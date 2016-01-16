using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Preview.Common.DataAccess
{
    public class SQLDatabaseManager
    {
        /* Default Connection String key on appSettings */
        private static string _defaultCS = "DatabaseManagerCS";

        /* START RETURNING SQLDATAREADER */
        /* NOTE READER MUST CLOSE CONNECTION MANUALLY */
        /*-------------------------------*/

        /* WITH DEFAULT CONNECTION STRING SPECIFIED IN APPSETTTINGS */
        /// <summary>
        /// This function takes in the query that needs to be executed and returns a data reader as output
        /// </summary>
        /// <param name="CommString">The query which needs to be executed</param>
        /// <returns>SQL Data reader that is the output of the select query executed</returns>
        public static SqlDataReader ExecuteDataReader(string CommString)
        {
            return ExecuteDataReader(CommandType.Text, CommString, null);
        }

        /// <summary>
        /// This function executes either the passed query or the passed stored procedure and returns the output in data reader
        /// </summary>
        /// <param name="CommType">whether it is a stored procedure or a simple query</param>
        /// <param name="CommString">if stored procedure, the name of the stored procedure, if query, then the whole query in string format</param>
        /// <param name="Parameters">if stored procedure, then the list of all parameters of that stored procedure, if any</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteDataReader(CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            return ExecuteDataReader(new SqlConnection(GetConnectionString(_defaultCS)), CommType, CommString, Parameters);
        }


        /* WITH CUSTOM SQL CONNECTION */
        /// <summary>
        /// This function takes in the query that needs to be executed and returns a data reader as output
        /// </summary>
        /// <param name="Conn">If the connection is not the same as in App settings, then the connection string is passed in this parameter</param>
        /// <param name="CommString">The query which needs to be executed</param>
        /// <returns>SQL Data reader that is the output of the select query executed</returns>
        public static SqlDataReader ExecuteDataReader(SqlConnection Conn, string CommString)
        {
            return ExecuteDataReader(Conn, CommandType.Text, CommString, null);
        }


        /// <summary>
        /// This function takes in the query that needs to be executed and returns a data reader as output
        /// </summary>
        /// <param name="Conn">The SQL Connection to be used</param>
        /// <param name="CommType">The Command type whether it is stored procedure or a simple query</param>
        /// <param name="CommString">If Stored procedure, then the name of the stored procedure, if simple query, then the query in
        /// string format</param>
        /// <param name="Parameters">List of parameters, if any required for Stored procedure</param>
        /// <returns>SQL Data reader that is the output of the select query executed</returns>
        public static SqlDataReader ExecuteDataReader(SqlConnection Conn, CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            SqlDataReader return_sdr = null;
            try
            {
                SqlCommand comm = new SqlCommand(CommString, Conn);
                comm.CommandType = CommType;
                if (Parameters != null && Parameters.Count > 0)
                {
                    foreach (Parameter param in Parameters)
                    {
                        if (param.DefaultValue == "")
                            comm.Parameters.AddWithValue(param.Name, DBNull.Value);
                        else
                            comm.Parameters.AddWithValue(param.Name, param.DefaultValue);
                    }
                }
                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }
                return_sdr = comm.ExecuteReader();

            }
            catch (SqlException sqx)
            {
                throw new Exception("SQLException : " + sqx.ErrorCode + Environment.NewLine + "Line Number : " + sqx.LineNumber + " Message : " + sqx.Message + Environment.NewLine + "Stack Trace :" + Environment.NewLine + sqx.StackTrace);
            }
            catch (Exception exp)
            {
                throw new Exception("Exception : " + exp.InnerException + Environment.NewLine + " Message : " + exp.Message + Environment.NewLine + "Stack Trace :" + Environment.NewLine + exp.StackTrace);
            }
            return return_sdr;
        }
        /*-----------------------------*/
        /* END RETURNING SQLDATAREADER */

        /* START RETURNING DATA SET */
        /*----------------------------*/

        /* WITH DEFAULT CONNECTION STRING SPECIFIED IN WEB.CONFIG */
        /// <summary>
        /// This function is used to return a dataset. Use this function when the stored procedure needs to return more than 1 table
        /// </summary>
        /// <param name="CommString">The name of the stored procdeure to be executed</param>
        /// <returns>Returns the dataset with all the tables returning from the database</returns>
        public static DataSet ExecuteDataSet(string CommString)
        {
            return ExecuteDataSet(CommandType.StoredProcedure, CommString, null);
        }

        /// <summary>
        /// This function is used to return a dataset. Use this function when the stored procedure needs to return more than 1 table and there are 
        /// input parameters to the stored procedure
        /// </summary>
        /// <param name="CommString">The name of the stored procdeure to be executed</param>
        /// <param name="Parameters">The list of paramters required for the stored procedure</param>
        /// <returns>Returns the dataset with all the tables returning from the database</returns>
        public static DataSet ExecuteDataSet1(string CommString, ParameterCollection Parameters)
        {
            return ExecuteDataSet(CommandType.StoredProcedure, CommString, Parameters);
        }

        /// <summary>
        /// This function is used to return a dataset.
        /// </summary>
        /// <param name="CommType">Takes in the type of Command type</param>
        /// <param name="CommString">Stored Procedure name if the command type is stored procedure, else the query</param>
        /// <param name="Parameters">the parameters that are needed for the stored procedure</param>
        /// <returns>Returns the dataset with all the tables returning from the database</returns>
        public static DataSet ExecuteDataSet(CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            return ExecuteDataSet(GetConnectionString(_defaultCS), CommType, CommString, Parameters);
        }

        /* WITH CUSTOM CONNECTION STRING */
        /// <summary>
        /// This function is used to return a dataset. Use this function when the stored procedure needs to return more than 1 table
        /// </summary>
        /// <param name="ConnString">The custom sql connection string</param>
        /// <param name="CommString">The name of the stored procdeure to be executed</param>
        /// <returns>Returns the dataset with all the tables returning from the database</returns>
        public static DataSet ExecuteDataSet(string ConnString, string CommString)
        {
            return ExecuteDataSet(ConnString, CommandType.StoredProcedure, CommString, null);
        }

        /// <summary>
        /// This function is used to return a dataset. Use this function when the stored procedure needs to return more than 1 table and there  are parameters
        /// to be provided to the stored procedure
        /// </summary>
        /// </summary>
        /// <param name="ConnString">The custom sql connection string</param>
        /// <param name="CommString">The name of the stored procdeure to be executed</param>
        /// <param name="Parameters">the parameters that are needed for the stored procedure</param>
        /// <returns>Returns the dataset with all the tables returning from the database</returns>
        public static DataSet ExecuteDataSet(string ConnString, string CommString, ParameterCollection Parameters)
        {
            return ExecuteDataSet(new SqlConnection(ConnString), CommandType.StoredProcedure, CommString, Parameters);
        }

        /// <summary>
        /// This function is used to return a dataset. Use this function when the stored procedure needs to return more than 1 table and there  are parameters
        /// to be provided to the stored procedure
        /// </summary>
        /// <param name="ConnString">The custom sql connection string</param>
        /// <param name="CommType">The name of the stored procdeure to be executed</param>
        /// <param name="CommString">the parameters that are needed for the stored procedure</param>
        /// <param name="Parameters">the parameters that are needed for the stored procedure</param>
        /// <returns>Returns the dataset with all the tables returning from the database</returns>
        public static DataSet ExecuteDataSet(string ConnString, CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            return ExecuteDataSet(new SqlConnection(ConnString), CommType, CommString, Parameters);
        }

        /* WITH CUSTOM SQL CONNECTION */
        /// <summary>
        /// This function is used to return a dataset. Use this function when the stored procedure needs to return more than 1 table
        /// </summary>
        /// <param name="Conn">Custom sql connection that uses some different connection string</param>
        /// <param name="CommString">The name of the stored procdeure to be executed</param>
        /// <returns>Returns the dataset with all the tables returning from the database</returns>
        public static DataSet ExecuteDataSet(SqlConnection Conn, string CommString)
        {
            return ExecuteDataSet(Conn, CommandType.StoredProcedure, CommString, null);
        }

        /// <summary>
        /// This function is used to return a dataset. Use this function when the stored procedure needs to return more than 1 table and there  are parameters
        /// to be provided to the stored procedure
        /// </summary>
        /// <param name="Conn">Custom sql cnnection</param>
        /// <param name="CommString">The name of the stored procdeure to be executed</param>
        /// <param name="Parameters">the parameters that are needed for the stored procedure</param>
        /// <returns>Returns the dataset with all the tables returning from the database</returns>
        public static DataSet ExecuteDataSet(SqlConnection Conn, string CommString, ParameterCollection Parameters)
        {
            return ExecuteDataSet(Conn, CommandType.StoredProcedure, CommString, Parameters);
        }

        /// <summary>
        /// This function is used to return a dataset. Use this function when the stored procedure needs to return more than 1 table and there  are parameters
        /// to be provided to the stored procedure
        /// </summary>
        /// <param name="Conn">The connection to be used</param>
        /// <param name="CommType">The command type whether it is stored procedure or query</param>
        /// <param name="CommString">if stored procedure, then procedure name and if single query then the query string</param>
        /// <param name="Parameters">the list of parameters if any that are input to the stored procedure</param>
        /// <returns>Returns the dataset with all the tables returning from the database</returns>
        public static DataSet ExecuteDataSet(SqlConnection Conn, CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            DataSet return_ds = null;
            try
            {
                using (Conn)
                {
                    SqlCommand comm = new SqlCommand(CommString, Conn);
                    comm.CommandType = CommType;
                    if (Parameters != null && Parameters.Count > 0)
                    {
                        foreach (Parameter param in Parameters)
                        {
                            if (param.DefaultValue == "")
                                comm.Parameters.AddWithValue(param.Name, DBNull.Value);
                            else
                                comm.Parameters.AddWithValue(param.Name, param.DefaultValue);
                        }
                    }
                    return_ds = new DataSet();
                    Conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(comm);
                    sda.Fill(return_ds);
                    Conn.Close();
                }
            }
            catch (SqlException sqx)
            {
                throw new Exception("SQLException : " + sqx.ErrorCode + Environment.NewLine + "Line Number : " + sqx.LineNumber + " Message : " + sqx.Message + Environment.NewLine + "Stack Trace :" + Environment.NewLine + sqx.StackTrace);
            }
            catch (Exception exp)
            {
                throw new Exception("Exception : " + exp.InnerException + Environment.NewLine + " Message : " + exp.Message + " Message : " + exp.Message + Environment.NewLine + "Stack Trace :" + Environment.NewLine + exp.StackTrace);
            }
            return return_ds;
        }

        /*-----------------------------*/
        /* END RETURNING DATA SET */

        /* START RETURNING DATA TABLE */
        /*----------------------------*/

        /* WITH DEFAULT CONNECTION STRING SPECIFIED IN WEB.CONFIG */
        /// <summary>
        /// This function returns a single data table
        /// </summary>
        /// <param name="CommString">The query string that needs to be execute</param>
        /// <returns>The output of the query string</returns>
        public static DataTable ExecuteDataTable(string CommString)
        {
            return ExecuteDataTable(CommandType.Text, CommString, null);
        }

        /// <summary>
        /// This function returns a single data table
        /// </summary>
        /// <param name="CommType">whether it is a stored procedure or a simple query</param>
        /// <param name="CommString">if stored procedure, then the name of stored procedure, if single query then the query string</param>
        /// <param name="Parameters">the list of parameters if any in case of stored procedure</param>
        /// <returns>Output of the stored procedure</returns>
        public static DataTable ExecuteDataTable(CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            return ExecuteDataTable(GetConnectionString(_defaultCS), CommType, CommString, Parameters);
        }


        /* WITH CUSTOM CONNECTION STRING */
        /// <summary>
        /// This function returns a single data table, use this function when the connection string is different from the one that is mentioned in the appsettings
        /// </summary>
        /// <param name="ConnString">The custom connection string if not the one mentioned in the appsettings</param>
        /// <param name="CommString">The query string that needs to be execute</param>
        /// <returns>The output of the query string</returns>
        public static DataTable ExecuteDataTable(string ConnString, string CommString)
        {
            return ExecuteDataTable(ConnString, CommandType.Text, CommString, null);
        }

        /// <summary>
        /// This function returns a single data table, use this function when the connection string is different from the one that is mentioned in the appsettings
        /// </summary>
        /// <param name="ConnString">The custom connection string if not the one mentioned in the appsettings</param>
        /// <param name="CommString">The name of the stored procedure to be executed</param>
        /// <param name="Parameters">Parameters if any for the stored procedure</param>
        /// <returns>Output of the stored procedure</returns>
        public static DataTable ExecuteDataTable(string ConnString, string CommString, ParameterCollection Parameters)
        {
            return ExecuteDataTable(new SqlConnection(ConnString), CommandType.Text, CommString, Parameters);
        }

        /// <summary>
        /// This function returns a single data table
        /// </summary>
        /// <param name="ConnString">The connection string required to access the database</param>
        /// <param name="CommType">whether it is a stored procedure or a simple query</param>
        /// <param name="CommString">if stored procedure, then the name of stored procedure, if single query then the query string</param>
        /// <param name="Parameters">Parameters if any for the stored procedure</param>
        /// <returns>The output table generated on execution</returns>
        public static DataTable ExecuteDataTable(string ConnString, CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            return ExecuteDataTable(new SqlConnection(ConnString), CommType, CommString, Parameters);
        }


        /* WITH CUSTOM SQL CONNECTION */
        /// <summary>
        /// This function returns a single data table
        /// </summary>
        /// <param name="Conn">The custom sql connection provided</param>
        /// <param name="CommString">The query that needs to be executed</param>
        /// <returns>Output on executing the query</returns>
        public static DataTable ExecuteDataTable(SqlConnection Conn, string CommString)
        {
            return ExecuteDataTable(Conn, CommandType.Text, CommString, null);
        }

        /// <summary>
        /// This function returns a single data table
        /// </summary>
        /// <param name="Conn">The sql connection used to access the data base</param>
        /// <param name="CommType">whether it is a stored procedure or a simple query</param>
        /// <param name="CommString">if stored procedure, then the name of stored procedure, if single query then the query string</param>
        /// <param name="Parameters">Parameters if any for the stored procedure</param>
        /// <returns>The output table for the query or the stored procedure</returns>
        public static DataTable ExecuteDataTable(SqlConnection Conn, CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            DataTable return_dt = null;
            try
            {
                using (Conn)
                {
                    SqlCommand comm = new SqlCommand(CommString, Conn);
                    comm.CommandType = CommType;
                    if (Parameters != null && Parameters.Count > 0)
                    {
                        foreach (Parameter param in Parameters)
                        {
                            if (param.DefaultValue == "")
                                comm.Parameters.AddWithValue(param.Name, DBNull.Value);
                            else
                                comm.Parameters.AddWithValue(param.Name, param.DefaultValue);
                        }
                    }
                    return_dt = new DataTable();
                    Conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(comm);
                    sda.Fill(return_dt);
                    Conn.Close();
                }
            }
            catch (SqlException sqx)
            {
                throw new Exception("SQLException : " + sqx.ErrorCode + Environment.NewLine + "Line Number : " + sqx.LineNumber + " Message : " + sqx.Message + Environment.NewLine + "Stack Trace :" + Environment.NewLine + sqx.StackTrace);
            }
            catch (Exception exp)
            {
                throw new Exception("Exception : " + exp.InnerException + Environment.NewLine + " Message : " + exp.Message + " Message : " + exp.Message + Environment.NewLine + "Stack Trace :" + Environment.NewLine + exp.StackTrace);
            }
            return return_dt;
        }



        /*--------------------------*/
        /* END RETURNING DATA TABLE */

        /* START RETURNING # OF ROW(S) AFFECTED */
        /*--------------------------------------*/

        /* WITH DEFAULT CONNECTION STRING SPECIFIED IN WEB.CONFIG */

        /// <summary>
        /// This function is used to execute queries that don't return any table (Insert, Delete or Update queries)
        /// </summary>
        /// <param name="CommString">The query which needs to be executed</param>
        /// <returns>The number of rows getting affected on execution</returns>
        public static int ExecuteNonQuery(string CommString)
        {
            return ExecuteNonQuery(CommandType.Text, CommString, null);
        }


        /// <summary>
        /// This function is used to execute queries that don't return any table (Insert, Delete or Update queries)
        /// </summary>
        /// <param name="CommType">this parameter will have the value as CommandType.Text as ExecuteNonQuery are not used for stored procedures</param>
        /// <param name="CommString">The query which needs to be executed</param>
        /// <param name="Parameters">Parameters if any, won't be there as stored procedures are not been used</param>
        /// <returns>The number of rows getting affected on execution</returns>
        public static int ExecuteNonQuery(CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            return ExecuteNonQuery(GetConnectionString(_defaultCS), CommType, CommString, Parameters);
        }
        /* WITH CUSTOM CONNECTION STRING */
        /// <summary>
        /// This function is used to execute queries that don't return any table (Insert, Delete or Update queries)
        /// </summary>
        /// <param name="ConnString">the custom connection string if not the same as available in app settings</param>
        /// <param name="CommString">The query which needs to be executed</param>
        /// <returns>The number of rows getting affected on execution</returns>
        public static int ExecuteNonQuery(string ConnString, string CommString)
        {
            return ExecuteNonQuery(new SqlConnection(ConnString), CommandType.Text, CommString, null);
        }



        /// <summary>
        /// This function is used to execute queries that don't return any table (Insert, Delete or Update queries)
        /// </summary>
        /// <param name="ConnString">The connection string used to access the database</param>
        /// <param name="CommType">whether it is a stored procedure or a simpple query, for this function it will never be a stored proc</param>
        /// <param name="CommString">the query which needs to be executed</param>
        /// <param name="Parameters">parameters if any, if stored procedure</param>
        /// <returns>The number of rows getting affected on execution</returns>
        public static int ExecuteNonQuery(string ConnString, CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            return ExecuteNonQuery(new SqlConnection(ConnString), CommType, CommString, Parameters);
        }

        /* WITH CUSTOM SQl CONNECTION */
        /// <summary>
        /// This function is used to execute queries that don't return any table (Insert, Delete or Update queries)
        /// </summary>
        /// <param name="Conn">custom sql connection to be used to access the database</param>
        /// <param name="CommString">the query which needs to be executed</param>
        /// <returns>The number of rows getting affected on execution</returns>
        public static int ExecuteNonQuery(SqlConnection Conn, string CommString)
        {
            return ExecuteNonQuery(Conn, CommandType.Text, CommString, null);
        }

        /// <summary>
        /// This function is used to execute queries that don't return any table (Insert, Delete or Update queries)
        /// </summary>
        /// <param name="Conn">the sql connection to be used to access the database</param>
        /// <param name="CommString">the query which needs to be executed</param>
        /// <param name="Parameters">Parameters if any</param>
        /// <returns>The number of rows getting affected on execution</returns>
        public static int ExecuteNonQuery(SqlConnection Conn, string CommString, ParameterCollection Parameters)
        {
            return ExecuteNonQuery(Conn, CommandType.Text, CommString, Parameters);
        }

        /// <summary>
        /// This function is used to execute queries that don't return any table (Insert, Delete or Update queries)
        /// </summary>
        /// <param name="Conn">the sql connection to be used to access the database</param>
        /// <param name="CommType">whether a stored procedure or a query, in this case never a stored procedure</param>
        /// <param name="CommString">the query which needs to be executed</param>
        /// <param name="Parameters">Parameters if any</param>
        /// <returns>The number of rows getting affected on execution</returns>
        public static int ExecuteNonQuery(SqlConnection Conn, CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            int return_int = 0;
            try
            {
                using (Conn)
                {
                    SqlCommand comm = new SqlCommand(CommString, Conn);
                    comm.CommandType = CommType;
                    if (Parameters != null && Parameters.Count > 0)
                    {
                        foreach (Parameter param in Parameters)
                        {
                            if (param.DefaultValue == "")
                                comm.Parameters.AddWithValue(param.Name, DBNull.Value);
                            else
                                comm.Parameters.AddWithValue(param.Name, param.DefaultValue);
                        }
                    }
                    Conn.Open();
                    return_int = comm.ExecuteNonQuery();
                    Conn.Close();
                }
            }
            catch (SqlException sqx)
            {
                throw new Exception("SQLException : " + sqx.ErrorCode + Environment.NewLine + "Line Number : " + sqx.LineNumber + " Message : " + sqx.Message + Environment.NewLine + "Stack Trace :" + Environment.NewLine + sqx.StackTrace);
            }
            catch (Exception exp)
            {
                throw new Exception("Exception : " + exp.InnerException + Environment.NewLine + " Message : " + exp.Message + " Message : " + exp.Message + Environment.NewLine + "Stack Trace :" + Environment.NewLine + exp.StackTrace);
            }
            return return_int;
        }
        /*------------------------------------*/
        /* END RETURNING # OF ROW(S) AFFECTED */

        /* START RETURNING SCALAR VALUE */
        /*------------------------------*/

        /* WITH DEFAULT CONNECTION STRING SPECIFIED IN WEB.CONFIG */
        /// <summary>
        /// This function reutrns the scalar value obtained on executing the given query
        /// </summary>
        /// <param name="CommString">the query which needs to be executed</param>
        /// <returns>Retrurns a single scalar value</returns>
        public static object ExecuteScalar(string CommString)
        {
            return ExecuteScalar(CommandType.Text, CommString, null);
        }

        /// <summary>
        /// This function reutrns the scalar value obtained on executing the given query
        /// </summary>
        /// <param name="CommType">whether it is a stored procedure or a single query</param>
        /// <param name="CommString">the query which needs to be executed or the name of the stored procedure</param>
        /// <param name="Parameters">parameters if any in case of stored procedure</param>
        /// <returns>Retrurns a single scalar value</returns>
        public static object ExecuteScalar(CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            return ExecuteScalar(GetConnectionString(_defaultCS), CommType, CommString, Parameters);
        }

        /* WITH CUSTOM CONNECTION STRING */
        /// <summary>
        /// This function reutrns the scalar value obtained on executing the given query
        /// </summary>
        /// <param name="ConnString">custom connection string to be used to access the database</param>
        /// <param name="CommString">the query which needs to be executed</param>
        /// <returns>Retrurns a single scalar value</returns>
        public static object ExecuteScalar(string ConnString, string CommString)
        {
            return ExecuteScalar(new SqlConnection(ConnString), CommandType.Text, CommString, null);
        }

        /// <summary>
        /// This function reutrns the scalar value obtained on executing the given query
        /// </summary>
        /// <param name="ConnString">the connection string required to access the database</param>
        /// <param name="CommType">whether it is a stored procedure or a single query</param>
        /// <param name="CommString">the query which needs to be executed or the name of the stored procedure</param>
        /// <param name="Parameters">parameters if any in case of stored procedure</param>
        /// <returns>Retrurns a single scalar value</returns>
        public static object ExecuteScalar(string ConnString, CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            return ExecuteScalar(new SqlConnection(ConnString), CommType, CommString, Parameters);
        }

        /* WITH CUSTOM SQL CONNECTION */
        /// <summary>
        /// This function reutrns the scalar value obtained on executing the given query
        /// </summary>
        /// <param name="Conn">the sql connection required to access the database</param>
        /// <param name="CommString">the query which needs to be executed</param>
        /// <returns>Retrurns a single scalar value</returns>
        public static object ExecuteScalar(SqlConnection Conn, string CommString)
        {
            return ExecuteScalar(Conn, CommandType.Text, CommString, null);
        }

        /// <summary>
        /// This function reutrns the scalar value obtained on executing the given query
        /// </summary>
        /// <param name="Conn">the connection string required to access the database</param>
        /// <param name="CommType">whether it is a stored procedure or a single query</param>
        /// <param name="CommString">the query which needs to be executed or the name of the stored procedure</param>
        /// <param name="Parameters">parameters if any in case of stored procedure</param>
        /// <returns>Retrurns a single scalar value</returns>
        public static object ExecuteScalar(SqlConnection Conn, CommandType CommType, string CommString, ParameterCollection Parameters)
        {
            object return_obj = null;
            try
            {
                using (Conn)
                {
                    SqlCommand comm = new SqlCommand(CommString, Conn);
                    comm.CommandType = CommType;
                    if (Parameters != null && Parameters.Count > 0)
                    {
                        foreach (Parameter param in Parameters)
                        {
                            if (param.DefaultValue == "")
                                comm.Parameters.AddWithValue(param.Name, DBNull.Value);
                            else
                                comm.Parameters.AddWithValue(param.Name, param.DefaultValue);
                        }
                    }
                    Conn.Open();
                    return_obj = comm.ExecuteScalar();
                    Conn.Close();
                }
            }
            catch (SqlException sqx)
            {
                throw new Exception("SQLException : " + sqx.ErrorCode + Environment.NewLine + "Line Number : " + sqx.LineNumber + " Message : " + sqx.Message + Environment.NewLine + "Stack Trace :" + Environment.NewLine + sqx.StackTrace);
            }
            catch (Exception exp)
            {
                throw new Exception("Exception : " + exp.InnerException + Environment.NewLine + " Message : " + exp.Message + " Message : " + exp.Message + Environment.NewLine + "Stack Trace :" + Environment.NewLine + exp.StackTrace);
            }
            return return_obj;
        }
        /*----------------------------*/
        /* END RETURNING SCALAR VALUE */

        /* HELPER FUNCTIONS */
        /*------------------*/
        /// <summary>
        /// Returns the connection string as per the app key value
        /// </summary>
        /// <param name="appkey">the key whose value needs to be used in the connection string</param>
        /// <returns>the connection string depending upon the app key value</returns>
        public static string GetConnectionString(string appkey)
        {
            string _valcs;
            if (ConfigurationManager.ConnectionStrings[_defaultCS] != null)
            {
                _valcs = ConfigurationManager.ConnectionStrings[_defaultCS].ConnectionString;
                return _valcs;
            }
            else
            {
                throw new Exception("Default connection string \"" + _defaultCS + "\" does not exist in <connectionStrings>. Please check your web.config file.");
            }
        }
       
    }

}
