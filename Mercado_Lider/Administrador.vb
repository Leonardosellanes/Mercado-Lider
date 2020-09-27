Imports MySql.Data.MySqlClient

Public Class Administrador
    Dim conexion As MySqlConnection
    Dim cmd As New MySqlCommand
    Dim r As MySqlDataReader

    Public Sub New()
        'Esta llamada es exigida por el diseñador.
        conexion = New MySqlConnection
        conexion.ConnectionString = "Server=localhost; database=mercadolider; Uid=root; pwd=;"
        cmd.Connection = conexion
        InitializeComponent()
        'Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub AjustarGridArticulos()
        Dim contador As Integer
        For Each grd In dataGridArticulos.Rows
            Dim row As DataGridViewRow = dataGridArticulos.Rows(contador)
            row.Height = 150
            contador = contador + 1
            CType(dataGridArticulos.Columns("portada"), DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom
        Next
    End Sub
    Private Sub updateGridArticulos()
        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter
        Try
            conexion.Open()

            cmd.CommandText = "SELECT articulos.portada,articulos.id,articulos.Nombre,articulos.precio,articulos.stock,usuario.username As vendedor FROM articulos,usuario  WHERE articulos.usuario_id = usuario.id AND articulos.deleted=0"
            adaptador.SelectCommand = cmd
            adaptador.Fill(ds, "Tabla")
            dataGridArticulos.DataSource = ds
            dataGridArticulos.DataMember = "Tabla"
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conexion.Close()
        End Try
        AjustarGridArticulos()
    End Sub

    Private Sub updateGridUser()
        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter
        Try
            conexion.Open()


            cmd.CommandText = "SELECT usuario.username,useremail.email,usuario.password,usuario.rol FROM usuario,useremail WHERE usuario.id=useremail.user_id"
            adaptador.SelectCommand = cmd
            adaptador.Fill(ds, "Tabla")
            grdUsuarios.DataSource = ds
            grdUsuarios.DataMember = "Tabla"
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conexion.Close()
        End Try
        grdUsuarios.Columns(0).Width = 200
        grdUsuarios.Columns(1).Width = 200
        grdUsuarios.Columns(2).Width = 200
        grdUsuarios.Columns(3).Width = 190
    End Sub

    Private Sub updateGridTransacciones()
        grdTransacciones.Rows.Clear()

        Dim idCompra As Integer
        Dim comprador As String
        Dim fecha As Date
        Dim precioTotal As Integer
        Dim vendedor As String

        Try
            conexion.Open()
            cmd.CommandText = "SELECT compras.id,usuario.username,compras.Fecha,compras.PrecioTotal FROM usuario,compras WHERE compras.usuario_id=usuario.id"
            r = cmd.ExecuteReader()
            Dim r2 As MySqlDataReader
            While (r.Read)
                idCompra = r("id")
                comprador = r("username")
                fecha = r("Fecha")
                cmd.CommandText = "SELECT usuario.id,usuario.username As Vendedor, (detalle_compra.Cantidad * detalle_compra.PrecioUnitario) As Precio FROM usuario,compras,detalle_compra,articulos WHERE compras.id = detalle_compra.id_compra AND articulos.id = detalle_compra.id_articulo AND articulos.usuario_id = usuario.id AND compras.id=@idCompra"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@idCompra", idCompra)
                Dim precio As Integer = 0
                Dim trackerNombre As String = ""
                Dim trackerID As String = ""
                r2 = cmd.ExecuteReader
                While (r2.Read)
                    MsgBox(r2("id"))
                End While
                r2.Close()
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
            conexion.Close()
        End Try
        r.Close()

        'idCompra = r("id")
        'comprador = r("username")
        'precioTotal = r("Preciototal")

        'Dim portada = r("portada")
        'End If
        'precioTotal = precioTotal + (precio * elem.cantidad)

        'Dim subtotal = (precio * elem.cantidad).ToString + "$"

        'DataGridCart.Rows.Add(portada, id, nombre, precio, elem.cantidad, subtotal)
        'End If
        'r.Close()
        ' Next
        ' lblPrecioTotalCart.Text = precioTotal
        'conexion.Close()
        ' Catch ex As Exception
        '    MsgBox(ex.ToString)
        '   conexion.Close()
        '        End Try

        grdTransacciones.Columns(0).Width = 200
        grdTransacciones.Columns(1).Width = 200
        grdTransacciones.Columns(2).Width = 200
        grdTransacciones.Columns(3).Width = 190
    End Sub
    Private Sub Administrador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OcultarBarras()
        pnlArticulos.Show()
        updateGridArticulos() 'Actualiza el datagrid de articulos'
        AjustarGridArticulos()

        dataGridArticulos.Columns(0).Width = 150
        dataGridArticulos.Columns(1).Width = 100
        dataGridArticulos.Columns(2).Width = 160
        dataGridArticulos.Columns(3).Width = 130
        dataGridArticulos.Columns(4).Width = 130
        dataGridArticulos.Columns(5).Width = 150
        dataGridArticulos.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 15)
    End Sub
    Private Sub OcultarBarras()
        pnlArticulos.Visible = False
        pnlUsuarios.Visible = False
        pnlTransacciones.Visible = False
    End Sub
    Private Sub btnArticulos_Click(sender As Object, e As EventArgs) Handles btnArticulos.Click
        updateGridArticulos()
        tcAdmin.SelectedTab = tcAdmin.TabPages.Item(0)
        OcultarBarras()
        pnlArticulos.Visible = True
    End Sub
    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        tcAdmin.SelectedTab = tcAdmin.TabPages.Item(1)
        OcultarBarras()
        pnlUsuarios.Visible = True
        updateGridUser()


    End Sub
    Private Sub btnTransacciones_Click(sender As Object, e As EventArgs) Handles btnTransacciones.Click
        tcAdmin.SelectedTab = tcAdmin.TabPages.Item(2)
        OcultarBarras()
        pnlTransacciones.Visible = True
        updateGridTransacciones()
    End Sub
    Private Sub Administrador_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmPrincipal.Show()
    End Sub

    Private Sub dataGridArticulos_SelectionChanged(sender As Object, e As EventArgs) Handles dataGridArticulos.SelectionChanged
        If (dataGridArticulos.SelectedRows.Count > 0) Then
            idArtLabel.Text = dataGridArticulos.Item("id", dataGridArticulos.SelectedRows(0).Index).Value
            NomArtLbl.Text = dataGridArticulos.Item("Nombre", dataGridArticulos.SelectedRows(0).Index).Value
        End If
    End Sub

    Private Sub btnEliminar1_Click(sender As Object, e As EventArgs) Handles btnEliminar1.Click
        Dim idArt = idArtLabel.Text()

        Try
            conexion.Open()
            cmd.CommandText = "UPDATE articulos SET deleted=1 WHERE id=@idArt"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@idArt", idArt)
            cmd.ExecuteNonQuery()
            conexion.Close()
            updateGridArticulos()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conexion.Close()
        End Try
    End Sub

    Private Sub grdUsuarios_SelectionChanged(sender As Object, e As EventArgs)

    End Sub
End Class