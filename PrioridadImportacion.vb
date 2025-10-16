Public Class PrioridadImportacion

    Dim logica As New LogicaCantina

    Private Sub ButtonOrigen_Click(sender As Object, e As EventArgs) Handles ButtonOrigen.Click
        Form1.OTP = True
        Me.Close()
    End Sub

    Private Sub ButtonDestino_Click(sender As Object, e As EventArgs) Handles ButtonDestino.Click
        Form1.OTP = False
        Me.Close()
    End Sub

    Private Sub PrioridadImportacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        logica.cargarSubdivision(Form1.subdivision)
    End Sub
End Class