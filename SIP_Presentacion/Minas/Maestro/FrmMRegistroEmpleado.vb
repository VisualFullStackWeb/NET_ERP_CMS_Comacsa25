Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmMRegistroEmpleado

#Region "Variables"
    Private Tipo As Int16 = 0
    Private Ls_CanteraCosteo As List(Of ETCanteraCosteo) = Nothing
    Private Ls_CanteraPje As List(Of ETCanteraCosteo) = Nothing
    Public Ls_Permisos As New List(Of Integer)
#End Region

#Region "Funciones Locales"

    Sub Limpiar()
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Txt3.Value = String.Empty
        Txt4.Value = String.Empty
        Txt5.Value = String.Empty
        Txt8.Value = 1
        Txt9.Value = String.Empty
        Txt6.Value = String.Empty
        Txt7.Value = String.Empty
        Txt10.Value = 0
        Call Iniciar_DetalleCanteraEmpleado()
        Cbo1.Value = ""
        dtFecha.Value = Now
        dtInicio.Value = dtFecha.Value
        dtFin.Value = dtFecha.Value

        Ep1.Clear()
        Ep2.Clear()
    End Sub

    Sub Controles(ByVal xBol As Boolean)

        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        Txt2.ReadOnly = xBol
        Txt4.ReadOnly = xBol
        Txt8.ReadOnly = True
        Txt9.ReadOnly = xBol
        Cbo1.ReadOnly = xBol

        dtFecha.ReadOnly = xBol
        dtInicio.ReadOnly = xBol
        dtFin.ReadOnly = xBol

    End Sub

    Sub SubControles(ByVal xBol As Boolean)
        Txt4.ReadOnly = True
        Txt5.ReadOnly = True
        Txt6.ReadOnly = True
        Txt7.ReadOnly = True
        Txt9.ReadOnly = xBol
        Txt10.ReadOnly = xBol
    End Sub

    Sub HabilitarBotones(ByVal xBol As Boolean)
        Btn4.Enabled = True
        Btn5.Enabled = Not xBol
        Btn6.Enabled = xBol
        Btn7.Enabled = xBol
    End Sub

    Sub Iniciar()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Opcion = 2
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraViaje(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_CanteraCosteo = New List(Of ETCanteraCosteo)
        Ls_CanteraCosteo = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_CanteraCosteo)

    End Sub

    Sub Iniciar_DetalleCanteraEmpleado()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .ID = Txt1.Value
            .Opcion = 5
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraViajeDetalle(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return
        Ls_CanteraPje = Nothing
        Ls_CanteraPje = New List(Of ETCanteraCosteo)
        Ls_CanteraPje = Entidad.MyLista.Ls_CanteraCosteo
        Call CargarUltraGrid(Grid2, Ls_CanteraPje)

    End Sub

    Sub Consultar_Empleado(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        dtFecha.Value = uRow.Cells("Fecha").Value
        dtInicio.Value = uRow.Cells("FechaInicio").Value
        dtFin.Value = uRow.Cells("FechaFin").Value

        Txt1.Value = uRow.Cells("ID").Value
        Txt2.Value = uRow.Cells("CodEmpleado").Value
        Txt3.Value = uRow.Cells("Empleado").Value
        'Txt4.Value = uRow.Cells("CodigoCantera").Value
        'Txt5.Value = uRow.Cells("Cantera").Value
        Txt8.Value = uRow.Cells("NroDias").Value
        'Txt9.Value = uRow.Cells("Motivo").Value
        Cbo1.Value = uRow.Cells("CodArea").Value
        'Txt6.Value = uRow.Cells("Ubigeo").Value
        'Txt7.Value = uRow.Cells("DescripcionUbigeo").Value
        
        Call Iniciar_DetalleCanteraEmpleado()

        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Function Verificar_Datos() As Boolean

        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt3.Value) Then
            Ep1.SetError(Txt2, "Ingrese el Empleado")
            lResult = Boolean.FalseString
        End If

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto
        With Entidad.CanteraCosteo
            .Opcion = 3
            .ID = Txt1.Text.TrimEnd
            .CodEmpleado = Txt2.Value

            Dim xFechaInicio As Date
            xFechaInicio = dtInicio.Value
            .FechaInicio = (xFechaInicio.ToString("dd/MM/yyyy") & " 12:00:00 am").Trim

            Dim xFechaFin As Date
            xFechaFin = dtFin.Value
            .FechaFin = (xFechaFin.ToString("dd/MM/yyyy") & " 11:59:59 pm").Trim

        End With
        If Negocio.CanteraCosteo.ValidarCanteraViaje(Entidad.CanteraCosteo) = False Then
            Ep1.SetError(Txt3, "El empleado ya tiene un registro en ese rango de fechas")
            lResult = Boolean.FalseString
        End If

        If Grid2.Rows.Count <= 0 Then
            Ep1.SetError(Txt4, "No ha ingresado ninguna cantera")
            lResult = Boolean.FalseString
        End If

        Dim suma As Double = 0

        For Each xRow As ETCanteraCosteo In Ls_CanteraPje
            suma = suma + Val(xRow.Porcentaje)
        Next

        If suma <> 100 Then
            Ep1.SetError(Txt4, "Debe distribuir en un 100% al Personal en la Canteras")
            lResult = Boolean.FalseString
        End If
        Return lResult

    End Function

#End Region

#Region "Funciones Globales"

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Tab1.Tabs("T01").Selected = True
    End Sub

    Public Sub Buscar()

        If Tipo = 0 Then
            Return
        End If

        If String.IsNullOrEmpty(Txt3.Value) Then
            Dim Empleado As New FrmListarPlanilla
            Empleado.ShowDialog()

            Txt2.Text = Trim(Empleado.CODIGO & "")
            Txt3.Text = Trim(Empleado.EMPLEADO & "")
            Empleado = Nothing
        Else
            If Btn5.Enabled = False Then Exit Sub

            Dim Cantera As New FrmListarCantera
            gEmpleo = "023"
            Cantera.ShowDialog()

            Txt4.Text = Trim(Cantera.CODIGO & "")
            Txt5.Text = Trim(Cantera.CANTERA & "")
            Txt6.Value = Trim(Cantera.CODIGOUBIGEO & "")
            Txt7.Value = Trim(Cantera.UBIGEO & "")

            Cantera = Nothing
        End If

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
            .Opcion = 4
            .ID = Txt1.Text
            .FechaInicio = dtInicio.Value
            .FechaFin = dtFin.Value
            .User = User_Sistema
            .CodCia = Companhia
        End With
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.Resultado = Negocio.CanteraCosteo.EliminarCanteraViaje(Entidad.CanteraCosteo, Nothing)
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
        Txt6.EndUpdate()
        Txt7.EndUpdate()
        Txt8.EndUpdate()
        Txt9.EndUpdate()
   

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto

        With Entidad.CanteraCosteo
            .Opcion = 1
            .ID = Txt1.Text
            .CodEmpleado = Txt2.Value
            .Empleado = Txt2.Value
            .CodArea = Cbo1.Value
            Dim xFechaInicio As Date
            xFechaInicio = dtInicio.Value
            .FechaInicio = (xFechaInicio.ToString("dd/MM/yyyy") & " 12:00:00 am").Trim

            Dim xFechaFin As Date
            xFechaFin = dtFin.Value
            .FechaFin = (xFechaFin.ToString("dd/MM/yyyy") & " 11:59:59 pm").Trim

            .NroDias = Txt8.Value
            .User = User_Sistema
            .Ubigeo = Txt6.Value
        End With


        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCanteraViaje(Entidad.CanteraCosteo, Ls_CanteraPje)

        If Entidad.Resultado.Realizo Then
            Call Iniciar()
            Call Limpiar()
            Tab1.Tabs("T01").Selected = True
            Tipo = Operacion.Retorno
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Modificar()

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Not VerificarControl(1, Txt1) Then
            MessageBox.Show("No existe registro para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Tipo = Operacion.Modificar

        Call Controles(Boolean.FalseString)
        Call HabilitarBotones(True)
    End Sub

    Public Sub Nuevo()

        Tipo = Operacion.Nuevo
        Call Limpiar()
        Call Controles(Boolean.FalseString)
        Call HabilitarBotones(True)
        Call SubControles(Boolean.TrueString)
        Ls_CanteraPje = Nothing
        Ls_CanteraPje = New List(Of ETCanteraCosteo)
        Call CargarUltraGrid(Grid2, Ls_CanteraPje)
        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

#End Region

#Region "Eventos"

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

    Sub Evento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia)
        Call ListarAreaUsuario(Cbo1, "")
        Cbo1.Value = 28
        dtFecha.Value = Now
        dtInicio.Value = dtFecha.Value
        dtFin.Value = dtFecha.Value

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

        If Ls_CanteraCosteo IsNot Nothing Then Ls_CanteraCosteo = Nothing

    End Sub

    Sub DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If e.Row.IsFilterRow Then Return

        Call Consultar_Empleado(e.Row)


    End Sub

    Private Sub Grilla_Detalle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid2.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If


        If Grid2.Rows.Count <= 0 Then Return
        If Grid2.ActiveRow Is Nothing Then Return

        Txt4.Text = Grid2.ActiveRow.Cells("CodigoCantera").Value.ToString.TrimEnd
        Txt5.Text = Grid2.ActiveRow.Cells("Cantera").Value.ToString.TrimEnd
        Txt6.Text = Grid2.ActiveRow.Cells("Ubigeo").Value.ToString.TrimEnd
        Txt7.Text = Grid2.ActiveRow.Cells("DescripcionUbigeo").Value.ToString.TrimEnd
        Txt9.Text = Grid2.ActiveRow.Cells("Motivo").Value.ToString.TrimEnd
        Txt10.Value = Grid2.ActiveRow.Cells("Porcentaje").Value

    End Sub


    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout, Grid2.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Fecha" Or uColumn.Key = "ID" Or _
                        uColumn.Key = "CodEmpleado" Or uColumn.Key = "Empleado") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "CodigoCantera" Or uColumn.Key = "Cantera" Or _
                        uColumn.Key = "Motivo" Or uColumn.Key = "Porcentaje" ) Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If


    End Sub

    Sub ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFin.ValueChanged, dtInicio.ValueChanged
        Txt8.Value = DateDiff(DateInterval.Day, dtInicio.Value, dtFin.Value) + 1
        'If DateValue(dtFin.Value) = DateValue(dtInicio.Value) Then
        '    If Month(dtFin.Value) = Month(dtInicio.Value) Then
        '        If Year(dtFin.Value) = Year(dtInicio.Value) Then
        '            Txt8.Value = DateDiff(DateInterval.Day, dtInicio.Value, dtFin.Value) + 1
        '            Return
        '        End If
        '    End If
        'Else

        'End If
    End Sub

#End Region

    Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt2.KeyDown, _
                                                                                                        Txt4.KeyDown


        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Tipo = 0 Then
            Return
        End If

        If (e.KeyCode) = 8 Or (e.KeyCode) = 46 Then

            If sender Is Txt2 Then
                Txt3.Clear()
            End If

            If sender Is Txt4 Then
                Txt5.Clear()
                Txt6.Clear()
                Txt7.Clear()
            End If

        End If


    End Sub

    Private Sub Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        If sender Is Btn4 Then
            Call SubControles(False)
            Call HabilitarBotones(False)
            Txt4.Clear()
            Txt5.Clear()
            Txt6.Clear()
            Txt7.Clear()
            Txt9.Clear()
            Txt10.Value = 0
            Txt4.Focus()
        End If
    End Sub
    Private Function ValidarDetalle() As Boolean
        Dim lResult As Boolean = True
        If String.IsNullOrEmpty(Txt4.Text.TrimEnd) Then
            Ep1.SetError(Txt4, "Seleccione Cantera")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt9.Text.TrimEnd) Then
            Ep1.SetError(Txt9, "Ingrese el Motivo")
            lResult = Boolean.FalseString
        End If

        If Val(Txt10.Value) <= 0 Or Val(Txt10.Value) > 100 Then
            Ep1.SetError(Txt10, "El Porcentaje debe estar entre 0% y 100%")
            lResult = Boolean.FalseString
        End If

        Dim suma As Double = 0
        Dim Existe As Boolean = False

        For Each xRow As ETCanteraCosteo In Ls_CanteraPje
            suma = suma + Val(xRow.Porcentaje)
            If Txt4.Text.TrimEnd = xRow.CodigoCantera.TrimEnd Then
                Existe = True
            End If
        Next

        suma = suma + Val(Txt10.Value)
        If Existe = True Then
            Ep1.SetError(Txt4, "La Cantera ya fue ingresada")
            lResult = Boolean.FalseString
        End If

        If Val(suma) > 100 Then
            Ep1.SetError(Txt10, "Excedió el 100%")
            lResult = Boolean.FalseString
        End If
        Return lResult
    End Function
    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click

        If ValidarDetalle() = False Then
            Exit Sub
        End If

        Entidad.CanteraCosteo = New ETCanteraCosteo
        With Entidad.CanteraCosteo
            .CodigoCantera = Txt4.Text.TrimEnd
            .Cantera = Txt5.Text.TrimEnd
            .Ubigeo = Txt6.Text.TrimEnd
            .DescripcionUbigeo = Txt7.Text.TrimEnd
            .Motivo = Txt9.Text.TrimEnd
            .Porcentaje = Txt10.Value
            .User = User_Sistema
            .Opcion = 1
        End With
        Ls_CanteraPje.Add(Entidad.CanteraCosteo)
        Call CargarUltraGrid(Grid2, Ls_CanteraPje)
        Call LimpiarDetalle()
        Call HabilitarBotones(True)
    End Sub

    Private Sub LimpiarDetalle()
        Txt4.Value = String.Empty
        Txt5.Value = String.Empty
        Txt9.Value = String.Empty
        Txt6.Value = String.Empty
        Txt7.Value = String.Empty
        Txt10.Value = 0
    End Sub
    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        Dim i As Integer = 0
        While i < Ls_CanteraPje.Count
            If Txt4.Text.TrimEnd = Ls_CanteraPje(i).CodigoCantera.TrimEnd Then
                Ls_CanteraPje.RemoveAt(i)
            Else
                i = i + 1
            End If
        End While

        Call CargarUltraGrid(Grid2, Ls_CanteraPje)

    End Sub


End Class