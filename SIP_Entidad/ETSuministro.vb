Public Class ETSuministro

    Inherits ETObjecto

    Private _CodSuministro As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Valor As Byte = Byte.MinValue
    Private _CostoUnitario As Decimal = Decimal.Zero
    Private _SubTotal As Decimal = Decimal.Zero
    Private _Peso As Decimal = Decimal.Zero
    Private _Unidad As String = String.Empty
    Private _UndDesp As String = String.Empty
    Private _Cantidad As Int32 = 0
    Private _CantidadUnitaria As Int32 = 0
    Private _Action As Boolean = Boolean.FalseString
    Private _Status As String = String.Empty
    Private _CodAnterior As String = String.Empty
    Private _Tipo As Int16 = 0
    Private _Item As Int32 = 0
    Private _CodEmpaque As String = String.Empty
    Private _DesEmpaque As String = String.Empty
    Private _DesSuministro As String = String.Empty
    Private _CantidadMaxima As Decimal = Decimal.Zero

    Public Property Item() As Int32
        Get
            Return _Item
        End Get
        Set(ByVal value As Int32)
            _Item = value
        End Set
    End Property

    Public Property Action() As Boolean
        Get
            Return _Action
        End Get
        Set(ByVal value As Boolean)
            _Action = value
        End Set
    End Property

    Public Property Valor() As Byte
        Get
            Return _Valor
        End Get
        Set(ByVal value As Byte)
            _Valor = value
        End Set
    End Property

    Public Overloads Property Tipo() As Int16
        Get
            Return _Tipo
        End Get
        Set(ByVal value As Int16)
            _Tipo = value
        End Set
    End Property

    Public Property CodSuministro() As String
        Get
            Return _CodSuministro
        End Get
        Set(ByVal value As String)
            _CodSuministro = value
        End Set
    End Property

    Public Property DesSuministro() As String
        Get
            Return _DesSuministro
        End Get
        Set(ByVal value As String)
            _DesSuministro = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property CodEmpaque() As String
        Get
            Return _CodEmpaque
        End Get
        Set(ByVal value As String)
            _CodEmpaque = value
        End Set
    End Property

    Public Property DesEmpaque() As String
        Get
            Return _DesEmpaque
        End Get
        Set(ByVal value As String)
            _DesEmpaque = value
        End Set
    End Property

    Public Property CostoUnitario() As Decimal
        Get
            Return _CostoUnitario
        End Get
        Set(ByVal value As Decimal)
            _CostoUnitario = value
        End Set
    End Property

    Public Property Peso() As Decimal
        Get
            Return _Peso
        End Get
        Set(ByVal value As Decimal)
            _Peso = value
        End Set
    End Property

    Public Overloads Property Cantidad() As Int32
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Int32)
            _Cantidad = value
        End Set
    End Property

    Public Property CantidadUnitaria() As Int32
        Get
            Return _CantidadUnitaria
        End Get
        Set(ByVal value As Int32)
            _CantidadUnitaria = value
        End Set
    End Property

    Public Property SubTotal() As Decimal
        Get
            Return _SubTotal
        End Get
        Set(ByVal value As Decimal)
            _SubTotal = value
        End Set
    End Property

    Public Overloads Property Unidad() As String
        Get
            Return _Unidad
        End Get
        Set(ByVal value As String)
            _Unidad = value
        End Set
    End Property

    Public Property UndDesp() As String
        Get
            Return _UndDesp
        End Get
        Set(ByVal value As String)
            _UndDesp = value
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

    Public Property CodAnterior() As String
        Get
            Return _CodAnterior
        End Get
        Set(ByVal value As String)
            _CodAnterior = value
        End Set
    End Property

    Public Property CantidadMaxima() As Decimal
        Get
            Return _CantidadMaxima
        End Get
        Set(ByVal value As Decimal)
            _CantidadMaxima = value
        End Set
    End Property

End Class
