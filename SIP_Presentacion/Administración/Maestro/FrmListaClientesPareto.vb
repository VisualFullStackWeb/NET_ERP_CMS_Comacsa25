Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmListaClientesPareto

    Private _parameter As Integer

    ' Constructor que acepta un parámetro
    Public Sub New(ByVal parameter As Integer)
        ' Llamar al constructor base
        InitializeComponent()

        ' Asignar el parámetro a una variable de clase
        _parameter = parameter

    End Sub

    Sub CargarDatos()
        Try
            Dim objNegocio As NGContratista = Nothing
            objNegocio = New NGContratista
            Dim dtCliente As New DataTable
            dtCliente = objNegocio.ListarClientesPareto(_parameter)
            Call CargarUltraGridxBinding(gridcliente, Source1, dtCliente)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmListaClientesPareto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarDatos()
    End Sub

    Private Sub gridcliente_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridcliente.DoubleClickRow
        Try
            codCliente = gridcliente.ActiveRow.Cells("COD_CLI").Value.ToString.Trim
            Cliente = gridcliente.ActiveRow.Cells("CLIENTE").Value.ToString.Trim
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridcliente_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridcliente.InitializeLayout

    End Sub
End Class