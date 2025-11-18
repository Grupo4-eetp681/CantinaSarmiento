Imports System.Drawing.Printing

Public Class ventas
    ' variables globales
    Dim logica As New LogicaCantina
    Dim calcularVuelto As Boolean = False
    Private Sub responsive() ' función para hacer responsive el formulario
        PanelContenedorIZQ.Width = Form1.ContenidoGeneral.Width * 0.7 ' ajustar el ancho del panel izquierdo

        Dim altura As Integer = PanelContenedorVentas.Height
        Dim ancho As Integer = PanelContenedorVentas.Width

        PanelDataVentas.Height = altura * (2 / 3) ' ajustar la altura del panel de datos de ventas
        PanelDataVentas.Width = ancho - 50 ' ajustar el ancho del panel de datos de ventas
        PanelDataVentas.Location = New Point(25, 0) ' centrar el panel de datos de ventas
        PanelDataVentas.BringToFront() ' traer el panel de datos de ventas al frente

        TXTPago.Width = PanelDerechaINFVueltoYPago.Width * 0.3 ' ajustar el ancho del textbox de pago
        PanelCentrarPago.Width = (TXTPago.Location.X + TXTPago.Width) ' ajustar el ancho del panel de centrar pago
        PanelCentrarVuelto.Width = PanelCentrarPago.Width ' ajustar el ancho del panel de centrar vuelto

        acomodarPagoYVuelto() ' llamar a la función para acomodar pago y vuelto

        'Acomodar Botones'
        Dim anchoConjunto As Integer = PanelContenedorButtonVentas.Width ' obtener el ancho del conjunto de botones
        Dim centroEspacioDisponible As Integer = PanelDerechaINFButton.Width / 2 ' calcular el centro del espacio disponible
        Dim nuevaX As Integer = centroEspacioDisponible - (anchoConjunto \ 2) ' calcular la nueva posición X
        PanelContenedorButtonVentas.Location = New Point(nuevaX, PanelContenedorButtonVentas.Location.Y) ' ajustar la ubicación del panel de botones

        TXTPago.Text = "$ "

        AjustarFuenteLabelMaximo(LabelPago, "PAGO:") ' ajustar la fuente del label de pago
        AjustarFuenteLabelMaximo(LabelVuelto, "VUELTO:") ' ajustar la fuente del label de vuelto

        DataGridView1.RowTemplate.Height = 40 ' ajustar la altura de las filas del datagridview de productos
        DataGridVentas.RowTemplate.Height = 30 ' ajustar la altura de las filas del datagridview de ventas

        AjustarFuenteEncabezado(DataGridView1) ' ajustar la fuente del encabezado del datagridview de productos
        AjustarFuenteEncabezado(DataGridVentas) ' ajustar la fuente del encabezado del datagridview de ventas

        DataGridView1.AutoResizeColumnHeadersHeight() ' ajustar la altura del encabezado de las columnas del datagridview de productos
        DataGridView1.Invalidate() ' invalidar el datagridview de productos para forzar el redibujado

    End Sub

    Private Sub AjustarFuenteEncabezado(dgv As DataGridView)
        dgv.SuspendLayout() ' suspender el diseño del datagridview para evitar parpadeos
        Try
            Dim anchoTotal As Integer = dgv.Width ' obtener el ancho total del datagridview
            Dim tamañoMin As Single = 8 ' tamaño mínimo de la fuente
            Dim tamañoMax As Single = 16 ' tamaño máximo de la fuente
            Dim factor As Single = Math.Min(1.0F, Math.Max(0.0F, (anchoTotal - 200) / 350.0F)) ' calcular el factor de ajuste basado en el ancho
            Dim nuevoTamaño As Single = tamañoMin + (tamañoMax - tamañoMin) * factor ' calcular el nuevo tamaño de la fuente

            dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Candara", nuevoTamaño, FontStyle.Bold) ' establecer la nueva fuente para el encabezado
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' centrar el texto del encabezado
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize ' ajustar automáticamente la altura del encabezado
        Finally
            dgv.ResumeLayout() ' reanudar el diseño del datagridview
            dgv.Refresh() ' refrescar el datagridview para aplicar los cambios
        End Try
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' evita beep

            If DataGridView1.CurrentRow IsNot Nothing Then
                AgregarProductoDesdeFila(DataGridView1.CurrentRow) ' agregar el producto desde la fila seleccionada
                Busqueda.Clear() ' limpiar el textbox de búsqueda
                Busqueda.Focus() ' establecer el foco en el textbox de búsqueda
            End If
        End If
    End Sub

    Private Sub AgregarProductoDesdeFila(fila As DataGridViewRow) ' función para agregar un producto desde una fila del datagridview
        Dim descripcion As String = fila.Cells("Descripción").Value.ToString() ' obtener la descripción del producto
        Dim precio As Decimal = Convert.ToDecimal(fila.Cells("Precio").Value) ' obtener el precio del producto

        If logica.verificarCaja Then
            SolicitudCaja.ShowDialog() ' mostrar el diálogo de solicitud de caja
            Return
        Else
            Dim encontrado = False
            For Each filaVenta As DataGridViewRow In DataGridVentas.Rows
                If filaVenta.Cells("Descripcion").Value.ToString = descripcion Then
                    ' Producto ya existe en la grilla de ventas
                    Dim cantidadActual = Convert.ToInt32(filaVenta.Cells("Cantidad").Value)
                    cantidadActual += 1 ' incrementar la cantidad
                    filaVenta.Cells("Cantidad").Value = cantidadActual ' actualizar la cantidad
                    filaVenta.Cells("Subtotal").Value = cantidadActual * precio ' actualizar el subtotal
                    encontrado = True
                    Exit For
                End If
            Next

            If Not encontrado Then
                DataGridVentas.Rows.Add(descripcion, 1, precio) ' agregar un nuevo producto a la grilla de ventas

                Dim nuevaFilaIndex = DataGridVentas.Rows.Count - 1 ' obtener el índice de la nueva fila

                DataGridVentas.CurrentCell = DataGridVentas.Rows(nuevaFilaIndex).Cells("Cantidad") ' establecer la celda actual en la columna Cantidad de la nueva fila
                DataGridVentas.BeginEdit(True) ' iniciar la edición de la celda actual
            End If
        End If

        ActualizarTotal() ' actualizar el total de la venta
    End Sub

    Private Sub Busqueda_TextChanged(sender As Object, e As EventArgs) Handles Busqueda.TextChanged
        If Busqueda.Text() = "" Then
            Dim tb = logica.ObtenerTodosLosProductos() ' obtener todos los productos
            DataGridView1.DataSource = tb ' asignar la fuente de datos al datagridview
        Else
            Dim tb = logica.FiltrarProductosPorNombre(Busqueda.Text()) ' filtrar productos por nombre
            DataGridView1.DataSource = tb ' asignar la fuente de datos al datagridview
        End If
    End Sub

    Private Sub Busqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles Busqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True  ' evita beep

            If DataGridView1.Rows.Count = 1 Then
                AgregarProductoDesdeFila(DataGridView1.Rows(0)) ' agregar el producto desde la única fila disponible
                Busqueda.Clear() ' limpiar el textbox de búsqueda
            ElseIf DataGridView1.Rows.Count > 1 Then
                DataGridView1.Focus() ' establecer el foco en el datagridview de productos
                If DataGridView1.Rows.Count > 0 Then
                    DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(0) ' establecer la celda actual en la primera fila y primera columna
                End If
            End If
        End If
        Busqueda.Focus() ' mantener el foco en el textbox de búsqueda
    End Sub

    Private Sub ventas_Load(sender As Object, e As EventArgs) Handles Me.Load

        logica.cargarSubdivision(Form1.subdivision) ' cargar la subdivisión actual
        Dim tb = logica.ObtenerTodosLosProductos() ' obtener todos los productos
        DataGridView1.DataSource = tb ' asignar la fuente de datos al datagridview

        PanelContenedorIZQ.Width = Form1.ContenidoGeneral.Width * 0.7 ' ajustar el ancho del panel izquierdo

        With DataGridVentas ' configurar el datagridview de ventas
            .Dock = DockStyle.Fill ' Ocupa todo el espacio del contenedor
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill ' Las columnas ocupan todo el ancho disponible
            .RowHeadersVisible = False ' Oculta la columna de encabezado de filas
            .AllowUserToAddRows = False ' No permite agregar filas manualmente
            .AllowUserToResizeColumns = False ' No permite redimensionar columnas
            .AllowUserToResizeRows = False ' No permite redimensionar filas
            .AllowUserToOrderColumns = False ' No permite reordenar columnas
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect ' Selección de fila completa
            .MultiSelect = False ' No permite selección múltiple
            .BackColor = Color.LightGray ' Color de fondo claro
            .ForeColor = Color.Black ' Color de texto
            .CurrentCell = Nothing  ' No selecciona ninguna celda al cargar
            .DefaultCellStyle.SelectionBackColor = DataGridVentas.DefaultCellStyle.BackColor ' Desactiva el resaltado de selección
            .DefaultCellStyle.SelectionForeColor = DataGridVentas.DefaultCellStyle.ForeColor ' Desactiva el resaltado de selección
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Centra el texto en las celdas
            .Font = New Font("Candara", 10) ' Establece la fuente de las celdas
            .ColumnHeadersDefaultCellStyle = DataGridView1.ColumnHeadersDefaultCellStyle ' Copia el estilo del encabezado de columnas desde DataGridView1

            .Columns.Clear() ' Limpiar columnas existentes
            .Columns.Add("Descripcion", "Descripción") ' Agregar columnas necesarias
            .Columns.Add("Cantidad", "Cantidad") ' Agregar columnas necesarias
            .Columns.Add("Subtotal", "Subtotal") ' Agregar columnas necesarias
            .AllowUserToAddRows = False ' No permite agregar filas manualmente
            .RowHeadersVisible = False ' Oculta la columna de encabezado de filas
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect ' Selección de fila completa
            .MultiSelect = False ' No permite selección múltiple
            .Columns("Descripcion").ReadOnly = True ' Hacer la columna Descripción de solo lectura
            .Columns("Subtotal").ReadOnly = True ' Hacer la columna Subtotal de solo lectura


            ' Agregar columna botón solo si no existe aún
            If Not .Columns.Contains("Eliminar") Then
                Dim btnEliminar As New DataGridViewButtonColumn() ' Crear columna de botón
                With btnEliminar ' Configurar propiedades del botón
                    .HeaderText = "" ' encabezado vacío
                    .Name = "Eliminar" ' nombre de la columna
                    .Text = "🗑️" ' texto del botón
                    .UseColumnTextForButtonValue = True ' usar texto en lugar de valor de celda
                    .Width = 40 ' ancho del botón
                    .FlatStyle = FlatStyle.Flat ' estilo plano
                End With
                .Columns.Add(btnEliminar) ' agregar la columna al datagridview
            End If

            .Columns("Eliminar").ReadOnly = True ' Hacer la columna Eliminar de solo lectura

        End With

        'Acomodar Botones'
        Dim anchoConjunto As Integer = PanelContenedorButtonVentas.Width ' obtener el ancho del conjunto de botones
        Dim centroEspacioDisponible As Integer = PanelDerechaINFButton.Width / 2  ' calcular el centro del espacio disponible
        Dim nuevaX As Integer = centroEspacioDisponible - (anchoConjunto \ 2) ' calcular la nueva posición X
        PanelContenedorButtonVentas.Location = New Point(nuevaX, PanelContenedorButtonVentas.Location.Y) ' ajustar la ubicación del panel de botones

        TXTPago.Text = "$ "

        AjustarFuenteLabelMaximo(LabelPago, "PAGO:") ' ajustar la fuente del label de pago
        AjustarFuenteLabelMaximo(LabelVuelto, "VUELTO:") ' ajustar la fuente del label de vuelto
    End Sub

    Private Sub acomodarPagoYVuelto() ' función para acomodar los paneles de pago y vuelto
        Dim anchoDisponible As Integer = PanelDerechaINFVueltoYPago.Width ' obtener el ancho disponible

        ' --- BLOQUE PAGO ---
        Dim anchoConjunto As Integer = PanelCentrarPago.Width ' obtener el ancho del conjunto de pago
        Dim centroEspacioDisponible As Integer = PanelDerechaINFVueltoYPago.Width / 2 ' calcular el centro del espacio disponible
        Dim nuevaX As Integer = centroEspacioDisponible - (anchoConjunto \ 2) ' calcular la nueva posición X
        PanelCentrarPago.Location = New Point(nuevaX, PanelContenedorButtonVentas.Location.Y) ' ajustar la ubicación del panel de pago

        ' --- BLOQUE VUELTO ---
        PanelCentrarVuelto.Location = New Point(nuevaX, PanelCentrarVuelto.Location.Y) ' ajustar la ubicación del panel de vuelto
    End Sub

    Private Sub ventas_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim altura As Integer = PanelContenedorVentas.Height ' obtener la altura del contenedor de ventas
        Dim ancho As Integer = PanelContenedorVentas.Width ' obtener el ancho del contenedor de ventas

        PanelDataVentas.Height = altura * (2 / 3) ' ajustar la altura del panel de datos de ventas
        PanelDataVentas.Width = ancho - 50 ' ajustar el ancho del panel de datos de ventas
        PanelDataVentas.Location = New Point(25, 0) ' ajustar la ubicación del panel de datos de ventas
        PanelDataVentas.BringToFront() ' traer el panel de datos de ventas al frente

        TXTPago.Width = PanelDerechaINFVueltoYPago.Width * 0.3 ' ajustar el ancho del textbox de pago
        PanelCentrarPago.Width = (TXTPago.Location.X + TXTPago.Width) ' ajustar el ancho del panel de pago
        PanelCentrarVuelto.Width = PanelCentrarPago.Width ' ajustar el ancho del panel de vuelto

        acomodarPagoYVuelto() ' llamar a la función para acomodar pago y vuelto

    End Sub

    Private Sub TXTPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPago.KeyPress
        ' Solo permitir números y control (backspace, etc.)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True ' rechazar el carácter
        End If

        ' No permitir borrar el símbolo "$"
        If TXTPago.SelectionStart <= 1 AndAlso e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True ' rechazar el carácter
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
            TXTPago.Text = "$ " ' establecer el texto inicial
            TXTPago.SelectionStart = TXTPago.Text.Length ' mover el cursor al final
        End If
    End Sub

    Private Sub TXTPago_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTPago.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' evitar el sonido de "ding" al presionar Enter
            'Obtener el pago'
            Dim textoLimpio As String = TXTPago.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim() ' limpiar el texto
            Dim montoPago As Long = 0   ' variable para el monto
            Long.TryParse(textoLimpio, montoPago) ' convertir el texto limpio a número
            If montoPago > 0 Then
                calcularVuelto = True
            Else
                calcularVuelto = False
            End If
            'Obtener el total'
            Dim textoTotal As String = LabelPrecioTotal.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim() 'txt limpio
            Dim montoTotal As Long = 0 ' variable para el monto
            Long.TryParse(textoTotal, montoTotal) ' convertir el texto limpio a número
            'Calcular el vuelto'
            Dim vuelto As Long = montoPago - montoTotal ' calcular el vuelto
            LabelNUMVuelto.Text = "$ " & vuelto.ToString("N0", New Globalization.CultureInfo("es-AR")).Replace(" ", "") ' mostrar el vuelto formateado
            TXTPago.Text = "$ " ' establecer el texto inicial
            acomodarPagoYVuelto() ' acomodar los paneles de pago y vuelto
            BotonRegistro.Focus() ' establecer el foco en el botón de registro
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If logica.verificarCaja Then
            SolicitudCaja.ShowDialog() ' mostrar el diálogo de solicitud de caja
            Return
        Else
            If e.RowIndex >= 0 Then
                Dim filaSeleccionada = DataGridView1.Rows(e.RowIndex) ' obtener la fila seleccionada
                Dim descripcion = filaSeleccionada.Cells("Descripción").Value.ToString ' obtener la descripción del producto
                Dim precioUnitario = Convert.ToInt64(filaSeleccionada.Cells("Precio").Value) ' obtener el precio unitario del producto
                Dim encontrado = False ' variable para verificar si el producto ya está en la grilla de ventas
                For Each filaVenta As DataGridViewRow In DataGridVentas.Rows
                    If filaVenta.Cells("Descripcion").Value.ToString = descripcion Then
                        ' Producto ya existe en la grilla de ventas
                        Dim cantidadActual = Convert.ToInt32(filaVenta.Cells("Cantidad").Value) ' obtener la cantidad actual
                        cantidadActual += 1 ' incrementar la cantidad en 1
                        filaVenta.Cells("Cantidad").Value = cantidadActual ' actualizar la cantidad en la grilla de ventas
                        filaVenta.Cells("Subtotal").Value = cantidadActual * precioUnitario ' actualizar el subtotal en la grilla de ventas
                        encontrado = True ' marcar como encontrado
                        Exit For
                    End If
                Next
                If Not encontrado Then
                    ' Producto no está, lo agregamos nuevo
                    DataGridVentas.Rows.Add(descripcion, 1, precioUnitario) ' agregar el producto a la grilla de ventas
                    Dim nuevaFilaIndex = DataGridVentas.Rows.Count - 1 ' obtener el índice de la nueva fila
                    DataGridVentas.CurrentCell = DataGridVentas.Rows(nuevaFilaIndex).Cells("Cantidad") ' establecer la celda actual en la columna Cantidad de la nueva fila
                    DataGridVentas.BeginEdit(True) ' iniciar la edición de la celda actual
                End If
            End If
            ActualizarTotal() ' actualizar el total después de editar la cantidad
        End If
    End Sub

    Private Sub DataGridVentas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridVentas.CellEndEdit
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridVentas.Columns("Cantidad").Index Then
            Dim fila As DataGridViewRow = DataGridVentas.Rows(e.RowIndex) ' obtener la fila editada
            Dim cantidad As Integer
            If Not Integer.TryParse(fila.Cells("Cantidad").Value.ToString(), cantidad) Then
                cantidad = 1 ' Por si ponen texto inválido
                fila.Cells("Cantidad").Value = cantidad ' restaurar la cantidad a 1
            End If
            'Si es 0, eliminamos la fila'
            If cantidad <= 0 Then
                DataGridVentas.Rows.Remove(fila) ' eliminar la fila si la cantidad es 0 o negativa
                ActualizarTotal() ' actualizar el total después de eliminar la fila
                Return
            End If
            Dim descripcion As String = fila.Cells("Descripcion").Value.ToString() ' obtener la descripción del producto editado
            For Each filaProducto As DataGridViewRow In DataGridView1.Rows
                If filaProducto.Cells("Descripción").Value.ToString() = descripcion Then
                    Dim precioUnitario As Long = Convert.ToInt64(filaProducto.Cells("Precio").Value) ' obtener el precio unitario del producto
                    fila.Cells("Subtotal").Value = cantidad * precioUnitario ' actualizar el subtotal en la grilla de ventas
                    Exit For
                End If
            Next
        End If
        ActualizarTotal() ' actualizar el total después de editar la cantidad
    End Sub

    Private Sub ActualizarTotal() ' función para actualizar el total de la venta
        'Obtener el vuelto'
        Dim textoLimpio As String = LabelNUMVuelto.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim() ' limpiar el texto
        Dim montoPago As Long = 0 ' variable para el monto
        Long.TryParse(textoLimpio, montoPago) ' convertir el texto limpio a número
        'Obtener el total'
        Dim textoTotal As String = LabelPrecioTotal.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim() ' limpiar el texto
        Dim montoTotal As Long = 0 ' variable para el monto
        Long.TryParse(textoTotal, montoTotal) ' convertir el texto limpio a número
        'Calcular el pago'
        Dim pago As Long = montoPago + montoTotal ' calcular el pago
        Dim anchoAntes As Integer = LabelPrecioTotal.Width ' obtener el ancho antes de actualizar el total
        Dim posicionAntes As Integer = LabelPrecioTotal.Location.X ' obtener la posición antes de actualizar el total
        Dim total As Long = 0 ' variable para el total
        For Each fila As DataGridViewRow In DataGridVentas.Rows
            If fila.Cells("Subtotal").Value IsNot Nothing Then
                total += Convert.ToInt64(fila.Cells("Subtotal").Value) ' sumar el subtotal al total
            End If
        Next
        LabelPrecioTotal.Text = "$ " & total.ToString("N0", New Globalization.CultureInfo("es-AR")).Replace(" ", "") ' mostrar el total formateado
        Dim anchoDespues As Integer = LabelPrecioTotal.Width ' obtener el ancho después de actualizar el total
        Dim posicionDespues As Integer = posicionAntes - (anchoDespues - anchoAntes) ' calcular la nueva posición después de actualizar el total
        LabelPrecioTotal.Location = New Point(posicionDespues, LabelPrecioTotal.Location.Y) ' actualizar la posición del label del total
        If calcularVuelto Then
            'Calcular el vuelto'
            Dim vuelto As Long = pago - total ' calcular el vuelto
            Dim texto As String = "$ " & vuelto.ToString("N0", New Globalization.CultureInfo("es-AR")).Replace(" ", "") ' formatear el vuelto
            AjustarFuenteLabelMaximo(LabelNUMVuelto, texto) ' ajustar la fuente del label del vuelto
            TXTPago.Text = "$ " ' reiniciar el texto del textbox de pago
            acomodarPagoYVuelto() ' acomodar los paneles de pago y vuelto
        End If
    End Sub

    Private Sub DataGridVentas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridVentas.CellDoubleClick
        If e.RowIndex >= 0 Then
            DataGridVentas.ClearSelection() ' limpiar la selección actual
            DataGridVentas.Rows(e.RowIndex).Selected = True ' seleccionar la fila doble clickeada
        End If
    End Sub

    Private Sub DataGridVentas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridVentas.CellContentClick
        If e.RowIndex >= 0 AndAlso DataGridVentas.Columns(e.ColumnIndex).Name = "Eliminar" Then
            DataGridVentas.Rows.RemoveAt(e.RowIndex) ' eliminar la fila seleccionada
            ActualizarTotal() ' actualizar el total después de eliminar la fila
        End If
    End Sub

    Private Sub mostrar_mensaje()
        PanelLabel.Visible = True ' mostrar el panel del mensaje
        LabelMensage.Visible = True ' mostrar el label del mensaje
        BotonFactura.Enabled = False ' deshabilitar el botón de factura
        BotonRegistro.Enabled = False ' deshabilitar el botón de registro
        BotonTicket.Enabled = False ' deshabilitar el botón de ticket
        TimerMensage.Start() ' iniciar el temporizador del mensaje
    End Sub

    Private Sub AjustarFuenteLabelMaximo(label As Label, texto As String)
        Dim anchoMaximo As Integer = label.Width ' obtener el ancho máximo del label
        Dim altoMaximo As Integer = label.Height ' obtener el alto máximo del label
        Dim fuenteBase As Font = label.Font ' obtener la fuente base del label
        Dim tamañoFuente As Single = fuenteBase.Size ' inicializar el tamaño de la fuente
        ' Prueba desde un tamaño grande hacia abajo
        For size As Single = 48 To 8 Step -1
            Using fuentePrueba As New Font(fuenteBase.FontFamily, size, fuenteBase.Style) ' crear una fuente de prueba
                Dim tamañoTexto As Size = TextRenderer.MeasureText(texto, fuentePrueba, New Size(anchoMaximo, altoMaximo), TextFormatFlags.WordBreak) ' medir el tamaño del texto con la fuente de prueba
                If tamañoTexto.Width <= anchoMaximo AndAlso tamañoTexto.Height <= altoMaximo Then ' verificar si el tamaño del texto cabe en el label
                    tamañoFuente = size ' actualizar el tamaño de la fuente
                    Exit For
                End If
            End Using
        Next
        label.Font = New Font(fuenteBase.FontFamily, tamañoFuente, fuenteBase.Style) ' establecer la nueva fuente del label
        label.Text = texto ' establecer el texto del label
        label.TextAlign = ContentAlignment.MiddleCenter ' centrar el texto del label
    End Sub

    Private Sub BotonRegistro_Click(sender As Object, e As EventArgs) Handles BotonRegistro.Click
        If Form1.botonRegistro = False Then
            Exit Sub
        End If
        calcularVuelto = False
        If DataGridVentas.Rows.Count = 0 Then
            AjustarFuenteLabelMaximo(LabelMensage, "Lista de venta vacía") ' ajustar la fuente del label del mensaje
            mostrar_mensaje() ' mostrar el mensaje
            Return
        End If
        Dim origen = "BotonRegistro" ' definir el origen del mensaje
        Dim mensaje = "¿Confirmar registro de venta?" ' definir el mensaje
        Dim continuar As Boolean = True ' variable para controlar si se continúa con la acción
        If Not logica.ObtenerEstadoAdvertencia(origen) Then
            Dim frm As New Advertencia(mensaje, origen) ' crear una instancia del formulario de advertencia
            Dim resultado = frm.ShowDialog() ' mostrar el formulario de advertencia
            If resultado = DialogResult.OK Then
                If frm.NoMostrarMas Then
                    logica.GuardarEstadoAdvertencia(origen, True) ' guardar el estado de la advertencia
                End If
                continuar = True ' actualizar la variable para controlar si se continúa con la acción
            Else
                continuar = False ' actualizar la variable para controlar si se continúa con la acción
            End If
        End If
        If continuar Then
            Dim total As Int128 = Int128.Parse(LabelPrecioTotal.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim()) ' obtener el total de la venta
            If CheckBoxTransferencia.CheckState Then
                logica.ActualizarCaja("VentasTransferencias", total) ' actualizar la caja de transferencias
            Else
                logica.ActualizarCaja("VentasEfectivo", total) ' actualizar la caja de efectivo
            End If
            AjustarFuenteLabelMaximo(LabelMensage, "Venta guardada") ' ajustar la fuente del label del mensaje
            mostrar_mensaje() ' mostrar el mensaje
            registrar_venta() ' registrar la venta
        End If
    End Sub

    Private Sub BotonFactura_Click(sender As Object, e As EventArgs) Handles BotonFactura.Click
        calcularVuelto = False ' desactivar el cálculo de vuelto
        If DataGridVentas.Rows.Count = 0 Then
            AjustarFuenteLabelMaximo(LabelMensage, "Lista de venta vacía") ' ajustar la fuente del label del mensaje
            mostrar_mensaje() ' mostrar el mensaje
            Return
        End If
        Dim origen = "BotonFactura" ' definir el origen del mensaje
        Dim mensaje = "¿Confirmar registro de venta?" ' definir el mensaje
        Dim continuar As Boolean = True ' variable para controlar si se continúa con la acción
        If Not logica.ObtenerEstadoAdvertencia(origen) Then
            Dim frm As New Advertencia(mensaje, origen) ' crear una instancia del formulario de advertencia
            Dim resultado = frm.ShowDialog() ' mostrar el formulario de advertencia
            If resultado = DialogResult.OK Then
                If frm.NoMostrarMas Then
                    logica.GuardarEstadoAdvertencia(origen, True) ' guardar el estado de la advertencia
                End If
                continuar = True ' actualizar la variable para controlar si se continúa con la acción
            Else
                continuar = False ' actualizar la variable para controlar si se continúa con la acción
            End If
        End If
        If continuar Then
            Dim total As Int128 = Int128.Parse(LabelPrecioTotal.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim()) ' obtener el total de la venta
            If CheckBoxTransferencia.CheckState Then
                logica.ActualizarCaja("VentasTransferencias", total) ' actualizar la caja de transferencias
            Else
                logica.ActualizarCaja("VentasEfectivo", total) ' actualizar la caja de efectivo
            End If
            AjustarFuenteLabelMaximo(LabelMensage, "Venta guardada") ' ajustar la fuente del label del mensaje
            mostrar_mensaje() ' mostrar el mensaje
            EmitirFacturaTipoC() ' emitir la factura tipo C
            registrar_venta() ' registrar la venta
        End If
    End Sub

    Private Sub BotonTicket_Click(sender As Object, e As EventArgs) Handles BotonTicket.Click
        calcularVuelto = False
        If DataGridVentas.Rows.Count = 0 Then
            AjustarFuenteLabelMaximo(LabelMensage, "Lista de venta vacía") ' ajustar la fuente del label del mensaje
            mostrar_mensaje() ' mostrar el mensaje
            Return
        End If
        Dim origen = "BotonTicket" ' definir el origen del mensaje
        Dim mensaje = "¿Confirmar registro de venta?" ' definir el mensaje
        Dim continuar As Boolean = True ' variable para controlar si se continúa con la acción
        If Not logica.ObtenerEstadoAdvertencia(origen) Then
            Dim frm As New Advertencia(mensaje, origen) ' crear una instancia del formulario de advertencia
            Dim resultado = frm.ShowDialog() ' mostrar el formulario de advertencia
            If resultado = DialogResult.OK Then
                If frm.NoMostrarMas Then
                    logica.GuardarEstadoAdvertencia(origen, True) ' guardar el estado de la advertencia
                End If
                continuar = True ' actualizar la variable para controlar si se continúa con la acción
            Else
                continuar = False ' actualizar la variable para controlar si se continúa con la acción
            End If
        End If
        If continuar Then
            Dim total As Int128 = Int128.Parse(LabelPrecioTotal.Text.Replace("$", "").Replace(".", "").Replace(",", "").Trim()) ' obtener el total de la venta
            If CheckBoxTransferencia.CheckState Then
                logica.ActualizarCaja("VentasTransferencias", total) ' actualizar la caja de transferencias
            Else
                logica.ActualizarCaja("VentasEfectivo", total) ' actualizar la caja de efectivo
            End If
            AjustarFuenteLabelMaximo(LabelMensage, "Venta guardada") ' ajustar la fuente del label del mensaje
            mostrar_mensaje() ' mostrar el mensaje
            ImprimirTicketsIndividuales() ' imprimir los tickets individuales
            registrar_venta() ' registrar la venta
        End If
    End Sub

    Private Sub TimerMensage_Tick(sender As Object, e As EventArgs) Handles TimerMensage.Tick
        PanelLabel.Visible = False ' ocultar el panel del mensaje
        LabelMensage.Visible = False ' ocultar el label del mensaje
        BotonFactura.Enabled = True ' habilitar el botón de factura
        BotonRegistro.Enabled = True ' habilitar el botón de registro
        BotonTicket.Enabled = True ' habilitar el botón de ticket
        TimerMensage.Stop() ' detener el temporizador del mensaje
    End Sub

    Private Sub registrar_venta()
        ' 1. Extraer los datos del DataGridVentas
        Dim ventasList As New List(Of (Descripcion As String, Cantidad As Integer, Subtotal As Integer, Fecha As Date)) ' lista para almacenar los datos de ventas
        For Each fila As DataGridViewRow In DataGridVentas.Rows
            If fila.IsNewRow Then Continue For
            Dim descripcion As String = fila.Cells("Descripcion").Value.ToString() ' obtener la descripción del producto
            Dim cantidad As Integer = Convert.ToInt32(fila.Cells("Cantidad").Value) ' obtener la cantidad del producto
            Dim subtotal As Integer = Convert.ToInt32(fila.Cells("Subtotal").Value) ' obtener el subtotal del producto
            Dim fechaYhora As DateTime = DateTime.Now ' obtener la fecha y hora actual
            ventasList.Add((descripcion, cantidad, subtotal, fechaYhora)) ' agregar los datos a la lista
        Next
        logica.RegistrarVentas(ventasList) ' 2. Pasar los datos a LogicaCantina para registrar la venta
        DataGridVentas.Rows.Clear() ' 3. Borrar el contenido del DataGridVentas
        ActualizarTotal() ' 4. Actualizar el total
        LabelNUMVuelto.Text = "$ 0" ' 5. Reiniciar el vuelto
    End Sub

    Private Sub EmitirFacturaTipoC()
        Dim printDoc As New PrintDocument() ' crear un nuevo documento de impresión
        AddHandler printDoc.PrintPage, AddressOf ImprimirFactura ' asignar el manejador de evento para la impresión de la página
        printDoc.DefaultPageSettings.Margins = New Margins(5, 5, 5, 5) ' 5 px en cada lado 
        printDoc.Print() ' iniciar la impresión
    End Sub

    Private Sub drawFittedText(text As String, baseFont As Font, x As Integer, ByRef yPos As Integer, bold As Boolean, maxWidth As Integer, gfx As Graphics, Optional extraSize As Single = 0)
        Dim size As Single = baseFont.Size + extraSize ' tamaño inicial de la fuente
        Dim style As FontStyle = If(bold, FontStyle.Bold, FontStyle.Regular) ' estilo de la fuente
        Dim fittedFont As Font = New Font(baseFont.FontFamily, size, style) ' fuente ajustada
        ' --- Aumentar hasta llenar el ancho ---
        While gfx.MeasureString(text, fittedFont).Width < maxWidth AndAlso size < 24 ' tope máximo más grande
            size += 0.5F ' aumentar el tamaño
            fittedFont = New Font(baseFont.FontFamily, size, style) ' actualizar la fuente ajustada
        End While
        ' --- Solo reducir si se pasa del ancho ---
        While gfx.MeasureString(text, fittedFont).Width > maxWidth AndAlso size > 6
            size -= 0.5F ' reducir el tamaño
            fittedFont = New Font(baseFont.FontFamily, size, style) ' actualizar la fuente ajustada
        End While
        ' Dibujar texto
        gfx.DrawString(text, fittedFont, Brushes.Black, x, yPos) ' dibujar el texto en la posición especificada
        yPos += fittedFont.Height + 2 ' actualizar la posición Y para la siguiente línea
    End Sub

    Private Sub drawWrappedText(text As String, baseFont As Font, x As Integer, ByRef yPos As Integer, bold As Boolean, maxWidth As Integer, gfx As Graphics)
        Dim style As FontStyle = If(bold, FontStyle.Bold, FontStyle.Regular) ' estilo de la fuente
        Dim drawFont As Font = New Font(baseFont.FontFamily, baseFont.Size, style) ' fuente para dibujar
        ' Crear un rectángulo para limitar el ancho
        Dim layoutRect As New RectangleF(x, yPos, maxWidth, 1000) ' 1000 es altura máxima temporal
        Dim stringFormat As New StringFormat() ' formato de cadena
        stringFormat.FormatFlags = StringFormatFlags.LineLimit ' limitar a líneas completas
        ' Dibujar texto ajustado automáticamente en varias líneas
        gfx.DrawString(text, drawFont, Brushes.Black, layoutRect, stringFormat) ' dibujar el texto en el rectángulo especificado
        ' Calcular altura ocupada y actualizar yPos
        Dim measuredSize As SizeF = gfx.MeasureString(text, drawFont, maxWidth) ' medir el tamaño del texto
        yPos += CInt(measuredSize.Height) + 2 ' actualizar la posición Y para la siguiente línea
    End Sub

    Private Sub ImprimirFactura(sender As Object, e As PrintPageEventArgs)
        Dim gfx As Graphics = e.Graphics ' objeto Graphics para dibujar en la página
        Dim maxWidth As Integer = e.MarginBounds.Width ' ancho máximo disponible para imprimir
        Dim y As Integer = 4 ' posición Y inicial
        ' --- Título ---
        drawFittedText("TICKET DE COMPRA", New Font("Roboto", 12), 4, y, True, maxWidth, gfx, 4) ' título del ticket
        drawFittedText("Fecha: " & Date.Now.ToString("dd/MM/yyyy HH:mm"), New Font("Roboto", 10), 4, y, False, maxWidth, gfx) ' fecha y hora
        drawFittedText(New String("-"c, 32), New Font("Roboto", 10), 4, y, False, maxWidth, gfx) ' separador
        ' --- Filas ---
        For Each fila As DataGridViewRow In DataGridVentas.Rows
            If fila.IsNewRow Then Continue For
            Dim linea As String = $"{fila.Cells("Descripcion").Value} x{fila.Cells("Cantidad").Value} - ${fila.Cells("Subtotal").Value}" ' construir la línea de texto
            drawWrappedText(linea, New Font("Roboto", 10), 4, y, False, maxWidth, gfx) ' dibujar la línea de texto
        Next
        y += 5 ' espacio antes del total
        ' --- Separador ---
        drawFittedText(New String("-"c, 32), New Font("Roboto", 10), 4, y, False, maxWidth, gfx) ' separador
        y += 10 ' espacio después del separador
        ' --- Total ---
        drawFittedText("TOTAL: " & LabelPrecioTotal.Text, New Font("Roboto", 12), 4, y, True, maxWidth, gfx, 4) ' total
        drawFittedText(New String("-"c, 32), New Font("Roboto", 10), 4, y, False, maxWidth, gfx) ' separador final
        y += 5 ' espacio después del total
    End Sub

    Private Sub ImprimirTicketsIndividuales()
        Dim totalGeneral As String = LabelPrecioTotal.Text ' Obtener el total general de la venta
        Dim margenEntreTickets As Integer = 80 ' Espacio adicional entre tickets
        Dim ticketIndex As Integer = 0 ' Índice del ticket actual
        Dim totalTickets As Integer = 0 ' Contador total de tickets a imprimir
        ' Contamos cuántos tickets en total se imprimirán
        For Each fila As DataGridViewRow In DataGridVentas.Rows
            If fila.IsNewRow Then Continue For
            totalTickets += Convert.ToInt32(fila.Cells("Cantidad").Value) ' Sumar la cantidad de cada producto
        Next
        ' Recorremos productos y cantidades
        For Each fila As DataGridViewRow In DataGridVentas.Rows
            If fila.IsNewRow Then Continue For
            Dim descripcionBase As String = fila.Cells("Descripcion").Value.ToString()
            Dim precioUnidad As Decimal = Convert.ToDecimal(fila.Cells("Subtotal").Value)
            Dim cantidad As Integer = Convert.ToInt32(fila.Cells("Cantidad").Value)

            Dim descripcion As String = $"{descripcionBase} - ${precioUnidad}"
            For i As Integer = 1 To cantidad
                ticketIndex += 1 ' Incrementar el índice del ticket
                Dim printDoc As New PrintDocument() ' Crear un nuevo documento de impresión
                AddHandler printDoc.PrintPage, Sub(sender As Object, e As PrintPageEventArgs)
                                                   Dim gfx As Graphics = e.Graphics ' Objeto Graphics para dibujar en la página
                                                   Dim maxWidth As Integer = e.MarginBounds.Width ' Ancho máximo disponible para imprimir
                                                   Dim y As Integer = 5 ' Posición Y inicial
                                                   drawFittedText("TICKET DE RETIRO", New Font("Roboto", 12), 4, y, True, maxWidth, gfx, 2) ' Título del ticket
                                                   drawWrappedText("Producto: " & descripcion, New Font("Roboto", 10), 4, y, False, maxWidth, gfx) ' Descripción del producto
                                                   drawFittedText("Fecha: " & Date.Now.ToString("dd/MM/yyyy HH:mm"), New Font("Roboto", 10), 4, y, False, maxWidth, gfx) ' Fecha y hora
                                                   drawFittedText(New String("-"c, 32), New Font("Roboto", 10), 4, y, False, maxWidth, gfx) ' Separador
                                                   If ticketIndex = totalTickets Then
                                                       drawFittedText("TOTAL: " & totalGeneral, New Font("Roboto", 11, FontStyle.Bold), 4, y, True, maxWidth, gfx, 4) ' Total general
                                                       drawFittedText(New String("-"c, 32), New Font("Roboto", 10), 4, y, False, maxWidth, gfx) ' Separador final
                                                   End If
                                                   y += margenEntreTickets ' Espacio antes del siguiente ticket
                                                   drawFittedText(New String(" "), New Font("Roboto", 10), 4, y, False, maxWidth, gfx) ' Espacio adicional
                                               End Sub

                printDoc.DefaultPageSettings.Margins = New Margins(5, 5, 5, 5) ' 5 px en cada lado
                printDoc.Print() ' Iniciar la impresión
            Next
        Next
        AjustarFuenteLabelMaximo(LabelMensage, "Tickets Generados") ' ajustar la fuente del label del mensaje
        mostrar_mensaje() ' mostrar el mensaje
    End Sub

    Private Sub ventas_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        responsive() ' llamar a la función para ajustar el diseño responsivo
    End Sub

    Private Sub PanelDataGrid_Resize(sender As Object, e As EventArgs) Handles PanelDataGrid.Resize
        DataGridView1.AutoResizeColumnHeadersHeight() ' ajustar la altura de los encabezados de columna
        DataGridView1.Invalidate() ' invalidar el control para forzar el redibujado
    End Sub
End Class