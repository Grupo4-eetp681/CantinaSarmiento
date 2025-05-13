<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        PanelBarraSuperior = New Panel()
        LogoSuperiorIzquierda = New PictureBox()
        PanelBotonesVentana = New Panel()
        ButtonMinimizarApp = New Button()
        ButtonCierreApp = New Button()
        PanelSuperiorAcciones = New Panel()
        PanelBotonesAcciones = New Panel()
        BotonCancelar = New Button()
        BotonExportar = New Button()
        BotonImportar = New Button()
        GenerarPDF = New Button()
        PanelInferiorAcciones = New Panel()
        PanelBotonesVentas = New Panel()
        BotonRegistrar = New Button()
        BotonTicket = New Button()
        BotonFactura = New Button()
        Button5 = New Button()
        PanelMargenI = New Panel()
        PanelBarraInferior = New Panel()
        PanelHora = New Panel()
        LabelHORA = New Label()
        TimerHORA = New Timer(components)
        ContenidoGeneral = New Panel()
        LogoMarcaAgua = New PictureBox()
        LabelTotal = New Label()
        PanelPagoVuelto = New Panel()
        TextVuelto = New TextBox()
        TextPago = New TextBox()
        PanelBarraSuperior.SuspendLayout()
        CType(LogoSuperiorIzquierda, ComponentModel.ISupportInitialize).BeginInit()
        PanelBotonesVentana.SuspendLayout()
        PanelSuperiorAcciones.SuspendLayout()
        PanelBotonesAcciones.SuspendLayout()
        PanelInferiorAcciones.SuspendLayout()
        PanelBotonesVentas.SuspendLayout()
        PanelBarraInferior.SuspendLayout()
        PanelHora.SuspendLayout()
        ContenidoGeneral.SuspendLayout()
        CType(LogoMarcaAgua, ComponentModel.ISupportInitialize).BeginInit()
        PanelPagoVuelto.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelBarraSuperior
        ' 
        PanelBarraSuperior.BackColor = SystemColors.ControlDarkDark
        PanelBarraSuperior.Controls.Add(LogoSuperiorIzquierda)
        PanelBarraSuperior.Controls.Add(PanelBotonesVentana)
        PanelBarraSuperior.Dock = DockStyle.Top
        PanelBarraSuperior.Location = New Point(0, 0)
        PanelBarraSuperior.Name = "PanelBarraSuperior"
        PanelBarraSuperior.Size = New Size(700, 25)
        PanelBarraSuperior.TabIndex = 0
        ' 
        ' LogoSuperiorIzquierda
        ' 
        LogoSuperiorIzquierda.Image = CType(resources.GetObject("LogoSuperiorIzquierda.Image"), Image)
        LogoSuperiorIzquierda.Location = New Point(0, 0)
        LogoSuperiorIzquierda.Name = "LogoSuperiorIzquierda"
        LogoSuperiorIzquierda.Size = New Size(20, 20)
        LogoSuperiorIzquierda.SizeMode = PictureBoxSizeMode.StretchImage
        LogoSuperiorIzquierda.TabIndex = 3
        LogoSuperiorIzquierda.TabStop = False
        ' 
        ' PanelBotonesVentana
        ' 
        PanelBotonesVentana.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PanelBotonesVentana.Controls.Add(ButtonMinimizarApp)
        PanelBotonesVentana.Controls.Add(ButtonCierreApp)
        PanelBotonesVentana.Location = New Point(644, 0)
        PanelBotonesVentana.Name = "PanelBotonesVentana"
        PanelBotonesVentana.Size = New Size(56, 25)
        PanelBotonesVentana.TabIndex = 2
        ' 
        ' ButtonMinimizarApp
        ' 
        ButtonMinimizarApp.BackColor = SystemColors.ControlDarkDark
        ButtonMinimizarApp.BackgroundImage = CType(resources.GetObject("ButtonMinimizarApp.BackgroundImage"), Image)
        ButtonMinimizarApp.BackgroundImageLayout = ImageLayout.Stretch
        ButtonMinimizarApp.FlatStyle = FlatStyle.Flat
        ButtonMinimizarApp.ForeColor = SystemColors.ControlDarkDark
        ButtonMinimizarApp.Location = New Point(0, 0)
        ButtonMinimizarApp.Name = "ButtonMinimizarApp"
        ButtonMinimizarApp.Size = New Size(25, 25)
        ButtonMinimizarApp.TabIndex = 0
        ButtonMinimizarApp.UseVisualStyleBackColor = False
        ' 
        ' ButtonCierreApp
        ' 
        ButtonCierreApp.BackColor = SystemColors.ControlDarkDark
        ButtonCierreApp.BackgroundImage = CType(resources.GetObject("ButtonCierreApp.BackgroundImage"), Image)
        ButtonCierreApp.BackgroundImageLayout = ImageLayout.Stretch
        ButtonCierreApp.FlatStyle = FlatStyle.Flat
        ButtonCierreApp.ForeColor = SystemColors.ControlDarkDark
        ButtonCierreApp.Location = New Point(31, 0)
        ButtonCierreApp.Name = "ButtonCierreApp"
        ButtonCierreApp.Size = New Size(25, 25)
        ButtonCierreApp.TabIndex = 0
        ButtonCierreApp.UseVisualStyleBackColor = False
        ' 
        ' PanelSuperiorAcciones
        ' 
        PanelSuperiorAcciones.Controls.Add(PanelBotonesAcciones)
        PanelSuperiorAcciones.Controls.Add(GenerarPDF)
        PanelSuperiorAcciones.Dock = DockStyle.Top
        PanelSuperiorAcciones.Location = New Point(25, 25)
        PanelSuperiorAcciones.Name = "PanelSuperiorAcciones"
        PanelSuperiorAcciones.Size = New Size(675, 30)
        PanelSuperiorAcciones.TabIndex = 1
        ' 
        ' PanelBotonesAcciones
        ' 
        PanelBotonesAcciones.Controls.Add(BotonCancelar)
        PanelBotonesAcciones.Controls.Add(BotonExportar)
        PanelBotonesAcciones.Controls.Add(BotonImportar)
        PanelBotonesAcciones.Dock = DockStyle.Left
        PanelBotonesAcciones.Location = New Point(0, 0)
        PanelBotonesAcciones.Name = "PanelBotonesAcciones"
        PanelBotonesAcciones.Size = New Size(100, 30)
        PanelBotonesAcciones.TabIndex = 2
        ' 
        ' BotonCancelar
        ' 
        BotonCancelar.BackColor = Color.Transparent
        BotonCancelar.BackgroundImage = CType(resources.GetObject("BotonCancelar.BackgroundImage"), Image)
        BotonCancelar.BackgroundImageLayout = ImageLayout.Stretch
        BotonCancelar.Location = New Point(70, 0)
        BotonCancelar.Name = "BotonCancelar"
        BotonCancelar.Size = New Size(30, 30)
        BotonCancelar.TabIndex = 3
        BotonCancelar.UseVisualStyleBackColor = False
        ' 
        ' BotonExportar
        ' 
        BotonExportar.BackColor = Color.Transparent
        BotonExportar.BackgroundImage = CType(resources.GetObject("BotonExportar.BackgroundImage"), Image)
        BotonExportar.BackgroundImageLayout = ImageLayout.Stretch
        BotonExportar.Location = New Point(0, 0)
        BotonExportar.Name = "BotonExportar"
        BotonExportar.Size = New Size(30, 30)
        BotonExportar.TabIndex = 2
        BotonExportar.UseVisualStyleBackColor = False
        ' 
        ' BotonImportar
        ' 
        BotonImportar.BackColor = Color.Transparent
        BotonImportar.BackgroundImage = CType(resources.GetObject("BotonImportar.BackgroundImage"), Image)
        BotonImportar.BackgroundImageLayout = ImageLayout.Stretch
        BotonImportar.Location = New Point(35, 0)
        BotonImportar.Name = "BotonImportar"
        BotonImportar.Size = New Size(30, 30)
        BotonImportar.TabIndex = 1
        BotonImportar.UseVisualStyleBackColor = False
        ' 
        ' GenerarPDF
        ' 
        GenerarPDF.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        GenerarPDF.Location = New Point(575, 4)
        GenerarPDF.Name = "GenerarPDF"
        GenerarPDF.Size = New Size(97, 23)
        GenerarPDF.TabIndex = 0
        GenerarPDF.Text = "GENERAR PDF"
        GenerarPDF.UseVisualStyleBackColor = True
        ' 
        ' PanelInferiorAcciones
        ' 
        PanelInferiorAcciones.Controls.Add(LabelTotal)
        PanelInferiorAcciones.Controls.Add(PanelBotonesVentas)
        PanelInferiorAcciones.Controls.Add(Button5)
        PanelInferiorAcciones.Dock = DockStyle.Bottom
        PanelInferiorAcciones.Location = New Point(25, 645)
        PanelInferiorAcciones.Name = "PanelInferiorAcciones"
        PanelInferiorAcciones.Size = New Size(675, 30)
        PanelInferiorAcciones.TabIndex = 2
        ' 
        ' PanelBotonesVentas
        ' 
        PanelBotonesVentas.Controls.Add(BotonRegistrar)
        PanelBotonesVentas.Controls.Add(BotonTicket)
        PanelBotonesVentas.Controls.Add(BotonFactura)
        PanelBotonesVentas.Dock = DockStyle.Left
        PanelBotonesVentas.Location = New Point(0, 0)
        PanelBotonesVentas.Name = "PanelBotonesVentas"
        PanelBotonesVentas.Size = New Size(100, 30)
        PanelBotonesVentas.TabIndex = 2
        ' 
        ' BotonRegistrar
        ' 
        BotonRegistrar.BackColor = Color.Transparent
        BotonRegistrar.BackgroundImage = CType(resources.GetObject("BotonRegistrar.BackgroundImage"), Image)
        BotonRegistrar.BackgroundImageLayout = ImageLayout.Zoom
        BotonRegistrar.Location = New Point(70, 0)
        BotonRegistrar.Name = "BotonRegistrar"
        BotonRegistrar.Size = New Size(30, 30)
        BotonRegistrar.TabIndex = 3
        BotonRegistrar.UseVisualStyleBackColor = False
        ' 
        ' BotonTicket
        ' 
        BotonTicket.BackColor = Color.Transparent
        BotonTicket.BackgroundImage = CType(resources.GetObject("BotonTicket.BackgroundImage"), Image)
        BotonTicket.BackgroundImageLayout = ImageLayout.Stretch
        BotonTicket.Location = New Point(0, 0)
        BotonTicket.Name = "BotonTicket"
        BotonTicket.Size = New Size(30, 30)
        BotonTicket.TabIndex = 2
        BotonTicket.UseVisualStyleBackColor = False
        ' 
        ' BotonFactura
        ' 
        BotonFactura.BackColor = Color.Transparent
        BotonFactura.BackgroundImage = CType(resources.GetObject("BotonFactura.BackgroundImage"), Image)
        BotonFactura.BackgroundImageLayout = ImageLayout.Stretch
        BotonFactura.Location = New Point(35, 0)
        BotonFactura.Name = "BotonFactura"
        BotonFactura.Size = New Size(30, 30)
        BotonFactura.TabIndex = 1
        BotonFactura.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button5.Location = New Point(1075, 4)
        Button5.Name = "Button5"
        Button5.Size = New Size(97, 23)
        Button5.TabIndex = 0
        Button5.Text = "GENERAR PDF"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' PanelMargenI
        ' 
        PanelMargenI.BackColor = SystemColors.ControlDarkDark
        PanelMargenI.Dock = DockStyle.Left
        PanelMargenI.Location = New Point(0, 25)
        PanelMargenI.Name = "PanelMargenI"
        PanelMargenI.Size = New Size(25, 675)
        PanelMargenI.TabIndex = 3
        ' 
        ' PanelBarraInferior
        ' 
        PanelBarraInferior.BackColor = SystemColors.ControlDarkDark
        PanelBarraInferior.Controls.Add(PanelHora)
        PanelBarraInferior.Dock = DockStyle.Bottom
        PanelBarraInferior.Location = New Point(25, 675)
        PanelBarraInferior.Name = "PanelBarraInferior"
        PanelBarraInferior.Size = New Size(675, 25)
        PanelBarraInferior.TabIndex = 4
        ' 
        ' PanelHora
        ' 
        PanelHora.Controls.Add(LabelHORA)
        PanelHora.Dock = DockStyle.Right
        PanelHora.Location = New Point(545, 0)
        PanelHora.Name = "PanelHora"
        PanelHora.Size = New Size(130, 25)
        PanelHora.TabIndex = 6
        ' 
        ' LabelHORA
        ' 
        LabelHORA.Dock = DockStyle.Right
        LabelHORA.Font = New Font("Century Gothic", 9F)
        LabelHORA.Location = New Point(0, 0)
        LabelHORA.Name = "LabelHORA"
        LabelHORA.Size = New Size(130, 25)
        LabelHORA.TabIndex = 5
        LabelHORA.Text = "HORA"
        LabelHORA.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' TimerHORA
        ' 
        TimerHORA.Enabled = True
        TimerHORA.Interval = 1000
        ' 
        ' ContenidoGeneral
        ' 
        ContenidoGeneral.Controls.Add(LogoMarcaAgua)
        ContenidoGeneral.Dock = DockStyle.Fill
        ContenidoGeneral.Location = New Point(25, 55)
        ContenidoGeneral.Name = "ContenidoGeneral"
        ContenidoGeneral.Size = New Size(675, 560)
        ContenidoGeneral.TabIndex = 5
        ' 
        ' LogoMarcaAgua
        ' 
        LogoMarcaAgua.Image = CType(resources.GetObject("LogoMarcaAgua.Image"), Image)
        LogoMarcaAgua.Location = New Point(212, 155)
        LogoMarcaAgua.Name = "LogoMarcaAgua"
        LogoMarcaAgua.Size = New Size(250, 250)
        LogoMarcaAgua.SizeMode = PictureBoxSizeMode.StretchImage
        LogoMarcaAgua.TabIndex = 6
        LogoMarcaAgua.TabStop = False
        ' 
        ' LabelTotal
        ' 
        LabelTotal.Anchor = AnchorStyles.Right
        LabelTotal.AutoSize = True
        LabelTotal.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelTotal.Location = New Point(623, 5)
        LabelTotal.Name = "LabelTotal"
        LabelTotal.Size = New Size(49, 21)
        LabelTotal.TabIndex = 3
        LabelTotal.Text = "Total"
        LabelTotal.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' PanelPagoVuelto
        ' 
        PanelPagoVuelto.Controls.Add(TextPago)
        PanelPagoVuelto.Controls.Add(TextVuelto)
        PanelPagoVuelto.Dock = DockStyle.Bottom
        PanelPagoVuelto.Location = New Point(25, 615)
        PanelPagoVuelto.Name = "PanelPagoVuelto"
        PanelPagoVuelto.Size = New Size(675, 30)
        PanelPagoVuelto.TabIndex = 7
        ' 
        ' TextVuelto
        ' 
        TextVuelto.Location = New Point(572, 4)
        TextVuelto.Name = "TextVuelto"
        TextVuelto.Size = New Size(100, 23)
        TextVuelto.TabIndex = 0
        ' 
        ' TextPago
        ' 
        TextPago.Location = New Point(466, 4)
        TextPago.Name = "TextPago"
        TextPago.Size = New Size(100, 23)
        TextPago.TabIndex = 1
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(700, 700)
        Controls.Add(ContenidoGeneral)
        Controls.Add(PanelPagoVuelto)
        Controls.Add(PanelInferiorAcciones)
        Controls.Add(PanelBarraInferior)
        Controls.Add(PanelSuperiorAcciones)
        Controls.Add(PanelMargenI)
        Controls.Add(PanelBarraSuperior)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        PanelBarraSuperior.ResumeLayout(False)
        CType(LogoSuperiorIzquierda, ComponentModel.ISupportInitialize).EndInit()
        PanelBotonesVentana.ResumeLayout(False)
        PanelSuperiorAcciones.ResumeLayout(False)
        PanelBotonesAcciones.ResumeLayout(False)
        PanelInferiorAcciones.ResumeLayout(False)
        PanelInferiorAcciones.PerformLayout()
        PanelBotonesVentas.ResumeLayout(False)
        PanelBarraInferior.ResumeLayout(False)
        PanelHora.ResumeLayout(False)
        ContenidoGeneral.ResumeLayout(False)
        CType(LogoMarcaAgua, ComponentModel.ISupportInitialize).EndInit()
        PanelPagoVuelto.ResumeLayout(False)
        PanelPagoVuelto.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelBarraSuperior As Panel
    Friend WithEvents ButtonCierreApp As Button
    Friend WithEvents PanelBotonesVentana As Panel
    Friend WithEvents ButtonMinimizarApp As Button
    Friend WithEvents PanelSuperiorAcciones As Panel
    Friend WithEvents GenerarPDF As Button
    Friend WithEvents BotonImportar As Button
    Friend WithEvents BotonCancelar As Button
    Friend WithEvents BotonExportar As Button
    Friend WithEvents PanelBotonesAcciones As Panel
    Friend WithEvents PanelInferiorAcciones As Panel
    Friend WithEvents PanelBotonesVentas As Panel
    Friend WithEvents BotonRegistrar As Button
    Friend WithEvents BotonTicket As Button
    Friend WithEvents BotonFactura As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents LogoSuperiorIzquierda As PictureBox
    Friend WithEvents PanelMargenI As Panel
    Friend WithEvents PanelBarraInferior As Panel
    Friend WithEvents LabelHORA As Label
    Friend WithEvents TimerHORA As Timer
    Friend WithEvents PanelHora As Panel
    Friend WithEvents LabelTotal As Label
    Friend WithEvents ContenidoGeneral As Panel
    Friend WithEvents LogoMarcaAgua As PictureBox
    Friend WithEvents PanelPagoVuelto As Panel
    Friend WithEvents TextPago As TextBox
    Friend WithEvents TextVuelto As TextBox

End Class
