Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb

Public Class FrmFamiliaProductos
#Region "Declarar Variables"

    Dim _objNegocio_ As NGProducto
    Dim _objEntidad_ As ETProducto

    Dim dtSubFamilia As DataTable
    Dim dtFamilias As DataTable
    Dim dtSubFamilias As DataTable
    Dim dtProductos As DataTable
    Dim ETMaestros2 = New ETMaestos2

    Dim Accion As String
    Dim Opcion As String
    Dim Sec As String

    Dim idSubfamilia As String

#End Region

#Region "FuncionesBasicas"
    Sub CargarProductos()
        'Llenar Combos de Productos
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        _objEntidad_.Tipo = 10
        dtProductos = _objNegocio_.ConsultarProducto(_objEntidad_)
        _objEntidad_.Tipo = 5

        Try
            cboProductos.DisplayMember = "Descripcion"
            cboProductos.ValueMember = "CodProducto"
            cboProductos.DataSource = dtProductos

        Catch ex As Exception
            MsgBox(ex.Message, "Tipo de pago no encontrado")
        End Try


        cboProductos.SelectedValue = 1
    End Sub
    Sub CargarSubfamilias()
        'Llenar Combos de Subfamilias
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto

        _objEntidad_.Accion = "R"
        _objEntidad_.SubFamilia = "0"
        dtSubFamilia = _objNegocio_.ConsultarSubfamilia(_objEntidad_)

        Try
            cboSubFamilias.DisplayMember = "subfamilia"
            cboSubFamilias.ValueMember = "idsubfamilia"
            cboSubFamilias.DataSource = dtSubFamilia

        Catch ex As Exception
            MsgBox(ex.Message, "Motivos no encontrados")
        End Try

    End Sub

    Sub Cargarfamilias()
        'Llenar Combos de Subfamilias
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto

        _objEntidad_.Accion = "R"
        _objEntidad_.SubFamilia = "0"
        dtSubFamilia = _objNegocio_.Consultarfamilia(_objEntidad_)

        Try
            cboFamilia.DisplayMember = "descrip"
            cboFamilia.ValueMember = "idFamilia"
            cboFamilia.DataSource = dtSubFamilia

        Catch ex As Exception
            MsgBox(ex.Message, "Motivos no encontrados")
        End Try

    End Sub

    Function ValidarSubFamilia() As Boolean

        If cboFamilia.Text = "" And txtSubFamilia.Text = "" Then
            ValidarSubFamilia = False
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical)
        Else
            ValidarSubFamilia = True
        End If

    End Function

    Function ValidarProductoSubFamilia() As Boolean

        If cboProductos.Text = "" Or cboSubFamilias.Text = "" Then
            ValidarProductoSubFamilia = False
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical)
        Else
            ValidarProductoSubFamilia = True
        End If

    End Function
    Function ValidarFamilia() As Boolean

        If txtFamilia.Text = "" Then
            ValidarFamilia = False
            MsgBox("Debe completar todos los campos", MsgBoxStyle.Critical)
        Else
            ValidarFamilia = True
        End If

    End Function


    Sub cargarDtg(ByVal Tipo As String)
        'Cargar Grilla
        Dim dtDatos As DataTable
        Dim dtDatosSF As DataTable
        Dim dtDatosF As DataTable
        dtDatos = New DataTable
        dtDatosSF = New DataTable
        dtDatosF = New DataTable

        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto

        Accion = "R"

        _objEntidad_.Accion = Accion

        If Tipo = "P" Then
            dtDatos = _objNegocio_.ConsultarFamiliaProductoFamilia(_objEntidad_)
            Call CargarUltraGridxBinding(grdProductos, Source1, dtDatos)
        ElseIf Tipo = "S" Then
            dtDatosSF = _objNegocio_.ConsultarSubfamilia(_objEntidad_)
            Call CargarUltraGridxBinding(grdSubFamilia, Source2, dtDatosSF)
        ElseIf Tipo = "F" Then
            dtDatosF = _objNegocio_.Consultarfamilia(_objEntidad_)
            Call CargarUltraGridxBinding(grdFamilia, Source3, dtDatosF)
        End If

    End Sub

#End Region

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Private Sub FrmFamiliaProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        idSubfamilia = ""

        CargarProductos()
        Cargarfamilias()
        CargarSubfamilias()
        cargarDtg("P")
    End Sub


    Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click

        Accion = "C"

        pnlRegistrar.Visible = True
        grdProductos.Enabled = False

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        grdProductos.Enabled = True
        cboSubFamilias.Enabled = True

        pnlRegistrar.Visible = False


    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        If ValidarProductoSubFamilia() = False Then Exit Sub
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto

        _objEntidad_.Accion = Accion
        _objEntidad_.SubFamilia = cboSubFamilias.SelectedValue
        _objEntidad_.CodProducto = cboProductos.SelectedValue
        _objEntidad_.Estado = ""
        _objEntidad_.Usuario = User_Sistema
        _objEntidad_.Fecha = Now

        _objNegocio_.ConsultarFamiliaProductoFamilia(_objEntidad_)

        cargarDtg("P")

        pnlRegistrar.Visible = False
        grdProductos.Enabled = True

        pnlRegistrar.Visible = False
    End Sub

    Private Sub grdProductos_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdProductos.DoubleClickRow
        Dim uRow As UltraGridRow
        uRow = e.Row

        Accion = "U"

        cboProductos.SelectedValue = uRow.Cells("cod_prod").Value.ToString()
        cboSubFamilias.SelectedValue = uRow.Cells("idsubfamilia").Value.ToString()

        txtCodProd.Enabled = False
        cboProductos.Enabled = False

        pnlRegistrar.Visible = True
        grdProductos.Enabled = False
    End Sub

    Private Sub txtCodProd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodProd.KeyPress
        If e.KeyChar = Chr(13) Then
            Try
                cboProductos.SelectedValue = txtCodProd.Text
            Catch ex As Exception
                MsgBox("Producto no existe", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub cboProductos_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProductos.SelectedValueChanged
        Try
            txtCodProd.Text = cboProductos.SelectedValue
        Catch ex As Exception
            MsgBox("Producto no existe", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged
        If Tab1.Tabs(0).Selected = True Then
            cargarDtg("P")
            CargarSubfamilias()
        ElseIf Tab1.Tabs(1).Selected = True Then
            cargarDtg("S")
            Cargarfamilias()
        ElseIf Tab1.Tabs(2).Selected = True Then
            cargarDtg("F")
        End If
    End Sub

    Private Sub btnCancelarSubFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarSubFamilia.Click
        grdSubFamilia.Enabled = True
        cboSubFamilias.Enabled = True

        PnlRegistrarSubFamilia.Visible = False
    End Sub

    Private Sub btnGrabarSubFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarSubFamilia.Click

        If ValidarSubFamilia() = False Then Exit Sub
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto

        _objEntidad_.Accion = Accion
        _objEntidad_.Familia = cboFamilia.SelectedValue
        _objEntidad_.SubFamilia = idSubfamilia
        _objEntidad_.Descripcion = txtSubFamilia.Text
        _objEntidad_.Estado = ""
        _objEntidad_.Usuario = User_Sistema
        _objEntidad_.Fecha = Now

        _objNegocio_.ConsultarSubfamilia(_objEntidad_)

        cargarDtg("S")

        grdSubFamilia.Enabled = True

        PnlRegistrarSubFamilia.Visible = False
    End Sub

    Private Sub btnAdicionarSubFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarSubFamilia.Click
        Accion = "C"

        PnlRegistrarSubFamilia.Visible = True
        grdSubFamilia.Enabled = False
    End Sub

    Private Sub grdSubFamilia_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdSubFamilia.DoubleClickRow
        Dim uRow As UltraGridRow
        uRow = e.Row

        Accion = "U"

        idSubfamilia = uRow.Cells("idsubfamilia").Value.ToString()
        txtSubFamilia.Text = uRow.Cells("subfamilia").Value.ToString()
        cboFamilia.SelectedValue = uRow.Cells("idfamilia").Value.ToString()

        PnlRegistrarSubFamilia.Visible = True
        grdSubFamilia.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        grdFamilia.Enabled = True
        cboFamilia.Enabled = True

        pnlRegistrarFamilia.Visible = False

    End Sub

    Private Sub btnGrabarFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarFamilia.Click
        If ValidarFamilia() = False Then Exit Sub
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto

        _objEntidad_.Accion = Accion
        _objEntidad_.Familia = txtidFamilia.Text
        _objEntidad_.Descripcion = txtFamilia.Text
        _objEntidad_.Estado = ""
        _objEntidad_.Usuario = User_Sistema
        _objEntidad_.Fecha = Now

        _objNegocio_.Consultarfamilia(_objEntidad_)

        cargarDtg("F")

        grdFamilia.Enabled = True

        pnlRegistrarFamilia.Visible = False



    End Sub

    Private Sub grdFamilia_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdFamilia.DoubleClickRow
        Dim uRow As UltraGridRow
        uRow = e.Row

        Accion = "U"

        txtidFamilia.Text = uRow.Cells("idFamilia").Value.ToString()
        txtFamilia.Text = uRow.Cells("descrip").Value.ToString()

        pnlRegistrarFamilia.Visible = True
        grdFamilia.Enabled = False

    End Sub

    Private Sub btnAdicionarFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarFamilia.Click
        Accion = "C"

        pnlRegistrarFamilia.Visible = True
        grdFamilia.Enabled = False
    End Sub

    Private Sub grdSubFamilia_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdSubFamilia.InitializeLayout

    End Sub
End Class