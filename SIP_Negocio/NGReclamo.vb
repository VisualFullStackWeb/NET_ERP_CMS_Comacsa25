Imports SIP_Entidad
Imports SIP_Datos
Public Class NGReclamo

    Dim ReclamoDAO As New DAReclamo

    Public Function ObtenerGuia(ByVal NroGuia As String, ByVal NroFact As String, _
                                ByVal CodCli As String, ByVal PorFechas As Boolean, ByVal Inicio As DateTime, ByVal Fin As DateTime) As DataSet
        Return ReclamoDAO.ObtenerGuia(NroGuia, NroFact, CodCli, PorFechas, Inicio, Fin)
    End Function

    Public Function ObtenerPersonalPorArea() As DataSet

        Dim ds As DataSet = ReclamoDAO.ObtenerPersonalPorArea()

        ds.Tables(0).TableName = "DESPACHO"
        ds.Tables(1).TableName = "VENTANAC"
        ds.Tables(2).TableName = "VENTAEXP"
        ds.Tables(3).TableName = "TRANSPORTE"
        ds.Tables(4).TableName = "LABORATORIO"

        Return ds
    End Function

    Public Function ObtenerRepresentamtePorCLiente(ByVal CodigoCliente As String) As ETReclamoPersona
        Return ReclamoDAO.ObtenerRepresentamtePorCLiente(CodigoCliente)
    End Function

    Public Function GrabarCabeceraReclamo(ByVal pReclamo As ETReclamo, ByVal opcion As Integer) As ETResultado
        Return ReclamoDAO.GrabarCabeceraReclamo(pReclamo, opcion)
    End Function
    Public Function ListarReclamos(ByVal pReclamo As ETReclamo, ByVal pRol As String) As List(Of ETReclamo)
        Return ReclamoDAO.ListarReclamos(pReclamo, pRol)
    End Function

    Public Function ListarConfiguracion() As DataTable
        Return ReclamoDAO.ListarConfiguracion()
    End Function

    Public Function RegistrarMuestras(ByVal pReclamo As ETReclamo) As ETResultado
        Return ReclamoDAO.RegistrarMuestras(pReclamo)
    End Function

    Public Function RegistrarEvidenciaCorreo(ByVal pReclamo As ETReclamo) As ETResultado
        Return ReclamoDAO.RegistrarEvidenciaCorreo(pReclamo)
    End Function

    Public Function RegistrarLaboratorioConformidad(ByVal pReclamo As ETReclamo) As ETResultado
        Return ReclamoDAO.RegistrarLaboratorioConformidad(pReclamo)
    End Function
    Public Function RegistrarLaboratorioInforme(ByVal pReclamo As ETReclamo) As ETResultado
        Return ReclamoDAO.RegistrarLaboratorioInforme(pReclamo)
    End Function
    Public Function RegistrarAprobacion(ByVal pReclamo As ETReclamo, ByVal Tipo As String, ByVal User_Sistema As String)
        Return ReclamoDAO.RegistrarAprobacion(pReclamo, Tipo, User_Sistema)
    End Function
    Public Function ObtenerReclamo(ByVal pReclamo As ETReclamo) As ETReclamo
        Return ReclamoDAO.ObtenerReclamo(pReclamo)
    End Function
    Public Function RegistrarProgramacionReunion(ByVal pReclamo As ETReclamo)
        Return ReclamoDAO.RegistrarProgramacionReunion(pReclamo)
    End Function
    Public Function ObtenerAnalisis(ByVal pReclamo As ETReclamo) As List(Of ETReclamoCausa)
        Return ReclamoDAO.ObtenerAnalisis(pReclamo)
    End Function
    Public Function RegistrarAnalisis(ByVal pReclamo As ETReclamo) As ETResultado
        Return ReclamoDAO.RegistrarAnalisis(pReclamo)
    End Function
    Public Function ReporteReclamo(ByVal pReclamo As ETReclamo) As DataSet
        Return ReclamoDAO.ReporteReclamo(pReclamo)
    End Function
    Public Function Reclamo_Seguimiento(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime) As DataTable
        Return ReclamoDAO.Reclamo_Seguimiento(fechaInicio, fechaFin)
    End Function

    Public Function Reclamo_IndicadorLab(ByVal ayo As Integer, ByVal mes1 As Integer, ByVal mes2 As Integer) As DataTable
        Return ReclamoDAO.Reclamo_IndicadorLab(ayo, mes1, mes2)
    End Function

    Public Function RegistrarPlanesAccion(ByVal pReclamo As ETReclamo) As ETResultado
        Return ReclamoDAO.RegistrarPlanesAccion(pReclamo)
    End Function
    Public Function RegistrarCorreosCliente(ByVal pReclamo As ETReclamo, ByVal Tipo As String) As ETResultado
        Return ReclamoDAO.RegistrarCorreosCliente(pReclamo, Tipo)
    End Function
    Public Function ObtenerCorreosClientes(ByVal pReclamo As ETReclamo) As List(Of ETReclamoPersona)
        Return ReclamoDAO.ObtenerCorreosClientes(pReclamo)
    End Function
    Public Function RegistrarGuias(ByVal pReclamo As ETReclamo)
        Return ReclamoDAO.RegistrarGuias(pReclamo)
    End Function
    Public Function RegistrarEvidencia(ByVal pReclamo As ETReclamo) As ETResultado
        Return ReclamoDAO.RegistrarEvidencia(pReclamo)
    End Function
    Public Function ActualizarEstado(ByVal pReclamo As ETReclamo, ByVal User_Sistema As String) As ETResultado
        Return ReclamoDAO.ActualizarEstado(pReclamo, User_Sistema)
    End Function
    Public Function RegistrarRechazoMuestra(ByVal pReclamo As ETReclamo, ByVal User_Sistema As String) As ETResultado
        Return ReclamoDAO.RegistrarRechazoMuestra(pReclamo, User_Sistema)
    End Function
    Public Function ObtenerListaEvidencias(ByVal pReclamo As ETReclamo) As List(Of ETReclamoEvidencia)
        Return ReclamoDAO.ObtenerListaEvidencias(pReclamo)
    End Function
    Public Function ObtenerPersonalPorGrupo(ByVal Grupo As String, ByVal NroReclamo As String, ByVal ItemSeleccione As Boolean) As List(Of ETReclamoPersona)
        Dim lista As List(Of ETReclamoPersona) = ReclamoDAO.ObtenerPersonalPorGrupo(Grupo, NroReclamo)

        If ItemSeleccione Then
            lista.Insert(0, New ETReclamoPersona("0", "-- Seleccione --"))
        End If

        Return ReclamoDAO.ObtenerPersonalPorGrupo(Grupo, "")
    End Function
    Public Function ObtenerEstadoReclamo(ByVal pReclamo As ETReclamo) As ETReclamoPermisos
        Return ReclamoDAO.ObtenerEstadoReclamo(pReclamo)
    End Function

    Public Function RegistrarFormato(ByVal pFormato As ETReclamoFormato)
        Return ReclamoDAO.RegistrarFormato(pFormato)
    End Function
    Public Function ObtenerFormato(ByVal pFormato As ETReclamoFormato) As ETReclamoFormato
        Return ReclamoDAO.ObtenerFormato(pFormato)
    End Function
    Public Function ReporteFormato(ByVal pReclamo As ETReclamo) As DataSet
        Return ReclamoDAO.ReporteFormato(pReclamo)
    End Function

    Public Function ObtenerClientePorCodigo(ByVal CodCia As String, ByVal CodCliente As String) As ETCliente
        Return ReclamoDAO.ObtenerClientePorCodigo(CodCia, CodCliente)
    End Function

    Public Function ObtenerCorreoPorNombre(ByVal CodCia As String, ByVal ResponsableVenta As String) As ETResponsableVenta
        Return ReclamoDAO.ObtenerCorreoPorNombre(CodCia, ResponsableVenta)
    End Function

    Public Function ObtenerRol(ByVal User_Sistema As String) As String
        Return ReclamoDAO.ObtenerRol(User_Sistema)
    End Function

    Public Function CorreoEjecutivo(ByVal codcli As String, ByVal tipo As String, ByVal pareto As String, ByVal usuario As String) As List(Of ETReclamoPersona)
        Return ReclamoDAO.CorreoEjecutivo(codcli, tipo, pareto, usuario)
    End Function

End Class
