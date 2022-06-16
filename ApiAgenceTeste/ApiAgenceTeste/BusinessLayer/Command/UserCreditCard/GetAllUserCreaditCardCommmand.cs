using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Common.Exceptions;
using BackEndPortafolioTarjeta.Persistence.DAO.Interfaces;
using BackEndPortafolioTarjeta.Persistence.Factory;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BackEndPortafolioTarjeta.BusinessLayer.Command.UserCreditCard
{
    public class GetAllUserCreaditCardCommmand : Command
    {
        private List<Entity> _ListaTarjetas;

        public GetAllUserCreaditCardCommmand()
        {
            _ListaTarjetas = new List<Entity>();
        }

        public override void Excute()
        {
            try
            {
                IDAOUserCreditCard _dao = DAOFactory.CreateDAOUserCreditCard();
                _ListaTarjetas = _dao.GetAllCreditCards();
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
