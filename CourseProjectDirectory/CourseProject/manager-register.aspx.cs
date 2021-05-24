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
    public partial class manager_register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }// End Page_Load



        protected void Submit_Click1(object sender, EventArgs e)
        {

            string firstname = firstnameID.Text;
            string lastname = lastnameID.Text;
            string email = emailID.Text;
            string password = passwordID.Text;
            string phone = phoneID.Text;
            string emailNotification = emailNotificationID.Text;


            if (Page.IsValid)
            {
                //int addUser = DBAction.AddUser(prefix, firstname, lastname, email, password, phone, emailNotification);

                string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);


                try
                {

                    string prefix = "";
                    string suffix = "";
                    string approvalDate = "";
                    string approved = "No";
                    string active = "Yes";
                    //string localDate = "";
                    string localDate = DateTime.Now.ToString("MM/dd/yyyy");
                    //string localDate = DateTime.Now.ToString();
                    con.Open();
                    string sql = "INSERT INTO MANAGER(FirstName,LastName,Email,Password,Phone,Prefix,Suffix,Approved,ApprovalDate,RegisterDate,LastLoginDate,Active,NotificationEmail) VALUES(@FirstName,@LastName,@Email,@Password,@Phone,@Prefix,@Suffix,@Approved,@ApprovalDate,@RegisterDate,@LastLoginDate,@Active,@NotificationEmail)";
                     

                    SqlCommand cmd = new SqlCommand(sql, con);
                    var firstNameParam = new SqlParameter("FirstName", System.Data.SqlDbType.VarChar);
                    var lastNameParam = new SqlParameter("LastName", System.Data.SqlDbType.VarChar);
                    var emailParam = new SqlParameter("Email", System.Data.SqlDbType.VarChar);
                    var passwordParam = new SqlParameter("Password", System.Data.SqlDbType.VarChar);
                    var phoneParam = new SqlParameter("Phone", System.Data.SqlDbType.VarChar);
                    var prefixParam = new SqlParameter("Prefix", System.Data.SqlDbType.VarChar);
                    var suffixParam = new SqlParameter("Suffix", System.Data.SqlDbType.VarChar);
                    var approvedParam = new SqlParameter("Approved", System.Data.SqlDbType.VarChar);
                    var approvalDateParam = new SqlParameter("ApprovalDate", System.Data.SqlDbType.VarChar);
                    var registerDateParam = new SqlParameter("RegisterDate", System.Data.SqlDbType.VarChar);
                    var lastLoginDateParam = new SqlParameter("LastLoginDate", System.Data.SqlDbType.VarChar);
                    var activeParam = new SqlParameter("Active", System.Data.SqlDbType.VarChar);
                    var notificationEmailParam = new SqlParameter("NotificationEmail", System.Data.SqlDbType.VarChar);
                    firstNameParam.Value = firstname;
                    lastNameParam.Value = lastname;
                    emailParam.Value = email;
                    passwordParam.Value = password;
                    phoneParam.Value = phone;
                    prefixParam.Value = prefix;
                    suffixParam.Value = suffix;
                    approvedParam.Value = approved;
                    activeParam.Value = active;
                    approvalDateParam.Value = approvalDate;
                    registerDateParam.Value = localDate;
                    lastLoginDateParam.Value = localDate;
                    //activeParam.Value = active;
                    notificationEmailParam.Value = emailNotification;
                    cmd.Parameters.Add(firstNameParam);
                    cmd.Parameters.Add(lastNameParam);
                    cmd.Parameters.Add(emailParam);
                    cmd.Parameters.Add(passwordParam);
                    cmd.Parameters.Add(phoneParam);
                    cmd.Parameters.Add(prefixParam);
                    cmd.Parameters.Add(suffixParam);
                    cmd.Parameters.Add(approvedParam);
                    cmd.Parameters.Add(activeParam);
                    cmd.Parameters.Add(approvalDateParam);
                    cmd.Parameters.Add(registerDateParam);
                    cmd.Parameters.Add(lastLoginDateParam);
                    //cmd.Parameters.Add(activeParam);
                    cmd.Parameters.Add(notificationEmailParam);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Label1.Text = "Thank you for registering. Your profile will be reviewed by an Administrator and you will be contacted by Email";

                    //Response.Redirect("login.aspx");

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