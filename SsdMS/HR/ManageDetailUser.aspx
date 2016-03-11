<%@ Page Title="更改用户资料" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDetailUser.aspx.cs" Inherits="SsdMS.HR.ManageDetailUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-primary" NavigateUrl="~/HR/ManageListUsers.aspx">返回管理用户界面</asp:HyperLink>
    </p>
    <p></p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" CssClass="text-danger" runat="server" />
            <p>
                <asp:Label ID="ErrorMessage" runat="server"></asp:Label></p>
        </ContentTemplate>
    </asp:UpdatePanel>

        <div class="form-horizontal">
            <%--添加 InfoUser信息--%>
        <h3>用户详情</h3>
        <div class="form-group">
            <asp:Label ID="Label1" AssociatedControlID="txtUserName" runat="server" Text="用户姓名" CssClass="col-md-2 control-label"></asp:Label>
             <div class="col-md-10">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                        CssClass="text-danger" ErrorMessage="“用户姓名”字段是必填字段。" />
              </div>
        </div>
        <div class="form-group">
                <asp:Label ID="Label2" AssociatedControlID="txtEmployeeNo" runat="server" Text="工号" CssClass="col-md-2 control-label"></asp:Label>
             <div class="col-md-10">
                <asp:TextBox ID="txtEmployeeNo" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                        CssClass="text-danger" ErrorMessage="“工号”字段是必填字段。" />
        
             </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label3" AssociatedControlID="txtBirthDate" runat="server" Text="出生日期" CssClass="col-md-2 control-label"></asp:Label>
             <div class="col-md-10">
                <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control"></asp:TextBox>
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                        CssClass="text-danger" ErrorMessage="“出生日期”字段是必填字段。" />--%>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label9" AssociatedControlID="txtEmail" runat="server" Text="电子邮箱" CssClass="col-md-2 control-label"></asp:Label>
             <div class="col-md-10">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>  
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                        CssClass="text-danger" ErrorMessage="“电子邮箱”字段是必填字段。" />           
             </div>        
        </div>
        <div class="form-group">
            <asp:Label ID="Label4" AssociatedControlID="txtPhone1" runat="server" Text="工作电话" CssClass="col-md-2 control-label"></asp:Label>
             <div class="col-md-10">
                <asp:TextBox ID="txtPhone1" runat="server" CssClass="form-control"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" CssClass="text-danger" runat="server" 
                     ErrorMessage="电话号码输入有误" ValidationExpression="^\d{11,}" ControlToValidate="txtPhone1"></asp:RegularExpressionValidator>            
             </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label5" AssociatedControlID="txtPhone2" runat="server" Text="住宅电话"  CssClass="col-md-2 control-label"></asp:Label>
             <div class="col-md-10">
                <asp:TextBox ID="txtPhone2" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="text-danger" runat="server" 
                    ErrorMessage="电话号码输入有误" ValidationExpression="^\d{11,}" ControlToValidate="txtPhone2"></asp:RegularExpressionValidator>            

             </div>            
        </div>  
        <div class="form-group">
            <asp:Label ID="Label8" AssociatedControlID="ddlProfession" runat="server" Text="职称" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3">
            <asp:DropDownList ID="ddlProfession" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:CompareValidator ID="CompareValidator3" runat="server" CssClass="text-danger" ErrorMessage="必须选择一个职称" ControlToValidate="ddlProfession" Type="Integer" ValueToCompare="-1" Operator="NotEqual"></asp:CompareValidator>
        </div>        
        </div>        
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
                <asp:Button runat="server" ID="btnUpdateUser" OnClick="btnUpdateUser_Click" Text="更新" CssClass="btn btn-primary" />
            </div>
            <div class="col-md-8">
                <%--<asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" Text="取消" CssClass="btn btn-warning" />--%>
                <asp:HyperLink ID="linkCancel" NavigateUrl="~/HR/ManageListUsers.aspx" CssClass="btn btn-warning" runat="server">取消</asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
