Imports SIP_Datos
Imports SIP_Entidad
Public Class NGPartida

    Public Function Mantenedor_Partida(ByVal Entidad As ETPartida) As Integer
        Dim lResult As ETPartida = Nothing
        Dim Mensaje1, Mensaje2 As String
        If Entidad Is Nothing Then
            Return 0
        End If
        If Entidad.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & Entidad.Nodo & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If

Ingreso:

        lResult = New ETPartida

        If Entidad.Tipo = 3 Then
            GoTo Operacion
        ElseIf Entidad.Tipo = 5 Then
            GoTo Salto
        End If

        Try

            Select Case Entidad.Level
                Case 1
                    If Val(Entidad.LinNeg) = 0 Then
                        MsgBox("Seleccione la Linea de Negocio", MsgBoxStyle.Exclamation, msgComacsa)
                        Return 0
                    End If
                Case 2
                    If Val(Entidad.TipoProceso) = 0 Then
                        MsgBox("Seleccione el Tipo de Proceso", MsgBoxStyle.Exclamation, msgComacsa)
                        Return 0
                    End If
                Case 3

                    If Entidad.TipoProceso = "1" Then
                        If String.IsNullOrEmpty(Entidad.ValorControl) Then
                            MsgBox("Ingrese el Valor de Mantenimiento", MsgBoxStyle.Exclamation, msgComacsa)
                            Return 0
                        End If

                        If Val(Entidad.AtributoControl) = 0 Then
                            MsgBox("Seleccione el Atributo de Control", MsgBoxStyle.Exclamation, msgComacsa)
                            Return 0
                        End If
                    Else
                        If String.IsNullOrEmpty(Entidad.ValorControl) Then
                            MsgBox("Ingrese el Mantenimiento", MsgBoxStyle.Exclamation, msgComacsa)
                            Return 0
                        End If
                    End If

                Case 4
                    If Val(Entidad.FamiliaEquipo) = 0 Then
                        MsgBox("Seleccione el Atributo de Control", MsgBoxStyle.Exclamation, msgComacsa)
                        Return 0
                    End If
                Case 5
                    If Entidad.ManttoGeneral = False Then
                        If Val(Entidad.ParteEquipo) = 0 Then
                            MsgBox("Seleccione la Parte del Equipo", MsgBoxStyle.Exclamation, msgComacsa)
                            Return 0
                        End If
                    End If
                Case Else
                    MsgBox("El Sistema no Soporta más de 5 Niveles", MsgBoxStyle.Exclamation, msgComacsa)
                    Return 0
            End Select

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return 0

        End Try

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else
Salto:
            lResult.Respuesta = Datos.Partida_Mantto.Consultar_Partida_Duplicada(Entidad)
            If lResult.Respuesta = 0 Then
                lResult.Respuesta = Datos.Partida_Mantto.Mantenimiento_Partida(Entidad)
            Else
                MsgBox("La Partida ya existe", MsgBoxStyle.Critical, msgComacsa)
                lResult.Respuesta = 0
                GoTo Salir
            End If

        End If

Salida:

        If lResult.Respuesta > 0 Then
            If Not (Entidad.Tipo = 5) Then
                MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            End If

            lResult.Validacion = Boolean.TrueString
        End If
Salir:
        Return lResult.Respuesta

    End Function
    Public Function Consultar_Partida() As DataSet
        Dim ds As DataSet
        Dim lResult As ETMyLista = Nothing

        ds = Datos.Partida_Mantto.Consultar_Partida

        If ds Is Nothing Then
            Return Nothing
        Else
            Return ds
        End If
    End Function
    Public Function Consultar_Partida_Nodo(ByVal Entidad As ETPartida) As DataSet
        Dim ds As DataSet
        Dim lResult As ETMyLista = Nothing

        ds = Datos.Partida_Mantto.Consultar_Partida_Nodo(Entidad)

        If ds Is Nothing Then
            Return Nothing
        Else
            Return ds
        End If
    End Function

    Public Function Mantenedor_Partida_Recursos(ByVal Entidad As ETPartida, ByVal Lista_Mat As List(Of ETPartidaMaterial), ByVal Lista_Mat_Del As List(Of ETPartidaMaterial), _
    ByVal Lista_Eq As List(Of ETPartidaEquipo), ByVal Lista_Eq_Del As List(Of ETPartidaEquipo), _
    ByVal Lista_MO As List(Of ETPartidaManoObra), ByVal Lista_MO_Del As List(Of ETPartidaManoObra), _
    ByVal Lista_Ser As List(Of ETPartidaServicio), ByVal Lista_Ser_Del As List(Of ETPartidaServicio)) As Integer
        Dim lResult As ETPartida = Nothing
        Dim Mensaje1, Mensaje2 As String
        If Entidad Is Nothing Then
            Return 0
        End If

        If Lista_Mat Is Nothing OrElse Lista_Mat_Del Is Nothing _
        OrElse Lista_Eq Is Nothing OrElse Lista_Eq_Del Is Nothing _
        OrElse Lista_MO Is Nothing OrElse Lista_MO_Del Is Nothing _
        OrElse Lista_Ser Is Nothing OrElse Lista_Ser_Del Is Nothing Then
            Return 0
        End If


        If Entidad.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & Entidad.Nodo & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If

Ingreso:

        lResult = New ETPartida

        Try

            If Entidad.ManttoGeneral = False Then
                If Val(Entidad.ParteEquipo) = 0 Then
                    MsgBox("Seleccione la Parte del Equipo", MsgBoxStyle.Exclamation, msgComacsa)
                    Return 0
                End If
            End If

            If Val(Entidad.Factor) <= 0 Then
                MsgBox("El Factor debe ser mayor que cero", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If Val(Entidad.Jornada) <= 0 Then
                MsgBox("la Jornada debe ser mayor que cero", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If String.IsNullOrEmpty(Entidad.UniMed.Trim) Then
                MsgBox("Ingrese la Unidad de Medida de la Jornada", MsgBoxStyle.Exclamation, msgComacsa)
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
            lResult.Respuesta = Datos.Partida_Mantto.Consultar_Partida_Duplicada(Entidad)
            If lResult.Respuesta > 0 Then
                MsgBox("La Partida ya existe", MsgBoxStyle.Critical, msgComacsa)
                lResult.Respuesta = 0
                GoTo Salir
            Else
                lResult.Respuesta = Datos.Partida_Mantto.Mantenimiento_Partida(Entidad)

                If Lista_Mat_Del.Count > 0 Then
                    lResult.Respuesta = lResult.Respuesta + Datos.Partida_Material.Mantenedor_Part_Material(Lista_Mat_Del)
                End If
                If Lista_Mat.Count > 0 Then
                    lResult.Respuesta = lResult.Respuesta + Datos.Partida_Material.Mantenedor_Part_Material(Lista_Mat)
                End If
                If Lista_Eq_Del.Count > 0 Then
                    lResult.Respuesta = lResult.Respuesta + Datos.Partida_Equipo.Mantenedor_Part_Equipo(Lista_Eq_Del)
                End If
                If Lista_Eq.Count > 0 Then
                    lResult.Respuesta = lResult.Respuesta + Datos.Partida_Equipo.Mantenedor_Part_Equipo(Lista_Eq)
                End If
                If Lista_MO_Del.Count > 0 Then
                    lResult.Respuesta = lResult.Respuesta + Datos.Partida_ManoObra.Mantenedor_Part_ManoObra(Lista_MO_Del)
                End If
                If Lista_MO.Count > 0 Then
                    lResult.Respuesta = lResult.Respuesta + Datos.Partida_ManoObra.Mantenedor_Part_ManoObra(Lista_MO)
                End If
                If Lista_Ser_Del.Count > 0 Then
                    lResult.Respuesta = lResult.Respuesta + Datos.Partida_Servicio.Mantenedor_Part_Servicio(Lista_Ser_Del)
                End If
                If Lista_Ser.Count > 0 Then
                    lResult.Respuesta = lResult.Respuesta + Datos.Partida_Servicio.Mantenedor_Part_Servicio(Lista_Ser)
                End If
            End If
        End If
Salida:

        If lResult.Respuesta > 0 Then
            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If
Salir:
        Return lResult.Respuesta
    End Function
    Public Function Consultar_Partida_Material(ByVal Entidad As ETPartida) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Partida_Material.Consultar_Part_Material(Entidad)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function Consultar_Partida_Equipo(ByVal Entidad As ETPartida) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Partida_Equipo.Consultar_Part_Equipo(Entidad)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function Consultar_Partida_ManoObra(ByVal Entidad As ETPartida) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Partida_ManoObra.Consultar_Part_ManoObra(Entidad)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function Consultar_Partida_Servicio(ByVal Entidad As ETPartida) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Partida_Servicio.Consultar_Part_Servicio(Entidad)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function Consultar_Lista_Material() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Partida_Material.Consultar_Lista_Material

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function Consultar_Lista_Equipo() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Partida_Equipo.Consultar_Lista_Equipo

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function Consultar_Lista_ManoObra() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Partida_ManoObra.Consultar_Lista_ManoObra

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function Consultar_Lista_Servicio() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Partida_Servicio.Consultar_Lista_Servicio

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
