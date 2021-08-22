Public Class clsProfesor

#Region "Atributos"
    Private clave_p As Integer
    Private nom_p As String
    Private dir_p As String
    Private tel_p As Integer
    Private hor_p As DateTime
#End Region

#Region "Propiedades"
    Public Property prop_clave_p As Integer
        Get
            Return clave_p
        End Get
        Set(value As Integer)
            clave_p = value
        End Set
    End Property

    Public Property prop_nom_p As String
        Get
            Return nom_p
        End Get
        Set(value As String)
            nom_p = value
        End Set
    End Property

    Public Property prop_dir_p As String
        Get
            Return dir_p
        End Get
        Set(value As String)
            dir_p = value
        End Set
    End Property

    Public Property prop_tel_p As Integer
        Get
            Return tel_p
        End Get
        Set(value As Integer)
            tel_p = value
        End Set
    End Property

    Public Property prop_hor_p As Date
        Get
            Return hor_p
        End Get
        Set(value As Date)
            hor_p = value
        End Set
    End Property
#End Region

End Class
