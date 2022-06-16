using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Common.Exceptions;
using BackEndPortafolioTarjeta.Persistence.DAO.Interfaces;
using BackEndPortafolioTarjeta.Persistence.Factory;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BackEndPortafolioTarjeta.BusinessLayer.Command.Consultor
{
    public class GetAllConsultores : Command
    {
        private List<Entity> _ListaTarjetas;

        public GetAllConsultores()
        {
            _ListaTarjetas = new List<Entity>();
        }

        public override void Excute()
        {
            try
            {
                IDAOConsultor _dao = DAOFactory.CreateDAOConsultor();
                _ListaTarjetas = _dao.GetAll();
            }

            catch (Exception e)
            {
                throw new CustomException("Error en la base de datos en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }
        }

        public override List<Entity> GetEntities()
        {
            return _ListaTarjetas;
        }

        public override Entity GetEntity()
        {
            throw new NotImplementedException();
        }
    }
}
