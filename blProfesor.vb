Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class blProfesor

    'Funcion que permite consultar los profesores de mi base de datos
    Public Function ConsultarProfesorBL() As List(Of clsProfesor)
        ''Se declara la lista de profesores que devuelve la funcion 
        Dim lista As New List(Of clsProfesor)()

        ''Se crea una instancia de la clase de conexion para obtener el connection string
        Dim conexion As New clsConexion()

        'Objeto para comunicarnos con la bd
        Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

        'Objeto para armar el comando a ejecutar en la base de datos
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
        cmd.CommandText = "spConsultarProfesor" 'El nombre del procedimiento almacenado 

        cmd.Connection = conn    'Al comando le indicamos a cual bd conectarse 
        conn.Open()              'Abrimos la conexion 
        dr = cmd.ExecuteReader() 'Al data reader le asignamos la ejecucion del comando configurado


        While dr.Read()
            Dim vProfesor As clsProfesor = New clsProfesor()

            vProfesor.prop_clave_p = Convert.ToInt32(dr("clave_p"))
            vProfesor.prop_nom_p = dr("nom_p")
            vProfesor.prop_dir_p = dr("dir_p")
            vProfesor.prop_tel_p = Convert.ToDouble(dr("tel_p"))
            vProfesor.prop_hor_p = Convert.ToDateTime(dr("hor_p"))

            lista.Add(vProfesor)

        End While
        ''Se retorna la lista de profesores
        Return lista
    End Function

    'Funcion que permite registrar los profesores de mi base de datos
    Public Sub RegistrarProfesorBL(pProfesor As clsProfesor, ByRef pError As String)

        Try
            Dim conexion As New clsConexion()
            'Objeto para comunicarnos con la bd
            Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

            'Objeto para armar el comando a ejecutar en la base de datos
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
            cmd.CommandText = "spRegistrarProfesor" 'El nombre del procedimiento almacenado 

            ''Preparar los parametros del procedimiento almacenado

            cmd.Parameters.Add("@pnombre", SqlDbType.VarChar)
            cmd.Parameters("@pnombre").Value = pProfesor.prop_nom_p

            cmd.Parameters.Add("@pdireccion", SqlDbType.VarChar)
            cmd.Parameters("@pdireccion").Value = pProfesor.prop_dir_p

            cmd.Parameters.Add("@ptelefono", SqlDbType.Int)
            cmd.Parameters("@ptelefono").Value = pProfesor.prop_tel_p

            cmd.Parameters.Add("@phorario", SqlDbType.DateTime)
            cmd.Parameters("@phorario").Value = pProfesor.prop_hor_p

            cmd.Connection = conn
            conn.Open()

            cmd.ExecuteNonQuery()



        Catch ex As Exception
            pError = "Error general al registrar el profesor. Detalle: " + ex.Message
        End Try

    End Sub

    'Funcion que permite modificar los profesores de mi base de datos
    Public Sub ModificarProfesorBL(pProfesor As clsProfesor, ByRef pErrror As String)
        Try
            Dim conexion As New clsConexion()

            'Objeto para comunicarnos con la bd
            Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

            'Objeto para armar el comando a ejecutar en la base de datos
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
            cmd.CommandText = "spModificarProfesor" 'El nombre del procedimiento almacenado 

            ''Preparar los parametros del procedimiento almacenado

            cmd.Parameters.Add("@clave_p", SqlDbType.VarChar)
            cmd.Parameters("@clave_p").Value = pProfesor.prop_clave_p

            cmd.Parameters.Add("@pnombre", SqlDbType.VarChar)
            cmd.Parameters("@pnombre").Value = pProfesor.prop_nom_p

            cmd.Parameters.Add("@pdireccion", SqlDbType.VarChar)
            cmd.Parameters("@pdireccion").Value = pProfesor.prop_dir_p

            cmd.Parameters.Add("@ptelefono", SqlDbType.Int)
            cmd.Parameters("@ptelefono").Value = pProfesor.prop_tel_p

            cmd.Parameters.Add("@phorario", SqlDbType.DateTime)
            cmd.Parameters("@phorario").Value = pProfesor.prop_hor_p

            cmd.Connection = conn
            conn.Open()

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            pErrror = "Error al modificar el profesor. Detalle: " + ex.Message
        End Try
    End Sub

    'Funcion que permite eliminar los profesores de mi base de datos
    Public Sub EliminarProfesorBL(pProfesor As clsProfesor, ByRef pErrror As String)
        Try
            Dim conexion As New clsConexion()

            'Objeto para comunicarnos con la bd
            Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

            'Objeto para armar el comando a ejecutar en la base de datos
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
            cmd.CommandText = "spEliminarProfesor" 'El nombre del procedimiento almacenado 

            ''Preparar los parametros del procedimiento almacenado
            cmd.Parameters.Add("@clave_p", SqlDbType.VarChar)
            cmd.Parameters("@clave_p").Value = pProfesor.prop_clave_p

            cmd.Connection = conn
            conn.Open()

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            pErrror = "Error al eliminar el profesor. Detalle: " + ex.Message
        End Try
    End Sub

End Class
