using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace tWWWProject
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            get();
        }

        private void get()
        {
            string name;
            int id = 0;
            string htmlsrc = "<table style=\"width: 900px; font-size: 30px;\" >";
            using (SqlConnection con = new SqlConnection(DB.GetConn()))
            {
                con.Open();
                using (IDataReader rs = DB.GetRS("SELECT * FROM Characters with (nolock) ", con))
                {
                    while (rs.Read())
                    {
                        name = DB.RSField(rs, "FullName");
                        id = DB.RSFieldInt(rs, "ID");
                        htmlsrc += "<tr><td>" + id.ToString() + "</td><td>" + name + "</td><td>  <button><a href =\"character.aspx?ID=" + id.ToString() + "\"> View </a></button>";
                        htmlsrc += "</td></tr>";

                    }
                    htmlsrc += "<tr><td>" + "" + "</td><td>" + "" + "</td><td>  <button><a href =character.aspx?ID=0> Add new </a></button>";
                    htmlsrc += "</td></tr>";
                }
            }
            htmlsrc += "</table>";
            list.Text = htmlsrc;
        }




    }
}

