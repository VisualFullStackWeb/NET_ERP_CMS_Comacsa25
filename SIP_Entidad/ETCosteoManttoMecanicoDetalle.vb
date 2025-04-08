Public Class ETCosteoManttoMecanicoDetalle
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Horas As Double = 0
    Private _CostoManoObra As Decimal = 0
    Private _CostoMateriales As Decimal = 0
    Private _SubTotal As Decimal = Decimal.Zero
    Private _Porcentaje As Decimal = Decimal.Zero
    Private _Status As String = String.Empty
    Private _Usuario As String = String.Empty
    Private _Tipo As Short = 0

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

    Public Property Horas() As Double
        Get
            Return _Horas
        End Get
        Set(ByVal value As Double)
            _Horas = value
        End Set
    End Property

    Public Property CostoManoObra() As Decimal
        Get
            Return _CostoManoObra
        End Get
        Set(ByVal value As Decimal)
            _CostoManoObra = value
        End Set
    End Property

    Public Property CostoMateriales() As Decimal
        Get
            Return _CostoMateriales
        End Get
        Set(ByVal value As Decimal)
            _CostoMateriales = value
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

    Public Property Porcentaje() As Decimal
        Get
            Return _Porcentaje
        End Get
        Set(ByVal value As Decimal)
            _Porcentaje = value
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

End Class
