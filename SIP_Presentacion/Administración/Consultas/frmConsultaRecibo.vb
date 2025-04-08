Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class frmConsultaRecibo
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
    Public tipoconsulta As Int32 = 0
#End Region

    Private Sub frmConsultaRecibo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'MsgBox(Me.Tag.ToString)
        If Me.Tag.ToString = "1" Then
            btngeneratxt.Visible = True
        Else
            btngeneratxt.Visible = False
        End If
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        Me.cmbMes2.Value = Month(Now.Date)
        Me.cmbMes.Value = Month(Now.Date)
        CargarDocumentos()
        cmbTipoDocumento.Value = "RH"
        If Me.Tag.ToString = "1" Then
            cmbTipoDocumento.Value = "BL"
        End If


        Dim oPrvFisN As New NGProveedorFiscalizado
        Dim oPrvFisE As New ETProveedorFiscalizado
        Dim DtDatos As New DataTable
        With oPrvFisE
            .User_Crea = User_Sistema
        End With
        DtDatos = oPrvFisN.ConsultaUsuariosDocumentos(oPrvFisE)

        'If Me.Tag.ToString = "1" Or User_Sistema = "SA" Or User_Sistema = "COTOYA" Or User_Sistema = "MAMPUERO" Or User_Sistema = "CIRO" Or User_Sistema = "RPRINCIPE" Then
        If Me.Tag.ToString = "1" Or DtDatos.Rows.Count > 0 Then
            cmbTipoDocumento.Enabled = True
            chktodos.Visible = True
        Else
            cmbTipoDocumento.Enabled = False
        End If
        'Procesar()
    End Sub
    Private Sub CargarDocumentos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarDocumentos
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraCombo(cmbTipoDocumento, Ls_Entrega, "TipoDoc", "Descripcion")
    End Sub
    Sub Procesar()

        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DsDatos As DataSet = Nothing
        Dim DtConsulta As DataTable = Nothing
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            If cmbMes.SelectedIndex > cmbMes2.SelectedIndex Then
                MsgBox("Seleccione rango de meses correctamente")
                Exit Sub
            End If
            With oPrvFisE
                .TipoDoc = IIf(chktodos.Checked = True, "", cmbTipoDocumento.Value) '"RH"
                .año = txtAño.Value
                .mes = cmbMes.Value
                .mes2 = cmbMes2.Value
                .User_Crea = User_Sistema
            End With
            If Me.Tag.ToString = "1" Then
                DsDatos = oPrvFisN.ConsultaDocumentosAprobados(oPrvFisE)
            Else
                DsDatos = oPrvFisN.ConsultaRecibos(oPrvFisE)
            End If

            DtConsulta = DsDatos.Tables(0)
            Call CargarUltraGridxBinding(Grid1, Source1, DtConsulta)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            'Procesar()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbTipoDocumento_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbTipoDocumento.InitializeLayout
        With cmbTipoDocumento.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("Descripcion").Width = 300 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "Descripcion") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub cmbTipoDocumento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoDocumento.ValueChanged
        'Procesar()
    End Sub

    Sub Reporte()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Dim i As Int32 = 0
        Try

            If Grid1.Rows.Count > 0 Then
                lblmensaje.Visible = True
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Refresh()
                lblmensaje.Update()
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTEDOCUMENTOS.xls")
                File.Copy(RutaReporteERP & "PLANTILLADOCUMENTOS.xls", path & "\REPORTEDOCUMENTOS.xls")
                m_Excel.Workbooks.Open(path & "\REPORTEDOCUMENTOS.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0

                nfila = 13
                nfilaini = 13

                With objHojaExcel
                    .Activate()
                    .Range("A2").Value = "RELACION DE " & cmbTipoDocumento.Text.ToString & " MES DE " & cmbMes.Text.ToString & " - " & txtAño.Value
                    .Range("A2").Font.Bold = True
                    Dim filaultima As Int32 = 0

                    For i = 0 To Grid1.Rows.Count - 1
                        lblmensaje.Text = "Generando Reporte " & i & " de " & Grid1.Rows.Count - 1 & " Registro(s)..."
                        lblmensaje.Refresh()
                        lblmensaje.Update()
                        .Range("A" & 5 + i).Value = Grid1.Rows(i).Cells("NUMSOLICITUD")
                        .Range("B" & 5 + i).Value = Grid1.Rows(i).Cells("NUMLIQUIDACION")
                        .Range("C" & 5 + i).Value = Grid1.Rows(i).Cells("FECHA")
                        .Range("D" & 5 + i).Value = Grid1.Rows(i).Cells("TRABAJADOR")
                        .Range("E" & 5 + i).Value = Grid1.Rows(i).Cells("TIPODOC")
                        .Range("F" & 5 + i).Value = Grid1.Rows(i).Cells("NUMDOC")
                        .Range("G" & 5 + i).Value = Grid1.Rows(i).Cells("NRORUC")
                        .Range("H" & 5 + i).Value = Grid1.Rows(i).Cells("RAZON")
                        .Range("I" & 5 + i).Value = Grid1.Rows(i).Cells("CONCEPTO")
                        .Range("J" & 5 + i).Value = Grid1.Rows(i).Cells("MONEDA")
                        .Range("K" & 5 + i).Value = Grid1.Rows(i).Cells("MONTOTOTAL")
                        .Range("L" & 5 + i).Value = Grid1.Rows(i).Cells("CANTERA")

                        .Range("M" & 5 + i).Value = Grid1.Rows(i).Cells("DIAS")
                        .Range("N" & 5 + i).Value = Grid1.Rows(i).Cells("PERSONAS")
                        .Range("O" & 5 + i).Value = "=K" & 5 + i & "/M" & 5 + i

                        .Range("P" & 5 + i).Value = Grid1.Rows(i).Cells("COMENTARIO")
                        .Range("Q" & 5 + i).Value = Grid1.Rows(i).Cells("AUXILIAR")
                        .Range("R" & 5 + i).Value = Grid1.Rows(i).Cells("MOTIVOREEMPLAZO")
                        .Range(.Cells(5 + i, 1), .Cells(5 + i, 18)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        nfila = nfila + 1
                        filaultima = 5 + i
                    Next
                    'm_Excel.Visible = True
                    .Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 10)).Value = "TOTAL"
                    '.Range(.Cells(filaultima + 1, 11), .Cells(filaultima + 1, 11)).Formula = "=SUBTOTALES(9,K5:K" & filaultima & ")"
                    .Range(.Cells(filaultima + 1, 11), .Cells(filaultima + 1, 11)).Formula = "=SUMA(K5:K" & filaultima & ")"
                    .Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 11)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range(.Cells(filaultima + 1, 10), .Cells(filaultima + 1, 11)).Font.Bold = True
                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(i & " " & ex.Message)
            m_Excel.Quit()
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            lblmensaje.Update()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub btngeneratxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngeneratxt.Click
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No hay datos a generar", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName.Trim = "" Then Exit Sub
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Cursor = Cursors.WaitCursor
        lblmensaje.Visible = True
        lblmensaje.Text = "Generando archivo txt..."
        lblmensaje.Refresh()
        Dim ruta As String
        If SaveFileDialog1.FileName.Substring(SaveFileDialog1.FileName.Length - 4, 1) = "." Then
            ruta = SaveFileDialog1.FileName
        Else
            ruta = SaveFileDialog1.FileName & ".txt"
        End If
        Dim fs As FileStream = File.Create(ruta)
        fs.Close()
        Dim sw As New System.IO.StreamWriter(ruta)
        Try
            generarTxt(sw)
            MsgBox("Archivo txt generado en la ruta: " & ruta, MsgBoxStyle.Information, "Comacsa")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            sw.Close()
            Cursor = Cursors.Default
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub
    Sub generarTxt(ByVal sw As System.IO.StreamWriter)
        If Grid1.Rows.Count > 0 Then
            For i As Int32 = 0 To Grid1.Rows.Count - 1
                'Nro de RUC
                sw.Write(Grid1.Rows(i).Cells("NRORUC").Value.ToString.Trim)
                sw.WriteLine("|")
            Next
        End If
    End Sub

    Private Sub chktodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktodos.CheckedChanged
        If chktodos.Checked = True Then
            cmbTipoDocumento.Enabled = False
        Else
            cmbTipoDocumento.Enabled = True
        End If
    End Sub

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout

    End Sub
End Class