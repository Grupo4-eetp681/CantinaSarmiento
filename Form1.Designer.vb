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
        ButtonMaximizarApp = New Button()
        ButtonMinimizarApp = New Button()
        ButtonCierreApp = New Button()
        PanelBotonesAcciones = New Panel()
        CerrarSesion = New Button()
        BotonImportar = New Button()
        BotonExportar = New Button()
        PanelMargenI = New Panel()
        SubPanelIzquierdo = New Panel()
        PanelBotonMenu = New Panel()
        ButtonMenuDerecha = New Button()
        BotonMenuAbajo = New Button()
        PanelBarraInferior = New Panel()
        PanelHora = New Panel()
        LabelHORA = New Label()
        TimerHORA = New Timer(components)
        ContenidoGeneral = New Panel()
        LogoMarcaAgua = New PictureBox()
        PanelMargenDerecho = New Panel()
        PanelContenedorDeFormularios = New Panel()
        botonInventario = New Button()
        botonVentas = New Button()
        botonCaja = New Button()
        FondoDeColor = New Panel()
        Opciones = New ContextMenuStrip(components)
        ActivarAdvertenciasToolStripMenuItem = New ToolStripMenuItem()
        ToolTip = New ToolTip(components)
        ToolTip1 = New ToolTip(components)
        PanelBarraSuperior.SuspendLayout()
        CType(LogoSuperiorIzquierda, ComponentModel.ISupportInitialize).BeginInit()
        PanelBotonesVentana.SuspendLayout()
        PanelBotonesAcciones.SuspendLayout()
        PanelMargenI.SuspendLayout()
        SubPanelIzquierdo.SuspendLayout()
        PanelBotonMenu.SuspendLayout()
        PanelBarraInferior.SuspendLayout()
        PanelHora.SuspendLayout()
        ContenidoGeneral.SuspendLayout()
        CType(LogoMarcaAgua, ComponentModel.ISupportInitialize).BeginInit()
        PanelMargenDerecho.SuspendLayout()
        PanelContenedorDeFormularios.SuspendLayout()
        FondoDeColor.SuspendLayout()
        Opciones.SuspendLayout()
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
        PanelBarraSuperior.Size = New Size(960, 40)
        PanelBarraSuperior.TabIndex = 0
        ' 
        ' LogoSuperiorIzquierda
        ' 
        LogoSuperiorIzquierda.Image = CType(resources.GetObject("LogoSuperiorIzquierda.Image"), Image)
        LogoSuperiorIzquierda.Location = New Point(0, 0)
        LogoSuperiorIzquierda.Name = "LogoSuperiorIzquierda"
        LogoSuperiorIzquierda.Size = New Size(40, 40)
        LogoSuperiorIzquierda.SizeMode = PictureBoxSizeMode.StretchImage
        LogoSuperiorIzquierda.TabIndex = 3
        LogoSuperiorIzquierda.TabStop = False
        ToolTip.SetToolTip(LogoSuperiorIzquierda, "Configuraciones")
        ' 
        ' PanelBotonesVentana
        ' 
        PanelBotonesVentana.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PanelBotonesVentana.Controls.Add(ButtonMaximizarApp)
        PanelBotonesVentana.Controls.Add(ButtonMinimizarApp)
        PanelBotonesVentana.Controls.Add(ButtonCierreApp)
        PanelBotonesVentana.Location = New Point(875, 2)
        PanelBotonesVentana.Name = "PanelBotonesVentana"
        PanelBotonesVentana.Size = New Size(85, 40)
        PanelBotonesVentana.TabIndex = 2
        ' 
        ' ButtonMaximizarApp
        ' 
        ButtonMaximizarApp.BackColor = SystemColors.ControlDarkDark
        ButtonMaximizarApp.BackgroundImage = CType(resources.GetObject("ButtonMaximizarApp.BackgroundImage"), Image)
        ButtonMaximizarApp.BackgroundImageLayout = ImageLayout.Stretch
        ButtonMaximizarApp.FlatStyle = FlatStyle.Flat
        ButtonMaximizarApp.ForeColor = SystemColors.ControlDarkDark
        ButtonMaximizarApp.Location = New Point(30, 0)
        ButtonMaximizarApp.Name = "ButtonMaximizarApp"
        ButtonMaximizarApp.Size = New Size(25, 25)
        ButtonMaximizarApp.TabIndex = 1
        ToolTip.SetToolTip(ButtonMaximizarApp, "Maximizar")
        ButtonMaximizarApp.UseVisualStyleBackColor = False
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
        ToolTip.SetToolTip(ButtonMinimizarApp, "Minimizar")
        ButtonMinimizarApp.UseVisualStyleBackColor = False
        ' 
        ' ButtonCierreApp
        ' 
        ButtonCierreApp.BackColor = SystemColors.ControlDarkDark
        ButtonCierreApp.BackgroundImage = CType(resources.GetObject("ButtonCierreApp.BackgroundImage"), Image)
        ButtonCierreApp.BackgroundImageLayout = ImageLayout.Stretch
        ButtonCierreApp.FlatStyle = FlatStyle.Flat
        ButtonCierreApp.ForeColor = SystemColors.ControlDarkDark
        ButtonCierreApp.Location = New Point(60, 0)
        ButtonCierreApp.Name = "ButtonCierreApp"
        ButtonCierreApp.Size = New Size(25, 25)
        ButtonCierreApp.TabIndex = 0
        ToolTip.SetToolTip(ButtonCierreApp, "Cerrar")
        ButtonCierreApp.UseVisualStyleBackColor = False
        ' 
        ' PanelBotonesAcciones
        ' 
        PanelBotonesAcciones.Controls.Add(CerrarSesion)
        PanelBotonesAcciones.Controls.Add(BotonImportar)
        PanelBotonesAcciones.Controls.Add(BotonExportar)
        PanelBotonesAcciones.Dock = DockStyle.Top
        PanelBotonesAcciones.Location = New Point(0, 0)
        PanelBotonesAcciones.Name = "PanelBotonesAcciones"
        PanelBotonesAcciones.Size = New Size(40, 150)
        PanelBotonesAcciones.TabIndex = 2
        PanelBotonesAcciones.Visible = False
        ' 
        ' CerrarSesion
        ' 
        CerrarSesion.BackColor = Color.Transparent
        CerrarSesion.BackgroundImage = CType(resources.GetObject("CerrarSesion.BackgroundImage"), Image)
        CerrarSesion.BackgroundImageLayout = ImageLayout.Stretch
        CerrarSesion.Location = New Point(0, 110)
        CerrarSesion.Name = "CerrarSesion"
        CerrarSesion.Size = New Size(40, 40)
        CerrarSesion.TabIndex = 3
        ToolTip.SetToolTip(CerrarSesion, "Cerrar Sesion")
        CerrarSesion.UseVisualStyleBackColor = False
        ' 
        ' BotonImportar
        ' 
        BotonImportar.BackColor = Color.Transparent
        BotonImportar.BackgroundImage = CType(resources.GetObject("BotonImportar.BackgroundImage"), Image)
        BotonImportar.BackgroundImageLayout = ImageLayout.Stretch
        BotonImportar.Location = New Point(0, 60)
        BotonImportar.Name = "BotonImportar"
        BotonImportar.Size = New Size(40, 40)
        BotonImportar.TabIndex = 1
        ToolTip.SetToolTip(BotonImportar, "Importar")
        BotonImportar.UseVisualStyleBackColor = False
        ' 
        ' BotonExportar
        ' 
        BotonExportar.BackColor = Color.Transparent
        BotonExportar.BackgroundImage = CType(resources.GetObject("BotonExportar.BackgroundImage"), Image)
        BotonExportar.BackgroundImageLayout = ImageLayout.Stretch
        BotonExportar.FlatAppearance.BorderSize = 0
        BotonExportar.FlatAppearance.MouseDownBackColor = SystemColors.ButtonShadow
        BotonExportar.Location = New Point(0, 10)
        BotonExportar.Name = "BotonExportar"
        BotonExportar.Size = New Size(40, 40)
        BotonExportar.TabIndex = 2
        ToolTip.SetToolTip(BotonExportar, "Exportar")
        BotonExportar.UseVisualStyleBackColor = False
        ' 
        ' PanelMargenI
        ' 
        PanelMargenI.BackColor = SystemColors.ControlDarkDark
        PanelMargenI.Controls.Add(SubPanelIzquierdo)
        PanelMargenI.Controls.Add(PanelBotonMenu)
        PanelMargenI.Dock = DockStyle.Left
        PanelMargenI.Location = New Point(0, 40)
        PanelMargenI.Name = "PanelMargenI"
        PanelMargenI.Size = New Size(40, 460)
        PanelMargenI.TabIndex = 3
        ' 
        ' SubPanelIzquierdo
        ' 
        SubPanelIzquierdo.Controls.Add(PanelBotonesAcciones)
        SubPanelIzquierdo.Dock = DockStyle.Fill
        SubPanelIzquierdo.Location = New Point(0, 40)
        SubPanelIzquierdo.Name = "SubPanelIzquierdo"
        SubPanelIzquierdo.Size = New Size(40, 420)
        SubPanelIzquierdo.TabIndex = 7
        ' 
        ' PanelBotonMenu
        ' 
        PanelBotonMenu.Controls.Add(ButtonMenuDerecha)
        PanelBotonMenu.Controls.Add(BotonMenuAbajo)
        PanelBotonMenu.Dock = DockStyle.Top
        PanelBotonMenu.Location = New Point(0, 0)
        PanelBotonMenu.Name = "PanelBotonMenu"
        PanelBotonMenu.Size = New Size(40, 40)
        PanelBotonMenu.TabIndex = 7
        ' 
        ' ButtonMenuDerecha
        ' 
        ButtonMenuDerecha.Anchor = AnchorStyles.None
        ButtonMenuDerecha.AutoSize = True
        ButtonMenuDerecha.BackgroundImage = CType(resources.GetObject("ButtonMenuDerecha.BackgroundImage"), Image)
        ButtonMenuDerecha.BackgroundImageLayout = ImageLayout.Stretch
        ButtonMenuDerecha.Location = New Point(0, 0)
        ButtonMenuDerecha.Name = "ButtonMenuDerecha"
        ButtonMenuDerecha.Size = New Size(40, 40)
        ButtonMenuDerecha.TabIndex = 8
        ToolTip.SetToolTip(ButtonMenuDerecha, "Cerrar Menu")
        ButtonMenuDerecha.UseVisualStyleBackColor = True
        ButtonMenuDerecha.Visible = False
        ' 
        ' BotonMenuAbajo
        ' 
        BotonMenuAbajo.Anchor = AnchorStyles.None
        BotonMenuAbajo.AutoSize = True
        BotonMenuAbajo.BackgroundImage = CType(resources.GetObject("BotonMenuAbajo.BackgroundImage"), Image)
        BotonMenuAbajo.BackgroundImageLayout = ImageLayout.Stretch
        BotonMenuAbajo.Location = New Point(0, 0)
        BotonMenuAbajo.Name = "BotonMenuAbajo"
        BotonMenuAbajo.Size = New Size(40, 40)
        BotonMenuAbajo.TabIndex = 7
        ToolTip.SetToolTip(BotonMenuAbajo, "Abrir Menu")
        BotonMenuAbajo.UseVisualStyleBackColor = True
        ' 
        ' PanelBarraInferior
        ' 
        PanelBarraInferior.BackColor = SystemColors.ControlDarkDark
        PanelBarraInferior.Controls.Add(PanelHora)
        PanelBarraInferior.Dock = DockStyle.Bottom
        PanelBarraInferior.Location = New Point(0, 500)
        PanelBarraInferior.Name = "PanelBarraInferior"
        PanelBarraInferior.Size = New Size(960, 40)
        PanelBarraInferior.TabIndex = 4
        ' 
        ' PanelHora
        ' 
        PanelHora.Controls.Add(LabelHORA)
        PanelHora.Dock = DockStyle.Right
        PanelHora.Location = New Point(830, 0)
        PanelHora.Name = "PanelHora"
        PanelHora.Size = New Size(130, 40)
        PanelHora.TabIndex = 6
        ' 
        ' LabelHORA
        ' 
        LabelHORA.Dock = DockStyle.Right
        LabelHORA.Font = New Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelHORA.Location = New Point(-120, 0)
        LabelHORA.Name = "LabelHORA"
        LabelHORA.Size = New Size(250, 40)
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
        ContenidoGeneral.BackColor = SystemColors.ControlDark
        ContenidoGeneral.Controls.Add(LogoMarcaAgua)
        ContenidoGeneral.Dock = DockStyle.Fill
        ContenidoGeneral.Location = New Point(0, 0)
        ContenidoGeneral.Name = "ContenidoGeneral"
        ContenidoGeneral.Size = New Size(880, 460)
        ContenidoGeneral.TabIndex = 5
        ' 
        ' LogoMarcaAgua
        ' 
        LogoMarcaAgua.Anchor = AnchorStyles.None
        LogoMarcaAgua.Image = CType(resources.GetObject("LogoMarcaAgua.Image"), Image)
        LogoMarcaAgua.Location = New Point(340, 130)
        LogoMarcaAgua.Name = "LogoMarcaAgua"
        LogoMarcaAgua.Size = New Size(200, 200)
        LogoMarcaAgua.SizeMode = PictureBoxSizeMode.StretchImage
        LogoMarcaAgua.TabIndex = 6
        LogoMarcaAgua.TabStop = False
        LogoMarcaAgua.WaitOnLoad = True
        ' 
        ' PanelMargenDerecho
        ' 
        PanelMargenDerecho.BackColor = SystemColors.ControlDarkDark
        PanelMargenDerecho.Controls.Add(PanelContenedorDeFormularios)
        PanelMargenDerecho.Dock = DockStyle.Right
        PanelMargenDerecho.Location = New Point(920, 40)
        PanelMargenDerecho.Name = "PanelMargenDerecho"
        PanelMargenDerecho.Size = New Size(40, 460)
        PanelMargenDerecho.TabIndex = 8
        ' 
        ' PanelContenedorDeFormularios
        ' 
        PanelContenedorDeFormularios.Controls.Add(botonInventario)
        PanelContenedorDeFormularios.Controls.Add(botonVentas)
        PanelContenedorDeFormularios.Controls.Add(botonCaja)
        PanelContenedorDeFormularios.Dock = DockStyle.Top
        PanelContenedorDeFormularios.Location = New Point(0, 0)
        PanelContenedorDeFormularios.Name = "PanelContenedorDeFormularios"
        PanelContenedorDeFormularios.Size = New Size(40, 140)
        PanelContenedorDeFormularios.TabIndex = 8
        ' 
        ' botonInventario
        ' 
        botonInventario.BackgroundImage = CType(resources.GetObject("botonInventario.BackgroundImage"), Image)
        botonInventario.BackgroundImageLayout = ImageLayout.Stretch
        botonInventario.Location = New Point(0, 100)
        botonInventario.Name = "botonInventario"
        botonInventario.Size = New Size(40, 40)
        botonInventario.TabIndex = 2
        ToolTip.SetToolTip(botonInventario, "Inventario")
        botonInventario.UseVisualStyleBackColor = True
        ' 
        ' botonVentas
        ' 
        botonVentas.BackgroundImage = CType(resources.GetObject("botonVentas.BackgroundImage"), Image)
        botonVentas.BackgroundImageLayout = ImageLayout.Stretch
        botonVentas.Location = New Point(0, 0)
        botonVentas.Name = "botonVentas"
        botonVentas.Size = New Size(40, 40)
        botonVentas.TabIndex = 0
        ToolTip.SetToolTip(botonVentas, "Ventas")
        botonVentas.UseVisualStyleBackColor = True
        ' 
        ' botonCaja
        ' 
        botonCaja.BackgroundImage = CType(resources.GetObject("botonCaja.BackgroundImage"), Image)
        botonCaja.BackgroundImageLayout = ImageLayout.Stretch
        botonCaja.Location = New Point(0, 50)
        botonCaja.Name = "botonCaja"
        botonCaja.Size = New Size(40, 40)
        botonCaja.TabIndex = 1
        ToolTip.SetToolTip(botonCaja, "Caja")
        botonCaja.UseVisualStyleBackColor = True
        ' 
        ' FondoDeColor
        ' 
        FondoDeColor.BackColor = Color.Gold
        FondoDeColor.Controls.Add(ContenidoGeneral)
        FondoDeColor.Dock = DockStyle.Fill
        FondoDeColor.Location = New Point(40, 40)
        FondoDeColor.Name = "FondoDeColor"
        FondoDeColor.Size = New Size(880, 460)
        FondoDeColor.TabIndex = 9
        ' 
        ' Opciones
        ' 
        Opciones.Items.AddRange(New ToolStripItem() {ActivarAdvertenciasToolStripMenuItem})
        Opciones.Name = "ContextMenuStrip1"
        Opciones.Size = New Size(183, 48)
        ' 
        ' ActivarAdvertenciasToolStripMenuItem
        ' 
        ActivarAdvertenciasToolStripMenuItem.Name = "ActivarAdvertenciasToolStripMenuItem"
        ActivarAdvertenciasToolStripMenuItem.Size = New Size(182, 22)
        ActivarAdvertenciasToolStripMenuItem.Text = "Activar Advertencias"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(960, 540)
        Controls.Add(FondoDeColor)
        Controls.Add(PanelMargenI)
        Controls.Add(PanelMargenDerecho)
        Controls.Add(PanelBarraSuperior)
        Controls.Add(PanelBarraInferior)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        WindowState = FormWindowState.Maximized
        PanelBarraSuperior.ResumeLayout(False)
        CType(LogoSuperiorIzquierda, ComponentModel.ISupportInitialize).EndInit()
        PanelBotonesVentana.ResumeLayout(False)
        PanelBotonesAcciones.ResumeLayout(False)
        PanelMargenI.ResumeLayout(False)
        SubPanelIzquierdo.ResumeLayout(False)
        PanelBotonMenu.ResumeLayout(False)
        PanelBotonMenu.PerformLayout()
        PanelBarraInferior.ResumeLayout(False)
        PanelHora.ResumeLayout(False)
        ContenidoGeneral.ResumeLayout(False)
        CType(LogoMarcaAgua, ComponentModel.ISupportInitialize).EndInit()
        PanelMargenDerecho.ResumeLayout(False)
        PanelContenedorDeFormularios.ResumeLayout(False)
        FondoDeColor.ResumeLayout(False)
        Opciones.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelBarraSuperior As Panel
    Friend WithEvents ButtonCierreApp As Button
    Friend WithEvents PanelBotonesVentana As Panel
    Friend WithEvents ButtonMinimizarApp As Button
    Friend WithEvents BotonImportar As Button
    Friend WithEvents BotonExportar As Button
    Friend WithEvents PanelBotonesAcciones As Panel
    Friend WithEvents LogoSuperiorIzquierda As PictureBox
    Friend WithEvents PanelMargenI As Panel
    Friend WithEvents PanelBarraInferior As Panel
    Friend WithEvents LabelHORA As Label
    Friend WithEvents TimerHORA As Timer
    Friend WithEvents PanelHora As Panel
    Friend WithEvents ContenidoGeneral As Panel
    Friend WithEvents LogoMarcaAgua As PictureBox
    Friend WithEvents PanelMargenDerecho As Panel
    Friend WithEvents BotonMenuAbajo As Button
    Friend WithEvents PanelBotonMenu As Panel
    Friend WithEvents SubPanelIzquierdo As Panel
    Friend WithEvents ButtonMaximizarApp As Button
    Friend WithEvents FondoDeColor As Panel
    Friend WithEvents CerrarSesion As Button
    Friend WithEvents PanelContenedorDeFormularios As Panel
    Friend WithEvents botonInventario As Button
    Friend WithEvents botonVentas As Button
    Friend WithEvents botonCaja As Button
    Friend WithEvents Opciones As ContextMenuStrip
    Friend WithEvents ActivarAdvertenciasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ButtonMenuDerecha As Button
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents ToolTip1 As ToolTip

End Class
