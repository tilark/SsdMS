<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDepartment.aspx.cs" Inherits="SsdMS.HR.ManageDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div class="clo-md-12">
        <h3>管理科室</h3>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ListView runat="server" ID="lvDepartment" ItemType="SsdMS.Models.Department" DataKeyNames="DepartmentID"  
                    InsertItemPosition="LastItem" InsertMethod="lvDepartment_InsertItem"
                    SelectMethod="lvDepartment_GetData" UpdateMethod="lvDepartment_UpdateItem" DeleteMethod="lvDepartment_DeleteItem">
                    <LayoutTemplate>
                            <table class="table table-hover">
                            <tr>
                                <th>科室名称</th>
                                <th>科室电话1</th>
                                <th>科室电话2</th>
                                <th>科室电话3</th>
                                <th>科室电话4</th>
                                <th>科室描述</th>
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
                            <td><asp:Label runat="server" ID="lblDepartmentName" Visible="true" Text="<%# Item.DepartmentName %>"></asp:Label>  </td>   
                            <td><asp:Label runat="server" ID="lblDepartmentPhone1" Visible="true" Text="<%# Item.DepartmentPhone1 %>"></asp:Label>  </td>   
                            <td><asp:Label runat="server" ID="lblDepartmentPhone2" Visible="true" Text="<%# Item.DepartmentPhone2 %>"></asp:Label>  </td>   
                            <td><asp:Label runat="server" ID="lblDepartmentPhone3" Visible="true" Text="<%# Item.DepartmentPhone3 %>"></asp:Label>  </td>   
                            <td><asp:Label runat="server" ID="lblDepartmentPhone4" Visible="true" Text="<%# Item.DepartmentPhone4 %>"></asp:Label>  </td>   
                            <td><asp:Label runat="server" ID="lblDepartmentDescrip" Visible="true" Text="<%# Item.DepartmentDescription %>"></asp:Label>  </td>   
                            
                            <td>                       
                                <asp:Button ID="EditButton" runat="server" Text="编辑" CommandName="Edit" CssClass="btn btn-primary" /> 
                            </td>
                            <td>    
                                <asp:Button ID="DeleteButton" runat="server" Text="删除" CommandName="Delete" CssClass="btn btn-danger" OnClientClick="javascript:return confirm('确认删除选中的用户记录？');"/> 
                            </td>
 
                        </tr>
                    </ItemTemplate>
                         <EditItemTemplate>
                            <tr>              
                                <td><asp:TextBox runat="server" ID="txtEditDepartmentName" Visible="true" CssClass="form-control" Text="<%#Item.DepartmentName %>"></asp:TextBox></td> 
                                <td><asp:TextBox runat="server" ID="txtEditDepartmentPhone1" Visible="true" CssClass="form-control" Text="<%#Item.DepartmentPhone1 %>"></asp:TextBox></td> 
                                <td><asp:TextBox runat="server" ID="txtEditDepartmentPhone2" Visible="true" CssClass="form-control" Text="<%#Item.DepartmentPhone2 %>"></asp:TextBox></td> 
                                <td><asp:TextBox runat="server" ID="txtEditDepartmentPhone3" Visible="true" CssClass="form-control" Text="<%#Item.DepartmentPhone3 %>"></asp:TextBox></td> 
                                <td><asp:TextBox runat="server" ID="txtEditDepartmentPhone4" Visible="true" CssClass="form-control" Text="<%#Item.DepartmentPhone4 %>"></asp:TextBox></td> 
                                <td><asp:TextBox runat="server" ID="txtEditDepartmentDescrip" Visible="true" CssClass="form-control" Text="<%#Item.DepartmentDescription %>"></asp:TextBox></td> 
                                
                                <td>
                                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-info"/>
                                </td>
                                <td>
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-warning"/>
                                </td>

                            </tr>
                        </EditItemTemplate>
                    <InsertItemTemplate>
                        <tr>
                            <td><asp:TextBox runat="server" ID="txtInsertDepartmentName" Visible="true" CssClass="form-control"></asp:TextBox></td> 
                            <td><asp:TextBox runat="server" ID="txtInsertDepartmentPhone1" Visible="true" CssClass="form-control"></asp:TextBox></td> 
                            <td><asp:TextBox runat="server" ID="txtInsertDepartmentPhone2" Visible="true" CssClass="form-control"></asp:TextBox></td> 
                            <td><asp:TextBox runat="server" ID="txtInsertDepartmentPhone3" Visible="true" CssClass="form-control"></asp:TextBox></td> 
                            <td><asp:TextBox runat="server" ID="txtInsertDepartmentPhone4" Visible="true" CssClass="form-control"></asp:TextBox></td> 
                            <td><asp:TextBox runat="server" ID="txtInsertDepartmentDescrip" Visible="true" CssClass="form-control"></asp:TextBox></td> 

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
