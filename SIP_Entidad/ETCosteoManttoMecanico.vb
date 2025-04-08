Public Class ETCosteoManttoMecanico
    Inherits ETPeriodo
    Private _Horas As Double = 0
    Private _CostoManoObra As Decimal = Decimal.Zero
    Private _CostoMateriales As Decimal = Decimal.Zero
    Private _Total As Decimal = Decimal.Zero

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

    Public Property Total() As Decimal
        Get
            Return _Total
        End Get
        Set(ByVal value As Decimal)
            _Total = value
        End Set
    End Property


End Class
