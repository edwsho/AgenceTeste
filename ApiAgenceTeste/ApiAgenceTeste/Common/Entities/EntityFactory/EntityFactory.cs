using ApiAgenceTeste.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndPortafolioTarjeta.Common.Entities.EntityFactory
{
    /// <summary>
	/// Fabrica que instancia todas las Entidades
	/// </summary>
    public static class EntityFactory
    {
		/// <summary>
		/// Metodo que realiza una instancia de tipo UserCreditCard
		/// </summary>
		/// <param name="nombre">Nombre del Usuario de la Tarjeta de Credito </param>
		/// <param name="numeroTarjeta">Numero de La Tarjeta de credito </param>
		/// <param name="fechaExp">Fecha de expiracion de la Tarjeta de credito</param>
		/// <param name="cVV">CVV codigo de verificacion</param>
		/// <returns></returns>
		public static UserCreditCard CreateUserCreditCard(string nombre, string numeroTarjeta, string fechaExp, string cVV)
        {
			return new UserCreditCard(nombre, numeroTarjeta, fechaExp, cVV);
        }


		/// <summary>
		/// Metodo que realiza una instancia de tipo UserCreditCard
		/// </summary>
		/// <param name="id">Id</param>
		/// <param name="nombre">Nombre del Usuario de la Tarjeta de Credito </param>
		/// <param name="numeroTarjeta">Numero de La Tarjeta de credito </param>
		/// <param name="fechaExp">Fecha de expiracion de la Tarjeta de credito</param>
		/// <param name="cVV">CVV codigo de verificacion</param>
		/// <returns></returns>
		public static UserCreditCard CreateUserCreditCardWithID(int id, string nombre, string numeroTarjeta, string fechaExp, string cVV)
		{
			return new UserCreditCard(id, nombre, numeroTarjeta, fechaExp, cVV);
		}

		public static UserCreditCard CreateEmptyUserCreditCard()
        {
			return new UserCreditCard();
        }

		public static Consultor CreateConsultor(string UserName)
        {
			return new Consultor(UserName);
        }

		public static Consultor CreateConsultor(string UserName, string CustoFixo)
		{
			return new Consultor(UserName, CustoFixo);
		}

		public static Consultor CreateConsultor(string UserName, string date1, string date2)
		{
			return new Consultor(UserName, date1, date2);
		}

		public static ReceitasConsultores CreateReceitasConsultores(string periodo, string receita, string comisao, string lucro, string custoFixo)
        {
			return new ReceitasConsultores(periodo, receita, comisao, lucro, custoFixo);
		}

		public static ConsultoresConsultados CreateConsultoresConsultados(string name)
		{
			return new ConsultoresConsultados(name );
		}

		public static ConsultoresConsultados CreateConsultoresConsultados(string name, List<ReceitasConsultores> _lista)
		{
			return new ConsultoresConsultados(name, _lista);
		}


	}
}
