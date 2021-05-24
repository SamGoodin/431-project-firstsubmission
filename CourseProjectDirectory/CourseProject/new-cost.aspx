<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new-cost.aspx.cs" Inherits="CourseProject.new_cost" %>

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
    <title>Add New Cost</title>
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
                    <h1 class="align-center">Add a New Cost Option</h1>
                    <hr />

                    <form method="post" runat="server">

                        <%-- add new Grade for project --%>
                        <div>
                            <asp:GridView
                                ID="gvCurrentCost"
                                runat="server"
                                AutoGenerateColumns="false"
                                ShowFooter="True"
                                ShowHeaderWhenEmpty="True"
                                DataKeyNames="CostID"
                                OnRowCommand="GvCurrentCost_RowCommand"
                                OnRowEditing="GvCurrentCost_RowEditing"
                                OnRowCancelingEdit="GvCurrentCost_RowCancelingEdit"
                                OnRowUpdating="GvCurrentCost_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="Available Costs">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("CostAmount") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditCost" Text='<%# Eval("CostAmount") %>' runat="server" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtCostFooter" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnEditCost" runat="server" class="button special" CommandName="Edit" ToolTip="Edit" Text="Edit" />
                                            <asp:Button ID="btnInactivateCost" runat="server" class="button special" CommandName="Inactivate" CommandArgument='<%# Eval("CostID") +","+ Eval("Active") %>' Text='<%# Eval("Active").ToString().Equals("Yes") ? " Inactivate " : " Activate " %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Button ID="btnSaveCost" runat="server" class="button special" CommandName="Update" ToolTip="Save" Text="Save" />
                                            <asp:Button ID="btnCost" runat="server" class="button special" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="btnNewCost" runat="server" class="button special" CommandName="AddNew" ToolTip="Add Cost" Text="Add Cost" />
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


