Imports MySql.Data.MySqlClient
Partial Class Editar
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Conexion.userCon = False Then
            If Not IsPostBack Then
                fillType()
                fillCategory()
                fillMunicipality()
                fillCP(Me.municipalityIn.SelectedValue.ToString)
            End If
        Else
            Response.Redirect("~/InicioSesion.aspx")
        End If
        
    End Sub
    Protected Sub fillType()
        Conexion.conectar()
        Try

            Dim sql As String = "SELECT DISTINCT type FROM lodging ORDER BY type ASC"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            While dr.Read
                Me.tipoIn.Items.Add(dr.Item(0))
            End While

            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub
    Protected Sub fillCategory()
        Conexion.conectar()
        Try

            Dim sql As String = "SELECT DISTINCT category FROM lodging ORDER BY category ASC"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            While dr.Read
                Me.categoryIn.Items.Add(dr.Item(0))
            End While

            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub
    Protected Sub fillMunicipality()
        Conexion.conectar()
        Try
            Dim sql As String = "SELECT DISTINCT municipality FROM postalCode ORDER BY municipality ASC"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            While dr.Read
                Me.municipalityIn.Items.Add(dr.Item(0))
            End While

            fillCM(Me.municipalityIn.SelectedValue.ToString)

            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub
    Protected Sub fillCM(municipality As String)
        Conexion.conectar()
        Try
            Dim sql As String = "SELECT DISTINCT municipalitycode FROM postalCode WHERE municipality = '" & municipality & "'"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            While dr.Read
                Me.cmIn.Text = dr.Item(0)
            End While
            fillCP(municipality)
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub
    Protected Sub fillCP(municipality As String)
        Me.cpIn.Items.Clear()
        Conexion.conectar()
        Try
            Dim sql As String = "SELECT DISTINCT postalcode FROM postalCode WHERE municipalitycode=" & Me.cmIn.Text & " AND municipality='" & municipality & "' ORDER BY postalcode ASC"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            While dr.Read
                Me.cpIn.Items.Add(dr.Item(0))
            End While

            dr.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub

    Protected Sub municipalityIn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles municipalityIn.SelectedIndexChanged
        fillCM(Me.municipalityIn.SelectedValue.ToString)
    End Sub

    Protected Sub finInsertar_Click(sender As Object, e As EventArgs) Handles finInsertar.Click
        Conexion.conectar()

        Try
            Dim sql As String = "INSERT INTO lodging(id,signatura,name,description,type,phone,address,marks,postalcode,municipalitycode,coordinates,category,turismemail,web,capacity,friendlyurl,physicalurl,zipfile)"
            sql &= " VALUES (null,'" & Me.firmaIn.Text & "','" & Me.nameIn.Text & "','" & Me.descripIn.Text & "','" & Me.tipoIn.SelectedValue.ToString & "','" & Me.phoneIn.Text & "','" & Me.addressIn.Text & "','" & Me.markIn.Text & "','" & Me.cpIn.SelectedValue.ToString & "','" & Me.cmIn.Text & "','" & Me.coordinateIn.Text & "','" & Me.categoryIn.SelectedValue.ToString & "','" & Me.emailIn.Text & "','" & Me.webIn.Text & "'," & Me.capacityIn.Text & ",'" & Me.friendIn.Text & "','" & Me.physicalIn.Text & "','" & Me.physicalIn.Text & "')"          
            Dim commando As New MySqlCommand(sql, Conexion.cnn1)
            commando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Conexion.desconectar()
        Response.Redirect("~\PaginaPrincipal.aspx")

    End Sub

End Class
