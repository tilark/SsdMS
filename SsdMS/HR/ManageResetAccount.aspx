<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageResetAccount.aspx.cs" Inherits="SsdMS.HR.ManageResetAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>更改登录名，谨慎操作</h3>

    <div class="clo-md-12">
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/HR/ManageListUsers.aspx" CssClass="btn btn-primary">返回管理用户界面</asp:HyperLink>
    <p><asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" runat="server" />
    </p>   
    <p></p>
    <h3>登录帐号</h3>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            
            <asp:FormView ID="fvUser" runat="server" ItemType ="SsdMS.Models.ApplicationUser" DataKeyNames="Id"
                 SelectMethod="fvUser_GetItem" UpdateMethod="fvUser_UpdateItem">
                <ItemTemplate>
                    <dl>
                        <dt>登录名：</dt>
                        <dd><asp:Label runat="server" Text="<%#Item.UserName %>"></asp:Label></dd>
                        <dt>用户姓名</dt>
                        <dd><asp:Label runat="server" Text="<%#Item.InfoUser.UserName %>"></asp:Label></dd>
                        <dt>工号</dt>
                        <dd><asp:Label runat="server" Text="<%#Item.InfoUser.EmployeeNo %>"></asp:Label></dd>
                        <dt>科室职务信息</dt>
                        <dd></dd>
                    </dl>
                </ItemTemplate>
                
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>         
</div>
</asp:Content>
