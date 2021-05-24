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
    public partial class view_own_programs : System.Web.UI.Page
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
                    string sql = "SELECT ProgramID, Name, Approved FROM PROGRAM WHERE CreatorEmail = @email AND CreatorRole = @role";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    var emailParam = new SqlParameter("email", System.Data.SqlDbType.VarChar);
                    var roleParam = new SqlParameter("role", System.Data.SqlDbType.Int);
                    emailParam.Value = Session["email"].ToString();
                    roleParam.Value = Convert.ToInt32(Session["role"]);
                    cmd.Parameters.Add(emailParam);
                    cmd.Parameters.Add(roleParam);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Dictionary<string, string>> rows = new List<Dictionary<string, string>>();
                    Dictionary<string, string> column;

                    while (reader.Read())
                    {
                        column = new Dictionary<string, string>();
                        column["ProgramID"] = reader["ProgramID"].ToString();
                        column["Name"] = reader["Name"].ToString();
                        column["Approved"] = reader["Approved"].ToString();
                        rows.Add(column);
                    }

                    foreach (Dictionary<string, string> columnVal in rows)
                    {
                        Label label = new Label();
                        label.Text = "Program Name: " + columnVal["Name"];
                        pgms.Controls.Add(label);
                        pgms.Controls.Add(new Literal() { Text = " " });

                        Button button = new Button();
                        button.Text = "View Program Details";
                        button.Click += (sender2, e2) =>
                        {
                            Session["programID"] = columnVal["ProgramID"];
                            Response.Redirect("view-edit-program.aspx");
                        };
                        pgms.Controls.Add(button);
                        pgms.Controls.Add(new Literal() { Text = " " });

                        Label approveLbl = new Label();
                        approveLbl.Text = "Approved: " + columnVal["Approved"];
                        pgms.Controls.Add(approveLbl);
                        pgms.Controls.Add(new Literal() { Text = " " });

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