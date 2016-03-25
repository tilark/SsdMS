<%@ Page Title="创建新用户" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageAddUser.aspx.cs" Inherits="SsdMS.HR.ManageAddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Content/bootstrap-datetimepicker.min.css" />
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-primary" NavigateUrl="~/HR/ManageListUsers.aspx">返回管理用户界面</asp:HyperLink>
    </p>
    <p></p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" CssClass="text-danger" runat="server" />
            <p>
                <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
            </p>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="form-horizontal">
        <h3>增加用户</h3>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Account" CssClass="col-md-2 control-label">帐号</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Account" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Account"
                    CssClass="text-danger" ErrorMessage="“帐号”字段是必填字段。" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">密码</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="“密码”字段是必填字段。" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">确认密码</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="“确认密码”字段是必填字段。" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="密码和确认密码不匹配。" />
            </div>
        </div>
        <%--添加 InfoUser信息--%>
        <h3>填写基本信息</h3>
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
                <div class='input-group' id='datetimepicker1'>
                    <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control birthdate"></asp:TextBox>
                    <span class="glyphicon glyphicon-calendar"></span>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtBirthDate"
                        CssClass="text-danger" ErrorMessage="“出生日期”字段是必填字段。" />
                </div>

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
            <asp:Label ID="Label5" AssociatedControlID="txtPhone2" runat="server" Text="住宅电话" CssClass="col-md-2 control-label"></asp:Label>
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
            <asp:Label ID="Label6" AssociatedControlID="ddlDepartment" runat="server" Text="科室" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="text-danger" ErrorMessage="必须选择一个科室" ControlToValidate="ddlDepartment" Type="Integer" ValueToCompare="-1" Operator="NotEqual"></asp:CompareValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label7" AssociatedControlID="ddlDuty" runat="server" Text="职务" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlDuty" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator2" runat="server" CssClass="text-danger" ErrorMessage="必须选择一个职务" ControlToValidate="ddlDuty" Type="Integer" ValueToCompare="-1" Operator="NotEqual"></asp:CompareValidator>
            </div>
        </div>

        <%--分配权限--%>
        <div class="form-group">
            <asp:Label ID="Label10" AssociatedControlID="ddlRole" runat="server" Text="权限" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator4" runat="server" CssClass="text-danger" ErrorMessage="必须选择一个权限" ControlToValidate="ddlRole" Type="String" ValueToCompare="-1" Operator="NotEqual"></asp:CompareValidator>
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
    </div>


    <script type="text/javascript" src="../Scripts/moment-with-locales.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.birthdate').datetimepicker({
                locale: 'zh-cn',
                viewMode: 'years',
                format: 'YYYY/MM/DD'
            });
        });
    </script>
</asp:Content>
