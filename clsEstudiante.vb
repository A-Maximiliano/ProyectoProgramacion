Public Class clsEstudiante

#Region "Atributos"
    Private mat_alu As Integer
    Private nom_alu As String
    Private edad_alu As Integer
    Private sem_alu As Integer
    Private gen_alu As String
    Private clave_c1 As Integer
#End Region

#Region "Propiedades"
    Public Property prop_mat_alu As Integer
        Get
            Return mat_alu
        End Get
        Set(value As Integer)
            mat_alu = value
        End Set
    End Property

    Public Property prop_nom_alu As String
        Get
            Return nom_alu
        End Get
        Set(value As String)
            nom_alu = value
        End Set
    End Property

    Public Property prop_edad_alu As Integer
        Get
            Return edad_alu
        End Get
        Set(value As Integer)
            edad_alu = value
        End Set
    End Property

    Public Property prop_sem_alu As Integer
        Get
            Return sem_alu
        End Get
        Set(value As Integer)
            sem_alu = value
        End Set
    End Property

    Public Property prop_gen_alu As String
        Get
            Return gen_alu
        End Get
        Set(value As String)
            gen_alu = value
        End Set
    End Property

    Public Property prop_clave_c1 As Integer
        Get
            Return clave_c1
        End Get
        Set(value As Integer)
            clave_c1 = value
        End Set
    End Property
#End Region

End Class
