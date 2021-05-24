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
    public partial class Profile : System.Web.UI.Page
    {
        string table;
        string username;
        string cs;
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            /*
            if (Session["ApprovalStatus"] != null)
            {
                if (Session["ApprovalStatus"].ToString() == "No")
                {
                    changePrefix.Visible = false;
                    changeFName.Visible = false;
                    changeLName.Visible = false;
                    changeNotif.Visible = false;
                    changePhone.Visible = false;
                    btnChangePassword.Visible = false;

                }
            }
            */
            PnlManageAdmin.Visible = false;
            PnlManageAdmin2.Visible = false;
            PnlViewPgms.Visible = false;
            PnlViewApprovedPgms.Visible = false;
            PnlViewUnapprovedPgms.Visible = false;
            PnlViewAllPgms.Visible = false;
            PnlViewAllUsers.Visible = false;
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
                    if (Session["ApprovalStatus"].ToString() == "No" || Session["ActiveStatus"].ToString() == "No")
                    {
                        PnlViewPgms.Visible = false;
                        changePrefix.Visible = false;
                        changeFName.Visible = false;
                        changeLName.Visible = false;
                        changeNotif.Visible = false;
                        changePhone.Visible = false;
                        btnChangePassword.Visible = false;
                    }
                    else
                    {
                        PnlViewPgms.Visible = true;
                    }
                }
                else
                {
                    table = "ADMIN";
                    PnlManageAdmin2.Visible = true;
                    PnlViewPgms.Visible = true;
                    PnlViewApprovedPgms.Visible = true;
                    PnlViewUnapprovedPgms.Visible = true;
                    PnlViewAllPgms.Visible = true;
                    PnlViewAllUsers.Visible = true;
                    if (roleNum == 3)
                    {
                        PnlManageAdmin.Visible = true;
                    }
                }
                cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                con = new SqlConnection(cs);

                //always use try/catch for db connecitons
                try
                {
                    username = Session["email"].ToString().Trim();
                    // for testing, using hardcode
                    //username = "sagoodin@iu.edu";    //mgr
                    //username = "asdf@iu.edu";   // admin
                    //username = "cs@gmail.com";  // user
                    string sql = "select * from " + table + " where Email = @Username";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    var tableParam = new SqlParameter("Table", System.Data.SqlDbType.VarChar);
                    var usernameParam = new SqlParameter("Username", System.Data.SqlDbType.VarChar);
                    //tableParam.Value = table;
                    usernameParam.Value = username;
                    //cmd.Parameters.Add(tableParam);
                    cmd.Parameters.Add(usernameParam);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    uname.Text = reader["Email"].ToString();
                    if (roleNum <= 1)
                    {
                        var prefixVal = reader["Prefix"].ToString();
                        prefix.Text = prefixVal;
                        var approveVal = reader["ApprovalDate"].ToString();
                        approveDate.Text = approveVal;
                        regDate.Text = reader["RegisterDate"].ToString();
                    }
                    else
                    {   // Admin dont have these
                        prefixLbl.Visible = false;
                        prefix.Visible = false;
                        changePrefix.Visible = false;
                        approveDateLbl.Visible = false;
                        approveDate.Visible = false;
                        regDate.Text = reader["CreateDate"].ToString();
                    }
                    firstName.Text = reader["FirstName"].ToString();
                    lastName.Text = reader["LastName"].ToString();
                    notifEmail.Text = reader["NotificationEmail"].ToString();
                    phone.Text = reader["Phone"].ToString();
                    con.Close();
                }
                catch (Exception err)
                {
                    errorLbl.Text = err.Message;
                }
                finally //must make sure the connection is properly closed
                { //the finally block will always run whether there is an error or not
                    con.Close();
                }
            }
        }// End Page_Load


        protected void showPrefixChange(object sender, EventArgs e)
        {
            changePrefix.Visible = false;
            newPrefix.Visible = true;
            submitPrefix.Visible = true;
        }

        protected void showFNameChange(object sender, EventArgs e)
        {
            changeFName.Visible = false;
            newFName.Visible = true;
            submitFName.Visible = true;
        }

        protected void showLNameChange(object sender, EventArgs e)
        {
            changeLName.Visible = false;
            newLName.Visible = true;
            submitLName.Visible = true;
        }

        protected void showNotifChange(object sender, EventArgs e)
        {
            changeNotif.Visible = false;
            newNotif.Visible = true;
            submitNotif.Visible = true;
        }

        protected void showPhoneChange(object sender, EventArgs e)
        {
            changePhone.Visible = false;
            newPhone.Visible = true;
            submitPhone.Visible = true;
        }

        protected void submitPrefix_Click(object sender, EventArgs e)
        {
            cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            con = new SqlConnection(cs);

            //always use try/catch for db connecitons
            try
            {
                string prefix = newPrefix.Text.Trim();
                string sql = "update " + table + " set Prefix = '" + prefix + "' where Email = '" + username + "';";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Profile.aspx");
            }
            catch (Exception err)
            {
                errorLbl.Text = err.Message;
            }
            finally //must make sure the connection is properly closed
            { //the finally block will always run whether there is an error or not
                con.Close();
            }
        }

        protected void submitFName_Click(object sender, EventArgs e)
        {
            cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            con = new SqlConnection(cs);

            //always use try/catch for db connecitons
            try
            {
                string fname = newFName.Text.Trim();
                string sql = "update " + table + " set FirstName = '" + fname + "' where Email = '" + username + "';";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Profile.aspx");
            }
            catch (Exception err)
            {
                errorLbl.Text = err.Message;
            }
            finally //must make sure the connection is properly closed
            { //the finally block will always run whether there is an error or not
                con.Close();
            }
        }

        protected void submitLName_Click(object sender, EventArgs e)
        {
            cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            con = new SqlConnection(cs);

            //always use try/catch for db connecitons
            try
            {
                string lname = newLName.Text.Trim();
                string sql = "update " + table + " set LastName = '" + lname + "' where Email = '" + username + "';";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Profile.aspx");
            }
            catch (Exception err)
            {
                errorLbl.Text = err.Message;
            }
            finally //must make sure the connection is properly closed
            { //the finally block will always run whether there is an error or not
                con.Close();
            }
        }

        protected void submitNotif_Click(object sender, EventArgs e)
        {
            cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            con = new SqlConnection(cs);

            //always use try/catch for db connecitons
            try
            {
                string notif = newNotif.Text.Trim();
                string sql = "update " + table + " set NotificationEmail = '" + notif + "' where Email = '" + username + "';";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Profile.aspx");
            }
            catch (Exception err)
            {
                errorLbl.Text = err.Message;
            }
            finally //must make sure the connection is properly closed
            { //the finally block will always run whether there is an error or not
                con.Close();
            }
        }

        protected void submitPhone_Click(object sender, EventArgs e)
        {
            cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            con = new SqlConnection(cs);

            //always use try/catch for db connecitons
            try
            {
                string fone = newPhone.Text.Trim();
                string sql = "update " + table + " set Phone = '" + fone + "' where Email = '" + username + "';";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Profile.aspx");
            }
            catch (Exception err)
            {
                errorLbl.Text = err.Message;
            }
            finally //must make sure the connection is properly closed
            { //the finally block will always run whether there is an error or not
                con.Close();
            }
        }

        protected void changePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("change-password.aspx");
        }
    }
}