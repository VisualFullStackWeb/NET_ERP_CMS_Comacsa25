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
Public Class FrmConstanciamalLlenada
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
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto

    Private Sub FrmConstanciamalLlenada_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpDesde.Value = "01/" & Month(Now.Date) & "/" & Year(Now.Date)
        dtpDesde.Value = DateAdd(DateInterval.Month, -1, dtpDesde.Value)
        dtpHasta.Value = Now.Date
        CargaDatos()
        CargarErrores()
    End Sub
    Sub CargaDatos()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        Dim dt As New DataTable
        _objEntidad.FechaInicio = dtpDesde.Value
        _objEntidad.FechaTerminacion = dtpHasta.Value
        dt = _objNegocio.CargarConstanciaError(_objEntidad)
        Call CargarUltraGridxBinding(gridListado, Source1, dt)
    End Sub
    Sub Nuevo()
        Limpiar()
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Ope = 1
        txtbillete.ReadOnly = False
    End Sub
    Sub Limpiar()
        txtbillete.Focus()
        txtbillete.Clear()
        txtconstancia.Clear()
        txtconfiguracion.Clear()
        txtpeso.Text = 0
        txtobservacion.Clear()
        txtidconstanciaerror.Text = 0
        txtidconstanciapeso.Text = 0
    End Sub

    Private Sub txtbillete_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtbillete.KeyDown
        Try
            If e.KeyValue = Keys.Enter Then
                CargaBillete(txtbillete.Text)
            End If
        Catch ex As Exception
            '
        End Try
    End Sub
    Sub CargaBillete(ByVal billete As String)
        Try
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            Dim dt As New DataTable
            dt = _objNegocio.CargarConstanciaBillete(billete)
            If dt.Rows.Count > 0 Then
                txtconstancia.Text = dt.Rows(0)("NUMCONSTANCIA").ToString.Trim
                txtpeso.Text = dt.Rows(0)("PESO")
                txtconfiguracion.Text = dt.Rows(0)("CONFIGURACION").ToString.Trim
                txtidconstanciapeso.Text = dt.Rows(0)("ID")
                txtconstancia.ReadOnly = False
                txtpeso.ReadOnly = False
                txtconfiguracion.ReadOnly = False
            Else
                MsgBox("N° de billete no existe", MsgBoxStyle.Exclamation, msgComacsa)
                txtconstancia.Clear()
                txtpeso.Clear()
                txtconfiguracion.Clear()
                txtidconstanciapeso.Text = 0
                txtconstancia.ReadOnly = True
                txtpeso.ReadOnly = True
                txtconfiguracion.ReadOnly = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub gridListado_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridListado.DoubleClickRow
        Try
            txtidconstanciaerror.Text = gridListado.ActiveRow.Cells("IDCONSTANCIAERROR").Value
            txtbillete.Text = gridListado.ActiveRow.Cells("NUMBILLETE").Value.ToString.Trim
            txtobservacion.Text = gridListado.ActiveRow.Cells("OBSERVACION").Value.ToString.Trim
            cmberror.Value = gridListado.ActiveRow.Cells("IDERROR").Value.ToString.Trim
            CargaBillete(txtbillete.Text)
            Tab1.Tabs("T02").Selected = Boolean.TrueString
            Ope = 2
            txtbillete.ReadOnly = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarErrores()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        Dim dt As New DataTable
        dt = _objNegocio.CargarDescripcionError()
        Call CargarUltraCombo(cmberror, dt, "ID", "DESCRIPCION")
    End Sub

    Private Sub cmberror_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmberror.InitializeLayout
        With cmberror.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("DESCRIPCION").Width = 800 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "DESCRIPCION") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub
    Sub Grabar()
        If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
        If txtbillete.Text.Trim = "" Then MsgBox("Ingrese N° de billete correcto", MsgBoxStyle.Exclamation, msgComacsa) : txtbillete.Focus() : Exit Sub
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        Dim dt As New DataTable
        dt = _objNegocio.CargarConstanciaBillete(txtbillete.Text)
        If dt.Rows.Count <= 0 Then
            MsgBox("Ingrese N° de billete correcto", MsgBoxStyle.Exclamation, msgComacsa)
            txtbillete.Focus()
            txtconstancia.Clear()
            txtpeso.Clear()
            txtconfiguracion.Clear()
            txtidconstanciapeso.Text = 0
            txtconstancia.ReadOnly = True
            txtpeso.ReadOnly = True
            txtconfiguracion.ReadOnly = True
        End If

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        If txtpeso.Text.Trim = "" Then txtpeso.Text = 0
        Ope = 1
        _objEntidad.numbillete = txtbillete.Text
        _objEntidad.iderror = cmberror.Value
        _objEntidad.Observacion = txtobservacion.Text
        _objEntidad.Configuracion = txtconfiguracion.Text
        _objEntidad.Peso = txtpeso.Text
        _objEntidad.numconstancia = txtconstancia.Text
        _objEntidad.User_Crea = User_Sistema
        _objEntidad.Tipo = Ope
        Dim id As Int32
        id = _objNegocio.Inserta_ConstanciaError(_objEntidad)
        If id <> 0 Then
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            Procesar()
        Else
            MsgBox("Se Produjo un Error al Grabar", MsgBoxStyle.Information, msgComacsa)
        End If

    End Sub

    Private Sub txtpeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpeso.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub
    Sub Procesar()
        Tab1.Tabs("T01").Selected = Boolean.TrueString
        Limpiar()
        CargaDatos()
    End Sub

    Sub Eliminar()
        If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
        If txtidconstanciaerror.Text.Trim = 0 Then MsgBox("Seleccione registro a eliminar", MsgBoxStyle.Exclamation, msgComacsa) : Exit Sub
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
       

        If MsgBox("¿Seguro desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto

        Ope = 3

        _objEntidad.numbillete = txtbillete.Text
        _objEntidad.iderror = cmberror.Value
        _objEntidad.Observacion = txtobservacion.Text
        _objEntidad.Configuracion = txtconfiguracion.Text
        _objEntidad.Peso = txtpeso.Text
        _objEntidad.numconstancia = txtconstancia.Text
        _objEntidad.User_Crea = User_Sistema
        _objEntidad.Tipo = Ope
        Dim id As Int32
        id = _objNegocio.Inserta_ConstanciaError(_objEntidad)
        If id <> 0 Then
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            Procesar()
        Else
            MsgBox("Se Produjo un Error al Grabar", MsgBoxStyle.Information, msgComacsa)
        End If

    End Sub

    Sub Reporte()
        If Tab1.Tabs("T01").Selected = Boolean.TrueString Then
            Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            Try

                If gridListado.Rows.Count > 0 Then

                    Dim path As String
                    path = Application.StartupPath
                    File.Delete(path & "\REPORTECONSTANCIAERROR.xls")
                    File.Copy(RutaReporteERP & "PLANTILLAMALLLENADO.xls", path & "\REPORTECONSTANCIAERROR.xls")
                    m_Excel.Workbooks.Open(path & "\REPORTECONSTANCIAERROR.xls")
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
                        .Range("A1").Value = "CONSTANCIA DE PESO MAL LLENADA DEL " & dtpDesde.Value & " AL " & dtpHasta.Value
                        .Range("A1").Font.Bold = True
                        Dim filaultima As Int32 = 0

                        For i As Int16 = 0 To gridListado.Rows.Count - 1
                            .Range("A" & 4 + i).Value = gridListado.Rows(i).Cells("FECHA")
                            .Range("B" & 4 + i).Value = gridListado.Rows(i).Cells("CODCANTERA")
                            .Range("C" & 4 + i).Value = gridListado.Rows(i).Cells("CANTERA")
                            .Range("D" & 4 + i).Value = gridListado.Rows(i).Cells("NUMBILLETE")
                            .Range("E" & 4 + i).Value = gridListado.Rows(i).Cells("ERROR")
                            .Range("F" & 4 + i).Value = gridListado.Rows(i).Cells("NUMCONSTANCIA")
                            .Range("G" & 4 + i).Value = gridListado.Rows(i).Cells("CONFIGURACION")
                            .Range("H" & 4 + i).Value = gridListado.Rows(i).Cells("PESO")
                            .Range("I" & 4 + i).Value = gridListado.Rows(i).Cells("OBSERVACION")
                            .Range("I" & 4 + i).WrapText = False
                            .Range(.Cells(4 + i, 1), .Cells(4 + i, 9)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
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

    End Sub

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged

    End Sub
End Class