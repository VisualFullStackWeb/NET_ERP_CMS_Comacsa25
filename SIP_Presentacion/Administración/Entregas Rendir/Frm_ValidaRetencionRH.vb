Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class Frm_ValidaRetencionRH
    Public numsolicitud As String
    Public estado As String
    Private Sub Frm_ValidaRetencionRH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If estado = "6" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
        CargarDatos()
    End Sub
    Public Sub CargarDatos()
        Try
            Dim objNegocio As NGContratista = Nothing
            Dim objEntidad As ETContratista = Nothing
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad.NumSolicitud = numsolicitud
            Dim dtRetencion As New DataTable
            dtRetencion = objNegocio.ListarRetencionSolicitud(objEntidad)
            If dtRetencion.Rows.Count = 0 Then
                Exit Sub
            End If
            Call CargarUltraGridxBinding(gridRetencion, Source1, dtRetencion)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            gridRetencion.PerformAction(EnterEditMode)
            Dim id As Int32 = 0
            Dim validacion As Int32 = 0
            Dim monto As Double = 0
            For i As Int32 = 0 To gridRetencion.Rows.Count - 1
                id = gridRetencion.Rows(i).Cells("ID").Value
                validacion = IIf(gridRetencion.Rows(i).Cells("FLAG").Value = True, 1, 0)
                monto = gridRetencion.Rows(i).Cells("MONTO").Value
                Dim objNegocio As NGContratista = Nothing
                Dim objEntidad As ETContratista = Nothing
                objNegocio = New NGContratista
                objEntidad = New ETContratista
                objEntidad.ID = id
                objEntidad._flgtrans = validacion
                objEntidad.montoTotal = monto
                objEntidad.Usuario = User_Sistema
                Dim dtRetencion As New DataTable
                dtRetencion = objNegocio.ValidarRetencionSolicitud(objEntidad)
            Next
            MsgBox("Validado Correctamente", MsgBoxStyle.Information, msgComacsa)
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class