Imports MySql.Data.MySqlClient
Partial Class Maps
    Inherits System.Web.UI.Page

    Dim idUser As String
    Dim coor, name, address, postalcode As String
    
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'If Not Page.IsPostBack Then
        idUser = Request.Params("id")
        getDatos()
        fillMap()
        'End If
        Me.nameTi.Text = name
    End Sub

    Protected Sub getDatos()
        Conexion.conectar()
        Try
            Dim sql As String = "SELECT name,address,postalcode,coordinates FROM lodging WHERE id=" & idUser
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            While dr.Read
                name = dr.Item(0)
                address = dr.Item(1)
                postalcode = dr.Item(2)
                coor = dr.Item(3)
            End While

            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub

    Protected Sub fillMap()
        Dim latLon() As String = coor.Split(",")
        Dim script As String = "<script type='text/javascript'>google.maps.event.addDomListener(window, 'load',function(){ init_map('" & name & "','" & address & "','" & postalcode & "'," & latLon(0) & "," & latLon(1) & ")});</script>"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "loadMap", script, False)
    End Sub

    Protected Sub btn_volver_Click(sender As Object, e As EventArgs) Handles btn_volver.Click
        Response.Redirect("~/PaginaPrincipal.aspx")
    End Sub
End Class
