Public Class Administrador
    Private Sub Administrador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OcultarBarras()
        pnlArticulos.Show()
    End Sub
    Private Sub OcultarBarras()
        pnlArticulos.Visible = False
        pnlUsuarios.Visible = False
        pnlTransacciones.Visible = False
    End Sub
    Private Sub btnArticulos_Click(sender As Object, e As EventArgs) Handles btnArticulos.Click
        tcAdmin.SelectedTab = tcAdmin.TabPages.Item(0)
        OcultarBarras()
        pnlArticulos.Visible = True
    End Sub
    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        tcAdmin.SelectedTab = tcAdmin.TabPages.Item(1)
        OcultarBarras()
        pnlUsuarios.Visible = True
    End Sub
    Private Sub btnTransacciones_Click(sender As Object, e As EventArgs) Handles btnTransacciones.Click
        tcAdmin.SelectedTab = tcAdmin.TabPages.Item(2)
        OcultarBarras()
        pnlTransacciones.Visible = True
    End Sub

    Private Sub Administrador_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmPrincipal.Show()
    End Sub
End Class