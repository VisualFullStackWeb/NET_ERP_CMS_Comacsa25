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
Public Class FrmRegistroKardex
#Region "Declarar Variables"
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
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

    Private Sub FrmRegistroKardex_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Procesar()
    End Sub

    Sub Procesar()
        CargarDatos()
        Me.Tab1.Tabs("T01").Selected = True
    End Sub

    Sub CargarDatos()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.ListarIQBFkardex()
        Call CargarUltraGridxBinding(GridProducto, Source1, dtDatos)
    End Sub

    Private Sub GridAnticipo_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridProducto.DoubleClickRow
        Me.Tab1.Tabs("T02").Selected = True
        Label1.Text = "CÓDIGO:            " & GridProducto.ActiveRow.Cells("COD_PROD").Value.ToString.Trim
        Label2.Text = "DESCRIPCIÓN:   " & GridProducto.ActiveRow.Cells("DES_SUNAT").Value.ToString.Trim & " - " & GridProducto.ActiveRow.Cells("PRESENTACION").Value.ToString.Trim
        txtcodprod.Text = GridProducto.ActiveRow.Cells("COD_PROD").Value.ToString.Trim
        txtcodsunat.Text = GridProducto.ActiveRow.Cells("COD_SUNAT").Value.ToString.Trim
        CargarKardex()
    End Sub

    Sub CargarKardex()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._cod_prod = txtcodprod.Text
        objEntidad._cod_sunat = txtcodsunat.Text
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.ListarIQBFkardexMov(objEntidad)
        Call CargarUltraGridxBinding(gridKardex, Source2, dtDatos)
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If txtcodprod.Text.ToString.Trim = "" Then
            'MsgBox("", MsgBoxStyle.Information, msgComacsa)
            Exit Sub
        End If
        Dim frm As New FrmIngresoKardex
        frm.cod_prod = txtcodprod.Text
        frm.cod_sunat = txtcodsunat.Text
        frm.ShowDialog()
        CargarKardex()
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        Try
            If gridKardex.ActiveRow.Cells("TIPO").Value = "I" Then
                MsgBox("No puede eliminar el saldo inicial", MsgBoxStyle.Information, msgComacsa)
                Exit Sub
            End If
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad.Operacion = 3
            objEntidad._id = gridKardex.ActiveRow.Cells("ID").Value
            objEntidad._cod_prod = ""
            objEntidad._cod_sunat = ""
            objEntidad._movi = ""
            objEntidad.Fecha = Now.Date
            objEntidad.Cantidad = 0
            objEntidad._marca = ""
            objEntidad._concentracion = ""
            objEntidad._observacion = ""
            objEntidad.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.IngresoIQBFkardex(objEntidad)
            If dtDatos.Rows.Count > 0 Then
                If dtDatos.Rows(0)(0) = "OK" Then
                    MsgBox("Se elimino el registro correctamente", MsgBoxStyle.Information, msgComacsa)
                    CargarKardex()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Reporte()
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim DtIngreso As DataTable = Nothing
        Dim DtEgreso As DataTable = Nothing
        Dim DtProduccion As DataTable = Nothing
        Dim DtUso As DataTable = Nothing
        Dim DtGeneral As DataTable = Nothing

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        lblmensaje.Text = "Generando Reporte..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        Try

            'oPrvFisN = New NGProveedorFiscalizado
            'oPrvFisE = New ETProveedorFiscalizado

            'With oPrvFisE
            '    .Cod_Cia = Companhia
            '    .FechIniVig = dtinicio.Value
            '    .FechFinVig = dtfin.Value
            'End With
            'DtIngreso = oPrvFisN.RptIngresoIQBF(oPrvFisE)
            'DtEgreso = oPrvFisN.RptEgresoIQBF(oPrvFisE)
            'DtProduccion = oPrvFisN.RptProduccionIQBF(oPrvFisE)
            'DtUso = oPrvFisN.RptUsoIQBF(oPrvFisE)
            'DtGeneral = oPrvFisN.RptGeneralIQBF(oPrvFisE)

            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            m_Excel.DisplayAlerts = False
            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\KardexIQBF.xls")

            File.Copy(RutaReporteERP & "PLANTILLAKARDEXIQBF.xls", path & "\KardexIQBF.xls")
            'desarrollo
            'File.Copy(Application.StartupPath & "\PLANTILLAKARDEXIQBF.xls", path & "\KardexIQBF.xls")

            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait

            m_Excel.Workbooks.Open(path & "\KardexIQBF.xls")

            Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            Dim objHojaExcel2 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
            Dim objHojaExcel3 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
            Dim objHojaExcel4 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)
            Dim objHojaExcel6 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(6)
            Dim objHojaExcel7 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(7)
            Dim objHojaExcel8 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(8)
            Dim objHojaExcel9 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(9)
            Dim objHojaExcel10 As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(11) 'Acetona

            Dim dtDatos As New DataTable

            Dim nfila As Integer
            Dim nfilaini As Integer
            Dim nfilault As Integer = 0
            Dim filaultima As Int32 = 0

            dtDatos = New DataTable
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._cod_prod = "50002383"
            objEntidad._cod_sunat = "4"
            dtDatos = New DataTable
            dtDatos = objNegocio.ListarIQBFRPTkardex(objEntidad)

            nfila = 10
            nfilaini = 10
            filaultima = 0
            With objHojaExcel
                .Activate()
                For i As Int16 = 0 To dtDatos.Rows.Count - 1
                    If dtDatos.Rows(i)("MOVI") = "I" Then
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("MARCA")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("CONCENTRACION")
                    End If
                    If dtDatos.Rows(i)("MOVI") = "S" Then
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                    End If
                    .Range("L" & nfila + i).Value = dtDatos.Rows(i)("SALDO")
                    .Range("M" & nfila + i).Value = "=L" & nfila + i & "/$L$6"
                    .Range("N" & nfila + i).Value = dtDatos.Rows(i)("OBSERVACION")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    filaultima = nfila + i
                Next
            End With


            dtDatos = New DataTable
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._cod_prod = "50002384"
            objEntidad._cod_sunat = "1"
            dtDatos = New DataTable
            dtDatos = objNegocio.ListarIQBFRPTkardex(objEntidad)

            nfila = 10
            nfilaini = 10
            filaultima = 0
            With objHojaExcel2
                '.Activate()
                For i As Int16 = 0 To dtDatos.Rows.Count - 1
                    If dtDatos.Rows(i)("MOVI") = "I" Then
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("MARCA")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("CONCENTRACION")
                    End If
                    If dtDatos.Rows(i)("MOVI") = "S" Then
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                    End If
                    .Range("L" & nfila + i).Value = dtDatos.Rows(i)("SALDO")
                    .Range("M" & nfila + i).Value = "=L" & nfila + i & "/$L$6"
                    .Range("N" & nfila + i).Value = dtDatos.Rows(i)("OBSERVACION")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    filaultima = nfila + i
                Next
            End With

            dtDatos = New DataTable
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._cod_prod = "50002381"
            objEntidad._cod_sunat = "2"
            dtDatos = New DataTable
            dtDatos = objNegocio.ListarIQBFRPTkardex(objEntidad)

            nfila = 10
            nfilaini = 10
            filaultima = 0
            With objHojaExcel3
                '.Activate()
                For i As Int16 = 0 To dtDatos.Rows.Count - 1
                    If dtDatos.Rows(i)("MOVI") = "I" Then
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("MARCA")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("CONCENTRACION")
                    End If
                    If dtDatos.Rows(i)("MOVI") = "S" Then
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                    End If
                    .Range("L" & nfila + i).Value = dtDatos.Rows(i)("SALDO")
                    .Range("M" & nfila + i).Value = "=L" & nfila + i & "/$L$6"
                    .Range("N" & nfila + i).Value = dtDatos.Rows(i)("OBSERVACION")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    filaultima = nfila + i
                Next
            End With

            dtDatos = New DataTable
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._cod_prod = "50002393"
            objEntidad._cod_sunat = "17"
            dtDatos = New DataTable
            dtDatos = objNegocio.ListarIQBFRPTkardex(objEntidad)

            nfila = 10
            nfilaini = 10
            filaultima = 0
            With objHojaExcel4
                '.Activate()
                For i As Int16 = 0 To dtDatos.Rows.Count - 1
                    If dtDatos.Rows(i)("MOVI") = "I" Then
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("MARCA")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("CONCENTRACION")
                    End If
                    If dtDatos.Rows(i)("MOVI") = "S" Then
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                    End If
                    .Range("L" & nfila + i).Value = dtDatos.Rows(i)("SALDO")
                    .Range("M" & nfila + i).Value = "=L" & nfila + i & "/$L$6"
                    .Range("N" & nfila + i).Value = dtDatos.Rows(i)("OBSERVACION")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    filaultima = nfila + i
                Next
            End With

            dtDatos = New DataTable
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._cod_prod = "50002402"
            objEntidad._cod_sunat = "21"
            dtDatos = New DataTable
            dtDatos = objNegocio.ListarIQBFRPTkardex(objEntidad)

            nfila = 32
            nfilaini = 32
            filaultima = 0
            With objHojaExcel6
                '.Activate()
                For i As Int16 = 0 To dtDatos.Rows.Count - 1
                    If dtDatos.Rows(i)("MOVI") = "I" Then
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("MARCA")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("CONCENTRACION")
                    End If
                    If dtDatos.Rows(i)("MOVI") = "S" Then
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                    End If
                    .Range("L" & nfila + i).Value = dtDatos.Rows(i)("SALDO")
                    .Range("M" & nfila + i).Value = "=L" & nfila + i & "/$L$6"
                    .Range("N" & nfila + i).Value = dtDatos.Rows(i)("OBSERVACION")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    filaultima = nfila + i
                Next
            End With

            dtDatos = New DataTable
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._cod_prod = "50026709"
            objEntidad._cod_sunat = "10"
            dtDatos = New DataTable
            dtDatos = objNegocio.ListarIQBFRPTkardex(objEntidad)

            nfila = 10
            nfilaini = 10
            filaultima = 0
            With objHojaExcel7
                '.Activate()
                For i As Int16 = 0 To dtDatos.Rows.Count - 1
                    If dtDatos.Rows(i)("MOVI") = "I" Then
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("MARCA")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("CONCENTRACION")
                    End If
                    If dtDatos.Rows(i)("MOVI") = "S" Then
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                    End If
                    .Range("L" & nfila + i).Value = dtDatos.Rows(i)("SALDO")
                    .Range("M" & nfila + i).Value = "=L" & nfila + i & "/$L$6"
                    .Range("N" & nfila + i).Value = dtDatos.Rows(i)("OBSERVACION")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    filaultima = nfila + i
                Next
            End With

            dtDatos = New DataTable
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._cod_prod = "50006336"
            objEntidad._cod_sunat = "7"
            dtDatos = New DataTable
            dtDatos = objNegocio.ListarIQBFRPTkardex(objEntidad)

            nfila = 10
            nfilaini = 10
            filaultima = 0
            With objHojaExcel8
                '.Activate()
                For i As Int16 = 0 To dtDatos.Rows.Count - 1
                    If dtDatos.Rows(i)("MOVI") = "I" Then
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("MARCA")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("CONCENTRACION")
                    End If
                    If dtDatos.Rows(i)("MOVI") = "S" Then
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                    End If
                    .Range("L" & nfila + i).Value = dtDatos.Rows(i)("SALDO")
                    .Range("M" & nfila + i).Value = "=L" & nfila + i & "/$L$6"
                    .Range("N" & nfila + i).Value = dtDatos.Rows(i)("OBSERVACION")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    filaultima = nfila + i
                Next
            End With

            dtDatos = New DataTable
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._cod_prod = "50008969"
            objEntidad._cod_sunat = "14"
            dtDatos = New DataTable
            dtDatos = objNegocio.ListarIQBFRPTkardex(objEntidad)

            nfila = 10
            nfilaini = 10
            filaultima = 0
            With objHojaExcel9
                '.Activate()
                For i As Int16 = 0 To dtDatos.Rows.Count - 1
                    If dtDatos.Rows(i)("MOVI") = "I" Then
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("MARCA")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("CONCENTRACION")
                    End If
                    If dtDatos.Rows(i)("MOVI") = "S" Then
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                    End If
                    .Range("L" & nfila + i).Value = dtDatos.Rows(i)("SALDO")
                    .Range("M" & nfila + i).Value = "=L" & nfila + i & "/$L$6"
                    .Range("N" & nfila + i).Value = dtDatos.Rows(i)("OBSERVACION")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    filaultima = nfila + i
                Next
            End With

            'ACETONA()
            dtDatos = New DataTable
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._cod_prod = "50027225"
            objEntidad._cod_sunat = "24"
            dtDatos = New DataTable
            dtDatos = objNegocio.ListarIQBFRPTkardex(objEntidad)

            nfila = 10
            nfilaini = 10
            filaultima = 0
            With objHojaExcel10
                '.Activate()
                For i As Int16 = 0 To dtDatos.Rows.Count - 1
                    If dtDatos.Rows(i)("MOVI") = "I" Then
                        .Range("B" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("C" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                        .Range("D" & nfila + i).Value = dtDatos.Rows(i)("MARCA")
                        .Range("E" & nfila + i).Value = dtDatos.Rows(i)("CONCENTRACION")
                    End If
                    If dtDatos.Rows(i)("MOVI") = "S" Then
                        .Range("F" & nfila + i).Value = dtDatos.Rows(i)("FECHA")
                        .Range("H" & nfila + i).Value = dtDatos.Rows(i)("CANTIDAD")
                    End If
                    .Range("L" & nfila + i).Value = dtDatos.Rows(i)("SALDO")
                    .Range("M" & nfila + i).Value = "=L" & nfila + i & "/$L$6"
                    .Range("N" & nfila + i).Value = dtDatos.Rows(i)("OBSERVACION")
                    .Range(.Cells(nfila + i, 2), .Cells(nfila + i, 14)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    filaultima = nfila + i
                Next
            End With

            m_Excel.Visible = True
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            oPrvFisN = Nothing
            oPrvFisE = Nothing
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub

    Private Sub GridProducto_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridProducto.InitializeLayout

    End Sub
End Class