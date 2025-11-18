Public Class CAJA
    ' variables globales
    Dim logica As New LogicaCantina
    Dim plata As New Int128
    Public retiro As Int128
    ' Funcion para hacer responsive el formulario
    Private Sub responsive()
        PanelDERECHO.Width = PanelFormulario.Width * 0.3

        ' Ajustar PanelLabels al 80% del contenedor
        PanelLabels.Width = PanelContenedorLabels.Width * 0.8
        PanelLabels.Height = PanelContenedorLabels.Height * 0.8

        ' Centrar PanelLabels dentro do contenedor
        PanelLabels.Left = (PanelContenedorLabels.Width - PanelLabels.Width) \ 2
        PanelLabels.Top = (PanelContenedorLabels.Height - PanelLabels.Height) \ 2

        AjustarLabelsEnPanel()

    End Sub

    Private Sub CAJA_shown(sender As Object, e As EventArgs) Handles Me.Shown
        PanelDERECHO.Width = PanelFormulario.Width * 0.3

        ' Ajustar PanelLabels al 80% del contenedor
        PanelLabels.Width = PanelContenedorLabels.Width * 0.8
        PanelLabels.Height = PanelContenedorLabels.Height * 0.8

        ' Centrar PanelLabels dentro do contenedor
        PanelLabels.Left = (PanelContenedorLabels.Width - PanelLabels.Width) \ 2
        PanelLabels.Top = (PanelContenedorLabels.Height - PanelLabels.Height) \ 2

        AjustarLabelsEnPanel()
    End Sub

    ' Actualizar los valores de la caja
    Public Sub actualizarCaja()
        Dim valores = logica.obtenerCaja()
        LabelNUMInicio.Text = "$ " & valores.Inicio.ToString("N0", New Globalization.CultureInfo("es-AR")).Replace(" ", "")
        LabelNUMRetiro.Text = "$ " & valores.Retiros.ToString("N0", New Globalization.CultureInfo("es-AR")).Replace(" ", "")
        LabelNUMVentas.Text = "$ " & valores.Ventas.ToString("N0", New Globalization.CultureInfo("es-AR")).Replace(" ", "")
        LabelNUMTransferencia.Text = "$ " & valores.Transferencias.ToString("N0", New Globalization.CultureInfo("es-AR")).Replace(" ", "")
        LabelNUMCaja.Text = "$ " & valores.Total.ToString("N0", New Globalization.CultureInfo("es-AR")).Replace(" ", "")
        DataGridViewCAJA.DataSource = logica.obtenerVentas() 'consulta que se ejecuta en la variable logica, la cual trae todas las ventas realizadas
    End Sub

    Private Sub CAJA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        logica.cargarSubdivision(Form1.subdivision)

        actualizarCaja()

        PanelMensage.Visible = False
        LabelMensage.Visible = False

        ' Configurar DataGridViewCAJA
        With DataGridViewCAJA
            .Dock = DockStyle.Fill ' Ocupa todo el espacio del contenedor
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill ' Las columnas ocupan todo el ancho disponible
            .RowHeadersVisible = False ' Oculta la columna de encabezado de filas
            .AllowUserToAddRows = False ' No permite agregar filas manualmente
            .AllowUserToResizeColumns = False ' No permite redimensionar columnas
            .AllowUserToResizeRows = False ' No permite redimensionar filas
            .AllowUserToOrderColumns = False ' No permite reordenar columnas
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect ' Selección de fila completa
            .MultiSelect = False ' No permite selección múltiple
            .ReadOnly = True ' Solo lectura
            .BackColor = Color.LightGray ' Color de fondo claro
            .ForeColor = Color.Black ' Color de texto
            .CurrentCell = Nothing ' No selecciona ninguna celda al cargar
            .DefaultCellStyle.SelectionBackColor = .DefaultCellStyle.BackColor ' Desactiva el resaltado de selección
            .DefaultCellStyle.SelectionForeColor = .DefaultCellStyle.ForeColor ' Desactiva el resaltado de selección
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ' Centra el texto en las celdas

            ' Opcional: desactiva la edición de celdas (aunque .ReadOnly ya lo hace)
            .EditMode = DataGridViewEditMode.EditProgrammatically
        End With

    End Sub

    ' Botón Retiro
    Private Sub ButtonRetiro_Click(sender As Object, e As EventArgs) Handles ButtonRetiro.Click
        FormRetiro.ShowDialog() ' Mostrar el formulario de retiro como diálogo modal
        actualizarCaja()
    End Sub

    ' Ajustar los labels dentro del panel
    Private Sub AjustarLabelsEnPanel()
        ' listas de labels y paneles
        Dim labelsIzq As Label() = {LabelINICIO, LabelVentas, LabelTransferencia, LabelRetiro, LabelCAJA}
        Dim labelsDer As Label() = {LabelNUMInicio, LabelNUMVentas, LabelNUMTransferencia, LabelNUMRetiro, LabelNUMCaja}
        Dim panelesBorde As Panel() = {PanelBorde1, PanelBorde2, PanelBorde3, PanelBorde4}

        ' Calcular dimensiones
        Dim filas As Integer = labelsIzq.Length
        Dim labelHeight As Integer = PanelLabels.Height \ filas
        Dim labelWidthIzq As Integer = PanelLabels.Width \ 2
        Dim labelWidthDer As Integer = PanelLabels.Width - labelWidthIzq

        ' Acomodar labels
        For i As Integer = 0 To filas - 1
            labelsIzq(i).Width = labelWidthIzq
            labelsIzq(i).Height = labelHeight
            labelsIzq(i).Left = 0
            labelsIzq(i).Top = i * labelHeight
            labelsIzq(i).TextAlign = ContentAlignment.MiddleLeft

            labelsDer(i).Width = labelWidthDer
            labelsDer(i).Height = labelHeight
            labelsDer(i).Left = labelWidthIzq
            labelsDer(i).Top = i * labelHeight
            labelsDer(i).TextAlign = ContentAlignment.MiddleRight
        Next

        ' Acomodar paneles divisores entre filas
        For i As Integer = 0 To panelesBorde.Length - 1
            panelesBorde(i).Width = PanelLabels.Width
            panelesBorde(i).Height = 3
            panelesBorde(i).Left = 0
            ' El divisor va debajo del label correspondiente
            panelesBorde(i).Top = labelsIzq(i).Top + labelHeight - (panelesBorde(i).Height \ 2)
            panelesBorde(i).BringToFront()
            panelesBorde(i).Visible = True
        Next

    End Sub

    ' Botón Cerrar Caja
    Private Sub ButtonCerrarCaja_Click(sender As Object, e As EventArgs) Handles ButtonCerrarCaja.Click

        Dim origen = "BotonCerrarCaja"
        Dim mensaje = "¿Confirmar Cierre De Caja?"
        Dim continuar As Boolean = True
        ' Mostrar advertencia si no se ha silenciado
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
        ' Proceder con el cierre de caja si se confirmó
        If continuar Then
            logica.GenerarCierreCajaPDF(DataGridViewCAJA) ' Generar el PDF del cierre de caja
            logica.CerrarCaja() ' Cerrar la caja en la lógica
            AjustarFuenteLabelMaximo(LabelMensage, "Caja Cerrada") ' Ajustar el mensaje
            mostrar_mensaje() ' Mostrar el mensaje de caja cerrada
            actualizarCaja() ' Actualizar los valores de la caja
        End If
    End Sub

    ' Ajustar la fuente del label para que el texto quepa dentro del tamaño máximo permitido
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
    
    ' Evento del temporizador para ocultar el mensaje después de un tiempo
    Private Sub TimerMensage_Tick(sender As Object, e As EventArgs) Handles TimerMensage.Tick
        PanelMensage.Visible = False
        LabelMensage.Visible = False
        ButtonCerrarCaja.Enabled = True
        ButtonRetiro.Enabled = True
        TimerMensage.Stop()
    End Sub

    ' Mostrar el mensaje de caja cerrada
    Private Sub mostrar_mensaje()
        PanelMensage.Visible = True
        LabelMensage.Visible = True
        ButtonCerrarCaja.Enabled = False
        ButtonRetiro.Enabled = False
        TimerMensage.Start()
    End Sub

    Private Sub CAJA_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        responsive()
    End Sub

End Class