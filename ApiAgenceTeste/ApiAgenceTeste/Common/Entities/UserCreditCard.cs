using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BackEndPortafolioTarjeta.Common.Entities
{
    public class UserCreditCard : Entity
    {
        //private string _id;
        private string _nombre;
        private string _numeroTarjeta;
        private string _fechaExp;
        private string _cvv;


        public UserCreditCard()
        {

        }

        public UserCreditCard(int _id)
        {
            Id = _id;
        }

        /// <summary>
		/// Constructor de la Entidad UserCreditCard con todos los atributos
		/// </summary>
        public UserCreditCard(string nombre, string numeroTarjeta, string fechaExp, string cVV)
        {
            Nombre = nombre;
            NumeroTarjeta = numeroTarjeta;
            FechaExp = fechaExp;
            CVV = cVV;
        }

        /// <summary>
		/// Constructor de la Entidad UserCreditCard con todos los atributos
		/// </summary>
        public UserCreditCard(int id, string nombre, string numeroTarjeta, string fechaExp, string cVV)
        {
            Id = id;                      // Este Id hereda de Entity ya que lo implementa  
            Nombre = nombre;
            NumeroTarjeta = numeroTarjeta;
            FechaExp = fechaExp;
            CVV = cVV;
        }

        /// <summary>
		/// Getters y Setters del atributo _nombre
		/// </summary>
        public string Nombre { get => _nombre; set => _nombre = value; }

        /// <summary>
		/// Getters y Setters del atributo _numeroTarjeta
		/// </summary>
        public string NumeroTarjeta { get => _numeroTarjeta; set => _numeroTarjeta = value; }

        /// <summary>
		/// Getters y Setters del atributo _fechaExp
		/// </summary>
        public string FechaExp { get => _fechaExp; set => _fechaExp = value; }

        /// <summary>
        /// Getters y Setters del atributo _cvv
        /// </summary>
        public string CVV { get => _cvv; set => _cvv = value; }




    }
}
