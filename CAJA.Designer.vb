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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CAJA))
        PanelFormulario = New Panel()
        PanelIZQDataGrid = New Panel()
        DataGridViewCAJA = New DataGridView()
        PanelDERECHO = New Panel()
        PanelContenedorLabels = New Panel()
        PanelLabels = New Panel()
        PanelBorde3 = New Panel()
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
        DataGridViewCAJA.BorderStyle = BorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Candara Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridViewCAJA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCAJA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Candara Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlDark
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        DataGridViewCAJA.DefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCAJA.Dock = DockStyle.Fill
        DataGridViewCAJA.Location = New Point(0, 0)
        DataGridViewCAJA.Name = "DataGridViewCAJA"
        DataGridViewCAJA.Size = New Size(520, 450)
        DataGridViewCAJA.TabIndex = 0
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
        PanelLabels.Controls.Add(PanelBorde3)
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
        PanelLabels.Location = New Point(55, 49)
        PanelLabels.Name = "PanelLabels"
        PanelLabels.Size = New Size(201, 250)
        PanelLabels.TabIndex = 4
        ' 
        ' PanelBorde3
        ' 
        PanelBorde3.BackColor = Color.Gold
        PanelBorde3.Location = New Point(0, 191)
        PanelBorde3.Name = "PanelBorde3"
        PanelBorde3.Size = New Size(201, 3)
        PanelBorde3.TabIndex = 10
        ' 
        ' PanelBorde2
        ' 
        PanelBorde2.BackColor = Color.Gold
        PanelBorde2.Location = New Point(3, 124)
        PanelBorde2.Name = "PanelBorde2"
        PanelBorde2.Size = New Size(200, 1)
        PanelBorde2.TabIndex = 9
        ' 
        ' PanelBorde1
        ' 
        PanelBorde1.BackColor = Color.Gold
        PanelBorde1.Location = New Point(0, 48)
        PanelBorde1.Name = "PanelBorde1"
        PanelBorde1.Size = New Size(200, 1)
        PanelBorde1.TabIndex = 8
        ' 
        ' LabelRetiro
        ' 
        LabelRetiro.BackColor = SystemColors.ControlDark
        LabelRetiro.Font = New Font("Candara", 16F, FontStyle.Bold)
        LabelRetiro.ForeColor = SystemColors.ActiveCaptionText
        LabelRetiro.Location = New Point(0, 150)
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
        LabelNUMRetiro.Location = New Point(130, 150)
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
        LabelNUMInicio.Location = New Point(130, 0)
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
        LabelCAJA.Location = New Point(0, 225)
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
        LabelNUMVentas.Location = New Point(130, 75)
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
        LabelNUMCaja.Location = New Point(130, 225)
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
    Friend WithEvents DataGridViewCAJA As DataGridView
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
    Friend WithEvents PanelBorde3 As Panel
End Class
