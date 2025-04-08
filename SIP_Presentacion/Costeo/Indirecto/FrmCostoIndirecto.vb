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
Public Class FrmCostoIndirecto
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Public ConceptoSeleccionado As String
    Public filtroDescripcion As String = String.Empty
#End Region
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Dim cierre As Int32

    Private Sub FrmCostoIndirecto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Year(Now.Date)
        txtayo1.Value = Year(Now.Date)
        cmbMes.Value = Now.Date.Month
        txtayo2.Value = Year(Now.Date)
        cmbMes1.Value = Now.Date.Month
        Procesar()
        EnergiaGas()
    End Sub
    Sub EnergiaGas()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            Dim dtDatos As New DataTable
            _objEntidad.Anho = txtayo1.Value
            _objEntidad.Mes = cmbMes.Value
            dtDatos = _objNegocio.Costo_ListaEnergiaGas(_objEntidad)
            Call CargarUltraGridxBinding(Me.gridEnergiaGas, Source5, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Sub Agua()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            Dim dtDatos As New DataTable
            _objEntidad.Anho = txtayo2.Value
            _objEntidad.Mes = cmbMes1.Value
            dtDatos = _objNegocio.Costo_ListaAgua(_objEntidad)
            Call CargarUltraGridxBinding(Me.gridAgua, Source5, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Sub Procesar()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            Dim dtDatos As New DataSet
            dtDatos = _objNegocio.Costo_Indirecto(_objEntidad)
            Call CargarUltraGridxBinding(Me.gridnoconsiderar, Source1, dtDatos.Tables(0))
            Call CargarUltraGridxBinding(Me.gridcostoequipo, Source2, dtDatos.Tables(1))
            Call CargarUltraGridxBinding(Me.gridporproducc, Source3, dtDatos.Tables(2))
            Call CargarUltraGridxBinding(Me.gridactivotipo, Source4, dtDatos.Tables(3))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub btnagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregar.Click
        Try
            Dim frm As New FrmCuentaCosto
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = Year(Now.Date)
            frm.dtDatos = _objNegocio.Costo_ListaCuentas(_objEntidad)

            Dim resul As DialogResult
            resul = frm.ShowDialog()
            Dim cod_cuenta As String
            If resul = Windows.Forms.DialogResult.OK Then
                cod_cuenta = frm.gridCuenta.ActiveRow.Cells("codCuenta").Value

                If MsgBox("Desea registrar cuenta?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Exit Sub
                End If

                _objNegocio = New NGProducto
                _objEntidad = New ETProducto
                _objEntidad.Tipo = 1
                _objEntidad.Cuenta = cod_cuenta
                _objEntidad.Usuario = User_Sistema
                Dim dtDatos As New DataTable
                dtDatos = _objNegocio.Costo_RegistraCuenta(_objEntidad)
                MsgBox("Cambios realizados correctamente", MsgBoxStyle.Information, msgComacsa)
                Procesar()
            End If

            'gridAreaCuenta.Rows(gridAreaCuenta.ActiveRow.Index).Cells("Cuenta").Value = Cuenta
        Catch ex As Exception
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Try
            If gridnoconsiderar.ActiveRow.Index < 0 Then Exit Sub
            If MsgBox("Desea eliminar cuenta?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Tipo = 3
            _objEntidad.Cuenta = gridnoconsiderar.ActiveRow.Cells("cgcod").Value
            _objEntidad.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RegistraCuenta(_objEntidad)
            MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
            Procesar()
            'gridAreaCuenta.Rows(gridAreaCuenta.ActiveRow.Index).Cells("Cuenta").Value = Cuenta
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnagregar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregar2.Click
        Try
            Dim frm As New FrmCostoEquipo
            Dim resul As DialogResult
            resul = frm.ShowDialog()
            Dim placa As String
            Dim cod_clase As String
            If resul = Windows.Forms.DialogResult.OK Then
                placa = frm.gridCuenta.ActiveRow.Cells("placa").Value
                cod_clase = frm.gridCuenta.ActiveRow.Cells("cod_clase").Value
                If MsgBox("Desea registrar equipo?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                    Exit Sub
                End If

                _objNegocio = New NGProducto
                _objEntidad = New ETProducto
                _objEntidad.Tipo = 1
                _objEntidad.Placa = placa
                _objEntidad.codClase = cod_clase
                _objEntidad.Usuario = User_Sistema
                Dim dtDatos As New DataTable
                dtDatos = _objNegocio.Costo_RegistraCostEquipo(_objEntidad)
                MsgBox("Cambios realizados correctamente", MsgBoxStyle.Information, msgComacsa)
                Procesar()
            End If

            'gridAreaCuenta.Rows(gridAreaCuenta.ActiveRow.Index).Cells("Cuenta").Value = Cuenta
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btneliminar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar2.Click
        Try
            If gridcostoequipo.ActiveRow.Index < 0 Then Exit Sub
            If MsgBox("Desea eliminar equipo?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If

            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Tipo = 3
            _objEntidad.Placa = gridcostoequipo.ActiveRow.Cells("Placa").Value
            _objEntidad.codClase = gridcostoequipo.ActiveRow.Cells("proceso").Value
            _objEntidad.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Costo_RegistraCostEquipo(_objEntidad)
            MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
            Procesar()

            'gridAreaCuenta.Rows(gridAreaCuenta.ActiveRow.Index).Cells("Cuenta").Value = Cuenta
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridporproducc_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridporproducc.InitializeLayout

    End Sub

    Private Sub gridporproducc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridporproducc.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            If Not (sender Is gridporproducc) Then Return
            With sender
                Select Case e.KeyValue
                    Case Keys.Up
                        .PerformAction(ExitEditMode)
                        .PerformAction(AboveCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Down
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Right
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Left
                        .PerformAction(ExitEditMode)
                        .PerformAction(PrevCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Return
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        'btnAgregar.Enabled = True
                End Select
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Try
            If MsgBox("Desea registrar cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If

            For i As Int32 = 0 To gridporproducc.Rows.Count - 1
                _objNegocio = New NGProducto
                _objEntidad = New ETProducto
                _objEntidad.Anho = txtayo.Value
                _objEntidad.ID = gridporproducc.Rows(i).Cells("idclase").Value
                _objEntidad.Monto = gridporproducc.Rows(i).Cells("porc").Value
                Dim dtDatos As New DataTable
                dtDatos = _objNegocio.Costo_RegistraPorcProduccion(_objEntidad)
            Next
            MsgBox("Cambios realizados correctamente", MsgBoxStyle.Information, msgComacsa)
            PorcentajeAyo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtayo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtayo.ValueChanged
        PorcentajeAyo()
    End Sub
    Sub PorcentajeAyo()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            Dim dtDatos As New DataTable
            _objEntidad.Anho = txtayo.Value
            dtDatos = _objNegocio.Costo_ListaPorcAyo(_objEntidad)
            Call CargarUltraGridxBinding(Me.gridporproducc, Source3, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub gridactivotipo_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridactivotipo.DoubleClickRow
        Try
            If gridactivotipo.ActiveRow.Index < 0 Then Exit Sub
            Dim frm As New FrmCostIngresoActivo
            frm.txtplaca.Text = gridactivotipo.ActiveRow.Cells("Placa").Value
            frm.txtmodelo.Text = gridactivotipo.ActiveRow.Cells("modelo").Value
            frm._idtipo = gridactivotipo.ActiveRow.Cells("idtipo").Value
            Dim resul As DialogResult
            resul = frm.ShowDialog
            If resul = Windows.Forms.DialogResult.OK Then
                MsgBox("Cambios realizados correctamente", MsgBoxStyle.Information, msgComacsa)
                Procesar()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim frm As New FrmIngresoReciboEnerGas
            frm.ayo = txtayo1.Value
            frm.mes = cmbMes.Value
            Dim resul As DialogResult
            resul = frm.ShowDialog()
            If resul = Windows.Forms.DialogResult.OK Then
                MsgBox("Proceso realizado correctamente", MsgBoxStyle.Information, msgComacsa)
                EnergiaGas()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            EnergiaGas()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btneliminarrec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminarrec.Click
        Try
            If gridEnergiaGas.ActiveRow.Index < 0 Then Exit Sub
            If MsgBox("Desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Operacion = 3
            _objEntidad.TipoRecibo = gridEnergiaGas.ActiveRow.Cells("tipo").Value
            _objEntidad.Anho = txtayo1.Value
            _objEntidad.Mes = cmbMes.Value
            _objEntidad.tipodoc = gridEnergiaGas.ActiveRow.Cells("tipo_doc").Value
            _objEntidad.seriedoc = gridEnergiaGas.ActiveRow.Cells("serie_doc").Value
            _objEntidad.numdoc = gridEnergiaGas.ActiveRow.Cells("numdoc").Value
            _objEntidad.Cantidad = 0
            _objEntidad.Monto = 0
            _objEntidad.Observacion = ""

            Dim dtResul As New DataTable
            dtResul = _objNegocio.Costo_IngresoEnergiaGas(_objEntidad)

            MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
            EnergiaGas()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim frm As New FrmIngresoReciboAgua
            frm.ayo = txtayo2.Value
            frm.mes = cmbMes1.Value
            Dim resul As DialogResult
            resul = frm.ShowDialog()
            If resul = Windows.Forms.DialogResult.OK Then
                MsgBox("Proceso realizado correctamente", MsgBoxStyle.Information, msgComacsa)
                Agua()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmbMes1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes1.ValueChanged
        Try
            Agua()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If gridEnergiaGas.ActiveRow.Index < 0 Then Exit Sub
            If MsgBox("Desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Exit Sub
            End If
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Operacion = 3
            _objEntidad.TipoRecibo = gridAgua.ActiveRow.Cells("tipo").Value
            _objEntidad.Anho = txtayo2.Value
            _objEntidad.Mes = cmbMes1.Value
            _objEntidad.tipodoc = gridAgua.ActiveRow.Cells("tipo_doc").Value
            _objEntidad.seriedoc = gridAgua.ActiveRow.Cells("serie_doc").Value
            _objEntidad.numdoc = gridAgua.ActiveRow.Cells("numdoc").Value
            _objEntidad.Cantidad = 0
            _objEntidad.Monto = 0
            _objEntidad.Observacion = ""

            Dim dtResul As New DataTable
            dtResul = _objNegocio.Costo_IngresoEnergiaGas(_objEntidad)

            MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
            Agua()
        Catch ex As Exception

        End Try
    End Sub

    Sub Reporte()
        If gridnoconsiderar.Rows.Count <= 0 Then
            MsgBox("No existen datos a exportar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        Dim rpta As Long
        Dim ruta As String = Application.StartupPath & "\COSTO_CUENTA_NOCONSIDERAR.xls"
        Dim archivoexcel As String = Trim(ruta)
        Try
            If Trim(Dir(Trim(ruta), vbArchive)) <> "" Then
                rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If rpta = vbNo Then Exit Sub
            End If
            Me.UltraGridExcelExporter1.Export(gridnoconsiderar, ruta)
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
            h_hoja.Range("A3:B3").Merge()
            h_hoja.Range("A3:B3").Font.Bold = True
            h_hoja.Range("A3:B3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A2:C2").Font.Bold = True
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            h_hoja.Cells(2, 1).value = "CUENTAS A NO CONSIDERAR EN EL COSTEO"
        Catch ex As Exception
            MsgBox("Error al Insertar Cabecera del Archivo" & vbCrLf & ex.Message.ToString)
        End Try

        libro_excel.Save()
        libro_excel.Close()
        libro_excel = Nothing

        archivo_excel.Quit()
        archivo_excel = Nothing

    End Sub
    Private Sub Abrir_Archivo(ByVal ruta As String)
        Dim xApp As Object
        Dim xLibros As Object
        Dim xLibro As Object
        Dim archivoexcel As String = Trim(ruta)
        xApp = CreateObject("excel.application")
        xLibros = xApp.Workbooks
        xLibros.Open(archivoexcel, 3)
        xLibro = xApp.ActiveWorkBook
        xApp.Visible = True
    End Sub

End Class