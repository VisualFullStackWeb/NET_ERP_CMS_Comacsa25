Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Math
Imports System.Drawing
Imports System.Windows
Imports System.Windows.Forms
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.Misc
Imports Infragistics.Win.DrawPhase
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmLOrdenProduccion
    Public Ls_Permisos As New List(Of Integer)
   
    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Me.WindowState = FormWindowState.Maximized
        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub


#Region "Declaraciones"

    Private Structure TurnoProduccion
        Event z()
        Const Turno1 As String = "PRIMERO"
        Const Turno2 As String = "SEGUNDO"
        Const Turno3 As String = "TERCERO"
        Const Turno4 As String = "HORARIO NORMAL"
    End Structure

    Private Enum Opcion
        Orden = 0
        Enlace = 1
        Ruma = 2
        Empaque = 3
        Activo = 4
        Chancadora = 5
        Molino = 5
        RumaMineral = 6
        FormulacionProducto = 7
        FormulacionSuministro = 8
        FormulacionRecirculado = 9
    End Enum

    Private Ope As Int16 = 0
    Public CodProducto As String = String.Empty
    Public Descripcion As String = String.Empty
    Public Cantidad As Decimal = Decimal.Zero
    Private uRow As UltraDataRow = Nothing
    Private Ejecutar As Boolean = Boolean.FalseString
    Private Bucle As Boolean = Boolean.FalseString
    Private Ls_Ruma As List(Of ETRuma) = Nothing
    Private Ls_Ruma_Temp As List(Of ETRuma) = Nothing
    Private Ls_Ruma_Mineral As List(Of ETRuma) = Nothing
    Private Ls_RumaProd As List(Of ETRuma) = Nothing
    Private Ls_RumaSuministro As List(Of ETRuma) = Nothing
    Private Ls_RumaProdRecirculado As List(Of ETRuma) = Nothing
    Private Ls_Enlace As List(Of ETProducto) = Nothing
    Private Ls_Empaque As List(Of ETSuministro) = Nothing
    Private Ls_Unidad As List(Of ETActivo) = Nothing
    Private Ls_Chancadora As List(Of ETActivo) = Nothing
    Private Ls_Molino As List(Of ETActivo) = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public EjecutarxStockMinimo As Boolean = Boolean.FalseString
    Private Ds_Ruma As New DataSet
    Private Tbl_Mineral As New DataTable
    Private Tbl_Ruma As New DataTable
    Private ReprocesarRuma As Boolean = Boolean.FalseString
    Private CodRuma As String = String.Empty

#End Region

#Region "Eventos"

    Sub Evento_SelectedTabChanging(ByVal sender As Object, ByVal e As SelectedTabChangingEventArgs) _
                                   Handles Tab1.SelectedTabChanging

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Tab1 Then Return

        If Not (e.Tab.Key.ToString = "T02" OrElse e.Tab.Key.ToString = "T03") Then Return

        If String.IsNullOrEmpty(Txt2.Value) Then
            MessageBox.Show("Ingrese el Producto ha Producir", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = Boolean.TrueString
            Return
        End If

        If String.IsNullOrEmpty(Cbo1.Value) Then
            MessageBox.Show("Seleccione el Enlace de Producción", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = Boolean.TrueString
            Return
        End If

        If Not IsNumeric(Num1.Value) Then
            MessageBox.Show("Ingrese la Cantidad ha Producir", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = Boolean.TrueString
            Return
        End If

        If Not IsDate(Dt3.Value) Then
            MessageBox.Show("Ingrese la Fecha de Ingreso al Almacen", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = Boolean.TrueString
            Return
        End If

    End Sub

    Sub Evento_BeforeCellUpdate(ByVal sender As Object, ByVal e As BeforeCellUpdateEventArgs) _
                                Handles Grid2.BeforeCellUpdate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid2 Then Return

        If e.Cell.Row Is Nothing Then Return

        If e.Cell.Column.Key.ToString <> "CantidadUnitaria" Then Return

        If Not IsNumeric(e.NewValue) Then Return

        If Verificar_Cantidad_Suministro(e.Cell.Row, e.NewValue) Then Return

        e.Cancel = Boolean.TrueString

    End Sub

    Sub Evento_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) _
                            Handles Txt2.ValueChanged, Cbo1.ValueChanged

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Txt2 Then

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

            Call Consultar(Opcion.Empaque, sender)

            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

            Return

        End If

        If sender Is Cbo1 Then

            If ReprocesarRuma = True Then
                Call ReprocesarRuma_OT(sender)
            End If
            
            Return

        End If

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If uRow IsNot Nothing Then uRow = Nothing
        If Ls_Enlace IsNot Nothing Then Ls_Enlace = Nothing
        If Ls_Ruma IsNot Nothing Then Ls_Ruma = Nothing
        If Ls_Empaque IsNot Nothing Then Ls_Empaque = Nothing
        If Ls_Unidad IsNot Nothing Then Ls_Unidad = Nothing
        If Ls_Chancadora IsNot Nothing Then Ls_Chancadora = Nothing
        If Ls_Molino IsNot Nothing Then Ls_Molino = Nothing

        If Ls_Ruma_Temp IsNot Nothing Then Ls_Ruma_Temp = Nothing
        If Ls_Ruma_Mineral IsNot Nothing Then Ls_Ruma_Mineral = Nothing
        If Ls_RumaSuministro IsNot Nothing Then Ls_RumaSuministro = Nothing
        If Ls_RumaProdRecirculado IsNot Nothing Then Ls_RumaProdRecirculado = Nothing

        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Controles(False)

        If Not EjecutarxStockMinimo Then Return

        Call Buscar_PorStockMinimo()

    End Sub

    'Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
    '                     Handles Me.Activated

    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    MdiOperaciones = New List(Of String)

    '    MdiOperaciones.Add(StrucOperaciones._Nuevo)
    '    MdiOperaciones.Add(StrucOperaciones._Orden)
    '    MdiOperaciones.Add(StrucOperaciones._Modificar)
    '    MdiOperaciones.Add(StrucOperaciones._Cancelar)
    '    MdiOperaciones.Add(StrucOperaciones._Actualizar)
    '    MdiOperaciones.Add(StrucOperaciones._Buscar)
    '    MdiOperaciones.Add(StrucOperaciones._Eliminar)
    '    MdiOperaciones.Add(StrucOperaciones._Reporte)
    '    MdiOperaciones.Add(StrucOperaciones._Grabar)

    '    Call AdministrarToolBar(MdiParent, MdiOperaciones)

    'End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
                          Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Cbo1.InitializeLayout, _
                                        Grid2.InitializeLayout, Grid3.InitializeLayout, _
                                        Grid4.InitializeLayout, Grid8.InitializeLayout, Grid6.InitializeLayout, Grid9.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Cbo1 Then
            With sender.DisplayLayout.Bands(0)
                .ColHeadersVisible = Boolean.FalseString
                .Columns("ID").Width = sender.Width
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "ID") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End With
        End If

        If sender Is Grid2 Then
            With sender.DisplayLayout.Bands(0)
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "CodSuministro" Or _
                            uColumn.Key = "Descripcion" Or uColumn.Key = "Peso" Or _
                            uColumn.Key = "CostoUnitario" Or _
                            uColumn.Key = "SubTotal" Or uColumn.Key = "CantidadUnitaria") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End With
        End If

        If sender Is Grid3 OrElse sender Is Grid4 Then
            With sender.DisplayLayout.Bands(0)
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Descripcion" Or uColumn.Key = "Fecha" Or _
                            uColumn.Key = "DesTurno" Or uColumn.Key = "NroOperarios" Or _
                            uColumn.Key = "SubTotal" Or uColumn.Key = "CodLote" Or _
                            uColumn.Key = "TonUtilizado" Or uColumn.Key = "Uso" Or _
                            uColumn.Key = "CostoxTon" Or uColumn.Key = "Horas") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                    If sender Is Grid3 AndAlso uColumn.Key = "CodLote" Then uColumn.Hidden = Boolean.TrueString
                Next
            End With
        End If


        If sender Is Grid8 OrElse sender Is Grid9 Then
            With sender.DisplayLayout.Bands(0)
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Codigo" Or uColumn.Key = "Descripcion" Or _
                            uColumn.Key = "Porcentaje" Or uColumn.Key = "Humedad" Or _
                            uColumn.Key = "Merma" Or uColumn.Key = "CantidadxFraccionada" Or _
                            uColumn.Key = "CantidadxNecesaria" Or uColumn.Key = "CostoxTON" Or _
                            uColumn.Key = "SubTotal") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        If Not (uColumn.Key = "Porcentaje" Or uColumn.Key = "Humedad" Or _
                            uColumn.Key = "Merma") Then
                            uColumn.CellActivation = Activation.ActivateOnly
                        Else
                            If Ope = 1 OrElse Ope = 2 Then
                                uColumn.CellActivation = Activation.AllowEdit
                            End If
                        End If
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End With
        End If


        If sender Is Grid6 Then
            With sender.DisplayLayout.Bands(0)
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Codigo" Or uColumn.Key = "Descripcion" Or _
                            uColumn.Key = "Porcentaje" Or uColumn.Key = "Humedad" Or _
                            uColumn.Key = "Merma" Or uColumn.Key = "CantidadxFraccionada" Or _
                            uColumn.Key = "CantidadxNecesaria" Or uColumn.Key = "CostoxTON" Or _
                            uColumn.Key = "SubTotal") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        If Not (uColumn.Key = "Porcentaje" Or uColumn.Key = "Humedad" Or _
                            uColumn.Key = "Merma") Then
                            uColumn.CellActivation = Activation.ActivateOnly
                        Else
                            If Ope = 1 OrElse Ope = 2 Then
                                uColumn.CellActivation = Activation.AllowEdit
                            End If
                        End If
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End With
        End If
    End Sub

    Sub Evento_AfterRowsDeleted(ByVal sender As Object, ByVal e As EventArgs) _
                                Handles Grid3.AfterRowsDeleted, Grid4.AfterRowsDeleted

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Grid3 OrElse sender Is Grid4) Then Return

        Call ReProcesarUnidad(sender)

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles _
                       Cbo1.KeyDown, Num1.KeyDown, Dt3.KeyDown, _
                       Txt2.KeyDown, Txt3.KeyDown, Txt1.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return

        If sender Is Txt1 Then
            Txt2.Focus()
            Txt2.SelectAll()
        End If

        If sender Is Txt2 OrElse sender Is Txt3 Then
            Cbo1.Focus()
            Cbo1.Select()
        End If

        If sender Is Cbo1 Then
            Num1.Focus()
            Num1.SelectAll()
        End If

        If sender Is Num1 Then
            Dt3.Focus()
            Dt3.SelectAll()
        End If

        If sender Is Dt3 Then
            Txt4.Focus()
            Txt4.SelectAll()
        End If

    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) _
                             Handles Grid3.InitializeRow, Grid4.InitializeRow, Grid6.InitializeRow, _
                             Grid7.InitializeRow, Grid8.InitializeRow, Grid9.InitializeRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Grid3 OrElse sender Is Grid4 OrElse sender Is Grid6 OrElse _
                sender Is Grid7 OrElse sender Is Grid8 OrElse sender Is Grid9) Then Return

        If (sender Is Grid3 OrElse sender Is Grid4) Then
            With e.Row
                Select Case .Cells("Turno").Value
                    Case 1
                        .Cells("DesTurno").Value = TurnoProduccion.Turno1
                    Case 2
                        .Cells("DesTurno").Value = TurnoProduccion.Turno2
                    Case 3
                        .Cells("DesTurno").Value = TurnoProduccion.Turno3
                    Case 4
                        .Cells("DesTurno").Value = TurnoProduccion.Turno4
                End Select
            End With
        End If

        If (sender Is Grid6 OrElse sender Is Grid7 OrElse sender Is Grid8 OrElse sender Is Grid9) Then
            If IsDBNull(e.Row.Cells("Nuevo").Value) Then
                e.Row.CellAppearance.BackColor = Color.LightYellow
                e.Row.CellAppearance.ForeColor = Color.Red
            Else
                If e.Row.Cells("Nuevo").Value = Boolean.TrueString Then
                    e.Row.CellAppearance.BackColor = Color.LightYellow
                    e.Row.CellAppearance.ForeColor = Color.Red
                End If
            End If
        End If
    End Sub

    Sub Evento_Grilla_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Grid6.KeyDown, Grid7.KeyDown, Grid8.KeyDown, Grid9.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Grid7 OrElse sender Is Grid8 OrElse sender Is Grid6 OrElse sender Is Grid9) Then Return

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

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) _
                     Handles Btn1.Click, Btn2.Click, Btn3.Click, _
                     Btn4.Click, Btn5.Click, Btn6.Click, Btn7.Click, _
                     Btn8.Click, Btn9.Click, Btn10.Click, Btn11.Click, _
                     Btn12.Click, Btn13.Click, Btn14.Click, Btn15.Click


        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Dim i As Integer = 0

        If sender Is Btn1 Then Buscar() : Return

        If Not IsDate(Dt1.Value) Then
            MessageBox.Show("Error: La Fecha de Inicio es Incorrecta", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If Not IsDate(Dt3.Value) Then
            MessageBox.Show("Error: La Fecha de Ingreso al Almacén es Incorrecta", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        If Ope = 0 Then Return

        If sender Is Btn2 OrElse sender Is Btn4 Then

            IIf(sender Is Btn2, Grid3.PerformAction(ExitEditMode), Grid4.PerformAction(ExitEditMode))
            StrucForm.FxLxDetalleUnidad = New FrmLDetalleUnidad
            AddHandler StrucForm.FxLxDetalleUnidad.Closing, AddressOf Buscar_Unidad
            StrucForm.FxLxDetalleUnidad.L = Boolean.TrueString
            StrucForm.FxLxDetalleUnidad.ID = Cbo1.Value
            StrucForm.FxLxDetalleUnidad.CodClase = StrucActivos.CodClase
            StrucForm.FxLxDetalleUnidad.CodTipo = IIf(sender Is Btn2, StrucActivos.Chancadora, StrucActivos.Molino)
            StrucForm.FxLxDetalleUnidad.CodProducto = Txt2.Value
            StrucForm.FxLxDetalleUnidad.FecInicio = Dt1.Value
            StrucForm.FxLxDetalleUnidad.FecIngreso = Dt3.Value
            StrucForm.FxLxDetalleUnidad.MdiParent = MdiParent
            StrucForm.FxLxDetalleUnidad.Show()
            StrucForm.FxLxDetalleUnidad = Nothing

        End If

        If sender Is Btn3 Then
            If Not VerificarControl(5, Grid3) Then
                MessageBox.Show("No tiene Lotes para Quitar de la Lista de Chancadoras", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If Grid3.ActiveRow Is Nothing Then
                MessageBox.Show("No tiene un Lote Seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            Grid3.ActiveRow.Delete()
        End If

        If sender Is Btn5 Then
            If Not VerificarControl(5, Grid4) Then
                MessageBox.Show("No tiene Lotes para Quitar de la Lista de Molinos", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            If Grid4.ActiveRow Is Nothing Then
                MessageBox.Show("No tiene un Lote Seleccionado", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End If
            Grid4.ActiveRow.Delete()
        End If

        If sender Is Btn6 Then
            Ls_Chancadora = New List(Of ETActivo)
            Call CargarUltraGrid(Grid3, Ls_Chancadora)
        End If

        If sender Is Btn7 Then
            Ls_Molino = New List(Of ETActivo)
            Call CargarUltraGrid(Grid4, Ls_Molino)
        End If

        If sender Is Btn8 Then
            StrucForm.FxCxRumas = New FrmCRumas
            AddHandler StrucForm.FxCxRumas.Closing, AddressOf Cargar_Ruma
            StrucForm.FxCxRumas.MdiParent = MdiParent
            StrucForm.FxCxRumas.L = Boolean.TrueString
            StrucForm.FxCxRumas.Show()
            StrucForm.FxCxRumas = Nothing
            Return
        End If

        If sender Is Btn9 Then
            If Grid7.Rows.Count <= 0 Then MsgBox("No hay Rumas a Quitar", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
            If Grid7.ActiveRow IsNot Nothing Then
                If Grid7.ActiveRow.Band.Index = 0 Then
                    CodRuma = Grid7.ActiveRow.Cells("CodRuma").Value

                    i = 0
                    While i < Tbl_Mineral.Rows.Count
                        If Tbl_Mineral.Rows(i)("CodRuma") = CodRuma Then
                            Tbl_Mineral.Rows.RemoveAt(i)
                        Else
                            i = i + 1
                        End If
                    End While

                    i = Grid7.ActiveRow.Index
                    Tbl_Ruma.Rows.RemoveAt(i)

                Else
                    MsgBox("Seleccione una Ruma", MsgBoxStyle.Exclamation, msgComacsa)
                End If
            End If
            Return
        End If

        If sender Is Btn10 Then

            StrucForm.FxCxProductos = New FrmCProductos
            AddHandler StrucForm.FxCxProductos.Closing, AddressOf Cargar_RumaxProducto
            StrucForm.FxCxProductos.MdiParent = MdiParent
            StrucForm.FxCxProductos.L = Boolean.TrueString
            StrucForm.FxCxProductos.RumaProd = Boolean.TrueString
            StrucForm.FxCxProductos.Show()
            StrucForm.FxCxProductos = Nothing
            Return

        End If

        If sender Is Btn11 Then
            If Grid8.Rows.Count <= 0 Then MsgBox("No hay Productos Terminados a Quitar", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub

            If Grid8.ActiveRow IsNot Nothing Then
                CodRuma = Grid8.ActiveRow.Cells("Codigo").Value.ToString
                Grid8.Rows(Grid8.ActiveRow.Index).Delete()
                Grid8.Update()
                Grid8.UpdateData()

                i = 0
                While i < Ls_RumaProd.Count
                    If CodRuma = Ls_RumaProd(i).CodRuma Then
                        Ls_RumaProd.RemoveAt(i)
                        Exit While
                    Else
                        i = i + 1
                    End If
                End While

            End If
            Return
        End If

        If sender Is Btn12 Then

            StrucForm.FxCxTSuministro = New frmCTSuministro
            AddHandler StrucForm.FxCxTSuministro.Closing, AddressOf Cargar_RumaxSuministro
            StrucForm.FxCxTSuministro.MdiParent = MdiParent
            StrucForm.FxCxTSuministro.L = Boolean.TrueString
            StrucForm.FxCxTSuministro.Show()
            StrucForm.FxCxTSuministro = Nothing
            Return

        End If

        If sender Is Btn13 Then
            If Grid6.Rows.Count <= 0 Then MsgBox("No hay Suministros a Quitar", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub

            If Grid6.ActiveRow IsNot Nothing Then
                CodRuma = Grid6.ActiveRow.Cells("Codigo").Value.ToString
                Grid6.Rows(Grid6.ActiveRow.Index).Delete()
                Grid6.Update()
                Grid6.UpdateData()

                i = 0
                While i < Ls_RumaSuministro.Count
                    If CodRuma = Ls_RumaSuministro(i).CodRuma Then
                        Ls_RumaSuministro.RemoveAt(i)
                        Exit While
                    Else
                        i = i + 1
                    End If
                End While

            End If
            Return
        End If

        If sender Is Btn14 Then

            StrucForm.FxCxProductos = New FrmCProductos
            AddHandler StrucForm.FxCxProductos.Closing, AddressOf Cargar_RumaxProductoRecirculado
            StrucForm.FxCxProductos.MdiParent = MdiParent
            StrucForm.FxCxProductos.L = Boolean.TrueString
            StrucForm.FxCxProductos.RumaProd = Boolean.TrueString
            StrucForm.FxCxProductos.Show()
            StrucForm.FxCxProductos = Nothing
            Return

        End If

        If sender Is Btn15 Then
            If Grid9.Rows.Count <= 0 Then MsgBox("No hay Productos Recirculados a Quitar", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub

            If Grid9.ActiveRow IsNot Nothing Then
                CodRuma = Grid9.ActiveRow.Cells("Codigo").Value.ToString
                Grid9.Rows(Grid9.ActiveRow.Index).Delete()
                Grid9.Update()
                Grid9.UpdateData()

                i = 0
                While i < Ls_RumaProdRecirculado.Count
                    If CodRuma = Ls_RumaProdRecirculado(i).CodRuma Then
                        Ls_RumaProdRecirculado.RemoveAt(i)
                        Exit While
                    Else
                        i = i + 1
                    End If
                End While

            End If
            Return
        End If

    End Sub

    Sub Evento_AfterExitEditMode(ByVal sender As Object, ByVal e As EventArgs) _
                                 Handles Num1.AfterExitEditMode

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Num1 Then Return

        If Not IsNumeric(sender.Value) Then Return

        Call ReProcesarUnidad(Grid3)

        Call ReProcesarUnidad(Grid4)

    End Sub

    Sub Evento_BeforeRowsDeleted(ByVal sender As Object, ByVal e As BeforeRowsDeletedEventArgs) _
                                 Handles Grid3.BeforeRowsDeleted, Grid4.BeforeRowsDeleted, _
                                 Grid6.BeforeRowsDeleted, Grid7.BeforeRowsDeleted, Grid8.BeforeRowsDeleted, _
                                 Grid9.BeforeRowsDeleted

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Grid3 OrElse sender Is Grid4 OrElse sender Is Grid6 _
                OrElse sender Is Grid7 OrElse sender Is Grid8 OrElse sender Is Grid9) Then Return

        e.DisplayPromptMsg = Boolean.FalseString

    End Sub

    Sub Evento_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call ScrollLabel(Lbl1)

    End Sub

#End Region

#Region "Procedimientos"

#Region "# Buscar"

    Sub Buscar_Orden(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        If String.IsNullOrEmpty(sender.NroDocumento) Then Return

        Ejecutar = Boolean.TrueString

        Call Consultar(Opcion.Orden, sender.NroDocumento)
        Call Controles(False)

    End Sub

    Sub Buscar_Producto(ByVal sender As Object, ByVal e As EventArgs)

        If Not sender.vCargar Then Return

        If String.IsNullOrEmpty(sender.CodProducto) Then Return

        CodProducto = sender.CodProducto
        Descripcion = sender.Descripcion

        Call Consultar(Opcion.Enlace, sender)

    End Sub

    Sub Buscar_PorStockMinimo()

        Call Nuevo()

        Entidad.Producto = New ETProducto
        Negocio.Producto = New NGProducto
        Ls_Enlace = New List(Of ETProducto)

        Entidad.Producto.CodProducto = CodProducto
        Ls_Enlace = Negocio.Producto.ConsultarEnlacexProducto(Entidad.Producto)

        Call Ingresar(Opcion.Enlace, Ls_Enlace)

        Num1.Value = Cantidad

    End Sub

    Sub Buscar_Unidad(ByVal sender As Object, ByVal e As EventArgs)

        If Not sender.vCargar Then Return

        If sender.Lista Is Nothing Then Return

        For Each Rpt As ETActivo In sender.Lista
            Call Consultar(Opcion.Activo, Rpt)
        Next

    End Sub

    Sub Cargar_RumaxSuministro(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        If Ls_RumaSuministro Is Nothing Then Ls_RumaSuministro = New List(Of ETRuma)

        For Each W As ETRuma In sender.Lista
            CodRuma = String.Empty : CodRuma = W.CodRuma

            If Not Ls_RumaSuministro.Exists(AddressOf Existe_Ruma) Then
                Call Consultar(Opcion.FormulacionSuministro, sender)
                Ls_RumaSuministro.Add(W)
            End If

            Call Ingresar(Opcion.FormulacionSuministro, Entidad.MyLista)
        Next

    End Sub

    Sub Cargar_RumaxProducto(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        If Ls_RumaProd Is Nothing Then Ls_RumaProd = New List(Of ETRuma)

        For Each W As ETRuma In sender.Lista
            CodRuma = String.Empty : CodRuma = W.CodRuma

            If Not Ls_RumaProd.Exists(AddressOf Existe_Ruma) Then
                Call Consultar(Opcion.FormulacionProducto, sender)
                Ls_RumaProd.Add(W)
            Else
                Entidad.MyLista = Nothing
                Entidad.MyLista = New ETMyLista
            End If

            Call Ingresar(Opcion.FormulacionProducto, Entidad.MyLista)
        Next
    End Sub

    Sub Cargar_RumaxProductoRecirculado(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        If Ls_RumaProdRecirculado Is Nothing Then Ls_RumaProdRecirculado = New List(Of ETRuma)

        For Each W As ETRuma In sender.Lista
            CodRuma = String.Empty : CodRuma = W.CodRuma

            If Not Ls_RumaProdRecirculado.Exists(AddressOf Existe_Ruma) Then
                Call Consultar(Opcion.FormulacionRecirculado, sender)
                Ls_RumaProdRecirculado.Add(W)
            Else
                Entidad.MyLista = Nothing
                Entidad.MyLista = New ETMyLista
            End If

            Call Ingresar(Opcion.FormulacionRecirculado, Entidad.MyLista)
        Next
    End Sub

    Sub Cargar_Ruma(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        If Tbl_Ruma Is Nothing Then Tbl_Ruma = New DataTable

        Dim StockRuma As Decimal = Decimal.Zero

        For Each W As ETRuma In sender.Lista
            CodRuma = String.Empty : CodRuma = W.CodRuma
            StockRuma = Decimal.Zero

            Call Consultar(Opcion.RumaMineral, sender)

            If Tbl_Ruma.Rows.Count > 0 Then
                If Ls_Ruma_Mineral.Count > 0 Then
                    StockRuma = Ls_Ruma_Mineral.Sum(Function(R) R.StockMineral)
                End If

                For Each xRow As DataRow In Tbl_Ruma.Rows
                    If xRow("CodRuma") <> CodRuma Then
                        Dim Fila As DataRow
                        Fila = Tbl_Ruma.Rows.Add()
                        Fila("CodRuma") = CodRuma
                        Fila("DesRuma") = W.Descripcion
                        Fila("ID") = Cbo1.Value
                        Fila("StockRecurso") = StockRuma
                        Fila("Cantidad") = Num1.Value
                        Fila("CantidadxFraccionada") = 0

                        Fila("Porcentaje") = 0
                        Fila("Humedad") = 0
                        Fila("Merma") = 0

                        Fila("CantidadxNecesaria") = 0
                        Fila("CostoxTON") = 0
                        Fila("SubTotal") = 0
                        Fila("Nuevo") = True

                        If Ls_Ruma_Mineral.Count > 0 Then
                            For Each yRow As ETRuma In Ls_Ruma_Mineral
                                Dim Fila2 As DataRow
                                Fila2 = Tbl_Mineral.Rows.Add()
                                Fila2("CodRuma") = CodRuma
                                Fila2("Codigo") = yRow.Codigo
                                Fila2("Descripcion") = yRow.Descripcion
                                Fila2("StockSubRecurso") = yRow.StockMineral
                                Fila2("CantidadxFraccionada") = yRow.CantidadxFraccionada
                                Fila2("CantidadxNecesaria") = yRow.CantidadxNecesaria
                                Fila2("CostoxExtraccion") = yRow.CostoxExtraccion
                                Fila2("CostoxCompra") = yRow.CostoxCompra
                                Fila2("CostoxRegalias") = yRow.CostoxRegalias
                                Fila2("CostoxFlete") = yRow.CostoxFlete
                                Fila2("CostoxOtros") = yRow.CostoxOtros
                                Fila2("CostoxTON") = yRow.CostoxRuma
                                Fila2("SubTotal") = yRow.CostoxRuma * yRow.CantidadxNecesaria
                                Fila2("Nuevo") = True
                            Next
                        End If
                        Ls_Ruma_Mineral = Nothing
                        Exit For
                    End If
                Next
            Else
                Dim Fila As DataRow
                Fila = Tbl_Ruma.Rows.Add()
                Fila("CodRuma") = CodRuma
                Fila("DesRuma") = W.Descripcion
                Fila("ID") = Cbo1.Value
                Fila("StockRecurso") = StockRuma
                Fila("Cantidad") = Num1.Value
                Fila("CantidadxFraccionada") = 0

                Fila("Porcentaje") = 0
                Fila("Humedad") = 0
                Fila("Merma") = 0

                Fila("CantidadxNecesaria") = 0
                Fila("CostoxTON") = 0
                Fila("SubTotal") = 0
                Fila("Nuevo") = True

                If Ls_Ruma_Mineral.Count > 0 Then
                    For Each yRow As ETRuma In Ls_Ruma_Mineral
                        Dim Fila2 As DataRow
                        Fila2 = Tbl_Mineral.Rows.Add()
                        Fila2("CodRuma") = CodRuma
                        Fila2("Codigo") = yRow.Codigo
                        Fila2("Descripcion") = yRow.Descripcion
                        Fila2("StockSubRecurso") = yRow.StockMineral
                        Fila2("CantidadxFraccionada") = yRow.CantidadxFraccionada
                        Fila2("CantidadxNecesaria") = yRow.CantidadxNecesaria
                        Fila2("CostoxExtraccion") = yRow.CostoxExtraccion
                        Fila2("CostoxCompra") = yRow.CostoxCompra
                        Fila2("CostoxRegalias") = yRow.CostoxRegalias
                        Fila2("CostoxFlete") = yRow.CostoxFlete
                        Fila2("CostoxOtros") = yRow.CostoxOtros
                        Fila2("CostoxTON") = yRow.CostoxRuma
                        Fila2("SubTotal") = yRow.CostoxRuma * yRow.CantidadxNecesaria
                        Fila2("Nuevo") = True
                    Next
                End If
                Ls_Ruma_Mineral = Nothing
            End If
        Next

        Dim Tbl1 As New DataTable
        Dim Tbl2 As New DataTable

        Tbl1 = Tbl_Ruma.Copy
        Tbl2 = Tbl_Mineral.Copy

        Ds_Ruma = Nothing
        Ds_Ruma = New DataSet


        Tbl_Ruma = Nothing
        Tbl_Mineral = Nothing

        Tbl_Ruma = New DataTable
        Tbl_Mineral = New DataTable

        Tbl_Ruma = Tbl1.Copy
        Tbl_Mineral = Tbl2.Copy

        Tbl_Ruma.TableName = "Ruma"
        Ds_Ruma.Tables.Add(Tbl_Ruma)
        Tbl_Mineral.TableName = "Mineral"
        Ds_Ruma.Tables.Add(Tbl_Mineral)

        Grid7.DataSource = Nothing

        Dim ColPk1 As DataColumn = Tbl_Ruma.Columns("CodRuma")
        Dim ColPk2 As DataColumn = Tbl_Mineral.Columns("CodRuma")

        Dim DtRelacion As DataRelation
        DtRelacion = Nothing
        DtRelacion = New DataRelation("PK_Ruma", ColPk1, ColPk2, False)
        Ds_Ruma.Relations.Add(DtRelacion)

        Call CargarUltraGrid(Grid7, Ds_Ruma)

    End Sub

#End Region

#Region "# Adicionales"

    Sub Limpiar()

        Bucle = Ejecutar

        Ejecutar = Boolean.FalseString
        Ep1.Clear()
        ReprocesarRuma = False
        Ls_Enlace = Nothing
        Ls_Enlace = New List(Of ETProducto)
        Ls_Ruma = Nothing
        Ls_Ruma = New List(Of ETRuma)
        Ls_Ruma_Temp = Nothing
        Ls_Ruma_Temp = New List(Of ETRuma)
        Ls_Ruma_Mineral = Nothing
        Ls_Ruma_Mineral = New List(Of ETRuma)
        Ls_RumaSuministro = Nothing
        Ls_RumaSuministro = New List(Of ETRuma)
        Ls_RumaProdRecirculado = Nothing
        Ls_RumaProdRecirculado = New List(Of ETRuma)
        Ls_Empaque = Nothing
        Ls_Empaque = New List(Of ETSuministro)
        Ls_Chancadora = Nothing
        Ls_Chancadora = New List(Of ETActivo)
        Ls_Molino = Nothing
        Ls_Molino = New List(Of ETActivo)

        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Txt3.Value = String.Empty
        Txt4.Value = String.Empty
        Chk1.Checked = False
        Num1.Value = Decimal.Zero
        Num2.Value = Decimal.Zero
        Num3.Value = Decimal.Zero
        Num4.Value = Decimal.Zero
        Num5.Value = Decimal.Zero
        Num6.Value = Decimal.Zero
        Num7.Value = Decimal.Zero
        Cbo2.Value = "P"
        Dt1.Value = Now
        Dt2.Value = DBNull.Value
        Dt3.Value = DBNull.Value


        Uds1.Rows.Clear()
        Uds2.Rows.Clear()
        UdsProducto.Rows.Clear()
        UdsSuministro.Rows.Clear()

        If Grid7.DataSource IsNot Nothing Then
            Dim ds As New DataSet
            ds = Grid7.DataSource
            ds.Tables(1).Clear()
            ds.Tables(0).Clear()
            Call CargarUltraGrid(Grid7, ds)
        End If


        Call CargarUltraCombo(Cbo1, Ls_Enlace, "ID", "ID")
        Call CargarUltraGrid(Grid8, UdsProducto)
        Call CargarUltraGrid(Grid6, UdsSuministro)
        Call CargarUltraGrid(Grid2, Uds2)
        Call CargarUltraGrid(Grid3, Ls_Chancadora)
        Call CargarUltraGrid(Grid4, Ls_Molino)

        Ejecutar = Bucle

    End Sub

    Sub Controles(ByVal Rpt As Boolean)

        Cbo1.ReadOnly = Not Rpt
        Num1.ReadOnly = Not Rpt
        Cbo2.ReadOnly = Not Rpt
        Dt3.ReadOnly = Not Rpt
        Txt4.ReadOnly = Not Rpt

        Btn2.Enabled = Rpt
        Btn3.Enabled = Rpt
        Btn4.Enabled = Rpt
        Btn5.Enabled = Rpt
        Btn6.Enabled = Rpt
        Btn7.Enabled = Rpt
        Btn8.Enabled = Rpt
        Btn9.Enabled = Rpt

        Btn10.Enabled = Rpt
        Btn11.Enabled = Rpt
        Btn12.Enabled = Rpt
        Btn13.Enabled = Rpt
        Btn14.Enabled = Rpt
        Btn15.Enabled = Rpt

        If Rpt Then

            Grid2.DisplayLayout.Bands(0).Columns("CantidadUnitaria").CellActivation = Activation.AllowEdit
            Grid3.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True
            Grid4.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True

            Grid6.DisplayLayout.Bands(0).Columns("Porcentaje").CellActivation = Activation.AllowEdit
            Grid7.DisplayLayout.Bands(0).Columns("Porcentaje").CellActivation = Activation.AllowEdit
            Grid8.DisplayLayout.Bands(0).Columns("Porcentaje").CellActivation = Activation.AllowEdit
            Grid9.DisplayLayout.Bands(0).Columns("Porcentaje").CellActivation = Activation.AllowEdit
            Grid6.DisplayLayout.Bands(0).Columns("Humedad").CellActivation = Activation.AllowEdit
            Grid7.DisplayLayout.Bands(0).Columns("Humedad").CellActivation = Activation.AllowEdit
            Grid8.DisplayLayout.Bands(0).Columns("Humedad").CellActivation = Activation.AllowEdit
            Grid9.DisplayLayout.Bands(0).Columns("Humedad").CellActivation = Activation.AllowEdit
            Grid6.DisplayLayout.Bands(0).Columns("Merma").CellActivation = Activation.AllowEdit
            Grid7.DisplayLayout.Bands(0).Columns("Merma").CellActivation = Activation.AllowEdit
            Grid8.DisplayLayout.Bands(0).Columns("Merma").CellActivation = Activation.AllowEdit
            Grid9.DisplayLayout.Bands(0).Columns("Merma").CellActivation = Activation.AllowEdit

            Grid6.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True
            Grid7.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True
            Grid8.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True
            Grid9.DisplayLayout.Override.AllowDelete = DefaultableBoolean.True

        Else
            Grid2.DisplayLayout.Bands(0).Columns("CantidadUnitaria").CellActivation = Activation.ActivateOnly
            Grid3.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
            Grid4.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False

            Grid6.DisplayLayout.Bands(0).Columns("Porcentaje").CellActivation = Activation.ActivateOnly
            Grid7.DisplayLayout.Bands(0).Columns("Porcentaje").CellActivation = Activation.ActivateOnly
            Grid8.DisplayLayout.Bands(0).Columns("Porcentaje").CellActivation = Activation.ActivateOnly
            Grid9.DisplayLayout.Bands(0).Columns("Porcentaje").CellActivation = Activation.ActivateOnly
            Grid6.DisplayLayout.Bands(0).Columns("Humedad").CellActivation = Activation.ActivateOnly
            Grid7.DisplayLayout.Bands(0).Columns("Humedad").CellActivation = Activation.ActivateOnly
            Grid8.DisplayLayout.Bands(0).Columns("Humedad").CellActivation = Activation.ActivateOnly
            Grid9.DisplayLayout.Bands(0).Columns("Humedad").CellActivation = Activation.ActivateOnly
            Grid6.DisplayLayout.Bands(0).Columns("Merma").CellActivation = Activation.ActivateOnly
            Grid7.DisplayLayout.Bands(0).Columns("Merma").CellActivation = Activation.ActivateOnly
            Grid8.DisplayLayout.Bands(0).Columns("Merma").CellActivation = Activation.ActivateOnly
            Grid9.DisplayLayout.Bands(0).Columns("Merma").CellActivation = Activation.ActivateOnly

            Grid6.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
            Grid7.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
            Grid8.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False
            Grid9.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False

        End If

    End Sub

    Sub ReProcesarUnidad(ByVal Grid As UltraGrid)

        If Grid Is Nothing Then
            Return
        End If

        Dim CantProdTON As Decimal = Decimal.Zero

        If Grid Is Grid3 Then
            CantProdTON = Num3.Value - IIf(IsDBNull(Num7.Value), 0, Num7.Value)


        ElseIf Grid Is Grid4 Then
            CantProdTON = IIf(IsDBNull(Num1.Value), 0, Num1.Value)
        End If

        Dim DecSum As Decimal = Decimal.Zero

        For Each xRow As UltraGridRow In Grid.Rows
            xRow.Cells("TonUtilizado").Value = Decimal.Zero
            xRow.Cells("Uso").Value = Decimal.Zero
            xRow.Cells("SubTotal").Value = Decimal.Zero
        Next

        For Each xRow As UltraGridRow In Grid.Rows

            If CantProdTON > Decimal.Add(DecSum, xRow.Cells("TonMaximo").Value) Then
                xRow.Cells("TonUtilizado").Value = xRow.Cells("TonMaximo").Value
            Else
                xRow.Cells("TonUtilizado").Value = CantProdTON - DecSum
            End If

            DecSum += xRow.Cells("TonUtilizado").Value

            If Decimal.Compare(xRow.Cells("TonMaximo").Value, Decimal.Zero) <> 0 Then
                xRow.Cells("Uso").Value = Int(Decimal.Multiply(Decimal.Divide(xRow.Cells("TonUtilizado").Value, xRow.Cells("TonMaximo").Value), 100))
            End If

            xRow.Cells("SubTotal").Value = Decimal.Multiply(xRow.Cells("TonUtilizado").Value, xRow.Cells("CostoxTon").Value)

        Next

        If Grid Is Grid4 Then
            Num4.Value = DecSum
        ElseIf Grid Is Grid3 Then
            Num6.Value = DecSum
        End If
    End Sub

    Sub Ingresar(ByVal Tipo As Int16, ByVal sender As Object)

        If sender Is Nothing Then
            Return
        End If

        If Tipo = Opcion.Orden Then

            Ope = 0
            Cbo1.Value = sender.CodEnlace
            Txt1.Value = sender.NroDocumento
            Dt1.Value = sender.Fecha
            Dt2.Value = IIf(sender.FechaActualizacion = FechaMinimaBD OrElse _
                            Not IsDate(sender.FechaActualizacion), DBNull.Value, sender.FechaActualizacion)
            Txt2.Value = CodProducto
            Txt3.Value = Descripcion
            Num1.Value = sender.Cantidad
            Num3.Value = sender.CantidadRequerida
            Num7.Value = sender.CantidadRecirculado

            Dt3.Value = sender.FechaIngreso
            Txt4.Value = sender.Especificaciones
            Chk1.Checked = sender.FormulaRecirculado
            If String.IsNullOrEmpty(sender.Status.Trim()) Then
                Cbo2.Value = "P"
            Else
                Cbo2.Value = sender.Status
            End If

        End If


        If Tipo = Opcion.Enlace Then
            If sender.Count = 0 Then
                Ejecutar = Boolean.FalseString
                Return
            Else
                Txt3.Value = Descripcion
                Txt2.Value = CodProducto
            End If

            If Ope = 1 Then
                ReprocesarRuma = True
            End If

            Call CargarUltraCombo(Cbo1, sender, "ID", "ID")
        End If

        If Tipo = Opcion.FormulacionRecirculado Then
            For Each W As ETRuma In sender.Ls_Formulacion_Recirculado
                uRow = Nothing
                uRow = UdsProdRecirculado.Rows.Add()
                uRow("ID") = W.ID
                uRow("Codigo") = W.Codigo
                uRow("Descripcion") = W.Descripcion
                uRow("Porcentaje") = W.Porcentaje
                uRow("Humedad") = W.Humedad
                uRow("Merma") = W.Merma
                uRow("StockRecurso") = W.StockRuma
                uRow("CostoxTON") = W.CostoxRuma
                Call CargarUltraGrid(Grid9, UdsProdRecirculado)
            Next
        End If

        If Tipo = Opcion.FormulacionProducto Then
            For Each W As ETRuma In sender.Ls_Formulacion_Producto
                uRow = Nothing
                uRow = UdsProducto.Rows.Add()
                uRow("ID") = W.ID
                uRow("Codigo") = W.Codigo
                uRow("Descripcion") = W.Descripcion
                uRow("Porcentaje") = W.Porcentaje
                uRow("Humedad") = W.Humedad
                uRow("Merma") = W.Merma
                uRow("StockRecurso") = W.StockRuma
                uRow("CostoxTON") = W.CostoxRuma
                Call CargarUltraGrid(Grid8, UdsProducto)
            Next
        End If

        If Tipo = Opcion.FormulacionSuministro Then
            For Each W As ETRuma In sender.Ls_Formulacion_Suministro
                uRow = Nothing
                uRow = UdsSuministro.Rows.Add()
                uRow("ID") = W.ID
                uRow("Codigo") = W.Codigo
                uRow("Descripcion") = W.Descripcion
                uRow("Porcentaje") = W.Porcentaje
                uRow("Humedad") = W.Humedad
                uRow("Merma") = W.Merma
                uRow("StockRecurso") = W.StockRuma
                uRow("CostoxTON") = W.CostoxRuma
                Call CargarUltraGrid(Grid6, UdsSuministro)
            Next
        End If

        If Tipo = Opcion.Ruma Then REM RUMA
            Ls_RumaProd = Nothing
            Ls_RumaProd = New List(Of ETRuma)

            Ls_RumaSuministro = Nothing
            Ls_RumaSuministro = New List(Of ETRuma)

            Ls_RumaProdRecirculado = Nothing
            Ls_RumaProdRecirculado = New List(Of ETRuma)

            UdsProducto.Rows.Clear()
            UdsSuministro.Rows.Clear()
            UdsProdRecirculado.Rows.Clear()

            For Each W As ETRuma In sender.Ls_Ruma
                uRow = Nothing
                Select Case W.TipoEnlace
                    Case "PRODUCTO"
                        uRow = UdsProducto.Rows.Add()
                    Case "RECIRCULADO"
                        uRow = UdsProdRecirculado.Rows.Add()
                    Case "SUMINISTRO"
                        uRow = UdsSuministro.Rows.Add()
                End Select

                uRow("ID") = W.ID
                uRow("Nuevo") = W.Nuevo
                uRow("Codigo") = W.Codigo
                uRow("Descripcion") = W.Descripcion
                uRow("Porcentaje") = W.Porcentaje
                uRow("Humedad") = W.Humedad
                uRow("Merma") = W.Merma
                uRow("StockRecurso") = W.StockRuma
                uRow("CostoxTON") = W.CostoxRuma
            Next

            Ls_RumaProd = sender.Ls_Formulacion_Producto
            Ls_RumaSuministro = sender.Ls_Formulacion_Suministro
            Ls_RumaProdRecirculado = sender.Ls_Formulacion_Recirculado
            Ds_Ruma = Nothing
            Tbl_Ruma = Nothing
            Tbl_Mineral = Nothing
            Ds_Ruma = New DataSet
            Tbl_Ruma = New DataTable
            Tbl_Mineral = New DataTable

            Tbl_Ruma = sender.DataTable1.copy
            Tbl_Ruma.TableName = "Ruma"
            Ds_Ruma.Tables.Add(Tbl_Ruma)
            Tbl_Mineral = sender.DataTable2.copy
            Tbl_Mineral.TableName = "Mineral"
            Ds_Ruma.Tables.Add(Tbl_Mineral)

            Grid7.DataSource = Nothing

            Dim ColPk1 As DataColumn = Tbl_Ruma.Columns("CodRuma")
            Dim ColPk2 As DataColumn = Tbl_Mineral.Columns("CodRuma")

            Dim DtRelacion As DataRelation
            DtRelacion = Nothing
            DtRelacion = New DataRelation("PK_Ruma", ColPk1, ColPk2, False)
            Ds_Ruma.Relations.Add(DtRelacion)

            Call CargarUltraGrid(Grid7, Ds_Ruma)
            Call CargarUltraGrid(Grid8, UdsProducto)
            Call CargarUltraGrid(Grid6, UdsSuministro)
            Call CargarUltraGrid(Grid9, UdsProdRecirculado)
        End If

        If Tipo = Opcion.Empaque Then REM EMPAQUE
            For Each W As ETSuministro In sender
                uRow = Nothing
                uRow = Uds2.Rows.Add()
                uRow("CodSuministro") = W.CodSuministro
                uRow("Descripcion") = W.Descripcion
                uRow("Peso") = W.Peso
                uRow("Unidad") = W.Unidad
                uRow("UndDesp") = W.UndDesp
                uRow("CostoUnitario") = W.CostoUnitario
                uRow("CantidadUnitaria") = W.CantidadUnitaria
                uRow("Cantidad") = Num1.Value
            Next
            Call CargarUltraGrid(Grid2, Uds2)
            Num5.Value = Grid2.Rows.Count
        End If

        If Tipo = Opcion.Activo Then REM ACTIVOS
            With sender
                Negocio.Activo = New NGActivo
                If .CodTipo = StrucActivos.Chancadora Then
                    Ls_Chancadora.Add(sender)
                    Call Negocio.Activo.Ordenar_Activo(Ls_Chancadora)
                    Call CargarUltraGrid(Grid3, Ls_Chancadora)
                    Call ReProcesarUnidad(Grid3)
                End If
                If .CodTipo = StrucActivos.Molino Then
                    Ls_Molino.Add(sender)
                    Call Negocio.Activo.Ordenar_Activo(Ls_Molino)
                    Call CargarUltraGrid(Grid4, Ls_Molino)
                    Call ReProcesarUnidad(Grid4)
                End If
            End With
        End If

        If Tipo = Opcion.Chancadora Then
            Call CargarUltraGrid(Grid3, Ls_Chancadora)
            Call ReProcesarUnidad(Grid3)
        End If

        If Tipo = Opcion.Molino Then
            Call CargarUltraGrid(Grid4, Ls_Molino)
            Call ReProcesarUnidad(Grid4)
        End If

    End Sub

    Sub Consultar(ByVal Tipo As Int16, ByVal sender As Object)

        If sender Is Nothing Then
            Return
        End If


        If Not Ejecutar Then Return

        Dim fecha As DateTime = Now

        Entidad.Activo = New ETActivo
        Entidad.Producto = New ETProducto
        Entidad.Orden = New ETOrden

        Negocio.Activo = New NGActivo
        Negocio.Producto = New NGProducto
        Negocio.Reporte = New NGReporte
        Negocio.Ruma = New NGRuma
        Negocio.Suministro = New NGSuministro

        If Tipo = Opcion.Enlace Then
            Ls_Enlace = New List(Of ETProducto)
            Entidad.Producto.CodProducto = sender.CodProducto
            Ls_Enlace = Negocio.Producto.ConsultarEnlacexProducto(Entidad.Producto)
            Call Ingresar(Tipo, Ls_Enlace)
            Return
        End If

        If Tipo = Opcion.Ruma Then
            Entidad.MyLista = New ETMyLista
            Entidad.Producto.CodProducto = Txt2.Value
            Entidad.Producto.Cantidad = Num1.Value
            Entidad.Producto.ID = IIf(Cbo1.Value IsNot Nothing, Cbo1.Value, 0)

            fecha = CDate(Dt3.Value).Date
            fecha = DateAdd(DateInterval.Day, 1, fecha)
            fecha = DateAdd(DateInterval.Second, -1, fecha)
            Entidad.Producto.FechaTerminacion = fecha
            Entidad.MyLista = Negocio.Ruma.CuadroxOrdenxRumaxProductoxSuministro_Relacion(Entidad.Producto)
            Call Ingresar(Tipo, Entidad.MyLista)
            Return
        End If

        If Tipo = Opcion.RumaMineral Then
            Ls_Ruma_Mineral = Nothing
            Ls_Ruma_Mineral = New List(Of ETRuma)
            Entidad.Producto.CodProducto = CodRuma
            fecha = CDate(Dt3.Value).Date
            fecha = DateAdd(DateInterval.Day, 1, fecha)
            fecha = DateAdd(DateInterval.Second, -1, fecha)
            Entidad.Producto.FechaTerminacion = fecha

            Ls_Ruma_Mineral = Negocio.Ruma.CuadroxOrdenxRumaxMineral(Entidad.Producto)

            Return
        End If

        If Tipo = Opcion.FormulacionProducto Then
            Entidad.Producto.CodProducto = CodRuma
            fecha = CDate(Dt3.Value).Date
            fecha = DateAdd(DateInterval.Day, 1, fecha)
            fecha = DateAdd(DateInterval.Second, -1, fecha)
            Entidad.Producto.FechaTerminacion = fecha
            Entidad.Producto.TipoProducto = "P"
            Entidad.Producto.ID = Cbo1.Value
            Entidad.MyLista = New ETMyLista
            Entidad.MyLista.Ls_Formulacion_Producto = Negocio.Ruma.CuadroxOrdenxProdTerminadoxSuministro(Entidad.Producto)

            Return
        End If


        If Tipo = Opcion.FormulacionSuministro Then
           
            Entidad.Producto.CodProducto = CodRuma
            fecha = CDate(Dt3.Value).Date
            fecha = DateAdd(DateInterval.Day, 1, fecha)
            fecha = DateAdd(DateInterval.Second, -1, fecha)
            Entidad.Producto.FechaTerminacion = fecha
            Entidad.Producto.TipoProducto = "S"
            Entidad.MyLista = New ETMyLista
            Entidad.MyLista.Ls_Formulacion_Suministro = Negocio.Ruma.CuadroxOrdenxProdTerminadoxSuministro(Entidad.Producto)

            Return
        End If


        If Tipo = Opcion.FormulacionRecirculado Then
            
            Entidad.Producto.CodProducto = CodRuma
            fecha = CDate(Dt3.Value).Date
            fecha = DateAdd(DateInterval.Day, 1, fecha)
            fecha = DateAdd(DateInterval.Second, -1, fecha)
            Entidad.Producto.FechaTerminacion = fecha
            Entidad.Producto.TipoProducto = "R"
            Entidad.MyLista = New ETMyLista
            Entidad.MyLista.Ls_Formulacion_Recirculado = Negocio.Ruma.CuadroxOrdenxProdTerminadoxSuministro(Entidad.Producto)

            Return
        End If

        If Tipo = Opcion.Empaque Then
            Ls_Empaque = New List(Of ETSuministro)
            Entidad.Producto.CodProducto = sender.Value
            Entidad.Producto.FechaTerminacion = Dt3.Value
            Ls_Empaque = Negocio.Suministro.CuadroxOrdenxSuministro(Entidad.Producto)
            Call Ingresar(Tipo, Ls_Empaque)
            Return
        End If

        If Tipo = Opcion.Activo Then
            Entidad.Activo.CodClase = sender.CodClase
            Entidad.Activo.CodTipo = sender.CodTipo
            Entidad.Activo.Placa = sender.Placa
            Entidad.Activo.Descripcion = sender.Descripcion
            Entidad.Activo.Fecha = sender.Fecha
            Entidad.Activo.Turno = sender.Turno
            Entidad.Activo.NroOperarios = sender.NroOperarios
            Entidad.Producto.CodProducto = Txt2.Value
            Entidad.Activo.Horas = sender.Horas
            Entidad.Activo.HorasMax = sender.HorasMax

            If sender.CodTipo = "02" Then
                Entidad.Producto.Cantidad = Num3.Value - IIf(IsDBNull(Num7.Value), 0, Num7.Value)
            Else
                Entidad.Producto.Cantidad = Num1.Value
            End If
            Entidad.Producto.ID = Cbo1.Value

            If Not Verificar_Unidad(Entidad.Activo, IIf(Entidad.Activo.CodTipo = StrucActivos.Chancadora, Ls_Chancadora, Ls_Molino)) Then Exit Sub
            Entidad.Activo = Negocio.Activo.CuadroxOrdenxUnidad(Entidad.Producto, Entidad.Activo)
            Call Ingresar(Tipo, Entidad.Activo)
            Return
        End If

        If Tipo = Opcion.Orden Then

            Call Limpiar()
            Ejecutar = Boolean.FalseString

            REM Orden    --------------------------------------------

            Entidad.Orden.NroDocumento = sender
            Entidad.MyLista = New ETMyLista

            Entidad.MyLista = Negocio.Orden.ConsultarOrden2(Entidad.Orden)

            If Entidad.MyLista.Validacion Then Entidad.Orden = Entidad.MyLista.Ls_Orden.First()

            REM Datos Adicionales -----------------------------------

            Entidad.Producto.ID = Entidad.Orden.CodEnlace
            Entidad.Producto.CodProducto = Entidad.Orden.CodProducto
            Entidad.Producto.Cantidad = Entidad.Orden.Cantidad
            Entidad.Producto.Tipo = 2

            Fecha = Entidad.Orden.FechaIngreso.Date
            Fecha = DateAdd(DateInterval.Day, 1, Fecha)
            Fecha = DateAdd(DateInterval.Second, -1, Fecha)
            Entidad.Producto.FechaTerminacion = Fecha
            CodProducto = Entidad.Orden.CodProducto
            Descripcion = Entidad.Orden.Descripcion

            REM Enlace   --------------------------------------------

            Ls_Enlace = Negocio.Producto.ConsultarEnlacexProducto(Entidad.Producto)

            REM Rumas    --------------------------------------------

            Dim Ls1 As New List(Of ETRuma)
            Dim Ls2 As New List(Of ETRuma)

            Dim Ls1_1 As New List(Of ETRuma)
            Dim Ls2_1 As New List(Of ETRuma)
            Dim Ls1_2 As New List(Of ETRuma)
            Dim Ls2_2 As New List(Of ETRuma)
            Dim Ls1_3 As New List(Of ETRuma)
            Dim Ls2_3 As New List(Of ETRuma)

            Entidad.MyLista = New ETMyLista
            Entidad.MyLista = Negocio.Orden.ConsultarOrden3(Entidad.Orden)

            If Entidad.MyLista.Validacion Then
                Ls1 = Entidad.MyLista.Ls_Ruma
                Ls1_1 = Entidad.MyLista.Ls_Formulacion_Producto
                Ls1_2 = Entidad.MyLista.Ls_Formulacion_Suministro
                Ls1_3 = Entidad.MyLista.Ls_Formulacion_Recirculado
            End If

            Dim ObjLista As New ETMyLista

            ObjLista = Negocio.Ruma.CuadroxOrdenxRumaxProductoxSuministro_Relacion(Entidad.Producto)

            Ls2 = ObjLista.Ls_Ruma
            Ls2_1 = Entidad.MyLista.Ls_Formulacion_Producto
            Ls2_2 = Entidad.MyLista.Ls_Formulacion_Suministro
            Ls2_3 = Entidad.MyLista.Ls_Formulacion_Recirculado

            Dim Tbl_Ruma_Temp As New DataTable
            Dim Tbl_Mineral_Temp As New DataTable

            Ls_Ruma = FiltrarConsultaRuma(Ls1, Ls2)
            Ls_RumaProd = FiltrarConsultaRuma(Ls1_1, Ls2_1)
            Ls_RumaSuministro = FiltrarConsultaRuma(Ls1_2, Ls2_2)
            Ls_RumaProdRecirculado = FiltrarConsultaRuma(Ls1_3, Ls2_3)
            
            Tbl_Ruma_Temp = FiltrarConsultaRumaxDataTable1(Entidad.MyLista.DataTable1, ObjLista.DataTable1)
            Tbl_Mineral_Temp = FiltrarConsultaRumaxDataTable2(Entidad.MyLista.DataTable2, ObjLista.DataTable2)
            ObjLista = Nothing

            Dim DataRuma As New ETMyLista
            DataRuma.Ls_Ruma = Ls_Ruma
            DataRuma.DataTable1 = Tbl_Ruma_Temp
            DataRuma.DataTable2 = Tbl_Mineral_Temp
            DataRuma.Validacion = True


            REM Empaques --------------------------------------------

            Dim Ls3 As New List(Of ETSuministro)
            Dim Ls4 As New List(Of ETSuministro)

            Entidad.MyLista = New ETMyLista
            Entidad.MyLista = Negocio.Orden.ConsultarOrden4(Entidad.Orden)

            If Entidad.MyLista.Validacion Then Ls3 = Entidad.MyLista.Ls_Suministro

            Ls4 = Negocio.Suministro.CuadroxOrdenxSuministro(Entidad.Producto)

            Ls_Empaque = FiltrarConsultaSuministro(Ls3, Ls4)


            REM Chancadoras -----------------------------------------

            Entidad.Activo.CodTipo = StrucActivos.Chancadora
            Ls_Chancadora = Negocio.Orden.ConsultarOrden5(Entidad.Orden, Entidad.Activo)

            REM Molinos    ------------------------------------------

            Entidad.Activo.CodTipo = StrucActivos.Molino
            Ls_Molino = Negocio.Orden.ConsultarOrden5(Entidad.Orden, Entidad.Activo)

            REM -----------------------------------------------------

            Call Ingresar(Opcion.Enlace, Ls_Enlace)

            Call Ingresar(Opcion.Orden, Entidad.Orden)

            Call Ingresar(Opcion.Ruma, DataRuma)

            Call Ingresar(Opcion.Empaque, Ls_Empaque)

            Call Ingresar(Opcion.Chancadora, Ls_Chancadora)

            Call Ingresar(Opcion.Molino, Ls_Molino)


        End If

    End Sub

#End Region

    Sub Grabar_Orden()

        Entidad.Orden = New ETOrden
        Ls_Ruma = New List(Of ETRuma)
        Ls_Empaque = New List(Of ETSuministro)

        Grid7.PerformAction(ExitEditMode)
        Grid2.PerformAction(ExitEditMode)
        Grid3.PerformAction(ExitEditMode)
        Grid4.PerformAction(ExitEditMode)
        Grid8.PerformAction(ExitEditMode)
        Grid6.PerformAction(ExitEditMode)
        Grid9.PerformAction(ExitEditMode)

        Grid7.PerformAction(EnterEditMode)
        Grid2.PerformAction(EnterEditMode)
        Grid3.PerformAction(EnterEditMode)
        Grid4.PerformAction(EnterEditMode)
        Grid8.PerformAction(EnterEditMode)
        Grid6.PerformAction(EnterEditMode)
        Grid9.PerformAction(EnterEditMode)

        Entidad.Orden.NroDocumento = Txt1.Value
        Entidad.Orden.CodEnlace = Cbo1.Value
        Entidad.Orden.CodProducto = Txt2.Value
        Entidad.Orden.Descripcion = Txt3.Value
        Entidad.Orden.Cantidad = Num1.Value
        Entidad.Orden.CantidadRequerida = Num3.Value
        Entidad.Orden.CantidadRecirculado = Num7.Value
        Entidad.Orden.FechaIngreso = Dt3.Value
        Entidad.Orden.Especificaciones = Txt4.Value
        Entidad.Orden.FormulaRecirculado = Chk1.Checked
        Entidad.Orden.Usuario = User_Sistema
        Entidad.Orden.Status = IIf(Cbo2.Value = "P", "", Cbo2.Value)

        Negocio.Orden = New NGOrden

        Dim dsRuma As New DataSet
        Dim DtRuma As New DataTable
        Dim DtMineral As New DataTable
        dsRuma = Grid7.DataSource
        DtRuma = dsRuma.Tables("Ruma")
        DtMineral = dsRuma.Tables("Mineral")

        For Each xRow As DataRow In DtRuma.Rows
            For Each yRow As DataRow In DtMineral.Rows
                If xRow("CodRuma") = yRow("CodRuma") Then
                    Entidad.Ruma = New ETRuma
                    With Entidad.Ruma
                        .TipoEnlace = "RUMA"
                        .ID = xRow("ID")
                        .CodRuma = xRow("CodRuma")
                        .DesRuma = xRow("DesRuma")
                        .Codigo = yRow("Codigo")
                        .Descripcion = yRow("Descripcion")
                        .Porcentaje = xRow("Porcentaje")
                        .Humedad = xRow("Humedad")
                        .Merma = xRow("Merma")
                        .Cantidad = xRow("Cantidad")
                        .StockRuma = xRow("StockRecurso")
                        .StockMineral = yRow("StockSubRecurso")
                        .CantidadxFraccionada = xRow("CantidadxFraccionada")
                        .CantidadSubRecurso = yRow("CantidadxFraccionada")
                        .CantidadxNecesaria = yRow("CantidadxNecesaria")
                        .CantxRumaxNecesaria = xRow("CantidadxNecesaria")
                        .CostoxExtraccion = yRow("CostoxExtraccion")
                        .CostoxCompra = yRow("CostoxCompra")
                        .CostoxRegalias = yRow("CostoxRegalias")
                        .CostoxFlete = yRow("CostoxFlete")
                        .CostoxOtros = yRow("CostoxOtros")
                        .CostoxRuma = yRow("CostoxTON")
                        .SubTotal = yRow("SubTotal")
                    End With
                    Ls_Ruma.Add(Entidad.Ruma)
                End If
            Next
        Next

        'For Each xRow As UltraGridRow In Grid7.Rows
        '    Entidad.Ruma = New ETRuma
        '    With Entidad.Ruma
        '        .TipoEnlace = "RUMA"
        '        .ID = xRow.Cells("ID").Value
        '        .CodRuma = xRow.Cells("CodRuma").Value
        '        .DesRuma = xRow.Cells("DesRuma").Value
        '        .Codigo = xRow.Cells("Codigo").Value
        '        .Descripcion = xRow.Cells("Descripcion").Value
        '        .Porcentaje = xRow.Cells("Porcentaje").Value
        '        .Humedad = xRow.Cells("Humedad").Value
        '        .Merma = xRow.Cells("Merma").Value
        '        .Cantidad = xRow.Cells("Cantidad").Value
        '        .StockRuma = xRow.Cells("StockRecurso").Value
        '        .StockMineral = xRow.Cells("StockSubRecurso").Value
        '        .CantidadxFraccionada = xRow.Cells("CantidadxFraccionada").Value
        '        .CantidadSubRecurso = xRow.Cells("CantidadSubRecurso").Value
        '        .CantidadxNecesaria = xRow.Cells("CantidadxNecesaria").Value
        '        .CostoxExtraccion = xRow.Cells("CostoxExtraccion").Value
        '        .CostoxCompra = xRow.Cells("CostoxCompra").Value
        '        .CostoxRegalias = xRow.Cells("CostoxRegalia").Value
        '        .CostoxFlete = xRow.Cells("CostoxFlete").Value
        '        .CostoxOtros = xRow.Cells("CostoxOtros").Value
        '        .CostoxRuma = xRow.Cells("CostoxTON").Value
        '        .SubTotal = xRow.Cells("SubTotal").Value
        '    End With
        '    Ls_Ruma.Add(Entidad.Ruma)
        'Next

        For Each xRow As UltraGridRow In Grid8.Rows
            Entidad.Ruma = New ETRuma
            With Entidad.Ruma
                .TipoEnlace = "PRODUCTO"
                .ID = xRow.Cells("ID").Value
                .Codigo = xRow.Cells("Codigo").Value
                .Descripcion = xRow.Cells("Descripcion").Value
                .Porcentaje = xRow.Cells("Porcentaje").Value
                .Humedad = xRow.Cells("Humedad").Value
                .Merma = xRow.Cells("Merma").Value
                .Cantidad = xRow.Cells("Cantidad").Value
                .StockRuma = xRow.Cells("StockRecurso").Value
                .CantidadxFraccionada = xRow.Cells("CantidadxFraccionada").Value
                .CantidadxNecesaria = xRow.Cells("CantidadxNecesaria").Value
                .CostoxRuma = xRow.Cells("CostoxTON").Value
                .SubTotal = xRow.Cells("SubTotal").Value
            End With
            Ls_Ruma.Add(Entidad.Ruma)
        Next

        For Each xRow As UltraGridRow In Grid6.Rows
            Entidad.Ruma = New ETRuma
            With Entidad.Ruma
                .TipoEnlace = "SUMINISTRO"
                .ID = xRow.Cells("ID").Value
                .Codigo = xRow.Cells("Codigo").Value
                .Descripcion = xRow.Cells("Descripcion").Value
                .Porcentaje = xRow.Cells("Porcentaje").Value
                .Humedad = xRow.Cells("Humedad").Value
                .Merma = xRow.Cells("Merma").Value
                .Cantidad = xRow.Cells("Cantidad").Value
                .StockRuma = xRow.Cells("StockRecurso").Value
                .CantidadxFraccionada = xRow.Cells("CantidadxFraccionada").Value
                .CantidadxNecesaria = xRow.Cells("CantidadxNecesaria").Value
                .CostoxRuma = xRow.Cells("CostoxTON").Value
                .SubTotal = xRow.Cells("SubTotal").Value
            End With
            Ls_Ruma.Add(Entidad.Ruma)
        Next

        For Each xRow As UltraGridRow In Grid9.Rows
            Entidad.Ruma = New ETRuma
            With Entidad.Ruma
                .TipoEnlace = "RECIRCULADO"
                .ID = xRow.Cells("ID").Value
                .Codigo = xRow.Cells("Codigo").Value
                .Descripcion = xRow.Cells("Descripcion").Value
                .Porcentaje = xRow.Cells("Porcentaje").Value
                .Humedad = xRow.Cells("Humedad").Value
                .Merma = xRow.Cells("Merma").Value
                .Cantidad = xRow.Cells("Cantidad").Value
                .StockRuma = xRow.Cells("StockRecurso").Value
                .CantidadxFraccionada = xRow.Cells("CantidadxFraccionada").Value
                .CantidadxNecesaria = xRow.Cells("CantidadxNecesaria").Value
                .CostoxRuma = xRow.Cells("CostoxTON").Value
                .SubTotal = xRow.Cells("SubTotal").Value
            End With
            Ls_Ruma.Add(Entidad.Ruma)
        Next

        For Each xRow As UltraGridRow In Grid2.Rows
            Entidad.Suministro = New ETSuministro
            With Entidad.Suministro
                .CodSuministro = xRow.Cells("CodSuministro").Value
                .Descripcion = xRow.Cells("Descripcion").Value
                .Peso = xRow.Cells("Peso").Value
                .Unidad = xRow.Cells("Unidad").Value
                .UndDesp = xRow.Cells("UndDesp").Value
                .CostoUnitario = xRow.Cells("CostoUnitario").Value
                .CantidadUnitaria = xRow.Cells("CantidadUnitaria").Value
                .Cantidad = xRow.Cells("Cantidad").Value
                .SubTotal = xRow.Cells("SubTotal").Value
            End With
            Ls_Empaque.Add(Entidad.Suministro)
        Next

        Entidad.Orden = Negocio.Orden.MantenimientoOrden(Entidad.Orden, Ls_Ruma, Ls_Empaque, Ls_Chancadora, Ls_Molino)

        If Not Entidad.Orden.Validacion Then Return

        Ejecutar = Boolean.FalseString
        Txt1.Value = Entidad.Orden.NroDocumento
        Ejecutar = Boolean.TrueString
        Tab1.Tabs(0).Selected = Boolean.TrueString

    End Sub

    Sub Reporte_Orden()

        If String.IsNullOrEmpty(Txt1.Value) Then Return

        StrucForm.FxRxReporte = New FrmBReporte
        Entidad.Orden = New ETOrden
        Entidad.Orden.NroDocumento = Txt1.Value
        StrucForm.FxRxReporte.NumReporte = VarReporte.Orden
        StrucForm.FxRxReporte.TextReporte = "Orden de Producción : " & Entidad.Orden.NroDocumento
        StrucForm.FxRxReporte.DatosReporte = Entidad.Orden
        StrucForm.FxRxReporte.MdiParent = MdiParent
        StrucForm.FxRxReporte.Show()

    End Sub

#End Region

#Region "Publicos"

    Public Sub Nuevo()

        Call Limpiar()

        Ejecutar = Boolean.TrueString

        Ope = 1

        Controles(Boolean.TrueString)

        Tab1.SelectedTab.Key = "T01"

    End Sub

    Public Sub Modificar()

        If Not VerificarControl(1, Txt1) Then
            MessageBox.Show("Seleccione el Nro Orden", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Ejecutar = Boolean.FalseString
        Ope = 2
        Call Controles(Boolean.TrueString)
        ReprocesarRuma = True
    End Sub

    Public Sub Stock()

        If Ope <> 1 Then Call Nuevo()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        StrucForm.FxLxStockMinimo = New FrmLStockMinimo
        StrucForm.FxLxStockMinimo.MdiParent = MdiParent
        StrucForm.FxLxStockMinimo.Show()
        StrucForm.FxLxStockMinimo = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Pedido()


    End Sub

    Public Sub Manual()

        If Ope <> 1 Then
            MsgBox("Presionar Nuevo", MsgBoxStyle.Information, msgComacsa)
            Exit Sub
        End If

        If IsDBNull(Dt3.Value) = True Or Dt3.Value Is Nothing Then
            MsgBox("Ingresar la Fecha de Ingreso al Almacén", MsgBoxStyle.Information, msgComacsa)
            Exit Sub
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        StrucForm.FxCxProductos = New FrmCProductos
        AddHandler StrucForm.FxCxProductos.Closing, AddressOf Buscar_Producto
        StrucForm.FxCxProductos.MdiParent = MdiParent
        StrucForm.FxCxProductos.Orden = Boolean.TrueString
        StrucForm.FxCxProductos.L = Boolean.TrueString
        StrucForm.FxCxProductos.Show()
        StrucForm.FxCxProductos = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Grabar()

        If Ope = 0 Then Return

        If Not Verificar_DatosGrabar() Then Return

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Grabar_Orden()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Reporte()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Reporte_Orden()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Buscar()
        ReprocesarRuma = False
        StrucForm.FxCxOrden = New FrmCOrden
        AddHandler StrucForm.FxCxOrden.Closing, AddressOf Buscar_Orden
        StrucForm.FxCxOrden.MdiParent = MdiParent
        StrucForm.FxCxOrden.L = Boolean.TrueString
        StrucForm.FxCxOrden.Show()
        StrucForm.FxCxOrden = Nothing

    End Sub

#End Region

#Region "Function"

    Function Verificar_Unidad(ByVal Rpt As ETActivo, ByVal Lista As List(Of ETActivo)) As Boolean

        Dim lResult As Boolean = Boolean.FalseString

        If Rpt Is Nothing OrElse Lista Is Nothing Then
            Return lResult
        End If

        Dim Results = Aggregate Tabla In Lista _
                      Where Tabla.Fecha = Rpt.Fecha And _
                            Tabla.Turno = Rpt.Turno And _
                            Tabla.Placa = Rpt.Placa _
                      Select Tabla Into Count()

        If Results <> 0 Then
            MessageBox.Show("Error: Debe Ingresar un Lote Diferente", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            lResult = Boolean.TrueString
        End If

        Return lResult

    End Function

    Function FiltrarConsultaRumaxDataTable1(ByRef Ls1 As DataTable, ByRef Ls2 As DataTable) As DataTable

        Dim lResult As DataTable

        lResult = New DataTable

        lResult = Ls1.Copy

        For Each xRow As DataRow In Ls2.Rows
            Bucle = Boolean.FalseString
            For Each yRow As DataRow In Ls1.Rows
                If xRow("CodRuma") = yRow("CodRuma") Then
                    Bucle = Boolean.TrueString : Exit For
                End If
            Next
            If Not Bucle Then
                xRow("Nuevo") = Boolean.TrueString
                lResult.ImportRow(xRow)
            End If
        Next

        Ls1 = Nothing
        Ls2 = Nothing

        Return lResult

    End Function

    Function FiltrarConsultaRumaxDataTable2(ByRef Ls1 As DataTable, ByRef Ls2 As DataTable) As DataTable

        Dim lResult As DataTable

        lResult = New DataTable

        lResult = Ls1.Copy

        For Each xRow As DataRow In Ls2.Rows
            Bucle = Boolean.FalseString
            For Each yRow As DataRow In Ls1.Rows
                If xRow("CodRuma") = yRow("CodRuma") And xRow("Codigo") = yRow("Codigo") Then
                    Bucle = Boolean.TrueString : Exit For
                End If
            Next
            If Not Bucle Then
                xRow("Nuevo") = Boolean.TrueString
                lResult.ImportRow(xRow)
            End If
        Next

        Ls1 = Nothing
        Ls2 = Nothing

        Return lResult

    End Function

    Function FiltrarConsultaRuma(ByRef Ls1 As List(Of ETRuma), ByRef Ls2 As List(Of ETRuma)) As List(Of ETRuma)

        Dim lResult As List(Of ETRuma) = Nothing

        lResult = New List(Of ETRuma)

        For Each Entidad.Ruma In Ls1
            lResult.Add(Entidad.Ruma)
        Next
        For Each Entidad.Ruma In Ls2
            Bucle = Boolean.FalseString
            For Each Rpt As ETRuma In Ls1
                If Rpt.TipoEnlace = "RUMA" Then
                    If Rpt.TipoEnlace = Entidad.Ruma.TipoEnlace And Rpt.CodRuma = Entidad.Ruma.CodRuma And Rpt.Codigo = Entidad.Ruma.Codigo Then
                        Bucle = Boolean.TrueString : Exit For
                    End If
                Else
                    If Rpt.TipoEnlace = Entidad.Ruma.TipoEnlace And Rpt.Codigo = Entidad.Ruma.Codigo Then
                        Bucle = Boolean.TrueString : Exit For
                    End If
                End If
            Next
            If Not Bucle Then Entidad.Ruma.Nuevo = True : lResult.Add(Entidad.Ruma)
        Next

        Ls1 = Nothing
        Ls2 = Nothing

        Return lResult

    End Function

    Function FiltrarConsultaSuministro(ByRef Ls3 As List(Of ETSuministro), ByRef Ls4 As List(Of ETSuministro)) As List(Of ETSuministro)

        Dim lResult As List(Of ETSuministro) = Nothing

        lResult = New List(Of ETSuministro)

        For Each Entidad.Suministro In Ls3
            lResult.Add(Entidad.Suministro)
        Next

        For Each Entidad.Suministro In Ls4
            Bucle = Boolean.FalseString
            For Each Rpt As ETSuministro In Ls3
                If Rpt.CodSuministro = Entidad.Suministro.CodSuministro Then
                    Bucle = Boolean.TrueString : Exit For
                End If
            Next
            If Not Bucle Then lResult.Add(Entidad.Suministro)
        Next

        Ls3 = Nothing
        Ls4 = Nothing

        Return lResult

    End Function

    Function Verificar_Cantidad_Suministro(ByVal vRow As UltraGridRow, ByVal Value As Int32) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If vRow Is Nothing Then
            Return lResult
        End If

        Dim SumCantUnit As Int32 = 0
        Dim MaxCantUnit As Int32 = 0

        For Each wRow As UltraGridRow In Grid2.Rows
            If String.Compare(wRow.Cells("CodSuministro").Value, vRow.Cells("CodSuministro").Value) <> 0 Then
                SumCantUnit += wRow.Cells("CantidadUnitaria").Value
            Else
                SumCantUnit += Value
            End If
            MaxCantUnit = wRow.Cells("CantidadMaxima").Value
        Next

        If MaxCantUnit > 0 AndAlso MaxCantUnit >= SumCantUnit Then lResult = Boolean.TrueString

        Return lResult

    End Function

    Function Verificar_DatosGrabar() As Boolean

        Dim lResult As Boolean = Boolean.TrueString
        Ep1.Clear()

        If String.IsNullOrEmpty(Txt2.Value) Then
            Ep1.SetError(Txt2, "Ingrese el Producto")
            lResult = Boolean.FalseString
        End If
        If Not IsNumeric(Cbo1.Value) OrElse Cbo1.Value = Decimal.Zero Then
            Ep1.SetError(Cbo1, "Ingrese el Enlace")
            lResult = Boolean.FalseString
        End If

        If Not IsNumeric(Num1.Value) OrElse Num1.Value = Decimal.Zero Then
            Ep1.SetError(Num1, "Ingrese la Cantidad")
            lResult = Boolean.FalseString
        End If

        If Num2.Value <> 100 Then
            Ep1.SetError(Num2, "La Formulación debe estar al 100%.00")
            lResult = Boolean.FalseString
        End If

        If Not IsNumeric(Num3.Value) OrElse Num3.Value = Decimal.Zero Then
            Ep1.SetError(Num3, "Ingrese la Formulación o ingrese la Cantidad a Producir")
            lResult = Boolean.FalseString
        Else

        End If

        If IsNumeric(Num6.Value) = False Then
            Ep1.SetError(Num6, "Distribuya la Cantidad Requerida en la Chancadora")
            lResult = Boolean.FalseString
        Else
            If IsDBNull(Num7.Value) = False Then
                If Val(FormatNumber((Num6.Value + Num7.Value), 3)) <> Val(FormatNumber(Num3.Value, 3)) Then
                    Ep1.SetError(Num6, "Distribuya Toda la Cantidad Requerida en la Chancadora")
                    lResult = Boolean.FalseString
                End If

            Else
                If Num6.Value <> Num3.Value Then
                    Ep1.SetError(Num6, "Distribuya Toda la Cantidad Requerida en la Chancadora")
                    lResult = Boolean.FalseString
                End If
            End If
        End If

        If IsNumeric(Num4.Value) = False Then
            Ep1.SetError(Num4, "Distribuya la Cantidad a Producir en los Molinos")
            lResult = Boolean.FalseString
        Else
            If Num4.Value <> Num1.Value Then
                Ep1.SetError(Num4, "Distribuya Toda la Cantidad a Producir en los Molinos")
                lResult = Boolean.FalseString
            End If
        End If


        If Not IsDate(Dt3.Value) Then
            Ep1.SetError(Dt3, "Ingrese la Fecha")
            lResult = Boolean.FalseString
        End If

        Return lResult

    End Function

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

    Function CargarRumaMineral() As List(Of ETRuma)
        Dim lResult As New List(Of ETRuma)


        Return lResult
    End Function

#End Region

    Private Sub Grid7_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid7.InitializeLayout
        If sender Is Nothing Then Exit Sub
        If e Is Nothing Then Exit Sub


        Grid7.DisplayLayout.Bands(0).Summaries.Clear()
        Grid7.DisplayLayout.Bands(0).SummaryFooterCaption = ""

        Grid7.DisplayLayout.Bands(1).Summaries.Clear()
        Grid7.DisplayLayout.Bands(1).SummaryFooterCaption = ""

        For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
            Select Case xCol.Key
                Case "CodRuma"
                    xCol.Header.Caption = "Código"
                    xCol.MinWidth = 60
                    xCol.CellActivation = Activation.ActivateOnly
                Case "DesRuma"
                    xCol.Header.Caption = "Ruma"
                    xCol.MinWidth = 150
                    xCol.CellActivation = Activation.ActivateOnly
                Case "StockRecurso"
                    xCol.Header.Caption = "Stock"
                    xCol.MinWidth = 80
                    xCol.CellActivation = Activation.ActivateOnly
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Formula = "sum( [../PK_Ruma/StockSubRecurso] )"
                    xCol.Format = "n3"

                    With Grid7.DisplayLayout.Bands(0).Summaries
                        .Add("Sumary1", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                        .Item("Sumary1").Appearance.BackColor = Color.LightYellow
                        .Item("Sumary1").Appearance.ForeColor = Color.Red
                        .Item("Sumary1").Appearance.FontData.Bold = DefaultableBoolean.True
                        .Item("Sumary1").Appearance.TextHAlign = HAlign.Right
                        .Item("Sumary1").DisplayFormat = "{0:N3}"
                    End With

                Case "Cantidad"

                    xCol.Header.Caption = "Cant.TON"
                    xCol.Formula = "if ( isnumber( [//CalsCantidad] ), [//CalsCantidad] ,0)"
                    xCol.MinWidth = 80
                    xCol.CellActivation = Activation.ActivateOnly
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Hidden = True
                    xCol.Format = "n3"
                Case "CantidadxFraccionada"
                    xCol.Header.Caption = "Cant.TON"
                    xCol.Formula = "[Cantidad] * [Porcentaje] *0.01"
                    xCol.MinWidth = 80
                    xCol.CellActivation = Activation.ActivateOnly
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n3"
                    With Grid7.DisplayLayout.Bands(0).Summaries
                        .Add("Sumary2", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                        .Item("Sumary2").Appearance.BackColor = Color.LightYellow
                        .Item("Sumary2").Appearance.ForeColor = Color.Red
                        .Item("Sumary2").Appearance.FontData.Bold = DefaultableBoolean.True
                        .Item("Sumary2").Appearance.TextHAlign = HAlign.Right
                        .Item("Sumary2").DisplayFormat = "{0:N3}"
                    End With

                Case "CantidadxNecesaria"
                    xCol.Header.Caption = "Cant.Req"
                    xCol.Formula = "(100+ [Humedad] + [Merma] )*0.01* [CantidadxFraccionada]"
                    xCol.MinWidth = 80
                    xCol.CellActivation = Activation.ActivateOnly
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n3"
                    With Grid7.DisplayLayout.Bands(0).Summaries
                        .Add("Sumary3", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                        .Item("Sumary3").Appearance.BackColor = Color.LightYellow
                        .Item("Sumary3").Appearance.ForeColor = Color.Red
                        .Item("Sumary3").Appearance.FontData.Bold = DefaultableBoolean.True
                        .Item("Sumary3").Appearance.TextHAlign = HAlign.Right
                        .Item("Sumary3").DisplayFormat = "{0:N3}"
                    End With

                Case "Porcentaje"
                    xCol.Header.Caption = "Porcentaje"
                    xCol.MinWidth = 60
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "#0.00 " + """%"""
                    xCol.MaskInput = "{double:3.2}"
                    With Grid7.DisplayLayout.Bands(0).Summaries
                        .Add("Sumary4", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                        .Item("Sumary4").Appearance.BackColor = Color.LightYellow
                        .Item("Sumary4").Appearance.ForeColor = Color.Red
                        .Item("Sumary4").Appearance.FontData.Bold = DefaultableBoolean.True
                        .Item("Sumary4").Appearance.TextHAlign = HAlign.Right
                        .Item("Sumary4").DisplayFormat = "{0:N2}"
                    End With

                    If Ope = 1 OrElse Ope = 2 Then
                        xCol.CellActivation = Activation.AllowEdit
                    Else
                        xCol.CellActivation = Activation.ActivateOnly
                    End If
                Case "Humedad"
                    xCol.Header.Caption = "Humedad"
                    xCol.MinWidth = 60
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "#0.00 " + """%"""
                    xCol.MaskInput = "{double:2.2}"
                    If Ope = 1 OrElse Ope = 2 Then
                        xCol.CellActivation = Activation.AllowEdit
                    Else
                        xCol.CellActivation = Activation.ActivateOnly
                    End If
                Case "Merma"
                    xCol.Header.Caption = "Merma"
                    xCol.MinWidth = 60
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "#0.00 " + """%"""
                    xCol.MaskInput = "{double:2.2}"
                    If Ope = 1 OrElse Ope = 2 Then
                        xCol.CellActivation = Activation.AllowEdit
                    Else
                        xCol.CellActivation = Activation.ActivateOnly
                    End If
                Case "CostoxTON"
                    xCol.Header.Caption = "CostoxTON"
                    'xCol.Formula = "if ( [CantidadxNecesaria] =0,0,(sum( [../band 1/subtotal] )/[CantidadxNecesaria]))"
                    xCol.Formula = "if ( [CantidadxNecesaria] =0,0,([SubTotal]/[CantidadxNecesaria]))"
                    xCol.MinWidth = 80
                    xCol.CellActivation = Activation.ActivateOnly
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n4"
                Case "SubTotal"
                    xCol.Header.Caption = "SubTotal"
                    'xCol.Formula = "[CantidadxNecesaria] * [CostoxTON]"
                    xCol.Formula = "SUM( [../PK_Ruma/SubTotal] )"
                    'xCol.Formula = "SUM( [Mineral/SubTotal] )"
                    xCol.MinWidth = 90
                    xCol.CellActivation = Activation.ActivateOnly
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n4"
                    With Grid7.DisplayLayout.Bands(0).Summaries
                        .Add("Sumary5", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                        .Item("Sumary5").Appearance.BackColor = Color.LightYellow
                        .Item("Sumary5").Appearance.ForeColor = Color.Red
                        .Item("Sumary5").Appearance.FontData.Bold = DefaultableBoolean.True
                        .Item("Sumary5").Appearance.TextHAlign = HAlign.Right
                        .Item("Sumary5").DisplayFormat = "{0:N4}"
                    End With

                Case Else
                    xCol.Hidden = True
                    xCol.CellActivation = Activation.NoEdit
            End Select
            xCol.Header.Appearance.TextHAlign = HAlign.Center
        Next



        For Each xCol As UltraGridColumn In e.Layout.Bands(1).Columns
            Select Case xCol.Key
                Case "Codigo"
                    xCol.Header.Caption = "Código"
                    xCol.MinWidth = 80
                    xCol.CellActivation = Activation.ActivateOnly
                Case "Descripcion"
                    xCol.Header.Caption = "Mineral"
                    xCol.MinWidth = 150
                    xCol.CellActivation = Activation.ActivateOnly
                Case "StockSubRecurso"
                    xCol.Header.Caption = "Stock"
                    xCol.MinWidth = 80
                    xCol.CellActivation = Activation.ActivateOnly
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n3"

                    With Grid7.DisplayLayout.Bands(1).Summaries
                        .Add("Sumary6", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                        .Item("Sumary6").Appearance.BackColor = Color.LightYellow
                        .Item("Sumary6").Appearance.ForeColor = Color.Red
                        .Item("Sumary6").Appearance.FontData.Bold = DefaultableBoolean.True
                        .Item("Sumary6").Appearance.TextHAlign = HAlign.Right
                        .Item("Sumary6").DisplayFormat = "{0:N3}"
                    End With

                Case "CantidadxFraccionada"
                    xCol.Header.Caption = "Cant.TON"
                    xCol.Formula = "if( [../../StockRecurso] =0,0, [../../CantidadxFraccionada] * (  [StockSubRecurso] /[../../StockRecurso] ))"
                    xCol.MinWidth = 80
                    xCol.CellActivation = Activation.ActivateOnly
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n3"
                    With Grid7.DisplayLayout.Bands(1).Summaries
                        .Add("Sumary7", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                        .Item("Sumary7").Appearance.BackColor = Color.LightYellow
                        .Item("Sumary7").Appearance.ForeColor = Color.Red
                        .Item("Sumary7").Appearance.FontData.Bold = DefaultableBoolean.True
                        .Item("Sumary7").Appearance.TextHAlign = HAlign.Right
                        .Item("Sumary7").DisplayFormat = "{0:N3}"
                    End With
                Case "CantidadxNecesaria"
                    xCol.Header.Caption = "Cant.Req"
                    xCol.Formula = "if( [../../StockRecurso] =0,0, [../../CantidadxNecesaria] * (  [StockSubRecurso] /[../../StockRecurso] ))"
                    xCol.MinWidth = 80
                    xCol.CellActivation = Activation.ActivateOnly
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n3"
                    With Grid7.DisplayLayout.Bands(1).Summaries
                        .Add("Sumary8", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                        .Item("Sumary8").Appearance.BackColor = Color.LightYellow
                        .Item("Sumary8").Appearance.ForeColor = Color.Red
                        .Item("Sumary8").Appearance.FontData.Bold = DefaultableBoolean.True
                        .Item("Sumary8").Appearance.TextHAlign = HAlign.Right
                        .Item("Sumary8").DisplayFormat = "{0:N3}"
                    End With

                Case "CostoxExtraccion"
                    xCol.Header.Caption = "C. Extracción"
                    xCol.MinWidth = 80
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n4"
                Case "CostoxCompra"
                    xCol.Header.Caption = "C. Compra"
                    xCol.MinWidth = 80
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n4"
                Case "CostoxRegalias"
                    xCol.Header.Caption = "C. Regalías"
                    xCol.MinWidth = 80
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n4"
                Case "CostoxFlete"
                    xCol.Header.Caption = "C. Flete"
                    xCol.MinWidth = 80
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n4"
                Case "CostoxOtros"
                    xCol.Header.Caption = "C. Otros"
                    xCol.MinWidth = 80
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n4"
                Case "CostoxTON"
                    xCol.Header.Caption = "C. xTON"
                    xCol.MinWidth = 80
                    xCol.CellActivation = Activation.ActivateOnly
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n4"
                Case "SubTotal"
                    xCol.Header.Caption = "SubTotal"
                    xCol.Formula = "[CantidadxNecesaria] * [CostoxTON]"
                    xCol.MinWidth = 90
                    xCol.CellActivation = Activation.ActivateOnly
                    xCol.CellAppearance.TextHAlign = HAlign.Right
                    xCol.Format = "n4"

                    With Grid7.DisplayLayout.Bands(1).Summaries
                        .Add("Sumary9", SummaryType.Sum, xCol, SummaryPosition.UseSummaryPositionColumn)
                        .Item("Sumary9").Appearance.BackColor = Color.LightYellow
                        .Item("Sumary9").Appearance.ForeColor = Color.Red
                        .Item("Sumary9").Appearance.FontData.Bold = DefaultableBoolean.True
                        .Item("Sumary9").Appearance.TextHAlign = HAlign.Right
                        .Item("Sumary9").DisplayFormat = "{0:N4}"
                    End With

                Case Else
                    xCol.Hidden = True
                    xCol.CellActivation = Activation.NoEdit
            End Select
            xCol.Header.Appearance.TextHAlign = HAlign.Center
        Next

    End Sub

   

    Private Sub Num1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Num1.ValueChanged
        Call ReProcesarUnidad(Grid3)
        Call ReProcesarUnidad(Grid4)
    End Sub

    Private Sub ReprocesarRuma_OT(ByVal sender As System.Object)
        If Not (String.IsNullOrEmpty(Cbo1.Value) = True OrElse Cbo1.Value Is Nothing) And _
                    Not (IsDBNull(Dt3.Value) = True OrElse Dt3.Value Is Nothing) Then
            If Cbo1.Value > 0 Then
                Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

                Call Consultar(Opcion.Ruma, sender)

                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            End If
        End If
    End Sub

    Private Sub Dt3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dt3.ValueChanged
        If ReprocesarRuma = True Then
            Call ReprocesarRuma_OT(sender)
        End If
    End Sub

    Private Sub Chk1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk1.CheckedChanged
        If sender Is Nothing Then Exit Sub
        If e Is Nothing Then Exit Sub
        Tab3.Tabs("T04").Visible = Chk1.Checked

    End Sub

End Class