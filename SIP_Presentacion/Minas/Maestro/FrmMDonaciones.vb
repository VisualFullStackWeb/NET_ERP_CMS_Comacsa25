Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmMDonaciones

#Region "Variables"
    Private Tipo As Int16 = 0
    Private Ls_Donaciones As List(Of ETCanteraCosteo) = Nothing
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

        If Ls_Donaciones IsNot Nothing Then Ls_Donaciones = Nothing

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout, Grid2.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "ID" Or uColumn.Key = "Glosa" Or _
                        uColumn.Key = "Ano" Or uColumn.Key = "Cantera" Or _
                        uColumn.Key = "MesName" Or uColumn.Key = "CodigoCantera") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Moneda" Or uColumn.Key = "Importe" Or _
                        uColumn.Key = "ID" Or uColumn.Key = "Glosa" Or _
                        uColumn.Key = "Cantidad") Then
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

        'If sender IsNot Grid1 Then Return

        If e.Row.IsFilterRow Then Return

        Call Consultar_Donaciones(e.Row)

    End Sub

    Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt2.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If (e.KeyCode) = 8 Or (e.KeyCode) = 46 Then
            If sender Is Txt2 Then
                Txt3.Clear()
            End If
        End If
    End Sub

    Private Sub Cbo1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo1.ValueChanged
        If String.IsNullOrEmpty(Cbo1.Value) Then
            Call LlenarMeses(Cbo3, Date.Now.Year, Date.Now.Month)
        Else
            Call LlenarMeses(Cbo3, Cbo1.Value, Date.Now.Month)
        End If

        Call Iniciar_DetalleDonaciones()
    End Sub

#End Region

#Region "Funciones Locales"

    Sub Limpiar()
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Txt3.Value = String.Empty
        Txt4.Value = 0
        Txt5.Value = 0
        Txt6.Value = 0
        Txt7.Clear()
        Cbo1.Value = ""
        Cbo2.Value = ""
        Cbo3.Value = ""

        Call Iniciar_DetalleDonaciones()
        Ep1.Clear()
        Ep2.Clear()

    End Sub

    Sub Controles(ByVal xBol As Boolean)
        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        Txt2.ReadOnly = xBol
        Txt4.ReadOnly = xBol
        Txt5.ReadOnly = True
        Txt6.ReadOnly = xBol
        Txt7.ReadOnly = xBol
        Cbo1.ReadOnly = xBol
        Cbo2.ReadOnly = xBol
        Cbo3.ReadOnly = xBol
    End Sub

    Sub Iniciar()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Opcion = 2
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraDonaciones(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Donaciones = New List(Of ETCanteraCosteo)
        Ls_Donaciones = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Donaciones)

    End Sub

    Sub Iniciar_DetalleDonaciones()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        Entidad.CanteraCosteo = New ETCanteraCosteo
        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .CodigoCantera = Txt2.Value
            If String.IsNullOrEmpty(Cbo1.Value) Then
                .Ano = 0
            Else
                .Ano = Cbo1.Value
            End If
            If String.IsNullOrEmpty(Cbo3.Value) Then
                .Mes = 0
            Else
                .Mes = Cbo3.Value
            End If

            If String.IsNullOrEmpty(Cbo2.Value) Then
                .Moneda = "S/."
            Else
                .Moneda = Cbo2.Value
            End If

            .Opcion = 5
        End With

        Ls_Donaciones = New List(Of ETCanteraCosteo)
        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraDonaciones(Entidad.CanteraCosteo)

        If Entidad.MyLista.Validacion Then
            Ls_Donaciones = Entidad.MyLista.Ls_CanteraCosteo
        End If

        Entidad.CanteraCosteo.Opcion = 6
        Me.Txt5.Value = Negocio.CanteraCosteo.ConsultarCanteraDonacionesMensual(Entidad.CanteraCosteo)

        Call CargarUltraGrid(Grid2, Ls_Donaciones)

    End Sub

    Sub Consultar_Donaciones(ByVal uRow As UltraGridRow)
        Dim xAnio As Long
        Dim xMes As Short

        If uRow Is Nothing Then
            Return
        End If
     
        Txt1.Value = uRow.Cells("ID").Value
        Txt2.Value = uRow.Cells("CodigoCantera").Value
        Txt3.Value = uRow.Cells("Cantera").Value
        Txt4.Value = uRow.Cells("Importe").Value
        Txt5.Value = uRow.Cells("Importe2").Value
        Txt6.Value = uRow.Cells("Cantidad").Value
        Txt7.Value = uRow.Cells("Glosa").Value
        xAnio = uRow.Cells("Ano").Value
        xMes = uRow.Cells("Mes").Value
        Cbo2.Value = uRow.Cells("Moneda").Value

        Call LlenarAnio(Cbo1, 2010, Date.Now.Year)
        Cbo1.Value = xAnio
        Call LlenarMeses(Cbo3, Cbo1.Value, Date.Now.Month)
        Cbo3.Value = xMes

        Call Iniciar_DetalleDonaciones()

        Tab1.Tabs("T02").Selected = Boolean.TrueString
    End Sub

    Function Verificar_Datos() As Boolean

        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt3.Value) Then
            Ep1.SetError(Txt2, "Ingrese una Cantera")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt2.Value) Then
            Ep1.SetError(Txt3, "Ingrese una Cantera")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt4.Value) Then
            Ep1.SetError(Txt4, "Ingrese el Costo x Donación")
            lResult = Boolean.FalseString
        End If

        If Val(Txt4.Value) <= 0 Then
            Ep1.SetError(Txt4, "Ingrese un Costo Mayor a Cero")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt6.Value) Then
            Ep1.SetError(Txt6, "Ingrese la Cantidad")
            lResult = Boolean.FalseString
        End If

        If Val(Txt6.Value) <= 0 Then
            Ep1.SetError(Txt6, "Ingrese la Cantidad")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt7.Value) Then
            Ep1.SetError(Txt7, "Ingrese la Glosa")
            lResult = Boolean.FalseString
        End If

        'Entidad.CanteraCosteo = New ETCanteraCosteo
        'Negocio.CanteraCosteo = New NGCanteraCosteo
        'Entidad.Objecto = New ETObjecto
        'With Entidad.CanteraCosteo
        '    .ID = Txt1.Text.Trim
        '    .Opcion = 3
        '    .CodigoCantera = Txt2.Value
        '    .Ano = Cbo1.Value
        'End With
        'If Negocio.CanteraCosteo.ValidarCanteraDonaciones(Entidad.CanteraCosteo) = True Then
        '    Ep1.SetError(Txt3, "La Cantera ya tiene un registro en ese año")
        '    lResult = Boolean.FalseString
        'End If

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
        Txt6.EndUpdate()
        Txt7.EndUpdate()

        If Verificar_Datos() = False Then Return

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto

        With Entidad.CanteraCosteo
            .Opcion = 1
            .ID = Txt1.Value
            .CodigoCantera = Txt2.Value
            .Cantera = Txt3.Value
            .Importe = Txt4.Value
            .Glosa = Txt7.Text.Trim
            .Mes = Cbo3.Value
            .Cantidad = Txt6.Value
            .Ano = Cbo1.Value
            .Moneda = Cbo2.Value
            .User = User_Sistema
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCanteraDonaciones(Entidad.CanteraCosteo)

        If Entidad.Resultado.Realizo Then
            Call Iniciar()
            Call Limpiar()
            Tab1.Tabs("T01").Selected = True
            Tipo = Operacion.Retorno
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Buscar()
        gEmpleo = "023"
        gAlmacen = "28"

        If String.IsNullOrEmpty(Txt3.Text) Then
            Dim Cantera As New FrmListarCantera
            Cantera.ShowDialog()
            Txt2.Text = Trim(Cantera.CODIGO & "")
            Txt3.Text = Trim(Cantera.CANTERA & "")
            Cantera = Nothing
            Call Iniciar_DetalleDonaciones()
            Return
        End If
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
            .ID = Txt1.Value
            .User = User_Sistema
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.EliminarCanteraDonaciones(Entidad.CanteraCosteo)

        If Entidad.Resultado.Realizo Then
            Call Iniciar()
            Call Limpiar()
            Tab1.Tabs("T01").Selected = True
            Tipo = Operacion.Retorno
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region


    Private Sub Cbo3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo3.ValueChanged
        Call Iniciar_DetalleDonaciones()
    End Sub

    Private Sub Cbo2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo2.ValueChanged
        Call Iniciar_DetalleDonaciones()
    End Sub
End Class