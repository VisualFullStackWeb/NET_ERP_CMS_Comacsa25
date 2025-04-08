<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAprobacionOC
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
        Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton
        Dim DateButton2 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance166 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance170 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance171 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim Appearance172 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance173 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Area")
        Dim Appearance174 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance175 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Proveedor")
        Dim Appearance176 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance177 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda")
        Dim Appearance187 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance188 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim Appearance189 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance190 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOC")
        Dim Appearance191 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance192 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
        Dim Appearance193 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UserCrea")
        Dim Appearance194 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance195 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoArea")
        Dim Appearance196 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Action")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Area")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Proveedor")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Moneda")
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Importe")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroOC")
        Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoProveedor")
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UserCrea")
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoArea")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance122 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Proveedor")
        Dim Appearance197 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance198 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda")
        Dim Appearance199 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance200 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim Appearance202 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance203 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioMonedaOC")
        Dim Appearance204 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance205 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance206 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance207 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance208 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance209 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOC")
        Dim Appearance210 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance211 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
        Dim Appearance212 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance151 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance152 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance153 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance154 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance155 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance156 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Proveedor")
        Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Moneda")
        Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Precio")
        Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioMonedaOC")
        Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroOC")
        Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoProveedor")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance107 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance108 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAprobacionOC))
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance185 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance140 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance109 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Item")
        Dim Appearance213 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance214 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance215 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim Appearance216 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance217 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UM")
        Dim Appearance218 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance219 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance220 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance221 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda")
        Dim Appearance222 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance223 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim Appearance224 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance225 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descuento")
        Dim Appearance226 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance227 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim Appearance228 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance229 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance133 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance134 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance135 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance136 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance137 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance138 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Item")
        Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Descripcion")
        Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UM")
        Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Moneda")
        Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Precio")
        Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Descuento")
        Dim UltraDataColumn28 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Importe")
        Dim Appearance186 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Proveedor")
        Dim Appearance230 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance231 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Marca")
        Dim Appearance232 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance233 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance234 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance235 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPago")
        Dim Appearance236 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance237 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UM")
        Dim Appearance238 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance239 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Moneda")
        Dim Appearance240 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance241 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCotizacion")
        Dim Appearance242 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance243 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim Appearance244 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance245 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GenerarOC")
        Dim Appearance246 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance247 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroCotizacion")
        Dim Appearance248 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance249 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCotizacion")
        Dim Appearance250 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance251 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Equivalencia")
        Dim Appearance252 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance253 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance254 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance255 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance256 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance257 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance258 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance259 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn29 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Proveedor")
        Dim UltraDataColumn30 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Marca")
        Dim UltraDataColumn31 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn32 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FormaPago")
        Dim UltraDataColumn33 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UM")
        Dim UltraDataColumn34 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Moneda")
        Dim UltraDataColumn35 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioCotizacion")
        Dim UltraDataColumn36 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Precio")
        Dim UltraDataColumn37 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("GenerarOC")
        Dim UltraDataColumn38 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroCotizacion")
        Dim UltraDataColumn39 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaCotizacion")
        Dim UltraDataColumn40 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Equivalencia")
        Dim Appearance163 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance139 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance167 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance168 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance164 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Area")
        Dim Appearance260 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance261 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Requisicion")
        Dim Appearance262 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance263 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UM")
        Dim Appearance264 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance265 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadAtender")
        Dim Appearance266 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance267 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadComprar")
        Dim Appearance268 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance269 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadAtendidaTemporal")
        Dim Appearance270 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance271 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Marca")
        Dim Appearance272 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance273 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim Appearance274 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance275 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Proveedor")
        Dim Appearance276 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance277 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance104 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance117 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance118 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance120 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn41 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Area")
        Dim UltraDataColumn42 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Requisicion")
        Dim UltraDataColumn43 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UM")
        Dim UltraDataColumn44 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CantidadAtender")
        Dim UltraDataColumn45 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CantidadComprar")
        Dim UltraDataColumn46 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CantidadAtendidaTemporal")
        Dim UltraDataColumn47 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Marca")
        Dim UltraDataColumn48 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Observacion")
        Dim UltraDataColumn49 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Proveedor")
        Dim Appearance201 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance169 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand6 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance278 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance279 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim Appearance280 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance281 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UM")
        Dim Appearance282 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance283 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance284 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance285 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance178 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance179 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance180 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance181 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance182 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance183 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraDataColumn50 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Codigo")
        Dim UltraDataColumn51 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Descripcion")
        Dim UltraDataColumn52 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UM")
        Dim UltraDataColumn53 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim Appearance132 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand7 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Codigo")
        Dim Appearance286 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance287 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
        Dim Appearance288 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance289 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UM")
        Dim Appearance290 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance291 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance292 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance293 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance149 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance150 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance157 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance158 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance159 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance160 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance184 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraDataColumn54 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Proveedor")
        Dim UltraDataColumn55 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Marca")
        Dim UltraDataColumn56 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn57 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FormaPago")
        Dim UltraDataColumn58 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("UM")
        Dim UltraDataColumn59 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Moneda")
        Dim UltraDataColumn60 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioCotizacion")
        Dim UltraDataColumn61 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Precio")
        Dim UltraDataColumn62 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("GenerarOC")
        Dim UltraDataColumn63 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroCotizacion")
        Dim UltraDataColumn64 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaCotizacion")
        Dim UltraDataColumn65 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Equivalencia")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.DtFin = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
        Me.DtInicio = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
        Me.RbAnularOC = New System.Windows.Forms.RadioButton
        Me.RbAprobacionOC = New System.Windows.Forms.RadioButton
        Me.dgvOC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.ChkTodos = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel
        Me.LblMensaje = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.dtFechaOC = New System.Windows.Forms.DateTimePicker
        Me.GrpTopMejores = New Infragistics.Win.Misc.UltraGroupBox
        Me.dgvMejoresProveedores = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource3 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.LblPrecioOC = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel17 = New Infragistics.Win.Misc.UltraLabel
        Me.LblUM = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel19 = New Infragistics.Win.Misc.UltraLabel
        Me.LblMonedaOC = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel15 = New Infragistics.Win.Misc.UltraLabel
        Me.LblCodigo = New Infragistics.Win.Misc.UltraLabel
        Me.LblProducto = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.btnSalir = New Infragistics.Win.Misc.UltraButton
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.LblImporte = New Infragistics.Win.Misc.UltraLabel
        Me.LblMoneda = New Infragistics.Win.Misc.UltraLabel
        Me.LblOC = New Infragistics.Win.Misc.UltraLabel
        Me.LblProveedor = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.dgvDetalleOC = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.GrpCuadorComparativo = New Infragistics.Win.Misc.UltraGroupBox
        Me.UltraGroupBox5 = New Infragistics.Win.Misc.UltraGroupBox
        Me.dgvAnalisisComparativo = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource6 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraLabel23 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraGroupBox4 = New Infragistics.Win.Misc.UltraGroupBox
        Me.LblRazonSocial = New Infragistics.Win.Misc.UltraLabel
        Me.LblPrecioUltimaCompra = New Infragistics.Win.Misc.UltraLabel
        Me.lblMonedaCuadro = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel18 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel16 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraGroupBox3 = New Infragistics.Win.Misc.UltraGroupBox
        Me.dgvDetalleRequerimiento = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource5 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraGroupBox2 = New Infragistics.Win.Misc.UltraGroupBox
        Me.dgvArticulosComparadosXproducto = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraDataSource4 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.dgvArticulosComparados = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.TabAprobacionOC = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraDataSource8 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.Cia1 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.DtFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.GrpTopMejores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpTopMejores.SuspendLayout()
        CType(Me.dgvMejoresProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalleOC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl4.SuspendLayout()
        CType(Me.GrpCuadorComparativo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCuadorComparativo.SuspendLayout()
        CType(Me.UltraGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox5.SuspendLayout()
        CType(Me.dgvAnalisisComparativo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox4.SuspendLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox3.SuspendLayout()
        CType(Me.dgvDetalleRequerimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox2.SuspendLayout()
        CType(Me.dgvArticulosComparadosXproducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvArticulosComparados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabAprobacionOC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabAprobacionOC.SuspendLayout()
        CType(Me.UltraDataSource8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cia1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.Cia1)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel2)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel1)
        Me.UltraTabPageControl1.Controls.Add(Me.DtFin)
        Me.UltraTabPageControl1.Controls.Add(Me.DtInicio)
        Me.UltraTabPageControl1.Controls.Add(Me.RbAnularOC)
        Me.UltraTabPageControl1.Controls.Add(Me.RbAprobacionOC)
        Me.UltraTabPageControl1.Controls.Add(Me.dgvOC)
        Me.UltraTabPageControl1.Controls.Add(Me.ChkTodos)
        Me.UltraTabPageControl1.Controls.Add(Me.UltraLabel14)
        Me.UltraTabPageControl1.Controls.Add(Me.LblMensaje)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 27)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(812, 464)
        '
        'UltraLabel2
        '
        Me.UltraLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Location = New System.Drawing.Point(650, 10)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(40, 14)
        Me.UltraLabel2.TabIndex = 139
        Me.UltraLabel2.Text = "Hasta :"
        '
        'UltraLabel1
        '
        Me.UltraLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Location = New System.Drawing.Point(465, 10)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(43, 14)
        Me.UltraLabel1.TabIndex = 138
        Me.UltraLabel1.Text = "Desde :"
        '
        'DtFin
        '
        Me.DtFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtFin.BackColor = System.Drawing.SystemColors.Window
        Me.DtFin.DateButtons.Add(DateButton1)
        Me.DtFin.Location = New System.Drawing.Point(700, 10)
        Me.DtFin.Name = "DtFin"
        Me.DtFin.NonAutoSizeHeight = 21
        Me.DtFin.Size = New System.Drawing.Size(105, 21)
        Me.DtFin.SpinButtonsVisible = True
        Me.DtFin.TabIndex = 137
        Me.DtFin.Value = "11/02/2011 11:59:59 pm"
        '
        'DtInicio
        '
        Me.DtInicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtInicio.BackColor = System.Drawing.SystemColors.Window
        Me.DtInicio.DateButtons.Add(DateButton2)
        Me.DtInicio.Location = New System.Drawing.Point(510, 10)
        Me.DtInicio.Name = "DtInicio"
        Me.DtInicio.NonAutoSizeHeight = 21
        Me.DtInicio.Size = New System.Drawing.Size(106, 21)
        Me.DtInicio.SpinButtonsVisible = True
        Me.DtInicio.TabIndex = 136
        Me.DtInicio.Value = "11/02/2011 12:00:00 am"
        '
        'RbAnularOC
        '
        Me.RbAnularOC.AutoSize = True
        Me.RbAnularOC.BackColor = System.Drawing.Color.Transparent
        Me.RbAnularOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbAnularOC.Location = New System.Drawing.Point(140, 43)
        Me.RbAnularOC.Name = "RbAnularOC"
        Me.RbAnularOC.Size = New System.Drawing.Size(162, 19)
        Me.RbAnularOC.TabIndex = 135
        Me.RbAnularOC.TabStop = True
        Me.RbAnularOC.Text = "Anular Aprobación de OC"
        Me.RbAnularOC.UseVisualStyleBackColor = False
        '
        'RbAprobacionOC
        '
        Me.RbAprobacionOC.AutoSize = True
        Me.RbAprobacionOC.BackColor = System.Drawing.Color.Transparent
        Me.RbAprobacionOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbAprobacionOC.Location = New System.Drawing.Point(10, 43)
        Me.RbAprobacionOC.Name = "RbAprobacionOC"
        Me.RbAprobacionOC.Size = New System.Drawing.Size(124, 19)
        Me.RbAprobacionOC.TabIndex = 134
        Me.RbAprobacionOC.TabStop = True
        Me.RbAprobacionOC.Text = "Aprobación de OC"
        Me.RbAprobacionOC.UseVisualStyleBackColor = False
        '
        'dgvOC
        '
        Me.dgvOC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOC.DataSource = Me.UltraDataSource1
        Appearance32.BackColor = System.Drawing.Color.White
        Me.dgvOC.DisplayLayout.Appearance = Appearance32
        Me.dgvOC.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        Appearance166.FontData.BoldAsString = "False"
        Appearance166.FontData.SizeInPoints = 8.0!
        UltraGridColumn1.Header.Appearance = Appearance166
        UltraGridColumn1.Header.Caption = "Aprobar"
        UltraGridColumn1.Header.VisiblePosition = 7
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 76
        UltraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance170.FontData.BoldAsString = "False"
        Appearance170.FontData.SizeInPoints = 8.0!
        Appearance170.TextHAlignAsString = "Center"
        Appearance170.TextVAlignAsString = "Middle"
        UltraGridColumn2.CellAppearance = Appearance170
        Appearance171.FontData.BoldAsString = "False"
        Appearance171.FontData.SizeInPoints = 8.0!
        UltraGridColumn2.Header.Appearance = Appearance171
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 79
        UltraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance172.FontData.BoldAsString = "False"
        Appearance172.FontData.SizeInPoints = 8.0!
        UltraGridColumn3.CellAppearance = Appearance172
        Appearance173.FontData.BoldAsString = "False"
        Appearance173.FontData.SizeInPoints = 8.0!
        UltraGridColumn3.Header.Appearance = Appearance173
        UltraGridColumn3.Header.VisiblePosition = 8
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 72
        UltraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance174.FontData.BoldAsString = "False"
        Appearance174.FontData.SizeInPoints = 8.0!
        Appearance174.TextHAlignAsString = "Center"
        Appearance174.TextVAlignAsString = "Middle"
        UltraGridColumn4.CellAppearance = Appearance174
        UltraGridColumn4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance175.FontData.BoldAsString = "False"
        Appearance175.FontData.SizeInPoints = 8.0!
        UltraGridColumn4.Header.Appearance = Appearance175
        UltraGridColumn4.Header.VisiblePosition = 2
        UltraGridColumn4.Width = 127
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance176.FontData.BoldAsString = "False"
        Appearance176.FontData.SizeInPoints = 8.0!
        Appearance176.TextHAlignAsString = "Center"
        Appearance176.TextVAlignAsString = "Middle"
        UltraGridColumn5.CellAppearance = Appearance176
        UltraGridColumn5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance177.FontData.BoldAsString = "False"
        Appearance177.FontData.SizeInPoints = 8.0!
        UltraGridColumn5.Header.Appearance = Appearance177
        UltraGridColumn5.Header.VisiblePosition = 3
        UltraGridColumn5.Width = 131
        UltraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance187.FontData.BoldAsString = "False"
        Appearance187.FontData.SizeInPoints = 8.0!
        Appearance187.TextHAlignAsString = "Center"
        Appearance187.TextVAlignAsString = "Middle"
        UltraGridColumn6.CellAppearance = Appearance187
        Appearance188.FontData.BoldAsString = "False"
        Appearance188.FontData.SizeInPoints = 8.0!
        UltraGridColumn6.Header.Appearance = Appearance188
        UltraGridColumn6.Header.VisiblePosition = 4
        UltraGridColumn6.Width = 67
        UltraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance189.FontData.BoldAsString = "False"
        Appearance189.FontData.SizeInPoints = 8.0!
        Appearance189.TextHAlignAsString = "Right"
        Appearance189.TextVAlignAsString = "Middle"
        UltraGridColumn7.CellAppearance = Appearance189
        UltraGridColumn7.Format = "n4"
        Appearance190.FontData.BoldAsString = "False"
        Appearance190.FontData.SizeInPoints = 8.0!
        UltraGridColumn7.Header.Appearance = Appearance190
        UltraGridColumn7.Header.VisiblePosition = 5
        UltraGridColumn7.Width = 94
        UltraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance191.FontData.BoldAsString = "False"
        Appearance191.FontData.SizeInPoints = 8.0!
        Appearance191.TextHAlignAsString = "Center"
        Appearance191.TextVAlignAsString = "Middle"
        UltraGridColumn8.CellAppearance = Appearance191
        Appearance192.FontData.BoldAsString = "False"
        Appearance192.FontData.SizeInPoints = 8.0!
        UltraGridColumn8.Header.Appearance = Appearance192
        UltraGridColumn8.Header.Caption = "Nro OC"
        UltraGridColumn8.Header.VisiblePosition = 0
        UltraGridColumn8.Width = 79
        UltraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance193.FontData.BoldAsString = "False"
        Appearance193.FontData.SizeInPoints = 8.0!
        UltraGridColumn9.Header.Appearance = Appearance193
        UltraGridColumn9.Header.VisiblePosition = 9
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 99
        UltraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance194.FontData.BoldAsString = "False"
        Appearance194.FontData.SizeInPoints = 8.0!
        Appearance194.TextHAlignAsString = "Center"
        Appearance194.TextVAlignAsString = "Middle"
        UltraGridColumn10.CellAppearance = Appearance194
        UltraGridColumn10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance195.FontData.BoldAsString = "False"
        Appearance195.FontData.SizeInPoints = 8.0!
        UltraGridColumn10.Header.Appearance = Appearance195
        UltraGridColumn10.Header.Caption = "User Crea"
        UltraGridColumn10.Header.VisiblePosition = 6
        UltraGridColumn10.Width = 99
        UltraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance196.FontData.BoldAsString = "False"
        Appearance196.FontData.SizeInPoints = 8.0!
        UltraGridColumn11.Header.Appearance = Appearance196
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.Width = 99
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11})
        Me.dgvOC.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.dgvOC.DisplayLayout.InterBandSpacing = 18
        Me.dgvOC.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvOC.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Appearance91.BackColor = System.Drawing.Color.Transparent
        Me.dgvOC.DisplayLayout.Override.CardAreaAppearance = Appearance91
        Appearance92.FontData.BoldAsString = "True"
        Appearance92.FontData.SizeInPoints = 9.0!
        Appearance92.ForeColor = System.Drawing.Color.Navy
        Me.dgvOC.DisplayLayout.Override.CellAppearance = Appearance92
        Me.dgvOC.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance93.BackColor = System.Drawing.Color.Navy
        Appearance93.FontData.BoldAsString = "True"
        Appearance93.FontData.ItalicAsString = "False"
        Appearance93.FontData.SizeInPoints = 10.0!
        Appearance93.ForeColor = System.Drawing.Color.White
        Appearance93.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvOC.DisplayLayout.Override.HeaderAppearance = Appearance93
        Appearance94.TextHAlignAsString = "Center"
        Appearance94.TextVAlignAsString = "Middle"
        Me.dgvOC.DisplayLayout.Override.RowPreviewAppearance = Appearance94
        Appearance95.BackColor = System.Drawing.Color.Navy
        Appearance95.BorderColor = System.Drawing.Color.White
        Appearance95.FontData.BoldAsString = "True"
        Appearance95.ForeColor = System.Drawing.Color.White
        Appearance95.TextHAlignAsString = "Center"
        Appearance95.TextVAlignAsString = "Middle"
        Me.dgvOC.DisplayLayout.Override.RowSelectorAppearance = Appearance95
        Me.dgvOC.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.dgvOC.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvOC.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance97.BackColor = System.Drawing.Color.Navy
        Appearance97.ForeColor = System.Drawing.Color.White
        Me.dgvOC.DisplayLayout.Override.SelectedRowAppearance = Appearance97
        Me.dgvOC.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvOC.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvOC.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvOC.Location = New System.Drawing.Point(10, 75)
        Me.dgvOC.Name = "dgvOC"
        Me.dgvOC.Size = New System.Drawing.Size(793, 380)
        Me.dgvOC.TabIndex = 132
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11})
        '
        'ChkTodos
        '
        Me.ChkTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance19.FontData.SizeInPoints = 9.0!
        Me.ChkTodos.Appearance = Appearance19
        Me.ChkTodos.BackColor = System.Drawing.Color.Transparent
        Me.ChkTodos.BackColorInternal = System.Drawing.Color.Transparent
        Me.ChkTodos.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.ChkTodos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkTodos.Location = New System.Drawing.Point(705, 43)
        Me.ChkTodos.Name = "ChkTodos"
        Me.ChkTodos.Size = New System.Drawing.Size(98, 20)
        Me.ChkTodos.TabIndex = 78
        Me.ChkTodos.Text = "Marcar Todos"
        '
        'UltraLabel14
        '
        Me.UltraLabel14.AutoSize = True
        Me.UltraLabel14.Location = New System.Drawing.Point(10, 10)
        Me.UltraLabel14.Name = "UltraLabel14"
        Me.UltraLabel14.Size = New System.Drawing.Size(49, 14)
        Me.UltraLabel14.TabIndex = 76
        Me.UltraLabel14.Text = "Empresa"
        '
        'LblMensaje
        '
        Me.LblMensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance98.BackColor = System.Drawing.SystemColors.ActiveCaption
        Appearance98.ForeColor = System.Drawing.Color.White
        Appearance98.TextHAlignAsString = "Center"
        Appearance98.TextVAlignAsString = "Middle"
        Me.LblMensaje.Appearance = Appearance98
        Me.LblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMensaje.Location = New System.Drawing.Point(0, 40)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(812, 25)
        Me.LblMensaje.TabIndex = 133
        Me.LblMensaje.Text = "                              APROBACIÓN DE OC"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.dtFechaOC)
        Me.UltraTabPageControl3.Controls.Add(Me.GrpTopMejores)
        Me.UltraTabPageControl3.Controls.Add(Me.LblImporte)
        Me.UltraTabPageControl3.Controls.Add(Me.LblMoneda)
        Me.UltraTabPageControl3.Controls.Add(Me.LblOC)
        Me.UltraTabPageControl3.Controls.Add(Me.LblProveedor)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel7)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel6)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel5)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel4)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel3)
        Me.UltraTabPageControl3.Controls.Add(Me.dgvDetalleOC)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(812, 464)
        '
        'dtFechaOC
        '
        Me.dtFechaOC.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaOC.Location = New System.Drawing.Point(641, 13)
        Me.dtFechaOC.Name = "dtFechaOC"
        Me.dtFechaOC.Size = New System.Drawing.Size(98, 20)
        Me.dtFechaOC.TabIndex = 135
        '
        'GrpTopMejores
        '
        Me.GrpTopMejores.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
        Me.GrpTopMejores.Controls.Add(Me.dgvMejoresProveedores)
        Me.GrpTopMejores.Controls.Add(Me.LblPrecioOC)
        Me.GrpTopMejores.Controls.Add(Me.UltraLabel17)
        Me.GrpTopMejores.Controls.Add(Me.LblUM)
        Me.GrpTopMejores.Controls.Add(Me.UltraLabel19)
        Me.GrpTopMejores.Controls.Add(Me.LblMonedaOC)
        Me.GrpTopMejores.Controls.Add(Me.UltraLabel15)
        Me.GrpTopMejores.Controls.Add(Me.LblCodigo)
        Me.GrpTopMejores.Controls.Add(Me.LblProducto)
        Me.GrpTopMejores.Controls.Add(Me.UltraLabel11)
        Me.GrpTopMejores.Controls.Add(Me.UltraLabel12)
        Me.GrpTopMejores.Controls.Add(Me.btnSalir)
        Me.GrpTopMejores.Controls.Add(Me.UltraLabel8)
        Me.GrpTopMejores.Location = New System.Drawing.Point(134, 85)
        Me.GrpTopMejores.Name = "GrpTopMejores"
        Me.GrpTopMejores.Size = New System.Drawing.Size(586, 372)
        Me.GrpTopMejores.TabIndex = 134
        Me.GrpTopMejores.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        Me.GrpTopMejores.Visible = False
        '
        'dgvMejoresProveedores
        '
        Me.dgvMejoresProveedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMejoresProveedores.DataSource = Me.UltraDataSource3
        Appearance122.BackColor = System.Drawing.Color.White
        Me.dgvMejoresProveedores.DisplayLayout.Appearance = Appearance122
        UltraGridBand2.ColHeaderLines = 2
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance197.FontData.BoldAsString = "False"
        Appearance197.FontData.SizeInPoints = 8.0!
        UltraGridColumn12.CellAppearance = Appearance197
        UltraGridColumn12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance198.FontData.BoldAsString = "False"
        Appearance198.FontData.SizeInPoints = 8.0!
        UltraGridColumn12.Header.Appearance = Appearance198
        UltraGridColumn12.Header.VisiblePosition = 0
        UltraGridColumn12.Width = 195
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance199.FontData.BoldAsString = "False"
        Appearance199.FontData.SizeInPoints = 8.0!
        Appearance199.TextHAlignAsString = "Center"
        Appearance199.TextVAlignAsString = "Middle"
        UltraGridColumn13.CellAppearance = Appearance199
        Appearance200.FontData.BoldAsString = "False"
        Appearance200.FontData.SizeInPoints = 8.0!
        UltraGridColumn13.Header.Appearance = Appearance200
        UltraGridColumn13.Header.VisiblePosition = 1
        UltraGridColumn13.Width = 60
        UltraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance202.FontData.BoldAsString = "False"
        Appearance202.FontData.SizeInPoints = 8.0!
        Appearance202.TextHAlignAsString = "Right"
        Appearance202.TextVAlignAsString = "Middle"
        UltraGridColumn14.CellAppearance = Appearance202
        UltraGridColumn14.Format = "n4"
        Appearance203.FontData.BoldAsString = "False"
        Appearance203.FontData.SizeInPoints = 8.0!
        UltraGridColumn14.Header.Appearance = Appearance203
        UltraGridColumn14.Header.Caption = "Precio" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Proveedor"
        UltraGridColumn14.Header.VisiblePosition = 2
        UltraGridColumn14.Width = 90
        UltraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance204.FontData.BoldAsString = "False"
        Appearance204.FontData.SizeInPoints = 8.0!
        Appearance204.TextHAlignAsString = "Right"
        Appearance204.TextVAlignAsString = "Middle"
        UltraGridColumn15.CellAppearance = Appearance204
        UltraGridColumn15.Format = "n4"
        Appearance205.FontData.BoldAsString = "False"
        Appearance205.FontData.SizeInPoints = 8.0!
        UltraGridColumn15.Header.Appearance = Appearance205
        UltraGridColumn15.Header.Caption = "Precio " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "O/C"
        UltraGridColumn15.Header.VisiblePosition = 3
        UltraGridColumn15.Width = 90
        UltraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance206.FontData.BoldAsString = "False"
        Appearance206.FontData.SizeInPoints = 8.0!
        Appearance206.TextHAlignAsString = "Center"
        Appearance206.TextVAlignAsString = "Middle"
        UltraGridColumn16.CellAppearance = Appearance206
        Appearance207.FontData.BoldAsString = "False"
        Appearance207.FontData.SizeInPoints = 8.0!
        UltraGridColumn16.Header.Appearance = Appearance207
        UltraGridColumn16.Header.Caption = "Código"
        UltraGridColumn16.Header.VisiblePosition = 4
        UltraGridColumn16.Width = 80
        UltraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance208.FontData.BoldAsString = "False"
        Appearance208.FontData.SizeInPoints = 8.0!
        Appearance208.TextHAlignAsString = "Center"
        Appearance208.TextVAlignAsString = "Middle"
        UltraGridColumn17.CellAppearance = Appearance208
        Appearance209.FontData.BoldAsString = "False"
        Appearance209.FontData.SizeInPoints = 8.0!
        UltraGridColumn17.Header.Appearance = Appearance209
        UltraGridColumn17.Header.VisiblePosition = 5
        UltraGridColumn17.Width = 70
        UltraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance210.FontData.BoldAsString = "False"
        Appearance210.FontData.SizeInPoints = 8.0!
        Appearance210.TextHAlignAsString = "Right"
        Appearance210.TextVAlignAsString = "Middle"
        UltraGridColumn18.CellAppearance = Appearance210
        UltraGridColumn18.Format = "n4"
        Appearance211.FontData.BoldAsString = "False"
        Appearance211.FontData.SizeInPoints = 8.0!
        UltraGridColumn18.Header.Appearance = Appearance211
        UltraGridColumn18.Header.Caption = "Nro O/C"
        UltraGridColumn18.Header.VisiblePosition = 6
        UltraGridColumn18.Width = 80
        UltraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance212.FontData.BoldAsString = "False"
        Appearance212.FontData.SizeInPoints = 8.0!
        UltraGridColumn19.Header.Appearance = Appearance212
        UltraGridColumn19.Header.VisiblePosition = 7
        UltraGridColumn19.Hidden = True
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19})
        Me.dgvMejoresProveedores.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.dgvMejoresProveedores.DisplayLayout.InterBandSpacing = 18
        Me.dgvMejoresProveedores.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvMejoresProveedores.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Appearance151.BackColor = System.Drawing.Color.Transparent
        Me.dgvMejoresProveedores.DisplayLayout.Override.CardAreaAppearance = Appearance151
        Appearance152.FontData.BoldAsString = "True"
        Appearance152.FontData.SizeInPoints = 9.0!
        Appearance152.ForeColor = System.Drawing.Color.Navy
        Me.dgvMejoresProveedores.DisplayLayout.Override.CellAppearance = Appearance152
        Me.dgvMejoresProveedores.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance153.BackColor = System.Drawing.Color.Navy
        Appearance153.FontData.BoldAsString = "True"
        Appearance153.FontData.ItalicAsString = "False"
        Appearance153.FontData.SizeInPoints = 10.0!
        Appearance153.ForeColor = System.Drawing.Color.White
        Appearance153.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvMejoresProveedores.DisplayLayout.Override.HeaderAppearance = Appearance153
        Appearance154.TextHAlignAsString = "Center"
        Appearance154.TextVAlignAsString = "Middle"
        Me.dgvMejoresProveedores.DisplayLayout.Override.RowPreviewAppearance = Appearance154
        Appearance155.BackColor = System.Drawing.Color.Navy
        Appearance155.BorderColor = System.Drawing.Color.White
        Appearance155.FontData.BoldAsString = "True"
        Appearance155.ForeColor = System.Drawing.Color.White
        Appearance155.TextHAlignAsString = "Center"
        Appearance155.TextVAlignAsString = "Middle"
        Me.dgvMejoresProveedores.DisplayLayout.Override.RowSelectorAppearance = Appearance155
        Me.dgvMejoresProveedores.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.dgvMejoresProveedores.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvMejoresProveedores.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance156.BackColor = System.Drawing.Color.Navy
        Appearance156.ForeColor = System.Drawing.Color.White
        Me.dgvMejoresProveedores.DisplayLayout.Override.SelectedRowAppearance = Appearance156
        Me.dgvMejoresProveedores.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvMejoresProveedores.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvMejoresProveedores.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvMejoresProveedores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvMejoresProveedores.Location = New System.Drawing.Point(15, 150)
        Me.dgvMejoresProveedores.Name = "dgvMejoresProveedores"
        Me.dgvMejoresProveedores.Size = New System.Drawing.Size(558, 215)
        Me.dgvMejoresProveedores.TabIndex = 134
        '
        'UltraDataSource3
        '
        Me.UltraDataSource3.Band.Columns.AddRange(New Object() {UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19})
        '
        'LblPrecioOC
        '
        Appearance5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.FontData.SizeInPoints = 9.0!
        Appearance5.TextHAlignAsString = "Center"
        Appearance5.TextVAlignAsString = "Middle"
        Me.LblPrecioOC.Appearance = Appearance5
        Me.LblPrecioOC.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblPrecioOC.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblPrecioOC.Location = New System.Drawing.Point(423, 125)
        Me.LblPrecioOC.Name = "LblPrecioOC"
        Me.LblPrecioOC.Size = New System.Drawing.Size(150, 21)
        Me.LblPrecioOC.TabIndex = 113
        '
        'UltraLabel17
        '
        Appearance85.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel17.Appearance = Appearance85
        Me.UltraLabel17.AutoSize = True
        Me.UltraLabel17.Location = New System.Drawing.Point(300, 125)
        Me.UltraLabel17.Name = "UltraLabel17"
        Me.UltraLabel17.Size = New System.Drawing.Size(122, 14)
        Me.UltraLabel17.TabIndex = 112
        Me.UltraLabel17.Text = "Precio O/C por Aprobar"
        '
        'LblUM
        '
        Appearance87.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance87.FontData.BoldAsString = "True"
        Appearance87.FontData.SizeInPoints = 9.0!
        Appearance87.TextHAlignAsString = "Center"
        Appearance87.TextVAlignAsString = "Middle"
        Me.LblUM.Appearance = Appearance87
        Me.LblUM.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblUM.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblUM.Location = New System.Drawing.Point(75, 125)
        Me.LblUM.Name = "LblUM"
        Me.LblUM.Size = New System.Drawing.Size(150, 21)
        Me.LblUM.TabIndex = 111
        '
        'UltraLabel19
        '
        Appearance86.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel19.Appearance = Appearance86
        Me.UltraLabel19.AutoSize = True
        Me.UltraLabel19.Location = New System.Drawing.Point(15, 125)
        Me.UltraLabel19.Name = "UltraLabel19"
        Me.UltraLabel19.Size = New System.Drawing.Size(40, 14)
        Me.UltraLabel19.TabIndex = 110
        Me.UltraLabel19.Text = "Unidad"
        '
        'LblMonedaOC
        '
        Appearance105.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance105.FontData.BoldAsString = "True"
        Appearance105.FontData.SizeInPoints = 9.0!
        Appearance105.TextHAlignAsString = "Center"
        Appearance105.TextVAlignAsString = "Middle"
        Me.LblMonedaOC.Appearance = Appearance105
        Me.LblMonedaOC.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblMonedaOC.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblMonedaOC.Location = New System.Drawing.Point(423, 100)
        Me.LblMonedaOC.Name = "LblMonedaOC"
        Me.LblMonedaOC.Size = New System.Drawing.Size(150, 21)
        Me.LblMonedaOC.TabIndex = 109
        '
        'UltraLabel15
        '
        Appearance106.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel15.Appearance = Appearance106
        Me.UltraLabel15.AutoSize = True
        Me.UltraLabel15.Location = New System.Drawing.Point(347, 100)
        Me.UltraLabel15.Name = "UltraLabel15"
        Me.UltraLabel15.Size = New System.Drawing.Size(68, 14)
        Me.UltraLabel15.TabIndex = 108
        Me.UltraLabel15.Text = "Moneda O/C"
        '
        'LblCodigo
        '
        Appearance107.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance107.FontData.BoldAsString = "True"
        Appearance107.FontData.SizeInPoints = 9.0!
        Appearance107.TextHAlignAsString = "Center"
        Appearance107.TextVAlignAsString = "Middle"
        Me.LblCodigo.Appearance = Appearance107
        Me.LblCodigo.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblCodigo.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblCodigo.Location = New System.Drawing.Point(75, 100)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(150, 21)
        Me.LblCodigo.TabIndex = 107
        '
        'LblProducto
        '
        Appearance4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        Me.LblProducto.Appearance = Appearance4
        Me.LblProducto.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblProducto.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblProducto.Location = New System.Drawing.Point(75, 50)
        Me.LblProducto.Name = "LblProducto"
        Me.LblProducto.Size = New System.Drawing.Size(498, 45)
        Me.LblProducto.TabIndex = 106
        '
        'UltraLabel11
        '
        Appearance108.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel11.Appearance = Appearance108
        Me.UltraLabel11.AutoSize = True
        Me.UltraLabel11.Location = New System.Drawing.Point(15, 100)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(40, 14)
        Me.UltraLabel11.TabIndex = 105
        Me.UltraLabel11.Text = "Código"
        '
        'UltraLabel12
        '
        Appearance84.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel12.Appearance = Appearance84
        Me.UltraLabel12.AutoSize = True
        Me.UltraLabel12.Location = New System.Drawing.Point(15, 50)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(50, 14)
        Me.UltraLabel12.TabIndex = 104
        Me.UltraLabel12.Text = "Producto"
        '
        'btnSalir
        '
        Appearance125.Image = CType(resources.GetObject("Appearance125.Image"), Object)
        Appearance125.ImageHAlign = Infragistics.Win.HAlign.Left
        Appearance125.ImageVAlign = Infragistics.Win.VAlign.Middle
        Appearance125.TextHAlignAsString = "Right"
        Appearance125.TextVAlignAsString = "Middle"
        Me.btnSalir.Appearance = Appearance125
        Me.btnSalir.Location = New System.Drawing.Point(520, 5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(60, 30)
        Me.btnSalir.TabIndex = 102
        Me.btnSalir.Text = "Salir"
        '
        'UltraLabel8
        '
        Appearance83.FontData.BoldAsString = "True"
        Appearance83.FontData.SizeInPoints = 14.0!
        Appearance83.TextHAlignAsString = "Center"
        Appearance83.TextVAlignAsString = "Middle"
        Me.UltraLabel8.Appearance = Appearance83
        Me.UltraLabel8.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.UltraLabel8.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.UltraLabel8.Location = New System.Drawing.Point(0, 1)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(586, 40)
        Me.UltraLabel8.TabIndex = 103
        Me.UltraLabel8.Text = "Top 5 Mejores Proveedores del Producto"
        '
        'LblImporte
        '
        Appearance3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.SizeInPoints = 9.0!
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.LblImporte.Appearance = Appearance3
        Me.LblImporte.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblImporte.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblImporte.Location = New System.Drawing.Point(641, 50)
        Me.LblImporte.Name = "LblImporte"
        Me.LblImporte.Size = New System.Drawing.Size(154, 21)
        Me.LblImporte.TabIndex = 9
        '
        'LblMoneda
        '
        Appearance6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance6.TextHAlignAsString = "Center"
        Appearance6.TextVAlignAsString = "Middle"
        Me.LblMoneda.Appearance = Appearance6
        Me.LblMoneda.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblMoneda.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblMoneda.Location = New System.Drawing.Point(400, 50)
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Size = New System.Drawing.Size(80, 21)
        Me.LblMoneda.TabIndex = 7
        '
        'LblOC
        '
        Appearance185.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance185.FontData.BoldAsString = "True"
        Appearance185.FontData.SizeInPoints = 9.0!
        Appearance185.TextHAlignAsString = "Center"
        Appearance185.TextVAlignAsString = "Middle"
        Me.LblOC.Appearance = Appearance185
        Me.LblOC.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblOC.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblOC.Location = New System.Drawing.Point(90, 50)
        Me.LblOC.Name = "LblOC"
        Me.LblOC.Size = New System.Drawing.Size(150, 21)
        Me.LblOC.TabIndex = 6
        '
        'LblProveedor
        '
        Appearance140.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance140.TextHAlignAsString = "Center"
        Appearance140.TextVAlignAsString = "Middle"
        Me.LblProveedor.Appearance = Appearance140
        Me.LblProveedor.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblProveedor.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblProveedor.Location = New System.Drawing.Point(90, 20)
        Me.LblProveedor.Name = "LblProveedor"
        Me.LblProveedor.Size = New System.Drawing.Size(390, 21)
        Me.LblProveedor.TabIndex = 5
        '
        'UltraLabel7
        '
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Location = New System.Drawing.Point(558, 50)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(43, 14)
        Me.UltraLabel7.TabIndex = 4
        Me.UltraLabel7.Text = "Importe"
        '
        'UltraLabel6
        '
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Location = New System.Drawing.Point(558, 20)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(36, 14)
        Me.UltraLabel6.TabIndex = 3
        Me.UltraLabel6.Text = "Fecha"
        '
        'UltraLabel5
        '
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Location = New System.Drawing.Point(340, 52)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(45, 14)
        Me.UltraLabel5.TabIndex = 2
        Me.UltraLabel5.Text = "Moneda"
        '
        'UltraLabel4
        '
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Location = New System.Drawing.Point(20, 50)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(40, 14)
        Me.UltraLabel4.TabIndex = 1
        Me.UltraLabel4.Text = "Nro Oc"
        '
        'UltraLabel3
        '
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Location = New System.Drawing.Point(20, 20)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(56, 14)
        Me.UltraLabel3.TabIndex = 0
        Me.UltraLabel3.Text = "Proveedor"
        '
        'dgvDetalleOC
        '
        Me.dgvDetalleOC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalleOC.DataSource = Me.UltraDataSource2
        Appearance109.BackColor = System.Drawing.Color.White
        Me.dgvDetalleOC.DisplayLayout.Appearance = Appearance109
        Me.dgvDetalleOC.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand3.ColHeaderLines = 2
        UltraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance213.FontData.BoldAsString = "False"
        Appearance213.FontData.SizeInPoints = 8.0!
        UltraGridColumn20.Header.Appearance = Appearance213
        UltraGridColumn20.Header.VisiblePosition = 0
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.Width = 49
        UltraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance214.FontData.BoldAsString = "False"
        Appearance214.FontData.SizeInPoints = 8.0!
        Appearance214.TextHAlignAsString = "Center"
        Appearance214.TextVAlignAsString = "Middle"
        UltraGridColumn21.CellAppearance = Appearance214
        UltraGridColumn21.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance215.FontData.BoldAsString = "False"
        Appearance215.FontData.SizeInPoints = 8.0!
        UltraGridColumn21.Header.Appearance = Appearance215
        UltraGridColumn21.Header.Caption = "Código"
        UltraGridColumn21.Header.VisiblePosition = 1
        UltraGridColumn21.Width = 78
        UltraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance216.FontData.BoldAsString = "False"
        Appearance216.FontData.SizeInPoints = 8.0!
        UltraGridColumn22.CellAppearance = Appearance216
        UltraGridColumn22.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance217.FontData.BoldAsString = "False"
        Appearance217.FontData.SizeInPoints = 8.0!
        UltraGridColumn22.Header.Appearance = Appearance217
        UltraGridColumn22.Header.Caption = "Descripción"
        UltraGridColumn22.Header.VisiblePosition = 2
        UltraGridColumn22.Width = 213
        UltraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance218.FontData.BoldAsString = "False"
        Appearance218.FontData.SizeInPoints = 8.0!
        Appearance218.TextHAlignAsString = "Center"
        Appearance218.TextVAlignAsString = "Middle"
        UltraGridColumn23.CellAppearance = Appearance218
        UltraGridColumn23.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance219.FontData.BoldAsString = "False"
        Appearance219.FontData.SizeInPoints = 8.0!
        UltraGridColumn23.Header.Appearance = Appearance219
        UltraGridColumn23.Header.VisiblePosition = 3
        UltraGridColumn23.Width = 58
        UltraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance220.FontData.BoldAsString = "False"
        Appearance220.FontData.SizeInPoints = 8.0!
        Appearance220.TextHAlignAsString = "Center"
        Appearance220.TextVAlignAsString = "Middle"
        UltraGridColumn24.CellAppearance = Appearance220
        Appearance221.FontData.BoldAsString = "False"
        Appearance221.FontData.SizeInPoints = 8.0!
        UltraGridColumn24.Header.Appearance = Appearance221
        UltraGridColumn24.Header.VisiblePosition = 4
        UltraGridColumn24.Width = 107
        UltraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance222.FontData.BoldAsString = "False"
        Appearance222.FontData.SizeInPoints = 8.0!
        Appearance222.TextHAlignAsString = "Center"
        Appearance222.TextVAlignAsString = "Middle"
        UltraGridColumn25.CellAppearance = Appearance222
        Appearance223.FontData.BoldAsString = "False"
        Appearance223.FontData.SizeInPoints = 8.0!
        UltraGridColumn25.Header.Appearance = Appearance223
        UltraGridColumn25.Header.VisiblePosition = 5
        UltraGridColumn25.Width = 53
        UltraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance224.FontData.BoldAsString = "False"
        Appearance224.FontData.SizeInPoints = 8.0!
        Appearance224.TextHAlignAsString = "Right"
        Appearance224.TextVAlignAsString = "Middle"
        UltraGridColumn26.CellAppearance = Appearance224
        UltraGridColumn26.Format = "n4"
        Appearance225.FontData.BoldAsString = "False"
        Appearance225.FontData.SizeInPoints = 8.0!
        UltraGridColumn26.Header.Appearance = Appearance225
        UltraGridColumn26.Header.VisiblePosition = 6
        UltraGridColumn26.Width = 84
        UltraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance226.FontData.BoldAsString = "False"
        Appearance226.FontData.SizeInPoints = 8.0!
        Appearance226.TextHAlignAsString = "Right"
        Appearance226.TextVAlignAsString = "Middle"
        UltraGridColumn27.CellAppearance = Appearance226
        UltraGridColumn27.Format = "n4"
        Appearance227.FontData.BoldAsString = "False"
        Appearance227.FontData.SizeInPoints = 8.0!
        UltraGridColumn27.Header.Appearance = Appearance227
        UltraGridColumn27.Header.Caption = "Dcto"
        UltraGridColumn27.Header.VisiblePosition = 7
        UltraGridColumn27.Width = 58
        UltraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance228.FontData.BoldAsString = "False"
        Appearance228.FontData.SizeInPoints = 8.0!
        Appearance228.TextHAlignAsString = "Right"
        Appearance228.TextVAlignAsString = "Middle"
        UltraGridColumn28.CellAppearance = Appearance228
        UltraGridColumn28.Format = "n4"
        Appearance229.FontData.BoldAsString = "False"
        Appearance229.FontData.SizeInPoints = 8.0!
        UltraGridColumn28.Header.Appearance = Appearance229
        UltraGridColumn28.Header.VisiblePosition = 8
        UltraGridColumn28.Width = 83
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28})
        Me.dgvDetalleOC.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.dgvDetalleOC.DisplayLayout.InterBandSpacing = 18
        Me.dgvDetalleOC.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDetalleOC.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Appearance133.BackColor = System.Drawing.Color.Transparent
        Me.dgvDetalleOC.DisplayLayout.Override.CardAreaAppearance = Appearance133
        Appearance134.FontData.BoldAsString = "True"
        Appearance134.FontData.SizeInPoints = 9.0!
        Appearance134.ForeColor = System.Drawing.Color.Navy
        Me.dgvDetalleOC.DisplayLayout.Override.CellAppearance = Appearance134
        Me.dgvDetalleOC.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance135.BackColor = System.Drawing.Color.Navy
        Appearance135.FontData.BoldAsString = "True"
        Appearance135.FontData.ItalicAsString = "False"
        Appearance135.FontData.SizeInPoints = 10.0!
        Appearance135.ForeColor = System.Drawing.Color.White
        Appearance135.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvDetalleOC.DisplayLayout.Override.HeaderAppearance = Appearance135
        Appearance136.TextHAlignAsString = "Center"
        Appearance136.TextVAlignAsString = "Middle"
        Me.dgvDetalleOC.DisplayLayout.Override.RowPreviewAppearance = Appearance136
        Appearance137.BackColor = System.Drawing.Color.Navy
        Appearance137.BorderColor = System.Drawing.Color.White
        Appearance137.FontData.BoldAsString = "True"
        Appearance137.ForeColor = System.Drawing.Color.White
        Appearance137.TextHAlignAsString = "Center"
        Appearance137.TextVAlignAsString = "Middle"
        Me.dgvDetalleOC.DisplayLayout.Override.RowSelectorAppearance = Appearance137
        Me.dgvDetalleOC.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.dgvDetalleOC.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvDetalleOC.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance138.BackColor = System.Drawing.Color.Navy
        Appearance138.ForeColor = System.Drawing.Color.White
        Me.dgvDetalleOC.DisplayLayout.Override.SelectedRowAppearance = Appearance138
        Me.dgvDetalleOC.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDetalleOC.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvDetalleOC.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvDetalleOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDetalleOC.Location = New System.Drawing.Point(20, 85)
        Me.dgvDetalleOC.Name = "dgvDetalleOC"
        Me.dgvDetalleOC.Size = New System.Drawing.Size(775, 370)
        Me.dgvDetalleOC.TabIndex = 133
        '
        'UltraDataSource2
        '
        Me.UltraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27, UltraDataColumn28})
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.GrpCuadorComparativo)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(812, 464)
        '
        'GrpCuadorComparativo
        '
        Me.GrpCuadorComparativo.Controls.Add(Me.UltraGroupBox5)
        Me.GrpCuadorComparativo.Controls.Add(Me.UltraGroupBox4)
        Me.GrpCuadorComparativo.Controls.Add(Me.UltraGroupBox3)
        Me.GrpCuadorComparativo.Controls.Add(Me.UltraGroupBox2)
        Me.GrpCuadorComparativo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpCuadorComparativo.Location = New System.Drawing.Point(0, 0)
        Me.GrpCuadorComparativo.Name = "GrpCuadorComparativo"
        Me.GrpCuadorComparativo.Size = New System.Drawing.Size(812, 464)
        Me.GrpCuadorComparativo.TabIndex = 142
        Me.GrpCuadorComparativo.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2007
        Me.GrpCuadorComparativo.Visible = False
        '
        'UltraGroupBox5
        '
        Me.UltraGroupBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox5.Controls.Add(Me.dgvAnalisisComparativo)
        Me.UltraGroupBox5.Controls.Add(Me.UltraLabel23)
        Me.UltraGroupBox5.Location = New System.Drawing.Point(10, 225)
        Me.UltraGroupBox5.Name = "UltraGroupBox5"
        Me.UltraGroupBox5.Size = New System.Drawing.Size(789, 235)
        Me.UltraGroupBox5.TabIndex = 3
        '
        'dgvAnalisisComparativo
        '
        Me.dgvAnalisisComparativo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAnalisisComparativo.DataSource = Me.UltraDataSource6
        Appearance186.BackColor = System.Drawing.Color.White
        Me.dgvAnalisisComparativo.DisplayLayout.Appearance = Appearance186
        Me.dgvAnalisisComparativo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand4.ColHeaderLines = 2
        UltraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance230.FontData.BoldAsString = "False"
        Appearance230.FontData.SizeInPoints = 8.0!
        UltraGridColumn29.CellAppearance = Appearance230
        UltraGridColumn29.CellMultiLine = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridColumn29.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance231.FontData.BoldAsString = "False"
        Appearance231.FontData.SizeInPoints = 8.0!
        UltraGridColumn29.Header.Appearance = Appearance231
        UltraGridColumn29.Header.VisiblePosition = 0
        UltraGridColumn29.MinWidth = 250
        UltraGridColumn29.RowLayoutColumnInfo.OriginX = 0
        UltraGridColumn29.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn29.Width = 250
        UltraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance232.FontData.BoldAsString = "False"
        Appearance232.FontData.SizeInPoints = 8.0!
        Appearance232.TextHAlignAsString = "Center"
        Appearance232.TextVAlignAsString = "Middle"
        UltraGridColumn30.CellAppearance = Appearance232
        UltraGridColumn30.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance233.FontData.BoldAsString = "False"
        Appearance233.FontData.SizeInPoints = 8.0!
        UltraGridColumn30.Header.Appearance = Appearance233
        UltraGridColumn30.Header.VisiblePosition = 1
        UltraGridColumn30.MaxWidth = 100
        UltraGridColumn30.MinWidth = 100
        UltraGridColumn30.RowLayoutColumnInfo.OriginX = 2
        UltraGridColumn30.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn30.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn30.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn30.Width = 100
        UltraGridColumn31.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance234.FontData.BoldAsString = "False"
        Appearance234.FontData.SizeInPoints = 8.0!
        Appearance234.TextHAlignAsString = "Center"
        Appearance234.TextVAlignAsString = "Middle"
        UltraGridColumn31.CellAppearance = Appearance234
        UltraGridColumn31.Format = "n4"
        Appearance235.FontData.BoldAsString = "False"
        Appearance235.FontData.SizeInPoints = 8.0!
        UltraGridColumn31.Header.Appearance = Appearance235
        UltraGridColumn31.Header.VisiblePosition = 2
        UltraGridColumn31.MaxWidth = 70
        UltraGridColumn31.MinWidth = 70
        UltraGridColumn31.RowLayoutColumnInfo.OriginX = 6
        UltraGridColumn31.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn31.Width = 70
        UltraGridColumn32.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance236.FontData.BoldAsString = "False"
        Appearance236.FontData.SizeInPoints = 8.0!
        Appearance236.TextHAlignAsString = "Right"
        Appearance236.TextVAlignAsString = "Middle"
        UltraGridColumn32.CellAppearance = Appearance236
        UltraGridColumn32.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn32.Format = "n4"
        Appearance237.FontData.BoldAsString = "False"
        Appearance237.FontData.SizeInPoints = 8.0!
        UltraGridColumn32.Header.Appearance = Appearance237
        UltraGridColumn32.Header.Caption = "Forma" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pago"
        UltraGridColumn32.Header.VisiblePosition = 3
        UltraGridColumn32.MaxWidth = 120
        UltraGridColumn32.MinWidth = 120
        UltraGridColumn32.RowLayoutColumnInfo.OriginX = 10
        UltraGridColumn32.Width = 120
        UltraGridColumn33.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance238.FontData.BoldAsString = "False"
        Appearance238.FontData.SizeInPoints = 9.0!
        Appearance238.TextHAlignAsString = "Center"
        Appearance238.TextVAlignAsString = "Middle"
        UltraGridColumn33.CellAppearance = Appearance238
        Appearance239.FontData.BoldAsString = "False"
        Appearance239.FontData.SizeInPoints = 8.0!
        UltraGridColumn33.Header.Appearance = Appearance239
        UltraGridColumn33.Header.VisiblePosition = 4
        UltraGridColumn33.MaxWidth = 35
        UltraGridColumn33.MinWidth = 35
        UltraGridColumn33.RowLayoutColumnInfo.OriginX = 4
        UltraGridColumn33.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn33.Width = 35
        UltraGridColumn34.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance240.FontData.BoldAsString = "False"
        Appearance240.FontData.SizeInPoints = 8.0!
        Appearance240.TextHAlignAsString = "Center"
        Appearance240.TextVAlignAsString = "Middle"
        UltraGridColumn34.CellAppearance = Appearance240
        Appearance241.FontData.BoldAsString = "False"
        Appearance241.FontData.SizeInPoints = 8.0!
        UltraGridColumn34.Header.Appearance = Appearance241
        UltraGridColumn34.Header.VisiblePosition = 5
        UltraGridColumn34.MaxWidth = 35
        UltraGridColumn34.MinWidth = 35
        UltraGridColumn34.RowLayoutColumnInfo.OriginX = 2
        UltraGridColumn34.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn34.Width = 35
        UltraGridColumn35.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance242.FontData.BoldAsString = "False"
        Appearance242.FontData.SizeInPoints = 8.0!
        Appearance242.TextHAlignAsString = "Right"
        Appearance242.TextVAlignAsString = "Middle"
        UltraGridColumn35.CellAppearance = Appearance242
        UltraGridColumn35.Format = "n4"
        Appearance243.FontData.BoldAsString = "False"
        Appearance243.FontData.SizeInPoints = 8.0!
        UltraGridColumn35.Header.Appearance = Appearance243
        UltraGridColumn35.Header.Caption = "Precio" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cotización"
        UltraGridColumn35.Header.VisiblePosition = 6
        UltraGridColumn35.MaxWidth = 70
        UltraGridColumn35.MinWidth = 70
        UltraGridColumn35.RowLayoutColumnInfo.OriginX = 6
        UltraGridColumn35.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn35.Width = 70
        UltraGridColumn36.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance244.FontData.BoldAsString = "False"
        Appearance244.FontData.SizeInPoints = 8.0!
        Appearance244.TextHAlignAsString = "Right"
        Appearance244.TextVAlignAsString = "Middle"
        UltraGridColumn36.CellAppearance = Appearance244
        UltraGridColumn36.ColSpan = CType(2, Short)
        UltraGridColumn36.Format = "n4"
        Appearance245.FontData.BoldAsString = "False"
        Appearance245.FontData.SizeInPoints = 8.0!
        UltraGridColumn36.Header.Appearance = Appearance245
        UltraGridColumn36.Header.VisiblePosition = 7
        UltraGridColumn36.MaxWidth = 70
        UltraGridColumn36.MinWidth = 70
        UltraGridColumn36.RowLayoutColumnInfo.OriginX = 8
        UltraGridColumn36.RowLayoutColumnInfo.OriginY = 1
        UltraGridColumn36.Width = 70
        UltraGridColumn37.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance246.FontData.BoldAsString = "False"
        Appearance246.FontData.SizeInPoints = 8.0!
        Appearance246.TextHAlignAsString = "Center"
        Appearance246.TextVAlignAsString = "Middle"
        UltraGridColumn37.CellAppearance = Appearance246
        Appearance247.FontData.BoldAsString = "False"
        Appearance247.FontData.SizeInPoints = 8.0!
        UltraGridColumn37.Header.Appearance = Appearance247
        UltraGridColumn37.Header.Caption = "Generar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "OC"
        UltraGridColumn37.Header.VisiblePosition = 8
        UltraGridColumn37.MaxWidth = 35
        UltraGridColumn37.MinWidth = 35
        UltraGridColumn37.RowLayoutColumnInfo.OriginX = 8
        UltraGridColumn37.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn37.RowLayoutColumnInfo.SpanX = 4
        UltraGridColumn37.Width = 35
        UltraGridColumn38.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance248.FontData.BoldAsString = "False"
        Appearance248.FontData.SizeInPoints = 8.0!
        Appearance248.TextHAlignAsString = "Center"
        Appearance248.TextVAlignAsString = "Middle"
        UltraGridColumn38.CellAppearance = Appearance248
        Appearance249.FontData.BoldAsString = "False"
        Appearance249.FontData.SizeInPoints = 8.0!
        UltraGridColumn38.Header.Appearance = Appearance249
        UltraGridColumn38.Header.Caption = "Nro" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cotización"
        UltraGridColumn38.Header.VisiblePosition = 9
        UltraGridColumn38.MaxWidth = 100
        UltraGridColumn38.MinWidth = 100
        UltraGridColumn38.RowLayoutColumnInfo.OriginX = 2
        UltraGridColumn38.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn38.Width = 100
        UltraGridColumn39.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance250.FontData.BoldAsString = "False"
        Appearance250.FontData.SizeInPoints = 8.0!
        Appearance250.TextHAlignAsString = "Center"
        Appearance250.TextVAlignAsString = "Middle"
        UltraGridColumn39.CellAppearance = Appearance250
        Appearance251.FontData.BoldAsString = "False"
        Appearance251.FontData.SizeInPoints = 8.0!
        UltraGridColumn39.Header.Appearance = Appearance251
        UltraGridColumn39.Header.Caption = "Fecha" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cotización"
        UltraGridColumn39.Header.VisiblePosition = 10
        UltraGridColumn39.MaxWidth = 70
        UltraGridColumn39.MinWidth = 70
        UltraGridColumn39.RowLayoutColumnInfo.OriginX = 4
        UltraGridColumn39.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn39.Width = 70
        UltraGridColumn40.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance252.FontData.BoldAsString = "False"
        Appearance252.FontData.SizeInPoints = 8.0!
        Appearance252.TextHAlignAsString = "Center"
        Appearance252.TextVAlignAsString = "Middle"
        UltraGridColumn40.CellAppearance = Appearance252
        Appearance253.FontData.BoldAsString = "False"
        Appearance253.FontData.SizeInPoints = 8.0!
        UltraGridColumn40.Header.Appearance = Appearance253
        UltraGridColumn40.Header.VisiblePosition = 11
        UltraGridColumn40.MaxWidth = 120
        UltraGridColumn40.MinWidth = 120
        UltraGridColumn40.RowLayoutColumnInfo.OriginX = 1
        UltraGridColumn40.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn40.Width = 120
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40})
        UltraGridBand4.UseRowLayout = True
        Me.dgvAnalisisComparativo.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.dgvAnalisisComparativo.DisplayLayout.InterBandSpacing = 18
        Me.dgvAnalisisComparativo.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Appearance254.BackColor = System.Drawing.Color.Transparent
        Me.dgvAnalisisComparativo.DisplayLayout.Override.CardAreaAppearance = Appearance254
        Appearance255.FontData.BoldAsString = "True"
        Appearance255.FontData.SizeInPoints = 9.0!
        Appearance255.ForeColor = System.Drawing.Color.Navy
        Me.dgvAnalisisComparativo.DisplayLayout.Override.CellAppearance = Appearance255
        Appearance256.BackColor = System.Drawing.Color.Navy
        Appearance256.FontData.BoldAsString = "True"
        Appearance256.FontData.ItalicAsString = "False"
        Appearance256.FontData.SizeInPoints = 10.0!
        Appearance256.ForeColor = System.Drawing.Color.White
        Appearance256.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvAnalisisComparativo.DisplayLayout.Override.HeaderAppearance = Appearance256
        Appearance257.TextHAlignAsString = "Center"
        Appearance257.TextVAlignAsString = "Middle"
        Me.dgvAnalisisComparativo.DisplayLayout.Override.RowPreviewAppearance = Appearance257
        Appearance258.BackColor = System.Drawing.Color.Navy
        Appearance258.BorderColor = System.Drawing.Color.White
        Appearance258.FontData.BoldAsString = "True"
        Appearance258.ForeColor = System.Drawing.Color.White
        Appearance258.TextHAlignAsString = "Center"
        Appearance258.TextVAlignAsString = "Middle"
        Me.dgvAnalisisComparativo.DisplayLayout.Override.RowSelectorAppearance = Appearance258
        Me.dgvAnalisisComparativo.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.dgvAnalisisComparativo.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvAnalisisComparativo.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance259.BackColor = System.Drawing.Color.Navy
        Appearance259.ForeColor = System.Drawing.Color.White
        Me.dgvAnalisisComparativo.DisplayLayout.Override.SelectedRowAppearance = Appearance259
        Me.dgvAnalisisComparativo.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvAnalisisComparativo.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvAnalisisComparativo.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvAnalisisComparativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvAnalisisComparativo.Location = New System.Drawing.Point(7, 30)
        Me.dgvAnalisisComparativo.Name = "dgvAnalisisComparativo"
        Me.dgvAnalisisComparativo.Size = New System.Drawing.Size(773, 200)
        Me.dgvAnalisisComparativo.TabIndex = 136
        '
        'UltraDataSource6
        '
        Me.UltraDataSource6.Band.Columns.AddRange(New Object() {UltraDataColumn29, UltraDataColumn30, UltraDataColumn31, UltraDataColumn32, UltraDataColumn33, UltraDataColumn34, UltraDataColumn35, UltraDataColumn36, UltraDataColumn37, UltraDataColumn38, UltraDataColumn39, UltraDataColumn40})
        '
        'UltraLabel23
        '
        Me.UltraLabel23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance163.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance163.FontData.BoldAsString = "True"
        Appearance163.FontData.SizeInPoints = 14.0!
        Appearance163.TextHAlignAsString = "Left"
        Appearance163.TextVAlignAsString = "Middle"
        Me.UltraLabel23.Appearance = Appearance163
        Me.UltraLabel23.Location = New System.Drawing.Point(0, 0)
        Me.UltraLabel23.Name = "UltraLabel23"
        Me.UltraLabel23.Size = New System.Drawing.Size(789, 24)
        Me.UltraLabel23.TabIndex = 0
        Me.UltraLabel23.Text = "Analisis de Cuadro Comparativo de Cotizaciones"
        '
        'UltraGroupBox4
        '
        Me.UltraGroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox4.Controls.Add(Me.LblRazonSocial)
        Me.UltraGroupBox4.Controls.Add(Me.LblPrecioUltimaCompra)
        Me.UltraGroupBox4.Controls.Add(Me.lblMonedaCuadro)
        Me.UltraGroupBox4.Controls.Add(Me.UltraLabel18)
        Me.UltraGroupBox4.Controls.Add(Me.UltraLabel16)
        Me.UltraGroupBox4.Controls.Add(Me.UltraLabel13)
        Me.UltraGroupBox4.Location = New System.Drawing.Point(10, 155)
        Me.UltraGroupBox4.Name = "UltraGroupBox4"
        Me.UltraGroupBox4.Size = New System.Drawing.Size(789, 63)
        Me.UltraGroupBox4.TabIndex = 2
        Me.UltraGroupBox4.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.Office2000
        '
        'LblRazonSocial
        '
        Me.LblRazonSocial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance139.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance139.FontData.BoldAsString = "True"
        Appearance139.FontData.SizeInPoints = 9.0!
        Appearance139.TextHAlignAsString = "Center"
        Appearance139.TextVAlignAsString = "Middle"
        Me.LblRazonSocial.Appearance = Appearance139
        Me.LblRazonSocial.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblRazonSocial.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblRazonSocial.Location = New System.Drawing.Point(247, 25)
        Me.LblRazonSocial.Name = "LblRazonSocial"
        Me.LblRazonSocial.Size = New System.Drawing.Size(521, 21)
        Me.LblRazonSocial.TabIndex = 9
        '
        'LblPrecioUltimaCompra
        '
        Appearance167.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance167.FontData.BoldAsString = "True"
        Appearance167.FontData.SizeInPoints = 9.0!
        Appearance167.TextHAlignAsString = "Center"
        Appearance167.TextVAlignAsString = "Middle"
        Me.LblPrecioUltimaCompra.Appearance = Appearance167
        Me.LblPrecioUltimaCompra.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblPrecioUltimaCompra.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.LblPrecioUltimaCompra.Location = New System.Drawing.Point(98, 25)
        Me.LblPrecioUltimaCompra.Name = "LblPrecioUltimaCompra"
        Me.LblPrecioUltimaCompra.Size = New System.Drawing.Size(128, 21)
        Me.LblPrecioUltimaCompra.TabIndex = 8
        '
        'lblMonedaCuadro
        '
        Appearance168.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Appearance168.FontData.BoldAsString = "True"
        Appearance168.FontData.SizeInPoints = 9.0!
        Appearance168.TextHAlignAsString = "Center"
        Appearance168.TextVAlignAsString = "Middle"
        Me.lblMonedaCuadro.Appearance = Appearance168
        Me.lblMonedaCuadro.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.lblMonedaCuadro.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.WindowsVista
        Me.lblMonedaCuadro.Location = New System.Drawing.Point(15, 25)
        Me.lblMonedaCuadro.Name = "lblMonedaCuadro"
        Me.lblMonedaCuadro.Size = New System.Drawing.Size(60, 21)
        Me.lblMonedaCuadro.TabIndex = 7
        '
        'UltraLabel18
        '
        Me.UltraLabel18.AutoSize = True
        Me.UltraLabel18.Location = New System.Drawing.Point(247, 5)
        Me.UltraLabel18.Name = "UltraLabel18"
        Me.UltraLabel18.Size = New System.Drawing.Size(71, 14)
        Me.UltraLabel18.TabIndex = 2
        Me.UltraLabel18.Text = "Razón Social"
        '
        'UltraLabel16
        '
        Me.UltraLabel16.AutoSize = True
        Me.UltraLabel16.Location = New System.Drawing.Point(100, 5)
        Me.UltraLabel16.Name = "UltraLabel16"
        Me.UltraLabel16.Size = New System.Drawing.Size(122, 14)
        Me.UltraLabel16.TabIndex = 1
        Me.UltraLabel16.Text = "Precio - Última Compra"
        '
        'UltraLabel13
        '
        Me.UltraLabel13.AutoSize = True
        Me.UltraLabel13.Location = New System.Drawing.Point(20, 5)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(45, 14)
        Me.UltraLabel13.TabIndex = 0
        Me.UltraLabel13.Text = "Moneda"
        '
        'UltraGroupBox3
        '
        Me.UltraGroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UltraGroupBox3.Controls.Add(Me.dgvDetalleRequerimiento)
        Me.UltraGroupBox3.Controls.Add(Me.UltraLabel10)
        Me.UltraGroupBox3.Location = New System.Drawing.Point(409, 10)
        Me.UltraGroupBox3.Name = "UltraGroupBox3"
        Me.UltraGroupBox3.Size = New System.Drawing.Size(390, 140)
        Me.UltraGroupBox3.TabIndex = 1
        '
        'dgvDetalleRequerimiento
        '
        Me.dgvDetalleRequerimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalleRequerimiento.DataSource = Me.UltraDataSource5
        Appearance164.BackColor = System.Drawing.Color.White
        Me.dgvDetalleRequerimiento.DisplayLayout.Appearance = Appearance164
        UltraGridBand5.ColHeaderLines = 3
        UltraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance260.FontData.BoldAsString = "False"
        Appearance260.FontData.SizeInPoints = 8.0!
        UltraGridColumn41.CellAppearance = Appearance260
        UltraGridColumn41.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance261.FontData.BoldAsString = "False"
        Appearance261.FontData.SizeInPoints = 8.0!
        UltraGridColumn41.Header.Appearance = Appearance261
        UltraGridColumn41.Header.Caption = "Área"
        UltraGridColumn41.Header.VisiblePosition = 0
        UltraGridColumn41.Width = 120
        UltraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance262.FontData.BoldAsString = "False"
        Appearance262.FontData.SizeInPoints = 8.0!
        Appearance262.TextHAlignAsString = "Center"
        Appearance262.TextVAlignAsString = "Middle"
        UltraGridColumn42.CellAppearance = Appearance262
        Appearance263.FontData.BoldAsString = "False"
        Appearance263.FontData.SizeInPoints = 8.0!
        UltraGridColumn42.Header.Appearance = Appearance263
        UltraGridColumn42.Header.Caption = "Nro Requerimiento"
        UltraGridColumn42.Header.VisiblePosition = 1
        UltraGridColumn42.Width = 120
        UltraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance264.FontData.BoldAsString = "False"
        Appearance264.FontData.SizeInPoints = 8.0!
        Appearance264.TextHAlignAsString = "Right"
        Appearance264.TextVAlignAsString = "Middle"
        UltraGridColumn43.CellAppearance = Appearance264
        UltraGridColumn43.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn43.Format = "n4"
        Appearance265.FontData.BoldAsString = "False"
        Appearance265.FontData.SizeInPoints = 8.0!
        UltraGridColumn43.Header.Appearance = Appearance265
        UltraGridColumn43.Header.VisiblePosition = 2
        UltraGridColumn43.Width = 45
        UltraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance266.FontData.BoldAsString = "False"
        Appearance266.FontData.SizeInPoints = 8.0!
        Appearance266.TextHAlignAsString = "Right"
        Appearance266.TextVAlignAsString = "Middle"
        UltraGridColumn44.CellAppearance = Appearance266
        UltraGridColumn44.Format = "n4"
        Appearance267.FontData.BoldAsString = "False"
        Appearance267.FontData.SizeInPoints = 8.0!
        UltraGridColumn44.Header.Appearance = Appearance267
        UltraGridColumn44.Header.Caption = "Cantidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "x" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Atender"
        UltraGridColumn44.Header.VisiblePosition = 3
        UltraGridColumn44.Width = 90
        UltraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance268.FontData.BoldAsString = "False"
        Appearance268.FontData.SizeInPoints = 8.0!
        Appearance268.TextHAlignAsString = "Right"
        Appearance268.TextVAlignAsString = "Middle"
        UltraGridColumn45.CellAppearance = Appearance268
        Appearance269.FontData.BoldAsString = "False"
        Appearance269.FontData.SizeInPoints = 8.0!
        UltraGridColumn45.Header.Appearance = Appearance269
        UltraGridColumn45.Header.Caption = "Cantidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "x" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Comprar"
        UltraGridColumn45.Header.VisiblePosition = 4
        UltraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance270.TextHAlignAsString = "Right"
        Appearance270.TextVAlignAsString = "Middle"
        UltraGridColumn46.CellAppearance = Appearance270
        Appearance271.FontData.BoldAsString = "False"
        Appearance271.FontData.SizeInPoints = 8.0!
        UltraGridColumn46.Header.Appearance = Appearance271
        UltraGridColumn46.Header.Caption = "Cantidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Atendida" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Temporal"
        UltraGridColumn46.Header.VisiblePosition = 5
        UltraGridColumn47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance272.FontData.BoldAsString = "False"
        Appearance272.FontData.SizeInPoints = 8.0!
        Appearance272.TextHAlignAsString = "Center"
        Appearance272.TextVAlignAsString = "Middle"
        UltraGridColumn47.CellAppearance = Appearance272
        UltraGridColumn47.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance273.FontData.BoldAsString = "False"
        Appearance273.FontData.SizeInPoints = 8.0!
        UltraGridColumn47.Header.Appearance = Appearance273
        UltraGridColumn47.Header.VisiblePosition = 6
        UltraGridColumn48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance274.FontData.BoldAsString = "False"
        Appearance274.FontData.SizeInPoints = 8.0!
        Appearance274.TextHAlignAsString = "Center"
        Appearance274.TextVAlignAsString = "Middle"
        UltraGridColumn48.CellAppearance = Appearance274
        UltraGridColumn48.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance275.FontData.BoldAsString = "False"
        Appearance275.FontData.SizeInPoints = 8.0!
        UltraGridColumn48.Header.Appearance = Appearance275
        UltraGridColumn48.Header.Caption = "Observación"
        UltraGridColumn48.Header.VisiblePosition = 7
        UltraGridColumn49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance276.FontData.BoldAsString = "False"
        Appearance276.FontData.SizeInPoints = 8.0!
        Appearance276.TextHAlignAsString = "Left"
        Appearance276.TextVAlignAsString = "Middle"
        UltraGridColumn49.CellAppearance = Appearance276
        UltraGridColumn49.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance277.FontData.BoldAsString = "False"
        Appearance277.FontData.SizeInPoints = 8.0!
        UltraGridColumn49.Header.Appearance = Appearance277
        UltraGridColumn49.Header.Caption = "Proveedor" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sugerido"
        UltraGridColumn49.Header.VisiblePosition = 8
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49})
        Me.dgvDetalleRequerimiento.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.dgvDetalleRequerimiento.DisplayLayout.InterBandSpacing = 18
        Me.dgvDetalleRequerimiento.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDetalleRequerimiento.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Appearance96.BackColor = System.Drawing.Color.Transparent
        Me.dgvDetalleRequerimiento.DisplayLayout.Override.CardAreaAppearance = Appearance96
        Appearance104.FontData.BoldAsString = "True"
        Appearance104.FontData.SizeInPoints = 9.0!
        Appearance104.ForeColor = System.Drawing.Color.Navy
        Me.dgvDetalleRequerimiento.DisplayLayout.Override.CellAppearance = Appearance104
        Appearance117.BackColor = System.Drawing.Color.Navy
        Appearance117.FontData.BoldAsString = "True"
        Appearance117.FontData.ItalicAsString = "False"
        Appearance117.FontData.SizeInPoints = 10.0!
        Appearance117.ForeColor = System.Drawing.Color.White
        Appearance117.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvDetalleRequerimiento.DisplayLayout.Override.HeaderAppearance = Appearance117
        Appearance118.TextHAlignAsString = "Center"
        Appearance118.TextVAlignAsString = "Middle"
        Me.dgvDetalleRequerimiento.DisplayLayout.Override.RowPreviewAppearance = Appearance118
        Appearance119.BackColor = System.Drawing.Color.Navy
        Appearance119.BorderColor = System.Drawing.Color.White
        Appearance119.FontData.BoldAsString = "True"
        Appearance119.ForeColor = System.Drawing.Color.White
        Appearance119.TextHAlignAsString = "Center"
        Appearance119.TextVAlignAsString = "Middle"
        Me.dgvDetalleRequerimiento.DisplayLayout.Override.RowSelectorAppearance = Appearance119
        Me.dgvDetalleRequerimiento.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.dgvDetalleRequerimiento.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvDetalleRequerimiento.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance120.BackColor = System.Drawing.Color.Navy
        Appearance120.ForeColor = System.Drawing.Color.White
        Me.dgvDetalleRequerimiento.DisplayLayout.Override.SelectedRowAppearance = Appearance120
        Me.dgvDetalleRequerimiento.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDetalleRequerimiento.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvDetalleRequerimiento.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvDetalleRequerimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDetalleRequerimiento.Location = New System.Drawing.Point(10, 30)
        Me.dgvDetalleRequerimiento.Name = "dgvDetalleRequerimiento"
        Me.dgvDetalleRequerimiento.Size = New System.Drawing.Size(374, 100)
        Me.dgvDetalleRequerimiento.TabIndex = 136
        '
        'UltraDataSource5
        '
        Me.UltraDataSource5.Band.Columns.AddRange(New Object() {UltraDataColumn41, UltraDataColumn42, UltraDataColumn43, UltraDataColumn44, UltraDataColumn45, UltraDataColumn46, UltraDataColumn47, UltraDataColumn48, UltraDataColumn49})
        '
        'UltraLabel10
        '
        Me.UltraLabel10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance201.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance201.FontData.BoldAsString = "True"
        Appearance201.FontData.SizeInPoints = 14.0!
        Appearance201.TextHAlignAsString = "Left"
        Appearance201.TextVAlignAsString = "Middle"
        Me.UltraLabel10.Appearance = Appearance201
        Me.UltraLabel10.Location = New System.Drawing.Point(0, 0)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(390, 24)
        Me.UltraLabel10.TabIndex = 1
        Me.UltraLabel10.Text = "Detalle por Requerimiento"
        '
        'UltraGroupBox2
        '
        Me.UltraGroupBox2.Controls.Add(Me.dgvArticulosComparadosXproducto)
        Me.UltraGroupBox2.Controls.Add(Me.dgvArticulosComparados)
        Me.UltraGroupBox2.Controls.Add(Me.UltraLabel9)
        Me.UltraGroupBox2.Location = New System.Drawing.Point(10, 10)
        Me.UltraGroupBox2.Name = "UltraGroupBox2"
        Me.UltraGroupBox2.Size = New System.Drawing.Size(390, 140)
        Me.UltraGroupBox2.TabIndex = 0
        '
        'dgvArticulosComparadosXproducto
        '
        Me.dgvArticulosComparadosXproducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvArticulosComparadosXproducto.DataSource = Me.UltraDataSource4
        Appearance169.BackColor = System.Drawing.Color.White
        Me.dgvArticulosComparadosXproducto.DisplayLayout.Appearance = Appearance169
        Me.dgvArticulosComparadosXproducto.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridBand6.ColHeaderLines = 2
        UltraGridColumn50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance278.FontData.BoldAsString = "False"
        Appearance278.FontData.SizeInPoints = 8.0!
        UltraGridColumn50.CellAppearance = Appearance278
        UltraGridColumn50.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance279.FontData.BoldAsString = "False"
        Appearance279.FontData.SizeInPoints = 8.0!
        UltraGridColumn50.Header.Appearance = Appearance279
        UltraGridColumn50.Header.Caption = "Código"
        UltraGridColumn50.Header.VisiblePosition = 0
        UltraGridColumn50.Width = 81
        UltraGridColumn51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance280.FontData.BoldAsString = "False"
        Appearance280.FontData.SizeInPoints = 8.0!
        Appearance280.TextHAlignAsString = "Center"
        Appearance280.TextVAlignAsString = "Middle"
        UltraGridColumn51.CellAppearance = Appearance280
        UltraGridColumn51.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance281.FontData.BoldAsString = "False"
        Appearance281.FontData.SizeInPoints = 8.0!
        UltraGridColumn51.Header.Appearance = Appearance281
        UltraGridColumn51.Header.Caption = "Descripción"
        UltraGridColumn51.Header.VisiblePosition = 1
        UltraGridColumn51.Width = 100
        UltraGridColumn52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance282.FontData.BoldAsString = "False"
        Appearance282.FontData.SizeInPoints = 8.0!
        Appearance282.TextHAlignAsString = "Right"
        Appearance282.TextVAlignAsString = "Middle"
        UltraGridColumn52.CellAppearance = Appearance282
        UltraGridColumn52.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        UltraGridColumn52.Format = "n4"
        Appearance283.FontData.BoldAsString = "False"
        Appearance283.FontData.SizeInPoints = 8.0!
        UltraGridColumn52.Header.Appearance = Appearance283
        UltraGridColumn52.Header.VisiblePosition = 2
        UltraGridColumn52.Width = 45
        UltraGridColumn53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance284.FontData.BoldAsString = "False"
        Appearance284.FontData.SizeInPoints = 8.0!
        Appearance284.TextHAlignAsString = "Right"
        Appearance284.TextVAlignAsString = "Middle"
        UltraGridColumn53.CellAppearance = Appearance284
        UltraGridColumn53.Format = "n4"
        Appearance285.FontData.BoldAsString = "False"
        Appearance285.FontData.SizeInPoints = 8.0!
        UltraGridColumn53.Header.Appearance = Appearance285
        UltraGridColumn53.Header.Caption = "Cantidad" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Requerida"
        UltraGridColumn53.Header.VisiblePosition = 3
        UltraGridColumn53.Width = 90
        UltraGridBand6.Columns.AddRange(New Object() {UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53})
        Me.dgvArticulosComparadosXproducto.DisplayLayout.BandsSerializer.Add(UltraGridBand6)
        Me.dgvArticulosComparadosXproducto.DisplayLayout.InterBandSpacing = 18
        Me.dgvArticulosComparadosXproducto.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvArticulosComparadosXproducto.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Appearance178.BackColor = System.Drawing.Color.Transparent
        Me.dgvArticulosComparadosXproducto.DisplayLayout.Override.CardAreaAppearance = Appearance178
        Appearance179.FontData.BoldAsString = "True"
        Appearance179.FontData.SizeInPoints = 9.0!
        Appearance179.ForeColor = System.Drawing.Color.Navy
        Me.dgvArticulosComparadosXproducto.DisplayLayout.Override.CellAppearance = Appearance179
        Appearance180.BackColor = System.Drawing.Color.Navy
        Appearance180.FontData.BoldAsString = "True"
        Appearance180.FontData.ItalicAsString = "False"
        Appearance180.FontData.SizeInPoints = 10.0!
        Appearance180.ForeColor = System.Drawing.Color.White
        Appearance180.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvArticulosComparadosXproducto.DisplayLayout.Override.HeaderAppearance = Appearance180
        Appearance181.TextHAlignAsString = "Center"
        Appearance181.TextVAlignAsString = "Middle"
        Me.dgvArticulosComparadosXproducto.DisplayLayout.Override.RowPreviewAppearance = Appearance181
        Appearance182.BackColor = System.Drawing.Color.Navy
        Appearance182.BorderColor = System.Drawing.Color.White
        Appearance182.FontData.BoldAsString = "True"
        Appearance182.ForeColor = System.Drawing.Color.White
        Appearance182.TextHAlignAsString = "Center"
        Appearance182.TextVAlignAsString = "Middle"
        Me.dgvArticulosComparadosXproducto.DisplayLayout.Override.RowSelectorAppearance = Appearance182
        Me.dgvArticulosComparadosXproducto.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.dgvArticulosComparadosXproducto.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvArticulosComparadosXproducto.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance183.BackColor = System.Drawing.Color.Navy
        Appearance183.ForeColor = System.Drawing.Color.White
        Me.dgvArticulosComparadosXproducto.DisplayLayout.Override.SelectedRowAppearance = Appearance183
        Me.dgvArticulosComparadosXproducto.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvArticulosComparadosXproducto.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvArticulosComparadosXproducto.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvArticulosComparadosXproducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvArticulosComparadosXproducto.Location = New System.Drawing.Point(10, 30)
        Me.dgvArticulosComparadosXproducto.Name = "dgvArticulosComparadosXproducto"
        Me.dgvArticulosComparadosXproducto.Size = New System.Drawing.Size(374, 100)
        Me.dgvArticulosComparadosXproducto.TabIndex = 136
        '
        'UltraDataSource4
        '
        Me.UltraDataSource4.Band.Columns.AddRange(New Object() {UltraDataColumn50, UltraDataColumn51, UltraDataColumn52, UltraDataColumn53})
        '
        'dgvArticulosComparados
        '
        Me.dgvArticulosComparados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvArticulosComparados.DataSource = Me.UltraDataSource4
        Appearance132.BackColor = System.Drawing.Color.White
        Me.dgvArticulosComparados.DisplayLayout.Appearance = Appearance132
        Me.dgvArticulosComparados.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn54.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance286.FontData.BoldAsString = "False"
        Appearance286.FontData.SizeInPoints = 8.0!
        UltraGridColumn54.CellAppearance = Appearance286
        Appearance287.FontData.BoldAsString = "True"
        Appearance287.FontData.SizeInPoints = 9.0!
        UltraGridColumn54.Header.Appearance = Appearance287
        UltraGridColumn54.Header.VisiblePosition = 0
        UltraGridColumn54.Width = 81
        UltraGridColumn55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance288.FontData.BoldAsString = "False"
        Appearance288.FontData.SizeInPoints = 8.0!
        Appearance288.TextHAlignAsString = "Center"
        Appearance288.TextVAlignAsString = "Middle"
        UltraGridColumn55.CellAppearance = Appearance288
        Appearance289.FontData.SizeInPoints = 9.0!
        UltraGridColumn55.Header.Appearance = Appearance289
        UltraGridColumn55.Header.VisiblePosition = 1
        UltraGridColumn55.Width = 100
        UltraGridColumn56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance290.FontData.BoldAsString = "False"
        Appearance290.FontData.SizeInPoints = 8.0!
        Appearance290.TextHAlignAsString = "Right"
        Appearance290.TextVAlignAsString = "Middle"
        UltraGridColumn56.CellAppearance = Appearance290
        UltraGridColumn56.Format = "n4"
        Appearance291.FontData.SizeInPoints = 9.0!
        UltraGridColumn56.Header.Appearance = Appearance291
        UltraGridColumn56.Header.VisiblePosition = 2
        UltraGridColumn56.Width = 45
        UltraGridColumn57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn57.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance292.FontData.BoldAsString = "False"
        Appearance292.FontData.SizeInPoints = 8.0!
        Appearance292.TextHAlignAsString = "Right"
        Appearance292.TextVAlignAsString = "Middle"
        UltraGridColumn57.CellAppearance = Appearance292
        UltraGridColumn57.Format = "n4"
        Appearance293.FontData.SizeInPoints = 9.0!
        UltraGridColumn57.Header.Appearance = Appearance293
        UltraGridColumn57.Header.Caption = "Cant Req"
        UltraGridColumn57.Header.VisiblePosition = 3
        UltraGridColumn57.Width = 90
        UltraGridBand7.Columns.AddRange(New Object() {UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57})
        Me.dgvArticulosComparados.DisplayLayout.BandsSerializer.Add(UltraGridBand7)
        Me.dgvArticulosComparados.DisplayLayout.InterBandSpacing = 18
        Me.dgvArticulosComparados.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvArticulosComparados.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Appearance149.BackColor = System.Drawing.Color.Transparent
        Me.dgvArticulosComparados.DisplayLayout.Override.CardAreaAppearance = Appearance149
        Appearance150.FontData.BoldAsString = "True"
        Appearance150.FontData.SizeInPoints = 9.0!
        Appearance150.ForeColor = System.Drawing.Color.Navy
        Me.dgvArticulosComparados.DisplayLayout.Override.CellAppearance = Appearance150
        Me.dgvArticulosComparados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance157.BackColor = System.Drawing.Color.Navy
        Appearance157.FontData.BoldAsString = "True"
        Appearance157.FontData.ItalicAsString = "False"
        Appearance157.FontData.SizeInPoints = 10.0!
        Appearance157.ForeColor = System.Drawing.Color.White
        Appearance157.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.dgvArticulosComparados.DisplayLayout.Override.HeaderAppearance = Appearance157
        Appearance158.TextHAlignAsString = "Center"
        Appearance158.TextVAlignAsString = "Middle"
        Me.dgvArticulosComparados.DisplayLayout.Override.RowPreviewAppearance = Appearance158
        Appearance159.BackColor = System.Drawing.Color.Navy
        Appearance159.BorderColor = System.Drawing.Color.White
        Appearance159.FontData.BoldAsString = "True"
        Appearance159.ForeColor = System.Drawing.Color.White
        Appearance159.TextHAlignAsString = "Center"
        Appearance159.TextVAlignAsString = "Middle"
        Me.dgvArticulosComparados.DisplayLayout.Override.RowSelectorAppearance = Appearance159
        Me.dgvArticulosComparados.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.RowIndex
        Me.dgvArticulosComparados.DisplayLayout.Override.RowSpacingAfter = 4
        Me.dgvArticulosComparados.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance160.BackColor = System.Drawing.Color.Navy
        Appearance160.ForeColor = System.Drawing.Color.White
        Me.dgvArticulosComparados.DisplayLayout.Override.SelectedRowAppearance = Appearance160
        Me.dgvArticulosComparados.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvArticulosComparados.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.dgvArticulosComparados.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.dgvArticulosComparados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvArticulosComparados.Location = New System.Drawing.Point(10, 30)
        Me.dgvArticulosComparados.Name = "dgvArticulosComparados"
        Me.dgvArticulosComparados.Size = New System.Drawing.Size(374, 100)
        Me.dgvArticulosComparados.TabIndex = 135
        Me.dgvArticulosComparados.Visible = False
        '
        'UltraLabel9
        '
        Appearance184.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance184.FontData.BoldAsString = "True"
        Appearance184.FontData.SizeInPoints = 14.0!
        Appearance184.TextHAlignAsString = "Left"
        Appearance184.TextVAlignAsString = "Middle"
        Me.UltraLabel9.Appearance = Appearance184
        Me.UltraLabel9.Location = New System.Drawing.Point(0, 0)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(390, 24)
        Me.UltraLabel9.TabIndex = 0
        Me.UltraLabel9.Text = "Artículos Comparados"
        '
        'TabAprobacionOC
        '
        Me.TabAprobacionOC.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.TabAprobacionOC.Controls.Add(Me.UltraTabPageControl1)
        Me.TabAprobacionOC.Controls.Add(Me.UltraTabPageControl3)
        Me.TabAprobacionOC.Controls.Add(Me.UltraTabPageControl4)
        Me.TabAprobacionOC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabAprobacionOC.Location = New System.Drawing.Point(0, 0)
        Me.TabAprobacionOC.Name = "TabAprobacionOC"
        Appearance2.FontData.SizeInPoints = 12.0!
        Me.TabAprobacionOC.SelectedTabAppearance = Appearance2
        Me.TabAprobacionOC.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.TabAprobacionOC.Size = New System.Drawing.Size(814, 492)
        Me.TabAprobacionOC.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon
        Me.TabAprobacionOC.TabIndex = 0
        Me.TabAprobacionOC.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        UltraTab1.Key = "Aprobar"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Aprobación de Orden de Compra"
        UltraTab2.Key = "Detalle"
        Appearance1.FontData.SizeInPoints = 12.0!
        UltraTab2.SelectedAppearance = Appearance1
        UltraTab2.TabPage = Me.UltraTabPageControl3
        UltraTab2.Text = "Detalle de Orden de Compra"
        UltraTab3.Key = "CuadroComparativo"
        UltraTab3.TabPage = Me.UltraTabPageControl4
        UltraTab3.Text = "Cuadro Comparativo"
        Me.TabAprobacionOC.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3})
        Me.TabAprobacionOC.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(812, 464)
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(812, 469)
        '
        'UltraDataSource8
        '
        Me.UltraDataSource8.Band.Columns.AddRange(New Object() {UltraDataColumn54, UltraDataColumn55, UltraDataColumn56, UltraDataColumn57, UltraDataColumn58, UltraDataColumn59, UltraDataColumn60, UltraDataColumn61, UltraDataColumn62, UltraDataColumn63, UltraDataColumn64, UltraDataColumn65})
        '
        'Cia1
        '
        Me.Cia1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance13.BackColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Appearance = Appearance13
        Me.Cia1.DisplayLayout.InterBandSpacing = 18
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Me.Cia1.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance35.FontData.BoldAsString = "True"
        Appearance35.FontData.SizeInPoints = 9.0!
        Appearance35.ForeColor = System.Drawing.Color.Navy
        Me.Cia1.DisplayLayout.Override.CellAppearance = Appearance35
        Appearance54.BackColor = System.Drawing.Color.Navy
        Appearance54.FontData.BoldAsString = "True"
        Appearance54.FontData.ItalicAsString = "True"
        Appearance54.FontData.SizeInPoints = 10.0!
        Appearance54.ForeColor = System.Drawing.Color.White
        Appearance54.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.Cia1.DisplayLayout.Override.HeaderAppearance = Appearance54
        Appearance57.BackColor = System.Drawing.Color.Navy
        Appearance57.BorderColor = System.Drawing.Color.White
        Appearance57.ForeColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Override.RowSelectorAppearance = Appearance57
        Me.Cia1.DisplayLayout.Override.RowSpacingAfter = 4
        Me.Cia1.DisplayLayout.Override.RowSpacingBefore = 2
        Appearance65.BackColor = System.Drawing.Color.Navy
        Appearance65.ForeColor = System.Drawing.Color.White
        Me.Cia1.DisplayLayout.Override.SelectedRowAppearance = Appearance65
        Me.Cia1.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black
        Me.Cia1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid
        Me.Cia1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.Cia1.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.Cia1.Location = New System.Drawing.Point(60, 10)
        Me.Cia1.Name = "Cia1"
        Me.Cia1.ReadOnly = True
        Me.Cia1.Size = New System.Drawing.Size(270, 22)
        Me.Cia1.TabIndex = 92
        '
        'FrmAprobacionOC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 492)
        Me.Controls.Add(Me.TabAprobacionOC)
        Me.Name = "FrmAprobacionOC"
        Me.Text = " Aprobación - O/C"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        CType(Me.DtFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        CType(Me.GrpTopMejores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpTopMejores.ResumeLayout(False)
        Me.GrpTopMejores.PerformLayout()
        CType(Me.dgvMejoresProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalleOC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl4.ResumeLayout(False)
        CType(Me.GrpCuadorComparativo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCuadorComparativo.ResumeLayout(False)
        CType(Me.UltraGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox5.ResumeLayout(False)
        CType(Me.dgvAnalisisComparativo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox4.ResumeLayout(False)
        Me.UltraGroupBox4.PerformLayout()
        CType(Me.UltraGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox3.ResumeLayout(False)
        CType(Me.dgvDetalleRequerimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox2.ResumeLayout(False)
        CType(Me.dgvArticulosComparadosXproducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvArticulosComparados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabAprobacionOC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabAprobacionOC.ResumeLayout(False)
        CType(Me.UltraDataSource8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cia1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabAprobacionOC As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ChkTodos As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents dgvOC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents RbAnularOC As System.Windows.Forms.RadioButton
    Friend WithEvents RbAprobacionOC As System.Windows.Forms.RadioButton
    Friend WithEvents LblMensaje As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DtInicio As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents DtFin As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents LblProveedor As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblImporte As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblMoneda As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblOC As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dgvDetalleOC As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraDataSource2 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents GrpTopMejores As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnSalir As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dgvMejoresProveedores As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents LblPrecioOC As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel17 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblUM As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel19 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblMonedaOC As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel15 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblCodigo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblProducto As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraDataSource3 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents dtFechaOC As System.Windows.Forms.DateTimePicker
    Friend WithEvents UltraDataSource4 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraDataSource5 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraDataSource6 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents GrpCuadorComparativo As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBox5 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraLabel23 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox4 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents LblRazonSocial As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents LblPrecioUltimaCompra As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblMonedaCuadro As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel18 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel16 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox3 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dgvDetalleRequerimiento As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraGroupBox2 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents dgvArticulosComparadosXproducto As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents dgvArticulosComparados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraDataSource8 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents dgvAnalisisComparativo As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Cia1 As Infragistics.Win.UltraWinGrid.UltraCombo
End Class
