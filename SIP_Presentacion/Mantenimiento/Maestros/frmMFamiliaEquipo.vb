Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.IO
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmMFamiliaEquipo
#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)
    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private TipoG As sTate

    Private Ls_FamiliaEq As List(Of ETFamiliaEquipo) = Nothing
    Private _IDFamiliaEq As Long
    Private _Resultado As Long

#End Region
#Region "Propiedades"
    Private Property IDFamiliaEq() As Long
        Get
            Return _IDFamiliaEq
        End Get
        Set(ByVal value As Long)
            _IDFamiliaEq = value
        End Set
    End Property
    Private Property Resultado() As Long
        Get
            Return _Resultado
        End Get
        Set(ByVal value As Long)
            _Resultado = value
        End Set
    End Property
#End Region
#Region "Formulario"

    Private Sub frmMFamiliaEquipo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub frmMFamiliaEquipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call Iniciar()

    End Sub
#End Region
#Region "Procedimientos Privados"
    Private Sub HabilitarControles(ByVal D As Boolean)
        Me.Txt1.ReadOnly = True
        Me.Txt2.ReadOnly = Not D
        Me.Txt3.ReadOnly = Not D
        Me.Cbo1.ReadOnly = True
        Btn1.Enabled = D
    End Sub
    Sub Iniciar()
        Me.Tab1.Tabs("T01").Selected = Boolean.TrueString

        Negocio.FamiliaEquipo = New NGFamiliaEquipo
        Entidad.MyLista = New ETMyLista
        Ls_FamiliaEq = New List(Of ETFamiliaEquipo)
        Entidad.MyLista = Negocio.FamiliaEquipo.ConsultarFamiliaEquipo

        If Entidad.MyLista.Validacion Then
            Ls_FamiliaEq = Entidad.MyLista.Ls_FamiliaEquipo
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_FamiliaEq)
        TipoG = sTate.eView
    End Sub
    Private Sub Limpiar()
        Dim Ls_Atributo As List(Of ETAtributo) = Nothing
        Dim Ls_FamiliaEq_Comp As List(Of ETParteEquipo) = Nothing

        Me.Txt1.Clear()
        Me.Txt2.Clear()
        Me.Txt3.Clear()
        Me.Cbo1.Value = "K1"
        Me.Ptb1.Image = ""
        Call InicializarVariables()


        Ls_Atributo = New List(Of ETAtributo)
        Call CargarUltraGrid(Grid2, Ls_Atributo)

        Ls_FamiliaEq_Comp = New List(Of ETParteEquipo)
        Call CargarUltraGrid(Grid3, Ls_FamiliaEq_Comp)

    End Sub
    Private Sub CargarAtributos()
        Dim ObjAtributo As New ETAtributo
        Dim Ls_Atributo As List(Of ETAtributo) = Nothing
        Negocio.Atributo = New NGAtributo
        Entidad.MyLista = New ETMyLista


        Ls_Atributo = New List(Of ETAtributo)
        ObjAtributo.IDCatalogoOrigen = Me.IDFamiliaEq
        ObjAtributo.Tipo = 3
        Entidad.MyLista = Negocio.Atributo.ConsultarAtributoFamiliaEquipo(ObjAtributo)

        If Entidad.MyLista.Validacion Then
            Ls_Atributo = Entidad.MyLista.Ls_Atributo
        End If

        Call CargarUltraGrid(Grid2, Ls_Atributo)
    End Sub
    Private Sub Cargar_FamiliaEquipo_Componente()
        Dim ObjParteEq As New ETParteEquipo
        Dim Ls_FamiliaEq_Comp As List(Of ETParteEquipo) = Nothing
        Negocio.ParteEquipo = New NGParteEquipo
        Entidad.MyLista = New ETMyLista

        Ls_FamiliaEq_Comp = New List(Of ETParteEquipo)
        ObjParteEq.IDCatalogoOrigen = Me.IDFamiliaEq
        ObjParteEq.Tipo = 3
        Entidad.MyLista = Negocio.ParteEquipo.Consultar_FamiliaEq_ParteEquipo(ObjParteEq)

        If Entidad.MyLista.Validacion Then
            Ls_FamiliaEq_Comp = Entidad.MyLista.Ls_ParteEquipo
        End If

        Call CargarUltraGrid(Grid3, Ls_FamiliaEq_Comp)
    End Sub
    Private Sub InicializarVariables()
        _IDFamiliaEq = 0
        _Resultado = 0
    End Sub
#End Region
#Region "Procedimientos Publicos"
    Public Sub Nuevo()
        Call HabilitarControles(True)
        Call Limpiar()
        Me.Tab1.Tabs("T02").Selected = Boolean.TrueString
        TipoG = sTate.eNew
        Me.Txt2.Focus()
    End Sub


    Public Sub Grabar()
        Dim ObjFamiliaEq As ETFamiliaEquipo = Nothing
        If Me.Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
        If Not (TipoG = sTate.eNew OrElse TipoG = sTate.eEdit) = Boolean.TrueString Then Exit Sub
        ObjFamiliaEq = New ETFamiliaEquipo
        ObjFamiliaEq.IDFamiliaEq = Me.IDFamiliaEq
        ObjFamiliaEq.Codigo = Me.Txt1.Text.Trim
        ObjFamiliaEq.Descripcion = Me.Txt2.Text.Trim
        If Me.Txt3.Text.Trim = "" Then
            ObjFamiliaEq.ExisteImage = Boolean.FalseString
        Else
            ObjFamiliaEq.ExisteImage = Boolean.TrueString
            ObjFamiliaEq.Foto = ConvertImageByte(Me.Txt3.Text.Trim)
        End If
        ObjFamiliaEq.Usuario = User_Sistema
        ObjFamiliaEq.Status = IIf(Me.Cbo1.Value = "K1", "", "*")
        ObjFamiliaEq.Tipo = TipoG

        Negocio.FamiliaEquipo = New NGFamiliaEquipo

        Try
            Me.Resultado = Negocio.FamiliaEquipo.Mantto_FamiliaEquipo(ObjFamiliaEq)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, msgComacsa)
        End Try

        Call Iniciar()
    End Sub
    Public Sub Eliminar()
        Dim ObjFamiliaEq As ETFamiliaEquipo = Nothing
        If Me.Tab1.Tabs("T01").Selected = Boolean.FalseString Then Exit Sub
        TipoG = sTate.eDel
        If Not (TipoG = sTate.eDel) = Boolean.TrueString Then Exit Sub
        If IsDBNull(Me.Grid1.ActiveRow.Cells("IDFamiliaEq").Value) = Boolean.TrueString Then Exit Sub

        ObjFamiliaEq = New ETFamiliaEquipo

        ObjFamiliaEq.IDFamiliaEq = Me.Grid1.ActiveRow.Cells("IDFamiliaEq").Value
        ObjFamiliaEq.Codigo = Me.Grid1.ActiveRow.Cells("Codigo").Value
        ObjFamiliaEq.Usuario = User_Sistema
        ObjFamiliaEq.Tipo = TipoG

        Negocio.FamiliaEquipo = New NGFamiliaEquipo

        Try
            Me.Resultado = Negocio.FamiliaEquipo.Mantto_FamiliaEquipo(ObjFamiliaEq)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Call Iniciar()
    End Sub

    Public Sub Modificar()
        If Me.Grid1.Rows.Count <= 0 Then Exit Sub
        If IsDBNull(Me.Grid1.ActiveRow.Cells("IDFamiliaEq").Value) = Boolean.TrueString Then Exit Sub
        Call Limpiar()
        TipoG = sTate.eEdit
        Me.IDFamiliaEq = Me.Grid1.ActiveRow.Cells("IDFamiliaEq").Value
        Me.Txt1.Text = Me.Grid1.ActiveRow.Cells("Codigo").Value
        Me.Txt2.Text = Me.Grid1.ActiveRow.Cells("Descripcion").Value

        Dim byteBLOBData(-1) As [Byte]
        byteBLOBData = CType(Me.Grid1.ActiveRow.Cells("Foto").Value, [Byte]())
        Dim stmBLOBData As New MemoryStream(byteBLOBData)
        Me.Ptb1.Image = Image.FromStream(stmBLOBData)

        If Me.Grid1.ActiveRow.Cells("Status").Value = "*" Then
            Me.Cbo1.Value = "K2"
            Call HabilitarControles(False)
        Else
            Call HabilitarControles(True)
            Me.Cbo1.Value = "K1"
        End If
        Me.Tab1.Tabs("T02").Selected = Boolean.TrueString

        Call CargarAtributos()
        Call Cargar_FamiliaEquipo_Componente()
    End Sub

    Public Sub Cancelar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Iniciar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Public Sub Actualizar()
        Call Cancelar()
    End Sub

#End Region
#Region "Botones"
    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        Ofd1.Filter = "Archivos de imagen(*.JPG)|*.JPG"
        Ofd1.ShowDialog()
        Me.Txt3.Text = Me.Ofd1.FileName
        Try
            Me.Ptb1.Image = Image.FromFile(Me.Txt3.Text.Trim)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
#End Region
#Region "Grillas"
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" OrElse _
                    uColumn.Key = "Estado") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub Grid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid2.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                    OrElse uColumn.Key = "Oblig" OrElse uColumn.Key = "Control" _
                    OrElse uColumn.Key = "NomEq" OrElse uColumn.Key = "Orden") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

    End Sub
    Private Sub Grid3_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid3.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                    OrElse uColumn.Key = "Interno" OrElse uColumn.Key = "Item" _
                    OrElse uColumn.Key = "CodigoOrigen" OrElse uColumn.Key = "DescripcionOrigen") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
#End Region



End Class