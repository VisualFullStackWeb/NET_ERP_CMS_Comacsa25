Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmLCosteoPlantaCemento

#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)

    Private Ls_Periodo As List(Of ETPeriodo) = Nothing
    Private Ls_UnidadProd As List(Of ETActivo) = Nothing
    Private Ls_UnidadProd_Del As List(Of ETActivo) = Nothing
    Private Ls_Mineral As List(Of ETProducto) = Nothing
    Private Ls_Mineral_Del As List(Of ETProducto) = Nothing
    Private Ls_Suministro As List(Of ETProducto) = Nothing
    Private Ls_Suministro_Del As List(Of ETProducto) = Nothing
    Private Ls_ManoObra As List(Of ETPersonal) = Nothing
    Private Ls_ManoObra_Del As List(Of ETPersonal) = Nothing

    Private Ls_Mineral_Temp As List(Of ETProducto) = Nothing
    Private Ls_Suministro_Temp As List(Of ETProducto) = Nothing
    Private Ls_ManoObra_Temp As List(Of ETPersonal) = Nothing

    Private Enum eState
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
        eClonar = 7
    End Enum

    Private TipoG As eState
    Private TipoGDetUnidadProd As eState
    Private TipoGDetMinerales As eState
    Private TipoGDetSuministros As eState
    Private TipoGDetManoObra As eState
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
    Private Function ValidarUnidadProd() As Boolean
        Dim i As Integer = -1
        Dim dup As Integer = 0
        Dim Consumo As Double = 0
        ValidarUnidadProd = True

        If String.IsNullOrEmpty(Txt2.Text.Trim) Then
            MsgBox("Seleccione la Unidad de Producción", MsgBoxStyle.Critical, msgComacsa)
            ValidarUnidadProd = False
            Exit Function
        End If

        For Each xRow As UltraGridRow In Grid2.Rows
            i = i + 1

            If TipoGDetUnidadProd = eState.eNew Then
                If xRow.Cells("Codigo").Value.ToString.Trim = Txt2.Text.Trim Then
                    dup = dup + 1
                End If
            ElseIf TipoGDetUnidadProd = eState.eEdit Then
                If xRow.Cells("Codigo").Value.ToString.Trim = Txt2.Text.Trim Then
                    If Val(i) <> Val(Grid2.ActiveRow.Index) Then
                        dup = dup + 1
                    End If
                End If
            End If
        Next

        If dup > 0 Then
            MsgBox("Ya se agrego la Unidad de Producción: " & Txt2.Text.Trim & " - " & Txt3.Text.Trim, MsgBoxStyle.Critical, msgComacsa)
            ValidarUnidadProd = False
            Exit Function
        End If

    End Function
    Private Function ValidarMinerales() As Boolean
        Dim i As Integer = -1
        Dim dup As Integer = 0
        Dim Consumo As Double = 0
        Dim lResult As Boolean = True
        lResult = True

        If String.IsNullOrEmpty(Txt4.Text.Trim) Then
            MsgBox("Seleccione un Mineral", MsgBoxStyle.Critical, msgComacsa)
            lResult = False
            Exit Function
        End If

        For Each xRow As UltraGridRow In Grid3.Rows
            i = i + 1

            If TipoGDetMinerales = eState.eNew Then
                If xRow.Cells("CodProducto").Value.ToString.Trim = Txt4.Text.Trim Then
                    dup = dup + 1
                End If
            ElseIf TipoGDetMinerales = eState.eEdit Then
                If xRow.Cells("CodProducto").Value.ToString.Trim = Txt4.Text.Trim Then
                    If Val(i) <> Val(Grid3.ActiveRow.Index) Then
                        dup = dup + 1
                    End If
                End If
            End If
        Next

        If dup > 0 Then
            MsgBox("Ya se agrego el Mineral: " & Txt4.Text.Trim & " - " & Txt5.Text.Trim, MsgBoxStyle.Critical, msgComacsa)
            lResult = False
            Exit Function

        End If
        Return lResult
    End Function
    Private Function ValidarSuministros() As Boolean
        Dim i As Integer = -1
        Dim dup As Integer = 0
        Dim Consumo As Double = 0
        Dim lResult As Boolean = True
        lResult = True

        If String.IsNullOrEmpty(Txt7.Text.Trim) Then
            MsgBox("Seleccione un Suministro", MsgBoxStyle.Critical, msgComacsa)
            lResult = False
            Exit Function
        End If

        For Each xRow As UltraGridRow In Grid4.Rows
            i = i + 1

            If TipoGDetSuministros = eState.eNew Then
                If xRow.Cells("CodProducto").Value.ToString.Trim = Txt7.Text.Trim Then
                    dup = dup + 1
                End If
            ElseIf TipoGDetSuministros = eState.eEdit Then
                If xRow.Cells("CodProducto").Value.ToString.Trim = Txt7.Text.Trim Then
                    If Val(i) <> Val(Grid4.ActiveRow.Index) Then
                        dup = dup + 1
                    End If
                End If
            End If
        Next

        If dup > 0 Then
            MsgBox("Ya se agrego el Suministro: " & Txt7.Text.Trim & " - " & Txt8.Text.Trim, MsgBoxStyle.Critical, msgComacsa)
            lResult = False
            Exit Function
        End If
        Return lResult
    End Function

    Private Function ValidarManoObra() As Boolean
        Dim i As Integer = -1
        Dim dup As Integer = 0
        Dim Consumo As Double = 0
        Dim lResult As Boolean = True
        lResult = True

        If String.IsNullOrEmpty(Txt13.Text.Trim) Then
            MsgBox("Seleccione al Personal", MsgBoxStyle.Critical, msgComacsa)
            lResult = False
            Exit Function
        End If

        For Each xRow As UltraGridRow In Grid5.Rows
            i = i + 1

            If TipoGDetSuministros = eState.eNew Then
                If xRow.Cells("CodPersonal").Value.ToString.Trim = Txt13.Text.Trim Then
                    dup = dup + 1
                End If
            ElseIf TipoGDetSuministros = eState.eEdit Then
                If xRow.Cells("CodPersonal").Value.ToString.Trim = Txt13.Text.Trim Then
                    If Val(i) <> Val(Grid5.ActiveRow.Index) Then
                        dup = dup + 1
                    End If
                End If
            End If
        Next

        If dup > 0 Then
            MsgBox("Ya se agrego al Personal: " & Txt13.Text.Trim & " - " & Txt14.Text.Trim, MsgBoxStyle.Critical, msgComacsa)
            lResult = False
            Exit Function
        End If
        Return lResult
    End Function


#End Region

#Region "Procedimientos Privados"
    Private Sub Cargar_Grilla()
        Entidad.Periodo = New ETPeriodo
        Entidad.Periodo.TipoPeriodo = ETPeriodo.sTipoPeriodo.CosteoPlantaCemento
        Entidad.Periodo.Tipo = 6

        Ls_Periodo = Nothing
        Ls_Periodo = New List(Of ETPeriodo)

        Entidad.MyLista = New ETMyLista
        Negocio.PeriodoPlantaCemento = New NGPeriodoPlantaCemento
        Entidad.MyLista = Negocio.PeriodoPlantaCemento.Consultar_Periodo(Entidad.Periodo)
        If Entidad.MyLista IsNot Nothing Then
            Ls_Periodo = Entidad.MyLista.Ls_Periodo
        End If
        Call CargarUltraGrid(Grid1, Ls_Periodo)
    End Sub

    Private Sub Inicio()
        TipoG = eState.eView
        TipoGDetUnidadProd = eState.eView
        TipoGDetManoObra = eState.eView
        TipoGDetSuministros = eState.eView
        TipoGDetMinerales = eState.eView

        Call HabilitarControles(False)
        Call InHabilitarControlesDetalle(True)
        Call Limpiar()
        Call Cargar_Grilla()
        Tab2.Tabs("T01").Selected = True
        Tab1.Tabs("T01").Selected = True

    End Sub
    Private Sub LimpiarTemp()
        Ls_Suministro_Temp = Nothing
        Ls_ManoObra_Temp = Nothing
        Ls_Mineral_Temp = Nothing
        Ls_Suministro_Temp = New List(Of ETProducto)
        Ls_ManoObra_Temp = New List(Of ETPersonal)
        Ls_Mineral_Temp = New List(Of ETProducto)

        Call CargarUltraGrid(Grid3, Ls_Mineral_Temp)
        Call CargarUltraGrid(Grid4, Ls_Suministro_Temp)
        Call CargarUltraGrid(Grid5, Ls_ManoObra_Temp)
    End Sub

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
        Call LimpiarDetalle()

        Dtp1.Value = Now
        Call LlenarMeses()
        If Cbo1.Items.Count > 0 Then
            Cbo1.Value = ""
        End If
        Cbo2.Value = "K1"
        _Periodo = 0


        Ls_UnidadProd = Nothing
        Ls_UnidadProd_Del = Nothing

        Ls_Suministro = Nothing
        Ls_Suministro_Del = Nothing
        Ls_Suministro_Temp = Nothing

        Ls_ManoObra = Nothing
        Ls_ManoObra_Del = Nothing
        Ls_ManoObra_Temp = Nothing

        Ls_Mineral = Nothing
        Ls_Mineral_Del = Nothing
        Ls_Mineral_Temp = Nothing


        Ls_UnidadProd = New List(Of ETActivo)
        Ls_UnidadProd_Del = New List(Of ETActivo)
        Ls_Suministro = New List(Of ETProducto)
        Ls_Suministro_Del = New List(Of ETProducto)
        Ls_Suministro_Temp = New List(Of ETProducto)

        Ls_ManoObra = New List(Of ETPersonal)
        Ls_ManoObra_Del = New List(Of ETPersonal)
        Ls_ManoObra_Temp = New List(Of ETPersonal)

        Ls_Mineral = New List(Of ETProducto)
        Ls_Mineral_Del = New List(Of ETProducto)
        Ls_Mineral_Temp = New List(Of ETProducto)

        Cbo3.DataSource = Nothing
        Call CargarUltraGrid(Grid2, Ls_UnidadProd)
        Call CargarUltraCombo(Cbo3, Ls_UnidadProd, "Codigo", "Descripcion")
        Call CargarUltraGrid(Grid3, Ls_Mineral_Temp)
        Call CargarUltraGrid(Grid4, Ls_Suministro_Temp)
        Call CargarUltraGrid(Grid5, Ls_ManoObra_Temp)

    End Sub

    Private Sub LimpiarDetalle()
        Call LimpiarUnidadProduccion()
        Call LimpiarMinerales()
        Call LimpiarSuministros()
        Call LimpiarManoObra()
        Call LimpiarOtros()
    End Sub

    Private Sub LimpiarUnidadProduccion()
        Txt2.Clear()
        Txt3.Clear()
    End Sub

    Private Sub LimpiarMinerales()
        Txt4.Clear()
        Txt5.Clear()
        Txt6.Value = 0
    End Sub

    Private Sub LimpiarSuministros()
        Txt7.Clear()
        Txt8.Clear()
        Txt9.Value = 0
        Txt10.Clear()
    End Sub

    Private Sub LimpiarManoObra()
        Txt13.Clear()
        Txt14.Clear()
        Txt15.Value = 0
    End Sub

    Private Sub LimpiarOtros()
        Txt11.Value = 0
        Txt12.Value = 0
    End Sub

    Private Sub HabilitarControles(ByVal xBol As Boolean)
        Dtp1.ReadOnly = Not xBol
        Cbo1.ReadOnly = Not xBol
        Cbo2.ReadOnly = True
    End Sub

    Private Sub HabilitarControlesDetalle(ByVal xBol As Boolean)
        Call HabilitarControlesUnidadProduccion(xBol)
        Call HabilitarControlesMinerales(xBol)
        Call HabilitarControlesSuministros(xBol)
        Call HabilitarControlesManoObra(xBol)
        Txt11.ReadOnly = True
        Txt12.ReadOnly = True
    End Sub

    Private Sub HabilitarControlesUnidadProduccion(ByVal xBol As Boolean)
        Txt2.ReadOnly = True
        Txt3.ReadOnly = True
        Btn1.Enabled = True
        Btn2.Enabled = xBol
        Btn3.Enabled = Not xBol
        Btn4.Enabled = Not xBol
        Grid2.Enabled = xBol
    End Sub

    Private Sub HabilitarControlesMinerales(ByVal xBol As Boolean)
        Txt4.ReadOnly = True
        Txt5.ReadOnly = True
        Txt6.ReadOnly = Not xBol
        Btn5.Enabled = True
        Btn6.Enabled = xBol
        Btn7.Enabled = Not xBol
        Btn8.Enabled = Not xBol
        Grid3.Enabled = xBol
    End Sub

    Private Sub HabilitarControlesSuministros(ByVal xBol As Boolean)
        Txt7.ReadOnly = True
        Txt8.ReadOnly = True
        Txt9.ReadOnly = Not xBol
        Txt10.ReadOnly = True
        Btn9.Enabled = True
        Btn10.Enabled = xBol
        Btn11.Enabled = Not xBol
        Btn12.Enabled = Not xBol
        Grid4.Enabled = xBol
    End Sub

    Private Sub HabilitarControlesManoObra(ByVal xBol As Boolean)
        Txt13.ReadOnly = True
        Txt14.ReadOnly = True
        Txt15.ReadOnly = Not xBol
        Btn13.Enabled = True
        Btn14.Enabled = xBol
        Btn15.Enabled = Not xBol
        Btn16.Enabled = Not xBol
        Grid5.Enabled = xBol
    End Sub

    Private Sub InHabilitarControlesDetalle(ByVal xBol As Boolean)

        Txt2.ReadOnly = xBol
        Txt3.ReadOnly = xBol
        Txt4.ReadOnly = xBol
        Txt5.ReadOnly = xBol
        Txt6.ReadOnly = xBol
        Txt7.ReadOnly = xBol
        Txt8.ReadOnly = xBol
        Txt9.ReadOnly = xBol
        Txt10.ReadOnly = xBol
        Txt11.ReadOnly = xBol
        Txt12.ReadOnly = xBol
        Txt13.ReadOnly = xBol
        Txt14.ReadOnly = xBol
        Txt15.ReadOnly = xBol
        Btn1.Enabled = Not xBol
        Btn2.Enabled = Not xBol
        Btn3.Enabled = Not xBol
        Btn4.Enabled = Not xBol
        Btn5.Enabled = Not xBol
        Btn6.Enabled = Not xBol
        Btn7.Enabled = Not xBol
        Btn8.Enabled = Not xBol
        Btn9.Enabled = Not xBol
        Btn10.Enabled = Not xBol
        Btn11.Enabled = Not xBol
        Btn12.Enabled = Not xBol
        Btn13.Enabled = Not xBol
        Btn14.Enabled = Not xBol
        Btn15.Enabled = Not xBol
        Btn16.Enabled = Not xBol
        Grid2.Enabled = xBol
        Grid3.Enabled = xBol
        Grid4.Enabled = xBol
        Grid5.Enabled = xBol
    End Sub

    Private Sub Cargar_Detalle()
        Call Cargar_UnidadProduccion()
        Call Cargar_Minerales()
        Call Cargar_Suministros()
        Call Cargar_Personal()
    End Sub

    Private Sub Cargar_UnidadProduccion()
        Entidad.Periodo = New ETPeriodo
        Entidad.Periodo.Periodo = Me.Periodo
        Entidad.Periodo.Tipo = 4

        Ls_UnidadProd_Del = Nothing
        Ls_UnidadProd_Del = New List(Of ETActivo)

        Ls_UnidadProd = Nothing
        Ls_UnidadProd = New List(Of ETActivo)
        Entidad.MyLista = New ETMyLista
        Negocio.PeriodoPlantaCemento = New NGPeriodoPlantaCemento
        Entidad.MyLista = Negocio.PeriodoPlantaCemento.Consultar_PeriodoPlantaCemento_UnidadProduccion(Entidad.Periodo)
        If Entidad.MyLista IsNot Nothing Then
            Ls_UnidadProd = Entidad.MyLista.Ls_Activo
        End If
        Call CargarUltraGrid(Grid2, Ls_UnidadProd)
    End Sub

    Private Sub Cargar_Minerales()
        Entidad.Periodo = New ETPeriodo
        Entidad.Periodo.Periodo = Me.Periodo
        Entidad.Periodo.Tipo = 4

        Ls_Mineral_Del = Nothing
        Ls_Mineral_Del = New List(Of ETProducto)

        Ls_Mineral = Nothing
        Ls_Mineral = New List(Of ETProducto)
        Entidad.MyLista = New ETMyLista
        Negocio.PeriodoPlantaCemento = New NGPeriodoPlantaCemento
        Entidad.MyLista = Negocio.PeriodoPlantaCemento.Consultar_PeriodoPlantaCemento_Minerales(Entidad.Periodo)
        If Entidad.MyLista IsNot Nothing Then
            Ls_Mineral = Entidad.MyLista.Ls_Producto
        End If
        'Call CargarUltraGrid(Grid3, Ls_Mineral)
    End Sub

    Private Sub Cargar_Suministros()
        Entidad.Periodo = New ETPeriodo
        Entidad.Periodo.Periodo = Me.Periodo
        Entidad.Periodo.Tipo = 4

        Ls_Suministro_Del = Nothing
        Ls_Suministro_Del = New List(Of ETProducto)

        Ls_Suministro = Nothing
        Ls_Suministro = New List(Of ETProducto)
        Entidad.MyLista = New ETMyLista
        Negocio.PeriodoPlantaCemento = New NGPeriodoPlantaCemento
        Entidad.MyLista = Negocio.PeriodoPlantaCemento.Consultar_PeriodoPlantaCemento_Suministro(Entidad.Periodo)
        If Entidad.MyLista IsNot Nothing Then
            Ls_Suministro = Entidad.MyLista.Ls_Producto
        End If
        'Call CargarUltraGrid(Grid4, Ls_Suministro)
    End Sub

    Private Sub Cargar_Personal()
        Entidad.Periodo = New ETPeriodo
        Entidad.Periodo.Periodo = Me.Periodo
        Entidad.Periodo.Tipo = 4

        Ls_ManoObra_Del = Nothing
        Ls_ManoObra_Del = New List(Of ETPersonal)

        Ls_ManoObra = Nothing
        Ls_ManoObra = New List(Of ETPersonal)
        Entidad.MyLista = New ETMyLista
        Negocio.PeriodoPlantaCemento = New NGPeriodoPlantaCemento
        Entidad.MyLista = Negocio.PeriodoPlantaCemento.Consultar_PeriodoPlantaCemento_ManoObra(Entidad.Periodo)
        If Entidad.MyLista IsNot Nothing Then
            Ls_ManoObra = Entidad.MyLista.Ls_Personal
        End If
        'Call CargarUltraGrid(Grid5, Ls_ManoObra)
    End Sub

    Private Sub Cargar_OtrosCostos()
        Dim Fecha As Date
        If String.IsNullOrEmpty(Cbo1.Value) Then
            MsgBox("Seleccione el Mes", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If
        Fecha = CDate(("01/" & CStr(Cbo1.Value) & "/" & CStr(Year(Dtp1.Value))))

        Entidad.CosteoActivo = New ETCosteoActivo
        Entidad.CosteoActivo.Codigo = Cbo3.Value
        Entidad.CosteoActivo.Fecha = Fecha
        Entidad.CosteoActivo.Tipo = 1

        Negocio.PeriodoPlantaCemento = New NGPeriodoPlantaCemento
        Txt11.Value = Negocio.PeriodoPlantaCemento.Consultar_PeriodoPlantaCemento_Otros(Entidad.CosteoActivo)

        Entidad.CosteoActivo.Tipo = 2
        Negocio.PeriodoPlantaCemento = New NGPeriodoPlantaCemento
        Txt12.Value = Negocio.PeriodoPlantaCemento.Consultar_PeriodoPlantaCemento_Otros(Entidad.CosteoActivo)

    End Sub

    Private Sub BuscarUnidadProduccion()
        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Catalogo_Activos
        frmHijo.ShowDialog()
        Txt2.Text = frmHijo.Flag2.Trim
        Txt3.Text = frmHijo.Descripcion.Trim
        Btn2.Focus()
        frmHijo = Nothing
    End Sub

    Private Sub BuscarMinerales()
        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Producto_Minerales
        frmHijo.ShowDialog()
        Txt4.Text = frmHijo.Flag2.Trim
        Txt5.Text = frmHijo.Descripcion.Trim
        Btn6.Focus()
        frmHijo = Nothing
    End Sub

    Private Sub BuscarSuministros()
        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Producto_Suministros
        frmHijo.ShowDialog()
        Txt7.Text = frmHijo.Flag2.Trim
        Txt8.Text = frmHijo.Descripcion.Trim
        Txt10.Text = frmHijo.Flag3.Trim
        Btn10.Focus()
        frmHijo = Nothing
    End Sub
    Private Sub Nuevo1()
        TipoG = eState.eNew
        TipoGDetUnidadProd = eState.eView
        TipoGDetMinerales = eState.eView
        TipoGDetSuministros = eState.eView
        TipoGDetManoObra = eState.eView
        Call Limpiar()
        Call HabilitarControles(True)
        Call HabilitarControlesDetalle(False)
        Tab1.Tabs("T03").Enabled = True
        Tab1.Tabs("T02").Selected = True
        Tab1.Tabs("T03").Enabled = True
        Dtp1.Focus()
    End Sub

    Private Sub Nuevo2()
        TipoG = eState.eClonar
        TipoGDetUnidadProd = eState.eView
        TipoGDetMinerales = eState.eView
        TipoGDetSuministros = eState.eView
        TipoGDetManoObra = eState.eView
        Me.Cbo1.Value = ""
        Call HabilitarControles(True)
        Call HabilitarControlesDetalle(False)
        Btn1.Enabled = False
        Btn2.Enabled = False
        Btn3.Enabled = False
        Btn4.Enabled = False
        Tab1.Tabs("T02").Selected = True
        Tab1.Tabs("T03").Enabled = False
        Dtp1.Focus()
    End Sub
    Private Sub BuscarManoObra()
        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Personal_LineaProduccion
        frmHijo.ShowDialog()
        Txt13.Text = frmHijo.Flag2.Trim
        Txt14.Text = frmHijo.Descripcion.Trim
        Btn14.Focus()
        frmHijo = Nothing
    End Sub

#End Region

#Region "Procedimientos Publicos"
    Public Sub Buscar()

        If Tab1.Tabs("T02").Selected = True Then
            If Not (TipoGDetUnidadProd = eState.eNew OrElse TipoGDetUnidadProd = eState.eEdit) Then
                MsgBox("Debe Presionar antes el evento Nuevo o Modificar de la Unidad de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            Else
                Call BuscarUnidadProduccion()
            End If

        ElseIf Tab1.Tabs("T03").Selected = True Then
            If Tab2.Tabs("T01").Selected = True Then
                If Not (TipoGDetMinerales = eState.eNew OrElse TipoGDetMinerales = eState.eEdit) Then
                    MsgBox("Debe Presionar antes el evento Nuevo o Modificar de la Pestaña de Minerales", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                Else
                    Call BuscarMinerales()
                End If
            ElseIf Tab2.Tabs("T02").Selected = True Then
                If Not (TipoGDetSuministros = eState.eNew OrElse TipoGDetSuministros = eState.eEdit) Then
                    MsgBox("Debe Presionar antes el evento Nuevo o Modificar de la Pestaña de Suministros", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                Else
                    Call BuscarSuministros()
                End If
            ElseIf Tab2.Tabs("T03").Selected = True Then
                If Not (TipoGDetManoObra = eState.eNew OrElse TipoGDetManoObra = eState.eEdit) Then
                    MsgBox("Debe Presionar antes el evento Nuevo o Modificar de la Pestaña de Mano de Obra", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                Else
                    Call BuscarManoObra()
                End If
            End If

        End If


    End Sub

    Public Sub Nuevo()
        If TipoG = eState.eEdit Then
            If MsgBox("Desea Tener como Plantilla al Periodo: " & NameMes(Me.Cbo1.Value) & Space(1) & Year(Me.Dtp1.Value), MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Call Nuevo1()
            Else
                Call Nuevo2()
            End If
        Else
            Call Nuevo1()
        End If
    End Sub

   

    Public Sub Grabar()
        If Not (TipoG = eState.eNew OrElse TipoG = eState.eEdit OrElse TipoG = eState.eClonar) Then
            MsgBox("Debe Presionar antes el evento Nuevo o Modificar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        Grid2.UpdateData()
        Grid3.UpdateData()
        Grid4.UpdateData()
        Grid5.UpdateData()


        Entidad.Periodo = New ETPeriodo

        With Entidad.Periodo
            .Periodo = Me.Periodo
            .Anio = Year(Dtp1.Value)
            If Cbo1.Items.Count > 0 Then
                .Mes = Cbo1.Value
            End If
            .TipoPeriodo = ETPeriodo.sTipoPeriodo.CosteoPlantaCemento
            .Status = IIf(Cbo2.Value = "K1", "", "*")
            .Usuario = User_Sistema
            .Tipo = TipoG
        End With


        If Negocio.PeriodoPlantaCemento.Mantenedor_PeriodoPlantaCemento(Entidad.Periodo, Ls_UnidadProd, Ls_UnidadProd_Del, Ls_Mineral, Ls_Mineral_Del, Ls_Suministro, Ls_Suministro_Del, Ls_ManoObra, Ls_ManoObra_Del) > 0 Then
            Call Inicio()
        End If
    End Sub

    Public Sub Modificar()
        If Grid1.Rows.Count <= 0 Then Return
        If Grid1.ActiveRow Is Nothing Then Return
        TipoG = eState.eEdit
        Call Limpiar()
        Call HabilitarControles(True)
        Call HabilitarControlesDetalle(False)
        Tab1.Tabs("T03").Enabled = True
        Grid2.Enabled = True
        Grid3.Enabled = True
        Grid4.Enabled = True
        Grid5.Enabled = True
        Periodo = Grid1.ActiveRow.Cells("Periodo").Value
        Me.Dtp1.Value = Mid(Date.Today.ToShortDateString, 1, 6) & Grid1.ActiveRow.Cells("Anio").Value
        Call LlenarMeses()
        Me.Cbo1.Value = Grid1.ActiveRow.Cells("Mes").Value
        If Grid1.ActiveRow.Cells("Status").Value = "*" Then
            Cbo2.Value = "K2"
        Else
            Cbo2.Value = "K1"
        End If
        'Call Cargar_UnidadProduccion()
        Call Cargar_Detalle()
        Cbo3.DataSource = Nothing
        Call CargarUltraCombo(Cbo3, Ls_UnidadProd, "Codigo", "Descripcion")
        Cbo3.Value = ""
        Tab1.Tabs("T02").Selected = True
        Cbo1.Focus()

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
            .Status = "*"
            .Usuario = User_Sistema
            .Tipo = 3
        End With

        If Negocio.PeriodoPlantaCemento.Mantenedor_PeriodoPlantaCemento(Entidad.Periodo, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing) > 0 Then
            Call Inicio()
        End If


    End Sub

    Public Sub Cancelar()
        If Tab1.Tabs("T03").Selected = True Then

            If Tab2.Tabs("T01").Selected = True And Not (TipoGDetMinerales = eState.eView) = True Then
                Call LimpiarMinerales()
                Call HabilitarControlesMinerales(False)
                Grid3.Enabled = True
            ElseIf Tab2.Tabs("T02").Selected = True And Not (TipoGDetSuministros = eState.eView) = True Then
                Call LimpiarMinerales()
                Call HabilitarControlesSuministros(False)
                Grid4.Enabled = True
            ElseIf Tab2.Tabs("T02").Selected = True And Not (TipoGDetManoObra = eState.eView) = True Then
                Call LimpiarManoObra()
                Call HabilitarControlesManoObra(False)
                Grid5.Enabled = True
            ElseIf Not (TipoG = eState.eView) Then
                Call Inicio()
            End If
        Else
            If Not (TipoG = eState.eView) Then
                Call Inicio()
            End If
        End If

    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Inicio()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

#End Region

#Region "Formulario"
    Private Sub frmLCosteoPlantaCemento_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmLCosteoPlantaCemento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub
#End Region

#Region "DateTime"
    Private Sub Dtp1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp1.ValueChanged
        Call LlenarMeses()
    End Sub
#End Region

#Region "Grilla"
    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout, Grid3.InitializeLayout, Grid4.InitializeLayout, Cbo3.InitializeLayout, Grid5.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Anio" OrElse uColumn.Key = "MesName") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

        If sender Is Cbo3 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    If uColumn.Key = "Codigo" Then
                        uColumn.MaxWidth = 80
                        uColumn.MinWidth = 80
                    Else
                        uColumn.MaxWidth = Cbo3.Width - 80
                        uColumn.MinWidth = Cbo3.Width - 80
                    End If
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If


        If sender Is Grid3 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "CodProducto" OrElse uColumn.Key = "Descripcion" _
                        OrElse uColumn.Key = "Cantidad") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

        If sender Is Grid4 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "CodProducto" OrElse uColumn.Key = "Descripcion" _
                        OrElse uColumn.Key = "Cantidad" OrElse uColumn.Key = "Unidad") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

        If sender Is Grid5 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "CodPersonal" OrElse uColumn.Key = "DesPersonal" _
                        OrElse uColumn.Key = "HorasTrab") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If
    End Sub
    Private Sub Grid2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid2.KeyDown
        Try
            Dim f As System.EventArgs = Nothing
            With Grid2
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(AboveCell, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Down
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(BelowCell, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Right
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(NextCellByTab, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Left
                        .PerformAction(ExitEditMode, False, False)
                        .PerformAction(PrevCellByTab, False, False)
                        e.Handled = True
                        .PerformAction(EnterEditMode, False, False)
                    Case Keys.Return
                        .PerformAction(ExitEditMode, False, False)
                        e.Handled = True
                        .PerformAction(NextRow, False, False)
                        .ActiveRow.Cells("Porcentaje").Activate()
                        .PerformAction(EnterEditMode, False, False)
                End Select
            End With
        Catch
            Exit Sub
        End Try
    End Sub
#End Region
   
#Region "Botones"
    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click, Btn5.Click, Btn9.Click, Btn13.Click
        If Not (sender Is Btn1) Then
            If Cbo3.Rows.Count <= 0 Then
                MsgBox("Debe ingresar las Unidades de Producción", MsgBoxStyle.Critical, msgComacsa)
                Return
            End If
            If Cbo3.Value = "" Then
                MsgBox("Debe Seleccionar la Unidad de Producción", MsgBoxStyle.Critical, msgComacsa)
                Return
            End If
        End If
        If sender Is Btn1 Then
            Call LimpiarUnidadProduccion()
            Call HabilitarControlesUnidadProduccion(True)
            TipoGDetUnidadProd = eState.eNew
            Txt2.Focus()
        End If

        If sender Is Btn5 Then
            Call LimpiarMinerales()
            Call HabilitarControlesMinerales(True)
            TipoGDetMinerales = eState.eNew
            Txt4.Focus()
        End If

        If sender Is Btn9 Then
            Call LimpiarSuministros()
            Call HabilitarControlesSuministros(True)
            TipoGDetSuministros = eState.eNew
            Txt7.Focus()
        End If

        If sender Is Btn13 Then
            Call LimpiarManoObra()
            Call HabilitarControlesManoObra(True)
            TipoGDetManoObra = eState.eNew
            Txt15.Focus()
        End If

    End Sub

    Private Sub ModicarDetalleUnidProd(ByVal UniProd As String, ByVal Recurso As String, ByVal Tipo As Integer)
        Select Case Tipo
            Case 1
                For Each xRow As ETProducto In Ls_Mineral
                    If xRow.CodPlanta.Trim = UniProd.Trim And xRow.CodProducto.Trim = Recurso.Trim Then
                        xRow.Cantidad = Txt6.Value
                    End If
                Next
            Case 2
                For Each xRow As ETProducto In Ls_Suministro
                    If xRow.CodPlanta.Trim = UniProd.Trim And xRow.CodProducto.Trim = Recurso.Trim Then
                        xRow.Cantidad = Txt9.Value
                    End If
                Next
            Case 3
                For Each xRow As ETPersonal In Ls_ManoObra
                    If xRow.Cargo.Trim = UniProd.Trim And xRow.CodPersonal.Trim = Recurso.Trim Then
                        xRow.HorasTrab = Grid5.ActiveRow.Cells("HorasTrab").Value
                    End If
                Next
        End Select
    End Sub
    Private Sub Btn_Agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click, Btn6.Click, Btn10.Click, Btn14.Click
        If Not (sender Is Btn2) Then
            If Cbo3.Rows.Count <= 0 Then
                MsgBox("Debe ingresar las Unidades de Producción", MsgBoxStyle.Critical, msgComacsa)
                Return
            End If
            If Cbo3.Value = "" Then
                MsgBox("Debe Seleccionar la Unidad de Producción", MsgBoxStyle.Critical, msgComacsa)
                Return
            End If
        End If
        If sender Is Btn2 Then
            If ValidarUnidadProd() = False Then
                Exit Sub
            End If

            If TipoGDetUnidadProd = eState.eNew Then
                Entidad.Activo = New ETActivo
                With Entidad.Activo
                    .Codigo = Txt2.Text.Trim
                    .Descripcion = Txt3.Text.Trim
                    .Usuario = User_Sistema
                    .Tipo = TipoGDetUnidadProd
                End With

                Ls_UnidadProd.Add(Entidad.Activo)

                Call CargarUltraGrid(Grid2, Ls_UnidadProd)

            Else
                Grid2.ActiveRow.Cells("Codigo").Value = Txt2.Text.Trim
                Grid2.ActiveRow.Cells("Descripcion").Value = Txt3.Value
                Grid2.ActiveRow.Cells("Usuario").Value = User_Sistema
                Grid2.UpdateData()
            End If


            Cbo3.DataSource = Nothing
            Call CargarUltraCombo(Cbo3, Ls_UnidadProd, "Codigo", "Descripcion")
            Cbo3.Value = ""
            Call HabilitarControlesUnidadProduccion(False)
            Call LimpiarUnidadProduccion()
            TipoGDetUnidadProd = eState.eView
            Grid2.Enabled = True
        End If

        If sender Is Btn6 Then
            Txt6.EndUpdate()
            If ValidarMinerales() = False Then
                Exit Sub
            End If

            If TipoGDetMinerales = eState.eNew Then
                Entidad.Producto = New ETProducto
                With Entidad.Producto
                    .CodProducto = Txt4.Text.Trim
                    .Descripcion = Txt5.Text.Trim
                    .CodPlanta = Cbo3.Value
                    .Cantidad = Txt6.Value
                    .Usuario = User_Sistema
                    .Tipo = TipoGDetMinerales
                End With

                Ls_Mineral_Temp.Add(Entidad.Producto)
                Ls_Mineral.Add(Entidad.Producto)

                Call CargarUltraGrid(Grid3, Ls_Mineral_Temp)

            Else
                Call ModicarDetalleUnidProd(Cbo3.Value, Txt4.Text, 1)

                Grid3.ActiveRow.Cells("CodProducto").Value = Txt4.Text.Trim
                Grid3.ActiveRow.Cells("Descripcion").Value = Txt5.Value
                Grid3.ActiveRow.Cells("Cantidad").Value = Txt6.Value
                Grid3.ActiveRow.Cells("Usuario").Value = User_Sistema
                Grid3.UpdateData()
            End If

            Cbo3.ReadOnly = False
            Call HabilitarControlesMinerales(False)
            Call LimpiarMinerales()
            TipoGDetMinerales = eState.eView
            Grid3.Enabled = True
        End If

        If sender Is Btn10 Then
            Txt9.EndUpdate()
            If ValidarSuministros() = False Then
                Exit Sub
            End If

            If TipoGDetSuministros = eState.eNew Then
                Entidad.Producto = New ETProducto
                With Entidad.Producto
                    .CodPlanta = Cbo3.Value
                    .CodProducto = Txt7.Text.Trim
                    .Descripcion = Txt8.Text.Trim
                    .Cantidad = Txt9.Value
                    .Unidad = Txt10.Text
                    .Usuario = User_Sistema
                    .Tipo = TipoGDetSuministros
                End With

                Ls_Suministro_Temp.Add(Entidad.Producto)
                Ls_Suministro.Add(Entidad.Producto)

                Call CargarUltraGrid(Grid4, Ls_Suministro_Temp)

            Else
                Call ModicarDetalleUnidProd(Cbo3.Value, Txt7.Text, 2)

                Grid4.ActiveRow.Cells("CodProducto").Value = Txt7.Text.Trim
                Grid4.ActiveRow.Cells("Descripcion").Value = Txt8.Value
                Grid4.ActiveRow.Cells("Cantidad").Value = Txt9.Value
                Grid4.ActiveRow.Cells("Unidad").Value = Txt10.Value
                Grid4.ActiveRow.Cells("Usuario").Value = User_Sistema
                Grid4.UpdateData()
            End If

            Cbo3.ReadOnly = False
            Call HabilitarControlesSuministros(False)
            Call LimpiarSuministros()
            TipoGDetSuministros = eState.eView
            Grid4.Enabled = True
        End If

        If sender Is Btn14 Then
            Txt15.EndUpdate()
            If ValidarManoObra() = False Then
                Exit Sub
            End If

            If TipoGDetManoObra = eState.eNew Then
                Entidad.Personal = New ETPersonal
                With Entidad.Personal
                    .Cargo = Cbo3.Value
                    .CodPersonal = Txt13.Text.Trim
                    .DesPersonal = Txt14.Text.Trim
                    .HorasTrab = Txt15.Value
                    .Usuario = User_Sistema
                    .Tipo = TipoGDetManoObra
                End With

                Ls_ManoObra_Temp.Add(Entidad.Personal)
                Ls_ManoObra.Add(Entidad.Personal)

                Call CargarUltraGrid(Grid5, Ls_ManoObra_Temp)

            Else
                Call ModicarDetalleUnidProd(Cbo3.Value, Txt13.Text, 3)

                Grid5.ActiveRow.Cells("CodPersonal").Value = Txt13.Text.Trim
                Grid5.ActiveRow.Cells("DesPersonal").Value = Txt14.Value
                Grid5.ActiveRow.Cells("HorasTrab").Value = Txt15.Value
                Grid5.ActiveRow.Cells("Usuario").Value = User_Sistema
                Grid5.UpdateData()
            End If

            Cbo3.ReadOnly = False
            Call HabilitarControlesManoObra(False)
            Call LimpiarManoObra()
            TipoGDetManoObra = eState.eView
            Grid5.Enabled = True
        End If
    End Sub

    Private Sub Btn_Modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click, Btn7.Click, Btn11.Click, Btn15.Click
        If Not (sender Is Btn3) Then
            If Cbo3.Rows.Count <= 0 Then
                MsgBox("Debe ingresar las Unidades de Producción", MsgBoxStyle.Critical, msgComacsa)
                Return
            End If
            If Cbo3.Value = "" Then
                MsgBox("Debe Seleccionar la Unidad de Producción", MsgBoxStyle.Critical, msgComacsa)
                Return
            End If
        End If
        If sender Is Btn3 Then
            If Grid2.Rows.Count <= 0 Then
                MsgBox("No hay Unidades de Producción a Editar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If Grid2.ActiveRow Is Nothing Then
                MsgBox("Seleccione el registro a Editar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If


            TipoGDetUnidadProd = eState.eEdit
            Call LimpiarUnidadProduccion()
            Call HabilitarControlesUnidadProduccion(True)

            Txt2.Text = Grid2.ActiveRow.Cells("Codigo").Value
            Txt3.Text = Grid2.ActiveRow.Cells("Descripcion").Value
            Grid2.Enabled = False
        End If

        If sender Is Btn7 Then
            If Grid3.Rows.Count <= 0 Then
                MsgBox("No hay Minerales a Editar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If Grid3.ActiveRow Is Nothing Then
                MsgBox("Seleccione el registro a Editar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If


            TipoGDetMinerales = eState.eEdit
            Call LimpiarMinerales()
            Call HabilitarControlesMinerales(True)

            Txt4.Text = Grid3.ActiveRow.Cells("CodProducto").Value
            Txt5.Text = Grid3.ActiveRow.Cells("Descripcion").Value
            Txt6.Value = Grid3.ActiveRow.Cells("Cantidad").Value
            Grid3.Enabled = False
        End If

        If sender Is Btn11 Then
            If Grid4.Rows.Count <= 0 Then
                MsgBox("No hay Suministros a Editar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If Grid4.ActiveRow Is Nothing Then
                MsgBox("Seleccione el registro a Editar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If


            TipoGDetSuministros = eState.eEdit
            Call LimpiarSuministros()
            Call HabilitarControlesSuministros(True)

            Txt7.Text = Grid4.ActiveRow.Cells("CodProducto").Value
            Txt8.Text = Grid4.ActiveRow.Cells("Descripcion").Value
            Txt9.Value = Grid4.ActiveRow.Cells("Cantidad").Value
            Txt10.Text = Grid4.ActiveRow.Cells("Unidad").Value
            Grid4.Enabled = False
        End If

        If sender Is Btn15 Then
            If Grid5.Rows.Count <= 0 Then
                MsgBox("No hay Peronal a Editar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If Grid5.ActiveRow Is Nothing Then
                MsgBox("Seleccione el registro a Editar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If


            TipoGDetManoObra = eState.eEdit
            Call LimpiarManoObra()
            Call HabilitarControlesManoObra(True)

            Txt13.Text = Grid4.ActiveRow.Cells("CodPersonal").Value
            Txt14.Text = Grid4.ActiveRow.Cells("DesPersonal").Value
            Txt15.Value = Grid4.ActiveRow.Cells("HorasTrab").Value

            Grid5.Enabled = False
        End If
    End Sub

    Private Sub Btn_Quitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click, Btn8.Click, Btn12.Click, Btn16.Click
        If Not (sender Is Btn4) Then
            If Cbo3.Rows.Count <= 0 Then
                MsgBox("Debe ingresar las Unidades de Producción", MsgBoxStyle.Critical, msgComacsa)
                Return
            End If
            If Cbo3.Value = "" Then
                MsgBox("Debe Seleccionar la Unidad de Producción", MsgBoxStyle.Critical, msgComacsa)
                Return
            End If
        End If
        If sender Is Btn4 Then
            If Grid2.Rows.Count <= 0 Then
                MsgBox("No hay Unidades de Producción a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If Grid2.ActiveRow Is Nothing Then
                MsgBox("Seleccione el registro a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If MsgBox("Está seguro de Quitar la Unidad de Producción: " & Grid2.ActiveRow.Cells("Codigo").Value & " - " & Grid2.ActiveRow.Cells("Descripcion").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            If Val(Grid2.ActiveRow.Cells("Tipo").Value) = 2 Then
                Entidad.Activo = New ETActivo
                With Entidad.Activo
                    .Codigo = Grid2.ActiveRow.Cells("Codigo").Value
                    .Usuario = User_Sistema
                    .Tipo = 3
                End With
                Ls_UnidadProd_Del.Add(Entidad.Activo)
            End If

            Call QuitarTodoDetalleUnidadProduccion(Grid2.ActiveRow.Cells("Codigo").Value)

            Grid2.ActiveRow.Delete(False)
            Grid2.UpdateData()

            Call CargarUltraCombo(Cbo3, Ls_UnidadProd, "Codigo", "Descripcion")
            Cbo3.Value = ""
            Call LimpiarTemp()

        End If

        If sender Is Btn8 Then
            If Grid3.Rows.Count <= 0 Then
                MsgBox("No hay Minerales a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If Grid3.ActiveRow Is Nothing Then
                MsgBox("Seleccione el registro a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If MsgBox("Está seguro de Quitar el Mineral: " & Grid3.ActiveRow.Cells("CodProducto").Value & " - " & Grid3.ActiveRow.Cells("Descripcion").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            If Val(Grid3.ActiveRow.Cells("Tipo").Value) = 2 Then
                Entidad.Producto = New ETProducto
                With Entidad.Producto
                    .CodPlanta = Grid3.ActiveRow.Cells("CodPlanta").Value
                    .CodProducto = Grid3.ActiveRow.Cells("CodProducto").Value
                    .Usuario = User_Sistema
                    .Tipo = 3
                End With
                Ls_Mineral_Del.Add(Entidad.Producto)
            End If

            Call QuitarDetalleUnidadProduccion(Grid3.ActiveRow.Cells("CodPlanta").Value, Grid3.ActiveRow.Cells("CodProducto").Value, 1)

            Grid3.ActiveRow.Delete(False)
            Grid3.UpdateData()

        End If

        If sender Is Btn12 Then
            If Grid4.Rows.Count <= 0 Then
                MsgBox("No hay Suministros a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If Grid4.ActiveRow Is Nothing Then
                MsgBox("Seleccione el registro a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If MsgBox("Está seguro de Quitar el Suministro: " & Grid4.ActiveRow.Cells("CodProducto").Value & " - " & Grid4.ActiveRow.Cells("Descripcion").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            If Val(Grid4.ActiveRow.Cells("Tipo").Value) = 2 Then
                Entidad.Producto = New ETProducto
                With Entidad.Producto
                    .CodPlanta = Grid3.ActiveRow.Cells("CodPlanta").Value
                    .CodProducto = Grid4.ActiveRow.Cells("CodProducto").Value
                    .Usuario = User_Sistema
                    .Tipo = 3
                End With
                Ls_Suministro_Del.Add(Entidad.Producto)
            End If

            Call QuitarDetalleUnidadProduccion(Grid4.ActiveRow.Cells("CodPlanta").Value, Grid4.ActiveRow.Cells("CodProducto").Value, 2)

            Grid4.ActiveRow.Delete(False)
            Grid4.UpdateData()

        End If

        If sender Is Btn16 Then
            If Grid5.Rows.Count <= 0 Then
                MsgBox("No hay Personal a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If Grid5.ActiveRow Is Nothing Then
                MsgBox("Seleccione el registro a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If MsgBox("Está seguro de Quitar al Personal: " & Grid5.ActiveRow.Cells("CodPersonal").Value & " - " & Grid5.ActiveRow.Cells("DesPersonal").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            If Val(Grid5.ActiveRow.Cells("Tipo").Value) = 2 Then
                Entidad.Personal = New ETPersonal
                With Entidad.Personal
                    .Cargo = Grid3.ActiveRow.Cells("Cargo").Value
                    .CodPersonal = Grid5.ActiveRow.Cells("CodPersonal").Value
                    .Usuario = User_Sistema
                    .Tipo = 3
                End With
                Ls_ManoObra_Del.Add(Entidad.Personal)
            End If

            Call QuitarDetalleUnidadProduccion(Grid5.ActiveRow.Cells("Cargo").Value, Grid5.ActiveRow.Cells("CodPersonal").Value, 3)

            Grid5.ActiveRow.Delete(False)
            Grid5.UpdateData()

        End If


    End Sub
#End Region

    Private Sub QuitarTodoDetalleUnidadProduccion(ByVal UniProd As String)
        Dim i As Integer = 0

        While i < Ls_Mineral.Count
            If Ls_Mineral(i).CodPlanta.Trim = UniProd.Trim Then
                Ls_Mineral.RemoveAt(i)
            Else
                i = i + 1
            End If
        End While

        i = 0
        While i < Ls_Suministro.Count
            If Ls_Suministro(i).CodPlanta.Trim = UniProd.Trim Then
                Ls_Suministro.RemoveAt(i)
            Else
                i = i + 1
            End If
        End While
        i = 0
        While i < Ls_ManoObra.Count
            If Ls_ManoObra(i).Cargo.Trim = UniProd.Trim Then
                Ls_ManoObra.RemoveAt(i)
            Else
                i = i + 1
            End If
        End While
    End Sub
  
    Private Sub QuitarDetalleUnidadProduccion(ByVal UniProd As String, ByVal Recurso As String, ByVal Tipo As String)
        Dim i As Integer = 0
        If Tipo = 1 Then
            While i < Ls_Mineral.Count
                If Ls_Mineral(i).CodPlanta.Trim = UniProd.Trim And Ls_Mineral(i).CodProducto.Trim = Recurso.Trim Then
                    Ls_Mineral.RemoveAt(i)
                Else
                    i = i + 1
                End If
            End While
        End If
        
        If Tipo = 2 Then
            While i < Ls_Suministro.Count
                If Ls_Suministro(i).CodPlanta.Trim = UniProd.Trim And Ls_Suministro(i).CodProducto.Trim = Recurso.Trim Then
                    Ls_Suministro.RemoveAt(i)
                Else
                    i = i + 1
                End If
            End While
        End If

        If Tipo = 3 Then
            While i < Ls_ManoObra.Count
                If Ls_ManoObra(i).Cargo.Trim = UniProd.Trim And Ls_ManoObra(i).CodPersonal.Trim = Recurso.Trim Then
                    Ls_ManoObra.RemoveAt(i)
                Else
                    i = i + 1
                End If
            End While
        End If
    End Sub

    Private Sub Cbo3_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo3.ValueChanged

        If TipoG = eState.eNew OrElse TipoG = eState.eEdit Then
            Call LimpiarTemp()
            Call LimpiarMinerales()
            Call LimpiarSuministros()
            Call LimpiarManoObra()
            TipoGDetMinerales = eState.eView
            TipoGDetSuministros = eState.eView
            TipoGDetManoObra = eState.eView
            If Cbo3.Value Is Nothing Then Exit Sub

            If Cbo3.Value.ToString.Trim <> "" Then
                For Each xRow As ETProducto In Ls_Mineral
                    If xRow.CodPlanta.Trim = Cbo3.Value.ToString.Trim Then
                        Ls_Mineral_Temp.Add(xRow)
                    End If
                Next
                Call CargarUltraGrid(Grid3, Ls_Mineral_Temp)

                For Each xRow As ETProducto In Ls_Suministro
                    If xRow.CodPlanta.Trim = Cbo3.Value.ToString.Trim Then
                        Ls_Suministro_Temp.Add(xRow)
                    End If
                Next
                Call CargarUltraGrid(Grid4, Ls_Suministro_Temp)

                For Each xRow As ETPersonal In Ls_ManoObra
                    If xRow.Cargo.Trim = Cbo3.Value.ToString.Trim Then
                        Ls_ManoObra_Temp.Add(xRow)
                    End If

                Next

                Call CargarUltraGrid(Grid5, Ls_ManoObra_Temp)

                Call Cargar_OtrosCostos()
            End If
        End If
    End Sub

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged
        If e.Tab.Key = "T03" Then
            If TipoG = eState.eNew OrElse TipoG = eState.eEdit Then
                If String.IsNullOrEmpty(Cbo1.Value) Then
                    MsgBox("Seleccione el Mes", MsgBoxStyle.Exclamation, msgComacsa)
                End If
            End If
        End If
    End Sub
End Class