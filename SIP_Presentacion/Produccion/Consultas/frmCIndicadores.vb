Imports Infragistics.Win.UltraWinGrid
Public Class frmCIndicadores
    Private data As DataTable = Nothing
    Private data2 As DataTable = Nothing
    Private listaDataTable As List(Of DataTable)
#Region "Propiedades"
    Public Ls_Permisos As New List(Of Integer)
    Private Property fechaInicio() As Date
        Get
            Return Me.dtpFechaInicio.Value

        End Get
        Set(ByVal value As Date)
            Me.dtpFechaInicio.Value = value
        End Set
    End Property
    Private Property fechaFin() As Date
        Get
            Return Me.dtpFechaFin.Value

        End Get
        Set(ByVal value As Date)
            Me.dtpFechaFin.Value = value
        End Set
    End Property
#End Region
#Region "Listar"
    Private Sub buscar()

        'VALIDAR ANIO
        If fechaFin < fechaInicio Then
            MessageBox.Show("La fecha fin no puede ser menor a la fecha de inicio", _
                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim business As New SIP_Negocio.DatosIndicadores
        listaDataTable = New List(Of DataTable)

        listaDataTable = business.listadoDataIndicador(Me.fechaInicio, fechaFin)

        Me.ugListado.DataSource = listaDataTable(0)
        Me.ugListado2.DataSource = listaDataTable(1)

        grillaSoloLectura()

        'contador de registros
        Dim cantidadReg As Integer = 0
        Select Case Me.TabControl1.SelectedIndex
            Case 0
                cantidadReg = Me.ugListado.Rows.Count
            Case 1
                cantidadReg = Me.ugListado.Rows.Count
        End Select

        lblCount.Text = cantidadReg.ToString + " registros encontrados."

    End Sub
    Private Sub grillaSoloLectura()

        For Each column As UltraGridColumn In ugListado.DisplayLayout.Bands(0).Columns
            column.CellActivation = Activation.ActivateOnly
        Next

        For Each column As UltraGridColumn In ugListado2.DisplayLayout.Bands(0).Columns
            column.CellActivation = Activation.ActivateOnly
        Next

    End Sub
#End Region
#Region "Otros"
    Private Sub exportarDatos()

        Dim nombreArchivo As String = "Consulta de datos de indicadores "
        Dim pathFile As String = My.Application.Info.DirectoryPath + "\" + nombreArchivo + ".xlsx"

        If Me.ugListado.Rows.Count < 1 Then
            MessageBox.Show("No existen registros para exportar. Haga clic en el botón buscar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        'Me.UltraGridExcelExporter1.Export(ugListado, pathFile)
        Common.Exportar.ExportToExcelMultipleHojas(listaDataTable, pathFile)
        'abrir el archivo exportado
        Dim proceso As New Process()
        proceso.StartInfo.FileName = pathFile
        proceso.Start()
        proceso.WaitForExit(1000 * 60 * 5) '5 minutos, como maximo

        Me.Cursor = Cursors.Default
        MessageBox.Show("Operación realizada satisfactoriamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
#End Region
    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click

        exportarDatos()

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        Me.Cursor = Cursors.WaitCursor
        buscar()
        exportarDatos()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub frmCIndicadores_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Dim fechaHoy As Date = Now

        Me.fechaInicio = "01/" & fechaHoy.Month.ToString("00") & "/" & fechaHoy.Year.ToString
        Me.fechaFin = fechaInicio.AddMonths(+1).AddDays(-1)

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        'contador de registros
        Dim cantidadReg As Integer = 0
        Select Case Me.TabControl1.SelectedIndex
            Case 0
                cantidadReg = Me.ugListado.Rows.Count
            Case 1
                cantidadReg = Me.ugListado.Rows.Count
        End Select

        lblCount.Text = cantidadReg.ToString + " registros encontrados."
    End Sub
End Class