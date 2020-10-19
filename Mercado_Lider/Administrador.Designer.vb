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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tcAdmin = New System.Windows.Forms.TabControl()
        Me.tpArticulos = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.NomArtLbl = New System.Windows.Forms.Label()
        Me.idArtLabel = New System.Windows.Forms.Label()
        Me.lblIDArt = New System.Windows.Forms.Label()
        Me.lblNomArt = New System.Windows.Forms.Label()
        Me.dataGridArticulos = New System.Windows.Forms.DataGridView()
        Me.btnEliminar1 = New System.Windows.Forms.Button()
        Me.tpUsuarios = New System.Windows.Forms.TabPage()
        Me.lblPassCambiada = New System.Windows.Forms.Label()
        Me.lblPassVacia = New System.Windows.Forms.Label()
        Me.txtSetContra = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grdUsuarios = New System.Windows.Forms.DataGridView()
        Me.lblTituloUser = New System.Windows.Forms.Label()
        Me.btnAgregarAdmin = New System.Windows.Forms.Button()
        Me.btnEliminarUser = New System.Windows.Forms.Button()
        Me.btnContraseña = New System.Windows.Forms.Button()
        Me.tpTransacciones = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label126 = New System.Windows.Forms.Label()
        Me.grdTransacciones = New System.Windows.Forms.DataGridView()
        Me.idCompraColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CompradorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PagoColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VendedorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tcAdmin.SuspendLayout()
        Me.tpArticulos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dataGridArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpUsuarios.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTransacciones.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.tpArticulos.Controls.Add(Me.Panel1)
        Me.tpArticulos.Controls.Add(Me.NomArtLbl)
        Me.tpArticulos.Controls.Add(Me.idArtLabel)
        Me.tpArticulos.Controls.Add(Me.lblIDArt)
        Me.tpArticulos.Controls.Add(Me.lblNomArt)
        Me.tpArticulos.Controls.Add(Me.dataGridArticulos)
        Me.tpArticulos.Controls.Add(Me.btnEliminar1)
        Me.tpArticulos.Location = New System.Drawing.Point(4, 22)
        Me.tpArticulos.Name = "tpArticulos"
        Me.tpArticulos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpArticulos.Size = New System.Drawing.Size(972, 501)
        Me.tpArticulos.TabIndex = 0
        Me.tpArticulos.Text = "Articulos"
        Me.tpArticulos.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Location = New System.Drawing.Point(-16, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(988, 49)
        Me.Panel1.TabIndex = 51
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.Location = New System.Drawing.Point(801, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "VENDEDOR"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label1.Location = New System.Drawing.Point(663, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "STOCK"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label14.Location = New System.Drawing.Point(538, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 13)
        Me.Label14.TabIndex = 59
        Me.Label14.Text = "PRECIO"
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label15.Location = New System.Drawing.Point(405, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = "NOMBRE"
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label16.Location = New System.Drawing.Point(309, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(24, 13)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "ID "
        '
        'NomArtLbl
        '
        Me.NomArtLbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.NomArtLbl.AutoSize = True
        Me.NomArtLbl.Location = New System.Drawing.Point(522, 438)
        Me.NomArtLbl.Name = "NomArtLbl"
        Me.NomArtLbl.Size = New System.Drawing.Size(39, 13)
        Me.NomArtLbl.TabIndex = 50
        Me.NomArtLbl.Text = "Label4"
        '
        'idArtLabel
        '
        Me.idArtLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.idArtLabel.AutoSize = True
        Me.idArtLabel.Location = New System.Drawing.Point(477, 414)
        Me.idArtLabel.Name = "idArtLabel"
        Me.idArtLabel.Size = New System.Drawing.Size(39, 13)
        Me.idArtLabel.TabIndex = 49
        Me.idArtLabel.Text = "Label3"
        '
        'lblIDArt
        '
        Me.lblIDArt.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblIDArt.AutoSize = True
        Me.lblIDArt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDArt.Location = New System.Drawing.Point(438, 409)
        Me.lblIDArt.Name = "lblIDArt"
        Me.lblIDArt.Size = New System.Drawing.Size(33, 20)
        Me.lblIDArt.TabIndex = 48
        Me.lblIDArt.Text = "ID:"
        '
        'lblNomArt
        '
        Me.lblNomArt.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblNomArt.AutoSize = True
        Me.lblNomArt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomArt.Location = New System.Drawing.Point(441, 433)
        Me.lblNomArt.Name = "lblNomArt"
        Me.lblNomArt.Size = New System.Drawing.Size(75, 20)
        Me.lblNomArt.TabIndex = 47
        Me.lblNomArt.Text = "Articulo:"
        '
        'dataGridArticulos
        '
        Me.dataGridArticulos.AllowUserToAddRows = False
        Me.dataGridArticulos.AllowUserToDeleteRows = False
        Me.dataGridArticulos.AllowUserToResizeColumns = False
        Me.dataGridArticulos.AllowUserToResizeRows = False
        Me.dataGridArticulos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.dataGridArticulos.BackgroundColor = System.Drawing.Color.White
        Me.dataGridArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dataGridArticulos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridArticulos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.dataGridArticulos.ColumnHeadersHeight = 40
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataGridArticulos.DefaultCellStyle = DataGridViewCellStyle27
        Me.dataGridArticulos.GridColor = System.Drawing.Color.White
        Me.dataGridArticulos.Location = New System.Drawing.Point(67, 21)
        Me.dataGridArticulos.MultiSelect = False
        Me.dataGridArticulos.Name = "dataGridArticulos"
        Me.dataGridArticulos.ReadOnly = True
        Me.dataGridArticulos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridArticulos.RowHeadersDefaultCellStyle = DataGridViewCellStyle28
        Me.dataGridArticulos.RowHeadersWidth = 60
        DataGridViewCellStyle29.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.Black
        Me.dataGridArticulos.RowsDefaultCellStyle = DataGridViewCellStyle29
        Me.dataGridArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridArticulos.Size = New System.Drawing.Size(902, 388)
        Me.dataGridArticulos.TabIndex = 46
        '
        'btnEliminar1
        '
        Me.btnEliminar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEliminar1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar1.ForeColor = System.Drawing.Color.Black
        Me.btnEliminar1.Location = New System.Drawing.Point(445, 456)
        Me.btnEliminar1.Name = "btnEliminar1"
        Me.btnEliminar1.Size = New System.Drawing.Size(158, 27)
        Me.btnEliminar1.TabIndex = 45
        Me.btnEliminar1.Text = "ELIMINAR ARTICULO"
        Me.btnEliminar1.UseVisualStyleBackColor = True
        '
        'tpUsuarios
        '
        Me.tpUsuarios.Controls.Add(Me.lblPassCambiada)
        Me.tpUsuarios.Controls.Add(Me.lblPassVacia)
        Me.tpUsuarios.Controls.Add(Me.txtSetContra)
        Me.tpUsuarios.Controls.Add(Me.Panel2)
        Me.tpUsuarios.Controls.Add(Me.grdUsuarios)
        Me.tpUsuarios.Controls.Add(Me.lblTituloUser)
        Me.tpUsuarios.Controls.Add(Me.btnAgregarAdmin)
        Me.tpUsuarios.Controls.Add(Me.btnEliminarUser)
        Me.tpUsuarios.Controls.Add(Me.btnContraseña)
        Me.tpUsuarios.Location = New System.Drawing.Point(4, 22)
        Me.tpUsuarios.Name = "tpUsuarios"
        Me.tpUsuarios.Padding = New System.Windows.Forms.Padding(3)
        Me.tpUsuarios.Size = New System.Drawing.Size(972, 501)
        Me.tpUsuarios.TabIndex = 1
        Me.tpUsuarios.Text = "Usuarios"
        Me.tpUsuarios.UseVisualStyleBackColor = True
        '
        'lblPassCambiada
        '
        Me.lblPassCambiada.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblPassCambiada.AutoSize = True
        Me.lblPassCambiada.ForeColor = System.Drawing.Color.Green
        Me.lblPassCambiada.Location = New System.Drawing.Point(449, 400)
        Me.lblPassCambiada.Name = "lblPassCambiada"
        Me.lblPassCambiada.Size = New System.Drawing.Size(187, 13)
        Me.lblPassCambiada.TabIndex = 51
        Me.lblPassCambiada.Text = "¡Contraseña cambiada correctamente!"
        Me.lblPassCambiada.Visible = False
        '
        'lblPassVacia
        '
        Me.lblPassVacia.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblPassVacia.AutoSize = True
        Me.lblPassVacia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPassVacia.Location = New System.Drawing.Point(458, 439)
        Me.lblPassVacia.Name = "lblPassVacia"
        Me.lblPassVacia.Size = New System.Drawing.Size(170, 13)
        Me.lblPassVacia.TabIndex = 50
        Me.lblPassVacia.Text = "*Este campo no puede estar vacio"
        Me.lblPassVacia.Visible = False
        '
        'txtSetContra
        '
        Me.txtSetContra.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtSetContra.Location = New System.Drawing.Point(479, 416)
        Me.txtSetContra.Name = "txtSetContra"
        Me.txtSetContra.Size = New System.Drawing.Size(127, 20)
        Me.txtSetContra.TabIndex = 49
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(-16, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(988, 34)
        Me.Panel2.TabIndex = 48
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label7.Location = New System.Drawing.Point(148, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "ID"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label3.Location = New System.Drawing.Point(872, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "ROL"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label4.Location = New System.Drawing.Point(660, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "CONTRASEÑA"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label5.Location = New System.Drawing.Point(462, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "E-MAIL"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label6.Location = New System.Drawing.Point(259, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "USERNAME"
        '
        'grdUsuarios
        '
        Me.grdUsuarios.AllowUserToAddRows = False
        Me.grdUsuarios.AllowUserToDeleteRows = False
        Me.grdUsuarios.AllowUserToResizeColumns = False
        Me.grdUsuarios.AllowUserToResizeRows = False
        Me.grdUsuarios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.grdUsuarios.BackgroundColor = System.Drawing.Color.White
        Me.grdUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdUsuarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle30
        Me.grdUsuarios.ColumnHeadersHeight = 30
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle31.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdUsuarios.DefaultCellStyle = DataGridViewCellStyle31
        Me.grdUsuarios.GridColor = System.Drawing.Color.White
        Me.grdUsuarios.Location = New System.Drawing.Point(126, 58)
        Me.grdUsuarios.MultiSelect = False
        Me.grdUsuarios.Name = "grdUsuarios"
        Me.grdUsuarios.ReadOnly = True
        Me.grdUsuarios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdUsuarios.RowHeadersDefaultCellStyle = DataGridViewCellStyle32
        Me.grdUsuarios.RowHeadersWidth = 30
        DataGridViewCellStyle33.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.Black
        Me.grdUsuarios.RowsDefaultCellStyle = DataGridViewCellStyle33
        Me.grdUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdUsuarios.Size = New System.Drawing.Size(846, 340)
        Me.grdUsuarios.TabIndex = 47
        '
        'lblTituloUser
        '
        Me.lblTituloUser.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTituloUser.AutoSize = True
        Me.lblTituloUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloUser.Location = New System.Drawing.Point(442, 16)
        Me.lblTituloUser.Name = "lblTituloUser"
        Me.lblTituloUser.Size = New System.Drawing.Size(205, 39)
        Me.lblTituloUser.TabIndex = 37
        Me.lblTituloUser.Text = "USUARIOS"
        '
        'btnAgregarAdmin
        '
        Me.btnAgregarAdmin.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAgregarAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarAdmin.ForeColor = System.Drawing.Color.Black
        Me.btnAgregarAdmin.Location = New System.Drawing.Point(681, 457)
        Me.btnAgregarAdmin.Name = "btnAgregarAdmin"
        Me.btnAgregarAdmin.Size = New System.Drawing.Size(164, 22)
        Me.btnAgregarAdmin.TabIndex = 36
        Me.btnAgregarAdmin.Text = "ASIGNAR COMO ADMIN"
        Me.btnAgregarAdmin.UseVisualStyleBackColor = True
        '
        'btnEliminarUser
        '
        Me.btnEliminarUser.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEliminarUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarUser.ForeColor = System.Drawing.Color.Black
        Me.btnEliminarUser.Location = New System.Drawing.Point(284, 457)
        Me.btnEliminarUser.Name = "btnEliminarUser"
        Me.btnEliminarUser.Size = New System.Drawing.Size(131, 22)
        Me.btnEliminarUser.TabIndex = 34
        Me.btnEliminarUser.Text = "ELIMINAR"
        Me.btnEliminarUser.UseVisualStyleBackColor = True
        '
        'btnContraseña
        '
        Me.btnContraseña.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnContraseña.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnContraseña.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContraseña.ForeColor = System.Drawing.Color.Black
        Me.btnContraseña.Location = New System.Drawing.Point(456, 457)
        Me.btnContraseña.Name = "btnContraseña"
        Me.btnContraseña.Size = New System.Drawing.Size(172, 22)
        Me.btnContraseña.TabIndex = 33
        Me.btnContraseña.Text = "CAMBIAR CONTRASEÑA"
        Me.btnContraseña.UseVisualStyleBackColor = True
        '
        'tpTransacciones
        '
        Me.tpTransacciones.Controls.Add(Me.Panel3)
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
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Location = New System.Drawing.Point(-18, 60)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(988, 34)
        Me.Panel3.TabIndex = 49
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label8.Location = New System.Drawing.Point(174, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 13)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "ID DE COMPRA"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label9.Location = New System.Drawing.Point(891, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 64
        Me.Label9.Text = "VENDEDOR"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label10.Location = New System.Drawing.Point(747, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "PAGÓ"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label11.Location = New System.Drawing.Point(532, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 62
        Me.Label11.Text = "FECHA"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label12.Location = New System.Drawing.Point(347, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 13)
        Me.Label12.TabIndex = 61
        Me.Label12.Text = "COMPRADOR"
        '
        'Label126
        '
        Me.Label126.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label126.AutoSize = True
        Me.Label126.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label126.Location = New System.Drawing.Point(357, 15)
        Me.Label126.Name = "Label126"
        Me.Label126.Size = New System.Drawing.Size(327, 39)
        Me.Label126.TabIndex = 12
        Me.Label126.Text = "TRANSACCIONES"
        '
        'grdTransacciones
        '
        Me.grdTransacciones.AllowUserToAddRows = False
        Me.grdTransacciones.AllowUserToDeleteRows = False
        Me.grdTransacciones.AllowUserToResizeColumns = False
        Me.grdTransacciones.AllowUserToResizeRows = False
        Me.grdTransacciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.grdTransacciones.BackgroundColor = System.Drawing.Color.White
        Me.grdTransacciones.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdTransacciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.grdTransacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdTransacciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idCompraColumn, Me.CompradorColumn, Me.FechaColumn, Me.PagoColumn, Me.VendedorColumn})
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdTransacciones.DefaultCellStyle = DataGridViewCellStyle24
        Me.grdTransacciones.GridColor = System.Drawing.Color.White
        Me.grdTransacciones.Location = New System.Drawing.Point(126, 71)
        Me.grdTransacciones.MultiSelect = False
        Me.grdTransacciones.Name = "grdTransacciones"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdTransacciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.grdTransacciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grdTransacciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdTransacciones.Size = New System.Drawing.Size(841, 427)
        Me.grdTransacciones.TabIndex = 11
        '
        'idCompraColumn
        '
        Me.idCompraColumn.HeaderText = "IDCOMPRA"
        Me.idCompraColumn.Name = "idCompraColumn"
        Me.idCompraColumn.ReadOnly = True
        '
        'CompradorColumn
        '
        Me.CompradorColumn.HeaderText = "Comprador"
        Me.CompradorColumn.Name = "CompradorColumn"
        Me.CompradorColumn.ReadOnly = True
        '
        'FechaColumn
        '
        Me.FechaColumn.HeaderText = "Fecha"
        Me.FechaColumn.Name = "FechaColumn"
        '
        'PagoColumn
        '
        Me.PagoColumn.HeaderText = "Pago"
        Me.PagoColumn.Name = "PagoColumn"
        Me.PagoColumn.ReadOnly = True
        '
        'VendedorColumn
        '
        Me.VendedorColumn.HeaderText = "Vendedor"
        Me.VendedorColumn.Name = "VendedorColumn"
        Me.VendedorColumn.ReadOnly = True
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
        'Timer1
        '
        Me.Timer1.Interval = 3000
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
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dataGridArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpUsuarios.ResumeLayout(False)
        Me.tpUsuarios.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grdUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTransacciones.ResumeLayout(False)
        Me.tpTransacciones.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
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
    Friend WithEvents lblTituloUser As Label
    Friend WithEvents btnAgregarAdmin As Button
    Friend WithEvents btnEliminarUser As Button
    Friend WithEvents btnContraseña As Button
    Friend WithEvents Label126 As Label
    Friend WithEvents grdTransacciones As DataGridView
    Friend WithEvents lblIDArt As Label
    Friend WithEvents lblNomArt As Label
    Friend WithEvents dataGridArticulos As DataGridView
    Friend WithEvents NomArtLbl As Label
    Friend WithEvents idArtLabel As Label
    Friend WithEvents idCompraColumn As DataGridViewTextBoxColumn
    Friend WithEvents CompradorColumn As DataGridViewTextBoxColumn
    Friend WithEvents FechaColumn As DataGridViewTextBoxColumn
    Friend WithEvents PagoColumn As DataGridViewTextBoxColumn
    Friend WithEvents VendedorColumn As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents grdUsuarios As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSetContra As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblPassVacia As Label
    Friend WithEvents lblPassCambiada As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
End Class
