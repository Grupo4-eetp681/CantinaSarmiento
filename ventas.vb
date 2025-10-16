Imports System.Drawing.Printing

Public Class ventas
    Dim logica As New LogicaCantina
    Dim calcularVuelto As Boolean = False

    Private Sub responsive()
        PanelContenedorIZQ.Width = Form1.ContenidoGeneral.Width * 0.7

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

        'Acomodar Botones'
        Dim anchoConjunto As Integer = PanelContenedorButtonVentas.Width
        Dim centroEspacioDisponible As Integer = PanelDerechaINFButton.Width / 2
        Dim nuevaX As Integer = centroEspacioDisponible - (anchoConjunto \ 2)
        PanelContenedorButtonVentas.Location = New Point(nuevaX, PanelContenedorButtonVentas.Location.Y)

        TXTPago.Text = "$ "

        AjustarFuenteLabelMaximo(LabelPago, "PAGO:")
        AjustarFuenteLabelMaximo(LabelVuelto, "VUELTO:")

        DataGridView1.RowTemplate.Height = 40
        DataGridVentas.RowTemplate.Height = 30

    End Sub

    Private Sub AjustarFuenteEncabezado(dgv As DataGridView)
        Dim anchoTotal As Integer = dgv.Width

        ' Tamaños base
        Dim tamañoMin As Single = 8
        Dim tamañoMax As Single = 16

        ' Escalado lineal entre 400 y 1000 px de ancho
        Dim factor As Single = Math.Min(1.0F, Math.Max(0.0F, (anchoTotal - 200) / 350.0F))
        Dim nuevoTamaño As Single = tamañoMin + (tamañoMax - tamañoMin) * factor

        ' Aplicar estilos
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Candara", nuevoTamaño, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
    End Sub


    Private Sub DataGridView1_Resize(sender As Object, e As EventArgs) Handles DataGridView1.Resize
        AjustarFuenteEncabezado(DataGridView1)
    End Sub
    Private Sub DataGridVentas_Resize(sender As Object, e As EventArgs) Handles DataGridVentas.Resize
        AjustarFuenteEncabezado(DataGridVentas)
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If DataGridView1.CurrentRow IsNot Nothing Then
                AgregarProductoDesdeFila(DataGridView1.CurrentRow)
                Busqueda.Clear()
                Busqueda.Focus()
            End If
        End If
    End Sub
    Private Sub AgregarProductoDesdeFila(fila As DataGridViewRow)
        Dim descripcion As String = fila.Cells("Descripción").Value.ToString()
        Dim precio As Decimal = Convert.ToDecimal(fila.Cells("Precio_Unitario").Value)

        If logica.verificarCaja Then
            SolicitudCaja.ShowDialog()
            Return
        Else
            Dim encontrado = False
            For Each filaVenta As DataGridViewRow In DataGridVentas.Rows
                    If filaVenta.Cells("Descripcion").Value.ToString = descripcion Then
                        ' Producto ya existe en la grilla de ventas
                        Dim cantidadActual = Convert.ToInt32(filaVenta.Cells("Cantidad").Value)
                        cantidadActual += 1
                        filaVenta.Cells("Cantidad").Value = cantidadActual
                    filaVenta.Cells("Subtotal").Value = cantidadActual * precio
                    encontrado = True
                        Exit For
                    End If
                Next

            If Not encontrado Then
                DataGridVentas.Rows.Add(descripcion, 1, precio)

                Dim nuevaFilaIndex = DataGridVentas.Rows.Count - 1

                DataGridVentas.CurrentCell = DataGridVentas.Rows(nuevaFilaIndex).Cells("Cantidad")
                DataGridVentas.BeginEdit(True)
            End If
        End If

        ActualizarTotal()
    End Sub

    Private Sub Busqueda_TextChanged(sender As Object, e As EventArgs) Handles Busqueda.TextChanged
        If Busqueda.Text() = "" Then
            Dim tb = logica.ObtenerTodosLosProductos()
            DataGridView1.DataSource = tb
        Else
            Dim tb = logica.FiltrarProductosPorNombre(Busqueda.Text())
            DataGridView1.DataSource = tb
        End If
    End Sub

    Private Sub Busqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles Busqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True  ' evita beep

            If DataGridView1.Rows.Count = 1 Then
                AgregarProductoDesdeFila(DataGridView1.Rows(0))
                Busqueda.Clear()
            ElseIf DataGridView1.Rows.Count > 1 Then
                DataGridView1.Focus()
                If DataGridView1.Rows.Count > 0 Then
                    DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(0)
                End If
            End If
        End If
        Busqueda.Focus()
    End Sub

    Private Sub ventas_Load(sender As Object, e As EventArgs) Handles Me.Load

        logica.cargarSubdivision(Form1.subdivision)
        Dim tb = logica.ObtenerTodosLosProductos()
        DataGridView1.DataSource = tb

        PanelContenedorIZQ.Width = Form1.ContenidoGeneral.Width * 0.7

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
            .Font = New Font("Candara", 10)
            .ColumnHeadersDefaultCellStyle = DataGridView1.ColumnHeadersDefaultCellStyle

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

        AjustarFuenteLabelMaximo(LabelPago, "PAGO:")
        AjustarFuenteLabelMaximo(LabelVuelto, "VUELTO:")
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

        ' Si está vacío, dejar solo el $`
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

        If logica.verificarCaja Then
            SolicitudCaja.ShowDialog()
            Return
        Else
            If e.RowIndex >= 0 Then
                Dim filaSeleccionada = DataGridView1.Rows(e.RowIndex)

                Dim descripcion = filaSeleccionada.Cells("Descripción").Value.ToString
                Dim precioUnitario = Convert.ToInt64(filaSeleccionada.Cells("Precio").Value)

                Dim encontrado = False

                For Each filaVenta As DataGridViewRow In DataGridVentas.Rows
                    If filaVenta.Cells("Descripcion").Value.ToString = descripcion Then
                        ' Producto ya existe en la grilla de ventas
                        Dim cantidadActual = Convert.ToInt32(filaVenta.Cells("Cantidad").Value)
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

                    Dim nuevaFilaIndex = DataGridVentas.Rows.Count - 1

                    DataGridVentas.CurrentCell = DataGridVentas.Rows(nuevaFilaIndex).Cells("Cantidad")
                    DataGridVentas.BeginEdit(True)
                End If
            End If

            ActualizarTotal()
        End If

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
                    Dim precioUnitario As Long = Convert.ToInt64(filaProducto.Cells("Precio").Value)
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
            Dim texto As String = "$ " & vuelto.ToString("N0", New Globalization.CultureInfo("es-AR")).Replace(" ", "")
            AjustarFuenteLabelMaximo(LabelNUMVuelto, texto)
            TXTPago.Text = "$ "

            acomodarPagoYVuelto()
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

    Private Sub mostrar_mensaje()
        PanelLabel.Visible = True
        LabelMensage.Visible = True
        BotonFactura.Enabled = False
        BotonRegistro.Enabled = False
        BotonTicket.Enabled = False
        TimerMensage.Start()
    End Sub

    Private Sub AjustarFuenteLabelMaximo(label As Label, texto As String)
        Dim anchoMaximo As Integer = label.Width
        Dim altoMaximo As Integer = label.Height
        Dim fuenteBase As Font = label.Font
        Dim tamañoFuente As Single = fuenteBase.Size

        ' Prueba desde un tamaño grande hacia abajo
        For size As Single = 48 To 8 Step -1
            Using fuentePrueba As New Font(fuenteBase.FontFamily, size, fuenteBase.Style)
                Dim tamañoTexto As Size = TextRenderer.MeasureText(texto, fuentePrueba, New Size(anchoMaximo, altoMaximo), TextFormatFlags.WordBreak)
                If tamañoTexto.Width <= anchoMaximo AndAlso tamañoTexto.Height <= altoMaximo Then
                    tamañoFuente = size
                    Exit For
                End If
            End Using
        Next

        label.Font = New Font(fuenteBase.FontFamily, tamañoFuente, fuenteBase.Style)
        label.Text = texto
        label.TextAlign = ContentAlignment.MiddleCenter
    End Sub

    Private Sub BotonRegistro_Click(sender As Object, e As EventArgs) Handles BotonRegistro.Click

        If Form1.botonRegistro = False Then
            Exit Sub
        End If

        calcularVuelto = False
        If DataGridVentas.Rows.Count = 0 Then
            AjustarFuenteLabelMaximo(LabelMensage, "Lista de venta vacía")
            mostrar_mensaje()
            Return
        End If

        Dim origen = "BotonRegistro"
        Dim mensaje = "¿Confirmar registro de venta?"
        Dim continuar As Boolean = True

        If Not logica.ObtenerEstadoAdvertencia(origen) Then
            Dim frm As New Advertencia(mensaje, origen)
            Dim resultado = frm.ShowDialog()
            If resultado = DialogResult.OK Then
                If frm.NoMostrarMas Then
                    logica.GuardarEstadoAdvertencia(origen, True)
                End If
                continuar = True
            Else
                continuar = False
            End If
        End If

        If continuar Then
            Dim total As Int128 = Int128.Parse(LabelPrecioTotal.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim())
            If CheckBoxTransferencia.CheckState Then
                logica.ActualizarCaja("VentasTransferencias", total)
            Else
                logica.ActualizarCaja("VentasEfectivo", total)
            End If
            AjustarFuenteLabelMaximo(LabelMensage, "Venta guardada")
            mostrar_mensaje()
            registrar_venta()
        End If
    End Sub

    Private Sub BotonFactura_Click(sender As Object, e As EventArgs) Handles BotonFactura.Click
        calcularVuelto = False
        If DataGridVentas.Rows.Count = 0 Then
            AjustarFuenteLabelMaximo(LabelMensage, "Lista de venta vacía")
            mostrar_mensaje()
            Return
        End If

        Dim origen = "BotonFactura"
        Dim mensaje = "¿Confirmar registro de venta?"
        Dim continuar As Boolean = True

        If Not logica.ObtenerEstadoAdvertencia(origen) Then
            Dim frm As New Advertencia(mensaje, origen)
            Dim resultado = frm.ShowDialog()
            If resultado = DialogResult.OK Then
                If frm.NoMostrarMas Then
                    logica.GuardarEstadoAdvertencia(origen, True)
                End If
                continuar = True
            Else
                continuar = False
            End If
        End If

        If continuar Then
            Dim total As Int128 = Int128.Parse(LabelPrecioTotal.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim())
            If CheckBoxTransferencia.CheckState Then
                logica.ActualizarCaja("VentasTransferencias", total)
            Else
                logica.ActualizarCaja("VentasEfectivo", total)
            End If
            AjustarFuenteLabelMaximo(LabelMensage, "Venta guardada")
            mostrar_mensaje()
            EmitirFacturaTipoC()
            registrar_venta()
        End If
    End Sub

    Private Sub BotonTicket_Click(sender As Object, e As EventArgs) Handles BotonTicket.Click
        calcularVuelto = False
        If DataGridVentas.Rows.Count = 0 Then
            AjustarFuenteLabelMaximo(LabelMensage, "Lista de venta vacía")
            mostrar_mensaje()
            Return
        End If

        Dim origen = "BotonTicket"
        Dim mensaje = "¿Confirmar registro de venta?"
        Dim continuar As Boolean = True

        If Not logica.ObtenerEstadoAdvertencia(origen) Then
            Dim frm As New Advertencia(mensaje, origen)
            Dim resultado = frm.ShowDialog()
            If resultado = DialogResult.OK Then
                If frm.NoMostrarMas Then
                    logica.GuardarEstadoAdvertencia(origen, True)
                End If
                continuar = True
            Else
                continuar = False
            End If
        End If

        If continuar Then
            Dim total As Int128 = Int128.Parse(LabelPrecioTotal.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim())
            If CheckBoxTransferencia.CheckState Then
                logica.ActualizarCaja("VentasTransferencias", total)
            Else
                logica.ActualizarCaja("VentasEfectivo", total)
            End If
            AjustarFuenteLabelMaximo(LabelMensage, "Venta guardada")
            mostrar_mensaje()
            ImprimirTicketsIndividuales()
            registrar_venta()
        End If

    End Sub

    Private Sub TimerMensage_Tick(sender As Object, e As EventArgs) Handles TimerMensage.Tick
        PanelLabel.Visible = False
        LabelMensage.Visible = False
        BotonFactura.Enabled = True
        BotonRegistro.Enabled = True
        BotonTicket.Enabled = True
        TimerMensage.Stop()
    End Sub

    Private Sub registrar_venta()
        ' 1. Extraer los datos del DataGridVentas
        Dim ventasList As New List(Of (Descripcion As String, Cantidad As Integer, Subtotal As Integer, Fecha As Date))
        For Each fila As DataGridViewRow In DataGridVentas.Rows
            If fila.IsNewRow Then Continue For
            Dim descripcion As String = fila.Cells("Descripcion").Value.ToString()
            Dim cantidad As Integer = Convert.ToInt32(fila.Cells("Cantidad").Value)
            Dim subtotal As Integer = Convert.ToInt32(fila.Cells("Subtotal").Value)
            Dim fechaYhora As DateTime = DateTime.Now
            ventasList.Add((descripcion, cantidad, subtotal, fechaYhora))
        Next

        ' 2. Pasar los datos a LogicaCantina
        logica.RegistrarVentas(ventasList)

        ' 3. Borrar el contenido del DataGridVentas
        DataGridVentas.Rows.Clear()

        ' 4. Actualizar el total
        ActualizarTotal()

        ' 5. Reiniciar el vuelto
        LabelNUMVuelto.Text = "$ 0"
    End Sub

    Private Sub EmitirFacturaTipoC()
        Dim printDoc As New PrintDocument()
        AddHandler printDoc.PrintPage, AddressOf ImprimirFactura
        printDoc.DefaultPageSettings.Margins = New Margins(5, 5, 5, 5) ' 5 px en cada lado
        printDoc.Print()
    End Sub

    Private Sub drawFittedText(text As String, baseFont As Font, x As Integer, ByRef yPos As Integer, bold As Boolean, maxWidth As Integer, gfx As Graphics, Optional extraSize As Single = 0)
        Dim size As Single = baseFont.Size + extraSize
        Dim style As FontStyle = If(bold, FontStyle.Bold, FontStyle.Regular)
        Dim fittedFont As Font = New Font(baseFont.FontFamily, size, style)

        ' --- Aumentar hasta llenar el ancho ---
        While gfx.MeasureString(text, fittedFont).Width < maxWidth AndAlso size < 24 ' tope máximo más grande
            size += 0.5F
            fittedFont = New Font(baseFont.FontFamily, size, style)
        End While

        ' --- Solo reducir si se pasa del ancho ---
        While gfx.MeasureString(text, fittedFont).Width > maxWidth AndAlso size > 6
            size -= 0.5F
            fittedFont = New Font(baseFont.FontFamily, size, style)
        End While

        ' Dibujar texto
        gfx.DrawString(text, fittedFont, Brushes.Black, x, yPos)
        yPos += fittedFont.Height + 2
    End Sub

    Private Sub drawWrappedText(text As String, baseFont As Font, x As Integer, ByRef yPos As Integer, bold As Boolean, maxWidth As Integer, gfx As Graphics)
        Dim style As FontStyle = If(bold, FontStyle.Bold, FontStyle.Regular)
        Dim drawFont As Font = New Font(baseFont.FontFamily, baseFont.Size, style)

        ' Crear un rectángulo para limitar el ancho
        Dim layoutRect As New RectangleF(x, yPos, maxWidth, 1000) ' 1000 es altura máxima temporal
        Dim stringFormat As New StringFormat()
        stringFormat.FormatFlags = StringFormatFlags.LineLimit

        ' Dibujar texto ajustado automáticamente en varias líneas
        gfx.DrawString(text, drawFont, Brushes.Black, layoutRect, stringFormat)

        ' Calcular altura ocupada y actualizar yPos
        Dim measuredSize As SizeF = gfx.MeasureString(text, drawFont, maxWidth)
        yPos += CInt(measuredSize.Height) + 2
    End Sub

    Private Sub ImprimirFactura(sender As Object, e As PrintPageEventArgs)
        Dim gfx As Graphics = e.Graphics
        Dim maxWidth As Integer = e.MarginBounds.Width
        Dim y As Integer = 4
        ' Título
        drawFittedText("TICKET DE COMPRA", New Font("Roboto", 12), 4, y, True, maxWidth, gfx, 4)
        drawFittedText("Fecha: " & Date.Now.ToString("dd/MM/yyyy HH:mm"), New Font("Roboto", 10), 4, y, False, maxWidth, gfx)
        drawFittedText(New String("-"c, 32), New Font("Roboto", 10), 4, y, False, maxWidth, gfx)

        For Each fila As DataGridViewRow In DataGridVentas.Rows
            If fila.IsNewRow Then Continue For
            Dim linea As String = $"{fila.Cells("Descripcion").Value} x{fila.Cells("Cantidad").Value} - ${fila.Cells("Subtotal").Value}"
            drawWrappedText(linea, New Font("Roboto", 10), 4, y, False, maxWidth, gfx)
        Next

        ' Separador
        drawFittedText(New String("-"c, 32), New Font("Roboto", 10), 4, y, False, maxWidth, gfx)

        ' Total
        drawFittedText("TOTAL: " & LabelPrecioTotal.Text, New Font("Roboto", 12), 4, y, True, maxWidth, gfx, 4)
        drawFittedText(New String("-"c, 32), New Font("Roboto", 10), 4, y, False, maxWidth, gfx)
    End Sub

    Private Sub ImprimirTicketsIndividuales()
        ' Recorremos cada fila del DataGrid
        For Each fila As DataGridViewRow In DataGridVentas.Rows
            If fila.IsNewRow Then Continue For
            Dim descripcion As String = $"{fila.Cells("Descripcion").Value} x{fila.Cells("Cantidad").Value} - ${fila.Cells("Subtotal").Value}"
            Dim cantidad As Integer = Convert.ToInt32(fila.Cells("Cantidad").Value)

            For i As Integer = 1 To cantidad
                ' Creamos el PrintDocument
                Dim printDoc As New PrintDocument()
                AddHandler printDoc.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                                   Dim gfx As Graphics = e.Graphics
                                                   Dim maxWidth As Integer = e.MarginBounds.Width
                                                   Dim y As Integer = 5

                                                   ' Encabezado del ticket
                                                   drawFittedText("TICKET DE RETIRO", New Font("Roboto", 12), 4, y, True, maxWidth, gfx, 2)
                                                   drawWrappedText("Producto: " & descripcion, New Font("Roboto", 10), 4, y, False, maxWidth, gfx)
                                                   drawFittedText("Fecha: " & Date.Now.ToString("dd/MM/yyyy HH:mm"), New Font("Roboto", 10), 4, y, False, maxWidth, gfx)

                                                   ' Separador
                                                   drawFittedText(New String("-"c, 32), New Font("Roboto", 10), 4, y, False, maxWidth, gfx)

                                                   ' Total
                                                   drawFittedText("TOTAL: " & LabelPrecioTotal.Text, New Font("Roboto", 10), 4, y, True, maxWidth, gfx, 4)
                                                   drawFittedText(New String("-"c, 32), New Font("Roboto", 10), 4, y, False, maxWidth, gfx)
                                               End Sub
                ' Mandamos a imprimir
                printDoc.DefaultPageSettings.Margins = New Margins(5, 5, 5, 5) ' 5 px en cada lado
                printDoc.Print()
            Next
        Next

        AjustarFuenteLabelMaximo(LabelMensage, "Tickets Generados")
        mostrar_mensaje()
    End Sub

    Private Sub ventas_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        responsive()
    End Sub
End Class