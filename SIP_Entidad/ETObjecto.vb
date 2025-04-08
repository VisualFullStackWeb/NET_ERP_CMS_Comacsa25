Public Class ETObjecto

    Private _Tipo As Int16 = 0
    Private _SemanaPrevia As Int16 = 0
    Private _Fecha As Date = Date.Now
    Private _FechaInicio As Date = Date.Now
    Private _FechaTerminacion As Date = Date.Now
    Private _FechaIngreso As Date = Date.Now
    Private _FechaHora As DateTime = DateTime.Now
    Private _Anho As Short = Short.MinValue
    Private _Anho1 As Short = Short.MinValue
    Private _Mes As Short = Short.MinValue
    Private _Mes1 As Short = Short.MinValue
    Private _Respuesta As Short = Short.MinValue
    Private _ValorxTexto As String = String.Empty
    Private _ValorxDecimal As Decimal = Decimal.Zero
    Private _ValorxEntero As Integer = 0
    Private _Usuario As String = String.Empty
    Private _Terminal As String = String.Empty
    Private _Validacion As Boolean = False
    Private _ID As Int32 = 0
    Private _IDSUPERVISOR As Int32
    Private _Datos As Object = Nothing
    Private _StockD As Decimal = Decimal.Zero
    Private _Unidad As String = String.Empty
    Private _StockV As Decimal = Decimal.Zero
    Private _StockPen As Decimal = Decimal.Zero
    Private _StockMin As Decimal = Decimal.Zero
    Private _NroReq As String = String.Empty
    Private _Update As Boolean = Boolean.FalseString
    Private _Semana As Int16 = 0
    Private _Dia As Int16 = 0
    Private _Turno As Int16 = 0
    Private _NroDocumento As String = String.Empty
    Private _TotalRuma As Decimal = Decimal.Zero
    Private _TotalSuministro As Decimal = Decimal.Zero
    Private _TotalChancadora As Decimal = Decimal.Zero
    Private _TotalMolino As Decimal = Decimal.Zero
    Private _FactorOriginal As String = String.Empty
    Private _FactorDestino As String = String.Empty
    Private _Factor As Decimal = Decimal.Zero
    Private _Operacion As String = String.Empty
    Private _Reader As DataTableReader = Nothing
    Private _Tabla As New DataTable
    Private _Coleccion As New DataSet
    Private _Imagen As New Object
    Private _Ls_Lista1 As New Object
    Private _Ls_Lista2 As New Object
    Private _NroInicio As Integer = 0
    Private _NroTermino As Integer = 0
    Private _NroViaje As Integer = 0
    Private _Sistema As String = String.Empty
    Private _TipoRecibo As String = String.Empty
    Private _periodo As String = String.Empty

    Private _MinVarD As Double = 0
    Private _MinVarI As Double = 0
    Private _MinFijD As Double = 0
    Private _MinFijI As Double = 0
    Private _MinFijO As Double = 0
    Private _ChaVarD As Double = 0
    Private _ChaVarI As Double = 0
    Private _ChaFijD As Double = 0
    Private _ChaFijI As Double = 0
    Private _MolVarD As Double = 0
    Private _MolVarI As Double = 0
    Private _MolFijD As Double = 0
    Private _MolFijI As Double = 0
    Private _Envases As Double = 0
    Private _GastoAdm As Double = 0
    Private _GastoVta As Double = 0
    Private _PorcChancadora As Double = 0
    Private _PorcMolino As Double = 0
    Private _Cantidad As Double = 0
    Private _Total As Double = 0
    Private _IDANEXO3 As Int32
    Private _ANEXO3 As String
    Private _Porcentaje As Double = 0
    Private _liberado As Int32
    Private _PLACA_TERCERO As String
    Private _tipograf As String
    Private _MesStr As String
    Private _YearStr As String
    Private _Mensaje As String

    Public Property Mensaje() As String
        Get
            Return _Mensaje
        End Get
        Set(ByVal value As String)
            _Mensaje = value
        End Set
    End Property

    Public Property MesStr() As String
        Get
            Return _MesStr
        End Get
        Set(ByVal value As String)
            _MesStr = value
        End Set
    End Property

    Public Property YearStr() As String
        Get
            Return _YearStr
        End Get
        Set(ByVal value As String)
            _YearStr = value
        End Set
    End Property

    Public Property tipograf() As String
        Get
            Return _tipograf
        End Get
        Set(ByVal value As String)
            _tipograf = value
        End Set
    End Property

    Public Property liberado() As Int32
        Get
            Return _liberado
        End Get
        Set(ByVal value As Int32)
            _liberado = value
        End Set
    End Property

    Public Property Porcentaje() As Double
        Get
            Return _Porcentaje
        End Get
        Set(ByVal value As Double)
            _Porcentaje = value
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

    Public Property ANEXO3() As String
        Get
            Return _ANEXO3
        End Get
        Set(ByVal value As String)
            _ANEXO3 = value
        End Set
    End Property

    Public Property PLACA_TERCERO() As String
        Get
            Return _PLACA_TERCERO
        End Get
        Set(ByVal value As String)
            _PLACA_TERCERO = value
        End Set
    End Property
    Public Property IDANEXO3() As Int32
        Get
            Return _IDANEXO3
        End Get
        Set(ByVal value As Int32)
            _IDANEXO3 = value
        End Set
    End Property

    Public Property Unidad() As String
        Get
            Return _Unidad
        End Get
        Set(ByVal value As String)
            _Unidad = value
        End Set
    End Property

    Public Property Cantidad() As Double
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Double)
            _Cantidad = value
        End Set
    End Property

    Public Property PorcChancadora() As Double
        Get
            Return _PorcChancadora
        End Get
        Set(ByVal value As Double)
            _PorcChancadora = value
        End Set
    End Property
    Public Property PorcMolino() As Double
        Get
            Return _PorcMolino
        End Get
        Set(ByVal value As Double)
            _PorcMolino = value
        End Set
    End Property
    Public Property MinVarD() As Double
        Get
            Return _MinVarD
        End Get
        Set(ByVal value As Double)
            _MinVarD = value
        End Set
    End Property
    Public Property MinVarI() As Double
        Get
            Return _MinVarI
        End Get
        Set(ByVal value As Double)
            _MinVarI = value
        End Set
    End Property
    Public Property MinFijD() As Double
        Get
            Return _MinFijD
        End Get
        Set(ByVal value As Double)
            _MinFijD = value
        End Set
    End Property
    Public Property MinFijI() As Double
        Get
            Return _MinFijI
        End Get
        Set(ByVal value As Double)
            _MinFijI = value
        End Set
    End Property
    Public Property MinFijO() As Double
        Get
            Return _MinFijO
        End Get
        Set(ByVal value As Double)
            _MinFijO = value
        End Set
    End Property
    Public Property ChaVarD() As Double
        Get
            Return _ChaVarD
        End Get
        Set(ByVal value As Double)
            _ChaVarD = value
        End Set
    End Property
    Public Property ChaVarI() As Double
        Get
            Return _ChaVarI
        End Get
        Set(ByVal value As Double)
            _ChaVarI = value
        End Set
    End Property
    Public Property ChaFijD() As Double
        Get
            Return _ChaFijD
        End Get
        Set(ByVal value As Double)
            _ChaFijD = value
        End Set
    End Property
    Public Property ChaFijI() As Double
        Get
            Return _ChaFijI
        End Get
        Set(ByVal value As Double)
            _ChaFijI = value
        End Set
    End Property
    Public Property MolVarD() As Double
        Get
            Return _MolVarD
        End Get
        Set(ByVal value As Double)
            _MolVarD = value
        End Set
    End Property
    Public Property MolVarI() As Double
        Get
            Return _MolVarI
        End Get
        Set(ByVal value As Double)
            _MolVarI = value
        End Set
    End Property
    Public Property MolFijD() As Double
        Get
            Return _MolFijD
        End Get
        Set(ByVal value As Double)
            _MolFijD = value
        End Set
    End Property
    Public Property MolFijI() As Double
        Get
            Return _MolFijI
        End Get
        Set(ByVal value As Double)
            _MolFijI = value
        End Set
    End Property
    Public Property Envases() As Double
        Get
            Return _Envases
        End Get
        Set(ByVal value As Double)
            _Envases = value
        End Set
    End Property
    Public Property GastoAdm() As Double
        Get
            Return _GastoAdm
        End Get
        Set(ByVal value As Double)
            _GastoAdm = value
        End Set
    End Property
    Public Property GastoVta() As Double
        Get
            Return _GastoVta
        End Get
        Set(ByVal value As Double)
            _GastoVta = value
        End Set
    End Property

    Public Property TipoRecibo() As String
        Get
            Return _TipoRecibo
        End Get
        Set(ByVal value As String)
            _TipoRecibo = value
        End Set
    End Property

    Public Property Sistema() As String
        Get
            Return _Sistema
        End Get
        Set(ByVal value As String)
            _Sistema = value
        End Set
    End Property

    Public Property Coleccion() As DataSet
        Get
            Return _Coleccion
        End Get
        Set(ByVal value As DataSet)
            _Coleccion = value
        End Set
    End Property

    Public Property Tabla() As DataTable
        Get
            Return _Tabla
        End Get
        Set(ByVal value As DataTable)
            _Tabla = value
        End Set
    End Property

    Public Property Reader() As DataTableReader
        Get
            Return _Reader
        End Get
        Set(ByVal value As DataTableReader)
            _Reader = value
        End Set
    End Property

    Public Property NroDocumento() As String
        Get
            Return _NroDocumento
        End Get
        Set(ByVal value As String)
            _NroDocumento = value
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

    Public Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property FechaHora() As DateTime
        Get
            Return _FechaHora
        End Get
        Set(ByVal value As DateTime)
            _FechaHora = value
        End Set
    End Property

    Public Property Anho() As Short
        Get
            Return _Anho
        End Get
        Set(ByVal value As Short)
            _Anho = value
        End Set
    End Property

    Public Property Anho1() As Short
        Get
            Return _Anho1
        End Get
        Set(ByVal value As Short)
            _Anho1 = value
        End Set
    End Property

    Public Property Mes() As Short
        Get
            Return _Mes
        End Get
        Set(ByVal value As Short)
            _Mes = value
        End Set
    End Property

    Public Property Mes1() As Short
        Get
            Return _Mes1
        End Get
        Set(ByVal value As Short)
            _Mes1 = value
        End Set
    End Property

    Public Property Respuesta() As Short
        Get
            Return _Respuesta
        End Get
        Set(ByVal value As Short)
            _Respuesta = value
        End Set
    End Property

    Public Property ValorxTexto() As String
        Get
            Return _ValorxTexto
        End Get
        Set(ByVal value As String)
            _ValorxTexto = value
        End Set
    End Property

    Public Property ValorxEntero() As Integer
        Get
            Return _ValorxEntero
        End Get
        Set(ByVal value As Integer)
            _ValorxEntero = value
        End Set
    End Property

    Public Property ValorxDecimal() As Decimal
        Get
            Return _ValorxDecimal
        End Get
        Set(ByVal value As Decimal)
            _ValorxDecimal = value
        End Set
    End Property

    Public Property Terminal() As String
        Get
            Return _Terminal
        End Get
        Set(ByVal value As String)
            _Terminal = value
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
    Private _Email As String = String.Empty
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Private _aprobado As String = String.Empty
    Public Property aprobado() As String
        Get
            Return _aprobado
        End Get
        Set(ByVal value As String)
            _aprobado = value
        End Set
    End Property

    Private _cadena As String = String.Empty
    Public Property cadena() As String
        Get
            Return _cadena
        End Get
        Set(ByVal value As String)
            _cadena = value
        End Set
    End Property

    Public Property Validacion() As Boolean
        Get
            Return _Validacion
        End Get
        Set(ByVal value As Boolean)
            _Validacion = value
        End Set
    End Property

    Public Property ID() As Int32
        Get
            Return _ID
        End Get
        Set(ByVal value As Int32)
            _ID = value
        End Set
    End Property

    Public Property IDSUPERVISOR() As Int32
        Get
            Return _IDSUPERVISOR
        End Get
        Set(ByVal value As Int32)
            _IDSUPERVISOR = value
        End Set
    End Property

    Public Property Datos() As Object
        Get
            Return _Datos
        End Get
        Set(ByVal value As Object)
            _Datos = value
        End Set
    End Property

    Public Property StockD() As Decimal
        Get
            Return _StockD
        End Get
        Set(ByVal value As Decimal)
            _StockD = value
        End Set
    End Property


    Public Property StockV() As Decimal
        Get
            Return _StockV
        End Get
        Set(ByVal value As Decimal)
            _StockV = value
        End Set
    End Property

    Public Property StockPen() As Decimal
        Get
            Return _StockPen
        End Get
        Set(ByVal value As Decimal)
            _StockPen = value
        End Set
    End Property

    Public Property StockMin() As Decimal
        Get
            Return _StockMin
        End Get
        Set(ByVal value As Decimal)
            _StockMin = value
        End Set
    End Property

    Public Property NroReq() As String
        Get
            Return _NroReq
        End Get
        Set(ByVal value As String)
            _NroReq = value
        End Set
    End Property

    Public Property Update() As Boolean
        Get
            Return _Update
        End Get
        Set(ByVal value As Boolean)
            _Update = value
        End Set
    End Property

    Public Property Semana() As Int16
        Get
            Return _Semana
        End Get
        Set(ByVal value As Int16)
            _Semana = value
        End Set
    End Property

    Public Property SemanaPrevia() As Int16
        Get
            Return _SemanaPrevia
        End Get
        Set(ByVal value As Int16)
            _SemanaPrevia = value
        End Set
    End Property

    Public Property Dia() As Int16
        Get
            Return _Dia
        End Get
        Set(ByVal value As Int16)
            _Dia = value
        End Set
    End Property

    Public Property Turno() As Int16
        Get
            Return _Turno
        End Get
        Set(ByVal value As Int16)
            _Turno = value
        End Set
    End Property

    Public Property FechaInicio() As Date
        Get
            Return _FechaInicio
        End Get
        Set(ByVal value As Date)
            _FechaInicio = value
        End Set
    End Property

    Public Property FechaTerminacion() As Date
        Get
            Return _FechaTerminacion
        End Get
        Set(ByVal value As Date)
            _FechaTerminacion = value
        End Set
    End Property

    Public Property FechaIngreso() As Date
        Get
            Return _FechaIngreso
        End Get
        Set(ByVal value As Date)
            _FechaIngreso = value
        End Set
    End Property

    Public Property TotalRuma() As Decimal
        Get
            Return _TotalRuma
        End Get
        Set(ByVal value As Decimal)
            _TotalRuma = value
        End Set
    End Property

    Public Property TotalSuministro() As Decimal
        Get
            Return _TotalSuministro
        End Get
        Set(ByVal value As Decimal)
            _TotalSuministro = value
        End Set
    End Property

    Public Property TotalChancadora() As Decimal
        Get
            Return _TotalChancadora
        End Get
        Set(ByVal value As Decimal)
            _TotalChancadora = value
        End Set
    End Property

    Public Property TotalMolino() As Decimal
        Get
            Return _TotalMolino
        End Get
        Set(ByVal value As Decimal)
            _TotalMolino = value
        End Set
    End Property

    Public Property FactorOriginal() As String
        Get
            Return _FactorOriginal
        End Get
        Set(ByVal value As String)
            _FactorOriginal = value
        End Set
    End Property

    Public Property FactorDestino() As String
        Get
            Return _FactorDestino
        End Get
        Set(ByVal value As String)
            _FactorDestino = value
        End Set
    End Property

    Public Property Factor() As Decimal
        Get
            Return _Factor
        End Get
        Set(ByVal value As Decimal)
            _Factor = value
        End Set
    End Property

    Public Property Operacion() As String
        Get
            Return _Operacion
        End Get
        Set(ByVal value As String)
            _Operacion = value
        End Set
    End Property

    Public Property Imagen() As Object
        Get
            Return _Imagen
        End Get
        Set(ByVal value As Object)
            _Imagen = value
        End Set
    End Property

    Public Property Ls_Lista1() As Object
        Get
            Return _Ls_Lista1
        End Get
        Set(ByVal value As Object)
            _Ls_Lista1 = value
        End Set
    End Property

    Public Property Ls_Lista2() As Object
        Get
            Return _Ls_Lista2
        End Get
        Set(ByVal value As Object)
            _Ls_Lista2 = value
        End Set
    End Property

    Public Property NroInicio() As Integer
        Get
            Return _NroInicio
        End Get
        Set(ByVal value As Integer)
            _NroInicio = value
        End Set
    End Property

    Public Property NroTermino() As Integer
        Get
            Return _NroTermino
        End Get
        Set(ByVal value As Integer)
            _NroTermino = value
        End Set
    End Property

    Public Property NroViaje() As Integer
        Get
            Return _NroViaje
        End Get
        Set(ByVal value As Integer)
            _NroViaje = value
        End Set
    End Property

    Public Property periodo() As String
        Get
            Return _periodo
        End Get
        Set(ByVal value As String)
            _periodo = value
        End Set
    End Property
End Class
