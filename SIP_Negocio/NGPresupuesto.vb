Imports SIP_Entidad
Imports SIP_Datos

Public Class NGPresupuesto
    Public Function Mantenedor_Presupuesto(ByVal Entidad As ETPresupuesto, _
                                            ByVal Ls_PresItem_Del As List(Of ETPresupuestoDetalle), _
                                            ByVal Ls_PresItem As List(Of ETPresupuestoDetalle), _
                                            ByVal Ls_Material As List(Of ETPresupuestoMaterial), _
                                            ByVal Ls_Material_Del As List(Of ETPresupuestoMaterial), _
                                            ByVal Ls_Equipo As List(Of ETPresupuestoEquipo), _
                                            ByVal Ls_Equipo_Del As List(Of ETPresupuestoEquipo), _
                                            ByVal Ls_ManoObra As List(Of ETPresupuestoManoObra), _
                                            ByVal Ls_ManoObra_Del As List(Of ETPresupuestoManoObra), _
                                            ByVal Ls_Servicio As List(Of ETPresupuestoServicio), _
                                            ByVal Ls_Servicio_Del As List(Of ETPresupuestoServicio), _
                                            ByVal Ls_Plan As List(Of ETPresupuestoPlan), _
                                            ByVal Ls_Plan_Del As List(Of ETPresupuestoPlan), _
                                            ByVal Ls_Plan_Material As List(Of ETPresupuestoPlanRecursos), _
                                            ByVal Ls_Plan_Equipo As List(Of ETPresupuestoPlanRecursos), _
                                            ByVal Ls_Plan_ManoObra As List(Of ETPresupuestoPlanRecursos), _
                                            ByVal Ls_Plan_Servicio As List(Of ETPresupuestoPlanRecursos), _
                                            ByVal Ls_Plan_Equipo_Asig As List(Of ETPresupuestoPlanRecursosAsignacion), _
                                            ByVal Ls_Plan_Equipo_Asig_Del As List(Of ETPresupuestoPlanRecursosAsignacion), _
                                            ByVal Ls_Plan_ManoObra_Asig As List(Of ETPresupuestoPlanRecursosAsignacion), _
                                            ByVal Ls_Plan_ManoObra_Asig_Del As List(Of ETPresupuestoPlanRecursosAsignacion)) As ETPresupuesto

        Dim lResult As ETPresupuesto = Nothing
        Dim Mensaje1, Mensaje2 As String
        If Entidad Is Nothing Then
            Return Nothing
        End If
        If Entidad.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & Entidad.Area & " - " & Entidad.Cod_Presup & " ?"
        End If

Ingreso:

        lResult = New ETPresupuesto

        If Entidad.Tipo = 3 Then
            GoTo Operacion
        End If

        Try

            If String.IsNullOrEmpty(Entidad.Cod_Area) Then
                MsgBox("Ingrese el Área", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If

            If String.IsNullOrEmpty(Entidad.Cod_EncargadoArea) Then
                MsgBox("El área no tiene Encargado o Jefatura", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If

            If String.IsNullOrEmpty(Entidad.Cliente) Then
                MsgBox("Ingrese el Cliente", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If

            If Val(Entidad.EquipoID) = 0 Then
                MsgBox("Ingrese el Equipo", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If

            If Entidad.TipoProceso = "1" Then
                If String.IsNullOrEmpty(Entidad.ValorControl) Then
                    MsgBox("Ingrese el Valor del Mantenimiento", MsgBoxStyle.Exclamation, msgComacsa)
                    Return Nothing
                End If

                If Val(Entidad.AtributoControl) = 0 Then
                    MsgBox("", MsgBoxStyle.Exclamation, msgComacsa)
                    Return Nothing
                End If
            End If

            If String.IsNullOrEmpty(Entidad.Cod_Prioridad) Then
                MsgBox("Seleccione la Prioridad", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If

            If String.IsNullOrEmpty(Entidad.Moneda) Then
                MsgBox("Seleccione la Moneda", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If

            If Val(Entidad.TipoCambio) = 0 Then
                MsgBox("No hay Tipo de Cambio para la Fecha", MsgBoxStyle.Exclamation, msgComacsa)

            End If

            If Val(Entidad.Total) < 0 Then
                MsgBox("El presupuesto no puede ser Negativo", MsgBoxStyle.Exclamation, msgComacsa)
                Return Nothing
            End If

            If Ls_PresItem.Count > 0 Then
                For Each Row As ETPresupuestoDetalle In Ls_PresItem
                    If Val(Row.Precio) <= 0 Then
                        MsgBox("Los Precios deben ser mayor a Cero", MsgBoxStyle.Exclamation, msgComacsa)
                        Return Nothing
                    End If
                    If Val(Row.Metrado) <= 0 Then
                        MsgBox("El metrado debe ser mayor a Cero", MsgBoxStyle.Exclamation, msgComacsa)
                        Return Nothing
                    End If
                    If Row.FechaInicio > Row.FechaTerminacion Then
                        MsgBox("La Fecha de Inicio debe menor o igual a la Fecha de Termino", MsgBoxStyle.Exclamation, msgComacsa)
                        Return Nothing
                    End If
                Next
            End If
        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return Nothing

        End Try

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return Nothing
        Else
            lResult = Datos.Presupuesto.Mantenedor_Presupuesto(Entidad, _
                      Ls_PresItem_Del, Ls_PresItem, Ls_Material, Ls_Material_Del, _
                      Ls_Equipo, Ls_Equipo_Del, Ls_ManoObra, Ls_ManoObra_Del, _
                      Ls_Servicio, Ls_Servicio_Del, Ls_Plan, Ls_Plan_Del, _
                      Ls_Plan_Material, Ls_Plan_Equipo, Ls_Plan_ManoObra, _
                      Ls_Plan_Servicio, Ls_Plan_Equipo_Asig, Ls_Plan_Equipo_Asig_Del, _
                      Ls_Plan_ManoObra_Asig, Ls_Plan_ManoObra_Asig_Del)
        End If

Salida:

        If Not (lResult Is Nothing) Then
            If Entidad.Tipo = 1 Then
                Mensaje2 = "Se Generó el Presupuesto: " & Entidad.Area_Abrev & " - " & lResult.Cod_Presup
            ElseIf Entidad.Tipo = 2 Then
                Mensaje2 = "Se modificó el Presupuesto: " & Entidad.Area_Abrev & " - " & lResult.Cod_Presup
            Else
                Mensaje2 = "Se Anularon Correctamente los Datos"
            End If

            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If
Salir:
        Return lResult
    End Function

  

    Public Function Consultar_Presupuesto() As ETMyLista
        Dim lResult As New ETMyLista
        lResult = Datos.Presupuesto.Consultar_Presupuesto
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Consultar_Presupuesto_Pendinte_Aprobar() As ETMyLista
        Dim lResult As New ETMyLista
        lResult = Datos.Presupuesto.Consultar_Presupuesto_Pendiente_Aprobar
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Consultar_PresupDetalle(ByVal Entidad As ETPresupuesto) As ETMyLista
        Dim lResult As New ETMyLista
        lResult = Datos.Presupuesto.Consultar_Presup_Detalle(Entidad)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function Consultar_TipoCambio(ByVal Entidad As ETPresupuesto) As Double
        Dim lResult As Double = 0
        If Entidad Is Nothing Then Return 0
        lResult = Datos.Presupuesto.Consultar_TipoCambio(Entidad)
        Return lResult
    End Function

    Public Function Consultar_Presupuesto_OT(ByVal Ent_Presup As ETPresupuesto) As ETMyLista
        Dim lResult As New ETMyLista
        lResult = Datos.Presupuesto.Consultar_Presupuesto_OT(Ent_Presup)
        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult
    End Function

    Public Function IsPresupuestoPendienteAprobacion(ByVal Presupuesto As ETPresupuesto) As Boolean
        Dim lresult As Integer = 0
        Dim Mensaje As String = String.Empty
        If Presupuesto Is Nothing Then
            Return False
        End If
        lresult = Datos.Presupuesto.Validar_Presupuesto_Pendiente_Aprobacion(Presupuesto)

        If lresult = 0 Then
            Return True
        Else
            Select Case lresult
                Case 1
                    Mensaje = "El Monto presupuestado debe ser mayor a cero"
                Case 2
                    Mensaje = "El Presupuesto no cuenta con Partidas"
                Case 3
                    Mensaje = "Existen Partidas Sin Recursos"
                Case 4
                    Mensaje = "No se creado los Periodos de las Partidas"
                Case 5
                    Mensaje = "Debe Planificar Todos los Materiales"
                Case 6
                    Mensaje = "Debe Planificar Todos los Equipos"
                Case 7
                    Mensaje = "Debe Planificar la Mano de Obra"
                Case 8
                    Mensaje = "Debe Planificar los Servicios"
                Case 9
                    Mensaje = "Debe asignar las Horas a los Equipos"
                Case Else
                    Mensaje = "Debe asignar las Horas al Personal"
            End Select

            MsgBox(Mensaje, MsgBoxStyle.Critical, msgComacsa)
            Return False
        End If
    End Function

    Public Function Aprobar_Presupuesto(ByVal PresupuestoAprobar As List(Of ETPresupuesto)) As Integer
        Dim lResult As Integer
        lResult = Datos.Presupuesto.Aprobar_Presupuesto(PresupuestoAprobar)
        Return lResult
    End Function

    Public Function Anular_Presupuesto(ByVal Presupuesto As ETPresupuesto) As Integer
        Dim lResult As Integer = 0
        Dim Status As String = String.Empty
        Status = Datos.Presupuesto.Obtener_Presupuesto_Estado(Presupuesto)
        If Not (Status.Trim = "D" OrElse Status.Trim = "C") Then
            MsgBox("El Presupuesto ya fue abrobado", MsgBoxStyle.Critical, msgComacsa)
            Return 0
        End If
        lResult = Datos.Presupuesto.Mantenimiento_Presupuesto_DatosGenerales(Presupuesto)
        If lResult > 0 Then
            MsgBox("Se Anuló el Presupuesto Correctamente", MsgBoxStyle.Information, msgComacsa)
        Else
            MsgBox("No se pudo Anular el Presupuesto", MsgBoxStyle.Critical, msgComacsa)
        End If
        Return lResult
    End Function

End Class
