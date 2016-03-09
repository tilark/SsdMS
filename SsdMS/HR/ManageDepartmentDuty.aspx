<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDepartmentDuty.aspx.cs" Inherits="SsdMS.HR.ManageDepartmentDuty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="clo-md-12">
        <h3>管理科室</h3>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <p><asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" runat="server" /></p>
                <p></p>
                <asp:ListView runat="server" ID="lvDepartmentDuty" ItemType="SsdMS.Models.DepartmentDuty" DataKeyNames="DepartmentDutyID"  
                    SelectMethod="lvDepartmentDuty_GetData"  DeleteMethod="lvDepartmentDuty_DeleteItem">
                    <LayoutTemplate>
                            <table class="table table-hover">
                            <tr>
                                <th>科室名称</th>
                                <th>职务名称</th>
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
                            <td><asp:Label runat="server" ID="lblDepartmentName" Visible="true" Text="<%# Item.Department.DepartmentName %>"></asp:Label>  </td>   
                            <td><asp:Label runat="server" ID="lblDepartmentPhone1" Visible="true" Text="<%# Item.Duty.DutyName %>"></asp:Label>  </td>   
<%--                            
                            <td>                       
                                <asp:Button ID="EditButton" runat="server" Text="编辑" CommandName="Edit" CssClass="btn btn-primary" /> 
                            </td>--%>
                            <td>    
                                <asp:Button ID="DeleteButton" runat="server" Text="删除" CommandName="Delete" CssClass="btn btn-danger" OnClientClick="javascript:return confirm('确认删除选中的用户记录？');"/> 
                            </td>
 
                        </tr>
                    </ItemTemplate>


                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
