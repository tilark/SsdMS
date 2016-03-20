<%@ Page Title="更改个人信息" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageInfoUser.aspx.cs" Inherits="SsdMS.Account.ManageInfoUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" CssClass="text-danger" runat="server" />
            <p>
                <asp:Label ID="ErrorMessage" runat="server"></asp:Label></p>
        </ContentTemplate>
        </asp:UpdatePanel>

        
            <%--添加 InfoUser信息--%>
        <h3>更改个人信息</h3>
            <asp:FormView ID="fvInfoUser" runat="server" ItemType="SsdMS.Models.InfoUser" DataKeyNames="InfoUserID"
                SelectMethod="fvInfoUser_GetItem" UpdateMethod="fvInfoUser_UpdateItem" DefaultMode="Edit">
                <EditItemTemplate>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label ID="Label1" AssociatedControlID="txtUserName" runat="server" Text="用户姓名" CssClass="col-md-4 control-label"></asp:Label>
                                <div class="col-md-8">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" Text="<%#Item.UserName %>"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                                        CssClass="text-danger" ErrorMessage="“用户姓名”字段是必填字段。" />
                                </div>
                        </div>
                        <div class="form-group">
                                <asp:Label ID="Label2" AssociatedControlID="txtEmployeeNo" runat="server" Text="工号" CssClass="col-md-4 control-label"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtEmployeeNo" runat="server" CssClass="form-control" Text="<%#Item.EmployeeNo %>"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                                        CssClass="text-danger" ErrorMessage="“工号”字段是必填字段。" />
                                <asp:Label ID="lblinfoUserID" runat="server" Visible="false" Text="<%# Item.InfoUserID %>"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label3" AssociatedControlID="txtBirthDate" runat="server" Text="出生日期" CssClass="col-md-4 control-label"></asp:Label>
                                <div class="col-md-8">
                                <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control" Text="<%#Item.BirthDate %>"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                                        CssClass="text-danger" ErrorMessage="“出生日期”字段是必填字段。" />--%>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label9" AssociatedControlID="txtEmail" runat="server" Text="电子邮箱" CssClass="col-md-4 control-label"></asp:Label>
                                <div class="col-md-8">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" Text="<%#Item.Email %>"></asp:TextBox>  
                                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                                        CssClass="text-danger" ErrorMessage="“电子邮箱”字段是必填字段。" />--%>           
                                </div>        
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label4" AssociatedControlID="txtPhone1" runat="server" Text="工作电话" CssClass="col-md-4 control-label"></asp:Label>
                                <div class="col-md-8">
                                <asp:TextBox ID="txtPhone1" runat="server" CssClass="form-control" Text="<%#Item.Phone1 %>"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" CssClass="text-danger" runat="server" 
                                        ErrorMessage="电话号码输入有误" ValidationExpression="^\d{11,}" ControlToValidate="txtPhone1"></asp:RegularExpressionValidator>            
                                </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label5" AssociatedControlID="txtPhone2" runat="server" Text="住宅电话"  CssClass="col-md-4 control-label"></asp:Label>
                                <div class="col-md-8">
                                <asp:TextBox ID="txtPhone2" runat="server" CssClass="form-control" Text="<%#Item.Phone2 %>"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="text-danger" runat="server" 
                                    ErrorMessage="电话号码输入有误" ValidationExpression="^\d{11,}" ControlToValidate="txtPhone2"></asp:RegularExpressionValidator>            
                                </div>            
                        </div>  
                        <div class="form-group">
                            <asp:Label ID="Label6" AssociatedControlID="lboxDepartmentDuty" runat="server" Text="科室职务"  CssClass="col-md-4 control-label"></asp:Label>
                                <div class="col-md-8">
                                    <asp:ListBox ID="lboxDepartmentDuty" CssClass="form-control" runat="server"></asp:ListBox>                        
                                </div> 
                        </div>                      
                        <div class="form-group">
                            <div class="col-md-2 col-md-offset-2">
                                <asp:Button runat="server" ID="btnUpdateUser" CommandName="Update" Text="更新" CssClass="btn btn-primary" />
                            </div>
                            <div class="col-md-6 col-md-offset-2">
                                <asp:HyperLink ID="linkCancel" NavigateUrl="Manage.aspx" CssClass="btn btn-warning" runat="server">取消</asp:HyperLink>
                            </div>
                        </div>
                    </div>
                </EditItemTemplate>
            </asp:FormView>
</asp:Content>
