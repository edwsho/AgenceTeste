using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Common.Entities.EntityFactory;
using BackEndPortafolioTarjeta.ServicesLayer.DTO;
using BackEndPortafolioTarjeta.ServicesLayer.Factory;
using System;
using System.Collections.Generic;

namespace BackEndPortafolioTarjeta.ServicesLayer.Mappers
{
    public class ConsultorMapper : GenericMapper<DTOConsultor>
    {
        public override DTOConsultor CrearDto(Entity entidad)
        {
            try
            {
                Consultor _consultor = entidad as Consultor;
                DTOConsultor _dto = null;

                _dto = DTOFactory.CreateDTOConsultor(_consultor.User, _consultor.Date1, _consultor.Date2);
                return _dto;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override Entity CrearEntidad(DTOConsultor dto)
        {
            try
            {
                Consultor _consult = EntityFactory.CreateConsultor(dto.UserName, dto.Date1, dto.Date2);
                return _consult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override List<DTOConsultor> CrearListaDto(List<Entity> entidades)
        {
            try
            {
                List<DTOConsultor> _dtoList = new List<DTOConsultor>();

                foreach (Entity _entity in entidades)
                {

                    _dtoList.Add(CrearDto(_entity));

                }

                return _dtoList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override List<Entity> CrearListaEntidades(List<DTOConsultor> dtos)
        {
            try
            {
                List<Entity> _entityList = new List<Entity>();

                foreach (DTOConsultor _item in dtos)
                {
                    _entityList.Add(CrearEntidad(_item));
                }
                return _entityList;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
