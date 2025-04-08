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
    Private Ls_ComprobPago_Mes As List(Of ETPeriodoDetalle) = Nothing

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
        Dim fechaTemp As Date = Date.Today
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim dup As Integer = 0
        Dim Porcentaje As Double = 0

        'ValidarRegistro = True
        ValidarRegistro = False
        Ep1.Clear()

        If Not (TipoG = eState.eNew OrElse TipoG = eState.eEdit) Then
            ValidarRegistro = False
            MsgBox("Debe Presionar el Evento Nuevo o Modificar antes de Grabar", MsgBoxStyle.Exclamation, msgComacsa)
            'Return False
            Return ValidarRegistro
        End If

        If String.IsNullOrEmpty(Cbo1.Value) Then
            Ep1.SetError(Cbo1, "Seleccione el Mes")
            'ValidarRegistro = False
            Cbo1.Focus()
            Return ValidarRegistro
        End If

        If Tag = "102" Then
            For Each xRow As ETPeriodoDetalle In Ls_PeriodoFactura
                If xRow.TipoPropio = "0" Then
                    'Ep1.SetError(Grid2, "Falta Registrar Activos")
                    'ValidarRegistro = False
                    MsgBox("Falta Registrar Activos", MsgBoxStyle.Exclamation, msgComacsa)
                    Return ValidarRegistro
                End If

                If xRow.SubTipo = "02" And xRow.Facturacion <= 0 Then
                    'Ep1.SetError(Grid2, "Agregue Todas las Facturas de Alquiler")
                    'ValidarRegistro = False
                    MsgBox("Agregue Todas las Facturas de Alquiler", MsgBoxStyle.Exclamation, msgComacsa)
                    Grid2.Focus()
                    Return ValidarRegistro
                End If

                If xRow.TipoCosteo = "02" And xRow.SubTipo = "01" And xRow.Facturacion <= 0 Then
                    i = i + 1
                End If
                If xRow.TipoCosteo = "01" And xRow.SubTipo = "01" And xRow.Facturacion <= 0 Then
                    j = j + 1
                End If

            Next

            If i > 0 Then
                If MsgBox("Está Seguro que los Cargadores Frontales no tuvieron Costo de Mantenimiento Automotriz", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Ok Then
                    'ValidarRegistro = False
                    Return ValidarRegistro
                End If
            End If
            If j > 0 Then
                If MsgBox("Está Seguro que los Camiones no tuvieron Costo de Mantenimiento Automotriz", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Ok Then
                    'ValidarRegistro = False
                    Return ValidarRegistro
                End If
            End If

            If (Val(DateDiff(DateInterval.Day, CDate(FechaTermino.ToShortDateString), CDate(Date.Today.ToShortDateString))) + 1) > 20 Then
                If String.IsNullOrEmpty(Txt3.Text.TrimEnd) Then
                    Ep1.SetError(Txt3, "Seleccione el Recibo del Gas Natural")
                    'ValidarRegistro = False
                    Txt3.Focus()
                    Return ValidarRegistro
                End If

                If Val(Txt5.Value) <= 0 Then
                    Ep1.SetError(Txt5, "Ingrese el Consumo de Gas Natutal(M3 STD)")
                    'ValidarRegistro = False
                    Txt5.Focus()
                    Return ValidarRegistro
                End If

                If Val(Txt6.Value) <= 0 Then
                    Ep1.SetError(Txt6, "Ingrese el Costo x m3 STD")
                    'ValidarRegistro = False
                    Txt6.Focus()
                    Return ValidarRegistro
                End If

                If String.IsNullOrEmpty(Txt9.Text.TrimEnd) Then
                    Ep1.SetError(Txt9, "Seleccione el Recibo de la Energía Eléctrica")
                    'ValidarRegistro = False
                    Txt9.Focus()
                    Return ValidarRegistro
                End If

                If Val(Txt11.Value) <= 0 Then
                    Ep1.SetError(Txt11, "Ingrese el Consumo de Energía Eléctrica(KWH)")
                    'ValidarRegistro = False
                    Txt11.Focus()
                    Return ValidarRegistro
                End If

                If Val(Txt12.Value) <= 0 Then
                    Ep1.SetError(Txt12, "Ingrese el Costo x KHW")
                    'ValidarRegistro = False
                    Txt12.Focus()
                    Return ValidarRegistro
                End If

            End If
        ElseIf Tag = "103" Then
            For Each xRow As ETPeriodoDetalle In Ls_PeriodoOperador
                If String.IsNullOrEmpty(xRow.PlaCod.TrimEnd) Then
                    'Ep1.SetError(Grid3, "Agregue al Operador del Cargador Frontal")
                    'ValidarRegistro = False
                    MsgBox("Agregue al Operador del Cargador Frontal", MsgBoxStyle.Exclamation, msgComacsa)
                    Grid3.Focus()
                    Return ValidarRegistro
                End If
            Next
        End If

        ValidarRegistro = True

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

        Txt1.Clear()
        Txt2.Clear()
        Txt3.Clear()

        Txt4.Value = 0
        Txt5.Value = 0
        Txt6.Value = 0

        Txt7.Clear()
        Txt8.Clear()
        Txt9.Clear()

        Txt10.Value = 0
        Txt11.Value = 0
        Txt12.Value = 0

        Txt1.Text = "PG0662"
        Txt2.Text = "GAS NATURAL DE LIMA Y CALLAO S.A."

        Txt7.Text = "PE0005"
        Txt8.Text = "EMPRESA DE DISTRIBUCION ELECTRICA LIMA NORTE S.A.A"

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
        Ls_ComprobPago_Mes = Nothing
        Ls_PeriodoFactura = New List(Of ETPeriodoDetalle)
        Ls_PeriodoOperador = New List(Of ETPeriodoDetalle)
        Ls_DocDetalle = New List(Of ETPeriodoDetalle)
        Ls_UnidDoc_ComprobPago = New List(Of ETPeriodoDetalle)
        Ls_ComprobPago_Mes = New List(Of ETPeriodoDetalle)

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

        Txt5.ReadOnly = Not xBol
        'Txt6.ReadOnly = Not xBol
        Txt11.ReadOnly = Not xBol
        'Txt12.ReadOnly = Not xBol
        Btn1.Enabled = xBol
        Btn2.Enabled = xBol
    End Sub

    Private Sub Inicio()
        Grb3.Visible = False
        Select Case Tag
            Case "101"
                Tab1.Tabs("T03").Visible = False
                Tab1.Tabs("T04").Visible = False
            Case "102"
                Tab1.Tabs("T04").Visible = False
                Grb3.Visible = True
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
            .Usuario = User_Sistema
        End With

        Entidad.MyLista = New ETMyLista
        Negocio.PeriodoCosteo = New NGPeriodoCosteo
        If Tag = "102" Then
            Ls_PeriodoFactura = Nothing
            Ls_PeriodoFactura = New List(Of ETPeriodoDetalle)
            Entidad.MyLista = Negocio.PeriodoCosteo.ConsultarPeriodo_Activo(Entidad.PeriodoDetalle)
            If Entidad.MyLista IsNot Nothing Then
                Ls_PeriodoFactura = Entidad.MyLista.Ls_PeriodoDetalle
            End If
            Call CargarUltraGrid(Grid2, Ls_PeriodoFactura)
            If TipoG = eState.eEdit Then
                Entidad.PeriodoDetalle.Tipo = 4
                Ls_UnidDoc_ComprobPago = Nothing
                Ls_UnidDoc_ComprobPago = New List(Of ETPeriodoDetalle)
                Entidad.MyLista = New ETMyLista
                Negocio.PeriodoCosteo = New NGPeriodoCosteo
                Entidad.MyLista = Negocio.PeriodoCosteo.ConsultarPeriodo_Activo_Facturacion(Entidad.PeriodoDetalle)
                If Entidad.MyLista IsNot Nothing Then
                    Ls_UnidDoc_ComprobPago = Entidad.MyLista.Ls_PeriodoDetalle
                End If
            End If
            Tab1.Tabs("T03").Selected = True
        Else
            Ls_PeriodoOperador = Nothing
            Ls_PeriodoOperador = New List(Of ETPeriodoDetalle)
            Entidad.MyLista = Negocio.PeriodoCosteo.ConsultarPeriodoCosteo_Operador(Entidad.PeriodoDetalle)
            If Entidad.MyLista IsNot Nothing Then
                Ls_PeriodoOperador = Entidad.MyLista.Ls_PeriodoDetalle
            End If
            Call CargarUltraGrid(Grid3, Ls_PeriodoOperador)
            Tab1.Tabs("T04").Selected = True
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
                Entidad.Periodo.Tipo = 10
            Case "103"
                Entidad.Periodo.TipoPeriodo = ETPeriodo.sTipoPeriodo.PeriodoCosteoProductos_Operador
                Entidad.Periodo.Tipo = 10
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
        Txt1.EndUpdate()
        Txt2.EndUpdate()
        Txt3.EndUpdate()
        Txt4.EndUpdate()
        Txt5.EndUpdate()
        Txt6.EndUpdate()

        Txt7.EndUpdate()
        Txt8.EndUpdate()
        Txt9.EndUpdate()
        Txt10.EndUpdate()
        Txt11.EndUpdate()
        Txt12.EndUpdate()


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

        Ls_ComprobPago_Mes = Nothing
        Ls_ComprobPago_Mes = New List(Of ETPeriodoDetalle)
        Entidad.PeriodoDetalle = New ETPeriodoDetalle
        With Entidad.PeriodoDetalle
            .Tipo_Doc = "34"
            .Cod_Prov = Txt1.Text.TrimEnd
            .Num_Doc = Txt3.Text.TrimEnd
            .Importe = Txt4.Value
            .Consumo = Txt5.Value
            .CostoUnitario = Val(Txt6.Value)
            .TipoCosteo = "1"
            .Tipo = 1
            .Usuario = User_Sistema
        End With
        If Not (String.IsNullOrEmpty(Txt3.Text.TrimEnd)) Then
            Ls_ComprobPago_Mes.Add(Entidad.PeriodoDetalle)
        End If
        
        Entidad.PeriodoDetalle = New ETPeriodoDetalle
        With Entidad.PeriodoDetalle
            .Tipo_Doc = "34"
            .Cod_Prov = Txt7.Text.TrimEnd
            .Num_Doc = Txt9.Text.TrimEnd
            .Importe = Txt10.Value
            .Consumo = Txt11.Value
            .CostoUnitario = Val(Txt12.Value)
            .TipoCosteo = "2"
            .Tipo = 1
            .Usuario = User_Sistema
        End With
        If Not (String.IsNullOrEmpty(Txt9.Text.TrimEnd)) Then
            Ls_ComprobPago_Mes.Add(Entidad.PeriodoDetalle)
        End If

        If Negocio.PeriodoCosteo.MantenedorPeriodoCosteo_Facturacion(Entidad.Periodo, Ls_PeriodoFactura, Ls_UnidDoc_ComprobPago, Ls_ComprobPago_Mes) = True Then
            Call Inicio()
        End If

    End Sub

    Private Sub Cargar_FacturacionMes()
        Ls_ComprobPago_Mes = Nothing
        Ls_ComprobPago_Mes = New List(Of ETPeriodoDetalle)
        Entidad.Periodo = New ETPeriodo
        Entidad.Periodo.Periodo = Periodo
        Entidad.Periodo.Tipo = 4
        Entidad.MyLista = New ETMyLista
        Negocio.PeriodoCosteo = New NGPeriodoCosteo
        Entidad.MyLista = Negocio.PeriodoCosteo.ConsultarPeriodoCosteo_ComprobantePago_Mes(Entidad.Periodo)
        If Entidad.MyLista IsNot Nothing Then
            If Entidad.MyLista.Validacion Then
                Ls_ComprobPago_Mes = Entidad.MyLista.Ls_PeriodoDetalle
            End If
        End If

        If Ls_ComprobPago_Mes.Count > 0 Then
            For Each xRow As ETPeriodoDetalle In Ls_ComprobPago_Mes
                If xRow.TipoCosteo = "1" Then
                    Txt1.Text = xRow.Cod_Prov
                    Txt2.Text = xRow.RazSoc
                    Txt3.Text = xRow.Num_Doc
                    Txt4.Value = xRow.Importe
                    Txt5.Value = xRow.Consumo
                    Txt6.Value = xRow.CostoUnitario
                Else
                    Txt7.Text = xRow.Cod_Prov
                    Txt8.Text = xRow.RazSoc
                    Txt9.Text = xRow.Num_Doc
                    Txt10.Value = xRow.Importe
                    Txt11.Value = xRow.Consumo
                    Txt12.Value = xRow.CostoUnitario
                End If
            Next
        End If
    End Sub
    Private Sub Modificar_Facturacion_Operador()
        TipoG = eState.eView
        Me.Dtp1.Value = Mid(Date.Today.ToShortDateString, 1, 6) & Grid1.ActiveRow.Cells("Anio").Value
        Me.Cbo1.Value = Grid1.ActiveRow.Cells("Mes").Value
        Cbo2.Value = "K1"
        TipoG = eState.eEdit
        Call CargarDetalle()
        If Tag = "102" Then
            Call Cargar_FacturacionMes()
        End If
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
                If Negocio.PeriodoCosteo.MantenedorPeriodoCosteo_Facturacion(Entidad.Periodo, Ls_PeriodoFactura, Ls_UnidDoc_ComprobPago, Ls_ComprobPago_Mes) = True Then
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

    Private Sub Grid3_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles Grid3.ClickCellButton
        If e Is Nothing Then
            Exit Sub
        End If

        If Grid3.Rows.Count <= 0 Then Exit Sub
        If Grid3.ActiveRow Is Nothing Then Exit Sub
        If String.IsNullOrEmpty(Cbo1.Value) Then
            MsgBox("Seleccione el Mes", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        FechaInicio = CDate(("01/" & CStr(Cbo1.Value) & "/" & Year(Dtp1.Value)))
        FechaTermino = DateAdd(DateInterval.Month, 1, FechaInicio)
        FechaTermino = DateAdd(DateInterval.Second, -1, FechaTermino)

        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Personal_Obrero
        frmHijo.ShowDialog()
        Grid3.ActiveRow.Cells("PlaCod").Value = frmHijo.Flag2.Trim
        Grid3.ActiveRow.Cells("Personal").Value = frmHijo.Descripcion.Trim
        Grid3.UpdateData()
        Grid3.Update()
        frmHijo = Nothing

    End Sub
    
    Private Sub Grid3_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid3.InitializeLayout
        If e Is Nothing Then
            Exit Sub
        End If

        For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (xCol.Key = "Codigo" OrElse xCol.Key = "Descripcion" _
                OrElse xCol.Key = "PlaCod" OrElse xCol.Key = "Personal") Then
                xCol.Hidden = True
            Else
                xCol.Hidden = False
            End If
        Next
    End Sub

    Private Sub Grid2_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles Grid2.ClickCellButton
        Dim Existe As Integer = 0
        Dim Contar As Integer = 0

        If e Is Nothing Then Exit Sub
        If Grid2.Rows.Count <= 0 Then Exit Sub
        If Grid2.ActiveRow Is Nothing Then Exit Sub
        Dim frm As New frmCConsutarComprobantePagoUnidProd
        frm.FechaInicio = FechaInicio
        frm.Tipo_Doc = "01"
        frm.FechaTermino = FechaTermino
        frm.Cod_Prov = Grid2.ActiveRow.Cells("Cod_Prov").Value
        frm.Codigo = Grid2.ActiveRow.Cells("Codigo").Value
        frm.Lbl2.Text = Grid2.ActiveRow.Cells("Codigo").Value
        frm.Lbl3.Text = Grid2.ActiveRow.Cells("Descripcion").Value
        frm.Lbl4.Text = Grid2.ActiveRow.Cells("Cod_Prov").Value
        frm.Lbl5.Text = Grid2.ActiveRow.Cells("RazSoc").Value
        frm.Dtp1.Value = FechaInicio
        frm.Dtp2.Value = FechaTermino
        If e.Cell.Column.Key = "Add" Then
            frm.Btn4.Visible = False
            frm.CargarDocumentos()
        Else
            frm.Btn3.Visible = False
            If Ls_UnidDoc_ComprobPago.Count > 0 Then
                For Each xRow As ETPeriodoDetalle In Ls_UnidDoc_ComprobPago
                    If xRow.Codigo.TrimEnd = Grid2.ActiveRow.Cells("Codigo").Value.ToString.TrimEnd Then
                        frm.Ls_Documentos.Add(xRow)
                    End If
                Next
            End If
            frm.VerDocumentos()
        End If
        frm.ShowDialog()
        If Ls_UnidDoc_ComprobPago.Count <= 0 Then
            Ls_UnidDoc_ComprobPago = frm.Ls_Documentos
        Else
            If frm.Ls_Documentos.Count > 0 Then
                If e.Cell.Column.Key = "Add" Then
                    For Each xRow As ETPeriodoDetalle In frm.Ls_Documentos
                        Existe = 0
                        For Each yRow As ETPeriodoDetalle In Ls_UnidDoc_ComprobPago
                            If xRow.Cod_Prov = yRow.Cod_Prov And xRow.Tipo_Doc = yRow.Tipo_Doc _
                             And xRow.Num_Doc = yRow.Num_Doc Then
                                Existe = Existe + 1
                            End If
                        Next
                        If Existe = 0 Then
                            Ls_UnidDoc_ComprobPago.Add(xRow)
                        End If
                    Next
                Else
                    Dim i As Integer = 0
                    While i < Ls_UnidDoc_ComprobPago.Count

                        If Grid2.ActiveRow.Cells("Codigo").Value.ToString.TrimEnd = Ls_UnidDoc_ComprobPago(i).Codigo.TrimEnd Then
                            Ls_UnidDoc_ComprobPago.RemoveAt(i)
                        Else
                            i = i + 1
                        End If

                    End While

                    'For Each yRow As ETPeriodoDetalle In Ls_UnidDoc_ComprobPago
                    '    If Grid2.ActiveRow.Cells("Codigo").Value.ToString.TrimEnd = yRow.Codigo.TrimEnd Then
                    '        Ls_UnidDoc_ComprobPago.Remove(yRow)
                    '    End If
                    'Next

                    For Each xRow As ETPeriodoDetalle In frm.Ls_Documentos
                        Ls_UnidDoc_ComprobPago.Add(xRow)
                    Next
                End If
               
            End If
        End If

        If Ls_UnidDoc_ComprobPago.Count > 0 Then
            For Each xRow As ETPeriodoDetalle In Ls_UnidDoc_ComprobPago
                If xRow.Codigo.TrimEnd = Grid2.ActiveRow.Cells("Codigo").Value.ToString.TrimEnd Then
                    Contar = Contar + 1
                End If
            Next
        End If

        Grid2.ActiveRow.Cells("Facturacion").Value = Contar

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
                OrElse xCol.Key = "Facturacion" OrElse xCol.Key = "Add" _
                OrElse xCol.Key = "Ver") Then
                xCol.Hidden = True
            Else
                xCol.Hidden = False
            End If
        Next
    End Sub

    Private Sub CalcularCostoUnitario(ByVal Tipo As Integer)
        If Tipo = 1 Then
            If Txt5.Value > 0 Then
                Txt6.Value = (Val(Txt4.Value) / Val(Txt5.Value))
            Else
                Txt6.Value = 0
            End If

        Else
            If Txt11.Value > 0 Then
                Txt12.Value = (Val(Txt10.Value) / Val(Txt11.Value))
            Else
                Txt12.Value = 0
            End If
        End If
    End Sub

    Private Sub Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click, Btn2.Click

        Dim FechaTerminoTemp As Date
        If String.IsNullOrEmpty(Cbo1.Value) Then
            MsgBox("Seleccione el Mes", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        Dim frm As New frmCConsutarComprobantePagoUnidProd
        FechaTerminoTemp = DateAdd(DateInterval.Second, -1, DateAdd(DateInterval.Month, 2, FechaInicio))
        frm.FechaInicio = FechaInicio
        frm.FechaTermino = FechaTerminoTemp
        frm.VisibleCheck = Boolean.FalseString
        frm.Tipo_Doc = "34"
        If sender Is Btn1 Then
            frm.Cod_Prov = Txt1.Text.TrimEnd
            frm.Lbl4.Text = Txt1.Text.TrimEnd
            frm.Lbl5.Text = Txt2.Text.TrimEnd
        Else
            frm.Cod_Prov = Txt7.Text.TrimEnd
            frm.Lbl4.Text = Txt7.Text.TrimEnd
            frm.Lbl5.Text = Txt8.Text.TrimEnd
        End If

        frm.Lbl1.Visible = False
        frm.Lbl2.Visible = False
        frm.Lbl3.Visible = False
       
        frm.Dtp1.Value = FechaInicio
        frm.Dtp2.Value = FechaTerminoTemp
        frm.Btn4.Visible = False
        frm.Btn3.Visible = False
        'frm.Dtp1.Enabled = True
        frm.CargarDocumentos()
        frm.ShowDialog()
        If sender Is Btn1 Then
            Txt3.Text = frm.Num_Doc
            Txt4.Value = frm.Importe
            Call CalcularCostoUnitario(1)
        Else
            Txt9.Text = frm.Num_Doc
            Txt10.Value = frm.Importe
            Call CalcularCostoUnitario(2)
        End If
       
        frm = Nothing
    End Sub


    Private Sub Txt5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt5.ValueChanged
        Call CalcularCostoUnitario(1)
    End Sub

    Private Sub Txt11_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt11.ValueChanged
        Call CalcularCostoUnitario(2)
    End Sub

End Class