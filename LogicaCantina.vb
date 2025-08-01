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

    Public Function ValidarLogin(division As String, contraseña As String) As (Exito As Boolean, Motivo As String)
        Try
            Using SQLiteConnection As SQLiteConnection = ObtenerConexion()
                Dim query As String = "SELECT COUNT(*) FROM usuarios WHERE Division = @Division AND Contraseña = @Contraseña"
                Using command As New SQLiteCommand(query, SQLiteConnection)
                    command.Parameters.AddWithValue("@Division", division)
                    command.Parameters.AddWithValue("@Contraseña", contraseña)
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    If count > 0 Then
                        Return (True, "")
                    Else
                        ' Puedes mejorar el motivo según la lógica que desees
                        Return (False, "Los datos no coinciden con los registros")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Return (False, "Error al validar el login: " & ex.Message)
        End Try
    End Function

    Public Function registrarDivision(division As String, contraseña As String) As (Exito As Boolean, Motivo As String)
        Try
            Using SQLiteConnection As SQLiteConnection = ObtenerConexion()
                Dim query As String = "SELECT COUNT(*) FROM usuarios WHERE Division = @Division"
                Using command As New SQLiteCommand(query, SQLiteConnection)
                    command.Parameters.AddWithValue("@Division", division)
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    If count > 0 Then
                        Return (False, "La división ya existe")
                    End If
                End Using
                query = "INSERT INTO usuarios (Division, Contraseña) VALUES (@Division, @Contraseña)"
                Using command As New SQLiteCommand(query, SQLiteConnection)
                    command.Parameters.AddWithValue("@Division", division)
                    command.Parameters.AddWithValue("@Contraseña", contraseña)
                    command.ExecuteNonQuery()
                    Return (True, "Registro exitoso")
                End Using
            End Using
        Catch ex As Exception
            Return (False, "Error al registrar la división: " & ex.Message)
        End Try
    End Function

    Public Function ObtenerTodosLosProductos() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As SQLiteConnection = ObtenerConexion()
                Dim query As String = "SELECT * FROM Producto"
                Using cmd As New SQLiteCommand(query, conn)
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception

        End Try
        Return dt
    End Function

    Public Function FiltrarProductosPorNombre(nombre As String) As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As SQLiteConnection = ObtenerConexion()
                Dim query As String = "SELECT * FROM Producto WHERE Descripcione LIKE @Descripcion"
                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Descripcion", "%" & nombre & "%")
                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception

        End Try
        Return dt
    End Function

End Class