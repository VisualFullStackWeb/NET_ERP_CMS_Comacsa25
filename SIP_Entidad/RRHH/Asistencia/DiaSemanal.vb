Public Class DiaSemanal
    Private _dia As Date
    Private _tardanza As Double = 0.0
    Private _prima As Double = 0.0
    Private _horasExtras As Double = 0.0
    Private _diaNombre As String = ""
    Private _horasPrima2 As String = 0.0
    Private _horaInicio As String = ""
    Private _horaFin As String = ""
    Public Property fecha() As Date
        Get
            Return _dia
        End Get
        Set(ByVal value As Date)
            _dia = value
        End Set
    End Property
    Public Property diaNombre() As String
        Get
            Return _diaNombre
        End Get
        Set(ByVal value As String)
            _diaNombre = value
        End Set
    End Property
    Public Property horaInicio() As String
        Get
            Return _horaInicio
        End Get
        Set(ByVal value As String)
            _horaInicio = value
        End Set
    End Property
    Public Property horaFin() As String
        Get
            Return _horaFin
        End Get
        Set(ByVal value As String)
            _horaFin = value
        End Set
    End Property
    Public Property horasTrabajadas() As Double
        Get
            Return _tardanza
        End Get
        Set(ByVal value As Double)
            _tardanza = value
        End Set
    End Property
    Public Property horasPrima2() As Double
        Get
            Return _prima
        End Get
        Set(ByVal value As Double)
            _prima = value
        End Set
    End Property
    Public Property horasPrima3() As Double
        Get
            Return _horasPrima2
        End Get
        Set(ByVal value As Double)
            _horasPrima2 = value
        End Set
    End Property
    Public Property horasExtras() As Double
        Get
            Return _horasExtras
        End Get
        Set(ByVal value As Double)
            _horasExtras = value
        End Set
    End Property
    Public ReadOnly Property horasExtras1() As Double
        Get
            Dim value As Double = 0.0

            If horasExtras > 0 Then

                If horasExtras > 2 Then
                    value = 2
                Else
                    value = horasExtras
                End If
            End If

            Return value
        End Get
    End Property

    Public ReadOnly Property horasExtras2() As Double
        Get
            Dim value As Double = 0.0
            Dim horaExtraBase As Double = 2.0

            If horasExtras > 2 Then

                value = horasExtras - horaExtraBase
            End If

            Return value
        End Get
    End Property
End Class
