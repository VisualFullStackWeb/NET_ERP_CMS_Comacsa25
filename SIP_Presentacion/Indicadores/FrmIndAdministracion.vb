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
Public Class FrmIndAdministracion
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

    Private Sub FrmIndAdministracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtayo.Value = Year(Now.Date)
        Me.cmbMesDesde.Value = Month(Now.Date)
    End Sub

    Private Sub cmbMesDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMesDesde.ValueChanged
        Try
            'GenerarIndicadorAdministracion()
        Catch ex As Exception

        End Try
    End Sub
    Sub GenerarIndicadorAdministracion()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            lblmensaje.Text = "Procesando Datos..."
            lblmensaje.Visible = True
            lblmensaje.Refresh()
            Dim dtDatos As New DataTable
            Dim dtDatosComercial As New DataTable
            Dim mes_ini As Int32 = cmbMesDesde.Value
            Dim mes_final As Int32 = cmbMesDesde.Value
            Dim dsDatos As New DataSet
            dsDatos = New DataSet
            dtDatos = New DataTable
            dtDatosComercial = New DataTable
            For I As Int32 = 1 To cmbMesDesde.Value
                dtDatos = New DataTable
                dsDatos = New DataSet
                _objNegocio = New NGProducto
                _objEntidad = New ETProducto
                _objEntidad.Anho = txtayo.Value
                _objEntidad.Mes = I
                _objEntidad.Usuario = User_Sistema
                dsDatos = _objNegocio.INDICADOR_ADMINISTRACION_FINAL(_objEntidad)
                dtDatos = dsDatos.Tables(0)
            Next


            'dtDatosComercial = dsDatos.Tables(1)
            Call CargarUltraGridxBinding(gridCompra, Source1, dtDatos)
            Call CargarUltraGridxBinding(gridComercial, Source2, dtDatosComercial)
        Catch ex As Exception
            'MsgBox(ex.Message)
            'm_Excel.Quit()
        Finally
            lblmensaje.Visible = False
            lblmensaje.Refresh()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Private Sub gridCompra_FilterRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.FilterRowEventArgs) Handles gridCompra.FilterRow, gridComercial.FilterRow
        Dim diferencia As Int32 = 0
        If e.Row.Cells("COLOR").Value.ToString.Trim = "VERDE" Then
            e.Row.Cells("PINTAR").Appearance.BackColor = Color.Green
        ElseIf e.Row.Cells("COLOR").Value.ToString.Trim = "AMARILLO" Then
            e.Row.Cells("PINTAR").Appearance.BackColor = Color.Yellow
        ElseIf e.Row.Cells("COLOR").Value.ToString.Trim = "ROJO" Then
            e.Row.Cells("PINTAR").Appearance.BackColor = Color.Red
        End If
    End Sub

    Sub Procesar()
        GenerarIndicadorAdministracion()
        Imprimir()
    End Sub

    Sub Reporte()
        Procesar()
    End Sub

    Sub Imprimir()
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            If gridCompra.Rows.Count > 0 Then
                Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                lblmensaje.Text = "Generando Reporte..."
                lblmensaje.Visible = True
                lblmensaje.Refresh()
                Dim path As String
                path = Application.StartupPath

                File.Delete(path & "\REPORTEINDICADORES.xls")
                File.Copy(RutaReporteERP & "PLANTILLA_INDICADOR_SIG.xls", path & "\REPORTEINDICADORES.xls")
                'File.Copy("D:\PLANTILLA_INDICADOR_SIG.xls", path & "\REPORTEINDICADORES.xls")
                m_Excel.Workbooks.Open(path & "\REPORTEINDICADORES.xls")

                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "General"

                m_Excel.DisplayAlerts = False


                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0
                Dim n_mes As Int32 = 0
                nfila = 15
                nfilaini = 15

                With objHojaExcel
                    .Activate()
                    'm_Excel.Visible = True
                    For i As Int32 = 0 To gridCompra.Rows.Count - 1

                        For x As Int32 = 14 To 148
                            Dim tipo_proceso As String = .Range("AH" & x).Value
                            Dim orden As String = .Range("AI" & x).Value

                            Dim tipo_medicion As String = .Range("AM" & x).Value
                            Dim valor_objetivo As Double = 0
                            Dim resultado As Double = 0
                            Dim operacion As String = .Range("AN" & x).Value
                            Dim periocidad As String = .Range("AP" & x).Value

                            If tipo_proceso = gridCompra.Rows(i).Cells("TIPO_PROCESO").Value And orden = gridCompra.Rows(i).Cells("ORDEN").Value.ToString Then
                                If gridCompra.Rows(i).Cells("ACCION").Value = "EXISTE" Then
                                    .Range("A" & x).EntireRow.Hidden = False
                                    If tipo_proceso = "E" And orden = 39 Then
                                        .Range("A43").EntireRow.Hidden = False
                                    End If
                                Else
                                    .Range("A" & x).EntireRow.Hidden = True
                                End If
                                .Range("J" & x).Value = gridCompra.Rows(i).Cells("INDICADOR").Value
                                .Range("N" & x).Value = gridCompra.Rows(i).Cells("ENERO").Value
                                .Range("O" & x).Value = gridCompra.Rows(i).Cells("FEBRERO").Value
                                .Range("P" & x).Value = gridCompra.Rows(i).Cells("MARZO").Value
                                .Range("Q" & x).Value = gridCompra.Rows(i).Cells("ABRIL").Value
                                .Range("R" & x).Value = gridCompra.Rows(i).Cells("MAYO").Value
                                .Range("S" & x).Value = gridCompra.Rows(i).Cells("JUNIO").Value
                                .Range("T" & x).Value = gridCompra.Rows(i).Cells("JULIO").Value
                                .Range("U" & x).Value = gridCompra.Rows(i).Cells("AGOSTO").Value
                                .Range("V" & x).Value = gridCompra.Rows(i).Cells("SETIEMBRE").Value
                                .Range("W" & x).Value = gridCompra.Rows(i).Cells("OCTUBRE").Value
                                .Range("X" & x).Value = gridCompra.Rows(i).Cells("NOVIEMBRE").Value
                                .Range("Y" & x).Value = gridCompra.Rows(i).Cells("DICIEMBRE").Value
                                'amarillo 65535

                                If x <= 148 Then '25
                                    For col As Int32 = 14 To 13 + cmbMesDesde.Value
                                        If tipo_medicion = "FIJO" Then
                                            Dim valor_medidicion As Double = .Range("AO" & x).Value
                                            Dim valor_mejorar As Double = 0
                                            If CStr(.Range("AQ" & x).Value).ToString.Trim <> "" Then
                                                valor_mejorar = .Range("AQ" & x).Value
                                            End If
                                            'Dim valor_mejorar As Double = IIf(.Range("AQ" & x).Value = "", 0, .Range("AQ" & x).Value)
                                            resultado = .Range(.Cells(x, col), .Cells(x, col)).Value
                                            'MsgBox(resultado)

                                            If x <> 49 And x <> 50 Then
                                                If operacion = "MENOR" Then
                                                    If resultado < valor_medidicion Then
                                                        .Range(.Cells(x, col), .Cells(x, col)).Font.Color = 5287936
                                                        '.Range("K" & x).Interior.Color = 5287936
                                                    ElseIf resultado < valor_mejorar And resultado >= valor_medidicion Then
                                                        .Range(.Cells(x, col), .Cells(x, col)).Font.Color = 65535
                                                    Else

                                                        .Range(.Cells(x, col), .Cells(x, col)).Font.Color = 255
                                                        '.Range("K" & x).Interior.Color = 255
                                                    End If
                                                End If
                                                If operacion = "MAYOR" Then
                                                    If resultado > valor_medidicion Then
                                                        .Range(.Cells(x, col), .Cells(x, col)).Font.Color = 5287936
                                                        '.Range("K" & x).Interior.Color = 5287936
                                                    ElseIf resultado > valor_mejorar And resultado <= valor_medidicion Then
                                                        .Range(.Cells(x, col), .Cells(x, col)).Font.Color = 65535
                                                    Else

                                                        .Range(.Cells(x, col), .Cells(x, col)).Font.Color = 255
                                                        '.Range("K" & x).Interior.Color = 255
                                                    End If
                                                Else
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                            End If
                        Next
                    Next
                End With
                'objHojaExcel.Protect()
                ImprimeDetalle(m_Excel)
                m_Excel.Visible = True
                objHojaExcel.Protect("SIG2021@", True)
                m_Excel.ActiveWorkbook.Protect("SIG2021@", True)
            End If

        Catch ex As Exception           
            'm_Excel.Quit()
            MsgBox(ex.Message)
            m_Excel.Visible = True
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            lblmensaje.Visible = False
            lblmensaje.Refresh()
        End Try
    End Sub

    Sub ImprimeDetalle(ByVal m_Excel As Microsoft.Office.Interop.Excel.Application)
        Dim objHojaExcelSOC As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(2)
        Dim objHojaExcelSIG As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(3)
        Dim objHojaExcelSEG As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(4)
        Dim objHojaExcelGAF As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(5)
        Dim objHojaExcelPE As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(6)
        Dim objHojaExcelCOM As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(7)
        Dim objHojaExcelVEN As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(8)
        Dim objHojaExcelID As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(9)
        Dim objHojaExcelDID As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(10)
        Dim objHojaExcelLAB As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(11)
        Dim objHojaExcelBNF As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(12)
        Dim objHojaExcelPCB As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(13)
        Dim objHojaExcelCAL As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(14)
        Dim objHojaExcelPMC As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(15)
        Dim objHojaExcelPPC As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(16)
        Dim objHojaExcelALM As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(17)
        Dim objHojaExcelDES As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(18)
        Dim objHojaExcelLEG As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(19)
        Dim objHojaExcelRRH As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(20)
        Dim objHojaExcelTMP As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(21)
        Dim objHojaExcelTMM As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(22)
        Dim objHojaExcelTME As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(23)

        Dim dsDatos As New DataSet
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.Anho = txtayo.Value
        _objEntidad.Usuario = User_Sistema
        dsDatos = _objNegocio.INDICADOR_ADMINISTRACION_FINAL_DETALLE(_objEntidad)
        ImprimeSOC(dsDatos.Tables(0), objHojaExcelSOC)
        ImprimeSIG(dsDatos.Tables(1), objHojaExcelSIG)
        ImprimeSEG(dsDatos.Tables(2), objHojaExcelSEG)
        ImprimeGAF(dsDatos.Tables(3), objHojaExcelGAF)
        ImprimePE(dsDatos.Tables(4), objHojaExcelPE)
        ImprimeCOM(dsDatos.Tables(5), objHojaExcelCOM)
        ImprimeVEN(dsDatos.Tables(6), objHojaExcelVEN)
        ImprimeID(dsDatos.Tables(7), objHojaExcelID)
        ImprimeDID(dsDatos.Tables(8), objHojaExcelDID)
        ImprimeLAB(dsDatos.Tables(9), objHojaExcelLAB)
        ImprimeBNF(dsDatos.Tables(10), objHojaExcelBNF)
        ImprimePCB(dsDatos.Tables(11), objHojaExcelPCB)
        ImprimeCAL(dsDatos.Tables(12), objHojaExcelCAL)
        ImprimePMC(dsDatos.Tables(13), objHojaExcelPMC)
        ImprimePPC(dsDatos.Tables(14), objHojaExcelPPC)
        ImprimeALM(dsDatos.Tables(15), objHojaExcelALM)
        ImprimeDES(dsDatos.Tables(16), objHojaExcelDES)
        ImprimeLEG(dsDatos.Tables(17), objHojaExcelLEG)
        ImprimeRRH(dsDatos.Tables(18), objHojaExcelRRH)
        ImprimeTMP(dsDatos.Tables(19), objHojaExcelTMP)
        ImprimeTMM(dsDatos.Tables(20), objHojaExcelTMM)
        ImprimeTME(dsDatos.Tables(21), objHojaExcelTME)
    End Sub

    Sub ImprimeTME(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(16, col), .Cells(16, col)).Value = dtDatos.Rows(4)(col)
                .Range(.Cells(17, col), .Cells(17, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(18, col), .Cells(18, col)).Value = dtDatos.Rows(3)(col)
                .Range(.Cells(19, col), .Cells(19, col)).Value = dtDatos.Rows(5)(col)
            Next
        End With
    End Sub

    Sub ImprimeTMM(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(16, col), .Cells(16, col)).Value = dtDatos.Rows(4)(col)
                .Range(.Cells(17, col), .Cells(17, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(18, col), .Cells(18, col)).Value = dtDatos.Rows(3)(col)
                .Range(.Cells(19, col), .Cells(19, col)).Value = dtDatos.Rows(5)(col)
            Next
        End With
    End Sub

    Sub ImprimeTMP(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(16, col), .Cells(16, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(17, col), .Cells(17, col)).Value = dtDatos.Rows(3)(col)
                .Range(.Cells(18, col), .Cells(18, col)).Value = dtDatos.Rows(4)(col)
            Next
        End With
    End Sub
    Sub ImprimeRRH(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(25, col), .Cells(25, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(26, col), .Cells(26, col)).Value = dtDatos.Rows(3)(col)

                .Range(.Cells(36, col), .Cells(36, col)).Value = dtDatos.Rows(10)(col)
                .Range(.Cells(37, col), .Cells(37, col)).Value = dtDatos.Rows(11)(col)

                .Range(.Cells(47, col), .Cells(47, col)).Value = dtDatos.Rows(4)(col)
                .Range(.Cells(48, col), .Cells(48, col)).Value = dtDatos.Rows(5)(col)
                .Range(.Cells(49, col), .Cells(49, col)).Value = dtDatos.Rows(6)(col)

                .Range(.Cells(58, col), .Cells(58, col)).Value = dtDatos.Rows(7)(col)
                .Range(.Cells(59, col), .Cells(59, col)).Value = dtDatos.Rows(8)(col)
                .Range(.Cells(60, col), .Cells(60, col)).Value = dtDatos.Rows(9)(col)

                .Range(.Cells(69, col), .Cells(69, col)).Value = dtDatos.Rows(12)(col)
            Next
        End With
    End Sub

    Sub ImprimeLEG(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(16, col), .Cells(16, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(18, col), .Cells(18, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(19, col), .Cells(19, col)).Value = dtDatos.Rows(3)(col)
            Next
        End With
    End Sub

    Sub ImprimeDES(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(20, col), .Cells(20, col)).Value = dtDatos.Rows(1)(col)
            Next
        End With
    End Sub

    Sub ImprimeALM(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(1)(col)
            Next
        End With
    End Sub

    Sub ImprimePPC(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(28, col), .Cells(28, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(31, col), .Cells(31, col)).Value = dtDatos.Rows(2)(col)
            Next
        End With
    End Sub

    Sub ImprimePMC(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(28, col), .Cells(28, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(29, col), .Cells(29, col)).Value = dtDatos.Rows(2)(col)
            Next
        End With
    End Sub

    Sub ImprimeCAL(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(26, col), .Cells(26, col)).Value = dtDatos.Rows(3)(col)
                .Range(.Cells(27, col), .Cells(27, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(38, col), .Cells(38, col)).Value = dtDatos.Rows(3)(col) + dtDatos.Rows(1)(col)

                .Range(.Cells(39, col), .Cells(39, col)).Value = dtDatos.Rows(13)(col)
                .Range(.Cells(40, col), .Cells(40, col)).Value = dtDatos.Rows(14)(col)
                .Range(.Cells(41, col), .Cells(41, col)).Value = dtDatos.Rows(15)(col)
                .Range(.Cells(42, col), .Cells(42, col)).Value = dtDatos.Rows(16)(col)
                .Range(.Cells(43, col), .Cells(43, col)).Value = dtDatos.Rows(17)(col)
                .Range(.Cells(44, col), .Cells(44, col)).Value = dtDatos.Rows(18)(col)
                .Range(.Cells(45, col), .Cells(45, col)).Value = dtDatos.Rows(19)(col)
                .Range(.Cells(46, col), .Cells(46, col)).Value = dtDatos.Rows(20)(col)
                .Range(.Cells(47, col), .Cells(47, col)).Value = dtDatos.Rows(21)(col)


                .Range(.Cells(49, col), .Cells(49, col)).Value = dtDatos.Rows(4)(col)
                .Range(.Cells(50, col), .Cells(50, col)).Value = dtDatos.Rows(5)(col)
                .Range(.Cells(51, col), .Cells(51, col)).Value = dtDatos.Rows(6)(col)
                .Range(.Cells(52, col), .Cells(52, col)).Value = dtDatos.Rows(7)(col)
                .Range(.Cells(53, col), .Cells(53, col)).Value = dtDatos.Rows(8)(col)
                .Range(.Cells(54, col), .Cells(54, col)).Value = dtDatos.Rows(9)(col)
                .Range(.Cells(55, col), .Cells(55, col)).Value = dtDatos.Rows(10)(col)
                .Range(.Cells(56, col), .Cells(56, col)).Value = dtDatos.Rows(11)(col)
                .Range(.Cells(57, col), .Cells(57, col)).Value = dtDatos.Rows(12)(col)

            Next
        End With
    End Sub

    Sub ImprimePCB(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(28, col), .Cells(28, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(29, col), .Cells(29, col)).Value = dtDatos.Rows(2)(col)
            Next
        End With
    End Sub

    Sub ImprimeBNF(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(27, col), .Cells(27, col)).Value = dtDatos.Rows(3)(col)
                .Range(.Cells(28, col), .Cells(28, col)).Value = dtDatos.Rows(1)(col)

                .Range(.Cells(39, col), .Cells(39, col)).Value = dtDatos.Rows(4)(col)
                .Range(.Cells(40, col), .Cells(40, col)).Value = dtDatos.Rows(5)(col)
                .Range(.Cells(41, col), .Cells(41, col)).Value = dtDatos.Rows(6)(col)
                .Range(.Cells(42, col), .Cells(42, col)).Value = dtDatos.Rows(7)(col)
                .Range(.Cells(43, col), .Cells(43, col)).Value = dtDatos.Rows(8)(col)
                .Range(.Cells(44, col), .Cells(44, col)).Value = dtDatos.Rows(9)(col)
                .Range(.Cells(45, col), .Cells(45, col)).Value = dtDatos.Rows(10)(col)
                .Range(.Cells(46, col), .Cells(46, col)).Value = dtDatos.Rows(11)(col)
                .Range(.Cells(47, col), .Cells(47, col)).Value = dtDatos.Rows(12)(col)

                .Range(.Cells(49, col), .Cells(49, col)).Value = dtDatos.Rows(13)(col)
                .Range(.Cells(50, col), .Cells(50, col)).Value = dtDatos.Rows(14)(col)
                .Range(.Cells(51, col), .Cells(51, col)).Value = dtDatos.Rows(15)(col)
                .Range(.Cells(52, col), .Cells(52, col)).Value = dtDatos.Rows(16)(col)
                .Range(.Cells(53, col), .Cells(53, col)).Value = dtDatos.Rows(17)(col)
                .Range(.Cells(54, col), .Cells(54, col)).Value = dtDatos.Rows(18)(col)
                .Range(.Cells(55, col), .Cells(55, col)).Value = dtDatos.Rows(19)(col)
                .Range(.Cells(56, col), .Cells(56, col)).Value = dtDatos.Rows(20)(col)
                .Range(.Cells(57, col), .Cells(57, col)).Value = dtDatos.Rows(21)(col)
                '.Range(.Cells(48, col), .Cells(48, col)).Value = dtDatos.Rows(4)(col)
            Next
        End With
    End Sub

    Sub ImprimeLAB(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(25, col), .Cells(25, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(26, col), .Cells(26, col)).Value = dtDatos.Rows(3)(col)
                .Range(.Cells(36, col), .Cells(36, col)).Value = dtDatos.Rows(4)(col)
                .Range(.Cells(37, col), .Cells(37, col)).Value = dtDatos.Rows(5)(col)
            Next
        End With
    End Sub

    Sub ImprimeDID(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(0)(col)
            Next
        End With
    End Sub

    Sub ImprimeID(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(0)(col)
            Next
        End With
    End Sub

    Sub ImprimeVEN(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(16, col), .Cells(16, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(26, col), .Cells(26, col)).Value = dtDatos.Rows(2)(col)

                .Range(.Cells(37, col), .Cells(37, col)).Value = dtDatos.Rows(6)(col)
                .Range(.Cells(38, col), .Cells(38, col)).Value = dtDatos.Rows(7)(col)

                .Range(.Cells(50, col), .Cells(50, col)).Value = dtDatos.Rows(4)(col)
                .Range(.Cells(51, col), .Cells(51, col)).Value = dtDatos.Rows(5)(col)

                .Range(.Cells(62, col), .Cells(62, col)).Value = dtDatos.Rows(8)(col)
                .Range(.Cells(63, col), .Cells(63, col)).Value = dtDatos.Rows(9)(col)

                .Range(.Cells(73, col), .Cells(73, col)).Value = dtDatos.Rows(3)(col)
            Next
        End With
    End Sub

    Sub ImprimeCOM(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(25, col), .Cells(25, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(26, col), .Cells(26, col)).Value = dtDatos.Rows(3)(col)
                .Range(.Cells(27, col), .Cells(27, col)).Value = dtDatos.Rows(4)(col)
                .Range(.Cells(37, col), .Cells(37, col)).Value = dtDatos.Rows(5)(col)
                .Range(.Cells(38, col), .Cells(38, col)).Value = dtDatos.Rows(6)(col)
                .Range(.Cells(48, col), .Cells(48, col)).Value = dtDatos.Rows(7)(col)
                .Range(.Cells(49, col), .Cells(49, col)).Value = dtDatos.Rows(8)(col)
                .Range(.Cells(59, col), .Cells(59, col)).Value = dtDatos.Rows(9)(col)
                .Range(.Cells(60, col), .Cells(60, col)).Value = dtDatos.Rows(10)(col)
            Next
        End With
    End Sub

    Sub ImprimePE(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(26, col), .Cells(26, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(27, col), .Cells(27, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(37, col), .Cells(37, col)).Value = dtDatos.Rows(3)(col)
                .Range(.Cells(38, col), .Cells(38, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(48, col), .Cells(48, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(49, col), .Cells(49, col)).Value = dtDatos.Rows(14)(col)
                .Range(.Cells(50, col), .Cells(50, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(62, col), .Cells(62, col)).Value = dtDatos.Rows(6)(col) + dtDatos.Rows(7)(col)
                .Range(.Cells(63, col), .Cells(63, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(74, col), .Cells(74, col)).Value = dtDatos.Rows(10)(col)
                .Range(.Cells(75, col), .Cells(75, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(86, col), .Cells(86, col)).Value = dtDatos.Rows(8)(col)
                .Range(.Cells(87, col), .Cells(87, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(98, col), .Cells(98, col)).Value = dtDatos.Rows(11)(col)
                .Range(.Cells(99, col), .Cells(99, col)).Value = dtDatos.Rows(13)(col)
                .Range(.Cells(110, col), .Cells(110, col)).Value = dtDatos.Rows(5)(col)
                .Range(.Cells(111, col), .Cells(111, col)).Value = dtDatos.Rows(12)(col)
                .Range(.Cells(112, col), .Cells(112, col)).Value = dtDatos.Rows(13)(col)
                .Range(.Cells(123, col), .Cells(123, col)).Value = dtDatos.Rows(15)(col)
                .Range(.Cells(124, col), .Cells(124, col)).Value = dtDatos.Rows(16)(col)
            Next
        End With
    End Sub

    Sub ImprimeGAF(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value

                .Range(.Cells(13, col), .Cells(13, col)).Value = dtDatos.Rows(7)(col)
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(8)(col)

                .Range(.Cells(25, col), .Cells(25, col)).Value = dtDatos.Rows(17)(col)
                .Range(.Cells(26, col), .Cells(26, col)).Value = dtDatos.Rows(18)(col)
                .Range(.Cells(27, col), .Cells(27, col)).Value = dtDatos.Rows(19)(col)

                .Range(.Cells(37, col), .Cells(37, col)).Value = dtDatos.Rows(16)(col)
                .Range(.Cells(38, col), .Cells(38, col)).Value = dtDatos.Rows(18)(col)
                .Range(.Cells(39, col), .Cells(39, col)).Value = dtDatos.Rows(19)(col)

                .Range(.Cells(49, col), .Cells(49, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(50, col), .Cells(50, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(60, col), .Cells(60, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(61, col), .Cells(61, col)).Value = dtDatos.Rows(3)(col)

                .Range(.Cells(70, col), .Cells(70, col)).Value = dtDatos.Rows(0)(col) + dtDatos.Rows(2)(col)
                .Range(.Cells(71, col), .Cells(71, col)).Value = dtDatos.Rows(1)(col) + dtDatos.Rows(3)(col)


                .Range(.Cells(81, col), .Cells(81, col)).Value = dtDatos.Rows(20)(col)
                .Range(.Cells(82, col), .Cells(82, col)).Value = dtDatos.Rows(21)(col)
                .Range(.Cells(83, col), .Cells(83, col)).Value = dtDatos.Rows(22)(col)

                .Range(.Cells(93, col), .Cells(93, col)).Value = dtDatos.Rows(23)(col)
                .Range(.Cells(94, col), .Cells(94, col)).Value = dtDatos.Rows(24)(col)
                .Range(.Cells(95, col), .Cells(95, col)).Value = dtDatos.Rows(25)(col)
            Next
        End With
    End Sub

    Sub ImprimeSEG(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(13, col), .Cells(13, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(1)(col)
                .Range(.Cells(26, col), .Cells(26, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(27, col), .Cells(27, col)).Value = dtDatos.Rows(3)(col)
                .Range(.Cells(38, col), .Cells(38, col)).Value = dtDatos.Rows(4)(col)
                .Range(.Cells(48, col), .Cells(48, col)).Value = dtDatos.Rows(5)(col)
                .Range(.Cells(58, col), .Cells(58, col)).Value = dtDatos.Rows(6)(col)
                .Range(.Cells(70, col), .Cells(70, col)).Value = dtDatos.Rows(13)(col)
                .Range(.Cells(71, col), .Cells(71, col)).Value = dtDatos.Rows(14)(col)
                .Range(.Cells(73, col), .Cells(73, col)).Value = dtDatos.Rows(15)(col)
                .Range(.Cells(74, col), .Cells(74, col)).Value = dtDatos.Rows(14)(col)
                .Range(.Cells(88, col), .Cells(88, col)).Value = dtDatos.Rows(7)(col)
                .Range(.Cells(89, col), .Cells(89, col)).Value = dtDatos.Rows(8)(col)
                .Range(.Cells(100, col), .Cells(100, col)).Value = dtDatos.Rows(9)(col)
                .Range(.Cells(110, col), .Cells(110, col)).Value = dtDatos.Rows(10)(col)
                .Range(.Cells(120, col), .Cells(120, col)).Value = dtDatos.Rows(11)(col)
                .Range(.Cells(130, col), .Cells(130, col)).Value = dtDatos.Rows(12)(col)
            Next
        End With
    End Sub

    Sub ImprimeSIG(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(1)(col)
                '.Range(.Cells(25, col), .Cells(25, col)).Value = dtDatos.Rows(2)(col)
                '.Range(.Cells(26, col), .Cells(26, col)).Value = dtDatos.Rows(3)(col)
                .Range(.Cells(36, col), .Cells(36, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(37, col), .Cells(37, col)).Value = dtDatos.Rows(3)(col)

                .Range(.Cells(48, col), .Cells(48, col)).Value = dtDatos.Rows(10)(col)
                .Range(.Cells(49, col), .Cells(49, col)).Value = dtDatos.Rows(11)(col)
                .Range(.Cells(50, col), .Cells(50, col)).Value = dtDatos.Rows(9)(col)

                .Range(.Cells(52, col), .Cells(52, col)).Value = dtDatos.Rows(4)(col)
                .Range(.Cells(53, col), .Cells(53, col)).Value = dtDatos.Rows(5)(col)
                .Range(.Cells(54, col), .Cells(54, col)).Value = dtDatos.Rows(6)(col)
                .Range(.Cells(55, col), .Cells(55, col)).Value = dtDatos.Rows(7)(col)
                .Range(.Cells(56, col), .Cells(56, col)).Value = dtDatos.Rows(8)(col)

                .Range(.Cells(67, col), .Cells(67, col)).Value = dtDatos.Rows(10)(col)
                .Range(.Cells(68, col), .Cells(68, col)).Value = dtDatos.Rows(11)(col)
                .Range(.Cells(69, col), .Cells(69, col)).Value = dtDatos.Rows(12)(col)
                .Range(.Cells(70, col), .Cells(70, col)).Value = dtDatos.Rows(9)(col)

                .Range(.Cells(72, col), .Cells(72, col)).Value = dtDatos.Rows(14)(col)
                .Range(.Cells(73, col), .Cells(73, col)).Value = dtDatos.Rows(15)(col)
                .Range(.Cells(74, col), .Cells(74, col)).Value = dtDatos.Rows(16)(col)
                .Range(.Cells(75, col), .Cells(75, col)).Value = dtDatos.Rows(17)(col)
            Next
        End With
    End Sub

    Sub ImprimeSOC(ByVal dtDatos As DataTable, ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        With objHojaExcel
            If dtDatos.Rows(0)("ACCION") = "OCULTA" Then
                objHojaExcel.Visible = False
                Exit Sub
            Else
                objHojaExcel.Visible = True
            End If
            For col As Int32 = 3 To 2 + cmbMesDesde.Value
                .Range(.Cells(14, col), .Cells(14, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(15, col), .Cells(15, col)).Value = dtDatos.Rows(0)(col)
                .Range(.Cells(25, col), .Cells(25, col)).Value = dtDatos.Rows(2)(col)
                .Range(.Cells(26, col), .Cells(26, col)).Value = dtDatos.Rows(3)(col)
                .Range(.Cells(27, col), .Cells(27, col)).Value = dtDatos.Rows(4)(col)
                .Range(.Cells(28, col), .Cells(28, col)).Value = dtDatos.Rows(5)(col)
                .Range(.Cells(29, col), .Cells(29, col)).Value = dtDatos.Rows(6)(col)
                .Range(.Cells(30, col), .Cells(30, col)).Value = dtDatos.Rows(7)(col)
                .Range(.Cells(40, col), .Cells(40, col)).Value = dtDatos.Rows(8)(col)
                .Range(.Cells(41, col), .Cells(41, col)).Value = dtDatos.Rows(9)(col)
                .Range(.Cells(51, col), .Cells(51, col)).Value = dtDatos.Rows(10)(col)
                .Range(.Cells(52, col), .Cells(52, col)).Value = dtDatos.Rows(9)(col)
                .Range(.Cells(58, col), .Cells(58, col)).Value = dtDatos.Rows(11)(col)
                .Range(.Cells(59, col), .Cells(59, col)).Value = dtDatos.Rows(9)(col)
                .Range(.Cells(82, col), .Cells(82, col)).Value = dtDatos.Rows(30)(col)
                .Range(.Cells(83, col), .Cells(83, col)).Value = dtDatos.Rows(31)(col)
                .Range(.Cells(95, col), .Cells(95, col)).Value = dtDatos.Rows(32)(col)
                .Range(.Cells(96, col), .Cells(96, col)).Value = dtDatos.Rows(33)(col)
            Next
        End With
    End Sub

    Sub Reporte_Grafico()
        Dim idconcepto As Int32 = gridCompra.ActiveRow.Cells("IDCONCEPTO").Value.ToString.Trim
        Dim desc_indicador As String = gridCompra.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
        Dim area As String = gridCompra.ActiveRow.Cells("AREA").Value.ToString.Trim
        Dim mes As Int32 = cmbMesDesde.Value
        Dim ayo As Int32 = txtayo.Value
        Dim dtDatos As New DataTable
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Anho = txtayo.Value
            _objEntidad.Mes = cmbMesDesde.Value
            _objEntidad.ID = idconcepto
            _objEntidad.Descripcion = desc_indicador
            _objEntidad.Usuario = userLogin

            If idconcepto = 0 And area = "COMPRAS" Then
                dtDatos = _objNegocio.INDICADOR_COMPRA_DETALLE(_objEntidad)
            End If

            If idconcepto = 0 And area = "COMERCIAL" Then
                dtDatos = _objNegocio.INDICADOR_COMERCIAL_DETALLE(_objEntidad)
            End If

            If idconcepto <> 0 Then
                dtDatos = _objNegocio.INDICADOR_DETALLE(_objEntidad)
            End If


            If dtDatos.Rows.Count > 0 Then
                Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
                Dim path As String
                path = Application.StartupPath
                File.Delete(path & "\REPORTEINDICADORES.xls")
                File.Copy(RutaReporteERP & "PLANTILLAINDICADORES.xls", path & "\REPORTEINDICADORES.xls")
                m_Excel.Workbooks.Open(path & "\REPORTEINDICADORES.xls")
                Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
                objHojaExcel.Name = "REPORTE"
                m_Excel.DisplayAlerts = False

                Dim nfila As Integer
                Dim nfilaini As Integer
                Dim nfilault As Integer = 0
                Dim n_mes As Int32 = 0
                nfila = 6
                nfilaini = 6

                With objHojaExcel
                    .Activate()
                    '.Range("A2").Value = "LISTADO DE MINERALES"
                    '.Range("A2").Font.Bold = True
                    Dim filaultima As Int32 = 0
                    Dim contactivo As Int32 = 0
                    For i As Int16 = 0 To dtDatos.Rows.Count - 1
                        n_mes = dtDatos.Rows(i)("MES")
                        .Range("C" & n_mes + nfila).Value = dtDatos.Rows(i)("INDICADOR")
                    Next

                End With
                m_Excel.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub
End Class
