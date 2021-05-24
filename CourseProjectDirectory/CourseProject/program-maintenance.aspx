<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="program-maintenance.aspx.cs" Inherits="CourseProject.program_maintenance" %>
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
    <title>Program Maintenance</title>
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
                        <h4 class="align-center">Want to become a Program Manager? <a style="color: #ff9900;" href="manager-register.aspx">Create an Account Here.</a></h4>
                        <h1 class="align-center">Manage Program Fields</h1>
                        <hr />

                        <form action="#" method="post" runat="server">
                             <%-- add new field of study --%>
                            <div class="first field half">
                                <h4 class="align-center">Field of Study<a style="color: #ff9900;" href="new-field.aspx">  MANAGE</a></h4>
                            </div>
                            <%-- add new manager role --%>
                            <div class="field half">
                                <h4 class="align-center">Manager Role<a style="color: #ff9900;" href="new-managerrole.aspx">  MANAGE</a></h4>
                            </div>
                            <%-- add new grade --%>
                            <div class="first field half">
                                <h4 class="align-center">Grade<a style="color: #ff9900;" href="new-grade.aspx">  MANAGE</a></h4>
                            </div>
                            <%-- add new residential choice --%>
                            <div class="field half">
                                <h4 class="align-center">Residential Choice<a style="color: #ff9900;" href="new-residentialchoice.aspx">  MANAGE</a></h4>
                            </div>
                            <%-- add new cost --%>
                            <div class="first field half">
                                <h4 class="align-center">Program Cost<a style="color: #ff9900;" href="new-cost.aspx">  MANAGE</a></h4>
                            </div>
                            <%-- add new stipend --%>
                            <div class="field half">
                                <h4 class="align-center">Stipend Option<a style="color: #ff9900;" href="new-stipend.aspx">  MANAGE</a></h4>
                            </div>
                            <%-- add new duration --%>
                            <div class="first field half">
                                <h4 class="align-center">Program Duration<a style="color: #ff9900;" href="new-duration.aspx">  MANAGE</a></h4>
                            </div>
                            <%-- add new season --%>
                            <div class="field half">
                                <h4 class="align-center">Season<a style="color: #ff9900;" href="new-season.aspx">  MANAGE</a></h4>
                            </div>
                            <%-- add new service area --%>
                            <div class="first field half">
                                <h4 class="align-center">Service Area<a style="color: #ff9900;" href="new-servicearea.aspx">  MANAGE</a></h4>
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

