<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUserRoles.aspx.cs" Inherits="SsdMS.HR.ManageUserRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clo-md-12">
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/HR/ManageListUsers.aspx" CssClass="btn btn-primary">返回管理用户界面</asp:HyperLink>
    <p><asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" runat="server" /></p>   
    <p></p>
    <h3>分配权限</h3>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:FormView ID="fvUser" runat="server" ItemType ="SsdMS.Models.ApplicationUser" DataKeyNames="Id"
                 SelectMethod="fvUser_GetItem" UpdateMethod="fvUser_UpdateItem">
                <ItemTemplate>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-4 control-label">帐号</asp:Label>
                            <div class="col-md-4">
                                <asp:Label ID="lblAccount" runat="server" CssClass="control-label" Text="<%#Item.UserName%>"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:Button runat="server" Text="更改帐号名" CommandName="Edit" CssClass="btn btn-primary"/>
                            </div>
                        </div>
                      </div>
                </ItemTemplate>
                <EditItemTemplate>
                    
                        <div class="form-group">
                            <asp:Label runat="server" CssClass="col-md-2 control-label">帐号</asp:Label>
                            <div class="col-md-4">
                                <asp:TextBox runat="server" ID="txtAccount" CssClass="form-control" Text="<%# Item.UserName %>"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAccount"
                                    CssClass="text-danger" ErrorMessage="“帐号”字段是必填字段。" />
                            </div>
                            <div class="col-md-7">
                                <asp:Button  runat="server" Text="更新" CssClass="btn btn-primary" CommandName="Update"/>
                                <asp:Button  runat="server" Text="取消" CssClass="btn btn-warning" CommandName="Cancel"/>
                            </div>
                        </div>
                </EditItemTemplate>
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>         
</div>
</asp:Content>
