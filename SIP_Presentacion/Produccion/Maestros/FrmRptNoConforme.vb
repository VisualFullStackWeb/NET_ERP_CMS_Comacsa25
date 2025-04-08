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
Public Class FrmRptNoConforme
    Public Ls_Permisos As New List(Of Integer)
    Dim procesado As Int32
    Dim _objNegocio As NGInsumosFiscalizados
    Dim _objEntidad As ETInsumosFiscalizados
    Dim cierre As Int32 = 0

    Private Sub FrmRptNoConforme_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpIni.Value = Now.Date
        dtpFin.Value = Now.Date
        ''Call ListarAlmacenNC(CboAlmacen, "28")

        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario

        Dim dtValores As New DataTable
        '_objNegocio = New NGProducto
        '_objEntidad = New ETProducto
        '_objEntidad.Anho = txtayo.Value
        '_objEntidad.ID = cmbArea.Value
        dtValores = Negocio.Usuario.MovimientosAlmacen_NC()
        Call CargarUltraCombo(CboAlmacen, dtValores, "cod_alm", "almacen")

    End Sub

    Private Sub CboAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles CboAlmacen.InitializeLayout
        With CboAlmacen.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("almacen").Width = 500 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "almacen") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Sub Reporte()
        If CboAlmacen.Value = "" Then
            MsgBox("Ingrese código de almacén", MsgBoxStyle.Information, msgComacsa)
            Exit Sub
        End If
        StrucForm.FxRxProductoNC = New FrmRptNC
        StrucForm.FxRxProductoNC.MdiParent = MdiParent
        StrucForm.FxRxProductoNC.codalmacen = CboAlmacen.Value
        StrucForm.FxRxProductoNC.fechaini = dtpIni.Value
        StrucForm.FxRxProductoNC.fechafin = dtpFin.Value
        StrucForm.FxRxProductoNC.Show()
    End Sub

End Class