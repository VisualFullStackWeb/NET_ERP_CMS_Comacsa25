<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturaCombustible
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturaCombustible))
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_CLI", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RAZSOC", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CODCANTERA", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CANTERA", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NUMPEDIDO", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA1", 7)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA2", 8)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AYO", 9)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES", 10)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES_DES", 11)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MONEDA", 12)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOTAL", 13)
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "", Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "PERIODODESC", -2, False)
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CANTIDAD", -2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CANTIDAD", -2, False)
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(992)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion12 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion13 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ACTION")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 0)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROD", 1)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UNIDAD", 2)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PRODUCTO", 3)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PRECIO", 4)
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOTAL", 5)
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA", 6)
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CANTIDAD", 7)
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDET", 8)
        Dim SummarySettings3 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "", Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "PERIODODESC", -2, False)
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings4 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TOTAL", 5, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TOTAL", 5, False)
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion14 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(631)
        Dim ColScrollRegion15 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion16 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion17 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion18 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(992)
        Dim ColScrollRegion19 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion20 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion21 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion22 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion23 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion24 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion25 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion26 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion27 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 0)
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AYO", 1)
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MESNRO", 2)
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES", 3)
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPOCARGA", 4)
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CODCONTRATISTA", 5)
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONTRATISTA", 6)
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CODALMACEN", 7)
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ALMACEN", 8)
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_EQUIPO", 9)
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA_CARGA", 10)
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PERIODO", 11)
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PERIODODESC", 12)
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CANTIDAD", 13)
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings5 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "", Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "PERIODODESC", 12, False)
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings6 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CANTIDAD", 13, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CANTIDAD", 13, False)
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion28 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(0)
        Dim ColScrollRegion29 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion30 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion31 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion32 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(992)
        Dim ColScrollRegion33 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion34 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion35 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion36 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion37 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion38 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion39 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion40 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion41 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraStatusPanel2 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel
        Dim ValueListItem23 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem24 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.BindingNavigator2 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpHasta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpDesde = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.gridCarga = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraStatusBar2 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar
        Me.grid = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbMes = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.txtayo = New System.Windows.Forms.NumericUpDown
        Me.txtid = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.chktodo = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.gridProductos = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpHasta1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpDesde1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtcanteraori = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcodcanteraori = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtidalmorigen = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcodequipo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcodcliente = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.txtcliente = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.txtalmorigen = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraDateTimeEditor1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraDateTimeEditor2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar
        Me.Source2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmbMoneda = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.txttotal = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        CType(Me.BindingNavigator2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator2.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.dtpHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridCarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraStatusBar2.SuspendLayout()
        Me.grid.SuspendLayout()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpHasta1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDesde1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcanteraori, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodcanteraori, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtidalmorigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodequipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodcliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtalmorigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.UltraDateTimeEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDateTimeEditor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraStatusBar1.SuspendLayout()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingNavigator2
        '
        Me.BindingNavigator2.AddNewItem = Nothing
        Me.BindingNavigator2.BackColor = System.Drawing.Color.Transparent
        Me.BindingNavigator2.CountItem = Me.ToolStripLabel2
        Me.BindingNavigator2.DeleteItem = Nothing
        Me.BindingNavigator2.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigator2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator9, Me.ToolStripButton6, Me.ToolStripButton7, Me.ToolStripSeparator10, Me.ToolStripLabel2, Me.ToolStripTextBox2, Me.ToolStripSeparator11, Me.ToolStripButton8, Me.ToolStripButton9, Me.ToolStripSeparator12, Me.ToolStripButton10, Me.ToolStripSeparator13})
        Me.BindingNavigator2.Location = New System.Drawing.Point(2, 4)
        Me.BindingNavigator2.MoveFirstItem = Me.ToolStripButton9
        Me.BindingNavigator2.MoveLastItem = Me.ToolStripButton6
        Me.BindingNavigator2.MoveNextItem = Me.ToolStripButton7
        Me.BindingNavigator2.MovePreviousItem = Me.ToolStripButton8
        Me.BindingNavigator2.Name = "BindingNavigator2"
        Me.BindingNavigator2.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.BindingNavigator2.PositionItem = Me.ToolStripTextBox2
        Me.BindingNavigator2.Size = New System.Drawing.Size(314, 25)
        Me.BindingNavigator2.TabIndex = 141
        Me.BindingNavigator2.Text = "BindingNavigator1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel2.Text = "de {0}"
        Me.ToolStripLabel2.ToolTipText = "Número total de elementos"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "Mover último"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Mover siguiente"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.AccessibleName = "Posición"
        Me.ToolStripTextBox2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripTextBox2.AutoSize = False
        Me.ToolStripTextBox2.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolStripTextBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripTextBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(50, 23)
        Me.ToolStripTextBox2.Text = "0"
        Me.ToolStripTextBox2.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolStripTextBox2.ToolTipText = "Posición actual"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton8.Text = "Mover anterior"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton9.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton9.Text = "Mover primero"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton10.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton10.Image = Global.SIP_Presentacion.My.Resources.Resources.Hand
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(99, 22)
        Me.ToolStripButton10.Text = "SELECCIONAR"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl1.Controls.Add(Me.dtpHasta)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel4)
        Me.UltraTabPageControl1.Controls.Add(Me.dtpDesde)
        Me.UltraTabPageControl1.Controls.Add(Me.gridCarga)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraStatusBar2)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(865, 473)
        '
        'UltraLabel1
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.TextHAlignAsString = "Center"
        Appearance13.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance13
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(195, 44)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(34, 14)
        Me.UltraLabel1.TabIndex = 181
        Me.UltraLabel1.Text = "Hasta"
        '
        'dtpHasta
        '
        Me.dtpHasta.AutoSize = False
        Me.dtpHasta.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpHasta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpHasta.Location = New System.Drawing.Point(235, 42)
        Me.dtpHasta.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpHasta.Size = New System.Drawing.Size(122, 18)
        Me.dtpHasta.TabIndex = 180
        Me.dtpHasta.TabStop = False
        Me.dtpHasta.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'UltraLabel4
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Appearance14.TextHAlignAsString = "Center"
        Appearance14.TextVAlignAsString = "Middle"
        Me.UltraLabel4.Appearance = Appearance14
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(11, 45)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(37, 14)
        Me.UltraLabel4.TabIndex = 179
        Me.UltraLabel4.Text = "Desde"
        '
        'dtpDesde
        '
        Me.dtpDesde.AutoSize = False
        Me.dtpDesde.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpDesde.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpDesde.Location = New System.Drawing.Point(54, 42)
        Me.dtpDesde.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpDesde.Size = New System.Drawing.Size(122, 18)
        Me.dtpDesde.TabIndex = 178
        Me.dtpDesde.TabStop = False
        Me.dtpDesde.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'gridCarga
        '
        Me.gridCarga.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance46.BackColor = System.Drawing.SystemColors.Window
        Appearance46.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridCarga.DisplayLayout.Appearance = Appearance46
        Me.gridCarga.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance48.Image = CType(resources.GetObject("Appearance48.Image"), Object)
        Appearance48.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance48.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance48
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 58
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.Caption = "COD. CLIENTE"
        UltraGridColumn3.Header.VisiblePosition = 4
        UltraGridColumn3.Width = 71
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.Caption = "CLIENTE"
        UltraGridColumn4.Header.VisiblePosition = 5
        UltraGridColumn4.Width = 138
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.Caption = "COD. CANTERA"
        UltraGridColumn5.Header.VisiblePosition = 6
        UltraGridColumn5.Width = 78
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.VisiblePosition = 7
        UltraGridColumn6.Width = 124
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.Caption = "N° PEDIDO"
        UltraGridColumn7.Header.VisiblePosition = 14
        UltraGridColumn7.Width = 86
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.VisiblePosition = 3
        UltraGridColumn8.Width = 71
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 146
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 144
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.Width = 85
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 107
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.Header.Caption = "MES"
        UltraGridColumn13.Header.VisiblePosition = 2
        UltraGridColumn13.Width = 79
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn14.Header.Caption = "MON"
        UltraGridColumn14.Header.VisiblePosition = 12
        UltraGridColumn14.Width = 60
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance5
        UltraGridColumn15.Format = "###,##0.00"
        UltraGridColumn15.Header.VisiblePosition = 13
        UltraGridColumn15.Width = 98
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15})
        SummarySettings1.DisplayFormat = "Total"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance50
        Appearance51.TextHAlignAsString = "Right"
        SummarySettings2.Appearance = Appearance51
        SummarySettings2.DisplayFormat = "{0:###,##0.00}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance52
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2})
        UltraGridBand1.SummaryFooterCaption = ""
        Me.gridCarga.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridCarga.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridCarga.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion13)
        Me.gridCarga.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance53.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance53.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance53.BorderColor = System.Drawing.SystemColors.Window
        Me.gridCarga.DisplayLayout.GroupByBox.Appearance = Appearance53
        Appearance54.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridCarga.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance54
        Me.gridCarga.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridCarga.DisplayLayout.GroupByBox.Hidden = True
        Appearance60.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance60.BackColor2 = System.Drawing.SystemColors.Control
        Appearance60.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance60.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridCarga.DisplayLayout.GroupByBox.PromptAppearance = Appearance60
        Me.gridCarga.DisplayLayout.MaxColScrollRegions = 1
        Me.gridCarga.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridCarga.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridCarga.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridCarga.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance61.BackColor = System.Drawing.SystemColors.Window
        Me.gridCarga.DisplayLayout.Override.CardAreaAppearance = Appearance61
        Appearance64.BorderColor = System.Drawing.Color.Silver
        Appearance64.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridCarga.DisplayLayout.Override.CellAppearance = Appearance64
        Me.gridCarga.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridCarga.DisplayLayout.Override.CellPadding = 0
        Me.gridCarga.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridCarga.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridCarga.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridCarga.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance65.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance65.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridCarga.DisplayLayout.Override.FilterRowAppearance = Appearance65
        Me.gridCarga.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridCarga.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridCarga.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance66.BackColor = System.Drawing.SystemColors.Control
        Appearance66.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance66.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance66.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance66.BorderColor = System.Drawing.SystemColors.Window
        Me.gridCarga.DisplayLayout.Override.GroupByRowAppearance = Appearance66
        Appearance68.FontData.Name = "Arial Narrow"
        Appearance68.FontData.SizeInPoints = 10.0!
        Appearance68.TextHAlignAsString = "Left"
        Me.gridCarga.DisplayLayout.Override.HeaderAppearance = Appearance68
        Me.gridCarga.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridCarga.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridCarga.DisplayLayout.Override.MinRowHeight = 24
        Appearance70.BackColor = System.Drawing.SystemColors.Window
        Appearance70.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance70.TextVAlignAsString = "Middle"
        Me.gridCarga.DisplayLayout.Override.RowAppearance = Appearance70
        Me.gridCarga.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridCarga.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridCarga.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance71.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridCarga.DisplayLayout.Override.TemplateAddRowAppearance = Appearance71
        Me.gridCarga.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridCarga.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridCarga.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridCarga.Location = New System.Drawing.Point(11, 66)
        Me.gridCarga.Name = "gridCarga"
        Me.gridCarga.Size = New System.Drawing.Size(845, 402)
        Me.gridCarga.TabIndex = 177
        Me.gridCarga.Text = "UltraGrid1"
        '
        'UltraStatusBar2
        '
        Me.UltraStatusBar2.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraStatusBar2.Controls.Add(Me.BindingNavigator2)
        Me.UltraStatusBar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraStatusBar2.Location = New System.Drawing.Point(0, 0)
        Me.UltraStatusBar2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraStatusBar2.Name = "UltraStatusBar2"
        UltraStatusPanel1.Control = Me.BindingNavigator2
        UltraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer
        Me.UltraStatusBar2.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1})
        Me.UltraStatusBar2.Size = New System.Drawing.Size(865, 30)
        Me.UltraStatusBar2.SizeGripVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraStatusBar2.TabIndex = 176
        Me.UltraStatusBar2.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'grid
        '
        Me.grid.Controls.Add(Me.txttotal)
        Me.grid.Controls.Add(Me.cmbMoneda)
        Me.grid.Controls.Add(Me.UltraLabel11)
        Me.grid.Controls.Add(Me.cmbMes)
        Me.grid.Controls.Add(Me.UltraLabel10)
        Me.grid.Controls.Add(Me.txtayo)
        Me.grid.Controls.Add(Me.txtid)
        Me.grid.Controls.Add(Me.chktodo)
        Me.grid.Controls.Add(Me.Button1)
        Me.grid.Controls.Add(Me.gridProductos)
        Me.grid.Controls.Add(Me.UltraLabel8)
        Me.grid.Controls.Add(Me.dtpHasta1)
        Me.grid.Controls.Add(Me.UltraLabel9)
        Me.grid.Controls.Add(Me.dtpDesde1)
        Me.grid.Controls.Add(Me.txtcanteraori)
        Me.grid.Controls.Add(Me.txtcodcanteraori)
        Me.grid.Controls.Add(Me.txtidalmorigen)
        Me.grid.Controls.Add(Me.txtcodequipo)
        Me.grid.Controls.Add(Me.txtcodcliente)
        Me.grid.Controls.Add(Me.UltraLabel5)
        Me.grid.Controls.Add(Me.txtcliente)
        Me.grid.Controls.Add(Me.UltraLabel2)
        Me.grid.Controls.Add(Me.txtalmorigen)
        Me.grid.Location = New System.Drawing.Point(1, 35)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(865, 473)
        '
        'UltraLabel11
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.TextHAlignAsString = "Center"
        Appearance9.TextVAlignAsString = "Middle"
        Me.UltraLabel11.Appearance = Appearance9
        Me.UltraLabel11.AutoSize = True
        Me.UltraLabel11.Location = New System.Drawing.Point(57, 100)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(26, 14)
        Me.UltraLabel11.TabIndex = 231
        Me.UltraLabel11.Text = "Mes"
        '
        'cmbMes
        '
        Me.cmbMes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMes.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "1"
        ValueListItem1.DisplayText = "ENERO"
        ValueListItem2.DataValue = "2"
        ValueListItem2.DisplayText = "FEBRERO"
        ValueListItem3.DataValue = "3"
        ValueListItem3.DisplayText = "MARZO"
        ValueListItem4.DataValue = "4"
        ValueListItem4.DisplayText = "ABRIL"
        ValueListItem5.DataValue = "5"
        ValueListItem5.DisplayText = "MAYO"
        ValueListItem6.DataValue = "6"
        ValueListItem6.DisplayText = "JUNIO"
        ValueListItem7.DataValue = "7"
        ValueListItem7.DisplayText = "JULIO"
        ValueListItem8.DataValue = "8"
        ValueListItem8.DisplayText = "AGOSTO"
        ValueListItem9.DataValue = "9"
        ValueListItem9.DisplayText = "SETIEMBRE"
        ValueListItem10.DataValue = "10"
        ValueListItem10.DisplayText = "OCTUBRE"
        ValueListItem11.DataValue = "11"
        ValueListItem11.DisplayText = "NOVIEMBRE"
        ValueListItem12.DataValue = "12"
        ValueListItem12.DisplayText = "DICIEMBRE"
        Me.cmbMes.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3, ValueListItem4, ValueListItem5, ValueListItem6, ValueListItem7, ValueListItem8, ValueListItem9, ValueListItem10, ValueListItem11, ValueListItem12})
        Me.cmbMes.Location = New System.Drawing.Point(90, 96)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(150, 21)
        Me.cmbMes.TabIndex = 230
        '
        'UltraLabel10
        '
        Appearance75.BackColor = System.Drawing.Color.Transparent
        Appearance75.TextHAlignAsString = "Center"
        Appearance75.TextVAlignAsString = "Middle"
        Me.UltraLabel10.Appearance = Appearance75
        Me.UltraLabel10.AutoSize = True
        Me.UltraLabel10.Location = New System.Drawing.Point(59, 73)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(24, 14)
        Me.UltraLabel10.TabIndex = 229
        Me.UltraLabel10.Text = "Año"
        '
        'txtayo
        '
        Me.txtayo.Location = New System.Drawing.Point(90, 70)
        Me.txtayo.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtayo.Name = "txtayo"
        Me.txtayo.Size = New System.Drawing.Size(57, 20)
        Me.txtayo.TabIndex = 228
        Me.txtayo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtayo.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'txtid
        '
        Appearance69.FontData.BoldAsString = "False"
        Appearance69.ForeColor = System.Drawing.Color.Black
        Appearance69.TextHAlignAsString = "Left"
        Appearance69.TextVAlignAsString = "Middle"
        Me.txtid.Appearance = Appearance69
        Me.txtid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtid.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtid.Location = New System.Drawing.Point(566, 45)
        Me.txtid.MaxLength = 100
        Me.txtid.Name = "txtid"
        Me.txtid.ReadOnly = True
        Me.txtid.Size = New System.Drawing.Size(49, 21)
        Me.txtid.TabIndex = 227
        Me.txtid.TabStop = False
        Me.txtid.Visible = False
        '
        'chktodo
        '
        Me.chktodo.AutoSize = True
        Me.chktodo.BackColor = System.Drawing.Color.Transparent
        Me.chktodo.Location = New System.Drawing.Point(42, 207)
        Me.chktodo.Name = "chktodo"
        Me.chktodo.Size = New System.Drawing.Size(15, 14)
        Me.chktodo.TabIndex = 226
        Me.chktodo.UseVisualStyleBackColor = False
        Me.chktodo.Visible = False
        '
        'Button1
        '
        Me.Button1.Image = Global.SIP_Presentacion.My.Resources.Resources.BINOCULAR
        Me.Button1.Location = New System.Drawing.Point(221, 147)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 22)
        Me.Button1.TabIndex = 225
        Me.Button1.UseVisualStyleBackColor = True
        '
        'gridProductos
        '
        Me.gridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridProductos.DisplayLayout.Appearance = Appearance15
        Me.gridProductos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn16.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance16.Image = CType(resources.GetObject("Appearance16.Image"), Object)
        Appearance16.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance16.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn16.Header.Appearance = Appearance16
        UltraGridColumn16.Header.Caption = ""
        UltraGridColumn16.Header.VisiblePosition = 0
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.MaxWidth = 25
        UltraGridColumn16.MinWidth = 20
        UltraGridColumn16.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn16.Width = 20
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn17.Header.VisiblePosition = 1
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 46
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn18.Header.Caption = "CODIGO"
        UltraGridColumn18.Header.VisiblePosition = 3
        UltraGridColumn18.Width = 72
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn19.Header.VisiblePosition = 5
        UltraGridColumn19.Width = 70
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn20.Header.VisiblePosition = 4
        UltraGridColumn20.Width = 221
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance17
        UltraGridColumn21.Format = "###,##0.00"
        UltraGridColumn21.Header.VisiblePosition = 7
        UltraGridColumn21.MaskInput = "{double:9.2}"
        UltraGridColumn21.Width = 74
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance72.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance72
        UltraGridColumn22.Format = "###,##0.00"
        UltraGridColumn22.Header.VisiblePosition = 8
        UltraGridColumn22.Width = 68
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn23.Header.VisiblePosition = 2
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.Width = 66
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance73.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance73
        UltraGridColumn24.Header.VisiblePosition = 6
        UltraGridColumn24.Width = 88
        UltraGridColumn25.Header.VisiblePosition = 9
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.Width = 91
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25})
        SummarySettings3.DisplayFormat = "Total"
        SummarySettings3.GroupBySummaryValueAppearance = Appearance18
        Appearance23.TextHAlignAsString = "Right"
        SummarySettings4.Appearance = Appearance23
        SummarySettings4.DisplayFormat = "{0:###,##0.00}"
        SummarySettings4.GroupBySummaryValueAppearance = Appearance25
        UltraGridBand2.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings3, SummarySettings4})
        UltraGridBand2.SummaryFooterCaption = ""
        Me.gridProductos.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridProductos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridProductos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion14)
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion15)
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion16)
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion17)
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion18)
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion19)
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion20)
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion21)
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion22)
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion23)
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion24)
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion25)
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion26)
        Me.gridProductos.DisplayLayout.ColScrollRegions.Add(ColScrollRegion27)
        Me.gridProductos.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.gridProductos.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridProductos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance28
        Me.gridProductos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridProductos.DisplayLayout.GroupByBox.Hidden = True
        Appearance37.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance37.BackColor2 = System.Drawing.SystemColors.Control
        Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance37.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridProductos.DisplayLayout.GroupByBox.PromptAppearance = Appearance37
        Me.gridProductos.DisplayLayout.MaxColScrollRegions = 1
        Me.gridProductos.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridProductos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridProductos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridProductos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance39.BackColor = System.Drawing.SystemColors.Window
        Me.gridProductos.DisplayLayout.Override.CardAreaAppearance = Appearance39
        Appearance40.BorderColor = System.Drawing.Color.Silver
        Appearance40.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridProductos.DisplayLayout.Override.CellAppearance = Appearance40
        Me.gridProductos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridProductos.DisplayLayout.Override.CellPadding = 0
        Me.gridProductos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridProductos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridProductos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridProductos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance41.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance41.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridProductos.DisplayLayout.Override.FilterRowAppearance = Appearance41
        Me.gridProductos.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridProductos.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridProductos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance42.BackColor = System.Drawing.SystemColors.Control
        Appearance42.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance42.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance42.BorderColor = System.Drawing.SystemColors.Window
        Me.gridProductos.DisplayLayout.Override.GroupByRowAppearance = Appearance42
        Appearance43.FontData.Name = "Arial Narrow"
        Appearance43.FontData.SizeInPoints = 10.0!
        Appearance43.TextHAlignAsString = "Left"
        Me.gridProductos.DisplayLayout.Override.HeaderAppearance = Appearance43
        Me.gridProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridProductos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridProductos.DisplayLayout.Override.MinRowHeight = 24
        Appearance44.BackColor = System.Drawing.SystemColors.Window
        Appearance44.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance44.TextVAlignAsString = "Middle"
        Me.gridProductos.DisplayLayout.Override.RowAppearance = Appearance44
        Me.gridProductos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridProductos.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridProductos.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance45.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridProductos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance45
        Me.gridProductos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridProductos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridProductos.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridProductos.Location = New System.Drawing.Point(22, 179)
        Me.gridProductos.Name = "gridProductos"
        Me.gridProductos.Size = New System.Drawing.Size(633, 285)
        Me.gridProductos.TabIndex = 224
        Me.gridProductos.Text = "UltraGrid1"
        '
        'UltraLabel8
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.TextHAlignAsString = "Center"
        Appearance8.TextVAlignAsString = "Middle"
        Me.UltraLabel8.Appearance = Appearance8
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Location = New System.Drawing.Point(49, 150)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(34, 14)
        Me.UltraLabel8.TabIndex = 223
        Me.UltraLabel8.Text = "Hasta"
        '
        'dtpHasta1
        '
        Me.dtpHasta1.AutoSize = False
        Me.dtpHasta1.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpHasta1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpHasta1.Location = New System.Drawing.Point(90, 149)
        Me.dtpHasta1.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpHasta1.Name = "dtpHasta1"
        Me.dtpHasta1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpHasta1.Size = New System.Drawing.Size(122, 18)
        Me.dtpHasta1.TabIndex = 222
        Me.dtpHasta1.TabStop = False
        Me.dtpHasta1.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'UltraLabel9
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextHAlignAsString = "Center"
        Appearance10.TextVAlignAsString = "Middle"
        Me.UltraLabel9.Appearance = Appearance10
        Me.UltraLabel9.AutoSize = True
        Me.UltraLabel9.Location = New System.Drawing.Point(46, 127)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(37, 14)
        Me.UltraLabel9.TabIndex = 221
        Me.UltraLabel9.Text = "Desde"
        '
        'dtpDesde1
        '
        Me.dtpDesde1.AutoSize = False
        Me.dtpDesde1.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpDesde1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpDesde1.Location = New System.Drawing.Point(90, 125)
        Me.dtpDesde1.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpDesde1.Name = "dtpDesde1"
        Me.dtpDesde1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpDesde1.Size = New System.Drawing.Size(122, 18)
        Me.dtpDesde1.TabIndex = 220
        Me.dtpDesde1.TabStop = False
        Me.dtpDesde1.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'txtcanteraori
        '
        Appearance67.FontData.BoldAsString = "False"
        Appearance67.ForeColor = System.Drawing.Color.Black
        Appearance67.TextHAlignAsString = "Left"
        Appearance67.TextVAlignAsString = "Middle"
        Me.txtcanteraori.Appearance = Appearance67
        Me.txtcanteraori.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcanteraori.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcanteraori.Location = New System.Drawing.Point(344, 42)
        Me.txtcanteraori.MaxLength = 100
        Me.txtcanteraori.Name = "txtcanteraori"
        Me.txtcanteraori.ReadOnly = True
        Me.txtcanteraori.Size = New System.Drawing.Size(89, 21)
        Me.txtcanteraori.TabIndex = 219
        Me.txtcanteraori.TabStop = False
        Me.txtcanteraori.Visible = False
        '
        'txtcodcanteraori
        '
        Appearance2.FontData.BoldAsString = "False"
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.TextHAlignAsString = "Left"
        Appearance2.TextVAlignAsString = "Middle"
        Me.txtcodcanteraori.Appearance = Appearance2
        Me.txtcodcanteraori.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodcanteraori.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodcanteraori.Location = New System.Drawing.Point(344, 15)
        Me.txtcodcanteraori.MaxLength = 100
        Me.txtcodcanteraori.Name = "txtcodcanteraori"
        Me.txtcodcanteraori.ReadOnly = True
        Me.txtcodcanteraori.Size = New System.Drawing.Size(82, 21)
        Me.txtcodcanteraori.TabIndex = 218
        Me.txtcodcanteraori.TabStop = False
        Me.txtcodcanteraori.Visible = False
        '
        'txtidalmorigen
        '
        Appearance74.FontData.BoldAsString = "False"
        Appearance74.ForeColor = System.Drawing.Color.Black
        Appearance74.TextHAlignAsString = "Left"
        Appearance74.TextVAlignAsString = "Middle"
        Me.txtidalmorigen.Appearance = Appearance74
        Me.txtidalmorigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidalmorigen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtidalmorigen.Location = New System.Drawing.Point(566, 15)
        Me.txtidalmorigen.MaxLength = 100
        Me.txtidalmorigen.Name = "txtidalmorigen"
        Me.txtidalmorigen.ReadOnly = True
        Me.txtidalmorigen.Size = New System.Drawing.Size(49, 21)
        Me.txtidalmorigen.TabIndex = 217
        Me.txtidalmorigen.TabStop = False
        Me.txtidalmorigen.Visible = False
        '
        'txtcodequipo
        '
        Appearance4.FontData.BoldAsString = "False"
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.TextHAlignAsString = "Left"
        Appearance4.TextVAlignAsString = "Middle"
        Me.txtcodequipo.Appearance = Appearance4
        Me.txtcodequipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodequipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodequipo.Location = New System.Drawing.Point(461, 45)
        Me.txtcodequipo.MaxLength = 100
        Me.txtcodequipo.Name = "txtcodequipo"
        Me.txtcodequipo.ReadOnly = True
        Me.txtcodequipo.Size = New System.Drawing.Size(82, 21)
        Me.txtcodequipo.TabIndex = 216
        Me.txtcodequipo.TabStop = False
        Me.txtcodequipo.Visible = False
        '
        'txtcodcliente
        '
        Appearance7.FontData.BoldAsString = "False"
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.TextHAlignAsString = "Left"
        Appearance7.TextVAlignAsString = "Middle"
        Me.txtcodcliente.Appearance = Appearance7
        Me.txtcodcliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodcliente.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodcliente.Location = New System.Drawing.Point(461, 15)
        Me.txtcodcliente.MaxLength = 100
        Me.txtcodcliente.Name = "txtcodcliente"
        Me.txtcodcliente.ReadOnly = True
        Me.txtcodcliente.Size = New System.Drawing.Size(82, 21)
        Me.txtcodcliente.TabIndex = 215
        Me.txtcodcliente.TabStop = False
        Me.txtcodcliente.Visible = False
        '
        'UltraLabel5
        '
        Appearance34.BackColor = System.Drawing.Color.Transparent
        Appearance34.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance34
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel5.Location = New System.Drawing.Point(22, 45)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(61, 17)
        Me.UltraLabel5.TabIndex = 214
        Me.UltraLabel5.Text = "& Contratista"
        '
        'txtcliente
        '
        Appearance36.FontData.BoldAsString = "False"
        Appearance36.ForeColor = System.Drawing.Color.Black
        Appearance36.TextHAlignAsString = "Left"
        Appearance36.TextVAlignAsString = "Middle"
        Me.txtcliente.Appearance = Appearance36
        Me.txtcliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcliente.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcliente.Location = New System.Drawing.Point(90, 43)
        Me.txtcliente.MaxLength = 100
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.ReadOnly = True
        Me.txtcliente.Size = New System.Drawing.Size(238, 21)
        Me.txtcliente.TabIndex = 213
        Me.txtcliente.TabStop = False
        '
        'UltraLabel2
        '
        Appearance19.BackColor = System.Drawing.Color.Transparent
        Appearance19.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance19
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(32, 15)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(51, 17)
        Me.UltraLabel2.TabIndex = 212
        Me.UltraLabel2.Text = "& Almacén"
        '
        'txtalmorigen
        '
        Appearance79.FontData.BoldAsString = "False"
        Appearance79.ForeColor = System.Drawing.Color.Black
        Appearance79.TextHAlignAsString = "Left"
        Appearance79.TextVAlignAsString = "Middle"
        Me.txtalmorigen.Appearance = Appearance79
        Me.txtalmorigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtalmorigen.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtalmorigen.Location = New System.Drawing.Point(90, 13)
        Me.txtalmorigen.MaxLength = 100
        Me.txtalmorigen.Name = "txtalmorigen"
        Me.txtalmorigen.ReadOnly = True
        Me.txtalmorigen.Size = New System.Drawing.Size(238, 21)
        Me.txtalmorigen.TabIndex = 211
        Me.txtalmorigen.TabStop = False
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BackColor = System.Drawing.Color.Transparent
        Me.BindingNavigator1.CountItem = Me.ToolStripLabel1
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.ToolStripTextBox1, Me.ToolStripSeparator3, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator4, Me.ToolStripButton5, Me.ToolStripSeparator5})
        Me.BindingNavigator1.Location = New System.Drawing.Point(2, 4)
        Me.BindingNavigator1.MoveFirstItem = Me.ToolStripButton4
        Me.BindingNavigator1.MoveLastItem = Me.ToolStripButton1
        Me.BindingNavigator1.MoveNextItem = Me.ToolStripButton2
        Me.BindingNavigator1.MovePreviousItem = Me.ToolStripButton3
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.BindingNavigator1.PositionItem = Me.ToolStripTextBox1
        Me.BindingNavigator1.Size = New System.Drawing.Size(314, 25)
        Me.BindingNavigator1.TabIndex = 141
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel1.Text = "de {0}"
        Me.ToolStripLabel1.ToolTipText = "Número total de elementos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Mover último"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Mover siguiente"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AccessibleName = "Posición"
        Me.ToolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.BackColor = System.Drawing.Color.White
        Me.ToolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripTextBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(50, 23)
        Me.ToolStripTextBox1.Text = "0"
        Me.ToolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolStripTextBox1.ToolTipText = "Posición actual"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Mover anterior"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Mover primero"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton5.Image = Global.SIP_Presentacion.My.Resources.Resources.Hand
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(99, 22)
        Me.ToolStripButton5.Text = "SELECCIONAR"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'Tab1
        '
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.Name = "Arial Narrow"
        Appearance3.FontData.SizeInPoints = 16.0!
        Me.Tab1.ActiveTabAppearance = Appearance3
        Appearance1.FontData.Name = "Arial Narrow"
        Appearance1.FontData.SizeInPoints = 10.0!
        Me.Tab1.Appearance = Appearance1
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Controls.Add(Me.grid)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(869, 511)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance11
        Me.Tab1.TabIndex = 4
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance24.Cursor = System.Windows.Forms.Cursors.Default
        Appearance24.FontData.BoldAsString = "True"
        Appearance24.FontData.Name = "Arial Narrow"
        Appearance24.FontData.SizeInPoints = 16.0!
        UltraTab3.ActiveAppearance = Appearance24
        Appearance49.FontData.Name = "Arial Narrow"
        Appearance49.FontData.SizeInPoints = 10.0!
        UltraTab3.Appearance = Appearance49
        UltraTab3.Key = "T01"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "IMPORTAR DATOS"
        Appearance76.Cursor = System.Windows.Forms.Cursors.Default
        Appearance76.FontData.BoldAsString = "True"
        Appearance76.FontData.Name = "Arial Narrow"
        Appearance76.FontData.SizeInPoints = 16.0!
        UltraTab1.ActiveAppearance = Appearance76
        Appearance6.FontData.Name = "Arial Narrow"
        Appearance6.FontData.SizeInPoints = 10.0!
        UltraTab1.Appearance = Appearance6
        UltraTab1.Key = "T02"
        UltraTab1.TabPage = Me.grid
        UltraTab1.Text = "LISTADO DE CARGAS"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab3, UltraTab1})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(865, 473)
        '
        'UltraLabel3
        '
        Me.UltraLabel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance35.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Appearance35.FontData.BoldAsString = "True"
        Appearance35.FontData.SizeInPoints = 10.0!
        Appearance35.ForeColor = System.Drawing.Color.SteelBlue
        Appearance35.TextHAlignAsString = "Center"
        Appearance35.TextVAlignAsString = "Middle"
        Me.UltraLabel3.Appearance = Appearance35
        Me.UltraLabel3.Location = New System.Drawing.Point(-1, 165)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(866, 39)
        Me.UltraLabel3.TabIndex = 157
        Me.UltraLabel3.Text = "Procesando Datos..."
        Me.UltraLabel3.Visible = False
        '
        'UltraLabel6
        '
        Appearance55.BackColor = System.Drawing.Color.Transparent
        Appearance55.TextHAlignAsString = "Center"
        Appearance55.TextVAlignAsString = "Middle"
        Me.UltraLabel6.Appearance = Appearance55
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(195, 44)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(34, 14)
        Me.UltraLabel6.TabIndex = 181
        Me.UltraLabel6.Text = "Hasta"
        '
        'UltraDateTimeEditor1
        '
        Me.UltraDateTimeEditor1.AutoSize = False
        Me.UltraDateTimeEditor1.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.UltraDateTimeEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.UltraDateTimeEditor1.Location = New System.Drawing.Point(235, 42)
        Me.UltraDateTimeEditor1.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.UltraDateTimeEditor1.Name = "UltraDateTimeEditor1"
        Me.UltraDateTimeEditor1.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.UltraDateTimeEditor1.Size = New System.Drawing.Size(122, 18)
        Me.UltraDateTimeEditor1.TabIndex = 180
        Me.UltraDateTimeEditor1.TabStop = False
        Me.UltraDateTimeEditor1.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'UltraLabel7
        '
        Appearance58.BackColor = System.Drawing.Color.Transparent
        Appearance58.TextHAlignAsString = "Center"
        Appearance58.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance58
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Location = New System.Drawing.Point(11, 45)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(37, 14)
        Me.UltraLabel7.TabIndex = 179
        Me.UltraLabel7.Text = "Desde"
        '
        'UltraDateTimeEditor2
        '
        Me.UltraDateTimeEditor2.AutoSize = False
        Me.UltraDateTimeEditor2.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.UltraDateTimeEditor2.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.UltraDateTimeEditor2.Location = New System.Drawing.Point(54, 42)
        Me.UltraDateTimeEditor2.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.UltraDateTimeEditor2.Name = "UltraDateTimeEditor2"
        Me.UltraDateTimeEditor2.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.UltraDateTimeEditor2.Size = New System.Drawing.Size(122, 18)
        Me.UltraDateTimeEditor2.TabIndex = 178
        Me.UltraDateTimeEditor2.TabStop = False
        Me.UltraDateTimeEditor2.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance77.BackColor = System.Drawing.SystemColors.Window
        Appearance77.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraGrid1.DisplayLayout.Appearance = Appearance77
        Me.UltraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn26.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance27.Image = CType(resources.GetObject("Appearance27.Image"), Object)
        Appearance27.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance27.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn26.Header.Appearance = Appearance27
        UltraGridColumn26.Header.Caption = ""
        UltraGridColumn26.Header.VisiblePosition = 0
        UltraGridColumn26.Hidden = True
        UltraGridColumn26.MaxWidth = 25
        UltraGridColumn26.MinWidth = 20
        UltraGridColumn26.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn26.Width = 20
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn27.Header.VisiblePosition = 1
        UltraGridColumn27.Hidden = True
        UltraGridColumn27.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn27.Width = 45
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn28.Header.Caption = "AÑO"
        UltraGridColumn28.Header.VisiblePosition = 2
        UltraGridColumn28.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn28.Width = 18
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn29.Header.VisiblePosition = 3
        UltraGridColumn29.Hidden = True
        UltraGridColumn29.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn29.Width = 47
        UltraGridColumn30.Header.VisiblePosition = 4
        UltraGridColumn30.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn30.Width = 76
        UltraGridColumn31.Header.Caption = "TIPO CARGA"
        UltraGridColumn31.Header.VisiblePosition = 5
        UltraGridColumn31.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn31.Width = 92
        UltraGridColumn32.Header.VisiblePosition = 6
        UltraGridColumn32.Hidden = True
        UltraGridColumn32.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn32.Width = 77
        UltraGridColumn33.Header.VisiblePosition = 7
        UltraGridColumn33.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn33.Width = 169
        UltraGridColumn34.Header.VisiblePosition = 8
        UltraGridColumn34.Hidden = True
        UltraGridColumn34.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn34.Width = 106
        UltraGridColumn35.Header.VisiblePosition = 9
        UltraGridColumn35.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn35.Width = 126
        UltraGridColumn36.Header.Caption = "COD. EQUIPO"
        UltraGridColumn36.Header.VisiblePosition = 10
        UltraGridColumn36.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn36.Width = 60
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn37.Header.Caption = "FECHA CARGA"
        UltraGridColumn37.Header.VisiblePosition = 11
        UltraGridColumn37.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn37.Width = 76
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn38.Header.VisiblePosition = 12
        UltraGridColumn38.Hidden = True
        UltraGridColumn38.Width = 85
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn39.Header.Caption = "PERIODO"
        UltraGridColumn39.Header.VisiblePosition = 13
        UltraGridColumn39.Width = 96
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance31.TextHAlignAsString = "Right"
        UltraGridColumn40.CellAppearance = Appearance31
        UltraGridColumn40.Header.VisiblePosition = 14
        UltraGridColumn40.Width = 92
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40})
        SummarySettings5.DisplayFormat = "Total"
        SummarySettings5.GroupBySummaryValueAppearance = Appearance20
        Appearance22.TextHAlignAsString = "Right"
        SummarySettings6.Appearance = Appearance22
        SummarySettings6.DisplayFormat = "{0}"
        SummarySettings6.GroupBySummaryValueAppearance = Appearance21
        UltraGridBand3.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings5, SummarySettings6})
        UltraGridBand3.SummaryFooterCaption = ""
        Me.UltraGrid1.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.UltraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion28)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion29)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion30)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion31)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion32)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion33)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion34)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion35)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion36)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion37)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion38)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion39)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion40)
        Me.UltraGrid1.DisplayLayout.ColScrollRegions.Add(ColScrollRegion41)
        Me.UltraGrid1.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance29.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance29.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.GroupByBox.Appearance = Appearance29
        Appearance30.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance30
        Me.UltraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid1.DisplayLayout.GroupByBox.Hidden = True
        Appearance56.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance56.BackColor2 = System.Drawing.SystemColors.Control
        Appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance56.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance56
        Me.UltraGrid1.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGrid1.DisplayLayout.MaxRowScrollRegions = 1
        Me.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = Appearance32
        Appearance33.BorderColor = System.Drawing.Color.Silver
        Appearance33.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGrid1.DisplayLayout.Override.CellAppearance = Appearance33
        Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGrid1.DisplayLayout.Override.CellPadding = 0
        Me.UltraGrid1.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.UltraGrid1.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.UltraGrid1.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.UltraGrid1.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance57.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance57.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.UltraGrid1.DisplayLayout.Override.FilterRowAppearance = Appearance57
        Me.UltraGrid1.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.UltraGrid1.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.UltraGrid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance59.BackColor = System.Drawing.SystemColors.Control
        Appearance59.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance59.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance59.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.Override.GroupByRowAppearance = Appearance59
        Appearance38.FontData.Name = "Arial Narrow"
        Appearance38.FontData.SizeInPoints = 10.0!
        Appearance38.TextHAlignAsString = "Left"
        Me.UltraGrid1.DisplayLayout.Override.HeaderAppearance = Appearance38
        Me.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.UltraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.UltraGrid1.DisplayLayout.Override.MinRowHeight = 24
        Appearance62.BackColor = System.Drawing.SystemColors.Window
        Appearance62.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance62.TextVAlignAsString = "Middle"
        Me.UltraGrid1.DisplayLayout.Override.RowAppearance = Appearance62
        Me.UltraGrid1.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.UltraGrid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.UltraGrid1.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance63.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance63
        Me.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.UltraGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid1.Location = New System.Drawing.Point(11, 66)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(845, 322)
        Me.UltraGrid1.TabIndex = 177
        Me.UltraGrid1.Text = "UltraGrid1"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraStatusBar1.Controls.Add(Me.BindingNavigator1)
        Me.UltraStatusBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 0)
        Me.UltraStatusBar1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        UltraStatusPanel2.Control = Me.BindingNavigator1
        UltraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer
        Me.UltraStatusBar1.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel2})
        Me.UltraStatusBar1.Size = New System.Drawing.Size(865, 30)
        Me.UltraStatusBar1.SizeGripVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraStatusBar1.TabIndex = 176
        Me.UltraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'cmbMoneda
        '
        Me.cmbMoneda.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMoneda.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem23.DataValue = "S"
        ValueListItem23.DisplayText = "SOLES"
        ValueListItem24.DataValue = "D"
        ValueListItem24.DisplayText = "DOLARES"
        Me.cmbMoneda.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem23, ValueListItem24})
        Me.cmbMoneda.Location = New System.Drawing.Point(276, 96)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(150, 21)
        Me.cmbMoneda.TabIndex = 233
        '
        'txttotal
        '
        Me.txttotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance47.FontData.BoldAsString = "False"
        Appearance47.ForeColor = System.Drawing.Color.Black
        Appearance47.TextHAlignAsString = "Right"
        Appearance47.TextVAlignAsString = "Middle"
        Me.txttotal.Appearance = Appearance47
        Me.txttotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotal.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttotal.Location = New System.Drawing.Point(533, 147)
        Me.txttotal.MaxLength = 100
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(122, 21)
        Me.txttotal.TabIndex = 234
        Me.txttotal.TabStop = False
        Me.txttotal.Visible = False
        '
        'lblmensaje
        '
        Me.lblmensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance12.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Appearance12.FontData.BoldAsString = "True"
        Appearance12.FontData.SizeInPoints = 10.0!
        Appearance12.ForeColor = System.Drawing.Color.SteelBlue
        Appearance12.TextHAlignAsString = "Center"
        Appearance12.TextVAlignAsString = "Middle"
        Me.lblmensaje.Appearance = Appearance12
        Me.lblmensaje.Location = New System.Drawing.Point(1, 236)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(866, 39)
        Me.lblmensaje.TabIndex = 158
        Me.lblmensaje.Text = "Procesando Datos..."
        Me.lblmensaje.Visible = False
        '
        'frmFacturaCombustible
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 511)
        Me.Controls.Add(Me.lblmensaje)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "frmFacturaCombustible"
        Me.Text = "frmFacturaCombustible"
        CType(Me.BindingNavigator2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator2.ResumeLayout(False)
        Me.BindingNavigator2.PerformLayout()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.dtpHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridCarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraStatusBar2.ResumeLayout(False)
        Me.UltraStatusBar2.PerformLayout()
        Me.grid.ResumeLayout(False)
        Me.grid.PerformLayout()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtayo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpHasta1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDesde1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcanteraori, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodcanteraori, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtidalmorigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodequipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodcliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtalmorigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.UltraDateTimeEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDateTimeEditor2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraStatusBar1.ResumeLayout(False)
        Me.UltraStatusBar1.PerformLayout()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents grid As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpHasta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpDesde As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents gridCarga As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraStatusBar2 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents BindingNavigator2 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcliente As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtalmorigen As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcodequipo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcodcliente As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcanteraori As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcodcanteraori As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtidalmorigen As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpHasta1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpDesde1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraDateTimeEditor1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraDateTimeEditor2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gridProductos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Source2 As System.Windows.Forms.BindingSource
    Friend WithEvents chktodo As System.Windows.Forms.CheckBox
    Friend WithEvents txtid As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtayo As System.Windows.Forms.NumericUpDown
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbMes As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cmbMoneda As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents txttotal As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
End Class
