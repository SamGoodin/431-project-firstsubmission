<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view-edit-program.aspx.cs" Inherits="CourseProject.view_edit_program" %>

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
    <title>View or Edit Program</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>

        <!-- Using WebFrame.ascx -->
        <general:Frame ID="idFrame" runat="server" />


            <!-- PAGE CONTENT -->
            <section>
                <div class="inner">
                <div class="box">
                      <div class="content">                        
                        
                        <h1 class="align-center">View or Edit Program</h1>
                        <hr />

                        <form action="#" method="post" runat="server">
                             <%-- add new field for project --%>
                            <div style="word-wrap: break-word;">
                               <asp:GridView 
                                    ID="gvSelectedProgram" 
                                    runat="server" 
                                    AutoGenerateColumns="false" 
                                    ShowFooter="True" 
                                    ShowHeaderWhenEmpty="True" 
                                    DataKeyNames="ProgramID"
                                    >
                                    <Columns>
                                        
                                        <asp:TemplateField  HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Name") %>' runat="server" />                                                
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditName" Text='<%# Eval("Name") %>' runat="server" />
                                            </EditItemTemplate>                                           
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditName" runat="server" class="button special edited" CommandName="Edit" ToolTip="Edit" Text="Edit" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btnSaveName" runat="server" class="button special edited" CommandName="Update" ToolTip="Save" Text="Save" />
                                                <asp:Button ID="btnCancel" runat="server" class="button special edited" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />
                                            </EditItemTemplate>                                            
                                        </asp:TemplateField>

                                        <asp:TemplateField  HeaderText="Contact">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("ContactID") %>' runat="server" />                                                
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditContact" Text='<%# Eval("ContactID") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditContact" runat="server" class="button special edited" CommandName="Edit" ToolTip="Edit" Text="Edit" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btnSaveName" runat="server" class="button special edited" CommandName="Update" ToolTip="Save" Text="Save" />
                                                <asp:Button ID="btnCancel" runat="server" class="button special edited" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />
                                            </EditItemTemplate>                                            
                                        </asp:TemplateField>

                                        <asp:TemplateField  HeaderText="Cost">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("CostID") %>' runat="server" />                                                
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditContact" Text='<%# Eval("CostID") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditCost" runat="server" class="button special edited" CommandName="Edit" ToolTip="Edit" Text="Edit" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btnSaveCost" runat="server" class="button special edited" CommandName="Update" ToolTip="Save" Text="Save" />
                                                <asp:Button ID="btnCancel" runat="server" class="button special edited" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />
                                            </EditItemTemplate>                                            
                                        </asp:TemplateField>

                                        <asp:TemplateField  HeaderText="Field">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("FieldID") %>' runat="server" />                                                
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditField" Text='<%# Eval("FieldID") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditField" runat="server" class="button special edited" CommandName="Edit" ToolTip="Edit" Text="Edit" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btnSaveField" runat="server" class="button special edited" CommandName="Update" ToolTip="Save" Text="Save" />
                                                <asp:Button ID="btnCancel" runat="server" class="button special edited" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />
                                            </EditItemTemplate>                                            
                                        </asp:TemplateField>

                                        <asp:TemplateField  HeaderText="Grade for Project">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("GradeID") %>' runat="server" />                                                
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditGrade" Text='<%# Eval("GradeID") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditGrade" runat="server" class="button special edited" CommandName="Edit" ToolTip="Edit" Text="Edit" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btnSaveGrade" runat="server" class="button special edited" CommandName="Update" ToolTip="Save" Text="Save" />
                                                <asp:Button ID="btnCancel" runat="server" class="button special edited" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />
                                            </EditItemTemplate>                                            
                                        </asp:TemplateField>


                                        <asp:TemplateField  HeaderText="Residential Status">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("ResidentialID") %>' runat="server" />                                                
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditResidential" Text='<%# Eval("ResidentialID") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditResidential" runat="server" class="button special edited" CommandName="Edit" ToolTip="Edit" Text="Edit" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btnSaveResidential" runat="server" class="button special edited" CommandName="Update" ToolTip="Save" Text="Save" />
                                                <asp:Button ID="btnCancel" runat="server" class="button special edited" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />
                                            </EditItemTemplate>                                            
                                        </asp:TemplateField>

                                       <asp:TemplateField  HeaderText="Stipend">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("StipendID") %>' runat="server" />                                                
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEditStipend" Text='<%# Eval("StipendID") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditStipend" runat="server" class="button special edited" CommandName="Edit" ToolTip="Edit" Text="Edit" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btnSaveStipend" runat="server" class="button special edited" CommandName="Update" ToolTip="Save" Text="Save" />
                                                <asp:Button ID="btnCancel" runat="server" class="button special edited" CommandName="Cancel" ToolTip="Cancel" Text="Cancel" />
                                            </EditItemTemplate>                                            
                                        </asp:TemplateField> 



                                    </Columns>
                                </asp:GridView>
                            </div>
                            
                           
                            <asp:Literal ID="ltrlSqlError" runat="server"></asp:Literal>
                            <br />
                            <asp:Literal ID="ltrlSqlError2" runat="server"></asp:Literal>

                            <br />
                            <asp:Button ID="btnBack" class="button special" runat="server" Text="Back to Profile Page" OnClick="back_Click" />
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



