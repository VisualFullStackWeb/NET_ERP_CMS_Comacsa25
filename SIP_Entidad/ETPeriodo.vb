Public Class ETPeriodo
    Private _Periodo As Integer = 0
    Private _Anio As Integer = 0
    Private _MesName As String = String.Empty
    Private _Mes As Short = 0
    Private _TipoPeriodo As sTipoPeriodo
    Private _ValorPeriodo As Decimal = Decimal.Zero
    Private _Valor2 As Decimal = Decimal.Zero
    Private _Valor3 As Decimal = Decimal.Zero
    Private _Valor4 As Decimal = Decimal.Zero
    Private _Valor5 As Decimal = Decimal.Zero
    Private _Valor6 As Decimal = Decimal.Zero
    Private _NroReg As Integer = 0
    Private _Estado As String = String.Empty
    Private _Status As String = String.Empty
    Private _Usuario As String = String.Empty
    Private _VarFiltrar As String = String.Empty
    Private _Tipo As Short = 0
    Public Enum sTipoPeriodo
        DistribucionPersonal_LinProd = 1
        CosteoGasNatural = 2
        CosteoPlantaCemento = 3
        CosteoSiliceHomogenizada = 4
        PeriodoCosteoProductos = 5
        PeriodoCosteoProductos_Facturacion = 6
        PeriodoCosteoProductos_Operador = 7
    End Enum


    Public Property Periodo() As Integer
        Get
            Return _Periodo
        End Get
        Set(ByVal value As Integer)
            _Periodo = value
        End Set
    End Property

    Public Property Anio() As Integer
        Get
            Return _Anio
        End Get
        Set(ByVal value As Integer)
            _Anio = value
        End Set
    End Property

    Public Property MesName() As String
        Get
            Return _MesName
        End Get
        Set(ByVal value As String)
            _MesName = value
        End Set
    End Property

    Public Property Mes() As Short
        Get
            Return _Mes
        End Get
        Set(ByVal value As Short)
            _Mes = value
        End Set
    End Property

    Public Property TipoPeriodo() As sTipoPeriodo
        Get
            Return _TipoPeriodo
        End Get
        Set(ByVal value As sTipoPeriodo)
            _TipoPeriodo = value
        End Set
    End Property

    Public Property NroReg() As Integer
        Get
            Return _NroReg
        End Get
        Set(ByVal value As Integer)
            _NroReg = value
        End Set
    End Property

    Public Property ValorPeriodo() As Decimal
        Get
            Return _ValorPeriodo
        End Get
        Set(ByVal value As Decimal)
            _ValorPeriodo = value
        End Set
    End Property

    Public Property Valor2() As Decimal
        Get
            Return _Valor2
        End Get
        Set(ByVal value As Decimal)
            _Valor2 = value
        End Set
    End Property

    Public Property Valor3() As Decimal
        Get
            Return _Valor3
        End Get
        Set(ByVal value As Decimal)
            _Valor3 = value
        End Set
    End Property

    Public Property Valor4() As Decimal
        Get
            Return _Valor4
        End Get
        Set(ByVal value As Decimal)
            _Valor4 = value
        End Set
    End Property

    Public Property Valor5() As Decimal
        Get
            Return _Valor5
        End Get
        Set(ByVal value As Decimal)
            _Valor5 = value
        End Set
    End Property

    Public Property Valor6() As Decimal
        Get
            Return _Valor6
        End Get
        Set(ByVal value As Decimal)
            _Valor6 = value
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

    Public Property VarFiltrar() As String
        Get
            Return _VarFiltrar
        End Get
        Set(ByVal value As String)
            _VarFiltrar = value
        End Set
    End Property

End Class
