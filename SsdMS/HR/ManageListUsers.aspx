<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageListUsers.aspx.cs" Inherits="SsdMS.HR.ManageListUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<p></p>
   
    <div class="clo-md-12">
        <h3>管理用户</h3>
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/HR/ManageAddUser.aspx" CssClass="btn btn-primary">增加用户</asp:HyperLink>
       <p></p>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <p><asp:ValidationSummary ShowModelStateErrors="true" runat="server" /></p>
                <asp:ListView runat="server" ID="lvInfoUser" ItemType="SsdMS.Models.InfoUser" DataKeyNames="InfoUserID"                     
                    SelectMethod="lvInfoUser_GetData" DeleteMethod="lvInfoUser_DeleteItem">
                    <LayoutTemplate>
                            <table class="table table-hover">
                            <tr>
                                <th>用户名</th>
                                <th>工号</th>
                                <th>工作电话</th>
                                <th>住宅电话</th>
                                <th>出生日期</th>
                                <th>操作</th>
                                <th></th>
                                <th></th>
                                <th></th>
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

                            <td><asp:Label runat="server" ID="lblInfoUserName" Visible="true" Text="<%# Item.UserName %>"></asp:Label>  </td>  
                            <td><asp:Label runat="server" ID="lblEmployeeNo" Visible="true" Text="<%# Item.EmployeeNo %>"></asp:Label>  </td>
                            <td><asp:Label runat="server" ID="lblPhone1" Visible="true" Text="<%# Item.Phone1 %>"></asp:Label>  </td>   
                            <td><asp:Label runat="server" ID="lblPhone2" Visible="true" Text="<%# Item.Phone2 %>"></asp:Label>  </td>  
                            <td><asp:Label runat="server" ID="lblBirthDate" Visible="true" Text="<%# Item.BirthDate %>"></asp:Label>  </td>   
                            <td><a href="ManageUserDetail.aspx?infouserID=<%#:Item.InfoUserID %>" class="btn btn-primary">详情</a></td>
                            <td><a href="ManageUserRoles.aspx?infouserID=<%#:Item.InfoUserID %>" class="btn btn-primary">管理权限</a></td>
                            <td><a href="ManageResetPassword.aspx?infouserID=<%#:Item.InfoUserID %>" class="btn btn-primary">重置密码</a></td>
                            <td><a href="ManageResetAccount.aspx?infouserID=<%#:Item.InfoUserID %>" class="btn btn-primary">更改登录名</a></td>
                            <td>                      
                                <asp:Button ID="DeleteButton" runat="server" Text="删除" CommandName="Delete" CssClass="btn btn-danger" OnClientClick="javascript:return confirm('确认删除选中的用户记录？');"/> 
                            </td>
 
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <h4>无用户数据，请添加!</h4>
                    </EmptyDataTemplate>                 
                </asp:ListView>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
