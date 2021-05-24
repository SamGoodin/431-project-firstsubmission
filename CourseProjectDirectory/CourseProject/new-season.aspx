<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new-season.aspx.cs" Inherits="CourseProject.new_season" %>
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
    <title>Add New Season</title>
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
                        <h1 class="align-center">Add a New Season Option</h1>
                        <hr />

                        <form method="post" runat="server">


                            <%-- add new field for project --%>
                            <div>
                               <asp:GridView 
                                    ID="gvCurrentSeasons" 
                                    runat="server" 
                                    AutoGenerateColumns="false" 
                                    ShowFooter="True" 
                                    ShowHeaderWhenEmpty="True" 
                                    DataKeyNames="SeasonID"
                                    OnRowCommand="GvCurrentSeasons_RowCommand" 
                                    OnRowEditing="GvCurrentSeasons_RowEditing"
                                    OnRowCancelingEdit="GvCurrentSeasons_RowCancelingEdit"
                                    OnRowUpdating="GvCurrentSeasons_RowUpdating"
                                    >
                                    <Columns>
                                        <asp:TemplateField  HeaderText="Available Seasons">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("SeasonName") %>' runat="server" />                                                
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditSeasonName" Text='<%# Eval("SeasonName") %>' runat="server" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtSeasonNameFooter" runat="server" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditSeason" runat="server" class="button special" CommandName="Edit" ToolTip="Edit" Text="Edit" />
                                                <asp:Button ID="btnInactivateSeason" runat="server" class="button special" CommandName="Inactivate"  CommandArgument='<%# Eval("SeasonID") +","+ Eval("Active") %>'  Text='<%# Eval("Active").ToString().Equals("Yes") ? " Inactivate " : " Activate " %>'  />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btnSaveSeason" runat="server" class="button special" CommandName="Update" ToolTip="Save" Text="Save" />
                                                <asp:Button ID="btnCancel" runat="server" class="button special" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="btnNewSeason" runat="server" class="button special" CommandName="AddNew" ToolTip="Add Season" Text="Add Season" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            
                           
                            <asp:Literal ID="ltrlSqlError" runat="server"></asp:Literal>
                            <br />
                            <asp:Literal ID="ltrlSqlError2" runat="server"></asp:Literal>
                        </form>
    </div>
    </div>
    </div>
    </section>

   <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField ="SeasonName" HeaderText="Seasons"  />
                                    </Columns>
                                </asp:GridView>--%>

   <%-- <asp:Label ID="Label1" runat="server" Text="List of Current Seasons:"></asp:Label>
                                <asp:DropDownList ID="DrpSq1" runat="server"></asp:DropDownList>--%>


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



