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
Public Class frmCalculoPPago
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

    Private Sub frmCalculoPPago_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFecha.Value = Now.Date
        cmbMoneda.SelectedIndex = 0
        Procesar()
    End Sub
    Sub Procesar()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.CodTransportista = txtcodprov.Text
        Dim dtDatos As New DataTable
        dtDatos = _objNegocio.Listar_Calculo_PP(_objEntidad)
        Call CargarUltraGridxBinding(Me.gridCalculo, Source2, dtDatos)
        Factura_Pagar()
    End Sub
    Sub Buscar()
        Dim frm As New FrmListaTransportista
        frm.ShowDialog()
        txtcodprov.Text = codMotivodetalle.Trim
        'txtproveedor.Text = Motivodetalle.Trim
        'Tasa_Proveedor()
        'Factura_Pagar()

        Entidad.Contratista = New ETContratista
        Negocio.NContratista = New NGContratista
        Entidad.MyLista = New ETMyLista
        Entidad.Contratista.Usuario = User_Sistema
        Entidad.Contratista._codprov = txtcodprov.Text
        Dim dtDatos2 As New DataTable
        dtDatos2 = Negocio.NContratista.Listar_PRO_Prov_Codigo(Entidad.Contratista)
        txtcodprov.Tag = ""
        UlblNota.Text = ""
        If dtDatos2.Rows.Count > 0 Then
            txtcodprov.Text = dtDatos2.Rows(0)("COD_PROV")
            txtproveedor.Text = dtDatos2.Rows(0)("PROVEEDOR")
            UlblNota.Text = "TIENE_LETRA_FIRMADA:" + dtDatos2.Rows(0)("TIENE_LETRA_FIRMADA") + Space(1) + vbCrLf + "TIENE_EXONERACION_LETRA_FIRMADA:" + dtDatos2.Rows(0)("TIENE_EXONERACION_LETRA_FIRMADA")
            txtcodprov.Tag = dtDatos2.Rows(0)("TIENE_LETRA_FIRMADA")
        Else
            MsgBox("El código no existe", MsgBoxStyle.Exclamation, msgComacsa)
            txtproveedor.Clear()
        End If
        Tasa_Proveedor()
        Factura_Pagar()

    End Sub
    Sub Nuevo()
        Tab1.Tabs("T02").Selected = True
        limpiar()
        Factura_Pagar()
        txtcodprov.Focus()
    End Sub
    Sub limpiar()
        txtid.Text = 0
        txtcodprov.Clear()
        txtproveedor.Clear()
        txttea.Clear()
        txtted.Clear()
        dtpFecha.Value = Now.Date
        txtcodigo.Clear()
        UlblNota.Clear()

    End Sub
    Private Sub txtcodprov_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodprov.KeyDown
        If e.KeyData = Keys.Return Then
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista._codprov = txtcodprov.Text
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NContratista.Listar_PRO_Prov_Codigo(Entidad.Contratista)
            txtcodprov.Tag = ""
            UlblNota.Text = ""
            If dtDatos.Rows.Count > 0 Then
                txtcodprov.Text = dtDatos.Rows(0)("COD_PROV")
                txtproveedor.Text = dtDatos.Rows(0)("PROVEEDOR")                
                UlblNota.Text = "TIENE_LETRA_FIRMADA:" + dtDatos.Rows(0)("TIENE_LETRA_FIRMADA") + Space(1) + vbCrLf + "TIENE_EXONERACION_LETRA_FIRMADA:" + dtDatos.Rows(0)("TIENE_EXONERACION_LETRA_FIRMADA")
                txtcodprov.Tag = dtDatos.Rows(0)("TIENE_LETRA_FIRMADA")
            Else
                MsgBox("El código no existe", MsgBoxStyle.Exclamation, msgComacsa)
                txtproveedor.Clear()
            End If
            Tasa_Proveedor()
            Factura_Pagar()
        End If
    End Sub

    Sub Tasa_Proveedor()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.CodTransportista = txtcodprov.Text
        Dim dtDatos As New DataTable
        dtDatos = _objNegocio.Tasa_Proveedor(_objEntidad)
        If dtDatos.Rows.Count > 0 Then
            txttea.Text = dtDatos.Rows(0)("TEA")
            txtted.Text = dtDatos.Rows(0)("TED")
        Else
            txttea.Text = "15.000"
            txtted.Text = "15.000"
        End If
    End Sub
    Dim dtFactura As New DataTable
    Sub Factura_Pagar()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.CodTransportista = txtcodprov.Text
        _objEntidad.Moneda = cmbMoneda.Value
        _objEntidad.Fecha = dtpFecha.Value
        Dim dtDatos As New DataTable
        dtFactura = _objNegocio.Factura_Pagar(_objEntidad)
        Call CargarUltraGridxBinding(Me.gridFactura, Source1, dtFactura)
    End Sub

    Sub Factura_Calculo()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.CodTransportista = txtcodprov.Text
        _objEntidad.ID = txtid.Text
        Dim dtDatos As New DataTable
        dtFactura = _objNegocio.Factura_Calculo(_objEntidad)
        Call CargarUltraGridxBinding(Me.gridFactura, Source1, dtFactura)
    End Sub

    Private Sub gridFactura_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridFactura.ClickCell
        Try
            If gridFactura.ActiveRow.Index < 0 Then Exit Sub
            If gridFactura.ActiveRow.Cells(gridFactura.ActiveCell.Column.Index).Column.Key = "MARCA" Then
                gridFactura.PerformAction(ExitEditMode)
                If gridFactura.ActiveRow.Cells("MARCA").Value.ToString = "True" Then
                    Dim fecha_1 As Date
                    Dim fecha_2 As Date
                    Dim dias As Integer
                    Dim monto As Double = gridFactura.ActiveRow.Cells("SALDO").Value
                    Dim dscto As Double = 0
                    Dim ted As Double = CDbl(txtted.Text) / 100
                    Dim tea As Double = CDbl(txttea.Text) / 100
                    fecha_1 = gridFactura.ActiveRow.Cells("FECHA_VTO").Value
                    fecha_2 = dtpFecha.Value
                    dias = (fecha_1 - fecha_2).TotalDays
                    gridFactura.ActiveRow.Cells("DIASADELANTO").Value = dias
                    '=IMPTOTAL*(1-1/(1+(1+TASAANUAL)^(DIAS/360)-1))
                    dscto = CDbl(monto) * CDbl(1 - 1 / (1 + Math.Pow((1 + tea), (dias / 360)) - 1))
                    gridFactura.ActiveRow.Cells("DSCTO").Value = Math.Round(dscto, 2)
                Else
                    gridFactura.ActiveRow.Cells("DIASADELANTO").Value = 0
                    gridFactura.ActiveRow.Cells("DSCTO").Value = "0.00"
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Try
            If txtted.Text.Trim = "" And txttea.Text.Trim = "" Then Exit Sub

            For i As Int32 = 0 To gridFactura.Rows.Count - 1
                If gridFactura.Rows(i).Cells("MARCA").Value.ToString = "True" Then
                    Dim fecha_1 As Date
                    Dim fecha_2 As Date
                    Dim dias As Integer
                    Dim monto As Double = gridFactura.Rows(i).Cells("SALDO").Value
                    Dim dscto As Double = 0
                    Dim ted As Double = CDbl(txtted.Text) / 100
                    Dim tea As Double = CDbl(txttea.Text) / 100
                    gridFactura.Rows(i).Cells("DIASADELANTO").Value = 0
                    gridFactura.Rows(i).Cells("DSCTO").Value = "0.00"
                    fecha_1 = gridFactura.Rows(i).Cells("FECHA_VTO").Value
                    fecha_2 = dtpFecha.Value
                    dias = (fecha_1 - fecha_2).TotalDays
                    gridFactura.Rows(i).Cells("DIASADELANTO").Value = dias
                    'dscto = CDbl((monto * ted) * dias)
                    'gridFactura.Rows(i).Cells("DSCTO").Value = Math.Round(dscto, 3)
                    dscto = CDbl(monto) * CDbl(1 - 1 / (1 + Math.Pow((1 + tea), (dias / 360)) - 1))
                    gridFactura.Rows(i).Cells("DSCTO").Value = Math.Round(dscto, 2)
                Else
                    gridFactura.Rows(i).Cells("DIASADELANTO").Value = 0
                    gridFactura.Rows(i).Cells("DSCTO").Value = "0.00"
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Sub Grabar()
        gridFactura.PerformAction(ExitEditMode)

        If txtcodprov.Tag.ToString.Trim = "NO" And User_Sistema <> "SA" Then 'validar contrato firmado 
            MsgBox("Proveedor no tiene contrato firmado.", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        If dtpFecha.Value < Now.Date Then
            MsgBox("No puede seleccionar una fecha menor a la actual", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        Dim cont As Int32 = 0
        For i As Int32 = 0 To gridFactura.Rows.Count - 1
            If gridFactura.Rows(i).Cells("MARCA").Value.ToString = "True" Then
                cont += 1
            End If
        Next
        If cont = 0 Then
            MsgBox("Debe seleccionar mínimo una factura", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        If cont > 12 Then
            MsgBox("Solo puede agregar 12 facturas al cálculo", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        If txttea.Text <= 0 Then
            MsgBox("El proveedor no tiene TASA asignada", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        Try
            If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
            Dim dtValidacion As New DataTable
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            If MsgBox("¿Seguro desea guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Tipo = 1
            _objEntidad.ID = txtid.Text
            _objEntidad.CodTransportista = txtcodprov.Text
            _objEntidad.tea = txttea.Text
            _objEntidad.ted = txtted.Text
            _objEntidad.Fecha = dtpFecha.Value
            _objEntidad.Estado = "0"
            _objEntidad.Usuario = User_Sistema
            _objEntidad.Moneda = cmbMoneda.Value
            Dim resul As String = ""
            resul = _objNegocio.Ingreso_Calculo_Cab(_objEntidad, dtFactura)
            If resul = "OK" Then
                MsgBox("Se guardaron correctamente los datos", MsgBoxStyle.Information, msgComacsa)
                limpiar()
                Procesar()
                Tab1.Tabs("T01").Selected = True
            Else
                MsgBox(resul, MsgBoxStyle.Information, msgComacsa)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub Eliminar()
        If txtid.Text = 0 Then
            MsgBox("Debe seleccionar registro a eliminar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If

        Try
            If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
            Dim dtValidacion As New DataTable
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            If MsgBox("¿Seguro desea eliminar el cálculo?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.Tipo = 3
            _objEntidad.ID = txtid.Text
            _objEntidad.CodTransportista = txtcodprov.Text
            _objEntidad.tea = txttea.Text
            _objEntidad.ted = txtted.Text
            _objEntidad.Fecha = dtpFecha.Value
            _objEntidad.Estado = "0"
            _objEntidad.Usuario = User_Sistema
            Dim resul As String = ""
            resul = _objNegocio.Ingreso_Calculo_Cab(_objEntidad, dtFactura)
            If resul = "OK" Then
                MsgBox("Se eliminó correctamente el cálculo", MsgBoxStyle.Information, msgComacsa)
                limpiar()
                Factura_Pagar()
                Procesar()
                Tab1.Tabs("T01").Selected = True
            Else
                MsgBox(resul, MsgBoxStyle.Information, msgComacsa)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub gridCalculo_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridCalculo.DoubleClickRow
        Try
            Tab1.Tabs("T02").Selected = True
            txtid.Text = gridCalculo.ActiveRow.Cells("ID").Value
            txtcodprov.Text = gridCalculo.ActiveRow.Cells("COD_PROV").Value
            txtproveedor.Text = gridCalculo.ActiveRow.Cells("PROVEEDOR").Value
            txttea.Text = gridCalculo.ActiveRow.Cells("TEA").Value
            txtted.Text = gridCalculo.ActiveRow.Cells("TED").Value
            dtpFecha.Value = gridCalculo.ActiveRow.Cells("FECHA_PAGO").Value
            txtcodigo.Text = gridCalculo.ActiveRow.Cells("CODIGO").Value
            txtruc.Text = gridCalculo.ActiveRow.Cells("RUC").Value
            cmbMoneda.Value = gridCalculo.ActiveRow.Cells("MONEDA").Value
            UlblNota.Text = "TIENE_LETRA_FIRMADA:" + gridCalculo.ActiveRow.Cells("TIENE_LETRA_FIRMADA").Value + Space(1) + vbCrLf + "TIENE EXONERACION LETRA_FIRMADA:" + gridCalculo.ActiveRow.Cells("TIENE_EXONERACION_LETRA_FIRMADA").Value
            txtcodprov.Tag = gridCalculo.ActiveRow.Cells("TIENE_LETRA_FIRMADA").Value

            Factura_Calculo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMoneda_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMoneda.ValueChanged
        Try
            Procesar()
        Catch ex As Exception

        End Try
    End Sub

    Sub Reporte()
        If txtid.Text = "" Then txtid.Text = 0
        If txtid.Text = 0 Then
            MsgBox("Debe grabar el cálculo para generar el reporte", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If
        If gridFactura.Rows.Count <= 0 Then
            MsgBox("No existen datos para el reporte", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
        Try

            Dim path As String
            path = Application.StartupPath
            File.Delete(path & "\REPORTEPRONTOPAGO.xls")
            File.Copy(RutaReporteERP & "PLANTILLAPRONTOPAGO_2024.xls", path & "\REPORTEPRONTOPAGO.xls")
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlWait
            m_Excel.Workbooks.Open(path & "\REPORTEPRONTOPAGO.xls")
            m_Excel.DisplayAlerts = False
            Dim objHojaExcelIngreso As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)
            objHojaExcelIngreso.Name = txtproveedor.Text.Substring(0, 31)
            'm_Excel.Visible = True
            exportarReporte(objHojaExcelIngreso)
            'm_Excel.Visible = True
            m_Excel.Cursor = Microsoft.Office.Interop.Excel.XlMousePointer.xlDefault
            'Dim ruta As String = "C:\Users\sistemas\Desktop\PRONTOPAGO_" & txtcodigo.Text & ".pdf"
            Dim ruta As String = RutaReporteERP_PP & "PRONTOPAGO_" & txtcodigo.Text & ".pdf"
            File.Delete(ruta)
            m_Excel.ActiveSheet.ExportAsFixedFormat(Type:=Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, Filename:= _
         ruta _
         , IncludeDocProperties:=True, IgnorePrintAreas:=False, OpenAfterPublish:= _
         True)
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.CodTransportista = txtcodprov.Text
            _objEntidad.Observacion = ruta
            Dim dtDatos As New DataTable
            dtDatos = _objNegocio.Listar_Correo_PP(_objEntidad)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            m_Excel.Workbooks.Close()
            m_Excel.Quit()
            GC.Collect()
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub
    Sub exportarReporte(ByVal objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet)
        Try
            Dim ultFila As Int32 = 0
            Dim ultFila2 As Int32 = 0
            Dim filaCompra As Int32 = 0

            Dim nfila As Integer = 29
            Dim nfilaini As Integer = 29
            Dim nfilault As Integer = 0
            Dim nfilaArea As Integer = 29
            Dim nfilainiArea As Integer = 29
            Dim nfilaultArea As Integer = 0

            With objHojaExcel
                .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
                .Activate()            
                Dim nmes As Int32 = 0
                .Range("A1").Value = "Alcances para el descuento por pronto pago - N° " & txtcodigo.Text
                .Range("E24").Value = CDbl(txttea.Text) / 100
                .Range("K25").Value = dtpFecha.Value
                .Range("G52").Value = DatePart(DateInterval.Day, Now.Date)
                .Range("I52").Value = nombreMEs(Month(Now.Date))
                .Range("K52").Value = Year(Now.Date)
                .Range("A2").Value = "Proveedor:  " & txtproveedor.Text.ToString.Trim & Chr(10) & "RUC: " & txtruc.Text & Chr(10) & "Código: " & txtcodprov.Text

                .Range("D28").Value = "Importe total de la factura " & cmbMoneda.Value & " (Incluye IGV)"
                .Range("J28").Value = "Descuento por pronto pago " & cmbMoneda.Value & " (1)"
                .Range("K28").Value = "Importe neto a pagar " & cmbMoneda.Value & " (2)"

                '.Range("L29").Value = cmbMoneda.Value
                '.Range("L30").Value = cmbMoneda.Value
                '.Range("L31").Value = cmbMoneda.Value
                For I As Int32 = 0 To gridFactura.Rows.Count - 1
                    If gridFactura.Rows(I).Cells("MARCA").Value.ToString = "True" Then
                        '.Range(.Cells(nfila + I, 2), .Cells(nfila + I, 2)).Value = gridFactura.Rows(I).Cells("FECHA_DOC").Value
                        '.Range(.Cells(nfila + I, 3), .Cells(nfila + I, 3)).Value = "FA " & gridFactura.Rows(I).Cells("NUM_DOC").Value.ToString.Substring(1, 3) & "-" & gridFactura.Rows(I).Cells("NUM_DOC").Value.ToString.Substring(14, 6)
                        '.Range(.Cells(nfila + I, 4), .Cells(nfila + I, 4)).Value = gridFactura.Rows(I).Cells("SALDO").Value
                        '.Range(.Cells(nfila + I, 5), .Cells(nfila + I, 5)).Value = gridFactura.Rows(I).Cells("FECHA_RECEPCION").Value
                        '.Range(.Cells(nfila + I, 6), .Cells(nfila + I, 6)).Value = gridFactura.Rows(I).Cells("FECHA_VTO").Value
                        '.Range(.Cells(nfila + I, 7), .Cells(nfila + I, 7)).Value = gridFactura.Rows(I).Cells("DIASADELANTO").Value
                        '.Range(.Cells(nfila + I, 8), .Cells(nfila + I, 8)).Value = gridFactura.Rows(I).Cells("DSCTO").Value
                        '.Range(.Cells(nfila + I, 9), .Cells(nfila + I, 9)).Value = "=D" & nfila + I & "-H" & nfila + I & ""
                        '=D31-H31


                        .Range(.Cells(nfila + I, 2), .Cells(nfila + I, 2)).Value = gridFactura.Rows(I).Cells("FECHA_DOC").Value
                        .Range(.Cells(nfila + I, 3), .Cells(nfila + I, 3)).Value = "FA " & gridFactura.Rows(I).Cells("NUM_DOC").Value.ToString.Substring(1, 3) & "-" & gridFactura.Rows(I).Cells("NUM_DOC").Value.ToString.Substring(14, 6)
                        '.Range(.Cells(nfila + I, 4), .Cells(nfila + I, 4)).Value = gridFactura.Rows(I).Cells("SALDO").Value
                        .Range(.Cells(nfila + I, 4), .Cells(nfila + I, 4)).Value = gridFactura.Rows(I).Cells("IMPTOTALORIGEN").Value
                        'IMPTOTALORIGEN

                        'NEW 130924 GABY
                        .Range(.Cells(nfila + I, 5), .Cells(nfila + I, 5)).Value = gridFactura.Rows(I).Cells("MONTO_RETENCION").Value
                        .Range(.Cells(nfila + I, 61), .Cells(nfila + I, 6)).Value = "=D" & nfila + I & "-E" & nfila + I & ""
                        '.Range(.Cells(nfila + I, 6), .Cells(nfila + I, 6)).Value = gridFactura.Rows(I).Cells("SALDO_RETENCION").Value


                        .Range(.Cells(nfila + I, 7), .Cells(nfila + I, 7)).Value = gridFactura.Rows(I).Cells("FECHA_RECEPCION").Value
                        .Range(.Cells(nfila + I, 8), .Cells(nfila + I, 8)).Value = gridFactura.Rows(I).Cells("FECHA_VTO").Value
                        .Range(.Cells(nfila + I, 9), .Cells(nfila + I, 9)).Value = gridFactura.Rows(I).Cells("DIASADELANTO").Value

                        .Range(.Cells(nfila + I, 10), .Cells(nfila + I, 10)).Value = gridFactura.Rows(I).Cells("DSCTO").Value
                        .Range(.Cells(nfila + I, 11), .Cells(nfila + I, 11)).Value = "=F" & nfila + I & "-J" & nfila + I & ""


                    End If
                    'nmes = dtAnual.Rows(I)("MES")
                Next
            End With

        Catch ex As Exception

        End Try
    End Sub
    Function nombreMEs(ByVal mes As Int32) As String
        Select Case mes
            Case 1
                Return "ENERO"
            Case 2
                Return "FEBRERO"
            Case 3
                Return "MARZO"
            Case 4
                Return "ABRIL"
            Case 5
                Return "MAYO"
            Case 6
                Return "JUNIO"
            Case 7
                Return "JULIO"
            Case 8
                Return "AGOSTO"
            Case 9
                Return "SETIEMBRE"
            Case 10
                Return "OCTUBRE"
            Case 11
                Return "NOVIEMBRE"
            Case Else
                Return "DICIEMBRE"
        End Select
        Return ""
    End Function

    Private Sub gridCalculo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridCalculo.InitializeLayout

    End Sub

    Private Sub gridFactura_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridFactura.InitializeLayout

    End Sub

    Private Sub txtcodprov_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodprov.ValueChanged

    End Sub

    Private Sub UltraTabPageControl2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles UltraTabPageControl2.Paint

    End Sub

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged

    End Sub
End Class