Public Class ETPartidaMaterial
    Inherits ETObjecto
    Private _Cod_Mat As String = String.Empty
    Private _Material As String = String.Empty
    Private _Material_Ant As String = String.Empty
    Private _Cod_UniMed As String = String.Empty
    Private _UniMed As String = String.Empty
    Private _Cantidad As Double = 0
    Private _Precio As Double = 0
    Private _SubTotal As Double = 0
    Private _Nro_OC As String = String.Empty
    Private _Status As String = String.Empty
    Private _Partida As Long = 0

    Public Property Cod_Mat() As String
        Get
            Return _Cod_Mat
        End Get
        Set(ByVal value As String)
            _Cod_Mat = value
        End Set
    End Property
    Public Property Material() As String
        Get
            Return _Material
        End Get
        Set(ByVal value As String)
            _Material = value
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
    Public Property UniMed() As String
        Get
            Return _UniMed
        End Get
        Set(ByVal value As String)
            _UniMed = value
        End Set
    End Property
    Public Overloads Property Cantidad() As Double
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Double)
            _Cantidad = value
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
    Public Property SubTotal() As Double
        Get
            Return _SubTotal
        End Get
        Set(ByVal value As Double)
            _SubTotal = value
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
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Public Property Material_Ant() As String
        Get
            Return _Material_Ant
        End Get
        Set(ByVal value As String)
            _Material_Ant = value
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
End Class
