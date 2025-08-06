Public Class ventas
    Dim logica As New LogicaCantina

    Private Sub Busqueda_TextChanged(sender As Object, e As EventArgs) Handles Busqueda.TextChanged
        If Busqueda.Text() = "" Then
            Dim tb = logica.ObtenerTodosLosProductos()
            DataGridView1.DataSource = tb
        Else
            Dim tb = logica.FiltrarProductosPorNombre(Busqueda.Text())
            DataGridView1.DataSource = tb
        End If

    End Sub

    Private Sub ventas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim tb = logica.ObtenerTodosLosProductos()
        DataGridView1.DataSource = tb

        PanelContenedorIZQ.Width = Form1.ContenidoGeneral.Width * 0.7

        With DataGridView1
            .Dock = DockStyle.Fill
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True

            ' Desactiva el resaltado de selección
            .DefaultCellStyle.SelectionBackColor = .DefaultCellStyle.BackColor
            .DefaultCellStyle.SelectionForeColor = .DefaultCellStyle.ForeColor

            ' Opcional: desactiva la edición de celdas (aunque .ReadOnly ya lo hace)
            .EditMode = DataGridViewEditMode.EditProgrammatically
        End With

        With DataGridVentas
            .Dock = DockStyle.Fill
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ReadOnly = True

            ' Desactiva el resaltado de selección
            .DefaultCellStyle.SelectionBackColor = .DefaultCellStyle.BackColor
            .DefaultCellStyle.SelectionForeColor = .DefaultCellStyle.ForeColor

            ' Opcional: desactiva la edición de celdas (aunque .ReadOnly ya lo hace)
            .EditMode = DataGridViewEditMode.EditProgrammatically
        End With

        TXTPago.Text = "$ "
    End Sub

    Private Sub acomodarPagoYVuelto()
        Dim anchoDisponible As Integer = PanelDerechaINFVueltoYPago.Width

        ' --- BLOQUE PAGO ---
        Dim anchoPago As Integer = (TXTPago.Location.X + TXTPago.Width) - LabelPago.Location.X
        Dim centroEspacioDisponible As Integer = anchoDisponible \ 2
        Dim nuevaXPago As Integer = centroEspacioDisponible - (anchoPago \ 2)
        LabelPago.Location = New Point(nuevaXPago, LabelPago.Location.Y)
        TXTPago.Location = New Point(LabelPago.Location.X + LabelPago.Width + 15, TXTPago.Location.Y)

        ' --- BLOQUE VUELTO ---
        Dim anchoVuelto As Integer = (LabelNUMVuelto.Location.X + LabelNUMVuelto.Width) - LabelVuelto.Location.X
        Dim nuevaXVuelto As Integer = centroEspacioDisponible - (anchoVuelto \ 2)
        LabelVuelto.Location = New Point(nuevaXVuelto, LabelVuelto.Location.Y)
        LabelNUMVuelto.Location = New Point(LabelVuelto.Location.X + LabelVuelto.Width + 15, LabelNUMVuelto.Location.Y)
    End Sub



    Private Sub ventas_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim altura As Integer = PanelContenedorVentas.Height
        Dim ancho As Integer = PanelContenedorVentas.Width

        PanelDataVentas.Height = altura * (2 / 3)
        PanelDataVentas.Width = ancho - 50
        PanelDataVentas.Location = New Point(25, 0)
        PanelDataVentas.BringToFront()

        PanelCentrarPago.Width = ancho - 50
        PanelCentrarVuelto.Width = ancho - 50
        PanelCentrarPago.Location = New Point(25, 0)
        PanelCentrarVuelto.Location = New Point(25, 0)

        TXTPago.Width = PanelDerechaINFVueltoYPago.Width * 0.3

        acomodarPagoYVuelto()

    End Sub

    Private Sub TXTPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPago.KeyPress
        ' Solo permitir números y control (backspace, etc.)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If

        ' No permitir borrar el símbolo "$"
        If TXTPago.SelectionStart <= 1 AndAlso e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TXTPago_TextChanged(sender As Object, e As EventArgs) Handles TXTPago.TextChanged
        ' Evita bucles infinitos
        If TXTPago.Text = "$ " Then Exit Sub

        ' Quitar todo lo que no sea número
        Dim textoLimpio As String = New String(TXTPago.Text.Where(Function(c) Char.IsDigit(c)).ToArray())

        ' Si está vacío, dejar solo el $
        If String.IsNullOrEmpty(textoLimpio) Then
            TXTPago.Text = "$ "
            TXTPago.SelectionStart = TXTPago.Text.Length
            Exit Sub
        End If

        ' Formatear con separadores de miles
        Dim valorNumerico As Long = Long.Parse(textoLimpio)
        Dim textoFormateado As String = "$ " & valorNumerico.ToString("N0", New Globalization.CultureInfo("es-AR"))

        ' Reasignar el texto formateado
        TXTPago.Text = textoFormateado

        ' Mover el cursor al final
        TXTPago.SelectionStart = TXTPago.Text.Length
    End Sub

    Private Sub TXTPago_Enter(sender As Object, e As EventArgs) Handles TXTPago.Enter

        If TXTPago.Text = "" Then
            TXTPago.Text = "$ "
            TXTPago.SelectionStart = TXTPago.Text.Length
        End If

    End Sub

    Private Sub TXTPago_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTPago.KeyDown
        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True

            'Obtener el pago'
            Dim textoLimpio As String = TXTPago.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim()
            Dim montoPago As Long = 0
            Long.TryParse(textoLimpio, montoPago)

            'Obtener el totl'
            Dim textoTotal As String = LabelTotal.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim()
            Dim montoTotal As Long = 0
            Long.TryParse(textoTotal, montoTotal)

            'Calcular el vuelto'
            Dim vuelto As Long = montoPago - montoTotal
            LabelNUMVuelto.Text = "$ " & vuelto.ToString("N0", New Globalization.CultureInfo("es-AR")).Replace(" ", "")
            TXTPago.Text = "$ "

            BotonRegistro.Focus()
        End If
    End Sub
End Class