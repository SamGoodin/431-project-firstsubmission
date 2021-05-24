<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new-grade.aspx.cs" Inherits="CourseProject.new_grade" %>
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
    <title>Add New Grade</title>
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
                        <h1 class="align-center">Add a New Eligible Grade Option</h1>
                        <hr />

                        <form method="post" runat="server">

                             <%-- add new Grade for project --%>
                            <div>
                               <asp:GridView 
                                    ID="gvCurrentGrade" 
                                    runat="server" 
                                    AutoGenerateColumns="false" 
                                    ShowFooter="True" 
                                    ShowHeaderWhenEmpty="True" 
                                    DataKeyNames="GradeID"
                                    OnRowCommand="GvCurrentGrade_RowCommand" 
                                    OnRowEditing="GvCurrentGrade_RowEditing"
                                    OnRowCancelingEdit="GvCurrentGrade_RowCancelingEdit"
                                    OnRowUpdating="GvCurrentGrade_RowUpdating"
                                    >
                                    <Columns>
                                        <asp:TemplateField  HeaderText="Available Grades">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("GradeLevel") %>' runat="server" />                                                
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditGradeName" Text='<%# Eval("GradeLevel") %>' runat="server" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:TextBox ID="txtGradeNameFooter" runat="server" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditGrade" runat="server" class="button special" CommandName="Edit" ToolTip="Edit" Text="Edit" />
                                                <asp:Button ID="btnInactivateGrade" runat="server" class="button special" CommandName="Inactivate"  CommandArgument='<%# Eval("GradeID") +","+ Eval("Active") %>'  Text='<%# Eval("Active").ToString().Equals("Yes") ? " Inactivate " : " Activate " %>'  />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btnSaveGrade" runat="server" class="button special" CommandName="Update" ToolTip="Save" Text="Save" />
                                                <asp:Button ID="btnCancel" runat="server" class="button special" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="btnNewGrade" runat="server" class="button special" CommandName="AddNew" ToolTip="Add Grade" Text="Add Grade" />
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



