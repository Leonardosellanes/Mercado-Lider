<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Administrador
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tcAdmin = New System.Windows.Forms.TabControl()
        Me.tpArticulos = New System.Windows.Forms.TabPage()
        Me.btnEliminar1 = New System.Windows.Forms.Button()
        Me.btnEliminar3 = New System.Windows.Forms.Button()
        Me.btnEliminar2 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.tpUsuarios = New System.Windows.Forms.TabPage()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.btnAgregarAdmin = New System.Windows.Forms.Button()
        Me.grdUsuarios = New System.Windows.Forms.DataGridView()
        Me.btnEliminarUser = New System.Windows.Forms.Button()
        Me.btnContraseña = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tpTransacciones = New System.Windows.Forms.TabPage()
        Me.Label126 = New System.Windows.Forms.Label()
        Me.grdTransacciones = New System.Windows.Forms.DataGridView()
        Me.pnlAdmin = New System.Windows.Forms.Panel()
        Me.pnlTransacciones = New System.Windows.Forms.Panel()
        Me.pnlUsuarios = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnTransacciones = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnUsuarios = New System.Windows.Forms.Button()
        Me.pnlArticulos = New System.Windows.Forms.Panel()
        Me.btnArticulos = New System.Windows.Forms.Button()
        Me.pnlSuperior = New System.Windows.Forms.Panel()
        Me.tcAdmin.SuspendLayout()
        Me.tpArticulos.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpUsuarios.SuspendLayout()
        CType(Me.grdUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTransacciones.SuspendLayout()
        CType(Me.grdTransacciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAdmin.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcAdmin
        '
        Me.tcAdmin.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tcAdmin.Controls.Add(Me.tpArticulos)
        Me.tcAdmin.Controls.Add(Me.tpUsuarios)
        Me.tcAdmin.Controls.Add(Me.tpTransacciones)
        Me.tcAdmin.Location = New System.Drawing.Point(12, 1)
        Me.tcAdmin.Name = "tcAdmin"
        Me.tcAdmin.SelectedIndex = 0
        Me.tcAdmin.Size = New System.Drawing.Size(980, 527)
        Me.tcAdmin.TabIndex = 0
        '
        'tpArticulos
        '
        Me.tpArticulos.Controls.Add(Me.btnEliminar1)
        Me.tpArticulos.Controls.Add(Me.btnEliminar3)
        Me.tpArticulos.Controls.Add(Me.btnEliminar2)
        Me.tpArticulos.Controls.Add(Me.Label9)
        Me.tpArticulos.Controls.Add(Me.Label10)
        Me.tpArticulos.Controls.Add(Me.Label11)
        Me.tpArticulos.Controls.Add(Me.Label12)
        Me.tpArticulos.Controls.Add(Me.Label13)
        Me.tpArticulos.Controls.Add(Me.Label14)
        Me.tpArticulos.Controls.Add(Me.PictureBox4)
        Me.tpArticulos.Controls.Add(Me.PictureBox5)
        Me.tpArticulos.Controls.Add(Me.PictureBox6)
        Me.tpArticulos.Location = New System.Drawing.Point(4, 22)
        Me.tpArticulos.Name = "tpArticulos"
        Me.tpArticulos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpArticulos.Size = New System.Drawing.Size(972, 501)
        Me.tpArticulos.TabIndex = 0
        Me.tpArticulos.Text = "Articulos"
        Me.tpArticulos.UseVisualStyleBackColor = True
        '
        'btnEliminar1
        '
        Me.btnEliminar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar1.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar1.Location = New System.Drawing.Point(783, 68)
        Me.btnEliminar1.Name = "btnEliminar1"
        Me.btnEliminar1.Size = New System.Drawing.Size(158, 27)
        Me.btnEliminar1.TabIndex = 45
        Me.btnEliminar1.Text = "ELIMINAR ARTICULO"
        Me.btnEliminar1.UseVisualStyleBackColor = True
        '
        'btnEliminar3
        '
        Me.btnEliminar3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar3.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar3.Location = New System.Drawing.Point(785, 358)
        Me.btnEliminar3.Name = "btnEliminar3"
        Me.btnEliminar3.Size = New System.Drawing.Size(158, 27)
        Me.btnEliminar3.TabIndex = 44
        Me.btnEliminar3.Text = "ELIMINAR ARTICULO"
        Me.btnEliminar3.UseVisualStyleBackColor = True
        '
        'btnEliminar2
        '
        Me.btnEliminar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar2.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar2.Location = New System.Drawing.Point(783, 212)
        Me.btnEliminar2.Name = "btnEliminar2"
        Me.btnEliminar2.Size = New System.Drawing.Size(158, 27)
        Me.btnEliminar2.TabIndex = 43
        Me.btnEliminar2.Text = "ELIMINAR ARTICULO"
        Me.btnEliminar2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(332, 403)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 20)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Precio"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(279, 358)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(165, 25)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Nombre Articulo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(332, 257)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 20)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Precio"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(279, 212)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(165, 25)
        Me.Label12.TabIndex = 38
        Me.Label12.Text = "Nombre Articulo"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(332, 114)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 20)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Precio"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(279, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(165, 25)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "Nombre Articulo"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Gray
        Me.PictureBox4.Location = New System.Drawing.Point(159, 342)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(97, 93)
        Me.PictureBox4.TabIndex = 40
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Gray
        Me.PictureBox5.Location = New System.Drawing.Point(159, 196)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(97, 93)
        Me.PictureBox5.TabIndex = 37
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Gray
        Me.PictureBox6.Location = New System.Drawing.Point(159, 53)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(97, 93)
        Me.PictureBox6.TabIndex = 34
        Me.PictureBox6.TabStop = False
        '
        'tpUsuarios
        '
        Me.tpUsuarios.Controls.Add(Me.Label127)
        Me.tpUsuarios.Controls.Add(Me.btnAgregarAdmin)
        Me.tpUsuarios.Controls.Add(Me.grdUsuarios)
        Me.tpUsuarios.Controls.Add(Me.btnEliminarUser)
        Me.tpUsuarios.Controls.Add(Me.btnContraseña)
        Me.tpUsuarios.Controls.Add(Me.Label15)
        Me.tpUsuarios.Controls.Add(Me.Label16)
        Me.tpUsuarios.Controls.Add(Me.Label17)
        Me.tpUsuarios.Controls.Add(Me.Label18)
        Me.tpUsuarios.Location = New System.Drawing.Point(4, 22)
        Me.tpUsuarios.Name = "tpUsuarios"
        Me.tpUsuarios.Padding = New System.Windows.Forms.Padding(3)
        Me.tpUsuarios.Size = New System.Drawing.Size(972, 501)
        Me.tpUsuarios.TabIndex = 1
        Me.tpUsuarios.Text = "Usuarios"
        Me.tpUsuarios.UseVisualStyleBackColor = True
        '
        'Label127
        '
        Me.Label127.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label127.AutoSize = True
        Me.Label127.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label127.Location = New System.Drawing.Point(434, 44)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(205, 39)
        Me.Label127.TabIndex = 37
        Me.Label127.Text = "USUARIOS"
        '
        'btnAgregarAdmin
        '
        Me.btnAgregarAdmin.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAgregarAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarAdmin.ForeColor = System.Drawing.Color.Black
        Me.btnAgregarAdmin.Location = New System.Drawing.Point(636, 438)
        Me.btnAgregarAdmin.Name = "btnAgregarAdmin"
        Me.btnAgregarAdmin.Size = New System.Drawing.Size(131, 22)
        Me.btnAgregarAdmin.TabIndex = 36
        Me.btnAgregarAdmin.Text = "AGREGAR ADMIN"
        Me.btnAgregarAdmin.UseVisualStyleBackColor = True
        '
        'grdUsuarios
        '
        Me.grdUsuarios.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grdUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdUsuarios.Location = New System.Drawing.Point(297, 143)
        Me.grdUsuarios.Name = "grdUsuarios"
        Me.grdUsuarios.Size = New System.Drawing.Size(488, 269)
        Me.grdUsuarios.TabIndex = 35
        '
        'btnEliminarUser
        '
        Me.btnEliminarUser.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnEliminarUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarUser.ForeColor = System.Drawing.Color.Black
        Me.btnEliminarUser.Location = New System.Drawing.Point(321, 438)
        Me.btnEliminarUser.Name = "btnEliminarUser"
        Me.btnEliminarUser.Size = New System.Drawing.Size(131, 22)
        Me.btnEliminarUser.TabIndex = 34
        Me.btnEliminarUser.Text = "ELIMINAR"
        Me.btnEliminarUser.UseVisualStyleBackColor = True
        '
        'btnContraseña
        '
        Me.btnContraseña.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnContraseña.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnContraseña.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContraseña.ForeColor = System.Drawing.Color.Black
        Me.btnContraseña.Location = New System.Drawing.Point(458, 438)
        Me.btnContraseña.Name = "btnContraseña"
        Me.btnContraseña.Size = New System.Drawing.Size(172, 22)
        Me.btnContraseña.TabIndex = 33
        Me.btnContraseña.Text = "CAMBIAR CONTRASEÑA"
        Me.btnContraseña.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(689, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 13)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "ROL"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(556, 120)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 13)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "CONTRASEÑA"
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(450, 120)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "CORREO"
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(335, 120)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 13)
        Me.Label18.TabIndex = 29
        Me.Label18.Text = "USUARIO"
        '
        'tpTransacciones
        '
        Me.tpTransacciones.Controls.Add(Me.Label126)
        Me.tpTransacciones.Controls.Add(Me.grdTransacciones)
        Me.tpTransacciones.Location = New System.Drawing.Point(4, 22)
        Me.tpTransacciones.Name = "tpTransacciones"
        Me.tpTransacciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTransacciones.Size = New System.Drawing.Size(972, 501)
        Me.tpTransacciones.TabIndex = 2
        Me.tpTransacciones.Text = "Transacciones"
        Me.tpTransacciones.UseVisualStyleBackColor = True
        '
        'Label126
        '
        Me.Label126.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label126.AutoSize = True
        Me.Label126.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label126.Location = New System.Drawing.Point(357, 23)
        Me.Label126.Name = "Label126"
        Me.Label126.Size = New System.Drawing.Size(327, 39)
        Me.Label126.TabIndex = 12
        Me.Label126.Text = "TRANSACCIONES"
        '
        'grdTransacciones
        '
        Me.grdTransacciones.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grdTransacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTransacciones.Location = New System.Drawing.Point(208, 71)
        Me.grdTransacciones.Name = "grdTransacciones"
        Me.grdTransacciones.Size = New System.Drawing.Size(651, 408)
        Me.grdTransacciones.TabIndex = 11
        '
        'pnlAdmin
        '
        Me.pnlAdmin.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.pnlAdmin.Controls.Add(Me.pnlTransacciones)
        Me.pnlAdmin.Controls.Add(Me.pnlUsuarios)
        Me.pnlAdmin.Controls.Add(Me.Panel6)
        Me.pnlAdmin.Controls.Add(Me.btnTransacciones)
        Me.pnlAdmin.Controls.Add(Me.Panel4)
        Me.pnlAdmin.Controls.Add(Me.btnUsuarios)
        Me.pnlAdmin.Controls.Add(Me.pnlArticulos)
        Me.pnlAdmin.Controls.Add(Me.btnArticulos)
        Me.pnlAdmin.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAdmin.Location = New System.Drawing.Point(0, 0)
        Me.pnlAdmin.Name = "pnlAdmin"
        Me.pnlAdmin.Size = New System.Drawing.Size(142, 518)
        Me.pnlAdmin.TabIndex = 7
        '
        'pnlTransacciones
        '
        Me.pnlTransacciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlTransacciones.Location = New System.Drawing.Point(137, 183)
        Me.pnlTransacciones.Name = "pnlTransacciones"
        Me.pnlTransacciones.Size = New System.Drawing.Size(5, 27)
        Me.pnlTransacciones.TabIndex = 20
        '
        'pnlUsuarios
        '
        Me.pnlUsuarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlUsuarios.Location = New System.Drawing.Point(137, 151)
        Me.pnlUsuarios.Name = "pnlUsuarios"
        Me.pnlUsuarios.Size = New System.Drawing.Size(5, 27)
        Me.pnlUsuarios.TabIndex = 19
        '
        'Panel6
        '
        Me.Panel6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel6.Location = New System.Drawing.Point(-261, 98)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(6, 27)
        Me.Panel6.TabIndex = 18
        '
        'btnTransacciones
        '
        Me.btnTransacciones.FlatAppearance.BorderSize = 0
        Me.btnTransacciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnTransacciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnTransacciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransacciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransacciones.ForeColor = System.Drawing.Color.White
        Me.btnTransacciones.Image = Global.Mercado_Lider.My.Resources.Resources.pagos
        Me.btnTransacciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTransacciones.Location = New System.Drawing.Point(-13, 183)
        Me.btnTransacciones.Name = "btnTransacciones"
        Me.btnTransacciones.Size = New System.Drawing.Size(150, 27)
        Me.btnTransacciones.TabIndex = 17
        Me.btnTransacciones.Text = "TRANSACCIONES"
        Me.btnTransacciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTransacciones.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel4.Location = New System.Drawing.Point(-261, 71)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(6, 27)
        Me.Panel4.TabIndex = 16
        '
        'btnUsuarios
        '
        Me.btnUsuarios.FlatAppearance.BorderSize = 0
        Me.btnUsuarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnUsuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUsuarios.ForeColor = System.Drawing.Color.White
        Me.btnUsuarios.Image = Global.Mercado_Lider.My.Resources.Resources.clientes
        Me.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUsuarios.Location = New System.Drawing.Point(-6, 151)
        Me.btnUsuarios.Name = "btnUsuarios"
        Me.btnUsuarios.Size = New System.Drawing.Size(142, 27)
        Me.btnUsuarios.TabIndex = 15
        Me.btnUsuarios.Text = "USUARIOS"
        Me.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUsuarios.UseVisualStyleBackColor = True
        '
        'pnlArticulos
        '
        Me.pnlArticulos.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.pnlArticulos.Location = New System.Drawing.Point(137, 121)
        Me.pnlArticulos.Name = "pnlArticulos"
        Me.pnlArticulos.Size = New System.Drawing.Size(5, 27)
        Me.pnlArticulos.TabIndex = 14
        '
        'btnArticulos
        '
        Me.btnArticulos.FlatAppearance.BorderSize = 0
        Me.btnArticulos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.btnArticulos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnArticulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArticulos.ForeColor = System.Drawing.Color.White
        Me.btnArticulos.Image = Global.Mercado_Lider.My.Resources.Resources.producto
        Me.btnArticulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnArticulos.Location = New System.Drawing.Point(-6, 121)
        Me.btnArticulos.Name = "btnArticulos"
        Me.btnArticulos.Size = New System.Drawing.Size(142, 27)
        Me.btnArticulos.TabIndex = 13
        Me.btnArticulos.Text = "ARTICULOS"
        Me.btnArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnArticulos.UseVisualStyleBackColor = True
        '
        'pnlSuperior
        '
        Me.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSuperior.Location = New System.Drawing.Point(142, 0)
        Me.pnlSuperior.Name = "pnlSuperior"
        Me.pnlSuperior.Size = New System.Drawing.Size(841, 36)
        Me.pnlSuperior.TabIndex = 8
        '
        'Administrador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 518)
        Me.Controls.Add(Me.pnlSuperior)
        Me.Controls.Add(Me.pnlAdmin)
        Me.Controls.Add(Me.tcAdmin)
        Me.MinimumSize = New System.Drawing.Size(999, 557)
        Me.Name = "Administrador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administrador"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tcAdmin.ResumeLayout(False)
        Me.tpArticulos.ResumeLayout(False)
        Me.tpArticulos.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpUsuarios.ResumeLayout(False)
        Me.tpUsuarios.PerformLayout()
        CType(Me.grdUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTransacciones.ResumeLayout(False)
        Me.tpTransacciones.PerformLayout()
        CType(Me.grdTransacciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAdmin.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tcAdmin As TabControl
    Friend WithEvents tpArticulos As TabPage
    Friend WithEvents tpUsuarios As TabPage
    Friend WithEvents pnlAdmin As Panel
    Friend WithEvents pnlTransacciones As Panel
    Friend WithEvents pnlUsuarios As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnTransacciones As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnUsuarios As Button
    Friend WithEvents pnlArticulos As Panel
    Friend WithEvents btnArticulos As Button
    Friend WithEvents tpTransacciones As TabPage
    Friend WithEvents pnlSuperior As Panel
    Friend WithEvents btnEliminar1 As Button
    Friend WithEvents btnEliminar3 As Button
    Friend WithEvents btnEliminar2 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Label127 As Label
    Friend WithEvents btnAgregarAdmin As Button
    Friend WithEvents grdUsuarios As DataGridView
    Friend WithEvents btnEliminarUser As Button
    Friend WithEvents btnContraseña As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label126 As Label
    Friend WithEvents grdTransacciones As DataGridView
End Class
