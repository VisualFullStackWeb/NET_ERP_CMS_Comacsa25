'Imports SIP_Entidad
'Imports SIP_Negocio
'Imports System
'Imports System.Windows.Forms
'Imports Infragistics.Win
'Imports Infragistics.Win.UltraWinGrid
'Imports Infragistics.Win.UltraWinGrid.UltraGridAction
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
Public Class FrmMUbicacionEquipoCantera

#Region "Variables"

    Private Tipo As Int16 = 0
    Public Ls_Permisos As New List(Of Integer)

    Private Lst_UbicacionEquipo As New List(Of ETCanteraCosteo)

    Private Lst_CanteraEquipo As New List(Of ETCanteraCosteo)
    Private CanteraEquipo As New ETCanteraCosteo

    Dim xFecha_Inicio As Date
    Dim xFecha_Fin As Date

#End Region

#Region "Evento"

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Call AdministrarToolBar(MdiParent)
    End Sub

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                    Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Sub UbicacionEquipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia2)
        dtSalida.Value = Now
        dtIngreso.Value = Now
        Call ListarTipoActivo(Cbo1)
        Call Iniciar()
    End Sub

    Sub Evento_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                         Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Lst_UbicacionEquipo IsNot Nothing Then Lst_UbicacionEquipo = Nothing

    End Sub

    Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _
                                                                                            Txt4.KeyDown, _
                                                                                            Txt2.KeyDown
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If (e.KeyCode) = 8 Or (e.KeyCode) = 46 Then
            If sender Is Txt4 Then
                Txt5.Clear()
            ElseIf sender Is Txt2 Then
                Txt3.Clear()
            End If
        End If
    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout, Grid2.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Periodo" Or uColumn.Key = "Tipo" Or _
                        uColumn.Key = "Cod_Equipo" Or uColumn.Key = "NombreEquipo" Or _
                        uColumn.Key = "ID" Or uColumn.Key = "FechaInicio" Or _
                        uColumn.Key = "FechaFin" Or uColumn.Key = "Cantera" Or uColumn.Key = "CodigoCantera") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    If uColumn.Key = "FechaInicio" Then
                        uColumn.Header.Caption = "F. Inicio"
                        uColumn.MinWidth = 65
                    ElseIf uColumn.Key = "FechaFin" Then
                        uColumn.MinWidth = 65
                        uColumn.Header.Caption = "F. Termino"
                    End If
                    uColumn.Hidden = Boolean.FalseString
                    uColumn.CellActivation = Activation.ActivateOnly
                End If
            Next
            Return
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "FechaInicio" Or uColumn.Key = "Tipo" Or _
                        uColumn.Key = "Cod_Equipo" Or uColumn.Key = "NombreEquipo") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If

    End Sub

    Sub _DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow, _
                                                                                                                                 Grid2.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If e.Row.IsFilterRow Then Return

        Call Consultar_Cantera(e.Row)
    End Sub

    Sub ChkSalida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkSalida.CheckedChanged
        If ChkSalida.Checked = True Then
            dtSalida.Enabled = True
        Else
            dtSalida.Enabled = False
        End If
    End Sub

    Sub Combo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo1.ValueChanged
        If Cbo1.Items.Count > 0 Then
            Txt5.Clear()
            Txt4.Clear()
        End If
    End Sub

#End Region

#Region "Funciones Locales"

    Sub Limpiar()
        Txt1.Value = String.Empty
        Txt4.Value = String.Empty
        Txt5.Value = String.Empty
        Txt2.Value = String.Empty
        Txt3.Value = String.Empty
        Cbo1.Value = ""
        dtIngreso.Value = Now
        dtSalida.Value = Now
        ChkSalida.Checked = False
        Call Iniciar_DetalleCanteraEquipo()
        Ep1.Clear()
        Ep2.Clear()
    End Sub

    Sub Controles(ByVal xBol As Boolean)

        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        Cbo1.ReadOnly = xBol
        Txt4.ReadOnly = xBol
        dtIngreso.ReadOnly = xBol
        dtSalida.ReadOnly = xBol

    End Sub

    Sub Consultar_Cantera(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Txt1.Value = uRow.Cells("ID").Value
        Txt2.Value = uRow.Cells("CodigoCantera").Value
        Txt3.Value = uRow.Cells("Cantera").Value
        Cbo1.Value = uRow.Cells("NombreTipo").Value
        Txt4.Value = uRow.Cells("Cod_Equipo").Value
        Txt5.Value = uRow.Cells("NombreEquipo").Value
        dtIngreso.Value = uRow.Cells("Fechainicio").Value

        If uRow.Cells("Movimiento").Value = "S" Then
            ChkSalida.Checked = True
            dtSalida.Enabled = True
            dtSalida.Value = uRow.Cells("FechaFin").Value
        Else
            ChkSalida.Checked = False
            dtSalida.Enabled = False
            dtSalida.Value = Now
        End If

        Call Iniciar_DetalleCanteraEquipo()

        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Function Verificar_Datos() As Boolean

        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt4.Value) Then
            Ep1.SetError(Txt2, "Ingrese una Cantera")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt5.Value) Then
            Ep1.SetError(Txt4, "Ingrese un Equipo")
            lResult = Boolean.FalseString
        End If

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto

        With Entidad.CanteraCosteo
            .Opcion = 6
            .ID = Txt1.Text.Trim
            .Cod_Equipo = Txt4.Value
            xFecha_Inicio = dtIngreso.Value
            .FechaInicio = (xFecha_Inicio.ToString("dd/MM/yyyy") & " 12:00:00 am").Trim

            If ChkSalida.Checked = True Then
                xFecha_Fin = dtSalida.Value
                .FechaFin = (xFecha_Fin.ToString("dd/MM/yyyy") & " 11:59:59 pm").Trim
            Else
                xFecha_Fin = "01/01/1973"
                .FechaFin = (xFecha_Fin.ToString("dd/MM/yyyy") & " 11:59:59 pm").Trim
            End If
        End With

        If Negocio.CanteraCosteo.ValidarCanteraEquipo(Entidad.CanteraCosteo) = True Then
            Ep1.SetError(Txt4, "El Equipo ya tiene un registro en ese rango de fechas")
            lResult = Boolean.FalseString
        End If

        Return lResult

    End Function

    Sub Iniciar_DetalleCanteraEquipo()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .CodigoCantera = Txt2.Value
            .Opcion = 3
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarUbicacionEquipoCantera(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Lst_CanteraEquipo = New List(Of ETCanteraCosteo)
        Lst_CanteraEquipo = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGrid(Grid2, Lst_CanteraEquipo)

    End Sub

    Sub Iniciar()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Opcion = 5
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarUbicacionEquipoCantera(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Lst_CanteraEquipo = New List(Of ETCanteraCosteo)
        Lst_CanteraEquipo = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGridxBinding(Grid1, Source1, Lst_CanteraEquipo)

    End Sub

#End Region

#Region "Funciones Globales"
    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Tab1.Tabs("T01").Selected = True
    End Sub
    Public Sub Nuevo()

        Tipo = Operacion.Nuevo
        Call Limpiar()
        Call Controles(Boolean.FalseString)
        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Public Sub Modificar()

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Not VerificarControl(1, Txt1) Then
            MessageBox.Show("No existe Cantera para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Tipo = Operacion.Modificar

        Call Controles(Boolean.FalseString)

    End Sub

    Public Sub Cancelar()

        Tipo = Operacion.Retorno
        Call Controles(Boolean.TrueString)

    End Sub

    Public Sub Eliminar()

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Tipo = Operacion.Retorno Then
            MessageBox.Show(Mensaje.Seleccion_2, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Txt1.EndUpdate()

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto

        With Entidad.CanteraCosteo
            .Opcion = 2
            .ID = Txt1.Value
            .User = User_Sistema
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.EliminarCanteraEquipo(Entidad.CanteraCosteo)

        If Entidad.Resultado.Realizo Then
            Call Iniciar()
            Call Limpiar()
            Tab1.Tabs("T01").Selected = True
            Tipo = Operacion.Retorno
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Grabar()

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Tipo = Operacion.Retorno Then
            MessageBox.Show(Mensaje.Seleccion_2, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If Not Verificar_Datos() Then
            MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Txt1.EndUpdate()
        Txt2.EndUpdate()
        Txt3.EndUpdate()
        Txt4.EndUpdate()
        Txt5.EndUpdate()

        Entidad.CanteraCosteo = New ETCanteraCosteo

        With Entidad.CanteraCosteo
            .ID = Txt1.Value
            .CodigoCantera = Txt2.Value
            .Cantera = Txt3.Value
            .Cod_Equipo = Txt4.Value
            .NombreEquipo = Txt5.Value
            .Tipo = Cbo1.Value
            .User = User_Sistema
            .FechaInicio = dtIngreso.Value
            If ChkSalida.Checked = True Then
                .FechaFin = dtSalida.Value
                .Chk = 1
                .Movimiento = "S"
            Else
                .Chk = 0
                .Movimiento = "I"
            End If
            .Opcion = 1
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCanteraEquipo(Entidad.CanteraCosteo)

        If Entidad.Resultado.Realizo Then
            Call Limpiar()
            Tab1.Tabs("T01").Selected = True
            Tipo = Operacion.Retorno
            Call Iniciar()

        End If

        
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Sub Reporte()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application

        Try

            If Grid1.Rows.Count > 0 Then

                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\ReporteUbicacionEquipos.xls")
                File.Copy(RutaReporteERP & "ReporteUbicacionEquipos.xls", path & "\ReporteUbicacionEquipos.xls")
                m_Excel.Workbooks.Open(path & "\ReporteUbicacionEquipos.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 13
                nfilaini = 13

                With objHojaExcel
                    .Activate()
                    .Range("A2").Value = "REPORTE DE UBICACION DE MAQUINAS EN CANTERA"
                    .Range("A2").Font.Bold = True
                    Dim filaultima As Int32 = 0
                    Dim filteredRows() As UltraGridRow = Grid1.Rows.GetFilteredInNonGroupByRows()
                    'For i As Int16 = 0 To Grid1.Rows.VisibleRowCount - 1
                    For i As Int16 = 0 To filteredRows.Length - 1
                        .Range("A" & 5 + i).Value = Grid1.Rows(filteredRows(i).Index).Cells("ID")
                        .Range("B" & 5 + i).Value = Grid1.Rows(filteredRows(i).Index).Cells("Tipo")
                        .Range("C" & 5 + i).Value = Grid1.Rows(filteredRows(i).Index).Cells("Cod_Equipo")
                        .Range("D" & 5 + i).Value = Grid1.Rows(filteredRows(i).Index).Cells("NombreEquipo")
                        .Range("E" & 5 + i).Value = Grid1.Rows(filteredRows(i).Index).Cells("Periodo")
                        .Range("F" & 5 + i).Value = Grid1.Rows(filteredRows(i).Index).Cells("CodigoCantera")
                        .Range("G" & 5 + i).Value = Grid1.Rows(filteredRows(i).Index).Cells("Cantera")
                        .Range("H" & 5 + i).Value = Grid1.Rows(filteredRows(i).Index).Cells("FechaInicio")
                        .Range("I" & 5 + i).Value = Grid1.Rows(filteredRows(i).Index).Cells("FechaFin")

                        .Range(.Cells(5 + i, 1), .Cells(5 + i, 9)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                        nfila = nfila + 1
                        filaultima = 5 + i
                    Next
                    .Range(.Cells(filaultima + 1, 8), .Cells(filaultima + 1, 9)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 1, 8), .Cells(filaultima + 1, 9)).Font.Bold = True
                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Public Sub Buscar()
    

        xFormulario = "UbicacionEquipo"
        If String.IsNullOrEmpty(Txt3.Value) Then

            Dim Combustible As New FrmListarCantera
            Combustible.ShowDialog()
            Txt2.Text = Combustible.CODIGO
            Txt3.Text = Combustible.CANTERA
            Combustible = Nothing
            Call Iniciar_DetalleCanteraEquipo()
        Else

            Dim Equipo As New FrmListarActivo

            GLinea = Cbo1.Value
            Equipo.ShowDialog()
            xFormulario = ""
            GLinea = ""
            Txt4.Value = Trim(Equipo.CODIGO & "")
            If Trim(Equipo.ACTIVO & "") = "" Then
                Txt5.Value = Trim(Equipo.CODIGO & "")
            Else
                Txt5.Value = Trim(Equipo.ACTIVO & "")
            End If
            Equipo = Nothing
        End If
    End Sub

#End Region

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged

    End Sub
End Class