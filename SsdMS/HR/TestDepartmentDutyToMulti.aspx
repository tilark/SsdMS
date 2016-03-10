<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestDepartmentDutyToMulti.aspx.cs" Inherits="SsdMS.HR.TestDepartmentDutyToMulti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>测试将科室职务加入到一个多项可选框中，再进行插入操作</h3>

<div class="form-group">
            <asp:Label ID="Label6" AssociatedControlID="ddlDepartment" runat="server" Text="科室"  CssClass="col-md-2 control-label"></asp:Label>
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
    
         <%--<h6>还可以新增多个科室与职务</h6>--%>
    <%--//将科室与职务的信息添加到一个多选框中--%>
    <div class="form-group">
            <div class="col-md-2 col-md-offset-2">
            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" CssClass="btn btn-primary" Text="添加科室职务" />
            </div>
            <div class="col-md-8">
                <asp:Button runat="server" ID="btnCancel" Text="显示科室职务列表" OnClick="btnCancel_Click" CssClass="btn btn-warning" />
            </div>
    </div>

    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ListBox ID="ListBox1" runat="server" CssClass="form-control" SelectionMode="Multiple"></asp:ListBox>
            <asp:ListBox ID="ListBox2" runat="server" CssClass="form-control" SelectionMode="Multiple"></asp:ListBox>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
  
</asp:Content>
