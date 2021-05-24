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
    public partial class new_servicearea : System.Web.UI.Page
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
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * from SERVICEAREA", con);
            sqlData.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvCurrentServiceArea.DataSource = dtbl;
                gvCurrentServiceArea.DataBind();

            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvCurrentServiceArea.DataSource = dtbl;
                gvCurrentServiceArea.DataBind();
                gvCurrentServiceArea.Rows[0].Cells.Clear();
                gvCurrentServiceArea.Rows[0].Cells.Add(new TableCell());
                gvCurrentServiceArea.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvCurrentServiceArea.Rows[0].Cells[0].Text = "No Service Areas Found.";
                gvCurrentServiceArea.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con.Close();

        }//End populateGridView


        //Adds new ServiceArea
        //Updates Active/Inactive
        protected void GvCurrentServiceArea_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string sqlQuery = "INSERT INTO SERVICEAREA (ServiceArea, Active) VALUES (@ServiceArea, @Active)";
                    string active = "Yes";
                    SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("@ServiceArea", (gvCurrentServiceArea.FooterRow.FindControl("txtServiceAreaFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.Add("@Active", SqlDbType.VarChar);
                    sqlCmd.Parameters["@Active"].Value = active;
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridView();
                    ltrlSqlError.Text = "New Service Area Added!";
                    con.Close();


                }
                else if (e.CommandName.Equals("Inactivate"))
                {
                    // Get ServiceAreaID and current active/inactive
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string rowIndex = commandArgs[0];
                    string action = commandArgs[1];


                    // Find if we need to activate or inactivate ServiceArea
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
                    string sqlQuery = "UPDATE SERVICEAREA SET Active = @Active WHERE ServiceAreaID = @id";
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





        }//End GvCurrentServiceArea_RowCommand


        //Switches to edit view
        protected void GvCurrentServiceArea_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCurrentServiceArea.EditIndex = e.NewEditIndex;
            PopulateGridView();


        }//End GvCurrentServiceArea_RowEditing

        //Cancels the edit
        protected void GvCurrentServiceArea_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCurrentServiceArea.EditIndex = -1;
            PopulateGridView();


        }//End GvCurrentServiceArea_RowCancelingEdit

        //Updates the selection
        protected void GvCurrentServiceArea_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Update ServiceArea
            try
            {

                string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string sqlQuery = "UPDATE SERVICEAREA SET ServiceArea=@ServiceArea WHERE ServiceAreaID = @id";

                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                sqlCmd.Parameters.AddWithValue("@ServiceArea", (gvCurrentServiceArea.Rows[e.RowIndex].FindControl("txtEditServiceArea") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvCurrentServiceArea.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gvCurrentServiceArea.EditIndex = -1;
                PopulateGridView();
                ltrlSqlError.Text = "Service Area Updated!";



                con.Close();

            }
            catch (Exception err)
            {
                ltrlSqlError.Text = err.Message;

            }

        }//End GvCurrentServiceArea_RowUpdating













    }// End new_servicearea
}