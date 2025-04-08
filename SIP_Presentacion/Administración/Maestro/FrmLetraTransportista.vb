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
Imports System.Drawing.Printing

Public Class FrmLetraTransportista
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Dim rutaArchivosCorreo As String = "\\10.10.10.35\Transportista\"

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
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto
    Sub Buscar()
        If txtid.Text <> 0 Then Exit Sub
        Dim frm As New FrmListaTransportista
        frm.ShowDialog()
        txtcodtransp.Text = codMotivodetalle.Trim
        txttransportista.Text = Motivodetalle.Trim
        txtruc.Text = Ruc.Trim
    End Sub
    Sub Limpiar()
        txtcodtransp.Clear()
        txttransportista.Clear()
        txtid.Text = 0
        txtmonto.Clear()
        txtobservacion.Clear()
        txtruc.Clear()
        dtinicio.Value = Now.Date
        txtcodtransp.Focus()
        chkdevolucion.Visible = False
        chkdevolucion.Checked = False
    End Sub
    Sub Nuevo()
        Limpiar()
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Ope = 1
    End Sub

    Private Sub FrmLetraTransportista_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtcodtransp.Focus()
        dtpdevolucion.Value = Now.Date
        CargaDatos()
    End Sub
    Sub CargaDatos()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        Dim dt As New DataTable
        dt = _objNegocio.CargarLetras()
        Call CargarUltraGridxBinding(gridLetras, Source1, dt)

        ' Oculta dos últimas columnas
        ' hvilela
        ' --USP_LISTARLETRA_TRANSPORTISTA '01'
        Dim band As UltraGridBand = gridLetras.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.Columns("RutaConvenio").Hidden = True
        band.Columns("RutaLetra").Hidden = True

    End Sub

    Private Sub txtmonto_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmonto.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub gridLetras_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridLetras.DoubleClickRow
        Try
            txtid.Text = gridLetras.ActiveRow.Cells("ID").Value
            txtcodtransp.Text = gridLetras.ActiveRow.Cells("COD_TRANSP").Value.ToString.Trim
            txttransportista.Text = gridLetras.ActiveRow.Cells("TRANSPORTISTA").Value.ToString.Trim
            txtobservacion.Text = gridLetras.ActiveRow.Cells("OBSERVACION").Value.ToString.Trim
            txtmonto.Text = gridLetras.ActiveRow.Cells("MONTO").Value
            dtinicio.Value = gridLetras.ActiveRow.Cells("FECHAINICIO").Value
            txtruc.Value = gridLetras.ActiveRow.Cells("RUC").Value
            '*--------------------------------------------------------------------------------------------------------
            ' HVilela  - 20240808
            txtRutaConvenio.Text = gridLetras.ActiveRow.Cells("RUTACONVENIO").Value.ToString.Trim
            txtRutaLetra.Text = gridLetras.ActiveRow.Cells("RUTALETRA").Value.ToString.Trim
            '*--------------------------------------------------------------------------------------------------------
            chkdevolucion.Visible = True
            If gridLetras.ActiveRow.Cells("FLGDEVOLUCION").Value = 1 Then
                chkdevolucion.Checked = True
                dtpdevolucion.Visible = True
                dtpdevolucion.Value = gridLetras.ActiveRow.Cells("FECHADEVOLUCION").Value
                UltraLabel6.Visible = True
            Else
                chkdevolucion.Checked = False
                dtpdevolucion.Visible = False
                UltraLabel6.Visible = False
            End If
            Tab1.Tabs("T02").Selected = Boolean.TrueString

            Ope = 2
        Catch ex As Exception

        End Try
    End Sub
    Sub Procesar()
        Tab1.Tabs("T01").Selected = Boolean.TrueString
        Limpiar()
        CargaDatos()
    End Sub
    Sub Cancelar()
        Tab1.Tabs("T01").Selected = Boolean.TrueString
        Limpiar()
    End Sub
    Sub Actualizar()
        Procesar()
    End Sub

    Sub Grabar()
        Try
            If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
            If txtcodtransp.Text.Trim = "" Then MsgBox("Ingrese Transportista", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            If txtmonto.Text.Trim = "" Then txtmonto.Text = 0.0

            Dim dtValidacion As New DataTable
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.CodTransportista = txtcodtransp.Text
            dtValidacion = _objNegocio.ValidacionLetras(_objEntidad)

            If dtValidacion.Rows(0)(0) <> "OK" And txtid.Text = 0 Then
                MsgBox(dtValidacion.Rows(0)(0), MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If

            If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            If txtid.Text = 0 Then
                Ope = 1
            Else
                Ope = 2
            End If

            _objEntidad.CodTransportista = txtcodtransp.Text
            _objEntidad.Transportista = txttransportista.Text
            _objEntidad.FechaInicio = dtinicio.Value
            _objEntidad.FechaTerminacion = dtinicio.Value
            _objEntidad.User_Crea = User_Sistema
            _objEntidad.Monto = txtmonto.Text
            _objEntidad.Observacion = txtobservacion.Text
            _objEntidad.ID = txtid.Text
            _objEntidad.Tipo = Ope
            _objEntidad.flgdevolucion = IIf(chkdevolucion.Checked = True, 1, 0)
            _objEntidad.fechadevolucion = dtpdevolucion.Value
            '*--------------------------------------------------------------------------------------------------------
            ' HVilela  - 20240808
            _objEntidad.RutaConvenio = txtRutaConvenio.Text
            _objEntidad.RutaLetra = txtRutaLetra.Text
            '*--------------------------------------------------------------------------------------------------------
            Dim id As Int32
            id = _objNegocio.Letra_Transportista(_objEntidad)
            If id <> 0 Then
                MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
                txtid.Text = id
                'If Ope = 1 Then
                '    Reporte()
                'End If
                Procesar()
            Else
                MsgBox("Se Produjo un Error al Grabar", MsgBoxStyle.Information, msgComacsa)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Sub Eliminar()
        Try
            If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
            If txtcodtransp.Text.Trim = "" Then MsgBox("Ingrese Transportista", MsgBoxStyle.Information, msgComacsa) : Exit Sub
            If txtmonto.Text.Trim = "" Then txtmonto.Text = 0.0
            If MsgBox("¿Seguro desea eliminar letra?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            Ope = 3
            _objEntidad.CodTransportista = txtcodtransp.Text
            _objEntidad.Transportista = txttransportista.Text
            _objEntidad.FechaInicio = dtinicio.Value
            _objEntidad.FechaTerminacion = dtinicio.Value
            _objEntidad.User_Crea = User_Sistema
            _objEntidad.Monto = txtmonto.Text
            _objEntidad.Observacion = txtobservacion.Text
            _objEntidad.ID = txtid.Text
            _objEntidad.Tipo = Ope
            _objEntidad.flgdevolucion = IIf(chkdevolucion.Checked = True, 1, 0)
            _objEntidad.fechadevolucion = dtpdevolucion.Value
            Dim id As Int32
            id = _objNegocio.Letra_Transportista(_objEntidad)
            If id <> 0 Then
                MsgBox("Se eliminó Correctamente lo Letra", MsgBoxStyle.Information, msgComacsa)
                Procesar()
            Else
                MsgBox("Se Produjo un Error al Eliminar", MsgBoxStyle.Information, msgComacsa)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub Reporte()
        If Tab1.Tabs("T01").Selected = Boolean.TrueString Then
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Try

                If gridLetras.Rows.Count > 0 Then

                    Dim path As String
                    path = Application.StartupPath
                    File.Delete(path & "\REPORTELETRAS.xls")
                    File.Copy(RutaReporteERP & "PLANTILLALETRAS.xls", path & "\REPORTELETRAS.xls")
                    m_Excel.Workbooks.Open(path & "\REPORTELETRAS.xls")
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
                        .Range("A2").Value = "LISTADO DE LETRAS POR TRANSPORTISTA"
                        .Range("A2").Font.Bold = True
                        Dim filaultima As Int32 = 0

                        For i As Int16 = 0 To gridLetras.Rows.Count - 1
                            .Range("A" & 5 + i).Value = gridLetras.Rows(i).Cells("NUMLETRA")
                            .Range("B" & 5 + i).Value = gridLetras.Rows(i).Cells("COD_TRANSP")
                            .Range("C" & 5 + i).Value = gridLetras.Rows(i).Cells("RUC")
                            .Range("D" & 5 + i).Value = gridLetras.Rows(i).Cells("TRANSPORTISTA")
                            .Range("E" & 5 + i).Value = gridLetras.Rows(i).Cells("FECHAINICIO")
                            .Range("F" & 5 + i).Value = gridLetras.Rows(i).Cells("OBSERVACION")

                            .Range(.Cells(5 + i, 1), .Cells(5 + i, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                            nfila = nfila + 1
                            filaultima = 5 + i
                        Next
                        '.Range(.Cells(filaultima + 1, 5), .Cells(filaultima + 1, 5)).Value = "Total"
                        '.Range(.Cells(filaultima + 1, 6), .Cells(filaultima + 1, 6)).Formula = "=SUMA(F5:F" & filaultima & ")"
                        '.Range(.Cells(filaultima + 1, 5), .Cells(filaultima + 1, 6)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                        '.Range(.Cells(filaultima + 1, 5), .Cells(filaultima + 1, 6)).Font.Bold = True
                    End With
                    m_Excel.Visible = True
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
            End Try
        Else
            Exit Sub
        End If
        'If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
        'If MsgBox("¿Desea imprimir letra?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
        ''MsgBox("Imprimir letra " & txtid.Text)
        'Dim ruta As String

        ''Dim fs As FileStream = File.Create(ruta)
        ''fs.Close()
        '_objNegocio = New NGProducto
        '_objEntidad = New ETProducto
        'Dim dt As New DataTable
        '_objEntidad.ID = txtid.Text
        'dt = _objNegocio.CargarLetraID(_objEntidad.ID)
        'If dt.Rows.Count <= 0 Then Exit Sub
        'Dim sw As New System.IO.StreamWriter(ruta)
        'Try
        '    generarTxtLetra(sw, dt)
        '    sw.Close()
        '    DestinoPort(dt.Rows(0)("IMPRESORA"), ruta)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        '    sw.Close()
        '    Cursor = Cursors.Default
        'End Try
    End Sub
    Sub generarTxtLetra(ByVal sw As System.IO.StreamWriter, ByVal dt As DataTable)
        Dim monto As Double = dt.Rows(0)("MONTO")
        sw.WriteLine(Chr(27) & "C" & Chr(23)) '& "C"
        sw.WriteLine(Chr(15))
        sw.Write(Espacio(30) & dt.Rows(0)("NUMLETRA") & Espacio(25))
        sw.Write(Convert.ToDateTime(dt.Rows(0)("FECHAINICIO")).ToString(" dd   MM  yyyy") & Espacio(6))
        sw.Write("LIMA" & Espacio(12))
        'sw.Write(Convert.ToDateTime(dt.Rows(0)("FECHAVENCIMIENTO")).ToString(" dd   MM  yyyy") & Espacio(6))
        sw.Write(Espacio(14) & Espacio(6)) ' FECHA VENCIMIENTO
        If monto <= 0 Then
            sw.Write("" & Espacio(3))
        Else
            sw.Write("S/." & Espacio(3) & dt.Rows(0)("MONTO"))
        End If
        sw.WriteLine(Espacio(15))
        sw.WriteLine("") ': sw.WriteLine("")
        sw.WriteLine(Espacio(31) & IIf(monto <= 0, "", monto_palabras(dt.Rows(0)("MONTO"))))
        sw.WriteLine("") : sw.WriteLine("")
        sw.WriteLine(Espacio(37) & dt.Rows(0)("TRANSPORTISTA")) : sw.WriteLine("")
        sw.WriteLine(Espacio(37) & dt.Rows(0)("DIRECCION")) : sw.WriteLine("") ': sw.WriteLine("")
        sw.WriteLine(Espacio(40) & dt.Rows(0)("RUC"))
        sw.WriteLine("") : sw.WriteLine("") : sw.WriteLine("") : sw.WriteLine("") : sw.WriteLine("") : sw.WriteLine("")
        sw.WriteLine(Chr(15))
        sw.WriteLine(Chr(12) & Chr(13))
        sw.WriteLine("") : sw.WriteLine("") : sw.WriteLine("") : sw.WriteLine("")
    End Sub

    Dim fileToPrint As System.IO.StreamReader
    Dim printFont As System.Drawing.Font
    Dim FILE_NOTIFY_CHANGE_LAST_WRITE = 16
    Declare Function CopyFile Lib "kernel32" Alias "CopyFileA" (ByVal lpExistingFileName As String, ByVal lpNewFileName As String, ByVal bFailIfExists As Long) As Long


    Sub DestinoPort(ByVal wSalida As String, ByVal wFileSal As String)
        Dim rsp As Long
        Dim i As Integer

        rsp = 1
        rsp = CopyFile(wFileSal, wSalida, FILE_NOTIFY_CHANGE_LAST_WRITE)
        Dim BUSCA As Object
        Dim Files(5) As String
        Files(0) = "FACTURA"
        Files(1) = "BOLETA"
        Files(2) = "GUIA"
        Files(3) = "XXX" 'NOTACREDITO
        Files(4) = "YYY" 'NOTADEBITO
        Files(5) = "BILLETE_DEVOLUCION" 'BILLETE_DEVOLUCION

        For i = 0 To UBound(Files)
            BUSCA = InStr(1, UCase(wFileSal), UCase(Files(i)))
            If BUSCA > 0 And Trim(UCase(User_Sistema)) <> "SA" Then
                'EliminaFile wFileSal 'Modificado el 09-01-2007
            End If
        Next
        'X = Nothing
    End Sub

    Private Sub Imprime(ByVal Path As String, ByVal dt As DataTable)
        Dim PrintPath As String = System.Environment. _
        GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        fileToPrint = New System.IO.StreamReader(Path)
        printFont = New System.Drawing.Font("Arial", 10)
        PrintDocument1.PrinterSettings.PrinterName = dt.Rows(0)("IMPRESORA") '"\\198.9.9.20\FX890C"
        PrintDocument1.Print()
        fileToPrint.Close()
    End Sub

    Function Espacio(ByVal cant As Int32) As String
        Dim cadena As String = String.Empty
        For i As Int32 = 0 To cant - 1
            cadena = cadena + " "
        Next
        Return cadena
    End Function

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = e.MarginBounds.Left
        Dim topMargin As Single = e.MarginBounds.Top
        Dim line As String = Nothing
        linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics)
        While count < linesPerPage
            line = fileToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(e.Graphics)
            e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, _
               yPos, New StringFormat())
            count += 1
        End While
        If Not (line Is Nothing) Then
            e.HasMorePages = True
        End If
    End Sub

    Dim indice As Integer
    Dim primero As Integer
    Dim desde As Integer
    Dim unidad1 As Integer
    Dim posicion As Integer
    Dim largo1 As Integer
    Dim cant_paso As String
    Dim cantidad_pal As String

    Public Function monto_palabras(ByVal cantidad As String)
        Dim Deci As String
        'Deci = cantidad.Format("#############0.00")
        Dim array() As String
        array = Split(cantidad, ".")
        Deci = array(1)
        'Deci = Right(Format(cantidad, "#############0.00"), 2)
        cantidad = Convert.ToInt32(array(0))

        Call llena_arreglo()
        cantidad_pal = ""
        largo1 = Len(cantidad)
        desde = 1
        primero = largo1 Mod 3
        unidad1 = Int(largo1 / 3)

        If primero = 0 Then
            primero = 3
        Else
            unidad1 = unidad1 + 1
        End If

        posicion = unidad1
        For indice As Int32 = primero To largo1 Step 3

            cant_paso = Mid$(cantidad, desde, indice - desde + 1)
            cantidad_pal = centena(cant_paso, posicion, unidad1, cantidad_pal, indice, largo1)
            desde = indice + 1
            posicion = posicion - 1
        Next indice
        monto_palabras = UCase(cantidad_pal) & " CON " & Deci & "/100  "
    End Function

    Dim unidades(10) As String
    Dim decenas(10) As String
    Dim dec_esp(10) As String
    Dim miles(12) As String

    Sub llena_arreglo()
        unidades(1) = "un"
        unidades(2) = "dos"
        unidades(3) = "tres"
        unidades(4) = "cuatro"
        unidades(5) = "cinco"
        unidades(6) = "seis"
        unidades(7) = "siete"
        unidades(8) = "ocho"
        unidades(9) = "nueve"

        dec_esp(1) = "diez"
        dec_esp(2) = "once"
        dec_esp(3) = "doce"
        dec_esp(4) = "trece"
        dec_esp(5) = "catorce"
        dec_esp(6) = "quince"

        decenas(1) = "diez"
        decenas(2) = "veinte"
        decenas(3) = "treinta"
        decenas(4) = "cuarenta"
        decenas(5) = "cincuenta"
        decenas(6) = "sesenta"
        decenas(7) = "setenta"
        decenas(8) = "ochenta"
        decenas(9) = "noventa"

        miles(1) = ""
        miles(2) = "mil"
        miles(3) = "millon"
        miles(4) = "mil"
        miles(5) = "billon"
        miles(6) = "mil"
        miles(7) = "trillon"
        miles(8) = "mil"
        miles(9) = "cuadrillon"
        miles(10) = "mil"
        miles(11) = "quintillon"
        miles(12) = "mil"
    End Sub
    Function centena(ByVal gabi As String, ByVal Pos As Integer, ByVal Total As Integer, ByVal cant_pal As String, ByVal pPosAct As Integer, ByVal pPosFin As Integer)
        Dim numero1 As Integer
        Dim numero2 As Integer
        Dim numero3 As Integer
        Dim largo As String
        Dim cant1 As String
        Dim unidad As String
        cant1 = ""
        unidad = ""

        If Pos Mod 2 <> 0 And Pos <> 1 And Val(gabi) <> 1 Then
            unidad = miles(Pos) + "es"
        Else
            unidad = miles(Pos)
        End If

        numero1 = 0
        numero2 = 0
        numero3 = 0
        largo = Len(gabi)

        If largo = "1" Then
            numero3 = Val(Mid$(gabi, 1, 1))
        End If

        If largo = "2" Then
            numero2 = Val(Mid$(gabi, 1, 1))
            numero3 = Val(Mid$(gabi, 2, 1))
        End If

        If largo = "3" Then
            numero1 = Val(Mid$(gabi, 1, 1))
            numero2 = Val(Mid$(gabi, 2, 1))
            numero3 = Val(Mid$(gabi, 3, 1))
        End If

        If numero1 = 0 And numero2 = 0 And numero3 = 0 And Pos = 2 Then
            unidad = ""
        End If

        Select Case numero1
            Case 0
            Case 1
                If numero1 = 1 And (numero2 <> 0 Or numero3 <> 0) Then
                    cant1 = "ciento"
                Else
                    cant1 = "cien"
                End If
            Case 5
                cant1 = "quinientos"
            Case 7
                cant1 = "setecientos"
            Case 9
                cant1 = "novecientos"
            Case Else
                cant1 = unidades(numero1) + "cientos"
        End Select

        If numero2 = 1 And numero3 <= 5 Then
            cant1 = cant1 + " " + dec_esp(numero3 + 1)
        Else
            If numero2 <> 0 Then
                cant1 = cant1 + " " + decenas(numero2)
                If numero3 <> 0 Then
                    cant1 = cant1 + " y"
                End If
            End If

            If numero3 <> 0 Then
                If Len(cant1) = 0 Then
                    cant1 = unidades(numero3)
                Else

                    cant1 = cant1 + " " + unidades(numero3)

                End If
            End If
        End If

        cant_pal = cant_pal + " " + cant1 + " " + unidad

        If pPosAct = pPosFin Then
            If numero2 > 1 And numero3 = 1 Then
                cant_pal = RTrim(cant_pal) + "O"
            End If
            If numero2 = 0 And numero3 = 1 Then
                cant_pal = RTrim(cant_pal) + "O"
            End If
        End If
        centena = cant_pal

    End Function

    Private Sub gridLetras_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridLetras.InitializeLayout

    End Sub

    Private Sub chkdevolucion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdevolucion.CheckedChanged
        If chkdevolucion.Checked = True Then
            UltraLabel6.Visible = True
            dtpdevolucion.Visible = True
        Else
            UltraLabel6.Visible = False
            dtpdevolucion.Visible = False
        End If
    End Sub

    Function ObtenerNombreReporte(ByVal RutaBase As String, ByVal NombreBase As String)

        Dim fechaHora As String = DateTime.Now.ToString("yyyyMMdd_HHmm")
        Dim nombreConFecha As String = System.IO.Path.GetFileNameWithoutExtension(NombreBase) & "_" & fechaHora & System.IO.Path.GetExtension(NombreBase)
        Return System.IO.Path.Combine(RutaBase, nombreConFecha)
        ''Return RutaBase & NombreBase
    End Function

    Private Sub btnAdjuntarConvenio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjuntarConvenio.Click

        Dim path As String = rutaArchivosCorreo
        Dim FileConvenio As String

        Try
            OpenFIle.CheckFileExists = True
            OpenFIle.CheckPathExists = True
            OpenFIle.DereferenceLinks = True
            OpenFIle.ValidateNames = True
            OpenFIle.Multiselect = False
            OpenFIle.RestoreDirectory = True
            OpenFIle.ShowHelp = True
            OpenFIle.ShowReadOnly = False
            OpenFIle.DefaultExt = "pdf"
            OpenFIle.Title = "Seleccione Archivo de Convenio"
            OpenFIle.Filter = "PDF Acrobat (*.pdf)|*.pdf|Microsoft Word (*.doc)|*.doc"
            If OpenFIle.ShowDialog() = 1 Then
                If OpenFIle.FileName.Length > 0 Then
                    FileConvenio = ObtenerNombreReporte(path, OpenFIle.SafeFileName)
                    System.IO.File.Copy(OpenFIle.FileName, FileConvenio, True)
                    txtRutaConvenio.Text = FileConvenio
                End If
            End If

        Catch objException As Exception
            MsgBox("Error: Cargar Arhivo()" & vbCrLf & objException.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub


    Private Sub btnAdjuntarLetra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjuntarLetra.Click

        Dim path As String = rutaArchivosCorreo
        Dim FileLetra As String

        Try
            OpenFIle.CheckFileExists = True
            OpenFIle.CheckPathExists = True
            OpenFIle.DereferenceLinks = True
            OpenFIle.ValidateNames = True
            OpenFIle.Multiselect = False
            OpenFIle.RestoreDirectory = True
            OpenFIle.ShowHelp = True
            OpenFIle.ShowReadOnly = False
            OpenFIle.DefaultExt = "pdf"
            OpenFIle.Title = "Seleccione Archivo de Convenio"
            OpenFIle.Filter = "PDF Acrobat (*.pdf)|*.pdf|Microsoft Word (*.doc)|*.doc"
            If OpenFIle.ShowDialog() = 1 Then
                If OpenFIle.FileName.Length > 0 Then
                    FileLetra = ObtenerNombreReporte(path, OpenFIle.SafeFileName)
                    System.IO.File.Copy(OpenFIle.FileName, FileLetra, True)
                    txtRutaLetra.Text = FileLetra
                End If
            End If

        Catch objException As Exception
            MsgBox("Error: Cargar Arhivo()" & vbCrLf & objException.Message, MsgBoxStyle.Critical, "Error")

        End Try

    End Sub

    Private Sub UltraTabPageControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UltraTabPageControl1.Paint

    End Sub

    Private Sub btnVisorConvenio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisorConvenio.Click
        Dim filePath As String = txtRutaConvenio.Text
        ' Verificar que el archivo existe
        If System.IO.File.Exists(filePath) Then
            Try
                ' Abrir el archivo con la aplicación predeterminada
                Try
                    ' Intentar abrir el archivo con la aplicación predeterminada
                    Process.Start(filePath)
                Catch win32Ex As System.ComponentModel.Win32Exception
                    ' Controlar el error cuando no hay ninguna aplicación asociada
                    If win32Ex.ErrorCode = -2147467259 Then
                        MessageBox.Show("No hay ninguna aplicación asociada con el archivo especificado para esta operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("Se produjo un error al intentar abrir el archivo: " & win32Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    ' Controlar otros errores posibles
                    MessageBox.Show("Se produjo un error inesperado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Catch ex As Exception
                MessageBox.Show("No se pudo abrir el archivo: " & ex.Message)
            End Try
        Else
            MessageBox.Show("El archivo no se encontró.")
        End If
    End Sub

    Private Sub btnVisorLetra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisorLetra.Click
        Dim filePath As String = txtRutaLetra.Text
        ' Verificar que el archivo existe
        If System.IO.File.Exists(filePath) Then
            Try
                ' Abrir el archivo con la aplicación predeterminada
                Try
                    ' Intentar abrir el archivo con la aplicación predeterminada
                    Process.Start(filePath)
                Catch win32Ex As System.ComponentModel.Win32Exception
                    ' Controlar el error cuando no hay ninguna aplicación asociada
                    If win32Ex.ErrorCode = -2147467259 Then
                        MessageBox.Show("No hay ninguna aplicación asociada con el archivo especificado para esta operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("Se produjo un error al intentar abrir el archivo: " & win32Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    ' Controlar otros errores posibles
                    MessageBox.Show("Se produjo un error inesperado: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Catch ex As Exception
                MessageBox.Show("No se pudo abrir el archivo: " & ex.Message)
            End Try
        Else
            MessageBox.Show("El archivo no se encontró.")
        End If
    End Sub
End Class