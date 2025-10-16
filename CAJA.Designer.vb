<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CAJA
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
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CAJA))
        PanelFormulario = New Panel()
        PanelIZQDataGrid = New Panel()
        DataGridViewCAJA = New DataGridView()
        PanelDERECHO = New Panel()
        PanelContenedorLabels = New Panel()
        PanelLabels = New Panel()
        LabelTransferencia = New Label()
        LabelNUMTransferencia = New Label()
        PanelBorde3 = New Panel()
        PanelBorde4 = New Panel()
        PanelBorde2 = New Panel()
        PanelBorde1 = New Panel()
        LabelRetiro = New Label()
        LabelNUMRetiro = New Label()
        LabelVentas = New Label()
        LabelNUMInicio = New Label()
        LabelCAJA = New Label()
        LabelNUMVentas = New Label()
        LabelINICIO = New Label()
        LabelNUMCaja = New Label()
        PanelBotonCerrarCaja = New Panel()
        Panel1 = New Panel()
        PanelMensage = New Panel()
        LabelMensage = New Label()
        ButtonCerrarCaja = New Button()
        ButtonRetiro = New Button()
        TimerMensage = New Timer(components)
        PanelFormulario.SuspendLayout()
        PanelIZQDataGrid.SuspendLayout()
        CType(DataGridViewCAJA, ComponentModel.ISupportInitialize).BeginInit()
        PanelDERECHO.SuspendLayout()
        PanelContenedorLabels.SuspendLayout()
        PanelLabels.SuspendLayout()
        PanelBotonCerrarCaja.SuspendLayout()
        Panel1.SuspendLayout()
        PanelMensage.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelFormulario
        ' 
        PanelFormulario.Controls.Add(PanelIZQDataGrid)
        PanelFormulario.Controls.Add(PanelDERECHO)
        PanelFormulario.Dock = DockStyle.Fill
        PanelFormulario.Location = New Point(0, 0)
        PanelFormulario.Name = "PanelFormulario"
        PanelFormulario.Size = New Size(800, 450)
        PanelFormulario.TabIndex = 0
        ' 
        ' PanelIZQDataGrid
        ' 
        PanelIZQDataGrid.Controls.Add(DataGridViewCAJA)
        PanelIZQDataGrid.Dock = DockStyle.Fill
        PanelIZQDataGrid.Location = New Point(0, 0)
        PanelIZQDataGrid.Name = "PanelIZQDataGrid"
        PanelIZQDataGrid.Size = New Size(520, 450)
        PanelIZQDataGrid.TabIndex = 0
        ' 
        ' DataGridViewCAJA
        ' 
        DataGridViewCAJA.AllowUserToAddRows = False
        DataGridViewCAJA.AllowUserToDeleteRows = False
        DataGridViewCAJA.AllowUserToResizeColumns = False
        DataGridViewCAJA.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        DataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(CByte(0), CByte(123), CByte(255))
        DataGridViewCAJA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCAJA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = SystemColors.Control
        DataGridViewCellStyle6.Font = New Font("Candara", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = Color.Transparent
        DataGridViewCellStyle6.SelectionForeColor = Color.White
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        DataGridViewCAJA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        DataGridViewCAJA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = SystemColors.Window
        DataGridViewCellStyle7.Font = New Font("Candara", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle7.ForeColor = SystemColors.ControlDark
        DataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(CByte(0), CByte(123), CByte(255))
        DataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.False
        DataGridViewCAJA.DefaultCellStyle = DataGridViewCellStyle7
        DataGridViewCAJA.Dock = DockStyle.Fill
        DataGridViewCAJA.Location = New Point(0, 0)
        DataGridViewCAJA.Name = "DataGridViewCAJA"
        DataGridViewCAJA.ReadOnly = True
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = SystemColors.Control
        DataGridViewCellStyle8.Font = New Font("Candara", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle8.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        DataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.True
        DataGridViewCAJA.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        DataGridViewCAJA.RowHeadersVisible = False
        DataGridViewCAJA.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridViewCAJA.Size = New Size(520, 450)
        DataGridViewCAJA.TabIndex = 3
        ' 
        ' PanelDERECHO
        ' 
        PanelDERECHO.BackColor = Color.Transparent
        PanelDERECHO.BorderStyle = BorderStyle.FixedSingle
        PanelDERECHO.Controls.Add(PanelContenedorLabels)
        PanelDERECHO.Controls.Add(PanelBotonCerrarCaja)
        PanelDERECHO.Dock = DockStyle.Right
        PanelDERECHO.Location = New Point(520, 0)
        PanelDERECHO.Name = "PanelDERECHO"
        PanelDERECHO.Size = New Size(280, 450)
        PanelDERECHO.TabIndex = 1
        ' 
        ' PanelContenedorLabels
        ' 
        PanelContenedorLabels.Controls.Add(PanelLabels)
        PanelContenedorLabels.Dock = DockStyle.Fill
        PanelContenedorLabels.Location = New Point(0, 0)
        PanelContenedorLabels.Name = "PanelContenedorLabels"
        PanelContenedorLabels.Size = New Size(278, 348)
        PanelContenedorLabels.TabIndex = 5
        ' 
        ' PanelLabels
        ' 
        PanelLabels.Anchor = AnchorStyles.None
        PanelLabels.Controls.Add(LabelTransferencia)
        PanelLabels.Controls.Add(LabelNUMTransferencia)
        PanelLabels.Controls.Add(PanelBorde3)
        PanelLabels.Controls.Add(PanelBorde4)
        PanelLabels.Controls.Add(PanelBorde2)
        PanelLabels.Controls.Add(PanelBorde1)
        PanelLabels.Controls.Add(LabelRetiro)
        PanelLabels.Controls.Add(LabelNUMRetiro)
        PanelLabels.Controls.Add(LabelVentas)
        PanelLabels.Controls.Add(LabelNUMInicio)
        PanelLabels.Controls.Add(LabelCAJA)
        PanelLabels.Controls.Add(LabelNUMVentas)
        PanelLabels.Controls.Add(LabelINICIO)
        PanelLabels.Controls.Add(LabelNUMCaja)
        PanelLabels.Location = New Point(20, 12)
        PanelLabels.Name = "PanelLabels"
        PanelLabels.Size = New Size(250, 325)
        PanelLabels.TabIndex = 4
        ' 
        ' LabelTransferencia
        ' 
        LabelTransferencia.BackColor = SystemColors.ControlDark
        LabelTransferencia.Font = New Font("Candara", 16F, FontStyle.Bold)
        LabelTransferencia.ForeColor = SystemColors.ActiveCaptionText
        LabelTransferencia.Location = New Point(0, 150)
        LabelTransferencia.Name = "LabelTransferencia"
        LabelTransferencia.Size = New Size(177, 25)
        LabelTransferencia.TabIndex = 13
        LabelTransferencia.Text = "TRANSFERENCIA"
        ' 
        ' LabelNUMTransferencia
        ' 
        LabelNUMTransferencia.BackColor = SystemColors.ControlDark
        LabelNUMTransferencia.Font = New Font("Candara", 16F, FontStyle.Bold)
        LabelNUMTransferencia.ForeColor = SystemColors.ActiveCaptionText
        LabelNUMTransferencia.Location = New Point(180, 150)
        LabelNUMTransferencia.Name = "LabelNUMTransferencia"
        LabelNUMTransferencia.Size = New Size(70, 25)
        LabelNUMTransferencia.TabIndex = 12
        LabelNUMTransferencia.Text = "$ 0.00"
        LabelNUMTransferencia.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' PanelBorde3
        ' 
        PanelBorde3.BackColor = Color.Gold
        PanelBorde3.Location = New Point(0, 200)
        PanelBorde3.Name = "PanelBorde3"
        PanelBorde3.Size = New Size(250, 3)
        PanelBorde3.TabIndex = 11
        ' 
        ' PanelBorde4
        ' 
        PanelBorde4.BackColor = Color.Gold
        PanelBorde4.Location = New Point(0, 276)
        PanelBorde4.Name = "PanelBorde4"
        PanelBorde4.Size = New Size(250, 3)
        PanelBorde4.TabIndex = 10
        ' 
        ' PanelBorde2
        ' 
        PanelBorde2.BackColor = Color.Gold
        PanelBorde2.Location = New Point(0, 124)
        PanelBorde2.Name = "PanelBorde2"
        PanelBorde2.Size = New Size(250, 3)
        PanelBorde2.TabIndex = 9
        ' 
        ' PanelBorde1
        ' 
        PanelBorde1.BackColor = Color.Gold
        PanelBorde1.Location = New Point(0, 48)
        PanelBorde1.Name = "PanelBorde1"
        PanelBorde1.Size = New Size(250, 3)
        PanelBorde1.TabIndex = 8
        ' 
        ' LabelRetiro
        ' 
        LabelRetiro.BackColor = SystemColors.ControlDark
        LabelRetiro.Font = New Font("Candara", 16F, FontStyle.Bold)
        LabelRetiro.ForeColor = SystemColors.ActiveCaptionText
        LabelRetiro.Location = New Point(0, 225)
        LabelRetiro.Name = "LabelRetiro"
        LabelRetiro.Size = New Size(109, 25)
        LabelRetiro.TabIndex = 7
        LabelRetiro.Text = "RETIROS: "
        ' 
        ' LabelNUMRetiro
        ' 
        LabelNUMRetiro.BackColor = SystemColors.ControlDark
        LabelNUMRetiro.Font = New Font("Candara", 16F, FontStyle.Bold)
        LabelNUMRetiro.ForeColor = SystemColors.ActiveCaptionText
        LabelNUMRetiro.Location = New Point(180, 225)
        LabelNUMRetiro.Name = "LabelNUMRetiro"
        LabelNUMRetiro.Size = New Size(70, 25)
        LabelNUMRetiro.TabIndex = 6
        LabelNUMRetiro.Text = "$ 0.00"
        LabelNUMRetiro.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' LabelVentas
        ' 
        LabelVentas.BackColor = SystemColors.ControlDark
        LabelVentas.Font = New Font("Candara", 16F, FontStyle.Bold)
        LabelVentas.ForeColor = SystemColors.ActiveCaptionText
        LabelVentas.Location = New Point(0, 75)
        LabelVentas.Name = "LabelVentas"
        LabelVentas.Size = New Size(100, 25)
        LabelVentas.TabIndex = 5
        LabelVentas.Text = "VENTAS: "
        ' 
        ' LabelNUMInicio
        ' 
        LabelNUMInicio.BackColor = SystemColors.ControlDark
        LabelNUMInicio.Font = New Font("Candara", 16F, FontStyle.Bold)
        LabelNUMInicio.ForeColor = SystemColors.ActiveCaptionText
        LabelNUMInicio.Location = New Point(180, 0)
        LabelNUMInicio.Name = "LabelNUMInicio"
        LabelNUMInicio.Size = New Size(70, 25)
        LabelNUMInicio.TabIndex = 3
        LabelNUMInicio.Text = "$ 0.00"
        LabelNUMInicio.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' LabelCAJA
        ' 
        LabelCAJA.BackColor = SystemColors.ControlDark
        LabelCAJA.Font = New Font("Candara", 16F, FontStyle.Bold)
        LabelCAJA.ForeColor = SystemColors.ActiveCaptionText
        LabelCAJA.Location = New Point(0, 300)
        LabelCAJA.Name = "LabelCAJA"
        LabelCAJA.Size = New Size(137, 25)
        LabelCAJA.TabIndex = 4
        LabelCAJA.Text = "TOTAL CAJA:"
        ' 
        ' LabelNUMVentas
        ' 
        LabelNUMVentas.BackColor = SystemColors.ControlDark
        LabelNUMVentas.Font = New Font("Candara", 16F, FontStyle.Bold)
        LabelNUMVentas.ForeColor = SystemColors.ActiveCaptionText
        LabelNUMVentas.Location = New Point(180, 75)
        LabelNUMVentas.Name = "LabelNUMVentas"
        LabelNUMVentas.Size = New Size(70, 25)
        LabelNUMVentas.TabIndex = 2
        LabelNUMVentas.Text = "$ 0.00"
        LabelNUMVentas.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' LabelINICIO
        ' 
        LabelINICIO.BackColor = SystemColors.ControlDark
        LabelINICIO.Font = New Font("Candara", 16F, FontStyle.Bold)
        LabelINICIO.ForeColor = SystemColors.ActiveCaptionText
        LabelINICIO.Location = New Point(0, 0)
        LabelINICIO.Name = "LabelINICIO"
        LabelINICIO.Size = New Size(85, 25)
        LabelINICIO.TabIndex = 0
        LabelINICIO.Text = "INICIO:"
        ' 
        ' LabelNUMCaja
        ' 
        LabelNUMCaja.BackColor = SystemColors.ControlDark
        LabelNUMCaja.Font = New Font("Candara", 16F, FontStyle.Bold)
        LabelNUMCaja.ForeColor = SystemColors.ActiveCaptionText
        LabelNUMCaja.Location = New Point(180, 300)
        LabelNUMCaja.Name = "LabelNUMCaja"
        LabelNUMCaja.Size = New Size(70, 25)
        LabelNUMCaja.TabIndex = 1
        LabelNUMCaja.Text = "$ 0.00"
        LabelNUMCaja.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' PanelBotonCerrarCaja
        ' 
        PanelBotonCerrarCaja.Controls.Add(Panel1)
        PanelBotonCerrarCaja.Dock = DockStyle.Bottom
        PanelBotonCerrarCaja.Location = New Point(0, 348)
        PanelBotonCerrarCaja.Name = "PanelBotonCerrarCaja"
        PanelBotonCerrarCaja.Size = New Size(278, 100)
        PanelBotonCerrarCaja.TabIndex = 3
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.Controls.Add(PanelMensage)
        Panel1.Controls.Add(ButtonCerrarCaja)
        Panel1.Controls.Add(ButtonRetiro)
        Panel1.Location = New Point(29, 25)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(220, 50)
        Panel1.TabIndex = 5
        ' 
        ' PanelMensage
        ' 
        PanelMensage.BackColor = Color.Gold
        PanelMensage.Controls.Add(LabelMensage)
        PanelMensage.Dock = DockStyle.Fill
        PanelMensage.Location = New Point(0, 0)
        PanelMensage.Name = "PanelMensage"
        PanelMensage.Size = New Size(220, 50)
        PanelMensage.TabIndex = 2
        PanelMensage.Visible = False
        ' 
        ' LabelMensage
        ' 
        LabelMensage.Dock = DockStyle.Fill
        LabelMensage.Font = New Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelMensage.ForeColor = Color.Black
        LabelMensage.Location = New Point(0, 0)
        LabelMensage.Name = "LabelMensage"
        LabelMensage.Size = New Size(220, 50)
        LabelMensage.TabIndex = 0
        LabelMensage.Text = "Label1"
        LabelMensage.TextAlign = ContentAlignment.MiddleCenter
        LabelMensage.Visible = False
        ' 
        ' ButtonCerrarCaja
        ' 
        ButtonCerrarCaja.BackColor = Color.FromArgb(CByte(255), CByte(203), CByte(0))
        ButtonCerrarCaja.FlatStyle = FlatStyle.Flat
        ButtonCerrarCaja.Font = New Font("Candara", 12F, FontStyle.Bold)
        ButtonCerrarCaja.ForeColor = SystemColors.ActiveCaptionText
        ButtonCerrarCaja.Location = New Point(120, 0)
        ButtonCerrarCaja.Name = "ButtonCerrarCaja"
        ButtonCerrarCaja.Size = New Size(100, 50)
        ButtonCerrarCaja.TabIndex = 1
        ButtonCerrarCaja.Text = "CERRAR CAJA"
        ButtonCerrarCaja.UseVisualStyleBackColor = False
        ' 
        ' ButtonRetiro
        ' 
        ButtonRetiro.BackColor = Color.FromArgb(CByte(255), CByte(203), CByte(0))
        ButtonRetiro.FlatStyle = FlatStyle.Flat
        ButtonRetiro.Font = New Font("Candara", 12F, FontStyle.Bold)
        ButtonRetiro.ForeColor = SystemColors.ActiveCaptionText
        ButtonRetiro.Location = New Point(0, 0)
        ButtonRetiro.Name = "ButtonRetiro"
        ButtonRetiro.Size = New Size(100, 50)
        ButtonRetiro.TabIndex = 0
        ButtonRetiro.Text = "RETIRAR DINERO"
        ButtonRetiro.UseVisualStyleBackColor = False
        ' 
        ' TimerMensage
        ' 
        TimerMensage.Enabled = True
        TimerMensage.Interval = 2000
        ' 
        ' CAJA
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(800, 450)
        Controls.Add(PanelFormulario)
        ForeColor = SystemColors.ControlDark
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "CAJA"
        Text = "CAJA"
        PanelFormulario.ResumeLayout(False)
        PanelIZQDataGrid.ResumeLayout(False)
        CType(DataGridViewCAJA, ComponentModel.ISupportInitialize).EndInit()
        PanelDERECHO.ResumeLayout(False)
        PanelContenedorLabels.ResumeLayout(False)
        PanelLabels.ResumeLayout(False)
        PanelBotonCerrarCaja.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        PanelMensage.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelFormulario As Panel
    Friend WithEvents PanelDERECHO As Panel
    Friend WithEvents PanelIZQDataGrid As Panel
    Friend WithEvents LabelNUMVentas As Label
    Friend WithEvents LabelNUMCaja As Label
    Friend WithEvents LabelINICIO As Label
    Friend WithEvents PanelLabels As Panel
    Friend WithEvents PanelBotonCerrarCaja As Panel
    Friend WithEvents LabelVentas As Label
    Friend WithEvents LabelNUMInicio As Label
    Friend WithEvents LabelCAJA As Label
    Friend WithEvents ButtonCerrarCaja As Button
    Friend WithEvents ButtonRetiro As Button
    Friend WithEvents PanelContenedorLabels As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelRetiro As Label
    Friend WithEvents LabelNUMRetiro As Label
    Friend WithEvents PanelMensage As Panel
    Friend WithEvents LabelMensage As Label
    Friend WithEvents TimerMensage As Timer
    Friend WithEvents PanelBorde2 As Panel
    Friend WithEvents PanelBorde1 As Panel
    Friend WithEvents PanelBorde4 As Panel
    Friend WithEvents DataGridViewCAJA As DataGridView
    Friend WithEvents LabelTransferencia As Label
    Friend WithEvents LabelNUMTransferencia As Label
    Friend WithEvents PanelBorde3 As Panel
End Class
