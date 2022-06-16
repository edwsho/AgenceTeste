using BackEndPortafolioTarjeta.BusinessLayer.Command.Consultor;
using BackEndPortafolioTarjeta.BusinessLayer.Command.UserCreditCard;
using BackEndPortafolioTarjeta.Common.Entities;
using System.Collections.Generic;

namespace BackEndPortafolioTarjeta.BusinessLayer.Factory
{
    public static class CommandFactory
    {

        public static AddUserCredictCardCommand AddUserCredictCardCommand(Entity _entidad)
        {
            return new AddUserCredictCardCommand(_entidad);
        }

        public static GetAllUserCreaditCardCommmand GetAllUserCreaditCardCommmand()
        {
            return new GetAllUserCreaditCardCommmand();
        }

        public static RefreshUserCreditCardCommand RefreshUserCreditCardCommand(Entity _entity)
        {
            return new RefreshUserCreditCardCommand(_entity);
        }

        public static DeleteUserCreditCardCommand DeleteUserCreditCardCommand(Entity _entity)
        {
            return new DeleteUserCreditCardCommand(_entity);
        }

        public static GetReceitasCommand GetReceitasCommand(List<Entity> _entity)
        {
            return new GetReceitasCommand(_entity);
        }

        public static GetAllConsultores GetAllConsultores()
        {
            return new GetAllConsultores();
        }



    }
}
