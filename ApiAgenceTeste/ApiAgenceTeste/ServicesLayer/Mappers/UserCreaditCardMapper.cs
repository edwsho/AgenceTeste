using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Common.Entities.EntityFactory;
using BackEndPortafolioTarjeta.ServicesLayer.DTO;
using BackEndPortafolioTarjeta.ServicesLayer.Factory;
using System;
using System.Collections.Generic;

namespace BackEndPortafolioTarjeta.ServicesLayer.Mappers
{
    public class UserCreaditCardMapper : GenericMapper<DTOUserCreditCard>
    {
        /// <summary>
        /// Metodo con el cual se transforma una entidad en un DTOCiudad
        /// </summary>
        /// <param name="entidad">Entidad que se desea transformar</param>
        /// <returns></returns>
        public override DTOUserCreditCard CrearDto(Entity entidad)
        {
            try
            {
                UserCreditCard _credit = entidad as UserCreditCard;
                DTOUserCreditCard _dto = null;

                _dto = DTOFactory.CreateDTOUserCreaditCard(_credit.Id, _credit.Nombre, _credit.NumeroTarjeta, _credit.FechaExp, _credit.CVV); 
                return _dto;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo con el cual se transforma un DTOCiudad a una Entidad UserCreditCard
        /// </summary>
        /// <param name="dto">Objeto dto que se desea transformar</param>
        /// <returns></returns>
        public override Entity CrearEntidad(DTOUserCreditCard dto)
        {
            try
            {
                UserCreditCard _credit = EntityFactory.CreateUserCreditCardWithID(dto.Id, dto.Nombre, dto.NumeroTarjeta, dto.FechaExp, dto.CVV);
                return _credit;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo con el cual se transforma de una lista de entidades a una lista de dtos
        /// </summary>
        /// <param name="entidades">Lista de entidades que se va a transformar</param>
        /// <returns></returns>
        public override List<DTOUserCreditCard> CrearListaDto(List<Entity> entidades)
        {
            try
            {
                List<DTOUserCreditCard> _dtoList = new List<DTOUserCreditCard>();

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


        /// <summary>
        /// Metodo con el cual se transforma de una lista de dtos a una lista de entidades
        /// </summary>
        /// <param name="dtos">Lista de dtos que se va a transformar</param>
        /// <returns></returns>
        public override List<Entity> CrearListaEntidades(List<DTOUserCreditCard> dtos)
        {
            try
            {
                List<Entity> _entityList = new List<Entity>();

                foreach (DTOUserCreditCard _item in dtos)
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
