<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirmCreatePgm.aspx.cs" Inherits="CourseProject.confirmCreatePgm" %>
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
		<title>Create Program Confirm</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<link rel="stylesheet" href="assets/css/main.css" />
	</head>
	<body>

        <!-- Using WebFrame.ascx -->
        <general:Frame ID="loginFrame" runat="server" />

            <!-- PAGE CONTENT -->
            <section class="wrapper">
                <div class="inner">
                <div class="box">
                <div class="content">
					<h2 class="align-center">Create Program Confirm</h2>
					<hr />

					<form runat="server">
                        <asp:Label ID="pgmName" runat="server" Text="Program Name: "></asp:Label>
                        <br />
                        <asp:Label ID="pgmAbbr" runat="server" Text="Program Abbreviation: "></asp:Label>
                        <br />
                        <asp:Label ID="contactFName" runat="server" Text="Contact First Name: "></asp:Label>
                        <br />
                        <asp:Label ID="contactLName" runat="server" Text="Contact Last Name: "></asp:Label>
                        <br />
                        <asp:Label ID="contactEmail" runat="server" Text="Contact Email: "></asp:Label>
                        <br />
                        <asp:Label ID="contactPhone" runat="server" Text="Contact Phone: "></asp:Label>
                        <br />
                        <asp:Label ID="checkboxList" runat="server" Text="Checkbox List: "></asp:Label>
                        <br />
                        <asp:Label ID="grade" runat="server" Text="Grade: "></asp:Label>
                        <br />
                        <asp:Label ID="housingNeeds" runat="server" Text="Housing Needs: "></asp:Label>
                        <br />
                        <asp:Label ID="cost" runat="server" Text="Cost: "></asp:Label>
                        <br />
                        <asp:Label ID="stipend" runat="server" Text="Stipend: "></asp:Label>
                        <br />
                        <asp:Label ID="duration" runat="server" Text="Duration: "></asp:Label>
                        <br />
                        <asp:Label ID="durationNotes" runat="server" Text="Duration Notes: "></asp:Label>
                        <br />
                        <asp:Label ID="season" runat="server" Text="Season: "></asp:Label>
                        <br />
                        <asp:Label ID="startDate" runat="server" Text="Start Date: "></asp:Label>
                        <br />
                        <asp:Label ID="applicationDeadline" runat="server" Text="Application Deadline: "></asp:Label>
                        <br />
                        <asp:Label ID="eligibility" runat="server" Text="Eligibility Restrictions: "></asp:Label>
                        <br />
                        <asp:Label ID="serviceArea" runat="server" Text="Service Area: "></asp:Label>
                        <br />
                        <asp:Label ID="notesToAdmin" runat="server" Text="Notes to Admin: "></asp:Label>
                        <br />
                        <asp:Label ID="description" runat="server" Text="Description: "></asp:Label>
                        <br />
                        <asp:Label ID="address1" runat="server" Text="Address 1: "></asp:Label>
                        <br />
                        <asp:Label ID="county" runat="server" Text="County: "></asp:Label>
                        <br />
                        <asp:Label ID="address2" runat="server" Text="Address 2: "></asp:Label>
                        <br />
                        <asp:Label ID="city" runat="server" Text="City: "></asp:Label>
                        <br />
                        <asp:Label ID="state" runat="server" Text="State: "></asp:Label>
                        <br />
                        <asp:Label ID="zipcode" runat="server" Text="Zipcode: "></asp:Label>
                        <br />
                        <asp:Button class="button special" runat="server" Text="Submit" OnClick="submit_Click" />
                        <asp:Label ID="errorLbl" runat="server" ></asp:Label>

                    </form>
                 </div>
                 </div>
                </div>
          </section>

    <!-- Using WebFooter.ascx -->
    <general:Footer ID="loginFooter" runat="server" />

		<!-- Scripts -->
			<script src="assets/js/jquery.min.js"></script>
			<script src="assets/js/jquery.scrolly.min.js"></script>
			<script src="assets/js/jquery.scrollex.min.js"></script>
			<script src="assets/js/skel.min.js"></script>
			<script src="assets/js/util.js"></script>
			<script src="assets/js/main.js"></script>

	</body>
</html>