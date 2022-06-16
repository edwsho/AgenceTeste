using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Common.Exceptions;
using BackEndPortafolioTarjeta.Persistence.DAO.Interfaces;
using BackEndPortafolioTarjeta.Persistence.Factory;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BackEndPortafolioTarjeta.BusinessLayer.Command.UserCreditCard
{
    public class RefreshUserCreditCardCommand : Command
    {

        public RefreshUserCreditCardCommand(Entity _entidad)
        {
            Entity = _entidad;
        }
        public override void Excute()
        {
            try
            {
                IDAOUserCreditCard _dao = DAOFactory.CreateDAOUserCreditCard();
                _dao.Refresh(Entity);
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
