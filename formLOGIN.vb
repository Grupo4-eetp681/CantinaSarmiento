Public Class formLOGIN
    Dim logica As New LogicaCantina
    ' Método para abrir el formulario ventas dentro del panel
    Public Sub AbrirVentasEnPanel()
        Form1.ContenidoGeneral.Controls.Clear() ' Limpia el panel
        Dim frmVentas As New ventas()
        frmVentas.TopLevel = False
        frmVentas.FormBorderStyle = FormBorderStyle.None
        frmVentas.Dock = DockStyle.Fill
        Form1.ContenidoGeneral.Controls.Add(frmVentas)
        frmVentas.Show()
    End Sub

    Private Sub BotonLogin_Click(sender As Object, e As EventArgs) Handles BotonLogin.Click
        Dim resultado = logica.ValidarLogin(TextBoxSubdivision.Text.ToLower(), TextBoxContra.Text)
        If resultado.Exito Then
            AbrirVentasEnPanel()
            Me.Dispose()
        ElseIf resultado.Motivo = "Los datos no coinciden con los registros" Then
            info.Text = "Los datos no coinciden con los registros"
            PanelInfo.Visible = True
            info.Visible = True
            Timer1.Start()
        End If
    End Sub

    Private Sub formLOGIN_Load(sender As Object, e As EventArgs) Handles Me.Load

        PanelInfo.Visible = False
        info.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        info.Visible = False
        PanelInfo.Visible = False
        Timer1.Stop()
    End Sub

    Private Sub LogoSarmientoLogin_Click(sender As Object, e As EventArgs) Handles LogoSarmientoLogin.Click
        Me.Dispose()
    End Sub

    Private Sub BotonRegister_Click(sender As Object, e As EventArgs) Handles BotonRegister.Click
        FormularioRegister.ShowDialog()
    End Sub

    Private Sub formLOGIN_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TextBoxSubdivision.Focus()
    End Sub
End Class