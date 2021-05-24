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
    public partial class view_edit_program : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null || Session["role"] == null || Convert.ToInt32(Session["role"]) < 1)
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
            int selectedProgramID = Convert.ToInt32(Session["programID"]); 
            DataTable dtbl = new DataTable();
            string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * from PROGRAM Where ProgramID = '"+ selectedProgramID + "' ", con);
            sqlData.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvSelectedProgram.DataSource = dtbl;
                gvSelectedProgram.DataBind();

            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvSelectedProgram.DataSource = dtbl;
                gvSelectedProgram.DataBind();
                gvSelectedProgram.Rows[0].Cells.Clear();
                gvSelectedProgram.Rows[0].Cells.Add(new TableCell());
                gvSelectedProgram.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvSelectedProgram.Rows[0].Cells[0].Text = "No Program Found.";
                gvSelectedProgram.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con.Close();

        }//End populateGridView

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }








    }// End view-edit-program
}