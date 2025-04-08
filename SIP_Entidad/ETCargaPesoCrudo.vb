Public Class ETCargaPesoCrudo

    Private _Anio As Integer
    Public Property Anio() As Integer
        Get
            Return _Anio
        End Get
        Set(ByVal value As Integer)
            _Anio = value
        End Set
    End Property

    Private _Mes As Integer
    Public Property Mes() As Integer
        Get
            Return _Mes
        End Get
        Set(ByVal value As Integer)
            _Mes = value
        End Set
    End Property

    Private _Dia As Integer
    Public Property Dia() As Integer
        Get
            Return _Dia
        End Get
        Set(ByVal value As Integer)
            _Dia = value
        End Set
    End Property

    Private _PorcHumCaliza As Decimal
    Public Property PorcHumCaliza() As Decimal
        Get
            Return _PorcHumCaliza
        End Get
        Set(ByVal value As Decimal)
            _PorcHumCaliza = value
        End Set
    End Property

    Private _PorcHumSilice As Decimal
    Public Property PorcHumSilice() As Decimal
        Get
            Return _PorcHumSilice
        End Get
        Set(ByVal value As Decimal)
            _PorcHumSilice = value
        End Set
    End Property

    Private _PorcHumCaolin As Decimal
    Public Property PorcHumCaolin() As Decimal
        Get
            Return _PorcHumCaolin
        End Get
        Set(ByVal value As Decimal)
            _PorcHumCaolin = value
        End Set
    End Property

    Private _PorcHumPirofilita As Decimal
    Public Property PorcHumPirofilita() As Decimal
        Get
            Return _PorcHumPirofilita
        End Get
        Set(ByVal value As Decimal)
            _PorcHumPirofilita = value
        End Set
    End Property

    Private _BaseCaliza As Decimal
    Public Property BaseCaliza() As Decimal
        Get
            Return _BaseCaliza
        End Get
        Set(ByVal value As Decimal)
            _BaseCaliza = value
        End Set
    End Property

    Private _BaseSilice As Decimal
    Public Property BaseSilice() As Decimal
        Get
            Return _BaseSilice
        End Get
        Set(ByVal value As Decimal)
            _BaseSilice = value
        End Set
    End Property

    Private _BaseCaolin As Decimal
    Public Property BaseCaolin() As Decimal
        Get
            Return _BaseCaolin
        End Get
        Set(ByVal value As Decimal)
            _BaseCaolin = value
        End Set
    End Property

    Sub CargaPesoCrudo()

        Anio = 0
        Mes = 0
        Dia = 0
        PorcHumCaliza = 0.0
        PorcHumSilice = 0.0
        PorcHumCaolin = 0.0
        PorcHumPirofilita = 0.0
        BaseCaliza = 0.0
        BaseSilice = 0.0
        BaseCaolin = 0.0

    End Sub

End Class
