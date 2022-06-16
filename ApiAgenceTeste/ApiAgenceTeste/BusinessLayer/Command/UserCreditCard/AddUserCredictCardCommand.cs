using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Common.Exceptions;
using BackEndPortafolioTarjeta.Persistence.DAO.Interfaces;
using BackEndPortafolioTarjeta.Persistence.Factory;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BackEndPortafolioTarjeta.BusinessLayer.Command.UserCreditCard
{
    public class AddUserCredictCardCommand : Command
    {
        /// <summary>
        /// Constructor de la clase 
        /// </summary>
        /// <param name="ciudad">Instancia ciudad que se desea insertar</param>
        public AddUserCredictCardCommand(Entity _entidad)
        {
            Entity = _entidad;
        }
        public override void Excute()
        {
            try
            {
                IDAOUserCreditCard _dao = DAOFactory.CreateDAOUserCreditCard();
                _dao.Add(Entity);
            }

            catch (Exception e)
            {
                throw new CustomException("Error en la base de datos en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }
        }


        /// <summary>
        /// Metodo que ejecuta la accion del comando
        /// </summary>
        public override List<Entity> GetEntities()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo que ejecuta la accion del comando
        /// </summary>
        public override Entity GetEntity()
        {
            throw new NotImplementedException();
        }
    }
}
