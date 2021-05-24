<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CourseProject.Login" %>\

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
		<title>Login Page</title>
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
            <h2 class="align-center">Sign In</h2>
            <h4 class="align-center">New Here? <a style="color: #ff9900;" href="register.aspx">Create an Account.</a></h4>
            <hr />
            
            <form action="#" method="post" runat="server">
                <asp:Label ID="Label1" runat="server" Font-Size="20px" ForeColor="Black"></asp:Label>
                <asp:Label ID="LtrlResponse" runat="server"></asp:Label>
                <div class="field">
                    <asp:TextBox name="login-email" ID="emailID" runat="server" placeholder="E-mail address"></asp:TextBox>
                    <%--<input name="login-email" id="emailID" type="text" placeholder="E-mail address" runat="server">--%>
                </div>
                <div class="field">
                    <asp:TextBox name="login-password"  ID="passwordID" runat="server" type="password" placeholder="Password" ></asp:TextBox>
                    <%--<input name="login-password" id="passwordID" type="password" placeholder="Password" runat="server">--%>
                </div>

                <ul class="actions align-center">
                    <li><asp:Button ID="BtnLogIn"  runat="server"  class="button special" Text="Log In" OnClick="LogIn_Click"/></li>
							<%--<input value="Log in" class="button special" type="submit">--%>
						</ul>
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