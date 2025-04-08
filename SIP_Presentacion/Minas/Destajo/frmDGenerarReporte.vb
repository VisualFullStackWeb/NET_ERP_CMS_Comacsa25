Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmDGenerarReporte
    Private Ls_ListaContratista As List(Of ETCanteraCosteo) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Enum Alineacion
        Izquierda = -4131
        Derecha = -4152
        Centrado = -4108
    End Enum
    Dim Obj_Excel As Object
    Dim Obj_Libro As Object
    Dim Obj_Hoja As Object
    Dim Fila As Integer

    Private Sub frmDGenerarReporte_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmDGenerarReporte_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)
    End Sub

    Private Sub frmDGenerarReporte_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Ls_ListaContratista IsNot Nothing Then Ls_ListaContratista = Nothing


    End Sub
    Private Sub frmDGenerarReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Nuevo()

    End Sub

    Public Sub Nuevo()
        Dtp1.Value = Now.Date
        Txt2.Clear()
        Txt3.Clear()
        Cbo2.Value = ""
        Ls_ListaContratista = Nothing
        Ls_ListaContratista = New List(Of ETCanteraCosteo)
        Call CargarUltraGrid(Grid1, Ls_ListaContratista)
    End Sub

    Public Sub Buscar()

        xFormulario = "Cantera_Contratista"

        If String.IsNullOrEmpty(Txt3.Value) Then
            Dim Proveedor As New FrmProveedores
            Proveedor.ShowDialog()
            Txt2.Text = Trim(Proveedor.Codigo & "")
            Txt3.Text = Trim(Proveedor.RazonSocial & "")
            Proveedor = Nothing
        End If

    End Sub

    Public Sub Procesar()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .Opcion = 7
            .Fecha = CDate(Dtp1.Value).Date
            .Esquema = Cbo2.Value
        End With
        Tab1.Tabs("T01").Selected = Boolean.TrueString
        Entidad.MyLista = Negocio.CanteraCosteo.ConsultarCanteraContratista(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_ListaContratista = New List(Of ETCanteraCosteo)
        Ls_ListaContratista = Entidad.MyLista.Ls_CanteraCosteo

        CargarUltraGrid(Grid1, Ls_ListaContratista)

    End Sub

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If sender Is Nothing Then Exit Sub

        For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
            If xCol.Key = "ID" Or xCol.Key = "CodigoProveedor" Or _
            xCol.Key = "Proveedor" Or xCol.Key = "CodigoCantera" Or _
            xCol.Key = "Cantera" Or xCol.Key = "CodEmpleado" Or _
            xCol.Key = "Empleado" Or xCol.Key = "Fecha" Or _
            xCol.Key = "Action" Or xCol.Key = "Action" Then
                If xCol.Key = "Action" Then
                    xCol.CellActivation = Activation.AllowEdit
                Else
                    xCol.CellActivation = Activation.ActivateOnly
                End If
            Else
                xCol.Hidden = True
            End If
        Next
    End Sub

    Public Sub Excel()
        'Dim ds_Contratista As DataSet
        'Dim dt_Contratista As DataTable
        Grid1.Update()
        Grid1.UpdateData()
        Dim Lista_Temp As New List(Of ETCanteraCosteo)
        Dim Lista As New List(Of ETCanteraCosteo)
        Lista_Temp = Grid1.DataSource
        'dt_Contratista = ds_Contratista.Tables(0)

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        If Lista_Temp.Count > 0 Then
            For Each xRow As ETCanteraCosteo In Lista_Temp
                If xRow.Action = True Then
                    xRow.CodCia = Companhia
                    Lista.Add(xRow)
                End If
            Next
        End If

        'If dt_Contratista.Rows.Count > 0 Then
        '    For Each xRow As DataRow In dt_Contratista.Rows
        '        If xRow.Item("Action") = True Then
        '            Entidad.CanteraCosteo = New ETCanteraCosteo
        '            With Entidad.CanteraCosteo
        '                .ID = xRow.Item("ID")
        '                .CodigoProveedor = xRow.Item("CodigoProveedor")
        '                .Proveedor = xRow.Item("Proveedor")
        '                .CodigoCantera = xRow.Item("CodigoCantera")
        '                .Cantera = xRow.Item("Cantera")
        '                .CodEmpleado = xRow.Item("CodEmpleado")
        '                .Empleado = xRow.Item("Empleado")
        '                .ID = xRow.Item("Fecha")
        '            End With
        '            Lista.Add(Entidad.CanteraCosteo)
        '        End If
        '    Next
        'End If

        If Lista.Count < 0 Then
            MsgBox("Debe Seleccionar al Menos un Registro de Contratista", MsgBoxStyle.Critical, msgComacsa)

            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If Cbo2.Value = "01" Then
            Call Excel_Esquema1(Lista)
        End If

        



        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Excel_Esquema1(ByVal Lista As List(Of ETCanteraCosteo))
        If Lista Is Nothing Then Exit Sub
        Dim Letra2 As String
        Dim LetraP As String = String.Empty
        Dim LetraT As String = String.Empty
        Dim LetraS As String = String.Empty
        Dim Letra As String = String.Empty
        Dim CadenaTotal As String = String.Empty
        Dim falta As Boolean = False
        Dim FilaInicio As Integer = 0
        Obj_Excel = CreateObject("Excel.Application")
        Obj_Libro = Obj_Excel.Workbooks.Add()
        Fila = 0

        For Each xRow As ETCanteraCosteo In Lista
            Dim ds As New DataSet
            Dim dt_Falta As New DataTable
            Dim dt_Mineral As New DataTable
            Dim dt_Personal As New DataTable
            Dim dt_ResumenFalta As New DataTable
            Dim TonFalta As Double = 0
            Dim Precio As Double = 0
            Dim TonNormal As Double = 0

            Negocio.CanteraCosteo = New NGCanteraCosteo
            ds = Negocio.CanteraCosteo.Generar_Cantera_Contratista_Esquema1(xRow)

            dt_Falta = ds.Tables(0)
            dt_Mineral = ds.Tables(1)
            dt_Personal = ds.Tables(2)
            dt_ResumenFalta = ds.Tables(3)

            Obj_Hoja = Obj_Libro.Sheets(1)
            Obj_Hoja.Activate()
            Obj_Hoja.Columns("A").ColumnWidth = 2.83
            Obj_Hoja.Columns("B").ColumnWidth = 50

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "PLANILLA AL " & xRow.Fecha.Date & " - " & UCase(xRow.Proveedor.Trim)
            Call FormatoCelda("B" & CStr(Fila) & ":B" & CStr(Fila + 1), "Arial", True, 10)

            Fila = Fila + 2
            Obj_Hoja.Cells(Fila, 2) = "CANTERA " & UCase(xRow.Cantera.Trim)
            Call FormatoCelda("B" & CStr(Fila) & ":B" & CStr(Fila + 1), "Arial", True, 10)
            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "SUPERVISOR: " & UCase(xRow.Empleado.Trim)
            Dim Columna As Integer = 3
            If dt_Mineral.Rows.Count > 0 And dt_Personal.Rows.Count > 0 Then
                Fila = Fila + 2
                For Each mRow As DataRow In dt_Mineral.Rows

                    LetraS = Letra_ColumnaExcel(Columna)

                    Obj_Hoja.Columns(LetraS).ColumnWidth = 20

                    Obj_Hoja.Cells(Fila, Columna).NumberFormat = "@"
                    'Obj_Hoja.Cells(Fila, Columna) = mRow.Item("Cod_MatPrima")
                    With Obj_Hoja.Cells(Fila, Columna)
                        '.HorizontalAlignment = 
                        .VerticalAlignment = Alineacion.Centrado
                        .WrapText = True
                    End With
                    Obj_Hoja.Cells(Fila, Columna) = mRow.Item("Cod_MatPrima").ToString.Trim & " - " & mRow.Item("Mineral")
                    Columna = Columna + 1
                    With Obj_Hoja.Cells(Fila, Columna)
                        '.HorizontalAlignment = 
                        .VerticalAlignment = Alineacion.Centrado
                        .WrapText = True
                    End With
                    Obj_Hoja.Cells(Fila, Columna) = "Precio x TON"
                    Columna = Columna + 1
                    With Obj_Hoja.Cells(Fila, Columna)
                        '.HorizontalAlignment = 
                        .VerticalAlignment = Alineacion.Centrado
                        .WrapText = True
                    End With
                    Obj_Hoja.Cells(Fila, Columna) = "Toneladas"
                    Columna = Columna + 1
                Next
                With Obj_Hoja.Cells(Fila, Columna)
                    '.HorizontalAlignment = 
                    .VerticalAlignment = Alineacion.Centrado
                    .WrapText = True
                End With

                LetraS = Letra_ColumnaExcel(Columna + 1)
                Obj_Hoja.Columns(LetraS).ColumnWidth = 20

                With Obj_Hoja.Cells(Fila, Columna)
                    '.HorizontalAlignment = 
                    .VerticalAlignment = Alineacion.Centrado
                    .WrapText = True
                End With

                With Obj_Hoja.Cells(Fila, Columna + 1)
                    '.HorizontalAlignment = 
                    .VerticalAlignment = Alineacion.Centrado
                    .WrapText = True
                End With

                Obj_Hoja.Cells(Fila, Columna) = "Descuento"
                Columna = Columna + 1
                Obj_Hoja.Cells(Fila, Columna) = "TOTAL A REMUNERACION"
                Letra2 = Letra_ColumnaExcel(dt_Mineral.Rows.Count * 3 + 4)
                Call FormatoCelda("C" & CStr(Fila) & ":" & Letra2 & CStr(Fila), "Arial", True, 8, , 1)

                Fila = Fila + 1
                FilaInicio = Fila
                For Each pRow As DataRow In dt_Personal.Rows
                    Obj_Hoja.Cells(Fila, 2) = pRow.Item("PlaCod").ToString.Trim & " - " & pRow.Item("Personal").ToString.Trim
                    Columna = 3
                    CadenaTotal = "=SUM("
                    For Each mRow As DataRow In dt_Mineral.Rows
                        falta = False
                        Precio = Val(mRow.Item("Precio"))
                        If pRow.Item("Adic") = "1" Then
                            Precio = Precio + Val(mRow.Item("Bonif"))
                        End If

                        If dt_Falta.Rows.Count > 0 Then
                            For Each fRow As DataRow In dt_Falta.Rows
                                If fRow.Item("PlaCod") = pRow.Item("Placod") And _
                                    fRow.Item("Cod_MatPrima") = mRow.Item("Cod_MatPrima") Then
                                    TonFalta = fRow.Item("PorrateoFalta")
                                    falta = True
                                    Exit For
                                End If
                            Next
                        End If

                        If falta = False Then
                            TonNormal = Val(mRow.Item("TonPorrateo"))
                            LetraS = Letra_ColumnaExcel(Columna)
                            Obj_Hoja.Cells(Fila, Columna).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, Columna) = TonNormal * Precio
                            Columna = Columna + 1
                            LetraP = Letra_ColumnaExcel(Columna)
                            Obj_Hoja.Cells(Fila, Columna).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, Columna) = Precio
                            Columna = Columna + 1
                            LetraT = Letra_ColumnaExcel(Columna)
                            Obj_Hoja.Cells(Fila, Columna).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, Columna) = TonNormal
                            Columna = Columna + 1
                        Else
                            LetraS = Letra_ColumnaExcel(Columna)
                            Obj_Hoja.Cells(Fila, Columna).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, Columna) = TonFalta * Precio
                            Columna = Columna + 1
                            LetraP = Letra_ColumnaExcel(Columna)
                            Obj_Hoja.Cells(Fila, Columna).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, Columna) = Precio
                            Columna = Columna + 1
                            LetraP = Letra_ColumnaExcel(Columna)
                            Obj_Hoja.Cells(Fila, Columna).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, Columna) = TonFalta
                            Columna = Columna + 1
                        End If
                        If CadenaTotal = "=SUM(" Then
                            CadenaTotal = CadenaTotal & LetraS & CStr(Fila)
                        Else
                            CadenaTotal = CadenaTotal & "," & LetraS & CStr(Fila)
                        End If

                    Next
                    LetraS = Letra_ColumnaExcel(Columna)
                    If CadenaTotal = "=SUM(" Then
                        CadenaTotal = CadenaTotal & LetraS & CStr(Fila)
                    Else
                        CadenaTotal = CadenaTotal & "," & LetraS & CStr(Fila)
                    End If
                    Obj_Hoja.Cells(Fila, Columna).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, Columna) = pRow.Item("Descuento")
                    Columna = Columna + 1
                    CadenaTotal = CadenaTotal & ")"
                    Obj_Hoja.Cells(Fila, Columna).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, Columna) = CadenaTotal

                    Letra2 = Letra_ColumnaExcel(dt_Mineral.Rows.Count * 3 + 4)

                    Call FormatoCelda("B" & CStr(Fila) & ":" & Letra2 & CStr(Fila + 1), "Arial", False, 8, , 1)
                    Fila = Fila + 1
                Next

                Obj_Hoja.Cells(Fila, 2) = "TOTAL"
                Obj_Hoja.Cells(Fila + 1, 2) = "Tn Totales"
                Columna = 3
                For Each mRow As DataRow In dt_Mineral.Rows
                    Obj_Hoja.Cells(Fila, Columna).NumberFormat = "#,##0.0000"
                    LetraS = Letra_ColumnaExcel(Columna)
                    Obj_Hoja.Cells(Fila, Columna) = "=SUM(" & LetraS & CStr(FilaInicio) & ":" & LetraS & CStr(Fila - 1) & ")"

                    Letra = Letra_ColumnaExcel(Columna + 2)
                    Obj_Hoja.Cells(Fila + 1, Columna).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila + 1, Columna) = "=" & Letra & CStr(Fila)


                    Columna = Columna + 2
                    LetraT = Letra_ColumnaExcel(Columna)
                    Obj_Hoja.Cells(Fila, Columna).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, Columna) = "=SUM(" & LetraT & CStr(FilaInicio) & ":" & LetraT & CStr(Fila - 1) & ")"

                    Columna = Columna + 1
                Next
                LetraS = Letra_ColumnaExcel(Columna)
                Obj_Hoja.Cells(Fila, Columna) = "=SUM(" & LetraS & CStr(FilaInicio) & ":" & LetraS & CStr(Fila - 1) & ")"
                Call FormatoCelda("B" & CStr(Fila) & ":" & Letra2 & CStr(Fila), "Arial", True, 8, , 1)

                Fila = Fila + 2
                Dim columna_ant As Integer = 0

                If dt_ResumenFalta.Rows.Count > 0 Then
                    FilaInicio = Fila
                    For Each rRow As DataRow In dt_ResumenFalta.Rows
                        Obj_Hoja.Cells(Fila, 2) = "Tn deducido faltas Guia " & Mid(rRow.Item("Guias").ToString.Trim, 1, Len(rRow.Item("Guias").ToString.Trim) - 2) & " - " & rRow.Item("PlaCod").ToString.Trim & " " & rRow.Item("Personal").ToString.Trim
                        Columna = 3
                        columna_ant = Columna
                        For Each mRow As DataRow In dt_Mineral.Rows
                            For Each fRow As DataRow In dt_Falta.Rows
                                If fRow.Item("PlaCod") = rRow.Item("Placod") And _
                                    fRow.Item("Cod_MatPrima") = mRow.Item("Cod_MatPrima") Then
                                    Obj_Hoja.Cells(Fila, Columna).NumberFormat = "#,##0.0000"
                                    Obj_Hoja.Cells(Fila, Columna) = fRow.Item("Tonelaje")

                                    Columna = Columna + 2
                                    Obj_Hoja.Cells(Fila, Columna).NumberFormat = "#,##0.0000"
                                    Obj_Hoja.Cells(Fila, Columna) = fRow.Item("PorrateoFalta")

                                    Columna = Columna + 1
                                End If
                            Next
                            If Columna = columna_ant Then
                                Columna = Columna + 3
                                columna_ant = Columna
                            Else
                                columna_ant = Columna
                            End If

                        Next
                        Fila = Fila + 1
                    Next


                    Fila = Fila + 4
                    Columna = 3

                    Obj_Hoja.Cells(Fila + 2, 2) = "Total"
                    Obj_Hoja.Cells(Fila + 3, 2) = "Personal con faltas"
                    Obj_Hoja.Cells(Fila + 4, 2) = "Tn a prorratear"
                    Obj_Hoja.Cells(Fila + 5, 2) = "Trabajadores"

                    For Each mRow As DataRow In dt_Mineral.Rows


                        Obj_Hoja.Cells(Fila + 2, Columna).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila + 2, Columna) = mRow.Item("Tonelaje")

                        Letra = Letra_ColumnaExcel(Columna + 2)
                        Obj_Hoja.Cells(Fila + 3, Columna).NumberFormat = "#,##0.0000"

                        Obj_Hoja.Cells(Fila + 3, Columna) = "=" & Letra & CStr(Fila)
                        Letra = Letra_ColumnaExcel(Columna)
                        Obj_Hoja.Cells(Fila + 4, Columna).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila + 4, Columna) = "=" & Letra & CStr(Fila + 2) & "-" & Letra & CStr(Fila + 3)

                        Obj_Hoja.Cells(Fila + 5, Columna).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila + 5, Columna) = "=" & Letra & CStr(Fila + 4) & "/" & Val(mRow.Item("NroPers"))

                        Call FormatoCelda(Letra & CStr(Fila + 5) & ":" & Letra & CStr(Fila + 5), "Arial", True, 8)

                        Columna = Columna + 2
                        Letra = Letra_ColumnaExcel(Columna)
                        Obj_Hoja.Cells(Fila, Columna).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, Columna) = "=sum(" & Letra & CStr(FilaInicio) & ":" & Letra & CStr(Fila - 1) & ")"
                        Call FormatoCelda(Letra & CStr(Fila) & ":" & Letra & CStr(Fila), "Arial", True, 8)
                        Columna = Columna + 1
                    Next

                End If

                Fila = Fila + 5
                Fila = Fila + 3
            End If

        Next

        Obj_Hoja = Obj_Libro.Sheets(1)
        Obj_Hoja.Activate()

        Obj_Excel.visible = True

        Obj_Hoja = Nothing
        Obj_Libro = Nothing
        Obj_Excel = Nothing

    End Sub

    Private Sub FormatoCelda(ByVal RANGO As String, ByVal TipoLetra As String, _
   ByVal Negrita As Boolean, ByVal TamañoLetra As Integer, Optional ByVal color As Integer = 0, _
   Optional ByVal Linea As Integer = 0, Optional ByVal Relleno As Integer = 0)

        With Obj_Hoja.range(RANGO)
            .Font.Name = TipoLetra
            .Font.Bold = Negrita
            .Font.Size = TamañoLetra
            If Val(color) > 0 Then .Font.ColorIndex = color
            If Val(Linea) > 0 Then .Borders.LineStyle = Linea
            If Val(Relleno) > 0 Then .Interior.ColorIndex = Relleno

        End With
    End Sub

    Private Sub CombinarCeldas(ByVal RANGO As String, ByVal Alinear As Long)
        Obj_Excel.range(RANGO).Select()
        ' Estableces MergeCells a True para combinar Y false para descombinar las celdas
        Obj_Excel.Selection.MergeCells = True
        Obj_Excel.range(RANGO).HorizontalAlignment = Alinear
        Obj_Excel.range(RANGO).VerticalAlignment = -4108 'Alineacion.Centrado
        Obj_Excel.ActiveCell.WrapText = True

        'Obj_Hoja

    End Sub

End Class