Public Class formINVENTARIO
    Dim logica As New LogicaCantina
    Dim productoSeleccionado As DataRow = Nothing

    Private Sub formINVENTARIO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        logica.cargarSubdivision(Form1.subdivision)
        ' Cargar todos los productos en el DataGridView
        DataGridViewInventario.DataSource = logica.ObtenerTodosLosProductosInventario()
        DataGridViewInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridViewInventario.ReadOnly = False
        DataGridViewInventario.AllowUserToAddRows = False
        DataGridViewInventario.MultiSelect = False
        DataGridViewInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewInventario.Columns("ID").ReadOnly = True
        DataGridViewInventario.Columns("Ganancia").ReadOnly = True

    End Sub

    ' Guardar el producto seleccionado para operar con él
    Private Sub DataGridViewInventario_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewInventario.SelectionChanged
        If DataGridViewInventario.SelectedRows.Count > 0 Then
            Dim rowIndex = DataGridViewInventario.SelectedRows(0).Index
            Dim dt = CType(DataGridViewInventario.DataSource, DataTable)
            If rowIndex >= 0 AndAlso rowIndex < dt.Rows.Count Then
                productoSeleccionado = dt.Rows(rowIndex)
            End If
        End If
    End Sub

    ' Permitir edición con doble clic
    Private Sub DataGridViewInventario_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInventario.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            DataGridViewInventario.BeginEdit(True)
        End If
    End Sub

    ' Capturar Enter para guardar el cambio
    Private Sub DataGridViewInventario_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridViewInventario.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub DataGridViewInventario_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInventario.CellEndEdit

        ' Tomar la fila actual
        Dim fila = DataGridViewInventario.CurrentRow

        ' Finalizar edición de la celda
        DataGridViewInventario.EndEdit()

        If fila IsNot Nothing Then
            ' Obtener valores de la fila
            Dim idProducto = Convert.ToInt32(fila.Cells("ID").Value)
            Dim descripcion = fila.Cells("Descripción").Value.ToString()
            Dim precioVenta = Convert.ToDouble(fila.Cells("Precio_Unitario").Value)
            Dim precioCosto = Convert.ToDouble(fila.Cells("Precio_Costo").Value)

            ' Calcular ganancia y actualizar celda
            Dim ganancia = precioVenta - precioCosto
            fila.Cells("Ganancia").Value = ganancia

            ' Guardar cambios en la base de datos
            logica.ActualizarProducto(idProducto, descripcion, precioVenta, precioCosto)
        End If


        Dim fil As Integer = e.RowIndex
        Dim col As Integer = e.ColumnIndex

        ' Validar que los índices sean correctos
        If fil < 0 OrElse fil >= DataGridViewInventario.Rows.Count Then Exit Sub
        If col < 0 OrElse col >= DataGridViewInventario.Columns.Count Then Exit Sub

        ' Usamos BeginInvoke para evitar la reentrancia
        Me.BeginInvoke(New Action(Sub()
                                      ' Validar de nuevo dentro del Invoke
                                      If fil < DataGridViewInventario.Rows.Count AndAlso col < DataGridViewInventario.Columns.Count Then
                                          If col < 3 And col > 0 Then ' si no es la última columna editable
                                              Dim celdaDestino As DataGridViewCell = DataGridViewInventario.Rows(fil).Cells(col + 1)
                                              If celdaDestino IsNot Nothing Then
                                                  DataGridViewInventario.CurrentCell = celdaDestino
                                                  DataGridViewInventario.BeginEdit(True)
                                              End If
                                          Else
                                              ' Última columna -> sacar foco
                                              DataGridViewInventario.CurrentCell = Nothing
                                          End If
                                      End If
                                  End Sub))

    End Sub

    Private Sub ButtonAgregar_Click(sender As Object, e As EventArgs) Handles ButtonAgregar.Click

        Dim origen = "BotonAgregar"
        Dim mensaje = "¿Confirmar Nuevo Producto?"
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
            Dim newId As Integer = logica.InsertarProductoVacio()

            ' Agregar la fila al DataTable
            Dim dt = CType(DataGridViewInventario.DataSource, DataTable)
            Dim nuevaFila As DataRow = dt.NewRow()
            nuevaFila("ID") = newId
            nuevaFila("Descripción") = ""
            nuevaFila("Precio_Unitario") = 0
            nuevaFila("Precio_Costo") = 0
            nuevaFila("Ganancia") = 0
            dt.Rows.Add(nuevaFila)

            ' Seleccionar y editar directamente la nueva fila
            DataGridViewInventario.CurrentCell =
            DataGridViewInventario.Rows(DataGridViewInventario.Rows.Count - 1).Cells("Descripción")
            DataGridViewInventario.BeginEdit(True)

            Dim ultimaFila As Integer = DataGridViewInventario.Rows.Count - 1
            DataGridViewInventario.CurrentCell = DataGridViewInventario.Rows(ultimaFila).Cells(1)
            DataGridViewInventario.BeginEdit(True)

        End If
    End Sub

    Private Sub ButtonEliminar_Click(sender As Object, e As EventArgs) Handles ButtonEliminar.Click

        If DataGridViewInventario.CurrentRow IsNot Nothing Then
            Dim origen = "BotonEliminar"
            Dim mensaje = "¿Seguro Que Desea Eliminar El Producto?"
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
                Dim idProducto As Integer = Convert.ToInt32(DataGridViewInventario.CurrentRow.Cells("ID").Value)

                ' Eliminar en la base
                logica.EliminarProducto(idProducto)

                ' Eliminar en la tabla vinculada al DGV
                Dim dt = CType(DataGridViewInventario.DataSource, DataTable)
                dt.Rows.RemoveAt(DataGridViewInventario.CurrentRow.Index)
            End If
        End If
    End Sub
End Class