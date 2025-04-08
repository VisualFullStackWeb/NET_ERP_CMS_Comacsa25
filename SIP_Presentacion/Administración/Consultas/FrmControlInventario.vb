Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports System.Windows.Forms.DataVisualization.Charting

Public Class FrmControlInventario
    Public Ls_Permisos As New List(Of Integer)
    Dim procesado As Int32
    Dim _objNegocio As NGInsumosFiscalizados
    Dim _objEntidad As ETInsumosFiscalizados
    Dim cierre As Int32 = 0
    Private Ls_RumaSuministro As List(Of ETRuma) = Nothing
    Private CodRuma As String = String.Empty
    Dim _objNegocio_ As NGProducto
    Dim _objEntidad_ As ETProducto
    Public Lista As List(Of ETRuma) = Nothing
    Dim dsFiltro As New DataSet
    Dim dtAlmacen As New DataTable
    Dim dtRuma As New DataTable
    Dim dtListaCantera As New DataTable
    Dim dtMineral As New DataTable
    Dim dtData As New DataTable
    Dim dtDataHist As New DataTable
    Dim dtDataFiltro As New DataTable
    Dim dtSaldoInicial As New DataTable
    Dim dtDataIni As New DataTable
    Dim dtRumaEnlazada As DataTable
    Dim dtConfigMeses As New DataTable
    Dim dtConfigFiltro As New DataTable

    Private Sub FrmControlInventario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFechaIni.Value = Now.Date
        dtFechaFin.Value = Now.Date
        txtayo.Value = Now.Year
        cargaFiltro()
        Chart1.Visible = False
        Chart2.Visible = False        
    End Sub

    Sub cargaData()
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        Dim fechaini As Date = dtFechaIni.Value
        Dim fechafin As Date = dtFechaFin.Value
        dtData = _objNegocio_.ListaConInvData(fechaini, fechafin)
        For I As Int32 = 0 To gridMes.Rows.Count - 1
            gridMes.Rows(I).Cells("sel").Value = True
        Next
    End Sub

    Sub cargaDatahistorica()
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        Dim fechaini As Date = dtFechaIni.Value
        Dim fechafin As Date = dtFechaFin.Value
        dtDataHist = _objNegocio_.ListaConInvDataHist(fechaini, fechafin)
    End Sub

    Sub ProcesaData()
        Dim cadenaMesNom As String = ""
        Dim cadenaMes As String = ""
        Dim cadenaAlmacen As String = ""
        Dim cadenaRuma As String = ""
        Dim cadenaPlanta As String = ""
        Dim cadenaMineral As String = ""
        Dim cadenaTipomov As String = ""

        gridRuma.PerformAction(ExitEditMode)
        gridTipo.PerformAction(ExitEditMode)
        cadenaMesNom = ""
        cadenaMes = ""
        cadenaAlmacen = ""
        cadenaRuma = ""
        cadenaPlanta = ""
        cadenaMineral = ""

        Dim ayoini As Int32 = Year(dtFechaIni.Value)
        Dim ayofin As Int32 = Year(dtFechaFin.Value)
        Dim mesini As Int32 = Month(dtFechaIni.Value)
        Dim mesfin As Int32 = Month(dtFechaFin.Value)
        Dim nro_mes As Int32 = 0
        For x As Int32 = ayoini To ayofin
            For i As Int32 = 0 To gridMes.Rows.Count - 1
                If gridMes.Rows(i).Cells("sel").Value = True Then
                    nro_mes = gridMes.Rows(i).Cells("MES_NRO").Value
                    cadenaMes = cadenaMes + gridMes.Rows(i).Cells("MES_NRO").Value + ","
                    If (x = ayoini And nro_mes >= mesini And ayoini <> ayofin) Or (x = ayofin And nro_mes <= mesfin) Or (x > ayoini And x < ayofin) Then
                        cadenaMesNom = cadenaMesNom + gridMes.Rows(i).Cells("MES").Value + x.ToString + ","
                    End If

                End If
            Next
        Next

        If cadenaMesNom.Length <= 0 Then Exit Sub
        cadenaMesNom = cadenaMesNom.Substring(0, cadenaMesNom.Length - 1)
        For i As Int32 = 0 To gridAlmacen.Rows.Count - 1
            If gridAlmacen.Rows(i).Cells("sel").Value = True Then
                cadenaAlmacen = cadenaAlmacen + "'" + gridAlmacen.Rows(i).Cells("COD_ALMACEN").Value + "',"
            End If
        Next
        For i As Int32 = 0 To gridRuma.Rows.Count - 1
            If gridRuma.Rows(i).Cells("sel").Value = True Then
                cadenaRuma = cadenaRuma + "'" + gridRuma.Rows(i).Cells("COD_RUMA").Value.ToString.Substring(0, 8) + "',"
                cadenaPlanta = cadenaPlanta + "'" + gridRuma.Rows(i).Cells("PLANTA").Value + "',"
            End If
        Next

        For i As Int32 = 0 To gridTipo.Rows.Count - 1
            If gridTipo.Rows(i).Cells("sel").Value = True Then
                cadenaTipomov = cadenaTipomov + "'" + gridTipo.Rows(i).Cells("ID_TIPO").Value + "',"
            End If
        Next

        Dim rows As DataRow()
        dtDataFiltro = dtData.Clone()
        Dim rows_Ini As DataRow()
        dtDataIni = dtSaldoInicial.Clone()
        Dim rows_Config As DataRow()
        dtConfigFiltro = dtConfigMeses.Clone()
        If cadenaTipomov = "" Then cadenaTipomov = "2"
        If cadenaRuma.Length > 0 Then
            chkruma.Checked = True
            rows = dtData.Select("MES IN(" & cadenaMes & ") AND COD_ALM IN(" & cadenaAlmacen & ") AND COD_RUMA IN(" & cadenaRuma & ") AND flgtransferencia IN(" & cadenaTipomov & ")")
            For Each dr As DataRow In rows
                dtDataFiltro.ImportRow(dr)
            Next

            rows_Ini = dtSaldoInicial.Select("COD_ALM IN(" & cadenaAlmacen & ") AND COD_RUMA IN(" & cadenaRuma & ")")
            For Each dr As DataRow In rows_Ini
                dtDataIni.ImportRow(dr)
            Next
            Ton_Inicial = 0
            Ton_InicialV = 0
            For i As Int32 = 0 To dtDataIni.Rows.Count - 1
                Ton_Inicial = Ton_Inicial + dtDataIni.Rows(i)("SALDO")
                Ton_InicialV = Ton_InicialV + dtDataIni.Rows(i)("COSTO")
            Next

            rows_Config = dtConfigMeses.Select(" COD_RUMA IN(" & cadenaRuma & ")")
            For Each dr As DataRow In rows_Config
                dtConfigFiltro.ImportRow(dr)
            Next
            Mes_min = 0
            Mes_max = 0
            'If dtConfigFiltro.Rows.Count > 0 Then
            '    Mes_min = dtConfigFiltro.Rows(0)("MIN_MESES")
            '    Mes_max = dtConfigFiltro.Rows(0)("MAX_MESES")
            'End If
            
            For i As Int32 = 0 To dtConfigFiltro.Rows.Count - 1
                Mes_min = IIf(Mes_min < dtConfigFiltro.Rows(i)("MIN_MESES"), dtConfigFiltro.Rows(i)("MIN_MESES"), Mes_min)
                Mes_max = IIf(Mes_max < dtConfigFiltro.Rows(i)("MAX_MESES"), dtConfigFiltro.Rows(i)("MAX_MESES"), Mes_max)
                'Mes_max = Mes_max + dtConfigFiltro.Rows(i)("MAX_MESES")
            Next
            'dtConfigMeses
        End If

        LimpiaGrafica()
        LimpiaGraficaSoles()
        If dtDataFiltro.Rows.Count > 0 Then
            GraficaTN(dtDataFiltro, cadenaMesNom)
            GraficaSoles(dtDataFiltro, cadenaMesNom)
            btncambiagrafica_Click(Nothing, Nothing)
            'ComposicionInventario()
        Else
            If cadenaRuma.Length > 0 Then
                MsgBox("No existen datos para mostrar", MsgBoxStyle.Information, "Validación")
                gridMineral.ActiveRow.Cells("sel").Value = False
            End If
            'gridRuma.ActiveRow.Cells("sel").Value = False
            LimpiaGrafica()
            LimpiaGraficaSoles()
            LimpiaTotales()
        End If
        ComposicionInventario()
        'gridMineral.DataSource = DtMinFiltro
    End Sub

    Sub ComposicionInventario()
        Dim dtComposicion As New DataTable
        dtComposicion.Columns.Add("ALMACEN")
        dtComposicion.Columns.Add("COD_RUMA")
        dtComposicion.Columns.Add("RUMA")
        dtComposicion.Columns.Add("STOCK")


        Dim cadenaRuma As String = ""
        Dim cadenaAlmacen As String = ""
        Dim cadenaMes As String = ""
        gridRuma.PerformAction(ExitEditMode)
        cadenaRuma = ""
        gridComposicion.DataSource = dtComposicion
        For i As Int32 = 0 To gridRuma.Rows.Count - 1
            If gridRuma.Rows(i).Cells("sel").Value = True Then
                cadenaRuma = cadenaRuma + "'" + gridRuma.Rows(i).Cells("COD_RUMA").Value.ToString.Substring(0, 8) + "',"
            End If
        Next
        If cadenaRuma.Length <= 0 Then Exit Sub
        For i As Int32 = 0 To gridAlmacen.Rows.Count - 1
            If gridAlmacen.Rows(i).Cells("sel").Value = True Then
                cadenaAlmacen = cadenaAlmacen + "'" + gridAlmacen.Rows(i).Cells("COD_ALMACEN").Value + "',"
            End If
        Next
        Dim arrayRuma() As String = cadenaRuma.Substring(0, cadenaRuma.Length - 1).Split(",")

        For i As Int32 = 0 To gridMes.Rows.Count - 1
            If gridMes.Rows(i).Cells("sel").Value = True Then
                cadenaMes = cadenaMes + "'" + gridMes.Rows(i).Cells("MES_NRO").Value + "',"
            End If
        Next
        If cadenaRuma.Length <= 0 Then Exit Sub

        If cadenaAlmacen.Length <= 0 Then Exit Sub
        Dim tn_ingreso As Double = 0
        Dim tn_salida As Double = 0
        
        Dim saldo As Double = 0
        
        Dim ton_ini As Double = 0
        Dim cadenaTipomov As String = ""
        For i As Int32 = 0 To gridTipo.Rows.Count - 1
            If gridTipo.Rows(i).Cells("sel").Value = True Then
                cadenaTipomov = cadenaTipomov + "'" + gridTipo.Rows(i).Cells("ID_TIPO").Value + "',"
            End If
        Next

        Dim dr As DataRow
        gridRuma.PerformAction(ExitEditMode)
        For I As Int32 = 0 To gridRuma.Rows.Count - 1
            If gridRuma.Rows(I).Cells("sel").Value = True Then
                CodRuma = gridRuma.Rows(I).Cells("COD_RUMA").Value.ToString.Substring(0, 8)
                tn_ingreso = CalculaTonMesRuma(dtData, cadenaMes, "Ingreso", CodRuma, cadenaTipomov)
                tn_salida = CalculaTonMesRuma(dtData, cadenaMes, "Salida", CodRuma, cadenaTipomov)

                ton_ini = TonInicial(cadenaAlmacen, CodRuma)
                
                saldo = ton_ini + tn_ingreso - tn_salida


                If tn_salida > 0 Then
                    dr = dtComposicion.NewRow
                    dr(0) = gridRuma.Rows(I).Cells("ALMACEN").Value
                    dr(1) = CodRuma + " - " + gridRuma.Rows(I).Cells("RUMA").Value
                    dr(2) = gridRuma.Rows(I).Cells("RUMA").Value
                    dr(3) = CInt(saldo).ToString("#,##0")
                    dtComposicion.Rows.Add(dr)
                End If
            End If


        Next

        gridComposicion.DataSource = dtComposicion
    End Sub

    Sub cargaConfMeses()
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        dtConfigMeses = _objNegocio_.ConInvConfMeses(txtayo.Value)
    End Sub

    Sub cargaSaldoInicial()
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        dtSaldoInicial = _objNegocio_.ConInvSaldoInicial(dtFechaIni.Value)
    End Sub

    Sub cargaFiltro()
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        dsFiltro = _objNegocio_.ListaConInvFiltro(User_Sistema)
        dtAlmacen = dsFiltro.Tables(0)
        dtRuma = dsFiltro.Tables(1)
        dtMineral = dsFiltro.Tables(2)
        dtRumaEnlazada = dsFiltro.Tables(3)
        gridAlmacen.DataSource = dtAlmacen
        cargaMeses()
        cargaTipo()
        cargaRuma()
        cargaMineral()
    End Sub

    Sub cargaRuma()
        Dim dtRumaFiltro As New DataTable
        Dim cadenaAlmacen As String = ""
        gridAlmacen.PerformAction(ExitEditMode)
        cadenaAlmacen = ""
        For i As Int32 = 0 To gridAlmacen.Rows.Count - 1
            If gridAlmacen.Rows(i).Cells("sel").Value = True Then
                cadenaAlmacen = cadenaAlmacen + "'" + gridAlmacen.Rows(i).Cells("COD_PLANTA").Value + "',"
            End If
        Next

        Dim rows As DataRow()
        dtRumaFiltro = dtRuma.Clone()
        If cadenaAlmacen.Length > 0 Then
            rows = dtRuma.Select("PLANTA IN(" & cadenaAlmacen & ")")
            For Each dr As DataRow In rows
                dtRumaFiltro.ImportRow(dr)
            Next
        End If
        gridRuma.DataSource = dtRumaFiltro
        LimpiaGrafica()
        LimpiaGraficaSoles()
    End Sub

    Sub CargaCanteras()
        dtListaCantera = New DataTable
        dtListaCantera.Columns.Add("CODCANTERA")
        dtListaCantera.Columns.Add("CANTERA")
        dtListaCantera.Columns.Add("CODRUMA")
        dtListaCantera.Columns.Add("RUMA")
        dtListaCantera.Columns.Add("CODMINERAL")
        dtListaCantera.Columns.Add("MINERAL")
        dtListaCantera.Columns.Add("MOVIMIENTO")
        dtListaCantera.Columns.Add("FLGTRANSFERENCIA")
        dtListaCantera.Columns.Add("CONTRATISTA")
        Dim dw As New DataView(dtData)
        dw.Sort = "CodCantera,cod_Ruma,CodMineral,TipoMovimiento,flgtransferencia"
        Dim row As DataRow
        Dim cadena As String = ""
        For Each i In dw
            If cadena <> i("CodCantera").ToString.Trim & i("cod_Ruma").ToString.Trim & i("CodMineral").ToString.Trim & i("TipoMovimiento").ToString.Trim & i("flgtransferencia").ToString.Trim Then
                row = dtListaCantera.NewRow
                row(0) = i("CodCantera")
                row(1) = i("NomCantera").ToString.Trim
                row(2) = i("cod_Ruma")
                row(3) = i("NomRuma").ToString.Trim
                row(4) = i("CodMineral")
                row(5) = i("mineral").ToString.Trim
                row(6) = i("TipoMovimiento").ToString.Trim.ToUpper
                row(7) = i("flgtransferencia")
                row(8) = i("contratista")
                dtListaCantera.Rows.Add(row)
                cadena = i("CodCantera").ToString.Trim & i("cod_Ruma").ToString.Trim & i("CodMineral").ToString.Trim & i("TipoMovimiento").ToString.Trim & i("flgtransferencia").ToString.Trim
            End If
        Next
    End Sub
    Sub cargaMineral()
        Dim DtMinFiltro As New DataTable

        Dim cadenaRuma As String = ""
        Dim cadenaPlanta As String = ""
        gridRuma.PerformAction(ExitEditMode)
        cadenaRuma = ""
        cadenaPlanta = ""

        For i As Int32 = 0 To gridRuma.Rows.Count - 1
            If gridRuma.Rows(i).Cells("sel").Value = True Then
                cadenaRuma = cadenaRuma + "'" + gridRuma.Rows(i).Cells("COD_RUMA").Value.ToString.Substring(0, 8) + "',"
                cadenaPlanta = cadenaPlanta + "'" + gridRuma.Rows(i).Cells("PLANTA").Value + "',"
            End If
        Next

        Dim rows As DataRow()
        DtMinFiltro = dtMineral.Clone()
        Dim codmineral As String = ""
        If cadenaRuma.Length > 0 Then
            rows = dtMineral.Select("COD_RUMA IN(" & cadenaRuma & ")") ' AND PLANTA IN(" & cadenaPlanta & ")
            For Each dr As DataRow In rows
                If codmineral <> dr(1).ToString.Trim Then
                    DtMinFiltro.ImportRow(dr)
                    codmineral = dr(1).ToString.Trim
                End If

            Next
            gridMineral.DataSource = DtMinFiltro
        Else
            gridMineral.DataSource = dtMineral

        End If
        'gridMineral.DataSource = dtMineral

    End Sub

    Sub cargaTipo()
        Dim dtTipo As New DataTable
        dtTipo.Columns.Add("sel")
        dtTipo.Columns.Add("TIPO")
        dtTipo.Columns.Add("ID_TIPO")
        Dim dr As DataRow
        dr = dtTipo.NewRow
        dr(0) = True
        dr(1) = "CANTERA"
        dr(2) = 0
        dtTipo.Rows.Add(dr)

        dr = dtTipo.NewRow
        dr(0) = True
        dr(1) = "TRANSFERENCIA"
        dr(2) = 1
        dtTipo.Rows.Add(dr)

        gridTipo.DataSource = dtTipo
    End Sub
    Sub cargaMeses()
        Dim dtMes As New DataTable
        dtMes.Columns.Add("sel")
        dtMes.Columns.Add("MES")
        dtMes.Columns.Add("MES_NRO")
        Dim dr As DataRow
        For i As Int32 = 1 To 12
            dr = dtMes.NewRow
            dr(0) = True
            dr(1) = nombreMEs(i)
            dr(2) = i
            dtMes.Rows.Add(dr)
        Next
        gridMes.DataSource = dtMes
    End Sub
    Sub Procesar()
        lblmensaje.Text = "Procesando Datos..."
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        'GraficaTN()
        cargaData()
        cargaDatahistorica()
        cargaSaldoInicial()
        CargaCanteras()
        cargaConfMeses()
        RptSemaforo()
        DetalleCantera("", "", "")
        lblmensaje.Text = ""
        lblmensaje.Visible = False
        lblmensaje.Refresh()
        LimpiaGrafica()
        LimpiaGraficaSoles()
        LimpiaTotales()
        ProcesaData()
    End Sub
    Sub LimpiaTotales()
        lblinicial.Text = "Invt. Inicial"
        lblentrada.Text = "Entradas"
        lblsalida.Text = "Salidas"
        lblfinal.Text = "Saldo Final"
        lblinicialV.Text = ""
        lblentradaV.Text = ""
        lblsalidaV.Text = ""
        lblfinalV.Text = ""
        lblpromedio.Text = "Promedio Máx. Consumo mensual"
        lblmesesstk.Text = "Meses en Stock"
        lblmin.Text = ""
        lblmax.Text = ""
        lblayo1.Text = ""
        lblayo2.Text = ""
        lblayo3.Text = ""
        lblayo4.Text = ""
        lblayo5.Text = ""
        lblayo6.Text = ""
        lbltonexe.Text = ""
        lbltonsol.Text = ""
        lbldefton.Text = ""
        lbldefsol.Text = ""
        'gridTipo.Rows(1).Cells("sel").Value = True
        'cargaRuma()
        RumaEnlazada()
    End Sub

    Sub LimpiaGrafica()
        Try
            Dim xValues(0) As String '= {"Enero", "Febrero", "Marzo"}
            Dim yValues(0) As Double
            Dim yValues_S(0) As Double
            Chart1.Series.Clear()
            Dim serie_TN_E As New Series
            serie_TN_E.Name = "Entradas"
            serie_TN_E.Color = Color.SteelBlue
            serie_TN_E.ChartType = SeriesChartType.Column
            serie_TN_E.Points.DataBindXY(xValues, yValues)
            Chart1.Series.Add(serie_TN_E)
            Dim serie_TN_S As New Series
            serie_TN_S.Name = "Salidas"
            serie_TN_S.Color = Color.Red
            serie_TN_S.ChartType = SeriesChartType.Column
            serie_TN_S.Points.DataBindXY(xValues, yValues_S)
            Chart1.Series.Add(serie_TN_S)
            Chart1.Visible = False
            Ton_Max = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub LimpiaGraficaSoles()
        Try
            Dim xValues(0) As String '= {"Enero", "Febrero", "Marzo"}
            Dim yValues(0) As Double
            Dim yValues_S(0) As Double
            Chart2.Series.Clear()
            Dim serie_TN_E As New Series
            serie_TN_E.Name = "Entradas"
            serie_TN_E.Color = Color.SteelBlue
            serie_TN_E.ChartType = SeriesChartType.Column
            serie_TN_E.Points.DataBindXY(xValues, yValues)
            Chart2.Series.Add(serie_TN_E)
            Dim serie_TN_S As New Series
            serie_TN_S.Name = "Salidas"
            serie_TN_S.Color = Color.Red
            serie_TN_S.ChartType = SeriesChartType.Column
            serie_TN_S.Points.DataBindXY(xValues, yValues_S)
            Chart2.Series.Add(serie_TN_S)
            Chart2.Visible = False
            Soles_Max = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim Ton_Max As Double = 0
    Dim Ton_Inicial As Double = 0
    Dim Ton_Entrada As Double = 0
    Dim Ton_Salida As Double = 0
    Dim Ton_Mov As Double = 0

    Dim Ton_InicialV As Double = 0
    Dim Ton_EntradaV As Double = 0
    Dim Ton_SalidaV As Double = 0

    Dim cant_Salida As Integer
    Dim Ton_Prom As Double = 0
    Dim Ton_Prom1 As Double = 0
    Dim Ton_Prom2 As Double = 0
    Dim Ton_Prom3 As Double = 0
    Dim Ton_Prom4 As Double = 0
    Dim Ton_Prom5 As Double = 0
    Dim Prom_max As Double = 0
    Dim Ton_final As Double = 0
    Dim Mes_min As Int32
    Dim Mes_max As Int32

    Dim Soles_Max As Double = 0

    Sub PromedioHistorico()
        Dim cadenaRuma As String = ""
        Dim cadenaAlmacen As String = ""

        For i As Int32 = 0 To gridAlmacen.Rows.Count - 1
            If gridAlmacen.Rows(i).Cells("sel").Value = True Then
                cadenaAlmacen = cadenaAlmacen + "'" + gridAlmacen.Rows(i).Cells("COD_ALMACEN").Value + "',"
            End If
        Next
        If cadenaAlmacen.Length <= 0 Then Exit Sub

        For i As Int32 = 0 To gridRuma.Rows.Count - 1
            If gridRuma.Rows(i).Cells("sel").Value = True Then
                cadenaRuma = cadenaRuma + "'" + gridRuma.Rows(i).Cells("COD_RUMA").Value.ToString.Substring(0, 8) + "',"
            End If
        Next
        If cadenaRuma.Length <= 0 Then Exit Sub

        Dim cadenaTipomov As String = ""
        For i As Int32 = 0 To gridTipo.Rows.Count - 1
            If gridTipo.Rows(i).Cells("sel").Value = True Then
                cadenaTipomov = cadenaTipomov + "'" + gridTipo.Rows(i).Cells("ID_TIPO").Value + "',"
            End If
        Next

        Dim dtHistorica As New DataTable
        dtHistorica = dtDataHist.Clone
        Dim rows As DataRow()
        rows = dtDataHist.Select("COD_ALM IN(" & cadenaAlmacen & ") AND COD_RUMA IN(" & cadenaRuma & ") AND flgtransferencia IN (" & cadenaTipomov & ")")
        For Each dr1 As DataRow In rows
            dtHistorica.ImportRow(dr1)
        Next
        Dim ayoini As Int32 = Year(dtFechaIni.Value)
        Ton_Prom1 = 0
        Ton_Prom2 = 0
        Ton_Prom3 = 0
        Ton_Prom4 = 0
        Ton_Prom4 = 0
        Ton_Prom5 = 0
        For i As Int32 = 0 To dtHistorica.Rows.Count - 1
            Dim ayo_hist As Int32 = dtHistorica.Rows(i)("ayo")
            If ayo_hist = ayoini - 5 Then Ton_Prom1 = Ton_Prom1 + dtHistorica.Rows(i)("tonprom") : lblayo1.Text = ayo_hist & ChrW(13) & CInt(Ton_Prom1).ToString("#,##0") & " Ton" : Prom_max = IIf(Ton_Prom1 > Prom_max, Ton_Prom1, Prom_max)
            If ayo_hist = ayoini - 4 Then Ton_Prom2 = Ton_Prom2 + dtHistorica.Rows(i)("tonprom") : lblayo2.Text = ayo_hist & ChrW(13) & CInt(Ton_Prom2).ToString("#,##0") & " Ton" : Prom_max = IIf(Ton_Prom2 > Prom_max, Ton_Prom2, Prom_max)
            If ayo_hist = ayoini - 3 Then Ton_Prom3 = Ton_Prom3 + dtHistorica.Rows(i)("tonprom") : lblayo3.Text = ayo_hist & ChrW(13) & CInt(Ton_Prom3).ToString("#,##0") & " Ton" : Prom_max = IIf(Ton_Prom3 > Prom_max, Ton_Prom3, Prom_max)
            If ayo_hist = ayoini - 2 Then Ton_Prom4 = Ton_Prom4 + dtHistorica.Rows(i)("tonprom") : lblayo4.Text = ayo_hist & ChrW(13) & CInt(Ton_Prom4).ToString("#,##0") & " Ton" : Prom_max = IIf(Ton_Prom4 > Prom_max, Ton_Prom4, Prom_max)
            If ayo_hist = ayoini - 1 Then Ton_Prom5 = Ton_Prom5 + dtHistorica.Rows(i)("tonprom") : lblayo5.Text = ayo_hist & ChrW(13) & CInt(Ton_Prom5).ToString("#,##0") & " Ton" : Prom_max = IIf(Ton_Prom5 > Prom_max, Ton_Prom5, Prom_max)

        Next
    End Sub

    Sub PromedioHistoricoRuma(ByVal codruma As String)
        Dim cadenaRuma As String = ""
        Dim cadenaAlmacen As String = ""

        For i As Int32 = 0 To gridAlmacen.Rows.Count - 1
            If gridAlmacen.Rows(i).Cells("sel").Value = True Then
                cadenaAlmacen = cadenaAlmacen + "'" + gridAlmacen.Rows(i).Cells("COD_ALMACEN").Value + "',"
            End If
        Next
        If cadenaAlmacen.Length <= 0 Then Exit Sub

        'For i As Int32 = 0 To gridRuma.Rows.Count - 1
        '    If gridRuma.Rows(i).Cells("sel").Value = True Then
        '        cadenaRuma = cadenaRuma + "'" + gridRuma.Rows(i).Cells("COD_RUMA").Value.ToString.Substring(0, 8) + "',"
        '    End If
        'Next
        'If cadenaRuma.Length <= 0 Then Exit Sub

        Dim cadenaTipomov As String = ""
        For i As Int32 = 0 To gridTipo.Rows.Count - 1
            If gridTipo.Rows(i).Cells("sel").Value = True Then
                cadenaTipomov = cadenaTipomov + "'" + gridTipo.Rows(i).Cells("ID_TIPO").Value + "',"
            End If
        Next

        Dim dtHistorica As New DataTable
        dtHistorica = dtDataHist.Clone
        Dim rows As DataRow()
        rows = dtDataHist.Select("COD_ALM IN(" & cadenaAlmacen & ") AND COD_RUMA ='" & codruma & "' AND flgtransferencia IN (" & cadenaTipomov & ")")
        For Each dr1 As DataRow In rows
            dtHistorica.ImportRow(dr1)
        Next
        Dim ayoini As Int32 = Year(dtFechaIni.Value)
        Ton_Prom1 = 0
        Ton_Prom2 = 0
        Ton_Prom3 = 0
        Ton_Prom4 = 0
        For i As Int32 = 0 To dtHistorica.Rows.Count - 1
            Dim ayo_hist As Int32 = dtHistorica.Rows(i)("ayo")
            If ayo_hist = ayoini - 4 Then Ton_Prom1 = Ton_Prom1 + dtHistorica.Rows(i)("tonprom") : Prom_max = IIf(Ton_Prom1 > Prom_max, Ton_Prom1, Prom_max)
            If ayo_hist = ayoini - 3 Then Ton_Prom2 = Ton_Prom2 + dtHistorica.Rows(i)("tonprom") : Prom_max = IIf(Ton_Prom2 > Prom_max, Ton_Prom2, Prom_max)
            If ayo_hist = ayoini - 2 Then Ton_Prom3 = Ton_Prom3 + dtHistorica.Rows(i)("tonprom") : Prom_max = IIf(Ton_Prom3 > Prom_max, Ton_Prom3, Prom_max)
            If ayo_hist = ayoini - 1 Then Ton_Prom4 = Ton_Prom4 + dtHistorica.Rows(i)("tonprom") : Prom_max = IIf(Ton_Prom4 > Prom_max, Ton_Prom4, Prom_max)
        Next
    End Sub

    Sub GraficaTN(ByVal dt As DataTable, ByVal cadenaMes As String)
        Try
            LimpiaGrafica()
            Chart1.Visible = True
            Dim xValues() As String
            xValues = cadenaMes.Split(",")
            Dim yValues(xValues.Count - 1) As Integer
            Dim yValues_S(xValues.Count - 1) As Integer
            Dim yValues_Saldo(xValues.Count - 1) As Integer
            Dim yValues_Min(xValues.Count - 1) As Integer
            Dim yValues_Max(xValues.Count - 1) As Integer
            For i As Int32 = 0 To xValues.Count - 1
                yValues(i) = CalculaTonMes(dt, xValues(i), "Ingreso")
                yValues_S(i) = CalculaTonMes(dt, xValues(i), "Salida")
            Next

            For i As Int32 = 0 To xValues.Count - 1
                yValues_Saldo(i) = CalculaSaldoMes(dt, xValues(i), "")
            Next

            cant_Salida = 0
            For Each i In yValues_S
                If i <> 0 Then cant_Salida += 1
            Next
            Ton_Prom = IIf(cant_Salida = 0, 0, Ton_Salida / cant_Salida)
            Prom_max = Ton_Prom
            PromedioHistorico()

            '====================Calculos totales
            lblinicial.Text = "Invt. Inicial" & ChrW(13) & Ton_Inicial.ToString("#,##0") & " Ton"
            lblinicialV.Text = "S/. " & Ton_InicialV.ToString("#,##0")

            lblentrada.Text = "Entradas" & ChrW(13) & Ton_Entrada.ToString("#,##0") & " Ton"
            lblsalida.Text = "Salidas" & ChrW(13) & Ton_Salida.ToString("#,##0") & " Ton"

            lblentradaV.Text = "S/. " & Ton_EntradaV.ToString("#,##0")
            lblsalidaV.Text = "S/. " & Ton_SalidaV.ToString("#,##0")

            Dim Ton_Final As Double
            Ton_Final = Ton_Inicial + Ton_Entrada - Ton_Salida
            lblfinal.Text = "Saldo Final" & ChrW(13) & Ton_Final.ToString("#,##0") & " Ton"

            Dim Soles_Final As Double
            Soles_Final = Ton_InicialV + Ton_EntradaV - Ton_SalidaV
            lblfinalV.Text = "S/. " & Soles_Final.ToString("#,##0")

            lblayo6.Text = "Actual" & ChrW(13) & Ton_Prom.ToString("#,##0") & " Ton"
            lblpromedio.Text = "Promedio Máx. Consumo mensual" & ChrW(13) & ChrW(13) & Prom_max.ToString("#,##0") & " Ton"

            lblmin.Text = Mes_min.ToString("#,##0") & " Meses"
            lblmax.Text = Mes_max.ToString("#,##0") & " Meses"
            Dim MesesStock As Int32
            MesesStock = IIf(Prom_max = 0, 0, Ton_Final / Prom_max)
            lblmesesstk.Text = "Meses en Stock" & ChrW(13) & MesesStock.ToString("#,##0") & " Meses"

            
            Dim ValorMin As Double = CInt(Prom_max * Mes_min)
            Dim ValorMax As Double = CInt(Prom_max * Mes_max)
            For i As Int32 = 0 To xValues.Count - 1
                yValues_Min(i) = ValorMin
                yValues_Max(i) = CInt(ValorMax).ToString("#,##0")
            Next

            'CALCULAR CUADRO DE RESULTADOS
            Dim costo_soles As Double = 0
            Dim consumo_dif As Double = 0
            Dim soles_dif As Double = 0
            Dim estado_result As String = ""
            Soles_Final = Math.Round(CDbl(Soles_Final), 4)
            Ton_Final = Math.Round(CDbl(Ton_Final), 4)
            costo_soles = IIf(Ton_Final < 1, 0, Math.Round(CDbl(Soles_Final / Ton_Final), 4))
            'consumo_total = Math.Round(CDbl(Soles_Final / Ton_Final), 4)

            If Ton_Final < ValorMin Then estado_result = "D"
            If Ton_Final > ValorMax Then estado_result = "E"
            lbltonexe.Text = ""
            lbltonsol.Text = ""
            lbldefton.Text = ""
            lbldefsol.Text = ""

            If estado_result = "D" Then
                consumo_dif = ValorMin - Ton_Final
                soles_dif = consumo_dif * costo_soles
                lbldefton.Text = CDbl(consumo_dif).ToString("#,##0")
                lbldefsol.Text = CDbl(soles_dif).ToString("#,##0")
                lbltonexe.Text = ""
                lbltonsol.Text = ""
            End If
            If estado_result = "E" Then
                consumo_dif = Ton_Final - ValorMax
                soles_dif = consumo_dif * costo_soles
                lbltonexe.Text = CDbl(consumo_dif).ToString("#,##0")
                lbltonsol.Text = CDbl(soles_dif).ToString("#,##0")
                lbldefton.Text = ""
                lbldefsol.Text = ""
            End If

            Dim cont As Int32 = 0
            For Each x In xValues
                xValues(cont) = x.Substring(0, 3) & "-" & x.Substring(x.Length - 2, 2)
                cont += 1
            Next
            Chart1.Series.Clear()

            '===========serie de entradas mensuales
            Dim serie_TN_E As New Series
            serie_TN_E.Name = "Entradas"
            serie_TN_E.IsValueShownAsLabel = True
            serie_TN_E.LabelFormat = "#,##0"
            serie_TN_E.Color = Color.SteelBlue
            serie_TN_E.ChartType = SeriesChartType.Column
            serie_TN_E.Points.DataBindXY(xValues, yValues)
            Chart1.Series.Add(serie_TN_E)

            '===========serie de salidas mensuales
            Dim serie_TN_S As New Series
            serie_TN_S.Name = "Salidas"
            serie_TN_S.IsValueShownAsLabel = True
            serie_TN_S.LabelFormat = "#,##0"
            serie_TN_S.Color = Color.Red
            serie_TN_S.ChartType = SeriesChartType.Column
            serie_TN_S.Points.DataBindXY(xValues, yValues_S)
            Chart1.Series.Add(serie_TN_S)

            '===========serie de saldos mensuales
            Dim serie_TN As New Series
            serie_TN.Name = "Saldo"
            serie_TN.IsValueShownAsLabel = True
            serie_TN.LabelFormat = "#,##0"
            serie_TN.BorderWidth = 3
            serie_TN.LabelBackColor = Color.White
            serie_TN.LabelForeColor = Color.Black
            serie_TN.Color = Color.Green
            serie_TN.ChartType = SeriesChartType.Line
            serie_TN.Points.DataBindXY(xValues, yValues_Saldo)
            Chart1.Series.Add(serie_TN)

            '===========serie de valores minimos
            Dim serie_Min As New Series
            serie_Min.Name = "Min " & CInt(ValorMin).ToString("#,##0")
            serie_Min.BorderWidth = 2
            serie_Min.BorderDashStyle = ChartDashStyle.Dash
            serie_Min.Color = Color.Red
            serie_Min.ChartType = SeriesChartType.Line
            serie_Min.Points.DataBindXY(xValues, yValues_Min)
            Chart1.Series.Add(serie_Min)

            '===========serie de valores maximos
            Dim serie_Max As New Series
            serie_Max.Name = "Máx " & CInt(ValorMax).ToString("#,##0")
            serie_Max.BorderWidth = 2
            serie_Max.BorderDashStyle = ChartDashStyle.Dash
            serie_Max.Color = Color.Red
            serie_Max.ChartType = SeriesChartType.Line
            serie_Max.Points.DataBindXY(xValues, yValues_Max)
            Chart1.Series.Add(serie_Max)
            Ton_Max = IIf(Ton_Max < ValorMax, ValorMax, Ton_Max)
            Chart1.ChartAreas("ChartArea1").AxisY.Minimum = 0
            Chart1.ChartAreas("ChartArea1").AxisY.Maximum = Ton_Max + IIf(Ton_Max < 1000, 200, 500)
            Chart1.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
            Chart1.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
            Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Interval = 1

            Chart1.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function CalculaTonMes(ByVal dt As DataTable, ByVal mes As String, ByVal tipo As String) As Double
        Try
            Dim nombreMes As String = mes.Substring(0, mes.Length - 4)
            Dim ayo As Int32 = mes.Substring(mes.Length - 4, 4)
            Dim Ton As Double = 0
            Dim dtMes As New DataTable
            dtMes = dt.Clone
            Dim rows As DataRow()
            rows = dt.Select("(Ayo='" & ayo & "' AND NomMes='" & nombreMes & "') AND TipoMovimiento='" & tipo & "'")
            For Each dr As DataRow In rows
                dtMes.ImportRow(dr)
            Next
            For i As Int32 = 0 To dtMes.Rows.Count - 1
                Ton = Ton + dtMes.Rows(i)("Ton")
            Next

            'extraemos el total de entradas o salidas
            Dim dtMovimiento As New DataTable
            dtMovimiento = dt.Clone
            Dim rowsMov As DataRow()
            rowsMov = dt.Select("TipoMovimiento='" & tipo & "'")
            For Each dr As DataRow In rowsMov
                dtMovimiento.ImportRow(dr)
            Next
            If tipo = "Ingreso" Then Ton_Entrada = 0 : Ton_EntradaV = 0
            If tipo = "Salida" Then Ton_Salida = 0 : Ton_SalidaV = 0
            For i As Int32 = 0 To dtMovimiento.Rows.Count - 1
                If tipo = "Ingreso" Then
                    Ton_Entrada = Ton_Entrada + dtMovimiento.Rows(i)("Ton")
                    Ton_EntradaV = Ton_EntradaV + dtMovimiento.Rows(i)("valorizado")
                Else
                    Ton_Salida = Ton_Salida + dtMovimiento.Rows(i)("Ton")
                    Ton_SalidaV = Ton_SalidaV + dtMovimiento.Rows(i)("valorizado")
                End If
            Next
            Ton = CInt(Ton)
            If Ton > Ton_Max Then Ton_Max = Ton
            Return CInt(Ton).ToString("#,##0")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Function

    Function CalculaSaldoMes(ByVal dt As DataTable, ByVal mes As String, ByVal tipo As String) As Double
        Try
            Dim nombreMes As String = mes.Substring(0, mes.Length - 4)
            Dim ayo As Int32 = mes.Substring(mes.Length - 4, 4)
            Dim Ton As Double = 0
            Dim dtMes As New DataTable
            dtMes = dt.Clone
            Dim rows As DataRow()
            rows = dt.Select("(Ayo='" & ayo & "' AND Mes <=" & MesNro(nombreMes) & ") or Ayo< " & ayo & "")
            For Each dr As DataRow In rows
                dtMes.ImportRow(dr)
            Next
            For i As Int32 = 0 To dtMes.Rows.Count - 1
                Ton = Ton + dtMes.Rows(i)("Ton")
            Next
            Ton_Mov = Ton_Inicial
            For i As Int32 = 0 To dtMes.Rows.Count - 1
                If dtMes.Rows(i)("TipoMovimiento") = "Ingreso" Then
                    Ton_Mov = Ton_Mov + dtMes.Rows(i)("Ton")
                Else
                    Ton_Mov = Ton_Mov - dtMes.Rows(i)("Ton")
                End If
            Next
            If Ton_Mov > Ton_Max Then Ton_Max = Ton_Mov
            Return CInt(Ton_Mov).ToString("#,##0")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Function CalculaSolesMes(ByVal dt As DataTable, ByVal mes As String, ByVal tipo As String) As Double
        Dim nombreMes As String = mes.Substring(0, mes.Length - 4)
        Dim ayo As Int32 = mes.Substring(mes.Length - 4, 4)
        Dim Soles As Double = 0
        Dim dtMes As New DataTable
        dtMes = dt.Clone
        Dim rows As DataRow()
        rows = dt.Select("(Ayo='" & ayo & "' AND NomMes='" & nombreMes & "') AND TipoMovimiento='" & tipo & "'")
        For Each dr As DataRow In rows
            dtMes.ImportRow(dr)
        Next
        For i As Int32 = 0 To dtMes.Rows.Count - 1
            Soles = Soles + dtMes.Rows(i)("valorizado")
        Next

        'extraemos el total de entradas o salidas

        'Dim dtMovimiento As New DataTable
        'dtMovimiento = dt.Clone
        'Dim rowsMov As DataRow()
        'rowsMov = dt.Select("TipoMovimiento='" & tipo & "'")
        'For Each dr As DataRow In rowsMov
        '    dtMovimiento.ImportRow(dr)
        'Next

        'If tipo = "Ingreso" Then Ton_Entrada = 0
        'If tipo = "Salida" Then Ton_Salida = 0
        'For i As Int32 = 0 To dtMovimiento.Rows.Count - 1
        '    If tipo = "Ingreso" Then
        '        Ton_Entrada = Ton_Entrada + dtMovimiento.Rows(i)("Ton")
        '    Else
        '        Ton_Salida = Ton_Salida + dtMovimiento.Rows(i)("Ton")
        '    End If
        'Next
        Soles = CInt(Soles)
        If Soles > Soles_Max Then Soles_Max = Soles
        Return CInt(Soles).ToString("#,##0")
    End Function

    Sub GraficaSoles(ByVal dt As DataTable, ByVal cadenaMes As String)
        Try
            LimpiaGraficaSoles()
            Chart2.Visible = True
            Dim xValues() As String
            xValues = cadenaMes.Split(",")
            Dim yValues(xValues.Count - 1) As Double
            Dim yValues_S(xValues.Count - 1) As Double
            For i As Int32 = 0 To xValues.Count - 1
                yValues(i) = CalculaSolesMes(dt, xValues(i), "Ingreso")
                yValues_S(i) = CalculaSolesMes(dt, xValues(i), "Salida")
                'yValues_S(i) = CInt(CalculaSolesMes(dt, xValues(i), "Salida")).ToString("#,###")
            Next
            Dim cont As Int32 = 0
            For Each x In xValues
                xValues(cont) = x.Substring(0, 3) & "-" & x.Substring(x.Length - 2, 2)
                cont += 1
            Next
            '=================================================================Calculos totales

            Chart2.Series.Clear()
            Dim serie_TN_E As New Series
            serie_TN_E.Name = "Entradas"
            serie_TN_E.IsValueShownAsLabel = True
            serie_TN_E.LabelFormat = "#,##0"
            serie_TN_E.Color = Color.SteelBlue
            serie_TN_E.ChartType = SeriesChartType.Column
            serie_TN_E.Points.DataBindXY(xValues, yValues)
            Chart2.Series.Add(serie_TN_E)

            Dim serie_TN_S As New Series
            serie_TN_S.Name = "Salidas"
            serie_TN_S.IsValueShownAsLabel = True
            serie_TN_S.LabelFormat = "#,##0"
            'serie_TN_S.
            serie_TN_S.Color = Color.Red
            serie_TN_S.ChartType = SeriesChartType.Column
            serie_TN_S.Points.DataBindXY(xValues, yValues_S)
            Chart2.ChartAreas("ChartArea1").AxisY.Maximum = Soles_Max + IIf(Soles_Max < 10000, 2000, 5000)
            Chart2.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
            Chart2.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
            'serie_TN_E.Font = New Font(Me.Font.Name, 7, FontStyle.Regular)
            'serie_TN_S.Font = New Font(Me.Font.Name, 7, FontStyle.Regular)
            Chart2.Series.Add(serie_TN_S)
            Chart2.ChartAreas("ChartArea1").AxisX.LabelStyle.Interval = 1
            Chart2.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function MesNro(ByVal mes As String) As Int32
        Select Case mes
            Case "ENERO"
                Return 1
            Case "FEBRERO"
                Return 2
            Case "MARZO"
                Return 3
            Case "ABRIL"
                Return 4
            Case "MAYO"
                Return 5
            Case "JUNIO"
                Return 6
            Case "JULIO"
                Return 7
            Case "AGOSTO"
                Return 8
            Case "SETIEMBRE"
                Return 9
            Case 10
                Return 10
            Case "NOVIEMBRE"
                Return 11
            Case Else
                Return 12
        End Select
        Return ""
    End Function

    Function nombreMEs(ByVal mes As Int32) As String
        Select Case mes
            Case 1
                Return "ENERO"
            Case 2
                Return "FEBRERO"
            Case 3
                Return "MARZO"
            Case 4
                Return "ABRIL"
            Case 5
                Return "MAYO"
            Case 6
                Return "JUNIO"
            Case 7
                Return "JULIO"
            Case 8
                Return "AGOSTO"
            Case 9
                Return "SETIEMBRE"
            Case 10
                Return "OCTUBRE"
            Case 11
                Return "NOVIEMBRE"
            Case Else
                Return "DICIEMBRE"
        End Select
        Return ""
    End Function

    Private Sub gridAlmacen_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridAlmacen.ClickCell
        Try
            If gridAlmacen.ActiveRow.Index < 0 Then Exit Sub
            cargaRuma()
            ProcesaData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridRuma_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridRuma.ClickCell
        Try
            If gridRuma.ActiveRow.Index < 0 Then Exit Sub
            gridRuma.PerformAction(ExitEditMode)
            Dim cadenaRuma As String = ""
            For i As Int32 = 0 To gridRuma.Rows.Count - 1
                If gridRuma.Rows(i).Cells("sel").Value = True Then
                    If cadenaRuma.Length > 0 Then MsgBox("No puede seleccionar más de una Ruma", MsgBoxStyle.Information, "Validación") : gridRuma.ActiveRow.Cells("sel").Value = False : Exit Sub
                    cadenaRuma = cadenaRuma + "'" + gridRuma.Rows(i).Cells("COD_RUMA").Value.ToString.Substring(0, 8) + "',"
                End If
            Next
            cargaMineral()
            ProcesaData()
            RumaEnlazada()
            'If gridComposicion.Rows.Count <= 0 Then
            ' gridRuma.ActiveRow.Cells("sel").Value = False
            'End If
            Button1_Click(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Sub RumaEnlazada()

        'SELECCIONAMOS LOS MINERALES QUE PERTENECEN A LAS RUMAS SELECCIONADAS
        Dim cadenaAlmacen As String = ""
        Dim cadenaRuma As String = ""
        gridAlmacen.PerformAction(ExitEditMode)
        gridRuma.PerformAction(ExitEditMode)
        cadenaAlmacen = ""
        cadenaRuma = ""
        Dim dtRumasEnlazadas As New DataTable
        dtRumasEnlazadas = dtRumaEnlazada.Clone
        gridRenlazada.DataSource = dtRumasEnlazadas

        For i As Int32 = 0 To gridAlmacen.Rows.Count - 1
            If gridAlmacen.Rows(i).Cells("sel").Value = True Then
                cadenaAlmacen = cadenaAlmacen + "'" + gridAlmacen.Rows(i).Cells("COD_ALMACEN").Value + "',"
            End If
        Next
        For i As Int32 = 0 To gridRuma.Rows.Count - 1
            If gridRuma.Rows(i).Cells("sel").Value = True Then
                cadenaRuma = cadenaRuma + "'" + gridRuma.Rows(i).Cells("COD_RUMA").Value.ToString.Substring(0, 8) + "',"
            End If
        Next
        If cadenaAlmacen.Length <= 0 Then Exit Sub
        If cadenaRuma.Length <= 0 Then Exit Sub
        Dim dtMineralxRuma As New DataTable
        dtMineralxRuma = dtRumaEnlazada.Clone
        Dim rows As DataRow()
        rows = dtRumaEnlazada.Select("COD_ALM IN(" & cadenaAlmacen & ") AND COD_RUMA IN(" & cadenaRuma & ")")
        dtMineralxRuma = dtRumaEnlazada.Clone
        For Each dr1 As DataRow In rows
            dtMineralxRuma.ImportRow(dr1)
        Next


        'SELECCIONAMOS LAS RUMAS ENLAZADAS A LOS MINERALES
        Dim cadenaMineral As String = ""
        For i As Int32 = 0 To dtMineralxRuma.Rows.Count - 1
            cadenaMineral = cadenaMineral + "'" + dtMineralxRuma.Rows(i)("COD_MINERAL").ToString.Trim + "',"
        Next

        Dim rows1 As DataRow()
        'rows1 = dtRumaEnlazada.Select("COD_RUMA NOT IN(" & cadenaRuma & ") AND COD_MINERAL IN(" & cadenaMineral & ")")
        rows1 = dtRumaEnlazada.Select("COD_ALM IN(" & cadenaAlmacen & ") AND Agrupacion IN(" & cadenaRuma & ")")
        Dim ruma As String = ""
        For Each dr1 As DataRow In rows1
            'If ruma <> dr1(2) Then
            dtRumasEnlazadas.ImportRow(dr1)
            ruma = dr1(2)
            'End If
        Next
        gridRenlazada.DataSource = dtRumasEnlazadas
        'dtRumaEnlazada
    End Sub

    Private Sub chkmes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkmes.CheckedChanged
        Try
            For i As Int32 = 0 To gridMes.Rows.Count - 1
                gridMes.Rows(i).Cells("sel").Value = chkmes.Checked
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkalmacen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkalmacen.CheckedChanged
        Try
            For i As Int32 = 0 To gridAlmacen.Rows.Count - 1
                gridAlmacen.Rows(i).Cells("sel").Value = chkalmacen.Checked
            Next
            cargaRuma()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkruma_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkruma.CheckedChanged
        Try
            If chkruma.Checked = True Then Exit Sub
            For i As Int32 = 0 To gridRuma.Rows.Count - 1
                gridRuma.Rows(i).Cells("sel").Value = chkruma.Checked
            Next
            cargaMineral()
            ProcesaData()
            RumaEnlazada()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridTipo_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridTipo.ClickCell
        Try
            If gridTipo.ActiveRow.Index < 0 Then Exit Sub
            gridTipo.PerformAction(ExitEditMode)
            ProcesaData()
            RptSemaforo()
            Button1_Click(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridMes_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridMes.ClickCell
        Try
            If gridMes.ActiveRow.Index < 0 Then Exit Sub
            gridMes.PerformAction(ExitEditMode)
            ProcesaData()
        Catch ex As Exception

        End Try
    End Sub

    Sub RptSemaforo()
        Dim i As Int32 = 0
        Try
            Dim dtreporte As New DataTable
            dtreporte.Columns.Add("COD_RUMA")
            dtreporte.Columns.Add("RUMA")
            dtreporte.Columns.Add("SALDO").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("CONSUMO_PROM")
            dtreporte.Columns.Add("MES_STOCK")
            dtreporte.Columns.Add("OBSERVACION")
            dtreporte.Columns.Add("MES_MINIMO")
            dtreporte.Columns.Add("MES_MAXIMO")
            dtreporte.Columns.Add("ESTADO")
            dtreporte.Columns.Add("SOLES")
            dtreporte.Columns.Add("RESULTADO")
            dtreporte.Columns.Add("DIF_TON")
            dtreporte.Columns.Add("DIF_SOL")
            dtreporte.Columns.Add("INICIAL").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("INGRESOS").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("SALIDAS").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("ALMACEN")

            Dim dr As DataRow
            Dim ton_ini As Double = 0
            Dim codruma As String = ""
            Dim tn_ingreso As Double = 0
            Dim tn_salida As Double = 0
            Dim saldo As Double = 0

            Dim soles As Double = 0
            Dim sol_ini As Double = 0
            Dim sol_ingreso As Double = 0
            Dim sol_salida As Double = 0

            Dim resultado As String = ""
            Dim dif_ton As Double = 0
            Dim dif_sol As Double = 0
            Dim valor_min As Double = 0
            Dim valor_max As Double = 0

            Dim cadenaMes As String = ""
            Dim observacion As String = ""
            Dim min_mes As Int32 = 0
            Dim max_mes As Int32 = 0
            Dim mes_stock As Integer = 0
            Dim ayoini As Int32 = Year(dtFechaIni.Value)
            Dim ayofin As Int32 = Year(dtFechaFin.Value)
            Dim mesini As Int32 = Month(dtFechaIni.Value)
            Dim mesfin As Int32 = Month(dtFechaFin.Value)
            Dim nro_mes As Int32 = 0
            Dim cadenaMesNom As String = ""
            'For i = 0 To gridMes.Rows.Count - 1
            '    cadenaMes = cadenaMes + gridMes.Rows(i).Cells("MES_NRO").Value + ","
            '    If (x = ayoini And nro_mes >= mesini And ayoini <> ayofin) Or (x = ayofin And nro_mes <= mesfin) Or (x > ayoini And x < ayofin) Then
            '        cadenaMesNom = cadenaMesNom + gridMes.Rows(i).Cells("MES").Value + x.ToString + ","
            '    End If
            'Next

            For x As Int32 = ayoini To ayofin
                For i = 0 To gridMes.Rows.Count - 1
                    If gridMes.Rows(i).Cells("sel").Value = True Then
                        nro_mes = gridMes.Rows(i).Cells("MES_NRO").Value
                        cadenaMes = cadenaMes + gridMes.Rows(i).Cells("MES_NRO").Value + ","
                        If (x = ayoini And nro_mes >= mesini And ayoini <> ayofin) Or (x = ayofin And nro_mes <= mesfin) Or (x > ayoini And x < ayofin) Then
                            cadenaMesNom = cadenaMesNom + gridMes.Rows(i).Cells("MES").Value + x.ToString + ","
                        End If

                    End If
                Next
            Next

            If cadenaMes.Length <= 0 Then Exit Sub
            cadenaMes = cadenaMes.Substring(0, cadenaMes.Length - 1)
            If cadenaMesNom.Length <= 0 Then Exit Sub
            cadenaMesNom = cadenaMesNom.Substring(0, cadenaMesNom.Length - 1)

            Dim promedio As Integer = 0


            Dim cadenaAlmacen As String = ""
            For i = 0 To gridAlmacen.Rows.Count - 1
                cadenaAlmacen = cadenaAlmacen + "'" + gridAlmacen.Rows(i).Cells("COD_ALMACEN").Value + "',"
            Next
            If cadenaAlmacen.Length <= 0 Then Exit Sub
            Dim cadenaTipomov As String = ""
            For i = 0 To gridTipo.Rows.Count - 1
                If gridTipo.Rows(i).Cells("sel").Value = True Then
                    cadenaTipomov = cadenaTipomov + "'" + gridTipo.Rows(i).Cells("ID_TIPO").Value + "',"
                End If
            Next
            For i = 0 To dtRuma.Rows.Count - 1
                codruma = dtRuma(i)("COD_RUMA").ToString.Substring(0, 8)
                'If codruma = "AGR00006" Then
                ' MsgBox("")
                'End If
                tn_ingreso = CalculaTonMesRuma(dtData, cadenaMes, "Ingreso", codruma, cadenaTipomov)
                tn_salida = CalculaTonMesRuma(dtData, cadenaMes, "Salida", codruma, cadenaTipomov)
                ton_ini = TonInicial(cadenaAlmacen, codruma)
                saldo = Math.Round(CDbl(ton_ini), 4) + Math.Round(CDbl(tn_ingreso), 4) - Math.Round(CDbl(tn_salida), 4)
                'If saldo < 0 Then saldo = 0
                saldo = Math.Round(CDbl(saldo), 4)
                'If dtRuma(i)("COD_RUMA").ToString.Substring(0, 8) = "00000046" Then
                promedio = CInt(CalculaPromRuma(dtData, cadenaMesNom, codruma, tn_salida))
                'End If


                sol_ingreso = CalculaSolesMesRuma(dtData, cadenaMes, "Ingreso", codruma, cadenaTipomov)
                sol_salida = CalculaSolesMesRuma(dtData, cadenaMes, "Salida", codruma, cadenaTipomov)
                sol_ini = SolInicial(cadenaAlmacen, codruma)
                soles = sol_ini + sol_ingreso - sol_salida
                soles = Math.Round(CDbl(soles), 4)

                Dim rows_Config As DataRow()
                rows_Config = dtConfigMeses.Select(" COD_RUMA ='" & codruma & "'")
                Dim dtConf As New DataTable
                dtConf = dtConfigMeses.Clone
                For Each dr1 As DataRow In rows_Config
                    dtConf.ImportRow(dr1)
                Next
                observacion = ""
                min_mes = 0
                max_mes = 0
                If dtConf.Rows.Count > 0 Then
                    observacion = dtConf(0)("DESCRIPCION")
                    min_mes = dtConf(0)("MIN_MESES")
                    max_mes = dtConf(0)("MAX_MESES")
                End If


               
                Dim consumo_dif As Double = 0
                Prom_max = promedio
                PromedioHistoricoRuma(dtRuma(i)("COD_RUMA").ToString.Substring(0, 8))

                If tn_salida > 0 Then
                    dr = dtreporte.NewRow
                    dr(0) = dtRuma(i)("COD_RUMA")
                    dr(1) = dtRuma(i)("RUMA")
                    dr(2) = CDbl(saldo).ToString("#,##0.00")
                    dr(3) = CInt(IIf(saldo = 0, 0, Prom_max)).ToString("#,##0")
                    mes_stock = CInt(IIf(Prom_max = 0, 0, saldo / Prom_max)).ToString("#,##0")
                    dr(4) = mes_stock
                    dr(5) = observacion
                    dr(6) = min_mes
                    dr(7) = max_mes
                    dr(8) = IIf(mes_stock < min_mes Or mes_stock > max_mes, "NO CUMPLE", "CUMPLE")
                    dr(9) = CInt(soles).ToString("#,##0")
                    'If codruma = "AGR00002" Then
                    '    MsgBox("")
                    'End If
                    If dr(8) = "NO CUMPLE" Then
                        valor_min = CInt(min_mes * Prom_max)
                        valor_max = CInt(max_mes * Prom_max)
                        If saldo < valor_min Then resultado = "D"
                        If saldo > valor_max Then resultado = "E"
                        dr(10) = IIf(resultado = "D", "Déficit", "Excedente")
                        Dim costo_soles As Double = 0
                        'Ton_Final < -0.5 Or Ton_Final < 0.5
                        costo_soles = IIf(saldo < 1, 0, Math.Round(CDbl(soles / saldo), 4))
                        Dim soles_dif As Double = 0
                        If resultado = "D" Then
                            consumo_dif = saldo - valor_min
                            soles_dif = consumo_dif * costo_soles
                        End If
                        If resultado = "E" Then
                            consumo_dif = saldo - valor_max
                            soles_dif = consumo_dif * costo_soles
                        End If
                        dr(11) = CInt(consumo_dif).ToString("#,##0")
                        dr(12) = CInt(soles_dif).ToString("#,##0")
                    End If
                    dr(13) = CDbl(ton_ini).ToString("#,##0.00")
                    dr(14) = CDbl(tn_ingreso).ToString("#,##0.00")
                    dr(15) = CDbl(tn_salida).ToString("#,##0.00")
                    dr(16) = dtRuma(i)("ALMACEN")
                    dtreporte.Rows.Add(dr)
                End If

            Next
            Dim dtSaldoRuma As New DataTable


            gridReporte.DataSource = dtreporte

            Dim dtNoCumple As New DataTable
            dtNoCumple = dtreporte.Clone
            Dim rows As DataRow()
            rows = dtreporte.Select("ESTADO='NO CUMPLE'")
            For Each dr1 As DataRow In rows
                dtNoCumple.ImportRow(dr1)
            Next
            'Dim dvOrdenado As New DataView(dtNoCumple)
            'dvOrdenado.Sort = "SALDO"
            gridReportenoCumple.DataSource = dtNoCumple
        Catch ex As Exception
            MsgBox(i)
            MsgBox(ex.Message)
        End Try
    End Sub

    Function TonInicial(ByVal cadenaAlmacen As String, ByVal ruma As String) As Double
        Dim rows_Ini As DataRow()
        Dim tn As Double = 0
        Dim dt As New DataTable
        dt = dtSaldoInicial.Clone
        rows_Ini = dtSaldoInicial.Select("COD_ALM IN(" & cadenaAlmacen & ") AND COD_RUMA ='" & ruma & "'")
        For Each dr As DataRow In rows_Ini
            dt.ImportRow(dr)
        Next
        For i As Int32 = 0 To dt.Rows.Count - 1
            tn = tn + dt.Rows(i)("SALDO")
        Next
        Return tn
    End Function

    Function SolInicial(ByVal cadenaAlmacen As String, ByVal ruma As String) As Double
        Dim rows_Ini As DataRow()
        Dim tn As Double = 0
        Dim dt As New DataTable
        dt = dtSaldoInicial.Clone
        rows_Ini = dtSaldoInicial.Select("COD_ALM IN(" & cadenaAlmacen & ") AND COD_RUMA ='" & ruma & "'")
        For Each dr As DataRow In rows_Ini
            dt.ImportRow(dr)
        Next
        For i As Int32 = 0 To dt.Rows.Count - 1
            tn = tn + dt.Rows(i)("COSTO")
        Next
        Return tn
    End Function

    Function CalculaPromRuma(ByVal dt As DataTable, ByVal cadenames As String, ByVal ruma As String, ByVal salida As Double) As Double
        If cadenames.Length <= 0 Then Exit Function
        Dim promedio As Double = 0
        Dim xValues() As String
        xValues = cadenames.Split(",")
        Dim yValues(xValues.Count - 1) As Double
        Dim yValues_S(xValues.Count - 1) As Double
        'If dtMes.Rows.Count <= 0 Then Return 0
        For i As Int32 = 0 To xValues.Count - 1
            yValues_S(i) = CalculaTonMesRumaDet(dtData, xValues(i), "Salida", ruma) 'CalculaTonMes(dtMes, xValues(i), "Salida")
        Next
        cant_Salida = 0
        For Each i In yValues_S
            If i <> 0 Then cant_Salida += 1
        Next
        promedio = IIf(cant_Salida = 0, 0, salida / cant_Salida)

        Return promedio
    End Function

    Function CalculaTonMesRumaDet(ByVal dt As DataTable, ByVal mes As String, ByVal tipo As String, ByVal ruma As String) As Double
        Dim Ton As Double = 0
        Dim dtMes As New DataTable
        dtMes = dt.Clone
        Dim nombreMes As String = mes.Substring(0, mes.Length - 4)
        Dim ayo As Int32 = mes.Substring(mes.Length - 4, 4)
        'Dim Ton As Double = 0
        'Dim dtMes As New DataTable
        dtMes = dt.Clone
        'Dim rows As DataRow()
        'rows = dt.Select("(Ayo='" & ayo & "' AND NomMes='" & nombreMEs() & "') AND TipoMovimiento='" & tipo & "'")

        Dim rows As DataRow()
        rows = dt.Select("(Ayo='" & ayo & "' AND NomMes='" & nombreMes & "') AND TipoMovimiento='" & tipo & "' and cod_Ruma='" & ruma & "'")
        For Each dr As DataRow In rows
            dtMes.ImportRow(dr)
        Next
        For i As Int32 = 0 To dtMes.Rows.Count - 1
            Ton = Ton + dtMes.Rows(i)("Ton")
        Next
        Return Ton
    End Function

    Function CalculaTonMesRuma(ByVal dt As DataTable, ByVal cadenames As String, ByVal tipo As String, ByVal ruma As String, ByVal cadenaTipomov As String) As Double
        Dim Ton As Double = 0
        Dim dtMes As New DataTable
        dtMes = dt.Clone
        Dim rows As DataRow()
        rows = dt.Select("Mes in(" & cadenames & ") AND TipoMovimiento='" & tipo & "' and cod_Ruma='" & ruma & "' AND flgtransferencia IN(" & cadenaTipomov & ")")
        For Each dr As DataRow In rows
            dtMes.ImportRow(dr)
        Next
        For i As Int32 = 0 To dtMes.Rows.Count - 1
            Ton = Ton + dtMes.Rows(i)("Ton")
        Next
        Return Ton
    End Function

    Function CalculaSolesMesRuma(ByVal dt As DataTable, ByVal cadenames As String, ByVal tipo As String, ByVal ruma As String, ByVal cadenaTipomov As String) As Double
        Dim Ton As Double = 0
        Dim dtMes As New DataTable
        dtMes = dt.Clone
        Dim rows As DataRow()
        rows = dt.Select("Mes in(" & cadenames & ") AND TipoMovimiento='" & tipo & "' and cod_Ruma='" & ruma & "' AND flgtransferencia IN(" & cadenaTipomov & ")")
        For Each dr As DataRow In rows
            dtMes.ImportRow(dr)
        Next
        For i As Int32 = 0 To dtMes.Rows.Count - 1
            Ton = Ton + dtMes.Rows(i)("valorizado")
        Next
        Return Ton
    End Function

    Private Sub btncambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncambiar.Click
        Dim frm As New FrmPoliticaInv
        frm.ShowDialog()
        cargaConfMeses()
        ProcesaData()
    End Sub

    Private Sub btncambiagrafica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncambiagrafica.Click
        Chart1.Visible = True
        Chart2.Visible = False
        Label5.Text = "Gráfica de toneladas"
        'If btncambiagrafica.Text = "G. Soles" Then
        '    Chart1.Visible = False
        '    Chart2.Visible = True
        '    btncambiagrafica.Text = "G. Ton"
        '    Label5.Text = "Gráfica de Soles"
        'Else
        '    Chart1.Visible = True
        '    Chart2.Visible = False
        '    btncambiagrafica.Text = "G. Soles"
        '    Label5.Text = "Gráfica de toneladas"
        'End If
    End Sub

    Private Sub gridReporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridReporte.Click
      VerComentario
    End Sub

    Private Sub gridReporte_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridReporte.ClickCell
        VerComentario()
    End Sub

    Sub VerComentario()
        Try
            If gridReporte.ActiveRow.Index < 0 Then Exit Sub
            Dim dtComentario As New DataTable
            _objNegocio_ = New NGProducto
            _objEntidad_ = New ETProducto
            Dim codruma As String = gridReporte.ActiveRow.Cells("COD_RUMA").Value.ToString.Substring(0, 8)
            dtComentario = _objNegocio_.ListaComentarioControl(codruma, "")
            If dtComentario.Rows.Count > 0 Then
                txtobservacion.Text = dtComentario.Rows(0)("COMENTARIO")
            Else
                txtobservacion.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridReporte_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridReporte.DoubleClickRow
        VerHistorial()
    End Sub

    Private Sub gridReporte_FilterRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.FilterRowEventArgs) Handles gridReporte.FilterRow
        Try
            If e.Row.Cells("ESTADO").Value.ToString.Trim = "CUMPLE" Then
                e.Row.Appearance.ForeColor = Color.Green
            Else
                e.Row.Appearance.ForeColor = Color.Red
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btngraficasoles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngraficasoles.Click
        Chart1.Visible = False
        Chart2.Visible = True
        Label5.Text = "Gráfica de Soles"
    End Sub

    Private Sub chkrumaenlazada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkrumaenlazada.CheckedChanged
        Try
            If chkrumaenlazada.Checked = True Then

                If gridRuma.Rows.Count <= 0 Then chkrumaenlazada.Checked = False : Exit Sub
                Dim ruma_enlazada As String = ""
                Dim ruma As String = ""
                For i As Int32 = 0 To gridRenlazada.Rows.Count - 1
                    ruma_enlazada = gridRenlazada.Rows(i).Cells("COD_RUMA").Value.ToString.Substring(0, 8)
                    For x As Int32 = 0 To gridRuma.Rows.Count
                        ruma = gridRuma.Rows(x).Cells("COD_RUMA").Value.ToString.Substring(0, 8)
                        If ruma_enlazada = ruma Then
                            gridRuma.Rows(x).Cells("sel").Value = True
                            Exit For
                        End If
                    Next
                Next
                gridTipo.Rows(1).Cells("sel").Value = False
                cargaMineral()
                ProcesaData()
                RumaEnlazada()
                chkrumaenlazada.Checked = False

                If gridRenlazada.Rows.Count > 0 Then
                    chkrumaenlazada.Checked = True
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub DataReporte()
        Dim i As Int32
        Try
            Dim dtreporte As New DataTable
            dtreporte.Columns.Add("COD_RUMA")
            dtreporte.Columns.Add("RUMA")
            dtreporte.Columns.Add("SALDO").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("CONSUMO_PROM").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("MES_STOCK")
            dtreporte.Columns.Add("OBSERVACION")
            dtreporte.Columns.Add("MES_MINIMO")
            dtreporte.Columns.Add("MES_MAXIMO")
            dtreporte.Columns.Add("ESTADO")
            dtreporte.Columns.Add("SOLES").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("RESULTADO")
            dtreporte.Columns.Add("DIF_TON").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("DIF_SOL").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("INICIAL").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("INGRESOS").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("SALIDAS").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("ALMACEN")
            dtreporte.Columns.Add("STOCK_SUGERIDO").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("INGRESO_PROMEDIO").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("SALIDA_PROMEDIO").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("PESO%").DataType = System.Type.GetType("System.Decimal")
            dtreporte.Columns.Add("COSTO_MINERAL").DataType = System.Type.GetType("System.Decimal")

            Dim mes As Double = CDate(dtFechaFin.Value).Month - 1
            Dim dias As Double = CDate(dtFechaFin.Value).Day
            If dias > 30 Then dias = 30
            dias = Math.Round(CDbl(dias / 30), 2)
            mes = mes + dias

            Dim total_salida As Double = 0
            For i = 0 To gridReporte.Rows.Count - 1
                total_salida = total_salida + gridReporte.Rows(i).Cells("SALIDAS").Value
            Next

            Dim dr As DataRow            
            For i = 0 To gridReporte.Rows.Count - 1
                dr = dtreporte.NewRow
                Dim consumo_prom As Double = gridReporte.Rows(i).Cells("CONSUMO_PROM").Value
                Dim mes_max As Double = gridReporte.Rows(i).Cells("MES_MAXIMO").Value
                Dim ingresos As Double = gridReporte.Rows(i).Cells("INGRESOS").Value
                Dim salidas As Double = gridReporte.Rows(i).Cells("SALIDAS").Value
                Dim saldo As Double = gridReporte.Rows(i).Cells("SALDO").Value
                Dim soles As Double = gridReporte.Rows(i).Cells("SOLES").Value
                Dim cod_ruma As String = gridReporte.Rows(i).Cells("COD_RUMA").Value

                dr(0) = cod_ruma 'gridReporte.Rows(i).Cells("COD_RUMA").Value
                dr(1) = gridReporte.Rows(i).Cells("RUMA").Value
                dr(2) = saldo
                dr(3) = consumo_prom
                dr(4) = gridReporte.Rows(i).Cells("MES_STOCK").Value
                dr(5) = gridReporte.Rows(i).Cells("OBSERVACION").Value
                dr(6) = gridReporte.Rows(i).Cells("MES_MINIMO").Value
                dr(7) = mes_max
                dr(8) = gridReporte.Rows(i).Cells("ESTADO").Value
                dr(9) = soles
                dr(10) = gridReporte.Rows(i).Cells("RESULTADO").Value
                dr(11) = gridReporte.Rows(i).Cells("DIF_TON").Value
                dr(12) = gridReporte.Rows(i).Cells("DIF_SOL").Value
                dr(13) = gridReporte.Rows(i).Cells("INICIAL").Value
                dr(14) = ingresos
                dr(15) = salidas
                dr(16) = gridReporte.Rows(i).Cells("ALMACEN").Value
                dr(17) = consumo_prom * mes_max
                dr(18) = Math.Round(CDbl(ingresos / mes), 2)
                dr(19) = Math.Round(CDbl(salidas / mes), 2)
                dr(20) = Math.Round(CDbl(IIf(total_salida = 0, 0, salidas / total_salida)), 6)
                dr(21) = Math.Round(CDbl(IIf(saldo = 0, 0, soles / saldo)), 2)
                dtreporte.Rows.Add(dr)
            Next
            gridReporteStock.DataSource = dtreporte
        Catch ex As Exception
            MsgBox("fila " & i & ": " & ex.Message)
        End Try

    End Sub
    Private Sub btnexportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexportar.Click
        Try
            DataReporte()
            Imprimir()
            'Dim m_Excel As New Microsoft.Office.Interop.Excel.Application
            'Dim libro_excel As Microsoft.Office.Interop.Excel.Workbook = Nothing
            'Dim h_hoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing
            'm_Excel.DisplayAlerts = False
            'Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = m_Excel.Worksheets(1)

            'With objHojaExcel
            '    .Visible = Microsoft.Office.Interop.Excel.XlSheetVisibility.xlSheetVisible
            '    .Activate()
            '    Dim Sql As String
            '    If cierre = 0 Then
            '        Sql = "uSp_Costo_mano_obra_produccion '01'," & txtayo.Value & "," & cmbMes.Value & ",'PL'"
            '    Else
            '        Sql = "select CODTIPO,DIA,TURNO,COD_PER,NUMDOC,COD_EQUIPO,COSTEAR,SOLESPORHORA,NROHRS,HORASEF," & _
            '        "VALORBI,EQUIPO,NOMBRE from Tbl_Cost_Mo_Molino_Personal " & _
            '        "where ayo=" & txtayo.Value & " and mes=" & cmbMes.Value & ""
            '    End If
            '    With m_Excel.ActiveWorkbook.PivotCaches.Create(Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlExternal)

            '        Dim sCnx As String

            '        sCnx = "OLEDB;Provider=SQLOLEDB.1;Use Procedure for Prepare=1;Use Encryption for Data=False;Auto Translate=True;" & _
            '        "Password =" & PASSINI & ";" & _
            '        "Persist Security Info=False;" & _
            '        "User ID=" & USERINI & ";" & _
            '        "Initial Catalog=" & BDINI & ";" & _
            '        "Data Source=" & DATASOURCE & ""

            '        .Connection = sCnx
            '        .CommandType = Microsoft.Office.Interop.Excel.XlCmdType.xlCmdSql
            '        .CommandText = Sql

            '        .CreatePivotTable(TableDestination:=m_Excel.ActiveWorkbook.ActiveSheet.Range("A3"), TableName:="Tabla dinámica1")
            '    End With

            '    With m_Excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1")
            '        'With .PivotFields("Centro_Costo")
            '        '    .Orientation = Excel.XlPivotFieldOrientation.xlPageField
            '        '    .Position = 1
            '        '    .Name = "Centro_Costo"
            '        'End With

            '        With .PivotFields("EQUIPO")
            '            .Orientation = Excel.XlPivotFieldOrientation.xlRowField
            '            .Position = 1
            '        End With

            '        With .PivotFields("NOMBRE")
            '            .Orientation = Excel.XlPivotFieldOrientation.xlRowField
            '            .Position = 2
            '        End With

            '        .AddDataField(.PivotFields("HORASEF"), "Suma de HORASEF", Excel.XlConsolidationFunction.xlSum)
            '        m_Excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("Suma de HORASEF").NumberFormat = "#,##0.00"

            '        .AddDataField(.PivotFields("ValorBi"), "Suma de ValorBi", Excel.XlConsolidationFunction.xlSum)
            '        m_Excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1").PivotFields("Suma de ValorBi").NumberFormat = "#,##0.00"

            '    End With
            'End With
            'm_Excel.ActiveWorkbook.ActiveSheet.PivotTables("Tabla dinámica1").SubtotalLocation(Excel.XlSubtototalLocationType.xlAtBottom)

        Catch ex As Exception

        End Try
    End Sub
    Sub Imprimir()
        If gridReporte.Rows.Count <= 0 Then
            MsgBox("No existen datos a exportar", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If
        'Dim rpta As Long
        Dim ruta As String = Application.StartupPath & "\CONTROL_POR_RUMA.xls"
        Dim archivoexcel As String = Trim(ruta)

        Try
            'If Trim(Dir(Trim(ruta), vbArchive)) <> "" Then
            '    rpta = MsgBox("Archivo ya Existe" & Chr(13) & "Desea Reemplazarlo", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
            '    If rpta = vbNo Then Exit Sub
            'End If
            Me.UltraGridExcelExporter1.Export(gridReporteStock, ruta)
            ''poner cabecera
            Call poner_cabecera_archivo_excel(archivoexcel)

            MessageBox.Show("Exportado: " & Chr(13) & ruta, "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Abrir_Archivo(ruta)
            'Me.Close()

        Catch ex As Exception
            'MessageBox.Show("Ruta Especificada No Existe", "Invalid File Name")
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub poner_cabecera_archivo_excel(ByVal p_archivo As String)
        Dim archivo_excel As New Microsoft.Office.Interop.Excel.Application
        Dim libro_excel As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim h_hoja As Microsoft.Office.Interop.Excel.Worksheet = Nothing

        ''abrir el archivo excel
        Try
            libro_excel = archivo_excel.Workbooks.Open(p_archivo, , False, , , , True, , , True)
        Catch ex As Exception
            MsgBox("Error al intentar abrir el Archivo" & vbCrLf & ex.Message.ToString)
        End Try

        Try
            h_hoja = libro_excel.Sheets(1)
            h_hoja.Range("A1:AZ3").Insert()
            h_hoja.Range("A2:H2").Merge()
            h_hoja.Range("A2:H2").Font.Bold = True
            h_hoja.Range("A2:DG2").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            h_hoja.Range("A1").Font.Bold = True
            h_hoja.Range("A1").ColumnWidth = 45
            h_hoja.Range("B1").ColumnWidth = 10
            h_hoja.Range("C1").ColumnWidth = 10
            h_hoja.Range("D1").ColumnWidth = 10
            h_hoja.Range("E1").ColumnWidth = 10
            h_hoja.Range("F1").ColumnWidth = 10
            h_hoja.Range("G1").ColumnWidth = 10
            h_hoja.Range("H1").ColumnWidth = 10
            h_hoja.Range("I1").ColumnWidth = 18
            h_hoja.Range("J1").ColumnWidth = 8
            h_hoja.Range("K1").ColumnWidth = 8
            h_hoja.Range("L1").ColumnWidth = 20
            h_hoja.Range("B:F").NumberFormat = "#,##0.00"
            h_hoja.Range("N:O").NumberFormat = "#,##0.00"
            h_hoja.Range("F:H").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
            h_hoja.Cells(1, 1).value = "CIA. MINERA AGREGADOS CALCAREOS S.A."
            h_hoja.Cells(2, 1).value = "REPORTE DE CONTROL POR RUMA "
        Catch ex As Exception
            MsgBox("Error al Insertar Cabecera del Archivo" & vbCrLf & ex.Message.ToString)
        End Try

        With h_hoja            
            .Range("A5:P5").Select()
            .Range(archivo_excel.Selection, archivo_excel.Selection.End(Microsoft.Office.Interop.Excel.XlDirection.xlDown)).Select()
            archivo_excel.Application.CutCopyMode = False
            archivo_excel.Sheets.Add()
            archivo_excel.ActiveWorkbook.PivotCaches.Create(SourceType:=Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlDatabase, SourceData:= _
                "Sheet1!A4:U50", Version:=Microsoft.Office.Interop.Excel.XlPivotTableVersionList.xlPivotTableVersion10).CreatePivotTable( _
                TableDestination:="Hoja1!R3C1", TableName:="TablaDinámica1", _
                DefaultVersion:=Microsoft.Office.Interop.Excel.XlPivotTableVersionList.xlPivotTableVersion10)
            archivo_excel.Sheets("Hoja1").Select()
            archivo_excel.Sheets("Hoja1").Range("A3").Select() 'Cells(3, 1).Select()
            archivo_excel.Sheets("Hoja1").name = "TD"
            archivo_excel.Sheets("Sheet1").name = "DATA"
            'With archivo_excel.ActiveWorkbook.ActiveSheet.PivotTables("TablaDinámica1")
            '    .ColumnGrand = True
            '    .HasAutoFormat = True
            '    .DisplayErrorString = False
            '    .DisplayNullString = True
            '    .EnableDrilldown = True
            '    .ErrorString = ""
            '    .MergeLabels = False
            '    .NullString = ""
            '    .PageFieldOrder = 2
            '    .PageFieldWrapCount = 0
            '    .PreserveFormatting = True
            '    .RowGrand = True
            '    .SaveData = True
            '    .PrintTitles = False
            '    .RepeatItemsOnEachPrintedPage = True
            '    .TotalsAnnotation = False
            '    .CompactRowIndent = 1
            '    .InGridDropZones = True
            '    .DisplayFieldCaptions = True
            '    .DisplayContextTooltips = True
            '    .ShowDrillIndicators = True
            '    .PrintDrillIndicators = False
            '    .SortUsingCustomLists = True
            '    .FieldListSortAscending = False
            '    .ShowValuesRow = True
            'End With
        End With
        With archivo_excel.ActiveWorkbook.ActiveSheet.PivotTables("TablaDinámica1")

            With .PivotFields("ALMACEN")
                .Orientation = Excel.XlPivotFieldOrientation.xlPageField
                .Position = 1
                .Name = "ALMACEN"
            End With

            With .PivotFields("POLITICA")
                .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                .Position = 1
                .Name = "ROTACION"
            End With

            With .PivotFields("RUMA")
                .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                .Position = 2
                .Name = "RUMA"
            End With

            .AddDataField(.PivotFields("PESO%"), "Suma de PESO % SALIDAS", Excel.XlConsolidationFunction.xlSum)
            .PivotFields("Suma de PESO % SALIDAS").NumberFormat = "#,##0.00"

            .AddDataField(.PivotFields("CONSUMO PROM."), "Suma de CONSUMO PROM. MENSUAL MAX. HISTORICO (TON)", Excel.XlConsolidationFunction.xlSum)
            .PivotFields("Suma de CONSUMO PROM. MENSUAL MAX. HISTORICO (TON)").NumberFormat = "#,##0.00"

            .AddDataField(.PivotFields("SALDO TON"), "Suma de SOTCK FINAL (TON)", Excel.XlConsolidationFunction.xlSum)
            .PivotFields("Suma de SOTCK FINAL (TON)").NumberFormat = "#,##0.00"

            .AddDataField(.PivotFields("STOCK_SUGERIDO"), "Suma de STOCK SUGERIDO MIN. (TON)", Excel.XlConsolidationFunction.xlSum)
            .PivotFields("Suma de STOCK SUGERIDO MIN. (TON)").NumberFormat = "#,##0.00"

            .AddDataField(.PivotFields("INGRESO_PROMEDIO"), "Suma de INGRESO PROMEDIO (TON)", Excel.XlConsolidationFunction.xlSum)
            .PivotFields("Suma de INGRESO PROMEDIO (TON)").NumberFormat = "#,##0.00"

            .AddDataField(.PivotFields("SALIDA_PROMEDIO"), "Suma de SALIDA PROMEDIO (TON)", Excel.XlConsolidationFunction.xlSum)
            .PivotFields("Suma de SALIDA PROMEDIO (TON)").NumberFormat = "#,##0.00"

            With .DataPivotField
                .Orientation = Excel.XlPivotFieldOrientation.xlColumnField
                .Position = 1
            End With

            archivo_excel.Sheets("TD").Range("A1:AZ3").Insert()
            archivo_excel.Sheets("TD").Range("A7").RowHeight = 50
            archivo_excel.Sheets("TD").Range("C1:H1").ColumnWidth = 14
            archivo_excel.Sheets("TD").Range("C7:H7").WrapText = True
            archivo_excel.Sheets("TD").Range("A1").Value = "RESUMEN DEL STOCK DE MINERALES AL " & CDate(dtFechaFin.Value).ToString("dd/MM/yyyy")
            archivo_excel.Sheets("TD").Range("A1").font.bold = True
        End With
        'h_hoja.Range("B:F").NumberFormat = "#,##0.00"
        archivo_excel.Sheets("TD").Columns("C:C").Select()
        archivo_excel.Selection.NumberFormat = "0.00%"

        archivo_excel.Sheets("TD").Columns("D:H").Select()
        archivo_excel.Selection.NumberFormat = "#,#0.00"

        archivo_excel.Visible = True
        'libro_excel.Save()
        'libro_excel.Close()
        libro_excel = Nothing

        'archivo_excel.Quit()
        'archivo_excel = Nothing

    End Sub

    Private Sub Abrir_Archivo(ByVal ruta As String)

        Dim xApp As Object
        Dim xLibros As Object
        Dim xLibro As Object
        Dim archivoexcel As String = Trim(ruta)

        'Abrimos el archivo
        xApp = CreateObject("excel.application")
        xLibros = xApp.Workbooks

        '' ''poner cabecera antes de abrir
        ''If b_imprimir_cabecera = True Then Call poner_cabecera_archivo_excel(archivoexcel)

        xLibros.Open(archivoexcel, 3)
        xLibro = xApp.ActiveWorkBook
        xApp.Visible = True

    End Sub

    Private Sub lblhist_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblhist.MouseMove
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub lblhist_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblhist.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        Try
            If gridReporte.ActiveRow.Index < 0 Then MsgBox("Debe seleccionar ruma", MsgBoxStyle.Exclamation, "Validación") : Exit Sub
            If txtobservacion.Text.ToString.Trim = "" Then MsgBox("Debe ingresar comentario", MsgBoxStyle.Exclamation, "Validación") : Exit Sub
            If MsgBox("Desea registrar observación?", MsgBoxStyle.YesNo, "Sistemas") = MsgBoxResult.No Then Exit Sub
            Dim dtComentario As New DataTable
            _objNegocio_ = New NGProducto
            _objEntidad_ = New ETProducto
            Dim codruma As String = gridReporte.ActiveRow.Cells("COD_RUMA").Value.ToString.Substring(0, 8)
            dtComentario = _objNegocio_.MantComentarioControl(codruma, txtobservacion.Text, User_Sistema)
            MsgBox("Registrado correctamente", MsgBoxStyle.Exclamation, "Sistemas")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblhist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblhist.Click
        VerHistorial()
    End Sub
    Sub VerHistorial()
        Try
            If gridReporte.ActiveRow.Index < 0 Then Exit Sub
            Dim dtComentario As New DataTable
            _objNegocio_ = New NGProducto
            _objEntidad_ = New ETProducto
            Dim codruma As String = gridReporte.ActiveRow.Cells("COD_RUMA").Value.ToString.Substring(0, 8)
            dtComentario = _objNegocio_.ListaComentarioControl(codruma, "H")
            If dtComentario.Rows.Count > 0 Then
                gpbHistorial.Visible = True
                gpbHistorial.Text = "Historial de comentarios ruma: " & gridReporte.ActiveRow.Cells("COD_RUMA").Value
                gridHistorial.DataSource = dtComentario
                gridReporte.Enabled = False
            Else
                gpbHistorial.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UltraLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraLabel1.Click
        gpbHistorial.Visible = False
        gridReporte.Enabled = True
    End Sub

    Sub DetalleCantera(ByVal cadenaAlmacen As String, ByVal cadenaruma As String, ByVal cadenaTipomov As String)
        Dim i As Int32
        Try
            Dim dtCantera As New DataTable
            dtCantera.Columns.Add("CANTERA")
            dtCantera.Columns.Add("RUMA")
            dtCantera.Columns.Add("MINERAL")
            dtCantera.Columns.Add("MOVIMIENTO")
            dtCantera.Columns.Add("TON").DataType = System.Type.GetType("System.Decimal")
            dtCantera.Columns.Add("SOLES").DataType = System.Type.GetType("System.Decimal")
            dtCantera.Columns.Add("SOLESXTON").DataType = System.Type.GetType("System.Decimal")
            dtCantera.Columns.Add("ORIGEN")
            dtCantera.Columns.Add("CONTRATISTA")

            Dim dtFiltro As New DataTable
            dtFiltro = dtListaCantera.Clone
            Dim rows As DataRow()
            If cadenaruma.Length > 0 Then
                'rows = dtListaCantera.Select("COD_ALM IN(" & cadenaAlmacen & ") AND COD_RUMA IN(" & cadenaruma & ") AND flgtransferencia IN(" & cadenaTipomov & ")")
                rows = dtListaCantera.Select("CODRUMA IN(" & cadenaruma & ") AND FLGTRANSFERENCIA IN(" & cadenaTipomov & ")")
                For Each dr As DataRow In rows
                    dtFiltro.ImportRow(dr)
                Next
            Else
                dtFiltro = dtListaCantera.Copy
            End If
            Dim row As DataRow
            For i = 0 To dtFiltro.Rows.Count - 1
                row = dtCantera.NewRow
                Dim codcantera As String = dtFiltro.Rows(i)("CODCANTERA").ToString.Trim
                Dim codruma As String = dtFiltro.Rows(i)("CODRUMA").ToString.Trim
                Dim codmineral As String = dtFiltro.Rows(i)("CODMINERAL").ToString.Trim
                Dim flgtransferencia As String = dtFiltro.Rows(i)("FLGTRANSFERENCIA").ToString.Trim
                row(0) = codcantera + " - " + dtFiltro.Rows(i)("CANTERA")
                row(1) = codruma + " - " + dtFiltro.Rows(i)("RUMA")
                row(2) = dtFiltro.Rows(i)("CODMINERAL").ToString.Trim + " - " + dtFiltro.Rows(i)("MINERAL")
                row(3) = dtFiltro.Rows(i)("MOVIMIENTO").ToString.Trim
                Dim ton As Double = CalculaTonMesCantera(dtData, row(3), codcantera, codruma, codmineral, flgtransferencia)
                Dim soles As Double = CalculaSolesMesCantera(dtData, row(3), codcantera, codruma, codmineral, flgtransferencia)
                row(4) = ton * CDbl(IIf(row(3) = "INGRESO", 1, -1)).ToString("#,##0.00")
                row(5) = soles * CDbl(IIf(row(3) = "INGRESO", 1, -1)).ToString("#,##0.00")
                row(6) = CDbl(IIf(ton = 0 Or soles = 0, 0, soles / ton)).ToString("#,##0.00")
                row(7) = IIf(dtFiltro.Rows(i)("FLGTRANSFERENCIA").ToString.Trim = 0, "CANTERA", "TRANSFERENCIA")
                row(8) = dtFiltro.Rows(i)("CONTRATISTA")
                dtCantera.Rows.Add(row)
            Next
            girdCanteraDet.DataSource = dtCantera
            girdCanteraDet1.DataSource = dtCantera
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Function CalculaTonMesCantera(ByVal dt As DataTable, ByVal tipo As String, ByVal cantera As String, ByVal ruma As String, ByVal codmineral As String, ByVal flgtransferencia As Int32) As Double
        Dim Ton As Double = 0
        Dim dtMes As New DataTable
        dtMes = dt.Clone
        Dim rows As DataRow()
        rows = dt.Select("TipoMovimiento='" & tipo & "' and codCantera='" & cantera & "' and cod_Ruma='" & ruma & "' and CodMineral='" & codmineral & "' and flgtransferencia=" & flgtransferencia)
        For Each dr As DataRow In rows
            dtMes.ImportRow(dr)
        Next
        For i As Int32 = 0 To dtMes.Rows.Count - 1
            Ton = Ton + dtMes.Rows(i)("Ton")
        Next
        Return Ton
    End Function

    Function CalculaSolesMesCantera(ByVal dt As DataTable, ByVal tipo As String, ByVal cantera As String, ByVal ruma As String, ByVal codmineral As String, ByVal flgtransferencia As Int32) As Double
        Dim Ton As Double = 0
        Dim dtMes As New DataTable
        dtMes = dt.Clone
        Dim rows As DataRow()
        rows = dt.Select("TipoMovimiento='" & tipo & "' and codCantera='" & cantera & "' and cod_Ruma='" & ruma & "' and CodMineral='" & codmineral & "' and flgtransferencia=" & flgtransferencia)
        For Each dr As DataRow In rows
            dtMes.ImportRow(dr)
        Next
        For i As Int32 = 0 To dtMes.Rows.Count - 1
            Ton = Ton + dtMes.Rows(i)("valorizado")
        Next
        Return Ton
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim cadenaRuma As String = ""
            gridRuma.PerformAction(ExitEditMode)
            cadenaRuma = ""

            For i As Int32 = 0 To gridRuma.Rows.Count - 1
                If gridRuma.Rows(i).Cells("sel").Value = True Then
                    cadenaRuma = cadenaRuma + "'" + gridRuma.Rows(i).Cells("COD_RUMA").Value.ToString.Substring(0, 8) + "',"
                End If
            Next
            'If cadenaRuma.Length <= 0 Then Exit Sub
            Dim cadenaAlmacen As String = ""
            For i As Int32 = 0 To gridAlmacen.Rows.Count - 1
                If gridAlmacen.Rows(i).Cells("sel").Value = True Then
                    cadenaAlmacen = cadenaAlmacen + "'" + gridAlmacen.Rows(i).Cells("COD_ALMACEN").Value + "',"
                End If
            Next
            Dim cadenaTipomov As String = ""
            For i As Int32 = 0 To gridTipo.Rows.Count - 1
                If gridTipo.Rows(i).Cells("sel").Value = True Then
                    cadenaTipomov = cadenaTipomov + "'" + gridTipo.Rows(i).Cells("ID_TIPO").Value + "',"
                End If
            Next

            DetalleCantera(cadenaAlmacen, cadenaRuma, cadenaTipomov)

            'Tab1.Tabs("T03").Selected = True
            'girdCanteraDet.Rows.FilterRow.Cells("RUMA").Value = "11"
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged
        If Tab1.Tabs("T03").Selected = True Then
            Button1_Click(Nothing, Nothing)
        End If
    End Sub


    Private Sub gridMineral_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridMineral.ClickCell
        Try
            If gridMineral.ActiveRow.Index < 0 Then Exit Sub
            gridMineral.PerformAction(ExitEditMode)
            chkruma.Checked = False
            chkruma_CheckedChanged(Nothing, Nothing)
            Dim codRuma As String = ""
            For i As Int32 = 0 To gridMineral.Rows.Count - 1
                If gridMineral.Rows(i).Cells("sel").Value = True Then
                    If codRuma.Length > 0 Then MsgBox("No puede seleccionar más de un Mineral", MsgBoxStyle.Information, "Validación") : gridMineral.ActiveRow.Cells("sel").Value = False : Exit Sub
                    codRuma = gridMineral.Rows(i).Cells("COD_RUMA").Value
                    chkMineral.Checked = True                    
                End If
            Next
            For i As Int32 = 0 To gridRuma.Rows.Count - 1
                gridRuma.Rows(i).Cells("sel").Value = False
                If gridRuma.Rows(i).Cells("COD_RUMA").Value.ToString.Substring(0, 8) = codRuma Then
                    gridRuma.Rows(i).Cells("sel").Value = True
                    gridRuma_ClickCell(Nothing, Nothing)
                End If
            Next
            'End If
            'Button1_Click(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkMineral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMineral.CheckedChanged
        Try
            If chkMineral.Checked = True Then Exit Sub
            For i As Int32 = 0 To gridMineral.Rows.Count - 1
                gridMineral.Rows(i).Cells("sel").Value = chkMineral.Checked
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridMineral_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridMineral.InitializeLayout

    End Sub
End Class