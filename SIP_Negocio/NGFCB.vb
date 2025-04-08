Imports SIP_Entidad
Imports SIP_Datos

Public Class NGFCB

    Dim cd As New DAFCB

    Public Function Guardar_Grupo(ByVal obj As ETFCB, ByVal Opcion As String) As ETResultado
        Return cd.Guardar_Grupo(obj, Opcion)
    End Function

    Public Function ListarGrupos() As DataTable
        Return cd.ListarGrupos()
    End Function
    Public Function ListarSubGrupos(ByVal gru_id As Integer) As DataTable
        Return cd.ListarSubGrupos(gru_id)
    End Function

    ''conceptos
    Public Function Guardar_Concepto(ByVal obj As ETFCB, ByVal Opcion As String) As ETResultado
        Return cd.Guardar_Concepto(obj, Opcion)
    End Function

    Public Function ListarConceptos() As DataTable
        Return cd.ListarConceptos()
    End Function
    '
    Public Function ListarConceptosxgrupo(ByVal gru_id As Integer) As DataTable
        Return cd.ListarConceptosxgrupo(gru_id)
    End Function

    Public Function Validar(ByVal des As String, ByVal tab As Integer) As DataTable
        Return cd.Validar(des, tab)
    End Function

    Public Function Guardar_Naturaleza_Concepto(ByVal Rpt As ETFCB, ByVal Ls_Entrega As List(Of ETFCB)) As ETFCB
        Return cd.Guardar_Naturaleza_Concepto(Rpt, Ls_Entrega)
    End Function

    Public Function ListarProveedores(ByVal gru_id As Integer, ByVal con_id As Integer, ByVal cia As String, ByVal tabl As Integer) As DataTable
        Return cd.ListarProveedores(gru_id, con_id, cia, tabl)
    End Function

    Public Function Guardar_Proveedor_Concepto(ByVal Rpt As ETFCB, ByVal Ls_Entrega As List(Of ETFCB)) As ETFCB
        Return cd.Guardar_Proveedor_Concepto(Rpt, Ls_Entrega)
    End Function

    Public Function ListarProvConcepto(ByVal gru_id As Integer, ByVal sg_id As Integer, ByVal con_id As Integer, ByVal cia As String) As DataTable
        Return cd.ListarProvConcepto(gru_id, sg_id, con_id, cia)
    End Function

    Public Function ListarNaturalezaConcepto(ByVal gru_id As Integer, ByVal sg_id As Integer, ByVal con_id As Integer, ByVal cia As String) As DataTable
        Return cd.ListarNaturalezaConcepto(gru_id, sg_id, con_id, cia)
    End Function

    Public Function Eliminar_Provconcep(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Return cd.Eliminar_Provconcep(id, Companhia, User)
    End Function

    Public Function Eliminar_Natuconcep(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Return cd.Eliminar_Natuconcep(id, Companhia, User)
    End Function

    Public Function Eliminar_Fileconcep(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Return cd.Eliminar_Fileconcep(id, Companhia, User)
    End Function

    Public Function Guardar_File_Concepto(ByVal Rpt As ETFCB, ByVal Ls_Entrega As List(Of ETFCB)) As ETFCB
        Return cd.Guardar_File_Concepto(Rpt, Ls_Entrega)
    End Function

    Public Function ListarFileConcepto(ByVal gru_id As Integer, ByVal sg_id As Integer, ByVal con_id As Integer, ByVal cia As String) As DataTable
        Return cd.ListarFileConcepto(gru_id, sg_id, con_id, cia)
    End Function
    '
    Public Function ListarNaturaleza(ByVal cia As String) As DataTable
        Return cd.ListarNaturaleza(cia)
    End Function

    Public Function ListarCaracteristicaxNaturaleza(ByVal gru_id As Integer, ByVal con_id As Integer, ByVal nat As String, ByVal cia As String) As DataTable
        Return cd.ListarCaracteristicaxNaturaleza(gru_id, con_id, nat, cia)
    End Function
    Public Function ListarDocxConcepto(ByVal gru_id As Integer, ByVal sg_id As Integer, ByVal con_id As Integer, ByVal cia As String) As DataTable
        Return cd.ListarDocxConcepto(gru_id, sg_id, con_id, cia)
    End Function
    Public Function Guardar_Doc_Concepto(ByVal Rpt As ETFCB, ByVal Ls_Entrega As List(Of ETFCB)) As ETFCB
        Return cd.Guardar_Doc_Concepto(Rpt, Ls_Entrega)
    End Function

    Public Function Eliminar_Doc_concep(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Return cd.Eliminar_Doc_concep(id, Companhia, User)
    End Function
    ''----------------------------
    Public Function Guardar_Seteo_Grupo(ByVal obj As ETFCB) As ETResultado
        Return cd.Guardar_Seteo_Grupo(obj)
    End Function

    Public Function Listar_Grupos_xagregar(ByVal cia As String) As DataTable
        Return cd.Listar_Grupos_xagregar(cia)
    End Function

    Public Function Listar_Grupos_seteados(ByVal cia As String) As DataTable
        Return cd.Listar_Grupos_seteados(cia)
    End Function

    Public Function Eliminar_grupos(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Return cd.Eliminar_grupos(id, Companhia, User)
    End Function


    Public Function Guardar_Seteo_Concepto(ByVal obj As ETFCB) As ETResultado
        Return cd.Guardar_Seteo_Concepto(obj)
    End Function

    Public Function Listar_Concepto_xagregar(ByVal cia As String) As DataTable
        Return cd.Listar_Concepto_xagregar(cia)
    End Function

    Public Function Listar_Conceptos_seteados(ByVal cia As String) As DataTable
        Return cd.Listar_Conceptos_seteados(cia)
    End Function

    Public Function Eliminar_Conceptos(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Return cd.Eliminar_Conceptos(id, Companhia, User)
    End Function


    Public Function Guardar_Subgrupo(ByVal obj As ETFCB, ByVal Opcion As String) As ETResultado
        Return cd.Guardar_Subgrupo(obj, Opcion)
    End Function

    Public Function ordenar(ByVal Orden As Integer, ByVal Id As Integer, ByVal Tabla As Integer) As ETResultado
        Return cd.ordenar(Orden, Id, Tabla)
    End Function

    Public Function ListarTipos() As DataTable
        Return cd.ListarTipos()
    End Function

    Public Function ListarMovxTipos(ByVal tipid As Integer) As DataTable
        Return cd.ListarMovxTipos(tipid)
    End Function

    Public Function ListarMovxconcepto(ByVal gru_id As Integer, ByVal sg_id As Integer, ByVal con_id As Integer, ByVal cia As String) As DataTable
        Return cd.ListarMovxconcepto(gru_id, sg_id, con_id, cia)
    End Function


    Public Function Guardar_TipoMov(ByVal Rpt As ETFCB, ByVal Ls_Entrega As List(Of ETFCB)) As ETFCB
        Return cd.Guardar_TipoMov(Rpt, Ls_Entrega)
    End Function

    Public Function Eliminar_Tipomovconcep(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Return cd.Eliminar_Tipomovconcep(id, Companhia, User)
    End Function

    Public Function Validardcambio(ByVal tabl As Integer) As DataTable
        Return cd.Validardcambio(tabl)
    End Function
    '
    Public Function Rpt_listargrupos() As DataTable
        Return cd.Rpt_listargrupos()
    End Function

    Public Function Rpt_listar_gasto_obras_xmes(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Return cd.Rpt_listar_gasto_obras_xmes(cia, ayo, mes)
    End Function

    Public Function Rpt_listarconmay(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Return cd.Rpt_listarconmay(cia, ayo, mes)
    End Function

    Public Function Rpt_listarcuentas(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Return cd.Rpt_listarcuentas(cia, ayo, mes)
    End Function

    Public Function Rpt_listardetalleconmay(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Return cd.Rpt_listardetalleconmay(cia, ayo, mes)
    End Function

    Public Function Rpt_listarmontoxconcepto(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Return cd.Rpt_listarmontoxconcepto(cia, ayo, mes)
    End Function

    Public Function Guardar_ctacte(ByVal Rpt As ETFCB, ByVal Ls_Entrega As List(Of ETFCB)) As ETFCB
        Return cd.Guardar_ctacte(Rpt, Ls_Entrega)
    End Function

    Public Function ListarCtactexConcepto(ByVal gru_id As Integer, ByVal sg_id As Integer, ByVal con_id As Integer, ByVal cia As String) As DataTable
        Return cd.ListarCtactexConcepto(gru_id, sg_id, con_id, cia)
    End Function

    Public Function Eliminar_Ctactexconcep(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Return cd.Eliminar_Ctactexconcep(id, Companhia, User)
    End Function
    Public Function Rpt_listarconmayacumulado(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Return cd.Rpt_listarconmayacumulado(cia, ayo, mes)
    End Function
    Public Function Rpt_FlujoCaja(ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Return cd.Rpt_FlujoCaja(ayo, mes)
    End Function
    Public Function Rpt_listarobras() As DataTable
        Return cd.Rpt_listarobras()
    End Function
    Public Function Rpt_gasto_acumuladoxobras(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Return cd.Rpt_gasto_acumuladoxobras(cia, ayo, mes)
    End Function


    Public Function saldo_ini_mensual(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Return cd.saldo_ini_mensual(cia, ayo, mes)
    End Function

End Class
