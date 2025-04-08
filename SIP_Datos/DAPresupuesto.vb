Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports SIP_Entidad
Imports System.Data.Common
Imports System.Globalization
Imports System.Configuration

Public Class DAPresupuesto
    Public Function Mantenedor_Presupuesto(ByVal Ent_Presp As ETPresupuesto, _
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
        If Ent_Presp Is Nothing Then Return Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto)
                db.AddInParameter(cmd, "PresupuestoID", DbType.Int32, Ent_Presp.Presupuesto)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Area", DbType.String, Ent_Presp.Cod_Area)
                db.AddInParameter(cmd, "Cod_Presupuesto", DbType.Int32, Val(Ent_Presp.Cod_Presup))
                db.AddInParameter(cmd, "Fecha", DbType.Date, Ent_Presp.Fecha)
                db.AddInParameter(cmd, "EncargadoArea", DbType.String, Ent_Presp.Cod_EncargadoArea)
                db.AddInParameter(cmd, "Cliente", DbType.String, Ent_Presp.Cod_Cli)
                db.AddInParameter(cmd, "ClienteInterno", DbType.String, Ent_Presp.Cod_ClienteInt)
                db.AddInParameter(cmd, "AreaInterna", DbType.String, Ent_Presp.Cod_AreaInt)
                db.AddInParameter(cmd, "Equipo", DbType.Int32, Ent_Presp.EquipoID)
                db.AddInParameter(cmd, "TipoProceso", DbType.String, Ent_Presp.TipoProceso)
                db.AddInParameter(cmd, "AtributoControl", DbType.Int32, Ent_Presp.AtributoControl)
                db.AddInParameter(cmd, "ValorControl", DbType.String, Ent_Presp.ValorControl)
                db.AddInParameter(cmd, "Prioridad", DbType.String, Ent_Presp.Cod_Prioridad)
                db.AddInParameter(cmd, "Moneda", DbType.String, Ent_Presp.Moneda)
                db.AddInParameter(cmd, "Total", DbType.Double, Ent_Presp.Total)
                db.AddInParameter(cmd, "FechaInicio", DbType.Date, Ent_Presp.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.Date, Ent_Presp.FechaTerminacion)
                db.AddInParameter(cmd, "TipoCambio", DbType.Double, Ent_Presp.TipoCambio)
                db.AddInParameter(cmd, "status", DbType.String, Ent_Presp.Status)
                db.AddInParameter(cmd, "User", DbType.String, Ent_Presp.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.Int16, Ent_Presp.Tipo)
                lResult = New ETPresupuesto
                If Ent_Presp.Tipo = 1 Then
                    Using dr As IDataReader = db.ExecuteReader(cmd, Trans)
                        While dr.Read
                            lResult.Presupuesto = dr.GetInt32(dr.GetOrdinal("Presupuesto"))
                            lResult.Cod_Presup = dr.GetString(dr.GetOrdinal("Cod_Presup"))
                        End While
                        If dr IsNot Nothing Then dr.Close()
                    End Using
                Else
                    db.ExecuteNonQuery(cmd, Trans)
                    lResult.Presupuesto = Ent_Presp.Presupuesto
                    lResult.Cod_Presup = Ent_Presp.Cod_Presup
                End If

                '****************************************************************
                'Detalle Presupuesto
                '****************************************************************
                'Anulando Detalle
                For Each Row As ETPresupuestoDetalle In Ls_PresItem_Del
                    Dim xmd_Del As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_PresupuestoDetalle)
                    db.AddInParameter(xmd_Del, "DetallePresupuestoID", DbType.Int32, Row.PresupuestoDet)
                    db.AddInParameter(xmd_Del, "PresupuestoID", DbType.Int32, Row.Presupuesto)
                    db.AddInParameter(xmd_Del, "Item", DbType.Int16, Row.Item)
                    db.AddInParameter(xmd_Del, "Partida", DbType.Int32, Row.Partida)
                    db.AddInParameter(xmd_Del, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(xmd_Del, "Descripcion", DbType.String, Row.Descripcion)
                    db.AddInParameter(xmd_Del, "UnidadMedida", DbType.String, Row.Cod_UniMed)
                    db.AddInParameter(xmd_Del, "Metrado", DbType.Double, Row.Metrado)
                    db.AddInParameter(xmd_Del, "Precio", DbType.Double, Row.Precio)
                    db.AddInParameter(xmd_Del, "Parcial", DbType.Double, Row.Parcial)
                    db.AddInParameter(xmd_Del, "TipoCambio", DbType.Double, Row.TipoCambio)
                    db.AddInParameter(xmd_Del, "FechaInicio", DbType.Date, Row.FechaInicio)
                    db.AddInParameter(xmd_Del, "FechaTermino", DbType.Date, Row.FechaTerminacion)
                    db.AddInParameter(xmd_Del, "TipoFactor", DbType.String, Row.TipoFactor)
                    db.AddInParameter(xmd_Del, "Factor", DbType.Double, Row.Factor)
                    db.AddInParameter(xmd_Del, "Jornada", DbType.Double, Row.Jornada)
                    db.AddInParameter(xmd_Del, "status", DbType.String, Row.Status)
                    db.AddInParameter(xmd_Del, "User", DbType.String, Row.Usuario)
                    db.AddInParameter(xmd_Del, "Tipo", DbType.String, Row.Tipo)
                    db.ExecuteNonQuery(xmd_Del, Trans)
                Next

                ' Grabando Presupuesto Detalle
                For Each Row As ETPresupuestoDetalle In Ls_PresItem
                    Dim xmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_PresupuestoDetalle)
                    db.AddInParameter(xmd, "DetallePresupuestoID", DbType.Int32, Row.PresupuestoDet)
                    db.AddInParameter(xmd, "PresupuestoID", DbType.Int32, Row.Presupuesto)
                    db.AddInParameter(xmd, "Item", DbType.Int16, Val(Row.Item))
                    db.AddInParameter(xmd, "Partida", DbType.Int32, Row.Partida)
                    db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(xmd, "Descripcion", DbType.String, Row.Descripcion)
                    db.AddInParameter(xmd, "UnidadMedida", DbType.String, Row.Cod_UniMed)
                    db.AddInParameter(xmd, "Metrado", DbType.Double, Row.Metrado)
                    db.AddInParameter(xmd, "Precio", DbType.Double, Row.Precio)
                    db.AddInParameter(xmd, "Parcial", DbType.Double, Row.Parcial)
                    db.AddInParameter(xmd, "TipoCambio", DbType.Double, Row.TipoCambio)
                    db.AddInParameter(xmd, "FechaInicio", DbType.Date, Row.FechaInicio)
                    db.AddInParameter(xmd, "FechaTermino", DbType.Date, Row.FechaTerminacion)
                    db.AddInParameter(xmd, "TipoFactor", DbType.String, Row.TipoFactor)
                    db.AddInParameter(xmd, "Factor", DbType.Double, Row.Factor)
                    db.AddInParameter(xmd, "Jornada", DbType.Double, Row.Jornada)
                    db.AddInParameter(xmd, "status", DbType.String, Row.Status)
                    db.AddInParameter(xmd, "User", DbType.String, Row.Usuario)
                    db.AddInParameter(xmd, "Tipo", DbType.String, Row.Tipo)
                    db.ExecuteNonQuery(xmd, Trans)
                Next

                If Ent_Presp.Tipo = 2 Then
                    For Each Ent_Material As ETPresupuestoMaterial In Ls_Material_Del
                        Dim mdxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Material)
                        db.AddInParameter(mdxmd, "DetallePresupuestoID", DbType.Int32, Ent_Material.Presupuesto)
                        db.AddInParameter(mdxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(mdxmd, "Material", DbType.String, Ent_Material.Cod_Mat)
                        db.AddInParameter(mdxmd, "UnidadMedida", DbType.String, Ent_Material.Cod_UniMed)
                        db.AddInParameter(mdxmd, "Cantidad", DbType.Double, Ent_Material.Cantidad)
                        db.AddInParameter(mdxmd, "Precio", DbType.Double, Ent_Material.Precio)
                        db.AddInParameter(mdxmd, "SubTotal", DbType.Double, Ent_Material.SubTotal)
                        db.AddInParameter(mdxmd, "Nro_OC", DbType.String, Ent_Material.Nro_OC)
                        db.AddInParameter(mdxmd, "status", DbType.String, Ent_Material.Status)
                        db.AddInParameter(mdxmd, "User", DbType.String, Ent_Material.Usuario)
                        db.AddInParameter(mdxmd, "Material_Ant", DbType.String, Ent_Material.Material_Ant)
                        db.AddInParameter(mdxmd, "Tipo", DbType.String, Ent_Material.Tipo.ToString)
                        db.ExecuteNonQuery(mdxmd, Trans)
                    Next
                    For Each Ent_Material As ETPresupuestoMaterial In Ls_Material
                        Dim mxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Material)
                        db.AddInParameter(mxmd, "DetallePresupuestoID", DbType.Int32, Ent_Material.Presupuesto)
                        db.AddInParameter(mxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(mxmd, "Material", DbType.String, Ent_Material.Cod_Mat)
                        db.AddInParameter(mxmd, "UnidadMedida", DbType.String, Ent_Material.Cod_UniMed)
                        db.AddInParameter(mxmd, "Cantidad", DbType.Double, Ent_Material.Cantidad)
                        db.AddInParameter(mxmd, "Precio", DbType.Double, Ent_Material.Precio)
                        db.AddInParameter(mxmd, "SubTotal", DbType.Double, Ent_Material.SubTotal)
                        db.AddInParameter(mxmd, "Nro_OC", DbType.String, Ent_Material.Nro_OC)
                        db.AddInParameter(mxmd, "status", DbType.String, Ent_Material.Status)
                        db.AddInParameter(mxmd, "User", DbType.String, Ent_Material.Usuario)
                        db.AddInParameter(mxmd, "Material_Ant", DbType.String, Ent_Material.Material_Ant)
                        db.AddInParameter(mxmd, "Tipo", DbType.String, Ent_Material.Tipo.ToString)
                        db.ExecuteNonQuery(mxmd, Trans)
                    Next

                    For Each Ent_Equipo As ETPresupuestoEquipo In Ls_Equipo_Del
                        Dim edxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Equipo)
                        db.AddInParameter(edxmd, "DetallePresupuestoID", DbType.Int32, Ent_Equipo.Presupuesto)
                        db.AddInParameter(edxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(edxmd, "Equipo", DbType.Int32, Ent_Equipo.Equipo)
                        db.AddInParameter(edxmd, "UnidadMedida", DbType.String, Ent_Equipo.Cod_UniMed)
                        db.AddInParameter(edxmd, "Cuadrilla", DbType.Int32, Ent_Equipo.Cuadrilla)
                        db.AddInParameter(edxmd, "Cantidad", DbType.Double, Ent_Equipo.Cantidad)
                        db.AddInParameter(edxmd, "Precio", DbType.Double, Ent_Equipo.Precio)
                        db.AddInParameter(edxmd, "SubTotal", DbType.Double, Ent_Equipo.SubTotal)
                        db.AddInParameter(edxmd, "status", DbType.String, Ent_Equipo.Status)
                        db.AddInParameter(edxmd, "User", DbType.String, Ent_Equipo.Usuario)
                        db.AddInParameter(edxmd, "Equipo_Ant", DbType.Int32, Ent_Equipo.Equipo_Ant)
                        db.AddInParameter(edxmd, "Tipo", DbType.String, Ent_Equipo.Tipo.ToString)
                        db.ExecuteNonQuery(edxmd, Trans)
                    Next
                    For Each Ent_Equipo As ETPresupuestoEquipo In Ls_Equipo
                        Dim exmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Equipo)
                        db.AddInParameter(exmd, "DetallePresupuestoID", DbType.Int32, Ent_Equipo.Presupuesto)
                        db.AddInParameter(exmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(exmd, "Equipo", DbType.Int32, Ent_Equipo.EquipoID)
                        db.AddInParameter(exmd, "UnidadMedida", DbType.String, Ent_Equipo.Cod_UniMed)
                        db.AddInParameter(exmd, "Cuadrilla", DbType.Int32, Ent_Equipo.Cuadrilla)
                        db.AddInParameter(exmd, "Cantidad", DbType.Double, Ent_Equipo.Cantidad)
                        db.AddInParameter(exmd, "Precio", DbType.Double, Ent_Equipo.Precio)
                        db.AddInParameter(exmd, "SubTotal", DbType.Double, Ent_Equipo.SubTotal)
                        db.AddInParameter(exmd, "status", DbType.String, Ent_Equipo.Status)
                        db.AddInParameter(exmd, "User", DbType.String, Ent_Equipo.Usuario)
                        db.AddInParameter(exmd, "Equipo_Ant", DbType.Int32, Ent_Equipo.Equipo_Ant)
                        db.AddInParameter(exmd, "Tipo", DbType.String, Ent_Equipo.Tipo.ToString)
                        db.ExecuteNonQuery(exmd, Trans)
                    Next

                    For Each Ent_ManoObra As ETPresupuestoManoObra In Ls_ManoObra_Del
                        Dim cdxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_ManoObra)
                        db.AddInParameter(cdxmd, "DetallePresupuestoID", DbType.Int32, Ent_ManoObra.Presupuesto)
                        db.AddInParameter(cdxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(cdxmd, "Cargo", DbType.String, Ent_ManoObra.Cod_Cargo)
                        db.AddInParameter(cdxmd, "UnidadMedida", DbType.String, Ent_ManoObra.Cod_UniMed)
                        db.AddInParameter(cdxmd, "Cuadrilla", DbType.String, Ent_ManoObra.Cuadrilla)
                        db.AddInParameter(cdxmd, "Cantidad", DbType.Double, Ent_ManoObra.Cantidad)
                        db.AddInParameter(cdxmd, "Precio", DbType.Double, Ent_ManoObra.Precio)
                        db.AddInParameter(cdxmd, "SubTotal", DbType.Double, Ent_ManoObra.SubTotal)
                        db.AddInParameter(cdxmd, "status", DbType.String, Ent_ManoObra.Status)
                        db.AddInParameter(cdxmd, "User", DbType.String, Ent_ManoObra.Usuario)
                        db.AddInParameter(cdxmd, "Cargo_Ant", DbType.String, Ent_ManoObra.Cargo_Ant)
                        db.AddInParameter(cdxmd, "Tipo", DbType.String, Ent_ManoObra.Tipo.ToString)
                        db.ExecuteNonQuery(cdxmd, Trans)
                    Next
                    For Each Ent_ManoObra As ETPresupuestoManoObra In Ls_ManoObra
                        Dim cxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_ManoObra)
                        db.AddInParameter(cxmd, "DetallePresupuestoID", DbType.Int32, Ent_ManoObra.Presupuesto)
                        db.AddInParameter(cxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(cxmd, "Cargo", DbType.String, Ent_ManoObra.Cod_Cargo)
                        db.AddInParameter(cxmd, "UnidadMedida", DbType.String, Ent_ManoObra.Cod_UniMed)
                        db.AddInParameter(cxmd, "Cuadrilla", DbType.String, Ent_ManoObra.Cuadrilla)
                        db.AddInParameter(cxmd, "Cantidad", DbType.Double, Ent_ManoObra.Cantidad)
                        db.AddInParameter(cxmd, "Precio", DbType.Double, Ent_ManoObra.Precio)
                        db.AddInParameter(cxmd, "SubTotal", DbType.Double, Ent_ManoObra.SubTotal)
                        db.AddInParameter(cxmd, "status", DbType.String, Ent_ManoObra.Status)
                        db.AddInParameter(cxmd, "User", DbType.String, Ent_ManoObra.Usuario)
                        db.AddInParameter(cxmd, "Cargo_Ant", DbType.String, Ent_ManoObra.Cargo_Ant)
                        db.AddInParameter(cxmd, "Tipo", DbType.String, Ent_ManoObra.Tipo.ToString)
                        db.ExecuteNonQuery(cxmd, Trans)
                    Next

                    For Each Ent_Servicio As ETPresupuestoServicio In Ls_Servicio_Del
                        Dim sdxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Servicio)
                        db.AddInParameter(sdxmd, "DetallePresupuestoID", DbType.Int32, Ent_Servicio.Presupuesto)
                        db.AddInParameter(sdxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(sdxmd, "Servicio", DbType.String, Ent_Servicio.Cod_Ser)
                        db.AddInParameter(sdxmd, "UnidadMedida", DbType.String, Ent_Servicio.Cod_UniMed)
                        db.AddInParameter(sdxmd, "Cantidad", DbType.Double, Ent_Servicio.Cantidad)
                        db.AddInParameter(sdxmd, "Precio", DbType.Double, Ent_Servicio.Precio)
                        db.AddInParameter(sdxmd, "SubTotal", DbType.Double, Ent_Servicio.SubTotal)
                        db.AddInParameter(sdxmd, "Nro_OC", DbType.String, Ent_Servicio.Nro_OC)
                        db.AddInParameter(sdxmd, "status", DbType.String, Ent_Servicio.Status)
                        db.AddInParameter(sdxmd, "User", DbType.String, Ent_Servicio.Usuario)
                        db.AddInParameter(sdxmd, "Servicio_Ant", DbType.String, Ent_Servicio.Servicio_Ant)
                        db.AddInParameter(sdxmd, "Tipo", DbType.String, Ent_Servicio.Tipo.ToString)
                        db.ExecuteNonQuery(sdxmd, Trans)
                    Next
                    For Each Ent_Servicio As ETPresupuestoServicio In Ls_Servicio
                        Dim sxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Servicio)
                        db.AddInParameter(sxmd, "DetallePresupuestoID", DbType.Int32, Ent_Servicio.Presupuesto)
                        db.AddInParameter(sxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(sxmd, "Servicio", DbType.String, Ent_Servicio.Cod_Ser)
                        db.AddInParameter(sxmd, "UnidadMedida", DbType.String, Ent_Servicio.Cod_UniMed)
                        db.AddInParameter(sxmd, "Cantidad", DbType.Double, Ent_Servicio.Cantidad)
                        db.AddInParameter(sxmd, "Precio", DbType.Double, Ent_Servicio.Precio)
                        db.AddInParameter(sxmd, "SubTotal", DbType.Double, Ent_Servicio.SubTotal)
                        db.AddInParameter(sxmd, "Nro_OC", DbType.String, Ent_Servicio.Nro_OC)
                        db.AddInParameter(sxmd, "status", DbType.String, Ent_Servicio.Status)
                        db.AddInParameter(sxmd, "User", DbType.String, Ent_Servicio.Usuario)
                        db.AddInParameter(sxmd, "Servicio_Ant", DbType.String, Ent_Servicio.Servicio_Ant)
                        db.AddInParameter(sxmd, "Tipo", DbType.String, Ent_Servicio.Tipo.ToString)
                        db.ExecuteNonQuery(sxmd, Trans)
                    Next
                    'Planificar Item en Periodos
                    For Each Ent_Plan As ETPresupuestoPlan In Ls_Plan_Del
                        Dim pdxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan)
                        db.AddInParameter(pdxmd, "PresupuestoPlanID", DbType.UInt32, Ent_Plan.PlanID)
                        db.AddInParameter(pdxmd, "DetallePresupuestoID", DbType.UInt32, Ent_Plan.PresupuestoDet)
                        db.AddInParameter(pdxmd, "Codigo", DbType.UInt16, Ent_Plan.Item)
                        db.AddInParameter(pdxmd, "Periodo", DbType.String, Ent_Plan.Periodo)
                        db.AddInParameter(pdxmd, "FechaInicio", DbType.Date, Ent_Plan.FechaInicio)
                        db.AddInParameter(pdxmd, "FechaTermino", DbType.Date, Ent_Plan.FechaTerminacion)
                        db.AddInParameter(pdxmd, "Porcentaje", DbType.Double, Ent_Plan.Porcentaje)
                        db.AddInParameter(pdxmd, "status", DbType.String, Ent_Plan.Status)
                        db.AddInParameter(pdxmd, "User", DbType.String, Ent_Plan.Usuario)
                        db.AddInParameter(pdxmd, "Tipo", DbType.String, Ent_Plan.Tipo.ToString)
                        db.ExecuteNonQuery(pdxmd, Trans)
                    Next

                    For Each Ent_Plan As ETPresupuestoPlan In Ls_Plan
                        Dim pxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan)
                        db.AddInParameter(pxmd, "PresupuestoPlanID", DbType.Int32, Ent_Plan.PlanID)
                        db.AddInParameter(pxmd, "DetallePresupuestoID", DbType.Int32, Ent_Plan.PresupuestoDet)
                        db.AddInParameter(pxmd, "Codigo", DbType.Int16, Ent_Plan.Item)
                        db.AddInParameter(pxmd, "Periodo", DbType.String, Ent_Plan.Periodo)
                        db.AddInParameter(pxmd, "FechaInicio", DbType.Date, Ent_Plan.FechaInicio)
                        db.AddInParameter(pxmd, "FechaTermino", DbType.Date, Ent_Plan.FechaTerminacion)
                        db.AddInParameter(pxmd, "Porcentaje", DbType.Double, Ent_Plan.Porcentaje)
                        db.AddInParameter(pxmd, "status", DbType.String, Ent_Plan.Status)
                        db.AddInParameter(pxmd, "User", DbType.String, Ent_Plan.Usuario)
                        db.AddInParameter(pxmd, "Tipo", DbType.String, Ent_Plan.Tipo.ToString)
                        db.ExecuteNonQuery(pxmd, Trans)
                    Next

                    'Planificar Recursos 
                    For Each Ent_PlanMat As ETPresupuestoPlanRecursos In Ls_Plan_Material
                        Dim pmxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_Material)
                        db.AddInParameter(pmxmd, "PresupPlanMaterial", DbType.Int32, Ent_PlanMat.PlanRecurso)
                        db.AddInParameter(pmxmd, "PresupuestoPlanID", DbType.Int32, Ent_PlanMat.PresupuestoPlan)
                        db.AddInParameter(pmxmd, "DetallePresupuestoID", DbType.Int32, Ent_PlanMat.PresupuestoDet)
                        db.AddInParameter(pmxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(pmxmd, "Material", DbType.String, Ent_PlanMat.Codigo)
                        db.AddInParameter(pmxmd, "Fecha", DbType.Date, Ent_PlanMat.Fecha)
                        db.AddInParameter(pmxmd, "FechaInicio", DbType.Date, Ent_PlanMat.FechaInicio)
                        db.AddInParameter(pmxmd, "FechaTermino", DbType.Date, Ent_PlanMat.FechaTerminacion)
                        db.AddInParameter(pmxmd, "Cantidad", DbType.Double, Ent_PlanMat.Cantidad)
                        db.AddInParameter(pmxmd, "status", DbType.String, Ent_PlanMat.Status)
                        db.AddInParameter(pmxmd, "User", DbType.String, Ent_PlanMat.Usuario)
                        db.AddInParameter(pmxmd, "Tipo", DbType.String, Ent_PlanMat.Tipo.ToString)
                        db.ExecuteNonQuery(pmxmd, Trans)
                    Next

                    For Each Ent_PlanEq As ETPresupuestoPlanRecursos In Ls_Plan_Equipo
                        Dim pexmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_Equipo)
                        db.AddInParameter(pexmd, "PresupPlanEquipo", DbType.Int32, Ent_PlanEq.PlanRecurso)
                        db.AddInParameter(pexmd, "PresupuestoPlanID", DbType.Int32, Ent_PlanEq.PresupuestoPlan)
                        db.AddInParameter(pexmd, "DetallePresupuestoID", DbType.Int32, Ent_PlanEq.PresupuestoDet)
                        db.AddInParameter(pexmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(pexmd, "FamiliaEquipo", DbType.Int32, Ent_PlanEq.Recurso)
                        db.AddInParameter(pexmd, "Fecha", DbType.Date, Ent_PlanEq.Fecha)
                        db.AddInParameter(pexmd, "FechaInicio", DbType.Date, Ent_PlanEq.FechaInicio)
                        db.AddInParameter(pexmd, "FechaTermino", DbType.Date, Ent_PlanEq.FechaTerminacion)
                        db.AddInParameter(pexmd, "Cantidad", DbType.Double, Ent_PlanEq.Cantidad)
                        db.AddInParameter(pexmd, "status", DbType.String, Ent_PlanEq.Status)
                        db.AddInParameter(pexmd, "User", DbType.String, Ent_PlanEq.Usuario)
                        db.AddInParameter(pexmd, "Tipo", DbType.String, Ent_PlanEq.Tipo.ToString)
                        db.ExecuteNonQuery(pexmd, Trans)
                    Next

                    For Each Ent_PlanMO As ETPresupuestoPlanRecursos In Ls_Plan_ManoObra
                        Dim pmoxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_ManoObra)
                        db.AddInParameter(pmoxmd, "PresupPlanManoObra", DbType.Int32, Ent_PlanMO.PlanRecurso)
                        db.AddInParameter(pmoxmd, "PresupuestoPlanID", DbType.Int32, Ent_PlanMO.PresupuestoPlan)
                        db.AddInParameter(pmoxmd, "DetallePresupuestoID", DbType.Int32, Ent_PlanMO.PresupuestoDet)
                        db.AddInParameter(pmoxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(pmoxmd, "Cargo", DbType.String, Ent_PlanMO.Codigo)
                        db.AddInParameter(pmoxmd, "Fecha", DbType.Date, Ent_PlanMO.Fecha)
                        db.AddInParameter(pmoxmd, "FechaInicio", DbType.Date, Ent_PlanMO.FechaInicio)
                        db.AddInParameter(pmoxmd, "FechaTermino", DbType.Date, Ent_PlanMO.FechaTerminacion)
                        db.AddInParameter(pmoxmd, "Cantidad", DbType.Double, Ent_PlanMO.Cantidad)
                        db.AddInParameter(pmoxmd, "status", DbType.String, Ent_PlanMO.Status)
                        db.AddInParameter(pmoxmd, "User", DbType.String, Ent_PlanMO.Usuario)
                        db.AddInParameter(pmoxmd, "Tipo", DbType.String, Ent_PlanMO.Tipo.ToString)
                        db.ExecuteNonQuery(pmoxmd, Trans)
                    Next

                    For Each Ent_PlanSer As ETPresupuestoPlanRecursos In Ls_Plan_Servicio
                        Dim psxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_Servicio)
                        db.AddInParameter(psxmd, "PresupPlanServicio", DbType.Int32, Ent_PlanSer.PlanRecurso)
                        db.AddInParameter(psxmd, "PresupuestoPlanID", DbType.Int32, Ent_PlanSer.PresupuestoPlan)
                        db.AddInParameter(psxmd, "DetallePresupuestoID", DbType.Int32, Ent_PlanSer.PresupuestoDet)
                        db.AddInParameter(psxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(psxmd, "Servicio", DbType.String, Ent_PlanSer.Codigo)
                        db.AddInParameter(psxmd, "Fecha", DbType.Date, Ent_PlanSer.Fecha)
                        db.AddInParameter(psxmd, "FechaInicio", DbType.Date, Ent_PlanSer.FechaInicio)
                        db.AddInParameter(psxmd, "FechaTermino", DbType.Date, Ent_PlanSer.FechaTerminacion)
                        db.AddInParameter(psxmd, "Cantidad", DbType.Double, Ent_PlanSer.Cantidad)
                        db.AddInParameter(psxmd, "status", DbType.String, Ent_PlanSer.Status)
                        db.AddInParameter(psxmd, "User", DbType.String, Ent_PlanSer.Usuario)
                        db.AddInParameter(psxmd, "Tipo", DbType.String, Ent_PlanSer.Tipo.ToString)
                        db.ExecuteNonQuery(psxmd, Trans)
                    Next

                    ' Asignar Recursos
                    For Each Ent_PlanEq_Asig_Del As ETPresupuestoPlanRecursosAsignacion In Ls_Plan_Equipo_Asig_Del
                        Dim peaxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_Equipo_Asignacion)
                        db.AddInParameter(peaxmd, "PresupPlanEqAsig", DbType.Int32, Ent_PlanEq_Asig_Del.PlanRecursoAsignacion)
                        db.AddInParameter(peaxmd, "PresupPlanEquipo", DbType.Int32, Ent_PlanEq_Asig_Del.PlanRecurso)
                        db.AddInParameter(peaxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(peaxmd, "Equipo", DbType.Int32, Ent_PlanEq_Asig_Del.Recurso)
                        db.AddInParameter(peaxmd, "HoraInicio", DbType.String, Ent_PlanEq_Asig_Del.HoraInicio)
                        db.AddInParameter(peaxmd, "HoraTermino", DbType.String, Ent_PlanEq_Asig_Del.HoraFin)
                        db.AddInParameter(peaxmd, "Horas", DbType.Double, Ent_PlanEq_Asig_Del.Horas)
                        db.AddInParameter(peaxmd, "Fecha", DbType.Date, Ent_PlanEq_Asig_Del.Fecha)
                        db.AddInParameter(peaxmd, "status", DbType.String, Ent_PlanEq_Asig_Del.Status)
                        db.AddInParameter(peaxmd, "User", DbType.String, Ent_PlanEq_Asig_Del.Usuario)
                        db.AddInParameter(peaxmd, "Tipo", DbType.String, Ent_PlanEq_Asig_Del.Tipo.ToString)
                        db.ExecuteNonQuery(peaxmd, Trans)
                    Next

                    For Each Ent_PlanEq_Asig As ETPresupuestoPlanRecursosAsignacion In Ls_Plan_Equipo_Asig
                        Dim peaxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_Equipo_Asignacion)
                        db.AddInParameter(peaxmd, "PresupPlanEqAsig", DbType.Int32, Ent_PlanEq_Asig.PlanRecursoAsignacion)
                        db.AddInParameter(peaxmd, "PresupPlanEquipo", DbType.Int32, Ent_PlanEq_Asig.PlanRecurso)
                        db.AddInParameter(peaxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(peaxmd, "Equipo", DbType.Int32, Ent_PlanEq_Asig.Recurso)
                        db.AddInParameter(peaxmd, "HoraInicio", DbType.String, Ent_PlanEq_Asig.HoraInicio)
                        db.AddInParameter(peaxmd, "HoraTermino", DbType.String, Ent_PlanEq_Asig.HoraFin)
                        db.AddInParameter(peaxmd, "Horas", DbType.Double, Ent_PlanEq_Asig.Horas)
                        db.AddInParameter(peaxmd, "Fecha", DbType.Date, Ent_PlanEq_Asig.Fecha)
                        db.AddInParameter(peaxmd, "status", DbType.String, Ent_PlanEq_Asig.Status)
                        db.AddInParameter(peaxmd, "User", DbType.String, Ent_PlanEq_Asig.Usuario)
                        db.AddInParameter(peaxmd, "Tipo", DbType.String, Ent_PlanEq_Asig.Tipo.ToString)
                        db.ExecuteNonQuery(peaxmd, Trans)
                    Next

                    For Each Ent_PlanMO_Asig_Del As ETPresupuestoPlanRecursosAsignacion In Ls_Plan_ManoObra_Asig_Del
                        Dim pmaoxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_ManoObra_Asignacion)
                        db.AddInParameter(pmaoxmd, "PresupPlanMOAsig", DbType.Int32, Ent_PlanMO_Asig_Del.PlanRecursoAsignacion)
                        db.AddInParameter(pmaoxmd, "PresupPlanManoObra", DbType.Int32, Ent_PlanMO_Asig_Del.PlanRecurso)
                        db.AddInParameter(pmaoxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(pmaoxmd, "Empleado", DbType.String, Ent_PlanMO_Asig_Del.Codigo)
                        db.AddInParameter(pmaoxmd, "HoraInicio", DbType.String, Ent_PlanMO_Asig_Del.HoraInicio)
                        db.AddInParameter(pmaoxmd, "HoraTermino", DbType.String, Ent_PlanMO_Asig_Del.HoraFin)
                        db.AddInParameter(pmaoxmd, "Horas", DbType.Double, Ent_PlanMO_Asig_Del.Horas)
                        db.AddInParameter(pmaoxmd, "Fecha", DbType.Date, Ent_PlanMO_Asig_Del.Fecha)
                        db.AddInParameter(pmaoxmd, "status", DbType.String, Ent_PlanMO_Asig_Del.Status)
                        db.AddInParameter(pmaoxmd, "User", DbType.String, Ent_PlanMO_Asig_Del.Usuario)
                        db.AddInParameter(pmaoxmd, "Tipo", DbType.String, Ent_PlanMO_Asig_Del.Tipo.ToString)
                        db.ExecuteNonQuery(pmaoxmd, Trans)
                    Next

                    For Each Ent_PlanMO_Asig As ETPresupuestoPlanRecursosAsignacion In Ls_Plan_ManoObra_Asig
                        Dim pmaoxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Plan_ManoObra_Asignacion)
                        db.AddInParameter(pmaoxmd, "PresupPlanMOAsig", DbType.Int32, Ent_PlanMO_Asig.PlanRecursoAsignacion)
                        db.AddInParameter(pmaoxmd, "PresupPlanManoObra", DbType.Int32, Ent_PlanMO_Asig.PlanRecurso)
                        db.AddInParameter(pmaoxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(pmaoxmd, "Empleado", DbType.String, Ent_PlanMO_Asig.Codigo)
                        db.AddInParameter(pmaoxmd, "HoraInicio", DbType.String, Ent_PlanMO_Asig.HoraInicio)
                        db.AddInParameter(pmaoxmd, "HoraTermino", DbType.String, Ent_PlanMO_Asig.HoraFin)
                        db.AddInParameter(pmaoxmd, "Horas", DbType.Double, Ent_PlanMO_Asig.Horas)
                        db.AddInParameter(pmaoxmd, "Fecha", DbType.Date, Ent_PlanMO_Asig.Fecha)
                        db.AddInParameter(pmaoxmd, "status", DbType.String, Ent_PlanMO_Asig.Status)
                        db.AddInParameter(pmaoxmd, "User", DbType.String, Ent_PlanMO_Asig.Usuario)
                        db.AddInParameter(pmaoxmd, "Tipo", DbType.String, Ent_PlanMO_Asig.Tipo.ToString)
                        db.ExecuteNonQuery(pmaoxmd, Trans)
                    Next

                End If
                Trans.Commit()
                conexion.Close()
                Return lResult

            Catch Err As Exception
                Trans.Rollback()
                conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try
        End Using
    End Function

    Public Function Consultar_Presupuesto() As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 4)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.Presupuesto = New ETPresupuesto
                    With Entidad.Presupuesto
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Area = dr.GetString(dr.GetOrdinal("Area"))
                        .Area_Abrev = dr.GetString(dr.GetOrdinal("Area_Abrev"))
                        .Cod_Presup = dr.GetString(dr.GetOrdinal("Cod_Presup"))
                        .EncargadoArea = dr.GetString(dr.GetOrdinal("EncargadoArea"))
                        .TipoCliente = dr.GetBoolean(dr.GetOrdinal("TipoCliente"))
                        .TipoCli = dr.GetString(dr.GetOrdinal("TipoCli"))
                        .Cliente = dr.GetString(dr.GetOrdinal("Cliente"))
                        .RUC = dr.GetString(dr.GetOrdinal("RUC"))
                        .AreaInterna = dr.GetString(dr.GetOrdinal("AreaInterna"))
                        .Equipo = dr.GetString(dr.GetOrdinal("Equipo"))
                        .TipoMantto = dr.GetString(dr.GetOrdinal("TipoMantto"))
                        .Atributo = dr.GetString(dr.GetOrdinal("Atributo"))
                        .ValorControl = dr.GetString(dr.GetOrdinal("ValorControl"))
                        .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                        .Prioridad = dr.GetString(dr.GetOrdinal("Prioridad"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .Total = dr.GetDecimal(dr.GetOrdinal("Total"))
                        .TipoCambio = dr.GetDecimal(dr.GetOrdinal("TipoCambio"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                        .Estado = dr.GetString(dr.GetOrdinal("Estado"))
                        .Cod_Area = dr.GetString(dr.GetOrdinal("Cod_Area"))
                        .Cod_EncargadoArea = dr.GetString(dr.GetOrdinal("Cod_EncargadoArea"))
                        .Cod_Cli = dr.GetString(dr.GetOrdinal("Cod_Cli"))
                        .Cod_ClienteInt = dr.GetString(dr.GetOrdinal("Cod_ClienteInt"))
                        .Cod_AreaInt = dr.GetString(dr.GetOrdinal("Cod_AreaInt"))
                        .EquipoID = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                        .TipoProceso = dr.GetString(dr.GetOrdinal("TipoProceso"))
                        .AtributoControl = dr.GetInt32(dr.GetOrdinal("AtributoControl"))
                        .Cod_UniMed = dr.GetString(dr.GetOrdinal("Cod_UniMed"))
                        .TipoDato = dr.GetString(dr.GetOrdinal("TipoDato"))
                        .Longitud = dr.GetInt16(dr.GetOrdinal("Longitud"))
                        .Decimales = dr.GetInt16(dr.GetOrdinal("Decimales"))
                        .Cod_Prioridad = dr.GetString(dr.GetOrdinal("Cod_Prioridad"))
                        .Status = dr.GetString(dr.GetOrdinal("Status"))
                        .Presupuesto = dr.GetInt32(dr.GetOrdinal("Presupuesto"))

                    End With
                    lResult.Ls_Presupuesto.Add(Entidad.Presupuesto)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

            Return lResult

        Catch Err As Exception
            MsgBox(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function Consultar_Presupuesto_Pendiente_Aprobar() As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 8)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.Presupuesto = New ETPresupuesto
                    With Entidad.Presupuesto
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Area_Abrev = dr.GetString(dr.GetOrdinal("Area_Abrev"))
                        .Cod_Presup = dr.GetString(dr.GetOrdinal("Cod_Presup"))
                        .Equipo = dr.GetString(dr.GetOrdinal("Equipo"))
                        .TipoMantto = dr.GetString(dr.GetOrdinal("TipoMantto"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .Total = dr.GetDecimal(dr.GetOrdinal("Total"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                        .Cod_Prioridad = dr.GetString(dr.GetOrdinal("Cod_Prioridad"))
                        .Presupuesto = dr.GetInt32(dr.GetOrdinal("Presupuesto"))
                    End With
                    lResult.Ls_Presupuesto.Add(Entidad.Presupuesto)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

            Return lResult

        Catch Err As Exception
            MsgBox(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function Consultar_TipoCambio(ByVal Ent_Presup As ETPresupuesto) As Double
        Dim lResult As Double
        Dim db As Database = DatabaseFactory.CreateDatabase
        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Fecha", DbType.Date, Ent_Presup.Fecha)
            db.AddInParameter(cmd, "Moneda", DbType.String, Ent_Presup.Moneda.Trim)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Ent_Presup.Tipo)

            lResult = db.ExecuteScalar(cmd)
            Return lResult

        Catch Err As Exception
            Return 0
        End Try

    End Function


    Public Function Consultar_Presup_Detalle(ByVal Ent_Pres As ETPresupuesto) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_PresupuestoDetalle)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "PresupuestoID", DbType.Int32, Ent_Pres.Presupuesto)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Ent_Pres.Tipo)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.Presupuesto_Detalle = New ETPresupuestoDetalle
                    With Entidad.Presupuesto_Detalle
                        .Item = dr.GetString(dr.GetOrdinal("Item"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                        .Metrado = dr.GetDecimal(dr.GetOrdinal("Metrado"))
                        .Precio = dr.GetDecimal(dr.GetOrdinal("Precio"))
                        .Parcial = dr.GetDecimal(dr.GetOrdinal("Parcial"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTerminacion"))
                        .Partida = dr.GetInt32(dr.GetOrdinal("Partida"))
                        .TipoFactor = dr.GetString(dr.GetOrdinal("TipoFactor"))
                        .Factor = dr.GetDecimal(dr.GetOrdinal("Factor"))
                        .Jornada = dr.GetDecimal(dr.GetOrdinal("Jornada"))
                        .TipoCambio = Ent_Pres.TipoCambio
                        .Cod_UniMed = dr.GetString(dr.GetOrdinal("Cod_UniMed"))
                        .Status = dr.GetString(dr.GetOrdinal("Status"))
                        .Presupuesto = dr.GetInt32(dr.GetOrdinal("Presupuesto"))
                        .PresupuestoDet = dr.GetInt32(dr.GetOrdinal("PresupuestoDet"))
                        .Tipo = 2
                        .Contar = dr.GetInt32(dr.GetOrdinal("Contar"))
                        lResult.Ls_Presupuesto_Detalle.Add(Entidad.Presupuesto_Detalle)
                    End With
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

            Return lResult

        Catch Err As Exception
            Return Nothing
        End Try

    End Function

    Public Function Consultar_Presupuesto_OT(ByVal Ent_Presp As ETPresupuesto) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "PresupuestoID", DbType.Int32, Ent_Presp.Presupuesto)
            db.AddInParameter(cmd, "Area", DbType.String, Ent_Presp.Area)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Ent_Presp.Tipo)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.Presupuesto = New ETPresupuesto
                    With Entidad.Presupuesto
                        .Presupuesto = dr.GetInt32(dr.GetOrdinal("Presupuesto"))
                        .Cod_Presup = dr.GetString(dr.GetOrdinal("Cod_Presup"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .EncargadoArea = dr.GetString(dr.GetOrdinal("EncargadoArea"))
                        .Cliente = dr.GetString(dr.GetOrdinal("Cliente"))
                        .RUC = dr.GetString(dr.GetOrdinal("RUC"))
                        .AreaInterna = dr.GetString(dr.GetOrdinal("AreaInterna"))
                        .Equipo = dr.GetString(dr.GetOrdinal("Equipo"))
                        .Atributo = dr.GetString(dr.GetOrdinal("Atributo"))
                        .ValorControl = dr.GetString(dr.GetOrdinal("ValorControl"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .Total = dr.GetDecimal(dr.GetOrdinal("Total"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                        .Cod_Area = dr.GetString(dr.GetOrdinal("Cod_Area"))
                        .Cod_EncargadoArea = dr.GetString(dr.GetOrdinal("Cod_EncargadoArea"))
                        .TipoCliente = dr.GetBoolean(dr.GetOrdinal("TipoCliente"))
                        .Cod_Cli = dr.GetString(dr.GetOrdinal("Cod_Cli"))
                        .Cod_ClienteInt = dr.GetString(dr.GetOrdinal("Cod_ClienteInt"))
                        .Cod_AreaInt = dr.GetString(dr.GetOrdinal("Cod_AreaInt"))
                        .EquipoID = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                        .TipoProceso = dr.GetString(dr.GetOrdinal("TipoProceso"))
                        .AtributoControl = dr.GetInt32(dr.GetOrdinal("AtributoControl"))
                        .Cod_UniMed = dr.GetString(dr.GetOrdinal("Cod_UniMed"))
                        .TipoDato = dr.GetString(dr.GetOrdinal("TipoDato"))
                        .Longitud = dr.GetInt16(dr.GetOrdinal("Longitud"))
                        .Decimales = dr.GetInt16(dr.GetOrdinal("Decimales"))
                        .Cod_Prioridad = dr.GetString(dr.GetOrdinal("Cod_Prioridad"))
                    End With
                    lResult.Ls_Presupuesto.Add(Entidad.Presupuesto)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

            Return lResult

        Catch Err As Exception
            MsgBox(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Validar_Presupuesto_Pendiente_Aprobacion(ByVal Ent_Presup As ETPresupuesto) As Integer
        Dim lResult As Integer = 0
        If Ent_Presup Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto)

        db.AddInParameter(cmd, "PresupuestoID", DbType.Int32, Ent_Presup.Presupuesto)
        db.AddInParameter(cmd, "Tipo", DbType.Int16, 7)

        lResult = db.ExecuteScalar(cmd)
        Return lResult
    End Function
    Public Function Aprobar_Presupuesto(ByVal Presupuesto_Aprobar As List(Of ETPresupuesto)) As Integer

        Dim lResult As Integer = 0
        If Presupuesto_Aprobar Is Nothing Then Return 0
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try
                For Each Ent_Presp As ETPresupuesto In Presupuesto_Aprobar
                    Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto)
                    db.AddInParameter(cmd, "PresupuestoID", DbType.Int32, Ent_Presp.Presupuesto)
                    db.AddInParameter(cmd, "status", DbType.String, Ent_Presp.Status)
                    db.AddInParameter(cmd, "User", DbType.String, Ent_Presp.Usuario)
                    db.AddInParameter(cmd, "Tipo", DbType.Int16, Ent_Presp.Tipo)
                    db.ExecuteNonQuery(cmd, Trans)

                Next
                Trans.Commit()
                conexion.Close()
                lResult = 1
                Return lResult

            Catch Err As Exception
                Trans.Rollback()
                conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return 0
            End Try
        End Using
    End Function
    Public Function Mantenimiento_Presupuesto_DatosGenerales(ByVal Ent_Presp As ETPresupuesto) As Integer

        Dim lResult As Integer = 0
        If Ent_Presp Is Nothing Then Return 0
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto)
                db.AddInParameter(cmd, "PresupuestoID", DbType.Int32, Ent_Presp.Presupuesto)
                db.AddInParameter(cmd, "status", DbType.String, Ent_Presp.Status)
                db.AddInParameter(cmd, "User", DbType.String, Ent_Presp.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.Int16, Ent_Presp.Tipo)
                db.ExecuteNonQuery(cmd, Trans)

                Trans.Commit()
                conexion.Close()
                lResult = 1
                Return lResult

            Catch Err As Exception
                Trans.Rollback()
                conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return 0
            End Try
        End Using
    End Function

    Public Function Obtener_Presupuesto_Estado(ByVal Ent_Presup As ETPresupuesto) As Integer
        Dim lResult As Integer = 0
        If Ent_Presup Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto)

        db.AddInParameter(cmd, "PresupuestoID", DbType.Int32, Ent_Presup.Presupuesto)
        db.AddInParameter(cmd, "Tipo", DbType.Int16, 10)

        lResult = db.ExecuteScalar(cmd)
        Return lResult
    End Function
End Class
