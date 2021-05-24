using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseProject
{
#pragma warning disable IDE1006 // Naming Styles
    public partial class program_maintenance : System.Web.UI.Page
#pragma warning restore IDE1006 // Naming Styles
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}