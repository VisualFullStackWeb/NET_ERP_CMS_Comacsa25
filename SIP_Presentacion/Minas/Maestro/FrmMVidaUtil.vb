Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmMVidaUtil

#Region "Variables"
    Private Tipo As Int16 = 0
    Private Ls_VidaUtil As List(Of ETCanteraCosteo) = Nothing
    Private Ls_Producto As New List(Of ETCanteraCosteo)
    Private Prod As New ETCanteraCosteo
    Public Ls_Permisos As New List(Of Integer)
#End Region

#Region "Funciones Locales"

    Private Sub ListarLinea(ByVal Opcion1 As String, ByVal Opcion2 As String, ByVal Opcion3 As String)

        Cbo1.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", Opcion1, "", Now.ToShortDateString, Now)
        Cbo1.ValueMember = "Codigo"
        Cbo1.DisplayMember = "Linea"
        Cbo1.Value = "011"
        Cbo1.ReadOnly = False

        Cbo2.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, Cbo1.Value, "", "", Opcion2, "", Now.ToShortDateString, Now)
        Cbo2.ValueMember = "Codigo"
        Cbo2.DisplayMember = "SubLinea"

        Cbo3.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", Opcion3, "", Now.ToShortDateString, Now)
        Cbo3.ValueMember = "Codigo"
        Cbo3.DisplayMember = "Descripcion"

    End Sub

    Sub Controles(ByVal xBol As Boolean)

        Txt1.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        Txt3.ReadOnly = xBol
        Cbo2.ReadOnly = xBol
        Cbo3.ReadOnly = xBol

    End Sub

    Sub Limpiar()
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Cbo1.Value = 0
        Cbo2.Value = 0
        Cbo3.Value = 0
        Ls_VidaUtil = New List(Of ETCanteraCosteo)
        Grid1.DataSource = Ls_VidaUtil
        Ep1.Clear()
        Ep2.Clear()
        Txt3.Value = 0
    End Sub

    Function Verificar_Datos() As Boolean

        Ep1.Clear()
        Ep2.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If String.IsNullOrEmpty(Txt2.Value) Then
            Ep1.SetError(Txt1, "Ingrese una Cantera")
            lResult = Boolean.FalseString
        End If

        Return lResult

    End Function

#End Region

#Region "Eventos"

    Sub _Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia)
    End Sub

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

        If Ls_VidaUtil IsNot Nothing Then Ls_VidaUtil = Nothing

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then

            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "CodProd" Or uColumn.Key = "Descripcion" Or _
                        uColumn.Key = "UM" Or uColumn.Key = "Action" Or _
                        uColumn.Key = "Periodo" Or uColumn.Key = "NumeroPeriodo") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If


    End Sub

    Sub _KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt1.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If (e.KeyCode) = 8 Or (e.KeyCode) = 46 Then
            If sender Is Txt1 Then
                Txt2.Clear()
                Ls_VidaUtil = New List(Of ETCanteraCosteo)
                Grid1.DataSource = Ls_VidaUtil
            End If
        End If
    End Sub

    Private Sub Combo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo1.ValueChanged
        Cbo2.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, Cbo1.Value, "", "", "LSL", "", Now.ToShortDateString, Now)
        Cbo2.ValueMember = "Codigo"
        Cbo2.DisplayMember = "SubLinea"
    End Sub
#End Region

#Region "Funciones Globales"

    Public Sub Buscar()
        If Txt1.ReadOnly = True Then Return

        Dim Cantera As New FrmListarCantera
        gEmpleo = ""
        Cantera.ShowDialog()
        Txt1.Text = Cantera.CODIGO
        Txt2.Text = Cantera.CANTERA
        If Not String.IsNullOrEmpty(Txt2.Text) Then
            Call ListarLinea("LLI", "LSL", "LTL")
        End If
    End Sub

    Public Sub Procesar()

        If Tipo = Operacion.Retorno Then
            MessageBox.Show(Mensaje.Seleccion_3, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Linea = Cbo1.Value
            .SubLinea = Cbo2.Value
            .Cantera = Txt1.Value

            If Cbo2.Value > 0 Then
                .Opcion = 2
            Else
                .Opcion = 1
            End If

        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ListarCanteraVidaUtilEquipo(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_VidaUtil = New List(Of ETCanteraCosteo)
        Ls_VidaUtil = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_VidaUtil)

    End Sub

    Public Sub Modificar()

        If Tab1.SelectedTab.Key <> "T02" Then Return

        If Not VerificarControl(1, Txt1) Then
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

    Public Sub Nuevo()
        Tipo = Operacion.Nuevo
        Call Limpiar()
        Call Controles(Boolean.FalseString)
    End Sub

    Public Sub Grabar()

        If Tipo = Operacion.Retorno Then
            MessageBox.Show(Mensaje.Seleccion_3, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If Not Verificar_Datos() Then
            MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Cbo1.EndUpdate()
        Cbo2.EndUpdate()
        Cbo3.EndUpdate()

        Txt1.EndUpdate()
        Txt2.EndUpdate()
        Txt3.EndUpdate()
        Grid1.UpdateData()

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto
        Ls_Producto = New List(Of ETCanteraCosteo)

        For i As Integer = 0 To Grid1.Rows.Count - 1

            If Grid1.Rows(i).Cells("Action").Value = True Then
                Prod = New ETCanteraCosteo
                With Prod
                    .CodProd = Grid1.Rows(i).Cells("CodProd").Value
                    .Opcion = 1
                    .CodigoCantera = Txt1.Value
                    .Cantera = Txt2.Value
                    .NumeroPeriodo = Txt3.Value
                    .Periodo = Cbo3.Value
                    .User = User_Sistema
                End With
                Ls_Producto.Add(Prod)
            End If
        Next


        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoVidaUtil(Ls_Producto)

        If Entidad.Resultado.Realizo Then

            Call Limpiar()
            Tab1.Tabs("T01").Selected = True
            Call Cancelar()
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

#End Region

End Class