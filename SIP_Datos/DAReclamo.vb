Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Data.SqlClient

Public Class DAReclamo
    'RECLAMOS
    Public Function ObtenerGuia(ByVal NroGuia As String, ByVal NroFactura As String, ByVal CodCli As String, ByVal PorFechas As Boolean, ByVal Inicio As DateTime, ByVal Fin As DateTime) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamos_obtenerGuia")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@cod_cia", DbType.String, "01")
            db.AddInParameter(cmd, "@nro_guia", DbType.String, NroGuia)
            db.AddInParameter(cmd, "@nro_fact", DbType.String, NroFactura)
            db.AddInParameter(cmd, "@cod_cli", DbType.String, CodCli)
            db.AddInParameter(cmd, "@porFechas", DbType.Boolean, PorFechas)
            db.AddInParameter(cmd, "@dtmInicio", DbType.DateTime, Inicio)
            db.AddInParameter(cmd, "@dtmFin", DbType.DateTime, Fin)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            ObtenerGuia = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ObtenerPersonalPorArea() As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamos_personal_por_area")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cod_cia", DbType.String, "01")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            ObtenerPersonalPorArea = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ObtenerRepresentamtePorCLiente(ByVal CodigoCliente As String) As ETReclamoPersona
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamos_representante_por_cliente")
        Dim oPersona As ETReclamoPersona = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cod_cia", DbType.String, "01")
            db.AddInParameter(cmd, "cod_cli", DbType.String, CodigoCliente)

            Using reader As IDataReader = db.ExecuteReader(cmd)

                While reader.Read()
                    oPersona = New ETReclamoPersona
                    oPersona.Codigo = reader.GetString(reader.GetOrdinal("codigo"))
                    oPersona.Nombre = reader.GetString(reader.GetOrdinal("persona"))
                    oPersona.Correo = reader.GetString(reader.GetOrdinal("correo"))
                    oPersona.Area = reader.GetString(reader.GetOrdinal("area"))
                End While

                If reader IsNot Nothing Then reader.Close()

            End Using

            ObtenerRepresentamtePorCLiente = oPersona

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function RegistrarCorreosCliente(ByVal pReclamo As ETReclamo, ByVal Tipo As String) As ETResultado
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmdEliminar As DbCommand = db.GetStoredProcCommand("usp_reclamo_persona")

                db.AddInParameter(cmdEliminar, "@cod_cia", DbType.String, pReclamo.CodCia)
                db.AddInParameter(cmdEliminar, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmdEliminar, "@tipo", DbType.String, Tipo)
                db.AddInParameter(cmdEliminar, "@opcion", DbType.Int32, 3)

                db.ExecuteNonQuery(cmdEliminar, Trans)

                Dim cmdReg As DbCommand = Nothing

                For Each oCorreo As ETReclamoPersona In pReclamo.ListaEmailsCliente
                    cmdReg = db.GetStoredProcCommand("usp_reclamo_persona")
                    db.AddInParameter(cmdReg, "@cod_cia", DbType.String, pReclamo.CodCia)
                    db.AddInParameter(cmdReg, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddInParameter(cmdReg, "@tipo", DbType.String, Tipo)
                    db.AddInParameter(cmdReg, "@cod_per", DbType.String, oCorreo.Codigo)
                    db.AddInParameter(cmdReg, "@persona", DbType.String, oCorreo.Nombre)
                    db.AddInParameter(cmdReg, "@correo", DbType.String, oCorreo.Correo)
                    db.AddInParameter(cmdReg, "@area", DbType.String, oCorreo.Area)
                    db.AddInParameter(cmdReg, "@opcion", DbType.Int32, 1)

                    db.ExecuteNonQuery(cmdReg, Trans)
                Next

                Trans.Commit()
                Conexion.Close()
                oResultado.Realizo = True

            Catch ex As Exception
                oResultado.Realizo = False
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using

        Return oResultado
    End Function
    Public Function RegistrarGuias(ByVal pReclamo As ETReclamo)
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Dim cmdProdElim As DbCommand = db.GetStoredProcCommand("usp_reclamos_producto")
                db.AddInParameter(cmdProdElim, "@cod_cia", DbType.String, pReclamo.CodCia)
                db.AddInParameter(cmdProdElim, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmdProdElim, "@opcion", DbType.Int32, 3)

                db.ExecuteNonQuery(cmdProdElim, Trans)

                Dim cmdProdReg As DbCommand = Nothing

                For Each oProdDetalle As ETReclamoProductoDetalle In pReclamo.Producto.ListaDetalles
                    cmdProdReg = db.GetStoredProcCommand("usp_reclamos_producto")
                    db.AddInParameter(cmdProdReg, "@cod_cia", DbType.String, pReclamo.CodCia)
                    db.AddInParameter(cmdProdReg, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddInParameter(cmdProdReg, "@nrofact", DbType.String, oProdDetalle.NRO_FACT)
                    db.AddInParameter(cmdProdReg, "@nroguia", DbType.String, oProdDetalle.NRO_GUIA)
                    db.AddInParameter(cmdProdReg, "@fecha", DbType.DateTime, oProdDetalle.FECHA)
                    db.AddInParameter(cmdProdReg, "@prod_cod", DbType.String, oProdDetalle.COD_PRODUCTO)
                    db.AddInParameter(cmdProdReg, "@producto", DbType.String, oProdDetalle.PRODUCTO)
                    db.AddInParameter(cmdProdReg, "@unidad", DbType.String, oProdDetalle.UNIDAD)
                    db.AddInParameter(cmdProdReg, "@lote", DbType.String, oProdDetalle.LOTE)
                    db.AddInParameter(cmdProdReg, "@nrobolsas", DbType.String, oProdDetalle.NRO_BOLSAS)
                    db.AddInParameter(cmdProdReg, "@nrobolsas_reclamadas", DbType.String, oProdDetalle.NRO_BOLSAS_RECLAMADAS)
                    db.AddInParameter(cmdProdReg, "@cant_ing", DbType.Decimal, oProdDetalle.CANT_INGRESADA)
                    db.AddInParameter(cmdProdReg, "@cant_desp", DbType.Decimal, oProdDetalle.CANT_DESPACHADA)
                    db.AddInParameter(cmdProdReg, "@cant_fact", DbType.Decimal, oProdDetalle.CANT_FACTURADA)
                    db.AddInParameter(cmdProdReg, "@opcion", DbType.Int32, 1)

                    db.ExecuteNonQuery(cmdProdReg, Trans)
                Next

                oResultado.Realizo = True

                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using
        Return oResultado
    End Function
    Public Function GrabarCabeceraReclamo(ByVal pReclamo As ETReclamo, ByVal opcion As Integer) As ETResultado
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim estado As String = "REGISTRADO"

                If pReclamo.Tipo = "1" Then
                    estado = "PRODUCTO"
                End If
                If pReclamo.Tipo = "2" Then
                    estado = "SERVICIO"
                End If

                '--Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamos_mantenimiento")
                Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamos_mantenimiento_240709")

                db.AddInParameter(cmd, "@cod_cia", DbType.String, pReclamo.CodCia)
                db.AddInParameter(cmd, "@fec_termino", DbType.DateTime, pReclamo.FechaFin)
                db.AddInParameter(cmd, "@fec_registro", DbType.DateTime, pReclamo.Fecha)
                db.AddInParameter(cmd, "@cliente_cod", DbType.String, pReclamo.ClienteCodigo)
                db.AddInParameter(cmd, "@registra_cod", DbType.String, pReclamo.UsuarioRegistra.Codigo)
                db.AddInParameter(cmd, "@resp_cod", DbType.String, pReclamo.UsuarioResponsable.Codigo)
                db.AddInParameter(cmd, "@tipo", DbType.String, pReclamo.Tipo)
                db.AddInParameter(cmd, "@origen", DbType.String, pReclamo.Origen)
                db.AddInParameter(cmd, "@estado", DbType.String, pReclamo.Estado)
                db.AddInParameter(cmd, "@prod_motivo", DbType.String, pReclamo.Producto.Motivo)
                db.AddInParameter(cmd, "@prod_nroguia", DbType.String, pReclamo.Producto.NroGuia)
                db.AddInParameter(cmd, "@prod_obs", DbType.String, pReclamo.Producto.Observacion)
                db.AddInParameter(cmd, "@serv_obs", DbType.String, pReclamo.ServicioObservacion)
                db.AddInParameter(cmd, "@cancelado", DbType.String, pReclamo.Cancelado)
                db.AddInParameter(cmd, "@fec_cancelado", DbType.DateTime, pReclamo.FechaCancelacion)
                db.AddInParameter(cmd, "@motivo_cancelado", DbType.String, pReclamo.MotivoCancelacion)
                db.AddInParameter(cmd, "@opcion", DbType.Int32, opcion)
                db.AddInParameter(cmd, "@reqAprobProd", DbType.Boolean, pReclamo.RequiereAprobProd)
                db.AddInParameter(cmd, "@reqAprobLab", DbType.Boolean, pReclamo.RequiereAprobLab)
                db.AddInParameter(cmd, "@reqAprobCom", DbType.Boolean, pReclamo.RequiereAprobCom)
                db.AddInParameter(cmd, "@pareto", DbType.String, pReclamo.Pareto)
                db.AddInParameter(cmd, "@tpreob", DbType.String, pReclamo.Tpreob)

                db.AddOutParameter(cmd, "@id_reclamo", DbType.Int32, 8)
                db.AddOutParameter(cmd, "@nro_reclamo", DbType.String, 20)
                db.AddOutParameter(cmd, "@mensaje", DbType.String, 250)

                db.ExecuteNonQuery(cmd, Trans)

                pReclamo.Id = Convert.ToInt32(db.GetParameterValue(cmd, "@id_reclamo"))
                pReclamo.Nro = Convert.ToString(db.GetParameterValue(cmd, "@nro_reclamo"))
                oResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "@mensaje"))

                'producto         

                '--------------------------------------------------------------------------------------------------------

                Dim cmdPrdReg As DbCommand = Nothing
                For Each oReclamoProductoOpcion As ETReclamoProductoOpcion In pReclamo.ProductosOpcion
                    cmdPrdReg = db.GetStoredProcCommand("usp_reclamos_productos_opcion")
                    db.AddInParameter(cmdPrdReg, "@cod_cia", DbType.String, pReclamo.CodCia)
                    db.AddInParameter(cmdPrdReg, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddInParameter(cmdPrdReg, "@cod_producto", DbType.String, oReclamoProductoOpcion.Codigo)
                    db.AddInParameter(cmdPrdReg, "@cod_opcion", DbType.String, oReclamoProductoOpcion.Opcion)
                    db.AddInParameter(cmdPrdReg, "@obs_opcion", DbType.String, oReclamoProductoOpcion.Observacion)
                    db.AddInParameter(cmdPrdReg, "@opcion", DbType.Int32, 1)
                    db.ExecuteNonQuery(cmdPrdReg, Trans)
                Next

                '--------------------------------------------------------------------------------------------------------

                If opcion = 2 Then
                    Dim cmdProdElim As DbCommand = db.GetStoredProcCommand("usp_reclamos_producto")
                    db.AddInParameter(cmdProdElim, "@cod_cia", DbType.String, pReclamo.CodCia)
                    db.AddInParameter(cmdProdElim, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddInParameter(cmdProdElim, "@opcion", DbType.Int32, 3)
                    db.ExecuteNonQuery(cmdProdElim, Trans)
                End If

                Dim cmdProdReg As DbCommand = Nothing
                For Each oProdDetalle As ETReclamoProductoDetalle In pReclamo.Producto.ListaDetalles
                    cmdProdReg = db.GetStoredProcCommand("usp_reclamos_producto")
                    db.AddInParameter(cmdProdReg, "@cod_cia", DbType.String, pReclamo.CodCia)
                    db.AddInParameter(cmdProdReg, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddInParameter(cmdProdReg, "@nrofact", DbType.String, oProdDetalle.NRO_FACT)
                    db.AddInParameter(cmdProdReg, "@nroguia", DbType.String, oProdDetalle.NRO_GUIA)
                    db.AddInParameter(cmdProdReg, "@fecha", DbType.DateTime, oProdDetalle.FECHA)
                    db.AddInParameter(cmdProdReg, "@prod_cod", DbType.String, oProdDetalle.COD_PRODUCTO)
                    db.AddInParameter(cmdProdReg, "@producto", DbType.String, oProdDetalle.PRODUCTO)
                    db.AddInParameter(cmdProdReg, "@unidad", DbType.String, oProdDetalle.UNIDAD)
                    db.AddInParameter(cmdProdReg, "@lote", DbType.String, oProdDetalle.LOTE)
                    db.AddInParameter(cmdProdReg, "@nrobolsas", DbType.String, oProdDetalle.NRO_BOLSAS)
                    db.AddInParameter(cmdProdReg, "@nrobolsas_reclamadas", DbType.String, oProdDetalle.NRO_BOLSAS_RECLAMADAS)
                    db.AddInParameter(cmdProdReg, "@cant_ing", DbType.Decimal, oProdDetalle.CANT_INGRESADA)
                    db.AddInParameter(cmdProdReg, "@cant_desp", DbType.Decimal, oProdDetalle.CANT_DESPACHADA)
                    db.AddInParameter(cmdProdReg, "@cant_fact", DbType.Decimal, oProdDetalle.CANT_FACTURADA)
                    db.AddInParameter(cmdProdReg, "@opcion", DbType.Int32, 1)
                    db.ExecuteNonQuery(cmdProdReg, Trans)
                Next

                'Producto Opcion 


                'Servicio
                If opcion = 2 Then
                    Dim cmdSerElim As DbCommand = db.GetStoredProcCommand("usp_reclamos_servicio")
                    db.AddInParameter(cmdSerElim, "@cod_cia", DbType.String, pReclamo.CodCia)
                    db.AddInParameter(cmdSerElim, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddInParameter(cmdSerElim, "@opcion", DbType.Int32, 3)
                    db.ExecuteNonQuery(cmdSerElim, Trans)
                End If


                Dim cmdSerReg As DbCommand = Nothing
                For Each oReclamoServicio As ETReclamoServicio In pReclamo.Servicios
                    cmdSerReg = db.GetStoredProcCommand("usp_reclamos_servicio")
                    db.AddInParameter(cmdSerReg, "@cod_cia", DbType.String, pReclamo.CodCia)
                    db.AddInParameter(cmdSerReg, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddInParameter(cmdSerReg, "@cod_servicio", DbType.String, oReclamoServicio.Codigo)
                    db.AddInParameter(cmdSerReg, "@cod_opcion", DbType.String, oReclamoServicio.Opcion)
                    db.AddInParameter(cmdSerReg, "@obs_opcion", DbType.String, oReclamoServicio.Observacion)
                    db.AddInParameter(cmdSerReg, "@opcion", DbType.Int32, 1)
                    db.ExecuteNonQuery(cmdSerReg, Trans)
                Next

                If opcion = 2 Then
                    Dim cmdMuestraElim As DbCommand = db.GetStoredProcCommand("usp_reclamos_muestra")
                    db.AddInParameter(cmdMuestraElim, "@cod_cia", DbType.String, pReclamo.CodCia)
                    db.AddInParameter(cmdMuestraElim, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddInParameter(cmdMuestraElim, "@id", DbType.Int32, 0)
                    db.AddInParameter(cmdMuestraElim, "@opcion", DbType.Int32, 3)

                    db.ExecuteNonQuery(cmdMuestraElim, Trans)
                End If

                'Muestras
                Dim cmdMuestras As DbCommand = Nothing

                For Each oReclamoMuestras As ETReclamoMuestra In pReclamo.ListaMuestras
                    cmdMuestras = db.GetStoredProcCommand("usp_reclamos_muestra")
                    db.AddInParameter(cmdMuestras, "@cod_cia", DbType.String, pReclamo.CodCia)
                    db.AddInParameter(cmdMuestras, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddInParameter(cmdMuestras, "@id", DbType.Int32, 0)
                    db.AddInParameter(cmdMuestras, "@producto", DbType.String, oReclamoMuestras.PRODUCTO)
                    db.AddInParameter(cmdMuestras, "@lote", DbType.String, oReclamoMuestras.LOTE)
                    db.AddInParameter(cmdMuestras, "@nro_bolsas", DbType.String, oReclamoMuestras.NROBOLSA)
                    db.AddInParameter(cmdMuestras, "@observacion", DbType.String, oReclamoMuestras.OBSERVACION)
                    db.AddInParameter(cmdMuestras, "@fec_entrega", DbType.DateTime, oReclamoMuestras.FECHA_INICIO)
                    db.AddInParameter(cmdMuestras, "@user", DbType.String, pReclamo.UsuarioRegistra.Codigo)
                    db.AddInParameter(cmdMuestras, "@opcion", DbType.Int32, 1)

                    db.ExecuteNonQuery(cmdMuestras, Trans)
                Next


                oResultado.Valor = pReclamo.Id
                oResultado.Mensaje = pReclamo.Nro

                oResultado.Realizo = True

                Trans.Commit()
                Conexion.Close()

            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using

        Return oResultado
    End Function

    Public Function RegistrarLaboratorioInforme(ByVal pReclamo As ETReclamo) As ETResultado
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmdMuestrasLab As DbCommand = Nothing

                If pReclamo.ListaMuestrasLab.Count > 0 Then

                    For Each oReclamoMuestras As EtReclamoMuestraLab In pReclamo.ListaMuestrasLab
                        cmdMuestrasLab = db.GetStoredProcCommand("usp_reclamos_muestra")
                        db.AddInParameter(cmdMuestrasLab, "@cod_cia", DbType.String, pReclamo.CodCia)
                        db.AddInParameter(cmdMuestrasLab, "@id_reclamo", DbType.Int32, pReclamo.Id)
                        db.AddInParameter(cmdMuestrasLab, "@id", DbType.Int32, oReclamoMuestras.ID)

                        If oReclamoMuestras.FECHA_FIN.HasValue Then
                            db.AddInParameter(cmdMuestrasLab, "@fec_informe", DbType.DateTime, oReclamoMuestras.FECHA_FIN.Value)
                        Else
                            db.AddInParameter(cmdMuestrasLab, "@fec_informe", DbType.DateTime, DBNull.Value)
                        End If
                        db.AddInParameter(cmdMuestrasLab, "@cod_per_aprob", DbType.String, oReclamoMuestras.APROBADO_POR)

                        db.AddInParameter(cmdMuestrasLab, "@ruta_archivo_lab", DbType.String, oReclamoMuestras.ARCHIVO)

                        db.AddInParameter(cmdMuestrasLab, "@observacion_lab", DbType.String, oReclamoMuestras.OBSERVACION)
                        db.AddInParameter(cmdMuestrasLab, "@user", DbType.String, pReclamo.UsuarioRegistra.Codigo)
                        db.AddInParameter(cmdMuestrasLab, "@opcion", DbType.Int32, 2)

                        db.ExecuteNonQuery(cmdMuestrasLab, Trans)
                    Next

                End If


                oResultado.Realizo = True

                Trans.Commit()
                Conexion.Close()

            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using
        Return oResultado
    End Function

    Public Function RegistrarLaboratorioConformidad(ByVal pReclamo As ETReclamo) As ETResultado
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmdMuestrasLab As DbCommand = Nothing

                If pReclamo.ListaMuestrasLab.Count > 0 Then

                    For Each oReclamoMuestras As EtReclamoMuestraLab In pReclamo.ListaMuestrasLab
                        cmdMuestrasLab = db.GetStoredProcCommand("usp_reclamos_muestra")
                        db.AddInParameter(cmdMuestrasLab, "@cod_cia", DbType.String, pReclamo.CodCia)
                        db.AddInParameter(cmdMuestrasLab, "@id_reclamo", DbType.Int32, pReclamo.Id)
                        db.AddInParameter(cmdMuestrasLab, "@id", DbType.Int32, oReclamoMuestras.ID)

                        db.AddInParameter(cmdMuestrasLab, "@fecha_entrega_conforme", DbType.Boolean, oReclamoMuestras.FECHA_CONFORME)
                        db.AddInParameter(cmdMuestrasLab, "@muestra_entrega_conforme", DbType.Boolean, oReclamoMuestras.MUESTRA_CONFORME)

                        If Not oReclamoMuestras.FECHA_CONFORME Or Not oReclamoMuestras.MUESTRA_CONFORME Then
                            db.AddInParameter(cmdMuestrasLab, "@estado", DbType.String, "RECHAZADO")
                        Else
                            db.AddInParameter(cmdMuestrasLab, "@estado", DbType.String, "EN CURSO")
                        End If

                        db.AddInParameter(cmdMuestrasLab, "@observacion_lab", DbType.String, oReclamoMuestras.OBSERVACION)

                        db.AddInParameter(cmdMuestrasLab, "@opcion", DbType.Int32, 6)

                        db.ExecuteNonQuery(cmdMuestrasLab, Trans)
                    Next

                End If


                oResultado.Realizo = True

                Trans.Commit()
                Conexion.Close()

            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using
        Return oResultado
    End Function

    Public Function RegistrarMuestras(ByVal pReclamo As ETReclamo) As ETResultado
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                'aprobaciones requeridas
                Dim cmdReq As DbCommand = db.GetStoredProcCommand("usp_reclamo_actualizar_reqAprobacion")
                db.AddInParameter(cmdReq, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmdReq, "@reqAprobProb", DbType.Boolean, pReclamo.RequiereAprobProd)
                db.AddInParameter(cmdReq, "@reqAprobLab", DbType.Boolean, pReclamo.RequiereAprobLab)
                db.AddInParameter(cmdReq, "@reqAprobCom", DbType.Boolean, pReclamo.RequiereAprobCom)

                db.ExecuteNonQuery(cmdReq, Trans)

                'fecha y comentario de la muestra
                Dim cmdUpdate As DbCommand = db.GetStoredProcCommand("usp_reclamos_muestra")
                db.AddInParameter(cmdUpdate, "@cod_cia", DbType.String, pReclamo.CodCia)
                db.AddInParameter(cmdUpdate, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmdUpdate, "@id", DbType.Int32, 0)
                db.AddInParameter(cmdUpdate, "@fec_entrega", DbType.DateTime, pReclamo.MuestraFecha)
                db.AddInParameter(cmdUpdate, "@observacion", DbType.String, pReclamo.MuestraComentario)
                db.AddInParameter(cmdUpdate, "@opcion", DbType.Int32, 5)

                db.ExecuteNonQuery(cmdUpdate, Trans)

                'detalles
                Dim cmdMuestraElim As DbCommand = db.GetStoredProcCommand("usp_reclamos_muestra")
                db.AddInParameter(cmdMuestraElim, "@cod_cia", DbType.String, pReclamo.CodCia)
                db.AddInParameter(cmdMuestraElim, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmdMuestraElim, "@id", DbType.Int32, 0)
                db.AddInParameter(cmdMuestraElim, "@opcion", DbType.Int32, 3)

                db.ExecuteNonQuery(cmdMuestraElim, Trans)

                Dim cmdMuestrasLab As DbCommand = Nothing

                For Each oReclamoMuestras As ETReclamoMuestra In pReclamo.ListaMuestras
                    cmdMuestrasLab = db.GetStoredProcCommand("usp_reclamos_muestra")
                    db.AddInParameter(cmdMuestrasLab, "@cod_cia", DbType.String, pReclamo.CodCia)
                    db.AddInParameter(cmdMuestrasLab, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddInParameter(cmdMuestrasLab, "@id", DbType.Int32, 0)
                    db.AddInParameter(cmdMuestrasLab, "@cod_prod", DbType.String, oReclamoMuestras.COD_PRODUCTO)
                    db.AddInParameter(cmdMuestrasLab, "@producto", DbType.String, oReclamoMuestras.PRODUCTO)
                    db.AddInParameter(cmdMuestrasLab, "@lote", DbType.String, oReclamoMuestras.LOTE)
                    db.AddInParameter(cmdMuestrasLab, "@nro_bolsas", DbType.String, oReclamoMuestras.NROBOLSA)
                    db.AddInParameter(cmdMuestrasLab, "@nro_bolsas_reclamadas", DbType.String, oReclamoMuestras.NROBOLSARECLAMADAS)
                    db.AddInParameter(cmdMuestrasLab, "@fec_entrega", DbType.DateTime, oReclamoMuestras.FECHA_INICIO)
                    db.AddInParameter(cmdMuestrasLab, "@observacion", DbType.String, oReclamoMuestras.OBSERVACION)
                    db.AddInParameter(cmdMuestrasLab, "@ruta_archivo", DbType.String, oReclamoMuestras.ARCHIVOM)
                    db.AddInParameter(cmdMuestrasLab, "@user", DbType.String, pReclamo.UsuarioRegistra.Codigo)
                    db.AddInParameter(cmdMuestrasLab, "@estado", DbType.String, oReclamoMuestras.ESTADO)
                    db.AddInParameter(cmdMuestrasLab, "@estado_obs", DbType.String, oReclamoMuestras.ESTADO_OBS)
                    db.AddInParameter(cmdMuestrasLab, "@responsable", DbType.String, oReclamoMuestras.RESPONSABLE)
                    db.AddInParameter(cmdMuestrasLab, "@opcion", DbType.Int32, 1)

                    db.ExecuteNonQuery(cmdMuestrasLab, Trans)
                Next

                oResultado.Realizo = True

                Trans.Commit()
                Conexion.Close()

            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using
        Return oResultado
    End Function

    Public Function RegistrarEvidenciaCorreo(ByVal pReclamo As ETReclamo) As ETResultado
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                'aprobaciones requeridas
                Dim cmdReq As DbCommand = db.GetStoredProcCommand("usp_Reclamo_Correo_Evidencia")
                db.AddInParameter(cmdReq, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmdReq, "@ruta", DbType.String, pReclamo.RutaCorreo)
                db.AddInParameter(cmdReq, "@nroncredito", DbType.String, pReclamo.NroNCredito)
                db.AddInParameter(cmdReq, "@usuario", DbType.String, pReclamo.UsuarioRegistra.Codigo)

                db.ExecuteNonQuery(cmdReq, Trans)

                Dim cmdMuestrasLab As DbCommand = Nothing

                oResultado.Realizo = True

                Trans.Commit()
                Conexion.Close()

            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using
        Return oResultado
    End Function

    Public Function RegistrarAprobacion(ByVal pReclamo As ETReclamo, ByVal Tipo As String, ByVal User_Sistema As String)
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim oAprobacion As ETReclamoAprobacion = Nothing

                Select Case Tipo
                    Case "PRODUCCION" : oAprobacion = pReclamo.AprobacionProduccion
                    Case "COMERCIAL" : oAprobacion = pReclamo.AprobacionComercial
                    Case "LABORATORIO" : oAprobacion = pReclamo.AprobacionLaboratorio
                    Case "GERENCIA" : oAprobacion = pReclamo.AprobacionGerencia
                End Select


                'If pReclamo.AprobacionProduccion.Observacion.Length > 0 Then
                Dim cmdProd As DbCommand = db.GetStoredProcCommand("usp_reclamo_aprobacion")
                db.AddInParameter(cmdProd, "@cod_cia", DbType.String, pReclamo.CodCia)
                db.AddInParameter(cmdProd, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmdProd, "@tipo", DbType.String, Tipo)
                db.AddInParameter(cmdProd, "@cod_per", DbType.String, oAprobacion.Gerente.Codigo)
                db.AddInParameter(cmdProd, "@observacion", DbType.String, oAprobacion.Observacion)
                db.AddInParameter(cmdProd, "@planaccion", DbType.String, oAprobacion.AccionesPorTomar)
                db.AddInParameter(cmdProd, "@fec_aprobacion", DbType.DateTime, oAprobacion.FechaAprobacion)
                db.AddInParameter(cmdProd, "@aprobado", DbType.Boolean, oAprobacion.Aprobado)
                db.AddInParameter(cmdProd, "@RegNotaCredito", DbType.Boolean, oAprobacion.RegNotaCredito)
                db.AddInParameter(cmdProd, "@user", DbType.String, User_Sistema)

                db.ExecuteNonQuery(cmdProd, Trans)
                'End If

                Trans.Commit()
                Conexion.Close()

                oResultado.Realizo = True

            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try


        End Using

        Return oResultado
    End Function

    Public Function ObtenerAnalisis(ByVal pReclamo As ETReclamo) As List(Of ETReclamoCausa)
        Dim lista As New List(Of ETReclamoCausa)
        Dim listaDet As New List(Of ETReclamoCausaDetalle)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamos_obtener_analisis")
        Dim oCausaOrigen As ETReclamoCausa = Nothing
        Dim oCausaOrigenDet As ETReclamoCausaDetalle = Nothing

        Try
            db.AddInParameter(cmd, "@id_reclamo", DbType.Int32, pReclamo.Id)

            Using reader As IDataReader = db.ExecuteReader(cmd)

                While reader.Read()
                    oCausaOrigen = New ETReclamoCausa

                    If reader("id_reclamo_causa") IsNot DBNull.Value Then
                        oCausaOrigen.Id = Convert.ToInt32(reader("id_reclamo_causa"))
                    End If
                    If reader("causa_origen") IsNot DBNull.Value Then
                        oCausaOrigen.CausaOrigen = Convert.ToString(reader("causa_origen"))
                    End If
                    If reader("cod_per_analisis") IsNot DBNull.Value Then
                        oCausaOrigen.Registrador.Codigo = Convert.ToString(reader("cod_per_analisis"))
                    End If
                    If reader("pers_analisis") IsNot DBNull.Value Then
                        oCausaOrigen.Registrador.Nombre = Convert.ToString(reader("pers_analisis"))
                    End If

                    lista.Add(oCausaOrigen)

                End While

                If reader.NextResult() Then

                    While reader.Read()
                        oCausaOrigenDet = New ETReclamoCausaDetalle()
                        If reader("id_reclamo_causa") IsNot DBNull.Value Then
                            oCausaOrigenDet.IdCausa = Convert.ToInt32(reader("id_reclamo_causa"))
                        End If
                        If reader("id_reclamo_causa_det") IsNot DBNull.Value Then
                            oCausaOrigenDet.Id = Convert.ToInt32(reader("id_reclamo_causa_det"))
                        End If
                        If reader("item") IsNot DBNull.Value Then
                            oCausaOrigenDet.Item = Convert.ToInt32(reader("item"))
                        End If
                        If reader("descripcion") IsNot DBNull.Value Then
                            oCausaOrigenDet.Descripcion = Convert.ToString(reader("descripcion"))
                        End If
                        listaDet.Add(oCausaOrigenDet)
                    End While

                End If

                For Each item As ETReclamoCausa In lista
                    Dim Id As Integer = item.Id
                    item.Detalles = listaDet.FindAll(Function(p) p.IdCausa = Id)
                Next

                If reader IsNot Nothing Then reader.Close()

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return lista
    End Function

    Public Function RegistrarAnalisis(ByVal pReclamo As ETReclamo) As ETResultado
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamo_analisis")
                db.AddInParameter(cmd, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmd, "@fecha_analisis", DbType.DateTime, pReclamo.FechaAnalisis.Value)
                db.AddInParameter(cmd, "@resp_analisis", DbType.String, pReclamo.PersonaAnalisis.Codigo)
                db.AddInParameter(cmd, "@user", DbType.String, pReclamo.UsuarioRegistra.Codigo)

                db.ExecuteNonQuery(cmd, Trans)

                Dim cmdElim As DbCommand = db.GetStoredProcCommand("usp_reclamo_causa_origen")
                db.AddInParameter(cmdElim, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddOutParameter(cmdElim, "@id_reclamo_causa", DbType.Int32, 8)
                db.AddInParameter(cmdElim, "@fecha", DbType.DateTime, pReclamo.FechaAnalisis.Value)
                db.AddInParameter(cmdElim, "@cod_per_analisis", DbType.String, String.Empty)
                db.AddInParameter(cmdElim, "@pers_analisis", DbType.String, String.Empty)
                db.AddInParameter(cmdElim, "@causa_origen", DbType.String, String.Empty)
                db.AddInParameter(cmdElim, "@opcion", DbType.Int32, 3)

                db.ExecuteNonQuery(cmdElim, Trans)

                Dim cmdReg As DbCommand = Nothing
                For Each oCausaOrigen As ETReclamoCausa In pReclamo.Causas
                    cmdReg = db.GetStoredProcCommand("usp_reclamo_causa_origen")
                    db.AddInParameter(cmdReg, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddOutParameter(cmdReg, "@id_reclamo_causa", DbType.Int32, 8)
                    db.AddInParameter(cmdReg, "@fecha", DbType.DateTime, pReclamo.FechaAnalisis.Value)
                    db.AddInParameter(cmdReg, "@cod_per_analisis", DbType.String, oCausaOrigen.Registrador.Codigo)
                    db.AddInParameter(cmdReg, "@pers_analisis", DbType.String, oCausaOrigen.Registrador.Nombre)
                    db.AddInParameter(cmdReg, "@causa_origen", DbType.String, oCausaOrigen.CausaOrigen)
                    db.AddInParameter(cmdReg, "@opcion", DbType.Int32, 1)

                    db.ExecuteNonQuery(cmdReg, Trans)

                    oCausaOrigen.Id = Convert.ToInt32(db.GetParameterValue(cmdReg, "@id_reclamo_causa"))

                    Dim cmdRegDet As DbCommand = Nothing

                    For Each oCausaOrigenDet As ETReclamoCausaDetalle In oCausaOrigen.Detalles
                        cmdRegDet = db.GetStoredProcCommand("usp_reclamo_causa_origen_det")

                        db.AddInParameter(cmdRegDet, "@id_reclamo", DbType.Int32, pReclamo.Id)
                        db.AddInParameter(cmdRegDet, "@id_reclamo_causa", DbType.Int32, oCausaOrigen.Id)
                        db.AddInParameter(cmdRegDet, "@item", DbType.Int32, oCausaOrigenDet.Item)
                        db.AddInParameter(cmdRegDet, "@descripcion", DbType.String, oCausaOrigenDet.Descripcion)
                        db.AddInParameter(cmdRegDet, "@opcion", DbType.Int32, 1)
                        db.AddOutParameter(cmdRegDet, "@id_reclamo_causa_det", DbType.Int32, 8)

                        db.ExecuteNonQuery(cmdRegDet, Trans)

                        oCausaOrigenDet.Id = Convert.ToInt32(db.GetParameterValue(cmdRegDet, "@id_reclamo_causa_det"))
                    Next

                Next


                Trans.Commit()
                Conexion.Close()

                oResultado.Realizo = True

            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                oResultado.Mensaje = ex.Message
                MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using

        Return oResultado
    End Function

    Public Function ReporteFormato(ByVal pReclamo As ETReclamo) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamo_reporte_formato_cliente")

        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@id_reclamo", DbType.Int32, pReclamo.Id)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Ds.DataSetName = "dsFormato"
            Ds.Tables(0).TableName = "RECLAMO"
            Ds.Tables(1).TableName = "COMENTARIOS"
            Ds.Tables(2).TableName = "PLAN_ACCION"

            Return Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ReporteReclamo(ByVal pReclamo As ETReclamo) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("sp_reclamo_reporte")

        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@id_reclamo", DbType.Int32, pReclamo.Id)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Ds.DataSetName = "dsReclamo"
            Ds.Tables(0).TableName = "Reclamo"
            Ds.Tables(1).TableName = "Productos"
            Ds.Tables(2).TableName = "Muestras"
            Ds.Tables(3).TableName = "PlanAccion"
            Ds.Tables(4).TableName = "Servicio"

            Return Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function RegistrarProgramacionReunion(ByVal pReclamo As ETReclamo)
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamo_reunion")
                db.AddInParameter(cmd, "id_reclamo", DbType.String, pReclamo.Id)
                db.AddInParameter(cmd, "@lugar_reunion", DbType.String, pReclamo.LugarReunion)
                If pReclamo.FechaReunion.HasValue Then
                    db.AddInParameter(cmd, "@fecha_reunion", DbType.DateTime, pReclamo.FechaReunion.Value)
                Else
                    db.AddInParameter(cmd, "@fecha_reunion", DbType.DateTime, DBNull.Value)
                End If
                db.AddInParameter(cmd, "@coord_reunion", DbType.String, pReclamo.Organizador.Codigo)

                db.ExecuteNonQuery(cmd, Trans)

                Dim cmdEliminar As DbCommand = db.GetStoredProcCommand("usp_reclamo_persona")

                db.AddInParameter(cmdEliminar, "@cod_cia", DbType.String, pReclamo.CodCia)
                db.AddInParameter(cmdEliminar, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmdEliminar, "@tipo", DbType.String, "PARTICIPANTE")
                db.AddInParameter(cmdEliminar, "@opcion", DbType.Int32, 3)

                db.ExecuteNonQuery(cmdEliminar, Trans)

                Dim cmdPart As DbCommand = Nothing

                For Each oParticipante As ETReclamoPersona In pReclamo.ListaParticipantes
                    cmdPart = db.GetStoredProcCommand("usp_reclamo_persona")
                    db.AddInParameter(cmdPart, "@cod_cia", DbType.String, pReclamo.CodCia)
                    db.AddInParameter(cmdPart, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddInParameter(cmdPart, "@tipo", DbType.String, "PARTICIPANTE")
                    db.AddInParameter(cmdPart, "@cod_per", DbType.String, oParticipante.Codigo)
                    db.AddInParameter(cmdPart, "@persona", DbType.String, oParticipante.Nombre)
                    db.AddInParameter(cmdPart, "@correo", DbType.String, oParticipante.Correo)
                    db.AddInParameter(cmdPart, "@area", DbType.String, oParticipante.Area)
                    db.AddInParameter(cmdPart, "@opcion", DbType.Int32, 1)

                    db.ExecuteNonQuery(cmdPart, Trans)
                Next

                Trans.Commit()
                Conexion.Close()
                oResultado.Realizo = True

            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using

        Return oResultado
    End Function

    Public Function ObtenerPersonalPorGrupo(ByVal Grupo As String, ByVal NroReclamo As String) As List(Of ETReclamoPersona)
        Dim lista As New List(Of ETReclamoPersona)
        Dim item As ETReclamoPersona = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand("sp_reclamo_listar_personas")
            db.AddInParameter(cmd, "@nro_reclamo", DbType.String, NroReclamo)
            db.AddInParameter(cmd, "@grupo", DbType.String, Grupo)

            Using reader As IDataReader = db.ExecuteReader(cmd)

                While reader.Read()
                    item = New ETReclamoPersona
                    If reader("codigo") IsNot DBNull.Value Then
                        item.Codigo = reader("codigo").ToString()
                    End If
                    If reader("persona") IsNot DBNull.Value Then
                        item.Nombre = reader("persona").ToString()
                    End If
                    If reader("correo") IsNot DBNull.Value Then
                        item.Correo = reader("correo").ToString()
                    End If
                    If reader("area") IsNot DBNull.Value Then
                        item.Area = reader("area").ToString()
                    End If
                    lista.Add(item)
                End While

                If reader IsNot Nothing Then reader.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return lista
    End Function

    Public Function ObtenerCorreosClientes(ByVal pReclamo As ETReclamo) As List(Of ETReclamoPersona)
        Dim lista As New List(Of ETReclamoPersona)
        Dim item As ETReclamoPersona = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamo_persona")
            db.AddInParameter(cmd, "@cod_cia", DbType.String, pReclamo.CodCia)
            db.AddInParameter(cmd, "@id_reclamo", DbType.Int32, pReclamo.Id)
            db.AddInParameter(cmd, "@tipo", DbType.String, "CORREOCLIENTE")
            db.AddInParameter(cmd, "@opcion", DbType.Int32, 4)
            Using reader As IDataReader = db.ExecuteReader(cmd)

                While reader.Read()
                    item = New ETReclamoPersona
                    If reader("persona") IsNot DBNull.Value Then
                        item.Nombre = reader("persona").ToString()
                    End If
                    If reader("correo") IsNot DBNull.Value Then
                        item.Correo = reader("correo").ToString()
                    End If
                    lista.Add(item)
                End While

                If reader IsNot Nothing Then reader.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return lista
    End Function

    Public Function ObtenerReclamo(ByVal pReclamo As ETReclamo) As ETReclamo
        Dim oReclamo As ETReclamo = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Try

            Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamo_obtener_240709")
            db.AddInParameter(cmd, "@cod_cia", DbType.String, pReclamo.CodCia)
            db.AddInParameter(cmd, "@id_reclamo", DbType.String, pReclamo.Id)

            Using reader As IDataReader = db.ExecuteReader(cmd)

                '1.- Reclamo 
                While reader.Read()
                    oReclamo = (ObtenerEntidad(reader))
                End While

                '2.- productos
                If reader.NextResult() Then

                    While reader.Read()
                        Dim oProdDet As New ETReclamoProductoDetalle()
                        If reader("prod_cod") IsNot DBNull.Value Then
                            oProdDet.COD_PRODUCTO = Convert.ToString(reader("prod_cod"))
                        End If
                        If reader("producto") IsNot DBNull.Value Then
                            oProdDet.PRODUCTO = Convert.ToString(reader("producto"))
                        End If
                        If reader("unidad") IsNot DBNull.Value Then
                            oProdDet.UNIDAD = Convert.ToString(reader("unidad"))
                        End If
                        If reader("cant_ing") IsNot DBNull.Value Then
                            oProdDet.CANT_INGRESADA = Convert.ToDecimal(reader("cant_ing"))
                        End If
                        If reader("cant_fact") IsNot DBNull.Value Then
                            oProdDet.CANT_FACTURADA = Convert.ToDecimal(reader("cant_fact"))
                        End If
                        If reader("lote") IsNot DBNull.Value Then
                            oProdDet.LOTE = Convert.ToString(reader("lote"))
                        End If
                        If reader("nrobolsas") IsNot DBNull.Value Then
                            oProdDet.NRO_BOLSAS = Convert.ToString(reader("nrobolsas"))
                        End If
                        If reader("nrobolsas_reclamadas") IsNot DBNull.Value Then
                            oProdDet.NRO_BOLSAS_RECLAMADAS = Convert.ToString(reader("nrobolsas_reclamadas"))
                        End If
                        If reader("nroguia") IsNot DBNull.Value Then
                            oProdDet.NRO_GUIA = Convert.ToString(reader("nroguia"))
                        End If
                        If reader("nrofact") IsNot DBNull.Value Then
                            oProdDet.NRO_FACT = Convert.ToString(reader("nrofact"))
                        End If
                        If reader("fecha") IsNot DBNull.Value Then
                            oProdDet.FECHA = Convert.ToDateTime(reader("fecha"))
                        End If
                        oReclamo.Producto.ListaDetalles.Add(oProdDet)
                    End While

                End If

                '3.- Servicios
                If reader.NextResult() Then
                    While reader.Read()
                        Dim oServicioDet As New ETReclamoServicio
                        If reader("cod_servicio") IsNot DBNull.Value Then
                            oServicioDet.Codigo = Convert.ToString(reader("cod_servicio"))
                        End If
                        If reader("cod_opcion") IsNot DBNull.Value Then
                            oServicioDet.Opcion = Convert.ToString(reader("cod_opcion"))
                        End If
                        If reader("obs_opcion") IsNot DBNull.Value Then
                            oServicioDet.Observacion = Convert.ToString(reader("obs_opcion"))
                        End If
                        oReclamo.Servicios.Add(oServicioDet)
                    End While
                End If

                '4.- Muestras
                If reader.NextResult() Then
                    While reader.Read()
                        Dim oMuestraReclamo As New ETReclamoMuestra
                        If reader("id_reclamo_muestra") IsNot DBNull.Value Then
                            oMuestraReclamo.ID = Convert.ToInt32(reader("id_reclamo_muestra"))
                        End If
                        If reader("producto") IsNot DBNull.Value Then
                            oMuestraReclamo.PRODUCTO = Convert.ToString(reader("producto"))
                        End If
                        If reader("lote") IsNot DBNull.Value Then
                            oMuestraReclamo.LOTE = Convert.ToString(reader("lote"))
                        End If
                        If reader("nro_bolsas") IsNot DBNull.Value Then
                            oMuestraReclamo.NROBOLSA = Convert.ToString(reader("nro_bolsas"))
                        End If
                        If reader("nro_bolsas_reclamadas") IsNot DBNull.Value Then
                            oMuestraReclamo.NROBOLSARECLAMADAS = Convert.ToString(reader("nro_bolsas_reclamadas"))
                        End If
                        If reader("observacion") IsNot DBNull.Value Then
                            oMuestraReclamo.OBSERVACION = Convert.ToString(reader("observacion"))
                        End If
                        If reader("responsable_lab") IsNot DBNull.Value Then
                            oMuestraReclamo.RESPONSABLE = Convert.ToString(reader("responsable_lab"))
                        End If
                        If reader("fec_entrega") IsNot DBNull.Value Then
                            oMuestraReclamo.FECHA_INICIO = Convert.ToDateTime(reader("fec_entrega"))
                        End If
                        If reader("fec_informe") IsNot DBNull.Value Then
                            oMuestraReclamo.FECHA_FIN = Convert.ToDateTime(reader("fec_informe"))
                        End If
                        If reader("estado") IsNot DBNull.Value Then
                            oMuestraReclamo.ESTADO = Convert.ToString(reader("estado"))
                        End If
                        If reader("estado_obs") IsNot DBNull.Value Then
                            oMuestraReclamo.ESTADO_OBS = Convert.ToString(reader("estado_obs"))
                        End If
                        If reader("ruta_archivo") IsNot DBNull.Value Then
                            oMuestraReclamo.ARCHIVOM = Convert.ToString(reader("ruta_archivo"))
                        End If

                        oReclamo.ListaMuestras.Add(oMuestraReclamo)

                        Dim oMuestraReclamosLab As New EtReclamoMuestraLab(oMuestraReclamo)

                        If reader("cod_per_aprob") IsNot DBNull.Value Then
                            oMuestraReclamosLab.APROBADO_POR = Convert.ToString(reader("cod_per_aprob"))
                        End If
                        If reader("ruta_archivo_lab") IsNot DBNull.Value Then
                            oMuestraReclamosLab.ARCHIVO = Convert.ToString(reader("ruta_archivo_lab"))
                        End If
                        If reader("fecha_entrega_conforme") IsNot DBNull.Value Then
                            oMuestraReclamosLab.FECHA_CONFORME = Convert.ToBoolean(reader("fecha_entrega_conforme"))
                        End If
                        If reader("muestra_entrega_conforme") IsNot DBNull.Value Then
                            oMuestraReclamosLab.MUESTRA_CONFORME = Convert.ToBoolean(reader("muestra_entrega_conforme"))
                        End If

                        oReclamo.ListaMuestrasLab.Add(oMuestraReclamosLab)
                    End While
                End If

                '5.- Aprobacion Produccion
                If reader.NextResult() Then
                    If reader.Read() Then
                        If reader("persona_cod") IsNot DBNull.Value Then
                            oReclamo.AprobacionProduccion.Gerente.Codigo = Convert.ToString(reader("persona_cod"))
                        End If
                        If reader("persona") IsNot DBNull.Value Then
                            oReclamo.AprobacionProduccion.Gerente.Nombre = Convert.ToString(reader("persona"))
                        End If
                        If reader("obs") IsNot DBNull.Value Then
                            oReclamo.AprobacionProduccion.Observacion = Convert.ToString(reader("obs"))
                        End If
                        If reader("planaccion") IsNot DBNull.Value Then
                            oReclamo.AprobacionProduccion.AccionesPorTomar = Convert.ToString(reader("planaccion"))
                        End If
                        If reader("fec_aprobacion") IsNot DBNull.Value Then
                            oReclamo.AprobacionProduccion.FechaAprobacion = Convert.ToDateTime(reader("fec_aprobacion"))
                        End If
                        If reader("aprobado") IsNot DBNull.Value Then
                            oReclamo.AprobacionProduccion.Aprobado = Convert.ToBoolean(reader("aprobado"))
                        End If

                    End If
                End If

                '6.- Aprobacion Comercial
                If reader.NextResult() Then
                    If reader.Read() Then
                        If reader("persona_cod") IsNot DBNull.Value Then
                            oReclamo.AprobacionComercial.Gerente.Codigo = Convert.ToString(reader("persona_cod"))
                        End If
                        If reader("persona") IsNot DBNull.Value Then
                            oReclamo.AprobacionComercial.Gerente.Nombre = Convert.ToString(reader("persona"))
                        End If
                        If reader("obs") IsNot DBNull.Value Then
                            oReclamo.AprobacionComercial.Observacion = Convert.ToString(reader("obs"))
                        End If
                        If reader("planaccion") IsNot DBNull.Value Then
                            oReclamo.AprobacionComercial.AccionesPorTomar = Convert.ToString(reader("planaccion"))
                        End If
                        If reader("fec_aprobacion") IsNot DBNull.Value Then
                            oReclamo.AprobacionComercial.FechaAprobacion = Convert.ToDateTime(reader("fec_aprobacion"))
                        End If
                        If reader("aprobado") IsNot DBNull.Value Then
                            oReclamo.AprobacionComercial.Aprobado = Convert.ToBoolean(reader("aprobado"))
                        End If

                        If reader("regnotacredito") IsNot DBNull.Value Then
                            oReclamo.AprobacionComercial.RegNotaCredito = Convert.ToBoolean(reader("regnotacredito"))
                        End If

                    End If
                End If

                '7.- Aprobacion Laboratorio
                If reader.NextResult() Then
                    If reader.Read() Then
                        If reader("persona_cod") IsNot DBNull.Value Then
                            oReclamo.AprobacionLaboratorio.Gerente.Codigo = Convert.ToString(reader("persona_cod"))
                        End If
                        If reader("persona") IsNot DBNull.Value Then
                            oReclamo.AprobacionLaboratorio.Gerente.Nombre = Convert.ToString(reader("persona"))
                        End If
                        If reader("obs") IsNot DBNull.Value Then
                            oReclamo.AprobacionLaboratorio.Observacion = Convert.ToString(reader("obs"))
                        End If
                        If reader("planaccion") IsNot DBNull.Value Then
                            oReclamo.AprobacionLaboratorio.AccionesPorTomar = Convert.ToString(reader("planaccion"))
                        End If
                        If reader("fec_aprobacion") IsNot DBNull.Value Then
                            oReclamo.AprobacionLaboratorio.FechaAprobacion = Convert.ToDateTime(reader("fec_aprobacion"))
                        End If
                        If reader("aprobado") IsNot DBNull.Value Then
                            oReclamo.AprobacionLaboratorio.Aprobado = Convert.ToBoolean(reader("aprobado"))
                        End If
                    End If
                End If

                '8.- Participantes de reunion
                Dim oParticipante As ETReclamoPersona = Nothing
                If reader.NextResult() Then

                    While reader.Read()
                        oParticipante = New ETReclamoPersona()
                        If reader("cod_per") IsNot DBNull.Value Then
                            oParticipante.Codigo = Convert.ToString(reader("cod_per"))
                        End If
                        If reader("persona") IsNot DBNull.Value Then
                            oParticipante.Nombre = Convert.ToString(reader("persona"))
                        End If
                        If reader("correo") IsNot DBNull.Value Then
                            oParticipante.Correo = Convert.ToString(reader("correo"))
                        End If
                        If reader("area") IsNot DBNull.Value Then
                            oParticipante.Area = Convert.ToString(reader("area"))
                        End If
                        oReclamo.ListaParticipantes.Add(oParticipante)
                    End While

                End If

                '9.- Causas
                If reader.NextResult() Then
                End If

                '10. Plan de Accion
                Dim oPlanAccion As ETReclamoPlanAccion = Nothing
                If reader.NextResult() Then
                    While reader.Read()
                        oPlanAccion = New ETReclamoPlanAccion

                        If reader("Item") IsNot DBNull.Value Then
                            oPlanAccion.Item = Convert.ToInt32(reader("Item"))
                        End If
                        If reader("persona_cod") IsNot DBNull.Value Then
                            oPlanAccion.ETEncargado.Codigo = Convert.ToString(reader("persona_cod"))
                        End If
                        If reader("persona") IsNot DBNull.Value Then
                            oPlanAccion.ETEncargado.Nombre = Convert.ToString(reader("persona"))
                        End If
                        If reader("accion") IsNot DBNull.Value Then
                            oPlanAccion.AccionPorRealizar = Convert.ToString(reader("accion"))
                        End If
                        If reader("estado") IsNot DBNull.Value Then
                            oPlanAccion.Estado = Convert.ToString(reader("estado"))
                        End If
                        If reader("fec_propuesta") IsNot DBNull.Value Then
                            oPlanAccion.FechaPropuesta = Convert.ToDateTime(reader("fec_propuesta"))
                        End If
                        If reader("fec_ejecucion") IsNot DBNull.Value Then
                            oPlanAccion.FechaEjecucion = Convert.ToDateTime(reader("fec_ejecucion"))
                        End If
                        If reader("notifica") IsNot DBNull.Value Then
                            oPlanAccion.Notifica = Convert.ToBoolean(reader("notifica"))
                        End If
                        oReclamo.ListaPlanes.Add(oPlanAccion)
                    End While
                End If
                '11.- Evidencias
                'If reader.NextResult() Then
                'End If

                'AProbacion Gerencia
                'If reader.NextResult() Then
                '    If reader.Read() Then
                '        If reader("persona_cod") IsNot DBNull.Value Then
                '            oReclamo.AprobacionGerencia.Gerente.Codigo = Convert.ToString(reader("persona_cod"))
                '        End If
                '        If reader("persona") IsNot DBNull.Value Then
                '            oReclamo.AprobacionGerencia.Gerente.Nombre = Convert.ToString(reader("persona"))
                '        End If
                '        If reader("obs") IsNot DBNull.Value Then
                '            oReclamo.AprobacionGerencia.Observacion = Convert.ToString(reader("obs"))
                '        End If
                '        If reader("fec_aprobacion") IsNot DBNull.Value Then
                '            oReclamo.AprobacionGerencia.FechaAprobacion = Convert.ToDateTime(reader("fec_aprobacion"))
                '        End If
                '        If reader("aprobado") IsNot DBNull.Value Then
                '            oReclamo.AprobacionGerencia.Aprobado = Convert.ToBoolean(reader("aprobado"))
                '        End If
                '    End If
                'End If

                '12.- Producto Opciones - Propiedades Quimicas / Fisicas / Otros 
                ' - LECTURA DE DATOS - A UN OBJETO 
                '-------------------------------------------------------------------------
                Dim oProductoOpcion As New ETReclamoProductoOpcion
                If reader.NextResult() Then

                    While reader.Read()
                        oProductoOpcion = New ETReclamoProductoOpcion
                        If reader("cod_producto") IsNot DBNull.Value Then
                            oProductoOpcion.Codigo = Convert.ToString(reader("cod_producto"))
                        End If
                        If reader("cod_opcion") IsNot DBNull.Value Then
                            oProductoOpcion.Opcion = Convert.ToString(reader("cod_opcion"))
                        End If
                        If reader("obs_opcion") IsNot DBNull.Value Then
                            oProductoOpcion.Observacion = Convert.ToString(reader("obs_opcion"))
                        End If
                        oReclamo.ProductosOpcion.Add(oProductoOpcion)
                    End While

                End If

                If reader IsNot Nothing Then reader.Close()

            End Using
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return oReclamo
    End Function

    Public Function ObtenerListaEvidencias(ByVal pReclamo As ETReclamo) As List(Of ETReclamoEvidencia)
        Dim lista As New List(Of ETReclamoEvidencia)
        Dim item As ETReclamoEvidencia = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand("sp_reclamo_evidencia")
            db.AddInParameter(cmd, "@id_reclamo", DbType.Int32, pReclamo.Id)
            db.AddInParameter(cmd, "@opcion", DbType.Int32, 4)
            Using reader As IDataReader = db.ExecuteReader(cmd)

                While reader.Read()
                    item = New ETReclamoEvidencia
                    If reader("fecha") IsNot DBNull.Value Then
                        item.Fecha = Convert.ToDateTime(reader("fecha"))
                    End If
                    If reader("comentario") IsNot DBNull.Value Then
                        item.Comentario = Convert.ToString(reader("comentario"))
                    End If
                    If reader("archivo") IsNot DBNull.Value Then
                        item.Archivo = Convert.ToString(reader("archivo"))
                    End If
                    lista.Add(item)
                End While

                If reader IsNot Nothing Then reader.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return lista
    End Function
    Public Function RegistrarEvidencia(ByVal pReclamo As ETReclamo) As ETResultado
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Dim cmdReq As DbCommand = db.GetStoredProcCommand("usp_reclamo_actualizar_reqAprobacion")
                db.AddInParameter(cmdReq, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmdReq, "@reqAprobProb", DbType.Boolean, pReclamo.RequiereAprobProd)
                db.AddInParameter(cmdReq, "@reqAprobLab", DbType.Boolean, pReclamo.RequiereAprobLab)
                db.AddInParameter(cmdReq, "@reqAprobCom", DbType.Boolean, pReclamo.RequiereAprobCom)

                db.ExecuteNonQuery(cmdReq, Trans)


                Dim cmdElim As DbCommand = db.GetStoredProcCommand("sp_reclamo_evidencia")
                db.AddInParameter(cmdElim, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmdElim, "@fecha", DbType.DateTime, pReclamo.Fecha)
                db.AddInParameter(cmdElim, "@comentario", DbType.String, "")
                db.AddInParameter(cmdElim, "@archivo", DbType.String, "")
                db.AddInParameter(cmdElim, "@opcion", DbType.Int32, 3)

                db.AddOutParameter(cmdElim, "@id_reclamo_ev", DbType.Int32, 8)

                db.ExecuteNonQuery(cmdElim, Trans)

                Dim cmdReg As DbCommand = Nothing

                For Each oEvidencia As ETReclamoEvidencia In pReclamo.ListaEvidencias
                    cmdReg = db.GetStoredProcCommand("sp_reclamo_evidencia")
                    db.AddInParameter(cmdReg, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddInParameter(cmdReg, "@fecha", DbType.DateTime, oEvidencia.Fecha)
                    db.AddInParameter(cmdReg, "@comentario", DbType.String, oEvidencia.Comentario)
                    db.AddInParameter(cmdReg, "@archivo", DbType.String, oEvidencia.Archivo)
                    db.AddInParameter(cmdReg, "@opcion", DbType.Int32, 1)

                    db.AddOutParameter(cmdReg, "@id_reclamo_ev", DbType.Int32, 8)

                    db.ExecuteNonQuery(cmdReg, Trans)

                Next

                Trans.Commit()
                Conexion.Close()

                oResultado.Realizo = True

            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                oResultado.Mensaje = ex.Message
                MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using

        Return oResultado
    End Function
    Public Function RegistrarPlanesAccion(ByVal pReclamo As ETReclamo) As ETResultado
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand("sp_reclamo_plan_accion")
                db.AddInParameter(cmd, "@cod_cia", DbType.String, pReclamo.CodCia)
                db.AddInParameter(cmd, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmd, "@item", DbType.Int32, 0)
                db.AddInParameter(cmd, "@persona_cod", DbType.String, "")
                db.AddInParameter(cmd, "@persona", DbType.String, "")
                db.AddInParameter(cmd, "@accion", DbType.String, "")
                db.AddInParameter(cmd, "@fec_propuesta", DbType.DateTime, pReclamo.Fecha)
                db.AddInParameter(cmd, "@fec_ejecucion", DbType.DateTime, pReclamo.Fecha)
                db.AddInParameter(cmd, "@estado", DbType.String, "")
                db.AddInParameter(cmd, "@notifica", DbType.Boolean, 0)
                db.AddInParameter(cmd, "@opcion", DbType.Int32, 3)

                db.AddOutParameter(cmd, "@id_plan_accion", DbType.Int32, 8)

                db.ExecuteNonQuery(cmd, Trans)

                Dim cmdReg As DbCommand = Nothing

                For Each oPlanAccion As ETReclamoPlanAccion In pReclamo.ListaPlanes
                    cmdReg = db.GetStoredProcCommand("sp_reclamo_plan_accion")
                    db.AddInParameter(cmdReg, "@cod_cia", DbType.String, pReclamo.CodCia)
                    db.AddInParameter(cmdReg, "@id_reclamo", DbType.Int32, pReclamo.Id)
                    db.AddInParameter(cmdReg, "@item", DbType.Int32, oPlanAccion.ItemCausa)
                    db.AddInParameter(cmdReg, "@persona_cod", DbType.String, oPlanAccion.EncargadoCodigo)
                    db.AddInParameter(cmdReg, "@persona", DbType.String, oPlanAccion.Encargado)
                    db.AddInParameter(cmdReg, "@accion", DbType.String, oPlanAccion.AccionPorRealizar)
                    db.AddInParameter(cmdReg, "@fec_propuesta", DbType.DateTime, oPlanAccion.FechaPropuesta)
                    db.AddInParameter(cmdReg, "@fec_ejecucion", DbType.DateTime, oPlanAccion.FechaEjecucion)
                    db.AddInParameter(cmdReg, "@estado", DbType.String, "PROCESO")
                    db.AddInParameter(cmdReg, "@notifica", DbType.Boolean, oPlanAccion.Notifica)
                    db.AddInParameter(cmdReg, "@opcion", DbType.Int32, 1)

                    db.AddOutParameter(cmdReg, "@id_plan_accion", DbType.Int32, 8)

                    db.ExecuteNonQuery(cmdReg, Trans)

                Next

                Trans.Commit()
                Conexion.Close()

                oResultado.Realizo = True

            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                oResultado.Mensaje = ex.Message
                MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using

        Return oResultado
    End Function

    Public Function ListarReclamos(ByVal pReclamo As ETReclamo, ByVal pRol As String) As List(Of ETReclamo)
        Dim lista As New List(Of ETReclamo)

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamos_listar_240709")
            db.AddInParameter(cmd, "@cod_cia", DbType.String, pReclamo.CodCia)
            db.AddInParameter(cmd, "@cod_cli", DbType.String, pReclamo.ClienteCodigo)
            db.AddInParameter(cmd, "@Rol", DbType.String, pRol)
            db.AddInParameter(cmd, "@dtmFechaInicio", DbType.DateTime, pReclamo.Fecha)
            db.AddInParameter(cmd, "@dtmFechaFin", DbType.DateTime, pReclamo.FechaFin)
            Using reader As IDataReader = db.ExecuteReader(cmd)

                While reader.Read()

                    lista.Add(ObtenerEntidad(reader))

                End While

                If reader IsNot Nothing Then reader.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return lista
    End Function

    Public Function ListarConfiguracion() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("USP_ERP_CONFIG_DIAS_RECLAMO")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Return Ds.Tables(0)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ObtenerPermisos(ByVal reader As IDataReader) As ETReclamoPermisos
        Dim item As ETReclamoPermisos = New ETReclamoPermisos
        Try
            While reader.Read()
                If reader("producto") IsNot DBNull.Value Then
                    item.Producto = Convert.ToBoolean(reader("producto"))
                End If
                If reader("servicio") IsNot DBNull.Value Then
                    item.Servicio = Convert.ToBoolean(reader("servicio"))
                End If
                If reader("muestra") IsNot DBNull.Value Then
                    item.Muestra = Convert.ToBoolean(reader("muestra"))
                End If
                If reader("evidencia") IsNot DBNull.Value Then
                    item.Evidencia = Convert.ToBoolean(reader("evidencia"))
                End If
                If reader("labinforme") IsNot DBNull.Value Then
                    item.InformeLab = Convert.ToBoolean(reader("labinforme"))
                End If
                If reader("labconforme") IsNot DBNull.Value Then
                    item.ConformidadLab = Convert.ToBoolean(reader("labconforme"))
                End If
                If reader("aprobprod") IsNot DBNull.Value Then
                    item.AprobProduccion = Convert.ToBoolean(reader("aprobprod"))
                End If
                If reader("aproblab") IsNot DBNull.Value Then
                    item.AprobLaboratorio = Convert.ToBoolean(reader("aproblab"))
                End If
                If reader("aprobger") IsNot DBNull.Value Then
                    item.AprobacionGerencial = Convert.ToBoolean(reader("aprobger"))
                End If
                If reader("aprobcom") IsNot DBNull.Value Then
                    item.AprobacionComercial = Convert.ToBoolean(reader("aprobcom"))
                End If
                If reader("reunion") IsNot DBNull.Value Then
                    item.Reunion = Convert.ToBoolean(reader("reunion"))
                End If
                If reader("analisis") IsNot DBNull.Value Then
                    item.AnalisisProblema = Convert.ToBoolean(reader("analisis"))
                End If
                If reader("planaccion") IsNot DBNull.Value Then
                    item.PlanesAccion = Convert.ToBoolean(reader("planaccion"))
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try
        Return item
    End Function

    Public Function ObtenerEntidad(ByVal reader As IDataReader) As ETReclamo
        Dim oReclamo As ETReclamo = Nothing
        Try
            oReclamo = New ETReclamo

            If reader("id_reclamo") IsNot DBNull.Value Then
                oReclamo.Id = Convert.ToInt32(reader("id_reclamo"))
            End If
            If reader("cod_cia") IsNot DBNull.Value Then
                oReclamo.CodCia = Convert.ToString(reader("cod_cia"))
            End If
            If reader("nro_reclamo") IsNot DBNull.Value Then
                oReclamo.Nro = Convert.ToString(reader("nro_reclamo"))
            End If
            If reader("tipo") IsNot DBNull.Value Then
                oReclamo.Tipo = Convert.ToString(reader("tipo"))
            End If

            If reader("origen") IsNot DBNull.Value Then
                oReclamo.Origen = Convert.ToString(reader("origen"))
            End If
            If reader("estado") IsNot DBNull.Value Then
                oReclamo.Estado = Convert.ToString(reader("estado"))
            End If

            If reader("fec_creacion") IsNot DBNull.Value Then
                oReclamo.Fecha = Convert.ToDateTime(reader("fec_creacion"))
            End If
            If reader("fec_termino") IsNot DBNull.Value Then
                oReclamo.FechaFin = Convert.ToDateTime(reader("fec_termino"))
            End If

            If reader("prod_motivo") IsNot DBNull.Value Then
                oReclamo.Producto.Motivo = Convert.ToString(reader("prod_motivo"))
            End If
            If reader("prod_nroguia") IsNot DBNull.Value Then
                oReclamo.Producto.NroGuia = Convert.ToString(reader("prod_nroguia"))
            End If
            If reader("prod_obs") IsNot DBNull.Value Then
                oReclamo.Producto.Observacion = Convert.ToString(reader("prod_obs"))
            End If
            If reader("serv_obs") IsNot DBNull.Value Then
                oReclamo.ServicioObservacion = Convert.ToString(reader("serv_obs"))
            End If


            If reader("prod_motivo") IsNot DBNull.Value Then
                oReclamo.Motivo = Convert.ToString(reader("prod_motivo"))
            End If
            If Convert.ToString(reader("tipo")) = 1 Then
                oReclamo.Observacion = Convert.ToString(reader("prod_obs"))
            Else
                oReclamo.Observacion = Convert.ToString(reader("serv_obs"))
            End If
            'If reader("prod_obs") IsNot DBNull.Value Then
            '    oReclamo.Origen = Convert.ToString(reader("prod_obs"))
            'End If
            'If reader("serv_obs") IsNot DBNull.Value Then
            '    oReclamo.ServicioObservacion = Convert.ToString(reader("serv_obs"))
            'End If

            If reader("cancelado") IsNot DBNull.Value Then
                oReclamo.Cancelado = Convert.ToBoolean(reader("cancelado"))
            End If
            If reader("fec_cancelado") IsNot DBNull.Value Then
                oReclamo.FechaCancelacion = Convert.ToString(reader("fec_cancelado"))
            End If
            If reader("motivo_cancelado") IsNot DBNull.Value Then
                oReclamo.MotivoCancelacion = Convert.ToString(reader("motivo_cancelado"))
            End If

            If reader("cliente_cod") IsNot DBNull.Value Then
                oReclamo.ClienteCodigo = Convert.ToString(reader("cliente_cod"))
            End If
            If reader("cliente") IsNot DBNull.Value Then
                oReclamo.Cliente = Convert.ToString(reader("cliente"))
            End If

            If reader("resp_cod") IsNot DBNull.Value Then
                oReclamo.UsuarioResponsable.Codigo = Convert.ToString(reader("resp_cod"))
            End If
            If reader("resp_nombre") IsNot DBNull.Value Then
                oReclamo.UsuarioResponsable.Nombre = Convert.ToString(reader("resp_nombre"))
            End If
            If reader("resp_correo") IsNot DBNull.Value Then
                oReclamo.UsuarioResponsable.Correo = Convert.ToString(reader("resp_correo"))
            End If

            If reader("registra_cod") IsNot DBNull.Value Then
                oReclamo.UsuarioRegistra.Codigo = Convert.ToString(reader("registra_cod"))
            End If
            If reader("registra_nombre") IsNot DBNull.Value Then
                oReclamo.UsuarioRegistra.Nombre = Convert.ToString(reader("registra_nombre"))
            End If
            If reader("registra_correo") IsNot DBNull.Value Then
                oReclamo.UsuarioRegistra.Correo = Convert.ToString(reader("registra_correo"))
            End If

            If reader("lugar_reunion") IsNot DBNull.Value Then
                oReclamo.LugarReunion = Convert.ToString(reader("lugar_reunion"))
            End If
            If reader("coord_reunion") IsNot DBNull.Value Then
                oReclamo.Organizador.Codigo = Convert.ToString(reader("coord_reunion"))
            End If
            If reader("reunion_org_persona") IsNot DBNull.Value Then
                oReclamo.Organizador.Nombre = Convert.ToString(reader("reunion_org_persona"))
            End If
            If reader("reunion_org_correo") IsNot DBNull.Value Then
                oReclamo.Organizador.Correo = Convert.ToString(reader("reunion_org_correo"))
            End If
            If reader("fecha_reunion") IsNot DBNull.Value Then
                oReclamo.FechaReunion = Convert.ToDateTime(reader("fecha_reunion"))
            End If

            If reader("fec_analisis") IsNot DBNull.Value Then
                oReclamo.FechaAnalisis = Convert.ToDateTime(reader("fec_analisis"))
            End If
            If reader("resp_analisis") IsNot DBNull.Value Then
                oReclamo.PersonaAnalisis.Codigo = Convert.ToString(reader("resp_analisis"))
            End If
            If reader("persona_analisis") IsNot DBNull.Value Then
                oReclamo.PersonaAnalisis.Nombre = Convert.ToString(reader("persona_analisis"))
            End If

            If reader("muestra_fecha") IsNot DBNull.Value Then
                oReclamo.MuestraFecha = Convert.ToString(reader("muestra_fecha"))
            End If
            If reader("muestra_comentario") IsNot DBNull.Value Then
                oReclamo.MuestraComentario = Convert.ToString(reader("muestra_comentario"))
            End If

            If reader("reqAprobProd") IsNot DBNull.Value Then
                oReclamo.RequiereAprobProd = Convert.ToBoolean(reader("reqAprobProd"))
            End If
            If reader("reqAprobLab") IsNot DBNull.Value Then
                oReclamo.RequiereAprobLab = Convert.ToBoolean(reader("reqAprobLab"))
            End If
            If reader("reqAprobCom") IsNot DBNull.Value Then
                oReclamo.RequiereAprobCom = Convert.ToBoolean(reader("reqAprobCom"))
            End If
            If reader("estado_comentado") IsNot DBNull.Value Then
                oReclamo.EstadoComentado = Convert.ToString(reader("estado_comentado"))
            End If

            'Estado del Reclamo
            If reader("producto") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.Producto = Convert.ToBoolean(reader("producto"))
            End If
            If reader("servicio") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.Servicio = Convert.ToBoolean(reader("servicio"))
            End If
            If reader("muestra") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.Muestra = Convert.ToBoolean(reader("muestra"))
            End If
            If reader("fec_reg_muestra") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.FechaMuestra = Convert.ToDateTime(reader("fec_reg_muestra"))
            End If
            If reader("evidencia") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.Evidencia = Convert.ToBoolean(reader("evidencia"))
            End If
            If reader("fec_reg_evidencia") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.FechaEvidencia = Convert.ToDateTime(reader("fec_reg_evidencia"))
            End If
            If reader("labinforme") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.InformeLab = Convert.ToBoolean(reader("labinforme"))
            End If
            If reader("labconforme") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.ConformidadLab = Convert.ToBoolean(reader("labconforme"))
            End If
            If reader("aprobprod") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.AprobProduccion = Convert.ToBoolean(reader("aprobprod"))
            End If
            If reader("aproblab") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.AprobLaboratorio = Convert.ToBoolean(reader("aproblab"))
            End If
            If reader("aprobger") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.AprobacionGerencial = Convert.ToBoolean(reader("aprobger"))
            End If
            If reader("aprobcom") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.AprobacionComercial = Convert.ToBoolean(reader("aprobcom"))
            End If
            If reader("reunion") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.Reunion = Convert.ToBoolean(reader("reunion"))
            End If
            If reader("analisis") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.AnalisisProblema = Convert.ToBoolean(reader("analisis"))
            End If
            If reader("planaccion") IsNot DBNull.Value Then
                oReclamo.ReclamoPermisos.PlanesAccion = Convert.ToBoolean(reader("planaccion"))
            End If
            If reader("pareto") IsNot DBNull.Value Then
                oReclamo.Pareto = Convert.ToString(reader("pareto"))
            End If
            If reader("tpreob") IsNot DBNull.Value Then
                oReclamo.Tpreob = Convert.ToString(reader("tpreob"))
            End If

            '------------------------------------------------------------------
            'Cambio agregado el 25/04/2024
            '------------------------------------------------------------------
            If reader IsNot Nothing AndAlso Not reader.IsClosed Then
                Dim schemaTable As DataTable = reader.GetSchemaTable()
                Dim campoExisteDM As Boolean = False
                Dim campoExisteDI As Boolean = False
                Dim campoExisteDP As Boolean = False
                Dim campoExisteDC As Boolean = False
                Dim campoExisteRC As Boolean = False

                ' Iterar sobre el esquema para verificar si el campo existe
                For Each row As DataRow In schemaTable.Rows
                    Dim columnName As String = row("ColumnName").ToString()
                    If columnName = "dias_muestra" Then
                        campoExisteDM = True
                        Exit For
                    End If
                Next

                For Each row As DataRow In schemaTable.Rows
                    Dim columnName As String = row("ColumnName").ToString()
                    If columnName = "dias_informe" Then
                        campoExisteDI = True
                        Exit For
                    End If
                Next

                For Each row As DataRow In schemaTable.Rows
                    Dim columnName As String = row("ColumnName").ToString()
                    If columnName = "dias_produccion" Then
                        campoExisteDP = True
                        Exit For
                    End If
                Next

                For Each row As DataRow In schemaTable.Rows
                    Dim columnName As String = row("ColumnName").ToString()
                    If columnName = "dias_comercial" Then
                        campoExisteDC = True
                        Exit For
                    End If
                Next

                For Each row As DataRow In schemaTable.Rows
                    Dim columnName As String = row("ColumnName").ToString()
                    If columnName = "RutaCorreo" Then
                        campoExisteRC = True
                        Exit For
                    End If
                Next

                ' Si el campo existe, acceder a él
                If campoExisteDM AndAlso Not reader.IsDBNull(reader.GetOrdinal("dias_muestra")) Then
                    oReclamo.dias_muestra = Convert.ToInt32(reader("dias_muestra"))
                End If

                If campoExisteDI AndAlso Not reader.IsDBNull(reader.GetOrdinal("dias_informe")) Then
                    oReclamo.dias_informe = Convert.ToString(reader("dias_informe"))
                End If

                If campoExisteDP AndAlso Not reader.IsDBNull(reader.GetOrdinal("dias_produccion")) Then
                    oReclamo.dias_produccion = Convert.ToString(reader("dias_produccion"))
                End If

                If campoExisteDC AndAlso Not reader.IsDBNull(reader.GetOrdinal("dias_comercial")) Then
                    oReclamo.dias_comercial = Convert.ToString(reader("dias_comercial"))
                End If

                If campoExisteRC AndAlso Not reader.IsDBNull(reader.GetOrdinal("RutaCorreo")) Then
                    oReclamo.RutaCorreo = Convert.ToString(reader("RutaCorreo"))
                End If

                If campoExisteRC AndAlso Not reader.IsDBNull(reader.GetOrdinal("nroncredito")) Then
                    oReclamo.NroNCredito = Convert.ToString(reader("nroncredito"))
                End If

            End If
            '------------------------------------------------------------------
            'If reader("dias_muestra") IsNot DBNull.Value Then
            'oReclamo.dias_muestra = Convert.ToInt32(reader("dias_muestra"))
            'End If
            'If reader("dias_informe") IsNot DBNull.Value Then
            'oReclamo.dias_informe = Convert.ToString(reader("dias_informe"))
            'End If
            'If reader("dias_produccion") IsNot DBNull.Value Then
            'oReclamo.dias_produccion = Convert.ToString(reader("dias_produccion"))
            'End If

            'If reader("dias_comercial") IsNot DBNull.Value Then
            'oReclamo.dias_comercial = Convert.ToString(reader("dias_comercial"))
            'End If

            'If reader("RutaCorreo") IsNot DBNull.Value Then
            'oReclamo.RutaCorreo = Convert.ToString(reader("RutaCorreo"))
            'End If

        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.OkOnly, MsgComacsa)
        End Try
        Return oReclamo
    End Function

    Public Function Reclamo_Seguimiento(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamos_seguimiento")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@dtmFechaInicio", DbType.DateTime, fechaInicio)
            db.AddInParameter(cmd, "@dtmFechaFin", DbType.DateTime, fechaFin)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Return Ds.Tables(0)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Reclamo_IndicadorLab(ByVal ayo As Integer, ByVal mes1 As Integer, ByVal mes2 As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("USP_ERP_RECLAMO_IND_LAB")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@AYO", DbType.Int32, ayo)
            db.AddInParameter(cmd, "@MES1", DbType.Int32, mes1)
            db.AddInParameter(cmd, "@MES2", DbType.Int32, mes2)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Return Ds.Tables(0)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ActualizarEstado(ByVal pReclamo As ETReclamo, ByVal User_Sistema As String) As ETResultado
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamo_actualizar_estado")
                db.AddInParameter(cmd, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmd, "@estado", DbType.String, pReclamo.Estado)
                db.AddInParameter(cmd, "@user", DbType.String, User_Sistema)

                db.ExecuteNonQuery(cmd, Trans)

                Trans.Commit()
                Conexion.Close()

                oResultado.Realizo = True

            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                oResultado.Mensaje = ex.Message
                MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using

        Return oResultado
    End Function

    Public Function RegistrarRechazoMuestra(ByVal pReclamo As ETReclamo, ByVal User_Sistema As String) As ETResultado
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamo_rechazo_muestras")
                db.AddInParameter(cmd, "@id_reclamo", DbType.Int32, pReclamo.Id)
                db.AddInParameter(cmd, "@user", DbType.String, User_Sistema)

                db.ExecuteNonQuery(cmd, Trans)

                Trans.Commit()
                Conexion.Close()

                oResultado.Realizo = True

            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                oResultado.Mensaje = ex.Message
                MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using

        Return oResultado
    End Function

    Public Function ObtenerEstadoReclamo(ByVal pReclamo As ETReclamo) As ETReclamoPermisos

        Dim item As ETReclamoPermisos = New ETReclamoPermisos

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamo_estado")
            db.AddInParameter(cmd, "@id_reclamo", DbType.Int32, pReclamo.Id)
            Using reader As IDataReader = db.ExecuteReader(cmd)

                While reader.Read()
                    If reader("producto") IsNot DBNull.Value Then
                        item.Producto = Convert.ToBoolean(reader("producto"))
                    End If
                    If reader("servicio") IsNot DBNull.Value Then
                        item.Servicio = Convert.ToBoolean(reader("servicio"))
                    End If
                    If reader("muestra") IsNot DBNull.Value Then
                        item.Muestra = Convert.ToBoolean(reader("muestra"))
                    End If
                    If reader("evidencia") IsNot DBNull.Value Then
                        item.Evidencia = Convert.ToBoolean(reader("evidencia"))
                    End If
                    If reader("labinforme") IsNot DBNull.Value Then
                        item.InformeLab = Convert.ToBoolean(reader("labinforme"))
                    End If
                    If reader("labconforme") IsNot DBNull.Value Then
                        item.ConformidadLab = Convert.ToBoolean(reader("labconforme"))
                    End If
                    If reader("aprobprod") IsNot DBNull.Value Then
                        item.AprobProduccion = Convert.ToBoolean(reader("aprobprod"))
                    End If
                    If reader("aproblab") IsNot DBNull.Value Then
                        item.AprobLaboratorio = Convert.ToBoolean(reader("aproblab"))
                    End If
                    If reader("aprobger") IsNot DBNull.Value Then
                        item.AprobacionGerencial = Convert.ToBoolean(reader("aprobger"))
                    End If
                    If reader("aprobcom") IsNot DBNull.Value Then
                        item.AprobacionComercial = Convert.ToBoolean(reader("aprobcom"))
                    End If
                    If reader("reunion") IsNot DBNull.Value Then
                        item.Reunion = Convert.ToBoolean(reader("reunion"))
                    End If
                    If reader("analisis") IsNot DBNull.Value Then
                        item.AnalisisProblema = Convert.ToBoolean(reader("analisis"))
                    End If
                    If reader("planaccion") IsNot DBNull.Value Then
                        item.PlanesAccion = Convert.ToBoolean(reader("planaccion"))
                    End If
                End While

                If reader IsNot Nothing Then reader.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return item
    End Function

    Public Function RegistrarFormato(ByVal pFormato As ETReclamoFormato) As ETResultado
        Dim oResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamo_formato_registrar")
                db.AddInParameter(cmd, "@id_reclamo", DbType.Int32, pFormato.id)
                db.AddInParameter(cmd, "@user", DbType.String, pFormato.user)
                db.AddInParameter(cmd, "@comentarios", DbType.String, pFormato.comentarios)
                If pFormato.fecha.HasValue Then
                    db.AddInParameter(cmd, "@fecha", DbType.DateTime, pFormato.fecha.Value)
                Else
                    db.AddInParameter(cmd, "@fecha", DbType.DateTime, DBNull.Value)
                End If

                db.ExecuteNonQuery(cmd, Trans)

                Dim cmdReg As DbCommand = Nothing

                cmdReg = db.GetStoredProcCommand("usp_reclamo_formato_planes")
                db.AddInParameter(cmdReg, "@id_reclamo", DbType.Int32, pFormato.id)
                db.AddInParameter(cmdReg, "@usuario", DbType.String, "")
                db.AddInParameter(cmdReg, "@planaccion", DbType.String, "")
                db.AddInParameter(cmdReg, "@opcion", DbType.Int32, 3)
                db.ExecuteNonQuery(cmdReg, Trans)

                For Each oPlanAccion As ETReclamoFormatoPlan In pFormato.ListaPlanes
                    cmdReg = db.GetStoredProcCommand("usp_reclamo_formato_planes")
                    db.AddInParameter(cmdReg, "@id_reclamo", DbType.Int32, pFormato.id)
                    db.AddInParameter(cmdReg, "@usuario", DbType.String, oPlanAccion.user)
                    db.AddInParameter(cmdReg, "@planaccion", DbType.String, oPlanAccion.acciones)
                    db.AddInParameter(cmdReg, "@opcion", DbType.Int32, 1)
                    db.ExecuteNonQuery(cmdReg, Trans)
                Next

                cmdReg = db.GetStoredProcCommand("usp_reclamo_formato_comentarios")
                db.AddInParameter(cmdReg, "@id_reclamo", DbType.Int32, pFormato.id)
                db.AddInParameter(cmdReg, "@usuario", DbType.String, "")
                db.AddInParameter(cmdReg, "@comentarios", DbType.String, "")
                db.AddInParameter(cmdReg, "@estado", DbType.String, "")
                db.AddInParameter(cmdReg, "@opcion", DbType.Int32, 3)
                db.ExecuteNonQuery(cmdReg, Trans)

                For Each oComentario As ETReclamoFormatoComentarios In pFormato.ListaComentarios
                    cmdReg = db.GetStoredProcCommand("usp_reclamo_formato_comentarios")
                    db.AddInParameter(cmdReg, "@id_reclamo", DbType.Int32, pFormato.id)
                    db.AddInParameter(cmdReg, "@usuario", DbType.String, oComentario.user)
                    db.AddInParameter(cmdReg, "@comentarios", DbType.String, oComentario.comentarios)
                    db.AddInParameter(cmdReg, "@estado", DbType.String, oComentario.estado)
                    db.AddInParameter(cmdReg, "@opcion", DbType.Int32, 1)
                    db.ExecuteNonQuery(cmdReg, Trans)
                Next

                Trans.Commit()
                Conexion.Close()

                oResultado.Realizo = True

            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                oResultado.Mensaje = ex.Message
                MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try

        End Using

        Return oResultado
    End Function

    Public Function ObtenerFormato(ByVal pFormato As ETReclamoFormato) As ETReclamoFormato
        Dim item As New ETReclamoFormato

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamo_ver_formato_cliente")
            db.AddInParameter(cmd, "@id_reclamo", DbType.String, pFormato.id)
            Using reader As IDataReader = db.ExecuteReader(cmd)

                If reader.Read() Then

                    If reader("id_reclamo") IsNot DBNull.Value Then
                        item.id = Convert.ToInt32(reader("id_reclamo"))
                    End If
                    If reader("comentarios") IsNot DBNull.Value Then
                        item.comentarios = Convert.ToString(reader("comentarios"))
                    End If
                    If reader("user_aprob") IsNot DBNull.Value Then
                        item.user = Convert.ToString(reader("user_aprob"))
                    End If
                    If reader("fec_aprob") IsNot DBNull.Value Then
                        item.fecha = Convert.ToDateTime(reader("fec_aprob"))
                    End If
                End If

                Dim oComentario As ETReclamoFormatoComentarios

                If reader.NextResult() Then
                    While reader.Read()
                        oComentario = New ETReclamoFormatoComentarios()

                        If reader("id_reclamo_det") IsNot DBNull.Value Then
                            oComentario.iddet = Convert.ToInt32(reader("id_reclamo_det"))
                        End If
                        If reader("id_reclamo") IsNot DBNull.Value Then
                            oComentario.id = Convert.ToInt32(reader("id_reclamo"))
                        End If
                        If reader("comentarios") IsNot DBNull.Value Then
                            oComentario.comentarios = Convert.ToString(reader("comentarios"))
                        End If
                        If reader("usuario") IsNot DBNull.Value Then
                            oComentario.user = Convert.ToString(reader("usuario"))
                        End If
                        If reader("estado") IsNot DBNull.Value Then
                            oComentario.estado = Convert.ToString(reader("estado"))
                        End If

                        item.ListaComentarios.Add(oComentario)
                    End While
                End If
                Dim oPlan As ETReclamoFormatoPlan

                If reader.NextResult() Then
                    While reader.Read()
                        oPlan = New ETReclamoFormatoPlan()

                        If reader("id_reclamo_det") IsNot DBNull.Value Then
                            oPlan.iddet = Convert.ToInt32(reader("id_reclamo_det"))
                        End If
                        If reader("id_reclamo") IsNot DBNull.Value Then
                            oPlan.id = Convert.ToInt32(reader("id_reclamo"))
                        End If
                        If reader("planaccion") IsNot DBNull.Value Then
                            oPlan.acciones = Convert.ToString(reader("planaccion"))
                        End If
                        If reader("usuario") IsNot DBNull.Value Then
                            oPlan.user = Convert.ToString(reader("usuario"))
                        End If

                        item.ListaPlanes.Add(oPlan)
                    End While
                End If
                If reader IsNot Nothing Then reader.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return item
    End Function

    Public Function ObtenerClientePorCodigo(ByVal CodCia As String, ByVal CodCliente As String) As ETCliente
        Dim oCliente As New ETCliente

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamos_cliente_buscar")
            db.AddInParameter(cmd, "@CIA", DbType.String, CodCia)
            db.AddInParameter(cmd, "@COD_CLI", DbType.String, CodCliente)

            Using reader As IDataReader = db.ExecuteReader(cmd)

                While reader.Read()
                    If reader("COD_CLI") IsNot DBNull.Value Then
                        oCliente.CodCliente = Convert.ToString(reader("COD_CLI"))
                    End If
                    If reader("CLIENTE") IsNot DBNull.Value Then
                        oCliente.DesCliente = Convert.ToString(reader("CLIENTE"))
                    End If
                    If reader("RUC") IsNot DBNull.Value Then
                        oCliente.RUC = Convert.ToString(reader("RUC"))
                    End If

                End While

                If reader IsNot Nothing Then reader.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return oCliente
    End Function




    Public Function ObtenerCorreoPorNombre(ByVal CodCia As String, ByVal ResponsableVenta As String) As ETResponsableVenta
        Dim oResponsableVenta As New ETResponsableVenta

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Try

            Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamos_ResposableVenta_buscar")
            db.AddInParameter(cmd, "@Cia", DbType.String, CodCia)
            db.AddInParameter(cmd, "@Persona", DbType.String, ResponsableVenta)

            Using reader As IDataReader = db.ExecuteReader(cmd)

                While reader.Read()
                    If reader("Codigo") IsNot DBNull.Value Then
                        oResponsableVenta.Codigo = Convert.ToString(reader("Codigo"))
                    End If
                    If reader("Persona") IsNot DBNull.Value Then
                        oResponsableVenta.Nombre = Convert.ToString(reader("Persona"))
                    End If
                    If reader("Correo") IsNot DBNull.Value Then
                        oResponsableVenta.Correo = Convert.ToString(reader("Correo"))
                    End If
                End While

                If reader IsNot Nothing Then reader.Close()

            End Using

        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return oResponsableVenta

    End Function

    Public Function ObtenerRol(ByVal User_Sistema As String) As String

        Dim r As String = ""
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand("usp_reclamo_obtener_rol")
            db.AddInParameter(cmd, "@usuario", DbType.String, User_Sistema)
            db.AddOutParameter(cmd, "@rol", DbType.String, 50)

            db.ExecuteNonQuery(cmd)

            r = Convert.ToString(db.GetParameterValue(cmd, "@rol"))

        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return r
    End Function

    Public Function CorreoEjecutivo(ByVal codcli As String, ByVal tipo As String, ByVal pareto As String, ByVal usuario As String) As List(Of ETReclamoPersona)
        Dim lista As New List(Of ETReclamoPersona)
        Dim item As ETReclamoPersona = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand("usp_erp_correo_vend_cliente")
            db.AddInParameter(cmd, "@cod_cli", DbType.String, codcli)
            db.AddInParameter(cmd, "@tipo", DbType.String, tipo)
            db.AddInParameter(cmd, "@usuario", DbType.String, usuario)

            Using reader As IDataReader = db.ExecuteReader(cmd)

                While reader.Read()
                    item = New ETReclamoPersona
                    If reader("persona") IsNot DBNull.Value Then
                        item.Nombre = reader("persona").ToString()
                    End If
                    If reader("correo") IsNot DBNull.Value Then
                        item.Correo = reader("correo").ToString()
                    End If
                    lista.Add(item)
                End While

                If reader IsNot Nothing Then reader.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return lista

        'Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim cmd As DbCommand = db.GetStoredProcCommand("usp_erp_correo_vend_cliente")
        'Dim Tabla As DataTable = Nothing
        'Dim Ds As DataSet = Nothing

        'Try
        '    db.AddInParameter(cmd, "@cod_cli", DbType.String, codcli)
        '    Ds = New DataSet
        '    Ds = db.ExecuteDataSet(cmd)

        '    Return Ds.Tables(0)

        'Catch Err As Exception
        '    MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        '    Return Nothing
        'End Try
    End Function

End Class

