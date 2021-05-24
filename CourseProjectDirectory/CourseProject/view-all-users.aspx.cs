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
    public partial class view_all_users : System.Web.UI.Page
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
                    // USERS
                    con.Open();
                    string sql = "SELECT Prefix, FirstName, LastName, Email FROM USERS";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<string[]> rows = new List<string[]>();

                    while (reader.Read())
                    {
                        string[] column = new string[4];
                        column[0] = reader["Prefix"].ToString();
                        column[1] = reader["FirstName"].ToString();
                        column[2] = reader["LastName"].ToString();
                        column[3] = reader["Email"].ToString();
                        rows.Add(column);
                    }

                    foreach (string[] columnVal in rows)
                    {
                        Label label = new Label();
                        label.Text = columnVal[0] + " " + columnVal[1] + " " + columnVal[2] + " Email: " + columnVal[3];
                        users.Controls.Add(label);
                        users.Controls.Add(new Literal() { Text = "<br/>" });
                    }
                    users.Controls.Add(new Literal() { Text = "<br/>" });

                    reader.Close();
                    //con.Close();

                    // MANAGERS
                    //con.Open();
                    string sql1 = "SELECT FirstName, LastName, Email FROM MANAGER";
                    SqlCommand cmd1 = new SqlCommand(sql1, con);
                    SqlDataReader reader1 = cmd1.ExecuteReader();

                    List<string[]> rows1 = new List<string[]>();

                    while (reader1.Read())
                    {
                        string[] column = new string[3];
                        column[0] = reader1["FirstName"].ToString();
                        column[1] = reader1["LastName"].ToString();
                        column[2] = reader1["Email"].ToString();
                        rows1.Add(column);
                    }

                    foreach (string[] columnVal in rows1)
                    {
                        Label label = new Label();
                        label.Text = columnVal[0] + " " + columnVal[1] + " Email: " + columnVal[2];
                        users.Controls.Add(label);
                        users.Controls.Add(new Literal() { Text = "<br/>" });
                    }
                    users.Controls.Add(new Literal() { Text = "<br/>" });

                    reader1.Close();
                    //con.Close();

                    // ADMIN
                    //con.Open();
                    string sql2 = "SELECT FirstName, LastName, Email FROM ADMIN";
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    List<string[]> rows2 = new List<string[]>();

                    while (reader2.Read())
                    {
                        string[] column = new string[3];
                        column[0] = reader2["FirstName"].ToString();
                        column[1] = reader2["LastName"].ToString();
                        column[2] = reader2["Email"].ToString();
                        rows2.Add(column);
                    }

                    foreach (string[] columnVal in rows2)
                    {
                        Label label = new Label();
                        label.Text = columnVal[0] + " " + columnVal[1] + " Email: " + columnVal[2];
                        users.Controls.Add(label);
                        users.Controls.Add(new Literal() { Text = "<br/>" });
                    }
                    users.Controls.Add(new Literal() { Text = "<br/>" });

                    reader2.Close();
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