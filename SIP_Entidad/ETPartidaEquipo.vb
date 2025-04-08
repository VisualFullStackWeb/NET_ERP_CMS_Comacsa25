Public Class ETPartidaEquipo
    Inherits ETObjecto
    Private _Cod_Eq As String = String.Empty
    Private _Equipo As String = String.Empty
    Private _Cod_UniMed As String = String.Empty
    Private _UniMed As String = String.Empty
    Private _Cuadrilla As Double = 0
    Private _Cantidad As Double = 0
    Private _Precio As Double = 0
    Private _SubTotal As Double = 0
    Private _Status As String = String.Empty
    Private _EquipoID As Long = 0
    Private _Equipo_Ant As Long = 0
    Private _Partida As Long = 0

    Public Property Cod_Eq() As String
        Get
            Return _Cod_Eq
        End Get
        Set(ByVal value As String)
            _Cod_Eq = value
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
    Public Property Cuadrilla() As Double
        Get
            Return _Cuadrilla
        End Get
        Set(ByVal value As Double)
            _Cuadrilla = value
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
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
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
    Public Property Equipo_Ant() As Long
        Get
            Return _Equipo_Ant
        End Get
        Set(ByVal value As Long)
            _Equipo_Ant = value
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
