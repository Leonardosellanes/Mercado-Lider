Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Public Class frmPrincipal

#Region "Funciones del Programa y del formulario"
    Dim conexion As MySqlConnection
    Dim cmd As New MySqlCommand

    Dim r As MySqlDataReader

    ''Informacion de usuario''

    Dim sesion As Boolean = False
    Dim ID As Integer = Nothing
    Dim Username As String
    Dim Nombre As String
    Dim Apellido As String
    Dim Email As String
    Dim Rol As String
    Dim CI As String
    Dim Telefono As String


    Dim carrito As New ArrayList

    Dim stock As Boolean


    'Objeto frmDomicilio para control de frm de domicilio'
    Dim frmDomicilio As Domicilio = New Domicilio
    Public Sub New()
        'Esta llamada es exigida por el diseñador.
        conexion = New MySqlConnection
        conexion.ConnectionString = "Server=localhost; database=mercadolider; Uid=root; pwd=;"
        cmd.Connection = conexion

        InitializeComponent()

        'Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    'Metodos utiles que usaremos

    ''Checking que lo ingresado sea un correo ,recibe por parametro un string y retorna true si se trata de una direccion de correo
    Private Function VerificarCorreo(val As String) As String
        Dim par As String
        par = "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
        If Regex.IsMatch(val, par) Then
            Return True
        Else
            Return False
        End If
    End Function

    ''Checkea que lo ingresado sea unicamente numeros''
    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function

    ''Encriptacion de pass mediante SHA1''
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

    ''Verifica si el Username existe''
    Private Function UserExist(ByVal username As String, ByVal con As MySqlConnection)
        Try
            con.Open()
            cmd.CommandText = "SELECT * FROM usuario WHERE username=@user AND deleted=0"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@user", username)
            r = cmd.ExecuteReader
            If (r.HasRows) Then
                r.Close()
                con.Close()
                Return True
            Else
                r.Close()
                con.Close()
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False

        End Try


    End Function

    Private Function TelefonoExist(ByVal telefono As String, ByVal con As MySqlConnection)
        Try
            con.Open()
            cmd.CommandText = "SELECT * FROM usuario  WHERE Telefono=@telefono AND deleted=0"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@telefono", telefono)
            r = cmd.ExecuteReader
            If (r.HasRows) Then
                r.Close()
                con.Close()
                Return True
            Else
                r.Close()
                con.Close()
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False

        End Try

    End Function


    Private Function EmailExist(ByVal email As String, ByVal con As MySqlConnection)
        Try
            con.Open()
            cmd.CommandText = "SELECT * FROM useremail WHERE email=@email"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@email", email)
            r = cmd.ExecuteReader
            If (r.HasRows) Then
                r.Close()
                con.Close()
                Return True
            Else
                r.Close()
                con.Close()
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False

        End Try
    End Function


    Private Sub ajustarGrid()
        grdInicio.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 20)
        Dim contador As Integer
        For Each grd In grdInicio.Rows
            Dim row As DataGridViewRow = grdInicio.Rows(contador)
            row.Height = 200
            contador = contador + 1
            CType(grdInicio.Columns("portada"), DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom
        Next
    End Sub

    'carga del formulario
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Domicilio.Hide()
        ocultarbarritas()
        subbarritas()
        pnlInicio.Visible = True
        Combobox()
        ComboBoxCategorias.Text = "TODOS"
        loadComboBoxCategoria()
        ActualizarSelectArticulos()
        grdInicio.Columns(0).Width = 200
        grdInicio.Columns(1).Width = 250
        grdInicio.Columns(2).Width = 250
        grdInicio.Columns(3).Width = 240
        ajustarGrid()
    End Sub
    Private Sub AgregarCategorias()
        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter
        Try
            conexion.Open()

            cmd.CommandText = "SELECT categoria FROM categoria"
            cmd.Parameters.Clear()
            r = cmd.ExecuteReader()
            While r.Read()
                Dim categoria = r.GetString("categoria")
                cbxCategorias.Items.Add(categoria)
            End While
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conexion.Close()
        End Try
        cbxCategorias.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    ''A PARTIR DE AQUI HACIA ABAJO ES CODIGO DE  DE ITERACCION DE USUARIO DENTRO DE LA INTERFAZ CON LOS DISTINTOS ELEMENTOS
    Private Sub modificarButton(sender As Object, e As EventArgs) Handles btnModificarInfo.Click
        UpdateUserInfo(ID)
        tbTodos.SelectedTab = tbTodos.TabPages.Item(10)
        Ocultarpaneles()
        btnConfigOcultar.Visible = False
    End Sub
    Private Sub btnCambiarPass_Click(sender As Object, e As EventArgs) Handles btnCambiarPass.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(9)
        pnlMiInfo.Visible = False
        btnConfigOcultar.Visible = False
        Ocultarpaneles()
        LabelCorrectChangePass.Visible = False
    End Sub

    Private Sub Ocultarpaneles()
        panelbotonescarrito.Visible = False
        pnlPerfil.Visible = False
    End Sub
    Private Sub ocultarbarritas()
        pnlInicio.Visible = False
        pnlCarrito.Visible = False
        Panel9.Visible = False
        pnlConfig.Visible = False
        btnConfigOcultar.Visible = False
        btnOcultarMiInfo.Visible = False
    End Sub
    Public Sub subbarritas()
        pnlEnca.Visible = False
        pnlCom.Visible = False
    End Sub
    Private Sub Combobox()
        ComboBoxCategorias.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxRolModificarPerfil.DropDownStyle = ComboBoxStyle.DropDownList
        cbxRol.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub ocultarregistro(ByVal h As Boolean, ByVal x As Boolean)
        txtUsername.Visible = h
        txtEmail.Visible = h
        txtTelefono.Visible = h
        cbxRol.Visible = h
        txtPass.Visible = h
        buttonRegister.Visible = h
        lblCamposAsterisco.Visible = h
        lblAsterisco.Visible = h
        lblUsername.Visible = h
        lblEmail.Visible = h
        lblTelefono.Visible = h
        lblRol.Visible = h
        lblPass.Visible = h
        lblRegistroBienvenido.Visible = x
        lblRegistradoCorrectamente.Visible = x
    End Sub
    Private Sub ocultarLogin(ByVal z As Boolean, ByVal y As Boolean)
        btnLogin.Visible = z
        btnRegistrar.Visible = z
        btnIngresar.Visible = z
        btnSign.Visible = z
        txtusernamelogin.Visible = z
        txtpasslogin.Visible = z
        lblNotienesCuentas.Visible = z
        lblUsernameLogin.Visible = z
        lblContraseñaLogin.Visible = z
        btnConfig.Visible = z
        btnPublicar.Visible = z
        btnCarrito.Visible = z
        lblBienvenido.Visible = y
        btnPublicar.Visible = y
        btnCarrito.Visible = y
        btnConfig.Visible = y
    End Sub
    Private Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(0)
        ocultarbarritas()
        Ocultarpaneles()
        pnlInicio.Visible = True
        ActualizarSelectArticulos()
        ajustarGrid()
        ComboBoxCategorias.Text = "TODOS"
    End Sub
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(1)
        Ocultarpaneles()
        ocultarbarritas()
        lblRegistradoCorrectamente.Visible = False
        ocultarregistro(True, False)
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(2)
        Ocultarpaneles()
        ocultarbarritas()
        txtusernamelogin.Clear()
        txtpasslogin.Clear()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(7)
        pnlPerfil.Visible = False
        subbarritas()
        pnlEnca.Visible = True
    End Sub

    Private Sub btnArticulos_Click(sender As Object, e As EventArgs)
        tbTodos.SelectedTab = tbTodos.TabPages.Item(9)
        panelbotonescarrito.Visible = False
        pnlPerfil.Visible = False
        subbarritas()
    End Sub
    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs)
        tbTodos.SelectedTab = tbTodos.TabPages.Item(10)
        panelbotonescarrito.Visible = False
        pnlPerfil.Visible = False
        subbarritas()
    End Sub
    Private Sub btnTransacciones_Click(sender As Object, e As EventArgs)
        tbTodos.SelectedTab = tbTodos.TabPages.Item(11)
        panelbotonescarrito.Visible = False
        pnlPerfil.Visible = False
        subbarritas()
    End Sub
    Private Sub btnConfig_Click(sender As Object, e As EventArgs) Handles btnConfig.Click
        pnlPerfil.Visible = True
        ocultarbarritas()
        pnlConfig.Visible = True
        btnConfigOcultar.Visible = True
    End Sub
    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        pnlMiInfo.Visible = True
        btnOcultarMiInfo.Visible = True
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles btnSign.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(1)
        Ocultarpaneles()
        ocultarbarritas()
    End Sub
    Private Sub Button29_Click(sender As Object, e As EventArgs)
        tbTodos.SelectedTab = tbTodos.TabPages.Item(10)
        Ocultarpaneles()
        btnConfigOcultar.Visible = False
    End Sub
    Private Sub Button37_Click(sender As Object, e As EventArgs)
        tbTodos.SelectedTab = tbTodos.TabPages.Item(6)
    End Sub
    Private Sub Button38_Click(sender As Object, e As EventArgs)
        tbTodos.SelectedTab = tbTodos.TabPages.Item(6)
    End Sub
    Private Sub Button39_Click(sender As Object, e As EventArgs)
        tbTodos.SelectedTab = tbTodos.TabPages.Item(6)
    End Sub
    Private Sub Button43_Click(sender As Object, e As EventArgs)
        tbTodos.SelectedTab = tbTodos.TabPages.Item(4)
    End Sub
    Private Sub Button45_Click(sender As Object, e As EventArgs)
        tbTodos.SelectedTab = tbTodos.TabPages.Item(4)
    End Sub
    Private Sub Button47_Click(sender As Object, e As EventArgs)
        tbTodos.SelectedTab = tbTodos.TabPages.Item(4)
    End Sub
    Private Sub Button49_Click(sender As Object, e As EventArgs) Handles btnConfigOcultar.Click
        pnlPerfil.Visible = False
        pnlMiInfo.Visible = False
        pnlConfig.Visible = False
        btnConfigOcultar.Visible = False
    End Sub
    Private Sub Button13_Click_1(sender As Object, e As EventArgs) Handles btnOcultarMiInfo.Click
        pnlMiInfo.Visible = False
        btnOcultarMiInfo.Visible = False
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnPublicar.Click

        If (Rol = "Cliente") Then
            Dim resultado As String
            resultado = MsgBox("No puedes publicar articulos por que tienes rol de Cliente,¿Quieres cambiar de rol y ademas tener previlegio de vendedor?", vbOKCancel, "CAMBIAR ROL")
            If resultado = vbOK Then
                Try
                    conexion.Open()
                    cmd.CommandText = "UPDATE usuario SET rol='Vendedor' WHERE id=@idUser"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@idUser", ID)
                    cmd.ExecuteNonQuery()
                    MsgBox("Ahora eres un vendedor,ya puedes publicar articulos")

                    Rol = "Vendedor"  ''Cambia la propiedad de la clase que representa informacion de  el usuario a vendedor
                    lblRolInfo.Text = "Vendedor" ''Cambia la informacion  del label de el panel derecho que contiene informacion minima de el usuario logeado.

                    conexion.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    conexion.Close()
                End Try
            End If
        Else
            tbTodos.SelectedTab = tbTodos.TabPages.Item(5)
            Ocultarpaneles()
            ocultarbarritas()
            Panel9.Visible = True
            AgregarCategorias()
        End If
    End Sub
    Private Sub grdMisArticulos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdMisArticulos.CellClick
        tbTodos.SelectedTab = tbTodos.TabPages.Item(6)
    End Sub
    Private Sub grdInicio_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdInicio.CellClick
        tbTodos.SelectedTab = tbTodos.TabPages.Item(4)
    End Sub


#End Region

#Region "Inicio"

    'Caraga todas las categorias de la base de datos al combobox categorias en le inicio
    Private Sub loadComboBoxCategoria()
        Try
            conexion.Open()
            cmd.CommandText = "SELECT categoria.categoria FROM categoria"
            r = cmd.ExecuteReader()

            While r.Read()
                Dim categoria = r.GetString("categoria")
                ComboBoxCategorias.Items.Add(categoria)
            End While
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conexion.Close()
        End Try
    End Sub

    'rellena el datagrid del inicio segun el estado de la sesion
    Sub ActualizarSelectArticulos()
        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter
        Try
            conexion.Open()

            If (sesion = False) Then
                cmd.CommandText = "SELECT articulos.portada,articulos.id,articulos.Nombre,articulos.precio FROM articulos,usuario WHERE usuario.id=articulos.usuario_id AND articulos.deleted=0 AND usuario.deleted=0 ORDER BY nombre ASC"
            Else
                cmd.CommandText = "SELECT articulos.portada,articulos.id,articulos.Nombre,articulos.precio FROM articulos,usuario WHERE usuario.id=articulos.usuario_id and usuario.id!=@userID AND articulos.deleted=0 AND usuario.deleted=0 ORDER BY nombre ASC"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@userID", ID)
            End If
            adaptador.SelectCommand = cmd
            adaptador.Fill(ds, "Tabla")
            grdInicio.DataSource = ds
            grdInicio.DataMember = "Tabla"

            If grdInicio.RowCount = 0 Then
                lblSinProductos.Visible = True
            Else
                lblSinProductos.Visible = False

            End If

            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conexion.Close()
        End Try
    End Sub

    ''EVENTO DEL BOTON MI CARRITO 
    Private Sub btnCarrito_Click(sender As Object, e As EventArgs) Handles btnCarrito.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(7)
        Ocultarpaneles()
        panelbotonescarrito.Visible = True
        ocultarbarritas()
        pnlEnca.Visible = True
        pnlCarrito.Visible = True
        UpdateGridCart(carrito)

        Dim contador As Integer
        For Each grd In DataGridCart.Rows
            Dim row As DataGridViewRow = DataGridCart.Rows(contador)
            row.Height = 150
            contador = contador + 1
        Next
        DataGridCart.Columns(0).Width = 150
        DataGridCart.Columns(1).Width = 150
        DataGridCart.Columns(2).Width = 150
        DataGridCart.Columns(3).Width = 100
        DataGridCart.Columns(4).Width = 100
        DataGridCart.Columns(5).Width = 120
        DataGridCart.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 20)
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(0)
        ajustarGrid()
    End Sub

    ''Metodo que se ejecuta cuando se seleciona un articulo en el inicio
    Private Sub grdInicio_SelectionChanged(sender As Object, e As EventArgs) Handles grdInicio.SelectionChanged
        If (grdInicio.SelectedRows.Count > 0) Then
            Dim articuloID = grdInicio.Item("id", grdInicio.SelectedRows(0).Index).Value

            lblNomArticuloFicha.Text = grdInicio.Item("Nombre", grdInicio.SelectedRows(0).Index).Value
            codigoFichaLbl.Text = grdInicio.Item("id", grdInicio.SelectedRows(0).Index).Value

            Dim portadaByte() As Byte = grdInicio.Item("portada", grdInicio.SelectedRows(0).Index).Value
            Dim ms As New System.IO.MemoryStream(portadaByte)
            PictureBoxPortadaFicha.Image = System.Drawing.Image.FromStream(ms)
            ms.Close()

            ''AGREGAR DATOS ADICIONALES A LA FICHA'

            Try
                conexion.Close()
                conexion.Open()
                cmd.CommandText = "SELECT articulos.Precio,articulos.Descripcion,articulos.stock,usuario.username FROM articulos,usuario WHERE articulos.id = @idArt AND articulos.deleted=0 and articulos.usuario_id = usuario.id"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@idArt", articuloID)
                r = cmd.ExecuteReader()
                If (r.Read()) Then
                    lblPrecioArticulo.Text = r("Precio") & "$"
                    txtDescripcionArticuloFicha.Text = r("Descripcion")
                    lblVendedorName.Text = r("username")
                    lblFichaCantidad.Text = r("stock")
                End If
                r.Close()
                cmd.CommandText = "SELECT galeria.fotos from galeria,articulos WHERE articulos.id=@idArt and articulos.id=galeria.articulo_id AND articulos.deleted=0"
                r = cmd.ExecuteReader()

                Dim arrayFotosFicha(2) As PictureBox
                arrayFotosFicha(0) = PictureBoxImagen1Ficha
                arrayFotosFicha(1) = PictureBoxImagen2Ficha
                arrayFotosFicha(2) = PictureBoxImagen3Ficha

                Dim cont = 0
                While r.Read()
                    Dim foto() As Byte = r("fotos")
                    Dim ms2 = New System.IO.MemoryStream(foto)
                    arrayFotosFicha(cont).Image = System.Drawing.Image.FromStream(ms2)
                    ms2.Close()
                    cont = cont + 1
                End While
                r.Close()
                conexion.Close()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
            conexion.Close()
        End If
    End Sub

    'boton de buscar
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ''Evento de el boton buscar que filtrara por texto en descripcion y categoria
        tbTodos.SelectedTab = tbTodos.TabPages.Item(0)

        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter
        Try
            conexion.Open()

            If ComboBoxCategorias.Text = "TODOS" Then  ''Si el combobox categoria tiene valor todos
                If (sesion = True) Then   ''Si existe una sesion de usuario abierta
                    ''Seleciona todos los articulos menos los publicados por el usuario con sesion de la sesion, filtrado por descripcion pasado a traves de el TextBox de busqueda 
                    cmd.CommandText = "SELECT articulos.portada,articulos.id,articulos.Nombre,Articulos.precio FROM articulos,usuario WHERE articulos.Descripcion LIKE '%" & txtBuscar.Text & "%' AND articulos.usuario_id=usuario.id AND usuario.id!=" & ID & " AND articulos.deleted=0 AND usuario.deleted=0"  '
                Else
                    ''De lo contrario seleciona todos los articulos
                    cmd.CommandText = "SELECT articulos.portada,articulos.id,articulos.Nombre,Articulos.precio FROM articulos WHERE  articulos.deleted=0 AND articulos.Descripcion LIKE '%" & txtBuscar.Text & "%' "

                End If

            Else
                'Si el combobox no esta selecionado en Todos,es decir que tiene una categoria,por lo tanto
                If (sesion = True) Then
                    'Si existe una sesion,selecciona todos los articulos menos los de el usuario de la sesion,filtrado por descripcion y categoria
                    cmd.CommandText = "SELECT articulos.portada,articulos.id,articulos.Nombre,Articulos.precio FROM articulos,categoria,articulo_categoria,usuario
WHERE articulos.Descripcion LIKE '%" & txtBuscar.Text & "%' AND articulos.id=articulo_categoria.articulo_id AND categoria.id = articulo_categoria.categoria_id AND categoria.categoria='" & ComboBoxCategorias.Text & "' AND articulos.usuario_id=usuario.id AND usuario.id!=" & ID & " AND articulos.deleted=0 AND usuario.deleted=0"
                Else
                    ''Si no existe una sesion ,filtra igual por descripcion y categoria,pero incluye los de el usuario de la sesion
                    cmd.CommandText = "SELECT articulos.portada,articulos.id,articulos.Nombre,Articulos.precio FROM articulos,categoria,articulo_categoria WHERE articulos.Descripcion LIKE '%" & txtBuscar.Text & "%' AND articulos.id=articulo_categoria.articulo_id AND categoria.id = articulo_categoria.categoria_id AND categoria.categoria='" & ComboBoxCategorias.Text & "' AND articulos.deleted=0"
                End If
            End If
            adaptador.SelectCommand = cmd
            adaptador.Fill(ds, "Tabla")
            grdInicio.DataSource = ds
            grdInicio.DataMember = "Tabla"


            If grdInicio.RowCount = 0 Then
                lblSinProductos.Visible = True
            Else
                lblSinProductos.Visible = False
            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conexion.Close()
        End Try
        ajustarGrid()
    End Sub
    'cambio de seleccion en el combobox categorias
    Private Sub ComboBoxCategorias_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxCategorias.TextChanged

        ''Evento que registra cuando se cambia o se seleciona un Item de el combobox
        tbTodos.SelectedTab = tbTodos.TabPages.Item(0)
        lblCategoria.Text = ComboBoxCategorias.Text()
        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter
        Try
            conexion.Open()

            If ComboBoxCategorias.Text = "TODOS" Then
                If (sesion = True) Then
                    ''Seleciona todos los articulos ,sin incluir los articulos de el usuario logeado
                    cmd.CommandText = "SELECT articulos.portada,articulos.id,articulos.Nombre,articulos.precio FROM articulos,usuario WHERE  articulos.usuario_id=usuario.id AND usuario.id!= " & ID & " AND articulos.deleted=0 AND usuario.deleted=0"
                Else

                    ''Seleciona todos los articulos.

                    cmd.CommandText = "SELECT articulos.portada,articulos.id,articulos.Nombre,articulos.precio FROM articulos WHERE articulos.deleted=0 "
                End If
            Else
                If (sesion = True) Then
                    ''Seleciona todos los articulos filtrados unicamente por categoria ,sin incluir los articulos de el usuario
                    cmd.CommandText = "SELECT articulos.portada,articulos.id,articulos.Nombre,articulos.precio FROM articulos,categoria,articulo_categoria,usuario WHERE articulos.id=articulo_categoria.articulo_id AND categoria.id = articulo_categoria.categoria_id AND categoria.categoria='" & ComboBoxCategorias.Text & "' AND articulos.usuario_id=usuario.id AND usuario.id!=" & ID & " AND articulos.deleted=0 AND usuario.deleted=0"
                Else
                    ''Seleciona todos los articulos filtrados unicamente por su categoria
                    cmd.CommandText = "SELECT articulos.portada,articulos.id,articulos.Nombre,articulos.precio FROM articulos,categoria,articulo_categoria WHERE articulos.id=articulo_categoria.articulo_id AND categoria.id = articulo_categoria.categoria_id AND categoria.categoria='" & ComboBoxCategorias.Text & "' AND articulos.deleted=0"
                End If
            End If
            adaptador.SelectCommand = cmd
            adaptador.Fill(ds, "Tabla")
            grdInicio.DataSource = ds
            grdInicio.DataMember = "Tabla"


            If grdInicio.RowCount = 0 Then
                lblSinProductos.Visible = True
            Else
                lblSinProductos.Visible = False
            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conexion.Close()
        End Try
        ajustarGrid()
    End Sub

    'evento del botona agregar al carrito
    Private Sub btnAgregarAlCarrito_Click(sender As Object, e As EventArgs) Handles btnAgregarAlCarrito.Click

        If (Not sesion) Then
            MsgBox("Necesitas iniciar sesion para agregar al carrito")
        Else
            Dim repetido As Boolean = False
            Dim codigoArticuloFicha = CInt(Int(codigoFichaLbl.Text))
            Dim stock = CInt(Int(lblFichaCantidad.Text))

            If (stock > 0) Then
                For Each elem In carrito
                    If (codigoArticuloFicha = elem.ID) Then
                        repetido = True
                    End If
                Next
                If (Not repetido) Then
                    carrito.Add(New ArticuloEnCarrito(codigoArticuloFicha, 1))
                    MsgBox("¡Producto agregado correctamente!")
                Else
                    MsgBox("¡este producto ya esta en el carrito!")
                End If
            Else
                MsgBox("No hay stock para este producto")
            End If
        End If
    End Sub
#End Region

#Region "Registro y Login"
    'Funcion que inserta email en la tabla
    Private Sub insertEmailTable(ByVal id As Integer, ByVal email As String, ByVal con As MySqlConnection)
        ''Para usar este metodo debe ya haber una conexion abierta

        cmd.CommandText = "INSERT INTO useremail VALUES(@user_email,@email)"
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@user_email", id)
        cmd.Parameters.AddWithValue("@email", email)
        cmd.ExecuteNonQuery()
        lblRegistradoCorrectamente.Visible = True
        txtUsername.Clear()
        txtEmail.Clear()
        txtTelefono.Clear()
        txtPass.Clear()
        cbxRol.Text = "Cliente"
        ocultarregistro(False, True)
    End Sub

    'Checkea la validacion del registro ,retorna true si fue correcta o false si hay un error,mostrando los labels de error durante el flujo.'
    Private Function checkvalidacion()
        Dim contador As Integer = 0
        '==========================================
        If txtUsername.Text = "" Then
            Label87.Visible = True
        Else
            If txtUsername.TextLength < 6 Then
                Label101.Visible = True
            Else
                contador = contador + 1
            End If
        End If
        '==========================================
        If txtEmail.Text = "" Then
            Label90.Visible = True
        Else
            If (VerificarCorreo(txtEmail.Text)) Then
                contador = contador + 1
            Else
                Label102.Visible = True
            End If

        End If
        '==========================================
        If txtTelefono.Text = "" Then
            Label91.Visible = True
        Else
            If txtTelefono.TextLength < 9 Then
                Label84.Visible = True
            Else
                contador = contador + 1
            End If
        End If
        '==========================================
        If txtPass.Text = "" Then
            Label92.Visible = True
        Else
            If txtPass.TextLength < 8 Then
                Label86.Visible = True
            Else
                contador = contador + 1
            End If
        End If
        '==========================================
        If (contador = 4) Then
            Return True
        Else
            Return False
        End If
    End Function

    'EVENTO DE BOTON DE EL FORMULARIO DE REGISTRO DE USUARIO
    Private Sub buttonRegister_Click(sender As Object, e As EventArgs) Handles buttonRegister.Click
        ''Funcion que retorna true si la validacion es correcta
        If (checkvalidacion()) Then
            If UserExist(txtUsername.Text, conexion) = False Then
                If EmailExist(txtEmail.Text, conexion) = False Then
                    If TelefonoExist(txtTelefono.Text, conexion) = False Then
                        Try
                            conexion.Open()
                            cmd.Connection = conexion

                            ''INSERCION EN LA TABLA usuarios

                            cmd.CommandText = "INSERT INTO usuario (id,username, password, Nombre, Apellido, telefono, rol, nroCalle, calle, nroApto, esq,deleted) VALUES (NULL,@username , @password, NULL, NULL, @telefono, @rol, NULL, NULL, NULL, NULL,@deleted);"
                            cmd.Prepare()
                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                            cmd.Parameters.AddWithValue("@password", generarClaveSHA1(txtPass.Text))
                            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text)
                            cmd.Parameters.AddWithValue("@rol", cbxRol.Text)
                            cmd.Parameters.AddWithValue("@deleted", 0)
                            cmd.ExecuteNonQuery()
                            ''Extraccion de ID de el registro anteriormente registrado para la insercion en otras tablas
                            cmd.CommandText = "SELECT id FROM usuario WHERE username=@username AND deleted=0"
                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                            Dim rd As MySqlDataReader = cmd.ExecuteReader
                            If (rd.HasRows) Then    '
                                If rd.Read Then
                                    Dim id As Integer = rd("id")
                                    rd.Close()   ''Cierre de DataReader''
                                    insertEmailTable(id, txtEmail.Text, conexion)   ''Inserta el email en la tabla 
                                End If
                            Else
                                rd.Close()
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                    Else
                        lblTelefonoEnUso.Visible = True
                    End If
                Else
                    lblCorreoEnUso.Visible = True
                End If
            Else
                lblUserEnUso.Visible = True
            End If
            conexion.Close()
        End If
    End Sub

    ''EVENTO DE EL BOTON DE LOGEO''
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim log As Integer
        If txtusernamelogin.Text = "" Then
            lblUsernameVacioLogin.Visible = True
        Else
            log = log + 1
        End If
        '==========================================
        If txtpasslogin.Text = "" Then
            lblPassVaciaLogin.Visible = True
        Else
            log = log + 1
        End If
        If (log = 2) Then
            conexion.Open()
            cmd.Connection = conexion

            cmd.CommandText = "SELECT usuario.id, usuario.username,usuario.Nombre, usuario.Apellido, usuario.telefono, usuario.rol , useremail.email from usuario,useremail where username=@nombre and password=@pass and useremail.user_id = usuario.id AND usuario.deleted=0"
            cmd.Prepare()
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@nombre", txtusernamelogin.Text)
            cmd.Parameters.AddWithValue("@pass", generarClaveSHA1(txtpasslogin.Text))
            r = cmd.ExecuteReader()
            If r.HasRows Then
                If r.Read Then

                    sesion = True  'Creacion de sesion'



                    ID = CInt(Int(r("id")))
                    Username = r("username")
                    Nombre = r("Nombre").ToString
                    Apellido = r("Apellido").ToString
                    Email = r("email")
                    Rol = r("rol")

                    Telefono = r("telefono").ToString
                    If (Rol = "Administrador") Then
                        conexion.Close()
                        Dim admin = New Administrador(ID)
                        admin.Show()
                        Me.Hide()
                    Else
                        lblUserInfo.Text = Username
                        lblEmailInfo.Text = Email
                        lblRolInfo.Text = Rol
                        txtusernamelogin.Clear()
                        txtpasslogin.Clear()
                        ocultarLogin(False, True)
                    End If
                End If
            Else
                lblNoExisteUser.Visible = True
            End If
            r.Close()
            conexion.Close()
        End If
        log = 0
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox3_Click(sender As Object, e As EventArgs) Handles txtTelefono.Click
        Label84.Visible = False
        Label91.Visible = False
        lblTelefonoEnUso.Visible = False
    End Sub
    Private Sub TextBox15_Click(sender As Object, e As EventArgs)
        txtApellidoModificarPerfil.Clear()
        txtApellidoModificarPerfil.ForeColor = Color.Black
    End Sub
    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles txtUsername.Click
        Label87.Visible = False
        Label101.Visible = False
        lblUserEnUso.Visible = False
    End Sub
    Private Sub TextBox5_Click(sender As Object, e As EventArgs)
        txtNombreModificarPerfil.Clear()
        txtNombreModificarPerfil.ForeColor = Color.Black
    End Sub
    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles txtEmail.Click
        Label90.Visible = False
        Label102.Visible = False
        lblCorreoEnUso.Visible = False
    End Sub
    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles txtPass.Click
        Label92.Visible = False
        Label86.Visible = False
    End Sub
    Private Sub TextBox7_Click(sender As Object, e As EventArgs) Handles txtusernamelogin.Click
        lblUsernameVacioLogin.Visible = False
        lblNoExisteUser.Visible = False
    End Sub
    Private Sub TextBox6_Click(sender As Object, e As EventArgs) Handles txtpasslogin.Click
        lblPassVaciaLogin.Visible = False
        lblNoExisteUser.Visible = False
    End Sub
#End Region

#Region "Mi Carrito"

    ''Datagrid Compras''
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(8)
        pnlPerfil.Visible = False
        subbarritas()
        pnlCom.Visible = True


        Dim ds As DataSet = New DataSet
        Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter
        Try
            conexion.Open()

            cmd.CommandText = "SELECT compras.id,compras.fecha ,compras.preciototal FROM compras WHERE usuario_id=@userID"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@userID", ID)

            adaptador.SelectCommand = cmd
            adaptador.Fill(ds, "Tabla")
            DataGridCompras.DataSource = ds
            DataGridCompras.DataMember = "Tabla"
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conexion.Close()
        End Try

        DataGridCompras.Columns(0).Width = 100
        DataGridCompras.Columns(1).Width = 150
        DataGridCompras.Columns(2).Width = 130
    End Sub
#End Region

#Region "Publicar"
    ''BOTONES DE IMPORTACION DE IMAGENES A EL PICTURE BOX''
    Private Sub button_agregarPortada_Click(sender As Object, e As EventArgs) Handles button_agregarPortada.Click
        With OpenFilePortada
            .Filter = "Image Files (*.png *.jpg .bmp) |.png; *.jpg; .bmp|All Files(.) |.*"
        End With
        If OpenFilePortada.ShowDialog() = DialogResult.OK Then
            PictureBoxPortada.Load(OpenFilePortada.FileName)
        End If
        lblErrorPortada.Visible = False
    End Sub
    Private Sub button_agregarImagen1_Click(sender As Object, e As EventArgs) Handles button_agregarImagen1.Click
        With OpenFileImagen1
            .Filter = "Image Files (*.png *.jpg .bmp) |.png; *.jpg; .bmp|All Files(.) |.*"
        End With
        If OpenFileImagen1.ShowDialog() = DialogResult.OK Then
            PictureBoxImagen1.Load(OpenFileImagen1.FileName)
            lblErrorImagen1.Visible = False
        End If
    End Sub
    Private Sub button_agregarImagen2_Click(sender As Object, e As EventArgs) Handles button_agregarImagen2.Click
        With OpenFileImagen2
            .Filter = "Image Files (*.png *.jpg .bmp) |.png; *.jpg; .bmp|All Files(.) |.*"
        End With
        If OpenFileImagen2.ShowDialog() = DialogResult.OK Then
            PictureBoxImagen2.Load(OpenFileImagen2.FileName)
            lblErrorImagen2.Visible = False
        End If
    End Sub
    Private Sub button_agregarImagen3_Click(sender As Object, e As EventArgs) Handles button_agregarImagen3.Click
        With OpenFileImagen3
            .Filter = "Image Files (*.png *.jpg .bmp) |.png; *.jpg; .bmp|All Files(.) |.*"
        End With
        If OpenFileImagen3.ShowDialog() = DialogResult.OK Then
            PictureBoxImagen3.Load(OpenFileImagen3.FileName)
            lblErrorImagen3.Visible = False
        End If
    End Sub

    ''EVENTO DE BOTON DE PUBLICAR ARTICULO''
    Private Sub buttonPublicarArticulo_Click(sender As Object, e As EventArgs) Handles buttonPublicarArticulo.Click
        Dim validacionFrmArticulo As Integer = 0

        If txtStockArticulo.Text = "" Then
            Label114.Visible = True
        Else
            validacionFrmArticulo = validacionFrmArticulo + 1
        End If
        '==========================================
        If txtNombreArticulo.Text = "" Then
            Label115.Visible = True
        Else
            If txtNombreArticulo.TextLength < 2 Then
                Label116.Visible = True
            Else
                validacionFrmArticulo = validacionFrmArticulo + 1
            End If
        End If
        '==========================================
        If txtPrecio.Text = "" Then
            Label120.Visible = True
        Else
            validacionFrmArticulo = validacionFrmArticulo + 1
        End If
        '==========================================
        If txtDescripcionArticulo.Text = "" Then
            Label118.Visible = True
        Else
            If txtDescripcionArticulo.TextLength < 10 Then
                Label119.Visible = True
            Else
                validacionFrmArticulo = validacionFrmArticulo + 1
            End If
        End If

        If Not PictureBoxPortada.Image Is Nothing Then
            validacionFrmArticulo = validacionFrmArticulo + 1
        Else
            lblErrorPortada.Visible = True
        End If

        If Not PictureBoxImagen1.Image Is Nothing Then
            validacionFrmArticulo = validacionFrmArticulo + 1
        Else
            lblErrorImagen1.Visible = True
        End If
        If Not PictureBoxImagen2.Image Is Nothing Then
            validacionFrmArticulo = validacionFrmArticulo + 1
        Else
            lblErrorImagen2.Visible = True
        End If

        If Not PictureBoxImagen3.Image Is Nothing Then
            validacionFrmArticulo = validacionFrmArticulo + 1
        Else
            lblErrorImagen3.Visible = True
        End If

        If lvCategorias.Items.Count = 0 Then
            lblErrorCategoria.Visible = True
        Else
            validacionFrmArticulo += 1
        End If

        If validacionFrmArticulo = 9 Then

            ''INSERCION DE ARTICULOS''

            Dim ms As New System.IO.MemoryStream()   ''Crea un buffer o reserva un espacio en memoria ram directamente.
            PictureBoxPortada.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ''Almacenamos la imagen cargada de el picturebox portada
            Dim portada As Byte() = ms.GetBuffer  ''Guardamos en portada,la cadena de bytes de la imagen mediante el metodo getBuffer
            ms.Close()                       ''Cerramos el buffer


            ''Insercion en la tabla articulos
            Try
                conexion.Open()
                cmd.CommandText = "INSERT INTO articulos(Nombre,Precio,Descripcion,portada,stock,usuario_id,deleted) VALUES(@nombre,@precio,@descripcion,@portada,@stock,@usuario_id,@deleted)"

                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@nombre", txtNombreArticulo.Text)
                cmd.Parameters.AddWithValue("@precio", txtPrecio.Text)
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcionArticulo.Text)
                cmd.Parameters.AddWithValue("@portada", portada)
                cmd.Parameters.AddWithValue("@stock", txtStockArticulo.Text)
                cmd.Parameters.AddWithValue("@usuario_id", ID)
                cmd.Parameters.AddWithValue("@deleted", 0)
                cmd.ExecuteNonQuery()

                ''EXTRAER EL ID DE EL ARTICULO INGRESADO ANTERIORMENTE'
                Dim idArticulo As Integer
                cmd.CommandText = "SELECT MAX(id) As id FROM articulos"
                r = cmd.ExecuteReader
                If (r.HasRows) Then
                    If r.Read Then
                        idArticulo = r("id")
                    End If
                End If
                r.Close()

                ''ARRAY DE los 3 PictureBox ya cargados''
                Dim arrayFotos(2) As PictureBox
                arrayFotos(0) = PictureBoxImagen1
                arrayFotos(1) = PictureBoxImagen2
                arrayFotos(2) = PictureBoxImagen3

                Dim nroFoto = 0

                For Each fotito As PictureBox In arrayFotos ''BUCLE FOREACH que insertara las 3 imagenes ingresadas como fotos de los articulos en la tabla galeria 
                    Dim ms2 = New System.IO.MemoryStream()
                    nroFoto = nroFoto + 1
                    fotito.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim foto As Byte() = ms2.GetBuffer
                    cmd.CommandText = "INSERT INTO galeria(articulo_id,fotos,nroFoto) VALUES(@articulo_id,@foto,@nroFoto)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@articulo_id", idArticulo)
                    cmd.Parameters.AddWithValue("@foto", foto)
                    cmd.Parameters.AddWithValue("@nroFoto", nroFoto)
                    cmd.ExecuteNonQuery()
                    ms2.Close()
                Next

                Dim contador As Integer = 0
                For Each item In lvCategorias.Items
                    Dim name As String = lvCategorias.Items(contador).Text
                    cmd.CommandText = "SELECT id FROM `categoria` WHERE categoria.categoria = @nomb"
                    cmd.Parameters.AddWithValue("@nomb", name)
                    r = cmd.ExecuteReader
                    If r.HasRows Then
                        contador += 1
                        If r.Read Then
                            Dim idcategoria As String = r("id")  ''Extrae el id de la categoria selecionada
                            r.Close()
                            cmd.CommandText = "insert into articulo_categoria(articulo_id,categoria_id) values (@articulo,@categoria)"
                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@articulo", idArticulo)
                            cmd.Parameters.AddWithValue("@categoria", idcategoria)
                            cmd.ExecuteNonQuery()  ''Inserta el id de el articulo ultimamente registrado y el id de categoria
                        End If
                    End If
                Next
                MsgBox("Articulo insertado correctamente")
                PictureBoxPortada.Image.Dispose()
                PictureBoxPortada.Image = Nothing
                PictureBoxImagen1.Image.Dispose()
                PictureBoxImagen1.Image = Nothing
                PictureBoxImagen2.Image.Dispose()
                PictureBoxImagen2.Image = Nothing
                PictureBoxImagen3.Image.Dispose()
                PictureBoxImagen3.Image = Nothing
                txtDescripcionArticulo.Clear()
                txtStockArticulo.Clear()
                txtNombreArticulo.Clear()
                txtPrecio.Clear()

                Dim h As String
                For Each lista In lvCategorias.Items
                    h = lvCategorias.Items(0).Text
                    cbxCategorias.Items.Add(h)
                    lista.remove()
                Next
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conexion.Close()
        End If
    End Sub

    'control de numeros en los textbox
    Private Sub TextBox10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStockArticulo.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    'control de etiquetas de los campos
    Private Sub TextBox10_Click(sender As Object, e As EventArgs) Handles txtStockArticulo.Click
        Label114.Visible = False
    End Sub
    Private Sub TextBox8_Click(sender As Object, e As EventArgs) Handles txtNombreArticulo.Click
        Label115.Visible = False
        Label116.Visible = False
    End Sub
    Private Sub TextBox9_Click(sender As Object, e As EventArgs) Handles txtPrecio.Click
        Label120.Visible = False
    End Sub
    Private Sub TextBox23_Click(sender As Object, e As EventArgs) Handles txtDescripcionArticulo.Click
        Label118.Visible = False
        Label119.Visible = False
    End Sub

       Private Sub cbxCategorias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCategorias.SelectedIndexChanged
        lvCategorias.Items.Add(cbxCategorias.SelectedItem)
        cbxCategorias.Items.Remove(cbxCategorias.Text)
    End Sub
     Private Sub lvCategorias_DoubleClick(sender As Object, e As EventArgs) Handles lvCategorias.DoubleClick
        Dim h As String
        For Each lista In lvCategorias.SelectedItems
            h = lvCategorias.SelectedItems(0).SubItems(0).Text
            cbxCategorias.Items.Add(h)
            lista.remove()
        Next
    End Sub

    Private Sub cbxCategorias_Click(sender As Object, e As EventArgs) Handles cbxCategorias.Click
        lblErrorCategoria.Visible = False
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("Para seleccionar una categoria,debe desplegar la lista y presionar click sobre la categoria deseada,si se equivoca y selecciona una categoria incorrecta,pede ir a la lista que aparece abajo de esta caja y presionar doble click sobre la categoria")
    End Sub
#End Region

#Region "Configuracion"
#Region "Mi info"
    ''ACTUALIZA LA INFORMACION DE LOS CAMPOS Y ETIQUETAS DEL USUARIO EN "MI INFO",CUANDO SE HACE ALGUN TIPO DE CAMBIO
    Private Sub UpdateUserInfo(ByVal id As Integer)
        Try
            conexion.Open()
            cmd.Connection = conexion

            cmd.CommandText = "SELECT * FROM usuario,useremail WHERE usuario.id=@id AND useremail.user_id = @id AND usuario.deleted=0"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@id", id)
            r = cmd.ExecuteReader
            If (r.HasRows) Then
                If (r.Read) Then
                    ''Set campos de el formulario de modificar perfil''
                    txtNombreModificarPerfil.Text = Convert.ToString(r.Item("Nombre"))
                    txtUsernameModificarPerfil.Text = r("username")
                    txtCorreoModificarPerfil.Text = r("email")
                    txtApellidoModificarPerfil.Text = Convert.ToString(r.Item("Apellido"))
                    txtTelefonoModificarPerfil.Text = Convert.ToString(r.Item("telefono"))
                    ComboBoxRolModificarPerfil.Text = r.Item("rol")

                    ''Set labels de informacion 
                    lblUserInfo.Text = r("username")
                    lblRolInfo.Text = r("Rol")
                    lblEmailInfo.Text = r("email")

                    ''SET campos de Domicilio Modal''
                    frmDomicilio.TextBox1.Text = Convert.ToString(r.Item("nroCalle"))
                    frmDomicilio.TextBox2.Text = Convert.ToString(r.Item("calle"))
                    frmDomicilio.TextBox3.Text = Convert.ToString(r.Item("esq"))
                    frmDomicilio.TextBox4.Text = Convert.ToString(r.Item("nroApto"))
                    frmDomicilio.TextBox5.Text = Convert.ToString(r.Item("ciudad"))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        conexion.Close()
        r.Close()
    End Sub

    ''EVENTO DE CLICK DE EL BOTON DE ACTUALIZAR INFORMACION
    Private Sub buttonSetInfo_Click(sender As Object, e As EventArgs) Handles buttonSetInfo.Click
        'VALIDACION DE FORMULARIO DE MODIFICACION DE PERFIL' 

        Dim validacion As Integer = 0

        Dim user = txtUsernameModificarPerfil.Text
        Dim correo = txtCorreoModificarPerfil.Text
        Dim nombre = txtNombreModificarPerfil.Text
        Dim telefono = txtTelefonoModificarPerfil.Text
        Dim apellido = txtApellidoModificarPerfil.Text

        ''Domicilio
        Dim nroCalle = frmDomicilio.TextBox1.Text
        Dim calle = frmDomicilio.TextBox2.Text
        Dim esq = frmDomicilio.TextBox3.Text
        Dim nroApto = frmDomicilio.TextBox4.Text
        Dim ciudad = frmDomicilio.TextBox5.Text


        If user = "" Then
            LabelErrorUsername.Text = "*Este campo no puede estar vacio"
        Else
            If Not txtUsernameModificarPerfil.TextLength < 6 Then
                validacion = validacion + 1
            Else
                LabelErrorUsername.Visible = True
                LabelErrorUsername.Text = "*El nombre debe tener mas de 6 caracteres"
            End If
        End If

        If correo = "" Then
            LabelErrorCorreo.Text = "*Este campo no puede estar vacio"
        Else
            If (VerificarCorreo(correo)) Then
                validacion = validacion + 1
            Else
                LabelErrorCorreo.Visible = True
                LabelErrorCorreo.Text = "*debes ingresar un correo valido"
            End If
        End If
        '==========================================
        If nombre = "" Then

            nombre = Nothing
            ''Informacion adicional',no necesariamente necesita no estar vacio

        Else
            If txtNombreModificarPerfil.TextLength < 3 Then
                Label97.Visible = True
            Else

            End If
        End If
        '==========================================
        If apellido = "" Then

            apellido = Nothing

            ''Informacion adicional',no necesariamente necesita no estar vacio
        Else
            If txtApellidoModificarPerfil.TextLength < 3 Then
                Label100.Visible = True
            Else

            End If
        End If

        If (validacion = 2) Then
            Dim result As DialogResult = MessageBox.Show("¿Seguro que quieres actualizar tu información? ", "Modificar perfil ", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Try
                    conexion.Open()
                    cmd.Connection = conexion


                    cmd.CommandText = "UPDATE usuario,useremail SET usuario.username=@username, usuario.Nombre=@nombre, usuario.Apellido=@apellido,usuario.telefono=@telefono, usuario.rol=@rol,usuario.nroCalle = @nro , usuario.calle=@calle, usuario.nroApto=@nroapto,usuario.esq=@esq,usuario.ciudad=@ciudad ,useremail.email = @email WHERE usuario.id=@id AND usuario.id = useremail.user_id"
                    cmd.Prepare()
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@username", user)
                    cmd.Parameters.AddWithValue("@nombre", nombre)
                    cmd.Parameters.AddWithValue("@apellido", apellido)
                    cmd.Parameters.AddWithValue("@telefono", telefono)
                    cmd.Parameters.AddWithValue("@rol", ComboBoxRolModificarPerfil.Text)
                    cmd.Parameters.AddWithValue("@nro", nroCalle)
                    cmd.Parameters.AddWithValue("@calle", calle)
                    cmd.Parameters.AddWithValue("@nroapto", nroApto)
                    cmd.Parameters.AddWithValue("@esq", esq)
                    cmd.Parameters.AddWithValue("@ciudad", ciudad)
                    cmd.Parameters.AddWithValue("@email", correo)
                    cmd.Parameters.AddWithValue("@id", ID)
                    cmd.ExecuteNonQuery()
                    MsgBox("Datos Actualizados correctamente")
                    Rol = ComboBoxRolModificarPerfil.Text()  ''Modifica una de las propiedades de la clase que es informacion de el usuario
                    conexion.Close()
                    UpdateUserInfo(ID)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                conexion.Close()
            End If
        End If
    End Sub
    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox13_Click(sender As Object, e As EventArgs) Handles txtUsernameModificarPerfil.Click
        LabelErrorUsername.Visible = False
    End Sub
    Private Sub TextBox14_Click(sender As Object, e As EventArgs) Handles txtCorreoModificarPerfil.Click
        LabelErrorCorreo.Visible = False
    End Sub
    Private Sub Button12_Click_1(sender As Object, e As EventArgs) Handles Button12.Click
        MsgBox("Seleccionando el permiso de 'vendedor',¡usted estara habilitado a vender sus propios articulos!")
    End Sub
    Private Sub TextBox19_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox21_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefonoModificarPerfil.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox5_Click_1(sender As Object, e As EventArgs) Handles txtNombreModificarPerfil.Click
        Label97.Visible = False
    End Sub
    Private Sub TextBox21_Click(sender As Object, e As EventArgs) Handles txtTelefonoModificarPerfil.Click
        Label99.Visible = False
    End Sub
    Private Sub TextBox15_Click_1(sender As Object, e As EventArgs) Handles txtApellidoModificarPerfil.Click
        Label100.Visible = False
    End Sub
    Private Sub TextBox20_Click(sender As Object, e As EventArgs) Handles txtDomicilioModificarPerfil.Click
        frmDomicilio.Show()
    End Sub
#End Region

#Region "Mis articulos"
    ''BOTONES DE IMPORTACION DE IMAGENES EN EL EDITOR DE ARTICULOS PUBLICADOS POR EL USUARIO
    Private Sub btnCambiarPortada_Click(sender As Object, e As EventArgs) Handles btnCambiarPortada.Click
        With ofdEditarPortada
            .Filter = "Image Files (*.png *.jpg .bmp) |.png; *.jpg; .bmp|All Files(.) |.*"
        End With
        If ofdEditarPortada.ShowDialog() = DialogResult.OK Then
            pbCambiarPortada.Load(ofdEditarPortada.FileName)
        End If
    End Sub
    Private Sub btnEditarImagen1_Click(sender As Object, e As EventArgs) Handles btnEditarImagen1.Click
        With ofdEditarImagen1
            .Filter = "Image Files (*.png *.jpg .bmp) |.png; *.jpg; .bmp|All Files(.) |.*"
        End With
        If ofdEditarImagen1.ShowDialog() = DialogResult.OK Then
            pbCambiarImg1.Load(ofdEditarImagen1.FileName)
        End If
    End Sub
    Private Sub btnEditarImagen2_Click(sender As Object, e As EventArgs) Handles btnEditarImagen2.Click
        With ofdEditarImagen2
            .Filter = "Image Files (*.png *.jpg .bmp) |.png; *.jpg; .bmp|All Files(.) |.*"
        End With
        If ofdEditarImagen2.ShowDialog() = DialogResult.OK Then
            pbCambiarImg2.Load(ofdEditarImagen2.FileName)
        End If
    End Sub
    Private Sub btnEditarImagen3_Click(sender As Object, e As EventArgs) Handles btnEditarImagen3.Click
        With ofdEditarImagen3
            .Filter = "Image Files (*.png *.jpg .bmp) |.png; *.jpg; .bmp|All Files(.) |.*"
        End With
        If ofdEditarImagen3.ShowDialog() = DialogResult.OK Then
            pbCambiarImg3.Load(ofdEditarImagen3.FileName)
        End If
    End Sub
    Private Sub UpdateGridCart(ByVal cartArray As ArrayList)
        DataGridCart.Rows.Clear()
        Try
            conexion.Open()
            cmd.CommandText = "SELECT articulos.id,articulos.portada,articulos.Nombre,articulos.precio FROM articulos WHERE articulos.id =@idArticulo"

            Dim precioTotal As Integer
            For Each elem In cartArray
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@idArticulo", elem.ID)
                r = cmd.ExecuteReader
                If r.Read Then
                    Dim id = r("id")
                    Dim nombre = r("Nombre")
                    Dim precio = r("Precio")
                    Dim portada = r("portada")

                    precioTotal = precioTotal + (precio * elem.cantidad)

                    Dim subtotal = (precio * elem.cantidad).ToString + "$"

                    DataGridCart.Rows.Add(portada, id, nombre, precio, elem.cantidad, subtotal)
                End If

                If DataGridCart.RowCount = 0 Then
                    lblSinArticulosCart.Visible = True
                Else
                    lblSinArticulosCart.Visible = False
                End If


                r.Close()
            Next
            lblPrecioTotalCart.Text = precioTotal
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conexion.Close()
        End Try
    End Sub
    'visualizar los articulos publicados
    Private Sub btnMisArticulos_Click(sender As Object, e As EventArgs) Handles btnMisArticulos.Click

        If (Rol = "Cliente") Then
            MsgBox("Usted esta registrado como cliente,para poder ver sus articulos publicados,dirijase a 'Mi info > Modificar > Rol' y seleccione vendedor,asi podra publicar nuevos articulos y ver los que ya ha publicado")
        Else
            tbTodos.SelectedTab = tbTodos.TabPages.Item(3)
            pnlMiInfo.Visible = False
            btnConfigOcultar.Visible = False
            Ocultarpaneles()

            Dim ds As DataSet = New DataSet
            Dim adaptador As MySqlDataAdapter = New MySqlDataAdapter
            Try
                conexion.Open()


                cmd.CommandText = "SELECT articulos.portada,articulos.id,articulos.Nombre,articulos.precio FROM articulos,usuario WHERE usuario.id=articulos.usuario_id and articulos.usuario_id = @userID AND articulos.deleted = 0 AND usuario.deleted=0"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@userID", ID)

                adaptador.SelectCommand = cmd
                adaptador.Fill(ds, "Tabla")
                grdMisArticulos.DataSource = ds
                grdMisArticulos.DataMember = "Tabla"

                If grdMisArticulos.RowCount = 0 Then
                    lblSinArticulos.Visible = True

                Else
                    lblSinArticulos.Visible = False

                End If


            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conexion.Close()

            Dim contador3 As Integer
            For Each grd In grdMisArticulos.Rows
                Dim row As DataGridViewRow = grdMisArticulos.Rows(contador3)
                row.Height = 200
                contador3 = contador3 + 1
                CType(grdMisArticulos.Columns("portada"), DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom
            Next
            grdMisArticulos.Columns(0).Width = 200
            grdMisArticulos.Columns(1).Width = 200
            grdMisArticulos.Columns(2).Width = 200
            grdMisArticulos.Columns(3).Width = 200
            grdMisArticulos.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 20)
        End If
    End Sub
    'boton de volver
    Private Sub btnVolverEditarArticulos_Click(sender As Object, e As EventArgs) Handles btnVolverEditarArticulos.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(3)

        Dim contador3 As Integer
        For Each grd In grdMisArticulos.Rows
            Dim row As DataGridViewRow = grdMisArticulos.Rows(contador3)
            row.Height = 200
            contador3 = contador3 + 1
        Next
        grdMisArticulos.Columns(0).Width = 200
        grdMisArticulos.Columns(1).Width = 200
        grdMisArticulos.Columns(2).Width = 200
        grdMisArticulos.Columns(3).Width = 200
    End Sub
#End Region

#Region "Mis articulos"
     Private Sub grdMisArticulos_SelectionChanged(sender As Object, e As EventArgs) Handles grdMisArticulos.SelectionChanged
        If (grdMisArticulos.SelectedRows.Count > 0) Then
            Dim articuloID = grdMisArticulos.Item("id", grdMisArticulos.SelectedRows(0).Index).Value

            txtEditarNombreArticulo.Text = grdMisArticulos.Item("Nombre", grdMisArticulos.SelectedRows(0).Index).Value
            lblCodigoEditar.Text = grdMisArticulos.Item("id", grdMisArticulos.SelectedRows(0).Index).Value
            txtEditarPrecio.Text = grdMisArticulos.Item("precio", grdMisArticulos.SelectedRows(0).Index).Value


            ''AGREGAR DATOS ADICIONALES A LA FICHA'

            Try
                conexion.Close()
                conexion.Open()
                cmd.CommandText = "SELECT articulos.portada,articulos.descripcion,articulos.stock FROM articulos WHERE articulos.id = @idArt "
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@idArt", articuloID)
                r = cmd.ExecuteReader()
                If r.Read Then
                    txtCambiarDescripcion.Text = r("descripcion")
                    txtStock.Text = r("stock")


                    Dim portadaByte() As Byte = r("portada")
                    Dim ms As New System.IO.MemoryStream(portadaByte)
                    pbCambiarPortada.Image = New Bitmap(Image.FromStream(ms))


                    ms.Close()
                End If
                r.Close()
                cmd.Parameters.Clear()
                cmd.CommandText = "SELECT galeria.fotos FROM galeria WHERE galeria.articulo_id = @idArt"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@idArt", articuloID)
                r = cmd.ExecuteReader()

                Dim arrayFotosFicha(2) As PictureBox
                arrayFotosFicha(0) = pbCambiarImg1
                arrayFotosFicha(1) = pbCambiarImg2
                arrayFotosFicha(2) = pbCambiarImg3

                Dim cont = 0
                While r.Read()
                    Dim foto2() As Byte = r("fotos")
                    Dim ms3 = New System.IO.MemoryStream(foto2)
                    arrayFotosFicha(cont).Image = New Bitmap(Image.FromStream(ms3))
                    ms3.Close()
                    cont = cont + 1
                End While
                r.Close()
                conexion.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conexion.Close()
        End If
    End Sub

     Private Sub txtStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStock.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
     End Sub
     Private Sub txtEditarPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEditarPrecio.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
     Private Sub btnGuardarCambios_Click(sender As Object, e As EventArgs) Handles btnGuardarCambios.Click
        Dim valores As Integer

        'VALIDACION DE LOS CAMPOS AL MODIFICAR UN ARTICULO
        If txtEditarNombreArticulo.Text = "" Then
            lblNombreVacioEditarArticulo.Visible = True
            lblNombreVacioEditarArticulo.Text = "*Este Campo no puede estar vacio"
        Else
            If txtEditarNombreArticulo.TextLength < 3 Then
                lblNombreVacioEditarArticulo.Visible = True
                lblNombreVacioEditarArticulo.Text = "*El nombre debe tener mas 3 o mas caracteres"
            Else
                valores = valores + 1
            End If
        End If
        '==============================================
        If txtCambiarDescripcion.Text = "" Then
            lblEditarDescripcionVacia.Visible = True
        Else
            If txtCambiarDescripcion.TextLength < 10 Then
                lblDescripcion10caracteres.Visible = True
            Else
                valores = valores + 1
            End If
        End If
        '==============================================
        If txtStock.Text = "" Then
            lblStockVacio.Visible = True
        Else
            valores = valores + 1
        End If
        '==============================================
        If txtEditarPrecio.Text = "" Then
            lblEditarPrecioVacio.Visible = True
        Else
            valores = valores + 1
        End If

        'Actualizacion de los datos del articulo seleccionado
        If valores = 4 Then

            ''INSERCION DE ARTICULOS''

            Dim ms As New System.IO.MemoryStream()   ''Crea un buffer o reserva un espacio en memoria ram directamente.
            pbCambiarPortada.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ''Almacenamos la imagen cargada de el picturebox portada
            Dim portada As Byte() = ms.GetBuffer  ''Guardamos en portada,la cadena de bytes de la imagen mediante el metodo getBuffer
            ms.Close()                       ''Cerramos el buffer

            Dim id_articulo As Integer = grdMisArticulos.Item("id", grdMisArticulos.SelectedRows(0).Index).Value

            ''Actualizacion en la tabla articulos
            Try
                conexion.Open()
                cmd.CommandText = "UPDATE `articulos` SET `Nombre`= @nombre,`Precio`=@precio,`Descripcion`=@descripcion,`portada`=@portada,`stock`=@stock WHERE articulos.id=@id_articulo"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@id_articulo", id_articulo)
                cmd.Parameters.AddWithValue("@nombre", txtEditarNombreArticulo.Text)
                cmd.Parameters.AddWithValue("@precio", txtEditarPrecio.Text)
                cmd.Parameters.AddWithValue("@descripcion", txtCambiarDescripcion.Text)
                cmd.Parameters.AddWithValue("@portada", portada)
                cmd.Parameters.AddWithValue("@stock", txtStock.Text)
                cmd.Parameters.AddWithValue("@usuario_id", ID)
                cmd.ExecuteNonQuery()

                ''ARRAY DE los 3 PictureBox 
                Dim arrayFotos(2) As PictureBox
                arrayFotos(0) = pbCambiarImg1
                arrayFotos(1) = pbCambiarImg2
                arrayFotos(2) = pbCambiarImg3

                Dim nroFoto = 0

                For Each fotito As PictureBox In arrayFotos ''BUCLE FOREACH que insertara las 3 imagenes ingresadas como fotos de los articulos en la tabla galeria 
                    Dim ms2 = New System.IO.MemoryStream()
                    fotito.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim foto As Byte() = ms2.GetBuffer
                    cmd.CommandText = "UPDATE `galeria` SET `fotos`=@foto WHERE articulo_id=@id_articulo"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@id_articulo", id_articulo)
                    cmd.Parameters.AddWithValue("@foto", foto)
                    cmd.ExecuteNonQuery()
                    ms2.Close()
                    nroFoto = nroFoto + 1
                Next
                MsgBox("Articulo actualizado correctamente")
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conexion.Close()
        End If
    End Sub
     Private Sub txtEditarNombreArticulo_Click(sender As Object, e As EventArgs) Handles txtEditarNombreArticulo.Click
        lblNombreVacioEditarArticulo.Visible = False
    End Sub
    Private Sub txtCambiarDescripcion_Click(sender As Object, e As EventArgs) Handles txtCambiarDescripcion.Click
        lblEditarDescripcionVacia.Visible = False
        lblDescripcion10caracteres.Visible = False
    End Sub
    Private Sub txtStock_Click(sender As Object, e As EventArgs) Handles txtStock.Click
        lblStockVacio.Visible = False
    End Sub
    Private Sub txtEditarPrecio_Click(sender As Object, e As EventArgs) Handles txtEditarPrecio.Click
        lblEditarPrecioVacio.Visible = False
    End Sub
     Private Sub DataGridCart_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridCart.SelectionChanged
        If (DataGridCart.SelectedRows.Count > 0) Then
            lblArticuloCart.Text = DataGridCart.Item("ColumnArticuloCart", DataGridCart.SelectedRows(0).Index).Value
            txtCantidadCart.Text = DataGridCart.Item("ColumnCantidadCart", DataGridCart.SelectedRows(0).Index).Value
        End If
    End Sub
    Private Sub txtCantidadCart_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadCart.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub deleteArtCart_Click(sender As Object, e As EventArgs) Handles deleteArtCart.Click
        If (DataGridCart.SelectedRows.Count = 0) Then
            MsgBox("No puede ejecutar esta accion por que el carrito esta vacio")
        Else
            Dim idArt = DataGridCart.Item("ColumnIDCart", DataGridCart.SelectedRows(0).Index).Value
            For i = 0 To carrito.Count - 1
                If idArt = carrito(i).ID Then
                    carrito.RemoveAt(i)
                    Exit For
                End If
            Next
            UpdateGridCart(carrito)
            ajustarGrid()
        End If
    End Sub

    Private Sub ActualizarCantidadCartButton_Click(sender As Object, e As EventArgs) Handles ActualizarCantidadCartButton.Click
        If (DataGridCart.SelectedRows.Count = 0) Then
            MsgBox("No puede ejecutar esta accion por que el carrito esta vacio")
        Else



            Dim idArt = DataGridCart.Item("ColumnIDCart", DataGridCart.SelectedRows(0).Index).Value ''Extraemos el id de el articulo selecionado en el datagrid
            Dim cantidad = CInt(Int(txtCantidadCart.Text))  ''Extraemos la nueva cantidad ingresada por el usuario

            If (cantidad > 0) Then



                Try
                    conexion.Open()
                    cmd.CommandText = "SELECT Nombre,stock FROM articulos WHERE id=@idArt"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@idArt", idArt)
                    r = cmd.ExecuteReader
                    If (r.Read()) Then
                        Dim stock = CInt(Int(r("stock")))
                        Dim articulo = r("Nombre")

                        If ((stock - cantidad) < 0) Then
                            MsgBox("No hay suficientes unidades para el articulo: " & articulo & " unidades disponibles: " & stock)
                        Else
                            For i = 0 To carrito.Count - 1      ''Busca el objeto de el articuloEnCarrito de el arraylist ,cuando lo encuentra,lo modifica a la nueva cantidad
                                If idArt = carrito(i).ID Then
                                    carrito(i).cantidad = cantidad
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                    r.Close()
                    conexion.Close()
                    UpdateGridCart(carrito)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Else
                MsgBox("La cantidad ingresada no es valida")

            End If

            Dim contador As Integer  ''????????'''
                For Each grd In DataGridCart.Rows
                    Dim row As DataGridViewRow = DataGridCart.Rows(contador)
                    row.Height = 150
                    contador = contador + 1
                Next
                DataGridCart.Columns(0).Width = 150
                DataGridCart.Columns(1).Width = 150
                DataGridCart.Columns(2).Width = 150
            End If
    End Sub

    'Vacia todos los articulos de el carrito y actualiza el datagrid
    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        carrito.Clear()
        UpdateGridCart(carrito)
    End Sub
    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click

        If (DataGridCart.SelectedRows.Count = 0) Then
            MsgBox("No puede ejecutar esta accion por que el carrito esta vacio")
        Else
            Dim resultado As String
            resultado = MsgBox("¿ESTAS SEGURO DE QUE DESEAS EFECTUAR COMPRA?", vbOKCancel, "CONFIRMACION")

            If (resultado = vbOK) Then


                Try
                    conexion.Open()
                    Dim precioTotal = CInt(Int(lblPrecioTotalCart.Text))
                    Dim fechaActual As Date = Date.Now
                    Dim idCompra As Integer

                    cmd.CommandText = "INSERT INTO compras(usuario_id,Fecha,PrecioTotal) VALUES(@idUser,@fecha,@preciototal)"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@idUser", ID)
                    cmd.Parameters.AddWithValue("@fecha", fechaActual)
                    cmd.Parameters.AddWithValue("@preciototal", precioTotal)
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "SELECT MAX(id) As id FROM compras"
                    r = cmd.ExecuteReader
                    If (r.HasRows) Then
                        If r.Read() Then
                            idCompra = CInt(Int(r("id")))
                        End If
                    End If
                    r.Close()

                    Dim articuloID As Integer
                    Dim cantidadArt As Integer
                    Dim precio As Integer
                    For Each d As DataGridViewRow In DataGridCart.Rows

                        articuloID = CInt(d.Cells("ColumnIDCart").Value())
                        cantidadArt = CInt(d.Cells("ColumnCantidadCart").Value())
                        precio = CInt(d.Cells("ColumnPrecioCart").Value())

                        cmd.CommandText = "INSERT INTO detalle_compra(id_compra,id_articulo,Cantidad,PrecioUnitario) VALUES(@idCompra,@idArt,@cant,@price)"
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@idCompra", idCompra)
                        cmd.Parameters.AddWithValue("@idArt", articuloID)
                        cmd.Parameters.AddWithValue("@cant", cantidadArt)
                        cmd.Parameters.AddWithValue("@price", precio)
                        cmd.ExecuteNonQuery()

                        cmd.CommandText = "SELECT stock FROM articulos WHERE id=@idArt"
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@idArt", articuloID)
                        r = cmd.ExecuteReader
                        r.Read()
                        Dim stock = CInt(Int(r("stock")))
                        Dim newStock = stock - cantidadArt

                        r.Close()
                        cmd.CommandText = "UPDATE articulos SET stock=@newstock WHERE id=@idArt"
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@newstock", newStock)
                        cmd.Parameters.AddWithValue("@idArt", articuloID)
                        cmd.ExecuteNonQuery()
                    Next
                    MsgBox("Compra efectuada correctamente")
                    carrito.Clear()
                    conexion.Close()
                    UpdateGridCart(carrito)
                Catch ex As Exception
                    conexion.Close()
                    MsgBox(ex.ToString)
                End Try


            End If

        End If




        Try
            'aca pones todo el codigode el boton
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "Modificar password"
    ''EVENTO DE EL BOTON DE CAMBIAR CONTRASEÑA 
    Private Sub Button48_Click(sender As Object, e As EventArgs) Handles btnAceptarPasswd.Click
        Dim H As Integer

        If txtContraseñaActual.Text = "" Then
            Label117.Visible = True
        End If

        '==========================================
        If txtContraseñaNueva.Text = "" Then
            Label107.Visible = True
        Else
            If txtContraseñaNueva.TextLength < 6 Then
                Label110.Visible = True
            Else
                H = H + 1
            End If
        End If
        '==========================================
        If txtRepetirContraseña.Text = "" Then
            Label108.Visible = True
        Else
            If txtRepetirContraseña.TextLength < 6 Then
                Label111.Visible = True
            Else
                If txtRepetirContraseña.Text = txtContraseñaNueva.Text Then
                    H = H + 1
                Else
                    Label109.Visible = True
                End If
            End If
        End If
        '==========================================

        Try
            conexion.Open()


            cmd.CommandText = "SELECT password FROM usuario WHERE id=@id AND deleted=0"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@id", ID)
            r = cmd.ExecuteReader()

            If (r.HasRows) Then
                If (r.Read()) Then
                    If (generarClaveSHA1(txtContraseñaActual.Text) = r("password")) Then
                        H = H + 1

                    Else
                        If (txtContraseñaActual.Text <> "") Then
                            MsgBox("La contraseña actual es incorrecta")
                        End If
                    End If
                End If
            End If

            r.Close()
            If (H = 3) Then

                Dim resultado As String
                resultado = MsgBox("¿ESTA SEGURO DE QUE DESEA CAMBIAR LA CONTRASEÑA?", vbOKCancel, "CONFIRMACION")

                If resultado = vbOK Then
                    LabelCorrectChangePass.Visible = True
                    cmd.CommandText = "UPDATE usuario SET password=@pass WHERE id=@id"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@pass", generarClaveSHA1(txtContraseñaNueva.Text))
                    cmd.Parameters.AddWithValue("@id", ID)
                    cmd.ExecuteNonQuery()
                    LabelCorrectChangePass.Visible = True
                    txtContraseñaNueva.Clear()
                    txtContraseñaActual.Clear()
                    txtRepetirContraseña.Clear()

                End If
            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            conexion.Close()
        End Try
        txtContraseñaNueva.Clear()
        txtContraseñaActual.Clear()
        txtRepetirContraseña.Clear()
    End Sub
    Private Sub TextBox16_Click(sender As Object, e As EventArgs) Handles txtContraseñaNueva.Click
        Label107.Visible = False
        Label110.Visible = False
        Label109.Visible = False
        LabelCorrectChangePass.Visible = False
    End Sub
    Private Sub TextBox18_Click(sender As Object, e As EventArgs) Handles txtRepetirContraseña.Click
        Label108.Visible = False
        Label111.Visible = False
        Label109.Visible = False
        LabelCorrectChangePass.Visible = False
    End Sub
    Private Sub TextBox24_Click(sender As Object, e As EventArgs) Handles txtContraseñaActual.Click
        Label117.Visible = False
        LabelCorrectChangePass.Visible = False
    End Sub
#End Region

#Region "Mis ventas"
    Private Sub Button55_Click(sender As Object, e As EventArgs) Handles btnMisVentas.Click

        If (Rol = "Cliente") Then
            MsgBox("Usted esta registrado como cliente,para poder ver sus Ventas Realizadas,dirijase a 'Mi info > Modificar > Rol' y seleccione vendedor,asi podra publicar nuevos articulos y ver los que ha vendido")
        Else
            tbTodos.SelectedTab = tbTodos.TabPages.Item(11)
            pnlMiInfo.Visible = False
            btnConfigOcultar.Visible = False
            Ocultarpaneles()

            Dim da As DataSet = New DataSet
            Dim adapta2r As MySqlDataAdapter = New MySqlDataAdapter
            Try
                conexion.Open()

                cmd.CommandText = "SELECT articulos.portada,articulos.Nombre,detalle_compra.Cantidad,detalle_compra.PrecioUnitario,compras.Fecha,compras.PrecioTotal,usuario.username from articulos,detalle_compra,compras,usuario where detalle_compra.id_articulo = articulos.id and compras.usuario_id = usuario.id and articulos.usuario_id = @userID and compras.id = detalle_compra.id_compra AND usuario.deleted=0"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@userID", ID)
                adapta2r.SelectCommand = cmd
                adapta2r.Fill(da, "Tabla")
                grdMisVentas.DataSource = da
                grdMisVentas.DataMember = "Tabla"

                If grdMisVentas.RowCount = 0 Then
                    lblSinVentas.Visible = True

                Else
                    lblSinVentas.Visible = False

                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            conexion.Close()

            Dim contador4 As Integer
            For Each grd In grdMisVentas.Rows
                Dim row As DataGridViewRow = grdMisVentas.Rows(contador4)
                row.Height = 150
                contador4 = contador4 + 1
                CType(grdMisVentas.Columns("portada"), DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom
            Next
            grdMisVentas.Columns(0).Width = 150
            grdMisVentas.Columns(1).Width = 150
            grdMisVentas.Columns(2).Width = 100
            grdMisVentas.Columns(3).Width = 120
            grdMisVentas.Columns(4).Width = 150
            grdMisVentas.Columns(5).Width = 120
            grdMisVentas.Columns(6).Width = 150
            grdMisVentas.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 15)
        End If

    End Sub
#End Region

#Region "Cerrar Sesion"
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        ocultarLogin(True, False)
        ocultarregistro(True, False)
        pnlPerfil.Visible = False
        btnConfigOcultar.Visible = False
        pnlConfig.Visible = False
        tbTodos.SelectedTab = tbTodos.TabPages.Item(0)
        pnlInicio.Visible = True
        Ocultarpaneles()

        'Destruye la sesion'
        sesion = False
        carrito.Clear()
        ActualizarSelectArticulos()
        ajustarGrid()
    End Sub
#End Region

#End Region

End Class