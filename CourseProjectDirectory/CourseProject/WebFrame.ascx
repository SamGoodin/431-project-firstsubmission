<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebFrame.ascx.cs" Inherits="CourseProject.WebFrame" %>

        <!-- Header -->
            <header id="header" class="alt">
                <div class="logo"><a href="Default.aspx">K-12 STEM Outreach</a></div>
                <a href="#menu" class="toggle"><span>Menu</span></a>
            </header>

        <!-- Nav -->
            <nav id="menu">
                <ul class="links">
                    <li runat="server" id="login"><a href="login.aspx">Login</a></li>
                    <li runat="server" id="profile"><a href="Profile.aspx">Profile</a></li>
                    <li runat="server" id="registeruser"><a href="register.aspx">Register</a></li>
                    <li runat="server" id="createprogram"><a href="createprogram.aspx">Create a Program</a></li>
                    <li runat="server" id="createadmin"><a href="create-admin.aspx">Create an Admin</a></li>
                    <li runat="server" id="programmaintenance"><a href="program-maintenance.aspx">Manage Program Fields</a></li>
                    <li runat="server" id="spreadsheetDownload"><a href="spreadsheetDownload.aspx">Download Programs Spreadsheet</a></li>
                    <li runat="server" id="userDownload"><a href="userDownload.aspx">Download Users Spreadsheet</a></li>
                    <li runat="server" id="logout"><a href="logout.aspx">Logout</a></li>
                </ul>

            </nav>

        <section id="bannershort">
                <div class="inner">
                    <h1>K-12 STEM Outreach</h1>
                    <p>Welcome to our STEM Education Outreach Programs and Events Website!</p>
                </div>

         </section>