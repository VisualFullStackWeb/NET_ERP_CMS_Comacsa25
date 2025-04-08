Imports System.Configuration
Public Class ETArea
    Inherits ETObjecto
    Private _Cod_Cia As String = String.Empty
    Private _Codigo As String = String.Empty
    Private _Area As String = String.Empty
    Private _Abrev As String = String.Empty
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
    Public Property Area() As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            _Area = value
        End Set
    End Property
    Public Property Abrev() As String
        Get
            Return _Abrev
        End Get
        Set(ByVal value As String)
            _Abrev = value
        End Set
    End Property
    Public Property Cod_Cia() As String
        Get
            Return _Cod_Cia
        End Get
        Set(ByVal value As String)
            _Cod_Cia = value
        End Set
    End Property
End Class
