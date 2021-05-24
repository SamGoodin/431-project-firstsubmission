<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="change-password.aspx.cs" Inherits="WebApplication1.change_password" %>
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
		<title>User Profile Page</title>
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
					<h2 class="align-center">Change Password</h2>
					<hr />

					<form runat="server">
                        <asp:Label runat="server" ForeColor="Red" Text="All Fields Required"></asp:Label><br />
                        <asp:Label ID="lblCurrentPassword" runat="server" Text="Enter Current Password: "></asp:Label>
                        <asp:TextBox ID="currentPasswordID" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqrdCurrentPasswordValidator" runat="server" ControlToValidate="currentPasswordID" ForeColor="Red" ErrorMessage="*Required"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="newPassLbl" runat="server" Text="New Password: "></asp:Label>
                        <asp:TextBox ID="newPassword" TextMode="Password" runat="server"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="newPassValid" runat="server" ControlToValidate="newPassword" ForeColor="Red" ErrorMessage="*Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="passValidateExprID" CssClass="errorcss" Display="Dynamic" ErrorMessage="Password must be at least 10 characters long with at least one number." ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{10,50})$" ControlToValidate="newPassword" runat="server"></asp:RegularExpressionValidator>
                        <asp:Literal runat="server" Text="Min 10 Characters and 1 Number"></asp:Literal>
                        <br />
                        <asp:Label ID="confirmLbl" runat="server" Text="Confirm Password: "></asp:Label>
                        <asp:TextBox ID="confirmPassword" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="confirmPassValid" runat="server" ControlToValidate="confirmPassword" ForeColor="Red" ErrorMessage="*Required"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="matchingValid" runat="server" ControlToValidate="confirmPassword" OnServerValidate="match_Validate" ForeColor="Red" ErrorMessage="*Password must match"></asp:CustomValidator>
                        <br />
                        <asp:Button class="button special" runat="server" Text="Submit" OnClick="changePassword_Click" />
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