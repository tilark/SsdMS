<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SsdMS.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="Content/bootstrap-datetimepicker.min.css" />
    <div class="col-md-12">
        <div class="form-group">
            <div class='input-group date birthdate' id='datetimepicker2'>
                <asp:TextBox ID="txtBirthDate" CssClass="form-control" runat="server"></asp:TextBox>
                <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $('#datetimepicker1').datetimepicker();
            $('.birthdate').datetimepicker({
                locale: 'zh-cn',
                viewMode: 'years',
                format: 'YYYY/MM/DD'
            });
        });
    </script>
    <script type="text/javascript" src="Scripts/moment-with-locales.min.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap-datetimepicker.min.js"></script>

</asp:Content>
