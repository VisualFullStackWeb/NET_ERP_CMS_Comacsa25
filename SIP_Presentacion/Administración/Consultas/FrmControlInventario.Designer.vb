<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmControlInventario
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
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance109 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel")
        Dim Appearance110 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CANTERA", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RUMA", 1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MINERAL", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MOVIMIENTO", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TON", 4)
        Dim Appearance104 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SOLES", 5)
        Dim Appearance107 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SOLESXTON", 6)
        Dim Appearance108 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ORIGEN", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONTRATISTA", 8)
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TON", 4, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TON", 4, False)
        Dim Appearance134 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance175 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SOLES", 5, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SOLES", 5, False)
        Dim Appearance176 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance177 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1366)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1172)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1261)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(185)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion12 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion13 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance178 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance179 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance180 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance181 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance182 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance183 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance184 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance185 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance186 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance187 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance258 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel")
        Dim Appearance259 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_RUMA", 0)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_ALM", 1)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ALMACEN", 2)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RUMA", 3)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_MINERAL", 4)
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Agrupacion", 5)
        Dim ColScrollRegion14 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(234)
        Dim ColScrollRegion15 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(174)
        Dim ColScrollRegion16 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(174)
        Dim ColScrollRegion17 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion18 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion19 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion20 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion21 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion22 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion23 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion24 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion25 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion26 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance260 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance261 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance262 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance263 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance264 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance265 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance266 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance267 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance268 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance269 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel")
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ALMACEN", 0)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_ALMACEN", 1)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PLANTA", 2)
        Dim ColScrollRegion27 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(182)
        Dim ColScrollRegion28 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion29 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion30 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion31 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion32 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion33 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion34 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion35 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion36 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ALMACEN", 0)
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_RUMA", 1)
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RUMA", 2)
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("STOCK", 3)
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings3 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Nothing, Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "RUMA", 2, False)
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings4 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "STOCK", 3, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "STOCK", 3, False)
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion37 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(69)
        Dim ColScrollRegion38 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(174)
        Dim ColScrollRegion39 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(174)
        Dim ColScrollRegion40 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion41 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion42 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion43 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion44 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion45 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion46 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion47 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion48 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion49 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel")
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPO", 0)
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_TIPO", 1)
        Dim ColScrollRegion50 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(182)
        Dim ColScrollRegion51 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(174)
        Dim ColScrollRegion52 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion53 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion54 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion55 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion56 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion57 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion58 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion59 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion60 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion61 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand6 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel")
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_MINERAL", 0)
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MINERAL", 1)
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_RUMA", 2)
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANTA", 3)
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_ALM", 4)
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ALMACEN", 5)
        Dim ColScrollRegion62 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(273)
        Dim ColScrollRegion63 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion64 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion65 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion66 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion67 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion68 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion69 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion70 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion71 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance138 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand7 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_RUMA", 0)
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RUMA", 1)
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANTA", 2)
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_ALM", 3)
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ALMACEN", 4)
        Dim ColScrollRegion72 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(266)
        Dim ColScrollRegion73 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion74 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion75 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion76 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion77 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion78 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion79 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion80 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion81 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand8 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel")
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES", 0)
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES_NRO", 1)
        Dim ColScrollRegion82 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(63)
        Dim ColScrollRegion83 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion84 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion85 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion86 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion87 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion88 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion89 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion90 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion91 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion92 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Appearance103 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand9 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_RUMA", 0)
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RUMA", 1)
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SALDO", 2, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OBSERVACION", 3)
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES_MINIMO", 4)
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES_MAXIMO", 5)
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ESTADO", 6)
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONSUMO_PROM", 7)
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES_STOCK", 8)
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SOLES", 9)
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RESULTADO", 10)
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DIF_TON", 11)
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("INGRESOS", 12)
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SALIDAS", 13)
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("INICIAL", 14)
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DIF_SOL", 15)
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ALMACEN", 16)
        Dim ColScrollRegion93 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(485)
        Dim ColScrollRegion94 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(801)
        Dim ColScrollRegion95 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(923)
        Dim ColScrollRegion96 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(185)
        Dim ColScrollRegion97 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion98 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion99 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion100 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion101 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion102 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion103 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion104 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion105 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance139 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand10 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel")
        Dim Appearance102 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COMENTARIO", 0)
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA", 1)
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 2)
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_RUMA", 3)
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("USUARIO", 4)
        Dim SummarySettings5 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "DIF_TON", -2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "DIF_TON", -2, False)
        Dim Appearance135 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance136 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings6 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "DIF_SOL", -2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "DIF_SOL", -2, False)
        Dim Appearance137 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance140 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion106 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(705)
        Dim ColScrollRegion107 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1177)
        Dim ColScrollRegion108 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(185)
        Dim ColScrollRegion109 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion110 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion111 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion112 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion113 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion114 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion115 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion116 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion117 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance141 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance142 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance143 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance144 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance145 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance146 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance147 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance148 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance149 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance150 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance116 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand11 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel")
        Dim Appearance151 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_RUMA", 0)
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RUMA", 1)
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SALDO", 2)
        Dim Appearance152 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OBSERVACION", 3)
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES_MINIMO", 4)
        Dim Appearance153 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES_MAXIMO", 5)
        Dim Appearance154 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ESTADO", 6)
        Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONSUMO_PROM", 7)
        Dim Appearance155 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES_STOCK", 8)
        Dim Appearance156 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SOLES", 9)
        Dim Appearance157 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RESULTADO", 10)
        Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DIF_TON", 11)
        Dim Appearance158 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DIF_SOL", 12)
        Dim Appearance159 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn84 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("INICIAL", 13)
        Dim Appearance160 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn85 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("INGRESOS", 14)
        Dim Appearance161 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn86 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SALIDAS", 15)
        Dim Appearance162 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn87 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ALMACEN", 16)
        Dim SummarySettings7 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "DIF_TON", 11, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "DIF_TON", 11, False)
        Dim Appearance163 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance164 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings8 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "DIF_SOL", 12, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "DIF_SOL", 12, False)
        Dim Appearance165 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance166 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings9 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "INICIAL", 13, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "INICIAL", 13, False)
        Dim Appearance167 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance168 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings10 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SALDO", 2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SALDO", 2, False)
        Dim Appearance169 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance170 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings11 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SOLES", 9, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SOLES", 9, False)
        Dim Appearance171 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance172 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings12 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "INGRESOS", 14, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "INGRESOS", 14, False)
        Dim Appearance173 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance174 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings13 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SALIDAS", 15, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SALIDAS", 15, False)
        Dim Appearance215 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance216 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion118 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1569)
        Dim ColScrollRegion119 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(185)
        Dim ColScrollRegion120 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion121 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion122 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion123 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion124 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion125 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion126 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion127 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion128 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance217 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance218 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance219 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance220 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance221 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance222 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance223 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance224 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance225 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance226 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance188 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand12 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel")
        Dim Appearance189 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_RUMA", 0)
        Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RUMA", 1)
        Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SALDO", 2)
        Dim Appearance190 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OBSERVACION", 3)
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES_MINIMO", 4)
        Dim Appearance191 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES_MAXIMO", 5)
        Dim Appearance192 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ESTADO", 6)
        Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONSUMO_PROM", 7)
        Dim Appearance193 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES_STOCK", 8)
        Dim Appearance194 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SOLES", 9)
        Dim Appearance195 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RESULTADO", 10)
        Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DIF_TON", 11)
        Dim Appearance196 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DIF_SOL", 12)
        Dim Appearance197 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("INICIAL", 13)
        Dim Appearance198 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("INGRESOS", 14)
        Dim Appearance199 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SALIDAS", 15)
        Dim Appearance200 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ALMACEN", 16)
        Dim SummarySettings14 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "DIF_TON", 11, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "DIF_TON", 11, False)
        Dim Appearance201 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance202 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings15 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "DIF_SOL", 12, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "DIF_SOL", 12, False)
        Dim Appearance203 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance204 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings16 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "INICIAL", 13, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "INICIAL", 13, False)
        Dim Appearance117 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance111 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings17 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SALDO", 2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SALDO", 2, False)
        Dim Appearance118 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance112 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings18 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SOLES", 9, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SOLES", 9, False)
        Dim Appearance131 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance113 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings19 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "INGRESOS", 14, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "INGRESOS", 14, False)
        Dim Appearance132 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance114 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings20 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SALIDAS", 15, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SALIDAS", 15, False)
        Dim Appearance133 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance115 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion129 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(212)
        Dim ColScrollRegion130 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1261)
        Dim ColScrollRegion131 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(185)
        Dim ColScrollRegion132 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion133 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion134 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion135 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion136 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion137 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion138 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion139 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion140 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance205 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance206 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance207 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance208 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance209 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance210 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance211 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance212 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance213 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance214 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance227 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand13 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("sel")
        Dim Appearance228 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CANTERA", 0)
        Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RUMA", 1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn109 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MINERAL", 2)
        Dim UltraGridColumn110 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MOVIMIENTO", 3)
        Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TON", 4)
        Dim Appearance229 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SOLES", 5)
        Dim Appearance230 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn113 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SOLESXTON", 6)
        Dim Appearance231 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn114 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ORIGEN", 7)
        Dim SummarySettings21 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TON", 4, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TON", 4, False)
        Dim Appearance232 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance233 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings22 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "SOLES", 5, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "SOLES", 5, False)
        Dim Appearance234 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance235 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion141 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1172)
        Dim ColScrollRegion142 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1261)
        Dim ColScrollRegion143 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(185)
        Dim ColScrollRegion144 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(192)
        Dim ColScrollRegion145 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(802)
        Dim ColScrollRegion146 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion147 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(799)
        Dim ColScrollRegion148 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(708)
        Dim ColScrollRegion149 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1029)
        Dim ColScrollRegion150 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(997)
        Dim ColScrollRegion151 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(884)
        Dim ColScrollRegion152 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(753)
        Dim Appearance236 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance237 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance238 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance239 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance240 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance241 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance242 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance243 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance244 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance245 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        Me.girdCanteraDet = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Button1 = New System.Windows.Forms.Button
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lbldefsol = New System.Windows.Forms.Label
        Me.lbltonsol = New System.Windows.Forms.Label
        Me.lbldefton = New System.Windows.Forms.Label
        Me.lbltonexe = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btngraficasoles = New System.Windows.Forms.Button
        Me.lblfinalV = New System.Windows.Forms.Label
        Me.lblsalidaV = New System.Windows.Forms.Label
        Me.lblentradaV = New System.Windows.Forms.Label
        Me.lblinicialV = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblayo5 = New System.Windows.Forms.Label
        Me.lblayo4 = New System.Windows.Forms.Label
        Me.lblayo3 = New System.Windows.Forms.Label
        Me.lblayo2 = New System.Windows.Forms.Label
        Me.lblayo1 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.chkrumaenlazada = New System.Windows.Forms.CheckBox
        Me.gridRenlazada = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btncambiagrafica = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkalmacen = New System.Windows.Forms.CheckBox
        Me.gridAlmacen = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.dtFechaFin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.dtFechaIni = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.btncambiar = New System.Windows.Forms.PictureBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.gridComposicion = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.gridTipo = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblmax = New System.Windows.Forms.Label
        Me.lblmin = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblmesesstk = New System.Windows.Forms.Label
        Me.lblpromedio = New System.Windows.Forms.Label
        Me.lblfinal = New System.Windows.Forms.Label
        Me.lblsalida = New System.Windows.Forms.Label
        Me.lblentrada = New System.Windows.Forms.Label
        Me.lblinicial = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkMineral = New System.Windows.Forms.CheckBox
        Me.gridMineral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkruma = New System.Windows.Forms.CheckBox
        Me.gridRuma = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkmes = New System.Windows.Forms.CheckBox
        Me.gridMes = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.txtayo = New System.Windows.Forms.NumericUpDown
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.gridReportenoCumple = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.tab2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.gpbHistorial = New System.Windows.Forms.GroupBox
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.gridHistorial = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.lblhist = New Infragistics.Win.Misc.UltraLabel
        Me.btnguardar = New System.Windows.Forms.Button
        Me.txtobservacion = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnexportar = New System.Windows.Forms.Button
        Me.gridReporte = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.gridReporteStock = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.girdCanteraDet1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.lblayo6 = New System.Windows.Forms.Label
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.girdCanteraDet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.gridRenlazada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaIni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btncambiar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.gridComposicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.gridTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.gridMineral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.gridRuma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        CType(Me.gridReportenoCumple, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab2.SuspendLayout()
        Me.gpbHistorial.SuspendLayout()
        CType(Me.gridHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtobservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridReporteStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.girdCanteraDet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Panel1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1645, 816)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.lblayo6)
        Me.Panel1.Controls.Add(Me.lblmensaje)
        Me.Panel1.Controls.Add(Me.girdCanteraDet)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.UltraLabel2)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.lbldefsol)
        Me.Panel1.Controls.Add(Me.lbltonsol)
        Me.Panel1.Controls.Add(Me.lbldefton)
        Me.Panel1.Controls.Add(Me.lbltonexe)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.btngraficasoles)
        Me.Panel1.Controls.Add(Me.lblfinalV)
        Me.Panel1.Controls.Add(Me.lblsalidaV)
        Me.Panel1.Controls.Add(Me.lblentradaV)
        Me.Panel1.Controls.Add(Me.lblinicialV)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.lblayo5)
        Me.Panel1.Controls.Add(Me.lblayo4)
        Me.Panel1.Controls.Add(Me.lblayo3)
        Me.Panel1.Controls.Add(Me.lblayo2)
        Me.Panel1.Controls.Add(Me.lblayo1)
        Me.Panel1.Controls.Add(Me.GroupBox7)
        Me.Panel1.Controls.Add(Me.btncambiagrafica)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.dtFechaFin)
        Me.Panel1.Controls.Add(Me.dtFechaIni)
        Me.Panel1.Controls.Add(Me.btncambiar)
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.lblmax)
        Me.Panel1.Controls.Add(Me.lblmin)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblmesesstk)
        Me.Panel1.Controls.Add(Me.lblpromedio)
        Me.Panel1.Controls.Add(Me.lblfinal)
        Me.Panel1.Controls.Add(Me.lblsalida)
        Me.Panel1.Controls.Add(Me.lblentrada)
        Me.Panel1.Controls.Add(Me.lblinicial)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Chart1)
        Me.Panel1.Controls.Add(Me.UltraLabel6)
        Me.Panel1.Controls.Add(Me.txtayo)
        Me.Panel1.Controls.Add(Me.Chart2)
        Me.Panel1.Controls.Add(Me.GroupBox8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1645, 816)
        Me.Panel1.TabIndex = 176
        '
        'lblmensaje
        '
        Me.lblmensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance26.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Appearance26.FontData.BoldAsString = "True"
        Appearance26.FontData.SizeInPoints = 10.0!
        Appearance26.ForeColor = System.Drawing.Color.SteelBlue
        Appearance26.TextHAlignAsString = "Center"
        Appearance26.TextVAlignAsString = "Middle"
        Me.lblmensaje.Appearance = Appearance26
        Me.lblmensaje.Location = New System.Drawing.Point(2, 373)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(1646, 39)
        Me.lblmensaje.TabIndex = 152
        Me.lblmensaje.Text = "Procesando..."
        Me.lblmensaje.Visible = False
        '
        'girdCanteraDet
        '
        Me.girdCanteraDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.girdCanteraDet.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance109.BackColor = System.Drawing.SystemColors.Window
        Appearance109.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.girdCanteraDet.DisplayLayout.Appearance = Appearance109
        Me.girdCanteraDet.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance110.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance110.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance110
        UltraGridColumn1.Header.Caption = " "
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 25
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 25
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Width = 255
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.VisiblePosition = 1
        UltraGridColumn3.Width = 158
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Width = 196
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Width = 142
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance104.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance104
        UltraGridColumn6.Format = "#,##0.00"
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.Width = 95
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance107.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance107
        UltraGridColumn7.Format = "#,##0.00"
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.Width = 88
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance108.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance108
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn8.Width = 108
        UltraGridColumn9.Header.VisiblePosition = 9
        UltraGridColumn9.Width = 118
        UltraGridColumn10.Header.Caption = "PROVEEDOR/CONTRATISTA"
        UltraGridColumn10.Header.VisiblePosition = 3
        UltraGridColumn10.Width = 168
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10})
        Appearance134.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance134
        SummarySettings1.DisplayFormat = "{0:###,##0}"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance175
        Appearance176.TextHAlignAsString = "Right"
        SummarySettings2.Appearance = Appearance176
        SummarySettings2.DisplayFormat = "{0:###,##0}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance177
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2})
        UltraGridBand1.SummaryFooterCaption = ""
        Me.girdCanteraDet.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.girdCanteraDet.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.girdCanteraDet.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.girdCanteraDet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.girdCanteraDet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.girdCanteraDet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.girdCanteraDet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.girdCanteraDet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.girdCanteraDet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.girdCanteraDet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.girdCanteraDet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.girdCanteraDet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.girdCanteraDet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.girdCanteraDet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.girdCanteraDet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.girdCanteraDet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion13)
        Me.girdCanteraDet.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance178.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance178.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance178.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance178.BorderColor = System.Drawing.SystemColors.Window
        Me.girdCanteraDet.DisplayLayout.GroupByBox.Appearance = Appearance178
        Appearance179.ForeColor = System.Drawing.SystemColors.GrayText
        Me.girdCanteraDet.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance179
        Me.girdCanteraDet.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.girdCanteraDet.DisplayLayout.GroupByBox.Hidden = True
        Appearance180.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance180.BackColor2 = System.Drawing.SystemColors.Control
        Appearance180.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance180.ForeColor = System.Drawing.SystemColors.GrayText
        Me.girdCanteraDet.DisplayLayout.GroupByBox.PromptAppearance = Appearance180
        Me.girdCanteraDet.DisplayLayout.MaxColScrollRegions = 1
        Me.girdCanteraDet.DisplayLayout.MaxRowScrollRegions = 1
        Me.girdCanteraDet.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.girdCanteraDet.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.girdCanteraDet.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance181.BackColor = System.Drawing.SystemColors.Window
        Me.girdCanteraDet.DisplayLayout.Override.CardAreaAppearance = Appearance181
        Appearance182.BorderColor = System.Drawing.Color.Silver
        Appearance182.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.girdCanteraDet.DisplayLayout.Override.CellAppearance = Appearance182
        Me.girdCanteraDet.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.girdCanteraDet.DisplayLayout.Override.CellPadding = 0
        Me.girdCanteraDet.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.girdCanteraDet.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.girdCanteraDet.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.girdCanteraDet.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance183.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.girdCanteraDet.DisplayLayout.Override.FilterRowAppearance = Appearance183
        Me.girdCanteraDet.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.girdCanteraDet.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.girdCanteraDet.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance184.BackColor = System.Drawing.SystemColors.Control
        Appearance184.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance184.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance184.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance184.BorderColor = System.Drawing.SystemColors.Window
        Me.girdCanteraDet.DisplayLayout.Override.GroupByRowAppearance = Appearance184
        Appearance185.FontData.Name = "Arial Narrow"
        Appearance185.FontData.SizeInPoints = 10.0!
        Appearance185.TextHAlignAsString = "Left"
        Me.girdCanteraDet.DisplayLayout.Override.HeaderAppearance = Appearance185
        Me.girdCanteraDet.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.girdCanteraDet.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.girdCanteraDet.DisplayLayout.Override.MinRowHeight = 24
        Appearance186.BackColor = System.Drawing.SystemColors.Window
        Appearance186.BorderColor = System.Drawing.Color.Silver
        Appearance186.TextVAlignAsString = "Middle"
        Me.girdCanteraDet.DisplayLayout.Override.RowAppearance = Appearance186
        Me.girdCanteraDet.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.girdCanteraDet.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.girdCanteraDet.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance187.BackColor = System.Drawing.SystemColors.ControlLight
        Me.girdCanteraDet.DisplayLayout.Override.TemplateAddRowAppearance = Appearance187
        Me.girdCanteraDet.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.girdCanteraDet.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.girdCanteraDet.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.girdCanteraDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.girdCanteraDet.Location = New System.Drawing.Point(268, 476)
        Me.girdCanteraDet.Name = "girdCanteraDet"
        Me.girdCanteraDet.Size = New System.Drawing.Size(1368, 313)
        Me.girdCanteraDet.TabIndex = 258
        Me.girdCanteraDet.Text = "UltraGrid1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(571, 74)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(196, 21)
        Me.Button1.TabIndex = 257
        Me.Button1.Text = "Detalle Cantera"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UltraLabel2
        '
        Appearance100.BackColor = System.Drawing.Color.Transparent
        Appearance100.ForeColor = System.Drawing.Color.Red
        Appearance100.TextHAlignAsString = "Center"
        Appearance100.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance100
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(859, 799)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(204, 14)
        Me.UltraLabel2.TabIndex = 256
        Me.UltraLabel2.Text = "(*) Promedio en base a rango de fechas"
        Me.UltraLabel2.Visible = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Goldenrod
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(1129, 2)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 23)
        Me.Label14.TabIndex = 255
        Me.Label14.Text = "Soles"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Goldenrod
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(1055, 2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 23)
        Me.Label15.TabIndex = 254
        Me.Label15.Text = "Ton"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbldefsol
        '
        Me.lbldefsol.BackColor = System.Drawing.Color.Goldenrod
        Me.lbldefsol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbldefsol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldefsol.ForeColor = System.Drawing.Color.Black
        Me.lbldefsol.Location = New System.Drawing.Point(1129, 48)
        Me.lbldefsol.Name = "lbldefsol"
        Me.lbldefsol.Size = New System.Drawing.Size(74, 23)
        Me.lbldefsol.TabIndex = 253
        Me.lbldefsol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbltonsol
        '
        Me.lbltonsol.BackColor = System.Drawing.Color.Goldenrod
        Me.lbltonsol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltonsol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltonsol.ForeColor = System.Drawing.Color.Black
        Me.lbltonsol.Location = New System.Drawing.Point(1129, 25)
        Me.lbltonsol.Name = "lbltonsol"
        Me.lbltonsol.Size = New System.Drawing.Size(74, 23)
        Me.lbltonsol.TabIndex = 252
        Me.lbltonsol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbldefton
        '
        Me.lbldefton.BackColor = System.Drawing.Color.Goldenrod
        Me.lbldefton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbldefton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldefton.ForeColor = System.Drawing.Color.Black
        Me.lbldefton.Location = New System.Drawing.Point(1055, 48)
        Me.lbldefton.Name = "lbldefton"
        Me.lbldefton.Size = New System.Drawing.Size(74, 23)
        Me.lbldefton.TabIndex = 251
        Me.lbldefton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbltonexe
        '
        Me.lbltonexe.BackColor = System.Drawing.Color.Goldenrod
        Me.lbltonexe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltonexe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltonexe.ForeColor = System.Drawing.Color.Black
        Me.lbltonexe.Location = New System.Drawing.Point(1055, 25)
        Me.lbltonexe.Name = "lbltonexe"
        Me.lbltonexe.Size = New System.Drawing.Size(74, 23)
        Me.lbltonexe.TabIndex = 250
        Me.lbltonexe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Goldenrod
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(968, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 23)
        Me.Label8.TabIndex = 249
        Me.Label8.Text = "Déficit"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Goldenrod
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(968, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 23)
        Me.Label9.TabIndex = 248
        Me.Label9.Text = "Excedente"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Goldenrod
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(968, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 23)
        Me.Label10.TabIndex = 247
        Me.Label10.Text = "Resultado"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btngraficasoles
        '
        Me.btngraficasoles.Location = New System.Drawing.Point(858, 73)
        Me.btngraficasoles.Name = "btngraficasoles"
        Me.btngraficasoles.Size = New System.Drawing.Size(75, 23)
        Me.btngraficasoles.TabIndex = 246
        Me.btngraficasoles.Text = "Soles"
        Me.btngraficasoles.UseVisualStyleBackColor = True
        '
        'lblfinalV
        '
        Me.lblfinalV.BackColor = System.Drawing.Color.Goldenrod
        Me.lblfinalV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblfinalV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfinalV.ForeColor = System.Drawing.Color.Black
        Me.lblfinalV.Location = New System.Drawing.Point(465, 62)
        Me.lblfinalV.Name = "lblfinalV"
        Me.lblfinalV.Size = New System.Drawing.Size(98, 32)
        Me.lblfinalV.TabIndex = 244
        Me.lblfinalV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblsalidaV
        '
        Me.lblsalidaV.BackColor = System.Drawing.Color.Goldenrod
        Me.lblsalidaV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblsalidaV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsalidaV.ForeColor = System.Drawing.Color.Black
        Me.lblsalidaV.Location = New System.Drawing.Point(367, 62)
        Me.lblsalidaV.Name = "lblsalidaV"
        Me.lblsalidaV.Size = New System.Drawing.Size(98, 32)
        Me.lblsalidaV.TabIndex = 243
        Me.lblsalidaV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblentradaV
        '
        Me.lblentradaV.BackColor = System.Drawing.Color.Goldenrod
        Me.lblentradaV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblentradaV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblentradaV.ForeColor = System.Drawing.Color.Black
        Me.lblentradaV.Location = New System.Drawing.Point(269, 62)
        Me.lblentradaV.Name = "lblentradaV"
        Me.lblentradaV.Size = New System.Drawing.Size(98, 32)
        Me.lblentradaV.TabIndex = 242
        Me.lblentradaV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblinicialV
        '
        Me.lblinicialV.BackColor = System.Drawing.Color.Goldenrod
        Me.lblinicialV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblinicialV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinicialV.ForeColor = System.Drawing.Color.Black
        Me.lblinicialV.Location = New System.Drawing.Point(171, 62)
        Me.lblinicialV.Name = "lblinicialV"
        Me.lblinicialV.Size = New System.Drawing.Size(98, 32)
        Me.lblinicialV.TabIndex = 241
        Me.lblinicialV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(1210, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(395, 20)
        Me.Label11.TabIndex = 240
        Me.Label11.Text = "Consumo promedio mensual histórico"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblayo5
        '
        Me.lblayo5.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lblayo5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblayo5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblayo5.ForeColor = System.Drawing.Color.Black
        Me.lblayo5.Location = New System.Drawing.Point(1474, 32)
        Me.lblayo5.Name = "lblayo5"
        Me.lblayo5.Size = New System.Drawing.Size(65, 36)
        Me.lblayo5.TabIndex = 239
        Me.lblayo5.Text = "Año 5"
        Me.lblayo5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblayo4
        '
        Me.lblayo4.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lblayo4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblayo4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblayo4.ForeColor = System.Drawing.Color.Black
        Me.lblayo4.Location = New System.Drawing.Point(1408, 32)
        Me.lblayo4.Name = "lblayo4"
        Me.lblayo4.Size = New System.Drawing.Size(65, 36)
        Me.lblayo4.TabIndex = 238
        Me.lblayo4.Text = "Año 4"
        Me.lblayo4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblayo3
        '
        Me.lblayo3.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lblayo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblayo3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblayo3.ForeColor = System.Drawing.Color.Black
        Me.lblayo3.Location = New System.Drawing.Point(1342, 32)
        Me.lblayo3.Name = "lblayo3"
        Me.lblayo3.Size = New System.Drawing.Size(65, 36)
        Me.lblayo3.TabIndex = 237
        Me.lblayo3.Text = "Año 3"
        Me.lblayo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblayo2
        '
        Me.lblayo2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lblayo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblayo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblayo2.ForeColor = System.Drawing.Color.Black
        Me.lblayo2.Location = New System.Drawing.Point(1276, 32)
        Me.lblayo2.Name = "lblayo2"
        Me.lblayo2.Size = New System.Drawing.Size(65, 36)
        Me.lblayo2.TabIndex = 236
        Me.lblayo2.Text = "Año 2"
        Me.lblayo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblayo1
        '
        Me.lblayo1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lblayo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblayo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblayo1.ForeColor = System.Drawing.Color.Black
        Me.lblayo1.Location = New System.Drawing.Point(1210, 32)
        Me.lblayo1.Name = "lblayo1"
        Me.lblayo1.Size = New System.Drawing.Size(65, 36)
        Me.lblayo1.TabIndex = 235
        Me.lblayo1.Text = "Año 1"
        Me.lblayo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.chkrumaenlazada)
        Me.GroupBox7.Controls.Add(Me.gridRenlazada)
        Me.GroupBox7.Location = New System.Drawing.Point(20, 484)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(242, 305)
        Me.GroupBox7.TabIndex = 234
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Ruma enlazada a otro almacén"
        '
        'chkrumaenlazada
        '
        Me.chkrumaenlazada.AutoSize = True
        Me.chkrumaenlazada.Location = New System.Drawing.Point(12, 21)
        Me.chkrumaenlazada.Name = "chkrumaenlazada"
        Me.chkrumaenlazada.Size = New System.Drawing.Size(15, 14)
        Me.chkrumaenlazada.TabIndex = 245
        Me.chkrumaenlazada.UseVisualStyleBackColor = True
        '
        'gridRenlazada
        '
        Me.gridRenlazada.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance258.BackColor = System.Drawing.SystemColors.Window
        Appearance258.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridRenlazada.DisplayLayout.Appearance = Appearance258
        Me.gridRenlazada.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance259.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance259.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn11.Header.Appearance = Appearance259
        UltraGridColumn11.Header.Caption = " "
        UltraGridColumn11.Header.VisiblePosition = 0
        UltraGridColumn11.MaxWidth = 25
        UltraGridColumn11.MinWidth = 25
        UltraGridColumn11.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn11.Width = 25
        UltraGridColumn12.Header.Caption = "RUMA"
        UltraGridColumn12.Header.VisiblePosition = 1
        UltraGridColumn12.Width = 46
        UltraGridColumn13.Header.VisiblePosition = 2
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.Width = 11
        UltraGridColumn14.Header.VisiblePosition = 3
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.Width = 19
        UltraGridColumn15.Header.VisiblePosition = 4
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 37
        UltraGridColumn16.Header.Caption = "MINERAL"
        UltraGridColumn16.Header.VisiblePosition = 5
        UltraGridColumn16.Width = 129
        UltraGridColumn17.Header.VisiblePosition = 6
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 66
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17})
        Me.gridRenlazada.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridRenlazada.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridRenlazada.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridRenlazada.DisplayLayout.ColScrollRegions.Add(ColScrollRegion14)
        Me.gridRenlazada.DisplayLayout.ColScrollRegions.Add(ColScrollRegion15)
        Me.gridRenlazada.DisplayLayout.ColScrollRegions.Add(ColScrollRegion16)
        Me.gridRenlazada.DisplayLayout.ColScrollRegions.Add(ColScrollRegion17)
        Me.gridRenlazada.DisplayLayout.ColScrollRegions.Add(ColScrollRegion18)
        Me.gridRenlazada.DisplayLayout.ColScrollRegions.Add(ColScrollRegion19)
        Me.gridRenlazada.DisplayLayout.ColScrollRegions.Add(ColScrollRegion20)
        Me.gridRenlazada.DisplayLayout.ColScrollRegions.Add(ColScrollRegion21)
        Me.gridRenlazada.DisplayLayout.ColScrollRegions.Add(ColScrollRegion22)
        Me.gridRenlazada.DisplayLayout.ColScrollRegions.Add(ColScrollRegion23)
        Me.gridRenlazada.DisplayLayout.ColScrollRegions.Add(ColScrollRegion24)
        Me.gridRenlazada.DisplayLayout.ColScrollRegions.Add(ColScrollRegion25)
        Me.gridRenlazada.DisplayLayout.ColScrollRegions.Add(ColScrollRegion26)
        Me.gridRenlazada.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance260.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance260.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance260.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance260.BorderColor = System.Drawing.SystemColors.Window
        Me.gridRenlazada.DisplayLayout.GroupByBox.Appearance = Appearance260
        Appearance261.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridRenlazada.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance261
        Me.gridRenlazada.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridRenlazada.DisplayLayout.GroupByBox.Hidden = True
        Appearance262.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance262.BackColor2 = System.Drawing.SystemColors.Control
        Appearance262.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance262.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridRenlazada.DisplayLayout.GroupByBox.PromptAppearance = Appearance262
        Me.gridRenlazada.DisplayLayout.MaxColScrollRegions = 1
        Me.gridRenlazada.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridRenlazada.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridRenlazada.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridRenlazada.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance263.BackColor = System.Drawing.SystemColors.Window
        Me.gridRenlazada.DisplayLayout.Override.CardAreaAppearance = Appearance263
        Appearance264.BorderColor = System.Drawing.Color.Silver
        Appearance264.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridRenlazada.DisplayLayout.Override.CellAppearance = Appearance264
        Me.gridRenlazada.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridRenlazada.DisplayLayout.Override.CellPadding = 0
        Me.gridRenlazada.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridRenlazada.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridRenlazada.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridRenlazada.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance265.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridRenlazada.DisplayLayout.Override.FilterRowAppearance = Appearance265
        Me.gridRenlazada.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridRenlazada.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridRenlazada.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance266.BackColor = System.Drawing.SystemColors.Control
        Appearance266.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance266.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance266.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance266.BorderColor = System.Drawing.SystemColors.Window
        Me.gridRenlazada.DisplayLayout.Override.GroupByRowAppearance = Appearance266
        Appearance267.FontData.Name = "Arial Narrow"
        Appearance267.FontData.SizeInPoints = 10.0!
        Appearance267.TextHAlignAsString = "Left"
        Me.gridRenlazada.DisplayLayout.Override.HeaderAppearance = Appearance267
        Me.gridRenlazada.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridRenlazada.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridRenlazada.DisplayLayout.Override.MinRowHeight = 24
        Appearance268.BackColor = System.Drawing.SystemColors.Window
        Appearance268.BorderColor = System.Drawing.Color.Silver
        Appearance268.TextVAlignAsString = "Middle"
        Me.gridRenlazada.DisplayLayout.Override.RowAppearance = Appearance268
        Me.gridRenlazada.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridRenlazada.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridRenlazada.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance269.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridRenlazada.DisplayLayout.Override.TemplateAddRowAppearance = Appearance269
        Me.gridRenlazada.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridRenlazada.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridRenlazada.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridRenlazada.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridRenlazada.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridRenlazada.Location = New System.Drawing.Point(3, 16)
        Me.gridRenlazada.Name = "gridRenlazada"
        Me.gridRenlazada.Size = New System.Drawing.Size(236, 286)
        Me.gridRenlazada.TabIndex = 175
        Me.gridRenlazada.Text = "UltraGrid1"
        '
        'btncambiagrafica
        '
        Me.btncambiagrafica.Location = New System.Drawing.Point(777, 73)
        Me.btncambiagrafica.Name = "btncambiagrafica"
        Me.btncambiagrafica.Size = New System.Drawing.Size(75, 23)
        Me.btncambiagrafica.TabIndex = 232
        Me.btncambiagrafica.Text = "Toneladas"
        Me.btncambiagrafica.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkalmacen)
        Me.GroupBox2.Controls.Add(Me.gridAlmacen)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 88)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(190, 262)
        Me.GroupBox2.TabIndex = 209
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Almacén"
        '
        'chkalmacen
        '
        Me.chkalmacen.AutoSize = True
        Me.chkalmacen.Location = New System.Drawing.Point(42, 54)
        Me.chkalmacen.Name = "chkalmacen"
        Me.chkalmacen.Size = New System.Drawing.Size(15, 14)
        Me.chkalmacen.TabIndex = 174
        Me.chkalmacen.UseVisualStyleBackColor = True
        '
        'gridAlmacen
        '
        Me.gridAlmacen.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance36.BackColor = System.Drawing.SystemColors.Window
        Appearance36.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridAlmacen.DisplayLayout.Appearance = Appearance36
        Me.gridAlmacen.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn18.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance37.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance37.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn18.Header.Appearance = Appearance37
        UltraGridColumn18.Header.Caption = " "
        UltraGridColumn18.Header.VisiblePosition = 0
        UltraGridColumn18.MaxWidth = 25
        UltraGridColumn18.MinWidth = 25
        UltraGridColumn18.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn18.Width = 25
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn19.Header.VisiblePosition = 1
        UltraGridColumn19.Width = 123
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn20.Header.VisiblePosition = 2
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.Width = 53
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn21.Header.VisiblePosition = 3
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 64
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21})
        Me.gridAlmacen.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.gridAlmacen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridAlmacen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridAlmacen.DisplayLayout.ColScrollRegions.Add(ColScrollRegion27)
        Me.gridAlmacen.DisplayLayout.ColScrollRegions.Add(ColScrollRegion28)
        Me.gridAlmacen.DisplayLayout.ColScrollRegions.Add(ColScrollRegion29)
        Me.gridAlmacen.DisplayLayout.ColScrollRegions.Add(ColScrollRegion30)
        Me.gridAlmacen.DisplayLayout.ColScrollRegions.Add(ColScrollRegion31)
        Me.gridAlmacen.DisplayLayout.ColScrollRegions.Add(ColScrollRegion32)
        Me.gridAlmacen.DisplayLayout.ColScrollRegions.Add(ColScrollRegion33)
        Me.gridAlmacen.DisplayLayout.ColScrollRegions.Add(ColScrollRegion34)
        Me.gridAlmacen.DisplayLayout.ColScrollRegions.Add(ColScrollRegion35)
        Me.gridAlmacen.DisplayLayout.ColScrollRegions.Add(ColScrollRegion36)
        Me.gridAlmacen.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance38.BorderColor = System.Drawing.SystemColors.Window
        Me.gridAlmacen.DisplayLayout.GroupByBox.Appearance = Appearance38
        Appearance39.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridAlmacen.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance39
        Me.gridAlmacen.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridAlmacen.DisplayLayout.GroupByBox.Hidden = True
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance40.BackColor2 = System.Drawing.SystemColors.Control
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridAlmacen.DisplayLayout.GroupByBox.PromptAppearance = Appearance40
        Me.gridAlmacen.DisplayLayout.MaxColScrollRegions = 1
        Me.gridAlmacen.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridAlmacen.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridAlmacen.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridAlmacen.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance41.BackColor = System.Drawing.SystemColors.Window
        Me.gridAlmacen.DisplayLayout.Override.CardAreaAppearance = Appearance41
        Appearance42.BorderColor = System.Drawing.Color.Silver
        Appearance42.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridAlmacen.DisplayLayout.Override.CellAppearance = Appearance42
        Me.gridAlmacen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridAlmacen.DisplayLayout.Override.CellPadding = 0
        Me.gridAlmacen.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridAlmacen.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridAlmacen.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridAlmacen.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance44.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridAlmacen.DisplayLayout.Override.FilterRowAppearance = Appearance44
        Me.gridAlmacen.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridAlmacen.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridAlmacen.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance45.BackColor = System.Drawing.SystemColors.Control
        Appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance45.BorderColor = System.Drawing.SystemColors.Window
        Me.gridAlmacen.DisplayLayout.Override.GroupByRowAppearance = Appearance45
        Appearance46.FontData.Name = "Arial Narrow"
        Appearance46.FontData.SizeInPoints = 10.0!
        Appearance46.TextHAlignAsString = "Left"
        Me.gridAlmacen.DisplayLayout.Override.HeaderAppearance = Appearance46
        Me.gridAlmacen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridAlmacen.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridAlmacen.DisplayLayout.Override.MinRowHeight = 24
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Appearance53.BorderColor = System.Drawing.Color.Silver
        Appearance53.TextVAlignAsString = "Middle"
        Me.gridAlmacen.DisplayLayout.Override.RowAppearance = Appearance53
        Me.gridAlmacen.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridAlmacen.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridAlmacen.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance54.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridAlmacen.DisplayLayout.Override.TemplateAddRowAppearance = Appearance54
        Me.gridAlmacen.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridAlmacen.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridAlmacen.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridAlmacen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridAlmacen.Location = New System.Drawing.Point(3, 16)
        Me.gridAlmacen.Name = "gridAlmacen"
        Me.gridAlmacen.Size = New System.Drawing.Size(184, 243)
        Me.gridAlmacen.TabIndex = 173
        Me.gridAlmacen.Text = "UltraGrid1"
        '
        'dtFechaFin
        '
        Me.dtFechaFin.AutoSize = False
        Me.dtFechaFin.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtFechaFin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtFechaFin.Location = New System.Drawing.Point(13, 50)
        Me.dtFechaFin.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtFechaFin.Name = "dtFechaFin"
        Me.dtFechaFin.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtFechaFin.Size = New System.Drawing.Size(147, 18)
        Me.dtFechaFin.TabIndex = 231
        Me.dtFechaFin.TabStop = False
        Me.dtFechaFin.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'dtFechaIni
        '
        Me.dtFechaIni.AutoSize = False
        Me.dtFechaIni.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtFechaIni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtFechaIni.Location = New System.Drawing.Point(13, 26)
        Me.dtFechaIni.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtFechaIni.Name = "dtFechaIni"
        Me.dtFechaIni.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtFechaIni.Size = New System.Drawing.Size(147, 18)
        Me.dtFechaIni.TabIndex = 230
        Me.dtFechaIni.TabStop = False
        Me.dtFechaIni.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'btncambiar
        '
        Me.btncambiar.Image = Global.SIP_Presentacion.My.Resources.Resources.Actualizar
        Me.btncambiar.Location = New System.Drawing.Point(937, 2)
        Me.btncambiar.Name = "btncambiar"
        Me.btncambiar.Size = New System.Drawing.Size(29, 26)
        Me.btncambiar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btncambiar.TabIndex = 229
        Me.btncambiar.TabStop = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.gridComposicion)
        Me.GroupBox6.Location = New System.Drawing.Point(1066, 760)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(77, 45)
        Me.GroupBox6.TabIndex = 228
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Composición del Inventario"
        Me.GroupBox6.Visible = False
        '
        'gridComposicion
        '
        Me.gridComposicion.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridComposicion.DisplayLayout.Appearance = Appearance14
        Me.gridComposicion.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn22.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance15.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn22.Header.Appearance = Appearance15
        UltraGridColumn22.Header.Caption = " "
        UltraGridColumn22.Header.VisiblePosition = 0
        UltraGridColumn22.MaxWidth = 25
        UltraGridColumn22.MinWidth = 25
        UltraGridColumn22.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn22.Width = 25
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn23.Header.VisiblePosition = 1
        UltraGridColumn23.Width = 8
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn24.Header.Caption = "RUMA"
        UltraGridColumn24.Header.VisiblePosition = 2
        UltraGridColumn24.Width = 8
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn25.Header.VisiblePosition = 3
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.Width = 141
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance98.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance98
        UltraGridColumn26.Header.VisiblePosition = 4
        UltraGridColumn26.Width = 8
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26})
        Appearance94.TextHAlignAsString = "Right"
        SummarySettings3.Appearance = Appearance94
        SummarySettings3.DisplayFormat = "Total:"
        SummarySettings3.GroupBySummaryValueAppearance = Appearance95
        Appearance96.TextHAlignAsString = "Right"
        SummarySettings4.Appearance = Appearance96
        SummarySettings4.DisplayFormat = "{0}"
        SummarySettings4.GroupBySummaryValueAppearance = Appearance97
        UltraGridBand4.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings3, SummarySettings4})
        UltraGridBand4.SummaryFooterCaption = ""
        Me.gridComposicion.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.gridComposicion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridComposicion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridComposicion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion37)
        Me.gridComposicion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion38)
        Me.gridComposicion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion39)
        Me.gridComposicion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion40)
        Me.gridComposicion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion41)
        Me.gridComposicion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion42)
        Me.gridComposicion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion43)
        Me.gridComposicion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion44)
        Me.gridComposicion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion45)
        Me.gridComposicion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion46)
        Me.gridComposicion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion47)
        Me.gridComposicion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion48)
        Me.gridComposicion.DisplayLayout.ColScrollRegions.Add(ColScrollRegion49)
        Me.gridComposicion.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.gridComposicion.DisplayLayout.GroupByBox.Appearance = Appearance16
        Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridComposicion.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance20
        Me.gridComposicion.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridComposicion.DisplayLayout.GroupByBox.Hidden = True
        Appearance21.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance21.BackColor2 = System.Drawing.SystemColors.Control
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridComposicion.DisplayLayout.GroupByBox.PromptAppearance = Appearance21
        Me.gridComposicion.DisplayLayout.MaxColScrollRegions = 1
        Me.gridComposicion.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridComposicion.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridComposicion.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridComposicion.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Me.gridComposicion.DisplayLayout.Override.CardAreaAppearance = Appearance22
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Appearance23.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridComposicion.DisplayLayout.Override.CellAppearance = Appearance23
        Me.gridComposicion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridComposicion.DisplayLayout.Override.CellPadding = 0
        Me.gridComposicion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridComposicion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridComposicion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridComposicion.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance25.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridComposicion.DisplayLayout.Override.FilterRowAppearance = Appearance25
        Me.gridComposicion.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridComposicion.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridComposicion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance99.BackColor = System.Drawing.SystemColors.Control
        Appearance99.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance99.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance99.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance99.BorderColor = System.Drawing.SystemColors.Window
        Me.gridComposicion.DisplayLayout.Override.GroupByRowAppearance = Appearance99
        Appearance27.FontData.Name = "Arial Narrow"
        Appearance27.FontData.SizeInPoints = 10.0!
        Appearance27.TextHAlignAsString = "Left"
        Me.gridComposicion.DisplayLayout.Override.HeaderAppearance = Appearance27
        Me.gridComposicion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridComposicion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridComposicion.DisplayLayout.Override.MinRowHeight = 24
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.BorderColor = System.Drawing.Color.Silver
        Appearance28.TextVAlignAsString = "Middle"
        Me.gridComposicion.DisplayLayout.Override.RowAppearance = Appearance28
        Me.gridComposicion.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridComposicion.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridComposicion.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance29.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridComposicion.DisplayLayout.Override.TemplateAddRowAppearance = Appearance29
        Me.gridComposicion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridComposicion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridComposicion.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridComposicion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridComposicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridComposicion.Location = New System.Drawing.Point(3, 16)
        Me.gridComposicion.Name = "gridComposicion"
        Me.gridComposicion.Size = New System.Drawing.Size(71, 26)
        Me.gridComposicion.TabIndex = 174
        Me.gridComposicion.Text = "UltraGrid1"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.gridTipo)
        Me.GroupBox5.Location = New System.Drawing.Point(17, 357)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(190, 121)
        Me.GroupBox5.TabIndex = 227
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Tipo de Ingreso"
        '
        'gridTipo
        '
        Me.gridTipo.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance72.BackColor = System.Drawing.SystemColors.Window
        Appearance72.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridTipo.DisplayLayout.Appearance = Appearance72
        Me.gridTipo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn27.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance73.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance73.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn27.Header.Appearance = Appearance73
        UltraGridColumn27.Header.Caption = " "
        UltraGridColumn27.Header.VisiblePosition = 0
        UltraGridColumn27.MaxWidth = 25
        UltraGridColumn27.MinWidth = 25
        UltraGridColumn27.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn27.Width = 25
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn28.Header.VisiblePosition = 1
        UltraGridColumn28.Width = 106
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn29.Header.VisiblePosition = 2
        UltraGridColumn29.Hidden = True
        UltraGridColumn29.Width = 53
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn27, UltraGridColumn28, UltraGridColumn29})
        Me.gridTipo.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.gridTipo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridTipo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridTipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion50)
        Me.gridTipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion51)
        Me.gridTipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion52)
        Me.gridTipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion53)
        Me.gridTipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion54)
        Me.gridTipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion55)
        Me.gridTipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion56)
        Me.gridTipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion57)
        Me.gridTipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion58)
        Me.gridTipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion59)
        Me.gridTipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion60)
        Me.gridTipo.DisplayLayout.ColScrollRegions.Add(ColScrollRegion61)
        Me.gridTipo.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance74.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance74.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance74.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance74.BorderColor = System.Drawing.SystemColors.Window
        Me.gridTipo.DisplayLayout.GroupByBox.Appearance = Appearance74
        Appearance75.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridTipo.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance75
        Me.gridTipo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridTipo.DisplayLayout.GroupByBox.Hidden = True
        Appearance79.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance79.BackColor2 = System.Drawing.SystemColors.Control
        Appearance79.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance79.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridTipo.DisplayLayout.GroupByBox.PromptAppearance = Appearance79
        Me.gridTipo.DisplayLayout.MaxColScrollRegions = 1
        Me.gridTipo.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridTipo.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridTipo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridTipo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance87.BackColor = System.Drawing.SystemColors.Window
        Me.gridTipo.DisplayLayout.Override.CardAreaAppearance = Appearance87
        Appearance88.BorderColor = System.Drawing.Color.Silver
        Appearance88.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridTipo.DisplayLayout.Override.CellAppearance = Appearance88
        Me.gridTipo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridTipo.DisplayLayout.Override.CellPadding = 0
        Me.gridTipo.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridTipo.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridTipo.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridTipo.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance89.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridTipo.DisplayLayout.Override.FilterRowAppearance = Appearance89
        Me.gridTipo.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridTipo.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance90.BackColor = System.Drawing.SystemColors.Control
        Appearance90.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance90.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance90.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance90.BorderColor = System.Drawing.SystemColors.Window
        Me.gridTipo.DisplayLayout.Override.GroupByRowAppearance = Appearance90
        Appearance91.FontData.Name = "Arial Narrow"
        Appearance91.FontData.SizeInPoints = 10.0!
        Appearance91.TextHAlignAsString = "Left"
        Me.gridTipo.DisplayLayout.Override.HeaderAppearance = Appearance91
        Me.gridTipo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridTipo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridTipo.DisplayLayout.Override.MinRowHeight = 24
        Appearance92.BackColor = System.Drawing.SystemColors.Window
        Appearance92.BorderColor = System.Drawing.Color.Silver
        Appearance92.TextVAlignAsString = "Middle"
        Me.gridTipo.DisplayLayout.Override.RowAppearance = Appearance92
        Me.gridTipo.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridTipo.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridTipo.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance93.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridTipo.DisplayLayout.Override.TemplateAddRowAppearance = Appearance93
        Me.gridTipo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridTipo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridTipo.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridTipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridTipo.Location = New System.Drawing.Point(3, 16)
        Me.gridTipo.Name = "gridTipo"
        Me.gridTipo.Size = New System.Drawing.Size(184, 102)
        Me.gridTipo.TabIndex = 174
        Me.gridTipo.Text = "UltraGrid1"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.LightGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(777, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(859, 24)
        Me.Label5.TabIndex = 225
        Me.Label5.Text = "Gráfica de toneladas"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblmax
        '
        Me.lblmax.BackColor = System.Drawing.Color.Goldenrod
        Me.lblmax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblmax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmax.ForeColor = System.Drawing.Color.Black
        Me.lblmax.Location = New System.Drawing.Point(852, 48)
        Me.lblmax.Name = "lblmax"
        Me.lblmax.Size = New System.Drawing.Size(84, 23)
        Me.lblmax.TabIndex = 223
        Me.lblmax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblmin
        '
        Me.lblmin.BackColor = System.Drawing.Color.Goldenrod
        Me.lblmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmin.ForeColor = System.Drawing.Color.Black
        Me.lblmin.Location = New System.Drawing.Point(852, 25)
        Me.lblmin.Name = "lblmin"
        Me.lblmin.Size = New System.Drawing.Size(84, 23)
        Me.lblmin.TabIndex = 222
        Me.lblmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Goldenrod
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(789, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 23)
        Me.Label4.TabIndex = 221
        Me.Label4.Text = "Máx."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Goldenrod
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(789, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 23)
        Me.Label3.TabIndex = 220
        Me.Label3.Text = "Mín."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Goldenrod
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(789, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 23)
        Me.Label2.TabIndex = 219
        Me.Label2.Text = "Política de Inv."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblmesesstk
        '
        Me.lblmesesstk.BackColor = System.Drawing.Color.LightGray
        Me.lblmesesstk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblmesesstk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmesesstk.ForeColor = System.Drawing.Color.Black
        Me.lblmesesstk.Location = New System.Drawing.Point(697, 11)
        Me.lblmesesstk.Name = "lblmesesstk"
        Me.lblmesesstk.Size = New System.Drawing.Size(89, 58)
        Me.lblmesesstk.TabIndex = 218
        Me.lblmesesstk.Text = "Meses en Stock"
        Me.lblmesesstk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblpromedio
        '
        Me.lblpromedio.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lblpromedio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblpromedio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpromedio.ForeColor = System.Drawing.Color.Black
        Me.lblpromedio.Location = New System.Drawing.Point(567, 11)
        Me.lblpromedio.Name = "lblpromedio"
        Me.lblpromedio.Size = New System.Drawing.Size(128, 58)
        Me.lblpromedio.TabIndex = 217
        Me.lblpromedio.Text = "Promedio Máx. Consumo mensual"
        Me.lblpromedio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblfinal
        '
        Me.lblfinal.BackColor = System.Drawing.Color.Goldenrod
        Me.lblfinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblfinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfinal.ForeColor = System.Drawing.Color.Black
        Me.lblfinal.Location = New System.Drawing.Point(465, 27)
        Me.lblfinal.Name = "lblfinal"
        Me.lblfinal.Size = New System.Drawing.Size(98, 34)
        Me.lblfinal.TabIndex = 216
        Me.lblfinal.Text = "Saldo Final"
        Me.lblfinal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblsalida
        '
        Me.lblsalida.BackColor = System.Drawing.Color.Goldenrod
        Me.lblsalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblsalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsalida.ForeColor = System.Drawing.Color.Black
        Me.lblsalida.Location = New System.Drawing.Point(367, 27)
        Me.lblsalida.Name = "lblsalida"
        Me.lblsalida.Size = New System.Drawing.Size(98, 34)
        Me.lblsalida.TabIndex = 215
        Me.lblsalida.Text = "Salidas"
        Me.lblsalida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblentrada
        '
        Me.lblentrada.BackColor = System.Drawing.Color.Goldenrod
        Me.lblentrada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblentrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblentrada.ForeColor = System.Drawing.Color.Black
        Me.lblentrada.Location = New System.Drawing.Point(269, 27)
        Me.lblentrada.Name = "lblentrada"
        Me.lblentrada.Size = New System.Drawing.Size(98, 34)
        Me.lblentrada.TabIndex = 214
        Me.lblentrada.Text = "Entradas"
        Me.lblentrada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblinicial
        '
        Me.lblinicial.BackColor = System.Drawing.Color.Goldenrod
        Me.lblinicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblinicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinicial.ForeColor = System.Drawing.Color.Black
        Me.lblinicial.Location = New System.Drawing.Point(171, 27)
        Me.lblinicial.Name = "lblinicial"
        Me.lblinicial.Size = New System.Drawing.Size(98, 34)
        Me.lblinicial.TabIndex = 213
        Me.lblinicial.Text = "Invt. Inicial"
        Me.lblinicial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Goldenrod
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(171, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(392, 23)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "Movimientos Minas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkMineral)
        Me.GroupBox4.Controls.Add(Me.gridMineral)
        Me.GroupBox4.Location = New System.Drawing.Point(490, 98)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(281, 355)
        Me.GroupBox4.TabIndex = 211
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Mineral"
        '
        'chkMineral
        '
        Me.chkMineral.AutoSize = True
        Me.chkMineral.Location = New System.Drawing.Point(43, 55)
        Me.chkMineral.Name = "chkMineral"
        Me.chkMineral.Size = New System.Drawing.Size(15, 14)
        Me.chkMineral.TabIndex = 176
        Me.chkMineral.UseVisualStyleBackColor = True
        '
        'gridMineral
        '
        Me.gridMineral.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance105.BackColor = System.Drawing.SystemColors.Window
        Appearance105.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridMineral.DisplayLayout.Appearance = Appearance105
        Me.gridMineral.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn30.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance106.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance106.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn30.Header.Appearance = Appearance106
        UltraGridColumn30.Header.Caption = " "
        UltraGridColumn30.Header.VisiblePosition = 0
        UltraGridColumn30.MaxWidth = 25
        UltraGridColumn30.MinWidth = 25
        UltraGridColumn30.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn30.Width = 25
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn31.Header.Caption = "MINERAL"
        UltraGridColumn31.Header.VisiblePosition = 1
        UltraGridColumn31.Width = 214
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn32.Header.VisiblePosition = 2
        UltraGridColumn32.Hidden = True
        UltraGridColumn32.Width = 38
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn33.Header.VisiblePosition = 3
        UltraGridColumn33.Hidden = True
        UltraGridColumn33.Width = 90
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn34.Header.VisiblePosition = 4
        UltraGridColumn34.Hidden = True
        UltraGridColumn34.Width = 53
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn35.Header.VisiblePosition = 5
        UltraGridColumn35.Hidden = True
        UltraGridColumn35.Width = 61
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn36.Header.VisiblePosition = 6
        UltraGridColumn36.Hidden = True
        UltraGridColumn36.Width = 63
        UltraGridBand6.Columns.AddRange(New Object() {UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36})
        Me.gridMineral.DisplayLayout.BandsSerializer.Add(UltraGridBand6)
        Me.gridMineral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridMineral.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion62)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion63)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion64)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion65)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion66)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion67)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion68)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion69)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion70)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion71)
        Me.gridMineral.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance76.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance76.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance76.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance76.BorderColor = System.Drawing.SystemColors.Window
        Me.gridMineral.DisplayLayout.GroupByBox.Appearance = Appearance76
        Appearance77.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridMineral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance77
        Me.gridMineral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridMineral.DisplayLayout.GroupByBox.Hidden = True
        Appearance78.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance78.BackColor2 = System.Drawing.SystemColors.Control
        Appearance78.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance78.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridMineral.DisplayLayout.GroupByBox.PromptAppearance = Appearance78
        Me.gridMineral.DisplayLayout.MaxColScrollRegions = 1
        Me.gridMineral.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridMineral.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridMineral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridMineral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance80.BackColor = System.Drawing.SystemColors.Window
        Me.gridMineral.DisplayLayout.Override.CardAreaAppearance = Appearance80
        Appearance81.BorderColor = System.Drawing.Color.Silver
        Appearance81.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridMineral.DisplayLayout.Override.CellAppearance = Appearance81
        Me.gridMineral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridMineral.DisplayLayout.Override.CellPadding = 0
        Me.gridMineral.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridMineral.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridMineral.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridMineral.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance82.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridMineral.DisplayLayout.Override.FilterRowAppearance = Appearance82
        Me.gridMineral.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridMineral.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridMineral.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance83.BackColor = System.Drawing.SystemColors.Control
        Appearance83.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance83.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance83.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance83.BorderColor = System.Drawing.SystemColors.Window
        Me.gridMineral.DisplayLayout.Override.GroupByRowAppearance = Appearance83
        Appearance84.FontData.Name = "Arial Narrow"
        Appearance84.FontData.SizeInPoints = 10.0!
        Appearance84.TextHAlignAsString = "Left"
        Me.gridMineral.DisplayLayout.Override.HeaderAppearance = Appearance84
        Me.gridMineral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridMineral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridMineral.DisplayLayout.Override.MinRowHeight = 24
        Appearance138.BackColor = System.Drawing.SystemColors.Window
        Appearance138.BorderColor = System.Drawing.Color.Silver
        Appearance138.TextVAlignAsString = "Middle"
        Me.gridMineral.DisplayLayout.Override.RowAppearance = Appearance138
        Me.gridMineral.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridMineral.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridMineral.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance86.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridMineral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance86
        Me.gridMineral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridMineral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridMineral.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridMineral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridMineral.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridMineral.Location = New System.Drawing.Point(3, 16)
        Me.gridMineral.Name = "gridMineral"
        Me.gridMineral.Size = New System.Drawing.Size(275, 336)
        Me.gridMineral.TabIndex = 173
        Me.gridMineral.Text = "UltraGrid1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkruma)
        Me.GroupBox3.Controls.Add(Me.gridRuma)
        Me.GroupBox3.Location = New System.Drawing.Point(213, 98)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(274, 355)
        Me.GroupBox3.TabIndex = 210
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Ruma"
        '
        'chkruma
        '
        Me.chkruma.AutoSize = True
        Me.chkruma.Location = New System.Drawing.Point(43, 54)
        Me.chkruma.Name = "chkruma"
        Me.chkruma.Size = New System.Drawing.Size(15, 14)
        Me.chkruma.TabIndex = 175
        Me.chkruma.UseVisualStyleBackColor = True
        '
        'gridRuma
        '
        Me.gridRuma.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance55.BackColor = System.Drawing.SystemColors.Window
        Appearance55.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridRuma.DisplayLayout.Appearance = Appearance55
        Me.gridRuma.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn37.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance56.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance56.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn37.Header.Appearance = Appearance56
        UltraGridColumn37.Header.Caption = " "
        UltraGridColumn37.Header.VisiblePosition = 0
        UltraGridColumn37.MaxWidth = 25
        UltraGridColumn37.MinWidth = 25
        UltraGridColumn37.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn37.Width = 25
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn38.Header.Caption = "RUMA"
        UltraGridColumn38.Header.VisiblePosition = 1
        UltraGridColumn38.Width = 207
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn39.Header.VisiblePosition = 2
        UltraGridColumn39.Hidden = True
        UltraGridColumn39.Width = 38
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn40.Header.VisiblePosition = 3
        UltraGridColumn40.Hidden = True
        UltraGridColumn40.Width = 90
        UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn41.Header.VisiblePosition = 4
        UltraGridColumn41.Hidden = True
        UltraGridColumn41.Width = 62
        UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn42.Header.VisiblePosition = 5
        UltraGridColumn42.Hidden = True
        UltraGridColumn42.Width = 63
        UltraGridBand7.Columns.AddRange(New Object() {UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42})
        Me.gridRuma.DisplayLayout.BandsSerializer.Add(UltraGridBand7)
        Me.gridRuma.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridRuma.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion72)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion73)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion74)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion75)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion76)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion77)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion78)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion79)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion80)
        Me.gridRuma.DisplayLayout.ColScrollRegions.Add(ColScrollRegion81)
        Me.gridRuma.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance57.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance57.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance57.BorderColor = System.Drawing.SystemColors.Window
        Me.gridRuma.DisplayLayout.GroupByBox.Appearance = Appearance57
        Appearance58.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridRuma.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance58
        Me.gridRuma.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridRuma.DisplayLayout.GroupByBox.Hidden = True
        Appearance59.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance59.BackColor2 = System.Drawing.SystemColors.Control
        Appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance59.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridRuma.DisplayLayout.GroupByBox.PromptAppearance = Appearance59
        Me.gridRuma.DisplayLayout.MaxColScrollRegions = 1
        Me.gridRuma.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridRuma.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridRuma.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridRuma.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance60.BackColor = System.Drawing.SystemColors.Window
        Me.gridRuma.DisplayLayout.Override.CardAreaAppearance = Appearance60
        Appearance61.BorderColor = System.Drawing.Color.Silver
        Appearance61.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridRuma.DisplayLayout.Override.CellAppearance = Appearance61
        Me.gridRuma.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridRuma.DisplayLayout.Override.CellPadding = 0
        Me.gridRuma.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridRuma.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridRuma.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridRuma.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance62.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridRuma.DisplayLayout.Override.FilterRowAppearance = Appearance62
        Me.gridRuma.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridRuma.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridRuma.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance63.BackColor = System.Drawing.SystemColors.Control
        Appearance63.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance63.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance63.BorderColor = System.Drawing.SystemColors.Window
        Me.gridRuma.DisplayLayout.Override.GroupByRowAppearance = Appearance63
        Appearance64.FontData.Name = "Arial Narrow"
        Appearance64.FontData.SizeInPoints = 10.0!
        Appearance64.TextHAlignAsString = "Left"
        Me.gridRuma.DisplayLayout.Override.HeaderAppearance = Appearance64
        Me.gridRuma.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridRuma.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridRuma.DisplayLayout.Override.MinRowHeight = 24
        Appearance65.BackColor = System.Drawing.SystemColors.Window
        Appearance65.BorderColor = System.Drawing.Color.Silver
        Appearance65.TextVAlignAsString = "Middle"
        Me.gridRuma.DisplayLayout.Override.RowAppearance = Appearance65
        Me.gridRuma.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridRuma.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridRuma.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance66.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridRuma.DisplayLayout.Override.TemplateAddRowAppearance = Appearance66
        Me.gridRuma.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridRuma.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridRuma.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridRuma.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridRuma.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridRuma.Location = New System.Drawing.Point(3, 16)
        Me.gridRuma.Name = "gridRuma"
        Me.gridRuma.Size = New System.Drawing.Size(268, 336)
        Me.gridRuma.TabIndex = 173
        Me.gridRuma.Text = "UltraGrid1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkmes)
        Me.GroupBox1.Controls.Add(Me.gridMes)
        Me.GroupBox1.Location = New System.Drawing.Point(391, 241)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(71, 56)
        Me.GroupBox1.TabIndex = 208
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Meses"
        '
        'chkmes
        '
        Me.chkmes.AutoSize = True
        Me.chkmes.Location = New System.Drawing.Point(43, 54)
        Me.chkmes.Name = "chkmes"
        Me.chkmes.Size = New System.Drawing.Size(15, 14)
        Me.chkmes.TabIndex = 176
        Me.chkmes.UseVisualStyleBackColor = True
        '
        'gridMes
        '
        Me.gridMes.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridMes.DisplayLayout.Appearance = Appearance30
        Me.gridMes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn43.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance31.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance31.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn43.Header.Appearance = Appearance31
        UltraGridColumn43.Header.Caption = " "
        UltraGridColumn43.Header.VisiblePosition = 0
        UltraGridColumn43.MaxWidth = 25
        UltraGridColumn43.MinWidth = 25
        UltraGridColumn43.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn43.Width = 25
        UltraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn44.Header.VisiblePosition = 1
        UltraGridColumn44.Width = 8
        UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn45.Header.VisiblePosition = 2
        UltraGridColumn45.Hidden = True
        UltraGridColumn45.Width = 53
        UltraGridBand8.Columns.AddRange(New Object() {UltraGridColumn43, UltraGridColumn44, UltraGridColumn45})
        Me.gridMes.DisplayLayout.BandsSerializer.Add(UltraGridBand8)
        Me.gridMes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridMes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridMes.DisplayLayout.ColScrollRegions.Add(ColScrollRegion82)
        Me.gridMes.DisplayLayout.ColScrollRegions.Add(ColScrollRegion83)
        Me.gridMes.DisplayLayout.ColScrollRegions.Add(ColScrollRegion84)
        Me.gridMes.DisplayLayout.ColScrollRegions.Add(ColScrollRegion85)
        Me.gridMes.DisplayLayout.ColScrollRegions.Add(ColScrollRegion86)
        Me.gridMes.DisplayLayout.ColScrollRegions.Add(ColScrollRegion87)
        Me.gridMes.DisplayLayout.ColScrollRegions.Add(ColScrollRegion88)
        Me.gridMes.DisplayLayout.ColScrollRegions.Add(ColScrollRegion89)
        Me.gridMes.DisplayLayout.ColScrollRegions.Add(ColScrollRegion90)
        Me.gridMes.DisplayLayout.ColScrollRegions.Add(ColScrollRegion91)
        Me.gridMes.DisplayLayout.ColScrollRegions.Add(ColScrollRegion92)
        Me.gridMes.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance32.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance32.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance32.BorderColor = System.Drawing.SystemColors.Window
        Me.gridMes.DisplayLayout.GroupByBox.Appearance = Appearance32
        Appearance33.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridMes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance33
        Me.gridMes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridMes.DisplayLayout.GroupByBox.Hidden = True
        Appearance34.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance34.BackColor2 = System.Drawing.SystemColors.Control
        Appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance34.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridMes.DisplayLayout.GroupByBox.PromptAppearance = Appearance34
        Me.gridMes.DisplayLayout.MaxColScrollRegions = 1
        Me.gridMes.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridMes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridMes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridMes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Me.gridMes.DisplayLayout.Override.CardAreaAppearance = Appearance35
        Appearance47.BorderColor = System.Drawing.Color.Silver
        Appearance47.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridMes.DisplayLayout.Override.CellAppearance = Appearance47
        Me.gridMes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridMes.DisplayLayout.Override.CellPadding = 0
        Me.gridMes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridMes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridMes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridMes.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance48.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridMes.DisplayLayout.Override.FilterRowAppearance = Appearance48
        Me.gridMes.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridMes.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridMes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance49.BackColor = System.Drawing.SystemColors.Control
        Appearance49.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance49.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance49.BorderColor = System.Drawing.SystemColors.Window
        Me.gridMes.DisplayLayout.Override.GroupByRowAppearance = Appearance49
        Appearance50.FontData.Name = "Arial Narrow"
        Appearance50.FontData.SizeInPoints = 10.0!
        Appearance50.TextHAlignAsString = "Left"
        Me.gridMes.DisplayLayout.Override.HeaderAppearance = Appearance50
        Me.gridMes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridMes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridMes.DisplayLayout.Override.MinRowHeight = 24
        Appearance51.BackColor = System.Drawing.SystemColors.Window
        Appearance51.BorderColor = System.Drawing.Color.Silver
        Appearance51.TextVAlignAsString = "Middle"
        Me.gridMes.DisplayLayout.Override.RowAppearance = Appearance51
        Me.gridMes.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridMes.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridMes.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance52.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridMes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance52
        Me.gridMes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridMes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridMes.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridMes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridMes.Location = New System.Drawing.Point(3, 16)
        Me.gridMes.Name = "gridMes"
        Me.gridMes.Size = New System.Drawing.Size(65, 37)
        Me.gridMes.TabIndex = 174
        Me.gridMes.Text = "UltraGrid1"
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Stacked
        ChartArea1.BackColor = System.Drawing.Color.LightSteelBlue
        ChartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(777, 126)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(859, 334)
        Me.Chart1.TabIndex = 207
        Me.Chart1.Text = "Chart1"
        Me.Chart1.Visible = False
        '
        'UltraLabel6
        '
        Appearance103.BackColor = System.Drawing.Color.Transparent
        Appearance103.TextHAlignAsString = "Center"
        Appearance103.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance103
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(15, 7)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(90, 14)
        Me.UltraLabel6.TabIndex = 191
        Me.UltraLabel6.Text = "Rango de fechas"
        '
        'txtayo
        '
        Me.txtayo.Location = New System.Drawing.Point(171, 12)
        Me.txtayo.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtayo.Name = "txtayo"
        Me.txtayo.Size = New System.Drawing.Size(57, 20)
        Me.txtayo.TabIndex = 190
        Me.txtayo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtayo.Value = New Decimal(New Integer() {2021, 0, 0, 0})
        '
        'Chart2
        '
        Me.Chart2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea2.BackColor = System.Drawing.Color.LightSteelBlue
        ChartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend2.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend2)
        Me.Chart2.Location = New System.Drawing.Point(777, 119)
        Me.Chart2.Name = "Chart2"
        Me.Chart2.Size = New System.Drawing.Size(859, 334)
        Me.Chart2.TabIndex = 224
        Me.Chart2.Text = "Chart2"
        Me.Chart2.Visible = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox8.Controls.Add(Me.gridReportenoCumple)
        Me.GroupBox8.Location = New System.Drawing.Point(1149, 760)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(493, 39)
        Me.GroupBox8.TabIndex = 245
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Rumas que no cumplen con la política de inventario"
        Me.GroupBox8.Visible = False
        '
        'gridReportenoCumple
        '
        Me.gridReportenoCumple.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridReportenoCumple.DisplayLayout.Appearance = Appearance1
        Me.gridReportenoCumple.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn46.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn46.Header.Appearance = Appearance2
        UltraGridColumn46.Header.Caption = " "
        UltraGridColumn46.Header.VisiblePosition = 0
        UltraGridColumn46.Hidden = True
        UltraGridColumn46.MaxWidth = 25
        UltraGridColumn46.MinWidth = 25
        UltraGridColumn46.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn46.Width = 25
        UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn47.Header.Caption = "RUMA"
        UltraGridColumn47.Header.VisiblePosition = 1
        UltraGridColumn47.Width = 50
        UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn48.Header.VisiblePosition = 2
        UltraGridColumn48.Hidden = True
        UltraGridColumn48.Width = 72
        UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance67.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance67.TextHAlignAsString = "Right"
        UltraGridColumn49.CellAppearance = Appearance67
        UltraGridColumn49.Format = "#,##0"
        UltraGridColumn49.Header.VisiblePosition = 4
        UltraGridColumn49.MaskInput = "nnnnnn"
        UltraGridColumn49.Width = 48
        UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn50.Header.Caption = "POLITICA"
        UltraGridColumn50.Header.VisiblePosition = 7
        UltraGridColumn50.Width = 48
        UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance68.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance68.TextHAlignAsString = "Center"
        UltraGridColumn51.CellAppearance = Appearance68
        UltraGridColumn51.Format = "#,##0"
        UltraGridColumn51.Header.Caption = "MES MIN."
        UltraGridColumn51.Header.VisiblePosition = 8
        UltraGridColumn51.Width = 48
        UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance69.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance69.TextHAlignAsString = "Center"
        UltraGridColumn52.CellAppearance = Appearance69
        UltraGridColumn52.Format = "#,##0"
        UltraGridColumn52.Header.Caption = "MES MAX."
        UltraGridColumn52.Header.VisiblePosition = 9
        UltraGridColumn52.Width = 48
        UltraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn53.Header.VisiblePosition = 10
        UltraGridColumn53.Width = 48
        UltraGridColumn54.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance70.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance70.TextHAlignAsString = "Right"
        UltraGridColumn54.CellAppearance = Appearance70
        UltraGridColumn54.Format = "#,##0"
        UltraGridColumn54.Header.Caption = "PROMEDIO (*)"
        UltraGridColumn54.Header.VisiblePosition = 5
        UltraGridColumn54.Width = 48
        UltraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance71.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance71.TextHAlignAsString = "Center"
        UltraGridColumn55.CellAppearance = Appearance71
        UltraGridColumn55.Format = "#,##0"
        UltraGridColumn55.Header.Caption = "MES STOCK"
        UltraGridColumn55.Header.VisiblePosition = 6
        UltraGridColumn55.Width = 48
        UltraGridColumn56.Header.VisiblePosition = 11
        UltraGridColumn56.Hidden = True
        UltraGridColumn56.Width = 97
        UltraGridColumn57.Header.VisiblePosition = 12
        UltraGridColumn57.Hidden = True
        UltraGridColumn57.Width = 96
        UltraGridColumn58.Header.VisiblePosition = 13
        UltraGridColumn58.Hidden = True
        UltraGridColumn58.Width = 95
        UltraGridColumn59.Header.VisiblePosition = 14
        UltraGridColumn59.Hidden = True
        UltraGridColumn59.Width = 95
        UltraGridColumn60.Header.VisiblePosition = 15
        UltraGridColumn60.Hidden = True
        UltraGridColumn60.Width = 95
        UltraGridColumn61.Header.VisiblePosition = 16
        UltraGridColumn61.Hidden = True
        UltraGridColumn61.Width = 95
        UltraGridColumn62.Header.VisiblePosition = 17
        UltraGridColumn62.Hidden = True
        UltraGridColumn62.Width = 95
        UltraGridColumn63.Header.VisiblePosition = 3
        UltraGridColumn63.Width = 48
        UltraGridBand9.Columns.AddRange(New Object() {UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63})
        Me.gridReportenoCumple.DisplayLayout.BandsSerializer.Add(UltraGridBand9)
        Me.gridReportenoCumple.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridReportenoCumple.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridReportenoCumple.DisplayLayout.ColScrollRegions.Add(ColScrollRegion93)
        Me.gridReportenoCumple.DisplayLayout.ColScrollRegions.Add(ColScrollRegion94)
        Me.gridReportenoCumple.DisplayLayout.ColScrollRegions.Add(ColScrollRegion95)
        Me.gridReportenoCumple.DisplayLayout.ColScrollRegions.Add(ColScrollRegion96)
        Me.gridReportenoCumple.DisplayLayout.ColScrollRegions.Add(ColScrollRegion97)
        Me.gridReportenoCumple.DisplayLayout.ColScrollRegions.Add(ColScrollRegion98)
        Me.gridReportenoCumple.DisplayLayout.ColScrollRegions.Add(ColScrollRegion99)
        Me.gridReportenoCumple.DisplayLayout.ColScrollRegions.Add(ColScrollRegion100)
        Me.gridReportenoCumple.DisplayLayout.ColScrollRegions.Add(ColScrollRegion101)
        Me.gridReportenoCumple.DisplayLayout.ColScrollRegions.Add(ColScrollRegion102)
        Me.gridReportenoCumple.DisplayLayout.ColScrollRegions.Add(ColScrollRegion103)
        Me.gridReportenoCumple.DisplayLayout.ColScrollRegions.Add(ColScrollRegion104)
        Me.gridReportenoCumple.DisplayLayout.ColScrollRegions.Add(ColScrollRegion105)
        Me.gridReportenoCumple.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.gridReportenoCumple.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridReportenoCumple.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.gridReportenoCumple.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridReportenoCumple.DisplayLayout.GroupByBox.Hidden = True
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridReportenoCumple.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.gridReportenoCumple.DisplayLayout.MaxColScrollRegions = 1
        Me.gridReportenoCumple.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridReportenoCumple.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridReportenoCumple.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridReportenoCumple.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.gridReportenoCumple.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridReportenoCumple.DisplayLayout.Override.CellAppearance = Appearance8
        Me.gridReportenoCumple.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridReportenoCumple.DisplayLayout.Override.CellPadding = 0
        Me.gridReportenoCumple.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridReportenoCumple.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridReportenoCumple.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridReportenoCumple.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance9.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridReportenoCumple.DisplayLayout.Override.FilterRowAppearance = Appearance9
        Me.gridReportenoCumple.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridReportenoCumple.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridReportenoCumple.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.gridReportenoCumple.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.FontData.Name = "Arial Narrow"
        Appearance11.FontData.SizeInPoints = 10.0!
        Appearance11.TextHAlignAsString = "Left"
        Me.gridReportenoCumple.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.gridReportenoCumple.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridReportenoCumple.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridReportenoCumple.DisplayLayout.Override.MinRowHeight = 24
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Appearance12.TextVAlignAsString = "Middle"
        Me.gridReportenoCumple.DisplayLayout.Override.RowAppearance = Appearance12
        Me.gridReportenoCumple.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridReportenoCumple.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridReportenoCumple.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridReportenoCumple.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.gridReportenoCumple.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridReportenoCumple.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridReportenoCumple.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridReportenoCumple.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridReportenoCumple.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridReportenoCumple.Location = New System.Drawing.Point(3, 16)
        Me.gridReportenoCumple.Name = "gridReportenoCumple"
        Me.gridReportenoCumple.Size = New System.Drawing.Size(487, 20)
        Me.gridReportenoCumple.TabIndex = 234
        Me.gridReportenoCumple.Text = "UltraGrid1"
        '
        'tab2
        '
        Me.tab2.Controls.Add(Me.gpbHistorial)
        Me.tab2.Controls.Add(Me.lblhist)
        Me.tab2.Controls.Add(Me.btnguardar)
        Me.tab2.Controls.Add(Me.txtobservacion)
        Me.tab2.Controls.Add(Me.btnexportar)
        Me.tab2.Controls.Add(Me.gridReporte)
        Me.tab2.Controls.Add(Me.gridReporteStock)
        Me.tab2.Location = New System.Drawing.Point(-10000, -10000)
        Me.tab2.Name = "tab2"
        Me.tab2.Size = New System.Drawing.Size(1645, 816)
        '
        'gpbHistorial
        '
        Me.gpbHistorial.BackColor = System.Drawing.Color.White
        Me.gpbHistorial.Controls.Add(Me.UltraLabel1)
        Me.gpbHistorial.Controls.Add(Me.gridHistorial)
        Me.gpbHistorial.Location = New System.Drawing.Point(325, 53)
        Me.gpbHistorial.Name = "gpbHistorial"
        Me.gpbHistorial.Size = New System.Drawing.Size(707, 559)
        Me.gpbHistorial.TabIndex = 247
        Me.gpbHistorial.TabStop = False
        Me.gpbHistorial.Text = "Historial de comentarios"
        Me.gpbHistorial.Visible = False
        '
        'UltraLabel1
        '
        Appearance139.BackColor = System.Drawing.Color.Red
        Appearance139.TextHAlignAsString = "Center"
        Appearance139.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance139
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(687, 9)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(17, 21)
        Me.UltraLabel1.TabIndex = 192
        Me.UltraLabel1.Text = "X"
        '
        'gridHistorial
        '
        Me.gridHistorial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridHistorial.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance101.BackColor = System.Drawing.SystemColors.Window
        Appearance101.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridHistorial.DisplayLayout.Appearance = Appearance101
        Me.gridHistorial.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn64.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn64.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance102.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance102.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn64.Header.Appearance = Appearance102
        UltraGridColumn64.Header.Caption = " "
        UltraGridColumn64.Header.VisiblePosition = 0
        UltraGridColumn64.Hidden = True
        UltraGridColumn64.MaxWidth = 25
        UltraGridColumn64.MinWidth = 25
        UltraGridColumn64.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn64.Width = 25
        UltraGridColumn65.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn65.Header.VisiblePosition = 1
        UltraGridColumn65.Width = 395
        UltraGridColumn66.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn66.Header.VisiblePosition = 2
        UltraGridColumn66.Width = 174
        UltraGridColumn67.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn67.Header.VisiblePosition = 3
        UltraGridColumn67.Hidden = True
        UltraGridColumn67.Width = 69
        UltraGridColumn68.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn68.Header.VisiblePosition = 4
        UltraGridColumn68.Hidden = True
        UltraGridColumn68.Width = 86
        UltraGridColumn69.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn69.Header.VisiblePosition = 5
        UltraGridColumn69.Width = 102
        UltraGridBand10.Columns.AddRange(New Object() {UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69})
        Appearance135.TextHAlignAsString = "Right"
        SummarySettings5.Appearance = Appearance135
        SummarySettings5.DisplayFormat = "{0:###,##0}"
        SummarySettings5.GroupBySummaryValueAppearance = Appearance136
        Appearance137.TextHAlignAsString = "Right"
        SummarySettings6.Appearance = Appearance137
        SummarySettings6.DisplayFormat = "{0:###,##0}"
        SummarySettings6.GroupBySummaryValueAppearance = Appearance140
        UltraGridBand10.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings5, SummarySettings6})
        UltraGridBand10.SummaryFooterCaption = ""
        Me.gridHistorial.DisplayLayout.BandsSerializer.Add(UltraGridBand10)
        Me.gridHistorial.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridHistorial.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridHistorial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion106)
        Me.gridHistorial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion107)
        Me.gridHistorial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion108)
        Me.gridHistorial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion109)
        Me.gridHistorial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion110)
        Me.gridHistorial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion111)
        Me.gridHistorial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion112)
        Me.gridHistorial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion113)
        Me.gridHistorial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion114)
        Me.gridHistorial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion115)
        Me.gridHistorial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion116)
        Me.gridHistorial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion117)
        Me.gridHistorial.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance141.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance141.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance141.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance141.BorderColor = System.Drawing.SystemColors.Window
        Me.gridHistorial.DisplayLayout.GroupByBox.Appearance = Appearance141
        Appearance142.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridHistorial.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance142
        Me.gridHistorial.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridHistorial.DisplayLayout.GroupByBox.Hidden = True
        Appearance143.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance143.BackColor2 = System.Drawing.SystemColors.Control
        Appearance143.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance143.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridHistorial.DisplayLayout.GroupByBox.PromptAppearance = Appearance143
        Me.gridHistorial.DisplayLayout.MaxColScrollRegions = 1
        Me.gridHistorial.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridHistorial.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridHistorial.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridHistorial.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance144.BackColor = System.Drawing.SystemColors.Window
        Me.gridHistorial.DisplayLayout.Override.CardAreaAppearance = Appearance144
        Appearance145.BorderColor = System.Drawing.Color.Silver
        Appearance145.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridHistorial.DisplayLayout.Override.CellAppearance = Appearance145
        Me.gridHistorial.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridHistorial.DisplayLayout.Override.CellPadding = 0
        Me.gridHistorial.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridHistorial.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridHistorial.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridHistorial.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance146.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridHistorial.DisplayLayout.Override.FilterRowAppearance = Appearance146
        Me.gridHistorial.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridHistorial.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridHistorial.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance147.BackColor = System.Drawing.SystemColors.Control
        Appearance147.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance147.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance147.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance147.BorderColor = System.Drawing.SystemColors.Window
        Me.gridHistorial.DisplayLayout.Override.GroupByRowAppearance = Appearance147
        Appearance148.FontData.Name = "Arial Narrow"
        Appearance148.FontData.SizeInPoints = 10.0!
        Appearance148.TextHAlignAsString = "Left"
        Me.gridHistorial.DisplayLayout.Override.HeaderAppearance = Appearance148
        Me.gridHistorial.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridHistorial.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridHistorial.DisplayLayout.Override.MinRowHeight = 24
        Appearance149.BackColor = System.Drawing.SystemColors.Window
        Appearance149.BorderColor = System.Drawing.Color.Silver
        Appearance149.TextVAlignAsString = "Middle"
        Me.gridHistorial.DisplayLayout.Override.RowAppearance = Appearance149
        Me.gridHistorial.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridHistorial.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridHistorial.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance150.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridHistorial.DisplayLayout.Override.TemplateAddRowAppearance = Appearance150
        Me.gridHistorial.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridHistorial.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridHistorial.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridHistorial.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridHistorial.Location = New System.Drawing.Point(0, 36)
        Me.gridHistorial.Name = "gridHistorial"
        Me.gridHistorial.Size = New System.Drawing.Size(707, 520)
        Me.gridHistorial.TabIndex = 174
        Me.gridHistorial.Text = "UltraGrid1"
        '
        'lblhist
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.FontData.UnderlineAsString = "True"
        Appearance3.ForeColor = System.Drawing.Color.Blue
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.lblhist.Appearance = Appearance3
        Me.lblhist.AutoSize = True
        Me.lblhist.Location = New System.Drawing.Point(90, 768)
        Me.lblhist.Name = "lblhist"
        Me.lblhist.Size = New System.Drawing.Size(64, 14)
        Me.lblhist.TabIndex = 246
        Me.lblhist.Text = "Ver historial"
        '
        'btnguardar
        '
        Me.btnguardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnguardar.Image = Global.SIP_Presentacion.My.Resources.Resources.guardar2
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnguardar.Location = New System.Drawing.Point(1106, 734)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(119, 28)
        Me.btnguardar.TabIndex = 245
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'txtobservacion
        '
        Me.txtobservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance85.BackColor = System.Drawing.Color.White
        Appearance85.TextHAlignAsString = "Left"
        Appearance85.TextVAlignAsString = "Middle"
        Me.txtobservacion.Appearance = Appearance85
        Me.txtobservacion.BackColor = System.Drawing.Color.White
        Me.txtobservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtobservacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtobservacion.Location = New System.Drawing.Point(90, 627)
        Me.txtobservacion.Multiline = True
        Me.txtobservacion.Name = "txtobservacion"
        Me.txtobservacion.Size = New System.Drawing.Size(962, 135)
        Me.txtobservacion.TabIndex = 244
        Me.txtobservacion.TabStop = False
        '
        'btnexportar
        '
        Me.btnexportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexportar.Image = Global.SIP_Presentacion.My.Resources.Resources.page_excel
        Me.btnexportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnexportar.Location = New System.Drawing.Point(1106, 627)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(119, 28)
        Me.btnexportar.TabIndex = 174
        Me.btnexportar.Text = "Exportar"
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'gridReporte
        '
        Me.gridReporte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridReporte.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance116.BackColor = System.Drawing.SystemColors.Window
        Appearance116.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridReporte.DisplayLayout.Appearance = Appearance116
        Me.gridReporte.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn70.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn70.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance151.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance151.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn70.Header.Appearance = Appearance151
        UltraGridColumn70.Header.Caption = " "
        UltraGridColumn70.Header.VisiblePosition = 0
        UltraGridColumn70.Hidden = True
        UltraGridColumn70.MaxWidth = 25
        UltraGridColumn70.MinWidth = 25
        UltraGridColumn70.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn70.Width = 25
        UltraGridColumn71.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn71.Header.Caption = "RUMA"
        UltraGridColumn71.Header.VisiblePosition = 1
        UltraGridColumn71.Width = 40
        UltraGridColumn72.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn72.Header.VisiblePosition = 2
        UltraGridColumn72.Hidden = True
        UltraGridColumn72.Width = 135
        UltraGridColumn73.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance152.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance152.TextHAlignAsString = "Right"
        UltraGridColumn73.CellAppearance = Appearance152
        UltraGridColumn73.Format = "#,##0.00"
        UltraGridColumn73.Header.Caption = "SALDO TON"
        UltraGridColumn73.Header.VisiblePosition = 7
        UltraGridColumn73.Width = 107
        UltraGridColumn74.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn74.Header.Caption = "POLITICA"
        UltraGridColumn74.Header.VisiblePosition = 11
        UltraGridColumn74.Width = 108
        UltraGridColumn75.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance153.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance153.TextHAlignAsString = "Center"
        UltraGridColumn75.CellAppearance = Appearance153
        UltraGridColumn75.Header.Caption = "MES MIN."
        UltraGridColumn75.Header.VisiblePosition = 12
        UltraGridColumn75.Width = 74
        UltraGridColumn76.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance154.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance154.TextHAlignAsString = "Center"
        UltraGridColumn76.CellAppearance = Appearance154
        UltraGridColumn76.Header.Caption = "MES MAX."
        UltraGridColumn76.Header.VisiblePosition = 13
        UltraGridColumn76.Width = 75
        UltraGridColumn77.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn77.Header.VisiblePosition = 14
        UltraGridColumn77.Width = 89
        UltraGridColumn78.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance155.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance155.TextHAlignAsString = "Right"
        UltraGridColumn78.CellAppearance = Appearance155
        UltraGridColumn78.Header.Caption = "CONSUMO PROM."
        UltraGridColumn78.Header.VisiblePosition = 9
        UltraGridColumn78.Width = 72
        UltraGridColumn79.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance156.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance156.TextHAlignAsString = "Center"
        UltraGridColumn79.CellAppearance = Appearance156
        UltraGridColumn79.Header.Caption = "MES STOCK"
        UltraGridColumn79.Header.VisiblePosition = 10
        UltraGridColumn79.Width = 80
        UltraGridColumn80.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance157.TextHAlignAsString = "Right"
        UltraGridColumn80.CellAppearance = Appearance157
        UltraGridColumn80.Format = "#,##0.00"
        UltraGridColumn80.Header.VisiblePosition = 8
        UltraGridColumn80.Width = 86
        UltraGridColumn81.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn81.Header.VisiblePosition = 15
        UltraGridColumn81.Width = 84
        UltraGridColumn82.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance158.TextHAlignAsString = "Right"
        UltraGridColumn82.CellAppearance = Appearance158
        UltraGridColumn82.Format = "#,##0.00"
        UltraGridColumn82.Header.Caption = "DIF. TON"
        UltraGridColumn82.Header.VisiblePosition = 16
        UltraGridColumn82.Width = 102
        UltraGridColumn83.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance159.TextHAlignAsString = "Right"
        UltraGridColumn83.CellAppearance = Appearance159
        UltraGridColumn83.Format = "#,##0.00"
        UltraGridColumn83.Header.Caption = "DIF. SOLES"
        UltraGridColumn83.Header.VisiblePosition = 17
        UltraGridColumn83.Width = 104
        UltraGridColumn84.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance160.TextHAlignAsString = "Right"
        UltraGridColumn84.CellAppearance = Appearance160
        UltraGridColumn84.Header.VisiblePosition = 4
        UltraGridColumn84.Width = 108
        UltraGridColumn85.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance161.TextHAlignAsString = "Right"
        UltraGridColumn85.CellAppearance = Appearance161
        UltraGridColumn85.Header.VisiblePosition = 5
        UltraGridColumn85.Width = 102
        UltraGridColumn86.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance162.TextHAlignAsString = "Right"
        UltraGridColumn86.CellAppearance = Appearance162
        UltraGridColumn86.Header.VisiblePosition = 6
        UltraGridColumn86.Width = 119
        UltraGridColumn87.Header.VisiblePosition = 3
        UltraGridColumn87.Width = 181
        UltraGridBand11.Columns.AddRange(New Object() {UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn81, UltraGridColumn82, UltraGridColumn83, UltraGridColumn84, UltraGridColumn85, UltraGridColumn86, UltraGridColumn87})
        Appearance163.TextHAlignAsString = "Right"
        SummarySettings7.Appearance = Appearance163
        SummarySettings7.DisplayFormat = "{0:###,##0.00}"
        SummarySettings7.GroupBySummaryValueAppearance = Appearance164
        Appearance165.TextHAlignAsString = "Right"
        SummarySettings8.Appearance = Appearance165
        SummarySettings8.DisplayFormat = "{0:###,##0.00}"
        SummarySettings8.GroupBySummaryValueAppearance = Appearance166
        Appearance167.TextHAlignAsString = "Right"
        SummarySettings9.Appearance = Appearance167
        SummarySettings9.DisplayFormat = "{0:###,##0.00}"
        SummarySettings9.GroupBySummaryValueAppearance = Appearance168
        Appearance169.TextHAlignAsString = "Right"
        SummarySettings10.Appearance = Appearance169
        SummarySettings10.DisplayFormat = "{0:###,##0.00}"
        SummarySettings10.GroupBySummaryValueAppearance = Appearance170
        Appearance171.TextHAlignAsString = "Right"
        SummarySettings11.Appearance = Appearance171
        SummarySettings11.DisplayFormat = "{0:###,##0.00}"
        SummarySettings11.GroupBySummaryValueAppearance = Appearance172
        Appearance173.TextHAlignAsString = "Right"
        SummarySettings12.Appearance = Appearance173
        SummarySettings12.DisplayFormat = "{0:###,##0.00}"
        SummarySettings12.GroupBySummaryValueAppearance = Appearance174
        Appearance215.TextHAlignAsString = "Right"
        SummarySettings13.Appearance = Appearance215
        SummarySettings13.DisplayFormat = "{0:###,##0.00}"
        SummarySettings13.GroupBySummaryValueAppearance = Appearance216
        UltraGridBand11.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings7, SummarySettings8, SummarySettings9, SummarySettings10, SummarySettings11, SummarySettings12, SummarySettings13})
        UltraGridBand11.SummaryFooterCaption = ""
        Me.gridReporte.DisplayLayout.BandsSerializer.Add(UltraGridBand11)
        Me.gridReporte.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridReporte.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion118)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion119)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion120)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion121)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion122)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion123)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion124)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion125)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion126)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion127)
        Me.gridReporte.DisplayLayout.ColScrollRegions.Add(ColScrollRegion128)
        Me.gridReporte.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance217.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance217.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance217.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance217.BorderColor = System.Drawing.SystemColors.Window
        Me.gridReporte.DisplayLayout.GroupByBox.Appearance = Appearance217
        Appearance218.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridReporte.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance218
        Me.gridReporte.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridReporte.DisplayLayout.GroupByBox.Hidden = True
        Appearance219.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance219.BackColor2 = System.Drawing.SystemColors.Control
        Appearance219.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance219.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridReporte.DisplayLayout.GroupByBox.PromptAppearance = Appearance219
        Me.gridReporte.DisplayLayout.MaxColScrollRegions = 1
        Me.gridReporte.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridReporte.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridReporte.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridReporte.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance220.BackColor = System.Drawing.SystemColors.Window
        Me.gridReporte.DisplayLayout.Override.CardAreaAppearance = Appearance220
        Appearance221.BorderColor = System.Drawing.Color.Silver
        Appearance221.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridReporte.DisplayLayout.Override.CellAppearance = Appearance221
        Me.gridReporte.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridReporte.DisplayLayout.Override.CellPadding = 0
        Me.gridReporte.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridReporte.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridReporte.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridReporte.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance222.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridReporte.DisplayLayout.Override.FilterRowAppearance = Appearance222
        Me.gridReporte.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridReporte.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridReporte.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance223.BackColor = System.Drawing.SystemColors.Control
        Appearance223.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance223.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance223.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance223.BorderColor = System.Drawing.SystemColors.Window
        Me.gridReporte.DisplayLayout.Override.GroupByRowAppearance = Appearance223
        Appearance224.FontData.Name = "Arial Narrow"
        Appearance224.FontData.SizeInPoints = 10.0!
        Appearance224.TextHAlignAsString = "Left"
        Me.gridReporte.DisplayLayout.Override.HeaderAppearance = Appearance224
        Me.gridReporte.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridReporte.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridReporte.DisplayLayout.Override.MinRowHeight = 24
        Appearance225.BackColor = System.Drawing.SystemColors.Window
        Appearance225.BorderColor = System.Drawing.Color.Silver
        Appearance225.TextVAlignAsString = "Middle"
        Me.gridReporte.DisplayLayout.Override.RowAppearance = Appearance225
        Me.gridReporte.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridReporte.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridReporte.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance226.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridReporte.DisplayLayout.Override.TemplateAddRowAppearance = Appearance226
        Me.gridReporte.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridReporte.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridReporte.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridReporte.Location = New System.Drawing.Point(25, 53)
        Me.gridReporte.Name = "gridReporte"
        Me.gridReporte.Size = New System.Drawing.Size(1571, 556)
        Me.gridReporte.TabIndex = 173
        Me.gridReporte.Text = "UltraGrid1"
        '
        'gridReporteStock
        '
        Me.gridReporteStock.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridReporteStock.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance188.BackColor = System.Drawing.SystemColors.Window
        Appearance188.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridReporteStock.DisplayLayout.Appearance = Appearance188
        Me.gridReporteStock.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn88.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn88.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance189.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance189.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn88.Header.Appearance = Appearance189
        UltraGridColumn88.Header.Caption = " "
        UltraGridColumn88.Header.VisiblePosition = 0
        UltraGridColumn88.Hidden = True
        UltraGridColumn88.MaxWidth = 25
        UltraGridColumn88.MinWidth = 25
        UltraGridColumn88.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn88.Width = 25
        UltraGridColumn89.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn89.Header.Caption = "RUMA"
        UltraGridColumn89.Header.VisiblePosition = 1
        UltraGridColumn89.Width = 8
        UltraGridColumn90.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn90.Header.VisiblePosition = 2
        UltraGridColumn90.Hidden = True
        UltraGridColumn90.Width = 135
        UltraGridColumn91.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance190.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance190.TextHAlignAsString = "Right"
        UltraGridColumn91.CellAppearance = Appearance190
        UltraGridColumn91.Format = "#,##0.00"
        UltraGridColumn91.Header.Caption = "SALDO TON"
        UltraGridColumn91.Header.VisiblePosition = 7
        UltraGridColumn91.Width = 12
        UltraGridColumn92.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn92.Header.Caption = "POLITICA"
        UltraGridColumn92.Header.VisiblePosition = 11
        UltraGridColumn92.Width = 11
        UltraGridColumn93.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance191.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance191.TextHAlignAsString = "Center"
        UltraGridColumn93.CellAppearance = Appearance191
        UltraGridColumn93.Header.Caption = "MES MIN."
        UltraGridColumn93.Header.VisiblePosition = 12
        UltraGridColumn93.Width = 9
        UltraGridColumn94.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance192.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance192.TextHAlignAsString = "Center"
        UltraGridColumn94.CellAppearance = Appearance192
        UltraGridColumn94.Header.Caption = "MES MAX."
        UltraGridColumn94.Header.VisiblePosition = 13
        UltraGridColumn94.Width = 9
        UltraGridColumn95.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn95.Header.VisiblePosition = 14
        UltraGridColumn95.Width = 8
        UltraGridColumn96.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance193.ImageHAlign = Infragistics.Win.HAlign.Right
        Appearance193.TextHAlignAsString = "Right"
        UltraGridColumn96.CellAppearance = Appearance193
        UltraGridColumn96.Header.Caption = "CONSUMO PROM."
        UltraGridColumn96.Header.VisiblePosition = 9
        UltraGridColumn96.Width = 11
        UltraGridColumn97.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance194.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance194.TextHAlignAsString = "Center"
        UltraGridColumn97.CellAppearance = Appearance194
        UltraGridColumn97.Header.Caption = "MES STOCK"
        UltraGridColumn97.Header.VisiblePosition = 10
        UltraGridColumn97.Width = 11
        UltraGridColumn98.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance195.TextHAlignAsString = "Right"
        UltraGridColumn98.CellAppearance = Appearance195
        UltraGridColumn98.Format = "#,##0.00"
        UltraGridColumn98.Header.VisiblePosition = 8
        UltraGridColumn98.Width = 11
        UltraGridColumn99.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn99.Header.VisiblePosition = 15
        UltraGridColumn99.Width = 8
        UltraGridColumn100.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance196.TextHAlignAsString = "Right"
        UltraGridColumn100.CellAppearance = Appearance196
        UltraGridColumn100.Format = "#,##0.00"
        UltraGridColumn100.Header.Caption = "DIF. TON"
        UltraGridColumn100.Header.VisiblePosition = 16
        UltraGridColumn100.Width = 8
        UltraGridColumn101.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance197.TextHAlignAsString = "Right"
        UltraGridColumn101.CellAppearance = Appearance197
        UltraGridColumn101.Format = "#,##0.00"
        UltraGridColumn101.Header.Caption = "DIF. SOLES"
        UltraGridColumn101.Header.VisiblePosition = 17
        UltraGridColumn101.Width = 8
        UltraGridColumn102.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance198.TextHAlignAsString = "Right"
        UltraGridColumn102.CellAppearance = Appearance198
        UltraGridColumn102.Header.VisiblePosition = 4
        UltraGridColumn102.Width = 14
        UltraGridColumn103.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance199.TextHAlignAsString = "Right"
        UltraGridColumn103.CellAppearance = Appearance199
        UltraGridColumn103.Header.VisiblePosition = 5
        UltraGridColumn103.Width = 14
        UltraGridColumn104.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance200.TextHAlignAsString = "Right"
        UltraGridColumn104.CellAppearance = Appearance200
        UltraGridColumn104.Header.VisiblePosition = 6
        UltraGridColumn104.Width = 11
        UltraGridColumn105.Header.VisiblePosition = 3
        UltraGridColumn105.Width = 8
        UltraGridBand12.Columns.AddRange(New Object() {UltraGridColumn88, UltraGridColumn89, UltraGridColumn90, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn95, UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn100, UltraGridColumn101, UltraGridColumn102, UltraGridColumn103, UltraGridColumn104, UltraGridColumn105})
        Appearance201.TextHAlignAsString = "Right"
        SummarySettings14.Appearance = Appearance201
        SummarySettings14.DisplayFormat = "{0:###,##0.00}"
        SummarySettings14.GroupBySummaryValueAppearance = Appearance202
        Appearance203.TextHAlignAsString = "Right"
        SummarySettings15.Appearance = Appearance203
        SummarySettings15.DisplayFormat = "{0:###,##0.00}"
        SummarySettings15.GroupBySummaryValueAppearance = Appearance204
        Appearance117.TextHAlignAsString = "Right"
        SummarySettings16.Appearance = Appearance117
        SummarySettings16.DisplayFormat = "{0:###,##0.00}"
        SummarySettings16.GroupBySummaryValueAppearance = Appearance111
        Appearance118.TextHAlignAsString = "Right"
        SummarySettings17.Appearance = Appearance118
        SummarySettings17.DisplayFormat = "{0:###,##0.00}"
        SummarySettings17.GroupBySummaryValueAppearance = Appearance112
        Appearance131.TextHAlignAsString = "Right"
        SummarySettings18.Appearance = Appearance131
        SummarySettings18.DisplayFormat = "{0:###,##0.00}"
        SummarySettings18.GroupBySummaryValueAppearance = Appearance113
        Appearance132.TextHAlignAsString = "Right"
        SummarySettings19.Appearance = Appearance132
        SummarySettings19.DisplayFormat = "{0:###,##0.00}"
        SummarySettings19.GroupBySummaryValueAppearance = Appearance114
        Appearance133.TextHAlignAsString = "Right"
        SummarySettings20.Appearance = Appearance133
        SummarySettings20.DisplayFormat = "{0:###,##0.00}"
        SummarySettings20.GroupBySummaryValueAppearance = Appearance115
        UltraGridBand12.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings14, SummarySettings15, SummarySettings16, SummarySettings17, SummarySettings18, SummarySettings19, SummarySettings20})
        UltraGridBand12.SummaryFooterCaption = ""
        Me.gridReporteStock.DisplayLayout.BandsSerializer.Add(UltraGridBand12)
        Me.gridReporteStock.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridReporteStock.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridReporteStock.DisplayLayout.ColScrollRegions.Add(ColScrollRegion129)
        Me.gridReporteStock.DisplayLayout.ColScrollRegions.Add(ColScrollRegion130)
        Me.gridReporteStock.DisplayLayout.ColScrollRegions.Add(ColScrollRegion131)
        Me.gridReporteStock.DisplayLayout.ColScrollRegions.Add(ColScrollRegion132)
        Me.gridReporteStock.DisplayLayout.ColScrollRegions.Add(ColScrollRegion133)
        Me.gridReporteStock.DisplayLayout.ColScrollRegions.Add(ColScrollRegion134)
        Me.gridReporteStock.DisplayLayout.ColScrollRegions.Add(ColScrollRegion135)
        Me.gridReporteStock.DisplayLayout.ColScrollRegions.Add(ColScrollRegion136)
        Me.gridReporteStock.DisplayLayout.ColScrollRegions.Add(ColScrollRegion137)
        Me.gridReporteStock.DisplayLayout.ColScrollRegions.Add(ColScrollRegion138)
        Me.gridReporteStock.DisplayLayout.ColScrollRegions.Add(ColScrollRegion139)
        Me.gridReporteStock.DisplayLayout.ColScrollRegions.Add(ColScrollRegion140)
        Me.gridReporteStock.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance205.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance205.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance205.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance205.BorderColor = System.Drawing.SystemColors.Window
        Me.gridReporteStock.DisplayLayout.GroupByBox.Appearance = Appearance205
        Appearance206.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridReporteStock.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance206
        Me.gridReporteStock.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridReporteStock.DisplayLayout.GroupByBox.Hidden = True
        Appearance207.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance207.BackColor2 = System.Drawing.SystemColors.Control
        Appearance207.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance207.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridReporteStock.DisplayLayout.GroupByBox.PromptAppearance = Appearance207
        Me.gridReporteStock.DisplayLayout.MaxColScrollRegions = 1
        Me.gridReporteStock.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridReporteStock.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridReporteStock.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridReporteStock.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance208.BackColor = System.Drawing.SystemColors.Window
        Me.gridReporteStock.DisplayLayout.Override.CardAreaAppearance = Appearance208
        Appearance209.BorderColor = System.Drawing.Color.Silver
        Appearance209.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridReporteStock.DisplayLayout.Override.CellAppearance = Appearance209
        Me.gridReporteStock.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridReporteStock.DisplayLayout.Override.CellPadding = 0
        Me.gridReporteStock.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridReporteStock.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridReporteStock.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridReporteStock.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance210.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gridReporteStock.DisplayLayout.Override.FilterRowAppearance = Appearance210
        Me.gridReporteStock.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridReporteStock.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridReporteStock.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance211.BackColor = System.Drawing.SystemColors.Control
        Appearance211.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance211.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance211.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance211.BorderColor = System.Drawing.SystemColors.Window
        Me.gridReporteStock.DisplayLayout.Override.GroupByRowAppearance = Appearance211
        Appearance212.FontData.Name = "Arial Narrow"
        Appearance212.FontData.SizeInPoints = 10.0!
        Appearance212.TextHAlignAsString = "Left"
        Me.gridReporteStock.DisplayLayout.Override.HeaderAppearance = Appearance212
        Me.gridReporteStock.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridReporteStock.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridReporteStock.DisplayLayout.Override.MinRowHeight = 24
        Appearance213.BackColor = System.Drawing.SystemColors.Window
        Appearance213.BorderColor = System.Drawing.Color.Silver
        Appearance213.TextVAlignAsString = "Middle"
        Me.gridReporteStock.DisplayLayout.Override.RowAppearance = Appearance213
        Me.gridReporteStock.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridReporteStock.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridReporteStock.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance214.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridReporteStock.DisplayLayout.Override.TemplateAddRowAppearance = Appearance214
        Me.gridReporteStock.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridReporteStock.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridReporteStock.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridReporteStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridReporteStock.Location = New System.Drawing.Point(90, 263)
        Me.gridReporteStock.Name = "gridReporteStock"
        Me.gridReporteStock.Size = New System.Drawing.Size(214, 158)
        Me.gridReporteStock.TabIndex = 248
        Me.gridReporteStock.Text = "UltraGrid1"
        Me.gridReporteStock.Visible = False
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.girdCanteraDet1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(1645, 816)
        '
        'girdCanteraDet1
        '
        Me.girdCanteraDet1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.girdCanteraDet1.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance227.BackColor = System.Drawing.SystemColors.Window
        Appearance227.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.girdCanteraDet1.DisplayLayout.Appearance = Appearance227
        Me.girdCanteraDet1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn106.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn106.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance228.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance228.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn106.Header.Appearance = Appearance228
        UltraGridColumn106.Header.Caption = " "
        UltraGridColumn106.Header.VisiblePosition = 0
        UltraGridColumn106.Hidden = True
        UltraGridColumn106.MaxWidth = 25
        UltraGridColumn106.MinWidth = 25
        UltraGridColumn106.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn106.Width = 25
        UltraGridColumn107.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn107.Header.VisiblePosition = 2
        UltraGridColumn107.Width = 228
        UltraGridColumn108.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn108.Header.VisiblePosition = 1
        UltraGridColumn108.Width = 154
        UltraGridColumn109.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn109.Header.VisiblePosition = 3
        UltraGridColumn109.Width = 193
        UltraGridColumn110.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn110.Header.VisiblePosition = 4
        UltraGridColumn110.Width = 134
        UltraGridColumn111.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance229.TextHAlignAsString = "Right"
        UltraGridColumn111.CellAppearance = Appearance229
        UltraGridColumn111.Format = "#,##0.00"
        UltraGridColumn111.Header.VisiblePosition = 5
        UltraGridColumn111.Width = 113
        UltraGridColumn112.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance230.TextHAlignAsString = "Right"
        UltraGridColumn112.CellAppearance = Appearance230
        UltraGridColumn112.Format = "#,##0.00"
        UltraGridColumn112.Header.VisiblePosition = 6
        UltraGridColumn112.Width = 102
        UltraGridColumn113.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance231.TextHAlignAsString = "Right"
        UltraGridColumn113.CellAppearance = Appearance231
        UltraGridColumn113.Header.VisiblePosition = 7
        UltraGridColumn113.Width = 109
        UltraGridColumn114.Header.VisiblePosition = 8
        UltraGridColumn114.Width = 101
        UltraGridBand13.Columns.AddRange(New Object() {UltraGridColumn106, UltraGridColumn107, UltraGridColumn108, UltraGridColumn109, UltraGridColumn110, UltraGridColumn111, UltraGridColumn112, UltraGridColumn113, UltraGridColumn114})
        Appearance232.TextHAlignAsString = "Right"
        SummarySettings21.Appearance = Appearance232
        SummarySettings21.DisplayFormat = "{0:###,##0}"
        SummarySettings21.GroupBySummaryValueAppearance = Appearance233
        Appearance234.TextHAlignAsString = "Right"
        SummarySettings22.Appearance = Appearance234
        SummarySettings22.DisplayFormat = "{0:###,##0}"
        SummarySettings22.GroupBySummaryValueAppearance = Appearance235
        UltraGridBand13.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings21, SummarySettings22})
        UltraGridBand13.SummaryFooterCaption = ""
        Me.girdCanteraDet1.DisplayLayout.BandsSerializer.Add(UltraGridBand13)
        Me.girdCanteraDet1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.girdCanteraDet1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.girdCanteraDet1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion141)
        Me.girdCanteraDet1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion142)
        Me.girdCanteraDet1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion143)
        Me.girdCanteraDet1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion144)
        Me.girdCanteraDet1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion145)
        Me.girdCanteraDet1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion146)
        Me.girdCanteraDet1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion147)
        Me.girdCanteraDet1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion148)
        Me.girdCanteraDet1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion149)
        Me.girdCanteraDet1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion150)
        Me.girdCanteraDet1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion151)
        Me.girdCanteraDet1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion152)
        Me.girdCanteraDet1.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance236.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance236.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance236.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance236.BorderColor = System.Drawing.SystemColors.Window
        Me.girdCanteraDet1.DisplayLayout.GroupByBox.Appearance = Appearance236
        Appearance237.ForeColor = System.Drawing.SystemColors.GrayText
        Me.girdCanteraDet1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance237
        Me.girdCanteraDet1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.girdCanteraDet1.DisplayLayout.GroupByBox.Hidden = True
        Appearance238.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance238.BackColor2 = System.Drawing.SystemColors.Control
        Appearance238.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance238.ForeColor = System.Drawing.SystemColors.GrayText
        Me.girdCanteraDet1.DisplayLayout.GroupByBox.PromptAppearance = Appearance238
        Me.girdCanteraDet1.DisplayLayout.MaxColScrollRegions = 1
        Me.girdCanteraDet1.DisplayLayout.MaxRowScrollRegions = 1
        Me.girdCanteraDet1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.girdCanteraDet1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.girdCanteraDet1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance239.BackColor = System.Drawing.SystemColors.Window
        Me.girdCanteraDet1.DisplayLayout.Override.CardAreaAppearance = Appearance239
        Appearance240.BorderColor = System.Drawing.Color.Silver
        Appearance240.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.girdCanteraDet1.DisplayLayout.Override.CellAppearance = Appearance240
        Me.girdCanteraDet1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.girdCanteraDet1.DisplayLayout.Override.CellPadding = 0
        Me.girdCanteraDet1.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.girdCanteraDet1.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.girdCanteraDet1.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.girdCanteraDet1.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance241.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.girdCanteraDet1.DisplayLayout.Override.FilterRowAppearance = Appearance241
        Me.girdCanteraDet1.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.girdCanteraDet1.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.girdCanteraDet1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance242.BackColor = System.Drawing.SystemColors.Control
        Appearance242.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance242.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance242.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance242.BorderColor = System.Drawing.SystemColors.Window
        Me.girdCanteraDet1.DisplayLayout.Override.GroupByRowAppearance = Appearance242
        Appearance243.FontData.Name = "Arial Narrow"
        Appearance243.FontData.SizeInPoints = 10.0!
        Appearance243.TextHAlignAsString = "Left"
        Me.girdCanteraDet1.DisplayLayout.Override.HeaderAppearance = Appearance243
        Me.girdCanteraDet1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.girdCanteraDet1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.girdCanteraDet1.DisplayLayout.Override.MinRowHeight = 24
        Appearance244.BackColor = System.Drawing.SystemColors.Window
        Appearance244.BorderColor = System.Drawing.Color.Silver
        Appearance244.TextVAlignAsString = "Middle"
        Me.girdCanteraDet1.DisplayLayout.Override.RowAppearance = Appearance244
        Me.girdCanteraDet1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.girdCanteraDet1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.girdCanteraDet1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance245.BackColor = System.Drawing.SystemColors.ControlLight
        Me.girdCanteraDet1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance245
        Me.girdCanteraDet1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.girdCanteraDet1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.girdCanteraDet1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.girdCanteraDet1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.girdCanteraDet1.Location = New System.Drawing.Point(108, 75)
        Me.girdCanteraDet1.Name = "girdCanteraDet1"
        Me.girdCanteraDet1.Size = New System.Drawing.Size(1174, 556)
        Me.girdCanteraDet1.TabIndex = 174
        Me.girdCanteraDet1.Text = "UltraGrid1"
        '
        'Tab1
        '
        Appearance17.FontData.BoldAsString = "True"
        Appearance17.FontData.Name = "Arial Narrow"
        Appearance17.FontData.SizeInPoints = 16.0!
        Me.Tab1.ActiveTabAppearance = Appearance17
        Appearance18.FontData.Name = "Arial Narrow"
        Appearance18.FontData.SizeInPoints = 10.0!
        Me.Tab1.Appearance = Appearance18
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Controls.Add(Me.tab2)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl2)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(1649, 854)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance19.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance19
        Me.Tab1.TabIndex = 16
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance24.Cursor = System.Windows.Forms.Cursors.Default
        Appearance24.FontData.BoldAsString = "True"
        Appearance24.FontData.Name = "Arial Narrow"
        Appearance24.FontData.SizeInPoints = 16.0!
        UltraTab3.ActiveAppearance = Appearance24
        Appearance43.FontData.Name = "Arial Narrow"
        Appearance43.FontData.SizeInPoints = 10.0!
        UltraTab3.Appearance = Appearance43
        UltraTab3.Key = "T01"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "CONTROL DE INVENTARIOS MP"
        UltraTab1.Key = "T02"
        UltraTab1.TabPage = Me.tab2
        UltraTab1.Text = "STOCK DE RUMAS"
        UltraTab2.Key = "T03"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "DETALLADO POR CANTERA"
        UltraTab2.Visible = False
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3, UltraTab1, UltraTab2})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1645, 816)
        '
        'lblayo6
        '
        Me.lblayo6.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lblayo6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblayo6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblayo6.ForeColor = System.Drawing.Color.Black
        Me.lblayo6.Location = New System.Drawing.Point(1540, 32)
        Me.lblayo6.Name = "lblayo6"
        Me.lblayo6.Size = New System.Drawing.Size(65, 36)
        Me.lblayo6.TabIndex = 259
        Me.lblayo6.Text = "Año 6"
        Me.lblayo6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmControlInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1649, 854)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmControlInventario"
        Me.Text = "FrmControlInventario"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.girdCanteraDet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.gridRenlazada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gridAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaIni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btncambiar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.gridComposicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.gridTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.gridMineral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.gridRuma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.gridReportenoCumple, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab2.ResumeLayout(False)
        Me.tab2.PerformLayout()
        Me.gpbHistorial.ResumeLayout(False)
        Me.gpbHistorial.PerformLayout()
        CType(Me.gridHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtobservacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridReporteStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.girdCanteraDet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtayo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents gridMineral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents gridRuma As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gridAlmacen As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gridMes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chkruma As System.Windows.Forms.CheckBox
    Friend WithEvents chkalmacen As System.Windows.Forms.CheckBox
    Friend WithEvents chkmes As System.Windows.Forms.CheckBox
    Friend WithEvents lblfinal As System.Windows.Forms.Label
    Friend WithEvents lblsalida As System.Windows.Forms.Label
    Friend WithEvents lblentrada As System.Windows.Forms.Label
    Friend WithEvents lblinicial As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblpromedio As System.Windows.Forms.Label
    Friend WithEvents lblmesesstk As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblmax As System.Windows.Forms.Label
    Friend WithEvents lblmin As System.Windows.Forms.Label
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents gridTipo As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents tab2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents gridReporte As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents gridComposicion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btncambiar As System.Windows.Forms.PictureBox
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtFechaFin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dtFechaIni As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents btncambiagrafica As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents gridRenlazada As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblayo1 As System.Windows.Forms.Label
    Friend WithEvents lblayo5 As System.Windows.Forms.Label
    Friend WithEvents lblayo4 As System.Windows.Forms.Label
    Friend WithEvents lblayo3 As System.Windows.Forms.Label
    Friend WithEvents lblayo2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblfinalV As System.Windows.Forms.Label
    Friend WithEvents lblsalidaV As System.Windows.Forms.Label
    Friend WithEvents lblentradaV As System.Windows.Forms.Label
    Friend WithEvents lblinicialV As System.Windows.Forms.Label
    Friend WithEvents chkrumaenlazada As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btngraficasoles As System.Windows.Forms.Button
    Friend WithEvents gridReportenoCumple As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lbldefsol As System.Windows.Forms.Label
    Friend WithEvents lbltonsol As System.Windows.Forms.Label
    Friend WithEvents lbldefton As System.Windows.Forms.Label
    Friend WithEvents lbltonexe As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnexportar As System.Windows.Forms.Button
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents txtobservacion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblhist As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents gpbHistorial As System.Windows.Forms.GroupBox
    Friend WithEvents gridHistorial As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents girdCanteraDet1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents gridReporteStock As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents girdCanteraDet As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chkMineral As System.Windows.Forms.CheckBox
    Friend WithEvents lblayo6 As System.Windows.Forms.Label
End Class
