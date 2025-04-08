
Imports Infragistics.Win.UltraWinGrid

Public Class frmListadoExportacion
#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)
#End Region
#Region "Propiedades"
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

        If Me.fechaFin < Me.fechaInicio Then
            MessageBox.Show("La fecha hasta no puede ser menor a la fecha desde.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim business As New SIP_Negocio.VentaExportacion()
        Me.ugListado.DataSource = business.listadoExportacion(fechaInicio, fechaFin)
        grillaSoloLectura()
        lblCount.Text = Me.ugListado.Rows.Count.ToString + " registros encontrados."
    End Sub
    Private Sub grillaSoloLectura()

        For Each column As UltraGridColumn In ugListado.DisplayLayout.Bands(0).Columns
            column.CellActivation = Activation.ActivateOnly
        Next
        'ugListado.DisplayLayout.Bands(0).Columns("").CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
    End Sub
#End Region

    Private Sub frmListadoExportacion_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown

        Me.dtpFechaInicio.Value = "01/01/" + DateTime.Now.Year.ToString
        Me.dtpFechaFin.Value = DateTime.Now

    End Sub

    Private Sub btnReporte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReporte.Click

        Me.Cursor = Cursors.WaitCursor
        Dim pathFile As String = My.Application.Info.DirectoryPath + "/" + Guid.NewGuid().ToString + ".xls"

        'Dim saveDialog As New SaveFileDialog
        'With saveDialog
        '    .Filter = "xls Files (*.xls*)|*.xls"
        '    If .ShowDialog() = DialogResult.OK Then
        '        pathFile = .FileName
        '    End If
        'End With

        If pathFile.Trim.Length < 1 Then
            Exit Sub
        End If

        Me.UltraGridExcelExporter1.Export(ugListado, pathFile)
        'abrir el archivo exportado
        System.Diagnostics.Process.Start(pathFile)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click

        Me.Cursor = Cursors.WaitCursor
        buscar()
        Me.Cursor = Cursors.Default

    End Sub
End Class