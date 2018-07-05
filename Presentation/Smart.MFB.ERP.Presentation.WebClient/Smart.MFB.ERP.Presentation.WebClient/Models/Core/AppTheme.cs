using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Smart.MFB.ERP.Presentation.WebClient.Models.Core
{
    public static class AppTheme
    {
        public static string GetTheme()
        {

            string theme = "";
            string conection = ConfigurationManager.ConnectionStrings["SmartMFBERPDB"].ConnectionString;
            var query = "Select Code from cor_theme";

            using (SqlConnection con = new SqlConnection(conection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query,con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (rd.HasRows)
                    {
                        theme = rd["Code"].ToString();
                    }
                }

            }

            return theme;
        }
    }
}