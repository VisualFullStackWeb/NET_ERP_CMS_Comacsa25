Imports SIP_Entidad
Imports SIP_Negocio
Public Class frmReclamoEjecutivo

    Private Sub frmReclamoEjecutivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each itemTab As Infragistics.Win.UltraWinTabControl.UltraTab In tabTipoReclamo.Tabs
            If itemTab.Key = "TT01" Or itemTab.Key = "TT02" Or itemTab.Key = "TT09" Or itemTab.Key = "TT03" Then
                itemTab.Visible = True
            Else
                itemTab.Visible = False
            End If
        Next




    End Sub

    Public Overrides Sub CargarDatos(ByVal pReclamo As SIP_Entidad.ETReclamo)
        MyBase.CargarDatos(pReclamo)



    End Sub

End Class
