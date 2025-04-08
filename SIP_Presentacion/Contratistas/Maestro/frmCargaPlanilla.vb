Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Public Class frmCargaPlanilla
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
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
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
    Private Ls_Anticipo As List(Of ETContratista) = Nothing
    Private Ls_EntregaDetalle As List(Of ETContratista) = Nothing
#End Region
    Dim dtPlanilla As New DataTable
    Dim dtnoExistente As New DataTable
    Dim x_mes As Int32 = 0
    Dim x_quincena As Int32 = 0
    Dim x_semanaini As Int32 = 0
    Dim x_semanafin As Int32 = 0
    Dim idtipopago As String = ""
    Dim idfrecuenia As Int32 = 0
    Sub Buscar()
        If Ope = 2 Then Exit Sub
        If txtcodcontratista.Focused = True Then
            limpiar()
            Dim frm As New frmBuscarContratista
            frm.ShowDialog()
            txtcodcontratista.Text = frm.gridcontratista.ActiveRow.Cells("COD_PROV").Value.ToString.Trim
            txtcontratista.Text = frm.gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
        End If

        If txtcodcantera.Focused = True Then
            limpiar()
            If txtcodcontratista.Text.Trim = "" Then
                MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            Dim frm As New frmBuscarCantera
            frm.codprov = txtcodcontratista.Text
            frm.ShowDialog()
            txtidcontratista.Text = frm.gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            txtcodcantera.Text = frm.gridcontratista.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcantera.Text = frm.gridcontratista.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
            idtipopago = frm.gridcontratista.ActiveRow.Cells("TIPOPAGO").Value
            idfrecuenia = frm.gridcontratista.ActiveRow.Cells("IDFRECPAGO").Value
            'txtcodcantera.Focus()
            seteoVisible(idfrecuenia, idtipopago)
        End If

    End Sub
    Sub seteoVisible(ByVal _idfrecuenia As Int32, ByVal _idtipopago As String)
        gbquincenal.Visible = False
        gbmensual.Visible = False
        Select Case _idfrecuenia
            Case 1
                'gbsemanal.Visible = True
                'txtsemana.Value = DatePart("ww", Now.Date)
                'Fecha_Semana(txtsemana.Value, 1)
            Case 2
                'gb2semanas.Visible = True
                'txtsemanaini.Value = DatePart("ww", Now.Date)
                'Fecha_Semana(txtsemanaini.Value, 2)
            Case 3
                gbquincenal.Visible = True
                gbquincenal.Refresh()
                cmbmesquincena.Value = Now.Date.Month
                Fecha_Quincena()
            Case 4
                gbmensual.Visible = True
                gbmensual.Refresh()
                cmbMes.Value = Now.Date.Month
                Fecha_Mes()
        End Select

        If _idtipopago.Trim = "T" Then
            'btncargarplanilla.Visible = False
            dtinicio.ReadOnly = False
            dtfin.ReadOnly = False
        ElseIf _idtipopago.Trim = "P" Then
            'btncargarplanilla.Visible = True
            dtinicio.ReadOnly = True
            dtfin.ReadOnly = True
        Else
            MsgBox("Contratista no posee configuración para esta cantera", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcantera.Focus()
            limpiar()
            Exit Sub
        End If
    End Sub
    Sub limpiar()
        txtcodcantera.Clear()
        txtcantera.Clear()
    End Sub

    Private Sub btncargarplanilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncargarplanilla.Click
        Try
            If txtcodcontratista.Text.ToString.Trim = "" Then
                MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
                txtcodcontratista.Focus()
                Exit Sub
            End If
            If txtcodcantera.Text.ToString.Trim = "" Then
                MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
                txtcodcantera.Focus()
                Exit Sub
            End If
            If idfrecuenia = 4 Then
                If cmbMes.SelectedIndex < 0 Then
                    MsgBox("Seleccione mes", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
            End If
            If idfrecuenia = 3 Then
                If cmbmesquincena.SelectedIndex < 0 Then
                    MsgBox("Seleccione mes", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
                If rdb1quincena.Checked = False And rdb2quincena.Checked = False Then
                    MsgBox("Seleccione quincena", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
            End If
            If Not validaPeriodoAnticipo() Then
                MsgBox("El contratista ya generó un anticipo para este periodo", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            PlanillaPeriodo()
            If dtPlanilla.Rows.Count > 0 Then
                If MsgBox("¿Ya se cargó una planilla para este periodo desea volver a cargar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            OpenFileDialog1.Filter = "Libro de Excel|*.xls;*.xlsx"
            OpenFileDialog1.FileName = String.Empty
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub
            Dim cadenaExcel As String = Me.OpenFileDialog1.FileName
            Cursor = Cursors.WaitCursor

            If Not ValidarExcel(cadenaExcel, txtcodcantera.Text, "P") Then
                MsgBox("El archivo seleccionado es incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
                Cursor = Cursors.Default
                Return
            End If
            'MsgBox("ENTRANDO A CONEXION OLEDB")
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                          "Data Source= " & cadenaExcel & _
                          ";Extended Properties=""Excel 8.0;HDR=YES"""
            Dim oConn As New OleDbConnection(cs)

            Try
                oConn.Open()

                'Dim objNegocio As NGContratista = Nothing
                'Dim objEntidad As ETContratista = Nothing
                'objNegocio = New NGContratista
                'objEntidad = New ETContratista

                'objEntidad._codprov = txtcodcontratista.Text

                'Dim dtContratista As New DataTable
                'dtContratista = objNegocio.ListarCantera(objEntidad)

                'For i As Int32 = 0 To dtContratista.Rows.Count - 1
                cargarDatos(oConn, txtcodcantera.Text.ToString.Trim.ToString.Trim, 1, "P", cadenaExcel)

                If dtnoExistente.Rows.Count > 0 Then
                    objNegocio = New NGContratista
                    objEntidad = New ETContratista
                    objEntidad._tipodocumento = "01"
                    objEntidad._idcontratista = txtidcontratista.Text
                    objEntidad._codprov = txtcodcontratista.Text
                    objEntidad._codcantera = txtcodcantera.Text
                    objEntidad._ayo = txtayo.Value
                    Select Case idfrecuenia
                        Case 3 'QUINCENAL
                            x_mes = cmbmesquincena.Value
                            x_quincena = IIf(rdb1quincena.Checked = True, 1, 2)
                        Case 4  'MENSUAL
                            x_mes = cmbMes.Value
                    End Select
                    objEntidad._mes = x_mes
                    objEntidad._quincena = x_quincena
                    objEntidad._semanaini = 0
                    objEntidad._semanafin = 0
                    objEntidad._usuario = User_Sistema
                    objEntidad._tipoanticipo = "E"
                    objNegocio.EliminaPlanillaPeriodo(objEntidad)
                    MessageBox.Show("El archivo contiene trabajador(es) no registrados en la BD", "Sistema", MessageBoxButtons.OK)
                    Dim frm As New frmnoExistente
                    frm.dtPlanilla = dtnoExistente
                    frm.ShowDialog()
                    Exit Sub
                End If

                'Next

                MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
                mostrarPlanilla("P")
                'btnprocesar_Click(Nothing, Nothing)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Ocurrió un error")
                'MsgBox("Archivo incorrecto a ya se encuentra utilizado", MsgBoxStyle.Critical, "Comacsa")
            Finally
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                Cursor = Cursors.Default
                oConn.Close()
                oConn.Dispose()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub cargarDatos(ByVal oConn As OleDbConnection, ByVal hoja As String, ByVal formato As Integer, ByVal tipoboton As String, ByVal RUTA As String)

        'Dim ObjExcel As Microsoft.Office.Interop.Excel.Application
        'Dim ObjW As Microsoft.Office.Interop.Excel.Workbook
        'ObjExcel = New Microsoft.Office.Interop.Excel.Application
        'ObjW = ObjExcel.Workbooks.Open(RUTA)
        'Try
        '    Dim existe As Int32 = 0
        '    For i As Int32 = 1 To ObjW.Sheets.Count
        '        If ObjW.Sheets(i).Name = hoja Then
        '            existe = 1
        '        End If
        '    Next
        '    If existe = 0 Then Exit Sub
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    ObjW.Close()
        '    ObjW = Nothing
        '    ObjExcel.Quit()
        '    Runtime.InteropServices.Marshal.ReleaseComObject(ObjExcel)
        '    ObjExcel = Nothing
        'End Try


        Dim Ls_datos = New List(Of ETProveedorFiscalizado)
        Dim DtSet As New System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        MyCommand = New System.Data.OleDb.OleDbDataAdapter _
        ("select * from [" & hoja & "$A6:AZ10000]", oConn)
        MyCommand.TableMappings.Add("Table", "TablaPlanilla")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim dtSeteoExcel As New DataTable
        dtSeteoExcel = objNegocio.ListarSeteoExcel()
        Dim _DNI As String = dtSeteoExcel.Rows(0)("CONCEPTOEXCEL")
        Dim _REMUNERACION As String = dtSeteoExcel.Rows(1)("CONCEPTOEXCEL")
        Dim _PAGO As String = dtSeteoExcel.Rows(2)("CONCEPTOEXCEL")
        Dim _ONP As String = dtSeteoExcel.Rows(3)("CONCEPTOEXCEL")
        Dim _AFP As String = dtSeteoExcel.Rows(4)("CONCEPTOEXCEL")
        Dim _QUINTA As String = dtSeteoExcel.Rows(5)("CONCEPTOEXCEL")
        Dim _ESSALUD As String = dtSeteoExcel.Rows(6)("CONCEPTOEXCEL")
        Dim _SCTR As String = dtSeteoExcel.Rows(7)("CONCEPTOEXCEL")
        Dim _AFPCOMP As String = dtSeteoExcel.Rows(8)("CONCEPTOEXCEL")
        Dim _FMINERO As String = dtSeteoExcel.Rows(9)("CONCEPTOEXCEL")
        Dim _GRATIFICACION As String = dtSeteoExcel.Rows(10)("CONCEPTOEXCEL")
        Dim _CTS As String = dtSeteoExcel.Rows(11)("CONCEPTOEXCEL")
        Dim _APE_PAT As String = dtSeteoExcel.Rows(12)("CONCEPTOEXCEL")
        Dim _APE_MAT As String = dtSeteoExcel.Rows(13)("CONCEPTOEXCEL")
        Dim _NOMBRES As String = dtSeteoExcel.Rows(14)("CONCEPTOEXCEL")
        Dim _SCTR_SALUD As String = dtSeteoExcel.Rows(15)("CONCEPTOEXCEL")
        Dim _ESSALUD_VIDA As String = dtSeteoExcel.Rows(16)("CONCEPTOEXCEL")
        dtPlanilla = DtSet.Tables(0)
        dtnoExistente = New DataTable
        If dtnoExistente.Columns.Count <= 0 Then
            dtnoExistente.Columns.Add("DNI")
            dtnoExistente.Columns.Add("NOMBRES")
        End If
        For i As Int32 = 0 To dtPlanilla.Rows.Count - 1
            If dtPlanilla.Rows(i)(_DNI).ToString.Trim <> "" Then
                objNegocio = New NGContratista
                objEntidad = New ETContratista
                objEntidad._tipodocumento = "01"
                objEntidad._documento = dtPlanilla.Rows(i)(_DNI)
                objEntidad._ayo = txtayo.Value
                Select Case idfrecuenia
                    Case 3 'QUINCENAL
                        x_mes = cmbmesquincena.Value
                        x_quincena = IIf(rdb1quincena.Checked = True, 1, 2)
                    Case 4  'MENSUAL
                        x_mes = cmbMes.Value
                        x_quincena = 0
                End Select
                objEntidad._mes = x_mes
                objEntidad._quincena = x_quincena
                objEntidad._semanaini = 0
                objEntidad._semanafin = 0
                objEntidad._fecha1 = dtinicio.Value
                objEntidad._fecha2 = dtfin.Value
                objEntidad._codprov = txtcodcontratista.Text
                objEntidad._codcantera = hoja 'txtcodcantera.Text
                objEntidad._sueldo = IIf(dtPlanilla.Rows(i)(_REMUNERACION) Is DBNull.Value Or dtPlanilla.Rows(i)(_REMUNERACION).ToString.Trim = "", 0, dtPlanilla.Rows(i)(_REMUNERACION))
                objEntidad._pago = IIf(dtPlanilla.Rows(i)(_PAGO) Is DBNull.Value Or dtPlanilla.Rows(i)(_PAGO).ToString.Trim = "", 0, dtPlanilla.Rows(i)(_PAGO))
                objEntidad._onp = IIf(dtPlanilla.Rows(i)(_ONP) Is DBNull.Value Or dtPlanilla.Rows(i)(_ONP).ToString.Trim = "", 0, dtPlanilla.Rows(i)(_ONP))
                objEntidad._afp = IIf(dtPlanilla.Rows(i)(_AFP) Is DBNull.Value Or dtPlanilla.Rows(i)(_AFP).ToString.Trim = "", 0, dtPlanilla.Rows(i)(_AFP))
                objEntidad._essalud = IIf(dtPlanilla.Rows(i)(_ESSALUD) Is DBNull.Value Or dtPlanilla.Rows(i)(_ESSALUD).ToString.Trim = "", 0, dtPlanilla.Rows(i)(_ESSALUD))
                objEntidad._quinta = IIf(dtPlanilla.Rows(i)(_QUINTA) Is DBNull.Value Or dtPlanilla.Rows(i)(_QUINTA).ToString.Trim = "", 0, dtPlanilla.Rows(i)(_QUINTA))
                objEntidad._sctr = IIf(dtPlanilla.Rows(i)(_SCTR) Is DBNull.Value Or dtPlanilla.Rows(i)(_SCTR).ToString.Trim = "", 0, dtPlanilla.Rows(i)(_SCTR))
                objEntidad._afpcomp = IIf(dtPlanilla.Rows(i)(_AFPCOMP) Is DBNull.Value Or dtPlanilla.Rows(i)(_AFPCOMP).ToString.Trim = "", 0, dtPlanilla.Rows(i)(_AFPCOMP))
                objEntidad._fminero = IIf(dtPlanilla.Rows(i)(_FMINERO) Is DBNull.Value Or dtPlanilla.Rows(i)(_FMINERO).ToString.Trim = "", 0, dtPlanilla.Rows(i)(_FMINERO))
                If tipoboton = "G" Then
                    objEntidad._gratificacion = IIf(dtPlanilla.Rows(i)(_PAGO) Is DBNull.Value Or dtPlanilla.Rows(i)(_PAGO).ToString.Trim = "", 0, dtPlanilla.Rows(i)(_PAGO))
                    objEntidad._cts = 0
                ElseIf tipoboton = "CTS" Then
                    objEntidad._gratificacion = 0
                    objEntidad._cts = IIf(dtPlanilla.Rows(i)(_PAGO) Is DBNull.Value Or dtPlanilla.Rows(i)(_PAGO).ToString.Trim = "", 0, dtPlanilla.Rows(i)(_PAGO))
                Else
                    objEntidad._gratificacion = 0
                    objEntidad._cts = 0
                End If
                objEntidad._usuario = User_Sistema
                objEntidad._apepat = dtPlanilla.Rows(i)(_APE_PAT).ToString
                objEntidad._apemat = dtPlanilla.Rows(i)(_APE_MAT).ToString
                objEntidad._nombres = dtPlanilla.Rows(i)(_NOMBRES).ToString
                objEntidad._sctr_salud = IIf(dtPlanilla.Rows(i)(_SCTR_SALUD) Is DBNull.Value Or dtPlanilla.Rows(i)(_SCTR_SALUD).ToString.Trim = "", 0, dtPlanilla.Rows(i)(_SCTR_SALUD))
                objEntidad._essalud_vida = IIf(dtPlanilla.Rows(i)(_ESSALUD_VIDA) Is DBNull.Value Or dtPlanilla.Rows(i)(_ESSALUD_VIDA).ToString.Trim = "", 0, dtPlanilla.Rows(i)(_ESSALUD_VIDA))
                Dim id_trabajador As Int32
                Select Case tipoboton
                    Case "P"
                        objEntidad._tipoanticipo = "E"
                        id_trabajador = objNegocio.ImportarPlanilla(objEntidad)
                    Case "G"
                        objEntidad._tipoanticipo = "G"
                        id_trabajador = objNegocio.ImportarGratiCts(objEntidad)
                    Case "CTS"
                        objEntidad._tipoanticipo = "CTS"
                        id_trabajador = objNegocio.ImportarGratiCts(objEntidad)
                End Select

                If id_trabajador = 0 Then
                    Dim dr As DataRow
                    dr = dtnoExistente.NewRow
                    dr(0) = objEntidad._documento.Trim
                    dr(1) = objEntidad._nombres.Trim 'objEntidad._apepat.Trim & " " & objEntidad._apemat.Trim & " " & " " & objEntidad._nombres.Trim
                    dtnoExistente.Rows.Add(dr)
                End If
            End If
        Next
    End Sub
    Sub PlanillaPeriodo()
        dtPlanilla = New DataTable
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._tipo = idfrecuenia
        objEntidad._ayo = txtayo.Value
        objEntidad._codcantera = txtcodcantera.Text
        objEntidad._codprov = txtcodcontratista.Text
        If gbquincenal.Visible = True Then
            objEntidad._mes = cmbmesquincena.Value
            objEntidad._quincena = IIf(rdb1quincena.Checked = True, 1, 2)
        ElseIf gbmensual.Visible = True Then
            objEntidad._mes = cmbMes.Value
            objEntidad._quincena = 0
        End If
        'dtPlanilla = objNegocio.ListaPlanillaFechaContratisa(objEntidad)
        dtPlanilla = objNegocio.IngresoPlanillaFecha(objEntidad)
    End Sub
    Sub PlanillaPeriodoGratificacion()
        dtPlanilla = New DataTable
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._tipoanticipo = "G"
        objEntidad._ayo = txtayo.Value
        If gbquincenal.Visible = True Then
            objEntidad._mes = cmbmesquincena.Value
        ElseIf gbmensual.Visible = True Then
            objEntidad._mes = cmbMes.Value
        End If
        objEntidad._codcantera = txtcodcantera.Text
        objEntidad._codprov = txtcodcontratista.Text
        objEntidad._quincena = 0
        dtPlanilla = objNegocio.IngresoGratiCtsFecha(objEntidad)
    End Sub
    Sub PlanillaPeriodoCTS()
        dtPlanilla = New DataTable
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._tipoanticipo = "CTS"
        objEntidad._ayo = txtayo.Value
        If gbquincenal.Visible = True Then
            objEntidad._mes = cmbmesquincena.Value
        ElseIf gbmensual.Visible = True Then
            objEntidad._mes = cmbMes.Value
        End If
        objEntidad._codcantera = txtcodcantera.Text
        objEntidad._codprov = txtcodcontratista.Text
        objEntidad._quincena = 0
        dtPlanilla = objNegocio.IngresoGratiCtsFecha(objEntidad)
    End Sub
    Function validaPeriodoAnticipo() As Boolean
        If Ope = 2 Then Return True
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._tipoanticipo = ""
        objEntidad._ayo = txtayo.Value
        If gbquincenal.Visible = True Then
            objEntidad._mes = cmbmesquincena.Value
            objEntidad._quincena = IIf(rdb1quincena.Checked = True, 1, 2)
        ElseIf gbmensual.Visible = True Then
            objEntidad._mes = cmbMes.Value
            objEntidad._quincena = 0
        End If
        objEntidad._idcontratista = txtidcontratista.Text
        objEntidad._semanaini = 0
        objEntidad._semanafin = 0
        Dim dt As New DataTable
        dt = objNegocio.validaPeriodoPlanilla(objEntidad)
        If dt.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Function validaPeriodoAnticipoGratificacion() As Boolean
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._tipoanticipo = "G"
        objEntidad._ayo = txtayo.Value
        If gbquincenal.Visible = True Then
            objEntidad._mes = cmbmesquincena.Value
        ElseIf gbmensual.Visible = True Then
            objEntidad._mes = cmbMes.Value
        End If
        objEntidad._quincena = 0
        objEntidad._idcontratista = txtidcontratista.Text
        objEntidad._semanaini = 0
        objEntidad._semanafin = 0
        Dim dt As New DataTable
        dt = objNegocio.validaPeriodo(objEntidad)
        If dt.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Function validaPeriodoAnticipoCTS() As Boolean
        If Ope = 2 Then Return True
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._tipoanticipo = "CTS"
        objEntidad._ayo = txtayo.Value
        If gbquincenal.Visible = True Then
            objEntidad._mes = cmbmesquincena.Value
        ElseIf gbmensual.Visible = True Then
            objEntidad._mes = cmbMes.Value
        End If
        objEntidad._quincena = 0
        objEntidad._idcontratista = txtidcontratista.Text
        objEntidad._semanaini = 0
        objEntidad._semanafin = 0
        Dim dt As New DataTable
        dt = objNegocio.validaPeriodo(objEntidad)
        If dt.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Function ValidarExcel(ByVal RUTA As String, ByVal codCantera As String, ByVal tipoboton As String) As Boolean
        Cursor = Cursors.WaitCursor
        'lblmensaje.Visible = True
        'lblmensaje.Text = "Validando datos de libro Excel..."
        'lblmensaje.Refresh()
        Select Case tipoboton

            Case "P"
                If BuscarTexto(RUTA, "CTS") Then Return False
                If BuscarTexto(RUTA, "GRATIFICACION") Then Return False
            Case "G"
                If Not BuscarTexto(RUTA, "GRATIFICACION") Then Return False
            Case "CTS"
                If Not BuscarTexto(RUTA, "CTS") Then Return False
        End Select
        Dim ObjExcel As Microsoft.Office.Interop.Excel.Application
        Dim ObjW As Microsoft.Office.Interop.Excel.Workbook
        ObjExcel = New Microsoft.Office.Interop.Excel.Application
        ObjW = ObjExcel.Workbooks.Open(RUTA)
        Try
            Dim existe As Int32 = 0
            For i As Int32 = 1 To ObjW.Sheets.Count
                If ObjW.Sheets(i).Name = codCantera Then
                    Return True
                End If
            Next
            If existe = 0 Then Exit Function
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ObjW.Close()
            ObjW = Nothing
            ObjExcel.Quit()
            Runtime.InteropServices.Marshal.ReleaseComObject(ObjExcel)
            ObjExcel = Nothing
        End Try
        Return True
    End Function
    Function BuscarTexto(ByVal Texto As String, ByVal Busqueda As String) As Boolean
        Dim i As Integer
        i = InStr(1, Texto.ToUpper, Busqueda)
        If i > 0 Then
            BuscarTexto = True
        Else
            BuscarTexto = False
        End If
    End Function

    Private Sub cmbmes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Fecha_Mes()
        Catch ex As Exception
        End Try
    End Sub
    Sub Fecha_Mes()
        If cmbMes.SelectedIndex < 0 Then
            Exit Sub : MsgBox("Seleccione Mes", MsgBoxStyle.Exclamation, msgComacsa)
        Else
            Dim mes As Int32
            mes = cmbMes.Value
            Dim fecha1 As Date
            Dim fecha2 As Date
            fecha1 = "01/" & mes & "/" & txtayo.Value
            fecha2 = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, fecha1)))
            dtinicio.Value = fecha1
            dtfin.Value = fecha2
        End If
    End Sub
    Sub Fecha_Quincena()
        If cmbmesquincena.SelectedIndex < 0 Then
            MsgBox("Seleccione Mes", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
        Else
            Dim quincena As Int32
            Dim mes As Int32
            mes = cmbmesquincena.Value
            Dim fecha1 As Date
            Dim fechainicio As Date
            Dim fecha2 As Date
            fecha1 = "01/" & mes & "/" & txtayo.Value
            If rdb1quincena.Checked = True Then
                quincena = 1
                fechainicio = fecha1
                fecha2 = "15/" & mes & "/" & txtayo.Value
            Else
                quincena = 2
                fechainicio = "16/" & mes & "/" & txtayo.Value
                fecha2 = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, fecha1)))
            End If
            dtinicio.Value = fechainicio
            dtfin.Value = fecha2
        End If
    End Sub

    Private Sub rdb1quincena_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rdb1quincena.Checked = True Then
            Fecha_Quincena()
        End If
    End Sub

    Private Sub rdb2quincena_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If rdb2quincena.Checked = True Then
            Fecha_Quincena()
        End If
    End Sub
    Sub mostrarPlanilla(ByVal tipoboton As String)
        Try
            'If txtcodcontratista.Text.ToString.Trim = "" Then
            '    MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
            '    txtcodcontratista.Focus()
            '    Exit Sub
            'End If
            'If txtcodcantera.Text.ToString.Trim = "" Then
            '    MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
            '    txtcodcantera.Focus()
            '    Exit Sub
            'End If
            'If Not validaPeriodoAnticipo() Then
            '    MsgBox("El contratista ya generó un anticipo para este periodo", MsgBoxStyle.Exclamation, msgComacsa)
            '    Exit Sub
            'End If
            Select Case tipoboton
                Case "P"
                    PlanillaPeriodo()
                Case "G"
                    PlanillaPeriodoGratificacion()
                Case "CTS"
                    PlanillaPeriodoCTS()
            End Select
            If dtPlanilla.Rows.Count <= 0 Then
                MsgBox("No hay datos para mostrar", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            Else
                If tipoboton = "P" Then
                    gridPlanilla.Visible = True
                    gridGratiCts.Visible = False
                    Call CargarUltraGridxBinding(gridPlanilla, Source1, dtPlanilla)
                ElseIf tipoboton = "G" Then
                    gridPlanilla.Visible = False
                    gridGratiCts.Visible = True
                    Call CargarUltraGridxBinding(gridGratiCts, Source1, dtPlanilla)
                    gridGratiCts.DisplayLayout.Bands(0).Columns("TOTAL").Header.Caption = "GRATIFICACION"
                ElseIf tipoboton = "CTS" Then
                    gridPlanilla.Visible = False
                    gridGratiCts.Visible = True
                    Call CargarUltraGridxBinding(gridGratiCts, Source1, dtPlanilla)
                    gridGratiCts.DisplayLayout.Bands(0).Columns("TOTAL").Header.Caption = "CTS"
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmCargaPlanilla_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtcodcontratista.Focus()
        txtayo.Value = Now.Date.Year
        Dim fecha1 As Date = "01/" & Now.Date.Month & "/" & Now.Date.Year
        Dim fecha2 As Date = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, fecha1)))
        dtinicio.Value = fecha1
        dtfin.Value = fecha2
    End Sub

    Private Sub btncargargrati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncargargrati.Click
        Try
            If txtcodcontratista.Text.ToString.Trim = "" Then
                MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
                txtcodcontratista.Focus()
                Exit Sub
            End If
            If txtcodcantera.Text.ToString.Trim = "" Then
                MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
                txtcodcantera.Focus()
                Exit Sub
            End If
            If idfrecuenia = 4 Then
                If cmbMes.SelectedIndex < 0 Then
                    MsgBox("Seleccione mes", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
                If cmbMes.Value <> 7 And cmbMes.Value <> 12 Then
                    MsgBox("Seleccione mes correcto para Gratificacion", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
            End If
            If idfrecuenia = 3 Then
                If cmbmesquincena.SelectedIndex < 0 Then
                    MsgBox("Seleccione mes", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
                If cmbmesquincena.Value <> 7 And cmbmesquincena.Value <> 12 Then
                    MsgBox("Seleccione mes correcto para Gratificacion", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
            End If
            If Not validaPeriodoAnticipoGratificacion() Then
                MsgBox("El contratista ya generó un anticipo para este periodo", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            PlanillaPeriodoGratificacion()
            If dtPlanilla.Rows.Count > 0 Then
                If MsgBox("¿Ya se cargó una planilla para este periodo desea volver a cargar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            OpenFileDialog1.Filter = "Libro de Excel|*.xls;*.xlsx"
            OpenFileDialog1.FileName = String.Empty
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub
            Dim cadenaExcel As String = Me.OpenFileDialog1.FileName
            Cursor = Cursors.WaitCursor

            If Not ValidarExcel(cadenaExcel, txtcodcantera.Text, "G") Then
                MsgBox("El archivo seleccionado es incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
                Cursor = Cursors.Default
                Return
            End If
            'MsgBox("ENTRANDO A CONEXION OLEDB")
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                          "Data Source= " & cadenaExcel & _
                          ";Extended Properties=""Excel 8.0;HDR=YES"""
            Dim oConn As New OleDbConnection(cs)

            Try
                oConn.Open()
                cargarDatos(oConn, txtcodcantera.Text, 1, "G", cadenaExcel)
                If dtnoExistente.Rows.Count > 0 Then
                    objNegocio = New NGContratista
                    objEntidad = New ETContratista
                    objEntidad._tipodocumento = "01"
                    objEntidad._idcontratista = txtidcontratista.Text
                    objEntidad._codprov = txtcodcontratista.Text
                    objEntidad._codcantera = txtcodcantera.Text
                    objEntidad._ayo = txtayo.Value
                    objEntidad._mes = cmbMes.Value
                    objEntidad._quincena = 0
                    objEntidad._semanaini = 0
                    objEntidad._semanafin = 0
                    objEntidad._usuario = User_Sistema
                    objEntidad._tipoanticipo = "G"
                    objNegocio.EliminaPlanillaPeriodo(objEntidad)
                    MessageBox.Show("El archivo contiene trabajador(es) no registrados en la BD", "Sistema", MessageBoxButtons.OK)
                    Dim frm As New frmnoExistente
                    frm.dtPlanilla = dtnoExistente
                    frm.ShowDialog()
                    Exit Sub
                End If
                MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
                mostrarPlanilla("G")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Ocurrió un error")
                'MsgBox("Archivo incorrecto a ya se encuentra utilizado", MsgBoxStyle.Critical, "Comacsa")
            Finally
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                Cursor = Cursors.Default
                oConn.Close()
                oConn.Dispose()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btncargarcts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncargarcts.Click
        Try
            If txtcodcontratista.Text.ToString.Trim = "" Then
                MsgBox("Ingrese contratista", MsgBoxStyle.Exclamation, msgComacsa)
                txtcodcontratista.Focus()
                Exit Sub
            End If
            If txtcodcantera.Text.ToString.Trim = "" Then
                MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
                txtcodcantera.Focus()
                Exit Sub
            End If
            If idfrecuenia = 4 Then
                If cmbMes.SelectedIndex < 0 Then
                    MsgBox("Seleccione mes", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
                If cmbMes.Value <> 5 And cmbMes.Value <> 11 Then
                    MsgBox("Seleccione mes correcto para CTS", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
            End If
            If idfrecuenia = 3 Then
                If cmbmesquincena.SelectedIndex < 0 Then
                    MsgBox("Seleccione mes", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
                If cmbmesquincena.Value <> 5 And cmbmesquincena.Value <> 11 Then
                    MsgBox("Seleccione mes correcto para CTS", MsgBoxStyle.Exclamation, msgComacsa)
                    Exit Sub
                End If
            End If
            If Not validaPeriodoAnticipoCTS() Then
                MsgBox("El contratista ya generó un anticipo para este periodo", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If

            PlanillaPeriodoCTS()
            If dtPlanilla.Rows.Count > 0 Then
                If MsgBox("¿Ya se cargó una planilla para este periodo desea volver a cargar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            OpenFileDialog1.Filter = "Libro de Excel|*.xls;*.xlsx"
            OpenFileDialog1.FileName = String.Empty
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub
            Dim cadenaExcel As String = Me.OpenFileDialog1.FileName
            Cursor = Cursors.WaitCursor

            If Not ValidarExcel(cadenaExcel, txtcodcantera.Text, "CTS") Then
                MsgBox("El archivo seleccionado es incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
                Cursor = Cursors.Default
                Return
            End If
            'MsgBox("ENTRANDO A CONEXION OLEDB")
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                          "Data Source= " & cadenaExcel & _
                          ";Extended Properties=""Excel 8.0;HDR=YES"""
            Dim oConn As New OleDbConnection(cs)

            Try
                oConn.Open()
                cargarDatos(oConn, txtcodcantera.Text, 1, "CTS", cadenaExcel)
                If dtnoExistente.Rows.Count > 0 Then
                    objNegocio = New NGContratista
                    objEntidad = New ETContratista
                    objEntidad._tipodocumento = "01"
                    objEntidad._idcontratista = txtidcontratista.Text
                    objEntidad._codprov = txtcodcontratista.Text
                    objEntidad._codcantera = txtcodcantera.Text
                    objEntidad._ayo = txtayo.Value
                    objEntidad._mes = cmbMes.Value
                    objEntidad._quincena = 0
                    objEntidad._semanaini = 0
                    objEntidad._semanafin = 0
                    objEntidad._usuario = User_Sistema
                    objEntidad._tipoanticipo = "CTS"
                    objNegocio.EliminaPlanillaPeriodo(objEntidad)
                    MessageBox.Show("El archivo contiene trabajador(es) no registrados en la BD", "Sistema", MessageBoxButtons.OK)
                    Dim frm As New frmnoExistente
                    frm.dtPlanilla = dtnoExistente
                    frm.ShowDialog()
                    Exit Sub
                End If
                MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
                mostrarPlanilla("CTS")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Ocurrió un error")
                'MsgBox("Archivo incorrecto a ya se encuentra utilizado", MsgBoxStyle.Critical, "Comacsa")
            Finally
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                Cursor = Cursors.Default
                oConn.Close()
                oConn.Dispose()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class