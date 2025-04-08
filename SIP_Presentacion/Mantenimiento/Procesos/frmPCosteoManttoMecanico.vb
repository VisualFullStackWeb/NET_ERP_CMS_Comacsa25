Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmPCosteoManttoMecanico
#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Costeo As List(Of ETCosteoManttoMecanico) = Nothing
    Private Ls_Detalle As List(Of ETCosteoManttoMecanicoDetalle) = Nothing
    Private Ls_Anular As List(Of ETCosteoManttoMecanicoDetalle) = Nothing

    Private Enum eState
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum

    Private TipoG As eState
    Private TipoGDet As eState

#End Region

#Region "Formulario"
    Private Sub frmPCosteoManttoMecanico_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmPCosteoManttoMecanico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub
#End Region
    
#Region "Procedimientos Privados"

    Private Sub Inicio()
        TipoG = eState.eView
        TipoGDet = eState.eView
        Call HabilitarControles(False)
        Call InHabilitarControlesDetalle()
        Call Limpiar()
        Call Cargar_Grilla()
        Tab1.Tabs("T01").Selected = True
    End Sub

    Private Sub SumarDatos()
        Dim Horas As Double = 0
        Dim CMO As Decimal = Decimal.Zero
        Dim CMat As Decimal = Decimal.Zero

        If Ls_Detalle.Count > 0 Then
            For Each xRow As ETCosteoManttoMecanicoDetalle In Ls_Detalle
                Horas = Horas + xRow.Horas
                CMO = CMO + xRow.CostoManoObra
                CMat = CMat + xRow.CostoMateriales
            Next
        End If

        Txt1.Value = Horas
        Txt2.Value = CMO
        Txt3.Value = CMat

    End Sub
    Private Sub HabilitarControles(ByVal xBol As Boolean)
        Dtp1.ReadOnly = Not xBol
        Cbo1.ReadOnly = Not xBol
        Txt1.ReadOnly = True
        Txt2.ReadOnly = True
        Txt3.ReadOnly = True
        Txt4.ReadOnly = True
        Cbo2.ReadOnly = True
    End Sub

    Private Sub HabilitarControlesDetalle(ByVal xBol As Boolean)
        If Not (TipoGDet = eState.eEdit) Then
            Btn1.Enabled = xBol
        End If
        Btn2.Enabled = True
        Btn3.Enabled = xBol
        Btn4.Enabled = Not xBol
        Btn5.Enabled = Not xBol
        Txt5.ReadOnly = True
        Txt6.ReadOnly = Not xBol
        Txt7.ReadOnly = Not xBol
        Txt8.ReadOnly = Not xBol
        Txt9.ReadOnly = True
        Txt10.ReadOnly = True
    End Sub

    Private Sub InHabilitarControlesDetalle()
        Btn2.Enabled = False
        Btn3.Enabled = False
        Btn4.Enabled = False
        Btn5.Enabled = False
        Txt5.ReadOnly = True
        Txt6.ReadOnly = True
        Txt7.ReadOnly = True
        Txt8.ReadOnly = True
        Txt9.ReadOnly = True
        Txt10.ReadOnly = True
    End Sub

    Private Sub Limpiar()
        Dtp1.Value = Date.Today
        If Cbo1.Items.Count > 0 Then
            Cbo1.Value = ""
        End If
        Txt1.Value = 0
        Txt2.Value = 0
        Txt3.Value = 0
        Cbo2.Value = "K1"
        Ls_Detalle = Nothing
        Ls_Anular = Nothing
        Ls_Detalle = New List(Of ETCosteoManttoMecanicoDetalle)
        Ls_Anular = New List(Of ETCosteoManttoMecanicoDetalle)
        Call CargarUltraGrid(Grid2, Ls_Detalle)
        Call LimpiarDetalle()

    End Sub

    Private Sub LimpiarDetalle()
        Txt5.Clear()
        Txt10.Clear()
        Txt6.Value = 0
        Txt7.Value = 0
        Txt8.Value = 0
        TipoGDet = eState.eView
    End Sub

    Private Function NameMes(ByVal Mes As Short) As String
        Dim Nombre As String = String.Empty
        Select Case Mes
            Case 1
                Nombre = "ENERO"
            Case 2
                Nombre = "FEBRERO"
            Case 3
                Nombre = "MARZO"
            Case 4
                Nombre = "ABRIL"
            Case 5
                Nombre = "MAYO"
            Case 6
                Nombre = "JUNIO"
            Case 7
                Nombre = "JULIO"
            Case 8
                Nombre = "AGOSTO"
            Case 9
                Nombre = "SETIEMBRE"
            Case 10
                Nombre = "OCTIBRE"
            Case 11
                Nombre = "NOVIEMBRE"
            Case 12
                Nombre = "DICIEMBRE"
        End Select
        Return Nombre
    End Function

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

    Private Sub Cargar_Grilla()
        Ls_Costeo = Nothing
        Ls_Costeo = New List(Of ETCosteoManttoMecanico)

        Entidad.MyLista = Negocio.CosteoManttoMecanico.Consultar_CosteoManttoMecanico
        If Entidad.MyLista IsNot Nothing Then
            If Entidad.MyLista.Validacion Then
                Ls_Costeo = Entidad.MyLista.Ls_CosteoManttoMecanico
            End If
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Costeo)

    End Sub

    Private Sub Cargar_Detalle()

        Ls_Detalle = Nothing
        Ls_Detalle = New List(Of ETCosteoManttoMecanicoDetalle)
        Entidad.CosteoManttoMecanico = New ETCosteoManttoMecanico
        With Entidad.CosteoManttoMecanico
            .Anio = Year(Dtp1.Value)
            .Mes = Cbo1.Value
            .Tipo = 4
        End With

        Entidad.MyLista = Negocio.CosteoManttoMecanico.Consultar_CosteoManttoMecanicoDetalle(Entidad.CosteoManttoMecanico)
        If Entidad.MyLista IsNot Nothing Then
            If Entidad.MyLista.Validacion Then
                Ls_Detalle = Entidad.MyLista.Ls_CosteoManttoMecanicoDetalle
            End If
        End If

        Call CargarUltraGrid(Grid2, Ls_Detalle)
    End Sub
#End Region

#Region "Procedimientos Publicos"
    Public Sub Nuevo()
        TipoG = eState.eNew
        TipoGDet = eState.eView
        Call Limpiar()
        Call HabilitarControles(True)
        Call HabilitarControlesDetalle(False)
        Call LlenarMeses()
        Tab1.Tabs("T02").Selected = True
        Cbo1.Focus()
    End Sub


    Public Sub Grabar()
        If Not (TipoG = eState.eNew OrElse TipoG = eState.eEdit) Then Return

        Txt1.EndUpdate()
        Txt2.EndUpdate()
        Txt3.EndUpdate()
        Txt4.EndUpdate()

        Entidad.CosteoManttoMecanico = New ETCosteoManttoMecanico
        With Entidad.CosteoManttoMecanico
            .Anio = Year(Me.Dtp1.Value)
            If Cbo1.Items.Count > 0 Then
                .Mes = Val(Cbo1.Value)
            End If
            .Horas = Txt1.Value
            .CostoManoObra = Txt2.Value
            .CostoMateriales = Txt3.Value
            .Total = Txt4.Value
            If Cbo2.Value = "K1" Then
                .Status = ""
            Else
                .Status = "*"
            End If
            .Usuario = User_Sistema
            .Tipo = TipoG
        End With

        If Negocio.CosteoManttoMecanico.Mantenedor_CosteoManttoMecanico(Entidad.CosteoManttoMecanico, Ls_Detalle, Ls_Anular) > 0 Then
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
        Me.Dtp1.Value = Mid(Date.Today.ToShortDateString, 1, 6) & Grid1.ActiveRow.Cells("Anio").Value
        Me.Cbo1.Value = Grid1.ActiveRow.Cells("Mes").Value
        Me.Txt1.Value = Grid1.ActiveRow.Cells("Horas").Value
        Me.Txt2.Value = Grid1.ActiveRow.Cells("CostoManoObra").Value
        Me.Txt3.Value = Grid1.ActiveRow.Cells("CostoMateriales").Value
        Me.Txt4.Value = Grid1.ActiveRow.Cells("Total").Value
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

        Entidad.CosteoManttoMecanico = New ETCosteoManttoMecanico
        With Entidad.CosteoManttoMecanico
            .Anio = Grid1.ActiveRow.Cells("Anio").Value
            .Mes = Grid1.ActiveRow.Cells("Mes").Value
            .MesName = Grid1.ActiveRow.Cells("MesName").Value
            .Status = "*"
            .Usuario = User_Sistema
            .Tipo = 3
        End With

        If Negocio.CosteoManttoMecanico.Mantenedor_CosteoManttoMecanico(Entidad.CosteoManttoMecanico, Nothing, Nothing) > 0 Then
            Call Inicio()
        End If
    End Sub


    Public Sub Cancelar()
        If Not (TipoG = eState.eView) Then
            Call Inicio()
        End If
    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Inicio()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

#End Region


    Private Sub Dtp1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp1.ValueChanged
        Call LlenarMeses()
    End Sub


    Private Sub Botones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click, Btn3.Click, Btn4.Click, Btn5.Click
        If sender Is Btn2 Then
            Call LimpiarDetalle()
            Call HabilitarControlesDetalle(True)
            TipoGDet = eState.eNew
            Btn1.Focus()
        End If

        If sender Is Btn3 Then
            If ValidarRegistro() = False Then
                Exit Sub
            End If

            If TipoGDet = eState.eNew Then
                Entidad.CosteoManttoMecanicoDetalle = New ETCosteoManttoMecanicoDetalle
                With Entidad.CosteoManttoMecanicoDetalle
                    .Codigo = Txt10.Text.Trim
                    .Descripcion = Txt5.Text
                    .Horas = Txt6.Value
                    .CostoManoObra = Txt7.Value
                    .CostoMateriales = Txt8.Value
                    .SubTotal = Txt9.Value
                    .Usuario = User_Sistema
                    .Tipo = TipoGDet
                End With

                Ls_Detalle.Add(Entidad.CosteoManttoMecanicoDetalle)

                Call CargarUltraGrid(Grid2, Ls_Detalle)

            Else
                Grid2.ActiveRow.Cells("Horas").Value = Txt6.Value
                Grid2.ActiveRow.Cells("CostoManoObra").Value = Txt7.Value
                Grid2.ActiveRow.Cells("CostoMateriales").Value = Txt8.Value
                Grid2.ActiveRow.Cells("SubTotal").Value = Txt9.Value
                Grid2.ActiveRow.Cells("Usuario").Value = User_Sistema

                Grid2.UpdateData()
            End If

            Call SumarDatos()
            Call HabilitarControlesDetalle(False)
            Call LimpiarDetalle()
            TipoGDet = eState.eView
        End If

        If sender Is Btn4 Then

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
            Txt5.Value = Grid2.ActiveRow.Cells("Codigo").Value
            Txt10.Value = Grid2.ActiveRow.Cells("Descripcion").Value
            Txt6.Value = Grid2.ActiveRow.Cells("Horas").Value
            Txt7.Value = Grid2.ActiveRow.Cells("CostoManoObra").Value
            Txt8.Value = Grid2.ActiveRow.Cells("CostoMateriales").Value
            Txt9.Value = Grid2.ActiveRow.Cells("SubTotal").Value

        End If

        If sender Is Btn5 Then
            If Grid2.Rows.Count <= 0 Then
                MsgBox("No hay Detalle a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If

            If Grid2.ActiveRow Is Nothing Then
                MsgBox("Seleccione el registro a Quitar", MsgBoxStyle.Critical, msgComacsa)
                Exit Sub
            End If


            If Val(Grid2.ActiveRow.Cells("Tipo").Value) = 2 Then
                With Entidad.CosteoManttoMecanicoDetalle
                    .Codigo = Grid2.ActiveRow.Cells("Codigo").Value
                    .Usuario = User_Sistema
                    .Tipo = 3
                End With
                Ls_Anular.Add(Entidad.CosteoManttoMecanicoDetalle)
            End If
            Ls_Detalle.RemoveAt(Grid2.ActiveRow.Index)
            Call SumarDatos()
            Call CargarUltraGrid(Grid2, Ls_Detalle)
        End If
    End Sub
    Private Function ValidarRegistro() As Boolean
        ValidarRegistro = True
        Dim dup As Integer = 0

        If String.IsNullOrEmpty(Txt10.Text.Trim) Then
            MsgBox("Seleccione un Activo", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If

        For Each xRow As UltraGridRow In Grid2.Rows
            If xRow.Cells("Codigo").Value.ToString.Trim = Txt10.Text.Trim Then

                dup = dup + 1
            End If
        Next

        If dup > 0 Then
            MsgBox("El Activo ya fue Ingresado", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If

        If Val(Txt6.Value) < 0 Then
            MsgBox("Error: El Valor de las Horas es Negativo", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If

        If Val(Txt7.Value) < 0 Then
            MsgBox("Error: El Valor de las Horas es Negativo", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If

        If Val(Txt8.Value) < 0 Then
            MsgBox("Error: EL Costo de Mano de Obra es Negativo", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If

        If Val(Txt8.Value) < 0 Then
            MsgBox("Error: El Costo de Materiales es Negativo", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If

        If Val(Txt9.Value) <= 0 Then
            MsgBox("Error: El Costo del Mantenimiento debe ser mayor a cero", MsgBoxStyle.Critical, msgComacsa)
            ValidarRegistro = False
            Exit Function
        End If
    End Function

    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Catalogo_Activos
        frmHijo.ShowDialog()

        Me.Txt10.Text = frmHijo.Flag2.Trim
        Me.Txt5.Text = frmHijo.Descripcion

        Txt6.Focus()
        frmHijo = Nothing
    End Sub

    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Anio" OrElse uColumn.Key = "MesName" _
                        OrElse uColumn.Key = "Horas" OrElse uColumn.Key = "CostoManoObra" _
                        OrElse uColumn.Key = "CostoMateriales" OrElse uColumn.Key = "Total") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

        If sender Is Grid2 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                        OrElse uColumn.Key = "Horas" OrElse uColumn.Key = "CostoManoObra" _
                        OrElse uColumn.Key = "CostoMateriales" OrElse uColumn.Key = "SubTotal" _
                        OrElse uColumn.Key = "Porcentaje") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If
    End Sub

    Private Sub Txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt6.KeyPress, Txt7.KeyPress, Txt8.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If sender Is Txt6 Then
                Txt6.EndUpdate()
                Txt7.Focus()
            End If

            If sender Is Txt7 Then
                Txt7.EndUpdate()
                Txt8.Focus()
            End If

            If sender Is Txt8 Then
                Txt8.EndUpdate()
                If Btn3.Enabled = True Then Btn3.Focus()
            End If

        End If
    End Sub

End Class