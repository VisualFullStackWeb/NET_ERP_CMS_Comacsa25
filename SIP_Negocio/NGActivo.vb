Imports SIP_Entidad
Imports SIP_Datos
Public Class NGActivo

    Private StrPregunta As String = String.Empty
    Private ListActivo As List(Of ETActivo)
    Private List_Personal As List(Of ETPersonal)

    Public Function ConsultarActivo(ByVal A As ETActivo) As List(Of ETActivo)
        Return Datos.Activo.ConsultarActivo(A)
    End Function
    Public Function ConsultarActivoxMatriz(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Activo.ConsultarActivoxMatriz(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox(MsgErrorAlCargar, MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function MantenimientoxMatrizxActivo(ByVal Rpt As ETActivo, ByVal Ls_Activo As List(Of ETActivo)) As ETActivo

        Dim lResult As ETActivo = Nothing
        If Rpt Is Nothing OrElse Ls_Activo Is Nothing Then
            Return lResult
        End If

Ingreso:

        Try

            lResult = New ETActivo

            If Not IsNumeric(Rpt.CodEnlace) Then
                MsgBox("Debe Ingresar el Código de Enlace", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If String.IsNullOrEmpty(Rpt.Usuario) Then
                MsgBox("Debe Ingresar el Usuario", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If Ls_Activo Is Nothing OrElse Ls_Activo.Count = 0 Then
                MsgBox("No existe ninguna Maquina", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            ListActivo = New List(Of ETActivo)
            ListActivo = Ls_Activo.FindAll(AddressOf BuscarUpdate)

            If ListActivo Is Nothing OrElse ListActivo.Count = 0 Then
                MsgBox("Debe Ingresar al menos un Registro", MsgBoxStyle.Exclamation, msgComacsa)
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
            lResult = Datos.Activo.MantenimientoxMatrizxActivo(Rpt, ListActivo)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETActivo
        Else
            If lResult.Validacion Then
                MsgBox("Se guardarón los cambios Correctamente", MsgBoxStyle.Information, msgComacsa)
            Else
                MsgBox(MsgErrorAlCargar, MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Function BuscarUpdate(ByVal Rpt As ETActivo) As Boolean
        If IsNumeric(Rpt.Rendimiento) AndAlso Rpt.Rendimiento > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ConsultarCronograma(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Activo.ConsultarCronograma(Rpt)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function
    Public Function ConsultarCronogramaxPersonal(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Activo.ConsultarCronogramaxPersonal(Rpt)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function
    Public Function MantenimientoxCronograma(ByVal Rpt As ETActivo, ByVal Ls_Personal As List(Of ETPersonal)) As ETActivo
        
        Dim lResult As ETActivo = Nothing
        If Rpt Is Nothing OrElse Ls_Personal Is Nothing Then
            Return lResult
        End If

Ingreso:

        lResult = New ETActivo

        If Not (IsNumeric(Rpt.Semana) AndAlso Rpt.Semana >= 1 AndAlso Rpt.Semana <= 53) Then
            MsgBox("Ingrese la Semana", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        If Not IsNumeric(Rpt.Anho) Then
            MsgBox("Ingrese el Año", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        If Not (IsNumeric(Rpt.Dia) AndAlso Rpt.Dia >= 1 AndAlso Rpt.Dia <= 7) Then
            MsgBox("Ingrese el Día", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        If Not IsDate(Rpt.Fecha) Then
            MsgBox("Ingrese la Fecha", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        If String.IsNullOrEmpty(Rpt.CodClase) Then
            MsgBox("Ingrese la Clase del Activo", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        If String.IsNullOrEmpty(Rpt.CodTipo) Then
            MsgBox("Ingrese el Tipo del Activo", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        If String.IsNullOrEmpty(Rpt.Placa) Then
            MsgBox("Ingrese la Placa del Activo", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        If String.IsNullOrEmpty(Rpt.Usuario) Then
            MsgBox("Ingrese el Usuario", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

        'If Ls_Personal Is Nothing OrElse Ls_Personal.Count = 0 Then
        '    MsgBox("Ingrese el Personal para la Programación", MsgBoxStyle.Exclamation, msgComacsa)
        '    Return lResult
        'End If

Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            If Rpt.AplicarSemana = False Then
                lResult = Datos.Activo.MantenimientoxCronograma(Rpt, Ls_Personal)
            Else
                lResult = Datos.Activo.MantenimientoxCronogramaxSemana(Rpt, Ls_Personal)
            End If

        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETActivo
        Else
            MsgBox("Se guardarón los cambios Correctamente", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function
    Public Function ConsultarEnlacexFormula(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Producto.ConsultarEnlacexFormula(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarEnlacexFormulaxProducto(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Producto.ConsultarEnlacexFormulaxProducto(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarEnlacexFormulaxSuministro(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Producto.ConsultarEnlacexFormulaxSuministro(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function CuadroDisponUnidad(ByVal A As ETActivo) As List(Of ETActivo)
        Return Datos.Activo.CuadroDisponUnidad(A)
    End Function
    Public Function ConsultarActivo4() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Activo.ConsultarActivo4

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox(MsgErrorAlCargar, MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function MantenimientoUnidadPersonal(ByVal Rpt As ETActivo, ByVal Ls_Personal As List(Of ETPersonal)) As ETActivo

        Dim lResult As ETActivo = Nothing
        If Rpt Is Nothing OrElse Ls_Personal Is Nothing Then
            Return lResult
        End If

Ingreso:

        lResult = New ETActivo
        Try
            If String.IsNullOrEmpty(Rpt.CodClase) Then
                MsgBox("Ingrese la Clase del Activo", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If String.IsNullOrEmpty(Rpt.CodTipo) Then
                MsgBox("Ingrese el Tipo del Activo", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            If String.IsNullOrEmpty(Rpt.Placa) Then
                MsgBox("Ingrese la Placa del Activo", MsgBoxStyle.Exclamation, msgComacsa)
                Return lResult
            End If

            'If Ls_Personal Is Nothing OrElse Ls_Personal.Count = 0 Then
            '    MsgBox("Debe Ingresar Personal para la Unidad", MsgBoxStyle.Exclamation, msgComacsa)
            '    Return lResult
            'End If

            If String.IsNullOrEmpty(Rpt.Usuario) Then
                MsgBox("Ingrese el Usuario", MsgBoxStyle.Exclamation, msgComacsa)
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
            lResult = Datos.Activo.MantenimientoUnidadPersonal(Rpt, Ls_Personal)
        End If

Salida:

        If lResult Is Nothing Then
            lResult = New ETActivo
        Else
            MsgBox("Se guardarón los cambios Correctamente", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function
    Public Function ConsultarActivo5(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Activo.ConsultarActivo5(Rpt)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox(MsgErrorAlCargar, MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function ConsultarActivo6(ByVal A As ETActivo) As List(Of ETActivo)
        Return Datos.Activo.ConsultarActivo6(A)
    End Function
    Public Function MantenimientoPlanilla(ByVal A As ETActivo, ByVal P As List(Of ETPersonal)) As ETObjecto

        MantenimientoPlanilla = New ETObjecto

Ingreso:

        Try
            If A.CodClase = String.Empty Then
                Return MantenimientoPlanilla
            End If
            If A.CodTipo = String.Empty Then
                Return MantenimientoPlanilla
            End If
            If A.Placa = String.Empty Then
                Return MantenimientoPlanilla
            End If
            If Not IsNumeric(A.Turno) OrElse (A.Turno < 1 OrElse A.Turno > 4) Then
                Return MantenimientoPlanilla
            End If
            If P Is Nothing Then
                P = New List(Of ETPersonal)
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoPlanilla
        End Try

Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return MantenimientoPlanilla
        Else
            MantenimientoPlanilla = Datos.Activo.MantenimientoPlanilla(A, P)
        End If

Salida:

        If MantenimientoPlanilla Is Nothing Then
            MantenimientoPlanilla = New ETObjecto
        Else
            MsgBox("Se guardarón los cambios Correctamente", MsgBoxStyle.Information, msgComacsa)
            MantenimientoPlanilla.Validacion = True
        End If

    End Function
    Public Function ConsultarActivo7(ByVal A As ETActivo) As List(Of ETPersonal)
        Return Datos.Activo.ConsultarActivo7(A)
    End Function
    Public Function ConsultarActivo8(ByVal A As ETActivo) As ETMyLista
        Return Datos.Activo.ConsultarActivo8(A)
    End Function

    Public Function ConsultarActivo9() As ETMyLista
        Return Datos.Activo.ConsultarActivo9
    End Function

    Public Function ConsultarActivo10() As ETMyLista
        Return Datos.Activo.ConsultarActivo10
    End Function

    Public Function ImportarCronograma(ByVal A As ETActivo) As ETObjecto

        ImportarCronograma = New ETObjecto
Ingreso:
        Try
            If Not IsNumeric(A.Tipo) OrElse A.Tipo < 1 OrElse A.Tipo > 3 Then
                MsgBox("Seleccione Tipo de Operación", MsgBoxStyle.Exclamation, msgComacsa)
                Return ImportarCronograma
            End If

            If Not IsNumeric(A.Anho) Then
                MsgBox("Ingrese el Año del Cronograma", MsgBoxStyle.Exclamation, msgComacsa)
                Return ImportarCronograma
            End If

            If Not IsNumeric(A.Semana) OrElse A.Semana <= 0 OrElse A.Semana > 52 Then
                MsgBox("Ingrese la Semana del Cronograma", MsgBoxStyle.Exclamation, msgComacsa)
                Return ImportarCronograma
            End If

            If Not IsDate(A.FechaInicio) Then
                MsgBox("No se puede identificar la Fecha de Inicio", MsgBoxStyle.Critical, msgComacsa)
                Return ImportarCronograma
            End If

            If A.Tipo = 1 Then
                If Not IsNumeric(A.Rotar1) OrElse A.Rotar1 < 1 OrElse A.Rotar1 > 3 Then
                    MsgBox("El Turno Seleccionado para el Primer Turno es Incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
                    Return ImportarCronograma
                End If
                If Not IsNumeric(A.Rotar2) OrElse A.Rotar2 < 1 OrElse A.Rotar2 > 3 Then
                    MsgBox("El Turno Seleccionado para el Segundo Turno es Incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
                    Return ImportarCronograma
                End If
                If Not IsNumeric(A.Rotar3) OrElse A.Rotar3 < 1 OrElse A.Rotar3 > 3 Then
                    MsgBox("El Turno Seleccionado para el Tercer Turno es Incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
                    Return ImportarCronograma
                End If
                If A.Rotar1 = A.Rotar2 OrElse _
                   A.Rotar2 = A.Rotar3 OrElse _
                   A.Rotar1 = A.Rotar3 Then
                    MsgBox("La rotacion de Turnos no debe repetirse", MsgBoxStyle.Exclamation, msgComacsa)
                    Return ImportarCronograma
                End If
            End If
            If A.Tipo = 3 Then
                If Not IsNumeric(A.SemanaPrevia) OrElse A.SemanaPrevia < 1 OrElse A.SemanaPrevia > 52 Then
                    MsgBox("La Semana Ingresada es Incorrecta", MsgBoxStyle.Exclamation, msgComacsa)
                    Return ImportarCronograma
                End If
                If A.SemanaPrevia >= A.Semana Then
                    MsgBox("La Semana Ingresada debe ser menor a la Semana que se desea Generar", MsgBoxStyle.Exclamation, msgComacsa)
                    Return ImportarCronograma
                End If
            Else
                A.SemanaPrevia = 0
            End If
            ImportarCronograma = ConsultarExisteCronograma(A)
            If ImportarCronograma Is Nothing Then ImportarCronograma = New ETObjecto : Return ImportarCronograma
            If ImportarCronograma.Respuesta <> 0 Then
                StrPregunta = "¿Seguro desea Guardar los cambios?"
            Else
                StrPregunta = "Existen datos Guardados en esta Semana y Año" & vbNewLine & _
                              "Se Sobreescribiran sobre los datos existentes" & vbNewLine & _
                              "¿Seguro desea Guardar los cambios?"
            End If
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return ImportarCronograma
        End Try

Operacion:

        If MsgBox(StrPregunta, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return ImportarCronograma
        Else
            ImportarCronograma = Datos.Activo.ImportarCronograma(A)
        End If

Salida:

        If ImportarCronograma Is Nothing Then
            ImportarCronograma = New ETObjecto
        Else
            MsgBox("Se guardarón los cambios Correctamente", MsgBoxStyle.Information, msgComacsa)
            ImportarCronograma.Validacion = True
        End If

    End Function
    Public Function ConsultarExisteCronograma(ByVal A As ETActivo) As ETObjecto
        Return Datos.Activo.ConsultarExisteCronograma(A)
    End Function
    Public Function CuadroxOrdenxUnidad(ByVal P As ETProducto, ByVal A As ETActivo) As ETActivo

Ingreso:
        CuadroxOrdenxUnidad = New ETActivo
        If P.CodProducto = Nothing OrElse P.CodProducto = String.Empty Then
            MsgBox("Ingrese el Producto", MsgBoxStyle.Exclamation, msgComacsa)
            Return Nothing
        End If
        If Not IsNumeric(P.ID) OrElse P.ID = 0 Then
            MsgBox("Ingrese el Enlace del Producto", MsgBoxStyle.Exclamation, msgComacsa)
            Return Nothing
        End If
        If Not IsDate(P.Fecha) Then
            MsgBox("Ingrese la Fecha ha Producir", MsgBoxStyle.Exclamation, msgComacsa)
            Return Nothing
        End If
        If Not IsNumeric(A.Turno) OrElse A.Turno = 0 Then
            MsgBox("Ingrese el Turno", MsgBoxStyle.Exclamation, msgComacsa)
            Return Nothing
        End If

        'If Not IsNumeric(A.NroOperarios) OrElse A.NroOperarios <= 0 Then
        '    MsgBox("Ingrese el Cronograma de Personal para el Activo: " & A.Descripcion, MsgBoxStyle.Exclamation, msgComacsa)
        '    Return Nothing
        'End If

Operacion:
        CuadroxOrdenxUnidad = Datos.Activo.CuadroxOrdenxUnidad(P, A)
Salida:

        If CuadroxOrdenxUnidad Is Nothing Then
            CuadroxOrdenxUnidad = New ETActivo
            MsgBox("No posee Distribución Unidad - Producto", MsgBoxStyle.Exclamation, msgComacsa)
        End If

        Return CuadroxOrdenxUnidad
    End Function
    Public Sub Ordenar_Activo(ByRef Ls As List(Of ETActivo))
        Dim LsSort = (From Tabla In Ls _
                      Order By Tabla.Fecha Ascending, _
                               Tabla.Turno Ascending, _
                               Tabla.Placa Ascending _
                      Select Tabla)
        Ls = New List(Of ETActivo)
        For Each T In LsSort
            Ls.Add(T)
        Next
        LsSort = Nothing
    End Sub
    Public Function Reporte_Cronograma(ByVal Rpt As ETActivo, ByVal pIdPlanta As Int16) As ETActivo

        Dim lResult As ETActivo = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETActivo
        lResult = Datos.Activo.Reporte_Cronograma(Rpt, pIdPlanta)

        If lResult Is Nothing Then lResult = New ETActivo

        Return lResult

    End Function

    Public Function ConsultarCronograma6(ByVal Rpt As ETActivo, ByVal pIdPlanta As Int16) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Activo.ConsultarCronograma6(Rpt, pIdPlanta)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function ConsultarProgramacion_1(ByVal Rpt1 As ETActivo, ByVal Rpt2 As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt1 Is Nothing OrElse Rpt2 Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Activo.ConsultarProgramacion_1(Rpt1, Rpt2)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ListarCanteras_CosteoMineral(ByVal CosteoMineral As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Activo.ListarCanterasCosteoMineral(CosteoMineral)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function ListarCosteoMineral(ByVal Costeo As ETCanteraCosteo) As DataTable
        Return Datos.Activo.ListarCosteoMineral(Costeo)
    End Function

    Public Function ListarCosteoMineral_Save(ByVal Costeo As ETCanteraCosteo) As DataTable
        Return Datos.Activo.ListarCosteoMineral_Save(Costeo)
    End Function

    Public Function ListarCosteoMineral_Minas(ByVal Costeo As ETCanteraCosteo) As DataTable
        Return Datos.Activo.ListarCosteoMineral_Minas(Costeo)
    End Function

    Public Function CosteoMineral_ValidarBilleteSinCantera(ByVal Costeo As ETCanteraCosteo) As DataTable
        Return Datos.Activo.CosteoMineral_ValidarBilleteSinCantera(Costeo)
    End Function

    Public Function CosteoMineral_Listar() As DataTable
        Return Datos.Activo.CosteoMineral_Listar
    End Function

    Public Function ListarCosteoMineralxCantera(ByVal Costeo As ETCanteraCosteo) As DataTable
        Return Datos.Activo.ListarCosteoMineralxCantera(Costeo)
    End Function

    Public Function ListarCosteoMineralxCantera_por_Rangos(ByVal Costeo As ETCanteraCosteo) As DataTable
        Return Datos.Activo.ListarCosteoMineralxCanteraxRangos(Costeo)
    End Function

    Public Function ListarDetalleCosteoMineral(ByVal Costeo As ETCanteraCosteo, ByVal Opcion As Integer) As DataTable
        Return Datos.Activo.ListarDetalleCosteoMineral(Costeo, Opcion)
    End Function

    Public Function ObtenerVentasMesual(ByVal Costeo As ETCanteraCosteo) As Double
        Return Datos.Activo.ObtenerVentasMensual(Costeo)
    End Function

    Public Function ListarAgrupacion(ByVal TIPO As Int32, ByVal CODAGRUPACION As String) As DataTable
        Return Datos.Activo.ListarAgrupacion(TIPO, CODAGRUPACION)
    End Function


    Public Function ListarTrabajadorCategoria(ByVal Costeo As ETCanteraCosteo) As DataTable
        Return Datos.Activo.ListarCosteoMineral_Save(Costeo)

    End Function

    Public Function ListarCategoriaTrabajador(ByVal Costeo As ETCanteraCosteo) As DataTable
        Return Datos.Activo.ListarCategoriaTrabajador(Costeo)
    End Function

    Public Function ListarCategoriaTrabajadorMant(ByVal Costeo As ETCanteraCosteo) As DataTable
        Return Datos.Activo.ListarCategoriaTrabajadorMant(Costeo)
    End Function
End Class
