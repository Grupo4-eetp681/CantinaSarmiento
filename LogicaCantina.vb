Imports System.Data.SQLite
Imports System.IO
Imports System.Text
Imports PdfSharp.Drawing
Imports PdfSharp.Fonts
Imports PdfSharp.Pdf

Public Class LogicaCantina
    Public subdivision As String = String.Empty
    Public programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
    Public cantinaSarmientoPath As String = Path.Combine(programDataPath, "CantinaSarmiento")
    Public baseDeDatosUsuarios = Path.Combine(cantinaSarmientoPath, "CantinaSarmiento.db")
    Public baseDeDatos As String = String.Empty
    Public OrigenTienePrioridad As Boolean = False

    Public Sub cargarSubdivision(division As String)
        subdivision = division
        baseDeDatos = Path.Combine(cantinaSarmientoPath, $"{subdivision}_CantinaSarmiento.db")
        verificarBaseDeDatos()
    End Sub

    Public Sub CargarListaDefault()
        Dim productos As (String, Double, Double)() = {
        ("Carpa", 12000, 0),
        ("Casilla", 20000, 0),
        ("Tablon", 10000, 0),
        ("Asador", 10000, 0),
        ("Carbón 5 KG", 4000, 0),
        ("Carbón 12 KG", 8000, 0),
        ("Papel Higiénico x1", 1000, 0),
        ("Papel Higiénico x4", 3000, 0),
        ("Servilleta de papel x1 rollo", 1000, 0),
        ("Servilleta de papel x3 rollos", 2500, 0),
        ("Pañuelos descartables", 500, 0),
        ("Algodón", 1500, 0),
        ("Bolsa residuos", 1500, 0),
        ("Arroz 1/2 KG", 2000, 0),
        ("Pure de tomate", 1500, 0),
        ("Provenzal", 2500, 0),
        ("Pimentón", 1500, 0),
        ("Fideos Spaguettis", 1800, 0),
        ("Fideos guiseros", 1600, 0),
        ("Queso rallado", 200, 0),
        ("Aceite x900 ML", 2800, 0),
        ("Vinagre", 1500, 0),
        ("Sal entrefina", 1500, 0),
        ("Sal fina", 1200, 0),
        ("Jugo de limon", 1500, 0),
        ("Aceitunas", 2000, 0),
        ("Mostaza", 1500, 0),
        ("Mayonesa", 1500, 0),
        ("Harina común kilo", 1500, 0),
        ("Edulcorante", 2500, 0),
        ("Dulce de leche", 2000, 0),
        ("Escarbadientes", 1000, 0),
        ("Encendedor", 1500, 0),
        ("Detergente", 2500, 0),
        ("Esponja platos", 2500, 0),
        ("Espirales x2", 1000, 0),
        ("Insecticida fuyi", 5000, 0),
        ("Hielo", 1000, 0),
        ("Jugo tang", 500, 0),
        ("Agua mineral x5 Litros", 4000, 0),
        ("Baggio 200 ML", 500, 0),
        ("Baggio Litro", 300, 0),
        ("Fernet 450 ML", 7000, 0),
        ("Gancia Litro", 6000, 0),
        ("Vino tinto toro Litro", 3000, 0),
        ("Soda 2 Litros", 1500, 0),
        ("Salamin", 3500, 0),
        ("Bizcochos", 2500, 0),
        ("Pan", 2000, 0),
        ("Banana/Manzana x Unidad", 1000, 0),
        ("Ensalada tricolor", 2500, 0),
        ("Chorizo parilleros bolsita", 6000, 0),
        ("Hamburguezas patty x4", 3500, 0),
        ("Ensalada de frutas", 2500, 0),
        ("Pebete de jamón y queso", 1500, 0),
        ("Sandwich de miga 6", 4500, 0),
        ("Empanada de carne/J y Q", 1500, 0),
        ("Cigarrillos", 2500, 0),
        ("Yerba sinceridad x 1/2 KG", 2500, 0),
        ("Azúcar", 2000, 0),
        ("Leche entera ilolay", 2500, 0),
        ("Té la virginia caja", 1500, 0),
        ("Té la virginia saquito", 300, 0),
        ("Café x 50G", 2500, 0),
        ("Café saquito", 500, 0),
        ("Mate cocido x1 saquito", 300, 0),
        ("Mate cocido x caja", 2500, 0),
        ("Cacao x 200g", 2000, 0),
        ("Chocolatada litro", 3000, 0),
        ("Toallitas húmedas", 4500, 0),
        ("Repelente", 9000, 0),
        ("Toallitas femeninas", 4500, 0),
        ("Jabón de tocador", 1500, 0),
        ("Desodrante rexona", 2500, 0),
        ("Shampo", 3000, 0),
        ("Acondicionador", 3000, 0),
        ("Protector solar", 17000, 0),
        ("Esponja para baño", 1000, 0),
        ("Pañales x8", 5000, 0),
        ("Papas fritas snack", 1500, 0),
        ("Chalitas", 2000, 0),
        ("Chizitos", 1500, 0),
        ("Palitos", 1500, 0),
        ("Maní", 2500, 0),
        ("Rex", 2000, 0),
        ("Saladix", 2000, 0),
        ("Fajita saborizada", 2000, 0),
        ("Galletitas dulces trio", 2000, 0),
        ("Galletitas media tarde x3", 2000, 0),
        ("Tostadas de arroz", 2500, 0),
        ("Galletitas con semillas", 2500, 0),
        ("Galletita granix salada x1", 2000, 0),
        ("Bizcochos don satur", 2000, 0),
        ("Bizcochos de arroz", 2500, 0),
        ("Jugitos congelados", 500, 0),
        ("Turrón miski", 300, 0),
        ("Alfajor simple", 500, 0),
        ("Barritas de cereal", 1500, 0),
        ("Pipas", 500, 0),
        ("Alfajor rasta", 2000, 0)
    }

        Using conn As SQLiteConnection = ObtenerConexion()
        For Each prod In productos
            Dim desc As String = prod.Item1
            Dim venta As Double = prod.Item2
            Dim costo As Double = prod.Item3
            Dim ganancia As Double = venta - costo

            Dim query As String = "INSERT OR IGNORE INTO Producto (Descripcion, PrecioVenta, PrecioCosto, Ganancia) 
                                   VALUES (@desc, @venta, @costo, @ganancia)"
            Using cmd As New SQLiteCommand(query, conn)
                cmd.Parameters.AddWithValue("@desc", desc)
                cmd.Parameters.AddWithValue("@venta", venta)
                cmd.Parameters.AddWithValue("@costo", costo)
                cmd.Parameters.AddWithValue("@ganancia", ganancia)
                cmd.ExecuteNonQuery()
            End Using
        Next
    End Using
End Sub


    Public Sub verificarBaseDeDatos()
        If Not Directory.Exists(cantinaSarmientoPath) Then
            Directory.CreateDirectory(cantinaSarmientoPath)
        End If

        If Not File.Exists(baseDeDatos) Then
            SQLiteConnection.CreateFile(baseDeDatos)
            Using conn As SQLiteConnection = ObtenerConexion()
                ' Crear todas las tablas desde cero
                Dim createProductoTable As String = "CREATE TABLE IF NOT EXISTS Producto (" &
                "IdProducto INTEGER PRIMARY KEY AUTOINCREMENT, " &
                "Descripcion TEXT UNIQUE, " &
                "PrecioVenta REAL, " &
                "PrecioCosto REAL, " &
                "Ganancia REAL)"

                Dim createVentasTable As String = "CREATE TABLE IF NOT EXISTS Ventas (" &
                "IdVenta INTEGER PRIMARY KEY AUTOINCREMENT, " &
                "Descripcion TEXT, " &
                "Cantidad INTEGER, " &
                "Subtotal REAL, " &
                "FechaYHora TEXT)"

                Dim createAdvertenciasTable As String = "CREATE TABLE IF NOT EXISTS Advertencias (" &
                "Id INTEGER PRIMARY KEY AUTOINCREMENT, " &
                "Origen TEXT UNIQUE, " &
                "NoMostrar INTEGER DEFAULT 0)"

                Dim createCajaTable As String = "CREATE TABLE IF NOT EXISTS Caja (" &
                "Id INTEGER PRIMARY KEY AUTOINCREMENT, " &
                "Inicio REAL, " &
                "Retiros REAL, " &
                "VentasEfectivo REAL, " &
                "VentasTransferencias REAL, " &
                "Total REAL)"

                Dim tablas As String() = {
                createProductoTable,
                createVentasTable,
                createAdvertenciasTable,
                createCajaTable
            }

                For Each sql As String In tablas
                    Using cmd As New SQLiteCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End Using
        Else
            ' Base de datos existe, verificar estructura
            Using conn As SQLiteConnection = ObtenerConexion()
                ' Tablas esperadas con sus columnas ACTUALIZADAS
                Dim tablasEsperadas As New Dictionary(Of String, String()) From {
                {"Producto", New String() {"IdProducto", "Descripcion", "PrecioVenta", "PrecioCosto", "Ganancia"}},
                {"Ventas", New String() {"IdVenta", "Descripcion", "Cantidad", "Subtotal", "FechaYHora"}},
                {"Advertencias", New String() {"Id", "Origen", "NoMostrar"}},
                {"Caja", New String() {"Id", "Inicio", "Retiros", "VentasEfectivo", "VentasTransferencias", "Total"}}
            }

                ' Eliminar la tabla Inicio si existe (ya no la necesitamos)
                Dim dropInicio As String = "DROP TABLE IF EXISTS Inicio"
                Using cmdDrop As New SQLiteCommand(dropInicio, conn)
                    cmdDrop.ExecuteNonQuery()
                End Using

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
                                createTableSql = "CREATE TABLE IF NOT EXISTS Producto (" &
                                "IdProducto INTEGER PRIMARY KEY AUTOINCREMENT, " &
                                "Descripcion TEXT, " &
                                "PrecioVenta REAL, " &
                                "PrecioCosto REAL, " &
                                "Ganancia REAL)"
                            Case "Ventas"
                                createTableSql = "CREATE TABLE IF NOT EXISTS Ventas (" &
                                "IdVenta INTEGER PRIMARY KEY AUTOINCREMENT, " &
                                "Descripcion TEXT, " &
                                "Cantidad INTEGER, " &
                                "Subtotal REAL, " &
                                "FechaYHora TEXT)"
                            Case "Advertencias"
                                createTableSql = "CREATE TABLE IF NOT EXISTS Advertencias (" &
                                "Id INTEGER PRIMARY KEY AUTOINCREMENT, " &
                                "Origen TEXT UNIQUE, " &
                                "NoMostrar INTEGER DEFAULT 0)"
                            Case "Caja"
                                createTableSql = "CREATE TABLE IF NOT EXISTS Caja (" &
                                "Id INTEGER PRIMARY KEY AUTOINCREMENT, " &
                                "Inicio REAL, " &
                                "Retiros REAL, " &
                                "VentasEfectivo REAL, " &
                                "VentasTransferencias REAL," &
                                "Total REAL)"
                        End Select
                        Using cmd As New SQLiteCommand(createTableSql, conn)
                            cmd.ExecuteNonQuery()
                        End Using
                    Else
                        ' Verificar y agregar columnas faltantes
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

                        ' Agregar las columnas faltantes
                        For Each columna In columnasFaltantes
                            Dim tipoColumna As String = "REAL"
                            Dim defaultValue As String = ""

                            Select Case columna
                                Case "Id", "IdProducto", "IdVenta", "Cantidad"
                                    tipoColumna = "INTEGER"
                                Case "Descripcion", "Origen", "FechaYHora"
                                    tipoColumna = "TEXT"
                                Case "NoMostrar"
                                    tipoColumna = "INTEGER"
                                    defaultValue = " DEFAULT 0"
                                Case "PrecioVenta", "PrecioCosto", "Ganancia", "Subtotal", "Inicio", "Retiros", "VentasEfectivo", "VentasTransferencias", "Total"
                                    tipoColumna = "REAL"
                            End Select

                            Dim alterSql As String = $"ALTER TABLE {tabla.Key} ADD COLUMN {columna} {tipoColumna}{defaultValue}"
                            Try
                                Using cmd As New SQLiteCommand(alterSql, conn)
                                    cmd.ExecuteNonQuery()
                                End Using
                            Catch ex As Exception
                                ' Ignorar errores de columnas que ya existen
                                Console.WriteLine($"Advertencia al agregar columna {columna}: {ex.Message}")
                            End Try
                        Next
                    End If
                Next

                ' Verificar y aplicar constrains únicos si es necesario
                Try
                    ' Para la tabla Advertencias, asegurar que Origen sea UNIQUE
                    Dim checkUnique As String = "SELECT sql FROM sqlite_master WHERE type='table' AND name='Advertencias'"
                    Using cmd As New SQLiteCommand(checkUnique, conn)
                        Dim tableSql As String = cmd.ExecuteScalar()?.ToString()
                        If Not String.IsNullOrEmpty(tableSql) AndAlso Not tableSql.Contains("UNIQUE") Then
                            ' Si no tiene el constraint UNIQUE, crear índice único
                            Dim createUniqueIndex As String = "CREATE UNIQUE INDEX IF NOT EXISTS idx_advertencias_origen ON Advertencias(Origen)"
                            Using cmdIndex As New SQLiteCommand(createUniqueIndex, conn)
                                cmdIndex.ExecuteNonQuery()
                            End Using
                        End If
                    End Using
                Catch ex As Exception
                    ' Ignorar errores de índices
                    Console.WriteLine($"Advertencia al crear índice único: {ex.Message}")
                End Try
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
                Dim query As String = "SELECT IdProducto as ID, Descripcion as Descripción, PrecioVenta as Precio FROM Producto ORDER BY Descripcion ASC"
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
                Dim query As String = "SELECT IdProducto as ID, Descripcion as Descripción, PrecioVenta as Precio FROM Producto WHERE Descripcion LIKE @Descripcion"
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
                Dim query As String = "INSERT INTO Ventas (Descripcion, Cantidad, Subtotal, FechaYHora) VALUES (@Descripcion, @Cantidad, @Subtotal, @FechaYHora)"
                Using cmd As New SQLiteCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Descripcion", venta.Descripcion)
                    cmd.Parameters.AddWithValue("@Cantidad", venta.Cantidad)
                    cmd.Parameters.AddWithValue("@Subtotal", venta.Subtotal)
                    cmd.Parameters.AddWithValue("@FechaYHora", venta.Fecha.ToString("yyyy-MM-dd : HH-mm-ss"))
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
            Dim query As String = "SELECT Descripcion as Descripción, Cantidad, Subtotal, FechaYHora as Fecha " &
                                  "FROM Ventas v "
            Using cmd As New SQLiteCommand(query, conn)
                Using da As New SQLiteDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ' Verifica si existe una advertencia registrada y devuelve el estado
    Public Function ObtenerEstadoAdvertencia(origen As String) As Boolean
        Using conn As SQLiteConnection = ObtenerConexion()
            Dim query As String = "SELECT NoMostrar FROM Advertencias WHERE Origen = @origen"
            Using cmd As New SQLiteCommand(query, conn)
                cmd.Parameters.AddWithValue("@origen", origen)

                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Convert.ToInt32(result) = 1 Then
                    Return True ' No mostrar más
                End If
            End Using
        End Using
        Return False ' Por defecto, mostrar
    End Function

    ' Inserta o actualiza una advertencia
    Public Sub GuardarEstadoAdvertencia(origen As String, noMostrar As Boolean)
        Using conn As SQLiteConnection = ObtenerConexion()
            Dim query As String = "
                INSERT INTO Advertencias (Origen, NoMostrar)
                VALUES (@origen, @noMostrar)
                ON CONFLICT(Origen) DO UPDATE SET NoMostrar = excluded.NoMostrar;
            "

            Using cmd As New SQLiteCommand(query, conn)
                cmd.Parameters.AddWithValue("@origen", origen)
                cmd.Parameters.AddWithValue("@noMostrar", If(noMostrar, 1, 0))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub advertenciasFalse()
        Using conn As SQLiteConnection = ObtenerConexion()
            Dim query As String = "UPDATE Advertencias SET NoMostrar = 0"
            Using cmd As New SQLiteCommand(query, conn)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub ActualizarInicio(valor As Double)
        Using conn As SQLiteConnection = ObtenerConexion()
            ' Primero verificamos si hay registro en Caja
            Dim existeRegistro As Boolean = False
            Dim idRegistro As Integer = -1
            Using cmd As New SQLiteCommand("SELECT Id FROM Caja LIMIT 1", conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    existeRegistro = True
                    idRegistro = Convert.ToInt32(result)
                End If
            End Using

            ' Si no existe, lo creamos vacío
            If Not existeRegistro Then
                Dim insertSql As String = "INSERT INTO Caja (Inicio, Retiros, VentasEfectivo, VentasTransferencias, Total) VALUES (0, 0, 0, 0, 0)"
                Using cmd As New SQLiteCommand(insertSql, conn)
                    cmd.ExecuteNonQuery()
                End Using
                idRegistro = CInt(conn.LastInsertRowId)
            End If

            ' Actualizamos la columna sumando el valor
            Dim updateSql As String = $"UPDATE Caja SET Inicio = IFNULL({valor}, 0)"
            Using cmd As New SQLiteCommand(updateSql, conn)
                cmd.Parameters.AddWithValue("@valor", valor)
                cmd.Parameters.AddWithValue("@id", idRegistro)
                cmd.ExecuteNonQuery()
            End Using
        End Using
        ActualizarCaja("Inicio", 0)
    End Sub

    Public Sub ActualizarCaja(columna As String, valor As Double)
        Using conn As SQLiteConnection = ObtenerConexion()

            ' Primero verificamos si hay registro en Caja
            Dim existeRegistro As Boolean = False
            Dim idRegistro As Integer = -1
            Using cmd As New SQLiteCommand("SELECT Id FROM Caja LIMIT 1", conn)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    existeRegistro = True
                    idRegistro = Convert.ToInt32(result)
                End If
            End Using

            ' Si no existe, lo creamos vacío
            If Not existeRegistro Then
                Dim insertSql As String = "INSERT INTO Caja (Inicio, Retiros, VentasEfectivo, VentasTransferencia, Total) VALUES (0, 0, 0, 0, 0)"
                Using cmd As New SQLiteCommand(insertSql, conn)
                    cmd.ExecuteNonQuery()
                End Using
                idRegistro = CInt(conn.LastInsertRowId)
            End If

            ' Actualizamos la columna sumando el valor
            Dim updateSql As String = $"UPDATE Caja SET {columna} = IFNULL({columna}, 0) + @valor WHERE Id=@id"
            Using cmd As New SQLiteCommand(updateSql, conn)
                cmd.Parameters.AddWithValue("@valor", valor)
                cmd.Parameters.AddWithValue("@id", idRegistro)
                cmd.ExecuteNonQuery()
            End Using

            ' Recalcular el total
            Dim recalcularSql As String = "UPDATE Caja SET Total = IFNULL(Inicio,0) - IFNULL(Retiros,0) + IFNULL(VentasEfectivo,0) + IFNULL(VentasTransferencias,0) WHERE Id=@id"
            Using cmd As New SQLiteCommand(recalcularSql, conn)
                cmd.Parameters.AddWithValue("@id", idRegistro)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function obtenerCaja() As (Inicio As Double, Retiros As Double, Ventas As Double, Transferencias As Double, Total As Double)
        Using conn As SQLiteConnection = ObtenerConexion()
            Dim query As String = "SELECT Inicio, Retiros, VentasEfectivo, VentasTransferencias, Total FROM Caja LIMIT 1"
            Using cmd As New SQLiteCommand(query, conn)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim inicio As Double = If(Not IsDBNull(reader("Inicio")), Convert.ToDouble(reader("Inicio")), 0)
                        Dim retiros As Double = If(Not IsDBNull(reader("Retiros")), Convert.ToDouble(reader("Retiros")), 0)
                        Dim ventas As Double = If(Not IsDBNull(reader("VentasEfectivo")), Convert.ToDouble(reader("VentasEfectivo")), 0)
                        Dim transferencias As Double = If(Not IsDBNull(reader("VentasTransferencias")), Convert.ToDouble(reader("VentasTransferencias")), 0)
                        Dim total As Double = If(Not IsDBNull(reader("Total")), Convert.ToDouble(reader("Total")), 0)
                        Return (inicio, retiros, ventas, transferencias, total)
                    End If
                End Using
            End Using
        End Using
        Return (0, 0, 0, 0, 0)
    End Function

    Public Sub GenerarCierreCajaPDF(DataGridViewCAJA As DataGridView)
        GlobalFontSettings.FontResolver = New CustomFontResolver()
        Dim font As New XFont("Calibri", 12)
        Dim doc As New PdfDocument()
        doc.Info.Title = "Cierre de Caja"
        Dim page As PdfPage = doc.AddPage()
        Dim pageHeight As Double = page.Height.Point ' Altura total de la página
        Dim marginBottom As Double = 40 ' Margen inferior
        Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
        Dim fontTitulo As New XFont("Helvetica", 14)
        Dim fontNormal As New XFont("Helvetica", 10)
        Dim fontResaltado As New XFont("Helvetica", 11)

        Dim y As Double = 40
        gfx.DrawString("CIERRE DE CAJA", fontTitulo, XBrushes.Black, 40, y)
        y += 25
        gfx.DrawString("Fecha: " & Date.Now.ToString("dd/MM/yyyy HH:mm"), fontNormal, XBrushes.Black, 40, y)
        y += 25
        gfx.DrawString(New String("-"c, 80), fontNormal, XBrushes.Black, 40, y)
        y += 25

        Dim totalVentas As Double = 0
        Dim totalGanancia As Double = 0

        ' --- Detalle de cada venta ---
        Using conn As SQLiteConnection = ObtenerConexion()
            For Each fila As DataGridViewRow In DataGridViewCAJA.Rows
                If fila.IsNewRow Then Continue For

                Dim descripcion As String = fila.Cells("Descripción").Value.ToString()
                Dim cantidad As Integer = Convert.ToInt32(fila.Cells("Cantidad").Value)
                Dim subtotal As Double = Convert.ToDouble(fila.Cells("Subtotal").Value)

                ' Obtener ganancia del producto desde la base de datos
                Dim gananciaProducto As Double = 0
                Using cmd As New SQLiteCommand("SELECT Ganancia FROM Producto WHERE Descripcion=@desc", conn)
                    cmd.Parameters.AddWithValue("@desc", descripcion)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        gananciaProducto = Convert.ToDouble(result)
                    End If
                End Using

                Dim subtotalGanancia As Double = gananciaProducto * cantidad
                totalGanancia += subtotalGanancia

                Dim linea As String = $"{descripcion} x{cantidad} - ${subtotal:N0} (Ganancia: ${subtotalGanancia:N0})"

                ' --- Salto de página automático ---
                If y + 20 > page.Height.Point - 40 Then
                    page = doc.AddPage()
                    gfx = XGraphics.FromPdfPage(page)
                    y = 40 ' Reiniciar posición en la nueva página
                End If

                ' Dibujar línea
                gfx.DrawString(linea, fontNormal, XBrushes.Black, 40, y)
                y += 20
            Next
        End Using

        y += 10
        gfx.DrawString(New String("-"c, 80), fontNormal, XBrushes.Black, 40, y)
        y += 25

        ' --- Resumen por producto ---
        gfx.DrawString("RESUMEN DE VENTAS POR PRODUCTO", fontResaltado, XBrushes.Black, 40, y)
        y += 25
        gfx.DrawString(New String("-"c, 80), fontNormal, XBrushes.Black, 40, y)
        y += 25

        ' Agrupar y contar productos
        Dim resumenVentas As New Dictionary(Of String, (Cantidad As Integer, Total As Double))
        For Each fila As DataGridViewRow In DataGridViewCAJA.Rows
            If fila.IsNewRow Then Continue For
            Dim descripcion As String = fila.Cells("Descripción").Value.ToString()
            Dim cantidad As Integer = Convert.ToInt32(fila.Cells("Cantidad").Value)
            Dim subtotal As Double = Convert.ToDouble(fila.Cells("Subtotal").Value)
            If resumenVentas.ContainsKey(descripcion) Then
                resumenVentas(descripcion) = (resumenVentas(descripcion).Cantidad + cantidad, resumenVentas(descripcion).Total + subtotal)
            Else
                resumenVentas(descripcion) = (cantidad, subtotal)
            End If
        Next

        For Each kvp In resumenVentas

            If y + 20 > page.Height.Point - marginBottom Then
                page = doc.AddPage()
                gfx = XGraphics.FromPdfPage(page)
                y = 40 ' reiniciar posición en la nueva página
            End If

            Dim lineaResumen As String = $"{kvp.Key} - Cantidad total: {kvp.Value.Cantidad} - Total vendido: ${kvp.Value.Total:N0}"
            gfx.DrawString(lineaResumen, fontNormal, XBrushes.Black, 40, y)
            y += 20
        Next

        y += 10
        gfx.DrawString(New String("-"c, 80), fontNormal, XBrushes.Black, 40, y)
        y += 25

        ' --- Totales desde la tabla Caja ---
        Using conn As SQLiteConnection = ObtenerConexion()
            Dim cmd As New SQLiteCommand("SELECT Inicio, Retiros, VentasEfectivo, VentasTransferencias, Total FROM Caja LIMIT 1", conn)
            Using reader = cmd.ExecuteReader()
                If reader.Read() Then
                    Dim inicio As Double = Convert.ToDouble(reader("Inicio"))
                    Dim retiros As Double = Convert.ToDouble(reader("Retiros"))
                    Dim ventas As Double = Convert.ToDouble(reader("VentasEfectivo"))
                    Dim transferencias As Double = Convert.ToDouble(reader("VentasTransferencias"))
                    Dim total As Double = Convert.ToDouble(reader("Total"))

                    gfx.DrawString($"Dinero inicial: ${inicio:N0}", fontNormal, XBrushes.Black, 40, y) : y += 20
                    gfx.DrawString($"Ventas en efectivo: ${ventas:N0}", fontNormal, XBrushes.Black, 40, y) : y += 20
                    gfx.DrawString($"Ventas por transferencia: ${transferencias:N0}", fontNormal, XBrushes.Black, 40, y) : y += 20
                    gfx.DrawString($"Retiros: ${retiros:N0}", fontNormal, XBrushes.Black, 40, y) : y += 20
                    gfx.DrawString($"TOTAL EN CAJA: ${total:N0}", fontResaltado, XBrushes.Black, 40, y) : y += 25
                End If
            End Using
        End Using

        gfx.DrawString($"Ganancia total: ${totalGanancia:N0}", fontResaltado, XBrushes.Black, 40, y)

        Dim fechayhora As String = Date.Now.ToString("yyyyMMdd_HHmmss")
        Dim ruta As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CierreCaja_" + fechayhora + ".pdf")
        doc.Save(ruta)
        doc.Close()
    End Sub

    Public Sub CerrarCaja()
        Using conn As SQLiteConnection = ObtenerConexion()
            ' Borrar todos los registros de Ventas
            Using cmdVentas As New SQLiteCommand("DELETE FROM Ventas", conn)
                cmdVentas.ExecuteNonQuery()
            End Using
            ' Borrar todos los registros de Caja
            Using cmdCaja As New SQLiteCommand("DELETE FROM Caja", conn)
                cmdCaja.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function ActualizarProducto(idProducto As Integer, descripcion As String, precioVenta As Double, precioCosto As Double) As Integer
        Dim ganancia As Double = precioVenta - precioCosto
        Using conn As SQLiteConnection = ObtenerConexion()
            Dim query As String = "UPDATE Producto SET Descripcion = @desc, PrecioVenta = @venta, PrecioCosto = @costo, Ganancia = @ganancia WHERE IdProducto = @id"
            Using cmd As New SQLiteCommand(query, conn)
                cmd.Parameters.AddWithValue("@desc", descripcion)
                cmd.Parameters.AddWithValue("@venta", precioVenta)
                cmd.Parameters.AddWithValue("@costo", precioCosto)
                cmd.Parameters.AddWithValue("@ganancia", ganancia)
                cmd.Parameters.AddWithValue("@id", idProducto)
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Public Function ObtenerTodosLosProductosInventario() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As SQLiteConnection = ObtenerConexion()
                Dim query As String = "SELECT IdProducto as ID, Descripcion as Descripción, PrecioVenta as Precio_Unitario, PrecioCosto as Precio_Costo, Ganancia as Ganancia FROM Producto"
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

    ' INSERTAR PRODUCTO VACÍO Y DEVOLVER EL ID
    Public Function InsertarProductoVacio() As Integer
        Using conn As SQLiteConnection = ObtenerConexion()
            Dim query As String =
                "INSERT INTO Producto (Descripcion, PrecioVenta, PrecioCosto, Ganancia) 
             VALUES ('', 0, 0, 0); 
             SELECT last_insert_rowid();"

            Using cmd As New SQLiteCommand(query, conn)
                Return Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
    End Function


    ' ELIMINAR PRODUCTO POR ID
    Public Sub EliminarProducto(idProducto As Integer)
        Using conn As SQLiteConnection = ObtenerConexion()
            Dim query As String = "DELETE FROM Producto WHERE IdProducto = @id"
            Using cmd As New SQLiteCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", idProducto)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function verificarCaja() As Boolean
        Using conn As SQLiteConnection = ObtenerConexion()
            Dim query As String = "SELECT COUNT(*) FROM Caja"
            Using cmd As New SQLiteCommand(query, conn)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    Return False
                Else
                    Return True
                End If
            End Using
        End Using
    End Function

    Public Sub ExportarProductos()
        Try
            ' Obtener los datos usando tu función existente
            Dim dtProductos As DataTable = ObtenerTodosLosProductosInventario()

            If dtProductos Is Nothing OrElse dtProductos.Rows.Count = 0 Then
                MessageBox.Show("No hay productos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Configurar el diálogo para guardar archivo
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Archivo CSV (*.csv)|*.csv|Archivo de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            saveFileDialog.FilterIndex = 1
            saveFileDialog.DefaultExt = "csv"
            saveFileDialog.FileName = $"Productos_Inventario_{DateTime.Now:yyyyMMdd_HHmmss}"
            saveFileDialog.Title = "Guardar exportación de productos"
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

            ' Mostrar el diálogo
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                ' Llamar a la función que hace la exportación real
                ExportarDataTableAArchivo(dtProductos, saveFileDialog.FileName)

                ' Confirmar que se exportó correctamente
                MessageBox.Show($"Productos exportados exitosamente a:{Environment.NewLine}{saveFileDialog.FileName}{Environment.NewLine}{Environment.NewLine}Total de productos: {dtProductos.Rows.Count}",
                              "Exportación Completada",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show($"Error al exportar prodctos:{Environment.NewLine}{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportarDataTableAArchivo(productos As DataTable, rutaArchivo As String)
        Using writer As New StreamWriter(rutaArchivo, False, Encoding.UTF8)
            ' Escribir encabezados
            Dim encabezados As New List(Of String)()
            For Each columna As DataColumn In productos.Columns
                encabezados.Add(columna.ColumnName)
            Next
            writer.WriteLine(String.Join(",", encabezados))

            ' Escribir datos
            For Each fila As DataRow In productos.Rows
                Dim valores As New List(Of String)()
                For Each valor As Object In fila.ItemArray
                    ' Escapar comillas y manejar valores nulos
                    Dim valorTexto As String = If(valor Is Nothing OrElse IsDBNull(valor), "", valor.ToString())

                    ' Si contiene comas o comillas, envolver en comillas dobles
                    If valorTexto.Contains(",") OrElse valorTexto.Contains("""") OrElse valorTexto.Contains(vbCrLf) Then
                        valorTexto = """" & valorTexto.Replace("""", """""") & """"
                    End If

                    valores.Add(valorTexto)
                Next
                writer.WriteLine(String.Join(",", valores))
            Next
        End Using
    End Sub

    Public Sub ImportarProductos()
        Try
            ' Paso 1: Seleccionar archivo
            Dim archivoSeleccionado As String = SeleccionarArchivo()
            If String.IsNullOrEmpty(archivoSeleccionado) Then Return

            ' Paso 2: Mostrar tu formulario de prioridad
            Dim formPrioridad As New PrioridadImportacion()
            formPrioridad.ShowDialog()

            ' Paso 3: Procesar según la prioridad elegida
            ProcesarImportacion(archivoSeleccionado)

        Catch ex As Exception
        End Try
    End Sub

    ' Seleccionar archivo de origen
    Private Function SeleccionarArchivo() As String
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv|Archivos de texto (*.txt)|*.txt"
        openFileDialog.Title = "Seleccionar archivo de productos"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Return openFileDialog.FileName
        End If

        Return Nothing
    End Function

    ' Procesar la importación según la prioridad
    Private Sub ProcesarImportacion(rutaArchivo As String)
        Dim lineas As String() = File.ReadAllLines(rutaArchivo)
        If lineas.Length < 2 Then
            MessageBox.Show("Archivo vacío o sin datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim encabezados As String() = lineas(0).Split(","c)
        Dim nuevos As Integer = 0
        Dim actualizados As Integer = 0
        Dim ignorados As Integer = 0

        Using conn As SQLiteConnection = ObtenerConexion()
            For i As Integer = 1 To lineas.Length - 1
                Try
                    Dim valores As String() = lineas(i).Split(","c)

                    If OrigenTienePrioridad Then
                        ' UPDATE + INSERT: Los datos del archivo tienen prioridad
                        Dim yaExiste As Boolean = ProductoExiste(conn, valores(1))
                        If InsertarOActualizar(conn, valores) Then
                            If yaExiste Then
                                actualizados += 1
                            Else
                                nuevos += 1
                            End If
                        End If
                    Else
                        ' SOLO INSERT: Solo productos nuevos
                        If Not ProductoExiste(conn, valores(1)) Then
                            If InsertarNuevo(conn, valores) Then
                                nuevos += 1
                            End If
                        Else
                            ignorados += 1
                        End If
                    End If

                Catch ex As Exception
                End Try
            Next
        End Using
    End Sub

    ' Verificar si producto existe
    Private Function ProductoExiste(conn As SQLiteConnection, descripcion As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM Producto WHERE Descripcion = @desc"
        Using cmd As New SQLiteCommand(query, conn)
            cmd.Parameters.AddWithValue("@desc", descripcion)
            Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    ' INSERT + UPDATE (cuando origen tiene prioridad)
    Private Function InsertarOActualizar(conn As SQLiteConnection, valores As String()) As Boolean
        Dim query As String = "
    INSERT INTO Producto (Descripcion, PrecioVenta, PrecioCosto, Ganancia)
    VALUES (@desc, @precioVenta, @precioCosto, @ganancia)
    ON CONFLICT(Descripcion) DO UPDATE SET 
        PrecioVenta = excluded.PrecioVenta,
        PrecioCosto = excluded.PrecioCosto,
        Ganancia = excluded.Ganancia;
    "

        Dim descNormalizado As String = valores(1).Trim()

        Using cmd As New SQLiteCommand(query, conn)
            cmd.Parameters.AddWithValue("@desc", descNormalizado)
            cmd.Parameters.AddWithValue("@precioVenta", Convert.ToDecimal(valores(2)))
            cmd.Parameters.AddWithValue("@precioCosto", Convert.ToDecimal(valores(3)))
            cmd.Parameters.AddWithValue("@ganancia", Convert.ToDecimal(valores(4)))
            cmd.ExecuteNonQuery()
            Return True
        End Using
    End Function


    ' SOLO INSERT (cuando destino tiene prioridad)
    Private Function InsertarNuevo(conn As SQLiteConnection, valores As String()) As Boolean
        Dim query As String = "
        INSERT INTO Producto (IdProducto, Descripcion, PrecioVenta, PrecioCosto, Ganancia)
        VALUES (@id, @desc, @precioVenta, @precioCosto, @ganancia);
    "


        Dim descNormalizado As String = valores(1).Trim()

        Using cmd As New SQLiteCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", valores(0))
            cmd.Parameters.AddWithValue("@desc", descNormalizado)
            cmd.Parameters.AddWithValue("@precioVenta", Convert.ToDecimal(valores(2)))
            cmd.Parameters.AddWithValue("@precioCosto", Convert.ToDecimal(valores(3)))
            cmd.Parameters.AddWithValue("@ganancia", Convert.ToDecimal(valores(4)))
            cmd.ExecuteNonQuery()
            Return True
        End Using
    End Function

End Class


Public Class CustomFontResolver
    Implements IFontResolver

    Public Function ResolveTypeface(familyName As String, isBold As Boolean, isItalic As Boolean) As FontResolverInfo Implements IFontResolver.ResolveTypeface
        ' Aquí puedes mapear tus fuentes a archivos .ttf
        If familyName = "Calibri" Then
            Return New FontResolverInfo("Calibri#")
        End If
        Return New FontResolverInfo("Arial#") ' fallback
    End Function

    Public Function GetFont(faceName As String) As Byte() Implements IFontResolver.GetFont
        ' Retornar el contenido del .ttf en bytes
        If faceName = "Calibri#" Then
            Return System.IO.File.ReadAllBytes("C:\Windows\Fonts\calibri.ttf")
        ElseIf faceName = "Arial#" Then
            Return System.IO.File.ReadAllBytes("C:\Windows\Fonts\arial.ttf")
        End If
        Return Nothing
    End Function
End Class