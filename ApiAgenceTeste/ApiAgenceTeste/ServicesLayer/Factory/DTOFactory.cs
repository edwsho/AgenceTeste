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
        /// Metodo que instancia un objeto de tipo DTOUserCreditCard
        /// </summary>
        /// <param name="id">Id Tarjeta de Creadito </param>
        /// <param name="nombre">>Nombre de la Tarjeta de Creadito/param>
        /// <param name="numeroTarjeta">Numero de la Tarjeta de Credito</param>
        /// <param name="fechaExp">Fecha Expiracion</param>
        /// <param name="cvv">CVV</param>
        /// <returns></returns>
        public static DTOUserCreditCard CreateDTOUserCreaditCard(int id, string nombre, string numeroTarjeta, string fechaExp, string cvv)
        {
            return new DTOUserCreditCard(id, nombre,numeroTarjeta,fechaExp,cvv);
        }

        /// <summary>
        /// Metodo que instancia un objeto de tipo DTOConsultor
        /// </summary>
        /// <param name="nombre">>Nombre de la Tarjeta de Creadito/param>
        /// <returns></returns>
        public static DTOConsultor CreateDTOConsultor(string nombre)
        {
            return new DTOConsultor(nombre);
        }


        /// <summary>
        /// Metodo que instancia un objeto de tipo DTOConsultor
        /// </summary>
        /// <param name="nombre">>Nombre de la Tarjeta de Creadito/param>
        /// <returns></returns>
        public static DTOConsultor CreateDTOConsultor(string nombre, string date1, string date2)
        {
            return new DTOConsultor(nombre,date1,date2);
        }


        /// <summary>
        /// Metodo que instancia un objeto de tipo DTOConsultor
        /// </summary>
        /// <param name="nombre">>Nombre de la Tarjeta de Creadito/param>
        /// <returns></returns>
        public static DTOReceitasConsultores CreateDTOReceitasConsultores(string periodo, string receita, string comisao, string lucro)
        {
            return new DTOReceitasConsultores(periodo, receita, comisao, lucro);
        }

        /// <summary>
        /// Metodo que instancia un objeto de tipo DTOConsultor
        /// </summary>
        /// <param name="nombre">>Nombre de la Tarjeta de Creadito/param>
        /// <returns></returns>
        public static DTOReceitasConsultores CreateDTOReceitasConsultores(string periodo, string receita, string comisao, string lucro, string custo)
        {
            return new DTOReceitasConsultores(periodo, receita, comisao, lucro, custo);
        }

        /// <summary>
        /// Metodo que instancia un objeto de tipo DTOConsultor
        /// </summary>
        /// <param name="nombre">>Nombre de la Tarjeta de Creadito/param>
        /// <returns></returns>
        public static DTOConsultoresConsultados CreateDTOConsultoresConsultados(string name, List<ReceitasConsultores> _lista)
        {
            return new DTOConsultoresConsultados(name, _lista);
        }



    }
}
