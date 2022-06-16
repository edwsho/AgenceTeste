using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Common.Entities.EntityFactory;
using BackEndPortafolioTarjeta.Common.Exceptions;
using BackEndPortafolioTarjeta.Persistence.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BackEndPortafolioTarjeta.Persistence.DAO.Interfaces
{
    public class DAOUserCreditCard : DAO , IDAOUserCreditCard
    {

       /* private readonly DAO _context;

        //Igualo la instanciasion anterior a la nueva declarada
        public DAOUserCreditCard(DAO context)
        {
            _context = context;
        }
       */

        public DAOUserCreditCard()
        {
        }

        /// <summary>
		/// Metodo para consultar Todas las entidades UserCreditCard
		/// </summary>
		/// <returns></returns>
        public List<Entity> GetAllCreditCards()
        {
            List<Entity> _creditCardList = new List<Entity>();
 
            try
            {
                Conectar();
                StoredProcedure("GetConsultores()"); //GetConsultores  GetAllCreditCards
                EjecutarReader();

                for (int i = 0; i < cantidadRegistros; i++)
                {
                    Consultor _user = EntityFactory.CreateConsultor(GetString(i, 0));
                    _creditCardList.Add(_user);


                }
                return _creditCardList;

                //_creditCardList = _context.TarjetaCredito.ToList();
            }

            catch (NullReferenceException e)
            {
                throw new CustomException("Parametros nulos en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (InvalidCastException e)
            {
                throw new CustomException("Casteo no correcto en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (SqlException e)
            {
                throw new CustomException("Casteo no correcto en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (Exception e)
            {
                throw new CustomException("Casteo no correcto en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }
        }


        /// <summary>
		/// Metodo para consultar una UserCreditCard
		/// </summary>
		/// <param name="entidad">Entidad</param>
		/// <returns></returns>
        public Entity GetUserCreditCardsbyId(Entity entidad)
        {
            throw new NotImplementedException();
        }

        public void Refresh(Entity entidad)
        {
            try
            {
                UserCreditCard _creditCard = (UserCreditCard)entidad;

                Conectar();

                StoredProcedure("UpdateUserCreditCard @Id, @Nombre, @NumeroTarjeta, @FechaExp, @Cvv ");

                AgregarParametro("Id", _creditCard.Id);
                AgregarParametro("Nombre", _creditCard.Nombre);
                AgregarParametro("NumeroTarjeta", _creditCard.NumeroTarjeta);
                AgregarParametro("FechaExp", _creditCard.FechaExp);
                AgregarParametro("Cvv", _creditCard.CVV);

                int _modify = EjecutarQuery();

                //
                //var _RefreshCard = _context.TarjetaCredito.Attach(_creditCard);

                //_RefreshCard.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //_context.SaveChanges();
            }

            catch (NullReferenceException e)
            {
                throw new CustomException("Parametros nulos en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (InvalidCastException e)
            {
                throw new CustomException("Casteo no correcto en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (SqlException e)
            {
                throw new CustomException("Casteo no correcto en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }
            catch (Exception e)
            {
                throw new CustomException("Parametros nulos en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }
        }


        /// <summary>
        /// Metodo para Eliminar una UserCreditCard
        /// </summary>
        /// <param name="entidad">Entidad</param>
        /// <returns></returns>
        public void Delete(Entity entidad)
        {
            try
            {

                Conectar();

                StoredProcedure("DeleteUserCreditCard @Id");

                AgregarParametro("Id", entidad.Id);

                int _delete = EjecutarQuery();



                //UserCreditCard _creditCard = (UserCreditCard)entidad;
                //UserCreditCard findTarjeta = (UserCreditCard)_context.TarjetaCredito.Find(_creditCard.Id);

                //if (findTarjeta == null)
                //{
                //    throw new CustomException("Parametros nulos en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". ");
                //}
                //_context.TarjetaCredito.Remove(findTarjeta);
                //_context.SaveChanges();


                //return Ok(new { message = "Tarjeta Eliminada con exito!" });
            }

            catch (NullReferenceException e)
            {
                throw new CustomException("Parametros nulos en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (InvalidCastException e)
            {
                throw new CustomException("Casteo no correcto en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (SqlException e)
            {
                throw new CustomException("Casteo no correcto en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (Exception e)
            {

                throw new CustomException("Parametros nulos en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }
        }

        /// <summary>
        /// Metodo par agregar una Tarjeta de Credito de tipo Entidad
        /// </summary>
        /// <param name="entidad">Tarjeta de Credito a agregar</param>
        public void Add(Entity entidad)
        {
            try
            {

                //UserCreditCard _creditCard = (UserCreditCard)entidad;
                //_context.Add(_creditCard);
                //_context.SaveChanges();

                UserCreditCard _credit = (UserCreditCard)entidad;

                Conectar();
                StoredProcedure("InsertUserCreditCard @Nombre,@NumeroTarjeta,@FechaExp,@Cvv ");
                AgregarParametro("Nombre", _credit.Nombre);
                AgregarParametro("NumeroTarjeta", _credit.NumeroTarjeta);
                AgregarParametro("FechaExp", _credit.FechaExp);
                AgregarParametro("CVV", _credit.CVV);

                int _Filas = EjecutarQuery();



            }
            catch (NullReferenceException e)
            {
                throw new CustomException("Parametros nulos en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (InvalidCastException e)
            {
                throw new CustomException("Casteo no correcto en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (SqlException e)
            {
                throw new CustomException("Casteo no correcto en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

            catch (Exception e)
            {
                throw new CustomException("Casteo no correcto en: " + GetType().FullName + "." + MethodBase.GetCurrentMethod().Name + ". " + e.Message);
            }

        }

        public List<Entity> GetAll()
        {
            try
            {
                List<Entity> _creditCardList = new List<Entity>();
                //UserCreditCard _Credit;

                //_Credit = EntityFactory.CreateEmptyUserCreditCard();
                //_creditCardList = _context.TarjetaCredito.ToList();
                return _creditCardList;
            }
            catch (Exception e)
            {
                throw new CustomException("Error al Consultar la lista de Tarjetas de Credito");
            }
        }

        List<Entity> IDAO.GetAll()
        {
            throw new System.NotImplementedException();
        }

        
    }
}
