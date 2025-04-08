
Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmMCatalogosMantto
#Region "Definicion de Variables"
    Public Ls_Permisos As New List(Of Integer)

    Private Enum FormularioMantto
        fLineaNegocio = 62
        fAtributos = 63
        fParteEquipo = 64
    End Enum
    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum

    Private CatalogoMantto As FormularioMantto
    Private TipoG As sTate
    Private Ls_LinNeg As List(Of ETLineaNegocio) = Nothing
    Private Ls_Atrib As List(Of ETAtributo) = Nothing
    Private Ls_ParteEq As List(Of ETParteEquipo) = Nothing
    Private Ls_SubParteEq As List(Of ETParteEquipo) = Nothing

    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Status As String = String.Empty
    Private _IDCompOrigen As Long = 0
    Private _IDCatalogo As Long = 0
    Private _Resultado As Long = 0

    Private Ls_Combo1 As List(Of ETUnidadMedida) = Nothing
#End Region
#Region "Propiedades"
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Public Property CompOrigen() As Long
        Get
            Return _IDCompOrigen
        End Get
        Set(ByVal value As Long)
            _IDCompOrigen = value
        End Set
    End Property
    Public Property IDCatalogo() As Long
        Get
            Return _IDCatalogo
        End Get
        Set(ByVal value As Long)
            _IDCatalogo = value
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
#Region "Form"

    Private Sub frmMCatalogosMantto_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub frmMCatalogosMantto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TipoG = sTate.eView
        Call CargarDatosFormulario()
        Call Iniciar()
        Call CargarCombos()
    End Sub
#End Region

#Region "Procedimiento Privados"
    Private Sub InicializarValores()
        _Codigo = String.Empty
        _Descripcion = String.Empty
        _Status = String.Empty
        _IDCatalogo = 0
        _Resultado = 0
        _IDCompOrigen = 0
    End Sub
    Private Sub CargarDatosFormulario()
        CatalogoMantto = Mid(Me.Tag, 2, 2)

        Select Case CatalogoMantto
            Case FormularioMantto.fLineaNegocio
                Me.Tab1.Tabs("T01").Text = "LINEA DE NEGOCIO"
                Me.UltraLabel3.Visible = False
                Me.UltraLabel4.Visible = False
                Me.UltraLabel5.Visible = False
                Me.UltraLabel6.Visible = False
                Me.Cbo1.Visible = False
                Me.Cbo2.Visible = False
                Me.Txt1.MaxLength = 4
                Me.Txt2.MaxLength = 50
                Me.Txt3.Visible = False
                Me.Txt4.Visible = False
                Me.UltraLabel7.Location = Me.UltraLabel3.Location
                Me.Cbo3.Location = Me.Cbo1.Location
                Me.UltraGroupBox1.Height = 170

            Case FormularioMantto.fAtributos
                Me.Tab1.Tabs("T01").Text = "ATRIBUTOS"
                Me.Txt1.MaxLength = 8
                Me.Txt2.MaxLength = 100
            Case FormularioMantto.fParteEquipo
                Me.Tab1.Tabs("T01").Text = "COMPONENTES"
                Me.Tab1.Tabs("T03").Visible = Boolean.TrueString
                UltraLabel3.Text = "Componente Origen:"
                Me.UltraLabel3.Visible = False
                Me.UltraLabel4.Visible = False
                Me.UltraLabel5.Visible = False
                Me.UltraLabel6.Visible = False
                Me.Cbo1.Visible = False
                Me.Cbo2.Visible = False
                Me.Txt1.MaxLength = 8
                Me.Txt2.MaxLength = 100
                Me.Txt3.Visible = False
                Me.Txt4.Visible = False
                Cbo1.Size = Me.Txt2.Size
                Me.UltraLabel7.Location = Me.UltraLabel3.Location
                Me.Cbo3.Location = Me.Cbo1.Location
                Me.UltraGroupBox1.Height = 170
        End Select
        Me.UltraGroupBox1.Text = Me.Tab1.Tabs("T01").Text
    End Sub
    Private Sub Grabar_LinNeg()
        Dim ObjLinNeg As New ETLineaNegocio
        Negocio.LineaNegocio = New NGLineaNegocio

        ObjLinNeg.Cod_Cia = Companhia
        ObjLinNeg.Codigo = Me.Txt1.Text.Trim
        ObjLinNeg.Descripcion = Me.Txt2.Text.Trim
        ObjLinNeg.Estado = IIf(Me.Cbo3.Value = "K01", "", "*")
        ObjLinNeg.Tipo = TipoG
        ObjLinNeg.Usuario = User_Sistema
        ObjLinNeg.IDCatalogo = Me.IDCatalogo

        Try

            Me.Resultado = Negocio.LineaNegocio.Mantto_LineaNegocio(ObjLinNeg)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Grabar_Atributo()
        Dim ObjAtrib As New ETAtributo
        Negocio.Atributo = New NGAtributo
        ObjAtrib.Codigo = Me.Txt1.Text.Trim
        ObjAtrib.Descripcion = Me.Txt2.Text.Trim
        ObjAtrib.UniMed = Me.Cbo1.Value.ToString
        ObjAtrib.TipoDato = Mid(Me.Cbo2.Value, 2, 1)
        ObjAtrib.Longitud = Me.Txt3.Text.Trim
        ObjAtrib.Decimales = Me.Txt4.Text.Trim
        ObjAtrib.Status = IIf(Me.Cbo3.Value = "K01", "", "*")
        ObjAtrib.Tipo = TipoG
        ObjAtrib.Usuario = User_Sistema
        ObjAtrib.IDCatalogo = Me.IDCatalogo
        Try

            Me.Resultado = Negocio.Atributo.Mantto_Atributo(ObjAtrib)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Grabar_ParteEquipo()
        Dim ObjParteEq As New ETParteEquipo
        Negocio.ParteEquipo = New NGParteEquipo

        ObjParteEq.Codigo = IIf(Me.Txt1.Text.Trim <> "", Me.Txt1.Text, "0")
        ObjParteEq.Descripcion = Me.Txt2.Text.Trim
        ObjParteEq.Estado = IIf(Me.Cbo3.Value = "K01", "", "*")
        ObjParteEq.Tipo = TipoG
        ObjParteEq.Usuario = User_Sistema
        ObjParteEq.CompOrigen = Me.CompOrigen
        ObjParteEq.IDCatalogo = Me.IDCatalogo

        Try

            Me.Resultado = Negocio.ParteEquipo.Mantto_ParteEquipo(ObjParteEq)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub HabilitarControles(ByVal D As Boolean)
        Me.Txt1.ReadOnly = Not D
        Me.Txt2.ReadOnly = Not D
        Me.Cbo3.ReadOnly = True
        Select Case CatalogoMantto
            Case FormularioMantto.fAtributos
                Me.Txt1.ReadOnly = Boolean.TrueString
                Me.Txt3.ReadOnly = Not D
                Me.Txt4.ReadOnly = Not D
                Me.Cbo1.ReadOnly = Not D
                Me.Cbo2.ReadOnly = Not D
            Case FormularioMantto.fParteEquipo
                Me.Txt1.ReadOnly = Boolean.TrueString
        End Select
    End Sub

    Private Sub LimpiarDatos()
        Dim Ls_SubParteEqTemp As List(Of ETParteEquipo) = Nothing
        Me.Txt1.Clear()
        Me.Txt2.Clear()
        Me.Cbo3.Value = "K01"
        Select Case CatalogoMantto
            Case FormularioMantto.fLineaNegocio
                Me.Txt1.Focus()
            Case FormularioMantto.fAtributos
                Me.Txt3.Clear()
                Me.Txt4.Text = "0"
                Me.Cbo1.Value = "00"
                Me.Cbo2.Value = "K1"
            Case FormularioMantto.fParteEquipo
                Me.Txt5.Clear()
                Call CargarUltraGrid(Grid2, Ls_SubParteEqTemp)
        End Select
        Call InicializarValores()

    End Sub
    Sub Iniciar()
        TipoG = sTate.eView
        Me.Tab1.Tabs("T01").Selected = Boolean.TrueString
        Select Case CatalogoMantto
            Case FormularioMantto.fLineaNegocio
                Call Iniciar_LinNeg()
            Case FormularioMantto.fAtributos
                Call Iniciar_Atributo()
            Case FormularioMantto.fParteEquipo
                Call Iniciar_ParteEquipo()
        End Select
    End Sub
    Sub Iniciar_LinNeg()

        Negocio.LineaNegocio = New NGLineaNegocio
        Entidad.MyLista = New ETMyLista

        Ls_LinNeg = New List(Of ETLineaNegocio)

        Entidad.MyLista = Negocio.LineaNegocio.ConsultarLineaNegocio

        If Entidad.MyLista.Validacion Then
            Ls_LinNeg = Entidad.MyLista.Ls_LinNeg
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_LinNeg)

    End Sub
    Sub Iniciar_Atributo()
        Negocio.Atributo = New NGAtributo
        Entidad.MyLista = New ETMyLista

        Ls_Atrib = New List(Of ETAtributo)

        Entidad.MyLista = Negocio.Atributo.ConsultarAtributo

        If Entidad.MyLista.Validacion Then
            Ls_Atrib = Entidad.MyLista.Ls_Atributo
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Atrib)
    End Sub
    Sub Iniciar_ParteEquipo()
        Dim ObjPartEq As New ETParteEquipo
        Negocio.ParteEquipo = New NGParteEquipo
        Entidad.MyLista = New ETMyLista

        Ls_ParteEq = New List(Of ETParteEquipo)
        ObjPartEq.CompOrigen = 0
        ObjPartEq.Tipo = TipoG
        Entidad.MyLista = Negocio.ParteEquipo.ConsultarParteEquipo(ObjPartEq)

        If Entidad.MyLista.Validacion Then
            Ls_ParteEq = Entidad.MyLista.Ls_ParteEquipo
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_ParteEq)
    End Sub

    Sub Cargar_SubParteEquipo(ByVal EntParteEquipo As ETParteEquipo)
        Negocio.ParteEquipo = New NGParteEquipo
        Entidad.MyLista = New ETMyLista

        Ls_SubParteEq = New List(Of ETParteEquipo)
        Entidad.MyLista = Negocio.ParteEquipo.ConsultarParteEquipo(EntParteEquipo)

        If Entidad.MyLista.Validacion Then
            Ls_SubParteEq = Entidad.MyLista.Ls_SubParteEquipo
        End If

        Call CargarUltraGrid(Grid2, Ls_SubParteEq)

    End Sub

    Sub Modificar_LinNeg()
        Me.Txt1.ReadOnly = Boolean.TrueString
        Me.Cbo3.ReadOnly = Boolean.TrueString
        Me.Txt2.ReadOnly = Boolean.FalseString
        Me.Codigo = Me.Grid1.ActiveRow.Cells("Codigo").Value
        Me.Descripcion = Me.Grid1.ActiveRow.Cells("Descripcion").Value
        Me.Status = Me.Grid1.ActiveRow.Cells("Status").Value.ToString.Trim
        Me.IDCatalogo = Me.Grid1.ActiveRow.Cells("IDCatalogo").Value
        Me.Txt1.Text = Me.Codigo
        Me.Txt2.Text = Me.Descripcion
        If Me.Status = "*" Then
            Me.Cbo3.Value = "K02"
        Else
            Me.Cbo3.Value = "K01"
        End If
        Me.Txt2.Focus()
    End Sub
    Sub Modificar_Atributo()
        Me.Txt1.ReadOnly = Boolean.TrueString
        Me.Cbo3.ReadOnly = Boolean.TrueString
        Me.Txt2.ReadOnly = Boolean.FalseString

        Me.IDCatalogo = Me.Grid1.ActiveRow.Cells("IDCatalogo").Value
        Me.Txt1.Text = Me.Grid1.ActiveRow.Cells("Codigo").Value
        Me.Txt2.Text = Me.Grid1.ActiveRow.Cells("Descripcion").Value
        Me.Cbo1.Value = Me.Grid1.ActiveRow.Cells("UniMed").Value
        Me.Cbo2.Value = Me.Grid1.ActiveRow.Cells("TipoDato").Value
        Me.Txt3.Text = Me.Grid1.ActiveRow.Cells("Longitud").Value
        Me.Txt4.Text = Me.Grid1.ActiveRow.Cells("Decimales").Value
        Me.Status = Me.Grid1.ActiveRow.Cells("Status").Value

        If Me.Status = "*" Then
            Me.Cbo3.Value = "K02"
        Else
            Me.Cbo3.Value = "K01"
        End If
        Me.Txt2.Focus()
    End Sub
    Sub Modificar_ParteEquipo()
        Dim ObjParteEq As New ETParteEquipo


        Me.Txt1.ReadOnly = Boolean.TrueString
        Me.Cbo3.ReadOnly = Boolean.TrueString
        Me.Txt2.ReadOnly = Boolean.FalseString
        Me.Codigo = Me.Grid1.ActiveRow.Cells("Codigo").Value
        Me.Descripcion = Me.Grid1.ActiveRow.Cells("Descripcion").Value
        Me.Status = Me.Grid1.ActiveRow.Cells("Status").Value.ToString.Trim
        Me.CompOrigen = Me.Grid1.ActiveRow.Cells("CompOrigen").Value
        Me.IDCatalogo = Me.Grid1.ActiveRow.Cells("IDCatalogo").Value

        If Me.CompOrigen > 0 Then
            Txt5.Text = Me.Grid1.ActiveRow.Cells("CodCompOrigen").Value & " - " & Me.Grid1.ActiveRow.Cells("Componente").Value
        End If
        ObjParteEq.Tipo = 5
        ObjParteEq.CompOrigen = Me.CompOrigen
        ObjParteEq.IDCatalogo = Me.IDCatalogo
        Call Cargar_SubParteEquipo(ObjParteEq)

        Me.Txt1.Text = Me.Codigo
        Me.Txt2.Text = Me.Descripcion
        If Me.Status = "*" Then
            Me.Cbo3.Value = "K02"
        Else
            Me.Cbo3.Value = "K01"
        End If
        Me.Txt2.Focus()
    End Sub
    Sub Eliminar_LinNeg()
        Dim ObjLinNeg As New ETLineaNegocio
        Negocio.LineaNegocio = New NGLineaNegocio

        ObjLinNeg.Cod_Cia = Companhia
        ObjLinNeg.Codigo = Me.Codigo
        ObjLinNeg.Descripcion = Me.Txt2.Text.Trim
        ObjLinNeg.Estado = IIf(Me.Cbo3.Value = "K01", "", "*")
        ObjLinNeg.Tipo = TipoG
        ObjLinNeg.Usuario = User_Sistema

        ObjLinNeg.IDCatalogo = Me.IDCatalogo
        Try

            Me.Resultado = Negocio.LineaNegocio.Mantto_LineaNegocio(ObjLinNeg)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Eliminar_Atributo()
        Dim ObjAtrib As New ETAtributo
        Negocio.Atributo = New NGAtributo

        ObjAtrib.Codigo = Me.Codigo
        ObjAtrib.Descripcion = Me.Txt2.Text.Trim
        ObjAtrib.Estado = IIf(Me.Cbo3.Value = "K01", "", "*")
        ObjAtrib.Tipo = TipoG
        ObjAtrib.Usuario = User_Sistema
        ObjAtrib.IDCatalogo = Me.IDCatalogo
        ObjAtrib.Longitud = 0
        ObjAtrib.Decimales = 0
        Try

            Me.Resultado = Negocio.Atributo.Mantto_Atributo(ObjAtrib)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Eliminar_ParteEquipo()
        Dim ObjParteEq As New ETParteEquipo
        Negocio.ParteEquipo = New NGParteEquipo

        ObjParteEq.Codigo = Me.Codigo
        ObjParteEq.Descripcion = Me.Txt2.Text.Trim
        ObjParteEq.Estado = IIf(Me.Cbo3.Value = "K01", "", "*")
        ObjParteEq.Tipo = TipoG
        ObjParteEq.Usuario = User_Sistema
        ObjParteEq.IDCatalogo = Me.IDCatalogo
        Try

            Me.Resultado = Negocio.ParteEquipo.Mantto_ParteEquipo(ObjParteEq)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CargarCombos_Atributo()

        Negocio.UnidadMedida = New NGUnidadMedida
        Entidad.MyLista = New ETMyLista

        Ls_Combo1 = New List(Of ETUnidadMedida)

        Entidad.MyLista = Negocio.UnidadMedida.ConsultarUnidadMedida

        If Entidad.MyLista.Validacion Then
            Ls_Combo1 = Entidad.MyLista.Ls_UnidadMedida
        End If

        Call CargarUltraCombo(Me.Cbo1, Ls_Combo1, "Codigo", "Descripcion", String.Empty)

    End Sub

    Private Sub CargarCombos()
        Select Case CatalogoMantto
            Case FormularioMantto.fAtributos
                Call CargarCombos_Atributo()
        End Select
    End Sub
#End Region
#Region "Procedimientos Publicos"
    Public Sub Nuevo()
        Call HabilitarControles(True)
        Call LimpiarDatos()
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Me.Txt1.Focus()
        TipoG = sTate.eNew
    End Sub

    Public Sub Grabar()
        If Tab1.Tabs("T02").Selected = Boolean.FalseString Then Exit Sub
        If TipoG = sTate.eDel Or TipoG = sTate.eView Then Exit Sub

        If Cbo3.Value = "K02" Then
            Call Iniciar()
            Exit Sub
        End If

        Me.Resultado = 0
        Select Case CatalogoMantto
            Case FormularioMantto.fLineaNegocio
                Call Grabar_LinNeg()
            Case FormularioMantto.fAtributos
                Call Grabar_Atributo()
            Case FormularioMantto.fParteEquipo
                Call Grabar_ParteEquipo()
        End Select

        If Me.Resultado <> 0 Then
            Call Iniciar()
            Call HabilitarControles(False)
            TipoG = sTate.eView
        End If

    End Sub

    Public Sub Modificar()
        If Me.Grid1.Rows.Count <= 0 Then Exit Sub
        Call LimpiarDatos()
        TipoG = sTate.eEdit
        Me.Tab1.Tabs("T02").Selected = Boolean.TrueString
        Select Case CatalogoMantto
            Case FormularioMantto.fLineaNegocio
                Call Modificar_LinNeg()
            Case FormularioMantto.fAtributos
                Call Modificar_Atributo()
            Case FormularioMantto.fParteEquipo
                Call Modificar_ParteEquipo()
        End Select

        If Me.Status = "*" Then Call HabilitarControles(False)
    End Sub
    Public Sub Eliminar()
        If Me.Grid1.Rows.Count <= 0 Then Exit Sub
        If Me.Tab1.Tabs("T01").Selected = Boolean.FalseString Then Exit Sub
        TipoG = sTate.eDel
        Me.Resultado = 0
        Me.IDCatalogo = Me.Grid1.ActiveRow.Cells("IDCatalogo").Value
        Me.Codigo = Me.Grid1.ActiveRow.Cells("Codigo").Value
        Select Case CatalogoMantto
            Case FormularioMantto.fLineaNegocio
                Call Eliminar_LinNeg()
            Case FormularioMantto.fAtributos
                Call Eliminar_Atributo()
            Case FormularioMantto.fParteEquipo
                Call Eliminar_ParteEquipo()
        End Select
        If Me.Resultado <> 0 Then Call Iniciar()
        TipoG = sTate.eView
    End Sub
    Public Sub Cancelar()
        If Me.Tab1.Tabs("T02").Selected = Boolean.TrueString Then
            Me.Tab1.Tabs("T01").Selected = Boolean.TrueString
            Call LimpiarDatos()
            TipoG = sTate.eView
            Call Iniciar()
        End If
    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Iniciar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
#End Region

#Region "Grillas"
    Private Sub Evento_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout

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
#End Region
#Region "Editor de Texto"
    Private Sub Txt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.Txt2.Focus()
        End If
    End Sub

    Private Sub Txt2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If CatalogoMantto = FormularioMantto.fLineaNegocio Then
                Me.Cbo3.Focus()
            End If
        End If

    End Sub

    Private Sub Txt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt3.KeyPress, Txt4.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii <> 13 Then
            KeyAscii = ValidarEntero(KeyAscii)
            e.KeyChar = Chr(KeyAscii)
        End If
    End Sub

#End Region

#Region "Combos"
    Private Sub Cbo1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo1.InitializeLayout
        With sender.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.TrueString
            .Columns("Descripcion").Width = sender.Width
            .Columns("Abrev").Width = CInt(sender.Width / 2)
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "Descripcion" OrElse uColumn.Key = "Abrev") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next

        End With
    End Sub

    Private Sub Cbo2_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo2.SelectionChanged
        If sender.VALUE <> "K3" Then
            If sender.Value = "K4" Or sender.Value = "K5" Then
                Me.Txt3.Text = "0"
                Me.Txt3.ReadOnly = Boolean.TrueString
            Else
                Txt3.ReadOnly = Boolean.FalseString
            End If
            Me.Txt4.Text = "0"
            Me.Txt4.ReadOnly = Boolean.TrueString
        Else
            Me.Txt4.ReadOnly = Boolean.FalseString
        End If
    End Sub

#End Region


End Class