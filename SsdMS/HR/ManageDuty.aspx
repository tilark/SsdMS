<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDuty.aspx.cs" Inherits="SsdMS.HR.ManageDuty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <p>
    <p><asp:ValidationSummary ShowModelStateErrors="true" runat="server" /></p>
    <p></p>
   
    <div class="clo-md-6">
        <h3>管理职务</h3>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ListView runat="server" ID="lvDuty" ItemType="SsdMS.Models.Duty" DataKeyNames="DutyID"  
                    InsertItemPosition="LastItem" InsertMethod="lvDuty_InsertItem"
                    SelectMethod="lvDuty_GetData" UpdateMethod="lvDuty_UpdateItem" DeleteMethod="lvDuty_DeleteItem">
                    <LayoutTemplate>
                            <table class="table table-hover">
                            <tr>
                                <th>职务</th>
                                <th>操作</th>
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
                            <td><asp:Label runat="server" ID="lblDutyName" Visible="true" Text="<%# Item.DutyName %>"></asp:Label>  </td>   
                            <td>                       
                                <asp:Button ID="EditButton" runat="server" Text="编辑" CommandName="Edit" CssClass="btn btn-primary" /> 
                                <asp:Button ID="DeleteButton" runat="server" Text="删除" CommandName="Delete" CssClass="btn btn-danger" OnClientClick="javascript:return confirm('确认删除选中的用户记录？');"/> 
                            </td>
 
                        </tr>
                    </ItemTemplate>
                                    <EditItemTemplate>
                            <tr>              
                                <td><asp:TextBox runat="server" ID="txtEditDutyName" Visible="true" CssClass="form-control" Text="<%#Item.DutyName %>"></asp:TextBox>
                                </td> 
                                <td>
                                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-info"/>
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-warning"/>
                                </td>

                            </tr>
                        </EditItemTemplate>
                    <InsertItemTemplate>
                        <tr>
                            <td>
                                <asp:TextBox runat="server" ID="txtInsert" CssClass="form-control"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="InsertButton" runat="server" Text="添加" CommandName="Insert" CssClass="btn btn-info" />
                            </td>
                        </tr>
                    </InsertItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
