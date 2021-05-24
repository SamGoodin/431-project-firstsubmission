<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApplication1.Profile" %>

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
    <title>Profile Page</title>
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
                    <h2 class="align-center">Profile Page</h2>
                    <hr />

                    <form runat="server">
                        <!-- Username -->
                        <asp:Label ID="usernameLbl" runat="server" Text="Username: "></asp:Label>
                        <asp:Label ID="uname" runat="server" Text="username"></asp:Label>
                        <br />
                       
                        <!-- Prefix -->
                        <asp:Label ID="prefixLbl" runat="server" Text="Prefix: "></asp:Label>
                        <asp:Label ID="prefix" runat="server" Text="prefix"></asp:Label>
                        <asp:Button ID="changePrefix" runat="server"  Text="Change Prefix" OnClick="showPrefixChange" />
                        <!-- change -->
                        <asp:TextBox ID="newPrefix" runat="server" Visible="false"></asp:TextBox>
                        <asp:Button ID="submitPrefix" runat="server" Text="Submit" Visible="false" OnClick="submitPrefix_Click" />
                        <br />
                        <!-- First Name -->
                        <asp:Label ID="firstNameLbl" runat="server" Text="First Name: "></asp:Label>
                        <asp:Label ID="firstName" runat="server" Text="fName"></asp:Label>
                        <asp:Button ID="changeFName" runat="server" Text="Change First Name" OnClick="showFNameChange" />
                        <!-- change -->
                        <asp:TextBox ID="newFName" runat="server" Visible="false"></asp:TextBox>
                        <asp:Button ID="submitFName" runat="server" Text="Submit" Visible="false" OnClick="submitFName_Click" />
                        <br />
                        <!-- Last Name -->
                        <asp:Label ID="lastNameLbl" runat="server" Text="Last Name: "></asp:Label>
                        <asp:Label ID="lastName" runat="server" Text="lName"></asp:Label>
                        <asp:Button ID="changeLName" runat="server" Text="Change Last Name" OnClick="showLNameChange" />
                        <!-- change -->
                        <asp:TextBox ID="newLName" runat="server" Visible="false"></asp:TextBox>
                        <asp:Button ID="submitLName" runat="server" Text="Submit" Visible="false" OnClick="submitLName_Click" />
                        <br />
                        <!-- Notification Email -->
                        <asp:Label ID="notifLbl" runat="server" Text="Notification Email: "></asp:Label>
                        <asp:Label ID="notifEmail" runat="server" Text="notif"></asp:Label>
                        <asp:Button ID="changeNotif" runat="server" Text="Change Notification Email" OnClick="showNotifChange" />
                        <!-- change -->
                        <asp:TextBox ID="newNotif" runat="server" Visible="false"></asp:TextBox>
                        <asp:Button ID="submitNotif" runat="server" Text="Submit" Visible="false" OnClick="submitNotif_Click" />
                        <br />
                        <!-- Phone -->
                        <asp:Label ID="phoneLbl" runat="server" Text="Phone: "></asp:Label>
                        <asp:Label ID="phone" runat="server" Text="phone"></asp:Label>
                        <asp:Button ID="changePhone" runat="server" Text="Change Phone" OnClick="showPhoneChange" />
                        <!-- change -->
                        <asp:TextBox ID="newPhone" runat="server" Visible="false"></asp:TextBox>
                        <asp:Button ID="submitPhone" runat="server" Text="Submit" Visible="false" OnClick="submitPhone_Click" />
                        <br />
                        <!-- Register Date -->
                        <asp:Label ID="regDateLbl" runat="server" Text="Register Date: "></asp:Label>
                        <asp:Label ID="regDate" runat="server" Text="regDate"></asp:Label>
                        <br />
                        <!-- Approval Date -->
                        <asp:Label ID="approveDateLbl" runat="server" Text="Approval Date: "></asp:Label>
                        <asp:Label ID="approveDate" runat="server" Text="approveDate"></asp:Label>
                        <br />
                        
                        <asp:Button ID="btnChangePassword" class="button special" runat="server" Text="Change Password" OnClick="changePassword_Click" />
                        <br />
                        <br />
                        <asp:Panel ID="PnlManageAdmin2" runat="server">
                            <a href="review-program-managers.aspx">Review New Program Managers</a><br />
                            <a href="manage-program-managers.aspx">Manage Program Managers</a>
                        </asp:Panel>
                        <asp:Panel ID="PnlManageAdmin" runat="server">
                             <a href="manageadministrators.aspx">Manage Administrators</a>                         
                        </asp:Panel>
                        <asp:Panel ID="PnlViewPgms" runat="server">
                             <a href="view-own-programs.aspx">View Created Programs</a>                         
                        </asp:Panel>
                        <asp:Panel ID="PnlViewApprovedPgms" runat="server">
                             <a href="view-approved-programs.aspx">View All Approved Programs</a>                         
                        </asp:Panel>
                        <asp:Panel ID="PnlViewUnapprovedPgms" runat="server">
                             <a href="view-unapproved-programs.aspx">View All Unapproved Programs</a>                         
                        </asp:Panel>
                        <asp:Panel ID="PnlViewAllPgms" runat="server">
                             <a href="view-all-programs.aspx">View All Programs</a>                         
                        </asp:Panel>
                        <asp:Panel ID="PnlViewAllUsers" runat="server">
                             <a href="view-all-users.aspx">View All Users</a>                         
                        </asp:Panel>
                        <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
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
