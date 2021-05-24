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
    public partial class review_program_managers : System.Web.UI.Page
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




        // Populates the unapproved managers
        void PopulateGridView()
        {

            DataTable dtbl = new DataTable();
            string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string no = "no";
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * from MANAGER where approved = '"+no+"'", con);
            sqlData.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvManagersToBeApproved.DataSource = dtbl;
                gvManagersToBeApproved.DataBind();

            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvManagersToBeApproved.DataSource = dtbl;
                gvManagersToBeApproved.DataBind();
                gvManagersToBeApproved.Rows[0].Cells.Clear();
                gvManagersToBeApproved.Rows[0].Cells.Add(new TableCell());
                gvManagersToBeApproved.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvManagersToBeApproved.Rows[0].Cells[0].Text = "No Managers Pending Approval.";
                gvManagersToBeApproved.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con.Close();

        }//End populateGridView

        // Populates the approved managers
        void PopulateGridView2()
        {

            DataTable dtbl = new DataTable();
            string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            SqlConnection con2 = new SqlConnection(cs);
            con2.Open();
            string yes = "Yes";
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * from MANAGER where approved = '" + yes + "'", con2);
            sqlData.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvApprovedManagers.DataSource = dtbl;
                gvApprovedManagers.DataBind();

            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvApprovedManagers.DataSource = dtbl;
                gvApprovedManagers.DataBind();
                gvApprovedManagers.Rows[0].Cells.Clear();
                gvApprovedManagers.Rows[0].Cells.Add(new TableCell());
                gvApprovedManagers.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvApprovedManagers.Rows[0].Cells[0].Text = "No Managers Approved.";
                gvApprovedManagers.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con2.Close();

        }//End populateGridView2



        //Updates Approve/Disapprove
        protected void GvManagerApproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Approve"))
                {
                    string commandArg = e.CommandArgument.ToString();
                    string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string sqlQuery = "UPDATE MANAGER SET Approved = @Active WHERE email = @Email";
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
                    errorLbl.Text = "Manager Approved!";
                    Label2.Text = "";
                    con.Close();


                }
                else if (e.CommandName.Equals("Disapprove"))
                {
                    // Get email
                    string commandArg = e.CommandArgument.ToString();

                    string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    string sqlQuery = "UPDATE MANAGER SET Approved = @Active WHERE email = @Email";
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
                    Label2.Text = "Manager Disapproved!";
                    errorLbl.Text = "";
                    con.Close();
                                       
                }

            }
            catch (Exception err)
            {
                Label2.Text = err.Message;

            }





        }//End GvManagerApproval_RowCommand


    }// End review_program_managers
}