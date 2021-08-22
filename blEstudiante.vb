Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class blEstudiante

    'Funcion que permite consultar los estudiantes de mi base de datos
    Public Function ConsultarEstudianteBL() As List(Of clsEstudiante)
        ''Se declara la lista de estudiantes que devuelve la funcion 
        Dim lista As New List(Of clsEstudiante)()

        ''Se crea una instancia de la clase de conexion para obtener el connection string
        Dim conexion As New clsConexion()

        'Objeto para comunicarnos con la bd
        Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

        'Objeto para armar el comando a ejecutar en la base de datos
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
        cmd.CommandText = "spConsultarAlumno" 'El nombre del procedimiento almacenado 

        cmd.Connection = conn    'Al comando le indicamos a cual bd conectarse 
        conn.Open()              'Abrimos la conexion 
        dr = cmd.ExecuteReader() 'Al data reader le asignamos la ejecucion del comando configurado


        While dr.Read()
            Dim vEstudiante As clsEstudiante = New clsEstudiante()

            vEstudiante.prop_mat_alu = Convert.ToInt32(dr("mat_alu"))
            vEstudiante.prop_nom_alu = dr("nom_alu")
            vEstudiante.prop_edad_alu = Convert.ToDouble(dr("edad_alu"))
            vEstudiante.prop_sem_alu = Convert.ToDouble(dr("sem_alu"))
            vEstudiante.prop_gen_alu = dr("gen_alu")
            vEstudiante.prop_clave_c1 = Convert.ToDouble(dr("clave_c1"))

            lista.Add(vEstudiante)

        End While
        ''Se retorna la lista de estudiantes
        Return lista
    End Function

    'Funcion que permite registar los estudiantes de mi base de datos
    Public Sub RegistrarEstudianteBL(pEstudiante As clsEstudiante, ByRef pError As String)

        Try
            Dim conexion As New clsConexion()
            'Objeto para comunicarnos con la bd
            Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

            'Objeto para armar el comando a ejecutar en la base de datos
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
            cmd.CommandText = "spRegistrarAlumno" 'El nombre del procedimiento almacenado 

            ''Preparar los parametros del procedimiento almacenado

            cmd.Parameters.Add("@pnombre_a", SqlDbType.VarChar)
            cmd.Parameters("@pnombre_a").Value = pEstudiante.prop_nom_alu

            cmd.Parameters.Add("@pedad_a", SqlDbType.Int)
            cmd.Parameters("@pedad_a").Value = pEstudiante.prop_edad_alu

            cmd.Parameters.Add("@psemestre_a", SqlDbType.Int)
            cmd.Parameters("@psemestre_a").Value = pEstudiante.prop_sem_alu

            cmd.Parameters.Add("@pgenero", SqlDbType.VarChar)
            cmd.Parameters("@pgenero").Value = pEstudiante.prop_gen_alu

            cmd.Parameters.Add("@pclave_alu_c", SqlDbType.VarChar)
            cmd.Parameters("@pclave_alu_c").Value = pEstudiante.prop_clave_c1

            cmd.Connection = conn
            conn.Open()

            cmd.ExecuteNonQuery()



        Catch ex As Exception
            pError = "Error general al registrar el estudiante. Detalle: " + ex.Message
        End Try

    End Sub

    'Funcion que permite modificar los estudiantes de mi base de datos
    Public Sub ModificarEstudianteBL(pEstudiante As clsEstudiante, ByRef pErrror As String)
        Try
            Dim conexion As New clsConexion()

            'Objeto para comunicarnos con la bd
            Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

            'Objeto para armar el comando a ejecutar en la base de datos
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
            cmd.CommandText = "spModificarAlumno" 'El nombre del procedimiento almacenado 

            ''Preparar los parametros del procedimiento almacenado

            cmd.Parameters.Add("@mat_alumno", SqlDbType.VarChar)
            cmd.Parameters("@mat_alumno").Value = pEstudiante.prop_mat_alu

            cmd.Parameters.Add("@pnombre_a", SqlDbType.VarChar)
            cmd.Parameters("@pnombre_a").Value = pEstudiante.prop_nom_alu

            cmd.Parameters.Add("@pedad_a", SqlDbType.Int)
            cmd.Parameters("@pedad_a").Value = pEstudiante.prop_edad_alu

            cmd.Parameters.Add("@psemestre_a", SqlDbType.Int)
            cmd.Parameters("@psemestre_a").Value = pEstudiante.prop_sem_alu

            cmd.Parameters.Add("@pgenero", SqlDbType.VarChar)
            cmd.Parameters("@pgenero").Value = pEstudiante.prop_gen_alu

            cmd.Parameters.Add("@pclave_alu_c", SqlDbType.VarChar)
            cmd.Parameters("@pclave_alu_c").Value = pEstudiante.prop_clave_c1

            cmd.Connection = conn
            conn.Open()

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            pErrror = "Error al modificar el estudiante. Detalle: " + ex.Message
        End Try
    End Sub

    'Funcion que permite eliminar los estudiantes de mi base de datos
    Public Sub EliminarEstudianteBL(pEstudiante As clsEstudiante, ByRef pErrror As String)
        Try
            Dim conexion As New clsConexion()

            'Objeto para comunicarnos con la bd
            Dim conn As New SqlConnection(conexion.obtenercadenaconexion())

            'Objeto para armar el comando a ejecutar en la base de datos
            Dim cmd As New SqlCommand

            cmd.CommandType = CommandType.StoredProcedure 'El comando es un procedimiento almacenado
            cmd.CommandText = "spEliminarAlumno" 'El nombre del procedimiento almacenado 

            ''Preparar los parametros del procedimiento almacenado
            cmd.Parameters.Add("@mat_alumno", SqlDbType.VarChar)
            cmd.Parameters("@mat_alumno").Value = pEstudiante.prop_mat_alu

            cmd.Connection = conn
            conn.Open()

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            pErrror = "Error al eliminar el estudiante. Detalle: " + ex.Message
        End Try
    End Sub

End Class
