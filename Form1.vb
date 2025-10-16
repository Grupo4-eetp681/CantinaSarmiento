Imports System.Runtime.InteropServices

Public Class Form1
    Public botonRegistro As Boolean = False
    Public subdivision As String = String.Empty
    Public desplegado As Boolean = False
    Private formularioActual As Form = Nothing
    Private logica As New LogicaCantina
    Private dragging As Boolean = False
    Private dragOffset As Point
    Public inicio As Int128
    Public OTP As Boolean = False
    Private estaMaximizado As Boolean = True

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
            If Me.Bounds = Screen.PrimaryScreen.WorkingArea Then
                ' Obtener posición actual del mouse en pantalla
                Dim mousePos As Point = Cursor.Position

                ' Restaurar tamaño normal
                RestaurarPersonalizado()

                ' Reposicionar ventana centrando el cursor en la parte superior del formulario restaurado
                Me.Location = New Point(mousePos.X - (Me.Width \ 2), mousePos.Y - 10)
            End If

            ' Ahora sí, permitir mover
            LiberarCapturaMouse()
            EnviarMensajeVentana(Me.Handle, MENSAJE_CLICK_NO_CLIENTE, IDENTIFICADOR_BARRA_TITULO, 0)
        End If
    End Sub


    Private Sub MaximizarPersonalizado()
        If Not estaMaximizado Then
            Dim pantallaActual As Screen = Screen.FromControl(Me)
            Me.Bounds = pantallaActual.WorkingArea
            estaMaximizado = True
        End If
    End Sub

    Private Sub RestaurarPersonalizado()
        If estaMaximizado Then
            Me.Size = New Size(1280, 720) ' el tamaño que quieras por defecto
            Me.CenterToScreen()
            estaMaximizado = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim areaTrabajo As Rectangle = Screen.PrimaryScreen.WorkingArea
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Bounds = areaTrabajo
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
            If logica.verificarCaja() Then
                SolicitudCaja.ShowDialog()
            End If
        Else
            formLOGIN.ShowDialog()
        End If
        logica.cargarSubdivision(subdivision)
        logica.verificarBaseDeDatos()
    End Sub

    Private Sub ButtonCierreApp_Click(sender As Object, e As EventArgs) Handles ButtonCierreApp.Click
        'Cerrar aplicacion'
        Dispose()
    End Sub

    Private Sub ButtonMinimizarApp_Click(sender As Object, e As EventArgs) Handles ButtonMinimizarApp.Click
        'Minimizar la ventana'
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Public Function ObtenerValorNumerico(textoFormateado As String) As Integer
        Dim limpio = textoFormateado.Replace("$", "").Replace(".", "").Trim()
        If IsNumeric(limpio) Then
            Return CInt(limpio)
        Else
            Return 0
        End If
    End Function

    Private Sub BotonMenubajo_Click(sender As Object, e As EventArgs) Handles BotonMenuAbajo.Click
        PanelBotonesAcciones.Visible = True
        desplegado = True
        ButtonMenuDerecha.Visible = True
    End Sub
    Private Sub ButtonMenuDerecha_Click(sender As Object, e As EventArgs) Handles ButtonMenuDerecha.Click
        PanelBotonesAcciones.Visible = False
        desplegado = False
        ButtonMenuDerecha.Visible = False
    End Sub

    Private Sub ButtonMaximizarApp_Click(sender As Object, e As EventArgs) Handles ButtonMaximizarApp.Click
        If Not estaMaximizado Then
            MaximizarPersonalizado()
        Else
            RestaurarPersonalizado()
        End If
    End Sub

    Private Sub PanelBarraSuperior_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelBarraSuperior.MouseMove
        ' Si quieres maximizar al llegar arriba, puedes hacerlo así:
        Dim screenPos As Point = PanelBarraSuperior.PointToScreen(e.Location)
        If screenPos.Y <= 0 And Not estaMaximizado Then
            MaximizarPersonalizado()
        End If
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

    Private Sub LogoSuperiorIzquierda_MouseDown(sender As Object, e As MouseEventArgs) Handles LogoSuperiorIzquierda.MouseDown
        If e.Button = MouseButtons.Right Then
            Opciones.Show(LogoSuperiorIzquierda, e.Location)
        End If
    End Sub

    Private Sub ActivarAdvertenciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivarAdvertenciasToolStripMenuItem.Click
        logica.advertenciasFalse()
    End Sub

    Private Sub BotonExportar_Click(sender As Object, e As EventArgs) Handles BotonExportar.Click
        logica.ExportarProductos()
    End Sub

    Private Sub BotonImportar_Click(sender As Object, e As EventArgs) Handles BotonImportar.Click
        logica.OrigenTienePrioridad = OTP
        logica.ImportarProductos()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        MaximizarPersonalizado()
    End Sub

    Private Sub CambiarInicioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarInicioToolStripMenuItem.Click
        SolicitudCaja.ShowDialog()
    End Sub

    Private Sub HabilitarDeshabilitarRegistroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HabilitarDeshabilitarRegistroToolStripMenuItem.Click
        If botonRegistro Then
            botonRegistro = False
        Else
            botonRegistro = True
        End If
    End Sub
End Class
