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
Imports System.Data
Public Class FrmCalendario
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Public ConceptoSeleccionado As String
    Public filtroDescripcion As String = String.Empty
#End Region
    Dim obj_Proyecto As New NGProyecto
    Dim obj_EProyecto As New ETProyecto

    Dim mes As Int32 = 0
    Private Sub FrmCalendario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Year
        Maxfecha()
    End Sub
    Sub Maxfecha()
        If dtpcalendario.MaxDate.Year > txtayo.Value Then
            dtpcalendario.MinDate = "01/01/" & CStr(txtayo.Value)
            dtpcalendario.MaxDate = "31/12/" & CStr(txtayo.Value)
        Else
            dtpcalendario.MaxDate = "31/12/" & CStr(txtayo.Value)
            dtpcalendario.MinDate = "01/01/" & CStr(txtayo.Value)
        End If
        mes = dtpcalendario.SelectionRange.Start.Month
        ListaHoras(txtayo.Value, mes)
    End Sub

    Private Sub txtayo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtayo.ValueChanged
        Maxfecha()
    End Sub

    Private Sub dtpcalendario_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles dtpcalendario.DateChanged
        Try
            Dim mes_calendar As Int32 = dtpcalendario.SelectionRange.Start.Month
            If mes <> mes_calendar Then
                mes = mes_calendar
                ListaHoras(txtayo.Value, mes)
            End If
            Dim dia As Int32
            dia = dtpcalendario.SelectionRange.Start.Day
            Dim fila As Int32 = 0
            For i As Int32 = 0 To gridRevision.Rows.Count - 1
                Dim inicioDescripcion As String = String.Empty
                'inicioDescripcion = Me.gridRevision.Rows(i).Cells("NRO_DIA").Value
                If dia = Me.gridRevision.Rows(i).Cells("NRO_DIA").Value Then
                    fila = i
                    Exit For
                End If
            Next
            Me.gridRevision.ActiveRow = Me.gridRevision.Rows(fila)
            'gridRevision.PerformAction(EnterEditMode)
        Catch ex As Exception

        End Try
    End Sub
    Sub ListaHoras(ByVal ayo As Integer, ByVal mes As Integer)
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.ayo = ayo
        obj_EProyecto.mes = mes
        Dim dtDatos As New DataTable
        dtDatos = obj_Proyecto.Lista_HoraDia(obj_EProyecto)
        gridRevision.DataSource = dtDatos
    End Sub

    Private Sub gridRevision_FilterRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.FilterRowEventArgs) Handles gridRevision.FilterRow
        Dim dia As String = e.Row.Cells("DIA").Value().ToString()
        If dia = "DOM" Then
            e.Row.Appearance.ForeColor = Color.Red
        End If
    End Sub

    Private Sub gridRevision_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridRevision.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridRevision) Then Return
            With sender
                Select Case e.KeyValue
                    Case 45
                        e.Handled = True
                        Return
                    Case Keys.Up
                        .PerformAction(ExitEditMode)
                        .PerformAction(AboveCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Down
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Right
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Left
                        .PerformAction(ExitEditMode)
                        .PerformAction(PrevCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Return
                        .PerformAction(ExitEditMode)                        
                        If gridRevision.ActiveRow.Cells(gridRevision.ActiveCell.Column.Index).Column.Key = "HORAS" Then
                            .PerformAction(NextCellByTab)
                            .PerformAction(NextCellByTab)
                        End If
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select

            End With
        Catch ex As Exception
        End Try
    End Sub

    Sub Grabar()
        gridRevision.PerformAction(ExitEditMode)
        If MsgBox("Desea grabar los cambios realizados?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
        Dim hora As Double = 0
        For i As Int32 = 0 To gridRevision.Rows.Count - 1
            obj_EProyecto = New ETProyecto
            obj_EProyecto.ayo = txtayo.Value
            obj_EProyecto.mes = mes
            obj_EProyecto.Dia = gridRevision.Rows(i).Cells("NRO_DIA").Value
            obj_EProyecto.horas = gridRevision.Rows(i).Cells("HORAS").Value
            obj_EProyecto.Usuario = User_Sistema
            obj_Proyecto = New NGProyecto
            Dim dtdatos As New DataTable
            dtdatos = obj_Proyecto.Actualiza_HoraDia(obj_EProyecto)
        Next
        MsgBox("Cambios realizados correctamente", MsgBoxStyle.Information, "Sistema")
        ListaHoras(txtayo.Value, mes)
        'MsgBox(mes)
    End Sub

    Private Sub gridRevision_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridRevision.InitializeLayout

    End Sub
End Class