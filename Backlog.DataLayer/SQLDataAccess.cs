using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace Ezzy.DatabaseLayer
{
    /// <summary>
    /// Purpose:    This class will call the database stored procedures or views [TODO] to access data or to save data.
    /// Created By: Arpit Shrivastava
    /// Created Dt: 20 Dec 2019 04:52
    /// </summary>
    public class SQLDataAccess : IApplicationDBContext
    {
        #region Design Pattern: Singleton (Single Instance)

        private static readonly object lockObject = new object();
        private static SQLDataAccess _Instance;

        public static SQLDataAccess Instance
        {
            get
            {
                //Lock is used to make the call Thread-safe
                lock (lockObject)
                {
                    if (_Instance == null)
                    {
                        _Instance = new SQLDataAccess();
                    }
                }
                return _Instance;
            }
        }
        #endregion

        private string GetConnectionString()
        {
                return ConfigurationManager.ConnectionStrings["BacklogConnectionString"].ConnectionString;
        }

        /// <summary>
        ///  Method will select the data from the database based on parameters.
        ///  It will execute the SELECT query into database.
        /// </summary>
        /// <typeparam name="T">Return object of type generics.</typeparam>
        /// <typeparam name="U">Passing parameters object of type generics.</typeparam>
        /// <param name="storedProcedure">Pass stored procedure name.</param>
        /// <param name="parameters">Pass U type of generics object as parameters, type "new { }" for no parameters and U as dynamics.</param>
        /// <returns>Returns list of T type of generics object</returns>
        public List<T> LoadData<T, U>(string storedProcedure, U parameters)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                List<T> rows = con.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        /// <summary>
        ///  Method will select the data from the database based on parameters with output direction.
        ///  It will execute the SELECT query into database.
        /// </summary>
        /// <typeparam name="T">Return object of type generics.</typeparam>
        /// <typeparam name="U">Passing parameters object of type generics.</typeparam>
        /// <param name="storedProcedure">Pass stored procedure name.</param>
        /// <param name="parameters">Pass U type of generics object as parameters, type "new { }" for no parameters and U as dynamics.</param>
        /// <returns>Returns list of T type of generics object</returns>
        public List<T> LoadDataOutParam<T, U, V>(string storedProcedure, U parameters, out V returnVar, DbType dbType, string returnVarName)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                var dynamicp = new Dapper.DynamicParameters();
                dynamicp.AddDynamicParams(parameters);
                dynamicp.Add(returnVarName, dbType: dbType, direction: ParameterDirection.Output);

                var rows = con.Query<T>(storedProcedure, dynamicp, commandType: CommandType.StoredProcedure);

                returnVar = dynamicp.Get<V>(returnVarName);

                return rows.ToList();
            }
        }

        /// <summary>
        /// Method will create, update or delete the data into database based on parameters.
        /// It will execute INSERT, UPDATE, DELETE query into database.
        /// </summary>
        /// <typeparam name="T">Passing parameters object of type generics.</typeparam>
        /// <param name="storedProcedure">Pass stored procedure name.</param>
        /// <param name="parameters">Pass T type of generics object as parameters, type "new { }" for no parameters and T as dynamics.</param>
        /// <returns>Returns an integer about how many rows updated.</returns>
        public int SaveData<T>(string storedProcedure, T parameters)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                int i = con.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return i;
            }
        }

        public int SaveMultipleData<T>(string storedProcedure, List<T> parameters)
        {
            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    transaction = con.BeginTransaction();
                    foreach (var model in parameters)
                    {
                        int i = con.Execute(storedProcedure, model, commandType: CommandType.StoredProcedure);
                        if (0 == 0) //(i==0)
                        {
                            transaction.Rollback();
                            return 0;
                        }
                    }
                    transaction.Commit();
                    return 1;
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// [DEPRECATED] Loads the Data into Datatable from Stored Procedure
        /// </summary>
        /// <param name="sProcedureName"></param>
        /// <param name="oParams"></param>
        /// <returns></returns>
        //public static DataTable ToLoad_SqlDB_ByProc(string sProcedureName, List<Common.ParameterDL> oParams)
        //{
        //    DataTable dt = new DataTable();
        //    string sConnString = GetConnectionString();
        //    SqlConnection oConn = new SqlConnection(sConnString);
        //    try
        //    {
        //        SqlCommand oComm = new SqlCommand(sProcedureName, oConn);
        //        oComm.CommandType = CommandType.StoredProcedure;
        //        if (oParams != null && oParams.Count() > 0)
        //        {
        //            for (int i = 0; i < oParams.Count(); i++)
        //            {
        //                oComm.Parameters.AddWithValue("@" + oParams[i].Key + "", oParams[i].Value);
        //            }
        //        }
        //        oConn.Open();
        //        SqlDataAdapter oAdapter = new SqlDataAdapter(oComm);

        //        oAdapter.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logging.LogError(Logging.GetCurrentMethod(), ex);
        //        throw;
        //    }
        //    finally
        //    {
        //        oConn.Close();
        //    }
        //    return dt;
        //}
    }
}
