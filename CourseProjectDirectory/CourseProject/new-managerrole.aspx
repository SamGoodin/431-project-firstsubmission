<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new-managerrole.aspx.cs" Inherits="CourseProject.new_managerrole" %>
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
    <title>Add New Manager Role</title>
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
                        <h4 class="align-center">Back to Program Maintenance? <a style="color: #ff9900;" href="program-maintenance.aspx"> Here.</a></h4>
                        <h1 class="align-center">Add a New Manager Role</h1>
                        <hr />

                        <form action="#" method="post" runat="server">
                            <%-- add new manager role for project --%>
                            <div class="first field half">
                                <input type="text" id="programNewManagerRoleID" name="programNewManagerRoleID" placeholder="New Manager Role" runat="server">
                            </div>
                            <div class="first field half">
                                <input value="Add" class="button special" type="submit">
                            </div>
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



