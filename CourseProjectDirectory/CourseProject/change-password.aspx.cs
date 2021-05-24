using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// db namespace
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class change_password : System.Web.UI.Page
    {
        string cs;
        SqlConnection con;
        string table;
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (1 == 0)
            {

            }
            else
            {
                var roleNum = Convert.ToInt32(Session["role"]);
                //var roleNum = 1;
                if (roleNum == 0)
                {
                    table = "USERS";
                }
                else if (roleNum == 1)
                {
                    table = "MANAGER";
                }
                else
                {
                    table = "ADMIN";
                }
                username = Session["email"].ToString().Trim();
                //username = "sagoodin@iu.edu";   //mgr
                //username = "asdf@iu.edu";   // admin
                //username = "cs@gmail.com";  // user
                cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                con = new SqlConnection(cs);
            }
        }

#pragma warning disable IDE1006 // Naming Styles
        protected void match_Validate(object sender, ServerValidateEventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            var confirmVal = e.Value;
            var newPassVal = newPassword.Text;
            bool isValid = confirmVal.Equals(newPassVal);
            e.IsValid = isValid;
        }

#pragma warning disable IDE1006 // Naming Styles
        protected void changePassword_Click(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {
            if (Page.IsValid)
            {
                string currentpassword = currentPasswordID.Text;
                string userName = (string)Session["email"];
                try
                {
                    string sql1 = "select count(*) from " + table + " where password = '" + currentpassword + "' AND email = '" + userName + "';";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    con.Open();
                    int thisCount = (int)cmd1.ExecuteScalar();

                    if (thisCount != 0)//A match
                    {
                        string pword = confirmPassword.Text;
                        string sql = "update " + table + " set Password = '" + pword + "' where Email = '" + username + "';";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        errorLbl.Text = "Current Password Not Correct";
                    }
                }
                catch (Exception error)
                {
                    errorLbl.Text = error.Message;
                }
                finally
                {
                    con.Close();
                }


                
            }
            
        }
    }
}