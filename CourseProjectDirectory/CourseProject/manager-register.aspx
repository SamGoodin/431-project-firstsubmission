<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manager-register.aspx.cs" Inherits="CourseProject.manager_register" %>

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
    <title>Manager Register Page</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="assets/css/main.css" />
</head>
<body>

    <!-- Using WebFrame.ascx -->
    <general:Frame ID="managerregisterFrame" runat="server" />

    <!-- PAGE CONTENT -->
    <section class="wrapper">
        <div class="inner">
            <div class="box">
                <div class="content">
                    <h2 class="align-center">Program Manager Register</h2>
                    <h4 class="align-center">Already have an Account? <a style="color: #ff9900;" href="login.aspx">Sign In Here.</a></h4>
                    <h4 class="align-center">Are you a Normal User? <a style="color: #ff9900;" href="register.aspx">Create an Account Here.</a></h4>
                    <hr />
                    <asp:Label ID="Label1" ForeColor="Red" runat="server" ></asp:Label>
                    <form method="post" runat="server">


                        <%-- first name --%>
                        <div class="first field half">
                            <asp:TextBox ID="firstnameID"  placeholder="First Name" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" CssClass="errorcss" ID="firstnameValidateID" ControlToValidate="firstnameID" ErrorMessage="First Name is required" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        

                        <%-- last name --%>
                        <div class="field half">
                            <asp:TextBox ID="lastnameID"  placeholder="Last Name" runat="server"></asp:TextBox>
                            <%--<input type="text" id="lastnameID" name="lastname" placeholder="Last Name" runat="server">--%>
                            <asp:RequiredFieldValidator runat="server" CssClass="errorcss" ID="lastnameValidateID" ControlToValidate="lastnameID" ErrorMessage="Last Name is required" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>


                        <%-- email --%>
                        <div class="first field half">
                            <asp:TextBox ID="emailID" name="email" placeholder="Email Address" runat="server" ></asp:TextBox>
                            <%--<input type="email" id="emailID" name="email" placeholder="Email Address" runat="server">--%>
                            <asp:RequiredFieldValidator runat="server" CssClass="errorcss" ID="emailValidateID" ControlToValidate="emailID" ErrorMessage="Email is required" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" CssClass="errorcss" ID="emailValidateExprID" ControlToValidate="emailID" ValidationExpression=".*@.{2,}\..{2,}"
                                ErrorMessage="E-mail is not in a valid format" Display="dynamic">
    				        </asp:RegularExpressionValidator>
                        </div>

                        <%-- confirm email --%>
                        <div class="field half">
                            <asp:TextBox ID="emailconfirmID" name="email" placeholder="Confirm Email Address" runat="server" ></asp:TextBox>
                            <%--<input type="email" id="emailconfirmID" placeholder="Confirm Email Address" runat="server">--%>
                            <asp:RequiredFieldValidator runat="server" CssClass="errorcss" ID="emailconfirmValidateID" ControlToValidate="emailconfirmID" ErrorMessage="Confirm email is required" Display="Dynamic"></asp:RequiredFieldValidator>
                            <%-- using CompareValidator to compare email--%>
                            <asp:CompareValidator runat="server" CssClass="errorcss" ID="emailconfirmValidateCompareID" ControlToValidate="emailconfirmID" ControlToCompare="emailID" Type="String" ErrorMessage="Emails don't match" Display="Dynamic">
    			        </asp:CompareValidator>
                        </div>

                        <%-- password --%>
                        <div class="first field half">
                            <asp:TextBox ID="passwordID" TextMode="Password" runat="server"  placeholder="Password"></asp:TextBox>
                            <%--<input type="password" id="passwordID" placeholder="Password" runat="server">--%>
                            <asp:RequiredFieldValidator runat="server" CssClass="errorcss" ID="passValidateID" ControlToValidate="passwordID" ErrorMessage="Password is required" Display="Dynamic"></asp:RequiredFieldValidator>
                            <%-- using validationexpression to choose the right validation instructions for passwords--%>
                            <asp:RegularExpressionValidator ID="passValidateExprID" CssClass="errorcss" Display="Dynamic" ErrorMessage="Password must be at least 10 characters long with at least one number." ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{10,50})$" ControlToValidate="passwordID" runat="server">
                                </asp:RegularExpressionValidator>
                        </div>

                        <%-- confirm password --%>
                        <div class="field half">
                            <asp:TextBox ID="confirmpasswordID" TextMode="Password" runat="server"  placeholder="Confirm Password"></asp:TextBox>
                            <%--<input type="password" id="confirmpasswordID" placeholder="Confirm Password" runat="server">--%>
                            <asp:RequiredFieldValidator runat="server" CssClass="errorcss" ID="confirmpasswordValidateID" ControlToValidate="confirmpasswordID" ErrorMessage="Confirm password is required" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator runat="server" CssClass="errorcss" ID="confirmPasswordCompareID" ControlToValidate="confirmpasswordID" ControlToCompare="passwordID" Type="String" ErrorMessage="Passwords don't match" Display="Dynamic"> 
    			        </asp:CompareValidator>
                        </div>

                        <%-- phone number --%>
                        <div class="first field half">
                            <asp:TextBox ID="phoneID" placeholder="Phone Number" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="phoneExpValidID" runat="server" Display="Dynamic" ErrorMessage="Enter a valid Phone number" ControlToValidate="phoneID" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$"></asp:RegularExpressionValidator>
                        </div>

                        <%-- notification email --%>
                        <div class="field half">
							<asp:TextBox ID="emailNotificationID" name="email" placeholder="Notification Email Address" runat="server" ></asp:TextBox>
                            <%-- <input type="email" id="emailNotificationID" name="email" placeholder="Notification Email Address" runat="server">--%>
                            <asp:RequiredFieldValidator runat="server" CssClass="errorcss" ID="RequiredFieldValidator1" ControlToValidate="emailNotificationID" ErrorMessage="Notificationn Email is required" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" CssClass="errorcss" ID="RegularExpressionValidator1" ControlToValidate="emailNotificationID" ValidationExpression=".*@.{2,}\..{2,}"
                                ErrorMessage="E-mail is not in a valid format" Display="dynamic">
    				        </asp:RegularExpressionValidator>
                        </div>

                       
                        <ul class="actions align-center">
                            <li>
                                <asp:Button ID="BtnSubmitProgramManager" class="button special" runat="server" Text="Register" OnClick="Submit_Click1" /></li>
                        </ul>

                        

                    </form>
                </div>
            </div>
        </div>
    </section>

    <!-- Using WebFooter.ascx -->
    <general:Footer ID="managerregisterFooter" runat="server" />

    <!-- Scripts -->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/jquery.scrolly.min.js"></script>
    <script src="assets/js/jquery.scrollex.min.js"></script>
    <script src="assets/js/skel.min.js"></script>
    <script src="assets/js/util.js"></script>
    <script src="assets/js/main.js"></script>

</body>
</html>
