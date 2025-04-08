Public Class Cabecera
    Inherits Auditoria

    Private _idCabecera As Integer
    Private _anio As Short
    Private _mes As Short
    Private _nombreArchivo As String = ""
    Private _nombreHoja As String = ""
    Public Property idCabecera() As Integer
        Get
            Return _idCabecera
        End Get
        Set(ByVal value As Integer)
            _idCabecera = value
        End Set
    End Property

    Public Property anio() As Short
        Get
            Return _anio
        End Get
        Set(ByVal value As Short)
            _anio = value
        End Set
    End Property
    Public Property mes() As Short
        Get
            Return _mes
        End Get
        Set(ByVal value As Short)
            _mes = value
        End Set
    End Property
    Public Property nombreArchivo() As String
        Get
            Return _nombreArchivo
        End Get
        Set(ByVal value As String)
            _nombreArchivo = value
        End Set
    End Property
    Public Property nombreHoja() As String
        Get
            Return _nombreHoja
        End Get
        Set(ByVal value As String)
            _nombreHoja = value
        End Set
    End Property

End Class
