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
        LabelCAJA = New Label()
        LabelTotalNeto = New Label()
        LabelTotalBruto = New Label()
        PanelBotonCerrarCaja = New Panel()
        PanelLabels = New Panel()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        ButtonRetiro = New Button()
        ButtonCerrarCaja = New Button()
        PanelContenedorLabels = New Panel()
        PanelFormulario.SuspendLayout()
        PanelIZQDataGrid.SuspendLayout()
        CType(DataGridViewCAJA, ComponentModel.ISupportInitialize).BeginInit()
        PanelDERECHO.SuspendLayout()
        PanelBotonCerrarCaja.SuspendLayout()
        PanelLabels.SuspendLayout()
        PanelContenedorLabels.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelFormulario
        ' 
        PanelFormulario.Controls.Add(PanelDERECHO)
        PanelFormulario.Controls.Add(PanelIZQDataGrid)
        PanelFormulario.Dock = DockStyle.Fill
        PanelFormulario.Location = New Point(0, 0)
        PanelFormulario.Name = "PanelFormulario"
        PanelFormulario.Size = New Size(800, 450)
        PanelFormulario.TabIndex = 0
        ' 
        ' PanelIZQDataGrid
        ' 
        PanelIZQDataGrid.Controls.Add(DataGridViewCAJA)
        PanelIZQDataGrid.Dock = DockStyle.Left
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
        PanelDERECHO.Controls.Add(PanelContenedorLabels)
        PanelDERECHO.Controls.Add(PanelBotonCerrarCaja)
        PanelDERECHO.Dock = DockStyle.Fill
        PanelDERECHO.Location = New Point(520, 0)
        PanelDERECHO.Name = "PanelDERECHO"
        PanelDERECHO.Size = New Size(280, 450)
        PanelDERECHO.TabIndex = 1
        ' 
        ' LabelCAJA
        ' 
        LabelCAJA.AutoSize = True
        LabelCAJA.BackColor = SystemColors.ControlDark
        LabelCAJA.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        LabelCAJA.ForeColor = SystemColors.ActiveCaptionText
        LabelCAJA.Location = New Point(0, 0)
        LabelCAJA.Name = "LabelCAJA"
        LabelCAJA.Size = New Size(67, 23)
        LabelCAJA.TabIndex = 0
        LabelCAJA.Text = "INICIO:"
        ' 
        ' LabelTotalNeto
        ' 
        LabelTotalNeto.AutoSize = True
        LabelTotalNeto.BackColor = SystemColors.ControlDark
        LabelTotalNeto.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        LabelTotalNeto.ForeColor = SystemColors.ActiveCaptionText
        LabelTotalNeto.Location = New Point(144, 134)
        LabelTotalNeto.Name = "LabelTotalNeto"
        LabelTotalNeto.Size = New Size(57, 23)
        LabelTotalNeto.TabIndex = 1
        LabelTotalNeto.Text = "$ 0.00"
        ' 
        ' LabelTotalBruto
        ' 
        LabelTotalBruto.AutoSize = True
        LabelTotalBruto.BackColor = SystemColors.ControlDark
        LabelTotalBruto.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        LabelTotalBruto.ForeColor = SystemColors.ActiveCaptionText
        LabelTotalBruto.Location = New Point(144, 68)
        LabelTotalBruto.Name = "LabelTotalBruto"
        LabelTotalBruto.Size = New Size(57, 23)
        LabelTotalBruto.TabIndex = 2
        LabelTotalBruto.Text = "$ 0.00"
        ' 
        ' PanelBotonCerrarCaja
        ' 
        PanelBotonCerrarCaja.Controls.Add(ButtonCerrarCaja)
        PanelBotonCerrarCaja.Controls.Add(ButtonRetiro)
        PanelBotonCerrarCaja.Dock = DockStyle.Bottom
        PanelBotonCerrarCaja.Location = New Point(0, 350)
        PanelBotonCerrarCaja.Name = "PanelBotonCerrarCaja"
        PanelBotonCerrarCaja.Size = New Size(280, 100)
        PanelBotonCerrarCaja.TabIndex = 3
        ' 
        ' PanelLabels
        ' 
        PanelLabels.Anchor = AnchorStyles.None
        PanelLabels.Controls.Add(Label1)
        PanelLabels.Controls.Add(Label2)
        PanelLabels.Controls.Add(Label3)
        PanelLabels.Controls.Add(LabelTotalBruto)
        PanelLabels.Controls.Add(LabelCAJA)
        PanelLabels.Controls.Add(LabelTotalNeto)
        PanelLabels.Location = New Point(40, 97)
        PanelLabels.Name = "PanelLabels"
        PanelLabels.Size = New Size(201, 157)
        PanelLabels.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = SystemColors.ControlDark
        Label1.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.ActiveCaptionText
        Label1.Location = New Point(0, 68)
        Label1.Name = "Label1"
        Label1.Size = New Size(85, 23)
        Label1.TabIndex = 5
        Label1.Text = "VENTAS: "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = SystemColors.ControlDark
        Label2.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        Label2.ForeColor = SystemColors.ActiveCaptionText
        Label2.Location = New Point(144, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(57, 23)
        Label2.TabIndex = 3
        Label2.Text = "$ 0.00"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = SystemColors.ControlDark
        Label3.Font = New Font("Candara", 14.25F, FontStyle.Bold)
        Label3.ForeColor = SystemColors.ActiveCaptionText
        Label3.Location = New Point(0, 134)
        Label3.Name = "Label3"
        Label3.Size = New Size(116, 23)
        Label3.TabIndex = 4
        Label3.Text = "TOTAL CAJA:"
        ' 
        ' ButtonRetiro
        ' 
        ButtonRetiro.BackColor = Color.FromArgb(CByte(255), CByte(203), CByte(0))
        ButtonRetiro.FlatStyle = FlatStyle.Flat
        ButtonRetiro.ForeColor = SystemColors.ActiveCaptionText
        ButtonRetiro.Location = New Point(62, 39)
        ButtonRetiro.Name = "ButtonRetiro"
        ButtonRetiro.Size = New Size(75, 23)
        ButtonRetiro.TabIndex = 0
        ButtonRetiro.Text = "RETIRO "
        ButtonRetiro.UseVisualStyleBackColor = False
        ' 
        ' ButtonCerrarCaja
        ' 
        ButtonCerrarCaja.BackColor = Color.FromArgb(CByte(255), CByte(203), CByte(0))
        ButtonCerrarCaja.FlatStyle = FlatStyle.Flat
        ButtonCerrarCaja.ForeColor = SystemColors.ActiveCaptionText
        ButtonCerrarCaja.Location = New Point(143, 39)
        ButtonCerrarCaja.Name = "ButtonCerrarCaja"
        ButtonCerrarCaja.Size = New Size(75, 23)
        ButtonCerrarCaja.TabIndex = 1
        ButtonCerrarCaja.Text = "CERRAR"
        ButtonCerrarCaja.UseVisualStyleBackColor = False
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
        PanelBotonCerrarCaja.ResumeLayout(False)
        PanelLabels.ResumeLayout(False)
        PanelLabels.PerformLayout()
        PanelContenedorLabels.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelFormulario As Panel
    Friend WithEvents PanelDERECHO As Panel
    Friend WithEvents PanelIZQDataGrid As Panel
    Friend WithEvents DataGridViewCAJA As DataGridView
    Friend WithEvents LabelTotalBruto As Label
    Friend WithEvents LabelTotalNeto As Label
    Friend WithEvents LabelCAJA As Label
    Friend WithEvents PanelLabels As Panel
    Friend WithEvents PanelBotonCerrarCaja As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonCerrarCaja As Button
    Friend WithEvents ButtonRetiro As Button
    Friend WithEvents PanelContenedorLabels As Panel
End Class
