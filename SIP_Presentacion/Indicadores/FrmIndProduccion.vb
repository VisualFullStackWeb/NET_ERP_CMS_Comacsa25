Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Public Class FrmIndProduccion
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Public ConceptoSeleccionado As String
    Public filtroDescripcion As String = String.Empty
#End Region
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto


    Sub GenerarIndicador()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim dtDatos As New DataTable
            Dim dtDatosResumen As New DataTable
            Dim mes_ini As Int32 = cmbMesDesde.Value
            Dim mes_final As Int32 = cmbMesDesde.Value
            Dim dsDatos As New DataSet
            dtDatos = New DataTable
            dtDatosResumen = New DataTable
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMesDesde.Value
            _objEntidad.Usuario = userLogin
            dsDatos = _objNegocio.INDICADOR_PRODUCCION_FINAL(_objEntidad)
            dtDatos = dsDatos.Tables(0)
            dtDatosResumen = dsDatos.Tables(1)
            Call CargarUltraGridxBinding(gridProduccion, Source1, dtDatos)
            Call CargarUltraGridxBinding(gridKwh, Source2, dtDatosResumen)
        Catch ex As Exception
            'MsgBox(ex.Message)
            'm_Excel.Quit()
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Private Sub gridProduccion_FilterRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.FilterRowEventArgs) Handles gridProduccion.FilterRow
        'Dim color As String = CDate(e.Row.Cells("COLOR").Value())
        Dim diferencia As Int32 = 0
        If e.Row.Cells("COLOR").Value.ToString.Trim = "VERDE" Then
            e.Row.Cells("PINTAR").Appearance.BackColor = Color.Green
        ElseIf e.Row.Cells("COLOR").Value.ToString.Trim = "AMARILLO" Then
            e.Row.Cells("PINTAR").Appearance.BackColor = Color.Yellow
        ElseIf e.Row.Cells("COLOR").Value.ToString.Trim = "ROJO" Then
            e.Row.Cells("PINTAR").Appearance.BackColor = Color.Red
        End If
    End Sub

    Private Sub cmbMesDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMesDesde.ValueChanged
        Try
            Call GenerarIndicador()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmIndProduccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtayo.Value = Year(Now.Date)
        Me.cmbMesDesde.Value = Month(Now.Date)
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click

    End Sub
End Class