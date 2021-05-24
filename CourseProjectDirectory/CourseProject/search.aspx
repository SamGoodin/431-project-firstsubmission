<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="CourseProject.search" %>

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
	<title>Register Page</title>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<link rel="stylesheet" href="assets/css/main.css" />
</head>
<body>


	<!-- Using WebFrame.ascx -->
	<general:Frame ID="idFrame" runat="server" />


	<!-- PAGE CONTENT -->
	<section class="wrapper">
		<div class="inner">

			<div class="box">
				<div class="content">
					<h2 class="align-center">Search</h2>
					<h4 class="align-center">Select options from any of the boxes below <a style="color: #ff9900;"</a></h4>
					
					<hr />

					<form method="post" runat="server">

						<div class="first field half">
							<asp:TextBox ID="ProgramNameID" name="ProgramName" placeholder="Program Name" runat="server"></asp:TextBox>
			        	</div>
						<%-- field --%>

						<div class="first field half">
                            <asp:label Text="Field" runat="server"></asp:label>
                            <asp:SqlDataSource ID="fieldDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select FieldName from FIELD where Active='yes'">
                            </asp:SqlDataSource>
                            <asp:DropDownList  ID="FieldID" AppendDataBoundItems="true" AutoPostBack="true" runat="server" DataSourceID="fieldDataSource" DataTextField="FieldName"></asp:DropDownList>
                   
                            
							<%--<input type="text" id="firstnameID" name="firstname" placeholder="First Name" runat="server">--%>
    					</div>

						<div class="field half">
                            <asp:label Text="Grade" runat="server"></asp:label>
                            <asp:SqlDataSource ID="gradeDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select GradeLevel from GRADE where Active='yes'">
                            </asp:SqlDataSource>
                            <asp:DropDownList ID="GradeID" AppendDataBoundItems="true" name="Grade" placeholder="Eligible Grades" runat="server" DataSourceID="gradeDataSource" DataTextField="GradeLevel"></asp:DropDownList>
    					</div>

						<div class="first field half">
                            <asp:label Text="Residential" runat="server"></asp:label>
                            <asp:SqlDataSource ID="residentialDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select ResidentialType from RESIDENTIAL where Active='yes'">
                            </asp:SqlDataSource>
							<asp:DropDownList ID="ResidentialID" AppendDataBoundItems="true" name="Residential" placeholder="Residency" runat="server" DataSourceID="residentialDataSource" DataTextField="ResidentialType"></asp:DropDownList>
						</div>

						<div class="field half">
                            <asp:label Text="Cost" runat="server"></asp:label>
                            <asp:SqlDataSource ID="costDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select CostAmount from COST where Active='yes'">
                            </asp:SqlDataSource>
							<asp:DropDownList ID="CostID" AppendDataBoundItems="true" name="Cost" placeholder="Cost" runat="server" DataSourceID="costDataSource" DataTextField="CostAmount"></asp:DropDownList>
						</div>

                        <div class="first field half">
                            <asp:label Text="Stipend" runat="server"></asp:label>
                            <asp:SqlDataSource ID="stipendDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select Participants from STIPEND where Active='yes'">
                            </asp:SqlDataSource>
							<asp:DropDownList ID="StipendID" AppendDataBoundItems="true" name="Stipend" placeholder="Stipend" runat="server" DataSourceID="stipendDataSource" DataTextField="Participants"></asp:DropDownList>
						</div>

                        <div class="field half">
                            <asp:label Text="Duration" runat="server"></asp:label>
                            <asp:SqlDataSource ID="durationDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select Length from DURATION where Active='yes'">
                            </asp:SqlDataSource>
							<asp:DropDownList ID="DurationID" AppendDataBoundItems="true" name="Duration" placeholder="Duration" runat="server" DataSourceID="durationDataSource" DataTextField="Length"></asp:DropDownList>
						</div>

                        <div class="first field half">
                            <asp:label Text="Season" runat="server"></asp:label>
                            <asp:SqlDataSource ID="seasonDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select SeasonName from SEASON where Active='yes'">
                            </asp:SqlDataSource>
							<asp:DropDownList ID="SeasonID" AppendDataBoundItems="true" name="Season" placeholder="Season" runat="server" DataSourceID="seasonDataSource" DataTextField="SeasonName"></asp:DropDownList>
						</div>
                        
                        <div class="field half">
                            <asp:label Text="Start Date" runat="server"></asp:label>
                            <asp:SqlDataSource ID="startDateDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select StartDate from PROGRAM where Active='yes'">
                            </asp:SqlDataSource>
							<asp:DropDownList ID="StartDateID" AppendDataBoundItems="true" name="Start Date" placeholder="Start Date" runat="server" DataSourceID="startDateDataSource" DataTextField="StartDate"></asp:DropDownList>
						</div>
                        
                        <div class="first field half">
                            <asp:label Text="Application Deadline" runat="server"></asp:label>
                            <asp:SqlDataSource ID="applicationDeadlineDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select ApplicationDeadline from PROGRAM where Active='yes'">
                            </asp:SqlDataSource>
							<asp:DropDownList ID="ApplicationDeadlineID" AppendDataBoundItems="true" name="Application Deadline" placeholder="Application Deadline" runat="server" DataSourceID="applicationDeadlineDataSource" DataTextField="ApplicationDeadline"></asp:DropDownList>
						</div>
                        
                        <!-- Don't see this table -->
                        <div class="field half">
                            <asp:label Text="University Affiliation" runat="server"></asp:label>
                            <!--
                            <asp:SqlDataSource ID="universityAffiliationDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select  from  where Active='yes'">
                            </asp:SqlDataSource>
                            DataSourceID="universityAffiliationDataSource" DataTextField="ResidentialType">
                            -->
							<asp:DropDownList ID="UniversityAffiliationID" AppendDataBoundItems="true" name="University Affiliation" placeholder="University Affiliation" runat="server"></asp:DropDownList>
						</div>

                        <div class="first field half">
                            <asp:label Text="Restrictions" runat="server"></asp:label>
                            <asp:SqlDataSource ID="restrictionDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select AdditionalRestriction from PROGRAM where Active='yes'">
                            </asp:SqlDataSource>
							<asp:DropDownList ID="RestrictionsID" AppendDataBoundItems="true" name="Restrictions" placeholder="Restrictions" runat="server" DataSourceID="restrictionDataSource" DataTextField="AdditionalRestriction"></asp:DropDownList>
						</div>

                        <div class="field half">
                            <asp:label Text="State" runat="server"></asp:label>
                            <asp:SqlDataSource ID="stateDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select STATE_NAME from US_STATE">
                            </asp:SqlDataSource>
							<asp:DropDownList ID="StateID" AppendDataBoundItems="true" name="State" placeholder="State" runat="server" DataSourceID="stateDataSource" DataTextField="STATE_NAME"></asp:DropDownList>
						</div>

                        <div class="first field half">
                            <asp:label Text="City" runat="server"></asp:label>
                            <asp:SqlDataSource ID="cityDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select CITY from US_CITY">
                            </asp:SqlDataSource>
							<asp:DropDownList ID="CityID" AppendDataBoundItems="true" name="City" placeholder="City" runat="server" DataSourceID="cityDataSource" DataTextField="CITY"></asp:DropDownList>
						</div>

                        <div class="field half">
                            <asp:label Text="County" runat="server"></asp:label>
                            <asp:SqlDataSource ID="countyDataSource" runat="server" ConnectionString ="<%$ ConnectionStrings:localConnection%>" SelectCommand="select COUNTY from US_CITY">
                            </asp:SqlDataSource>
							<asp:DropDownList ID="CountyID" AppendDataBoundItems="true" name="County" placeholder="County" runat="server" DataSourceID="countyDataSource" DataTextField="COUNTY"></asp:DropDownList>
						</div>
                        <div class="first field half">
							<asp:TextBox ID="ZipID" name="ZipID" placeholder="Zipcode" runat="server"></asp:TextBox>
			        	</div>
						<ul class="actions align-center">
							<li>
								<asp:Button ID="BtnSubmitUser" class="button special" runat="server" Text="Search"  OnClick="Submit_Click1" />
								<%--<input value="Register" class="button special" type="submit">--%></li>
						</ul>
                        <div id ="lastlabel" runat="server">
						<asp:Label ID="Label1" runat="server" ></asp:Label>
                        </div>

						<asp:Panel ID="pnSearchedPrograms">
                            <%-- List of Managers to be Activated/Inactivated --%>
                            <div>
                                <h2>Search Results</h2>
                               <asp:GridView
                                    ID="gvManagersToBeManagedActivate" 
                                    runat="server" 
                                    AutoGenerateColumns="false" 
                                    ShowFooter="False" 
                                    ShowHeaderWhenEmpty="True" 
                                     
                                   
                                    >
                                    <Columns>
                                        <asp:TemplateField  HeaderText="Program Name">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Name") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Start Date">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("StartDate") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                         </asp:TemplateField>
                                         <asp:TemplateField  HeaderText="Cost">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("CostAmount") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Website">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Website") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Duration">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Length") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                         </asp:TemplateField>
                                         <asp:TemplateField  HeaderText="Grade Level">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("GradeLevel") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>       
                                        <asp:TemplateField  HeaderText="Housing">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("ResidentialType") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Season">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("SeasonName") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                         </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>               
                        
                        <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>            


						</asp:Panel>





					</form>
				</div>
			</div>
		</div>
	</section>

	<!-- Using WebFooter.ascx -->
	<general:Footer ID="idFoot" runat="server" />

	<!-- Scripts -->
	<script src="assets/js/jquery.min.js"></script>
	<script src="assets/js/jquery.scrolly.min.js"></script>
	<script src="assets/js/jquery.scrollex.min.js"></script>
	<script src="assets/js/skel.min.js"></script>
	<script src="assets/js/util.js"></script>
	<script src="assets/js/main.js"></script>

</body>
</html>
