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
    public partial class new_duration : System.Web.UI.Page
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
            }
        }//End Page_Load



        // Populates the data
        void PopulateGridView()
        {

            DataTable dtbl = new DataTable();
            string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * from DURATION", con);
            sqlData.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvCurrentDuration.DataSource = dtbl;
                gvCurrentDuration.DataBind();

            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvCurrentDuration.DataSource = dtbl;
                gvCurrentDuration.DataBind();
                gvCurrentDuration.Rows[0].Cells.Clear();
                gvCurrentDuration.Rows[0].Cells.Add(new TableCell());
                gvCurrentDuration.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvCurrentDuration.Rows[0].Cells[0].Text = "No Durations Found.";
                gvCurrentDuration.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con.Close();

        }//End populateGridView


        //Adds new Duration
        //Updates Active/Inactive
        protected void GvCurrentDuration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string sqlQuery = "INSERT INTO DURATION (Length, Active) VALUES (@Length, @Active)";
                    string active = "Yes";
                    SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("@Length", (gvCurrentDuration.FooterRow.FindControl("txtDurationFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.Add("@Active", SqlDbType.VarChar);
                    sqlCmd.Parameters["@Active"].Value = active;
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridView();
                    ltrlSqlError.Text = "New Duration Added!";
                    con.Close();


                }
                else if (e.CommandName.Equals("Inactivate"))
                {
                    // Get DurationID and current active/inactive
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string rowIndex = commandArgs[0];
                    string action = commandArgs[1];


                    // Find if we need to activate or inactivate Stipend
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
                    string sqlQuery = "UPDATE DURATION SET Active = @Active WHERE DurationID = @id";
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





        }//End GvCurrentDuration_RowCommand


        //Switches to edit view
        protected void GvCurrentDuration_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCurrentDuration.EditIndex = e.NewEditIndex;
            PopulateGridView();


        }//End GvCurrentDuration_RowEditing

        //Cancels the edit
        protected void GvCurrentDuration_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCurrentDuration.EditIndex = -1;
            PopulateGridView();


        }//End GvCurrentDuration_RowCancelingEdit

        //Updates the selection
        protected void GvCurrentDuration_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Update Duration
            try
            {

                string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string sqlQuery = "UPDATE DURATION SET Length=@Length WHERE DurationID = @id";

                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                sqlCmd.Parameters.AddWithValue("@Length", (gvCurrentDuration.Rows[e.RowIndex].FindControl("txtEditDuration") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvCurrentDuration.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gvCurrentDuration.EditIndex = -1;
                PopulateGridView();
                ltrlSqlError.Text = "Duration Updated!";



                con.Close();

            }
            catch (Exception err)
            {
                ltrlSqlError.Text = err.Message;

            }

        }//End GvCurrentDuration_RowUpdating













    }// End new_duration
}