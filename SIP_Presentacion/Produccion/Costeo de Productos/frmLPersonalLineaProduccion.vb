Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmLPersonalLineaProduccion

#Region "Declarar Variables"

    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Periodo As List(Of ETPeriodo) = Nothing
    Private Ls_Detalle As List(Of ETPersonalLineaProduccion) = Nothing
    Private Ls_Anular As List(Of ETPersonalLineaProduccion) = Nothing
    Private Ls_LineaProd As List(Of ETLineaNegocio) = Nothing

    Private Enum eState
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum

    Private TipoG As eState
    Private TipoGDet As eState
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
        Dim i As Integer = -1
        Dim dup As Integer = 0
        Dim Porcentaje As Double = 0

        ValidarRegistro = True

        If String.IsNullOrEmpty(Txt1.Text.Trim) Then
            MsgBox("Seleccione al Personal", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If

        If Cbo3.Rows.Count <= 0 Then
            MsgBox("No existe ninguna Linea de Producción", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        Else
            If Val(Cbo3.Value) <= 0 Then
                MsgBox("Seleccione la Linea de Producción", MsgBoxStyle.Critical, msgComacsa)
                ValidarRegistro = False
                Exit Function
            End If
        End If

        If Val(Txt3.Value) <= 0 Then
            MsgBox("Ingrese el Porcentaje mayor a Cero", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If

        If Val(Txt3.Value) > 100 Then
            MsgBox("Ingrese el Porcentaje menor o igual 100.00", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If

        For Each xRow As UltraGridRow In Grid2.Rows
            i = i + 1
           
            If xRow.Cells("Codigo").Value.ToString.Trim = Txt1.Text.Trim Then
                Porcentaje = Porcentaje + xRow.Cells("Porcentaje").Value
                If TipoGDet = eState.eNew Then
                    If Val(xRow.Cells("LinProd").Value) = Val(Cbo3.Value) Then
                        dup = dup + 1
                    End If
                ElseIf TipoGDet = eState.eEdit Then
                    If Val(xRow.Cells("LinProd").Value) = Val(Cbo3.Value) Then
                        If Val(i) <> Val(Grid2.ActiveRow.Index) Then
                            dup = dup + 1
                        End If
                    End If
                End If
            End If
        Next

        If dup > 0 Then
            MsgBox("Ya se agrego la Linea de Producción: " & Cbo3.ActiveRow.Cells("Codigo").Value & Chr(13) & "Para el Personal: " & Txt1.Text.Trim, MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If

        If TipoGDet = eState.eEdit Then
            Porcentaje = Porcentaje - Val(Grid2.ActiveRow.Cells("Porcentaje").Value)
        End If

        If (Porcentaje + Val(Txt3.Value)) > 100 Then
            MsgBox("Excedió el 100%", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
        End If

    End Function
#End Region

#Region "Procedimientos Privados"

    Private Sub Cargar_Grilla()
        Ls_Periodo = Nothing
        Ls_Periodo = New List(Of ETPeriodo)
        Entidad.Periodo = New ETPeriodo
        Entidad.Periodo.TipoPeriodo = ETPeriodo.sTipoPeriodo.DistribucionPersonal_LinProd
        Entidad.Periodo.Tipo = 4
        Entidad.MyLista = Negocio.Personal_LinProd.Consultar_Periodo(Entidad.Periodo)
        If Entidad.MyLista IsNot Nothing Then
            If Entidad.MyLista.Validacion Then
                Ls_Periodo = Entidad.MyLista.Ls_Periodo
            End If
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Periodo)

    End Sub

    Private Sub Inicio()
        TipoG = eState.eView
        TipoGDet = eState.eView
        Call HabilitarControles(False)
        Call InHabilitarControlesDetalle(True)
        Call Limpiar()
        Call Cargar_Grilla()
        Tab1.Tabs("T01").Selected = True
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
        Dtp1.Value = Date.Today
        If Cbo1.Items.Count > 0 Then
            Cbo1.Value = ""
        End If
        Cbo2.Value = "K1"
        _Periodo = 0
        Call LimpiarDetalle()

        Ls_Anular = Nothing
        Ls_Detalle = Nothing
        Ls_Anular = New List(Of ETPersonalLineaProduccion)
        Ls_Detalle = New List(Of ETPersonalLineaProduccion)
        Call CargarUltraGrid(Grid2, Ls_Detalle)
    End Sub

    Private Sub LimpiarClone()
        Dtp1.Value = Date.Today
        If Cbo1.Items.Count > 0 Then
            Cbo1.Value = ""
        End If
        Cbo2.Value = "K1"
        _Periodo = 0
        Call LimpiarDetalle()

        Ls_Anular = Nothing
        Ls_Anular = New List(Of ETPersonalLineaProduccion)
        For Each xRow As ETPersonalLineaProduccion In Ls_Detalle
            xRow.Tipo = 1
        Next
        Call CargarUltraGrid(Grid2, Ls_Detalle)
    End Sub

    Private Sub LimpiarDetalle()
        Txt1.Clear()
        Txt2.Clear()
        Txt3.Value = 0
        If Cbo3.Rows.Count > 0 Then
            Cbo3.Value = 0
        End If

    End Sub

    Private Sub HabilitarControles(ByVal xBol As Boolean)
        Dtp1.ReadOnly = Not xBol
        Cbo1.ReadOnly = Not xBol
        Cbo2.ReadOnly = True
    End Sub

    Private Sub HabilitarControlesDetalle(ByVal xBol As Boolean)
        Txt1.ReadOnly = True
        Txt2.ReadOnly = True
        Cbo3.ReadOnly = Not xBol
        Txt3.ReadOnly = Not xBol
        Btn1.Enabled = True
        Btn2.Enabled = xBol
        Btn3.Enabled = Not xBol
        Btn4.Enabled = Not xBol
        Grid2.Enabled = xBol
    End Sub

    Private Sub InHabilitarControlesDetalle(ByVal xBol As Boolean)
        Txt1.ReadOnly = xBol
        Txt2.ReadOnly = xBol
        Txt3.ReadOnly = xBol
        Btn1.Enabled = Not xBol
        Btn2.Enabled = Not xBol
        Btn3.Enabled = Not xBol
        Btn4.Enabled = Not xBol
    End Sub

    Private Sub CargarLineaProduccion()
        Ls_LineaProd = Nothing
        Ls_LineaProd = New List(Of ETLineaNegocio)
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.LineaProduccion.ConsultarLineaProduccion
        If Entidad.MyLista IsNot Nothing Then
            Ls_LineaProd = Entidad.MyLista.Ls_Linea_Produccion
        End If
        Call CargarUltraCombo(Cbo3, Ls_LineaProd, "IDCatalogo", "Descripcion")
    End Sub

    Private Sub Cargar_Detalle()

        Ls_Detalle = Nothing
        Ls_Detalle = New List(Of ETPersonalLineaProduccion)
        Entidad.Periodo = New ETPeriodo
        With Entidad.Periodo
            .Periodo = Me.Periodo
            .TipoPeriodo = ETPeriodo.sTipoPeriodo.DistribucionPersonal_LinProd
            .Tipo = 4
        End With

        Entidad.MyLista = Negocio.Personal_LinProd.Consultar_PersonalLinProd(Entidad.Periodo)
        If Entidad.MyLista IsNot Nothing Then
            If Entidad.MyLista.Validacion Then
                Ls_Detalle = Entidad.MyLista.Ls_Personal_LinProd
            End If
        End If

        Call CargarUltraGrid(Grid2, Ls_Detalle)
    End Sub

    Private Sub NuevoPeriodo()
        TipoG = eState.eNew
        TipoGDet = eState.eView
        Call Limpiar()
        Call HabilitarControles(True)
        Call HabilitarControlesDetalle(False)
        Tab1.Tabs("T02").Selected = True
        Dtp1.Focus()
    End Sub

    Private Sub NuevoPeriodoClone()
        TipoG = eState.eNew
        TipoGDet = eState.eView
        Call LimpiarClone()
        Call HabilitarControles(True)
        Call HabilitarControlesDetalle(False)
        Grid2.Enabled = True
        Tab1.Tabs("T02").Selected = True
        Dtp1.Focus()
    End Sub
#End Region


#Region "Procedimientos Publicos"

    Public Sub Buscar()
        If Not (TipoGDet = eState.eNew OrElse TipoGDet = eState.eEdit) Then
            MsgBox("Debe Presionar antes el evento Nuevo o Modificar del detalle", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Personal
        frmHijo.ShowDialog()
        Txt1.Text = frmHijo.Flag2.Trim
        Txt2.Text = frmHijo.Descripcion.Trim
        Txt3.Focus()
        frmHijo = Nothing

    End Sub

    Public Sub Nuevo()
        If TipoG = eState.eEdit Then
            If MsgBox("Desea Tener como Plantilla al Periodo: " & NameMes(Me.Cbo1.Value) & Space(1) & Year(Me.Dtp1.Value), MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Call NuevoPeriodo()
            Else
                Call NuevoPeriodoClone()
            End If
        Else
            Call NuevoPeriodo()
        End If

    End Sub

    Public Sub Grabar()
        If Not (TipoG = eState.eNew OrElse TipoG = eState.eEdit) Then
            MsgBox("Debe Presionar antes el evento Nuevo o Modificar", MsgBoxStyle.Exclamation, msgComacsa)
        End If


        Entidad.Periodo = New ETPeriodo

        With Entidad.Periodo
            .Periodo = Me.Periodo
            .Anio = Year(Dtp1.Value)
            If Cbo1.Items.Count > 0 Then
                .Mes = Cbo1.Value
            End If
            .TipoPeriodo = ETPeriodo.sTipoPeriodo.DistribucionPersonal_LinProd
            .Status = IIf(Cbo2.Value = "K1", "", "*")
            .Usuario = User_Sistema
            .Tipo = TipoG
        End With

        If Negocio.Personal_LinProd.Mantenedor_Personal_LinProd(Entidad.Periodo, Ls_Detalle, Ls_Anular) > 0 Then
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
        Grid2.Enabled = True
        Periodo = Grid1.ActiveRow.Cells("Periodo").Value
        Me.Dtp1.Value = Mid(Date.Today.ToShortDateString, 1, 6) & Grid1.ActiveRow.Cells("Anio").Value
        Me.Cbo1.Value = Grid1.ActiveRow.Cells("Mes").Value
        If Grid1.ActiveRow.Cells("Status").Value = "*" Then
            Cbo2.Value = "K2"
        Else
            Cbo2.Value = "K1"
        End If

        Call Cargar_Detalle()
        Tab1.Tabs("T02").Selected = True
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

        If Negocio.Personal_LinProd.Mantenedor_Personal_LinProd(Entidad.Periodo, Nothing, Nothing) > 0 Then
            Call Inicio()
        End If
    End Sub

    Public Sub Cancelar()
        If Tab1.Tabs("T03").Selected = True And Not (TipoGDet = eState.eView) = True Then
            Call LimpiarDetalle()
            Call HabilitarControlesDetalle(False)
            Grid2.Enabled = True
            TipoGDet = eState.eView

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
    Private Sub frmLPersonalLineaProduccion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmLPersonalLineaProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargarLineaProduccion()
        Call Inicio()
    End Sub
#End Region
    

#Region "DateTime"
    Private Sub Dtp1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp1.ValueChanged
        Call LlenarMeses()
    End Sub

#End Region

#Region "Grilla"
    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout, Cbo3.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Anio" OrElse uColumn.Key = "MesName" _
                        OrElse uColumn.Key = "NroReg") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                        OrElse uColumn.Key = "CodLinProd" OrElse uColumn.Key = "LineaProduccion" _
                        OrElse uColumn.Key = "Porcentaje") Then
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
                        uColumn.MinWidth = 60
                        uColumn.MaxWidth = 60
                    Else
                        uColumn.MinWidth = Cbo3.Width - 60
                        uColumn.MaxWidth = Cbo3.Width - 60
                    End If
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If
    End Sub

#End Region
   
#Region "Botones"
    Private Sub Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click, Btn2.Click, Btn3.Click, Btn4.Click
        If sender Is Btn1 Then
            Call LimpiarDetalle()
            Call HabilitarControlesDetalle(True)
            TipoGDet = eState.eNew
            Txt1.Focus()
        End If

        If sender Is Btn2 Then
            If ValidarRegistro() = False Then
                Exit Sub
            End If

            If TipoGDet = eState.eNew Then
                Entidad.PersonalProduccion = New ETPersonalLineaProduccion
                With Entidad.PersonalProduccion
                    .Codigo = Txt1.Text.Trim
                    .Descripcion = Txt2.Text.Trim
                    .CodLinProd = Cbo3.ActiveRow.Cells("Codigo").Value
                    .LineaProduccion = Cbo3.Text.Trim
                    .LinProd = Cbo3.Value
                    .Porcentaje = Txt3.Value
                    .Usuario = User_Sistema
                    .Tipo = TipoGDet
                    If OptLab.Checked Then
                        .Asigna = "L"
                    ElseIf OptAcarreo.Checked Then
                        .Asigna = "A"
                    Else
                        .Asigna = "P"
                    End If
                End With

                Ls_Detalle.Add(Entidad.PersonalProduccion)

                Call CargarUltraGrid(Grid2, Ls_Detalle)

            Else
                Grid2.ActiveRow.Cells("Codigo").Value = Txt1.Text.Trim
                Grid2.ActiveRow.Cells("Descripcion").Value = Txt2.Text.Trim
                Grid2.ActiveRow.Cells("CodLinProd").Value = Cbo3.ActiveRow.Cells("Codigo").Value
                Grid2.ActiveRow.Cells("LineaProduccion").Value = Cbo3.Text.Trim
                Grid2.ActiveRow.Cells("LinProd").Value = Cbo3.Value
                Grid2.ActiveRow.Cells("Porcentaje").Value = Txt3.Value
                Grid2.ActiveRow.Cells("Usuario").Value = User_Sistema
                If OptLab.Checked Then
                    Grid2.ActiveRow.Cells("Asigna").Value = "L"
                ElseIf OptAcarreo.Checked Then
                    Grid2.ActiveRow.Cells("Asigna").Value = "A"
                Else
                    Grid2.ActiveRow.Cells("Asigna").Value = "P"
                End If
                Grid2.UpdateData()
            End If

            Call HabilitarControlesDetalle(False)
            Call LimpiarDetalle()
            TipoGDet = eState.eView
            Grid2.Enabled = True
        End If

        If sender Is Btn3 Then
            If Grid2.Rows.Count <= 0 Then
                MsgBox("No hay Detalle a Editar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If Grid2.ActiveRow Is Nothing Then
                MsgBox("Seleccione el registro a Editar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If


            TipoGDet = eState.eEdit
            Call LimpiarDetalle()
            Call HabilitarControlesDetalle(True)

            Txt1.Text = Grid2.ActiveRow.Cells("Codigo").Value
            Txt2.Text = Grid2.ActiveRow.Cells("Descripcion").Value
            Txt3.Value = Grid2.ActiveRow.Cells("Porcentaje").Value
            Cbo3.Value = Grid2.ActiveRow.Cells("LinProd").Value

            If Trim(Grid2.ActiveRow.Cells("Asigna").Value & "") = "L" Then
                OptLab.Checked = True
            ElseIf Trim(Grid2.ActiveRow.Cells("Asigna").Value & "") = "A" Then
                OptAcarreo.Checked = True
            Else
                OptPlanta.Checked = True
            End If
            Grid2.Enabled = False
        End If

        If sender Is Btn4 Then
            If Grid2.Rows.Count <= 0 Then
                MsgBox("No hay Detalle a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If Grid2.ActiveRow Is Nothing Then
                MsgBox("Seleccione el registro a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If MsgBox("Está seguro de Quitar al Personal: " & Grid2.ActiveRow.Cells("Codigo").Value & Chr(13) & "De la Linea de Producción: " & Grid2.ActiveRow.Cells("CodLinProd").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            If Val(Grid2.ActiveRow.Cells("Tipo").Value) = 2 Then
                Entidad.PersonalProduccion = New ETPersonalLineaProduccion
                With Entidad.PersonalProduccion
                    .Codigo = Grid2.ActiveRow.Cells("Codigo").Value
                    .LinProd = Grid2.ActiveRow.Cells("LinProd").Value
                    .Usuario = User_Sistema
                    .Tipo = 3
                End With
                Ls_Anular.Add(Entidad.PersonalProduccion)
            End If

            Entidad.PersonalProduccion = New ETPersonalLineaProduccion
            With Entidad.PersonalProduccion
                .Codigo = Grid2.ActiveRow.Cells("Codigo").Value
                .Descripcion = Grid2.ActiveRow.Cells("Descripcion").Value
                .CodLinProd = Grid2.ActiveRow.Cells("CodLinProd").Value
                .LineaProduccion = Grid2.ActiveRow.Cells("LineaProduccion").Value
                .Porcentaje = Grid2.ActiveRow.Cells("Porcentaje").Value
                .LinProd = Grid2.ActiveRow.Cells("LinProd").Value
                .Tipo = Grid2.ActiveRow.Cells("Tipo").Value
                .Usuario = Grid2.ActiveRow.Cells("Usuario").Value
                .Periodo = Grid2.ActiveRow.Cells("Periodo").Value
                .Asigna = Grid2.ActiveRow.Cells("Asigna").Value
            End With

            Grid2.ActiveRow.Delete(False)
            Grid2.UpdateData()
            'Ls_Detalle.Remove(Entidad.PersonalProduccion)
            'Call CargarUltraGrid(Grid2, Ls_Detalle)
        End If
    End Sub
#End Region

#Region "Combo"
    Private Sub Cbo3_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo3.ValueChanged
        If TipoGDet = eState.eNew OrElse TipoGDet = eState.eEdit Then
            Txt3.Focus()
        End If
    End Sub
#End Region

#Region "Txt"
    Private Sub Txt3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Btn2.Enabled = True Then Btn2.Focus()
        End If
    End Sub
#End Region


End Class