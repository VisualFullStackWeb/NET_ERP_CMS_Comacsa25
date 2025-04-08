Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class FrmRegAlqMaquina
    Dim dtDetalle As DataTable
    Dim flgtrans As Int32
    Dim tipomov As String
    Dim objEntidad As ETContratista
    Dim objNegocio As NGContratista
    Dim ruta_archivo As String = ""
    Dim user_aprueba As String = "0"
    Dim estado As String = "0"
#Region "Variables"
    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private ListModulos As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim Ope = 1
#End Region

    Private Sub FrmRegAlqMaquina_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        cmbMes.Value = Now.Date.Month
        cmbperiodo.Value = 1
        dtpIni.Value = "01/" & Month(Now.Date) & "/" & Year(Now.Date)
        dtpFin.Value = Now.Date
        dtDetalle = New DataTable
        If dtDetalle.Columns.Count <= 1 Then
            creaTablaDetalle()
        End If
        usuario_Aprueba()
    End Sub

    Sub Procesar()
        carga_Datos()
    End Sub

    Sub carga_Datos()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._fecha1 = dtpIni.Value
        objEntidad._fecha2 = dtpFin.Value
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.ListarRegistroAlquiler(objEntidad)
        Call CargarUltraGridxBinding(gridData, Source2, dtDatos)
    End Sub

    Sub creaTablaDetalle()
        dtDetalle.Columns.Add("COD_CANTERA")
        dtDetalle.Columns.Add("FECHA")
        dtDetalle.Columns.Add("HORO_INI")
        dtDetalle.Columns.Add("HORO_FIN")
        dtDetalle.Columns.Add("HORA")
        dtDetalle.Columns.Add("GALONES")
        dtDetalle.Columns.Add("GALON_HORA")
        dtDetalle.Columns.Add("LABOR")
        dtDetalle.Columns.Add("ACTIVIDAD")
        dtDetalle.Columns.Add("CANTERA")
    End Sub

    Private Sub cmbperiodo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbperiodo.ValueChanged
        Try
            Fecha_Quincena()
        Catch ex As Exception

        End Try
    End Sub
    Sub carga_Factura()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._fecha1 = dtinicio.Value
        objEntidad._fecha2 = dtfin.Value
        objEntidad._codprov = txtcodprov.Text
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.ListarFacturaAlquiler(objEntidad)
        Call CargarUltraGridxBinding(gridFactura, Source1, dtDatos)
    End Sub
    Sub Fecha_Mes()
        If cmbMes.SelectedIndex < 0 Then
            Exit Sub : MsgBox("Seleccione Mes", MsgBoxStyle.Exclamation, msgComacsa)
        Else
            Dim mes As Int32
            mes = cmbMes.Value
            Dim fecha1 As Date
            Dim fecha2 As Date
            fecha1 = "01/" & mes & "/" & txtAño.Value
            fecha2 = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, fecha1)))

            dtinicio.Value = fecha1
            dtfin.Value = fecha2

        End If
    End Sub
    Sub Fecha_Quincena()
        If cmbMes.SelectedIndex < 0 Then
            MsgBox("Seleccione Mes", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
        Else
            Dim quincena As Int32
            Dim mes As Int32
            mes = cmbMes.Value
            Dim fecha1 As Date
            Dim fechainicio As Date
            Dim fecha2 As Date
            fecha1 = "01/" & mes & "/" & txtAño.Value
            If cmbperiodo.Value = 1 Then
                quincena = 1
                fechainicio = fecha1
                fecha2 = "15/" & mes & "/" & txtAño.Value
            Else
                quincena = 2
                fechainicio = "16/" & mes & "/" & txtAño.Value
                fecha2 = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, fecha1)))
            End If
            dtinicio.Value = fechainicio
            dtfin.Value = fecha2

        End If
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            Fecha_Mes()
            Fecha_Quincena()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Try
            OpenFileDialog1.Filter = "Libro de Excel|*.xls;*.xlsx"
            OpenFileDialog1.FileName = String.Empty
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub
            Dim cadenaExcel As String = Me.OpenFileDialog1.FileName
            Cursor = Cursors.WaitCursor
            lblmensaje.Visible = True
            lblmensaje.Text = "Validando datos de libro Excel..."
            lblmensaje.Refresh()
            If Not ValidarExcel(cadenaExcel) Then
                MsgBox("El archivo seleccionado es incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
                Cursor = Cursors.Default
                lblmensaje.Visible = False
                lblmensaje.Refresh()
                Exit Sub
            End If
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                          "Data Source= " & cadenaExcel & _
                          ";Extended Properties=""Excel 8.0;HDR=YES"""
            Dim oConn As New OleDbConnection(cs)

            Try
                oConn.Open()
                cargarDatos(oConn, "DATA")
                ruta_archivo = cadenaExcel
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Ocurrió un error")
                'MsgBox("Archivo incorrecto a ya se encuentra utilizado", MsgBoxStyle.Critical, "Comacsa")
            Finally
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                Cursor = Cursors.Default
                lblmensaje.Visible = False
                lblmensaje.Refresh()
                oConn.Close()
                oConn.Dispose()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub cargarDatos(ByVal oConn As OleDbConnection, ByVal hoja As String)
        Try
            Dim Ls_datos = New List(Of ETProveedorFiscalizado)
            Dim DtSet As New System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyCommand = New System.Data.OleDb.OleDbDataAdapter _
           ("select * from [" & hoja & "$A2:Q33]", oConn)
            MyCommand.TableMappings.Add("Table", "Tabla")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            lblmensaje.Text = "Cargando datos de libro Excel..."
            lblmensaje.Refresh()
            Dim cont As Int32 = 1

            Dim codcantera As String = ""
            Dim tipoequipo As String = ""

            dtDetalle.Rows.Clear()
            'If DtSet.Tables(1).Rows(i)(0).ToString() = "" Then
            For i As Int32 = 0 To DtSet.Tables(0).Rows.Count - 1
                If DtSet.Tables(0).Rows(i)(1).ToString <> "" And DtSet.Tables(0).Rows(i)(3).ToString <> "" And DtSet.Tables(0).Rows(i)(7).ToString <> "" _
                And DtSet.Tables(0).Rows(i)(11).ToString <> 0 And DtSet.Tables(0).Rows(i)(12).ToString <> "" And DtSet.Tables(0).Rows(i)(13).ToString <> "" Then 'And DtSet.Tables(0).Rows(i)("F5").ToString <> "" And DtSet.Tables(0).Rows(i)("F6").ToString <> "" Then
                    Dim dr As DataRow
                    dr = dtDetalle.NewRow
                    dr(0) = DtSet.Tables(0).Rows(i)(1).ToString()
                    dr(1) = CDate(DtSet.Tables(0).Rows(i)(3)).ToString("dd/MM/yyyy")
                    dr(2) = DtSet.Tables(0).Rows(i)(12).ToString()
                    dr(3) = DtSet.Tables(0).Rows(i)(13).ToString()
                    dr(4) = DtSet.Tables(0).Rows(i)(11).ToString()
                    dr(5) = CDbl(DtSet.Tables(0).Rows(i)(7)).ToString("###0.00")
                    dr(6) = CDbl(DtSet.Tables(0).Rows(i)(8)).ToString("###0.00")
                    dr(7) = DtSet.Tables(0).Rows(i)(9).ToString()
                    dr(8) = DtSet.Tables(0).Rows(i)(10).ToString()
                    dr(9) = DtSet.Tables(0).Rows(i)(2).ToString()
                    dtDetalle.Rows.Add(dr)
                    cont = cont + 1
                End If
            Next
            Call CargarUltraGrid(gridDetalle, dtDetalle)
            MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
            'cmbMes.ReadOnly = True
            'txtAño.Enabled = False
            'cmbperiodo.ReadOnly = True
            cont = cont + 1
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
            dtDetalle.Rows.Clear()
            Call CargarUltraGrid(gridDetalle, dtDetalle)
        End Try

    End Sub

    Function ValidarExcel(ByVal RUTA As String) As Boolean
        Cursor = Cursors.WaitCursor
        lblmensaje.Visible = True
        lblmensaje.Text = "Validando datos de libro Excel..."
        lblmensaje.Refresh()
        Dim ObjExcel As Microsoft.Office.Interop.Excel.Application
        Dim ObjW As Microsoft.Office.Interop.Excel.Workbook
        ObjExcel = New Microsoft.Office.Interop.Excel.Application
        ObjW = ObjExcel.Workbooks.Open(RUTA)
        Try
            'If Not ObjW.Sheets(1).Name.ToString.ToUpper = cmbMes.Text.ToString.ToUpper Then
            '    Return False
            'End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ObjW.Close()
            ObjW = Nothing
            ObjExcel.Quit()
            Runtime.InteropServices.Marshal.ReleaseComObject(ObjExcel)
            ObjExcel = Nothing
        End Try
    End Function

    Private Sub chkcontratista_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkcontratista.CheckedChanged
        Try
            If chkcontratista.Checked = True Then
                gridFactura.Enabled = False
            Else
                gridFactura.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Grabar()
        If Tab1.Tabs("T02").Selected = False Then
            Exit Sub
        End If
        Try
            If estado = 1 And user_aprueba = 0 Then
                MessageBox.Show("El registro se encuentra aprobado", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If chkcontratista.Checked = False Then
                If gridFactura.Rows.Count <= 0 Then
                    MessageBox.Show("Debe seleccionar una factura", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
            If dtDetalle.Rows.Count <= 0 Then
                MessageBox.Show("No existe detalle", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

            If File.Exists(txtruta.Text) Then
                File.Delete(txtruta.Text)
            End If

            objEntidad = New ETContratista
            objNegocio = New NGContratista
            Dim ruta As String = RutaReporteERP_MP & "ALQUILER_MAQUINA_" & Now.ToString("hhmmss") & ".xls"
            With objEntidad
                .Operacion = IIf(txtid.Text = 0, 1, 2)
                .ID = txtid.Text
                ._ayo = txtAño.Value
                ._mes = cmbMes.Value
                ._fecha1 = dtfin.Value
                If chkcontratista.Checked = False And txtid.Text = 0 Then
                    ._codprov = gridFactura.ActiveRow.Cells("COD_PROV").Value
                    ._razon = gridFactura.ActiveRow.Cells("RAZSOC").Value
                    ._numdocori = gridFactura.ActiveRow.Cells("NUMDOC").Value
                Else
                    ._codprov = txtcodprov.Text
                    ._razon = txtproveedor.Text
                    ._numdocori = ""
                End If
                .hora = 0
                ._galon = 0
                ._galon_hora = 0
                ._contratista = IIf(chkcontratista.Checked = False, 0, 1)
                ._aprobado = IIf(chkaprobar.Checked = False, 0, 1)
                ._ruta = ruta
                ._nota_credito = IIf(chkNC.Checked = True, 1, 0)
                ._importe_NC = txtimporteNC.Text
                ._observacion = txtobservacion.Text

                ._usuario = User_Sistema
            End With
            'Dim valida As String
            'valida = objNegocio.ValidaCarga(objEntidad)

            'If valida = "EXISTE" Then
            '    If MsgBox("¿Ya existe una carga desea reemplazar los tickets generados?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            '        Exit Sub
            '    Else
            '        objNegocio.Elimina_Carga_Movimiento(objEntidad)
            '    End If
            '    'MessageBox.Show("Ya existe una carga", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    'Exit Sub
            'End If
            Dim id As Int32 = objNegocio.Reg_Alquiler_Maquina(objEntidad).Rows(0)(0)

            If txtid.Text = 0 Then
                For i As Int32 = 0 To gridDetalle.Rows.Count - 1
                    objEntidad = New ETContratista
                    objNegocio = New NGContratista
                    With objEntidad
                        ._id = id
                        ._item = i + 1
                        ._cantera = gridDetalle.Rows(i).Cells("COD_CANTERA").Value
                        ._fecha1 = gridDetalle.Rows(i).Cells("FECHA").Value
                        ._horo_ini = gridDetalle.Rows(i).Cells("HORO_INI").Value
                        ._horo_fin = gridDetalle.Rows(i).Cells("HORO_FIN").Value
                        .hora = gridDetalle.Rows(i).Cells("HORA").Value
                        ._galon = gridDetalle.Rows(i).Cells("GALONES").Value
                        ._galon_hora = gridDetalle.Rows(i).Cells("GALON_HORA").Value
                        ._labor = gridDetalle.Rows(i).Cells("LABOR").Value
                        ._actividad = gridDetalle.Rows(i).Cells("ACTIVIDAD").Value
                        ._usuario = User_Sistema
                    End With
                    objNegocio.Reg_Alquiler_Maquina_Det(objEntidad)
                Next
                File.Copy(ruta_archivo, ruta)
            End If


            Dim Mensaje As String = "Se grabó con éxito el registro"
            MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
            Tab1.Tabs("T01").Selected = Boolean.TrueString
            limpiar()
            carga_Datos()
        Catch ex As Exception
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub

    Sub Eliminar()
        If Tab1.Tabs("T02").Selected = False Then
            Exit Sub
        End If
        Try
            'If dtDetalle.Rows.Count <= 0 Then
            '    MessageBox.Show("No existe detalle", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If
            If estado = 1 And user_aprueba = 0 Then
                MessageBox.Show("El registro se encuentra aprobado", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If MsgBox("¿Seguro desea Elimnar el registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

            objEntidad = New ETContratista
            objNegocio = New NGContratista
            With objEntidad
                .Operacion = 3
                .ID = txtid.Text
                ._ayo = txtAño.Value
                ._mes = cmbMes.Value
                ._fecha1 = dtfin.Value
                ._codprov = txtcodprov.Text
                ._razon = txtproveedor.Text
                ._numdocori = ""
                .hora = 0
                ._galon = 0
                ._galon_hora = 0
                ._contratista = IIf(chkcontratista.Checked = False, 0, 1)
                ._aprobado = IIf(chkaprobar.Checked = False, 0, 1)
                ._ruta = txtruta.Text
                ._usuario = User_Sistema
            End With

            Dim id As Int32 = objNegocio.Reg_Alquiler_Maquina(objEntidad).Rows(0)(0)

            If File.Exists(txtruta.Text) Then
                File.Delete(txtruta.Text)
            End If

            Dim Mensaje As String = "Se eliminó con éxito el registro"
            MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
            Tab1.Tabs("T01").Selected = Boolean.TrueString
            limpiar()
            carga_Datos()
        Catch ex As Exception
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub

    Private Sub txtcliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        buscar()
    End Sub
    Sub buscar()
        If txtcodprov.Focused = True Then
            Dim frm As New FrmListaTransportista
            frm.ShowDialog()
            txtcodprov.Text = codMotivodetalle.Trim
            txtproveedor.Text = Motivodetalle.Trim
            If chkcontratista.Checked = False Then
                carga_Factura()
            End If
        End If
    End Sub

    Private Sub txtcodprov_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodprov.KeyDown
        If e.KeyData = Keys.Return Then
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista._codprov = txtcodprov.Text
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NContratista.Listar_PRO_Prov_Codigo(Entidad.Contratista)
            If dtDatos.Rows.Count > 0 Then
                txtcodprov.Text = dtDatos.Rows(0)("COD_PROV")
                txtproveedor.Text = dtDatos.Rows(0)("PROVEEDOR")
            Else
                MsgBox("El código no existe", MsgBoxStyle.Exclamation, msgComacsa)
                txtproveedor.Clear()
            End If
            If chkcontratista.Checked = False Then
                carga_Factura()
            End If
        End If
    End Sub
    Sub Nuevo()
        Tab1.Tabs("T02").Selected = True
        limpiar()
    End Sub
    Sub limpiar()
        txtcodprov.Clear()
        txtproveedor.Clear()
        txtruta.Clear()
        txtid.Text = 0
        Ope = 1
        chkcontratista.Checked = False
        chkaprobar.Checked = False
        dtDetalle.Rows.Clear()
        gridFactura.Enabled = True
        btnImportar.Enabled = True
        txtimporteNC.Text = "0.00"
        chkNC.Checked = False
        txtimporteNC.ReadOnly = True
        txtobservacion.Clear()
        Call CargarUltraGrid(gridDetalle, dtDetalle)
        carga_Factura()
    End Sub

    Private Sub gridData_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridData.DoubleClickRow
        Try
            Tab1.Tabs("T02").Selected = True
            txtid.Text = gridData.ActiveRow.Cells("ID").Value
            txtAño.Value = gridData.ActiveRow.Cells("AYO").Value
            cmbMes.Value = gridData.ActiveRow.Cells("MES").Value
            txtcodprov.Text = gridData.ActiveRow.Cells("COD_PROV").Value
            txtproveedor.Text = gridData.ActiveRow.Cells("RAZON").Value
            txtruta.Text = gridData.ActiveRow.Cells("RUTA").Value
            chkcontratista.Checked = IIf(gridData.ActiveRow.Cells("CONTRATISTA").Value = 1, True, False)
            chkaprobar.Checked = IIf(gridData.ActiveRow.Cells("APROBADO").Value = 1, True, False)
            chkNC.Checked = IIf(gridData.ActiveRow.Cells("NOTA_CREDITO").Value = 1, True, False)
            txtimporteNC.Text = gridData.ActiveRow.Cells("IMPORTE_NC").Value
            txtobservacion.Text = gridData.ActiveRow.Cells("OBSERVACIONES").Value
            estado = gridData.ActiveRow.Cells("APROBADO").Value
            If chkcontratista.Checked = True Then
                gridFactura.Enabled = False
            Else
                gridFactura.Enabled = True
            End If
            If CDate(gridData.ActiveRow.Cells("FECHA").Value).Day > 16 Then
                cmbperiodo.Value = 2
            Else
                cmbperiodo.Value = 1
            End If

            If dtDetalle.Columns.Count <= 1 Then
                creaTablaDetalle()
            End If
            dtDetalle.Rows.Clear()
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad.ID = txtid.Text
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.ListarRegistroAlquiler_Det(objEntidad)
            For i As Int32 = 0 To dtDatos.Rows.Count - 1
                Dim dr As DataRow
                dr = dtDetalle.NewRow
                dr(0) = dtDatos.Rows(i)(0).ToString()
                dr(1) = CDate(dtDatos.Rows(i)(1)).ToString("dd/MM/yyyy")
                dr(2) = dtDatos.Rows(i)(2).ToString()
                dr(3) = dtDatos.Rows(i)(3).ToString()
                dr(4) = dtDatos.Rows(i)(4).ToString()
                dr(5) = CDbl(dtDatos.Rows(i)(5)).ToString("###0.00")
                dr(6) = CDbl(dtDatos.Rows(i)(6)).ToString("###0.00")
                dr(7) = dtDatos.Rows(i)(7).ToString()
                dr(8) = dtDatos.Rows(i)(8).ToString()
                dr(9) = dtDatos.Rows(i)(9).ToString()
                dtDetalle.Rows.Add(dr)
            Next
            Call CargarUltraGrid(gridDetalle, dtDetalle)
            carga_Factura_Det()
            usuario_Aprueba()
            gridFactura.Enabled = False
            btnImportar.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
    Sub usuario_Aprueba()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad.Usuario = User_Sistema
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.user_Aprueba_Alquiler(objEntidad)
        If dtDatos.Rows.Count > 0 Then
            user_aprueba = 1
            chkaprobar.Visible = True
        Else
            user_aprueba = 0
            chkaprobar.Visible = False
        End If
    End Sub
    Sub carga_Factura_Det()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad.ID = txtid.Text
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.ListarFacturaAlquiler_ID(objEntidad)
        Call CargarUltraGridxBinding(gridFactura, Source1, dtDatos)
    End Sub

    Private Sub txtimporteNC_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtimporteNC.GotFocus
        txtimporteNC.Text = CDbl(txtimporteNC.Text).ToString("###0.00")
    End Sub

    Private Sub UltraTextEditor1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtimporteNC.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub chkNC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNC.CheckedChanged
        If chkNC.Checked = True Then
            txtimporteNC.ReadOnly = False
            txtimporteNC.Focus()
        Else
            txtimporteNC.ReadOnly = True
            txtimporteNC.Text = "0.00"
        End If
    End Sub

    Private Sub gridData_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridData.InitializeLayout

    End Sub
End Class