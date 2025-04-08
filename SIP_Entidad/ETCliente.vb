
Public Class ETCliente

    Inherits ETObjecto

    Private _CodCliente As String = String.Empty
    Private _CodProducto As String = String.Empty
    Private _DesCliente As String = String.Empty
    Private _Palabra As String = String.Empty
    Private _DocExt As String = String.Empty
    Private _Anho As Int32 = 0
    Private _Mes As Int32 = 0
    Private _Semana As Int32 = 0
    Private _FechaInicio As Date = Date.Now
    Private _FechaFinal As Date = Date.Now
    Private _Fecha As Date = Date.Now
    Private _Tipo As Int16 = 0
    Private _Descripcion As String = String.Empty
    Private _Codigo As String = String.Empty
    Private _CantidadAnterior As Decimal = Decimal.Zero
    Private _CantidadDespachada As Decimal = Decimal.Zero
    Private _CantidadCotizada As Decimal = Decimal.Zero
    Private _CantidadActual As Decimal = Decimal.Zero
    Private _Diferencia As Decimal = Decimal.Zero
    Private _Stock As Decimal = Decimal.Zero
    Private _CantTON As Decimal = Decimal.Zero
    Private _CantBULTOS As Decimal = Decimal.Zero
    Private _SemanaActual As Decimal = Decimal.Zero
    Private _SemanaSiguiente As Decimal = Decimal.Zero
    Private _NroPedido As String = String.Empty
    Private _FechaRequerida As Date = Date.Now
    Private _Pais As String = String.Empty
    Private _FechaGuiaInicio1 As Date = Date.Now
    Private _FechaGuiaFinal1 As Date = Date.Now
    Private _FechaGuiaInicio2 As Date = Date.Now
    Private _FechaGuiaFinal2 As Date = Date.Now
    Private _RUC As String = String.Empty


    Public Overloads Property Tipo() As Int16
        Get
            Return _Tipo
        End Get
        Set(ByVal value As Int16)
            _Tipo = value
        End Set
    End Property

    Public Property DesCliente() As String
        Get
            Return _DesCliente
        End Get
        Set(ByVal value As String)
            _DesCliente = value
        End Set
    End Property

    Public Property NroPedido() As String
        Get
            Return _NroPedido
        End Get
        Set(ByVal value As String)
            _NroPedido = value
        End Set
    End Property

    Public Property CodCliente() As String
        Get
            Return _CodCliente
        End Get
        Set(ByVal value As String)
            _CodCliente = value
        End Set
    End Property

    Public Property DocExt() As String
        Get
            Return _DocExt
        End Get
        Set(ByVal value As String)
            _DocExt = value
        End Set
    End Property

    Public Property Palabra() As String
        Get
            Return _Palabra
        End Get
        Set(ByVal value As String)
            _Palabra = value
        End Set
    End Property

    Public Overloads Property Anho() As Int32
        Get
            Return _Anho
        End Get
        Set(ByVal value As Int32)
            _Anho = value
        End Set
    End Property

    Public Property Pais() As String
        Get
            Return _Pais
        End Get
        Set(ByVal value As String)
            _Pais = value
        End Set
    End Property

    Public Overloads Property Mes() As Int32
        Get
            Return _Mes
        End Get
        Set(ByVal value As Int32)
            _Mes = value
        End Set
    End Property

    Public Overloads Property Semana() As Int32
        Get
            Return _Semana
        End Get
        Set(ByVal value As Int32)
            _Semana = value
        End Set
    End Property

    Public Property CodProducto() As String
        Get
            Return _CodProducto
        End Get
        Set(ByVal value As String)
            _CodProducto = value
        End Set
    End Property

    Public Overloads Property FechaInicio() As Date
        Get
            Return _FechaInicio
        End Get
        Set(ByVal value As Date)
            _FechaInicio = value
        End Set
    End Property

    Public Property FechaFinal() As Date
        Get
            Return _FechaFinal
        End Get
        Set(ByVal value As Date)
            _FechaFinal = value
        End Set
    End Property

    Public Overloads Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property FechaRequerida() As Date
        Get
            Return _FechaRequerida
        End Get
        Set(ByVal value As Date)
            _FechaRequerida = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
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

    Public Property CantidadAnterior() As Decimal
        Get
            Return _CantidadAnterior
        End Get
        Set(ByVal value As Decimal)
            _CantidadAnterior = value
        End Set
    End Property

    Public Property CantidadDespachada() As Decimal
        Get
            Return _CantidadDespachada
        End Get
        Set(ByVal value As Decimal)
            _CantidadDespachada = value
        End Set
    End Property

    Public Property CantidadCotizada() As Decimal
        Get
            Return _CantidadCotizada
        End Get
        Set(ByVal value As Decimal)
            _CantidadCotizada = value
        End Set
    End Property

    Public Property CantidadActual() As Decimal
        Get
            Return _CantidadActual
        End Get
        Set(ByVal value As Decimal)
            _CantidadActual = value
        End Set
    End Property

    Public Property Diferencia() As Decimal
        Get
            Return _Diferencia
        End Get
        Set(ByVal value As Decimal)
            _Diferencia = value
        End Set
    End Property

    Public Property Stock() As Decimal
        Get
            Return _Stock
        End Get
        Set(ByVal value As Decimal)
            _Stock = value
        End Set
    End Property

    Public Property SemanaActual() As Decimal
        Get
            Return _SemanaActual
        End Get
        Set(ByVal value As Decimal)
            _SemanaActual = value
        End Set
    End Property

    Public Property SemanaSiguiente() As Decimal
        Get
            Return _SemanaSiguiente
        End Get
        Set(ByVal value As Decimal)
            _SemanaSiguiente = value
        End Set
    End Property

    Public Property CantTON() As Decimal
        Get
            Return _CantTON
        End Get
        Set(ByVal value As Decimal)
            _CantTON = value
        End Set
    End Property

    Public Property CantBULTOS() As Decimal
        Get
            Return _CantBULTOS
        End Get
        Set(ByVal value As Decimal)
            _CantBULTOS = value
        End Set
    End Property

    Public Property FechaGuiaInicio1() As Date
        Get
            Return _FechaGuiaInicio1
        End Get
        Set(ByVal value As Date)
            _FechaGuiaInicio1 = value
        End Set
    End Property

    Public Property FechaGuiaFinal1() As Date
        Get
            Return _FechaGuiaFinal1
        End Get
        Set(ByVal value As Date)
            _FechaGuiaFinal1 = value
        End Set
    End Property

    Public Property FechaGuiaInicio2() As Date
        Get
            Return _FechaGuiaInicio2
        End Get
        Set(ByVal value As Date)
            _FechaGuiaInicio2 = value
        End Set
    End Property

    Public Property FechaGuiaFinal2() As Date
        Get
            Return _FechaGuiaFinal2
        End Get
        Set(ByVal value As Date)
            _FechaGuiaFinal2 = value
        End Set
    End Property

    Public Property RUC() As String
        Get
            Return _RUC
        End Get
        Set(ByVal value As String)
            _RUC = value
        End Set
    End Property

End Class
