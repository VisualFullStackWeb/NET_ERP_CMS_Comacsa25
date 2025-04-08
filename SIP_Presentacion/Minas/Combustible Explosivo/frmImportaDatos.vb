Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Public Class frmImportaDatos
    Dim dtDetalle As DataTable
    Dim flgtrans As Int32
    Dim tipomov As String
    Dim objEntidad As ETContratista
    Dim objNegocio As NGContratista
#Region "Variables"
    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private ListModulos As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim Ope = 1
#End Region

    Private Sub frmImportaDatos_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmImportaDatos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        dtpDesde.Value = "01/" & Month(Now.Date) & "/" & Year(Now.Date)
        dtpHasta.Value = Now.Date
        cmbperiodo.Value = 1
        CargarDatos()
        dtDetalle = New DataTable
        If dtDetalle.Columns.Count <= 1 Then
            creaTablaDetalle()
        End If
    End Sub
    Sub Procesar()
        limpiar()
        CargarDatos()
        Tab1.Tabs("T02").Selected = True
    End Sub
    Public Sub CargarDatos()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._fecha1 = dtpDesde.Value
            objEntidad._fecha2 = dtpHasta.Value
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.ListarCargas(objEntidad)
            Call CargarUltraGridxBinding(gridCarga, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
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
            If Not ObjW.Sheets(1).Name.ToString.ToUpper = cmbMes.Text.ToString.ToUpper Then
                Return False
            End If
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
    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        'dtDetalle = New DataTable
        If txtalmorigen.Text.Trim = "" Then
            MsgBox("Seleccione almacén", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        If txtequipo.Text.Trim = "" Then
            MessageBox.Show("Ingrese Maquina", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtalmorigen.Focus()
            Exit Sub
        End If
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
                cargarDatos(oConn, cmbMes.Text, 1)
                'cargarDatosLaboratorio(oConn, "HCl 36.5-38%", 1)
                'cargarDatosLaboratorio(oConn, "H2SO4 95-98%", 1)
                'cargarDatosLaboratorio(oConn, "NH4OH 28-30%", 1)
                'cargarDatosLaboratorio(oConn, "KMnO4 mín 99%", 2)
                'cargarDatosLaboratorio(oConn, "Na2CO3", 2)
                'cargarDatosLaboratorio(oConn, "HCl 33% Rovic bidón", 2)
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
    Sub cargarDatos(ByVal oConn As OleDbConnection, ByVal hoja As String, ByVal formato As Integer)
        Dim Ls_datos = New List(Of ETProveedorFiscalizado)
        Dim DtSet As New System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        MyCommand = New System.Data.OleDb.OleDbDataAdapter _
       ("select * from [" & hoja & "$A1:R45]", oConn)
        MyCommand.TableMappings.Add("Table", "Tabla")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)
        lblmensaje.Text = "Cargando datos de libro Excel..."
        lblmensaje.Refresh()
        'MsgBox(DtSet.Tables(0).Rows.Count)
        'MsgBox(DtSet.Tables(0).Rows(10)("F3"))
        'If dtDetalle.Columns.Count <= 1 Then
        '    creaTablaDetalle()
        'End If
        Dim cont As Int32 = 1
        Dim ayo_excel As Int32
        Dim mes_excel As Int32
        Dim placa As String = txtcodequipo.Text 'DtSet.Tables(0).Rows(6)("F1").ToString
        Dim codtipoequipo As String = ""
        Dim tipoequipo As String = ""
        objEntidad = New ETContratista
        objNegocio = New NGContratista
        objEntidad._placa = placa
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.BuscaTipoEquipo(objEntidad)
        If dtDatos.Rows.Count > 0 Then
            codtipoequipo = dtDatos.Rows(0)("COD_CLASE").ToString.Trim
            tipoequipo = dtDatos.Rows(0)("DESCRIP").ToString.Trim
        Else
            codtipoequipo = ""
            tipoequipo = ""
            placa = ""
        End If

        Dim dtFechas As New DataTable
        objEntidad = New ETContratista
        objNegocio = New NGContratista
        objEntidad._ayo = txtAño.Value
        objEntidad._mes = cmbMes.Value
        objEntidad._quincena = cmbperiodo.Value
        If DtSet.Tables(0).Rows(9)("F5").ToString = "INICIAL" Then
            objEntidad._tipomaterial = "C"
        Else
            objEntidad._tipomaterial = "E"
        End If
        objEntidad._codcli = txtcodcliente.Text 'DtSet.Tables(0).Rows(4)("F1").ToString
        objEntidad._codequipo = txtcodequipo.Text 'placa
        objEntidad._codalmori = txtidalmorigen.Text
        dtFechas = objNegocio.ValidaFechasCarga(objEntidad)
        Dim fecha1 As Date = dtFechas.Rows(0)(0)
        Dim fecha2 As Date = dtFechas.Rows(1)(0)


        objEntidad._placa = txtcodequipo.Text
        'txtcodequipo.Text = placa
        'txtcliente.Text = DtSet.Tables(0).Rows(4)("F7").ToString
        'txtcodcliente.Text = DtSet.Tables(0).Rows(4)("F1").ToString
        dtDetalle.Rows.Clear()
        If DtSet.Tables(0).Rows(9)("F5").ToString = "INICIAL" Then
            cmbtipo.Value = "C"
            For i As Int32 = 10 To 42
                If DtSet.Tables(0).Rows(i)("F4").ToString <> "" Then 'And DtSet.Tables(0).Rows(i)("F5").ToString <> "" And DtSet.Tables(0).Rows(i)("F6").ToString <> "" Then
                    ayo_excel = Year(DtSet.Tables(0).Rows(i)("F4").ToString)
                    mes_excel = Month(DtSet.Tables(0).Rows(i)("F4").ToString)
                    If ayo_excel <> txtAño.Value Or mes_excel <> cmbMes.Value Then
                        MsgBox("La fecha no se encuentra en el periodo correcto en la fila " & cont)
                        Exit Sub
                    End If
                    If fecha1 < CDate(DtSet.Tables(0).Rows(i)("F4")).ToString("dd/MM/yyyy") And CDate(DtSet.Tables(0).Rows(i)("F4")).ToString("dd/MM/yyyy") < fecha2 Then
                        Dim dr As DataRow
                        dr = dtDetalle.NewRow
                        dr(0) = codtipoequipo 'CODTIPOEQUIPO
                        dr(1) = tipoequipo 'TIPOEQUIPO
                        dr(2) = txtcodequipo.Text 'DtSet.Tables(0).Rows(6)("F1").ToString 'CODEQUIPO
                        dr(3) = txtequipo.Text 'DtSet.Tables(0).Rows(6)("F7").ToString 'EQUIPO
                        If DtSet.Tables(0).Rows(i)("F5").ToString = "" Or DtSet.Tables(0).Rows(i)("F5").ToString = "-" Then
                            dr(4) = 0 'ENTRADA
                        Else
                            dr(4) = DtSet.Tables(0).Rows(i)("F5") 'ENTRADA
                        End If

                        If DtSet.Tables(0).Rows(i)("F6").ToString = "" Or DtSet.Tables(0).Rows(i)("F6").ToString = "-" Then
                            dr(5) = 0 'SALIDA
                        Else
                            dr(5) = DtSet.Tables(0).Rows(i)("F6") 'SALIDA
                        End If

                        If DtSet.Tables(0).Rows(i)("F7") Is DBNull.Value Then
                            DtSet.Tables(0).Rows(i)("F7") = 0
                        End If
                        If DtSet.Tables(0).Rows(i)("F7").ToString = "" Then
                            DtSet.Tables(0).Rows(i)("F7") = 0
                        End If
                        dr(6) = CDbl(DtSet.Tables(0).Rows(i)("F7")).ToString("#0.0000") 'TAREO

                        dr(7) = DtSet.Tables(0).Rows(i)("F13").ToString 'CODTIPOTAREO
                        dr(8) = DtSet.Tables(0).Rows(i)("F14").ToString 'TIPOTAREO
                        dr(9) = DtSet.Tables(0).Rows(i)("F15").ToString 'CODTIPOTRABAJO
                        dr(10) = DtSet.Tables(0).Rows(i)("F16").ToString 'TIPOTRABAJO
                        'If DtSet.Tables(0).Rows(i)("F12").ToString.ToString = "" Then
                        '    MsgBox("NO EXISTE CODIGO DE PRODUCTO")
                        '    Exit Sub
                        'End If
                        dr(11) = DtSet.Tables(0).Rows(i)("F12").ToString 'CODMATERIAL
                        dr(12) = DtSet.Tables(0).Rows(i)("F11").ToString 'MATERIAL
                        If DtSet.Tables(0).Rows(i)("F9") Is DBNull.Value Then
                            DtSet.Tables(0).Rows(i)("F9") = 0
                        End If
                        If DtSet.Tables(0).Rows(i)("F9").ToString = "" Then
                            DtSet.Tables(0).Rows(i)("F9") = 0
                        End If
                        dr(13) = CDbl(DtSet.Tables(0).Rows(i)("F9")).ToString("#0.0000") 'CANTIDAD
                        dr(14) = DtSet.Tables(0).Rows(i)("F18").ToString 'UM
                        dr(15) = "0.00000"
                        dr(16) = "0.00000"
                        dr(17) = "0.00000"
                        dr(18) = CDate(DtSet.Tables(0).Rows(i)("F4")).ToString("dd/MM/yyyy") 'FECHA
                        dr(19) = DtSet.Tables(0).Rows(i)("F17").ToString.Trim 'MOTIVO
                        dtDetalle.Rows.Add(dr)
                        cont = cont + 1
                    End If
                End If
                'MsgBox(DtSet.Tables(0).Rows(i)("F3").ToString)
            Next
        Call CargarUltraGrid(gridDetalle, dtDetalle)
        MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
        cmbMes.ReadOnly = True
        txtAño.Enabled = False
        cmbperiodo.ReadOnly = True
        Else
        cmbtipo.Value = "E"
        For i As Int32 = 10 To 42
            If DtSet.Tables(0).Rows(i)("F4").ToString <> "" Then
                ayo_excel = Year(DtSet.Tables(0).Rows(i)("F4").ToString)
                mes_excel = Month(DtSet.Tables(0).Rows(i)("F4").ToString)
                If ayo_excel <> txtAño.Value Or mes_excel <> cmbMes.Value Then
                    MsgBox("La fecha no se encuentra en el periodo correcto en la fila " & cont)
                    Exit Sub
                End If
                If fecha1 < CDate(DtSet.Tables(0).Rows(i)("F4")).ToString("dd/MM/yyyy") And CDate(DtSet.Tables(0).Rows(i)("F4")).ToString("dd/MM/yyyy") < fecha2 Then
                    For j As Int32 = 5 To 11
                        If DtSet.Tables(0).Rows(i)("F" & j).ToString <> "" Then
                            Dim dr As DataRow
                            dr = dtDetalle.NewRow
                            dr(0) = "" 'codtipoequipo 'CODTIPOEQUIPO
                            dr(1) = "" 'tipoequipo 'TIPOEQUIPO
                            dr(2) = "" 'DtSet.Tables(0).Rows(6)("F1").ToString 'CODEQUIPO
                            dr(3) = "" 'DtSet.Tables(0).Rows(6)("F7").ToString 'EQUIPO
                            dr(4) = "0.00000" 'ENTRADA
                            dr(5) = "0.00000" 'SALIDA
                            dr(6) = "0.00000" 'TAREO
                            dr(7) = "" 'CODTIPOTAREO
                            dr(8) = "" 'TIPOTAREO
                            dr(9) = DtSet.Tables(0).Rows(i)("F13").ToString 'CODTIPOTRABAJO
                            dr(10) = DtSet.Tables(0).Rows(i)("F12").ToString 'TIPOTRABAJO
                            dr(11) = DtSet.Tables(0).Rows(8)("F" & j).ToString 'CODMATERIAL
                            dr(12) = DtSet.Tables(0).Rows(9)("F" & j).ToString 'MATERIAL
                            dr(13) = CDbl(DtSet.Tables(0).Rows(i)("F" & j)).ToString("#0.0000") 'CANTIDAD
                            dr(14) = DtSet.Tables(0).Rows(7)("F" & j).ToString 'UM
                            dr(15) = "0.00000"
                            dr(16) = "0.00000"
                            dr(17) = "0.00000"
                            dr(18) = CDate(DtSet.Tables(0).Rows(i)("F4")).ToString("dd/MM/yyyy") 'FECHA
                            dr(19) = DtSet.Tables(0).Rows(i)("F14").ToString.Trim 'MOTIVO
                            dtDetalle.Rows.Add(dr)
                        End If
                    Next
                End If
                cont = cont + 1
            End If
            'MsgBox(DtSet.Tables(0).Rows(i)("F3").ToString)
        Next
        Call CargarUltraGrid(gridDetalle, dtDetalle)
        MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
        cmbMes.ReadOnly = True
        txtAño.Enabled = False
        cmbperiodo.ReadOnly = True
        End If
        
    End Sub

    Sub creaTablaDetalle()
        dtDetalle.Columns.Add("COD_TIPOEQUIPO")
        dtDetalle.Columns.Add("TIPOEQUIPO")
        dtDetalle.Columns.Add("COD_EQUIPO")
        dtDetalle.Columns.Add("EQUIPO")
        dtDetalle.Columns.Add("ENTRADA")
        dtDetalle.Columns.Add("SALIDA")
        dtDetalle.Columns.Add("CANTMAQUINA")
        dtDetalle.Columns.Add("COD_TIPOTAREO")
        dtDetalle.Columns.Add("TIPOTAREO")
        dtDetalle.Columns.Add("COD_TIPOTRABAJO")
        dtDetalle.Columns.Add("TIPOTRABAJO")
        dtDetalle.Columns.Add("COD_MATERIAL")
        dtDetalle.Columns.Add("MATERIAL")
        dtDetalle.Columns.Add("CANTIDAD")
        dtDetalle.Columns.Add("UM")
        dtDetalle.Columns.Add("CANT_PEDIDA")
        dtDetalle.Columns.Add("VALOR")
        dtDetalle.Columns.Add("TOTALDESPACHADO")
        dtDetalle.Columns.Add("FECHA")
        dtDetalle.Columns.Add("MOTIVO")
    End Sub
    Sub Buscar()
        If txtalmorigen.Focused = True Then
            txtalmorigen.Clear()
            Dim frm As New frmBuscarAlmacen
            frm.ShowDialog()
            txtalmorigen.Text = frm.gridAlmacen.ActiveRow.Cells("ALMACEN").Value.ToString.Trim
            txtidalmorigen.Text = frm.gridAlmacen.ActiveRow.Cells("COD_ALMACEN").Value.ToString.Trim
            txtcodcanteraori.Text = frm.gridAlmacen.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcanteraori.Text = frm.gridAlmacen.ActiveRow.Cells("CANTERA").Value.ToString.Trim
        End If
        If txtcliente.Focused = True Then
            txtcliente.Clear()
            txtcodcliente.Clear()
            Dim frm As New frmBuscarCliente
            frm.ShowDialog()
            txtcliente.Text = frm.gridCliente.ActiveRow.Cells("RAZON").Value.ToString.Trim
            txtcodcliente.Text = frm.gridCliente.ActiveRow.Cells("COD_CLI").Value.ToString.Trim
        End If
        If txtequipo.Focused = True Then
            txtequipo.Clear()
            txtcodequipo.Clear()
            Dim frm As New FrmBuscarMquina
            frm.ShowDialog()
            txtequipo.Text = frm.gridMaquina.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
            txtcodequipo.Text = frm.gridMaquina.ActiveRow.Cells("PLACA").Value.ToString.Trim
        End If
    End Sub
    Sub Grabar()
        'MsgBox(dtDetalle.Rows.Count)
        If Tab1.Tabs("T01").Selected = False Then
            Exit Sub
        End If
        Try
            If txtalmorigen.Text.Trim = "" Then
                MessageBox.Show("Ingrese almacén", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtalmorigen.Focus()
                Exit Sub
            End If
            If txtequipo.Text.Trim = "" Then
                MessageBox.Show("Ingrese Maquina", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtalmorigen.Focus()
                Exit Sub
            End If
            If dtDetalle.Rows.Count <= 0 Then
                MessageBox.Show("No existen datos a importar", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            For i As Int32 = 0 To dtDetalle.Rows.Count - 1
                objEntidad = New ETContratista
                objNegocio = New NGContratista
                If dtDetalle.Rows(i)("CANTIDAD") > 0 Or dtDetalle.Rows(i)("CANTMAQUINA") > 0 Then
                    Dim dtvalidaProducto As New DataTable
                    dtvalidaProducto = objNegocio.ValidaProduto(dtDetalle.Rows(i)("COD_MATERIAL"))
                    If dtvalidaProducto.Rows.Count = 0 Then
                        MessageBox.Show("El producto ingresado en la fila " & i + 1 & " no existe", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End If
            Next

            If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            objEntidad = New ETContratista
            objNegocio = New NGContratista

            With objEntidad
                .Tipo = Ope
                ._codalmori = txtidalmorigen.Text
                ._codcli = txtcodcliente.Text
                ._tipomaterial = cmbtipo.Value
                ._codcanteraori = txtcodcanteraori.Text
                ._ayo = txtAño.Value
                ._mes = cmbMes.Value
                ._quincena = cmbperiodo.Value
                ._codequipo = txtcodequipo.Text.ToString
                ._usuario = User_Sistema
            End With
            Dim valida As String
            valida = objNegocio.ValidaCarga(objEntidad)

            If valida = "EXISTE" Then
                If MsgBox("¿Ya existe una carga desea reemplazar los tickets generados?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Exit Sub
                Else
                    objNegocio.Elimina_Carga_Movimiento(objEntidad)
                End If
                'MessageBox.Show("Ya existe una carga", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Exit Sub
            End If

            objNegocio.Carga_Movimiento(objEntidad, dtDetalle)
            Dim Mensaje As String = "Se grabó con éxito el registro"
            MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
            Tab1.Tabs("T01").Selected = Boolean.TrueString
            limpiar()
            CargarDatos()
        Catch ex As Exception
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub

    Sub Eliminar()
        If Tab1.Tabs("T02").Selected = False Then
            Exit Sub
        End If
        If gridCarga.ActiveRow Is Nothing Then
            Exit Sub
        End If
        objEntidad = New ETContratista
        objNegocio = New NGContratista
        With objEntidad
            .Tipo = Ope
            ._codalmori = gridCarga.ActiveRow.Cells("CODALMACEN").Value.ToString.Trim
            ._codcli = gridCarga.ActiveRow.Cells("CODCONTRATISTA").Value.ToString.Trim
            ._tipomaterial = IIf(gridCarga.ActiveRow.Cells("TIPOCARGA").Value.ToString.Trim = "COMBUSTIBLE", "C", "E")
            ._codcanteraori = ""
            ._ayo = gridCarga.ActiveRow.Cells("AYO").Value.ToString.Trim
            ._mes = gridCarga.ActiveRow.Cells("MESNRO").Value.ToString.Trim
            ._quincena = gridCarga.ActiveRow.Cells("PERIODO").Value.ToString.Trim
            ._codequipo = gridCarga.ActiveRow.Cells("COD_EQUIPO").Value.ToString.Trim
            ._usuario = User_Sistema
        End With
        Dim valida As String
        valida = objNegocio.ValidaCarga(objEntidad)
        If MsgBox("¿Desea eliminar la carga y los tickets relacionados?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Exit Sub
        Else
            objNegocio.Elimina_Carga_Movimiento(objEntidad)
        End If
        Dim Mensaje As String = "Se eliminó con éxito el registro"
        MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        limpiar()
        CargarDatos()
            'MessageBox.Show("Ya existe una carga", msgComacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Exit Sub
    End Sub

    Private Sub txtalmorigen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtalmorigen.KeyPress
        Buscar()
    End Sub
    Sub limpiar()
        dtDetalle.Rows.Clear()
        Call CargarUltraGrid(gridDetalle, dtDetalle)
        cmbMes.ReadOnly = False
        txtAño.Enabled = True
        cmbperiodo.ReadOnly = False
        txtalmorigen.Clear()
        txtidalmorigen.Clear()
        cmbtipo.Value = ""
        txtcliente.Clear()
        txtcodcliente.Clear()
        txtcodequipo.Clear()
        txtequipo.Clear()
    End Sub
    Sub Nuevo()
        Tab1.Tabs("T01").Selected = True
        limpiar()
    End Sub

    Private Sub txtcliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcliente.KeyPress
        Buscar()
    End Sub

    Private Sub txtequipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtequipo.KeyPress
        Buscar()
    End Sub
End Class