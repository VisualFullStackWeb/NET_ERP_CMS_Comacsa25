Public Class FrmCFormulacion

#Region "Declarar Variables"

    Public Ls_Permisos As New List(Of Integer)

#End Region

    Private Sub FrmCFormulacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txt_agno.Value = Now.Year
        cmbMes.Value = Now.Month

    End Sub

    Private Sub txt_codproducto_EditorButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles txt_codproducto.EditorButtonClick

        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Producto_Terminado
        frmHijo.ShowDialog()
        txt_codproducto.Text = frmHijo.Flag2
        lbl_descrip_producto.Text = frmHijo.Descripcion
        frmHijo = Nothing

    End Sub

    Private Sub txt_molino_EditorButtonClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles txt_molino.EditorButtonClick
        Dim frmHijo As New frmBuscar
        frmHijo.Formulario = frmBuscar.eState.frm_Catalogo_molino
        frmHijo.ShowDialog()
        txt_molino.Text = frmHijo.Flag2
        lbl_descrip_molino.Text = frmHijo.Descripcion
        frmHijo = Nothing
    End Sub

    Sub Procesar()

        Call Reporte()

    End Sub

    Private Sub Reporte()
        Try

       
            Dim dt_rpt As DataTable = Negocio.Producto.Consultar_Formulaciones(txt_codproducto.Text, txt_molino.Text, txt_agno.Value, cmbMes.Value)
            Dim dr_fila As DataRow

            If dt_rpt.Rows.Count = 0 Then
                MsgBox("No existen Reegistros para el Periodo Indicado", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            lblmensaje.Visible = True
            lblmensaje.Text = "Generando Reporte..."
            lblmensaje.Refresh()
            lblmensaje.Update()
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            Dim archivo_excel As New Microsoft.Office.Interop.Excel.Application
            Dim libro_excel As Microsoft.Office.Interop.Excel.Workbook = Nothing
            Dim h_hoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing
            Dim s_nombre_mes As String = cmbMes.Text
            Dim s_agno As String = txt_agno.Value
            Dim i_fila_excel As Integer = 7

            Dim s_cod_molino As String = ""
            Dim s_cod_producto As String = ""
            Dim s_letra_col_fin As String = "F"

            libro_excel = archivo_excel.Workbooks.Add
            h_hoja = libro_excel.Worksheets.Add
            h_hoja.Visible = True : h_hoja.Activate()

            h_hoja.Cells.Select()
            h_hoja.Cells.Font.Size = 9
            h_hoja.Application.ActiveWindow.DisplayGridlines = False

            ''**************************
            ''poner titulo general 
            ''**************************
            h_hoja.Cells(1, 1).value = "Cia. Minera Agregados Calcareos S.A."
            ''h_hoja.Cells(2, 1).value = "RUC: " & CIA_AUX_RUC
            h_hoja.Cells.Range(s_letra_col_fin & "1").Value = "FECHA: " & Format(Now, "dd/MM/yyyy HH:mm")
            h_hoja.Cells.Range(s_letra_col_fin & "1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            h_hoja.Cells(2, 1).value = "REPORTE DE FORMULACIONES"
            h_hoja.Cells(3, 1).value = s_nombre_mes & " del " & s_agno

            ''**************************
            ''combinar titulo y subtitulo
            ''**************************
            h_hoja.Range("A2", s_letra_col_fin & "2").Merge()
            h_hoja.Range("A3", s_letra_col_fin & "3").Merge()
            h_hoja.Range("A2", s_letra_col_fin & "2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            h_hoja.Range("A3", s_letra_col_fin & "3").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            ''TAMAÑO DEL TITULO
            h_hoja.Range("A3", s_letra_col_fin & "3").Font.Size = 14
            h_hoja.Range("A4", s_letra_col_fin & "2").Font.Size = 14
            h_hoja.Range("A4", s_letra_col_fin & "5").Font.Size = 14

            ''**************************
            ''poner en negrita toda la cabecera
            ''**************************
            h_hoja.Range("A1:" & s_letra_col_fin & "7").Font.Bold = True


            ''titulos de columnas
            h_hoja.Cells(6, 1).value = "CODIGO"
            h_hoja.Cells(6, 2).value = "DESCRIPCION"
            h_hoja.Cells(6, 3).value = "TIPO"
            h_hoja.Cells(6, 4).value = "CODIGO"
            h_hoja.Cells(6, 5).value = "DESCRIPCION"
            h_hoja.Cells(6, 6).value = "PORCENTAJE"

            ''**************************
            ''poner tamaños a las columnas
            ''**************************
            h_hoja.Columns("E:E").ColumnWidth = 35
            ''h_hoja.Range("B7", s_letra_col_fin & "8").ColumnWidth = 18


            ' ''**************************
            ' ''centrar titulos
            ' ''**************************
            h_hoja.Range("A6", s_letra_col_fin & "7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            Call poner_marco_a_rango_excel(h_hoja, "A", s_letra_col_fin, 6, 6)


            ''**************************
            ''pintar el detalle
            ''**************************
            For i_fila As Integer = 0 To dt_rpt.Rows.Count - 1
                dr_fila = dt_rpt.Rows(i_fila)

                If s_cod_producto <> dr_fila.Item("codproducto").ToString Then
                    i_fila_excel += 2
                    h_hoja.Cells(i_fila_excel, 1).value = "'" & dr_fila.Item("codproducto").ToString
                    h_hoja.Cells(i_fila_excel, 2).value = dr_fila.Item("descrip_producto").ToString
                    h_hoja.Range("A" & i_fila_excel & ":" & s_letra_col_fin & i_fila_excel).Font.Bold = True
                    s_cod_producto = dr_fila.Item("codproducto").ToString
                    s_cod_molino = ""
                End If

                If s_cod_molino <> dr_fila.Item("codmolino").ToString Then
                    i_fila_excel += 1
                    h_hoja.Cells(i_fila_excel, 1).value = "'" & dr_fila.Item("codmolino").ToString
                    h_hoja.Cells(i_fila_excel, 2).value = dr_fila.Item("descrip_molino").ToString
                    s_cod_molino = dr_fila.Item("codmolino").ToString
                End If

                i_fila_excel += 1
                h_hoja.Cells(i_fila_excel, 3).value = dr_fila.Item("descrip_tipo").ToString
                h_hoja.Cells(i_fila_excel, 4).value = "'" & dr_fila.Item("codruma").ToString
                If dr_fila.Item("cod_tipo").ToString = "P" Then
                    h_hoja.Cells(i_fila_excel, 5).value = dr_fila.Item("descrip_producto_detalle").ToString
                ElseIf dr_fila.Item("cod_tipo").ToString = "R" Then
                    h_hoja.Cells(i_fila_excel, 5).value = dr_fila.Item("descrip_ruma_detalle").ToString
                Else
                    h_hoja.Cells(i_fila_excel, 5).value = dr_fila.Item("descrip_suministro_detalle").ToString
                End If
                h_hoja.Cells(i_fila_excel, 6).value = dr_fila.Item("porcentaje").ToString

                ''i_fila_excel += 1

            Next

            h_hoja.Range("F8", "F" & i_fila_excel).NumberFormat = "#,###,###,##0.00"

            dt_rpt.Dispose()

            archivo_excel.Visible = True

            Me.Cursor = System.Windows.Forms.Cursors.Default
            libro_excel = Nothing
            archivo_excel = Nothing
        Catch ex As Exception
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
        End Try


    End Sub

    Public Sub poner_marco_a_rango_excel(ByVal p_hoja As Microsoft.Office.Interop.Excel.Worksheet, ByVal p_letra_columna_inicio As String, ByVal p_letra_columna_final As String, ByVal p_fila_desde As Integer, ByVal p_fila_hasta As Integer)

        p_hoja.Range(p_letra_columna_inicio & p_fila_desde, p_letra_columna_final & p_fila_hasta).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        p_hoja.Range(p_letra_columna_inicio & p_fila_desde, p_letra_columna_final & p_fila_hasta).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone
        p_hoja.Range(p_letra_columna_inicio & p_fila_desde, p_letra_columna_final & p_fila_hasta).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlLineStyleNone

    End Sub

    Private Sub txt_codproducto_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_codproducto.KeyUp
        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then
            txt_codproducto.Text = ""
            lbl_descrip_producto.Text = ""
        End If
    End Sub

    Private Sub txt_molino_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_molino.KeyUp
        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then
            txt_molino.Text = ""
            lbl_descrip_molino.Text = ""
        End If
    End Sub

End Class
