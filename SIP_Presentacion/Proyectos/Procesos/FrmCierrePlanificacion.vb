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
Imports System.Data
Public Class FrmCierrePlanificacion
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
    Dim dtTarea As New DataTable
    Dim dtSubTarea As New DataTable
    Dim dtSubTarea_Filtro As New DataTable
    Dim dtPersonal As New DataTable
    Dim dtMaterial As New DataTable
    Dim dtServicio As New DataTable
    Dim dtPlano As New DataTable
    Dim dtPlanoDet As New DataTable
    Dim obj_Proyecto As New NGProyecto
    Dim obj_EProyecto As New ETProyecto

    Private Sub FrmCierrePlanificacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFechacierre.Value = Now.Date
        dtfintaller.Value = Now.Date
        cargaData()
        limpiar()
    End Sub
    Sub Procesar()
        cargaData()
        Tab1.Tabs("T01").Selected = Boolean.TrueString
        limpiar()
    End Sub

    Sub cargaData()
        Dim dtPlanificacion As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        Dim dsData As New DataSet
        dsData = obj_Proyecto.Lista_PlanificacionAvance(obj_EProyecto)
        dtPlanificacion = dsData.Tables(0)
        gridProyecto.DataSource = dtPlanificacion
    End Sub

    Private Sub gridProyecto_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridProyecto.DoubleClickRow
        Try
            Tab1.Tabs("T02").Selected = Boolean.TrueString
            txtidproyecto.Text = gridProyecto.ActiveRow.Cells("ID_PROYECTO").Value
            txtproyecto.Text = gridProyecto.ActiveRow.Cells("PROYECTO").Value
            dtFecha.Value = gridProyecto.ActiveRow.Cells("FECHA").Value
            dtFechacierre.MinDate = dtFecha.Value
            txtcostototal.Text = gridProyecto.ActiveRow.Cells("COSTO").Value
            txtcierre.Text = gridProyecto.ActiveRow.Cells("FLGCIERRE").Value
            dtFechacierre.Value = gridProyecto.ActiveRow.Cells("FECHACIERRE").Value
            If txtcierre.Text = "0" Then
                btncierre.Text = "Cierre de planificación"
            Else
                btncierre.Text = "Apertura de planificación"
            End If
            cargaCostoTaller(txtidproyecto.Text)
        Catch ex As Exception

        End Try
    End Sub

    Sub cargaCostoTaller(ByVal id_proyecto As Int32)
        Dim dtPlanificacion As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.idproyecto = id_proyecto
        Dim dsData As New DataSet
        dsData = obj_Proyecto.Lista_PlanificacionProyecto(obj_EProyecto)
        dtPlanificacion = dsData.Tables(0)
        cmbTaller.DataSource = dtPlanificacion
        cmbTaller.ValueMember = "ID_TALLER"
        cmbTaller.DisplayMember = "TALLER"
        If dtPlanificacion.Rows.Count > 0 Then
            cmbTaller.Value = dtPlanificacion.Rows(0)("ID_TALLER")
        End If
    End Sub

    Sub cargaDetalleTaller(ByVal id_proyecto As Int32)
        Dim dtPlanificacion As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.idproyecto = id_proyecto
        obj_EProyecto.idtaller = cmbTaller.Value
        Dim dsData As New DataSet
        dsData = obj_Proyecto.Lista_DetalleTaller(obj_EProyecto)
        dtPlanificacion = dsData.Tables(0)
        If dtPlanificacion.Rows.Count > 0 Then
            dtiniciotaller.Value = dtPlanificacion.Rows(0)("FECHA_INICIO")
            dtfintaller.Value = dtPlanificacion.Rows(0)("FECHA_FIN")
            dtfintaller.MinDate = dtiniciotaller.Value
            txtnumoperario.Text = dtPlanificacion.Rows(0)("CANTIDAD_OPERARIO")
            txtcostotaller.Text = dtPlanificacion.Rows(0)("COSTO_TALLER")
            txthoraejecucion.Text = dtPlanificacion.Rows(0)("HORAS")
            txtcierretaller.Text = dtPlanificacion.Rows(0)("FLGCIERRE")
            If txtcierretaller.Text = "0" Then
                btncierretaller.Text = "Cierre de taller"
            Else
                btncierretaller.Text = "Apertura de taller"
            End If


        End If
    End Sub

    Private Sub cmbTaller_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbTaller.InitializeLayout
        With cmbTaller.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("TALLER").Width = sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "TALLER") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub cmbTaller_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTaller.ValueChanged
        Try
            cargaDetalleTaller(txtidproyecto.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncierre.Click
        Try
            If txtidproyecto.Text = 0 Then MsgBox("Debe seleccionar proyecto", MsgBoxStyle.Exclamation, "Validación") : Exit Sub
            If txtcierre.Text = "" Then MsgBox("Error al realizar proceso", MsgBoxStyle.Exclamation, "Validación") : Exit Sub
            If MsgBox("Desea cerrar planificación del proyecto?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
            Dim dtPlanificacion As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            Dim dsData As New DataSet
            Dim cierre As Int32
            If txtcierre.Text = "0" Then
                cierre = 1
            Else
                cierre = 0
            End If
            obj_EProyecto.idproyecto = txtidproyecto.Text
            obj_EProyecto.cierre = cierre
            obj_EProyecto.FechaTerminacion = dtFechacierre.Value
            obj_EProyecto.Usuario = User_Sistema
            dtPlanificacion = obj_Proyecto.CierreProyecto(obj_EProyecto)
            If dtPlanificacion.Rows.Count > 0 Then
                If dtPlanificacion.Rows(0)(0) = "OK" Then
                    MsgBox("Cierre de planificación realizado correctamente", MsgBoxStyle.Information, "sISTEMA")
                    Procesar()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub limpiar()
        txtidproyecto.Text = 0
        txtcierre.Text = ""
        txtcierretaller.Text = ""
        txtproyecto.Text = ""
        txtnumoperario.Text = ""
        txtcostototal.Text = "0.00"
        txtcostotaller.Text = "0.00"
        txthoraejecucion.Text = "0.00"
    End Sub

    Private Sub btncierretaller_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncierretaller.Click
        Try
            If txtcierre.Text = "1" Then MsgBox("No puede aperturar taller, el proyecto se encuentra cerrado", MsgBoxStyle.Exclamation, "Validación") : Exit Sub
            If txtcierretaller.Text = "" Then MsgBox("Error al realizar proceso", MsgBoxStyle.Exclamation, "Validación") : Exit Sub
            If MsgBox("Desea cerrar planificación del taller?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
            Dim dtPlanificacion As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            Dim dsData As New DataSet
            Dim cierre As Int32
            If txtcierretaller.Text = "0" Then
                cierre = 1
            Else
                cierre = 0
            End If
            obj_EProyecto.idproyecto = txtidproyecto.Text
            obj_EProyecto.idtaller = cmbTaller.Value
            obj_EProyecto.cierre = cierre
            obj_EProyecto.FechaTerminacion = dtfintaller.Value
            obj_EProyecto.Usuario = User_Sistema
            dtPlanificacion = obj_Proyecto.CierreTaller(obj_EProyecto)
            If dtPlanificacion.Rows.Count > 0 Then
                If dtPlanificacion.Rows(0)(0) = "OK" Then
                    MsgBox("Cierre de planificación realizado correctamente", MsgBoxStyle.Information, "sISTEMA")
                    cargaDetalleTaller(txtidproyecto.Text)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class