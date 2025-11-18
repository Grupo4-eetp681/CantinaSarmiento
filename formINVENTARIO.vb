Public Class formINVENTARIO
    ' variables globales
    Dim logica As New LogicaCantina
    Dim productoSeleccionado As DataRow = Nothing

    ' Variables de control
    Private manejandoCelda As Boolean = False
    Private ultimoMovimientoManual As Boolean = False
    
    ' Cargar el formulario
    Private Sub formINVENTARIO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        logica.cargarSubdivision(Form1.subdivision) ' cargar la subdivisión actual
        ' Cargar todos los productos en el DataGridView
        DataGridViewInventario.DataSource = logica.ObtenerTodosLosProductosInventario() ' consulta que se ejecuta en la variable logica, la cual trae todos los productos del inventario
        DataGridViewInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect ' seleccionar fila completa
        DataGridViewInventario.ReadOnly = False ' permitir edición
        DataGridViewInventario.AllowUserToAddRows = False ' no permitir agregar filas manualmente
        DataGridViewInventario.MultiSelect = False ' no permitir selección múltiple
        DataGridViewInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill ' ajustar columnas al ancho del DataGridView
        DataGridViewInventario.Columns("ID").ReadOnly = True ' hacer columna ID de solo lectura
        DataGridViewInventario.Columns("Ganancia").ReadOnly = True ' hacer columna Ganancia de solo lectura

        DataGridViewInventario.RowTemplate.Height = 30 ' ajustar altura de filas

    End Sub

    ' Guardar el producto seleccionado para operar con él
    Private Sub DataGridViewInventario_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewInventario.SelectionChanged
        If DataGridViewInventario.SelectedRows.Count > 0 Then
            Dim rowIndex = DataGridViewInventario.SelectedRows(0).Index ' obtener el índice de la fila seleccionada
            Dim dt = CType(DataGridViewInventario.DataSource, DataTable) ' obtener el DataTable vinculado
            If rowIndex >= 0 AndAlso rowIndex < dt.Rows.Count Then
                productoSeleccionado = dt.Rows(rowIndex) ' guardar la fila seleccionada
            End If
        End If
    End Sub

    ' Permitir edición con doble clic
    Private Sub DataGridViewInventario_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInventario.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            DataGridViewInventario.BeginEdit(True) ' iniciar edición de la celda
        End If
    End Sub

    ' Capturar Enter para guardar el cambio
    Private Sub DataGridViewInventario_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridViewInventario.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' evitar el sonido de alerta
        ElseIf e.KeyCode = Keys.Tab Then
            ultimoMovimientoManual = True ' marcar que el movimiento fue manual
        End If
    End Sub

    Private Sub DataGridViewInventario_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInventario.CellEndEdit
        If manejandoCelda Then Exit Sub
        manejandoCelda = True ' marcar que se está manejando la celda

        Try
            Dim fila = DataGridViewInventario.CurrentRow ' obtener la fila actual
            DataGridViewInventario.EndEdit() ' finalizar edición

            If fila IsNot Nothing Then
                Dim idProducto = Convert.ToInt32(fila.Cells("ID").Value) ' obtener ID del producto
                Dim descripcion = fila.Cells("Descripción").Value.ToString() ' obtener descripción
                Dim precioVenta = Convert.ToDouble(fila.Cells("Precio_Unitario").Value) ' obtener precio de venta
                Dim precioCosto = Convert.ToDouble(fila.Cells("Precio_Costo").Value) ' obtener precio de costo
                Dim ganancia = precioVenta - precioCosto ' calcular ganancia
                fila.Cells("Ganancia").Value = ganancia ' actualizar ganancia en la celda

                ' Validar descripción vacía
                If String.IsNullOrWhiteSpace(descripcion) Then
                    Dim origen = "CeldasInventario" ' origen de la advertencia
                    Dim mensaje = "La descripción del producto no puede estar vacía." ' mensaje de la advertencia

                    Dim continuar As Boolean = True
                    If Not logica.ObtenerEstadoAdvertencia(origen) Then 
                        Dim frm As New Advertencia(mensaje, origen) ' crear formulario de advertencia
                        Dim resultado = frm.ShowDialog() ' mostrar el formulario de advertencia
                        If resultado = DialogResult.OK Then
                            If frm.NoMostrarMas Then logica.GuardarEstadoAdvertencia(origen, True) ' guardar estado de advertencia
                            continuar = True
                        Else
                            continuar = False
                        End If
                    End If

                    ' Restaurar valor anterior
                    fila.Cells("Descripción").Value = If(productoSeleccionado IsNot Nothing, productoSeleccionado("Descripción"), "") 
                    DataGridViewInventario.CurrentCell = fila.Cells("Descripción") ' establecer celda actual
                    DataGridViewInventario.BeginEdit(True) ' iniciar edición
                    Exit Sub
                End If

                ' Validar precio vacío
                If precioVenta <= 0 Or precioVenta = Nothing Then
                    Dim origen = "CeldasInventario" ' origen de la advertencia
                    Dim mensaje = "El precio de venta no puede ser 0 o negativo" ' mensaje de la advertencia

                    Dim continuar As Boolean = True
                    If Not logica.ObtenerEstadoAdvertencia(origen) Then
                        Dim frm As New Advertencia(mensaje, origen) ' crear formulario de advertencia
                        Dim resultado = frm.ShowDialog() ' mostrar el formulario de advertencia
                        If resultado = DialogResult.OK Then 
                            If frm.NoMostrarMas Then logica.GuardarEstadoAdvertencia(origen, True) ' guardar estado de advertencia
                            continuar = True
                        Else
                            continuar = False
                        End If
                    End If

                    ' Restaurar valor anterior
                    fila.Cells("Precio_Unitario").Value = If(productoSeleccionado IsNot Nothing, productoSeleccionado("Precio_Unitario"), "")
                    DataGridViewInventario.CurrentCell = fila.Cells("Precio_Unitario") ' establecer celda actual
                    DataGridViewInventario.BeginEdit(True) ' iniciar edición
                    Exit Sub
                End If

                ' Guardar en DB
                logica.ActualizarProducto(idProducto, descripcion, precioVenta, precioCosto)
            End If

            ' --- Evitar mover celda si fue por Tab ---
            If ultimoMovimientoManual Then
                ultimoMovimientoManual = False
                manejandoCelda = False
                Exit Sub
            End If

            ' --- Mover automáticamente a la siguiente celda ---
            Dim fil As Integer = e.RowIndex
            Dim col As Integer = e.ColumnIndex

            If fil < 0 OrElse fil >= DataGridViewInventario.Rows.Count Then Exit Sub
            If col < 0 OrElse col >= DataGridViewInventario.Columns.Count Then Exit Sub

            ' el BeginInvoke es para que se ejecute después de que termine todo este proceso
            Me.BeginInvoke(New Action(Sub()
                                          If fil < DataGridViewInventario.Rows.Count AndAlso col < DataGridViewInventario.Columns.Count Then
                                              If col < 3 And col > 0 Then
                                                  Dim celdaDestino As DataGridViewCell = DataGridViewInventario.Rows(fil).Cells(col + 1) ' siguiente celda en la misma fila
                                                  If celdaDestino IsNot Nothing Then
                                                      DataGridViewInventario.CurrentCell = celdaDestino ' mover a la siguiente celda
                                                      DataGridViewInventario.BeginEdit(True) ' iniciar edición
                                                  End If
                                              Else
                                                  DataGridViewInventario.CurrentCell = Nothing ' quitar selección
                                              End If
                                          End If
                                      End Sub))

        Finally
            manejandoCelda = False
        End Try
    End Sub

    Private Sub ButtonAgregar_Click(sender As Object, e As EventArgs) Handles ButtonAgregar.Click

        Dim origen = "BotonAgregar" ' origen de la advertencia
        Dim mensaje = "¿Confirmar Nuevo Producto?" ' mensaje de la advertencia
        Dim continuar As Boolean = True 

        If Not logica.ObtenerEstadoAdvertencia(origen) Then
            Dim frm As New Advertencia(mensaje, origen) ' crear formulario de advertencia
            Dim resultado = frm.ShowDialog() ' mostrar el formulario de advertencia
            If resultado = DialogResult.OK Then
                If frm.NoMostrarMas Then
                    logica.GuardarEstadoAdvertencia(origen, True) ' guardar estado de advertencia
                End If
                continuar = True
            Else
                continuar = False
            End If
        End If

        If continuar Then
            Dim newId As Integer = logica.InsertarProductoVacio() ' insertar producto vacío en la base y obtener su ID

            ' Agregar la fila al DataTable
            Dim dt = CType(DataGridViewInventario.DataSource, DataTable)
            Dim nuevaFila As DataRow = dt.NewRow() ' crear nueva fila
            nuevaFila("ID") = newId ' asignar el ID generado
            nuevaFila("Descripción") = "" ' descripción vacía
            nuevaFila("Precio_Unitario") = 0 ' precio de venta 0
            nuevaFila("Precio_Costo") = 0 ' precio de costo 0
            nuevaFila("Ganancia") = 0 ' ganancia 0 
            dt.Rows.Add(nuevaFila) ' agregar la fila al DataTable

            ' Seleccionar y editar directamente la nueva fila
            DataGridViewInventario.CurrentCell =
            DataGridViewInventario.Rows(DataGridViewInventario.Rows.Count - 1).Cells("Descripción") ' seleccionar la celda de descripción de la nueva fila
            DataGridViewInventario.BeginEdit(True) ' iniciar edición

            Dim ultimaFila As Integer = DataGridViewInventario.Rows.Count - 1 ' obtener el índice de la última fila
            DataGridViewInventario.CurrentCell = DataGridViewInventario.Rows(ultimaFila).Cells(1) ' seleccionar la celda de descripción de la nueva fila
            DataGridViewInventario.BeginEdit(True) ' iniciar edición

        End If
    End Sub

    ' Eliminar producto seleccionado
    Private Sub ButtonEliminar_Click(sender As Object, e As EventArgs) Handles ButtonEliminar.Click

        If DataGridViewInventario.CurrentRow IsNot Nothing Then
            Dim origen = "BotonEliminar" ' origen de la advertencia
            Dim mensaje = "¿Seguro Que Desea Eliminar El Producto?" ' mensaje de la advertencia
            Dim continuar As Boolean = True 

            If Not logica.ObtenerEstadoAdvertencia(origen) Then
                Dim frm As New Advertencia(mensaje, origen) ' crear formulario de advertencia
                Dim resultado = frm.ShowDialog() ' mostrar el formulario de advertencia
                If resultado = DialogResult.OK Then
                    If frm.NoMostrarMas Then 
                        logica.GuardarEstadoAdvertencia(origen, True) ' guardar estado de advertencia
                    End If
                    continuar = True
                Else
                    continuar = False
                End If
            End If

            If continuar Then
                Dim idProducto As Integer = Convert.ToInt32(DataGridViewInventario.CurrentRow.Cells("ID").Value) ' obtener ID del producto

                ' Eliminar en la base
                logica.EliminarProducto(idProducto) ' eliminar producto de la base de datos

                ' Eliminar en la tabla vinculada al DGV
                Dim dt = CType(DataGridViewInventario.DataSource, DataTable)
                dt.Rows.RemoveAt(DataGridViewInventario.CurrentRow.Index) ' eliminar la fila del DataTable
            End If
        End If
    End Sub

    Private Sub DataGridViewInventario_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles DataGridViewInventario.CellValidating
        Dim dgv As DataGridView = CType(sender, DataGridView) ' obtener el DataGridView
        Dim colName As String = dgv.Columns(e.ColumnIndex).Name ' obtener el nombre de la columna
        Dim valor As String = e.FormattedValue?.ToString().Trim() ' obtener el valor ingresado y eliminar espacios

        ' === VALIDAR DESCRIPCIÓN ===
        If colName = "Descripción" Then
            If String.IsNullOrWhiteSpace(valor) Then
                Dim origen = "ValidacionDescripcion" ' origen de la advertencia
                Dim mensaje = "La descripción no puede estar vacía." ' mensaje de la advertencia
                Dim continuar As Boolean = True

                If Not logica.ObtenerEstadoAdvertencia(origen) Then
                    Dim frm As New Advertencia(mensaje, origen) ' crear formulario de advertencia
                    Dim resultado = frm.ShowDialog() ' mostrar el formulario de advertencia

                    If resultado = DialogResult.OK Then
                        If frm.NoMostrarMas Then logica.GuardarEstadoAdvertencia(origen, True) ' guardar estado de advertencia
                        continuar = True
                    Else
                        continuar = False
                    End If
                End If

                If Not continuar Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        End If

        ' === VALIDAR PRECIO UNITARIO ===
        If colName = "Precio_Unitario" Then
            Dim precioVenta As Double
            If Not Double.TryParse(valor, precioVenta) OrElse precioVenta <= 0 Then
                Dim origen = "ValidacionPrecioVenta" ' origen de la advertencia
                Dim mensaje = "El precio de venta debe ser un número mayor que 0." ' mensaje de la advertencia
                Dim continuar As Boolean = True

                If Not logica.ObtenerEstadoAdvertencia(origen) Then
                    Dim frm As New Advertencia(mensaje, origen) ' crear formulario de advertencia
                    Dim resultado = frm.ShowDialog() ' mostrar el formulario de advertencia

                    If resultado = DialogResult.OK Then
                        If frm.NoMostrarMas Then logica.GuardarEstadoAdvertencia(origen, True) ' guardar estado de advertencia
                        continuar = True
                    Else
                        continuar = False
                    End If
                End If

                If Not continuar Then
                    e.Cancel = True ' cancelar la edición
                    Exit Sub
                End If
            End If
        End If

        ' === VALIDAR PRECIO COSTO ===
        If colName = "Precio_Costo" Then
            Dim precioCosto As Double
            If Not Double.TryParse(valor, precioCosto) OrElse precioCosto < 0 Then
                Dim origen = "ValidacionPrecioCosto" ' origen de la advertencia
                Dim mensaje = "El precio de costo no puede ser negativo." ' mensaje de la advertencia
                Dim continuar As Boolean = True

                If Not logica.ObtenerEstadoAdvertencia(origen) Then
                    Dim frm As New Advertencia(mensaje, origen) ' crear formulario de advertencia
                    Dim resultado = frm.ShowDialog() ' mostrar el formulario de advertencia

                    If resultado = DialogResult.OK Then
                        If frm.NoMostrarMas Then logica.GuardarEstadoAdvertencia(origen, True) ' guardar estado de advertencia
                        continuar = True
                    Else
                        continuar = False
                    End If
                End If

                If Not continuar Then
                    e.Cancel = True ' cancelar la edición
                    Exit Sub
                End If
            End If
        End If
    End Sub

End Class