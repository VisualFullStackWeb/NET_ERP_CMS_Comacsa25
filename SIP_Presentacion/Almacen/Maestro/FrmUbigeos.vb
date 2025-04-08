Imports SIP_Negocio
Imports SIP_Entidad
Imports Infragistics.Win.UltraWinGrid

Public Class FrmUbigeos
    Friend Neg_Ubi As New NGUbigeos
    Friend lst As New List(Of ETUbigeos)    
    Public uRow As UltraGridRow

    Private _Codigo_UbigeoField As String = String.Empty
    Public Property Codigo_Ubigeo_Sunat() As String
        Get
            Return _Codigo_UbigeoField
        End Get
        Set(ByVal value As String)
            _Codigo_UbigeoField = value
        End Set
    End Property

    
    Private Sub FrmUbigeos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        lst = Nothing      
    End Sub

    Private Sub FrmUbigeos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lst = Neg_Ubi.ListarUbigeos()
        udgUbigeo.DataSource = lst
    End Sub

    Private Sub udgUbigeo_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles udgUbigeo.DoubleClickRow
        uRow = sender.ActiveRow
        udgUbigeo.Tag = uRow.Cells(2).Value + " - " + uRow.Cells(3).Value + " - " + uRow.Cells(4).Value
        Codigo_Ubigeo_Sunat = uRow.Cells("IdUbigeoSunat").Value
        Me.DialogResult = DialogResult.OK
        Close()
    End Sub


End Class