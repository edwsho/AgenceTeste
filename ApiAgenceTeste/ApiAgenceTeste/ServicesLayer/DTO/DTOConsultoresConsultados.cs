using ApiAgenceTeste.Common.Entities;
using BackEndPortafolioTarjeta.Common.Entities;
using System.Collections.Generic;

namespace ApiAgenceTeste.ServicesLayer.DTO
{
    public class DTOConsultoresConsultados
    {

        private string _name;
        private List<ReceitasConsultores> _listReceitas;

        public DTOConsultoresConsultados()
        {

        }

        public DTOConsultoresConsultados(string name, List<ReceitasConsultores> listaReceitas)
        {
            Name = name;
            ListaReceitas = listaReceitas;
        }

        public string Name { get => _name; set => _name = value; }
        public List<ReceitasConsultores> ListaReceitas { get => _listReceitas; set => _listReceitas = value; }

    }
}
