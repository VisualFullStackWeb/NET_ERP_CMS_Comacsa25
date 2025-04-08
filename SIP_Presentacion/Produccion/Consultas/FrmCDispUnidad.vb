Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports SIP_Entidad
Imports SIP_Negocio
Public Class FrmCDispUnidad

#Region "Variables"

    Private AppOcupado As Infragistics.Win.Appearance
    Private AppDisponible As Infragistics.Win.Appearance
    Private Shared myTimer As New Timer()
    Private Shared exitFlag As Boolean = False
    Private LOrden As List(Of ETOrden)
    Private List As List(Of ETActivo)
    Private NumDiaxAnho As Int16 = 0
    Private NumDiaxSemana As Int16 = 0
    Private NumSemanaxAnho As Int16 = 0
    Private FecRegistro As Date = Date.Now
    Private FecCierre As Date = Date.Now
    Private FecInicio As Date = Date.Now
    Private StrOcupado As String = "OCUPADO"
    Private StrDisponible As String = "DISPONIBLE"


#End Region

#Region "Eventos"

    Sub Evento_ClickCellButton(ByVal sender As Object, ByVal e As CellEventArgs) Handles Grid1.ClickCellButton

        If Not (e.Cell.Column.Key = "DesMiercoles" OrElse _
                e.Cell.Column.Key = "DesJueves" OrElse _
                e.Cell.Column.Key = "DesViernes" OrElse _
                e.Cell.Column.Key = "DesSabado" OrElse _
                e.Cell.Column.Key = "DesDomingo" OrElse _
                e.Cell.Column.Key = "DesLunes" OrElse _
                e.Cell.Column.Key = "DesMartes") Then
            Exit Sub
        End If

        If e.Cell.Value = StrOcupado Then

            Entidad.Orden = New ETOrden
            Entidad.Activo = New ETActivo
            Negocio.Orden = New NGOrden

            Entidad.Orden.Tipo = 6

            Select Case e.Cell.Column.Key
                Case "DesMiercoles"
                    Entidad.Orden.Fecha = sender.ActiveRow.Cells("dtMiercoles").Value
                Case "DesJueves"
                    Entidad.Orden.Fecha = sender.ActiveRow.Cells("dtJueves").Value
                Case "DesViernes"
                    Entidad.Orden.Fecha = sender.ActiveRow.Cells("dtViernes").Value
                Case "DesSabado"
                    Entidad.Orden.Fecha = sender.ActiveRow.Cells("dtSabado").Value
                Case "DesDomingo"
                    Entidad.Orden.Fecha = sender.ActiveRow.Cells("dtDomingo").Value
                Case "DesLunes"
                    Entidad.Orden.Fecha = sender.ActiveRow.Cells("dtLunes").Value
                Case "DesMartes"
                    Entidad.Orden.Fecha = sender.ActiveRow.Cells("dtMartes").Value
            End Select

            Entidad.Activo.Turno = sender.ActiveRow.Cells("Turno").Value
            Entidad.Activo.Placa = sender.ActiveRow.Cells("Placa").Value

            'LOrden = New List(Of ETOrden)
            'LOrden = Negocio.Orden.ConsultarOrdenxFecha(Entidad.Orden, Entidad.Activo)

            Drop1.DataSource = LOrden

            Drop1.Visible = True

            Temporizador()

        Else

            Drop1.Visible = False

        End If

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Grid1.KeyDown, Drop1.KeyDown
        Try
            With sender
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(AboveCell, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Down
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(BelowCell, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Right
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(NextCellByTab, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Left
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(PrevCellByTab, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Return
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(BelowCell, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                End Select
            End With
        Catch
            Exit Sub
        End Try
    End Sub

    Sub Evento_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        List = Nothing
    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        dt1.Value = Now

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Drop1.InitializeLayout

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "DesJueves" Or uColumn.Key = "DesMiercoles" _
                        Or uColumn.Key = "Descripcion" Or uColumn.Key = "DesViernes" _
                        Or uColumn.Key = "DesSabado" Or uColumn.Key = "DesDomingo" Or uColumn.Key = "DesTurno" _
                        Or uColumn.Key = "DesLunes" Or uColumn.Key = "DesMartes") Then
                    uColumn.Hidden = True
                End If
            Next
        End If
        If sender Is Drop1 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "NroDocumento" Or uColumn.Key = "CodProducto" _
                        Or uColumn.Key = "Descripcion") Then
                    uColumn.Hidden = True
                End If
            Next
        End If
    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) Handles Grid1.InitializeRow
        With e.Row
            If .Cells("Turno").Value = 1 Then
                .Cells("DesTurno").Value = "Primero"
            ElseIf .Cells("Turno").Value = 2 Then
                .Cells("DesTurno").Value = "Segundo"
            ElseIf .Cells("Turno").Value = 3 Then
                .Cells("DesTurno").Value = "Tercero"
            Else
                .Cells("DesTurno").Value = "Cuarto"
            End If

            AppOcupado = New Infragistics.Win.Appearance
            AppDisponible = New Infragistics.Win.Appearance

            AppOcupado.BackColor = Color.LightCoral
            AppOcupado.ForeColor = Color.White
            AppOcupado.FontData.Bold = DefaultableBoolean.True

            AppDisponible.BackColor = Color.SkyBlue
            AppDisponible.ForeColor = Color.White
            AppDisponible.FontData.Bold = DefaultableBoolean.True

            If .Cells("Miercoles").Value = True Then
                .Cells("DesMiercoles").Value = StrOcupado
                .Cells("DesMiercoles").Style = UltraWinGrid.ColumnStyle.Button
                .Cells("DesMiercoles").Appearance = AppOcupado
            Else
                .Cells("DesMiercoles").Value = StrDisponible
                .Cells("DesMiercoles").Appearance = AppDisponible
            End If

            If .Cells("Jueves").Value = True Then
                .Cells("DesJueves").Value = StrOcupado
                .Cells("DesJueves").Style = UltraWinGrid.ColumnStyle.Button
                .Cells("DesJueves").Appearance = AppOcupado
            Else
                .Cells("DesJueves").Value = StrDisponible
                .Cells("DesJueves").Appearance = AppDisponible
            End If

            If .Cells("Viernes").Value = True Then
                .Cells("DesViernes").Value = StrOcupado
                .Cells("DesViernes").Style = UltraWinGrid.ColumnStyle.Button
                .Cells("DesViernes").Appearance = AppOcupado
            Else
                .Cells("DesViernes").Value = StrDisponible
                .Cells("DesViernes").Appearance = AppDisponible
            End If

            If .Cells("Sabado").Value = True Then
                .Cells("DesSabado").Value = StrOcupado
                .Cells("DesSabado").Style = UltraWinGrid.ColumnStyle.Button
                .Cells("DesSabado").Appearance = AppOcupado
            Else
                .Cells("DesSabado").Value = StrDisponible
                .Cells("DesSabado").Appearance = AppDisponible
            End If

            If .Cells("Domingo").Value = True Then
                .Cells("DesDomingo").Value = StrOcupado
                .Cells("DesDomingo").Style = UltraWinGrid.ColumnStyle.Button
                .Cells("DesDomingo").Appearance = AppOcupado
            Else
                .Cells("DesDomingo").Value = StrDisponible
                .Cells("DesDomingo").Appearance = AppDisponible
            End If

            If .Cells("Lunes").Value = True Then
                .Cells("DesLunes").Value = StrOcupado
                .Cells("DesLunes").Style = UltraWinGrid.ColumnStyle.Button
                .Cells("DesLunes").Appearance = AppOcupado
            Else
                .Cells("DesLunes").Value = StrDisponible
                .Cells("DesLunes").Appearance = AppDisponible
            End If

            If .Cells("Martes").Value = True Then
                .Cells("DesMartes").Value = StrOcupado
                .Cells("DesMartes").Style = UltraWinGrid.ColumnStyle.Button
                .Cells("DesMartes").Appearance = AppOcupado
            Else
                .Cells("DesMartes").Value = StrDisponible
                .Cells("DesMartes").Appearance = AppDisponible
            End If

        End With
    End Sub

    Sub Evento_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dt1.ValueChanged, _
                                                                              dt2.ValueChanged, _
                                                                              dt3.ValueChanged
        If sender Is dt1 Then

            If dt1.Value = Nothing Then
                Exit Sub
            End If

            FecRegistro = dt1.Value
            NumDiaxSemana = DatePart(DateInterval.Weekday, FecRegistro)
            NumSemanaxAnho = DatePart(DateInterval.WeekOfYear, FecRegistro)
            NumDiaxAnho = DatePart(DateInterval.DayOfYear, FecRegistro)

            If NumDiaxSemana = 1 OrElse NumDiaxSemana = 2 OrElse NumDiaxSemana = 3 Then
                NumSemanaxAnho -= 1
                FecInicio = DateAdd(DateInterval.Day, -(3 + NumDiaxSemana), FecRegistro)
                FecCierre = DateAdd(DateInterval.Day, 3 - NumDiaxSemana, FecRegistro)
            Else
                FecInicio = DateAdd(DateInterval.Day, 4 - NumDiaxSemana, FecRegistro)
                FecCierre = DateAdd(DateInterval.Day, 10 - NumDiaxSemana, FecRegistro)
            End If

            dt2.Value = FecInicio
            dt3.Value = FecCierre
            Txt1.Value = NumSemanaxAnho

        Else
            If sender Is dt2 Then
                dt2.Value = FecInicio
            Else
                dt3.Value = FecCierre
            End If
        End If

    End Sub



#End Region

#Region "Metodos Locales"

    Sub TimerEventProcessor(ByVal myObject As Object, _
                                          ByVal myEventArgs As EventArgs)
        myTimer.Stop()
        Drop1.Visible = False
        exitFlag = True

    End Sub

    Sub Temporizador()

        myTimer.Stop()
        AddHandler myTimer.Tick, AddressOf TimerEventProcessor
        myTimer.Interval = 5000
        myTimer.Start()
        While exitFlag = False
            Application.DoEvents()
        End While

    End Sub

#End Region

#Region "Metodos Publicos"

    Public Sub Procesar()

        Negocio.Activo = New NGActivo
        Entidad.Activo = New ETActivo

        Entidad.Activo.FechaInicio = dt2.Value
        Entidad.Activo.FechaFinal = dt3.Value

        List = New List(Of ETActivo)

        List = Negocio.Activo.CuadroDisponUnidad(Entidad.Activo)

        CargarUltraGrid(Grid1, List)

    End Sub

#End Region

End Class