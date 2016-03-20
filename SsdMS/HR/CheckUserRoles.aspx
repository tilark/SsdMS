<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckUserRoles.aspx.cs" Inherits="SsdMS.HR.CheckUserRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-primary" NavigateUrl="~/HR/ManageListUsers.aspx">返回管理用户界面</asp:HyperLink>
    </p>

    <asp:FormView ID="fvUserRoles" runat="server" ItemType="SsdMS.Models.ApplicationUser" DataKeyNames="Id" SelectMethod="fvUserRoles_GetItem">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Visible="true">
                <a href="../Admin/ManageUserRoles.aspx?id=<%#:Item.Id %>" class="btn btn-primary">超级管理员更改权限</a>
            </asp:Label>

            <div class="form-group">
                <asp:Label ID="Label2" AssociatedControlID="txtUserName" runat="server" Text="帐号" CssClass="col-md-4 control-label"></asp:Label>
                    <div class="col-md-8">
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" ReadOnly="true" Text="<%#Item.UserName %>"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                            CssClass="text-danger" ErrorMessage="“用户姓名”字段是必填字段。" />
                    </div>
            </div>
            <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">用户姓名</asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox ID="TextBox1" ReadOnly="true" runat="server" CssClass="form-control" Text="<%#Item.InfoUser.UserName%>"></asp:TextBox>
                    </div>
            </div>
            <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-4 control-label">工号</asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox ID="TextBox2" ReadOnly="true" runat="server" CssClass="form-control" Text="<%#Item.InfoUser.EmployeeNo%>"></asp:TextBox>
                    </div>
            </div>
        </ItemTemplate>
    </asp:FormView>
    <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">权限列表</asp:Label>
            <div class="col-md-10">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
            </div>
    </div>
</asp:Content>
