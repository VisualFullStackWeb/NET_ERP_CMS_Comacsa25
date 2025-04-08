Imports SIP_Entidad
Imports SIP_Datos
Imports System.Threading
Imports System.Text.RegularExpressions

Public Class NGProyecto

    Public Function Lista_HoraDia(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_HoraDia(Rpt)

    End Function

    Public Function Actualiza_HoraDia(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Actualiza_HoraDia(Rpt)

    End Function

    Public Function Lista_Tarea(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_Tarea(Rpt)

    End Function

    Public Function Lista_Proyecto(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_Proyecto(Rpt)

    End Function

    Public Function Lista_Equipo(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_Equipo(Rpt)

    End Function

    Public Function ValidaPlano(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.ValidaPlano(Rpt)

    End Function

    Public Function Lista_Taller(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_Taller(Rpt)

    End Function

    Public Function Mant_Tarea(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Mant_Tarea(Rpt)

    End Function

    Public Function Mant_Planificacion(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Mant_Planificacion(Rpt)

    End Function

    Public Function Mant_Pla_Tarea(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Mant_Pla_Tarea(Rpt)

    End Function

    Public Function Mant_SubTarea(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Mant_SubTarea(Rpt)

    End Function

    Public Function Lista_Planificacion(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_Planificacion(Rpt)

    End Function

    Public Function Lista_PlanificacionAvance(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_PlanificacionAvance(Rpt)

    End Function

    Public Function Lista_PlanificacionID(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_PlanificacionID(Rpt)

    End Function

    Public Function Mant_Plano(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Mant_Plano(Rpt)

    End Function

    Public Function Mant_PlanoDET(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Mant_PlanoDET(Rpt)

    End Function

    Public Function Lista_Personal(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_Personal(Rpt)

    End Function

    Public Function Lista_Material(ByVal Rpt As ETProyecto) As DataTable
        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_Material(Rpt)
    End Function

    Public Function Costo_Material(ByVal Rpt As ETProyecto) As DataTable
        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Costo_Material(Rpt)
    End Function

    Public Function Lista_Servicio(ByVal Rpt As ETProyecto) As DataTable
        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_Servicio(Rpt)
    End Function

    Public Function Costo_Servicio(ByVal Rpt As ETProyecto) As DataTable
        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Costo_Servicio(Rpt)
    End Function

    Public Function Mant_SubPersonal(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Mant_SubPersonal(Rpt)

    End Function

    Public Function Mant_SubMaterial(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Mant_SubMaterial(Rpt)

    End Function

    Public Function Mant_SubServicio(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Mant_SubServicio(Rpt)

    End Function

    Public Function Lista_DetSubtareaID(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_DetSubtareaID(Rpt)

    End Function

    Public Function Lista_DetSubtareaIDREAL(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_DetSubtareaIDREAL(Rpt)

    End Function

    Public Function Actu_Subtarea(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Actu_Subtarea(Rpt)

    End Function

    Public Function ReporteGant(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.ReporteGant(Rpt)

    End Function

    Public Function ReporteValor(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.ReporteValor(Rpt)

    End Function

    Public Function ReporteGantReal(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.ReporteGantReal(Rpt)

    End Function

    Public Function Lista_PlanificacionProyecto(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_PlanificacionProyecto(Rpt)

    End Function

    Public Function Lista_EquipoProyecto(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_EquipoProyecto(Rpt)

    End Function

    Public Function Lista_TallerID(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_TallerID(Rpt)

    End Function

    Public Function Lista_AvanceSubtarea(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_AvanceSubtarea(Rpt)

    End Function

    Public Function Lista_AvanceFisicoSub(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_AvanceFisicoSub(Rpt)

    End Function

    Public Function Mant_AvanceFisicoSub(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Mant_AvanceFisicoSub(Rpt)

    End Function

    Public Function Lista_DetalleTaller(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_DetalleTaller(Rpt)

    End Function

    Public Function CierreProyecto(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.CierreProyecto(Rpt)

    End Function

    Public Function CierreTaller(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.CierreTaller(Rpt)

    End Function

    Public Function Lista_PersonalExt(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_PersonalExt(Rpt)

    End Function

    Public Function Lista_PersonalExtMant(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_PersonalExtMant(Rpt)

    End Function

    Public Function Lista_Subtarea(ByVal Rpt As ETProyecto) As DataTable

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_Subtarea(Rpt)

    End Function

    Public Function Lista_PlanificacionOrden(ByVal Rpt As ETProyecto) As DataSet

        Dim lResult As ETMyLista = Nothing
        Return Datos.Proyecto.Lista_PlanificacionOrden(Rpt)

    End Function
End Class
