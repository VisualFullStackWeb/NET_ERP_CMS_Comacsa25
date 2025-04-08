
Public Class ETPersonal

    Inherits ETObjecto

    Private _Action As Boolean = Boolean.FalseString
    Private _CodPersonal As String = String.Empty
    Private _DesPersonal As String = String.Empty
    Private _HorasTrabajadas As Decimal = Decimal.Zero
    Private _CostoxHora As Decimal = Decimal.Zero
    Private _DescripArea As String = String.Empty
    Private _Area As String = String.Empty
    Private _Cargo As String = String.Empty
    Private _Serie_Guia As String = String.Empty
    Private _Nro_Guia As String = String.Empty
    Private _Status As String = String.Empty
    Private _DesTurno As String = String.Empty
    Private _CodUnidadProd As String = String.Empty

    Public Property Action() As Boolean
        Get
            Return _Action
        End Get
        Set(ByVal value As Boolean)
            _Action = value
        End Set
    End Property
    Public Property CodPersonal() As String
        Get
            Return _CodPersonal
        End Get
        Set(ByVal value As String)
            _CodPersonal = value
        End Set
    End Property
    Public Property DesPersonal() As String
        Get
            Return _DesPersonal
        End Get
        Set(ByVal value As String)
            _DesPersonal = value
        End Set
    End Property
    Public Property HorasTrab() As Decimal
        Get
            Return _HorasTrabajadas
        End Get
        Set(ByVal value As Decimal)
            _HorasTrabajadas = value
        End Set
    End Property
    Public Property CostoxHora() As Decimal
        Get
            Return _CostoxHora
        End Get
        Set(ByVal value As Decimal)
            _CostoxHora = value
        End Set
    End Property
    Public Property DescripArea() As String
        Get
            Return _DescripArea
        End Get
        Set(ByVal value As String)
            _DescripArea = value
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
    Public Property Cargo() As String
        Get
            Return _Cargo
        End Get
        Set(ByVal value As String)
            _Cargo = value
        End Set
    End Property
    Public Property Serie_Guia() As String
        Get
            Return _Serie_Guia
        End Get
        Set(ByVal value As String)
            _Serie_Guia = value
        End Set
    End Property
    Public Property Nro_Guia() As String
        Get
            Return _Nro_Guia
        End Get
        Set(ByVal value As String)
            _Nro_Guia = value
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
    Public Property DesTurno() As String
        Get
            Return _DesTurno
        End Get
        Set(ByVal value As String)
            _DesTurno = value
        End Set
    End Property

    Public Property CodUnidadProd() As String
        Get
            Return _CodUnidadProd
        End Get
        Set(ByVal value As String)
            _CodUnidadProd = value
        End Set
    End Property
End Class
