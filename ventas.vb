Public Class ventas
    Dim logica As New LogicaCantina
    Dim calcularVuelto As Boolean = False
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
            .EnableHeadersVisualStyles = False
            .BackColor = Color.LightGray
            .ForeColor = Color.Black
            .CurrentCell = Nothing
            .DefaultCellStyle.SelectionBackColor = .DefaultCellStyle.BackColor
            .DefaultCellStyle.SelectionForeColor = .DefaultCellStyle.ForeColor
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

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
            .EnableHeadersVisualStyles = False
            .BackColor = Color.LightGray
            .ForeColor = Color.Black
            .CurrentCell = Nothing
            .DefaultCellStyle.SelectionBackColor = DataGridVentas.DefaultCellStyle.BackColor
            .DefaultCellStyle.SelectionForeColor = DataGridVentas.DefaultCellStyle.ForeColor
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Desactiva el resaltado de selección
            .DefaultCellStyle.SelectionBackColor = .DefaultCellStyle.BackColor
            .DefaultCellStyle.SelectionForeColor = .DefaultCellStyle.ForeColor

            .Columns.Clear()
            .Columns.Add("Descripcion", "Descripción")
            .Columns.Add("Cantidad", "Cantidad")
            .Columns.Add("Subtotal", "Subtotal")
            .AllowUserToAddRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .Columns("Descripcion").ReadOnly = True
            .Columns("Subtotal").ReadOnly = True


            ' Agregar columna botón solo si no existe aún
            If Not .Columns.Contains("Eliminar") Then
                Dim btnEliminar As New DataGridViewButtonColumn()
                With btnEliminar
                    .HeaderText = ""
                    .Name = "Eliminar"
                    .Text = "🗑️"
                    .UseColumnTextForButtonValue = True
                    .Width = 40
                    .FlatStyle = FlatStyle.Flat
                End With
                .Columns.Add(btnEliminar)
            End If

            .Columns("Eliminar").ReadOnly = True

        End With

        'Acomodar Botones'
        Dim anchoConjunto As Integer = PanelContenedorButtonVentas.Width
        Dim centroEspacioDisponible As Integer = PanelDerechaINFButton.Width / 2
        Dim nuevaX As Integer = centroEspacioDisponible - (anchoConjunto \ 2)
        PanelContenedorButtonVentas.Location = New Point(nuevaX, PanelContenedorButtonVentas.Location.Y)

        TXTPago.Text = "$ "
    End Sub

    Private Sub acomodarPagoYVuelto()
        Dim anchoDisponible As Integer = PanelDerechaINFVueltoYPago.Width

        ' --- BLOQUE PAGO ---
        Dim anchoConjunto As Integer = PanelCentrarPago.Width
        Dim centroEspacioDisponible As Integer = PanelDerechaINFVueltoYPago.Width / 2
        Dim nuevaX As Integer = centroEspacioDisponible - (anchoConjunto \ 2)
        PanelCentrarPago.Location = New Point(nuevaX, PanelContenedorButtonVentas.Location.Y)

        ' --- BLOQUE VUELTO ---
        PanelCentrarVuelto.Location = New Point(nuevaX, PanelCentrarVuelto.Location.Y)
    End Sub



    Private Sub ventas_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim altura As Integer = PanelContenedorVentas.Height
        Dim ancho As Integer = PanelContenedorVentas.Width

        PanelDataVentas.Height = altura * (2 / 3)
        PanelDataVentas.Width = ancho - 50
        PanelDataVentas.Location = New Point(25, 0)
        PanelDataVentas.BringToFront()

        TXTPago.Width = PanelDerechaINFVueltoYPago.Width * 0.3
        PanelCentrarPago.Width = (TXTPago.Location.X + TXTPago.Width)
        PanelCentrarVuelto.Width = PanelCentrarPago.Width

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
            If montoPago > 0 Then
                calcularVuelto = True
            Else
                calcularVuelto = False
            End If

            'Obtener el total'
            Dim textoTotal As String = LabelPrecioTotal.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim()
            Dim montoTotal As Long = 0
            Long.TryParse(textoTotal, montoTotal)

            'Calcular el vuelto'
            Dim vuelto As Long = montoPago - montoTotal
            LabelNUMVuelto.Text = "$ " & vuelto.ToString("N0", New Globalization.CultureInfo("es-AR")).Replace(" ", "")
            TXTPago.Text = "$ "

            acomodarPagoYVuelto()
            BotonRegistro.Focus()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim filaSeleccionada As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            Dim descripcion As String = filaSeleccionada.Cells("Descripción").Value.ToString()
            Dim precioUnitario As Long = Convert.ToInt64(filaSeleccionada.Cells("Precio_Unitario").Value)

            Dim encontrado As Boolean = False

            For Each filaVenta As DataGridViewRow In DataGridVentas.Rows
                If filaVenta.Cells("Descripcion").Value.ToString() = descripcion Then
                    ' Producto ya existe en la grilla de ventas
                    Dim cantidadActual As Integer = Convert.ToInt32(filaVenta.Cells("Cantidad").Value)
                    cantidadActual += 1
                    filaVenta.Cells("Cantidad").Value = cantidadActual
                    filaVenta.Cells("Subtotal").Value = cantidadActual * precioUnitario
                    encontrado = True
                    Exit For
                End If
            Next

            If Not encontrado Then
                ' Producto no está, lo agregamos nuevo
                DataGridVentas.Rows.Add(descripcion, 1, precioUnitario)

                Dim nuevaFilaIndex As Integer = DataGridVentas.Rows.Count - 1

                DataGridVentas.CurrentCell = DataGridVentas.Rows(nuevaFilaIndex).Cells("Cantidad")
                DataGridVentas.BeginEdit(True)
            End If
        End If

        ActualizarTotal()
    End Sub
    Private Sub DataGridVentas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridVentas.CellEndEdit
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridVentas.Columns("Cantidad").Index Then
            Dim fila As DataGridViewRow = DataGridVentas.Rows(e.RowIndex)

            Dim cantidad As Integer
            If Not Integer.TryParse(fila.Cells("Cantidad").Value.ToString(), cantidad) Then
                cantidad = 1 ' Por si ponen texto inválido
                fila.Cells("Cantidad").Value = cantidad
            End If

            'Si es 0, eliminamos la fila'
            If cantidad <= 0 Then
                DataGridVentas.Rows.Remove(fila)
                ActualizarTotal()
                Return
            End If

            ' Buscamos el precio original del producto
            Dim descripcion As String = fila.Cells("Descripcion").Value.ToString()

            ' Lo buscás en el DataGridView1 (productos) para obtener el precio
            For Each filaProducto As DataGridViewRow In DataGridView1.Rows
                If filaProducto.Cells("Descripción").Value.ToString() = descripcion Then
                    Dim precioUnitario As Long = Convert.ToInt64(filaProducto.Cells("Precio_Unitario").Value)
                    fila.Cells("Subtotal").Value = cantidad * precioUnitario
                    Exit For
                End If
            Next
        End If
        ActualizarTotal()
    End Sub
    Private Sub ActualizarTotal()

        'Obtener el vuelto'
        Dim textoLimpio As String = LabelNUMVuelto.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim()
        Dim montoPago As Long = 0
        Long.TryParse(textoLimpio, montoPago)

        'Obtener el total'
        Dim textoTotal As String = LabelPrecioTotal.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim()
        Dim montoTotal As Long = 0
        Long.TryParse(textoTotal, montoTotal)

        'Calcular el pago'
        Dim pago As Long = montoPago + montoTotal

        Dim anchoAntes As Integer = LabelPrecioTotal.Width
        Dim posicionAntes As Integer = LabelPrecioTotal.Location.X

        Dim total As Long = 0

        For Each fila As DataGridViewRow In DataGridVentas.Rows
            If fila.Cells("Subtotal").Value IsNot Nothing Then
                total += Convert.ToInt64(fila.Cells("Subtotal").Value)
            End If
        Next

        LabelPrecioTotal.Text = "$ " & total.ToString("N0", New Globalization.CultureInfo("es-AR")).Replace(" ", "")

        Dim anchoDespues As Integer = LabelPrecioTotal.Width
        Dim posicionDespues As Integer = posicionAntes - (anchoDespues - anchoAntes)
        LabelPrecioTotal.Location = New Point(posicionDespues, LabelPrecioTotal.Location.Y)

        If calcularVuelto Then
            'Calcular el vuelto'
            Dim vuelto As Long = pago - total
            LabelNUMVuelto.Text = "$ " & vuelto.ToString("N0", New Globalization.CultureInfo("es-AR")).Replace(" ", "")
            TXTPago.Text = "$ "

            acomodarPagoYVuelto()
        End If

    End Sub




    Private Sub EliminarProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarProductoToolStripMenuItem.Click
        If DataGridVentas.SelectedRows.Count > 0 Then
            DataGridVentas.Rows.Remove(DataGridVentas.SelectedRows(0))
            ActualizarTotal() ' Si tenés un método para recalcular el total
        End If
    End Sub

    Private Sub DataGridVentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridVentas.CellDoubleClick
        If e.RowIndex >= 0 Then
            DataGridVentas.ClearSelection()
            DataGridVentas.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Private Sub DataGridVentas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridVentas.CellContentClick
        If e.RowIndex >= 0 AndAlso DataGridVentas.Columns(e.ColumnIndex).Name = "Eliminar" Then
            DataGridVentas.Rows.RemoveAt(e.RowIndex)
            ActualizarTotal()
        End If
    End Sub

    Private Sub BotonRegistro_Click(sender As Object, e As EventArgs) Handles BotonRegistro.Click
        calcularVuelto = False
    End Sub

    Private Sub BotonFactura_Click(sender As Object, e As EventArgs) Handles BotonFactura.Click
        calcularVuelto = False
    End Sub

    Private Sub BotonTicket_Click(sender As Object, e As EventArgs) Handles BotonTicket.Click
        calcularVuelto = False
    End Sub
End Class