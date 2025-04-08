Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.IO
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmMEquipo

#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)
    Private Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum

    Private Enum ValorTipoDato
        vTexto = 1
        vEntero = 2
        vDecimal = 3
        vDate = 4
        vTime = 5
    End Enum

    Dim TipoG As State
    Dim TipoDato As ValorTipoDato

    Private Ls_Combo1 As List(Of ETLineaNegocio) = Nothing
    Private Ls_Combo2 As List(Of ETFamiliaEquipo) = Nothing
    Private dataSetArbol As DataSet
    Private Ls_Mantenimiento As List(Of ETOrdenTrabajo_Mantto) = Nothing

    Dim ValorCelda As String

    Private _Componente As Long = 0
    Private _ComponenteOrigen As Long = 0
    Private _Item As Long = 0
    Private _ItemOrigen As Long = 0
    Private _LevelNode As Integer = 0
    Private _EquipoID As Long = 0
    Private _Resultado As Long = 0
    Private _FamiliaEquipoID As Long = 0
    Private _Nuevo As Integer = 0
    Private _Profundidad As Integer
    Private _NodoPadre As Integer
    Private _Responsable As String = String.Empty
    Private _Manipulador As String = String.Empty
    Private _CodigoAnterior As String = String.Empty

#End Region

#Region "Formulario"
    Private Sub frmMEquipo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmMEquipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Iniciar()
    End Sub
#End Region
#Region "Propiedades"
    Private Property Componente() As Long
        Get
            Return _Componente
        End Get
        Set(ByVal value As Long)
            _Componente = value
        End Set
    End Property
    Private Property ItemComp() As Long
        Get
            Return _Item
        End Get
        Set(ByVal value As Long)
            _Item = value
        End Set
    End Property
    Private Property ComponenteOrigen() As Long
        Get
            Return _ComponenteOrigen
        End Get
        Set(ByVal value As Long)
            _ComponenteOrigen = value
        End Set
    End Property
    Private Property ItemCompOrigen() As Long
        Get
            Return _ItemOrigen
        End Get
        Set(ByVal value As Long)
            _ItemOrigen = value
        End Set
    End Property
    Private Property LevelNode() As Integer
        Get
            Return _LevelNode
        End Get
        Set(ByVal value As Integer)
            _LevelNode = value
        End Set
    End Property
    Private Property FamiliaEqID() As Long
        Get
            Return _FamiliaEquipoID
        End Get
        Set(ByVal value As Long)
            _FamiliaEquipoID = value
        End Set
    End Property
    Private Property EquipoID() As Long
        Get
            Return _EquipoID
        End Get
        Set(ByVal value As Long)
            _EquipoID = value
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
    Private Property NewNode() As Integer
        Get
            Return _Nuevo
        End Get
        Set(ByVal value As Integer)
            _Nuevo = value
        End Set
    End Property
    Private Property Profundidad() As Integer
        Get
            Return _Profundidad
        End Get
        Set(ByVal value As Integer)
            _Profundidad = value
        End Set
    End Property
    Private Property NodoPadre() As Integer
        Get
            Return _NodoPadre
        End Get
        Set(ByVal value As Integer)
            _NodoPadre = value
        End Set
    End Property
    Private Property Responsable() As String
        Get
            Return _Responsable
        End Get
        Set(ByVal value As String)
            _Responsable = value
        End Set
    End Property
    Private Property Manipulador() As String
        Get
            Return _Manipulador
        End Get
        Set(ByVal value As String)
            _Manipulador = value
        End Set
    End Property
    Private Property CodigoAnterior() As String
        Get
            Return _CodigoAnterior
        End Get
        Set(ByVal value As String)
            _CodigoAnterior = value
        End Set
    End Property
#End Region

#Region "Procedimientos Publicos"

    Public Sub Nuevo()
        TipoG = State.eNew
        Call HabilitarControles(Boolean.TrueString)
        Call CargarLineaNegocio()
        Call CargarFamiliaEquipo()
        Call LimpiarDatos()
        Me.Tab1.Tabs("T03").Enabled = Boolean.FalseString
        Me.Tab1.Tabs("T02").Selected = Boolean.TrueString
    End Sub
    Public Sub Grabar()
        Dim ObjEquipo As ETEquipo = Nothing
        Dim Ls_AtributoTemp As List(Of ETAtributo) = Nothing
        Dim Ls_Equipo_Componente As List(Of ETAtributo) = Nothing
        Dim EquipoIDTemp As Long = 0
        Entidad.MyLista = New ETMyLista
        Dim Mensaje As String

        If Me.Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
        If Not (TipoG = State.eNew OrElse TipoG = State.eEdit) = Boolean.TrueString Then Exit Sub
        ObjEquipo = New ETEquipo
        ObjEquipo.Equipo = Me.EquipoID
        ObjEquipo.Codigo = Me.Txt1.Text.Trim
        ObjEquipo.LinNeg = Me.Cbo1.Value
        Me.FamiliaEqID = IIf(Me.Cbo2.Value <= 0, 0, Me.Cbo2.Value)
        ObjEquipo.FamiliaEqID = Me.FamiliaEqID
        ObjEquipo.Descripcion = Me.Txt2.Text.Trim
        If Me.Txt3.Text.Trim = "" Then
            ObjEquipo.ExisteFoto = Boolean.FalseString
        Else
            ObjEquipo.ExisteFoto = Boolean.TrueString
            ObjEquipo.Foto = ConvertImageByte(Me.Txt3.Text.Trim)
        End If

        If Me.Txt4.Text.Trim = "" Then
            ObjEquipo.ExistePlano = Boolean.FalseString
        Else
            ObjEquipo.ExistePlano = Boolean.TrueString
            ObjEquipo.Plano = ConvertImageByte(Me.Txt4.Text.Trim)
        End If
        ObjEquipo.CodResponsable = Responsable
        ObjEquipo.CodManipulador = Manipulador
        ObjEquipo.CodigoAnterior = CodigoAnterior
        ObjEquipo.Usuario = User_Sistema

        Select Case Cbo3.Value
            Case "K1"
                ObjEquipo.Status = ""
            Case "K2"
                ObjEquipo.Status = "M"
            Case "K3"
                ObjEquipo.Status = "B"
            Case "K4"
                ObjEquipo.Status = "*"
        End Select

        ObjEquipo.Tipo = TipoG

        Ls_AtributoTemp = New List(Of ETAtributo)


        For Each xRow As UltraGridRow In Grid2.Rows
            Entidad.AtribEquipo = New ETAtributo
            With Entidad.AtribEquipo
                .IDCatalogoOrigen = xRow.Cells("IDCatalogoOrigen").Value
                .IDCatalogo = xRow.Cells("IDCatalogo").Value
                .Valor = xRow.Cells("Valor").Value
                If xRow.Cells("Oblig").Value = Boolean.TrueString Then
                    If xRow.Cells("Valor").Value = "" Then
                        Mensaje = "El Atributo: " & xRow.Cells("Codigo").Value & " - " & xRow.Cells("Descripcion").Value
                        Mensaje = Mensaje & Chr(13) & "Su Valor es de Ingreso Obligatorio"
                        Entidad.AtribEquipo = Nothing
                        Ls_AtributoTemp = Nothing
                        ObjEquipo = Nothing
                        MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                        Exit Sub
                    End If
                End If
                .TipoG = xRow.Cells("TipoG").Value
                .Status = ""
                .Usuario = User_Sistema
            End With
            Ls_AtributoTemp.Add(Entidad.AtribEquipo)
        Next

        If TipoG = State.eEdit Then
            Ls_Equipo_Componente = New List(Of ETAtributo)
            For Each xRow As UltraGridRow In Grid3.Rows
                Entidad.Equipo_ParteEq_Atributo_Valor = New ETAtributo
                With Entidad.Equipo_ParteEq_Atributo_Valor
                    .IDCatalogoOrigen = xRow.Cells("IDCatalogoOrigen").Value
                    .IDCatalogo = xRow.Cells("IDCatalogo").Value
                    .Valor = xRow.Cells("Valor").Value
                    If xRow.Cells("Oblig").Value = Boolean.TrueString Then
                        If xRow.Cells("Valor").Value = "" Then
                            Mensaje = "El Atributo: " & xRow.Cells("Codigo").Value & " - " & xRow.Cells("Descripcion").Value
                            Mensaje = Mensaje & Chr(13) & "Componente: " & Me.UltraLabel10.Text.Trim
                            Mensaje = Mensaje & Chr(13) & "Su Valor es de Ingreso Obligatorio"
                            Entidad.Equipo_ParteEq_Atributo_Valor = Nothing
                            Ls_Equipo_Componente = Nothing
                            Ls_AtributoTemp = Nothing
                            ObjEquipo = Nothing
                            MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
                            Exit Sub
                        End If
                    End If
                    .Status = ""
                    .Usuario = User_Sistema
                    If .Nuevo = "N" Then
                        .Tipo = 1
                    Else
                        .Tipo = 2
                    End If
                End With
                Ls_Equipo_Componente.Add(Entidad.Equipo_ParteEq_Atributo_Valor)
            Next
        End If
        Negocio.Equipo = New NGEquipo

        Try
            EquipoIDTemp = Negocio.Equipo.Mantto_Equipo(ObjEquipo, Ls_AtributoTemp, Ls_Equipo_Componente)

            If EquipoIDTemp > 0 Then
                EquipoID = EquipoIDTemp
                Call GrabarArbol(Negocio.Equipo)
                MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
                If Tab1.Tabs("T03").Selected = Boolean.FalseString Then
                    Call Iniciar()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub Modificar()
        If Me.Grid1.Rows.Count <= 0 Then Exit Sub
        If Me.Grid1.ActiveRow Is Nothing Then Exit Sub
        Call LimpiarDatos()
        TipoG = State.eEdit
        Me.Cbo3.Value = Me.Grid1.ActiveRow.Cells("Status").Value
        Call CargarLineaNegocio()
        Call CargarFamiliaEquipo()
        Txt1.Text = Me.Grid1.ActiveRow.Cells("Codigo").Value
        Me.Txt2.Text = Me.Grid1.ActiveRow.Cells("Descripcion").Value
        Me.Txt5.Text = Me.Grid1.ActiveRow.Cells("CodResponsable").Value.ToString.Trim & " - " & Me.Grid1.ActiveRow.Cells("Responsable").Value
        Me.Txt6.Text = Me.Grid1.ActiveRow.Cells("CodManipulador").Value.ToString.Trim & " - " & Me.Grid1.ActiveRow.Cells("Manipulador").Value
        Me.Responsable = Me.Grid1.ActiveRow.Cells("CodResponsable").Value.ToString.Trim
        Me.Manipulador = Me.Grid1.ActiveRow.Cells("CodManipulador").Value.ToString.Trim
        Me.Cbo1.Value = Me.Grid1.ActiveRow.Cells("LinNegID").Value
        Me.Cbo2.Value = Me.Grid1.ActiveRow.Cells("FamiliaEqID").Value
        Me.EquipoID = Me.Grid1.ActiveRow.Cells("Equipo").Value
        Me.FamiliaEqID = Me.Grid1.ActiveRow.Cells("FamiliaEqID").Value
        Me.CodigoAnterior = Me.Grid1.ActiveRow.Cells("CodigoAnterior").Value
        Txt7.Text = CodigoAnterior

        If Me.Grid1.ActiveRow.Cells("ExisteFoto").Value = Boolean.TrueString Then
            Dim byteBLOBDataFoto(-1) As [Byte]
            byteBLOBDataFoto = CType(Me.Grid1.ActiveRow.Cells("Foto").Value, [Byte]())
            Dim stmBLOBDataFoto As New MemoryStream(byteBLOBDataFoto)
            Me.Ptb1.Image = Image.FromStream(stmBLOBDataFoto)
        End If

        If Me.Grid1.ActiveRow.Cells("ExistePlano").Value = Boolean.TrueString Then
            Dim byteBLOBDataPlano(-1) As [Byte]
            byteBLOBDataPlano = CType(Me.Grid1.ActiveRow.Cells("Plano").Value, [Byte]())
            Dim stmBLOBDataPlano As New MemoryStream(byteBLOBDataPlano)
            Me.Ptb2.Image = Image.FromStream(stmBLOBDataPlano)
        End If
        Call CargarAtributosEquipo()
        Call Cargar_Equipo_ParteEq()
        Call Cargar_Equipo_Mantenimiento()
        Me.Tab1.Tabs("T03").Enabled = Boolean.TrueString
        Me.Tab1.Tabs("T02").Selected = Boolean.TrueString


    End Sub
    Public Sub Eliminar()

        If Grid1.Rows.Count <= 0 Then Return
        If Grid1.ActiveRow Is Nothing Then Return
        If Grid1.ActiveRow.Cells("Status").Value <> "K1" Then
            MsgBox("No se puede Anular el Equipo", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        Entidad.Equipo.Equipo = Grid1.ActiveRow.Cells("Equipo").Value
        Entidad.Equipo.Codigo = Grid1.ActiveRow.Cells("Codigo").Value
        Entidad.Equipo.Status = "*"
        Entidad.Equipo.Tipo = 3

        If Negocio.Equipo.Mantto_Equipo(Entidad.Equipo, Nothing, Nothing) > 0 Then
            Call Iniciar()
        End If


    End Sub
    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Iniciar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

#End Region
#Region "Procedimientos Privados"
    Private Sub GrabarArbol(ByVal NGArbol As NGEquipo)
        Dim EntEq As New ETEquipo
        EntEq.Equipo = Me.EquipoID
        EntEq.FamiliaEqID = Me.FamiliaEqID
        Dim EntNodoPadre As New ETAtributo

        If Me.NewNode > 0 Then
            For Each XNode As UltraWinTree.UltraTreeNode In Tree1.Nodes
                If Mid(XNode.Tag, Len(XNode.Tag), 1) = "N" Then
                    Entidad.Atributo = New ETAtributo
                    With Entidad.Atributo
                        .ParteEquipoRaiz = Val(XNode.DataKey)
                        .ItemRaiz = Val(Mid(XNode.Tag, 1, Len(XNode.Tag) - 1))
                        .Level = XNode.Level
                        .Status = ""
                        .Tipo = 1
                        .Usuario = User_Sistema
                    End With
                    Me.NodoPadre = NGArbol.Mantto_Equipo_ParteEq(EntEq, Entidad.Atributo)
                    EntNodoPadre.ParteEquipoRaiz = Val(XNode.DataKey)
                    EntNodoPadre.ItemRaiz = Val(Mid(XNode.Tag, 1, Len(XNode.Tag) - 1))
                    EntNodoPadre.NodoPadre = Me.NodoPadre
                    EntNodoPadre.Nodo = 0
                    Entidad.Atributo = Nothing
                    Call AgregarListaTreeNuevo(EntEq, EntNodoPadre, Me.Tree1.Nodes(XNode.Index), NGArbol)
                Else
                    Me.NodoPadre = 0
                    Dim dataViewHijos As DataView
                    dataViewHijos = New DataView(dataSetArbol.Tables("TablaArbol"))
                    dataViewHijos.RowFilter = dataSetArbol.Tables("TablaArbol").Columns("IdentificadorPadre").ColumnName + " = " + Me.NodoPadre.ToString()
                    For Each dataRowCurrent As DataRowView In dataViewHijos
                        If Val(dataRowCurrent("IdentificadorNodo").ToString().Trim()) = Val(XNode.DataKey) Then
                            EntNodoPadre.ParteEquipoRaiz = Val(dataRowCurrent("ParteEquipoID").ToString().Trim())
                            Exit For
                        End If
                    Next dataRowCurrent
                    EntNodoPadre.Nodo = Val(Me.NodoPadre)
                    EntNodoPadre.ItemRaiz = Val(Mid(XNode.Tag, 1, Len(XNode.Tag) - 1))
                    EntNodoPadre.NodoPadre = Val(XNode.DataKey)

                    Call AgregarListaTreeNuevo(EntEq, EntNodoPadre, Me.Tree1.Nodes(XNode.Index), NGArbol)
                End If
            Next
        End If

        EntNodoPadre = Nothing
    End Sub
    Private Sub AgregarListaTreeNuevo(ByVal EntEquipo As ETEquipo, ByVal NodoParent As ETAtributo, ByVal TreeNodo As Infragistics.Win.UltraWinTree.UltraTreeNode, ByVal NGArbolito As NGEquipo)
        For Each XNode As UltraWinTree.UltraTreeNode In TreeNodo.Nodes
            If Mid(XNode.Tag, Len(XNode.Tag), 1) = "N" Then
                Entidad.Atributo = New ETAtributo
                With Entidad.Atributo
                    .ParteEquipoRaiz = NodoParent.ParteEquipoRaiz
                    .ItemRaiz = NodoParent.ItemRaiz
                    .IDCatalogoOrigen = Val(XNode.DataKey)
                    .ItemParteEq = Val(Mid(XNode.Tag, 1, Len(XNode.Tag) - 1))
                    If TipoG = State.eNew Then
                        .ParteEquipo = Val(XNode.Parent.DataKey)
                    Else
                        Dim dataViewHijos As DataView
                        dataViewHijos = New DataView(dataSetArbol.Tables("TablaArbol"))
                        dataViewHijos.RowFilter = dataSetArbol.Tables("TablaArbol").Columns("IdentificadorPadre").ColumnName + " = " + NodoParent.Nodo.ToString()
                        For Each dataRowCurrent As DataRowView In dataViewHijos
                            If Mid(XNode.Parent.Tag, Len(XNode.Parent.Tag), 1) = "N" Then
                                .ParteEquipo = Val(XNode.Parent.DataKey)
                            Else
                                If Val(dataRowCurrent("IdentificadorNodo").ToString().Trim()) = Val(NodoParent.NodoPadre) Then
                                    .ParteEquipo = Val(dataRowCurrent("ParteEquipoID").ToString().Trim())
                                    Exit For
                                End If
                            End If
                           
                        Next dataRowCurrent
                    End If
                   
                    .ItemPadreParteEq = Val(Mid(XNode.Parent.Tag, 1, Len(XNode.Parent.Tag) - 1))
                    .Level = XNode.Level
                    .Tipo = 1
                    .Status = ""
                    .NodoPadre = NodoParent.NodoPadre
                    .Usuario = User_Sistema
                End With
                Me.NodoPadre = NGArbolito.Mantto_Equipo_ParteEq(EntEquipo, Entidad.Atributo)
                Entidad.Atributo = Nothing

                Dim EntNodoPadre As New ETAtributo
                EntNodoPadre.ParteEquipoRaiz = NodoParent.ParteEquipoRaiz
                EntNodoPadre.ItemRaiz = NodoParent.ItemRaiz
                EntNodoPadre.NodoPadre = Me.NodoPadre
                EntNodoPadre.Nodo = NodoParent.NodoPadre
                Call AgregarListaTreeNuevo(EntEquipo, EntNodoPadre, TreeNodo.Nodes(XNode.Index), NGArbolito)
                EntNodoPadre = Nothing
            Else

                Dim EntNodoPadre As New ETAtributo
                EntNodoPadre.ParteEquipoRaiz = NodoParent.ParteEquipoRaiz
                EntNodoPadre.ItemRaiz = NodoParent.ItemRaiz
                EntNodoPadre.NodoPadre = Val(XNode.DataKey)
                EntNodoPadre.Nodo = NodoParent.NodoPadre
                Call AgregarListaTreeNuevo(EntEquipo, EntNodoPadre, TreeNodo.Nodes(XNode.Index), NGArbolito)
                EntNodoPadre = Nothing
            End If
        Next
    End Sub
    Private Sub CargarAtributosComponente()
        Dim Lst_AtribComp As List(Of ETAtributo) = Nothing
        Dim ObjComp As New ETAtributo
        Negocio.Equipo = New NGEquipo
        Entidad.MyLista = New ETMyLista
        ObjComp.Nodo = Me.Componente
        ObjComp.Tipo = 3
        Entidad.MyLista = Negocio.Equipo.Consultar_Equipo_ParteEq_Atrib_Valor(ObjComp)

        If Entidad.MyLista.Validacion Then
            Lst_AtribComp = Entidad.MyLista.Ls_Atributo
        End If

        Call CargarUltraGrid(Me.Grid3, Lst_AtribComp)
    End Sub
    Private Sub InicializarPropiedades()
        _Componente = 0
        _ComponenteOrigen = 0
        _Item = 0
        _ItemOrigen = 0
        _LevelNode = -1
        _EquipoID = 0
        _Resultado = 0
        _FamiliaEquipoID = 0
        _Nuevo = 0
        _Profundidad = 0
        _NodoPadre = 0
        _Manipulador = String.Empty
        _Responsable = String.Empty
        _CodigoAnterior = String.Empty
    End Sub
    Private Sub InicializarPropNodo()
        _Componente = 0
        _ComponenteOrigen = 0
        _Item = 0
        _ItemOrigen = 0
        _LevelNode = -1
    End Sub
    Private Sub HabilitarControles(ByVal D As Boolean)
        Me.Cbo1.ReadOnly = Not D
        Me.Cbo2.ReadOnly = Not D
        Me.Btn1.Enabled = D
        Me.Btn2.Enabled = D
        Me.Btn3.Enabled = D
        Me.Btn4.Enabled = D
        Me.Btn5.Enabled = D
        Me.Cbo3.ReadOnly = Boolean.TrueString
    End Sub
    Private Sub Iniciar()
        Dim Ls_Equipo As List(Of ETEquipo) = Nothing
        Dim ObjEquipo As New ETEquipo

        Me.Tab1.Tabs("T01").Selected = Boolean.TrueString
        TipoG = State.eView

        Negocio.Equipo = New NGEquipo
        Entidad.MyLista = New ETMyLista

        Ls_Equipo = New List(Of ETEquipo)
        ObjEquipo.Tipo = TipoG
        Entidad.MyLista = Negocio.Equipo.Consultar_Equipo()

        If Entidad.MyLista.Validacion Then
            Ls_Equipo = Entidad.MyLista.Ls_Equipo
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Equipo)
        Call LimpiarDatos()
    End Sub
    Private Sub CargarLineaNegocio()

        Entidad.MyLista = New ETMyLista

        Ls_Combo1 = New List(Of ETLineaNegocio)

        If TipoG = State.eNew Then
            Entidad.MyLista = Negocio.LineaNegocio.ConsultarLineaNegocio_Activos
        Else
            If Cbo3.Value = "K3" Or Cbo3.Value = "K4" Then
                Entidad.MyLista = Negocio.LineaNegocio.ConsultarLineaNegocio
            Else
                Entidad.MyLista = Negocio.LineaNegocio.ConsultarLineaNegocio_Activos
            End If
        End If

        If Entidad.MyLista.Validacion Then
            Ls_Combo1 = Entidad.MyLista.Ls_LinNeg
        End If

        Call CargarUltraCombo(Me.Cbo1, Ls_Combo1, "IDCatalogo", "Descripcion", String.Empty)

    End Sub
    Private Sub CargarFamiliaEquipo()
        Negocio.FamiliaEquipo = New NGFamiliaEquipo
        Entidad.MyLista = New ETMyLista

        Ls_Combo2 = New List(Of ETFamiliaEquipo)

        If TipoG = State.eNew Then
            Entidad.MyLista = Negocio.FamiliaEquipo.ConsultarFamiliaEquipo_Enlazar
        Else
            If Cbo3.Value = "K3" Or Cbo3.Value = "K4" Then
                Entidad.MyLista = Negocio.FamiliaEquipo.ConsultarFamiliaEquipo_Todos
            Else
                Entidad.MyLista = Negocio.FamiliaEquipo.ConsultarFamiliaEquipo_Enlazar
            End If
        End If

        If Entidad.MyLista.Validacion Then
            Ls_Combo2 = Entidad.MyLista.Ls_FamiliaEquipo
        End If

        Call CargarUltraCombo(Me.Cbo2, Ls_Combo2, "IDCatalogo", "Descripcion", String.Empty)

    End Sub
    Private Sub CargarAtributosEquipo_New()
        Dim LsAtributoEquipo As List(Of ETAtributo) = Nothing
        Dim ObjFamEq As New ETFamiliaEquipo

        Negocio.Equipo = New NGEquipo
        Entidad.MyLista = New ETMyLista

        LsAtributoEquipo = New List(Of ETAtributo)
        ObjFamEq.IDFamiliaEq = Me.Cbo2.Value
        ObjFamEq.Tipo = 1
        Entidad.MyLista = Negocio.Equipo.ConsultarFamiliaEquipo(ObjFamEq)


        If Entidad.MyLista.Validacion Then
            LsAtributoEquipo = Entidad.MyLista.Ls_Atributo
        End If

        Call CargarUltraGrid(Me.Grid2, LsAtributoEquipo)

    End Sub
    Private Sub CargarAtributosEquipo()
        Dim LsAtributoEquipo As List(Of ETAtributo) = Nothing
        Dim ObjEq As New ETEquipo

        Negocio.Equipo = New NGEquipo
        Entidad.MyLista = New ETMyLista

        LsAtributoEquipo = New List(Of ETAtributo)

        ObjEq.Equipo = Me.EquipoID
        ObjEq.FamiliaEqID = Me.FamiliaEqID
        ObjEq.Tipo = 3
        Entidad.MyLista = Negocio.Equipo.Consultar_Atributos_Equipo(ObjEq)


        If Entidad.MyLista.Validacion Then
            LsAtributoEquipo = Entidad.MyLista.Ls_Atributo
        End If

        Call CargarUltraGrid(Me.Grid2, LsAtributoEquipo)

    End Sub
    Private Sub CargarAtributos_ParteEq_Equipo_New()
        Dim ObjFamEq As New ETFamiliaEquipo

        Negocio.Equipo = New NGEquipo
        ObjFamEq.IDFamiliaEq = Me.Cbo2.Value
        ObjFamEq.Tipo = 2
        dataSetArbol = Negocio.Equipo.Consultar_ParteEq_FamiliaEquipo(ObjFamEq)

        Tree1.Nodes.Clear()
        Call CrearNodosDelPadre(0, Nothing)

    End Sub
    Private Sub Cargar_Equipo_ParteEq()
        Dim ObjEquipo As New ETEquipo

        Negocio.Equipo = New NGEquipo
        ObjEquipo.Equipo = Me.EquipoID
        ObjEquipo.FamiliaEqID = Me.FamiliaEqID
        ObjEquipo.Tipo = 4
        dataSetArbol = Negocio.Equipo.Consultar_Equipo_ParteEq(ObjEquipo)

        Tree1.Nodes.Clear()
        Call CrearNodosDelPadre(0, Nothing)

    End Sub
    Private Sub Cargar_Equipo_Mantenimiento()

        Negocio.Equipo = New NGEquipo
        Entidad.Equipo = New ETEquipo
        Entidad.Equipo.Equipo = Me.EquipoID
        Ls_Mantenimiento = New List(Of ETOrdenTrabajo_Mantto)
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.Equipo.Consultar_Equipo_Mantenimiento(Entidad.Equipo)
        If Entidad.MyLista.Validacion Then
            Ls_Mantenimiento = Entidad.MyLista.Ls_Orden_Trabajo_Mantto
        End If

        Call CargarUltraGrid(Grid4, Ls_Mantenimiento)

    End Sub
    Private Sub LimpiarDatos()
        Me.Txt1.Clear()
        Me.Txt2.Clear()
        Me.Txt3.Clear()
        Me.Txt4.Clear()
        Me.Txt5.Clear()
        Me.Txt6.Clear()
        Me.Txt7.Clear()
        UltraLabel13.Visible = False
        If Cbo1.Rows.Count > 0 Then
            Me.Cbo1.Value = ""
        End If

        If Cbo2.Rows.Count > 0 Then
            Me.Cbo2.Value = ""
        End If

        Me.Cbo3.Value = "K1"
        Me.Ptb1.Image = ""
        Me.Ptb2.Image = ""
        Call InicializarPropiedades()
        Dim LsAtributoEquipo As List(Of ETAtributo) = Nothing
        LsAtributoEquipo = New List(Of ETAtributo)
        Ls_Mantenimiento = New List(Of ETOrdenTrabajo_Mantto)

        Call CargarUltraGrid(Me.Grid2, LsAtributoEquipo)
        Call CargarUltraGrid(Me.Grid3, LsAtributoEquipo)
        Call CargarUltraGrid(Me.Grid4, Ls_Mantenimiento)

        Tree1.Nodes.Clear()
        LsAtributoEquipo = Nothing
    End Sub
    Private Sub CrearNodosDelPadre(ByVal indicePadre As Integer, ByVal nodePadre As Infragistics.Win.UltraWinTree.UltraTreeNode)

        Dim dataViewHijos As DataView

        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(dataSetArbol.Tables("TablaArbol"))

        dataViewHijos.RowFilter = dataSetArbol.Tables("TablaArbol").Columns("IdentificadorPadre").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.

        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New Infragistics.Win.UltraWinTree.UltraTreeNode
            nuevoNodo.Text = dataRowCurrent("NombreNodo").ToString().Trim()
            'nuevoNodo.Key = dataRowCurrent("IdentificadorNodo").ToString().Trim() & "I" & dataRowCurrent("Item").ToString().Trim()
            nuevoNodo.Tag = dataRowCurrent("Item").ToString().Trim() & dataRowCurrent("Nuevo").ToString().Trim()
            nuevoNodo.DataKey = dataRowCurrent("IdentificadorNodo").ToString().Trim()
            nuevoNodo.LeftImages.Add(My.Resources.parte_equipo)
            If nuevoNodo.Level > Me.Profundidad Then
                Me.Profundidad = nuevoNodo.Level
            End If

            If dataRowCurrent("Nuevo".ToString.Trim) = "N" Then
                Me.NewNode = Me.NewNode + 1
                If TipoG = State.eEdit Then
                    UltraLabel13.Visible = True
                End If
            End If
            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                Tree1.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If

            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            CrearNodosDelPadre(Int32.Parse(dataRowCurrent("IdentificadorNodo").ToString()), nuevoNodo)
        Next dataRowCurrent

    End Sub

#End Region
#Region "Combo"

    Private Sub Evento_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo1.InitializeLayout, Cbo2.InitializeLayout
        With sender.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.TrueString
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With

        If sender.Name = "Cbo1" Then
            Cbo1.DisplayLayout.Bands(0).Columns("Codigo").Width = 60
            Cbo1.DisplayLayout.Bands(0).Columns("Descripcion").Width = sender.Width - 100
        Else
            Cbo2.DisplayLayout.Bands(0).Columns("Codigo").Width = 80
            Cbo2.DisplayLayout.Bands(0).Columns("Descripcion").Width = sender.Width - 100
        End If
    End Sub
    Private Sub Cbo2_RowSelected(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles Cbo2.RowSelected
        If Not (TipoG = State.eNew) = Boolean.TrueString Then Exit Sub
        If e Is Nothing Then Exit Sub
        If Cbo2.ActiveRow Is Nothing Then Exit Sub
        If Cbo2.Rows.Count <= 0 Then Exit Sub
        Call CargarAtributosEquipo_New()
        Call CargarAtributos_ParteEq_Equipo_New()
    End Sub
#End Region
#Region "Grillas"
    Private Sub Grid2_AfterCellActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid2.AfterCellActivate
        Dim sValor1 As String
        Try
            If Grid2.ActiveRow Is Nothing Then Exit Sub
            If IsDBNull(Grid2.ActiveRow.Cells("Valor").Value) Then
                sValor1 = ""
            Else
                sValor1 = Grid2.ActiveRow.Cells("Valor").Value
            End If
            Dim editor As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
            TipoDato = Grid2.ActiveRow.Cells("TipoDato").Value

            Select Case TipoDato
                Case ValorTipoDato.vDate
                    sValor1 = sValor1.Replace("/", "")
                    If Len(sValor1.Trim) > 0 Then
                        sValor1 = sValor1.Insert(2, "/")
                        sValor1 = sValor1.Insert(5, "/")
                    End If
                    Grid2.ActiveRow.Cells("Valor").Value = sValor1
                    editor.InputMask = "{LOC}dd/mm/yyyy"
                    Grid2.ActiveRow.Cells("Valor").EditorControl = editor
                Case ValorTipoDato.vTime
                    sValor1 = sValor1.Replace(":", "")
                    If Len(sValor1.Trim) > 0 Then
                        sValor1 = sValor1.Insert(2, ":")
                    End If

                    Grid2.ActiveRow.Cells("Valor").Value = sValor1
                    editor.InputMask = "{LOC}hh:mm"
                    Grid2.ActiveRow.Cells("Valor").EditorControl = editor
                Case Else
                    Grid2.ActiveRow.Cells("Valor").EditorControl = Nothing
            End Select
            ValorCelda = sValor1
        Catch
            Exit Sub
        End Try
    End Sub
    Private Sub Grid2_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles Grid2.AfterRowUpdate
        Dim sValor1 As String
        Try
            If Grid2.ActiveRow Is Nothing Then Exit Sub
            If IsDBNull(Grid2.ActiveRow.Cells("Valor").Value) Then
                sValor1 = ""
            Else
                sValor1 = Grid2.ActiveRow.Cells("Valor").Value
            End If
            TipoDato = Grid2.ActiveRow.Cells("TipoDato").Value
            Select Case TipoDato
                Case ValorTipoDato.vDate

                    Grid2.ActiveRow.Cells("Valor").EditorControl = Nothing
                    sValor1 = sValor1.Replace("/", "")
                    If Len(sValor1.Trim) > 0 Then
                        sValor1 = sValor1.Insert(2, "/")
                        sValor1 = sValor1.Insert(5, "/")
                    End If

                    Grid2.ActiveRow.Cells("Valor").Value = sValor1
                Case ValorTipoDato.vTime

                    Grid2.ActiveRow.Cells("Valor").EditorControl = Nothing
                    If Len(sValor1.Trim) > 0 Then
                        sValor1 = sValor1.Replace(":", "")
                        sValor1 = sValor1.Insert(2, ":")
                    End If
                    Grid2.ActiveRow.Cells("Valor").Value = sValor1
                Case Else

                    Grid2.ActiveRow.Cells("Valor").EditorControl = Nothing
                    Grid2.ActiveRow.Cells("Valor").Value = sValor1
            End Select
        Catch
            Exit Sub
        End Try
    End Sub
    Private Sub Grid2_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid2.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                    OrElse uColumn.Key = "Valor" OrElse uColumn.Key = "Und") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

        With e.Layout
            .Bands(0).Columns("Valor").CellAppearance.BackColor = Color.White
            .Bands(0).Columns("Valor").CellAppearance.BackColor2 = Color.LightGray
            .Bands(0).Columns("Valor").CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
            .Bands(0).Columns("Valor").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton
        End With
    End Sub
    Private Sub Grid2_AfterExitEditMode(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid2.AfterExitEditMode
        Dim sValor1 As String
        Try
            If Grid2.ActiveRow Is Nothing Then Exit Sub
            If IsDBNull(Grid2.ActiveRow.Cells("Valor").Value) Then
                sValor1 = ""
            Else
                sValor1 = Grid2.ActiveRow.Cells("Valor").Value
            End If
            TipoDato = Grid2.ActiveRow.Cells("TipoDato").Value
            Select Case TipoDato
                Case ValorTipoDato.vDate

                    Grid2.ActiveRow.Cells("Valor").EditorControl = Nothing
                    sValor1 = sValor1.Replace("/", "")
                    If Len(sValor1.Trim) > 0 Then
                        sValor1 = sValor1.Insert(2, "/")
                        sValor1 = sValor1.Insert(5, "/")
                    End If

                    Grid2.ActiveRow.Cells("Valor").Value = sValor1
                Case ValorTipoDato.vTime

                    Grid2.ActiveRow.Cells("Valor").EditorControl = Nothing
                    If Len(sValor1.Trim) > 0 Then
                        sValor1 = sValor1.Replace(":", "")
                        sValor1 = sValor1.Insert(2, ":")
                    End If
                    Grid2.ActiveRow.Cells("Valor").Value = sValor1
                Case Else

                    Grid2.ActiveRow.Cells("Valor").EditorControl = Nothing
                    Grid2.ActiveRow.Cells("Valor").Value = sValor1
            End Select
        Catch
            Exit Sub
        End Try
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

                        '.PerformAction(ExitEditMode, False, False)
                        'e.Handled = True
                        '.PerformAction(NextRow, False, False)
                        '.ActiveRow.Cells("Valor").Activate()
                        '.PerformAction(EnterEditMode, False, False)

                        .PerformAction(ExitEditMode, False, False)
                        e.Handled = True
                        .PerformAction(NextRow, False, False)
                        .ActiveRow.Cells("Valor").Activate()
                        .PerformAction(PrevRow, False, False)
                        .ActiveRow.Cells("Valor").Activate()
                        .PerformAction(EnterEditMode, False, False)
                        '.PerformAction(ExitEditMode, False, False)
                        e.Handled = True
                        .PerformAction(NextRow, False, False)
                        .ActiveRow.Cells("Valor").Activate()
                        .PerformAction(EnterEditMode, False, False)
                End Select
            End With
        Catch
            Exit Sub
        End Try
    End Sub
    Private Sub Grid2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Grid2.KeyPress
        Dim KeyAscii As Integer
        Dim sValor As String
        Dim iLong As Integer
        Dim iLongValor As Integer

        If Grid2.ActiveRow Is Nothing Then Exit Sub
        If Grid2.ActiveRow.Cells("Valor").Activated = Boolean.FalseString Then Exit Sub
        TipoDato = Grid2.ActiveRow.Cells("TipoDato").Value
        sValor = ValorCelda ' Grid2.ActiveRow.Cells("Valor").Value
        iLong = Grid2.ActiveRow.Cells("Longitud").Value
        iLongValor = Len(ValorCelda.Trim) 'Len(Grid2.ActiveRow.Cells("Valor").Value.ToString.Trim)
        KeyAscii = Asc(e.KeyChar)
        Select Case TipoDato
            Case ValorTipoDato.vTexto
                If (Val(iLong) - 1) < Val(iLongValor) Then
                    KeyAscii = 0
                End If
            Case ValorTipoDato.vDecimal
                KeyAscii = ValidarDecimal(Asc(e.KeyChar), ValorCelda)
                If (Val(iLong) - 1) < Val(iLongValor) And KeyAscii <> 8 Then
                    KeyAscii = 0
                End If
            Case ValorTipoDato.vEntero
                KeyAscii = ValidarEntero(Asc(e.KeyChar))
                If (Val(iLong) - 1) < Val(iLongValor) And KeyAscii <> 8 Then
                    KeyAscii = 0
                End If
        End Select
        If KeyAscii = 13 Then
            Grid2.PerformAction(ExitEditMode, False, False)
        Else
            e.KeyChar = Chr(KeyAscii)
        End If

    End Sub
    Private Sub Grid2_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles Grid2.CellChange
        Dim TipoTemp As ValorTipoDato

        If Me.Grid2.ActiveRow Is Nothing Then Exit Sub

        If IsDBNull(e.Cell.Text) Then
            ValorCelda = ""
        Else
            TipoTemp = Grid2.ActiveRow.Cells("TipoDato").Value

            Select Case TipoTemp
                Case ValorTipoDato.vDate
                    If e.Cell.Text.Trim = "" Then
                        ValorCelda = String.Empty
                        e.Cell.Value = String.Empty
                    ElseIf e.Cell.Text.Trim = "__/__/____" Then
                        ValorCelda = String.Empty
                        e.Cell.Value = String.Empty
                        Grid2.ActiveRow.Cells("Valor").EditorControl = Nothing
                    Else
                        ValorCelda = e.Cell.Text
                    End If
                Case ValorTipoDato.vTime
                    If e.Cell.Text.Trim = "" Then
                        ValorCelda = String.Empty
                        e.Cell.Value = String.Empty
                    ElseIf e.Cell.Text.Trim = "__:__" Then
                        ValorCelda = String.Empty
                        e.Cell.Value = String.Empty
                        Grid2.ActiveRow.Cells("Valor").EditorControl = Nothing
                    Else
                        ValorCelda = e.Cell.Text
                    End If
                Case Else
                    If e.Cell.Text.Trim = "" Then
                        ValorCelda = String.Empty
                        e.Cell.Value = String.Empty
                    Else
                        ValorCelda = e.Cell.Text
                    End If
            End Select


            If e.Cell.Value.ToString.Trim = "" And e.Cell.Text.Trim = String.Empty Then
                Grid2.PerformAction(ExitEditMode, False, False)
                Grid2.PerformAction(NextRow, False, False)
            End If
        End If

    End Sub
    Private Sub Grilla_Error(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ErrorEventArgs) Handles Grid2.Error, Grid3.Error
        If e.ErrorType = ErrorType.Data Then
            ' DataErroInfo object contains details regarding the data error.

            ' ErrorText property contains the error message.
            Debug.WriteLine("Data Error: Error text = " & e.DataErrorInfo.ErrorText)

            ' Exception property will contain the exception that caused the Error event to fire.
            ' It will be null if there was no exception.
            If Not Nothing Is e.DataErrorInfo.Exception Then
                Debug.WriteLine("Data Error: Exception type = " & e.DataErrorInfo.Exception.GetType().Name)
            Else
                Debug.WriteLine("Data Error: No Exception.")
            End If

            ' Cell returns the cell involved in the data error. It will be null for errors generated
            ' when performing operations like adding or deleting rows or operations that do not
            ' deal with a cell.
            If Not Nothing Is e.DataErrorInfo.Cell Then
                Debug.WriteLine("DataError: Cell's column key = " & e.DataErrorInfo.Cell.Column.Key)
            Else
                Debug.WriteLine("DataError: No cell.")
            End If

            ' Row returns the row involved in the data error. It will be null if error occurred while
            ' doing an operation that did not involve a row.
            If Not Nothing Is e.DataErrorInfo.Row Then
                Debug.WriteLine("DataError: Index of the row involved = " & e.DataErrorInfo.Row.Index)
            Else
                Debug.WriteLine("DataError: No row.")
            End If

            ' Source property indicates how the data error was generated.
            Debug.Write("DataError: Source of the error is ")
            Select Case (e.DataErrorInfo.Source)
                Case DataErrorSource.CellUpdate
                    If Nothing Is e.DataErrorInfo.InvalidValue Then
                        Debug.WriteLine("Cell updating.")
                    Else
                        Debug.WriteLine("Cell updating with invalid value of " & e.DataErrorInfo.InvalidValue.ToString())
                    End If
                Case DataErrorSource.RowAdd
                    Debug.WriteLine("Row adding.")
                Case DataErrorSource.RowDelete
                    Debug.WriteLine("Row deleting.")
                Case DataErrorSource.RowUpdate
                    Debug.WriteLine("Row updating.")
                Case DataErrorSource.Unspecified
                    Debug.WriteLine("Unknown.")
            End Select

            ' Set the cancel to true to prevent the grid from displaying a message for
            ' this error. Instead we will display our own message box below.
            e.Cancel = True

            'MessageBox.Show(Me, _
            ' "Please enter a valid value for the cell." & vbCrLf & "Data error defatils:" & e.ErrorText, _
            ' "Invalid input", _
            ' MessageBoxButtons.OK, _
            ' MessageBoxIcon.Error)

        ElseIf e.ErrorType = ErrorType.Mask Then
            ' MaskErroInfo property contains the detaisl regarding the mask error.

            ' InvalidText is the text in the cell that doesn't satisfy the mask input.
            Debug.WriteLine("Mask Error: Invalid text = " & e.MaskErrorInfo.InvalidText)

            ' StartPos may indicate the position in the text that caused the mask input
            ' verification failed.
            Debug.WriteLine("Mask Error: Character position = " & e.MaskErrorInfo.StartPos)

            ' Prevent the UltraGrid from beeping whenever the user types in a
            ' character that doesn't match the mask as well as for other mask
            ' related errors.
            e.MaskErrorInfo.CancelBeep = True
        Else
            ' Set the cancel to true to prevent the grid from displaying the message
            ' for this error.
            e.Cancel = True
            Debug.WriteLine("Unknown error occured with the error message of: " & e.ErrorText)
        End If
    End Sub
    Private Sub Grid2_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles Grid2.BeforeCellUpdate

        If e.NewValue Is Nothing Or IsDBNull(e.NewValue) Then
            e = Nothing
        End If
    End Sub
    Private Sub Grid3_AfterCellActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid3.AfterCellActivate
        Dim sValor1 As String
        Try
            If Grid3.ActiveRow Is Nothing Then Exit Sub
            If IsDBNull(Grid3.ActiveRow.Cells("Valor").Value) Then
                sValor1 = ""
            Else
                sValor1 = Grid3.ActiveRow.Cells("Valor").Value
            End If
            Dim editor As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
            TipoDato = Grid3.ActiveRow.Cells("TipoDato").Value

            Select Case TipoDato
                Case ValorTipoDato.vDate
                    sValor1 = sValor1.Replace("/", "")
                    If Len(sValor1.Trim) > 0 Then
                        sValor1 = sValor1.Insert(2, "/")
                        sValor1 = sValor1.Insert(5, "/")
                    End If
                    Grid3.ActiveRow.Cells("Valor").Value = sValor1
                    editor.InputMask = "{LOC}dd/mm/yyyy"
                    Grid3.ActiveRow.Cells("Valor").EditorControl = editor
                Case ValorTipoDato.vTime
                    sValor1 = sValor1.Replace(":", "")
                    If Len(sValor1.Trim) > 0 Then
                        sValor1 = sValor1.Insert(2, ":")
                    End If

                    Grid3.ActiveRow.Cells("Valor").Value = sValor1
                    editor.InputMask = "{LOC}hh:mm"
                    Grid3.ActiveRow.Cells("Valor").EditorControl = editor
                Case Else
                    Grid3.ActiveRow.Cells("Valor").EditorControl = Nothing
            End Select
            ValorCelda = sValor1
        Catch
            Exit Sub
        End Try

    End Sub
    Private Sub Grid3_AfterExitEditMode(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid3.AfterExitEditMode
        Dim sValor1 As String
        Try
            If Grid3.ActiveRow Is Nothing Then Exit Sub
            If IsDBNull(Grid3.ActiveRow.Cells("Valor").Value) Then
                sValor1 = ""
            Else
                sValor1 = Grid3.ActiveRow.Cells("Valor").Value
            End If
            TipoDato = Grid3.ActiveRow.Cells("TipoDato").Value
            Select Case TipoDato
                Case ValorTipoDato.vDate

                    Grid3.ActiveRow.Cells("Valor").EditorControl = Nothing
                    sValor1 = sValor1.Replace("/", "")
                    If Len(sValor1.Trim) > 0 Then
                        sValor1 = sValor1.Insert(2, "/")
                        sValor1 = sValor1.Insert(5, "/")
                    End If

                    Grid3.ActiveRow.Cells("Valor").Value = sValor1
                Case ValorTipoDato.vTime

                    Grid3.ActiveRow.Cells("Valor").EditorControl = Nothing
                    If Len(sValor1.Trim) > 0 Then
                        sValor1 = sValor1.Replace(":", "")
                        sValor1 = sValor1.Insert(2, ":")
                    End If
                    Grid3.ActiveRow.Cells("Valor").Value = sValor1
                Case Else
                    Grid3.ActiveRow.Cells("Valor").EditorControl = Nothing
                    Grid3.ActiveRow.Cells("Valor").Value = sValor1
            End Select
        Catch
            Exit Sub
        End Try

    End Sub
    Private Sub Grid3_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles Grid3.AfterRowUpdate
        Dim sValor1 As String
        Try
            If Grid3.ActiveRow Is Nothing Then Exit Sub
            If IsDBNull(Grid3.ActiveRow.Cells("Valor").Value) Then
                sValor1 = ""
            Else
                sValor1 = Grid3.ActiveRow.Cells("Valor").Value
            End If
            TipoDato = Grid3.ActiveRow.Cells("TipoDato").Value
            Select Case TipoDato
                Case ValorTipoDato.vDate

                    Grid3.ActiveRow.Cells("Valor").EditorControl = Nothing
                    sValor1 = sValor1.Replace("/", "")
                    If Len(sValor1.Trim) > 0 Then
                        sValor1 = sValor1.Insert(2, "/")
                        sValor1 = sValor1.Insert(5, "/")
                    End If

                    Grid3.ActiveRow.Cells("Valor").Value = sValor1
                Case ValorTipoDato.vTime

                    Grid3.ActiveRow.Cells("Valor").EditorControl = Nothing
                    If Len(sValor1.Trim) > 0 Then
                        sValor1 = sValor1.Replace(":", "")
                        sValor1 = sValor1.Insert(2, ":")
                    End If
                    Grid3.ActiveRow.Cells("Valor").Value = sValor1
                Case Else

                    Grid3.ActiveRow.Cells("Valor").EditorControl = Nothing
                    Grid3.ActiveRow.Cells("Valor").Value = sValor1
            End Select
        Catch
            Exit Sub
        End Try
    End Sub
    Private Sub Grid3_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles Grid3.BeforeCellUpdate
        If e.NewValue Is Nothing Or IsDBNull(e.NewValue) Then
            e = Nothing
        End If
    End Sub
    Private Sub Grid3_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles Grid3.CellChange
        Dim TipoTemp As ValorTipoDato

        If Me.Grid3.ActiveRow Is Nothing Then Exit Sub

        If IsDBNull(e.Cell.Text) Then
            ValorCelda = ""
        Else
            TipoTemp = Grid3.ActiveRow.Cells("TipoDato").Value

            Select Case TipoTemp
                Case ValorTipoDato.vDate
                    If e.Cell.Text.Trim = "" Then
                        ValorCelda = String.Empty
                        e.Cell.Value = String.Empty
                    ElseIf e.Cell.Text.Trim = "__/__/____" Then
                        ValorCelda = String.Empty
                        e.Cell.Value = String.Empty
                        Grid3.ActiveRow.Cells("Valor").EditorControl = Nothing
                    Else
                        ValorCelda = e.Cell.Text
                    End If
                Case ValorTipoDato.vTime
                    If e.Cell.Text.Trim = "" Then
                        ValorCelda = String.Empty
                        e.Cell.Value = String.Empty
                    ElseIf e.Cell.Text.Trim = "__:__" Then
                        ValorCelda = String.Empty
                        e.Cell.Value = String.Empty
                        Grid3.ActiveRow.Cells("Valor").EditorControl = Nothing
                    Else
                        ValorCelda = e.Cell.Text
                    End If
                Case Else
                    If e.Cell.Text.Trim = "" Then
                        ValorCelda = String.Empty
                        e.Cell.Value = String.Empty
                    Else
                        ValorCelda = e.Cell.Text
                    End If
            End Select


            If e.Cell.Value.ToString.Trim = "" And e.Cell.Text.Trim = String.Empty Then
                Grid3.PerformAction(ExitEditMode, False, False)
                Grid3.PerformAction(NextRow, False, False)
            End If
        End If
    End Sub
    Private Sub Grid3_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid3.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                    OrElse uColumn.Key = "Valor" OrElse uColumn.Key = "Und") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

        With e.Layout
            .Bands(0).Columns("Valor").CellAppearance.BackColor = Color.White
            .Bands(0).Columns("Valor").CellAppearance.BackColor2 = Color.LightGray
            .Bands(0).Columns("Valor").CellAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
            .Bands(0).Columns("Valor").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton
        End With
    End Sub
    Private Sub Grid3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Grid3.KeyDown
        Try
            Dim f As System.EventArgs = Nothing
            With Grid3
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
                        .ActiveRow.Cells("Valor").Activate()
                        .PerformAction(PrevRow, False, False)
                        .ActiveRow.Cells("Valor").Activate()
                        .PerformAction(EnterEditMode, False, False)
                        '.PerformAction(ExitEditMode, False, False)
                        e.Handled = True
                        .PerformAction(NextRow, False, False)
                        .ActiveRow.Cells("Valor").Activate()
                        .PerformAction(EnterEditMode, False, False)
                End Select
            End With
        Catch
            Exit Sub
        End Try

    End Sub
    Private Sub Grid3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Grid3.KeyPress
        Dim KeyAscii As Integer
        Dim sValor As String
        Dim iLong As Integer
        Dim iLongValor As Integer

        If Grid3.ActiveRow Is Nothing Then Exit Sub
        If Grid3.ActiveRow.Cells("Valor").Activated = Boolean.FalseString Then Exit Sub
        TipoDato = Grid3.ActiveRow.Cells("TipoDato").Value
        sValor = ValorCelda ' Grid2.ActiveRow.Cells("Valor").Value
        iLong = Grid3.ActiveRow.Cells("Longitud").Value
        iLongValor = Len(ValorCelda.Trim) 'Len(Grid2.ActiveRow.Cells("Valor").Value.ToString.Trim)
        KeyAscii = Asc(e.KeyChar)
        Select Case TipoDato
            Case ValorTipoDato.vTexto
                If (Val(iLong) - 1) < Val(iLongValor) Then
                    KeyAscii = 0
                End If
            Case ValorTipoDato.vEntero
                KeyAscii = ValidarEntero(Asc(e.KeyChar))
                If (Val(iLong) - 1) < Val(iLongValor) And KeyAscii <> 8 Then
                    KeyAscii = 0
                End If
        End Select
        If KeyAscii = 13 Then
            Grid3.PerformAction(ExitEditMode, False, False)
        Else
            e.KeyChar = Chr(KeyAscii)
        End If
    End Sub
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                    OrElse uColumn.Key = "LinNeg" OrElse uColumn.Key = "FamiliaEq" _
                    OrElse uColumn.Key = "Estado") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Private Sub Grid4_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid4.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                    OrElse uColumn.Key = "Cod_Presp" OrElse uColumn.Key = "TipoMantto" _
                    OrElse uColumn.Key = "Moneda" OrElse uColumn.Key = "CostoPresup" _
                    OrElse uColumn.Key = "CostoTotal" OrElse uColumn.Key = "FechaInicio" _
                    OrElse uColumn.Key = "FechaTerminacion" OrElse uColumn.Key = "Estado" _
                    OrElse uColumn.Key = "Cod_Presp") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
#End Region
#Region "Arboles"
    Private Sub Tree1_AfterActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinTree.NodeEventArgs) Handles Tree1.AfterActivate
        If NewNode > 0 Then Exit Sub
        Me.LevelNode = e.TreeNode.Level
        Call InicializarPropNodo()
        Me.UltraLabel10.Text = e.TreeNode.Text
        Me.Componente = e.TreeNode.DataKey
        Me.Grid3.Enabled = Boolean.FalseString
        Call CargarAtributosComponente()
        If Me.Grid3.Rows.Count > 0 Then Me.Grid3.Enabled = Boolean.TrueString
    End Sub
#End Region
#Region "Botones"
    Private Sub Btn1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn1.Click
        Ofd1.Filter = "Archivos de imagen(*.JPG)|*.JPG"
        Ofd1.ShowDialog()
        Me.Txt3.Text = Me.Ofd1.FileName
        Try
            Me.Ptb1.Image = Image.FromFile(Me.Txt3.Text.Trim)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        Ofd2.Filter = "Archivos de imagen(*.JPG)|*.JPG"
        Ofd2.ShowDialog()
        Me.Txt4.Text = Me.Ofd2.FileName
        Try
            Me.Ptb2.Image = Image.FromFile(Me.Txt4.Text.Trim)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Boton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click, Btn4.Click

        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Personal
        frmHijo.ShowDialog()
        If sender Is Btn3 Then
            Me.Txt5.Text = frmHijo.Flag2.Trim & " - " & frmHijo.Descripcion
            Me.Responsable = frmHijo.Flag2.Trim
        Else
            Me.Txt6.Text = frmHijo.Flag2.Trim & " - " & frmHijo.Descripcion
            Me.Manipulador = frmHijo.Flag2.Trim
        End If

        frmHijo = Nothing
    End Sub

    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click
        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Catalogo_Activos_Disponible_Enlace
        frmHijo.ID_Input = Me.EquipoID
        frmHijo.ShowDialog()

        Me.Txt7.Text = frmHijo.Flag2.Trim
        Me.CodigoAnterior = frmHijo.Flag2.Trim

        frmHijo = Nothing
    End Sub
#End Region

  



End Class