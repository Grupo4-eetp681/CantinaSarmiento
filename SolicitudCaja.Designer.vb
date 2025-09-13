<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SolicitudCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SolicitudCaja))
        PanelContenedorRetiro = New Panel()
        ButtonCancelar = New Button()
        ButtonAceptar = New Button()
        TextBoxPlata = New TextBox()
        LabelTitulo = New Label()
        PanelContenedorRetiro.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelContenedorRetiro
        ' 
        PanelContenedorRetiro.BackColor = SystemColors.ControlDark
        PanelContenedorRetiro.Controls.Add(ButtonCancelar)
        PanelContenedorRetiro.Controls.Add(ButtonAceptar)
        PanelContenedorRetiro.Controls.Add(TextBoxPlata)
        PanelContenedorRetiro.Controls.Add(LabelTitulo)
        PanelContenedorRetiro.Location = New Point(2, 2)
        PanelContenedorRetiro.Name = "PanelContenedorRetiro"
        PanelContenedorRetiro.Size = New Size(300, 150)
        PanelContenedorRetiro.TabIndex = 1
        ' 
        ' ButtonCancelar
        ' 
        ButtonCancelar.BackColor = Color.Gold
        ButtonCancelar.FlatStyle = FlatStyle.Flat
        ButtonCancelar.Font = New Font("Candara", 12F, FontStyle.Bold)
        ButtonCancelar.Location = New Point(170, 110)
        ButtonCancelar.Name = "ButtonCancelar"
        ButtonCancelar.Size = New Size(95, 35)
        ButtonCancelar.TabIndex = 3
        ButtonCancelar.Text = "CANCELAR"
        ButtonCancelar.UseVisualStyleBackColor = False
        ' 
        ' ButtonAceptar
        ' 
        ButtonAceptar.BackColor = Color.Gold
        ButtonAceptar.FlatStyle = FlatStyle.Flat
        ButtonAceptar.Font = New Font("Candara", 12F, FontStyle.Bold)
        ButtonAceptar.Location = New Point(35, 110)
        ButtonAceptar.Name = "ButtonAceptar"
        ButtonAceptar.Size = New Size(95, 35)
        ButtonAceptar.TabIndex = 2
        ButtonAceptar.Text = "ACEPTAR"
        ButtonAceptar.UseVisualStyleBackColor = False
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
        LabelTitulo.Location = New Point(43, 9)
        LabelTitulo.Name = "LabelTitulo"
        LabelTitulo.Size = New Size(215, 48)
        LabelTitulo.TabIndex = 0
        LabelTitulo.Text = "INGRESE EL VALOR INICIAL DE CAJA"
        LabelTitulo.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' SolicitudCaja
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Gold
        ClientSize = New Size(304, 154)
        Controls.Add(PanelContenedorRetiro)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "SolicitudCaja"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SolicitudCaja"
        PanelContenedorRetiro.ResumeLayout(False)
        PanelContenedorRetiro.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelContenedorRetiro As Panel
    Friend WithEvents ButtonCancelar As Button
    Friend WithEvents ButtonAceptar As Button
    Friend WithEvents TextBoxPlata As TextBox
    Friend WithEvents LabelTitulo As Label
End Class
