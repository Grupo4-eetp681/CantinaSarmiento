<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ventas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ventas))
        PanelVentas = New Panel()
        PanelContenedorDER = New Panel()
        PanelContenedorVentas = New Panel()
        PanelDataVentas = New Panel()
        PanelTotales = New Panel()
        PanelTotal = New Panel()
        LabelTotal = New Label()
        LabelPrecioTotal = New Label()
        PanelContenedorIZQ = New Panel()
        PanelDataGrid = New Panel()
        DataGridView1 = New DataGridView()
        PanelContenedorBusqueda = New Panel()
        PanelBusqueda = New Panel()
        Busqueda = New TextBox()
        PictureBox1 = New PictureBox()
        PanelVentas.SuspendLayout()
        PanelContenedorDER.SuspendLayout()
        PanelContenedorVentas.SuspendLayout()
        PanelTotales.SuspendLayout()
        PanelTotal.SuspendLayout()
        PanelContenedorIZQ.SuspendLayout()
        PanelDataGrid.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        PanelContenedorBusqueda.SuspendLayout()
        PanelBusqueda.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PanelVentas
        ' 
        PanelVentas.Controls.Add(PanelContenedorDER)
        PanelVentas.Controls.Add(PanelContenedorIZQ)
        PanelVentas.Dock = DockStyle.Fill
        PanelVentas.Location = New Point(0, 0)
        PanelVentas.Name = "PanelVentas"
        PanelVentas.Size = New Size(800, 450)
        PanelVentas.TabIndex = 0
        ' 
        ' PanelContenedorDER
        ' 
        PanelContenedorDER.BackColor = SystemColors.ControlDark
        PanelContenedorDER.Controls.Add(PanelContenedorVentas)
        PanelContenedorDER.Controls.Add(PanelTotales)
        PanelContenedorDER.Dock = DockStyle.Fill
        PanelContenedorDER.Location = New Point(550, 0)
        PanelContenedorDER.Name = "PanelContenedorDER"
        PanelContenedorDER.Size = New Size(250, 450)
        PanelContenedorDER.TabIndex = 5
        ' 
        ' PanelContenedorVentas
        ' 
        PanelContenedorVentas.Controls.Add(PanelDataVentas)
        PanelContenedorVentas.Dock = DockStyle.Fill
        PanelContenedorVentas.Location = New Point(0, 50)
        PanelContenedorVentas.Name = "PanelContenedorVentas"
        PanelContenedorVentas.Size = New Size(250, 400)
        PanelContenedorVentas.TabIndex = 4
        ' 
        ' PanelDataVentas
        ' 
        PanelDataVentas.BackColor = SystemColors.MenuHighlight
        PanelDataVentas.Location = New Point(25, 25)
        PanelDataVentas.Name = "PanelDataVentas"
        PanelDataVentas.Size = New Size(200, 200)
        PanelDataVentas.TabIndex = 5
        ' 
        ' PanelTotales
        ' 
        PanelTotales.BackColor = Color.FromArgb(CByte(217), CByte(217), CByte(217))
        PanelTotales.Controls.Add(PanelTotal)
        PanelTotales.Dock = DockStyle.Top
        PanelTotales.Location = New Point(0, 0)
        PanelTotales.Name = "PanelTotales"
        PanelTotales.Size = New Size(250, 50)
        PanelTotales.TabIndex = 3
        ' 
        ' PanelTotal
        ' 
        PanelTotal.Anchor = AnchorStyles.None
        PanelTotal.Controls.Add(LabelTotal)
        PanelTotal.Controls.Add(LabelPrecioTotal)
        PanelTotal.Location = New Point(55, 14)
        PanelTotal.Name = "PanelTotal"
        PanelTotal.Size = New Size(140, 23)
        PanelTotal.TabIndex = 4
        ' 
        ' LabelTotal
        ' 
        LabelTotal.Font = New Font("Candara", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelTotal.Location = New Point(0, 0)
        LabelTotal.Name = "LabelTotal"
        LabelTotal.Size = New Size(78, 23)
        LabelTotal.TabIndex = 1
        LabelTotal.Text = "TOTAL:"
        ' 
        ' LabelPrecioTotal
        ' 
        LabelPrecioTotal.AutoSize = True
        LabelPrecioTotal.Font = New Font("Candara Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelPrecioTotal.Location = New Point(84, 0)
        LabelPrecioTotal.Name = "LabelPrecioTotal"
        LabelPrecioTotal.Size = New Size(56, 23)
        LabelPrecioTotal.TabIndex = 2
        LabelPrecioTotal.Text = "$0.00"
        ' 
        ' PanelContenedorIZQ
        ' 
        PanelContenedorIZQ.Controls.Add(PanelDataGrid)
        PanelContenedorIZQ.Controls.Add(PanelContenedorBusqueda)
        PanelContenedorIZQ.Dock = DockStyle.Left
        PanelContenedorIZQ.Location = New Point(0, 0)
        PanelContenedorIZQ.Name = "PanelContenedorIZQ"
        PanelContenedorIZQ.Size = New Size(550, 450)
        PanelContenedorIZQ.TabIndex = 4
        ' 
        ' PanelDataGrid
        ' 
        PanelDataGrid.Controls.Add(DataGridView1)
        PanelDataGrid.Dock = DockStyle.Fill
        PanelDataGrid.Location = New Point(0, 50)
        PanelDataGrid.Name = "PanelDataGrid"
        PanelDataGrid.Size = New Size(550, 400)
        PanelDataGrid.TabIndex = 0
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BorderStyle = BorderStyle.None
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(550, 400)
        DataGridView1.TabIndex = 0
        ' 
        ' PanelContenedorBusqueda
        ' 
        PanelContenedorBusqueda.BackColor = Color.FromArgb(CByte(217), CByte(217), CByte(217))
        PanelContenedorBusqueda.Controls.Add(PanelBusqueda)
        PanelContenedorBusqueda.Dock = DockStyle.Top
        PanelContenedorBusqueda.Location = New Point(0, 0)
        PanelContenedorBusqueda.Name = "PanelContenedorBusqueda"
        PanelContenedorBusqueda.Size = New Size(550, 50)
        PanelContenedorBusqueda.TabIndex = 1
        ' 
        ' PanelBusqueda
        ' 
        PanelBusqueda.Anchor = AnchorStyles.None
        PanelBusqueda.Controls.Add(Busqueda)
        PanelBusqueda.Controls.Add(PictureBox1)
        PanelBusqueda.Location = New Point(155, 10)
        PanelBusqueda.Name = "PanelBusqueda"
        PanelBusqueda.Size = New Size(240, 30)
        PanelBusqueda.TabIndex = 2
        ' 
        ' Busqueda
        ' 
        Busqueda.Location = New Point(40, 0)
        Busqueda.Multiline = True
        Busqueda.Name = "Busqueda"
        Busqueda.Size = New Size(200, 30)
        Busqueda.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(30, 30)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' ventas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveBorder
        ClientSize = New Size(800, 450)
        Controls.Add(PanelVentas)
        FormBorderStyle = FormBorderStyle.None
        Name = "ventas"
        Text = "ventas"
        PanelVentas.ResumeLayout(False)
        PanelContenedorDER.ResumeLayout(False)
        PanelContenedorVentas.ResumeLayout(False)
        PanelTotales.ResumeLayout(False)
        PanelTotal.ResumeLayout(False)
        PanelTotal.PerformLayout()
        PanelContenedorIZQ.ResumeLayout(False)
        PanelDataGrid.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        PanelContenedorBusqueda.ResumeLayout(False)
        PanelBusqueda.ResumeLayout(False)
        PanelBusqueda.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelVentas As Panel
    Friend WithEvents PanelDataGrid As Panel
    Friend WithEvents LabelPrecioTotal As Label
    Friend WithEvents LabelTotal As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PanelTotales As Panel
    Friend WithEvents PanelContenedorIZQ As Panel
    Friend WithEvents PanelContenedorBusqueda As Panel
    Friend WithEvents PanelContenedorDER As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Busqueda As TextBox
    Friend WithEvents PanelBusqueda As Panel
    Friend WithEvents PanelTotal As Panel
    Friend WithEvents PanelContenedorVentas As Panel
    Friend WithEvents PanelDataVentas As Panel
End Class
