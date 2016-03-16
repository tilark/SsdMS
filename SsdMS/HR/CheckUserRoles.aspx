<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckUserRoles.aspx.cs" Inherits="SsdMS.HR.CheckUserRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <p>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-primary" NavigateUrl="~/HR/ManageListUsers.aspx">返回管理用户界面</asp:HyperLink>
    </p>

    <asp:FormView ID="fvUserRoles" runat="server" ItemType="SsdMS.Models.ApplicationUser" DataKeyNames="Id" SelectMethod="fvUserRoles_GetItem">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text="<%#Item.UserName %>"></asp:Label>

        </ItemTemplate>
    </asp:FormView>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
</asp:Content>
