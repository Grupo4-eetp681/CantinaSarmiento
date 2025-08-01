Public Class FormularioRegister

    Dim logica As New LogicaCantina

    Private Sub BotonCancelarRegister_Click(sender As Object, e As EventArgs) Handles BotonCancelarRegister.Click
        Me.Close()
        formLOGIN.Show()

    End Sub

    Private Sub BotonAceptarRegister_Click(sender As Object, e As EventArgs) Handles BotonAceptarRegister.Click
        Dim division As String = TextBoxSubdivision.Text()
        Dim contraseña As String = TextBoxContraseña1.Text()
        Dim contraseña2 As String = TextBoxContraseña2.Text()

        If (division = "" And contraseña = "" And contraseña2 = "") Then
            info.Text = "Debe completar todos los campos"
            PanelInfo.Visible = True
            info.Visible = True
            Timer1.Start()
        End If
        If (contraseña <> contraseña2) Then
            info.Text = "Las contraseñas no coinciden"
            PanelInfo.Visible = True
            info.Visible = True
            Timer1.Start()
        Else
            Dim resultado = logica.registrarDivision(division, contraseña)
            If resultado.Exito Then
                Me.Close()
                formLOGIN.Show()
            End If
            If Not resultado.Exito Then
                info.Text = resultado.Motivo
                PanelInfo.Visible = True
                info.Visible = True
                Timer1.Start()
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        info.Visible = False
        PanelInfo.Visible = False
        Timer1.Stop()
    End Sub

    Private Sub FormularioRegister_Load(sender As Object, e As EventArgs) Handles Me.Load
        info.Visible = False
        PanelInfo.Visible = False
    End Sub
End Class