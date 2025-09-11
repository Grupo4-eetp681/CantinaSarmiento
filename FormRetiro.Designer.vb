<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRetiro
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
        PanelContenedorRetiro = New Panel()
        Button2 = New Button()
        Button1 = New Button()
        TextBoxPlata = New TextBox()
        LabelTitulo = New Label()
        PanelContenedorRetiro.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelContenedorRetiro
        ' 
        PanelContenedorRetiro.BackColor = SystemColors.ControlDark
        PanelContenedorRetiro.Controls.Add(Button2)
        PanelContenedorRetiro.Controls.Add(Button1)
        PanelContenedorRetiro.Controls.Add(TextBoxPlata)
        PanelContenedorRetiro.Controls.Add(LabelTitulo)
        PanelContenedorRetiro.Location = New Point(2, 2)
        PanelContenedorRetiro.Name = "PanelContenedorRetiro"
        PanelContenedorRetiro.Size = New Size(300, 150)
        PanelContenedorRetiro.TabIndex = 0
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.Gold
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Candara", 12F, FontStyle.Bold)
        Button2.Location = New Point(170, 110)
        Button2.Name = "Button2"
        Button2.Size = New Size(95, 35)
        Button2.TabIndex = 3
        Button2.Text = "CANCELAR"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Gold
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Candara", 12F, FontStyle.Bold)
        Button1.Location = New Point(35, 110)
        Button1.Name = "Button1"
        Button1.Size = New Size(95, 35)
        Button1.TabIndex = 2
        Button1.Text = "ACEPTAR"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' TextBoxPlata
        ' 
        TextBoxPlata.Font = New Font("Candara", 14F, FontStyle.Bold)
        TextBoxPlata.Location = New Point(35, 60)
        TextBoxPlata.Name = "TextBoxPlata"
        TextBoxPlata.Size = New Size(230, 30)
        TextBoxPlata.TabIndex = 1
        TextBoxPlata.Text = "$"
        ' 
        ' LabelTitulo
        ' 
        LabelTitulo.Anchor = AnchorStyles.Top
        LabelTitulo.Font = New Font("Candara", 14F, FontStyle.Bold)
        LabelTitulo.Location = New Point(36, 7)
        LabelTitulo.Name = "LabelTitulo"
        LabelTitulo.Size = New Size(228, 35)
        LabelTitulo.TabIndex = 0
        LabelTitulo.Text = "¿CUANTO DESEA RETIRAR?"
        LabelTitulo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' FormRetiro
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDarkDark
        ClientSize = New Size(304, 154)
        Controls.Add(PanelContenedorRetiro)
        FormBorderStyle = FormBorderStyle.None
        Name = "FormRetiro"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormRetiro"
        PanelContenedorRetiro.ResumeLayout(False)
        PanelContenedorRetiro.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelContenedorRetiro As Panel
    Friend WithEvents LabelTitulo As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBoxPlata As TextBox
    Friend WithEvents Button2 As Button
End Class
