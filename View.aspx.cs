using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace DatabaseConnectivityinASP
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.\\EAUDIT;Integrated Security=SSPI;Initial Catalog=angularDB";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd;
            string sql = "SELECT * FROM Company";
            SqlDataReader dataReader;
            try
            {
                con.Open();
                cmd = new SqlCommand(sql, con);
                dataReader = cmd.ExecuteReader();
                Response.Write("<table border='1'>");
                while (dataReader.Read())
                {
                    Response.Write("<tr>");
                    Response.Write("<td>" + dataReader.GetValue(0) + "</td><td>" + dataReader.GetValue(1) + "</td><td>" + dataReader.GetValue(2)+"</td>");
                    Response.Write("</tr>");
                }
                Response.Write("</table>");
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}