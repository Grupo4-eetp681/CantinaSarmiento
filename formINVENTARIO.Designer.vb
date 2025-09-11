<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formINVENTARIO
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
        Dim PanelInventarioContenedor As Panel
        PanelContenedorDataGridInventario = New Panel()
        DataGridViewInventario = New DataGridView()
        PanelInferior = New Panel()
        PanelButtons = New Panel()
        ButtonEliminar = New Button()
        ButtonAgregar = New Button()
        PanelInventarioContenedor = New Panel()
        PanelInventarioContenedor.SuspendLayout()
        PanelContenedorDataGridInventario.SuspendLayout()
        CType(DataGridViewInventario, ComponentModel.ISupportInitialize).BeginInit()
        PanelInferior.SuspendLayout()
        PanelButtons.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelInventarioContenedor
        ' 
        PanelInventarioContenedor.Controls.Add(PanelContenedorDataGridInventario)
        PanelInventarioContenedor.Controls.Add(PanelInferior)
        PanelInventarioContenedor.Dock = DockStyle.Fill
        PanelInventarioContenedor.Location = New Point(0, 0)
        PanelInventarioContenedor.Name = "PanelInventarioContenedor"
        PanelInventarioContenedor.Size = New Size(800, 450)
        PanelInventarioContenedor.TabIndex = 0
        ' 
        ' PanelContenedorDataGridInventario
        ' 
        PanelContenedorDataGridInventario.Controls.Add(DataGridViewInventario)
        PanelContenedorDataGridInventario.Dock = DockStyle.Fill
        PanelContenedorDataGridInventario.Location = New Point(0, 0)
        PanelContenedorDataGridInventario.Name = "PanelContenedorDataGridInventario"
        PanelContenedorDataGridInventario.Size = New Size(800, 350)
        PanelContenedorDataGridInventario.TabIndex = 0
        ' 
        ' DataGridViewInventario
        ' 
        DataGridViewInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewInventario.Location = New Point(0, 0)
        DataGridViewInventario.Name = "DataGridViewInventario"
        DataGridViewInventario.Size = New Size(800, 350)
        DataGridViewInventario.TabIndex = 0
        ' 
        ' PanelInferior
        ' 
        PanelInferior.Controls.Add(PanelButtons)
        PanelInferior.Dock = DockStyle.Bottom
        PanelInferior.Location = New Point(0, 350)
        PanelInferior.Name = "PanelInferior"
        PanelInferior.Size = New Size(800, 100)
        PanelInferior.TabIndex = 0
        ' 
        ' PanelButtons
        ' 
        PanelButtons.Anchor = AnchorStyles.None
        PanelButtons.Controls.Add(ButtonEliminar)
        PanelButtons.Controls.Add(ButtonAgregar)
        PanelButtons.Location = New Point(265, 33)
        PanelButtons.Name = "PanelButtons"
        PanelButtons.Size = New Size(270, 35)
        PanelButtons.TabIndex = 2
        ' 
        ' ButtonEliminar
        ' 
        ButtonEliminar.BackColor = Color.FromArgb(CByte(255), CByte(203), CByte(0))
        ButtonEliminar.FlatStyle = FlatStyle.Flat
        ButtonEliminar.Font = New Font("Candara", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonEliminar.Location = New Point(0, 0)
        ButtonEliminar.Name = "ButtonEliminar"
        ButtonEliminar.Size = New Size(110, 35)
        ButtonEliminar.TabIndex = 1
        ButtonEliminar.Text = "ELIMINAR"
        ButtonEliminar.UseVisualStyleBackColor = False
        ' 
        ' ButtonAgregar
        ' 
        ButtonAgregar.BackColor = Color.FromArgb(CByte(255), CByte(203), CByte(0))
        ButtonAgregar.FlatStyle = FlatStyle.Flat
        ButtonAgregar.Font = New Font("Candara", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonAgregar.Location = New Point(160, 0)
        ButtonAgregar.Name = "ButtonAgregar"
        ButtonAgregar.Size = New Size(110, 35)
        ButtonAgregar.TabIndex = 0
        ButtonAgregar.Text = "AGREGAR"
        ButtonAgregar.UseVisualStyleBackColor = False
        ' 
        ' formINVENTARIO
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(800, 450)
        Controls.Add(PanelInventarioContenedor)
        FormBorderStyle = FormBorderStyle.None
        Name = "formINVENTARIO"
        Text = "formINVENTARIO"
        PanelInventarioContenedor.ResumeLayout(False)
        PanelContenedorDataGridInventario.ResumeLayout(False)
        CType(DataGridViewInventario, ComponentModel.ISupportInitialize).EndInit()
        PanelInferior.ResumeLayout(False)
        PanelButtons.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelInventarioContenedor As Panel
    Friend WithEvents PanelContenedorDataGridInventario As Panel
    Friend WithEvents DataGridViewInventario As DataGridView
    Friend WithEvents PanelInferior As Panel
    Friend WithEvents ButtonAgregar As Button
    Friend WithEvents ButtonEliminar As Button
    Friend WithEvents PanelButtons As Panel
End Class
