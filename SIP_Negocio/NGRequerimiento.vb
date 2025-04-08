Imports SIP_Entidad
Imports SIP_Datos
Public Class NGRequerimiento

    'Private Ls_Ruma As List(Of ETRuma) = Nothing
    Private Ds As DataSet = Nothing

    Public Function MantenimientoRequerimiento(ByVal Rpt As ETRequerimiento, ByVal Ls_Ruma As List(Of ETRuma)) As ETRequerimiento

        Dim lResult As ETRequerimiento = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

Ingreso:

        lResult = New ETRequerimiento

        Try
            If String.IsNullOrEmpty(Rpt.NroReq) Then Rpt.NroReq = String.Empty

            If Not IsDate(Rpt.FechaLimite) Then
                MsgBox("Debe Ingresar la Fecha Requerida", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If String.IsNullOrEmpty(Rpt.Prioridad) Then
                MsgBox("Debe Ingresar la Prioridad del Requerimiento", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If String.IsNullOrEmpty(Rpt.Observacion) Then
                Rpt.Observacion = String.Empty
            Else
                Rpt.Observacion = Rpt.Observacion.Trim
            End If

            If String.IsNullOrEmpty(Rpt.Usuario) Then
                MsgBox("Ingrese el Usuario", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If Ls_Ruma Is Nothing OrElse Ls_Ruma.Count = 0 Then
                MsgBox("Debe tener una Lista de Rumas", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return lResult

        End Try

Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Requerimiento.MantenimientoRequerimiento(Rpt, Ls_Ruma)
        End If
Salida:

        If lResult Is Nothing Then
            lResult = New ETRequerimiento
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Private Function ConsultarRequerimiento(ByVal Rpt As ETRequerimiento) As ETRequerimiento

        Dim lResult As ETRequerimiento = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETRequerimiento
        lResult = Datos.Requerimiento.ConsultarRequerimiento(Rpt)

        If lResult Is Nothing Then lResult = New ETRequerimiento

        Return lResult

    End Function

    Public Function Consultar_MaestroxDetalle() As ETRequerimiento

        Dim lResult As ETRequerimiento = Nothing
        Dim TblMaestro As DataTable = Nothing
        Dim TblDetalle As DataTable = Nothing
        Dim DsColumnParent As DataColumn = Nothing
        Dim DsColumnChild As DataColumn = Nothing
        Dim DsRelation As DataRelation = Nothing

        Try

            Entidad.Requerimiento = New ETRequerimiento
            TblMaestro = New DataTable
            Entidad.Requerimiento.Tipo = 1

            Entidad.Requerimiento = ConsultarRequerimiento(Entidad.Requerimiento)
            TblMaestro = Entidad.Requerimiento.Tabla
            TblMaestro.TableName = "Maestro"

            '-------------------------------------------------------------------

            Entidad.Requerimiento = New ETRequerimiento
            TblDetalle = New DataTable
            Entidad.Requerimiento.Tipo = 2

            Entidad.Requerimiento = ConsultarRequerimiento(Entidad.Requerimiento)
            TblDetalle = Entidad.Requerimiento.Tabla
            TblDetalle.TableName = "Detalle"

            '-------------------------------------------------------------------

            Ds = New DataSet
            Ds.Tables.Add(TblMaestro)
            Ds.Tables.Add(TblDetalle)

            '-------------------------------------------------------------------

            DsColumnParent = Ds.Tables("Maestro").Columns("ID")
            DsColumnChild = Ds.Tables("Detalle").Columns("KeyID")
            DsRelation = New DataRelation("KeyForeign", DsColumnParent, DsColumnChild)

            '-------------------------------------------------------------------

            Ds.Relations.Add(DsRelation)

            '-------------------------------------------------------------------

            lResult = New ETRequerimiento
            lResult.Coleccion = Ds
            lResult.Validacion = Boolean.TrueString

        Catch
            lResult = New ETRequerimiento
        Finally

            Ds = Nothing
            TblMaestro = Nothing
            TblDetalle = Nothing
            DsColumnParent = Nothing
            DsColumnChild = Nothing
            DsRelation = Nothing

        End Try

        Return lResult

    End Function

    Private Function ConsultarRequerimiento3(ByVal Rpt As ETRequerimiento) As ETRequerimiento

        Dim lResult As ETRequerimiento = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETRequerimiento
        lResult = Datos.Requerimiento.ConsultarRequerimiento3(Rpt)

        If lResult Is Nothing Then lResult = New ETRequerimiento

        Return lResult

    End Function

    Private Function ConsultarRequerimiento4(ByVal Rpt As ETRequerimiento) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista

        lResult = Datos.Requerimiento.ConsultarRequerimiento4(Rpt)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function Consultar_Requerimiento(ByVal Rpt As ETRequerimiento) As ETRequerimiento

        Dim lResult As ETRequerimiento = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETRequerimiento
        lResult = ConsultarRequerimiento3(Rpt)

        If lResult Is Nothing OrElse Not lResult.Validacion Then
            lResult = New ETRequerimiento : Return lResult
        End If

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = ConsultarRequerimiento4(Rpt)

        If Entidad.MyLista Is Nothing OrElse Not Entidad.MyLista.Validacion Then
            lResult = New ETRequerimiento : Return lResult
        Else
            lResult.Ls_Lista1 = Entidad.MyLista.Ls_Ruma
        End If

        Return lResult

    End Function

    Public Function EliminarRequerimiento(ByVal Rpt As ETRequerimiento) As ETRequerimiento

        Dim lResult As ETRequerimiento = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

Ingreso:

        lResult = New ETRequerimiento

        If Not IsNumeric(Rpt.ID) OrElse Rpt.ID = 0 OrElse String.IsNullOrEmpty(Rpt.NroReq) Then
            MsgBox("No Posee Numero de Requerimiento", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        Entidad.Requerimiento = New ETRequerimiento
        Entidad.Requerimiento = ConsultarRequerimiento3(Rpt)

        If Not Entidad.Requerimiento.Validacion Then
            MsgBox("El Requerimiento ya Fue Eliminado", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Requerimiento.EliminarRequerimiento(Rpt)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETRequerimiento
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function CRxConsultar_Requerimiento(ByVal Rpt As ETRequerimiento) As ETRequerimiento

        Dim lResult As ETRequerimiento = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETRequerimiento
        lResult = Datos.Requerimiento.CRxConsultar_Requerimiento(Rpt)

        If lResult Is Nothing Then
            lResult = New ETRequerimiento
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function


    '=================================================

    Public Function GrabarRequerimientoCompra(ByVal Reque As ETRequerimiento, ByVal C As List(Of ETRequerimiento) _
                                              , ByVal Opcion As String, ByVal X As List(Of ETLisMaestroDocumentosTecnicos), _
                                              ByVal R As List(Of ETRequerimiento)) As ETResultado
        Return Datos.Requerimiento.GrabarRequerimientoCompra(Reque, C, Opcion, X, R)
    End Function

    Public Function GrabarRequerimientoCompraDistribuir(ByVal Productos As List(Of ETListDetalleRequerimiento), _
                                          ByVal Distribucion As List(Of ETListDetalleRequerimiento)) As ETResultado
        Return Datos.Requerimiento.GrabarRequerimientoCompraDistribuir(Productos, Distribucion)
    End Function

    Public Function EliminarRequerimientoCompraDistribuir(ByVal Requerimiento As ETRequerimiento) As ETResultado
        Return Datos.Requerimiento.EliminarRequerimientoCompraDistribuir(Requerimiento)
    End Function

    Public Function ListarRequerimiento(ByVal Reque As ETRequerimiento, ByVal Opcion As String) As DataTable
        Return Datos.Requerimiento.ListarRequerimiento(Reque, Opcion)
    End Function

    Public Function ListarRequerimientoCompra_Consolidado_Distribuir(ByVal Reque As ETRequerimiento, ByVal Opcion As String) As DataTable
        Return Datos.Requerimiento.ListarReqCompraConsolidadoDistribuir(Reque, Opcion)
    End Function

    Public Function ValidarRequerimientoOrigen(ByVal Reque As ETRequerimiento) As String
        Return Datos.Requerimiento.ValidarRequerimientoOrigen(Reque)
    End Function

    Public Function AprobarRequerimiento(ByVal Logistica As List(Of ETRequerimiento)) As ETResultado
        Return Datos.Requerimiento.AprobarRequerimiento(Logistica)
    End Function

    Public Function AnularRequerimientoLogistica(ByVal Logistica As ETRequerimiento) As ETResultado
        Return Datos.Requerimiento.AnularRequerimientoLogistica(Logistica)
    End Function

    Public Function ListarRequerimientoLogistica(ByVal Logistica As ETRequerimiento, ByVal Opcion As String) As DataTable
        Return Datos.Requerimiento.ListarRequerimientoLogistica(Logistica, Opcion)
    End Function

    Public Function ListarPromedioConsumoMensual(ByVal Reque As ETRequerimiento) As DataTable
        Return Datos.Requerimiento.ListarPromedioConsumoMensual(Reque)
    End Function

    Public Function ConsumoAreaUltimosAños(ByVal Reque As ETRequerimiento)
        Return Datos.Requerimiento.ConsumoAreaUltimosAños(Reque)
    End Function

    Public Function UltimoProveedorCompra(ByVal Reque As ETRequerimiento) As DataTable
        Return Datos.Requerimiento.UltimoProveedorCompra(Reque)
    End Function

    Public Function DiasUltimoPedido(ByVal Reque As ETRequerimiento) As DataTable
        Return Datos.Requerimiento.DiasUltimoPedido(Reque)
    End Function

    Public Function UltimoDespachoArea(ByVal Reque As ETRequerimiento) As DataTable
        Return Datos.Requerimiento.UltimoDespachoArea(Reque)
    End Function

    Public Function StockMesAnterior(ByVal Logistica As ETRequerimiento, ByVal xTipo As String) As ETResultado
        Return Datos.Requerimiento.StockMesAnterior(Logistica, xTipo)
    End Function

    Public Function Consumo_Ingreso_Mes(ByVal Reque As ETRequerimiento, ByVal Mov As String, ByVal Doc As String) As DataTable
        Return Datos.Requerimiento.Consumo_Ingreso_Mes(Reque, Mov, Doc)
    End Function

    Public Function UsuarioRequerimiento(ByVal Logistica As ETRequerimiento, ByVal Opcion As String) As DataTable
        Return Datos.Requerimiento.UsuarioRequerimiento(Logistica, Opcion)
    End Function

    Public Function ListarRequerimientoCompra() As DataTable
        Return Datos.Requerimiento.ListarRequerimientoCompra
    End Function

    Public Function ListarNombreCorto(ByVal Detalle As ETRequerimiento, ByVal Opcion As String) As DataTable
        Return Datos.Requerimiento.ListarNombreCorto(Detalle, Opcion)
    End Function



End Class
