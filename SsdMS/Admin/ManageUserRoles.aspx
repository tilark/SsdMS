<%@ Page Title="管理用户权限" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUserRoles.aspx.cs" Inherits="SsdMS.Admin.ManageUserRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-primary" NavigateUrl="~/HR/ManageListUsers.aspx">返回管理用户界面</asp:HyperLink>
    </p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <p><asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" runat="server" /></p> 
            <p><asp:Label ID="Message" runat="server" Text=""></asp:Label></p>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:FormView ID="fvUserRoles" runat="server" ItemType="SsdMS.Models.ApplicationUser" DataKeyNames="Id" 
        SelectMethod="fvUserRoles_GetItem">
        <ItemTemplate>
    <div class="form-horizontal">

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
        </div>
        </ItemTemplate>
    </asp:FormView>
    <asp:Label ID="lblUserId" runat="server" Text="" Visible="false"></asp:Label>
    
    <div class="col-md-5">
             <%--右边框为“科室成员”等MapRole的已有权限列表--%>
            <div class="form-group">
                <asp:Label ID="Label12" AssociatedControlID="lboxUserRoles" runat="server" Text="用户权限" CssClass="col-md-3 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:ListBox ID="lboxUserRoles" runat="server" CssClass="form-control" Height ="250px"  SelectionMode="Single">
                            </asp:ListBox>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAddRoles" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnDeleteRoles" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel> 
                </div>
            </div> 
      </div> 
    
        <div class="col-md-2">
             <%--中间为添加至映射权限，从映射权限表删除按钮,向左与向右箭头 col-md-offset-2--%>
            <div class="form-group">
                <div class="col-md-2" style="margin-top:20px">
                    <asp:Button runat="server" ID="btnAddRoles" OnClick="btnAddRoles_Click" Text="添加权限至用户" CssClass="btn btn-primary" />
                </div>
                <div class="col-md-10" style="margin-top:80px">
                    <asp:Button runat="server" ID="btnDeleteRoles" OnClick="btnDeleteRoles_Click" Text="删除用户权限" CssClass="btn btn-warning" />
                </div>
             </div>
        </div>
        <div class="col-md-5">
            <div class="form-group">
                <asp:Label ID="Label7" AssociatedControlID="lboxRoles" runat="server" Text="权限" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-10">
                <asp:ListBox ID="lboxRoles" runat="server" CssClass="form-control" Height="300px" SelectionMode="Multiple"></asp:ListBox>  
                </div>      
            </div>
        </div>

</asp:Content>
