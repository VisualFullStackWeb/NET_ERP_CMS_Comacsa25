Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmLRequerimiento
    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub


#Region "Declaraciones"

    Private CodRuma As String = String.Empty
    Private ID As Int32 = 0
    Private Ope As Int32 = 0
    Private Ds As DataSet = Nothing
    Private Dt As DataTable = Nothing
    Private Ls_Ruma As List(Of ETRuma) = Nothing
    Private MdiOperaciones As List(Of String) = Nothing

#End Region

#Region "Eventos"

    'Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
    '                     Handles Me.Activated

    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    MdiOperaciones = New List(Of String)

    '    MdiOperaciones.Add(StrucOperaciones._Nuevo)
    '    MdiOperaciones.Add(StrucOperaciones._Modificar)
    '    MdiOperaciones.Add(StrucOperaciones._Cancelar)
    '    MdiOperaciones.Add(StrucOperaciones._Actualizar)
    '    MdiOperaciones.Add(StrucOperaciones._Eliminar)
    '    MdiOperaciones.Add(StrucOperaciones._Grabar)
    '    MdiOperaciones.Add(StrucOperaciones._Reporte)
    '    MdiOperaciones.Add(StrucOperaciones._Correo)
    '    MdiOperaciones.Add(StrucOperaciones._Excel)

    '    Call AdministrarToolBar(MdiParent, MdiOperaciones)

    'End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) _
                          Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Iniciar()

    End Sub

    Sub Evento_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles _
                    Me.Shown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call ScrollLabel(Lbl1)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) _
                          Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Dt IsNot Nothing Then Dt = Nothing
        If Ds IsNot Nothing Then Ds = Nothing
        If Ls_Ruma IsNot Nothing Then Ls_Ruma = Nothing
        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) _
                                Handles Grid1.InitializeLayout, Grid2.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            With Grid1.DisplayLayout
                For Each uColumn As UltraGridColumn In .Bands(0).Columns
                    If Not (uColumn.Key = "NroReq" Or _
                            uColumn.Key = "FechaLimite" Or _
                            uColumn.Key = "FechaCreacion") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next

                For Each uColumn As UltraGridColumn In .Bands(1).Columns
                    If Not (uColumn.Key = "CodRuma" Or _
                            uColumn.Key = "Descripcion" Or _
                            uColumn.Key = "Cantidad") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                        uColumn.CellActivation = Activation.ActivateOnly
                    End If
                Next

                .Bands(1).Columns("CodRuma").Header.VisiblePosition = 0
                .Bands(1).Columns("Descripcion").Header.VisiblePosition = 1
                .Bands(1).Columns("Cantidad").Header.VisiblePosition = 2

                .Bands(1).Columns("CodRuma").MaxWidth = 110
                .Bands(1).Columns("CodRuma").MinWidth = 110
                .Bands(1).Columns("Cantidad").MaxWidth = 110
                .Bands(1).Columns("Cantidad").MinWidth = 110

                .Bands(1).Columns("CodRuma").Header.Caption = "Código"

                .Bands(1).Columns("CodRuma").Header.Appearance.TextHAlign = HAlign.Center
                .Bands(1).Columns("Cantidad").Header.Appearance.TextHAlign = HAlign.Center

                .Bands(1).Columns("CodRuma").CellAppearance.TextHAlign = HAlign.Center
                .Bands(1).Columns("Cantidad").CellAppearance.TextHAlign = HAlign.Center
            End With
            Return
        End If

        If sender Is Grid2 Then
            With Grid2.DisplayLayout
                For Each uColumn As UltraGridColumn In .Bands(0).Columns
                    If Not (uColumn.Key = "CodRuma" Or _
                            uColumn.Key = "Descripcion" Or _
                            uColumn.Key = "Cantidad") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next
            End With
            Return
        End If

    End Sub

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) _
                     Handles Btn1.Click, Btn2.Click

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ope = 0 Then Return

        If sender Is Btn1 Then

            Grid2.PerformAction(ExitEditMode)
            StrucForm.FxCxRumas = New FrmCRumas
            AddHandler StrucForm.FxCxRumas.Closing, AddressOf Cargar_Ruma
            StrucForm.FxCxRumas.MdiParent = MdiParent
            StrucForm.FxCxRumas.L = Boolean.TrueString
            StrucForm.FxCxRumas.Show()
            StrucForm.FxCxRumas = Nothing
            Return

        End If

        If sender Is Btn2 Then

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

    End Sub

    Sub Evento_BeforeRowsDeleted(ByVal sender As Object, ByVal e As BeforeRowsDeletedEventArgs) _
                                 Handles Grid2.BeforeRowsDeleted

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid2 Then Return

        e.DisplayPromptMsg = Boolean.FalseString

    End Sub

    Sub Evento_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) _
                              Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If e.Row.IsFilterRow Then Return

        If Not e.Row.HasChild Then Return

        Call Consultar_Requerimiento(e.Row)

    End Sub

#End Region

#Region "Publicos"

    Public Sub Nuevo()

        Ope = 1
        Call Limpiar()
        Call Controles(Boolean.TrueString)
        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Public Sub Modificar()

        If Not Tab1.Tabs("T02").Selected Then
            Return
        End If

        If Not VerificarControl(1, Txt1) Then
            MessageBox.Show("No existe Requerimiento para Modificar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Ope = 2
        Call Controles(Boolean.TrueString)

    End Sub

    Public Sub Reporte()

        If Not Tab1.Tabs("T02").Selected Then
            Return
        End If

        If Not VerificarControl(1, Txt1) Then
            Return
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Try
            Entidad.Requerimiento = New ETRequerimiento
            Negocio.Requerimiento = New NGRequerimiento

            Entidad.Requerimiento.ID = ID
            Entidad.Requerimiento = Negocio.Requerimiento.CRxConsultar_Requerimiento(Entidad.Requerimiento)

            If Not Entidad.Requerimiento.Validacion Then Exit Try

            StrucForm.FxRxReporte = New FrmBReporte

            StrucForm.FxRxReporte.NumReporte = VarReporte.Requerimiento
            StrucForm.FxRxReporte.DatosReporte = Entidad.Requerimiento.Tabla
            StrucForm.FxRxReporte.Tipo = Boolean.TrueString
            StrucForm.FxRxReporte.TextReporte = "Requerimiento [" & Txt1.Value & "]"
            StrucForm.FxRxReporte.MdiParent = MdiParent
            StrucForm.FxRxReporte.Show()

        Catch
        End Try

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)


    End Sub

    Public Sub Archivar(ByVal Tipo As Integer)

        '    If Txt1.Value = Nothing OrElse Txt1.Value = String.Empty Then
        '        Exit Sub
        '    End If

        '    CargarUltraStatusBar(MdiParent)

        '    Entidad.Requerimiento = New ETRequerimiento
        '    Entidad.Requerimiento.NroReq = Txt1.Value
        '    Entidad.Objecto = New ETObjecto
        '    Entidad.Objecto.Datos = Entidad.Requerimiento

        '    StrucForm.CxReporte = New ClsReporte
        '    StrucForm.CxReporte.CargarArchivo(VarReporte.Requerimiento, Entidad.Objecto, Tipo, Txt1.Value)

        '    CargarUltraStatusBar(MdiParent)

    End Sub

    Public Sub Eliminar()

        If Not Tab1.Tabs("T02").Selected Then
            Return
        End If

        If Not VerificarControl(1, Txt1) Then
            MessageBox.Show("No existe Requerimiento para Eliminar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Requerimiento = New ETRequerimiento
        Negocio.Requerimiento = New NGRequerimiento

        Entidad.Requerimiento.ID = ID
        Entidad.Requerimiento.NroReq = Txt1.Value
        Entidad.Requerimiento.Usuario = User_Sistema

        Entidad.Requerimiento = Negocio.Requerimiento.EliminarRequerimiento(Entidad.Requerimiento)

        If Entidad.Requerimiento.Validacion Then
            Call Limpiar()
            Call Iniciar()
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Grabar()

        If Not Tab1.Tabs("T02").Selected Then
            Return
        End If

        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Grid2.PerformAction(ExitEditMode)

        Entidad.Requerimiento = New ETRequerimiento
        Negocio.Requerimiento = New NGRequerimiento

        Entidad.Requerimiento.ID = ID
        Entidad.Requerimiento.NroReq = Txt1.Value
        Entidad.Requerimiento.Prioridad = Cbo1.Value
        Entidad.Requerimiento.Observacion = Txt2.Value
        Entidad.Requerimiento.FechaLimite = Dt2.Value
        Entidad.Requerimiento.Usuario = User_Sistema

        Entidad.Requerimiento = Negocio.Requerimiento.MantenimientoRequerimiento(Entidad.Requerimiento, Ls_Ruma)

        If Entidad.Requerimiento.Validacion Then
            Txt1.Value = Entidad.Requerimiento.NroReq
            Call Controles(Boolean.FalseString)
            Call Iniciar()
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Cancelar()

        Ope = 0
        Call Controles(Boolean.FalseString)

    End Sub

    Public Sub Correo()
        'Dim strAdj As String = String.Empty
        'If Txt1.Value = Nothing OrElse Txt1.Value = String.Empty Then
        '    Exit Sub
        'End If
        'If ExisteFichero(CarpetaArchivo & Txt1.Value & ".PDF") Then
        '    strAdj = CarpetaArchivo & Txt1.Value & ".PDF"
        'ElseIf ExisteFichero(CarpetaArchivo & Txt1.Value & ".DOC") Then
        '    strAdj = CarpetaArchivo & Txt1.Value & ".DOC"
        'ElseIf ExisteFichero(CarpetaArchivo & Txt1.Value & ".XLS") Then
        '    strAdj = CarpetaArchivo & Txt1.Value & ".XLS"
        'Else
        '    MessageBox.Show("No existe el Archivo", Mensaje.msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'StrucForm.CxReporte = New ClsReporte
        'StrucForm.CxReporte.CargarCorreo(Correo_MinasTo, Correo_MinasCC, Txt1.Value, strAdj, String.Empty)
    End Sub

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Excel()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Exportar_Requerimiento(ExpArchivo.Excel)

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Word()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Exportar_Requerimiento(ExpArchivo.Word)

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Pdf()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Exportar_Requerimiento(ExpArchivo.Pdf)

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

#Region "Procedimientos"

    Sub Limpiar()

        ID = 0
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Dt1.Value = Date.Now
        Dt2.Value = DBNull.Value
        Cbo1.Value = Nothing

        Ls_Ruma = New List(Of ETRuma)
        Call CargarUltraGrid(Grid2, Ls_Ruma)

    End Sub

    Sub Cargar_Ruma(ByVal sender As Object, ByVal e As EventArgs)

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not sender.vCargar Then Return

        For Each W As ETRuma In sender.Lista
            CodRuma = String.Empty : CodRuma = W.CodRuma
            If Not Ls_Ruma.Exists(AddressOf Existe_Ruma) Then Ls_Ruma.Add(W)
        Next

        Call CargarUltraGrid(Grid2, Ls_Ruma)

    End Sub

    Sub Consultar_Requerimiento(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Requerimiento = New ETRequerimiento
        Negocio.Requerimiento = New NGRequerimiento

        Entidad.Requerimiento.ID = uRow.Cells("ID").Value
        Entidad.Requerimiento = Negocio.Requerimiento.Consultar_Requerimiento(Entidad.Requerimiento)

        If Entidad.Requerimiento.Validacion Then
            Call Cargar_Requerimiento() : Call Cancelar()
        End If

        CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Sub Controles(ByVal Val As Boolean)

        Txt2.ReadOnly = Not Val
        Dt2.ReadOnly = Not Val
        Cbo1.ReadOnly = Not Val

        Btn1.Enabled = Val
        Btn2.Enabled = Val

        With Grid2.DisplayLayout
            If Val Then
                .Bands(0).Columns("Cantidad").CellActivation = Activation.AllowEdit
                .Override.AllowDelete = DefaultableBoolean.True
            Else
                .Bands(0).Columns("Cantidad").CellActivation = Activation.ActivateOnly
                .Override.AllowDelete = DefaultableBoolean.False
            End If
        End With

    End Sub

    Sub Cargar_Requerimiento()

        ID = Entidad.Requerimiento.ID
        Txt1.Value = Entidad.Requerimiento.NroReq
        Txt2.Value = Entidad.Requerimiento.Observacion
        Dt2.Value = Entidad.Requerimiento.FechaLimite
        Dt1.Value = Entidad.Requerimiento.FechaEmision
        Cbo1.Value = Entidad.Requerimiento.Prioridad

        Ls_Ruma = New List(Of ETRuma)
        Ls_Ruma = Entidad.Requerimiento.Ls_Lista1

        Call CargarUltraGrid(Grid2, Ls_Ruma)

        Tab1.Tabs("T02").Selected = Boolean.TrueString

    End Sub

    Sub Iniciar()

        Entidad.Requerimiento = New ETRequerimiento
        Negocio.Requerimiento = New NGRequerimiento

        Entidad.Requerimiento = Negocio.Requerimiento.Consultar_MaestroxDetalle

        If Entidad.Requerimiento.Validacion Then Ds = Entidad.Requerimiento.Coleccion

        Call CargarUltraGridxBinding(Grid1, Source1, Ds)

    End Sub

    Sub Exportar_Requerimiento(ByVal TipoDoc As Short)

        If Not Tab1.Tabs("T02").Selected Then
            Return
        End If

        If Not VerificarControl(1, Txt1) Then
            Return
        End If

        Try
            Entidad.Requerimiento = New ETRequerimiento
            Negocio.Requerimiento = New NGRequerimiento

            Entidad.Requerimiento.ID = ID
            Entidad.Requerimiento = Negocio.Requerimiento.CRxConsultar_Requerimiento(Entidad.Requerimiento)

            If Not Entidad.Requerimiento.Validacion Then Exit Try

            Call Visor_Consulta_Reporte(VarReporte.Requerimiento, Entidad.Requerimiento.Tabla, TipoDoc, Txt1.Value, VarReporte.Requerimiento)

        Catch
        End Try


    End Sub

#End Region

#Region "Funciones"

    Function Existe_Ruma(ByVal Rpt As ETRuma) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.CodRuma = CodRuma Then lResult = Boolean.TrueString

        Return lResult

    End Function

#End Region

End Class