Imports Microsoft.Office.Interop
Imports Infragistics.Win.UltraWinGrid
Imports System.Threading
Imports System
Imports System.IO
Imports Microsoft.Office.Interop.Excel
Imports System.Linq

Public Class frmReporteCostoCargaLaboral
#Region "Propiedades"
    Public Ls_Permisos As New List(Of Integer)
    Private Property anio() As Short
        Get
            Dim value As Short = -1
            If Me.cbbAnio.SelectedIndex < 1 Then
                Return value
            Else
                Return Integer.Parse(Me.cbbAnio.Text)
            End If

        End Get
        Set(ByVal value As Short)
            Me.cbbAnio.Text = value.ToString
        End Set
    End Property
    Private Property mes() As Short
        Get
            Return Me.cbbMes.SelectedIndex
        End Get
        Set(ByVal value As Short)
            Me.cbbMes.SelectedIndex = value
        End Set
    End Property
    Private ReadOnly Property mesNombre() As String
        Get
            Return Me.cbbMes.Text
        End Get        
    End Property
#End Region
#Region "Combo"
    Private Sub comboAnio()

        With Me.cbbAnio
            .Items.Clear()
            .Items.Add("[SELECCIONE]")
            For i As Integer = Now.Year To 2020 Step -1
                .Items.Add(i)
            Next
            .SelectedIndex = 0
        End With

    End Sub
    Private Sub comboMes()

        With Me.cbbMes
            .Items.Clear()
            .Items.Add("[SELECCIONE]")
            For i As Integer = 0 To 11
                .Items.Add(Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames(i).ToUpper)
            Next
            .SelectedIndex = 0
        End With

    End Sub
#End Region
#Region "Listar"
    Private Sub buscar()

        Me.Cursor = Cursors.WaitCursor

        Dim business As New SIP_Negocio.CentroCostoCargaLaboral()
        Me.ugListado.DataSource = business.listadoCentroCostoCargaLaboral(Me.anio, Me.mes)
        grillaSoloLectura()

        lblCount.Text = Me.ugListado.Rows.Count.ToString + " registros encontrados."

        Me.Cursor = Cursors.Default

    End Sub
    Private Sub grillaSoloLectura()

        For Each column As UltraGridColumn In ugListado.DisplayLayout.Bands(0).Columns
            column.CellActivation = Activation.ActivateOnly
        Next

    End Sub

#End Region
#Region "Otros"
    Private Sub procesarAccion()

        'VALIDAR ANIO
        If anio < 1 Then
            MessageBox.Show("Seleccione Año", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'mes
        If mes < 1 Then
            MessageBox.Show("Seleccione Mes", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Me.rdbProcesar.Checked = True Then
            importarDatosExcel()
        End If

        If Me.rdbConsultar.Checked = True Then
            buscar()
        End If

    End Sub
    Private Sub importarDatosExcel()

        'validar si ya existen registros en el periodo actual
        Dim business As New SIP_Negocio.CentroCostoCargaLaboral
        If business.validarPeriodoCarga(Me.anio, Me.mes) = True Then
            Dim periodo As String = Me.anio & "-" & Me.mesNombre
            Dim mensaje As String = "El periodo " & periodo & " ya cuenta con información importada y procesada." & _
            Chr(13) & Chr(13) & "Desea eliminar toda la información del periodo " & periodo & ", para volver ha importar y procesar nuevamente?"

            If MessageBox.Show(mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                business.eliminarPeriodo(Me.anio, Me.mes, User_Sistema)
            Else
                Exit Sub
            End If
        End If

        Dim open As New OpenFileDialog
        Dim pathFile As String = ""
        open.Filter = "Libro de Excel (*.xlsx)|*.xlsx|Libro de Excel 97-2003 (*.xls)|*.xls"

        If open.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            pathFile = open.FileName.ToString
        End If

        Dim listaHojas As New Dictionary(Of String, Integer)

        If pathFile.Trim.Length < 1 Then
            Exit Sub
        Else

            Me.Cursor = Cursors.WaitCursor

            Dim objImportarExcel As New Common.ImportarExcel()
            Dim ContenidoLista As New List(Of Common.ImportarExcel.Libro)
            ContenidoLista = objImportarExcel.importarDatosCeldas(pathFile, "NOM. TRBAJADOR", 9, 5, 2)

            If objImportarExcel.resumenHojas.Count < 1 Then
                MessageBox.Show("El archivo de origen no corrresponde con el formato, vuelva ha intentarlo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Dim detalleMensaje As String = ""
            'Un Loop para recorrer el diccionario
            Dim Par As KeyValuePair(Of String, Integer)
            For Each Par In objImportarExcel.resumenHojas
                detalleMensaje = detalleMensaje & Par.Key.ToString & "==> " & Par.Value & " registros." & Chr(13)
            Next

            Dim mensaje As String = "Se ha identificado los siguientes datos del archivo importado." + Chr(13) + Chr(13) + _
            detalleMensaje + Chr(13) + "Desea continuar con el proceso?"

            If MessageBox.Show(mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then

                business = New SIP_Negocio.CentroCostoCargaLaboral

                For Each Par In objImportarExcel.resumenHojas

                    Dim idCabecera As Integer = -1
                    Dim entityCabecera As New SIP_Entidad.Cabecera
                    entityCabecera.anio = Me.anio
                    entityCabecera.mes = Me.mes
                    entityCabecera.nombreArchivo = pathFile
                    entityCabecera.nombreHoja = Par.Key.ToString
                    entityCabecera.loginUsuario = User_Sistema

                    idCabecera = business.agregarCabecera(entityCabecera)

                    For Each fila As Common.ImportarExcel.Libro In ContenidoLista

                        If fila.nombreHoja.ToUpper = Par.Key.ToString.ToUpper Then

                            Dim entityDetalle As New SIP_Entidad.Detalle
                            entityDetalle.idCabecera = idCabecera
                            entityDetalle.empleado = fila.valorCelda
                            entityDetalle.codigoEmpleado = fila.valorCelda.Substring(0, 5)
                            Dim posInicial As Integer = fila.valorCelda.IndexOf("-")
                            entityDetalle.apellidosEmpleado = fila.valorCelda.Substring(posInicial + 1, fila.valorCelda.Length - posInicial - 1)
                            entityDetalle.loginUsuario = User_Sistema

                            business.agregarDetalle(entityDetalle)
                        End If
                    Next
                Next

                Me.Cursor = Cursors.Default
                MessageBox.Show("Operación realizada satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.rdbConsultar.Checked = True
                buscar()
            End If

            Me.Cursor = Cursors.Default

        End If

    End Sub
#End Region

    Private Sub btnReporte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReporte.Click

        Dim nombreArchivo As String = "Carga_Laboral_" & Me.anio & "-" & Me.mesNombre
        Dim pathFile As String = My.Application.Info.DirectoryPath + "/" + nombreArchivo + ".xlsx"

        If pathFile.Trim.Length < 1 Then
            Exit Sub
        End If

        If Me.ugListado.Rows.Count < 1 Then
            MessageBox.Show("No existen registros para exportar. Haga clic en el botón buscar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If


        If MessageBox.Show("Desea exportar la información?", Me.Text, _
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> System.Windows.Forms.DialogResult.Yes Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim dts As New DataSet
        Dim business As New SIP_Negocio.CentroCostoCargaLaboral
        dts = business.listarDataSetCentroCostoCargaLaboral(Me.anio, Me.mes)

        Common.Exportar.ExportDatasetToExcelMultipleHojas(dts, pathFile, "A1:I1")
        'abrir el archivo exportado
        'Dim proceso As New Process()
        'proceso.StartInfo.FileName = pathFile
        'proceso.Start()
        ''proceso.WaitForExit(1000 * 60 * 5) '5 minutos, como maximo

        System.Diagnostics.Process.Start(pathFile)
        Me.Cursor = Cursors.Default
        MessageBox.Show("Operación realizada satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click

        procesarAccion()

    End Sub

    Private Sub frmReporteCostoCargaLaboral_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        comboAnio()
        comboMes()

    End Sub

    Private Sub rdbProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbProcesar.Click, _
        rdbConsultar.Click

        Dim nombreBoton As String = ""
        If Me.rdbProcesar.Checked = True Then
            nombreBoton = "Importar y Procesar"
        End If

        If Me.rdbConsultar.Checked = True Then
            nombreBoton = "Buscar"
        End If

        btnBuscar.Text = nombreBoton

    End Sub

End Class
