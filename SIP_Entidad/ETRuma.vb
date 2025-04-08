Public Class ETRuma

    Inherits ETObjecto

    Private _CodRuma As String = String.Empty
    Private _DesRuma As String = String.Empty
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Cantera As String = String.Empty
    Private _Equipo As String = String.Empty
    Private _Trabajador As String = String.Empty
    Private _Anexo3 As String = String.Empty
    Private _Cantidad As Decimal = Decimal.Zero
    Private _CantidadxFraccionada As Decimal = Decimal.Zero
    Private _CantidadxNecesaria As Decimal = Decimal.Zero
    Private _CantidadSubRecurso As Decimal = Decimal.Zero
    Private _CantxRumaxNecesaria As Decimal = Decimal.Zero
    Private _StockRuma As Decimal = Decimal.Zero
    Private _StockMineral As Decimal = Decimal.Zero


    Private _SubTotal As Decimal = Decimal.Zero
    Private _Merma As Decimal = Decimal.Zero
    Private _Humedad As Decimal = Decimal.Zero
    Private _Seguridad As Decimal = Decimal.Zero
    Private _CostoxExtraccion As Decimal = Decimal.Zero
    Private _CostoxCompra As Decimal = Decimal.Zero
    Private _CostoxRegalias As Decimal = Decimal.Zero
    Private _CostoxFlete As Decimal = Decimal.Zero
    Private _CostoxOtros As Decimal = Decimal.Zero
    Private _CostoxRuma As Decimal = Decimal.Zero

    Private _ID As Int32 = 0
    Private _PartidaPresupuestal As Int32 = 0
    Private _Update As Boolean = Boolean.FalseString
    Private _InstMineral As New ETMineral
    Private _Porcentaje As Decimal = Decimal.Zero
    Private _Item As Int32 = 0
    Private _TipoEnlace As String = String.Empty
    Private _Nro_OC As String = String.Empty
    Private _ContarRecurso As Integer = 0
    Private _Nuevo As Boolean = Boolean.FalseString

    Public Overloads Property ID() As Int32
        Get
            Return _ID
        End Get
        Set(ByVal value As Int32)
            _ID = value
        End Set
    End Property

    Public Property PartidaPresupuestal() As Int32
        Get
            Return _PartidaPresupuestal

        End Get
        Set(ByVal value As Int32)
            _PartidaPresupuestal = value
        End Set
    End Property

    Public Property CodRuma() As String
        Get
            Return _CodRuma
        End Get
        Set(ByVal value As String)
            _CodRuma = value
        End Set
    End Property

    Public Property DesRuma() As String
        Get
            Return _DesRuma
        End Get
        Set(ByVal value As String)
            _DesRuma = value
        End Set
    End Property

    Public Property Cantera() As String
        Get
            Return _Cantera
        End Get
        Set(ByVal value As String)
            _Cantera = value
        End Set
    End Property

    Public Property Equipo() As String
        Get
            Return _Equipo
        End Get
        Set(ByVal value As String)
            _Equipo = value
        End Set
    End Property

    Public Property Trabajador() As String
        Get
            Return _Trabajador
        End Get
        Set(ByVal value As String)
            _Trabajador = value
        End Set
    End Property

    Public Property codAnexo3() As String
        Get
            Return _Anexo3
        End Get
        Set(ByVal value As String)
            _Anexo3 = value
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

    Public Overloads Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property

    Public Property CantidadxFraccionada() As Decimal
        Get
            Return _CantidadxFraccionada
        End Get
        Set(ByVal value As Decimal)
            _CantidadxFraccionada = value
        End Set
    End Property

    Public Property CantidadSubRecurso() As Decimal
        Get
            Return _CantidadSubRecurso
        End Get
        Set(ByVal value As Decimal)
            _CantidadSubRecurso = value
        End Set
    End Property

    Public Property Item() As Int32
        Get
            Return _Item
        End Get
        Set(ByVal value As Int32)
            _Item = value
        End Set
    End Property

    Public Property CantidadxNecesaria() As Decimal
        Get
            Return _CantidadxNecesaria
        End Get
        Set(ByVal value As Decimal)
            _CantidadxNecesaria = value
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

    Public Overloads Property Porcentaje() As Decimal
        Get
            Return _Porcentaje
        End Get
        Set(ByVal value As Decimal)
            _Porcentaje = value
        End Set
    End Property

    Public Property Merma() As Decimal
        Get
            Return _Merma
        End Get
        Set(ByVal value As Decimal)
            _Merma = value
        End Set
    End Property

    Public Property Humedad() As Decimal
        Get
            Return _Humedad
        End Get
        Set(ByVal value As Decimal)
            _Humedad = value
        End Set
    End Property

    Public Property Seguridad() As Decimal
        Get
            Return _Seguridad
        End Get
        Set(ByVal value As Decimal)
            _Seguridad = value
        End Set
    End Property

    Public Overloads Property Update() As Boolean
        Get
            Return _Update
        End Get
        Set(ByVal value As Boolean)
            _Update = value
        End Set
    End Property

    Public Property InstMineral() As ETMineral
        Get
            Return _InstMineral
        End Get
        Set(ByVal value As ETMineral)
            _InstMineral = value
        End Set
    End Property

    Public Property StockRuma() As Decimal
        Get
            Return _StockRuma
        End Get
        Set(ByVal value As Decimal)
            _StockRuma = value
        End Set
    End Property

    Public Property StockMineral() As Decimal
        Get
            Return _StockMineral
        End Get
        Set(ByVal value As Decimal)
            _StockMineral = value
        End Set
    End Property

    Public Property CostoxExtraccion() As Decimal
        Get
            Return _CostoxExtraccion
        End Get
        Set(ByVal value As Decimal)
            _CostoxExtraccion = value
        End Set
    End Property
    Public Property CostoxCompra() As Decimal
        Get
            Return _CostoxCompra
        End Get
        Set(ByVal value As Decimal)
            _CostoxCompra = value
        End Set
    End Property
    Public Property CostoxRegalias() As Decimal
        Get
            Return _CostoxRegalias
        End Get
        Set(ByVal value As Decimal)
            _CostoxRegalias = value
        End Set
    End Property
    Public Property CostoxFlete() As Decimal
        Get
            Return _CostoxFlete
        End Get
        Set(ByVal value As Decimal)
            _CostoxFlete = value
        End Set
    End Property
    Public Property CostoxOtros() As Decimal
        Get
            Return _CostoxOtros
        End Get
        Set(ByVal value As Decimal)
            _CostoxOtros = value
        End Set
    End Property
    Public Property CostoxRuma() As Decimal
        Get
            Return _CostoxRuma
        End Get
        Set(ByVal value As Decimal)
            _CostoxRuma = value
        End Set
    End Property
    Public Property TipoEnlace() As String
        Get
            Return _TipoEnlace
        End Get
        Set(ByVal value As String)
            _TipoEnlace = value
        End Set
    End Property
    Public Property Nro_OC() As String
        Get
            Return _Nro_OC
        End Get
        Set(ByVal value As String)
            _Nro_OC = value
        End Set
    End Property
    Public Property ContarRecurso() As Integer
        Get
            Return _ContarRecurso
        End Get
        Set(ByVal value As Integer)
            _ContarRecurso = value
        End Set
    End Property

    Public Property CantxRumaxNecesaria() As Decimal
        Get
            Return _CantxRumaxNecesaria
        End Get
        Set(ByVal value As Decimal)
            _CantxRumaxNecesaria = value
        End Set
    End Property
    Public Property Nuevo() As Boolean
        Get
            Return _Nuevo
        End Get
        Set(ByVal value As Boolean)
            _Nuevo = value
        End Set
    End Property
End Class
