using Connection;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Method
    {
        private Connection.Connection objConn;

        public Method()
        {
            objConn = new Connection.Connection();
        }

        public void BeginTransaction()
        {
            objConn.BeginTransaction(true);
        }

        public void CommitTransaction()
        {
            objConn.CommitTransaction();
        }

        public void DisposeTransaction()
        {
            objConn.DisposeTransaction();
        }

        public enum Metodo
        {
            INSERT,
            UPDATE,
            DELETE
        }

        #region UNIVERSIDAD

        public DataTable Event(string tabla, int id = 0)
        {
            string where = id > 0 ? $"Id = {id}" : "";

            return objConn.Select(tabla, "*", where);
        }

        public bool Event(string tabla, Dictionary<string, string> data, Metodo metodo)
        {
            bool estado = true;

            string columns = String.Empty;
            string values = String.Empty;
            string where = String.Empty;

            switch (metodo)
            {
                case Metodo.INSERT:
                    foreach (var item in data)
                    {
                        columns += $"{item.Key},";
                        values += item.Key.Contains("Fecha") ? $"CONVERT(SMALLDATETIME,'{item.Value}',103)" : $"'{item.Value}',";
                    }

                    if (!objConn.Insert(tabla, columns.TrimEnd(','), values.TrimEnd(',')))
                    {
                        estado = false;
                    }
                    break;

                case Metodo.UPDATE:
                    foreach (var item in data)
                    {
                        if (item.Key.Equals("Id"))
                        {
                            where = $"Id = {item.Value}";
                        }
                        else
                        {
                            values += item.Key.Contains("Fecha") ? $"{item.Key} = CONVERT(SMALLDATETIME,'{item.Value}',103)" : $"{item.Key} = '{item.Value}',";

                        }
                    }

                    if (!objConn.Update(tabla, values.TrimEnd(','), where))
                    {
                        estado = false;
                    }

                    break;

                case Metodo.DELETE:
                    foreach (var item in data)
                    {
                        if (item.Key == "Id")
                        {
                            where = $"Id = {Convert.ToInt32(item.Value)}";
                            break;
                        }
                    }

                    if (!objConn.Delete(tabla, where))
                    {
                        estado = false;
                    }

                    break;
            }

            return estado;
        }

        #endregion
    }
}
