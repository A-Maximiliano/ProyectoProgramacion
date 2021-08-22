
Public Class clsMateria

#Region "Atributos"
    Private clave_m As Integer
    Private nom_m As String
    Private creed_m As Double
#End Region

#Region "Propiedades"
    Public Property prop_clave_m As Integer
        Get
            Return clave_m
        End Get
        Set(value As Integer)
            clave_m = value
        End Set
    End Property

    Public Property prop_nom_m As String
        Get
            Return nom_m
        End Get
        Set(value As String)
            nom_m = value
        End Set
    End Property

    Public Property prop_creed_m As Double
        Get
            Return creed_m
        End Get
        Set(value As Double)
            creed_m = value
        End Set
    End Property
#End Region

End Class
