<%@ Page Title="用户详情" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUserDetail.aspx.cs" Inherits="SsdMS.HR.ManageUserDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="col-md-12">
     <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/HR/ManageListUsers.aspx" CssClass="btn btn-primary">返回管理用户界面</asp:HyperLink>
    <p><asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" runat="server" /></p>   
    <asp:Label ID="lblDepartmentDuty" runat="server" Text="科室职务为："></asp:Label>
    <h3>基本信息</h3>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:FormView ID="fvInfoUser" runat="server" ItemType="SsdMS.Models.InfoUser" DataKeyNames="InfoUserID"
                UpdateMethod="fvInfoUser_UpdateItem" DefaultMode="Edit" SelectMethod="fvInfoUser_GetItem">
                <%--<ItemTemplate>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-md-2 col-md-offset-6">
                                <asp:Button runat="server" CommandName="Edit" Text="编辑" CssClass="btn btn-primary" />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label10" runat="server" CssClass="col-md-6 control-label">用户姓名:</asp:Label>
                            <div class="col-md-6">
                                <asp:Label ID="txtUserName" runat="server" CssClass="form-control" Text="<%#Item.UserName %>"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label2" runat="server" CssClass="col-md-6 control-label">工号:</asp:Label>
                            <div class="col-md-6">
                                <asp:Label ID="Label11" runat="server" CssClass="form-control" Text="<%#Item.EmployeeNo %>"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label12" runat="server" CssClass="col-md-6 control-label">出生日期:</asp:Label>
                            <div class="col-md-6">
                                <asp:Label ID="Label13" runat="server" CssClass="form-control" Text="<%#Item.BirthDate %>"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="Label14" runat="server" CssClass="col-md-6 control-label">电子邮箱:</asp:Label>
                            <div class="col-md-6">
                                <asp:Label ID="Label15" runat="server" CssClass="form-control" Text="<%#Item.Email %>"></asp:Label>
                            </div>
                        </div>                    
                    </div>
                </ItemTemplate>--%>
                <EditItemTemplate>
                    
                  <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label ID="Label1" AssociatedControlID="txtUserName" runat="server" Text="用户姓名" CssClass="col-md-4 control-label"></asp:Label>
                         <div class="col-md-8">
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" Text="<%#Item.UserName %>"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                                    CssClass="text-danger" ErrorMessage="“用户姓名”字段是必填字段。" />
                          </div>
                    </div>
                    <div class="form-group">
                            <asp:Label ID="Label2" AssociatedControlID="txtEmployeeNo" runat="server" Text="工号" CssClass="col-md-4 control-label"></asp:Label>
                         <div class="col-md-8">
                            <asp:TextBox ID="txtEmployeeNo" runat="server" CssClass="form-control" Text="<%#Item.EmployeeNo %>"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                                    CssClass="text-danger" ErrorMessage="“工号”字段是必填字段。" />
                         </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" AssociatedControlID="txtBirthDate" runat="server" Text="出生日期" CssClass="col-md-4 control-label"></asp:Label>
                         <div class="col-md-8">
                            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control" Text="<%#Item.BirthDate %>"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtUserName"
                                    CssClass="text-danger" ErrorMessage="“出生日期”字段是必填字段。" />--%>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label9" AssociatedControlID="txtEmail" runat="server" Text="电子邮箱" CssClass="col-md-4 control-label"></asp:Label>
                         <div class="col-md-8">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" Text="<%#Item.Email %>"></asp:TextBox>  
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail"
                                    CssClass="text-danger" ErrorMessage="“电子邮箱”字段是必填字段。" />           
                         </div>        
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label4" AssociatedControlID="txtPhone1" runat="server" Text="工作电话" CssClass="col-md-4 control-label"></asp:Label>
                         <div class="col-md-8">
                            <asp:TextBox ID="txtPhone1" runat="server" CssClass="form-control" Text="<%#Item.Phone1 %>"></asp:TextBox>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" CssClass="text-danger" runat="server" 
                                 ErrorMessage="电话号码输入有误" ValidationExpression="^\d{11,}" ControlToValidate="txtPhone1"></asp:RegularExpressionValidator>            
                         </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label5" AssociatedControlID="txtPhone2" runat="server" Text="住宅电话"  CssClass="col-md-4 control-label"></asp:Label>
                         <div class="col-md-8">
                            <asp:TextBox ID="txtPhone2" runat="server" CssClass="form-control" Text="<%#Item.Phone2 %>"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="text-danger" runat="server" 
                                ErrorMessage="电话号码输入有误" ValidationExpression="^\d{11,}" ControlToValidate="txtPhone2"></asp:RegularExpressionValidator>            
                         </div>            
                    </div>  
                    <div class="form-group">
                        <asp:Label ID="Label8" AssociatedControlID="ddlProfession" runat="server" Text="职称" CssClass="col-md-4 control-label"></asp:Label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlProfession" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" CssClass="text-danger" ErrorMessage="必须选择一个职称" ControlToValidate="ddlProfession" Type="Integer" ValueToCompare="-1" Operator="NotEqual"></asp:CompareValidator>
                        </div>        
                    </div>        
                    <div class="form-group">
                        <asp:Label ID="Label6" AssociatedControlID="ddlDepartment" runat="server" Text="科室"  CssClass="col-md-4 control-label"></asp:Label>
                        <div class="col-md-8">
                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="text-danger" ErrorMessage="必须选择一个科室" ControlToValidate="ddlDepartment" Type="Integer" ValueToCompare="-1" Operator="NotEqual"></asp:CompareValidator>
                        </div>    
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label7" AssociatedControlID="ddlDuty" runat="server" Text="职务" CssClass="col-md-4 control-label"></asp:Label>
                        <div class="col-md-8">
                        <asp:DropDownList ID="ddlDuty" runat="server" CssClass="form-control"></asp:DropDownList>  
                        <asp:CompareValidator ID="CompareValidator2" runat="server" CssClass="text-danger" ErrorMessage="必须选择一个职务" ControlToValidate="ddlDuty" Type="Integer" ValueToCompare="-1" Operator="NotEqual"></asp:CompareValidator>
                        </div>      
                    </div>
<%--                     <h6>还可以新增多个科室与职务</h6> --%>
                    <div class="form-group">
                        <div class="col-md-2 col-md-offset-2">
                            <asp:Button runat="server" CommandName="Update" Text="更新" CssClass="btn btn-primary" />
                        </div>
                        <div class="col-md-8">
                            <asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" Text="取消" CssClass="btn btn-warning" />
                        </div>
                    </div>    
                  </div>                 
                </EditItemTemplate>
            </asp:FormView>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
