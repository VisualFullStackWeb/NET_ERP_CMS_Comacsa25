Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmDListarPrecioMineral
    Private Tipo As Int16 = 0
    Private Ls_ListaPrecio As List(Of ETCanteraCosteo) = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Private Sub frmDListarPrecioMineral_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmDListarPrecioMineral_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    Private Sub frmDListarPrecioMineral_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_ListaPrecio IsNot Nothing Then Ls_ListaPrecio = Nothing
    End Sub

    Private Sub frmDListarPrecioMineral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call ListarCia(Cia)
        Call Iniciar()
        Dtp1.Value = Now
    End Sub

    Public Sub Buscar()

        'If Me.Tag <> "113" Then Exit Sub

        xFormulario = "Cantera_Contratista"

        If String.IsNullOrEmpty(Txt3.Value) Then
            Dim Proveedor As New FrmProveedores
            Proveedor.ShowDialog()
            Txt2.Text = Trim(Proveedor.Codigo & "")
            Txt3.Text = Trim(Proveedor.RazonSocial & "")
            Proveedor = Nothing
        ElseIf String.IsNullOrEmpty(Txt5.Value) Then
            Dim Cantera As New FrmListarCantera
            Cantera.PROVEEDOR = Txt2.Text.Trim
            Cantera.ShowDialog()
            Txt4.Text = Trim(Cantera.CODIGO & "")
            Txt5.Text = Trim(Cantera.CANTERA & "")
            Cantera = Nothing
            xFormulario = String.Empty
        ElseIf String.IsNullOrEmpty(Txt7.Value) Then

            Dim Minerales As New FrmListarProductos
            Minerales.COD_CANTERA = Txt4.Value.Trim
            Minerales.ShowDialog()
            Txt6.Text = Trim(Minerales.CODIGO & "")
            Txt7.Text = Trim(Minerales.DESCRIPCION & "")
            xFormulario = String.Empty
            Minerales = Nothing
            xFormulario = String.Empty
        End If

    End Sub


    Private Sub Grid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        'If sender Is Grid2 Then
        For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
            If Not (uColumn.Key = "Precio" Or uColumn.Key = "Fecha" Or _
                    uColumn.Key = "Moneda" Or uColumn.Key = "ID" Or _
                    uColumn.Key = "Mineral" Or uColumn.Key = "Cantera" Or _
                    uColumn.Key = "Importe" Or uColumn.Key = "Proveedor") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
        Return
    End Sub

    Sub DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If e.Row.IsFilterRow Then Return
        'If sender.name = "Grid3" Then Return
        Call Consultar_ListaPrecio(e.Row)

        Tipo = Operacion.Retorno

    End Sub

   
#Region "Funciones Locales"

    Sub Limpiar()
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Txt3.Value = String.Empty
        Txt4.Value = String.Empty
        Txt5.Value = String.Empty
        Txt6.Value = String.Empty
        Txt7.Value = String.Empty
        Txt8.Value = 0
        Txt9.Value = 0
        Cbo2.Value = ""
        Ep1.Clear()
        Ep2.Clear()
    End Sub

    Sub Controles(ByVal xBol As Boolean)
        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        Txt2.ReadOnly = xBol
        Txt3.ReadOnly = True
        Txt4.ReadOnly = xBol
        Txt5.ReadOnly = True
        Txt6.ReadOnly = xBol
        Txt7.ReadOnly = True
        Txt8.ReadOnly = xBol
        Txt9.ReadOnly = xBol
        Cbo2.ReadOnly = xBol
        Dtp1.ReadOnly = xBol

    End Sub

    Sub Iniciar()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Opcion = 3
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraContratista_ListaPrecioMineral(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_ListaPrecio = New List(Of ETCanteraCosteo)
        Ls_ListaPrecio = Entidad.MyLista.Ls_CanteraCosteo

        CargarUltraGridxBinding(Grid1, Source1, Ls_ListaPrecio)

    End Sub


    Sub Consultar_ListaPrecio(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Txt1.Clear()


        Txt1.Value = uRow.Cells("ID").Value
        Txt2.Value = uRow.Cells("CodigoProveedor").Value
        Txt3.Value = uRow.Cells("Proveedor").Value
        Txt4.Value = uRow.Cells("CodigoCantera").Value
        Txt5.Value = uRow.Cells("Cantera").Value
        Txt6.Value = uRow.Cells("CodigoMineral").Value
        Txt7.Value = uRow.Cells("Mineral").Value
        Txt8.Value = uRow.Cells("Importe").Value
        Txt9.Value = uRow.Cells("Importe2").Value
        Cbo2.Value = uRow.Cells("Moneda").Value
        Dtp1.Value = uRow.Cells("Fecha").Value
        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Function Verificar_Datos() As Boolean

        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt3.Value) Then
            Ep1.SetError(Txt3, "Ingrese un Proveedor")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt5.Value) Then
            Ep1.SetError(Txt5, "Ingrese una Cantera")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt7.Value) Then
            Ep1.SetError(Txt7, "Ingrese una Cantera")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo2.Value) Then
            Ep1.SetError(Cbo2, "Seleccione una moneda")
            lResult = Boolean.FalseString
        End If



        If Txt8.Value <= 0 Then
            Ep1.SetError(Txt6, "El precio debe ser mayor a 0")
            lResult = Boolean.FalseString
        End If

        If Txt9.Value < 0 Then
            Ep1.SetError(Txt9, "Bonificación debe ser mayor o igual a 0")
            lResult = Boolean.FalseString
        End If


        Return lResult

    End Function


#End Region

#Region "Funciones Globales"

    Public Sub Actualizar()

        Tipo = Operacion.Retorno
        Call Controles(Boolean.TrueString)

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Tab1.Tabs("T01").Selected = True
    End Sub


    Public Sub Cancelar()
        Call Actualizar()
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
            .Opcion = 2
            .ID = Txt1.Text
            .User = User_Sistema
            .CodCia = Companhia
            .Fecha = Dtp1.Value
        End With
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.Resultado = Negocio.CanteraCosteo.EliminarCanteraContratista_ListaPrecioMineral(Entidad.CanteraCosteo)
        If Entidad.Resultado.Realizo Then
            Call Limpiar()
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
        Txt7.EndUpdate()
        Txt8.EndUpdate()
        Txt9.EndUpdate()

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto

        With Entidad.CanteraCosteo
            .Opcion = 1
            .ID = Txt1.Text
            .CodigoProveedor = Txt2.Value
            .Proveedor = Txt3.Value
            .CodigoCantera = Txt4.Value
            .Cantera = Txt5.Value
            .CodigoMineral = Txt6.Value
            .Mineral = Txt7.Value
            .Importe = Txt8.Value
            .Importe2 = Txt9.Value
            .Moneda = Cbo2.Value
            .User = User_Sistema
            .CodCia = Companhia
            .Fecha = Dtp1.Value
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCanteraContratista_ListaPrecioMineral(Entidad.CanteraCosteo)
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