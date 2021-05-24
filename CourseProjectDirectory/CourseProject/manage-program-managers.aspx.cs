using System;
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
    public partial class manage_program_managers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                PopulateGridView();
                PopulateGridView2();
            }
        }//End Page_Load


        // Populates the Inactivated managers for Activation
        void PopulateGridView()
        {

            DataTable dtbl = new DataTable();
            string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string no = "No";
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * from MANAGER where active = '" + no + "'", con);
            sqlData.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvManagersToBeManagedActivate.DataSource = dtbl;
                gvManagersToBeManagedActivate.DataBind();

            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvManagersToBeManagedActivate.DataSource = dtbl;
                gvManagersToBeManagedActivate.DataBind();
                gvManagersToBeManagedActivate.Rows[0].Cells.Clear();
                gvManagersToBeManagedActivate.Rows[0].Cells.Add(new TableCell());
                gvManagersToBeManagedActivate.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvManagersToBeManagedActivate.Rows[0].Cells[0].Text = "No Managers to Activate.";
                gvManagersToBeManagedActivate.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con.Close();

        }//End populateGridView



        // Populates the Activated managers for Inactivation
        void PopulateGridView2()
        {

            DataTable dtbl = new DataTable();
            string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            SqlConnection con2 = new SqlConnection(cs);
            con2.Open();
            string yes = "Yes";
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * from MANAGER where active = '" + yes + "'", con2);
            sqlData.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvManagersToBeManagedInactivate.DataSource = dtbl;
                gvManagersToBeManagedInactivate.DataBind();

            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvManagersToBeManagedInactivate.DataSource = dtbl;
                gvManagersToBeManagedInactivate.DataBind();
                gvManagersToBeManagedInactivate.Rows[0].Cells.Clear();
                gvManagersToBeManagedInactivate.Rows[0].Cells.Add(new TableCell());
                gvManagersToBeManagedInactivate.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvManagersToBeManagedInactivate.Rows[0].Cells[0].Text = "No Managers to Inactivate.";
                gvManagersToBeManagedInactivate.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con2.Close();

        }//End populateGridView2





        //Updates Activate/Inactivate
        protected void GvManagerActivateInactivate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Activate"))
                {
                    string commandArg = e.CommandArgument.ToString();
                    string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string sqlQuery = "UPDATE MANAGER SET Active = @Active WHERE email = @Email";
                    //string sqlQuery = "UPDATE FIELD SET FieldName=@FieldName WHERE FieldID = @id";
                    string active = "Yes";
                    SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                    //sqlCmd.Parameters.AddWithValue("@FieldName", (gvCurrentFields.FooterRow.FindControl("txtFieldNameFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.Add("@Active", SqlDbType.VarChar);
                    sqlCmd.Parameters.Add("@Email", SqlDbType.VarChar);
                    sqlCmd.Parameters["@Active"].Value = active;
                    sqlCmd.Parameters["@Email"].Value = commandArg;
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridView();
                    PopulateGridView2();
                    errorLbl.Text = "Manager Activated!";
                    Label2.Text = "";
                    con.Close();


                }
                else if (e.CommandName.Equals("Inactivate"))
                {
                    // Get email
                    string commandArg = e.CommandArgument.ToString();

                    string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string sqlQuery = "UPDATE MANAGER SET Active = @Active WHERE email = @Email";
                    //string sqlQuery = "UPDATE FIELD SET FieldName=@FieldName WHERE FieldID = @id";
                    string active = "No";
                    SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                    //sqlCmd.Parameters.AddWithValue("@FieldName", (gvCurrentFields.FooterRow.FindControl("txtFieldNameFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.Add("@Active", SqlDbType.VarChar);
                    sqlCmd.Parameters.Add("@Email", SqlDbType.VarChar);
                    sqlCmd.Parameters["@Active"].Value = active;
                    sqlCmd.Parameters["@Email"].Value = commandArg;
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridView();
                    PopulateGridView2();
                    Label2.Text = "Manager Inactivated!";
                    errorLbl.Text = "";
                    con.Close();

                }

            }
            catch (Exception err)
            {
                Label2.Text = err.Message;

            }





        }//End GvManagerActivateInactivate_RowCommand








    }
}