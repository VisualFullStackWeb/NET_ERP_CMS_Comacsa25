Imports Infragistics.Win.UltraWinGrid.UltraGridAction
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLOrdenProduccion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand7 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Ruma", -1)
        Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Band 1")
        Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodRuma", 0)
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesRuma", 1)
        Dim Appearance176 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad", 2)
        Dim Appearance186 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Porcentaje", 3)
        Dim Appearance187 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Humedad", 4)
        Dim Appearance243 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Merma", 5)
        Dim Appearance244 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockRecurso", 6)
        Dim Appearance245 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn109 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxFraccionada", 7)
        Dim Appearance246 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn110 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxNecesaria", 8)
        Dim Appearance249 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxTON", 9)
        Dim Appearance250 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal", 10)
        Dim Appearance251 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings21 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CantidadxFraccionada", 7, False, "Ruma", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CantidadxFraccionada", 7, False)
        Dim Appearance472 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance252 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings22 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Porcentaje", 3, False, "Ruma", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Porcentaje", 3, False)
        Dim Appearance473 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance253 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings23 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "StockRecurso", 6, False, "Ruma", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "StockRecurso", 6, False)
        Dim Appearance474 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance254 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings24 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CantidadxNecesaria", 8, False, "Ruma", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CantidadxNecesaria", 8, False)
        Dim Appearance475 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance347 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings25 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SubTotal", 10, False, "Ruma", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SubTotal", 10, False)
        Dim Appearance476 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance348 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand8 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 1", 0)
        Dim UltraGridColumn113 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodRuma", 0)
        Dim Appearance349 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn114 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo", 1)
        Dim Appearance350 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn115 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 2)
        Dim Appearance351 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn116 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad", 3)
        Dim Appearance352 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance353 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn117 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxNecesaria", 4)
        Dim Appearance354 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance355 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn118 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxExtraccion", 5)
        Dim Appearance356 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance357 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn119 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxCompra", 6)
        Dim Appearance358 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance359 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn120 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxRegalias", 7)
        Dim Appearance448 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance449 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn121 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxFlete", 8)
        Dim Appearance450 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance451 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn122 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxOtros", 9)
        Dim Appearance452 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance453 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn123 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxTON", 10)
        Dim Appearance454 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance455 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn124 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal", 11)
        Dim Appearance456 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance457 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn125 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockSubRecurso", 12)
        Dim Appearance458 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance459 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance460 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance461 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance462 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance463 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance464 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance465 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance466 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance467 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance468 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance469 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance470 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance471 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance327 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance265 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance264 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance177 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance302 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Porcentaje")
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Humedad")
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Merma")
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockRecurso")
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxTON")
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nuevo")
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxFraccionada", 0)
        Dim Appearance103 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance104 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxNecesaria", 1)
        Dim Appearance123 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance163 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal", 2)
        Dim Appearance170 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance171 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad", 3)
        Dim Appearance172 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings6 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CantidadxFraccionada", 0, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CantidadxFraccionada", 0, False)
        Dim Appearance173 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance174 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings7 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CantidadxNecesaria", 1, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CantidadxNecesaria", 1, False)
        Dim Appearance255 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance256 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings8 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SubTotal", 2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SubTotal", 2, False)
        Dim Appearance257 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance258 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings9 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Porcentaje", 2, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Porcentaje", 2, True)
        Dim Appearance259 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance260 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings10 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "StockRecurso", 5, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "StockRecurso", 5, True)
        Dim Appearance261 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance262 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance531 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance532 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance533 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance534 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance535 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance536 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance537 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance538 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance539 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance540 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Descripcion")
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Porcentaje")
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Humedad")
        Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Merma")
        Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("StockRecurso")
        Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CostoxTON")
        Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ID")
        Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Nuevo")
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance263 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim Appearance267 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Porcentaje")
        Dim Appearance268 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Humedad")
        Dim Appearance269 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance270 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Merma")
        Dim Appearance271 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance274 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockRecurso")
        Dim Appearance275 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance276 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxTON")
        Dim Appearance277 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance278 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nuevo")
        Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxFraccionada", 0)
        Dim Appearance289 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance290 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn84 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxNecesaria", 1)
        Dim Appearance291 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance292 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn85 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal", 2)
        Dim Appearance293 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance294 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn86 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad", 3)
        Dim Appearance295 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings11 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CantidadxFraccionada", 0, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CantidadxFraccionada", 0, False)
        Dim Appearance296 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance297 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings12 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CantidadxNecesaria", 1, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CantidadxNecesaria", 1, False)
        Dim Appearance298 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance299 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings13 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SubTotal", 2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SubTotal", 2, False)
        Dim Appearance300 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance301 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings14 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Porcentaje", 2, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Porcentaje", 2, True)
        Dim Appearance303 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance304 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings15 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "StockRecurso", 5, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "StockRecurso", 5, True)
        Dim Appearance305 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance306 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance279 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance280 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance281 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance282 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance283 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance284 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance285 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance286 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance287 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance288 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance904 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand6 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn87 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance307 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim Appearance308 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Porcentaje")
        Dim Appearance309 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Humedad")
        Dim Appearance310 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance311 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Merma")
        Dim Appearance312 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance313 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockRecurso")
        Dim Appearance314 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance315 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxTON")
        Dim Appearance549 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance550 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nuevo")
        Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxFraccionada", 0)
        Dim Appearance551 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance552 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxNecesaria", 1)
        Dim Appearance553 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance554 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal", 2)
        Dim Appearance555 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance556 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad", 3)
        Dim Appearance557 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings16 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CantidadxFraccionada", 0, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CantidadxFraccionada", 0, False)
        Dim Appearance558 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance559 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings17 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CantidadxNecesaria", 1, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CantidadxNecesaria", 1, False)
        Dim Appearance560 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance561 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings18 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SubTotal", 2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SubTotal", 2, False)
        Dim Appearance562 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance563 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings19 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Porcentaje", 2, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Porcentaje", 2, True)
        Dim Appearance564 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance565 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings20 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "StockRecurso", 5, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "StockRecurso", 5, True)
        Dim Appearance566 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance567 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance933 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance934 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance935 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance936 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance937 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance938 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance939 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance940 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance941 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance942 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Descripcion")
        Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Porcentaje")
        Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Humedad")
        Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Merma")
        Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("StockRecurso")
        Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CostoxTON")
        Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ID")
        Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Nuevo")
        Dim Appearance188 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance189 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance190 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 0)
        Dim Appearance191 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance192 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodLote", 1)
        Dim Appearance193 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance194 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodClase", 2)
        Dim Appearance195 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance196 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodTipo", 3)
        Dim Appearance197 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance198 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha", 4)
        Dim Appearance199 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance200 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Turno", 5)
        Dim Appearance201 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance202 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Placa", 6)
        Dim Appearance203 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance204 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad", 7)
        Dim Appearance205 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance206 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Rendimiento", 9)
        Dim Appearance207 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance208 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Energia", 10)
        Dim Appearance209 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance210 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperarios", 11)
        Dim Appearance211 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance212 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoPromxHora", 12)
        Dim Appearance213 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance214 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoKwxHora", 13)
        Dim Appearance215 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance216 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MODhhxtn", 14)
        Dim Appearance217 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance218 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MODSolxtn", 15)
        Dim Appearance219 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance220 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EnergiaSolxtn", 16)
        Dim Appearance221 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance222 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxTon", 17)
        Dim Appearance223 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance224 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal", 18)
        Dim Appearance225 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance226 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TonMaximo", 19)
        Dim Appearance227 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance228 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TonUtilizado", 20)
        Dim Appearance229 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance230 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Uso", 21)
        Dim Appearance231 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance232 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesTurno", 22)
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Horas", 23)
        Dim Appearance175 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(674)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(-7)
        Dim Appearance233 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance234 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance235 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance236 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance237 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance238 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance239 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance240 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance241 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance242 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance142 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 0)
        Dim Appearance508 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance509 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodLote", 1)
        Dim Appearance143 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodClase", 2)
        Dim Appearance144 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance108 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodTipo", 3)
        Dim Appearance145 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance109 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha", 4)
        Dim Appearance146 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance110 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Turno", 5)
        Dim Appearance148 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance111 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Placa", 6)
        Dim Appearance149 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance112 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad", 7)
        Dim Appearance150 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance113 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 8)
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Rendimiento", 9)
        Dim Appearance152 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance115 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Energia", 10)
        Dim Appearance153 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance116 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperarios", 11)
        Dim Appearance154 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance117 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoPromxHora", 12)
        Dim Appearance155 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance118 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoKwxHora", 13)
        Dim Appearance158 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MODhhxtn", 14)
        Dim Appearance160 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance120 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MODSolxtn", 15)
        Dim Appearance178 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance121 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EnergiaSolxtn", 16)
        Dim Appearance179 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance122 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxTon", 17)
        Dim Appearance180 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance126 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal", 18)
        Dim Appearance181 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TonMaximo", 19)
        Dim Appearance182 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance128 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TonUtilizado", 20)
        Dim Appearance183 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance132 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Uso", 21)
        Dim Appearance184 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance133 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesTurno", 22)
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Horas", 23)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(674)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(621)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(-7)
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance156 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance162 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance503 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance266 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance185 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance507 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance326 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance500 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance114 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance501 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance159 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance502 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLOrdenProduccion))
        Dim Appearance102 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance273 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance157 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance272 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance504 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance505 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance506 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance141 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance161 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab7 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab9 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance107 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance165 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance166 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance168 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance167 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance169 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance511 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance510 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodSuministro")
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Unidad")
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UndDesp")
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Peso")
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoUnitario")
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadUnitaria")
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal", 0, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadMaxima", 1)
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Nothing, "CantidadUnitaria", 7, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CostoUnitario", 5, True)
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Nothing, Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CostoUnitario", 5, True)
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings3 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("SumCantidadUnitaria", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CantidadUnitaria", 7, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CantidadUnitaria", 7, True)
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings4 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("SumCantidadMaxima", Infragistics.Win.UltraWinGrid.SummaryType.Maximum, Nothing, "CantidadMaxima", 1, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CantidadUnitaria", 7, True)
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings5 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SubTotal", 0, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SubTotal", 0, False)
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance129 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance130 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance131 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance134 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance135 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance136 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance137 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance138 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance139 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance147 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodSuministro")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Descripcion")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Unidad")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UndDesp")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Peso")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CostoUnitario")
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CantidadUnitaria")
        Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodRuma")
        Dim UltraDataColumn28 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Descripcion")
        Dim UltraDataColumn29 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim UltraDataColumn30 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Humedad")
        Dim UltraDataColumn31 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Merma")
        Dim UltraDataColumn32 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Porcentaje")
        Dim UltraDataColumn33 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ID")
        Dim UltraDataColumn34 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CostoxRuma")
        Dim UltraDataColumn35 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CostoxFlete")
        Dim Appearance247 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance248 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance164 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance140 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab8 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance151 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn36 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn37 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Descripcion")
        Dim UltraDataColumn38 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Porcentaje")
        Dim UltraDataColumn39 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Humedad")
        Dim UltraDataColumn40 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Merma")
        Dim UltraDataColumn41 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("StockRecurso")
        Dim UltraDataColumn42 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CostoxTON")
        Dim UltraDataColumn43 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ID")
        Dim UltraDataColumn44 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Nuevo")
        Dim Appearance360 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand9 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Ruma", -1)
        Dim UltraGridColumn126 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance361 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn127 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Band 1")
        Dim UltraGridColumn128 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodRuma", 0)
        Dim Appearance362 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance363 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn129 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DesRuma", 1)
        Dim Appearance364 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn130 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad", 2)
        Dim Appearance365 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn131 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Porcentaje", 3)
        Dim Appearance366 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn132 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Humedad", 4)
        Dim Appearance367 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn133 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Merma", 5)
        Dim Appearance368 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn134 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockRecurso", 6)
        Dim Appearance369 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn135 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxFraccionada", 7)
        Dim Appearance370 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn136 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxNecesaria", 8)
        Dim Appearance371 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn137 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxTON", 9)
        Dim Appearance372 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn138 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal", 10)
        Dim Appearance373 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand10 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 1", -1)
        Dim UltraGridColumn139 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodRuma", 0)
        Dim Appearance374 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn140 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo", 1)
        Dim Appearance375 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn141 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion", 2)
        Dim Appearance376 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn142 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad", 3)
        Dim Appearance377 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance378 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn143 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxNecesaria", 4)
        Dim Appearance379 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance380 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn144 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxExtraccion", 5)
        Dim Appearance381 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance382 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn145 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxCompra", 6)
        Dim Appearance383 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance384 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn146 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxRegalias", 7)
        Dim Appearance385 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance386 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn147 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxFlete", 8)
        Dim Appearance387 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance388 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn148 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxOtros", 9)
        Dim Appearance389 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance390 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn149 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxTON", 10)
        Dim Appearance391 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance392 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn150 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal", 11)
        Dim Appearance393 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance394 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn151 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockSubRecurso", 12)
        Dim Appearance395 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance396 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance397 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance398 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance399 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance400 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance401 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance402 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance403 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance404 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance405 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance406 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance407 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance408 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance409 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand11 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn152 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance410 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn153 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim Appearance411 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn154 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Porcentaje")
        Dim Appearance412 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn155 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Humedad")
        Dim Appearance413 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance414 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn156 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Merma")
        Dim Appearance415 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance416 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn157 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("StockRecurso")
        Dim Appearance417 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance418 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn158 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoxTON")
        Dim Appearance419 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance420 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn159 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn160 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxFraccionada", 0)
        Dim Appearance421 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance422 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn161 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadxNecesaria", 1)
        Dim Appearance423 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance424 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn162 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal", 2)
        Dim Appearance425 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance426 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn163 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad", 3)
        Dim Appearance427 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings26 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CantidadxFraccionada", 0, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CantidadxFraccionada", 0, False)
        Dim Appearance428 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance429 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings27 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CantidadxNecesaria", 1, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CantidadxNecesaria", 1, False)
        Dim Appearance430 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance431 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings28 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SubTotal", 2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SubTotal", 2, False)
        Dim Appearance432 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance433 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings29 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Porcentaje", 2, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "Porcentaje", 2, True)
        Dim Appearance434 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance435 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings30 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "StockRecurso", 5, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "StockRecurso", 5, True)
        Dim Appearance436 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance437 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance438 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance439 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance440 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance441 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance442 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance443 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance444 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance445 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance446 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance447 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl7 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid7 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Clm1 = New Infragistics.Win.UltraWinCalcManager.UltraCalcManager(Me.components)
        Me.Num1 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Num2 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Num4 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Num3 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Num5 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Num6 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Num7 = New Infragistics.Win.UltraWinEditors.UltraNumericEditor
        Me.Navigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.Source2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn8 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn9 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl9 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid8 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UdsProducto = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.BindingNavigator2 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn10 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn11 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl10 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid6 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.BindingNavigator3 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripSeparator34 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator38 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn12 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator39 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn13 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator40 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl11 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid9 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UdsProdRecirculado = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.BindingNavigator4 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn14 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn15 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid3 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Tool1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid4 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Tool2 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.Btn7 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel
        Me.Cbo2 = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.Chk1 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.Lbl1 = New Infragistics.Win.Misc.UltraLabel
        Me.Cbo1 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.Btn1 = New Infragistics.Win.Misc.UltraButton
        Me.Iml1 = New System.Windows.Forms.ImageList(Me.components)
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt4 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Dt3 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Dt2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.Dt1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.Txt3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Txt1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl8 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Tab3 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage4 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Tab2 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox
        Me.Grid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Uds2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.Uds1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.Ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.Bgw1 = New System.ComponentModel.BackgroundWorker
        Me.UdsSuministro = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraTabSharedControlsPage3 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Navigator2 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.StripLbl1 = New System.Windows.Forms.ToolStripLabel
        Me.Separator7 = New System.Windows.Forms.ToolStripSeparator
        Me.StripBtn4 = New System.Windows.Forms.ToolStripButton
        Me.StripBtn3 = New System.Windows.Forms.ToolStripButton
        Me.Separator6 = New System.Windows.Forms.ToolStripSeparator
        Me.StripTxt1 = New System.Windows.Forms.ToolStripTextBox
        Me.Separator5 = New System.Windows.Forms.ToolStripSeparator
        Me.StripBtn2 = New System.Windows.Forms.ToolStripButton
        Me.StripBtn1 = New System.Windows.Forms.ToolStripButton
        Me.Separator4 = New System.Windows.Forms.ToolStripSeparator
        Me.StripLbl5 = New System.Windows.Forms.ToolStripLabel
        Me.Separator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.Separator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.Separator3 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Grid5 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator27 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton18 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton19 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripTextBox3 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator29 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton20 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton21 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator30 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator31 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton22 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator32 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton23 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator33 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl7.SuspendLayout()
        CType(Me.Grid7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Clm1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Navigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Navigator1.SuspendLayout()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl9.SuspendLayout()
        CType(Me.Grid8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UdsProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator2.SuspendLayout()
        Me.UltraTabPageControl10.SuspendLayout()
        CType(Me.Grid6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator3.SuspendLayout()
        Me.UltraTabPageControl11.SuspendLayout()
        CType(Me.Grid9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UdsProdRecirculado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator4.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.Grid3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool1.SuspendLayout()
        Me.UltraTabPageControl4.SuspendLayout()
        CType(Me.Grid4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tool2.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.Cbo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cbo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl8.SuspendLayout()
        CType(Me.Tab3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab3.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.Tab2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab2.SuspendLayout()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Uds2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Uds1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.Ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UdsSuministro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl5.SuspendLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Navigator2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Navigator2.SuspendLayout()
        Me.UltraTabPageControl6.SuspendLayout()
        CType(Me.Grid5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl7
        '
        Me.UltraTabPageControl7.Controls.Add(Me.Grid7)
        Me.UltraTabPageControl7.Controls.Add(Me.Navigator1)
        Me.UltraTabPageControl7.Location = New System.Drawing.Point(2, 31)
        Me.UltraTabPageControl7.Name = "UltraTabPageControl7"
        Me.UltraTabPageControl7.Size = New System.Drawing.Size(705, 461)
        '
        'Grid7
        '
        Me.Grid7.CalcManager = Me.Clm1
        Appearance84.BackColor = System.Drawing.SystemColors.Window
        Appearance84.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid7.DisplayLayout.Appearance = Appearance84
        Me.Grid7.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn100.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn100.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn100.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance85.Image = CType(resources.GetObject("Appearance85.Image"), Object)
        Appearance85.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance85.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn100.Header.Appearance = Appearance85
        UltraGridColumn100.Header.Caption = ""
        UltraGridColumn100.Header.VisiblePosition = 0
        UltraGridColumn100.Hidden = True
        UltraGridColumn100.MaxWidth = 25
        UltraGridColumn100.MinWidth = 20
        UltraGridColumn100.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn100.Width = 20
        UltraGridColumn101.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn101.Header.VisiblePosition = 12
        UltraGridColumn102.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn102.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance86.TextHAlignAsString = "Center"
        UltraGridColumn102.CellAppearance = Appearance86
        UltraGridColumn102.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance87.TextHAlignAsString = "Center"
        UltraGridColumn102.Header.Appearance = Appearance87
        UltraGridColumn102.Header.Caption = "Código"
        UltraGridColumn102.Header.VisiblePosition = 1
        UltraGridColumn102.MinWidth = 80
        UltraGridColumn102.Width = 80
        UltraGridColumn103.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance176.TextHAlignAsString = "Center"
        UltraGridColumn103.Header.Appearance = Appearance176
        UltraGridColumn103.Header.Caption = "Ruma"
        UltraGridColumn103.Header.VisiblePosition = 2
        UltraGridColumn103.MinWidth = 150
        UltraGridColumn103.Width = 150
        UltraGridColumn104.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn104.DataType = GetType(Decimal)
        UltraGridColumn104.Format = "n4"
        UltraGridColumn104.Formula = "if ( isnumber( [//CalsCantidad] ), [//CalsCantidad] ,0)"
        Appearance186.TextHAlignAsString = "Center"
        UltraGridColumn104.Header.Appearance = Appearance186
        UltraGridColumn104.Header.VisiblePosition = 3
        UltraGridColumn104.Hidden = True
        UltraGridColumn104.MinWidth = 80
        UltraGridColumn104.Width = 80
        UltraGridColumn105.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn105.DataType = GetType(Decimal)
        UltraGridColumn105.Format = "n2"
        Appearance187.TextHAlignAsString = "Center"
        UltraGridColumn105.Header.Appearance = Appearance187
        UltraGridColumn105.Header.Caption = "Pje (%)"
        UltraGridColumn105.Header.VisiblePosition = 5
        UltraGridColumn105.MinWidth = 60
        UltraGridColumn105.Width = 60
        UltraGridColumn106.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn106.DataType = GetType(Decimal)
        UltraGridColumn106.Format = "n2"
        Appearance243.TextHAlignAsString = "Center"
        UltraGridColumn106.Header.Appearance = Appearance243
        UltraGridColumn106.Header.VisiblePosition = 6
        UltraGridColumn106.MinWidth = 60
        UltraGridColumn106.Width = 60
        UltraGridColumn107.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn107.DataType = GetType(Decimal)
        UltraGridColumn107.Format = "n2"
        Appearance244.TextHAlignAsString = "Center"
        UltraGridColumn107.Header.Appearance = Appearance244
        UltraGridColumn107.Header.VisiblePosition = 7
        UltraGridColumn107.MinWidth = 60
        UltraGridColumn107.Width = 60
        UltraGridColumn108.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn108.DataType = GetType(Decimal)
        UltraGridColumn108.Format = "n3"
        Appearance245.TextHAlignAsString = "Center"
        UltraGridColumn108.Header.Appearance = Appearance245
        UltraGridColumn108.Header.Caption = "Stock"
        UltraGridColumn108.Header.VisiblePosition = 8
        UltraGridColumn108.MinWidth = 80
        UltraGridColumn108.Width = 80
        UltraGridColumn109.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn109.DataType = GetType(Decimal)
        UltraGridColumn109.Format = "n3"
        UltraGridColumn109.Formula = "[Cantidad] * [Porcentaje] *0.01"
        Appearance246.TextHAlignAsString = "Center"
        UltraGridColumn109.Header.Appearance = Appearance246
        UltraGridColumn109.Header.Caption = "Cant. Ton"
        UltraGridColumn109.Header.VisiblePosition = 4
        UltraGridColumn109.MaskInput = "{double:10.3}"
        UltraGridColumn109.MinWidth = 80
        UltraGridColumn109.Width = 80
        UltraGridColumn110.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn110.DataType = GetType(Decimal)
        UltraGridColumn110.Format = "n3"
        UltraGridColumn110.Formula = "(100+ [Humedad] + [Merma] )*0.01* [CantidadFraccionada]"
        Appearance249.TextHAlignAsString = "Center"
        UltraGridColumn110.Header.Appearance = Appearance249
        UltraGridColumn110.Header.Caption = "Cant. Req"
        UltraGridColumn110.Header.VisiblePosition = 9
        UltraGridColumn110.MaskInput = "{double:10.3}"
        UltraGridColumn110.MinWidth = 80
        UltraGridColumn110.Width = 80
        UltraGridColumn111.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn111.DataType = GetType(Decimal)
        UltraGridColumn111.Format = "n4"
        UltraGridColumn111.Formula = "if (sum( [../band 1/cantidadxnecesaria] )=0,0,sum( [../band 1/subtotal] )/sum( [." & _
            "./band 1/cantidadxnecesaria] ))"
        Appearance250.TextHAlignAsString = "Center"
        UltraGridColumn111.Header.Appearance = Appearance250
        UltraGridColumn111.Header.VisiblePosition = 10
        UltraGridColumn111.MinWidth = 80
        UltraGridColumn111.Width = 80
        UltraGridColumn112.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn112.DataType = GetType(Decimal)
        UltraGridColumn112.Format = "n4"
        UltraGridColumn112.Formula = "SUM( [../band 1/subtotal] )"
        Appearance251.TextHAlignAsString = "Center"
        UltraGridColumn112.Header.Appearance = Appearance251
        UltraGridColumn112.Header.VisiblePosition = 11
        UltraGridColumn112.MinWidth = 80
        UltraGridColumn112.Width = 80
        UltraGridBand7.Columns.AddRange(New Object() {UltraGridColumn100, UltraGridColumn101, UltraGridColumn102, UltraGridColumn103, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106, UltraGridColumn107, UltraGridColumn108, UltraGridColumn109, UltraGridColumn110, UltraGridColumn111, UltraGridColumn112})
        Appearance472.BackColor = System.Drawing.SystemColors.Info
        Appearance472.FontData.BoldAsString = "True"
        Appearance472.ForeColor = System.Drawing.Color.Red
        Appearance472.TextHAlignAsString = "Right"
        SummarySettings21.Appearance = Appearance472
        SummarySettings21.DisplayFormat = "{0:N3}"
        SummarySettings21.GroupBySummaryValueAppearance = Appearance252
        Appearance473.BackColor = System.Drawing.SystemColors.Info
        Appearance473.FontData.BoldAsString = "True"
        Appearance473.ForeColor = System.Drawing.Color.Red
        Appearance473.TextHAlignAsString = "Right"
        SummarySettings22.Appearance = Appearance473
        SummarySettings22.DisplayFormat = "{0:N2}"
        SummarySettings22.GroupBySummaryValueAppearance = Appearance253
        Appearance474.BackColor = System.Drawing.SystemColors.Info
        Appearance474.FontData.BoldAsString = "True"
        Appearance474.ForeColor = System.Drawing.Color.Red
        Appearance474.TextHAlignAsString = "Right"
        SummarySettings23.Appearance = Appearance474
        SummarySettings23.DisplayFormat = "{0:N3}"
        SummarySettings23.GroupBySummaryValueAppearance = Appearance254
        Appearance475.BackColor = System.Drawing.SystemColors.Info
        Appearance475.FontData.BoldAsString = "True"
        Appearance475.ForeColor = System.Drawing.Color.Red
        Appearance475.TextHAlignAsString = "Right"
        SummarySettings24.Appearance = Appearance475
        SummarySettings24.DisplayFormat = "{0:N3}"
        SummarySettings24.GroupBySummaryValueAppearance = Appearance347
        Appearance476.BackColor = System.Drawing.SystemColors.Info
        Appearance476.FontData.BoldAsString = "True"
        Appearance476.ForeColor = System.Drawing.Color.Red
        Appearance476.TextHAlignAsString = "Right"
        SummarySettings25.Appearance = Appearance476
        SummarySettings25.DisplayFormat = "{0:N4}"
        SummarySettings25.GroupBySummaryValueAppearance = Appearance348
        UltraGridBand7.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings21, SummarySettings22, SummarySettings23, SummarySettings24, SummarySettings25})
        UltraGridBand7.SummaryFooterCaption = ""
        UltraGridColumn113.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance349.TextHAlignAsString = "Center"
        UltraGridColumn113.Header.Appearance = Appearance349
        UltraGridColumn113.Header.VisiblePosition = 0
        UltraGridColumn113.Hidden = True
        UltraGridColumn113.Width = 85
        UltraGridColumn114.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance350.TextHAlignAsString = "Center"
        UltraGridColumn114.Header.Appearance = Appearance350
        UltraGridColumn114.Header.Caption = "Código"
        UltraGridColumn114.Header.VisiblePosition = 1
        UltraGridColumn114.MinWidth = 80
        UltraGridColumn114.Width = 80
        UltraGridColumn115.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance351.TextHAlignAsString = "Center"
        UltraGridColumn115.Header.Appearance = Appearance351
        UltraGridColumn115.Header.Caption = "Mineral"
        UltraGridColumn115.Header.VisiblePosition = 2
        UltraGridColumn115.MinWidth = 150
        UltraGridColumn115.Width = 150
        UltraGridColumn116.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance352.TextHAlignAsString = "Right"
        UltraGridColumn116.CellAppearance = Appearance352
        UltraGridColumn116.DataType = GetType(Decimal)
        UltraGridColumn116.Format = "n3"
        UltraGridColumn116.Formula = "if( [../../stockrecurso] =0,0, [../../cantidadfraccionada] * (  [StockSubRecurso]" & _
            " /[../../stockrecurso] ))"
        Appearance353.TextHAlignAsString = "Center"
        UltraGridColumn116.Header.Appearance = Appearance353
        UltraGridColumn116.Header.Caption = "Cant. Ton"
        UltraGridColumn116.Header.VisiblePosition = 4
        UltraGridColumn116.MaskInput = ""
        UltraGridColumn116.MinWidth = 80
        UltraGridColumn116.Width = 80
        UltraGridColumn117.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance354.TextHAlignAsString = "Right"
        UltraGridColumn117.CellAppearance = Appearance354
        UltraGridColumn117.DataType = GetType(Decimal)
        UltraGridColumn117.Format = "n3"
        UltraGridColumn117.Formula = "if ( [../../stockrecurso] =0,0, [../../cantidadncesaria] *( [StockSubRecurso] / [" & _
            "../../stockrecurso] ))"
        Appearance355.TextHAlignAsString = "Center"
        UltraGridColumn117.Header.Appearance = Appearance355
        UltraGridColumn117.Header.Caption = "Cant. Req. "
        UltraGridColumn117.Header.VisiblePosition = 5
        UltraGridColumn117.MaskInput = "{double:10.3}"
        UltraGridColumn117.MinWidth = 80
        UltraGridColumn117.Width = 80
        UltraGridColumn118.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance356.TextHAlignAsString = "Right"
        UltraGridColumn118.CellAppearance = Appearance356
        UltraGridColumn118.DataType = GetType(Decimal)
        UltraGridColumn118.Format = "n4"
        Appearance357.TextHAlignAsString = "Center"
        UltraGridColumn118.Header.Appearance = Appearance357
        UltraGridColumn118.Header.Caption = "C. Extracción"
        UltraGridColumn118.Header.VisiblePosition = 6
        UltraGridColumn118.MinWidth = 90
        UltraGridColumn118.Width = 90
        UltraGridColumn119.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance358.TextHAlignAsString = "Right"
        UltraGridColumn119.CellAppearance = Appearance358
        UltraGridColumn119.DataType = GetType(Decimal)
        UltraGridColumn119.Format = "n4"
        Appearance359.TextHAlignAsString = "Center"
        UltraGridColumn119.Header.Appearance = Appearance359
        UltraGridColumn119.Header.Caption = "C. Compra"
        UltraGridColumn119.Header.VisiblePosition = 7
        UltraGridColumn119.MinWidth = 90
        UltraGridColumn119.Width = 90
        UltraGridColumn120.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance448.TextHAlignAsString = "Right"
        UltraGridColumn120.CellAppearance = Appearance448
        UltraGridColumn120.DataType = GetType(Decimal)
        UltraGridColumn120.Format = "n4"
        Appearance449.TextHAlignAsString = "Center"
        UltraGridColumn120.Header.Appearance = Appearance449
        UltraGridColumn120.Header.Caption = "C. Regalías"
        UltraGridColumn120.Header.VisiblePosition = 8
        UltraGridColumn120.MinWidth = 90
        UltraGridColumn120.Width = 90
        UltraGridColumn121.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance450.TextHAlignAsString = "Right"
        UltraGridColumn121.CellAppearance = Appearance450
        UltraGridColumn121.DataType = GetType(Decimal)
        UltraGridColumn121.Format = "n4"
        Appearance451.TextHAlignAsString = "Center"
        UltraGridColumn121.Header.Appearance = Appearance451
        UltraGridColumn121.Header.Caption = "C. Flete"
        UltraGridColumn121.Header.VisiblePosition = 9
        UltraGridColumn121.MinWidth = 90
        UltraGridColumn121.Width = 90
        UltraGridColumn122.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance452.TextHAlignAsString = "Right"
        UltraGridColumn122.CellAppearance = Appearance452
        UltraGridColumn122.DataType = GetType(Decimal)
        UltraGridColumn122.Format = "n4"
        Appearance453.TextHAlignAsString = "Center"
        UltraGridColumn122.Header.Appearance = Appearance453
        UltraGridColumn122.Header.Caption = "C. Otros"
        UltraGridColumn122.Header.VisiblePosition = 10
        UltraGridColumn122.MinWidth = 90
        UltraGridColumn122.Width = 90
        UltraGridColumn123.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance454.TextHAlignAsString = "Right"
        UltraGridColumn123.CellAppearance = Appearance454
        UltraGridColumn123.DataType = GetType(Decimal)
        UltraGridColumn123.Format = "n4"
        Appearance455.TextHAlignAsString = "Center"
        UltraGridColumn123.Header.Appearance = Appearance455
        UltraGridColumn123.Header.VisiblePosition = 11
        UltraGridColumn123.MinWidth = 90
        UltraGridColumn123.Width = 90
        UltraGridColumn124.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance456.TextHAlignAsString = "Right"
        UltraGridColumn124.CellAppearance = Appearance456
        UltraGridColumn124.DataType = GetType(Decimal)
        UltraGridColumn124.Format = "n4"
        UltraGridColumn124.Formula = "[CantReq] * [CostoxTON]"
        Appearance457.TextHAlignAsString = "Center"
        UltraGridColumn124.Header.Appearance = Appearance457
        UltraGridColumn124.Header.VisiblePosition = 12
        UltraGridColumn124.MinWidth = 90
        UltraGridColumn124.Width = 90
        UltraGridColumn125.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance458.TextHAlignAsString = "Right"
        UltraGridColumn125.CellAppearance = Appearance458
        UltraGridColumn125.DataType = GetType(Decimal)
        UltraGridColumn125.Format = "n3"
        Appearance459.TextHAlignAsString = "Center"
        UltraGridColumn125.Header.Appearance = Appearance459
        UltraGridColumn125.Header.Caption = "Stock"
        UltraGridColumn125.Header.VisiblePosition = 3
        UltraGridColumn125.Width = 8
        UltraGridBand8.Columns.AddRange(New Object() {UltraGridColumn113, UltraGridColumn114, UltraGridColumn115, UltraGridColumn116, UltraGridColumn117, UltraGridColumn118, UltraGridColumn119, UltraGridColumn120, UltraGridColumn121, UltraGridColumn122, UltraGridColumn123, UltraGridColumn124, UltraGridColumn125})
        Me.Grid7.DisplayLayout.BandsSerializer.Add(UltraGridBand7)
        Me.Grid7.DisplayLayout.BandsSerializer.Add(UltraGridBand8)
        Me.Grid7.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid7.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid7.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance460.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance460.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance460.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance460.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid7.DisplayLayout.GroupByBox.Appearance = Appearance460
        Appearance461.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid7.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance461
        Me.Grid7.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid7.DisplayLayout.GroupByBox.Hidden = True
        Appearance462.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance462.BackColor2 = System.Drawing.SystemColors.Control
        Appearance462.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance462.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid7.DisplayLayout.GroupByBox.PromptAppearance = Appearance462
        Me.Grid7.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid7.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid7.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid7.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid7.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid7.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Appearance463.BackColor = System.Drawing.SystemColors.Window
        Me.Grid7.DisplayLayout.Override.CardAreaAppearance = Appearance463
        Appearance464.BorderColor = System.Drawing.Color.Silver
        Appearance464.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid7.DisplayLayout.Override.CellAppearance = Appearance464
        Me.Grid7.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid7.DisplayLayout.Override.CellPadding = 0
        Me.Grid7.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.Grid7.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.Grid7.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.Grid7.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance465.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance465.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Grid7.DisplayLayout.Override.FilterRowAppearance = Appearance465
        Me.Grid7.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid7.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid7.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance466.BackColor = System.Drawing.Color.LightYellow
        Me.Grid7.DisplayLayout.Override.FixedRowAppearance = Appearance466
        Me.Grid7.DisplayLayout.Override.FixedRowsLimit = 10
        Me.Grid7.DisplayLayout.Override.FixedRowStyle = Infragistics.Win.UltraWinGrid.FixedRowStyle.Top
        Appearance467.BackColor = System.Drawing.SystemColors.Control
        Appearance467.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance467.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance467.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance467.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid7.DisplayLayout.Override.GroupByRowAppearance = Appearance467
        Appearance468.FontData.Name = "Arial Narrow"
        Appearance468.FontData.SizeInPoints = 10.0!
        Appearance468.TextHAlignAsString = "Left"
        Me.Grid7.DisplayLayout.Override.HeaderAppearance = Appearance468
        Me.Grid7.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid7.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid7.DisplayLayout.Override.MinRowHeight = 24
        Appearance469.BackColor = System.Drawing.SystemColors.Window
        Appearance469.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance469.TextVAlignAsString = "Middle"
        Me.Grid7.DisplayLayout.Override.RowAppearance = Appearance469
        Me.Grid7.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid7.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid7.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid7.DisplayLayout.Override.SpecialRowSeparator = Infragistics.Win.UltraWinGrid.SpecialRowSeparator.FixedRows
        Appearance470.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Grid7.DisplayLayout.Override.SpecialRowSeparatorAppearance = Appearance470
        Me.Grid7.DisplayLayout.Override.SpecialRowSeparatorHeight = 10
        Appearance471.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid7.DisplayLayout.Override.TemplateAddRowAppearance = Appearance471
        Me.Grid7.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid7.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid7.Location = New System.Drawing.Point(0, 25)
        Me.Grid7.Name = "Grid7"
        Me.Grid7.Size = New System.Drawing.Size(705, 436)
        Me.Grid7.TabIndex = 150
        Me.Grid7.Text = "UltraGrid1"
        '
        'Clm1
        '
        Me.Clm1.ContainingControl = Me
        '
        'Num1
        '
        Appearance1.TextHAlignAsString = "Right"
        Me.Num1.Appearance = Appearance1
        Me.Clm1.SetCalcSettings(Me.Num1, New Infragistics.Win.UltraWinCalcManager.CalcSettings("CalsCantidad", Nothing, "", "Text", Infragistics.Win.UltraWinCalcManager.CalcErrorIconAlignment.[Default], Nothing))
        Me.Num1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Num1.FormatString = "##,##0.000"
        Me.Num1.Location = New System.Drawing.Point(157, 155)
        Me.Num1.MaskInput = "{double:10.3}"
        Me.Num1.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 196608})
        Me.Num1.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.Num1.Name = "Num1"
        Me.Num1.Nullable = True
        Me.Num1.NullText = "0.000"
        Me.Num1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Decimal]
        Me.Num1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Num1.ReadOnly = True
        Me.Num1.Size = New System.Drawing.Size(89, 21)
        Me.Num1.TabIndex = 80
        '
        'Num2
        '
        Appearance28.TextHAlignAsString = "Right"
        Me.Num2.Appearance = Appearance28
        Me.Clm1.SetCalcSettings(Me.Num2, New Infragistics.Win.UltraWinCalcManager.CalcSettings("CalsPorcentaje", Nothing, "sum([//Grid7/Ruma/Porcentaje]) +sum( [//Grid8/Band 0/Porcentaje] )+sum( [//Grid6/" & _
                    "Band 0/Porcentaje] )+ sum([//Grid9/Band 0/Porcentaje] )", "Text", Infragistics.Win.UltraWinCalcManager.CalcErrorIconAlignment.[Default], Nothing))
        Me.Num2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Num2.FormatString = "##0.00"
        Me.Num2.Location = New System.Drawing.Point(156, 209)
        Me.Num2.MaskInput = "{double:5.2}"
        Me.Num2.MaxValue = New Decimal(New Integer() {99999, 0, 0, 131072})
        Me.Num2.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.Num2.Name = "Num2"
        Me.Num2.Nullable = True
        Me.Num2.NullText = "0.00"
        Me.Num2.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Decimal]
        Me.Num2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Num2.ReadOnly = True
        Me.Num2.Size = New System.Drawing.Size(90, 21)
        Me.Num2.TabIndex = 96
        '
        'Num4
        '
        Appearance327.TextHAlignAsString = "Right"
        Me.Num4.Appearance = Appearance327
        Me.Clm1.SetCalcSettings(Me.Num4, New Infragistics.Win.UltraWinCalcManager.CalcSettings("CalsCantPlanificada", Nothing, "", "Text", Infragistics.Win.UltraWinCalcManager.CalcErrorIconAlignment.[Default], Nothing))
        Me.Num4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Num4.FormatString = "##,##0.000"
        Me.Num4.Location = New System.Drawing.Point(533, 179)
        Me.Num4.MaskInput = "{double:10.3}"
        Me.Num4.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 196608})
        Me.Num4.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.Num4.Name = "Num4"
        Me.Num4.Nullable = True
        Me.Num4.NullText = "0.00"
        Me.Num4.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Decimal]
        Me.Num4.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Num4.ReadOnly = True
        Me.Num4.Size = New System.Drawing.Size(89, 21)
        Me.Num4.TabIndex = 98
        '
        'Num3
        '
        Appearance265.TextHAlignAsString = "Right"
        Me.Num3.Appearance = Appearance265
        Me.Clm1.SetCalcSettings(Me.Num3, New Infragistics.Win.UltraWinCalcManager.CalcSettings("CalsCantReq", Nothing, "sum( [//Grid7/Ruma/CantidadxNecesaria] )+sum( [//Grid8/Band 0/CantidadxNecesaria]" & _
                    " ) +sum(  [//Grid6/Band 0/CantidadxNecesaria] )+ sum([//Grid9/Band 0/CantidadxNe" & _
                    "cesaria] )", "Text", Infragistics.Win.UltraWinCalcManager.CalcErrorIconAlignment.[Default], Nothing))
        Me.Num3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Num3.FormatString = "##,##0.000"
        Me.Num3.Location = New System.Drawing.Point(531, 155)
        Me.Num3.MaskInput = "{double:10.3}"
        Me.Num3.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 196608})
        Me.Num3.MinValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.Num3.Name = "Num3"
        Me.Num3.Nullable = True
        Me.Num3.NullText = "0.000"
        Me.Num3.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Decimal]
        Me.Num3.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Num3.ReadOnly = True
        Me.Num3.Size = New System.Drawing.Size(89, 21)
        Me.Num3.TabIndex = 100
        '
        'Num5
        '
        Appearance264.TextHAlignAsString = "Right"
        Me.Num5.Appearance = Appearance264
        Me.Clm1.SetCalcSettings(Me.Num5, New Infragistics.Win.UltraWinCalcManager.CalcSettings("clsSuministros", Nothing, "", "Text", Infragistics.Win.UltraWinCalcManager.CalcErrorIconAlignment.[Default], Nothing))
        Me.Num5.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Num5.FormatString = "#,##0.000"
        Me.Num5.Location = New System.Drawing.Point(578, 128)
        Me.Num5.MaskInput = "{double:10.3}"
        Me.Num5.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 196608})
        Me.Num5.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.Num5.Name = "Num5"
        Me.Num5.Nullable = True
        Me.Num5.NullText = "0.00"
        Me.Num5.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Decimal]
        Me.Num5.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Num5.ReadOnly = True
        Me.Num5.Size = New System.Drawing.Size(42, 21)
        Me.Num5.TabIndex = 101
        Me.Num5.Visible = False
        '
        'Num6
        '
        Appearance5.TextHAlignAsString = "Right"
        Me.Num6.Appearance = Appearance5
        Me.Clm1.SetCalcSettings(Me.Num6, New Infragistics.Win.UltraWinCalcManager.CalcSettings("CalsCantPlanificada", Nothing, "", "Text", Infragistics.Win.UltraWinCalcManager.CalcErrorIconAlignment.[Default], Nothing))
        Me.Num6.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Num6.FormatString = "##,##0.000"
        Me.Num6.Location = New System.Drawing.Point(157, 184)
        Me.Num6.MaskInput = "{double:10.3}"
        Me.Num6.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 196608})
        Me.Num6.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.Num6.Name = "Num6"
        Me.Num6.Nullable = True
        Me.Num6.NullText = "0.000"
        Me.Num6.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Decimal]
        Me.Num6.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Num6.ReadOnly = True
        Me.Num6.Size = New System.Drawing.Size(89, 21)
        Me.Num6.TabIndex = 103
        '
        'Num7
        '
        Appearance177.TextHAlignAsString = "Right"
        Me.Num7.Appearance = Appearance177
        Me.Clm1.SetCalcSettings(Me.Num7, New Infragistics.Win.UltraWinCalcManager.CalcSettings("CalsCantCanchadoNecesario", Nothing, "sum([//Grid9/Band 0/CantidadxNecesaria])", "Text", Infragistics.Win.UltraWinCalcManager.CalcErrorIconAlignment.[Default], Nothing))
        Me.Num7.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Num7.FormatString = "##,##0.000"
        Me.Num7.Location = New System.Drawing.Point(252, 184)
        Me.Num7.MaskInput = "{double:10.3}"
        Me.Num7.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 196608})
        Me.Num7.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.Num7.Name = "Num7"
        Me.Num7.Nullable = True
        Me.Num7.NullText = "0.000"
        Me.Num7.NumericType = Infragistics.Win.UltraWinEditors.NumericType.[Decimal]
        Me.Num7.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Num7.ReadOnly = True
        Me.Num7.Size = New System.Drawing.Size(89, 21)
        Me.Num7.TabIndex = 105
        Me.Num7.Visible = False
        '
        'Navigator1
        '
        Me.Navigator1.AddNewItem = Nothing
        Me.Navigator1.BackColor = System.Drawing.SystemColors.Control
        Me.Navigator1.BindingSource = Me.Source2
        Me.Navigator1.CountItem = Nothing
        Me.Navigator1.DeleteItem = Nothing
        Me.Navigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Navigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator13, Me.ToolStripSeparator17, Me.Btn8, Me.ToolStripSeparator18, Me.Btn9, Me.ToolStripSeparator19})
        Me.Navigator1.Location = New System.Drawing.Point(0, 0)
        Me.Navigator1.MoveFirstItem = Nothing
        Me.Navigator1.MoveLastItem = Nothing
        Me.Navigator1.MoveNextItem = Nothing
        Me.Navigator1.MovePreviousItem = Nothing
        Me.Navigator1.Name = "Navigator1"
        Me.Navigator1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.Navigator1.PositionItem = Nothing
        Me.Navigator1.Size = New System.Drawing.Size(705, 25)
        Me.Navigator1.TabIndex = 149
        Me.Navigator1.Text = "BindingNavigator1"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(6, 25)
        '
        'Btn8
        '
        Me.Btn8.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn8.Image = CType(resources.GetObject("Btn8.Image"), System.Drawing.Image)
        Me.Btn8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn8.Name = "Btn8"
        Me.Btn8.Size = New System.Drawing.Size(76, 22)
        Me.Btn8.Text = "&AGREGAR"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        Me.ToolStripSeparator18.Size = New System.Drawing.Size(6, 25)
        '
        'Btn9
        '
        Me.Btn9.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn9.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn9.Image = CType(resources.GetObject("Btn9.Image"), System.Drawing.Image)
        Me.Btn9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn9.Name = "Btn9"
        Me.Btn9.Size = New System.Drawing.Size(67, 22)
        Me.Btn9.Text = "&QUITAR"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl9
        '
        Me.UltraTabPageControl9.Controls.Add(Me.Grid8)
        Me.UltraTabPageControl9.Controls.Add(Me.BindingNavigator2)
        Me.UltraTabPageControl9.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl9.Name = "UltraTabPageControl9"
        Me.UltraTabPageControl9.Size = New System.Drawing.Size(705, 461)
        '
        'Grid8
        '
        Me.Grid8.CalcManager = Me.Clm1
        Me.Grid8.DataSource = Me.UdsProducto
        Appearance302.BackColor = System.Drawing.SystemColors.Window
        Appearance302.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid8.DisplayLayout.Appearance = Appearance302
        Me.Grid8.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn61.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance80.TextHAlignAsString = "Center"
        UltraGridColumn61.Header.Appearance = Appearance80
        UltraGridColumn61.Header.Caption = "Código"
        UltraGridColumn61.Header.VisiblePosition = 0
        UltraGridColumn61.MaxWidth = 80
        UltraGridColumn61.MinWidth = 80
        UltraGridColumn61.Width = 80
        UltraGridColumn62.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance82.TextHAlignAsString = "Center"
        UltraGridColumn62.Header.Appearance = Appearance82
        UltraGridColumn62.Header.Caption = "Producto"
        UltraGridColumn62.Header.VisiblePosition = 1
        UltraGridColumn62.MinWidth = 150
        UltraGridColumn62.Width = 150
        UltraGridColumn63.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance83.TextHAlignAsString = "Right"
        UltraGridColumn63.CellAppearance = Appearance83
        UltraGridColumn63.Format = "n2"
        UltraGridColumn63.Header.Caption = "Pje (%)"
        UltraGridColumn63.Header.VisiblePosition = 3
        UltraGridColumn63.MinWidth = 50
        UltraGridColumn63.Width = 50
        UltraGridColumn64.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance93.TextHAlignAsString = "Right"
        UltraGridColumn64.CellAppearance = Appearance93
        UltraGridColumn64.Format = "n2"
        Appearance94.TextHAlignAsString = "Center"
        UltraGridColumn64.Header.Appearance = Appearance94
        UltraGridColumn64.Header.VisiblePosition = 4
        UltraGridColumn64.MinWidth = 50
        UltraGridColumn64.Width = 50
        UltraGridColumn65.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance95.TextHAlignAsString = "Right"
        UltraGridColumn65.CellAppearance = Appearance95
        UltraGridColumn65.Format = "n2"
        Appearance96.TextHAlignAsString = "Center"
        UltraGridColumn65.Header.Appearance = Appearance96
        UltraGridColumn65.Header.VisiblePosition = 5
        UltraGridColumn65.MinWidth = 50
        UltraGridColumn65.Width = 50
        UltraGridColumn66.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance97.TextHAlignAsString = "Right"
        UltraGridColumn66.CellAppearance = Appearance97
        UltraGridColumn66.Format = "n3"
        Appearance98.TextHAlignAsString = "Center"
        UltraGridColumn66.Header.Appearance = Appearance98
        UltraGridColumn66.Header.Caption = "Stock"
        UltraGridColumn66.Header.VisiblePosition = 6
        UltraGridColumn66.MinWidth = 100
        UltraGridColumn66.Width = 100
        UltraGridColumn67.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance99.TextHAlignAsString = "Right"
        UltraGridColumn67.CellAppearance = Appearance99
        UltraGridColumn67.Format = "n4"
        Appearance101.TextHAlignAsString = "Center"
        UltraGridColumn67.Header.Appearance = Appearance101
        UltraGridColumn67.Header.VisiblePosition = 10
        UltraGridColumn67.MinWidth = 100
        UltraGridColumn67.Width = 100
        UltraGridColumn68.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn68.Header.VisiblePosition = 8
        UltraGridColumn68.Hidden = True
        UltraGridColumn68.Width = 8
        UltraGridColumn69.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn69.Header.VisiblePosition = 9
        UltraGridColumn69.Hidden = True
        UltraGridColumn70.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn70.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance103.TextHAlignAsString = "Right"
        UltraGridColumn70.CellAppearance = Appearance103
        UltraGridColumn70.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn70.DataType = GetType(Decimal)
        UltraGridColumn70.Format = "n3"
        UltraGridColumn70.Formula = "[Cantidad] * [Porcentaje] * 0.01"
        Appearance104.TextHAlignAsString = "Center"
        UltraGridColumn70.Header.Appearance = Appearance104
        UltraGridColumn70.Header.Caption = "Cantidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(TON)"
        UltraGridColumn70.Header.VisiblePosition = 2
        UltraGridColumn70.MaxWidth = 90
        UltraGridColumn70.MinWidth = 90
        UltraGridColumn70.Width = 90
        UltraGridColumn71.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn71.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance123.TextHAlignAsString = "Right"
        UltraGridColumn71.CellAppearance = Appearance123
        UltraGridColumn71.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn71.Format = "n3"
        UltraGridColumn71.Formula = "(100 +  [Humedad] + [Merma]) * 0.01 *   [CantidadxFraccionada]"
        Appearance163.TextHAlignAsString = "Center"
        UltraGridColumn71.Header.Appearance = Appearance163
        UltraGridColumn71.Header.Caption = "Cant.Req." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(TON)"
        UltraGridColumn71.Header.VisiblePosition = 7
        UltraGridColumn71.MaskInput = "{double:10.3}"
        UltraGridColumn71.MaxWidth = 90
        UltraGridColumn71.MinWidth = 90
        UltraGridColumn71.Width = 90
        UltraGridColumn72.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn72.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance170.TextHAlignAsString = "Right"
        UltraGridColumn72.CellAppearance = Appearance170
        UltraGridColumn72.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn72.Format = "c"
        UltraGridColumn72.Formula = "[CantidadxNecesaria] * [CostoxTON]"
        Appearance171.TextHAlignAsString = "Center"
        UltraGridColumn72.Header.Appearance = Appearance171
        UltraGridColumn72.Header.VisiblePosition = 11
        UltraGridColumn72.MaxWidth = 90
        UltraGridColumn72.MinWidth = 90
        UltraGridColumn72.Width = 90
        UltraGridColumn73.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance172.TextHAlignAsString = "Right"
        UltraGridColumn73.CellAppearance = Appearance172
        UltraGridColumn73.Format = "n4"
        UltraGridColumn73.Formula = "if( ISNUMBER([//CalsCantidad]) , [//CalsCantidad] , 0 )"
        UltraGridColumn73.Header.VisiblePosition = 12
        UltraGridColumn73.Hidden = True
        UltraGridColumn73.MinWidth = 100
        UltraGridColumn73.Width = 100
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73})
        Appearance173.BackColor = System.Drawing.SystemColors.Info
        Appearance173.FontData.BoldAsString = "True"
        Appearance173.ForeColor = System.Drawing.Color.Red
        Appearance173.TextHAlignAsString = "Right"
        SummarySettings6.Appearance = Appearance173
        SummarySettings6.DisplayFormat = "{0:N3}"
        SummarySettings6.GroupBySummaryValueAppearance = Appearance174
        Appearance255.BackColor = System.Drawing.SystemColors.Info
        Appearance255.FontData.BoldAsString = "True"
        Appearance255.ForeColor = System.Drawing.Color.Red
        Appearance255.TextHAlignAsString = "Right"
        SummarySettings7.Appearance = Appearance255
        SummarySettings7.DisplayFormat = "{0:N3}"
        SummarySettings7.GroupBySummaryValueAppearance = Appearance256
        Appearance257.BackColor = System.Drawing.SystemColors.Info
        Appearance257.FontData.BoldAsString = "True"
        Appearance257.ForeColor = System.Drawing.Color.Red
        Appearance257.TextHAlignAsString = "Right"
        SummarySettings8.Appearance = Appearance257
        SummarySettings8.DisplayFormat = "{0:N4}"
        SummarySettings8.GroupBySummaryValueAppearance = Appearance258
        Appearance259.BackColor = System.Drawing.SystemColors.Info
        Appearance259.FontData.BoldAsString = "True"
        Appearance259.ForeColor = System.Drawing.Color.Red
        Appearance259.TextHAlignAsString = "Right"
        SummarySettings9.Appearance = Appearance259
        SummarySettings9.DisplayFormat = "{0:N2}"
        SummarySettings9.GroupBySummaryValueAppearance = Appearance260
        Appearance261.BackColor = System.Drawing.SystemColors.Info
        Appearance261.FontData.BoldAsString = "True"
        Appearance261.ForeColor = System.Drawing.Color.Red
        Appearance261.TextHAlignAsString = "Right"
        SummarySettings10.Appearance = Appearance261
        SummarySettings10.DisplayFormat = "{0:N3}"
        SummarySettings10.GroupBySummaryValueAppearance = Appearance262
        UltraGridBand4.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings6, SummarySettings7, SummarySettings8, SummarySettings9, SummarySettings10})
        UltraGridBand4.SummaryFooterCaption = ""
        UltraGridBand4.UseRowLayout = True
        Me.Grid8.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.Grid8.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid8.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid8.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance531.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance531.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance531.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance531.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid8.DisplayLayout.GroupByBox.Appearance = Appearance531
        Appearance532.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid8.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance532
        Me.Grid8.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid8.DisplayLayout.GroupByBox.Hidden = True
        Appearance533.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance533.BackColor2 = System.Drawing.SystemColors.Control
        Appearance533.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance533.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid8.DisplayLayout.GroupByBox.PromptAppearance = Appearance533
        Me.Grid8.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid8.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid8.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid8.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid8.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid8.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance534.BackColor = System.Drawing.SystemColors.Window
        Me.Grid8.DisplayLayout.Override.CardAreaAppearance = Appearance534
        Appearance535.BorderColor = System.Drawing.Color.Silver
        Appearance535.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid8.DisplayLayout.Override.CellAppearance = Appearance535
        Me.Grid8.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid8.DisplayLayout.Override.CellPadding = 0
        Me.Grid8.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance536.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grid8.DisplayLayout.Override.FilterRowAppearance = Appearance536
        Me.Grid8.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid8.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid8.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance537.BackColor = System.Drawing.SystemColors.Control
        Appearance537.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance537.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance537.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance537.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid8.DisplayLayout.Override.GroupByRowAppearance = Appearance537
        Appearance538.FontData.Name = "Arial Narrow"
        Appearance538.FontData.SizeInPoints = 10.0!
        Appearance538.TextHAlignAsString = "Left"
        Me.Grid8.DisplayLayout.Override.HeaderAppearance = Appearance538
        Me.Grid8.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid8.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid8.DisplayLayout.Override.MinRowHeight = 24
        Appearance539.BackColor = System.Drawing.SystemColors.Window
        Appearance539.BorderColor = System.Drawing.Color.Silver
        Appearance539.TextVAlignAsString = "Middle"
        Me.Grid8.DisplayLayout.Override.RowAppearance = Appearance539
        Me.Grid8.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid8.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid8.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance540.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid8.DisplayLayout.Override.TemplateAddRowAppearance = Appearance540
        Me.Grid8.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid8.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid8.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid8.Location = New System.Drawing.Point(0, 25)
        Me.Grid8.Name = "Grid8"
        Me.Grid8.Size = New System.Drawing.Size(705, 436)
        Me.Grid8.TabIndex = 151
        Me.Grid8.Text = "UltraGrid1"
        '
        'UdsProducto
        '
        UltraDataColumn11.DataType = GetType(Decimal)
        UltraDataColumn12.DataType = GetType(Decimal)
        UltraDataColumn13.DataType = GetType(Decimal)
        UltraDataColumn14.DataType = GetType(Decimal)
        UltraDataColumn15.DataType = GetType(Decimal)
        UltraDataColumn16.DataType = GetType(Integer)
        UltraDataColumn17.DataType = GetType(Boolean)
        Me.UdsProducto.Band.Columns.AddRange(New Object() {UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17})
        '
        'BindingNavigator2
        '
        Me.BindingNavigator2.AddNewItem = Nothing
        Me.BindingNavigator2.BackColor = System.Drawing.SystemColors.Control
        Me.BindingNavigator2.BindingSource = Me.Source2
        Me.BindingNavigator2.CountItem = Nothing
        Me.BindingNavigator2.DeleteItem = Nothing
        Me.BindingNavigator2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator20, Me.ToolStripLabel6, Me.ToolStripSeparator24, Me.Btn10, Me.ToolStripSeparator25, Me.Btn11, Me.ToolStripSeparator26})
        Me.BindingNavigator2.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator2.MoveFirstItem = Nothing
        Me.BindingNavigator2.MoveLastItem = Nothing
        Me.BindingNavigator2.MoveNextItem = Nothing
        Me.BindingNavigator2.MovePreviousItem = Nothing
        Me.BindingNavigator2.Name = "BindingNavigator2"
        Me.BindingNavigator2.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.BindingNavigator2.PositionItem = Nothing
        Me.BindingNavigator2.Size = New System.Drawing.Size(705, 25)
        Me.BindingNavigator2.TabIndex = 150
        Me.BindingNavigator2.Text = "BindingNavigator2"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(34, 22)
        Me.ToolStripLabel6.Text = "         "
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(6, 25)
        '
        'Btn10
        '
        Me.Btn10.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn10.Image = CType(resources.GetObject("Btn10.Image"), System.Drawing.Image)
        Me.Btn10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn10.Name = "Btn10"
        Me.Btn10.Size = New System.Drawing.Size(76, 22)
        Me.Btn10.Text = "&AGREGAR"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(6, 25)
        '
        'Btn11
        '
        Me.Btn11.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn11.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn11.Image = CType(resources.GetObject("Btn11.Image"), System.Drawing.Image)
        Me.Btn11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn11.Name = "Btn11"
        Me.Btn11.Size = New System.Drawing.Size(67, 22)
        Me.Btn11.Text = "&QUITAR"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl10
        '
        Me.UltraTabPageControl10.Controls.Add(Me.Grid6)
        Me.UltraTabPageControl10.Controls.Add(Me.BindingNavigator3)
        Me.UltraTabPageControl10.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl10.Name = "UltraTabPageControl10"
        Me.UltraTabPageControl10.Size = New System.Drawing.Size(705, 461)
        '
        'Grid6
        '
        Me.Grid6.CalcManager = Me.Clm1
        Me.Grid6.DataSource = Me.UdsProducto
        Appearance92.BackColor = System.Drawing.SystemColors.Window
        Appearance92.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid6.DisplayLayout.Appearance = Appearance92
        Me.Grid6.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn74.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance263.TextHAlignAsString = "Center"
        UltraGridColumn74.Header.Appearance = Appearance263
        UltraGridColumn74.Header.Caption = "Código"
        UltraGridColumn74.Header.VisiblePosition = 0
        UltraGridColumn74.MaxWidth = 80
        UltraGridColumn74.MinWidth = 80
        UltraGridColumn74.Width = 80
        UltraGridColumn75.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance267.TextHAlignAsString = "Center"
        UltraGridColumn75.Header.Appearance = Appearance267
        UltraGridColumn75.Header.Caption = "Suministro"
        UltraGridColumn75.Header.VisiblePosition = 1
        UltraGridColumn75.MinWidth = 150
        UltraGridColumn75.Width = 150
        UltraGridColumn76.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance268.TextHAlignAsString = "Right"
        UltraGridColumn76.CellAppearance = Appearance268
        UltraGridColumn76.Format = "n2"
        UltraGridColumn76.Header.Caption = "Pje (%)"
        UltraGridColumn76.Header.VisiblePosition = 3
        UltraGridColumn76.MinWidth = 50
        UltraGridColumn76.Width = 50
        UltraGridColumn77.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance269.TextHAlignAsString = "Right"
        UltraGridColumn77.CellAppearance = Appearance269
        UltraGridColumn77.Format = "n2"
        Appearance270.TextHAlignAsString = "Center"
        UltraGridColumn77.Header.Appearance = Appearance270
        UltraGridColumn77.Header.VisiblePosition = 4
        UltraGridColumn77.MinWidth = 50
        UltraGridColumn77.Width = 50
        UltraGridColumn78.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance271.TextHAlignAsString = "Right"
        UltraGridColumn78.CellAppearance = Appearance271
        UltraGridColumn78.Format = "n2"
        Appearance274.TextHAlignAsString = "Center"
        UltraGridColumn78.Header.Appearance = Appearance274
        UltraGridColumn78.Header.VisiblePosition = 5
        UltraGridColumn78.MinWidth = 50
        UltraGridColumn78.Width = 50
        UltraGridColumn79.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance275.TextHAlignAsString = "Right"
        UltraGridColumn79.CellAppearance = Appearance275
        UltraGridColumn79.Format = "n3"
        Appearance276.TextHAlignAsString = "Center"
        UltraGridColumn79.Header.Appearance = Appearance276
        UltraGridColumn79.Header.Caption = "Stock"
        UltraGridColumn79.Header.VisiblePosition = 6
        UltraGridColumn79.MinWidth = 100
        UltraGridColumn79.Width = 100
        UltraGridColumn80.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance277.TextHAlignAsString = "Right"
        UltraGridColumn80.CellAppearance = Appearance277
        UltraGridColumn80.Format = "n4"
        Appearance278.TextHAlignAsString = "Center"
        UltraGridColumn80.Header.Appearance = Appearance278
        UltraGridColumn80.Header.VisiblePosition = 10
        UltraGridColumn80.MinWidth = 100
        UltraGridColumn80.Width = 100
        UltraGridColumn81.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn81.Header.VisiblePosition = 8
        UltraGridColumn81.Hidden = True
        UltraGridColumn81.Width = 8
        UltraGridColumn82.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn82.Header.VisiblePosition = 9
        UltraGridColumn82.Hidden = True
        UltraGridColumn83.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn83.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance289.TextHAlignAsString = "Right"
        UltraGridColumn83.CellAppearance = Appearance289
        UltraGridColumn83.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn83.DataType = GetType(Decimal)
        UltraGridColumn83.Format = "n3"
        UltraGridColumn83.Formula = "[Cantidad] * [Porcentaje] * 0.01"
        Appearance290.TextHAlignAsString = "Center"
        UltraGridColumn83.Header.Appearance = Appearance290
        UltraGridColumn83.Header.Caption = "Cantidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(TON)"
        UltraGridColumn83.Header.VisiblePosition = 2
        UltraGridColumn83.MaxWidth = 90
        UltraGridColumn83.MinWidth = 90
        UltraGridColumn83.Width = 90
        UltraGridColumn84.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn84.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance291.TextHAlignAsString = "Right"
        UltraGridColumn84.CellAppearance = Appearance291
        UltraGridColumn84.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn84.Format = "n3"
        UltraGridColumn84.Formula = "(100 +  [Humedad] + [Merma]) * 0.01 *   [CantidadxFraccionada]"
        Appearance292.TextHAlignAsString = "Center"
        UltraGridColumn84.Header.Appearance = Appearance292
        UltraGridColumn84.Header.Caption = "Cant.Req." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(TON)"
        UltraGridColumn84.Header.VisiblePosition = 7
        UltraGridColumn84.MaskInput = "{double:10.3}"
        UltraGridColumn84.MaxWidth = 90
        UltraGridColumn84.MinWidth = 90
        UltraGridColumn84.Width = 90
        UltraGridColumn85.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn85.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance293.TextHAlignAsString = "Right"
        UltraGridColumn85.CellAppearance = Appearance293
        UltraGridColumn85.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn85.Format = "c"
        UltraGridColumn85.Formula = "[CantidadxNecesaria] * [CostoxTON]"
        Appearance294.TextHAlignAsString = "Center"
        UltraGridColumn85.Header.Appearance = Appearance294
        UltraGridColumn85.Header.VisiblePosition = 11
        UltraGridColumn85.MaxWidth = 90
        UltraGridColumn85.MinWidth = 90
        UltraGridColumn85.Width = 90
        UltraGridColumn86.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance295.TextHAlignAsString = "Right"
        UltraGridColumn86.CellAppearance = Appearance295
        UltraGridColumn86.Format = "n4"
        UltraGridColumn86.Formula = "if( ISNUMBER([//CalsCantidad]) , [//CalsCantidad] , 0 )"
        UltraGridColumn86.Header.VisiblePosition = 12
        UltraGridColumn86.Hidden = True
        UltraGridColumn86.MinWidth = 100
        UltraGridColumn86.Width = 100
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn81, UltraGridColumn82, UltraGridColumn83, UltraGridColumn84, UltraGridColumn85, UltraGridColumn86})
        Appearance296.BackColor = System.Drawing.SystemColors.Info
        Appearance296.FontData.BoldAsString = "True"
        Appearance296.ForeColor = System.Drawing.Color.Red
        Appearance296.TextHAlignAsString = "Right"
        SummarySettings11.Appearance = Appearance296
        SummarySettings11.DisplayFormat = "{0:N3}"
        SummarySettings11.GroupBySummaryValueAppearance = Appearance297
        Appearance298.BackColor = System.Drawing.SystemColors.Info
        Appearance298.FontData.BoldAsString = "True"
        Appearance298.ForeColor = System.Drawing.Color.Red
        Appearance298.TextHAlignAsString = "Right"
        SummarySettings12.Appearance = Appearance298
        SummarySettings12.DisplayFormat = "{0:N3}"
        SummarySettings12.GroupBySummaryValueAppearance = Appearance299
        Appearance300.BackColor = System.Drawing.SystemColors.Info
        Appearance300.FontData.BoldAsString = "True"
        Appearance300.ForeColor = System.Drawing.Color.Red
        Appearance300.TextHAlignAsString = "Right"
        SummarySettings13.Appearance = Appearance300
        SummarySettings13.DisplayFormat = "{0:N4}"
        SummarySettings13.GroupBySummaryValueAppearance = Appearance301
        Appearance303.BackColor = System.Drawing.SystemColors.Info
        Appearance303.FontData.BoldAsString = "True"
        Appearance303.ForeColor = System.Drawing.Color.Red
        Appearance303.TextHAlignAsString = "Right"
        SummarySettings14.Appearance = Appearance303
        SummarySettings14.DisplayFormat = "{0:N2}"
        SummarySettings14.GroupBySummaryValueAppearance = Appearance304
        Appearance305.BackColor = System.Drawing.SystemColors.Info
        Appearance305.FontData.BoldAsString = "True"
        Appearance305.ForeColor = System.Drawing.Color.Red
        Appearance305.TextHAlignAsString = "Right"
        SummarySettings15.Appearance = Appearance305
        SummarySettings15.DisplayFormat = "{0:N3}"
        SummarySettings15.GroupBySummaryValueAppearance = Appearance306
        UltraGridBand5.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings11, SummarySettings12, SummarySettings13, SummarySettings14, SummarySettings15})
        UltraGridBand5.SummaryFooterCaption = ""
        UltraGridBand5.UseRowLayout = True
        Me.Grid6.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.Grid6.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid6.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid6.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance279.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance279.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance279.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance279.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid6.DisplayLayout.GroupByBox.Appearance = Appearance279
        Appearance280.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid6.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance280
        Me.Grid6.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid6.DisplayLayout.GroupByBox.Hidden = True
        Appearance281.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance281.BackColor2 = System.Drawing.SystemColors.Control
        Appearance281.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance281.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid6.DisplayLayout.GroupByBox.PromptAppearance = Appearance281
        Me.Grid6.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid6.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid6.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid6.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid6.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid6.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance282.BackColor = System.Drawing.SystemColors.Window
        Me.Grid6.DisplayLayout.Override.CardAreaAppearance = Appearance282
        Appearance283.BorderColor = System.Drawing.Color.Silver
        Appearance283.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid6.DisplayLayout.Override.CellAppearance = Appearance283
        Me.Grid6.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid6.DisplayLayout.Override.CellPadding = 0
        Me.Grid6.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance284.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grid6.DisplayLayout.Override.FilterRowAppearance = Appearance284
        Me.Grid6.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid6.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid6.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance285.BackColor = System.Drawing.SystemColors.Control
        Appearance285.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance285.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance285.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance285.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid6.DisplayLayout.Override.GroupByRowAppearance = Appearance285
        Appearance286.FontData.Name = "Arial Narrow"
        Appearance286.FontData.SizeInPoints = 10.0!
        Appearance286.TextHAlignAsString = "Left"
        Me.Grid6.DisplayLayout.Override.HeaderAppearance = Appearance286
        Me.Grid6.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid6.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid6.DisplayLayout.Override.MinRowHeight = 24
        Appearance287.BackColor = System.Drawing.SystemColors.Window
        Appearance287.BorderColor = System.Drawing.Color.Silver
        Appearance287.TextVAlignAsString = "Middle"
        Me.Grid6.DisplayLayout.Override.RowAppearance = Appearance287
        Me.Grid6.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid6.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid6.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance288.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid6.DisplayLayout.Override.TemplateAddRowAppearance = Appearance288
        Me.Grid6.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid6.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid6.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid6.Location = New System.Drawing.Point(0, 25)
        Me.Grid6.Name = "Grid6"
        Me.Grid6.Size = New System.Drawing.Size(705, 436)
        Me.Grid6.TabIndex = 152
        Me.Grid6.Text = "UltraGrid1"
        '
        'BindingNavigator3
        '
        Me.BindingNavigator3.AddNewItem = Nothing
        Me.BindingNavigator3.BackColor = System.Drawing.SystemColors.Control
        Me.BindingNavigator3.BindingSource = Me.Source2
        Me.BindingNavigator3.CountItem = Nothing
        Me.BindingNavigator3.DeleteItem = Nothing
        Me.BindingNavigator3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator34, Me.ToolStripSeparator38, Me.Btn12, Me.ToolStripSeparator39, Me.Btn13, Me.ToolStripSeparator40})
        Me.BindingNavigator3.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator3.MoveFirstItem = Nothing
        Me.BindingNavigator3.MoveLastItem = Nothing
        Me.BindingNavigator3.MoveNextItem = Nothing
        Me.BindingNavigator3.MovePreviousItem = Nothing
        Me.BindingNavigator3.Name = "BindingNavigator3"
        Me.BindingNavigator3.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.BindingNavigator3.PositionItem = Nothing
        Me.BindingNavigator3.Size = New System.Drawing.Size(705, 25)
        Me.BindingNavigator3.TabIndex = 151
        Me.BindingNavigator3.Text = "BindingNavigator3"
        '
        'ToolStripSeparator34
        '
        Me.ToolStripSeparator34.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator34.Name = "ToolStripSeparator34"
        Me.ToolStripSeparator34.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator38
        '
        Me.ToolStripSeparator38.Name = "ToolStripSeparator38"
        Me.ToolStripSeparator38.Size = New System.Drawing.Size(6, 25)
        '
        'Btn12
        '
        Me.Btn12.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn12.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn12.Image = CType(resources.GetObject("Btn12.Image"), System.Drawing.Image)
        Me.Btn12.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn12.Name = "Btn12"
        Me.Btn12.Size = New System.Drawing.Size(76, 22)
        Me.Btn12.Text = "&AGREGAR"
        '
        'ToolStripSeparator39
        '
        Me.ToolStripSeparator39.Name = "ToolStripSeparator39"
        Me.ToolStripSeparator39.Size = New System.Drawing.Size(6, 25)
        '
        'Btn13
        '
        Me.Btn13.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn13.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn13.Image = CType(resources.GetObject("Btn13.Image"), System.Drawing.Image)
        Me.Btn13.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn13.Name = "Btn13"
        Me.Btn13.Size = New System.Drawing.Size(67, 22)
        Me.Btn13.Text = "&QUITAR"
        '
        'ToolStripSeparator40
        '
        Me.ToolStripSeparator40.Name = "ToolStripSeparator40"
        Me.ToolStripSeparator40.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl11
        '
        Me.UltraTabPageControl11.Controls.Add(Me.Grid9)
        Me.UltraTabPageControl11.Controls.Add(Me.BindingNavigator4)
        Me.UltraTabPageControl11.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl11.Name = "UltraTabPageControl11"
        Me.UltraTabPageControl11.Size = New System.Drawing.Size(705, 461)
        '
        'Grid9
        '
        Me.Grid9.CalcManager = Me.Clm1
        Me.Grid9.DataSource = Me.UdsProdRecirculado
        Appearance904.BackColor = System.Drawing.SystemColors.Window
        Appearance904.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid9.DisplayLayout.Appearance = Appearance904
        Me.Grid9.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn87.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance307.TextHAlignAsString = "Center"
        UltraGridColumn87.Header.Appearance = Appearance307
        UltraGridColumn87.Header.Caption = "Código"
        UltraGridColumn87.Header.VisiblePosition = 0
        UltraGridColumn87.MaxWidth = 80
        UltraGridColumn87.MinWidth = 80
        UltraGridColumn87.Width = 80
        UltraGridColumn88.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance308.TextHAlignAsString = "Center"
        UltraGridColumn88.Header.Appearance = Appearance308
        UltraGridColumn88.Header.Caption = "Producto"
        UltraGridColumn88.Header.VisiblePosition = 1
        UltraGridColumn88.MinWidth = 150
        UltraGridColumn88.Width = 150
        UltraGridColumn89.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance309.TextHAlignAsString = "Right"
        UltraGridColumn89.CellAppearance = Appearance309
        UltraGridColumn89.Format = "n2"
        UltraGridColumn89.Header.Caption = "Pje (%)"
        UltraGridColumn89.Header.VisiblePosition = 3
        UltraGridColumn89.MinWidth = 50
        UltraGridColumn89.Width = 50
        UltraGridColumn90.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance310.TextHAlignAsString = "Right"
        UltraGridColumn90.CellAppearance = Appearance310
        UltraGridColumn90.Format = "n2"
        Appearance311.TextHAlignAsString = "Center"
        UltraGridColumn90.Header.Appearance = Appearance311
        UltraGridColumn90.Header.VisiblePosition = 4
        UltraGridColumn90.MinWidth = 50
        UltraGridColumn90.Width = 50
        UltraGridColumn91.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance312.TextHAlignAsString = "Right"
        UltraGridColumn91.CellAppearance = Appearance312
        UltraGridColumn91.Format = "n2"
        Appearance313.TextHAlignAsString = "Center"
        UltraGridColumn91.Header.Appearance = Appearance313
        UltraGridColumn91.Header.VisiblePosition = 5
        UltraGridColumn91.MinWidth = 50
        UltraGridColumn91.Width = 50
        UltraGridColumn92.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance314.TextHAlignAsString = "Right"
        UltraGridColumn92.CellAppearance = Appearance314
        UltraGridColumn92.Format = "n3"
        Appearance315.TextHAlignAsString = "Center"
        UltraGridColumn92.Header.Appearance = Appearance315
        UltraGridColumn92.Header.Caption = "Stock"
        UltraGridColumn92.Header.VisiblePosition = 6
        UltraGridColumn92.MinWidth = 100
        UltraGridColumn92.Width = 100
        UltraGridColumn93.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance549.TextHAlignAsString = "Right"
        UltraGridColumn93.CellAppearance = Appearance549
        UltraGridColumn93.Format = "n4"
        Appearance550.TextHAlignAsString = "Center"
        UltraGridColumn93.Header.Appearance = Appearance550
        UltraGridColumn93.Header.VisiblePosition = 10
        UltraGridColumn93.MinWidth = 100
        UltraGridColumn93.Width = 100
        UltraGridColumn94.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn94.Header.VisiblePosition = 8
        UltraGridColumn94.Hidden = True
        UltraGridColumn94.Width = 8
        UltraGridColumn95.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn95.Header.VisiblePosition = 9
        UltraGridColumn95.Hidden = True
        UltraGridColumn96.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn96.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance551.TextHAlignAsString = "Right"
        UltraGridColumn96.CellAppearance = Appearance551
        UltraGridColumn96.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn96.DataType = GetType(Decimal)
        UltraGridColumn96.Format = "n3"
        UltraGridColumn96.Formula = "[Cantidad] * [Porcentaje] * 0.01"
        Appearance552.TextHAlignAsString = "Center"
        UltraGridColumn96.Header.Appearance = Appearance552
        UltraGridColumn96.Header.Caption = "Cantidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(TON)"
        UltraGridColumn96.Header.VisiblePosition = 2
        UltraGridColumn96.MaxWidth = 90
        UltraGridColumn96.MinWidth = 90
        UltraGridColumn96.Width = 90
        UltraGridColumn97.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn97.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance553.TextHAlignAsString = "Right"
        UltraGridColumn97.CellAppearance = Appearance553
        UltraGridColumn97.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn97.Format = "n3"
        UltraGridColumn97.Formula = "(100 +  [Humedad] + [Merma]) * 0.01 *   [CantidadxFraccionada]"
        Appearance554.TextHAlignAsString = "Center"
        UltraGridColumn97.Header.Appearance = Appearance554
        UltraGridColumn97.Header.Caption = "Cant.Req." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(TON)"
        UltraGridColumn97.Header.VisiblePosition = 7
        UltraGridColumn97.MaskInput = "{double:10.3}"
        UltraGridColumn97.MaxWidth = 90
        UltraGridColumn97.MinWidth = 90
        UltraGridColumn97.Width = 90
        UltraGridColumn98.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn98.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance555.TextHAlignAsString = "Right"
        UltraGridColumn98.CellAppearance = Appearance555
        UltraGridColumn98.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn98.Format = "c"
        UltraGridColumn98.Formula = "[CantidadxNecesaria] * [CostoxTON]"
        Appearance556.TextHAlignAsString = "Center"
        UltraGridColumn98.Header.Appearance = Appearance556
        UltraGridColumn98.Header.VisiblePosition = 11
        UltraGridColumn98.MaxWidth = 90
        UltraGridColumn98.MinWidth = 90
        UltraGridColumn98.Width = 90
        UltraGridColumn99.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance557.TextHAlignAsString = "Right"
        UltraGridColumn99.CellAppearance = Appearance557
        UltraGridColumn99.Format = "n4"
        UltraGridColumn99.Formula = "if( ISNUMBER([//CalsCantidad]) , [//CalsCantidad] , 0 )"
        UltraGridColumn99.Header.VisiblePosition = 12
        UltraGridColumn99.Hidden = True
        UltraGridColumn99.MinWidth = 100
        UltraGridColumn99.Width = 100
        UltraGridBand6.Columns.AddRange(New Object() {UltraGridColumn87, UltraGridColumn88, UltraGridColumn89, UltraGridColumn90, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn95, UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99})
        Appearance558.BackColor = System.Drawing.SystemColors.Info
        Appearance558.FontData.BoldAsString = "True"
        Appearance558.ForeColor = System.Drawing.Color.Red
        Appearance558.TextHAlignAsString = "Right"
        SummarySettings16.Appearance = Appearance558
        SummarySettings16.DisplayFormat = "{0:N3}"
        SummarySettings16.GroupBySummaryValueAppearance = Appearance559
        Appearance560.BackColor = System.Drawing.SystemColors.Info
        Appearance560.FontData.BoldAsString = "True"
        Appearance560.ForeColor = System.Drawing.Color.Red
        Appearance560.TextHAlignAsString = "Right"
        SummarySettings17.Appearance = Appearance560
        SummarySettings17.DisplayFormat = "{0:N3}"
        SummarySettings17.GroupBySummaryValueAppearance = Appearance561
        Appearance562.BackColor = System.Drawing.SystemColors.Info
        Appearance562.FontData.BoldAsString = "True"
        Appearance562.ForeColor = System.Drawing.Color.Red
        Appearance562.TextHAlignAsString = "Right"
        SummarySettings18.Appearance = Appearance562
        SummarySettings18.DisplayFormat = "{0:N4}"
        SummarySettings18.GroupBySummaryValueAppearance = Appearance563
        Appearance564.BackColor = System.Drawing.SystemColors.Info
        Appearance564.FontData.BoldAsString = "True"
        Appearance564.ForeColor = System.Drawing.Color.Red
        Appearance564.TextHAlignAsString = "Right"
        SummarySettings19.Appearance = Appearance564
        SummarySettings19.DisplayFormat = "{0:N2}"
        SummarySettings19.GroupBySummaryValueAppearance = Appearance565
        Appearance566.BackColor = System.Drawing.SystemColors.Info
        Appearance566.FontData.BoldAsString = "True"
        Appearance566.ForeColor = System.Drawing.Color.Red
        Appearance566.TextHAlignAsString = "Right"
        SummarySettings20.Appearance = Appearance566
        SummarySettings20.DisplayFormat = "{0:N3}"
        SummarySettings20.GroupBySummaryValueAppearance = Appearance567
        UltraGridBand6.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings16, SummarySettings17, SummarySettings18, SummarySettings19, SummarySettings20})
        UltraGridBand6.SummaryFooterCaption = ""
        UltraGridBand6.UseRowLayout = True
        Me.Grid9.DisplayLayout.BandsSerializer.Add(UltraGridBand6)
        Me.Grid9.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid9.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid9.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance933.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance933.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance933.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance933.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid9.DisplayLayout.GroupByBox.Appearance = Appearance933
        Appearance934.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid9.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance934
        Me.Grid9.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid9.DisplayLayout.GroupByBox.Hidden = True
        Appearance935.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance935.BackColor2 = System.Drawing.SystemColors.Control
        Appearance935.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance935.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid9.DisplayLayout.GroupByBox.PromptAppearance = Appearance935
        Me.Grid9.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid9.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid9.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid9.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid9.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid9.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance936.BackColor = System.Drawing.SystemColors.Window
        Me.Grid9.DisplayLayout.Override.CardAreaAppearance = Appearance936
        Appearance937.BorderColor = System.Drawing.Color.Silver
        Appearance937.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid9.DisplayLayout.Override.CellAppearance = Appearance937
        Me.Grid9.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid9.DisplayLayout.Override.CellPadding = 0
        Me.Grid9.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance938.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grid9.DisplayLayout.Override.FilterRowAppearance = Appearance938
        Me.Grid9.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid9.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid9.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance939.BackColor = System.Drawing.SystemColors.Control
        Appearance939.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance939.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance939.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance939.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid9.DisplayLayout.Override.GroupByRowAppearance = Appearance939
        Appearance940.FontData.Name = "Arial Narrow"
        Appearance940.FontData.SizeInPoints = 10.0!
        Appearance940.TextHAlignAsString = "Left"
        Me.Grid9.DisplayLayout.Override.HeaderAppearance = Appearance940
        Me.Grid9.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid9.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid9.DisplayLayout.Override.MinRowHeight = 24
        Appearance941.BackColor = System.Drawing.SystemColors.Window
        Appearance941.BorderColor = System.Drawing.Color.Silver
        Appearance941.TextVAlignAsString = "Middle"
        Me.Grid9.DisplayLayout.Override.RowAppearance = Appearance941
        Me.Grid9.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid9.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid9.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance942.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid9.DisplayLayout.Override.TemplateAddRowAppearance = Appearance942
        Me.Grid9.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid9.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid9.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid9.Location = New System.Drawing.Point(0, 25)
        Me.Grid9.Name = "Grid9"
        Me.Grid9.Size = New System.Drawing.Size(705, 436)
        Me.Grid9.TabIndex = 153
        Me.Grid9.Text = "UltraGrid1"
        '
        'UdsProdRecirculado
        '
        UltraDataColumn20.DataType = GetType(Decimal)
        UltraDataColumn21.DataType = GetType(Decimal)
        UltraDataColumn22.DataType = GetType(Decimal)
        UltraDataColumn23.DataType = GetType(Decimal)
        UltraDataColumn24.DataType = GetType(Decimal)
        UltraDataColumn25.DataType = GetType(Integer)
        UltraDataColumn26.DataType = GetType(Boolean)
        Me.UdsProdRecirculado.Band.Columns.AddRange(New Object() {UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26})
        '
        'BindingNavigator4
        '
        Me.BindingNavigator4.AddNewItem = Nothing
        Me.BindingNavigator4.BackColor = System.Drawing.SystemColors.Control
        Me.BindingNavigator4.BindingSource = Me.Source2
        Me.BindingNavigator4.CountItem = Nothing
        Me.BindingNavigator4.DeleteItem = Nothing
        Me.BindingNavigator4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator14, Me.ToolStripLabel3, Me.ToolStripSeparator15, Me.Btn14, Me.ToolStripSeparator16, Me.Btn15, Me.ToolStripSeparator21})
        Me.BindingNavigator4.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator4.MoveFirstItem = Nothing
        Me.BindingNavigator4.MoveLastItem = Nothing
        Me.BindingNavigator4.MoveNextItem = Nothing
        Me.BindingNavigator4.MovePreviousItem = Nothing
        Me.BindingNavigator4.Name = "BindingNavigator4"
        Me.BindingNavigator4.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.BindingNavigator4.PositionItem = Nothing
        Me.BindingNavigator4.Size = New System.Drawing.Size(705, 25)
        Me.BindingNavigator4.TabIndex = 152
        Me.BindingNavigator4.Text = "BindingNavigator4"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(34, 22)
        Me.ToolStripLabel3.Text = "         "
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(6, 25)
        '
        'Btn14
        '
        Me.Btn14.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn14.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn14.Image = CType(resources.GetObject("Btn14.Image"), System.Drawing.Image)
        Me.Btn14.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn14.Name = "Btn14"
        Me.Btn14.Size = New System.Drawing.Size(76, 22)
        Me.Btn14.Text = "&AGREGAR"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 25)
        '
        'Btn15
        '
        Me.Btn15.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn15.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn15.Image = CType(resources.GetObject("Btn15.Image"), System.Drawing.Image)
        Me.Btn15.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn15.Name = "Btn15"
        Me.Btn15.Size = New System.Drawing.Size(67, 22)
        Me.Btn15.Text = "&QUITAR"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.Grid3)
        Me.UltraTabPageControl3.Controls.Add(Me.Tool1)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(2, 33)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(676, 191)
        '
        'Grid3
        '
        Me.Grid3.CalcManager = Me.Clm1
        Appearance188.BackColor = System.Drawing.SystemColors.Window
        Appearance188.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid3.DisplayLayout.Appearance = Appearance188
        Me.Grid3.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance189.TextHAlignAsString = "Center"
        UltraGridColumn1.CellAppearance = Appearance189
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance190.Image = CType(resources.GetObject("Appearance190.Image"), Object)
        Appearance190.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance190.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance190.TextHAlignAsString = "Center"
        UltraGridColumn1.Header.Appearance = Appearance190
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 25
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 25
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance191.TextHAlignAsString = "Center"
        UltraGridColumn2.CellAppearance = Appearance191
        UltraGridColumn2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance192.TextHAlignAsString = "Center"
        UltraGridColumn2.Header.Appearance = Appearance192
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 120
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance193.TextHAlignAsString = "Center"
        UltraGridColumn3.CellAppearance = Appearance193
        UltraGridColumn3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance194.TextHAlignAsString = "Center"
        UltraGridColumn3.Header.Appearance = Appearance194
        UltraGridColumn3.Header.Caption = "Lote"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.MaxWidth = 150
        UltraGridColumn3.MinWidth = 150
        UltraGridColumn3.Width = 150
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance195.TextHAlignAsString = "Center"
        UltraGridColumn4.CellAppearance = Appearance195
        UltraGridColumn4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance196.TextHAlignAsString = "Center"
        UltraGridColumn4.Header.Appearance = Appearance196
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance197.TextHAlignAsString = "Center"
        UltraGridColumn5.CellAppearance = Appearance197
        UltraGridColumn5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance198.TextHAlignAsString = "Center"
        UltraGridColumn5.Header.Appearance = Appearance198
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Hidden = True
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance199.TextHAlignAsString = "Center"
        UltraGridColumn6.CellAppearance = Appearance199
        UltraGridColumn6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn6.DataType = GetType(Date)
        Appearance200.TextHAlignAsString = "Center"
        UltraGridColumn6.Header.Appearance = Appearance200
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.MaxWidth = 70
        UltraGridColumn6.MinWidth = 70
        UltraGridColumn6.Width = 70
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance201.TextHAlignAsString = "Center"
        UltraGridColumn7.CellAppearance = Appearance201
        UltraGridColumn7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance202.TextHAlignAsString = "Center"
        UltraGridColumn7.Header.Appearance = Appearance202
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.MinWidth = 120
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance203.TextHAlignAsString = "Center"
        UltraGridColumn8.CellAppearance = Appearance203
        UltraGridColumn8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance204.TextHAlignAsString = "Center"
        UltraGridColumn8.Header.Appearance = Appearance204
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance205.TextHAlignAsString = "Center"
        UltraGridColumn9.CellAppearance = Appearance205
        UltraGridColumn9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn9.DataType = GetType(Decimal)
        Appearance206.TextHAlignAsString = "Center"
        UltraGridColumn9.Header.Appearance = Appearance206
        UltraGridColumn9.Header.VisiblePosition = 9
        UltraGridColumn9.Hidden = True
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn10.Header.Caption = "Chancadora"
        UltraGridColumn10.Header.VisiblePosition = 5
        UltraGridColumn10.MinWidth = 180
        UltraGridColumn10.Width = 180
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance207.TextHAlignAsString = "Center"
        UltraGridColumn11.CellAppearance = Appearance207
        UltraGridColumn11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn11.DataType = GetType(Decimal)
        Appearance208.TextHAlignAsString = "Center"
        UltraGridColumn11.Header.Appearance = Appearance208
        UltraGridColumn11.Header.VisiblePosition = 11
        UltraGridColumn11.Hidden = True
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance209.TextHAlignAsString = "Center"
        UltraGridColumn12.CellAppearance = Appearance209
        UltraGridColumn12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn12.DataType = GetType(Decimal)
        Appearance210.TextHAlignAsString = "Center"
        UltraGridColumn12.Header.Appearance = Appearance210
        UltraGridColumn12.Header.VisiblePosition = 12
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance211.TextHAlignAsString = "Center"
        UltraGridColumn13.CellAppearance = Appearance211
        UltraGridColumn13.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn13.DataType = GetType(Short)
        Appearance212.TextHAlignAsString = "Center"
        UltraGridColumn13.Header.Appearance = Appearance212
        UltraGridColumn13.Header.Caption = "# Ope"
        UltraGridColumn13.Header.VisiblePosition = 13
        UltraGridColumn13.MaxWidth = 50
        UltraGridColumn13.MinWidth = 50
        UltraGridColumn13.Width = 50
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance213.TextHAlignAsString = "Center"
        UltraGridColumn14.CellAppearance = Appearance213
        UltraGridColumn14.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn14.DataType = GetType(Decimal)
        Appearance214.TextHAlignAsString = "Center"
        UltraGridColumn14.Header.Appearance = Appearance214
        UltraGridColumn14.Header.VisiblePosition = 15
        UltraGridColumn14.Hidden = True
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance215.TextHAlignAsString = "Center"
        UltraGridColumn15.CellAppearance = Appearance215
        UltraGridColumn15.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn15.DataType = GetType(Decimal)
        Appearance216.TextHAlignAsString = "Center"
        UltraGridColumn15.Header.Appearance = Appearance216
        UltraGridColumn15.Header.VisiblePosition = 16
        UltraGridColumn15.Hidden = True
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance217.TextHAlignAsString = "Center"
        UltraGridColumn16.CellAppearance = Appearance217
        UltraGridColumn16.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn16.DataType = GetType(Decimal)
        Appearance218.TextHAlignAsString = "Center"
        UltraGridColumn16.Header.Appearance = Appearance218
        UltraGridColumn16.Header.VisiblePosition = 17
        UltraGridColumn16.Hidden = True
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance219.TextHAlignAsString = "Center"
        UltraGridColumn17.CellAppearance = Appearance219
        UltraGridColumn17.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn17.DataType = GetType(Decimal)
        Appearance220.TextHAlignAsString = "Center"
        UltraGridColumn17.Header.Appearance = Appearance220
        UltraGridColumn17.Header.VisiblePosition = 18
        UltraGridColumn17.Hidden = True
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance221.TextHAlignAsString = "Center"
        UltraGridColumn18.CellAppearance = Appearance221
        UltraGridColumn18.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn18.DataType = GetType(Decimal)
        Appearance222.TextHAlignAsString = "Center"
        UltraGridColumn18.Header.Appearance = Appearance222
        UltraGridColumn18.Header.VisiblePosition = 19
        UltraGridColumn18.Hidden = True
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance223.TextHAlignAsString = "Center"
        UltraGridColumn19.CellAppearance = Appearance223
        UltraGridColumn19.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn19.DataType = GetType(Decimal)
        UltraGridColumn19.Format = "c2"
        Appearance224.TextHAlignAsString = "Center"
        UltraGridColumn19.Header.Appearance = Appearance224
        UltraGridColumn19.Header.VisiblePosition = 20
        UltraGridColumn19.MaxWidth = 80
        UltraGridColumn19.MinWidth = 80
        UltraGridColumn19.Width = 80
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance225.TextHAlignAsString = "Center"
        UltraGridColumn20.CellAppearance = Appearance225
        UltraGridColumn20.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn20.DataType = GetType(Decimal)
        UltraGridColumn20.Format = "c2"
        Appearance226.TextHAlignAsString = "Center"
        UltraGridColumn20.Header.Appearance = Appearance226
        UltraGridColumn20.Header.VisiblePosition = 22
        UltraGridColumn20.MaxWidth = 80
        UltraGridColumn20.MinWidth = 80
        UltraGridColumn20.Width = 80
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance227.TextHAlignAsString = "Center"
        UltraGridColumn21.CellAppearance = Appearance227
        UltraGridColumn21.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn21.DataType = GetType(Decimal)
        Appearance228.TextHAlignAsString = "Center"
        UltraGridColumn21.Header.Appearance = Appearance228
        UltraGridColumn21.Header.VisiblePosition = 23
        UltraGridColumn21.Hidden = True
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance229.TextHAlignAsString = "Center"
        UltraGridColumn22.CellAppearance = Appearance229
        UltraGridColumn22.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn22.DataType = GetType(Decimal)
        UltraGridColumn22.Format = "n3"
        Appearance230.TextHAlignAsString = "Center"
        UltraGridColumn22.Header.Appearance = Appearance230
        UltraGridColumn22.Header.Caption = "Cant. (Ton)"
        UltraGridColumn22.Header.VisiblePosition = 21
        UltraGridColumn22.MaskInput = ""
        UltraGridColumn22.MaxWidth = 80
        UltraGridColumn22.MinWidth = 80
        UltraGridColumn22.Width = 80
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance231.BackColor = System.Drawing.SystemColors.Highlight
        Appearance231.ForeColor = System.Drawing.Color.White
        Appearance231.TextHAlignAsString = "Center"
        UltraGridColumn23.CellAppearance = Appearance231
        UltraGridColumn23.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn23.Format = "##0 ""%"""
        Appearance232.TextHAlignAsString = "Center"
        UltraGridColumn23.Header.Appearance = Appearance232
        UltraGridColumn23.Header.VisiblePosition = 24
        UltraGridColumn23.MaxWidth = 100
        UltraGridColumn23.MinWidth = 100
        UltraGridColumn23.NullText = "0"
        UltraGridColumn23.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        UltraGridColumn23.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegative
        UltraGridColumn23.Width = 100
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn24.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn24.Header.Caption = "Turno"
        UltraGridColumn24.Header.VisiblePosition = 10
        UltraGridColumn24.MaxWidth = 130
        UltraGridColumn24.MinWidth = 130
        UltraGridColumn24.Width = 130
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance175.TextHAlignAsString = "Right"
        UltraGridColumn25.CellAppearance = Appearance175
        UltraGridColumn25.DataType = GetType(Double)
        UltraGridColumn25.Format = "n2"
        UltraGridColumn25.Header.VisiblePosition = 14
        UltraGridColumn25.MaskInput = ""
        UltraGridColumn25.MaxWidth = 40
        UltraGridColumn25.MinWidth = 40
        UltraGridColumn25.Width = 40
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25})
        UltraGridBand1.SummaryFooterCaption = ""
        Me.Grid3.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.Grid3.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid3.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.Grid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.Grid3.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance233.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance233.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance233.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance233.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid3.DisplayLayout.GroupByBox.Appearance = Appearance233
        Appearance234.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid3.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance234
        Me.Grid3.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid3.DisplayLayout.GroupByBox.Hidden = True
        Appearance235.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance235.BackColor2 = System.Drawing.SystemColors.Control
        Appearance235.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance235.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid3.DisplayLayout.GroupByBox.PromptAppearance = Appearance235
        Me.Grid3.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid3.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid3.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid3.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid3.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid3.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance236.BackColor = System.Drawing.SystemColors.Window
        Me.Grid3.DisplayLayout.Override.CardAreaAppearance = Appearance236
        Appearance237.BorderColor = System.Drawing.Color.Silver
        Appearance237.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid3.DisplayLayout.Override.CellAppearance = Appearance237
        Me.Grid3.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid3.DisplayLayout.Override.CellPadding = 0
        Me.Grid3.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance238.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grid3.DisplayLayout.Override.FilterRowAppearance = Appearance238
        Me.Grid3.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid3.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid3.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance239.BackColor = System.Drawing.SystemColors.Control
        Appearance239.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance239.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance239.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance239.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid3.DisplayLayout.Override.GroupByRowAppearance = Appearance239
        Appearance240.FontData.Name = "Arial Narrow"
        Appearance240.FontData.SizeInPoints = 10.0!
        Appearance240.TextHAlignAsString = "Left"
        Me.Grid3.DisplayLayout.Override.HeaderAppearance = Appearance240
        Me.Grid3.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.[Select]
        Me.Grid3.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid3.DisplayLayout.Override.MinRowHeight = 24
        Appearance241.BackColor = System.Drawing.SystemColors.Window
        Appearance241.BorderColor = System.Drawing.Color.Silver
        Appearance241.TextVAlignAsString = "Middle"
        Me.Grid3.DisplayLayout.Override.RowAppearance = Appearance241
        Me.Grid3.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid3.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid3.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance242.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid3.DisplayLayout.Override.TemplateAddRowAppearance = Appearance242
        Me.Grid3.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid3.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid3.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid3.Location = New System.Drawing.Point(0, 25)
        Me.Grid3.Name = "Grid3"
        Me.Grid3.Size = New System.Drawing.Size(676, 166)
        Me.Grid3.TabIndex = 132
        Me.Grid3.Text = "UltraGrid1"
        '
        'Tool1
        '
        Me.Tool1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator3, Me.Btn2, Me.ToolStripSeparator1, Me.Btn3, Me.ToolStripSeparator4, Me.Btn6, Me.ToolStripSeparator12})
        Me.Tool1.Location = New System.Drawing.Point(0, 0)
        Me.Tool1.Name = "Tool1"
        Me.Tool1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Tool1.Size = New System.Drawing.Size(676, 25)
        Me.Tool1.TabIndex = 129
        Me.Tool1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(25, 22)
        Me.ToolStripLabel1.Text = "      "
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'Btn2
        '
        Me.Btn2.Enabled = False
        Me.Btn2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn2.Image = CType(resources.GetObject("Btn2.Image"), System.Drawing.Image)
        Me.Btn2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn2.Name = "Btn2"
        Me.Btn2.Size = New System.Drawing.Size(76, 22)
        Me.Btn2.Text = "&AGREGAR"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Btn3
        '
        Me.Btn3.Enabled = False
        Me.Btn3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn3.Image = CType(resources.GetObject("Btn3.Image"), System.Drawing.Image)
        Me.Btn3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn3.Name = "Btn3"
        Me.Btn3.Size = New System.Drawing.Size(67, 22)
        Me.Btn3.Text = "&QUITAR"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'Btn6
        '
        Me.Btn6.Enabled = False
        Me.Btn6.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn6.Image = CType(resources.GetObject("Btn6.Image"), System.Drawing.Image)
        Me.Btn6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn6.Name = "Btn6"
        Me.Btn6.Size = New System.Drawing.Size(69, 22)
        Me.Btn6.Text = "&LIMPIAR"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.Grid4)
        Me.UltraTabPageControl4.Controls.Add(Me.Tool2)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(676, 191)
        '
        'Grid4
        '
        Me.Grid4.CalcManager = Me.Clm1
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid4.DisplayLayout.Appearance = Appearance49
        Me.Grid4.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance142.TextHAlignAsString = "Center"
        UltraGridColumn26.CellAppearance = Appearance142
        UltraGridColumn26.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance52.Image = CType(resources.GetObject("Appearance52.Image"), Object)
        Appearance52.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance52.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance52.TextHAlignAsString = "Center"
        UltraGridColumn26.Header.Appearance = Appearance52
        UltraGridColumn26.Header.Caption = ""
        UltraGridColumn26.Header.VisiblePosition = 0
        UltraGridColumn26.Hidden = True
        UltraGridColumn26.MaxWidth = 25
        UltraGridColumn26.MinWidth = 25
        UltraGridColumn26.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn26.Width = 25
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance508.TextHAlignAsString = "Center"
        UltraGridColumn27.CellAppearance = Appearance508
        UltraGridColumn27.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance509.TextHAlignAsString = "Center"
        UltraGridColumn27.Header.Appearance = Appearance509
        UltraGridColumn27.Header.VisiblePosition = 1
        UltraGridColumn27.Hidden = True
        UltraGridColumn27.Width = 120
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance143.TextHAlignAsString = "Center"
        UltraGridColumn28.CellAppearance = Appearance143
        UltraGridColumn28.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance105.TextHAlignAsString = "Center"
        UltraGridColumn28.Header.Appearance = Appearance105
        UltraGridColumn28.Header.Caption = "Lote"
        UltraGridColumn28.Header.VisiblePosition = 2
        UltraGridColumn28.MaxWidth = 170
        UltraGridColumn28.MinWidth = 170
        UltraGridColumn28.Width = 170
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance144.TextHAlignAsString = "Center"
        UltraGridColumn29.CellAppearance = Appearance144
        UltraGridColumn29.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance108.TextHAlignAsString = "Center"
        UltraGridColumn29.Header.Appearance = Appearance108
        UltraGridColumn29.Header.VisiblePosition = 3
        UltraGridColumn29.Hidden = True
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance145.TextHAlignAsString = "Center"
        UltraGridColumn30.CellAppearance = Appearance145
        UltraGridColumn30.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance109.TextHAlignAsString = "Center"
        UltraGridColumn30.Header.Appearance = Appearance109
        UltraGridColumn30.Header.VisiblePosition = 4
        UltraGridColumn30.Hidden = True
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance146.TextHAlignAsString = "Center"
        UltraGridColumn31.CellAppearance = Appearance146
        UltraGridColumn31.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn31.DataType = GetType(Date)
        Appearance110.TextHAlignAsString = "Center"
        UltraGridColumn31.Header.Appearance = Appearance110
        UltraGridColumn31.Header.VisiblePosition = 6
        UltraGridColumn31.MaxWidth = 70
        UltraGridColumn31.MinWidth = 70
        UltraGridColumn31.Width = 70
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance148.TextHAlignAsString = "Center"
        UltraGridColumn32.CellAppearance = Appearance148
        UltraGridColumn32.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance111.TextHAlignAsString = "Center"
        UltraGridColumn32.Header.Appearance = Appearance111
        UltraGridColumn32.Header.VisiblePosition = 7
        UltraGridColumn32.Hidden = True
        UltraGridColumn32.MinWidth = 120
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance149.TextHAlignAsString = "Center"
        UltraGridColumn33.CellAppearance = Appearance149
        UltraGridColumn33.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance112.TextHAlignAsString = "Center"
        UltraGridColumn33.Header.Appearance = Appearance112
        UltraGridColumn33.Header.VisiblePosition = 8
        UltraGridColumn33.Hidden = True
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance150.TextHAlignAsString = "Center"
        UltraGridColumn34.CellAppearance = Appearance150
        UltraGridColumn34.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn34.DataType = GetType(Decimal)
        Appearance113.TextHAlignAsString = "Center"
        UltraGridColumn34.Header.Appearance = Appearance113
        UltraGridColumn34.Header.VisiblePosition = 9
        UltraGridColumn34.Hidden = True
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn35.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn35.Header.Caption = "Molino"
        UltraGridColumn35.Header.VisiblePosition = 5
        UltraGridColumn35.MinWidth = 180
        UltraGridColumn35.Width = 180
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance152.TextHAlignAsString = "Center"
        UltraGridColumn36.CellAppearance = Appearance152
        UltraGridColumn36.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn36.DataType = GetType(Decimal)
        Appearance115.TextHAlignAsString = "Center"
        UltraGridColumn36.Header.Appearance = Appearance115
        UltraGridColumn36.Header.VisiblePosition = 11
        UltraGridColumn36.Hidden = True
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance153.TextHAlignAsString = "Center"
        UltraGridColumn37.CellAppearance = Appearance153
        UltraGridColumn37.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn37.DataType = GetType(Decimal)
        Appearance116.TextHAlignAsString = "Center"
        UltraGridColumn37.Header.Appearance = Appearance116
        UltraGridColumn37.Header.VisiblePosition = 12
        UltraGridColumn37.Hidden = True
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance154.TextHAlignAsString = "Center"
        UltraGridColumn38.CellAppearance = Appearance154
        UltraGridColumn38.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn38.DataType = GetType(Short)
        Appearance117.TextHAlignAsString = "Center"
        UltraGridColumn38.Header.Appearance = Appearance117
        UltraGridColumn38.Header.Caption = "# Ope"
        UltraGridColumn38.Header.VisiblePosition = 13
        UltraGridColumn38.MaxWidth = 50
        UltraGridColumn38.MinWidth = 50
        UltraGridColumn38.Width = 50
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance155.TextHAlignAsString = "Center"
        UltraGridColumn39.CellAppearance = Appearance155
        UltraGridColumn39.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn39.DataType = GetType(Decimal)
        Appearance118.TextHAlignAsString = "Center"
        UltraGridColumn39.Header.Appearance = Appearance118
        UltraGridColumn39.Header.VisiblePosition = 15
        UltraGridColumn39.Hidden = True
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance158.TextHAlignAsString = "Center"
        UltraGridColumn40.CellAppearance = Appearance158
        UltraGridColumn40.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn40.DataType = GetType(Decimal)
        Appearance119.TextHAlignAsString = "Center"
        UltraGridColumn40.Header.Appearance = Appearance119
        UltraGridColumn40.Header.VisiblePosition = 16
        UltraGridColumn40.Hidden = True
        UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance160.TextHAlignAsString = "Center"
        UltraGridColumn41.CellAppearance = Appearance160
        UltraGridColumn41.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn41.DataType = GetType(Decimal)
        Appearance120.TextHAlignAsString = "Center"
        UltraGridColumn41.Header.Appearance = Appearance120
        UltraGridColumn41.Header.VisiblePosition = 17
        UltraGridColumn41.Hidden = True
        UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance178.TextHAlignAsString = "Center"
        UltraGridColumn42.CellAppearance = Appearance178
        UltraGridColumn42.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn42.DataType = GetType(Decimal)
        Appearance121.TextHAlignAsString = "Center"
        UltraGridColumn42.Header.Appearance = Appearance121
        UltraGridColumn42.Header.VisiblePosition = 18
        UltraGridColumn42.Hidden = True
        UltraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance179.TextHAlignAsString = "Center"
        UltraGridColumn43.CellAppearance = Appearance179
        UltraGridColumn43.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn43.DataType = GetType(Decimal)
        Appearance122.TextHAlignAsString = "Center"
        UltraGridColumn43.Header.Appearance = Appearance122
        UltraGridColumn43.Header.VisiblePosition = 19
        UltraGridColumn43.Hidden = True
        UltraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance180.TextHAlignAsString = "Center"
        UltraGridColumn44.CellAppearance = Appearance180
        UltraGridColumn44.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn44.DataType = GetType(Decimal)
        UltraGridColumn44.Format = "c2"
        Appearance126.TextHAlignAsString = "Center"
        UltraGridColumn44.Header.Appearance = Appearance126
        UltraGridColumn44.Header.VisiblePosition = 20
        UltraGridColumn44.MaxWidth = 80
        UltraGridColumn44.MinWidth = 80
        UltraGridColumn44.Width = 80
        UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance181.TextHAlignAsString = "Center"
        UltraGridColumn45.CellAppearance = Appearance181
        UltraGridColumn45.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn45.DataType = GetType(Decimal)
        UltraGridColumn45.Format = "c2"
        Appearance127.TextHAlignAsString = "Center"
        UltraGridColumn45.Header.Appearance = Appearance127
        UltraGridColumn45.Header.VisiblePosition = 22
        UltraGridColumn45.MaxWidth = 80
        UltraGridColumn45.MinWidth = 80
        UltraGridColumn45.Width = 80
        UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance182.TextHAlignAsString = "Center"
        UltraGridColumn46.CellAppearance = Appearance182
        UltraGridColumn46.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn46.DataType = GetType(Decimal)
        Appearance128.TextHAlignAsString = "Center"
        UltraGridColumn46.Header.Appearance = Appearance128
        UltraGridColumn46.Header.VisiblePosition = 23
        UltraGridColumn46.Hidden = True
        UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance183.TextHAlignAsString = "Center"
        UltraGridColumn47.CellAppearance = Appearance183
        UltraGridColumn47.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn47.DataType = GetType(Decimal)
        UltraGridColumn47.Format = "n3"
        Appearance132.TextHAlignAsString = "Center"
        UltraGridColumn47.Header.Appearance = Appearance132
        UltraGridColumn47.Header.Caption = "Cant. (Ton)"
        UltraGridColumn47.Header.VisiblePosition = 21
        UltraGridColumn47.MaskInput = ""
        UltraGridColumn47.MaxWidth = 80
        UltraGridColumn47.MinWidth = 80
        UltraGridColumn47.Width = 80
        UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance184.BackColor = System.Drawing.SystemColors.Highlight
        Appearance184.ForeColor = System.Drawing.Color.White
        Appearance184.TextHAlignAsString = "Center"
        UltraGridColumn48.CellAppearance = Appearance184
        UltraGridColumn48.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn48.Format = "##0 ""%"""
        Appearance133.TextHAlignAsString = "Center"
        UltraGridColumn48.Header.Appearance = Appearance133
        UltraGridColumn48.Header.VisiblePosition = 24
        UltraGridColumn48.MaxWidth = 100
        UltraGridColumn48.MinWidth = 100
        UltraGridColumn48.NullText = "0"
        UltraGridColumn48.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        UltraGridColumn48.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegative
        UltraGridColumn48.Width = 100
        UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn49.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn49.Header.Caption = "Turno"
        UltraGridColumn49.Header.VisiblePosition = 10
        UltraGridColumn49.MaxWidth = 130
        UltraGridColumn49.MinWidth = 130
        UltraGridColumn49.Width = 130
        UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn50.DataType = GetType(Double)
        UltraGridColumn50.Format = "n2"
        UltraGridColumn50.Header.VisiblePosition = 14
        UltraGridColumn50.MaxWidth = 40
        UltraGridColumn50.MinWidth = 40
        UltraGridColumn50.Width = 40
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50})
        UltraGridBand2.SummaryFooterCaption = ""
        Me.Grid4.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.Grid4.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid4.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid4.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.Grid4.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.Grid4.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.Grid4.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance53.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance53.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance53.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid4.DisplayLayout.GroupByBox.Appearance = Appearance53
        Appearance54.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid4.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance54
        Me.Grid4.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid4.DisplayLayout.GroupByBox.Hidden = True
        Appearance55.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance55.BackColor2 = System.Drawing.SystemColors.Control
        Appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance55.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid4.DisplayLayout.GroupByBox.PromptAppearance = Appearance55
        Me.Grid4.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid4.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid4.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid4.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid4.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid4.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance58.BackColor = System.Drawing.SystemColors.Window
        Me.Grid4.DisplayLayout.Override.CardAreaAppearance = Appearance58
        Appearance59.BorderColor = System.Drawing.Color.Silver
        Appearance59.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid4.DisplayLayout.Override.CellAppearance = Appearance59
        Me.Grid4.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid4.DisplayLayout.Override.CellPadding = 0
        Me.Grid4.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance60.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grid4.DisplayLayout.Override.FilterRowAppearance = Appearance60
        Me.Grid4.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid4.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid4.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance61.BackColor = System.Drawing.SystemColors.Control
        Appearance61.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance61.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance61.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid4.DisplayLayout.Override.GroupByRowAppearance = Appearance61
        Appearance62.FontData.Name = "Arial Narrow"
        Appearance62.FontData.SizeInPoints = 10.0!
        Appearance62.TextHAlignAsString = "Left"
        Me.Grid4.DisplayLayout.Override.HeaderAppearance = Appearance62
        Me.Grid4.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.[Select]
        Me.Grid4.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid4.DisplayLayout.Override.MinRowHeight = 24
        Appearance63.BackColor = System.Drawing.SystemColors.Window
        Appearance63.BorderColor = System.Drawing.Color.Silver
        Appearance63.TextVAlignAsString = "Middle"
        Me.Grid4.DisplayLayout.Override.RowAppearance = Appearance63
        Me.Grid4.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid4.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid4.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance64.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid4.DisplayLayout.Override.TemplateAddRowAppearance = Appearance64
        Me.Grid4.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid4.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid4.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid4.Location = New System.Drawing.Point(0, 25)
        Me.Grid4.Name = "Grid4"
        Me.Grid4.Size = New System.Drawing.Size(676, 166)
        Me.Grid4.TabIndex = 133
        Me.Grid4.Text = "UltraGrid1"
        '
        'Tool2
        '
        Me.Tool2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.ToolStripSeparator2, Me.Btn4, Me.ToolStripSeparator9, Me.Btn5, Me.ToolStripSeparator10, Me.Btn7, Me.ToolStripSeparator11})
        Me.Tool2.Location = New System.Drawing.Point(0, 0)
        Me.Tool2.Name = "Tool2"
        Me.Tool2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Tool2.Size = New System.Drawing.Size(676, 25)
        Me.Tool2.TabIndex = 130
        Me.Tool2.Text = "ToolStrip2"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(25, 22)
        Me.ToolStripLabel2.Text = "      "
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Btn4
        '
        Me.Btn4.Enabled = False
        Me.Btn4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn4.Image = CType(resources.GetObject("Btn4.Image"), System.Drawing.Image)
        Me.Btn4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn4.Name = "Btn4"
        Me.Btn4.Size = New System.Drawing.Size(76, 22)
        Me.Btn4.Text = "&AGREGAR"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'Btn5
        '
        Me.Btn5.Enabled = False
        Me.Btn5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn5.Image = CType(resources.GetObject("Btn5.Image"), System.Drawing.Image)
        Me.Btn5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn5.Name = "Btn5"
        Me.Btn5.Size = New System.Drawing.Size(67, 22)
        Me.Btn5.Text = "&QUITAR"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'Btn7
        '
        Me.Btn7.Enabled = False
        Me.Btn7.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Btn7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Btn7.Image = CType(resources.GetObject("Btn7.Image"), System.Drawing.Image)
        Me.Btn7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Btn7.Name = "Btn7"
        Me.Btn7.Size = New System.Drawing.Size(69, 22)
        Me.Btn7.Text = "&LIMPIAR"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraGroupBox3)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(709, 494)
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance156.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox3.ContentAreaAppearance = Appearance156
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel13)
        Me.UltraGroupBox3.Controls.Add(Me.Cbo2)
        Me.UltraGroupBox3.Controls.Add(Me.Num7)
        Me.UltraGroupBox3.Controls.Add(Me.Chk1)
        Me.UltraGroupBox3.Controls.Add(Me.Num6)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel12)
        Me.UltraGroupBox3.Controls.Add(Me.Num5)
        Me.UltraGroupBox3.Controls.Add(Me.Num3)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel10)
        Me.UltraGroupBox3.Controls.Add(Me.Num4)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBox3.Controls.Add(Me.Num2)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel4)
        Me.UltraGroupBox3.Controls.Add(Me.Lbl1)
        Me.UltraGroupBox3.Controls.Add(Me.Cbo1)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel3)
        Me.UltraGroupBox3.Controls.Add(Me.Btn1)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel5)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel2)
        Me.UltraGroupBox3.Controls.Add(Me.Txt4)
        Me.UltraGroupBox3.Controls.Add(Me.Num1)
        Me.UltraGroupBox3.Controls.Add(Me.Dt3)
        Me.UltraGroupBox3.Controls.Add(Me.Dt2)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel1)
        Me.UltraGroupBox3.Controls.Add(Me.Dt1)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel7)
        Me.UltraGroupBox3.Controls.Add(Me.Txt3)
        Me.UltraGroupBox3.Controls.Add(Me.Txt2)
        Me.UltraGroupBox3.Controls.Add(Me.Txt1)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel8)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel9)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel11)
        Appearance162.FontData.BoldAsString = "True"
        Appearance162.FontData.Name = "Arial Narrow"
        Appearance162.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox3.HeaderAppearance = Appearance162
        Me.UltraGroupBox3.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox3.Location = New System.Drawing.Point(13, 77)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(687, 352)
        Me.UltraGroupBox3.TabIndex = 1
        Me.UltraGroupBox3.Text = "DATOS GENERALES"
        Me.UltraGroupBox3.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'UltraLabel13
        '
        Appearance503.BackColor = System.Drawing.Color.Transparent
        Appearance503.TextHAlignAsString = "Right"
        Me.UltraLabel13.Appearance = Appearance503
        Me.UltraLabel13.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel13.Location = New System.Drawing.Point(49, 317)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(103, 21)
        Me.UltraLabel13.TabIndex = 107
        Me.UltraLabel13.Text = "Estado"
        '
        'Cbo2
        '
        Me.Cbo2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cbo2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "P"
        ValueListItem1.DisplayText = "EN PROCESO"
        ValueListItem2.DataValue = "R"
        ValueListItem2.DisplayText = "RECIRCULADO"
        ValueListItem3.DataValue = "C"
        ValueListItem3.DisplayText = "CERRADA"
        Me.Cbo2.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3})
        Me.Cbo2.Location = New System.Drawing.Point(156, 317)
        Me.Cbo2.Name = "Cbo2"
        Me.Cbo2.Size = New System.Drawing.Size(144, 21)
        Me.Cbo2.TabIndex = 106
        '
        'Chk1
        '
        Appearance266.FontData.BoldAsString = "True"
        Appearance266.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Chk1.Appearance = Appearance266
        Me.Chk1.BackColor = System.Drawing.Color.Transparent
        Me.Chk1.BackColorInternal = System.Drawing.Color.Transparent
        Me.Chk1.Location = New System.Drawing.Point(252, 129)
        Me.Chk1.Name = "Chk1"
        Me.Chk1.Size = New System.Drawing.Size(284, 20)
        Me.Chk1.TabIndex = 104
        Me.Chk1.Text = "Utilizar en la Formulación Producto Recirculado"
        '
        'UltraLabel12
        '
        Appearance185.BackColor = System.Drawing.Color.Transparent
        Appearance185.TextHAlignAsString = "Right"
        Me.UltraLabel12.Appearance = Appearance185
        Me.UltraLabel12.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel12.Location = New System.Drawing.Point(51, 184)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(103, 21)
        Me.UltraLabel12.TabIndex = 102
        Me.UltraLabel12.Text = "Chancadora (Ton):"
        '
        'UltraLabel10
        '
        Appearance507.BackColor = System.Drawing.Color.Transparent
        Appearance507.TextHAlignAsString = "Right"
        Me.UltraLabel10.Appearance = Appearance507
        Me.UltraLabel10.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel10.Location = New System.Drawing.Point(430, 157)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(97, 21)
        Me.UltraLabel10.TabIndex = 99
        Me.UltraLabel10.Text = "Req. (Ton) :"
        '
        'UltraLabel6
        '
        Appearance326.BackColor = System.Drawing.Color.Transparent
        Appearance326.TextHAlignAsString = "Right"
        Me.UltraLabel6.Appearance = Appearance326
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel6.Location = New System.Drawing.Point(436, 180)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(94, 21)
        Me.UltraLabel6.TabIndex = 97
        Me.UltraLabel6.Text = "Molino (Ton):"
        '
        'UltraLabel4
        '
        Appearance77.BackColor = System.Drawing.Color.Transparent
        Appearance77.TextHAlignAsString = "Right"
        Me.UltraLabel4.Appearance = Appearance77
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel4.Location = New System.Drawing.Point(84, 211)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(70, 21)
        Me.UltraLabel4.TabIndex = 95
        Me.UltraLabel4.Text = "Porcentaje :"
        '
        'Lbl1
        '
        Appearance500.BackColor = System.Drawing.Color.Transparent
        Appearance500.FontData.BoldAsString = "True"
        Appearance500.FontData.ItalicAsString = "True"
        Appearance500.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Lbl1.Appearance = Appearance500
        Me.Lbl1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.Lbl1.Location = New System.Drawing.Point(159, 80)
        Me.Lbl1.Name = "Lbl1"
        Me.Lbl1.Size = New System.Drawing.Size(198, 21)
        Me.Lbl1.TabIndex = 94
        '
        'Cbo1
        '
        Appearance114.TextHAlignAsString = "Center"
        Me.Cbo1.Appearance = Appearance114
        Me.Cbo1.AutoSize = False
        Me.Cbo1.CalcManager = Me.Clm1
        Me.Cbo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance38.BackColor = System.Drawing.SystemColors.Window
        Appearance38.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Cbo1.DisplayLayout.Appearance = Appearance38
        Me.Cbo1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Cbo1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance39.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance39.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance39.BorderColor = System.Drawing.SystemColors.Window
        Me.Cbo1.DisplayLayout.GroupByBox.Appearance = Appearance39
        Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Cbo1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance40
        Me.Cbo1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance41.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance41.BackColor2 = System.Drawing.SystemColors.Control
        Appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance41.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Cbo1.DisplayLayout.GroupByBox.PromptAppearance = Appearance41
        Me.Cbo1.DisplayLayout.MaxColScrollRegions = 1
        Me.Cbo1.DisplayLayout.MaxRowScrollRegions = 1
        Appearance42.BackColor = System.Drawing.SystemColors.Window
        Appearance42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cbo1.DisplayLayout.Override.ActiveCellAppearance = Appearance42
        Appearance43.BackColor = System.Drawing.SystemColors.Highlight
        Appearance43.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Cbo1.DisplayLayout.Override.ActiveRowAppearance = Appearance43
        Me.Cbo1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Cbo1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance44.BackColor = System.Drawing.SystemColors.Window
        Me.Cbo1.DisplayLayout.Override.CardAreaAppearance = Appearance44
        Appearance45.BorderColor = System.Drawing.Color.Silver
        Appearance45.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Cbo1.DisplayLayout.Override.CellAppearance = Appearance45
        Me.Cbo1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Cbo1.DisplayLayout.Override.CellPadding = 0
        Appearance46.BackColor = System.Drawing.SystemColors.Control
        Appearance46.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance46.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance46.BorderColor = System.Drawing.SystemColors.Window
        Me.Cbo1.DisplayLayout.Override.GroupByRowAppearance = Appearance46
        Appearance47.TextHAlignAsString = "Left"
        Me.Cbo1.DisplayLayout.Override.HeaderAppearance = Appearance47
        Me.Cbo1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.Cbo1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance48.BackColor = System.Drawing.SystemColors.Window
        Appearance48.BorderColor = System.Drawing.Color.Silver
        Me.Cbo1.DisplayLayout.Override.RowAppearance = Appearance48
        Me.Cbo1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance501.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Cbo1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance501
        Me.Cbo1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Cbo1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Cbo1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.Cbo1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cbo1.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.Cbo1.Location = New System.Drawing.Point(157, 130)
        Me.Cbo1.Name = "Cbo1"
        Me.Cbo1.ReadOnly = True
        Me.Cbo1.Size = New System.Drawing.Size(89, 21)
        Me.Cbo1.TabIndex = 93
        '
        'UltraLabel3
        '
        Appearance159.BackColor = System.Drawing.Color.Transparent
        Appearance159.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance159
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(49, 132)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(105, 21)
        Me.UltraLabel3.TabIndex = 92
        Me.UltraLabel3.Text = "* Cod. Enlace :"
        '
        'Btn1
        '
        Appearance502.Image = "BINOCULAR.ICO"
        Appearance502.ImageHAlign = Infragistics.Win.HAlign.Center
        Me.Btn1.Appearance = Appearance502
        Me.Btn1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3D
        Me.Btn1.ImageList = Me.Iml1
        Me.Btn1.Location = New System.Drawing.Point(252, 29)
        Me.Btn1.Name = "Btn1"
        Me.Btn1.Size = New System.Drawing.Size(50, 25)
        Me.Btn1.TabIndex = 91
        '
        'Iml1
        '
        Me.Iml1.ImageStream = CType(resources.GetObject("Iml1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Iml1.TransparentColor = System.Drawing.Color.Transparent
        Me.Iml1.Images.SetKeyName(0, "BINOCULAR.ICO")
        Me.Iml1.Images.SetKeyName(1, "Add.png")
        Me.Iml1.Images.SetKeyName(2, "Delete1.png")
        '
        'UltraLabel5
        '
        Appearance102.BackColor = System.Drawing.Color.Transparent
        Appearance102.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance102
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel5.Location = New System.Drawing.Point(55, 263)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(100, 21)
        Me.UltraLabel5.TabIndex = 89
        Me.UltraLabel5.Text = "Especificaciones :"
        '
        'UltraLabel2
        '
        Appearance100.BackColor = System.Drawing.Color.Transparent
        Appearance100.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance100
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(2, 238)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(152, 21)
        Me.UltraLabel2.TabIndex = 88
        Me.UltraLabel2.Text = "* Fec. de Ingreso al Almacen :"
        '
        'Txt4
        '
        Me.Txt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt4.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt4.Location = New System.Drawing.Point(156, 262)
        Me.Txt4.Multiline = True
        Me.Txt4.Name = "Txt4"
        Me.Txt4.ReadOnly = True
        Me.Txt4.Size = New System.Drawing.Size(465, 49)
        Me.Txt4.TabIndex = 86
        Me.Txt4.Tag = ""
        '
        'Dt3
        '
        Appearance273.TextHAlignAsString = "Center"
        Me.Dt3.Appearance = Appearance273
        Me.Dt3.DateTime = New Date(2012, 5, 4, 0, 0, 0, 0)
        Me.Dt3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Dt3.Location = New System.Drawing.Point(157, 236)
        Me.Dt3.Name = "Dt3"
        Me.Dt3.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Dt3.ReadOnly = True
        Me.Dt3.Size = New System.Drawing.Size(89, 21)
        Me.Dt3.TabIndex = 83
        Me.Dt3.Value = New Date(2012, 5, 4, 0, 0, 0, 0)
        '
        'Dt2
        '
        Me.Dt2.DateTime = New Date(2012, 5, 4, 0, 0, 0, 0)
        Me.Dt2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Dt2.Location = New System.Drawing.Point(532, 55)
        Me.Dt2.Name = "Dt2"
        Me.Dt2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Dt2.ReadOnly = True
        Me.Dt2.Size = New System.Drawing.Size(89, 21)
        Me.Dt2.TabIndex = 11
        Me.Dt2.Value = New Date(2012, 5, 4, 0, 0, 0, 0)
        '
        'UltraLabel1
        '
        Appearance157.BackColor = System.Drawing.Color.Transparent
        Appearance157.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance157
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(365, 55)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(161, 21)
        Me.UltraLabel1.TabIndex = 10
        Me.UltraLabel1.Text = "Fecha de Actualización :"
        '
        'Dt1
        '
        Appearance272.TextHAlignAsString = "Center"
        Me.Dt1.Appearance = Appearance272
        Me.Dt1.DateTime = New Date(2012, 5, 4, 0, 0, 0, 0)
        Me.Dt1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Dt1.Location = New System.Drawing.Point(157, 55)
        Me.Dt1.Name = "Dt1"
        Me.Dt1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Dt1.ReadOnly = True
        Me.Dt1.Size = New System.Drawing.Size(89, 21)
        Me.Dt1.TabIndex = 9
        Me.Dt1.Value = New Date(2012, 5, 4, 0, 0, 0, 0)
        '
        'UltraLabel7
        '
        Appearance504.BackColor = System.Drawing.Color.Transparent
        Appearance504.TextHAlignAsString = "Right"
        Me.UltraLabel7.Appearance = Appearance504
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel7.Location = New System.Drawing.Point(50, 55)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(104, 21)
        Me.UltraLabel7.TabIndex = 8
        Me.UltraLabel7.Text = "Fecha de Emisión :"
        '
        'Txt3
        '
        Appearance505.Image = "email.png"
        Appearance505.ImageHAlign = Infragistics.Win.HAlign.Right
        Me.Txt3.Appearance = Appearance505
        Me.Txt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt3.Location = New System.Drawing.Point(252, 105)
        Me.Txt3.MaxLength = 60
        Me.Txt3.Name = "Txt3"
        Me.Txt3.ReadOnly = True
        Me.Txt3.Size = New System.Drawing.Size(369, 21)
        Me.Txt3.TabIndex = 7
        '
        'Txt2
        '
        Appearance506.Image = "Crystal_Clear_kdm_user_male[1].png"
        Appearance506.TextHAlignAsString = "Center"
        Me.Txt2.Appearance = Appearance506
        Me.Txt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt2.Location = New System.Drawing.Point(157, 105)
        Me.Txt2.MaxLength = 60
        Me.Txt2.Name = "Txt2"
        Me.Txt2.ReadOnly = True
        Me.Txt2.Size = New System.Drawing.Size(89, 21)
        Me.Txt2.TabIndex = 6
        '
        'Txt1
        '
        Appearance141.TextHAlignAsString = "Center"
        Me.Txt1.Appearance = Appearance141
        Me.Txt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Txt1.Location = New System.Drawing.Point(157, 30)
        Me.Txt1.MaxLength = 10
        Me.Txt1.Name = "Txt1"
        Me.Txt1.ReadOnly = True
        Me.Txt1.Size = New System.Drawing.Size(89, 21)
        Me.Txt1.TabIndex = 4
        '
        'UltraLabel8
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.TextHAlignAsString = "Right"
        Me.UltraLabel8.Appearance = Appearance2
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel8.Location = New System.Drawing.Point(13, 157)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(141, 21)
        Me.UltraLabel8.TabIndex = 3
        Me.UltraLabel8.Text = "* Cant. a Producir (Ton) :"
        '
        'UltraLabel9
        '
        Appearance81.BackColor = System.Drawing.Color.Transparent
        Appearance81.TextHAlignAsString = "Right"
        Me.UltraLabel9.Appearance = Appearance81
        Me.UltraLabel9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel9.Location = New System.Drawing.Point(49, 107)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(105, 21)
        Me.UltraLabel9.TabIndex = 2
        Me.UltraLabel9.Text = "* Producto Terminado :"
        '
        'UltraLabel11
        '
        Appearance161.BackColor = System.Drawing.Color.Transparent
        Appearance161.TextHAlignAsString = "Right"
        Me.UltraLabel11.Appearance = Appearance161
        Me.UltraLabel11.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel11.Location = New System.Drawing.Point(51, 30)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(104, 21)
        Me.UltraLabel11.TabIndex = 0
        Me.UltraLabel11.Text = "* Nro Documento :"
        '
        'UltraTabPageControl8
        '
        Me.UltraTabPageControl8.Controls.Add(Me.Tab3)
        Me.UltraTabPageControl8.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl8.Name = "UltraTabPageControl8"
        Me.UltraTabPageControl8.Size = New System.Drawing.Size(709, 494)
        '
        'Tab3
        '
        Me.Tab3.Controls.Add(Me.UltraTabSharedControlsPage4)
        Me.Tab3.Controls.Add(Me.UltraTabPageControl7)
        Me.Tab3.Controls.Add(Me.UltraTabPageControl9)
        Me.Tab3.Controls.Add(Me.UltraTabPageControl10)
        Me.Tab3.Controls.Add(Me.UltraTabPageControl11)
        Me.Tab3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab3.Location = New System.Drawing.Point(0, 0)
        Me.Tab3.Name = "Tab3"
        Me.Tab3.SharedControlsPage = Me.UltraTabSharedControlsPage4
        Me.Tab3.Size = New System.Drawing.Size(709, 494)
        Me.Tab3.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Appearance91.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab3.TabHeaderAreaAppearance = Appearance91
        Me.Tab3.TabIndex = 97
        Me.Tab3.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance88.FontData.BoldAsString = "True"
        Appearance88.FontData.Name = "Arial Narrow"
        Appearance88.FontData.SizeInPoints = 14.0!
        UltraTab5.ActiveAppearance = Appearance88
        UltraTab5.Key = "T01"
        UltraTab5.TabPage = Me.UltraTabPageControl7
        UltraTab5.Text = " LISTADO DE RUMA (S)"
        Appearance89.FontData.BoldAsString = "True"
        Appearance89.FontData.Name = "Arial Narrow"
        Appearance89.FontData.SizeInPoints = 14.0!
        UltraTab6.ActiveAppearance = Appearance89
        UltraTab6.Key = "T02"
        UltraTab6.TabPage = Me.UltraTabPageControl9
        UltraTab6.Text = "LISTADO DE PROD. TERM (S)"
        Appearance90.FontData.BoldAsString = "True"
        Appearance90.FontData.Name = "Arial Narrow"
        Appearance90.FontData.SizeInPoints = 14.0!
        UltraTab7.ActiveAppearance = Appearance90
        UltraTab7.Key = "T03"
        UltraTab7.TabPage = Me.UltraTabPageControl10
        UltraTab7.Text = "LISTADO DE SUMINISTRO (S)"
        Appearance3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial Narrow"
        Appearance3.FontData.SizeInPoints = 14.0!
        UltraTab9.ActiveAppearance = Appearance3
        Appearance4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        UltraTab9.Appearance = Appearance4
        UltraTab9.Key = "T04"
        UltraTab9.TabPage = Me.UltraTabPageControl11
        UltraTab9.Text = "RECIRCULADO"
        UltraTab9.Visible = False
        Me.Tab3.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab5, UltraTab6, UltraTab7, UltraTab9})
        Me.Tab3.TabSize = New System.Drawing.Size(100, 30)
        Me.Tab3.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage4
        '
        Me.UltraTabSharedControlsPage4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage4.Name = "UltraTabSharedControlsPage4"
        Me.UltraTabSharedControlsPage4.Size = New System.Drawing.Size(705, 461)
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGroupBox4)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGroupBox1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(709, 494)
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance107.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox4.ContentAreaAppearance = Appearance107
        Me.UltraGroupBox4.Controls.Add(Me.Tab2)
        Appearance106.FontData.BoldAsString = "True"
        Appearance106.FontData.Name = "Arial Narrow"
        Appearance106.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox4.HeaderAppearance = Appearance106
        Me.UltraGroupBox4.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox4.Location = New System.Drawing.Point(11, 186)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(686, 252)
        Me.UltraGroupBox4.TabIndex = 127
        Me.UltraGroupBox4.Text = "LISTADO DE UNIDADES"
        Me.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'Tab2
        '
        Appearance165.FontData.BoldAsString = "True"
        Appearance165.FontData.Name = "Arial Narrow"
        Appearance165.FontData.SizeInPoints = 16.0!
        Me.Tab2.ActiveTabAppearance = Appearance165
        Appearance166.FontData.Name = "Arial Narrow"
        Appearance166.FontData.SizeInPoints = 10.0!
        Me.Tab2.Appearance = Appearance166
        Me.Tab2.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.Tab2.Controls.Add(Me.UltraTabPageControl3)
        Me.Tab2.Controls.Add(Me.UltraTabPageControl4)
        Me.Tab2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab2.Location = New System.Drawing.Point(3, 23)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.Tab2.Size = New System.Drawing.Size(680, 226)
        Me.Tab2.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPage2003
        Appearance168.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab2.TabHeaderAreaAppearance = Appearance168
        Me.Tab2.TabIndex = 2
        Me.Tab2.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance124.Cursor = System.Windows.Forms.Cursors.Default
        Appearance124.FontData.BoldAsString = "True"
        Appearance124.FontData.Name = "Arial Narrow"
        Appearance124.FontData.SizeInPoints = 16.0!
        UltraTab1.ActiveAppearance = Appearance124
        Appearance167.FontData.Name = "Arial Narrow"
        Appearance167.FontData.SizeInPoints = 10.0!
        UltraTab1.Appearance = Appearance167
        UltraTab1.Key = "T01"
        UltraTab1.TabPage = Me.UltraTabPageControl3
        UltraTab1.Text = "CHANCADORA"
        Appearance125.Cursor = System.Windows.Forms.Cursors.Default
        Appearance125.FontData.BoldAsString = "True"
        Appearance125.FontData.Name = "Arial Narrow"
        Appearance125.FontData.SizeInPoints = 16.0!
        UltraTab2.ActiveAppearance = Appearance125
        Appearance169.FontData.Name = "Arial Narrow"
        Appearance169.FontData.SizeInPoints = 10.0!
        UltraTab2.Appearance = Appearance169
        UltraTab2.Key = "T02"
        UltraTab2.TabPage = Me.UltraTabPageControl4
        UltraTab2.Text = "MOLINO"
        Me.Tab2.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        Me.Tab2.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(676, 191)
        '
        'UltraGroupBox1
        '
        Me.UltraGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance36.BackColor = System.Drawing.Color.White
        Me.UltraGroupBox1.ContentAreaAppearance = Appearance36
        Me.UltraGroupBox1.Controls.Add(Me.Grid2)
        Appearance511.FontData.BoldAsString = "True"
        Appearance511.FontData.Name = "Arial Narrow"
        Appearance511.FontData.SizeInPoints = 10.0!
        Me.UltraGroupBox1.HeaderAppearance = Appearance511
        Me.UltraGroupBox1.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraGroupBox1.Location = New System.Drawing.Point(11, 9)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(689, 171)
        Me.UltraGroupBox1.TabIndex = 126
        Me.UltraGroupBox1.Text = "LISTADO DE ENVASE(S)"
        Me.UltraGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'Grid2
        '
        Me.Grid2.CalcManager = Me.Clm1
        Me.Grid2.DataSource = Me.Uds2
        Appearance510.BackColor = System.Drawing.SystemColors.Window
        Appearance510.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid2.DisplayLayout.Appearance = Appearance510
        Me.Grid2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance32.TextHAlignAsString = "Center"
        UltraGridColumn51.CellAppearance = Appearance32
        UltraGridColumn51.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance33.TextHAlignAsString = "Center"
        UltraGridColumn51.Header.Appearance = Appearance33
        UltraGridColumn51.Header.Caption = "Código"
        UltraGridColumn51.Header.VisiblePosition = 0
        UltraGridColumn51.MaxWidth = 85
        UltraGridColumn51.MinWidth = 85
        UltraGridColumn51.Width = 85
        UltraGridColumn52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn52.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn52.Header.Caption = "Descripción"
        UltraGridColumn52.Header.VisiblePosition = 1
        UltraGridColumn52.MinWidth = 300
        UltraGridColumn52.Width = 300
        UltraGridColumn53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn53.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance34.TextHAlignAsString = "Center"
        UltraGridColumn53.Header.Appearance = Appearance34
        UltraGridColumn53.Header.VisiblePosition = 4
        UltraGridColumn53.Hidden = True
        UltraGridColumn53.Width = 67
        UltraGridColumn54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn54.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn54.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance35.TextHAlignAsString = "Center"
        UltraGridColumn54.Header.Appearance = Appearance35
        UltraGridColumn54.Header.VisiblePosition = 7
        UltraGridColumn54.Hidden = True
        UltraGridColumn54.Width = 67
        UltraGridColumn55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance37.TextHAlignAsString = "Center"
        UltraGridColumn55.CellAppearance = Appearance37
        UltraGridColumn55.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn55.Format = "n2"
        Appearance50.TextHAlignAsString = "Center"
        UltraGridColumn55.Header.Appearance = Appearance50
        UltraGridColumn55.Header.VisiblePosition = 2
        UltraGridColumn55.MaxWidth = 85
        UltraGridColumn55.MinWidth = 85
        UltraGridColumn55.Width = 85
        UltraGridColumn56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance51.TextHAlignAsString = "Center"
        UltraGridColumn56.CellAppearance = Appearance51
        UltraGridColumn56.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn56.Format = "c"
        Appearance56.TextHAlignAsString = "Center"
        UltraGridColumn56.Header.Appearance = Appearance56
        UltraGridColumn56.Header.VisiblePosition = 3
        UltraGridColumn56.MaxWidth = 85
        UltraGridColumn56.MinWidth = 85
        UltraGridColumn56.Width = 85
        UltraGridColumn57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn57.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn57.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn57.Formula = "if( ISNUMBER([//CalsCantidad]) , [//CalsCantidad] , 0 )"
        Appearance57.TextHAlignAsString = "Center"
        UltraGridColumn57.Header.Appearance = Appearance57
        UltraGridColumn57.Header.VisiblePosition = 8
        UltraGridColumn57.Hidden = True
        UltraGridColumn57.Width = 78
        UltraGridColumn58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn58.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance65.TextHAlignAsString = "Center"
        UltraGridColumn58.CellAppearance = Appearance65
        UltraGridColumn58.Format = "###,##0"
        UltraGridColumn58.Formula = "if( [//clsSuministros] =1 , [CantidadMaxima] )"
        Appearance66.TextHAlignAsString = "Center"
        UltraGridColumn58.Header.Appearance = Appearance66
        UltraGridColumn58.Header.Caption = "Cantidad"
        UltraGridColumn58.Header.VisiblePosition = 5
        UltraGridColumn58.MaskInput = ""
        UltraGridColumn58.MaxWidth = 85
        UltraGridColumn58.MinWidth = 85
        UltraGridColumn58.NullText = "0"
        UltraGridColumn58.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        UltraGridColumn58.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.IntegerNonNegative
        UltraGridColumn58.Width = 85
        UltraGridColumn59.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn59.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance67.TextHAlignAsString = "Center"
        UltraGridColumn59.CellAppearance = Appearance67
        UltraGridColumn59.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn59.Format = "c"
        UltraGridColumn59.Formula = "[CantidadUnitaria] * [CostoUnitario]"
        Appearance68.TextHAlignAsString = "Center"
        UltraGridColumn59.Header.Appearance = Appearance68
        UltraGridColumn59.Header.VisiblePosition = 6
        UltraGridColumn59.MaxWidth = 85
        UltraGridColumn59.MinWidth = 85
        UltraGridColumn60.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn60.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn60.DataType = GetType(Decimal)
        UltraGridColumn60.Formula = "Int( [Cantidad]  * 1000 / [Peso] )"
        UltraGridColumn60.Header.VisiblePosition = 9
        UltraGridColumn60.Hidden = True
        UltraGridColumn60.Width = 8
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60})
        Appearance69.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer))
        Appearance69.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance69
        SummarySettings1.DisplayFormat = "Cant. Ing. :"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance70
        Appearance71.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer))
        Appearance71.TextHAlignAsString = "Right"
        SummarySettings2.Appearance = Appearance71
        SummarySettings2.DisplayFormat = "Total Maximo :"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance72
        Appearance73.BackColor = System.Drawing.Color.White
        Appearance73.TextHAlignAsString = "Center"
        SummarySettings3.Appearance = Appearance73
        SummarySettings3.DisplayFormat = "{0}"
        SummarySettings3.GroupBySummaryValueAppearance = Appearance74
        Appearance75.BackColor = System.Drawing.Color.White
        Appearance75.TextHAlignAsString = "Center"
        SummarySettings4.Appearance = Appearance75
        SummarySettings4.DisplayFormat = "{0}"
        SummarySettings4.GroupBySummaryValueAppearance = Appearance76
        Appearance78.BackColor = System.Drawing.Color.White
        Appearance78.TextHAlignAsString = "Center"
        SummarySettings5.Appearance = Appearance78
        SummarySettings5.DisplayFormat = "{0}"
        SummarySettings5.GroupBySummaryValueAppearance = Appearance79
        UltraGridBand3.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2, SummarySettings3, SummarySettings4, SummarySettings5})
        UltraGridBand3.SummaryFooterCaption = ""
        Me.Grid2.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.Grid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance129.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance129.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance129.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance129.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.GroupByBox.Appearance = Appearance129
        Appearance130.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid2.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance130
        Me.Grid2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid2.DisplayLayout.GroupByBox.Hidden = True
        Appearance131.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance131.BackColor2 = System.Drawing.SystemColors.Control
        Appearance131.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance131.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid2.DisplayLayout.GroupByBox.PromptAppearance = Appearance131
        Me.Grid2.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid2.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance134.BackColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.Override.CardAreaAppearance = Appearance134
        Appearance135.BorderColor = System.Drawing.Color.Silver
        Appearance135.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid2.DisplayLayout.Override.CellAppearance = Appearance135
        Me.Grid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid2.DisplayLayout.Override.CellPadding = 0
        Me.Grid2.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance136.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grid2.DisplayLayout.Override.FilterRowAppearance = Appearance136
        Me.Grid2.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid2.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid2.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance137.BackColor = System.Drawing.SystemColors.Control
        Appearance137.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance137.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance137.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance137.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid2.DisplayLayout.Override.GroupByRowAppearance = Appearance137
        Appearance138.FontData.Name = "Arial Narrow"
        Appearance138.FontData.SizeInPoints = 10.0!
        Appearance138.TextHAlignAsString = "Left"
        Me.Grid2.DisplayLayout.Override.HeaderAppearance = Appearance138
        Me.Grid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid2.DisplayLayout.Override.MinRowHeight = 24
        Appearance139.BackColor = System.Drawing.SystemColors.Window
        Appearance139.BorderColor = System.Drawing.Color.Silver
        Appearance139.TextVAlignAsString = "Middle"
        Me.Grid2.DisplayLayout.Override.RowAppearance = Appearance139
        Me.Grid2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid2.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid2.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance147.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid2.DisplayLayout.Override.TemplateAddRowAppearance = Appearance147
        Me.Grid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid2.Location = New System.Drawing.Point(3, 23)
        Me.Grid2.Name = "Grid2"
        Me.Grid2.Size = New System.Drawing.Size(683, 145)
        Me.Grid2.TabIndex = 127
        Me.Grid2.Text = "UltraGrid1"
        '
        'Uds2
        '
        UltraDataColumn5.DataType = GetType(Decimal)
        UltraDataColumn6.DataType = GetType(Decimal)
        UltraDataColumn7.DataType = GetType(Integer)
        UltraDataColumn8.DataType = GetType(Integer)
        Me.Uds2.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8})
        '
        'Uds1
        '
        UltraDataColumn29.DataType = GetType(Decimal)
        UltraDataColumn30.DataType = GetType(Decimal)
        UltraDataColumn31.DataType = GetType(Decimal)
        UltraDataColumn32.DataType = GetType(Decimal)
        UltraDataColumn33.DataType = GetType(Integer)
        UltraDataColumn34.DataType = GetType(Decimal)
        UltraDataColumn35.DataType = GetType(Decimal)
        Me.Uds1.Band.Columns.AddRange(New Object() {UltraDataColumn27, UltraDataColumn28, UltraDataColumn29, UltraDataColumn30, UltraDataColumn31, UltraDataColumn32, UltraDataColumn33, UltraDataColumn34, UltraDataColumn35})
        '
        'Tab1
        '
        Appearance247.FontData.BoldAsString = "True"
        Appearance247.FontData.Name = "Arial Narrow"
        Appearance247.FontData.SizeInPoints = 16.0!
        Me.Tab1.ActiveTabAppearance = Appearance247
        Appearance248.FontData.Name = "Arial Narrow"
        Appearance248.FontData.SizeInPoints = 10.0!
        Me.Tab1.Appearance = Appearance248
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl2)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl8)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(713, 532)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance164.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance164
        Me.Tab1.TabIndex = 1
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance24.Cursor = System.Windows.Forms.Cursors.Default
        Appearance24.FontData.BoldAsString = "True"
        Appearance24.FontData.Name = "Arial Narrow"
        Appearance24.FontData.SizeInPoints = 16.0!
        UltraTab3.ActiveAppearance = Appearance24
        Appearance140.FontData.Name = "Arial Narrow"
        Appearance140.FontData.SizeInPoints = 10.0!
        UltraTab3.Appearance = Appearance140
        UltraTab3.Key = "T01"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "DESCRIPCION"
        UltraTab8.Key = "T03"
        UltraTab8.TabPage = Me.UltraTabPageControl8
        UltraTab8.Text = "FORMULACIÓN"
        Appearance25.Cursor = System.Windows.Forms.Cursors.Default
        Appearance25.FontData.BoldAsString = "True"
        Appearance25.FontData.Name = "Arial Narrow"
        Appearance25.FontData.SizeInPoints = 16.0!
        UltraTab4.ActiveAppearance = Appearance25
        Appearance151.FontData.Name = "Arial Narrow"
        Appearance151.FontData.SizeInPoints = 10.0!
        UltraTab4.Appearance = Appearance151
        UltraTab4.Key = "T02"
        UltraTab4.TabPage = Me.UltraTabPageControl2
        UltraTab4.Text = "DETALLES"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3, UltraTab8, UltraTab4})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(709, 494)
        '
        'Ep1
        '
        Me.Ep1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep1.ContainerControl = Me
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(76, 22)
        Me.ToolStripButton1.Text = "AGREGAR"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(84, 22)
        Me.ToolStripButton2.Text = "MODIFICAR"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(75, 22)
        Me.ToolStripButton3.Text = "ELIMINAR"
        '
        'UdsSuministro
        '
        UltraDataColumn38.DataType = GetType(Decimal)
        UltraDataColumn39.DataType = GetType(Decimal)
        UltraDataColumn40.DataType = GetType(Decimal)
        UltraDataColumn41.DataType = GetType(Decimal)
        UltraDataColumn42.DataType = GetType(Decimal)
        UltraDataColumn43.DataType = GetType(Integer)
        UltraDataColumn44.DataType = GetType(Boolean)
        Me.UdsSuministro.Band.Columns.AddRange(New Object() {UltraDataColumn36, UltraDataColumn37, UltraDataColumn38, UltraDataColumn39, UltraDataColumn40, UltraDataColumn41, UltraDataColumn42, UltraDataColumn43, UltraDataColumn44})
        '
        'UltraTabSharedControlsPage3
        '
        Me.UltraTabSharedControlsPage3.Location = New System.Drawing.Point(1, 20)
        Me.UltraTabSharedControlsPage3.Name = "UltraTabSharedControlsPage3"
        Me.UltraTabSharedControlsPage3.Size = New System.Drawing.Size(196, 77)
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.Grid1)
        Me.UltraTabPageControl5.Controls.Add(Me.Navigator2)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(1, 22)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(644, 182)
        '
        'Grid1
        '
        Me.Grid1.CalcManager = Me.Clm1
        Appearance360.BackColor = System.Drawing.SystemColors.Window
        Appearance360.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid1.DisplayLayout.Appearance = Appearance360
        Me.Grid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn126.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn126.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn126.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance361.Image = CType(resources.GetObject("Appearance361.Image"), Object)
        Appearance361.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance361.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn126.Header.Appearance = Appearance361
        UltraGridColumn126.Header.Caption = ""
        UltraGridColumn126.Header.VisiblePosition = 0
        UltraGridColumn126.Hidden = True
        UltraGridColumn126.MaxWidth = 25
        UltraGridColumn126.MinWidth = 20
        UltraGridColumn126.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn126.Width = 20
        UltraGridColumn127.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn127.Header.VisiblePosition = 12
        UltraGridColumn128.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn128.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance362.TextHAlignAsString = "Center"
        UltraGridColumn128.CellAppearance = Appearance362
        UltraGridColumn128.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance363.TextHAlignAsString = "Center"
        UltraGridColumn128.Header.Appearance = Appearance363
        UltraGridColumn128.Header.Caption = "Código"
        UltraGridColumn128.Header.VisiblePosition = 1
        UltraGridColumn128.MinWidth = 80
        UltraGridColumn128.Width = 80
        UltraGridColumn129.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance364.TextHAlignAsString = "Center"
        UltraGridColumn129.Header.Appearance = Appearance364
        UltraGridColumn129.Header.Caption = "Ruma"
        UltraGridColumn129.Header.VisiblePosition = 2
        UltraGridColumn129.MinWidth = 150
        UltraGridColumn129.Width = 150
        UltraGridColumn130.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn130.DataType = GetType(Decimal)
        UltraGridColumn130.Format = "n4"
        UltraGridColumn130.Formula = "if ( isnumber( [//CalsCantidad] ), [//CalsCantidad] ,0)"
        Appearance365.TextHAlignAsString = "Center"
        UltraGridColumn130.Header.Appearance = Appearance365
        UltraGridColumn130.Header.VisiblePosition = 3
        UltraGridColumn130.Hidden = True
        UltraGridColumn130.MinWidth = 80
        UltraGridColumn130.Width = 80
        UltraGridColumn131.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn131.DataType = GetType(Decimal)
        UltraGridColumn131.Format = "n2"
        Appearance366.TextHAlignAsString = "Center"
        UltraGridColumn131.Header.Appearance = Appearance366
        UltraGridColumn131.Header.Caption = "Pje (%)"
        UltraGridColumn131.Header.VisiblePosition = 5
        UltraGridColumn131.MinWidth = 60
        UltraGridColumn131.Width = 60
        UltraGridColumn132.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn132.DataType = GetType(Decimal)
        UltraGridColumn132.Format = "n2"
        Appearance367.TextHAlignAsString = "Center"
        UltraGridColumn132.Header.Appearance = Appearance367
        UltraGridColumn132.Header.VisiblePosition = 6
        UltraGridColumn132.MinWidth = 60
        UltraGridColumn132.Width = 60
        UltraGridColumn133.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn133.DataType = GetType(Decimal)
        UltraGridColumn133.Format = "n2"
        Appearance368.TextHAlignAsString = "Center"
        UltraGridColumn133.Header.Appearance = Appearance368
        UltraGridColumn133.Header.VisiblePosition = 7
        UltraGridColumn133.MinWidth = 60
        UltraGridColumn133.Width = 60
        UltraGridColumn134.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn134.DataType = GetType(Decimal)
        UltraGridColumn134.Format = "n3"
        Appearance369.TextHAlignAsString = "Center"
        UltraGridColumn134.Header.Appearance = Appearance369
        UltraGridColumn134.Header.Caption = "Stock"
        UltraGridColumn134.Header.VisiblePosition = 8
        UltraGridColumn134.MinWidth = 80
        UltraGridColumn134.Width = 80
        UltraGridColumn135.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn135.DataType = GetType(Decimal)
        UltraGridColumn135.Format = "n3"
        UltraGridColumn135.Formula = "[Cantidad] * [Porcentaje] *0.01"
        Appearance370.TextHAlignAsString = "Center"
        UltraGridColumn135.Header.Appearance = Appearance370
        UltraGridColumn135.Header.Caption = "Cant. Ton"
        UltraGridColumn135.Header.VisiblePosition = 4
        UltraGridColumn135.MinWidth = 80
        UltraGridColumn135.Width = 80
        UltraGridColumn136.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn136.DataType = GetType(Decimal)
        UltraGridColumn136.Format = "n3"
        UltraGridColumn136.Formula = "(100+ [Humedad] + [Merma] )*0.01* [CantidadFraccionada]"
        Appearance371.TextHAlignAsString = "Center"
        UltraGridColumn136.Header.Appearance = Appearance371
        UltraGridColumn136.Header.Caption = "Cant. Req"
        UltraGridColumn136.Header.VisiblePosition = 9
        UltraGridColumn136.MinWidth = 80
        UltraGridColumn136.Width = 80
        UltraGridColumn137.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn137.DataType = GetType(Decimal)
        UltraGridColumn137.Format = "n4"
        UltraGridColumn137.Formula = "if (sum( [../band 1/cantidadxnecesaria] )=0,0,sum( [../band 1/subtotal] )/sum( [." & _
            "./band 1/cantidadxnecesaria] ))"
        Appearance372.TextHAlignAsString = "Center"
        UltraGridColumn137.Header.Appearance = Appearance372
        UltraGridColumn137.Header.VisiblePosition = 10
        UltraGridColumn137.MinWidth = 80
        UltraGridColumn137.Width = 80
        UltraGridColumn138.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn138.DataType = GetType(Decimal)
        UltraGridColumn138.Format = "n4"
        UltraGridColumn138.Formula = "SUM( [../band 1/subtotal] )"
        Appearance373.TextHAlignAsString = "Center"
        UltraGridColumn138.Header.Appearance = Appearance373
        UltraGridColumn138.Header.VisiblePosition = 11
        UltraGridColumn138.MinWidth = 80
        UltraGridColumn138.Width = 80
        UltraGridBand9.Columns.AddRange(New Object() {UltraGridColumn126, UltraGridColumn127, UltraGridColumn128, UltraGridColumn129, UltraGridColumn130, UltraGridColumn131, UltraGridColumn132, UltraGridColumn133, UltraGridColumn134, UltraGridColumn135, UltraGridColumn136, UltraGridColumn137, UltraGridColumn138})
        UltraGridBand9.SummaryFooterCaption = ""
        UltraGridColumn139.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance374.TextHAlignAsString = "Center"
        UltraGridColumn139.Header.Appearance = Appearance374
        UltraGridColumn139.Header.VisiblePosition = 0
        UltraGridColumn139.Hidden = True
        UltraGridColumn139.Width = 85
        UltraGridColumn140.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance375.TextHAlignAsString = "Center"
        UltraGridColumn140.Header.Appearance = Appearance375
        UltraGridColumn140.Header.Caption = "Código"
        UltraGridColumn140.Header.VisiblePosition = 1
        UltraGridColumn140.MinWidth = 80
        UltraGridColumn140.Width = 80
        UltraGridColumn141.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance376.TextHAlignAsString = "Center"
        UltraGridColumn141.Header.Appearance = Appearance376
        UltraGridColumn141.Header.Caption = "Mineral"
        UltraGridColumn141.Header.VisiblePosition = 2
        UltraGridColumn141.MinWidth = 150
        UltraGridColumn141.Width = 150
        UltraGridColumn142.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance377.TextHAlignAsString = "Right"
        UltraGridColumn142.CellAppearance = Appearance377
        UltraGridColumn142.DataType = GetType(Decimal)
        UltraGridColumn142.Format = "n3"
        UltraGridColumn142.Formula = "if( [../../stockrecurso] =0,0, [../../cantidadfraccionada] * (  [StockSubRecurso]" & _
            " /[../../stockrecurso] ))"
        Appearance378.TextHAlignAsString = "Center"
        UltraGridColumn142.Header.Appearance = Appearance378
        UltraGridColumn142.Header.Caption = "Cant. Ton"
        UltraGridColumn142.Header.VisiblePosition = 4
        UltraGridColumn142.MinWidth = 80
        UltraGridColumn142.Width = 80
        UltraGridColumn143.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance379.TextHAlignAsString = "Right"
        UltraGridColumn143.CellAppearance = Appearance379
        UltraGridColumn143.DataType = GetType(Decimal)
        UltraGridColumn143.Format = "n3"
        UltraGridColumn143.Formula = "if ( [../../stockrecurso] =0,0, [../../cantidadncesaria] *( [StockSubRecurso] / [" & _
            "../../stockrecurso] ))"
        Appearance380.TextHAlignAsString = "Center"
        UltraGridColumn143.Header.Appearance = Appearance380
        UltraGridColumn143.Header.Caption = "Cant. Req. "
        UltraGridColumn143.Header.VisiblePosition = 5
        UltraGridColumn143.MinWidth = 80
        UltraGridColumn143.Width = 80
        UltraGridColumn144.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance381.TextHAlignAsString = "Right"
        UltraGridColumn144.CellAppearance = Appearance381
        UltraGridColumn144.DataType = GetType(Decimal)
        UltraGridColumn144.Format = "n4"
        Appearance382.TextHAlignAsString = "Center"
        UltraGridColumn144.Header.Appearance = Appearance382
        UltraGridColumn144.Header.Caption = "C. Extracción"
        UltraGridColumn144.Header.VisiblePosition = 6
        UltraGridColumn144.MinWidth = 90
        UltraGridColumn144.Width = 90
        UltraGridColumn145.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance383.TextHAlignAsString = "Right"
        UltraGridColumn145.CellAppearance = Appearance383
        UltraGridColumn145.DataType = GetType(Decimal)
        UltraGridColumn145.Format = "n4"
        Appearance384.TextHAlignAsString = "Center"
        UltraGridColumn145.Header.Appearance = Appearance384
        UltraGridColumn145.Header.Caption = "C. Compra"
        UltraGridColumn145.Header.VisiblePosition = 7
        UltraGridColumn145.MinWidth = 90
        UltraGridColumn145.Width = 90
        UltraGridColumn146.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance385.TextHAlignAsString = "Right"
        UltraGridColumn146.CellAppearance = Appearance385
        UltraGridColumn146.DataType = GetType(Decimal)
        UltraGridColumn146.Format = "n4"
        Appearance386.TextHAlignAsString = "Center"
        UltraGridColumn146.Header.Appearance = Appearance386
        UltraGridColumn146.Header.Caption = "C. Regalías"
        UltraGridColumn146.Header.VisiblePosition = 8
        UltraGridColumn146.MinWidth = 90
        UltraGridColumn146.Width = 90
        UltraGridColumn147.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance387.TextHAlignAsString = "Right"
        UltraGridColumn147.CellAppearance = Appearance387
        UltraGridColumn147.DataType = GetType(Decimal)
        UltraGridColumn147.Format = "n4"
        Appearance388.TextHAlignAsString = "Center"
        UltraGridColumn147.Header.Appearance = Appearance388
        UltraGridColumn147.Header.Caption = "C. Flete"
        UltraGridColumn147.Header.VisiblePosition = 9
        UltraGridColumn147.MinWidth = 90
        UltraGridColumn147.Width = 90
        UltraGridColumn148.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance389.TextHAlignAsString = "Right"
        UltraGridColumn148.CellAppearance = Appearance389
        UltraGridColumn148.DataType = GetType(Decimal)
        UltraGridColumn148.Format = "n4"
        Appearance390.TextHAlignAsString = "Center"
        UltraGridColumn148.Header.Appearance = Appearance390
        UltraGridColumn148.Header.Caption = "C. Otros"
        UltraGridColumn148.Header.VisiblePosition = 10
        UltraGridColumn148.MinWidth = 90
        UltraGridColumn148.Width = 90
        UltraGridColumn149.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance391.TextHAlignAsString = "Right"
        UltraGridColumn149.CellAppearance = Appearance391
        UltraGridColumn149.DataType = GetType(Decimal)
        UltraGridColumn149.Format = "n4"
        Appearance392.TextHAlignAsString = "Center"
        UltraGridColumn149.Header.Appearance = Appearance392
        UltraGridColumn149.Header.VisiblePosition = 11
        UltraGridColumn149.MinWidth = 90
        UltraGridColumn149.Width = 90
        UltraGridColumn150.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance393.TextHAlignAsString = "Right"
        UltraGridColumn150.CellAppearance = Appearance393
        UltraGridColumn150.DataType = GetType(Decimal)
        UltraGridColumn150.Format = "n4"
        UltraGridColumn150.Formula = "[CantReq] * [CostoxTON]"
        Appearance394.TextHAlignAsString = "Center"
        UltraGridColumn150.Header.Appearance = Appearance394
        UltraGridColumn150.Header.VisiblePosition = 12
        UltraGridColumn150.MinWidth = 90
        UltraGridColumn150.Width = 90
        UltraGridColumn151.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance395.TextHAlignAsString = "Right"
        UltraGridColumn151.CellAppearance = Appearance395
        UltraGridColumn151.DataType = GetType(Decimal)
        UltraGridColumn151.Format = "n3"
        Appearance396.TextHAlignAsString = "Center"
        UltraGridColumn151.Header.Appearance = Appearance396
        UltraGridColumn151.Header.Caption = "Stock"
        UltraGridColumn151.Header.VisiblePosition = 3
        UltraGridColumn151.Width = 8
        UltraGridBand10.Columns.AddRange(New Object() {UltraGridColumn139, UltraGridColumn140, UltraGridColumn141, UltraGridColumn142, UltraGridColumn143, UltraGridColumn144, UltraGridColumn145, UltraGridColumn146, UltraGridColumn147, UltraGridColumn148, UltraGridColumn149, UltraGridColumn150, UltraGridColumn151})
        Me.Grid1.DisplayLayout.BandsSerializer.Add(UltraGridBand9)
        Me.Grid1.DisplayLayout.BandsSerializer.Add(UltraGridBand10)
        Me.Grid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance397.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance397.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance397.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance397.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.GroupByBox.Appearance = Appearance397
        Appearance398.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance398
        Me.Grid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid1.DisplayLayout.GroupByBox.Hidden = True
        Appearance399.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance399.BackColor2 = System.Drawing.SystemColors.Control
        Appearance399.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance399.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance399
        Me.Grid1.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid1.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid1.DisplayLayout.Override.BorderStyleSpecialRowSeparator = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Appearance400.BackColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.CardAreaAppearance = Appearance400
        Appearance401.BorderColor = System.Drawing.Color.Silver
        Appearance401.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid1.DisplayLayout.Override.CellAppearance = Appearance401
        Me.Grid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid1.DisplayLayout.Override.CellPadding = 0
        Me.Grid1.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.Grid1.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.Grid1.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.Grid1.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance402.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance402.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Grid1.DisplayLayout.Override.FilterRowAppearance = Appearance402
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid1.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance403.BackColor = System.Drawing.Color.LightYellow
        Me.Grid1.DisplayLayout.Override.FixedRowAppearance = Appearance403
        Me.Grid1.DisplayLayout.Override.FixedRowsLimit = 10
        Me.Grid1.DisplayLayout.Override.FixedRowStyle = Infragistics.Win.UltraWinGrid.FixedRowStyle.Top
        Appearance404.BackColor = System.Drawing.SystemColors.Control
        Appearance404.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance404.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance404.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance404.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid1.DisplayLayout.Override.GroupByRowAppearance = Appearance404
        Appearance405.FontData.Name = "Arial Narrow"
        Appearance405.FontData.SizeInPoints = 10.0!
        Appearance405.TextHAlignAsString = "Left"
        Me.Grid1.DisplayLayout.Override.HeaderAppearance = Appearance405
        Me.Grid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid1.DisplayLayout.Override.MinRowHeight = 24
        Appearance406.BackColor = System.Drawing.SystemColors.Window
        Appearance406.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance406.TextVAlignAsString = "Middle"
        Me.Grid1.DisplayLayout.Override.RowAppearance = Appearance406
        Me.Grid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid1.DisplayLayout.Override.SpecialRowSeparator = Infragistics.Win.UltraWinGrid.SpecialRowSeparator.FixedRows
        Appearance407.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Grid1.DisplayLayout.Override.SpecialRowSeparatorAppearance = Appearance407
        Me.Grid1.DisplayLayout.Override.SpecialRowSeparatorHeight = 10
        Appearance408.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance408
        Me.Grid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid1.Location = New System.Drawing.Point(0, 25)
        Me.Grid1.Name = "Grid1"
        Me.Grid1.Size = New System.Drawing.Size(644, 157)
        Me.Grid1.TabIndex = 150
        Me.Grid1.Text = "UltraGrid1"
        '
        'Navigator2
        '
        Me.Navigator2.AddNewItem = Nothing
        Me.Navigator2.BackColor = System.Drawing.SystemColors.Control
        Me.Navigator2.BindingSource = Me.Source2
        Me.Navigator2.CountItem = Me.StripLbl1
        Me.Navigator2.DeleteItem = Nothing
        Me.Navigator2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Navigator2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Separator7, Me.StripBtn4, Me.StripBtn3, Me.Separator6, Me.StripLbl1, Me.StripTxt1, Me.Separator5, Me.StripBtn2, Me.StripBtn1, Me.Separator4, Me.StripLbl5, Me.Separator1, Me.ToolStripButton4, Me.Separator2, Me.ToolStripButton5, Me.Separator3})
        Me.Navigator2.Location = New System.Drawing.Point(0, 0)
        Me.Navigator2.MoveFirstItem = Me.StripBtn1
        Me.Navigator2.MoveLastItem = Me.StripBtn4
        Me.Navigator2.MoveNextItem = Me.StripBtn3
        Me.Navigator2.MovePreviousItem = Me.StripBtn2
        Me.Navigator2.Name = "Navigator2"
        Me.Navigator2.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.Navigator2.PositionItem = Me.StripTxt1
        Me.Navigator2.Size = New System.Drawing.Size(644, 25)
        Me.Navigator2.TabIndex = 149
        Me.Navigator2.Text = "BindingNavigator1"
        '
        'StripLbl1
        '
        Me.StripLbl1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripLbl1.Name = "StripLbl1"
        Me.StripLbl1.Size = New System.Drawing.Size(37, 22)
        Me.StripLbl1.Text = "de {0}"
        Me.StripLbl1.ToolTipText = "Número total de elementos"
        '
        'Separator7
        '
        Me.Separator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Separator7.Name = "Separator7"
        Me.Separator7.Size = New System.Drawing.Size(6, 25)
        '
        'StripBtn4
        '
        Me.StripBtn4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripBtn4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StripBtn4.Image = CType(resources.GetObject("StripBtn4.Image"), System.Drawing.Image)
        Me.StripBtn4.Name = "StripBtn4"
        Me.StripBtn4.RightToLeftAutoMirrorImage = True
        Me.StripBtn4.Size = New System.Drawing.Size(23, 22)
        Me.StripBtn4.Text = "Mover último"
        '
        'StripBtn3
        '
        Me.StripBtn3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripBtn3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StripBtn3.Image = CType(resources.GetObject("StripBtn3.Image"), System.Drawing.Image)
        Me.StripBtn3.Name = "StripBtn3"
        Me.StripBtn3.RightToLeftAutoMirrorImage = True
        Me.StripBtn3.Size = New System.Drawing.Size(23, 22)
        Me.StripBtn3.Text = "Mover siguiente"
        '
        'Separator6
        '
        Me.Separator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Separator6.Name = "Separator6"
        Me.Separator6.Size = New System.Drawing.Size(6, 25)
        '
        'StripTxt1
        '
        Me.StripTxt1.AccessibleName = "Posición"
        Me.StripTxt1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripTxt1.AutoSize = False
        Me.StripTxt1.BackColor = System.Drawing.Color.White
        Me.StripTxt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StripTxt1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.StripTxt1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StripTxt1.Name = "StripTxt1"
        Me.StripTxt1.Size = New System.Drawing.Size(50, 23)
        Me.StripTxt1.Text = "0"
        Me.StripTxt1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.StripTxt1.ToolTipText = "Posición actual"
        '
        'Separator5
        '
        Me.Separator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Separator5.Name = "Separator5"
        Me.Separator5.Size = New System.Drawing.Size(6, 25)
        '
        'StripBtn2
        '
        Me.StripBtn2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripBtn2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StripBtn2.Image = CType(resources.GetObject("StripBtn2.Image"), System.Drawing.Image)
        Me.StripBtn2.Name = "StripBtn2"
        Me.StripBtn2.RightToLeftAutoMirrorImage = True
        Me.StripBtn2.Size = New System.Drawing.Size(23, 22)
        Me.StripBtn2.Text = "Mover anterior"
        '
        'StripBtn1
        '
        Me.StripBtn1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.StripBtn1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StripBtn1.Image = CType(resources.GetObject("StripBtn1.Image"), System.Drawing.Image)
        Me.StripBtn1.Name = "StripBtn1"
        Me.StripBtn1.RightToLeftAutoMirrorImage = True
        Me.StripBtn1.Size = New System.Drawing.Size(23, 22)
        Me.StripBtn1.Text = "Mover primero"
        '
        'Separator4
        '
        Me.Separator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Separator4.Name = "Separator4"
        Me.Separator4.Size = New System.Drawing.Size(6, 25)
        '
        'StripLbl5
        '
        Me.StripLbl5.Name = "StripLbl5"
        Me.StripLbl5.Size = New System.Drawing.Size(34, 22)
        Me.StripLbl5.Text = "         "
        '
        'Separator1
        '
        Me.Separator1.Name = "Separator1"
        Me.Separator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(76, 22)
        Me.ToolStripButton4.Text = "&AGREGAR"
        '
        'Separator2
        '
        Me.Separator2.Name = "Separator2"
        Me.Separator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(67, 22)
        Me.ToolStripButton5.Text = "&QUITAR"
        '
        'Separator3
        '
        Me.Separator3.Name = "Separator3"
        Me.Separator3.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.Grid5)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(644, 182)
        '
        'Grid5
        '
        Me.Grid5.CalcManager = Me.Clm1
        Me.Grid5.DataSource = Me.UdsProducto
        Appearance409.BackColor = System.Drawing.SystemColors.Window
        Appearance409.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid5.DisplayLayout.Appearance = Appearance409
        Me.Grid5.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn152.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance410.TextHAlignAsString = "Center"
        UltraGridColumn152.Header.Appearance = Appearance410
        UltraGridColumn152.Header.Caption = "Código"
        UltraGridColumn152.Header.VisiblePosition = 0
        UltraGridColumn152.MaxWidth = 80
        UltraGridColumn152.MinWidth = 80
        UltraGridColumn152.Width = 80
        UltraGridColumn153.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance411.TextHAlignAsString = "Center"
        UltraGridColumn153.Header.Appearance = Appearance411
        UltraGridColumn153.Header.Caption = "Producto"
        UltraGridColumn153.Header.VisiblePosition = 1
        UltraGridColumn153.MinWidth = 150
        UltraGridColumn153.Width = 150
        UltraGridColumn154.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance412.TextHAlignAsString = "Right"
        UltraGridColumn154.CellAppearance = Appearance412
        UltraGridColumn154.Format = "n2"
        UltraGridColumn154.Header.Caption = "Pje (%)"
        UltraGridColumn154.Header.VisiblePosition = 3
        UltraGridColumn154.MinWidth = 50
        UltraGridColumn154.Width = 50
        UltraGridColumn155.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance413.TextHAlignAsString = "Right"
        UltraGridColumn155.CellAppearance = Appearance413
        UltraGridColumn155.Format = "n2"
        Appearance414.TextHAlignAsString = "Center"
        UltraGridColumn155.Header.Appearance = Appearance414
        UltraGridColumn155.Header.VisiblePosition = 4
        UltraGridColumn155.MinWidth = 50
        UltraGridColumn155.Width = 50
        UltraGridColumn156.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance415.TextHAlignAsString = "Right"
        UltraGridColumn156.CellAppearance = Appearance415
        UltraGridColumn156.Format = "n2"
        Appearance416.TextHAlignAsString = "Center"
        UltraGridColumn156.Header.Appearance = Appearance416
        UltraGridColumn156.Header.VisiblePosition = 5
        UltraGridColumn156.MinWidth = 50
        UltraGridColumn156.Width = 50
        UltraGridColumn157.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance417.TextHAlignAsString = "Right"
        UltraGridColumn157.CellAppearance = Appearance417
        UltraGridColumn157.Format = "n3"
        Appearance418.TextHAlignAsString = "Center"
        UltraGridColumn157.Header.Appearance = Appearance418
        UltraGridColumn157.Header.Caption = "Stock"
        UltraGridColumn157.Header.VisiblePosition = 6
        UltraGridColumn157.MinWidth = 100
        UltraGridColumn157.Width = 100
        UltraGridColumn158.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance419.TextHAlignAsString = "Right"
        UltraGridColumn158.CellAppearance = Appearance419
        UltraGridColumn158.Format = "n4"
        Appearance420.TextHAlignAsString = "Center"
        UltraGridColumn158.Header.Appearance = Appearance420
        UltraGridColumn158.Header.VisiblePosition = 9
        UltraGridColumn158.MinWidth = 100
        UltraGridColumn158.Width = 100
        UltraGridColumn159.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn159.Header.VisiblePosition = 8
        UltraGridColumn159.Hidden = True
        UltraGridColumn159.Width = 8
        UltraGridColumn160.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn160.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance421.TextHAlignAsString = "Right"
        UltraGridColumn160.CellAppearance = Appearance421
        UltraGridColumn160.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn160.DataType = GetType(Decimal)
        UltraGridColumn160.Format = "n4"
        UltraGridColumn160.Formula = "[Cantidad] * [Porcentaje] * 0.01"
        Appearance422.TextHAlignAsString = "Center"
        UltraGridColumn160.Header.Appearance = Appearance422
        UltraGridColumn160.Header.Caption = "Cantidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(TON)"
        UltraGridColumn160.Header.VisiblePosition = 2
        UltraGridColumn160.MaxWidth = 90
        UltraGridColumn160.MinWidth = 90
        UltraGridColumn160.Width = 90
        UltraGridColumn161.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn161.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance423.TextHAlignAsString = "Right"
        UltraGridColumn161.CellAppearance = Appearance423
        UltraGridColumn161.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn161.Format = "n4"
        UltraGridColumn161.Formula = "(100 +  [Humedad] + [Merma]) * 0.01 *   [CantidadxFraccionada]"
        Appearance424.TextHAlignAsString = "Center"
        UltraGridColumn161.Header.Appearance = Appearance424
        UltraGridColumn161.Header.Caption = "Cant.Req." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(TON)"
        UltraGridColumn161.Header.VisiblePosition = 7
        UltraGridColumn161.MaxWidth = 90
        UltraGridColumn161.MinWidth = 90
        UltraGridColumn161.Width = 90
        UltraGridColumn162.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn162.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance425.TextHAlignAsString = "Right"
        UltraGridColumn162.CellAppearance = Appearance425
        UltraGridColumn162.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn162.Format = "c"
        UltraGridColumn162.Formula = "[CantidadxNecesaria] * [CostoxTON]"
        Appearance426.TextHAlignAsString = "Center"
        UltraGridColumn162.Header.Appearance = Appearance426
        UltraGridColumn162.Header.VisiblePosition = 10
        UltraGridColumn162.MaxWidth = 90
        UltraGridColumn162.MinWidth = 90
        UltraGridColumn162.Width = 90
        UltraGridColumn163.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance427.TextHAlignAsString = "Right"
        UltraGridColumn163.CellAppearance = Appearance427
        UltraGridColumn163.Format = "n4"
        UltraGridColumn163.Formula = "if( ISNUMBER([//CalsCantidad]) , [//CalsCantidad] , 0 )"
        UltraGridColumn163.Header.VisiblePosition = 11
        UltraGridColumn163.Hidden = True
        UltraGridColumn163.MinWidth = 100
        UltraGridColumn163.Width = 100
        UltraGridBand11.Columns.AddRange(New Object() {UltraGridColumn152, UltraGridColumn153, UltraGridColumn154, UltraGridColumn155, UltraGridColumn156, UltraGridColumn157, UltraGridColumn158, UltraGridColumn159, UltraGridColumn160, UltraGridColumn161, UltraGridColumn162, UltraGridColumn163})
        Appearance428.BackColor = System.Drawing.SystemColors.Info
        Appearance428.FontData.BoldAsString = "True"
        Appearance428.ForeColor = System.Drawing.Color.Red
        Appearance428.TextHAlignAsString = "Right"
        SummarySettings26.Appearance = Appearance428
        SummarySettings26.DisplayFormat = "{0:N3}"
        SummarySettings26.GroupBySummaryValueAppearance = Appearance429
        Appearance430.BackColor = System.Drawing.SystemColors.Info
        Appearance430.FontData.BoldAsString = "True"
        Appearance430.ForeColor = System.Drawing.Color.Red
        Appearance430.TextHAlignAsString = "Right"
        SummarySettings27.Appearance = Appearance430
        SummarySettings27.DisplayFormat = "{0:N3}"
        SummarySettings27.GroupBySummaryValueAppearance = Appearance431
        Appearance432.BackColor = System.Drawing.SystemColors.Info
        Appearance432.FontData.BoldAsString = "True"
        Appearance432.ForeColor = System.Drawing.Color.Red
        Appearance432.TextHAlignAsString = "Right"
        SummarySettings28.Appearance = Appearance432
        SummarySettings28.DisplayFormat = "{0:N4}"
        SummarySettings28.GroupBySummaryValueAppearance = Appearance433
        Appearance434.BackColor = System.Drawing.SystemColors.Info
        Appearance434.FontData.BoldAsString = "True"
        Appearance434.ForeColor = System.Drawing.Color.Red
        Appearance434.TextHAlignAsString = "Right"
        SummarySettings29.Appearance = Appearance434
        SummarySettings29.DisplayFormat = "{0:N2}"
        SummarySettings29.GroupBySummaryValueAppearance = Appearance435
        Appearance436.BackColor = System.Drawing.SystemColors.Info
        Appearance436.FontData.BoldAsString = "True"
        Appearance436.ForeColor = System.Drawing.Color.Red
        Appearance436.TextHAlignAsString = "Right"
        SummarySettings30.Appearance = Appearance436
        SummarySettings30.DisplayFormat = "{0:N3}"
        SummarySettings30.GroupBySummaryValueAppearance = Appearance437
        UltraGridBand11.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings26, SummarySettings27, SummarySettings28, SummarySettings29, SummarySettings30})
        UltraGridBand11.SummaryFooterCaption = ""
        UltraGridBand11.UseRowLayout = True
        Me.Grid5.DisplayLayout.BandsSerializer.Add(UltraGridBand11)
        Me.Grid5.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid5.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid5.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance438.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance438.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance438.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance438.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid5.DisplayLayout.GroupByBox.Appearance = Appearance438
        Appearance439.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid5.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance439
        Me.Grid5.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.Grid5.DisplayLayout.GroupByBox.Hidden = True
        Appearance440.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance440.BackColor2 = System.Drawing.SystemColors.Control
        Appearance440.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance440.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Grid5.DisplayLayout.GroupByBox.PromptAppearance = Appearance440
        Me.Grid5.DisplayLayout.MaxColScrollRegions = 1
        Me.Grid5.DisplayLayout.MaxRowScrollRegions = 1
        Me.Grid5.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid5.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.Grid5.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.Grid5.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance441.BackColor = System.Drawing.SystemColors.Window
        Me.Grid5.DisplayLayout.Override.CardAreaAppearance = Appearance441
        Appearance442.BorderColor = System.Drawing.Color.Silver
        Appearance442.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.Grid5.DisplayLayout.Override.CellAppearance = Appearance442
        Me.Grid5.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.Grid5.DisplayLayout.Override.CellPadding = 0
        Me.Grid5.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance443.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Grid5.DisplayLayout.Override.FilterRowAppearance = Appearance443
        Me.Grid5.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.Grid5.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.Grid5.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance444.BackColor = System.Drawing.SystemColors.Control
        Appearance444.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance444.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance444.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance444.BorderColor = System.Drawing.SystemColors.Window
        Me.Grid5.DisplayLayout.Override.GroupByRowAppearance = Appearance444
        Appearance445.FontData.Name = "Arial Narrow"
        Appearance445.FontData.SizeInPoints = 10.0!
        Appearance445.TextHAlignAsString = "Left"
        Me.Grid5.DisplayLayout.Override.HeaderAppearance = Appearance445
        Me.Grid5.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.Grid5.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.Grid5.DisplayLayout.Override.MinRowHeight = 24
        Appearance446.BackColor = System.Drawing.SystemColors.Window
        Appearance446.BorderColor = System.Drawing.Color.Silver
        Appearance446.TextVAlignAsString = "Middle"
        Me.Grid5.DisplayLayout.Override.RowAppearance = Appearance446
        Me.Grid5.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.Grid5.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.Grid5.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance447.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Grid5.DisplayLayout.Override.TemplateAddRowAppearance = Appearance447
        Me.Grid5.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.Grid5.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.Grid5.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.Grid5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid5.Location = New System.Drawing.Point(0, 0)
        Me.Grid5.Name = "Grid5"
        Me.Grid5.Size = New System.Drawing.Size(644, 182)
        Me.Grid5.TabIndex = 130
        Me.Grid5.Text = "UltraGrid1"
        '
        'UltraTabControl1
        '
        Me.UltraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl5)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl6)
        Me.UltraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage3
        Me.UltraTabControl1.Size = New System.Drawing.Size(200, 100)
        Me.UltraTabControl1.TabIndex = 0
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel7.Text = "de {0}"
        Me.ToolStripLabel7.ToolTipText = "Número total de elementos"
        '
        'ToolStripSeparator27
        '
        Me.ToolStripSeparator27.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator27.Name = "ToolStripSeparator27"
        Me.ToolStripSeparator27.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton18
        '
        Me.ToolStripButton18.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton18.Image = CType(resources.GetObject("ToolStripButton18.Image"), System.Drawing.Image)
        Me.ToolStripButton18.Name = "ToolStripButton18"
        Me.ToolStripButton18.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton18.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton18.Text = "Mover último"
        '
        'ToolStripButton19
        '
        Me.ToolStripButton19.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton19.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton19.Image = CType(resources.GetObject("ToolStripButton19.Image"), System.Drawing.Image)
        Me.ToolStripButton19.Name = "ToolStripButton19"
        Me.ToolStripButton19.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton19.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton19.Text = "Mover siguiente"
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox3
        '
        Me.ToolStripTextBox3.AccessibleName = "Posición"
        Me.ToolStripTextBox3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripTextBox3.AutoSize = False
        Me.ToolStripTextBox3.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolStripTextBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripTextBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripTextBox3.Name = "ToolStripTextBox3"
        Me.ToolStripTextBox3.Size = New System.Drawing.Size(50, 23)
        Me.ToolStripTextBox3.Text = "0"
        Me.ToolStripTextBox3.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolStripTextBox3.ToolTipText = "Posición actual"
        '
        'ToolStripSeparator29
        '
        Me.ToolStripSeparator29.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator29.Name = "ToolStripSeparator29"
        Me.ToolStripSeparator29.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton20
        '
        Me.ToolStripButton20.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton20.Image = CType(resources.GetObject("ToolStripButton20.Image"), System.Drawing.Image)
        Me.ToolStripButton20.Name = "ToolStripButton20"
        Me.ToolStripButton20.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton20.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton20.Text = "Mover anterior"
        '
        'ToolStripButton21
        '
        Me.ToolStripButton21.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton21.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton21.Image = CType(resources.GetObject("ToolStripButton21.Image"), System.Drawing.Image)
        Me.ToolStripButton21.Name = "ToolStripButton21"
        Me.ToolStripButton21.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton21.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton21.Text = "Mover primero"
        '
        'ToolStripSeparator30
        '
        Me.ToolStripSeparator30.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator30.Name = "ToolStripSeparator30"
        Me.ToolStripSeparator30.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(34, 22)
        Me.ToolStripLabel8.Text = "         "
        '
        'ToolStripSeparator31
        '
        Me.ToolStripSeparator31.Name = "ToolStripSeparator31"
        Me.ToolStripSeparator31.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton22
        '
        Me.ToolStripButton22.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton22.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripButton22.Image = CType(resources.GetObject("ToolStripButton22.Image"), System.Drawing.Image)
        Me.ToolStripButton22.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton22.Name = "ToolStripButton22"
        Me.ToolStripButton22.Size = New System.Drawing.Size(76, 22)
        Me.ToolStripButton22.Text = "&AGREGAR"
        '
        'ToolStripSeparator32
        '
        Me.ToolStripSeparator32.Name = "ToolStripSeparator32"
        Me.ToolStripSeparator32.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton23
        '
        Me.ToolStripButton23.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton23.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripButton23.Image = CType(resources.GetObject("ToolStripButton23.Image"), System.Drawing.Image)
        Me.ToolStripButton23.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton23.Name = "ToolStripButton23"
        Me.ToolStripButton23.Size = New System.Drawing.Size(67, 22)
        Me.ToolStripButton23.Text = "&QUITAR"
        '
        'ToolStripSeparator33
        '
        Me.ToolStripSeparator33.Name = "ToolStripSeparator33"
        Me.ToolStripSeparator33.Size = New System.Drawing.Size(6, 25)
        '
        'FrmLOrdenProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 532)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmLOrdenProduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "L01"
        Me.Text = "ORDEN DE PRODUCCION"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.UltraTabPageControl7.ResumeLayout(False)
        Me.UltraTabPageControl7.PerformLayout()
        CType(Me.Grid7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Clm1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Navigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Navigator1.ResumeLayout(False)
        Me.Navigator1.PerformLayout()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl9.ResumeLayout(False)
        Me.UltraTabPageControl9.PerformLayout()
        CType(Me.Grid8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UdsProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator2.ResumeLayout(False)
        Me.BindingNavigator2.PerformLayout()
        Me.UltraTabPageControl10.ResumeLayout(False)
        Me.UltraTabPageControl10.PerformLayout()
        CType(Me.Grid6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator3.ResumeLayout(False)
        Me.BindingNavigator3.PerformLayout()
        Me.UltraTabPageControl11.ResumeLayout(False)
        Me.UltraTabPageControl11.PerformLayout()
        CType(Me.Grid9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UdsProdRecirculado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator4.ResumeLayout(False)
        Me.BindingNavigator4.PerformLayout()
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        CType(Me.Grid3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool1.ResumeLayout(False)
        Me.Tool1.PerformLayout()
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.UltraTabPageControl4.PerformLayout()
        CType(Me.Grid4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tool2.ResumeLayout(False)
        Me.Tool2.PerformLayout()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        Me.UltraGroupBox3.PerformLayout()
        CType(Me.Cbo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cbo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txt1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl8.ResumeLayout(False)
        CType(Me.Tab3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab3.ResumeLayout(False)
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        CType(Me.Tab2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab2.ResumeLayout(False)
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Uds2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Uds1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.Ep1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UdsSuministro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl5.ResumeLayout(False)
        Me.UltraTabPageControl5.PerformLayout()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Navigator2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Navigator2.ResumeLayout(False)
        Me.Navigator2.PerformLayout()
        Me.UltraTabPageControl6.ResumeLayout(False)
        CType(Me.Grid5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Iml1 As System.Windows.Forms.ImageList
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Grid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Tab2 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Tool1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Clm1 As Infragistics.Win.UltraWinCalcManager.UltraCalcManager
    Friend WithEvents Uds1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents Uds2 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents Tool2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Grid3 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Grid4 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Btn7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Bgw1 As System.ComponentModel.BackgroundWorker

    Sub Evento_KeyDown_Grilla(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Grid2.KeyDown, Grid3.KeyDown, Grid4.KeyDown

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not (sender Is Grid1 OrElse sender Is Grid2 OrElse _
           sender Is Grid3 OrElse sender Is Grid4) Then Return

        With sender
            Select Case e.KeyValue
                Case Keys.Up
                    .PerformAction(ExitEditMode)
                    .PerformAction(AboveCell)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Down
                    .PerformAction(ExitEditMode)
                    .PerformAction(BelowCell)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Right
                    .PerformAction(ExitEditMode)
                    .PerformAction(NextCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Left
                    .PerformAction(ExitEditMode)
                    .PerformAction(PrevCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Return
                    .PerformAction(ExitEditMode)
                    .PerformAction(NextCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
            End Select
        End With

    End Sub
    Friend WithEvents UdsProducto As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents UdsSuministro As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents Num5 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Num3 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Num4 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Num2 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Lbl1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Cbo1 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Btn1 As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt4 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Num1 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents Dt3 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Dt2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Dt1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Txt3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Txt1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Num6 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Source2 As System.Windows.Forms.BindingSource
    Friend WithEvents UltraTabPageControl8 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Tab3 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage4 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl7 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Grid7 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraTabPageControl9 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl10 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabSharedControlsPage3 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Grid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Navigator2 As System.Windows.Forms.BindingNavigator
    Friend WithEvents StripLbl1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Separator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StripBtn4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StripBtn3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Separator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StripTxt1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents Separator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StripBtn2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents StripBtn1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Separator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StripLbl5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Separator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Separator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Separator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Grid5 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents Navigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Grid8 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents BindingNavigator2 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Grid6 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents BindingNavigator3 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripSeparator34 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator38 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator39 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn13 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator40 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel7 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator27 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton18 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton19 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox3 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator29 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton20 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton21 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator30 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel8 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator31 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton22 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator32 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton23 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator33 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UltraTabPageControl11 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Chk1 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents Grid9 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UdsProdRecirculado As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents BindingNavigator4 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn14 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Btn15 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Num7 As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Cbo2 As Infragistics.Win.UltraWinEditors.UltraComboEditor

End Class
