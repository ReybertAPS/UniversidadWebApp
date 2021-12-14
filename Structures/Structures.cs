using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Structures
{
    public class Structures
    {
        private DataTable dt;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dataSource"].ConnectionString);

        private SqlConnection OpenConnection()
        {
            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hubo un error: " + ex.Message);
                }
            }
            return con;
        }

        private void CloseConnection()
        {
            if (con.State != ConnectionState.Closed)
            {
                try
                {
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrio un error: " + ex.Message);
                }
            }
        }

        public DataTable ExecQuery(string query)
        {
            dt = new DataTable();
            try
            {
                OpenConnection();
                da = new SqlDataAdapter(query, con);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        public bool Exec(string query)
        {
            bool estado = true;
            int filas = 0;

            try
            {
                OpenConnection();
                cmd = new SqlCommand(query, con);
                filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                    estado = true;
                else
                    estado = false;

            }
            catch (Exception ex)
            {
                estado = false;

            }
            finally
            {
                CloseConnection();
            }

            return estado;
        }

        protected static void OnInfoMessage(object sender, SqlInfoMessageEventArgs args)
        {
            string result = string.Empty;
            foreach (SqlError err in args.Errors)
            {
                result = err.Source + "," + err.Class + "," + err.State + "," + err.Number + "," + err.LineNumber + "," +
                err.Procedure + "," + err.Server + "," + err.Message;
            }
        }

    }
}
