Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports SIP_Reporte
Public Class frmROrdenTrabajo_vs_Presupuesto
    Public Ls_Permisos As New List(Of Integer)

    Private Sub frmROrdenTrabajo_vs_Presupuesto_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmROrdenTrabajo_vs_OT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Cargar_Grilla()
    End Sub

    Private Sub Cargar_Grilla()
        Dim Ls_OrdenTrabajo As New List(Of ETOrdenTrabajo_Mantto)
        Entidad.MyLista = New ETMyLista
        Negocio.Orden_Trabajo = New NGOrdenTrabajo_Mantto

        Entidad.MyLista = Negocio.Orden_Trabajo.Reporte_OrdenTrabajo

        If Entidad.MyLista.Validacion Then
            Ls_OrdenTrabajo = Entidad.MyLista.Ls_Orden_Trabajo_Mantto
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_OrdenTrabajo)

    End Sub

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Abrev" OrElse uColumn.Key = "Codigo" _
               OrElse uColumn.Key = "Cod_Presp" OrElse uColumn.Key = "FechaInicio" _
               OrElse uColumn.Key = "Cliente" OrElse uColumn.Key = "Equipo" _
               OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "Moneda" _
               OrElse uColumn.Key = "CostoPresup" OrElse uColumn.Key = "CostoTotal" _
               OrElse uColumn.Key = "Estado") Then
                uColumn.Hidden = True
            Else
                uColumn.Hidden = False
            End If
        Next
    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Cargar_Grilla()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Public Sub Reporte()
        If Grid1.Rows.Count <= 0 Then Return
        If Grid1.ActiveRow Is Nothing Then Return

        StrucForm.VisorReport_Mantto = New frmVisorReporte
        StrucForm.VisorReport_Mantto.OrdenTrabajo = Grid1.ActiveRow.Cells("OrdenTrabajo").Value
        StrucForm.VisorReport_Mantto.Presupuesto = Grid1.ActiveRow.Cells("Presupuesto").Value
        StrucForm.VisorReport_Mantto.Status = Grid1.ActiveRow.Cells("Status").Value
        StrucForm.VisorReport_Mantto.MdiParent = MdiParent
        StrucForm.VisorReport_Mantto.Show()

    End Sub
End Class