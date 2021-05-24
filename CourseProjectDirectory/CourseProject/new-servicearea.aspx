<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new-servicearea.aspx.cs" Inherits="CourseProject.new_servicearea" %>

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
    <title>Add New Service Area</title>
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
                    <h4 class="align-center">Back to Program Maintenance? <a style="color: #ff9900;" href="program-maintenance.aspx">Here.</a></h4>
                    <h1 class="align-center">Add a New Service Area Option</h1>
                    <hr />

                    <form method="post" runat="server">

                        <%-- add new ServiceArea for project --%>
                        <div>
                            <asp:GridView
                                ID="gvCurrentServiceArea"
                                runat="server"
                                AutoGenerateColumns="false"
                                ShowFooter="True"
                                ShowHeaderWhenEmpty="True"
                                DataKeyNames="ServiceAreaID"
                                OnRowCommand="GvCurrentServiceArea_RowCommand"
                                OnRowEditing="GvCurrentServiceArea_RowEditing"
                                OnRowCancelingEdit="GvCurrentServiceArea_RowCancelingEdit"
                                OnRowUpdating="GvCurrentServiceArea_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="Available Service Area Options">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("ServiceArea") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditServiceArea" Text='<%# Eval("ServiceArea") %>' runat="server" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtServiceAreaFooter" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnEditServiceArea" runat="server" class="button special" CommandName="Edit" ToolTip="Edit" Text="Edit" />
                                            <asp:Button ID="btnInactivateServiceArea" runat="server" class="button special" CommandName="Inactivate" CommandArgument='<%# Eval("ServiceAreaID") +","+ Eval("Active") %>' Text='<%# Eval("Active").ToString().Equals("Yes") ? " Inactivate " : " Activate " %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Button ID="btnSaveServiceArea" runat="server" class="button special" CommandName="Update" ToolTip="Save" Text="Save" />
                                            <asp:Button ID="btnServiceArea" runat="server" class="button special" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="btnNewServiceArea" runat="server" class="button special" CommandName="AddNew" ToolTip="Add Service Area" Text="Add Service Area" />
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


