Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class blCarrera

    'Funcion que permite consultar las carreras de mi base de datos
    Public Function ConsultarCarrerasBL() As List(Of clsCarrera)
        ''Se declara la lista de carreras que devuelve la funcion 
        Dim lista As New List(Of clsCarrera)()

        ''Se crea una instancia de la clase de conexion para obtener el connection string
        Dim conexion As New clsConexion()

        'Objeto para comunicarnos con la bd
        Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

        'Objeto para armar el comando a ejecutar en la base de datos
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
        cmd.CommandText = "spConsultarCarrera" 'El nombre del procedimiento almacenado 

        cmd.Connection = conn    'Al comando le indicamos a cual bd conectarse 
        conn.Open()              'Abrimos la conexion 
        dr = cmd.ExecuteReader() 'Al data reader le asignamos la ejecucion del comando configurado


        While dr.Read()
            Dim vCarrera As clsCarrera = New clsCarrera()

            vCarrera.clave_c_prop = Convert.ToInt32(dr("clave_c"))
            vCarrera.nom_c_prop = dr("nom_c")
            vCarrera.dura_c_prop = Convert.ToDouble(dr("dura_c"))

            lista.Add(vCarrera)

        End While

        ''Se retorna la lista de carreras
        Return lista
    End Function

    'Funcion que permite registar las carreras de mi base de datos
    Public Sub RegistrarCarreraBL(pCarrera As clsCarrera, ByRef pError As String)

        Try
            Dim conexion As New clsConexion()
            'Objeto para comunicarnos con la bd
            Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

            'Objeto para armar el comando a ejecutar en la base de datos
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
            cmd.CommandText = "spRegistrarCarrera" 'El nombre del procedimiento almacenado 

            ''Preparar los parametros del procedimiento almacenado

            cmd.Parameters.Add("@pnombre", SqlDbType.VarChar)
            cmd.Parameters("@pnombre").Value = pCarrera.nom_c_prop

            cmd.Parameters.Add("@pduracion", SqlDbType.Float)
            cmd.Parameters("@pduracion").Value = pCarrera.dura_c_prop

            cmd.Connection = conn
            conn.Open()

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            pError = "Error general al registrar la carrera. Detalle: " + ex.Message
        End Try

    End Sub

    'Funcion que permite modificar las carreras de mi base de datos
    Public Sub ModificarCarreraBL(pCarrera As clsCarrera, ByRef pErrror As String)
        Try
            Dim conexion As New clsConexion()

            'Objeto para comunicarnos con la bd
            Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

            'Objeto para armar el comando a ejecutar en la base de datos
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
            cmd.CommandText = "spModificarCarrera" 'El nombre del procedimiento almacenado 

            ''Preparar los parametros del procedimiento almacenado
            cmd.Parameters.Add("@pclave_c", SqlDbType.VarChar)
            cmd.Parameters("@pclave_c").Value = pCarrera.clave_c_prop

            cmd.Parameters.Add("@pnombre", SqlDbType.VarChar)
            cmd.Parameters("@pnombre").Value = pCarrera.nom_c_prop

            cmd.Parameters.Add("@pduracion", SqlDbType.Float)
            cmd.Parameters("@pduracion").Value = pCarrera.dura_c_prop


            cmd.Connection = conn
            conn.Open()

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            pErrror = "Error al modificar la carrera. Detalle: " + ex.Message
        End Try
    End Sub

    'Funcion que permite eliminar las carreras de mi base de datos
    Public Sub EliminarCarreraBL(pCarrera As clsCarrera, ByRef pErrror As String)
        Try
            Dim conexion As New clsConexion()

            'Objeto para comunicarnos con la bd
            Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

            'Objeto para armar el comando a ejecutar en la base de datos
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
            cmd.CommandText = "spEliminarCarrera" 'El nombre del procedimiento almacenado 

            ''Preparar los parametros del procedimiento almacenado
            cmd.Parameters.Add("@pclave_c", SqlDbType.VarChar)
            cmd.Parameters("@pclave_c").Value = pCarrera.clave_c_prop




            cmd.Connection = conn
            conn.Open()

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            pErrror = "Error al eliminar la carrera. Detalle: " + ex.Message
        End Try
    End Sub

End Class
