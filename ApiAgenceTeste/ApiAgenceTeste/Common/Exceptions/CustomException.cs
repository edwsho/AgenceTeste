using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEndPortafolioTarjeta.Common.Exceptions
{
    public class CustomException : Exception
    {
        private string _message;   // Descripcion o pequeno mensaje sobre la exception 
        private DateTime _fecha;   // Fecha en la que se genero la Exception

        public CustomException(string message)
        {
            _message = message;   
            _fecha = DateTime.Now;
        }

        public CustomException()
        {

        }

        /// <summary>
        /// Getters y Setters del atributo _message
        /// </summary>
        public string Message { get => _message; set => _message = value; }

        /// <summary>
        /// Getters y Setters del atributo _fecha
        /// </summary>
        public DateTime Fecha { get => _fecha; set => _fecha = value; }


    }
}
