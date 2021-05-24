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
    public partial class manageadministrators : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null || Convert.ToInt32(Session["role"]) != 3)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                PopulateGridView();
            }
        }//End Page_Load



        // Populates the data
        void PopulateGridView()
        {

            DataTable dtbl = new DataTable();
            string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * from ADMIN", con);
            sqlData.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvManageAdmin.DataSource = dtbl;
                gvManageAdmin.DataBind();

            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvManageAdmin.DataSource = dtbl;
                gvManageAdmin.DataBind();
                gvManageAdmin.Rows[0].Cells.Clear();
                gvManageAdmin.Rows[0].Cells.Add(new TableCell());
                gvManageAdmin.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvManageAdmin.Rows[0].Cells[0].Text = "No Administrators Found.";
                gvManageAdmin.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con.Close();

        }//End populateGridView


        //Adds new Season
        //Updates Active/Inactive
        protected void GvCurrentAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Inactivate"))
                {
                    // Get SeasonID and current active/inactive
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string rowIndex = commandArgs[0];
                    string action = commandArgs[1];


                    // Find if we need to activate or inactivate season
                    //string action = "";
                    if (action == "No")
                    {
                        action = "Yes";
                    }
                    else
                    {
                        action = "No";
                    }

                    //Set up SQL connection
                    string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string sqlQuery = "UPDATE Season SET Active = @Active WHERE SeasonID = @id";
                    SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.Add("@Active", SqlDbType.VarChar);
                    sqlCmd.Parameters.Add("@id", SqlDbType.Int);
                    sqlCmd.Parameters["@Active"].Value = action;
                    sqlCmd.Parameters["@id"].Value = Convert.ToInt32(rowIndex);
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridView();
                    con.Close();
                    ltrlSqlError.Text = "";
                    //ltrlSqlError2.Text = action;
                    //ltrlSqlError.Text = rowIndex;


                }


            }
            catch (Exception err)
            {
                ltrlSqlError.Text = err.Message;

            }





        }//End GvCurrentAdmin_RowCommand


        //Switches to edit view
        protected void GvCurrentAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvManageAdmin.EditIndex = e.NewEditIndex;
            PopulateGridView();


        }//End GvCurrentAdmin_RowEditing
        //Cancels the edit
        protected void GvCurrentAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvManageAdmin.EditIndex = -1;
            PopulateGridView();


        }//End GvCurrentAdmin_RowCancelingEdit

        //Updates the selection
        protected void GvCurrentAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Update Admin
            try
            {

                string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string sqlQuery = "UPDATE ADMIN SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Password=@Password WHERE ID = @id";

                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                sqlCmd.Parameters.AddWithValue("@FirstName", (gvManageAdmin.Rows[e.RowIndex].FindControl("txtEditAdminFirstName") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@LastName", (gvManageAdmin.Rows[e.RowIndex].FindControl("txtEditAdminLastName") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Email", (gvManageAdmin.Rows[e.RowIndex].FindControl("txtEditAdminEmail") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Password", (gvManageAdmin.Rows[e.RowIndex].FindControl("txtEditAdminPassword") as TextBox).Text.Trim());
                //sqlCmd.Parameters.AddWithValue("@Phone", (gvManageAdmin.Rows[e.RowIndex].FindControl("txtEditAdminPhone") as TextBox).Text.Trim());
                //sqlCmd.Parameters.AddWithValue("@NotificationEmail", (gvManageAdmin.Rows[e.RowIndex].FindControl("txtEditAdminNotificationEmail") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvManageAdmin.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gvManageAdmin.EditIndex = -1;
                PopulateGridView();
                ltrlSqlError.Text = "Administrator Updated!";



                con.Close();

            }
            catch (Exception err)
            {
                ltrlSqlError.Text = err.Message;

            }

        }//End GvCurrentAdmin_RowUpdating







    }
}