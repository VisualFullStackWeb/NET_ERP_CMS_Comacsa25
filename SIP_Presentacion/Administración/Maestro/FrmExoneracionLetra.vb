Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class FrmExoneracionLetra
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private TipoG As sTate
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_EntregaDetalle As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
    Public tipoconsulta As Int32 = 0
#End Region   
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Sub Buscar()
        If txtid.Text <> 0 Then Exit Sub
        Dim frm As New FrmListaTransportista
        frm.ShowDialog()
        txtcodtransp.Text = codMotivodetalle.Trim
        txttransportista.Text = Motivodetalle.Trim
    End Sub
    Sub Limpiar()
        txtcodtransp.Clear()
        txttransportista.Clear()
        txtid.Text = 0
        txtmonto.Clear()
        txtobservacion.Clear()
        dtinicio.Value = Now.Date
        txtcodtransp.Focus()
    End Sub
    Sub Nuevo()
        Limpiar()
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Ope = 1
    End Sub

    Private Sub FrmLetraTransportista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtcodtransp.Focus()
        CargaDatos()
    End Sub
    Sub CargaDatos()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        Dim dt As New DataTable
        dt = _objNegocio.CargarExoneracion()
        Call CargarUltraGridxBinding(gridLetras, Source1, dt)
    End Sub

    Private Sub txtmonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonto.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub gridLetras_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridLetras.DoubleClickRow
        Try
            txtid.Text = gridLetras.ActiveRow.Cells("ID").Value
            txtcodtransp.Text = gridLetras.ActiveRow.Cells("COD_TRANSP").Value.ToString.Trim
            txttransportista.Text = gridLetras.ActiveRow.Cells("TRANSPORTISTA").Value.ToString.Trim
            txtobservacion.Text = gridLetras.ActiveRow.Cells("OBSERVACION").Value.ToString.Trim
            'txtmonto.Text = gridLetras.ActiveRow.Cells("MONTO").Value
            'dtinicio.Value = gridLetras.ActiveRow.Cells("FECHAINICIO").Value
            Tab1.Tabs("T02").Selected = Boolean.TrueString
            Ope = 2
        Catch ex As Exception

        End Try
    End Sub
    Sub Procesar()
        Tab1.Tabs("T01").Selected = Boolean.TrueString
        Limpiar()
        CargaDatos()
    End Sub
    Sub Cancelar()
        Tab1.Tabs("T01").Selected = Boolean.TrueString
        Limpiar()
    End Sub
    Sub Actualizar()
        Procesar()
    End Sub

    Sub Grabar()
        Try
            If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
            If txtcodtransp.Text.Trim = "" Then MsgBox("Ingrese Transportista", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            'If txtmonto.Text.Trim = "" Then txtmonto.Text = 0.0

            Dim dtValidacion As New DataTable
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.CodTransportista = txtcodtransp.Text
            dtValidacion = _objNegocio.ValidacionLetras(_objEntidad)

            If dtValidacion.Rows(0)(0) <> "OK" And txtid.Text = 0 Then
                MsgBox(dtValidacion.Rows(0)(0), MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If

            If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            If txtid.Text = 0 Then
                Ope = 1
            Else
                Ope = 2
            End If
            _objEntidad.CodTransportista = txtcodtransp.Text
            _objEntidad.Transportista = txttransportista.Text
            '_objEntidad.FechaInicio = dtinicio.Value
            '_objEntidad.FechaTerminacion = dtinicio.Value
            _objEntidad.User_Crea = User_Sistema
            '_objEntidad.Monto = txtmonto.Text
            _objEntidad.Observacion = txtobservacion.Text
            _objEntidad.ID = txtid.Text
            _objEntidad.Tipo = Ope
            Dim id As Int32
            id = _objNegocio.Exoneracion_Letra(_objEntidad)
            If id <> 0 Then
                MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
                Procesar()
            Else
                MsgBox("Se Produjo un Error al Grabar", MsgBoxStyle.Information, msgComacsa)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Sub Eliminar()
        Try
            If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
            If txtcodtransp.Text.Trim = "" Then MsgBox("Ingrese Transportista", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            If txtmonto.Text.Trim = "" Then txtmonto.Text = 0.0
            If MsgBox("¿Seguro desea eliminar letra?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            Ope = 3
            _objEntidad.CodTransportista = txtcodtransp.Text
            _objEntidad.Transportista = txttransportista.Text
            _objEntidad.FechaInicio = dtinicio.Value
            _objEntidad.FechaTerminacion = dtinicio.Value
            _objEntidad.User_Crea = User_Sistema
            _objEntidad.Monto = txtmonto.Text
            _objEntidad.Observacion = txtobservacion.Text
            _objEntidad.ID = txtid.Text
            _objEntidad.Tipo = Ope
            Dim id As Int32
            id = _objNegocio.Exoneracion_Letra(_objEntidad)
            If id <> 0 Then
                MsgBox("Se eliminó Correctamente lo Letra", MsgBoxStyle.Information, msgComacsa)
                Procesar()
            Else
                MsgBox("Se Produjo un Error al Eliminar", MsgBoxStyle.Information, msgComacsa)
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class