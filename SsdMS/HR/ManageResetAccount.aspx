﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageResetAccount.aspx.cs" Inherits="SsdMS.HR.ManageResetAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>更改登录帐号，谨慎操作</h3>

        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/HR/ManageListUsers.aspx" CssClass="btn btn-primary">返回管理用户界面</asp:HyperLink>
    <p><asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" runat="server" />
    </p>   
    <p></p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="Message" runat="server"></asp:Label>
            <asp:FormView ID="fvUser" runat="server" ItemType ="SsdMS.Models.ApplicationUser" DataKeyNames="Id"
                 SelectMethod="fvUser_GetItem" UpdateMethod="fvUser_UpdateItem" DefaultMode="Edit">
                <EditItemTemplate>
                    <div class="form-horizontal">
                        <div class="form-group">
                                <asp:Label runat="server" CssClass="col-md-2 control-label">帐号</asp:Label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtAccount" CssClass="form-control" Text="<%# Item.UserName %>"/>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAccount"
                                        CssClass="text-danger" ErrorMessage="“帐号”字段是必填字段。" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Button  runat="server" Text="更新" CssClass="btn btn-primary" CommandName="Update"/>
                                    <asp:HyperLink ID="linkCancel" NavigateUrl="~/HR/ManageListUsers.aspx" CssClass="btn btn-warning" runat="server">取消</asp:HyperLink>
                                </div>
                        </div>
                        <div class="form-group">
                                <asp:Label runat="server" CssClass="col-md-2 control-label">用户姓名</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="TextBox1" ReadOnly="true" runat="server" CssClass="form-control" Text="<%#Item.InfoUser.UserName%>"></asp:TextBox>
                                </div>
                        </div>
                        <div class="form-group">
                                <asp:Label runat="server" CssClass="col-md-2 control-label">工号</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="TextBox2" ReadOnly="true" runat="server" CssClass="form-control" Text="<%#Item.InfoUser.EmployeeNo%>"></asp:TextBox>
                                </div>
                        </div>
                  </div>
                </EditItemTemplate>
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>         
</asp:Content>
