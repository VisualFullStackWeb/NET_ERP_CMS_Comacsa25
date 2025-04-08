Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.Office.Interop
Imports SIP_Entidad

Public Class frmConsultaParteAsistencia
    Public Ls_Permisos As New List(Of Integer)
#Region "Propiedades"
    Private Property codigoArea() As String
        Get
            Return cbArea.SelectedValue
        End Get
        Set(ByVal value As String)
            cbArea.SelectedValue = value
        End Set
    End Property
    Private Property fechaInicio() As Date
        Get
            Return Me.dtpFechaInicio.Value
        End Get
        Set(ByVal value As Date)
            Me.dtpFechaInicio.Value = value
        End Set
    End Property
    Private fechaFin As Date
    Private Property fechaFinTexto() As String
        Get
            Return txtFechaFin.Text
        End Get
        Set(ByVal value As String)
            txtFechaFin.Text = value
        End Set
    End Property
    Private ReadOnly Property ordenarPor() As Short
        Get

            Dim value As Short = 0

            If Me.rbCodigo.Checked = True Then
                value = 1
            End If

            Return value
        End Get
    End Property

#End Region
#Region "Otros"
    Private Sub comboArea()

        Dim business As New SIP_Negocio.ParteAsistencia()
        With Me.cbArea
            .DataSource = business.comboArea()
            .DisplayMember = "DESCRIPCION"
            .ValueMember = "codigo"
        End With

    End Sub
    Private Sub calcularFechaFin()

        Me.fechaFin = fechaInicio.AddDays(6)
        Me.fechaFinTexto = Me.fechaFin.ToShortDateString

    End Sub

    Private Sub generarParteSemanal()

        Dim business As New SIP_Negocio.ParteAsistencia()
        Dim lista As New List(Of SIP_Entidad.ParteAsistencia)
        mostrarEstado("PEND")
        lista = business.generarParteAsistencia(Me.codigoArea, Me.fechaInicio, Me.fechaFin, Me.ordenarPor)
        If lista.Count < 1 Then
            MessageBox.Show("No hay datos para generar el Parte de Asistencia", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            mostrarEstado("")
            Exit Sub
        End If
        mostrarEstado("PROC")
        ExportToExcel(lista)

        mostrarEstado("FIN")
        'MessageBox.Show("Operación realizada satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub mostrarEstado(ByVal estado As String)

        Dim nombreEstado As String = ""
        Select Case estado.ToUpper
            Case "PEND"
                nombreEstado = "En proceso..."

            Case "PROC"

                nombreEstado = "Exportando..."
            Case "FIN"
                nombreEstado = "Finalizado"
        End Select

        Me.lblEstadoEjec.Text = nombreEstado
        Me.pnlEstado.Visible = nombreEstado.Length > 0
        Me.Refresh()
        Threading.Thread.Sleep(700)

    End Sub
    Private Sub ExportToExcel(ByVal lista As List(Of SIP_Entidad.ParteAsistencia))

        Try

            Dim excelApp = New Excel.Application()
            excelApp.Workbooks.Add()
            Dim hoja As Excel._Worksheet = excelApp.ActiveSheet

            Const horasSemanales As Integer = 48
            Const horasDiarias As Integer = 8
            Const horaSabado5 As Integer = 5
            Const colorAzul As Integer = 16748574

            With hoja
                Dim filaIndex As Integer = 1
                Dim columnaIndex As Integer = 3

                .Columns("A").ColumnWidth = 6
                .Columns("B").ColumnWidth = 35

                'titulo 01
                .Cells(filaIndex, columnaIndex) = "PARTE DE ASISTENCIA - ÁREA : " & Me.cbArea.Text.ToUpper
                .Range("C1:AL1").Merge()
                .Range("C1:AL1").Font.Bold = True
                .Range("C1:AL1").Font.Size = 15
                .Range("C1:AL1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                .Range("C1:AL1").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                'titulo 02
                filaIndex = filaIndex + 1
                .Cells(filaIndex, columnaIndex) = "SEMANA DEL " & Me.fechaInicio.ToShortDateString & " AL " & Me.fechaFin.ToShortDateString
                .Range("C2:AL2").Merge()
                .Range("C2:AL2").Font.Bold = True
                .Range("C2:AL2").Font.Size = 12
                .Range("C2:AL2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify
                .Range("C2:AL2").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                'titulo 03
                Dim columnaInicio As Integer = 0
                filaIndex = filaIndex + 1

                .Cells(filaIndex, 1) = "N° Tar.".ToUpper()
                .Cells(filaIndex, 2) = "Trabajador".ToUpper()

                .Range(.Cells(filaIndex, 1), .Cells(filaIndex, 2)).Font.Bold = True
                .Range(.Cells(filaIndex, 1), .Cells(filaIndex, 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                .Range(.Cells(filaIndex, 1), .Cells(filaIndex, 2)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                For Each fila As DiaSemanal In lista(0).listaDias
                    columnaInicio = columnaIndex
                    .Cells(filaIndex, columnaIndex) = fila.fecha.ToShortDateString
                    columnaIndex = columnaIndex + (1 * 4)
                    .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaIndex - 1)).Merge()
                    .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaIndex - 1)).Font.Bold = True
                    .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaIndex - 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaIndex - 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                Next

                'TITULO 4               
                'columnas de dias, LUNES, MARTES
                filaIndex = filaIndex + 1
                columnaIndex = 3
                For Each fila As DiaSemanal In lista(0).listaDias
                    columnaInicio = columnaIndex
                    .Cells(filaIndex, columnaIndex) = fila.diaNombre.ToUpper
                    columnaIndex = columnaIndex + (1 * 4)
                    .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaIndex - 1)).Merge()
                    .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaIndex - 1)).Font.Bold = True
                    .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaIndex - 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaIndex - 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                Next

                'columnas total                                
                columnaInicio = columnaIndex
                .Cells(filaIndex, columnaIndex) = "TOTAL"
                columnaIndex = columnaIndex + (1 * 5)
                .Range(.Cells(filaIndex - 1, columnaInicio), .Cells(filaIndex, columnaIndex - 1)).Merge()
                .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaIndex - 1)).Font.Bold = True
                .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaIndex - 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                .Range(.Cells(filaIndex - 1, columnaInicio), .Cells(filaIndex, columnaIndex - 1)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                'columnas BONIFICACION                
                columnaInicio = columnaIndex
                .Cells(filaIndex, columnaIndex) = "BONIFICACIÓN"
                .Range(.Cells(filaIndex - 1, columnaInicio), .Cells(filaIndex, columnaIndex + 2)).Merge()
                .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaIndex + 2)).Font.Bold = True
                .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaIndex + 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                .Range(.Cells(filaIndex - 1, columnaInicio), .Cells(filaIndex, columnaIndex + 2)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                '/*************TITULO 05****************/
                filaIndex = filaIndex + 1
                columnaIndex = 3
                'columnas de dias
                For Each fila As DiaSemanal In lista(0).listaDias
                    columnaInicio = columnaIndex
                    .Cells(filaIndex, columnaIndex) = "T"
                    .Columns(columnaIndex).ColumnWidth = 5
                    columnaIndex = columnaIndex + 1

                    .Cells(filaIndex, columnaIndex) = "P2"
                    .Columns(columnaIndex).ColumnWidth = 5
                    columnaIndex = columnaIndex + 1

                    .Cells(filaIndex, columnaIndex) = "P3"
                    .Columns(columnaIndex).ColumnWidth = 5
                    columnaIndex = columnaIndex + 1

                    .Cells(filaIndex, columnaIndex) = "H.E"
                    .Columns(columnaIndex).ColumnWidth = 5
                    columnaIndex = columnaIndex + 1

                    .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaInicio + 4)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaInicio + 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                Next

                'columnas total  
                columnaInicio = columnaIndex
                .Cells(filaIndex, columnaIndex) = "T"
                .Columns(columnaIndex).ColumnWidth = 5

                columnaIndex = columnaIndex + 1
                .Cells(filaIndex, columnaIndex) = "ST 2"
                .Columns(columnaIndex).ColumnWidth = 5

                columnaIndex = columnaIndex + 1
                .Cells(filaIndex, columnaIndex) = "ST 3"
                .Columns(columnaIndex).ColumnWidth = 5

                columnaIndex = columnaIndex + 1
                .Cells(filaIndex, columnaIndex) = "H.E-25%"
                .Columns(columnaIndex).ColumnWidth = 7

                columnaIndex = columnaIndex + 1
                .Cells(filaIndex, columnaIndex) = "H.E-35%"
                .Columns(columnaIndex).ColumnWidth = 7

                .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaInicio + 5)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaInicio + 5)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                'columnas BONIFICACION
                columnaIndex = columnaIndex + 1
                columnaInicio = columnaIndex
                .Cells(filaIndex, columnaIndex) = "Punt."
                .Columns(columnaIndex).ColumnWidth = 5

                columnaIndex = columnaIndex + 1
                .Cells(filaIndex, columnaIndex) = "Prod."
                .Columns(columnaIndex).ColumnWidth = 5

                columnaIndex = columnaIndex + 1
                .Cells(filaIndex, columnaIndex) = "Otros."
                .Columns(columnaIndex).ColumnWidth = 5

                .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaInicio + 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaInicio + 2)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                '/*************DATOS****************/
                filaIndex = filaIndex + 1
                columnaIndex = 1

                For Each fila As SIP_Entidad.ParteAsistencia In lista

                    columnaIndex = 1
                    'codigo empleado
                    .Cells(filaIndex, columnaIndex) = fila.codigoEmpleado
                    .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    columnaIndex = columnaIndex + 1

                    'apellidos y nombres
                    .Cells(filaIndex, columnaIndex) = fila.apellidosyNombres
                    .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    columnaIndex = columnaIndex + 1

                    'horas trabajadas, horas plus y horas extras
                    For Each fila2 As DiaSemanal In fila.listaDias

                        columnaInicio = columnaIndex
                        .Cells(filaIndex, columnaIndex) = fila2.horasTrabajadas
                        If fila2.horasTrabajadas < horasDiarias Then

                            Select Case fila2.fecha.DayOfWeek
                                Case DayOfWeek.Saturday

                                    If fila2.horasTrabajadas <> horaSabado5 Then
                                        .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Interior.Color = 4210943 'pintar de color rojo
                                        .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Font.Bold = True
                                    End If

                                Case DayOfWeek.Sunday
                                    'no pintar de rojo los domingos
                                    If fila2.horasTrabajadas < 1 Then
                                        .Cells(filaIndex, columnaIndex) = "" 'borrar si es menor a cero, solo para los domingos
                                    End If

                                    'pintar los domingos si es mayor a 0 horas
                                    If fila2.horasTrabajadas > horaSabado5 Then
                                        .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Interior.Color = colorAzul 'pintar de color azul
                                        .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Font.Bold = True
                                    End If

                                Case Else
                                    .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Interior.Color = 4210943 'pintar de color rojo
                                    .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Font.Bold = True
                            End Select
                        Else
                            Select Case fila2.fecha.DayOfWeek
                                Case DayOfWeek.Sunday
                                    If fila2.horasTrabajadas > horaSabado5 Then
                                        .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Interior.Color = colorAzul 'pintar de color azul
                                        .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Font.Bold = True
                                    End If
                            End Select
                        End If

                        columnaIndex = columnaIndex + 1

                        If fila2.horasPrima2 > 0 Then
                            .Cells(filaIndex, columnaIndex) = fila2.horasPrima2
                        End If

                        columnaIndex = columnaIndex + 1

                        If fila2.horasPrima3 > 0 Then
                            .Cells(filaIndex, columnaIndex) = fila2.horasPrima3
                        End If

                        columnaIndex = columnaIndex + 1

                        If fila2.horasExtras > 0 Then
                            .Cells(filaIndex, columnaIndex) = fila2.horasExtras
                            .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Interior.Color = colorAzul 'pintar de color azul
                            .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Font.Bold = True
                        End If

                        columnaIndex = columnaIndex + 1

                        .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaInicio + 4)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    Next

                    'total horas trabajadas
                    columnaInicio = columnaIndex
                    .Cells(filaIndex, columnaIndex) = fila.totalHorasTrabajadas
                    .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Font.Bold = True

                    'pintar de color rojo, si las hora totales son menores a las horas semanales
                    If fila.totalHorasTrabajadas < horasSemanales Then
                        .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Interior.Color = 4210943 'pintar de color rojo                        
                    End If

                    If fila.totalHorasTrabajadas > horasSemanales Then
                        .Range(.Cells(filaIndex, columnaIndex), .Cells(filaIndex, columnaIndex)).Interior.Color = colorAzul 'pintar de color azul                        
                    End If

                    columnaIndex = columnaIndex + 1

                    'total horas primas 2
                    If fila.totalST2 > 0 Then
                        .Cells(filaIndex, columnaIndex) = fila.totalST2
                    End If

                    columnaIndex = columnaIndex + 1

                    If fila.totalST3 > 0 Then
                        .Cells(filaIndex, columnaIndex) = fila.totalST3
                    End If

                    columnaIndex = columnaIndex + 1

                    If fila.totalHorasExtras1 > 0 Then
                        .Cells(filaIndex, columnaIndex) = fila.totalHorasExtras1
                    End If
                    columnaIndex = columnaIndex + 1

                    If fila.totalHorasExtras2 > 0 Then
                        .Cells(filaIndex, columnaIndex) = fila.totalHorasExtras2
                    End If
                    columnaIndex = columnaIndex + 1

                    'bonificacion
                    .Cells(filaIndex, columnaIndex) = "" 'fila.BonificaionPuntualidad
                    columnaIndex = columnaIndex + 1

                    .Cells(filaIndex, columnaIndex) = "" 'fila.BonificaionProduccion
                    columnaIndex = columnaIndex + 1

                    .Cells(filaIndex, columnaIndex) = "" 'fila.BonificacionOtros
                    columnaIndex = columnaIndex + 1

                    'asignar bordes a todos los valores de totales
                    .Range(.Cells(filaIndex, columnaInicio), .Cells(filaIndex, columnaInicio + 7)).Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("C" & filaIndex & ":AL" & filaIndex).NumberFormat = "#,##0.0"

                    filaIndex = filaIndex + 1
                Next

                'CENTRAR CABECERA; NUMERO DE TARJETA Y TRABAJADOR
                .Range("A3:A5").Merge()
                .Range("A3:A5").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                .Range("B3:B5").Merge()
                .Range("B3:B5").Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                'total y bonoficacion
                .Range("AE3:AL3").Font.Bold = True

            End With

            excelApp.Visible = True
            excelApp = Nothing

        Catch ex As Exception
            Throw New Exception("Se ha producido un error en ExportToExcel: " & vbLf & ex.Message)
        End Try

    End Sub
#End Region


    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaInicio.ValueChanged

        calcularFechaFin()

    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click

        If Me.cbArea.Text = "" Then
            MessageBox.Show("Seleccione Área", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Me.fechaFinTexto = "" Then
            MessageBox.Show("Seleccione fecha inicio de la semana", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        generarParteSemanal()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub frmConsultaParteAsistencia_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        comboArea()
        Me.fechaInicio = Now.AddDays(-7).ToShortDateString '"24/08/2022" 'Now.ToShortDateString
        'Me.fechaInicio = "24/08/2022" 

    End Sub


    Private Sub btExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btExportar.Click

        If Me.cbArea.Text = "" Then
            MessageBox.Show("Seleccione Área", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Me.fechaFinTexto = "" Then
            MessageBox.Show("Seleccione fecha inicio de la semana", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim dt As DataTable
        Dim business As New SIP_Negocio.ParteAsistencia()        
        mostrarEstado("PEND")
        dt = business.listarMarcacion(Me.codigoArea, Me.fechaInicio, Me.fechaFin)

        Select Case ordenarPor
            Case 0                
                dt.DefaultView.Sort = "Apellidos_Nombres asc"
                dt = dt.DefaultView.ToTable

            Case 1                
                dt.DefaultView.Sort = "Codigo asc"
                dt = dt.DefaultView.ToTable
        End Select

        If dt.Rows.Count < 1 Then
            MessageBox.Show("No hay datos para generar la exportación", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Cursor = Cursors.Default
            mostrarEstado("")
            Exit Sub
        End If
        mostrarEstado("PROC")
        Common.Exportar.ExportExcel(dt)        
        mostrarEstado("FIN")

        Me.Cursor = Cursors.Default

    End Sub
End Class