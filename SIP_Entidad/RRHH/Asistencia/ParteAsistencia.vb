Public Class ParteAsistencia
    Private _numeroTarjeta As String = ""
    Private _apellidosyNombres As String = ""
    Private _area As String = ""
    Private _listaDias As List(Of DiaSemanal)

    Public Property codigoEmpleado() As String
        Get
            Return _numeroTarjeta
        End Get
        Set(ByVal value As String)
            _numeroTarjeta = value
        End Set
    End Property
    Public Property apellidosyNombres() As String
        Get
            Return _apellidosyNombres
        End Get
        Set(ByVal value As String)
            _apellidosyNombres = value
        End Set
    End Property
    Public Property area() As String
        Get
            Return _area
        End Get
        Set(ByVal value As String)
            _area = value
        End Set
    End Property
    Public Property listaDias() As List(Of DiaSemanal)
        Get
            Return _listaDias
        End Get
        Set(ByVal value As List(Of DiaSemanal))
            _listaDias = value
        End Set
    End Property
    Public ReadOnly Property totalHorasTrabajadas() As Double
        Get

            Dim value As Double

            For Each item As DiaSemanal In listaDias
                value = value + item.horasTrabajadas
            Next

            Return value

        End Get
    End Property

    Public ReadOnly Property totalST2() As Double
        Get

            Dim value As Double = 0.0

            For Each item As DiaSemanal In listaDias
                value = value + item.horasPrima2
            Next

            Return value

        End Get
    End Property

    Public ReadOnly Property totalST3() As Double
        Get

            Dim value As Double = 0.0

            For Each item As DiaSemanal In listaDias
                value = value + item.horasPrima3
            Next

            Return value

        End Get
    End Property

    Public ReadOnly Property totalHorasExtras1() As Double
        Get

            Dim value As Double

            For Each item As DiaSemanal In listaDias
                value = value + item.horasExtras1
            Next

            Return value

        End Get
    End Property

    Public ReadOnly Property totalHorasExtras2() As Double
        Get

            Dim value As Double

            For Each item As DiaSemanal In listaDias
                value = value + item.horasExtras2
            Next

            Return value

        End Get
    End Property

    Public ReadOnly Property BonificaionPuntualidad() As Double
        Get

            Dim value As Double = 0.0

            Return value

        End Get
    End Property
    Public ReadOnly Property BonificaionProduccion() As Double
        Get

            Dim value As Double = 0.0

            Return value

        End Get
    End Property
    Public ReadOnly Property BonificacionOtros() As Double
        Get

            Dim value As Double = 0.0

            Return value

        End Get
    End Property
End Class
