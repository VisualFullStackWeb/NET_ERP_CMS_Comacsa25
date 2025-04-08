Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmDContratista
    Private Tipo As Int16 = 0
    Private Ls_ListaContratista As List(Of ETCanteraCosteo) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private LsPersonal As List(Of ETPersonal) = Nothing
    Private DT_Billete As DataSet = Nothing
    Private DT_Billete_Castigo As DataSet = Nothing
    Private DT_Personal As DataSet = Nothing
    Private LsPersonalMod As List(Of ETPersonal) = Nothing

    Private Sub CargarBillete()
        Dim Fecha1 As Date
        Dim Fecha2 As Date
        Dim Fecha As Date
        Fecha = CDate(dtp1.Value)
        Fecha1 = DateAdd(DateInterval.Day, (1 - Fecha.Day), Fecha).Date
        Fecha2 = DateAdd(DateInterval.Month, 1, Fecha1).Date
        Fecha2 = DateAdd(DateInterval.Second, -1, Fecha2)
        Txt2.EndUpdate()
        Txt4.EndUpdate()
        Dim EntContratista As New ETCanteraCosteo
        With EntContratista
            .ID = Txt1.Value
            .CodigoProveedor = Txt2.Value
            .CodigoCantera = Txt4.Value
            .FechaInicio = Fecha1
            .FechaFin = Fecha2
            .CodCia = Companhia
        End With
        DT_Billete = Nothing
        Negocio.CanteraCosteo = New NGCanteraCosteo
        DT_Billete = Negocio.CanteraCosteo.Consultar_Cantera_Contratista_Billete(EntContratista)

        EntContratista = Nothing

        Call CargarUltraGrid(Grid3, DT_Billete)
    End Sub

    Private Sub CargarBillete_Castigo()
        
        Txt2.EndUpdate()
        Txt4.EndUpdate()
        Dim EntContratista As New ETCanteraCosteo
        With EntContratista
            .ID = Txt8.Value
            .CodigoProveedor = Txt2.Value
            .CodigoCantera = Txt4.Value
            .CodCia = Companhia
        End With
        DT_Billete_Castigo = Nothing
        Negocio.CanteraCosteo = New NGCanteraCosteo
        DT_Billete_Castigo = Negocio.CanteraCosteo.Consultar_Cantera_Contratista_Billete_Castigo(EntContratista)

        EntContratista = Nothing

        Call CargarUltraGrid(Grid5, DT_Billete_Castigo)
    End Sub

    Private Sub CargarPersonal()
        If Tag Is Nothing Then Exit Sub

        Txt2.EndUpdate()
        Txt4.EndUpdate()
        Dim EntContratista As New ETCanteraCosteo
        With EntContratista
            .ID = Txt1.Value
            .CodigoProveedor = Txt2.Value
            .Fecha = CDate(dtp1.Value)
            .CodCia = Companhia
            If Me.Tag.ToString.Trim = "110" Then
                .Opcion = 1
            Else
                .Opcion = 2
            End If
        End With
        DT_Personal = Nothing
        Negocio.CanteraCosteo = New NGCanteraCosteo
        DT_Personal = Negocio.CanteraCosteo.Consultar_Cantera_Contratista_Personal(EntContratista)

        EntContratista = Nothing
        If Me.Tag.ToString.Trim = "110" Then
            Call CargarUltraGrid(Grid2, DT_Personal)
        Else
            Call CargarUltraGrid(Grid4, DT_Personal)
        End If


    End Sub

    Private Sub frmDContratista_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmDContratista_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)
    End Sub

    Private Sub frmDContratista_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_ListaContratista IsNot Nothing Then Ls_ListaContratista = Nothing


    End Sub

    Private Sub frmDContratista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call ListarCia(Cia)
        
       
        Call Iniciar()
    End Sub

    Sub DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If e.Row.IsFilterRow Then Return
        'If sender.name = "Grid3" Then Return
        Call Consultar_Contratista(e.Row)

    End Sub

    Sub Iniciar()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            Select Case Me.Tag.ToString.Trim
                Case "110"
                    .Opcion = 3
                    Tab1.Tabs("T05").Visible = False
                Case "111"
                    .Opcion = 5
                    Tab1.Tabs("T03").Visible = False
                Case "112"
                    .Opcion = 6
                    Tab1.Tabs("T05").Text = "GUIA vs PERSONAL"
                    Tab1.Tabs("T03").Visible = False
                
            End Select
            .Fecha = Now
        End With
        Tab1.Tabs("T01").Selected = Boolean.TrueString
        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraContratista(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_ListaContratista = New List(Of ETCanteraCosteo)
        Ls_ListaContratista = Entidad.MyLista.Ls_CanteraCosteo

        CargarUltraGridxBinding(Grid1, Source1, Ls_ListaContratista)

    End Sub

    Sub Limpiar()
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Txt3.Value = String.Empty
        Txt4.Value = String.Empty
        Txt5.Value = String.Empty
        Txt6.Value = String.Empty
        Txt7.Value = String.Empty
        Txt8.Value = String.Empty
        Cbo2.Value = ""
        dtp1.Value = DateAdd(DateInterval.Day, 1 - Now.Day, Now)
        dtp1.Value = DateAdd(DateInterval.Month, 1, dtp1.Value)
        dtp1.Value = DateAdd(DateInterval.Day, -1, dtp1.Value)
        Cbo3.Value = "03"
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
        Cbo2.ReadOnly = xBol
        Cbo3.ReadOnly = xBol
        Txt8.ReadOnly = xBol
    End Sub

    Sub Consultar_Contratista(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Txt1.Clear()
        Txt1.Value = uRow.Cells("ID").Value
        Txt2.Value = uRow.Cells("CodigoProveedor").Value
        Txt3.Value = uRow.Cells("Proveedor").Value
        Txt4.Value = uRow.Cells("CodigoCantera").Value
        Txt5.Value = uRow.Cells("Cantera").Value
        Txt6.Value = uRow.Cells("CodEmpleado").Value
        Txt7.Value = uRow.Cells("Empleado").Value
        Cbo2.Value = uRow.Cells("Esquema").Value
        Cbo3.Value = uRow.Cells("TipoTrabajo").Value
        dtp1.Value = uRow.Cells("Fecha").Value
        Txt8.Value = uRow.Cells("ID_Castigo").Value

        Call CargarBillete()

        Select Case Tag.ToString.Trim
            Case "110"
                Call CargarPersonal()

        End Select
       
        Tab1.Tabs("T02").Selected = True
    End Sub

    Function Verificar_Datos() As Boolean

        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt3.Value) Then
            Ep1.SetError(Txt3, "Ingrese el Proveedor")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt5.Value) Then
            Ep1.SetError(Txt5, "Ingrese una Cantera")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt7.Value) Then
            Ep1.SetError(Txt7, "Ingrese el Empleado")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo2.Value) Then
            Ep1.SetError(Cbo2, "Seleccione el Esquema de Cálculo de Boleta")
            lResult = Boolean.FalseString
        End If


        If Val(Txt1.Value) = Val(Txt8.Value) And Val(Txt8.Value) > 0 Then
            Ep1.SetError(Txt8, "No se puede castigar asi mismo")
            lResult = Boolean.FalseString
        End If
        Return lResult

    End Function

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If sender Is Nothing Then Exit Sub

        For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
            If xCol.Key = "ID" Or xCol.Key = "CodigoProveedor" Or _
            xCol.Key = "Proveedor" Or xCol.Key = "CodigoCantera" Or _
            xCol.Key = "Cantera" Or xCol.Key = "CodEmpleado" Or _
            xCol.Key = "Empleado" Or xCol.Key = "Periodo" Or _
            xCol.Key = "ID_Castigo" Then
                xCol.CellActivation = Activation.ActivateOnly
            Else
                xCol.Hidden = True
            End If
        Next
    End Sub

    Public Sub Actualizar()

        Tipo = Operacion.Retorno
        Call Controles(Boolean.TrueString)
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Iniciar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Tab1.Tabs("T01").Selected = True
    End Sub

    Public Sub Buscar()

        If Tipo = 0 Then
            Return
        End If

        If Me.Tag <> "110" Then Exit Sub

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
            Dim Personal As New FrmListarEmpleoLabor
            Personal.EmpleadoTerceros = Txt2.Text.Trim
            Personal.ShowDialog()
            Txt6.Text = Trim(Personal.CODIGO)
            Txt7.Text = Trim(Personal.EMPLEO)
            Personal = Nothing
            xFormulario = String.Empty
        End If

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
        Txt7.EndUpdate()


        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto
        With Entidad.CanteraCosteo
            If Tag = "110" Then
                .Opcion = 2
            Else
                .Opcion = 3
            End If

            .ID = Txt1.Text
            .User = User_Sistema
            .CodCia = Companhia
        End With
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        If Tag = "110" Then
            Entidad.Resultado = Negocio.CanteraCosteo.EliminarCanteraContratista(Entidad.CanteraCosteo, Nothing, Nothing)
        ElseIf Tag = "111" Then
            Entidad.Resultado = Negocio.CanteraCosteo.EliminarCanteraContratista_Faltas(Entidad.CanteraCosteo)
        Else
            Entidad.Resultado = Negocio.CanteraCosteo.EliminarCanteraContratista_Guia_vs_Personal(Entidad.CanteraCosteo)
        End If

        If Entidad.Resultado.Realizo Then
            Call Limpiar()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            Call Iniciar()
            Tab1.Tabs("T01").Selected = Boolean.TrueString
            Tipo = Operacion.Retorno
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Private Sub Grabar_Contratista()
        Dim Fecha As Date
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

        Grid2.Update()
        Grid2.UpdateData()
        Grid3.Update()
        Grid3.UpdateData()

        Grid5.Update()
        Grid5.UpdateData()

        Dim dsbillete As DataSet
        Dim dtbillete As New DataTable
        Dim ibillete As Integer = 0

        dsbillete = Grid3.DataSource
        dtbillete = dsbillete.Tables(0)
        For Each xRow As DataRow In dtbillete.Rows
            If xRow.Item("Action") = True Then
                ibillete = ibillete + 1
            End If
        Next


        If ibillete = 0 Then
            MsgBox("Debe Checkear al menos un Billete", MsgBoxStyle.Critical, msgComacsa)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim dsbillete_Castigo As DataSet
        Dim dtbillete_Castigo As New DataTable
        Dim ibillete_Castigo As Integer = 0

        dsbillete_Castigo = Grid5.DataSource
        If dsbillete_Castigo IsNot Nothing Then
            dtbillete_Castigo = dsbillete_Castigo.Tables(0)
            For Each xRow As DataRow In dtbillete_Castigo.Rows
                If xRow.Item("Action") = True Then
                    ibillete_Castigo = ibillete_Castigo + 1
                End If
            Next
        Else
            dtbillete_Castigo = Nothing
        End If
        

        If ibillete_Castigo = 0 And Val(Txt8.Value) > 0 Then
            MsgBox("Debe Checkear al menos un Billete a Castillar", MsgBoxStyle.Critical, msgComacsa)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim dspersonal As DataSet
        Dim dtpersonal As New DataTable
        Dim ip As Integer = 0

        dspersonal = Grid2.DataSource
        dtpersonal = dspersonal.Tables(0)
        For Each xRow As DataRow In dtpersonal.Rows
            If xRow.Item("Action") = True Then
                ip = ip + 1
            End If
        Next

        If ip = 0 Then
            MsgBox("Debe Checkear al menos un Personal", MsgBoxStyle.Critical, msgComacsa)
            Cursor = Cursors.Default
            Exit Sub
        End If


        Fecha = dtp1.Value
        Fecha = DateAdd(DateInterval.Day, (1 - Fecha.Day), Fecha)
        If Cbo3.Value = "02" Or Cbo3.Value = "03" Then
            Fecha = DateAdd(DateInterval.Month, 1, Fecha)
            Fecha = DateAdd(DateInterval.Day, -1, Fecha)
        Else
            Fecha = DateAdd(DateInterval.Day, 14, Fecha)
        End If
        
        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto

        With Entidad.CanteraCosteo
            .Opcion = 1
            .ID = Txt1.Value
            .ID_Castigo = Txt8.Value
            .CodigoProveedor = Txt2.Value
            .Proveedor = Txt3.Value
            .CodigoCantera = Txt4.Value
            .Cantera = Txt5.Value
            .CodEmpleado = Txt6.Value
            .Empleado = Txt7.Value
            .Esquema = Cbo2.Value
            .User = User_Sistema
            .CodCia = Companhia
            .Fecha = Fecha
            .TipoTrabajo = Cbo3.Value
        End With


        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCanteraContratista(Entidad.CanteraCosteo, dtbillete, dtpersonal, dtbillete_Castigo)
        If Entidad.Resultado.Realizo Then
            Call Limpiar()
            Call Iniciar()
            Tab1.Tabs("T01").Selected = Boolean.TrueString
            Tipo = Operacion.Retorno
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Private Sub Grabar_Contratista_Faltas()

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
        
        
        With Entidad.CanteraCosteo
            .ID = Txt1.Value
            .User = User_Sistema
            .CodCia = Companhia
        End With


        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCanteraContratista_Faltas(Entidad.CanteraCosteo, LsPersonalMod, LsPersonal)
        If Entidad.Resultado.Realizo Then
            Call Limpiar()
            Call Iniciar()
            Tab1.Tabs("T01").Selected = Boolean.TrueString
            Tipo = Operacion.Retorno
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Private Sub Grabar_Contratista_GuiaPersonal()

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


        With Entidad.CanteraCosteo
            .ID = Txt1.Value
            .User = User_Sistema
            .CodCia = Companhia
        End With


        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCanteraContratista_Personal_Guia(Entidad.CanteraCosteo, LsPersonalMod, LsPersonal)
        If Entidad.Resultado.Realizo Then
            Call Limpiar()
            Call Iniciar()
            Tab1.Tabs("T01").Selected = Boolean.TrueString
            Tipo = Operacion.Retorno
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Grabar()
        Select Case Me.Tag
            Case "110"
                Call Grabar_Contratista()
            Case "111"
                Call Grabar_Contratista_Faltas()
            Case "112"
                Call Grabar_Contratista_GuiaPersonal()
        End Select
    End Sub

    Public Sub Modificar()

        If Not VerificarControl(1, Txt1) Then
            MessageBox.Show("No existe registro para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Tipo = Operacion.Modificar
        If Tag = "110" Then
            Call Controles(Boolean.FalseString)
            Grid2.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.AllowEdit
            Grid3.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.AllowEdit
            Grid3.DisplayLayout.Bands(0).Columns("Castigo").CellActivation = Activation.AllowEdit
            Grid4.DisplayLayout.Bands(0).Columns("Billete").CellActivation = Activation.NoEdit
            Grid5.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.AllowEdit
            Grid5.DisplayLayout.Bands(0).Columns("Castigo").CellActivation = Activation.AllowEdit
        Else
            LsPersonal = Nothing
            LsPersonalMod = Nothing

            LsPersonal = New List(Of ETPersonal)
            LsPersonalMod = New List(Of ETPersonal)
            Call Controles(Boolean.TrueString)
            
            Grid2.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.ActivateOnly
            Grid3.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.ActivateOnly
            Grid3.DisplayLayout.Bands(0).Columns("Castigo").CellActivation = Activation.ActivateOnly
            Grid4.DisplayLayout.Bands(0).Columns("Billete").CellActivation = Activation.AllowEdit
            Grid5.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.ActivateOnly
        End If



    End Sub

    Public Sub Nuevo()
        If Me.Tag <> "110" Then Exit Sub
        Tipo = Operacion.Nuevo
        Call Limpiar()
        Call Controles(Boolean.FalseString)
        Tab1.Tabs("T02").Selected = Boolean.TrueString
    End Sub


    Private Sub Txt6_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt6.ValueChanged
        If String.IsNullOrEmpty(Txt6.Value) Then
            Txt7.Value = String.Empty
        End If
    End Sub

    Private Sub Txt4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt4.ValueChanged
        If String.IsNullOrEmpty(Txt4.Value) Then
            Txt5.Value = String.Empty
            Txt6.Value = String.Empty
            Txt7.Value = String.Empty
        End If
        Call CargarBillete()
        Call CargarPersonal()
    End Sub

    Private Sub Txt2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt2.ValueChanged
        If String.IsNullOrEmpty(Txt2.Value) Then
            Txt3.Value = String.Empty
            Txt4.Value = String.Empty
            Txt5.Value = String.Empty
            Txt6.Value = String.Empty
            Txt7.Value = String.Empty
        End If
        Call CargarBillete()
        Call CargarPersonal()
    End Sub

    Private Sub dtp1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp1.ValueChanged
        Call CargarBillete()
        Call CargarPersonal()
    End Sub



    Private Sub Grid3_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid3.InitializeLayout
        If sender Is Nothing Then Exit Sub
        If e Is Nothing Then Exit Sub

        For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
            If Tipo = Operacion.Nuevo Or Tipo = Operacion.Modificar Then
                If xCol.Key = "Action" Or xCol.Key = "Castigo" Then
                    xCol.CellActivation = Activation.AllowEdit
                Else
                    xCol.CellActivation = Activation.ActivateOnly
                End If
            Else
                xCol.CellActivation = Activation.ActivateOnly
            End If

        Next
    End Sub


    Private Sub Grid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid2.InitializeLayout
        For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
            If Tipo = Operacion.Nuevo Or Tipo = Operacion.Modificar Then
                If xCol.Key = "Action" Then
                    xCol.CellActivation = Activation.AllowEdit
                Else
                    xCol.CellActivation = Activation.ActivateOnly
                End If
            Else
                xCol.CellActivation = Activation.ActivateOnly
            End If
        Next
    End Sub

    Private Sub Grid4_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles Grid4.ClickCellButton
        If e Is Nothing Then Exit Sub
        Dim i As Integer = 0
        Dim j As Integer = 0
        If Tipo = Operacion.Retorno Then
            MessageBox.Show(Mensaje.Seleccion_2, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim frm As New frmListarNroGuia
        frm.ID = Txt1.Value
        frm.PlaCod = e.Cell.Row.Cells("PlaCod").Value
        frm.Formulario = Tag.ToString.Trim
        frm.ShowDialog()
        Entidad.Personal = New ETPersonal

        With Entidad.Personal
            .CodPersonal = e.Cell.Row.Cells("PlaCod").Value
        End With
        If LsPersonalMod.Count <= 0 Then
            LsPersonalMod.Add(Entidad.Personal)
        Else
            While i < LsPersonalMod.Count
                If LsPersonalMod(i).CodPersonal = e.Cell.Row.Cells("PlaCod").Value Then
                    j = j + 1
                End If
                i = i + 1
            End While

            If j = 0 Then
                LsPersonalMod.Add(Entidad.Personal)
            End If

        End If

        i = 0
        If frm.Faltas.Count > 0 Then
            While i < LsPersonal.Count
                If LsPersonal(i).CodPersonal = e.Cell.Row.Cells("PlaCod").Value Then
                    LsPersonal.RemoveAt(i)
                Else
                    i = i + 1
                End If
            End While

            For Each xRow As ETPersonal In frm.Faltas
                LsPersonal.Add(xRow)
            Next
        End If
        frm = Nothing
    End Sub

    Private Sub Grid4_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid4.InitializeLayout
        For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
            If xCol.Key = "Billete" Then
                xCol.CellActivation = Activation.NoEdit
            Else
                xCol.CellActivation = Activation.ActivateOnly
            End If

        Next
    End Sub

    Private Sub Txt8_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt8.ValueChanged
        Call CargarBillete_Castigo()
    End Sub
End Class