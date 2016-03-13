<%@ Page Title="管理角色" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListMapRoles.aspx.cs" Inherits="SsdMS.Admin.ListMapRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clo-md-12">
        <h3>管理角色</h3>
        <%--<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/HR/ManageAddUser.aspx" CssClass="btn btn-primary">增加用户</asp:HyperLink>--%>
       <p></p>
        <asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" runat="server" />
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <p><asp:ValidationSummary ShowModelStateErrors="true" runat="server" /></p>
                <asp:ListView runat="server" ID="lvMapRole" ItemType="SsdMS.Models.MapRole" DataKeyNames="MapRoleID"                     
                    SelectMethod="lvMapRole_GetData" DeleteMethod="lvMapRole_DeleteItem"
                     InsertItemPosition="LastItem" InsertMethod="lvMapRole_InsertItem">
                    <LayoutTemplate>
                            <table class="table table-hover">
                            <tr>
                                <th>角色名</th>
                                <th>拥有权限</th>
                                <th>操作</th>
                                <th></th>
                            </tr>  
                        
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />                
                            </table>
                        <asp:DataPager runat="server" PageSize="15" >
                            <Fields>
                                <asp:NextPreviousPagerField 
                                ButtonType="Button"
                                ShowFirstPageButton="True" 
                                ShowLastPageButton="True" ButtonCssClass="btn btn-info" />
                            </Fields>
                            </asp:DataPager>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>

                            <td><asp:Label runat="server" ID="lblMapRoleName" Visible="true" Text="<%# Item.MapRoleName %>"></asp:Label>  </td>  
                            <td><asp:Label runat="server" ID="lblEmployeeNo" Visible="true" ></asp:Label>  </td>
                            <td>                      
                                <asp:Button ID="DeleteButton" runat="server" Text="删除" CommandName="Delete" CssClass="btn btn-danger" OnClientClick="javascript:return confirm('确认删除选中的用户记录？');"/> 
                            </td>
 
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <h4>无用户数据，请添加!</h4>
                    </EmptyDataTemplate>      
                    <InsertItemTemplate>
                       <td><asp:TextBox ID="txtInsert" runat="server"></asp:TextBox></td> 
                       <td></td>
                        <td>                      
                           <asp:Button ID="btnInsert" runat="server" Text="增加" CommandName="Insert" CssClass="btn btn-primary" /> 
                       </td>
                    </InsertItemTemplate>           
                </asp:ListView>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
