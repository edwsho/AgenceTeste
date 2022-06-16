using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Common.Exceptions;
using BackEndPortafolioTarjeta.Persistence.DAO.Interfaces;
using BackEndPortafolioTarjeta.Persistence.Factory;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BackEndPortafolioTarjeta.BusinessLayer.Command.UserCreditCard
{
    public class DeleteUserCreditCardCommand : Command
    {
        public DeleteUserCreditCardCommand(Entity _entity)
        {
            Entity = _entity;
        }

        public override void Excute()
        {
            try
            {
                IDAOUserCreditCard _dao = DAOFactory.CreateDAOUserCreditCard();
                _dao.Delete(Entity);
            }

            catch (Exception e)
            {
                throw new CustomException("Error en la base de datos en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }
        }

        public override List<Entity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public override Entity GetEntity()
        {
            throw new NotImplementedException();
        }
    }
}
