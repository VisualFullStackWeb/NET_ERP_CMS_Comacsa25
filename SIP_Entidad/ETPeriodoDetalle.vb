Public Class ETPeriodoDetalle
    Private _Action As Boolean = False
    Private _Periodo As Integer = 0
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _TipoCosteo As String = String.Empty
    Private _Costeo As String = String.Empty
    Private _TipoPropio As String = String.Empty
    Private _Propio As String = String.Empty
    Private _SubTipo As String = String.Empty
    Private _SubCosteo As String = String.Empty
    Private _Cod_Prov As String = String.Empty
    Private _RazSoc As String = String.Empty
    Private _Tipo_Doc_Name As String = String.Empty
    Private _Tipo_Doc As String = String.Empty
    Private _Num_Doc As String = String.Empty
    Private _Total As Decimal = Decimal.Zero
    Private _IGV As Decimal = Decimal.Zero
    Private _Importe As Decimal = Decimal.Zero
    Private _Consumo As Decimal = Decimal.Zero
    Private _CostoUnitario As Decimal = Decimal.Zero
    Private _PlaCod As String = String.Empty
    Private _Personal As String = String.Empty
    Private _Operador As String = String.Empty
    Private _Usuario As String = String.Empty
    Private _Tipo As Int16 = 0
    Private _Cod_Alm As String = String.Empty
    Private _FechaInicio As DateTime = Date.Today
    Private _FechaTermino As DateTime = Date.Today
    Private _Facturacion As Integer = 0
    Private _Fecha_Doc As Date = Date.Today
    Private _Fecha_Proc As Date = Date.Today
    Private _Add As String = "Add"
    Private _Ver As String = "Ver"

    Public Property Action() As Boolean
        Get
            Return _Action
        End Get
        Set(ByVal value As Boolean)
            _Action = value
        End Set
    End Property
    Public Property Periodo() As Integer
        Get
            Return _Periodo
        End Get
        Set(ByVal value As Integer)
            _Periodo = value
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

    Public Property TipoCosteo() As String
        Get
            Return _TipoCosteo
        End Get
        Set(ByVal value As String)
            _TipoCosteo = value
        End Set
    End Property

    Public Property Costeo() As String
        Get
            Return _Costeo
        End Get
        Set(ByVal value As String)
            _Costeo = value
        End Set
    End Property

    Public Property TipoPropio() As String
        Get
            Return _TipoPropio
        End Get
        Set(ByVal value As String)
            _TipoPropio = value
        End Set
    End Property

    Public Property Propio() As String
        Get
            Return _Propio
        End Get
        Set(ByVal value As String)
            _Propio = value
        End Set
    End Property

    Public Property SubTipo() As String
        Get
            Return _SubTipo
        End Get
        Set(ByVal value As String)
            _SubTipo = value
        End Set
    End Property

    Public Property SubCosteo() As String
        Get
            Return _SubCosteo
        End Get
        Set(ByVal value As String)
            _SubCosteo = value
        End Set
    End Property

    Public Property Cod_Prov() As String
        Get
            Return _Cod_Prov
        End Get
        Set(ByVal value As String)
            _Cod_Prov = value
        End Set
    End Property

    Public Property RazSoc() As String
        Get
            Return _RazSoc
        End Get
        Set(ByVal value As String)
            _RazSoc = value
        End Set
    End Property

    Public Property Tipo_Doc_Name() As String
        Get
            Return _Tipo_Doc_Name
        End Get
        Set(ByVal value As String)
            _Tipo_Doc_Name = value
        End Set
    End Property

    Public Property Tipo_Doc() As String
        Get
            Return _Tipo_Doc
        End Get
        Set(ByVal value As String)
            _Tipo_Doc = value
        End Set
    End Property

    Public Property Num_Doc() As String
        Get
            Return _Num_Doc
        End Get
        Set(ByVal value As String)
            _Num_Doc = value
        End Set
    End Property

    Public Property Total() As Decimal
        Get
            Return _Total
        End Get
        Set(ByVal value As Decimal)
            _Total = value
        End Set
    End Property

    Public Property IGV() As Decimal
        Get
            Return _IGV
        End Get
        Set(ByVal value As Decimal)
            _IGV = value
        End Set
    End Property

    Public Property Importe() As Decimal
        Get
            Return _Importe
        End Get
        Set(ByVal value As Decimal)
            _Importe = value
        End Set
    End Property

    Public Property Consumo() As Decimal
        Get
            Return _Consumo
        End Get
        Set(ByVal value As Decimal)
            _Consumo = value
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

    Public Property PlaCod() As String
        Get
            Return _PlaCod
        End Get
        Set(ByVal value As String)
            _PlaCod = value
        End Set
    End Property

    Public Property Operador() As String
        Get
            Return _Operador
        End Get
        Set(ByVal value As String)
            _Operador = value
        End Set
    End Property

    Public Property Personal() As String
        Get
            Return _Personal
        End Get
        Set(ByVal value As String)
            _Personal = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Tipo() As Int16
        Get
            Return _Tipo
        End Get
        Set(ByVal value As Int16)
            _Tipo = value
        End Set
    End Property

    Public Property Cod_Alm() As String
        Get
            Return _Cod_Alm
        End Get
        Set(ByVal value As String)
            _Cod_Alm = value
        End Set
    End Property

    Public Property FechaInicio() As DateTime
        Get
            Return _FechaInicio
        End Get
        Set(ByVal value As DateTime)
            _FechaInicio = value
        End Set
    End Property

    Public Property FechaTermino() As DateTime
        Get
            Return _FechaTermino
        End Get
        Set(ByVal value As DateTime)
            _FechaTermino = value
        End Set
    End Property

    Public Property Facturacion() As Integer
        Get
            Return _Facturacion
        End Get
        Set(ByVal value As Integer)
            _Facturacion = value
        End Set
    End Property

    Public Property Fecha_Doc() As Date
        Get
            Return _Fecha_Doc
        End Get
        Set(ByVal value As Date)
            _Fecha_Doc = value
        End Set
    End Property

    Public Property Fecha_Proc() As Date
        Get
            Return _Fecha_Proc
        End Get
        Set(ByVal value As Date)
            _Fecha_Proc = value
        End Set
    End Property

    Public Property Add() As String
        Get
            Return _Add
        End Get
        Set(ByVal value As String)
            _Add = value
        End Set
    End Property

    Public Property Ver() As String
        Get
            Return _Ver
        End Get
        Set(ByVal value As String)
            _Ver = value
        End Set
    End Property


End Class
