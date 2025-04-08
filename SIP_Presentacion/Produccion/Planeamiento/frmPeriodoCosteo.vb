Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmPeriodoCosteo
#Region "Declarar Variables"

    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Periodo As List(Of ETPeriodo) = Nothing
    Private Ls_PeriodoFactura As List(Of ETPeriodoDetalle) = Nothing
    Private Ls_PeriodoOperador As List(Of ETPeriodoDetalle) = Nothing
    Private Ls_DocDetalle As List(Of ETPeriodoDetalle) = Nothing
    Private Ls_UnidDoc_ComprobPago As List(Of ETPeriodoDetalle) = Nothing

    Private FechaInicio As Date
    Private FechaTermino As Date

    Private Enum eState
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum

    Private TipoG As eState
    Private _Periodo As Integer = 0

#End Region

#Region "Propiedades"
    Private Property Periodo() As Integer
        Get
            Return _Periodo
        End Get
        Set(ByVal value As Integer)
            _Periodo = value
        End Set
    End Property
#End Region

#Region "Funciones Privadas"
    Private Function ValidarRegistro() As Boolean
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim dup As Integer = 0
        Dim Porcentaje As Double = 0

        ValidarRegistro = True
        Ep1.Clear()

        If Not (TipoG = eState.eNew OrElse TipoG = eState.eEdit) Then
            ValidarRegistro = False
            MsgBox("Debe Presionar el Evento Nuevo o Modificar antes de Grabar", MsgBoxStyle.Exclamation, msgComacsa)
            Return False
        End If

        If String.IsNullOrEmpty(Cbo1.Value) Then
            Ep1.SetError(Cbo1, "Seleccione el Mes")
            ValidarRegistro = False
        End If


        If Tag = "102" Then
            For Each xRow As ETPeriodoDetalle In Ls_PeriodoFactura
                If xRow.TipoPropio = "0" Then
                    Ep1.SetError(Grid2, "Falta Registrar Activos")
                    ValidarRegistro = False
                End If

                If xRow.SubTipo = "02" And String.IsNullOrEmpty(xRow.Num_Doc.TrimEnd) Then
                    Ep1.SetError(Grid2, "Agregue Todas las Facturas de Alquiler")
                    ValidarRegistro = False
                End If

                If xRow.TipoCosteo = "02" And xRow.SubTipo = "01" And String.IsNullOrEmpty(xRow.Num_Doc.TrimEnd) Then
                    i = i + 1
                End If
                If xRow.TipoCosteo = "01" And xRow.SubTipo = "01" And String.IsNullOrEmpty(xRow.Num_Doc.TrimEnd) Then
                    j = j + 1
                End If

            Next

            If i > 0 Then
                If MsgBox("Está Seguro que los Cargadores Frontales no tuvieron Costo de Mantenimiento Automotriz", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Ok Then
                    ValidarRegistro = False
                End If
            End If
            If j > 0 Then
                If MsgBox("Está Seguro que los Camiones no tuvieron Costo de Mantenimiento Automotriz", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Ok Then
                    ValidarRegistro = False
                End If
            End If

        ElseIf Tag = "103" Then
            For Each xRow As ETPeriodoDetalle In Ls_PeriodoOperador
                If String.IsNullOrEmpty(xRow.PlaCod.TrimEnd) Then
                    Ep1.SetError(Grid2, "Agregue a Todos los Operadores del Cargador Frontal")
                    ValidarRegistro = False
                End If
            Next
        End If

    End Function
#End Region

#Region "Procedimientos Privados"
    Private Sub LlenarMeses()
        Dim i As Short = 1
        Cbo1.Items.Clear()
        If Year(Dtp1.Value) = Year(Date.Today) Then
            For i = 1 To Month(Date.Today)
                Dim Item As New Infragistics.Win.ValueListItem
                Item.DataValue = i
                Item.DisplayText = NameMes(i)
                Cbo1.Items.Add(Item)
            Next
        ElseIf Year(Dtp1.Value) < Year(Date.Today) Then
            For i = 1 To 12
                Dim Item1 As New Infragistics.Win.ValueListItem
                Item1.DataValue = i
                Item1.DisplayText = NameMes(i)
                Cbo1.Items.Add(Item1)
            Next
        End If

    End Sub
    Private Sub Limpiar()
        FechaInicio = Now
        FechaTermino = Now
        Dtp1.Value = Now
        Cbo1.Value = String.Empty
        Cbo2.Value = "K1"
        Ep1.Clear()
        _Periodo = 0
        Ls_PeriodoFactura = Nothing
        Ls_PeriodoOperador = Nothing
        Ls_DocDetalle = Nothing
        Ls_UnidDoc_ComprobPago = Nothing
        Ls_PeriodoFactura = New List(Of ETPeriodoDetalle)
        Ls_PeriodoOperador = New List(Of ETPeriodoDetalle)
        Ls_DocDetalle = New List(Of ETPeriodoDetalle)
        Ls_UnidDoc_ComprobPago = New List(Of ETPeriodoDetalle)

        Call CargarUltraGrid(Grid2, Ls_PeriodoFactura)
        Call CargarUltraGrid(Grid3, Ls_PeriodoOperador)
    End Sub

    Private Sub HabilitarControles(ByVal xBol As Boolean)
        Dtp1.ReadOnly = Not xBol
        Cbo1.ReadOnly = Not xBol
        If Tag = "101" Then
            Cbo2.ReadOnly = Not xBol
        Else
            If TipoG = eState.eEdit Then
                Cbo1.ReadOnly = True
            End If
            Cbo2.ReadOnly = True
        End If

    End Sub

    Private Sub Inicio()
        Select Case Tag
            Case "101"
                Tab1.Tabs("T03").Visible = False
                Tab1.Tabs("T04").Visible = False
            Case "102"
                Tab1.Tabs("T04").Visible = False
            Case "103"
                Tab1.Tabs("T03").Visible = False
        End Select

        Call LlenarMeses()
        Call Limpiar()
        Call HabilitarControles(False)
        Call CargarPeriodoCosteo()
        Tab1.Tabs("T01").Selected = True
        TipoG = eState.eView
    End Sub

    Private Sub CargarDetalle()
        If Tag = "101" Then
            Exit Sub
        End If

        If String.IsNullOrEmpty(Cbo1.Value) Then
            Exit Sub
        End If

        If Not (TipoG = eState.eNew OrElse TipoG = eState.eEdit) Then
            Exit Sub
        End If

        FechaInicio = CDate(("01/" & CStr(Cbo1.Value) & "/" & Year(Dtp1.Value)))
        FechaTermino = DateAdd(DateInterval.Month, 1, FechaInicio)
        FechaTermino = DateAdd(DateInterval.Second, -1, FechaTermino)

        Entidad.PeriodoDetalle = New ETPeriodoDetalle
        With Entidad.PeriodoDetalle
            .Periodo = Periodo
            .Cod_Alm = "19"
            .FechaInicio = FechaInicio
            .FechaTermino = FechaTermino
            If TipoG = eState.eNew Then
                .Tipo = 3
            Else
                .Tipo = 4
            End If
        End With

        Entidad.MyLista = New ETMyLista
        Negocio.PeriodoCosteo = New NGPeriodoCosteo
        If Tag = "102" Then
            Ls_PeriodoFactura = Nothing
            Ls_PeriodoFactura = New List(Of ETPeriodoDetalle)
            Entidad.MyLista = Negocio.PeriodoCosteo.ConsultarPeriodoCosteo_Facturacion(Entidad.PeriodoDetalle)
            If Entidad.MyLista IsNot Nothing Then
                Ls_PeriodoFactura = Entidad.MyLista.Ls_PeriodoDetalle
            End If
            Call CargarUltraGrid(Grid2, Ls_PeriodoFactura)
            Tab1.Tabs("T03").Selected = True
        Else
            Ls_PeriodoOperador = Nothing
            Ls_PeriodoOperador = New List(Of ETPeriodoDetalle)
            Entidad.MyLista = Negocio.PeriodoCosteo.ConsultarPeriodoCosteo_Operador(Entidad.PeriodoDetalle)
            If Entidad.MyLista IsNot Nothing Then
                Ls_PeriodoOperador = Entidad.MyLista.Ls_PeriodoDetalle
            End If
            Call CargarUltraGrid(Grid3, Ls_PeriodoOperador)
            Tab1.Tabs("T03").Selected = True
        End If
    End Sub
#Region "Cierre"
    Private Sub CargarPeriodoCosteo()
        Ls_Periodo = New List(Of ETPeriodo)
        Entidad.Periodo = New ETPeriodo
        Select Case Tag
            Case "101"
                Entidad.Periodo.TipoPeriodo = ETPeriodo.sTipoPeriodo.PeriodoCosteoProductos
                Entidad.Periodo.Tipo = 6
            Case "102"
                Entidad.Periodo.TipoPeriodo = ETPeriodo.sTipoPeriodo.PeriodoCosteoProductos_Facturacion
                Entidad.Periodo.Tipo = 8
            Case "103"
                Entidad.Periodo.TipoPeriodo = ETPeriodo.sTipoPeriodo.PeriodoCosteoProductos_Operador
                Entidad.Periodo.Tipo = 8
        End Select
        Negocio.PeriodoCosteo = New NGPeriodoCosteo
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.PeriodoCosteo.ConsultarPeriodoCosteo(Entidad.Periodo)
        If Entidad.MyLista IsNot Nothing Then
            Ls_Periodo = Entidad.MyLista.Ls_Periodo
        End If
        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Periodo)
    End Sub

    Private Sub Nuevo_Cierre()
        If TipoG = eState.eEdit Then
            If MsgBox("Desea Tener como Plantilla al Periodo: " & NameMes(Me.Cbo1.Value) & Space(1) & Year(Me.Dtp1.Value), MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Call Limpiar()
                Call HabilitarControles(True)
                Dtp1.Focus()
                TipoG = eState.eNew
                Tab1.Tabs("T02").Selected = True
            Else
                Cbo1.Value = String.Empty
                Cbo2.Value = "K1"
                Call HabilitarControles(True)
                Cbo1.Focus()
                TipoG = eState.eNew
                Tab1.Tabs("T02").Selected = True
            End If
        Else
            Call Limpiar()
            Call HabilitarControles(True)
            Dtp1.Focus()
            TipoG = eState.eNew
            Tab1.Tabs("T02").Selected = True
        End If

    End Sub

    Private Sub Grabar_Cierre()

        If ValidarRegistro() = False Then
            Exit Sub
        End If
        Entidad.Periodo = New ETPeriodo

        With Entidad.Periodo
            .Periodo = Me.Periodo
            .Anio = Year(Dtp1.Value)
            If Cbo1.Items.Count > 0 Then
                .Mes = Cbo1.Value
            End If
            .TipoPeriodo = ETPeriodo.sTipoPeriodo.PeriodoCosteoProductos
            .Status = IIf(Cbo2.Value = "K1", "A", "")
            .Usuario = User_Sistema
            .Tipo = TipoG
        End With

        If Negocio.PeriodoCosteo.MantenedorPeriodoCosteo(Entidad.Periodo) = True Then
            Call Inicio()
        End If
    End Sub


    Private Sub Modificar_Cierre()
        Me.Dtp1.Value = Mid(Date.Today.ToShortDateString, 1, 6) & Grid1.ActiveRow.Cells("Anio").Value
        Me.Cbo1.Value = Grid1.ActiveRow.Cells("Mes").Value
        Cbo2.Value = Grid1.ActiveRow.Cells("Status").Value
        Tab1.Tabs("T02").Selected = True
    End Sub
#End Region

#Region "Facturacion"
    Private Sub Nuevo_Facturacion()
        Call Limpiar()
        Call HabilitarControles(True)
        Dtp1.Focus()
        TipoG = eState.eNew
        Tab1.Tabs("T02").Selected = True
    End Sub

    Private Sub Grabar_Facturacion()

        If ValidarRegistro() = False Then
            Exit Sub
        End If
        Entidad.Periodo = New ETPeriodo

        With Entidad.Periodo
            .Periodo = Me.Periodo
            .Anio = Year(Dtp1.Value)
            If Cbo1.Items.Count > 0 Then
                .Mes = Cbo1.Value
            End If
            .TipoPeriodo = ETPeriodo.sTipoPeriodo.PeriodoCosteoProductos_Facturacion
            .Status = IIf(Cbo2.Value = "K1", "", "*")
            .Usuario = User_Sistema
            .Tipo = TipoG
        End With

        If Negocio.PeriodoCosteo.MantenedorPeriodoCosteo_Facturacion(Entidad.Periodo, Ls_PeriodoFactura) = True Then
            Call Inicio()
        End If
    End Sub

    Private Sub Modificar_Facturacion_Operador()
        TipoG = eState.eView
        Me.Dtp1.Value = Mid(Date.Today.ToShortDateString, 1, 6) & Grid1.ActiveRow.Cells("Anio").Value
        Me.Cbo1.Value = Grid1.ActiveRow.Cells("Mes").Value
        Cbo2.Value = "K1"
        TipoG = eState.eEdit
        Call CargarDetalle()
        Tab1.Tabs("T02").Selected = True
    End Sub
#End Region

#Region "Operador"
    Private Sub Nuevo_Operador()
        Call Limpiar()
        Call HabilitarControles(True)
        Dtp1.Focus()
        TipoG = eState.eNew
        Tab1.Tabs("T02").Selected = True
    End Sub

    Private Sub Grabar_Operador()
        If ValidarRegistro() = False Then
            Exit Sub
        End If
        Entidad.Periodo = New ETPeriodo

        With Entidad.Periodo
            .Periodo = Me.Periodo
            .Anio = Year(Dtp1.Value)
            If Cbo1.Items.Count > 0 Then
                .Mes = Cbo1.Value
            End If
            .TipoPeriodo = ETPeriodo.sTipoPeriodo.PeriodoCosteoProductos_Operador
            .Status = IIf(Cbo2.Value = "K1", "", "*")
            .Usuario = User_Sistema
            .Tipo = TipoG
        End With

        If Negocio.PeriodoCosteo.MantenedorPeriodoCosteo_Operador(Entidad.Periodo, Ls_PeriodoOperador) = True Then
            Call Inicio()
        End If
    End Sub

#End Region
#End Region

#Region "Procedimientos Publicos"
    Public Sub Actualizar()
        Call Inicio()
    End Sub

    Public Sub Cancelar()
        Call Inicio()
    End Sub

    Public Sub Nuevo()

        Select Case Tag
            Case "101"
              Call Nuevo_Cierre()
            Case "102"
                Call Nuevo_Facturacion()
            Case "103"
                Call Nuevo_Operador()
        End Select

    End Sub

    Public Sub Grabar()
        If Not (TipoG = eState.eNew OrElse TipoG = eState.eEdit) Then
            MsgBox("Debe Presionar antes el evento Nuevo o Modificar", MsgBoxStyle.Exclamation, msgComacsa)
        End If

        Select Case Tag
            Case "101"
                Call Grabar_Cierre()
            Case "102"
                Call Grabar_Facturacion()
            Case "103"
                Call Grabar_Operador()
        End Select

    End Sub

    Public Sub Eliminar()
        If Grid1.Rows.Count <= 0 Then Return
        If Grid1.ActiveRow Is Nothing Then Return
        If Not (TipoG = eState.eView) Then Return

        Entidad.Periodo = New ETPeriodo
        With Entidad.Periodo
            .Periodo = Grid1.ActiveRow.Cells("Periodo").Value
            .Anio = Grid1.ActiveRow.Cells("Anio").Value
            .Mes = Grid1.ActiveRow.Cells("Mes").Value
            .MesName = Grid1.ActiveRow.Cells("MesName").Value
            If Tag = "101" Then
                If Grid1.ActiveRow.Cells("Status").Value = "K2" Then
                    .Estado = ""
                Else
                    .Estado = "A"
                End If
            End If
            .Status = "*"
            .Usuario = User_Sistema
            .Tipo = 3
        End With

        Select Case Tag
            Case "101"
                If Negocio.PeriodoCosteo.MantenedorPeriodoCosteo(Entidad.Periodo) = True Then
                    Call Inicio()
                End If
            Case "102"
                If Negocio.PeriodoCosteo.MantenedorPeriodoCosteo_Facturacion(Entidad.Periodo, Ls_PeriodoFactura) = True Then
                    Call Inicio()
                End If
            Case "103"
                If Negocio.PeriodoCosteo.MantenedorPeriodoCosteo_Operador(Entidad.Periodo, Ls_PeriodoOperador) = True Then
                    Call Inicio()
                End If
        End Select
        
     

    End Sub

    Public Sub Modificar()
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No hay Registros a Editar", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        If Grid1.ActiveRow Is Nothing Then
            MsgBox("Seleccione un registro a Editar", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If
        Call HabilitarControles(True)
        Call Limpiar()
        TipoG = eState.eEdit
        Periodo = Grid1.ActiveRow.Cells("Periodo").Value

        Select Case Tag
            Case "101"
                Call Modificar_Cierre()
            Case "102", "103"
                Call Modificar_Facturacion_Operador()
        End Select

    End Sub

#End Region

#Region "Formulario"
    Private Sub frmPeriodoCosteo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Call Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub frmPeriodoCosteo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub
#End Region

#Region "Grilla"
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Exit Sub
        End If

        For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (xCol.Key = "Anio" OrElse xCol.Key = "MesName" OrElse xCol.Key = "Estado") Then
                xCol.Hidden = True
            Else
                xCol.Hidden = False
            End If
        Next
    End Sub
#End Region

#Region "Controles"
    Private Sub Dtp1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp1.ValueChanged
        Call LlenarMeses()
        Call CargarDetalle()
    End Sub

    Private Sub Cbo1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo1.ValueChanged
        Call CargarDetalle()
    End Sub

#End Region
    
    Private Sub Grid3_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid3.InitializeLayout
        If e Is Nothing Then
            Exit Sub
        End If

        For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (xCol.Key = "Codigo" OrElse xCol.Key = "Descripcion" _
                OrElse xCol.Key = "PlaCod" OrElse xCol.Key = "Operador" ) Then
                xCol.Hidden = True
            Else
                xCol.Hidden = False
            End If
        Next
    End Sub

    Private Sub Grid2_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles Grid2.ClickCellButton


        If e Is Nothing Then Exit Sub
        If Grid2.Rows.Count <= 0 Then Exit Sub
        If Grid2.ActiveRow Is Nothing Then Exit Sub
        Dim frm As New frmCConsutarComprobantePagoUnidProd
        frm.FechaInicio = FechaInicio
        frm.FechaTermino = FechaTermino
        frm.Cod_Prov = Grid2.ActiveRow.Cells("Cod_Prov").Value
        frm.Lbl2.Text = Grid2.ActiveRow.Cells("Codigo").Value
        frm.Lbl3.Text = Grid2.ActiveRow.Cells("Descripcion").Value
        frm.Lbl4.Text = Grid2.ActiveRow.Cells("Cod_Prov").Value
        frm.Lbl5.Text = Grid2.ActiveRow.Cells("RazSoc").Value
        frm.Dtp1.Value = FechaInicio
        frm.Dtp2.Value = FechaTermino
        frm.CargarDocumentos()
        frm.ShowDialog()

        Grid2.UpdateData()
        Grid2.Update()
        frm = Nothing
    End Sub

    Private Sub Grid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid2.InitializeLayout
        If e Is Nothing Then
            Exit Sub
        End If

        For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (xCol.Key = "Costeo" OrElse xCol.Key = "Codigo" _
                OrElse xCol.Key = "Descripcion" OrElse xCol.Key = "Propio" _
                OrElse xCol.Key = "SubCosteo" OrElse xCol.Key = "RazSoc" _
                OrElse xCol.Key = "Tipo_Doc_Name" OrElse xCol.Key = "Num_Doc" _
                OrElse xCol.Key = "Importe") Then
                xCol.Hidden = True
            Else
                xCol.Hidden = False
            End If
        Next
    End Sub

End Class