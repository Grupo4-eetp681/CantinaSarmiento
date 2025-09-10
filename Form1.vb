Imports System.Runtime.InteropServices
Imports System.Security.Policy
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Public subdivision As String = String.Empty
    Public desplegado As Boolean = False
    Private formularioActual As Form = Nothing
    Private logica As New LogicaCantina
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
            ' Ya no necesitas activar dragging ni dragOffset
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
        Dim resultado = logica.verificarSesion()
        If resultado Then
            formLOGIN.AbrirVentasEnPanel()
            formularioActual = ventas
        Else
            formLOGIN.ShowDialog()
        End If
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
        ' Si quieres maximizar al llegar arriba, puedes hacerlo así:
        Dim screenPos As Point = PanelBarraSuperior.PointToScreen(e.Location)
        If screenPos.Y <= 0 And Me.WindowState <> FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub PanelBarraSuperior_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelBarraSuperior.MouseUp
        ' Ya no necesitas nada aquí
    End Sub

    Private Sub CerrarSesion_Click(sender As Object, e As EventArgs) Handles CerrarSesion.Click
        logica.cerrarSesion()
        Dispose()
    End Sub

    Public Sub AbrirFormularioEnPanel(f As Form)
        If formularioActual IsNot Nothing Then
            ' Si el formulario es del mismo tipo, no hacer nada
            If formularioActual.GetType() Is f.GetType() Then
                Return
            End If
            ' Cierra el formulario anterior
            formularioActual.Dispose()
        End If

        ContenidoGeneral.Controls.Clear()
        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill
        ContenidoGeneral.Controls.Add(f)
        f.Show()
        formularioActual = f
    End Sub

    Private Sub botonVentas_Click(sender As Object, e As EventArgs) Handles botonVentas.Click
        AbrirFormularioEnPanel(New ventas())
    End Sub

    Private Sub botonCaja_Click(sender As Object, e As EventArgs) Handles botonCaja.Click
        AbrirFormularioEnPanel(New CAJA())
    End Sub

    Private Sub botonInventario_Click(sender As Object, e As EventArgs) Handles botonInventario.Click
        AbrirFormularioEnPanel(New formINVENTARIO())
    End Sub
End Class
