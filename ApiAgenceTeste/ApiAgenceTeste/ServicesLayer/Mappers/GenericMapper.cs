using BackEndPortafolioTarjeta.Common.Entities;
using System.Collections.Generic;

namespace BackEndPortafolioTarjeta.ServicesLayer.Mappers
{
    public abstract class GenericMapper<TDTO>
    {

        public abstract TDTO CrearDto(Entity entidad);

        public abstract Entity CrearEntidad(TDTO dto);

        public abstract List<TDTO> CrearListaDto(List<Entity> entidades);

        public abstract List<Entity> CrearListaEntidades(List<TDTO> dtos);


    }
}
