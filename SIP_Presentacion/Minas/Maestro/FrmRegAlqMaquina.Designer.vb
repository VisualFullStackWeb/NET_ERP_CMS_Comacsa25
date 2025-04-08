<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegAlqMaquina
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
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AYO", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA", 3)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROV", 4)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RAZON", 5)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NUMDOC", 6)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HORA", 7)
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GALON", 8)
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GALON_HORA", 9)
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONTRATISTA", 10)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("APROBADO", 11)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RUTA", 12)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ESTADO", 13)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NOTA_CREDITO", 14)
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IMPORTE_NC", 15)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OBSERVACIONES", 16)
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "", Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "PERIODODESC", -2, False)
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CANTIDAD", -2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CANTIDAD", -2, False)
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(992)
        Dim ColScrollRegion4 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion5 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion6 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion7 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion8 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion9 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion10 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion11 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion12 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
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
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance123 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPO_DOC", 0)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NUMDOC", 1)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA", 2)
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RAZSOC", 3)
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IMPORTE", 4)
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_PROV", 5)
        Dim SummarySettings3 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Nothing, Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "MATERIAL", -2, False)
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings4 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CANTIDAD", -2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CANTIDAD", -2, False)
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings5 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Nothing, Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "UM", -2, False)
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings6 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Nothing, Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TIPOTAREO", -2, False)
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings7 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CANTMAQUINA", -2, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CANTMAQUINA", -2, False)
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion13 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(451)
        Dim ColScrollRegion14 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion15 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion16 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(945)
        Dim ColScrollRegion17 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(852)
        Dim ColScrollRegion18 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion19 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion20 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion21 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion22 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion23 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion24 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion25 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion26 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance128 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance129 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance130 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance131 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance132 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance133 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance134 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance135 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance136 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_CANTERA", 0)
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA", 1)
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HORO_INI", 2)
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HORO_FIN", 3)
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HORA", 4)
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GALONES", 5)
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GALON_HORA", 6)
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LABOR", 7)
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ACTIVIDAD", 8)
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CANTERA", 9)
        Dim SummarySettings8 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, Nothing, Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "HORO_FIN", 3, False)
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings9 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "HORA", 4, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "HORA", 4, False)
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings10 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "GALONES", 5, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "GALONES", 5, False)
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings11 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "GALON_HORA", 6, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "GALON_HORA", 6, False)
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion27 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion28 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion29 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(945)
        Dim ColScrollRegion30 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(852)
        Dim ColScrollRegion31 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion32 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion33 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion34 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion35 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion36 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion37 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion38 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion39 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
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
        Dim ValueListItem25 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem26 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance114 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 0)
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AYO", 1)
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MESNRO", 2)
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MES", 3)
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPOCARGA", 4)
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CODCONTRATISTA", 5)
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CONTRATISTA", 6)
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CODALMACEN", 7)
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ALMACEN", 8)
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COD_EQUIPO", 9)
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA_CARGA", 10)
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PERIODO", 11)
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PERIODODESC", 12)
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CANTIDAD", 13)
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings12 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Formula, "", Nothing, -1, False, Nothing, -1, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "PERIODODESC", 12, False)
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim SummarySettings13 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CANTIDAD", 13, False, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "CANTIDAD", 13, False)
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ColScrollRegion40 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(0)
        Dim ColScrollRegion41 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(843)
        Dim ColScrollRegion42 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(992)
        Dim ColScrollRegion43 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(796)
        Dim ColScrollRegion44 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion45 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion46 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion47 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion48 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion49 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion50 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion51 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraStatusPanel2 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegAlqMaquina))
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpFin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpIni = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.gridData = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.lblmensaje = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.txtimporteNC = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.chkNC = New System.Windows.Forms.CheckBox
        Me.txtobservacion = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtproveedor = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcodprov = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.gridFactura = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.chkaprobar = New System.Windows.Forms.CheckBox
        Me.txtruta = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.chkcontratista = New System.Windows.Forms.CheckBox
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbperiodo = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.txtcanteraori = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcodcanteraori = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtid = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.gridDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnImportar = New System.Windows.Forms.Button
        Me.UltraLabel15 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbMes = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.txtAño = New System.Windows.Forms.NumericUpDown
        Me.dtfin = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.dtinicio = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtcodequipo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtcodcliente = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.BindingNavigator2 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpHasta = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.dtpDesde = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.gridCarga = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraStatusBar2 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton
        Me.Source1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Source2 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.dtpFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpIni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraStatusBar1.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.txtimporteNC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtobservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtproveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodprov, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtruta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbperiodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcanteraori, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodcanteraori, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtfin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtinicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodequipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcodcliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator2.SuspendLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        CType(Me.dtpHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridCarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraStatusBar2.SuspendLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BackColor = System.Drawing.Color.Transparent
        Me.BindingNavigator1.CountItem = Me.ToolStripLabel1
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.None
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.ToolStripTextBox1, Me.ToolStripSeparator4, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator7, Me.ToolStripButton5, Me.ToolStripSeparator8})
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel7)
        Me.UltraTabPageControl2.Controls.Add(Me.dtpFin)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraLabel8)
        Me.UltraTabPageControl2.Controls.Add(Me.dtpIni)
        Me.UltraTabPageControl2.Controls.Add(Me.gridData)
        Me.UltraTabPageControl2.Controls.Add(Me.UltraStatusBar1)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(865, 475)
        '
        'UltraLabel7
        '
        Appearance55.BackColor = System.Drawing.Color.Transparent
        Appearance55.TextHAlignAsString = "Center"
        Appearance55.TextVAlignAsString = "Middle"
        Me.UltraLabel7.Appearance = Appearance55
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Location = New System.Drawing.Point(194, 41)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(34, 14)
        Me.UltraLabel7.TabIndex = 180
        Me.UltraLabel7.Text = "Hasta"
        '
        'dtpFin
        '
        Me.dtpFin.AutoSize = False
        Me.dtpFin.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpFin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpFin.Location = New System.Drawing.Point(234, 39)
        Me.dtpFin.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpFin.Size = New System.Drawing.Size(122, 18)
        Me.dtpFin.TabIndex = 179
        Me.dtpFin.TabStop = False
        Me.dtpFin.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'UltraLabel8
        '
        Appearance58.BackColor = System.Drawing.Color.Transparent
        Appearance58.TextHAlignAsString = "Center"
        Appearance58.TextVAlignAsString = "Middle"
        Me.UltraLabel8.Appearance = Appearance58
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Location = New System.Drawing.Point(10, 42)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(37, 14)
        Me.UltraLabel8.TabIndex = 178
        Me.UltraLabel8.Text = "Desde"
        '
        'dtpIni
        '
        Me.dtpIni.AutoSize = False
        Me.dtpIni.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpIni.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpIni.Location = New System.Drawing.Point(53, 39)
        Me.dtpIni.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpIni.Name = "dtpIni"
        Me.dtpIni.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpIni.Size = New System.Drawing.Size(122, 18)
        Me.dtpIni.TabIndex = 177
        Me.dtpIni.TabStop = False
        Me.dtpIni.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'gridData
        '
        Me.gridData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance4.BackColor = System.Drawing.SystemColors.Window
        Appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridData.DisplayLayout.Appearance = Appearance4
        Me.gridData.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance27.Image = CType(resources.GetObject("Appearance27.Image"), Object)
        Appearance27.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance27.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance27
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 62
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 37
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 45
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 48
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 63
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 210
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Width = 108
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance7
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 96
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance36.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance36
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 105
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance88.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance88
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Width = 127
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 126
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Hidden = True
        UltraGridColumn13.Width = 119
        UltraGridColumn14.Header.VisiblePosition = 13
        UltraGridColumn14.Hidden = True
        UltraGridColumn14.Width = 205
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn15.Header.VisiblePosition = 14
        UltraGridColumn15.Width = 96
        UltraGridColumn16.Header.VisiblePosition = 15
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.Width = 75
        UltraGridColumn17.Header.VisiblePosition = 16
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 93
        UltraGridColumn18.Header.VisiblePosition = 17
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.Width = 118
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18})
        SummarySettings1.DisplayFormat = "Total"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance20
        Appearance22.TextHAlignAsString = "Right"
        SummarySettings2.Appearance = Appearance22
        SummarySettings2.DisplayFormat = "{0}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance21
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1, SummarySettings2})
        UltraGridBand1.SummaryFooterCaption = ""
        Me.gridData.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridData.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridData.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridData.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridData.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridData.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridData.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridData.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridData.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridData.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridData.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridData.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridData.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridData.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridData.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.gridData.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance29.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance29.BorderColor = System.Drawing.SystemColors.Window
        Me.gridData.DisplayLayout.GroupByBox.Appearance = Appearance29
        Appearance30.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridData.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance30
        Me.gridData.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridData.DisplayLayout.GroupByBox.Hidden = True
        Appearance56.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance56.BackColor2 = System.Drawing.SystemColors.Control
        Appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance56.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridData.DisplayLayout.GroupByBox.PromptAppearance = Appearance56
        Me.gridData.DisplayLayout.MaxColScrollRegions = 1
        Me.gridData.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridData.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridData.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Me.gridData.DisplayLayout.Override.CardAreaAppearance = Appearance32
        Appearance33.BorderColor = System.Drawing.Color.Silver
        Appearance33.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridData.DisplayLayout.Override.CellAppearance = Appearance33
        Me.gridData.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridData.DisplayLayout.Override.CellPadding = 0
        Me.gridData.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridData.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridData.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridData.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance57.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance57.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridData.DisplayLayout.Override.FilterRowAppearance = Appearance57
        Me.gridData.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridData.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridData.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance59.BackColor = System.Drawing.SystemColors.Control
        Appearance59.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance59.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance59.BorderColor = System.Drawing.SystemColors.Window
        Me.gridData.DisplayLayout.Override.GroupByRowAppearance = Appearance59
        Appearance38.FontData.Name = "Arial Narrow"
        Appearance38.FontData.SizeInPoints = 10.0!
        Appearance38.TextHAlignAsString = "Left"
        Me.gridData.DisplayLayout.Override.HeaderAppearance = Appearance38
        Me.gridData.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridData.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridData.DisplayLayout.Override.MinRowHeight = 24
        Appearance62.BackColor = System.Drawing.SystemColors.Window
        Appearance62.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance62.TextVAlignAsString = "Middle"
        Me.gridData.DisplayLayout.Override.RowAppearance = Appearance62
        Me.gridData.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridData.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridData.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance63.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridData.DisplayLayout.Override.TemplateAddRowAppearance = Appearance63
        Me.gridData.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridData.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridData.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridData.Location = New System.Drawing.Point(10, 63)
        Me.gridData.Name = "gridData"
        Me.gridData.Size = New System.Drawing.Size(845, 322)
        Me.gridData.TabIndex = 176
        Me.gridData.Text = "UltraGrid1"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.UltraStatusBar1.Controls.Add(Me.BindingNavigator1)
        Me.UltraStatusBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 0)
        Me.UltraStatusBar1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        UltraStatusPanel1.Control = Me.BindingNavigator1
        UltraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer
        Me.UltraStatusBar1.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1})
        Me.UltraStatusBar1.Size = New System.Drawing.Size(865, 30)
        Me.UltraStatusBar1.SizeGripVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraStatusBar1.TabIndex = 152
        Me.UltraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.lblmensaje)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel10)
        Me.UltraTabPageControl1.Controls.Add(Me.txtimporteNC)
        Me.UltraTabPageControl1.Controls.Add(Me.chkNC)
        Me.UltraTabPageControl1.Controls.Add(Me.txtobservacion)
        Me.UltraTabPageControl1.Controls.Add(Me.txtproveedor)
        Me.UltraTabPageControl1.Controls.Add(Me.txtcodprov)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel9)
        Me.UltraTabPageControl1.Controls.Add(Me.gridFactura)
        Me.UltraTabPageControl1.Controls.Add(Me.chkaprobar)
        Me.UltraTabPageControl1.Controls.Add(Me.txtruta)
        Me.UltraTabPageControl1.Controls.Add(Me.chkcontratista)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel6)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbperiodo)
        Me.UltraTabPageControl1.Controls.Add(Me.txtcanteraori)
        Me.UltraTabPageControl1.Controls.Add(Me.txtcodcanteraori)
        Me.UltraTabPageControl1.Controls.Add(Me.txtid)
        Me.UltraTabPageControl1.Controls.Add(Me.gridDetalle)
        Me.UltraTabPageControl1.Controls.Add(Me.btnImportar)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel15)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbMes)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel3)
        Me.UltraTabPageControl1.Controls.Add(Me.txtAño)
        Me.UltraTabPageControl1.Controls.Add(Me.dtfin)
        Me.UltraTabPageControl1.Controls.Add(Me.dtinicio)
        Me.UltraTabPageControl1.Controls.Add(Me.txtcodequipo)
        Me.UltraTabPageControl1.Controls.Add(Me.txtcodcliente)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel4)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(865, 475)
        '
        'lblmensaje
        '
        Me.lblmensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance35.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Appearance35.FontData.BoldAsString = "True"
        Appearance35.FontData.SizeInPoints = 10.0!
        Appearance35.ForeColor = System.Drawing.Color.SteelBlue
        Appearance35.TextHAlignAsString = "Center"
        Appearance35.TextVAlignAsString = "Middle"
        Me.lblmensaje.Appearance = Appearance35
        Me.lblmensaje.Location = New System.Drawing.Point(2, 138)
        Me.lblmensaje.Name = "lblmensaje"
        Me.lblmensaje.Size = New System.Drawing.Size(866, 39)
        Me.lblmensaje.TabIndex = 157
        Me.lblmensaje.Text = "Procesando Datos..."
        Me.lblmensaje.Visible = False
        '
        'UltraLabel10
        '
        Appearance37.BackColor = System.Drawing.Color.Transparent
        Appearance37.TextHAlignAsString = "Right"
        Me.UltraLabel10.Appearance = Appearance37
        Me.UltraLabel10.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel10.Location = New System.Drawing.Point(349, 183)
        Me.UltraLabel10.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(48, 16)
        Me.UltraLabel10.TabIndex = 233
        Me.UltraLabel10.Text = "Obs."
        '
        'txtimporteNC
        '
        Appearance89.FontData.BoldAsString = "False"
        Appearance89.ForeColor = System.Drawing.Color.Black
        Appearance89.TextHAlignAsString = "Right"
        Appearance89.TextVAlignAsString = "Middle"
        Me.txtimporteNC.Appearance = Appearance89
        Me.txtimporteNC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtimporteNC.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtimporteNC.Location = New System.Drawing.Point(78, 207)
        Me.txtimporteNC.MaxLength = 8
        Me.txtimporteNC.Name = "txtimporteNC"
        Me.txtimporteNC.ReadOnly = True
        Me.txtimporteNC.Size = New System.Drawing.Size(100, 21)
        Me.txtimporteNC.TabIndex = 232
        '
        'chkNC
        '
        Me.chkNC.AutoSize = True
        Me.chkNC.BackColor = System.Drawing.Color.Transparent
        Me.chkNC.Location = New System.Drawing.Point(78, 184)
        Me.chkNC.Name = "chkNC"
        Me.chkNC.Size = New System.Drawing.Size(100, 17)
        Me.chkNC.TabIndex = 231
        Me.chkNC.Text = "Nota de Crédito"
        Me.chkNC.UseVisualStyleBackColor = False
        '
        'txtobservacion
        '
        Me.txtobservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance67.FontData.BoldAsString = "False"
        Appearance67.ForeColor = System.Drawing.Color.Black
        Appearance67.TextHAlignAsString = "Left"
        Appearance67.TextVAlignAsString = "Middle"
        Me.txtobservacion.Appearance = Appearance67
        Me.txtobservacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtobservacion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtobservacion.Location = New System.Drawing.Point(403, 183)
        Me.txtobservacion.MaxLength = 500
        Me.txtobservacion.Multiline = True
        Me.txtobservacion.Name = "txtobservacion"
        Me.txtobservacion.Size = New System.Drawing.Size(453, 46)
        Me.txtobservacion.TabIndex = 230
        Me.txtobservacion.TabStop = False
        '
        'txtproveedor
        '
        Appearance16.FontData.BoldAsString = "False"
        Appearance16.ForeColor = System.Drawing.Color.Black
        Appearance16.TextHAlignAsString = "Left"
        Appearance16.TextVAlignAsString = "Middle"
        Me.txtproveedor.Appearance = Appearance16
        Me.txtproveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtproveedor.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtproveedor.Location = New System.Drawing.Point(160, 125)
        Me.txtproveedor.MaxLength = 20
        Me.txtproveedor.Name = "txtproveedor"
        Me.txtproveedor.ReadOnly = True
        Me.txtproveedor.Size = New System.Drawing.Size(237, 21)
        Me.txtproveedor.TabIndex = 228
        Me.txtproveedor.TabStop = False
        '
        'txtcodprov
        '
        Appearance5.FontData.BoldAsString = "False"
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.TextHAlignAsString = "Left"
        Appearance5.TextVAlignAsString = "Middle"
        Me.txtcodprov.Appearance = Appearance5
        Me.txtcodprov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodprov.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodprov.Location = New System.Drawing.Point(78, 125)
        Me.txtcodprov.MaxLength = 8
        Me.txtcodprov.Name = "txtcodprov"
        Me.txtcodprov.Size = New System.Drawing.Size(76, 21)
        Me.txtcodprov.TabIndex = 229
        '
        'UltraLabel9
        '
        Appearance34.BackColor = System.Drawing.Color.Transparent
        Appearance34.TextHAlignAsString = "Right"
        Me.UltraLabel9.Appearance = Appearance34
        Me.UltraLabel9.AutoSize = True
        Me.UltraLabel9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel9.Location = New System.Drawing.Point(8, 127)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(59, 17)
        Me.UltraLabel9.TabIndex = 227
        Me.UltraLabel9.Text = "& Proveedor"
        '
        'gridFactura
        '
        Me.gridFactura.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance123.BackColor = System.Drawing.SystemColors.Window
        Appearance123.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridFactura.DisplayLayout.Appearance = Appearance123
        Me.gridFactura.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn19.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance124.Image = CType(resources.GetObject("Appearance124.Image"), Object)
        Appearance124.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance124.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn19.Header.Appearance = Appearance124
        UltraGridColumn19.Header.Caption = ""
        UltraGridColumn19.Header.VisiblePosition = 0
        UltraGridColumn19.Hidden = True
        UltraGridColumn19.MaxWidth = 25
        UltraGridColumn19.MinWidth = 20
        UltraGridColumn19.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn19.Width = 20
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn20.Header.VisiblePosition = 1
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.Width = 53
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn21.Header.Caption = "N° FACTURA"
        UltraGridColumn21.Header.VisiblePosition = 2
        UltraGridColumn21.Width = 85
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn22.Header.VisiblePosition = 3
        UltraGridColumn22.Width = 72
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn23.Header.Caption = "RAZON"
        UltraGridColumn23.Header.VisiblePosition = 4
        UltraGridColumn23.Width = 179
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance40.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance40
        UltraGridColumn24.Header.VisiblePosition = 5
        UltraGridColumn24.Width = 60
        UltraGridColumn25.Header.VisiblePosition = 6
        UltraGridColumn25.Hidden = True
        UltraGridColumn25.Width = 86
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25})
        SummarySettings3.DisplayFormat = "Total"
        SummarySettings3.GroupBySummaryValueAppearance = Appearance14
        Appearance17.TextHAlignAsString = "Right"
        SummarySettings4.Appearance = Appearance17
        SummarySettings4.DisplayFormat = "{0}"
        SummarySettings4.GroupBySummaryValueAppearance = Appearance15
        SummarySettings5.DisplayFormat = " "
        SummarySettings5.GroupBySummaryValueAppearance = Appearance18
        SummarySettings6.DisplayFormat = "Total Tareo"
        SummarySettings6.GroupBySummaryValueAppearance = Appearance23
        Appearance25.TextHAlignAsString = "Right"
        SummarySettings7.Appearance = Appearance25
        SummarySettings7.DisplayFormat = "{0}"
        SummarySettings7.GroupBySummaryValueAppearance = Appearance26
        UltraGridBand2.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings3, SummarySettings4, SummarySettings5, SummarySettings6, SummarySettings7})
        UltraGridBand2.SummaryFooterCaption = ""
        Me.gridFactura.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridFactura.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridFactura.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion13)
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion14)
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion15)
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion16)
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion17)
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion18)
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion19)
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion20)
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion21)
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion22)
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion23)
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion24)
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion25)
        Me.gridFactura.DisplayLayout.ColScrollRegions.Add(ColScrollRegion26)
        Me.gridFactura.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance127.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance127.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance127.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance127.BorderColor = System.Drawing.SystemColors.Window
        Me.gridFactura.DisplayLayout.GroupByBox.Appearance = Appearance127
        Appearance128.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridFactura.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance128
        Me.gridFactura.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridFactura.DisplayLayout.GroupByBox.Hidden = True
        Appearance129.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance129.BackColor2 = System.Drawing.SystemColors.Control
        Appearance129.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance129.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridFactura.DisplayLayout.GroupByBox.PromptAppearance = Appearance129
        Me.gridFactura.DisplayLayout.MaxColScrollRegions = 1
        Me.gridFactura.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridFactura.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridFactura.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridFactura.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance130.BackColor = System.Drawing.SystemColors.Window
        Me.gridFactura.DisplayLayout.Override.CardAreaAppearance = Appearance130
        Appearance131.BorderColor = System.Drawing.Color.Silver
        Appearance131.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridFactura.DisplayLayout.Override.CellAppearance = Appearance131
        Me.gridFactura.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridFactura.DisplayLayout.Override.CellPadding = 0
        Me.gridFactura.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridFactura.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridFactura.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridFactura.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance132.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance132.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridFactura.DisplayLayout.Override.FilterRowAppearance = Appearance132
        Me.gridFactura.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridFactura.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance133.BackColor = System.Drawing.SystemColors.Control
        Appearance133.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance133.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance133.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance133.BorderColor = System.Drawing.SystemColors.Window
        Me.gridFactura.DisplayLayout.Override.GroupByRowAppearance = Appearance133
        Appearance134.FontData.Name = "Arial Narrow"
        Appearance134.FontData.SizeInPoints = 10.0!
        Appearance134.TextHAlignAsString = "Left"
        Me.gridFactura.DisplayLayout.Override.HeaderAppearance = Appearance134
        Me.gridFactura.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridFactura.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridFactura.DisplayLayout.Override.MinRowHeight = 24
        Appearance135.BackColor = System.Drawing.SystemColors.Window
        Appearance135.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance135.TextVAlignAsString = "Middle"
        Me.gridFactura.DisplayLayout.Override.RowAppearance = Appearance135
        Me.gridFactura.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridFactura.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridFactura.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance136.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridFactura.DisplayLayout.Override.TemplateAddRowAppearance = Appearance136
        Me.gridFactura.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridFactura.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridFactura.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridFactura.Location = New System.Drawing.Point(403, 12)
        Me.gridFactura.Name = "gridFactura"
        Me.gridFactura.Size = New System.Drawing.Size(453, 165)
        Me.gridFactura.TabIndex = 222
        Me.gridFactura.Text = "UltraGrid1"
        '
        'chkaprobar
        '
        Me.chkaprobar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkaprobar.AutoSize = True
        Me.chkaprobar.BackColor = System.Drawing.Color.Transparent
        Me.chkaprobar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkaprobar.ForeColor = System.Drawing.Color.Red
        Me.chkaprobar.Location = New System.Drawing.Point(15, 449)
        Me.chkaprobar.Name = "chkaprobar"
        Me.chkaprobar.Size = New System.Drawing.Size(137, 17)
        Me.chkaprobar.TabIndex = 225
        Me.chkaprobar.Text = "APROBAR REGISTRO"
        Me.chkaprobar.UseVisualStyleBackColor = False
        '
        'txtruta
        '
        Appearance49.FontData.BoldAsString = "False"
        Appearance49.ForeColor = System.Drawing.Color.Black
        Appearance49.TextHAlignAsString = "Left"
        Appearance49.TextVAlignAsString = "Middle"
        Me.txtruta.Appearance = Appearance49
        Me.txtruta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtruta.Location = New System.Drawing.Point(737, 190)
        Me.txtruta.MaxLength = 100
        Me.txtruta.Name = "txtruta"
        Me.txtruta.ReadOnly = True
        Me.txtruta.Size = New System.Drawing.Size(119, 21)
        Me.txtruta.TabIndex = 224
        Me.txtruta.TabStop = False
        Me.txtruta.Visible = False
        '
        'chkcontratista
        '
        Me.chkcontratista.AutoSize = True
        Me.chkcontratista.BackColor = System.Drawing.Color.Transparent
        Me.chkcontratista.Location = New System.Drawing.Point(78, 103)
        Me.chkcontratista.Name = "chkcontratista"
        Me.chkcontratista.Size = New System.Drawing.Size(76, 17)
        Me.chkcontratista.TabIndex = 223
        Me.chkcontratista.Text = "Contratista"
        Me.chkcontratista.UseVisualStyleBackColor = False
        '
        'UltraLabel6
        '
        Appearance92.BackColor = System.Drawing.Color.Transparent
        Appearance92.TextHAlignAsString = "Right"
        Me.UltraLabel6.Appearance = Appearance92
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel6.Location = New System.Drawing.Point(23, 78)
        Me.UltraLabel6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(48, 16)
        Me.UltraLabel6.TabIndex = 214
        Me.UltraLabel6.Text = "Periodo"
        '
        'cmbperiodo
        '
        Me.cmbperiodo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbperiodo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem1.DataValue = "1"
        ValueListItem1.DisplayText = "1ERA QUINCENA"
        ValueListItem2.DataValue = "2"
        ValueListItem2.DisplayText = "2DA QUINCENA"
        Me.cmbperiodo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.cmbperiodo.Location = New System.Drawing.Point(78, 76)
        Me.cmbperiodo.Name = "cmbperiodo"
        Me.cmbperiodo.Size = New System.Drawing.Size(150, 21)
        Me.cmbperiodo.TabIndex = 213
        '
        'txtcanteraori
        '
        Appearance6.FontData.BoldAsString = "False"
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.TextHAlignAsString = "Left"
        Appearance6.TextVAlignAsString = "Middle"
        Me.txtcanteraori.Appearance = Appearance6
        Me.txtcanteraori.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcanteraori.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcanteraori.Location = New System.Drawing.Point(716, 63)
        Me.txtcanteraori.MaxLength = 100
        Me.txtcanteraori.Name = "txtcanteraori"
        Me.txtcanteraori.ReadOnly = True
        Me.txtcanteraori.Size = New System.Drawing.Size(89, 21)
        Me.txtcanteraori.TabIndex = 208
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
        Me.txtcodcanteraori.Location = New System.Drawing.Point(716, 36)
        Me.txtcodcanteraori.MaxLength = 100
        Me.txtcodcanteraori.Name = "txtcodcanteraori"
        Me.txtcodcanteraori.ReadOnly = True
        Me.txtcodcanteraori.Size = New System.Drawing.Size(82, 21)
        Me.txtcodcanteraori.TabIndex = 207
        Me.txtcodcanteraori.TabStop = False
        Me.txtcodcanteraori.Visible = False
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
        Me.txtid.Location = New System.Drawing.Point(716, 93)
        Me.txtid.MaxLength = 100
        Me.txtid.Name = "txtid"
        Me.txtid.ReadOnly = True
        Me.txtid.Size = New System.Drawing.Size(49, 21)
        Me.txtid.TabIndex = 206
        Me.txtid.TabStop = False
        Me.txtid.Text = "0"
        Me.txtid.Visible = False
        '
        'gridDetalle
        '
        Me.gridDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance44.BackColor = System.Drawing.SystemColors.Window
        Appearance44.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridDetalle.DisplayLayout.Appearance = Appearance44
        Me.gridDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn26.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance85.Image = CType(resources.GetObject("Appearance85.Image"), Object)
        Appearance85.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance85.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn26.Header.Appearance = Appearance85
        UltraGridColumn26.Header.Caption = ""
        UltraGridColumn26.Header.VisiblePosition = 0
        UltraGridColumn26.Hidden = True
        UltraGridColumn26.MaxWidth = 25
        UltraGridColumn26.MinWidth = 20
        UltraGridColumn26.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn26.Width = 20
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn27.Header.Caption = "CODIGO"
        UltraGridColumn27.Header.VisiblePosition = 1
        UltraGridColumn27.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn27.Width = 30
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn28.Header.VisiblePosition = 3
        UltraGridColumn28.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn28.Width = 66
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn29.Header.VisiblePosition = 4
        UltraGridColumn29.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn29.Width = 65
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn30.Header.VisiblePosition = 5
        UltraGridColumn30.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn30.Width = 70
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance48.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance48
        UltraGridColumn31.Header.VisiblePosition = 6
        UltraGridColumn31.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn31.Width = 65
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance41.TextHAlignAsString = "Right"
        UltraGridColumn32.CellAppearance = Appearance41
        UltraGridColumn32.Header.VisiblePosition = 7
        UltraGridColumn32.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn32.Width = 68
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance42.TextHAlignAsString = "Right"
        UltraGridColumn33.CellAppearance = Appearance42
        UltraGridColumn33.Header.Caption = "G / H"
        UltraGridColumn33.Header.VisiblePosition = 8
        UltraGridColumn33.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn33.Width = 60
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn34.Header.VisiblePosition = 9
        UltraGridColumn34.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn34.Width = 99
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn35.Header.VisiblePosition = 10
        UltraGridColumn35.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn35.Width = 120
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn36.Header.VisiblePosition = 2
        UltraGridColumn36.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn36.Width = 145
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36})
        SummarySettings8.DisplayFormat = "Totales"
        SummarySettings8.GroupBySummaryValueAppearance = Appearance10
        Appearance12.TextHAlignAsString = "Right"
        SummarySettings9.Appearance = Appearance12
        SummarySettings9.DisplayFormat = "{0:##0.00}"
        SummarySettings9.GroupBySummaryValueAppearance = Appearance19
        Appearance90.TextHAlignAsString = "Right"
        SummarySettings10.Appearance = Appearance90
        SummarySettings10.DisplayFormat = " {0:##0.00}"
        SummarySettings10.GroupBySummaryValueAppearance = Appearance45
        Appearance91.TextHAlignAsString = "Right"
        SummarySettings11.Appearance = Appearance91
        SummarySettings11.DisplayFormat = "{0:##0.00}"
        SummarySettings11.GroupBySummaryValueAppearance = Appearance46
        UltraGridBand3.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings8, SummarySettings9, SummarySettings10, SummarySettings11})
        UltraGridBand3.SummaryFooterCaption = ""
        Me.gridDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.gridDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion27)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion28)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion29)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion30)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion31)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion32)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion33)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion34)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion35)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion36)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion37)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion38)
        Me.gridDetalle.DisplayLayout.ColScrollRegions.Add(ColScrollRegion39)
        Me.gridDetalle.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance28.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance28.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDetalle.DisplayLayout.GroupByBox.Appearance = Appearance28
        Appearance50.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance50
        Me.gridDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDetalle.DisplayLayout.GroupByBox.Hidden = True
        Appearance51.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance51.BackColor2 = System.Drawing.SystemColors.Control
        Appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance51
        Me.gridDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.gridDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance52.BackColor = System.Drawing.SystemColors.Window
        Me.gridDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance52
        Appearance53.BorderColor = System.Drawing.Color.Silver
        Appearance53.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridDetalle.DisplayLayout.Override.CellAppearance = Appearance53
        Me.gridDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridDetalle.DisplayLayout.Override.CellPadding = 0
        Me.gridDetalle.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridDetalle.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridDetalle.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridDetalle.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance54.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance54.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridDetalle.DisplayLayout.Override.FilterRowAppearance = Appearance54
        Me.gridDetalle.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridDetalle.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance31.BackColor = System.Drawing.SystemColors.Control
        Appearance31.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance31.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance31.BorderColor = System.Drawing.SystemColors.Window
        Me.gridDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance31
        Appearance83.FontData.Name = "Arial Narrow"
        Appearance83.FontData.SizeInPoints = 10.0!
        Appearance83.TextHAlignAsString = "Left"
        Me.gridDetalle.DisplayLayout.Override.HeaderAppearance = Appearance83
        Me.gridDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridDetalle.DisplayLayout.Override.MinRowHeight = 24
        Appearance60.BackColor = System.Drawing.SystemColors.Window
        Appearance60.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance60.TextVAlignAsString = "Middle"
        Me.gridDetalle.DisplayLayout.Override.RowAppearance = Appearance60
        Me.gridDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridDetalle.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridDetalle.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance39.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance39
        Me.gridDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridDetalle.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridDetalle.Location = New System.Drawing.Point(15, 235)
        Me.gridDetalle.Name = "gridDetalle"
        Me.gridDetalle.Size = New System.Drawing.Size(845, 205)
        Me.gridDetalle.TabIndex = 191
        Me.gridDetalle.Text = "UltraGrid1"
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(78, 154)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(150, 20)
        Me.btnImportar.TabIndex = 165
        Me.btnImportar.Text = "Importar Datos"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'UltraLabel15
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.TextHAlignAsString = "Right"
        Me.UltraLabel15.Appearance = Appearance13
        Me.UltraLabel15.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel15.Location = New System.Drawing.Point(43, 15)
        Me.UltraLabel15.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel15.Name = "UltraLabel15"
        Me.UltraLabel15.Size = New System.Drawing.Size(27, 16)
        Me.UltraLabel15.TabIndex = 164
        Me.UltraLabel15.Text = "Año"
        '
        'cmbMes
        '
        Me.cmbMes.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbMes.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem15.DataValue = "1"
        ValueListItem15.DisplayText = "ENERO"
        ValueListItem16.DataValue = "2"
        ValueListItem16.DisplayText = "FEBRERO"
        ValueListItem17.DataValue = "3"
        ValueListItem17.DisplayText = "MARZO"
        ValueListItem18.DataValue = "4"
        ValueListItem18.DisplayText = "ABRIL"
        ValueListItem19.DataValue = "5"
        ValueListItem19.DisplayText = "MAYO"
        ValueListItem20.DataValue = "6"
        ValueListItem20.DisplayText = "JUNIO"
        ValueListItem21.DataValue = "7"
        ValueListItem21.DisplayText = "JULIO"
        ValueListItem22.DataValue = "8"
        ValueListItem22.DisplayText = "AGOSTO"
        ValueListItem23.DataValue = "9"
        ValueListItem23.DisplayText = "SETIEMBRE"
        ValueListItem24.DataValue = "10"
        ValueListItem24.DisplayText = "OCTUBRE"
        ValueListItem25.DataValue = "11"
        ValueListItem25.DisplayText = "NOVIEMBRE"
        ValueListItem26.DataValue = "12"
        ValueListItem26.DisplayText = "DICIEMBRE"
        Me.cmbMes.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem15, ValueListItem16, ValueListItem17, ValueListItem18, ValueListItem19, ValueListItem20, ValueListItem21, ValueListItem22, ValueListItem23, ValueListItem24, ValueListItem25, ValueListItem26})
        Me.cmbMes.Location = New System.Drawing.Point(78, 45)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(150, 21)
        Me.cmbMes.TabIndex = 161
        '
        'UltraLabel3
        '
        Appearance87.BackColor = System.Drawing.Color.Transparent
        Appearance87.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance87
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(40, 46)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(35, 17)
        Me.UltraLabel3.TabIndex = 162
        Me.UltraLabel3.Text = "MES :"
        '
        'txtAño
        '
        Me.txtAño.Location = New System.Drawing.Point(78, 14)
        Me.txtAño.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtAño.Name = "txtAño"
        Me.txtAño.Size = New System.Drawing.Size(84, 20)
        Me.txtAño.TabIndex = 163
        Me.txtAño.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'dtfin
        '
        Me.dtfin.AutoSize = False
        Me.dtfin.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtfin.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtfin.Location = New System.Drawing.Point(494, 48)
        Me.dtfin.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtfin.Name = "dtfin"
        Me.dtfin.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtfin.ReadOnly = True
        Me.dtfin.Size = New System.Drawing.Size(91, 21)
        Me.dtfin.TabIndex = 218
        Me.dtfin.TabStop = False
        Me.dtfin.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'dtinicio
        '
        Me.dtinicio.AutoSize = False
        Me.dtinicio.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtinicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtinicio.Location = New System.Drawing.Point(494, 17)
        Me.dtinicio.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtinicio.Name = "dtinicio"
        Me.dtinicio.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtinicio.ReadOnly = True
        Me.dtinicio.Size = New System.Drawing.Size(91, 21)
        Me.dtinicio.TabIndex = 217
        Me.dtinicio.TabStop = False
        Me.dtinicio.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'txtcodequipo
        '
        Appearance47.FontData.BoldAsString = "False"
        Appearance47.ForeColor = System.Drawing.Color.Black
        Appearance47.TextHAlignAsString = "Left"
        Appearance47.TextVAlignAsString = "Middle"
        Me.txtcodequipo.Appearance = Appearance47
        Me.txtcodequipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodequipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodequipo.Location = New System.Drawing.Point(631, 17)
        Me.txtcodequipo.MaxLength = 100
        Me.txtcodequipo.Name = "txtcodequipo"
        Me.txtcodequipo.ReadOnly = True
        Me.txtcodequipo.Size = New System.Drawing.Size(82, 21)
        Me.txtcodequipo.TabIndex = 212
        Me.txtcodequipo.TabStop = False
        Me.txtcodequipo.Visible = False
        '
        'txtcodcliente
        '
        Appearance84.FontData.BoldAsString = "False"
        Appearance84.ForeColor = System.Drawing.Color.Black
        Appearance84.TextHAlignAsString = "Left"
        Appearance84.TextVAlignAsString = "Middle"
        Me.txtcodcliente.Appearance = Appearance84
        Me.txtcodcliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodcliente.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtcodcliente.Location = New System.Drawing.Point(631, 42)
        Me.txtcodcliente.MaxLength = 100
        Me.txtcodcliente.Name = "txtcodcliente"
        Me.txtcodcliente.ReadOnly = True
        Me.txtcodcliente.Size = New System.Drawing.Size(82, 21)
        Me.txtcodcliente.TabIndex = 211
        Me.txtcodcliente.TabStop = False
        Me.txtcodcliente.Visible = False
        '
        'UltraLabel1
        '
        Appearance114.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance114
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(448, 49)
        Me.UltraLabel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(34, 17)
        Me.UltraLabel1.TabIndex = 220
        Me.UltraLabel1.Text = "Hasta"
        '
        'UltraLabel4
        '
        Appearance86.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel4.Appearance = Appearance86
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel4.Location = New System.Drawing.Point(445, 17)
        Me.UltraLabel4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(37, 17)
        Me.UltraLabel4.TabIndex = 219
        Me.UltraLabel4.Text = "Desde"
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
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
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
        Me.Tab1.Controls.Add(Me.UltraTabPageControl2)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(869, 513)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance11
        Me.Tab1.TabIndex = 4
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance8.FontData.BoldAsString = "True"
        Appearance8.FontData.Name = "Arial Narrow"
        Appearance8.FontData.SizeInPoints = 16.0!
        UltraTab1.ActiveAppearance = Appearance8
        Appearance43.FontData.Name = "Arial Narrow"
        Appearance43.FontData.SizeInPoints = 10.0!
        UltraTab1.Appearance = Appearance43
        UltraTab1.Key = "T01"
        UltraTab1.TabPage = Me.UltraTabPageControl2
        UltraTab1.Text = "REGISTRO DE ALQUILER DE MAQUINA"
        Appearance24.Cursor = System.Windows.Forms.Cursors.Default
        Appearance24.FontData.BoldAsString = "True"
        Appearance24.FontData.Name = "Arial Narrow"
        Appearance24.FontData.SizeInPoints = 16.0!
        UltraTab3.ActiveAppearance = Appearance24
        Appearance9.FontData.Name = "Arial Narrow"
        Appearance9.FontData.SizeInPoints = 10.0!
        UltraTab3.Appearance = Appearance9
        UltraTab3.Key = "T02"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "IMPORTAR DATOS"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab3})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(865, 475)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'UltraLabel2
        '
        Appearance61.BackColor = System.Drawing.Color.Transparent
        Appearance61.TextHAlignAsString = "Center"
        Appearance61.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance61
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(195, 40)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(34, 14)
        Me.UltraLabel2.TabIndex = 175
        Me.UltraLabel2.Text = "Hasta"
        '
        'dtpHasta
        '
        Me.dtpHasta.AutoSize = False
        Me.dtpHasta.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpHasta.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpHasta.Location = New System.Drawing.Point(235, 38)
        Me.dtpHasta.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpHasta.Size = New System.Drawing.Size(122, 18)
        Me.dtpHasta.TabIndex = 174
        Me.dtpHasta.TabStop = False
        Me.dtpHasta.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'UltraLabel5
        '
        Appearance64.BackColor = System.Drawing.Color.Transparent
        Appearance64.TextHAlignAsString = "Center"
        Appearance64.TextVAlignAsString = "Middle"
        Me.UltraLabel5.Appearance = Appearance64
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(11, 41)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(37, 14)
        Me.UltraLabel5.TabIndex = 173
        Me.UltraLabel5.Text = "Desde"
        '
        'dtpDesde
        '
        Me.dtpDesde.AutoSize = False
        Me.dtpDesde.DateTime = New Date(2011, 3, 1, 0, 0, 0, 0)
        Me.dtpDesde.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtpDesde.Location = New System.Drawing.Point(54, 38)
        Me.dtpDesde.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtpDesde.Size = New System.Drawing.Size(122, 18)
        Me.dtpDesde.TabIndex = 172
        Me.dtpDesde.TabStop = False
        Me.dtpDesde.Value = New Date(2011, 3, 1, 0, 0, 0, 0)
        '
        'gridCarga
        '
        Me.gridCarga.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance65.BackColor = System.Drawing.SystemColors.Window
        Appearance65.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridCarga.DisplayLayout.Appearance = Appearance65
        Me.gridCarga.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn37.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance66.Image = CType(resources.GetObject("Appearance66.Image"), Object)
        Appearance66.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance66.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn37.Header.Appearance = Appearance66
        UltraGridColumn37.Header.Caption = ""
        UltraGridColumn37.Header.VisiblePosition = 0
        UltraGridColumn37.Hidden = True
        UltraGridColumn37.MaxWidth = 25
        UltraGridColumn37.MinWidth = 20
        UltraGridColumn37.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn37.Width = 20
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn38.Header.VisiblePosition = 1
        UltraGridColumn38.Hidden = True
        UltraGridColumn38.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn38.Width = 45
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn39.Header.Caption = "AÑO"
        UltraGridColumn39.Header.VisiblePosition = 2
        UltraGridColumn39.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn39.Width = 33
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn40.Header.VisiblePosition = 3
        UltraGridColumn40.Hidden = True
        UltraGridColumn40.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn40.Width = 47
        UltraGridColumn41.Header.VisiblePosition = 4
        UltraGridColumn41.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn41.Width = 55
        UltraGridColumn42.Header.Caption = "TIPO CARGA"
        UltraGridColumn42.Header.VisiblePosition = 5
        UltraGridColumn42.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn42.Width = 91
        UltraGridColumn43.Header.VisiblePosition = 6
        UltraGridColumn43.Hidden = True
        UltraGridColumn43.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn43.Width = 77
        UltraGridColumn44.Header.VisiblePosition = 7
        UltraGridColumn44.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn44.Width = 166
        UltraGridColumn45.Header.VisiblePosition = 8
        UltraGridColumn45.Hidden = True
        UltraGridColumn45.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn45.Width = 106
        UltraGridColumn46.Header.VisiblePosition = 9
        UltraGridColumn46.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn46.Width = 124
        UltraGridColumn47.Header.Caption = "COD. EQUIPO"
        UltraGridColumn47.Header.VisiblePosition = 10
        UltraGridColumn47.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn47.Width = 59
        UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn48.Header.Caption = "FECHA CARGA"
        UltraGridColumn48.Header.VisiblePosition = 11
        UltraGridColumn48.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn48.Width = 75
        UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn49.Header.VisiblePosition = 12
        UltraGridColumn49.Hidden = True
        UltraGridColumn49.Width = 85
        UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn50.Header.Caption = "PERIODO"
        UltraGridColumn50.Header.VisiblePosition = 13
        UltraGridColumn50.Width = 94
        UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance68.TextHAlignAsString = "Right"
        UltraGridColumn51.CellAppearance = Appearance68
        UltraGridColumn51.Header.VisiblePosition = 14
        UltraGridColumn51.Width = 91
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51})
        SummarySettings12.DisplayFormat = "Total"
        SummarySettings12.GroupBySummaryValueAppearance = Appearance70
        Appearance71.TextHAlignAsString = "Right"
        SummarySettings13.Appearance = Appearance71
        SummarySettings13.DisplayFormat = "{0}"
        SummarySettings13.GroupBySummaryValueAppearance = Appearance72
        UltraGridBand4.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings12, SummarySettings13})
        UltraGridBand4.SummaryFooterCaption = ""
        Me.gridCarga.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.gridCarga.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridCarga.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion40)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion41)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion42)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion43)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion44)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion45)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion46)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion47)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion48)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion49)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion50)
        Me.gridCarga.DisplayLayout.ColScrollRegions.Add(ColScrollRegion51)
        Me.gridCarga.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance73.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance73.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance73.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance73.BorderColor = System.Drawing.SystemColors.Window
        Me.gridCarga.DisplayLayout.GroupByBox.Appearance = Appearance73
        Appearance74.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridCarga.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance74
        Me.gridCarga.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridCarga.DisplayLayout.GroupByBox.Hidden = True
        Appearance75.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance75.BackColor2 = System.Drawing.SystemColors.Control
        Appearance75.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance75.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridCarga.DisplayLayout.GroupByBox.PromptAppearance = Appearance75
        Me.gridCarga.DisplayLayout.MaxColScrollRegions = 1
        Me.gridCarga.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridCarga.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridCarga.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridCarga.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance76.BackColor = System.Drawing.SystemColors.Window
        Me.gridCarga.DisplayLayout.Override.CardAreaAppearance = Appearance76
        Appearance77.BorderColor = System.Drawing.Color.Silver
        Appearance77.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridCarga.DisplayLayout.Override.CellAppearance = Appearance77
        Me.gridCarga.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridCarga.DisplayLayout.Override.CellPadding = 0
        Me.gridCarga.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridCarga.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridCarga.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridCarga.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance78.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance78.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridCarga.DisplayLayout.Override.FilterRowAppearance = Appearance78
        Me.gridCarga.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridCarga.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridCarga.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance79.BackColor = System.Drawing.SystemColors.Control
        Appearance79.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance79.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance79.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance79.BorderColor = System.Drawing.SystemColors.Window
        Me.gridCarga.DisplayLayout.Override.GroupByRowAppearance = Appearance79
        Appearance80.FontData.Name = "Arial Narrow"
        Appearance80.FontData.SizeInPoints = 10.0!
        Appearance80.TextHAlignAsString = "Left"
        Me.gridCarga.DisplayLayout.Override.HeaderAppearance = Appearance80
        Me.gridCarga.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridCarga.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridCarga.DisplayLayout.Override.MinRowHeight = 24
        Appearance81.BackColor = System.Drawing.SystemColors.Window
        Appearance81.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance81.TextVAlignAsString = "Middle"
        Me.gridCarga.DisplayLayout.Override.RowAppearance = Appearance81
        Me.gridCarga.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridCarga.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridCarga.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance82.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridCarga.DisplayLayout.Override.TemplateAddRowAppearance = Appearance82
        Me.gridCarga.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridCarga.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridCarga.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridCarga.Location = New System.Drawing.Point(11, 62)
        Me.gridCarga.Name = "gridCarga"
        Me.gridCarga.Size = New System.Drawing.Size(845, 322)
        Me.gridCarga.TabIndex = 171
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
        UltraStatusPanel2.Control = Me.BindingNavigator2
        UltraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer
        Me.UltraStatusBar2.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel2})
        Me.UltraStatusBar2.Size = New System.Drawing.Size(865, 30)
        Me.UltraStatusBar2.SizeGripVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.UltraStatusBar2.TabIndex = 151
        Me.UltraStatusBar2.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007
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
        'FrmRegAlqMaquina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 513)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmRegAlqMaquina"
        Me.Text = "FrmRegAlqMaquina"
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.dtpFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpIni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraStatusBar1.ResumeLayout(False)
        Me.UltraStatusBar1.PerformLayout()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.txtimporteNC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtobservacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtproveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodprov, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtruta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbperiodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcanteraori, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodcanteraori, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtfin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtinicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodequipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcodcliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator2.ResumeLayout(False)
        Me.BindingNavigator2.PerformLayout()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        CType(Me.dtpHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridCarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraStatusBar2.ResumeLayout(False)
        Me.UltraStatusBar2.PerformLayout()
        CType(Me.Source1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Source2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Source1 As System.Windows.Forms.BindingSource
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtfin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dtinicio As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbperiodo As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblmensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtcodequipo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcodcliente As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcanteraori As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcodcanteraori As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtid As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents gridDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents UltraLabel15 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbMes As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtAño As System.Windows.Forms.NumericUpDown
    Friend WithEvents gridFactura As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chkcontratista As System.Windows.Forms.CheckBox
    Friend WithEvents txtruta As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents chkaprobar As System.Windows.Forms.CheckBox
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpHasta As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
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
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpFin As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtpIni As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents gridData As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtproveedor As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtcodprov As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Source2 As System.Windows.Forms.BindingSource
    Friend WithEvents txtobservacion As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtimporteNC As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents chkNC As System.Windows.Forms.CheckBox
End Class
