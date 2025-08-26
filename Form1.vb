Imports System.Runtime.InteropServices
Imports System.Security.Policy
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Public subdivision As String = String.Empty
    Public desplegado As Boolean = False

    Private dragging As Boolean = False
    Private dragOffset As Point

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
            dragging = True
            dragOffset = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Evitar que el usuario pueda usar el tab en los botones de cierre y minimizar'
        ButtonCierreApp.TabStop = False
        ButtonMinimizarApp.TabStop = False
        Dim altura As Int128 = FondoDeColor.AccessibilityObject.Bounds.Height
        Dim anchura As Int128 = FondoDeColor.AccessibilityObject.Bounds.Width
        ContenidoGeneral.Size = New Size(anchura - 6, altura - 6)
        ContenidoGeneral.Location = New Point(3, 3)
        formLOGIN.ShowDialog()
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

    Private Sub BotonMenu_Click(sender As Object, e As EventArgs) Handles BotonMenu.Click
        If desplegado = False Then
            PanelBotonesAcciones.Visible = True
            Dim rutaImagen As String = System.IO.Path.Combine(Application.StartupPath, "..\..\..\imagenes\flechahorizontal.png")
            BotonMenu.BackgroundImage = Image.FromFile(rutaImagen)
            BotonMenu.BackgroundImageLayout = ImageLayout.Stretch
            desplegado = True
        Else
            PanelBotonesAcciones.Visible = False
            Dim rutaImagen As String = System.IO.Path.Combine(Application.StartupPath, "..\..\..\imagenes\flechavertical.png")
            BotonMenu.BackgroundImage = Image.FromFile(rutaImagen)
            BotonMenu.BackgroundImageLayout = ImageLayout.Stretch
            desplegado = False
        End If
    End Sub

    Private Sub ButtonMaximizarApp_Click(sender As Object, e As EventArgs) Handles ButtonMaximizarApp.Click
        If WindowState = FormWindowState.Normal Then
            WindowState = FormWindowState.Maximized
        Else
            WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub PanelBarraSuperior_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelBarraSuperior.MouseMove
        If dragging Then
            Dim screenPos As Point = PanelBarraSuperior.PointToScreen(e.Location)
            Me.Location = New Point(screenPos.X - dragOffset.X, screenPos.Y - dragOffset.Y)

            ' Si el mouse está en la parte superior de la pantalla, maximiza
            If screenPos.Y <= 0 Then
                Me.WindowState = FormWindowState.Maximized
                dragging = False
            End If
        End If
    End Sub

    Private Sub PanelBarraSuperior_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelBarraSuperior.MouseUp
        dragging = False
    End Sub

End Class
