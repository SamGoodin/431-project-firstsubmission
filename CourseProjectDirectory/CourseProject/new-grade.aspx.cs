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
    public partial class new_grade : System.Web.UI.Page
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
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * from GRADE", con);
            sqlData.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvCurrentGrade.DataSource = dtbl;
                gvCurrentGrade.DataBind();

            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvCurrentGrade.DataSource = dtbl;
                gvCurrentGrade.DataBind();
                gvCurrentGrade.Rows[0].Cells.Clear();
                gvCurrentGrade.Rows[0].Cells.Add(new TableCell());
                gvCurrentGrade.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvCurrentGrade.Rows[0].Cells[0].Text = "No Grades Found.";
                gvCurrentGrade.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con.Close();

        }//End populateGridView


        //Adds new Grade
        //Updates Active/Inactive
        protected void GvCurrentGrade_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string sqlQuery = "INSERT INTO GRADE (GradeLevel, Active) VALUES (@GradeLevel, @Active)";
                    string active = "Yes";
                    SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                    sqlCmd.Parameters.AddWithValue("@GradeLevel", (gvCurrentGrade.FooterRow.FindControl("txtGradeNameFooter") as TextBox).Text.Trim());
                    sqlCmd.Parameters.Add("@Active", SqlDbType.VarChar);
                    sqlCmd.Parameters["@Active"].Value = active;
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridView();
                    ltrlSqlError.Text = "New Grade Added!";
                    con.Close();


                }
                else if (e.CommandName.Equals("Inactivate"))
                {
                    // Get GradeID and current active/inactive
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                    string rowIndex = commandArgs[0];
                    string action = commandArgs[1];


                    // Find if we need to activate or inactivate Grade
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
                    string sqlQuery = "UPDATE GRADE SET Active = @Active WHERE GradeID = @id";
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





        }//End GvCurrentGrade_RowCommand


        //Switches to edit view
        protected void GvCurrentGrade_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCurrentGrade.EditIndex = e.NewEditIndex;
            PopulateGridView();


        }//End GvCurrentGrade_RowEditing

        //Cancels the edit
        protected void GvCurrentGrade_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCurrentGrade.EditIndex = -1;
            PopulateGridView();


        }//End GvCurrentGrade_RowCancelingEdit

        //Updates the selection
        protected void GvCurrentGrade_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //Update Grade
            try
            {

                string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                string sqlQuery = "UPDATE GRADE SET GradeLevel=@GradeLevel WHERE GradeID = @id";

                SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                sqlCmd.Parameters.AddWithValue("@GradeLevel", (gvCurrentGrade.Rows[e.RowIndex].FindControl("txtEditGradeName") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvCurrentGrade.DataKeys[e.RowIndex].Value.ToString()));
                sqlCmd.ExecuteNonQuery();
                gvCurrentGrade.EditIndex = -1;
                PopulateGridView();
                ltrlSqlError.Text = "Grade Updated!";



                con.Close();

            }
            catch (Exception err)
            {
                ltrlSqlError.Text = err.Message;

            }

        }//End GvCurrentGrade_RowUpdating



















    }// End New_Grade
}