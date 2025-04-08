Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmGastosVehiculos
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Entrega As List(Of ETEntregas) = Nothing

    Dim dsFiltros As DataSet
    Dim dtPlaXCenco As DataSet

    Dim dtCentrosCostos As DataTable
    Dim dtPlacas As DataTable
    Dim datos As DataTable


    Dim placa As String
    Dim cgcod As String
    Dim periodo As String
    Dim tituloRep As String
#End Region

    Private Sub FrmGastosVehiculos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        periodo = ""
        cargarFiltros()
    End Sub

#Region "Metodos"
    Sub cargarFiltros()

        'Llenar lista de centro de costo y placas

        Negocio.NEntregas = New NGEntregas
        periodo = txtAño.Value.ToString()
        dsFiltros = Negocio.NEntregas.ListarCentroCostoPlaca(periodo)

        dtCentrosCostos = dsFiltros.Tables(0)
        dtPlacas = dsFiltros.Tables(1)

        Try
            grdCencos.DataSource = dtCentrosCostos
            grdPlaca.DataSource = dtPlacas
        Catch ex As Exception
            MsgBox(ex.Message, "Centros de Costo no encontrador")
        End Try
    End Sub

    Sub CargarDatos()

        Dim cadenaCenCos As String
        Dim cadenaPlaca As String

        cadenaPlaca = ""
        cadenaCenCos = ""

        grdCencos.PerformAction(ExitEditMode)
        grdPlaca.PerformAction(ExitEditMode)

        For i As Int32 = 0 To grdCencos.Rows.Count - 1
            If grdCencos.Rows(i).Cells("sel").Value = True Then
                cadenaCenCos = cadenaCenCos + grdCencos.Rows(i).Cells("codcencos").Value.ToString() + ","
            End If
        Next

        For i As Int32 = 0 To grdPlaca.Rows.Count - 1
            If grdPlaca.Rows(i).Cells("sel").Value = True Then
                cadenaPlaca = cadenaPlaca + grdPlaca.Rows(i).Cells("placa").Value.ToString() + ","
            End If
        Next

        Negocio.NEntregas = New NGEntregas
        Dim dt As New DataSet
        dt = Negocio.NEntregas.ListarGatosVehiculos(periodo, cadenaCenCos, cadenaPlaca)
        GrdPropia.DataSource = dt.Tables(0)
        GrdAlquilada.DataSource = dt.Tables(1)
    End Sub
#End Region

    Private Sub FrmGastosVehiculos_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        Try
            CargarDatos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExportarPropia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarPropia.Click
        tituloRep = "REPORTE DE GASTOS DE VEHICULOS PROPIOS"
        Exportar(GrdPropia)
    End Sub

    Private Sub btnExportarAlquilados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarAlquilados.Click
        tituloRep = "REPORTE DE GASTOS DE VEHICULOS ALQUILADOS"
        Exportar(GrdAlquilada)
    End Sub

    Sub Exportar(ByVal grd As Infragistics.Win.UltraWinGrid.UltraGrid)

        FrmExportaExcel.Insertar_Cabecera = True
        Dim path As String
        path = Application.StartupPath


        FrmExportaExcel.exportFileName.Text = path + "\" + tituloRep & txtAño.Value.ToString() + ".xls"
        FrmExportaExcel.UltGrd = grd
        FrmExportaExcel.Titulo_Reporte = tituloRep
        FrmExportaExcel.Subtitulo_Reporte_1 = "Periodo : " & txtAño.Value.ToString()
        FrmExportaExcel.ShowDialog()
    End Sub

    Private Sub GrdPropia_DoubleClickRow_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GrdPropia.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot GrdPropia Then Return

        If e.Row.IsFilterRow Then Return


        placa = ""
        cgcod = ""

        grdPlacaCosto.PerformAction(ExitEditMode)

        placa = e.Row.Cells("cgaux").Value
        cgcod = e.Row.Cells("cgcod").Value

        Negocio.NEntregas = New NGEntregas
        Dim dt As New DataSet
        dtPlaXCenco = Negocio.NEntregas.ListarPlacasxCentro(periodo, cgcod, placa)
        grdPlacaCosto.DataSource = dtPlaXCenco.Tables(0)

        Tab1.Tabs("T02").Selected = True
    End Sub

    Private Sub GrdAlquilada_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GrdAlquilada.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot GrdAlquilada Then Return

        If e.Row.IsFilterRow Then Return

        Dim placa As String
        Dim cgcod As String

        placa = ""
        cgcod = ""

        grdPlacaCosto.PerformAction(ExitEditMode)

        placa = e.Row.Cells("cgaux").Value
        cgcod = e.Row.Cells("cgcod").Value

        Negocio.NEntregas = New NGEntregas
        Dim dt As New DataSet
        dtPlaXCenco = Negocio.NEntregas.ListarPlacasxCentro(periodo, cgcod, placa)
        grdPlacaCosto.DataSource = dtPlaXCenco.Tables(0)

        Tab1.Tabs("T02").Selected = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        tituloRep = "DETALLE DE GASTOS DE VEHICULO " + placa
        Exportar(grdPlacaCosto)
    End Sub

    Private Sub chkalmacen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkalmacen.CheckedChanged
        Try
            For i As Int32 = 0 To grdCencos.Rows.Count - 1
                grdCencos.Rows(i).Cells("sel").Value = chkalmacen.Checked
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkruma_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkruma.CheckedChanged
        Try
            For i As Int32 = 0 To grdPlaca.Rows.Count - 1
                grdPlaca.Rows(i).Cells("sel").Value = chkruma.Checked
            Next
        Catch ex As Exception

        End Try
    End Sub

End Class
