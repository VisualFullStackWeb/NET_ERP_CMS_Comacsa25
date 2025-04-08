Public Class ETCuentaCorriente
    Private _ID As Integer = 0
    Private _Fecha As Date = Date.Now
    Private _Documento As String = String.Empty
    Private _Numero As String = String.Empty
    Private _Detalle As String = String.Empty
    Private _Cantidad As Double = 0
    Private _Debe As Double = 0
    Private _Haber As Double = 0
    Private _Saldo As Double = 0
    Private _Lote As String = String.Empty
    Private _Voucher As String = String.Empty
    Private _VoucherConta As String = String.Empty

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
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

    Public Property Documento() As String
        Get
            Return _Documento
        End Get
        Set(ByVal value As String)
            _Documento = value
        End Set
    End Property

    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property

    Public Property Detalle() As String
        Get
            Return _Detalle
        End Get
        Set(ByVal value As String)
            _Detalle = value
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

    Public Property Debe() As Double
        Get
            Return _Debe
        End Get
        Set(ByVal value As Double)
            _Debe = value
        End Set
    End Property

    Public Property Haber() As Double
        Get
            Return _Haber
        End Get
        Set(ByVal value As Double)
            _Haber = value
        End Set
    End Property

    Public Property Saldo() As Double
        Get
            Return _Saldo
        End Get
        Set(ByVal value As Double)
            _Saldo = value
        End Set
    End Property
    Public Property Lote() As String
        Get
            Return _Lote
        End Get
        Set(ByVal value As String)
            _Lote = value
        End Set
    End Property
    Public Property Voucher() As String
        Get
            Return _Voucher
        End Get
        Set(ByVal value As String)
            _Voucher = value
        End Set
    End Property

    Public Property VoucherConta() As String
        Get
            Return _VoucherConta
        End Get
        Set(ByVal value As String)
            _VoucherConta = value
        End Set
    End Property
End Class
