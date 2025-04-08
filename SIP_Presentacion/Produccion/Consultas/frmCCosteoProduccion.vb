Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Common


'ALINEACION IZQUIERDA:Alineacion.Izquierda
Public Class frmCCosteoProduccion
    Private Enum Alineacion
        Izquierda = -4131
        Derecha = -4152
        Centrado = -4108
    End Enum
    Dim Obj_Excel As Object
    Dim Obj_Libro As Object
    Dim Obj_Hoja As Object
    Dim Fila As Integer = 0
    Dim CodEnlace As Integer = 0
    Dim TotalProduccion As Double = 0
    Dim TotalPlanta As Double = 0
    Dim CostoTotal As Double = 0
    Dim CostoTotalAcum As Double = 0
    Dim UnidadProd As String = String.Empty
    Public Ls_Permisos As New List(Of Integer)
    Dim DsProduccion As DataSet
    Dim FechaInicio As DateTime
    Dim FechaTermino As DateTime
    Dim Resumen_Ruma As Double = 0
    Dim Resumen_SiliceHomogenizada As Double = 0
    Dim Resumen_Chancadora As Double = 0
    Dim Resumen_Cargador_Frontal As Double = 0
    Dim Resumen_ManoObra As Double = 0
    Dim Resumen_ManttoMecanico As Double = 0
    Dim Resumen_Depreciacion As Double = 0
    Dim Resumen_Energia As Double = 0
    Dim Resumen_GasNatural As Double = 0
    Dim Resumen_Envases As Double = 0
    Dim Resumen_ManttoReparacioMP As Double = 0
    Dim Resumen_SobrecostoEmpleado As Double = 0
    Dim Resumen_SobrecostoObrero As Double = 0

    Dim Resumen_Ruma_Acum As Double = 0
    Dim Resumen_SiliceHomogenizada_Acum As Double = 0
    Dim Resumen_Chancadora_Acum As Double = 0
    Dim Resumen_Cargador_Frontal_Acum As Double = 0
    Dim Resumen_ManoObra_Acum As Double = 0
    Dim Resumen_ManttoMecanico_Acum As Double = 0
    Dim Resumen_Depreciacion_Acum As Double = 0
    Dim Resumen_Energia_Acum As Double = 0
    Dim Resumen_GasNatural_Acum As Double = 0
    Dim Resumen_Envases_Acum As Double = 0
    Dim Resumen_ManttoReparacioMP_Acum As Double = 0
    Dim Resumen_SobrecostoEmpleado_Acum As Double = 0
    Dim Resumen_SobrecostoObrero_Acum As Double = 0
    Dim Resumen_ProduccionProducto_Acum As Double = 0
    Dim Resumen_ProduccionProducto As Double = 0

    Dim PrecioMaximo As Double = 0
    Dim PrecioMinimo As Double = 0
    Dim PrecioPromedio As Double = 0
    Dim Utilidad As Double = 0
    Dim Spid As Integer
    Dim FechaInicioAño As Date
    Dim EntSilice As List(Of ETPeriodo) = Nothing
    Dim Ls_CosteoMolino As List(Of ETOrden) = Nothing
    Dim Ls_CosteoProducto As List(Of ETOrden) = Nothing
    Dim TotalManoObra As Double = 0

    Private Sub frmCCosteoProduccion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmCCosteoProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ConfigurarFormulario()
        Spid = Negocio.CosteoProduccion.Consultar_Spid()

    End Sub

    Private Sub ConfigurarFormulario()
        Clb1.Value = Now.ToShortDateString
        Select Case Trim(Me.Tag)
            Case "84"
                Grb1.Text = "COSTEO DE PRODUCCIÓN"
                UltraLabel3.Visible = True
                Clb1.Visible = True
                lblEstado.Text = ""
                lblCosteo.Text = ""
                lblDetalle.Text = ""
                Chk1.Visible = True
            Case "97"
                Grb1.Text = "REPORTE DE MINERALES EN PRODUCTOS TERMINADOS"
                UltraLabel3.Visible = False
                Clb1.Visible = False
                Chk1.Visible = False

            Case "107"
                Grb1.Text = "TRAZABILIDAD DE PROFORMAS"
                UltraLabel3.Visible = False
                Txt2.Visible = False
                Clb1.Visible = False
                Chk1.Visible = False
                Grb2.Visible = False
                Grb3.Visible = False
                Grb4.Visible = False
                UltraLabel1.Text = "Proforma:"
                Txt1.ReadOnly = False
        End Select
    End Sub
    Public Sub Nuevo()
        Txt1.Clear()
        Txt2.Clear()
        Txt3.Clear()
        Txt4.Clear()
        Txt5.Value = 0
        Rbt3.Checked = True

    End Sub
    Public Sub Buscar()
        Dim frmHijo As New frmBuscar
        If String.IsNullOrEmpty(Txt1.Text.Trim) Then
            frmHijo.Formulario = frmBuscar.eState.frm_Producto_Terminado
            frmHijo.ShowDialog()
            Txt1.Text = frmHijo.Flag2
            Txt2.Text = frmHijo.Descripcion
        ElseIf Rbt5.Checked = True Then
            frmHijo.Formulario = frmBuscar.eState.frm_Catalogo_molino
            frmHijo.ShowDialog()
            Txt3.Text = frmHijo.Flag2
            Txt4.Text = frmHijo.Descripcion
        Else
            frmHijo.Formulario = frmBuscar.eState.frm_Producto_Terminado
            frmHijo.ShowDialog()
            Txt1.Text = frmHijo.Flag2
            Txt2.Text = frmHijo.Descripcion
        End If
      
        frmHijo = Nothing
    End Sub
    Public Sub Reporte()

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Select Case Trim(Me.Tag)
            Case "97"
                Call Reporte_ProductoMinerales()
            Case "107"
                Call Reporte_TrazabilidadProforma()
        End Select

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Private Sub Reporte_TrazabilidadProforma()
        Dim ds As DataSet
        Negocio.ReportesBL = New NGReportes
        ds = Negocio.ReportesBL.ValidarProforma(Companhia, Txt1.Text.Trim)

        If ds Is Nothing Then
            MsgBox("Error Inesperado, Consulte con el Administrador del Sistema", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        ElseIf ds.Tables(0).Rows.Count <= 0 Then
            MsgBox("La Proforma no Existe", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        ElseIf ds.Tables(0).Rows(0).Item("Status").ToString.TrimEnd.TrimStart = "*" Then
            MsgBox("La Proforma esta Anulada", MsgBoxStyle.Exclamation, msgComacsa)
            Exit Sub
        End If


        StrucForm.FxRxReporte = New FrmBReporte
        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .Cod_Cia = Companhia
            .NroDocumento = Txt1.Text.Trim
        End With

        StrucForm.FxRxReporte.NumReporte = VarReporte.TrazabilidadProforma
        StrucForm.FxRxReporte.TextReporte = "REPORTE DE TRAZABILIDAD DE PROFORMAS"
        StrucForm.FxRxReporte.DatosReporte = Entidad.Orden
        StrucForm.FxRxReporte.MdiParent = MdiParent
        StrucForm.FxRxReporte.Show()

    End Sub


    Private Sub InicilizarValores()
        TotalPlanta = 0
        CostoTotal = 0
        CostoTotalAcum = 0
        Resumen_Ruma = 0
        Resumen_SiliceHomogenizada = 0
        Resumen_Chancadora = 0
        Resumen_Cargador_Frontal = 0
        Resumen_ManoObra = 0
        Resumen_ManttoMecanico = 0
        Resumen_Depreciacion = 0
        Resumen_Energia = 0
        Resumen_GasNatural = 0
        Resumen_Envases = 0
        Resumen_ManttoReparacioMP = 0
        Resumen_SobrecostoEmpleado = 0
        Resumen_SobrecostoObrero = 0

        Resumen_Ruma_Acum = 0
        Resumen_SiliceHomogenizada_Acum = 0
        Resumen_Chancadora_Acum = 0
        Resumen_Cargador_Frontal_Acum = 0
        Resumen_ManoObra_Acum = 0
        Resumen_ManttoMecanico_Acum = 0
        Resumen_Depreciacion_Acum = 0
        Resumen_Energia_Acum = 0
        Resumen_GasNatural_Acum = 0
        Resumen_Envases_Acum = 0
        Resumen_ManttoReparacioMP_Acum = 0
        Resumen_SobrecostoEmpleado_Acum = 0
        Resumen_SobrecostoObrero_Acum = 0

        Resumen_ProduccionProducto = 0
        PrecioMaximo = 0
        PrecioMinimo = 0
        PrecioPromedio = 0
        EntSilice = Nothing
        Ls_CosteoMolino = New List(Of ETOrden)
        Ls_CosteoProducto = New List(Of ETOrden)
    End Sub

    Public Sub Excel_X()
        If Not (Trim(Me.Tag) = "84") Then Exit Sub

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Me.Cursor = Cursors.WaitCursor

        If String.IsNullOrEmpty(Txt1.Text.Trim) Then
            MsgBox("Seleccione el Producto a Analizar", MsgBoxStyle.Critical, msgComacsa)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        FechaInicio = "01/" & Month(Clb1.Value) & "/" & Year(Clb1.Value) & " 12:00:00 am"
        FechaInicioAño = "01/01/" & Year(Clb1.Value) & " 12:00:00 am"
        FechaTermino = DateAdd(DateInterval.Month, 1, FechaInicio)
        FechaTermino = DateAdd(DateInterval.Second, -1, FechaTermino)
        lblEstado.Text = ""
        lblCosteo.Text = ""
        lblDetalle.Text = ""
        Grb3.Visible = True
        lblEstado.Text = "Validando Ingresos del Costeo"
        Application.DoEvents()

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .Cod_Cia = Companhia
            .FechaInicio = FechaInicio
            .FechaTerminacion = FechaTermino
            .CodProducto = Txt1.Text.Trim
            .Cod_Alm = "19"
            .Respuesta = 0
            
        End With

        If Negocio.CosteoProduccion.Validar_Costeo_ProductosTerminados(Entidad.Orden) = False Then
            'Me.Cursor = Cursors.Default
            'Exit Sub
        End If


        Obj_Excel = CreateObject("Excel.Application")
        Obj_Libro = Obj_Excel.Workbooks.Add()
        Call InicilizarValores()

        lblEstado.Text = "Obteniendo Precios de Venta"
        Application.DoEvents()

        Dim dsPrecioVenta As DataSet
        dsPrecioVenta = Negocio.CosteoProduccion.Consultar_Produccion_PrecioVenta(Entidad.Orden)

        If dsPrecioVenta IsNot Nothing Then
            For i = 0 To dsPrecioVenta.Tables(0).Rows.Count - 1
                PrecioMaximo = Val(dsPrecioVenta.Tables(0).Rows(i).Item("Maximo").ToString.Trim)
                PrecioMinimo = Val(dsPrecioVenta.Tables(0).Rows(i).Item("Minimo").ToString.Trim)
                PrecioPromedio = (PrecioMaximo + PrecioMinimo) / 2
            Next
        End If

        lblEstado.Text = "Obteniendo Datos del Costeo del Producto"
        Application.DoEvents()
        Call CargarCosteoProduccion()
        Call PintarMolino()
        lblEstado.Text = "Exportando Resumen del Costeo del Producto"
        lblCosteo.Text = ""
        lblDetalle.Text = ""
        Call CrearResumen()
        lblEstado.Text = "Exportación Finalizada"
        lblCosteo.Text = ""
        lblDetalle.Text = ""

        Obj_Hoja = Obj_Libro.Sheets(1)
        Obj_Hoja.Activate()

        Obj_Excel.visible = True

        Obj_Hoja = Nothing
        Obj_Libro = Nothing
        Obj_Excel = Nothing

        Me.Cursor = Cursors.Default

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Public Sub Excel()
        Try

            If Not (Trim(Me.Tag) = "84") Then Exit Sub

            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            Me.Cursor = Cursors.WaitCursor
            Txt5.EndUpdate()
            Txt3.EndUpdate()
            If String.IsNullOrEmpty(Txt1.Text.Trim) Then
                MsgBox("Seleccione el Producto a Analizar", MsgBoxStyle.Critical, msgComacsa)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If Rbt5.Checked = True Then
                If String.IsNullOrEmpty(Txt3.Text.Trim) Then
                    MsgBox("Seleccione un Molino", MsgBoxStyle.Critical, msgComacsa)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                If Val(Txt5.Value) <= 0 Then
                    MsgBox("Ingrese una Cantidad Proyectada mayor a Cero", MsgBoxStyle.Critical, msgComacsa)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

            End If

            FechaInicio = "01/" & Month(Clb1.Value) & "/" & Year(Clb1.Value) & " 12:00:00 am"
            FechaInicioAño = "01/01/" & Year(Clb1.Value) & " 12:00:00 am"
            FechaTermino = DateAdd(DateInterval.Month, 1, FechaInicio)
            FechaTermino = DateAdd(DateInterval.Second, -1, FechaTermino)
            lblEstado.Text = ""
            lblCosteo.Text = ""
            lblDetalle.Text = ""
            Grb3.Visible = True
            lblEstado.Text = "Validando Ingresos del Costeo"
            Application.DoEvents()

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .Cod_Cia = Companhia
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .CodProducto = Txt1.Text.Trim
                .Cod_Alm = "19"
                .Respuesta = 0
                .Mes = Month(Clb1.Value)
                .Anho = Year(Clb1.Value)
                If Rbt5.Checked = True Then
                    .Proyeccion = True
                End If
            End With

            If Negocio.CosteoProduccion.Validar_Costeo_ProductosTerminados_Cierre(Entidad.Orden) = False Then
                lblEstado.Text = "Faltan Costos para Generar el Costeo del Producto"
                'Me.Cursor = Cursors.Default
                'Exit Sub
            End If


            Obj_Excel = CreateObject("Excel.Application")
            Obj_Libro = Obj_Excel.Workbooks.Add()
            Call InicilizarValores()

            lblEstado.Text = "Obteniendo Precios de Venta"
            Application.DoEvents()

            Dim dsPrecioVenta As DataSet
            dsPrecioVenta = Negocio.CosteoProduccion.Consultar_Produccion_PrecioVenta(Entidad.Orden)

            If dsPrecioVenta IsNot Nothing Then
                For i = 0 To dsPrecioVenta.Tables(0).Rows.Count - 1
                    PrecioMaximo = Val(dsPrecioVenta.Tables(0).Rows(i).Item("Maximo").ToString.Trim)
                    PrecioMinimo = Val(dsPrecioVenta.Tables(0).Rows(i).Item("Minimo").ToString.Trim)
                    PrecioPromedio = (PrecioMaximo + PrecioMinimo) / 2
                Next
            End If

            lblEstado.Text = "Obteniendo Datos del Costeo del Producto"
            Application.DoEvents()
            Call CargarCosteoProduccion_Cierre()
            Call PintarMolino_Cierre()
            lblEstado.Text = "Exportando Resumen del Costeo del Producto"
            lblCosteo.Text = ""
            lblDetalle.Text = ""
            Call CrearResumen_Cierre()
            lblEstado.Text = "Exportación Finalizada"
            lblCosteo.Text = ""
            lblDetalle.Text = ""

            Obj_Hoja = Obj_Libro.Sheets(1)
            Obj_Hoja.Activate()

            Obj_Excel.visible = True

            Obj_Hoja = Nothing
            Obj_Libro = Nothing
            Obj_Excel = Nothing

            Me.Cursor = Cursors.Default

            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Excel_Antes()

        If Not (Trim(Me.Tag) = "84") Then Exit Sub

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Me.Cursor = Cursors.WaitCursor
        Txt5.EndUpdate()
        Txt3.EndUpdate()
        If String.IsNullOrEmpty(Txt1.Text.Trim) Then
            MsgBox("Seleccione el Producto a Analizar", MsgBoxStyle.Critical, msgComacsa)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If Rbt5.Checked = True Then
            If String.IsNullOrEmpty(Txt3.Text.Trim) Then
                MsgBox("Seleccione un Molino", MsgBoxStyle.Critical, msgComacsa)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If Val(Txt5.Value) <= 0 Then
                MsgBox("Ingrese una Cantidad Proyectada mayor a Cero", MsgBoxStyle.Critical, msgComacsa)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

        End If

        FechaInicio = "01/" & Month(Clb1.Value) & "/" & Year(Clb1.Value) & " 12:00:00 am"
        FechaInicioAño = "01/01/" & Year(Clb1.Value) & " 12:00:00 am"
        FechaTermino = DateAdd(DateInterval.Month, 1, FechaInicio)
        FechaTermino = DateAdd(DateInterval.Second, -1, FechaTermino)
        lblEstado.Text = ""
        lblCosteo.Text = ""
        lblDetalle.Text = ""
        Grb3.Visible = True
        lblEstado.Text = "Validando Ingresos del Costeo"
        Application.DoEvents()

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .Cod_Cia = Companhia
            .FechaInicio = FechaInicio
            .FechaTerminacion = FechaTermino
            .CodProducto = Txt1.Text.Trim
            .Cod_Alm = "19"
            .Respuesta = 0
            If Rbt5.Checked = True Then
                .Proyeccion = True
            End If
        End With

        If Negocio.CosteoProduccion.Validar_Costeo_ProductosTerminados_Cierre(Entidad.Orden) = False Then
            lblEstado.Text = "Faltan Costos para Generar el Costeo del Producto"
            'Me.Cursor = Cursors.Default
            'Exit Sub
        End If


        Obj_Excel = CreateObject("Excel.Application")
        Obj_Libro = Obj_Excel.Workbooks.Add()
        Call InicilizarValores()

        lblEstado.Text = "Obteniendo Precios de Venta"
        Application.DoEvents()

        Dim dsPrecioVenta As DataSet
        dsPrecioVenta = Negocio.CosteoProduccion.Consultar_Produccion_PrecioVenta(Entidad.Orden)

        If dsPrecioVenta IsNot Nothing Then
            For i = 0 To dsPrecioVenta.Tables(0).Rows.Count - 1
                PrecioMaximo = Val(dsPrecioVenta.Tables(0).Rows(i).Item("Maximo").ToString.Trim)
                PrecioMinimo = Val(dsPrecioVenta.Tables(0).Rows(i).Item("Minimo").ToString.Trim)
                PrecioPromedio = (PrecioMaximo + PrecioMinimo) / 2
            Next
        End If

        lblEstado.Text = "Obteniendo Datos del Costeo del Producto"
        Application.DoEvents()
        Call CargarCosteoProduccion_Cierre()
        Call PintarMolino_Cierre()
        lblEstado.Text = "Exportando Resumen del Costeo del Producto"
        lblCosteo.Text = ""
        lblDetalle.Text = ""
        Call CrearResumen_Cierre()
        lblEstado.Text = "Exportación Finalizada"
        lblCosteo.Text = ""
        lblDetalle.Text = ""

        Obj_Hoja = Obj_Libro.Sheets(1)
        Obj_Hoja.Activate()

        Obj_Excel.visible = True

        Obj_Hoja = Nothing
        Obj_Libro = Nothing
        Obj_Excel = Nothing

        Me.Cursor = Cursors.Default

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Private Sub PintarMolino_Cierre()
        Dim i As Integer = 0
        Dim r As Integer = 0
        Dim cr As Integer = 0
        Dim sh As Integer = 0
        Dim c As Integer = 0
        Dim p As Integer = 0
        Dim mo As Integer = 0
        Dim Ruma As String = String.Empty
        Dim TipoEnlace As String = String.Empty
        Dim FilaRuma As Integer = 0
        Dim TotalRuma As Double = 0
        Dim CostoChandadora As Double = 0
        Dim CostoChandadora_MM As Double = 0
        Dim CostoChandadora_Energia As Double = 0
        Dim CostoChandadora_Deprec As Double = 0
        Dim CostoChandadora_TI As Double = 0
        Dim CostoChandadora_MO As Double = 0
        Dim CostoChandadora_Cantidad As Double = 0
        Dim Chancadora As String = String.Empty
        Dim Chancadora_Descrip As String = String.Empty
        Dim Chancadora_Produccion As Double = 0

        Dim Chancadora_Cantidad As Double = 0
        Dim Chancadora_Silice As Double = 0
        Dim Chancadora_SubTotal As Double = 0

        Dim Chanc_E_EnergiaTotal As Double = 0
        Dim Chanc_E_CostoKWH As Double = 0
        Dim Chanc_E_Referencia As String = String.Empty
        Dim Chanc_E_CostoEnergia As Double = 0
        Dim Chanc_MO As Double = 0
        Dim Chanc_MO_Pers As Double = 0
        'Dim TI_Cantidad As Double = 0
        'Dim TI_Silice As Double = 0
        'Dim TI_Normal As Double = 0
        'Dim TI_SubTotal As Double = 0
        Dim CantidadAcum As Double = 0
        Dim SubTotalAcum As Double = 0
        Dim CostoTotalAcum As Double = 0
        Dim TotalProdMolino As Double = 0

        Dim TotalCostoRuma As Double = 0
        Dim TotalCostoSiliceHomog As Double = 0
        Dim TotalCostoChancadora As Double = 0
        Dim TotalCostoPala As Double = 0
        Dim TotalCostoManttoMecanico As Double = 0
        Dim TotalCostoDepreciacion As Double = 0
        Dim TotalCostoEnergia As Double = 0
        Dim TotalCostoGasNatural As Double = 0
        Dim TotalCostoEnvases As Double = 0
        Dim TotalCostoMantenimientoMaqPesada As Double = 0
        Dim TotalCostoSobrecostosObreros As Double = 0
        Dim TotalCostoSobrecostosEmpleados As Double = 0

        Dim TotalCostoRumaAcum As Double = 0
        Dim TotalCostoSiliceHomogAcum As Double = 0
        Dim TotalCostoChancadoraAcum As Double = 0
        Dim TotalCostoPalaAcum As Double = 0
        Dim TotalManoObraAcum As Double = 0
        Dim TotalCostoManttoMecanicoAcum As Double = 0
        Dim TotalCostoDepreciacionAcum As Double = 0
        Dim TotalCostoEnergiaAcum As Double = 0
        Dim TotalCostoGasNaturalAcum As Double = 0
        Dim TotalCostoEnvasesAcum As Double = 0

        Dim TotalCostoMantenimientoMaqPesadaAcum As Double = 0
        Dim TotalCostoSobrecostosObrerosAcum As Double = 0
        Dim TotalCostoSobrecostosEmpleadosAcum As Double = 0


        Dim CostoxMolino As Double = 0
        Dim CostoxMolinoAcum As Double = 0

        Dim CantidadRuma As Double = 0
        Dim CostoUnitarioRuma As Double = 0
        Dim PintarCabecera As Boolean = False
        Dim SaltarReturn As Boolean = False
        Dim TONSiliceHomog As Double = 0

        Dim CodTipoCostoCble As String = String.Empty
        Dim TipoCostoCble As String = String.Empty
        Dim DesCostoCble As String = String.Empty
        Dim CostoTipoCostoCble As Decimal = Decimal.Zero
        Dim lDureza As Decimal = 0


        For i = 0 To DsProduccion.Tables(0).Rows.Count - 1
            TotalManoObra = 0
            TotalCostoRumaAcum = 0
            TotalCostoSiliceHomogAcum = 0
            TotalCostoChancadoraAcum = 0
            TotalCostoPalaAcum = 0
            TotalCostoDepreciacionAcum = 0
            TotalCostoEnergiaAcum = 0
            TotalCostoEnvasesAcum = 0
            TotalCostoGasNaturalAcum = 0
            TotalCostoManttoMecanicoAcum = 0
            TotalManoObraAcum = 0

            TotalCostoMantenimientoMaqPesadaAcum = 0
            TotalCostoSobrecostosEmpleadosAcum = 0
            TotalCostoSobrecostosObrerosAcum = 0

            Ruma = ""
            Obj_Hoja = Obj_Libro.Sheets(i + 2)
            Obj_Hoja.Activate()
            Obj_Libro.Sheets(i + 2).Name = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString

            Fila = 1
            Obj_Hoja.Cells(Fila, 2) = "Cía Minera Agregados Calcareos S.A."

            Fila = Fila + 2
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE PRODUCCION (S/.) POR  MOLINO - " & NameMes(Month(FechaInicio)) & " " & Year(FechaTermino)
            Call CombinarCeldas("B" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 14)

            Fila = Fila + 2
            Obj_Hoja.Cells(Fila, 2) = "Producto: "
            Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
            Obj_Hoja.Cells(Fila, 3) = Txt1.Text.Trim
            Obj_Hoja.Cells(Fila, 4) = Txt2.Text.Trim
            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "Molino: "
            Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
            Obj_Hoja.Cells(Fila, 3) = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
            Obj_Hoja.Cells(Fila, 4) = DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            Call FormatoCelda("B" & CStr(Fila) & ":B" & CStr(Fila + 3), "Arial", True, 8)
            Call FormatoCelda("C" & CStr(Fila) & ":L" & CStr(Fila + 3), "Arial", False, 8)

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            Application.DoEvents()
            lblCosteo.Text = ""
            lblDetalle.Text = ""
            Fila = Fila + 1

            Obj_Hoja.Cells(Fila, 2) = "Min. Requerido (TON):"
            Obj_Hoja.Cells(Fila, 3).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 3) = Val(DsProduccion.Tables(0).Rows(i).Item("TonConsumido").ToString)
            Call FormatoCelda("G" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "Produc.(TON):"
            Obj_Hoja.Cells(Fila, 3).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 3) = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)

            Obj_Hoja.Cells(Fila, 7) = "Hrs. Trab. x Molino:"
            Call CombinarCeldas("G" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("G" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = Val(DsProduccion.Tables(0).Rows(i).Item("HorasTrab").ToString)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "Prod x Molino:"
            Obj_Hoja.Cells(Fila, 3).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 3) = Val(DsProduccion.Tables(0).Rows(i).Item("TonUniProd").ToString)

            Obj_Hoja.Cells(Fila, 7) = "Silice Homogenizada (TON):"
            Call CombinarCeldas("G" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("G" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"

            TONSiliceHomog = 0
            If Val(DsProduccion.Tables(0).Rows(i).Item("TonSilicato").ToString) > 0 And Val(DsProduccion.Tables(0).Rows(i).Item("TonSilice").ToString) > 0 Then
                TONSiliceHomog = Val(DsProduccion.Tables(0).Rows(i).Item("TonSilicato").ToString) + Val(DsProduccion.Tables(0).Rows(i).Item("TonSilice").ToString)
            End If

            Obj_Hoja.Cells(Fila, 9) = TONSiliceHomog
            TotalProdMolino = 0
            If Rbt3.Checked = True Or Rbt5.Checked = True Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Obteniendo Datos Mensuales"
                lblDetalle.Text = ""
                Application.DoEvents()
                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.Trim
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                    .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("TonConsumido").ToString)
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                    .Cod_Alm = "19"
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                Negocio.CosteoProduccion.Consultar_Produccion_GenericoxMolino_Cierre(Entidad.Orden)
            End If

            'MANO DE OBRA 
            Dim dsManoObra As DataSet

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("ProduccionPlanta").ToString)
                .Descripcion = DsProduccion.Tables(0).Rows(i).Item("Molino").ToString.Trim
                .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsManoObra = Negocio.CosteoProduccion.Consultar_Produccion_ManoObra_Cierre(Entidad.Orden)
            'FIN MANO DE OBRA

            Pinta_Mano_de_Obra(dsManoObra, i, Fila, "R")


            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo Costeo del Cargador Frontal"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsPala As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .Anho = Year(FechaTermino)
                .Mes = Month(FechaTermino)
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                .Spid = Spid
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsPala = Negocio.CosteoProduccion.Consultar_Produccion_Pala_Cierre(Entidad.Orden)

            Dim dsPalaCombustible As DataSet
            Dim dsPalaMO As DataSet
            Dim dsPalaDeprec As DataSet
            Dim dsPalaManttoAlquiler As DataSet
            Dim CostoCombustible As Double = 0
            Dim CostoPala As Double = 0
            Dim CostoPalaMO As Double = 0
            Dim CostoPalaDeprec As Double = 0
            Dim CostoPalaAlqMantto As Double = 0
            TotalCostoPala = 0

            If dsPala.Tables(0).Rows.Count > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                lblDetalle.Text = ""
                Application.DoEvents()

                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DEL CARGADOR FRONTAL"
                Call CombinarCeldas("B" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 10)

                Fila = Fila + 1
                PintarCabecera = False

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal: " & dsPala.Tables(0).Rows(c).Item("Cod_Pala").ToString.Trim
                lblDetalle.Text = ""
                Application.DoEvents()

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal: " & dsPala.Tables(0).Rows(c).Item("Cod_Pala").ToString.Trim
                lblDetalle.Text = "Obteniendo el Consumo de Combustible del Cargador Frontal"
                Application.DoEvents()

                CostoPala = 0
                CostoCombustible = 0

                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.TrimEnd
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                    .Cod_Alm = "19"
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsPalaCombustible = Negocio.CosteoProduccion.Consultar_Produccion_Pala_Combustible_Cierre(Entidad.Orden)
                CostoCombustible = 0

                If dsPalaCombustible.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo del Cargador Frontal: " & dsPala.Tables(0).Rows(c).Item("Cod_Pala").ToString.Trim
                    lblDetalle.Text = "Exportando el Consumo de Combustible del Cargador Frontal"

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 4) = "CONSUMO DE COMBUSTIBLE"
                    Call FormatoCelda("D" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8)

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 8) = "Mensual"
                    Call CombinarCeldas("H" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Cargador Frontal"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 4) = "Codigo"
                    Obj_Hoja.Cells(Fila, 5) = "Combustible"
                    Call CombinarCeldas("E" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 7) = "Und"
                    Obj_Hoja.Cells(Fila, 8) = "Nro. O/C"
                    Obj_Hoja.Cells(Fila, 9) = "Consumo"
                    Obj_Hoja.Cells(Fila, 10) = "Cant. Comb."
                    Obj_Hoja.Cells(Fila, 11) = "Precio"
                    Obj_Hoja.Cells(Fila, 12) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                    FilaRuma = Fila


                    For cr = 0 To dsPalaCombustible.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsPalaCombustible.Tables(0).Rows(cr).Item("Cod_Pala").ToString.TrimEnd & " - " & dsPalaCombustible.Tables(0).Rows(cr).Item("Pala").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4) = dsPalaCombustible.Tables(0).Rows(cr).Item("Codigo").ToString.Trim
                        Obj_Hoja.Cells(Fila, 5) = dsPalaCombustible.Tables(0).Rows(cr).Item("Descripcion").ToString.Trim
                        Call CombinarCeldas("E" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 7) = dsPalaCombustible.Tables(0).Rows(cr).Item("unid").ToString.Trim
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 8) = dsPalaCombustible.Tables(0).Rows(cr).Item("Nro_OC").ToString.Trim
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsPalaCombustible.Tables(0).Rows(cr).Item("Consumo").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsPalaCombustible.Tables(0).Rows(cr).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsPalaCombustible.Tables(0).Rows(cr).Item("Precio").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsPalaCombustible.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", False, 8, , 1)
                        CostoCombustible = CostoCombustible + Val(dsPalaCombustible.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPala = TotalCostoPala + Val(dsPalaCombustible.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPalaAcum = TotalCostoPalaAcum + Val(dsPalaCombustible.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = "=SUM(I" & CStr(FilaRuma + 1) & ":I" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = "=SUM(J" & CStr(FilaRuma + 1) & ":J" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = "=L" & CStr(Fila) & "/J" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = "=SUM(L" & CStr(FilaRuma + 1) & ":L" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("I" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                    End If

                End If

                For icble As Integer = 1 To 1
                    CostoTipoCostoCble = 0
                    If icble = 1 Then
                        TipoCostoCble = "Mantenimiento y Reparación de Maquinaria Pesada"
                        CodTipoCostoCble = "MP"
                        TotalCostoMantenimientoMaqPesada = 0
                        DesCostoCble = "Costo Mantto. MP"
                    ElseIf icble = 2 Then
                        TipoCostoCble = "Sobrecostos Laborales Empleados"
                        CodTipoCostoCble = "SE"
                        TotalCostoSobrecostosEmpleados = 0
                        DesCostoCble = "Costo Empleados"
                    ElseIf icble = 3 Then
                        TipoCostoCble = "Sobrecostos Laborales Obreros"
                        CodTipoCostoCble = "SO"
                        TotalCostoSobrecostosObreros = 0
                        DesCostoCble = "Costo Obreros"
                    End If
                    lblEstado.Text = "Exportando " + TipoCostoCble + ": " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Obteniendo el Costeo del " + TipoCostoCble + " del Molino"

                    lblDetalle.Text = ""
                    Application.DoEvents()

                    Dim dsManttoMP As DataSet
                    Entidad.Orden = New ETOrden
                    With (Entidad.Orden)
                        .CodEnlace = CodEnlace
                        .CodProducto = Txt1.Text.Trim
                        .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                        .Usuario = User_Sistema
                        .Spid = Spid
                        .Anho = FechaTermino.Year
                        .Mes = FechaTermino.Month
                        .Tipo_Doc = CodTipoCostoCble
                        Negocio.CosteoProduccion = New NGCosteoProduccion
                        dsManttoMP = Negocio.CosteoProduccion.Consultar_Produccion_Contable_Cierre(Entidad.Orden)

                    End With


                    If dsManttoMP.Tables(0).Rows.Count > 0 Then
                        lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                        lblCosteo.Text = "Exportando el Costeo del " + TipoCostoCble + " del Molino"
                        lblDetalle.Text = ""

                        Fila = Fila + 2
                        Obj_Hoja.Cells(Fila, 2) = "COSTEO DE " + TipoCostoCble.ToUpper
                        'Call CombinarCeldas("B" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
                        Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8)

                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 7) = "Mensual"
                        Call CombinarCeldas("G" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)

                        Call FormatoCelda("G" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)

                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = "Tipo.Und.Prod"
                        Obj_Hoja.Cells(Fila, 3) = "Código"
                        Obj_Hoja.Cells(Fila, 4) = "Und. Prod."
                        Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                        Obj_Hoja.Cells(Fila, 7) = DesCostoCble
                        Obj_Hoja.Cells(Fila, 8) = "Producción"
                        Obj_Hoja.Cells(Fila, 9) = "Cant. TON"
                        Obj_Hoja.Cells(Fila, 10) = "Costo x TON"
                        Obj_Hoja.Cells(Fila, 11) = "SubTotal(S/.)"
                        FilaRuma = Fila
                        Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)

                        For r = 0 To dsManttoMP.Tables(0).Rows.Count - 1
                            Fila = Fila + 1
                            Obj_Hoja.Cells(Fila, 2) = dsManttoMP.Tables(0).Rows(r).Item("TipoUnidad").ToString.Trim
                            Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
                            Obj_Hoja.Cells(Fila, 3) = dsManttoMP.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                            Obj_Hoja.Cells(Fila, 4) = dsManttoMP.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                            Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                            Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 7) = Val(dsManttoMP.Tables(0).Rows(r).Item("CostoContable").ToString.Trim)
                            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 8) = Val(dsManttoMP.Tables(0).Rows(r).Item("Tonelaje").ToString.Trim)
                            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 9) = Val(dsManttoMP.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                            Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 10) = Val(dsManttoMP.Tables(0).Rows(r).Item("CostoxTon").ToString.Trim)
                            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 11) = Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)

                            Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1)

                            If icble = 1 Then
                                TipoCostoCble = "Mantenimiento y Reparación de Maquinaria Pesada"
                                CodTipoCostoCble = "MP"
                                TotalCostoMantenimientoMaqPesada = TotalCostoMantenimientoMaqPesada + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                                TotalCostoMantenimientoMaqPesadaAcum = TotalCostoMantenimientoMaqPesadaAcum + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                                DesCostoCble = "Costo Mantto. MP"
                            ElseIf icble = 2 Then
                                TipoCostoCble = "Sobrecostos Laborales Empleados"
                                CodTipoCostoCble = "SE"
                                TotalCostoSobrecostosEmpleados = TotalCostoSobrecostosEmpleados + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                                TotalCostoSobrecostosEmpleadosAcum = TotalCostoSobrecostosEmpleadosAcum + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)

                                DesCostoCble = "Costo Empleados"
                            ElseIf icble = 3 Then
                                TipoCostoCble = "Sobrecostos Laborales Obreros"
                                CodTipoCostoCble = "SO"
                                TotalCostoSobrecostosObreros = TotalCostoSobrecostosObreros + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                                TotalCostoSobrecostosObrerosAcum = TotalCostoSobrecostosObrerosAcum + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                                DesCostoCble = "Costo Obreros"
                            End If
                            CostoTipoCostoCble = CostoTipoCostoCble + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                        Next


                        For r = 0 To dsManttoMP.Tables(1).Rows.Count - 1
                            Fila = Fila + 1
                            Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
                            Obj_Hoja.Cells(Fila, 3) = dsManttoMP.Tables(1).Rows(r).Item("Naturaleza").ToString.Trim
                            Obj_Hoja.Cells(Fila, 4) = dsManttoMP.Tables(1).Rows(r).Item("Descripcion").ToString.Trim
                            Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                            Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 7) = Val(dsManttoMP.Tables(1).Rows(r).Item("Importe").ToString.Trim)
                            Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1)
                        Next
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 9) = "Costo Total:"
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = CostoTipoCostoCble

                        Call CombinarCeldas("J" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Derecha)
                        Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)
                    End If
                Next

                CostoCombustible = 0
                CostoPala = 0
                PintarCabecera = False
                CostoChandadora_MO = 0
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                lblDetalle.Text = "Obteniendo el Costo de Mano de Obra del Cargador Frontal"
                Application.DoEvents()

                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.TrimEnd
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cod_Alm = "19"
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsPalaMO = Negocio.CosteoProduccion.Consultar_Produccion_Pala_ManoObra_Cierre(Entidad.Orden)

                CostoPalaMO = 0

                CostoPalaMO = 0
                If dsPalaMO.Tables(0).Rows.Count > 0 Then

                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                    lblDetalle.Text = "Exportando el Costo de Mano de Obra del Cargador Frontal"

                    Fila = Fila + 2

                    Obj_Hoja.Cells(Fila, 4) = "MANO DE OBRA"
                    Call CombinarCeldas("D" & CStr(Fila) & ":R" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 8) = "Mensual"
                    Call CombinarCeldas("H" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("H" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Cargador Frontal"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 4) = "Código"
                    Obj_Hoja.Cells(Fila, 5) = "Personal"
                    Call CombinarCeldas("E" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 8) = "Total"
                    Obj_Hoja.Cells(Fila, 9) = "Total Horas"
                    Obj_Hoja.Cells(Fila, 10) = "Horas Prod."
                    Obj_Hoja.Cells(Fila, 11) = "Costo M.O."
                    Obj_Hoja.Cells(Fila, 12) = "Costo x Hora"
                    Obj_Hoja.Cells(Fila, 13) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 14) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 15) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                    FilaRuma = Fila
                    PintarCabecera = True

                    For cr = 0 To dsPalaMO.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsPalaMO.Tables(0).Rows(cr).Item("Cod_Pala").ToString.TrimEnd & " - " & dsPalaMO.Tables(0).Rows(cr).Item("Pala").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 4) = dsPalaMO.Tables(0).Rows(cr).Item("PlaCod").ToString.Trim
                        Obj_Hoja.Cells(Fila, 5) = dsPalaMO.Tables(0).Rows(cr).Item("Descripcion").ToString.Trim
                        Call CombinarCeldas("E" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsPalaMO.Tables(0).Rows(cr).Item("Boleta").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsPalaMO.Tables(0).Rows(cr).Item("HorasLab").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsPalaMO.Tables(0).Rows(cr).Item("Horas").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsPalaMO.Tables(0).Rows(cr).Item("CostoMO").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsPalaMO.Tables(0).Rows(cr).Item("CostoxHora").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsPalaMO.Tables(0).Rows(cr).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = Val(dsPalaMO.Tables(0).Rows(cr).Item("CostoxTon").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = Val(dsPalaMO.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        CostoPalaMO = CostoPalaMO + Val(dsPalaMO.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPala = TotalCostoPala + Val(dsPalaMO.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPalaAcum = TotalCostoPalaAcum + Val(dsPalaMO.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", False, 8, , 1)
                    Next

                    If PintarCabecera = True Then
                        If (Fila) - (FilaRuma + 1) > 0 Then
                            Fila = Fila + 1
                            Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 13) = "=SUM(M" & CStr(FilaRuma + 1) & ":M" & CStr(Fila - 1) & ")"
                            Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 14) = "=O" & CStr(Fila) & "/M" & CStr(Fila)
                            Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 15) = "=SUM(O" & CStr(FilaRuma + 1) & ":O" & CStr(Fila - 1) & ")"
                            Call FormatoCelda("M" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                        End If
                    End If

                End If

                CostoPalaMO = 0
                CostoCombustible = 0
                CostoPala = 0
                PintarCabecera = False
                CostoPalaDeprec = 0

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal" '& dsPala.Tables(0).Rows(c).Item("Cod_Pala").ToString.Trim
                lblDetalle.Text = "Obteniendo la Depreciación del Cargador Frontal"
                Application.DoEvents()

                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.TrimEnd
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .Cod_Alm = "19"
                    .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsPalaDeprec = Negocio.CosteoProduccion.Consultar_Produccion_Pala_Depreciacion_Cierre(Entidad.Orden)

                If dsPalaDeprec.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo del Cargador Frontal" '& dsPala.Tables(0).Rows(c).Item("Cod_Pala").ToString.Trim
                    lblDetalle.Text = "Exportando la Depreciación del Cargador Frontal"

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "DEPRECIACIÓN CARGADOR FRONTAL"
                    Call CombinarCeldas("B" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8)

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 6) = "Mensual"
                    Call CombinarCeldas("F" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("F" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Código"
                    Obj_Hoja.Cells(Fila, 3) = "Und. Prod."
                    Call CombinarCeldas("C" & CStr(Fila) & ":E" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 6) = "Costo Deprec."
                    Obj_Hoja.Cells(Fila, 7) = "Producción"
                    Obj_Hoja.Cells(Fila, 8) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 9) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 10) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                    FilaRuma = Fila
                    PintarCabecera = True

                    For cr = 0 To dsPalaDeprec.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 2) = dsPalaDeprec.Tables(0).Rows(cr).Item("Codigo").ToString.Trim
                        Obj_Hoja.Cells(Fila, 3) = dsPalaDeprec.Tables(0).Rows(cr).Item("Descripcion").ToString.Trim
                        Call CombinarCeldas("C" & CStr(Fila) & ":E" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = Val(dsPalaDeprec.Tables(0).Rows(cr).Item("CostoDeprec").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsPalaDeprec.Tables(0).Rows(cr).Item("Tonelaje").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsPalaDeprec.Tables(0).Rows(cr).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsPalaDeprec.Tables(0).Rows(cr).Item("CostoxTon").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsPalaDeprec.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", False, 8, , 1)
                        CostoPalaDeprec = CostoPalaDeprec + Val(dsPalaDeprec.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPala = TotalCostoPala + Val(dsPalaDeprec.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPalaAcum = TotalCostoPalaAcum + Val(dsPalaDeprec.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = "=SUM(F" & CStr(FilaRuma + 1) & ":F" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = "=SUM(G" & CStr(FilaRuma + 1) & ":G" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = "=SUM(H" & CStr(FilaRuma + 1) & ":H" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = "=J" & CStr(Fila) & "/H" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = "=SUM(J" & CStr(FilaRuma + 1) & ":J" & CStr(Fila - 1) & ")"

                        Call FormatoCelda("F" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                    End If

                End If

                CostoPalaMO = 0
                CostoCombustible = 0
                CostoPala = 0
                PintarCabecera = False
                CostoPalaDeprec = 0
                CostoPalaAlqMantto = 0

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                lblDetalle.Text = "Obteniendo el Costo del Mantto. Mecánico del Cargador Frontal"
                Application.DoEvents()

                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.TrimEnd
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .Cod_Alm = "19"
                    .Tipo = 0
                    .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsPalaManttoAlquiler = Negocio.CosteoProduccion.Consultar_Produccion_Pala_Alquiler_Mantto_Cierre(Entidad.Orden)

                CostoPalaAlqMantto = 0
                If dsPalaManttoAlquiler.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                    lblDetalle.Text = "Exportando el Costo del Mantto. Automotriz del Cargador Frontal"

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "MANTENIMIENTO AUTOMOTRIZ"
                    Call CombinarCeldas("D" & CStr(Fila) & ":R" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 7) = "Mensual"
                    Call CombinarCeldas("G" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("G" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Cargador Frontal"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 4) = "Proveedor"
                    Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 7) = "Tipo. Doc."
                    Obj_Hoja.Cells(Fila, 8) = "Nro. Doc."
                    Call CombinarCeldas("H" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 11) = "Total(Sin IGV)"
                    Obj_Hoja.Cells(Fila, 12) = "Produccion"
                    Obj_Hoja.Cells(Fila, 13) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 14) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 15) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                    FilaRuma = Fila

                    For cr = 0 To dsPalaManttoAlquiler.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsPala.Tables(0).Rows(cr).Item("Cod_Pala").ToString.TrimEnd & " - " & dsPala.Tables(0).Rows(cr).Item("Pala").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4) = dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Proveedor").ToString.Trim
                        Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 7) = dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Tipo_Doc").ToString.Trim
                        Call CombinarCeldas("H" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 8) = Trim(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Num_Doc").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Total").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Produccion").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("CostoxTON").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", False, 8, , 1)
                        CostoPalaAlqMantto = CostoPalaAlqMantto + Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPala = TotalCostoPala + Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPalaAcum = TotalCostoPalaAcum + Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = "=SUM(K" & CStr(FilaRuma + 1) & ":K" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = "=SUM(L" & CStr(FilaRuma + 1) & ":L" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(M" & CStr(FilaRuma + 1) & ":M" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = "=O" & CStr(Fila) & "/M" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = "=SUM(O" & CStr(FilaRuma + 1) & ":O" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(P" & CStr(FilaRuma + 1) & ":P" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = "=R" & CStr(Fila) & "/P" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = "=SUM(R" & CStr(FilaRuma + 1) & ":R" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("K" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)

                    End If

                End If

                CostoPalaMO = 0
                CostoCombustible = 0
                CostoPala = 0
                PintarCabecera = False
                CostoPalaDeprec = 0
                CostoPalaAlqMantto = 0

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                lblDetalle.Text = "Obteniendo el Costo de Alquiler del Cargador Frontal"
                Application.DoEvents()

                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.TrimEnd
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .Cod_Alm = "19"
                    .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                    .Tipo = 1
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsPalaManttoAlquiler = Negocio.CosteoProduccion.Consultar_Produccion_Pala_Alquiler_Mantto_Cierre(Entidad.Orden)

                CostoPalaAlqMantto = 0
                If dsPalaManttoAlquiler.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                    lblDetalle.Text = "Exportando el Costo del Alquiler del Cargador Frontal"

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "ALQUILER"
                    Call CombinarCeldas("D" & CStr(Fila) & ":R" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 7) = "Mensual"
                    Call CombinarCeldas("G" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("G" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Cargador Frontal"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 4) = "Proveedor"
                    Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 7) = "Tipo. Doc."
                    Obj_Hoja.Cells(Fila, 8) = "Nro. Doc."
                    Call CombinarCeldas("H" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 11) = "Total(Sin IGV)"
                    Obj_Hoja.Cells(Fila, 12) = "Produccion"
                    Obj_Hoja.Cells(Fila, 13) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 14) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 15) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                    FilaRuma = Fila

                    For cr = 0 To dsPalaManttoAlquiler.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsPala.Tables(0).Rows(cr).Item("Cod_Pala").ToString.TrimEnd & " - " & dsPala.Tables(0).Rows(cr).Item("Pala").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4) = dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Proveedor").ToString.Trim
                        Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 7) = dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Tipo_Doc").ToString.Trim
                        Call CombinarCeldas("H" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 8) = Trim(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Num_Doc").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Total").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Produccion").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("CostoxTON").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", False, 8, , 1)

                        CostoPalaAlqMantto = CostoPalaAlqMantto + Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPala = TotalCostoPala + Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPalaAcum = TotalCostoPalaAcum + Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = "=SUM(K" & CStr(FilaRuma + 1) & ":K" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = "=SUM(L" & CStr(FilaRuma + 1) & ":L" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(M" & CStr(FilaRuma + 1) & ":M" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = "=O" & CStr(Fila) & "/M" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = "=SUM(O" & CStr(FilaRuma + 1) & ":O" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(P" & CStr(FilaRuma + 1) & ":P" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = "=R" & CStr(Fila) & "/P" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = "=SUM(R" & CStr(FilaRuma + 1) & ":R" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("K" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)

                    End If

                End If

            End If

            CostoPalaMO = 0
            CostoCombustible = 0
            CostoPala = 0
            CostoPalaDeprec = 0
            CostoPalaAlqMantto = 0

            TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("ProduccionPlanta").ToString)
            Fila = Fila + 1

            'lalooo
            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo Datos de Costeo RUMA Y/O PRODUCTOS Y/O SUMINISTROS"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsRuma As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .Usuario = User_Sistema
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                .Spid = Spid
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsRuma = Negocio.CosteoProduccion.Consultar_Produccion_Ruma_Cierre(Entidad.Orden)

            TotalCostoRuma = 0
            TotalCostoRumaAcum = 0
            CantidadRuma = 0
            CostoUnitarioRuma = 0
            TipoEnlace = String.Empty
            CantidadAcum = 0
            SubTotalAcum = 0
            CostoTotalAcum = 0
            If dsRuma.Tables(0).Rows.Count > 0 Then
                Fila = Fila + 2

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando Costeo RUMA Y/O PRODUCTOS Y/O SUMINISTROS"
                lblDetalle.Text = ""
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE RUMA Y/O PRODUCTO TERMINADO Y/O SUMINISTRO"

                Call CombinarCeldas("B" & CStr(Fila) & ":S" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":S" & CStr(Fila), "Arial", True, 10)

                FilaRuma = 0
                TotalRuma = 0
                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 12) = "Costo de Mineral (Mensual)"
                Call CombinarCeldas("L" & CStr(Fila) & ":S" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("L" & CStr(Fila) & ":S" & CStr(Fila), "Arial", True, 8, , 1)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2) = "Tipo"
                Obj_Hoja.Cells(Fila, 3) = "Cod. Ruma"
                Obj_Hoja.Cells(Fila, 4) = "Ruma"
                Obj_Hoja.Cells(Fila, 5) = "Código"
                Obj_Hoja.Cells(Fila, 6) = "Descripción"
                Call CombinarCeldas("F" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 9) = "Normal TON"
                Obj_Hoja.Cells(Fila, 10) = "Humedad TON"
                Obj_Hoja.Cells(Fila, 11) = "Merma TON"
                Obj_Hoja.Cells(Fila, 12) = "Cant. Req. TON"
                Obj_Hoja.Cells(Fila, 13) = "Regalías"
                Obj_Hoja.Cells(Fila, 14) = "Extracción"
                Obj_Hoja.Cells(Fila, 15) = "Compras"
                Obj_Hoja.Cells(Fila, 16) = "Flete"
                Obj_Hoja.Cells(Fila, 17) = "Otros"
                Obj_Hoja.Cells(Fila, 18) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 19) = "SubTotal(S/.)"
                Call FormatoCelda("B" & CStr(Fila) & ":S" & CStr(Fila), "Arial", True, 8, , 1)
                FilaRuma = Fila

                For r = 0 To dsRuma.Tables(0).Rows.Count - 1
                    Fila = Fila + 1
                    TipoEnlace = dsRuma.Tables(0).Rows(r).Item("TipoEnlace").ToString.Trim
                    Obj_Hoja.Cells(Fila, 2) = TipoEnlace
                    If TipoEnlace = "RUMA" Then
                        Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 3) = dsRuma.Tables(0).Rows(r).Item("CodRuma").ToString.Trim
                        Obj_Hoja.Cells(Fila, 4) = dsRuma.Tables(0).Rows(r).Item("Ruma").ToString.Trim
                    End If
                    Obj_Hoja.Cells(Fila, 5).NumberFormat = "@"
                    Obj_Hoja.Cells(Fila, 5) = dsRuma.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                    Obj_Hoja.Cells(Fila, 6) = dsRuma.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                    Call CombinarCeldas("F" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = Val(dsRuma.Tables(0).Rows(r).Item("CantProd").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = Val(dsRuma.Tables(0).Rows(r).Item("CantHumedad").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 11) = Val(dsRuma.Tables(0).Rows(r).Item("CantMerma").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 12) = Val(dsRuma.Tables(0).Rows(r).Item("CantidadTON").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 13) = Val(dsRuma.Tables(0).Rows(r).Item("CostoxRegalias").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 14) = Val(dsRuma.Tables(0).Rows(r).Item("CostoxExtraccion").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 15) = Val(dsRuma.Tables(0).Rows(r).Item("CostoxCompra").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 16).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 16) = Val(dsRuma.Tables(0).Rows(r).Item("CostoxFlete").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 17).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 17) = Val(dsRuma.Tables(0).Rows(r).Item("CostoxOtros").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 18).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 18) = Val(dsRuma.Tables(0).Rows(r).Item("CostoxTON").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 19).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 19) = Val(dsRuma.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)

                    TotalCostoRuma = TotalCostoRuma + Val(dsRuma.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    CantidadRuma = CantidadRuma + Val(dsRuma.Tables(0).Rows(r).Item("CantidadTON").ToString.Trim)
                    TotalRuma = TotalRuma + Val(dsRuma.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    SubTotalAcum = SubTotalAcum + Val(dsRuma.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                    CostoTotalAcum = CostoTotalAcum + Val(dsRuma.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                    CantidadAcum = CantidadAcum + Val(dsRuma.Tables(0).Rows(r).Item("CantAcum").ToString.Trim)
                    TotalCostoRumaAcum = TotalCostoRumaAcum + Val(dsRuma.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                    TotalProdMolino = TotalProdMolino + Val(dsRuma.Tables(0).Rows(r).Item("CantNormalAcum").ToString.Trim)
                    'Call CombinarCeldas("B" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("B" & CStr(Fila) & ":S" & CStr(Fila), "Arial", False, 8, , 1)
                Next


                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 9) = "=SUM(I" & CStr(FilaRuma + 1) & ":I" & CStr(Fila - 1) & ")"

                Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 10) = "=SUM(J" & CStr(FilaRuma + 1) & ":J" & CStr(Fila - 1) & ")"

                Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 11) = "=SUM(K" & CStr(FilaRuma + 1) & ":K" & CStr(Fila - 1) & ")"

                Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 12) = "=SUM(L" & CStr(FilaRuma + 1) & ":L" & CStr(Fila - 1) & ")"
                'Obj_Hoja.Cells(Fila, 11) = CantidadRuma

                'Call CombinarCeldas("K" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)

                Obj_Hoja.Cells(Fila, 13) = "Costo x TON:"
                Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                If CantidadRuma <> 0 Then
                    Obj_Hoja.Cells(Fila, 14) = TotalCostoRuma / CantidadRuma
                Else
                    Obj_Hoja.Cells(Fila, 14) = 0
                End If

                Call CombinarCeldas("N" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)

                Obj_Hoja.Cells(Fila, 17) = "Costo Total:"
                Obj_Hoja.Cells(Fila, 18).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 18) = TotalCostoRuma
                Call CombinarCeldas("R" & CStr(Fila) & ":S" & CStr(Fila), Alineacion.Centrado)

                Call FormatoCelda("I" & CStr(Fila) & ":S" & CStr(Fila), "Arial", False, 8, , 1)
                Call FormatoCelda("I" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("K" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("N" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("R" & CStr(Fila) & ":S" & CStr(Fila), "Arial", True, 8, , 1)
            End If
            TotalCostoSiliceHomog = 0
            TotalCostoSiliceHomogAcum = 0
            If TONSiliceHomog > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Obteniendo Datos del Costo de Homogenización de Silice"
                lblDetalle.Text = ""
                Application.DoEvents()

                Dim dsSilice As DataSet
                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.Trim
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                    .Usuario = User_Sistema
                    .Cantidad = TONSiliceHomog
                    .Spid = Spid
                    .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsSilice = Negocio.CosteoProduccion.Consultar_Produccion_Silice_Cierre(Entidad.Orden)
                If dsSilice.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo de la Homogenización de Silice"
                    lblDetalle.Text = ""
                    Application.DoEvents()
                    Fila = Fila + 2

                    Obj_Hoja.Cells(Fila, 2) = "COSTEO DE HOMOGENIZACIÓN DE SILICE"
                    Call CombinarCeldas("B" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 10)
                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 6) = "Mensual"
                    Call CombinarCeldas("F" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("F" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Código"
                    Obj_Hoja.Cells(Fila, 3) = "Descripción"
                    Call CombinarCeldas("C" & CStr(Fila) & ":E" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 6) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 7) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 8) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                    FilaRuma = Fila

                    For sh = 0 To dsSilice.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 2) = dsSilice.Tables(0).Rows(sh).Item("Concepto").ToString.TrimEnd
                        Obj_Hoja.Cells(Fila, 3) = dsSilice.Tables(0).Rows(sh).Item("Descripcion").ToString.TrimEnd
                        Call CombinarCeldas("C" & CStr(Fila) & ":E" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = Val(dsSilice.Tables(0).Rows(sh).Item("Cantidad").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsSilice.Tables(0).Rows(sh).Item("CostoxTON").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsSilice.Tables(0).Rows(sh).Item("SubTotal").ToString.TrimEnd)
                        TotalCostoSiliceHomog = TotalCostoSiliceHomog + Val(dsSilice.Tables(0).Rows(sh).Item("SubTotal").ToString.TrimEnd)
                        TotalCostoSiliceHomogAcum = TotalCostoSiliceHomogAcum + Val(dsSilice.Tables(0).Rows(sh).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", False, 8, , 1)
                    Next

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 6) = "=AVERAGE(F" & CStr(FilaRuma + 1) & ":F" & CStr(Fila - 1) & ")"
                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = "=H" & CStr(Fila) & "/F" & CStr(Fila)
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = "=SUM(H" & CStr(FilaRuma + 1) & ":H" & CStr(Fila - 1) & ")"
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"

                    Call FormatoCelda("F" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                End If

            End If

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo Datos del Costeo de la Chancadora"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsChancadora As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Anho = Year(FechaTermino)
                .Mes = Month(FechaTermino)
                .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                .Spid = Spid
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsChancadora = Negocio.CosteoProduccion.Consultar_Produccion_Chancadora_Cierre(Entidad.Orden)

            TotalCostoChancadora = 0
            TotalCostoChancadoraAcum = 0

            If dsChancadora.Tables(0).Rows.Count > 0 Then

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                lblDetalle.Text = ""
                Application.DoEvents()
                Fila = Fila + 2

                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE CHANCADORA"
                Call CombinarCeldas("B" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 10)


                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                lblDetalle.Text = "Obteniendo el Transporte Interno de la Chancadora"
                Application.DoEvents()

                Dim dsChancTI As DataSet
                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.Trim
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                    .Usuario = User_Sistema
                    .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                    .Spid = Spid
                    .Anho = Year(FechaTermino)
                    .Mes = Month(FechaTermino)
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsChancTI = Negocio.CosteoProduccion.Consultar_Produccion_Chancadora_TranspInt_Cierre(Entidad.Orden)
                If dsChancTI.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                    lblDetalle.Text = "Exportando el Transporte Interno de la Chancadora"
                    Application.DoEvents()

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "TRANSPORTE A CHANCADORA"
                    Call CombinarCeldas("D" & CStr(Fila) & ":M" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 5) = "Mensual"
                    Call CombinarCeldas("E" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("E" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Chancadora"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 4) = "Transporte"
                    Obj_Hoja.Cells(Fila, 5) = "TON Transp."
                    Obj_Hoja.Cells(Fila, 6) = "Costo Transp."
                    Obj_Hoja.Cells(Fila, 7) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 8) = "TON Chanc."
                    Obj_Hoja.Cells(Fila, 9) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 10) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                    FilaRuma = Fila
                    Dim lPlaca As String = ""
                    Dim lFilaPlaca As String = 0
                    For cr = 0 To dsChancTI.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        If lPlaca <> dsChancTI.Tables(0).Rows(cr).Item("Transporte").ToString.TrimEnd Then
                            lPlaca = dsChancTI.Tables(0).Rows(cr).Item("Transporte").ToString.TrimEnd
                            Obj_Hoja.Cells(Fila, 4).NumberFormat = "@"
                            Obj_Hoja.Cells(Fila, 4) = dsChancTI.Tables(0).Rows(cr).Item("Transporte").ToString.TrimEnd
                            Obj_Hoja.Cells(Fila, 5).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 5) = Val(dsChancTI.Tables(0).Rows(cr).Item("TotalTranspProduccion").ToString.TrimEnd)
                            Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 6) = Val(dsChancTI.Tables(0).Rows(cr).Item("CostoTransporte").ToString.TrimEnd)
                            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 9) = Val(dsChancTI.Tables(0).Rows(cr).Item("CostoxTON").ToString.TrimEnd)
                            If lFilaPlaca <> 0 Then
                                Call CombinarCeldas("D" & CStr(lFilaPlaca) & ":D" & CStr(Fila - 1), Alineacion.Izquierda)
                                Call CombinarCeldas("E" & CStr(lFilaPlaca) & ":E" & CStr(Fila - 1), Alineacion.Derecha)
                                Call CombinarCeldas("F" & CStr(lFilaPlaca) & ":F" & CStr(Fila - 1), Alineacion.Derecha)
                                Call CombinarCeldas("I" & CStr(lFilaPlaca) & ":I" & CStr(Fila - 1), Alineacion.Derecha)
                            End If
                            lFilaPlaca = Fila
                        End If
                        Obj_Hoja.Cells(Fila, 2) = dsChancTI.Tables(0).Rows(cr).Item("Cod_Chancadora").ToString.TrimEnd + " - " + dsChancTI.Tables(0).Rows(cr).Item("Chancadora").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        'Obj_Hoja.Cells(Fila, 4).NumberFormat = "@"
                        'Obj_Hoja.Cells(Fila, 4) = dsChancTI.Tables(0).Rows(cr).Item("Transporte").ToString.TrimEnd
                        'Obj_Hoja.Cells(Fila, 5).NumberFormat = "#,##0.0000"
                        'Obj_Hoja.Cells(Fila, 5) = Val(dsChancTI.Tables(0).Rows(cr).Item("TotalTranspProduccion").ToString.TrimEnd)
                        'Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        'Obj_Hoja.Cells(Fila, 6) = Val(dsChancTI.Tables(0).Rows(cr).Item("CostoTransporte").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsChancTI.Tables(0).Rows(cr).Item("Cantidad").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsChancTI.Tables(0).Rows(cr).Item("TotalChancProduccion").ToString.TrimEnd)
                        'Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        'Obj_Hoja.Cells(Fila, 9) = Val(dsChancTI.Tables(0).Rows(cr).Item("CostoxTON").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsChancTI.Tables(0).Rows(cr).Item("SubTotal").ToString.TrimEnd)
                        TotalCostoChancadora = TotalCostoChancadora + Val(dsChancTI.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoChancadoraAcum = TotalCostoChancadoraAcum + Val(dsChancTI.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", False, 8, , 1)
                    Next
                    If lFilaPlaca <> 0 Then
                        Call CombinarCeldas("D" & CStr(lFilaPlaca) & ":D" & CStr(Fila), Alineacion.Izquierda)
                        Call CombinarCeldas("E" & CStr(lFilaPlaca) & ":E" & CStr(Fila), Alineacion.Derecha)
                        Call CombinarCeldas("F" & CStr(lFilaPlaca) & ":F" & CStr(Fila), Alineacion.Derecha)
                        Call CombinarCeldas("I" & CStr(lFilaPlaca) & ":I" & CStr(Fila), Alineacion.Derecha)
                    End If

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = "=SUM(G" & CStr(FilaRuma) & ":G" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = "=SUM(H" & CStr(FilaRuma) & ":H" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = "=J" & CStr(Fila) & "/G" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = "=SUM(J" & CStr(FilaRuma) & ":J" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("G" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                    End If
                End If


                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                lblDetalle.Text = "Obteniendo el Mantenimiento Mecánico de la Chancadora"
                Application.DoEvents()

                Dim dsChancME As DataSet
                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.Trim
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                    .Usuario = User_Sistema
                    .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                    .Spid = Spid
                End With

                'Dureza del Prodcuto

                'lDureza = Negocio.CosteoProduccion.Consultar_Dureza_Producto(Companhia, Year(Entidad.Orden.FechaTerminacion), Month(Entidad.Orden.FechaTerminacion), Entidad.Orden.CodProducto, Entidad.Orden.CodMolino)
                'Obj_Hoja.Cells(5, 8) = "Fact. Dureza"
                'Obj_Hoja.Cells(5, 9) = lDureza
                'Fin Dureza

                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsChancME = Negocio.CosteoProduccion.Consultar_Produccion_Chancadora_ManttoMecanico_Cierre(Entidad.Orden)
                If dsChancME.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                    lblDetalle.Text = "Exportando el Mantenimiento Mecánico de la Chancadora"
                    Application.DoEvents()

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "MANTENIMIENTO MECÁNICO"
                    Call CombinarCeldas("D" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 4) = "Mensual"
                    Call CombinarCeldas("D" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("D" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Chancadora"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 4) = "Producción(TON)"
                    Obj_Hoja.Cells(Fila, 5) = "M de Obra"
                    Obj_Hoja.Cells(Fila, 6) = "Materiales"
                    Obj_Hoja.Cells(Fila, 7) = "Total Mantto"
                    Obj_Hoja.Cells(Fila, 8) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 9) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 10) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                    FilaRuma = Fila
                    For cr = 0 To dsChancME.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsChancME.Tables(0).Rows(cr).Item("Codigo").ToString.TrimEnd + " - " + dsChancME.Tables(0).Rows(cr).Item("Descripcion").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 4) = Val(dsChancME.Tables(0).Rows(cr).Item("Tonelaje").ToString.TrimEnd)

                        Obj_Hoja.Cells(Fila, 5).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 5) = Val(dsChancME.Tables(0).Rows(cr).Item("CostoManObra").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = Val(dsChancME.Tables(0).Rows(cr).Item("CostoMantto").ToString.TrimEnd) - Val(dsChancME.Tables(0).Rows(cr).Item("CostoManObra").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsChancME.Tables(0).Rows(cr).Item("CostoMantto").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsChancME.Tables(0).Rows(cr).Item("Cantidad").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsChancME.Tables(0).Rows(cr).Item("CostoxTON").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsChancME.Tables(0).Rows(cr).Item("SubTotal").ToString.TrimEnd)

                        TotalCostoChancadora = TotalCostoChancadora + Val(dsChancME.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoChancadoraAcum = TotalCostoChancadoraAcum + Val(dsChancME.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", False, 8, , 1)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 4) = "=SUM(D" & CStr(FilaRuma) & ":D" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 5).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 5) = "=SUM(E" & CStr(FilaRuma) & ":E" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = "=SUM(F" & CStr(FilaRuma) & ":F" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = "=SUM(G" & CStr(FilaRuma) & ":G" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = "=SUM(H" & CStr(FilaRuma) & ":H" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = "=J" & CStr(Fila) & "/H" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = "=SUM(J" & CStr(FilaRuma) & ":J" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("D" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                    End If

                End If


                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                lblDetalle.Text = "Obteniendo la Depreciación de la Chancadora"
                Application.DoEvents()

                Dim dsChancDep As DataSet
                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.Trim
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsChancDep = Negocio.CosteoProduccion.Consultar_Produccion_Chancadora_Depreciacion_Cierre(Entidad.Orden)
                If dsChancDep.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                    lblDetalle.Text = "Exportando la Depreciación de la Chancadora"
                    Application.DoEvents()

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "DEPRECIACIÓN"
                    Call CombinarCeldas("D" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 4) = "Mensual"
                    Call CombinarCeldas("D" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("D" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Chancadora"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 4) = "Producción(TON)"
                    Obj_Hoja.Cells(Fila, 5) = "Costo Mantto"
                    Obj_Hoja.Cells(Fila, 6) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 7) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 8) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                    FilaRuma = Fila
                    For cr = 0 To dsChancDep.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsChancDep.Tables(0).Rows(cr).Item("Codigo").ToString.TrimEnd + " - " + dsChancDep.Tables(0).Rows(cr).Item("Descripcion").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 4) = Val(dsChancDep.Tables(0).Rows(cr).Item("Tonelaje").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 5).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 5) = Val(dsChancDep.Tables(0).Rows(cr).Item("CostoDeprec").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = Val(dsChancDep.Tables(0).Rows(cr).Item("Cantidad").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsChancDep.Tables(0).Rows(cr).Item("CostoxTON").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsChancDep.Tables(0).Rows(cr).Item("SubTotal").ToString.TrimEnd)
                        TotalCostoChancadora = TotalCostoChancadora + Val(dsChancDep.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoChancadoraAcum = TotalCostoChancadoraAcum + Val(dsChancDep.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", False, 8, , 1)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 4) = "=SUM(D" & CStr(FilaRuma) & ":D" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 5).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 5) = "=SUM(E" & CStr(FilaRuma) & ":E" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = "=SUM(F" & CStr(FilaRuma) & ":F" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = "=H" & CStr(Fila) & "/F" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = "=SUM(H" & CStr(FilaRuma) & ":H" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("D" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                    End If
                End If

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                lblDetalle.Text = "Obteniendo la Energía Electrica de la Chancadora"
                Application.DoEvents()

                Dim dsChancEnergia As DataSet
                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.Trim
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                    .Usuario = User_Sistema
                    .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                    .Spid = Spid
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsChancEnergia = Negocio.CosteoProduccion.Consultar_Produccion_Chancadora_Energia_Cierre(Entidad.Orden)
                If dsChancEnergia.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                    lblDetalle.Text = "Exportando la Energía Electrica de la Chancadora"
                    Application.DoEvents()

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "ENERGÍA ELECTRICA"
                    Call CombinarCeldas("D" & CStr(Fila) & ":M" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 4) = "Mensual"
                    Call CombinarCeldas("D" & CStr(Fila) & ":M" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("D" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Chancadora"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 4) = "Referencia"
                    Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 7) = "Producción(TON)"
                    Obj_Hoja.Cells(Fila, 8) = "Energia(KWH)"
                    Obj_Hoja.Cells(Fila, 9) = "Consumo(KWH)"
                    Obj_Hoja.Cells(Fila, 10) = "Costo KWH"
                    Obj_Hoja.Cells(Fila, 11) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 12) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 13) = "SubTotal(S/.)"

                    Call FormatoCelda("B" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1)
                    FilaRuma = Fila
                    For cr = 0 To dsChancEnergia.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsChancEnergia.Tables(0).Rows(cr).Item("Codigo").ToString.TrimEnd + " - " + dsChancEnergia.Tables(0).Rows(cr).Item("Descripcion").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 4) = dsChancEnergia.Tables(0).Rows(cr).Item("Referencia").ToString.TrimEnd
                        Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("Tonelaje").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("EnergiaTotal").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("Energia").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("CostoKWH").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("Cantidad").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("CostoxTON").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("SubTotal").ToString.TrimEnd)
                        TotalCostoChancadora = TotalCostoChancadora + Val(dsChancEnergia.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoChancadoraAcum = TotalCostoChancadoraAcum + Val(dsChancEnergia.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":M" & CStr(Fila), "Arial", False, 8, , 1)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = "=SUM(G" & CStr(FilaRuma) & ":G" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = "=SUM(H" & CStr(FilaRuma) & ":H" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = "=SUM(I" & CStr(FilaRuma) & ":I" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = "=SUM(J" & CStr(FilaRuma) & ":J" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = "=SUM(K" & CStr(FilaRuma) & ":K" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = "=M" & CStr(Fila) & "/K" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(M" & CStr(FilaRuma) & ":M" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("G" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1)
                    End If

                End If


                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                lblDetalle.Text = "Obteniendo la Mano de Obra de la Chancadora"
                Application.DoEvents()

                Dim dsChancManoObra As DataSet
                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.TrimEnd
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cod_Alm = "19"
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsChancManoObra = Negocio.CosteoProduccion.Consultar_Produccion_Chancadora_ManoObra_Cierre(Entidad.Orden)

                If dsChancManoObra.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                    lblDetalle.Text = "Exportando la Mano de Obra de la Chancadora"
                    Fila = Fila + 2

                    Obj_Hoja.Cells(Fila, 4) = "MANO DE OBRA (CHANCADORA)"
                    Call CombinarCeldas("D" & CStr(Fila) & ":P" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":P" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 8) = "Mensual"
                    Call CombinarCeldas("H" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("H" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Chancadora"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 4) = "Código"
                    Obj_Hoja.Cells(Fila, 5) = "Personal"
                    Call CombinarCeldas("E" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 8) = "Total"
                    Obj_Hoja.Cells(Fila, 9) = "Total Horas"
                    Obj_Hoja.Cells(Fila, 10) = "Horas Prod."
                    Obj_Hoja.Cells(Fila, 11) = "Costo M.O."
                    Obj_Hoja.Cells(Fila, 12) = "Costo x Hora"
                    Obj_Hoja.Cells(Fila, 13) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 14) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 15) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                    FilaRuma = Fila

                    For cr = 0 To dsChancManoObra.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsChancManoObra.Tables(0).Rows(cr).Item("Cod_Chancadora").ToString.TrimEnd & " - " & dsChancManoObra.Tables(0).Rows(cr).Item("Chancadora").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 4) = dsChancManoObra.Tables(0).Rows(cr).Item("PlaCod").ToString.Trim
                        Obj_Hoja.Cells(Fila, 5) = dsChancManoObra.Tables(0).Rows(cr).Item("Descripcion").ToString.Trim
                        Call CombinarCeldas("E" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("Boleta").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("HorasLab").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("Horas").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("CostoMO").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("CostoxHora").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("CostoxTon").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoChancadora = TotalCostoChancadora + Val(dsChancManoObra.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoChancadoraAcum = TotalCostoChancadoraAcum + Val(dsChancManoObra.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", False, 8, , 1)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=AVERAGE(M" & CStr(FilaRuma + 1) & ":M" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = "=O" & CStr(Fila) & "/M" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = "=SUM(O" & CStr(FilaRuma + 1) & ":O" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("M" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                    End If

                End If

            End If

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo el Costeo de la Mano de Obra del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()

            'Dim dsManoObra As DataSet

            'Entidad.Orden = New ETOrden
            'With Entidad.Orden
            '    .CodEnlace = CodEnlace
            '    .CodProducto = Txt1.Text.Trim
            '    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
            '    .Usuario = User_Sistema
            '    .Spid = Spid
            '    .FechaInicio = FechaInicio
            '    .FechaTerminacion = FechaTermino
            '    .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
            '    .TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("ProduccionPlanta").ToString)
            '    .Descripcion = DsProduccion.Tables(0).Rows(i).Item("Molino").ToString.Trim
            '    .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
            '    .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
            'End With
            'Negocio.CosteoProduccion = New NGCosteoProduccion
            'dsManoObra = Negocio.CosteoProduccion.Consultar_Produccion_ManoObra_Cierre(Entidad.Orden)

            Pinta_Mano_de_Obra(dsManoObra, i, Fila, "A")
            Pinta_Mano_de_Obra(dsManoObra, i, Fila, "P")
            Pinta_Mano_de_Obra(dsManoObra, i, Fila, "L")

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo el Costeo del Mantto. Mec. del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsManttoMec As DataSet
            Entidad.Orden = New ETOrden
            With (Entidad.Orden)
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .TotalMolino = Val(DsProduccion.Tables(0).Rows(i).Item("TonUniProd").ToString)
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("ProduccionPlanta").ToString)
                .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsManttoMec = Negocio.CosteoProduccion.Consultar_Produccion_Mantto_Mecanico_Cierre(Entidad.Orden)

            TotalCostoManttoMecanico = 0
            If dsManttoMec.Tables(0).Rows.Count > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Mantto. Mec. del Molino"
                lblDetalle.Text = ""

                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE MANTENIMIENTO MECÁNICO"
                Call CombinarCeldas("B" & CStr(Fila) & ":M" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 10)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 7) = "Mensual"
                Call CombinarCeldas("G" & CStr(Fila) & ":M" & CStr(Fila), Alineacion.Centrado)

                Call FormatoCelda("G" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2) = "Tipo.Und.Prod"
                Obj_Hoja.Cells(Fila, 3) = "Código"
                Obj_Hoja.Cells(Fila, 4) = "Und. Prod."
                Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 7) = "M de Obra"
                Obj_Hoja.Cells(Fila, 8) = "Materiales"
                Obj_Hoja.Cells(Fila, 9) = "Total Mantto"
                Obj_Hoja.Cells(Fila, 10) = "Producción"
                Obj_Hoja.Cells(Fila, 11) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 12) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 13) = "SubTotal(S/.)"
                FilaRuma = Fila
                Call FormatoCelda("B" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1)

                For r = 0 To dsManttoMec.Tables(0).Rows.Count - 1
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = dsManttoMec.Tables(0).Rows(r).Item("TipoUnidad").ToString.Trim
                    Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
                    Obj_Hoja.Cells(Fila, 3) = dsManttoMec.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                    Obj_Hoja.Cells(Fila, 4) = dsManttoMec.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                    Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)

                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = Val(dsManttoMec.Tables(0).Rows(r).Item("CostoManObra").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = Val(dsManttoMec.Tables(0).Rows(r).Item("CostoMantto").ToString.Trim) - Val(dsManttoMec.Tables(0).Rows(r).Item("CostoManObra").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = Val(dsManttoMec.Tables(0).Rows(r).Item("CostoMantto").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = Val(dsManttoMec.Tables(0).Rows(r).Item("Tonelaje").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 11) = Val(dsManttoMec.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 12) = Val(dsManttoMec.Tables(0).Rows(r).Item("CostoxTon").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 13) = Val(dsManttoMec.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)

                    Call FormatoCelda("B" & CStr(Fila) & ":M" & CStr(Fila), "Arial", False, 8, , 1)

                    TotalCostoManttoMecanico = TotalCostoManttoMecanico + Val(dsManttoMec.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    TotalCostoManttoMecanicoAcum = TotalCostoManttoMecanicoAcum + Val(dsManttoMec.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                Next

                Fila = Fila + 1

                Obj_Hoja.Cells(Fila, 9) = "Costo Total:"
                Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 10) = TotalCostoManttoMecanico

                Call CombinarCeldas("J" & CStr(Fila) & ":M" & CStr(Fila), Alineacion.Derecha)
                Call FormatoCelda("I" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1)

            End If

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo el Costeo de la Energía del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsEnergia As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .NroHoras = Val(DsProduccion.Tables(0).Rows(i).Item("Horas").ToString)
                .HorasTrabajadas = Val(DsProduccion.Tables(0).Rows(i).Item("HorasTrab").ToString)
                .TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("ProduccionPlanta").ToString)
                .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")

            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsEnergia = Negocio.CosteoProduccion.Consultar_Produccion_Energia_Cierre(Entidad.Orden)

            TotalCostoEnergia = 0
            If dsEnergia.Tables(0).Rows.Count > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Energía del Molino"
                lblDetalle.Text = ""

                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE ENERGIA"
                Call CombinarCeldas("B" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 10)
                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 8) = "Mensual"
                Call CombinarCeldas("H" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("H" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2) = "Referencia"
                Call CombinarCeldas("B" & CStr(Fila) & ":D" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 5) = "Código"
                Obj_Hoja.Cells(Fila, 6) = "Molino"
                Call CombinarCeldas("F" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 8) = "Energía (KWH)"
                Obj_Hoja.Cells(Fila, 9) = "Total Horas"
                Obj_Hoja.Cells(Fila, 10) = "Horas"
                Obj_Hoja.Cells(Fila, 11) = "Costo KWH"
                Obj_Hoja.Cells(Fila, 12) = "Consumo (KWH)"
                Obj_Hoja.Cells(Fila, 13) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 14) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 15) = "SubTotal(S/.)"
                Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)

                FilaRuma = Fila

                For r = 0 To dsEnergia.Tables(0).Rows.Count - 1
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = dsEnergia.Tables(0).Rows(r).Item("TipoUnidad").ToString.Trim
                    Call CombinarCeldas("B" & CStr(Fila) & ":D" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 5).NumberFormat = "@"
                    Obj_Hoja.Cells(Fila, 5) = dsEnergia.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                    Obj_Hoja.Cells(Fila, 6) = dsEnergia.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                    Call CombinarCeldas("F" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = Val(dsEnergia.Tables(0).Rows(r).Item("EnergiaTotal").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = Val(dsEnergia.Tables(0).Rows(r).Item("Horas_Und").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = Val(dsEnergia.Tables(0).Rows(r).Item("Horas").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 11) = Val(dsEnergia.Tables(0).Rows(r).Item("CostoKwxHora").ToString.Trim)

                    Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 12) = Val(dsEnergia.Tables(0).Rows(r).Item("Energia").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 13) = Val(dsEnergia.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 14) = Val(dsEnergia.Tables(0).Rows(r).Item("CostoxTon").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 15) = Val(dsEnergia.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)

                    Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", False, 8, , 1)

                    TotalCostoEnergia = TotalCostoEnergia + Val(dsEnergia.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    TotalCostoEnergiaAcum = TotalCostoEnergiaAcum + Val(dsEnergia.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                Next

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 13) = "Costo Total:"
                Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 14) = TotalCostoEnergia

                Call CombinarCeldas("N" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("M" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)

            End If

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo el Costeo de la Depreciación del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsDeprec As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .TotalMolino = Val(DsProduccion.Tables(0).Rows(i).Item("TonUniProd").ToString)
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("ProduccionPlanta").ToString)
                .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsDeprec = Negocio.CosteoProduccion.Consultar_Produccion_Depreciacion_Cierre(Entidad.Orden)

            TotalCostoDepreciacion = 0
            If dsDeprec.Tables(0).Rows.Count > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Depreciación del Molino"
                lblDetalle.Text = ""

                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE DEPRECIACIÓN"
                Call CombinarCeldas("B" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 10)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 7) = "Mensual"
                Call CombinarCeldas("G" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("G" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2) = "Tipo Und. Prod."
                Obj_Hoja.Cells(Fila, 3) = "Código"
                Obj_Hoja.Cells(Fila, 4) = "Und. Prod."
                Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 7) = "Costo Deprec."
                Obj_Hoja.Cells(Fila, 8) = "Producción"
                Obj_Hoja.Cells(Fila, 9) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 10) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 11) = "SubTotal(S/.)"
                Obj_Hoja.Cells(Fila, 11) = "SubTotal(S/.)"
                FilaRuma = Fila
                Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)

                For r = 0 To dsDeprec.Tables(0).Rows.Count - 1
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = dsDeprec.Tables(0).Rows(r).Item("TipoUnidad").ToString.Trim
                    Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
                    Obj_Hoja.Cells(Fila, 3) = dsDeprec.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                    Obj_Hoja.Cells(Fila, 4) = dsDeprec.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                    Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = Val(dsDeprec.Tables(0).Rows(r).Item("CostoDeprec").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = Val(dsDeprec.Tables(0).Rows(r).Item("Tonelaje").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = Val(dsDeprec.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = Val(dsDeprec.Tables(0).Rows(r).Item("CostoxTon").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 11) = Val(dsDeprec.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1)
                    TotalCostoDepreciacion = TotalCostoDepreciacion + Val(dsDeprec.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    TotalCostoDepreciacionAcum = TotalCostoDepreciacionAcum + Val(dsDeprec.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                Next

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 9) = "Costo Total:"
                Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 10) = TotalCostoDepreciacion

                Call CombinarCeldas("J" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Derecha)
                Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)
            End If


            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo el Costeo del Gas Natural del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsGasNat As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("ProduccionPlanta").ToString)
                .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsGasNat = Negocio.CosteoProduccion.Consultar_Produccion_GasNatural_Cierre(Entidad.Orden)

            TotalCostoGasNatural = 0
            If dsGasNat.Tables(0).Rows.Count > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Gas Natural del Molino"
                lblDetalle.Text = ""

                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE GAS NATURAL"
                Call CombinarCeldas("B" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 10)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 7) = "Mensual"
                Call CombinarCeldas("G" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("G" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2) = "Referencia"
                Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 4) = "Código"
                Obj_Hoja.Cells(Fila, 5) = "Und. Prod."
                Call CombinarCeldas("E" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 7) = "Gas m3 std"
                Obj_Hoja.Cells(Fila, 8) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 9) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 10) = "SubTotal(S/.)"
                Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)

                FilaRuma = Fila

                For r = 0 To dsGasNat.Tables(0).Rows.Count - 1
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = dsGasNat.Tables(0).Rows(r).Item("TipoUnidad").ToString.Trim
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 4).NumberFormat = "@"
                    Obj_Hoja.Cells(Fila, 4) = dsGasNat.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                    Obj_Hoja.Cells(Fila, 5) = dsGasNat.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                    Call CombinarCeldas("E" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = Val(dsGasNat.Tables(0).Rows(r).Item("GasNatural").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = Val(dsGasNat.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = Val(dsGasNat.Tables(0).Rows(r).Item("CostoxTon").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = Val(dsGasNat.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", False, 8, , 1)
                    TotalCostoGasNatural = TotalCostoGasNatural + Val(dsGasNat.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    TotalCostoGasNaturalAcum = TotalCostoGasNaturalAcum + Val(dsGasNat.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                Next

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 8) = "Costo Total:"
                Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 9) = TotalCostoGasNatural

                Call CombinarCeldas("I" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("H" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
            End If

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo el Costeo del Envase de la Producción del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsEnvases As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
                .Peso = Val(DsProduccion.Tables(0).Rows(i).Item("Peso").ToString())
                .UnidPeso = Trim(DsProduccion.Tables(0).Rows(i).Item("UndPeso").ToString())
                .UnidProd = Trim(DsProduccion.Tables(0).Rows(i).Item("UndProd").ToString())
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsEnvases = Negocio.CosteoProduccion.Consultar_Produccion_Envases_Cierre(Entidad.Orden)

            TotalCostoEnvases = 0
            If dsEnvases.Tables(0).Rows.Count > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Envase de la Producción del Molino"
                lblDetalle.Text = ""

                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE ENVASES"
                Call CombinarCeldas("B" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 10)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 6) = "Mensual"
                Call CombinarCeldas("F" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("F" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2) = "Código"
                Obj_Hoja.Cells(Fila, 3) = "Envase"
                Call CombinarCeldas("C" & CStr(Fila) & ":E" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 6) = "Cantidad"
                Obj_Hoja.Cells(Fila, 7) = "Costo x Und"
                Obj_Hoja.Cells(Fila, 8) = "SubTotal(S/.)"
                FilaRuma = Fila
                Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)

                For r = 0 To dsEnvases.Tables(0).Rows.Count - 1
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2).NumberFormat = "@"
                    Obj_Hoja.Cells(Fila, 2) = dsEnvases.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                    Obj_Hoja.Cells(Fila, 3) = dsEnvases.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                    Call CombinarCeldas("C" & CStr(Fila) & ":E" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 6) = Val(dsEnvases.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = Val(dsEnvases.Tables(0).Rows(r).Item("CostoUnitario").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = Val(dsEnvases.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)

                    Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", False, 8, , 1)

                    TotalCostoEnvases = TotalCostoEnvases + Val(dsEnvases.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    TotalCostoEnvasesAcum = TotalCostoEnvasesAcum + Val(dsEnvases.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                Next

            End If


            For icble As Integer = 2 To 3
                CostoTipoCostoCble = 0
                If icble = 1 Then
                    TipoCostoCble = "Mantenimiento y Reparación de Maquinaria Pesada"
                    CodTipoCostoCble = "MP"
                    TotalCostoMantenimientoMaqPesada = 0
                    DesCostoCble = "Costo Mantto. MP"
                ElseIf icble = 2 Then
                    TipoCostoCble = "Sobrecostos Laborales Empleados"
                    CodTipoCostoCble = "SE"
                    TotalCostoSobrecostosEmpleados = 0
                    DesCostoCble = "Costo Empleados"
                ElseIf icble = 3 Then
                    TipoCostoCble = "Sobrecostos Laborales Obreros"
                    CodTipoCostoCble = "SO"
                    TotalCostoSobrecostosObreros = 0
                    DesCostoCble = "Costo Obreros"
                End If
                lblEstado.Text = "Exportando " + TipoCostoCble + ": " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Obteniendo el Costeo del " + TipoCostoCble + " del Molino"

                lblDetalle.Text = ""
                Application.DoEvents()

                Dim dsManttoMP As DataSet
                Entidad.Orden = New ETOrden
                With (Entidad.Orden)
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.Trim
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Anho = FechaTermino.Year
                    .Mes = FechaTermino.Month
                    .Tipo_Doc = CodTipoCostoCble
                    Negocio.CosteoProduccion = New NGCosteoProduccion
                    dsManttoMP = Negocio.CosteoProduccion.Consultar_Produccion_Contable_Cierre(Entidad.Orden)

                End With


                If dsManttoMP.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo del " + TipoCostoCble + " del Molino"
                    lblDetalle.Text = ""

                    Fila = Fila + 3
                    Obj_Hoja.Cells(Fila, 2) = "COSTEO DE " + TipoCostoCble.ToUpper
                    Call CombinarCeldas("B" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 10)

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 7) = "Mensual"
                    Call CombinarCeldas("G" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)

                    Call FormatoCelda("G" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Tipo.Und.Prod"
                    Obj_Hoja.Cells(Fila, 3) = "Código"
                    Obj_Hoja.Cells(Fila, 4) = "Und. Prod."
                    Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 7) = DesCostoCble
                    Obj_Hoja.Cells(Fila, 8) = "Producción"
                    Obj_Hoja.Cells(Fila, 9) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 10) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 11) = "SubTotal(S/.)"
                    FilaRuma = Fila
                    Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)

                    For r = 0 To dsManttoMP.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsManttoMP.Tables(0).Rows(r).Item("TipoUnidad").ToString.Trim
                        Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 3) = dsManttoMP.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                        Obj_Hoja.Cells(Fila, 4) = dsManttoMP.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                        Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsManttoMP.Tables(0).Rows(r).Item("CostoContable").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsManttoMP.Tables(0).Rows(r).Item("Tonelaje").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsManttoMP.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsManttoMP.Tables(0).Rows(r).Item("CostoxTon").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)

                        Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1)

                        If icble = 1 Then
                            TipoCostoCble = "Mantenimiento y Reparación de Maquinaria Pesada"
                            CodTipoCostoCble = "MP"
                            TotalCostoMantenimientoMaqPesada = TotalCostoMantenimientoMaqPesada + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                            TotalCostoMantenimientoMaqPesadaAcum = TotalCostoMantenimientoMaqPesadaAcum + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                            DesCostoCble = "Costo Mantto. MP"
                        ElseIf icble = 2 Then
                            TipoCostoCble = "Sobrecostos Laborales Empleados"
                            CodTipoCostoCble = "SE"
                            TotalCostoSobrecostosEmpleados = TotalCostoSobrecostosEmpleados + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                            TotalCostoSobrecostosEmpleadosAcum = TotalCostoSobrecostosEmpleadosAcum + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)

                            DesCostoCble = "Costo Empleados"
                        ElseIf icble = 3 Then
                            TipoCostoCble = "Sobrecostos Laborales Obreros"
                            CodTipoCostoCble = "SO"
                            TotalCostoSobrecostosObreros = TotalCostoSobrecostosObreros + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                            TotalCostoSobrecostosObrerosAcum = TotalCostoSobrecostosObrerosAcum + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                            DesCostoCble = "Costo Obreros"
                        End If
                        CostoTipoCostoCble = CostoTipoCostoCble + Val(dsManttoMP.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    Next


                    For r = 0 To dsManttoMP.Tables(1).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 3) = dsManttoMP.Tables(1).Rows(r).Item("Naturaleza").ToString.Trim
                        Obj_Hoja.Cells(Fila, 4) = dsManttoMP.Tables(1).Rows(r).Item("Descripcion").ToString.Trim
                        Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsManttoMP.Tables(1).Rows(r).Item("Importe").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1)
                    Next
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 9) = "Costo Total:"
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = CostoTipoCostoCble

                    Call CombinarCeldas("J" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Derecha)
                    Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)

                End If
                Fila = Fila + 1
            Next


            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Exportando el Resumen del Costeo del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()


            Fila = Fila + 2

            Obj_Hoja.Cells(Fila, 2) = "RESUMEN"
            Call CombinarCeldas("B" & CStr(Fila) & ":I" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 10)

            Fila = Fila + 2
            Obj_Hoja.Cells(Fila, 8) = "Mensual"
            Call CombinarCeldas("H" & CStr(Fila) & ":I" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("H" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "Descripción"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
            Obj_Hoja.Cells(Fila, 8) = "Costo x TON"
            Obj_Hoja.Cells(Fila, 9) = "Valor"
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "CANTIDAD PRODUCIDA (TON)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
            FilaRuma = Fila

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .TotalMolino = TotalProdMolino
                .Concepto = "01"
                .Descripcion = "CANTIDAD PRODUCIDA (TON)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA RUMA Y/O PROD. TERMINADO Y/O SUMINISTRO(S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoRuma
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = TotalCostoRuma
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = TotalCostoRuma / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = TotalCostoRumaAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = TotalCostoRumaAcum / TotalProdMolino
                End If

                .Concepto = "02"
                .Descripcion = "COSTO DE LA RUMA Y/O PROD. TERMINADO Y/O SUMINISTRO(S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)


            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE HOMOGENIZACIÓN DE SILICE (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoSiliceHomog
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = TotalCostoSiliceHomog
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = TotalCostoSiliceHomog / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = TotalCostoSiliceHomogAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = TotalCostoSiliceHomogAcum / TotalProdMolino
                End If
                .Concepto = "03"
                .Descripcion = "COSTO DE HOMOGENIZACIÓN DE SILICE (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA CHANCADORA (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoChancadora
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = TotalCostoChancadora
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = TotalCostoChancadora / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = TotalCostoChancadoraAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = TotalCostoChancadoraAcum / TotalProdMolino
                End If
                .Concepto = "04"
                .Descripcion = "COSTO DE LA CHANCADORA (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DEL CARGADOR FRONTAL (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoPala
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = TotalCostoPala
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = TotalCostoPala / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = TotalCostoPalaAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = TotalCostoPalaAcum / TotalProdMolino
                End If
                .Concepto = "05"
                .Descripcion = "COSTO DEL CARGADOR FRONTAL (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA MANO DE OBRA (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalManoObra
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = TotalManoObra
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = TotalManoObra / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = TotalManoObraAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = TotalManoObraAcum / TotalProdMolino
                End If
                .Concepto = "06"
                .Descripcion = "COSTO DE LA MANO DE OBRA (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DEL MANTENIMIENTO MECÁNICO (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoManttoMecanico
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = TotalCostoManttoMecanico
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = TotalCostoManttoMecanico / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = TotalCostoManttoMecanicoAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = TotalCostoManttoMecanicoAcum / TotalProdMolino
                End If
                .Concepto = "07"
                .Descripcion = "COSTO DEL MANTENIMIENTO MECÁNICO (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA DEPRECIACIÓN (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoDepreciacion
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = TotalCostoDepreciacion
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = TotalCostoDepreciacion / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = TotalCostoDepreciacionAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = TotalCostoDepreciacionAcum / TotalProdMolino
                End If
                .Concepto = "08"
                .Descripcion = "COSTO DE LA DEPRECIACIÓN (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA ENERGÍA (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoEnergia
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = TotalCostoEnergia
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = TotalCostoEnergia / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = TotalCostoEnergiaAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = TotalCostoEnergiaAcum / TotalProdMolino
                End If
                .Concepto = "09"
                .Descripcion = "COSTO DE LA ENERGÍA (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Fila = Fila + 1

            Obj_Hoja.Cells(Fila, 2) = "COSTO DEL GAS NATURAL (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoGasNatural
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = TotalCostoGasNatural
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = TotalCostoGasNatural / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = TotalCostoGasNaturalAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = TotalCostoGasNaturalAcum / TotalProdMolino
                End If
                .Concepto = "10"
                .Descripcion = "COSTO DEL GAS NATURAL (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Fila = Fila + 1

            Obj_Hoja.Cells(Fila, 2) = "COSTO DEL ENVASE (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoEnvases
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = TotalCostoEnvases
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = TotalCostoEnvases / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = TotalCostoEnvasesAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = TotalCostoEnvasesAcum / TotalProdMolino
                End If
                .Concepto = "11"
                .Descripcion = "COSTO DEL ENVASE (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Fila = Fila + 1

            Obj_Hoja.Cells(Fila, 2) = "COSTO DE MANTENIMIENTO Y REPARACION DE MAQUINARIA PESADA (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoMantenimientoMaqPesada
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = TotalCostoMantenimientoMaqPesada
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = TotalCostoMantenimientoMaqPesada / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = TotalCostoMantenimientoMaqPesadaAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = TotalCostoMantenimientoMaqPesadaAcum / TotalProdMolino
                End If
                .Concepto = "14"
                .Descripcion = "COSTO DE MANTENIMIENTO Y REPARACION DE MAQUINARIA PESADA (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Fila = Fila + 1

            Obj_Hoja.Cells(Fila, 2) = "SOBRECOSTOS LABORALES EMPLEADOS (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoSobrecostosEmpleados
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = TotalCostoSobrecostosEmpleados
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = TotalCostoSobrecostosEmpleados / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = TotalCostoSobrecostosEmpleadosAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = TotalCostoSobrecostosEmpleadosAcum / TotalProdMolino
                End If
                .Concepto = "15"
                .Descripcion = "SOBRECOSTOS LABORALES EMPLEADOS (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Fila = Fila + 1

            Obj_Hoja.Cells(Fila, 2) = "SOBRECOSTOS LABORALES OBREROS (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoSobrecostosObreros
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = TotalCostoSobrecostosObreros
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = TotalCostoSobrecostosObreros / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = TotalCostoSobrecostosObrerosAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = TotalCostoSobrecostosObrerosAcum / TotalProdMolino
                End If
                .Concepto = "16"
                .Descripcion = "SOBRECOSTOS LABORALES OBREROS (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO X MOLINO (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            CostoxMolino = TotalCostoRuma + TotalCostoSiliceHomog + TotalCostoChancadora + TotalCostoPala
            CostoxMolino = CostoxMolino + TotalManoObra + TotalCostoManttoMecanico
            CostoxMolino = CostoxMolino + TotalCostoDepreciacion + TotalCostoEnergia
            CostoxMolino = CostoxMolino + TotalCostoGasNatural + TotalCostoEnvases
            CostoxMolino = CostoxMolino + TotalCostoMantenimientoMaqPesada + TotalCostoSobrecostosEmpleados
            CostoxMolino = CostoxMolino + TotalCostoSobrecostosObreros

            CostoxMolinoAcum = TotalCostoRumaAcum + TotalCostoSiliceHomogAcum + TotalCostoChancadoraAcum + TotalCostoPalaAcum
            CostoxMolinoAcum = CostoxMolinoAcum + TotalManoObraAcum + TotalCostoManttoMecanicoAcum
            CostoxMolinoAcum = CostoxMolinoAcum + TotalCostoDepreciacionAcum + TotalCostoEnergiaAcum
            CostoxMolinoAcum = CostoxMolinoAcum + TotalCostoGasNaturalAcum + TotalCostoEnvasesAcum
            CostoxMolinoAcum = CostoxMolinoAcum + TotalCostoMantenimientoMaqPesadaAcum
            CostoxMolinoAcum = CostoxMolinoAcum + TotalCostoSobrecostosEmpleadosAcum + TotalCostoSobrecostosObrerosAcum

            Obj_Hoja.Cells(Fila, 9) = CostoxMolino
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .ValorxDecimal = CostoxMolino
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .CostoxTON = 0
                Else
                    .CostoxTON = CostoxMolino / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                .TotalMolino = CostoxMolinoAcum
                If TotalProdMolino > 0 Then
                    .CostoxTONAcum = CostoxMolinoAcum / TotalProdMolino
                End If
                .Concepto = "12"
                .Descripcion = "COSTO X MOLINO (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)


            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO X TON"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = CostoxMolino / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)

            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                If Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString) = 0 Then
                    .ValorxDecimal = 0
                Else
                    .ValorxDecimal = CostoxMolino / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                End If

                If TotalProdMolino > 0 Then
                    .TotalMolino = CostoxMolinoAcum / TotalProdMolino
                End If

                .Concepto = "13"
                .Descripcion = "COSTO X MOLINO (S/.)"
            End With
            Ls_CosteoMolino.Add(Entidad.Orden)

            Resumen_Ruma = Resumen_Ruma + TotalCostoRuma
            Resumen_SiliceHomogenizada = Resumen_SiliceHomogenizada + TotalCostoSiliceHomog
            Resumen_Chancadora = Resumen_Chancadora + TotalCostoChancadora
            Resumen_Cargador_Frontal = Resumen_Cargador_Frontal + TotalCostoPala
            Resumen_ManoObra = Resumen_ManoObra + TotalManoObra
            Resumen_ManttoMecanico = Resumen_ManttoMecanico + TotalCostoManttoMecanico
            Resumen_Depreciacion = Resumen_Depreciacion + TotalCostoDepreciacion
            Resumen_Energia = Resumen_Energia + TotalCostoEnergia
            Resumen_GasNatural = Resumen_GasNatural + TotalCostoGasNatural
            Resumen_Envases = Resumen_Envases + TotalCostoEnvases
            Resumen_ManttoReparacioMP = Resumen_ManttoReparacioMP + TotalCostoMantenimientoMaqPesada
            Resumen_SobrecostoEmpleado = Resumen_SobrecostoEmpleado + TotalCostoSobrecostosEmpleados
            Resumen_SobrecostoObrero = Resumen_SobrecostoObrero + TotalCostoSobrecostosObreros

            Resumen_Ruma_Acum = Resumen_Ruma_Acum + TotalCostoRumaAcum
            Resumen_SiliceHomogenizada_Acum = Resumen_SiliceHomogenizada_Acum + TotalCostoSiliceHomogAcum
            Resumen_Chancadora_Acum = Resumen_Chancadora_Acum + TotalCostoChancadoraAcum
            Resumen_Cargador_Frontal_Acum = Resumen_Cargador_Frontal_Acum + TotalCostoPalaAcum
            Resumen_ManoObra_Acum = Resumen_ManoObra_Acum + TotalManoObraAcum
            Resumen_ManttoMecanico_Acum = Resumen_ManttoMecanico_Acum + TotalCostoManttoMecanicoAcum
            Resumen_Depreciacion_Acum = Resumen_Depreciacion_Acum + TotalCostoDepreciacionAcum
            Resumen_Energia_Acum = Resumen_Energia_Acum + TotalCostoEnergiaAcum
            Resumen_GasNatural_Acum = Resumen_GasNatural_Acum + TotalCostoGasNaturalAcum
            Resumen_Envases_Acum = Resumen_Envases_Acum + TotalCostoEnvasesAcum
            Resumen_ProduccionProducto = Resumen_ProduccionProducto + TotalProdMolino

            Resumen_ManttoReparacioMP_Acum = Resumen_ManttoReparacioMP_Acum + TotalCostoMantenimientoMaqPesadaAcum
            Resumen_SobrecostoEmpleado_Acum = Resumen_SobrecostoEmpleado_Acum + TotalCostoSobrecostosEmpleadosAcum
            Resumen_SobrecostoObrero_Acum = Resumen_SobrecostoObrero_Acum + TotalCostoSobrecostosObrerosAcum

        Next
    End Sub
    Private Sub Pinta_Mano_de_Obra(ByVal dsManoObra As DataSet, ByVal i As Integer, ByVal FilaRuma As Integer, ByVal lTipo As String)

        If dsManoObra.Tables(0).Rows.Count > 0 Then
            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Exportando el Costeo de la Mano de Obra del Molino"
            lblDetalle.Text = ""


            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obtener el Costeo de la Mano de Obra del Producto"
            lblDetalle.Text = ""

            Fila = Fila + 2
            If lTipo = "R" Then
                Obj_Hoja.Cells(Fila, 2) = "ACARREO"
            Else
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE MANO DE OBRA "
            End If

            Call CombinarCeldas("B" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 10)


            Dim TipoMO As String = String.Empty
            Dim TotalMOTipo As Double = 0
            Dim TotalMOTipoAcum As Double = 0
            For r = 0 To dsManoObra.Tables(0).Rows.Count - 1
                If dsManoObra.Tables(0).Rows(r).Item("Tipo").ToString.Trim = lTipo Then
                    If TipoMO <> dsManoObra.Tables(0).Rows(r).Item("Tipo").ToString.Trim Then
                        If r > 0 Then
                            '    Fila = Fila + 1
                            '    If TipoMO = "A" And lTipo <> "R" Then
                            '        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                            '        Obj_Hoja.Cells(Fila, 10) = "=sum(J" & CStr(FilaRuma + 1) & ":J" & CStr(Fila - 1) & ")"
                            '        Call FormatoCelda("J" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                            '    End If
                            '    If Not (lTipo = "R" And Fila <= 12) Then
                            '        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                            '        Obj_Hoja.Cells(Fila, 12) = "=sum(L" & CStr(FilaRuma + 1) & ":L" & CStr(Fila - 1) & ")"
                            '        Call FormatoCelda("L" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                            '    End If
                            '    'Call CombinarCeldas("P" & CStr(Fila) & ":Q" & CStr(Fila), Alineacion.Centrado)
                            '    TotalMOTipo = 0
                            '    TotalMOTipoAcum = 0
                        End If

                        Fila = Fila + 2
                        TipoMO = dsManoObra.Tables(0).Rows(r).Item("Tipo").ToString.Trim
                        Select Case TipoMO
                            Case "A"
                                Obj_Hoja.Cells(Fila, 4) = "MOLIENDA (OBREROS)"
                            Case "B"
                                Obj_Hoja.Cells(Fila, 4) = "PERSONAL DE PLANTA DE CEMENTO"
                            Case "R"
                                Obj_Hoja.Cells(Fila, 4) = "DISTRIBUCIÓN PORCENTUAL DEL COSTO DEL PERSONAL (ACARREO) ENTRE LAS PLANTAS"
                            Case "P"
                                Obj_Hoja.Cells(Fila, 4) = "DISTRIBUCIÓN PORCENTUAL DEL COSTO DEL PERSONAL (PLANTA) ENTRE LAS PLANTAS"
                            Case "L"
                                Obj_Hoja.Cells(Fila, 4) = "DISTRIBUCIÓN PORCENTUAL DEL COSTO DEL PERSONAL (LABORATORIO) ENTRE LAS PLANTAS"
                            Case Else
                                Obj_Hoja.Cells(Fila, 4) = "OTROS"
                        End Select
                        Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 10)
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 8) = "Mensual"
                        Call CombinarCeldas("H" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)


                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = "Cod.Und.Prod."
                        Obj_Hoja.Cells(Fila, 3) = "Und. Prod."
                        Obj_Hoja.Cells(Fila, 4) = "Código"
                        Obj_Hoja.Cells(Fila, 5) = "Personal"
                        Call CombinarCeldas("E" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
                        Obj_Hoja.Cells(Fila, 8) = "Porcentaje"
                        Obj_Hoja.Cells(Fila, 9) = "Total Prod."
                        Obj_Hoja.Cells(Fila, 10) = "Cant. TON"
                        Obj_Hoja.Cells(Fila, 11) = "Costo x TON"
                        Obj_Hoja.Cells(Fila, 12) = "SubTotal(S/.)"
                        FilaRuma = Fila
                        Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                    End If

                    'If Not (TipoMO.TrimEnd = "C" And Chk1.Checked = False) Then
                    'If Not ((TipoMO.TrimEnd = "P" Or TipoMO.TrimEnd = "R" Or TipoMO.TrimEnd = "L") And Chk1.Checked = False) Then
                    If Not ((TipoMO.TrimEnd = "P" Or TipoMO.TrimEnd = "L") And Chk1.Checked = False) Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 2) = dsManoObra.Tables(0).Rows(r).Item("Placa").ToString.Trim
                        Obj_Hoja.Cells(Fila, 3) = dsManoObra.Tables(0).Rows(r).Item("UnidadProd").ToString.Trim
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 4) = dsManoObra.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                        Obj_Hoja.Cells(Fila, 5) = dsManoObra.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                        Call CombinarCeldas("E" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsManoObra.Tables(0).Rows(r).Item("Porcentaje").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsManoObra.Tables(0).Rows(r).Item("TonMaximo").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsManoObra.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsManoObra.Tables(0).Rows(r).Item("CostoxTON").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsManoObra.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", False, 8, , 1)
                    End If
                    TotalManoObra = TotalManoObra + Val(dsManoObra.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    TotalMOTipo = TotalMOTipo + Val(dsManoObra.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                End If
            Next


            Fila = Fila + 1
            If TipoMO = "C" And Chk1.Checked = False Then

                Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 12) = TotalMOTipo

                Call FormatoCelda("L" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                TotalMOTipo = 0
                TotalMOTipoAcum = 0
            Else
                Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 12) = "=sum(L" & CStr(FilaRuma + 1) & ":L" & CStr(Fila - 1) & ")"

                Call FormatoCelda("L" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                TotalMOTipo = 0
                TotalMOTipoAcum = 0
            End If

            'Fila = Fila + 2
            'Obj_Hoja.Cells(Fila, 11) = "Costo Total:"
            'Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
            'Obj_Hoja.Cells(Fila, 12) = TotalManoObra

            'Call CombinarCeldas("P" & CStr(Fila) & ":Q" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("K" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
        End If
    End Sub

    Private Sub PintarMolino()
        Dim i As Integer = 0
        Dim r As Integer = 0
        Dim cr As Integer = 0
        Dim sh As Integer = 0
        Dim c As Integer = 0
        Dim p As Integer = 0
        Dim mo As Integer = 0
        Dim Ruma As String = String.Empty
        Dim TipoEnlace As String = String.Empty
        Dim FilaRuma As Integer = 0
        Dim TotalRuma As Double = 0
        Dim CostoChandadora As Double = 0
        Dim CostoChandadora_MM As Double = 0
        Dim CostoChandadora_Energia As Double = 0
        Dim CostoChandadora_Deprec As Double = 0
        Dim CostoChandadora_TI As Double = 0
        Dim CostoChandadora_MO As Double = 0
        Dim CostoChandadora_Cantidad As Double = 0
        Dim Chancadora As String = String.Empty
        Dim Chancadora_Descrip As String = String.Empty
        Dim Chancadora_Produccion As Double = 0

        Dim Chancadora_Cantidad As Double = 0
        Dim Chancadora_Silice As Double = 0
        Dim Chancadora_SubTotal As Double = 0

        Dim Chanc_E_EnergiaTotal As Double = 0
        Dim Chanc_E_CostoKWH As Double = 0
        Dim Chanc_E_Referencia As String = String.Empty
        Dim Chanc_E_CostoEnergia As Double = 0
        Dim Chanc_MO As Double = 0
        Dim Chanc_MO_Pers As Double = 0
        Dim TI_Cantidad As Double = 0
        Dim TI_Silice As Double = 0
        Dim TI_Normal As Double = 0
        Dim TI_SubTotal As Double = 0
        Dim CantidadAcum As Double = 0
        Dim SubTotalAcum As Double = 0
        Dim CostoTotalAcum As Double = 0
        Dim TotalProdMolino As Double = 0

        Dim TotalCostoRuma As Double = 0
        Dim TotalCostoSiliceHomog As Double = 0
        Dim TotalCostoChancadora As Double = 0
        Dim TotalCostoPala As Double = 0
        Dim TotalManoObra As Double = 0
        Dim TotalCostoManttoMecanico As Double = 0
        Dim TotalCostoDepreciacion As Double = 0
        Dim TotalCostoEnergia As Double = 0
        Dim TotalCostoGasNatural As Double = 0
        Dim TotalCostoEnvases As Double = 0

        Dim TotalCostoRumaAcum As Double = 0
        Dim TotalCostoSiliceHomogAcum As Double = 0
        Dim TotalCostoChancadoraAcum As Double = 0
        Dim TotalCostoPalaAcum As Double = 0
        Dim TotalManoObraAcum As Double = 0
        Dim TotalCostoManttoMecanicoAcum As Double = 0
        Dim TotalCostoDepreciacionAcum As Double = 0
        Dim TotalCostoEnergiaAcum As Double = 0
        Dim TotalCostoGasNaturalAcum As Double = 0
        Dim TotalCostoEnvasesAcum As Double = 0


        Dim CostoxMolino As Double = 0
        Dim CostoxMolinoAcum As Double = 0

        Dim CantidadRuma As Double = 0
        Dim CostoUnitarioRuma As Double = 0
        Dim PintarCabecera As Boolean = False
        Dim SaltarReturn As Boolean = False
        Dim TONSiliceHomog As Double = 0


        For i = 0 To DsProduccion.Tables(0).Rows.Count - 1
            TotalCostoRumaAcum = 0
            TotalCostoSiliceHomogAcum = 0
            TotalCostoChancadoraAcum = 0
            TotalCostoPalaAcum = 0
            TotalCostoDepreciacionAcum = 0
            TotalCostoEnergiaAcum = 0
            TotalCostoEnvasesAcum = 0
            TotalCostoGasNaturalAcum = 0
            TotalCostoManttoMecanicoAcum = 0
            TotalManoObraAcum = 0


            Ruma = ""
            Obj_Hoja = Obj_Libro.Sheets(i + 2)
            Obj_Hoja.Activate()
            Obj_Libro.Sheets(i + 2).Name = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString

            Fila = 1
            Obj_Hoja.Cells(Fila, 2) = "Cía Minera Agregados Calcareos S.A."

            Fila = Fila + 2
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE PRODUCCION (S/.) POR  MOLINO - " & NameMes(Month(FechaInicio)) & " " & Year(FechaTermino)
            Call CombinarCeldas("B" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 14)

            Fila = Fila + 2
            Obj_Hoja.Cells(Fila, 2) = "Producto: "
            Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
            Obj_Hoja.Cells(Fila, 3) = Txt1.Text.Trim
            Obj_Hoja.Cells(Fila, 4) = Txt2.Text.Trim
            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "Molino: "
            Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
            Obj_Hoja.Cells(Fila, 3) = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
            Obj_Hoja.Cells(Fila, 4) = DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            Call FormatoCelda("B" & CStr(Fila) & ":B" & CStr(Fila + 2), "Arial", True, 8)
            Call FormatoCelda("C" & CStr(Fila) & ":L" & CStr(Fila + 2), "Arial", False, 8)

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            Application.DoEvents()
            lblCosteo.Text = ""
            lblDetalle.Text = ""

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "Produc.(TON):"
            Obj_Hoja.Cells(Fila, 3).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 3) = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
            Obj_Hoja.Cells(Fila, 7) = "Minerales Requeridos (TON):"
            Call CombinarCeldas("G" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = Val(DsProduccion.Tables(0).Rows(i).Item("TonConsumido").ToString)
            Call FormatoCelda("G" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "Prod x Molino:"
            Obj_Hoja.Cells(Fila, 3).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 3) = Val(DsProduccion.Tables(0).Rows(i).Item("TonUniProd").ToString)
            Obj_Hoja.Cells(Fila, 7) = "Hrs. Trab. x Molino:"
            Call CombinarCeldas("G" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("G" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = Val(DsProduccion.Tables(0).Rows(i).Item("HorasTrab").ToString)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 7) = "Silice Homogenizada (TON):"
            Call CombinarCeldas("G" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("G" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"

            TONSiliceHomog = 0
            If Val(DsProduccion.Tables(0).Rows(i).Item("TonSilicato").ToString) > 0 And Val(DsProduccion.Tables(0).Rows(i).Item("TonSilice").ToString) > 0 Then
                TONSiliceHomog = Val(DsProduccion.Tables(0).Rows(i).Item("TonSilicato").ToString) + Val(DsProduccion.Tables(0).Rows(i).Item("TonSilice").ToString)
            End If

            Obj_Hoja.Cells(Fila, 9) = TONSiliceHomog
            TotalProdMolino = 0
            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo Datos Mensuales"
            lblDetalle.Text = ""
            Application.DoEvents()
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                .FechaInicio = FechaInicioAño
                .FechaTerminacion = FechaTermino
                .Cod_Alm = "19"

            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            Negocio.CosteoProduccion.Consultar_Produccion_GenericoxMolino(Entidad.Orden)

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo Datos de Costeo RUMA Y/O PRODUCTOS Y/O SUMINISTROS"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsRuma As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsRuma = Negocio.CosteoProduccion.Consultar_Produccion_Ruma(Entidad.Orden)

            TotalCostoRuma = 0
            TotalCostoRumaAcum = 0
            CantidadRuma = 0
            CostoUnitarioRuma = 0
            TipoEnlace = String.Empty
            CantidadAcum = 0
            SubTotalAcum = 0
            CostoTotalAcum = 0
            If dsRuma.Tables(0).Rows.Count > 0 Then
                Fila = Fila + 2

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando Costeo RUMA Y/O PRODUCTOS Y/O SUMINISTROS"
                lblDetalle.Text = ""
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE RUMA Y/O PRODUCTO TERMINADO Y/O SUMINISTRO"
                Call CombinarCeldas("B" & CStr(Fila) & ":R" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 10)

                FilaRuma = 0
                TotalRuma = 0
                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 12) = "Mensual"
                Call CombinarCeldas("L" & CStr(Fila) & ":R" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 19) = "Acumulado"
                Call CombinarCeldas("S" & CStr(Fila) & ":U" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("L" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("S" & CStr(Fila) & ":U" & CStr(Fila), "Arial", True, 8, , 1, 19)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2) = "Tipo"
                Obj_Hoja.Cells(Fila, 3) = "Cod. Ruma"
                Obj_Hoja.Cells(Fila, 4) = "Ruma"
                Obj_Hoja.Cells(Fila, 5) = "Código"
                Obj_Hoja.Cells(Fila, 6) = "Descripción"
                Call CombinarCeldas("F" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 9) = "Normal TON"
                Obj_Hoja.Cells(Fila, 10) = "Humedad TON"
                Obj_Hoja.Cells(Fila, 11) = "Merma TON"
                Obj_Hoja.Cells(Fila, 12) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 13) = "Regalías"
                Obj_Hoja.Cells(Fila, 14) = "Extracción"
                Obj_Hoja.Cells(Fila, 15) = "Compras"
                Obj_Hoja.Cells(Fila, 16) = "Flete"
                Obj_Hoja.Cells(Fila, 17) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 18) = "SubTotal(S/.)"
                Obj_Hoja.Cells(Fila, 19) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 20) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 21) = "SubTotal(S/.)"
                'Call CombinarCeldas("B" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("S" & CStr(Fila) & ":U" & CStr(Fila), "Arial", True, 8, , 1, 19)
                FilaRuma = Fila

                For r = 0 To dsRuma.Tables(0).Rows.Count - 1
                    Fila = Fila + 1
                    TipoEnlace = dsRuma.Tables(0).Rows(r).Item("TipoEnlace").ToString.Trim
                    Obj_Hoja.Cells(Fila, 2) = TipoEnlace
                    If TipoEnlace = "RUMA" Then
                        Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 3) = dsRuma.Tables(0).Rows(r).Item("CodRuma").ToString.Trim
                        Obj_Hoja.Cells(Fila, 4) = dsRuma.Tables(0).Rows(r).Item("Ruma").ToString.Trim
                    End If
                    Obj_Hoja.Cells(Fila, 5).NumberFormat = "@"
                    Obj_Hoja.Cells(Fila, 5) = dsRuma.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                    Obj_Hoja.Cells(Fila, 6) = dsRuma.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                    Call CombinarCeldas("F" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = Val(dsRuma.Tables(0).Rows(r).Item("CantProd").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = Val(dsRuma.Tables(0).Rows(r).Item("CantHumedad").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 11) = Val(dsRuma.Tables(0).Rows(r).Item("CantMerma").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 12) = Val(dsRuma.Tables(0).Rows(r).Item("CantidadTON").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 13) = Val(dsRuma.Tables(0).Rows(r).Item("CostoxRegalias").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 14) = Val(dsRuma.Tables(0).Rows(r).Item("CostoxExtraccion").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 15) = Val(dsRuma.Tables(0).Rows(r).Item("CostoxCompra").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 16).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 16) = Val(dsRuma.Tables(0).Rows(r).Item("CostoxFlete").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 17).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 17) = Val(dsRuma.Tables(0).Rows(r).Item("CostoxTON").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 18).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 18) = Val(dsRuma.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 19).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 19) = Val(dsRuma.Tables(0).Rows(r).Item("CantAcum").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 20).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 20) = Val(dsRuma.Tables(0).Rows(r).Item("CostoxTonAcum").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 21).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 21) = Val(dsRuma.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)

                    TotalCostoRuma = TotalCostoRuma + Val(dsRuma.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    CantidadRuma = CantidadRuma + Val(dsRuma.Tables(0).Rows(r).Item("CantidadTON").ToString.Trim)
                    TotalRuma = TotalRuma + Val(dsRuma.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    SubTotalAcum = SubTotalAcum + Val(dsRuma.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                    CostoTotalAcum = CostoTotalAcum + Val(dsRuma.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                    CantidadAcum = CantidadAcum + Val(dsRuma.Tables(0).Rows(r).Item("CantAcum").ToString.Trim)
                    TotalCostoRumaAcum = TotalCostoRumaAcum + Val(dsRuma.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                    TotalProdMolino = TotalProdMolino + Val(dsRuma.Tables(0).Rows(r).Item("CantNormalAcum").ToString.Trim)
                    'Call CombinarCeldas("B" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("B" & CStr(Fila) & ":R" & CStr(Fila), "Arial", False, 8, , 1)
                    Call FormatoCelda("S" & CStr(Fila) & ":U" & CStr(Fila), "Arial", False, 8, , 1, 19)

                Next


                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 9) = "=SUM(I" & CStr(FilaRuma + 1) & ":I" & CStr(Fila - 1) & ")"

                Obj_Hoja.Cells(Fila, 10) = "Cant. Req. TON:"
                Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 11) = CantidadRuma
                Call CombinarCeldas("K" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)

                Obj_Hoja.Cells(Fila, 13) = "Costo x TON:"
                Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                If CantidadRuma <> 0 Then
                    Obj_Hoja.Cells(Fila, 14) = TotalCostoRuma / CantidadRuma
                Else
                    Obj_Hoja.Cells(Fila, 14) = 0
                End If

                Call CombinarCeldas("N" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)

                Obj_Hoja.Cells(Fila, 16) = "Costo Total:"
                Obj_Hoja.Cells(Fila, 17).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 17) = TotalCostoRuma
                Call CombinarCeldas("Q" & CStr(Fila) & ":R" & CStr(Fila), Alineacion.Centrado)


                Obj_Hoja.Cells(Fila, 19).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 19) = CantidadAcum

                Obj_Hoja.Cells(Fila, 20).NumberFormat = "#,##0.0000"
                If CantidadAcum = 0 Then
                    Obj_Hoja.Cells(Fila, 20) = 0
                Else
                    Obj_Hoja.Cells(Fila, 20) = CostoTotalAcum / CantidadAcum
                End If

                Obj_Hoja.Cells(Fila, 21).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 21) = CostoTotalAcum

                Call FormatoCelda("I" & CStr(Fila) & ":R" & CStr(Fila), "Arial", False, 8, , 1)
                Call FormatoCelda("I" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("K" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("N" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("Q" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("S" & CStr(Fila) & ":U" & CStr(Fila), "Arial", True, 8, , 1, 19)

            End If
            TotalCostoSiliceHomog = 0
            TotalCostoSiliceHomogAcum = 0

            If TONSiliceHomog > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Obteniendo Datos del Costo de Homogenización de Silice"
                lblDetalle.Text = ""
                Application.DoEvents()

                Dim dsSilice As DataSet
                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.Trim
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                    .Usuario = User_Sistema
                    .Spid = Spid
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsSilice = Negocio.CosteoProduccion.Consultar_Produccion_Silice(Entidad.Orden)
                If dsSilice.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo de la Homogenización de Silice"
                    lblDetalle.Text = ""
                    Application.DoEvents()
                    Fila = Fila + 2

                    Obj_Hoja.Cells(Fila, 2) = "COSTEO DE HOMOGENIZACIÓN DE SILICE"
                    Call CombinarCeldas("B" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 10)
                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 6) = "Mensual"
                    Call CombinarCeldas("F" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 9) = "Acumulado"
                    Call CombinarCeldas("I" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("F" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Código"
                    Obj_Hoja.Cells(Fila, 3) = "Descripción"
                    Call CombinarCeldas("C" & CStr(Fila) & ":E" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 6) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 7) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 8) = "SubTotal(S/.)"
                    Obj_Hoja.Cells(Fila, 9) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 10) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 11) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    FilaRuma = Fila

                    For sh = 0 To dsSilice.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 2) = dsSilice.Tables(0).Rows(sh).Item("Concepto").ToString.TrimEnd
                        Obj_Hoja.Cells(Fila, 3) = dsSilice.Tables(0).Rows(sh).Item("Descripcion").ToString.TrimEnd
                        Call CombinarCeldas("C" & CStr(Fila) & ":E" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = Val(dsSilice.Tables(0).Rows(sh).Item("Cantidad").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsSilice.Tables(0).Rows(sh).Item("CostoxTON").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsSilice.Tables(0).Rows(sh).Item("SubTotal").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsSilice.Tables(0).Rows(sh).Item("CantAcum").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsSilice.Tables(0).Rows(sh).Item("CostoxTONAcum").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsSilice.Tables(0).Rows(sh).Item("SubTotalAcum").ToString.TrimEnd)
                        TotalCostoSiliceHomog = TotalCostoSiliceHomog + Val(dsSilice.Tables(0).Rows(sh).Item("SubTotal").ToString.TrimEnd)
                        TotalCostoSiliceHomogAcum = TotalCostoSiliceHomogAcum + Val(dsSilice.Tables(0).Rows(sh).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", False, 8, , 1)
                        Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)
                    Next

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 6) = "=AVERAGE(F" & CStr(FilaRuma + 1) & ":F" & CStr(Fila - 1) & ")"
                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = "=H" & CStr(Fila) & "/F" & CStr(Fila)
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = "=SUM(H" & CStr(FilaRuma + 1) & ":H" & CStr(Fila - 1) & ")"
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = "=AVERAGE(I" & CStr(FilaRuma + 1) & ":I" & CStr(Fila - 1) & ")"
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/I" & CStr(Fila)
                    Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 11) = "=SUM(K" & CStr(FilaRuma + 1) & ":K" & CStr(Fila - 1) & ")"

                    Call FormatoCelda("F" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)
                End If

            End If

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo Datos del Costeo de la Chancadora"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsChancadora As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsChancadora = Negocio.CosteoProduccion.Consultar_Produccion_Chancadora(Entidad.Orden)

            TotalCostoChancadora = 0
            TotalCostoChancadoraAcum = 0

            If dsChancadora.Tables(0).Rows.Count > 0 Then

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                lblDetalle.Text = ""
                Application.DoEvents()
                Fila = Fila + 2

                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE CHANCADORA"
                Call CombinarCeldas("B" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 10)


                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                lblDetalle.Text = "Obteniendo el Transporte Interno de la Chancadora"
                Application.DoEvents()

                Dim dsChancTI As DataSet
                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.Trim
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                    .Usuario = User_Sistema
                    .Spid = Spid
                End With

                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsChancTI = Negocio.CosteoProduccion.Consultar_Produccion_Chancadora_TranspInt(Entidad.Orden)
                If dsChancTI.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                    lblDetalle.Text = "Exportando el Transporte Interno de la Chancadora"
                    Application.DoEvents()

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "TRANSPORTE INTERNO"
                    Call CombinarCeldas("D" & CStr(Fila) & ":M" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 5) = "Mensual"
                    Call CombinarCeldas("E" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 13) = "Acumulado"
                    Call CombinarCeldas("K" & CStr(Fila) & ":M" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("E" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("K" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Chancadora"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 4) = "Transporte"
                    Obj_Hoja.Cells(Fila, 5) = "TON Transp."
                    Obj_Hoja.Cells(Fila, 6) = "Costo Transp."
                    Obj_Hoja.Cells(Fila, 7) = "TON Chanc."
                    Obj_Hoja.Cells(Fila, 8) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 9) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 10) = "SubTotal(S/.)"
                    Obj_Hoja.Cells(Fila, 11) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 12) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 13) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("K" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    FilaRuma = Fila
                    For cr = 0 To dsChancTI.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsChancTI.Tables(0).Rows(cr).Item("Cod_Chancadora").ToString.TrimEnd + " - " + dsChancTI.Tables(0).Rows(cr).Item("Chancadora").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 4) = dsChancTI.Tables(0).Rows(cr).Item("Transporte").ToString.TrimEnd
                        Obj_Hoja.Cells(Fila, 5).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 5) = Val(dsChancTI.Tables(0).Rows(cr).Item("TotalTranspProduccion").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = Val(dsChancTI.Tables(0).Rows(cr).Item("CostoTransporte").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsChancTI.Tables(0).Rows(cr).Item("TotalChancProduccion").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsChancTI.Tables(0).Rows(cr).Item("Cantidad").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsChancTI.Tables(0).Rows(cr).Item("CostoxTON").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsChancTI.Tables(0).Rows(cr).Item("SubTotal").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsChancTI.Tables(0).Rows(cr).Item("CantAcum").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsChancTI.Tables(0).Rows(cr).Item("CostoxTONAcum").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsChancTI.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.TrimEnd)
                        TotalCostoChancadora = TotalCostoChancadora + Val(dsChancTI.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoChancadoraAcum = TotalCostoChancadoraAcum + Val(dsChancTI.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", False, 8, , 1)
                        Call FormatoCelda("K" & CStr(Fila) & ":M" & CStr(Fila), "Arial", False, 8, , 1, 19)

                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = "=SUM(G" & CStr(FilaRuma) & ":G" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = "=SUM(H" & CStr(FilaRuma) & ":H" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = "=J" & CStr(Fila) & "/H" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = "=SUM(J" & CStr(FilaRuma) & ":J" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = "=SUM(K" & CStr(FilaRuma) & ":K" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = "=M" & CStr(Fila) & "/K" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(M" & CStr(FilaRuma) & ":M" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("G" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                        Call FormatoCelda("K" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    End If

                End If

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                lblDetalle.Text = "Obteniendo el Mantenimiento Mecánico de la Chancadora"
                Application.DoEvents()

                Dim dsChancME As DataSet
                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.Trim
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                    .Usuario = User_Sistema
                    .Spid = Spid
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsChancME = Negocio.CosteoProduccion.Consultar_Produccion_Chancadora_ManttoMecanico(Entidad.Orden)
                If dsChancME.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                    lblDetalle.Text = "Exportando el Mantenimiento Mecánico de la Chancadora"
                    Application.DoEvents()

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "MANTENIMIENTO MECÁNICO"
                    Call CombinarCeldas("D" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 4) = "Mensual"
                    Call CombinarCeldas("D" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("D" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Chancadora"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 4) = "Producción(TON)"
                    Obj_Hoja.Cells(Fila, 5) = "Costo Mantto"
                    Obj_Hoja.Cells(Fila, 6) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 7) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 8) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                    FilaRuma = Fila
                    For cr = 0 To dsChancME.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsChancME.Tables(0).Rows(cr).Item("Codigo").ToString.TrimEnd + " - " + dsChancME.Tables(0).Rows(cr).Item("Descripcion").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 4) = Val(dsChancME.Tables(0).Rows(cr).Item("Tonelaje").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 5).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 5) = Val(dsChancME.Tables(0).Rows(cr).Item("CostoMantto").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = Val(dsChancME.Tables(0).Rows(cr).Item("Cantidad").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsChancME.Tables(0).Rows(cr).Item("CostoxTON").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsChancME.Tables(0).Rows(cr).Item("SubTotal").ToString.TrimEnd)
                        TotalCostoChancadora = TotalCostoChancadora + Val(dsChancME.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoChancadoraAcum = TotalCostoChancadoraAcum + Val(dsChancME.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", False, 8, , 1)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 4) = "=SUM(D" & CStr(FilaRuma) & ":D" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 5).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 5) = "=SUM(E" & CStr(FilaRuma) & ":E" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = "=SUM(F" & CStr(FilaRuma) & ":F" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = "=H" & CStr(Fila) & "/F" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = "=SUM(H" & CStr(FilaRuma) & ":H" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("D" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                        Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    End If

                End If


                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                lblDetalle.Text = "Obteniendo la Depreciación de la Chancadora"
                Application.DoEvents()

                Dim dsChancDep As DataSet
                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.Trim
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                    .Usuario = User_Sistema
                    .Spid = Spid
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsChancDep = Negocio.CosteoProduccion.Consultar_Produccion_Chancadora_Depreciacion(Entidad.Orden)
                If dsChancDep.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                    lblDetalle.Text = "Exportando la Depreciación de la Chancadora"
                    Application.DoEvents()

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "DEPRECIACIÓN"
                    Call CombinarCeldas("D" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 4) = "Mensual"
                    Call CombinarCeldas("D" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 9) = "Acumulado"
                    Call CombinarCeldas("I" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("D" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Chancadora"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 4) = "Producción(TON)"
                    Obj_Hoja.Cells(Fila, 5) = "Costo Mantto"
                    Obj_Hoja.Cells(Fila, 6) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 7) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 8) = "SubTotal(S/.)"
                    Obj_Hoja.Cells(Fila, 9) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 10) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 11) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    FilaRuma = Fila
                    For cr = 0 To dsChancDep.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsChancDep.Tables(0).Rows(cr).Item("Codigo").ToString.TrimEnd + " - " + dsChancDep.Tables(0).Rows(cr).Item("Descripcion").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 4) = Val(dsChancDep.Tables(0).Rows(cr).Item("Tonelaje").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 5).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 5) = Val(dsChancDep.Tables(0).Rows(cr).Item("CostoDeprec").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = Val(dsChancDep.Tables(0).Rows(cr).Item("Cantidad").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsChancDep.Tables(0).Rows(cr).Item("CostoxTON").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsChancDep.Tables(0).Rows(cr).Item("SubTotal").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsChancDep.Tables(0).Rows(cr).Item("CantAcum").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsChancDep.Tables(0).Rows(cr).Item("CostoxTONAcum").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsChancDep.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.TrimEnd)
                        TotalCostoChancadora = TotalCostoChancadora + Val(dsChancDep.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoChancadoraAcum = TotalCostoChancadoraAcum + Val(dsChancDep.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", False, 8, , 1)
                        Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 4) = "=SUM(D" & CStr(FilaRuma) & ":D" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 5).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 5) = "=SUM(E" & CStr(FilaRuma) & ":E" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = "=SUM(F" & CStr(FilaRuma) & ":F" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = "=H" & CStr(Fila) & "/F" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = "=SUM(H" & CStr(FilaRuma) & ":H" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = "=SUM(I" & CStr(FilaRuma) & ":I" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/I" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = "=SUM(K" & CStr(FilaRuma) & ":K" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("D" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                        Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    End If

                End If


                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                lblDetalle.Text = "Obteniendo la Energía Electrica de la Chancadora"
                Application.DoEvents()

                Dim dsChancEnergia As DataSet
                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.Trim
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                    .Usuario = User_Sistema
                    .Spid = Spid
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsChancEnergia = Negocio.CosteoProduccion.Consultar_Produccion_Chancadora_Energia(Entidad.Orden)
                If dsChancEnergia.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                    lblDetalle.Text = "Exportando la Energía Electrica de la Chancadora"
                    Application.DoEvents()

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "ENERGÍA ELECTRICA"
                    Call CombinarCeldas("D" & CStr(Fila) & ":N" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":N" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 4) = "Mensual"
                    Call CombinarCeldas("D" & CStr(Fila) & ":M" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 14) = "Acumulado"
                    Call CombinarCeldas("N" & CStr(Fila) & ":P" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("D" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("N" & CStr(Fila) & ":P" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Chancadora"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 4) = "Referencia"
                    Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 7) = "Producción(TON)"
                    Obj_Hoja.Cells(Fila, 8) = "Energia Total"
                    Obj_Hoja.Cells(Fila, 9) = "Energía"
                    Obj_Hoja.Cells(Fila, 10) = "Costo KWH"
                    Obj_Hoja.Cells(Fila, 11) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 12) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 13) = "SubTotal(S/.)"
                    Obj_Hoja.Cells(Fila, 14) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 15) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 16) = "SubTotal(S/.)"

                    Call FormatoCelda("B" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("N" & CStr(Fila) & ":P" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    FilaRuma = Fila
                    For cr = 0 To dsChancEnergia.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsChancEnergia.Tables(0).Rows(cr).Item("Codigo").ToString.TrimEnd + " - " + dsChancEnergia.Tables(0).Rows(cr).Item("Descripcion").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 4) = dsChancEnergia.Tables(0).Rows(cr).Item("Referencia").ToString.TrimEnd
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("Tonelaje").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("EnergíaTotal").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("Energía").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("CostoKWH").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("Cantidad").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("CostoxTON").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("SubTotal").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("CantAcum").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("CostoxTONAcum").ToString.TrimEnd)
                        Obj_Hoja.Cells(Fila, 16).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 16) = Val(dsChancEnergia.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.TrimEnd)
                        TotalCostoChancadora = TotalCostoChancadora + Val(dsChancEnergia.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoChancadoraAcum = TotalCostoChancadoraAcum + Val(dsChancEnergia.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":M" & CStr(Fila), "Arial", False, 8, , 1)
                        Call FormatoCelda("N" & CStr(Fila) & ":P" & CStr(Fila), "Arial", False, 8, , 1, 19)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = "=SUM(G" & CStr(FilaRuma) & ":G" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = "=SUM(H" & CStr(FilaRuma) & ":H" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = "=SUM(I" & CStr(FilaRuma) & ":I" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = "=SUM(J" & CStr(FilaRuma) & ":J" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = "=SUM(K" & CStr(FilaRuma) & ":K" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = "=M" & CStr(Fila) & "/K" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(M" & CStr(FilaRuma) & ":M" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = "=SUM(N" & CStr(FilaRuma) & ":N" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = "=P" & CStr(Fila) & "/N" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 16).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 16) = "=SUM(P" & CStr(FilaRuma) & ":P" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("G" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1)
                        Call FormatoCelda("N" & CStr(Fila) & ":P" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    End If

                End If


                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                lblDetalle.Text = "Obteniendo la Mano de Obra de la Chancadora"
                Application.DoEvents()

                Dim dsChancManoObra As DataSet
                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.TrimEnd
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cod_Alm = "19"
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsChancManoObra = Negocio.CosteoProduccion.Consultar_Produccion_Chancadora_ManoObra(Entidad.Orden)

                If dsChancManoObra.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo de la Chancadora"
                    lblDetalle.Text = "Exportando la Mano de Obra de la Chancadora"
                    Fila = Fila + 2

                    Obj_Hoja.Cells(Fila, 4) = "MANO DE OBRA"
                    Call CombinarCeldas("D" & CStr(Fila) & ":P" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":P" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 8) = "Mensual"
                    Call CombinarCeldas("H" & CStr(Fila) & ":M" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 16) = "Acumulado"
                    Call CombinarCeldas("N" & CStr(Fila) & ":P" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("H" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("N" & CStr(Fila) & ":P" & CStr(Fila), "Arial", True, 8, , 1, 19)

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Chancadora"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 4) = "Código"
                    Obj_Hoja.Cells(Fila, 5) = "Personal"
                    Call CombinarCeldas("E" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 8) = "Total"
                    Obj_Hoja.Cells(Fila, 9) = "Total Horas"
                    Obj_Hoja.Cells(Fila, 10) = "Horas Prod."
                    'Obj_Hoja.Cells(Fila, 11) = "Costo M.O."
                    'Obj_Hoja.Cells(Fila, 12) = "Costo x Hora"
                    Obj_Hoja.Cells(Fila, 11) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 12) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 13) = "SubTotal(S/.)"
                    Obj_Hoja.Cells(Fila, 14) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 16) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 16) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("N" & CStr(Fila) & ":P" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    FilaRuma = Fila

                    For cr = 0 To dsChancManoObra.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsChancManoObra.Tables(0).Rows(cr).Item("Cod_Chancadora").ToString.TrimEnd & " - " & dsChancManoObra.Tables(0).Rows(cr).Item("Chancadora").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 4) = dsChancManoObra.Tables(0).Rows(cr).Item("PlaCod").ToString.Trim
                        Obj_Hoja.Cells(Fila, 5) = dsChancManoObra.Tables(0).Rows(cr).Item("Descripcion").ToString.Trim
                        Call CombinarCeldas("E" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("Boleta").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("HorasLab").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("Horas").ToString.Trim)
                        'Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        'Obj_Hoja.Cells(Fila, 11) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("CostoMO").ToString.Trim)
                        'Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        'Obj_Hoja.Cells(Fila, 12) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("CostoxHora").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("CostoxTon").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("CantAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("CostoxTonAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 16).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 16) = Val(dsChancManoObra.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        TotalCostoChancadora = TotalCostoChancadora + Val(dsChancManoObra.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoChancadoraAcum = TotalCostoChancadoraAcum + Val(dsChancManoObra.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":M" & CStr(Fila), "Arial", False, 8, , 1)
                        Call FormatoCelda("N" & CStr(Fila) & ":P" & CStr(Fila), "Arial", False, 8, , 1, 19)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = "=AVERAGE(K" & CStr(FilaRuma + 1) & ":K" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = "=M" & CStr(Fila) & "/K" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(M" & CStr(FilaRuma + 1) & ":M" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = "=AVERAGE(N" & CStr(FilaRuma + 1) & ":N" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = "=P" & CStr(Fila) & "/N" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 16).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 16) = "=SUM(P" & CStr(FilaRuma + 1) & ":P" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("K" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1)
                        Call FormatoCelda("N" & CStr(Fila) & ":P" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    End If

                End If

            End If


            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo Costeo del Cargador Frontal"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsPala As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsPala = Negocio.CosteoProduccion.Consultar_Produccion_Pala(Entidad.Orden)

            Dim dsPalaCombustible As DataSet
            Dim dsPalaMO As DataSet
            Dim dsPalaDeprec As DataSet
            Dim dsPalaManttoAlquiler As DataSet
            Dim CostoCombustible As Double = 0
            Dim CostoPala As Double = 0
            Dim CostoPalaMO As Double = 0
            Dim CostoPalaDeprec As Double = 0
            Dim CostoPalaAlqMantto As Double = 0
            TotalCostoPala = 0

            If dsPala.Tables(0).Rows.Count > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                lblDetalle.Text = ""
                Application.DoEvents()

                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DEL CARGADOR FRONTAL"
                Call CombinarCeldas("B" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 10)

                Fila = Fila + 1
                PintarCabecera = False

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal: " & dsPala.Tables(0).Rows(c).Item("Cod_Pala").ToString.Trim
                lblDetalle.Text = ""
                Application.DoEvents()

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal: " & dsPala.Tables(0).Rows(c).Item("Cod_Pala").ToString.Trim
                lblDetalle.Text = "Obteniendo el Consumo de Combustible del Cargador Frontal"
                Application.DoEvents()

                CostoPala = 0
                CostoCombustible = 0

                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.TrimEnd
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .Cod_Alm = "19"
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsPalaCombustible = Negocio.CosteoProduccion.Consultar_Produccion_Pala_Combustible(Entidad.Orden)
                CostoCombustible = 0

                If dsPalaCombustible.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo del Cargador Frontal: " & dsPala.Tables(0).Rows(c).Item("Cod_Pala").ToString.Trim
                    lblDetalle.Text = "Exportando el Consumo de Combustible del Cargador Frontal"

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 4) = "CONSUMO DE COMBUSTIBLE"
                    Call FormatoCelda("D" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8)

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 8) = "Mensual"
                    Call CombinarCeldas("H" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 13) = "Acumulado"
                    Call CombinarCeldas("M" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("H" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("M" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Cargador Frontal"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 4) = "Codigo"
                    Obj_Hoja.Cells(Fila, 5) = "Combustible"
                    Call CombinarCeldas("E" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 7) = "Und"
                    Obj_Hoja.Cells(Fila, 8) = "Nro. O/C"
                    Obj_Hoja.Cells(Fila, 9) = "Consumo"
                    Obj_Hoja.Cells(Fila, 10) = "Cant. Comb."
                    Obj_Hoja.Cells(Fila, 11) = "Precio"
                    Obj_Hoja.Cells(Fila, 12) = "SubTotal(S/.)"
                    Obj_Hoja.Cells(Fila, 13) = "Cant. Comb."
                    Obj_Hoja.Cells(Fila, 14) = "Precio"
                    Obj_Hoja.Cells(Fila, 15) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("M" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    FilaRuma = Fila


                    For cr = 0 To dsPalaCombustible.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsPalaCombustible.Tables(0).Rows(cr).Item("Cod_Pala").ToString.TrimEnd & " - " & dsPalaCombustible.Tables(0).Rows(cr).Item("Pala").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4) = dsPalaCombustible.Tables(0).Rows(cr).Item("Codigo").ToString.Trim
                        Obj_Hoja.Cells(Fila, 5) = dsPalaCombustible.Tables(0).Rows(cr).Item("Descripcion").ToString.Trim
                        Call CombinarCeldas("E" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 7) = dsPalaCombustible.Tables(0).Rows(cr).Item("unid").ToString.Trim
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 8) = dsPalaCombustible.Tables(0).Rows(cr).Item("Nro_OC").ToString.Trim
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsPalaCombustible.Tables(0).Rows(cr).Item("Consumo").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsPalaCombustible.Tables(0).Rows(cr).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsPalaCombustible.Tables(0).Rows(cr).Item("Precio").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsPalaCombustible.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsPalaCombustible.Tables(0).Rows(cr).Item("CantAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = Val(dsPalaCombustible.Tables(0).Rows(cr).Item("PrecioAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = Val(dsPalaCombustible.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", False, 8, , 1)
                        Call FormatoCelda("M" & CStr(Fila) & ":O" & CStr(Fila), "Arial", False, 8, , 1, 19)
                        CostoCombustible = CostoCombustible + Val(dsPalaCombustible.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPala = TotalCostoPala + Val(dsPalaCombustible.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPalaAcum = TotalCostoPalaAcum + Val(dsPalaCombustible.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)

                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = "=SUM(I" & CStr(FilaRuma + 1) & ":I" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = "=SUM(J" & CStr(FilaRuma + 1) & ":J" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = "=L" & CStr(Fila) & "/J" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = "=SUM(L" & CStr(FilaRuma + 1) & ":L" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(M" & CStr(FilaRuma + 1) & ":M" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = "=O" & CStr(Fila) & "/M" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = "=SUM(O" & CStr(FilaRuma + 1) & ":O" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("I" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                        Call FormatoCelda("M" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    End If

                End If

                CostoCombustible = 0
                CostoPala = 0
                PintarCabecera = False
                CostoChandadora_MO = 0
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                lblDetalle.Text = "Obteniendo el Costo de Mano de Obra del Cargador Frontal"
                Application.DoEvents()

                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.TrimEnd
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cod_Alm = "19"
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsPalaMO = Negocio.CosteoProduccion.Consultar_Produccion_Pala_ManoObra(Entidad.Orden)

                CostoPalaMO = 0

                CostoPalaMO = 0
                If dsPalaMO.Tables(0).Rows.Count > 0 Then

                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                    lblDetalle.Text = "Exportando el Costo de Mano de Obra del Cargador Frontal"

                    Fila = Fila + 2

                    Obj_Hoja.Cells(Fila, 4) = "MANO DE OBRA"
                    Call CombinarCeldas("D" & CStr(Fila) & ":R" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 8) = "Mensual"
                    Call CombinarCeldas("H" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 16) = "Acumulado"
                    Call CombinarCeldas("P" & CStr(Fila) & ":R" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("H" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1, 19)

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Cargador Frontal"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 4) = "Código"
                    Obj_Hoja.Cells(Fila, 5) = "Personal"
                    Call CombinarCeldas("E" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 8) = "Total"
                    Obj_Hoja.Cells(Fila, 9) = "Total Horas"
                    Obj_Hoja.Cells(Fila, 10) = "Horas Prod."
                    Obj_Hoja.Cells(Fila, 11) = "Costo M.O."
                    Obj_Hoja.Cells(Fila, 12) = "Costo x Hora"
                    Obj_Hoja.Cells(Fila, 13) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 14) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 15) = "SubTotal(S/.)"
                    Obj_Hoja.Cells(Fila, 16) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 17) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 18) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    FilaRuma = Fila
                    PintarCabecera = True

                    For cr = 0 To dsPalaMO.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsPalaMO.Tables(0).Rows(cr).Item("Cod_Pala").ToString.TrimEnd & " - " & dsPalaMO.Tables(0).Rows(cr).Item("Pala").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 4) = dsPalaMO.Tables(0).Rows(cr).Item("PlaCod").ToString.Trim
                        Obj_Hoja.Cells(Fila, 5) = dsPalaMO.Tables(0).Rows(cr).Item("Descripcion").ToString.Trim
                        Call CombinarCeldas("E" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsPalaMO.Tables(0).Rows(cr).Item("Boleta").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsPalaMO.Tables(0).Rows(cr).Item("HorasLab").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsPalaMO.Tables(0).Rows(cr).Item("Horas").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsPalaMO.Tables(0).Rows(cr).Item("CostoMO").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsPalaMO.Tables(0).Rows(cr).Item("CostoxHora").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsPalaMO.Tables(0).Rows(cr).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = Val(dsPalaMO.Tables(0).Rows(cr).Item("CostoxTon").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = Val(dsPalaMO.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 16).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 16) = Val(dsPalaMO.Tables(0).Rows(cr).Item("CantAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 17).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 17) = Val(dsPalaMO.Tables(0).Rows(cr).Item("CostoxTonAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 18).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 18) = Val(dsPalaMO.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)

                        CostoPalaMO = CostoPalaMO + Val(dsPalaMO.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPala = TotalCostoPala + Val(dsPalaMO.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPalaAcum = TotalCostoPalaAcum + Val(dsPalaMO.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", False, 8, , 1)
                        Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", False, 8, , 1, 19)
                    Next

                    If PintarCabecera = True Then
                        If (Fila) - (FilaRuma + 1) > 0 Then
                            Fila = Fila + 1
                            Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 13) = "=SUM(M" & CStr(FilaRuma + 1) & ":M" & CStr(Fila - 1) & ")"
                            Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 14) = "=O" & CStr(Fila) & "/M" & CStr(Fila)
                            Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 15) = "=SUM(O" & CStr(FilaRuma + 1) & ":O" & CStr(Fila - 1) & ")"
                            Obj_Hoja.Cells(Fila, 16).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 16) = "=SUM(P" & CStr(FilaRuma + 1) & ":P" & CStr(Fila - 1) & ")"
                            Obj_Hoja.Cells(Fila, 17).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 17) = "=R" & CStr(Fila) & "/P" & CStr(Fila)
                            Obj_Hoja.Cells(Fila, 18).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 18) = "=SUM(R" & CStr(FilaRuma + 1) & ":R" & CStr(Fila - 1) & ")"
                            Call FormatoCelda("M" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                            Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1, 19)
                        End If
                    End If

                End If

                CostoPalaMO = 0
                CostoCombustible = 0
                CostoPala = 0
                PintarCabecera = False
                CostoPalaDeprec = 0

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal" '& dsPala.Tables(0).Rows(c).Item("Cod_Pala").ToString.Trim
                lblDetalle.Text = "Obteniendo la Depreciación del Cargador Frontal"
                Application.DoEvents()

                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.TrimEnd
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .Cod_Alm = "19"
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsPalaDeprec = Negocio.CosteoProduccion.Consultar_Produccion_Pala_Depreciacion(Entidad.Orden)

                If dsPalaDeprec.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo del Cargador Frontal" '& dsPala.Tables(0).Rows(c).Item("Cod_Pala").ToString.Trim
                    lblDetalle.Text = "Exportando la Depreciación del Cargador Frontal"

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "DEPRECIACIÓN CARGADOR FRONTAL"
                    Call CombinarCeldas("B" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8)

                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 6) = "Mensual"
                    Call CombinarCeldas("F" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 11) = "Acumulado"
                    Call CombinarCeldas("K" & CStr(Fila) & ":M" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("F" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("K" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Código"
                    Obj_Hoja.Cells(Fila, 3) = "Und. Prod."
                    Call CombinarCeldas("C" & CStr(Fila) & ":E" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 6) = "Costo Deprec."
                    Obj_Hoja.Cells(Fila, 7) = "Producción"
                    Obj_Hoja.Cells(Fila, 8) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 9) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 10) = "SubTotal(S/.)"
                    Obj_Hoja.Cells(Fila, 11) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 12) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 13) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("K" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1, 19)

                    FilaRuma = Fila
                    PintarCabecera = True

                    For cr = 0 To dsPalaDeprec.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 2) = dsPalaDeprec.Tables(0).Rows(cr).Item("Codigo").ToString.Trim
                        Obj_Hoja.Cells(Fila, 3) = dsPalaDeprec.Tables(0).Rows(cr).Item("Descripcion").ToString.Trim
                        Call CombinarCeldas("C" & CStr(Fila) & ":E" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = Val(dsPalaDeprec.Tables(0).Rows(cr).Item("CostoDeprec").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = Val(dsPalaDeprec.Tables(0).Rows(cr).Item("Tonelaje").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsPalaDeprec.Tables(0).Rows(cr).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsPalaDeprec.Tables(0).Rows(cr).Item("CostoxTon").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsPalaDeprec.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsPalaDeprec.Tables(0).Rows(cr).Item("CantAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsPalaDeprec.Tables(0).Rows(cr).Item("CostoxTonAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsPalaDeprec.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", False, 8, , 1)
                        Call FormatoCelda("K" & CStr(Fila) & ":M" & CStr(Fila), "Arial", False, 8, , 1, 19)

                        CostoPalaDeprec = CostoPalaDeprec + Val(dsPalaDeprec.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPala = TotalCostoPala + Val(dsPalaDeprec.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPalaAcum = TotalCostoPalaAcum + Val(dsPalaDeprec.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 6) = "=SUM(F" & CStr(FilaRuma + 1) & ":F" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 7) = "=SUM(G" & CStr(FilaRuma + 1) & ":G" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = "=SUM(H" & CStr(FilaRuma + 1) & ":H" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = "=J" & CStr(Fila) & "/H" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = "=SUM(J" & CStr(FilaRuma + 1) & ":J" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = "=SUM(K" & CStr(FilaRuma + 1) & ":K" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = "=M" & CStr(Fila) & "/K" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(M" & CStr(FilaRuma + 1) & ":M" & CStr(Fila - 1) & ")"

                        Call FormatoCelda("F" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                        Call FormatoCelda("K" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1, 19)

                    End If

                End If

                CostoPalaMO = 0
                CostoCombustible = 0
                CostoPala = 0
                PintarCabecera = False
                CostoPalaDeprec = 0
                CostoPalaAlqMantto = 0

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                lblDetalle.Text = "Obteniendo el Costo del Mantto. Mecánico del Cargador Frontal"
                Application.DoEvents()

                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.TrimEnd
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .Cod_Alm = "19"
                    .Tipo = 0
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsPalaManttoAlquiler = Negocio.CosteoProduccion.Consultar_Produccion_Pala_Alquiler_Mantto(Entidad.Orden)

                CostoPalaAlqMantto = 0
                If dsPalaManttoAlquiler.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                    lblDetalle.Text = "Exportando el Costo del Mantto. Mecánico del Cargador Frontal"

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "MANTENIMIENTO"
                    Call CombinarCeldas("D" & CStr(Fila) & ":R" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 7) = "Mensual"
                    Call CombinarCeldas("G" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 16) = "Acumulado"
                    Call CombinarCeldas("P" & CStr(Fila) & ":R" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("G" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1, 19)


                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Cargador Frontal"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 4) = "Proveedor"
                    Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 7) = "Tipo. Doc."
                    Obj_Hoja.Cells(Fila, 8) = "Nro. Doc."
                    Call CombinarCeldas("H" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 11) = "Total(Sin IGV)"
                    Obj_Hoja.Cells(Fila, 12) = "Produccion"
                    Obj_Hoja.Cells(Fila, 13) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 14) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 15) = "SubTotal(S/.)"
                    Obj_Hoja.Cells(Fila, 16) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 17) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 18) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    FilaRuma = Fila

                    For cr = 0 To dsPalaManttoAlquiler.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsPala.Tables(0).Rows(cr).Item("Cod_Pala").ToString.TrimEnd & " - " & dsPala.Tables(0).Rows(cr).Item("Pala").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4) = dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Proveedor").ToString.Trim
                        Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 7) = dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Tipo_Doc").ToString.Trim
                        Call CombinarCeldas("H" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 8) = Trim(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Num_Doc").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Total").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Produccion").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("CostoxTON").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 16).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 16) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("CantAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 17).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 17) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("CostoxTONAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 18).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 18) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", False, 8, , 1)
                        Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", False, 8, , 1, 19)

                        CostoPalaAlqMantto = CostoPalaAlqMantto + Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPala = TotalCostoPala + Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPalaAcum = TotalCostoPalaAcum + Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = "=SUM(K" & CStr(FilaRuma + 1) & ":K" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = "=SUM(L" & CStr(FilaRuma + 1) & ":L" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(M" & CStr(FilaRuma + 1) & ":M" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = "=O" & CStr(Fila) & "/M" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = "=SUM(O" & CStr(FilaRuma + 1) & ":O" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(P" & CStr(FilaRuma + 1) & ":P" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = "=R" & CStr(Fila) & "/P" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = "=SUM(R" & CStr(FilaRuma + 1) & ":R" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("K" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                        Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1, 19)

                    End If

                End If

                CostoPalaMO = 0
                CostoCombustible = 0
                CostoPala = 0
                PintarCabecera = False
                CostoPalaDeprec = 0
                CostoPalaAlqMantto = 0

                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                lblDetalle.Text = "Obteniendo el Costo de Alquiler del Cargador Frontal"
                Application.DoEvents()

                Entidad.Orden = New ETOrden
                With Entidad.Orden
                    .CodEnlace = CodEnlace
                    .CodProducto = Txt1.Text.TrimEnd
                    .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                    .Usuario = User_Sistema
                    .Spid = Spid
                    .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                    .FechaInicio = FechaInicio
                    .FechaTerminacion = FechaTermino
                    .Cod_Alm = "19"
                    .Tipo = 1
                End With
                Negocio.CosteoProduccion = New NGCosteoProduccion
                dsPalaManttoAlquiler = Negocio.CosteoProduccion.Consultar_Produccion_Pala_Alquiler_Mantto(Entidad.Orden)

                CostoPalaAlqMantto = 0
                If dsPalaManttoAlquiler.Tables(0).Rows.Count > 0 Then
                    lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                    lblCosteo.Text = "Exportando el Costeo del Cargador Frontal"
                    lblDetalle.Text = "Exportando el Costo del Alquiler del Cargador Frontal"

                    Fila = Fila + 2
                    Obj_Hoja.Cells(Fila, 4) = "ALQUILER"
                    Call CombinarCeldas("D" & CStr(Fila) & ":R" & CStr(Fila), Alineacion.Izquierda)
                    Call FormatoCelda("D" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8)
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 7) = "Mensual"
                    Call CombinarCeldas("G" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 16) = "Acumulado"
                    Call CombinarCeldas("P" & CStr(Fila) & ":R" & CStr(Fila), Alineacion.Centrado)
                    Call FormatoCelda("G" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1, 19)


                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = "Cargador Frontal"
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 4) = "Proveedor"
                    Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 7) = "Tipo. Doc."
                    Obj_Hoja.Cells(Fila, 8) = "Nro. Doc."
                    Call CombinarCeldas("H" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                    Obj_Hoja.Cells(Fila, 11) = "Total(Sin IGV)"
                    Obj_Hoja.Cells(Fila, 12) = "Produccion"
                    Obj_Hoja.Cells(Fila, 13) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 14) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 15) = "SubTotal(S/.)"
                    Obj_Hoja.Cells(Fila, 16) = "Cant. TON"
                    Obj_Hoja.Cells(Fila, 17) = "Costo x TON"
                    Obj_Hoja.Cells(Fila, 18) = "SubTotal(S/.)"
                    Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1, 19)

                    FilaRuma = Fila

                    For cr = 0 To dsPalaManttoAlquiler.Tables(0).Rows.Count - 1
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = dsPala.Tables(0).Rows(cr).Item("Cod_Pala").ToString.TrimEnd & " - " & dsPala.Tables(0).Rows(cr).Item("Pala").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 4) = dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Proveedor").ToString.Trim
                        Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 7) = dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Tipo_Doc").ToString.Trim
                        Call CombinarCeldas("H" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 8) = Trim(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Num_Doc").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Total").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Produccion").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("CostoxTON").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 16).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 16) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("CantAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 17).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 17) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("CostoxTONAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 18).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 18) = Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", False, 8, , 1)
                        Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", False, 8, , 1, 19)

                        CostoPalaAlqMantto = CostoPalaAlqMantto + Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPala = TotalCostoPala + Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotal").ToString.Trim)
                        TotalCostoPalaAcum = TotalCostoPalaAcum + Val(dsPalaManttoAlquiler.Tables(0).Rows(cr).Item("SubTotalAcum").ToString.Trim)
                    Next

                    If (Fila) - (FilaRuma + 1) > 0 Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = "=SUM(K" & CStr(FilaRuma + 1) & ":K" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = "=SUM(L" & CStr(FilaRuma + 1) & ":L" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(M" & CStr(FilaRuma + 1) & ":M" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = "=O" & CStr(Fila) & "/M" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = "=SUM(O" & CStr(FilaRuma + 1) & ":O" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = "=SUM(P" & CStr(FilaRuma + 1) & ":P" & CStr(Fila - 1) & ")"
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = "=R" & CStr(Fila) & "/P" & CStr(Fila)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = "=SUM(R" & CStr(FilaRuma + 1) & ":R" & CStr(Fila - 1) & ")"
                        Call FormatoCelda("K" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                        Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1, 19)

                    End If

                End If

            End If

            CostoPalaMO = 0
            CostoCombustible = 0
            CostoPala = 0
            CostoPalaDeprec = 0
            CostoPalaAlqMantto = 0

            TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("ProduccionPlanta").ToString)

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo el Costeo de la Mano de Obra del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsManoObra As DataSet

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("ProduccionPlanta").ToString)
                .Descripcion = DsProduccion.Tables(0).Rows(i).Item("Molino").ToString.Trim
                .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsManoObra = Negocio.CosteoProduccion.Consultar_Produccion_ManoObra(Entidad.Orden)

            TotalManoObra = 0
            If dsManoObra.Tables(0).Rows.Count > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Mano de Obra del Molino"
                lblDetalle.Text = ""


                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Obtener el Costeo de la Mano de Obra del Producto"
                lblDetalle.Text = ""

                Fila = Fila + 2

                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE MANO DE OBRA"
                Call CombinarCeldas("B" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 10)


                Dim TipoMO As String = String.Empty
                Dim TotalMOTipo As Double = 0
                Dim TotalMOTipoAcum As Double = 0

                For r = 0 To dsManoObra.Tables(0).Rows.Count - 1

                    If TipoMO <> dsManoObra.Tables(0).Rows(r).Item("Tipo").ToString.Trim Then
                        If r > 0 Then
                            Fila = Fila + 1
                            Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 12) = "=sum(L" & CStr(FilaRuma + 1) & ":L" & CStr(Fila - 1) & ")"
                            Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                            Obj_Hoja.Cells(Fila, 15) = "=sum(O" & CStr(FilaRuma + 1) & ":O" & CStr(Fila - 1) & ")"

                            'Call CombinarCeldas("P" & CStr(Fila) & ":Q" & CStr(Fila), Alineacion.Centrado)
                            Call FormatoCelda("L" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                            Call FormatoCelda("O" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1, 19)
                            TotalMOTipo = 0
                            TotalMOTipoAcum = 0
                        End If

                        Fila = Fila + 2
                        TipoMO = dsManoObra.Tables(0).Rows(r).Item("Tipo").ToString.Trim
                        Select Case TipoMO
                            Case "A"
                                Obj_Hoja.Cells(Fila, 4) = "OBREROS"
                            Case "B"
                                Obj_Hoja.Cells(Fila, 4) = "PERSONAL DE PLANTA DE CEMENTO"
                            Case "C"
                                Obj_Hoja.Cells(Fila, 4) = "DISTRIBUCIÓN PORCENTUAL DEL COSTO DEL PERSONAL ENTRE LAS PLANTAS"
                            Case Else
                                Obj_Hoja.Cells(Fila, 4) = "OTROS"
                        End Select
                        Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 10)
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 8) = "Mensual"
                        Call CombinarCeldas("H" & CStr(Fila) & ":L" & CStr(Fila), Alineacion.Centrado)
                        Obj_Hoja.Cells(Fila, 15) = "Acumulado"
                        Call CombinarCeldas("M" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                        Call FormatoCelda("H" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                        Call FormatoCelda("M" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1, 19)


                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = "Cod.Und.Prod."
                        Obj_Hoja.Cells(Fila, 3) = "Und. Prod."
                        Obj_Hoja.Cells(Fila, 4) = "Código"
                        Obj_Hoja.Cells(Fila, 5) = "Personal"
                        Call CombinarCeldas("E" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
                        Obj_Hoja.Cells(Fila, 8) = "Porcentaje"
                        Obj_Hoja.Cells(Fila, 9) = "Total Prod."
                        Obj_Hoja.Cells(Fila, 10) = "Cant. TON"
                        Obj_Hoja.Cells(Fila, 11) = "Costo x TON"
                        Obj_Hoja.Cells(Fila, 12) = "SubTotal(S/.)"
                        Obj_Hoja.Cells(Fila, 13) = "Cant. TON"
                        Obj_Hoja.Cells(Fila, 14) = "Costo x TON"
                        Obj_Hoja.Cells(Fila, 15) = "SubTotal(S/.)"
                        FilaRuma = Fila
                        Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                        Call FormatoCelda("M" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    End If

                    If Not (TipoMO.TrimEnd = "C" And Chk1.Checked = False) Then
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 2) = dsManoObra.Tables(0).Rows(r).Item("Placa").ToString.Trim
                        Obj_Hoja.Cells(Fila, 3) = dsManoObra.Tables(0).Rows(r).Item("UnidadProd").ToString.Trim
                        Obj_Hoja.Cells(Fila, 4).NumberFormat = "@"
                        Obj_Hoja.Cells(Fila, 4) = dsManoObra.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                        Obj_Hoja.Cells(Fila, 5) = dsManoObra.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                        Call CombinarCeldas("E" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(dsManoObra.Tables(0).Rows(r).Item("Porcentaje").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(dsManoObra.Tables(0).Rows(r).Item("TonMaximo").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(dsManoObra.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(dsManoObra.Tables(0).Rows(r).Item("CostoxTON").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 12) = Val(dsManoObra.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 13) = Val(dsManoObra.Tables(0).Rows(r).Item("CantAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 14) = Val(dsManoObra.Tables(0).Rows(r).Item("CostoxTONAcum").ToString.Trim)
                        Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 15) = Val(dsManoObra.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                        Call FormatoCelda("B" & CStr(Fila) & ":L" & CStr(Fila), "Arial", False, 8, , 1)
                        Call FormatoCelda("M" & CStr(Fila) & ":O" & CStr(Fila), "Arial", False, 8, , 1, 19)
                    End If

                    TotalManoObra = TotalManoObra + Val(dsManoObra.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    TotalManoObraAcum = TotalManoObraAcum + Val(dsManoObra.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                    TotalMOTipo = TotalMOTipo + Val(dsManoObra.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    TotalMOTipoAcum = TotalMOTipoAcum + Val(dsManoObra.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                Next


                Fila = Fila + 1
                If TipoMO = "C" And Chk1.Checked = False Then

                    Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 12) = TotalMOTipo
                    Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 15) = TotalMOTipoAcum

                    Call FormatoCelda("L" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("O" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    TotalMOTipo = 0
                    TotalMOTipoAcum = 0
                Else
                    Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 12) = "=sum(L" & CStr(FilaRuma + 1) & ":L" & CStr(Fila - 1) & ")"
                    Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 15) = "=sum(O" & CStr(FilaRuma + 1) & ":O" & CStr(Fila - 1) & ")"

                    Call FormatoCelda("L" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("O" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1, 19)
                    TotalMOTipo = 0
                    TotalMOTipoAcum = 0
                End If

                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 11) = "Costo Total:"
                Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 12) = TotalManoObra

                'Call CombinarCeldas("P" & CStr(Fila) & ":Q" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("K" & CStr(Fila) & ":L" & CStr(Fila), "Arial", True, 8, , 1)
            End If

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo el Costeo del Mantto. Mec. del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsManttoMec As DataSet
            Entidad.Orden = New ETOrden
            With (Entidad.Orden)
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .TotalMolino = Val(DsProduccion.Tables(0).Rows(i).Item("TonUniProd").ToString)
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("ProduccionPlanta").ToString)
                .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsManttoMec = Negocio.CosteoProduccion.Consultar_Produccion_Mantto_Mecanico(Entidad.Orden)

            TotalCostoManttoMecanico = 0
            If dsManttoMec.Tables(0).Rows.Count > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Mantto. Mec. del Molino"
                lblDetalle.Text = ""

                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE MANTENIMIENTO MECÁNICO"
                Call CombinarCeldas("B" & CStr(Fila) & ":N" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":N" & CStr(Fila), "Arial", True, 10)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 7) = "Mensual"
                Call CombinarCeldas("G" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 12) = "Acumulado"
                Call CombinarCeldas("L" & CStr(Fila) & ":N" & CStr(Fila), Alineacion.Centrado)

                Call FormatoCelda("G" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("L" & CStr(Fila) & ":N" & CStr(Fila), "Arial", True, 8, , 1, 19)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2) = "Tipo.Und.Prod"
                Obj_Hoja.Cells(Fila, 3) = "Código"
                Obj_Hoja.Cells(Fila, 4) = "Und. Prod."
                Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 7) = "Costo Mantto."
                Obj_Hoja.Cells(Fila, 8) = "Producción"
                Obj_Hoja.Cells(Fila, 9) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 10) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 11) = "SubTotal(S/.)"
                Obj_Hoja.Cells(Fila, 12) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 13) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 14) = "SubTotal(S/.)"
                FilaRuma = Fila
                Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("L" & CStr(Fila) & ":N" & CStr(Fila), "Arial", True, 8, , 1, 19)

                For r = 0 To dsManttoMec.Tables(0).Rows.Count - 1
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = dsManttoMec.Tables(0).Rows(r).Item("TipoUnidad").ToString.Trim
                    Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
                    Obj_Hoja.Cells(Fila, 3) = dsManttoMec.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                    Obj_Hoja.Cells(Fila, 4) = dsManttoMec.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                    Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = Val(dsManttoMec.Tables(0).Rows(r).Item("CostoMantto").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = Val(dsManttoMec.Tables(0).Rows(r).Item("Tonelaje").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = Val(dsManttoMec.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = Val(dsManttoMec.Tables(0).Rows(r).Item("CostoxTon").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 11) = Val(dsManttoMec.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 12) = Val(dsManttoMec.Tables(0).Rows(r).Item("CantAcum").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 13) = Val(dsManttoMec.Tables(0).Rows(r).Item("CostoxTonAcum").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 14) = Val(dsManttoMec.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)

                    Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1)
                    Call FormatoCelda("L" & CStr(Fila) & ":N" & CStr(Fila), "Arial", False, 8, , 1, 19)

                    TotalCostoManttoMecanico = TotalCostoManttoMecanico + Val(dsManttoMec.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    TotalCostoManttoMecanicoAcum = TotalCostoManttoMecanicoAcum + Val(dsManttoMec.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                Next

                Fila = Fila + 1

                Obj_Hoja.Cells(Fila, 9) = "Costo Total:"
                Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 10) = TotalCostoManttoMecanico
                Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 12) = "=AVERAGE(L" & CStr(FilaRuma + 1) & ":L" & CStr(Fila - 1) & ")"
                Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 13) = "=N" & CStr(Fila) & "/L" & CStr(Fila)
                Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 14) = "=SUM(N" & CStr(FilaRuma + 1) & ":N" & CStr(Fila - 1) & ")"

                Call CombinarCeldas("J" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Derecha)
                Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("L" & CStr(Fila) & ":N" & CStr(Fila), "Arial", True, 8, , 1, 19)


            End If

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo el Costeo de la Depreciación del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsDeprec As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .TotalMolino = Val(DsProduccion.Tables(0).Rows(i).Item("TonUniProd").ToString)
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("ProduccionPlanta").ToString)
                .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsDeprec = Negocio.CosteoProduccion.Consultar_Produccion_Depreciacion(Entidad.Orden)

            TotalCostoDepreciacion = 0
            If dsDeprec.Tables(0).Rows.Count > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Depreciación del Molino"
                lblDetalle.Text = ""

                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE DEPRECIACIÓN"
                Call CombinarCeldas("B" & CStr(Fila) & ":N" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":N" & CStr(Fila), "Arial", True, 10)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 7) = "Mensual"
                Call CombinarCeldas("G" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 12) = "Acumulado"
                Call CombinarCeldas("L" & CStr(Fila) & ":N" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("G" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("L" & CStr(Fila) & ":N" & CStr(Fila), "Arial", True, 8, , 1, 19)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2) = "Tipo Und. Prod."
                Obj_Hoja.Cells(Fila, 3) = "Código"
                Obj_Hoja.Cells(Fila, 4) = "Und. Prod."
                Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 7) = "Costo Deprec."
                Obj_Hoja.Cells(Fila, 8) = "Producción"
                Obj_Hoja.Cells(Fila, 9) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 10) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 11) = "SubTotal(S/.)"
                Obj_Hoja.Cells(Fila, 11) = "SubTotal(S/.)"
                Obj_Hoja.Cells(Fila, 12) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 13) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 14) = "SubTotal(S/.)"
                FilaRuma = Fila
                Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("L" & CStr(Fila) & ":N" & CStr(Fila), "Arial", True, 8, , 1, 19)

                For r = 0 To dsDeprec.Tables(0).Rows.Count - 1
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = dsDeprec.Tables(0).Rows(r).Item("TipoUnidad").ToString.Trim
                    Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
                    Obj_Hoja.Cells(Fila, 3) = dsDeprec.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                    Obj_Hoja.Cells(Fila, 4) = dsDeprec.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                    Call CombinarCeldas("D" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = Val(dsDeprec.Tables(0).Rows(r).Item("CostoDeprec").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = Val(dsDeprec.Tables(0).Rows(r).Item("Tonelaje").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = Val(dsDeprec.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = Val(dsDeprec.Tables(0).Rows(r).Item("CostoxTon").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 11) = Val(dsDeprec.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 12) = Val(dsDeprec.Tables(0).Rows(r).Item("CantAcum").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 13) = Val(dsDeprec.Tables(0).Rows(r).Item("CostoxTonAcum").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 14) = Val(dsDeprec.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                    Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1)
                    Call FormatoCelda("L" & CStr(Fila) & ":N" & CStr(Fila), "Arial", False, 8, , 1, 19)
                    TotalCostoDepreciacion = TotalCostoDepreciacion + Val(dsDeprec.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    TotalCostoDepreciacionAcum = TotalCostoDepreciacionAcum + Val(dsDeprec.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                Next

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 9) = "Costo Total:"
                Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 10) = TotalCostoDepreciacion
                Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 12) = "=AVERAGE(L" & CStr(FilaRuma + 1) & ":L" & CStr(Fila - 1) & ")"
                Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 13) = "=N" & CStr(Fila) & "/L" & CStr(Fila)
                Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 14) = "=SUM(N" & CStr(FilaRuma + 1) & ":N" & CStr(Fila - 1) & ")"

                Call CombinarCeldas("J" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Derecha)
                Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("L" & CStr(Fila) & ":N" & CStr(Fila), "Arial", True, 8, , 1, 19)

            End If

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo el Costeo de la Energía del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsEnergia As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .HorasTrabajadas = Val(DsProduccion.Tables(0).Rows(i).Item("HorasTrab").ToString)
                .TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("ProduccionPlanta").ToString)
                .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)

            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsEnergia = Negocio.CosteoProduccion.Consultar_Produccion_Energia(Entidad.Orden)

            TotalCostoEnergia = 0
            If dsEnergia.Tables(0).Rows.Count > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo de la Energía del Molino"
                lblDetalle.Text = ""

                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE ENERGIA"
                Call CombinarCeldas("B" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 10)
                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 8) = "Mensual"
                Call CombinarCeldas("H" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 16) = "Acumulado"
                Call CombinarCeldas("P" & CStr(Fila) & ":R" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("H" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1, 19)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2) = "Referencia"
                Call CombinarCeldas("B" & CStr(Fila) & ":D" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 5) = "Código"
                Obj_Hoja.Cells(Fila, 6) = "Molino"
                Call CombinarCeldas("F" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 8) = "Total Energía"
                Obj_Hoja.Cells(Fila, 9) = "Total Horas"
                Obj_Hoja.Cells(Fila, 10) = "Horas"
                Obj_Hoja.Cells(Fila, 11) = "Costo KWH"
                Obj_Hoja.Cells(Fila, 12) = "Energía"
                Obj_Hoja.Cells(Fila, 13) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 14) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 15) = "SubTotal(S/.)"
                Obj_Hoja.Cells(Fila, 16) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 17) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 18) = "SubTotal(S/.)"

                Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1, 19)

                FilaRuma = Fila

                For r = 0 To dsEnergia.Tables(0).Rows.Count - 1
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = dsEnergia.Tables(0).Rows(r).Item("TipoUnidad").ToString.Trim
                    Call CombinarCeldas("B" & CStr(Fila) & ":D" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 5).NumberFormat = "@"
                    Obj_Hoja.Cells(Fila, 5) = dsEnergia.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                    Obj_Hoja.Cells(Fila, 6) = dsEnergia.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                    Call CombinarCeldas("F" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = Val(dsEnergia.Tables(0).Rows(r).Item("EnergiaTotal").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = Val(dsEnergia.Tables(0).Rows(r).Item("Horas_Und").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = Val(dsEnergia.Tables(0).Rows(r).Item("Horas").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 11) = Val(dsEnergia.Tables(0).Rows(r).Item("CostoKwxHora").ToString.Trim)

                    Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 12) = Val(dsEnergia.Tables(0).Rows(r).Item("Energia").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 13) = Val(dsEnergia.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 14) = Val(dsEnergia.Tables(0).Rows(r).Item("CostoxTon").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 15).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 15) = Val(dsEnergia.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 16).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 16) = Val(dsEnergia.Tables(0).Rows(r).Item("CantAcum").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 17).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 17) = Val(dsEnergia.Tables(0).Rows(r).Item("CostoxTonAcum").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 18).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 18) = Val(dsEnergia.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)

                    Call FormatoCelda("B" & CStr(Fila) & ":O" & CStr(Fila), "Arial", False, 8, , 1)
                    Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", False, 8, , 1, 19)

                    TotalCostoEnergia = TotalCostoEnergia + Val(dsEnergia.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    TotalCostoEnergiaAcum = TotalCostoEnergiaAcum + Val(dsEnergia.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                Next

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 13) = "Costo Total:"
                Obj_Hoja.Cells(Fila, 14).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 14) = TotalCostoEnergia
                Obj_Hoja.Cells(Fila, 16).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 16) = "=AVERAGE(P" & CStr(FilaRuma + 1) & ":P" & CStr(Fila - 1) & ")"
                Obj_Hoja.Cells(Fila, 17).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 17) = "=R" & CStr(Fila) & "/P" & CStr(Fila)
                Obj_Hoja.Cells(Fila, 18).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 18) = "=SUM(R" & CStr(FilaRuma + 1) & ":R" & CStr(Fila - 1) & ")"

                Call CombinarCeldas("N" & CStr(Fila) & ":O" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("M" & CStr(Fila) & ":O" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("P" & CStr(Fila) & ":R" & CStr(Fila), "Arial", True, 8, , 1, 19)


            End If

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo el Costeo del Gas Natural del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsGasNat As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("ProduccionPlanta").ToString)
                .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsGasNat = Negocio.CosteoProduccion.Consultar_Produccion_GasNatural(Entidad.Orden)

            TotalCostoGasNatural = 0
            If dsGasNat.Tables(0).Rows.Count > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Gas Natural del Molino"
                lblDetalle.Text = ""

                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE GAS NATURAL"
                Call CombinarCeldas("B" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 10)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 7) = "Mensual"
                Call CombinarCeldas("G" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 11) = "Acumulado"
                Call CombinarCeldas("K" & CStr(Fila) & ":M" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("G" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("K" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1, 19)


                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2) = "Referencia"
                Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 4) = "Código"
                Obj_Hoja.Cells(Fila, 5) = "Und. Prod."
                Call CombinarCeldas("E" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 7) = "Gas m3 std"
                Obj_Hoja.Cells(Fila, 8) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 9) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 10) = "SubTotal(S/.)"
                Obj_Hoja.Cells(Fila, 11) = "Cant. TON"
                Obj_Hoja.Cells(Fila, 12) = "Costo x TON"
                Obj_Hoja.Cells(Fila, 13) = "SubTotal(S/.)"
                Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("K" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1, 19)

                FilaRuma = Fila

                For r = 0 To dsGasNat.Tables(0).Rows.Count - 1
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2) = dsGasNat.Tables(0).Rows(r).Item("TipoUnidad").ToString.Trim
                    Call CombinarCeldas("B" & CStr(Fila) & ":C" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 4).NumberFormat = "@"
                    Obj_Hoja.Cells(Fila, 4) = dsGasNat.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                    Obj_Hoja.Cells(Fila, 5) = dsGasNat.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                    Call CombinarCeldas("E" & CStr(Fila) & ":F" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = Val(dsGasNat.Tables(0).Rows(r).Item("GasNatural").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = Val(dsGasNat.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = Val(dsGasNat.Tables(0).Rows(r).Item("CostoxTon").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = Val(dsGasNat.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 11) = Val(dsGasNat.Tables(0).Rows(r).Item("CantAcum").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 12) = Val(dsGasNat.Tables(0).Rows(r).Item("CostoxTonAcum").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 13) = Val(dsGasNat.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                    Call FormatoCelda("B" & CStr(Fila) & ":J" & CStr(Fila), "Arial", False, 8, , 1)
                    Call FormatoCelda("K" & CStr(Fila) & ":M" & CStr(Fila), "Arial", False, 8, , 1, 19)
                    TotalCostoGasNatural = TotalCostoGasNatural + Val(dsGasNat.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    TotalCostoGasNaturalAcum = TotalCostoGasNaturalAcum + Val(dsGasNat.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                Next

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 8) = "Costo Total:"
                Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 9) = TotalCostoGasNatural
                Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 11) = "=AVERAGE(K" & CStr(FilaRuma + 1) & ":K" & CStr(Fila - 1) & ")"
                Obj_Hoja.Cells(Fila, 12).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 12) = "=M" & CStr(Fila) & "/K" & CStr(Fila)
                Obj_Hoja.Cells(Fila, 13).NumberFormat = "#,##0.0000"
                Obj_Hoja.Cells(Fila, 13) = "=SUM(M" & CStr(FilaRuma + 1) & ":M" & CStr(Fila - 1) & ")"


                Call CombinarCeldas("I" & CStr(Fila) & ":J" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("H" & CStr(Fila) & ":J" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("K" & CStr(Fila) & ":M" & CStr(Fila), "Arial", True, 8, , 1, 19)
            End If

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Obteniendo el Costeo del Envase de la Producción del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()

            Dim dsEnvases As DataSet
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .Cantidad = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString
                .FechaInicio = FechaInicio
                .FechaTerminacion = FechaTermino
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            dsEnvases = Negocio.CosteoProduccion.Consultar_Produccion_Envases(Entidad.Orden)

            TotalCostoEnvases = 0
            If dsEnvases.Tables(0).Rows.Count > 0 Then
                lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
                lblCosteo.Text = "Exportando el Costeo del Envase de la Producción del Molino"
                lblDetalle.Text = ""

                Fila = Fila + 2
                Obj_Hoja.Cells(Fila, 2) = "COSTEO DE ENVASES"
                Call CombinarCeldas("B" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 10)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 6) = "Mensual"
                Call CombinarCeldas("F" & CStr(Fila) & ":H" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 9) = "Acumulado"
                Call CombinarCeldas("I" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
                Call FormatoCelda("F" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)

                Fila = Fila + 1
                Obj_Hoja.Cells(Fila, 2) = "Código"
                Obj_Hoja.Cells(Fila, 3) = "Envase"
                Call CombinarCeldas("C" & CStr(Fila) & ":E" & CStr(Fila), Alineacion.Centrado)
                Obj_Hoja.Cells(Fila, 6) = "Cantidad"
                Obj_Hoja.Cells(Fila, 7) = "Costo x Und"
                Obj_Hoja.Cells(Fila, 8) = "SubTotal(S/.)"
                Obj_Hoja.Cells(Fila, 9) = "Cantidad"
                Obj_Hoja.Cells(Fila, 10) = "Costo x Und"
                Obj_Hoja.Cells(Fila, 11) = "SubTotal(S/.)"
                FilaRuma = Fila
                Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)

                For r = 0 To dsEnvases.Tables(0).Rows.Count - 1
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 2).NumberFormat = "@"
                    Obj_Hoja.Cells(Fila, 2) = dsEnvases.Tables(0).Rows(r).Item("Codigo").ToString.Trim
                    Obj_Hoja.Cells(Fila, 3) = dsEnvases.Tables(0).Rows(r).Item("Descripcion").ToString.Trim
                    Call CombinarCeldas("C" & CStr(Fila) & ":E" & CStr(Fila), Alineacion.Izquierda)
                    Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 6) = Val(dsEnvases.Tables(0).Rows(r).Item("Cantidad").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = Val(dsEnvases.Tables(0).Rows(r).Item("CostoUnitario").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = Val(dsEnvases.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = Val(dsEnvases.Tables(0).Rows(r).Item("CantAcum").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = Val(dsEnvases.Tables(0).Rows(r).Item("CostoUnitarioAcum").ToString.Trim)
                    Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 11) = Val(dsEnvases.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)

                    Call FormatoCelda("B" & CStr(Fila) & ":H" & CStr(Fila), "Arial", False, 8, , 1)
                    Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

                    TotalCostoEnvases = TotalCostoEnvases + Val(dsEnvases.Tables(0).Rows(r).Item("SubTotal").ToString.Trim)
                    TotalCostoEnvasesAcum = TotalCostoEnvasesAcum + Val(dsEnvases.Tables(0).Rows(r).Item("SubTotalAcum").ToString.Trim)
                Next

                If (Fila) - (FilaRuma + 1) > 0 Then
                    Fila = Fila + 1
                    Obj_Hoja.Cells(Fila, 6).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 6) = "=SUM(F" & CStr(FilaRuma) & ":F" & CStr(Fila - 1) & ")"
                    Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 7) = "=H" & CStr(Fila) & "/F" & CStr(Fila)
                    Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 8) = "=SUM(H" & CStr(FilaRuma) & ":H" & CStr(Fila - 1) & ")"
                    Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 9) = "=SUM(I" & CStr(FilaRuma) & ":I" & CStr(Fila - 1) & ")"
                    Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/I" & CStr(Fila)
                    Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                    Obj_Hoja.Cells(Fila, 11) = "=SUM(K" & CStr(FilaRuma) & ":K" & CStr(Fila - 1) & ")"
                    Call FormatoCelda("F" & CStr(Fila) & ":H" & CStr(Fila), "Arial", True, 8, , 1)
                    Call FormatoCelda("I" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)
                End If

            End If

            Fila = Fila + 3

            lblEstado.Text = "Exportando Molino: " & DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString & " - " & DsProduccion.Tables(0).Rows(i).Item("Molino").ToString
            lblCosteo.Text = "Exportando el Resumen del Costeo del Molino"
            lblDetalle.Text = ""
            Application.DoEvents()

            Obj_Hoja.Cells(Fila, 2) = "RESUMEN"
            Call CombinarCeldas("B" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 10)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 8) = "Mensual"
            Call CombinarCeldas("H" & CStr(Fila) & ":I" & CStr(Fila), Alineacion.Centrado)
            Obj_Hoja.Cells(Fila, 10) = "Acumulado"
            Call CombinarCeldas("J" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("H" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "Descripción"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
            Obj_Hoja.Cells(Fila, 8) = "Costo x TON"
            Obj_Hoja.Cells(Fila, 9) = "Valor"
            Obj_Hoja.Cells(Fila, 10) = "Costo x TON"
            Obj_Hoja.Cells(Fila, 11) = "Valor"
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "CANTIDAD PRODUCIDA (TON)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 11) = TotalProdMolino
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)
            FilaRuma = Fila

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA RUMA Y/O PROD. TERMINADO Y/O SUMINISTRO(S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoRuma
            Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 11) = TotalCostoRumaAcum
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE HOMOGENIZACIÓN DE SILICE (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoSiliceHomog
            Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 11) = TotalCostoSiliceHomogAcum
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA CHANCADORA (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoChancadora
            Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 11) = TotalCostoChancadoraAcum
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DEL CARGADOR FRONTAL (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoPala
            Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 11) = TotalCostoPalaAcum
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA MANO DE OBRA (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalManoObra
            Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 11) = TotalManoObraAcum
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DEL MANTENIMIENTO MECÁNICO (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoManttoMecanico
            Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 11) = TotalCostoManttoMecanicoAcum
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA DEPRECIACIÓN (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoDepreciacion
            Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 11) = TotalCostoDepreciacionAcum
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA ENERGÍA (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoEnergia
            Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 11) = TotalCostoEnergiaAcum
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DEL GAS NATURAL (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoGasNatural
            Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 11) = TotalCostoGasNaturalAcum
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO DEL ENVASE (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = TotalCostoEnvases
            Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaRuma)
            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 11) = TotalCostoEnvasesAcum
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO X MOLINO (S/.)"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            CostoxMolino = TotalCostoRuma + TotalCostoSiliceHomog + TotalCostoChancadora + TotalCostoPala
            CostoxMolino = CostoxMolino + TotalManoObra + TotalCostoManttoMecanico
            CostoxMolino = CostoxMolino + TotalCostoDepreciacion + TotalCostoEnergia
            CostoxMolino = CostoxMolino + TotalCostoGasNatural + TotalCostoEnvases
            CostoxMolinoAcum = TotalCostoRumaAcum + TotalCostoSiliceHomogAcum + TotalCostoChancadoraAcum + TotalCostoPalaAcum
            CostoxMolinoAcum = CostoxMolinoAcum + TotalManoObraAcum + TotalCostoManttoMecanicoAcum
            CostoxMolinoAcum = CostoxMolinoAcum + TotalCostoDepreciacionAcum + TotalCostoEnergiaAcum
            CostoxMolinoAcum = CostoxMolinoAcum + TotalCostoGasNaturalAcum + TotalCostoEnvasesAcum

            Obj_Hoja.Cells(Fila, 9) = CostoxMolino
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 11) = CostoxMolinoAcum
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)
            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "COSTO X TON"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
            Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 9) = CostoxMolino / Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
            Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 11) = CostoxMolinoAcum / TotalProdMolino
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)
            Resumen_Ruma = Resumen_Ruma + TotalCostoRuma
            Resumen_SiliceHomogenizada = Resumen_SiliceHomogenizada + TotalCostoSiliceHomog
            Resumen_Chancadora = Resumen_Chancadora + TotalCostoChancadora
            Resumen_Cargador_Frontal = Resumen_Cargador_Frontal + TotalCostoPala
            Resumen_ManoObra = Resumen_ManoObra + TotalManoObra
            Resumen_ManttoMecanico = Resumen_ManttoMecanico + TotalCostoManttoMecanico
            Resumen_Depreciacion = Resumen_Depreciacion + TotalCostoDepreciacion
            Resumen_Energia = Resumen_Energia + TotalCostoEnergia
            Resumen_GasNatural = Resumen_GasNatural + TotalCostoGasNatural
            Resumen_Envases = Resumen_Envases + TotalCostoEnvases

            Resumen_Ruma_Acum = Resumen_Ruma_Acum + TotalCostoRumaAcum
            Resumen_SiliceHomogenizada_Acum = Resumen_SiliceHomogenizada_Acum + TotalCostoSiliceHomogAcum
            Resumen_Chancadora_Acum = Resumen_Chancadora_Acum + TotalCostoChancadoraAcum
            Resumen_Cargador_Frontal_Acum = Resumen_Cargador_Frontal_Acum + TotalCostoPalaAcum
            Resumen_ManoObra_Acum = Resumen_ManoObra_Acum + TotalManoObraAcum
            Resumen_ManttoMecanico_Acum = Resumen_ManttoMecanico_Acum + TotalCostoManttoMecanicoAcum
            Resumen_Depreciacion_Acum = Resumen_Depreciacion_Acum + TotalCostoDepreciacionAcum
            Resumen_Energia_Acum = Resumen_Energia_Acum + TotalCostoEnergiaAcum
            Resumen_GasNatural_Acum = Resumen_GasNatural_Acum + TotalCostoGasNaturalAcum
            Resumen_Envases_Acum = Resumen_Envases_Acum + TotalCostoEnvasesAcum
            Resumen_ProduccionProducto = Resumen_ProduccionProducto + TotalProdMolino

            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodEnlace = CodEnlace
                .CodProducto = Txt1.Text.Trim
                .CodMolino = DsProduccion.Tables(0).Rows(i).Item("CodMolino").ToString.TrimEnd
                .Usuario = User_Sistema
                .Spid = Spid
                .Cod_Planta = Val(DsProduccion.Tables(0).Rows(i).Item("LinProd").ToString)
                .FechaInicio = FechaInicioAño
                .FechaTerminacion = FechaTermino
                .Cod_Alm = "19"

            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            Negocio.CosteoProduccion.Consultar_Produccion_Generico_Delete(Entidad.Orden)

        Next
    End Sub

    Private Sub CargarCosteoProduccion()
        Dim i As Integer = 0

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .Cod_Cia = Companhia
            .FechaInicio = FechaInicio
            .FechaTerminacion = FechaTermino
            .CodProducto = Txt1.Text.Trim

        End With

        Negocio.CosteoProduccion = New NGCosteoProduccion
        DsProduccion = Negocio.CosteoProduccion.Consultar_Produccion(Entidad.Orden)

        If DsProduccion.Tables(0).Rows.Count > 2 Then
            For i = 1 To DsProduccion.Tables(0).Rows.Count - 2
                With Obj_Libro
                    Obj_Libro.Sheets.Add()
                End With
            Next
        End If


        TotalProduccion = 0
        UnidadProd = ""


        CodEnlace = 0
        For i = 0 To DsProduccion.Tables(0).Rows.Count - 1
            TotalProduccion = TotalProduccion + Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
            CodEnlace = Val(DsProduccion.Tables(0).Rows(i).Item("Enlace").ToString)
            UnidadProd = DsProduccion.Tables(0).Rows(i).Item("UndProd").ToString
            UnidadProd = UnidadProd & " ("
            UnidadProd = UnidadProd & DsProduccion.Tables(0).Rows(i).Item("Peso").ToString & Space(1)
            UnidadProd = UnidadProd & DsProduccion.Tables(0).Rows(i).Item("UndPeso").ToString
            UnidadProd = UnidadProd & " )"
        Next

    End Sub

    Private Sub CargarCosteoProduccion_Cierre()
        Dim i As Integer = 0

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .Cod_Cia = Companhia
            .FechaInicio = FechaInicio
            .FechaTerminacion = FechaTermino
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
            .CodMolino = Txt3.Text.Trim
            .Cantidad = Txt5.Value
            If Rbt5.Checked = True Then
                .Proyeccion = True
            End If

        End With

        Negocio.CosteoProduccion = New NGCosteoProduccion
        DsProduccion = Negocio.CosteoProduccion.Consultar_Produccion_Cierre(Entidad.Orden)

        If DsProduccion.Tables(0).Rows.Count > 2 Then
            For i = 1 To DsProduccion.Tables(0).Rows.Count - 2
                With Obj_Libro
                    Obj_Libro.Sheets.Add()
                End With
            Next
        End If


        TotalProduccion = 0
        UnidadProd = ""


        CodEnlace = 0
        For i = 0 To DsProduccion.Tables(0).Rows.Count - 1
            TotalProduccion = TotalProduccion + Val(DsProduccion.Tables(0).Rows(i).Item("Cantidad").ToString)
            CodEnlace = Val(DsProduccion.Tables(0).Rows(i).Item("Enlace").ToString)
            UnidadProd = DsProduccion.Tables(0).Rows(i).Item("UndProd").ToString
            UnidadProd = UnidadProd & " ("
            UnidadProd = UnidadProd & DsProduccion.Tables(0).Rows(i).Item("Peso").ToString & Space(1)
            UnidadProd = UnidadProd & DsProduccion.Tables(0).Rows(i).Item("UndPeso").ToString
            UnidadProd = UnidadProd & " )"
        Next



    End Sub

    Private Sub CrearResumen_Cierre()
        'Dim dsResumen As DataSet
        Dim FilaTemp As Integer = 0

        Obj_Libro.Sheets(1).Name = "Resumen"


        If DsProduccion.Tables(0).Rows.Count <= 0 Then
            Call CrearResumen_Cierre_MesSinProd()
            Exit Sub
        End If

        Obj_Hoja = Obj_Libro.Sheets(1)
        Obj_Hoja.Activate()

        Fila = 1
        Obj_Hoja.Cells(Fila, 2) = "Cía Minera Agregados Calcareos S.A."

        Fila = 3
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE PRODUCCION (S/.) " & NameMes(Month(FechaInicio)) & " " & Year(FechaTermino)
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
        Call FormatoCelda("B" & CStr(Fila) & ":G" & CStr(Fila), "Arial", True, 14)

        Fila = 5

        Obj_Hoja.Cells(Fila, 2) = "Producto: "
        Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
        Obj_Hoja.Cells(Fila, 3) = Me.Txt1.Text.Trim
        Obj_Hoja.Cells(Fila, 4) = Me.Txt2.Text.Trim
        Call FormatoCelda("B" & CStr(Fila) & ":B" & CStr(Fila + 2), "Arial", True, 8)
        Call FormatoCelda("C" & CStr(Fila) & ":G" & CStr(Fila + 2), "Arial", False, 8)
        Fila = 6
        Obj_Hoja.Cells(Fila, 2) = "Und.Prod.: "
        Obj_Hoja.Cells(Fila, 3) = Me.UnidadProd
        Obj_Hoja.Cells(Fila, 6) = "Enlace:"
        Obj_Hoja.Cells(Fila, 7) = CodEnlace
        Call FormatoCelda("F" & CStr(Fila) & ":F" & CStr(Fila), "Arial", True, 8)

        Fila = 7
        Obj_Hoja.Cells(Fila, 2) = "Producción: "
        Obj_Hoja.Cells(Fila, 3).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 3) = Me.TotalProduccion

        Obj_Hoja.Cells(Fila, 6) = "Prod. Planta:"
        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 7) = Me.TotalPlanta
        Call FormatoCelda("F" & CStr(Fila) & ":F" & CStr(Fila), "Arial", True, 8)


        Fila = 9
        Obj_Hoja.Cells(Fila, 2) = "RESUMEN"
        Call CombinarCeldas("B" & CStr(Fila) & ":I" & CStr(Fila), Alineacion.Centrado)
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 10)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 8) = "Mensual"
        Call CombinarCeldas("H" & CStr(Fila) & ":I" & CStr(Fila), Alineacion.Centrado)
        Call FormatoCelda("H" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "Descripción"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
        Obj_Hoja.Cells(Fila, 8) = "Costo x TON"
        Obj_Hoja.Cells(Fila, 9) = "Valor"
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "CANTIDAD PRODUCIDA (TON)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = TotalProduccion
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
        FilaTemp = Fila

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = TotalProduccion
            .TotalMolino = Resumen_ProduccionProducto
            .Concepto = "01"
            .Descripcion = "CANTIDAD PRODUCIDA (TON)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA RUMA Y/O PROD. TERMINADO Y/O SUMINISTRO(S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_Ruma
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
        If TotalProduccion = 0 Then TotalProduccion = 1
        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = Resumen_Ruma
            .CostoxTON = Resumen_Ruma / TotalProduccion
            .TotalMolino = Resumen_Ruma_Acum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = Resumen_Ruma_Acum / Resumen_ProduccionProducto
            End If

            .Concepto = "02"
            .Descripcion = "COSTO DE LA RUMA Y/O PROD. TERMINADO Y/O SUMINISTRO(S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE HOMOGENIZACIÓN DE SILICE (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_SiliceHomogenizada
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = Resumen_SiliceHomogenizada
            .CostoxTON = Resumen_SiliceHomogenizada / TotalProduccion
            .TotalMolino = Resumen_SiliceHomogenizada_Acum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = Resumen_SiliceHomogenizada_Acum / Resumen_ProduccionProducto
            End If

            .Concepto = "03"
            .Descripcion = "COSTO DE HOMOGENIZACIÓN DE SILICE (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)


        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA CHANCADORA (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_Chancadora
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = Resumen_Chancadora
            .CostoxTON = Resumen_Chancadora / TotalProduccion
            .TotalMolino = Resumen_Chancadora_Acum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = Resumen_Chancadora_Acum / Resumen_ProduccionProducto
            End If

            .Concepto = "04"
            .Descripcion = "COSTO DE LA CHANCADORA (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DEL CARGADOR FRONTAL (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_Cargador_Frontal
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = Resumen_Cargador_Frontal
            .CostoxTON = Resumen_Cargador_Frontal / TotalProduccion
            .TotalMolino = Resumen_Cargador_Frontal_Acum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = Resumen_Cargador_Frontal_Acum / Resumen_ProduccionProducto
            End If

            .Concepto = "05"
            .Descripcion = "COSTO DEL CARGADOR FRONTAL (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA MANO DE OBRA (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_ManoObra
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = Resumen_ManoObra
            .CostoxTON = Resumen_ManoObra / TotalProduccion
            .TotalMolino = Resumen_ManoObra_Acum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = Resumen_ManoObra_Acum / Resumen_ProduccionProducto
            End If

            .Concepto = "06"
            .Descripcion = "COSTO DE LA MANO DE OBRA (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DEL MANTENIMIENTO MECÁNICO (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_ManttoMecanico
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = Resumen_ManttoMecanico
            .CostoxTON = Resumen_ManttoMecanico / TotalProduccion
            .TotalMolino = Resumen_ManttoMecanico_Acum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = Resumen_ManttoMecanico_Acum / Resumen_ProduccionProducto
            End If

            .Concepto = "07"
            .Descripcion = "COSTO DEL MANTENIMIENTO MECÁNICO (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA DEPRECIACIÓN (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_Depreciacion
        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = Resumen_Depreciacion
            .CostoxTON = Resumen_Depreciacion / TotalProduccion
            .TotalMolino = Resumen_Depreciacion_Acum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = Resumen_Depreciacion_Acum / Resumen_ProduccionProducto
            End If

            .Concepto = "08"
            .Descripcion = "COSTO DE LA DEPRECIACIÓN (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA ENERGÍA (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_Energia
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = Resumen_Energia
            .CostoxTON = Resumen_Energia / TotalProduccion
            .TotalMolino = Resumen_Energia_Acum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = Resumen_Energia_Acum / Resumen_ProduccionProducto
            End If

            .Concepto = "09"
            .Descripcion = "COSTO DE LA ENERGÍA (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DEL GAS NATURAL (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_GasNatural
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = Resumen_GasNatural
            .CostoxTON = Resumen_GasNatural / TotalProduccion
            .TotalMolino = Resumen_GasNatural_Acum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = Resumen_GasNatural_Acum / Resumen_ProduccionProducto
            End If

            .Concepto = "10"
            .Descripcion = "COSTO DEL GAS NATURAL (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DEL ENVASE (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_Envases
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = Resumen_Envases
            .CostoxTON = Resumen_Envases / TotalProduccion
            .TotalMolino = Resumen_Envases_Acum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = Resumen_Envases_Acum / Resumen_ProduccionProducto
            End If

            .Concepto = "11"
            .Descripcion = "COSTO DEL ENVASE (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE MANTENIMIENTO Y REPARACION DE MAQUINARIA PESADA  (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_ManttoReparacioMP
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = Resumen_ManttoReparacioMP
            .CostoxTON = Resumen_ManttoReparacioMP / TotalProduccion
            .TotalMolino = Resumen_ManttoReparacioMP_Acum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = Resumen_ManttoReparacioMP_Acum / Resumen_ProduccionProducto
            End If

            .Concepto = "18"
            .Descripcion = "COSTO DE MANTENIMIENTO Y REPARACION DE MAQUINARIA PESADA  (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "SOBRECOSTOS EMPLEADOS (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_SobrecostoEmpleado
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = Resumen_SobrecostoEmpleado
            .CostoxTON = Resumen_SobrecostoEmpleado / TotalProduccion
            .TotalMolino = Resumen_SobrecostoEmpleado_Acum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = Resumen_SobrecostoEmpleado_Acum / Resumen_ProduccionProducto
            End If

            .Concepto = "19"
            .Descripcion = "SOBRECOSTOS EMPLEADOS (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "SOBRECOSTOS OBREROS (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_SobrecostoObrero
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = Resumen_SobrecostoObrero
            .CostoxTON = Resumen_SobrecostoObrero / TotalProduccion
            .TotalMolino = Resumen_SobrecostoObrero_Acum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = Resumen_SobrecostoObrero_Acum / Resumen_ProduccionProducto
            End If

            .Concepto = "20"
            .Descripcion = "SOBRECOSTOS OBREROS (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO TOTAL (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        CostoTotal = Resumen_Ruma + Resumen_SiliceHomogenizada + Resumen_Chancadora + Resumen_Cargador_Frontal
        CostoTotal = CostoTotal + Resumen_ManoObra + Resumen_ManttoMecanico
        CostoTotal = CostoTotal + Resumen_Depreciacion + Resumen_Energia
        CostoTotal = CostoTotal + Resumen_GasNatural + Resumen_Envases
        CostoTotal = CostoTotal + Resumen_ManttoReparacioMP + Resumen_SobrecostoEmpleado + Resumen_SobrecostoObrero

        Obj_Hoja.Cells(Fila, 9) = CostoTotal
        CostoTotalAcum = Resumen_Ruma_Acum + Resumen_SiliceHomogenizada_Acum + Resumen_Chancadora_Acum + Resumen_Cargador_Frontal_Acum
        CostoTotalAcum = CostoTotalAcum + Resumen_ManoObra_Acum + Resumen_ManttoMecanico_Acum
        CostoTotalAcum = CostoTotalAcum + Resumen_Depreciacion_Acum + Resumen_Energia_Acum
        CostoTotalAcum = CostoTotalAcum + Resumen_GasNatural_Acum + Resumen_Envases_Acum
        CostoTotalAcum = CostoTotalAcum + Resumen_ManttoReparacioMP_Acum + Resumen_SobrecostoEmpleado_Acum
        CostoTotalAcum = CostoTotalAcum + Resumen_SobrecostoObrero_Acum

    
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = CostoTotal
            .CostoxTON = CostoTotal / TotalProduccion
            .TotalMolino = CostoTotalAcum
            If Resumen_ProduccionProducto > 0 Then
                .CostoxTONAcum = CostoTotalAcum / Resumen_ProduccionProducto
            End If

            .Concepto = "12"
            .Descripcion = "COSTO TOTAL (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO X TON (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = CostoTotal / TotalProduccion

        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = CostoTotal / TotalProduccion
            If Resumen_ProduccionProducto > 0 Then
                .TotalMolino = CostoTotalAcum / Resumen_ProduccionProducto
            End If

            .Concepto = "13"
            .Descripcion = "COSTO X TON (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "PRECIO VENTA MAXIMO (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = PrecioMaximo
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = PrecioMaximo
            .Concepto = "14"
            .Descripcion = "PRECIO VENTA MAXIMO (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "PRECIO VENTA MINIMO (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = PrecioMinimo
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = PrecioMinimo
            .Concepto = "15"
            .Descripcion = "PRECIO VENTA MINIMO (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "PRECIO VENTA PROMEDIO (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = PrecioPromedio
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = PrecioPromedio
            .Concepto = "16"
            .Descripcion = "PRECIO VENTA PROMEDIO (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "UTILIDAD X TON (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = PrecioPromedio - CostoTotal / TotalProduccion
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .CodProducto = Txt1.Text.Trim
            .Usuario = User_Sistema
            .ValorxDecimal = PrecioPromedio - CostoTotal / TotalProduccion
            .Concepto = "17"
            .Descripcion = "UTILIDAD X TON (S/.)"
            .FechaTerminacion = FechaTermino
        End With
        Ls_CosteoProducto.Add(Entidad.Orden)

        If Rbt3.Checked Then
            Entidad.Orden = New ETOrden
            With Entidad.Orden
                .CodProducto = Txt1.Text.Trim
                .Anho = Year(FechaTermino)
                .Mes = Month(FechaTermino)
                .Usuario = User_Sistema
                .FechaTerminacion = FechaTermino
            End With
            Negocio.CosteoProduccion = New NGCosteoProduccion
            Negocio.CosteoProduccion.Consultar_Produccion_Resumen(Entidad.Orden, Ls_CosteoProducto, Ls_CosteoMolino)
        End If


    End Sub

    Private Sub CrearResumen_Cierre_MesSinProd()
        Dim i As Integer = 0
        'Dim dsResumen As DataSet
        Dim FilaTemp As Integer = 0

        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .Cod_Cia = Companhia
            .FechaInicio = FechaInicio
            .FechaTerminacion = FechaTermino
            .CodProducto = Txt1.Text.Trim
            .Anho = Year(FechaTermino)
            .Mes = Month(FechaTermino)
            .Usuario = User_Sistema
            .Cierre = IIf(Rbt3.Checked = True Or Rbt5.Checked = True, "2", "1")
        End With

        Negocio.CosteoProduccion = New NGCosteoProduccion
        DsProduccion = Negocio.CosteoProduccion.Consultar_Produccion_MesSinProd_Cierre(Entidad.Orden)

        If DsProduccion.Tables(0).Rows.Count > 0 Then
            Obj_Libro.Sheets(1).Name = "Resumen"

            If DsProduccion.Tables(0).Rows.Count <= 0 Then Exit Sub
            Obj_Hoja = Obj_Libro.Sheets(1)
            Obj_Hoja.Activate()

            Fila = 1
            Obj_Hoja.Cells(Fila, 2) = "Cía Minera Agregados Calcareos S.A."

            Fila = 3
            Obj_Hoja.Cells(Fila, 2) = "COSTO DE PRODUCCION (S/.) " & NameMes(Month(FechaInicio)) & " " & Year(FechaTermino)
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("B" & CStr(Fila) & ":G" & CStr(Fila), "Arial", True, 14)

            Fila = 5

            Obj_Hoja.Cells(Fila, 2) = "Producto: "
            Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
            Obj_Hoja.Cells(Fila, 3) = Me.Txt1.Text.Trim
            Obj_Hoja.Cells(Fila, 4) = Me.Txt2.Text.Trim
            Call FormatoCelda("B" & CStr(Fila) & ":B" & CStr(Fila + 2), "Arial", True, 8)
            Call FormatoCelda("C" & CStr(Fila) & ":G" & CStr(Fila + 2), "Arial", False, 8)

            TotalProduccion = Val(DsProduccion.Tables(0).Rows(i).Item("Produccion").ToString)
            CodEnlace = Val(DsProduccion.Tables(0).Rows(i).Item("Enlace").ToString)
            UnidadProd = DsProduccion.Tables(0).Rows(i).Item("UndProd").ToString
            UnidadProd = UnidadProd & " ("
            UnidadProd = UnidadProd & DsProduccion.Tables(0).Rows(i).Item("Peso").ToString & Space(1)
            UnidadProd = UnidadProd & DsProduccion.Tables(0).Rows(i).Item("UndPeso").ToString
            UnidadProd = UnidadProd & " )"
            TotalPlanta = Val(DsProduccion.Tables(0).Rows(i).Item("TotalPlanta").ToString)

            Fila = 6
            Obj_Hoja.Cells(Fila, 2) = "Und.Prod.: "
            Obj_Hoja.Cells(Fila, 3) = Me.UnidadProd
            Obj_Hoja.Cells(Fila, 6) = "Enlace:"
            Obj_Hoja.Cells(Fila, 7) = CodEnlace
            Call FormatoCelda("F" & CStr(Fila) & ":F" & CStr(Fila), "Arial", True, 8)

            Fila = 7
            Obj_Hoja.Cells(Fila, 2) = "Producción: "
            Obj_Hoja.Cells(Fila, 3).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 3) = Me.TotalProduccion

            Obj_Hoja.Cells(Fila, 6) = "Prod. Planta:"
            Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
            Obj_Hoja.Cells(Fila, 7) = Me.TotalPlanta
            Call FormatoCelda("F" & CStr(Fila) & ":F" & CStr(Fila), "Arial", True, 8)

            Fila = 9
            Obj_Hoja.Cells(Fila, 2) = "RESUMEN"
            Call CombinarCeldas("B" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 10)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 8) = "Mensual"
            Call CombinarCeldas("H" & CStr(Fila) & ":I" & CStr(Fila), Alineacion.Centrado)
            Obj_Hoja.Cells(Fila, 10) = "Acumulado"
            Call CombinarCeldas("J" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
            Call FormatoCelda("H" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)

            Fila = Fila + 1
            Obj_Hoja.Cells(Fila, 2) = "Descripción"
            Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
            Obj_Hoja.Cells(Fila, 8) = "Costo x TON"
            Obj_Hoja.Cells(Fila, 9) = "Valor"
            Obj_Hoja.Cells(Fila, 10) = "Costo x TON"
            Obj_Hoja.Cells(Fila, 11) = "Valor"
            Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
            Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)

            For i = 0 To DsProduccion.Tables(0).Rows.Count - 1

                Select Case DsProduccion.Tables(0).Rows(i).Item("Concepto").ToString.TrimEnd
                    Case "01"
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = DsProduccion.Tables(0).Rows(i).Item("Descripcion").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(DsProduccion.Tables(0).Rows(i).Item("Valor").ToString)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(DsProduccion.Tables(0).Rows(i).Item("ValorAcum").ToString)
                        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
                        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)
                        FilaTemp = Fila
                    Case "02", "03", "04", "05", "06", "07", "08", "09", "10", "11"
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = DsProduccion.Tables(0).Rows(i).Item("Descripcion").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 8) = Val(DsProduccion.Tables(0).Rows(i).Item("CostoxTON").ToString)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(DsProduccion.Tables(0).Rows(i).Item("Valor").ToString)
                        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 10) = Val(DsProduccion.Tables(0).Rows(i).Item("CostoxTONAcum").ToString)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(DsProduccion.Tables(0).Rows(i).Item("ValorAcum").ToString)
                        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
                        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)
                    Case "12", "13"
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = DsProduccion.Tables(0).Rows(i).Item("Descripcion").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(DsProduccion.Tables(0).Rows(i).Item("Valor").ToString)
                        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 11) = Val(DsProduccion.Tables(0).Rows(i).Item("ValorAcum").ToString)
                        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
                        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)

                    Case "14", "15"
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = DsProduccion.Tables(0).Rows(i).Item("Descripcion").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(DsProduccion.Tables(0).Rows(i).Item("Valor").ToString)
                        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
                    Case "16", "17"
                        Fila = Fila + 1
                        Obj_Hoja.Cells(Fila, 2) = DsProduccion.Tables(0).Rows(i).Item("Descripcion").ToString.TrimEnd
                        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
                        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
                        Obj_Hoja.Cells(Fila, 9) = Val(DsProduccion.Tables(0).Rows(i).Item("Valor").ToString)
                        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
                End Select

            Next
        End If

    End Sub

    Private Sub CrearResumen()
        'Dim dsResumen As DataSet
        Dim FilaTemp As Integer = 0

        Obj_Libro.Sheets(1).Name = "Resumen"


        If DsProduccion.Tables(0).Rows.Count <= 0 Then Exit Sub
        Obj_Hoja = Obj_Libro.Sheets(1)
        Obj_Hoja.Activate()

        Fila = 1
        Obj_Hoja.Cells(Fila, 2) = "Cía Minera Agregados Calcareos S.A."

        Fila = 3
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE PRODUCCION (S/.) " & NameMes(Month(FechaInicio)) & " " & Year(FechaTermino)
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
        Call FormatoCelda("B" & CStr(Fila) & ":G" & CStr(Fila), "Arial", True, 14)


        Fila = 5
        Obj_Hoja.Cells(Fila, 2) = "Producto: "
        Obj_Hoja.Cells(Fila, 3).NumberFormat = "@"
        Obj_Hoja.Cells(Fila, 3) = Me.Txt1.Text.Trim
        Obj_Hoja.Cells(Fila, 4) = Me.Txt2.Text.Trim
        Call FormatoCelda("B" & CStr(Fila) & ":B" & CStr(Fila + 2), "Arial", True, 8)
        Call FormatoCelda("C" & CStr(Fila) & ":G" & CStr(Fila + 2), "Arial", False, 8)
        Fila = 6
        Obj_Hoja.Cells(Fila, 2) = "Und.Prod.: "
        Obj_Hoja.Cells(Fila, 3) = Me.UnidadProd
        Obj_Hoja.Cells(Fila, 6) = "Enlace:"
        Obj_Hoja.Cells(Fila, 7) = CodEnlace
        Call FormatoCelda("F" & CStr(Fila) & ":F" & CStr(Fila), "Arial", True, 8)

        Fila = 7
        Obj_Hoja.Cells(Fila, 2) = "Producción: "
        Obj_Hoja.Cells(Fila, 3).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 3) = Me.TotalProduccion

        Obj_Hoja.Cells(Fila, 6) = "Prod. Planta:"
        Obj_Hoja.Cells(Fila, 7).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 7) = Me.TotalPlanta
        Call FormatoCelda("F" & CStr(Fila) & ":F" & CStr(Fila), "Arial", True, 8)


        Fila = 9
        Obj_Hoja.Cells(Fila, 2) = "RESUMEN"
        Call CombinarCeldas("B" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
        Call FormatoCelda("B" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 10)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 8) = "Mensual"
        Call CombinarCeldas("H" & CStr(Fila) & ":I" & CStr(Fila), Alineacion.Centrado)
        Obj_Hoja.Cells(Fila, 10) = "Acumulado"
        Call CombinarCeldas("J" & CStr(Fila) & ":K" & CStr(Fila), Alineacion.Centrado)
        Call FormatoCelda("H" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "Descripción"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Centrado)
        Obj_Hoja.Cells(Fila, 8) = "Costo x TON"
        Obj_Hoja.Cells(Fila, 9) = "Valor"
        Obj_Hoja.Cells(Fila, 10) = "Costo x TON"
        Obj_Hoja.Cells(Fila, 11) = "Valor"
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "CANTIDAD PRODUCIDA (TON)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = TotalProduccion
        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 11) = Resumen_ProduccionProducto
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)
        FilaTemp = Fila

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA RUMA Y/O PROD. TERMINADO Y/O SUMINISTRO(S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_Ruma
        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 11) = Resumen_Ruma_Acum
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE HOMOGENIZACIÓN DE SILICE (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_SiliceHomogenizada
        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 11) = Resumen_SiliceHomogenizada_Acum
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA CHANCADORA (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_Chancadora
        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 11) = Resumen_Chancadora_Acum
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DEL CARGADOR FRONTAL (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_Cargador_Frontal
        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 11) = Resumen_Cargador_Frontal_Acum
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA MANO DE OBRA (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_ManoObra
        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 11) = Resumen_ManoObra_Acum
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DEL MANTENIMIENTO MECÁNICO (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_ManttoMecanico
        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 11) = Resumen_ManttoMecanico_Acum
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA DEPRECIACIÓN (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_Depreciacion
        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 11) = Resumen_Depreciacion_Acum
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DE LA ENERGÍA (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_Energia
        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 11) = Resumen_Energia_Acum
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DEL GAS NATURAL (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_GasNatural
        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 11) = Resumen_GasNatural_Acum
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO DEL ENVASE (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 8).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 8) = "=I" & CStr(Fila) & "/I" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = Resumen_Envases
        Obj_Hoja.Cells(Fila, 10).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 10) = "=K" & CStr(Fila) & "/K" & CStr(FilaTemp)
        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 11) = Resumen_Envases_Acum
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", False, 8, , 1, 19)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO TOTAL (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        CostoTotal = Resumen_Ruma + Resumen_SiliceHomogenizada + Resumen_Chancadora + Resumen_Cargador_Frontal
        CostoTotal = CostoTotal + Resumen_ManoObra + Resumen_ManttoMecanico
        CostoTotal = CostoTotal + Resumen_Depreciacion + Resumen_Energia
        CostoTotal = CostoTotal + Resumen_GasNatural + Resumen_Envases
        Obj_Hoja.Cells(Fila, 9) = CostoTotal
        CostoTotalAcum = Resumen_Ruma_Acum + Resumen_SiliceHomogenizada_Acum + Resumen_Chancadora_Acum + Resumen_Cargador_Frontal_Acum
        CostoTotalAcum = CostoTotalAcum + Resumen_ManoObra_Acum + Resumen_ManttoMecanico_Acum
        CostoTotalAcum = CostoTotalAcum + Resumen_Depreciacion_Acum + Resumen_Energia_Acum
        CostoTotalAcum = CostoTotalAcum + Resumen_GasNatural_Acum + Resumen_Envases_Acum

        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 11) = CostoTotalAcum
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)
        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "COSTO X TON (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = CostoTotal / TotalProduccion
        Obj_Hoja.Cells(Fila, 11).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 11) = CostoTotalAcum / Resumen_ProduccionProducto
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)
        Call FormatoCelda("J" & CStr(Fila) & ":K" & CStr(Fila), "Arial", True, 8, , 1, 19)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "PRECIO VENTA MAXIMO (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = PrecioMaximo
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "PRECIO VENTA MINIMO (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = PrecioMinimo
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", False, 8, , 1)


        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "PRECIO VENTA PROMEDIO (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = PrecioPromedio
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)

        Fila = Fila + 1
        Obj_Hoja.Cells(Fila, 2) = "UTILIDAD X TON (S/.)"
        Call CombinarCeldas("B" & CStr(Fila) & ":G" & CStr(Fila), Alineacion.Izquierda)
        Obj_Hoja.Cells(Fila, 9).NumberFormat = "#,##0.0000"
        Obj_Hoja.Cells(Fila, 9) = PrecioPromedio - CostoTotal / TotalProduccion
        Call FormatoCelda("B" & CStr(Fila) & ":I" & CStr(Fila), "Arial", True, 8, , 1)

    End Sub

    Private Sub FormatoCelda(ByVal RANGO As String, ByVal TipoLetra As String, _
    ByVal Negrita As Boolean, ByVal TamañoLetra As Integer, Optional ByVal color As Integer = 0, _
    Optional ByVal Linea As Integer = 0, Optional ByVal Relleno As Integer = 0)

        With Obj_Hoja.range(RANGO)
            .Font.Name = TipoLetra
            .Font.Bold = Negrita
            .Font.Size = TamañoLetra
            If Val(color) > 0 Then .Font.ColorIndex = color
            If Val(Linea) > 0 Then .Borders.LineStyle = Linea
            If Val(Relleno) > 0 Then .Interior.ColorIndex = Relleno

        End With
    End Sub

    Private Sub CombinarCeldas(ByVal RANGO As String, ByVal Alinear As Long)
        Obj_Excel.range(RANGO).Select()
        ' Estableces MergeCells a True para combinar Y false para descombinar las celdas
        Obj_Excel.Selection.MergeCells = True
        Obj_Excel.range(RANGO).HorizontalAlignment = Alinear
        Obj_Excel.range(RANGO).VerticalAlignment = -4108 'Alineacion.Centrado
        Obj_Excel.ActiveCell.WrapText = True

        'Obj_Hoja

    End Sub

    Private Sub Reporte_ProductoMinerales()

        StrucForm.FxRxReporte = New FrmBReporte
        Entidad.Orden = New ETOrden
        With Entidad.Orden
            .Cod_Cia = Companhia
            If Txt1.Text.Trim = "" Then
                .CodProducto = "*"
            Else
                .CodProducto = Txt1.Text.Trim
            End If

        End With

        StrucForm.FxRxReporte.NumReporte = VarReporte.ProductoxMinerales
        StrucForm.FxRxReporte.TextReporte = "REPORTE DE MINERALES EN PRODUCTOS TERMINADOS"
        StrucForm.FxRxReporte.DatosReporte = Entidad.Orden
        StrucForm.FxRxReporte.MdiParent = MdiParent
        StrucForm.FxRxReporte.Show()

    End Sub

    Private Sub Rbt5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbt5.CheckedChanged
        Lbl1.Visible = Rbt5.Checked
        Lbl2.Visible = Rbt5.Checked
        Txt3.Clear()
        Txt3.Visible = Rbt5.Checked
        Txt4.Clear()
        Txt4.Visible = Rbt5.Checked
        Txt5.Value = 0
        Txt5.Visible = Rbt5.Checked
    End Sub


End Class