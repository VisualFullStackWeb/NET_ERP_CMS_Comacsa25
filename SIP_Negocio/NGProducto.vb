Imports SIP_Entidad
Imports SIP_Datos
Imports System.Threading
Imports System.Text.RegularExpressions

Public Class NGProducto

    Private Shared ET_Producto As ETProducto
    Private strCodSuminstro As String = String.Empty
    Private Shared ListaSuministro As List(Of ETSuministro)
    Private ListaProducto As List(Of ETProducto)
    Private ListaRuma As List(Of ETRuma)
    Private MaxPorcentaje As Decimal = Decimal.Zero
    Private Shared ListaVenta As List(Of ETProducto)
    Private Hilo() As Thread
    Private SubClase() As ClsLotes
    Private Item As Int16 = 0
    Private DecPorc As Decimal = Decimal.Zero
    Private _CPy As Decimal = Decimal.Zero
    Private _CSv As Decimal = Decimal.Zero

    Private Enum MensajeValidarProductoOrden
        Enlace = 1
        Empaque = 2
        Chancadora = 3
        Molino = 4
    End Enum

    Public Function ConsultarProducto(ByVal Rpt As ETProducto) As DataTable

        'Return Datos.Producto.ConsultarProductoJS(Rpt)
        'add jcms 070623 corrige consulta de productos que no se uestra en el modulo de formulacion de produccion
        Return Datos.Producto.ConsultarProducto(Rpt)

    End Function
    Public Function ConsultarSubfamilia(ByVal Rpt As ETProducto) As DataTable

        Return Datos.Producto.ConsultarSubfamilia(Rpt)

    End Function
    Public Function Consultarfamilia(ByVal Rpt As ETProducto) As DataTable

        Return Datos.Producto.Consultarfamilia(Rpt)

    End Function

    Public Function ConsultarProductoJS(ByVal Rpt As ETProducto) As DataTable

        Return Datos.Producto.ConsultarProductoJS(Rpt)

    End Function

    Public Function ConsultarProductoxStock(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

Ingreso:
        lResult = New ETMyLista

        If Not IsDate(Rpt.Fecha) Then
            MsgBox("Ingrese la Fecha", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If
        If String.IsNullOrEmpty(Rpt.CodProducto) Then
            Rpt.CodProducto = String.Empty
        End If
        If String.IsNullOrEmpty(Rpt.Descripcion) Then
            Rpt.Descripcion = String.Empty
        End If
        If String.IsNullOrEmpty(Rpt.CodAlmacen) Then
            MsgBox("Seleccione el Almacen", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If
        If String.IsNullOrEmpty(Rpt.TipoProducto) Then
            MsgBox("Seleccione el Tipo de Producto", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

Operacion:

        lResult = Datos.Producto.ConsultarProductoxStock(Rpt)
Salida:

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            ListaProducto = New List(Of ETProducto)
            For Each wProd As ETProducto In lResult.Ls_Producto
                If wProd.StockDespacho <> 0 Then
                    Entidad.Producto = New ETProducto
                    With Entidad.Producto
                        .CodProducto = wProd.CodProducto
                        .Descripcion = wProd.Descripcion
                        .Unidad = wProd.Unidad
                        .Stock = wProd.StockDespacho
                        .EnProduccion = wProd.EnProduccion
                        .StockDespacho = wProd.StockDespacho * Convert.ToDecimal(IIf(Not IsNumeric(wProd.Factor), 0, wProd.Factor)) * 100
                        .CantidadDespachada = wProd.CantidadDespachada
                        If Rpt.TipoProducto <> "01" Then
                            .StockVenta = wProd.StockVenta * wProd.Factor * 100
                            .StockMinimo = wProd.StockMinimo
                            .StockPendiente = wProd.StockPendiente
                            .Proyeccion = wProd.Proyeccion
                        End If
                        If .StockMinimo > .StockVenta Then .DifMinxVenta = .StockMinimo - .StockVenta
                        _CPy = Decimal.Zero
                        _CSv = Decimal.Zero
                        _CPy = .Proyeccion - .CantidadDespachada
                        _CPy = IIf(_CPy < 0, Decimal.Zero, _CPy)
                        _CSv = .StockVenta - _CPy
                        If _CSv < .StockMinimo Then .CantidadRecomendada = .StockMinimo - _CSv
                    End With
                    ListaProducto.Add(Entidad.Producto)
                End If
            Next
            lResult.Ls_Producto = ListaProducto
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function MantenimientoFormula(ByVal Rpt As ETProducto, _
                                         ByVal Ls_Ruma As List(Of ETRuma), _
                                         ByVal Ls_RumaxProd As List(Of ETRuma), _
                                         ByVal Ls_RumaxSuministro As List(Of ETRuma)) As ETProducto

        Dim lResult As ETProducto = Nothing
        If Rpt Is Nothing OrElse (Ls_Ruma Is Nothing And Ls_RumaxProd Is Nothing And Ls_RumaxSuministro Is Nothing) Then
            Return lResult
        End If

Ingreso:

        Try

            lResult = New ETProducto

            'If Not IsNumeric(Rpt.ID) Then
            '    MsgBox("Ingrese el Producto para poder Guardar la Formula", MsgBoxStyle.Exclamation, msgComacsa)
            '    Return lResult
            'End If

            If String.IsNullOrEmpty(Rpt.CodProducto.Trim) Then
                MsgBox("Ingrese el Producto para el enlace", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If String.IsNullOrEmpty(Rpt.IDMolino.Trim) Then
                MsgBox("Seleccione el Molino", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If String.IsNullOrEmpty(Rpt.Usuario) Then
                MsgBox("Ingrese el Usuario", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If


            If String.IsNullOrEmpty(Rpt.Usuario) Then
                MsgBox("Ingrese el Usuario para poder Guardar los cambios", MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If

            If (Ls_Ruma Is Nothing OrElse Ls_Ruma.Count = 0) And (Ls_RumaxProd Is Nothing OrElse Ls_RumaxProd.Count = 0) And (Ls_RumaxSuministro Is Nothing OrElse Ls_RumaxSuministro.Count = 0) Then
                MsgBox("No posee Ruma(s) y/o  Producto(s) Terminado(s) y/o Suministro(s) para Guardar", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If



            If (Ls_Ruma.Count + Ls_RumaxProd.Count + Ls_RumaxSuministro.Count) = 1 Then
                If Ls_Ruma.Count = 1 Then
                    Ls_Ruma.ForEach(AddressOf AsignaPorcentaje)
                End If

                If Ls_RumaxProd.Count = 1 Then
                    Ls_RumaxProd.ForEach(AddressOf AsignaPorcentaje)
                End If
                If Ls_RumaxSuministro.Count = 1 Then
                    Ls_RumaxSuministro.ForEach(AddressOf AsignaPorcentaje)
                End If
            Else
                DecPorc = Decimal.Zero
                If (Ls_Ruma.Count + Ls_RumaxProd.Count + Ls_RumaxSuministro.Count) > 1 Then
                    If Ls_Ruma.Exists(AddressOf PorcentajeInvalido) Then
                        MsgBox("No Puede ver Ruma con Porcentaje (0) cero", MsgBoxStyle.Exclamation, msgComacsa)
                        Return lResult
                    End If

                    DecPorc = Ls_Ruma.Sum(Function(I As ETRuma) I.Porcentaje)

                    If Ls_RumaxProd.Exists(AddressOf PorcentajeInvalido) Then
                        MsgBox("No Puede ver Productos Terminados con Porcentaje (0) cero", MsgBoxStyle.Exclamation, msgComacsa)
                        Return lResult
                    End If

                    DecPorc = DecPorc + Ls_RumaxProd.Sum(Function(I As ETRuma) I.Porcentaje)

                    If Ls_RumaxSuministro.Exists(AddressOf PorcentajeInvalido) Then
                        MsgBox("No Puede ver Productos Terminados con Porcentaje (0) cero", MsgBoxStyle.Exclamation, msgComacsa)
                        Return lResult
                    End If

                    DecPorc = DecPorc + Ls_RumaxSuministro.Sum(Function(I As ETRuma) I.Porcentaje)

                End If

                'If Ls_RumaxProd.Count > 1 Then
                '    If Ls_RumaxProd.Exists(AddressOf PorcentajeInvalido) Then
                '        MsgBox("No Puede ver Ruma con Porcentaje (0) cero", MsgBoxStyle.Exclamation, msgComacsa)
                '        Return lResult
                '    End If

                '    DecPorc = DecPorc + Ls_RumaxProd.Sum(Function(I As ETRuma) I.Porcentaje)

                'End If

                If (Ls_Ruma.Count + Ls_RumaxProd.Count + Ls_RumaxSuministro.Count) > 1 Then
                    If DecPorc <> Convert.ToDecimal(100) Then
                        MsgBox("La distribución tiene que ser en Total 100%", MsgBoxStyle.Exclamation, msgComacsa)
                        Return lResult
                    End If

                End If
            End If


        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return lResult
        End Try

Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Producto.MantenimientoFormula(Rpt, Ls_Ruma, Ls_RumaxProd, Ls_RumaxSuministro)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETProducto
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ConsultarAlmacen(ByVal Producto As ETProducto) As List(Of ETProducto)
        Return Datos.Producto.ConsultarAlmacen(Producto)
    End Function

    Public Function EliminarEnlace(ByVal Rpt As ETProducto) As ETProducto

        Dim lResult As ETProducto = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETProducto

Ingreso:

        If Not IsNumeric(Rpt.ID) OrElse Rpt.ID = Decimal.Zero Then
            MsgBox("Ingrese el Enlace del Producto", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        If String.IsNullOrEmpty(Rpt.Usuario) Then
            MsgBox("Ingrese el Usuario", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

Operacion:

        If MsgBox(" ¿ Seguro desea Anular el Enlace : " & Convert.ToString(Rpt.ID) & vbNewLine & _
                  "(" & Rpt.CodProducto & ") " & Rpt.Descripcion & " ? ", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Producto.EliminarEnlace(Rpt)
        End If

Salida:
        If lResult Is Nothing Then
            lResult = New ETProducto
        Else
            MsgBox("Se Anulo Correctamente el Enlace", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function MantenimientoEnlace(ByVal Rpt As ETProducto, ByVal Ls_Ruma As List(Of ETRuma), _
                                        ByVal Ls_RumaProd As List(Of ETRuma), _
                                        ByVal Ls_RumaSuministro As List(Of ETRuma)) As ETProducto

        Dim lResult As ETProducto = Nothing
        If Rpt Is Nothing OrElse (Ls_Ruma Is Nothing And Ls_RumaProd Is Nothing And Ls_RumaSuministro Is Nothing) Then
            Return lResult
        End If

Ingreso:

        lResult = New ETProducto

        Try

            If String.IsNullOrEmpty(Rpt.CodProducto) Then
                MsgBox("Ingrese el Producto para el enlace", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If String.IsNullOrEmpty(Rpt.Usuario) Then
                MsgBox("Ingrese el Usuario", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If (Ls_Ruma Is Nothing And Ls_RumaProd Is Nothing And Ls_RumaSuministro Is Nothing) OrElse (Ls_Ruma.Count + Ls_RumaProd.Count + Ls_RumaSuministro.Count) = 0 Then
                MsgBox("Debe ingresar al menos una Ruma o un Producto Terminado para el enlace", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return lResult

        End Try

Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Producto.MantenimientoEnlace(Rpt, Ls_Ruma, Ls_RumaProd, Ls_RumaSuministro)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETProducto
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ConsultarEnlace() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Producto.ConsultarEnlace()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarProdProyectado(ByVal ayo As Int32) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Producto.ConsultarProdProyectado(ayo)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarBusquedaEnlace(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Producto.ConsultarBusquedaEnlace(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarPermisoStockMinimo(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Producto.ConsultarPermisoStockMinimo(Rpt)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function ConsultarEnlacexRuma(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Producto.ConsultarEnlacexRuma(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarEnlacexRumaxProducto(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Producto.ConsultarEnlacexRumaxProducto(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarEnlacexRumaxSuministro(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Producto.ConsultarEnlacexRumaxSuministro(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarProyeccion_1(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista

        lResult = Datos.Producto.ConsultarProyeccion_1(Rpt)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function MantenimientoProyeccion(ByVal Rpt As ETProducto, ByVal Lista As List(Of ETProducto)) As ETProducto

        Dim lResult As ETProducto = Nothing
        If Rpt Is Nothing OrElse Lista Is Nothing Then
            Return lResult
        End If

        lResult = New ETProducto

Ingreso:

        If Not (IsNumeric(Rpt.Anho) AndAlso Rpt.Anho >= 2011) Then
            MsgBox("Ingrese el Año", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        If Not (IsNumeric(Rpt.Mes) AndAlso Rpt.Mes >= 1 AndAlso Rpt.Mes <= 12) Then
            MsgBox("Ingrese el Mes", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        If String.IsNullOrEmpty(Rpt.Usuario) Then
            MsgBox("Ingrese el Usuario", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        If Lista Is Nothing OrElse Lista.Count = 0 Then
            MsgBox("No posee productos para Guardar", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        Dim Ls As New List(Of ETProducto)

        Ls = Lista.Where(AddressOf Where_Cantidad).ToList

        If Ls.Count = 0 Then
            MsgBox("No existen productos para la Actualización", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Producto.MantenimientoProyeccion(Rpt, Ls)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETProducto
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ConsultarFactor1(ByVal P As ETProducto) As List(Of ETProducto)
        Return Datos.Producto.ConsultarFactor1(P)
    End Function

    Public Function ConsultarFactor2() As List(Of ETProducto)
        Return Datos.Producto.ConsultarFactor2
    End Function

    Public Function ConsultarFactor3() As List(Of ETProducto)
        Return Datos.Producto.ConsultarFactor3
    End Function

    Public Function ConsultarEnlacexProducto(ByVal P As ETProducto) As List(Of ETProducto)
        ConsultarEnlacexProducto = New List(Of ETProducto)
Operacion:
        ConsultarEnlacexProducto = Datos.Producto.ConsultarEnlacexProducto(P)
Confirmacion:
        If ConsultarEnlacexProducto Is Nothing OrElse ConsultarEnlacexProducto.Count = 0 Then
            MsgBox("El Producto no posee Enlace(s) Definido(s)", MsgBoxStyle.Exclamation, msgComacsa)
            ConsultarEnlacexProducto = New List(Of ETProducto)
        End If
Salida:
        Return ConsultarEnlacexProducto
    End Function

    Public Function ProductosExportacion(ByVal P As ETProducto) As List(Of ETProducto)
        Return Datos.Producto.ProductosExportacion(P)
    End Function

    Public Function ConsultarProducto5() As DataTable
        Return Datos.Producto.ConsultarProducto5()
    End Function

    Public Function ConsultarFamiliaProductoFamilia(ByVal P As ETProducto) As DataTable
        Return Datos.Producto.ConsultarFamiliaProductoFamilia(P)
    End Function

    'Public Function ConsultarProducto5() As DataTable 

    '    Dim lResult As  = Nothing

    '    lResult = New ETMyLista
    '    lResult = Datos.Producto.ConsultarProducto5()

    '    If lResult Is Nothing Then
    '        lResult = New ETMyLista
    '    Else
    '        If Not lResult.Validacion Then
    '            MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
    '        End If
    '    End If

    '    Return lResult

    'End Function

    Public Shared Function ConsultarProducto6(ByVal Rpt As ETProducto) As ETProducto

        Dim lResult As New ETProducto
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = Datos.Producto.ConsultarProducto6(Rpt)
        If lResult Is Nothing Then lResult = New ETProducto

        Return lResult

    End Function

    Public Function ConsultarSuministros_Enlace() As ETMyLista

        Dim lResult As New ETMyLista

        lResult = Datos.Producto.ConsultarSuministros_Enlace()
        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function
    Public Enum enmTipoStock
        todos = 0
        SinStock = 1
        ConStock = 2
    End Enum
    Public Function ConsultarSuministros() As ETMyLista

        Dim lResult As New ETMyLista
        Dim Ls_Suministro As New List(Of ETRuma)

        lResult = Datos.Producto.ConsultarSuministros("")
        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function
    Public Function ConsultarSuministros2(ByVal tipoStock As enmTipoStock, ByVal pIdAlmacenSolicitante As String) As List(Of ETRuma)

        Dim lResult As New ETMyLista
        Dim Ls_Suministro As New List(Of ETRuma)
        Dim listaSuministro As New List(Of ETRuma)

        'lResult = Datos.Producto.ConsultarSuministros()
        lResult = Datos.Producto.ConsultarSuministros(pIdAlmacenSolicitante)
        If lResult Is Nothing Then lResult = New ETMyLista

        If lResult.Ls_Ruma.Count > 0 Then
            Ls_Suministro = lResult.Ls_Ruma
        End If

        For Each Item As ETRuma In Ls_Suministro

            Select Case tipoStock
                Case enmTipoStock.todos
                    listaSuministro.Add(Item)

                Case enmTipoStock.SinStock

                    If Item.StockD < 1 Then
                        listaSuministro.Add(Item)
                    End If

                Case enmTipoStock.ConStock

                    If Item.StockD > 0 Then
                        listaSuministro.Add(Item)
                    End If

            End Select

        Next

        Return listaSuministro

    End Function

    Public Function MantenimientoProducto(ByVal Rpt As ETProducto, ByVal Ls_Suministro As List(Of ETSuministro)) As ETProducto

        Dim lResult As ETProducto = Nothing
        If Rpt Is Nothing OrElse Ls_Suministro Is Nothing Then
            Return lResult
        End If

Ingreso:

        Try

            lResult = New ETProducto

            If String.IsNullOrEmpty(Rpt.CodProducto) Then
                Rpt.CodProducto = String.Empty
            Else
                Rpt.CodProducto = Rpt.CodProducto.Trim
            End If

            If String.IsNullOrEmpty(Rpt.Uso) Then
                Rpt.Uso = String.Empty
            Else
                Rpt.Uso = Rpt.Uso.Trim
            End If

            If Rpt.CodProducto.Length = 0 Then Rpt.Tipo = 1

            If Rpt.CodProducto.Length = 8 Then Rpt.Tipo = 2

            If String.IsNullOrEmpty(Rpt.Descripcion) Then
                MsgBox("Ingrese el Nombre del Producto", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            Else
                Rpt.Descripcion = Rpt.Descripcion.Trim
            End If

            If String.IsNullOrEmpty(Rpt.TipoProducto) Then
                MsgBox("Ingrese el Origen del Producto", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If String.IsNullOrEmpty(Rpt.UnidadProduccion) Then
                MsgBox("Ingrese la Unidad de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If String.IsNullOrEmpty(Rpt.UnidadVentas) Then
                MsgBox("Ingrese la Unidad de Venta", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If String.IsNullOrEmpty(Rpt.Unidad) Then
                MsgBox("Ingrese la Unidad del Producto", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If Not IsNumeric(Rpt.Peso) OrElse Rpt.Peso = 0 Then
                MsgBox("Ingrese el Peso del Producto", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If Not IsNumeric(Rpt.FactorBolsa) OrElse Rpt.FactorBolsa = 0 Then
                MsgBox("Ingrese el Factor de la Bolsa", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If String.IsNullOrEmpty(Rpt.Usuario) Then
                MsgBox("Ingrese el Usuario", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If Not IsNumeric(Rpt.Factor) OrElse Rpt.Factor = 0 Then
                MsgBox("Ingrese el Factor del Producto", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            Select Case Rpt.Status
                Case "K3" : Rpt.Status = "*"
                Case "K2" : Rpt.Status = "I"
                Case "K1" : Rpt.Status = ""
                Case Else
                    MsgBox("Ingrese la Estado del Producto", MsgBoxStyle.Exclamation, msgComacsa)
                    Return lResult
            End Select

            If String.IsNullOrEmpty(Rpt.Clasificacion) Then
                Rpt.Clasificacion = String.Empty
            End If

            If String.IsNullOrEmpty(Rpt.NoConforme) Then
                Rpt.NoConforme = String.Empty
            End If

            Rpt.ParteSemanal = 0

            ListaSuministro = New List(Of ETSuministro)

            For Each Row In Ls_Suministro
                strCodSuminstro = String.Empty : strCodSuminstro = Row.CodSuministro
                If Not ListaSuministro.Exists(AddressOf Existe_CodSuministro) Then
                    ListaSuministro.Add(Row)
                End If
            Next

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return lResult

        End Try

Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Producto.MantenimientoProducto(Rpt, ListaSuministro)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETProducto
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Function BuscarCodSuministro(ByVal Rpt As ETSuministro) As Boolean
        If Rpt.CodSuministro = strCodSuminstro Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function ConsultarCodVenta(ByVal Rpt As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Producto.ConsultarCodVenta(Rpt)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function Ordenar_CodProducto_Asc(ByVal x As ETProducto, _
                                            ByVal y As ETProducto) As Integer

        Return String.Compare(x.CodProducto, y.CodProducto)

    End Function

    Public Function Ordenar_CodProducto_Desc(ByVal x As ETProducto, _
                                             ByVal y As ETProducto) As Integer

        Return String.Compare(x.CodProducto, y.CodProducto) * -1

    End Function

    Public Function Ordenar_Descripcion_Asc(ByVal x As ETProducto, _
                                            ByVal y As ETProducto) As Integer

        Return String.Compare(x.Descripcion, y.Descripcion)

    End Function

    Public Function Ordenar_Descripcion_Desc(ByVal x As ETProducto, _
                                    ByVal y As ETProducto) As Integer

        Return String.Compare(x.Descripcion, y.Descripcion) * -1

    End Function

    Public Function Ordenar_Peso_Asc(ByVal x As ETProducto, ByVal y As ETProducto) As Integer
        If (x.Peso > y.Peso) Then
            Return 1
        ElseIf (x.Peso < y.Peso) Then
            Return -1
        Else
            Return 0
        End If
    End Function

    Public Function Ordenar_Peso_Desc(ByVal x As ETProducto, ByVal y As ETProducto) As Integer
        If (x.Peso < y.Peso) Then
            Return 1
        ElseIf (x.Peso > y.Peso) Then
            Return -1
        Else
            Return 0
        End If
    End Function
    
    Public Function Cargar_Consultar_Producto(ByVal Rpt As ETProducto) As ETProducto

        Dim lResult As ETProducto = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Try

            Dim i As Int16 = 2
            ReDim Preserve Hilo(i)
            ReDim Preserve SubClase(i)

            '---------------------------------------------------

            lResult = New ETProducto
            Entidad.Producto = New ETProducto

            Entidad.Producto = Rpt

            '---------------------------------------------------

            For i = 0 To 2
                SubClase(i) = New ClsLotes(i, Rpt)
                Hilo(i) = New Thread(AddressOf SubClase(i).Cargar_Consulta_Producto)
                Hilo(i).Start()
            Next

TerminaSubProceso:

            For i = 0 To 2
                If Hilo(i).IsAlive Then GoTo TerminaSubProceso
            Next

            '---------------------------------------------------

            If Not ET_Producto.Validacion Then Return lResult

            '---------------------------------------------------

            lResult = ET_Producto

            lResult.Ls_Lista1 = ListaSuministro

            lResult.Ls_Lista2 = ListaVenta

            '---------------------------------------------------

        Catch
            If lResult Is Nothing Then lResult = New ETProducto
        Finally
            Hilo = Nothing
            ET_Producto = Nothing
            ListaSuministro = Nothing
            ListaVenta = Nothing
        End Try

        Return lResult

    End Function

    Public Function ValidarProductoOrden(ByVal Rpt As ETProducto) As ETProducto

        Dim lResult As ETProducto = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETProducto
        lResult = Datos.Producto.ValidarProductoOrden(Rpt)

        If lResult Is Nothing Then lResult = New ETProducto : GoTo Salir

        If Not lResult.Validacion Then GoTo Salir

        If lResult.Respuesta <> 0 Then lResult.Validacion = Boolean.FalseString

        Select Case lResult.Respuesta
            Case MensajeValidarProductoOrden.Enlace
                MsgBox("El Producto No tiene Enlaces definidos", MsgBoxStyle.Exclamation, msgComacsa)
            Case MensajeValidarProductoOrden.Empaque
                MsgBox("El Producto No tiene Empaques definidos", MsgBoxStyle.Exclamation, msgComacsa)
            Case MensajeValidarProductoOrden.Chancadora
                MsgBox("El Producto No tiene Chancadora(s) definidos", MsgBoxStyle.Exclamation, msgComacsa)
            Case MensajeValidarProductoOrden.Molino
                MsgBox("El Producto No tiene Molinos(s) definidos", MsgBoxStyle.Exclamation, msgComacsa)
        End Select

Salir:
        Return lResult

    End Function

    Private Class ClsLotes

        Public Item As Int16
        Public Entidad As ETProducto = Nothing
        Private Lista As ETMyLista = Nothing
        Private Obj As NGSuministro = Nothing

        Sub New(ByVal i As Int16, ByVal Rpt As ETProducto)
            Entidad = New ETProducto
            Entidad = Rpt
            Item = i
        End Sub

        Public Sub Cargar_Consulta_Producto()

            If Item = 0 Then
                ET_Producto = New ETProducto
                ET_Producto = ConsultarProducto6(Entidad)
                If ET_Producto Is Nothing Then ET_Producto = New ETProducto
            End If

            'If Item = 1 Then
            '    Obj = New NGSuministro
            '    Lista = New ETMyLista
            '    ListaSuministro = New List(Of ETSuministro)

            '    Lista = Obj.ConsultarSuministro2(Entidad)
            '    ListaSuministro = Lista.Ls_Suministro

            '    If ListaSuministro Is Nothing Then ListaSuministro = New List(Of ETSuministro)
            'End If

            If Item = 2 Then

                Lista = New ETMyLista
                ListaVenta = New List(Of ETProducto)

                Lista = ConsultarCodVenta(Entidad)
                ListaVenta = Lista.Ls_Producto

                If ListaVenta Is Nothing Then ListaVenta = New List(Of ETProducto)
            End If

        End Sub

    End Class

    Private Function Existe_CodSuministro(ByVal Rpt As ETSuministro) As Boolean
        If Rpt.CodSuministro = strCodSuminstro Then
            Return Boolean.TrueString
        Else
            Return Boolean.FalseString
        End If
    End Function

    Private Sub AsignaPorcentaje(ByVal Rpt As ETRuma)
        Rpt.Porcentaje = 100
    End Sub

    Private Function PorcentajeInvalido(ByVal Rpt As ETRuma) As Boolean
        If Rpt.Porcentaje <= Decimal.Zero Then
            Return Boolean.TrueString
        Else
            Return Boolean.FalseString
        End If
    End Function

    Private Function Where_Cantidad(ByVal Rpt As ETProducto) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.Cantidad > Decimal.Zero Then lResult = Boolean.TrueString

        Return lResult

    End Function

    '===============================================================
    Public Function AgregarProducto(ByVal Producto As ETProducto, ByVal Opcion As String) As ETResultado
        Return Datos.Producto.AgregarProducto(Producto, Opcion)
    End Function

    Public Function ListarProductos(ByVal Producto As ETProducto, ByVal Opcion As String) As DataTable
        Return Datos.Producto.ListarProducto(Producto, Opcion)
    End Function

    Public Function ListarProductosOC(ByVal OC As ETOrdenCompra, ByVal Opcion As String) As DataTable
        Return Datos.Producto.ListarProductosOC(OC, Opcion)
    End Function

    Public Function ProductoValidar(ByVal Producto As ETProducto, ByVal Opcion As String) As DataTable
        Return Datos.Producto.ProductoValidar(Producto, Opcion)
    End Function


    Public Function Update_Producto_UD(ByVal Producto As ETProducto) As ETResultado
        Return Datos.Producto.Update_Producto_UD(Producto)
    End Function

    Public Function ProductoStockActual(ByVal Producto As ETProducto) As DataTable
        Return Datos.Producto.ProductoStockActual(Producto)
    End Function

    Public Function ConversionProducto(ByVal Conversion As ETProducto, ByVal Opcion As String) As ETResultado
        Return Datos.Producto.ConversionProducto(Conversion, Opcion)
    End Function
    Public Function ListarProductosImp(ByVal Producto As ETProducto) As DataTable
        Return Datos.Producto.ListaProductosImp(Producto)
    End Function

    Public Function ProductoConversion(ByVal Conversion As ETProducto, ByVal A As List(Of ETProducto)) As ETResultado
        Return Datos.Producto.ProductoConversion(Conversion, A)
    End Function

    Public Function ListarConversionProducto(ByVal Conversion As ETProducto, ByVal Opcion As String) As DataTable
        Return Datos.Producto.ListarConversionProducto(Conversion, Opcion)
    End Function

    Public Function Existe_Producto_Conversion(ByVal Conversion As ETProducto) As DataTable
        Return Datos.Producto.Existe_Producto_Conversion(Conversion)
    End Function


    Public Function Listar_Linea_SubLinea(ByVal Producto As ETProducto, ByVal Opcion As String) As DataTable
        Return Datos.Producto.Listar_Linea_SubLinea(Producto, Opcion)
    End Function

    Public Function ListarSubLinea(ByVal Producto As ETProducto, ByVal Opcion As String) As DataTable
        Return Datos.Producto.ListarSubLinea(Producto, Opcion)
    End Function

    Public Function verificacierreAlmacen(ByVal Producto As ETProducto) As DataTable
        Return Datos.Producto.verificacierreAlmacen(Producto)
    End Function

    Public Function verificaperiodoProvision(ByVal Producto As ETProducto) As DataTable
        Return Datos.Producto.verificaperiodoProvision(Producto)
    End Function

    Public Function Consultar_Formulaciones(ByVal p_cod_producto As String, ByVal p_cod_molino As String, ByVal p_agno As Integer, ByVal p_mes As Integer) As DataTable
        Return Datos.Producto.Consultar_Formulaciones(p_cod_producto, p_cod_molino, p_agno, p_mes)
    End Function

    Public Function MantenimientoMineralProductoProyeccion(ByVal Rpt As ETProducto, _
                                     ByVal Ls_Ruma As List(Of ETRuma)) As ETProducto

        Dim lResult As ETProducto = Nothing
        If Rpt Is Nothing OrElse (Ls_Ruma Is Nothing) Then
            Return lResult
        End If

Ingreso:

        Try

            lResult = New ETProducto

            If String.IsNullOrEmpty(Rpt.CodProducto.Trim) Then
                MsgBox("Ingrese el Producto", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If


            If String.IsNullOrEmpty(Rpt.Usuario) Then
                MsgBox("Ingrese el Usuario", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If


            If String.IsNullOrEmpty(Rpt.Usuario) Then
                MsgBox("Ingrese el Usuario para poder Guardar los cambios", MsgBoxStyle.Critical, msgComacsa)
                Return lResult
            End If

            If (Ls_Ruma Is Nothing OrElse Ls_Ruma.Count = 0) Then
                MsgBox("No posee Mineral(es)  para Guardar", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If


            If (Ls_Ruma.Count) = 1 Then
                If Ls_Ruma.Count = 1 Then
                    Ls_Ruma.ForEach(AddressOf AsignaPorcentaje)
                End If
            Else
                DecPorc = Decimal.Zero
                If (Ls_Ruma.Count) > 1 Then
                    If Ls_Ruma.Exists(AddressOf PorcentajeInvalido) Then
                        MsgBox("No Puede ver Mineral con Porcentaje (0) cero", MsgBoxStyle.Exclamation, msgComacsa)
                        Return lResult
                    End If

                    DecPorc = Ls_Ruma.Sum(Function(I As ETRuma) I.Porcentaje)

                End If


                If (Ls_Ruma.Count) > 1 Then
                    If DecPorc <> Convert.ToDecimal(100) Then
                        MsgBox("La distribución tiene que ser en Total 100%", MsgBoxStyle.Exclamation, msgComacsa)
                        Return lResult
                    End If

                End If
            End If


        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return lResult
        End Try

Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            lResult = Datos.Producto.MantenimientoMineralProductoProyeccion(Rpt, Ls_Ruma)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETProducto
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function EliminaMineralProductoProyeccion(ByVal Rpt As ETProducto) As Integer

        Dim lResult As Integer = 0

Ingreso:

        Try

            lResult = 0

            If String.IsNullOrEmpty(Rpt.CodProducto.Trim) Then
                MsgBox("Ingrese el Producto", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If


            If String.IsNullOrEmpty(Rpt.Usuario) Then
                MsgBox("Ingrese el Usuario", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If String.IsNullOrEmpty(Rpt.Usuario) Then
                MsgBox("Ingrese el Usuario para poder Guardar los cambios", MsgBoxStyle.Critical, msgComacsa)
                Return 0
            End If


        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return 0
        End Try

Operacion:

        'If MsgBox("¿Seguro desea Eliminar los datos?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
        ' Return lResult
        ' Else
        lResult = Datos.Producto.EliminaMineralProductoProyeccion(Rpt)
        ' End If

Salida:

        'If lResult Is Nothing Then
        ' lResult = New ETProducto
        ' Else
        ' MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
        ' lResult.Validacion = Boolean.TrueString
        ' End If

        Return lResult

    End Function

    'Public Function ListarFormulacionProyectada(ByVal idProducto As Int32) As DataTable
    '    Return Datos.Producto.ListarFormulacionProyectada(idProducto)
    'End Function

    Public Function ListarFormulacionProyectada(ByVal idProducto As Int32) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        lResult = New ETMyLista
        lResult = Datos.Producto.ListarFormulacionProyectada(idProducto)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function CargarBilletes(ByVal Producto As ETProducto) As DataTable
        Return Datos.Producto.CargarBilletes(Producto)
    End Function

    Public Function Billete_Exonerado(ByVal Ls_Datos As List(Of ETProducto)) As Integer

        Try
            Return Datos.Producto.Billete_Exonerado(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CargarLetras() As DataTable
        Return Datos.Producto.CargarLetras()
    End Function

    Public Function CargarAutorizacionIQBF() As DataTable
        Return Datos.Producto.CargarAutorizacionIQBF()
    End Function

    Public Function ListaPedidosSuministro(ByVal usuario As String) As DataTable
        Return Datos.Producto.ListaPedidosSuministro(usuario)
    End Function
    Public Function ListarEntregasSolicitudPlanilla(ByVal usuario As String) As DataTable
        Return Datos.Producto.ListarSolicitudesPlanilla(usuario)
    End Function
    Public Function ClonarUsuario(ByVal usuario As String, ByVal user_ant As String, ByVal user_nuevo As String, ByVal pass As String, ByVal encargado As String, ByVal email As String, ByVal placod As String) As DataTable
        Return Datos.Producto.ClonarUsuario(usuario, user_ant, user_nuevo, pass, encargado, email, placod)
    End Function

    Public Function AreaUsuario(ByVal usuario As String) As DataTable
        Return Datos.Producto.AreaUsuario(usuario)
    End Function

    Public Function ListaPedidoAtendido(ByVal usuario As String) As DataTable
        Return Datos.Producto.ListaPedidoAtendido(usuario)
    End Function

    Public Function ListaPedidoAtendido_Hist(ByVal usuario As String, ByVal fecha1 As Date, ByVal fecha2 As Date) As DataTable
        Return Datos.Producto.ListaPedidoAtendido_Hist(usuario, fecha1, fecha2)
    End Function

    Public Function ListaPedidoAtendidoCadena(ByVal usuario As String, ByVal cadena As String) As DataTable
        Return Datos.Producto.ListaPedidoAtendidoCadena(usuario, cadena)
    End Function

    Public Function ListaPedidoAtendidoCorreo(ByVal ruta As String) As DataTable
        Return Datos.Producto.ListaPedidoAtendidoCorreo(ruta)
    End Function
    Public Function DiferenciaInventario(ByVal Ls_Datos As ETProducto) As DataTable
        Return Datos.Producto.DiferenciaInventario(Ls_Datos)
    End Function
    Public Function ApruebaPedidoAtendido(ByVal Ls_Datos As ETProducto) As DataTable
        Return Datos.Producto.ApruebaPedidoAtendido(Ls_Datos)
    End Function

    Public Function userapruebaSuministro(ByVal usuario As String) As DataTable
        Return Datos.Producto.userapruebaSuministro(usuario)
    End Function

    Public Function ListaPedidosSuministroID(ByVal id As Int32) As DataTable
        Return Datos.Producto.ListaPedidosSuministroID(id)
    End Function

    Public Function SolicitudDetalle(ByVal id As String) As DataTable
        Return Datos.Producto.SolicitudDetalle(id)
    End Function



    Public Function Letra_Transportista(ByVal Ls_Datos As ETProducto) As Integer

        Try
            Return Datos.Producto.Letra_Transportista(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Autorizacion_IQBF(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Autorizacion_IQBF(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CargarExoneracion() As DataTable
        Return Datos.Producto.CargarExoneracion()
    End Function

    Public Function Exoneracion_Letra(ByVal Ls_Datos As ETProducto) As Integer

        Try
            Return Datos.Producto.Exoneracion_Letra(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ValidacionLetras(ByVal Ls_Datos As ETProducto) As DataTable
        Return Datos.Producto.ValidacionLetras(Ls_Datos)
    End Function

    Public Function CargarLetraID(ByVal id As Int32) As DataTable
        Return Datos.Producto.CargarLetraID(id)
    End Function

    Public Function Rpt_FormulacionProyectado() As DataTable
        Return Datos.Producto.Rpt_FormulacionProyectado()
    End Function

    Public Function Rpt_ReporteProyectadoMineral(ByVal ayo As Integer) As DataTable
        Return Datos.Producto.Rpt_ReporteProyectadoMineral(ayo)
    End Function

    Public Function CargarConstanciaError(ByVal obj As ETProducto) As DataTable
        Return Datos.Producto.CargarConstanciaError(obj)
    End Function

    Public Function CargarConstanciaBillete(ByVal billete As String) As DataTable
        Return Datos.Producto.CargarConstanciaBillete(billete)
    End Function

    Public Function CargarDescripcionError() As DataTable
        Return Datos.Producto.CargarDescripcionError()
    End Function

    Public Function Inserta_ConstanciaError(ByVal Ls_Datos As ETProducto) As Integer
        Try
            Return Datos.Producto.Inserta_ConstanciaError(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Ingreso_Tasa(ByVal Ls_Datos As ETProducto) As String

        Try
            Return Datos.Producto.Ingreso_Tasa(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Tasa_Proveedor(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Tasa_Proveedor(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Factura_Pagar(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Factura_Pagar(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    'Public Function Calculo_Importe_ppago(ByVal Ls_Datos As String, ByVal dtDetalle As DataTable) As Stri
    '    Try
    '        Return Datos.Producto.Ingreso_Calculo_Cab(Ls_Datos, dtDetalle)
    '    Catch Err As Exception
    '        Throw New Exception(Err.Message)
    '    End Try
    'End Function

    Public Function Ingreso_Calculo_Cab(ByVal Ls_Datos As ETProducto, ByVal dtDetalle As DataTable) As String

        Try
            Return Datos.Producto.Ingreso_Calculo_Cab(Ls_Datos, dtDetalle)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_Calculo_PP(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Listar_Calculo_PP(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Listar_Correo_PP(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Listar_Correo_PP(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Factura_Calculo(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Factura_Calculo(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ManoObra(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.Costo_ManoObra(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_Validacion(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_Validacion(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_Cierre(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_Cierre(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RptComparativoMinas(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.Costo_RptComparativoMinas(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_VerificaCierre(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_VerificaCierre(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RevisionCantera(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_RevisionCantera(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Costo_RevisionCanteraID(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_RevisionCanteraID(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Costo_ActualizaCantera(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ActualizaCantera(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_CostoMineral(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.Costo_CostoMineral(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_DiasHabiles(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_DiasHabiles(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_Seguro(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_Seguro(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RegistraDias(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_RegistraDias(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RegistraSeguro(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_RegistraSeguro(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReplicaSeguro(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReplicaSeguro(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_Indirecto(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.Costo_Indirecto(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Costo_ListaCuentas(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ListaCuentas(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RegistraCuenta(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_RegistraCuenta(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Costo_ListaEquipos(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ListaEquipos(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Consumo_Ene_Mes(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Consumo_Ene_Mes(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RegistraCostEquipo(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_RegistraCostEquipo(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Costo_ListaPorcAyo(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ListaPorcAyo(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Costo_RegistraPorcProduccion(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_RegistraPorcProduccion(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RptIndirecto(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_RptIndirecto(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ListaSeteoVTAADM(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ListaSeteoVTAADM(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_MantSeteoVTAADM(ByVal dt As DataTable) As DataTable

        Try
            Return Datos.Producto.Costo_MantSeteoVTAADM(dt)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function CE_RESUMEN_MENSUAL(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.CE_RESUMEN_MENSUAL(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RptIndirectoCAL(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_RptIndirectoCAL(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RptIndirectoTerrazo(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_RptIndirectoTerrazo(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RptIndirectoPastas(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_RptIndirectoPastas(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_MP_CAL(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_MP_CAL(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_MP_Terrazo(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_MP_Terrazo(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_MP_Pasta(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_MP_Pasta(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReportePresentacion(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReportePresentacion(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function
    Public Function Costo_ReporteCanteras(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteCanteras(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteTrimestral(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteTrimestral(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteTrimestralRuma(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteTrimestralRuma(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteTrimestralMO(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteTrimestralMO(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_MesesProduccion(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_MesesProduccion(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_GastoExportacion(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_GastoExportacion(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReportePresentacionCAL(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReportePresentacionCAL(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReportePresentacionTERRAZO(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReportePresentacionTERRAZO(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReportePresentacionPASTAS(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReportePresentacionPASTAS(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_COST_ALTOBAJO(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.Costo_COST_ALTOBAJO(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_PRECIOPRODUCTO(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.Costo_PRECIOPRODUCTO(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_COSTOXMOLINO(ByVal Ls_Datos As ETProducto) As DataSet
        Try
            Return Datos.Producto.Costo_COSTOXMOLINO(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_CONSUMO_ENERGIA(ByVal Ls_Datos As ETProducto) As DataSet
        Try
            Return Datos.Producto.Costo_CONSUMO_ENERGIA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function PP_RPT_CONTROL(ByVal Ls_Datos As ETProducto) As DataSet
        Try
            Return Datos.Producto.PP_RPT_CONTROL(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_COSTOXCHANCADORA(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.Costo_COSTOXCHANCADORA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_COSTOXRUMA(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.Costo_COSTOXRUMA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_COST_MIN_CANTERA(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_COST_MIN_CANTERA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function INDICADOR_PRODUCCION(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.INDICADOR_PRODUCCION(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function REPORTE_PARADA(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.REPORTE_PARADA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function INDICADOR_PRODUCCION_FINAL(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.INDICADOR_PRODUCCION_FINAL(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function INDICADOR_ADMINISTRACION_FINAL(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.INDICADOR_ADMINISTRACION_FINAL(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function INDICADOR_ADMINISTRACION_FINAL_DETALLE(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.INDICADOR_ADMINISTRACION_FINAL_DETALLE(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function INDICADOR_COMPRA_DETALLE(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.INDICADOR_COMPRA_DETALLE(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function RPT_CUENTA9(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.RPT_CUENTA9(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function RPT_COSTOS_ADM(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.RPT_COSTOS_ADM(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function INDICADOR_COMERCIAL_DETALLE(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.INDICADOR_COMERCIAL_DETALLE(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function INDICADOR_DETALLE(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.INDICADOR_DETALLE(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function LISTAR_AREA(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.LISTAR_AREA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function LISTAR_INDPRINCIPAL(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.LISTAR_INDPRINCIPAL(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function LISTAR_INDICADORES(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.LISTAR_INDICADORES(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CARGA_INDICADORES(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.CARGA_INDICADORES(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function LISTAR_INDICADORES_FINAL(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.LISTAR_INDICADORES_FINAL(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function INSERTA_INDICADORES(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.INSERTA_INDICADORES(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function LISTA_PARA_CAMPANIA(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.LISTA_PARA_CAMPANIA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function LISTA_NAVIERA(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.LISTA_NAVIERA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MANT_NAVIERA(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.MANT_NAVIERA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function APRUEBA_TARIFA(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.APRUEBA_TARIFA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function LISTA_TARIFA_NAV(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.LISTA_TARIFA_NAV(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MANT_TARIFA_NAV(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.MANT_TARIFA_NAV(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function APRUEBA_TARIFA_NAV(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.APRUEBA_TARIFA_NAV(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function LISTA_TRAZA_COSTO(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.LISTA_TRAZA_COSTO(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function LISTA_TRAZA_COSTO_MOL(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.LISTA_TRAZA_COSTO_MOL(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function LISTA_TRAZA_COSTO_CH(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.LISTA_TRAZA_COSTO_CH(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function LISTA_TRAZA_COSTO_MIN(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.LISTA_TRAZA_COSTO_MIN(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MANT_PARA_CAMPANIA(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.MANT_PARA_CAMPANIA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function INDICADOR_ENERGIA(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.INDICADOR_ENERGIA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function CAPACIDAD_CEMENTO(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.CAPACIDAD_CEMENTO(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function INDICADOR_DEVOLUCION(ByVal Ls_Datos As ETProducto) As DataSet
        Try
            Return Datos.Producto.INDICADOR_DEVOLUCION(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function INDICADOR_VARIOS(ByVal Ls_Datos As ETProducto) As DataSet
        Try
            Return Datos.Producto.INDICADOR_VARIOS(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RPT_MIN_CANTERA(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_RPT_MIN_CANTERA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RPT_MIN_CANTERA_T(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_RPT_MIN_CANTERA_T(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_COST_MINERAL_DET(ByVal Ls_Datos As ETProducto) As DataSet
        Try
            Return Datos.Producto.Costo_COST_MINERAL_DET(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RPT_GUIA_FACTURA(ByVal Ls_Datos As ETProducto) As DataSet
        Try
            Return Datos.Producto.Costo_RPT_GUIA_FACTURA(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_COST_RUMA_COMPARATIVO(ByVal Ls_Datos As ETProducto) As DataSet
        Try
            Return Datos.Producto.Costo_COST_RUMA_COMPARATIVO(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_COST_MOLINO_COMPARATIVO(ByVal Ls_Datos As ETProducto) As DataSet
        Try
            Return Datos.Producto.Costo_COST_MOLINO_COMPARATIVO(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_COST_CH_COMPARATIVO(ByVal Ls_Datos As ETProducto) As DataSet
        Try
            Return Datos.Producto.Costo_COST_CH_COMPARATIVO(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ListaActivoClase(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_ListaActivoClase(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ListaTipoComb(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_ListaTipoComb(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_MantActivos(ByVal Ls_Datos As ETProducto, ByVal dtDetalle As DataTable) As DataTable
        Try
            Return Datos.Producto.Costo_MantActivos(Ls_Datos, dtDetalle)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ListacostoPromedio(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_ListacostoPromedio(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ListacostoPromedio_Rango(ByVal Ls_Datos As ETProducto) As DataSet
        Try
            Return Datos.Producto.Costo_ListacostoPromedio_Rango(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function


    Public Function Costo_Abrir_Margenes(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_Abrir_Margenes(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_VerificaTipo(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_VerificaTipo(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_IngresaTipo(ByVal Ls_Datos As ETProducto) As Int32
        Try
            Return Datos.Producto.Costo_IngresaTipo(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ProcesaMargen(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_ProcesaMargen(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function


    Public Function Costo_ListaProducto(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_ListaProducto(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ListaCantera(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_ListaCantera(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ClonarRegistro(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_ClonarRegistro(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ClonarRegistro_Rango(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_ClonarRegistro_Rango(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ClonarEnvase(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_ClonarEnvase(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_Prom_EliminarRegistro(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_Prom_EliminarRegistro(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ListaConcepto(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_ListaConcepto(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_Prom_IngresoRegistro(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_Prom_IngresoRegistro(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_Prom_IngresoRegistro_Rango(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_Prom_IngresoRegistro_Rango(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ListaDocumentos(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_ListaDocumentos(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_IngresoEnergiaGas(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_IngresoEnergiaGas(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ListaEnergiaGas(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_ListaEnergiaGas(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ListaAgua(ByVal Ls_Datos As ETProducto) As DataTable
        Try
            Return Datos.Producto.Costo_ListaAgua(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ListaCuentasMPrev(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ListaCuentasMPrev(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_RegistraCuentaMPrev(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_RegistraCuentaMPrev(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_CuentasMPrev(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_CuentasMPrev(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_PorcentajeCosteo(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_PorcentajeCosteo(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_Mant_PorcentajeCosteo(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_Mant_PorcentajeCosteo(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteDetMolienda(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteDetMolienda(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteDetChancado(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteDetChancado(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteDetMoliendaCAL(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteDetMoliendaCAL(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function


    Public Function Costo_ReporteDetalleMoliendaCAL(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteDetalleMoliendaCAL(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteDetalleMoliendaTERRAZO(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteDetalleMoliendaTERRAZO(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteDetMoliendaTERRAZO(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteDetMoliendaTERRAZO(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteDetalleMoliendaPASTAS(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteDetalleMoliendaPASTAS(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteDetalleMolienda(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteDetalleMolienda(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteDetMoliendaPASTAS(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteDetMoliendaPASTAS(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteDetMatPrima(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteDetMatPrima(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteDetMatPrimaTERRAZO(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteDetMatPrimaTERRAZO(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteDetMatPrimaPASTAS(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteDetMatPrimaPASTAS(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ReporteDetMineral(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ReporteDetMineral(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_TonIngresada(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_TonIngresada(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function


    Public Function Costo_Bolsa(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_Bolsa(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_Kardex(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_Kardex(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_TonIngresada_Anual(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_TonIngresada_Anual(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function Costo_ValidaCantera(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.Costo_ValidaCantera(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MantenimientoProyecto(ByVal Producto As ETProducto) As DataTable
        Return Datos.Producto.MantenimientoProyecto(Producto)
    End Function

    Public Function MantenimientoProyectoTrabajador(ByVal Producto As ETProducto) As DataTable
        Return Datos.Producto.MantenimientoProyectoTrabajador(Producto)
    End Function

    Public Function ListarProyecto(ByVal Producto As ETProducto) As DataTable
        Return Datos.Producto.ListarProyecto(Producto)
    End Function

    Public Function ListarProyectoTrabajador(ByVal Producto As ETProducto) As DataTable
        Return Datos.Producto.ListarProyectoTrabajador(Producto)
    End Function


    Public Function MantenimientoProyectoEquipo(ByVal Producto As ETProducto) As DataTable
        Return Datos.Producto.MantenimientoProyectoEquipo(Producto)
    End Function

    Public Function ListarProyectoEquipo(ByVal Producto As ETProducto) As DataTable
        Return Datos.Producto.ListarProyectoEquipo(Producto)
    End Function

    Public Function ReplicaProyectoTrabajador(ByVal Producto As ETProducto) As DataTable
        Return Datos.Producto.ReplicaProyectoTrabajador(Producto)
    End Function

    Public Function ReplicaProyectoEquipo(ByVal Producto As ETProducto) As DataTable
        Return Datos.Producto.ReplicaProyectoEquipo(Producto)
    End Function

    Public Function Costo_DetalleCostoProd(ByVal Ls_Datos As ETProducto) As DataSet

        Try
            Return Datos.Producto.Costo_DetalleCostoProd(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function ListaConInvFiltro(ByVal usuario As String) As DataSet
        Return Datos.Producto.ListaConInvFiltro(usuario)
    End Function

    Public Function ListaConInvData(ByVal fechaini As Date, ByVal fechafin As Date) As DataTable
        Return Datos.Producto.ListaConInvData(fechaini, fechafin)
    End Function

    Public Function ConInvSaldoInicial(ByVal fecha As Date) As DataTable
        Return Datos.Producto.ConInvSaldoInicial(fecha)
    End Function

    Public Function ConInvConfMeses(ByVal AYO As Int32) As DataTable
        Return Datos.Producto.ConInvConfMeses(AYO)
    End Function

    Public Function ListaConfigMes() As DataTable
        Return Datos.Producto.ListaConfigMes()
    End Function

    Public Function MantConfigMes(ByVal obj As ETProducto) As DataTable
        Return Datos.Producto.MantConfigMes(obj)
    End Function

    Public Function ListaConInvDataHist(ByVal fechaini As Date, ByVal fechafin As Date) As DataTable
        Return Datos.Producto.ListaConInvDataHist(fechaini, fechafin)
    End Function

    Public Function ListaConfigRuma(ByVal idconfig As Int32) As DataTable
        Return Datos.Producto.ListaConfigRuma(idconfig)
    End Function

    Public Function MantConfigRuma(ByVal obj As ETProducto) As DataTable
        Return Datos.Producto.MantConfigRuma(obj)
    End Function

    Public Function ListaComentarioControl(ByVal CODRUMA As String, ByVal tipo As String) As DataTable
        Return Datos.Producto.ListaComentarioControl(CODRUMA, tipo)
    End Function

    Public Function MantComentarioControl(ByVal CODRUMA As String, ByVal obs As String, ByVal usuario As String) As DataTable
        Return Datos.Producto.MantComentarioControl(CODRUMA, obs, usuario)
    End Function

    Public Function RPT_RESUMEN_ENTREGAS(ByVal Ls_Datos As ETProducto) As DataTable

        Try
            Return Datos.Producto.RPT_RESUMEN_ENTREGAS(Ls_Datos)
        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

End Class
