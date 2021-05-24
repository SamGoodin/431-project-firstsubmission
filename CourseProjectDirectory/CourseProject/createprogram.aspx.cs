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
    public partial class createprogram : System.Web.UI.Page
    {

        string cs;
        SqlConnection conn;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Fill_State();
            }
        }



        public void Fill_State()
        {
            cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select State_Name,ID from US_STATE", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            ddProgramStateID.DataSource = dr;
            ddProgramStateID.Items.Clear();
            ddProgramStateID.Items.Add("--Please Select State--");
            ddProgramStateID.DataTextField = "State_Name";
            ddProgramStateID.DataValueField = "ID";
            ddProgramStateID.DataBind();
            conn.Close();
        }



      

        public void Bind_ddlCity()
        {
            cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            SqlCommand cmd = new SqlCommand("select City,ID from US_CITY where ID_STATE='" + ddProgramStateID.SelectedValue + "'", conn);

            SqlDataReader dr = cmd.ExecuteReader();
            programCityID.DataSource = dr;
            programCityID.Items.Clear();
            programCityID.Items.Add("--Please Select City--");
            programCityID.DataTextField = "City";
            programCityID.DataValueField = "ID";
            programCityID.DataBind();
            conn.Close();
        }

        public void Bind_ddlCounty()
        {
            string cs2 = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            SqlConnection conn2 = new SqlConnection(cs2);
            conn2.Open();

            SqlCommand cmd = new SqlCommand("select County,ID from US_CITY where ID='" + programCityID.SelectedValue + "'", conn2);

            SqlDataReader dr = cmd.ExecuteReader();
            ddProgramCountyID.DataSource = dr;
            ddProgramCountyID.Items.Clear();
            ddProgramCountyID.Items.Add("-- Please select City for County--");
            ddProgramCountyID.DataTextField = "County";
            ddProgramCountyID.DataValueField = "ID";
            ddProgramCountyID.DataBind();
            conn2.Close();
        }



        protected void Submit_Click1(object sender, EventArgs e)
        {
            /* Old
            string programName = programNameID.Text;
            string programAbbreviation = programAbbreviationID.Text;
            string programContactName = programContactNameID.Text;
            string[] contactName = programContactName.Split(' ');
            string contactFirstName = contactName[0];
            string contactLastName = contactName[1];
            string programContactEmail = programContactEmailID.Text;
            string programContactPhone = programContactPhoneID.Text;
            string checkboxList;
            string gradeRadioButtonList = gradeRadioButtonListID.SelectedValue;
            string programHousingNeeds = programHousingNeedsID.SelectedValue;
            string programCost = programCostID.SelectedValue;
            string programDuration = programDurationID.Text;
            string programDurationAdditionalNotes = programDurationAdditionalNotesID.Text;
            string programSeason = programSeasonID.SelectedValue;
            DateTime programStartDate = DateTime.Parse(programStartDateID.Text);
            DateTime programApplicationDeadline = DateTime.Parse(programApplicationDeadlineID.Text);
            int universityAffiliations = 0;
            // currently an integer in the DB. will need to be changed to varchar
            int DDlistAffil = 2;
            string programEligibilityRestrictionsOther = programEligibilityRestrictionsOtherID.Text;
            string programServiceArea = programServiceAreaID.SelectedValue;
            string programNotesToAdmin = programNotesToAdminID.Text;
            string programDescription = programDescriptionID.Text;
            string programAddress1 = programAddress1ID.Text;
            string programCounty = programCountyID.SelectedValue;
            string programAddress2 = programAddress2ID.Text;
            string programState = programStateID.SelectedValue;
            string programZipcode = programZipcodeID.Text;
            DateTime lastUpdated = DateTime.Now;
            */
            string checkboxList;
            int universityAffiliations = 0;
            // currently an integer in the DB. will need to be changed to varchar

            if (otherFieldsPanelID.Visible == true)
            {
                checkboxList = otherFieldID.Text;
            }
            else
            {
                checkboxList = CheckboxList1.SelectedValue;
            }
            if (affilPanelID.Visible == true)
            {
                universityAffiliations = 1;

            }

            Session["pgmName"] = programNameID.Text;
            Session["pgmAbbr"] = programAbbreviationID.Text;
            Session["contactFirstName"] = pgmFirstNameID.Text;
            Session["contactLastName"] = pgmLastNameID.Text;
            Session["contactEmail"] = programContactEmailID.Text;
            Session["contactPhone"] = programContactPhoneID.Text;
            Session["checkboxList"] = checkboxList;
            Session["grade"] = gradeRadioButtonListID.SelectedValue;
            Session["housingNeeds"] = programHousingNeedsID.SelectedValue;
            Session["cost"] = programCostID.SelectedValue;
            Session["stipend"] = programStipendID.SelectedValue;
            Session["duration"] = programDurationID.Text;
            Session["durationNotes"] = programDurationAdditionalNotesID.Text;
            Session["season"] = programSeasonID.SelectedValue;
            Session["startDate"] = DateTime.Parse(programStartDateID.Text);
            Session["appDeadline"] = DateTime.Parse(programApplicationDeadlineID.Text);
            Session["uniAffi"] = universityAffiliations;
            Session["eligibilityRestr"] = programEligibilityRestrictionsOtherID.Text;
            Session["serviceArea"] = programServiceAreaID.SelectedValue;
            Session["notesToAdmin"] = programNotesToAdminID.Text;
            Session["description"] = programDescriptionID.Text;
            Session["address1"] = programAddress1ID.Text;
            Session["county"] = ddProgramCountyID.SelectedValue;
            Session["address2"] = programAddress2ID.Text;
            Session["city"] = programCityID.SelectedValue;
            Session["state"] = ddProgramStateID.SelectedValue;
            Session["zipcode"] = programZipcodeID.Text;

            Response.Redirect("confirmCreatePgm.aspx");

        }//End Submit_Click1


        //Field Of Study CheckboxList
        protected void FieldsOfStudy_ServerChange(object sender, EventArgs e)
        {
            for (int i = 0; i < CheckboxList1.Items.Count; i++)
            {
                if (CheckboxList1.Items[(CheckboxList1.Items.Count) - 1].Selected)
                {

                    if (CheckboxList1.SelectedItem.Text == "Other")
                    {
                        otherFieldsPanelID.Visible = true;
                    }
                    else otherFieldsPanelID.Visible = false;

                }
            }
        }

        //Program Housing Dropdown
        //protected void programHousingNeedsID_ServerChange(object sender, EventArgs e)
        //{
        //    if (programHousingNeedsID.SelectedItem.Value == "Yes, for all students")
        //    {
        //        residencePanelID.Visible = true;
        //    }
        //    else
        //    {
        //        residencePanelID.Visible = false;
        //    }
        //}

        //Cost of Program Housing Dropdown
        //protected void programCostID_ServerChange(object sender, EventArgs e)
        //{
        //    if (programCostID.SelectedItem.Value == "CostPlusAll")
        //    {
        //        programCostPanelOneID.Visible = true;
        //        programCostPanelTwoID.Visible = false;
        //        programCostPanelThreeID.Visible = false;
        //        programCostPanelFourID.Visible = false;
        //    }
        //    else if (programCostID.SelectedItem.Value == "CostPlusSome")
        //    {
        //        programCostPanelOneID.Visible = false;
        //        programCostPanelTwoID.Visible = true;
        //        programCostPanelThreeID.Visible = false;
        //        programCostPanelFourID.Visible = false;
        //    }
        //    else if (programCostID.SelectedItem.Value == "CostForAll")
        //    {
        //        programCostPanelOneID.Visible = false;
        //        programCostPanelTwoID.Visible = false;
        //        programCostPanelThreeID.Visible = true;
        //        programCostPanelFourID.Visible = false;
        //    }
        //    else if (programCostID.SelectedItem.Value == "CostDetermined")
        //    {
        //        programCostPanelOneID.Visible = false;
        //        programCostPanelTwoID.Visible = false;
        //        programCostPanelThreeID.Visible = false;
        //        programCostPanelFourID.Visible = true;
        //    }
        //    else
        //    {
        //        programCostPanelOneID.Visible = false;
        //        programCostPanelTwoID.Visible = false;
        //        programCostPanelThreeID.Visible = false;
        //        programCostPanelFourID.Visible = false;
        //    }

        //}

        protected void RadioAffil_checkedChanged(object sender, EventArgs e)
        {
            if (RadioAffilYesID.Checked)
            {
                affilPanelID.Visible = true;
            }
            else
            {
                affilPanelID.Visible = false;
            }
        }

        //DD LIST UNI AFFILIATION
        //protected void DDlistAffil_ServerChange(object sender, EventArgs e)
        //{
        //    if (DDlistAffilID.SelectedItem.Value == "OtherAffil")
        //    {
        //        affilOtherPanelID.Visible = true;
        //    }
        //    else
        //    {
        //        affilOtherPanelID.Visible = false;
        //    }
        //}

        //DD LIST SERVICE
        protected void DDlistService_ServerChange(object sender, EventArgs e)
        {
            if (programServiceAreaID.SelectedItem.Value == "Other")
            {
                servicePanelID.Visible = true;
            }
            else
            {
                servicePanelID.Visible = false;
            }
        }


        protected void DDlistState_ServerChange(object sender, EventArgs e)
        {
            Bind_ddlCity();
            Bind_ddlCounty();
        }

        protected void DDlistCity_ServerChange(object sender, EventArgs e)
        {
            Bind_ddlCounty();
        }

    }// End creatprogram
}