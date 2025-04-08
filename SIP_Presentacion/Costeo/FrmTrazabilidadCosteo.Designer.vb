<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTrazabilidadCosteo
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
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem13 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem14 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem15 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem16 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem17 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem18 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem19 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem20 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem21 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem22 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem23 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem24 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTrazabilidadCosteo))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROD", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PRODUCTO", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TON", 2)
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MINERAL", 3)
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CHANCADO", 4)
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MOLIENDA", 5)
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ENVASES", 6)
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOTALPRODUCCION", 7)
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GASTOSADM", 8)
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GASTOSVENTA", 9)
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOTALTON", 10)
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOTVARIABLE", 11)
        Dim Appearance158 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOTFIJO", 12)
        Dim Appearance159 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1077)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(698)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(740)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion12 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion13 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion14 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance152 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance153 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance161 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance162 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CODRUMA", 0)
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("INSUMO", 1)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TON_MATERIA_PRIMA", 2)
        Dim Appearance163 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COSTOXTONRUMA", 3)
        Dim Appearance164 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TONMERMAH", 4)
        Dim Appearance165 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TONCONSUMIDA", 5)
        Dim Appearance166 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COSTOTOTAL", 6)
        Dim Appearance167 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TONPRODUCTO", 7)
        Dim Appearance168 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "", Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TON", -2, False)
        Dim Appearance169 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance170 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TOT_COSTO", -2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TOT_COSTO", -2, False)
        Dim Appearance171 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance172 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion15 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(888)
        Dim ColScrollRegion16 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(429)
        Dim ColScrollRegion17 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(429)
        Dim ColScrollRegion18 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(712)
        Dim ColScrollRegion19 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(698)
        Dim ColScrollRegion20 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(740)
        Dim ColScrollRegion21 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion22 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion23 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion24 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion25 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion26 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion27 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion28 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion29 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion30 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion31 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance173 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance174 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance175 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance176 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance177 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance178 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance179 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance180 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance181 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance182 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance103 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance104 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CODRUMA", 0)
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("INSUMO", 1)
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TON_MATERIA_PRIMA", 2)
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COSTOXTONRUMA", 3)
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TONMERMAH", 4)
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TONCONSUMIDA", 5)
        Dim Appearance102 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COSTOTOTAL", 6)
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TONPRODUCTO", 7)
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings3 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "", Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TON", -2, False)
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance120 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings4 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TOT_COSTO", -2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TOT_COSTO", -2, False)
        Dim Appearance121 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance122 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion32 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(647)
        Dim ColScrollRegion33 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(539)
        Dim ColScrollRegion34 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(429)
        Dim ColScrollRegion35 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(429)
        Dim ColScrollRegion36 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(712)
        Dim ColScrollRegion37 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(698)
        Dim ColScrollRegion38 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(740)
        Dim ColScrollRegion39 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion40 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion41 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion42 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion43 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion44 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion45 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion46 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion47 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion48 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion49 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance123 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance126 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance128 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance129 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance130 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance131 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance132 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance154 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance155 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance156 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance157 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance147 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance149 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance150 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance151 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance146 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_RUMA", 0)
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RUMA", 1)
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EQUIPO", 2)
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONCEPTO", 3)
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TON_CHANCADO", 4)
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TON_MATPRIMA", 5)
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOT_COSTO", 6)
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COSTOXTON_CHANCADO", 7)
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COSTOXTON_TOTAL_MATPRIMA", 8)
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings5 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "", Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "COSTOXTON_CHANCADO", 7, False)
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings6 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "COSTOXTON_TOTAL_MATPRIMA", 8, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "COSTOXTON_TOTAL_MATPRIMA", 8, False)
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion50 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(845)
        Dim ColScrollRegion51 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(429)
        Dim ColScrollRegion52 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(712)
        Dim ColScrollRegion53 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(698)
        Dim ColScrollRegion54 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(740)
        Dim ColScrollRegion55 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion56 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion57 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion58 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion59 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion60 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion61 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion62 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion63 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion64 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion65 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance107 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance108 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ENLACE", 0)
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EQUIPO", 1)
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONCEPTO", 2)
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TON", 3)
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOT_COSTO_VAR", 4)
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOT_COSTO_FIJO", 5)
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROD", 6)
        Dim SummarySettings7 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "", Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TON", 3, False)
        Dim Appearance115 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance116 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings8 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TOT_COSTO", -2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TOT_COSTO", -2, False)
        Dim Appearance117 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance118 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion66 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(888)
        Dim ColScrollRegion67 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(888)
        Dim ColScrollRegion68 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(429)
        Dim ColScrollRegion69 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(429)
        Dim ColScrollRegion70 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(712)
        Dim ColScrollRegion71 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(698)
        Dim ColScrollRegion72 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(740)
        Dim ColScrollRegion73 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion74 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion75 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion76 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion77 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion78 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion79 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion80 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion81 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion82 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion83 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance133 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance134 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance135 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance136 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance137 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance138 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance139 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance140 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance141 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance142 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance143 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance144 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance145 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance148 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand6 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROD", 0)
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EQUIPO", 1)
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONCEPTO", 2)
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TON", 3)
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOT_COSTO_VAR", 4)
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOT_COSTO_FIJO", 5)
        Dim Appearance160 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ENLACE", 6)
        Dim SummarySettings9 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "", Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TON", 3, False)
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings10 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TOT_COSTO_VAR", 4, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TOT_COSTO_VAR", 4, False)
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion84 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(864)
        Dim ColScrollRegion85 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(712)
        Dim ColScrollRegion86 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(698)
        Dim ColScrollRegion87 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(740)
        Dim ColScrollRegion88 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion89 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion90 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion91 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion92 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion93 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion94 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion95 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion96 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion97 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion98 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataBand1 As Infragistics.Win.UltraWinDataSource.UltraDataBand = New Infragistics.Win.UltraWinDataSource.UltraDataBand("Band 1")
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Action")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UltraLabel16 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbMes = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.txtayo = New System.Windows.Forms.NumericUpDown
        Me.gridCostos = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnrevision = New System.Windows.Forms.Button
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.txtcostoxtonfijo1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel20 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcostoxtonvar1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel21 = New Infragistics.Win.Misc.UltraLabel
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtcostoxton3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel22 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.txttoneladas3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraTextEditor1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcostototal3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.gridMineral = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGrid3 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Label5 = New System.Windows.Forms.Label
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.txtcostoxtonfijo2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcostoxtonvar2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcostoFIJO = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcostoVAR = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtcostoxton2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.txttoneladas2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.txtcostototal2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.txtcostoxtonfijo3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel18 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcostoxtonvar3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel19 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel15 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcostoFIJO2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel17 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcostoVAR2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtcostoxton = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.txttoneladas = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.UltraGrid11 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.txtcostototal = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source4 = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridCostos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl4.SuspendLayout()
        CType(Me.txtcostoxtonfijo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostoxtonvar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostoxton3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttoneladas3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostototal3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridMineral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.txtcostoxtonfijo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostoxtonvar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostoFIJO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostoVAR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostoxton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttoneladas2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostototal2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostoxtonfijo3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostoxtonvar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostoFIJO2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostoVAR2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostoxton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttoneladas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcostototal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Panel1)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1099, 433)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.UltraLabel16)
        Me.Panel1.Controls.Add(Me.cmbMes)
        Me.Panel1.Controls.Add(Me.UltraLabel6)
        Me.Panel1.Controls.Add(Me.txtayo)
        Me.Panel1.Controls.Add(Me.gridCostos)
        Me.Panel1.Controls.Add(Me.btnrevision)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1099, 433)
        Me.Panel1.TabIndex = 176
        '
        'UltraLabel16
        '
        Appearance33.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel16.Appearance = Appearance33
        Me.UltraLabel16.AutoSize = True
        Me.UltraLabel16.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel16.Location = New System.Drawing.Point(31, 41)
        Me.UltraLabel16.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel16.Name = "UltraLabel16"
        Me.UltraLabel16.Size = New System.Drawing.Size(26, 17)
        Me.UltraLabel16.TabIndex = 201
        Me.UltraLabel16.Text = "Mes"
        '
        'cmbMes
        '
        Me.cmbMes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMes.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem13.DataValue = "1"
        ValueListItem13.DisplayText = "ENERO"
        ValueListItem14.DataValue = "2"
        ValueListItem14.DisplayText = "FEBRERO"
        ValueListItem15.DataValue = "3"
        ValueListItem15.DisplayText = "MARZO"
        ValueListItem16.DataValue = "4"
        ValueListItem16.DisplayText = "ABRIL"
        ValueListItem17.DataValue = "5"
        ValueListItem17.DisplayText = "MAYO"
        ValueListItem18.DataValue = "6"
        ValueListItem18.DisplayText = "JUNIO"
        ValueListItem19.DataValue = "7"
        ValueListItem19.DisplayText = "JULIO"
        ValueListItem20.DataValue = "8"
        ValueListItem20.DisplayText = "AGOSTO"
        ValueListItem21.DataValue = "9"
        ValueListItem21.DisplayText = "SETIEMBRE"
        ValueListItem22.DataValue = "10"
        ValueListItem22.DisplayText = "OCTUBRE"
        ValueListItem23.DataValue = "11"
        ValueListItem23.DisplayText = "NOVIEMBRE"
        ValueListItem24.DataValue = "12"
        ValueListItem24.DisplayText = "DICIEMBRE"
        Me.cmbMes.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem13, ValueListItem14, ValueListItem15, ValueListItem16, ValueListItem17, ValueListItem18, ValueListItem19, ValueListItem20, ValueListItem21, ValueListItem22, ValueListItem23, ValueListItem24})
        Me.cmbMes.Location = New System.Drawing.Point(65, 39)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(150, 21)
        Me.cmbMes.TabIndex = 200
        '
        'UltraLabel6
        '
        Appearance38.BackColor = System.Drawing.Color.Transparent
        Appearance38.TextHAlignAsString = "Center"
        Appearance38.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance38
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(31, 16)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(24, 14)
        Me.UltraLabel6.TabIndex = 199
        Me.UltraLabel6.Text = "Año"
        '
        'txtayo
        '
        Me.txtayo.Location = New System.Drawing.Point(65, 14)
        Me.txtayo.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtayo.Name = "txtayo"
        Me.txtayo.Size = New System.Drawing.Size(57, 20)
        Me.txtayo.TabIndex = 198
        Me.txtayo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtayo.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'gridCostos
        '
        Me.gridCostos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridCostos.DisplayLayout.Appearance = Appearance1
        Me.gridCostos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance2.Image = CType(resources.GetObject("Appearance2.Image"), Object)
        Appearance2.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance2
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.Caption = "CODIGO"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.MaxWidth = 70
        UltraGridColumn2.MinWidth = 70
        UltraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn2.Width = 70
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn3.Width = 353
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance3
        UltraGridColumn4.Format = "#####,##0.00###"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.MaxWidth = 70
        UltraGridColumn4.MinWidth = 70
        UltraGridColumn4.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn4.Width = 70
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance5
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.MaxWidth = 65
        UltraGridColumn5.MinWidth = 65
        UltraGridColumn5.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn5.Width = 65
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance23
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.MaxWidth = 75
        UltraGridColumn6.MinWidth = 75
        UltraGridColumn6.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn6.Width = 75
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance25.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance25
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.MaxWidth = 75
        UltraGridColumn7.MinWidth = 75
        UltraGridColumn7.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn7.Width = 75
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance26.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance26
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.MaxWidth = 65
        UltraGridColumn8.MinWidth = 65
        UltraGridColumn8.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn8.Width = 65
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance27.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance27
        UltraGridColumn9.Header.Caption = "TOTAL PRODUCC."
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.MaxLength = 80
        UltraGridColumn9.MaxWidth = 80
        UltraGridColumn9.MinWidth = 80
        UltraGridColumn9.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn9.Width = 80
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance28.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance28
        UltraGridColumn10.Header.Caption = "ADM."
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.MaxLength = 65
        UltraGridColumn10.MaxWidth = 65
        UltraGridColumn10.MinWidth = 65
        UltraGridColumn10.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn10.Width = 65
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance29.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance29
        UltraGridColumn11.Header.Caption = "VENTAS"
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.MaxLength = 65
        UltraGridColumn11.MaxWidth = 65
        UltraGridColumn11.MinWidth = 65
        UltraGridColumn11.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn11.Width = 65
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance30.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance30
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.MaxLength = 75
        UltraGridColumn12.MaxWidth = 75
        UltraGridColumn12.MinWidth = 75
        UltraGridColumn12.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn12.Width = 75
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance158.TextHAlignAsString = "Right"
        UltraGridColumn13.CellAppearance = Appearance158
        UltraGridColumn13.Header.Caption = "VARIABLE"
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn13.Width = 94
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance159.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance159
        UltraGridColumn14.Header.Caption = "FIJO"
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn14.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn14.Width = 92
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14})
        Me.gridCostos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridCostos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridCostos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion13)
        Me.gridCostos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion14)
        Me.gridCostos.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance40.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance40.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance40.BorderColor = System.Drawing.SystemColors.Window
        Me.gridCostos.DisplayLayout.GroupByBox.Appearance = Appearance40
        Appearance50.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridCostos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance50
        Me.gridCostos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridCostos.DisplayLayout.GroupByBox.Hidden = True
        Appearance60.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance60.BackColor2 = System.Drawing.SystemColors.Control
        Appearance60.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance60.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridCostos.DisplayLayout.GroupByBox.PromptAppearance = Appearance60
        Me.gridCostos.DisplayLayout.MaxColScrollRegions = 1
        Me.gridCostos.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridCostos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridCostos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridCostos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance61.BackColor = System.Drawing.SystemColors.Window
        Me.gridCostos.DisplayLayout.Override.CardAreaAppearance = Appearance61
        Appearance6.BorderColor = System.Drawing.Color.Silver
        Appearance6.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridCostos.DisplayLayout.Override.CellAppearance = Appearance6
        Me.gridCostos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridCostos.DisplayLayout.Override.CellPadding = 0
        Me.gridCostos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridCostos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridCostos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridCostos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance63.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance63.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridCostos.DisplayLayout.Override.FilterRowAppearance = Appearance63
        Me.gridCostos.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridCostos.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridCostos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance64.BackColor = System.Drawing.SystemColors.Control
        Appearance64.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance64.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance64.BorderColor = System.Drawing.SystemColors.Window
        Me.gridCostos.DisplayLayout.Override.GroupByRowAppearance = Appearance64
        Appearance65.FontData.Name = "Arial Narrow"
        Appearance65.FontData.SizeInPoints = 10.0!
        Appearance65.TextHAlignAsString = "Left"
        Me.gridCostos.DisplayLayout.Override.HeaderAppearance = Appearance65
        Me.gridCostos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridCostos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridCostos.DisplayLayout.Override.MinRowHeight = 24
        Appearance66.BackColor = System.Drawing.SystemColors.Window
        Appearance66.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance66.TextVAlignAsString = "Middle"
        Me.gridCostos.DisplayLayout.Override.RowAppearance = Appearance66
        Me.gridCostos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridCostos.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridCostos.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance67.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridCostos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance67
        Me.gridCostos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridCostos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridCostos.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridCostos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridCostos.Location = New System.Drawing.Point(11, 67)
        Me.gridCostos.Name = "gridCostos"
        Me.gridCostos.Size = New System.Drawing.Size(1079, 357)
        Me.gridCostos.TabIndex = 197
        '
        'btnrevision
        '
        Me.btnrevision.Image = Global.SIP_Presentacion.My.Resources.Resources.layout_edit
        Me.btnrevision.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnrevision.Location = New System.Drawing.Point(565, 375)
        Me.btnrevision.Name = "btnrevision"
        Me.btnrevision.Size = New System.Drawing.Size(191, 37)
        Me.btnrevision.TabIndex = 1
        Me.btnrevision.Text = "Revision de Canteras"
        Me.btnrevision.UseVisualStyleBackColor = True
        Me.btnrevision.Visible = False
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.txtcostoxtonfijo1)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel20)
        Me.UltraTabPageControl4.Controls.Add(Me.txtcostoxtonvar1)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel21)
        Me.UltraTabPageControl4.Controls.Add(Me.Label6)
        Me.UltraTabPageControl4.Controls.Add(Me.txtcostoxton3)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel8)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel22)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel9)
        Me.UltraTabPageControl4.Controls.Add(Me.txttoneladas3)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraTextEditor1)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel10)
        Me.UltraTabPageControl4.Controls.Add(Me.txtcostototal3)
        Me.UltraTabPageControl4.Controls.Add(Me.gridMineral)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraGrid3)
        Me.UltraTabPageControl4.Controls.Add(Me.Label5)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(1099, 433)
        '
        'txtcostoxtonfijo1
        '
        Me.txtcostoxtonfijo1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance81.FontData.BoldAsString = "False"
        Appearance81.ForeColor = System.Drawing.Color.Black
        Appearance81.TextHAlignAsString = "Right"
        Appearance81.TextVAlignAsString = "Middle"
        Me.txtcostoxtonfijo1.Appearance = Appearance81
        Me.txtcostoxtonfijo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoxtonfijo1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoxtonfijo1.Location = New System.Drawing.Point(990, 126)
        Me.txtcostoxtonfijo1.MaxLength = 8
        Me.txtcostoxtonfijo1.Name = "txtcostoxtonfijo1"
        Me.txtcostoxtonfijo1.ReadOnly = True
        Me.txtcostoxtonfijo1.Size = New System.Drawing.Size(94, 21)
        Me.txtcostoxtonfijo1.TabIndex = 229
        Me.txtcostoxtonfijo1.TabStop = False
        Me.txtcostoxtonfijo1.Text = "0.00"
        '
        'UltraLabel20
        '
        Me.UltraLabel20.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance82.BackColor = System.Drawing.Color.Transparent
        Appearance82.TextHAlignAsString = "Center"
        Appearance82.TextVAlignAsString = "Middle"
        Me.UltraLabel20.Appearance = Appearance82
        Me.UltraLabel20.AutoSize = True
        Me.UltraLabel20.Location = New System.Drawing.Point(902, 130)
        Me.UltraLabel20.Name = "UltraLabel20"
        Me.UltraLabel20.Size = New System.Drawing.Size(82, 14)
        Me.UltraLabel20.TabIndex = 230
        Me.UltraLabel20.Text = "Costo x TN Fijo"
        '
        'txtcostoxtonvar1
        '
        Me.txtcostoxtonvar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance152.FontData.BoldAsString = "False"
        Appearance152.ForeColor = System.Drawing.Color.Black
        Appearance152.TextHAlignAsString = "Right"
        Appearance152.TextVAlignAsString = "Middle"
        Me.txtcostoxtonvar1.Appearance = Appearance152
        Me.txtcostoxtonvar1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoxtonvar1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoxtonvar1.Location = New System.Drawing.Point(990, 99)
        Me.txtcostoxtonvar1.MaxLength = 8
        Me.txtcostoxtonvar1.Name = "txtcostoxtonvar1"
        Me.txtcostoxtonvar1.ReadOnly = True
        Me.txtcostoxtonvar1.Size = New System.Drawing.Size(94, 21)
        Me.txtcostoxtonvar1.TabIndex = 227
        Me.txtcostoxtonvar1.TabStop = False
        Me.txtcostoxtonvar1.Text = "0.00"
        '
        'UltraLabel21
        '
        Me.UltraLabel21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance153.BackColor = System.Drawing.Color.Transparent
        Appearance153.TextHAlignAsString = "Center"
        Appearance153.TextVAlignAsString = "Middle"
        Me.UltraLabel21.Appearance = Appearance153
        Me.UltraLabel21.AutoSize = True
        Me.UltraLabel21.Location = New System.Drawing.Point(903, 102)
        Me.UltraLabel21.Name = "UltraLabel21"
        Me.UltraLabel21.Size = New System.Drawing.Size(81, 14)
        Me.UltraLabel21.TabIndex = 228
        Me.UltraLabel21.Text = "Costo x TN Var"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label6.Location = New System.Drawing.Point(992, 193)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 16)
        Me.Label6.TabIndex = 222
        Me.Label6.Text = "REGRESAR"
        '
        'txtcostoxton3
        '
        Me.txtcostoxton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance44.FontData.BoldAsString = "False"
        Appearance44.ForeColor = System.Drawing.Color.Black
        Appearance44.TextHAlignAsString = "Right"
        Appearance44.TextVAlignAsString = "Middle"
        Me.txtcostoxton3.Appearance = Appearance44
        Me.txtcostoxton3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoxton3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoxton3.Location = New System.Drawing.Point(990, 153)
        Me.txtcostoxton3.MaxLength = 8
        Me.txtcostoxton3.Name = "txtcostoxton3"
        Me.txtcostoxton3.ReadOnly = True
        Me.txtcostoxton3.Size = New System.Drawing.Size(94, 21)
        Me.txtcostoxton3.TabIndex = 220
        Me.txtcostoxton3.TabStop = False
        Me.txtcostoxton3.Text = "0.00"
        '
        'UltraLabel8
        '
        Me.UltraLabel8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance86.BackColor = System.Drawing.Color.Transparent
        Appearance86.TextHAlignAsString = "Center"
        Appearance86.TextVAlignAsString = "Middle"
        Me.UltraLabel8.Appearance = Appearance86
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Location = New System.Drawing.Point(923, 157)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(61, 14)
        Me.UltraLabel8.TabIndex = 221
        Me.UltraLabel8.Text = "Costo x TN"
        '
        'UltraLabel22
        '
        Me.UltraLabel22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance85.BackColor = System.Drawing.Color.Transparent
        Appearance85.TextHAlignAsString = "Center"
        Appearance85.TextVAlignAsString = "Middle"
        Me.UltraLabel22.Appearance = Appearance85
        Me.UltraLabel22.AutoSize = True
        Me.UltraLabel22.Location = New System.Drawing.Point(1122, 72)
        Me.UltraLabel22.Name = "UltraLabel22"
        Me.UltraLabel22.Size = New System.Drawing.Size(62, 14)
        Me.UltraLabel22.TabIndex = 219
        Me.UltraLabel22.Text = "Costo Total"
        '
        'UltraLabel9
        '
        Me.UltraLabel9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel9.Appearance = Appearance4
        Me.UltraLabel9.AutoSize = True
        Me.UltraLabel9.Location = New System.Drawing.Point(924, 50)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(62, 14)
        Me.UltraLabel9.TabIndex = 219
        Me.UltraLabel9.Text = "Costo Total"
        Me.UltraLabel9.Visible = False
        '
        'txttoneladas3
        '
        Me.txttoneladas3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance80.FontData.BoldAsString = "False"
        Appearance80.ForeColor = System.Drawing.Color.Black
        Appearance80.TextHAlignAsString = "Right"
        Appearance80.TextVAlignAsString = "Middle"
        Me.txttoneladas3.Appearance = Appearance80
        Me.txttoneladas3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttoneladas3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttoneladas3.Location = New System.Drawing.Point(990, 72)
        Me.txttoneladas3.MaxLength = 8
        Me.txttoneladas3.Name = "txttoneladas3"
        Me.txttoneladas3.ReadOnly = True
        Me.txttoneladas3.Size = New System.Drawing.Size(94, 21)
        Me.txttoneladas3.TabIndex = 216
        Me.txttoneladas3.TabStop = False
        Me.txttoneladas3.Text = "0.00"
        '
        'UltraTextEditor1
        '
        Me.UltraTextEditor1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance84.FontData.BoldAsString = "False"
        Appearance84.ForeColor = System.Drawing.Color.Black
        Appearance84.TextHAlignAsString = "Right"
        Appearance84.TextVAlignAsString = "Middle"
        Me.UltraTextEditor1.Appearance = Appearance84
        Me.UltraTextEditor1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.UltraTextEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.UltraTextEditor1.Location = New System.Drawing.Point(1188, 68)
        Me.UltraTextEditor1.MaxLength = 8
        Me.UltraTextEditor1.Name = "UltraTextEditor1"
        Me.UltraTextEditor1.ReadOnly = True
        Me.UltraTextEditor1.Size = New System.Drawing.Size(94, 21)
        Me.UltraTextEditor1.TabIndex = 218
        Me.UltraTextEditor1.TabStop = False
        Me.UltraTextEditor1.Text = "0.00"
        '
        'UltraLabel10
        '
        Me.UltraLabel10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance20.BackColor = System.Drawing.Color.Transparent
        Appearance20.TextHAlignAsString = "Center"
        Appearance20.TextVAlignAsString = "Middle"
        Me.UltraLabel10.Appearance = Appearance20
        Me.UltraLabel10.AutoSize = True
        Me.UltraLabel10.Location = New System.Drawing.Point(907, 76)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(79, 14)
        Me.UltraLabel10.TabIndex = 217
        Me.UltraLabel10.Text = "TN Producidas"
        '
        'txtcostototal3
        '
        Me.txtcostototal3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance83.FontData.BoldAsString = "False"
        Appearance83.ForeColor = System.Drawing.Color.Black
        Appearance83.TextHAlignAsString = "Right"
        Appearance83.TextVAlignAsString = "Middle"
        Me.txtcostototal3.Appearance = Appearance83
        Me.txtcostototal3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostototal3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostototal3.Location = New System.Drawing.Point(990, 46)
        Me.txtcostototal3.MaxLength = 8
        Me.txtcostototal3.Name = "txtcostototal3"
        Me.txtcostototal3.ReadOnly = True
        Me.txtcostototal3.Size = New System.Drawing.Size(94, 21)
        Me.txtcostototal3.TabIndex = 218
        Me.txtcostototal3.TabStop = False
        Me.txtcostototal3.Text = "0.00"
        Me.txtcostototal3.Visible = False
        '
        'gridMineral
        '
        Me.gridMineral.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance161.BackColor = System.Drawing.SystemColors.Window
        Appearance161.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridMineral.DisplayLayout.Appearance = Appearance161
        Me.gridMineral.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn15.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance162.Image = CType(resources.GetObject("Appearance162.Image"), Object)
        Appearance162.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance162.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn15.Header.Appearance = Appearance162
        UltraGridColumn15.Header.Caption = ""
        UltraGridColumn15.Header.VisiblePosition = 0
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.MaxWidth = 25
        UltraGridColumn15.MinWidth = 20
        UltraGridColumn15.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn15.Width = 20
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn16.Header.Caption = "CODIGO"
        UltraGridColumn16.Header.VisiblePosition = 1
        UltraGridColumn16.Width = 73
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn17.Header.Caption = "RUMA"
        UltraGridColumn17.Header.VisiblePosition = 2
        UltraGridColumn17.Width = 246
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance163.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance163
        UltraGridColumn18.Format = "#####,##0.00###"
        UltraGridColumn18.Header.Caption = "MAT. PRIMA (TM)"
        UltraGridColumn18.Header.VisiblePosition = 3
        UltraGridColumn18.Width = 101
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance164.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance164
        UltraGridColumn19.Header.Caption = "COSTO X TON RUMA"
        UltraGridColumn19.Header.VisiblePosition = 4
        UltraGridColumn19.Width = 100
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance165.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance165
        UltraGridColumn20.Format = "#####,##0.00###"
        UltraGridColumn20.Header.Caption = "MERMA / HUMEDAD"
        UltraGridColumn20.Header.VisiblePosition = 5
        UltraGridColumn20.Width = 115
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance166.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance166
        UltraGridColumn21.Format = "#####,##0.00###"
        UltraGridColumn21.Header.Caption = "TON. CONSUMIDA"
        UltraGridColumn21.Header.VisiblePosition = 6
        UltraGridColumn21.Width = 121
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance167.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance167
        UltraGridColumn22.Format = "#####,##0.00###"
        UltraGridColumn22.Header.Caption = "COSTO X TON PRODUCIDA"
        UltraGridColumn22.Header.VisiblePosition = 7
        UltraGridColumn22.Width = 77
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance168.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance168
        UltraGridColumn23.Header.VisiblePosition = 8
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.Width = 88
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23})
        Appearance169.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance169
        SummarySettings1.DisplayFormat = "TOTAL"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance170
        Appearance171.TextHAlignAsString = "Right"
        SummarySettings2.Appearance = Appearance171
        SummarySettings2.DisplayFormat = "{0}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance172
        UltraGridBand2.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2})
        UltraGridBand2.SummaryFooterCaption = ""
        Me.gridMineral.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridMineral.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion15)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion16)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion17)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion18)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion19)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion20)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion21)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion22)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion23)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion24)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion25)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion26)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion27)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion28)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion29)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion30)
        Me.gridMineral.DisplayLayout.ColScrollRegions.Add(ColScrollRegion31)
        Me.gridMineral.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance173.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance173.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance173.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance173.BorderColor = System.Drawing.SystemColors.Window
        Me.gridMineral.DisplayLayout.GroupByBox.Appearance = Appearance173
        Appearance174.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridMineral.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance174
        Me.gridMineral.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridMineral.DisplayLayout.GroupByBox.Hidden = True
        Appearance175.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance175.BackColor2 = System.Drawing.SystemColors.Control
        Appearance175.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance175.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridMineral.DisplayLayout.GroupByBox.PromptAppearance = Appearance175
        Me.gridMineral.DisplayLayout.MaxColScrollRegions = 1
        Me.gridMineral.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridMineral.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridMineral.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridMineral.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance176.BackColor = System.Drawing.SystemColors.Window
        Me.gridMineral.DisplayLayout.Override.CardAreaAppearance = Appearance176
        Appearance177.BorderColor = System.Drawing.Color.Silver
        Appearance177.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridMineral.DisplayLayout.Override.CellAppearance = Appearance177
        Me.gridMineral.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridMineral.DisplayLayout.Override.CellPadding = 0
        Me.gridMineral.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridMineral.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridMineral.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridMineral.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance178.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance178.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridMineral.DisplayLayout.Override.FilterRowAppearance = Appearance178
        Me.gridMineral.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridMineral.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridMineral.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance179.BackColor = System.Drawing.SystemColors.Control
        Appearance179.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance179.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance179.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance179.BorderColor = System.Drawing.SystemColors.Window
        Me.gridMineral.DisplayLayout.Override.GroupByRowAppearance = Appearance179
        Appearance180.FontData.Name = "Arial Narrow"
        Appearance180.FontData.SizeInPoints = 10.0!
        Appearance180.TextHAlignAsString = "Left"
        Me.gridMineral.DisplayLayout.Override.HeaderAppearance = Appearance180
        Me.gridMineral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridMineral.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridMineral.DisplayLayout.Override.MinRowHeight = 24
        Appearance181.BackColor = System.Drawing.SystemColors.Window
        Appearance181.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance181.TextVAlignAsString = "Middle"
        Me.gridMineral.DisplayLayout.Override.RowAppearance = Appearance181
        Me.gridMineral.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridMineral.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridMineral.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance182.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridMineral.DisplayLayout.Override.TemplateAddRowAppearance = Appearance182
        Me.gridMineral.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridMineral.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridMineral.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridMineral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridMineral.Location = New System.Drawing.Point(11, 46)
        Me.gridMineral.Name = "gridMineral"
        Me.gridMineral.Size = New System.Drawing.Size(890, 377)
        Me.gridMineral.TabIndex = 211
        '
        'UltraGrid3
        '
        Me.UltraGrid3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance103.BackColor = System.Drawing.SystemColors.Window
        Appearance103.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraGrid3.DisplayLayout.Appearance = Appearance103
        Me.UltraGrid3.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn24.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance104.Image = CType(resources.GetObject("Appearance104.Image"), Object)
        Appearance104.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance104.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn24.Header.Appearance = Appearance104
        UltraGridColumn24.Header.Caption = ""
        UltraGridColumn24.Header.VisiblePosition = 0
        UltraGridColumn24.Hidden = True
        UltraGridColumn24.MaxWidth = 25
        UltraGridColumn24.MinWidth = 20
        UltraGridColumn24.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn24.Width = 20
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn25.Header.Caption = "CODIGO"
        UltraGridColumn25.Header.VisiblePosition = 1
        UltraGridColumn25.Width = 85
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn26.Header.Caption = "RUMA"
        UltraGridColumn26.Header.VisiblePosition = 2
        UltraGridColumn26.Width = 160
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance21
        UltraGridColumn27.Header.Caption = "MAT. PRIMA (TM)"
        UltraGridColumn27.Header.VisiblePosition = 3
        UltraGridColumn27.Width = 71
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance22
        UltraGridColumn28.Header.Caption = "COSTO X TON RUMA"
        UltraGridColumn28.Header.VisiblePosition = 4
        UltraGridColumn28.Width = 72
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance101.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance101
        UltraGridColumn29.Header.Caption = "MERMA / HUMEDAD"
        UltraGridColumn29.Header.VisiblePosition = 5
        UltraGridColumn29.Width = 69
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance102.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance102
        UltraGridColumn30.Header.Caption = "TON. CONSUMIDA"
        UltraGridColumn30.Header.VisiblePosition = 6
        UltraGridColumn30.Width = 72
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance105.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance105
        UltraGridColumn31.Header.Caption = "COSTO X TON PRODUCIDA"
        UltraGridColumn31.Header.VisiblePosition = 7
        UltraGridColumn31.Width = 63
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance106.TextHAlignAsString = "Right"
        UltraGridColumn32.CellAppearance = Appearance106
        UltraGridColumn32.Header.VisiblePosition = 8
        UltraGridColumn32.Hidden = True
        UltraGridColumn32.Width = 88
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32})
        Appearance119.TextHAlignAsString = "Right"
        SummarySettings3.Appearance = Appearance119
        SummarySettings3.DisplayFormat = "TOTAL"
        SummarySettings3.GroupBySummaryValueAppearance = Appearance120
        Appearance121.TextHAlignAsString = "Right"
        SummarySettings4.Appearance = Appearance121
        SummarySettings4.DisplayFormat = "{0}"
        SummarySettings4.GroupBySummaryValueAppearance = Appearance122
        UltraGridBand3.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings3, SummarySettings4})
        UltraGridBand3.SummaryFooterCaption = ""
        Me.UltraGrid3.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.UltraGrid3.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion32)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion33)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion34)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion35)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion36)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion37)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion38)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion39)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion40)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion41)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion42)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion43)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion44)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion45)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion46)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion47)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion48)
        Me.UltraGrid3.DisplayLayout.ColScrollRegions.Add(ColScrollRegion49)
        Me.UltraGrid3.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance123.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance123.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance123.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance123.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid3.DisplayLayout.GroupByBox.Appearance = Appearance123
        Appearance124.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid3.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance124
        Me.UltraGrid3.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid3.DisplayLayout.GroupByBox.Hidden = True
        Appearance125.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance125.BackColor2 = System.Drawing.SystemColors.Control
        Appearance125.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance125.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid3.DisplayLayout.GroupByBox.PromptAppearance = Appearance125
        Me.UltraGrid3.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGrid3.DisplayLayout.MaxRowScrollRegions = 1
        Me.UltraGrid3.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraGrid3.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraGrid3.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance126.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGrid3.DisplayLayout.Override.CardAreaAppearance = Appearance126
        Appearance127.BorderColor = System.Drawing.Color.Silver
        Appearance127.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGrid3.DisplayLayout.Override.CellAppearance = Appearance127
        Me.UltraGrid3.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGrid3.DisplayLayout.Override.CellPadding = 0
        Me.UltraGrid3.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.UltraGrid3.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.UltraGrid3.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.UltraGrid3.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance128.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance128.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.UltraGrid3.DisplayLayout.Override.FilterRowAppearance = Appearance128
        Me.UltraGrid3.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.UltraGrid3.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.UltraGrid3.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance129.BackColor = System.Drawing.SystemColors.Control
        Appearance129.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance129.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance129.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance129.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid3.DisplayLayout.Override.GroupByRowAppearance = Appearance129
        Appearance130.FontData.Name = "Arial Narrow"
        Appearance130.FontData.SizeInPoints = 10.0!
        Appearance130.TextHAlignAsString = "Left"
        Me.UltraGrid3.DisplayLayout.Override.HeaderAppearance = Appearance130
        Me.UltraGrid3.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.UltraGrid3.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.UltraGrid3.DisplayLayout.Override.MinRowHeight = 24
        Appearance131.BackColor = System.Drawing.SystemColors.Window
        Appearance131.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance131.TextVAlignAsString = "Middle"
        Me.UltraGrid3.DisplayLayout.Override.RowAppearance = Appearance131
        Me.UltraGrid3.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.UltraGrid3.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.UltraGrid3.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance132.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraGrid3.DisplayLayout.Override.TemplateAddRowAppearance = Appearance132
        Me.UltraGrid3.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.UltraGrid3.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGrid3.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGrid3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid3.Location = New System.Drawing.Point(25, 264)
        Me.UltraGrid3.Name = "UltraGrid3"
        Me.UltraGrid3.Size = New System.Drawing.Size(649, 159)
        Me.UltraGrid3.TabIndex = 212
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(1099, 22)
        Me.Label5.TabIndex = 210
        Me.Label5.Text = "      PRODUCTO: "
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.txtcostoxtonfijo2)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel14)
        Me.UltraTabPageControl3.Controls.Add(Me.txtcostoxtonvar2)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel13)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel12)
        Me.UltraTabPageControl3.Controls.Add(Me.txtcostoFIJO)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl3.Controls.Add(Me.txtcostoVAR)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel7)
        Me.UltraTabPageControl3.Controls.Add(Me.Label3)
        Me.UltraTabPageControl3.Controls.Add(Me.txtcostoxton2)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel4)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel5)
        Me.UltraTabPageControl3.Controls.Add(Me.txttoneladas2)
        Me.UltraTabPageControl3.Controls.Add(Me.Label4)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraGrid2)
        Me.UltraTabPageControl3.Controls.Add(Me.txtcostototal2)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(1099, 433)
        '
        'txtcostoxtonfijo2
        '
        Me.txtcostoxtonfijo2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance154.FontData.BoldAsString = "False"
        Appearance154.ForeColor = System.Drawing.Color.Black
        Appearance154.TextHAlignAsString = "Right"
        Appearance154.TextVAlignAsString = "Middle"
        Me.txtcostoxtonfijo2.Appearance = Appearance154
        Me.txtcostoxtonfijo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoxtonfijo2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoxtonfijo2.Location = New System.Drawing.Point(983, 179)
        Me.txtcostoxtonfijo2.MaxLength = 8
        Me.txtcostoxtonfijo2.Name = "txtcostoxtonfijo2"
        Me.txtcostoxtonfijo2.ReadOnly = True
        Me.txtcostoxtonfijo2.Size = New System.Drawing.Size(94, 21)
        Me.txtcostoxtonfijo2.TabIndex = 225
        Me.txtcostoxtonfijo2.TabStop = False
        Me.txtcostoxtonfijo2.Text = "0.00"
        '
        'UltraLabel14
        '
        Me.UltraLabel14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance155.BackColor = System.Drawing.Color.Transparent
        Appearance155.TextHAlignAsString = "Center"
        Appearance155.TextVAlignAsString = "Middle"
        Me.UltraLabel14.Appearance = Appearance155
        Me.UltraLabel14.AutoSize = True
        Me.UltraLabel14.Location = New System.Drawing.Point(895, 183)
        Me.UltraLabel14.Name = "UltraLabel14"
        Me.UltraLabel14.Size = New System.Drawing.Size(82, 14)
        Me.UltraLabel14.TabIndex = 226
        Me.UltraLabel14.Text = "Costo x TN Fijo"
        '
        'txtcostoxtonvar2
        '
        Me.txtcostoxtonvar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance156.FontData.BoldAsString = "False"
        Appearance156.ForeColor = System.Drawing.Color.Black
        Appearance156.TextHAlignAsString = "Right"
        Appearance156.TextVAlignAsString = "Middle"
        Me.txtcostoxtonvar2.Appearance = Appearance156
        Me.txtcostoxtonvar2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoxtonvar2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoxtonvar2.Location = New System.Drawing.Point(983, 152)
        Me.txtcostoxtonvar2.MaxLength = 8
        Me.txtcostoxtonvar2.Name = "txtcostoxtonvar2"
        Me.txtcostoxtonvar2.ReadOnly = True
        Me.txtcostoxtonvar2.Size = New System.Drawing.Size(94, 21)
        Me.txtcostoxtonvar2.TabIndex = 223
        Me.txtcostoxtonvar2.TabStop = False
        Me.txtcostoxtonvar2.Text = "0.00"
        '
        'UltraLabel13
        '
        Me.UltraLabel13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance157.BackColor = System.Drawing.Color.Transparent
        Appearance157.TextHAlignAsString = "Center"
        Appearance157.TextVAlignAsString = "Middle"
        Me.UltraLabel13.Appearance = Appearance157
        Me.UltraLabel13.AutoSize = True
        Me.UltraLabel13.Location = New System.Drawing.Point(896, 155)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(81, 14)
        Me.UltraLabel13.TabIndex = 224
        Me.UltraLabel13.Text = "Costo x TN Var"
        '
        'UltraLabel12
        '
        Me.UltraLabel12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance147.BackColor = System.Drawing.Color.Transparent
        Appearance147.TextHAlignAsString = "Center"
        Appearance147.TextVAlignAsString = "Middle"
        Me.UltraLabel12.Appearance = Appearance147
        Me.UltraLabel12.AutoSize = True
        Me.UltraLabel12.Location = New System.Drawing.Point(922, 76)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(55, 14)
        Me.UltraLabel12.TabIndex = 222
        Me.UltraLabel12.Text = "Costo Fijo"
        '
        'txtcostoFIJO
        '
        Me.txtcostoFIJO.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance149.FontData.BoldAsString = "False"
        Appearance149.ForeColor = System.Drawing.Color.Black
        Appearance149.TextHAlignAsString = "Right"
        Appearance149.TextVAlignAsString = "Middle"
        Me.txtcostoFIJO.Appearance = Appearance149
        Me.txtcostoFIJO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoFIJO.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoFIJO.Location = New System.Drawing.Point(983, 73)
        Me.txtcostoFIJO.MaxLength = 8
        Me.txtcostoFIJO.Name = "txtcostoFIJO"
        Me.txtcostoFIJO.ReadOnly = True
        Me.txtcostoFIJO.Size = New System.Drawing.Size(94, 21)
        Me.txtcostoFIJO.TabIndex = 221
        Me.txtcostoFIJO.TabStop = False
        Me.txtcostoFIJO.Text = "0.00"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance150.BackColor = System.Drawing.Color.Transparent
        Appearance150.TextHAlignAsString = "Center"
        Appearance150.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance150
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(899, 50)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(78, 14)
        Me.UltraLabel1.TabIndex = 220
        Me.UltraLabel1.Text = "Costo Variable"
        '
        'txtcostoVAR
        '
        Me.txtcostoVAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance151.FontData.BoldAsString = "False"
        Appearance151.ForeColor = System.Drawing.Color.Black
        Appearance151.TextHAlignAsString = "Right"
        Appearance151.TextVAlignAsString = "Middle"
        Me.txtcostoVAR.Appearance = Appearance151
        Me.txtcostoVAR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoVAR.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoVAR.Location = New System.Drawing.Point(983, 47)
        Me.txtcostoVAR.MaxLength = 8
        Me.txtcostoVAR.Name = "txtcostoVAR"
        Me.txtcostoVAR.ReadOnly = True
        Me.txtcostoVAR.Size = New System.Drawing.Size(94, 21)
        Me.txtcostoVAR.TabIndex = 219
        Me.txtcostoVAR.TabStop = False
        Me.txtcostoVAR.Text = "0.00"
        '
        'UltraLabel7
        '
        Me.UltraLabel7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance16.BackColor = System.Drawing.Color.Transparent
        Appearance16.TextHAlignAsString = "Center"
        Appearance16.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance16
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Location = New System.Drawing.Point(898, 129)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(79, 14)
        Me.UltraLabel7.TabIndex = 218
        Me.UltraLabel7.Text = "TN Producidas"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(985, 249)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 16)
        Me.Label3.TabIndex = 215
        Me.Label3.Text = "REGRESAR"
        '
        'txtcostoxton2
        '
        Me.txtcostoxton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance58.FontData.BoldAsString = "False"
        Appearance58.ForeColor = System.Drawing.Color.Black
        Appearance58.TextHAlignAsString = "Right"
        Appearance58.TextVAlignAsString = "Middle"
        Me.txtcostoxton2.Appearance = Appearance58
        Me.txtcostoxton2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoxton2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoxton2.Location = New System.Drawing.Point(983, 207)
        Me.txtcostoxton2.MaxLength = 8
        Me.txtcostoxton2.Name = "txtcostoxton2"
        Me.txtcostoxton2.ReadOnly = True
        Me.txtcostoxton2.Size = New System.Drawing.Size(94, 21)
        Me.txtcostoxton2.TabIndex = 213
        Me.txtcostoxton2.TabStop = False
        Me.txtcostoxton2.Text = "0.00"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance59.BackColor = System.Drawing.Color.Transparent
        Appearance59.TextHAlignAsString = "Center"
        Appearance59.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance59
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(916, 211)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(61, 14)
        Me.UltraLabel4.TabIndex = 214
        Me.UltraLabel4.Text = "Costo x TN"
        '
        'UltraLabel5
        '
        Me.UltraLabel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance54.BackColor = System.Drawing.Color.Transparent
        Appearance54.TextHAlignAsString = "Center"
        Appearance54.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance54
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(915, 103)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(62, 14)
        Me.UltraLabel5.TabIndex = 212
        Me.UltraLabel5.Text = "Costo Total"
        '
        'txttoneladas2
        '
        Me.txttoneladas2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance146.FontData.BoldAsString = "False"
        Appearance146.ForeColor = System.Drawing.Color.Black
        Appearance146.TextHAlignAsString = "Right"
        Appearance146.TextVAlignAsString = "Middle"
        Me.txttoneladas2.Appearance = Appearance146
        Me.txttoneladas2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttoneladas2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttoneladas2.Location = New System.Drawing.Point(983, 125)
        Me.txttoneladas2.MaxLength = 8
        Me.txttoneladas2.Name = "txttoneladas2"
        Me.txttoneladas2.ReadOnly = True
        Me.txttoneladas2.Size = New System.Drawing.Size(94, 21)
        Me.txttoneladas2.TabIndex = 209
        Me.txttoneladas2.TabStop = False
        Me.txttoneladas2.Text = "0.00"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(0, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1099, 22)
        Me.Label4.TabIndex = 208
        Me.Label4.Text = "      PRODUCTO: "
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraGrid2.DisplayLayout.Appearance = Appearance7
        Me.UltraGrid2.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn33.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance8.Image = CType(resources.GetObject("Appearance8.Image"), Object)
        Appearance8.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance8.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn33.Header.Appearance = Appearance8
        UltraGridColumn33.Header.Caption = ""
        UltraGridColumn33.Header.VisiblePosition = 0
        UltraGridColumn33.Hidden = True
        UltraGridColumn33.MaxWidth = 25
        UltraGridColumn33.MinWidth = 20
        UltraGridColumn33.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn33.Width = 20
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
        UltraGridColumn34.Header.VisiblePosition = 1
        UltraGridColumn34.Hidden = True
        UltraGridColumn34.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn34.Width = 58
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn35.Header.VisiblePosition = 2
        UltraGridColumn35.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn35.Width = 121
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn36.Header.VisiblePosition = 3
        UltraGridColumn36.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn36.Width = 150
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn37.Header.VisiblePosition = 4
        UltraGridColumn37.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn37.Width = 170
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance31.TextHAlignAsString = "Right"
        UltraGridColumn38.CellAppearance = Appearance31
        UltraGridColumn38.Header.VisiblePosition = 5
        UltraGridColumn38.Hidden = True
        UltraGridColumn38.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn38.Width = 37
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance37.TextHAlignAsString = "Right"
        UltraGridColumn39.CellAppearance = Appearance37
        UltraGridColumn39.Header.Caption = "TON. MAT. PRIMA"
        UltraGridColumn39.Header.VisiblePosition = 6
        UltraGridColumn39.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn39.Width = 93
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance49.TextHAlignAsString = "Right"
        UltraGridColumn40.CellAppearance = Appearance49
        UltraGridColumn40.Header.VisiblePosition = 7
        UltraGridColumn40.Hidden = True
        UltraGridColumn40.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn40.Width = 64
        UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance51.TextHAlignAsString = "Right"
        UltraGridColumn41.CellAppearance = Appearance51
        UltraGridColumn41.Format = "#####,##0.00###"
        UltraGridColumn41.Header.Caption = "COSTO X CHANCADO"
        UltraGridColumn41.Header.VisiblePosition = 8
        UltraGridColumn41.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn41.Width = 130
        UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance52.TextHAlignAsString = "Right"
        UltraGridColumn42.CellAppearance = Appearance52
        UltraGridColumn42.Format = "#####,##0.00###"
        UltraGridColumn42.Header.Caption = "COSTO TOTAL"
        UltraGridColumn42.Header.VisiblePosition = 9
        UltraGridColumn42.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn42.Width = 126
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42})
        Appearance87.TextHAlignAsString = "Right"
        SummarySettings5.Appearance = Appearance87
        SummarySettings5.DisplayFormat = "TOTAL"
        SummarySettings5.GroupBySummaryValueAppearance = Appearance88
        Appearance89.TextHAlignAsString = "Right"
        SummarySettings6.Appearance = Appearance89
        SummarySettings6.DisplayFormat = "{0:###,##0.00###}"
        SummarySettings6.GroupBySummaryValueAppearance = Appearance90
        UltraGridBand4.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings5, SummarySettings6})
        UltraGridBand4.SummaryFooterCaption = ""
        Me.UltraGrid2.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.UltraGrid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion50)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion51)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion52)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion53)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion54)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion55)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion56)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion57)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion58)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion59)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion60)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion61)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion62)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion63)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion64)
        Me.UltraGrid2.DisplayLayout.ColScrollRegions.Add(ColScrollRegion65)
        Me.UltraGrid2.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance91.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance91.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance91.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance91.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid2.DisplayLayout.GroupByBox.Appearance = Appearance91
        Appearance92.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid2.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance92
        Me.UltraGrid2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid2.DisplayLayout.GroupByBox.Hidden = True
        Appearance93.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance93.BackColor2 = System.Drawing.SystemColors.Control
        Appearance93.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance93.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid2.DisplayLayout.GroupByBox.PromptAppearance = Appearance93
        Me.UltraGrid2.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGrid2.DisplayLayout.MaxRowScrollRegions = 1
        Me.UltraGrid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraGrid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraGrid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance94.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = Appearance94
        Appearance95.BorderColor = System.Drawing.Color.Silver
        Appearance95.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGrid2.DisplayLayout.Override.CellAppearance = Appearance95
        Me.UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGrid2.DisplayLayout.Override.CellPadding = 0
        Me.UltraGrid2.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.UltraGrid2.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.UltraGrid2.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.UltraGrid2.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance96.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance96.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.UltraGrid2.DisplayLayout.Override.FilterRowAppearance = Appearance96
        Me.UltraGrid2.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.UltraGrid2.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.UltraGrid2.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance97.BackColor = System.Drawing.SystemColors.Control
        Appearance97.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance97.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance97.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance97.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid2.DisplayLayout.Override.GroupByRowAppearance = Appearance97
        Appearance98.FontData.Name = "Arial Narrow"
        Appearance98.FontData.SizeInPoints = 10.0!
        Appearance98.TextHAlignAsString = "Left"
        Me.UltraGrid2.DisplayLayout.Override.HeaderAppearance = Appearance98
        Me.UltraGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.UltraGrid2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.UltraGrid2.DisplayLayout.Override.MinRowHeight = 24
        Appearance99.BackColor = System.Drawing.SystemColors.Window
        Appearance99.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance99.TextVAlignAsString = "Middle"
        Me.UltraGrid2.DisplayLayout.Override.RowAppearance = Appearance99
        Me.UltraGrid2.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.UltraGrid2.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.UltraGrid2.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance100.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraGrid2.DisplayLayout.Override.TemplateAddRowAppearance = Appearance100
        Me.UltraGrid2.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.UltraGrid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGrid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGrid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.UltraGrid2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid2.Location = New System.Drawing.Point(27, 47)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(847, 377)
        Me.UltraGrid2.TabIndex = 207
        '
        'txtcostototal2
        '
        Me.txtcostototal2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance55.FontData.BoldAsString = "False"
        Appearance55.ForeColor = System.Drawing.Color.Black
        Appearance55.TextHAlignAsString = "Right"
        Appearance55.TextVAlignAsString = "Middle"
        Me.txtcostototal2.Appearance = Appearance55
        Me.txtcostototal2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostototal2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostototal2.Location = New System.Drawing.Point(983, 99)
        Me.txtcostototal2.MaxLength = 8
        Me.txtcostototal2.Name = "txtcostototal2"
        Me.txtcostototal2.ReadOnly = True
        Me.txtcostototal2.Size = New System.Drawing.Size(94, 21)
        Me.txtcostototal2.TabIndex = 211
        Me.txtcostototal2.TabStop = False
        Me.txtcostototal2.Text = "0.00"
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGrid1)
        Me.UltraTabPageControl2.Controls.Add(Me.txtcostoxtonfijo3)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel18)
        Me.UltraTabPageControl2.Controls.Add(Me.txtcostoxtonvar3)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel19)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel15)
        Me.UltraTabPageControl2.Controls.Add(Me.txtcostoFIJO2)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel17)
        Me.UltraTabPageControl2.Controls.Add(Me.txtcostoVAR2)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel11)
        Me.UltraTabPageControl2.Controls.Add(Me.Label2)
        Me.UltraTabPageControl2.Controls.Add(Me.txtcostoxton)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel3)
        Me.UltraTabPageControl2.Controls.Add(Me.txttoneladas)
        Me.UltraTabPageControl2.Controls.Add(Me.Label1)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraGrid11)
        Me.UltraTabPageControl2.Controls.Add(Me.txtcostototal)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(1099, 433)
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance107.BackColor = System.Drawing.SystemColors.Window
        Appearance107.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraGrid1.DisplayLayout.Appearance = Appearance107
        Me.UltraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn43.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance108.Image = CType(resources.GetObject("Appearance108.Image"), Object)
        Appearance108.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance108.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn43.Header.Appearance = Appearance108
        UltraGridColumn43.Header.Caption = ""
        UltraGridColumn43.Header.VisiblePosition = 0
        UltraGridColumn43.Hidden = True
        UltraGridColumn43.MaxWidth = 25
        UltraGridColumn43.MinWidth = 20
        UltraGridColumn43.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn43.Width = 20
        UltraGridColumn44.Header.VisiblePosition = 1
        UltraGridColumn44.Hidden = True
        UltraGridColumn44.Width = 86
        UltraGridColumn45.Header.VisiblePosition = 2
        UltraGridColumn45.Width = 144
        UltraGridColumn46.Header.VisiblePosition = 3
        UltraGridColumn46.Width = 153
        UltraGridColumn47.Header.VisiblePosition = 4
        UltraGridColumn47.Width = 167
        UltraGridColumn48.Header.VisiblePosition = 5
        UltraGridColumn48.Width = 183
        UltraGridColumn49.Header.VisiblePosition = 6
        UltraGridColumn49.Width = 203
        UltraGridColumn50.Header.VisiblePosition = 7
        UltraGridColumn50.Hidden = True
        UltraGridColumn50.Width = 179
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50})
        Appearance115.TextHAlignAsString = "Right"
        SummarySettings7.Appearance = Appearance115
        SummarySettings7.DisplayFormat = "TOTAL"
        SummarySettings7.GroupBySummaryValueAppearance = Appearance116
        Appearance117.TextHAlignAsString = "Right"
        SummarySettings8.Appearance = Appearance117
        SummarySettings8.DisplayFormat = "{0}"
        SummarySettings8.GroupBySummaryValueAppearance = Appearance118
        UltraGridBand5.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings7, SummarySettings8})
        UltraGridBand5.SummaryFooterCaption = ""
        Me.UltraGrid1.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.UltraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion66)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion67)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion68)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion69)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion70)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion71)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion72)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion73)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion74)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion75)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion76)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion77)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion78)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion79)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion80)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion81)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion82)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion83)
        Me.UltraGrid1.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance133.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance133.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance133.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance133.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.GroupByBox.Appearance = Appearance133
        Appearance134.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance134
        Me.UltraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
        Appearance135.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance135.BackColor2 = System.Drawing.SystemColors.Control
        Appearance135.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance135.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance135
        Me.UltraGrid1.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGrid1.DisplayLayout.MaxRowScrollRegions = 1
        Me.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance136.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = Appearance136
        Appearance137.BorderColor = System.Drawing.Color.Silver
        Appearance137.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGrid1.DisplayLayout.Override.CellAppearance = Appearance137
        Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGrid1.DisplayLayout.Override.CellPadding = 0
        Me.UltraGrid1.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.UltraGrid1.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.UltraGrid1.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.UltraGrid1.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance138.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance138.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.UltraGrid1.DisplayLayout.Override.FilterRowAppearance = Appearance138
        Me.UltraGrid1.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.UltraGrid1.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.UltraGrid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance139.BackColor = System.Drawing.SystemColors.Control
        Appearance139.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance139.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance139.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance139.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.Override.GroupByRowAppearance = Appearance139
        Appearance140.FontData.Name = "Arial Narrow"
        Appearance140.FontData.SizeInPoints = 10.0!
        Appearance140.TextHAlignAsString = "Left"
        Me.UltraGrid1.DisplayLayout.Override.HeaderAppearance = Appearance140
        Me.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.UltraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.UltraGrid1.DisplayLayout.Override.MinRowHeight = 24
        Appearance141.BackColor = System.Drawing.SystemColors.Window
        Appearance141.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance141.TextVAlignAsString = "Middle"
        Me.UltraGrid1.DisplayLayout.Override.RowAppearance = Appearance141
        Me.UltraGrid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.UltraGrid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.UltraGrid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance142.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance142
        Me.UltraGrid1.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid1.Location = New System.Drawing.Point(11, 47)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(890, 377)
        Me.UltraGrid1.TabIndex = 231
        '
        'txtcostoxtonfijo3
        '
        Me.txtcostoxtonfijo3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance143.FontData.BoldAsString = "False"
        Appearance143.ForeColor = System.Drawing.Color.Black
        Appearance143.TextHAlignAsString = "Right"
        Appearance143.TextVAlignAsString = "Middle"
        Me.txtcostoxtonfijo3.Appearance = Appearance143
        Me.txtcostoxtonfijo3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoxtonfijo3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoxtonfijo3.Location = New System.Drawing.Point(996, 184)
        Me.txtcostoxtonfijo3.MaxLength = 8
        Me.txtcostoxtonfijo3.Name = "txtcostoxtonfijo3"
        Me.txtcostoxtonfijo3.ReadOnly = True
        Me.txtcostoxtonfijo3.Size = New System.Drawing.Size(94, 21)
        Me.txtcostoxtonfijo3.TabIndex = 229
        Me.txtcostoxtonfijo3.TabStop = False
        Me.txtcostoxtonfijo3.Text = "0.00"
        '
        'UltraLabel18
        '
        Me.UltraLabel18.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance144.BackColor = System.Drawing.Color.Transparent
        Appearance144.TextHAlignAsString = "Center"
        Appearance144.TextVAlignAsString = "Middle"
        Me.UltraLabel18.Appearance = Appearance144
        Me.UltraLabel18.AutoSize = True
        Me.UltraLabel18.Location = New System.Drawing.Point(908, 188)
        Me.UltraLabel18.Name = "UltraLabel18"
        Me.UltraLabel18.Size = New System.Drawing.Size(82, 14)
        Me.UltraLabel18.TabIndex = 230
        Me.UltraLabel18.Text = "Costo x TN Fijo"
        '
        'txtcostoxtonvar3
        '
        Me.txtcostoxtonvar3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance56.FontData.BoldAsString = "False"
        Appearance56.ForeColor = System.Drawing.Color.Black
        Appearance56.TextHAlignAsString = "Right"
        Appearance56.TextVAlignAsString = "Middle"
        Me.txtcostoxtonvar3.Appearance = Appearance56
        Me.txtcostoxtonvar3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoxtonvar3.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoxtonvar3.Location = New System.Drawing.Point(996, 157)
        Me.txtcostoxtonvar3.MaxLength = 8
        Me.txtcostoxtonvar3.Name = "txtcostoxtonvar3"
        Me.txtcostoxtonvar3.ReadOnly = True
        Me.txtcostoxtonvar3.Size = New System.Drawing.Size(94, 21)
        Me.txtcostoxtonvar3.TabIndex = 227
        Me.txtcostoxtonvar3.TabStop = False
        Me.txtcostoxtonvar3.Text = "0.00"
        '
        'UltraLabel19
        '
        Me.UltraLabel19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance57.BackColor = System.Drawing.Color.Transparent
        Appearance57.TextHAlignAsString = "Center"
        Appearance57.TextVAlignAsString = "Middle"
        Me.UltraLabel19.Appearance = Appearance57
        Me.UltraLabel19.AutoSize = True
        Me.UltraLabel19.Location = New System.Drawing.Point(909, 160)
        Me.UltraLabel19.Name = "UltraLabel19"
        Me.UltraLabel19.Size = New System.Drawing.Size(81, 14)
        Me.UltraLabel19.TabIndex = 228
        Me.UltraLabel19.Text = "Costo x TN Var"
        '
        'UltraLabel15
        '
        Me.UltraLabel15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance145.BackColor = System.Drawing.Color.Transparent
        Appearance145.TextHAlignAsString = "Center"
        Appearance145.TextVAlignAsString = "Middle"
        Me.UltraLabel15.Appearance = Appearance145
        Me.UltraLabel15.AutoSize = True
        Me.UltraLabel15.Location = New System.Drawing.Point(935, 78)
        Me.UltraLabel15.Name = "UltraLabel15"
        Me.UltraLabel15.Size = New System.Drawing.Size(55, 14)
        Me.UltraLabel15.TabIndex = 226
        Me.UltraLabel15.Text = "Costo Fijo"
        '
        'txtcostoFIJO2
        '
        Me.txtcostoFIJO2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance148.FontData.BoldAsString = "False"
        Appearance148.ForeColor = System.Drawing.Color.Black
        Appearance148.TextHAlignAsString = "Right"
        Appearance148.TextVAlignAsString = "Middle"
        Me.txtcostoFIJO2.Appearance = Appearance148
        Me.txtcostoFIJO2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoFIJO2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoFIJO2.Location = New System.Drawing.Point(996, 75)
        Me.txtcostoFIJO2.MaxLength = 8
        Me.txtcostoFIJO2.Name = "txtcostoFIJO2"
        Me.txtcostoFIJO2.ReadOnly = True
        Me.txtcostoFIJO2.Size = New System.Drawing.Size(94, 21)
        Me.txtcostoFIJO2.TabIndex = 225
        Me.txtcostoFIJO2.TabStop = False
        Me.txtcostoFIJO2.Text = "0.00"
        '
        'UltraLabel17
        '
        Me.UltraLabel17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Center"
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel17.Appearance = Appearance9
        Me.UltraLabel17.AutoSize = True
        Me.UltraLabel17.Location = New System.Drawing.Point(912, 50)
        Me.UltraLabel17.Name = "UltraLabel17"
        Me.UltraLabel17.Size = New System.Drawing.Size(78, 14)
        Me.UltraLabel17.TabIndex = 224
        Me.UltraLabel17.Text = "Costo Variable"
        '
        'txtcostoVAR2
        '
        Me.txtcostoVAR2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance53.FontData.BoldAsString = "False"
        Appearance53.ForeColor = System.Drawing.Color.Black
        Appearance53.TextHAlignAsString = "Right"
        Appearance53.TextVAlignAsString = "Middle"
        Me.txtcostoVAR2.Appearance = Appearance53
        Me.txtcostoVAR2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoVAR2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoVAR2.Location = New System.Drawing.Point(996, 47)
        Me.txtcostoVAR2.MaxLength = 8
        Me.txtcostoVAR2.Name = "txtcostoVAR2"
        Me.txtcostoVAR2.ReadOnly = True
        Me.txtcostoVAR2.Size = New System.Drawing.Size(94, 21)
        Me.txtcostoVAR2.TabIndex = 223
        Me.txtcostoVAR2.TabStop = False
        Me.txtcostoVAR2.Text = "0.00"
        '
        'UltraLabel11
        '
        Me.UltraLabel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance62.BackColor = System.Drawing.Color.Transparent
        Appearance62.TextHAlignAsString = "Center"
        Appearance62.TextVAlignAsString = "Middle"
        Me.UltraLabel11.Appearance = Appearance62
        Me.UltraLabel11.AutoSize = True
        Me.UltraLabel11.Location = New System.Drawing.Point(912, 134)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(79, 14)
        Me.UltraLabel11.TabIndex = 218
        Me.UltraLabel11.Text = "TN Producidas"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(998, 244)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 16)
        Me.Label2.TabIndex = 206
        Me.Label2.Text = "REGRESAR"
        '
        'txtcostoxton
        '
        Me.txtcostoxton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance32.FontData.BoldAsString = "False"
        Appearance32.ForeColor = System.Drawing.Color.Black
        Appearance32.TextHAlignAsString = "Right"
        Appearance32.TextVAlignAsString = "Middle"
        Me.txtcostoxton.Appearance = Appearance32
        Me.txtcostoxton.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostoxton.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostoxton.Location = New System.Drawing.Point(996, 211)
        Me.txtcostoxton.MaxLength = 8
        Me.txtcostoxton.Name = "txtcostoxton"
        Me.txtcostoxton.ReadOnly = True
        Me.txtcostoxton.Size = New System.Drawing.Size(94, 21)
        Me.txtcostoxton.TabIndex = 204
        Me.txtcostoxton.TabStop = False
        Me.txtcostoxton.Text = "0.00"
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance34.BackColor = System.Drawing.Color.Transparent
        Appearance34.TextHAlignAsString = "Center"
        Appearance34.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance34
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(930, 215)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(61, 14)
        Me.UltraLabel2.TabIndex = 205
        Me.UltraLabel2.Text = "Costo x TN"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance35.BackColor = System.Drawing.Color.Transparent
        Appearance35.TextHAlignAsString = "Center"
        Appearance35.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance35
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(929, 108)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(62, 14)
        Me.UltraLabel3.TabIndex = 203
        Me.UltraLabel3.Text = "Costo Total"
        '
        'txttoneladas
        '
        Me.txttoneladas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance36.FontData.BoldAsString = "False"
        Appearance36.ForeColor = System.Drawing.Color.Black
        Appearance36.TextHAlignAsString = "Right"
        Appearance36.TextVAlignAsString = "Middle"
        Me.txttoneladas.Appearance = Appearance36
        Me.txttoneladas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttoneladas.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttoneladas.Location = New System.Drawing.Point(996, 130)
        Me.txttoneladas.MaxLength = 8
        Me.txttoneladas.Name = "txttoneladas"
        Me.txttoneladas.ReadOnly = True
        Me.txttoneladas.Size = New System.Drawing.Size(94, 21)
        Me.txttoneladas.TabIndex = 200
        Me.txttoneladas.TabStop = False
        Me.txttoneladas.Text = "0.00"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1099, 22)
        Me.Label1.TabIndex = 199
        Me.Label1.Text = "      PRODUCTO: "
        '
        'UltraGrid11
        '
        Me.UltraGrid11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance39.BackColor = System.Drawing.SystemColors.Window
        Appearance39.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraGrid11.DisplayLayout.Appearance = Appearance39
        Me.UltraGrid11.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn51.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance41.Image = CType(resources.GetObject("Appearance41.Image"), Object)
        Appearance41.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance41.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn51.Header.Appearance = Appearance41
        UltraGridColumn51.Header.Caption = ""
        UltraGridColumn51.Header.VisiblePosition = 0
        UltraGridColumn51.Hidden = True
        UltraGridColumn51.MaxWidth = 25
        UltraGridColumn51.MinWidth = 20
        UltraGridColumn51.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn51.Width = 20
        UltraGridColumn52.Header.VisiblePosition = 1
        UltraGridColumn52.Hidden = True
        UltraGridColumn52.Width = 149
        UltraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn53.Header.VisiblePosition = 3
        UltraGridColumn53.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn53.Width = 131
        UltraGridColumn54.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn54.Header.VisiblePosition = 4
        UltraGridColumn54.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn54.Width = 191
        UltraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance42.TextHAlignAsString = "Right"
        UltraGridColumn55.CellAppearance = Appearance42
        UltraGridColumn55.Header.Caption = "TONELADA"
        UltraGridColumn55.Header.VisiblePosition = 5
        UltraGridColumn55.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn55.Width = 122
        UltraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance45.TextHAlignAsString = "Right"
        UltraGridColumn56.CellAppearance = Appearance45
        UltraGridColumn56.Header.Caption = "COSTO VARIABLE"
        UltraGridColumn56.Header.VisiblePosition = 6
        UltraGridColumn56.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn56.Width = 163
        Appearance160.TextHAlignAsString = "Right"
        UltraGridColumn57.CellAppearance = Appearance160
        UltraGridColumn57.Header.Caption = "COSTO FIJO"
        UltraGridColumn57.Header.VisiblePosition = 7
        UltraGridColumn57.Width = 111
        UltraGridColumn58.Header.VisiblePosition = 2
        UltraGridColumn58.Width = 91
        UltraGridBand6.Columns.AddRange(New Object() {UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58})
        Appearance46.TextHAlignAsString = "Right"
        SummarySettings9.Appearance = Appearance46
        SummarySettings9.DisplayFormat = "TOTAL"
        SummarySettings9.GroupBySummaryValueAppearance = Appearance47
        Appearance48.TextHAlignAsString = "Right"
        SummarySettings10.Appearance = Appearance48
        SummarySettings10.DisplayFormat = "{0:###,##0.00}"
        SummarySettings10.GroupBySummaryValueAppearance = Appearance68
        UltraGridBand6.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings9, SummarySettings10})
        UltraGridBand6.SummaryFooterCaption = ""
        Me.UltraGrid11.DisplayLayout.BandsSerializer.Add(UltraGridBand6)
        Me.UltraGrid11.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid11.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion84)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion85)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion86)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion87)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion88)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion89)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion90)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion91)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion92)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion93)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion94)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion95)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion96)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion97)
        Me.UltraGrid11.DisplayLayout.ColScrollRegions.Add(ColScrollRegion98)
        Me.UltraGrid11.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance69.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance69.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance69.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance69.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid11.DisplayLayout.GroupByBox.Appearance = Appearance69
        Appearance70.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid11.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance70
        Me.UltraGrid11.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid11.DisplayLayout.GroupByBox.Hidden = True
        Appearance71.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance71.BackColor2 = System.Drawing.SystemColors.Control
        Appearance71.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance71.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid11.DisplayLayout.GroupByBox.PromptAppearance = Appearance71
        Me.UltraGrid11.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGrid11.DisplayLayout.MaxRowScrollRegions = 1
        Me.UltraGrid11.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraGrid11.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraGrid11.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance72.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGrid11.DisplayLayout.Override.CardAreaAppearance = Appearance72
        Appearance73.BorderColor = System.Drawing.Color.Silver
        Appearance73.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGrid11.DisplayLayout.Override.CellAppearance = Appearance73
        Me.UltraGrid11.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGrid11.DisplayLayout.Override.CellPadding = 0
        Me.UltraGrid11.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.UltraGrid11.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.UltraGrid11.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.UltraGrid11.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance74.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance74.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.UltraGrid11.DisplayLayout.Override.FilterRowAppearance = Appearance74
        Me.UltraGrid11.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.UltraGrid11.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.UltraGrid11.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance75.BackColor = System.Drawing.SystemColors.Control
        Appearance75.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance75.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance75.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance75.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid11.DisplayLayout.Override.GroupByRowAppearance = Appearance75
        Appearance76.FontData.Name = "Arial Narrow"
        Appearance76.FontData.SizeInPoints = 10.0!
        Appearance76.TextHAlignAsString = "Left"
        Me.UltraGrid11.DisplayLayout.Override.HeaderAppearance = Appearance76
        Me.UltraGrid11.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.UltraGrid11.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.UltraGrid11.DisplayLayout.Override.MinRowHeight = 24
        Appearance77.BackColor = System.Drawing.SystemColors.Window
        Appearance77.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance77.TextVAlignAsString = "Middle"
        Me.UltraGrid11.DisplayLayout.Override.RowAppearance = Appearance77
        Me.UltraGrid11.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.UltraGrid11.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.UltraGrid11.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance78.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraGrid11.DisplayLayout.Override.TemplateAddRowAppearance = Appearance78
        Me.UltraGrid11.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGrid11.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGrid11.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.UltraGrid11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid11.Location = New System.Drawing.Point(27, 334)
        Me.UltraGrid11.Name = "UltraGrid11"
        Me.UltraGrid11.Size = New System.Drawing.Size(866, 90)
        Me.UltraGrid11.TabIndex = 198
        '
        'txtcostototal
        '
        Me.txtcostototal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance79.FontData.BoldAsString = "False"
        Appearance79.ForeColor = System.Drawing.Color.Black
        Appearance79.TextHAlignAsString = "Right"
        Appearance79.TextVAlignAsString = "Middle"
        Me.txtcostototal.Appearance = Appearance79
        Me.txtcostototal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcostototal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcostototal.Location = New System.Drawing.Point(996, 104)
        Me.txtcostototal.MaxLength = 8
        Me.txtcostototal.Name = "txtcostototal"
        Me.txtcostototal.ReadOnly = True
        Me.txtcostototal.Size = New System.Drawing.Size(94, 21)
        Me.txtcostototal.TabIndex = 202
        Me.txtcostototal.TabStop = False
        Me.txtcostototal.Text = "0.00"
        '
        'UltraDataSource2
        '
        Me.UltraDataSource2.Band.ChildBands.AddRange(New Object() {UltraDataBand1})
        Me.UltraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn1})
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
        Me.Tab1.Controls.Add(Me.UltraTabPageControl2)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl3)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl4)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(1103, 471)
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
        UltraTab3.Text = "TRAZABILIDAD DE COSTOS POR PRODUCTOS"
        Appearance15.Cursor = System.Windows.Forms.Cursors.Default
        Appearance15.FontData.BoldAsString = "True"
        Appearance15.FontData.Name = "Arial Narrow"
        Appearance15.FontData.SizeInPoints = 16.0!
        UltraTab4.ActiveAppearance = Appearance15
        Appearance14.FontData.Name = "Arial Narrow"
        Appearance14.FontData.SizeInPoints = 10.0!
        UltraTab4.Appearance = Appearance14
        UltraTab4.Key = "T04"
        UltraTab4.TabPage = Me.UltraTabPageControl4
        UltraTab4.Text = "MINERAL"
        UltraTab4.Visible = False
        Appearance12.Cursor = System.Windows.Forms.Cursors.Default
        Appearance12.FontData.BoldAsString = "True"
        Appearance12.FontData.Name = "Arial Narrow"
        Appearance12.FontData.SizeInPoints = 16.0!
        UltraTab2.ActiveAppearance = Appearance12
        Appearance13.FontData.Name = "Arial Narrow"
        Appearance13.FontData.SizeInPoints = 10.0!
        UltraTab2.Appearance = Appearance13
        UltraTab2.Key = "T03"
        UltraTab2.TabPage = Me.UltraTabPageControl3
        UltraTab2.Text = "CHANCADO"
        UltraTab2.Visible = False
        Appearance10.Cursor = System.Windows.Forms.Cursors.Default
        Appearance10.FontData.BoldAsString = "True"
        Appearance10.FontData.Name = "Arial Narrow"
        Appearance10.FontData.SizeInPoints = 16.0!
        UltraTab1.ActiveAppearance = Appearance10
        Appearance11.FontData.Name = "Arial Narrow"
        Appearance11.FontData.SizeInPoints = 10.0!
        UltraTab1.Appearance = Appearance11
        UltraTab1.Key = "T02"
        UltraTab1.TabPage = Me.UltraTabPageControl2
        UltraTab1.Text = "MOLIENDA"
        UltraTab1.Visible = False
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3, UltraTab4, UltraTab2, UltraTab1})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1099, 433)
        '
        'FrmTrazabilidadCosteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1103, 471)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmTrazabilidadCosteo"
        Me.Text = "FrmTrazabilidadCosteo"
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridCostos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.UltraTabPageControl4.PerformLayout()
        CType(Me.txtcostoxtonfijo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostoxtonvar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostoxton3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttoneladas3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostototal3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridMineral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        CType(Me.txtcostoxtonfijo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostoxtonvar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostoFIJO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostoVAR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostoxton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttoneladas2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostototal2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostoxtonfijo3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostoxtonvar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostoFIJO2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostoVAR2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostoxton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttoneladas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcostototal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gridCostos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnrevision As System.Windows.Forms.Button
    Friend WithEvents UltraLabel16 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbMes As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtayo As System.Windows.Forms.NumericUpDown
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents Source2 As System.Windows.Forms.BindingSource
    Friend WithEvents Source3 As System.Windows.Forms.BindingSource
    Friend WithEvents Source4 As System.Windows.Forms.BindingSource
    Friend WithEvents UltraGrid11 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtcostoxton As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcostototal As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txttoneladas As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcostoxton2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txttoneladas2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtcostototal2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraDataSource2 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents gridMineral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGrid3 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcostoxton3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txttoneladas3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcostototal3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcostoFIJO As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcostoVAR As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcostoxtonfijo2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcostoxtonvar2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcostoxtonfijo3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel18 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcostoxtonvar3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel19 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel15 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcostoFIJO2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel17 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcostoVAR2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcostoxtonfijo1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel20 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcostoxtonvar1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel21 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraLabel22 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraTextEditor1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
