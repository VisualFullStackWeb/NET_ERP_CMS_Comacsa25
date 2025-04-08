Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmRangosAprobacion

    '   ***** LISTAS    *****
    Dim LstFirmaCodigo As New List(Of ETLstFirmaMonto)
    Dim Firma As ETLstFirmaMonto

    Dim RangoAprobacion As New List(Of ETAprobacionFirmaMonto)
    Dim Rango As ETAprobacionFirmaMonto

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Load"
    Private Sub FrmRangosAprobacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        TabRangoAprobacion.Tabs("Consulta").Selected = True
        Call CargarUsuarios()
        Call CargarTabla()
    End Sub
#End Region                '   Load

#Region "Funciones Locales"

#Region "Cargar Usuarios"
    Private Sub CargarUsuarios()
        With Entidad.Usuario
            .Cod_Cia = Companhia
        End With

        UltraComboEditor3.DataSource = Negocio.Usuario.UsersFirma(Entidad.Usuario, "8")
        UltraComboEditor3.DisplayMember = "Usuario"
        UltraComboEditor3.ValueMember = "Login"
        UltraComboEditor3.SelectedIndex = 0

        CmbUsuario.DataSource = Negocio.Usuario.UsersFirma(Entidad.Usuario, "8")
        CmbUsuario.DisplayMember = "Usuario"
        CmbUsuario.ValueMember = "Login"
        CmbUsuario.SelectedIndex = 0

    End Sub
#End Region

#Region "Cargar Tabla"
    Private Sub CargarTabla()
        Dim ds As New DataSet

        Dim dx As New DataTable
        Dim dz As New DataTable

        With Entidad.AprobacionFirmaMonto
            .Cod_Cia = Companhia
        End With



        dx = Negocio.AprobacionFirmaMontoBL.ListarRangoAprobacion(Entidad.AprobacionFirmaMonto, "LIS")
        dz = Negocio.AprobacionFirmaMontoBL.ListarFirmaMonto(Entidad.AprobacionFirmaMonto, "LIS")


        dx.TableName = "PADRE"
        dz.TableName = "HIJO"

        ds.Tables.Add(dx)
        ds.Tables.Add(dz)


        Dim RangoAprobacion As DataColumn = ds.Tables("PADRE").Columns("Codigo")
        Dim FirmaMonto As DataColumn = ds.Tables("HIJO").Columns("Codigo")

        ' Create DataRelation.
        Dim Rango_Firma As DataRelation
        Rango_Firma = New DataRelation("CustomersOrders", RangoAprobacion, FirmaMonto)

        ' Add the relation to the DataSet.
        ds.Relations.Add(Rango_Firma)

        DgvRangoAprobacion.DataSource = ds

    End Sub
#End Region

#Region "Listar Firmas x Codigo Aprobacion"
    Private Sub ListarFirmaCodigo()
        Dim dtFirmaCodigo As New DataTable
        With Entidad.AprobacionFirmaMonto
            .CodigoAprobacion = Trim(CodigoAprobacion.Text & "")
            .Cod_Cia = Companhia
        End With
        dtFirmaCodigo = Negocio.AprobacionFirmaMontoBL.ListarFirmaMonto(Entidad.AprobacionFirmaMonto, "LxC")
        If dtFirmaCodigo.Rows.Count > 0 Then
            dgvFirmaUsuario.DataSource = dtFirmaCodigo
            dgvFirmaUsuario.Refresh()
        End If
    End Sub
#End Region

#Region "Efectos - DgvRangoAprobacion"

    Private Sub EfectosDgvRangoAprobacion()

        '   *****   Bands (0)
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns.Add("Codigo")
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("Codigo").Hidden = True

        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns.Add("Moneda")
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("Moneda").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("Moneda").EditorControl = CboMoneda
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("Moneda").Width = 60
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("Moneda").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("Moneda").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle

        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns.Add("TotalDesde")
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("TotalDesde").Width = 250
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("TotalDesde").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("TotalDesde").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("TotalDesde").CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("TotalDesde").CellAppearance.FontData.SizeInPoints = 8

        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns.Add("Signo")
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("Signo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("Signo").EditorControl = CboSigno
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("Signo").Width = 60
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("Signo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("Signo").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle

        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns.Add("TotalHasta")
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("TotalHasta").Width = 250
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("TotalHasta").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("TotalHasta").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("TotalHasta").CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False
        DgvRangoAprobacion.DisplayLayout.Bands(0).Columns("TotalHasta").CellAppearance.FontData.SizeInPoints = 8

        '   *****   Bands   (1)
        DgvRangoAprobacion.DisplayLayout.Bands(1).Columns.Add("Codigo")
        DgvRangoAprobacion.DisplayLayout.Bands(1).Columns("Codigo").Hidden = True

        DgvRangoAprobacion.DisplayLayout.Bands(1).Columns.Add("Usuario")
        DgvRangoAprobacion.DisplayLayout.Bands(1).Columns("Usuario").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        DgvRangoAprobacion.DisplayLayout.Bands(1).Columns("Usuario").EditorControl = CmbUsuario
        DgvRangoAprobacion.DisplayLayout.Bands(1).Columns("Usuario").Width = 180
        DgvRangoAprobacion.DisplayLayout.Bands(1).Columns("Usuario").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        DgvRangoAprobacion.DisplayLayout.Bands(1).Columns("Usuario").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle

        DgvRangoAprobacion.DisplayLayout.Bands(1).Columns.Add("Firma")
        DgvRangoAprobacion.DisplayLayout.Bands(1).Columns("Firma").Width = 55
        DgvRangoAprobacion.DisplayLayout.Bands(1).Columns("Firma").CellAppearance.FontData.SizeInPoints = 8
        DgvRangoAprobacion.DisplayLayout.Bands(1).Columns("Firma").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

    End Sub
#End Region

#Region "Efectos - DgvFirmaUsuario"
    Public Sub EfectodgvFirmaUsuario()
        dgvFirmaUsuario.DisplayLayout.Bands(0).Columns.Add("Usuario")
        dgvFirmaUsuario.DisplayLayout.Bands(0).Columns("Usuario").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        dgvFirmaUsuario.DisplayLayout.Bands(0).Columns("Usuario").EditorControl = CmbUsuario
        dgvFirmaUsuario.DisplayLayout.Bands(0).Columns("Usuario").Width = 180
        dgvFirmaUsuario.DisplayLayout.Bands(0).Columns("Usuario").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        dgvFirmaUsuario.DisplayLayout.Bands(0).Columns("Usuario").CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle

        dgvFirmaUsuario.DisplayLayout.Bands(0).Columns.Add("Firma")
        dgvFirmaUsuario.DisplayLayout.Bands(0).Columns("Firma").Width = 60
        dgvFirmaUsuario.DisplayLayout.Bands(0).Columns("Firma").CellAppearance.FontData.SizeInPoints = 8
        dgvFirmaUsuario.DisplayLayout.Bands(0).Columns("Firma").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

    End Sub
#End Region

#Region "Validar"
    Private Function Validar() As Boolean
        If Not dgvFirmaUsuario.Rows.Count > 0 Then
            MsgBox("No hay detalle para GUARDAR. Al terminar de hacer el registro, presione la tecla ENTER.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        Return True
    End Function
#End Region

#End Region   '   Funciones Locales

#Region "Funciones Publicas"

#Region "Grabar"
    Public Sub Grabar()
        Dim NumeroAprobacion As Integer
        TxtDesde.Focus()
        If Validar() = False Then Return

        If MsgBox("¿Esta Seguro de GRABAR el Rango de Aprobación. ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
            With Entidad.AprobacionFirmaMonto
                .Cod_Cia = Companhia
                .Moneda = CboMoneda.Value
                .TotalDesde = TxtDesde.Value
                .Signo = CboSigno.Value
                .TotalHasta = TxtHasta.Value
                .User_crea = User_Sistema
                If CodigoAprobacion.Text <> "" Then
                    .CodigoAprobacion = Trim(CodigoAprobacion.Text & "")
                Else
                    .CodigoAprobacion = 0
                End If
            End With

            For j As Integer = 0 To dgvFirmaUsuario.Rows.Count - 1
                Rango = New ETAprobacionFirmaMonto
                With Rango
                    .Cod_Cia = Companhia
                    .CodigoAprobacion = NumeroAprobacion
                    .Firma = dgvFirmaUsuario.Rows(j).Cells("Firma").Value
                    .Usuario = dgvFirmaUsuario.Rows(j).Cells("Usuario").Value
                    .User_crea = User_Sistema
                End With
                RangoAprobacion.Add(Rango)
            Next

            If CodigoAprobacion.Text = "" Then
                Entidad.Resultado = Negocio.AprobacionFirmaMontoBL.GrabarRangoAprobacion(Entidad.AprobacionFirmaMonto, RangoAprobacion, "AGR")
            Else
                Entidad.Resultado = Negocio.AprobacionFirmaMontoBL.GrabarRangoAprobacion(Entidad.AprobacionFirmaMonto, RangoAprobacion, "MOD")
            End If

            If Entidad.Resultado.Realizo = True Then
                MsgBox("Se guardó con exito los registros.", MsgBoxStyle.Information, "Comacsa")
            End If

            RangoAprobacion = New List(Of ETAprobacionFirmaMonto)
            TabRangoAprobacion.Tabs("Consulta").Selected = True
            Call CargarTabla()
        End If
    End Sub
#End Region

#Region "Nuevo"
    Public Sub Nuevo()
        Dim dtFirmaCodigo As New DataTable
        With Entidad.AprobacionFirmaMonto
            .Cod_Cia = Companhia
            .CodigoAprobacion = 0
        End With
        dtFirmaCodigo = Negocio.AprobacionFirmaMontoBL.ListarFirmaMonto(Entidad.AprobacionFirmaMonto, "LxC")

        TabRangoAprobacion.Tabs("Registrar").Selected = True
        TxtDesde.Value = 0
        TxtHasta.Value = 0
        CboMoneda.SelectedIndex = -1
        CboSigno.SelectedIndex = -1
        CodigoAprobacion.Clear()

        dgvFirmaUsuario.DataSource = dtFirmaCodigo

    End Sub
#End Region

#Region "Eliminar"
    Public Sub Eliminar()
        If TabRangoAprobacion.Tabs("Consulta").Selected = True Then
            If MsgBox("¿Esta Seguro de ELIMINAR el Rango de Aprobación. ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
                With Entidad.AprobacionFirmaMonto
                    .Cod_Cia = Companhia
                    .CodigoAprobacion = DgvRangoAprobacion.ActiveRow.Cells("Codigo").Value
                    .User_crea = User_Sistema
                End With
                Entidad.Resultado = Negocio.AprobacionFirmaMontoBL.RangoAprobacionEliminar(Entidad.AprobacionFirmaMonto)

                If Entidad.Resultado.Realizo = True Then
                    MsgBox("Se ELIMINÓ con éxito el Rango de Aprobación.", MsgBoxStyle.Information, "Comacsa")
                End If
                Call CargarTabla()
            End If
        End If
    End Sub
#End Region

#End Region  '   Funciones Publicas

#Region "Evento Controles"

#Region "TabRangoAprobacion - SelectedTabChanged"
    Private Sub TabRangoAprobacion_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles TabRangoAprobacion.SelectedTabChanged
        If TabRangoAprobacion.Tabs("Consulta").Selected = True Then
            TabRangoAprobacion.Tabs("Registrar").Enabled = False
        Else
            TabRangoAprobacion.Tabs("Registrar").Enabled = True
        End If
    End Sub
#End Region

#Region "DgvRangoAprobacion - DoubleClickRow"
    Private Sub DgvRangoAprobacion_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvRangoAprobacion.DoubleClickRow
        If Not e.Row.HasChild Then
            Return
        End If

        TabRangoAprobacion.Tabs("Registrar").Selected = True
        CodigoAprobacion.Text = Trim(DgvRangoAprobacion.ActiveRow.Cells("Codigo").Value & "")
        CboMoneda.Value = Trim(DgvRangoAprobacion.ActiveRow.Cells("Moneda").Value & "")
        CboSigno.Value = Trim(DgvRangoAprobacion.ActiveRow.Cells("Signo").Value & "")
        TxtDesde.Value = Trim(DgvRangoAprobacion.ActiveRow.Cells("TotalDesde").Value & "")
        TxtHasta.Value = Trim(DgvRangoAprobacion.ActiveRow.Cells("TotalHasta").Value & "")
        Call ListarFirmaCodigo()

    End Sub
#End Region

#End Region    '   Evento Controles

End Class