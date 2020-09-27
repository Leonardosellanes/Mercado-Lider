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
        Me.NomArtLbl = New System.Windows.Forms.Label()
        Me.idArtLabel = New System.Windows.Forms.Label()
        Me.lblIDArt = New System.Windows.Forms.Label()
        Me.lblNomArt = New System.Windows.Forms.Label()
        Me.dataGridArticulos = New System.Windows.Forms.DataGridView()
        Me.btnEliminar1 = New System.Windows.Forms.Button()
        Me.tpUsuarios = New System.Windows.Forms.TabPage()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.btnAgregarAdmin = New System.Windows.Forms.Button()
        Me.grdUsuarios = New System.Windows.Forms.DataGridView()
        Me.btnEliminarUser = New System.Windows.Forms.Button()
        Me.btnContraseña = New System.Windows.Forms.Button()
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
        Me.idCompraColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CompradorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PagoColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VendedorColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tcAdmin.SuspendLayout()
        Me.tpArticulos.SuspendLayout()
        CType(Me.dataGridArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'NomArtLbl
        '
        Me.NomArtLbl.AutoSize = True
        Me.NomArtLbl.Location = New System.Drawing.Point(522, 438)
        Me.NomArtLbl.Name = "NomArtLbl"
        Me.NomArtLbl.Size = New System.Drawing.Size(39, 13)
        Me.NomArtLbl.TabIndex = 50
        Me.NomArtLbl.Text = "Label4"
        '
        'idArtLabel
        '
        Me.idArtLabel.AutoSize = True
        Me.idArtLabel.Location = New System.Drawing.Point(480, 402)
        Me.idArtLabel.Name = "idArtLabel"
        Me.idArtLabel.Size = New System.Drawing.Size(39, 13)
        Me.idArtLabel.TabIndex = 49
        Me.idArtLabel.Text = "Label3"
        '
        'lblIDArt
        '
        Me.lblIDArt.AutoSize = True
        Me.lblIDArt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIDArt.Location = New System.Drawing.Point(441, 397)
        Me.lblIDArt.Name = "lblIDArt"
        Me.lblIDArt.Size = New System.Drawing.Size(33, 20)
        Me.lblIDArt.TabIndex = 48
        Me.lblIDArt.Text = "ID:"
        '
        'lblNomArt
        '
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
        Me.dataGridArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridArticulos.Location = New System.Drawing.Point(167, 19)
        Me.dataGridArticulos.Name = "dataGridArticulos"
        Me.dataGridArticulos.Size = New System.Drawing.Size(788, 375)
        Me.dataGridArticulos.TabIndex = 46
        '
        'btnEliminar1
        '
        Me.btnEliminar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.tpUsuarios.Controls.Add(Me.Label127)
        Me.tpUsuarios.Controls.Add(Me.btnAgregarAdmin)
        Me.tpUsuarios.Controls.Add(Me.grdUsuarios)
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
        'Label127
        '
        Me.Label127.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label127.AutoSize = True
        Me.Label127.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label127.Location = New System.Drawing.Point(442, 16)
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
        Me.btnAgregarAdmin.Location = New System.Drawing.Point(689, 438)
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
        Me.grdUsuarios.Location = New System.Drawing.Point(220, 58)
        Me.grdUsuarios.Name = "grdUsuarios"
        Me.grdUsuarios.Size = New System.Drawing.Size(680, 361)
        Me.grdUsuarios.TabIndex = 35
        '
        'btnEliminarUser
        '
        Me.btnEliminarUser.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnEliminarUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarUser.ForeColor = System.Drawing.Color.Black
        Me.btnEliminarUser.Location = New System.Drawing.Point(292, 438)
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
        Me.btnContraseña.Location = New System.Drawing.Point(464, 438)
        Me.btnContraseña.Name = "btnContraseña"
        Me.btnContraseña.Size = New System.Drawing.Size(172, 22)
        Me.btnContraseña.TabIndex = 33
        Me.btnContraseña.Text = "CAMBIAR CONTRASEÑA"
        Me.btnContraseña.UseVisualStyleBackColor = True
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
        Me.grdTransacciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idCompraColumn, Me.CompradorColumn, Me.FechaColumn, Me.PagoColumn, Me.VendedorColumn})
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
        CType(Me.dataGridArticulos, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label127 As Label
    Friend WithEvents btnAgregarAdmin As Button
    Friend WithEvents grdUsuarios As DataGridView
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
End Class
