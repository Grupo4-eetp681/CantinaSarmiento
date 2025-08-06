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

        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.RowHeadersVisible = False


    End Sub

    Private Sub ventas_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim altura As Integer = PanelContenedorVentas.Height
        Dim ancho As Integer = PanelContenedorVentas.Width

        PanelDataVentas.Height = altura / 2
        PanelDataVentas.Width = ancho - 50
        PanelDataVentas.Location = New Point(25, 25)
        PanelDataVentas.BringToFront()
    End Sub
End Class