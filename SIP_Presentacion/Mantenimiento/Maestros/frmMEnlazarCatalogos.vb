Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmMEnlazarCatalogos
    Public Ls_Permisos As New List(Of Integer)

    Private Enum FormularioMantto
        fEnlazarComponente_SubComponente = 65
        fEnlazarAtributosComponentes = 66
        fEnlazarAtributosFamiliaEquipo = 68
        fEnlazarFamiliaEquipoComponente = 69
    End Enum

    Private CatalogoMantto As FormularioMantto

    Private Sub frmMEnlazarCatalogos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub frmMEnlazarAtributos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargarDatosFormulario()
        Call Iniciar()
    End Sub
    Private Ls_ParteEq As List(Of ETParteEquipo) = Nothing
    Private Ls_SubParteEq As List(Of ETParteEquipo) = Nothing
    Private Ls_Atributo As List(Of ETAtributo) = Nothing
    Private Ls_FamiliaEq As List(Of ETFamiliaEquipo) = Nothing
    Private Ls_FamiliaEq_Comp As List(Of ETParteEquipo) = Nothing
    Private _IDCatalogo As Long = 0
    Private _Status As String = String.Empty
    Private _IDSubCatalogo As Long = 0
    Private _Resultado As Long = 0

#Region "Propiedades"
    Private Property IDCatalogo() As Long
        Get
            Return _IDCatalogo
        End Get
        Set(ByVal value As Long)
            _IDCatalogo = value
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
    Private Property IDSubCatalogo() As Long
        Get
            Return _IDSubCatalogo
        End Get
        Set(ByVal value As Long)
            _IDSubCatalogo = value
        End Set
    End Property
    Public Property Resultado() As Long
        Get
            Return _Resultado
        End Get
        Set(ByVal value As Long)
            _Resultado = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Private Sub CargarDatosFormulario()

        CatalogoMantto = Mid(Me.Tag, 2, 2)
        Me.Grid2.Top = 89
        Me.Grid2.Height = 374
        Select Case CatalogoMantto
            Case FormularioMantto.fEnlazarComponente_SubComponente
                Me.UltraLabel1.Text = "COMPONENTES"
                Me.UltraLabel2.Text = "SUBCOMPONENTES"
                Me.UltraGroupBox1.Text = "ENLAZAR SUB COMPONENTES"
                Me.Grid2.DisplayLayout.Bands(0).Columns("Oblig").Hidden = True
                Me.Grid2.DisplayLayout.Bands(0).Columns("Control").Hidden = True
                Me.Grid2.DisplayLayout.Bands(0).Columns("NomEq").Hidden = True
                Me.Grid2.DisplayLayout.Bands(0).Columns("Interno").Hidden = False
                Me.Grid2.DisplayLayout.Bands(0).Columns("Descripcion").Width = 264

            Case FormularioMantto.fEnlazarAtributosComponentes
                Me.UltraLabel1.Text = "COMPONENTES"
                Me.Grid2.DisplayLayout.Bands(0).Columns("Control").Hidden = True
                Me.Grid2.DisplayLayout.Bands(0).Columns("NomEq").Hidden = True
                Me.Grid2.DisplayLayout.Bands(0).Columns("Descripcion").Width = 264
            Case FormularioMantto.fEnlazarAtributosFamiliaEquipo
                Me.UltraLabel1.Text = "FAMILIA DE EQUIPOS"
                Me.Grid2.DisplayLayout.Bands(0).Columns("Oblig").Hidden = True
                Me.Grid2.DisplayLayout.Bands(0).Columns("Control").Hidden = True
                Me.Grid2.DisplayLayout.Bands(0).Columns("NomEq").Hidden = True
                Me.Grid2.DisplayLayout.Bands(0).Columns("Descripcion").Width = 230
            Case FormularioMantto.fEnlazarFamiliaEquipoComponente
                Me.UltraLabel1.Text = "FAMILIA DE EQUIPOS"
                Me.UltraLabel2.Text = "COMPONENTES"
                Me.UltraGroupBox1.Text = "ENLAZAR COMPONENTES"
                Me.Grid2.DisplayLayout.Bands(0).Columns("Oblig").Hidden = True
                Me.Grid2.DisplayLayout.Bands(0).Columns("Control").Hidden = True
                Me.Grid2.DisplayLayout.Bands(0).Columns("NomEq").Hidden = True
                Me.Grid2.DisplayLayout.Bands(0).Columns("Interno").Hidden = True
                Me.Grid2.DisplayLayout.Bands(0).Columns("Descripcion").Width = 264
                Me.Grid2.Top = 333
                Me.Grid2.Height = 130
                Me.Grid3.Visible = Boolean.TrueString
                Me.Btn1.Visible = Boolean.TrueString
        End Select
    End Sub
    Private Sub Iniciar()
        Select Case CatalogoMantto
            Case FormularioMantto.fEnlazarComponente_SubComponente
                Call Iniciar_Componente_SubComponente()
            Case FormularioMantto.fEnlazarAtributosComponentes
                Call Iniciar_Atributo_Componente()
            Case FormularioMantto.fEnlazarAtributosFamiliaEquipo
                Call Iniciar_Atributo_FamiliaEquipo()
            Case FormularioMantto.fEnlazarFamiliaEquipoComponente
                Call Iniciar_FamiliaEquipo_Componente()
                Call Iniciar_Familia_Componente()
        End Select
    End Sub

    Private Sub Iniciar_Familia_Componente()
        Dim ObjPartEq As New ETParteEquipo
        Negocio.ParteEquipo = New NGParteEquipo
        Entidad.MyLista = New ETMyLista

        Ls_ParteEq = New List(Of ETParteEquipo)
        ObjPartEq.CompOrigen = 0
        ObjPartEq.Tipo = 6
        Entidad.MyLista = Negocio.ParteEquipo.ConsultarParteEquipo(ObjPartEq)

        If Entidad.MyLista.Validacion Then
            Ls_ParteEq = Entidad.MyLista.Ls_ParteEquipo
        End If

        Call CargarUltraGrid(Grid3, Ls_ParteEq)
    End Sub

    Private Sub Iniciar_Componente_SubComponente()
        Dim ObjPartEq As New ETParteEquipo
        Negocio.ParteEquipo = New NGParteEquipo
        Entidad.MyLista = New ETMyLista

        Ls_ParteEq = New List(Of ETParteEquipo)
        ObjPartEq.CompOrigen = 0
        ObjPartEq.Tipo = 6
        Entidad.MyLista = Negocio.ParteEquipo.ConsultarParteEquipo(ObjPartEq)

        If Entidad.MyLista.Validacion Then
            Ls_ParteEq = Entidad.MyLista.Ls_ParteEquipo
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_ParteEq)

        Ls_SubParteEq = New List(Of ETParteEquipo)
        Call CargarUltraGrid(Grid2, Ls_SubParteEq)
    End Sub
    Private Sub Iniciar_Atributo_Componente()
        Call Iniciar_Componente_SubComponente()
        Ls_Atributo = New List(Of ETAtributo)
        Call CargarUltraGrid(Grid2, Ls_Atributo)
    End Sub
    Private Sub Iniciar_Atributo_FamiliaEquipo()
        Dim ObjFamiliaEq As New ETFamiliaEquipo
        Negocio.FamiliaEquipo = New NGFamiliaEquipo
        Entidad.MyLista = New ETMyLista

        Ls_FamiliaEq = New List(Of ETFamiliaEquipo)
        ObjFamiliaEq.Tipo = 5
        Entidad.MyLista = Negocio.FamiliaEquipo.ConsultarFamiliaEquipo_Enlazar()

        If Entidad.MyLista.Validacion Then
            Ls_FamiliaEq = Entidad.MyLista.Ls_FamiliaEquipo
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_FamiliaEq)
        Ls_Atributo = New List(Of ETAtributo)
        Call CargarUltraGrid(Grid2, Ls_Atributo)
    End Sub
    Private Sub Iniciar_FamiliaEquipo_Componente()
        Call Iniciar_Atributo_FamiliaEquipo()
        Ls_FamiliaEq_Comp = New List(Of ETParteEquipo)
        Call CargarUltraGrid(Grid2, Ls_FamiliaEq_Comp)
    End Sub

    Private Sub Cargar_Componente_SubComponente()
        Dim ObjPartEq As New ETParteEquipo
        Negocio.ParteEquipo = New NGParteEquipo
        Entidad.MyLista = New ETMyLista

        Ls_SubParteEq = New List(Of ETParteEquipo)
        ObjPartEq.CompOrigen = 0
        ObjPartEq.IDCatalogo = Me.IDCatalogo
        ObjPartEq.Tipo = 7
        Entidad.MyLista = Negocio.ParteEquipo.ConsultarParteEquipo(ObjPartEq)

        If Entidad.MyLista.Validacion Then
            Ls_SubParteEq = Entidad.MyLista.Ls_SubParteEquipo
        End If

        Call CargarUltraGrid(Grid2, Ls_SubParteEq)
    End Sub
    Private Sub Cargar_Atributo_Componente()
        Dim ObjAtributo As New ETAtributo
        Negocio.Atributo = New NGAtributo
        Entidad.MyLista = New ETMyLista

        Ls_Atributo = New List(Of ETAtributo)
        ObjAtributo.IDCatalogoOrigen = Me.IDCatalogo
        ObjAtributo.Tipo = 2
        Entidad.MyLista = Negocio.Atributo.ConsultarAtributoParteEquipo(ObjAtributo)

        If Entidad.MyLista.Validacion Then
            Ls_Atributo = Entidad.MyLista.Ls_Atributo
        End If

        Call CargarUltraGrid(Grid2, Ls_Atributo)
    End Sub
    Private Sub Cargar_Atributo_FamiliaEquipo()
        Dim ObjAtributo As New ETAtributo
        Negocio.Atributo = New NGAtributo
        Entidad.MyLista = New ETMyLista

        Ls_Atributo = New List(Of ETAtributo)
        ObjAtributo.IDCatalogoOrigen = Me.IDCatalogo
        ObjAtributo.Tipo = 2
        Entidad.MyLista = Negocio.Atributo.ConsultarAtributoFamiliaEquipo(ObjAtributo)

        If Entidad.MyLista.Validacion Then
            Ls_Atributo = Entidad.MyLista.Ls_Atributo
        End If

        Call CargarUltraGrid(Grid2, Ls_Atributo)
    End Sub
    Private Sub Cargar_FamiliaEquipo_Componente()
        Dim ObjParteEq As New ETParteEquipo
        Negocio.ParteEquipo = New NGParteEquipo
        Entidad.MyLista = New ETMyLista

        Ls_FamiliaEq_Comp = New List(Of ETParteEquipo)
        ObjParteEq.IDCatalogoOrigen = Me.IDCatalogo
        ObjParteEq.Tipo = 2
        Entidad.MyLista = Negocio.ParteEquipo.Consultar_FamiliaEq_ParteEquipo(ObjParteEq)

        If Entidad.MyLista.Validacion Then
            Ls_FamiliaEq_Comp = Entidad.MyLista.Ls_ParteEquipo
        End If

        Call CargarUltraGrid(Grid2, Ls_FamiliaEq_Comp)
    End Sub
    Private Sub Grabar_Componente_SubComponente()
        Dim Ls_SubParteEqTemp As List(Of ETParteEquipo) = Nothing

        Ls_SubParteEqTemp = New List(Of ETParteEquipo)
        For Each xRow As UltraGridRow In Grid2.Rows
            Entidad.SubParteEquipo = New ETParteEquipo
            With Entidad.SubParteEquipo
                If xRow.Cells("Action").Value = Boolean.TrueString Then
                    .Status = ""
                Else
                    .Status = "*"
                End If
                .CompOrigen = Me.IDCatalogo
                .IDCatalogo = xRow.Cells("IDCatalogo").Value
                .Tipo = 8
                .Usuario = User_Sistema
            End With
            If xRow.Cells("Action").Value = Boolean.TrueString Then
                If Negocio.ParteEquipo.Validar_Circularidad_SubComponente(Entidad.SubParteEquipo) = True Then
                    MsgBox("El SubComponente: " & xRow.Cells("Codigo").Value & " - " & xRow.Cells("Descripcion").Value & Chr(13) & "Genera circularidad")
                    Exit Sub
                End If
            End If

            Ls_SubParteEqTemp.Add(Entidad.SubParteEquipo)
        Next

        Negocio.ParteEquipo = New NGParteEquipo

        Try
            Me.Resultado = Negocio.ParteEquipo.Mantto_SubParteEquipo(Ls_SubParteEqTemp)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub Grabar_Atributo_Componente()
        Dim Ls_AtributoTemp As List(Of ETAtributo) = Nothing

        Ls_AtributoTemp = New List(Of ETAtributo)
        For Each xRow As UltraGridRow In Grid2.Rows
            Entidad.AtribParteEquipo = New ETAtributo
            With Entidad.AtribParteEquipo
                If xRow.Cells("Action").Value = Boolean.TrueString Then
                    .Status = ""
                Else
                    .Status = "*"
                End If
                .IDCatalogoOrigen = Me.IDCatalogo
                .IDCatalogo = xRow.Cells("IDCatalogo").Value
                .Oblig = xRow.Cells("Oblig").Value
                .Tipo = 1
                .Usuario = User_Sistema
            End With
            Ls_AtributoTemp.Add(Entidad.AtribParteEquipo)
        Next

        Negocio.Atributo = New NGAtributo

        Try
            Me.Resultado = Negocio.Atributo.Mantto_AtributoParteEquipo(Ls_AtributoTemp)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Grabar_Atributo_FamiliaEquipo()
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim Orden1 As Integer = 0
        Dim Orden2 As Integer = 0
        Dim Er1 As Integer = 0
        Dim Er2 As Integer = 0
        Dim Ls_AtributoTemp As List(Of ETAtributo) = Nothing

        Ls_AtributoTemp = New List(Of ETAtributo)


        For i = 0 To Grid2.Rows.Count - 2
            If Grid2.Rows(i).Cells("Action").Value = Boolean.TrueString Then
                If Grid2.Rows(i).Cells("NomEq").Value = Boolean.TrueString Then
                    Orden1 = Grid2.Rows(i).Cells("Orden").Value
                    If Orden1 > 0 Then
                        For j = i + 1 To Grid2.Rows.Count - 1
                            If Grid2.Rows(j).Cells("Action").Value = Boolean.TrueString Then
                                If Grid2.Rows(j).Cells("NomEq").Value = Boolean.TrueString Then
                                    Orden2 = Grid2.Rows(j).Cells("Orden").Value
                                    If Orden2 > 0 Then
                                        If Orden1 = Orden2 Then
                                            MsgBox("El Orden de la concatenación del nombre del Equipo debe ser único", MsgBoxStyle.Critical, msgComacsa)
                                            Exit Sub
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    ElseIf Orden1 < 0 Then
                        MsgBox("El Orden de la concatenación del nombre del Equipo debe ser mayor a cero", MsgBoxStyle.Critical, msgComacsa)
                        Exit Sub
                    End If
                End If
            End If
        Next

        For Each xRow As UltraGridRow In Grid2.Rows
            Entidad.AtribFamiliaEquipo = New ETAtributo
            With Entidad.AtribFamiliaEquipo
                If xRow.Cells("Action").Value = Boolean.TrueString Then
                    .Status = ""
                Else
                    .Status = "*"
                End If
                .IDCatalogoOrigen = Me.IDCatalogo
                .IDCatalogo = xRow.Cells("IDCatalogo").Value
                .Oblig = xRow.Cells("Oblig").Value
                .Control = xRow.Cells("Control").Value
                .NomEq = xRow.Cells("NomEq").Value
                If xRow.Cells("NomEq").Value = True Then
                    .Orden = xRow.Cells("Orden").Value
                End If
                .Tipo = 1
                .Usuario = User_Sistema
            End With
            Ls_AtributoTemp.Add(Entidad.AtribFamiliaEquipo)
        Next

        Negocio.Atributo = New NGAtributo

        Try
            Me.Resultado = Negocio.Atributo.Mantto_AtributoFamiliaEquipo(Ls_AtributoTemp)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Grabar_FamiliaEquipo_Componente()
        Dim Ls_ParteEqTemp As List(Of ETParteEquipo) = Nothing

        Ls_ParteEqTemp = New List(Of ETParteEquipo)
        For Each xRow As UltraGridRow In Grid2.Rows
            Entidad.FamiliaParteEquipo = New ETParteEquipo
            With Entidad.FamiliaParteEquipo
                .IDCatalogoOrigen = Me.IDCatalogo
                .IDCatalogo = xRow.Cells("IDCatalogo").Value
                .Item = xRow.Cells("Item").Value
                .Interno = xRow.Cells("Interno").Value
                If xRow.Cells("Action").Value = Boolean.TrueString Then
                    .Status = ""
                Else
                    .Status = "*"
                End If
                .Usuario = User_Sistema
                .Tipo = 1

            End With
            Ls_ParteEqTemp.Add(Entidad.FamiliaParteEquipo)
        Next

        Negocio.ParteEquipo = New NGParteEquipo

        Try
            Me.Resultado = Negocio.ParteEquipo.Mantto_FamiliaEq_ParteEquipo(Ls_ParteEqTemp)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "Grillas"

    Private Sub Grid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid1.Click
        If Grid1.Rows.Count <= 0 Then Exit Sub
        If IsDBNull(Me.Grid1.ActiveRow.Cells("IDCatalogo").Value) = Boolean.TrueString Then Exit Sub

        Me.IDCatalogo = Me.Grid1.ActiveRow.Cells("IDCatalogo").Value

        Select Case CatalogoMantto
            Case FormularioMantto.fEnlazarComponente_SubComponente
                Call Cargar_Componente_SubComponente()
            Case FormularioMantto.fEnlazarAtributosComponentes
                Call Cargar_Atributo_Componente()
            Case FormularioMantto.fEnlazarAtributosFamiliaEquipo
                Call Cargar_Atributo_FamiliaEquipo()
            Case FormularioMantto.fEnlazarFamiliaEquipoComponente
                Ls_FamiliaEq_Comp = Nothing
                Call Cargar_FamiliaEquipo_Componente()
        End Select
        Me.Grid2.Enabled = Boolean.FalseString
    End Sub

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion") Then
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
            If Not (uColumn.Key = "Action" OrElse uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next

        Select Case CatalogoMantto
            Case FormularioMantto.fEnlazarAtributosComponentes
                Me.Grid2.DisplayLayout.Bands(0).Columns("Oblig").Hidden = Boolean.FalseString
            Case FormularioMantto.fEnlazarAtributosFamiliaEquipo
                Me.Grid2.DisplayLayout.Bands(0).Columns("Oblig").Hidden = Boolean.FalseString
                Me.Grid2.DisplayLayout.Bands(0).Columns("Control").Hidden = Boolean.FalseString
                Me.Grid2.DisplayLayout.Bands(0).Columns("NomEq").Hidden = Boolean.FalseString
                Me.Grid2.DisplayLayout.Bands(0).Columns("Orden").Hidden = Boolean.FalseString
            Case FormularioMantto.fEnlazarFamiliaEquipoComponente
                Me.Grid2.DisplayLayout.Bands(0).Columns("Interno").Hidden = Boolean.FalseString
        End Select


    End Sub
#End Region
#Region "Procedimientos Publicas"
    Public Sub Modificar()
        If Me.IDCatalogo = 0 Then
            MsgBox("Seleccione un " & Me.UltraLabel1.Text.Trim, MsgBoxStyle.Information, "COMACSA")
            Exit Sub
        End If

        Me.Grid2.Enabled = Boolean.TrueString
        Me.Grid3.Enabled = Boolean.TrueString
        Me.Btn1.Enabled = Boolean.TrueString
    End Sub
    Public Sub Grabar()
        If Grid2.Rows.Count <= 0 Then Exit Sub
        If Grid2.Enabled = False Then Exit Sub
        Grid2.UpdateData()

        If Me.IDCatalogo = 0 Then Exit Sub

        Select Case CatalogoMantto
            Case FormularioMantto.fEnlazarComponente_SubComponente
                Call Grabar_Componente_SubComponente()
                Call Cargar_Componente_SubComponente()
            Case FormularioMantto.fEnlazarAtributosComponentes
                Call Grabar_Atributo_Componente()
                Call Cargar_Atributo_Componente()
            Case FormularioMantto.fEnlazarAtributosFamiliaEquipo
                Call Grabar_Atributo_FamiliaEquipo()
                Call Cargar_Atributo_FamiliaEquipo()
            Case FormularioMantto.fEnlazarFamiliaEquipoComponente
                Call Grabar_FamiliaEquipo_Componente()
                Ls_FamiliaEq_Comp = Nothing
                Call Cargar_FamiliaEquipo_Componente()
        End Select
        Me.Grid2.Enabled = Boolean.FalseString
        Me.Grid3.Enabled = Boolean.FalseString
        Me.Btn1.Enabled = Boolean.FalseString
    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Iniciar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
#End Region

    Private Sub Grid3_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid3.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Action" OrElse uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        For Each xRow As UltraGridRow In Grid3.Rows
            If xRow.Cells("Action").Value = Boolean.TrueString Then
                Entidad.FamiliaParteEquipo = New ETParteEquipo
                With Entidad.FamiliaParteEquipo
                    If xRow.Cells("Action").Value = Boolean.TrueString Then
                        .Status = ""
                    Else
                        .Status = "*"
                    End If
                    .Action = xRow.Cells("Action").Value
                    .Codigo = xRow.Cells("Codigo").Value
                    .Descripcion = xRow.Cells("Descripcion").Value
                    .IDCatalogoOrigen = Me.IDCatalogo
                    .IDCatalogo = xRow.Cells("IDCatalogo").Value
                    .Interno = xRow.Cells("Interno").Value
                    .Tipo = 1
                    .Usuario = User_Sistema
                End With
                Ls_FamiliaEq_Comp.Add(Entidad.FamiliaParteEquipo)
            End If
        Next

        Call CargarUltraGrid(Grid2, Ls_FamiliaEq_Comp)
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
                        If CatalogoMantto = FormularioMantto.fEnlazarAtributosFamiliaEquipo Then
                            .ActiveRow.Cells("Orden").Activate()
                            .PerformAction(PrevRow, False, False)
                            .ActiveRow.Cells("Orden").Activate()
                            .PerformAction(EnterEditMode, False, False)
                            '.PerformAction(ExitEditMode, False, False)
                            e.Handled = True
                            .PerformAction(NextRow, False, False)
                            .ActiveRow.Cells("Orden").Activate()
                        End If
                        .PerformAction(EnterEditMode, False, False)
                End Select
            End With
        Catch
            Exit Sub
        End Try
    End Sub
End Class