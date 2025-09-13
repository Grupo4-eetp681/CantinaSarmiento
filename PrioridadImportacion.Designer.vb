<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrioridadImportacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrioridadImportacion))
        PanelContenedorRetiro = New Panel()
        ButtonDestino = New Button()
        ButtonOrigen = New Button()
        LabelTitulo = New Label()
        PanelContenedorRetiro.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelContenedorRetiro
        ' 
        PanelContenedorRetiro.BackColor = SystemColors.ControlDark
        PanelContenedorRetiro.Controls.Add(ButtonDestino)
        PanelContenedorRetiro.Controls.Add(ButtonOrigen)
        PanelContenedorRetiro.Controls.Add(LabelTitulo)
        PanelContenedorRetiro.Location = New Point(2, 2)
        PanelContenedorRetiro.Name = "PanelContenedorRetiro"
        PanelContenedorRetiro.Size = New Size(300, 150)
        PanelContenedorRetiro.TabIndex = 1
        ' 
        ' ButtonDestino
        ' 
        ButtonDestino.BackColor = Color.Gold
        ButtonDestino.FlatStyle = FlatStyle.Flat
        ButtonDestino.Font = New Font("Candara", 12F, FontStyle.Bold)
        ButtonDestino.Location = New Point(169, 88)
        ButtonDestino.Name = "ButtonDestino"
        ButtonDestino.Size = New Size(95, 35)
        ButtonDestino.TabIndex = 3
        ButtonDestino.Text = "DESTINO"
        ButtonDestino.UseVisualStyleBackColor = False
        ' 
        ' ButtonOrigen
        ' 
        ButtonOrigen.BackColor = Color.Gold
        ButtonOrigen.FlatStyle = FlatStyle.Flat
        ButtonOrigen.Font = New Font("Candara", 12F, FontStyle.Bold)
        ButtonOrigen.Location = New Point(36, 88)
        ButtonOrigen.Name = "ButtonOrigen"
        ButtonOrigen.Size = New Size(95, 35)
        ButtonOrigen.TabIndex = 2
        ButtonOrigen.Text = "ORIGEN"
        ButtonOrigen.UseVisualStyleBackColor = False
        ' 
        ' LabelTitulo
        ' 
        LabelTitulo.Anchor = AnchorStyles.Top
        LabelTitulo.Font = New Font("Candara", 14F, FontStyle.Bold)
        LabelTitulo.Location = New Point(36, 27)
        LabelTitulo.Name = "LabelTitulo"
        LabelTitulo.Size = New Size(228, 35)
        LabelTitulo.TabIndex = 0
        LabelTitulo.Text = "ESTABLECER PRIORIDAD"
        LabelTitulo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PrioridadImportacion
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Gold
        ClientSize = New Size(304, 154)
        Controls.Add(PanelContenedorRetiro)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "PrioridadImportacion"
        StartPosition = FormStartPosition.CenterScreen
        Text = "PrioridadImportacion"
        PanelContenedorRetiro.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelContenedorRetiro As Panel
    Friend WithEvents ButtonDestino As Button
    Friend WithEvents ButtonOrigen As Button
    Friend WithEvents LabelTitulo As Label
End Class
