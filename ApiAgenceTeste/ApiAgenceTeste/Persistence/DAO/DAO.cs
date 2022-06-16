using BackEndPortafolioTarjeta.Common.Entities;
using BackEndPortafolioTarjeta.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace BackEndPortafolioTarjeta.Persistence.DAO
{
    public abstract class DAO
    {
        private MySqlConnection _con;
        private MySqlCommand _command;
        //private SqlConnection _con;
        //private SqlCommand _command;
        private DataTable _dataTable;
        private DataSet _dataSet;
        private string _cadena;
        private int _cantidadRegistros;

        public DAO()
        {
            CrearStringConexion();
        }

        public int cantidadRegistros
        {
            get { return _cantidadRegistros; }
        }

        /// <summary>
        ///  Busca el string de conexión a la base de datos en el archivo web.config, dicho string se llama "postgrestring"
        /// </summary>
        private void CrearStringConexion()
        {
            //_cadena = "Server=(local)\\sqlexpress;Database=TarejtaCreditoDb;Trusted_Connection=True;MultipleActiveResultSets=True;";
            //_cadena = "Server=sql8002.site4now.net;Database=db_a881d4_agencetestedb;User Id=db_a881d4_agencetestedb_admin;Password=Gokart24;Trusted_Connection=False;MultipleActiveResultSets=True;";
            _cadena = "Server=MYSQL8002.site4now.net;Database=db_a881d4_eddie21;Uid=a881d4_eddie21;Pwd=Gokart24;Convert Zero Datetime=True;";
        }

        private bool IsConnected()
        {
            if (_con == null)
                return false;

            if (_con.State == System.Data.ConnectionState.Open)
                return true;

            return false;
        }

        public bool Conectar()
        {
            try
            {
                _con = new MySqlConnection(_cadena);   //_con = new SqlConnection(_cadena);
                _con.Open();
                return true;
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Desconectar()
        {
            if (_con != null && IsConnected())
                _con.Close();
        }

        /// <summary>
        /// Ejecutar el StoredProcedure con un valor de retorno (ResultSet), habilita el uso de las funciones "GetInt, GetString, etc" y devuelve un objeto DataTable.
        /// </summary>
        public DataTable EjecutarReader()
        {

            try
            {

                _dataTable = new DataTable();

                _dataTable.Load(_command.ExecuteReader());

                Desconectar();
                //Hacer Validacion de Cantidad de DataTables 
                _cantidadRegistros = _dataTable.Rows.Count;

            }
            catch (SqlException exc)
            {
                Desconectar();
                throw exc;
            }
            catch (Exception exc)
            {
                Desconectar();
                throw exc;
            }

            return _dataTable;

        }


        public DataSet EjecutarReaderDataSet()
        {

            try
            {

                _dataSet = new DataSet();

                _dataSet.Load(_command.ExecuteReader(), LoadOption.OverwriteChanges, "Sets");

                Desconectar();
                //Hacer Validacion de Cantidad de DataTables 
                _cantidadRegistros = _dataSet.Tables["Sets"].Rows.Count;

            }
            catch (SqlException exc)
            {
                Desconectar();
                throw exc;
            }
            catch (Exception exc)
            {
                Desconectar();
                throw exc;
            }

            return _dataSet;

        }


        /// <summary>
        /// Ejecutar el StoredProcedure sin valor de retorno (ResultSet), devuelve el número de filas afectadas.
        /// </summary>
        public int EjecutarQuery()
        {
            try
            {
                int filasAfectadas = _command.ExecuteNonQuery();

                Desconectar();

                return filasAfectadas;
            }
            catch (SqlException exc)
            {
                Desconectar();
                throw exc;
            }
            catch (Exception exc)
            {
                Desconectar();
                throw exc;
            }
        }

        /// <summary>
        /// Crea el comando para ejecutar el StoredProcedure, Ejemplo: StoredProcedure("nombreSP(@param)")
        /// </summary>
        public MySqlCommand StoredProcedure(string sp)   //public SqlCommand StoredProcedure(string sp)
        {
            try
            {
                _command = new MySqlCommand("call " + sp, _con); //_command = new MySqlCommand("EXECUTE " + sp, _con);    //new SqlCommand("select * from " + sp, _con);
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            return _command;
        }


        public void AgregarParametro(string nombre, object valor)
        {
            try
            {
                _command.Parameters.AddWithValue("@" + nombre, valor);
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (NullReferenceException exc)
            {
                throw exc;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        public int GetInt(int fila, int columna)
        {
            try
            {
                int intItem = Convert.ToInt32(_dataTable.Rows[fila][columna]);

                return intItem;
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (OverflowException e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public char GetChar(int fila, int columna)
        {
            try
            {
                char charItem = Convert.ToChar(_dataTable.Rows[fila][columna]);

                return charItem;
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetString(int fila, int columna)
        {
            try
            {
                string stringItem = Convert.ToString(_dataTable.Rows[fila][columna]);

                return stringItem;
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (ArgumentNullException e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public double GetDouble(int fila, int columna)
        {
            try
            {
                double doubleItem = Convert.ToDouble(_dataTable.Rows[fila][columna]);

                return doubleItem;
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (OverflowException e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public decimal GetDecimal(int fila, int columna)
        {
            try
            {
                decimal decimalItem = Convert.ToDecimal(_dataTable.Rows[fila][columna]);

                return decimalItem;
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (OverflowException e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool GetBool(int fila, int columna)
        {
            try
            {
                bool boolItem = Convert.ToBoolean(_dataTable.Rows[fila][columna]);

                return boolItem;
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DateTime GetDateTime(int fila, int columna)
        {
            try
            {
                DateTime dateItem = Convert.ToDateTime(_dataTable.Rows[fila][columna]);

                return dateItem;
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public byte[] GetByte(int fila, int columna)
        {
            try
            {
                byte[] dateItem = (byte[])_dataTable.Rows[fila][columna];

                return dateItem;
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetLengthDataTable()
        {
            try
            {
                int intItem = _dataTable.Rows.Count;

                return intItem;
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (OverflowException e)
            {
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
