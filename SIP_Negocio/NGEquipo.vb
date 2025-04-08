Imports SIP_Entidad
Imports SIP_Datos

Public Class NGEquipo
    Public Function Mantto_Equipo(ByVal Entidad As ETEquipo, ByVal Ls_Atributo As List(Of ETAtributo), ByVal Ls_AtributoParteEq As List(Of ETAtributo)) As Long
        Dim Equipo As Long = 0
        Dim lResult As ETEquipo = Nothing
        Dim Gastos As Integer = 0
        Dim Mensaje1, Mensaje2 As String
        If Entidad Is Nothing Then
            Return 0
        End If
        If Entidad.Tipo <> 3 Then
            Mensaje1 = "¿Seguro desea Guardar los cambios?"
            Mensaje2 = "Se Guardaron Correctamente los Datos"
        Else
            Mensaje1 = "¿Seguro desea Eliminar el Registro: " & Entidad.Codigo & " ?"
            Mensaje2 = "Se Eliminaron Correctamente los Datos"
        End If

Ingreso:

        lResult = New ETEquipo

        If Entidad.Tipo = 3 Then

            Gastos = Datos.Equipo.Validar_Equipo_Mantenimiento(Entidad)

            If Gastos > 0 Then
                MsgBox("No puede anular el equipo porque tiene Mantenimientos", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If
            GoTo Operacion
        Else
            If Not (String.IsNullOrEmpty(Entidad.CodigoAnterior.Trim)) Then
                If Datos.Equipo.Validar_Equipo_CodigoAnterior(Entidad) Then
                    MsgBox("El Código Anterior ya fue Anexado a Otro Equipo", MsgBoxStyle.Exclamation, msgComacsa)
                    Return 0
                End If
            End If
        End If

        Try
            If String.IsNullOrEmpty(Entidad.LinNeg) Then
                MsgBox("Seleccione la Linea de Negocio", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If Val(Entidad.FamiliaEqID) = 0 Then
                MsgBox("Seleccione la Linea de Negocio", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If Ls_Atributo Is Nothing Or Ls_Atributo.Count = 0 Then
                MsgBox("La Familia del Equipo No esta enlazado con Atributos", MsgBoxStyle.Exclamation, msgComacsa)
                Return 0
            End If

            If String.IsNullOrEmpty(Entidad.CodResponsable.Trim) Then
                MsgBox("Ingrese al Responsable del Equipo", MsgBoxStyle.Exclamation, msgComacsa)
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
            Equipo = Datos.Equipo.Mantto_Equipo_Image(Entidad, Ls_Atributo, Ls_AtributoParteEq)
            If Equipo > 0 Then
                lResult.Respuesta = 1
            Else
                lResult.Respuesta = 0
            End If

        End If

Salida:

        If lResult.Respuesta > 0 Then
            If Entidad.Tipo = 3 Then
                MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
            End If

            lResult.Validacion = Boolean.TrueString
        End If

        Return Equipo
    End Function
    Public Function Mantto_Equipo_ParteEq(ByVal EntEquipo As ETEquipo, ByVal EntAtributo As ETAtributo) As Long
        Dim lResult As ETAtributo = Nothing
        If EntAtributo Is Nothing Then
            Return 0
        End If
Ingreso:
        lResult = New ETAtributo
Operacion:
        lResult.Respuesta = Datos.Equipo.Mantto_Equipo_ParteEq(EntEquipo, EntAtributo)
Salida:
        Return lResult.Respuesta

    End Function
    Public Function Consultar_Equipo() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Equipo.Consultar_Equipo()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function Consultar_Equipo_Activo() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Equipo.Consultar_Equipo_Activos()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function Consultar_Equipo_Por_Familia(ByVal Entidad As ETEquipo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Equipo.Consultar_Equipo_Por_Familia(Entidad)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function Consultar_Equipo_Req(ByVal EntEq As ETEquipo) As DataSet

        Dim ds As DataSet

        ds = Datos.Equipo.Consultar_Equipo_Req(EntEq)

        Return ds

    End Function
    Public Function Consultar_Atributos_Equipo(ByVal EntEq As ETEquipo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Equipo.ConsultarAtributosEquipo(EntEq)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function ConsultarFamiliaEquipo(ByVal EntFamEq As ETFamiliaEquipo) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Equipo.ConsultarAtributosEquipo_New(EntFamEq)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function Consultar_ParteEq_FamiliaEquipo(ByVal EntFamEq As ETFamiliaEquipo) As DataSet

        Dim ds As DataSet
        Dim lResult As ETMyLista = Nothing

        ds = Datos.Equipo.ConsultarAtributosParteEquipo_New(EntFamEq)

        If ds Is Nothing Then
            Return Nothing
        Else
            Return ds
        End If

    End Function
    Public Function Consultar_Equipo_ParteEq(ByVal EntEquipo As ETEquipo) As DataSet

        Dim ds As DataSet
        Dim lResult As ETMyLista = Nothing

        ds = Datos.Equipo.Consultar_Equipo_ParteEquipo(EntEquipo)

        If ds Is Nothing Then
            Return Nothing
        Else
            Return ds
        End If

    End Function
    Public Function Consultar_Equipo_ParteEq_Atrib_Valor(ByVal EntNodo As ETAtributo) As ETMyLista
        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Equipo.ConsultarEquipo_ParteEq_Atrib_Valor(EntNodo)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function
    Public Function Consultar_Equipo_Mantenimiento(ByVal Ent_Eq As ETEquipo) As ETMyLista
        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Equipo.Consultar_Equipo_Mantenimiento(Ent_Eq)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult


    End Function
    Public Function Consultar_Equipo_Pendiente_Contabilidad() As ETMyLista
        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        Entidad.Equipo = New ETEquipo
        Entidad.Equipo.Tipo = 11
        lResult = Datos.Equipo.Consultar_Equipo_Contabilidad(Entidad.Equipo)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function
    Public Function Consultar_Equipo_Enlazado_Contabilidad() As ETMyLista
        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        Entidad.Equipo = New ETEquipo
        Entidad.Equipo.Tipo = 12
        lResult = Datos.Equipo.Consultar_Equipo_Contabilidad(Entidad.Equipo)

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If
        Return lResult
    End Function
    Public Function Validar_Equipo_Codigo_Contabilidad(ByVal Equipo As ETEquipo) As Boolean
        Return Datos.Equipo.Validar_Equipo_CodigoContabilidad(Equipo)
    End Function
    Public Function Update_Equipo_Contabilidad(ByVal ListaPendiente As List(Of ETEquipo), ByVal Ls_DesEnlazar As List(Of ETEquipo)) As Integer
        Dim lResult As Long = 0
        Dim Mensaje1, Mensaje2 As String
        Mensaje1 = "¿Seguro desea Guardar los cambios?"
        Mensaje2 = "Se Guardaron Correctamente los Datos"

Ingreso:

        If (ListaPendiente.Count + Ls_DesEnlazar.Count) = 0 Then
            MsgBox("No hay Registros que actualizar", MsgBoxStyle.Exclamation, msgComacsa)
            Return 0
        End If

Operacion:


        If MsgBox(Mensaje1, MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return 0
        Else
            lResult = Datos.Equipo.Update_Equipo_Contabilidad(ListaPendiente, Ls_DesEnlazar)

        End If

Salida:

        If lResult > 0 Then

            MsgBox(Mensaje2, MsgBoxStyle.Information, msgComacsa)
        End If

        Return lResult
    End Function

End Class
