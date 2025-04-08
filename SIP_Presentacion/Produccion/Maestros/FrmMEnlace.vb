Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmMEnlace

#Region "Declaraciones"
    Private Ope As Int32 = 0
    Private vCargar = Boolean.TrueString
    Private Ls_Activo As List(Of ETActivo) = Nothing
    Private Ls_Producto As List(Of ETProducto) = Nothing
    Private Ls_Ruma As List(Of ETRuma) = Nothing
    Private Ls_RumaProd As List(Of ETRuma) = Nothing
    Private Ls_RumaSuministro As List(Of ETRuma) = Nothing
    Private CodRuma As String = String.Empty
    Private CodProducto As String = String.Empty
    Private Descripcion As String = String.Empty
    Private ID As Int32 = 0
    Private MdiOperaciones As List(Of String) = Nothing
    Private MaxPorcentaje As Decimal = Decimal.Zero

    Private Enum Filtro
        Enlace = 1
        Codigo = 2
        Descripcion = 3
        Emision = 4
    End Enum

#End Region

#Region "Eventos"

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                         Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
                          Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Activo IsNot Nothing Then Ls_Activo = Nothing
        If Ls_Producto IsNot Nothing Then Ls_Producto = Nothing
        If Ls_Ruma IsNot Nothing Then Ls_Ruma = Nothing
        If Ls_RumaProd IsNot Nothing Then Ls_RumaProd = Nothing
        If Ls_RumaSuministro IsNot Nothing Then Ls_RumaSuministro = Nothing
        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_HelpRequested(ByVal sender As Object, ByVal hlpevent As HelpEventArgs) _
                             Handles Me.HelpRequested

        If sender Is Nothing OrElse hlpevent Is Nothing Then
            Return
        End If

        StrucForm.FxBxAyuda = New FrmBAyuda
        StrucForm.FxBxAyuda.Formulario = Tag.ToString
        StrucForm.FxBxAyuda.ShowDialog()

    End Sub


    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) _
                    Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        Me.cmbMes.SelectedIndex = 0
        Call Iniciar()

    End Sub

    Sub Evento_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles _
                     Me.Shown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call ScrollLabel(Lbl1)

        Call Configurar_Formulario()


    End Sub

    Public Ls_Permisos As New List(Of Integer)


    Sub Evento_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) _
                             Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If e.Row.IsFilterRow Then Return

        Call Consultar_Enlace(e.Row)

    End Sub

    Private Sub Grid1_Error(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ErrorEventArgs) Handles Grid1.Error
        If e.ErrorType = ErrorType.Data Then
            ' DataErroInfo object contains details regarding the data error.

            ' ErrorText property contains the error message.
            Debug.WriteLine("Data Error: Error text = " & e.DataErrorInfo.ErrorText)

            ' Exception property will contain the exception that caused the Error event to fire.
            ' It will be null if there was no exception.
            If Not Nothing Is e.DataErrorInfo.Exception Then
                Debug.WriteLine("Data Error: Exception type = " & e.DataErrorInfo.Exception.GetType().Name)
            Else
                Debug.WriteLine("Data Error: No Exception.")
            End If

            ' Cell returns the cell involved in the data error. It will be null for errors generated
            ' when performing operations like adding or deleting rows or operations that do not
            ' deal with a cell.
            If Not Nothing Is e.DataErrorInfo.Cell Then
                Debug.WriteLine("DataError: Cell's column key = " & e.DataErrorInfo.Cell.Column.Key)
            Else
                Debug.WriteLine("DataError: No cell.")
            End If

            ' Row returns the row involved in the data error. It will be null if error occurred while
            ' doing an operation that did not involve a row.
            If Not Nothing Is e.DataErrorInfo.Row Then
                Debug.WriteLine("DataError: Index of the row involved = " & e.DataErrorInfo.Row.Index)
            Else
                Debug.WriteLine("DataError: No row.")
            End If

            ' Source property indicates how the data error was generated.
            Debug.Write("DataError: Source of the error is ")
            Select Case (e.DataErrorInfo.Source)
                Case DataErrorSource.CellUpdate
                    If Nothing Is e.DataErrorInfo.InvalidValue Then
                        Debug.WriteLine("Cell updating.")
                    Else
                        Debug.WriteLine("Cell updating with invalid value of " & e.DataErrorInfo.InvalidValue.ToString())
                    End If
                Case DataErrorSource.RowAdd
                    Debug.WriteLine("Row adding.")
                Case DataErrorSource.RowDelete
                    Debug.WriteLine("Row deleting.")
                Case DataErrorSource.RowUpdate
                    Debug.WriteLine("Row updating.")
                Case DataErrorSource.Unspecified
                    Debug.WriteLine("Unknown.")
            End Select

            ' Set the cancel to true to prevent the grid from displaying a message for
            ' this error. Instead we will display our own message box below.
            e.Cancel = True

            'MessageBox.Show(Me, _
            ' "Please enter a valid value for the cell." & vbCrLf & "Data error defatils:" & e.ErrorText, _
            ' "Invalid input", _
            ' MessageBoxButtons.OK, _
            ' MessageBoxIcon.Error)

        ElseIf e.ErrorType = ErrorType.Mask Then
            ' MaskErroInfo property contains the detaisl regarding the mask error.

            ' InvalidText is the text in the cell that doesn't satisfy the mask input.
            Debug.WriteLine("Mask Error: Invalid text = " & e.MaskErrorInfo.InvalidText)

            ' StartPos may indicate the position in the text that caused the mask input
            ' verification failed.
            Debug.WriteLine("Mask Error: Character position = " & e.MaskErrorInfo.StartPos)

            ' Prevent the UltraGrid from beeping whenever the user types in a
            ' character that doesn't match the mask as well as for other mask
            ' related errors.
            e.MaskErrorInfo.CancelBeep = True
        Else
            ' Set the cancel to true to prevent the grid from displaying the message
            ' for this error.
            e.Cancel = True
            Debug.WriteLine("Unknown error occured with the error message of: " & e.ErrorText)
        End If


    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout, Grid2.InitializeLayout, Grid3.InitializeLayout, Grid4.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Grid1 OrElse sender Is Grid2 OrElse sender Is Grid3 OrElse sender Is Grid4) Then Return

        If sender Is Grid1 Then
            Call Producto_InitializeLayout(e) : Return
        End If

        If sender Is Grid2 Then

            If Tag = StrucToolTag.Nulo Then Return

            If Tag = StrucToolTag.MProductoxUnidad Then
                Call Unidad_InitializeLayout(e) : Return
            End If

            If Tag = StrucToolTag.MProductoRuma OrElse Tag = StrucToolTag.MFormula Then
                Call Ruma_InitializeLayout(e) : Return
            End If

        End If

        If sender Is Grid3 Then

            If Tag = StrucToolTag.Nulo Then Return

            If Tag = StrucToolTag.MProductoRuma OrElse Tag = StrucToolTag.MFormula Then
                Call ProductoTerminado_InitializeLayout(e) : Return
            End If

        End If

        If sender Is Grid4 Then

            If Tag = StrucToolTag.Nulo Then Return

            If Tag = StrucToolTag.MProductoRuma OrElse Tag = StrucToolTag.MFormula Then
                Call ProductoTerminado_InitializeLayout(e) : Return
            End If

        End If
    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) _
                       Handles Num1.KeyDown, Txt4.KeyDown, Txt5.KeyDown, _
                               Dt3.KeyDown, Dt4.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If e.KeyValue <> Keys.Enter Then Return

        If sender Is Num1 Then
            Call Filtrar_Busqueda(Filtro.Enlace)
            Return
        End If

        If sender Is Txt4 Then
            Call Filtrar_Busqueda(Filtro.Codigo)
            Return
        End If

        If sender Is Txt5 Then
            Call Filtrar_Busqueda(Filtro.Descripcion)
            Return
        End If

        If sender Is Dt3 OrElse sender Is Dt4 Then
            Call Filtrar_Busqueda(Filtro.Emision)
            Return
        End If

    End Sub

    Sub Evento_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) _
                        Handles Txt4.KeyPress

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Txt4 Then Return

        If Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57 OrElse _
           Asc(e.KeyChar) = Keys.Back Then
            e.Handled = Boolean.FalseString
        Else
            e.Handled = Boolean.TrueString
        End If

    End Sub

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) _
                     Handles Btn2.Click, Btn1.Click, Btn3.Click, Btn4.Click, _
                     Btn5.Click, Btn6.Click, Btn7.Click, Btn8.Click, Btn9.Click

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Btn1 Then

            If Not VerificarControl(5, Grid1) Then Return

            If Grid1.ActiveRow.IsFilterRow Then Return

            Call Consultar_Enlace(Grid1.ActiveRow)

            Return

        End If

        If Ope = 0 Then Return

        If sender Is Btn2 Then

            Call Buscar() : Return

        End If

        If sender Is Btn9 Then
            Dim frmHijo As New frmBuscar
            frmHijo.Formulario = frmBuscar.eState.frm_Catalogo_molino
            frmHijo.ShowDialog()
            txt6.Text = frmHijo.Flag2
            Txt7.Text = frmHijo.Descripcion
            frmHijo = Nothing
        End If

        If sender Is Btn3 Then
            Grid1.PerformAction(ExitEditMode)
            StrucForm.FxCxRumas = New FrmCRumas
            AddHandler StrucForm.FxCxRumas.Closing, AddressOf Cargar_Ruma
            StrucForm.FxCxRumas.MdiParent = MdiParent
            StrucForm.FxCxRumas.L = Boolean.TrueString
            StrucForm.FxCxRumas.Show()
            StrucForm.FxCxRumas = Nothing
            Return

        End If

        If sender Is Btn4 Then

            If Not VerificarControl(5, Grid2) Then
                MessageBox.Show("No tiene Rumas para Quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If Grid2.ActiveRow Is Nothing Then
                MessageBox.Show("No tiene una Ruma Seleccionada", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            Grid2.ActiveRow.Delete()

        End If

        If sender Is Btn5 Then

            Grid1.PerformAction(ExitEditMode)
            StrucForm.FxCxProductos = New FrmCProductos
            AddHandler StrucForm.FxCxProductos.Closing, AddressOf Cargar_RumaxProducto
            StrucForm.FxCxProductos.MdiParent = MdiParent
            StrucForm.FxCxProductos.L = Boolean.TrueString
            StrucForm.FxCxProductos.RumaProd = Boolean.TrueString
            StrucForm.FxCxProductos.Show()
            StrucForm.FxCxProductos = Nothing
            Return

        End If


        If sender Is Btn6 Then

            If Not VerificarControl(5, Grid3) Then
                MessageBox.Show("No tiene Producto Terminado para Quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If Grid3.ActiveRow Is Nothing Then
                MessageBox.Show("No tiene un Producto Terminado Seleccionada", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            Grid3.ActiveRow.Delete()

        End If

        If sender Is Btn7 Then

            Grid1.PerformAction(ExitEditMode)
            StrucForm.FxCxTSuministro = New frmCTSuministro
            AddHandler StrucForm.FxCxTSuministro.Closing, AddressOf Cargar_RumaxSuministro
            StrucForm.FxCxTSuministro.MdiParent = MdiParent
            StrucForm.FxCxTSuministro.L = Boolean.TrueString
            StrucForm.FxCxTSuministro.Show()
            StrucForm.FxCxTSuministro = Nothing
            Return

        End If


        If sender Is Btn8 Then

            If Not VerificarControl(5, Grid4) Then
                MessageBox.Show("No tiene Producto Terminado para Quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            If Grid4.ActiveRow Is Nothing Then
                MessageBox.Show("No tiene un Producto Terminado Seleccionada", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If

            Grid4.ActiveRow.Delete()

        End If
    End Sub

    Sub Evento_BeforeRowsDeleted(ByVal sender As Object, ByVal e As BeforeRowsDeletedEventArgs) Handles Grid2.BeforeRowsDeleted, Grid3.BeforeRowsDeleted, Grid4.BeforeRowsDeleted


        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid2 And sender IsNot Grid3 And sender IsNot Grid4 Then Return

        e.DisplayPromptMsg = Boolean.FalseString

    End Sub

    Sub Evento_AfterCellUpdate(ByVal sender As Object, ByVal e As CellEventArgs) Handles Grid2.AfterCellUpdate, Grid3.AfterCellUpdate, Grid4.AfterCellUpdate


        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not Tag.ToString = StrucToolTag.MFormula Then Return

        If Not (sender Is Grid2 OrElse sender Is Grid3 OrElse sender Is Grid4) Then Return

        If e.Cell.Column.Key = "Porcentaje" Then
            MaxPorcentaje = Decimal.Zero

            For Each uRow As UltraGridRow In Grid2.Rows
                MaxPorcentaje += IIf(IsNumeric(uRow.Cells("Porcentaje").Value), uRow.Cells("Porcentaje").Value, Decimal.Zero)
            Next

            For Each uRow As UltraGridRow In Grid3.Rows
                MaxPorcentaje += IIf(IsNumeric(uRow.Cells("Porcentaje").Value), uRow.Cells("Porcentaje").Value, Decimal.Zero)
            Next

            For Each uRow As UltraGridRow In Grid4.Rows
                MaxPorcentaje += IIf(IsNumeric(uRow.Cells("Porcentaje").Value), uRow.Cells("Porcentaje").Value, Decimal.Zero)
            Next

            If MaxPorcentaje > 100 Then
                MessageBox.Show("El total no puede exceder del 100%", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                e.Cell.Value = Decimal.Zero
                Return
            End If
        End If

        If e.Cell.Column.Key = "Porcentaje" OrElse e.Cell.Column.Key = "Humedad" OrElse e.Cell.Column.Key = "Merma" Then
            e.Cell.Row.Cells("Update").Value = Boolean.TrueString
        End If

    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) Handles Grid2.InitializeRow, Grid3.InitializeRow, Grid4.InitializeRow


        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not Tag.ToString = StrucToolTag.MProductoxUnidad Then Return

        If Not (sender Is Grid2 OrElse sender Is Grid3 OrElse sender Is Grid4) Then Return

        With e.Row
            If sender Is Grid2 OrElse sender Is Grid3 OrElse sender Is Grid4 Then
                If .Cells("ID").Value <> 0 Then
                    .Cells("Update").Value = Boolean.TrueString
                Else
                    .Cells("Update").Value = Boolean.FalseString
                End If
                If .Cells("CodTipo").Value = StrucActivos.Molino Then
                    .Cells("DesTipo").Value = StrucActivos.StrMolino
                    .Cells("DesTipo").Appearance.ForeColor = Color.White
                    .Cells("DesTipo").Appearance.BackColor = Color.SkyBlue
                ElseIf .Cells("CodTipo").Value = StrucActivos.Chancadora Then
                    .Cells("DesTipo").Value = StrucActivos.StrChancadora
                    .Cells("DesTipo").Appearance.ForeColor = Color.White
                    .Cells("DesTipo").Appearance.BackColor = Color.LightCoral
                End If
            End If
        End With

    End Sub

    Private Sub Evento_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles Grid2.CellChange, Grid3.CellChange, Grid4.CellChange

        If IsDBNull(e.Cell.Text) Then
            e.Cell.Value = 100
        End If


        'If IsNumeric(e.Cell.Text) = False Then
        '    e.Cell.Value = 100
        'End If

    End Sub

    Private Sub Evento_Grilla_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Grid1.KeyDown, Grid2.KeyDown, Grid3.KeyDown, Grid4.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Grid1 OrElse sender Is Grid2 OrElse sender Is Grid3 OrElse sender Is Grid4) Then Return

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
    End Sub
#End Region

#Region "Publicos"

    Public Sub Nuevo()
        verificacierreAlmacen()
        If estadoAlmacen = 1 Then MsgBox("El almacén se encuentra cerrado", MsgBoxStyle.Information, msgComacsa) : Exit Sub
        If Tag = StrucToolTag.MProductoRuma OrElse Tag = StrucToolTag.MFormula Then
            Ope = 1
            Call Limpiar() : Call Controles(Boolean.TrueString)
            Tab1.Tabs("T02").Selected = Boolean.TrueString
            If Tag = StrucToolTag.MFormula Then
                Chk1.Checked = False
                Chk1.Visible = True
            End If

        End If

    End Sub

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Eliminar()

        If Tag = StrucToolTag.MProductoRuma OrElse Tag = StrucToolTag.MFormula Then

            If Not Tab1.Tabs("T02").Selected Then Return

            If String.IsNullOrEmpty(Txt1.Value) Then
                MessageBox.Show("No existe Enlace para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            verificacierreAlmacen()
            If estadoAlmacen = 1 Then MsgBox("El almacén se encuentra cerrado", MsgBoxStyle.Information, msgComacsa) : Exit Sub

            Call Eliminar_Enlace()

        End If

    End Sub

    Public Sub Buscar()

        If Not Btn2.Enabled Then Return

        StrucForm.FxCxProductos = New FrmCProductos
        AddHandler StrucForm.FxCxProductos.Closing, AddressOf Cargar_Producto
        StrucForm.FxCxProductos.MdiParent = MdiParent
        StrucForm.FxCxProductos.L = Boolean.TrueString
        StrucForm.FxCxProductos.Show()
        StrucForm.FxCxProductos = Nothing

    End Sub

    Public Sub Grabar()

        Grid2.UpdateData()
        Grid3.UpdateData()
        Grid4.UpdateData()

        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If Not Verificar_Datos() Then
            MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        verificacierreAlmacen()
        If estadoAlmacen = 1 Then MsgBox("El almacén se encuentra cerrado", MsgBoxStyle.Information, msgComacsa) : Exit Sub

        Grid2.PerformAction(ExitEditMode)
        Grid3.PerformAction(ExitEditMode)
        Grid4.PerformAction(ExitEditMode)

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        If Tag.ToString = StrucToolTag.MProductoRuma Then Call Grabar_Enlace()
        If Tag.ToString = StrucToolTag.MFormula Then Call Grabar_Formula()
        If Tag.ToString = StrucToolTag.MProductoxUnidad Then Call Grabar_Unidad()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Modificar()
        If Tag = StrucToolTag.MProductoRuma OrElse _
           Tag = StrucToolTag.MFormula OrElse _
           Tag = StrucToolTag.MProductoxUnidad Then

            If String.IsNullOrEmpty(Txt1.Value) Then
                MessageBox.Show("No existe Enlace para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            verificacierreAlmacen()
            If estadoAlmacen = 1 Then MsgBox("El almacén se encuentra cerrado", MsgBoxStyle.Information, msgComacsa) : Exit Sub

            Ope = 2
            Call Controles(Boolean.TrueString)
            Tab1.Tabs("T02").Selected = Boolean.TrueString

        End If

    End Sub

    Public Sub Cancelar()

        Ope = 0
        Call Controles(Boolean.FalseString)

    End Sub

    Public Sub Reporte()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        If Tag.ToString = StrucToolTag.MProductoRuma Then Call Reporte_ProductoxRuma()
        If Tag.ToString = StrucToolTag.MFormula Then Call Reporte_Formula()
        If Tag.ToString = StrucToolTag.MProductoxUnidad Then Call Reporte_ProductoxUnidad()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

#Region "Procedimientos"

    Sub Reporte_ProductoxRuma()

        StrucForm.FxRxReporte = New FrmBReporte
        StrucForm.FxRxReporte.NumReporte = VarReporte.ProductoxRuma
        StrucForm.FxRxReporte.TextReporte = "Cuadro Enlace (Producto - Ruma y/o Producto Terminado y/o Suministros)"
        StrucForm.FxRxReporte.MdiParent = MdiParent
        StrucForm.FxRxReporte.Show()

    End Sub

    Sub Reporte_Formula()

        StrucForm.FxRxReporte = New FrmBReporte
        StrucForm.FxRxReporte.NumReporte = VarReporte.Formula
        StrucForm.FxRxReporte.TextReporte = "Cuadro Enlace (Formula)"
        StrucForm.FxRxReporte.MdiParent = MdiParent
        StrucForm.FxRxReporte.Show()

    End Sub

    Sub Reporte_ProductoxUnidad()

        StrucForm.FxRxReporte = New FrmBReporte
        StrucForm.FxRxReporte.NumReporte = VarReporte.ProductoxUnidad
        StrucForm.FxRxReporte.TextReporte = "Cuadro Enlace (Producto - Unidad)"
        StrucForm.FxRxReporte.MdiParent = MdiParent
        StrucForm.FxRxReporte.Show()

    End Sub

    Sub Configurar_Formulario()

        Gbp1.Expanded = Boolean.FalseString

        If Tag = StrucToolTag.Nulo Then Return

        If Tag = StrucToolTag.MProductoRuma OrElse Tag = StrucToolTag.MFormula Then
            Tab2.Tabs("T01").Selected = True
            Btn2.Visible = Boolean.TrueString
            Navigator2.Visible = Boolean.TrueString
            Navigator3.Visible = Boolean.TrueString
            Navigator4.Visible = Boolean.TrueString
            Call Grupo_Navigator2(1, Boolean.TrueString)
            Call Grupo_Navigator2(2, Boolean.FalseString)
            Gpb1.Text = "LISTADO DE RUMAS"

        End If

        'If Tag = StrucToolTag.MFormula Then
        '    Tab2.Tabs("T01").Selected = True
        '    Btn2.Visible = Boolean.FalseString
        '    Navigator2.Visible = Boolean.FalseString
        '    Navigator3.Visible = Boolean.FalseString
        '    Navigator4.Visible = Boolean.FalseString
        '    Gpb1.Text = "LISTADO DE RUMAS"

        'End If

        If Tag = StrucToolTag.MProductoxUnidad Then
            Btn2.Visible = Boolean.FalseString
            Navigator2.Visible = Boolean.TrueString
            Call Grupo_Navigator2(1, Boolean.FalseString)
            Call Grupo_Navigator2(2, Boolean.TrueString)
            Gpb1.Text = "LISTADO DE UNIDADES"
            Tab2.Tabs("T02").Text = "UNIDADES"
            Tab2.Tabs("T02").Visible = False
            Tab2.Tabs("T03").Visible = False
        End If

    End Sub

    Sub Grupo_Navigator2(ByVal _Tipo As Int16, ByVal Rpt As Boolean)

        If _Tipo = 1 Then
            Separator2.Visible = Rpt
            Separator3.Visible = Rpt
            Btn3.Visible = Rpt
            Btn4.Visible = Rpt

            Separator9.Visible = Rpt
            Separator10.Visible = Rpt
            Btn5.Visible = Rpt
            Btn6.Visible = Rpt

            Separator16.Visible = Rpt
            Separator17.Visible = Rpt
            Btn7.Visible = Rpt
            Btn8.Visible = Rpt

        End If

        If _Tipo = 2 Then
            Separator4.Visible = Rpt
            Separator5.Visible = Rpt
            Separator6.Visible = Rpt
            Separator7.Visible = Rpt

            Separator11.Visible = Rpt
            Separator12.Visible = Rpt
            Separator13.Visible = Rpt
            Separator14.Visible = Rpt

            Separator18.Visible = Rpt
            Separator19.Visible = Rpt
            Separator20.Visible = Rpt
            Separator21.Visible = Rpt

            StripBtn1.Visible = Rpt
            StripBtn2.Visible = Rpt
            StripBtn3.Visible = Rpt
            StripBtn4.Visible = Rpt
            StripBtn5.Visible = Rpt
            StripBtn6.Visible = Rpt
            StripBtn7.Visible = Rpt
            StripBtn8.Visible = Rpt

            StripBtn9.Visible = Rpt
            StripBtn10.Visible = Rpt
            StripBtn11.Visible = Rpt
            StripBtn12.Visible = Rpt

            StripTxt1.Visible = Rpt
            StripTxt2.Visible = Rpt
            StripTxt3.Visible = Rpt
            StripLbl1.Visible = Rpt
            StripLbl2.Visible = Rpt
            StripLbl3.Visible = Rpt
        End If

    End Sub

    Sub Iniciar()

        Negocio.Producto = New NGProducto
        Entidad.MyLista = New ETMyLista

        Entidad.MyLista = Negocio.Producto.ConsultarEnlace()

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Producto = New List(Of ETProducto)
        Ls_Producto = Entidad.MyLista.Ls_Producto

        'Call CargarUltraGridxBinding(Grid1, Source1, Ls_Producto, "Descripcion")
        'Call CargarUltraGridxBinding(Me.Grid1, Source1, Ls_Producto)
        'Call CargarUltraGrid(Grid1, Ls_Producto)

        Dim dtdatos As New DataTable
        dtdatos.Columns.Add("ID")
        dtdatos.Columns.Add("CodProducto")
        dtdatos.Columns.Add("Descripcion")
        dtdatos.Columns.Add("IDMolino")
        dtdatos.Columns.Add("UnidadProduccion")
        dtdatos.Columns.Add("FechaCreacion")
        dtdatos.Columns.Add("FechaActualizacion")
        Dim dr As DataRow
        For i As Int32 = 0 To Ls_Producto.Count - 1
            dr = dtdatos.NewRow
            dr(0) = Ls_Producto.Item(i).ID
            dr(1) = Ls_Producto.Item(i).CodProducto
            dr(2) = Ls_Producto.Item(i).Descripcion
            dr(3) = Ls_Producto.Item(i).IDMolino
            dr(4) = Ls_Producto.Item(i).UnidadProduccion
            dr(5) = Ls_Producto.Item(i).FechaCreacion
            dr(6) = Ls_Producto.Item(i).FechaActualizacion
            dtdatos.Rows.Add(dr)
        Next
        Call CargarUltraGridxBinding(Me.Grid1, Source1, dtdatos)
        'For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
        '    If Not (uColumn.Key = "ID" OrElse uColumn.Key = "CodProducto" OrElse _
        '            uColumn.Key = "IDMolino" OrElse uColumn.Key = "UnidadProduccion" OrElse _
        '            uColumn.Key = "Descripcion") Then
        ''        OrElse uColumn.Key = "FechaCreacion"
        '        uColumn.Hidden = Boolean.TrueString
        '    Else
        '        uColumn.Hidden = Boolean.FalseString
        '    End If
        'Next

    End Sub

    Sub ActivarTab()
        If Tag = StrucToolTag.MProductoRuma Or Tag = StrucToolTag.MFormula Then
            If Grid2.Rows.Count > 0 Then
                Tab2.Tabs("T01").Selected = Boolean.TrueString
            ElseIf Grid3.Rows.Count > 0 Then
                Tab2.Tabs("T02").Selected = Boolean.TrueString
            ElseIf Grid4.Rows.Count > 0 Then
                Tab2.Tabs("T03").Selected = Boolean.TrueString
            End If
        End If
    End Sub
    Sub Consultar_Enlace(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        If Tag = StrucToolTag.MProductoRuma Then Call Consultar_Ruma(uRow) : Call Consultar_Ruma_Producto(uRow) : Call Consultar_Ruma_Suministro(uRow) : Call ActivarTab()

        If Tag = StrucToolTag.MProductoxUnidad Then Call Consultar_Unidad(uRow)

        If Tag = StrucToolTag.MFormula Then
            Call Consultar_Formula(uRow)
            Call Consultar_Formula_Producto(uRow)
            Call Consultar_Formula_Suministro(uRow)
            Call ActivarTab()
        End If

        lblPeriodo.Text = "Periodo: " & cmbMes.Text & " - " & txtAño.Value
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Sub Cargar_Enlace(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        Call Cancelar()

        Txt1.Value = uRow.Cells("ID").Value
        Txt2.Value = uRow.Cells("CodProducto").Value
        Txt3.Value = uRow.Cells("Descripcion").Value
        txt6.Value = uRow.Cells("IdMolino").Value
        Txt7.Value = uRow.Cells("UnidadProduccion").Value
        If Tag = StrucToolTag.MFormula Then
            Chk1.Checked = False
            Chk1.Visible = False
        End If

        Dt1.Value = uRow.Cells("FechaCreacion").Value
        Dt2.Value = IIf(uRow.Cells("FechaActualizacion").Value = DateFechaMinima, DBNull.Value, uRow.Cells("FechaActualizacion").Value)

        If Tag = StrucToolTag.MProductoxUnidad Then
            Call CargarUltraGridxBinding(Grid2, Source2, Ls_Activo, "Descripcion")
        ElseIf Tag = StrucToolTag.MProductoRuma OrElse Tag = StrucToolTag.MFormula Then
            Call CargarUltraGrid(Grid2, Ls_Ruma)
            Call CargarUltraGrid(Grid3, Ls_RumaProd)
            Call CargarUltraGrid(Grid4, Ls_RumaSuministro)
        End If

        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Sub Cargar_Producto(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        Txt2.Value = sender.CodProducto
        Txt3.Value = sender.Descripcion

    End Sub

    Sub Cargar_Ruma(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        If Ls_Ruma Is Nothing Then Ls_Ruma = New List(Of ETRuma)

        For Each W As ETRuma In sender.Lista
            CodRuma = String.Empty : CodRuma = W.CodRuma
            If Not Ls_Ruma.Exists(AddressOf Existe_Ruma) Then Ls_Ruma.Add(W)
        Next

        Call CargarUltraGrid(Grid2, Ls_Ruma)

    End Sub

    Sub Cargar_RumaxProducto(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        If Ls_RumaProd Is Nothing Then Ls_RumaProd = New List(Of ETRuma)

        For Each W As ETRuma In sender.Lista
            CodRuma = String.Empty : CodRuma = W.CodRuma
            If Not Ls_RumaProd.Exists(AddressOf Existe_Ruma) Then Ls_RumaProd.Add(W)
        Next

        Call CargarUltraGrid(Grid3, Ls_RumaProd)

    End Sub

    Sub Cargar_RumaxSuministro(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        If Ls_RumaSuministro Is Nothing Then Ls_RumaSuministro = New List(Of ETRuma)

        For Each W As ETRuma In sender.Lista
            CodRuma = String.Empty : CodRuma = W.CodRuma
            If Not Ls_RumaSuministro.Exists(AddressOf Existe_Ruma) Then Ls_RumaSuministro.Add(W)
        Next

        Call CargarUltraGrid(Grid4, Ls_RumaSuministro)

    End Sub

    Sub Consultar_Ruma(ByVal uRow As UltraGridRow)

        Entidad.MyLista = New ETMyLista
        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto
        Ls_Ruma = New List(Of ETRuma)

        Entidad.Producto.ID = uRow.Cells("ID").Value
        Entidad.Producto.Anho = txtAño.Value
        Entidad.Producto.Mes = Me.cmbMes.SelectedIndex + 1
        Entidad.MyLista = Negocio.Producto.ConsultarEnlacexRuma(Entidad.Producto)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Ruma = Entidad.MyLista.Ls_Ruma

        Call Cargar_Enlace(uRow)

    End Sub

    Sub Consultar_Ruma_Producto(ByVal uRow As UltraGridRow)

        Entidad.MyLista = New ETMyLista
        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto
        Ls_RumaProd = New List(Of ETRuma)

        Entidad.Producto.ID = uRow.Cells("ID").Value
        Entidad.Producto.Anho = txtAño.Value
        Entidad.Producto.Mes = Me.cmbMes.SelectedIndex + 1
        Entidad.MyLista = Negocio.Producto.ConsultarEnlacexRumaxProducto(Entidad.Producto)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_RumaProd = Entidad.MyLista.Ls_Ruma

        Call Cargar_Enlace(uRow)

    End Sub

    Sub Consultar_Ruma_Suministro(ByVal uRow As UltraGridRow)

        Entidad.MyLista = New ETMyLista
        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto
        Ls_RumaSuministro = New List(Of ETRuma)

        Entidad.Producto.ID = uRow.Cells("ID").Value
        Entidad.Producto.Anho = txtAño.Value
        Entidad.Producto.Mes = Me.cmbMes.SelectedIndex + 1
        Entidad.MyLista = Negocio.Producto.ConsultarEnlacexRumaxSuministro(Entidad.Producto)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_RumaSuministro = Entidad.MyLista.Ls_Ruma

        Call Cargar_Enlace(uRow)

    End Sub

    Sub Consultar_Formula(ByVal uRow As UltraGridRow)

        Entidad.Activo = New ETActivo
        Entidad.MyLista = New ETMyLista
        Negocio.Activo = New NGActivo
        Ls_Ruma = New List(Of ETRuma)

        Entidad.Activo.CodEnlace = uRow.Cells("ID").Value
        Entidad.Activo.Anho = txtAño.Value
        Entidad.Activo.Mes = Me.cmbMes.SelectedIndex + 1
        Entidad.MyLista = Negocio.Activo.ConsultarEnlacexFormula(Entidad.Activo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Ruma = Entidad.MyLista.Ls_Ruma

        Call Cargar_Enlace(uRow)

    End Sub

    Sub Consultar_Formula_Producto(ByVal uRow As UltraGridRow)

        Entidad.Activo = New ETActivo
        Entidad.MyLista = New ETMyLista
        Negocio.Activo = New NGActivo
        Ls_RumaProd = New List(Of ETRuma)

        Entidad.Activo.CodEnlace = uRow.Cells("ID").Value
        Entidad.Activo.Anho = txtAño.Value
        Entidad.Activo.Mes = Me.cmbMes.SelectedIndex + 1
        Entidad.MyLista = Negocio.Activo.ConsultarEnlacexFormulaxProducto(Entidad.Activo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_RumaProd = Entidad.MyLista.Ls_Ruma

        Call Cargar_Enlace(uRow)

    End Sub

    Sub Consultar_Formula_Suministro(ByVal uRow As UltraGridRow)

        Entidad.Activo = New ETActivo
        Entidad.MyLista = New ETMyLista
        Negocio.Activo = New NGActivo
        Ls_RumaSuministro = New List(Of ETRuma)

        Entidad.Activo.CodEnlace = uRow.Cells("ID").Value
        Entidad.Activo.Anho = txtAño.Value
        Entidad.Activo.Mes = Me.cmbMes.SelectedIndex + 1
        Entidad.MyLista = Negocio.Activo.ConsultarEnlacexFormulaxSuministro(Entidad.Activo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_RumaSuministro = Entidad.MyLista.Ls_Ruma

        Call Cargar_Enlace(uRow)

    End Sub

    Sub Consultar_Unidad(ByVal uRow As UltraGridRow)

        Entidad.Activo = New ETActivo
        Entidad.MyLista = New ETMyLista
        Negocio.Activo = New NGActivo
        Ls_Activo = New List(Of ETActivo)

        Entidad.Activo.CodClase = StrucActivos.CodClase
        Entidad.Activo.CodEnlace = uRow.Cells("ID").Value

        Entidad.MyLista = Negocio.Activo.ConsultarActivoxMatriz(Entidad.Activo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Activo = Entidad.MyLista.Ls_Activo

        Call Cargar_Enlace(uRow)

    End Sub

    Sub Limpiar()

        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Txt3.Value = String.Empty
        txt6.Value = String.Empty
        Txt7.Value = String.Empty
        Dt1.Value = Now.Date
        Dt2.Value = DBNull.Value
        If Ls_Ruma IsNot Nothing And Ls_RumaProd IsNot Nothing And Ls_RumaSuministro IsNot Nothing Then
            If (Ls_Ruma.Count + Ls_RumaProd.Count + Ls_RumaSuministro.Count) > 0 Then
                If MsgBox("¿Desea Mantener la Formulación para otro producto?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Tab1.Tabs("T02").Selected = Boolean.TrueString
                    Exit Sub
                End If
            End If
        End If

        Ls_Ruma = New List(Of ETRuma)
        Call CargarUltraGrid(Grid2, Ls_Ruma)

        Ls_RumaProd = New List(Of ETRuma)
        Call CargarUltraGrid(Grid3, Ls_RumaProd)

        Ls_RumaSuministro = New List(Of ETRuma)
        Call CargarUltraGrid(Grid4, Ls_RumaSuministro)

        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Sub Controles(ByVal Val As Boolean)

        If Tag.ToString = StrucToolTag.MProductoRuma OrElse Tag.ToString = StrucToolTag.MFormula Then
            If Ope <> 2 Then Btn2.Enabled = Val : Btn9.Enabled = Val
            Btn3.Enabled = Val : Btn4.Enabled = Val : Btn5.Enabled = Val : Btn6.Enabled = Val : Btn7.Enabled = Val : Btn8.Enabled = Val
            Grid2.DisplayLayout.Override.AllowDelete = IIf(Val, 1, 2)
            Grid3.DisplayLayout.Override.AllowDelete = IIf(Val, 1, 2)
            Grid4.DisplayLayout.Override.AllowDelete = IIf(Val, 1, 2)
            If Ope = 1 And Tag.ToString = StrucToolTag.MFormula Then
                Dt1.ReadOnly = False
            Else
                Dt1.ReadOnly = True
            End If
        End If

        If Tag.ToString = StrucToolTag.MProductoxUnidad Then
            With Grid2.DisplayLayout.Bands(0)
                If Val Then
                    .Columns("Rendimiento").CellActivation = Activation.AllowEdit
                    .Columns("Energia").CellActivation = Activation.AllowEdit
                Else
                    .Columns("Rendimiento").CellActivation = Activation.ActivateOnly
                    .Columns("Energia").CellActivation = Activation.ActivateOnly
                End If
            End With
        End If

        If Tag.ToString = StrucToolTag.MFormula Then
            With Grid2.DisplayLayout.Bands(0)
                If Val Then
                    .Columns("Merma").CellActivation = Activation.AllowEdit
                    .Columns("Humedad").CellActivation = Activation.AllowEdit
                    .Columns("Porcentaje").CellActivation = Activation.AllowEdit
                Else
                    .Columns("Merma").CellActivation = Activation.ActivateOnly
                    .Columns("Humedad").CellActivation = Activation.ActivateOnly
                    .Columns("Porcentaje").CellActivation = Activation.ActivateOnly
                End If
            End With

            With Grid3.DisplayLayout.Bands(0)
                If Val Then
                    .Columns("Merma").CellActivation = Activation.AllowEdit
                    .Columns("Humedad").CellActivation = Activation.AllowEdit
                    .Columns("Porcentaje").CellActivation = Activation.AllowEdit
                Else
                    .Columns("Merma").CellActivation = Activation.ActivateOnly
                    .Columns("Humedad").CellActivation = Activation.ActivateOnly
                    .Columns("Porcentaje").CellActivation = Activation.ActivateOnly
                End If
            End With

            With Grid4.DisplayLayout.Bands(0)
                If Val Then
                    .Columns("Merma").CellActivation = Activation.AllowEdit
                    .Columns("Humedad").CellActivation = Activation.AllowEdit
                    .Columns("Porcentaje").CellActivation = Activation.AllowEdit
                Else
                    .Columns("Merma").CellActivation = Activation.ActivateOnly
                    .Columns("Humedad").CellActivation = Activation.ActivateOnly
                    .Columns("Porcentaje").CellActivation = Activation.ActivateOnly
                End If
            End With
        End If

    End Sub

    Sub Filtrar_Busqueda(ByVal Rpt As Int16)

        If Not Verificar_Filtro(Rpt) Then Return

        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto
        Entidad.MyLista = New ETMyLista
        Ls_Producto = New List(Of ETProducto)

        Entidad.Producto.Tipo = Rpt
        Entidad.Producto.ID = IIf(IsNumeric(Num1.Value), Num1.Value, 0)
        Entidad.Producto.CodProducto = Lbl2.Text & IIf(String.IsNullOrEmpty(Txt4.Value), String.Empty, Trim(Txt4.Value))
        Entidad.Producto.Descripcion = IIf(String.IsNullOrEmpty(Txt5.Value), String.Empty, Trim(Txt5.Value))
        Entidad.Producto.FechaCreacion = IIf(IsDate(Dt3.Value), Dt3.Value, DateFechaMinima)
        Entidad.Producto.FechaActualizacion = IIf(IsDate(Dt4.Value), Dt4.Value, DateFechaMinima)

        Entidad.MyLista = Negocio.Producto.ConsultarBusquedaEnlace(Entidad.Producto)

        If Entidad.MyLista.Validacion Then
            Ls_Producto = Entidad.MyLista.Ls_Producto
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Producto)

    End Sub

    Sub Producto_InitializeLayout(ByVal e As InitializeLayoutEventArgs)

        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "ID" OrElse uColumn.Key = "CodProducto" OrElse _
                    uColumn.Key = "IDMolino" OrElse uColumn.Key = "UnidadProduccion" OrElse _
                    uColumn.Key = "Descripcion") Then
                'OrElse uColumn.Key = "FechaCreacion"
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

    End Sub

    Sub Unidad_InitializeLayout(ByVal e As InitializeLayoutEventArgs)

        If e Is Nothing Then
            Return
        End If

        With e.Layout

            .Override.FilterUIType = FilterUIType.FilterRow

            With .Bands(0)

                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Update" OrElse uColumn.Key = "Placa" OrElse _
                            uColumn.Key = "DesTipo" OrElse uColumn.Key = "Descripcion" OrElse _
                            uColumn.Key = "Rendimiento" OrElse uColumn.Key = "Energia") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next

                .Columns("Update").Header.VisiblePosition = 0
                .Columns("DesTipo").Header.VisiblePosition = 1
                .Columns("Placa").Header.VisiblePosition = 2
                .Columns("Descripcion").Header.VisiblePosition = 3
                .Columns("Rendimiento").Header.VisiblePosition = 4
                .Columns("Energia").Header.VisiblePosition = 5

            End With

        End With

    End Sub

    Sub Ruma_InitializeLayout(ByVal e As InitializeLayoutEventArgs)

        If e Is Nothing Then
            Return
        End If

        With e.Layout.Bands(0)

            If Tag = StrucToolTag.MProductoRuma Then
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "CodRuma" Or uColumn.Key = "Descripcion") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            Else
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Merma" OrElse uColumn.Key = "Descripcion" OrElse _
                            uColumn.Key = "CodRuma" OrElse uColumn.Key = "Humedad" OrElse _
                            uColumn.Key = "Porcentaje") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End If

            .Columns("CodRuma").Header.VisiblePosition = 0
            .Columns("Descripcion").Header.VisiblePosition = 1
            .Columns("Porcentaje").Header.VisiblePosition = 2
            .Columns("Humedad").Header.VisiblePosition = 3
            .Columns("Merma").Header.VisiblePosition = 4

        End With

    End Sub

    Sub ProductoTerminado_InitializeLayout(ByVal e As InitializeLayoutEventArgs)

        If e Is Nothing Then
            Return
        End If

        With e.Layout.Bands(0)

            If Tag = StrucToolTag.MProductoRuma Then
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "CodRuma" Or uColumn.Key = "Descripcion") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            Else
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Merma" OrElse uColumn.Key = "Descripcion" OrElse _
                            uColumn.Key = "CodRuma" OrElse uColumn.Key = "Humedad" OrElse _
                            uColumn.Key = "Porcentaje") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End If

            .Columns("CodRuma").Header.VisiblePosition = 0
            .Columns("Descripcion").Header.VisiblePosition = 1
            .Columns("Porcentaje").Header.VisiblePosition = 2
            .Columns("Humedad").Header.VisiblePosition = 3
            .Columns("Merma").Header.VisiblePosition = 4

        End With

    End Sub

    Sub Grabar_Enlace()

        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto

        Entidad.Producto.ID = IIf(IsNumeric(Txt1.Value), Txt1.Value, 0)
        Entidad.Producto.IDMolino = txt6.Text.Trim
        Entidad.Producto.CodProducto = Txt2.Value
        Entidad.Producto.Usuario = User_Sistema
        Entidad.Producto.Anho = txtAño.Value
        Entidad.Producto.Mes = Me.cmbMes.SelectedIndex + 1
        Entidad.Producto = Negocio.Producto.MantenimientoEnlace(Entidad.Producto, Ls_Ruma, Ls_RumaProd, Ls_RumaSuministro)

        If Not Entidad.Producto.Validacion Then Return

        If Ope = 1 Then Txt1.Value = Entidad.Producto.ID

        Call Iniciar() : Call Cancelar()

    End Sub

    Sub Grabar_Formula()

        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto

        Entidad.Producto.ID = Val(Txt1.Text)
        Entidad.Producto.CodProducto = Txt2.Text.Trim
        Entidad.Producto.IDMolino = txt6.Text.Trim
        Entidad.Producto.Usuario = User_Sistema
        Entidad.Producto.Fecha = CDate(Dt1.Value).Date
        Entidad.Producto.Anho = txtAño.Value
        Entidad.Producto.Mes = Me.cmbMes.SelectedIndex + 1
        If Ope = 1 Then
            Entidad.Producto.Update = Chk1.Checked
        Else
            Entidad.Producto.Update = False
        End If

        Entidad.Producto = Negocio.Producto.MantenimientoFormula(Entidad.Producto, Ls_Ruma, Ls_RumaProd, Ls_RumaSuministro)

        If Not Entidad.Producto.Validacion Then Return

        If Ope = 1 Then Txt1.Value = Entidad.Producto.ID

        Call Cancelar()

    End Sub

    Sub Grabar_Unidad()

        Entidad.Activo = New ETActivo
        Negocio.Activo = New NGActivo

        Entidad.Activo.Usuario = User_Sistema
        Entidad.Activo.CodEnlace = Txt1.Value
        Entidad.Activo.Anho = txtAño.Value
        Entidad.Activo.Mes = Me.cmbMes.SelectedIndex + 1
        Entidad.Activo = Negocio.Activo.MantenimientoxMatrizxActivo(Entidad.Activo, Ls_Activo)

        If Not Entidad.Activo.Validacion Then Return

        Call Cancelar()

    End Sub

    Sub Eliminar_Enlace()

        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto

        Entidad.Producto.ID = Txt1.Value
        Entidad.Producto.CodProducto = Txt2.Value
        Entidad.Producto.Descripcion = Txt3.Value
        Entidad.Producto.IDMolino = txt6.Text.Trim
        Entidad.Producto.Usuario = User_Sistema
        Entidad.Producto.Anho = txtAño.Value
        Entidad.Producto.Mes = Me.cmbMes.SelectedIndex + 1

        Entidad.Producto = Negocio.Producto.EliminarEnlace(Entidad.Producto)

        If Not Entidad.Producto.Validacion Then Return

        Call Limpiar()

        Call Iniciar()

    End Sub
    Dim estadoAlmacen As Int32
    Sub verificacierreAlmacen()

        Entidad.Producto.Periodo = (cmbMes.SelectedIndex + 1).ToString.PadLeft(2, "0") & txtAño.Value.ToString
        Dim dtCierre As New DataTable
        dtCierre = Negocio.Producto.verificacierreAlmacen(Entidad.Producto)
        'Entidad.MyLista = Negocio.NEntregas.VerificaCierreContable(Entidad.Entregas)


        If dtCierre.Rows.Count > 0 Then
            estadoAlmacen = 1
        Else
            estadoAlmacen = 0
        End If

    End Sub
#End Region

#Region "Funciones"

    Function Existe_Ruma(ByVal Rpt As ETRuma) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.CodRuma = CodRuma Then
            lResult = Boolean.TrueString
        End If

        Return lResult

    End Function

    Function Verificar_Datos() As Boolean

        Ep1.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        If Ope = 2 AndAlso String.IsNullOrEmpty(Txt1.Value) Then
            Ep1.SetError(Txt1, "Ingrese el Enlace")
            lResult = Boolean.FalseString
        End If

        If String.IsNullOrEmpty(Txt2.Value) Then
            Ep1.SetError(Txt2, "Ingrese el Producto para el enlace")
            lResult = Boolean.FalseString
        End If

        Return lResult

    End Function

    Function Verificar_Filtro(ByVal Rpt As Int16) As Boolean

        Dim lResult As Boolean = Boolean.TrueString

        If Rpt = Filtro.Enlace Then
            If Not (IsNumeric(Num1.Value) AndAlso Num1.Value <> 0) Then
                MessageBox.Show("Ingrese el Enlace para Iniciar la Busqueda", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                lResult = Boolean.FalseString
            End If
        End If
        If Rpt = Filtro.Codigo Then
            If String.IsNullOrEmpty(Txt4.Value) Then
                MessageBox.Show("Ingrese el Código del Producto para Iniciar la Busqueda", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                lResult = Boolean.FalseString
            End If
        End If
        If Rpt = Filtro.Descripcion Then
            If String.IsNullOrEmpty(Txt5.Value) Then
                MessageBox.Show("Ingrese la Descripción del Producto para Iniciar la Busqueda", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                lResult = Boolean.FalseString
            End If
        End If
        If Rpt = Filtro.Emision Then
            If Not IsDate(Dt3.Value) Then
                MessageBox.Show("Ingrese la Fecha de Inicio para Iniciar la Busqueda", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                lResult = Boolean.FalseString
            ElseIf Not IsDate(Dt4.Value) Then
                MessageBox.Show("Ingrese la Fecha de Final para Iniciar la Busqueda", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                lResult = Boolean.FalseString
            ElseIf Date.Compare(Dt3.Value, Dt4.Value) > 0 Then
                MessageBox.Show("Ingrese la Fecha de Inicio no puede ser Mayor que la Fecha Final", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                lResult = Boolean.FalseString
            End If
        End If

        Return lResult

    End Function

#End Region


    
    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            lblPeriodo.Text = "Periodo: " & cmbMes.Text & " - " & txtAño.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtAño_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAño.ValueChanged
        lblPeriodo.Text = "Periodo: " & cmbMes.Text & " - " & txtAño.Value
    End Sub
End Class