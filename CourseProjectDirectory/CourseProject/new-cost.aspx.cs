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
    public partial class new_cost : System.Web.UI.Page
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
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * from COST", con);
            sqlData.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvCurrentCost.DataSource = dtbl;
                gvCurrentCost.DataBind();

            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvCurrentCost.DataSource = dtbl;
                gvCurrentCost.DataBind();
                gvCurrentCost.Rows[0].Cells.Clear();
                gvCurrentCost.Rows[0].Cells.Add(new TableCell());
                gvCurrentCost.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvCurrentCost.Rows[0].Cells[0].Text = "No Costs Found.";
                gvCurrentCost.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con.Close();

        }//End populateGridView


        //Adds new Cost
        //Updates Active/Inactive
        protected void GvCurrentCost_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string sqlQuery = "INSERT INTO COST (CostAmount, Active) VALUES (@CostAmount, @Active)";
                    string active = "Yes";
                    SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("@CostAmount", (gvCurrentCost.FooterRow.FindControl("txtCostFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.Add("@Active", SqlDbType.VarChar);
                    sqlCmd.Parameters["@Active"].Value = active;
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridView();
                    ltrlSqlError.Text = "New Cost Added!";
                    con.Close();


                }
                else if (e.CommandName.Equals("Inactivate"))
                {
                    // Get CostID and current active/inactive
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string rowIndex = commandArgs[0];
                    string action = commandArgs[1];


                    // Find if we need to activate or inactivate Cost
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
                    string sqlQuery = "UPDATE COST SET Active = @Active WHERE CostID = @id";
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





        }//End GvCurrentCost_RowCommand


        //Switches to edit view
        protected void GvCurrentCost_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCurrentCost.EditIndex = e.NewEditIndex;
            PopulateGridView();


        }//End GvCurrentCost_RowEditing

        //Cancels the edit
        protected void GvCurrentCost_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCurrentCost.EditIndex = -1;
            PopulateGridView();


        }//End GvCurrentCost_RowCancelingEdit

        //Updates the selection
        protected void GvCurrentCost_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Update Cost
            try
            {

                string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string sqlQuery = "UPDATE COST SET CostAmount=@CostAmount WHERE CostID = @id";

                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                sqlCmd.Parameters.AddWithValue("@CostAmount", (gvCurrentCost.Rows[e.RowIndex].FindControl("txtEditCost") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvCurrentCost.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gvCurrentCost.EditIndex = -1;
                PopulateGridView();
                ltrlSqlError.Text = "Cost Updated!";



                con.Close();

            }
            catch (Exception err)
            {
                ltrlSqlError.Text = err.Message;

            }

        }//End GvCurrentCost_RowUpdating


















    }// End new_cost
}