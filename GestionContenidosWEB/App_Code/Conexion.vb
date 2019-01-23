Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Conexion
    Public Shared cnn1 As MySqlConnection

    Public Shared concectado As Boolean = False

    Public Shared Sub conectar()
        Dim cadenaconexion As String = "server=kasserver.synology.me;database=reto_gp4;user id=gp4;port=3307; password=MmlYOc8DvJXQns7D;"
        'Dim cadenaconexion As String = "server=localhost;database=hola;user id=root; password=;"
        cnn1 = New MySqlConnection(cadenaconexion)

        Try
            If cnn1.State = ConnectionState.Closed Then
                cnn1.Open()
            End If

        Catch ex As Exception


        End Try
    End Sub
    Public Shared Sub desconectar()
        Dim cadenaconexion As String = "server=kasserver.synology.me;database=reto_gp4;user id=gp4;port=3307; password=MmlYOc8DvJXQns7D;"
        'Dim cadenaconexion As String = "server=localhost;database=hola;user id=root; password=;"
        cnn1 = New MySqlConnection(cadenaconexion)

        Try
            If cnn1.State = ConnectionState.Open Then
                cnn1.Close()
            End If



        Catch ex As Exception


        End Try
    End Sub
End Class
