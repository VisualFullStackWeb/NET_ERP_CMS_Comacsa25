Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows
Imports System.Windows.Forms
Imports System.Math
Imports System.Drawing
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmCOrden

#Region "Declaraciones"

    Public L As Boolean = Boolean.FalseString
    Public vCargar As Boolean = Boolean.FalseString
    Public NroDocumento As String = String.Empty
    Private Ls_Orden As List(Of ETOrden) = Nothing
    Private uRow As UltraGridRow
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)

#End Region

#Region "Eventos"

    'Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated

    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    MdiOperaciones = New List(Of String)

    '    MdiOperaciones.Add(StrucOperaciones._Actualizar)
    '    MdiOperaciones.Add(StrucOperaciones._Reporte)

    '    Call AdministrarToolBar(MdiParent, MdiOperaciones)

    'End Sub

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        AdministrarToolBar(MdiParent)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_Orden IsNot Nothing Then Ls_Orden = Nothing
        If MdiOperaciones IsNot Nothing Then MdiOperaciones = Nothing

    End Sub

    Sub Evento_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Gbp1.Expanded = Boolean.FalseString
        Gbp1.Enabled = Boolean.TrueString
        Txt1.Value = String.Empty
        Txt2.Value = String.Empty
        Dt1.Value = DBNull.Value
        Dt2.Value = DBNull.Value

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call Iniciar()

    End Sub

    Sub Evento_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Grid1.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

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

    Sub Evento_InitializeLayout(ByVal sender As Object, ByVal e As InitializeLayoutEventArgs) Handles Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "NroDocumento" OrElse uColumn.Key = "Descripcion" OrElse _
                    uColumn.Key = "CodProducto" OrElse uColumn.Key = "Fecha" OrElse _
                    uColumn.Key = "DesStatus") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

    End Sub

    Sub Evento_DoubleClickRow(ByVal sender As Object, ByVal e As DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        If e.Row.IsFilterRow Then Return

        Call Cargar_Orden(e.Row)

    End Sub

    Sub Evento_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Btn1.Click

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Btn1 Then

            If Not VerificarControl(5, Grid1) Then Return

            If Grid1.ActiveRow.IsFilterRow Then Return

            Call Cargar_Orden(Grid1.ActiveRow)

            Return

        End If

        'If sender Is Btn2 OrElse sender Is Btn3 OrElse _
        '   sender Is Btn4 Then

        '    If Not Filtrar_Busqueda(sender) Then Return

        '    Call Consultar_Filtro(sender)

        'End If

    End Sub

    Sub Evento_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _
                        Txt1.KeyPress, Txt2.KeyPress

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Txt1 Then

            If Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57 OrElse Asc(e.KeyChar) = Keys.Back Then
                e.Handled = Boolean.FalseString
            Else
                e.Handled = Boolean.TrueString
            End If
            Return

        End If

        If sender Is Txt2 Then

            If Asc(e.KeyChar) >= 48 AndAlso Asc(e.KeyChar) <= 57 OrElse _
                Asc(e.KeyChar) = 80 OrElse Asc(e.KeyChar) = 112 OrElse _
                Asc(e.KeyChar) = Keys.Back Then
                e.Handled = Boolean.FalseString
            Else
                e.Handled = Boolean.TrueString
            End If
            Return

        End If

    End Sub

    Sub Evento_InitializeRow(ByVal sender As Object, ByVal e As InitializeRowEventArgs) Handles Grid1.InitializeRow

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Grid1 Then Return

        With e.Row.Cells("Status")
            If .Value = "*" Then
                e.Row.Cells("DesStatus").Value = "ANULADO"
            Else
                e.Row.Cells("DesStatus").Value = "ACTIVO"
            End If
        End With

    End Sub

#End Region

#Region "Procedimientos"

    Sub Iniciar()

        Entidad.MyLista = New ETMyLista
        Negocio.Orden = New NGOrden

        Entidad.MyLista = Negocio.Orden.ConsultarOrden1()

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Orden = New List(Of ETOrden)
        Ls_Orden = Entidad.MyLista.Ls_Orden

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Orden)

    End Sub

    Sub Cargar_Orden(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If

        vCargar = Boolean.TrueString

        NroDocumento = uRow.Cells("NroDocumento").Value

        If L Then Close()

    End Sub

    Sub Consultar_Filtro(ByVal uButon As Object)

        'Entidad.Orden = New ETOrden
        'Negocio.Orden = New NGOrden

        'If uButon Is Btn2 Then
        '    Entidad.Orden.Tipo = 6
        '    Entidad.Orden.NroDocumento = Txt1.Value
        'End If
        'If uButon Is Btn3 Then
        '    Entidad.Orden.Tipo = 7
        '    Entidad.Orden.CodProducto = Txt2.Value
        'End If
        'If uButon Is Btn4 Then
        '    Entidad.Orden.Tipo = 8
        '    Entidad.Orden.FechaInicio = Dt1.Value
        '    Entidad.Orden.FechaTerminacion = Dt2.Value
        'End If

        'ET_Orden = New ETOrden

        'ET_Orden = Negocio.Orden.ConsultarOrden_Busqueda(Entidad.Orden)

        'If Not ET_Orden.Validacion Then
        '    Call LimpiarUltraGridxBinding(Grid1, Source1)
        'Else
        '    Call CargarUltraGridxBinding(Grid1, Source1, ET_Orden.Tabla)
        'End If

    End Sub

    Sub Reporte_Orden()

        If Not VerificarControl(5, Grid1) Then Return

        If Grid1.ActiveRow.IsFilterRow Then Return

        uRow = Grid1.ActiveRow

        StrucForm.FxRxReporte = New FrmBReporte
        Entidad.Orden = New ETOrden
        Entidad.Objecto = New ETObjecto

        Entidad.Orden.NroDocumento = uRow.Cells("NroDocumento").Value
        Entidad.Objecto.Datos = Entidad.Orden

        StrucForm.FxRxReporte.NumReporte = VarReporte.Orden
        StrucForm.FxRxReporte.DatosReporte = Entidad.Objecto
        StrucForm.FxRxReporte.MdiParent = MdiParent
        StrucForm.FxRxReporte.Show()

    End Sub

#End Region

#Region "Metodos Publicos"

    Public Sub Reporte()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Reporte_Orden()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Actualizar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Call Iniciar()

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

#End Region

#Region "Function"

    Function Existe_Orden(ByVal Rpt As ETOrden) As Boolean
        If Rpt.NroDocumento = Grid1.ActiveRow.Cells("NroDocumento").Value Then
            Return Boolean.TrueString
        Else
            Return Boolean.FalseString
        End If
    End Function

    Function Filtrar_Busqueda(ByVal uButon As Object) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If uButon Is Nothing Then
            Return lResult
        End If

        Ep1.Clear()

        'If uButon Is Btn2 Then ' NroDocumento

        '    If Not VerificarControl(1, Txt1) Then Ep1.SetError(Txt1, "Ingrese el NroDocumento") : GoTo Salir
        '    If Txt1.Value.ToString.Length <> 10 Then Ep1.SetError(Txt1, "El NroDocumento es Incorrecto") : GoTo Salir

        'End If

        'If uButon Is Btn3 Then ' CodProducto

        '    If Not VerificarControl(1, Txt2) Then Ep1.SetError(Txt2, "Ingrese el Código de Producto") : GoTo Salir
        '    If Txt2.Value.ToString.Length <> 8 Then Ep1.SetError(Txt2, "El Código de Producto es Incorrecto") : GoTo Salir

        'End If

        'If uButon Is Btn4 Then ' RangodeFechas

        '    If Not IsDate(Dt1.Value) Then Ep1.SetError(Dt1, "Ingrese la Fecha") : GoTo Salir
        '    If Not IsDate(Dt2.Value) Then Ep1.SetError(Dt2, "Ingrese la Fecha") : GoTo Salir
        '    If CDate(Dt1.Value) > CDate(Dt2.Value) Then Ep1.SetError(Dt2, "Rango de Fechas Incorrecto") : GoTo Salir

        'End If

        lResult = Boolean.TrueString


        'If Tipo = 4 Then ' Estado

        'End If
Salir:
        Return lResult

    End Function

#End Region


End Class