Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAProyecto

    Public Function Lista_HoraDia(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_HoraDia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt.ayo)
            db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Lista_HoraDia = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Actualiza_HoraDia(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Actualiza_HoraDia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt.ayo)
            db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            db.AddInParameter(cmd, "DIA", DbType.Int32, Rpt.Dia)
            db.AddInParameter(cmd, "HORA", DbType.Double, Rpt.horas)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Actualiza_HoraDia = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_Tarea(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_Tarea)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt.ayo)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Lista_Tarea = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_Taller(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_Taller)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt.ayo)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Lista_Taller = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_Proyecto(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_Proyecto)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt.ayo)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Lista_Proyecto = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ValidaPlano(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ValidaPlano)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID_PLANO", DbType.String, Rpt.idplano)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ValidaPlano = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_Equipo(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_Equipo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt.ayo)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Lista_Equipo = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Mant_Tarea(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Mant_Tarea)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "OPE", DbType.Int32, Rpt.Operacion)
            db.AddInParameter(cmd, "ID_TAREA", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "DESC_TAREA", DbType.String, Rpt.desc_tarea)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Mant_Tarea = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Mant_SubTarea(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Mant_SubTarea)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "OPE", DbType.Int32, Rpt.Operacion)
            db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.idsubtarea)
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID_TALLER", DbType.String, Rpt.idtaller)
            db.AddInParameter(cmd, "ID_PROYECTO", DbType.Int32, Rpt.idproyecto)
            db.AddInParameter(cmd, "ID_EQUIPO_INT", DbType.Int32, Rpt.idequipo)
            db.AddInParameter(cmd, "SUBTAREA", DbType.String, Rpt.subtarea)
            db.AddInParameter(cmd, "FECHA_INI", DbType.Date, Rpt.fechaini)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "EJECUCION", DbType.Int32, Rpt.ejecucion)
            db.AddInParameter(cmd, "ID_PLANIFICACION", DbType.Int32, Rpt.idplanificacion)
            db.AddInParameter(cmd, "ID_TAREA", DbType.Int32, Rpt.idtarea)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Mant_SubTarea = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Mant_Pla_Tarea(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Mant_Pla_Tarea)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "OPE", DbType.Int32, Rpt.Operacion)
            db.AddInParameter(cmd, "ID_PLANIF_TAREA", DbType.Int32, Rpt.idplanificacion_tarea)
            db.AddInParameter(cmd, "ID_PLANIFICACION", DbType.Int32, Rpt.idplanificacion)
            db.AddInParameter(cmd, "ID_TAREA", DbType.Int32, Rpt.idtarea)
            db.AddInParameter(cmd, "TAREA", DbType.String, Rpt.desc_tarea)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Mant_Pla_Tarea = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Mant_Plano(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Mant_Plano)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "OPE", DbType.Int32, Rpt.Operacion)
            db.AddInParameter(cmd, "ID_PLANIF_PLANO", DbType.Int32, Rpt.idplanificacion_plano)
            db.AddInParameter(cmd, "ID_PLANIFICACION", DbType.Int32, Rpt.idplanificacion)
            db.AddInParameter(cmd, "PLANO", DbType.String, Rpt.plano)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Mant_Plano = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Mant_PlanoDET(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Mant_PlanoDET)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "OPE", DbType.Int32, Rpt.Operacion)
            db.AddInParameter(cmd, "ID_PLANIF_SUB_PLANO", DbType.Int32, Rpt.idplanificacion_plano)
            db.AddInParameter(cmd, "ID_PLANIF_SUBTAREA", DbType.Int32, Rpt.idplanisubtarea)
            db.AddInParameter(cmd, "PLANO", DbType.String, Rpt.plano)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Mant_PlanoDET = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Mant_Planificacion(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Mant_Planificacion)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "OPE", DbType.Int32, Rpt.Operacion)
            db.AddInParameter(cmd, "ID_PLANIFICACION", DbType.Int32, Rpt.idplanificacion)
            db.AddInParameter(cmd, "ID_PROYECTO", DbType.Int32, Rpt.idproyecto)
            db.AddInParameter(cmd, "ID_TALLER", DbType.String, Rpt.idtaller)
            db.AddInParameter(cmd, "ID_EQUIPO", DbType.Int32, Rpt.idequipo)
            db.AddInParameter(cmd, "FECHA_INICIO_GANTT", DbType.String, Rpt.fechaini)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "TIPO", DbType.Int32, Rpt.ejecucion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Mant_Planificacion = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_Planificacion(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_Planificacion)
        Dim Tabla As DataSet = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt.ayo)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataSet
            Tabla = Ds

            Lista_Planificacion = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_PlanificacionAvance(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_PlanificacionAvance)
        Dim Tabla As DataSet = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt.ayo)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataSet
            Tabla = Ds

            Lista_PlanificacionAvance = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_PlanificacionID(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_PlanificacionID)
        Dim Tabla As DataSet = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID_PLANIFICACION", DbType.Int32, Rpt.idplanificacion)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataSet
            Tabla = Ds

            Lista_PlanificacionID = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_Personal(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_Personal)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt.ayo)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Lista_Personal = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_Material(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_Material)
        cmd.CommandTimeout = 0
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt.ayo)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Lista_Material = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Costo_Material(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costo_Material)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "COD_PROD", DbType.Int32, Rpt.codprod)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Costo_Material = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_Servicio(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_Servicio)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt.ayo)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Lista_Servicio = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Costo_Servicio(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costo_Servicio)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "COD_PROD", DbType.Int32, Rpt.codprod)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Costo_Servicio = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Mant_SubPersonal(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Mant_SubPersonal)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "OPE", DbType.Int32, Rpt.Operacion)
            db.AddInParameter(cmd, "ID_PLANIF_SUB_PERSONAL", DbType.Int32, Rpt.idsubpersonal)
            db.AddInParameter(cmd, "ID_PLANIF_SUBTAREA", DbType.Int32, Rpt.idplanisubtarea)
            db.AddInParameter(cmd, "PLACOD", DbType.String, Rpt.placod)
            db.AddInParameter(cmd, "HORAS", DbType.Double, Rpt.horas)
            db.AddInParameter(cmd, "COSTO", DbType.Double, Rpt.precio)
            db.AddInParameter(cmd, "TOTAL", DbType.Double, Rpt.Total)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Mant_SubPersonal = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Mant_SubMaterial(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Mant_SubMaterial)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "OPE", DbType.Int32, Rpt.Operacion)
            db.AddInParameter(cmd, "ID_PLANIF_SUB_MATERIAL", DbType.Int32, Rpt.idsubmaterial)
            db.AddInParameter(cmd, "ID_PLANIF_SUBTAREA", DbType.Int32, Rpt.idplanisubtarea)
            db.AddInParameter(cmd, "COD_PROD", DbType.String, Rpt.placod)
            db.AddInParameter(cmd, "CANTIDAD", DbType.Double, Rpt.Cantidad)
            db.AddInParameter(cmd, "PRECIO", DbType.Double, Rpt.precio)
            db.AddInParameter(cmd, "PRECIO_ESTIMADO", DbType.Double, Rpt.precioestimado)
            db.AddInParameter(cmd, "TOTAL", DbType.Double, Rpt.Total)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Mant_SubMaterial = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Mant_SubServicio(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Mant_SubServicio)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "OPE", DbType.Int32, Rpt.Operacion)
            db.AddInParameter(cmd, "ID_PLANIF_SUB_SERVICIO", DbType.Int32, Rpt.idsubservicio)
            db.AddInParameter(cmd, "ID_PLANIF_SUBTAREA", DbType.Int32, Rpt.idplanisubtarea)
            db.AddInParameter(cmd, "COD_SERVICIO", DbType.String, Rpt.placod)
            db.AddInParameter(cmd, "CANTIDAD", DbType.Double, Rpt.Cantidad)
            db.AddInParameter(cmd, "PRECIO", DbType.Double, Rpt.precio)
            db.AddInParameter(cmd, "PRECIO_ESTIMADO", DbType.Double, Rpt.precioestimado)
            db.AddInParameter(cmd, "TOTAL", DbType.Double, Rpt.Total)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Mant_SubServicio = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_DetSubtareaID(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_DetSubtareaID)
        Dim Tabla As DataSet = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID_PLANIF_SUBTAREA", DbType.Int32, Rpt.idplanisubtarea)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataSet
            Tabla = Ds

            Lista_DetSubtareaID = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_DetSubtareaIDREAL(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_DetSubtareaIDREAL)
        Dim Tabla As DataSet = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID_PLANIF_SUBTAREA", DbType.Int32, Rpt.idplanisubtarea)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataSet
            Tabla = Ds

            Lista_DetSubtareaIDREAL = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Actu_Subtarea(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Actu_Subtarea)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "ID_PLANIF_SUBTAREA", DbType.Int32, Rpt.idplanisubtarea)
            db.AddInParameter(cmd, "FECHA_INI", DbType.String, Rpt.fechaini)
            db.AddInParameter(cmd, "NOTA", DbType.String, Rpt.nota)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "SUBTAREA", DbType.String, Rpt.subtarea)
            db.AddInParameter(cmd, "ID_PLANIF_TAREA", DbType.Int32, Rpt.idplanificacion_tarea)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Actu_Subtarea = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ReporteGant(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ReporteGant)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "IDPROYECTO", DbType.Int32, Rpt.idproyecto)
            db.AddInParameter(cmd, "ID_TALLER", DbType.Int32, Rpt.idtaller)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ReporteGant = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ReporteValor(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ReporteValor)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "FECHA", DbType.DateTime, Rpt.Fecha)
            db.AddInParameter(cmd, "TIPO", DbType.String, Rpt.tipograf)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ReporteValor = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ReporteGantReal(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ReporteGantReal)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "IDPROYECTO", DbType.Int32, Rpt.idproyecto)
            db.AddInParameter(cmd, "ID_TALLER", DbType.Int32, Rpt.idtaller)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ReporteGantReal = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_PlanificacionProyecto(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_PlanificacionProyecto)
        Dim Tabla As DataSet = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID_PROYECTO", DbType.Int32, Rpt.idproyecto)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataSet
            Tabla = Ds

            Lista_PlanificacionProyecto = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_EquipoProyecto(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_EquipoProyecto)
        Dim Tabla As DataSet = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID_PROYECTO", DbType.Int32, Rpt.idproyecto)
            db.AddInParameter(cmd, "ID_TALLER", DbType.String, Rpt.idtaller)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataSet
            Tabla = Ds

            Lista_EquipoProyecto = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_TallerID(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_TallerID)
        Dim Tabla As DataSet = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID_PLANIFICACION", DbType.Int32, Rpt.idplanificacion)
            db.AddInParameter(cmd, "ID_PROYECTO", DbType.Int32, Rpt.idproyecto)
            db.AddInParameter(cmd, "ID_TALLER", DbType.Int32, Rpt.idtaller)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataSet
            Tabla = Ds

            Lista_TallerID = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_AvanceSubtarea(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_AvanceSubtarea)
        Dim Tabla As DataSet = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID_PROYECTO", DbType.Int32, Rpt.idproyecto)
            db.AddInParameter(cmd, "ID_TALLER", DbType.Int32, Rpt.idtaller)
            db.AddInParameter(cmd, "ID_EQUIPO", DbType.Int32, Rpt.idequipo)
            db.AddInParameter(cmd, "ID_PLANF_TAREA", DbType.Int32, Rpt.idplanificacion_tarea)
            db.AddInParameter(cmd, "FLGPERSONAL", DbType.Int32, Rpt.flgpersonal)
            db.AddInParameter(cmd, "FLGMATERIAL", DbType.Int32, Rpt.flgmaterial)
            db.AddInParameter(cmd, "FLGSERVICIO", DbType.Int32, Rpt.flgservicio)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataSet
            Tabla = Ds

            Lista_AvanceSubtarea = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_AvanceFisicoSub(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_AvanceFisicoSub)
        Dim Tabla As DataSet = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID_PROYECTO", DbType.Int32, Rpt.idproyecto)
            db.AddInParameter(cmd, "FECHA", DbType.DateTime, Rpt.Fecha)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataSet
            Tabla = Ds

            Lista_AvanceFisicoSub = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Mant_AvanceFisicoSub(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Mant_AvanceFisicoSub)
        Dim Tabla As DataSet = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID_PLANIF_SUBTAREA", DbType.Int32, Rpt.idplanisubtarea)
            db.AddInParameter(cmd, "FECHA", DbType.DateTime, Rpt.Fecha)
            db.AddInParameter(cmd, "AVANCE", DbType.Double, Rpt.avance)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataSet
            Tabla = Ds

            Mant_AvanceFisicoSub = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_DetalleTaller(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_DetalleTaller)
        Dim Tabla As DataSet = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID_PROYECTO", DbType.Int32, Rpt.idproyecto)
            db.AddInParameter(cmd, "ID_TALLER", DbType.String, Rpt.idtaller)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataSet
            Tabla = Ds

            Lista_DetalleTaller = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function CierreProyecto(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.CierreProyecto)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "ID_PROYECTO", DbType.Int32, Rpt.idproyecto)
            db.AddInParameter(cmd, "FLGCIERRE", DbType.Int32, Rpt.cierre)
            db.AddInParameter(cmd, "FECHACIERRE", DbType.String, Rpt.FechaTerminacion)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CierreProyecto = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function CierreTaller(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.CierreTaller)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "ID_PROYECTO", DbType.Int32, Rpt.idproyecto)
            db.AddInParameter(cmd, "ID_TALLER", DbType.String, Rpt.idtaller)
            db.AddInParameter(cmd, "FLGCIERRE", DbType.Int32, Rpt.cierre)
            db.AddInParameter(cmd, "FECHACIERRE", DbType.String, Rpt.FechaTerminacion)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CierreTaller = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_PersonalExt(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_PersonalExt)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt.ayo)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Lista_PersonalExt = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_PersonalExtMant(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_PersonalExtMant)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "PERSONAL", DbType.String, Rpt.personal)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Lista_PersonalExtMant = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Lista_Subtarea(ByVal Rpt As ETProyecto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_Subtarea)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID_TAREA", DbType.Int32, Rpt.idtarea)
            db.AddInParameter(cmd, "EJECUCION", DbType.Int32, Rpt.ejecucion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Lista_Subtarea = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function


    Public Function Lista_PlanificacionOrden(ByVal Rpt As ETProyecto) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Lista_PlanificacionOrden)
        Dim Tabla As DataSet = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "FECHA1", DbType.DateTime, Rpt.fechaini)
            db.AddInParameter(cmd, "FECHA2", DbType.DateTime, Rpt.FechaTerminacion)
            'db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataSet
            Tabla = Ds

            Lista_PlanificacionOrden = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function


End Class
