namespace Core
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System.Data;
    using Core.Classe;

    public class Connexion : IDisposable
    {
        #region Fields

        private static string _cnxString = string.Empty;

        private SqlConnection _cnx = null;
        private SqlTransaction _trans = null;

        #endregion Fields

        #region Constructors
        //Pour créer la connexion, on utilise la classe SqlConnection 

        public Connexion()
        {
            try
            {
                Connection = new SqlConnection();
            }
            catch (Exception ex)
            {
            }
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Chaine connexion 
        /// </summary>
        public static string CnxString
        {
            get { return _cnxString; }

            set
            {
                try
                {
                    CheckCnxString(value);
                    _cnxString = value;
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// SqlConnection
        /// </summary>
        public SqlConnection Connection
        {
            get { return _cnx; }
            private set { _cnx = value; }
        }

        /// <summary>
        /// SqlTransaction
        /// </summary>
        public SqlTransaction Transaction
        {
            get { return _trans; }
            private set { _trans = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Starts a new database transaction 
        /// </summary>
        /// <returns>New Sql transaction</returns>
        public SqlTransaction BeginTransaction()
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Open();

                Transaction = Connection.BeginTransaction(IsolationLevel.ReadUncommitted);

                return Transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Close the current connection
        /// </summary>
        public void Close()
        {
            try
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Commit the current database transaction
        /// </summary>
        public void CommitTransaction()
        {
            try
            {
                if (Transaction != null)
                {
                    if (Transaction.Connection != null)
                        Transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Dispose Transaction
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (Connection != null)
                {
                    if (Transaction != null)
                        Transaction.Dispose();

                    Connection.Dispose();
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Open the connection
        /// </summary>
        /// <returns>Sql connection</returns>
        public SqlConnection Open()
        {
            try
            {
                if (Connection.State != ConnectionState.Open)
                {
                    Connection.ConnectionString = _cnxString;
                    Connection.Open();
                }

                return Connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Rolls back the current transaction
        /// </summary>
        public void RollBackTransaction()
        {
            try
            {
                if (Connection == null)
                    return;

                if (Transaction != null)
                {
                    if (Transaction.Connection != null)
                        Transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Chaine connexion
        /// </summary>
        /// <param name="cnxString"> Chaine connexion</param>
        protected static void CheckCnxString(string cnxString)
        {
            try
            {
                if (cnxString == null)
                    throw new NullReferenceException("Connexion invalide!");

                using (SqlConnection cnx = new SqlConnection())
                {
                    cnx.ConnectionString = cnxString;
                    cnx.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        #endregion Methods
    }
}