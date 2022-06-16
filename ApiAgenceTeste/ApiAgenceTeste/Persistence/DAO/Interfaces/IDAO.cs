using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEndPortafolioTarjeta.Common.Entities;

namespace BackEndPortafolioTarjeta.Persistence.Interfaces
{
    public interface IDAO
    {
        void Add(Entity entidad);

        void Refresh(Entity entidad);

        void Delete(Entity entidad);

        List<Entity> GetAll();
    }
}
