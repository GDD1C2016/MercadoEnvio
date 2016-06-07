using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
using MercadoEnvio.Properties;

namespace MercadoEnvio.Helpers
{
    public class DataBaseHelper
    {
        #region attributes
        private string _connectionString;
        private readonly SqlConnection _sqlConn;
        private SqlTransaction _sqlTrans;
        #endregion

        #region properties
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public enum ExecutionType
        {
            Scalar,
            NonQuery
        };

        public SqlConnection Connection
        {
            get { return _sqlConn; }
        }
        #endregion

        #region constructor
        public DataBaseHelper(string connectionString)
        {
            _connectionString = connectionString;
            _sqlConn = new SqlConnection(_connectionString);
        }
        #endregion

        #region methods
        #region transaction methods

        public void BeginTransaction()
        {
            if (Connection != null)
            {
                if (Connection.State != ConnectionState.Open)
                    try
                    {
                        Connection.Open();
                    }
                    catch (SqlException)
                    {
                        throw new Exception(Resources.ErrorBD);
                    }
                    catch (ConfigurationErrorsException)
                    {
                        throw new Exception(Resources.ErrorBD);
                    }

                try
                {
                    _sqlTrans = Connection.BeginTransaction();
                }
                catch (Exception ex)
                {
                    throw new Exception(Resources.ErrorBeginTrans, ex);
                }
            }
            else
                throw new Exception(Resources.ErrorNoConnection);
        }

        public void RollbackTransaction()
        {
            if (_sqlTrans != null)
            {
                try
                {
                    _sqlTrans.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception(Resources.ErrorRollbackTrans, ex);
                }
            }
            else
                throw new Exception(Resources.ErrorNoTrans);
        }

        public void EndTransaction()
        {
            if (_sqlTrans != null)
            {
                try
                {
                    _sqlTrans.Commit();

                    try
                    {
                        _sqlTrans.Dispose();
                        _sqlTrans = null;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(Resources.ErrorEndTrans, ex);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(Resources.ErrorTrans, ex);
                }
            }
            else
                throw new Exception(Resources.ErrorNoTrans);
        }
        #endregion

        #region data methods
        public DataTable GetDataAsTable(string storedProcedure)
        {
            SqlCommand sqlCommand = Connection.CreateCommand();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);

            sqlCommand.Connection = Connection;
            sqlCommand.Transaction = _sqlTrans;

            try
            {
                DataTable sqlTable = new DataTable();

                sqlCommand.CommandText = storedProcedure;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlAdapter.Fill(sqlTable);

                return sqlTable;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw new Exception(Resources.ErrorSP, ex);
            }
            finally
            {
                if (_sqlTrans == null)
                    EndConnection();

                sqlCommand.Dispose();
                sqlAdapter.Dispose();
            }
        }

        public DataTable GetDataAsTable(string storedProcedure, List<SqlParameter> parameters)
        {
            SqlCommand sqlCommand = Connection.CreateCommand();
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);

            sqlCommand.Connection = Connection;
            sqlCommand.Transaction = _sqlTrans;

            try
            {
                DataTable sqlTable = new DataTable();

                sqlCommand.CommandText = storedProcedure;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter sqlPrm in parameters)
                {
                    sqlCommand.Parameters.Add(sqlPrm);
                }

                sqlAdapter.Fill(sqlTable);

                return sqlTable;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw new Exception(Resources.ErrorSP, ex);
            }
            finally
            {
                if (_sqlTrans == null)
                    EndConnection();

                sqlCommand.Dispose();
                sqlAdapter.Dispose();
            }
        }

        public object ExecInstruction(ExecutionType execType, string storedProcedure, List<SqlParameter> parameters)
        {
            SqlCommand sqlCommand = Connection.CreateCommand();

            sqlCommand.Connection = Connection;
            sqlCommand.Transaction = _sqlTrans;

            try
            {
                object result = null;

                sqlCommand.CommandText = storedProcedure;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter sqlPrm in parameters)
                {
                    sqlCommand.Parameters.Add(sqlPrm);
                }

                switch (execType)
                {
                    case ExecutionType.NonQuery:
                        result = sqlCommand.ExecuteNonQuery();
                        break;
                    case ExecutionType.Scalar:
                        result = sqlCommand.ExecuteScalar();
                        break;
                }

                return result;
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw new Exception(Resources.ErrorSP, ex);
            }
            finally
            {
                if (_sqlTrans == null)
                    EndConnection();

                sqlCommand.Dispose();
            }
        }

        public void EndConnection()
        {
            try
            {
                if (Connection != null)
                {
                    if (_sqlTrans != null)
                    {
                        EndTransaction();
                    }

                    Connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(Resources.ErrorBD, ex);
            }
        }
        #endregion
        #endregion
    }
}
