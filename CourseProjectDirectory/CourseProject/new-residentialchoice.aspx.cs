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
    public partial class new_residentialchoice : System.Web.UI.Page
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
        }







        // Populates the data
        void PopulateGridView()
        {

            DataTable dtbl = new DataTable();
            string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * from RESIDENTIAL", con);
            sqlData.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvCurrentResidentialOptions.DataSource = dtbl;
                gvCurrentResidentialOptions.DataBind();

            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvCurrentResidentialOptions.DataSource = dtbl;
                gvCurrentResidentialOptions.DataBind();
                gvCurrentResidentialOptions.Rows[0].Cells.Clear();
                gvCurrentResidentialOptions.Rows[0].Cells.Add(new TableCell());
                gvCurrentResidentialOptions.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvCurrentResidentialOptions.Rows[0].Cells[0].Text = "No Residential Options Found.";
                gvCurrentResidentialOptions.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con.Close();

        }//End populateGridView




        //Adds new Residential Option
        //Updates Active/Inactive
        protected void GvCurrentResidentialOptions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                        
                        string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                        SqlConnection con = new SqlConnection(cs);
                        con.Open();
                        string sqlQuery = "INSERT INTO RESIDENTIAL (ResidentialType, Active) VALUES (@ResidentialType, @Active)";
                        string active = "Yes";
                        SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                        sqlCmd.Parameters.AddWithValue("@ResidentialType", (gvCurrentResidentialOptions.FooterRow.FindControl("txtResidentialTypeNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.Add("@Active", SqlDbType.VarChar);
                        sqlCmd.Parameters["@Active"].Value = active;
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridView();
                        ltrlSqlError.Text = "New Residential Option Added!";
                        con.Close();
                   


                }
                else if (e.CommandName.Equals("Inactivate"))
                {
                    // Get Residential and current active/inactive
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string rowIndex = commandArgs[0];
                    string action = commandArgs[1];


                    // Find if we need to activate or inactivate Residential Option
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
                    string sqlQuery = "UPDATE RESIDENTIAL SET Active = @Active WHERE ResidentialID = @id";
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





        }//End gvCurrentResidentialOptions_RowCommand




        //Switches to edit view
        protected void GvCurrentResidentialOptions_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCurrentResidentialOptions.EditIndex = e.NewEditIndex;
            PopulateGridView();


        }//End gvCurrentResidentialOptions_RowEditing

        //Cancels the edit
        protected void GvCurrentResidentialOptions_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCurrentResidentialOptions.EditIndex = -1;
            PopulateGridView();


        }//End gvCurrentResidentialOptions_RowCancelingEdit


        //Updates the selection
        protected void GvCurrentResidentialOptions_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Update Residential Option
            try
            {

                string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string sqlQuery = "UPDATE RESIDENTIAL SET ResidentialType=@ResidentialType WHERE ResidentialID = @id";

                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                sqlCmd.Parameters.AddWithValue("@ResidentialType", (gvCurrentResidentialOptions.Rows[e.RowIndex].FindControl("txtEditResidentialTypeName") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvCurrentResidentialOptions.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gvCurrentResidentialOptions.EditIndex = -1;
                PopulateGridView();
                ltrlSqlError.Text = "Residential Option Updated!";



                con.Close();

            }
            catch (Exception err)
            {
                ltrlSqlError.Text = err.Message;

            }

        }//End gvCurrentResidentialOptions_RowUpdating






    }
}