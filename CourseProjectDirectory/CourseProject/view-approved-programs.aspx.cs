using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// db namespace
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections;

namespace CourseProject
{
    public partial class view_approved_programs : System.Web.UI.Page
    {
        string cs;
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null || Session["role"] == null || Convert.ToInt32(Session["role"]) < 1)
            {
                Response.Redirect("login.aspx");
            }

            if (0 == 0)
            {
                cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                con = new SqlConnection(cs);
                try
                {

                    con.Open();
                    string sql = "SELECT ProgramID, Name, Approved FROM PROGRAM WHERE Approved = @Approved";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    var approvedParam1 = new SqlParameter("Approved", System.Data.SqlDbType.VarChar);
                    approvedParam1.Value = "yes";
                    cmd.Parameters.Add(approvedParam1);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<string[]> rows = new List<string[]>();
                    //string[] column = new string[3];

                    //List<Dictionary<string, string, string>> rows = new List<Dictionary<string, string, string>>();
                    //Dictionary<string, string, string> column;

                    while (reader.Read())
                    {
                        string[] column = new string[3];
                        column[0] = reader["ProgramID"].ToString();
                        column[1] = reader["Name"].ToString();
                        column[2] = reader["Approved"].ToString();
                        //column = new Dictionary<string, string, string>();
                        //column["ProgramID"] = reader["ProgramID"].ToString();
                        //column["Name"] = reader["Name"].ToString();
                        rows.Add(column);
                    }

                    foreach (string[] columnVal in rows)
                    {
                        Label label = new Label();
                        label.Text = columnVal[1];
                        pgms.Controls.Add(label);
                        pgms.Controls.Add(new Literal() { Text = " " });

                        Button button = new Button();
                        button.Text = "View Program Details";
                        button.Click += (sender2, e2) =>
                        {
                            Session["programID"] = columnVal[0];
                            Response.Redirect("view-edit-program.aspx");
                        };
                        pgms.Controls.Add(button);
                        pgms.Controls.Add(new Literal() { Text = " " });

                        Button approval = new Button();
                        string approveSql = "update PROGRAM set Approved = @Approved where ProgramID = @ProgramID";
                        SqlCommand approveCmd = new SqlCommand(approveSql, con);
                        var pgmIDParam = new SqlParameter("ProgramID", System.Data.SqlDbType.Int);
                        pgmIDParam.Value = columnVal[0];
                        approveCmd.Parameters.Add(pgmIDParam);
                        var approvedParam = new SqlParameter("Approved", System.Data.SqlDbType.VarChar);
                        if (columnVal[2] == "yes")
                        {
                            approval.Text = "Disapprove";
                            approval.Click += (sender2, e2) =>
                            {
                                con.Open();
                                approvedParam.Value = "no";
                                approveCmd.Parameters.Add(approvedParam);
                                approveCmd.ExecuteNonQuery();
                                con.Close();
                                //Session["programID"] = columnVal[0];
                                Response.Redirect("view-approved-programs.aspx");
                            };
                        }
                        else
                        {
                            approval.Text = "Approve";
                            approval.Click += (sender2, e2) =>
                            {
                                con.Open();
                                approvedParam.Value = "yes";
                                approveCmd.Parameters.Add(approvedParam);
                                approveCmd.ExecuteNonQuery();
                                con.Close();
                                //Session["programID"] = columnVal[0];
                                Response.Redirect("view-approved-programs.aspx");
                            };
                        }
                        pgms.Controls.Add(approval);
                        pgms.Controls.Add(new Literal() { Text = "<br/>" });
                    }

                    reader.Close();
                    con.Close();
                }
                catch (Exception err)
                {
                    errorLbl.Text = err.ToString();
                }

            }
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}