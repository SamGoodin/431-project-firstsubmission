using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject
{
    public partial class new_season : System.Web.UI.Page
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
               
           
        }// End Page_Load



       
        // Populates the data
        void PopulateGridView()
        {

            DataTable dtbl = new DataTable();
            string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * from Season", con);
            sqlData.Fill(dtbl);
            
            if (dtbl.Rows.Count > 0)
            {
                gvCurrentSeasons.DataSource = dtbl;
                gvCurrentSeasons.DataBind();
               
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvCurrentSeasons.DataSource = dtbl;
                gvCurrentSeasons.DataBind();
                gvCurrentSeasons.Rows[0].Cells.Clear();
                gvCurrentSeasons.Rows[0].Cells.Add(new TableCell());
                gvCurrentSeasons.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvCurrentSeasons.Rows[0].Cells[0].Text = "No Seasons Found.";
                gvCurrentSeasons.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con.Close();

        }//End populateGridView


        //Adds new Season
        //Updates Active/Inactive
        protected void GvCurrentSeasons_RowCommand(object sender, GridViewCommandEventArgs e)
        {        
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string sqlQuery = "INSERT INTO Season (SeasonName, Active) VALUES (@SeasonName, @Active)";
                    string active = "Yes";
                    SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("@SeasonName", (gvCurrentSeasons.FooterRow.FindControl("txtSeasonNameFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.Add("@Active", SqlDbType.VarChar);
                    sqlCmd.Parameters["@Active"].Value = active;
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridView();
                    ltrlSqlError.Text = "New Season Added!";
                    con.Close();


                }
                else if (e.CommandName.Equals("Inactivate"))
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





        }//End GvCurrentSeasons_RowCommand


        //Switches to edit view
        protected void GvCurrentSeasons_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCurrentSeasons.EditIndex = e.NewEditIndex;
            PopulateGridView();


        }//End GvCurrentSeasons_RowEditing
        //Cancels the edit
        protected void GvCurrentSeasons_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCurrentSeasons.EditIndex = -1;
            PopulateGridView();


        }//End GvCurrentSeasons_RowCancelingEdit

        //Updates the selection
        protected void GvCurrentSeasons_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Update Season
            try
            {
               
                string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string sqlQuery = "UPDATE Season SET SeasonName=@SeasonName WHERE SeasonID = @id";
                
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                sqlCmd.Parameters.AddWithValue("@SeasonName", (gvCurrentSeasons.Rows[e.RowIndex].FindControl("txtEditSeasonName") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvCurrentSeasons.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gvCurrentSeasons.EditIndex = -1;
                PopulateGridView();
                ltrlSqlError.Text = "Season Updated!";



                con.Close();

            }
            catch (Exception err)
            {
                ltrlSqlError.Text = err.Message;

            }

        }//End GvCurrentSeasons_RowUpdating



    }//End of new_season
}







