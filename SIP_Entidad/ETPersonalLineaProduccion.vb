Public Class ETPersonalLineaProduccion
    Private _Periodo As Long = 0
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _LinProd As Long = 0
    Private _CodLinProd As String = String.Empty
    Private _LineaProduccion As String = String.Empty
    Private _Porcentaje As Double = 0
    Private _Estado As String = String.Empty
    Private _Status As String = String.Empty
    Private _Usuario As String = String.Empty
    Private _Tipo As Short = 0
    Private _Asigna As String = String.Empty

    Public Property Periodo() As Long
        Get
            Return _Periodo
        End Get
        Set(ByVal value As Long)
            _Periodo = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
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

    Public Property LinProd() As Long
        Get
            Return _LinProd
        End Get
        Set(ByVal value As Long)
            _LinProd = value
        End Set
    End Property

    Public Property CodLinProd() As String
        Get
            Return _CodLinProd
        End Get
        Set(ByVal value As String)
            _CodLinProd = value
        End Set
    End Property

    Public Property LineaProduccion() As String
        Get
            Return _LineaProduccion
        End Get
        Set(ByVal value As String)
            _LineaProduccion = value
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

    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
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

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Tipo() As Short
        Get
            Return _Tipo
        End Get
        Set(ByVal value As Short)
            _Tipo = value
        End Set
    End Property
    Public Property Asigna() As String
        Get
            Return _Asigna
        End Get
        Set(ByVal value As String)
            _Asigna = value
        End Set
    End Property

End Class
