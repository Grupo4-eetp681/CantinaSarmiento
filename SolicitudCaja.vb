Public Class SolicitudCaja
    Dim logica As New LogicaCantina
    Private Sub TextBoxPlata_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxPlata.KeyPress
        ' Solo permitir números y control (backspace, etc.)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If

        ' No permitir borrar el símbolo "$"
        If TextBoxPlata.SelectionStart <= 1 AndAlso e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxPlata_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPlata.TextChanged
        ' Evita bucles infinitos
        If TextBoxPlata.Text = "$ " Then Exit Sub

        ' Quitar todo lo que no sea número
        Dim textoLimpio As String = New String(TextBoxPlata.Text.Where(Function(c) Char.IsDigit(c)).ToArray())

        ' Si está vacío, dejar solo el $`
        If String.IsNullOrEmpty(textoLimpio) Then
            TextBoxPlata.Text = "$ "
            TextBoxPlata.SelectionStart = TextBoxPlata.Text.Length
            Exit Sub
        End If

        ' Formatear con separadores de miles
        Dim valorNumerico As Long = Long.Parse(textoLimpio)
        Dim textoFormateado As String = "$ " & valorNumerico.ToString("N0", New Globalization.CultureInfo("es-AR"))

        ' Reasignar el texto formateado
        TextBoxPlata.Text = textoFormateado

        ' Mover el cursor al final
        TextBoxPlata.SelectionStart = TextBoxPlata.Text.Length
    End Sub

    Private Sub FormSolicitudCaja_Load(sender As Object, e As EventArgs) Handles Me.Load
        logica.cargarSubdivision(Form1.subdivision)
    End Sub

    Private Sub confirmarInicio()
        Dim origen As String = "Ingreso"
        Dim textoLimpio As String = TextBoxPlata.Text.Replace("$", "").Replace(" ", "").Replace(".", "")
        Dim monto As Long = 0
        If Not Long.TryParse(textoLimpio, monto) OrElse monto <= 0 Then
            Dim mensajeError As String = "Ingrese un monto válido mayor a cero."
            Dim frmError As New Advertencia(mensajeError, "ValidacionInicio")
            frmError.ShowDialog()
            TextBoxPlata.Focus()
            Return
        End If

        Dim mensaje As String = "¿Confirmar $: " + monto.ToString("N0", New Globalization.CultureInfo("es-AR")) + " de inicio?"
        If Not logica.ObtenerEstadoAdvertencia(origen) Then
            Dim frm As New Advertencia(mensaje, origen)
            If frm.ShowDialog() = DialogResult.OK AndAlso frm.NoMostrarMas Then
                logica.GuardarEstadoAdvertencia(origen, True)
            End If
        End If
        logica.ActualizarCaja("Inicio", monto)
        Me.Dispose()
    End Sub

    Private Sub TextBoxPlata_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxPlata.KeyDown
        If e.KeyCode = Keys.Enter Then
            confirmarInicio()
        End If
    End Sub

    Private Sub ButtonAceptar_Click(sender As Object, e As EventArgs) Handles ButtonAceptar.Click
        confirmarInicio()
    End Sub

    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click
        Me.Dispose()
    End Sub
End Class