using System;
using System.Collections;
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
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FieldID.Items.Insert(0, new ListItem("Any","Any"));
                GradeID.Items.Insert(0, new ListItem("Any", "Any"));
                ResidentialID.Items.Insert(0, new ListItem("Any", "Any"));
                CostID.Items.Insert(0, new ListItem("Any", "Any"));
                StipendID.Items.Insert(0, new ListItem("Any", "Any"));
                DurationID.Items.Insert(0, new ListItem("Any", "Any"));
                SeasonID.Items.Insert(0, new ListItem("Any", "Any"));
                StartDateID.Items.Insert(0, new ListItem("Any", "Any"));
                ApplicationDeadlineID.Items.Insert(0, new ListItem("Any", "Any"));
                UniversityAffiliationID.Items.Insert(0, new ListItem("Any", "Any"));
                RestrictionsID.Items.Insert(0, new ListItem("Any", "Any"));
                StateID.Items.Insert(0, new ListItem("Any", "Any"));
                CityID.Items.Insert(0, new ListItem("Any", "Any"));
                CountyID.Items.Insert(0, new ListItem("Any", "Any"));
                PopulateGridView("select * from ProgramsView where programID = 1");
            }
        }



        // Populates the Inactivated managers for Activation
        void PopulateGridView(string sql)
        {

            DataTable dtbl = new DataTable();
            string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            //string no = sql;
            SqlDataAdapter sqlData = new SqlDataAdapter(sql, con);
            sqlData.Fill(dtbl);

            if (dtbl.Rows.Count > 0)
            {
                gvManagersToBeManagedActivate.DataSource = dtbl;
                gvManagersToBeManagedActivate.DataBind();

            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvManagersToBeManagedActivate.DataSource = dtbl;
                gvManagersToBeManagedActivate.DataBind();
                gvManagersToBeManagedActivate.Rows[0].Cells.Clear();
                gvManagersToBeManagedActivate.Rows[0].Cells.Add(new TableCell());
                gvManagersToBeManagedActivate.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvManagersToBeManagedActivate.Rows[0].Cells[0].Text = "No Program Found.";
                gvManagersToBeManagedActivate.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;




            }

            con.Close();

        }//End populateGridView


        protected void Submit_Click1(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                //int addUser = DBAction.AddUser(prefix, firstname, lastname, email, password, phone, emailNotification);
                string programName = ProgramNameID.Text;
                string field = FieldID.SelectedValue;
                string grade = GradeID.SelectedValue;
                string residential = ResidentialID.SelectedValue;
                string cost = CostID.SelectedValue;
                string stipend = StipendID.SelectedValue;
                string duration = DurationID.SelectedValue;
                string season = SeasonID.SelectedValue;
                string startDate = StartDateID.SelectedValue;
                string applicationDeadline = ApplicationDeadlineID.SelectedValue;
                string universityAffiliation = UniversityAffiliationID.SelectedValue;
                string restriction = RestrictionsID.SelectedValue;
                string state = StateID.SelectedValue;
                string city = CityID.SelectedValue;
                string county = CountyID.SelectedValue;
                string zip = ZipID.Text;
                var programNameParam = new SqlParameter("Name", System.Data.SqlDbType.VarChar);
                var fieldParam = new SqlParameter("Field", System.Data.SqlDbType.VarChar);
                var gradeParam = new SqlParameter("Grade", System.Data.SqlDbType.VarChar);
                var residentialParam = new SqlParameter("Residential", System.Data.SqlDbType.VarChar);
                var costParam = new SqlParameter("Cost", System.Data.SqlDbType.VarChar);
                var stipendParam = new SqlParameter("Stipend", System.Data.SqlDbType.VarChar);
                var durationParam = new SqlParameter("Duration", System.Data.SqlDbType.VarChar);
                var seasonParam = new SqlParameter("Season", System.Data.SqlDbType.VarChar);
                var startDateParam = new SqlParameter("StartDate", System.Data.SqlDbType.DateTime);
                var applicationDeadlineParam = new SqlParameter("ApplicationDeadline", System.Data.SqlDbType.DateTime);
                var universityAffiliationParam = new SqlParameter("UniversityAffiliation", System.Data.SqlDbType.VarChar);
                //var restrictionParam = new SqlParameter("AdditionalRestriction", System.Data.SqlDbType.VarChar);
                var stateParam = new SqlParameter("State", System.Data.SqlDbType.VarChar);
                var cityParam = new SqlParameter("City", System.Data.SqlDbType.VarChar);
                var countyParam = new SqlParameter("County", System.Data.SqlDbType.VarChar);
                var zipParam = new SqlParameter("Zip", System.Data.SqlDbType.VarChar);
                programNameParam.Value = programName;
                fieldParam.Value = field;
                gradeParam.Value = grade;
                residentialParam.Value = residential;
                costParam.Value = cost;
                stipendParam.Value = stipend;
                durationParam.Value = duration;
                seasonParam.Value = season;
                startDateParam.Value = startDate;
                applicationDeadlineParam.Value = applicationDeadline;
                universityAffiliationParam.Value = universityAffiliation;
                stateParam.Value = state;
                cityParam.Value = city;
                countyParam.Value = county;
                var approved = "yes";
                SqlParameter[] parameters = { programNameParam, fieldParam, gradeParam, residentialParam, costParam, stipendParam, durationParam, seasonParam, startDateParam, applicationDeadlineParam, universityAffiliationParam }; /*restrictionParam, stateParam, cityParam, countyParam, zipParam };*/
                String[] inputSelectionData = { programName, field, grade, residential, cost, stipend, duration, season, startDate, applicationDeadline, universityAffiliation }; /*restriction, state, city, county, zip };*/
                String[] sqlStatement = { "Name LIKE @Name", "FieldName = @Field", "GradeLevel = @Grade", "ResidentialType = @Residential", "CostAmount = @Cost", "Participants = @Stipend", "Length = @Duration", "SeasonName = @Season", "StartDate = @StartDate", "ApplicationDeadline = @ApplicationDeadline", "Institution = @UniversityAffiliation" }; /*"AdditionalRestriction = @AdditionalRestriction", "AddressZipcode = @Zip"};*/
                String[] sqlStatement2 = { "Name LIKE '"+ programName+"'", "FieldName ='"+ field + "'", "GradeLevel ='" + grade + "'", "ResidentialType ='" + residential + "'", "CostAmount ='" + cost + "'", "Participants ='" + stipend + "'", "Length ='" + duration + "'", "SeasonName ='" + season + "'", "StartDate ='" + startDate + "'", "ApplicationDeadline ='" + applicationDeadline + "'", "Institution ='" + universityAffiliation + "'" }; /*"AdditionalRestriction = @AdditionalRestriction", "AddressZipcode = @Zip"};*/

                List<String> sqlStatementList = new List<string>();
                String sqlParsed = null;

                for (int i = 0; i < inputSelectionData.Length; i++)
                {
                    if (inputSelectionData[i] != "" && inputSelectionData[i] != "Any")
                    {
                        sqlStatementList.Add(sqlStatement2[i]);
                        //parameters[i].Value = inputSelectionData[i];
                    }
                }
                for (int i = 0; i < sqlStatementList.Count; i++)
                {
                    if (i == sqlStatementList.Count - 1)
                    {
                        sqlParsed = sqlParsed + sqlStatementList[i] + " AND Approved = '"+ approved + "'";
                    }
                    else
                    {
                        sqlParsed = sqlParsed + sqlStatementList[i] + " AND ";
                    }
                }
                string sql = "SELECT * FROM ProgramsView WHERE " + sqlParsed;
                if (sqlParsed == null)
                {
                    sql = "SELECT * FROM ProgramsView WHERE Approved = '"+ approved + "'";
                }
                //string cs = WebConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
                // Name = @Name AND FieldName = @Field AND GradeLevel = @Grade AND ResidentialType = @Residential AND CostAmount = @Cost AND Participants = @Stipend AND Length = @Duration AND SeasonName = @Season AND StartDate = @StartDate AND ApplicationDeadline = @ApplicationDeadline";// AND AdditionalRestriction = @Restriction";
                //SqlConnection con = new SqlConnection(cs);
                //SqlCommand cmd = new SqlCommand(sql, con);


                
                    List<String> outputList = new List<string>();
                    //List<Int32> outputIntList = new List<Int32>();
                    
                    //cmd.Parameters.Add(programNameParam);
                    //cmd.Parameters.Add(fieldParam);
                    //cmd.Parameters.Add(gradeParam);
                    //cmd.Parameters.Add(residentialParam);
                    //cmd.Parameters.Add(costParam);
                    //cmd.Parameters.Add(stipendParam);
                    //cmd.Parameters.Add(durationParam);
                    //cmd.Parameters.Add(seasonParam);
                    //cmd.Parameters.Add(startDateParam);
                    //cmd.Parameters.Add(applicationDeadlineParam);
                    //cmd.Parameters.Add(universityAffiliationParam);
                    //cmd.Parameters.Add(restrictionParam);
                    //cmd.Parameters.Add(stateParam);
                    //cmd.Parameters.Add(cityParam);
                    //cmd.Parameters.Add(countyParam);
                    //con.Open();
                    //SqlDataReader reader = cmd.ExecuteReader();
                    PopulateGridView(sql);






                    //while (reader.Read())
                    //{

                    //    outputList.Add(reader["Name"].ToString());
                    //    outputList.Add(reader["StartDate"].ToString());
                    //    outputList.Add(reader["ApplicationDeadline"].ToString());
                    //    outputList.Add(reader["Affiliation"].ToString());
                    //    outputList.Add(reader["AdditionalRestriction"].ToString());
                    //    outputList.Add(reader["AddressLine1"].ToString());
                    //    outputList.Add(reader["AddressLine2"].ToString());
                    //    outputList.Add(reader["AddressZipcode"].ToString());
                    //    outputList.Add(reader["Website"].ToString());
                    //    outputList.Add(reader["Description"].ToString());
                    //    outputList.Add(reader["CostAmount"].ToString());
                    //    outputList.Add(reader["FieldName"].ToString());
                    //    outputList.Add(reader["Length"].ToString());
                    //    outputList.Add(reader["GradeLevel"].ToString());
                    //    outputList.Add(reader["ResidentialType"].ToString());
                    //    outputList.Add(reader["SeasonName"].ToString());
                    //    outputList.Add(reader["ServiceArea"].ToString());
                    //    outputList.Add(reader["Participants"].ToString());
                    //    outputList.Add(reader["STATE_NAME"].ToString());


                    //}
                    //reader.Close();
                    //for (int i = 0; i < outputList.Count; i++)
                    //{
                    //    Label1.Text += outputList[i] + "<br>" + "      .";
                    //}
                    //Label1.Text = sql;
                
            }//End if valid


        }








    }// End search
}