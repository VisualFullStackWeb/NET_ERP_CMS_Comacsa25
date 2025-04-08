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
Public Class FrmExcepcionPesoVehicular
    Public Ls_Permisos As New List(Of Integer)
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto

    Private Sub FrmExcepcionPesoVehicular_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub FrmExcepcionPesoVehicular_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtcodtransp.ReadOnly = False
        txtcodtransp.Focus()
        dtinicio.Value = "01/" & Month(Now) & "/" & Year(Now)
        dtinicio.Value = DateAdd(DateInterval.Month, -1, dtinicio.Value)
        dtfin.Value = Now.Date
    End Sub
    Private Sub txtcodtransp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodtransp.KeyDown
        If e.KeyValue = Keys.Enter Then
            Carga_Datos()
        End If
    End Sub
    Private Sub txtcodtransp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcodtransp.KeyPress
        'MsgBox("PRUEBA")
    End Sub
    Sub Procesar()
        Carga_Datos()
    End Sub
    Sub Carga_Datos()
        Try
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.CodTransportista = txtcodtransp.Text
            _objEntidad.FechaInicio = dtinicio.Value
            _objEntidad.FechaTerminacion = dtfin.Value
            Dim dt As New DataTable
            dt = _objNegocio.CargarBilletes(_objEntidad)
            Call CargarUltraGridxBinding(gridDetalle, Source1, dt)
            If dt.Rows.Count > 0 Then
                txttransportista.Text = dt.Rows(0)("transportista")
            Else
                MsgBox("No existen billetes para este transportista", MsgBoxStyle.Exclamation, msgComacsa)
                txttransportista.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Grabar()
        Try
            If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            gridDetalle.PerformAction(ExitEditMode)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            Dim list_entidades As New List(Of ETProducto)
            For i As Int32 = 0 To gridDetalle.Rows.Count - 1
                _objEntidad = New ETProducto
                _objEntidad.Cod_Cia = Companhia
                _objEntidad.User_Crea = User_Sistema
                _objEntidad.tipodoc = "TZ"
                _objEntidad.FechaInicio = dtinicio.Value
                _objEntidad.FechaTerminacion = dtfin.Value
                _objEntidad.numbillete = gridDetalle.Rows(i).Cells("numdoc").Value
                _objEntidad.check = IIf(gridDetalle.Rows(i).Cells("sel").Value.ToString = "True", 1, 0)
                _objEntidad.CodTransportista = txtcodtransp.Text
                list_entidades.Add(_objEntidad)
            Next
            Dim id As Int32
            id = _objNegocio.Billete_Exonerado(list_entidades)
            If id <> 0 Then
                Carga_Datos()
                MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            Else
                MsgBox("Se Produjo un Error al Grabar", MsgBoxStyle.Information, msgComacsa)
            End If
            '_objNegocio.MantenimientoEnlace()
        Catch ex As Exception

        End Try
    End Sub
    Sub Buscar()
        Dim frm As New FrmListaTransportista
        frm.ShowDialog()
        txtcodtransp.Text = codMotivodetalle.Trim
        txttransportista.Text = Motivodetalle.Trim
        Carga_Datos()
    End Sub
End Class