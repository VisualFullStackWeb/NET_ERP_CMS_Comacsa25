Imports SIP_Entidad

Public Class ParteAsistencia
    Dim lista As List(Of SIP_Entidad.ParteAsistencia) = Nothing
    Public Enum enmTipoOrden
        ApellidosyNombres = 0
        codigoEmpleado = 1
    End Enum
    Public Function listarMarcacion(ByVal codigoArea As String, ByVal fechaInicio As Date, ByVal fechaFin As Date) As DataTable

        Try

            fechaInicio = CDate(fechaInicio & " 00:00:00")
            fechaFin = CDate(fechaFin & " 23:59:59")
            fechaFin = fechaFin.AddDays(1)
            Dim data As New SIP_Datos.ParteAsistencia
            Return data.listar("lst", "lst_marcacion_obrero", fechaInicio, fechaFin, codigoArea, "") 'xxx

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function    
    Private Function listarHorarioSemanal() As DataTable

        Try

            Dim data As New SIP_Datos.ParteAsistencia
            Return data.listar("lst", "lst_listar_horario_semanal", Now, Now, "", "")

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Private Function listarHorarioDiario() As DataTable

        Try

            Dim data As New SIP_Datos.ParteAsistencia
            Return data.listar("lst", "lst_listar_horario_diario", Now, Now, "", "")

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Private Function listarHorarioObreros(ByVal codigoArea As String, ByVal fechaInicio As Date, ByVal fechaFin As Date) As List(Of HorarioObrero)

        Try

            Dim value As New List(Of HorarioObrero)
            Dim data As New SIP_Datos.ParteAsistencia
            Dim dt As New DataTable

            dt = data.listar("lst", "lst_listar_horario_obreros_inicial", fechaInicio, fechaFin, codigoArea, "")

            Dim item As HorarioObrero = Nothing
            Dim codigoTrabajador As String = ""

            'agregar los horarios iniciales del trabajador
            For Each fila As DataRow In dt.Rows
                codigoTrabajador = fila("codigo").ToString

                If existeHorarioTrabajador(value, codigoTrabajador) = False Then
                    item = New HorarioObrero
                    With item
                        .codigoTrabajador = codigoTrabajador
                        .codigoHorario = fila("horario").ToString
                        .tipoHorario = fila("tipo_horario").ToString
                        .fecha = fila("fecha").ToString
                    End With
                    value.Add(item)
                End If

            Next

            'agregar los horarios que estan en el rango de la semana
            dt = data.listar("lst", "lst_listar_horario_obreros_rango", fechaInicio, fechaFin, codigoArea, "")

            For Each fila As DataRow In dt.Rows
                codigoTrabajador = fila("codigo").ToString
                item = New HorarioObrero
                With item
                    .codigoTrabajador = codigoTrabajador
                    .codigoHorario = fila("horario").ToString
                    .tipoHorario = fila("tipo_horario").ToString
                    .fecha = fila("fecha").ToString
                End With
                value.Add(item)
            Next

            Return value
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try

    End Function

    Public Function comboArea() As DataTable

        Try

            Dim data As New SIP_Datos.ParteAsistencia
            Return data.listar("lst", "lst_combo_area", Now, Now, "", "")

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function generarParteAsistencia(ByVal codigoArea As String, ByVal fechaInicio As Date, ByVal fechaFin As Date, _
            ByVal ordenarPor As enmTipoOrden) As List(Of SIP_Entidad.ParteAsistencia)

        '1.- obtener el dt, de las marcaciones de los trabajadores
        Dim dt As DataTable
        dt = listarMarcacion(codigoArea, fechaInicio, fechaFin)

        '2.- obtener el dt, del maestro de horario semanal 
        Dim dtHorarioSemanal As DataTable
        dtHorarioSemanal = listarHorarioSemanal()

        '3.- obtener el dt, del maestro de horario diario
        Dim dtHorarioDiario As DataTable
        dtHorarioDiario = listarHorarioDiario()

        '4.- obtener el dt, de los horarios de los trabajadores
        Dim listaHorarioObreros As List(Of HorarioObrero)
        listaHorarioObreros = listarHorarioObreros(codigoArea, fechaInicio, fechaFin)

        lista = New List(Of SIP_Entidad.ParteAsistencia)
        Dim item As SIP_Entidad.ParteAsistencia = Nothing

        '5.- agregar el codigo y el nombre del empleado
        Dim codigoEmpleado As String = ""

        For Each fila As DataRow In dt.Rows

            codigoEmpleado = fila("codigo").ToString

            If existeCodigoTrabajador(codigoEmpleado) = False Then
                item = New SIP_Entidad.ParteAsistencia

                item.codigoEmpleado = codigoEmpleado
                item.apellidosyNombres = fila("Apellidos_Nombres").ToString
                lista.Add(item)
            End If

        Next

        '5.1.- ordenar la lista
        'lista.Sort(Function(x, y) x.codigoEmpleado.CompareTo(y.codigoEmpleado))

        Select Case ordenarPor
            Case enmTipoOrden.ApellidosyNombres
                lista = lista.OrderBy(Function(x) x.apellidosyNombres).ToList()

            Case enmTipoOrden.codigoEmpleado
                lista = lista.OrderBy(Function(x) x.codigoEmpleado).ToList()
        End Select

        '6.- asignar valores a las fechas de cada trabajador
        Dim listaDias As List(Of DiaSemanal) = Nothing
        Dim registroDia As DiaSemanal = Nothing
        Dim dtFiltros As DataRow()
        Dim minutosMinHorasExtras As Integer = 30

        For Each registro As SIP_Entidad.ParteAsistencia In lista

            Dim fecha As Date = fechaInicio
            listaDias = New List(Of DiaSemanal)

            Dim marcaRelojInicio As String
            Dim marcaRelojFin As String
            Dim prima2 As Double = 0.0
            Dim prima3 As Double = 0.0
            Dim marcaTAmanecidaInicio As Boolean = False
            Dim marcaTAmanecidaFin As Boolean = False
            Dim turnoAmanecida As Boolean = False
            Dim salirBucle As Boolean = False
            Dim horaAsistenciaIni As String = ""
            Dim horaAsistenciaFin As String = ""

            Dim horarioInicio As String = ""
            Dim horarioFin As String = ""
            Dim minutosExtras As Integer = 0

            Do
                turnoAmanecida = False
                marcaRelojInicio = "00:00"
                marcaRelojFin = "00:00"

                '6.1.- obtener el horario del trabajador, validar el horario de amanecida
                If marcaTAmanecidaInicio = False Then
                    Dim horario As ArrayList
                    horario = fnObtenerHorarioTrabajador(listaHorarioObreros, dtHorarioSemanal, dtHorarioDiario, registro.codigoEmpleado, fecha)

                    If horario.Count > 1 Then
                        horarioInicio = horario(0)
                        horarioFin = horario(1)
                    Else
                        'no tiene horario
                        'el trabajado no tiene marcacion, posible falta o vacaciones, etc
                        listaDias.Add(fnAddDiaEnBlanco(fecha))
                        fecha = fecha.AddDays(1)

                        'evaluar condicion while
                        If fecha > fechaFin Then
                            salirBucle = True
                        End If
                        Continue Do
                    End If

                End If

                '6.1.- extraer hora inicio y hora fin del trabajador
                dtFiltros = dt.Select("codigo='" & registro.codigoEmpleado & "' and fecha='" & fecha.ToShortDateString & "'")
                If dtFiltros.Count > 0 Then
                    For Each f As System.Data.DataRow In dtFiltros

                        Dim fechaHora As Date = f("fecha_hora").ToString

                        If marcaRelojInicio = "00:00" Then
                            Dim horaTemp As String = Hour(fechaHora).ToString("00") & ":" & Minute(fechaHora).ToString("00") & ":" & Second(fechaHora).ToString("00")

                            If horarioInicio = "15:00" Then
                                If DateDiff(DateInterval.Hour, CDate(horaTemp), CDate(horarioInicio)) < 2 Then
                                    marcaRelojInicio = horaTemp
                                    Continue For
                                End If
                            Else
                                marcaRelojInicio = horaTemp
                                Continue For
                            End If

                        End If

                        If marcaRelojInicio <> "00:00" Then
                            marcaRelojFin = Hour(fechaHora).ToString("00") & ":" & Minute(fechaHora).ToString("00") & ":" & Second(fechaHora).ToString("00")
                        End If

                    Next
                Else

                    If marcaTAmanecidaInicio = True Then
                        marcaRelojInicio = "00:12"
                    Else

                        'el trabajado no tiene marcacion, posible falta o vacaciones, etc
                        listaDias.Add(fnAddDiaEnBlanco(fecha))
                        fecha = fecha.AddDays(1)

                        If fecha > fechaFin Then
                            salirBucle = True
                        End If

                        Continue Do
                    End If

                End If

                '/*************************************************************************/
                Dim horasTrabajadas As Double = 0.0
                Dim horasResto As Double = 0.0
                Dim horarioNormalDiurno As Boolean = False
                Dim horarioSabadoMedioDia As Boolean = False
                'si tiene el horario de 3er turno, entonces, hallar la hora salida que esta en el dia siguiente                                
                Select Case horarioInicio
                    Case "07:00" 'primer turno/horario normal

                        Select Case horarioFin
                            Case "15:00"
                                If marcaRelojInicio <= horarioInicio And marcaRelojFin >= horarioFin Then
                                    'marco dentro del horario nrmal
                                Else
                                    'horasResto = DateDiff(DateInterval.Hour, CDate(horarioInicio), CDate(marcaRelojInicio))

                                    If marcaRelojInicio >= horarioInicio Then
                                        horasResto = DateDiff(DateInterval.Minute, CDate(horarioInicio), CDate(marcaRelojInicio))

                                        If horasResto > 480 Then
                                            horasResto = 480
                                        End If

                                        horasResto = horasResto / 60
                                    End If

                                    If marcaRelojFin <> "00:00" And marcaRelojFin <= horarioFin Then
                                        horasResto = horasResto + (DateDiff(DateInterval.Minute, CDate(marcaRelojFin), CDate(horarioFin)))
                                        horasResto = horasResto / 60
                                    End If

                                End If

                            Case "12:00"
                                If marcaRelojInicio <= horarioInicio And marcaRelojFin >= horarioFin Then
                                    horarioSabadoMedioDia = True
                                End If

                            Case "16:21"
                                If marcaRelojInicio <= horarioInicio And marcaRelojFin >= horarioFin Then
                                    horarioNormalDiurno = True
                                Else

                                    If marcaRelojInicio >= horarioInicio Then
                                        horasResto = DateDiff(DateInterval.Minute, CDate(horarioInicio), CDate(marcaRelojInicio))
                                        horasResto = horasResto / 60
                                    End If

                                    If marcaRelojFin <= horarioFin Then
                                        horasResto = horasResto + (DateDiff(DateInterval.Minute, CDate(marcaRelojFin), CDate(horarioFin)))

                                        If horasResto > 501 Then
                                            horasResto = 501
                                        End If

                                        horasResto = horasResto / 60
                                    End If
                                    horarioNormalDiurno = True
                                End If

                        End Select

                        horaAsistenciaIni = marcaRelojInicio
                        horaAsistenciaFin = marcaRelojFin

                        'si tiene hora extras
                        If marcaRelojFin <> "00:00" Then
                            Dim minutosDespuesSalida As Integer = DateDiff(DateInterval.Minute, CDate(horarioFin), CDate(marcaRelojFin))
                            If minutosDespuesSalida > minutosMinHorasExtras Then
                                minutosExtras = minutosDespuesSalida
                            End If
                        End If

                    Case "15:00" 'segundo turno - 15:00-23:00

                        If marcaRelojInicio <= horarioInicio And marcaRelojFin >= horarioFin Then
                            prima2 = 5 * 0.5
                        End If

                        horaAsistenciaIni = marcaRelojInicio
                        horaAsistenciaFin = marcaRelojFin

                        'si tiene hora extras
                        If marcaRelojFin <> "00:00" Then
                            Dim minutosDespuesSalida As Integer = DateDiff(DateInterval.Minute, CDate(marcaRelojFin), CDate(horarioFin))
                            If minutosDespuesSalida > minutosMinHorasExtras Then
                                minutosExtras = minutosDespuesSalida
                            End If
                        End If

                    Case "23:00" ' tercer turno - 23:00-07:00

                        'falta controlar para que cuando no tenga fecha fin, no haga nada, continue con su bucle,xxxxx
                        If marcaRelojInicio <> "00:00" And marcaRelojFin <> "00:00" Then
                            If marcaTAmanecidaInicio = False Then
                                horaAsistenciaIni = marcaRelojFin
                                prima3 = 1
                                fecha = fecha.AddDays(1)
                                marcaTAmanecidaInicio = True
                                Continue Do
                            Else
                                horaAsistenciaFin = marcaRelojInicio
                                prima3 = prima3 + Hour(horarioFin) * 1
                                marcaTAmanecidaFin = True
                                turnoAmanecida = True
                            End If
                        Else

                            If horaAsistenciaIni.Length > 0 Then
                                horaAsistenciaFin = marcaRelojInicio

                                If (Hour(horaAsistenciaFin) * 1) > 0 Then
                                    prima3 = prima3 + Hour(horaAsistenciaFin) * 1
                                Else
                                    prima3 = 0
                                    horasResto = 8
                                End If

                                marcaTAmanecidaFin = True
                                turnoAmanecida = True
                            Else

                                'validar que la hora de marcacion sea del horario de inicio antes de las 23 horas, caso contario no se marco asistencia
                                If DateDiff(DateInterval.Hour, CDate(marcaRelojInicio), CDate(horarioInicio)) < 2 Then
                                    horaAsistenciaIni = marcaRelojInicio
                                    prima3 = 1
                                    fecha = fecha.AddDays(1)
                                    marcaTAmanecidaInicio = True
                                    Continue Do
                                Else

                                    'registrar dia en blanco
                                    listaDias.Add(fnAddDiaEnBlanco(fecha))
                                    fecha = fecha.AddDays(1)

                                    If fecha > fechaFin Then
                                        salirBucle = True
                                    End If

                                    Continue Do
                                End If

                            End If
                        End If

                End Select

                If marcaTAmanecidaFin = True Then
                    'si tiene hora extras
                    If horaAsistenciaFin <> "00:00" Then
                        Dim minutosDespuesSalida As Integer = DateDiff(DateInterval.Minute, CDate("07:00"), CDate(horaAsistenciaFin))
                        If minutosDespuesSalida > minutosMinHorasExtras Then
                            minutosExtras = minutosDespuesSalida
                        End If
                    End If
                End If

                horasTrabajadas = 8 - horasResto

                If horarioNormalDiurno = True Then
                    horasTrabajadas = horasTrabajadas + 0.6
                End If

                If horarioSabadoMedioDia = True Then
                    horasTrabajadas = 5
                End If

                'add un nuervo item
                registroDia = New DiaSemanal
                With registroDia
                    'si tiene turno noche, entonces la fecha de asistencia es del dia anterior
                    If marcaTAmanecidaFin = True Then
                        .fecha = fecha.AddDays(-1).ToShortDateString
                        .diaNombre = WeekdayName(Weekday(fecha.AddDays(-1)))
                    Else
                        .fecha = fecha.ToShortDateString
                        .diaNombre = WeekdayName(Weekday(fecha))
                    End If
                    .horaInicio = horaAsistenciaIni
                    .horaFin = horaAsistenciaFin
                    .horasTrabajadas = horasTrabajadas
                    .horasPrima2 = prima2
                    .horasPrima3 = prima3
                    .horasExtras = minutosExtras / 60
                End With

                listaDias.Add(registroDia)
                prima3 = 0 'borrar el dato de la prima
                prima2 = 0 'borrar el dato de la prima
                marcaTAmanecidaInicio = False
                marcaTAmanecidaFin = False
                horaAsistenciaIni = ""
                horaAsistenciaFin = ""
                minutosExtras = 0

                If turnoAmanecida = True Then
                    fecha = fecha
                Else
                    fecha = fecha.AddDays(1)
                End If

                If fecha > fechaFin Then
                    salirBucle = True
                End If

            Loop While salirBucle = False

            registro.listaDias = listaDias

        Next

        Return lista

    End Function
    Private Function fnAddDiaEnBlanco(ByVal fecha As Date) As DiaSemanal

        Dim registroDia As DiaSemanal = New DiaSemanal
        With registroDia
            .fecha = fecha.ToShortDateString
            .diaNombre = WeekdayName(Weekday(fecha))
            .horaInicio = "00:00"
            .horaFin = "00:00"
            .horasTrabajadas = 0
            .horasPrima2 = 0
            .horasPrima3 = 0
            .horasExtras = 0
        End With
        Return registroDia
    End Function
    Private Function fnObtenerHorarioTrabajador(ByVal listaHT As List(Of HorarioObrero), ByVal dtHorarioSemanal As DataTable, ByVal dtHorarioDiario As DataTable, _
                     ByVal codigoTrabajador As String, ByVal fecha As Date) As ArrayList

        Dim listaHorario As New ArrayList
        Dim codigoHorario As String = ""
        Dim tipoHorario As String = ""

        For Each item As HorarioObrero In listaHT

            If item.codigoTrabajador = codigoTrabajador Then
                If item.fecha <= fecha Then
                    codigoHorario = item.codigoHorario
                    tipoHorario = item.tipoHorario
                    'Exit For
                End If
            End If
        Next

        'buscar el horario semanal
        If codigoHorario.Length > 0 Then

            Dim dtFiltros As DataRow()
            Dim codigoHorarioDiario As String = ""
            Dim numeroDia As Integer = fecha.DayOfWeek
            If numeroDia = 0 Then numeroDia = 1

            'dtFiltros = dtHorarioSemanal.Select("horario='" & codigoHorario & "' and tipo_horario='" & tipoHorario & "' and num_dia=" & numeroDia)
            dtFiltros = dtHorarioSemanal.Select("horario='" & codigoHorario & "' and num_dia=" & numeroDia)

            For Each f As System.Data.DataRow In dtFiltros
                codigoHorarioDiario = f("horario_diario").ToString
            Next

            'buscar el horario diario
            If codigoHorarioDiario.Length > 0 Then
                dtFiltros = dtHorarioDiario.Select("horario='" & codigoHorarioDiario & "'")

                For Each f As System.Data.DataRow In dtFiltros
                    listaHorario.Add(f("hinicio").ToString)
                    listaHorario.Add(f("hfin").ToString)
                Next
            End If

        End If

        Return listaHorario

    End Function
    Private Function existeCodigoTrabajador(ByVal codigoEmpleado As String) As Boolean

        Dim value As Boolean = False

        For Each item As SIP_Entidad.ParteAsistencia In lista

            If item.codigoEmpleado = codigoEmpleado Then
                value = True
                Exit For
            End If
        Next

        Return value
    End Function
    Private Function existeHorarioTrabajador(ByVal lista As List(Of HorarioObrero), ByVal codigoTrabajador As String) As Boolean

        Dim value As Boolean = False

        For Each item As HorarioObrero In lista

            If item.codigoTrabajador = codigoTrabajador Then
                value = True
                Exit For
            End If
        Next

        Return value
    End Function

End Class
