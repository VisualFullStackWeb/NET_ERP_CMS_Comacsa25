<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlanificacion
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
        Dim Appearance181 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance182 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlanificacion))
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANO", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ELIMINAR", 1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_PLANIF_SUB_PLANO", 2)
        Dim ColScrollRegion1 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(246)
        Dim ColScrollRegion2 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(381)
        Dim ColScrollRegion3 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(308)
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
        Dim Appearance183 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance184 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance185 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance186 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance187 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance188 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance189 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance190 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance191 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance192 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance176 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance175 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance132 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance133 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CODIGO", 0)
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TRABAJADOR", 1)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HORAS", 2)
        Dim Appearance158 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("COSTO", 3)
        Dim Appearance159 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOTAL", 4)
        Dim Appearance160 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 5)
        Dim ColScrollRegion15 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(812)
        Dim ColScrollRegion16 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(453)
        Dim ColScrollRegion17 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(381)
        Dim ColScrollRegion18 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(308)
        Dim ColScrollRegion19 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion20 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion21 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion22 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion23 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion24 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion25 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion26 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion27 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion28 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion29 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
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
        Dim Appearance177 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance174 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance144 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance145 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CODIGO", 0)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PRODUCTO", 1)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UNIDAD", 2)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CANTIDAD", 3)
        Dim Appearance161 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PRECIO_SISTEMA", 4)
        Dim Appearance162 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PRECIO_ESTIMADO", 5)
        Dim Appearance163 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOTAL", 6)
        Dim Appearance164 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 7)
        Dim ColScrollRegion30 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(812)
        Dim ColScrollRegion31 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(683)
        Dim ColScrollRegion32 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(453)
        Dim ColScrollRegion33 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(381)
        Dim ColScrollRegion34 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(308)
        Dim ColScrollRegion35 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion36 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion37 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion38 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion39 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion40 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion41 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion42 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion43 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion44 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion45 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance146 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance147 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance148 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance149 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance150 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance151 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance152 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance153 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance154 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance155 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CODIGO", 0)
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SERVICIO", 1)
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CANTIDAD", 2)
        Dim Appearance165 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PRECIO_SISTEMA", 3)
        Dim Appearance166 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PRECIO_ESTIMADO", 4)
        Dim Appearance167 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TOTAL", 5)
        Dim Appearance168 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", 6)
        Dim ColScrollRegion46 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(812)
        Dim ColScrollRegion47 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(683)
        Dim ColScrollRegion48 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(683)
        Dim ColScrollRegion49 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(453)
        Dim ColScrollRegion50 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(381)
        Dim ColScrollRegion51 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(308)
        Dim ColScrollRegion52 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion53 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion54 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion55 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion56 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion57 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion58 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion59 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion60 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion61 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion62 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_PLANIFICACION", 0)
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_PROYECTO", 1)
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_TALLER", 2)
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PROYECTO", 3)
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TALLER", 4)
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_EQUIPO", 5)
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EQUIPO", 6)
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FECHA", 7)
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EJECUCION", 8)
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPO", 9)
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FLGCIERRE", 10)
        Dim ColScrollRegion63 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(1022)
        Dim ColScrollRegion64 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(800)
        Dim ColScrollRegion65 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(308)
        Dim ColScrollRegion66 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion67 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion68 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion69 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion70 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion71 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion72 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion73 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion74 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion75 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion76 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand6 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PLANO", 0)
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ELIMINAR", 1)
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_PLANIF_PLANO", 2)
        Dim ColScrollRegion77 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(246)
        Dim ColScrollRegion78 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(246)
        Dim ColScrollRegion79 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(381)
        Dim ColScrollRegion80 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(308)
        Dim ColScrollRegion81 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion82 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion83 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion84 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion85 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion86 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion87 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion88 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion89 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion90 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion91 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance120 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand7 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance121 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_TAREA", 0)
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_SUBTAREA", 1)
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ELIMINAR", 2)
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SUBTAREA", 3)
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NUMERO", 4)
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EJECUCION", 5)
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TIPO", 6)
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_PLANIF_SUBTAREA", 7)
        Dim ColScrollRegion92 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(453)
        Dim ColScrollRegion93 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(381)
        Dim ColScrollRegion94 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(308)
        Dim ColScrollRegion95 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion96 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion97 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion98 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion99 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion100 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion101 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion102 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion103 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion104 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion105 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance122 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance123 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance126 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance128 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance129 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance130 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance131 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem13 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem14 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem15 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance180 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance108 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridBand8 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Action")
        Dim Appearance109 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_TAREA", 0)
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DESC_TAREA", 1)
        Dim Appearance171 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ELIMINAR", 2)
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID_PLANIF_TAREA", 3)
        Dim ColScrollRegion106 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(381)
        Dim ColScrollRegion107 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(308)
        Dim ColScrollRegion108 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(677)
        Dim ColScrollRegion109 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(349)
        Dim ColScrollRegion110 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion111 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(483)
        Dim ColScrollRegion112 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(836)
        Dim ColScrollRegion113 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion114 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion115 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(767)
        Dim ColScrollRegion116 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(617)
        Dim ColScrollRegion117 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim ColScrollRegion118 As Infragistics.Win.UltraWinGrid.ColScrollRegion = New Infragistics.Win.UltraWinGrid.ColScrollRegion(789)
        Dim Appearance110 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance111 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance112 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance113 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance114 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance115 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance116 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance117 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance118 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance170 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance169 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance178 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance179 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance172 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance173 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab7 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance156 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance157 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance107 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance102 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance103 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab
        Dim Appearance104 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraTabPageControl7 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.gridplanodet = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.txtplanodet = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel12 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Button7 = New System.Windows.Forms.Button
        Me.UltraLabel17 = New Infragistics.Win.Misc.UltraLabel
        Me.txttotpersona = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnAgregar = New System.Windows.Forms.PictureBox
        Me.gridpersonal = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraLabel18 = New Infragistics.Win.Misc.UltraLabel
        Me.txttotmaterial = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.gridmaterial = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.UltraLabel19 = New Infragistics.Win.Misc.UltraLabel
        Me.txttotservicio = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.gridServicio = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.panel = New System.Windows.Forms.Panel
        Me.gridProyecto = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.rdbCore = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.Button8 = New System.Windows.Forms.Button
        Me.gridplano = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.gridsubtarea = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraLabel20 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbTipo = New Infragistics.Win.UltraWinEditors.UltraComboEditor
        Me.rdbCorrectiva = New System.Windows.Forms.RadioButton
        Me.rdbnoPlanificada = New System.Windows.Forms.RadioButton
        Me.rdbPlanificada = New System.Windows.Forms.RadioButton
        Me.txtplano = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel13 = New Infragistics.Win.Misc.UltraLabel
        Me.txtidequipo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtidtaller = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtidproyecto = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtsubtarea = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.gridTarea = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.txttarea = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.txtequipo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.dtFecha = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txttaller = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.txtid = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtproyecto = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl
        Me.txtsubtareadet = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txttotalsub = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel16 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel15 = New Infragistics.Win.Misc.UltraLabel
        Me.dtfechasubtarea = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.txtidplanifsub = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel14 = New Infragistics.Win.Misc.UltraLabel
        Me.txtnota = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraTabControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.cmbsubtarea = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel
        Me.cmbTarea = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel
        Me.txtequipo_det = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.txttaller_det = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel
        Me.txtproyecto_det = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel10 = New Infragistics.Win.Misc.UltraLabel
        Me.Tab1 = New Infragistics.Win.UltraWinTabControl.UltraTabControl
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
        Me.UltraTabPageControl7.SuspendLayout()
        CType(Me.gridplanodet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtplanodet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl4.SuspendLayout()
        CType(Me.txttotpersona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAgregar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridpersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl5.SuspendLayout()
        CType(Me.txttotmaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridmaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl6.SuspendLayout()
        CType(Me.txttotservicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        Me.panel.SuspendLayout()
        CType(Me.gridProyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rdbCore.SuspendLayout()
        CType(Me.gridplano, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridsubtarea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtplano, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtidequipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtidtaller, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtidproyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsubtarea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridTarea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttarea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtequipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttaller, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtproyecto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.txtsubtareadet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttotalsub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtfechasubtarea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtidplanifsub, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnota, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControl1.SuspendLayout()
        CType(Me.cmbsubtarea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTarea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtequipo_det, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttaller_det, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtproyecto_det, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl7
        '
        Me.UltraTabPageControl7.Controls.Add(Me.gridplanodet)
        Me.UltraTabPageControl7.Controls.Add(Me.txtplanodet)
        Me.UltraTabPageControl7.Controls.Add(Me.UltraLabel12)
        Me.UltraTabPageControl7.Location = New System.Drawing.Point(1, 35)
        Me.UltraTabPageControl7.Name = "UltraTabPageControl7"
        Me.UltraTabPageControl7.Size = New System.Drawing.Size(972, 285)
        '
        'gridplanodet
        '
        Me.gridplanodet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance181.BackColor = System.Drawing.SystemColors.Window
        Appearance181.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridplanodet.DisplayLayout.Appearance = Appearance181
        Me.gridplanodet.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance182.Image = CType(resources.GetObject("Appearance182.Image"), Object)
        Appearance182.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance182.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn1.Header.Appearance = Appearance182
        UltraGridColumn1.Header.Caption = ""
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.MaxWidth = 25
        UltraGridColumn1.MinWidth = 20
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 20
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn2.Width = 129
        UltraGridColumn3.Header.Caption = ""
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.URL
        UltraGridColumn3.Width = 79
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 72
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4})
        Me.gridplanodet.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridplanodet.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridplanodet.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion1)
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion2)
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion3)
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion4)
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion5)
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion6)
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion7)
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion8)
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion9)
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion10)
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion11)
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion12)
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion13)
        Me.gridplanodet.DisplayLayout.ColScrollRegions.Add(ColScrollRegion14)
        Me.gridplanodet.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance183.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance183.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance183.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance183.BorderColor = System.Drawing.SystemColors.Window
        Me.gridplanodet.DisplayLayout.GroupByBox.Appearance = Appearance183
        Appearance184.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridplanodet.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance184
        Me.gridplanodet.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridplanodet.DisplayLayout.GroupByBox.Hidden = True
        Appearance185.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance185.BackColor2 = System.Drawing.SystemColors.Control
        Appearance185.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance185.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridplanodet.DisplayLayout.GroupByBox.PromptAppearance = Appearance185
        Me.gridplanodet.DisplayLayout.MaxColScrollRegions = 1
        Me.gridplanodet.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridplanodet.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridplanodet.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridplanodet.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance186.BackColor = System.Drawing.SystemColors.Window
        Me.gridplanodet.DisplayLayout.Override.CardAreaAppearance = Appearance186
        Appearance187.BorderColor = System.Drawing.Color.Silver
        Appearance187.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridplanodet.DisplayLayout.Override.CellAppearance = Appearance187
        Me.gridplanodet.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridplanodet.DisplayLayout.Override.CellPadding = 0
        Me.gridplanodet.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridplanodet.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridplanodet.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridplanodet.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance188.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance188.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridplanodet.DisplayLayout.Override.FilterRowAppearance = Appearance188
        Me.gridplanodet.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridplanodet.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance189.BackColor = System.Drawing.SystemColors.Control
        Appearance189.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance189.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance189.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance189.BorderColor = System.Drawing.SystemColors.Window
        Me.gridplanodet.DisplayLayout.Override.GroupByRowAppearance = Appearance189
        Appearance190.FontData.Name = "Arial Narrow"
        Appearance190.FontData.SizeInPoints = 10.0!
        Appearance190.TextHAlignAsString = "Left"
        Me.gridplanodet.DisplayLayout.Override.HeaderAppearance = Appearance190
        Me.gridplanodet.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridplanodet.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridplanodet.DisplayLayout.Override.MinRowHeight = 24
        Appearance191.BackColor = System.Drawing.SystemColors.Window
        Appearance191.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance191.TextVAlignAsString = "Middle"
        Me.gridplanodet.DisplayLayout.Override.RowAppearance = Appearance191
        Me.gridplanodet.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridplanodet.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridplanodet.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance192.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridplanodet.DisplayLayout.Override.TemplateAddRowAppearance = Appearance192
        Me.gridplanodet.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridplanodet.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridplanodet.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridplanodet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridplanodet.Location = New System.Drawing.Point(264, 22)
        Me.gridplanodet.Name = "gridplanodet"
        Me.gridplanodet.Size = New System.Drawing.Size(248, 257)
        Me.gridplanodet.TabIndex = 248
        '
        'txtplanodet
        '
        Appearance20.TextHAlignAsString = "Left"
        Appearance20.TextVAlignAsString = "Middle"
        Me.txtplanodet.Appearance = Appearance20
        Me.txtplanodet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtplanodet.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtplanodet.Location = New System.Drawing.Point(89, 44)
        Me.txtplanodet.Name = "txtplanodet"
        Me.txtplanodet.Size = New System.Drawing.Size(139, 21)
        Me.txtplanodet.TabIndex = 247
        Me.txtplanodet.TabStop = False
        '
        'UltraLabel12
        '
        Appearance38.BackColor = System.Drawing.Color.Transparent
        Appearance38.TextHAlignAsString = "Left"
        Me.UltraLabel12.Appearance = Appearance38
        Me.UltraLabel12.AutoSize = True
        Me.UltraLabel12.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel12.Location = New System.Drawing.Point(40, 46)
        Me.UltraLabel12.Name = "UltraLabel12"
        Me.UltraLabel12.Size = New System.Drawing.Size(45, 17)
        Me.UltraLabel12.TabIndex = 246
        Me.UltraLabel12.Text = "Planos :"
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.Button7)
        Me.UltraTabPageControl4.Controls.Add(Me.UltraLabel17)
        Me.UltraTabPageControl4.Controls.Add(Me.txttotpersona)
        Me.UltraTabPageControl4.Controls.Add(Me.Button4)
        Me.UltraTabPageControl4.Controls.Add(Me.Button1)
        Me.UltraTabPageControl4.Controls.Add(Me.btnAgregar)
        Me.UltraTabPageControl4.Controls.Add(Me.gridpersonal)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(972, 285)
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.Location = New System.Drawing.Point(761, 81)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(70, 39)
        Me.Button7.TabIndex = 265
        Me.Button7.Text = "Personal externo"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'UltraLabel17
        '
        Me.UltraLabel17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance176.BackColor = System.Drawing.Color.Transparent
        Appearance176.TextHAlignAsString = "Left"
        Me.UltraLabel17.Appearance = Appearance176
        Me.UltraLabel17.AutoSize = True
        Me.UltraLabel17.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel17.Location = New System.Drawing.Point(761, 241)
        Me.UltraLabel17.Name = "UltraLabel17"
        Me.UltraLabel17.Size = New System.Drawing.Size(118, 17)
        Me.UltraLabel17.TabIndex = 264
        Me.UltraLabel17.Text = "Costo total de personal"
        '
        'txttotpersona
        '
        Me.txttotpersona.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance175.TextHAlignAsString = "Right"
        Appearance175.TextVAlignAsString = "Middle"
        Me.txttotpersona.Appearance = Appearance175
        Me.txttotpersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotpersona.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttotpersona.Location = New System.Drawing.Point(761, 264)
        Me.txttotpersona.Name = "txttotpersona"
        Me.txttotpersona.ReadOnly = True
        Me.txttotpersona.Size = New System.Drawing.Size(124, 21)
        Me.txttotpersona.TabIndex = 263
        Me.txttotpersona.TabStop = False
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Image = Global.SIP_Presentacion.My.Resources.Resources.delete_icon
        Me.Button4.Location = New System.Drawing.Point(761, 50)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(28, 25)
        Me.Button4.TabIndex = 254
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = Global.SIP_Presentacion.My.Resources.Resources.add_icon
        Me.Button1.Location = New System.Drawing.Point(761, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 25)
        Me.Button1.TabIndex = 253
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Image = Global.SIP_Presentacion.My.Resources.Resources.Add
        Me.btnAgregar.Location = New System.Drawing.Point(802, 19)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(29, 24)
        Me.btnAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnAgregar.TabIndex = 252
        Me.btnAgregar.TabStop = False
        Me.btnAgregar.Visible = False
        '
        'gridpersonal
        '
        Me.gridpersonal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance132.BackColor = System.Drawing.SystemColors.Window
        Appearance132.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridpersonal.DisplayLayout.Appearance = Appearance132
        Me.gridpersonal.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance133.Image = CType(resources.GetObject("Appearance133.Image"), Object)
        Appearance133.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance133.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn5.Header.Appearance = Appearance133
        UltraGridColumn5.Header.Caption = ""
        UltraGridColumn5.Header.VisiblePosition = 0
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.MaxWidth = 25
        UltraGridColumn5.MinWidth = 20
        UltraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn5.Width = 20
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.VisiblePosition = 1
        UltraGridColumn6.Width = 80
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.VisiblePosition = 2
        UltraGridColumn7.Width = 301
        Appearance158.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance158
        UltraGridColumn8.Header.VisiblePosition = 3
        UltraGridColumn8.MaskInput = "{double:9.2}"
        UltraGridColumn8.Width = 83
        Appearance159.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance159
        UltraGridColumn9.Header.VisiblePosition = 4
        UltraGridColumn9.MaskInput = "{double:9.2}"
        UltraGridColumn9.Width = 89
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance160.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance160
        UltraGridColumn10.Header.VisiblePosition = 5
        UltraGridColumn10.MaskInput = "{double:9.2}"
        UltraGridColumn10.Width = 80
        UltraGridColumn11.Header.VisiblePosition = 6
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.Width = 93
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11})
        Me.gridpersonal.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridpersonal.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridpersonal.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion15)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion16)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion17)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion18)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion19)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion20)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion21)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion22)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion23)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion24)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion25)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion26)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion27)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion28)
        Me.gridpersonal.DisplayLayout.ColScrollRegions.Add(ColScrollRegion29)
        Me.gridpersonal.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance134.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance134.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance134.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance134.BorderColor = System.Drawing.SystemColors.Window
        Me.gridpersonal.DisplayLayout.GroupByBox.Appearance = Appearance134
        Appearance135.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridpersonal.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance135
        Me.gridpersonal.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridpersonal.DisplayLayout.GroupByBox.Hidden = True
        Appearance136.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance136.BackColor2 = System.Drawing.SystemColors.Control
        Appearance136.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance136.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridpersonal.DisplayLayout.GroupByBox.PromptAppearance = Appearance136
        Me.gridpersonal.DisplayLayout.MaxColScrollRegions = 1
        Me.gridpersonal.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridpersonal.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridpersonal.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridpersonal.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance137.BackColor = System.Drawing.SystemColors.Window
        Me.gridpersonal.DisplayLayout.Override.CardAreaAppearance = Appearance137
        Appearance138.BorderColor = System.Drawing.Color.Silver
        Appearance138.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridpersonal.DisplayLayout.Override.CellAppearance = Appearance138
        Me.gridpersonal.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridpersonal.DisplayLayout.Override.CellPadding = 0
        Me.gridpersonal.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridpersonal.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridpersonal.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridpersonal.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance139.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance139.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridpersonal.DisplayLayout.Override.FilterRowAppearance = Appearance139
        Me.gridpersonal.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridpersonal.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance140.BackColor = System.Drawing.SystemColors.Control
        Appearance140.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance140.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance140.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance140.BorderColor = System.Drawing.SystemColors.Window
        Me.gridpersonal.DisplayLayout.Override.GroupByRowAppearance = Appearance140
        Appearance141.FontData.Name = "Arial Narrow"
        Appearance141.FontData.SizeInPoints = 10.0!
        Appearance141.TextHAlignAsString = "Left"
        Me.gridpersonal.DisplayLayout.Override.HeaderAppearance = Appearance141
        Me.gridpersonal.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridpersonal.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridpersonal.DisplayLayout.Override.MinRowHeight = 24
        Appearance142.BackColor = System.Drawing.SystemColors.Window
        Appearance142.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance142.TextVAlignAsString = "Middle"
        Me.gridpersonal.DisplayLayout.Override.RowAppearance = Appearance142
        Me.gridpersonal.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridpersonal.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridpersonal.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance143.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridpersonal.DisplayLayout.Override.TemplateAddRowAppearance = Appearance143
        Me.gridpersonal.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridpersonal.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridpersonal.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridpersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridpersonal.Location = New System.Drawing.Point(65, 19)
        Me.gridpersonal.Name = "gridpersonal"
        Me.gridpersonal.Size = New System.Drawing.Size(690, 266)
        Me.gridpersonal.TabIndex = 251
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.UltraLabel18)
        Me.UltraTabPageControl5.Controls.Add(Me.txttotmaterial)
        Me.UltraTabPageControl5.Controls.Add(Me.Button5)
        Me.UltraTabPageControl5.Controls.Add(Me.Button2)
        Me.UltraTabPageControl5.Controls.Add(Me.gridmaterial)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(972, 285)
        '
        'UltraLabel18
        '
        Me.UltraLabel18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance177.BackColor = System.Drawing.Color.Transparent
        Appearance177.TextHAlignAsString = "Left"
        Me.UltraLabel18.Appearance = Appearance177
        Me.UltraLabel18.AutoSize = True
        Me.UltraLabel18.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel18.Location = New System.Drawing.Point(761, 227)
        Me.UltraLabel18.Name = "UltraLabel18"
        Me.UltraLabel18.Size = New System.Drawing.Size(126, 17)
        Me.UltraLabel18.TabIndex = 266
        Me.UltraLabel18.Text = "Costo total de materiales"
        '
        'txttotmaterial
        '
        Me.txttotmaterial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance174.TextHAlignAsString = "Right"
        Appearance174.TextVAlignAsString = "Middle"
        Me.txttotmaterial.Appearance = Appearance174
        Me.txttotmaterial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotmaterial.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttotmaterial.Location = New System.Drawing.Point(761, 250)
        Me.txttotmaterial.Name = "txttotmaterial"
        Me.txttotmaterial.ReadOnly = True
        Me.txttotmaterial.Size = New System.Drawing.Size(124, 21)
        Me.txttotmaterial.TabIndex = 265
        Me.txttotmaterial.TabStop = False
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Image = Global.SIP_Presentacion.My.Resources.Resources.delete_icon
        Me.Button5.Location = New System.Drawing.Point(761, 49)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(28, 25)
        Me.Button5.TabIndex = 255
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Image = Global.SIP_Presentacion.My.Resources.Resources.add_icon
        Me.Button2.Location = New System.Drawing.Point(761, 18)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(28, 25)
        Me.Button2.TabIndex = 254
        Me.Button2.UseVisualStyleBackColor = True
        '
        'gridmaterial
        '
        Me.gridmaterial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance144.BackColor = System.Drawing.SystemColors.Window
        Appearance144.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridmaterial.DisplayLayout.Appearance = Appearance144
        Me.gridmaterial.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance145.Image = CType(resources.GetObject("Appearance145.Image"), Object)
        Appearance145.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance145.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn12.Header.Appearance = Appearance145
        UltraGridColumn12.Header.Caption = ""
        UltraGridColumn12.Header.VisiblePosition = 0
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.MaxWidth = 25
        UltraGridColumn12.MinWidth = 20
        UltraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn12.Width = 20
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.Header.VisiblePosition = 1
        UltraGridColumn13.Width = 54
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn14.Header.VisiblePosition = 2
        UltraGridColumn14.Width = 257
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn15.Header.Caption = "UNID"
        UltraGridColumn15.Header.VisiblePosition = 3
        UltraGridColumn15.Width = 40
        Appearance161.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance161
        UltraGridColumn16.Header.VisiblePosition = 4
        UltraGridColumn16.MaskInput = "{double:9.2}"
        UltraGridColumn16.Width = 70
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance162.TextHAlignAsString = "Right"
        UltraGridColumn17.CellAppearance = Appearance162
        UltraGridColumn17.Header.Caption = "PRECIO"
        UltraGridColumn17.Header.VisiblePosition = 5
        UltraGridColumn17.MaskInput = "{double:9.2}"
        UltraGridColumn17.Width = 67
        Appearance163.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance163
        UltraGridColumn18.Header.Caption = "P. ESTIMADO"
        UltraGridColumn18.Header.VisiblePosition = 6
        UltraGridColumn18.MaskInput = "{double:9.2}"
        UltraGridColumn18.Width = 83
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance164.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance164
        UltraGridColumn19.Header.VisiblePosition = 7
        UltraGridColumn19.MaskInput = "{double:9.2}"
        UltraGridColumn19.Width = 62
        UltraGridColumn20.Header.VisiblePosition = 8
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.Width = 93
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20})
        Me.gridmaterial.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.gridmaterial.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridmaterial.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion30)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion31)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion32)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion33)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion34)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion35)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion36)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion37)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion38)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion39)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion40)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion41)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion42)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion43)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion44)
        Me.gridmaterial.DisplayLayout.ColScrollRegions.Add(ColScrollRegion45)
        Me.gridmaterial.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance146.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance146.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance146.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance146.BorderColor = System.Drawing.SystemColors.Window
        Me.gridmaterial.DisplayLayout.GroupByBox.Appearance = Appearance146
        Appearance147.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridmaterial.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance147
        Me.gridmaterial.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridmaterial.DisplayLayout.GroupByBox.Hidden = True
        Appearance148.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance148.BackColor2 = System.Drawing.SystemColors.Control
        Appearance148.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance148.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridmaterial.DisplayLayout.GroupByBox.PromptAppearance = Appearance148
        Me.gridmaterial.DisplayLayout.MaxColScrollRegions = 1
        Me.gridmaterial.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridmaterial.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridmaterial.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridmaterial.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance149.BackColor = System.Drawing.SystemColors.Window
        Me.gridmaterial.DisplayLayout.Override.CardAreaAppearance = Appearance149
        Appearance150.BorderColor = System.Drawing.Color.Silver
        Appearance150.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridmaterial.DisplayLayout.Override.CellAppearance = Appearance150
        Me.gridmaterial.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridmaterial.DisplayLayout.Override.CellPadding = 0
        Me.gridmaterial.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridmaterial.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridmaterial.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridmaterial.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance151.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance151.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridmaterial.DisplayLayout.Override.FilterRowAppearance = Appearance151
        Me.gridmaterial.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridmaterial.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance152.BackColor = System.Drawing.SystemColors.Control
        Appearance152.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance152.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance152.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance152.BorderColor = System.Drawing.SystemColors.Window
        Me.gridmaterial.DisplayLayout.Override.GroupByRowAppearance = Appearance152
        Appearance153.FontData.Name = "Arial Narrow"
        Appearance153.FontData.SizeInPoints = 10.0!
        Appearance153.TextHAlignAsString = "Left"
        Me.gridmaterial.DisplayLayout.Override.HeaderAppearance = Appearance153
        Me.gridmaterial.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridmaterial.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridmaterial.DisplayLayout.Override.MinRowHeight = 24
        Appearance154.BackColor = System.Drawing.SystemColors.Window
        Appearance154.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance154.TextVAlignAsString = "Middle"
        Me.gridmaterial.DisplayLayout.Override.RowAppearance = Appearance154
        Me.gridmaterial.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridmaterial.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridmaterial.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance155.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridmaterial.DisplayLayout.Override.TemplateAddRowAppearance = Appearance155
        Me.gridmaterial.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridmaterial.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridmaterial.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridmaterial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridmaterial.Location = New System.Drawing.Point(65, 18)
        Me.gridmaterial.Name = "gridmaterial"
        Me.gridmaterial.Size = New System.Drawing.Size(690, 253)
        Me.gridmaterial.TabIndex = 252
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.UltraLabel19)
        Me.UltraTabPageControl6.Controls.Add(Me.txttotservicio)
        Me.UltraTabPageControl6.Controls.Add(Me.Button6)
        Me.UltraTabPageControl6.Controls.Add(Me.Button3)
        Me.UltraTabPageControl6.Controls.Add(Me.gridServicio)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(972, 285)
        '
        'UltraLabel19
        '
        Me.UltraLabel19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance79.BackColor = System.Drawing.Color.Transparent
        Appearance79.TextHAlignAsString = "Left"
        Me.UltraLabel19.Appearance = Appearance79
        Me.UltraLabel19.AutoSize = True
        Me.UltraLabel19.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel19.Location = New System.Drawing.Point(761, 228)
        Me.UltraLabel19.Name = "UltraLabel19"
        Me.UltraLabel19.Size = New System.Drawing.Size(118, 17)
        Me.UltraLabel19.TabIndex = 266
        Me.UltraLabel19.Text = "Costo total de servicios"
        '
        'txttotservicio
        '
        Me.txttotservicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance106.TextHAlignAsString = "Right"
        Appearance106.TextVAlignAsString = "Middle"
        Me.txttotservicio.Appearance = Appearance106
        Me.txttotservicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotservicio.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttotservicio.Location = New System.Drawing.Point(761, 251)
        Me.txttotservicio.Name = "txttotservicio"
        Me.txttotservicio.ReadOnly = True
        Me.txttotservicio.Size = New System.Drawing.Size(124, 21)
        Me.txttotservicio.TabIndex = 265
        Me.txttotservicio.TabStop = False
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.Image = Global.SIP_Presentacion.My.Resources.Resources.delete_icon
        Me.Button6.Location = New System.Drawing.Point(761, 50)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(28, 25)
        Me.Button6.TabIndex = 256
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Image = Global.SIP_Presentacion.My.Resources.Resources.add_icon
        Me.Button3.Location = New System.Drawing.Point(761, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(28, 25)
        Me.Button3.TabIndex = 254
        Me.Button3.UseVisualStyleBackColor = True
        '
        'gridServicio
        '
        Me.gridServicio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance41.BackColor = System.Drawing.SystemColors.Window
        Appearance41.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridServicio.DisplayLayout.Appearance = Appearance41
        Me.gridServicio.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn21.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance42.Image = CType(resources.GetObject("Appearance42.Image"), Object)
        Appearance42.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance42.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn21.Header.Appearance = Appearance42
        UltraGridColumn21.Header.Caption = ""
        UltraGridColumn21.Header.VisiblePosition = 0
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.MaxWidth = 25
        UltraGridColumn21.MinWidth = 20
        UltraGridColumn21.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn21.Width = 20
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn22.Header.VisiblePosition = 1
        UltraGridColumn22.Width = 56
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn23.Header.VisiblePosition = 2
        UltraGridColumn23.Width = 273
        Appearance165.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance165
        UltraGridColumn24.Header.VisiblePosition = 3
        UltraGridColumn24.MaskInput = "{double:9.2}"
        UltraGridColumn24.Width = 79
        Appearance166.TextHAlignAsString = "Right"
        UltraGridColumn25.CellAppearance = Appearance166
        UltraGridColumn25.Header.Caption = "PRECIO"
        UltraGridColumn25.Header.VisiblePosition = 4
        UltraGridColumn25.MaskInput = "{double:9.2}"
        UltraGridColumn25.Width = 70
        Appearance167.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance167
        UltraGridColumn26.Header.Caption = "P. ESTIMADO"
        UltraGridColumn26.Header.VisiblePosition = 5
        UltraGridColumn26.MaskInput = "{double:9.2}"
        UltraGridColumn26.Width = 83
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance168.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance168
        UltraGridColumn27.Header.VisiblePosition = 6
        UltraGridColumn27.MaskInput = "{double:9.2}"
        UltraGridColumn27.Width = 72
        UltraGridColumn28.Header.VisiblePosition = 7
        UltraGridColumn28.Hidden = True
        UltraGridColumn28.Width = 93
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28})
        Me.gridServicio.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.gridServicio.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridServicio.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion46)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion47)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion48)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion49)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion50)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion51)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion52)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion53)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion54)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion55)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion56)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion57)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion58)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion59)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion60)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion61)
        Me.gridServicio.DisplayLayout.ColScrollRegions.Add(ColScrollRegion62)
        Me.gridServicio.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance44.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance44.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance44.BorderColor = System.Drawing.SystemColors.Window
        Me.gridServicio.DisplayLayout.GroupByBox.Appearance = Appearance44
        Appearance45.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridServicio.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance45
        Me.gridServicio.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridServicio.DisplayLayout.GroupByBox.Hidden = True
        Appearance46.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance46.BackColor2 = System.Drawing.SystemColors.Control
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance46.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridServicio.DisplayLayout.GroupByBox.PromptAppearance = Appearance46
        Me.gridServicio.DisplayLayout.MaxColScrollRegions = 1
        Me.gridServicio.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridServicio.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridServicio.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridServicio.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Me.gridServicio.DisplayLayout.Override.CardAreaAppearance = Appearance47
        Appearance48.BorderColor = System.Drawing.Color.Silver
        Appearance48.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridServicio.DisplayLayout.Override.CellAppearance = Appearance48
        Me.gridServicio.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridServicio.DisplayLayout.Override.CellPadding = 0
        Me.gridServicio.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridServicio.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridServicio.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridServicio.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance49.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance49.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridServicio.DisplayLayout.Override.FilterRowAppearance = Appearance49
        Me.gridServicio.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridServicio.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance50.BackColor = System.Drawing.SystemColors.Control
        Appearance50.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance50.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance50.BorderColor = System.Drawing.SystemColors.Window
        Me.gridServicio.DisplayLayout.Override.GroupByRowAppearance = Appearance50
        Appearance51.FontData.Name = "Arial Narrow"
        Appearance51.FontData.SizeInPoints = 10.0!
        Appearance51.TextHAlignAsString = "Left"
        Me.gridServicio.DisplayLayout.Override.HeaderAppearance = Appearance51
        Me.gridServicio.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridServicio.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridServicio.DisplayLayout.Override.MinRowHeight = 24
        Appearance52.BackColor = System.Drawing.SystemColors.Window
        Appearance52.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance52.TextVAlignAsString = "Middle"
        Me.gridServicio.DisplayLayout.Override.RowAppearance = Appearance52
        Me.gridServicio.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridServicio.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridServicio.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance53.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridServicio.DisplayLayout.Override.TemplateAddRowAppearance = Appearance53
        Me.gridServicio.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridServicio.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridServicio.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridServicio.Location = New System.Drawing.Point(65, 19)
        Me.gridServicio.Name = "gridServicio"
        Me.gridServicio.Size = New System.Drawing.Size(690, 253)
        Me.gridServicio.TabIndex = 253
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.panel)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1024, 506)
        '
        'panel
        '
        Me.panel.BackColor = System.Drawing.Color.Transparent
        Me.panel.Controls.Add(Me.gridProyecto)
        Me.panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel.Location = New System.Drawing.Point(0, 0)
        Me.panel.Name = "panel"
        Me.panel.Size = New System.Drawing.Size(1024, 506)
        Me.panel.TabIndex = 176
        '
        'gridProyecto
        '
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridProyecto.DisplayLayout.Appearance = Appearance28
        Me.gridProyecto.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn29.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance29.Image = CType(resources.GetObject("Appearance29.Image"), Object)
        Appearance29.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance29.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn29.Header.Appearance = Appearance29
        UltraGridColumn29.Header.Caption = ""
        UltraGridColumn29.Header.VisiblePosition = 0
        UltraGridColumn29.Hidden = True
        UltraGridColumn29.MaxWidth = 25
        UltraGridColumn29.MinWidth = 20
        UltraGridColumn29.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn29.Width = 20
        UltraGridColumn30.Header.VisiblePosition = 1
        UltraGridColumn30.Hidden = True
        UltraGridColumn30.Width = 84
        UltraGridColumn31.Header.VisiblePosition = 2
        UltraGridColumn31.Hidden = True
        UltraGridColumn31.Width = 108
        UltraGridColumn32.Header.VisiblePosition = 3
        UltraGridColumn32.Hidden = True
        UltraGridColumn32.Width = 116
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn33.Header.VisiblePosition = 4
        UltraGridColumn33.Width = 226
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn34.Header.VisiblePosition = 5
        UltraGridColumn34.Width = 306
        UltraGridColumn35.Header.VisiblePosition = 6
        UltraGridColumn35.Hidden = True
        UltraGridColumn35.Width = 72
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn36.Header.VisiblePosition = 7
        UltraGridColumn36.Width = 230
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn37.Header.VisiblePosition = 8
        UltraGridColumn37.Width = 122
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn38.Header.VisiblePosition = 9
        UltraGridColumn38.Hidden = True
        UltraGridColumn38.Width = 91
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn39.Header.VisiblePosition = 10
        UltraGridColumn39.Width = 100
        UltraGridColumn40.Header.VisiblePosition = 11
        UltraGridColumn40.Hidden = True
        UltraGridColumn40.Width = 99
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40})
        Me.gridProyecto.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.gridProyecto.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridProyecto.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion63)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion64)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion65)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion66)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion67)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion68)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion69)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion70)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion71)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion72)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion73)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion74)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion75)
        Me.gridProyecto.DisplayLayout.ColScrollRegions.Add(ColScrollRegion76)
        Me.gridProyecto.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance30.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance30.BorderColor = System.Drawing.SystemColors.Window
        Me.gridProyecto.DisplayLayout.GroupByBox.Appearance = Appearance30
        Appearance31.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridProyecto.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance31
        Me.gridProyecto.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridProyecto.DisplayLayout.GroupByBox.Hidden = True
        Appearance32.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance32.BackColor2 = System.Drawing.SystemColors.Control
        Appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance32.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridProyecto.DisplayLayout.GroupByBox.PromptAppearance = Appearance32
        Me.gridProyecto.DisplayLayout.MaxColScrollRegions = 1
        Me.gridProyecto.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridProyecto.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridProyecto.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridProyecto.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance33.BackColor = System.Drawing.SystemColors.Window
        Me.gridProyecto.DisplayLayout.Override.CardAreaAppearance = Appearance33
        Appearance34.BorderColor = System.Drawing.Color.Silver
        Appearance34.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridProyecto.DisplayLayout.Override.CellAppearance = Appearance34
        Me.gridProyecto.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridProyecto.DisplayLayout.Override.CellPadding = 0
        Me.gridProyecto.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridProyecto.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridProyecto.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridProyecto.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance35.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance35.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridProyecto.DisplayLayout.Override.FilterRowAppearance = Appearance35
        Me.gridProyecto.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridProyecto.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Me.gridProyecto.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance36.BackColor = System.Drawing.SystemColors.Control
        Appearance36.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance36.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance36.BorderColor = System.Drawing.SystemColors.Window
        Me.gridProyecto.DisplayLayout.Override.GroupByRowAppearance = Appearance36
        Appearance37.FontData.Name = "Arial Narrow"
        Appearance37.FontData.SizeInPoints = 10.0!
        Appearance37.TextHAlignAsString = "Left"
        Me.gridProyecto.DisplayLayout.Override.HeaderAppearance = Appearance37
        Me.gridProyecto.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridProyecto.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridProyecto.DisplayLayout.Override.MinRowHeight = 24
        Appearance83.BackColor = System.Drawing.SystemColors.Window
        Appearance83.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance83.TextVAlignAsString = "Middle"
        Me.gridProyecto.DisplayLayout.Override.RowAppearance = Appearance83
        Me.gridProyecto.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridProyecto.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridProyecto.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance39.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridProyecto.DisplayLayout.Override.TemplateAddRowAppearance = Appearance39
        Me.gridProyecto.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridProyecto.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridProyecto.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridProyecto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridProyecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridProyecto.Location = New System.Drawing.Point(0, 0)
        Me.gridProyecto.Name = "gridProyecto"
        Me.gridProyecto.Size = New System.Drawing.Size(1024, 506)
        Me.gridProyecto.TabIndex = 195
        '
        'rdbCore
        '
        Me.rdbCore.Controls.Add(Me.Button8)
        Me.rdbCore.Controls.Add(Me.gridplano)
        Me.rdbCore.Controls.Add(Me.gridsubtarea)
        Me.rdbCore.Controls.Add(Me.UltraLabel20)
        Me.rdbCore.Controls.Add(Me.cmbTipo)
        Me.rdbCore.Controls.Add(Me.rdbCorrectiva)
        Me.rdbCore.Controls.Add(Me.rdbnoPlanificada)
        Me.rdbCore.Controls.Add(Me.rdbPlanificada)
        Me.rdbCore.Controls.Add(Me.txtplano)
        Me.rdbCore.Controls.Add(Me.UltraLabel13)
        Me.rdbCore.Controls.Add(Me.txtidequipo)
        Me.rdbCore.Controls.Add(Me.txtidtaller)
        Me.rdbCore.Controls.Add(Me.txtidproyecto)
        Me.rdbCore.Controls.Add(Me.txtsubtarea)
        Me.rdbCore.Controls.Add(Me.UltraLabel6)
        Me.rdbCore.Controls.Add(Me.gridTarea)
        Me.rdbCore.Controls.Add(Me.txttarea)
        Me.rdbCore.Controls.Add(Me.UltraLabel3)
        Me.rdbCore.Controls.Add(Me.txtequipo)
        Me.rdbCore.Controls.Add(Me.UltraLabel5)
        Me.rdbCore.Controls.Add(Me.UltraLabel2)
        Me.rdbCore.Controls.Add(Me.dtFecha)
        Me.rdbCore.Controls.Add(Me.txttaller)
        Me.rdbCore.Controls.Add(Me.UltraLabel1)
        Me.rdbCore.Controls.Add(Me.txtid)
        Me.rdbCore.Controls.Add(Me.txtproyecto)
        Me.rdbCore.Controls.Add(Me.UltraLabel4)
        Me.rdbCore.Location = New System.Drawing.Point(1, 35)
        Me.rdbCore.Name = "rdbCore"
        Me.rdbCore.Size = New System.Drawing.Size(1024, 506)
        '
        'Button8
        '
        Me.Button8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button8.Image = Global.SIP_Presentacion.My.Resources.Resources.add_icon
        Me.Button8.Location = New System.Drawing.Point(894, 139)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(28, 25)
        Me.Button8.TabIndex = 263
        Me.Button8.UseVisualStyleBackColor = True
        '
        'gridplano
        '
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridplano.DisplayLayout.Appearance = Appearance2
        Me.gridplano.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn41.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance3.Image = CType(resources.GetObject("Appearance3.Image"), Object)
        Appearance3.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn41.Header.Appearance = Appearance3
        UltraGridColumn41.Header.Caption = ""
        UltraGridColumn41.Header.VisiblePosition = 0
        UltraGridColumn41.Hidden = True
        UltraGridColumn41.MaxWidth = 25
        UltraGridColumn41.MinWidth = 20
        UltraGridColumn41.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn41.Width = 20
        UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn42.Header.VisiblePosition = 1
        UltraGridColumn42.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn42.Width = 123
        UltraGridColumn43.Header.Caption = ""
        UltraGridColumn43.Header.VisiblePosition = 2
        UltraGridColumn43.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.URL
        UltraGridColumn43.Width = 68
        UltraGridColumn44.Header.VisiblePosition = 3
        UltraGridColumn44.Hidden = True
        UltraGridColumn44.Width = 72
        UltraGridBand6.Columns.AddRange(New Object() {UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44})
        Me.gridplano.DisplayLayout.BandsSerializer.Add(UltraGridBand6)
        Me.gridplano.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridplano.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion77)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion78)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion79)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion80)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion81)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion82)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion83)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion84)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion85)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion86)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion87)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion88)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion89)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion90)
        Me.gridplano.DisplayLayout.ColScrollRegions.Add(ColScrollRegion91)
        Me.gridplano.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.gridplano.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridplano.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
        Me.gridplano.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridplano.DisplayLayout.GroupByBox.Hidden = True
        Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance8.BackColor2 = System.Drawing.SystemColors.Control
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridplano.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
        Me.gridplano.DisplayLayout.MaxColScrollRegions = 1
        Me.gridplano.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridplano.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridplano.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridplano.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.gridplano.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridplano.DisplayLayout.Override.CellAppearance = Appearance11
        Me.gridplano.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridplano.DisplayLayout.Override.CellPadding = 0
        Me.gridplano.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridplano.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridplano.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridplano.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance12.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance12.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridplano.DisplayLayout.Override.FilterRowAppearance = Appearance12
        Me.gridplano.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridplano.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance13.BackColor = System.Drawing.SystemColors.Control
        Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance13.BorderColor = System.Drawing.SystemColors.Window
        Me.gridplano.DisplayLayout.Override.GroupByRowAppearance = Appearance13
        Appearance14.FontData.Name = "Arial Narrow"
        Appearance14.FontData.SizeInPoints = 10.0!
        Appearance14.TextHAlignAsString = "Left"
        Me.gridplano.DisplayLayout.Override.HeaderAppearance = Appearance14
        Me.gridplano.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridplano.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridplano.DisplayLayout.Override.MinRowHeight = 24
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance15.TextVAlignAsString = "Middle"
        Me.gridplano.DisplayLayout.Override.RowAppearance = Appearance15
        Me.gridplano.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridplano.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridplano.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridplano.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
        Me.gridplano.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridplano.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridplano.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridplano.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridplano.Location = New System.Drawing.Point(688, 29)
        Me.gridplano.Name = "gridplano"
        Me.gridplano.Size = New System.Drawing.Size(248, 101)
        Me.gridplano.TabIndex = 262
        '
        'gridsubtarea
        '
        Me.gridsubtarea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance120.BackColor = System.Drawing.SystemColors.Window
        Appearance120.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridsubtarea.DisplayLayout.Appearance = Appearance120
        Me.gridsubtarea.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn45.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance121.Image = CType(resources.GetObject("Appearance121.Image"), Object)
        Appearance121.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance121.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn45.Header.Appearance = Appearance121
        UltraGridColumn45.Header.Caption = ""
        UltraGridColumn45.Header.VisiblePosition = 0
        UltraGridColumn45.Hidden = True
        UltraGridColumn45.MaxWidth = 25
        UltraGridColumn45.MinWidth = 20
        UltraGridColumn45.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn45.Width = 20
        UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn46.Header.VisiblePosition = 1
        UltraGridColumn46.Hidden = True
        UltraGridColumn46.Width = 35
        UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn47.Header.VisiblePosition = 2
        UltraGridColumn47.Hidden = True
        UltraGridColumn47.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn47.Width = 76
        UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn48.Header.Caption = ""
        UltraGridColumn48.Header.VisiblePosition = 7
        UltraGridColumn48.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn48.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.URL
        UltraGridColumn48.Width = 42
        UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn49.Header.VisiblePosition = 4
        UltraGridColumn49.Width = 258
        UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn50.Header.VisiblePosition = 3
        UltraGridColumn50.Width = 40
        UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn51.Header.VisiblePosition = 5
        UltraGridColumn51.Hidden = True
        UltraGridColumn51.Width = 61
        UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn52.Header.VisiblePosition = 6
        UltraGridColumn52.Width = 75
        UltraGridColumn53.Header.VisiblePosition = 8
        UltraGridColumn53.Hidden = True
        UltraGridColumn53.Width = 56
        UltraGridBand7.Columns.AddRange(New Object() {UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53})
        Me.gridsubtarea.DisplayLayout.BandsSerializer.Add(UltraGridBand7)
        Me.gridsubtarea.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridsubtarea.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion92)
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion93)
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion94)
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion95)
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion96)
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion97)
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion98)
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion99)
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion100)
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion101)
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion102)
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion103)
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion104)
        Me.gridsubtarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion105)
        Me.gridsubtarea.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance122.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance122.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance122.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance122.BorderColor = System.Drawing.SystemColors.Window
        Me.gridsubtarea.DisplayLayout.GroupByBox.Appearance = Appearance122
        Appearance123.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridsubtarea.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance123
        Me.gridsubtarea.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridsubtarea.DisplayLayout.GroupByBox.Hidden = True
        Appearance124.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance124.BackColor2 = System.Drawing.SystemColors.Control
        Appearance124.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance124.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridsubtarea.DisplayLayout.GroupByBox.PromptAppearance = Appearance124
        Me.gridsubtarea.DisplayLayout.MaxColScrollRegions = 1
        Me.gridsubtarea.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridsubtarea.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridsubtarea.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridsubtarea.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance125.BackColor = System.Drawing.SystemColors.Window
        Me.gridsubtarea.DisplayLayout.Override.CardAreaAppearance = Appearance125
        Appearance126.BorderColor = System.Drawing.Color.Silver
        Appearance126.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridsubtarea.DisplayLayout.Override.CellAppearance = Appearance126
        Me.gridsubtarea.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridsubtarea.DisplayLayout.Override.CellPadding = 0
        Me.gridsubtarea.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridsubtarea.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridsubtarea.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridsubtarea.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance127.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance127.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridsubtarea.DisplayLayout.Override.FilterRowAppearance = Appearance127
        Me.gridsubtarea.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridsubtarea.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance128.BackColor = System.Drawing.SystemColors.Control
        Appearance128.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance128.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance128.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance128.BorderColor = System.Drawing.SystemColors.Window
        Me.gridsubtarea.DisplayLayout.Override.GroupByRowAppearance = Appearance128
        Appearance129.FontData.Name = "Arial Narrow"
        Appearance129.FontData.SizeInPoints = 10.0!
        Appearance129.TextHAlignAsString = "Left"
        Me.gridsubtarea.DisplayLayout.Override.HeaderAppearance = Appearance129
        Me.gridsubtarea.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridsubtarea.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridsubtarea.DisplayLayout.Override.MinRowHeight = 24
        Appearance130.BackColor = System.Drawing.SystemColors.Window
        Appearance130.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance130.TextVAlignAsString = "Middle"
        Me.gridsubtarea.DisplayLayout.Override.RowAppearance = Appearance130
        Me.gridsubtarea.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridsubtarea.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridsubtarea.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance131.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridsubtarea.DisplayLayout.Override.TemplateAddRowAppearance = Appearance131
        Me.gridsubtarea.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridsubtarea.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridsubtarea.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridsubtarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridsubtarea.Location = New System.Drawing.Point(529, 169)
        Me.gridsubtarea.Name = "gridsubtarea"
        Me.gridsubtarea.Size = New System.Drawing.Size(455, 320)
        Me.gridsubtarea.TabIndex = 250
        '
        'UltraLabel20
        '
        Appearance22.BackColor = System.Drawing.Color.Transparent
        Appearance22.TextHAlignAsString = "Left"
        Me.UltraLabel20.Appearance = Appearance22
        Me.UltraLabel20.AutoSize = True
        Me.UltraLabel20.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel20.Location = New System.Drawing.Point(293, 85)
        Me.UltraLabel20.Name = "UltraLabel20"
        Me.UltraLabel20.Size = New System.Drawing.Size(26, 17)
        Me.UltraLabel20.TabIndex = 261
        Me.UltraLabel20.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbTipo.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem13.DataValue = "0"
        ValueListItem13.DisplayText = "PLANIFICADA"
        ValueListItem14.DataValue = "2"
        ValueListItem14.DisplayText = "NO-PLANIFICADA"
        ValueListItem15.DataValue = "1"
        ValueListItem15.DisplayText = "CORRECTIVA"
        Me.cmbTipo.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem13, ValueListItem14, ValueListItem15})
        Me.cmbTipo.Location = New System.Drawing.Point(322, 84)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(132, 21)
        Me.cmbTipo.TabIndex = 260
        '
        'rdbCorrectiva
        '
        Me.rdbCorrectiva.AutoSize = True
        Me.rdbCorrectiva.BackColor = System.Drawing.Color.Transparent
        Me.rdbCorrectiva.Location = New System.Drawing.Point(874, 300)
        Me.rdbCorrectiva.Name = "rdbCorrectiva"
        Me.rdbCorrectiva.Size = New System.Drawing.Size(73, 17)
        Me.rdbCorrectiva.TabIndex = 259
        Me.rdbCorrectiva.Text = "Correctiva"
        Me.rdbCorrectiva.UseVisualStyleBackColor = False
        Me.rdbCorrectiva.Visible = False
        '
        'rdbnoPlanificada
        '
        Me.rdbnoPlanificada.AutoSize = True
        Me.rdbnoPlanificada.BackColor = System.Drawing.Color.Transparent
        Me.rdbnoPlanificada.Location = New System.Drawing.Point(874, 282)
        Me.rdbnoPlanificada.Name = "rdbnoPlanificada"
        Me.rdbnoPlanificada.Size = New System.Drawing.Size(94, 17)
        Me.rdbnoPlanificada.TabIndex = 258
        Me.rdbnoPlanificada.Text = "No-Planificada"
        Me.rdbnoPlanificada.UseVisualStyleBackColor = False
        Me.rdbnoPlanificada.Visible = False
        '
        'rdbPlanificada
        '
        Me.rdbPlanificada.AutoSize = True
        Me.rdbPlanificada.BackColor = System.Drawing.Color.Transparent
        Me.rdbPlanificada.Checked = True
        Me.rdbPlanificada.Location = New System.Drawing.Point(874, 264)
        Me.rdbPlanificada.Name = "rdbPlanificada"
        Me.rdbPlanificada.Size = New System.Drawing.Size(77, 17)
        Me.rdbPlanificada.TabIndex = 257
        Me.rdbPlanificada.TabStop = True
        Me.rdbPlanificada.Text = "Planificada"
        Me.rdbPlanificada.UseVisualStyleBackColor = False
        Me.rdbPlanificada.Visible = False
        '
        'txtplano
        '
        Appearance26.TextHAlignAsString = "Left"
        Appearance26.TextVAlignAsString = "Middle"
        Me.txtplano.Appearance = Appearance26
        Me.txtplano.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtplano.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtplano.Location = New System.Drawing.Point(543, 31)
        Me.txtplano.Name = "txtplano"
        Me.txtplano.Size = New System.Drawing.Size(139, 21)
        Me.txtplano.TabIndex = 255
        Me.txtplano.TabStop = False
        '
        'UltraLabel13
        '
        Appearance68.BackColor = System.Drawing.Color.Transparent
        Appearance68.TextHAlignAsString = "Left"
        Me.UltraLabel13.Appearance = Appearance68
        Me.UltraLabel13.AutoSize = True
        Me.UltraLabel13.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel13.Location = New System.Drawing.Point(492, 31)
        Me.UltraLabel13.Name = "UltraLabel13"
        Me.UltraLabel13.Size = New System.Drawing.Size(45, 17)
        Me.UltraLabel13.TabIndex = 254
        Me.UltraLabel13.Text = "Planos :"
        '
        'txtidequipo
        '
        Appearance40.TextHAlignAsString = "Left"
        Appearance40.TextVAlignAsString = "Middle"
        Me.txtidequipo.Appearance = Appearance40
        Me.txtidequipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidequipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtidequipo.Location = New System.Drawing.Point(839, 109)
        Me.txtidequipo.Name = "txtidequipo"
        Me.txtidequipo.ReadOnly = True
        Me.txtidequipo.Size = New System.Drawing.Size(129, 21)
        Me.txtidequipo.TabIndex = 253
        Me.txtidequipo.TabStop = False
        Me.txtidequipo.Visible = False
        '
        'txtidtaller
        '
        Appearance82.TextHAlignAsString = "Left"
        Appearance82.TextVAlignAsString = "Middle"
        Me.txtidtaller.Appearance = Appearance82
        Me.txtidtaller.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidtaller.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtidtaller.Location = New System.Drawing.Point(839, 56)
        Me.txtidtaller.Name = "txtidtaller"
        Me.txtidtaller.ReadOnly = True
        Me.txtidtaller.Size = New System.Drawing.Size(129, 21)
        Me.txtidtaller.TabIndex = 252
        Me.txtidtaller.TabStop = False
        Me.txtidtaller.Visible = False
        '
        'txtidproyecto
        '
        Appearance80.TextHAlignAsString = "Left"
        Appearance80.TextVAlignAsString = "Middle"
        Me.txtidproyecto.Appearance = Appearance80
        Me.txtidproyecto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidproyecto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtidproyecto.Location = New System.Drawing.Point(839, 29)
        Me.txtidproyecto.Name = "txtidproyecto"
        Me.txtidproyecto.ReadOnly = True
        Me.txtidproyecto.Size = New System.Drawing.Size(129, 21)
        Me.txtidproyecto.TabIndex = 251
        Me.txtidproyecto.TabStop = False
        Me.txtidproyecto.Visible = False
        '
        'txtsubtarea
        '
        Appearance6.TextHAlignAsString = "Left"
        Appearance6.TextVAlignAsString = "Middle"
        Me.txtsubtarea.Appearance = Appearance6
        Me.txtsubtarea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsubtarea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtsubtarea.Location = New System.Drawing.Point(529, 139)
        Me.txtsubtarea.Name = "txtsubtarea"
        Me.txtsubtarea.ReadOnly = True
        Me.txtsubtarea.Size = New System.Drawing.Size(422, 21)
        Me.txtsubtarea.TabIndex = 249
        Me.txtsubtarea.TabStop = False
        '
        'UltraLabel6
        '
        Appearance180.BackColor = System.Drawing.Color.Transparent
        Appearance180.TextHAlignAsString = "Left"
        Me.UltraLabel6.Appearance = Appearance180
        Me.UltraLabel6.AutoSize = True
        Me.UltraLabel6.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel6.Location = New System.Drawing.Point(460, 141)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(63, 17)
        Me.UltraLabel6.TabIndex = 248
        Me.UltraLabel6.Text = "Sub-Tarea :"
        '
        'gridTarea
        '
        Me.gridTarea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance108.BackColor = System.Drawing.SystemColors.Window
        Appearance108.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridTarea.DisplayLayout.Appearance = Appearance108
        Me.gridTarea.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn54.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn54.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Appearance109.Image = CType(resources.GetObject("Appearance109.Image"), Object)
        Appearance109.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance109.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn54.Header.Appearance = Appearance109
        UltraGridColumn54.Header.Caption = ""
        UltraGridColumn54.Header.VisiblePosition = 0
        UltraGridColumn54.Hidden = True
        UltraGridColumn54.MaxWidth = 25
        UltraGridColumn54.MinWidth = 20
        UltraGridColumn54.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn54.Width = 20
        UltraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn55.Header.VisiblePosition = 1
        UltraGridColumn55.Hidden = True
        UltraGridColumn55.Width = 19
        UltraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance171.ForeColor = System.Drawing.Color.Black
        UltraGridColumn56.CellAppearance = Appearance171
        UltraGridColumn56.Header.VisiblePosition = 2
        UltraGridColumn56.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn56.Width = 255
        UltraGridColumn57.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn57.Header.Caption = ""
        UltraGridColumn57.Header.VisiblePosition = 3
        UltraGridColumn57.SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled
        UltraGridColumn57.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.URL
        UltraGridColumn57.Width = 88
        UltraGridColumn58.Header.VisiblePosition = 4
        UltraGridColumn58.Hidden = True
        UltraGridColumn58.Width = 87
        UltraGridBand8.Columns.AddRange(New Object() {UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58})
        Me.gridTarea.DisplayLayout.BandsSerializer.Add(UltraGridBand8)
        Me.gridTarea.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridTarea.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridTarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion106)
        Me.gridTarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion107)
        Me.gridTarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion108)
        Me.gridTarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion109)
        Me.gridTarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion110)
        Me.gridTarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion111)
        Me.gridTarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion112)
        Me.gridTarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion113)
        Me.gridTarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion114)
        Me.gridTarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion115)
        Me.gridTarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion116)
        Me.gridTarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion117)
        Me.gridTarea.DisplayLayout.ColScrollRegions.Add(ColScrollRegion118)
        Me.gridTarea.DisplayLayout.EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.ExtendRowSelector
        Appearance110.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance110.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance110.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance110.BorderColor = System.Drawing.SystemColors.Window
        Me.gridTarea.DisplayLayout.GroupByBox.Appearance = Appearance110
        Appearance111.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridTarea.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance111
        Me.gridTarea.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridTarea.DisplayLayout.GroupByBox.Hidden = True
        Appearance112.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance112.BackColor2 = System.Drawing.SystemColors.Control
        Appearance112.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance112.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridTarea.DisplayLayout.GroupByBox.PromptAppearance = Appearance112
        Me.gridTarea.DisplayLayout.MaxColScrollRegions = 1
        Me.gridTarea.DisplayLayout.MaxRowScrollRegions = 1
        Me.gridTarea.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridTarea.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridTarea.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance113.BackColor = System.Drawing.SystemColors.Window
        Me.gridTarea.DisplayLayout.Override.CardAreaAppearance = Appearance113
        Appearance114.BorderColor = System.Drawing.Color.Silver
        Appearance114.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridTarea.DisplayLayout.Override.CellAppearance = Appearance114
        Me.gridTarea.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridTarea.DisplayLayout.Override.CellPadding = 0
        Me.gridTarea.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Hidden
        Me.gridTarea.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Edit
        Me.gridTarea.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Match
        Me.gridTarea.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Appearance115.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance115.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.gridTarea.DisplayLayout.Override.FilterRowAppearance = Appearance115
        Me.gridTarea.DisplayLayout.Override.FilterRowSpacingAfter = 10
        Me.gridTarea.DisplayLayout.Override.FilterRowSpacingBefore = 10
        Appearance116.BackColor = System.Drawing.SystemColors.Control
        Appearance116.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance116.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance116.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance116.BorderColor = System.Drawing.SystemColors.Window
        Me.gridTarea.DisplayLayout.Override.GroupByRowAppearance = Appearance116
        Appearance117.FontData.Name = "Arial Narrow"
        Appearance117.FontData.SizeInPoints = 10.0!
        Appearance117.TextHAlignAsString = "Left"
        Me.gridTarea.DisplayLayout.Override.HeaderAppearance = Appearance117
        Me.gridTarea.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.gridTarea.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard
        Me.gridTarea.DisplayLayout.Override.MinRowHeight = 24
        Appearance118.BackColor = System.Drawing.SystemColors.Window
        Appearance118.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Appearance118.TextVAlignAsString = "Middle"
        Me.gridTarea.DisplayLayout.Override.RowAppearance = Appearance118
        Me.gridTarea.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.gridTarea.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
        Me.gridTarea.DisplayLayout.Override.RowSelectorStyle = Infragistics.Win.HeaderStyle.Standard
        Appearance119.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridTarea.DisplayLayout.Override.TemplateAddRowAppearance = Appearance119
        Me.gridTarea.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridTarea.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridTarea.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
        Me.gridTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridTarea.Location = New System.Drawing.Point(71, 169)
        Me.gridTarea.Name = "gridTarea"
        Me.gridTarea.Size = New System.Drawing.Size(383, 320)
        Me.gridTarea.TabIndex = 246
        '
        'txttarea
        '
        Appearance54.TextHAlignAsString = "Left"
        Appearance54.TextVAlignAsString = "Middle"
        Me.txttarea.Appearance = Appearance54
        Me.txttarea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttarea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttarea.Location = New System.Drawing.Point(71, 139)
        Me.txttarea.Name = "txttarea"
        Me.txttarea.ReadOnly = True
        Me.txttarea.Size = New System.Drawing.Size(383, 21)
        Me.txttarea.TabIndex = 245
        Me.txttarea.TabStop = False
        '
        'UltraLabel3
        '
        Appearance55.BackColor = System.Drawing.Color.Transparent
        Appearance55.TextHAlignAsString = "Left"
        Me.UltraLabel3.Appearance = Appearance55
        Me.UltraLabel3.AutoSize = True
        Me.UltraLabel3.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel3.Location = New System.Drawing.Point(15, 141)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(40, 17)
        Me.UltraLabel3.TabIndex = 244
        Me.UltraLabel3.Text = "Tarea :"
        '
        'txtequipo
        '
        Appearance85.TextHAlignAsString = "Left"
        Appearance85.TextVAlignAsString = "Middle"
        Me.txtequipo.Appearance = Appearance85
        Me.txtequipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtequipo.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtequipo.Location = New System.Drawing.Point(71, 111)
        Me.txtequipo.Name = "txtequipo"
        Me.txtequipo.ReadOnly = True
        Me.txtequipo.Size = New System.Drawing.Size(383, 21)
        Me.txtequipo.TabIndex = 243
        Me.txtequipo.TabStop = False
        '
        'UltraLabel5
        '
        Appearance86.BackColor = System.Drawing.Color.Transparent
        Appearance86.TextHAlignAsString = "Left"
        Me.UltraLabel5.Appearance = Appearance86
        Me.UltraLabel5.AutoSize = True
        Me.UltraLabel5.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel5.Location = New System.Drawing.Point(15, 114)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(45, 17)
        Me.UltraLabel5.TabIndex = 242
        Me.UltraLabel5.Text = "Equipo :"
        '
        'UltraLabel2
        '
        Appearance170.BackColor = System.Drawing.Color.Transparent
        Appearance170.TextHAlignAsString = "Left"
        Me.UltraLabel2.Appearance = Appearance170
        Me.UltraLabel2.AutoSize = True
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel2.Location = New System.Drawing.Point(15, 87)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(82, 17)
        Me.UltraLabel2.TabIndex = 241
        Me.UltraLabel2.Text = "Fecha de Inicio:"
        '
        'dtFecha
        '
        Me.dtFecha.AutoSize = False
        Me.dtFecha.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtFecha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtFecha.Location = New System.Drawing.Point(102, 85)
        Me.dtFecha.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtFecha.Size = New System.Drawing.Size(147, 18)
        Me.dtFecha.TabIndex = 240
        Me.dtFecha.TabStop = False
        Me.dtFecha.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'txttaller
        '
        Appearance89.TextHAlignAsString = "Left"
        Appearance89.TextVAlignAsString = "Middle"
        Me.txttaller.Appearance = Appearance89
        Me.txttaller.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttaller.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttaller.Location = New System.Drawing.Point(71, 58)
        Me.txttaller.Name = "txttaller"
        Me.txttaller.ReadOnly = True
        Me.txttaller.Size = New System.Drawing.Size(383, 21)
        Me.txttaller.TabIndex = 239
        Me.txttaller.TabStop = False
        '
        'UltraLabel1
        '
        Appearance91.BackColor = System.Drawing.Color.Transparent
        Appearance91.TextHAlignAsString = "Left"
        Me.UltraLabel1.Appearance = Appearance91
        Me.UltraLabel1.AutoSize = True
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel1.Location = New System.Drawing.Point(15, 60)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(38, 17)
        Me.UltraLabel1.TabIndex = 238
        Me.UltraLabel1.Text = "Taller :"
        '
        'txtid
        '
        Appearance81.TextHAlignAsString = "Left"
        Appearance81.TextVAlignAsString = "Middle"
        Me.txtid.Appearance = Appearance81
        Me.txtid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtid.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtid.Location = New System.Drawing.Point(71, 6)
        Me.txtid.Name = "txtid"
        Me.txtid.ReadOnly = True
        Me.txtid.Size = New System.Drawing.Size(129, 21)
        Me.txtid.TabIndex = 237
        Me.txtid.TabStop = False
        Me.txtid.Visible = False
        '
        'txtproyecto
        '
        Appearance93.TextHAlignAsString = "Left"
        Appearance93.TextVAlignAsString = "Middle"
        Me.txtproyecto.Appearance = Appearance93
        Me.txtproyecto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtproyecto.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtproyecto.Location = New System.Drawing.Point(71, 30)
        Me.txtproyecto.Name = "txtproyecto"
        Me.txtproyecto.ReadOnly = True
        Me.txtproyecto.Size = New System.Drawing.Size(383, 21)
        Me.txtproyecto.TabIndex = 236
        Me.txtproyecto.TabStop = False
        '
        'UltraLabel4
        '
        Appearance95.BackColor = System.Drawing.Color.Transparent
        Appearance95.TextHAlignAsString = "Left"
        Me.UltraLabel4.Appearance = Appearance95
        Me.UltraLabel4.AutoSize = True
        Me.UltraLabel4.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel4.Location = New System.Drawing.Point(15, 33)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(54, 17)
        Me.UltraLabel4.TabIndex = 235
        Me.UltraLabel4.Text = "Proyecto :"
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.txtsubtareadet)
        Me.UltraTabPageControl3.Controls.Add(Me.txttotalsub)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel16)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel15)
        Me.UltraTabPageControl3.Controls.Add(Me.dtfechasubtarea)
        Me.UltraTabPageControl3.Controls.Add(Me.txtidplanifsub)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel14)
        Me.UltraTabPageControl3.Controls.Add(Me.txtnota)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraTabControl1)
        Me.UltraTabPageControl3.Controls.Add(Me.cmbsubtarea)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel11)
        Me.UltraTabPageControl3.Controls.Add(Me.cmbTarea)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel8)
        Me.UltraTabPageControl3.Controls.Add(Me.txtequipo_det)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel7)
        Me.UltraTabPageControl3.Controls.Add(Me.txttaller_det)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel9)
        Me.UltraTabPageControl3.Controls.Add(Me.txtproyecto_det)
        Me.UltraTabPageControl3.Controls.Add(Me.UltraLabel10)
        Me.UltraTabPageControl3.Enabled = False
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(1024, 506)
        '
        'txtsubtareadet
        '
        Appearance169.TextHAlignAsString = "Left"
        Appearance169.TextVAlignAsString = "Middle"
        Me.txtsubtareadet.Appearance = Appearance169
        Me.txtsubtareadet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsubtareadet.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtsubtareadet.Location = New System.Drawing.Point(79, 115)
        Me.txtsubtareadet.Multiline = True
        Me.txtsubtareadet.Name = "txtsubtareadet"
        Me.txtsubtareadet.Size = New System.Drawing.Size(383, 53)
        Me.txtsubtareadet.TabIndex = 263
        Me.txtsubtareadet.TabStop = False
        '
        'txttotalsub
        '
        Appearance178.TextHAlignAsString = "Right"
        Appearance178.TextVAlignAsString = "Middle"
        Me.txttotalsub.Appearance = Appearance178
        Me.txttotalsub.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotalsub.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttotalsub.Location = New System.Drawing.Point(857, 118)
        Me.txttotalsub.Name = "txttotalsub"
        Me.txttotalsub.ReadOnly = True
        Me.txttotalsub.Size = New System.Drawing.Size(124, 21)
        Me.txttotalsub.TabIndex = 262
        Me.txttotalsub.TabStop = False
        '
        'UltraLabel16
        '
        Appearance179.BackColor = System.Drawing.Color.Transparent
        Appearance179.TextHAlignAsString = "Left"
        Me.UltraLabel16.Appearance = Appearance179
        Me.UltraLabel16.AutoSize = True
        Me.UltraLabel16.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel16.Location = New System.Drawing.Point(486, 120)
        Me.UltraLabel16.Name = "UltraLabel16"
        Me.UltraLabel16.Size = New System.Drawing.Size(128, 17)
        Me.UltraLabel16.TabIndex = 261
        Me.UltraLabel16.Text = "Costo total de sub-tarea :"
        '
        'UltraLabel15
        '
        Appearance87.BackColor = System.Drawing.Color.Transparent
        Appearance87.TextHAlignAsString = "Left"
        Me.UltraLabel15.Appearance = Appearance87
        Me.UltraLabel15.AutoSize = True
        Me.UltraLabel15.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel15.Location = New System.Drawing.Point(486, 16)
        Me.UltraLabel15.Name = "UltraLabel15"
        Me.UltraLabel15.Size = New System.Drawing.Size(79, 17)
        Me.UltraLabel15.TabIndex = 260
        Me.UltraLabel15.Text = "Fecha de Inicio"
        '
        'dtfechasubtarea
        '
        Me.dtfechasubtarea.AutoSize = False
        Me.dtfechasubtarea.DateTime = New Date(2014, 6, 9, 0, 0, 0, 0)
        Me.dtfechasubtarea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.dtfechasubtarea.Location = New System.Drawing.Point(571, 17)
        Me.dtfechasubtarea.MinDate = New Date(2010, 8, 1, 0, 0, 0, 0)
        Me.dtfechasubtarea.Name = "dtfechasubtarea"
        Me.dtfechasubtarea.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.dtfechasubtarea.Size = New System.Drawing.Size(147, 18)
        Me.dtfechasubtarea.TabIndex = 259
        Me.dtfechasubtarea.TabStop = False
        Me.dtfechasubtarea.Value = New Date(2014, 6, 9, 0, 0, 0, 0)
        '
        'txtidplanifsub
        '
        Appearance172.TextHAlignAsString = "Left"
        Appearance172.TextVAlignAsString = "Middle"
        Me.txtidplanifsub.Appearance = Appearance172
        Me.txtidplanifsub.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtidplanifsub.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtidplanifsub.Location = New System.Drawing.Point(857, 40)
        Me.txtidplanifsub.Name = "txtidplanifsub"
        Me.txtidplanifsub.ReadOnly = True
        Me.txtidplanifsub.Size = New System.Drawing.Size(124, 21)
        Me.txtidplanifsub.TabIndex = 258
        Me.txtidplanifsub.TabStop = False
        Me.txtidplanifsub.Visible = False
        '
        'UltraLabel14
        '
        Appearance173.BackColor = System.Drawing.Color.Transparent
        Appearance173.TextHAlignAsString = "Left"
        Me.UltraLabel14.Appearance = Appearance173
        Me.UltraLabel14.AutoSize = True
        Me.UltraLabel14.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel14.Location = New System.Drawing.Point(486, 43)
        Me.UltraLabel14.Name = "UltraLabel14"
        Me.UltraLabel14.Size = New System.Drawing.Size(123, 17)
        Me.UltraLabel14.TabIndex = 257
        Me.UltraLabel14.Text = "Notas para supervisión :"
        '
        'txtnota
        '
        Appearance23.TextHAlignAsString = "Left"
        Appearance23.TextVAlignAsString = "Middle"
        Me.txtnota.Appearance = Appearance23
        Me.txtnota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnota.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtnota.Location = New System.Drawing.Point(485, 64)
        Me.txtnota.MaxLength = 300
        Me.txtnota.Multiline = True
        Me.txtnota.Name = "txtnota"
        Me.txtnota.Size = New System.Drawing.Size(496, 48)
        Me.txtnota.TabIndex = 256
        Me.txtnota.TabStop = False
        '
        'UltraTabControl1
        '
        Appearance17.FontData.BoldAsString = "True"
        Appearance17.FontData.Name = "Arial Narrow"
        Appearance17.FontData.SizeInPoints = 16.0!
        Me.UltraTabControl1.ActiveTabAppearance = Appearance17
        Me.UltraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance18.FontData.Name = "Arial Narrow"
        Appearance18.FontData.SizeInPoints = 10.0!
        Appearance18.TextHAlignAsString = "Center"
        Me.UltraTabControl1.Appearance = Appearance18
        Me.UltraTabControl1.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl4)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl5)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl6)
        Me.UltraTabControl1.Controls.Add(Me.UltraTabPageControl7)
        Me.UltraTabControl1.Location = New System.Drawing.Point(13, 174)
        Me.UltraTabControl1.Name = "UltraTabControl1"
        Me.UltraTabControl1.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.UltraTabControl1.Size = New System.Drawing.Size(976, 323)
        Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance19.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UltraTabControl1.TabHeaderAreaAppearance = Appearance19
        Me.UltraTabControl1.TabIndex = 255
        Me.UltraTabControl1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        UltraTab7.Key = "T04"
        UltraTab7.TabPage = Me.UltraTabPageControl7
        UltraTab7.Text = "PLANOS"
        Appearance24.Cursor = System.Windows.Forms.Cursors.Default
        Appearance24.FontData.BoldAsString = "True"
        Appearance24.FontData.Name = "Arial Narrow"
        Appearance24.FontData.SizeInPoints = 16.0!
        UltraTab3.ActiveAppearance = Appearance24
        Appearance43.FontData.Name = "Arial Narrow"
        Appearance43.FontData.SizeInPoints = 10.0!
        UltraTab3.Appearance = Appearance43
        UltraTab3.Key = "T01"
        UltraTab3.TabPage = Me.UltraTabPageControl4
        UltraTab3.Text = "PERSONAL QUE PARTICIPA"
        UltraTab4.Key = "T02"
        UltraTab4.TabPage = Me.UltraTabPageControl5
        UltraTab4.Text = "MATERIALES NECESARIOS"
        UltraTab5.Key = "T03"
        UltraTab5.TabPage = Me.UltraTabPageControl6
        UltraTab5.Text = "SERVICIOS NECESARIOS"
        Me.UltraTabControl1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab7, UltraTab3, UltraTab4, UltraTab5})
        Me.UltraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(972, 285)
        '
        'cmbsubtarea
        '
        Me.cmbsubtarea.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmbsubtarea.DisplayLayout.Appearance = Appearance25
        Me.cmbsubtarea.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmbsubtarea.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance71.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance71.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance71.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance71.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbsubtarea.DisplayLayout.GroupByBox.Appearance = Appearance71
        Appearance88.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbsubtarea.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance88
        Appearance90.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance90.BackColor2 = System.Drawing.SystemColors.Control
        Appearance90.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance90.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbsubtarea.DisplayLayout.GroupByBox.PromptAppearance = Appearance90
        Me.cmbsubtarea.DisplayLayout.MaxColScrollRegions = 1
        Me.cmbsubtarea.DisplayLayout.MaxRowScrollRegions = 1
        Appearance92.BackColor = System.Drawing.SystemColors.Highlight
        Appearance92.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmbsubtarea.DisplayLayout.Override.ActiveRowAppearance = Appearance92
        Appearance96.BackColor = System.Drawing.Color.Transparent
        Me.cmbsubtarea.DisplayLayout.Override.CardAreaAppearance = Appearance96
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Appearance27.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmbsubtarea.DisplayLayout.Override.CellAppearance = Appearance27
        Me.cmbsubtarea.DisplayLayout.Override.CellPadding = 0
        Appearance97.TextHAlignAsString = "Left"
        Me.cmbsubtarea.DisplayLayout.Override.HeaderAppearance = Appearance97
        Me.cmbsubtarea.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmbsubtarea.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance94.BackColor = System.Drawing.SystemColors.Window
        Appearance94.BorderColor = System.Drawing.Color.Silver
        Me.cmbsubtarea.DisplayLayout.Override.RowAppearance = Appearance94
        Me.cmbsubtarea.DisplayLayout.Override.RowSpacingAfter = 4
        Me.cmbsubtarea.DisplayLayout.Override.RowSpacingBefore = 2
        Me.cmbsubtarea.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmbsubtarea.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmbsubtarea.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmbsubtarea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbsubtarea.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbsubtarea.Location = New System.Drawing.Point(79, 115)
        Me.cmbsubtarea.Name = "cmbsubtarea"
        Me.cmbsubtarea.ReadOnly = True
        Me.cmbsubtarea.Size = New System.Drawing.Size(383, 22)
        Me.cmbsubtarea.TabIndex = 254
        Me.cmbsubtarea.TabStop = False
        Me.cmbsubtarea.Visible = False
        '
        'UltraLabel11
        '
        Appearance21.BackColor = System.Drawing.Color.Transparent
        Appearance21.TextHAlignAsString = "Left"
        Me.UltraLabel11.Appearance = Appearance21
        Me.UltraLabel11.AutoSize = True
        Me.UltraLabel11.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel11.Location = New System.Drawing.Point(13, 120)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(63, 17)
        Me.UltraLabel11.TabIndex = 253
        Me.UltraLabel11.Text = "Sub-Tarea :"
        '
        'cmbTarea
        '
        Me.cmbTarea.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Appearance69.BackColor = System.Drawing.SystemColors.Window
        Appearance69.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.cmbTarea.DisplayLayout.Appearance = Appearance69
        Me.cmbTarea.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.cmbTarea.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance70.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance70.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance70.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance70.BorderColor = System.Drawing.SystemColors.Window
        Me.cmbTarea.DisplayLayout.GroupByBox.Appearance = Appearance70
        Appearance72.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbTarea.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance72
        Appearance73.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance73.BackColor2 = System.Drawing.SystemColors.Control
        Appearance73.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance73.ForeColor = System.Drawing.SystemColors.GrayText
        Me.cmbTarea.DisplayLayout.GroupByBox.PromptAppearance = Appearance73
        Me.cmbTarea.DisplayLayout.MaxColScrollRegions = 1
        Me.cmbTarea.DisplayLayout.MaxRowScrollRegions = 1
        Appearance74.BackColor = System.Drawing.SystemColors.Highlight
        Appearance74.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.cmbTarea.DisplayLayout.Override.ActiveRowAppearance = Appearance74
        Appearance75.BackColor = System.Drawing.Color.Transparent
        Me.cmbTarea.DisplayLayout.Override.CardAreaAppearance = Appearance75
        Appearance76.BorderColor = System.Drawing.Color.Silver
        Appearance76.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.cmbTarea.DisplayLayout.Override.CellAppearance = Appearance76
        Me.cmbTarea.DisplayLayout.Override.CellPadding = 0
        Appearance77.TextHAlignAsString = "Left"
        Me.cmbTarea.DisplayLayout.Override.HeaderAppearance = Appearance77
        Me.cmbTarea.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmbTarea.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance78.BackColor = System.Drawing.SystemColors.Window
        Appearance78.BorderColor = System.Drawing.Color.Silver
        Me.cmbTarea.DisplayLayout.Override.RowAppearance = Appearance78
        Me.cmbTarea.DisplayLayout.Override.RowSpacingAfter = 4
        Me.cmbTarea.DisplayLayout.Override.RowSpacingBefore = 2
        Me.cmbTarea.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.cmbTarea.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.cmbTarea.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.cmbTarea.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.cmbTarea.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.cmbTarea.Location = New System.Drawing.Point(79, 89)
        Me.cmbTarea.Name = "cmbTarea"
        Me.cmbTarea.Size = New System.Drawing.Size(383, 22)
        Me.cmbTarea.TabIndex = 252
        Me.cmbTarea.TabStop = False
        '
        'UltraLabel8
        '
        Appearance156.BackColor = System.Drawing.Color.Transparent
        Appearance156.TextHAlignAsString = "Left"
        Me.UltraLabel8.Appearance = Appearance156
        Me.UltraLabel8.AutoSize = True
        Me.UltraLabel8.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel8.Location = New System.Drawing.Point(13, 94)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(40, 17)
        Me.UltraLabel8.TabIndex = 251
        Me.UltraLabel8.Text = "Tarea :"
        '
        'txtequipo_det
        '
        Appearance9.TextHAlignAsString = "Left"
        Appearance9.TextVAlignAsString = "Middle"
        Me.txtequipo_det.Appearance = Appearance9
        Me.txtequipo_det.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtequipo_det.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtequipo_det.Location = New System.Drawing.Point(79, 64)
        Me.txtequipo_det.Name = "txtequipo_det"
        Me.txtequipo_det.ReadOnly = True
        Me.txtequipo_det.Size = New System.Drawing.Size(383, 21)
        Me.txtequipo_det.TabIndex = 250
        Me.txtequipo_det.TabStop = False
        '
        'UltraLabel7
        '
        Appearance98.BackColor = System.Drawing.Color.Transparent
        Appearance98.TextHAlignAsString = "Left"
        Me.UltraLabel7.Appearance = Appearance98
        Me.UltraLabel7.AutoSize = True
        Me.UltraLabel7.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel7.Location = New System.Drawing.Point(13, 67)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(45, 17)
        Me.UltraLabel7.TabIndex = 249
        Me.UltraLabel7.Text = "Equipo :"
        '
        'txttaller_det
        '
        Appearance157.TextHAlignAsString = "Left"
        Appearance157.TextVAlignAsString = "Middle"
        Me.txttaller_det.Appearance = Appearance157
        Me.txttaller_det.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttaller_det.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txttaller_det.Location = New System.Drawing.Point(79, 39)
        Me.txttaller_det.Name = "txttaller_det"
        Me.txttaller_det.ReadOnly = True
        Me.txttaller_det.Size = New System.Drawing.Size(383, 21)
        Me.txttaller_det.TabIndex = 247
        Me.txttaller_det.TabStop = False
        '
        'UltraLabel9
        '
        Appearance67.BackColor = System.Drawing.Color.Transparent
        Appearance67.TextHAlignAsString = "Left"
        Me.UltraLabel9.Appearance = Appearance67
        Me.UltraLabel9.AutoSize = True
        Me.UltraLabel9.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel9.Location = New System.Drawing.Point(13, 41)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(38, 17)
        Me.UltraLabel9.TabIndex = 246
        Me.UltraLabel9.Text = "Taller :"
        '
        'txtproyecto_det
        '
        Appearance56.TextHAlignAsString = "Left"
        Appearance56.TextVAlignAsString = "Middle"
        Me.txtproyecto_det.Appearance = Appearance56
        Me.txtproyecto_det.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtproyecto_det.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtproyecto_det.Location = New System.Drawing.Point(79, 14)
        Me.txtproyecto_det.Name = "txtproyecto_det"
        Me.txtproyecto_det.ReadOnly = True
        Me.txtproyecto_det.Size = New System.Drawing.Size(383, 21)
        Me.txtproyecto_det.TabIndex = 245
        Me.txtproyecto_det.TabStop = False
        '
        'UltraLabel10
        '
        Appearance107.BackColor = System.Drawing.Color.Transparent
        Appearance107.TextHAlignAsString = "Left"
        Me.UltraLabel10.Appearance = Appearance107
        Me.UltraLabel10.AutoSize = True
        Me.UltraLabel10.Font = New System.Drawing.Font("Arial Narrow", 9.75!)
        Me.UltraLabel10.Location = New System.Drawing.Point(13, 17)
        Me.UltraLabel10.Name = "UltraLabel10"
        Me.UltraLabel10.Size = New System.Drawing.Size(54, 17)
        Me.UltraLabel10.TabIndex = 244
        Me.UltraLabel10.Text = "Proyecto :"
        '
        'Tab1
        '
        Appearance99.FontData.BoldAsString = "True"
        Appearance99.FontData.Name = "Arial Narrow"
        Appearance99.FontData.SizeInPoints = 16.0!
        Me.Tab1.ActiveTabAppearance = Appearance99
        Appearance100.FontData.Name = "Arial Narrow"
        Appearance100.FontData.SizeInPoints = 10.0!
        Me.Tab1.Appearance = Appearance100
        Me.Tab1.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl1)
        Me.Tab1.Controls.Add(Me.rdbCore)
        Me.Tab1.Controls.Add(Me.UltraTabPageControl3)
        Me.Tab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tab1.Location = New System.Drawing.Point(0, 0)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.Tab1.Size = New System.Drawing.Size(1028, 544)
        Me.Tab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.PropertyPageSelected
        Appearance101.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Tab1.TabHeaderAreaAppearance = Appearance101
        Me.Tab1.TabIndex = 15
        Me.Tab1.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowSizeToFit
        Appearance102.Cursor = System.Windows.Forms.Cursors.Default
        Appearance102.FontData.BoldAsString = "True"
        Appearance102.FontData.Name = "Arial Narrow"
        Appearance102.FontData.SizeInPoints = 16.0!
        UltraTab6.ActiveAppearance = Appearance102
        Appearance103.FontData.Name = "Arial Narrow"
        Appearance103.FontData.SizeInPoints = 10.0!
        UltraTab6.Appearance = Appearance103
        UltraTab6.Key = "T01"
        UltraTab6.TabPage = Me.UltraTabPageControl1
        UltraTab6.Text = "LISTADO DE PROYECTOS"
        Appearance1.FontData.Name = "Arial Narrow"
        Appearance1.FontData.SizeInPoints = 16.0!
        UltraTab1.ActiveAppearance = Appearance1
        Appearance5.FontData.Name = "Arial Narrow"
        Appearance5.FontData.SizeInPoints = 10.0!
        UltraTab1.Appearance = Appearance5
        UltraTab1.Key = "T02"
        UltraTab1.TabPage = Me.rdbCore
        UltraTab1.Text = "PLANIFICACION DE TAREAS Y SUB-TAREAS"
        Appearance104.FontData.Name = "Arial Narrow"
        Appearance104.FontData.SizeInPoints = 16.0!
        UltraTab2.ActiveAppearance = Appearance104
        Appearance105.FontData.Name = "Arial Narrow"
        Appearance105.FontData.SizeInPoints = 10.0!
        UltraTab2.Appearance = Appearance105
        UltraTab2.Key = "T03"
        UltraTab2.TabPage = Me.UltraTabPageControl3
        UltraTab2.Text = "DETALLE DE SUBTAREA"
        Me.Tab1.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab6, UltraTab1, UltraTab2})
        Me.Tab1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2007
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1024, 506)
        '
        'FrmPlanificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 544)
        Me.Controls.Add(Me.Tab1)
        Me.Name = "FrmPlanificacion"
        Me.Text = "FrmPlanificacion"
        Me.UltraTabPageControl7.ResumeLayout(False)
        Me.UltraTabPageControl7.PerformLayout()
        CType(Me.gridplanodet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtplanodet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.UltraTabPageControl4.PerformLayout()
        CType(Me.txttotpersona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAgregar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridpersonal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl5.ResumeLayout(False)
        Me.UltraTabPageControl5.PerformLayout()
        CType(Me.txttotmaterial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridmaterial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl6.ResumeLayout(False)
        Me.UltraTabPageControl6.PerformLayout()
        CType(Me.txttotservicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridServicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.panel.ResumeLayout(False)
        CType(Me.gridProyecto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rdbCore.ResumeLayout(False)
        Me.rdbCore.PerformLayout()
        CType(Me.gridplano, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridsubtarea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtplano, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtidequipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtidtaller, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtidproyecto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsubtarea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridTarea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttarea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtequipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttaller, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtproyecto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        CType(Me.txtsubtareadet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttotalsub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtfechasubtarea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtidplanifsub, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnota, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControl1.ResumeLayout(False)
        CType(Me.cmbsubtarea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTarea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtequipo_det, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttaller_det, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtproyecto_det, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tab1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents panel As System.Windows.Forms.Panel
    Friend WithEvents gridProyecto As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents rdbCore As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents txtid As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtproyecto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txttaller As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtFecha As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txttarea As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtequipo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents gridTarea As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtsubtarea As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents gridsubtarea As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents txtequipo_det As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txttaller_det As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtproyecto_det As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel10 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbTarea As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents cmbsubtarea As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtidtaller As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtidproyecto As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtidequipo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraTabControl1 As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl7 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents txtplanodet As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel12 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents gridplanodet As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtplano As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel13 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents gridpersonal As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gridmaterial As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gridServicio As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraLabel14 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txtnota As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents rdbCorrectiva As System.Windows.Forms.RadioButton
    Friend WithEvents rdbnoPlanificada As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPlanificada As System.Windows.Forms.RadioButton
    Friend WithEvents btnAgregar As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents txtidplanifsub As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel15 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents dtfechasubtarea As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txttotalsub As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel16 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel17 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txttotpersona As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel18 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txttotmaterial As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel19 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txttotservicio As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel20 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cmbTipo As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents gridplano As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtsubtareadet As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
End Class
