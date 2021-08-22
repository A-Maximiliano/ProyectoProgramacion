Imports System.Configuration

Public Class clsConexion

    Public Function obtenercadenaconexion() As String
        Return ConfigurationManager.ConnectionStrings("connDB").ConnectionString.ToString()
    End Function

End Class
