Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmTrabajadoresArea
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private TipoG As sTate
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_EntregaDetalle As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
#End Region
    Private Sub FrmTrabajadoresArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call HabilitarControles(True)
        Call CargarDatos()
        Call CargarAreas()
    End Sub

    Private Sub CargarDatos()
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.TipoOperacion = Ope
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Ls_EntregaDetalle = Nothing
        Ls_EntregaDetalle = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarTrabajadoresArea()
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.GridTrabajadoresArea, Source1, Ls_Entrega)
    End Sub


    Private Sub TxtCodigoTrabajador_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoTrabajador.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If TxtCodigoTrabajador.Text.ToString.Trim = "" Then
            TxtCodigoTrabajador.Focus()
            Exit Sub
        End If
        CargarTrabajadoresxCodigo(Me.TxtCodigoTrabajador.Text)
        If lResult.Ls_Entrega.Count > 0 Then
            TxtNombresTrabajador.Text = lResult.Ls_Entrega.Item(0).NomTrabajador

            cmbArea.ReadOnly = False
            cmbArea.Focus()
        Else
            MsgBox("Código de trabajador no existe", MsgBoxStyle.Exclamation, msgComacsa)
            TxtCodigoTrabajador.Clear()
            TxtNombresTrabajador.Clear()
            TxtCodigoTrabajador.Focus()
        End If
    End Sub

    Private Sub CargarTrabajadoresxCodigo(ByVal codTrabajador As String)
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Rpt.CodTrabajador = codTrabajador
        Entidad.MyLista = Negocio.NEntregas.ListarTrabajadorxCodigo(Rpt)
        lResult = New ETMyLista
        lResult = Entidad.MyLista
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
    End Sub

    'Sub buscar()
    '    If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
    '    If TxtCodigoTrabajador.ReadOnly = True Then Return
    '    Dim FRM As New FrmListadoPersonal
    '    FRM.ShowDialog()
    '    If codTrabajador.ToString.Trim = "" Then Return
    '    TxtCodigoTrabajador.Text = codTrabajador.ToString.Trim
    '    TxtNombresTrabajador.Text = nomTrabajador.ToString.Trim
    '    cmbArea.ReadOnly = False
    '    cmbArea.Focus()
    'End Sub

    Private Sub CargarAreas()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarAreas
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraCombo(cmbArea, Ls_Entrega, "codArea", "Area")
    End Sub

    Private Sub HabilitarControles(ByVal D As Boolean)
        Me.TxtCodigoTrabajador.ReadOnly = D
        Me.cmbArea.ReadOnly = D
        Me.Chkesjefe.Enabled = Not D
        Me.TxtCodigoTrabajador.Focus()
    End Sub

    Sub nuevo()
        'Call LimpiarDatos()
        'Ope = 1
        'TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        'Call HabilitarControles(False)
    End Sub

    Private Sub cmbArea_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbArea.InitializeLayout
        With cmbArea.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("Area").Width = 300
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "Area") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub cmbArea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbArea.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        txtarea.Text = cmbArea.Text.ToString
    End Sub

    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try
            If sender.readonly = True Then Return
            txtarea.Text = cmbArea.Text.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridTrabajadoresArea_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridTrabajadoresArea.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot GridTrabajadoresArea Then Return
        If e.Row.IsFilterRow Then Return
        SubProceso_TrabajadorArea(e.Row)
    End Sub

    Sub SubProceso_TrabajadorArea(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If
        Call LimpiarDatos()
        Ope = 2
        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Call HabilitarControles(True)
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.MyLista = New ETMyLista
        TxtCodigoTrabajador.Text = uRow.Cells("CodTrabajador").Value.ToString.Trim
        TxtNombresTrabajador.Text = uRow.Cells("NomTrabajador").Value.ToString.Trim
        txtdni.Text = uRow.Cells("dni").Value.ToString.Trim
        txttelefono.Text = uRow.Cells("telefono").Value.ToString.Trim
        txtemail.Text = uRow.Cells("Email").Value.ToString.Trim
        cmbArea.Value = uRow.Cells("codArea").Value.ToString.Trim
        txtarea.Text = cmbArea.Text
        txtCodigoJefe.Text = uRow.Cells("CodJefe").Value.ToString.Trim
        txtNomJefe.Text = uRow.Cells("NomJefe").Value.ToString.Trim
        Chkesjefe.Checked = False

        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        modificar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Private Sub GridTrabajadoresArea_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridTrabajadoresArea.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "CodTrabajador" OrElse uColumn.Key = "NomTrabajador" OrElse _
                    uColumn.Key = "NomJefe" OrElse uColumn.Key = "Area" OrElse uColumn.Key = "Areabd" OrElse uColumn.Key = "Cargo" OrElse uColumn.Key = "telefono" OrElse uColumn.Key = "Email" OrElse uColumn.Key = "dni") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Sub modificar()
        cmbArea.ReadOnly = False
        Chkesjefe.Enabled = True
        cmbArea.Focus()
    End Sub

    Sub cancelar()
        Call HabilitarControles(True)
        Call LimpiarDatos()
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
    End Sub

    Sub actualizar()
        Call HabilitarControles(True)
        Call LimpiarDatos()
        Call CargarDatos()
        Call CargarAreas()
        TabMaestroEntregas.Tabs("Lista").Selected = Boolean.TrueString
    End Sub

    Sub LimpiarDatos()
        TxtCodigoTrabajador.Clear()
        TxtNombresTrabajador.Clear()
        txtdni.Clear()
        txttelefono.Clear()
        txtemail.Clear()
        Chkesjefe.Checked = False
        cmbArea.Value = 0
        Ep1.Clear()
        Ope = 0
    End Sub

    Sub grabar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If Not Verificar_Datos() Then
            MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.Entregas.CodTrabajador = IIf(TxtCodigoTrabajador.Value Is Nothing, String.Empty, TxtCodigoTrabajador.Value)
        Entidad.Entregas.codArea = IIf(cmbArea.Value Is Nothing, String.Empty, cmbArea.Value)
        Dim flgjefe As Int32 = 0
        Entidad.Entregas.flgjefe = flgjefe
        Entidad.Entregas.CodJefe = IIf(txtCodigoJefe.Value Is Nothing, String.Empty, txtCodigoJefe.Value)
        Entidad.Entregas.dni = IIf(txtdni.Value Is Nothing, String.Empty, txtdni.Value)
        Entidad.Entregas.telefono = IIf(txttelefono.Value Is Nothing, String.Empty, txttelefono.Value)
        Entidad.Entregas.Email = IIf(txtemail.Value Is Nothing, String.Empty, txtemail.Value)
        Entidad.Entregas = Negocio.NEntregas.MantenimientoTrabajadorArea(Entidad.Entregas)
        If Entidad.Entregas.Validacion Then
            Call actualizar()
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Function Verificar_Datos() As Boolean
        Ep1.Clear()
        Dim lResult As Boolean = Boolean.TrueString
        If String.IsNullOrEmpty(TxtCodigoTrabajador.Value) Then
            Ep1.SetError(TxtCodigoTrabajador, "Ingrese código de trabajador")
            lResult = Boolean.FalseString
        End If
        If String.IsNullOrEmpty(cmbArea.Value) Then
            Ep1.SetError(cmbArea, "Seleccione Área")
            lResult = Boolean.FalseString
        End If
        Return lResult
    End Function
    Sub eliminar()
    End Sub
    Sub reporte()
        If GridTrabajadoresArea.Rows.Count <= 0 Then
            MsgBox("No existen datos a exportar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        Dim rpta As Long
        Dim ruta As String = Application.StartupPath & "\TRABAJADORAREA " & ".xls"
        Dim archivoexcel As String = Trim(ruta)

        Try
            If Trim(Dir(Trim(ruta), vbArchive)) <> "" Then
                rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If rpta = vbNo Then Exit Sub
            End If
            Me.UltraGridExcelExporter1.Export(GridTrabajadoresArea, ruta)

            ''poner cabecera
            Call poner_cabecera_archivo_excel(archivoexcel)

            MessageBox.Show("Exportado: " & Chr(13) & ruta, "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Abrir_Archivo(ruta)
            'Me.Close()

        Catch ex As Exception
            'MessageBox.Show("Ruta Especificada No Existe", "Invalid File Name")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Abrir_Archivo(ByVal ruta As String)

        Dim xApp As Object
        Dim xLibros As Object
        Dim xLibro As Object
        Dim archivoexcel As String = Trim(ruta)

        'Abrimos el archivo
        xApp = CreateObject("excel.application")
        xLibros = xApp.Workbooks

        '' ''poner cabecera antes de abrir
        ''If b_imprimir_cabecera = True Then Call poner_cabecera_archivo_excel(archivoexcel)

        xLibros.Open(archivoexcel, 3)
        xLibro = xApp.ActiveWorkBook
        xApp.Visible = True

    End Sub

    Private Sub poner_cabecera_archivo_excel(ByVal p_archivo As String)

        Dim archivo_excel As New Microsoft.Office.Interop.Excel.Application
        Dim libro_excel As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim h_hoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing

        ''abrir el archivo excel
        Try
            libro_excel = archivo_excel.Workbooks.Open(p_archivo, , False, , , , True, , , True)
        Catch ex As Exception
            MsgBox("Error al intentar abrir el Archivo" & vbCrLf & ex.Message.ToString)
        End Try

        Try
            h_hoja = libro_excel.Sheets(1)
            h_hoja.Range("A1:AZ3").Insert()
            h_hoja.Range("A2:E2").Merge()
            h_hoja.Range("A2:E2").Font.Bold = True
            h_hoja.Range("A2:DG2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            h_hoja.Cells(2, 1).value = "TRABAJADORES POR AREA"
            h_hoja.Range("A1").ColumnWidth = 9.15
            h_hoja.Range("B1").ColumnWidth = 39.3
            h_hoja.Range("C1").ColumnWidth = 38.45
            h_hoja.Range("D1").ColumnWidth = 29.15
            h_hoja.Range("E1").ColumnWidth = 32.7
            'h_hoja.Range("D1:D10000").NumberFormat = "#,##0.0000"

        Catch ex As Exception
            MsgBox("Error al Insertar Cabecera del Archivo" & vbCrLf & ex.Message.ToString)
        End Try

        libro_excel.Save()
        libro_excel.Close()
        libro_excel = Nothing

        archivo_excel.Quit()
        archivo_excel = Nothing

    End Sub

    Private Sub txtCodigoJefe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigoJefe.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If txtCodigoJefe.Text.ToString.Trim = "" Then
            txtCodigoJefe.Focus()
            Exit Sub
        End If
        CargarTrabajadoresxCodigo(Me.txtCodigoJefe.Text)
        If lResult.Ls_Entrega.Count > 0 Then
            txtNomJefe.Text = lResult.Ls_Entrega.Item(0).NomTrabajador
        Else
            MsgBox("Código de trabajador no existe", MsgBoxStyle.Exclamation, msgComacsa)
            txtCodigoJefe.Clear()
            txtNomJefe.Clear()
            txtCodigoJefe.Focus()
        End If
    End Sub

    Sub buscar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If txtCodigoJefe.ReadOnly = True Then Return
        Dim FRM As New FrmListadoPersonal
        FRM.ShowDialog()
        If txtCodigoJefe.ToString.Trim = "" Then Return
        txtCodigoJefe.Text = codTrabajador.ToString.Trim
        txtNomJefe.Text = nomTrabajador.ToString.Trim
    End Sub

End Class