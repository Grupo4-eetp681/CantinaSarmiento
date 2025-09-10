Imports System.Data.SQLite
Imports System.IO

Public Class LogicaCantina
    Public subdivision As String = String.Empty
    Public programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
    Public cantinaSarmientoPath As String = Path.Combine(programDataPath, "CantinaSarmiento")
    Public baseDeDatosUsuarios = Path.Combine(cantinaSarmientoPath, "CantinaSarmiento.db")
    Public baseDeDatos As String = String.Empty

    Public Sub cargarSubdivision(division As String)
        subdivision = division
        baseDeDatos = Path.Combine(cantinaSarmientoPath, $"{subdivision}_CantinaSarmiento.db")
        verificarBaseDeDatos()
    End Sub

    Private Sub verificarBaseDeDatos()
        If Not Directory.Exists(cantinaSarmientoPath) Then
            Directory.CreateDirectory(cantinaSarmientoPath)
        End If
        If Not File.Exists(baseDeDatos) Then
            SQLiteConnection.CreateFile(baseDeDatos)
            Using conn As SQLiteConnection = ObtenerConexion()
                Dim createProductoTable As String = "CREATE TABLE IF NOT EXISTS Producto (IdProducto INTEGER PRIMARY KEY AUTOINCREMENT, Descripcion TEXT, PrecioVenta REAL)"
                Dim createOperacionTable As String = "CREATE TABLE IF NOT EXISTS Operacion (IdOperacion INTEGER PRIMARY KEY AUTOINCREMENT, Descripcion TEXT)"
                Dim createInicioTable As String = "CREATE TABLE IF NOT EXISTS Inicio (Id INTEGER PRIMARY KEY AUTOINCREMENT, Plata REAL, Fecha date)"
                Dim createVentasTable As String = "CREATE TABLE IF NOT EXISTS Ventas (IdVenta INTEGER PRIMARY KEY AUTOINCREMENT, IdProducto INTEGER, Cantidad INTEGER, Fecha DATE, FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto))"
                Dim tablas As String() = {
                        createProductoTable,
                        createOperacionTable,
                        createInicioTable,
                        createVentasTable
                    }
                For Each sql As String In tablas
                    Using cmd As New SQLiteCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End Using
        Else
            ' Verificar que las tablas y columnas estén correctas
            Using conn As SQLiteConnection = ObtenerConexion()
                Dim tablasEsperadas As New Dictionary(Of String, String()) From {
                    {"Producto", New String() {"IdProducto", "Descripcion", "PrecioVenta"}},
                    {"Operacion", New String() {"IdOperacion", "Descripcion"}},
                    {"Inicio", New String() {"Id", "Plata", "Fecha"}},
                    {"Ventas", New String() {"IdVenta", "IdProducto", "Cantidad", "Fecha"}}
                }
                For Each tabla In tablasEsperadas
                    Dim existeTabla As Boolean = False
                    Dim queryTabla As String = "SELECT name FROM sqlite_master WHERE type='table' AND name=@tabla"
                    Using cmd As New SQLiteCommand(queryTabla, conn)
                        cmd.Parameters.AddWithValue("@tabla", tabla.Key)
                        Using reader = cmd.ExecuteReader()
                            existeTabla = reader.HasRows
                        End Using
                    End Using
                    If Not existeTabla Then
                        ' Crear la tabla si no existe
                        Dim createTableSql As String = ""
                        Select Case tabla.Key
                            Case "Producto"
                                createTableSql = "CREATE TABLE IF NOT EXISTS Producto (IdProducto INTEGER PRIMARY KEY AUTOINCREMENT, Descripcion TEXT, PrecioVenta REAL)"
                            Case "Operacion"
                                createTableSql = "CREATE TABLE IF NOT EXISTS Operacion (IdOperacion INTEGER PRIMARY KEY AUTOINCREMENT, Descripcion TEXT)"
                            Case "Inicio"
                                createTableSql = "CREATE TABLE IF NOT EXISTS Inicio (Id INTEGER PRIMARY KEY AUTOINCREMENT, Hora time, Fecha date)"
                            Case "Ventas"
                                createTableSql = "CREATE TABLE IF NOT EXISTS Ventas (IdVenta INTEGER PRIMARY KEY AUTOINCREMENT, IdProducto INTEGER, Cantidad INTEGER, Fecha DATE, FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto))"
                        End Select
                        Using cmd As New SQLiteCommand(createTableSql, conn)
                            cmd.ExecuteNonQuery()
                        End Using
                    Else
                        ' Verificar columnas
                        Dim columnasFaltantes As New List(Of String)
                        Dim queryColumnas As String = $"PRAGMA table_info({tabla.Key})"
                        Dim columnasActuales As New List(Of String)
                        Using cmd As New SQLiteCommand(queryColumnas, conn)
                            Using reader = cmd.ExecuteReader()
                                While reader.Read()
                                    columnasActuales.Add(reader("name").ToString())
                                End While
                            End Using
                        End Using
                        For Each columnaEsperada In tabla.Value
                            If Not columnasActuales.Contains(columnaEsperada) Then
                                columnasFaltantes.Add(columnaEsperada)
                            End If
                        Next
                        ' Si faltan columnas, puedes agregarlas aquí
                        For Each columna In columnasFaltantes
                            Dim tipoColumna As String = "TEXT"
                            Select Case columna
                                Case "IdProducto", "IdOperacion", "IdVenta", "Id"
                                    tipoColumna = "INTEGER"
                                Case "PrecioVenta", "Plata"
                                    tipoColumna = "REAL"
                                Case "Cantidad"
                                    tipoColumna = "INTEGER"
                                Case "Hora"
                                    tipoColumna = "time"
                                Case "Fecha"
                                    tipoColumna = "date"
                            End Select
                            Dim alterSql As String = $"ALTER TABLE {tabla.Key} ADD COLUMN {columna} {tipoColumna}"
                            Using cmd As New SQLiteCommand(alterSql, conn)
                                cmd.ExecuteNonQuery()
                            End Using
                        Next
                    End If
                Next
            End Using
        End If
    End Sub

    Public Sub guardarSesion(division As String)
        Using conn As SQLiteConnection = ObtenerConexionUsuario()
            Dim deleteQuery As String = "DELETE FROM sesion"
            Using deleteCmd As New SQLiteCommand(deleteQuery, conn)
                deleteCmd.ExecuteNonQuery()
            End Using
            Dim insertQuery As String = "INSERT INTO sesion (division) VALUES (@division)"
            Using insertCmd As New SQLiteCommand(insertQuery, conn)
                insertCmd.Parameters.AddWithValue("@division", division)
                insertCmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function verificarSesion() As Boolean
        Using conn As SQLiteConnection = ObtenerConexionUsuario()
            Dim query As String = "SELECT division FROM sesion LIMIT 1"
            Using cmd As New SQLiteCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    Dim division As String = result.ToString()
                    cargarSubdivision(division)
                    Form1.subdivision = division
                    Return True
                End If
            End Using
        End Using
    End Function

    Public Sub verificarBaseDeDatosUsuarios()
        If Not Directory.Exists(cantinaSarmientoPath) Then
            Directory.CreateDirectory(cantinaSarmientoPath)
        End If
        If Not File.Exists(baseDeDatosUsuarios) Then
            SQLiteConnection.CreateFile(baseDeDatosUsuarios)
            Using conn As SQLiteConnection = ObtenerConexionUsuario()
                Dim createUsuarioTable As String = "CREATE TABLE IF NOT EXISTS usuarios (IdUsuario INTEGER PRIMARY KEY AUTOINCREMENT, Division TEXT, Contraseña INTEGER)"
                Dim createSesionTable As String = "CREATE TABLE IF NOT EXISTS sesion (division TEXT)"
                Dim tablas As String() = {
                        createUsuarioTable,
                        createSesionTable
                    }
                For Each sql As String In tablas
                    Using cmd As New SQLiteCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End Using
        End If
    End Sub
    Public Function ObtenerConexion() As SQLiteConnection
        Dim connectionString As String = $"Data Source={baseDeDatos};Version=3;"
        Dim conn As New SQLiteConnection(connectionString)
        conn.Open()
        Return conn
    End Function

    Public Function ObtenerConexionUsuario() As SQLiteConnection
        verificarBaseDeDatosUsuarios()
        Dim connectionString As String = $"Data Source={baseDeDatosUsuarios};Version=3;"
        Dim conn As New SQLiteConnection(connectionString)
        conn.Open()
        Return conn
    End Function

    Public Function ValidarLogin(division As String, contraseña As String) As (Exito As Boolean, Motivo As String)
        Try
            Using SQLiteConnection As SQLiteConnection = ObtenerConexionUsuario()
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
            Using SQLiteConnection As SQLiteConnection = ObtenerConexionUsuario()
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
                Dim query As String = "SELECT IdProducto as ID, Descripcion as Descripción, PrecioVenta as Precio_Unitario FROM Producto"
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
                Dim query As String = "SELECT IdProducto as ID, Descripcion as Descripción, PrecioVenta as Precio_Unitario FROM Producto WHERE Descripcion LIKE @Descripcion"
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

    Public Sub RegistrarVentas(filas As List(Of (Descripcion As String, Cantidad As Integer, Subtotal As Integer, Fecha As Date)))
        Using conn As SQLiteConnection = ObtenerConexion()
            For Each venta In filas
                Dim query As String = "INSERT INTO Ventas (Descripcion, Cantidad, Subtotal, Fecha) VALUES (@Descripcion, @Cantidad, @Subtotal, @Fecha)"
                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Descripcion", venta.Descripcion)
                    cmd.Parameters.AddWithValue("@Cantidad", venta.Cantidad)
                    cmd.Parameters.AddWithValue("@Subtotal", venta.Subtotal)
                    cmd.Parameters.AddWithValue("@Fecha", venta.Fecha.ToString("yyyy-MM-dd"))
                    cmd.ExecuteNonQuery()
                End Using
            Next
        End Using
    End Sub

    Public Sub cerrarSesion()
        Using conn As SQLiteConnection = ObtenerConexionUsuario()
            Dim deleteQuery As String = "DELETE FROM sesion"
            Using deleteCmd As New SQLiteCommand(deleteQuery, conn)
                deleteCmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function obtenerVentas() As DataTable
        Dim dt As New DataTable()
        Using conn As SQLiteConnection = ObtenerConexion()
            Dim query As String = "SELECT p.Descripcion AS Producto, v.Cantidad, v.Fecha " &
                                  "FROM Ventas v " &
                                  "INNER JOIN Producto p ON v.IdProducto = p.IdProducto"
            Using cmd As New SQLiteCommand(query, conn)
                Using da As New SQLiteDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Function obtenerPlata() As Int128
        Using conn As SQLiteConnection = ObtenerConexion()
            Dim query As String = "SELECT plata FROM Inicio"
            Using cmd As New SQLiteCommand(query, conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                    Return result
                Else
                    Return 0
                End If
            End Using
        End Using
    End Function

End Class