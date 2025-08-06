<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormularioRegister
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormularioRegister))
        PanelSuperiorLogoRegister = New Panel()
        LogoSarmientoLogin = New PictureBox()
        PanelInferiorRegister = New Panel()
        PanelInfo = New Panel()
        info = New Label()
        BotonAceptarRegister = New Button()
        BotonCancelarRegister = New Button()
        Button1 = New Button()
        PanelCentralRegister = New Panel()
        LabelRepetirContraseñaRegister = New Label()
        LabelContraseñaRegister = New Label()
        LabelSubdivisiónRegister = New Label()
        TextBoxContraseña2 = New TextBox()
        TextBoxContraseña1 = New TextBox()
        TextBoxSubdivision = New TextBox()
        Timer1 = New Timer(components)
        FondoDeColor = New Panel()
        PanelContenedor = New Panel()
        PanelSuperiorLogoRegister.SuspendLayout()
        CType(LogoSarmientoLogin, ComponentModel.ISupportInitialize).BeginInit()
        PanelInferiorRegister.SuspendLayout()
        PanelInfo.SuspendLayout()
        PanelCentralRegister.SuspendLayout()
        FondoDeColor.SuspendLayout()
        PanelContenedor.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelSuperiorLogoRegister
        ' 
        PanelSuperiorLogoRegister.BackColor = SystemColors.ControlDark
        PanelSuperiorLogoRegister.Controls.Add(LogoSarmientoLogin)
        PanelSuperiorLogoRegister.Dock = DockStyle.Top
        PanelSuperiorLogoRegister.Location = New Point(0, 0)
        PanelSuperiorLogoRegister.Name = "PanelSuperiorLogoRegister"
        PanelSuperiorLogoRegister.Size = New Size(280, 105)
        PanelSuperiorLogoRegister.TabIndex = 0
        ' 
        ' LogoSarmientoLogin
        ' 
        LogoSarmientoLogin.Anchor = AnchorStyles.None
        LogoSarmientoLogin.Image = CType(resources.GetObject("LogoSarmientoLogin.Image"), Image)
        LogoSarmientoLogin.Location = New Point(90, 5)
        LogoSarmientoLogin.Name = "LogoSarmientoLogin"
        LogoSarmientoLogin.Size = New Size(100, 100)
        LogoSarmientoLogin.SizeMode = PictureBoxSizeMode.StretchImage
        LogoSarmientoLogin.TabIndex = 8
        LogoSarmientoLogin.TabStop = False
        LogoSarmientoLogin.WaitOnLoad = True
        ' 
        ' PanelInferiorRegister
        ' 
        PanelInferiorRegister.BackColor = SystemColors.ControlDark
        PanelInferiorRegister.Controls.Add(PanelInfo)
        PanelInferiorRegister.Controls.Add(BotonAceptarRegister)
        PanelInferiorRegister.Controls.Add(BotonCancelarRegister)
        PanelInferiorRegister.Controls.Add(Button1)
        PanelInferiorRegister.Dock = DockStyle.Bottom
        PanelInferiorRegister.Location = New Point(0, 370)
        PanelInferiorRegister.Name = "PanelInferiorRegister"
        PanelInferiorRegister.Size = New Size(280, 30)
        PanelInferiorRegister.TabIndex = 1
        ' 
        ' PanelInfo
        ' 
        PanelInfo.Controls.Add(info)
        PanelInfo.Dock = DockStyle.Fill
        PanelInfo.Location = New Point(0, 0)
        PanelInfo.Name = "PanelInfo"
        PanelInfo.Size = New Size(280, 30)
        PanelInfo.TabIndex = 5
        PanelInfo.Visible = False
        ' 
        ' info
        ' 
        info.AutoSize = True
        info.Dock = DockStyle.Fill
        info.Font = New Font("Candara", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        info.ForeColor = Color.FromArgb(CByte(34), CByte(34), CByte(34))
        info.Location = New Point(0, 0)
        info.Name = "info"
        info.Size = New Size(47, 18)
        info.TabIndex = 0
        info.Text = "Label1"
        info.TextAlign = ContentAlignment.MiddleCenter
        info.Visible = False
        ' 
        ' BotonAceptarRegister
        ' 
        BotonAceptarRegister.BackColor = Color.FromArgb(CByte(255), CByte(203), CByte(0))
        BotonAceptarRegister.FlatStyle = FlatStyle.Flat
        BotonAceptarRegister.Font = New Font("Candara", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BotonAceptarRegister.ForeColor = SystemColors.ActiveCaptionText
        BotonAceptarRegister.Location = New Point(152, 0)
        BotonAceptarRegister.Name = "BotonAceptarRegister"
        BotonAceptarRegister.Size = New Size(80, 25)
        BotonAceptarRegister.TabIndex = 2
        BotonAceptarRegister.Text = "ACEPTAR"
        BotonAceptarRegister.UseVisualStyleBackColor = False
        ' 
        ' BotonCancelarRegister
        ' 
        BotonCancelarRegister.BackColor = Color.FromArgb(CByte(255), CByte(203), CByte(0))
        BotonCancelarRegister.FlatStyle = FlatStyle.Flat
        BotonCancelarRegister.Font = New Font("Candara", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BotonCancelarRegister.ForeColor = SystemColors.ActiveCaptionText
        BotonCancelarRegister.Location = New Point(50, 0)
        BotonCancelarRegister.Name = "BotonCancelarRegister"
        BotonCancelarRegister.Size = New Size(80, 25)
        BotonCancelarRegister.TabIndex = 1
        BotonCancelarRegister.Text = "CANCELAR"
        BotonCancelarRegister.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(31, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(0, 0)
        Button1.TabIndex = 0
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' PanelCentralRegister
        ' 
        PanelCentralRegister.BackColor = SystemColors.ControlDark
        PanelCentralRegister.Controls.Add(LabelRepetirContraseñaRegister)
        PanelCentralRegister.Controls.Add(LabelContraseñaRegister)
        PanelCentralRegister.Controls.Add(LabelSubdivisiónRegister)
        PanelCentralRegister.Controls.Add(TextBoxContraseña2)
        PanelCentralRegister.Controls.Add(TextBoxContraseña1)
        PanelCentralRegister.Controls.Add(TextBoxSubdivision)
        PanelCentralRegister.Dock = DockStyle.Fill
        PanelCentralRegister.Location = New Point(0, 105)
        PanelCentralRegister.Name = "PanelCentralRegister"
        PanelCentralRegister.Size = New Size(280, 265)
        PanelCentralRegister.TabIndex = 2
        ' 
        ' LabelRepetirContraseñaRegister
        ' 
        LabelRepetirContraseñaRegister.AutoSize = True
        LabelRepetirContraseñaRegister.Font = New Font("Candara", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelRepetirContraseñaRegister.ForeColor = Color.FromArgb(CByte(34), CByte(34), CByte(34))
        LabelRepetirContraseñaRegister.Location = New Point(58, 176)
        LabelRepetirContraseñaRegister.Name = "LabelRepetirContraseñaRegister"
        LabelRepetirContraseñaRegister.Size = New Size(165, 19)
        LabelRepetirContraseñaRegister.TabIndex = 5
        LabelRepetirContraseñaRegister.Text = "REPETIR CONTRASEÑA"
        ' 
        ' LabelContraseñaRegister
        ' 
        LabelContraseñaRegister.AutoSize = True
        LabelContraseñaRegister.Font = New Font("Candara", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelContraseñaRegister.ForeColor = Color.FromArgb(CByte(34), CByte(34), CByte(34))
        LabelContraseñaRegister.Location = New Point(88, 111)
        LabelContraseñaRegister.Name = "LabelContraseñaRegister"
        LabelContraseñaRegister.Size = New Size(105, 19)
        LabelContraseñaRegister.TabIndex = 4
        LabelContraseñaRegister.Text = "CONTRASEÑA"
        ' 
        ' LabelSubdivisiónRegister
        ' 
        LabelSubdivisiónRegister.AutoSize = True
        LabelSubdivisiónRegister.Font = New Font("Candara", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelSubdivisiónRegister.ForeColor = Color.FromArgb(CByte(34), CByte(34), CByte(34))
        LabelSubdivisiónRegister.Location = New Point(91, 40)
        LabelSubdivisiónRegister.Name = "LabelSubdivisiónRegister"
        LabelSubdivisiónRegister.Size = New Size(99, 19)
        LabelSubdivisiónRegister.TabIndex = 3
        LabelSubdivisiónRegister.Text = "SUBDIVISIÓN"
        ' 
        ' TextBoxContraseña2
        ' 
        TextBoxContraseña2.Location = New Point(50, 198)
        TextBoxContraseña2.Name = "TextBoxContraseña2"
        TextBoxContraseña2.Size = New Size(180, 23)
        TextBoxContraseña2.TabIndex = 2
        ' 
        ' TextBoxContraseña1
        ' 
        TextBoxContraseña1.Location = New Point(50, 133)
        TextBoxContraseña1.Name = "TextBoxContraseña1"
        TextBoxContraseña1.Size = New Size(180, 23)
        TextBoxContraseña1.TabIndex = 1
        ' 
        ' TextBoxSubdivision
        ' 
        TextBoxSubdivision.Location = New Point(50, 62)
        TextBoxSubdivision.Name = "TextBoxSubdivision"
        TextBoxSubdivision.Size = New Size(180, 23)
        TextBoxSubdivision.TabIndex = 0
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 2000
        ' 
        ' FondoDeColor
        ' 
        FondoDeColor.BackColor = Color.FromArgb(CByte(68), CByte(68), CByte(68))
        FondoDeColor.Controls.Add(PanelContenedor)
        FondoDeColor.Dock = DockStyle.Fill
        FondoDeColor.Location = New Point(0, 0)
        FondoDeColor.Name = "FondoDeColor"
        FondoDeColor.Size = New Size(286, 406)
        FondoDeColor.TabIndex = 3
        ' 
        ' PanelContenedor
        ' 
        PanelContenedor.Anchor = AnchorStyles.None
        PanelContenedor.Controls.Add(PanelCentralRegister)
        PanelContenedor.Controls.Add(PanelInferiorRegister)
        PanelContenedor.Controls.Add(PanelSuperiorLogoRegister)
        PanelContenedor.Location = New Point(3, 3)
        PanelContenedor.Name = "PanelContenedor"
        PanelContenedor.Size = New Size(280, 400)
        PanelContenedor.TabIndex = 3
        ' 
        ' FormularioRegister
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(286, 406)
        Controls.Add(FondoDeColor)
        FormBorderStyle = FormBorderStyle.None
        Name = "FormularioRegister"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form2"
        PanelSuperiorLogoRegister.ResumeLayout(False)
        CType(LogoSarmientoLogin, ComponentModel.ISupportInitialize).EndInit()
        PanelInferiorRegister.ResumeLayout(False)
        PanelInfo.ResumeLayout(False)
        PanelInfo.PerformLayout()
        PanelCentralRegister.ResumeLayout(False)
        PanelCentralRegister.PerformLayout()
        FondoDeColor.ResumeLayout(False)
        PanelContenedor.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelSuperiorLogoRegister As Panel
    Friend WithEvents PanelInferiorRegister As Panel
    Friend WithEvents LogoSarmientoLogin As PictureBox
    Friend WithEvents PanelCentralRegister As Panel
    Friend WithEvents TextBoxSubdivision As TextBox
    Friend WithEvents TextBoxContraseña2 As TextBox
    Friend WithEvents TextBoxContraseña1 As TextBox
    Friend WithEvents LabelSubdivisiónRegister As Label
    Friend WithEvents LabelRepetirContraseñaRegister As Label
    Friend WithEvents LabelContraseñaRegister As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents BotonAceptarRegister As Button
    Friend WithEvents BotonCancelarRegister As Button
    Friend WithEvents PanelInfo As Panel
    Friend WithEvents info As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents FondoDeColor As Panel
    Friend WithEvents PanelContenedor As Panel
End Class
