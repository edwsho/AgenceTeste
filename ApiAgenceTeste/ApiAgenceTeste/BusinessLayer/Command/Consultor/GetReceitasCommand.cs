using ApiAgenceTeste.Common.Entities;
using BackEndPortafolioTarjeta.BusinessLayer.Factory;
using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Common.Exceptions;
using BackEndPortafolioTarjeta.Persistence.DAO.Interfaces;
using BackEndPortafolioTarjeta.Persistence.Factory;
using BackEndPortafolioTarjeta.ServicesLayer.DTO;
using BackEndPortafolioTarjeta.ServicesLayer.Factory;
using BackEndPortafolioTarjeta.ServicesLayer.Mappers;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BackEndPortafolioTarjeta.BusinessLayer.Command.Consultor
{
    public class GetReceitasCommand : Command
    {

        private List<Entity> _Users;//Lista de Consultores 
        
        private Entity _Entity;

        private Command _command;

        /// <summary>
        /// Constructor de la clase 
        /// </summary>
        /// <param name="ciudad">Instancia ciudad que se desea insertar</param>
        public GetReceitasCommand(List<Entity> _entidad)
        {
            _Users = _entidad;
        }

        public override void Excute()
        {
            try
            {
                ConsultorMapper traductor = MapperFactory.CreateConsultorMapper();
                List<DTOConsultor> dto = traductor.CrearListaDto(_Users);
                _Users.Clear();

                // Obtengo todas las receitas(Comisao, ReceitaLiquida, lucro)
                foreach (var item in dto)
                {
                    IDAOConsultor _dao = DAOFactory.CreateDAOConsultor();

                    //Consulto el Custo Fixo (Costo Fijo)
                    string _salario = _dao.GetCustoFixo(item.UserName);


                    //Consulto las Receitas
                    _Entity = _dao.GetReceitas(item.UserName,item.Date1,item.Date2, _salario);

                    ConsultoresConsultados consultoresConsultados = _Entity as ConsultoresConsultados;

                    //Verifico si la entidad tiene registros Periodo "N/A" de modo tal de no enviarlo al Front
                    if (consultoresConsultados.ListaReceitas[0].Periodo != "N/A")
                    {
                        _Users.Add(_Entity);
                    }
                    
                }

            }

            catch (Exception e)
            {
                throw new CustomException("Error en la base de datos en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }
        }

        public override List<Entity> GetEntities()
        {
            return _Users;
        }

        public override Entity GetEntity()
        {
            throw new NotImplementedException();
        }

    }
}
