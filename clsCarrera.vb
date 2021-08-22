Public Class clsCarrera

#Region "Atributos"
    Private clave_c As Integer
    Private nom_c As String
    Private dura_c As Double
#End Region

#Region "Propiedades"
    Public Property clave_c_prop As Integer
        Get
            Return clave_c
        End Get
        Set(value As Integer)
            clave_c = value
        End Set
    End Property

    Public Property nom_c_prop As String
        Get
            Return nom_c
        End Get
        Set(value As String)
            nom_c = value
        End Set
    End Property

    Public Property dura_c_prop As Double
        Get
            Return dura_c
        End Get
        Set(value As Double)
            dura_c = value
        End Set
    End Property
#End Region

End Class
