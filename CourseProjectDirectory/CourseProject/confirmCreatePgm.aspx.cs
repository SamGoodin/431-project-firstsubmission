using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// db namespace
using System.Data.SqlClient;
using System.Web.Configuration;

namespace CourseProject
{
    public partial class confirmCreatePgm : System.Web.UI.Page
    {
        string pgmNameV;
        string pgmAbbrV;
        string contactFNameV;
        string contactLNameV;
        string contactEmailV;
        string contactPhoneV;
        string checkboxListV;
        string gradeV;
        string housingNeedsV;
        string costV;
        string stipendV;
        string durationV;
        string durationNotesV;
        string seasonV;
        string startDateV;
        string applicationDeadlineV;
        string uniAffiliationV;
        string eligibilityV;
        string serviceAreaV;
        string notesToAdminV;
        string descriptionV;
        string address1V;
        string countyV;
        string address2V;
        string cityV;
        string stateV;
        string zipcodeV;

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (Session["email"] == null || Session["pgmName"].ToString() == null)
            {
                Response.Redirect("login.aspx");
            }
            */

            if (!this.IsPostBack)
            {
                pgmNameV = Session["pgmName"].ToString();
                pgmAbbrV = Session["pgmAbbr"].ToString();
                contactFNameV = Session["contactFirstName"].ToString();
                contactLNameV = Session["contactLastName"].ToString();
                contactEmailV = Session["contactEmail"].ToString();
                contactPhoneV = Session["contactPhone"].ToString();
                checkboxListV = Session["checkboxList"].ToString();
                gradeV = Session["grade"].ToString();
                housingNeedsV = Session["housingNeeds"].ToString();
                costV = Session["cost"].ToString();
                stipendV = Session["stipend"].ToString();
                durationV = Session["duration"].ToString();
                durationNotesV = Session["durationNotes"].ToString();
                seasonV = Session["season"].ToString();
                startDateV = Session["startDate"].ToString();
                applicationDeadlineV = Session["appDeadline"].ToString();
                uniAffiliationV = Session["uniAffi"].ToString();
                eligibilityV = Session["eligibilityRestr"].ToString();
                serviceAreaV = Session["serviceArea"].ToString();
                notesToAdminV = Session["notesToAdmin"].ToString();
                descriptionV = Session["description"].ToString();
                address1V = Session["address1"].ToString();
                countyV = Session["county"].ToString();
                address2V = Session["address2"].ToString();
                cityV = Session["city"].ToString();
                stateV = Session["state"].ToString();
                zipcodeV = Session["zipcode"].ToString();

// TODO !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                pgmName.Text += Session["pgmName"].ToString();
                pgmAbbr.Text += Session["pgmAbbr"].ToString();
                contactFName.Text += Session["contactFirstName"].ToString();
                contactLName.Text += Session["contactLastName"].ToString();
                contactEmail.Text += Session["contactEmail"].ToString();
                contactPhone.Text += Session["contactPhone"].ToString();
                checkboxList.Text += Session["checkboxList"].ToString();
                grade.Text += Session["grade"].ToString();
                housingNeeds.Text += Session["housingNeeds"].ToString();
                cost.Text += Session["cost"].ToString();
                stipend.Text += Session["stipend"].ToString();
                duration.Text += Session["duration"].ToString();
                durationNotes.Text += Session["durationNotes"].ToString();
                season.Text += Session["season"].ToString();
                startDate.Text += Session["startDate"].ToString();
                applicationDeadline.Text += Session["appDeadline"].ToString();
                eligibility.Text += Session["eligibilityRestr"].ToString();
                serviceArea.Text += Session["serviceArea"].ToString();
                notesToAdmin.Text += Session["notesToAdmin"].ToString();
                description.Text += Session["description"].ToString();
                address1.Text += Session["address1"].ToString();
                county.Text += Session["county"].ToString();
                address2.Text += Session["address2"].ToString();
                city.Text += Session["city"].ToString();
                state.Text += Session["state"].ToString();
                zipcode.Text += Session["zipcode"].ToString();
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            processSql();
        }

        protected void processSql()
        {
            if (Page.IsValid)
            {

                int contactID;
                string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                try
                {
                    con.Open();
                    string sql = "INSERT INTO CONTACT(FirstName,LastName,Email,Phone) VALUES(@ContactFirstName, @ContactLastName, @ContactEmail, @ContactPhone)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    var contactFirstNameParam = new SqlParameter("ContactFirstName", System.Data.SqlDbType.VarChar);
                    var contactLastNameParam = new SqlParameter("ContactLastName", System.Data.SqlDbType.VarChar);
                    var contactEmailParam = new SqlParameter("ContactEmail", System.Data.SqlDbType.VarChar);
                    var contactPhoneParam = new SqlParameter("ContactPhone", System.Data.SqlDbType.VarChar);
                    contactFirstNameParam.Value = Session["contactFirstName"].ToString();
                    contactLastNameParam.Value = Session["contactLastName"].ToString();
                    contactEmailParam.Value = Session["contactEmail"].ToString();
                    contactPhoneParam.Value = Session["contactPhone"].ToString();
                    cmd.Parameters.Add(contactFirstNameParam);
                    cmd.Parameters.Add(contactLastNameParam);
                    cmd.Parameters.Add(contactEmailParam);
                    cmd.Parameters.Add(contactPhoneParam);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    errorLbl.Text = "Contact";

                    //not sure on the one below

                    string contactSql = "select ContactID from CONTACT where LastName = '" + Session["contactLastName"].ToString() + "'";
                    SqlCommand contactCmd = new SqlCommand(contactSql, con);
                    con.Open();
                    SqlDataReader contactReader = contactCmd.ExecuteReader();
                    contactReader.Read();
                    contactID = (int)contactReader["ContactID"];
                    con.Close();

                    string costSql = "select CostID from COST where CostAmount = '" + Session["cost"].ToString() + "'";
                    SqlCommand costCmd = new SqlCommand(costSql, con);
                    con.Open();
                    SqlDataReader costReader = costCmd.ExecuteReader();
                    costReader.Read();
                    int costID = (int)costReader["CostID"];
                    con.Close();
                    errorLbl.Text = "CostsID";

                    string fieldSql = "select FieldID from FIELD where FieldName = '" + Session["checkboxList"].ToString() + "'";
                    SqlCommand fieldCmd = new SqlCommand(fieldSql, con);
                    con.Open();
                    SqlDataReader fieldReader = fieldCmd.ExecuteReader();
                    fieldReader.Read();
                    int fieldID = (int)fieldReader["FieldID"];
                    con.Close();
                    errorLbl.Text = "FielDID";

                    /*
                    string gradeSql = "select GradeID from GRADE where GradeLevel = '" + Session["grade"].ToString() + "'";
                    SqlCommand gradeCmd = new SqlCommand(gradeSql, con);
                    con.Open();
                    SqlDataReader gradeReader = gradeCmd.ExecuteReader();
                    gradeReader.Read();
                    errorLbl.Text = "GRADE : " + Session["grade"].ToString();
                    int gradeID = (int)gradeReader["GradeID"];
                    con.Close();
                    errorLbl.Text = "GradeID";
                    */
                    int gradeID = 1;

                    string resSql = "select ResidentialID from RESIDENTIAL where ResidentialType = '" + Session["housingNeeds"].ToString() + "'";
                    SqlCommand resCmd = new SqlCommand(resSql, con);
                    con.Open();
                    SqlDataReader resReader = resCmd.ExecuteReader();
                    resReader.Read();
                    int residentialID = (int)resReader["ResidentialID"];
                    con.Close();
                    errorLbl.Text = "Res";

                    /*
                    string stipSql = "select StipendID from STIPEND where Participants = '" + Session["stipend"].ToString() + "'";
                    SqlCommand stipCmd = new SqlCommand(stipSql, con);
                    con.Open();
                    SqlDataReader stipReader = stipCmd.ExecuteReader();
                    stipReader.Read();
                    errorLbl.Text = "GRADE : " + Session["stipend"].ToString();
                    int stipendID = (int)stipReader["StipendID"];
                    con.Close();
                    errorLbl.Text = "Stipend";
                    */
                    int stipendID = 1;

                    /*
                    string durSql = "select DurationID from DURATION where Length = '" + Session["duration"].ToString() + "'";
                    SqlCommand durCmd = new SqlCommand(durSql, con);
                    con.Open();
                    SqlDataReader durReader = durCmd.ExecuteReader();
                    durReader.Read();
                    errorLbl.Text = "dur : " + Session["duration"].ToString();
                    int durationID = (int)durReader["DurationID"];
                    con.Close();
                    errorLbl.Text = "Duration";
                    */
                    int durationID = 1;

                    /*
                    string seasSql = "select SeasonID from SEASON where SeasonName = '" + Session["season"].ToString() + "'";
                    SqlCommand seasCmd = new SqlCommand(seasSql, con);
                    con.Open();
                    SqlDataReader seasReader = seasCmd.ExecuteReader();
                    seasReader.Read();
                    errorLbl.Text = "seas : " + Session["season"].ToString();
                    int seasonID = (int)seasReader["SeasonID"];
                    con.Close();
                    errorLbl.Text = "Season";
                    */
                    int seasonID = 1;
                    errorLbl.Text = "Season";

                    DateTime startDate = DateTime.Parse(Session["startDate"].ToString());
                    DateTime applicationDeadline = DateTime.Parse(Session["appDeadline"].ToString());
                    errorLbl.Text = "dates";

                    // Affiliation is boolean
                    string affiliation;
                    if (Session["uniAffi"].ToString() != null)
                    {
                        affiliation = "yes";
                    }
                    else
                    {
                        affiliation = "no";
                    }
                    errorLbl.Text = "Affiliation";

                    string servSql = "select ServiceAreaID from SERVICEAREA where ServiceArea = '" + Session["serviceArea"].ToString() + "'";
                    SqlCommand servCmd = new SqlCommand(servSql, con);
                    con.Open();
                    SqlDataReader servReader = servCmd.ExecuteReader();
                    servReader.Read();
                    errorLbl.Text = "serv : " + Session["serviceArea"].ToString();
                    int serviceAreaID = (int)servReader["ServiceAreaID"];
                    con.Close();
                    errorLbl.Text = "ServiceAreaID";

                    DateTime lastUpdated = DateTime.Now;

                    string active = "Yes";

                    string finalSql = "INSERT INTO PROGRAM(Name,ContactID,CostID,FieldID,GradeID,ResidentialID,StipendID,DurationID,SeasonID,StartDate,ApplicationDeadline,Affiliation,AffiliationID,AdditionalRestriction,Institution,AddressLine1,AddressLine2,AddressLine3,AddressState,AddressCity,AddressCounty,AddressZipcode,ServiceAreaID,Website,Description,LastUpdated,Active,CreatorEmail,CreatorRole,Approved) VALUES(@ProgramName,@ContactID,@CostID,@FieldID,@GradeID,@ResidentialID,@StipendID,@DurationID,@SeasonID,@StartDate,@ApplicationDeadline,@Affiliation,@AffiliationID,@AdditionalRestriction,@Institution,@AddressLine1,@AddressLine2,@AddressLine3,@AddressState,@AddressCity,@AddressCounty,@AddressZipcode,@ServiceAreaID,@Website,@Description,@LastUpdated,@Active,@CreatorEmail,@CreatorRole,@Approved)";
                    SqlCommand finalCmd = new SqlCommand(finalSql, con);                                                                                                              
                    con.Open();
                    var nameParam = new SqlParameter("ProgramName", System.Data.SqlDbType.VarChar);
                    var contactParam = new SqlParameter("ContactID", System.Data.SqlDbType.Int);
                    var costParam = new SqlParameter("CostID", System.Data.SqlDbType.SmallInt);
                    var fieldParam = new SqlParameter("FieldID", System.Data.SqlDbType.Int);
                    var gradeParam = new SqlParameter("GradeID", System.Data.SqlDbType.SmallInt);
                    var residentialParam = new SqlParameter("ResidentialID", System.Data.SqlDbType.SmallInt);
                    var stipendParam = new SqlParameter("StipendID", System.Data.SqlDbType.SmallInt);
                    var durationParam = new SqlParameter("DurationID", System.Data.SqlDbType.SmallInt);
                    var seasonParam = new SqlParameter("SeasonID", System.Data.SqlDbType.SmallInt);
                    var startDateParam = new SqlParameter("StartDate", System.Data.SqlDbType.DateTime);
                    var appDeadlineParam = new SqlParameter("ApplicationDeadline", System.Data.SqlDbType.DateTime);
                    var affiliationParam = new SqlParameter("Affiliation", System.Data.SqlDbType.VarChar);
                    var affiliationIDParam = new SqlParameter("AffiliationID", System.Data.SqlDbType.Int);
                    var restrictionParam = new SqlParameter("AdditionalRestriction", System.Data.SqlDbType.VarChar);
                    var institutionParam = new SqlParameter("Institution", System.Data.SqlDbType.VarChar);
                    var address1Param = new SqlParameter("AddressLine1", System.Data.SqlDbType.VarChar);
                    var address2Param = new SqlParameter("AddressLine2", System.Data.SqlDbType.VarChar);
                    var address3Param = new SqlParameter("AddressLine3", System.Data.SqlDbType.VarChar);
                    var addressStateParam = new SqlParameter("AddressState", System.Data.SqlDbType.VarChar);
                    var addressCityParam = new SqlParameter("AddressCity", System.Data.SqlDbType.VarChar);
                    var addressCountyParam = new SqlParameter("AddressCounty", System.Data.SqlDbType.VarChar);
                    var addressZipParam = new SqlParameter("AddressZipcode", System.Data.SqlDbType.Int);
                    var serviceAreaIDParam = new SqlParameter("ServiceAreaID", System.Data.SqlDbType.Int);
                    var websiteParam = new SqlParameter("Website", System.Data.SqlDbType.VarChar);
                    var descriptionParam = new SqlParameter("Description", System.Data.SqlDbType.VarChar);
                    var lastUpdatedParam = new SqlParameter("LastUpdated", System.Data.SqlDbType.DateTime);
                    var activeParam = new SqlParameter("Active", System.Data.SqlDbType.VarChar);
                    var cEmailParam = new SqlParameter("CreatorEmail", System.Data.SqlDbType.VarChar);
                    var cRoleParam = new SqlParameter("CreatorRole", System.Data.SqlDbType.Int);
                    var approvedParam = new SqlParameter("Approved", System.Data.SqlDbType.VarChar);
                    nameParam.Value = Session["pgmName"].ToString();
                    contactParam.Value = contactID;
                    costParam.Value = costID;
                    fieldParam.Value = fieldID;
                    gradeParam.Value = gradeID;
                    residentialParam.Value = residentialID;
                    stipendParam.Value = stipendID;
                    durationParam.Value = durationID;
                    seasonParam.Value = seasonID;
                    startDateParam.Value = startDate;
                    appDeadlineParam.Value = applicationDeadline;
                    //affiliationParam.Value = affiliation;
                    affiliationParam.Value = "yes" ;
                    affiliationIDParam.Value = 1;
                    restrictionParam.Value = Session["eligibilityRestr"].ToString();
                    institutionParam.Value = Session["uniAffi"].ToString();
                    address1Param.Value = Session["address1"].ToString();
                    address2Param.Value = Session["address2"].ToString();
                    address3Param.Value = "NULL";
                    addressStateParam.Value = Session["state"].ToString();
                    addressCityParam.Value = Session["city"].ToString();
                    addressCountyParam.Value = Session["county"].ToString();
                    addressZipParam.Value = Session["zipcode"].ToString();
                    serviceAreaIDParam.Value = serviceAreaID;
                    websiteParam.Value = "website.com";
                    descriptionParam.Value = Session["description"].ToString();
                    lastUpdatedParam.Value = lastUpdated;
                    cEmailParam.Value = Session["email"].ToString();
                    cRoleParam.Value = Convert.ToInt32(Session["role"]);
                    activeParam.Value = active;
                    approvedParam.Value = "no";
                    finalCmd.Parameters.Add(nameParam);
                    finalCmd.Parameters.Add(contactParam);
                    finalCmd.Parameters.Add(costParam);
                    finalCmd.Parameters.Add(fieldParam);
                    finalCmd.Parameters.Add(gradeParam);
                    finalCmd.Parameters.Add(residentialParam);
                    finalCmd.Parameters.Add(stipendParam);
                    finalCmd.Parameters.Add(durationParam);
                    finalCmd.Parameters.Add(seasonParam);
                    finalCmd.Parameters.Add(startDateParam);
                    finalCmd.Parameters.Add(appDeadlineParam);
                    finalCmd.Parameters.Add(affiliationParam);
                    finalCmd.Parameters.Add(affiliationIDParam);
                    finalCmd.Parameters.Add(restrictionParam);
                    finalCmd.Parameters.Add(institutionParam);
                    finalCmd.Parameters.Add(address1Param);
                    finalCmd.Parameters.Add(address2Param);
                    finalCmd.Parameters.Add(address3Param);
                    finalCmd.Parameters.Add(addressStateParam);
                    finalCmd.Parameters.Add(addressCityParam);
                    finalCmd.Parameters.Add(addressCountyParam);
                    finalCmd.Parameters.Add(addressZipParam);
                    finalCmd.Parameters.Add(serviceAreaIDParam);
                    finalCmd.Parameters.Add(websiteParam);
                    finalCmd.Parameters.Add(descriptionParam);
                    finalCmd.Parameters.Add(lastUpdatedParam);
                    finalCmd.Parameters.Add(activeParam);
                    finalCmd.Parameters.Add(cEmailParam);
                    finalCmd.Parameters.Add(cRoleParam);
                    finalCmd.Parameters.Add(approvedParam);
                    finalCmd.ExecuteNonQuery();
                    con.Close();

                    Response.Redirect("Profile.aspx");

                }
                catch (Exception err)
                {
                    //err.ToString();
                    errorLbl.Text = "Unable to register at this time, Please contact Administrator" + err;

                }
                finally
                {
                    con.Close();

                }
            }//End if valid
        }
    }
}