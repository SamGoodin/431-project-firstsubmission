<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="spreadsheetDownload.aspx.cs" Inherits="CourseProject.spreadsheetDownload" %>
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
		<title>Download Spreadsheet Page</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1" />
		<link rel="stylesheet" href="assets/css/main.css" />
	</head>
	<body>

        <!-- Using WebFrame.ascx -->
        <general:Frame ID="spreadFrame" runat="server" />



        <!-- DOWNLOAD EXCEL SPREADSHEET BUTTON -->
            <!-- PAGE CONTENT -->
            <section class="wrapper">
                <div class="inner">
            <div class="box">
            <div class="content">
                <h3 class="align-center">Download Excel Spreadsheet</h3>
                <hr />


                <form id="FormSpreadDownload" runat="server">

                     <asp:Button ID="download" runat="server" OnClick="Download_Click" Text="Export to Excel" />
                     <asp:Panel id="pnlDownload" runat="server">
                    
                     <asp:HyperLink ID="HyperLink" runat="server">HyperLink</asp:HyperLink>
                    </asp:Panel>
            </form>
            
             </div>
             </div>
             </div>
          </section>

        <!-- END OF DOWNLOAD EXCEL SPREADSHEET BUTTON -->

    <!-- Using WebFooter.ascx -->
    <general:Footer ID="spreadFooter" runat="server" />

		<!-- Scripts -->
			<script src="assets/js/jquery.min.js"></script>
			<script src="assets/js/jquery.scrolly.min.js"></script>
			<script src="assets/js/jquery.scrollex.min.js"></script>
			<script src="assets/js/skel.min.js"></script>
			<script src="assets/js/util.js"></script>
			<script src="assets/js/main.js"></script>

	</body>
</html>