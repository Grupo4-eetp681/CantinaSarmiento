Public Class CAJA
    Dim logica As New LogicaCantina
    Dim plata As New Int128

    Private Sub CAJA_shown(sender As Object, e As EventArgs) Handles Me.Shown
        PanelDERECHO.Width = PanelFormulario.Width * 0.3
    End Sub
    Private Sub CAJA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        logica.cargarSubdivision(Form1.subdivision)

        plata = logica.obtenerPlata()
        LabelINICIO.Text = "Plata: $" & plata.ToString()
        DataGridViewCAJA.DataSource = logica.obtenerVentas()

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

    End Sub
End Class