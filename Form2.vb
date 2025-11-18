Public Class FormularioRegister

    Dim logica As New LogicaCantina ' variables globales
    
    ' Botón Cancelar
    Private Sub BotonCancelarRegister_Click(sender As Object, e As EventArgs) Handles BotonCancelarRegister.Click
        Me.Dispose()
    End Sub
    ' Botón Aceptar
    Private Sub BotonAceptarRegister_Click(sender As Object, e As EventArgs) Handles BotonAceptarRegister.Click
        Dim division As String = TextBoxSubdivision.Text() ' obtener el texto de la subdivision
        Dim contraseña As String = TextBoxContraseña1.Text() ' obtener el texto de la contraseña
        Dim contraseña2 As String = TextBoxContraseña2.Text() ' obtener el texto de la confirmación de la contraseña

        If (division = "" And contraseña = "" And contraseña2 = "") Then ' validar que no estén vacíos
            info.Text = "Debe completar todos los campos" ' mostrar mensaje de error
            PanelInfo.Visible = True ' hacer visible el panel de información
            info.Visible = True ' hacer visible el label de información
            Timer1.Start()
        End If
        If (contraseña <> contraseña2) Then
            info.Text = "Las contraseñas no coinciden" ' mostrar mensaje de error
            PanelInfo.Visible = True ' hacer visible el panel de información
            info.Visible = True ' hacer visible el label de información
            Timer1.Start() 
        Else
            division = division.ToLower() ' convertir la división a minúsculas
            Dim resultado = logica.registrarDivision(division, contraseña) ' llamar al método para registrar la división
            If resultado.Exito Then
                ' Preguntar si desea cargar una lista por defecto de productos
                Dim continuar As Boolean 
                Dim frm As New Advertencia("¿Desea cargar una lista por defecto de productos?", "Register", False) ' crear formulario de advertencia
                Dim rest = frm.ShowDialog() ' mostrar el formulario de advertencia
                If rest = DialogResult.OK Then ' si se confirma
                    continuar = True 
                Else
                    continuar = False
                End If

                If continuar Then
                    logica.cargarSubdivision(division) ' cargar la subdivisión
                    logica.CargarListaDefault() ' cargar la lista por defecto de productos
                End If

                Me.Dispose() ' cerrar el formulario de registro
            End If
            If Not resultado.Exito Then ' si no se pudo registrar
                info.Text = resultado.Motivo ' mostrar el motivo del error
                PanelInfo.Visible = True ' hacer visible el panel de información
                info.Visible = True ' hacer visible el label de información
                Timer1.Start() ' iniciar el temporizador
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        info.Visible = False
        PanelInfo.Visible = False
        Timer1.Stop()
    End Sub

    Private Sub FormularioRegister_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBoxContraseña1.PasswordChar = "*"c ' ocultar el texto de la contraseña
        TextBoxContraseña2.PasswordChar = "*"c ' ocultar el texto de la confirmación de la contraseña
        info.Visible = False ' ocultar el label de información
        PanelInfo.Visible = False ' ocultar el panel de información
    End Sub

End Class