using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject
{
    public partial class create_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }// End Page_Load



        protected void Submit_Click1(object sender, EventArgs e)
        {

            string firstname = firstnameID.Text;
            string lastname = lastnameID.Text;
            string email = emailID.Text;
            string password = passwordID.Text;
            




            if (Page.IsValid)
            {
                //int addUser = DBAction.AddUser(prefix, firstname, lastname, email, password, phone, emailNotification);

                string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);


                try
                {

                    int accesslevel = 2;
                    
                    
                    //string localDate = "";
                    string localDate = DateTime.Now.ToString();
                    con.Open();
                    string sql = "INSERT INTO ADMIN(FirstName,LastName,Email,Password,AccessLevel,CreateDate) VALUES(@FirstName, @LastName, @Email, @Password, @AccessLevel, @LocalDate)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    var firstNameParam = new SqlParameter("FirstName", System.Data.SqlDbType.VarChar);
                    var lastNameParam = new SqlParameter("LastName", System.Data.SqlDbType.VarChar);
                    var emailParam = new SqlParameter("Email", System.Data.SqlDbType.VarChar);
                    var passwordParam = new SqlParameter("Password", System.Data.SqlDbType.VarChar);
                    var accessLevelParam = new SqlParameter("AccessLevel", System.Data.SqlDbType.Int); //might be TinyInt instead
                    var localDateParam = new SqlParameter("LocalDate", System.Data.SqlDbType.DateTime);
                    firstNameParam.Value = firstname;
                    lastNameParam.Value = lastname;
                    emailParam.Value = email;
                    passwordParam.Value = password;
                    accessLevelParam.Value = accesslevel;
                    localDateParam.Value = localDate;
                    cmd.Parameters.Add(firstNameParam);
                    cmd.Parameters.Add(lastNameParam);
                    cmd.Parameters.Add(emailParam);
                    cmd.Parameters.Add(passwordParam);
                    cmd.Parameters.Add(accessLevelParam);
                    cmd.Parameters.Add(localDateParam);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("Profile.aspx");

                }
                catch (Exception err)
                {
                    err.ToString();
                    Label1.Text = "Unable to register at this time, Please contact Administrator" + err;

                }
                finally
                {
                    con.Close();

                }


            }//End if valid






        }









    }
}
