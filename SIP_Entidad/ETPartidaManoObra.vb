Public Class ETPartidaManoObra
    Inherits ETObjecto
    Private _Cod_Cargo As String = String.Empty
    Private _Cargo As String = String.Empty
    Private _Cod_UniMed As String = String.Empty
    Private _UniMed As String = String.Empty
    Private _Cuadrilla As Double = 0
    Private _Cantidad As Double = 0
    Private _Precio As Double = 0
    Private _SubTotal As Double = 0
    Private _Status As String = String.Empty
    Private _Cargo_Ant As String = String.Empty
    Private _Partida As Long = 0

    Public Property Cod_Cargo() As String
        Get
            Return _Cod_Cargo
        End Get
        Set(ByVal value As String)
            _Cod_Cargo = value
        End Set
    End Property
    Public Property Cargo() As String
        Get
            Return _Cargo
        End Get
        Set(ByVal value As String)
            _Cargo = value
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
    Public Property Cargo_Ant() As String
        Get
            Return _Cargo_Ant
        End Get
        Set(ByVal value As String)
            _Cargo_Ant = value
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
