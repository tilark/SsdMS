<%@ Page Title="管理角色" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageMapRoles.aspx.cs" Inherits="SsdMS.Admin.ManageMapRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>管理角色</h3>
       <p>
           <asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" runat="server" />
       </p>    
        <%--添加Role的列表至ListBox，多选--%>
        <div class="col-md-5">
            <div class="form-group">
                <asp:Label ID="Label7" AssociatedControlID="lboxRoles" runat="server" Text="权限" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-10">
                <asp:ListBox ID="lboxRoles" runat="server" CssClass="form-control" Height="300px" SelectionMode="Multiple"></asp:ListBox>  
                </div>      
            </div>
        </div>
        <div class="col-md-2">
             <%--中间为添加至映射权限，从映射权限表删除按钮,向左与向右箭头 col-md-offset-2--%>
            <div class="form-group">
                <div class="col-md-2" style="margin-top:20px">
                    <asp:Button runat="server" ID="btnAddRoles" OnClick="btnAddRoles_Click" Text="添加权限至角色" CssClass="btn btn-primary" />
                </div>
                <div class="col-md-10" style="margin-top:80px">
                    <asp:Button runat="server" ID="btnDeleteRoles" OnClick="btnDeleteRoles_Click" Text="删除角色权限" CssClass="btn btn-warning" />
                </div>
             </div>
        </div>
        <div class="col-md-5">
             <%--右边框为“科室成员”等MapRole的已有权限列表--%>
            <div class="form-group">
                <asp:Label ID="Label12" AssociatedControlID="lboxRoles" runat="server" Text="角色" CssClass="col-md-2 control-label"></asp:Label>
                <div class="col-md-6">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlMapRole" AutoPostBack="true" OnTextChanged="ddlMapRole_TextChanged" runat="server" CssClass="form-control"></asp:DropDownList>  
                            <asp:CompareValidator ID="CompareValidator2" runat="server" CssClass="text-danger" ErrorMessage="请选择一个角色" ControlToValidate="ddlMapRole" Type="Integer" ValueToCompare="-1" Operator="NotEqual"></asp:CompareValidator>
                           
                            <asp:ListBox ID="lboxTrueRoles" runat="server" CssClass="form-control" Height ="250px"  SelectionMode="Single">
                                
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
   
</asp:Content>
