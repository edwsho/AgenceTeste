using ApiAgenceTeste.Common.Entities;
using ApiAgenceTeste.ServicesLayer.DTO;
using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.ServicesLayer.DTO;
using System.Collections.Generic;

namespace BackEndPortafolioTarjeta.ServicesLayer.Factory
{
    public class DTOFactory
    {
        /// <summary>
        /// Metodo que instancia un objeto de tipo DTOConsultor
        /// </summary>
        /// <param name="nombre">>Nombre de la Tarjeta de Creadito</param>
        /// <returns></returns>
        public static DTOConsultor CreateDTOConsultor(string nombre)
        {
            return new DTOConsultor(nombre);
        }


        /// <summary>
        /// Metodo que instancia un objeto de tipo DTOConsultor
        /// </summary>
        /// <param name="nombre">>Nombre del Consultor</param>
        /// <param name="date1">>Primer Fecha del filtro</param>
        /// <param name="date2">>Sefunda Fecha del filtro</param>
        /// <returns></returns>
        public static DTOConsultor CreateDTOConsultor(string nombre, string date1, string date2)
        {
            return new DTOConsultor(nombre,date1,date2);
        }


        /// <summary>
        /// Metodo que instancia un objeto de tipo DTOReceitasConsultores
        /// </summary>
        /// <param name="periodo">>Periodo resultante de la consulta de Receitas</param>
        /// <param name="receita">>Receita total del consultor en el periodo</param>
        /// <param name="comisao">>Comissao del consultor en el periodo</param>
        /// <param name="lucro">>Lucro del consultor en el periodo</param>
        /// <returns></returns>
        public static DTOReceitasConsultores CreateDTOReceitasConsultores(string periodo, string receita, string comisao, string lucro)
        {
            return new DTOReceitasConsultores(periodo, receita, comisao, lucro);
        }

        /// <summary>
        /// Metodo que instancia un objeto de tipo DTOReceitasConsultores
        /// </summary>
        /// <param name="periodo">>Periodo resultante de la consulta de Receitas </param>
        /// <param name="receita">>Receita total del consultor en el periodo</param>
        /// <param name="comisao">>Comissao del consultor en el periodo</param>
        /// <param name="lucro">>Lucro del consultor en el periodo</param>
        /// <param name="custo">>Custo Fixo o Sueldo del consultor en el periodo</param>
        /// <returns></returns>
        public static DTOReceitasConsultores CreateDTOReceitasConsultores(string periodo, string receita, string comisao, string lucro, string custo)
        {
            return new DTOReceitasConsultores(periodo, receita, comisao, lucro, custo);
        }

        /// <summary>
        /// Metodo que instancia un objeto de tipo DTOConsultoresConsultados
        /// </summary>
        /// <param name="nombre">>Nombre del Consultor</param>
        /// /// <param name="_lista">>Lista de Receitas del Consultor</param>
        /// <returns></returns>
        public static DTOConsultoresConsultados CreateDTOConsultoresConsultados(string name, List<ReceitasConsultores> _lista)
        {
            return new DTOConsultoresConsultados(name, _lista);
        }



    }
}
