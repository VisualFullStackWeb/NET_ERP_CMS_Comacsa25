Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmMListaPrecioFleteMineral
#Region "Variables"
    Private Tipo As Int16 = 0
    Private Ls_ListaPrecio As List(Of ETCanteraCosteo) = Nothing
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

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call ListarCia(Cia)
        Call Iniciar()
        dtFecha.Value = Now


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

        If Ls_ListaPrecio IsNot Nothing Then Ls_ListaPrecio = Nothing

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                               Handles Grid2.InitializeLayout, Grid3.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
            If Not (uColumn.Key = "Precio" Or uColumn.Key = "Fecha" Or _
                    uColumn.Key = "Moneda" Or uColumn.Key = "ID" Or _
                    uColumn.Key = "Mineral" Or uColumn.Key = "Cantera" Or _
                    uColumn.Key = "Importe" Or uColumn.Key = "CodigoMineral") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

        Return
    End Sub

    Sub DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid2.DoubleClickRow, Grid3.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If e.Row.IsFilterRow Then Return
        'If sender.name = "Grid3" Then Return
        Call Consultar_ListaPrecio(e.Row)

        Tipo = Operacion.Retorno

    End Sub

    Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt2.KeyDown, _
                                                                                                    Txt4.KeyDown, _
                                                                                                    Txt6.KeyDown
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If (e.KeyCode) = 8 Or (e.KeyCode) = 46 Then
            If sender Is Txt2 Then
                Txt3.Clear()
                Txt2.Clear()
                Txt6.EndUpdate()
                Txt2.EndUpdate()
            End If

            If sender Is Txt4 Then
                Txt5.Clear()
                Txt4.Clear()
                Txt4.EndUpdate()

            End If

            Call Iniciar_DetalleListaPrecio()

        End If

    End Sub


#End Region

#Region "Funciones Locales"

    Sub Limpiar()
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Txt3.Value = String.Empty
        Txt4.Value = String.Empty
        Txt5.Value = String.Empty
        Txt6.Value = 0
        Cbo2.Value = ""
        Call Iniciar_DetalleListaPrecio()
        Ep1.Clear()
        Ep2.Clear()
    End Sub

    Sub Controles(ByVal xBol As Boolean)
        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        Txt2.ReadOnly = xBol
        Txt3.ReadOnly = xBol
        Txt4.ReadOnly = xBol
        Txt5.ReadOnly = xBol
        Txt6.ReadOnly = xBol
        Cbo2.ReadOnly = xBol
        dtFecha.ReadOnly = xBol
    End Sub

    Sub Iniciar()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Opcion = 4
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraListaPrecioFletexMineral(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_ListaPrecio = New List(Of ETCanteraCosteo)
        Ls_ListaPrecio = Entidad.MyLista.Ls_CanteraCosteo

        CargarUltraGridxBinding(Grid2, Source1, Ls_ListaPrecio)

    End Sub

    Sub Iniciar_DetalleListaPrecio()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .CodigoCantera = Txt2.Value
            .Opcion = 2
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraListaPrecioFletexMineral(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_ListaPrecio = New List(Of ETCanteraCosteo)
        Ls_ListaPrecio = Entidad.MyLista.Ls_CanteraCosteo

        CargarUltraGrid(Grid3, Ls_ListaPrecio)

    End Sub

    Sub Consultar_ListaPrecio(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        dtFecha.Value = Now
        Txt1.Clear()


        Txt1.Value = uRow.Cells("ID").Value
        Txt2.Value = uRow.Cells("CodigoCantera").Value
        Txt3.Value = uRow.Cells("Cantera").Value
        Txt4.Value = uRow.Cells("CodigoMineral").Value
        Txt5.Value = uRow.Cells("Mineral").Value
        Txt6.Value = uRow.Cells("Importe").Value
        Cbo2.Value = uRow.Cells("Moneda").Value
        dtFecha.Value = uRow.Cells("Fecha").Value
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Call Iniciar_DetalleListaPrecio()
    End Sub

    Function Verificar_Datos() As Boolean

        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt3.Value) Then
            Ep1.SetError(Txt3, "Ingrese una Cantera")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt5.Value) Then
            Ep1.SetError(Txt5, "Ingrese un Mineral")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo2.Value) Then
            Ep1.SetError(Cbo2, "Seleccione una moneda")
            lResult = Boolean.FalseString
        End If

        If Txt6.Value <= 0 Then
            Ep1.SetError(Txt6, "El precio debe ser mayor a 0")
            lResult = Boolean.FalseString
        End If

        Return lResult

    End Function


#End Region

#Region "Funciones Globales"

    Public Sub Actualizar()

        If String.IsNullOrEmpty(Txt3.Value) Then Return
        If String.IsNullOrEmpty(Txt5.Value) Then Return

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar_DetalleListaPrecio()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Tab1.Tabs("T01").Selected = True
    End Sub

    Public Sub Buscar()

        If Tipo = 0 Then
            Return
        End If

        xFormulario = "Lista_Precio_FletexMineral"

        If String.IsNullOrEmpty(Txt3.Value) Then

            Dim Cantera As New FrmListarCantera
            Cantera.FECHA = dtFecha.Value
            Cantera.ShowDialog()
            Txt2.Text = Trim(Cantera.CODIGO & "")
            Txt3.Text = Trim(Cantera.CANTERA & "")
            Cantera = Nothing
        ElseIf String.IsNullOrEmpty(Txt5.Value) Then

            Dim Minerales As New FrmListarProductos
            Minerales.COD_CANTERA = Txt2.Text.Trim
            Minerales.ShowDialog()
            Txt4.Text = Trim(Minerales.CODIGO & "")
            Txt5.Text = Trim(Minerales.DESCRIPCION & "")
            xFormulario = String.Empty
            Minerales = Nothing

            Call Iniciar_DetalleListaPrecio()
        End If

        xFormulario = String.Empty

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
        Txt2.EndUpdate()
        Txt3.EndUpdate()
        Txt4.EndUpdate()
        Txt5.EndUpdate()
        Txt6.EndUpdate()

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto
        With Entidad.CanteraCosteo
            .Opcion = 3
            .ID = Txt1.Text
            .User = User_Sistema
            .CodCia = Companhia
            .Fecha = dtFecha.Value
        End With
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.Resultado = Negocio.CanteraCosteo.EliminarCanteraListaPrecioFletexMineral(Entidad.CanteraCosteo)
        If Entidad.Resultado.Realizo Then
            Call Limpiar()
            Call Iniciar_DetalleListaPrecio()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            Call Iniciar()
            Tab1.Tabs("T01").Selected = Boolean.TrueString
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

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto

        With Entidad.CanteraCosteo
            .Opcion = 1
            .ID = Txt1.Text
            .CodigoMineral = Txt4.Value
            .Mineral = Txt5.Value
            .CodigoCantera = Txt2.Value
            .Cantera = Txt3.Value
            .Importe = Txt6.Value
            .Moneda = Cbo2.Value
            .User = User_Sistema
            .CodCia = Companhia
            .Fecha = dtFecha.Value
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCanteraListaPrecioFletexMineral(Entidad.CanteraCosteo)
        If Entidad.Resultado.Realizo Then
            Call Limpiar()
            Call Iniciar()
            Tab1.Tabs("T01").Selected = Boolean.TrueString
            Tipo = Operacion.Retorno
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Public Sub Modificar()

        If Not VerificarControl(1, Txt1) Then
            MessageBox.Show("No existe registro para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Tipo = Operacion.Modificar

        Call Controles(Boolean.FalseString)

    End Sub

    Public Sub Nuevo()
        Tipo = Operacion.Nuevo
        Call Limpiar()
        Call Controles(Boolean.FalseString)
        Tab1.Tabs("T02").Selected = Boolean.TrueString
    End Sub

#End Region


End Class