Imports System.Runtime.InteropServices

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

    Private Sub PanelBarraSuperior_LocationChanged(sender As Object, e As EventArgs) Handles PanelBarraSuperior.LocationChanged

    End Sub

    Private Sub TimerHORA_Tick(sender As Object, e As EventArgs) Handles TimerHORA.Tick
        LabelHORA.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
    End Sub
End Class
