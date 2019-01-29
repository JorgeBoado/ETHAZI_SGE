Imports MySql.Data.MySqlClient
Imports System.Data
Partial Class PaginaPrincipal
    Inherits System.Web.UI.Page
    Dim das1 As New DataSet
    Dim lat, lon, name, address, postalcode As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Conexion.userCon = False Then
            If Not IsPostBack Then
                mostrarTabla()
                fillTerritoryFiltro()
                fillMunicipioFiltro(Me.territoryFiltro.SelectedValue.ToString)
                fillCPFiltro(Me.municipioFiltro.SelectedValue.ToString)
                fillTypeFiltro()
                fillCategoryFiltro()
            End If
        Else
            Response.Redirect("~/InicioSesion.aspx")
        End If
            
    End Sub

    Private Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
        mostrarTabla()
    End Sub

    Private Sub mostrarTabla(Optional terr As String = Nothing, Optional muni As String = Nothing, Optional cp As String = Nothing, Optional type As String = Nothing, Optional cat As String = Nothing, Optional nombre As String = Nothing)
        Me.GridView1.DataBind()
        Conexion.conectar()
        Me.GridView1.AutoGenerateSelectButton = True
        Dim sql As String = Nothing

        If Not terr = Nothing And terr <> "-Todas-" And muni = Nothing Or muni = "-Todas-" Then
            sql = "SELECT id as ID,signatura as Signatura,name as Name,CONCAT(SUBSTRING(description,1,50),'...') as Description,type as Type,phone as Phone,address as Address,marks as Mark, postalcode as PC,municipalitycode as MC,coordinates as Coordinates,category as Category,turismemail as Email,web as WEB,capacity as Capacity,friendlyurl as FriendlyUrl,physicalurl as PhysicalUrl,zipfile as ZipFile FROM lodging WHERE postalcode IN (SELECT postalcode FROM postalCode WHERE territory = '" & terr & "')"
        ElseIf Not terr = Nothing And terr <> "-Todas-" And muni = "-Todas-" And cp = "-Todas-" Then
            sql = "SELECT id as ID,signatura as Signatura,name as Name,CONCAT(SUBSTRING(description,1,50),'...') as Description,type as Type,phone as Phone,address as Address,marks as Mark, postalcode as PC,municipalitycode as MC,coordinates as Coordinates,category as Category,turismemail as Email,web as WEB,capacity as Capacity,friendlyurl as FriendlyUrl,physicalurl as PhysicalUrl,zipfile as ZipFile FROM lodging WHERE postalcode IN (SELECT postalcode FROM postalCode WHERE territory = '" & terr & "')"
        ElseIf Not terr = Nothing And terr <> "-Todas-" And Not muni = Nothing And muni <> "-Todas-" And cp = Nothing Or cp = "-Todas-" Then
            sql = "SELECT id as ID,signatura as Signatura,name as Name,CONCAT(SUBSTRING(description,1,50),'...') as Description,type as Type,phone as Phone,address as Address,marks as Mark, postalcode as PC,municipalitycode as MC,coordinates as Coordinates,category as Category,turismemail as Email,web as WEB,capacity as Capacity,friendlyurl as FriendlyUrl,physicalurl as PhysicalUrl,zipfile as ZipFile FROM lodging WHERE postalcode IN (SELECT postalcode FROM postalCode WHERE territory = '" & terr & "' AND municipality='" & muni & "')"
        ElseIf Not muni = Nothing And muni <> "-Todas-" And Not cp = Nothing And cp <> "Todas" Then
            sql = "SELECT id as ID,signatura as Signatura,name as Name,CONCAT(SUBSTRING(description,1,50),'...') as Description,type as Type,phone as Phone,address as Address,marks as Mark, postalcode as PC,municipalitycode as MC,coordinates as Coordinates,category as Category,turismemail as Email,web as WEB,capacity as Capacity,friendlyurl as FriendlyUrl,physicalurl as PhysicalUrl,zipfile as ZipFile FROM lodging WHERE postalcode IN (SELECT postalcode FROM postalCode WHERE postalcode='" & cp & "')"
        Else
            sql = "SELECT id as ID,signatura as Signatura,name as Name,CONCAT(SUBSTRING(description,1,50),'...') as Description,type as Type,phone as Phone,address as Address,marks as Mark, postalcode as PC,municipalitycode as MC,coordinates as Coordinates,category as Category,turismemail as Email,web as WEB,capacity as Capacity,friendlyurl as FriendlyUrl,physicalurl as PhysicalUrl,zipfile as ZipFile FROM lodging WHERE 1 = 1"
        End If

        If Not nombre = Nothing Then
            sql = "SELECT id as ID,signatura as Signatura,name as Name,CONCAT(SUBSTRING(description,1,50),'...') as Description,type as Type,phone as Telefono,address as Address,marks as Mark, postalcode as CP,municipalitycode as CM,coordinates as Coordinates,category as Category,turismemail as Email,web as WEB,capacity as Capacity,friendlyurl as FriendlyUrl,physicalurl as PhysicalUrl,zipfile as ZipFile FROM lodging WHERE name LIKE '%" & nombre & "%'"
        End If

        If Not type = Nothing And type <> "-Todas-" And cat = Nothing Or cat = "-Todas-" Then
            sql &= " AND type='" & type & "'"
        ElseIf Not cat = Nothing And cat <> "-Todas-" And type = Nothing Or type = "-Todas-" Then
            sql &= " AND category='" & cat & "'"
        ElseIf Not cat = Nothing And cat <> "-Todas-" And Not cat = Nothing And cat <> "-Todas-" Then
            sql &= " AND category='" & cat & "' AND type='" & type & "'"
        End If

        Dim commando As New MySqlCommand(sql, Conexion.cnn1)
        Dim adapter As New MySqlDataAdapter(commando)
        Try
            adapter.Fill(das1, "Cliente")
            Me.GridView1.DataSource = das1.Tables("Cliente")
            Me.GridView1.DataBind()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Conexion.desconectar()

    End Sub

    Protected Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click

        Conexion.conectar()
        Dim sql As String
        Try
            sql = "DELETE FROM lodging WHERE id = " & Me.GridView1.SelectedRow.Cells(1).Text
            Dim commando As New MySqlCommand(sql, Conexion.cnn1)
            commando.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        mostrarTabla()
        Conexion.desconectar()
    End Sub

    Protected Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        Response.Redirect("~/Editar.aspx?id=" & Me.GridView1.SelectedRow.Cells(1).Text)
    End Sub

    Protected Sub btn_insertar_Click(sender As Object, e As EventArgs) Handles btn_insertar.Click
        Response.Redirect("~/Insertar.aspx")
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Me.btn_actualizar.Enabled = True
        Me.btn_eliminar.Enabled = True
        Me.btn_mapa.Enabled = True
    End Sub

    Protected Sub fillMunicipioFiltro(Optional terr As String = Nothing)
        Me.municipioFiltro.Items.Clear()
        Conexion.conectar()
        Try

            Dim sql As String = Nothing

            If Not terr = Nothing Then
                sql = "SELECT DISTINCT municipality FROM postalCode WHERE territory='" & terr & "' ORDER BY municipality ASC"
            Else
                sql = "SELECT DISTINCT municipality FROM postalCode ORDER BY municipality ASC"
            End If

            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            Me.municipioFiltro.Items.Add("-Todas-")

            While dr.Read
                Me.municipioFiltro.Items.Add(dr.Item(0))
            End While

            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub

    Protected Sub fillCPFiltro(Optional muni As String = Nothing)
        Me.CPFiltro.Items.Clear()
        Conexion.conectar()
        Try
            Dim sql As String
            If Not muni = Nothing Then
                sql = "SELECT DISTINCT postalcode FROM postalCode WHERE municipality='" & muni & "' ORDER BY postalcode ASC"
            Else
                sql = "SELECT DISTINCT postalcode FROM postalCode ORDER BY postalcode ASC"
            End If


            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            Me.CPFiltro.Items.Add("-Todas-")

            While dr.Read
                Me.CPFiltro.Items.Add(dr.Item(0))
            End While

            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub

    Protected Sub fillTerritoryFiltro()
        Conexion.conectar()
        Try

            Dim sql As String = "SELECT DISTINCT territory FROM postalCode ORDER BY territory ASC"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            Me.territoryFiltro.Items.Add("-Todas-")

            While dr.Read
                Me.territoryFiltro.Items.Add(dr.Item(0))
            End While

            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub

    Protected Sub fillTypeFiltro()
        Conexion.conectar()
        Try

            Dim sql As String = "SELECT DISTINCT type FROM lodging ORDER BY type ASC"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            Me.TipoFiltro.Items.Add("-Todas-")

            While dr.Read
                Me.TipoFiltro.Items.Add(dr.Item(0))
            End While

            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub

    Protected Sub fillCategoryFiltro()

        Conexion.conectar()
        Try

            Dim sql As String = "SELECT DISTINCT category FROM lodging ORDER BY category ASC"
            Dim cmd As New MySqlCommand(sql, Conexion.cnn1)
            Dim dr As MySqlDataReader = Nothing

            dr = cmd.ExecuteReader()

            Me.CategoriaFiltro.Items.Add("-Todas-")

            While dr.Read
                Me.CategoriaFiltro.Items.Add(dr.Item(0))
            End While

            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Conexion.desconectar()
    End Sub

    Protected Sub territoryFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles territoryFiltro.SelectedIndexChanged
        fillMunicipioFiltro(Me.territoryFiltro.SelectedValue.ToString)
        mostrarTabla(Me.territoryFiltro.SelectedValue.ToString)
        If Not Me.territoryFiltro.SelectedValue = "-Todas-" Then
            Me.municipioFiltro.Enabled = True
        Else
            Me.CPFiltro.Enabled = False
            Me.municipioFiltro.Enabled = False
        End If

    End Sub

    Protected Sub municipioFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles municipioFiltro.SelectedIndexChanged
        fillCPFiltro(Me.municipioFiltro.SelectedValue.ToString)
        mostrarTabla(Me.territoryFiltro.SelectedValue.ToString, Me.municipioFiltro.SelectedValue.ToString)

        If Not Me.municipioFiltro.SelectedValue = "-Todas-" Then
            Me.CPFiltro.Enabled = True
        Else
            Me.CPFiltro.Enabled = False
        End If
    End Sub

    Protected Sub CPFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CPFiltro.SelectedIndexChanged
        mostrarTabla(Me.territoryFiltro.SelectedValue.ToString, Me.municipioFiltro.SelectedValue.ToString, Me.CPFiltro.SelectedValue.ToString)
    End Sub

    Protected Sub TipoFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TipoFiltro.SelectedIndexChanged
        If Me.territoryFiltro.SelectedValue.ToString = "-Todas-" And Me.CategoriaFiltro.SelectedValue.ToString = "-Todas-" And Me.TipoFiltro.SelectedValue.ToString <> "-Todas-" Then
            mostrarTabla(, , , Me.TipoFiltro.SelectedValue.ToString, )
        ElseIf Me.territoryFiltro.SelectedValue.ToString = "-Todas-" And Me.CategoriaFiltro.SelectedValue.ToString <> "-Todas-" And Me.TipoFiltro.SelectedValue.ToString <> "-Todas-" Then
            mostrarTabla(, , , Me.TipoFiltro.SelectedValue.ToString, Me.CategoriaFiltro.SelectedValue.ToString)
        ElseIf Me.territoryFiltro.SelectedValue.ToString = "-Todas-" And Me.TipoFiltro.SelectedValue.ToString = "-Todas-" And Me.CategoriaFiltro.SelectedValue.ToString = "-Todas-" Then
            mostrarTabla()
        ElseIf Me.territoryFiltro.SelectedValue.ToString = "-Todas-" And Me.TipoFiltro.SelectedValue.ToString = "-Todas-" And Me.CategoriaFiltro.SelectedValue.ToString <> "-Todas-" Then
            mostrarTabla(, , , , Me.CategoriaFiltro.SelectedValue.ToString)
        End If

    End Sub

    Protected Sub CategoriaFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CategoriaFiltro.SelectedIndexChanged
        If Me.territoryFiltro.SelectedValue.ToString = "-Todas-" And Me.TipoFiltro.SelectedValue.ToString = "-Todas-" And Me.CategoriaFiltro.SelectedValue.ToString <> "-Todas-" Then
            mostrarTabla(, , , , Me.CategoriaFiltro.SelectedValue.ToString)
        ElseIf Me.territoryFiltro.SelectedValue.ToString = "-Todas-" And Me.TipoFiltro.SelectedValue.ToString <> "-Todas-" And Me.CategoriaFiltro.SelectedValue.ToString <> "-Todas-" Then
            mostrarTabla(, , , Me.TipoFiltro.SelectedValue.ToString, Me.CategoriaFiltro.SelectedValue.ToString)
        ElseIf Me.territoryFiltro.SelectedValue.ToString = "-Todas-" And Me.CategoriaFiltro.SelectedValue.ToString = "-Todas-" And Me.TipoFiltro.SelectedValue.ToString = "-Todas-" Then
            mostrarTabla()
        ElseIf Me.territoryFiltro.SelectedValue.ToString = "-Todas-" And Me.CategoriaFiltro.SelectedValue.ToString = "-Todas-" And Me.TipoFiltro.SelectedValue.ToString <> "-Todas-" Then
            mostrarTabla(, , , Me.TipoFiltro.SelectedValue.ToString, )
        End If
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            Me.CheckBox2.Checked = False
            Me.CheckBox3.Checked = False
            Me.btn_buscarFiltro.Enabled = False
            Me.buscarFiltro.Enabled = False
            Me.territoryFiltro.Enabled = True
            Me.TipoFiltro.Enabled = False
            Me.CategoriaFiltro.Enabled = False
            mostrarTabla()
        Else
            Me.territoryFiltro.SelectedValue = "-Todas-"
            Me.municipioFiltro.SelectedValue = "-Todas-"
            Me.CPFiltro.SelectedValue = "-Todas-"
            Me.territoryFiltro.Enabled = False
            Me.municipioFiltro.Enabled = False
            Me.CPFiltro.Enabled = False
            mostrarTabla()
        End If

    End Sub

    Protected Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Me.CheckBox1.Checked = False
            Me.CheckBox3.Checked = False
            Me.btn_buscarFiltro.Enabled = False
            Me.buscarFiltro.Enabled = False
            Me.territoryFiltro.Enabled = False
            Me.TipoFiltro.Enabled = True
            Me.CategoriaFiltro.Enabled = True
            mostrarTabla()
        Else
            Me.TipoFiltro.SelectedValue = "-Todas-"
            Me.CategoriaFiltro.SelectedValue = "-Todas-"
            Me.TipoFiltro.Enabled = False
            Me.CategoriaFiltro.Enabled = False
            mostrarTabla()
        End If
       
    End Sub

    Protected Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged

        If CheckBox3.Checked = True Then
            Me.CheckBox1.Checked = False
            Me.CheckBox2.Checked = False
            Me.btn_buscarFiltro.Enabled = True
            Me.buscarFiltro.Enabled = True
            Me.TipoFiltro.Enabled = False
            Me.CategoriaFiltro.Enabled = False
            Me.territoryFiltro.Enabled = False
            mostrarTabla()
        Else
            Me.buscarFiltro.Text = ""
            Me.buscarFiltro.Enabled = False
            Me.btn_buscarFiltro.Enabled = False
            mostrarTabla()
        End If

       
    End Sub

    Protected Sub btn_buscarFiltro_Click(sender As Object, e As EventArgs) Handles btn_buscarFiltro.Click
        mostrarTabla(, , , , , Me.buscarFiltro.Text)
    End Sub

    Protected Sub btn_mapa_Click(sender As Object, e As EventArgs) Handles btn_mapa.Click

        Response.Redirect("~/Maps.aspx?id=" & Me.GridView1.SelectedRow.Cells(1).Text)

    End Sub

End Class
