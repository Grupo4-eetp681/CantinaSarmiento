Public Class formLOGIN
    Dim logica As New LogicaCantina
    Private Sub BotonLogin_Click(sender As Object, e As EventArgs) Handles BotonLogin.Click
        Dim resultado = logica.ValidarLogin(TextBoxSubdivision.Text, TextBoxContra.Text)
        If resultado.Exito Then
            Me.Close()
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
End Class