Public Class PrioridadImportacion
    ' variables globales
    Dim logica As New LogicaCantina

    Private Sub ButtonOrigen_Click(sender As Object, e As EventArgs) Handles ButtonOrigen.Click
        Form1.OTP = True ' establecer OTP como verdadero
        Me.Close() ' cerrar el formulario
    End Sub

    Private Sub ButtonDestino_Click(sender As Object, e As EventArgs) Handles ButtonDestino.Click
        Form1.OTP = False ' establecer OTP como falso
        Me.Close() ' cerrar el formulario
    End Sub

    Private Sub PrioridadImportacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        logica.cargarSubdivision(Form1.subdivision) ' cargar la subdivisión actual
    End Sub
End Class