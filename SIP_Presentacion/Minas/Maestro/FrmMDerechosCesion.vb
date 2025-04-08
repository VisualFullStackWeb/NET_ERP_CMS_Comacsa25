Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmMDerechosCesion

#Region "Variables"
    Private Tipo As Int16 = 0
    Private Ls_DerechoCesion As List(Of ETCanteraCosteo) = Nothing
    Public Ls_Permisos As New List(Of Integer)
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

        If Ls_DerechoCesion IsNot Nothing Then Ls_DerechoCesion = Nothing

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout, Grid2.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "ID" Or uColumn.Key = "FechaInicio" Or _
                        uColumn.Key = "FechaFin" Or uColumn.Key = "CodigoCantera" Or _
                        uColumn.Key = "Cantera") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "FechaFin" Or uColumn.Key = "Moneda" Or _
                        uColumn.Key = "FechaInicio" Or uColumn.Key = "CodigoCantera" Or _
                        uColumn.Key = "Cantera" Or uColumn.Key = "Importe2") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If

    End Sub

    Sub _Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia)
        Call Iniciar()
    End Sub

    Sub DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow, _
                                                                                                                                Grid2.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not ((sender Is Grid1) Or (sender Is Grid2)) Then Return
        If e.Row.IsFilterRow Then Return

        Call Consultar_DerechoCesion(e.Row)


    End Sub

    Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt2.KeyDown

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
        End If
    End Sub

#End Region

#Region "Funciones Locales"

    Sub Limpiar()
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Txt3.Value = String.Empty
        Txt4.Value = 0
        Cbo1.Value = ""
        Cbo2.Value = ""
        Dtp1.Value = Date.Today
        Dtp2.Value = Date.Today
        Call Iniciar_Detalle_DerechoCesion()
        Ep1.Clear()
        Ep2.Clear()

    End Sub

    Sub Controles(ByVal xBol As Boolean)
        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        Txt2.ReadOnly = xBol
        Txt4.ReadOnly = xBol
        Txt5.ReadOnly = True
        Cbo1.ReadOnly = xBol
        Cbo2.ReadOnly = xBol
        Dtp1.ReadOnly = xBol
        Dtp2.ReadOnly = xBol
    End Sub

    Sub Iniciar()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Opcion = 2
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraDerechoCesion(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_DerechoCesion = New List(Of ETCanteraCosteo)
        Ls_DerechoCesion = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_DerechoCesion)

    End Sub

    Sub Iniciar_Detalle_DerechoCesion()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .CodigoCantera = Txt2.Value
            .Opcion = 5
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraDerechoCesion(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_DerechoCesion = New List(Of ETCanteraCosteo)
        Ls_DerechoCesion = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGrid(Grid2, Ls_DerechoCesion)

    End Sub

    Sub Consultar_DerechoCesion(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Txt1.Value = uRow.Cells("ID").Value
        Txt2.Value = uRow.Cells("CodigoCantera").Value
        Txt3.Value = uRow.Cells("Cantera").Value
        Txt4.Value = uRow.Cells("Importe2").Value
        Txt5.Value = uRow.Cells("Importe").Value
        Dtp1.Value = uRow.Cells("FechaInicio").Value
        Dtp2.Value = uRow.Cells("FechaFin").Value
        'Cbo1.Value = uRow.Cells("Ano").Value
        Cbo2.Value = uRow.Cells("Moneda").Value
        Call Iniciar_Detalle_DerechoCesion()
        Tab1.Tabs("T02").Selected = Boolean.TrueString
    End Sub

    Function Verificar_Datos() As Boolean
        Dim FechaInicio As DateTime
        Dim FechaTemp As DateTime
        Dim FechaTermino As DateTime
        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt3.Value) Then
            Ep1.SetError(Txt2, "Ingrese una Cantera")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt2.Value) Then
            Ep1.SetError(Txt3, "Ingrese una Cantidad")
            lResult = Boolean.FalseString
        End If

        'If String.IsNullOrEmpty(Cbo1.Value) Then
        '    Ep1.SetError(Cbo1, "Seleccione un año")
        '    lResult = Boolean.FalseString
        'End If

        If CDate(Dtp1.Value) > CDate(Dtp2.Value) Then
            Ep1.SetError(Dtp1, "Fecha de Inicio es mayor a la Fecha de Termino")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo2.Value) Then
            Ep1.SetError(Cbo2, "Seleccione una moneda")
            lResult = Boolean.FalseString
        End If

        If Val(Txt4.Value) <= 0 Then
            Ep1.SetError(Txt4, "El Importe debe ser mayor a 0")
            lResult = Boolean.FalseString
        End If

        FechaTemp = CDate(Dtp1.Value)
        FechaInicio = FechaTemp.Date
        FechaTemp = CDate(Dtp2.Value)
        FechaTermino = FechaTemp.Date
        FechaTermino = DateAdd(DateInterval.Day, 1, FechaTermino)
        FechaTermino = DateAdd(DateInterval.Second, -1, FechaTermino)
        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo

        With Entidad.CanteraCosteo
            .ID = Txt1.Text.Trim
            .Opcion = 3
            .CodigoCantera = Txt2.Value
            .FechaInicio = FechaInicio
            .FechaFin = FechaTermino
        End With
        If Negocio.CanteraCosteo.ValidarCanteraDerechoCesion(Entidad.CanteraCosteo) = True Then
            Ep1.SetError(Txt3, "La Cantera ya tiene un registro en el Periodo de Fechas")
            lResult = Boolean.FalseString
        End If

        Return lResult

    End Function

#End Region

#Region "Funciones Globales"

    Public Sub Nuevo()

        Tipo = Operacion.Nuevo
        Call Limpiar()
        Call Controles(Boolean.FalseString)
        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Public Sub Modificar()

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Not VerificarControl(1, Txt2) Then
            MessageBox.Show("No existe datos para modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Tipo = Operacion.Modificar

        Call Controles(Boolean.FalseString)

    End Sub

    Public Sub Cancelar()

        Tipo = Operacion.Retorno
        Call Controles(Boolean.TrueString)

    End Sub

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Tab1.Tabs("T01").Selected = True
    End Sub

    Public Sub Grabar()
        Dim FechaTemp As DateTime
        Dim FechaInicio As Date
        Dim FechaTermino As DateTime

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Tipo = Operacion.Retorno Then
            MessageBox.Show(Mensaje.Seleccion_2, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Txt1.EndUpdate()
        Txt2.EndUpdate()
        Txt3.EndUpdate()
        Txt4.EndUpdate()
        Txt5.EndUpdate()

        If Verificar_Datos() = False Then Return

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo

        FechaTemp = CDate(Dtp1.Value)
        FechaInicio = FechaTemp.Date
        FechaTemp = CDate(Dtp2.Value)
        FechaTermino = FechaTemp.Date
        FechaTermino = DateAdd(DateInterval.Day, 1, FechaTermino)
        FechaTermino = DateAdd(DateInterval.Second, -1, FechaTermino)


        With Entidad.CanteraCosteo
            .Opcion = 1
            .ID = Txt1.Value
            .CodigoCantera = Txt2.Value
            .Cantera = Txt3.Value
            .Importe = Txt5.Value
            .Importe2 = Txt4.Value
            .FechaInicio = FechaInicio
            .FechaFin = FechaTermino
            .Moneda = Cbo2.Value
            .User = User_Sistema
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCanteraDerechoCesion(Entidad.CanteraCosteo)

        If Entidad.Resultado.Realizo Then
            Call Iniciar()
            Call Limpiar()
            Tab1.Tabs("T01").Selected = True
            Tipo = Operacion.Retorno
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Buscar()

        If Tipo = 0 Then
            Return
        End If

        gEmpleo = "023"
        gAlmacen = "28"

        If String.IsNullOrEmpty(Txt3.Text) Then
            Dim Cantera As New FrmListarCantera
            Cantera.ShowDialog()
            Txt2.Text = Trim(Cantera.CODIGO & "")
            Txt3.Text = Trim(Cantera.CANTERA & "")
            Cantera = Nothing
            Call Iniciar_Detalle_DerechoCesion()
            Return
        End If
    End Sub

    Public Sub Eliminar()
        Dim FechaTemp As DateTime
        Dim FechaInicio As Date
        Dim FechaTermino As DateTime

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Tipo = Operacion.Retorno Then
            MessageBox.Show(Mensaje.Seleccion_2, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Txt1.EndUpdate()

        FechaTemp = CDate(Dtp1.Value)
        FechaInicio = FechaTemp.Date
        FechaTemp = CDate(Dtp2.Value)
        FechaTermino = FechaTemp.Date
        FechaTermino = DateAdd(DateInterval.Day, 1, FechaTermino)
        FechaTermino = DateAdd(DateInterval.Second, -1, FechaTermino)

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto

        With Entidad.CanteraCosteo
            .Opcion = 4
            .ID = Txt1.Value
            .User = User_Sistema
            .FechaInicio = FechaInicio
            .FechaFin = FechaTermino
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.EliminarCanteraDerechoCesion(Entidad.CanteraCosteo)

        If Entidad.Resultado.Realizo Then
            Call Iniciar()
            Call Limpiar()
            Tab1.Tabs("T01").Selected = True
            Tipo = Operacion.Retorno
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

    Private Sub Txt4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt4.ValueChanged
        If IsDBNull(Me.Txt4.Value) = False Then
            Me.Txt5.Value = Val(Me.Txt4.Value) / 12
        End If

    End Sub
End Class