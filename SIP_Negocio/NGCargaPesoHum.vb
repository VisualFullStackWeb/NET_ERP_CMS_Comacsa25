Imports SIP_Entidad
Imports SIP_Datos

Public Class NGCargaPesoHum

    Dim CargaPesoHumDA As New DACargaPesoHum

    Public Function Prod_CargaPesos_ValidarCierre(ByVal anio As Integer, ByVal mes As Integer) As Integer
        Return CargaPesoHumDA.Prod_CargaPesos_ValidarCierre(anio, mes)
    End Function
    Public Function Prod_CargaPesos_LimpiarRegistros(ByVal anio As Integer, ByVal mes As Integer, ByVal dia As Integer) As Integer
        Return CargaPesoHumDA.Prod_CargaPesos_LimpiarRegistros(anio, mes, dia)
    End Function
    Public Function Prod_CargaPesos_RegistrarTrama(ByVal id As String, _
                                               ByVal hora As String, _
                                               ByVal fecha As DateTime, _
                                               ByVal peso_caliza As Decimal, _
                                               ByVal peso_silice As Decimal, _
                                               ByVal peso_caolin As Decimal, _
                                               ByVal grupo As String) As Integer

        Return CargaPesoHumDA.Prod_CargaPesos_RegistrarTrama(id, hora, fecha, peso_caliza, peso_silice, peso_caolin, grupo)
    End Function
    Public Function Listar_CargaPesosHum(ByVal anio As Integer, ByVal mes As Integer) As DataSet
        Return CargaPesoHumDA.Listar_CargaPesosHum(anio, mes)
    End Function
    Public Function Listar_CargaPesosHumGrupo(ByVal Grupo As String) As DataSet
        Return CargaPesoHumDA.Listar_CargaPesosHumGrupo(Grupo)
    End Function
    Public Function Actualizar_CargaPesosResumenParametros(ByVal anio As Integer, ByVal mes As Integer, ByVal porc_pirofilita As Decimal, ByVal porc_silice As Decimal) As Integer
        Return CargaPesoHumDA.Actualizar_CargaPesosResumenParametros(anio, mes, porc_pirofilita, porc_silice)
    End Function
    Public Function Actualizar_CargaPesosResumen(ByVal ListaItems As List(Of ETCargaPesoCrudo)) As String
        Return CargaPesoHumDA.Actualizar_CargaPesosResumen(ListaItems)
    End Function
    Public Function ValidarResumenCLinker(ByVal pClinkerReporte As ETClinker_Reporte) As Integer
        Return CargaPesoHumDA.ValidarResumenHorno(pClinkerReporte)
    End Function
    Public Function GenerarResumenHorno(ByVal pClinkerReporte As ETClinker_Reporte, ByVal user As String, ByVal opcion As Integer) As ETClinker_Reporte
        Return CargaPesoHumDA.GenerarResumenHorno(pClinkerReporte, user, opcion)
    End Function
    Public Function ObtenerResumenHorno(ByVal pClinkerReporte As ETClinker_Reporte) As ETClinker_Reporte
        Return CargaPesoHumDA.ObtenerResumenHorno(pClinkerReporte)
    End Function
    Public Function ActualizarResumenHorno(ByVal pClinkerReporte As ETClinker_Reporte) As ETClinker_Reporte
        Return CargaPesoHumDA.ActualizarResumenHorno(pClinkerReporte)
    End Function
    Public Function ObtenerInventario(ByVal anio As Integer, ByVal mes As Integer) As DataSet
        Return CargaPesoHumDA.ObtenerInventario(anio, mes)
    End Function
End Class
