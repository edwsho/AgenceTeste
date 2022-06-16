using BackEndPortafolioTarjeta.Common.Entities;
using System;
using System.Collections.Generic;

namespace ApiAgenceTeste.Common.Entities
{
    public class ConsultoresConsultados : Entity
    {

        private string _name;
        private List<ReceitasConsultores> _listReceitas;
        private List<Entity> _listReceitas2;


        public ConsultoresConsultados()
        {

        }

        public ConsultoresConsultados(string name)
        {
            Name = name;
        }

        public ConsultoresConsultados(string name, List<ReceitasConsultores> listaReceitas)
        {
            Name = name;
            ListaReceitas = listaReceitas;
        }

        //public ConsultoresConsultados(string name, List<Entity> listaReceitas2)
        //{
        //    Name = name;
        //    _listReceitas2 = listaReceitas2;
        //}

        public string Name { get => _name; set => _name = value; }
        public List<ReceitasConsultores> ListaReceitas { get => _listReceitas; set => _listReceitas = value; }
    }
}
