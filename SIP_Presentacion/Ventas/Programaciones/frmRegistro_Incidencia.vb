Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Public Class frmRegistro_Incidencia
    Public fecha As Date
    Public idestado As Int32
    Public idconcepto As Int32
    Public fechaincidencia As Date
    Public horaincidencia As String
    Public observacion As String
    Private Sub frmRegistro_Incidencia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        llenarConcepto()
        llenarIncidencia()
        dtpFecha.Value = fecha
    End Sub

    Private Sub btnincidencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnincidencia.Click
        If cmbincidencia.Value = Nothing Then
            MsgBox("Seleccione una incidencia")
            Exit Sub
        End If
        fechaincidencia = dtpFecha.Value
        horaincidencia = CDate(dtphora.Value).ToString("HH:mm:ss")
        idestado = cmbincidencia.Value
        If cmbConcepto.Visible = True Then
            idconcepto = cmbConcepto.Value
        Else
            idconcepto = 0
        End If
        observacion = txtobservacion.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Sub llenarIncidencia()
        Try
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista.Fecha = dtpFecha.Value
            Dim dtConsulta As New DataTable
            dtConsulta = Negocio.NContratista.llenar_Incidencia(Entidad.Contratista)
            Call CargarUltraCombo(cmbincidencia, dtConsulta, "ID", "INCIDENCIA")
        Catch ex As Exception

        End Try
    End Sub
    Sub llenarConcepto()
        Try
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista.Fecha = dtpFecha.Value
            Dim dtConsulta As New DataTable
            dtConsulta = Negocio.NContratista.llenar_Concepto(Entidad.Contratista)
            Call CargarUltraCombo(cmbConcepto, dtConsulta, "IDCONCEPTO", "CONCEPTO")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbConcepto_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbConcepto.InitializeLayout
        With cmbConcepto.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("CONCEPTO").Width = 300 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "CONCEPTO") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub cmbincidencia_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbincidencia.InitializeLayout
        With cmbincidencia.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("INCIDENCIA").Width = 200 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "INCIDENCIA") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub cmbincidencia_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbincidencia.ValueChanged
        Try
            If cmbincidencia.Value = 2 Then
                UltraLabel4.Visible = True
                cmbConcepto.Visible = True
            Else
                UltraLabel4.Visible = False
                cmbConcepto.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class