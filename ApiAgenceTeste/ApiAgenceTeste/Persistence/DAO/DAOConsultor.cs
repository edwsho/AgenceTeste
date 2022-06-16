using ApiAgenceTeste.Common.Entities;
using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Common.Entities.EntityFactory;
using BackEndPortafolioTarjeta.Common.Exceptions;
using BackEndPortafolioTarjeta.Persistence.DAO.Interfaces;
using BackEndPortafolioTarjeta.Persistence.Interfaces;
using BackEndPortafolioTarjeta.ServicesLayer.DTO;
using BackEndPortafolioTarjeta.ServicesLayer.Factory;
using BackEndPortafolioTarjeta.ServicesLayer.Mappers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace BackEndPortafolioTarjeta.Persistence.DAO
{
    public class DAOConsultor : DAO, IDAOConsultor
    {

        List<ReceitasConsultores> _listaReceitas = new List<ReceitasConsultores>();
        List<Entity> _listaConsultados = new List<Entity>();
        Entity _costoFixoConsultor;



        public DAOConsultor()
        {
        }

        /// <summary>
		/// Metodo para consultar Todas las entidades Receitas Correspondientes a un Consultor con Rango de Fecha en especifico.
		/// </summary>
		/// <returns></returns>
        public Entity GetReceitas(string entidad, string _date1, string _date2, string _salario)
        {
            try
            {
                    Conectar();

                    StoredProcedure("GetReceitas(@ConsultorName,@Date1,@Date2)"); // GetOfficeByCountry(@countryName)  GetConsultores  GetAllCreditCards

                    AgregarParametro("ConsultorName", entidad);
                    AgregarParametro("Date1", _date1);
                    AgregarParametro("Date2", _date2);

                    EjecutarReader();

                    if (cantidadRegistros == 0)
                    {
                    _salario = "0";
                    ReceitasConsultores _user = EntityFactory.CreateReceitasConsultores("N/A", "0", "0", "0", _salario);
                    //-------------------

                    _listaReceitas.Add(_user);
                    }
                    else
                        {
                            for (int i = 0; i < cantidadRegistros; i++)
                            {
                                float _lucro = 0;
                                _lucro = float.Parse(GetString(i, 4)) - float.Parse(_salario) - float.Parse(GetString(i, 5));
                                ReceitasConsultores _user = EntityFactory.CreateReceitasConsultores(GetString(i, 1), GetString(i, 4), GetString(i, 5), _lucro.ToString(), _salario);

                                // Asigno el Nombre y ano del Mes correspondiente
                                DateTime _datevalue = (Convert.ToDateTime(_user.Periodo.ToString()));
                                int _mn = _datevalue.Month;
                                string _mn2 = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(_mn).ToUpper().Replace(".", " ");
                                string _yy = _datevalue.Year.ToString();
                                _user.Periodo = _mn2 + _yy;
                                //-------------------

                                _listaReceitas.Add(_user);
                            }
    
                        }

                    ConsultoresConsultados _consulta = EntityFactory.CreateConsultoresConsultados(entidad, _listaReceitas);
                
                return _consulta;    

                //_listaConsultados.Add(_consulta);
                //return _listaConsultados;

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

        public void Add(Entity entidad)
        {
            throw new NotImplementedException();
        }

        public void Delete(Entity entidad)
        {
            throw new NotImplementedException();
        }

        public List<Entity> GetAll()
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

        public List<Entity> GetUserCreditCardsbyId(List<Entity> entidad)
        {
            throw new NotImplementedException();
        }

        public void Refresh(Entity entidad)
        {
            throw new NotImplementedException();
        }

        public List<Entity> GetReceitas(List<Entity> entidad)
        {
            throw new NotImplementedException();
        }

        public string GetCustoFixo(string _entity)
        {
            try
            {
                
                Conectar();

                StoredProcedure("getCustoFixoConsultor(@ConsultorName)"); // GetOfficeByCountry(@countryName)  GetConsultores  GetAllCreditCards

                AgregarParametro("ConsultorName", _entity);

                EjecutarReader();

                if (GetLengthDataTable() == 0 )
                {
                    return "0";
                }
                else
                {
                    return GetString(0, 1);
                }
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
    }
}
