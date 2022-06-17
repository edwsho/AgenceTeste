using BackEndPortafolioTarjeta.BusinessLayer.Command.Consultor;
using BackEndPortafolioTarjeta.Common.Entities;
using System.Collections.Generic;

namespace BackEndPortafolioTarjeta.BusinessLayer.Factory
{
    public static class CommandFactory
    {

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
