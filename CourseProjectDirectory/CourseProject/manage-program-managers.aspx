﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage-program-managers.aspx.cs" Inherits="CourseProject.manage_program_managers" %>


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
    <title>Manage Program Managers Page</title>
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
                    <h2 class="align-center">Manage Program Managers</h2>
                    <hr />

                    <form runat="server">

                        <%-- List of Managers to be Activated/Inactivated --%>
                            <div>
                                <h2>Inactive Program Managers</h2>
                               <asp:GridView
                                    ID="gvManagersToBeManagedActivate" 
                                    runat="server" 
                                    AutoGenerateColumns="false" 
                                    ShowFooter="False" 
                                    ShowHeaderWhenEmpty="True" 
                                    DataKeyNames="ManagerID"
                                    OnRowCommand="GvManagerActivateInactivate_RowCommand" 
                                   
                                    >
                                    <Columns>
                                        <asp:TemplateField  HeaderText="First Name">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("FirstName") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Last Name">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("LastName") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                         </asp:TemplateField>
                                         <asp:TemplateField  HeaderText="Email">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Email") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnActivate" runat="server" class="button special" CommandName="Activate" CommandArgument='<%# Eval("Email") %>' ToolTip ="Activate" Text="Activate" />
                                                <%--<asp:Button ID="btnDisapprove" runat="server" class="button special" CommandName="Disapprove"  CommandArgument='<%# Eval("FieldID") +","+ Eval("Active") %>'  Text='<%# Eval("Active").ToString().Equals("Yes") ? " Inactivate " : " Activate " %>'  />--%>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <%--<asp:Button ID="btnSaveField" runat="server" class="button special" CommandName="Update" ToolTip="Save" Text="Save" />--%>
                                                <%--<asp:Button ID="btnCancel" runat="server" class="button special" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />--%>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <%--<asp:Button ID="btnNewField" runat="server" class="button special" CommandName="AddNew" ToolTip="Add Field" Text="Add Field" />--%>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>               
                        
                        <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>


                         <%-- List of Managers to inactivate --%>
                            <div>
                                <h2>Current Active Program Managers</h2>
                               <asp:GridView 
                                    ID="gvManagersToBeManagedInactivate" 
                                    runat="server" 
                                    AutoGenerateColumns="false" 
                                    ShowFooter="False" 
                                    ShowHeaderWhenEmpty="True" 
                                    DataKeyNames="ManagerID"
                                    OnRowCommand="GvManagerActivateInactivate_RowCommand" 
                                   
                                    >
                                    <Columns>
                                        <asp:TemplateField  HeaderText="First Name">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("FirstName") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="Last Name">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("LastName") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                         </asp:TemplateField>
                                         <asp:TemplateField  HeaderText="Email">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Email") %>' runat="server" />                                                
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnInactivate" runat="server" class="button special" CommandName="Inactivate" CommandArgument='<%# Eval("Email") %>' ToolTip ="Inactivate" Text="Inactivate" />
                                                <%--<asp:Button ID="btnDisapprove" runat="server" class="button special" CommandName="Disapprove"  CommandArgument='<%# Eval("FieldID") +","+ Eval("Active") %>'  Text='<%# Eval("Active").ToString().Equals("Yes") ? " Inactivate " : " Activate " %>'  />--%>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <%--<asp:Button ID="btnSaveField" runat="server" class="button special" CommandName="Update" ToolTip="Save" Text="Save" />--%>
                                                <%--<asp:Button ID="btnCancel" runat="server" class="button special" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />--%>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <%--<asp:Button ID="btnNewField" runat="server" class="button special" CommandName="AddNew" ToolTip="Add Field" Text="Add Field" />--%>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                 
                         
                        
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>



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

