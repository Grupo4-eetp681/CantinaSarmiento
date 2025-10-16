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
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ventas))
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        PanelVentas = New Panel()
        PanelContenedorDER = New Panel()
        PanelContenedorVentas = New Panel()
        PanelDerechaINFVueltoYPago = New Panel()
        PanelPago = New Panel()
        PanelCentrarPago = New Panel()
        TXTPago = New TextBox()
        LabelPago = New Label()
        PanelVuelto = New Panel()
        PanelCentrarVuelto = New Panel()
        LabelNUMVuelto = New Label()
        LabelVuelto = New Label()
        Panel10PX2 = New Panel()
        PanelDataVentas = New Panel()
        DataGridVentas = New DataGridView()
        PanelTransferencia = New Panel()
        CheckBoxTransferencia = New CheckBox()
        Panel10PX3 = New Panel()
        PanelDerechaINFButton = New Panel()
        PanelContenedorButtonVentas = New Panel()
        PanelLabel = New Panel()
        LabelMensage = New Label()
        BotonTicket = New Button()
        BotonFactura = New Button()
        BotonRegistro = New Button()
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
        Panel10PX = New Panel()
        TimerMensage = New Timer(components)
        ToolTip = New ToolTip(components)
        PanelVentas.SuspendLayout()
        PanelContenedorDER.SuspendLayout()
        PanelContenedorVentas.SuspendLayout()
        PanelDerechaINFVueltoYPago.SuspendLayout()
        PanelPago.SuspendLayout()
        PanelCentrarPago.SuspendLayout()
        PanelVuelto.SuspendLayout()
        PanelCentrarVuelto.SuspendLayout()
        PanelDataVentas.SuspendLayout()
        CType(DataGridVentas, ComponentModel.ISupportInitialize).BeginInit()
        PanelTransferencia.SuspendLayout()
        PanelDerechaINFButton.SuspendLayout()
        PanelContenedorButtonVentas.SuspendLayout()
        PanelLabel.SuspendLayout()
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
        PanelVentas.Controls.Add(Panel10PX)
        PanelVentas.Dock = DockStyle.Fill
        PanelVentas.Location = New Point(0, 0)
        PanelVentas.Name = "PanelVentas"
        PanelVentas.Size = New Size(1286, 688)
        PanelVentas.TabIndex = 0
        ' 
        ' PanelContenedorDER
        ' 
        PanelContenedorDER.BackColor = SystemColors.ControlDark
        PanelContenedorDER.Controls.Add(PanelContenedorVentas)
        PanelContenedorDER.Controls.Add(PanelTotales)
        PanelContenedorDER.Dock = DockStyle.Fill
        PanelContenedorDER.Location = New Point(900, 0)
        PanelContenedorDER.Name = "PanelContenedorDER"
        PanelContenedorDER.Size = New Size(386, 678)
        PanelContenedorDER.TabIndex = 5
        ' 
        ' PanelContenedorVentas
        ' 
        PanelContenedorVentas.BackColor = Color.Transparent
        PanelContenedorVentas.Controls.Add(PanelDerechaINFVueltoYPago)
        PanelContenedorVentas.Controls.Add(Panel10PX2)
        PanelContenedorVentas.Controls.Add(PanelDataVentas)
        PanelContenedorVentas.Controls.Add(PanelTransferencia)
        PanelContenedorVentas.Controls.Add(Panel10PX3)
        PanelContenedorVentas.Controls.Add(PanelDerechaINFButton)
        PanelContenedorVentas.Dock = DockStyle.Fill
        PanelContenedorVentas.Location = New Point(0, 50)
        PanelContenedorVentas.Name = "PanelContenedorVentas"
        PanelContenedorVentas.Size = New Size(386, 628)
        PanelContenedorVentas.TabIndex = 4
        ' 
        ' PanelDerechaINFVueltoYPago
        ' 
        PanelDerechaINFVueltoYPago.BackColor = Color.Transparent
        PanelDerechaINFVueltoYPago.Controls.Add(PanelPago)
        PanelDerechaINFVueltoYPago.Controls.Add(PanelVuelto)
        PanelDerechaINFVueltoYPago.Dock = DockStyle.Bottom
        PanelDerechaINFVueltoYPago.Location = New Point(0, 468)
        PanelDerechaINFVueltoYPago.Name = "PanelDerechaINFVueltoYPago"
        PanelDerechaINFVueltoYPago.Size = New Size(386, 60)
        PanelDerechaINFVueltoYPago.TabIndex = 7
        ' 
        ' PanelPago
        ' 
        PanelPago.Controls.Add(PanelCentrarPago)
        PanelPago.Dock = DockStyle.Fill
        PanelPago.Location = New Point(0, 0)
        PanelPago.Name = "PanelPago"
        PanelPago.Size = New Size(386, 30)
        PanelPago.TabIndex = 5
        ' 
        ' PanelCentrarPago
        ' 
        PanelCentrarPago.Anchor = AnchorStyles.None
        PanelCentrarPago.Controls.Add(TXTPago)
        PanelCentrarPago.Controls.Add(LabelPago)
        PanelCentrarPago.Location = New Point(68, 0)
        PanelCentrarPago.Name = "PanelCentrarPago"
        PanelCentrarPago.Size = New Size(235, 30)
        PanelCentrarPago.TabIndex = 8
        ' 
        ' TXTPago
        ' 
        TXTPago.Font = New Font("Candara Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TXTPago.Location = New Point(85, 2)
        TXTPago.Name = "TXTPago"
        TXTPago.Size = New Size(150, 27)
        TXTPago.TabIndex = 2
        TXTPago.Text = "$ "
        ' 
        ' LabelPago
        ' 
        LabelPago.Font = New Font("Candara", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelPago.Location = New Point(0, 3)
        LabelPago.Name = "LabelPago"
        LabelPago.Size = New Size(70, 25)
        LabelPago.TabIndex = 3
        LabelPago.Text = "PAGO:"
        ' 
        ' PanelVuelto
        ' 
        PanelVuelto.Controls.Add(PanelCentrarVuelto)
        PanelVuelto.Dock = DockStyle.Bottom
        PanelVuelto.Location = New Point(0, 30)
        PanelVuelto.Name = "PanelVuelto"
        PanelVuelto.Size = New Size(386, 30)
        PanelVuelto.TabIndex = 4
        ' 
        ' PanelCentrarVuelto
        ' 
        PanelCentrarVuelto.Anchor = AnchorStyles.None
        PanelCentrarVuelto.BackColor = Color.Transparent
        PanelCentrarVuelto.Controls.Add(LabelNUMVuelto)
        PanelCentrarVuelto.Controls.Add(LabelVuelto)
        PanelCentrarVuelto.Location = New Point(68, 0)
        PanelCentrarVuelto.Name = "PanelCentrarVuelto"
        PanelCentrarVuelto.Size = New Size(235, 30)
        PanelCentrarVuelto.TabIndex = 9
        ' 
        ' LabelNUMVuelto
        ' 
        LabelNUMVuelto.AutoSize = True
        LabelNUMVuelto.Dock = DockStyle.Right
        LabelNUMVuelto.Font = New Font("Candara", 15.75F, FontStyle.Bold)
        LabelNUMVuelto.Location = New Point(176, 0)
        LabelNUMVuelto.Name = "LabelNUMVuelto"
        LabelNUMVuelto.Size = New Size(59, 26)
        LabelNUMVuelto.TabIndex = 2
        LabelNUMVuelto.Text = "$0.00"
        LabelNUMVuelto.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' LabelVuelto
        ' 
        LabelVuelto.Font = New Font("Candara", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelVuelto.Location = New Point(0, 3)
        LabelVuelto.Name = "LabelVuelto"
        LabelVuelto.Size = New Size(90, 25)
        LabelVuelto.TabIndex = 1
        LabelVuelto.Text = "VUELTO:"
        ' 
        ' Panel10PX2
        ' 
        Panel10PX2.Dock = DockStyle.Bottom
        Panel10PX2.Location = New Point(0, 528)
        Panel10PX2.Name = "Panel10PX2"
        Panel10PX2.Size = New Size(386, 10)
        Panel10PX2.TabIndex = 7
        ' 
        ' PanelDataVentas
        ' 
        PanelDataVentas.BackColor = Color.Transparent
        PanelDataVentas.Controls.Add(DataGridVentas)
        PanelDataVentas.Location = New Point(25, 25)
        PanelDataVentas.Name = "PanelDataVentas"
        PanelDataVentas.Size = New Size(200, 200)
        PanelDataVentas.TabIndex = 5
        ' 
        ' DataGridVentas
        ' 
        DataGridVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = SystemColors.Window
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle1.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.False
        DataGridVentas.DefaultCellStyle = DataGridViewCellStyle1
        DataGridVentas.Dock = DockStyle.Fill
        DataGridVentas.Location = New Point(0, 0)
        DataGridVentas.Name = "DataGridVentas"
        DataGridVentas.Size = New Size(200, 200)
        DataGridVentas.TabIndex = 5
        ' 
        ' PanelTransferencia
        ' 
        PanelTransferencia.Controls.Add(CheckBoxTransferencia)
        PanelTransferencia.Dock = DockStyle.Bottom
        PanelTransferencia.Location = New Point(0, 538)
        PanelTransferencia.Name = "PanelTransferencia"
        PanelTransferencia.Size = New Size(386, 40)
        PanelTransferencia.TabIndex = 8
        ' 
        ' CheckBoxTransferencia
        ' 
        CheckBoxTransferencia.Anchor = AnchorStyles.None
        CheckBoxTransferencia.Font = New Font("Candara", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        CheckBoxTransferencia.Location = New Point(98, 5)
        CheckBoxTransferencia.Name = "CheckBoxTransferencia"
        CheckBoxTransferencia.Size = New Size(190, 30)
        CheckBoxTransferencia.TabIndex = 0
        CheckBoxTransferencia.Text = "TRANSFERENCIA?"
        CheckBoxTransferencia.UseVisualStyleBackColor = True
        ' 
        ' Panel10PX3
        ' 
        Panel10PX3.Dock = DockStyle.Bottom
        Panel10PX3.Location = New Point(0, 578)
        Panel10PX3.Name = "Panel10PX3"
        Panel10PX3.Size = New Size(386, 10)
        Panel10PX3.TabIndex = 9
        ' 
        ' PanelDerechaINFButton
        ' 
        PanelDerechaINFButton.BackColor = Color.Transparent
        PanelDerechaINFButton.Controls.Add(PanelContenedorButtonVentas)
        PanelDerechaINFButton.Dock = DockStyle.Bottom
        PanelDerechaINFButton.Location = New Point(0, 588)
        PanelDerechaINFButton.Name = "PanelDerechaINFButton"
        PanelDerechaINFButton.Size = New Size(386, 40)
        PanelDerechaINFButton.TabIndex = 6
        ' 
        ' PanelContenedorButtonVentas
        ' 
        PanelContenedorButtonVentas.Anchor = AnchorStyles.None
        PanelContenedorButtonVentas.Controls.Add(PanelLabel)
        PanelContenedorButtonVentas.Controls.Add(BotonTicket)
        PanelContenedorButtonVentas.Controls.Add(BotonFactura)
        PanelContenedorButtonVentas.Controls.Add(BotonRegistro)
        PanelContenedorButtonVentas.Location = New Point(73, 0)
        PanelContenedorButtonVentas.Name = "PanelContenedorButtonVentas"
        PanelContenedorButtonVentas.Size = New Size(240, 40)
        PanelContenedorButtonVentas.TabIndex = 7
        ' 
        ' PanelLabel
        ' 
        PanelLabel.Controls.Add(LabelMensage)
        PanelLabel.Dock = DockStyle.Fill
        PanelLabel.Location = New Point(0, 0)
        PanelLabel.Name = "PanelLabel"
        PanelLabel.Size = New Size(240, 40)
        PanelLabel.TabIndex = 8
        PanelLabel.Visible = False
        ' 
        ' LabelMensage
        ' 
        LabelMensage.BackColor = Color.Gold
        LabelMensage.Dock = DockStyle.Fill
        LabelMensage.Font = New Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelMensage.Location = New Point(0, 0)
        LabelMensage.Name = "LabelMensage"
        LabelMensage.Size = New Size(240, 40)
        LabelMensage.TabIndex = 0
        LabelMensage.Text = "Label1"
        LabelMensage.Visible = False
        ' 
        ' BotonTicket
        ' 
        BotonTicket.BackColor = Color.Transparent
        BotonTicket.BackgroundImage = CType(resources.GetObject("BotonTicket.BackgroundImage"), Image)
        BotonTicket.BackgroundImageLayout = ImageLayout.Stretch
        BotonTicket.FlatStyle = FlatStyle.Popup
        BotonTicket.ForeColor = Color.Transparent
        BotonTicket.Location = New Point(200, 0)
        BotonTicket.Name = "BotonTicket"
        BotonTicket.Size = New Size(40, 40)
        BotonTicket.TabIndex = 5
        ToolTip.SetToolTip(BotonTicket, "Generar Tickets")
        BotonTicket.UseVisualStyleBackColor = False
        ' 
        ' BotonFactura
        ' 
        BotonFactura.BackColor = Color.Transparent
        BotonFactura.BackgroundImage = CType(resources.GetObject("BotonFactura.BackgroundImage"), Image)
        BotonFactura.BackgroundImageLayout = ImageLayout.Stretch
        BotonFactura.FlatStyle = FlatStyle.Popup
        BotonFactura.ForeColor = Color.FromArgb(CByte(217), CByte(217), CByte(217))
        BotonFactura.Location = New Point(100, 0)
        BotonFactura.Name = "BotonFactura"
        BotonFactura.Size = New Size(40, 40)
        BotonFactura.TabIndex = 4
        ToolTip.SetToolTip(BotonFactura, "Generar Factura")
        BotonFactura.UseVisualStyleBackColor = False
        ' 
        ' BotonRegistro
        ' 
        BotonRegistro.BackColor = Color.Transparent
        BotonRegistro.BackgroundImage = CType(resources.GetObject("BotonRegistro.BackgroundImage"), Image)
        BotonRegistro.BackgroundImageLayout = ImageLayout.Stretch
        BotonRegistro.FlatStyle = FlatStyle.Popup
        BotonRegistro.ForeColor = Color.Transparent
        BotonRegistro.Location = New Point(0, 0)
        BotonRegistro.Name = "BotonRegistro"
        BotonRegistro.Size = New Size(40, 40)
        BotonRegistro.TabIndex = 3
        ToolTip.SetToolTip(BotonRegistro, "Registrar Venta")
        BotonRegistro.UseVisualStyleBackColor = False
        ' 
        ' PanelTotales
        ' 
        PanelTotales.BackColor = Color.FromArgb(CByte(217), CByte(217), CByte(217))
        PanelTotales.Controls.Add(PanelTotal)
        PanelTotales.Dock = DockStyle.Top
        PanelTotales.Location = New Point(0, 0)
        PanelTotales.Name = "PanelTotales"
        PanelTotales.Size = New Size(386, 50)
        PanelTotales.TabIndex = 3
        ' 
        ' PanelTotal
        ' 
        PanelTotal.Anchor = AnchorStyles.None
        PanelTotal.Controls.Add(LabelTotal)
        PanelTotal.Controls.Add(LabelPrecioTotal)
        PanelTotal.Location = New Point(73, 14)
        PanelTotal.Name = "PanelTotal"
        PanelTotal.Size = New Size(240, 23)
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
        LabelPrecioTotal.Font = New Font("Candara", 15.75F, FontStyle.Bold)
        LabelPrecioTotal.Location = New Point(184, -2)
        LabelPrecioTotal.Name = "LabelPrecioTotal"
        LabelPrecioTotal.Size = New Size(59, 26)
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
        PanelContenedorIZQ.Size = New Size(900, 678)
        PanelContenedorIZQ.TabIndex = 4
        ' 
        ' PanelDataGrid
        ' 
        PanelDataGrid.Controls.Add(DataGridView1)
        PanelDataGrid.Dock = DockStyle.Fill
        PanelDataGrid.Location = New Point(0, 50)
        PanelDataGrid.Name = "PanelDataGrid"
        PanelDataGrid.Size = New Size(900, 628)
        PanelDataGrid.TabIndex = 0
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(0), CByte(123), CByte(255))
        DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = SystemColors.Control
        DataGridViewCellStyle3.Font = New Font("Candara", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = Color.Transparent
        DataGridViewCellStyle3.SelectionForeColor = Color.White
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = SystemColors.Window
        DataGridViewCellStyle4.Font = New Font("Candara", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle4.Padding = New Padding(0, 0, 0, 5)
        DataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(CByte(0), CByte(123), CByte(255))
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.False
        DataGridView1.DefaultCellStyle = DataGridViewCellStyle4
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = SystemColors.Control
        DataGridViewCellStyle5.Font = New Font("Candara", 12F)
        DataGridViewCellStyle5.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        DataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        DataGridView1.RowHeadersVisible = False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(900, 628)
        DataGridView1.TabIndex = 1
        ' 
        ' PanelContenedorBusqueda
        ' 
        PanelContenedorBusqueda.BackColor = Color.FromArgb(CByte(217), CByte(217), CByte(217))
        PanelContenedorBusqueda.Controls.Add(PanelBusqueda)
        PanelContenedorBusqueda.Dock = DockStyle.Top
        PanelContenedorBusqueda.Location = New Point(0, 0)
        PanelContenedorBusqueda.Name = "PanelContenedorBusqueda"
        PanelContenedorBusqueda.Size = New Size(900, 50)
        PanelContenedorBusqueda.TabIndex = 1
        ' 
        ' PanelBusqueda
        ' 
        PanelBusqueda.Anchor = AnchorStyles.None
        PanelBusqueda.Controls.Add(Busqueda)
        PanelBusqueda.Controls.Add(PictureBox1)
        PanelBusqueda.Location = New Point(330, 10)
        PanelBusqueda.Name = "PanelBusqueda"
        PanelBusqueda.Size = New Size(240, 30)
        PanelBusqueda.TabIndex = 2
        ' 
        ' Busqueda
        ' 
        Busqueda.Font = New Font("Candara", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Busqueda.Location = New Point(40, 2)
        Busqueda.Name = "Busqueda"
        Busqueda.Size = New Size(200, 27)
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
        ' Panel10PX
        ' 
        Panel10PX.BackColor = SystemColors.ControlDark
        Panel10PX.Dock = DockStyle.Bottom
        Panel10PX.Location = New Point(0, 678)
        Panel10PX.Name = "Panel10PX"
        Panel10PX.Size = New Size(1286, 10)
        Panel10PX.TabIndex = 8
        ' 
        ' TimerMensage
        ' 
        TimerMensage.Interval = 2000
        ' 
        ' ventas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveBorder
        ClientSize = New Size(1286, 688)
        Controls.Add(PanelVentas)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "ventas"
        Text = "ventas"
        PanelVentas.ResumeLayout(False)
        PanelContenedorDER.ResumeLayout(False)
        PanelContenedorVentas.ResumeLayout(False)
        PanelDerechaINFVueltoYPago.ResumeLayout(False)
        PanelPago.ResumeLayout(False)
        PanelCentrarPago.ResumeLayout(False)
        PanelCentrarPago.PerformLayout()
        PanelVuelto.ResumeLayout(False)
        PanelCentrarVuelto.ResumeLayout(False)
        PanelCentrarVuelto.PerformLayout()
        PanelDataVentas.ResumeLayout(False)
        CType(DataGridVentas, ComponentModel.ISupportInitialize).EndInit()
        PanelTransferencia.ResumeLayout(False)
        PanelDerechaINFButton.ResumeLayout(False)
        PanelContenedorButtonVentas.ResumeLayout(False)
        PanelLabel.ResumeLayout(False)
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
    Friend WithEvents PanelTotales As Panel
    Friend WithEvents PanelContenedorIZQ As Panel
    Friend WithEvents PanelContenedorBusqueda As Panel
    Friend WithEvents PanelContenedorDER As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Busqueda As TextBox
    Friend WithEvents PanelBusqueda As Panel
    Friend WithEvents PanelTotal As Panel
    Friend WithEvents PanelContenedorVentas As Panel
    Friend WithEvents PanelDerechaINFButton As Panel
    Friend WithEvents PanelContenedorButtonVentas As Panel
    Friend WithEvents BotonTicket As Button
    Friend WithEvents BotonFactura As Button
    Friend WithEvents BotonRegistro As Button
    Friend WithEvents PanelDerechaINFVueltoYPago As Panel
    Friend WithEvents LabelNUMVuelto As Label
    Friend WithEvents LabelPago As Label
    Friend WithEvents LabelVuelto As Label
    Friend WithEvents TXTPago As TextBox
    Friend WithEvents Panel10PX As Panel
    Friend WithEvents PanelCentrarPago As Panel
    Friend WithEvents PanelPago As Panel
    Friend WithEvents PanelVuelto As Panel
    Friend WithEvents PanelCentrarVuelto As Panel
    Friend WithEvents Panel10PX2 As Panel
    Friend WithEvents PanelLabel As Panel
    Friend WithEvents LabelMensage As Label
    Friend WithEvents TimerMensage As Timer
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents PanelDataVentas As Panel
    Friend WithEvents DataGridVentas As DataGridView
    Friend WithEvents PanelTransferencia As Panel
    Friend WithEvents CheckBoxTransferencia As CheckBox
    Friend WithEvents Panel10PX3 As Panel
End Class
