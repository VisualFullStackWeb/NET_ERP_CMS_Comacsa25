Public Class ETAreaJefatura
    Inherits ETObjecto
    Private _Area As String = String.Empty
    Private _JefeArea As String = String.Empty
    Private _Cod_Area As String = String.Empty
    Private _Cod_JefeArea As String = String.Empty
    Private _Status As String = String.Empty
    Private _AreaJefatura As Long = 0

    Private _FechaInicioTxt As String = String.Empty
    Private _FechaTerminoTxt As String = String.Empty

    Public Property Area() As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            _Area = value
        End Set
    End Property

    Public Property JefeArea() As String
        Get
            Return _JefeArea
        End Get
        Set(ByVal value As String)
            _JefeArea = value
        End Set
    End Property

    Public Property Cod_Area() As String
        Get
            Return _Cod_Area
        End Get
        Set(ByVal value As String)
            _Cod_Area = value
        End Set
    End Property

    Public Property Cod_JefeArea() As String
        Get
            Return _Cod_JefeArea
        End Get
        Set(ByVal value As String)
            _Cod_JefeArea = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property

    Public Property AreaJefatura() As Long
        Get
            Return _AreaJefatura
        End Get
        Set(ByVal value As Long)
            _AreaJefatura = value
        End Set
    End Property

    Public Property FechaInicioTxt() As String
        Get
            Return _FechaInicioTxt
        End Get
        Set(ByVal value As String)
            _FechaInicioTxt = value
        End Set
    End Property

    Public Property FechaTerminoTxt() As String
        Get
            Return _FechaTerminoTxt
        End Get
        Set(ByVal value As String)
            _FechaTerminoTxt = value
        End Set
    End Property
End Class
