Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmMHoraMaquina

#Region "Variables"
    Private Tipo As Int16 = 0
    Private Ls_HoraMaquina As List(Of ETCanteraCosteo) = Nothing
    Public Ls_Permisos As New List(Of Integer)
#End Region

#Region "Funciones Locales"

    Sub Limpiar()
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Txt3.Value = String.Empty
        Txt4.Value = String.Empty
        Txt5.Value = String.Empty
        Txt8.Value = 0
        Txt7.Value = 0
        Txt6.Value = 0
        Cbo1.Value = ""
        Cbo2.Value = "01"
        Cbo3.Value = "01"
        Call Iniciar_DetalleCantera()

        Ep1.Clear()
        Ep2.Clear()

    End Sub

    Sub Controles(ByVal xBol As Boolean)
        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        Txt2.ReadOnly = xBol
        Txt4.ReadOnly = xBol
        Txt6.ReadOnly = True
        Txt7.ReadOnly = xBol
        Txt8.ReadOnly = xBol
        Cbo1.ReadOnly = xBol
        Cbo2.ReadOnly = xBol
        dtFecha.ReadOnly = xBol

    End Sub

    Sub Iniciar()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Opcion = 2
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ListarCanteraHoraMaquina(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_HoraMaquina = New List(Of ETCanteraCosteo)
        Ls_HoraMaquina = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_HoraMaquina)

    End Sub

    Sub Iniciar_DetalleCantera()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .CodigoCantera = Txt2.Value
            .Opcion = 5
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ListarCanteraHoraMaquina(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_HoraMaquina = New List(Of ETCanteraCosteo)
        Ls_HoraMaquina = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGrid(Grid2, Ls_HoraMaquina)

    End Sub

    Sub Consultar_HoraMaquina(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If
        Tipo = Operacion.Retorno

        Txt1.Value = uRow.Cells("ID").Value
        Txt2.Value = uRow.Cells("CodigoCantera").Value
        Txt3.Value = uRow.Cells("Cantera").Value
        Cbo1.Value = uRow.Cells("Tipo").Value
        Txt4.Value = uRow.Cells("Cod_Equipo").Value
        Txt5.Value = uRow.Cells("NombreEquipo").Value
        Txt8.Value = uRow.Cells("Importe2").Value
        Txt7.Value = uRow.Cells("Importe").Value
        Txt6.Value = uRow.Cells("Hora").Value
        Cbo2.Value = uRow.Cells("Periodo").Value
        Cbo3.Value = uRow.Cells("TipoTrabajo").Value
        dtFecha.Value = uRow.Cells("Fecha").Value
        Call Iniciar_DetalleCantera()

        Tab1.Tabs("T02").Selected = Boolean.TrueString
    End Sub

    Function Verificar_Datos() As Boolean
        Dim Total_Horas As Double = 0
        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt3.Value) Then
            Ep1.SetError(Txt1, "Ingrese una Cantera")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt6.Value) Then
            Ep1.SetError(Txt6, "Ingrese una Cantidad")
            lResult = Boolean.FalseString
        End If

        If Cbo2.Value = "05" Then
            If Val(Txt6.Value) <= 0 Or Val(Txt6.Value) > 24 Then
                Ep1.SetError(Txt6, "Ingrese una Cantidad entre 0 y 24")
                lResult = Boolean.FalseString
            End If
        Else
            If Val(Txt7.Value) < 0 Then
                Ep1.SetError(Txt6, "Ingrese una Entrada mayor o igual a Cero")
                lResult = Boolean.FalseString
            End If
            If Val(Txt8.Value) <= 0 Then
                Ep1.SetError(Txt6, "Ingrese una Salida mayor a Cero")
                lResult = Boolean.FalseString
            End If
            If Val(Txt6.Value) <= 0 Then
                Ep1.SetError(Txt6, "Ingrese una Cantidad mayor a Cero")
                lResult = Boolean.FalseString
            End If
        End If


        If String.IsNullOrEmpty(Cbo2.Value) Then
            Ep1.SetError(Cbo2, "Seleccione el Tipo de Tareo")
            lResult = Boolean.FalseString
        End If


        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto
        With Entidad.CanteraCosteo
            .Opcion = 3
            .Fecha = dtFecha.Value
            If String.IsNullOrEmpty(Txt1.Value) Then
                .ID = String.Empty
            Else
                .ID = Txt1.Value
            End If
            .Periodo = Cbo2.Value
            .CodigoCantera = Txt2.Value
            .Cod_Equipo = Txt4.Value
        End With
        If Negocio.CanteraCosteo.ValidarCanteraHoraMaquina(Entidad.CanteraCosteo) = True Then
            Ep1.SetError(Txt4, "El equipo ya ha sido registrado")
            lResult = Boolean.FalseString
        End If

        With Entidad.CanteraCosteo
            .Opcion = 6
            If String.IsNullOrEmpty(Txt1.Value) Then
                .ID = String.Empty
            Else
                .ID = Txt1.Value
            End If
            .Fecha = dtFecha.Value
            .CodigoCantera = Txt2.Value
            .Cod_Equipo = Txt4.Value
            .Periodo = Cbo2.Value
        End With

        If Cbo2.Value = "05" Then
            Total_Horas = Negocio.CanteraCosteo.ValidarCanteraHoraMaquina_TotalHoras(Entidad.CanteraCosteo)
            If (Total_Horas + Val(Txt6.Value)) > 24 Then
                Total_Horas = 24 - Total_Horas
                If Total_Horas > 0 Then
                    Ep1.SetError(Txt6, "El acumulado excedio las 24 horas. Disponible: " & Total_Horas.ToString)
                Else
                    Ep1.SetError(Txt6, "El acumulado excedio las 24 horas")
                End If

                lResult = Boolean.FalseString
            End If
        End If


        Return lResult
    End Function

    Sub Tipo_Equipo()
        Cbo1.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "UNO", Txt2.Value, dtFecha.Value, Now)
        Cbo1.ValueMember = "Codigo"
        Cbo1.DisplayMember = "Descripcion"
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
        Txt8.EndUpdate()

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
            .Importe = Txt7.Value
            .Importe2 = Txt8.Value
            .User = User_Sistema
            .Fecha = dtFecha.Value
            .Tipo = Cbo1.Value
            .Periodo = Cbo2.Value
            .TipoTrabajo = Cbo3.Value
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoCanteraHoraMaquina(Entidad.CanteraCosteo)

        If Entidad.Resultado.Realizo Then
            Call Iniciar()
            Call Limpiar()
            Tab1.Tabs("T01").Selected = True
            Tipo = Operacion.Retorno
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Buscar()
        xFormulario = "HoraMaquina"
        If String.IsNullOrEmpty(Txt3.Text) Then
            Dim Cantera As New FrmListarCantera
            Cantera.FECHA = dtFecha.Value
            Cantera.ShowDialog()
            Txt2.Text = Cantera.CODIGO
            Txt3.Text = Cantera.CANTERA
            Cantera = Nothing
            If String.IsNullOrEmpty(Txt2.Text.Trim) Then
                If Not (Tipo = Operacion.Retorno) Then
                    dtFecha.ReadOnly = False
                End If
            Else
                dtFecha.ReadOnly = True
            End If

            xFormulario = String.Empty
            Call Tipo_Equipo()
            Call Iniciar_DetalleCantera()

            Return
        End If

        If String.IsNullOrEmpty(Txt5.Text) Then
            Dim Equipo As New FrmListarActivo
            gCantera = Trim(Txt2.Text & "")
            GLinea = Cbo1.Value
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

        Entidad.Resultado = Negocio.CanteraCosteo.EliminarCanteraHoraMaquina(Entidad.CanteraCosteo)

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

        If Ls_HoraMaquina IsNot Nothing Then Ls_HoraMaquina = Nothing

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout, Grid2.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "ID" Or uColumn.Key = "CodigoCantera" Or _
                        uColumn.Key = "Cantera" Or uColumn.Key = "NombreEquipo" _
                        Or uColumn.Key = "Hora" Or uColumn.Key = "Fecha" Or _
                        uColumn.Key = "Cod_Equipo" Or uColumn.Key = "NombreTipoTrabajo") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.CellActivation = Activation.ActivateOnly
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                'If Not (uColumn.Key = "Cod_Equipo" Or uColumn.Key = "NombreTipo" Or _
                If Not (uColumn.Key = "ID" Or uColumn.Key = "Cod_Equipo" Or uColumn.Key = "NombreTipo" Or _
                        uColumn.Key = "NombreEquipo" Or uColumn.Key = "Hora" Or uColumn.Key = "Fecha" Or uColumn.Key = "NombreTipoTrabajo") Then
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
        dtFecha.Value = Now

        Cbo2.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "TTE", "", Now.ToShortDateString, Now)
        Cbo2.ValueMember = "Codigo"
        Cbo2.DisplayMember = "Descripcion"


    End Sub

    Sub DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow, _
                                                                                                                                Grid2.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If e.Row.IsFilterRow Then Return

        Call Consultar_HoraMaquina(e.Row)

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
                Txt5.Clear()
                Txt4.Clear()
                If Cbo1.Items.Count > 0 Then Cbo1.Value = ""

            End If

            If sender Is Txt4 Then

                Txt5.Clear()
                Txt4.Clear()
            End If
        End If

        Call Iniciar_DetalleCantera()
    End Sub

    Sub Combo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo1.ValueChanged
        Txt5.Clear()
        Txt4.Clear()
    End Sub


#End Region


    Private Sub Txt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt7.ValueChanged, Txt8.ValueChanged

        If Txt8.Value IsNot Nothing And IsDBNull(Txt8.Value) = False And _
        Txt7.Value IsNot Nothing And IsDBNull(Txt7.Value) = False Then
            If Not (Cbo2.Value = "06") Then
                Txt6.Value = Txt8.Value - Txt7.Value
            Else
                Txt6.Value = 0
            End If

        Else
            Txt6.Value = 0
        End If

    End Sub


    Private Sub Cbo2_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo2.ValueChanged
        If Tipo = Operacion.Nuevo Or Tipo = Operacion.Modificar Then
            If Cbo2.Value = "06" Then
                Txt6.ReadOnly = False
                Txt6.SelectAll()
                Txt6.Focus()
            Else
                Txt_ValueChanged(sender, e)
                Txt6.ReadOnly = True
            End If
        Else
            Txt6.ReadOnly = True
        End If
    End Sub

    Private Sub Cbo2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo2.InitializeLayout

    End Sub
End Class