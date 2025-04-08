Public Class ETFCB
    Inherits ETObjecto

    Private _descripcion As String
    Private _cia As String
    Private _positivo As Integer
    Private _grupo As Integer
    Private _subgrupo As Integer
    Private _codmaestro As String
    Private _codmaestro3 As String
    Private _ingreso As Integer
    Private _dcambio As Integer

    Private _dprov As Integer

    Public Property dprov() As Integer
        Get
            Return _dprov
        End Get
        Set(ByVal value As Integer)
            _dprov = value
        End Set
    End Property

    Public Property dcambio() As Integer
        Get
            Return _dcambio
        End Get
        Set(ByVal value As Integer)
            _dcambio = value
        End Set
    End Property


    Public Property ingreso() As Integer
        Get
            Return _ingreso
        End Get
        Set(ByVal value As Integer)
            _ingreso = value
        End Set
    End Property



    Public Property codmaestro3() As String
        Get
            Return _codmaestro3
        End Get
        Set(ByVal value As String)
            _codmaestro3 = value
        End Set
    End Property

    Public Property codmaestro() As String
        Get
            Return _codmaestro
        End Get
        Set(ByVal value As String)
            _codmaestro = value
        End Set
    End Property

    Private _ciamaestro As String
    Public Property ciamaestro() As String
        Get
            Return _ciamaestro
        End Get
        Set(ByVal value As String)
            _ciamaestro = value
        End Set
    End Property

    Public Property subgrupo() As Integer
        Get
            Return _subgrupo
        End Get
        Set(ByVal value As Integer)
            _subgrupo = value
        End Set
    End Property

    Private _concepto As Integer
    Private _proveedor As String

    Public Property proveedor() As String
        Get
            Return _proveedor
        End Get
        Set(ByVal value As String)
            _proveedor = value
        End Set
    End Property

    Public Property concepto() As Integer
        Get
            Return _concepto
        End Get
        Set(ByVal value As Integer)
            _concepto = value
        End Set
    End Property


    Public Property grupo() As Integer
        Get
            Return _grupo
        End Get
        Set(ByVal value As Integer)
            _grupo = value
        End Set
    End Property


    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property cia() As String
        Get
            Return _cia
        End Get
        Set(ByVal value As String)
            _cia = value
        End Set
    End Property

    Public Property positivo() As Integer
        Get
            Return _positivo
        End Get
        Set(ByVal value As Integer)
            _positivo = value
        End Set
    End Property

End Class
