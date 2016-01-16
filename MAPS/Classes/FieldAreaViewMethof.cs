using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Preview.Common.DataAccess;
using System.IO;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace MAPS.Classes
{
    public class FieldAreaViewMethof
    {
        public static DataSet getfieldAreaValue(int id)
        {
              string sql="GetFieldAreaValue";
              ParameterCollection par = new ParameterCollection();
              par.Add("@Id", id.ToString());
           
            return SQLDatabaseManager.ExecuteDataSet1(sql, par);
            
        }

        public static DataSet getfieldAreaValueCadastral(int id)
        {
            string sql = "GetFieldAreaValueCadastral";
            ParameterCollection par = new ParameterCollection();
            par.Add("@Id", id.ToString());

            return SQLDatabaseManager.ExecuteDataSet1(sql, par);

        }

        public static DataSet getfieldAreaTopValue(int id)
        {
            string sql = "GetFieldAreaTopValue";
            ParameterCollection par = new ParameterCollection();
            par.Add("@Id", id.ToString());

            return SQLDatabaseManager.ExecuteDataSet1(sql, par);

        }
       

       
    }
}