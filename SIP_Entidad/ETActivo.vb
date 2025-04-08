Public Class ETActivo

    Inherits ETObjecto
    Private _Action As Boolean = Boolean.FalseString
    Private _CodInterno As String = String.Empty
    Private _Placa As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _CodClase As String = String.Empty
    Private _CodTipo As String = String.Empty
    Private _Clase As String = String.Empty
    Private _TipoEq As String = String.Empty
    Private _CostoxHora As Decimal = Decimal.Zero
    Private _Rendimiento As Decimal = Decimal.Zero
    Private _CostoPromxHora As Decimal = Decimal.Zero
    Private _CostoKwxHora As Decimal = Decimal.Zero
    Private _Energia As Decimal = Decimal.Zero
    Private _ID As Int32 = 0
    Private _CodEnlace As Int32 = 0
    Private _NroOperarios As Int16 = 0
    Private _Update As Boolean = Boolean.FalseString
    Private _DesTipo As String = String.Empty
    Private _MODhhxtn As Decimal = Decimal.Zero
    Private _MODSolxtn As Decimal = Decimal.Zero
    Private _EnergiaSolxtn As Decimal = Decimal.Zero
    Private _CostoxTon As Decimal = Decimal.Zero
    Private _TonMaximo As Decimal = Decimal.Zero
    Private _TonUtilizado As Decimal = Decimal.Zero
    Private _SubTotal As Decimal = Decimal.Zero
    Private _CantidadxFraccionada As Decimal = Decimal.Zero
    Private _Uso As Int32 = 0
    Private _CodLote As String = String.Empty
    Private _FechaInicio As Date = Date.Now
    Private _FechaFinal As Date = Date.Now
    Private _Fecha As Date = Date.Now
    Private _Cantidad As Decimal = Decimal.Zero
    Private _Item As Int32 = 0
    Private _Turno As Int16 = 0
    Private _Miercoles As Boolean = Boolean.FalseString
    Private _Jueves As Boolean = Boolean.FalseString
    Private _Viernes As Boolean = Boolean.FalseString
    Private _Sabado As Boolean = Boolean.FalseString
    Private _Domingo As Boolean = Boolean.FalseString
    Private _Lunes As Boolean = Boolean.FalseString
    Private _Martes As Boolean = Boolean.FalseString
    Private _AplicarSemana As Boolean = Boolean.FalseString

    Private _dtMiercoles As Date = Date.Now
    Private _dtJueves As Date = Date.Now
    Private _dtViernes As Date = Date.Now
    Private _dtSabado As Date = Date.Now
    Private _dtDomingo As Date = Date.Now
    Private _dtLunes As Date = Date.Now
    Private _dtMartes As Date = Date.Now
    Private _Turno1 As Boolean = Boolean.FalseString
    Private _Turno2 As Boolean = Boolean.FalseString
    Private _Turno3 As Boolean = Boolean.FalseString
    Private _Turno4 As Boolean = Boolean.FalseString
    Private _Rotar1 As Int16 = 0
    Private _Rotar2 As Int16 = 0
    Private _Rotar3 As Int16 = 0
    Private _Ls_Personal As New List(Of ETPersonal)
    Private _Activo As Long = 0
    Private _Status As String = String.Empty
    Private _Horas As Decimal = Decimal.Zero
    Private _HorasMax As Decimal = Decimal.Zero
    Private _HorasParada As Decimal = Decimal.Zero
    Private _ListaPersonal As New List(Of ETPersonal)

    Public Property Action() As Boolean
        Get
            Return _Action
        End Get
        Set(ByVal value As Boolean)
            _Action = value
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

    Public Property CodInterno() As String
        Get
            Return _CodInterno
        End Get
        Set(ByVal value As String)
            _CodInterno = value
        End Set
    End Property

    Public Property CodLote() As String
        Get
            Return _CodLote
        End Get
        Set(ByVal value As String)
            _CodLote = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
        End Set
    End Property

    Public Property Placa() As String
        Get
            Return _Placa
        End Get
        Set(ByVal value As String)
            _Placa = value
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

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property CodClase() As String
        Get
            Return _CodClase
        End Get
        Set(ByVal value As String)
            _CodClase = value
        End Set
    End Property

    Public Property Clase() As String
        Get
            Return _Clase
        End Get
        Set(ByVal value As String)
            _Clase = value
        End Set
    End Property

    Public Property CodTipo() As String
        Get
            Return _CodTipo
        End Get
        Set(ByVal value As String)
            _CodTipo = value
        End Set
    End Property

    Public Property TipoEq() As String
        Get
            Return _TipoEq
        End Get
        Set(ByVal value As String)
            _TipoEq = value
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

    Public Property Rendimiento() As Decimal
        Get
            Return _Rendimiento
        End Get
        Set(ByVal value As Decimal)
            _Rendimiento = value
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

    Public Property Energia() As Decimal
        Get
            Return _Energia
        End Get
        Set(ByVal value As Decimal)
            _Energia = value
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

    Public Property CostoPromxHora() As Decimal
        Get
            Return _CostoPromxHora
        End Get
        Set(ByVal value As Decimal)
            _CostoPromxHora = value
        End Set
    End Property

    Public Property CostoKwxHora() As Decimal
        Get
            Return _CostoKwxHora
        End Get
        Set(ByVal value As Decimal)
            _CostoKwxHora = value
        End Set
    End Property

    Public Property NroOperarios() As Int16
        Get
            Return _NroOperarios
        End Get
        Set(ByVal value As Int16)
            _NroOperarios = value
        End Set
    End Property

    Public Property DesTipo() As String
        Get
            Return _DesTipo
        End Get
        Set(ByVal value As String)
            _DesTipo = value
        End Set
    End Property

    Public Property MODhhxtn() As Decimal
        Get
            Return _MODhhxtn
        End Get
        Set(ByVal value As Decimal)
            _MODhhxtn = value
        End Set
    End Property

    Public Property MODSolxtn() As Decimal
        Get
            Return _MODSolxtn
        End Get
        Set(ByVal value As Decimal)
            _MODSolxtn = value
        End Set
    End Property

    Public Property EnergiaSolxtn() As Decimal
        Get
            Return _EnergiaSolxtn
        End Get
        Set(ByVal value As Decimal)
            _EnergiaSolxtn = value
        End Set
    End Property

    Public Property CostoxTon() As Decimal
        Get
            Return _CostoxTon
        End Get
        Set(ByVal value As Decimal)
            _CostoxTon = value
        End Set
    End Property

    Public Property TonMaximo() As Decimal
        Get
            Return _TonMaximo
        End Get
        Set(ByVal value As Decimal)
            _TonMaximo = value
        End Set
    End Property

    Public Property TonUtilizado() As Decimal
        Get
            Return _TonUtilizado
        End Get
        Set(ByVal value As Decimal)
            _TonUtilizado = value
        End Set
    End Property

    Public Property Uso() As Int32
        Get
            Return _Uso
        End Get
        Set(ByVal value As Int32)
            _Uso = value
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

    Public Overloads Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property

    Public Overloads Property Turno() As Int16
        Get
            Return _Turno
        End Get
        Set(ByVal value As Int16)
            _Turno = value
        End Set
    End Property

    Public Property Miercoles() As Boolean
        Get
            Return _Miercoles
        End Get
        Set(ByVal value As Boolean)
            _Miercoles = value
        End Set
    End Property

    Public Property Jueves() As Boolean
        Get
            Return _Jueves
        End Get
        Set(ByVal value As Boolean)
            _Jueves = value
        End Set
    End Property

    Public Property Viernes() As Boolean
        Get
            Return _Viernes
        End Get
        Set(ByVal value As Boolean)
            _Viernes = value
        End Set
    End Property

    Public Property Sabado() As Boolean
        Get
            Return _Sabado
        End Get
        Set(ByVal value As Boolean)
            _Sabado = value
        End Set
    End Property

    Public Property Domingo() As Boolean
        Get
            Return _Domingo
        End Get
        Set(ByVal value As Boolean)
            _Domingo = value
        End Set
    End Property

    Public Property Lunes() As Boolean
        Get
            Return _Lunes
        End Get
        Set(ByVal value As Boolean)
            _Lunes = value
        End Set
    End Property

    Public Property Martes() As Boolean
        Get
            Return _Martes
        End Get
        Set(ByVal value As Boolean)
            _Martes = value
        End Set
    End Property

    Public Property dtMiercoles() As Date
        Get
            Return _dtMiercoles
        End Get
        Set(ByVal value As Date)
            _dtMiercoles = value
        End Set
    End Property

    Public Property dtJueves() As Date
        Get
            Return _dtJueves
        End Get
        Set(ByVal value As Date)
            _dtJueves = value
        End Set
    End Property

    Public Property dtViernes() As Date
        Get
            Return _dtViernes
        End Get
        Set(ByVal value As Date)
            _dtViernes = value
        End Set
    End Property

    Public Property dtSabado() As Date
        Get
            Return _dtSabado
        End Get
        Set(ByVal value As Date)
            _dtSabado = value
        End Set
    End Property

    Public Property dtDomingo() As Date
        Get
            Return _dtDomingo
        End Get
        Set(ByVal value As Date)
            _dtDomingo = value
        End Set
    End Property

    Public Property dtLunes() As Date
        Get
            Return _dtLunes
        End Get
        Set(ByVal value As Date)
            _dtLunes = value
        End Set
    End Property

    Public Property dtMartes() As Date
        Get
            Return _dtMartes
        End Get
        Set(ByVal value As Date)
            _dtMartes = value
        End Set
    End Property

    Public Property Turno1() As Boolean
        Get
            Return _Turno1
        End Get
        Set(ByVal value As Boolean)
            _Turno1 = value
        End Set
    End Property

    Public Property Turno2() As Boolean
        Get
            Return _Turno2
        End Get
        Set(ByVal value As Boolean)
            _Turno2 = value
        End Set
    End Property

    Public Property Turno3() As Boolean
        Get
            Return _Turno3
        End Get
        Set(ByVal value As Boolean)
            _Turno3 = value
        End Set
    End Property

    Public Property Turno4() As Boolean
        Get
            Return _Turno4
        End Get
        Set(ByVal value As Boolean)
            _Turno4 = value
        End Set
    End Property

    Public Property Rotar1() As Int16
        Get
            Return _Rotar1
        End Get
        Set(ByVal value As Int16)
            _Rotar1 = value
        End Set
    End Property

    Public Property Rotar2() As Int16
        Get
            Return _Rotar2
        End Get
        Set(ByVal value As Int16)
            _Rotar2 = value
        End Set
    End Property

    Public Property Rotar3() As Int16
        Get
            Return _Rotar3
        End Get
        Set(ByVal value As Int16)
            _Rotar3 = value
        End Set
    End Property

    Public Property Activo() As Long
        Get
            Return _Activo
        End Get
        Set(ByVal value As Long)
            _Activo = value
        End Set
    End Property

    Public Property Ls_Personal() As List(Of ETPersonal)
        Get
            Return _Ls_Personal
        End Get
        Set(ByVal value As List(Of ETPersonal))
            _Ls_Personal = value
        End Set
    End Property

    Public Property AplicarSemana() As Boolean
        Get
            Return _AplicarSemana
        End Get
        Set(ByVal value As Boolean)
            _AplicarSemana = value
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

    Public Property Horas() As Decimal
        Get
            Return _Horas
        End Get
        Set(ByVal value As Decimal)
            _Horas = value
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

    Public Property ListaPersonal() As List(Of ETPersonal)
        Get
            Return _ListaPersonal
        End Get
        Set(ByVal value As List(Of ETPersonal))
            _ListaPersonal = value
        End Set
    End Property
End Class
