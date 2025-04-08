Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Public Class FrmMFormulacionProyectado
    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Producto As List(Of ETProducto) = Nothing
    Private Ls_Ruma As List(Of ETRuma) = Nothing
    Private CodMineral As String = String.Empty
    Private Ope As Int32 = 0
    Private Sub FrmMFormulacionProyectado_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Public Sub Administrar_Permisos(ByVal FormParent As FrmBMain, _
                                Optional ByVal Operaciones As List(Of Integer) = Nothing, _
                                Optional ByVal Tipo As Boolean = False)

        If FormParent Is Nothing Then
            Return
        End If

        If Tipo = Boolean.TrueString Then
            For Each uBoton As Object In FormParent.tolMain.Tools
                If Mid(uBoton.Key, 1, 1) = "K" Then
                    uBoton.SharedProps.Enabled = Boolean.FalseString
                End If
            Next
            Return
        End If

        If Operaciones Is Nothing Then
            For Each uBoton As Object In FormParent.tolMain.Tools
                'If Mid(uBoton.Key, 1, 1) = "K" Then
                '    uBoton.SharedProps.Enabled = Boolean.TrueString
                'End If
                If IsNumeric(uBoton.Key) Then
                    uBoton.SharedProps.Enabled = Boolean.TrueString
                End If
            Next
        Else
            For Each uBoton As Object In FormParent.tolMain.Tools
                If IsNumeric(uBoton.Key) Then
                    uBoton.SharedProps.Enabled = Boolean.FalseString
                End If
                'If Mid(uBoton.Key, 1, 1) = "K" Then
                '    uBoton.SharedProps.Enabled = Boolean.FalseString
                'End If
            Next
            For Each Key As Integer In Operaciones
                FormParent.tolMain.Tools.Item(CStr(Key)).SharedProps.Enabled = Boolean.TrueString
            Next
        End If

        FormParent.Refresh()

    End Sub
    Private Sub FrmMFormulacionProyectado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Iniciar()
    End Sub
    Sub Procesar()
        frmAñoProceso.ShowDialog()
    End Sub
    Sub Actualizar()
        Iniciar()
    End Sub
    Sub Iniciar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Negocio.Producto = New NGProducto
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.Producto.ConsultarProdProyectado(Now.Date.Year)
        If Not Entidad.MyLista.Validacion Then Return
        Ls_Producto = New List(Of ETProducto)
        Ls_Producto = Entidad.MyLista.Ls_Producto
        Dim dtdatos As New DataTable
        dtdatos.Columns.Add("ID")
        dtdatos.Columns.Add("CodProducto")
        dtdatos.Columns.Add("Descripcion")
        dtdatos.Columns.Add("Estado")
        Dim dr As DataRow
        For i As Int32 = 0 To Ls_Producto.Count - 1
            dr = dtdatos.NewRow
            dr(0) = Ls_Producto.Item(i).ID
            dr(1) = Ls_Producto.Item(i).CodProducto
            dr(2) = Ls_Producto.Item(i).Descripcion
            dr(3) = Ls_Producto.Item(i).Estado
            dtdatos.Rows.Add(dr)
        Next
        Call CargarUltraGridxBinding(Grid1, Source1, dtdatos, "Descripcion")
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub


    Private Sub Grid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If e.Row.IsFilterRow Then Return

        Call Consultar_Formulacion(e.Row)

    End Sub

    Sub Consultar_Formulacion(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If
        Limpiar()
        txtcodigo.Text = uRow.Cells("CodProducto").Value
        txtproducto.Text = uRow.Cells("Descripcion").Value
        txtid.Text = uRow.Cells("ID").Value
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Grid2.DisplayLayout.Bands(0).Columns("Merma").CellActivation = Activation.AllowEdit
        Grid2.DisplayLayout.Bands(0).Columns("Humedad").CellActivation = Activation.AllowEdit
        Grid2.DisplayLayout.Bands(0).Columns("Porcentaje").CellActivation = Activation.AllowEdit
        Grid2.DisplayLayout.Bands(0).Columns("Seguridad").CellActivation = Activation.AllowEdit

        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto

        Entidad.Activo = New ETActivo
        Entidad.MyLista = New ETMyLista

        Entidad.Activo.CodEnlace = uRow.Cells("ID").Value
        Entidad.Activo.Anho = txtAño.Value
        Entidad.MyLista = Negocio.Producto.ListarFormulacionProyectada(uRow.Cells("ID").Value)

        If Not Entidad.MyLista.Validacion Then Return
        Ls_Ruma = Entidad.MyLista.Ls_Ruma
        Call CargarUltraGridxBinding(Grid2, Source2, Ls_Ruma, "")
    End Sub
    Sub modificar()
        Grid2.DisplayLayout.Bands(0).Columns("Merma").CellActivation = Activation.AllowEdit
        Grid2.DisplayLayout.Bands(0).Columns("Humedad").CellActivation = Activation.AllowEdit
        Grid2.DisplayLayout.Bands(0).Columns("Porcentaje").CellActivation = Activation.AllowEdit
        Grid2.DisplayLayout.Bands(0).Columns("Seguridad").CellActivation = Activation.AllowEdit
    End Sub
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "CodProducto" OrElse _
                    uColumn.Key = "Descripcion" OrElse uColumn.Key = "Estado") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        Grid1.PerformAction(ExitEditMode)
        StrucForm.FxCxMineralProyecion = New FrmCMineralProyecion
        AddHandler StrucForm.FxCxMineralProyecion.Closing, AddressOf Cargar_Mineral
        StrucForm.FxCxMineralProyecion.MdiParent = MdiParent
        StrucForm.FxCxMineralProyecion.L = Boolean.TrueString
        StrucForm.FxCxMineralProyecion.Show()
        StrucForm.FxCxMineralProyecion = Nothing
        Return
    End Sub
    Sub Cargar_Mineral(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        If Ls_Ruma Is Nothing Then Ls_Ruma = New List(Of ETRuma)

        For Each W As ETRuma In sender.Lista
            CodMineral = String.Empty : CodMineral = W.CodRuma
            If Not Ls_Ruma.Exists(AddressOf Existe_Mineral) Then Ls_Ruma.Add(W)
        Next

        Call CargarUltraGrid(Grid2, Ls_Ruma)

    End Sub

    Function Existe_Mineral(ByVal Rpt As ETRuma) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.CodRuma = CodMineral Then
            lResult = Boolean.TrueString
        End If

        Return lResult

    End Function

    Private Sub Grid2_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid2.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Merma" OrElse uColumn.Key = "Descripcion" OrElse _
                            uColumn.Key = "CodRuma" OrElse uColumn.Key = "Humedad" OrElse _
                            uColumn.Key = "Porcentaje" OrElse uColumn.Key = "Seguridad") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

    End Sub

    Private Sub Grid2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid2.KeyDown
        Try
            With sender
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode)
                        .PerformAction(AboveCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Down
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Right
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Left
                        .PerformAction(ExitEditMode)
                        .PerformAction(PrevCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Return
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        If Not VerificarControl(5, Grid2) Then
            MessageBox.Show("No tiene Minerales para Quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If Grid2.ActiveRow Is Nothing Then
            MessageBox.Show("No tiene una Mineral Seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Grid2.ActiveRow.Delete()
    End Sub

    Private Sub Grid2_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles Grid2.BeforeRowsDeleted
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        e.DisplayPromptMsg = Boolean.FalseString
    End Sub

    Public Sub Nuevo()
        'Ope = 1
        'Call Limpiar()
        'Tab1.Tabs("T02").Selected = Boolean.TrueString
    End Sub
    Sub Limpiar()
        txtcodigo.Value = String.Empty
        Ls_Ruma = New List(Of ETRuma)
        Call CargarUltraGrid(Grid2, Ls_Ruma)
        Tab1.Tabs("T01").Selected = Boolean.TrueString
        Grid2.DisplayLayout.Bands(0).Columns("Merma").CellActivation = Activation.ActivateOnly
        Grid2.DisplayLayout.Bands(0).Columns("Humedad").CellActivation = Activation.ActivateOnly
        Grid2.DisplayLayout.Bands(0).Columns("Porcentaje").CellActivation = Activation.ActivateOnly
        Grid2.DisplayLayout.Bands(0).Columns("Seguridad").CellActivation = Activation.ActivateOnly
    End Sub
    Sub Grabar()
        Try
            If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
            If txtcodigo.Text.ToString.Trim = "" Then
                MessageBox.Show("Debe seleccionar un Producto", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If Grid2.Rows.Count = 0 Then
                MessageBox.Show("Debe ingresar mínimo un mineral", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Entidad.Producto = New ETProducto
            Negocio.Producto = New NGProducto

            Entidad.Producto.ID = Val(txtid.Text)
            Entidad.Producto.CodProducto = txtcodigo.Text.Trim
            Entidad.Producto.Usuario = User_Sistema
            Entidad.Producto.Anho = txtAño.Value
            'MsgBox(Ls_Ruma.Item(1).Merma)
            Dim result As Integer
            result = Negocio.Producto.EliminaMineralProductoProyeccion(Entidad.Producto)
            If result = 0 Then Exit Sub
            Entidad.Producto = Negocio.Producto.MantenimientoMineralProductoProyeccion(Entidad.Producto, Ls_Ruma)
            If Entidad.Producto.Validacion = True Then
                Limpiar()
            End If
        Catch ex As Exception

        End Try

    End Sub
    Sub Eliminar()
        Try
            If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
            If txtcodigo.Text.ToString.Trim = "" Then
                MessageBox.Show("Debe seleccionar un Producto", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If Grid2.Rows.Count = 0 Then
                MessageBox.Show("Debe ingresar mínimo un mineral", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            Entidad.Producto = New ETProducto
            Negocio.Producto = New NGProducto

            Entidad.Producto.ID = Val(txtid.Text)
            Entidad.Producto.CodProducto = txtcodigo.Text.Trim
            Entidad.Producto.Usuario = User_Sistema
            Entidad.Producto.Anho = txtAño.Value
            Dim result As Integer
            If MsgBox("¿Seguro desea Eliminar los datos?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            result = Negocio.Producto.EliminaMineralProductoProyeccion(Entidad.Producto)
            If result = 0 Then Exit Sub
            MsgBox("Se Eliminaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            Limpiar()
        Catch ex As Exception

        End Try

    End Sub
    Sub cancelar()
        Limpiar()
    End Sub

    Sub Reporte()
        Negocio.Producto = New NGProducto
        Entidad.MyLista = New ETMyLista
        Dim dtReporte As New DataTable

        dtReporte = Negocio.Producto.Rpt_FormulacionProyectado()

        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try

            If dtReporte.Rows.Count > 0 Then
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Visible = True
                lblmensaje.Refresh()

                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\FORMULACIONESPROYECTADO.xls")
                File.Copy(RutaReporteERP & "PLANTILLAFORMULACIONESPROYECTADO.xls", path & "\FORMULACIONESPROYECTADO.xls")
                m_Excel.Workbooks.Open(path & "\FORMULACIONESPROYECTADO.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 5
                nfilaini = 5

                With objHojaExcel
                    .Activate()
                    .Range("A2").Value = "LISTADO DE FORMULACIONES"
                    .Range("A2").Font.Bold = True
                    Dim filaultima As Int32 = 0
                    For i As Int16 = 0 To dtReporte.Rows.Count - 1
                        .Range("A" & nfilaini + i).Value = dtReporte.Rows(i)("CODMINERAL")
                        .Range("B" & nfilaini + i).Value = dtReporte.Rows(i)("PRODVENTA")
                        .Range("C" & nfilaini + i).Value = dtReporte.Rows(i)("MINERAL")
                        .Range("D" & nfilaini + i).Value = dtReporte.Rows(i)("PORCENTAJE")
                        .Range("E" & nfilaini + i).Value = dtReporte.Rows(i)("HUMEDAD")
                        .Range("F" & nfilaini + i).Value = dtReporte.Rows(i)("MERMA")
                        .Range("G" & nfilaini + i).Value = dtReporte.Rows(i)("SEGURIDAD")
                        .Range(.Cells(nfilaini + i, 1), .Cells(nfilaini + i, 7)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nfila = nfila + 1
                        filaultima = 5 + i
                    Next
                    '.Range(.Cells(filaultima + 1, 3), .Cells(filaultima + 1, 3)).Value = "Total"
                    '.Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 4)).Formula = "=SUMA(D5:D" & filaultima & ")"
                    '.Range(.Cells(filaultima + 1, 3), .Cells(filaultima + 1, 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    '.Range(.Cells(filaultima + 1, 3), .Cells(filaultima + 1, 4)).Font.Bold = True
                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
End Class