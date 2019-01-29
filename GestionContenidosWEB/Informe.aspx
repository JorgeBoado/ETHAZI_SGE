<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Informe.aspx.vb" Inherits="Informe" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <br />
    <div class="row">
        <div class="col-4">
            <label>Select</label>
            <asp:DropDownList ID="list_informe" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
        </div>
    </div>
    <br />
    <br />
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" Height="1202px" ReportSourceID="CrystalReportSource1" ToolPanelView="None" ToolPanelWidth="200px" Width="1104px" Visible="False" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="report.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

