using ApiAgenceTeste.Common.Entities;
using ApiAgenceTeste.ServicesLayer.Mappers;
using BackEndPortafolioTarjeta.ServicesLayer.Mappers;

namespace BackEndPortafolioTarjeta.ServicesLayer.Factory
{
    public class MapperFactory
    {
        /// <summary>
        /// Metodo con el cual se instancia un objeto de tipo ConsultorMapper
        /// </summary>
        /// <returns></returns>
        public static ConsultorMapper CreateConsultorMapper()
        {
            return new ConsultorMapper();
        }

        /// <summary>
        /// Metodo con el cual se instancia un objeto de tipo ReceitasConsultoresMapper
        /// </summary>
        /// <returns></returns>
        public static ReceitasConsultoresMapper CreateReceitasConsultoresMapper()
        {
            return new ReceitasConsultoresMapper();
        }

        /// <summary>
        /// Metodo con el cual se instancia un objeto de tipo ConsultoresConsultadosMapper
        /// </summary>
        /// <returns></returns>
        public static ConsultoresConsultadosMapper CreateConsultoresConsultadosMapper()
        {
            return new ConsultoresConsultadosMapper();
        }

    }
}
