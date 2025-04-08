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

Public Class FrmReporteCostCantera
    Public Ls_Permisos As New List(Of Integer)
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Dim opcion As String

    Private Sub FrmReporteCostCanteral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Date.Year
        cmbMes.Value = Now.Date.Month
        cmbMesF.Value = Now.Date.Month
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Reporte()
    End Sub
    Sub Reporte()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto

            _objEntidad.Accion = opcion
            _objEntidad.Anho = txtayo.Value
            If opcion = 1 Then
                _objEntidad.Mes = cmbMes.Value
                _objEntidad.Mes1 = cmbMesF.Value
            Else
                _objEntidad.Mes = 0
                _objEntidad.Mes1 = 0
            End If

           


            Dim dtDatos As New DataTable

            dtDatos = _objNegocio.Costo_ReporteCanteras(_objEntidad)

            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
            Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

            Try
                exLibro = exApp.Workbooks.Add()
                exHoja = exLibro.Worksheets.Add()
                Dim nfila As Integer

                exHoja.Cells.Item(1, 1) = "Cod. Cantera"
                exHoja.Cells.Item(1, 2) = "Cantera"
                exHoja.Cells.Item(1, 3) = "Toneladas"
                exHoja.Cells.Item(1, 4) = "Importe"
                exHoja.Cells.Item(1, 5) = "Unidad Económica"
                exHoja.Cells.Item(1, 6) = "Porcentaje"
                exHoja.Cells.Item(1, 7) = "Importe2"
                exHoja.Cells.Item(1, 8) = "Importe3"
                exHoja.Cells.Item(1, 9) = "Importe4"
                exHoja.Cells.Item(1, 10) = "Cuenta"
                exHoja.Cells.Item(1, 11) = "Costo Mineral"
                exHoja.Cells.Item(1, 12) = "Costo Lima"
                exHoja.Cells.Item(1, 13) = "Costo Uea"
                exHoja.Cells.Item(1, 14) = "Costo Cantera Sub"

                nfila = 2
                Dim fila_fin As String
                fila_fin = Convert.ToString(dtDatos.Rows.Count + 2)
                With exHoja
                    .Activate()
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        .Range("A" & nfila + i).Value = "'" & dtDatos.Rows(i)("Codcantera")
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("cantera")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("Toneladas")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("Importe")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("Descripcion")
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("Porcentaje")
                        .Range("G" & nfila + i).Value = dtDatos.Rows(i)("Importe2")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("Importe3")
                        .Range("I" & nfila + i).Value = dtDatos.Rows(i)("Importe4")
                        .Range("J" & nfila + i).Value = dtDatos.Rows(i)("cuenta")
                        .Range("K" & nfila + i).Value = dtDatos.Rows(i)("Costo_mineral")
                        .Range("L" & nfila + i).Value = dtDatos.Rows(i)("Costo_Lima")
                        .Range("M" & nfila + i).Value = dtDatos.Rows(i)("Costo_Uea")
                        .Range("N" & nfila + i).Value = dtDatos.Rows(i)("Costo_Cantera_Sub")

                    Next

                    .Range("A" & fila_fin).Value = "TOTAL"
                    .Range("A" & fila_fin).Font.Bold = 1
                    .Range("A" & fila_fin & ":B" & fila_fin).Merge()

                    .Range("C" & fila_fin).Value = "=SUMA(C2:C" & dtDatos.Rows.Count + 1 & ")"
                    .Range("D" & fila_fin).Value = "=SUMA(D2:D" & dtDatos.Rows.Count + 1 & ")"

                    .Range("F" & fila_fin).Value = "=SUMA(F2:F" & dtDatos.Rows.Count + 1 & ")"
                    .Range("G" & fila_fin).Value = "=SUMA(G2:G" & dtDatos.Rows.Count + 1 & ")"
                    .Range("H" & fila_fin).Value = "=SUMA(H2:H" & dtDatos.Rows.Count + 1 & ")"
                    .Range("I" & fila_fin).Value = "=SUMA(I2:I" & dtDatos.Rows.Count + 1 & ")"

                    .Range("K" & fila_fin).Value = "=SUMA(K2:K" & dtDatos.Rows.Count + 1 & ")"
                    .Range("L" & fila_fin).Value = "=SUMA(L2:L" & dtDatos.Rows.Count + 1 & ")"
                    .Range("M" & fila_fin).Value = "=SUMA(M2:M" & dtDatos.Rows.Count + 1 & ")"
                    .Range("N" & fila_fin).Value = "=SUMA(N2:N" & dtDatos.Rows.Count + 1 & ")"

                End With
                exHoja.Rows.Item(1).Font.Bold = 1
                exHoja.Rows.HorizontalAlignment = 3
                exHoja.Columns.AutoFit()
                exHoja.Columns.HorizontalAlignment = 2
                exApp.Visible = True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar Excel")
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub rbtOpcion1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtOpcion1.CheckedChanged
        If rbtOpcion1.Checked = True Then
            rbtOpcion2.Checked = False
            opcion = 1
        End If
    End Sub

    Private Sub rbtOpcion2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtOpcion2.CheckedChanged
        If rbtOpcion2.Checked = True Then
            rbtOpcion1.Checked = False
            opcion = 2
        End If
    End Sub

    Private Sub cmbMesF_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMesF.ValueChanged
        If cmbMesF.SelectedIndex < cmbMes.SelectedIndex Then
            MsgBox("El mes final de la consulta, debe ser mayor o igual al inicial", MsgBoxStyle.Exclamation, "Validación")
            cmbMesF.Value = 12
        End If
    End Sub
End Class