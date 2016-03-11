<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeDepartmentDutyRoles.aspx.cs" Inherits="SsdMS.HR.ChangeDepartmentDutyRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="form-group">
            <asp:Label ID="Label6" AssociatedControlID="ddlDepartment" runat="server" Text="科室"  CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3">
            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control"></asp:DropDownList>
                <%--<asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="text-danger" ErrorMessage="必须选择一个科室" ControlToValidate="ddlDepartment" Type="Integer" ValueToCompare="-1" Operator="NotEqual"></asp:CompareValidator>--%>
            </div>    
        </div>
        <div class="form-group">
            <asp:Label ID="Label7" AssociatedControlID="ddlDuty" runat="server" Text="职务" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3">
            <asp:DropDownList ID="ddlDuty" runat="server" CssClass="form-control"></asp:DropDownList>  
            <%--<asp:CompareValidator ID="CompareValidator2" runat="server" CssClass="text-danger" ErrorMessage="必须选择一个职务" ControlToValidate="ddlDuty" Type="Integer" ValueToCompare="-1" Operator="NotEqual"></asp:CompareValidator>--%>
            </div>      
        </div>
        <div class="form-group">
            <div class="col-md-2 col-md-offset-2">
                <asp:Button runat="server" ID="btnAddDepartDuties" OnClick="btnAddDepartDuties_Click" Text="添加科室职务" CssClass="btn btn-primary" />
            </div>
            <div class="col-md-8">
                <asp:Button runat="server" ID="btnDeleteDepartDuties" OnClick="btnDeleteDepartDuties_Click" Text="删除科室职务" CssClass="btn btn-warning" />
                  
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label11" AssociatedControlID="lboxDepartDuties" runat="server" Text="科室职务列表"  CssClass="col-md-2 control-label"></asp:Label>

            <div class="col-md-6">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:ListBox ID="lboxDepartDuties" runat="server" CssClass="form-control" SelectionMode="Single"></asp:ListBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                             ErrorMessage="请将选择的科室与职务添加到列表框" CssClass="text-danger" ControlToValidate="lboxDepartDuties"></asp:RequiredFieldValidator>--%>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAddDepartDuties" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDeleteDepartDuties" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel> 
            </div>
        </div>
        <%--分配权限--%> 
        <div class="form-group">
            <asp:Label ID="Label10" AssociatedControlID="ddlRole" runat="server" Text="权限" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3">
            <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control"></asp:DropDownList>  
            <%--<asp:CompareValidator ID="CompareValidator4" runat="server" CssClass="text-danger" ErrorMessage="必须选择一个权限" ControlToValidate="ddlRole" Type="Integer" ValueToCompare="-1" Operator="NotEqual"></asp:CompareValidator>--%>
            </div>      
        </div>
        <div class="form-group">
            <div class="col-md-2 col-md-offset-2">
                <asp:Button runat="server" ID="btnAddRoles" OnClick="btnAddRoles_Click" Text="添加权限" CssClass="btn btn-primary" />
            </div>
            <div class="col-md-8">
                <asp:Button runat="server" ID="btnDeleteRoles" OnClick="btnDeleteRoles_Click" Text="删除权限" CssClass="btn btn-warning" />
                
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label12" AssociatedControlID="lboxRoles" runat="server" Text="权限列表" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-6">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:ListBox ID="lboxRoles" runat="server" CssClass="form-control" SelectionMode="Single"></asp:ListBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                             ErrorMessage="请将选择的权限添加到列表框" CssClass="text-danger" ControlToValidate="lboxRoles"></asp:RequiredFieldValidator>--%>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAddRoles" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDeleteRoles" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel> 
            </div>
        </div> 
    <div class="form-group">
            <div class="col-md-2 col-md-offset-2">
                <asp:Button runat="server" ID="btnAddUser" OnClick="btnAddUser_Click" Text="新增" CssClass="btn btn-primary" />
            </div>
            <div class="col-md-8">
                <%--<asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" Text="取消" CssClass="btn btn-warning" />--%>
                <asp:HyperLink ID="linkCancel" NavigateUrl="~/HR/ManageListUsers.aspx" CssClass="btn btn-warning" runat="server">取消</asp:HyperLink>
            </div>
        </div>             
</asp:Content>
