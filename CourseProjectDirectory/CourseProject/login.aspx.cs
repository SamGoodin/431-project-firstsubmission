using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                emailID.Focus();
        }




        protected void LogIn_Click(object sender, EventArgs e)
        {

            string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            //always use try/catch for db connecitons
            try
            {
                //check if the email exists, if so, check if matches the pwd
                string uname = emailID.Text;
                string pwd = passwordID.Text;

                string sql = "select count(*) from ADMIN where Email = @UName and Password = @Pwd";
                SqlCommand cmd = new SqlCommand(sql, con);
                var unameParam = new SqlParameter("UName", System.Data.SqlDbType.VarChar);
                var pwdParam = new SqlParameter("Pwd", System.Data.SqlDbType.VarChar);
                unameParam.Value = uname;
                pwdParam.Value = pwd;
                cmd.Parameters.Add(unameParam);
                cmd.Parameters.Add(pwdParam);
                con.Open();
                int thisCount = (int)cmd.ExecuteScalar();
                if (thisCount != 0) //a match
                {

                    LtrlResponse.Text = "Login successfull! ";

                    cmd = new SqlCommand("select AccessLevel from ADMIN where email = '" + uname + "' and Password = '" + pwd + "'", con);
                    int fn = (int)cmd.ExecuteScalar();


                    //allow login, transfer to the main page.
                    //  cmd = new SqlCommand("select fname from customer where email = '" + uname + "'", con);
                    //  string fn = (string)cmd.ExecuteScalar();
                    Session["email"] = uname;
                    Session["role"] = fn;

                    // Response.Redirect("main.aspx?fn="+fn+"&em=" + TxtEm.Text, true);
                    Response.Redirect("Profile.aspx");

                    con.Close();
                }
                else if (thisCount == 0)
                {
                    cmd = new SqlCommand("select count(*) from Users where email = '" + uname + "' and Password = '" + pwd + "'", con);
                    thisCount = (int)cmd.ExecuteScalar();
                    if (thisCount != 0)
                    {
                        LtrlResponse.Text = "Login successfull! ";
                        Session["email"] = uname;
                        Session["role"] = 0;
                        Response.Redirect("Profile.aspx");
                        con.Close();
                    }
                    else
                    {
                        cmd = new SqlCommand("select count(*) from MANAGER where email = '" + uname + "' and Password = '" + pwd + "'", con);
                        thisCount = (int)cmd.ExecuteScalar();
                        if (thisCount != 0)
                        {
                            string approvalStatus = "";
                            string activeStatus = "";
                            try
                            {
                                cmd = new SqlCommand("select Approved, Active from MANAGER where email = '" + uname + "'", con);

                                ArrayList res = new ArrayList();
                                
                                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);


                                reader.Read();
                                for (int field = 0; field < reader.FieldCount; field++)
                                {
                                    string oneValue = reader.GetValue(field).ToString();

                                    res.Add(oneValue);
                                }


                                reader.Close();

                               

                                //string fn = (string)cmd.ExecuteScalar();
                                approvalStatus = (string)res[0];
                                activeStatus = (string)res[1];
                                con.Close();
                            }
                            catch (Exception err)
                            {
                                Label1.Text = err.Message;

                            }
                            finally
                            {
                                con.Close();
                            }

                            LtrlResponse.Text = "Login successfull! ";
                            Session["email"] = uname;
                            Session["role"] = 1;
                            Session["ApprovalStatus"] = approvalStatus;
                            Session["ActiveStatus"] = activeStatus;
                            Response.Redirect("Profile.aspx");
                            con.Close();
                        }


                    }
                }
                else
                {
                    
                        Label1.Text = "Username or Password doesn't match with our database. Please try again.";
                }


            }
            catch (Exception err)
            {
                Response.Write(err.Message);
                LtrlResponse.Text = err.Message;
                //LtrlResponse.Text = Label1.Text + "Cannot submit information now. Please try again later.";

            }
            finally //must make sure the connection is properly closed
            { //the finally block will always run whether there is an error or not
                con.Close();
                Label1.Text = "Username or Password doesn't match with our database. Please try again.";
            }





        }// End LogIn_Click





    }
}