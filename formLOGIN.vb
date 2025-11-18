Public Class formLOGIN
    ' variables globales
    Dim logica As New LogicaCantina
    ' Método para abrir el formulario ventas dentro del panel
    Public Sub AbrirVentasEnPanel()
        Form1.ContenidoGeneral.Controls.Clear() ' Limpia el panel
        Dim frmVentas As New ventas() ' Crea una instancia del formulario ventas
        frmVentas.TopLevel = False ' Indica que no es un formulario de nivel superior
        frmVentas.FormBorderStyle = FormBorderStyle.None ' Quita los bordes del formulario
        frmVentas.Dock = DockStyle.Fill ' Hace que el formulario llene todo el panel
        Form1.ContenidoGeneral.Controls.Add(frmVentas) ' Agrega el formulario al panel
        frmVentas.Show() ' Muestra el formulario
    End Sub

    Private Sub BotonLogin_Click(sender As Object, e As EventArgs) Handles BotonLogin.Click
        Dim resultado = logica.ValidarLogin(TextBoxSubdivision.Text.ToLower(), TextBoxContra.Text)
        If resultado.Exito Then
            logica.guardarSesion(TextBoxSubdivision.Text.ToLower()) ' guardar la sesión iniciada
            Form1.subdivision = TextBoxSubdivision.Text.ToLower() ' guardar la subdivisión en el formulario principal
            AbrirVentasEnPanel() ' abrir el formulario ventas en el panel
            Me.Dispose() ' cerrar el formulario de login
        ElseIf resultado.Motivo = "Los datos no coinciden con los registros" Then ' mostrar mensaje de error
            info.Text = "Los datos no coinciden con los registros" 
            PanelInfo.Visible = True ' mostrar el panel de información
            info.Visible = True ' mostrar el label de información
            Timer1.Start() ' iniciar el temporizador
        End If
    End Sub

    Private Sub formLOGIN_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBoxContra.PasswordChar = "*"c ' ocultar caracteres de contraseña
        PanelInfo.Visible = False ' ocultar el panel de información
        info.Visible = False ' ocultar el label de información
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        info.Visible = False ' ocultar el label de información
        PanelInfo.Visible = False ' ocultar el panel de información
        Timer1.Stop() ' detener el temporizador
    End Sub

    Private Sub BotonRegister_Click(sender As Object, e As EventArgs) Handles BotonRegister.Click
        FormularioRegister.ShowDialog() ' mostrar el formulario de registro
    End Sub

    Private Sub formLOGIN_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TextBoxSubdivision.Focus() ' establecer el foco en el textbox de subdivisión
    End Sub
End Class