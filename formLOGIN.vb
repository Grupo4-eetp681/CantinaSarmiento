Public Class formLOGIN
    Dim logica As New LogicaCantina
    Private Sub BotonLogin_Click(sender As Object, e As EventArgs) Handles BotonLogin.Click
        Dim esvalido As Boolean = logica.ValidarLogin(TextBoxSubdivision.Text, TextBoxContra.Text)
        If esvalido Then
            Me.Close()
        Else
            MessageBox.Show("Credenciales incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class