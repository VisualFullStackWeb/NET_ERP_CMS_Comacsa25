Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmListarPlanilla
    '   *****   VARIABLES   *****
    Public CODIGO As String
    Public EMPLEADO As String

#Region "Load"
    Private Sub FrmListarPlanilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarPersonal()
    End Sub
#End Region                'Load

#Region "Funciones Locales"

#Region "Listar Personal"
    Private Sub ListarPersonal()
        With Entidad.Usuario
            .Cod_Cia = Companhia
        End With
        dgvPlanilla.DataSource = Negocio.Usuario.ListarUsers(Entidad.Usuario, "PLA")
    End Sub
#End Region

#End Region   'Funciones Locales

#Region "Evento Controles"

#Region "dgvPlanilla - DoubleClickRow"
    Private Sub dgvPlanilla_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvPlanilla.DoubleClickRow
        CODIGO = e.Row.Cells("Codigo").Value
        EMPLEADO = e.Row.Cells("Empleado").Value
        Me.Close()
    End Sub
#End Region

#End Region    'Evento Controles

End Class