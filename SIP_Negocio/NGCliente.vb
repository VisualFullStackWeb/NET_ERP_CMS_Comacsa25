Imports SIP_Entidad
Imports SIP_Datos
Imports System.Threading
Imports System.Globalization

Public Class NGCliente

    Private FechaCotizaMinima As Date = CDate("01-08-2010")
    Private FechaGuiaMinima As Date = CDate("01-07-2010")
    Private Hilo() As Thread
    Private SubClase() As ClsLotes
    Private Contador As Int32 = 0
    Private Ds As DataSet

    Public Function VerificarProforma(ByVal Rpt As ETProforma) As ETCliente

        Dim lResult As ETCliente = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

Ingresar:

        Try

            lResult = New ETCliente

            If String.IsNullOrEmpty(Rpt.NumPedido) Then
                MsgBox("Ingrese el Nro Proforma", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If
            If Rpt.NumPedido.Length <> 10 Then
                MsgBox("El Nro Proforma debe tener 10 digitos", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return lResult
        End Try

Operacion:

        lResult = Datos.Cliente.VerificarProforma(Rpt)

Comprobacion:

        If lResult Is Nothing Then
            lResult = New ETCliente
        Else
            If Not lResult.Validacion Then
                If lResult.Respuesta = 1 Then
                    MsgBox("La Proforma no Existe", MsgBoxStyle.Exclamation, msgComacsa)
                ElseIf lResult.Respuesta = 2 Then
                    MsgBox("La Proforma no pertenece al Área de Exportaciones", MsgBoxStyle.Exclamation, msgComacsa)
                End If
            End If
        End If

Salida:

        Return lResult

    End Function

    Public Function ConsultaProduccionDetallada(ByVal C As ETCliente) As ETObjecto

        ConsultaProduccionDetallada = New ETObjecto

Ingreso:

        If Not IsNumeric(C.Anho) Then
            MsgBox("Ingrese el Año Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If

        If Not IsNumeric(C.Mes) Then
            MsgBox("Ingrese el Mes Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If

        If Not IsNumeric(C.Semana) Then
            MsgBox("Ingrese el Semana Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If

        If IsDBNull(C.Codigo) OrElse Len(C.Codigo) <> 8 OrElse Mid(C.Codigo, 1, 1) <> "P" Then
            MsgBox("Ingrese el Codigo del Producto", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If

        C.FechaInicio = FechaGuiaMinima
        C.FechaFinal = ObtenerFecha(C.Anho, C.Mes)
        C.FechaFinal = C.FechaFinal.AddMonths(7)
Operacion:

        ConsultaProduccionDetallada = Datos.Cliente.ConsultaExportacion7(C)

        If ConsultaProduccionDetallada Is Nothing Then
            ConsultaProduccionDetallada = New ETObjecto
        Else
            ConsultaProduccionDetallada.Validacion = Boolean.TrueString
        End If

Salida:
        Return ConsultaProduccionDetallada

    End Function

    Public Function ConsultaProduccionAcumulado(ByVal C As ETCliente) As ETObjecto

        ConsultaProduccionAcumulado = New ETObjecto

Ingreso:

        If Not IsNumeric(C.Anho) Then
            MsgBox("Ingrese el Año Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Handle_Error1
        End If

        If Not IsNumeric(C.Mes) Then
            MsgBox("Ingrese el Mes Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Handle_Error1
        End If

        If IsDBNull(C.Codigo) OrElse Len(C.Codigo) <> 8 OrElse Mid(C.Codigo, 1, 1) <> "P" Then
            MsgBox("Ingrese el Codigo del Producto", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Handle_Error1
        End If

        C.FechaInicio = FechaCotizaMinima
        C.FechaFinal = ObtenerFecha(C.Anho, C.Mes).AddDays(-1)

        C.FechaGuiaInicio1 = FechaGuiaMinima
        C.FechaGuiaFinal1 = ObtenerFecha(C.Anho, C.Mes).AddDays(-1)
        C.FechaGuiaInicio2 = ObtenerFecha(C.Anho, C.Mes)
        C.FechaGuiaFinal2 = ObtenerFecha(C.Anho, C.Mes).AddMonths(1).AddDays(-1)

Operacion:

Fase1:
        Entidad.Objecto = New ETObjecto
        Entidad.Objecto = ConsultaExportacion8()

        If Entidad.Objecto Is Nothing Then GoTo Handle_Error1

Fase2:
        Entidad.Objecto = New ETObjecto
        Entidad.Objecto = ConsultaExportacion9()

        If Entidad.Objecto Is Nothing Then GoTo Handle_Error1

Fase3:
        Entidad.Objecto = New ETObjecto

        Entidad.Objecto = ConsultaExportacion10(C)

        If Entidad.Objecto Is Nothing Then GoTo Salida

Fase4:

        ConsultaProduccionAcumulado = ConsultaExportacion11(C)

        If ConsultaProduccionAcumulado Is Nothing Then
            ConsultaProduccionAcumulado = New ETObjecto
        Else
            ConsultaProduccionAcumulado.Validacion = Boolean.TrueString
        End If

        GoTo Salida

Handle_Error1:

        Return ConsultaProduccionAcumulado

Salida:
        ConsultaExportacion8()
        Return ConsultaProduccionAcumulado

    End Function

    Public Function ListarExportacion(ByVal C As ETCliente) As List(Of ETCliente)
        Return Datos.Cliente.ListarExportacion(C)
    End Function

    Public Function ConsultaProduccion(ByVal C As ETCliente) As DataTable

        ConsultaProduccion = New DataTable

        Try
Ingreso:
            If Not IsNumeric(C.Anho) Then
                MsgBox("Ingrese el Año Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Handle_Error1
            End If

            If Not IsNumeric(C.Mes) Then
                MsgBox("Ingrese el Mes Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Handle_Error1
            End If

            If Not (C.Tipo = 4 OrElse C.Tipo = 5) Then
                MsgBox("Ingrese el Tipo", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Handle_Error1
            End If

            If IsDBNull(C.Codigo) OrElse Len(C.Codigo) <> 8 Then C.Codigo = String.Empty

Fase1:
            Entidad.Objecto = New ETObjecto
            Entidad.Objecto = ConsultaExportacion1()

            If Entidad.Objecto Is Nothing Then
                GoTo Handle_Error1
            End If

Fase2:
            Entidad.Objecto = New ETObjecto

            Entidad.Objecto = ConsultaExportacion2()

            If Entidad.Objecto Is Nothing Then
                GoTo Handle_Error1
            End If

Fase3:
            Entidad.Objecto = New ETObjecto

            C.FechaInicio = FechaGuiaMinima
            C.FechaFinal = ObtenerFecha(C.Anho, C.Mes)
            C.FechaFinal = C.FechaFinal.AddMonths(7)

            Entidad.Objecto = ConsultaExportacion3(C)

            If Entidad.Objecto Is Nothing Then
                GoTo Handle_Error1
            End If

Fase4:
            C.FechaInicio = FechaCotizaMinima
            C.FechaFinal = ObtenerFecha(C.Anho, C.Mes)
            C.FechaFinal = C.FechaFinal.AddMonths(6)

            Dim v As Integer = 0

            v = DateDiff(DateInterval.Month, C.FechaInicio, C.FechaFinal)

            ReDim Preserve Hilo(v)
            ReDim Preserve SubClase(v)

            While C.FechaInicio <= C.FechaFinal

                Entidad.Cliente = New ETCliente

                Entidad.Cliente.Tipo = C.Tipo
                Entidad.Cliente.Mes = Month(C.FechaInicio)
                Entidad.Cliente.Anho = Year(C.FechaInicio)
                Entidad.Cliente.Codigo = C.Codigo

                SubClase(Contador) = New ClsLotes(Entidad.Cliente)

                Hilo(Contador) = New Thread(AddressOf SubClase(Contador).CargarTablaPPATempExportacion)

                Hilo(Contador).Start()

                If Contador = 6 Then Hilo(Contador).Join()

                Contador += 1

                C.FechaInicio = C.FechaInicio.AddMonths(1)

            End While

TerminaSubProceso:

            For k As Int32 = 0 To v
                If Hilo(k).IsAlive Then GoTo TerminaSubProceso
            Next

            Hilo = Nothing

Fase5:
            Entidad.Objecto = New ETObjecto
            Ds = ConsultaExportacion6(C)

            If Entidad.Objecto Is Nothing Then
                GoTo Limpiar
            End If

Fase6:
            Ds = New DataSet
            Ds.Locale = CultureInfo.InvariantCulture

            Ds = ConsultaExportacion6(C)

            If Ds IsNot Nothing AndAlso Ds.Tables.Count = 1 Then

                ConsultaProduccion = AlterarColumnas(Ds.Tables(0), C)

            End If

            GoTo Limpiar

        Catch

            GoTo Limpiar

        End Try

Handle_Error1:
        Return ConsultaProduccion
Limpiar:
        ConsultaExportacion1()
        Return ConsultaProduccion

    End Function

    Public Function Consultar_Cliente_Activos() As ETMyLista
        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        lResult = Datos.Cliente.Listar_Clientes_Activos
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function

    Private Function ObtenerFecha(ByVal Anho As Integer, _
                                  ByVal Mes As Integer) As Date

        ObtenerFecha = Date.Now
        ObtenerFecha = CDate("01-" + IIf(Len(CStr(Mes)) = 1, "0", "") + CStr(Mes) + "-" + CStr(Anho))

    End Function

    Private Function ConsultaExportacion1() As ETObjecto
        Return Datos.Cliente.ConsultaExportacion1
    End Function

    Private Function ConsultaExportacion2() As ETObjecto
        Return Datos.Cliente.ConsultaExportacion2()
    End Function

    Private Function ConsultaExportacion3(ByVal C As ETCliente) As ETObjecto
        Return Datos.Cliente.ConsultaExportacion3(C)
    End Function

    Private Function ConsultaExportacion6(ByVal C As ETCliente) As DataSet
        Return Datos.Cliente.ConsultaExportacion6(C)
    End Function

    Private Function ConsultaExportacion8() As ETObjecto
        Return Datos.Cliente.ConsultaExportacion8
    End Function

    Private Function ConsultaExportacion9() As ETObjecto
        Return Datos.Cliente.ConsultaExportacion9()
    End Function

    Private Function ConsultaExportacion10(ByVal C As ETCliente) As ETObjecto
        Return Datos.Cliente.ConsultaExportacion10(C)
    End Function

    Public Function ConsultaExportacion11(ByVal C As ETCliente) As ETObjecto
        Return Datos.Cliente.ConsultaExportacion11(C)
    End Function

    Private Function AlterarColumnas(ByVal dt As DataTable, ByVal C As ETCliente) As DataTable

        AlterarColumnas = New DataTable

        AlterarColumnas = dt.Copy

        AlterarColumnas.Columns.Add("Anho", Type.GetType("System.Int32"), C.Anho)
        AlterarColumnas.Columns.Add("Mes", Type.GetType("System.Int32"), C.Mes)

        AlterarColumnas.Columns.Remove(AlterarColumnas.Columns("Codigo1"))
        AlterarColumnas.Columns.Remove(AlterarColumnas.Columns("Descripcion1"))

        AlterarColumnas.AcceptChanges()

    End Function

    Private Class ClsLotes

        Public ET_Cliente As ETCliente

        Sub New(ByVal Rpt As ETCliente)
            ET_Cliente = New ETCliente
            ET_Cliente = Rpt
        End Sub

        Public Sub CargarTablaPPATempExportacion()
            If ET_Cliente.Tipo = 4 Then
                Datos.Cliente.ConsultaExportacion4(ET_Cliente)
            End If
            If ET_Cliente.Tipo = 5 Then
                Datos.Cliente.ConsultaExportacion5(ET_Cliente)
            End If
        End Sub

    End Class
End Class



