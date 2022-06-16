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
    public class ReceitasConsultoresMapper : GenericMapper<DTOReceitasConsultores>
    {

        public override DTOReceitasConsultores CrearDto(Entity entidad)
        {
            try
            {
                ReceitasConsultores _receitas = entidad as ReceitasConsultores;
                DTOReceitasConsultores _dto = null;

                _dto = DTOFactory.CreateDTOReceitasConsultores(_receitas.Periodo, _receitas.Receita, _receitas.Comisao, _receitas.Lucro, _receitas.CustoFixo);
                return _dto;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override Entity CrearEntidad(DTOReceitasConsultores dto)
        {
            try
            {
                ReceitasConsultores _consult = EntityFactory.CreateReceitasConsultores(dto.Periodo, dto.Receita, dto.Comisao, dto.Lucro, dto.CustoFixo);
                return _consult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override List<DTOReceitasConsultores> CrearListaDto(List<Entity> entidades)
        {
            try
            {
                List<DTOReceitasConsultores> _dtoList = new List<DTOReceitasConsultores>();

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

        public override List<Entity> CrearListaEntidades(List<DTOReceitasConsultores> dtos)
        {
            try
            {
                List<Entity> _entityList = new List<Entity>();

                foreach (DTOReceitasConsultores _item in dtos)
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
