<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Advertencia
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
        CheckBoxNoMostrar = New CheckBox()
        LabelMensaje = New Label()
        BtnAceptar = New Button()
        BtnCancelar = New Button()
        SuspendLayout()
        ' 
        ' CheckBoxNoMostrar
        ' 
        CheckBoxNoMostrar.AutoSize = True
        CheckBoxNoMostrar.Font = New Font("Candara", 11F, FontStyle.Bold)
        CheckBoxNoMostrar.Location = New Point(12, 94)
        CheckBoxNoMostrar.Name = "CheckBoxNoMostrar"
        CheckBoxNoMostrar.Size = New Size(258, 22)
        CheckBoxNoMostrar.TabIndex = 0
        CheckBoxNoMostrar.Text = "No volver a mostrar esta advertencia"
        CheckBoxNoMostrar.UseVisualStyleBackColor = True
        ' 
        ' LabelMensaje
        ' 
        LabelMensaje.Font = New Font("Candara", 11F, FontStyle.Bold)
        LabelMensaje.Location = New Point(12, 9)
        LabelMensaje.Name = "LabelMensaje"
        LabelMensaje.Size = New Size(258, 38)
        LabelMensaje.TabIndex = 1
        LabelMensaje.Text = "Label1"
        LabelMensaje.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' BtnAceptar
        ' 
        BtnAceptar.BackColor = SystemColors.ControlDark
        BtnAceptar.FlatStyle = FlatStyle.Flat
        BtnAceptar.Font = New Font("Candara", 10F, FontStyle.Bold)
        BtnAceptar.Location = New Point(12, 53)
        BtnAceptar.Name = "BtnAceptar"
        BtnAceptar.Size = New Size(80, 35)
        BtnAceptar.TabIndex = 2
        BtnAceptar.Text = "Aceptar"
        BtnAceptar.UseVisualStyleBackColor = False
        ' 
        ' BtnCancelar
        ' 
        BtnCancelar.BackColor = SystemColors.ControlDark
        BtnCancelar.FlatStyle = FlatStyle.Flat
        BtnCancelar.Font = New Font("Candara", 10F, FontStyle.Bold)
        BtnCancelar.Location = New Point(190, 53)
        BtnCancelar.Name = "BtnCancelar"
        BtnCancelar.Size = New Size(80, 35)
        BtnCancelar.TabIndex = 3
        BtnCancelar.Text = "Cancelar"
        BtnCancelar.UseVisualStyleBackColor = False
        ' 
        ' Advertencia
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDarkDark
        ClientSize = New Size(282, 125)
        Controls.Add(BtnCancelar)
        Controls.Add(BtnAceptar)
        Controls.Add(LabelMensaje)
        Controls.Add(CheckBoxNoMostrar)
        FormBorderStyle = FormBorderStyle.None
        Name = "Advertencia"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Advertencia"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents CheckBoxNoMostrar As CheckBox
    Friend WithEvents LabelMensaje As Label
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents BtnCancelar As Button
End Class
