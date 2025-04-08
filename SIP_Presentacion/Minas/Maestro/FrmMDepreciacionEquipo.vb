Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmMDepreciacionEquipo

#Region "Variables"
    Private Tipo As Int16 = 0
    Private Ls_Depreciacion As List(Of ETCanteraCosteo) = Nothing
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

        If Ls_Depreciacion IsNot Nothing Then Ls_Depreciacion = Nothing

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid2.InitializeLayout, Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "ID" Or uColumn.Key = "Ano" Or _
                        uColumn.Key = "CodigoCantera" Or uColumn.Key = "Cantera") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If


        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Ano" Or uColumn.Key = "Cod_Equipo" Or _
                        uColumn.Key = "NombreEquipo" Or uColumn.Key = "Moneda" Or _
                        uColumn.Key = "Importe") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If


    End Sub

    Sub DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid2.DoubleClickRow, _
                                                                                                                             Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If e.Row.IsFilterRow Then Return

        Call Consultar_CanteraDepreciacion(e.Row)

    End Sub

    Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt2.KeyDown, _
                                                                                                     Txt4.KeyDown
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If (e.KeyCode) = 8 Or (e.KeyCode) = 46 Then
            If sender Is Txt2 Then
                Txt3.Clear()
                Txt2.Clear()
                Txt2.EndUpdate()
                Call Iniciar_DetalleCantera()
            End If

            If sender Is Txt4 Then
                Txt5.Clear()
                Txt4.Clear()
                Txt4.EndUpdate()
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
                    Txt7.Value = OpenFile.FileName
                ElseIf sender Is btn4 Then
                    Txt8.Value = OpenFile.FileName
                ElseIf sender Is btn6 Then
                    Txt9.Value = OpenFile.FileName
                End If
            End If
        End If


        If (sender Is btn3) Or (sender Is btn5) Or (sender Is btn7) Then
            Dim wordapp As Object
            Dim ruta As String = ""

            If sender Is btn3 Then
                If Txt7.Value = "" Then
                    MsgBox("NO archivo por abrir", MsgBoxStyle.Critical, "Comacsa")
                    Return
                End If
                ruta = Txt7.Value
            ElseIf sender Is btn5 Then
                If Txt8.Value = "" Then
                    MsgBox("NO archivo por abrir", MsgBoxStyle.Critical, "Comacsa")
                    Return
                End If
                ruta = Txt8.Value
            ElseIf sender Is btn7 Then
                If Txt9.Value = "" Then
                    MsgBox("NO archivo por abrir", MsgBoxStyle.Critical, "Comacsa")
                    Return
                End If
                ruta = Txt9.Value
            End If

            On Error Resume Next
            wordapp = CreateObject("WORD.APPLICATION")
            wordapp.Documents.Open(FileName:=ruta, ReadOnly:=True)
            wordapp.Visible = True
        End If


        If (sender Is btn8) Or (sender Is btn9) Or (sender Is btn10) Then
            If sender Is btn8 Then
                Txt7.Clear()
            ElseIf sender Is btn9 Then
                Txt8.Clear()
            ElseIf sender Is btn10 Then
                Txt9.Clear()
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
        Txt6.Value = 0
        Txt7.Value = String.Empty
        Txt8.Value = String.Empty
        Txt9.Value = String.Empty
        Cbo1.Value = ""
        Cbo2.Value = ""
        Cbo3.Value = ""
        Call Iniciar_DetalleCantera()
        Ep1.Clear()
        Ep2.Clear()
        
    End Sub

    Sub Controles(ByVal xBol As Boolean)
        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        Txt2.ReadOnly = xBol
        'Txt3.ReadOnly = xBol
        Txt4.ReadOnly = xBol
        'Txt5.ReadOnly = xBol
        Txt6.ReadOnly = xBol
        'Txt7.ReadOnly = xBol
        'Txt8.ReadOnly = xBol
        'Txt9.ReadOnly = xBol
        Cbo1.ReadOnly = xBol
        Cbo2.ReadOnly = xBol
        Cbo3.ReadOnly = xBol

    End Sub

    Sub Iniciar()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Opcion = 4
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ListarCanteraDepreciacion(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Depreciacion = New List(Of ETCanteraCosteo)
        Ls_Depreciacion = Entidad.MyLista.Ls_CanteraCosteo

        CargarUltraGridxBinding(Grid1, Source1, Ls_Depreciacion)
        Tab1.Tabs("T01").Selected = True
    End Sub

    Sub Iniciar_DetalleCantera()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .CodigoCantera = Txt2.Value
            .Opcion = 2
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ListarCanteraDepreciacion(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Depreciacion = New List(Of ETCanteraCosteo)
        Ls_Depreciacion = Entidad.MyLista.Ls_CanteraCosteo

        CargarUltraGrid(Grid2, Ls_Depreciacion)

    End Sub

    Sub Consultar_CanteraDepreciacion(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then Return

        Txt1.Value = uRow.Cells("ID").Value
        Txt2.Value = uRow.Cells("CodigoCantera").Value
        Txt3.Value = uRow.Cells("Cantera").Value
        Call Tipo_Equipo()
        Txt4.Value = uRow.Cells("Cod_Equipo").Value
        Txt5.Value = uRow.Cells("NombreEquipo").Value
        Txt6.Value = uRow.Cells("Importe").Value
        Txt7.Value = uRow.Cells("Archivo1").Value
        Txt8.Value = uRow.Cells("Archivo2").Value
        Txt9.Value = uRow.Cells("Archivo3").Value
        Cbo1.Value = uRow.Cells("NombreTipo").Value
        Cbo2.Value = uRow.Cells("Ano").Value
        Cbo3.Value = uRow.Cells("Moneda").Value
        Call Iniciar_DetalleCantera()
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

        If String.IsNullOrEmpty(Cbo1.Value) Then
            Ep1.SetError(Cbo2, "Seleccione un tipo de equipo")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt5.Value) Then
            Ep1.SetError(Txt5, "Ingrese un Equipo")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo2.Value) Then
            Ep1.SetError(Cbo2, "Seleccione un Año")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo3.Value) Then
            Ep1.SetError(Cbo3, "Seleccione una moneda")
            lResult = Boolean.FalseString
        End If

        If Val(Txt6.Value) <= 0 Then
            Ep1.SetError(Txt6, "El Importe debe ser mayor a 0")
            lResult = Boolean.FalseString
        End If

        Return lResult

    End Function

    Sub Tipo_Equipo()
        Cbo1.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "UNO", Txt2.Value, Now.ToShortDateString, Now)
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

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Tab1.Tabs("T01").Selected = True
    End Sub

    Public Sub Buscar()
        If Tipo = 0 Then
            Return
        End If
        xFormulario = "Depreciacion_Equipo"
        If String.IsNullOrEmpty(Txt3.Value) Then
            Dim Cantera As New FrmListarCantera

            Cantera.ShowDialog()
            Txt2.Text = Trim(Cantera.CODIGO & "")
            Txt3.Text = Trim(Cantera.CANTERA & "")
            Call Tipo_Equipo()
            Call Iniciar_DetalleCantera()

        ElseIf String.IsNullOrEmpty(Txt5.Value) Then
            Dim Equipo As New FrmListarActivo
            GLinea = Cbo1.Value
            GCantera = Txt2.Value
            Equipo.ShowDialog()
            xFormulario = ""
            GLinea = ""
            Txt4.Value = Trim(Equipo.CODIGO & "")
            If Trim(Equipo.ACTIVO & "") = "" Then
                Txt5.Value = Trim(Equipo.CODIGO & "")
            Else
                Txt5.Value = Trim(Equipo.ACTIVO & "")
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
        Txt8.EndUpdate()


        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto
        With Entidad.CanteraCosteo
            .Opcion = 3
            .ID = Txt1.Text
            .User = User_Sistema
            .CodCia = Companhia
            .Fecha = DateTime.Today
        End With
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.Resultado = Negocio.CanteraCosteo.EliminarCanteraDepreciacion(Entidad.CanteraCosteo)
        If Entidad.Resultado.Realizo Then
            Call Limpiar()
            Call Iniciar()
            Tipo = Operacion.Retorno
            Tab1.Tabs("T01").Selected = True
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
            .CodigoCantera = Txt2.Value
            .Cantera = Txt3.Value
            .Cod_Equipo = Txt4.Value
            .NombreEquipo = Txt5.Value
            .Importe = Txt6.Value
            .Archivo1 = Txt7.Value
            .Archivo2 = Txt8.Value
            .Archivo3 = Txt9.Value
            .Tipo = Cbo1.Value
            .Ano = Cbo2.Value
            .Moneda = Cbo3.Value
            .User = User_Sistema
            .CodCia = Companhia
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCanteraDepreciacion(Entidad.CanteraCosteo)
        If Entidad.Resultado.Realizo Then
            Call Limpiar()
            Call Iniciar()
            Tipo = Operacion.Retorno
            Tab1.Tabs("T01").Selected = True
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