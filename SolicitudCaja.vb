Public Class SolicitudCaja
    ' variables globales
    Dim logica As New LogicaCantina
    Private Sub TextBoxPlata_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxPlata.KeyPress
        ' Solo permitir números y control (backspace, etc.)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True ' rechazar el carácter
        End If

        ' No permitir borrar el símbolo "$"
        If TextBoxPlata.SelectionStart <= 1 AndAlso e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True ' rechazar el carácter
        End If
    End Sub
    Private Sub TextBoxPlata_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPlata.TextChanged
        ' Evita bucles infinitos
        If TextBoxPlata.Text = "$ " Then Exit Sub

        ' Quitar todo lo que no sea número
        Dim textoLimpio As String = New String(TextBoxPlata.Text.Where(Function(c) Char.IsDigit(c)).ToArray())

        ' Si está vacío, dejar solo el $`
        If String.IsNullOrEmpty(textoLimpio) Then
            TextBoxPlata.Text = "$ " ' establecer texto predeterminado
            TextBoxPlata.SelectionStart = TextBoxPlata.Text.Length ' Mover el cursor al final
            Exit Sub
        End If

        ' Formatear con separadores de miles
        Dim valorNumerico As Long = Long.Parse(textoLimpio)
        Dim textoFormateado As String = "$ " & valorNumerico.ToString("N0", New Globalization.CultureInfo("es-AR")) ' Formato con puntos como separadores de miles

        ' Reasignar el texto formateado
        TextBoxPlata.Text = textoFormateado

        ' Mover el cursor al final
        TextBoxPlata.SelectionStart = TextBoxPlata.Text.Length ' Mover el cursor al final
    End Sub

    Private Sub FormSolicitudCaja_Load(sender As Object, e As EventArgs) Handles Me.Load
        logica.cargarSubdivision(Form1.subdivision) ' cargar la subdivisión actual
        TextBoxPlata.Focus() ' establecer el foco en el textbox de plata
    End Sub

    Private Sub confirmarInicio()
        Dim origen As String = "Ingreso" ' origen para la advertencia
        Dim textoLimpio As String = TextBoxPlata.Text.Replace("$", "").Replace(" ", "").Replace(".", "") ' limpiar el texto
        Dim monto As Long = 0 ' variable para el monto
        If Not Long.TryParse(textoLimpio, monto) OrElse monto <= 0 Then
            Dim mensajeError As String = "Ingrese un monto válido mayor a cero." ' mensaje de error
            Dim frmError As New Advertencia(mensajeError, "ValidacionInicio") ' crear formulario de advertencia
            frmError.ShowDialog() ' mostrar el formulario de advertencia
            TextBoxPlata.Focus() ' establecer el foco en el textbox de plata
            Return
        End If

        Dim mensaje As String = "¿Confirmar $: " + monto.ToString("N0", New Globalization.CultureInfo("es-AR")) + " de inicio?" ' mensaje de confirmación
        If Not logica.ObtenerEstadoAdvertencia(origen) Then 
            Dim frm As New Advertencia(mensaje, origen) ' crear formulario de advertencia
            If frm.ShowDialog() = DialogResult.OK AndAlso frm.NoMostrarMas Then
                logica.GuardarEstadoAdvertencia(origen, True) ' guardar estado de advertencia
            End If
        End If
        logica.ActualizarInicio(monto) ' actualizar el inicio de caja
        Me.Dispose()
    End Sub

    Private Sub TextBoxPlata_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxPlata.KeyDown
        If e.KeyCode = Keys.Enter Then
            confirmarInicio() ' confirmar el inicio
        End If
    End Sub

    Private Sub ButtonAceptar_Click(sender As Object, e As EventArgs) Handles ButtonAceptar.Click
        confirmarInicio() ' confirmar el inicio
    End Sub

    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click
        Me.Dispose() ' cerrar el formulario
    End Sub
End Class