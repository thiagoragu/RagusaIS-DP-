using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class DAL_BaseDatos
    {
        //Data Source=.\SQLEXPRESS;Initial Catalog=BaseDiploma;Integrated Security=True;Encrypt=False

        string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        public SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public SqlCommand Command;
        public SqlTransaction Transaction;

        public DAL_BaseDatos(){ }

        public DataTable LeerBase(string Consulta, Hashtable TablaH)
        {
            DataTable Tabla = new DataTable();
            SqlDataAdapter DA;
            Command = new SqlCommand(Consulta, Connection);
            Command.CommandType = CommandType.StoredProcedure;
            try
            {
                DA = new SqlDataAdapter(Command);

                if (TablaH != null)
                {
                    foreach (string data in TablaH.Keys)
                    {
                        Command.Parameters.AddWithValue(data, TablaH[data]);
                    }
                }
                DA.Fill(Tabla);
                return Tabla;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EscribirBase(string Consulta, Hashtable TablaH)
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.ConnectionString = conexion;
                Connection.Open();
            }
            try
            {
                Transaction = Connection.BeginTransaction();
                Command = new SqlCommand(Consulta, Connection, Transaction);
                Command.CommandType = CommandType.StoredProcedure;

                if (TablaH != null)
                {
                    foreach (string data in TablaH.Keys)
                    {
                        Command.Parameters.AddWithValue(data, TablaH[data]);
                    }
                }
                int answer = Command.ExecuteNonQuery();
                Transaction.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                Transaction.Rollback();
                return false;
                throw ex;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                return false;
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
        }
        public int EscribirBaseID(string Consulta, Hashtable TablaH)
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.ConnectionString = conexion;
                Connection.Open();
            }
            try
            {
                Transaction = Connection.BeginTransaction();

                Command = new SqlCommand(Consulta, Connection, Transaction);
                Command.CommandType = CommandType.StoredProcedure;

                if (TablaH != null)
                {
                    foreach (string data in TablaH.Keys)
                    {
                        Command.Parameters.AddWithValue(data, TablaH[data]);
                    }
                }

                int idGenerado = Convert.ToInt32(Command.ExecuteScalar());
                Transaction.Commit();
                return idGenerado;
            }
            catch (SqlException ex)
            {
                Transaction.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                Transaction.Rollback();
                throw ex;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}



