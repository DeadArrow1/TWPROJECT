using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace tWWWProject
{
    public class DB
    {
        public string connString = "";

        public static string GetConn()
        {
            return ConfigurationManager.ConnectionStrings["TWWW"].ConnectionString;           
        }
        static public IDataReader GetRS(string sql, SqlConnection dbconn)
        {
            using (SqlCommand cmd = new SqlCommand(sql, dbconn))
            {
                return cmd.ExecuteReader();
            }
        }

        static public void ExecuteSQL(String Sql, SqlConnection dbconn)
        {
            SqlCommand cmd = new SqlCommand(Sql, dbconn);
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                { 
                    cmd.Dispose();
                    throw (ex);
                } 
        }
        public static String RSField(IDataReader rs, String fieldname)
        {
            int idx = rs.GetOrdinal(fieldname);
            if (rs.IsDBNull(idx))
            { 
                return String.Empty; 
            }
            return rs.GetString(idx);
               
        }

        public static int RSFieldInt(IDataReader rs, String fieldname)
        {
            
            try
            {
                int idx = rs.GetOrdinal(fieldname);
                if (rs.IsDBNull(idx))
                {
                    return 0;
                }
                return rs.GetInt32(idx);              
            }
            catch
            {
                return 0;
            }

        }
    }

}