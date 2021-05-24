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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            


        }




        protected void Submit_Click1(object sender, EventArgs e)
        {

            string prefix = PrefixID.Text;
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


                    int approved = 1;
                    string active = "Yes";
                    string confirmed = "No";
                    DateTime localDate = DateTime.Now;
                    con.Open();
                    string sql = "INSERT INTO Users(Prefix,FirstName,LastName,Email,Password,Phone,RegisterDate,Approved,ApprovalDate,LastLoginDate,Active,Confirmed,NotificationEmail) VALUES(@Prefix, @FirstName, @LastName,@Email,@Password,@Phone,@RegisterDate,@Approved,@ApprovalDate,@LastLoginDate,@Active,@Confirmed,@NotificationEmail)";
                    //old values VALUES('" + prefix + "', '" + firstname + "', '" + lastname + "', '" + email + "', '" + password + "', '" + phone + "', '" + localDate + "', '" + approved + "', '" + localDate + "', '" + localDate + "', '" + active + "', '" + confirmed + "', '" + emailNotification + "')";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    var firstNameParam = new SqlParameter("FirstName", System.Data.SqlDbType.VarChar);
                    var lastNameParam = new SqlParameter("LastName", System.Data.SqlDbType.VarChar);
                    var emailParam = new SqlParameter("Email", System.Data.SqlDbType.VarChar);
                    var passwordParam = new SqlParameter("Password", System.Data.SqlDbType.VarChar);
                    var phoneParam = new SqlParameter("Phone", System.Data.SqlDbType.VarChar);
                    var prefixParam = new SqlParameter("Prefix", System.Data.SqlDbType.VarChar);
                    var approvedParam = new SqlParameter("Approved", System.Data.SqlDbType.VarChar);
                    var approvalDateParam = new SqlParameter("ApprovalDate", System.Data.SqlDbType.DateTime);
                    var registerDateParam = new SqlParameter("RegisterDate", System.Data.SqlDbType.DateTime);
                    var lastLoginDateParam = new SqlParameter("LastLoginDate", System.Data.SqlDbType.DateTime);
                    var activeParam = new SqlParameter("Active", System.Data.SqlDbType.VarChar);
                    var confirmedParam = new SqlParameter("Confirmed", System.Data.SqlDbType.VarChar);
                    var notificationEmailParam = new SqlParameter("NotificationEmail", System.Data.SqlDbType.VarChar);
                    firstNameParam.Value = firstname;
                    lastNameParam.Value = lastname;
                    emailParam.Value = email;
                    passwordParam.Value = password;
                    phoneParam.Value = phone;
                    prefixParam.Value = prefix;
                    approvedParam.Value = approved;
                    //activeParam.Value = active;
                    approvalDateParam.Value = localDate;
                    registerDateParam.Value = localDate;
                    lastLoginDateParam.Value = localDate;
                    activeParam.Value = active;
                    confirmedParam.Value = confirmed;
                    notificationEmailParam.Value = emailNotification;
                    cmd.Parameters.Add(firstNameParam);
                    cmd.Parameters.Add(lastNameParam);
                    cmd.Parameters.Add(emailParam);
                    cmd.Parameters.Add(passwordParam);
                    cmd.Parameters.Add(phoneParam);
                    cmd.Parameters.Add(prefixParam);
                    cmd.Parameters.Add(approvedParam);
                    //cmd.Parameters.Add(activeParam);
                    cmd.Parameters.Add(approvalDateParam);
                    cmd.Parameters.Add(registerDateParam);
                    cmd.Parameters.Add(lastLoginDateParam);
                    cmd.Parameters.Add(activeParam);
                    cmd.Parameters.Add(confirmedParam);
                    cmd.Parameters.Add(notificationEmailParam);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("login.aspx");

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






        }//End Submit_Click1









    }// End register
}