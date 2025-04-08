Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmMCombustibleExplosivos

#Region "Variables"
    Private Tipo As Int16 = 0
    Private Ls_Combustible As List(Of ETCanteraCosteo) = Nothing
    Public Ls_Permisos As New List(Of Integer)
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
        txtprecio.Value = 0
        Txt9.Value = String.Empty
        Txt10.Value = String.Empty
     
        Cbo2.Value = ""
        Cbo1.Value = ""
        Cbo3.Value = "C"
        Call Iniciar_Detalle_Cantera()
        Ep1.Clear()
        Ep2.Clear()
    End Sub

    Sub Controles(ByVal xBol As Boolean)

        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        Txt6.ReadOnly = xBol
        Txt8.ReadOnly = xBol
        Txt9.ReadOnly = True
        Txt2.ReadOnly = xBol
        Cbo2.ReadOnly = xBol
        Cbo1.ReadOnly = xBol
        Cbo3.ReadOnly = xBol
        If Cbo3.Value = "C" Then
            Txt10.ReadOnly = True
        Else
            Txt10.ReadOnly = xBol
        End If

        dtFecha.ReadOnly = xBol

    End Sub

    Sub Iniciar()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Opcion = 2
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ListarCanteraCombustibleExplosivo(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Combustible = New List(Of ETCanteraCosteo)
        Ls_Combustible = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Combustible)

    End Sub

    Sub Iniciar_Detalle_Cantera()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .CodigoCantera = Txt2.Value
            .Opcion = 4
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ListarCanteraCombustibleExplosivo(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Combustible = New List(Of ETCanteraCosteo)
        Ls_Combustible = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGrid(Grid2, Ls_Combustible)

    End Sub

    Sub Consultar_Combustible(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Cbo1.Value = ""
        Txt4.Clear()
        Txt5.Clear()

        Txt1.Value = uRow.Cells("ID").Value
        Txt2.Value = uRow.Cells("CodigoCantera").Value
        Txt3.Value = uRow.Cells("Cantera").Value
        Cbo2.Value = uRow.Cells("Tipo").Value
        Cbo3.Value = uRow.Cells("TipoTrabajo").Value
        
        Txt6.Value = uRow.Cells("CodProd").Value
        Txt7.Value = uRow.Cells("Descripcion").Value
        Txt8.Value = uRow.Cells("Importe").Value
        Txt9.Value = uRow.Cells("UM").Value
        Txt10.Value = uRow.Cells("Motivo").Value
        If uRow.Cells("Cod_Equipo").Value <> "" Then
            Call Tipo_Equipo()
            Cbo1.Value = uRow.Cells("Periodo").Value
            Txt4.Value = uRow.Cells("Cod_Equipo").Value
            Txt5.Value = uRow.Cells("NombreEquipo").Value
        End If



        dtFecha.Value = uRow.Cells("Fecha").Value

        Call Iniciar_Detalle_Cantera()

        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Function Verificar_Datos() As Boolean

        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt6.Value) Then
            Ep1.SetError(Txt6, "Ingrese un Usuario para Verificar")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt7.Value) Then
            Ep1.SetError(Txt7, "Ingrese el producto")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt8.Value) Then
            Ep1.SetError(Txt8, "Ingrese la Cantidad")
            lResult = Boolean.FalseString
        End If

        'If String.IsNullOrEmpty(txtprecio.Value) Then
        '    Ep1.SetError(txtprecio, "Ingrese el Precio")
        '    lResult = Boolean.FalseString
        'End If

        If Val(Txt8.Value) <= 0 Then
            Ep1.SetError(Txt8, "Ingrese una Cantidad Mayor a Cero")
            lResult = Boolean.FalseString
        End If

        'If Val(txtprecio.Value) <= 0 Then
        '    Ep1.SetError(txtprecio, "Ingrese unn Precio Mayor a Cero")
        '    lResult = Boolean.FalseString
        'End If

        If Cbo3.Value = "A" And String.IsNullOrEmpty(Txt10.Value) Then
            Ep1.SetError(Txt10, "Ingrese el motivo por el cual sea consumido el combustible")
            lResult = Boolean.FalseString
        End If

        Return lResult

    End Function

    Sub Tipo_Equipo()
        'Cbo1.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "UNO", Txt2.Value, Me.dtFecha.Value, Now)
        'Cbo1.ValueMember = "Codigo"
        'Cbo1.DisplayMember = "Descripcion"
    End Sub

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

        If Not VerificarControl(1, Txt6) Then
            MessageBox.Show("No existe Usuario para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        If Not VerificarControl(1, Txt6) Then
            MessageBox.Show("No existe Usuario para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If Tipo = Operacion.Retorno Then
            MessageBox.Show(Mensaje.Seleccion_2, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If Not Verificar_Datos() Then
            MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Txt1.EndUpdate()
        Txt6.EndUpdate()
        Txt7.EndUpdate()
        Txt8.EndUpdate()
        Txt9.EndUpdate()
        Txt2.EndUpdate()
        Txt3.EndUpdate()
        Txt4.EndUpdate()
        Txt5.EndUpdate()
        Txt10.EndUpdate()
        txtprecio.EndUpdate()

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto

        With Entidad.CanteraCosteo
            .Opcion = 1
            .ID = Txt1.Value
            .CodProd = Txt6.Value
            .Descripcion = Txt7.Value
            .Importe = Txt8.Value
            '.Cantidad = txtprecio.Value
            .UM = Txt9.Value
            .CodigoCantera = Txt2.Value
            .Cantera = Txt3.Value
            .Cod_Equipo = Txt4.Value
            .NombreEquipo = Txt5.Value
            .User = User_Sistema
            .Fecha = dtFecha.Value
            .Tipo = Cbo2.Value
            .NombreTipo = Cbo1.Value
            .TipoTrabajo = Cbo3.Value
            .Motivo = Txt10.Text
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCombustibleExplosivo(Entidad.CanteraCosteo)

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
        xFormulario = "Combustible_Explosivo"
        If String.IsNullOrEmpty(Txt3.Text) Then
            Dim Cantera As New FrmListarCantera
            Cantera.ShowDialog()
            Txt2.Text = Trim(Cantera.CODIGO & "")
            Txt3.Text = Trim(Cantera.CANTERA & "")
            Cantera = Nothing
            xFormulario = String.Empty
            Txt4.SelectAll()
            Call Tipo_Equipo()
            Return
        End If

        If String.IsNullOrEmpty(Txt7.Text) Then
            Dim Combustible As New FrmListarProductos

            If Cbo2.Value = "C" Then
                xFormulario = "Cantera_Combustible"
            Else
                xFormulario = "Cantera_Explosivo"
            End If

            Combustible.ShowDialog()
            Txt6.Text = Trim(Combustible.CODIGO & "")
            Txt7.Text = Trim(Combustible.DESCRIPCION & "")
            Txt9.Text = Trim(Combustible.UNIDADMEDIDA & "")
            Combustible = Nothing
            xFormulario = String.Empty
            Txt8.SelectAll()
            Return
        End If

        If String.IsNullOrEmpty(Txt5.Text) And Txt5.Enabled = True Then
            Dim Activo As New FrmListarActivo
            GCantera = Txt2.Value
            GLinea = Cbo1.Value
            Activo.ShowDialog()
            Txt4.Text = Trim(Activo.CODIGO & "")
            Txt5.Text = Trim(Activo.ACTIVO & "")
            Activo = Nothing
            xFormulario = String.Empty
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
            .Opcion = 3
            .ID = Txt1.Value
            .User = User_Sistema
            .Fecha = dtFecha.Value
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.EliminarCombustibleExplosivo(Entidad.CanteraCosteo)

        If Entidad.Resultado.Realizo Then
            Call Iniciar()
            Call Limpiar()
            Tab1.Tabs("T01").Selected = True
            Tipo = Operacion.Retorno
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)


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

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Iniciar()
        Call Tipo_Equipo()
        Call ListarCia(Cia)
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

        If Ls_Combustible IsNot Nothing Then Ls_Combustible = Nothing

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout, Grid2.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Fecha" Or uColumn.Key = "NombreTipo" Or _
                        uColumn.Key = "CodProd" Or uColumn.Key = "Descripcion" Or _
                        uColumn.Key = "ID" Or uColumn.Key = "DescripTipoTrabajo" Or _
                        uColumn.Key = "CodigoCantera" Or uColumn.Key = "Cantera" Or _
                        uColumn.Key = "Cod_Equipo") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                    uColumn.CellActivation = Activation.ActivateOnly
                End If
            Next
            Return
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Fecha" Or uColumn.Key = "NombreTipo" Or _
                        uColumn.Key = "CodProd" Or uColumn.Key = "Descripcion" Or _
                        uColumn.Key = "UM" Or uColumn.Key = "Importe" Or _
                        uColumn.Key = "DescripTipoTrabajo" Or uColumn.Key = "Cod_Equipo") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                    uColumn.CellActivation = Activation.ActivateOnly
                End If
            Next
            Return
        End If

    End Sub

    Sub DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow, _
                                                                                                                                Grid2.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If e.Row.IsFilterRow Then Return

        Call Consultar_Combustible(e.Row)

    End Sub

    Private Sub ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt6.ValueChanged _
                                                                                                , Txt2.ValueChanged _
                                                                                                , Cbo2.ValueChanged _
                                                                                                , Cbo3.ValueChanged, Cbo1.ValueChanged

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Txt6 Then
            If Len(Txt6.Text) <> 8 Then
                Txt7.Clear()
                Txt8.Value = 0
                Txt9.Clear()
            End If
        End If

        If sender Is Txt2 Then
            If Len(Txt2.Text) <> 5 Then
                Txt3.Clear()
            End If
        End If

        If sender Is Cbo2 Then

            If Cbo2.Value = "C" Then

                Cbo1.Enabled = True
                Txt4.Enabled = True
                Txt5.Enabled = True

            Else
                Cbo1.Enabled = False
                Txt4.Enabled = False
                Txt5.Enabled = False

            End If


            Txt6.Clear()
            Txt7.Clear()
            Txt8.Value = 0
            Txt9.Clear()
        End If

        If sender Is Cbo3 Then
            Txt10.Clear()
            If Cbo3.Value = "C" Then
                Txt10.ReadOnly = True
            Else
                If Not (Operacion.Retorno) Then
                    Txt10.ReadOnly = False
                    Txt10.Focus()
                Else
                    Txt10.ReadOnly = True
                End If
            End If
        End If

    End Sub

    Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt6.KeyDown, _
                                                                                                      Txt2.KeyDown, _
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
            End If

            If sender Is Txt6 Then
                Txt7.Clear()
            End If
        End If

    End Sub

#End Region


End Class