Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmLSiliceHomogenizada
#Region "Declarar Variables"

    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Periodo As List(Of ETPeriodo) = Nothing

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
        Dim i As Integer = -1
        Dim dup As Integer = 0
        Dim Porcentaje As Double = 0

        ValidarRegistro = True
        Ep1.Clear()

        If String.IsNullOrEmpty(Cbo1.Value) Then
            Ep1.SetError(Cbo1, "Seleccione el Mes")
            ValidarRegistro = False
        End If
        If Val(Txt1.Value) Then
            Ep1.SetError(Txt1, "Ingrese el Costo x TON de la Mano de Obra del Cargador Frontal")
            ValidarRegistro = False
        End If

        If Val(Txt2.Value) Then
            Ep1.SetError(Txt2, "Ingrese el Costo x TON de la Mano de Obra de la Chancadora")
            ValidarRegistro = False
        End If

        If Val(Txt3.Value) Then
            Ep1.SetError(Txt3, "Ingrese el Costo x TON del Combustible")
            ValidarRegistro = False
        End If

        If Val(Txt4.Value) <= 0 Then
            Ep1.SetError(Txt4, "Ingrese el Costo x TON de la Energía Electrica")
            ValidarRegistro = False
        End If

        If Val(Txt5.Value) Then
            Ep1.SetError(Txt5, "Ingrese el Costo x TON del Aquiler de Volquetes")
            ValidarRegistro = False
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
        Dtp1.Value = Now
        Cbo1.Value = String.Empty
        Txt1.Value = 0
        Txt2.Value = 0
        Txt3.Value = 0
        Txt4.Value = 0
        Txt5.Value = 0
        Cbo2.Value = "K1"
        Ep1.Clear()
        _Periodo = 0
    End Sub

    Private Sub HabilitarControles(ByVal xBol As Boolean)
        Dtp1.ReadOnly = Not xBol
        Cbo1.ReadOnly = Not xBol
        Txt1.ReadOnly = Not xBol
        Txt2.ReadOnly = Not xBol
        Txt3.ReadOnly = Not xBol
        Txt4.ReadOnly = Not xBol
        Txt5.ReadOnly = Not xBol
        Cbo2.ReadOnly = True

    End Sub

    Private Sub Inicio()
        Call Limpiar()
        Call HabilitarControles(False)
        Call CargarSiliceHomogenizada()
        Tab1.Tabs("T01").Selected = True
        TipoG = eState.eView
    End Sub

    Private Sub CargarSiliceHomogenizada()
        Ls_Periodo = New List(Of ETPeriodo)
        Entidad.Periodo = New ETPeriodo
        Entidad.Periodo.TipoPeriodo = ETPeriodo.sTipoPeriodo.CosteoSiliceHomogenizada
        Entidad.Periodo.Tipo = 6
        Negocio.PeriodoSiliceHomogenizada = New NGSiliceHomogenizada
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.PeriodoSiliceHomogenizada.ConsultarSiliceHomogenizada(Entidad.Periodo)
        If Entidad.MyLista IsNot Nothing Then
            Ls_Periodo = Entidad.MyLista.Ls_Periodo
        End If
        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Periodo)
    End Sub
#End Region

#Region "Procedimientos Publicos"
    Public Sub Actualizar()
        Call Inicio()
    End Sub

    Public Sub Cancelar()
        Call Inicio()
    End Sub

    Public Sub Nuevo()
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
            .TipoPeriodo = ETPeriodo.sTipoPeriodo.CosteoSiliceHomogenizada
            .Valor2 = Txt1.Value
            .Valor3 = Txt2.Value
            .Valor4 = Txt3.Value
            .Valor5 = Txt4.Value
            .Valor6 = Txt5.Value
            .ValorPeriodo = Txt1.Value + Txt2.Value + Txt3.Value + Txt4.Value + Txt5.Value
            .Status = IIf(Cbo2.Value = "K1", "", "*")
            .Usuario = User_Sistema
            .Tipo = TipoG
        End With

        If Negocio.PeriodoSiliceHomogenizada.MantenedorSiliceHomogenizada(Entidad.Periodo) = True Then
            Call Inicio()
        End If
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

        If Negocio.PeriodoSiliceHomogenizada.MantenedorSiliceHomogenizada(Entidad.Periodo) = True Then
            Call Inicio()
        End If
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
        Me.Dtp1.Value = Mid(Date.Today.ToShortDateString, 1, 6) & Grid1.ActiveRow.Cells("Anio").Value
        Me.Cbo1.Value = Grid1.ActiveRow.Cells("Mes").Value
        Me.Txt1.Value = Grid1.ActiveRow.Cells("Valor2").Value
        Me.Txt2.Value = Grid1.ActiveRow.Cells("Valor3").Value
        Me.Txt3.Value = Grid1.ActiveRow.Cells("Valor4").Value
        Me.Txt4.Value = Grid1.ActiveRow.Cells("Valor5").Value
        Me.Txt5.Value = Grid1.ActiveRow.Cells("Valor6").Value

        If Grid1.ActiveRow.Cells("Status").Value = "*" Then
            Cbo2.Value = "K2"
        Else
            Cbo2.Value = "K1"
        End If
        Tab1.Tabs("T02").Selected = True
    End Sub

#End Region

#Region "Formulario"
    Private Sub frmLSiliceHomogenizada_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Call Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmLSiliceHomogenizada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub
#End Region
#Region "Grilla"
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Exit Sub
        End If

        For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (xCol.Key = "Anio" OrElse xCol.Key = "MesName" OrElse xCol.Key = "ValorPeriodo") Then
                xCol.Hidden = True
            Else
                xCol.Hidden = False
            End If
        Next
    End Sub
#End Region
    
#Region "Controles"
    Private Sub Cbo1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo1.ValueChanged
        Txt1.Focus()
    End Sub

    Private Sub Txt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt2.Focus()
        End If
    End Sub

    Private Sub Txt2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt3.Focus()
        End If
    End Sub

    Private Sub Txt3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt4.Focus()
        End If
    End Sub

    Private Sub Txt4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt4.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt5.Focus()
        End If
    End Sub

    Private Sub Dtp1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp1.ValueChanged
        Call LlenarMeses()
    End Sub
#End Region
 
End Class