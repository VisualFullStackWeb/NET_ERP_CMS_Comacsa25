Imports SIP_Entidad
Imports SIP_Datos
Public Class NGRuma

    Public Function ConsultarRuma1() As ETMyLista

        Dim lResult As ETMyLista

        lResult = New ETMyLista
        lResult = Datos.Ruma.ConsultarRuma1

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarMineral1() As ETMyLista

        Dim lResult As ETMyLista

        lResult = New ETMyLista
        lResult = Datos.Ruma.ConsultarMineral1

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarRuma2(ByVal P As ETProducto) As DataTable

Ingreso:

        ConsultarRuma2 = New DataTable

        With ConsultarRuma2
            .Columns.Add("CodRuma")
            .Columns.Add("DesRuma")
            .Columns.Add("CodMineral")
            .Columns.Add("DesMineral")
            .Columns.Add("Cantera")
        End With

Operacion:

        Dim List As New List(Of ETRuma)

        List = Datos.Ruma.ConsultarRuma2(P)

Salida:

        If Not (List Is Nothing OrElse List.Count = 0) Then
            For Each W As ETRuma In List
                Dim Row As DataRow = ConsultarRuma2.NewRow
                Row("CodRuma") = W.CodRuma
                Row("DesRuma") = W.Descripcion
                Row("CodMineral") = W.InstMineral.CodMineral
                Row("DesMineral") = W.InstMineral.Descripcion
                Row("Cantera") = W.InstMineral.Cantera
                ConsultarRuma2.Rows.Add(Row)
            Next
        End If

        Return ConsultarRuma2

    End Function

    Public Function CuadroxOrdenxRuma(ByVal P As ETProducto) As List(Of ETRuma)

Ingreso:

        CuadroxOrdenxRuma = New List(Of ETRuma)

        If P.CodProducto = Nothing OrElse P.CodProducto = String.Empty Then
            MsgBox("Ingrese el Producto", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If

        If Not IsNumeric(P.ID) OrElse P.ID = 0 Then
            MsgBox("Ingrese el Enlace del Producto", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If

Operacion:

        CuadroxOrdenxRuma = Datos.Ruma.CuadroxOrdenxRuma(P)

Confirmacion:

        If CuadroxOrdenxRuma Is Nothing OrElse CuadroxOrdenxRuma.Count = 0 Then
            MsgBox("No posee Ruma(s) para el Producto", MsgBoxStyle.Exclamation, msgComacsa)
            CuadroxOrdenxRuma = New List(Of ETRuma)
            GoTo Salida
        End If

Salida:

        Return CuadroxOrdenxRuma

    End Function

    Public Function CuadroxOrdenxRumaxProductoxSuministro(ByVal P As ETProducto) As List(Of ETRuma)

Ingreso:

        CuadroxOrdenxRumaxProductoxSuministro = New List(Of ETRuma)

        If P.CodProducto = Nothing OrElse P.CodProducto = String.Empty Then
            MsgBox("Ingrese el Producto", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If

        If Not IsNumeric(P.ID) OrElse P.ID = 0 Then
            MsgBox("Ingrese el Enlace del Producto", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If

Operacion:

        CuadroxOrdenxRumaxProductoxSuministro = Datos.Ruma.CuadroxOrdenxRumaxProductoxSuministro(P)

Confirmacion:

        If CuadroxOrdenxRumaxProductoxSuministro Is Nothing OrElse CuadroxOrdenxRumaxProductoxSuministro.Count = 0 Then
            MsgBox("No posee Ruma(s) para el Producto", MsgBoxStyle.Exclamation, msgComacsa)
            CuadroxOrdenxRumaxProductoxSuministro = New List(Of ETRuma)
            GoTo Salida
        End If

Salida:

        Return CuadroxOrdenxRumaxProductoxSuministro

    End Function

    Public Function CuadroxOrdenxRumaxProductoxSuministro_Relacion(ByVal P As ETProducto) As ETMyLista

Ingreso:

        CuadroxOrdenxRumaxProductoxSuministro_Relacion = New ETMyLista

        If P.CodProducto = Nothing OrElse P.CodProducto = String.Empty Then
            MsgBox("Ingrese el Producto", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If

        If Not IsNumeric(P.ID) OrElse P.ID = 0 Then
            MsgBox("Ingrese el Enlace del Producto", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If

Operacion:

        CuadroxOrdenxRumaxProductoxSuministro_Relacion = Datos.Ruma.CuadroxOrdenxRumaxProductoxSuministro_Relacion(P)

Confirmacion:

        If CuadroxOrdenxRumaxProductoxSuministro_Relacion Is Nothing OrElse CuadroxOrdenxRumaxProductoxSuministro_Relacion.Validacion = False Then
            MsgBox("No posee Ruma(s) para el Producto", MsgBoxStyle.Exclamation, msgComacsa)
            CuadroxOrdenxRumaxProductoxSuministro_Relacion = New ETMyLista
            GoTo Salida
        End If

Salida:

        Return CuadroxOrdenxRumaxProductoxSuministro_Relacion

    End Function

    Public Function CuadroxOrdenxRumaxMineral(ByVal P As ETProducto) As List(Of ETRuma)

Ingreso:

        CuadroxOrdenxRumaxMineral = New List(Of ETRuma)

        If P.CodProducto = Nothing OrElse P.CodProducto = String.Empty Then
            MsgBox("Ingrese la Ruma", MsgBoxStyle.Exclamation, msgComacsa)
            GoTo Salida
        End If

Operacion:

        CuadroxOrdenxRumaxMineral = Datos.Ruma.CuadroxOrdenxRumaxMineral(P)

Confirmacion:

        If CuadroxOrdenxRumaxMineral Is Nothing OrElse CuadroxOrdenxRumaxMineral.Count = 0 Then
            MsgBox("No posee Mineral(s) para la Ruma", MsgBoxStyle.Exclamation, msgComacsa)
            CuadroxOrdenxRumaxMineral = New List(Of ETRuma)
            GoTo Salida
        End If

Salida:

        Return CuadroxOrdenxRumaxMineral

    End Function

    Public Function CuadroxOrdenxProdTerminadoxSuministro(ByVal P As ETProducto) As List(Of ETRuma)

Ingreso:

        CuadroxOrdenxProdTerminadoxSuministro = New List(Of ETRuma)

        If P.CodProducto = Nothing OrElse P.CodProducto = String.Empty Then
            Select Case P.TipoProducto
                Case "P"
                    MsgBox("Ingrese el Producto Terminado", MsgBoxStyle.Exclamation, msgComacsa)
                Case "R"
                    MsgBox("Ingrese el Producto Terminado Recirculado", MsgBoxStyle.Exclamation, msgComacsa)
                Case "S"
                    MsgBox("Ingrese el Suministro", MsgBoxStyle.Exclamation, msgComacsa)
            End Select
            GoTo Salida
        End If

Operacion:

        CuadroxOrdenxProdTerminadoxSuministro = Datos.Ruma.CuadroxOrdenxProductoxSuministro(P)

Confirmacion:

        If CuadroxOrdenxProdTerminadoxSuministro Is Nothing OrElse CuadroxOrdenxProdTerminadoxSuministro.Count = 0 Then
            MsgBox("No posee Mineral(s) para la Ruma", MsgBoxStyle.Exclamation, msgComacsa)
            Select Case P.TipoProducto
                Case "P"
                    MsgBox("No posee Producto Terminado(s) para la Formulación", MsgBoxStyle.Exclamation, msgComacsa)
                Case "R"
                    MsgBox("No posee Producto Terminado Recirculado(s) para la Formulación", MsgBoxStyle.Exclamation, msgComacsa)
                Case "S"
                    MsgBox("No posee Suministro(s) para la Formulación", MsgBoxStyle.Exclamation, msgComacsa)
            End Select
            CuadroxOrdenxProdTerminadoxSuministro = New List(Of ETRuma)
            GoTo Salida
        End If

Salida:

        Return CuadroxOrdenxProdTerminadoxSuministro

    End Function
    Public Function ConsultaRumaSeteos(ByVal Ent As ETRuma) As DataTable
        Return Datos.Ruma.ConsultaRumaSeteos(Ent)
    End Function
End Class
