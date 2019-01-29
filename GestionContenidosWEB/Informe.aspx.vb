Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports System.Configuration

Partial Class Informe
    Inherits System.Web.UI.Page

    Dim cmd As New MySqlCommand
    Dim adap As New MySqlDataAdapter
    Dim ds As New DataSet

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Conexion.userCon = False Then
            Conexion.conectar()
            Dim sql As String = "SELECT name FROM lodging"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                Me.list_informe.Items.Add(dr.Item(0))
            End While
            dr.Close()
            Conexion.desconectar()
        Else
            Response.Redirect("~/InicioSesion.aspx")
        End If
      
    End Sub

    Protected Sub list_informe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list_informe.SelectedIndexChanged

        Dim rc As New ReportDocument
        rc.Load(Server.MapPath("report.rpt"))
        rc.RecordSelectionFormula = "{lodging1.name} = '" & Me.list_informe.SelectedValue & "'"
        CrystalReportViewer1.ReportSource = rc
        CrystalReportViewer1.Visible = True
    End Sub

End Class
