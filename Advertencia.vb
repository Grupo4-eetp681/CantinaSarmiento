Public Class Advertencia
    Dim logica As New LogicaCantina
    Private _origen As String
    Public Property NoMostrarMas As Boolean = False

    ' Constructor que recibe mensaje y origen
    Public Sub New(mensaje As String, origen As String)
        ' Llamar al diseñador
        InitializeComponent()

        ' Setear el mensaje en el Label
        AjustarFuenteLabelMaximo(LabelMensaje, mensaje)

        ' Guardar de dónde viene (para saber qué advertencia se quiere silenciar)
        _origen = origen
    End Sub

    ' Botón Aceptar
    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        ' Guardar si tildó el CheckBox
        If CheckBoxNoMostrar.Checked Then
            NoMostrarMas = True
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    ' Botón Cancelar
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub AjustarFuenteLabelMaximo(label As Label, texto As String)
        Dim anchoMaximo As Integer = label.Width
        Dim altoMaximo As Integer = label.Height
        Dim fuenteBase As Font = label.Font
        Dim tamañoFuente As Single = fuenteBase.Size

        ' Prueba desde un tamaño grande hacia abajo
        For size As Single = 48 To 8 Step -1
            Using fuentePrueba As New Font(fuenteBase.FontFamily, size, fuenteBase.Style)
                Dim tamañoTexto As Size = TextRenderer.MeasureText(texto, fuentePrueba, New Size(anchoMaximo, altoMaximo), TextFormatFlags.WordBreak)
                If tamañoTexto.Width <= anchoMaximo AndAlso tamañoTexto.Height <= altoMaximo Then
                    tamañoFuente = size
                    Exit For
                End If
            End Using
        Next

        label.Font = New Font(fuenteBase.FontFamily, tamañoFuente, fuenteBase.Style)
        label.Text = texto
        label.TextAlign = ContentAlignment.MiddleCenter
    End Sub
End Class