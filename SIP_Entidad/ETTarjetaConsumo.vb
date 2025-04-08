Public Class ETTarjetaConsumo
    Private _ID As String
    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal value As String)
            _ID = value
        End Set
    End Property

    Private _CodCia As String
    Public Property CodCia() As String
        Get
            Return _CodCia
        End Get
        Set(ByVal value As String)
            _CodCia = value
        End Set
    End Property

    Private _PlaCod As String
    Public Property PlaCod() As String
        Get
            Return _PlaCod
        End Get
        Set(ByVal value As String)
            _PlaCod = value
        End Set
    End Property

    Private _Nro_Tarjeta As String
    Public Property Nro_Tarjeta() As String
        Get
            Return _Nro_Tarjeta
        End Get
        Set(ByVal value As String)
            _Nro_Tarjeta = value
        End Set
    End Property

    Private _Saldo_Ini As Decimal
    Public Property Saldo_Ini() As Decimal
        Get
            Return _Saldo_Ini
        End Get
        Set(ByVal value As Decimal)
            _Saldo_Ini = value
        End Set
    End Property

    Private _Saldo_Fin As Decimal
    Public Property Saldo_Fin() As Decimal
        Get
            Return _Saldo_Fin
        End Get
        Set(ByVal value As Decimal)
            _Saldo_Fin = value
        End Set
    End Property

    Private _Fec_Emision As Date
    Public Property Fec_Emision() As Date
        Get
            Return _Fec_Emision
        End Get
        Set(ByVal value As Date)
            _Fec_Emision = value
        End Set
    End Property


    Private _Usuario As String
    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    ' Campos privados
    Private _Estado_Tarjeta As String
    Private _Moneda_Tarjeta As String
    Private _Tipo_Tarjeta As String
    Private _Codigo_Empleado As String
    Private _Codigo_Banco As String
    Private _Fecha_Emision As Date
    Private _Fecha_Vcmto As Date
    Private _Saldo_Inicial As Decimal
    Private _Saldo_Inicial1 As Decimal
    Private _Ciclo_De As Integer
    Private _Ciclo_Hasta As Integer

    ' Propiedades públicas con validaciones opcionales
    Public Property Estado_Tarjeta() As String
        Get
            Return _Estado_Tarjeta
        End Get
        Set(ByVal value As String)
            _Estado_Tarjeta = value
        End Set
    End Property

    Public Property Moneda_Tarjeta() As String
        Get
            Return _Moneda_Tarjeta
        End Get
        Set(ByVal value As String)
            _Moneda_Tarjeta = value
        End Set
    End Property

    Public Property Tipo_Tarjeta() As String
        Get
            Return _Tipo_Tarjeta
        End Get
        Set(ByVal value As String)
            _Tipo_Tarjeta = value
        End Set
    End Property

    Public Property Codigo_Empleado() As String
        Get
            Return _Codigo_Empleado
        End Get
        Set(ByVal value As String)
            _Codigo_Empleado = value
        End Set
    End Property

    Public Property Codigo_Banco() As String
        Get
            Return _Codigo_Banco
        End Get
        Set(ByVal value As String)
            _Codigo_Banco = value
        End Set
    End Property

    Public Property Fecha_Emision() As Date
        Get
            Return _Fecha_Emision
        End Get
        Set(ByVal value As Date)
            _Fecha_Emision = value
        End Set
    End Property

    Public Property Fecha_Vcmto() As Date
        Get
            Return _Fecha_Vcmto
        End Get
        Set(ByVal value As Date)
            _Fecha_Vcmto = value
        End Set
    End Property

    Public Property Saldo_Inicial() As Decimal
        Get
            Return _Saldo_Inicial
        End Get
        Set(ByVal value As Decimal)
            If value < 0 Then
                Throw New ArgumentException("El saldo inicial no puede ser negativo.")
            End If
            _Saldo_Inicial = value
        End Set
    End Property

    Public Property Saldo_Inicial1() As Decimal
        Get
            Return _Saldo_Inicial1
        End Get
        Set(ByVal value As Decimal)
            If value < 0 Then
                Throw New ArgumentException("El saldo inicial no puede ser negativo.")
            End If
            _Saldo_Inicial1 = value
        End Set
    End Property

    Public Property Ciclo_De() As Integer
        Get
            Return _Ciclo_De
        End Get
        Set(ByVal value As Integer)
            _Ciclo_De = value
        End Set
    End Property
    Public Property Ciclo_Hasta() As Integer
        Get
            Return _Ciclo_Hasta
        End Get
        Set(ByVal value As Integer)
            _Ciclo_Hasta = value
        End Set
    End Property


    Sub New()
        ID = 0
        CodCia = ""
        PlaCod = ""
        Saldo_Fin = 0.0
        Saldo_Ini = 0.0
        Usuario = ""
        Estado_Tarjeta = ""
        Moneda_Tarjeta = ""
        Tipo_Tarjeta = ""
        Codigo_Empleado = ""
        Codigo_Banco = ""
        Nro_Tarjeta = ""
        Fecha_Emision = Nothing
        Fecha_Vcmto = Nothing
        Saldo_Inicial = 0.0
        Saldo_Inicial1 = 0.0
        Ciclo_De = 0
        Ciclo_Hasta = 0
    End Sub

End Class