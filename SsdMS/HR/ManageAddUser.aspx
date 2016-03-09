<%@ Page Title="创建新用户" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageAddUser.aspx.cs" Inherits="SsdMS.HR.ManageAddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-primary">返回管理用户界面</asp:HyperLink>
    </p>
    <p></p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" runat="server" />
            <p></p>
        </ContentTemplate>
    </asp:UpdatePanel>

        <div class="form-horizontal">
            <h3>增加用户</h3>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">登陆邮箱</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                        CssClass="text-danger" ErrorMessage="“登陆邮箱”字段是必填字段。" />
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
                <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                        CssClass="text-danger" ErrorMessage="“出生日期”字段是必填字段。" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label9" AssociatedControlID="txtEmail" runat="server" Text="电子邮箱" CssClass="col-md-2 control-label"></asp:Label>
             <div class="col-md-10">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>  
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="请输入正确的邮箱格式" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>  
            </div>        
        </div>
        <div class="form-group">
            <asp:Label ID="Label4" AssociatedControlID="txtPhone1" runat="server" Text="工作电话" CssClass="col-md-2 control-label"></asp:Label>
             <div class="col-md-10">
                <asp:TextBox ID="txtPhone1" runat="server" CssClass="form-control"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="电话号码输入有误" ValidationExpression="^\d{11,}" ControlToValidate="txtPhone1"></asp:RegularExpressionValidator>            
             </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label5" AssociatedControlID="txtPhone2" runat="server" Text="住宅电话" CssClass="col-md-2 control-label"></asp:Label>
             <div class="col-md-10">
                <asp:TextBox ID="txtPhone2" runat="server" CssClass="form-control"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="电话号码输入有误" ControlToValidate="txtPhone2" ValidationExpression="^\d{11,}"></asp:RegularExpressionValidator>
             </div>            
        </div>     
        <div class="form-group">
            <asp:Label ID="Label6" AssociatedControlID="ddlDepartment" runat="server" Text="科室" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3">
            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control"></asp:DropDownList> 
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator> 
            </div>    
        </div>
        <div class="form-group">
            <asp:Label ID="Label7" AssociatedControlID="ddlDuty" runat="server" Text="职务" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3">
            <asp:DropDownList ID="ddlDuty" runat="server" CssClass="form-control"></asp:DropDownList>  
            </div>      
        </div>
        <div class="form-group">
            <asp:Label ID="Label8" AssociatedControlID="ddlProfession" runat="server" Text="职称" CssClass="col-md-2 control-label"></asp:Label>
            <div class="col-md-3">
            <asp:DropDownList ID="ddlProfession" runat="server" CssClass="form-control"></asp:DropDownList>
             </div>        
        </div>                                   
        <div class="form-group">
           <%-- <div class="col-md-offset-2 col-md-10">--%>
            <div class="col-md-2 col-md-offset-2">
                <asp:Button runat="server" ID="btnAddUser" OnClick="btnAddUser_Click" Text="新增" CssClass="btn btn-primary" />
            </div>
            <div class="col-md-8">
                <asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" Text="取消" CssClass="btn btn-warning" />
            </div>
        </div>
    </div>
     

</asp:Content>
