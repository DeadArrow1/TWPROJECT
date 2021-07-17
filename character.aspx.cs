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
    
    public partial class character : System.Web.UI.Page
    {
       
        int curID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            int start = url.LastIndexOf('=');
            if (start >= 0)
            {
                string param1 = url.Substring(start + 1, url.Length - start - 1);
                int.TryParse(param1, out curID);
            }

            if (this.IsPostBack)
            {

            }
            else
            {
                if (curID > 0)
                {
                    getcharacter(curID);
                }
            }            
        }

        private void getcharacter(int id)
        {
            string name;
            int SpecificAvatarID=0;
            string age;
            string description;
            string occupation="";
            string characteristics = "";
            string despises = "";
            string afinity = "";
            string gear = "";
            using (SqlConnection con = new SqlConnection(DB.GetConn()))
            {
                con.Open();
                using (IDataReader rs = DB.GetRS("SELECT * FROM Characters with (nolock) where ID=" + id.ToString(), con))
                {
                   if (rs.Read())
                    {
                        name = DB.RSField(rs, "FullName");
                        Name.Text = name;
                        age = DB.RSField(rs, "Age");
                        Age.Text = age;
                        description= DB.RSField(rs, "Description");
                        Description.Text = description;
                        occupation = DB.RSField(rs, "Occupation");
                        Occupation.Text = occupation;
                        characteristics = DB.RSField(rs, "Characteristics");
                        Characteristics.Text = occupation;
                        despises = DB.RSField(rs, "Despises");
                        Despises.Text = despises;
                        afinity = DB.RSField(rs, "Afinity");
                        Afinity.Text = afinity;
                        gear = DB.RSField(rs, "Gear");
                        Gear.Text = gear;

                        SpecificAvatarID = DB.RSFieldInt(rs, "AvatarID");
                        avatarimage.Src = "Resources/"+ SpecificAvatarID.ToString() + ".jpg";
                        switch (SpecificAvatarID)
                        {
                            case 0:
                                Image0.Checked = true;
                                break;
                            case 1:
                                Image1.Checked = true;
                                break;
                            case 2:
                                Image2.Checked = true;
                                break;
                            case 3:
                                Image3.Checked = true;
                                break;
                        }
                        
                    }

                }
            }
            
            }

        protected void Delete(object sender, EventArgs e)
        {
            if (curID > 0)
            {
                using (SqlConnection con = new SqlConnection(DB.GetConn()))
                {
                    con.Open();
                    DB.ExecuteSQL("delete from Characters where ID =" + curID.ToString(), con);
                }

                Response.Redirect("default.aspx");
            }
            else 
            {
                string script = "alert('You are trying to delete non existing profile.');";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Test", script, true);
            }

        }

        protected void Return(object sender, EventArgs e)
        {
            

                Response.Redirect("default.aspx");
            

        }

        protected void Change(object sender, EventArgs e)
        {
            if (curID > 0)
            {
                using (SqlConnection con = new SqlConnection(DB.GetConn()))
                {
                    //UPDATE table_name
                    //SET column1 = value1, column2 = value2, ...
                    //WHERE condition;
                    con.Open();
                    DB.ExecuteSQL("UPDATE Characters SET FullName='" + Name.Text + "' where ID =" + curID.ToString(), con);
                    DB.ExecuteSQL("UPDATE Characters SET Age='" + Age.Text + "' where ID =" + curID.ToString(), con);
                    DB.ExecuteSQL("UPDATE Characters SET Description='" + Description.Text + "' where ID =" + curID.ToString(), con);
                    DB.ExecuteSQL("UPDATE Characters SET Occupation='" + Occupation.Text + "' where ID =" + curID.ToString(), con);
                    DB.ExecuteSQL("UPDATE Characters SET Characteristics='" + Characteristics.Text + "' where ID =" + curID.ToString(), con);
                    DB.ExecuteSQL("UPDATE Characters SET Despises='" + Despises.Text + "' where ID =" + curID.ToString(), con);
                    DB.ExecuteSQL("UPDATE Characters SET Afinity='" + Afinity.Text + "' where ID =" + curID.ToString(), con);
                    DB.ExecuteSQL("UPDATE Characters SET Gear='" + Gear.Text + "' where ID =" + curID.ToString(), con);
                    



                    if (Image0.Checked)
                    {
                        DB.ExecuteSQL("UPDATE Characters SET AvatarID=0 where ID =" + curID.ToString(), con);
                    }
                    else if (Image1.Checked)
                    {
                        DB.ExecuteSQL("UPDATE Characters SET AvatarID=1 where ID =" + curID.ToString(), con);
                    }
                    else if (Image2.Checked)
                    {
                        DB.ExecuteSQL("UPDATE Characters SET AvatarID=2 where ID =" + curID.ToString(), con);
                    }
                    else if (Image3.Checked)
                    {
                        DB.ExecuteSQL("UPDATE Characters SET AvatarID=3 where ID =" + curID.ToString(), con);
                    }
                }

               Response.Redirect("default.aspx");
            }

            if (curID == 0)
            {
                using (SqlConnection con = new SqlConnection(DB.GetConn()))
                {
                    
                    con.Open();
                    string executeString = "INSERT INTO Characters (FullName, Age,Description,Occupation,Characteristics,Despises,Afinity,Gear,AvatarID)" +
                                                            "Values('" + Name.Text + "','" + Age.Text + "','" + Description.Text + "','" + Occupation.Text + "','" + Characteristics.Text + "','" + Despises.Text + "','" + Afinity.Text + "','" + Gear.Text + "',";

                                       

                    if (Image0.Checked)
                    {
                        
                        executeString= executeString+"0);";
                    }
                    else if (Image1.Checked)
                    {
                      
                        executeString = executeString + "1);";
                    }
                    else if (Image2.Checked)
                    {
                       
                        executeString = executeString + "2);";
                    }
                    else if (Image3.Checked)
                    {
                        
                        executeString = executeString + "3);";
                    }
                    DB.ExecuteSQL(executeString, con);
                }
         
                Response.Redirect("default.aspx");
            }

        }

        protected void Image3_CheckedChanged(object sender, EventArgs e)
        {
            if (Image3.Checked)
                avatarimage.Src = "Resources/3.jpg";
        }

        protected void Image2_CheckedChanged(object sender, EventArgs e)
        {
            if (Image2.Checked)
                avatarimage.Src = "Resources/2.jpg";

        }

        protected void Image1_CheckedChanged(object sender, EventArgs e)
        {
            if (Image1.Checked)
                avatarimage.Src = "Resources/1.jpg";
        }

        protected void Image0_CheckedChanged(object sender, EventArgs e)
        {
            if(Image0.Checked)
                avatarimage.Src = "Resources/0.jpg";

        }
    }
}