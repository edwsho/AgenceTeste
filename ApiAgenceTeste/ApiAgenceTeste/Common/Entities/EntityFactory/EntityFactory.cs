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
		/// Metodo que realiza una instancia de tipo Consultor
		/// </summary>
		/// <param name="UserName">Nombre del Consultor </param>
		/// <returns></returns>
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
