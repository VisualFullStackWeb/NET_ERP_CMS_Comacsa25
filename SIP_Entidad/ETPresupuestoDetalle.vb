Public Class ETPresupuestoDetalle
    Inherits ETObjecto

    Private _Item As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _UniMed As String = String.Empty
    Private _Metrado As Double = 0
    Private _Precio As Double = 0
    Private _Parcial As Double = 0
    Private _TipoCambio As Double = 0
    Private _Partida As Long = 0
    Private _TipoFactor As String = String.Empty
    Private _Jornada As Double = 0
    Private _Cod_UniMed As String = String.Empty
    Private _Status As String = String.Empty
    Private _Presupuesto As Long = 0
    Private _PresupuestoDet As Long = 0
    Private _Contar As Integer = 0

    Public Property Item() As String
        Get
            Return _Item
        End Get
        Set(ByVal value As String)
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
    Public Property UniMed() As String
        Get
            Return _UniMed
        End Get
        Set(ByVal value As String)
            _UniMed = value
        End Set
    End Property
    Public Property Metrado() As Double
        Get
            Return _Metrado
        End Get
        Set(ByVal value As Double)
            _Metrado = value
        End Set
    End Property
    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal value As Double)
            _Precio = value
        End Set
    End Property
    Public Property Parcial() As Double
        Get
            Return _Parcial
        End Get
        Set(ByVal value As Double)
            _Parcial = value
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
    Public Property Partida() As Long
        Get
            Return _Partida
        End Get
        Set(ByVal value As Long)
            _Partida = value
        End Set
    End Property
    Public Property TipoFactor() As String
        Get
            Return _TipoFactor
        End Get
        Set(ByVal value As String)
            _TipoFactor = value
        End Set
    End Property
    Public Property Jornada() As Double
        Get
            Return _Jornada
        End Get
        Set(ByVal value As Double)
            _Jornada = value
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
    Public Property PresupuestoDet() As Long
        Get
            Return _PresupuestoDet
        End Get
        Set(ByVal value As Long)
            _PresupuestoDet = value
        End Set
    End Property
    Public Property Contar() As Integer
        Get
            Return _Contar
        End Get
        Set(ByVal value As Integer)
            _Contar = value
        End Set
    End Property
End Class
