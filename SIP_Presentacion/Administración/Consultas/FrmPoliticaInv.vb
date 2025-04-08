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
Imports System.Windows.Forms.DataVisualization.Charting
Public Class FrmPoliticaInv
    Public Ls_Permisos As New List(Of Integer)
    Dim procesado As Int32
    Dim cierre As Int32 = 0
    Private Ls_RumaSuministro As List(Of ETRuma) = Nothing
    Private CodRuma As String = String.Empty
    Dim _objNegocio_ As NGProducto
    Dim _objEntidad_ As ETProducto
    Public Lista As List(Of ETRuma) = Nothing
    Private Sub FrmPoliticaInv_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargaData()
    End Sub

    Sub cargaData()
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        Dim dtData As New DataTable
        dtData = _objNegocio_.ListaConfigMes()
        gridPolitica.DataSource = dtData
    End Sub

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        Try
            If MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
            gridPolitica.PerformAction(ExitEditMode)

            Dim dtData As New DataTable
            For i As Int32 = 0 To gridPolitica.Rows.Count - 1
                _objNegocio_ = New NGProducto
                _objEntidad_ = New ETProducto
                _objEntidad_.ID = gridPolitica.Rows(i).Cells("ID").Value
                _objEntidad_.Descripcion = gridPolitica.Rows(i).Cells("DESCRIPCION").Value
                _objEntidad_.Mes = gridPolitica.Rows(i).Cells("MIN_MESES").Value
                _objEntidad_.Mes1 = gridPolitica.Rows(i).Cells("MAX_MESES").Value
                _objEntidad_.Usuario = User_Sistema
                dtData = _objNegocio_.MantConfigMes(_objEntidad_)
            Next
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridPolitica_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridPolitica.DoubleClickRow
        Try
            Dim id As Int32
            id = gridPolitica.ActiveRow.Cells("ID").Value
            Dim frm As New FrmConfigRuma
            frm.lblid.Text = id
            frm.lbldescrip.Text = gridPolitica.ActiveRow.Cells("DESCRIPCION").Value
            frm.lblmesini.Text = gridPolitica.ActiveRow.Cells("MIN_MESES").Value & "  -  "
            frm.lblmesfin.Text = gridPolitica.ActiveRow.Cells("MAX_MESES").Value & " Meses"
            frm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridPolitica_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridPolitica.InitializeLayout

    End Sub
End Class