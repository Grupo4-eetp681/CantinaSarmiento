Public Class CAJA
    Dim logica As New LogicaCantina
    Dim plata As New Int128
    Public retiro As Int128

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

    Private Sub actualizarCaja()
        Dim valores = logica.obtenerCaja()
        Dim inicio = valores.Inicio
        Dim retiros = valores.Retiros
        Dim ventas = valores.Ventas
        Dim total = valores.Total
        LabelNUMInicio.Text = "$ " + inicio.ToString()
        LabelNUMRetiro.Text = "$ " + retiros.ToString()
        LabelNUMVentas.Text = "$ " + ventas.ToString()
        LabelNUMCaja.Text = "$ " + total.ToString()
        DataGridViewCAJA.DataSource = logica.obtenerVentas()
    End Sub

    Private Sub CAJA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        logica.cargarSubdivision(Form1.subdivision)

        actualizarCaja()

        With DataGridViewCAJA
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

    End Sub

    Private Sub ButtonRetiro_Click(sender As Object, e As EventArgs) Handles ButtonRetiro.Click
        FormRetiro.ShowDialog()
        actualizarCaja()
    End Sub

    Private Sub AjustarLabelsEnPanel()
        ' Arrays de labels por fila
        Dim labelsIzq As Label() = {LabelINICIO, LabelVentas, LabelRetiro, LabelCAJA}
        Dim labelsDer As Label() = {LabelNUMInicio, LabelNUMVentas, LabelNUMRetiro, LabelNUMCaja}

        Dim filas As Integer = labelsIzq.Length
        Dim labelHeight As Integer = PanelLabels.Height \ filas
        Dim labelWidthIzq As Integer = PanelLabels.Width \ 2
        Dim labelWidthDer As Integer = PanelLabels.Width - labelWidthIzq

        For i As Integer = 0 To filas - 1
            ' Izquierda
            labelsIzq(i).Width = labelWidthIzq
            labelsIzq(i).Height = labelHeight
            labelsIzq(i).Left = 0
            labelsIzq(i).Top = i * labelHeight
            labelsIzq(i).TextAlign = ContentAlignment.MiddleLeft

            ' Derecha
            labelsDer(i).Width = labelWidthDer
            labelsDer(i).Height = labelHeight
            labelsDer(i).Left = labelWidthIzq
            labelsDer(i).Top = i * labelHeight
            labelsDer(i).TextAlign = ContentAlignment.MiddleRight
        Next
    End Sub
End Class