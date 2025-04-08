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
Imports System.Drawing.Printing
Public Class FrmAutorizaIQBF
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

    Private Sub FrmAutorizaIQBF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtcodprov.Focus()
        CargaDatos()
    End Sub
    Sub CargaDatos()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        Dim dt As New DataTable
        dt = _objNegocio.CargarAutorizacionIQBF()
        Call CargarUltraGridxBinding(gridIQBF, Source1, dt)
    End Sub
    Sub Buscar()
        If txtcodprov.Focused = True Then
            If txtid.Text <> 0 Then Exit Sub
            Dim frm As New FrmListaTransportista
            frm.ShowDialog()
            txtcodprov.Text = codMotivodetalle.Trim
            txtproveedor.Text = Motivodetalle.Trim
            txtruc.Text = Ruc.Trim
            txtcodprod.Focus()
            Exit Sub
        End If
        If txtcodprod.Focused = True Then
            If txtid.Text <> 0 Then Exit Sub
            Dim frm As New FrmListaProdIQBF
            frm.ShowDialog()
            txtcodprod.Text = frm.gridMotivos.ActiveRow.Cells("COD_PROD").Value.ToString.Trim
            txtproducto.Text = frm.gridMotivos.ActiveRow.Cells("PRODUCTO").Value.ToString.Trim
            txtobservacion.Focus()
            Exit Sub
        End If
    End Sub
    Sub Nuevo()
        Limpiar()
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Ope = 1
    End Sub
    Sub Limpiar()
        txtcodprov.Clear()
        txtproveedor.Clear()
        txtid.Text = 0
        txtcodprod.Clear()
        txtproducto.Clear()
        txtobservacion.Clear()
        txtruc.Clear()
        dtinicio.Value = Now.Date
        txtcodprov.Focus()
    End Sub
    Sub Grabar()
        Try
            If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
            If txtcodprov.Text.Trim = "" Then MsgBox("Ingrese Proveedor", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            If txtcodprod.Text.Trim = "" Then MsgBox("Ingrese Producto", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            'If txtmonto.Text.Trim = "" Then txtmonto.Text = 0.0
            If MsgBox("¿Seguro desea guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto

            Ope = 1

            _objNegocio = New NGProducto
            _objEntidad = New ETProducto

            _objEntidad.CodTransportista = txtcodprov.Text
            _objEntidad.CodProducto = txtcodprod.Text
            _objEntidad.FechaInicio = dtinicio.Value
            _objEntidad.User_Crea = User_Sistema
            _objEntidad.Observacion = txtobservacion.Text
            _objEntidad.ID = txtid.Text
            _objEntidad.Tipo = Ope
            Dim DTTABLE As New DataTable
            DTTABLE = _objNegocio.Autorizacion_IQBF(_objEntidad)
            If DTTABLE.Rows.Count > 0 Then
                If DTTABLE.Rows(0)(0) = "OK" Then
                    MsgBox("Se guardaron correctamente los datos", MsgBoxStyle.Information, msgComacsa)
                    Procesar()
                Else
                    MsgBox(DTTABLE.Rows(0)(0), MsgBoxStyle.Information, msgComacsa)
                End If
            Else
                MsgBox("Se produjo un error al grabar", MsgBoxStyle.Information, msgComacsa)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Procesar()
        Tab1.Tabs("T01").Selected = Boolean.TrueString
        Limpiar()
        CargaDatos()
    End Sub
    Sub Eliminar()
        Try
            If Tab1.Tabs("T02").Selected = Boolean.TrueString Then Exit Sub
            'If txtcodprov.Text.Trim = "" Then MsgBox("Ingrese Proveedor", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            'If txtcodprod.Text.Trim = "" Then MsgBox("Ingrese Producto", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            'If txtmonto.Text.Trim = "" Then txtmonto.Text = 0.0
            If MsgBox("¿Seguro desea eliminar el registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto

            Ope = 3

            _objNegocio = New NGProducto
            _objEntidad = New ETProducto

            _objEntidad.CodTransportista = txtcodprov.Text
            _objEntidad.CodProducto = txtcodprod.Text
            _objEntidad.FechaInicio = dtinicio.Value
            _objEntidad.User_Crea = User_Sistema
            _objEntidad.Observacion = txtobservacion.Text
            _objEntidad.ID = gridIQBF.ActiveRow.Cells("ID").Value
            _objEntidad.Tipo = Ope
            Dim DTTABLE As New DataTable
            DTTABLE = _objNegocio.Autorizacion_IQBF(_objEntidad)
            If DTTABLE.Rows.Count > 0 Then
                If DTTABLE.Rows(0)(0) = "OK" Then
                    MsgBox("Se eliminó el registro Correctamente", MsgBoxStyle.Information, msgComacsa)
                    Procesar()
                Else
                    MsgBox(DTTABLE.Rows(0)(0), MsgBoxStyle.Information, msgComacsa)
                End If
            Else
                MsgBox("Se produjo un error al eliminar", MsgBoxStyle.Information, msgComacsa)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridIQBF_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridIQBF.DoubleClickRow
        Try
            txtid.Text = gridIQBF.ActiveRow.Cells("ID").Value
            txtcodprov.Text = gridIQBF.ActiveRow.Cells("COD_PROV").Value
            txtproveedor.Text = gridIQBF.ActiveRow.Cells("RAZSOC").Value
            txtcodprod.Text = gridIQBF.ActiveRow.Cells("COD_PROD").Value
            txtproducto.Text = gridIQBF.ActiveRow.Cells("PRODUCTO").Value
            dtinicio.Value = gridIQBF.ActiveRow.Cells("FECHA").Value
            txtobservacion.Text = gridIQBF.ActiveRow.Cells("OBSERVACION").Value
            Tab1.Tabs("T02").Selected = True
        Catch ex As Exception

        End Try
    End Sub
End Class