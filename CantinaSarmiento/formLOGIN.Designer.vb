<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formLOGIN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formLOGIN))
        PanelSuperior = New Panel()
        LogoSarmientoLogin = New PictureBox()
        PanelInferior = New Panel()
        BotonRegister = New Button()
        BotonLogin = New Button()
        PanelCentral = New Panel()
        LabelSubdivision = New Label()
        LabelContraseña = New Label()
        TextBoxContra = New TextBox()
        TextBoxSubdivision = New TextBox()
        PanelSuperior.SuspendLayout()
        CType(LogoSarmientoLogin, ComponentModel.ISupportInitialize).BeginInit()
        PanelInferior.SuspendLayout()
        PanelCentral.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelSuperior
        ' 
        PanelSuperior.BackColor = SystemColors.ActiveBorder
        PanelSuperior.Controls.Add(LogoSarmientoLogin)
        PanelSuperior.Dock = DockStyle.Top
        PanelSuperior.Location = New Point(0, 0)
        PanelSuperior.Name = "PanelSuperior"
        PanelSuperior.Size = New Size(272, 100)
        PanelSuperior.TabIndex = 0
        ' 
        ' LogoSarmientoLogin
        ' 
        LogoSarmientoLogin.Anchor = AnchorStyles.None
        LogoSarmientoLogin.Image = CType(resources.GetObject("LogoSarmientoLogin.Image"), Image)
        LogoSarmientoLogin.Location = New Point(86, 0)
        LogoSarmientoLogin.Name = "LogoSarmientoLogin"
        LogoSarmientoLogin.Size = New Size(100, 100)
        LogoSarmientoLogin.SizeMode = PictureBoxSizeMode.StretchImage
        LogoSarmientoLogin.TabIndex = 7
        LogoSarmientoLogin.TabStop = False
        LogoSarmientoLogin.WaitOnLoad = True
        ' 
        ' PanelInferior
        ' 
        PanelInferior.BackColor = SystemColors.ActiveBorder
        PanelInferior.Controls.Add(BotonRegister)
        PanelInferior.Controls.Add(BotonLogin)
        PanelInferior.Dock = DockStyle.Bottom
        PanelInferior.Location = New Point(0, 383)
        PanelInferior.Name = "PanelInferior"
        PanelInferior.Size = New Size(272, 28)
        PanelInferior.TabIndex = 1
        ' 
        ' BotonRegister
        ' 
        BotonRegister.BackColor = Color.Yellow
        BotonRegister.FlatStyle = FlatStyle.Flat
        BotonRegister.Font = New Font("Candara", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BotonRegister.ForeColor = Color.Black
        BotonRegister.Location = New Point(143, 3)
        BotonRegister.Name = "BotonRegister"
        BotonRegister.Size = New Size(75, 23)
        BotonRegister.TabIndex = 1
        BotonRegister.Text = "REGISTER"
        BotonRegister.UseVisualStyleBackColor = False
        ' 
        ' BotonLogin
        ' 
        BotonLogin.BackColor = Color.Yellow
        BotonLogin.FlatStyle = FlatStyle.Flat
        BotonLogin.Font = New Font("Candara", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        BotonLogin.ForeColor = SystemColors.ActiveCaptionText
        BotonLogin.Location = New Point(54, 3)
        BotonLogin.Name = "BotonLogin"
        BotonLogin.Size = New Size(75, 23)
        BotonLogin.TabIndex = 0
        BotonLogin.Text = "LOGIN"
        BotonLogin.UseVisualStyleBackColor = False
        ' 
        ' PanelCentral
        ' 
        PanelCentral.BackColor = SystemColors.ActiveBorder
        PanelCentral.Controls.Add(LabelSubdivision)
        PanelCentral.Controls.Add(LabelContraseña)
        PanelCentral.Controls.Add(TextBoxContra)
        PanelCentral.Controls.Add(TextBoxSubdivision)
        PanelCentral.Dock = DockStyle.Fill
        PanelCentral.Location = New Point(0, 100)
        PanelCentral.Name = "PanelCentral"
        PanelCentral.Size = New Size(272, 283)
        PanelCentral.TabIndex = 2
        ' 
        ' LabelSubdivision
        ' 
        LabelSubdivision.AutoSize = True
        LabelSubdivision.Font = New Font("Candara", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelSubdivision.Location = New Point(87, 82)
        LabelSubdivision.Name = "LabelSubdivision"
        LabelSubdivision.Size = New Size(99, 19)
        LabelSubdivision.TabIndex = 3
        LabelSubdivision.Text = "SUBDIVISIÓN"
        ' 
        ' LabelContraseña
        ' 
        LabelContraseña.AutoSize = True
        LabelContraseña.Font = New Font("Candara", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelContraseña.Location = New Point(84, 153)
        LabelContraseña.Name = "LabelContraseña"
        LabelContraseña.Size = New Size(105, 19)
        LabelContraseña.TabIndex = 2
        LabelContraseña.Text = "CONTRASEÑA"
        ' 
        ' TextBoxContra
        ' 
        TextBoxContra.Location = New Point(46, 174)
        TextBoxContra.Multiline = True
        TextBoxContra.Name = "TextBoxContra"
        TextBoxContra.Size = New Size(180, 26)
        TextBoxContra.TabIndex = 1
        ' 
        ' TextBoxSubdivision
        ' 
        TextBoxSubdivision.Location = New Point(46, 104)
        TextBoxSubdivision.Multiline = True
        TextBoxSubdivision.Name = "TextBoxSubdivision"
        TextBoxSubdivision.Size = New Size(180, 26)
        TextBoxSubdivision.TabIndex = 0
        ' 
        ' formLOGIN
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(272, 411)
        Controls.Add(PanelCentral)
        Controls.Add(PanelInferior)
        Controls.Add(PanelSuperior)
        FormBorderStyle = FormBorderStyle.None
        Name = "formLOGIN"
        Text = "formLOGIN"
        PanelSuperior.ResumeLayout(False)
        CType(LogoSarmientoLogin, ComponentModel.ISupportInitialize).EndInit()
        PanelInferior.ResumeLayout(False)
        PanelCentral.ResumeLayout(False)
        PanelCentral.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelSuperior As Panel
    Friend WithEvents PanelInferior As Panel
    Friend WithEvents PanelCentral As Panel
    Friend WithEvents LogoSarmientoLogin As PictureBox
    Friend WithEvents TextBoxSubdivision As TextBox
    Friend WithEvents LabelSubdivision As Label
    Friend WithEvents LabelContraseña As Label
    Friend WithEvents TextBoxContra As TextBox
    Friend WithEvents BotonRegister As Button
    Friend WithEvents BotonLogin As Button
End Class
