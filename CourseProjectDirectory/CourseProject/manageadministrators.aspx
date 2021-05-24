<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageadministrators.aspx.cs" Inherits="CourseProject.manageadministrators" %>

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
    <title>Manage Administrators</title>
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
                    <h4 class="align-center">Manage Current Administrators</h4>
                    <h1 class="align-center">Update/Modify as needed.</h1>
                    <hr />

                    <form method="post" runat="server">

                        <%-- Mange Admin for project --%>
                        <div>
                            <asp:GridView
                                ID="gvManageAdmin"
                                runat="server"
                                AutoGenerateColumns="false"
                                ShowFooter="True"
                                ShowHeaderWhenEmpty="True"
                                DataKeyNames="ID"
                                OnRowCommand="GvCurrentAdmin_RowCommand"
                                OnRowEditing="GvCurrentAdmin_RowEditing"
                                OnRowCancelingEdit="GvCurrentAdmin_RowCancelingEdit"
                                OnRowUpdating="GvCurrentAdmin_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="First Name">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("FirstName") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditAdminFirstName" Text='<%# Eval("FirstName") %>' runat="server" />
                                        </EditItemTemplate>                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Last Name">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("LastName") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditAdminLastName" Text='<%# Eval("LastName") %>' runat="server" />
                                        </EditItemTemplate>                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Email") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditAdminEmail" Text='<%# Eval("Email") %>' runat="server" />
                                        </EditItemTemplate>                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Password">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Password") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditAdminPassword" Text='<%# Eval("Password") %>' runat="server" />
                                        </EditItemTemplate>                                        
                                    </asp:TemplateField>                  

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnEditSeason" runat="server" class="button special" CommandName="Edit" ToolTip="Edit" Text="Edit" />
                                            <%--<asp:Button ID="btnInactivateSeason" runat="server" class="button special" CommandName="Inactivate"  CommandArgument='<%# Eval("SeasonID") +","+ Eval("Active") %>'  Text='<%# Eval("Active").ToString().Equals("Yes") ? " Inactivate " : " Activate " %>'  />--%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Button ID="btnSaveSeason" runat="server" class="button special" CommandName="Update" ToolTip="Save" Text="Save" />
                                            <asp:Button ID="btnCancel" runat="server" class="button special" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />
                                        </EditItemTemplate>
                                        <%--<FooterTemplate>
                                                <asp:Button ID="btnNewSeason" runat="server" class="button special" CommandName="AddNew" ToolTip="Add Season" Text="Add Season" />
                                            </FooterTemplate>--%>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>


                        <asp:Literal ID="ltrlSqlError" runat="server"></asp:Literal>
                        <br />





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
