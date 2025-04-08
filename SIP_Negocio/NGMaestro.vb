Imports SIP_Entidad
Imports SIP_Datos
Public Class NGMaestro

    Public Function Converciones(ByVal O As ETObjecto) As ETObjecto

        Converciones = New ETObjecto

Operacion:

        Converciones = Datos.Maestro.Converciones(O)

Salida:

        If Converciones Is Nothing Then
            Converciones = New ETObjecto
        Else
            Converciones.Validacion = True
        End If

        Return Converciones

    End Function

    Public Function ConsultasMaestros1() As DataTable
        Return Datos.Maestro.ConsultasMaestros1
    End Function
    Public Function ConsultasMaestros2(ByVal Ent As ETMaestos2) As DataTable
        Return Datos.Maestro.ConsultasMaestros2(Ent)
    End Function
    Public Function ConsultasTipoPago(ByVal Ent As ETMaestos2) As DataTable
        Return Datos.Maestro.ConsultasTipoPago(Ent)
    End Function
    Public Function ConsultaRuma(ByVal Ent As ETMaestos2) As DataTable
        Return Datos.Maestro.ConsultaRuma(Ent)
    End Function
    Public Function ConsultarAreas(ByVal Ent As ETMaestos2) As DataTable
        Return Datos.Maestro.ConsultarArea(Ent)
    End Function
    Public Function ConsultarMonedas(ByVal Ent As ETMaestos2) As DataTable
        Return Datos.Maestro.ConsultarMonedas(Ent)
    End Function
    Public Function ObtenerDataTrabajador(ByVal Ent As ETMaestos2) As DataTable
        Return Datos.Maestro.ObtenerDataTrabajador(Ent)
    End Function

    Public Function ConsultarConceptos(ByVal Ent As ETMaestos2) As DataTable
        Return Datos.Maestro.ConsultarConceptos(Ent)
    End Function
    Public Function ConsultarPermisos(ByVal Ent As ETMaestos2) As DataTable
        Return Datos.Maestro.ConsultarPermisos(Ent)
    End Function
    Public Function ConsultasMaestros3(ByVal Ent As ETMaestos2) As DataTable
        Return Datos.Maestro.ConsultasMaestros3(Ent)
    End Function

    Public Function ConsultarMaestro2(ByVal Entidad As ETMaestos2) As ETMyLista
        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Maestro.Consultar_Maestros2(Entidad)

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
