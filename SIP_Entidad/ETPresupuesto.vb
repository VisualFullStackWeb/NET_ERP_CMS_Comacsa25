Public Class ETPresupuesto
    Inherits ETObjecto
    Private _Action As Boolean = Boolean.FalseString
    Private _Presupuesto As Long = 0
    Private _Area As String = String.Empty
    Private _Area_Abrev As String = String.Empty
    Private _Cod_Presup As String = String.Empty
    Private _EncargadoArea As String = String.Empty
    Private _TipoCli As String = String.Empty
    Private _TipoCliente As Boolean = Boolean.FalseString
    Private _Cliente As String = String.Empty
    Private _RUC As String = String.Empty
    Private _AreaInterna As String = String.Empty
    Private _Equipo As String = String.Empty
    Private _TipoMantto As String = String.Empty
    Private _Atributo As String = String.Empty
    Private _ValorControl As String = String.Empty
    Private _UniMed As String = String.Empty
    Private _Prioridad As String = String.Empty
    Private _Moneda As String = String.Empty
    Private _Total As Double = 0
    Private _TipoCambio As Double = 0
    Private _Estado As String = String.Empty
    Private _Cod_Area As String = String.Empty
    Private _Cod_EncargadoArea As String = String.Empty
    Private _EncargadoAreaID As Long = 0
    Private _Cod_Cli As String = String.Empty
    Private _Cod_ClienteInt As String = String.Empty
    Private _Cod_AreaInt As String = String.Empty
    Private _EquipoID As Long = 0
    Private _TipoProceso As String = String.Empty
    Private _AtributoControl As Long = 0
    Private _Cod_UniMed As String = String.Empty
    Private _TipoDato As String = String.Empty
    Private _Longitud As Short = 0
    Private _Decimales As Short = 0
    Private _Cod_Prioridad As String = String.Empty
    Private _Status As String = String.Empty

    Public Property Action() As Boolean
        Get
            Return _Action
        End Get
        Set(ByVal value As Boolean)
            _Action = value
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
    Public Property Area_Abrev() As String
        Get
            Return _Area_Abrev
        End Get
        Set(ByVal value As String)
            _Area_Abrev = value
        End Set
    End Property
    Public Property Cod_Presup() As String
        Get
            Return _Cod_Presup
        End Get
        Set(ByVal value As String)
            _Cod_Presup = value
        End Set
    End Property
    Public Property EncargadoArea() As String
        Get
            Return _EncargadoArea
        End Get
        Set(ByVal value As String)
            _EncargadoArea = value
        End Set
    End Property
    Public Property TipoCli() As String
        Get
            Return _TipoCli
        End Get
        Set(ByVal value As String)
            _TipoCli = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
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
    Public Property AreaInterna() As String
        Get
            Return _AreaInterna
        End Get
        Set(ByVal value As String)
            _AreaInterna = value
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
    Public Property TipoMantto() As String
        Get
            Return _TipoMantto
        End Get
        Set(ByVal value As String)
            _TipoMantto = value
        End Set
    End Property
    Public Property Atributo() As String
        Get
            Return _Atributo
        End Get
        Set(ByVal value As String)
            _Atributo = value
        End Set
    End Property
    Public Property ValorControl() As String
        Get
            Return _ValorControl
        End Get
        Set(ByVal value As String)
            _ValorControl = value
        End Set
    End Property
    Public Property UniMed() As String
        Get
            Return _UniMed
        End Get
        Set(ByVal value As String)
            _UniMed = value
        End Set
    End Property
    Public Property Prioridad() As String
        Get
            Return _Prioridad
        End Get
        Set(ByVal value As String)
            _Prioridad = value
        End Set
    End Property
    Public Property Moneda() As String
        Get
            Return _Moneda
        End Get
        Set(ByVal value As String)
            _Moneda = value
        End Set
    End Property
    Public Overloads Property Total() As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = value
        End Set
    End Property
    Public Property TipoCambio() As Double
        Get
            Return _TipoCambio
        End Get
        Set(ByVal value As Double)
            _TipoCambio = value
        End Set
    End Property
    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
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
    Public Property Cod_EncargadoArea() As String
        Get
            Return _Cod_EncargadoArea
        End Get
        Set(ByVal value As String)
            _Cod_EncargadoArea = value
        End Set
    End Property
    Public Property EncargadoAreaID() As Long
        Get
            Return _EncargadoAreaID
        End Get
        Set(ByVal value As Long)
            _EncargadoAreaID = value
        End Set
    End Property
    Public Property TipoCliente() As Boolean
        Get
            Return _TipoCliente
        End Get
        Set(ByVal value As Boolean)
            _TipoCliente = value
        End Set
    End Property
    Public Property Cod_Cli() As String
        Get
            Return _Cod_Cli
        End Get
        Set(ByVal value As String)
            _Cod_Cli = value
        End Set
    End Property
    Public Property Cod_ClienteInt() As String
        Get
            Return _Cod_ClienteInt
        End Get
        Set(ByVal value As String)
            _Cod_ClienteInt = value
        End Set
    End Property
    Public Property Cod_AreaInt() As String
        Get
            Return _Cod_AreaInt
        End Get
        Set(ByVal value As String)
            _Cod_AreaInt = value
        End Set
    End Property
    Public Property EquipoID() As Long
        Get
            Return _EquipoID
        End Get
        Set(ByVal value As Long)
            _EquipoID = value
        End Set
    End Property
    Public Property TipoProceso() As String
        Get
            Return _TipoProceso
        End Get
        Set(ByVal value As String)
            _TipoProceso = value
        End Set
    End Property
    Public Property AtributoControl() As Long
        Get
            Return _AtributoControl
        End Get
        Set(ByVal value As Long)
            _AtributoControl = value
        End Set
    End Property
    Public Property Cod_UniMed() As String
        Get
            Return _Cod_UniMed
        End Get
        Set(ByVal value As String)
            _Cod_UniMed = value
        End Set
    End Property
    Public Property TipoDato() As String
        Get
            Return _TipoDato
        End Get
        Set(ByVal value As String)
            _TipoDato = value
        End Set
    End Property
    Public Property Longitud() As Short
        Get
            Return _Longitud
        End Get
        Set(ByVal value As Short)
            _Longitud = value
        End Set
    End Property
    Public Property Decimales() As Short
        Get
            Return _Decimales
        End Get
        Set(ByVal value As Short)
            _Decimales = value
        End Set
    End Property
    Public Property Cod_Prioridad() As String
        Get
            Return _Cod_Prioridad
        End Get
        Set(ByVal value As String)
            _Cod_Prioridad = value
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
    Public Property Presupuesto() As Long
        Get
            Return _Presupuesto
        End Get
        Set(ByVal value As Long)
            _Presupuesto = value
        End Set
    End Property
End Class
