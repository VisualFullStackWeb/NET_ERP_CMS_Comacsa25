Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Imports System.IO
Public Class frmCargaUnacem
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

    Private Sub frmCargaUnacem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFecha.Value = Now.Date
        txtAño.Value = Now.Date.Year
    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Try
            'Dim dtDatos As New DataTable
            'objNegocio = New NGContratista
            'objEntidad = New ETContratista
            'objEntidad.Fecha = dtFecha.Value
            'dtDatos = objNegocio.ValidaCargaUnacem(objEntidad)
            'If dtDatos.Rows.Count > 0 Then
            '    If MsgBox("Ya existe una carga para la fecha seleccionada" & vbLf & "¿Desea continuar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            'End If

            OpenFileDialog1.Filter = "Libro de Excel|*.xls;*.xlsx"
            OpenFileDialog1.FileName = String.Empty
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub
            Dim cadenaExcel As String = Me.OpenFileDialog1.FileName
            Cursor = Cursors.WaitCursor

            'If Not ValidarExcel(cadenaExcel) Then
            '    MsgBox("El archivo seleccionado es incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
            '    Cursor = Cursors.Default
            '    lblmensaje.Visible = False
            '    lblmensaje.Refresh()
            '    Exit Sub
            'End If
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                        "Data Source= " & cadenaExcel & _
                        ";Extended Properties=""Excel 8.0;HDR=YES"""
            Dim oConn As New OleDbConnection(cs)
            Try
                oConn.Open()
                cargarDatos(oConn, cadenaExcel)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Ocurrió un error")
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

    Sub cargarDatos(ByVal oConn As OleDbConnection, ByVal cadenaExcel As String)
        Try
            Dim Ls_datos = New List(Of ETProveedorFiscalizado)
            Dim DtSet As New System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyCommand = New System.Data.OleDb.OleDbDataAdapter _
            ("select * from [FORMATO$A8:Z1000]", oConn)
            MyCommand.TableMappings.Add("Table", "Tabla")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            Dim cont As Int32 = 1
            Dim dtDatos As New DataTable
            dtDatos = DtSet.Tables(0)

            lblmensaje.Text = "Validando datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim codigo_transp As String = ""
            For i As Int32 = 0 To dtDatos.Rows.Count - 1
                codigo_transp = dtDatos.Rows(i)("CODIGO_TRANSPORTISTA").ToString.Trim
                If codigo_transp = "" Then Exit For
                If codigo_transp <> "" Then
                    Dim fecha_cantera As String = dtDatos.Rows(i)("FECHA_SALIDA_CANTERA").ToString.Trim
                    If fecha_cantera = "" Then MsgBox("Ingrese fecha salida de cantera en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim cod_mineral As String = dtDatos.Rows(i)("CODIGO_MINERAL").ToString.Trim
                    If cod_mineral = "" Then MsgBox("Ingrese codigo de mineral en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim placa As String = dtDatos.Rows(i)("PLACA_TRACTO").ToString.Trim
                    If placa = "" Then MsgBox("Ingrese placa en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim placa_2 As String = dtDatos.Rows(i)("PLACA_CARRETA").ToString.Trim
                    'If placa_2 = "" Then MsgBox("Ingrese placa en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim dni As String = dtDatos.Rows(i)("DNI_CONDUCTOR").ToString.Trim
                    If dni = "" Then MsgBox("Ingrese dni en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    If dni.Length < 8 Then MsgBox("Ingrese dni correcto en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim serie As String = dtDatos.Rows(i)("SERIE_GUIA_COMACSA").ToString.Trim
                    If serie = "" Then MsgBox("Ingrese serie documento en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim numero As String = dtDatos.Rows(i)("NUMERO_GUIA_COMACSA").ToString.Trim
                    If numero = "" Then MsgBox("Ingrese numero documento en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim peso_bruto As Double = dtDatos.Rows(i)("PESO_BRUTO")
                    Dim peso_tara As Double = dtDatos.Rows(i)("PESO_TARA").ToString.Trim
                    If peso_tara > peso_bruto Then MsgBox("El peso tara no puede exceder al peso bruto en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim peso_neto As Double = dtDatos.Rows(i)("PESO_NETO").ToString.Trim
                    If peso_neto <> peso_bruto - peso_tara Then MsgBox("El peso neto es incorrecto en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim serie_transp As String = dtDatos.Rows(i)("SERIE_GUIA_TRANSPORTISTA").ToString.Trim
                    If serie = "" Then MsgBox("Ingrese serie transportista documento en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim numero_transp As String = dtDatos.Rows(i)("NUMERO_TRANSPORTISTA").ToString.Trim
                    If numero_transp = "" Then MsgBox("Ingrese numero transportista documento en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim constancia As String = dtDatos.Rows(i)("N_CVPM").ToString.Trim
                    If constancia = "" Then MsgBox("Ingrese constancia de pesos y medidas en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim fecha_proceso As String = dtDatos.Rows(i)("FECHA_INGRESO_UNACEM").ToString.Trim
                    If fecha_proceso = "" Then MsgBox("Ingrese fecha de proceso en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                    Dim doc_fisico As String = dtDatos.Rows(i)("DOCUMENTOS_ENTREGADOS_FISICO").ToString.Trim
                    If doc_fisico <> "SI" And doc_fisico <> "NO" Then MsgBox("Debe ingresar solo SI o NO para el ingreso de documentos fisicos en la fila " & i + 9, MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
                End If
            Next



            lblmensaje.Text = "Cargando datos de libro Excel..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()

            objNegocio = New NGContratista
            objNegocio.CargaUnacem(dtDatos, User_Sistema, txtAño.Value)

            'COPIAMOS UNA COPIA DEL ARCHIVO EN EL SERVIDOR            
            Dim RUTA As String = RutaReportes_UNCAEM & "\REPORTE_UNACEM_" & txtAño.Value & ".xlsx"
            If File.Exists(RUTA) Then
                File.Delete(RUTA)
            End If
            File.Copy(cadenaExcel, RUTA)

            MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
            procesar()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try

    End Sub

    Sub Reporte()
        Try
            Dim RUTA As String = RutaReportes_UNCAEM & "\REPORTE_UNACEM_" & txtAño.Value & ".xlsx"
            Process.Start(RUTA)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub procesar()
        lblmensaje.Text = "Procesando Datos..."
        lblmensaje.Visible = True
        lblmensaje.Update()
        Try
            Dim dtDatos As New DataSet
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad.Fecha = dtFecha.Value
            objEntidad.Anho = txtAño.Value
            dtDatos = objNegocio.ListaCargaUnacem(objEntidad)
            Dim dtINgMin As New DataTable
            Dim dtINgRee As New DataTable
            Dim dtSalMin As New DataTable
            Dim dtGUComaca As New DataTable
            Dim dtIPesaje As New DataTable
            dtINgMin = dtDatos.Tables(0)
            dtINgRee = dtDatos.Tables(1)
            dtSalMin = dtDatos.Tables(2)
            dtGUComaca = dtDatos.Tables(3)
            dtIPesaje = dtDatos.Tables(4)

            Call CargarUltraGridxBinding(UltraGrid1, Source1, dtINgMin)
            Call CargarUltraGridxBinding(UltraGrid2, Source2, dtINgRee)
            Call CargarUltraGridxBinding(UltraGrid3, Source3, dtSalMin)
            Call CargarUltraGridxBinding(UltraGrid4, Source4, dtGUComaca)
            Call CargarUltraGridxBinding(UltraGrid5, Source5, dtIPesaje)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Update()
        End Try


    End Sub

    Private Sub dtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFecha.ValueChanged
        Try
            'procesar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtAño_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAño.ValueChanged
        Try
            procesar()
        Catch ex As Exception

        End Try
    End Sub
End Class