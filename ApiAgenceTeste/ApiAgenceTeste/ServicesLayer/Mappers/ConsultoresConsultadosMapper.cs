using ApiAgenceTeste.Common.Entities;
using ApiAgenceTeste.ServicesLayer.DTO;
using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Common.Entities.EntityFactory;
using BackEndPortafolioTarjeta.ServicesLayer.Factory;
using BackEndPortafolioTarjeta.ServicesLayer.Mappers;
using System;
using System.Collections.Generic;

namespace ApiAgenceTeste.ServicesLayer.Mappers
{
    public class ConsultoresConsultadosMapper : GenericMapper<DTOConsultoresConsultados>
    {
        public override DTOConsultoresConsultados CrearDto(Entity entidad)
        {
            try
            {
                ConsultoresConsultados _receitas = entidad as ConsultoresConsultados;
                DTOConsultoresConsultados _dto = null;

                int i = _receitas.ListaReceitas.Count;


                _dto = DTOFactory.CreateDTOConsultoresConsultados(_receitas.Name, _receitas.ListaReceitas);

                return _dto;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override Entity CrearEntidad(DTOConsultoresConsultados dto)
        {
            try
            {
                ConsultoresConsultados _consult = EntityFactory.CreateConsultoresConsultados(dto.Name, dto.ListaReceitas);
                return _consult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override List<DTOConsultoresConsultados> CrearListaDto(List<Entity> entidades)
        {
            try
            {
                List<DTOConsultoresConsultados> _dtoList = new List<DTOConsultoresConsultados>();

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

        public override List<Entity> CrearListaEntidades(List<DTOConsultoresConsultados> dtos)
        {
            try
            {
                List<Entity> _entityList = new List<Entity>();

                foreach (DTOConsultoresConsultados _item in dtos)
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
