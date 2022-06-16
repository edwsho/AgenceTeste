using BackEndPortafolioTarjeta.Common.Entities;
using System.Collections.Generic;

namespace BackEndPortafolioTarjeta.BusinessLayer.Command
{

    /// <summary>
    /// Superclase Comando
    /// </summary>
    public abstract class Command
    {
        private Entity _entidad;

        public Entity Entity { get => _entidad; set => _entidad = value; }

        public abstract void Excute();

        public abstract Entity GetEntity();

        public abstract List<Entity> GetEntities();

    }
}
