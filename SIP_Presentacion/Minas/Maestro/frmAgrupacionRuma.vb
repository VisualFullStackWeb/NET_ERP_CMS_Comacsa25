Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmAgrupacionRuma
#Region "Variables"
    Public Ls_Permisos As New List(Of Integer)
    Private Tipo As Int16 = 0
    Private Ls_DisponibEquipoCantera As List(Of ETCanteraCosteo) = Nothing
    Private Ls_DisponibEquipoCantera_Det As List(Of ETCanteraCosteo) = Nothing
#End Region
    Sub Procesar(ByVal TIPO As Int32, ByVal CODAGRUPACION As String, ByVal Grilla As UltraGrid, ByVal Source As BindingSource)
        Dim dtAgrupacion As New DataTable
        Dim dtRumaAgrupacion As New DataTable
        dtAgrupacion = Negocio.Activo.ListarAgrupacion(TIPO, CODAGRUPACION)
        Call CargarUltraGridxBinding(Grilla, Source, dtAgrupacion)
    End Sub

    Private Sub frmAgrupacionRuma_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub frmAgrupacionRuma_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'txtAño.Value = Convert.ToInt32(Year(Now.Date))
        'Me.cmbMes.Value = Month(Now.Date)
        Procesar(1, "", Me.GridAgrupacion, Source1)
    End Sub
    Sub Nuevo()
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Limpiar()
        Procesar(2, "", Me.GridRumas, Source2)
    End Sub
    Sub Limpiar()
        txtagrupacion.Clear()
        txtagrupacion.Focus()
        txtid.Text = 0
    End Sub

    Private Sub GridAgrupacion_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridAgrupacion.DoubleClickRow
        Try
            Tab1.Tabs("T02").Selected = Boolean.TrueString
            Dim cod_agrupacion As String = String.Empty
            cod_agrupacion = Me.GridAgrupacion.ActiveRow.Cells("CODAGRUPACION").Value
            txtid.Text = Me.GridAgrupacion.ActiveRow.Cells("ID").Value
            txtagrupacion.Text = Me.GridAgrupacion.ActiveRow.Cells("DESCRIPCION").Value
            Procesar(2, cod_agrupacion, Me.GridRumas, Source2)
        Catch ex As Exception

        End Try
    End Sub

    Sub Cancelar()
        Tab1.Tabs("T01").Selected = Boolean.TrueString
        Limpiar()
    End Sub
    Sub Actualizar()
        Procesar(1, "", Me.GridAgrupacion, Source1)
        Procesar(2, "", Me.GridRumas, Source2)
        Tab1.Tabs("T01").Selected = Boolean.TrueString
        Limpiar()
    End Sub

    Sub Grabar()
        If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Return
        If txtagrupacion.Text.Trim = "" Then
            MsgBox("Ingrese nombre de agrupación", MsgBoxStyle.Exclamation, msgComacsa)
            txtagrupacion.Focus()
            Exit Sub
        End If
        'If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        '    Return
        'Else
        Try
            Entidad.CanteraCosteo = New ETCanteraCosteo
            Negocio.CanteraCosteo = New NGCanteraCosteo
            Entidad.Objecto = New ETObjecto

            With Entidad.CanteraCosteo
                .Opcion = 1
                .ID = txtid.Text
                .Descripcion = txtagrupacion.Text
                .User = User_Sistema
            End With
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

            Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoAgrupacion(Entidad.CanteraCosteo, 1)
            If Entidad.Resultado.Realizo = False Then Exit Sub
            Dim cod_Agrupacion As String = Entidad.Resultado.CodAgrupacion
            'MsgBox(cod_Agrupacion)
            GridRumas.PerformAction(ExitEditMode)
            For i As Int32 = 0 To GridRumas.Rows.Count - 1
                Entidad.CanteraCosteo = New ETCanteraCosteo
                Negocio.CanteraCosteo = New NGCanteraCosteo
                Entidad.Objecto = New ETObjecto
                'MsgBox(GridRumas.Rows(i).Cells("ACTION").Value)
                With Entidad.CanteraCosteo
                    .Opcion = 1
                    .ID = txtid.Text
                    .Descripcion = txtagrupacion.Text
                    .User = User_Sistema
                    .check = GridRumas.Rows(i).Cells("ACTION").Value
                    .codagrupacion = cod_Agrupacion
                    .codruma = GridRumas.Rows(i).Cells("CODRUMA").Value
                End With
                Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoAgrupacionRuma(Entidad.CanteraCosteo, 1)
            Next
            If Entidad.Resultado.Realizo Then
                Dim Mensaje As String = "Se guardó con éxito el registro"
                MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
                Call Procesar(1, "", Me.GridAgrupacion, Source1)
                Call Cancelar()
                Call Limpiar()
                Tab1.Tabs("T01").Selected = True
                Tipo = Operacion.Retorno
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, msgComacsa)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

        'End If
    End Sub
End Class