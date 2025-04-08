
Public Class ETOrden

    Inherits ETObjecto

    Private _ID As Int32 = 0
    Private _CodProducto As String = String.Empty
    Private _Especificaciones As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Cantidad As Decimal = Decimal.Zero
    Private _NroDocumento As String = String.Empty
    Private _TotalRuma As Decimal = Decimal.Zero
    Private _TotalSuministro As Decimal = Decimal.Zero
    Private _TotalChancadora As Decimal = Decimal.Zero
    Private _TotalMolino As Decimal = Decimal.Zero
    Private _TotalPlanta As Decimal = Decimal.Zero
    Private _FechaInicio As Date = Date.Now
    Private _Fecha As Date = Date.Now
    Private _FechaTerminacion As Date = Date.Now
    Private _FechaIngreso As Date = Date.Now
    Private _Tipo As Int16 = 0
    Private _CodEnlace As Int16 = 0
    'Private entInstActivo As New ETActivo
    Private _FechaActualizacion As Date = Date.Now
    Private _Status As String = String.Empty
    Private _Lista_Ruma As New List(Of ETRuma)
    Private _Cod_Cia As String = String.Empty
    Private _Cod_Alm As String = String.Empty

    Private _CodChancadora As String = String.Empty
    Private _CodMolino As String = String.Empty
    Private _HorasTrab As Double = 0
    Private _Cod_Planta As Long = 0

    Private _ConsumoSilicato As Decimal = Decimal.Zero
    Private _ConsumoSilice As Decimal = Decimal.Zero
    Private _TotalSilicato As Decimal = Decimal.Zero
    Private _TotalSilice As Decimal = Decimal.Zero
    Private _ProdSilice_Silicato As Decimal = Decimal.Zero
    Private _ProdSilice_Silice As Decimal = Decimal.Zero
    Private _SPID As Integer = 0
    Private _Cierre As String = "2"
    Private _Peso As Decimal = Decimal.Zero
    Private _UnidPeso As String = String.Empty
    Private _UnidProd As String = String.Empty
    Private _CostoxTON As Decimal = Decimal.Zero
    Private _CostoxTONAcum As Decimal = Decimal.Zero
    Private _Concepto As String = String.Empty
    Private _NroHoras As Decimal = Decimal.Zero
    Private _Proyeccion As Boolean = False
    Private _CantidadRequerida As Decimal = Decimal.Zero
    Private _FormulaRecirculado As Boolean = Boolean.FalseString
    Private _CantidadRecirculado As Decimal = Decimal.Zero
    Private _CodRuma As String = String.Empty
    Private _DesRuma As String = String.Empty
    Private _Chancadora As String = String.Empty
    Private _Molino As String = String.Empty
    Private _Tipo_Doc As String = String.Empty
    Private _Nuevo As Short = 0
    Private _Lote As String = String.Empty
    Private _Tipo_Mov As String = String.Empty
    Private _HorasMax As Decimal = Decimal.Zero
    Private _HorasParada As Decimal = Decimal.Zero
    Private _NroOpe As Integer = 0


    Public Property Lote() As String
        Get
            Return _Lote
        End Get
        Set(ByVal value As String)
            _Lote = value
        End Set
    End Property

    Public Property Tipo_Mov() As String
        Get
            Return _Tipo_Mov
        End Get
        Set(ByVal value As String)
            _Tipo_Mov = value
        End Set
    End Property

    Public Property HorasMax() As Decimal
        Get
            Return _HorasMax
        End Get
        Set(ByVal value As Decimal)
            _HorasMax = value
        End Set
    End Property

    Public Property HorasParada() As Decimal
        Get
            Return _HorasParada
        End Get
        Set(ByVal value As Decimal)
            _HorasParada = value
        End Set
    End Property

    Public Property NroOpe() As Integer
        Get
            Return _NroOpe
        End Get
        Set(ByVal value As Integer)
            _NroOpe = value
        End Set
    End Property

    Public Property CodEnlace() As Int32
        Get
            Return _CodEnlace
        End Get
        Set(ByVal value As Int32)
            _CodEnlace = value
        End Set
    End Property

    Public Overloads Property ID() As Int32
        Get
            Return _ID
        End Get
        Set(ByVal value As Int32)
            _ID = value
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

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
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

    Public Overloads Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
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

    Public Overloads Property FechaTerminacion() As Date
        Get
            Return _FechaTerminacion
        End Get
        Set(ByVal value As Date)
            _FechaTerminacion = value
        End Set
    End Property

    Public Overloads Property FechaIngreso() As Date
        Get
            Return _FechaIngreso
        End Get
        Set(ByVal value As Date)
            _FechaIngreso = value
        End Set
    End Property

    Public Overloads Property TotalRuma() As Decimal
        Get
            Return _TotalRuma
        End Get
        Set(ByVal value As Decimal)
            _TotalRuma = value
        End Set
    End Property

    Public Overloads Property TotalSuministro() As Decimal
        Get
            Return _TotalSuministro
        End Get
        Set(ByVal value As Decimal)
            _TotalSuministro = value
        End Set
    End Property

    Public Overloads Property TotalChancadora() As Decimal
        Get
            Return _TotalChancadora
        End Get
        Set(ByVal value As Decimal)
            _TotalChancadora = value
        End Set
    End Property

    Public Overloads Property TotalMolino() As Decimal
        Get
            Return _TotalMolino
        End Get
        Set(ByVal value As Decimal)
            _TotalMolino = value
        End Set
    End Property

    Public Property TotalPlanta() As Decimal
        Get
            Return _TotalPlanta
        End Get
        Set(ByVal value As Decimal)
            _TotalPlanta = value
        End Set
    End Property

    Public Property Especificaciones() As String
        Get
            Return _Especificaciones
        End Get
        Set(ByVal value As String)
            _Especificaciones = value
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

    Public Overloads Property NroDocumento() As String
        Get
            Return _NroDocumento
        End Get
        Set(ByVal value As String)
            _NroDocumento = value
        End Set
    End Property

    'Public Property InstActivo() As ETActivo
    '    Get
    '        Return entInstActivo
    '    End Get
    '    Set(ByVal value As ETActivo)
    '        entInstActivo = value
    '    End Set
    'End Property

    Public Property Lista_Ruma() As List(Of ETRuma)
        Get
            Return _Lista_Ruma
        End Get
        Set(ByVal value As List(Of ETRuma))
            _Lista_Ruma = value
        End Set
    End Property

    Public Property FechaActualizacion() As Date
        Get
            Return _FechaActualizacion
        End Get
        Set(ByVal value As Date)
            _FechaActualizacion = value
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

    Public Property Cod_Alm() As String
        Get
            Return _Cod_Alm
        End Get
        Set(ByVal value As String)
            _Cod_Alm = value
        End Set
    End Property

    Public Property CodMolino() As String
        Get
            Return _CodMolino
        End Get
        Set(ByVal value As String)
            _CodMolino = value
        End Set
    End Property
    Public Property HorasTrabajadas() As Double
        Get
            Return _HorasTrab
        End Get
        Set(ByVal value As Double)
            _HorasTrab = value
        End Set
    End Property

    Public Property Cod_Planta() As Long
        Get
            Return _Cod_Planta
        End Get
        Set(ByVal value As Long)
            _Cod_Planta = value
        End Set
    End Property

    Public Property ConsumoSilicato() As Decimal
        Get
            Return _ConsumoSilicato
        End Get
        Set(ByVal value As Decimal)
            _ConsumoSilicato = value
        End Set
    End Property

    Public Property ConsumoSilice() As Decimal
        Get
            Return _ConsumoSilice
        End Get
        Set(ByVal value As Decimal)
            _ConsumoSilice = value
        End Set
    End Property

    Public Property TotalSilicato() As Decimal
        Get
            Return _TotalSilicato
        End Get
        Set(ByVal value As Decimal)
            _TotalSilicato = value
        End Set
    End Property

    Public Property TotalSilice() As Decimal
        Get
            Return _TotalSilice
        End Get
        Set(ByVal value As Decimal)
            _TotalSilice = value
        End Set
    End Property

    Public Property ProdSilice_Silicato() As Decimal
        Get
            Return _ProdSilice_Silicato
        End Get
        Set(ByVal value As Decimal)
            _ProdSilice_Silicato = value
        End Set
    End Property

    Public Property ProdSilice_Silice() As Decimal
        Get
            Return _ProdSilice_Silice
        End Get
        Set(ByVal value As Decimal)
            _ProdSilice_Silice = value
        End Set
    End Property
    Public Property Spid() As Integer
        Get
            Return _SPID
        End Get
        Set(ByVal value As Integer)
            _SPID = value
        End Set
    End Property
    Public Property Cierre() As String
        Get
            Return _Cierre
        End Get
        Set(ByVal value As String)
            _Cierre = value
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

    Public Property UnidPeso() As String
        Get
            Return _UnidPeso
        End Get
        Set(ByVal value As String)
            _UnidPeso = value
        End Set
    End Property

    Public Property UnidProd() As String
        Get
            Return _UnidProd
        End Get
        Set(ByVal value As String)
            _UnidProd = value
        End Set
    End Property
    Public Property Concepto() As String
        Get
            Return _Concepto
        End Get
        Set(ByVal value As String)
            _Concepto = value
        End Set
    End Property
    Public Property CostoxTON() As Decimal
        Get
            Return _CostoxTON
        End Get
        Set(ByVal value As Decimal)
            _CostoxTON = value
        End Set
    End Property

    Public Property CostoxTONAcum() As Decimal
        Get
            Return _CostoxTONAcum
        End Get
        Set(ByVal value As Decimal)
            _CostoxTONAcum = value
        End Set
    End Property

    Public Property NroHoras() As Decimal
        Get
            Return _NroHoras
        End Get
        Set(ByVal value As Decimal)
            _NroHoras = value
        End Set
    End Property

    Public Property Proyeccion() As Boolean
        Get
            Return _Proyeccion
        End Get
        Set(ByVal value As Boolean)
            _Proyeccion = value
        End Set
    End Property

    Public Property CantidadRequerida() As Decimal
        Get
            Return _CantidadRequerida
        End Get
        Set(ByVal value As Decimal)
            _CantidadRequerida = value
        End Set
    End Property

    Public Property FormulaRecirculado() As Boolean
        Get
            Return _FormulaRecirculado
        End Get
        Set(ByVal value As Boolean)
            _FormulaRecirculado = value
        End Set
    End Property

    Public Property CantidadRecirculado() As Decimal
        Get
            Return _CantidadRecirculado
        End Get
        Set(ByVal value As Decimal)
            _CantidadRecirculado = value
        End Set
    End Property

    Public Property Cod_Chancadora() As String
        Get
            Return _CodChancadora
        End Get
        Set(ByVal value As String)
            _CodChancadora = value
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

    Public Property Chancadora() As String
        Get
            Return _Chancadora
        End Get
        Set(ByVal value As String)
            _Chancadora = value
        End Set
    End Property

    Public Property Molino() As String
        Get
            Return _Molino
        End Get
        Set(ByVal value As String)
            _Molino = value
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

    Public Property Nuevo() As Short
        Get
            Return _Nuevo
        End Get
        Set(ByVal value As Short)
            _Nuevo = value
        End Set
    End Property



End Class
