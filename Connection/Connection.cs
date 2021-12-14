using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Transactions;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using Structures;

namespace Connection
{


    public class Connection
    {
        Structures.Structures structures = new Structures.Structures();
        private TransactionScope Transaction { get; set; }
        public string Query { get; set; }

        public Connection()
        {
            GetTransaction();
        }

        #region TRANSACCIONES

        private void GetTransaction()
        {
            if (System.Transactions.Transaction.Current != null)
            {
                bool isError = false;
                try
                {
                    if (System.Transactions.Transaction.Current.TransactionInformation.Status == TransactionStatus.Active)
                    {
                        if (Transaction == null)
                            Transaction = new TransactionScope(System.Transactions.Transaction.Current);
                    }
                    else
                        isError = true;
                }
                catch
                {
                    isError = true;
                }
                finally
                {
                    if (isError)
                        EndTransaction(false);
                }
            }
        }

        public void EndTransaction(bool generarTransaccion = true)
        {
            if (System.Transactions.Transaction.Current == null)
                return;

            if (generarTransaccion)
                GetTransaction();
            try
            {
                System.Transactions.Transaction.Current.Rollback();
            }
            catch
            {

            }
            finally
            {
                if (Transaction != null)
                    Transaction.Dispose();
                Transaction = null;
                System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    int counter = 0;
                    while (System.Transactions.Transaction.Current != null)
                    {
                        try
                        {
                            counter++;
                            if (System.Transactions.Transaction.Current.TransactionInformation.Status != TransactionStatus.Active)
                                System.Transactions.Transaction.Current.Rollback();

                            if (Transaction != null)
                            {
                                Transaction = null;

                                if (System.Transactions.Transaction.Current == null)
                                    break;
                            }

                            if (counter > 1 && System.Transactions.Transaction.Current.TransactionInformation.Status != TransactionStatus.Active)
                            {
                                System.Transactions.Transaction.Current.Dispose();
                                break;
                            }

                            Transaction = new TransactionScope(System.Transactions.Transaction.Current);
                            Transaction.Dispose();
                            Transaction = null;
                        }
                        catch { }
                    }
                });
            }
        }

        public void BeginTransaction(bool isTransaction)
        {
            if (!isTransaction)
                return;

            if (System.Transactions.Transaction.Current != null)
            {
                if (Transaction != null)
                    return;
                Transaction = new TransactionScope(System.Transactions.Transaction.Current);
                return;
            }

            Transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead, Timeout = new TimeSpan(1, 0, 0) });
        }

        public void CommitTransaction()
        {
            GetTransaction();
            Transaction.Complete();
            Transaction.Dispose();
            Transaction = null;
        }

        public void DisposeTransaction()
        {
            EndTransaction();
        }

        public bool StarProcedure(string name)
        {
            if (System.Transactions.Transaction.Current != null)
                return false;

            DataTable sp = structures.ExecQuery("sp_helpText " + name);

            if (sp == null)
                return false;

            if (sp.Rows.Count == 0)
                return false;
            else
                return true;
        }

        #endregion

        public DataTable Select(string table, string column, string where = "", string orderBy = "", string groupBy = "", string having = "")
        {
            DataTable dt = new DataTable();
            string query = "select " + column + " from " + table + " " + ((where != "") ? " where " + where : "") + ((groupBy == "") ? "" : " group by " + groupBy) + ((having == "") ? "" : " having " + having) + ((orderBy == "") ? "" : " order by " + orderBy);

            try
            {
                dt = structures.ExecQuery(query);
            }
            catch (Exception)
            {
                EndTransaction(false);
                dt = null;
            }

            return dt;
        }

        public bool Insert(string table, string column, string value)
        {
            bool estado = true;
            BeginTransaction(true);
            String QInsert = "insert into " + table + " (" + column + ") values (" + value + ")";
            try
            {
                estado = structures.Exec(QInsert);
            }
            catch (Exception ex)
            {
                estado = false;
            }

            return estado;
        }

        public bool Update(string table, string value, string where, string from = "")
        {
            bool estado = true;
            string fromSql = (from == "") ? "" : " from " + from;
            String Cond = (where == "") ? "" : " where " + where;
            String query = "update " + table + " set " + value + fromSql + Cond;

            BeginTransaction(true);
            try
            {
                estado = structures.Exec(query);
            }
            catch (Exception ex)
            {
                estado = false;
            }

            return estado;
        }

        public bool Delete(string table, string where, string from = "")
        {
            bool estado = true;
            String query = "delete from " + table + ((from.Trim() == "") ? "" : " from " + from) + " where " + where + "";


            BeginTransaction(true);
            try
            {
                estado = structures.Exec(query);
            }
            catch (Exception ex)
            {
                estado = false;
            }

            return estado;
        }

        public DataTable StoreProcedure(string name, string values)
        {
            String query = "EXEC " + name + " " + values;
            BeginTransaction(StarProcedure(name));

            try
            {
                DataTable dt = structures.ExecQuery(query);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
