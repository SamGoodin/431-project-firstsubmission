<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createprogram.aspx.cs" Inherits="CourseProject.createprogram" MaintainScrollPositionOnPostback="true"  %>
<%@ Register TagPrefix="general" TagName="Frame" Src="WebFrame.ascx" %>
<%@ Register TagPrefix="general" TagName="Footer" Src="WebFooter.ascx" %>
<!DOCTYPE html>
<!--
	Transitive by TEMPLATED
	templated.co @templatedco
	Released for free under the Creative Commons Attribution 3.0 license (templated.co/license)
-->
<html>
<head>
    <title>Create New Program</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="assets/css/main.css" />
</head>
<body>

        <!-- Using WebFrame.ascx -->
        <general:Frame ID="createprogramFrame" runat="server" />

            <!-- PAGE CONTENT -->
            <section class="wrapper">
                <div class="inner">
                <div class="box">
                <div class="content">
                <h2 class="align-center">Create A New Program</h2>
                <h4 class="align-center">Add a program option? <a style="color: #ff9900;" href="program-maintenance.aspx">Go Here.</a></h4>
                <h4 class="align-center">Want to become a Program Manager? <a style="color: #ff9900;" href="manager-register.aspx">Create an Account Here.</a></h4>
                <hr />
                <asp:Panel ID="formPanel" runat="server" Visible="true">
                <form  method="post" runat="server">

                    <asp:ScriptManager ID="ScriptManager1" runat="server" />


                    

                    <%-- program name --%>
                    <div class="first field half">
                        <label for="name">Program Name</label>
                        <asp:TextBox ID="programNameID" placeholder="Enter Program Name" runat="server"></asp:TextBox>
                        <%--<input type="text" id="programName" name="programName" placeholder="Enter Program Name" runat="server">--%>
                        <asp:RequiredFieldValidator runat="server" CssClass="errorcss" ID="programNameValidateID" ControlToValidate="programNameID" ErrorMessage="Program Name is required" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>


                    <%-- Program Abbreviation or Acronym --%>
                    <div class="field half">
                        <label for="name">Program Abbreviation</label>
                        <asp:TextBox ID="programAbbreviationID" placeholder="Enter Program Abbreviation or Acronym" runat="server"></asp:TextBox>
                        <%--<input type="text" id="programAbbreviationID" name="programAbbreviation" placeholder="Program Abbreviation or Acronym" runat="server">--%>
                        <asp:RequiredFieldValidator runat="server" CssClass="errorcss" ID="programAbbreviationValidateID" ControlToValidate="programAbbreviationID" ErrorMessage="Program Abbreviation is required" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>


                    <%-- Program Contact First Name --%>
                    <div class="first field half">
                        <label for="name">Program Contact First Name</label>
                        <asp:TextBox ID="pgmFirstNameID" placeholder="Program Contact First Name" runat="server"></asp:TextBox>
                        <%--<input type="text" id="programContactNameID" name="programContactNameID" placeholder="Program Main Contact Name" runat="server">--%>
                        <asp:RequiredFieldValidator runat="server" CssClass="errorcss" ID="pgmFirstNameValidate" ControlToValidate="pgmFirstNameID" ErrorMessage="Project Contact is required" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <%-- Program Contact Last Name --%>
                    <div class="second field half">
                        <label for="name">Program Contact Last Name</label>
                        <asp:TextBox ID="pgmLastNameID" placeholder="Program Contact Last Name" runat="server"></asp:TextBox>
                        <%--<input type="text" id="programContactNameID" name="programContactNameID" placeholder="Program Main Contact Name" runat="server">--%>
                        <asp:RequiredFieldValidator runat="server" CssClass="errorcss" ID="pgmLastNameValidate" ControlToValidate="pgmLastNameID" ErrorMessage="Project Contact is required" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>

                    <%-- Program Contact Email --%>
                    <div class="first field half">
                        <label for="name">Program Contact Email</label>
                        <asp:TextBox ID="programContactEmailID"  placeholder="Program Contact Email Address" runat="server" ></asp:TextBox>
                        <%--<input type="email" id="programContactEmailID" placeholder="Program Contact Email Address" runat="server">--%>
                        <asp:RequiredFieldValidator runat="server" CssClass="errorcss" ID="programContactEmailValidateID" ControlToValidate="programContactEmailID" ErrorMessage="Email is required" Display="Dynamic"></asp:RequiredFieldValidator>
                        <%-- using RegularExpressionValidator for email--%>
                        <asp:RegularExpressionValidator runat="server" CssClass="errorcss" ID="programContactEmailValidateExprID" ControlToValidate="programContactEmailID" ValidationExpression=".*@.{2,}\..{2,}" ErrorMessage="E-mail is not in a valid format" Display="dynamic">
                        </asp:RegularExpressionValidator>
                    </div>

                    <%-- Program Contact Phone --%>
                    <div class="second field half">
                        <label for="name">Program Contact Phone Number</label>
                        <asp:TextBox ID="programContactPhoneID" placeholder="Program Contact Phone Number" runat="server"></asp:TextBox>
                        <%--<asp:TextBox id="programContactPhoneID" placeholder="Program Contact Phone Number" runat="server"></asp:TextBox>--%>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ErrorMessage="Enter a valid Phone number" ControlToValidate="programContactPhoneID" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"></asp:RegularExpressionValidator>
                    </div>


                    <%-- Program Fields of Study --%>
                    <div class="field checkboxfield">
                        <p>Which fields of study does the program include?</p>
                        <asp:SqlDataSource ID="fieldDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select FieldName from FIELD where Active='yes'">
                        </asp:SqlDataSource>
                        <asp:CheckBoxList  ID="CheckboxList1" RepeatColumns="2" AutoPostBack="true" OnSelectedIndexChanged="FieldsOfStudy_ServerChange" runat="server" DataSourceID="fieldDataSource" DataTextField="FieldName"></asp:CheckBoxList>
                    </div>
                   <!-- Other Fields -->
                    <asp:Panel ID="otherFieldsPanelID" runat="server" Visible="false">
                        <%-- OTHER - Program Fields of Study --%>
                        <div class="field">
                            <asp:TextBox ID="otherFieldID" placeholder="Please Describe Other Field of Study" runat="server"></asp:TextBox>
                        </div>
                    </asp:Panel>   
                    

                     <%-- Eligible grades --%>
                    <div class="field checkboxfield">
                        <p>Eligible grades that students must have completed or currently enrolled to participate.</p>
                        <asp:SqlDataSource ID="gradeDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select GradeLevel from GRADE where Active='yes'">
                        </asp:SqlDataSource>
                        <asp:RadioButtonList ID="gradeRadioButtonListID" runat="server" DataSourceID="gradeDataSource" DataTextField="GradeLevel">
                        </asp:RadioButtonList>
                    </div>


                    <%-- Housing Needs--%>
                    <div class="first field half">
                        <p>Is the program a residential program requiring students to stay overnight, or does the program provide housing if needed?</p>
                        <asp:SqlDataSource ID="housingNeedsDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select ResidentialType from RESIDENTIAL where Active='yes'">
                        </asp:SqlDataSource>
                        <asp:DropDownList ID="programHousingNeedsID" runat="server" DataSourceID="housingNeedsDataSource" DataTextField="ResidentialType"  >
                        </asp:DropDownList>
                    </div>                                                                                                                                        
                   
                    
                    <!-- Other Residence Field -->
                    <%--<asp:Panel ID="residencePanelID" runat="server" Visible="false">
                        <div class="field">
                            <asp:TextBox ID="ResidenceID" placeholder="What are the eligibility requirements to live on-site?" runat="server"></asp:TextBox>
                        </div>
                    </asp:Panel>  --%> 

                    <%-- Cost of Program--%>
                    <div class="field half">
                        <label>Cost of Program</label>
                        <asp:SqlDataSource ID="programCostDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select CostAmount from COST where Active='yes'">
                        </asp:SqlDataSource>
                        <asp:DropDownList ID="programCostID" runat="server" DataSourceID="programCostDataSource" DataTextField="CostAmount">
                        </asp:DropDownList>
                    </div>

                    <%-- Program Stipend--%>
                    <div class="first field half">
                        <label>Program Stipend</label>
                        <asp:SqlDataSource ID="programStipendDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select Participants from STIPEND where Active='yes'">
                        </asp:SqlDataSource>
                        <asp:DropDownList ID="programStipendID" runat="server" DataSourceID="programStipendDataSource" DataTextField="Participants">
                        </asp:DropDownList>
                    </div>

                    <!-- Other Residence Field -->
                    <%--<asp:Panel ID="programCostPanelOneID" runat="server" Visible="false">
                        <div class="field">
                            <asp:TextBox ID="CostPlusAllID" placeholder="How much is the stipend?" runat="server"></asp:TextBox>
                        </div>
                    </asp:Panel>   
                    <!-- Other Residence Field -->
                    <asp:Panel ID="programCostPanelTwoID" runat="server" Visible="false">
                        <div class="field">
                            <asp:TextBox ID="CostPlusSomeOneID" placeholder="How much is the stipend?" runat="server"></asp:TextBox>
                            <asp:TextBox ID="CostPlusSomeTwoID" placeholder="Describe the eligibility criteria for students to receive a stipend" runat="server"></asp:TextBox>
                        </div>
                    </asp:Panel>   
                    <!-- Other Residence Field -->
                    <asp:Panel ID="programCostPanelThreeID" runat="server" Visible="false">
                        <div class="field">
                            <asp:TextBox ID="CostForAllID" placeholder="How much does it cost for students to participate in this program?" runat="server"></asp:TextBox>
                        </div>
                    </asp:Panel>  
                    <!-- Other Residence Field -->
                    <asp:Panel ID="programCostPanelFourID" runat="server" Visible="false">
                        <div class="field">
                            <asp:TextBox ID="CostDeterminedID" placeholder="Explain if cost can be free or reduced to a specific amount and explain the eligibility for cost reduction and if any documentation is necessary." runat="server"></asp:TextBox>
                        </div>
                    </asp:Panel> --%>  

                    <%-- Program Duration --%>
                    <div class="second field half">
                        <label>Program Duration</label>
                        <asp:SqlDataSource ID="programDurationDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select Length from DURATION where Active='yes'">
                        </asp:SqlDataSource>
                        <asp:DropDownList ID="programDurationID" runat="server" DataSourceID="programDurationDataSource" DataTextField="Length">
                        </asp:DropDownList>
                    </div>

                    <%-- Program Duration Additional Notes--%>
                    <div class="first field half">
                        <label>Program Duration Additional Notes</label>
                        <asp:TextBox ID="programDurationAdditionalNotesID" placeholder="Program Duration Additional Notes" runat="server"></asp:TextBox>
                    </div>

                     <%-- Program Season --%>
                    <div class="second field half">
                        <label>Season</label>
                        <asp:SqlDataSource ID="programSeasonDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select SeasonName from SEASON where Active='yes'">
                        </asp:SqlDataSource>
                        <asp:DropDownList ID="programSeasonID" runat="server" DataSourceID="programSeasonDataSource" DataTextField="SeasonName">
                        </asp:DropDownList>
                    </div>

                    <%-- Program Start Date --%>
                    <div class="first field half">
                        <label>Start Date</label>
                        <asp:TextBox ID="programStartDateID" placeholder="Start Date:DD/MM/YYYY" runat="server"></asp:TextBox>
                    </div>
                    <%-- Application Deadline --%>
                    <div class="second field half">
                        <label>Application Deadline</label>
                        <asp:TextBox ID="programApplicationDeadlineID" placeholder="Application Deadline:DD/MM/YYYY" runat="server"></asp:TextBox>
                    </div>


                    <%-- Program Affiliations --%>
                    <div class="field">
                        <p>Is the program affiliated with a college or university?</p>
                        <asp:RadioButton id="RadioAffilNoID" Text="No" Checked="True" GroupName="RadioGroup1" runat="server" OnCheckedChanged="RadioAffil_checkedChanged" AutoPostBack="true"/><br />
                        <asp:RadioButton id="RadioAffilYesID" Text="Yes" Checked="False" GroupName="RadioGroup1" runat="server" OnCheckedChanged="RadioAffil_checkedChanged" AutoPostBack="true" /><br />
                    </div>

                    <asp:Panel ID="affilPanelID" runat="server" Visible="false">
                       <div class="field">
                        <asp:DropDownList ID="DDlistAffilID" runat="server" >
                            <asp:ListItem Value="Indiana University - Bloomington">Indiana University - Bloomington</asp:ListItem>
                            <asp:ListItem Value="Indiana University School of Medicine">Indiana University School of Medicine</asp:ListItem>
                            <asp:ListItem Value="Indiana University School of Dentistry">Indiana University School of Dentistry</asp:ListItem>
                            <asp:ListItem Value="IUPUI - All Campus Schools">IUPUI - All Campus Schools</asp:ListItem>
                            <asp:ListItem Value="IUPUI - School of Science">IUPUI - School of Science</asp:ListItem>
                            <asp:ListItem Value="IUPUI - School of Engineering & Technology">IUPUI - School of Engineering & Technology</asp:ListItem>
                            <asp:ListItem Value="IUPUI - School of Informatics & Computing">IUPUI - School of Informatics & Computing</asp:ListItem>
                            <asp:ListItem Value="IUPUI - School of Health & Human Sciences">IUPUI - School of Health & Human Sciences</asp:ListItem>
                            <asp:ListItem Value="Anderson University">Anderson University</asp:ListItem>
                            <asp:ListItem Value="Ball State University">Ball State University</asp:ListItem>
                            <asp:ListItem Value="DePauw University">DePauw University</asp:ListItem>
                            <asp:ListItem Value="Indiana State University">Indiana State University</asp:ListItem>
                            <asp:ListItem Value="Marian University">Marian University</asp:ListItem>
                            <asp:ListItem Value="Purdue University">Purdue University</asp:ListItem>
                            <asp:ListItem Value="Taylor University">Taylor University</asp:ListItem>
                            <asp:ListItem Value="University of Evansville">University of Evansville</asp:ListItem>
                            <asp:ListItem Value="University of Indianapolis">University of Indianapolis</asp:ListItem>
                            <asp:ListItem Value="University of Notre Dame">University of Notre Dame</asp:ListItem>
                            <asp:ListItem Value="University of Southern Indiana">University of Southern Indiana</asp:ListItem>
                            <asp:ListItem Value="Earlham College">Earlham College</asp:ListItem>
                            <asp:ListItem Value="Franklin College">Franklin College</asp:ListItem>
                            <asp:ListItem Value="Hanover College">Hanover College</asp:ListItem>
                            <asp:ListItem Value="Ivy Tech Community College">Ivy Tech Community College</asp:ListItem>
                            <asp:ListItem Value="Wabash College">Wabash College</asp:ListItem>
                            <asp:ListItem Value="Rose-Hulman Institute of Technology">Rose-Hulman Institute of Technology</asp:ListItem>
                            <asp:ListItem Value="OtherAffil">Other</asp:ListItem>
                        </asp:DropDownList>
                           </div>
                    </asp:Panel>  
                        
                     

                    <%-- Eligibility Restrictions Other --%>

                    <div class="first field half">
                        <label>Eligibility Restrictions</label>
                        <asp:TextBox ID="programEligibilityRestrictionsOtherID" placeholder="Enter any unique elegibility restrictions" runat="server"></asp:TextBox>
                    </div>


                     <%-- Program Service Area --%>
                    <div class="field half">
                        <label>Service Area</label>
                        <asp:SqlDataSource ID="programServiceAreaDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select ServiceArea from SERVICEAREA where Active='yes'">
                        </asp:SqlDataSource>
                        <asp:DropDownList ID="programServiceAreaID" runat="server" DataSourceID="programServiceAreaDataSource" DataTextField="ServiceArea" AutoPostBack="true" OnSelectedIndexChanged="DDlistService_ServerChange">
                        </asp:DropDownList>
                    </div>          

                    <!-- Other Service Field -->
                    <asp:Panel ID="servicePanelID" runat="server" Visible="false">
                        <div class="field">
                            <asp:TextBox ID="serviceOtherID" placeholder="Describe service area or geographical limitations from where you want to draw candidates" runat="server"></asp:TextBox>
                        </div>
                    </asp:Panel>   

                    <%-- Program Notes to Admin --%>
                    <div class="first field half">
                        <label>Program Notes to Admin</label>
                        <asp:TextBox ID="programNotesToAdminID" placeholder="Enter any Notes to Admin" Height="125px" runat="server"></asp:TextBox>
                    </div>

                    <%-- Program Description --%>
                    <div class="field half">
                        <label>Program Description</label>
                        <asp:TextBox ID="programDescriptionID" placeholder="Enter a description of program" Height="125px" runat="server"></asp:TextBox>
                    </div>
                          
                    <%-- Program Address 1 --%>
                    <div class="first field half">
                        <label>Program Address 1</label>
                        <asp:TextBox ID="programAddress1ID" placeholder="Program Address"  runat="server"></asp:TextBox>
                    </div>

                    <%-- Program Address 2 --%>
                    <div class="second field half">
                        <label>Program Address 2</label>
                        <asp:TextBox ID="programAddress2ID" placeholder="Program Address 2"  runat="server"></asp:TextBox>
                    </div>

                                      
                    
                    <%-- Program State --%>
                    <div class="first field half">
                        <label>Program State</label>
                        <%--<asp:SqlDataSource ID="SqlDataSourceState" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select State_Name from US_STATE">
                        </asp:SqlDataSource>--%>
                        <asp:DropDownList ID="ddProgramStateID" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="DDlistState_ServerChange">
                        </asp:DropDownList>                       
                    </div>
                        <%-- Program zipcode --%>
                    <div class="second field half">
                        <label>Program Zipcode</label>
                        <asp:TextBox ID="programZipcodeID" placeholder="Zipcode"  runat="server"></asp:TextBox>
                    </div>
       
                    <ul class="actions align-center">


                     <%-- Program city --%>
                    <div class="first field half">
                        <label>Program City</label>
                        <%--<asp:SqlDataSource ID="SqlDataSourceCity" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select City from US_CITY">
                        </asp:SqlDataSource>--%>
                        <asp:DropDownList ID="programCityID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDlistCity_ServerChange"></asp:DropDownList>
                    </div>

                        <%-- Program county --%>
                    <div class="first field half">
                        <label>Program County</label>
                        <asp:DropDownList ID="ddProgramCountyID" runat="server">                            
                        </asp:DropDownList>
                    </div>          





                        <br />

                        <li>
                            <asp:Button ID="BtnSubmitProgram" class="button special" runat="server" Text="Create Program"  OnClick="Submit_Click1" />
                            <%--<input value="Create Program" class="button special" type="submit">--%>
                        </li>
                    </ul>
                    <asp:Label ID="errorLbl" runat="server" ></asp:Label>
                        
                </form>
               </asp:Panel>
            </div>
        </div>
        </div>
    </section>



    <!-- Using WebFooter.ascx -->
    <general:Footer ID="createprogramFooter" runat="server" />

    <!-- Scripts -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/jquery.scrolly.min.js"></script>
    <script src="assets/js/jquery.scrollex.min.js"></script>
    <script src="assets/js/skel.min.js"></script>
    <script src="assets/js/util.js"></script>
    <script src="assets/js/main.js"></script>

</body>
</html>