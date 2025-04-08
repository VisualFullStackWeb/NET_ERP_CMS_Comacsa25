Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Data.OleDb
Imports System.Text
Imports Microsoft.Office.Interop
Public Class FrmIngresoTipoProd
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Public dtdatos As New DataTable

    Private Sub FrmIngresoTipoProd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call CargarUltraGridxBinding(Me.gridproducto, Source1, dtdatos)
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            'MsgBox(cmbtipo.Value)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.CodProducto = gridproducto.ActiveRow.Cells("COD_PRODPDC").Value
            _objEntidad.ID = cmbtipo.Value
            _objEntidad.Usuario = User_Sistema
            _objEntidad.Terminal = Terminal
            If gridproducto.ActiveRow.Cells("TIPO").Value = "" Then
                _objEntidad.Accion = "I"
            Else
                _objEntidad.Accion = "U"
            End If
            Dim Datos As Int32
            Datos = _objNegocio.Costo_IngresaTipo(_objEntidad)
            If Datos = 1 Then
                gridproducto.ActiveRow.Cells("TIPO").Value = cmbtipo.Text
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class