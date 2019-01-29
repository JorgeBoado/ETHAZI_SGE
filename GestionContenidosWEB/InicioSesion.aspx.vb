Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.Security.Cryptography

Partial Class InicioSesion

    Inherits System.Web.UI.Page
    Dim das1 As New DataSet
    Dim usuarios As New ArrayList
    Dim passwords As New ArrayList
    Dim dr As MySqlDataReader
    Dim sql As String

    Protected Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click

        Dim adap1 As New MySqlDataAdapter
        Dim cmd1 As New MySqlCommand

        Dim cadena As String = ""
        Dim nombrecorrecto As Boolean
        Dim passcorrecta As Boolean

        For Each item In usuarios
            If txtNombre.Text = item Then
                nombrecorrecto = True
            End If
        Next
        For Each item2 In passwords
            If encriptar(txtPassword.Text) = item2 Then
                passcorrecta = True
            End If
        Next
        If nombrecorrecto And passcorrecta Then
            Conexion.userCon = True
            Response.Redirect("PaginaPrincipal.aspx")
            Me.lblMensaje.Visible = False


        Else
            Me.lblMensaje.Visible = True
            Me.lblMensaje.Text = "Usuario no identificado"
        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Conexion.conectar()

        Catch ex As Exception
            MsgBox("No se pudo conectar " & ex.Message)
        End Try
        sql = " SELECT nick, pass FROM admins"
        Dim cmd1 As New MySqlCommand(sql, Conexion.cnn1)
        Dim linea As String = ""
        Dim pass As String = ""
        dr = cmd1.ExecuteReader
        While dr.Read

            linea = dr(0)
            pass = dr(1)
            usuarios.Add(linea)
            passwords.Add(pass)
        End While

        Conexion.userCon = False

    End Sub


    Function encriptar(pass As String) As String
        Dim SHA256 As SHA256 = SHA256Managed.Create()
        Dim hash() As Byte = SHA256.ComputeHash(Encoding.UTF8.GetBytes(pass))

        Dim res As String = ""
        For i = 0 To hash.Length - 1
            res &= hash(i).ToString("X2")
        Next

        Return res.ToLower
    End Function

End Class

