Imports SIP_Entidad
Imports SIP_Datos

Public Class NGPresupuestoDet
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
    Public Function Consultar_Presupuesto_Material(ByVal Entidad As ETPresupuestoDetalle) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Presupuesto_Material.Consultar_Presup_Material(Entidad)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function Consultar_Presupuesto_Equipo(ByVal Entidad As ETPresupuestoDetalle) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Presupuesto_Equipo.Consultar_Presup_Equipo(Entidad)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Consultar_Presupuesto_ManoObra(ByVal Entidad As ETPresupuestoDetalle) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Presupuesto_ManoObra.Consultar_Presup_ManoObra(Entidad)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function
    Public Function Consultar_Presupuesto_Servicio(ByVal Entidad As ETPresupuestoDetalle) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Presupuesto_Servicios.Consultar_Presup_Servicio(Entidad)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Consultar_Presupuesto_Plan(ByVal Entidad As ETPresupuestoPlan) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Presupuesto_Plan.Consultar_PresupuestoPlan(Entidad)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function

    Public Function Consultar_Presupuesto_Plan_Material(ByVal Entidad As ETPresupuestoPlanRecursos) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Presupuesto_Plan_Recurso.Consultar_PresupuestoPlanMaterial(Entidad)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function

    Public Function Consultar_Presupuesto_Plan_Equipo(ByVal Entidad As ETPresupuestoPlanRecursos) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Presupuesto_Plan_Recurso.Consultar_PresupuestoPlanEquipo(Entidad)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function
    Public Function Consultar_Presupuesto_Plan_Equipo_Asignacion(ByVal Entidad As ETPresupuestoPlanRecursosAsignacion) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Presupuesto_Plan_Recurso_Asignacion.Consultar_PlanEquipo_Asignacion(Entidad)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function
    Public Function Validar_Presupuesto_Plan_Equipo_Asignacion(ByVal Entidad As ETPresupuestoPlanRecursosAsignacion) As Integer
        Dim lResult As Integer
        If Entidad Is Nothing Then Return 0

        lResult = Datos.Presupuesto_Plan_Recurso_Asignacion.Validar_PlanEquipo_Asignacion(Entidad)

        Return lResult
    End Function
    Public Function Consultar_Presupuesto_Plan_ManoObra(ByVal Entidad As ETPresupuestoPlanRecursos) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Presupuesto_Plan_Recurso.Consultar_PresupuestoPlanManoObra(Entidad)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function
    Public Function Consultar_Presupuesto_Plan_ManoObra_Asignacion(ByVal Entidad As ETPresupuestoPlanRecursosAsignacion) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Presupuesto_Plan_Recurso_Asignacion.Consultar_PlanManoObra_Asignacion(Entidad)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function
    Public Function Validar_Presupuesto_Plan_ManoObra_Asignacion(ByVal Entidad As ETPresupuestoPlanRecursosAsignacion) As Integer
        Dim lResult As Integer
        If Entidad Is Nothing Then Return 0

        lResult = Datos.Presupuesto_Plan_Recurso_Asignacion.Validar_PlanManoObra_Asignacion(Entidad)
        
        Return lResult
    End Function
    Public Function Consultar_Presupuesto_Plan_Servicio(ByVal Entidad As ETPresupuestoPlanRecursos) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Entidad Is Nothing Then Return Nothing

        lResult = New ETMyLista
        lResult = Datos.Presupuesto_Plan_Recurso.Consultar_PresupuestoPlanServicio(Entidad)
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
        lResult = Datos.Presupuesto_Material.Consultar_Lista_Material

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
        lResult = Datos.Presupuesto_Equipo.Consultar_Lista_Equipo

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
        lResult = Datos.Presupuesto_ManoObra.Consultar_Lista_ManoObra

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
        lResult = Datos.Presupuesto_Servicios.Consultar_Lista_Servicio

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
