Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmPCheckList
#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)

    Private _Equipo As Long = 0
    Private _Personal As String = String.Empty
    Private _AtribID As Long = 0
    Private _Atributo As String = String.Empty
    Private _Und As String = String.Empty
    Private _TipoDato As Integer = 0
    Private _Longitud As Integer = 0
    Private _Decimales As Integer = 0
    Private _CheckList As Long = 0
    Private _Status As String = String.Empty
    Private _Resultado As Integer = 0

    Private Ls_Detalle As List(Of ETCheckListDetalle) = Nothing

    Private Enum eState
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum

    Private TipoG As eState

#End Region
#Region "Propiedades Privadas"
    Private Property Equipo() As Long
        Get
            Return _Equipo
        End Get
        Set(ByVal value As Long)
            _Equipo = value
        End Set
    End Property
    Private Property Personal() As String
        Get
            Return _Personal
        End Get
        Set(ByVal value As String)
            _Personal = value
        End Set
    End Property
    Private Property AtribID() As Long
        Get
            Return _AtribID
        End Get
        Set(ByVal value As Long)
            _AtribID = value
        End Set
    End Property
    Private Property Atributo() As String
        Get
            Return _Atributo
        End Get
        Set(ByVal value As String)
            _Atributo = value
        End Set
    End Property
    Private Property Und() As String
        Get
            Return _Und
        End Get
        Set(ByVal value As String)
            _Und = value
        End Set
    End Property
    Private Property TipoDato() As Integer
        Get
            Return _TipoDato
        End Get
        Set(ByVal value As Integer)
            _TipoDato = value
        End Set
    End Property
    Private Property Longitud() As Integer
        Get
            Return _Longitud
        End Get
        Set(ByVal value As Integer)
            _Longitud = value
        End Set
    End Property
    Private Property Decimales() As Integer
        Get
            Return _Decimales
        End Get
        Set(ByVal value As Integer)
            _Decimales = value
        End Set
    End Property
    Private Property CheckList() As Long
        Get
            Return _CheckList
        End Get
        Set(ByVal value As Long)
            _CheckList = value
        End Set
    End Property
    Private Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Private Property Resultado() As Integer
        Get
            Return _Resultado
        End Get
        Set(ByVal value As Integer)
            _Resultado = value
        End Set
    End Property
#End Region
#Region "Formulario"

    Private Sub frmPCheckList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub frmPCheckList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargarUnidadMedida()
        TipoG = eState.eView
        Call CargarDatos()
        Call InicializarValores()
    End Sub
#End Region
#Region "Procedimientos Privados"
    Private Sub Iniciar()
        Me.Tab1.Tabs("T01").Selected = Boolean.TrueString
        TipoG = eState.eView
        Call CargarDatos()
        Call HabilitarControles(False)
        Call Limpiar()
    End Sub
    Private Sub HabilitarControles(ByVal d As Boolean)
        Txt4.ReadOnly = Not d
        Cbo1.ReadOnly = Not d
        Cbo4.ReadOnly = Not d
        Cbo5.ReadOnly = Not d
        Btn1.Enabled = d
        Btn2.Enabled = d
    End Sub
    Private Sub Limpiar()
        Call InicializarValores()
        Me.Txt1.Clear()
        Me.Txt2.Clear()
        Me.Txt3.Clear()
        Me.Txt4.Clear()
        Me.Cbo1.Value = Boolean.TrueString
        Me.Cbo2.Value = ""
        Me.Cbo3.Value = "K1"
        Me.Dtp1.Value = Now.Date
        Dim LsDetalle As List(Of ETCheckListDetalle) = Nothing
        LsDetalle = New List(Of ETCheckListDetalle)
        Call CargarUltraGrid(Me.Grid2, LsDetalle)
    End Sub
    Private Sub InicializarValores()
        _Equipo = 0
        _Personal = String.Empty
        _AtribID = 0
        _Atributo = String.Empty
        _Und = String.Empty
        _TipoDato = 0
        _Longitud = 0
        _Decimales = 0
        _CheckList = 0
        _Status = String.Empty
        Ls_Detalle = Nothing
        Ls_Detalle = New List(Of ETCheckListDetalle)
    End Sub
    Private Sub CargarUnidadMedida()
        Dim Ls_Combo1 As List(Of ETUnidadMedida)
        Negocio.UnidadMedida = New NGUnidadMedida
        Entidad.MyLista = New ETMyLista

        Ls_Combo1 = New List(Of ETUnidadMedida)

        Entidad.MyLista = Negocio.UnidadMedida.ConsultarUnidadMedida

        If Entidad.MyLista.Validacion Then
            Ls_Combo1 = Entidad.MyLista.Ls_UnidadMedida
        End If

        Call CargarUltraCombo(Me.Cbo2, Ls_Combo1, "Codigo", "Descripcion", String.Empty)

    End Sub
    Private Sub CargarComponentesEq()
        Ls_Detalle = Nothing
        Ls_Detalle = New List(Of ETCheckListDetalle)
        Dim ObjCL As New ETCheckList
        ObjCL.CheckList = Me.CheckList
        ObjCL.EquipoID = Me.Equipo
        ObjCL.TipoChL = Me.Cbo1.Value
        Select Case TipoG
            Case eState.eNew
                ObjCL.Tipo = 6
            Case eState.eEdit
                If Me.Status = "K1" Then
                    ObjCL.Tipo = 5
                Else
                    ObjCL.Tipo = 4
                End If
        End Select
        Negocio.CheckList = New NGCheckList
        Entidad.MyLista = New ETMyLista

        Ls_Detalle = New List(Of ETCheckListDetalle)

        Entidad.MyLista = Negocio.CheckList.ConsultarDetalleCheckList(ObjCL)

        If Entidad.MyLista.Validacion Then
            Ls_Detalle = Entidad.MyLista.Ls_CheckListDet
        End If

        Call CargarUltraGrid(Me.Grid2, Ls_Detalle)

    End Sub
    Private Sub CargarDatos()
        Dim Ls_CheckList As List(Of ETCheckList)
        Negocio.CheckList = New NGCheckList
        Entidad.MyLista = New ETMyLista

        Ls_CheckList = New List(Of ETCheckList)

        Entidad.MyLista = Negocio.CheckList.ConsultarCheckList

        If Entidad.MyLista.Validacion Then
            Ls_CheckList = Entidad.MyLista.Ls_CheckList
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_CheckList)

    End Sub
#End Region
#Region "Procedimientos Publicos"
    Public Sub Nuevo()
        Call Limpiar()
        Call HabilitarControles(Boolean.TrueString)
        Me.Tab1.Tabs("T02").Selected = Boolean.TrueString
        Me.Txt2.Focus()
        TipoG = eState.eNew
    End Sub
    Public Sub Grabar()
        Dim objCL As New ETCheckList

        objCL.CheckList = Me.CheckList
        objCL.Fecha = CDate(Me.Dtp1.Value)
        objCL.Codigo = Txt1.Text.Trim
        objCL.Tipo = TipoG
        objCL.ResponsableID = Me.Personal
        objCL.TipoChL = Me.Cbo1.Value
        objCL.EquipoID = Me.Equipo

        objCL.AtributoControl = Me.AtribID
        If Me.AtribID > 0 Then
            objCL.AtribOb = Boolean.TrueString
        End If
        objCL.Valor = Me.Txt4.Text.Trim
        objCL.Usuario = User_Sistema

        If TipoG = eState.eEdit Then
            If Cbo3.Value = "K1" Then
                If gAreaMantto = True OrElse UCase(User_Sistema.Trim) = "SA" Then
                    If MsgBox("Desea Cambiar el estado de PENDIENTE a REVISADO", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                        Cbo3.Value = "K2"
                    End If
                End If
            End If
        End If

        Select Case Cbo3.Value
            Case "K1"
                objCL.Status = "P"
            Case "K2"
                objCL.Status = "R"
            Case "K3"
                objCL.Status = ""
            Case "K4"
                objCL.Status = "*"
        End Select

        Negocio.CheckList = New NGCheckList

        Try
            Me.Resultado = Negocio.CheckList.Mantto_CheckList(objCL, Ls_Detalle)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Call Iniciar()
    End Sub
    Public Sub Modificar()
        If Me.Grid1.Rows.Count <= 0 Then Exit Sub
        If Me.Grid1.ActiveRow Is Nothing Then Exit Sub
        Call Limpiar()
        TipoG = 2
        Me.CheckList = Grid1.ActiveRow.Cells("CheckList").Value
        Me.Txt1.Text = Grid1.ActiveRow.Cells("Codigo").Value
        Me.Dtp1.Value = Grid1.ActiveRow.Cells("Fecha").Value
        Me.Cbo1.Value = Grid1.ActiveRow.Cells("TipoChL").Value
        Me.Txt2.Text = Grid1.ActiveRow.Cells("Responsable").Value
        Me.Txt3.Text = Grid1.ActiveRow.Cells("Equipo").Value
        If Grid1.ActiveRow.Cells("Control").Value.ToString.Trim <> "" Then
            Me.UltraLabel5.Text = Grid1.ActiveRow.Cells("Control").Value
        End If

        Me.Txt4.Text = Grid1.ActiveRow.Cells("Valor").Value
        Me.Cbo2.Value = Grid1.ActiveRow.Cells("UniMed").Value
        Me.Cbo3.Value = Grid1.ActiveRow.Cells("Status").Value
        Me.Personal = Grid1.ActiveRow.Cells("ResponsableID").Value
        Me.Equipo = Grid1.ActiveRow.Cells("EquipoID").Value
        Me.Und = Grid1.ActiveRow.Cells("UniMed").Value
        Me.AtribID = Grid1.ActiveRow.Cells("AtributoControl").Value
        Me.TipoDato = Grid1.ActiveRow.Cells("TipoDato").Value
        Me.Longitud = Grid1.ActiveRow.Cells("Longitud").Value
        Me.Decimales = Grid1.ActiveRow.Cells("Decimales").Value

        Select Case Cbo3.Value
            Case "K1"
                Call HabilitarControles(True)
            Case Else
                Call HabilitarControles(False)
        End Select

        Call CargarComponentesEq()
        Me.Tab1.Tabs("T02").Selected = Boolean.TrueString
    End Sub
    Public Sub Eliminar()
        Dim objCL As New ETCheckList
        If Grid1.Rows.Count <= 0 Then Exit Sub
        If Grid1.ActiveRow Is Nothing Then Exit Sub
        If Not (Grid1.ActiveRow.Cells("Status").Value.ToString.Trim = "P" _
        OrElse Grid1.ActiveRow.Cells("Status").Value.ToString.Trim = "R") Then
            MsgBox("Solo puede anular los CheckList que estan Pendientes o Revisados", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        Me.CheckList = Me.Grid1.ActiveRow.Cells("CheckList").Value
        objCL.CheckList = Me.CheckList
        objCL.Usuario = User_Sistema
        objCL.Status = "*"
        objCL.Tipo = 3
        Negocio.CheckList = New NGCheckList

        Try
            Me.Resultado = Negocio.CheckList.Mantto_CheckList(objCL, Ls_Detalle)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Call Iniciar()
    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Iniciar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

#End Region
#Region "Botones"
    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Equipo
        frmHijo.ShowDialog()
        Me.Equipo = frmHijo.ID
        Me.Txt3.Text = frmHijo.Descripcion
        Me.AtribID = frmHijo.Flag1
        Me.Atributo = frmHijo.Flag2
        Me.Und = frmHijo.Flag3
        Me.UltraLabel5.Text = Me.Atributo
        Me.Cbo2.Value = Und
        Me.TipoDato = Val(frmHijo.Flag4)
        Me.Longitud = Val(frmHijo.Flag5)
        Me.Decimales = Val(frmHijo.Flag6)
        Call CargarComponentesEq()
        frmHijo = Nothing
    End Sub
    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Personal
        frmHijo.ShowDialog()
        Me.Txt2.Text = frmHijo.Flag2 & " - " & frmHijo.Descripcion
        Me.Personal = frmHijo.Flag2
        frmHijo = Nothing
        Me.Cbo1.Focus()
    End Sub
#End Region
#Region "TextBox"
    Private Sub Txt4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt4.KeyPress
        If Not (Asc(e.KeyChar) = 13) Then

        End If
    End Sub
#End Region
#Region "Grillas"
    Private Sub Grid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid2.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "ParteEq" _
                    OrElse uColumn.Key = "Urgente" OrElse uColumn.Key = "UrgenteMantto" _
                    OrElse uColumn.Key = "Observacion") Then
 
                uColumn.Hidden = Boolean.TrueString
            Else
                'If Me.Cbo3.Value = "K1" Then
                '    If uColumn.Key = "Urgente" OrElse uColumn.Key = "UrgenteMantto" Or uColumn.Key = "Observacion" Then
                '        uColumn.CellActivation = Activation.AllowEdit
                '    End If
                'Else
                '    If uColumn.Key = "Urgente" OrElse uColumn.Key = "UrgenteMantto" Or uColumn.Key = "Observacion" Then
                '        uColumn.CellActivation = Activation.NoEdit

                '    End If
                'End If
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

        For Each xRow As UltraGridRow In e.Layout.Rows
            If Me.Cbo3.Value = "K1" Then
                If gAreaMantto = True Then
                    xRow.Cells("Urgente").Activation = Activation.NoEdit
                    xRow.Cells("UrgenteMantto").Activation = Activation.AllowEdit
                Else
                    xRow.Cells("Urgente").Activation = Activation.AllowEdit
                    xRow.Cells("UrgenteMantto").Activation = Activation.NoEdit
                End If

                If UCase(Trim(User_Sistema)) = "SA" Then
                    xRow.Cells("Urgente").Activation = Activation.AllowEdit
                    xRow.Cells("UrgenteMantto").Activation = Activation.AllowEdit
                End If
            Else
                xRow.Cells("Urgente").Activation = Activation.NoEdit
                xRow.Cells("UrgenteMantto").Activation = Activation.NoEdit
            End If
           
        Next
    End Sub
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Fecha" _
                    OrElse uColumn.Key = "Responsable" OrElse uColumn.Key = "TipoCL" _
                    OrElse uColumn.Key = "Equipo" OrElse uColumn.Key = "Control" _
                    OrElse uColumn.Key = "Valor" OrElse uColumn.Key = "Und" _
                    OrElse uColumn.Key = "Estado") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
#End Region
 
End Class