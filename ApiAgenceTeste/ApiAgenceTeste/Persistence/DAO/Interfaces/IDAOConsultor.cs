using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Persistence.Interfaces;
using System.Collections.Generic;

namespace BackEndPortafolioTarjeta.Persistence.DAO.Interfaces
{
    public interface IDAOConsultor : IDAO
    {

        List<Entity> GetReceitas(List<Entity> entidad);

        Entity GetReceitas(string _username,string _date1, string _date2, string _salario);

        string GetCustoFixo(string _username);


    }
}
