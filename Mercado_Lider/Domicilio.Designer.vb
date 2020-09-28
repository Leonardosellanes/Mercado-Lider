<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Domicilio
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblNroCasa = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.lblCalle = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.lblEsq = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.lblNroApto = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.lblCiudad = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Green
        Me.Button1.Location = New System.Drawing.Point(180, 139)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "ACEPTAR"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(50, 139)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "CANCELAR"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'lblNroCasa
        '
        Me.lblNroCasa.AutoSize = True
        Me.lblNroCasa.Location = New System.Drawing.Point(12, 22)
        Me.lblNroCasa.Name = "lblNroCasa"
        Me.lblNroCasa.Size = New System.Drawing.Size(69, 13)
        Me.lblNroCasa.TabIndex = 2
        Me.lblNroCasa.Text = "Nro de Casa:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(82, 19)
        Me.TextBox1.MaxLength = 11
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(55, 20)
        Me.TextBox1.TabIndex = 3
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(188, 19)
        Me.TextBox2.MaxLength = 30
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(143, 20)
        Me.TextBox2.TabIndex = 5
        '
        'lblCalle
        '
        Me.lblCalle.AutoSize = True
        Me.lblCalle.Location = New System.Drawing.Point(149, 22)
        Me.lblCalle.Name = "lblCalle"
        Me.lblCalle.Size = New System.Drawing.Size(33, 13)
        Me.lblCalle.TabIndex = 4
        Me.lblCalle.Text = "Calle:"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(61, 58)
        Me.TextBox3.MaxLength = 30
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(143, 20)
        Me.TextBox3.TabIndex = 7
        '
        'lblEsq
        '
        Me.lblEsq.AutoSize = True
        Me.lblEsq.Location = New System.Drawing.Point(16, 61)
        Me.lblEsq.Name = "lblEsq"
        Me.lblEsq.Size = New System.Drawing.Size(28, 13)
        Me.lblEsq.TabIndex = 6
        Me.lblEsq.Text = "Esq:"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(276, 61)
        Me.TextBox4.MaxLength = 11
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(55, 20)
        Me.TextBox4.TabIndex = 9
        '
        'lblNroApto
        '
        Me.lblNroApto.AutoSize = True
        Me.lblNroApto.Location = New System.Drawing.Point(206, 64)
        Me.lblNroApto.Name = "lblNroApto"
        Me.lblNroApto.Size = New System.Drawing.Size(67, 13)
        Me.lblNroApto.TabIndex = 8
        Me.lblNroApto.Text = "Nro de Apto:"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(109, 98)
        Me.TextBox5.MaxLength = 30
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(143, 20)
        Me.TextBox5.TabIndex = 11
        '
        'lblCiudad
        '
        Me.lblCiudad.AutoSize = True
        Me.lblCiudad.Location = New System.Drawing.Point(64, 101)
        Me.lblCiudad.Name = "lblCiudad"
        Me.lblCiudad.Size = New System.Drawing.Size(43, 13)
        Me.lblCiudad.TabIndex = 10
        Me.lblCiudad.Text = "Ciudad:"
        '
        'Domicilio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 174)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.lblCiudad)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.lblNroApto)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.lblEsq)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.lblCalle)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblNroCasa)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(359, 213)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(359, 213)
        Me.Name = "Domicilio"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Domicilio"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents lblNroCasa As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents lblCalle As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents lblEsq As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents lblNroApto As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents lblCiudad As Label
End Class
