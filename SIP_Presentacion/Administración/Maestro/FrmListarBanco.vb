Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmListarBanco
    '   *****   VARIABLES   *****
    Public CODIGO As String
    Public DESBANCO As String

#Region "Load"
    Private Sub FrmListarBanco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarBancos()
    End Sub
#End Region                'Load

#Region "Funciones Locales"

#Region "Listar Bancos"
    Private Sub ListarBancos()
        With Entidad.Usuario
            .Cod_Cia = Companhia
        End With
        dgvBanco.DataSource = Negocio.Banco.ListarBancos(Entidad.Banco, "")


    End Sub
#End Region

#End Region   'Funciones Locales

#Region "Evento Controles"

#Region "dgvBanco - DoubleClickRow"
    Private Sub dgvBanco_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvBanco.DoubleClickRow
        CODIGO = e.Row.Cells("Codigo").Value
        DESBANCO = e.Row.Cells("Descripcion").Value
        Me.Close()
    End Sub
#End Region

#End Region    'Evento Controles

    Private Sub UltraGroupBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGroupBox1.Click

    End Sub
End Class