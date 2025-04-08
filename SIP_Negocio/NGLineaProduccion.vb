Imports SIP_Entidad
Imports SIP_Datos
Public Class NGLineaProduccion
    Public Function Mantto_LineaProduccion(ByVal LineaProduccion As ETLineaNegocio, ByVal Productos As List(Of ETLineaNegocio), ByVal Procesos As List(Of ETLineaNegocio)) As Integer

        Dim lResult As ETLineaNegocio = Nothing
        Dim Mensaje1, Mensaje2 As String
        If LineaProduccion Is Nothing Then
            Return 0
        End If
        If LineaProduccion.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & LineaProduccion.Codigo & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If

Ingreso:

        lResult = New ETLineaNegocio

        If LineaProduccion.Tipo = 3 Then GoTo Operacion

        Try

            If String.IsNullOrEmpty(LineaProduccion.Descripcion) Then
                MsgBox("Ingrese la Descripcion de la Linea de Producción", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return 0

        End Try

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else
            lResult.Respuesta = Datos.LineaProduccion.ManttoLineaProduccion(LineaProduccion, Productos, Procesos)
        End If
Salida:

        If lResult.Respuesta > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta

    End Function

    Public Function ConsultarLineaProduccion() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.LineaProduccion.ConsultarLineaProduccion

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ConsultarLineaProduccion_Productos(ByVal LineaProduccion As ETLineaNegocio) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.LineaProduccion.ConsultarLineaProduccion_Productos(LineaProduccion)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function ConsultarLineaProduccion_Procesos(ByVal LineaProduccion As ETLineaNegocio) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.LineaProduccion.ConsultarLineaProduccion_Procesos(LineaProduccion)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function


    Public Function Mantto_ProcesoProductivo(ByVal Proceso As ETLineaNegocio) As Integer

        Dim lResult As ETLineaNegocio = Nothing
        Dim Mensaje1, Mensaje2 As String
        If Proceso Is Nothing Then
            Return 0
        End If
        If Proceso.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & Proceso.Codigo & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If

Ingreso:

        lResult = New ETLineaNegocio

        If Proceso.Tipo = 3 Then GoTo Operacion

        Try

            If String.IsNullOrEmpty(Proceso.Descripcion) Then
                MsgBox("Ingrese la Descripcion del Proceso Productivo", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return 0

        End Try

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else
            lResult.Respuesta = Datos.LineaProduccion.Mantto_ProcesoProducto(Proceso)
        End If
Salida:

        If lResult.Respuesta > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult.Respuesta

    End Function

    Public Function Consultar_ProcesoProductivo() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.LineaProduccion.Consultar_ProcesoProductivo

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
End Class
