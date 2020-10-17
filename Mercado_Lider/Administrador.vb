Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class Administrador
    Dim conexion As MySqlConnection
    Dim cmd As New MySqlCommand
    Dim r As MySqlDataReader

    Dim id As Integer

    Public Sub New(ByVal idAdmin As Integer)

        Me.id = idAdmin

        'Esta llamada es exigida por el diseñador.
        conexion = New MySqlConnection
        conexion.ConnectionString = "Server=localhost;  database=mercadolider; Uid=root; pwd=;"
        cmd.Connection = conexion
        InitializeComponent()
        'Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Function generarClaveSHA1(ByVal cadena As String) As String
        Dim enc As New UTF8Encoding
        Dim data() As Byte = enc.GetBytes(cadena)
        Dim result() As Byte
        Dim sha As New SHA1CryptoServiceProvider

        result = sha.ComputeHash(data)
        Dim sb As New StringBuilder
        Dim max As Int32 = result.Length

        For i As Integer = 0 To max - 1
            'Convertimos los valores en hexadecimal
            'cuando tiene una cifra hay que rellenarlo con cero
            'para que siempre ocupen dos dígitos.
            If (result(i) < 16) Then
                sb.Append("0")
            End If
            sb.Append(result(i).ToString("x"))
        Next
        'Devolvemos la cadena con el hash en mayúsculas
        generarClaveSHA1 = sb.ToString().ToUpper()
        Return generarClaveSHA1
    End Function




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

            cmd.CommandText = "SELECT usuario.id,usuario.username,useremail.email,usuario.password,usuario.rol FROM usuario,useremail WHERE usuario.id=useremail.user_id AND usuario.id!=@idadmin AND usuario.deleted=0"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@idadmin", id)

            adaptador.SelectCommand = cmd
            adaptador.Fill(ds, "Tabla")
            grdUsuarios.DataSource = ds
            grdUsuarios.DataMember = "Tabla"
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conexion.Close()
        End Try
        grdUsuarios.Columns(0).Width = 80
        grdUsuarios.Columns(1).Width = 200
        grdUsuarios.Columns(2).Width = 200
        grdUsuarios.Columns(3).Width = 190
    End Sub



    Private Sub getPagoYVendedor(ByVal idCompra As Integer, ByVal comprador As String, ByVal fecha As Date)

        Dim con As New MySqlConnection
        con.ConnectionString = "Server=localhost; database=mercadolider; Uid=root; pwd=;"

        Dim cmd As New MySqlCommand
        Dim rd As MySqlDataReader

        Try
            con.Open()
            cmd.Connection = con

            cmd.CommandText = "SELECT usuario.id,usuario.username As Vendedor, (detalle_compra.Cantidad * detalle_compra.PrecioUnitario) As Precio FROM usuario,compras,detalle_compra,articulos WHERE compras.id = detalle_compra.id_compra AND articulos.id = detalle_compra.id_articulo AND articulos.usuario_id = usuario.id AND compras.id=@idCompra ORDER BY Vendedor"
            cmd.Parameters.AddWithValue("@idCompra", idCompra)

            rd = cmd.ExecuteReader

            Dim anteriorID = 0
            Dim anteriorPrecioTotal = 0
            Dim anteriorVendedor = ""

            Dim precioTotal = 0
            Dim Vendedor = ""

            While (rd.Read())

                Dim idVendedor = CInt(Int(rd("id")))
                If (idVendedor = anteriorID) Then


                    precioTotal = precioTotal + CInt(Int(rd("Precio")))


                Else
                    If (anteriorID <> 0) Then 'entra aqui sabemos que se trata de el primer registro con ese id

                        precioTotal = 0
                        precioTotal = rd("Precio")
                        Vendedor = rd("Vendedor")
                        grdTransacciones.Rows.Add(idCompra, comprador, fecha, anteriorPrecioTotal, anteriorVendedor)


                    Else
                        precioTotal = rd("Precio") '' Si entra aqui sabemos que se trata de el primer registro
                        Vendedor = rd("Vendedor")

                    End If
                End If
                anteriorID = rd("id")
                anteriorPrecioTotal = precioTotal
                anteriorVendedor = Vendedor


            End While

            grdTransacciones.Rows.Add(idCompra, comprador, fecha, anteriorPrecioTotal, anteriorVendedor)



            rd.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)




        End Try
        con.Close()


    End Sub

    Private Sub updateGridTransacciones()
        Dim con As New MySqlConnection
        con.ConnectionString = "Server=localhost; database=mercadolider; Uid=root; pwd=;"

        Dim cmd As New MySqlCommand
        cmd.Connection = con
        Dim rd As MySqlDataReader





        grdTransacciones.Rows.Clear()
        Try

            con.Open()

            cmd.CommandText = "SELECT compras.id,usuario.username,compras.Fecha,compras.PrecioTotal FROM usuario,compras WHERE compras.usuario_id=usuario.id ORDER BY compras.Fecha DESC"
            rd = cmd.ExecuteReader()

            Dim idCompra As Integer
            Dim comprador As String
            Dim fecha As Date


            While (rd.Read())

                idCompra = rd("id")
                comprador = rd("username")
                fecha = rd("Fecha")


                getPagoYVendedor(idCompra, comprador, fecha)




            End While
            rd.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
        con.Close()
        grdTransacciones.Columns(0).Width = 100
        grdTransacciones.Columns(1).Width = 200
        grdTransacciones.Columns(2).Width = 200
        grdTransacciones.Columns(3).Width = 190
    End Sub
    Private Sub Administrador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OcultarBarras()
        pnlArticulos.Show()
        updateGridArticulos() 'Actualiza el datagrid de articulos'
        AjustarGridArticulos()


        Me.Timer1.Enabled = True

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
        frmPrincipal.tbTodos.SelectedTab = frmPrincipal.tbTodos.TabPages.Item(0)
    End Sub

    Private Sub dataGridArticulos_SelectionChanged(sender As Object, e As EventArgs) Handles dataGridArticulos.SelectionChanged
        If (dataGridArticulos.SelectedRows.Count > 0) Then
            idArtLabel.Text = dataGridArticulos.Item("id", dataGridArticulos.SelectedRows(0).Index).Value
            NomArtLbl.Text = dataGridArticulos.Item("Nombre", dataGridArticulos.SelectedRows(0).Index).Value
        End If
    End Sub

    Private Sub btnEliminar1_Click(sender As Object, e As EventArgs) Handles btnEliminar1.Click
        Dim idArt = idArtLabel.Text()
        Dim NombreArt = dataGridArticulos.Item("Nombre", dataGridArticulos.SelectedRows(0).Index).Value

        Dim resultado = MsgBox("Seguro que quieres eliminar el articulo:" & NombreArt & " con ID:" & idArt & " ", vbOKCancel, "ELIMINAR ARTICULO")

        If resultado = vbOK Then

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
        End If
    End Sub

    Private Sub btnEliminarUser_Click(sender As Object, e As EventArgs) Handles btnEliminarUser.Click

        Dim id = grdUsuarios.Item("id", grdUsuarios.SelectedRows(0).Index).Value
        Dim username = grdUsuarios.Item("username", grdUsuarios.SelectedRows(0).Index).Value
        Dim resultado = MsgBox("Seguro que quieres eliminar al usuario:" & username & " con ID:" & id & " ", vbOKCancel, "ELIMINAR USUARIO")

        If resultado = vbOK Then
            Try
                conexion.Open()
                cmd.CommandText = "UPDATE usuario SET deleted=@deleted WHERE id=@idUser"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@deleted", 1)
                cmd.Parameters.AddWithValue("@idUser", id)

                cmd.ExecuteNonQuery()



                MsgBox("Usuario eliminado exitosamente")

                conexion.Close()

                updateGridUser()



            Catch ex As Exception
                MsgBox(ex.ToString)
                conexion.Close()
            End Try
        End If


    End Sub

    Private Sub btnContraseña_Click(sender As Object, e As EventArgs) Handles btnContraseña.Click
        If txtSetContra.Text = "" Then
            lblPassVacia.Text = "*Este campo no puede estar vacio"
            lblPassVacia.Visible = True
        Else
            If txtSetContra.TextLength < 6 Then
                lblPassVacia.Text = "*La contraseña debe tener mas de 6 caracteres"
                lblPassVacia.Visible = True
            Else
                Dim id = grdUsuarios.Item("id", grdUsuarios.SelectedRows(0).Index).Value
                Dim username = grdUsuarios.Item("username", grdUsuarios.SelectedRows(0).Index).Value
                Dim resultado = MsgBox("Seguro que quieres cambiarle la contraseña al usuario:" & username & " con ID:" & id & " ", vbOKCancel, "CAMBIAR CONTRASEÑA")

                If resultado = vbOK Then
                    Try
                        conexion.Open()
                        cmd.CommandText = "UPDATE usuario SET password=@passEncrypy WHERE id=@idUser"
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@passEncrypy", generarClaveSHA1(txtSetContra.Text))
                        cmd.Parameters.AddWithValue("@idUser", id)

                        cmd.ExecuteNonQuery()
                        lblPassCambiada.Visible = True
                        conexion.Close()
                        updateGridUser()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                        conexion.Close()
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub btnAgregarAdmin_Click(sender As Object, e As EventArgs) Handles btnAgregarAdmin.Click
        Dim id = grdUsuarios.Item("id", grdUsuarios.SelectedRows(0).Index).Value
        Dim username = grdUsuarios.Item("username", grdUsuarios.SelectedRows(0).Index).Value
        Dim resultado = MsgBox("Seguro que quieres asignarle el rol de aministrador a :" & username & " con ID:" & id & " ?", vbOKCancel, "CAMBIAR ROL")

        If resultado = vbOK Then
            Try
                conexion.Open()
                cmd.CommandText = "UPDATE usuario SET rol='Administrador' WHERE id=@idUser"
                cmd.Parameters.Clear()

                cmd.Parameters.AddWithValue("@idUser", id)

                cmd.ExecuteNonQuery()

                MsgBox("Ahora el usuario:" & username & " tiene rol administrador")




                conexion.Close()

                updateGridUser()
            Catch ex As Exception
                MsgBox(ex.ToString)
                conexion.Close()
            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick  ''Evento Timer que ejecuta el bloque interno cada 3 segundos'
        updateGridTransacciones()    ''Llama a la funcion que actualiza el datagrid de visualizacion de transacciones.
    End Sub
    Private Sub txtSetContra_Click(sender As Object, e As EventArgs) Handles txtSetContra.Click
        lblPassVacia.Visible = False
        lblPassCambiada.Visible = False
    End Sub
    Private Sub txtSetContra_TextChanged(sender As Object, e As EventArgs) Handles txtSetContra.TextChanged
        lblPassVacia.Visible = False
        lblPassCambiada.Visible = False
    End Sub
End Class