Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmMGlosa
#Region "Variables Privadas"
    Private _Sistema As String = String.Empty
    Private _Grupo As String = String.Empty
    Private _Modulo As Integer = 0
    Public Ls_Permisos As New List(Of Integer)

    Private Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private TipoG As State

    Private Ls_Glosa As List(Of ETGlosa) = Nothing
#End Region
#Region "Propidades Privadas"
    Public Property Sistema() As String
        Get
            Return _Sistema
        End Get
        Set(ByVal value As String)
            _Sistema = value
        End Set
    End Property

    Public Property Grupo() As String
        Get
            Return _Grupo
        End Get
        Set(ByVal value As String)
            _Grupo = value
        End Set
    End Property

    Public Property Modulo() As Integer
        Get
            Return _Modulo
        End Get
        Set(ByVal value As Integer)
            _Modulo = value
        End Set
    End Property

#End Region

#Region "Propiedades Privadas"
    Private Sub Limpiar()
        Txt1.Clear()
        Txt2.Clear()
        Cbo1.Value = "A"
    End Sub

    Private Sub HabilitarControles(ByVal xBol As Boolean)
        Txt1.ReadOnly = True
        Txt2.ReadOnly = Not xBol
        Cbo1.ReadOnly = Not xBol
    End Sub

    Private Sub Inicio()
        If Not (String.IsNullOrEmpty(Me.Tag.ToString.Trim)) Then
            Me.Sistema = Mid(Me.Tag, 1, 2)
            Me.Grupo = Mid(Me.Tag, 3, 1)
            Me.Modulo = Val(Mid(Me.Tag, 4, Len(Me.Tag)))
        End If

        Call Limpiar()
        Call HabilitarControles(False)
        Call CargarDatos()
        Tab1.Tabs("T01").Selected = True
        TipoG = State.eView


    End Sub
    Private Sub CargarDatos()
        TipoG = State.eView
        Entidad.Glosa = New ETGlosa
        With Entidad.Glosa
            .Cod_Sistema = Me.Sistema
            .Cod_Grupo = Me.Grupo
            .Cod_Modulo = Me.Modulo
            .Tipo = TipoG
        End With

        Ls_Glosa = New List(Of ETGlosa)
        Entidad.MyLista = New ETMyLista
        Negocio.Glosa = New NGGlosa
        Entidad.MyLista = Negocio.Glosa.ConsultarGlosa(Entidad.Glosa)
        If Entidad.MyLista IsNot Nothing Then
            If Entidad.MyLista.Validacion Then
                Ls_Glosa = Entidad.MyLista.Ls_Glosa
            End If
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Glosa)

    End Sub
#End Region

#Region "Procedimientos Publicos"
    Public Sub Nuevo()
        Call Limpiar()
        Call HabilitarControles(True)
        TipoG = State.eNew
        Tab1.Tabs("T02").Selected = True
       

    End Sub

    Public Sub Grabar()
        If Not (TipoG = State.eNew Or TipoG = State.eEdit) Then
            MsgBox("Presione el Evento Nuevo o Modificar", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        Entidad.Glosa = New ETGlosa
        With Entidad.Glosa
            .ID = Txt1.Text.Trim
            .Cod_Sistema = Me.Sistema
            .Cod_Grupo = Me.Grupo
            .Cod_Modulo = Me.Modulo
            .Glosa = Txt2.Text.Trim
            .Status = IIf(Cbo1.Value = "A", "", Cbo1.Value)
            .Usuario = User_Sistema
            .Tipo = TipoG
        End With

        Negocio.Glosa = New NGGlosa

        If Negocio.Glosa.Mantto_Glosa(Entidad.Glosa) > 0 Then
            Call Inicio()
        End If

    End Sub

    Public Sub Modificar()
        If String.IsNullOrEmpty(Txt1.Text.Trim) Then
            MsgBox("Seleccione un Registro antes de Modificar", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If
        Call HabilitarControles(True)
        TipoG = State.eEdit
    End Sub

    Public Sub Eliminar()
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No Hay Datos a Eliminar", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        If Grid1.ActiveRow Is Nothing Then
            MsgBox("Seleccione la Glosa a Eliminar", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        TipoG = State.eDel

        Entidad.Glosa = New ETGlosa
        With Entidad.Glosa
            .ID = Grid1.ActiveRow.Cells("ID").Value
            .Cod_Sistema = Me.Sistema
            .Cod_Grupo = Me.Grupo
            .Cod_Modulo = Me.Modulo
            .Glosa = Grid1.ActiveRow.Cells("Glosa").Value
            .Status = "*"
            .Usuario = User_Sistema
            .Tipo = TipoG
        End With

        Negocio.Glosa = New NGGlosa

        If Negocio.Glosa.Mantto_Glosa(Entidad.Glosa) > 0 Then
            Call Inicio()
        End If

    End Sub

    Public Sub Actualizar()
        Call Inicio()
    End Sub

    Public Sub Cancelar()
        Call Inicio()
    End Sub

#End Region
#Region "Formulario"

    Private Sub frmMGlosa_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Private Sub frmMGlosa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub
#End Region

    Private Sub Grid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow
        If e Is Nothing Then
            Exit Sub
        End If

        If Grid1.Rows.Count <= 0 Then
            Exit Sub
        End If

        If Grid1.ActiveRow Is Nothing Then
            Exit Sub
        End If

        Txt1.Text = Grid1.ActiveRow.Cells("ID").Value
        Txt2.Text = Grid1.ActiveRow.Cells("Glosa").Value
        If Trim(Grid1.ActiveRow.Cells("Status").Value) = "" Then
            Cbo1.Value = "A"
        Else
            Cbo1.Value = Grid1.ActiveRow.Cells("Status").Value
        End If

        TipoG = State.eView
        Call HabilitarControles(False)
        Tab1.Tabs("T02").Selected = True
    End Sub
    
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "ID" Or uColumn.Key = "Glosa" Or _
                        uColumn.Key = "Estado") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If
    End Sub
End Class