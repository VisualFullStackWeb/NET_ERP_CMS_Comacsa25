Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmMCostoAutorizacion

#Region "Variables"
    Private Tipo As Int16 = 0
    Private Ls_CostoAutorizacion As List(Of ETCanteraCosteo) = Nothing
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

        If Ls_CostoAutorizacion IsNot Nothing Then Ls_CostoAutorizacion = Nothing

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout, Grid2.InitializeLayout, Cbo4.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "ID" Or uColumn.Key = "MesName" Or _
                        uColumn.Key = "Ano" Or uColumn.Key = "CodigoCantera" Or _
                        uColumn.Key = "Cantera" Or uColumn.Key = "Glosa" Or _
                        uColumn.Key = "NombreTipo") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Importe" Or uColumn.Key = "Moneda" Or _
                        uColumn.Key = "ID" Or _
                        uColumn.Key = "Glosa" Or uColumn.Key = "NombreTipo") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If

        If sender Is Cbo4 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Glosa") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.MaxWidth = Cbo4.Width
                    uColumn.MinWidth = Cbo4.Width
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

        If e.Row.IsFilterRow Then Return

        Call Consultar_CostoAutorizacion(e.Row)


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
                Txt2.Clear()
                Txt3.Clear()
                Call Iniciar_Detalle_CostoAutorizacion()
            End If
        End If
    End Sub

    Sub _Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click, _
                                                                                   btn3.Click, _
                                                                                   btn4.Click, _
                                                                                   btn5.Click, _
                                                                                   btn6.Click, _
                                                                                   btn7.Click, _
                                                                                   btn8.Click, _
                                                                                   btn9.Click, _
                                                                                   btn10.Click
        If Tipo = 0 Then Return

        If (sender Is btn2) Or (sender Is btn4) Or (sender Is btn6) Then
            OpenFile.CheckFileExists = True
            OpenFile.CheckPathExists = True
            OpenFile.DereferenceLinks = True
            OpenFile.ValidateNames = True
            OpenFile.Multiselect = False
            OpenFile.RestoreDirectory = True
            OpenFile.ShowHelp = True
            OpenFile.ShowReadOnly = False
            OpenFile.DefaultExt = "doc"
            OpenFile.Title = "Seleccione Archivo"
            OpenFile.Filter = "Microsoft Word Files (*.doc)|*.doc"
            If OpenFile.ShowDialog() = 1 Then
                If sender Is btn2 Then
                    Txt5.Value = OpenFile.FileName
                ElseIf sender Is btn4 Then
                    Txt6.Value = OpenFile.FileName
                ElseIf sender Is btn6 Then
                    Txt7.Value = OpenFile.FileName
                End If
            End If
        End If


        If (sender Is btn3) Or (sender Is btn5) Or (sender Is btn7) Then
            Dim wordapp As Object
            Dim ruta As String = ""

            If sender Is btn3 Then
                If Txt5.Value = "" Then
                    MsgBox("NO archivo por abrir", MsgBoxStyle.Critical, "Comacsa")
                    Return
                End If
                ruta = Txt5.Value
            ElseIf sender Is btn5 Then
                If Txt6.Value = "" Then
                    MsgBox("NO archivo por abrir", MsgBoxStyle.Critical, "Comacsa")
                    Return
                End If
                ruta = Txt6.Value
            ElseIf sender Is btn7 Then
                If Txt7.Value = "" Then
                    MsgBox("No hay archivo para abrir", MsgBoxStyle.Critical, "Comacsa")
                    Return
                End If
                ruta = Txt7.Value
            End If

            On Error Resume Next
            wordapp = CreateObject("WORD.APPLICATION")
            wordapp.Documents.Open(FileName:=ruta, ReadOnly:=True)
            wordapp.Visible = True
        End If


        If (sender Is btn8) Or (sender Is btn9) Or (sender Is btn10) Then
            If sender Is btn8 Then
                Txt5.Clear()
            ElseIf sender Is btn9 Then
                Txt6.Clear()
            ElseIf sender Is btn10 Then
                Txt7.Clear()
            End If
        End If

    End Sub

    Private Sub Cbo1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo1.ValueChanged
        If String.IsNullOrEmpty(Cbo1.Value) Then
            Call LlenarMeses(Cbo3, Date.Now.Year, Date.Now.Month)
        Else
            Call LlenarMeses(Cbo3, Cbo1.Value, Date.Now.Month)
        End If
        If Not (String.IsNullOrEmpty(Cbo1.Value)) Then
            Call Iniciar_Detalle_CostoAutorizacion()
        End If

    End Sub

    Private Sub Cbo3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo3.ValueChanged
        If Not (String.IsNullOrEmpty(Cbo1.Value)) Then
            Call Iniciar_Detalle_CostoAutorizacion()
        End If
        'Call Iniciar_Detalle_CostoAutorizacion()
    End Sub

#End Region

#Region "Funciones Locales"

    Sub Limpiar()
        Call LlenarAnio(Cbo1, 2010, Year(Date.Now))
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Txt3.Value = String.Empty
        Txt4.Value = 0
        Txt10.Value = 0
        Txt5.Value = String.Empty
        Txt6.Value = String.Empty
        Txt7.Value = String.Empty

        Txt9.Value = 0
        chkMes.Checked = False
        Cbo1.Value = ""
        Cbo2.Value = ""
        Cbo3.Value = ""
        Cbo4.Value = ""
        Ls_CostoAutorizacion = New List(Of ETCanteraCosteo)
        Call CargarUltraGrid(Grid2, Ls_CostoAutorizacion)
        'Call Iniciar_Detalle_CostoAutorizacion()
        Ep1.Clear()
        Ep2.Clear()

    End Sub

    Sub Controles(ByVal xBol As Boolean)
        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        Txt2.ReadOnly = xBol
        Txt10.ReadOnly = xBol
        Cbo1.ReadOnly = xBol
        Cbo2.ReadOnly = xBol
        Cbo4.ReadOnly = xBol
        chkMes.Enabled = Not xBol
        If chkMes.Checked = True Then
            If xBol = False Then
                Cbo3.ReadOnly = xBol
            Else
                Cbo3.ReadOnly = True
            End If
        End If
        Txt4.ReadOnly = True
        Txt9.ReadOnly = True
    End Sub

    Sub Iniciar()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Opcion = 4
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraCostoAutorizacion(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_CostoAutorizacion = New List(Of ETCanteraCosteo)
        Ls_CostoAutorizacion = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_CostoAutorizacion)

        Call CargarGlosa()
        Me.Tab1.Tabs("T01").Selected = True
    End Sub


    Sub CargarGlosa()
        Dim Ls_Glosa As New List(Of ETGlosa)
        Entidad.Glosa = New ETGlosa
        Entidad.Glosa.Cod_Modulo = 93
        Entidad.Glosa.Tipo = 6

        Negocio.Glosa = New NGGlosa
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.Glosa.ConsultarGlosaFormulario(Entidad.Glosa)
        If Entidad.MyLista IsNot Nothing Then
            If Entidad.MyLista.Validacion Then
                Ls_Glosa = Entidad.MyLista.Ls_Glosa
            End If
        End If

        Call CargarUltraCombo(Cbo4, Ls_Glosa, "ID", "Glosa")

    End Sub

    Sub Iniciar_Detalle_CostoAutorizacion()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista
        Entidad.CanteraCosteo = New ETCanteraCosteo
        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .CodigoCantera = Txt2.Value
            .Ano = Val(Cbo1.Value)
            If chkMes.Checked = True Then
                If String.IsNullOrEmpty(Cbo3.Value) Then
                    .Mes = Date.Now.Month
                Else
                    .Mes = Val(Cbo3.Value)
                End If
            Else
                .Mes = Date.Now.Month
            End If

            .Moneda = Cbo2.Value
            .Opcion = 2
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraCostoAutorizacion(Entidad.CanteraCosteo)
        Ls_CostoAutorizacion = New List(Of ETCanteraCosteo)
        If Entidad.MyLista.Validacion Then
            Ls_CostoAutorizacion = Entidad.MyLista.Ls_CanteraCosteo
        End If

        Entidad.CanteraCosteo.Opcion = 8
        Me.Txt9.Value = Negocio.CanteraCosteo.ConsultarCanteraCostoAutorizacionMensual(Entidad.CanteraCosteo)

        Call CargarUltraGrid(Grid2, Ls_CostoAutorizacion)

    End Sub

    Sub Consultar_CostoAutorizacion(ByVal uRow As UltraGridRow)
        Dim xAnio As Long
        Dim xMes As Integer
        If uRow Is Nothing Then
            Return
        End If

        Txt1.Value = uRow.Cells("ID").Value
        Txt2.Value = uRow.Cells("CodigoCantera").Value
        Txt3.Value = uRow.Cells("Cantera").Value
        Txt4.Value = uRow.Cells("Importe").Value
        Txt5.Value = uRow.Cells("Archivo1").Value
        Txt6.Value = uRow.Cells("Archivo2").Value
        Txt7.Value = uRow.Cells("Archivo3").Value
        Cbo4.Value = uRow.Cells("Cod_Glosa").Value
        Txt9.Value = uRow.Cells("Importe2").Value
        Txt10.Value = uRow.Cells("Importe3").Value
        If Val(uRow.Cells("Tipo").Value) = 0 Then
            Chk2.Checked = False
        Else
            Chk2.Checked = True
        End If
        xAnio = uRow.Cells("Ano").Value
        xMes = uRow.Cells("Mes").Value
        Cbo2.Value = uRow.Cells("Moneda").Value
        Call LlenarAnio(Cbo1, 2010, Year(Date.Now))
        Cbo1.Value = xAnio
        Call LlenarMeses(Cbo3, Cbo1.Value, Date.Now.Month)
        If xMes = 0 Then
            chkMes.Checked = False
        Else
            chkMes.Checked = True
        End If
        Cbo3.Value = xMes

        Call Iniciar_Detalle_CostoAutorizacion()
        Tab1.Tabs("T02").Selected = Boolean.TrueString
    End Sub

    Function Verificar_Datos() As Boolean

        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt3.Value) Then
            Ep1.SetError(Txt3, "Ingrese una Cantera")
            lResult = Boolean.FalseString
        End If

        If Val(Txt10.Value) <= 0 Then
            Ep1.SetError(Txt10, "El Importe debe ser mayor a 0")
            lResult = Boolean.FalseString
        End If

        If Val(Txt4.Value) <= 0 Then
            Ep1.SetError(Txt10, "El Importe debe ser mayor a 0")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo1.Value) Then
            Ep1.SetError(Cbo1, "Seleccione un año")
            lResult = Boolean.FalseString
        End If

        If Me.chkMes.Checked = True Then
            If String.IsNullOrEmpty(Cbo3.Value) Then
                Ep1.SetError(Cbo3, "Seleccione el Mes")
                lResult = Boolean.FalseString
            End If
        End If

        If String.IsNullOrEmpty(Cbo2.Value) Then
            Ep1.SetError(Cbo2, "Seleccione una moneda")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo4.Value) Then
            Ep1.SetError(Cbo4, "Seleccione la Glosa")
            lResult = Boolean.FalseString
        End If

        'Entidad.CanteraCosteo = New ETCanteraCosteo
        'Negocio.CanteraCosteo = New NGCanteraCosteo
        'Entidad.Objecto = New ETObjecto
        'With Entidad.CanteraCosteo
        '    .Opcion = 3
        '    .CodigoCantera = Txt2.Value
        '    .Ano = Cbo1.Value
        'End With
        'If Negocio.CanteraCosteo.ValidarCanteraDerechoCesion(Entidad.CanteraCosteo) = True Then
        '    Ep1.SetError(Txt3, "La Cantera ya tiene un registro en ese año")
        '    lResult = Boolean.FalseString
        'End If

        Return lResult

    End Function

#End Region

#Region "Funciones Globales"

    Public Sub Actualizar()
        Tipo = Operacion.Retorno
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Tab1.Tabs("T01").Selected = True
    End Sub

    Public Sub Buscar()
        If Tipo = 0 Then
            Return
        End If
        xFormulario = "Costo_Autorizacion"
        If String.IsNullOrEmpty(Txt3.Value) Then
            Dim Cantera As New FrmListarCantera
            Cantera.ANIO = Cbo1.Value
            Cantera.ShowDialog()
            Txt2.Text = Trim(Cantera.CODIGO & "")
            Txt3.Text = Trim(Cantera.CANTERA & "")
            Cantera = Nothing
            'If String.IsNullOrEmpty(Txt2.Text.Trim) Then
            '    If Not (Tipo = Operacion.Retorno) Then
            '        Cbo1.ReadOnly = False
            '    End If
            'Else
            '    Cbo1.ReadOnly = True
            'End If
            If Not (String.IsNullOrEmpty(Cbo1.Value)) Then
                Call Iniciar_Detalle_CostoAutorizacion()
            End If

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
        Txt7.EndUpdate()


        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto
        With Entidad.CanteraCosteo
            .Opcion = 3
            .ID = Txt1.Text
            .User = User_Sistema
            .CodCia = Companhia
        End With
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.Resultado = Negocio.CanteraCosteo.EliminarCostoAutorizacion(Entidad.CanteraCosteo)
        If Entidad.Resultado.Realizo Then
            Call Limpiar()
            Call Iniciar()
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
        Txt5.EndUpdate()
        Txt7.EndUpdate()
        Txt9.EndUpdate()
        Txt10.EndUpdate()
        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto

        With Entidad.CanteraCosteo
            .Opcion = 1
            .ID = Txt1.Text
            .CodigoCantera = Txt2.Value
            .Cantera = Txt3.Value
            .Importe = Txt4.Value
            .Archivo1 = Txt5.Value
            .Archivo2 = Txt6.Value
            .Archivo3 = Txt7.Value
            .Cod_Glosa = Cbo4.Value
            .Importe2 = Txt9.Value
            .Importe3 = Txt10.Value
            .Ano = Cbo1.Value
            .Moneda = Cbo2.Value
            If Chk2.Checked = False Then
                .Tipo = "0"
            Else
                .Tipo = "1"
            End If

            If chkMes.Checked = True Then
                .Mes = Cbo3.Value
            Else
                .Mes = 0
            End If

            .User = User_Sistema
            .CodCia = Companhia
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCostoAutorizacion(Entidad.CanteraCosteo)
        If Entidad.Resultado.Realizo Then
            Call Limpiar()
            Call Iniciar()
            Tab1.Tabs("T01").Selected = True
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

    Private Sub chkMes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMes.CheckedChanged
        Txt4.Visible = Not chkMes.Checked
        UltraLabel12.Visible = Not chkMes.Checked
        Cbo3.ReadOnly = Not chkMes.Checked
    End Sub

    Private Sub Txt10_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt10.ValueChanged
        If chkMes.Checked = True Then
            Txt4.Value = Txt10.Value
        Else
            If IsDBNull(Txt10.Value) Then
                Txt4.Value = 0
            Else
                Txt4.Value = (Txt10.Value / 12)
            End If

        End If
    End Sub
End Class