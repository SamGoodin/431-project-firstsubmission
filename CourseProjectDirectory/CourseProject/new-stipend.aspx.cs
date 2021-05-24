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
    public partial class new_stipend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                if (Session["email"] == null)
                {
                    Response.Redirect("login.aspx");
                }
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
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * from STIPEND", con);
            sqlData.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvCurrentStipend.DataSource = dtbl;
                gvCurrentStipend.DataBind();

            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvCurrentStipend.DataSource = dtbl;
                gvCurrentStipend.DataBind();
                gvCurrentStipend.Rows[0].Cells.Clear();
                gvCurrentStipend.Rows[0].Cells.Add(new TableCell());
                gvCurrentStipend.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvCurrentStipend.Rows[0].Cells[0].Text = "No Stipends Found.";
                gvCurrentStipend.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con.Close();

        }//End populateGridView


        //Adds new Stipend
        //Updates Active/Inactive
        protected void GvCurrentStipend_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string sqlQuery = "INSERT INTO STIPEND (Participants, Active) VALUES (@Participants, @Active)";
                    string active = "Yes";
                    SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("@Participants", (gvCurrentStipend.FooterRow.FindControl("txtStipendFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.Add("@Active", SqlDbType.VarChar);
                    sqlCmd.Parameters["@Active"].Value = active;
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridView();
                    ltrlSqlError.Text = "New Stipend Added!";
                    con.Close();


                }
                else if (e.CommandName.Equals("Inactivate"))
                {
                    // Get StipendID and current active/inactive
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
                    string sqlQuery = "UPDATE STIPEND SET Active = @Active WHERE StipendID = @id";
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





        }//End GvCurrentStipend_RowCommand


        //Switches to edit view
        protected void GvCurrentStipend_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCurrentStipend.EditIndex = e.NewEditIndex;
            PopulateGridView();


        }//End GvCurrentStipend_RowEditing

        //Cancels the edit
        protected void GvCurrentStipend_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCurrentStipend.EditIndex = -1;
            PopulateGridView();


        }//End GvCurrentStipend_RowCancelingEdit

        //Updates the selection
        protected void GvCurrentStipend_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Update Stipend
            try
            {

                string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string sqlQuery = "UPDATE STIPEND SET Participants=@Participants WHERE StipendID = @id";

                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                sqlCmd.Parameters.AddWithValue("@Participants", (gvCurrentStipend.Rows[e.RowIndex].FindControl("txtEditStipend") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvCurrentStipend.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gvCurrentStipend.EditIndex = -1;
                PopulateGridView();
                ltrlSqlError.Text = "Stipend Updated!";



                con.Close();

            }
            catch (Exception err)
            {
                ltrlSqlError.Text = err.Message;

            }

        }//End GvCurrentStipend_RowUpdating





















    }// End New_Stipend
}