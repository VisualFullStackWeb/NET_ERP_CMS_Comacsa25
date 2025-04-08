Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports System.Drawing.Printing
Imports Microsoft.Office.Interop
Public Class frmConsultaProgramacion
#Region "Declarar Variables"
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
#End Region

    Private Sub frmConsultaProgramacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFecha.Value = Now.Date
        Procesar()
    End Sub
    Sub Procesar()
        Dim dtProgramacion As New DataTable
        Entidad.Contratista = New ETContratista
        Entidad.Contratista.TipoOperacion = Ope
        Negocio.NContratista = New NGContratista
        Entidad.MyLista = New ETMyLista
        Entidad.Contratista.Usuario = User_Sistema
        Entidad.Contratista._codprov = txtcodprov.Text
        Entidad.Contratista.Fecha = dtpFecha.Value
        Entidad.Contratista.NroViaje = nupviaje.Value
        dtProgramacion = Negocio.NContratista.Listar_PRO_ConsultaProgramacion(Entidad.Contratista)
        Call CargarUltraGridxBinding(Me.gridProgramacion, Source1, dtProgramacion)
    End Sub
    Sub Buscar()
        Dim frm As New FrmListaTransportista
        frm.ShowDialog()
        txtcodprov.Text = codMotivodetalle.Trim
        txtproveedor.Text = Motivodetalle.Trim
        Procesar()
        'txtruc.Text = Ruc.Trim
    End Sub

    Private Sub txtcodprov_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodprov.KeyDown
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
            Procesar()
        End If
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Try
            Procesar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub nupviaje_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nupviaje.ValueChanged
        Try
            Procesar()
        Catch ex As Exception

        End Try
    End Sub
    Sub Reporte()
        exportar()
    End Sub
    Sub exportar()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try

            If gridProgramacion.Rows.Count > 0 Then
                Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\CONSULTAPROGRAMACION.xls")
                File.Copy(RutaReporteERP & "PLANTILLACONSULTAPROGRAMACION.xls", path & "\CONSULTAPROGRAMACION.xls")
                m_Excel.Workbooks.Open(path & "\CONSULTAPROGRAMACION.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 7
                nfilaini = 7

                With objHojaExcel
                    .Activate()
                    Dim viaje As String = ""
                    Select Case CInt(nupviaje.Value)
                        Case Is = 1
                            viaje = "1ER VIAJE"
                        Case Is = 2
                            viaje = "2DO VIAJE"
                        Case Is = 3
                            viaje = "3ER VIAJE"
                    End Select
                    .Range("E1").Value = "PROGRAMACION POR CAMION AL DIA " & dtpFecha.Value '& "  -  " & viaje
                    .Range("E1").Font.Bold = True
                    Dim filaultima As Int32 = 0
                    Dim contactivo As Int32 = 0
                    For i As Int16 = 0 To gridProgramacion.Rows.Count - 1
                        '.Range("A" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("NUMDOC").Value
                        .Range("B" & nfilaini + i).Value = gridProgramacion.Rows(i).Cells("PLACA").Value
                        .Range("C" & nfilaini + i).Value = gridProgramacion.Rows(i).Cells("NUMPEDIDO").Value
                        .Range("D" & nfilaini + i).Value = gridProgramacion.Rows(i).Cells("NROVIAJE").Value
                        .Range("E" & nfilaini + i).Value = gridProgramacion.Rows(i).Cells("CLIENTE").Value
                        '.Range("C" & nfilaini & "D" & nfilaini).Merge()
                        .Range(.Cells(nfilaini + i, 5), .Cells(nfilaini + i, 6)).Merge()
                        '.Range("D" & 5 - contactivo + i).Value = gridMineral.Rows(i).Cells("COD_MATPRIMA").Value
                        .Range("G" & nfilaini + i).Value = gridProgramacion.Rows(i).Cells("DISTRITO").Value
                        .Range("H" & nfilaini + i).Value = gridProgramacion.Rows(i).Cells("DIRECCION").Value
                        .Range("I" & nfilaini + i).Value = gridProgramacion.Rows(i).Cells("REFERENCIA").Value
                        .Range("J" & nfilaini + i).Value = gridProgramacion.Rows(i).Cells("PRODUCTO").Value.ToString.Trim
                        .Range("K" & nfilaini + i).Value = gridProgramacion.Rows(i).Cells("HORA").Value
                        .Range("L" & nfilaini + i).Value = "TM"
                        .Range("M" & nfilaini + i).Value = gridProgramacion.Rows(i).Cells("TONELADA").Value
                        .Range(.Cells(nfilaini + i, 2), .Cells(nfilaini + i, 13)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nfila = nfila + 1
                        filaultima = nfilaini + i
                    Next
                    filaultima += 1
                    .Range(.Cells(filaultima + 1, 12), .Cells(filaultima + 1, 12)).Value = "TOTAL"
                    .Range(.Cells(filaultima + 1, 12), .Cells(filaultima + 1, 12)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(filaultima + 1, 13), .Cells(filaultima + 1, 13)).Formula = "=SUMA(M5:M" & filaultima & ")"

                    '.Range(.Cells(filaultima + 1, 4), .Cells(filaultima + 1, 8)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 1, 12), .Cells(filaultima + 1, 13)).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble
                    .Range(.Cells(filaultima + 1, 12), .Cells(filaultima + 1, 13)).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    .Range(.Cells(filaultima + 1, 12), .Cells(filaultima + 1, 13)).Font.Bold = True
                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub gridProgramacion_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridProgramacion.DoubleClickRow
        frmCamionReprogramacion.codprov = txtcodprov.Text
        frmCamionReprogramacion.fecha = dtpFecha.Value
        frmCamionReprogramacion.ShowDialog()
        'MsgBox(frmCamionReprogramacion.placa)
        Dim placa As String = frmCamionReprogramacion.placa.Trim
        If MsgBox("Desea cambiar placa a la programación?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then

            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.ID = gridProgramacion.ActiveRow.Cells("IDPROGRAMACION").Value
            Entidad.Contratista._placa = placa
            Entidad.Contratista.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NContratista.Actualiza_Placa_Prog(Entidad.Contratista)
            If dtDatos.Rows(0)(0) <> "OK" Then
                MsgBox(dtDatos.Rows(0)(0), MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            Else
                MsgBox("Grabado correctamente", MsgBoxStyle.Information, msgComacsa)
                Procesar()
            End If

        End If
    End Sub

    Private Sub gridProgramacion_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridProgramacion.InitializeLayout

    End Sub
End Class