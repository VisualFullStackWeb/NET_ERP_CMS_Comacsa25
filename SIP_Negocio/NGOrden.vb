
Imports SIP_Entidad
Imports SIP_Datos
Imports System.Threading

Public Class NGOrden

    Private Hilo() As Thread
    Private SubClase() As ClsLotes
    Private Ls_Empaque As List(Of ETSuministro)
    Private Ls_Ruma As List(Of ETRuma)
    Private Ls_Ruma_Recirculado As List(Of ETRuma)
    Private Ls_Chancadora As List(Of ETActivo)
    Private Ls_Chancadora_Temp As List(Of ETActivo)
    Private Ls_Molino As List(Of ETActivo)
    Private Ls_Billete As List(Of ETOrden)
    Private Ls_Billete_Mineral As List(Of ETOrden)
    Private Ls_Personal As List(Of ETPersonal)
    Private Item As Int32
    Private FechaInicio As Date = CDate("31/12/2100")
    Private FechaTerminacion As Date = CDate("01/01/1990")
    Private _Cod_Chancadora As String = String.Empty
    Private _Cod_Turno As Short = 0

    Public Function MantenimientoOrden(ByVal Rpt As ETOrden, _
                                       ByVal ListaxRuma As List(Of ETRuma), _
                                       ByVal ListaxEmpaques As List(Of ETSuministro), _
                                       ByVal ListaxChancadora As List(Of ETActivo), _
                                       ByVal ListaxMolino As List(Of ETActivo)) As ETOrden



        Dim lResult As ETOrden = Nothing
        If Rpt Is Nothing OrElse ListaxRuma Is Nothing OrElse ListaxEmpaques Is Nothing OrElse ListaxChancadora Is Nothing OrElse ListaxMolino Is Nothing Then
            MsgBox("Error al Ingresar los Datos", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If
        Dim CantRecirculado As Decimal = Decimal.Zero

Ingreso:

        lResult = New ETOrden
        Ls_Ruma = New List(Of ETRuma)
        Ls_Empaque = New List(Of ETSuministro)
        Ls_Chancadora = New List(Of ETActivo)
        Ls_Molino = New List(Of ETActivo)
        Ls_Ruma_Recirculado = New List(Of ETRuma)

        Try

            If String.IsNullOrEmpty(Rpt.NroDocumento) Then
                Rpt.Tipo = 1
            Else
                Rpt.Tipo = 2
            End If

            If Not IsNumeric(Rpt.CodEnlace) OrElse Rpt.CodEnlace = 0 Then
                MsgBox("Ingrese el Enlace para poder Guardar la Orden de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            Else
                Rpt.CodProducto = Rpt.CodProducto.Trim
            End If

            If String.IsNullOrEmpty(Rpt.CodProducto) Then
                MsgBox("Ingrese el Producto para poder Guardar la Orden de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            Else
                Rpt.CodProducto = Rpt.CodProducto.Trim
            End If

            If String.IsNullOrEmpty(Rpt.Descripcion) Then
                MsgBox("Ingrese el Producto para poder Guardar la Orden de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            Else
                Rpt.Descripcion = Rpt.Descripcion.Trim
            End If

            If Rpt.Cantidad = Decimal.Zero Then
                MsgBox("Ingrese la Cantidad para poder Guardar la Orden de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            If Not IsDate(Rpt.FechaIngreso) Then
                MsgBox("Ingrese la Fecha de Ingreso al Álmacen", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            If String.IsNullOrEmpty(Rpt.Especificaciones) Then
                Rpt.Especificaciones = String.Empty
            Else
                Rpt.Especificaciones = Rpt.Especificaciones.Trim
            End If

            REM ------------------------- Rumas ----------------------------

            If ListaxRuma.Count = 0 Then
                MsgBox("Error: No existen Rumas para poder Guardar", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            Ls_Ruma = ListaxRuma.Where(AddressOf Where_Ruma).ToList()


            Item = 0

            Ls_Ruma.ForEach(AddressOf Agregar_Item)

            Rpt.TotalRuma = Ls_Ruma.Sum(Function(R) R.SubTotal)

            If Ls_Ruma.Count = 0 OrElse Rpt.TotalRuma = Decimal.Zero Then
                MsgBox("Error: No existen Rumas para poder Guardar", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            If Rpt.FormulaRecirculado = True Then
                Ls_Ruma_Recirculado = ListaxRuma.Where(AddressOf Where_Ruma_Recirculado).ToList()
                CantRecirculado = Ls_Ruma_Recirculado.Sum(Function(R) R.CantidadxNecesaria)
                If CantRecirculado <= 0 Then
                    MsgBox("La Cantidad de Producto Recirculado Debe ser mayor a Cero", MsgBoxStyle.Exclamation, msgComacsa)
                    GoTo Salida
                End If
                Rpt.CantidadRecirculado = CantRecirculado
            End If
            
            REM ------------------------- Empaques ----------------------------

            If ListaxEmpaques.Count = 0 Then
                MsgBox("No existen Empaques para poder Guardar", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            Ls_Empaque = ListaxEmpaques.Where(AddressOf Where_Suministro).ToList()

            Item = 0

            Ls_Empaque.ForEach(AddressOf Agregar_Item)

            Rpt.TotalSuministro = Ls_Empaque.Sum(Function(S) S.SubTotal)

            If Ls_Empaque.Count = 0 OrElse Rpt.TotalSuministro = 0 Then
                MsgBox("Ingrese la Cantidad de Empaques para la Orden de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            REM ------------------- Lotes para Chancadoras -----------------------

            If ListaxChancadora.Count = 0 Then
                MsgBox("Ingrese los Lotes por las Chancadoras que se usaran en la Orden de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            Item = 0

            For Each Entidad.Activo In ListaxChancadora
                With Entidad.Activo
                    If .TonUtilizado > 0 Then
                        If FechaInicio > .Fecha Then FechaInicio = .Fecha
                        If FechaTerminacion < .Fecha Then FechaTerminacion = .Fecha
                        Item += 1
                        .Item = Item
                        Rpt.TotalChancadora += .SubTotal
                        Ls_Chancadora.Add(Entidad.Activo)
                    End If
                End With
            Next

            If Ls_Chancadora.Count = 0 Then
                MsgBox("Ingrese los Lotes por las Chancadoras que se usaran en la Orden de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            REM ------------------- Lotes para Molinos -----------------------

            If ListaxMolino.Count = 0 Then
                MsgBox("Ingrese los Lotes por los Molinos que se usaran en la Orden de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            Item = 0

            For Each Entidad.Activo In ListaxMolino
                With Entidad.Activo
                    If .TonUtilizado > 0 Then
                        If FechaInicio > .Fecha Then FechaInicio = .Fecha
                        If FechaTerminacion < .Fecha Then FechaTerminacion = .Fecha
                        Item += 1
                        .Item = Item
                        Rpt.TotalMolino += .SubTotal
                        Ls_Molino.Add(Entidad.Activo)
                    End If
                End With
            Next

            If Ls_Molino.Count = 0 Then
                MsgBox("Ingrese los Lotes por los Molinos que se usaran en la Orden de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            REM -------------------------------------------------------------

            Rpt.FechaInicio = FechaInicio
            Rpt.FechaTerminacion = FechaTerminacion

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            GoTo Salida
        End Try

Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            GoTo Salida
        Else
            lResult = Datos.Orden.MantenimientoOrden(Rpt, Ls_Ruma, Ls_Empaque, Ls_Chancadora, Ls_Molino)
        End If

Confirmacion:

        If lResult Is Nothing Then
            lResult = New ETOrden
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
        End If

Salida:

        Ls_Empaque = Nothing
        Ls_Ruma = Nothing
        Ls_Chancadora = Nothing
        Ls_Molino = Nothing
        ListaxRuma = Nothing
        ListaxEmpaques = Nothing
        ListaxChancadora = Nothing
        ListaxMolino = Nothing

        Return lResult

    End Function

    Public Function MantenimientoOrden5(ByVal Rpt As ETOrden, _
                                     ByVal Listar_Activo As List(Of ETActivo), _
                                     ByVal Listar_Billete As List(Of ETOrden)) As ETOrden



        Dim lResult As ETOrden = Nothing
        If Rpt Is Nothing OrElse Listar_Activo Is Nothing OrElse Listar_Billete Is Nothing Then
            MsgBox("Error al Ingresar los Datos", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If

Ingreso:

        lResult = New ETOrden
        Ls_Billete = New List(Of ETOrden)
        Ls_Chancadora = New List(Of ETActivo)
       
        Try

            If Not IsNumeric(Rpt.ID) OrElse Rpt.ID = 0 Then
                MsgBox("Seleccione la Orden de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            If String.IsNullOrEmpty(Rpt.Cod_Chancadora.Trim) Then
                MsgBox("Ingrese la Chancadora", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            Else
                Rpt.Cod_Chancadora = Rpt.Cod_Chancadora.Trim
            End If

            If IsDate(Rpt.Fecha) = False Then
                MsgBox("Ingrese una Fecha Válida", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            ' ------------------------- Chancadoras ----------------------------

            If Listar_Activo.Count = 0 Then
                MsgBox("Debe Confirmar el Chancadora que realizó el trabajo", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            _Cod_Chancadora = Rpt.Cod_Chancadora
            Ls_Chancadora = Listar_Activo.Where(AddressOf Where_Chancadora).ToList()
            Rpt.TotalChancadora = Ls_Chancadora.Sum(Function(R) R.Cantidad)

            If Ls_Chancadora.Count = 0 Then
                MsgBox("Error: No existe Chancadora a Confirmar a Grabar!!!", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            ElseIf Not (Rpt.TotalChancadora = Rpt.Cantidad) Then
                MsgBox("Error: La Cantidad Chancada es diferente a la Cantidad a Chancar!!!", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            '------------------------- BILLETES ----------------------------

            If Listar_Billete.Count = 0 Then
                MsgBox("No existen Billetes para poder Guardar", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            Ls_Billete = Listar_Billete.Where(AddressOf Where_Billete).ToList()


            Rpt.TotalRuma = Ls_Billete.Sum(Function(B) B.Cantidad)

            If Ls_Billete.Count = 0 Then
                MsgBox("No hay Billetes de Pesaje de Balanza a enlazar", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            ElseIf Not (Rpt.TotalRuma = Rpt.Cantidad) Then
                MsgBox("La Cantidad a Chancar es diferente al Pesaje de Balanza ", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If


            ' ------------------- Personal -----------------------

            'If Listar_Personal.Count = 0 Then
            '    MsgBox("No Existe Personal asignado a la Chancadora", MsgBoxStyle.Exclamation, msgComacsa)
            '    GoTo Salida
            'End If

            'Ls_Personal = Listar_Personal.Where(AddressOf Where_Personal).ToList()

            'Rpt.TotalRuma = Ls_Billete.Sum(Function(B) B.Cantidad)

            'For Each xRow As ETActivo In Ls_Chancadora
            '    _Cod_Turno = xRow.Turno
            '    xRow.ListaPersonal = Listar_Personal.Where(AddressOf Where_Personal_Turno).ToList()
            '    xRow.NroOperarios = xRow.ListaPersonal.Count
            'Next

            Ls_Chancadora_Temp = New List(Of ETActivo)
            Ls_Chancadora_Temp = Ls_Chancadora.Where(AddressOf Where_Chancadora_Nro_Ope).ToList()

            If Ls_Chancadora_Temp.Count > 0 Then
                MsgBox("Existen Turnos sin Personal", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            GoTo Salida
        End Try

Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            GoTo Salida
        Else
            lResult = Datos.Orden.MantenimientoOrden5(Rpt, Ls_Chancadora, Ls_Billete)
        End If

Confirmacion:

        If lResult Is Nothing Then
            lResult = New ETOrden
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
        End If

Salida:
        Ls_Chancadora_Temp = Nothing
        Ls_Chancadora = Nothing
        Ls_Billete = Nothing
        Listar_Activo = Nothing
        Listar_Billete = Nothing

        Return lResult

    End Function

    Public Function MantenimientoOrden5_M(ByVal Listar_Billete As List(Of ETOrden), _
                                     ByVal Listar_Mineral As List(Of ETOrden)) As ETOrden



        Dim lResult As ETOrden = Nothing
        If Listar_Billete Is Nothing OrElse Listar_Mineral Is Nothing Then
            MsgBox("Error al Ingresar los Datos", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If

Ingreso:

        lResult = New ETOrden
       

        Try

            ' ------------------------- Chancadoras ----------------------------
            If Listar_Billete.Count = 0 Then
                MsgBox("No hay Billetes de Balanza para confirmar el Molino", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

            If Listar_Mineral.Count = 0 Then
                MsgBox("Debe Confirmar el Molino que realizó el trabajo", MsgBoxStyle.Exclamation, msgComacsa)
                GoTo Salida
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            GoTo Salida
        End Try

Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            GoTo Salida
        Else
            lResult = Datos.Orden.MantenimientoOrden5_M(Listar_Billete, Listar_Mineral)
        End If

Confirmacion:

        If lResult Is Nothing Then
            lResult = New ETOrden
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
        End If

Salida:
        Ls_Billete = Nothing
        Ls_Billete_Mineral = Nothing
        Listar_Mineral = Nothing
        Listar_Billete = Nothing

        Return lResult

    End Function

    Public Function ConsultarOrden1() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Orden.ConsultarOrden1()
        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function ConsultarOrden2(ByVal Rpt As ETOrden) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Orden.ConsultarOrden2(Rpt)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function ConsultarOrden3(ByVal Rpt As ETOrden) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Orden.ConsultarOrden3(Rpt)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function ConsultarOrden4(ByVal Rpt As ETOrden) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Orden.ConsultarOrden4(Rpt)
        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult
    End Function

    Public Function ConsultarOrden5(ByVal O As ETOrden, ByVal A As ETActivo) As List(Of ETActivo)
        Return Datos.Orden.ConsultarOrden5(O, A)
    End Function

    Public Function ConsultarOrden9(ByVal Rpt As ETOrden) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Orden.ConsultarOrden9(Rpt)
        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult
    End Function

    Public Function ConsultarOrden12(ByVal O As ETOrden) As List(Of ETActivo)
        Return Datos.Orden.ConsultarOrden12(O)
    End Function

    Public Function ConsultarOrden13(ByVal O As ETOrden) As List(Of ETActivo)
        Return Datos.Orden.ConsultarOrden13(O)
    End Function

    Public Function Consultar_Orden_PesajeRuma(ByVal O As ETOrden) As DataSet
        Return Datos.Orden.Consultar_Orden_PesajeRuma(O)
    End Function

    Public Function Consultar_Orden_Chancadora_Pesaje(ByVal O As ETOrden) As DataSet
        Return Datos.Orden.Consultar_Orden_Chancadora_Pesaje(O)
    End Function

    Public Function Consultar_Orden_Chancadora_Molino(ByVal O As ETOrden) As DataSet
        Return Datos.Orden.Consultar_Orden_Chancadora_Molino(O)
    End Function

    Public Function Consultar_Orden_Molienda_IngresoProd(ByVal Rpt As ETOrden) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        lResult = New ETMyLista
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = Datos.Orden.Consultar_Orden_Molienda_IngresoProd(Rpt)
        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function



    Sub Agregar_Item(ByVal Rpt As Object)
        Item += 1
        Rpt.Item = Item
    End Sub

    Function Where_Suministro(ByVal Rpt As ETSuministro) As Boolean
        Where_Suministro = Boolean.FalseString
        If Not (Rpt.CantidadUnitaria = 0 OrElse Rpt.CostoUnitario = 0) Then
            Where_Suministro = Boolean.TrueString
        End If
    End Function

    Function Where_Chancadora(ByVal Rpt As ETActivo) As Boolean
        Where_Chancadora = Boolean.FalseString
        If (Rpt.CodInterno.Trim = _Cod_Chancadora) Then
            Where_Chancadora = Boolean.TrueString
        End If
    End Function

    Function Where_Billete(ByVal Rpt As ETOrden) As Boolean
        Where_Billete = Boolean.FalseString
        If (Rpt.Cod_Chancadora = _Cod_Chancadora) Then
            Where_Billete = Boolean.TrueString
        End If
    End Function

    Function Where_Personal(ByVal Rpt As ETPersonal) As Boolean
        Where_Personal = Boolean.FalseString
        If (Rpt.CodUnidadProd = _Cod_Chancadora And Rpt.Action = True) Then
            Where_Personal = Boolean.TrueString
        End If
    End Function

    Function Where_Chancadora_Nro_Ope(ByVal Rpt As ETActivo) As Boolean
        Where_Chancadora_Nro_Ope = Boolean.FalseString
        If (Rpt.CodInterno = _Cod_Chancadora And Rpt.NroOperarios <= 0) Then
            Where_Chancadora_Nro_Ope = Boolean.TrueString
        End If
    End Function

    Function Where_Personal_Turno(ByVal Rpt As ETPersonal) As Boolean
        Where_Personal_Turno = Boolean.FalseString
        If (Rpt.CodUnidadProd = _Cod_Chancadora And Rpt.Action = True And Rpt.Turno = _Cod_Turno) Then
            Where_Personal_Turno = Boolean.TrueString
        End If
    End Function


    Function Where_Ruma(ByVal Rpt As ETRuma) As Boolean
        Where_Ruma = Boolean.FalseString
        If Not (Rpt.CantidadxNecesaria = 0 OrElse Rpt.SubTotal = 0) Then
            Where_Ruma = Boolean.TrueString
        End If
    End Function

    Function Where_Ruma_Recirculado(ByVal Rpt As ETRuma) As Boolean
        Where_Ruma_Recirculado = Boolean.FalseString
        If (Rpt.TipoEnlace = "RECIRCULADO") Then
            Where_Ruma_Recirculado = Boolean.TrueString
        End If
    End Function

    Public Function ConsultarOrden_Busqueda(ByVal Rpt As ETOrden) As ETOrden

        Dim lResult As ETOrden = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETOrden
        lResult = Datos.Orden.ConsultarOrden_Busqueda(Rpt)
        If lResult Is Nothing Then lResult = New ETOrden

        Return lResult

    End Function

    'Public Function Consultar_Orden_Produccion(ByVal Rpt As ETOrden) As ETOrden

    '    'Dim lResult As ETOrden = Nothing
    '    'If Rpt Is Nothing Then
    '    '    Return lResult
    '    'End If

    '    'Entidad.Orden = New ETOrden

    '    'Entidad.Orden.NroDocumento = Rpt.NroDocumento
    '    'Entidad.Orden = ConsultarOrden2(Entidad.Orden)

    '    'Dim i As Int16 = 2
    '    'ReDim Preserve Hilo(i)
    '    'ReDim Preserve SubClase(i)








    '    'Return lResult


    'End Function



    Private Class ClsLotes

        Public Item As Int16
        Public Entidad As ETOrden

        Sub New(ByVal i As Int16, ByVal Rpt As ETOrden)
            Entidad = New ETOrden
            Entidad = Rpt
            Item = i
        End Sub

        Public Sub Cargar_Consulta_Producto()

            'If Item = 0 Then
            '    ET_Producto = New ETProducto
            '    ET_Producto = ConsultarProducto6(Entidad)
            '    If ET_Producto Is Nothing Then ET_Producto = New ETProducto
            'End If

            'If Item = 1 Then
            '    Dim Obj As New NGSuministro
            '    ListaSuministro = New List(Of ETSuministro)
            '    ListaSuministro = Obj.ConsultarSuministro2(Entidad)
            '    If ListaSuministro Is Nothing Then ListaSuministro = New List(Of ETSuministro)
            'End If

            'If Item = 2 Then
            '    ObjLista = New Object
            '    ObjLista = ConsultarCodVenta(Entidad)
            '    If ObjLista Is Nothing Then ObjLista = New Object
            'End If

        End Sub

    End Class


End Class
