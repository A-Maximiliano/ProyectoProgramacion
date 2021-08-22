Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class blMateria

    'Funcion que permite consultar las materias de mi base de datos
    Public Function ConsultarMateriaBL() As List(Of clsMateria)
        ''Se declara la lista de materias que devuelve la funcion 
        Dim lista As New List(Of clsMateria)()

        ''Se crea una instancia de la clase de conexion para obtener el connection string
        Dim conexion As New clsConexion()

        'Objeto para comunicarnos con la bd
        Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

        'Objeto para armar el comando a ejecutar en la base de datos
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
        cmd.CommandText = "spConsultarMateria" 'El nombre del procedimiento almacenado 

        cmd.Connection = conn    'Al comando le indicamos a cual bd conectarse 
        conn.Open()              'Abrimos la conexion 
        dr = cmd.ExecuteReader() 'Al data reader le asignamos la ejecucion del comando configurado


        While dr.Read()
            Dim vMateria As clsMateria = New clsMateria()

            vMateria.prop_clave_m = Convert.ToInt32(dr("clave_m"))
            vMateria.prop_nom_m = dr("nom_m")
            vMateria.prop_creed_m = Convert.ToDouble(dr("creed_m"))

            lista.Add(vMateria)

        End While



        ''Se retorna la lista de materias
        Return lista
    End Function

    'Funcion que permite registrar las materias de mi base de datos
    Public Sub RegistrarMateriaBL(pMateria As clsMateria, ByRef pError As String)

        Try
            Dim conexion As New clsConexion()
            'Objeto para comunicarnos con la bd
            Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

            'Objeto para armar el comando a ejecutar en la base de datos
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
            cmd.CommandText = "spRegistrarMateria" 'El nombre del procedimiento almacenado 

            ''Preparar los parametros del procedimiento almacenado

            cmd.Parameters.Add("@pnombre", SqlDbType.VarChar)
            cmd.Parameters("@pnombre").Value = pMateria.prop_nom_m

            cmd.Parameters.Add("@pcreditos", SqlDbType.Float)
            cmd.Parameters("@pcreditos").Value = pMateria.prop_creed_m

            cmd.Connection = conn
            conn.Open()

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            pError = "Error general al registrar la materia. Detalle: " + ex.Message
        End Try

    End Sub

    'Funcion que permite modificar las materias de mi base de datos
    Public Sub ModificarMateriaBL(pMateria As clsMateria, ByRef pErrror As String)
        Try
            Dim conexion As New clsConexion()

            'Objeto para comunicarnos con la bd
            Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

            'Objeto para armar el comando a ejecutar en la base de datos
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
            cmd.CommandText = "spModificarMateria" 'El nombre del procedimiento almacenado 

            ''Preparar los parametros del procedimiento almacenado
            cmd.Parameters.Add("@pclave_m", SqlDbType.VarChar)
            cmd.Parameters("@pclave_m").Value = pMateria.prop_clave_m

            cmd.Parameters.Add("@pnombre", SqlDbType.VarChar)
            cmd.Parameters("@pnombre").Value = pMateria.prop_nom_m

            cmd.Parameters.Add("@pcreditos", SqlDbType.Float)
            cmd.Parameters("@pcreditos").Value = pMateria.prop_creed_m


            cmd.Connection = conn
            conn.Open()

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            pErrror = "Error al modificar la materia. Detalle: " + ex.Message
        End Try
    End Sub

    'Funcion que permite eliminar las materias de mi base de datos
    Public Sub EliminarMateriaBL(pMateria As clsMateria, ByRef pErrror As String)
        Try
            Dim conexion As New clsConexion()

            'Objeto para comunicarnos con la bd
            Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

            'Objeto para armar el comando a ejecutar en la base de datos
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
            cmd.CommandText = "spEliminarMateria" 'El nombre del procedimiento almacenado 

            ''Preparar los parametros del procedimiento almacenado
            cmd.Parameters.Add("@pclave_m", SqlDbType.VarChar)
            cmd.Parameters("@pclave_m").Value = pMateria.prop_clave_m




            cmd.Connection = conn
            conn.Open()

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            pErrror = "Error al eliminar la materia. Detalle: " + ex.Message
        End Try
    End Sub

End Class
