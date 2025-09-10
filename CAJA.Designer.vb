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
        PanelFormulario = New Panel()
        PanelIZQDataGrid = New Panel()
        DataGridViewCAJA = New DataGridView()
        PanelDERECHO = New Panel()
        PanelContenedorLabels = New Panel()
        PanelLabels = New Panel()
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
        ButtonCerrarCaja = New Button()
        ButtonRetiro = New Button()
        PanelFormulario.SuspendLayout()
        PanelIZQDataGrid.SuspendLayout()
        CType(DataGridViewCAJA, ComponentModel.ISupportInitialize).BeginInit()
        PanelDERECHO.SuspendLayout()
        PanelContenedorLabels.SuspendLayout()
        PanelLabels.SuspendLayout()
        PanelBotonCerrarCaja.SuspendLayout()
        Panel1.SuspendLayout()
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
        DataGridViewCAJA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCAJA.Dock = DockStyle.Fill
        DataGridViewCAJA.Location = New Point(0, 0)
        DataGridViewCAJA.Name = "DataGridViewCAJA"
        DataGridViewCAJA.Size = New Size(520, 450)
        DataGridViewCAJA.TabIndex = 0
        ' 
        ' PanelDERECHO
        ' 
        PanelDERECHO.BackColor = Color.Transparent
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
        PanelContenedorLabels.Size = New Size(280, 350)
        PanelContenedorLabels.TabIndex = 5
        ' 
        ' PanelLabels
        ' 
        PanelLabels.Anchor = AnchorStyles.None
        PanelLabels.Controls.Add(LabelRetiro)
        PanelLabels.Controls.Add(LabelNUMRetiro)
        PanelLabels.Controls.Add(LabelVentas)
        PanelLabels.Controls.Add(LabelNUMInicio)
        PanelLabels.Controls.Add(LabelCAJA)
        PanelLabels.Controls.Add(LabelNUMVentas)
        PanelLabels.Controls.Add(LabelINICIO)
        PanelLabels.Controls.Add(LabelNUMCaja)
        PanelLabels.Location = New Point(40, 50)
        PanelLabels.Name = "PanelLabels"
        PanelLabels.Size = New Size(200, 250)
        PanelLabels.TabIndex = 4
        ' 
        ' LabelRetiro
        ' 
        LabelRetiro.BackColor = SystemColors.ControlDark
        LabelRetiro.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        LabelRetiro.ForeColor = SystemColors.ActiveCaptionText
        LabelRetiro.Location = New Point(0, 150)
        LabelRetiro.Name = "LabelRetiro"
        LabelRetiro.Size = New Size(85, 25)
        LabelRetiro.TabIndex = 7
        LabelRetiro.Text = "RETIROS: "
        ' 
        ' LabelNUMRetiro
        ' 
        LabelNUMRetiro.BackColor = SystemColors.ControlDark
        LabelNUMRetiro.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        LabelNUMRetiro.ForeColor = SystemColors.ActiveCaptionText
        LabelNUMRetiro.Location = New Point(140, 150)
        LabelNUMRetiro.Name = "LabelNUMRetiro"
        LabelNUMRetiro.Size = New Size(60, 25)
        LabelNUMRetiro.TabIndex = 6
        LabelNUMRetiro.Text = "$ 0.00"
        ' 
        ' LabelVentas
        ' 
        LabelVentas.BackColor = SystemColors.ControlDark
        LabelVentas.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        LabelVentas.ForeColor = SystemColors.ActiveCaptionText
        LabelVentas.Location = New Point(0, 75)
        LabelVentas.Name = "LabelVentas"
        LabelVentas.Size = New Size(85, 25)
        LabelVentas.TabIndex = 5
        LabelVentas.Text = "VENTAS: "
        ' 
        ' LabelNUMInicio
        ' 
        LabelNUMInicio.BackColor = SystemColors.ControlDark
        LabelNUMInicio.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        LabelNUMInicio.ForeColor = SystemColors.ActiveCaptionText
        LabelNUMInicio.Location = New Point(140, 0)
        LabelNUMInicio.Name = "LabelNUMInicio"
        LabelNUMInicio.Size = New Size(60, 25)
        LabelNUMInicio.TabIndex = 3
        LabelNUMInicio.Text = "$ 0.00"
        ' 
        ' LabelCAJA
        ' 
        LabelCAJA.BackColor = SystemColors.ControlDark
        LabelCAJA.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        LabelCAJA.ForeColor = SystemColors.ActiveCaptionText
        LabelCAJA.Location = New Point(0, 225)
        LabelCAJA.Name = "LabelCAJA"
        LabelCAJA.Size = New Size(120, 25)
        LabelCAJA.TabIndex = 4
        LabelCAJA.Text = "TOTAL CAJA:"
        ' 
        ' LabelNUMVentas
        ' 
        LabelNUMVentas.BackColor = SystemColors.ControlDark
        LabelNUMVentas.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        LabelNUMVentas.ForeColor = SystemColors.ActiveCaptionText
        LabelNUMVentas.Location = New Point(140, 75)
        LabelNUMVentas.Name = "LabelNUMVentas"
        LabelNUMVentas.Size = New Size(60, 25)
        LabelNUMVentas.TabIndex = 2
        LabelNUMVentas.Text = "$ 0.00"
        ' 
        ' LabelINICIO
        ' 
        LabelINICIO.BackColor = SystemColors.ControlDark
        LabelINICIO.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        LabelINICIO.ForeColor = SystemColors.ActiveCaptionText
        LabelINICIO.Location = New Point(0, 0)
        LabelINICIO.Name = "LabelINICIO"
        LabelINICIO.Size = New Size(70, 25)
        LabelINICIO.TabIndex = 0
        LabelINICIO.Text = "INICIO:"
        ' 
        ' LabelNUMCaja
        ' 
        LabelNUMCaja.BackColor = SystemColors.ControlDark
        LabelNUMCaja.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        LabelNUMCaja.ForeColor = SystemColors.ActiveCaptionText
        LabelNUMCaja.Location = New Point(140, 225)
        LabelNUMCaja.Name = "LabelNUMCaja"
        LabelNUMCaja.Size = New Size(60, 25)
        LabelNUMCaja.TabIndex = 1
        LabelNUMCaja.Text = "$ 0.00"
        ' 
        ' PanelBotonCerrarCaja
        ' 
        PanelBotonCerrarCaja.Controls.Add(Panel1)
        PanelBotonCerrarCaja.Dock = DockStyle.Bottom
        PanelBotonCerrarCaja.Location = New Point(0, 350)
        PanelBotonCerrarCaja.Name = "PanelBotonCerrarCaja"
        PanelBotonCerrarCaja.Size = New Size(280, 100)
        PanelBotonCerrarCaja.TabIndex = 3
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.Controls.Add(ButtonCerrarCaja)
        Panel1.Controls.Add(ButtonRetiro)
        Panel1.Location = New Point(30, 25)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(220, 50)
        Panel1.TabIndex = 5
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
        ' CAJA
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(800, 450)
        Controls.Add(PanelFormulario)
        ForeColor = SystemColors.ControlDark
        FormBorderStyle = FormBorderStyle.None
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
End Class
