Imports System.Data.SQLite
Imports System.IO

Public Class LogicaCantina
    Public programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
    Public cantinaSarmientoPath As String = Path.Combine(programDataPath, "CantinaSarmiento")
    Public baseDeDatos As String = Path.Combine(cantinaSarmientoPath, "CantinaSarmiento.db")

    Public Function ObtenerConexion() As SQLiteConnection
        Dim connectionString As String = $"Data Source={baseDeDatos};Version=3;"
        Dim conn As New SQLiteConnection(connectionString)
        conn.Open()
        Return conn
    End Function

    Public Function ValidarLogin(division As String, contraseña As String) As Boolean
        Using SQLiteConnection As SQLiteConnection = ObtenerConexion()
            Dim query As String = "SELECT COUNT(*) FROM usuarios WHERE Division = @Division AND Contraseña = @Contraseña"
            Using command As New SQLiteCommand(query, SQLiteConnection)
                command.Parameters.AddWithValue("@Division", division)
                command.Parameters.AddWithValue("@Contraseña", contraseña)
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

End Class