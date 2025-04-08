Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmMListaPrecioEquipo

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
        Cbo3.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "LPC", "", Now.ToShortDateString, Now)
        Cbo3.ValueMember = "Codigo"
        Cbo3.DisplayMember = "Descripcion"

        Cbo4.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "LTL", "", Now.ToShortDateString, Now)
        Cbo4.ValueMember = "Codigo"
        Cbo4.DisplayMember = "Descripcion"

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

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Cod_Equipo" Or uColumn.Key = "Fecha" Or _
                        uColumn.Key = "NombreEquipo" Or uColumn.Key = "ID" Or _
                        uColumn.Key = "Proveedor" Or uColumn.Key = "Cantera") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.CellActivation = Activation.ActivateOnly
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If


        If sender Is Grid3 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Cod_Equipo" Or uColumn.Key = "Hora" Or _
                        uColumn.Key = "NombreEquipo" Or uColumn.Key = "Moneda" Or _
                        uColumn.Key = "Periodo" Or uColumn.Key = "Moneda" Or _
                        uColumn.Key = "Importe" Or uColumn.Key = "Proveedor" Or _
                        uColumn.Key = "Cantera") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If


    End Sub

    Sub DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid2.DoubleClickRow, Grid3.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If e.Row.IsFilterRow Then Return
        'If sender.name = "Grid3" Then Return
        Call Consultar_ListaPrecio(e.Row)

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
                Txt7.Clear()
                Txt6.Clear()

                Txt6.EndUpdate()
                Txt2.EndUpdate()
            End If

            If sender Is Txt4 Then
                Txt5.Clear()
                Txt4.Clear()
                Call Tipo_Equipo()
                Txt7.Clear()
                Txt6.Clear()
                Txt4.EndUpdate()
                If Cbo1.Items.Count > 0 Then Cbo1.Value = ""
            End If

            If sender Is Txt6 Then
                Txt7.Clear()
                Txt6.Clear()
                Txt6.EndUpdate()
            End If
            Call Iniciar_DetalleListaPrecio()

        End If

    End Sub

    Sub Combo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo1.ValueChanged, Cbo3.ValueChanged

        If sender Is Cbo1 Then
            Txt7.Clear()
            Txt6.Clear()
            Txt6.EndUpdate()
        End If
       
        If sender Is Cbo3 Then
            If Cbo3.Value = "01" OrElse Cbo3.Value = "03" OrElse Cbo3.Value = "04" Then
                Txt9.Visible = False
                UltraLabel9.Visible = False
                Cbo4.Visible = False
            Else
                Txt9.Visible = True
                UltraLabel9.Text = Cbo3.Text & " MINIMOS(AS):"
                UltraLabel9.Visible = True
                Cbo4.Visible = True
                Txt9.Focus()
            End If
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
        Txt6.Value = String.Empty
        Txt7.Value = String.Empty
        Txt8.Value = 0
        Txt9.Value = 0

        Cbo1.Value = ""
        Cbo2.Value = ""
        Cbo3.Value = ""
        Cbo4.Value = ""
        UltraLabel9.Visible = False
        Txt9.Visible = False
        Cbo4.Visible = False
        Cbo4.Value = "03"
        Call Iniciar_DetalleListaPrecio()
        Ep1.Clear()
        Ep2.Clear()
    End Sub

    Sub Controles(ByVal xBol As Boolean)
        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        ChkProveedor.Enabled = Not xBol
        Txt2.ReadOnly = xBol
        Txt3.ReadOnly = xBol
        Txt4.ReadOnly = xBol
        Txt5.ReadOnly = xBol
        Txt6.ReadOnly = xBol
        Txt7.ReadOnly = xBol
        Txt8.ReadOnly = xBol
        Txt9.ReadOnly = xBol
        Cbo1.ReadOnly = xBol
        Cbo2.ReadOnly = xBol
        Cbo3.ReadOnly = xBol
        Cbo4.ReadOnly = True
        dtFecha.ReadOnly = xBol
    End Sub

    Sub Iniciar()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Opcion = 4
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraListaPrecio(Entidad.CanteraCosteo)

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
            .Cod_Equipo = Txt6.Value
            .Opcion = 2
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraListaPrecio(Entidad.CanteraCosteo)

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
        Txt8.Value = 0

        Txt1.Value = uRow.Cells("ID").Value
        ChkProveedor.Checked = uRow.Cells("Tercero").Value
        Txt2.Value = uRow.Cells("CodigoProveedor").Value
        Txt3.Value = uRow.Cells("Proveedor").Value
        Txt4.Value = uRow.Cells("CodigoCantera").Value
        Txt5.Value = uRow.Cells("Cantera").Value
        Txt8.Value = uRow.Cells("Importe").Value
        Txt9.Value = uRow.Cells("Hora").Value
       
        Cbo2.Value = uRow.Cells("Moneda").Value
        dtFecha.Value = uRow.Cells("Fecha").Value
        Call Tipo_Equipo()
        Cbo3.Value = uRow.Cells("Tipo").Value

        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Cbo1.Value = uRow.Cells("NombreTipo").Value

        Txt6.Value = uRow.Cells("Cod_Equipo").Value
        Txt7.Value = uRow.Cells("NombreEquipo").Value
        Call Iniciar_DetalleListaPrecio()

    End Sub

    Function Verificar_Datos() As Boolean

        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt3.Value) And ChkProveedor.Checked = True Then
            Ep1.SetError(Txt1, "Ingrese un Proveedor")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt5.Value) Then
            Ep1.SetError(Txt5, "Ingrese una Cantera")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt7.Value) Then
            Ep1.SetError(Txt7, "Ingrese un Equipo")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo2.Value) Then
            Ep1.SetError(Cbo2, "Seleccione una moneda")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo3.Value) Then
            Ep1.SetError(Cbo3, "Seleccione el Tipo de Precio")
            lResult = Boolean.FalseString
        End If

        If Txt8.Value <= 0 Then
            Ep1.SetError(Txt8, "El precio debe ser mayor a 0")
            lResult = Boolean.FalseString
        End If

        If Val(Txt9.Value) < 0 Then
            Ep1.SetError(Txt9, "Las Horas Mínimas debe ser mayor o igual a 0")
            lResult = Boolean.FalseString
        Else
            If String.IsNullOrEmpty(Cbo4.Value) Then
                Ep1.SetError(Cbo4, "Seleccione un periodo")
                lResult = Boolean.FalseString
            End If
        End If

        Return lResult

    End Function

    Sub Tipo_Equipo()
        Cbo1.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "UNO", Txt4.Value, dtFecha.Value, Now)
        Cbo1.ValueMember = "Codigo"
        Cbo1.DisplayMember = "Descripcion"
    End Sub

#End Region

#Region "Funciones Globales"

    Public Sub Actualizar()

        If String.IsNullOrEmpty(Txt3.Value) Then Return
        If String.IsNullOrEmpty(Txt5.Value) Then Return
        If String.IsNullOrEmpty(Txt7.Value) Then Return
        If Cbo1.Value = "" Then Return

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar_DetalleListaPrecio()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Tab1.Tabs("T01").Selected = True
    End Sub

    Public Sub Buscar()

        If Tipo = 0 Then
            Return
        End If

        xFormulario = "Lista_Precio"

        If String.IsNullOrEmpty(Txt3.Value) And ChkProveedor.Checked = True Then
            Dim Proveedor As New FrmProveedores
            Proveedor.ShowDialog()
            Txt2.Text = Trim(Proveedor.Codigo & "")
            Txt3.Text = Trim(Proveedor.RazonSocial & "")
            Proveedor = Nothing
        ElseIf String.IsNullOrEmpty(Txt5.Value) Then
            Dim Cantera As New FrmListarCantera
            Cantera.FECHA = dtFecha.Value
            Cantera.ShowDialog()
            Txt4.Text = Trim(Cantera.CODIGO & "")
            Txt5.Text = Trim(Cantera.CANTERA & "")
            Cantera = Nothing
            If String.IsNullOrEmpty(Txt4.Text.Trim) Then
                If Not (Tipo = Operacion.Retorno) Then
                    dtFecha.ReadOnly = False
                End If
            Else
                dtFecha.ReadOnly = True
            End If
            xFormulario = String.Empty
            Call Tipo_Equipo()

        ElseIf String.IsNullOrEmpty(Txt7.Value) Then
            Dim Equipo As New FrmListarActivo
            GLinea = Cbo1.Value
            GCantera = Txt4.Value
            Equipo.PROVEEDOR = Txt2.Value
            Equipo.ShowDialog()
            Txt6.Value = Trim(Equipo.CODIGO & "")
            If Trim(Equipo.ACTIVO & "") = "" Then
                Txt7.Value = Trim(Equipo.CODIGO & "")
            Else
                Txt7.Value = Trim(Equipo.ACTIVO & "")
            End If
            Equipo = Nothing
            xFormulario = String.Empty
            GLinea = String.Empty
            Call Iniciar_DetalleListaPrecio()
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
            .Opcion = 3
            .ID = Txt1.Text
            .User = User_Sistema
            .CodCia = Companhia
            .Fecha = dtFecha.Value
        End With
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.Resultado = Negocio.CanteraCosteo.EliminarCanteraListaPrecio(Entidad.CanteraCosteo)
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
            .Cod_Equipo = Txt6.Value
            .NombreEquipo = Txt7.Value
            .Importe = Txt8.Value
            .Tercero = ChkProveedor.Checked
            .Tipo = Cbo1.Value
            .Moneda = Cbo2.Value
            .Periodo = Cbo3.Value
            .User = User_Sistema
            .CodCia = Companhia
            .Fecha = dtFecha.Value
            .NombreTipo = Cbo1.Value
            .Hora = Txt9.Value
            If String.IsNullOrEmpty(Cbo4.Value) Then
                .TipoPerMin = ""
            Else
                .TipoPerMin = Cbo4.Value
            End If

        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCanteraListaPrecio(Entidad.CanteraCosteo)
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



    Private Sub Cbo3_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo3.InitializeLayout

    End Sub

    Private Sub Txt4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt4.ValueChanged
        Txt5.Clear()
        Txt6.Clear()
        Txt7.Clear()
    End Sub

    Private Sub ChkProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkProveedor.CheckedChanged
        Txt2.ReadOnly = Not ChkProveedor.Checked
        Txt3.ReadOnly = Not ChkProveedor.Checked
        Txt2.Clear()
        Txt3.Clear()
    End Sub

    Private Sub Txt2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt2.ValueChanged
        Txt4.Clear()
        Txt5.Clear()
        Txt6.Clear()
        Txt7.Clear()
    End Sub

    Private Sub Txt6_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt6.ValueChanged

    End Sub

    Private Sub Cbo2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo2.ValueChanged

    End Sub
End Class