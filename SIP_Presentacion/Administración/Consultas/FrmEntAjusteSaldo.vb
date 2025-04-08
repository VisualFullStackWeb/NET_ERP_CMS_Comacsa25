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

Public Class FrmEntAjusteSaldo
    Public codtrabajador As String
    Public fecha As Date

    Private Sub FrmEntAjusteSaldo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargaDatos()
    End Sub

    Sub cargaDatos()
        Try
            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing

            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            Dim dtDatos As New DataTable
            With oPrvFisE
                .cod_trabajador = codtrabajador
                .Fecha = fecha
            End With
            dtDatos = oPrvFisN.DatosAjustesEnt(oPrvFisE)

            Call CargarUltraGridxBinding(Grid1, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Dim frm As New FrmEntIngresoAjuste
        frm.dtpFecha.Value = fecha
        frm.codTrabajador = codtrabajador
        frm.ShowDialog()
        cargaDatos()
    End Sub
    Dim estadoContable As Int32 = 0
    Sub verificaestadoContable()
        Entidad.Entregas.añocontable = Convert.ToInt32(Year(Grid1.ActiveRow.Cells("FECHA").Value))
        Entidad.Entregas.mescontable = Convert.ToInt32(Month(Grid1.ActiveRow.Cells("FECHA").Value))
        Entidad.MyLista = Negocio.NEntregas.VerificaCierreContable(Entidad.Entregas)
        'lResult = New ETMyLista
        'lResult = Entidad.MyLista

        If Entidad.MyLista.Ls_Entrega.Count = 0 Then
            estadoContable = 0
        Else
            estadoContable = Entidad.MyLista.Ls_Entrega.Item(0).estadocontable
        End If
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Try
            verificaestadoContable()
            If estadoContable = 1 Then
                MsgBox("El período contable del registro que desea eliminar se encuentra cerrado", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If

            If MsgBox("Desea eliminar el registro seleccionado?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If

            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing

            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            Dim dtDatos As New DataTable
            With oPrvFisE
                .Ope = 3
                .id = Grid1.ActiveRow.Cells("ID").Value
                .cod_trabajador = codtrabajador
                .Monto = 0
                .User_Crea = User_Sistema
                .tipo_mov = ""
                .Fecha = Grid1.ActiveRow.Cells("FECHA").Value
            End With
            dtDatos = oPrvFisN.AjustesDifCambio(oPrvFisE)
            MsgBox("Registro eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
            cargaDatos()
        Catch ex As Exception

        End Try
    End Sub

End Class