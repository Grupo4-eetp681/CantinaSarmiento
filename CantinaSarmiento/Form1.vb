Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    ' Esta función le dice a Windows que libere el control del mouse
    <DllImport("user32.dll", EntryPoint:="ReleaseCapture")>
    Private Shared Sub LiberarCapturaMouse()
    End Sub

    ' Esta función le envía un mensaje a la ventana para simular que se hizo clic en la barra de título
    <DllImport("user32.dll", EntryPoint:="SendMessage")>
    Private Shared Function EnviarMensajeVentana(hWnd As IntPtr, mensaje As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    ' Constantes para mover la ventana
    Private Const MENSAJE_CLICK_NO_CLIENTE As Integer = &HA1
    Private Const IDENTIFICADOR_BARRA_TITULO As Integer = &H2

    ' Evento del panel que permite mover el formulario al hacer clic y arrastrar
    Private Sub PanelBarraSuperior_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelBarraSuperior.MouseDown
        If e.Button = MouseButtons.Left Then
            LiberarCapturaMouse()
            EnviarMensajeVentana(Me.Handle, MENSAJE_CLICK_NO_CLIENTE, IDENTIFICADOR_BARRA_TITULO, 0)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Evitar que el usuario pueda usar el tab en los botones de cierre y minimizar'
        ButtonCierreApp.TabStop = False
        ButtonMinimizarApp.TabStop = False
    End Sub

    Private Sub ButtonCierreApp_Click(sender As Object, e As EventArgs) Handles ButtonCierreApp.Click
        'Cerrar aplicacion'
        Dispose()
    End Sub

    Private Sub ButtonMinimizarApp_Click(sender As Object, e As EventArgs) Handles ButtonMinimizarApp.Click
        'Minimizar la ventana'
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub TimerHORA_Tick(sender As Object, e As EventArgs) Handles TimerHORA.Tick
        'Cambiar la hora del label'
        LabelHORA.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
    End Sub
    Public Function ObtenerValorNumerico(textoFormateado As String) As Integer
        Dim limpio = textoFormateado.Replace("$", "").Replace(".", "").Trim()
        If IsNumeric(limpio) Then
            Return CInt(limpio)
        Else
            Return 0 ' o lanzar un error si preferís
        End If
    End Function

    Private Sub TextPago_TextChanged(sender As Object, e As EventArgs) Handles TextPago.TextChanged
        'Funcion para aplicar formato de $ x.xxx.xxx'
        Dim textoSinSimbolo As String = TextPago.Text.Replace("$", "").Replace(".", "").Trim()

        If IsNumeric(textoSinSimbolo) Then
            Dim valor As Decimal = Decimal.Parse(textoSinSimbolo)
            TextPago.Text = "$ " & Format(valor, "#,##0")
            TextPago.SelectionStart = TextPago.Text.Length ' Mueve el cursor al final
        ElseIf TextPago.Text.Length <= 2 Then
            TextPago.Text = "$ "
            TextPago.SelectionStart = TextPago.Text.Length
        End If
    End Sub

    Private Sub TextPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextPago.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextPago_KeyDown(sender As Object, e As KeyEventArgs) Handles TextPago.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' Evita que suene el 'beep' o se pase al siguiente control
            ' Si se presiona Enter, se agrega la lógica para procesar el pago
            Dim valor As Integer = ObtenerValorNumerico(TextPago.Text)
            LabelVuelto.Text = "Vuelto: $ " & Format(valor - 1000, "#,##0")
        End If
    End Sub
End Class
