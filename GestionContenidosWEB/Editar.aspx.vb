Imports MySql.Data.MySqlClient
Partial Class Editar
    Inherits System.Web.UI.Page
    Dim idUsuario As String
    Dim codeP, codeM, muni, type, category As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        idUsuario = Request.Params("id")

        If Not Page.IsPostBack Then
            fillTodo()
            fillType()
            fillCategory()
            fillMunicipality(codeM, codeP)
            fillCM(Me.municipalityAc.SelectedValue.ToString)
        End If

    End Sub

    Protected Sub fillTodo()
        Conexion.conectar()
        Try

            Dim sql As String = "SELECT name,phone,signatura,turismemail,address,postalcode,web,description,type,marks,coordinates,category,capacity,friendlyurl,physicalurl,zipfile,municipalitycode FROM lodging WHERE id = " & idUsuario
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            Me.idAc.Text = idUsuario

            While dr.Read
                If Not IsDBNull(dr.Item(0)) Then
                    Me.nameAc.Text = dr.Item(0)
                Else
                    Me.nameAc.Text = ""
                End If

                If Not IsDBNull(dr.Item(1)) Then
                    Me.phoneAc.Text = dr.Item(1)
                Else
                    Me.phoneAc.Text = ""
                End If

                If Not IsDBNull(dr.Item(2)) Then
                    Me.firmaAc.Text = dr.Item(2)
                Else
                    Me.firmaAc.Text = ""
                End If

                If Not IsDBNull(dr.Item(3)) Then
                    Me.emailAc.Text = dr.Item(3)
                Else
                    Me.emailAc.Text = ""
                End If

                If Not IsDBNull(dr.Item(4)) Then
                    Me.addressAc.Text = dr.Item(4)
                Else
                    Me.addressAc.Text = ""
                End If

                If Not IsDBNull(dr.Item(6)) Then
                    Me.webAc.Text = dr.Item(6)
                Else
                    Me.webAc.Text = ""
                End If

                codeP = dr.Item(5)

                If Not IsDBNull(dr.Item(7)) Then
                    Me.descripAc.Text = dr.Item(7)
                Else
                    Me.descripAc.Text = ""
                End If
                If Not IsDBNull(dr.Item(8)) Then
                    type = dr.Item(8)
                Else
                    type = ""
                End If

                If Not IsDBNull(dr.Item(9)) Then
                    Me.markAc.Text = dr.Item(9)
                Else
                    Me.markAc.Text = ""
                End If

                If Not IsDBNull(dr.Item(10)) Then
                    Me.coordinateAc.Text = dr.Item(10)
                Else
                    Me.coordinateAc.Text = ""
                End If

                If Not IsDBNull(dr.Item(11)) Then
                    category = dr.Item(11)
                Else
                    category = ""
                End If

                If Not IsDBNull(dr.Item(12)) Then
                    Me.capacityAc.Text = dr.Item(12)
                Else
                    Me.capacityAc.Text = ""
                End If

                If Not IsDBNull(dr.Item(13)) Then
                    Me.friendAc.Text = dr.Item(13)
                Else
                    Me.friendAc.Text = ""
                End If

                If Not IsDBNull(dr.Item(14)) Then
                    Me.physicalAc.Text = dr.Item(14)
                Else
                    Me.physicalAc.Text = ""
                End If

                If Not IsDBNull(dr.Item(15)) Then
                    Me.zipAc.Text = dr.Item(15)
                Else
                    Me.zipAc.Text = ""
                End If

                codeM = dr.Item(16)

            End While

            dr.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub

    Protected Sub fillType()
        Conexion.conectar()
        Try

            Dim sql As String = "SELECT DISTINCT type FROM lodging ORDER BY type ASC"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            While dr.Read
                Me.typeAc.Items.Add(dr.Item(0))
            End While

            dr.Close()

            Me.typeAc.SelectedValue = type

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
                Me.categoryAc.Items.Add(dr.Item(0))
            End While

            dr.Close()

            Me.categoryAc.SelectedValue = category

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub

    Protected Sub fillMunicipality(Optional cm As String = Nothing, Optional cp As String = Nothing)
        Conexion.conectar()
        Try

            Dim sql As String = "SELECT DISTINCT municipality FROM postalCode ORDER BY municipality ASC"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing
            dr = cmd.ExecuteReader()

            While dr.Read
                Me.municipalityAc.Items.Add(dr.Item(0))
            End While
            dr.Close()

            Dim sqlMu As String = "SELECT DISTINCT municipality FROM postalCode WHERE municipalitycode='" & cm & "' AND postalcode='" & cp & "' ORDER BY municipality ASC"
            Dim cmd2 As New MySqlCommand(sqlMu, Conexion.cnn1)
            Dim dr2 As MySqlDataReader = Nothing
            dr2 = cmd2.ExecuteReader

            While dr2.Read
                muni = dr2.Item(0)
            End While

            dr2.Close()

            Me.municipalityAc.SelectedValue = muni
            fillCM(Me.municipalityAc.SelectedValue.ToString)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub

    Protected Sub fillCM(Optional municipalityVar As String = Nothing)
        Conexion.conectar()
        Try

            Dim sql As String = "SELECT DISTINCT municipalitycode FROM postalCode WHERE municipality = '" & municipalityVar & "'"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            While dr.Read
                Me.cmAc.Text = dr.Item(0)
            End While

            dr.Close()

            fillCP(municipalityVar)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub
    Protected Sub fillCP(municipalityVar As String)
        Me.cpAc.Items.Clear()
        Conexion.conectar()
        Try
            Dim sql As String = "SELECT DISTINCT postalcode FROM postalCode WHERE municipalitycode=" & Me.cmAc.Text & " AND municipality='" & municipalityVar & "' ORDER BY postalcode ASC"

            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            While dr.Read
                Me.cpAc.Items.Add(dr.Item(0))
            End While

            dr.Close()

            Me.cpAc.SelectedValue = codeP

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub

    Protected Sub municipalityAc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles municipalityAc.SelectedIndexChanged
        fillCM(Me.municipalityAc.SelectedValue.ToString)
    End Sub

    Protected Sub canEditar_Click(sender As Object, e As EventArgs) Handles canEditar.Click
        Response.Redirect("~\PaginaPrincipal.aspx")
    End Sub

    Protected Sub finEditar_Click(sender As Object, e As EventArgs) Handles finEditar.Click
        Conexion.conectar()

        Try
            Dim sql As String = "UPDATE lodging SET signatura = '" & Me.firmaAc.Text & "', name = '" & Me.nameAc.Text & "', capacity=" & Me.capacityAc.Text & ",type='" & Me.typeAc.SelectedValue.ToString & "', category='" & Me.categoryAc.SelectedValue.ToString & "', phone = '" & Me.phoneAc.Text & "', marks='" & Me.markAc.Text & "', turismemail='" & Me.emailAc.Text & "', web = '" & Me.webAc.Text & "', address='" & Me.addressAc.Text & "', municipalitycode='" & Me.cmAc.Text & "', postalcode='" & Me.cpAc.SelectedValue.ToString & "', coordinates='" & Me.coordinateAc.Text & "', description='" & Me.descripAc.Text & "', friendlyurl='" & Me.friendAc.Text & "', physicalurl='" & Me.physicalAc.Text & "', zipfile='" & Me.zipAc.Text & "' WHERE lodging.id = " & idUsuario
            Dim commando As New MySqlCommand(sql, Conexion.cnn1)
            commando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Conexion.desconectar()

        Response.Redirect("~\PaginaPrincipal.aspx")

    End Sub

   
End Class
