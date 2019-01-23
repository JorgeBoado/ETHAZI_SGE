
Imports MySql.Data.MySqlClient
Imports System.Data
Partial Class _Default
    Inherits Page
    Dim das1 As New DataSet
    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        Conexion.conectar()
        mostrarTabla()
    End Sub
    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
        mostrarTabla()
        'Me.GridView1.Visible = True
        'Me.GridView1.DataSource = das1.Tables("Cliente")
        'GridView1.DataBind()
    End Sub

    Private Sub mostrarTabla()
        Dim sql As String
        Dim mistring As String = ""
        sql = "SELECT * FROM lodging"
        Dim commando As New MySqlCommand(sql, Conexion.cnn1)
        Dim adapter As New MySqlDataAdapter(commando)

        adapter.Fill(das1, "Cliente")
        Me.GridView1.Width = 50
        Me.GridView1.Height = 100
        Me.GridView1.DataSource = das1.Tables("Cliente")
        Me.GridView1.DataBind()
    End Sub


End Class