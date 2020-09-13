Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient
Public Class frmPrincipal
    Dim conexion As MySqlConnection
    Dim cmd As New MySqlCommand

    Dim r As MySqlDataReader

    ''Informacion de usuario''
    Dim ID As Integer
    Dim Username As String
    Dim Nombre As String
    Dim Apellido As String
    Dim Email As String
    Dim Rol As String
    Dim CI As String
    Dim Telefono As String


    'Objeto frmDomicilio para control de frm de domicilio'
    Dim frmDomicilio As Domicilio = New Domicilio


    Public Sub New()
        'Esta llamada es exigida por el diseñador.
        InitializeComponent()
        conexion = New MySqlConnection
        conexion.ConnectionString = "Server=localhost; database=mercadolider; Uid=root; pwd=;"


        'Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    'Metodos utiles que usaremos
    'Checkea la validacion ,retorna true si fue correcta o false si hay un error,modificando los labels de error durante el flujo.'

    Private Function checkvalidacion()
        Dim contador As Integer = 0
        '==========================================
        If txtUsername.Text = "" Then
            Label87.Visible = True
        Else
            If txtUsername.TextLength < 3 Then
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

    'Funcion que inserta email en la tabla
    Private Sub insertEmailTable(ByVal id As Integer, ByVal email As String, ByVal con As MySqlConnection)
        Dim cmd As New MySqlCommand

        cmd.Connection = con
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

    ''Check if Username existe''
    Private Function UserExist(ByVal username As String, ByVal con As MySqlConnection)
        Dim cmd As New MySqlCommand
        Dim dr As MySqlDataReader
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "SELECT * FROM usuario WHERE username=@user"
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@user", username)
        dr = cmd.ExecuteReader
        If (dr.HasRows) Then
            dr.Close()
            con.Close()
            Return True
        Else
            dr.Close()
            con.Close()
            Return False
        End If
        dr.Close()
    End Function

    ''ACTUALIZA LA INFORMACION  DE EL USUARIO DE LOS CAMPOS Y ETIQUETAS,CUANDO SE HACE ALGUN TIPO DE CAMBIO
    Private Sub UpdateUserInfo(ByVal id As Integer)
        Try
            conexion.Open()
            cmd.Connection = conexion

            cmd.CommandText = "SELECT * FROM usuario,useremail WHERE usuario.id=@id"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@id", id)
            r = cmd.ExecuteReader
            If (r.HasRows) Then
                If (r.Read) Then
                    ''Set campos de el formulario de modificar perfil''
                    txtNombreModificarPerfil.Text = r("Nombre")
                    txtUsernameModificarPerfil.Text = r("username")
                    txtCorreoModificarPerfil.Text = r("email")
                    txtApellidoModificarPerfil.Text = r("Apellido")
                    txtTelefonoModificarPerfil.Text = r("telefono")
                    ComboBoxRolModificarPerfil.Text = r("Rol")

                    ''Set labels de informacion 
                    lblUserInfo.Text = r("username")
                    lblRolInfo.Text = r("Rol")
                    lblEmailInfo.Text = r("email")

                    ''SET campos de Domicilio Modal''
                    frmDomicilio.TextBox1.Text = r("nroCalle")
                    frmDomicilio.TextBox2.Text = r("calle")
                    frmDomicilio.TextBox3.Text = r("esq")
                    frmDomicilio.TextBox4.Text = r("nroApto")
                    frmDomicilio.TextBox5.Text = r("ciudad")
                End If
            End If
            r.Close()
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    ''BOTONES DE IMPORTACION DE IMAGENES PARA INSERTAR ARTICULO EN LA BASE DE DATOS''
    Private Sub button_agregarImagen1_Click(sender As Object, e As EventArgs) Handles button_agregarImagen1.Click
        If OpenFileImagen1.ShowDialog() = DialogResult.OK Then
            PictureBoxImagen1.Load(OpenFileImagen1.FileName)
        End If
    End Sub
    Private Sub button_agregarImagen2_Click(sender As Object, e As EventArgs) Handles button_agregarImagen2.Click
        If OpenFileImagen2.ShowDialog() = DialogResult.OK Then
            PictureBoxImagen2.Load(OpenFileImagen2.FileName)
        End If
    End Sub
    Private Sub button_agregarImagen3_Click(sender As Object, e As EventArgs) Handles button_agregarImagen3.Click
        If OpenFileImagen3.ShowDialog() = DialogResult.OK Then
            PictureBoxImagen3.Load(OpenFileImagen3.FileName)
        End If
    End Sub
    Private Sub button_agregarPortada_Click(sender As Object, e As EventArgs) Handles button_agregarPortada.Click
        If OpenFilePortada.ShowDialog() = DialogResult.OK Then
            PictureBoxPortada.Load(OpenFilePortada.FileName)
        End If
    End Sub

    ''EVENTO DE EL BOTON DE CAMBIAR CONTRASEÑA 
    Private Sub Button48_Click(sender As Object, e As EventArgs) Handles btnAceptarPasswd.Click
        Dim H As Integer
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
        If (H = 2) Then
            Dim resultado As String
            resultado = MsgBox("ESTA SEGURO DE QUE DESEA CAMBIAR LA CONTRASEÑA", vbOKCancel, "CONFIRMACION")

            If resultado = vbOK Then
                LabelCorrectChangePass.Visible = True
                Try
                    conexion.Open()
                    cmd.CommandText = "UPDATE usuario SET password=@pass WHERE id=@id"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@pass", generarClaveSHA1(txtContraseñaNueva.Text))
                    cmd.Parameters.AddWithValue("@id", ID)
                    cmd.ExecuteNonQuery()
                    LabelCorrectChangePass.Visible = True
                    txtContraseñaNueva.Clear()
                    txtContraseñaActual.Clear()
                    txtRepetirContraseña.Clear()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Else
                txtContraseñaNueva.Clear()
                txtContraseñaActual.Clear()

                txtRepetirContraseña.Clear()
            End If
        End If
        '==========================================
        If txtContraseñaActual.Text = "" Then
            Label117.Visible = True
        End If
    End Sub

    'EVENTO DE BOTON DE EL FORMULARIO DE REGISTRO DE USUARIO
    Private Sub buttonRegister_Click(sender As Object, e As EventArgs) Handles buttonRegister.Click
        ''Funcion que retorna true si la validacion es correcta
        If (checkvalidacion()) Then
            If UserExist(txtUsername.Text, conexion) = False Then
                Try
                    conexion.Open()
                    cmd.Connection = conexion

                    ''INSERCION EN LA TABLA usuarios

                    cmd.CommandText = "INSERT INTO usuario (id,username, password, Nombre, Apellido, telefono, rol, nroCalle, calle, nroApto, esq) VALUES (NULL,@username , @password, NULL, NULL, @telefono, @rol, NULL, NULL, NULL, NULL);"
                    cmd.Prepare()
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                    cmd.Parameters.AddWithValue("@password", generarClaveSHA1(txtPass.Text))
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text)
                    cmd.Parameters.AddWithValue("@rol", cbxRol.Text)
                    cmd.ExecuteNonQuery()
                    ''Extraccion de ID de el registro anteriormente registrado para la insercion en otras tablas
                    cmd.CommandText = "SELECT id FROM usuario WHERE username=@username"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                    Dim rd As MySqlDataReader = cmd.ExecuteReader
                    If (rd.HasRows) Then    '
                        If rd.Read Then
                            Dim id As Integer = rd("id")
                            rd.Close()   ''Cierre de DataReader''
                            insertEmailTable(id, txtEmail.Text, conexion)   ''Inserta el email en la tabla 
                        End If
                    End If
                    rd.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("Ya existe un nombre de usuario con este nombre")
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

            cmd.CommandText = "SELECT usuario.id, usuario.username,usuario.Nombre, usuario.Apellido, usuario.telefono, usuario.rol , useremail.email from usuario,useremail where username=@nombre and password=@pass and useremail.user_id = usuario.id"
            cmd.Prepare()
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@nombre", txtusernamelogin.Text)
            cmd.Parameters.AddWithValue("@pass", generarClaveSHA1(txtpasslogin.Text))
            Dim r As MySqlDataReader = cmd.ExecuteReader()
            If r.HasRows Then
                If r.Read Then
                    ID = r("id")
                    Username = r("username")
                    Nombre = r("Nombre").ToString
                    Apellido = r("Apellido").ToString
                    Email = r("email")
                    Rol = r("rol")
                    'CI = r("ci")
                    Telefono = r("telefono").ToString
                    If (Rol = "Administrador") Then
                        Administrador.Show()
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



    ''EVENTO DE CLICK DE EL BOTON DE ACTUALIZAR INFORMACION
    Private Sub buttonSetInfo_Click(sender As Object, e As EventArgs) Handles buttonSetInfo.Click, btnCerrarSesion.Click
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
            If Not txtUsernameModificarPerfil.TextLength <= 6 Then
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
                    conexion.Close()
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
                    UpdateUserInfo(ID)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                conexion.Close()
            End If
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
            MsgBox("Necesitas agregar una foto de portada")
        End If

        If Not PictureBoxImagen1.Image Is Nothing Then
            validacionFrmArticulo = validacionFrmArticulo + 1
        Else
            MsgBox("Necesitas agregar una primer imagen")

        End If

        If Not PictureBoxImagen2.Image Is Nothing Then
            validacionFrmArticulo = validacionFrmArticulo + 1
        Else
            MsgBox("Necesitas agregar una segunda imagen")

        End If



        If Not PictureBoxImagen3.Image Is Nothing Then
            validacionFrmArticulo = validacionFrmArticulo + 1
        Else
            MsgBox("Necesitas agregar una tercera imagen")

        End If



        If validacionFrmArticulo = 8 Then




            Dim ms As New System.IO.MemoryStream()   ''Crea un buffer o reserva un espacio en memoria ran directamente  ram donde a futuro se trabajara con cantidad de datos importantes
            PictureBoxPortada.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim portada As Byte() = ms.GetBuffer








            Try

                conexion.Open()
                cmd.CommandText = "INSERT INTO articulos(Nombre,Precio,Descripcion,portada,stock,usuario_id) VALUES(@nombre,@precio,@descripcion,@portada,@stock,@usuario_id)"

                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@nombre", txtNombreArticulo.Text)
                cmd.Parameters.AddWithValue("@precio", txtPrecio.Text)
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcionArticulo.Text)
                cmd.Parameters.AddWithValue("@portada", portada)
                cmd.Parameters.AddWithValue("@stock", txtStockArticulo.Text)
                cmd.Parameters.AddWithValue("@usuario_id", ID)




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
                    nroFoto = nroFoto + 1

                    fotito.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim foto As Byte() = ms.GetBuffer

                    cmd.CommandText = "INSERT INTO galeria(articulo_id,fotos,nroFoto) VALUES(@articulo_id,@foto,@nroFoto)"

                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@articulo_id", idArticulo)
                    cmd.Parameters.AddWithValue("@foto", foto)
                    cmd.Parameters.AddWithValue("@nroFoto", nroFoto)

                    cmd.ExecuteNonQuery()





                    ms.Close()

                Next



                MsgBox("Articulo insertado correctamente")
                conexion.Close()






            Catch ex As Exception
                MsgBox(ex.ToString)
                conexion.Close()

            End Try




        End If



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
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Domicilio.Hide()
        ocultarbarritas()
        subbarritas()
        pnlInicio.Visible = True
        Combobox()
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
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxRolModificarPerfil.DropDownStyle = ComboBoxStyle.DropDownList
        cbxRol.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub
    Private Sub ocultarregistro(ByVal h As Boolean, ByVal x As Boolean)
        btnRegistrar.Visible = h
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
    End Sub
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(1)
        Ocultarpaneles()
        ocultarbarritas()
        lblRegistradoCorrectamente.Visible = False
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(2)
        Ocultarpaneles()
        ocultarbarritas()
    End Sub
    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(3)
        Ocultarpaneles()
        pnlMiInfo.Visible = False
        btnConfigOcultar.Visible = False
    End Sub
    Private Sub btnCarrito_Click(sender As Object, e As EventArgs) Handles btnCarrito.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(7)
        Ocultarpaneles()
        panelbotonescarrito.Visible = True
        ocultarbarritas()
        pnlEnca.Visible = True
        pnlCarrito.Visible = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(7)
        pnlPerfil.Visible = False
        subbarritas()
        pnlEnca.Visible = True
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(8)
        pnlPerfil.Visible = False
        subbarritas()
        pnlCom.Visible = True
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
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnPublicar.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(5)
        Ocultarpaneles()
        ocultarbarritas()
        Panel9.Visible = True
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
    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(6)
    End Sub
    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(6)
    End Sub
    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(6)
    End Sub
    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(4)
    End Sub
    Private Sub Button45_Click(sender As Object, e As EventArgs) Handles Button45.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(4)
    End Sub
    Private Sub Button47_Click(sender As Object, e As EventArgs) Handles Button47.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(4)
    End Sub
    Private Sub Button49_Click(sender As Object, e As EventArgs) Handles btnConfigOcultar.Click
        pnlPerfil.Visible = False
        pnlMiInfo.Visible = False
        pnlConfig.Visible = False
        btnConfigOcultar.Visible = False
    End Sub
    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
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
    End Sub
    Private Sub TextBox15_Click(sender As Object, e As EventArgs)
        Label85.Visible = False
        txtApellidoModificarPerfil.Clear()
        txtApellidoModificarPerfil.ForeColor = Color.Black
    End Sub
    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles txtUsername.Click
        Label87.Visible = False
        Label101.Visible = False
    End Sub
    Private Sub TextBox5_Click(sender As Object, e As EventArgs)
        txtNombreModificarPerfil.Clear()
        txtNombreModificarPerfil.ForeColor = Color.Black
    End Sub
    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles txtEmail.Click
        Label90.Visible = False
        Label102.Visible = False
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
    Private Sub tbxBuscar_Click(sender As Object, e As EventArgs) Handles tbxBuscar.Click
        tbxBuscar.Clear()
        tbxBuscar.ForeColor = Color.Black
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
    Private Sub Button13_Click_1(sender As Object, e As EventArgs) Handles btnOcultarMiInfo.Click
        pnlMiInfo.Visible = False
        btnOcultarMiInfo.Visible = False
    End Sub
    Private Sub Button55_Click(sender As Object, e As EventArgs) Handles btnMisVentas.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(11)
        pnlMiInfo.Visible = False
        btnConfigOcultar.Visible = False
        Ocultarpaneles()
    End Sub
    Private Sub TextBox19_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCedulaModificarPerfil.KeyPress
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
    Private Sub TextBox19_Click(sender As Object, e As EventArgs) Handles txtCedulaModificarPerfil.Click
        Label98.Visible = False
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
    Private Sub TextBox17_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub TextBox16_Click(sender As Object, e As EventArgs) Handles txtContraseñaNueva.Click
        Label107.Visible = False
        Label110.Visible = False
        Label109.Visible = False
    End Sub
    Private Sub TextBox18_Click(sender As Object, e As EventArgs) Handles txtRepetirContraseña.Click
        Label108.Visible = False
        Label111.Visible = False
        Label109.Visible = False
    End Sub
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
    Private Sub TextBox24_Click(sender As Object, e As EventArgs) Handles txtContraseñaActual.Click
        Label117.Visible = False
    End Sub
    Private Sub btnMisArticulos_Click(sender As Object, e As EventArgs) Handles btnMisArticulos.Click
        tbTodos.SelectedTab = tbTodos.TabPages.Item(3)
        pnlMiInfo.Visible = False
        btnConfigOcultar.Visible = False
        Ocultarpaneles()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        ocultarLogin(True, False)
        ocultarregistro(True, False)
        pnlPerfil.Visible = False
        btnConfigOcultar.Visible = False
        pnlConfig.Visible = False
    End Sub


End Class