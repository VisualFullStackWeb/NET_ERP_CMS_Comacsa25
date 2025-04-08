Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmDisponibilidadEquipoCantera
#Region "Variables"
    Public Ls_Permisos As New List(Of Integer)
    Private Tipo As Int16 = 0
    Private Ls_DisponibEquipoCantera As List(Of ETCanteraCosteo) = Nothing
    Private Ls_DisponibEquipoCantera_Det As List(Of ETCanteraCosteo) = Nothing
#End Region
#Region "Funciones Locales"

    Sub Limpiar()
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Txt3.Value = String.Empty
        Txt4.Value = String.Empty
        Txt5.Value = String.Empty
        Txt6.Value = 0
        Cbo3.Value = ""
        Cbo4.Value = "01"
        Call LlenarAnio(Cbo1, 2010, Date.Now.Year)
        Cbo1.Value = Date.Now.Year
        Call LlenarMeses(Cbo2, Cbo1.Value, Date.Now.Month)
        Cbo2.Value = Date.Now.Month

        Ep1.Clear()
        Ep2.Clear()

        Ls_DisponibEquipoCantera_Det = Nothing
        Ls_DisponibEquipoCantera_Det = New List(Of ETCanteraCosteo)
        Call CargarUltraGrid(Grid2, Ls_DisponibEquipoCantera_Det)
    End Sub

    Sub Controles(ByVal xBol As Boolean)
        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        Txt2.ReadOnly = xBol
        Txt4.ReadOnly = xBol
        Txt6.ReadOnly = xBol
        Cbo1.ReadOnly = xBol
        Cbo2.ReadOnly = xBol
        Cbo3.ReadOnly = xBol
        Cbo4.ReadOnly = xBol
    End Sub

    Function Verificar_Datos() As Boolean
        Dim Total_Horas As Double = 0
        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Cbo1.Value) Then
            Ep1.SetError(Cbo1, "Seleccionar el Año")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo2.Value) Then
            Ep1.SetError(Cbo2, "Seleccionar el Mes")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt3.Value) Then
            Ep1.SetError(Txt3, "Ingrese una Cantera")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt5.Value) Then
            Ep1.SetError(Txt5, "Ingrese un Equipo")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo3.Value) Then
            Ep1.SetError(Cbo3, "Seleccione el Tipo de Equipo")
            lResult = Boolean.FalseString
        End If

        If Val(Txt6.Value) <= 0 Then
            Ep1.SetError(Txt6, "Ingresar una disponilidad")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Cbo4.Value) Then
            Ep1.SetError(Cbo4, "Seleccione el Tipo de Disponilidad")
            lResult = Boolean.FalseString
        End If

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto
        With Entidad.CanteraCosteo
            .Opcion = 3
            If String.IsNullOrEmpty(Txt1.Value) Then
                .ID = String.Empty
            Else
                .ID = Txt1.Value
            End If
            .Ano = Cbo1.Value
            .Mes = Cbo2.Value
            .CodigoCantera = Txt2.Value
            .Cod_Equipo = Txt4.Value
        End With

        If Negocio.CanteraCosteo.ValidarCanteraHoraDisponibleMaquina(Entidad.CanteraCosteo) = True Then
            Ep1.SetError(Txt4, "El equipo ya ha sido registrado")
            lResult = Boolean.FalseString
        End If

        Return lResult
    End Function

    Sub Tipo_Equipo(ByVal FechaInicio As Date, ByVal FechaTermino As DateTime)
        Cbo3.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "DOS", Txt2.Value, FechaInicio, FechaTermino)
        Cbo3.ValueMember = "Codigo"
        Cbo3.DisplayMember = "Descripcion"
    End Sub

    Sub Iniciar()
        Call Limpiar()
        Call Controles(True)

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Opcion = 2
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ListarCanteraHoraDisponibleMaquina(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_DisponibEquipoCantera = New List(Of ETCanteraCosteo)
        Ls_DisponibEquipoCantera = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_DisponibEquipoCantera)

    End Sub

    Sub Iniciar_DetalleCantera()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .CodigoCantera = Txt2.Value
            .Opcion = 5
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ListarCanteraHoraDisponibleMaquina(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_DisponibEquipoCantera_Det = Nothing
        Ls_DisponibEquipoCantera_Det = New List(Of ETCanteraCosteo)
        Ls_DisponibEquipoCantera_Det = Entidad.MyLista.Ls_CanteraCosteo
        Call CargarUltraGrid(Grid2, Ls_DisponibEquipoCantera_Det)

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

        If Not VerificarControl(1, Txt1) Then
            MessageBox.Show("No existe datos para modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Tipo = Operacion.Modificar

        Call Controles(Boolean.FalseString)

    End Sub

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
       
        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Tab1.Tabs("T01").Selected = True
    End Sub

    Public Sub Cancelar()
        Call Actualizar()
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

        If Verificar_Datos() = False Then Return

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto

        With Entidad.CanteraCosteo
            .Opcion = 1
            .ID = Txt1.Value
            .CodigoCantera = Txt2.Value
            .Cantera = Txt3.Value
            .Cod_Equipo = Txt4.Value
            .NombreEquipo = Txt5.Value
            .Hora = Txt6.Value
            .User = User_Sistema
            .Tipo = Cbo3.Value
            .Periodo = Cbo4.Value
            .Ano = Cbo1.Value
            .Mes = Cbo2.Value
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCanteraHoraDisponibleMaquina(Entidad.CanteraCosteo)

        If Entidad.Resultado.Realizo Then
            Call Iniciar()
            Tab1.Tabs("T01").Selected = True
            Tipo = Operacion.Retorno
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Buscar()
        Dim FechaInicio As DateTime
        Dim FechaTermino As DateTime
        Dim Cadena As String = String.Empty

        If String.IsNullOrEmpty(Cbo2.Value) Then
            MsgBox("Seleccionar el Mes", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        Cadena = "01/" & Mid(("0" & Cbo2.Value.ToString.TrimEnd), 2, 2) & "/" & Cbo1.Value.ToString.TrimEnd
        FechaInicio = CDate(Cadena)
        FechaTermino = DateAdd(DateInterval.Second, -1, DateAdd(DateInterval.Month, 1, FechaInicio))
        xFormulario = "HoraDisponibleMaquina"
        If String.IsNullOrEmpty(Txt3.Text) Then
            Dim Cantera As New FrmListarCantera
            Cantera.FECHA = FechaInicio
            Cantera.FECHATERMINO = FechaTermino
            Cantera.ShowDialog()
            Txt2.Text = Cantera.CODIGO
            Txt3.Text = Cantera.CANTERA
            Cantera = Nothing
            If String.IsNullOrEmpty(Txt2.Text.Trim) Then
                If Not (Tipo = Operacion.Retorno) Then
                    Cbo1.ReadOnly = False
                    Cbo2.ReadOnly = False
                End If
            Else
                Cbo1.ReadOnly = True
                Cbo2.ReadOnly = True
            End If

            xFormulario = String.Empty
            Call Tipo_Equipo(FechaInicio, FechaTermino)
            Call Iniciar_DetalleCantera()

            Return
        End If

        If String.IsNullOrEmpty(Txt5.Text) Then
            Dim Equipo As New FrmListarActivo
            GCantera = Trim(Txt2.Text & "")
            GLinea = Cbo3.Value
            Equipo.FECHAINICIO = FechaInicio
            Equipo.FECHATERMINO = FechaTermino
            Equipo.ShowDialog()
            Txt4.Text = Equipo.CODIGO
            Txt5.Text = Equipo.ACTIVO
            Equipo = Nothing
            xFormulario = String.Empty
        End If
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
            .Opcion = 4
            .ID = Txt1.Value
            .User = User_Sistema
            .Fecha = Now
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.EliminarCanteraHoraDisponibleMaquina(Entidad.CanteraCosteo)

        If Entidad.Resultado.Realizo Then
            Call Iniciar()
            Tab1.Tabs("T01").Selected = True
            Tipo = Operacion.Retorno
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region




    Private Sub FrmDisponibilidadEquipoCantera_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub FrmDisponibilidadEquipoCantera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia)
        Cbo4.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "TTE", "", Now.ToShortDateString, Now)
        Cbo4.ValueMember = "Codigo"
        Cbo4.DisplayMember = "Descripcion"
        Call LlenarAnio(Cbo1, 2010, Date.Now.Year)
        Cbo1.Value = Date.Now.Year
        Call LlenarMeses(Cbo2, Cbo1.Value, Date.Now.Month)
        Cbo2.Value = Date.Now.Month
        Call Iniciar()
    End Sub

    Private Sub Cbo1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo1.ValueChanged
        Call LlenarMeses(Cbo2, Cbo1.Value, Date.Now.Month)
        Txt5.Clear()
        Txt4.Clear()
        Txt3.Clear()
        Txt2.Clear()
    End Sub

    Private Sub Cbo2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo2.ValueChanged
        Txt5.Clear()
        Txt4.Clear()
        Txt3.Clear()
        Txt2.Clear()
    End Sub

    Private Sub Txt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt2.ValueChanged, Txt4.ValueChanged
        If sender Is Txt2 Then
            If String.IsNullOrEmpty(Txt2.Text.TrimEnd) Then
                Txt3.Clear()
            End If
        End If

        If sender Is Txt4 Then
            If String.IsNullOrEmpty(Txt4.Text.TrimEnd) Then
                Txt5.Clear()
            End If
        End If
    End Sub

    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout
        If e Is Nothing Then
            Exit Sub
        End If

        If sender Is Grid1 Then
            For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
                For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                    If Not (uColumn.Key = "ID" Or uColumn.Key = "CodigoCantera" Or _
                            uColumn.Key = "Cantera" Or uColumn.Key = "Cod_Equipo" Or _
                           uColumn.Key = "NombreTipo" Or uColumn.Key = "NombreEquipo" _
                           Or uColumn.Key = "Hora" Or uColumn.Key = "Ano" Or uColumn.Key = "MesName") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.CellActivation = Activation.ActivateOnly
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            Next
        End If

        If sender Is Grid2 Then
            For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
                For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                    If Not (uColumn.Key = "ID" Or uColumn.Key = "Cod_Equipo" Or _
                           uColumn.Key = "NombreTipo" Or uColumn.Key = "NombreEquipo" _
                           Or uColumn.Key = "Hora") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            Next
        End If

    End Sub

    Sub DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow, _
                                                                                                                            Grid2.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If e.Row.IsFilterRow Then Return

        Call Consultar_HoraDisponibleMaquina(e.Row)

    End Sub

    Sub Consultar_HoraDisponibleMaquina(ByVal uRow As UltraGridRow)

        Dim xAnio As Integer
        Dim xMes As Integer
        If uRow Is Nothing Then
            Return
        End If

        Txt1.Value = uRow.Cells("ID").Value
        xAnio = uRow.Cells("Ano").Value
        xMes = uRow.Cells("Mes").Value
        Call LlenarAnio(Cbo1, 2010, Year(Date.Now))
        Cbo1.Value = xAnio
        Call LlenarMeses(Cbo2, Cbo1.Value, Date.Now.Month)
        Cbo2.Value = xMes
        Txt2.Value = uRow.Cells("CodigoCantera").Value
        Txt3.Value = uRow.Cells("Cantera").Value
        Cbo3.Value = uRow.Cells("Tipo").Value
        Txt4.Value = uRow.Cells("Cod_Equipo").Value
        Txt5.Value = uRow.Cells("NombreEquipo").Value
        Txt6.Value = uRow.Cells("Hora").Value
        Cbo4.Value = uRow.Cells("Periodo").Value
        Call Iniciar_DetalleCantera()

        Tab1.Tabs("T02").Selected = Boolean.TrueString
    End Sub


End Class