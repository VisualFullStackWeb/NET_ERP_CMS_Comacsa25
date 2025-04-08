Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DACosteoProduccion
    Public Function Consultar_Producto_Tonelaje(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Producto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "fecini", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)

            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_SPID() As Integer
        Dim lResult As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Consultar_SPID)
        Try
            cmd.CommandTimeout = 3000

            lResult = db.ExecuteScalar(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = 0
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function


    Public Function Consultar_Producto_PrecioVenta(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_PrecioVenta)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Producto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)

            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function


    Public Function Consultar_Producto_Suministro(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Envases)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            
            'db.AddInParameter(cmd, "Tipo", DbType.String, "1")
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_GasNatural(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_GasNatural)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "fecini", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "Tonelaje", DbType.Double, Producto.Cantidad)
            db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
            db.AddInParameter(cmd, "ProduccionPlanta", DbType.Double, Producto.TotalPlanta)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
           
            

            'db.AddInParameter(cmd, "Tipo", DbType.String, "1")
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function
    Public Function Consultar_Producto_ManoObra(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_ManoObra)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Placa", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "fecini", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "UnidadProd", DbType.String, Producto.Descripcion)
            db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
            db.AddInParameter(cmd, "Produccion", DbType.Double, Producto.Cantidad)
            db.AddInParameter(cmd, "ProduccionPlanta", DbType.Double, Producto.TotalPlanta)
            'db.AddInParameter(cmd, "Tipo", DbType.String, "1")

            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Chancadora_ManoObra_Normal(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Chancadora_ManoObraNormal)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Placa", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "fecini", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "CantidadChanc", DbType.Double, Producto.Cantidad)
            db.AddInParameter(cmd, "Produccion", DbType.Double, Producto.TotalChancadora)
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Pala_ManoObra(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Pala_ManoObra)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "Cod_Alm", DbType.String, Producto.Cod_Alm)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Chancadora_ManoObra(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Chancadora_ManoObra)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "Cod_Alm", DbType.String, Producto.Cod_Alm)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_ManttoMecanico(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_ManttoMecanico)
        Try
            cmd.CommandTimeout = 3000

            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Placa", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "Tonelaje", DbType.Double, Producto.TotalMolino)
            db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
            db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
            db.AddInParameter(cmd, "ProduccionPlanta", DbType.Double, Producto.TotalPlanta)

            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_ManttoMecanicoNormal(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_ManttoMecanico_Normal)
        Try
            cmd.CommandTimeout = 3000

            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Placa", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "Tonelaje", DbType.Double, Producto.TotalMolino)
            db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
            db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
            db.AddInParameter(cmd, "ProduccionPlanta", DbType.Double, Producto.TotalPlanta)
            db.AddInParameter(cmd, "Tipo", DbType.String, "1")

            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Pala(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Pala)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Pala_Combustible(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_PalaDetalle_Comb)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Alm", DbType.String, Producto.Cod_Alm)
            db.AddInParameter(cmd, "Producto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
            'db.AddInParameter(cmd, "Produccion", DbType.Double, Producto.TotalChancadora)
            'db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
            'db.AddInParameter(cmd, "Tipo", DbType.String, "1")

            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Pala_Depreciacion(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_PalaDetalle_Deprec)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Alm", DbType.String, Producto.Cod_Alm)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
            'db.AddInParameter(cmd, "Produccion", DbType.Double, Producto.TotalChancadora)
            'db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
            'db.AddInParameter(cmd, "Tipo", DbType.String, "1")


            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function


    Public Function Consultar_Producto_Energia(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Energia)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Placa", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "fecini", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "Tonelaje", DbType.Double, Producto.Cantidad)
            db.AddInParameter(cmd, "Horas_Trab", DbType.Double, Producto.HorasTrabajadas)
            db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
            db.AddInParameter(cmd, "ProduccionPlanta", DbType.Double, Producto.TotalPlanta)
            'db.AddInParameter(cmd, "Tipo", DbType.String, "1")

            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Depreciacion_Normal(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Depreciacion_Normal)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Placa", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Fecha", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "Tonelaje", DbType.Double, Producto.TotalMolino)
            db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
            db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
            db.AddInParameter(cmd, "ProduccionPlanta", DbType.Double, Producto.TotalPlanta)
            db.AddInParameter(cmd, "Tipo", DbType.String, "1")
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Depreciacion(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Depreciacion)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Placa", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "Tonelaje", DbType.Double, Producto.TotalMolino)
            db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
            db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
            db.AddInParameter(cmd, "ProduccionPlanta", DbType.Double, Producto.TotalPlanta)
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Pala_Alquiler_Mantto(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Pala_Alquiler_Mantto)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "Moneda", DbType.String, "S/.")
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "Tipo", DbType.String, Producto.Tipo.ToString)
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Chancadora(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Chancadora)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_General(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Molino)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Placa", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "fecini", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "Tonelaje", DbType.Double, Producto.TotalMolino)
            db.AddInParameter(cmd, "Horas_Trab", DbType.Double, Producto.HorasTrabajadas)
            db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
            db.AddInParameter(cmd, "CantidadChancada", DbType.Double, Producto.TotalChancadora)
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function


    Public Function Consultar_Producto_Ruma(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Ruma)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            'db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
            'db.AddInParameter(cmd, "Tipo", DbType.String, "1")
            lResult = db.ExecuteDataSet(cmd)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Silice(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Silice)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
            lResult = db.ExecuteDataSet(cmd)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Chancadora_TranspInt(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Chancadora_TranspInt)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Chancadora_ManttoMecanico(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Chancadora_ManttoMec)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)

            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Chancadora_Depreciacion(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Chancadora_Deprec)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)

            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Chancadora_Energia(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Chancadora_Energia)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
            db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)

            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Generico(ByVal Producto As ETOrden) As Boolean
        Dim lResult As Boolean
        Dim db As Database = DatabaseFactory.CreateDatabase

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Generico_Molino)
            Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Generico_Pala)

            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Producto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
                db.AddInParameter(cmd, "fecini", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Planta", DbType.Int32, Producto.Cod_Planta)
                db.ExecuteNonQuery(cmd, Trans)


                xmd.CommandTimeout = 3000
                db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(xmd, "Producto", DbType.String, Producto.CodProducto)
                db.AddInParameter(xmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(xmd, "Enlace", DbType.Int32, Producto.CodEnlace)
                db.AddInParameter(xmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(xmd, "Spid", DbType.Int32, Producto.Spid)
                db.AddInParameter(xmd, "Cod_Alm", DbType.String, Producto.Cod_Alm)
                db.AddInParameter(xmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(xmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(xmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
                db.ExecuteNonQuery(xmd, Trans)
                Trans.Commit()
                Conexion.Close()
                lResult = True
                cmd.CommandTimeout = 0
                xmd.CommandTimeout = 0
            Catch ex As Exception
                cmd.CommandTimeout = 0
                xmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = False
            End Try
        End Using


        Return lResult
    End Function

    Public Function Consultar_Producto_Generico_Delete(ByVal Producto As ETOrden) As Boolean
        Dim lResult As Boolean
        Dim db As Database = DatabaseFactory.CreateDatabase

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Generico_Delete)
            
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Producto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Spid", DbType.Int32, Producto.Spid)
                db.ExecuteNonQuery(cmd, Trans)


                Trans.Commit()
                Conexion.Close()
                lResult = True
                cmd.CommandTimeout = 0
            Catch ex As Exception
                cmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = False
            End Try
        End Using


        Return lResult
    End Function

    Public Function Consultar_Producto_CostoNeto(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Neto)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, Producto.CodEnlace)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Produccion", DbType.Double, Producto.Cantidad)
            db.AddInParameter(cmd, "fecini", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)

            lResult = db.ExecuteDataSet(cmd)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function


    Public Function ValidarCosteoProductoTerminado(ByVal Producto As ETOrden) As ETMyLista
        Dim lResult As New ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Validar_Costeo_Produccion_Cierre)
        Try
            db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
            db.AddInParameter(cmd, "fecini", DbType.DateTime, Producto.FechaInicio)
            db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)
            db.AddInParameter(cmd, "Almacen", DbType.String, Producto.Cod_Alm)
            db.AddInParameter(cmd, "Periodo", DbType.Int16, Producto.Respuesta)
            db.AddInParameter(cmd, "Producto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Producto.Tipo)
            db.AddInParameter(cmd, "Mes", DbType.Int16, Producto.Mes)
            db.AddInParameter(cmd, "Año", DbType.Int16, Producto.Anho)

            If Producto.Tipo = 8 OrElse Producto.Tipo = 9 Then
                Using dr As IDataReader = db.ExecuteReader(cmd)
                    While dr.Read
                        If Producto.Tipo = 1 Then
                            Entidad.Producto = New ETProducto
                            With Entidad.Producto
                                .CodProducto = dr.GetString(dr.GetOrdinal("Codigo"))
                                .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                            End With
                            lResult.Ls_Producto.Add(Entidad.Producto)
                        Else
                            Entidad.CosteoActivo = New ETCosteoActivo
                            With Entidad.CosteoActivo
                                .Codigo = dr.GetString(dr.GetOrdinal("Codigo")).Trim & " - " & dr.GetString(dr.GetOrdinal("Modelo")).Trim

                                .Descripcion = dr.GetString(dr.GetOrdinal("Proveedor"))
                                .Cantidad = dr.GetDecimal(dr.GetOrdinal("Costo"))
                            End With
                            lResult.Ls_CosteoActivo.Add(Entidad.CosteoActivo)
                        End If
                    End While

                End Using

            Else
                lResult.ValorxDecimal = db.ExecuteScalar(cmd)
            End If
            lResult.Validacion = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult.Validacion = False
        End Try
        Return lResult
    End Function

#Region "Cierre Costeo de Productos Terminados"
    Public Function Consultar_Producto_Generico_Cierre(ByVal Producto As ETOrden) As Boolean
        Dim lResult As Boolean
        Dim db As Database = DatabaseFactory.CreateDatabase

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Generico_Molino_Cierre)


            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Producto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "Enlace", DbType.Int32, Producto.CodEnlace)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Cod_Alm", DbType.String, Producto.Cod_Alm)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Produccion", DbType.Double, Producto.Cantidad)
                db.ExecuteNonQuery(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
                lResult = True
                cmd.CommandTimeout = 0
            Catch ex As Exception
                cmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = False
            End Try
        End Using


        Return lResult
    End Function

    Public Function Consultar_Producto_Ruma_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Ruma_Cierre)

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodEnlace", DbType.Int32, Producto.CodEnlace)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)
                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try
        End Using
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Silice_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Silice_Cierre)
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)

                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using

        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Chancadora_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Chancadora_Cierre)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Anio", DbType.Int32, Producto.Anho)
            db.AddInParameter(cmd, "Mes", DbType.Int16, Producto.Mes)
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Chancadora_TranspInt_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Chancadora_TranspInt_Cierre)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Anio", DbType.Int32, Producto.Anho)
            db.AddInParameter(cmd, "Mes", DbType.Int32, Producto.Mes)
            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Chancadora_ManttoMecanico_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Chancadora_ManttoMec_Cierre)

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)

                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try
        End Using

        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Chancadora_Depreciacion_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Chancadora_Deprec_Cierre)
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)
                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using

        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Chancadora_Energia_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Chancadora_Energia_Cierre)

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)

                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Chancadora_ManoObra_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Chancadora_ManoObra_Cierre)

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)

                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Pala_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Pala_Cierre)
        Try
            cmd.CommandTimeout = 3000
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
            db.AddInParameter(cmd, "Anio", DbType.Int32, Producto.Anho)
            db.AddInParameter(cmd, "Mes", DbType.Int16, Producto.Mes)

            lResult = db.ExecuteDataSet(cmd)
        Catch ex As Exception
            lResult = Nothing
        End Try
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Pala_Combustible_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_PalaDetalle_Comb_Cierre)

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Producto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)

                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Pala_ManoObra_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Pala_ManoObra_Cierre)

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "Cod_Alm", DbType.String, Producto.Cod_Alm)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)

                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Pala_Depreciacion_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Pala_Depreciacion_Cierre)

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)
                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Pala_Alquiler_Mantto_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Pala_Alquiler_Mantto_Cierre)
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Moneda", DbType.String, "S/.")
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Tipo", DbType.String, Producto.Tipo.ToString)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)

                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using

        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_ManoObra_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_ManoObra_Cierre)
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Placa", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "fecini", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "UnidadProd", DbType.String, Producto.Descripcion)
                db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
                db.AddInParameter(cmd, "Produccion", DbType.Double, Producto.Cantidad)
                db.AddInParameter(cmd, "ProduccionPlanta", DbType.Double, Producto.TotalPlanta)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)
                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_ManttoMecanico_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_ManttoMecanico_Cierre)
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000

                db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Placa", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Tonelaje", DbType.Double, Producto.TotalMolino)
                db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
                db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
                db.AddInParameter(cmd, "ProduccionPlanta", DbType.Double, Producto.TotalPlanta)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)
                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using

        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Contable_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Contable_Cierre)
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000

                db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Placa", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "Anio", DbType.Int32, Producto.Anho)
                db.AddInParameter(cmd, "Mes", DbType.Int16, Producto.Mes)
                db.AddInParameter(cmd, "Concepto", DbType.String, Producto.Tipo_Doc)
                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using

        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Depreciacion_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Depreciacion_Cierre)

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Placa", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Tonelaje", DbType.Double, Producto.TotalMolino)
                db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
                db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
                db.AddInParameter(cmd, "ProduccionPlanta", DbType.Double, Producto.TotalPlanta)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)
                
                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Energia_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Energia_Cierre)

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Placa", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "fecini", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Tonelaje", DbType.Double, Producto.Cantidad)
                db.AddInParameter(cmd, "Horas", DbType.Double, Producto.NroHoras)
                db.AddInParameter(cmd, "Horas_Trab", DbType.Double, Producto.HorasTrabajadas)
                db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
                db.AddInParameter(cmd, "ProduccionPlanta", DbType.Double, Producto.TotalPlanta)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)

                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_GasNatural_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_GasNatural_Cierre)
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "fecini", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Tonelaje", DbType.Double, Producto.Cantidad)
                db.AddInParameter(cmd, "ProduccionPlanta", DbType.Double, Producto.TotalPlanta)
                db.AddInParameter(cmd, "LinProd", DbType.Int32, Producto.Cod_Planta)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)

                'db.AddInParameter(cmd, "Tipo", DbType.String, "1")
                lResult = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Suministro_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Envase_Cierre)
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Molino", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Cantidad", DbType.Double, Producto.Cantidad)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Peso", DbType.Double, Producto.Peso)
                db.AddInParameter(cmd, "UndPeso", DbType.String, Producto.UnidPeso)
                db.AddInParameter(cmd, "UndPesoProducida", DbType.String, Producto.UnidProd)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)
                lResult = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using

        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Producto_Resumen(ByVal Producto As ETOrden, ByVal Resumen As List(Of ETOrden), ByVal Molino As List(Of ETOrden)) As Boolean
        Dim lResult As Boolean
        Dim db As Database = DatabaseFactory.CreateDatabase

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Resumen_Delete)
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodProducto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "Anio", DbType.Int32, Producto.Anho)
                db.AddInParameter(cmd, "Mes", DbType.Int16, Producto.Mes)
                db.ExecuteNonQuery(cmd, Trans)

                For Each xRow As ETOrden In Resumen
                    Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Resumen)
                    db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(xmd, "Anio", DbType.Int32, Producto.Anho)
                    db.AddInParameter(xmd, "Mes", DbType.Int16, Producto.Mes)
                    db.AddInParameter(xmd, "Codigo", DbType.String, xRow.CodProducto)
                    db.AddInParameter(xmd, "Concepto", DbType.String, xRow.Concepto)
                    db.AddInParameter(xmd, "FechaMes", DbType.DateTime, xRow.FechaTerminacion)
                    db.AddInParameter(xmd, "Descripcion", DbType.String, xRow.Descripcion)
                    db.AddInParameter(xmd, "CostoxTON", DbType.Double, xRow.CostoxTON)
                    db.AddInParameter(xmd, "Valor", DbType.Double, xRow.ValorxDecimal)
                    db.AddInParameter(xmd, "CostoxTONAcum", DbType.Double, xRow.CostoxTONAcum)
                    db.AddInParameter(xmd, "ValorAcum", DbType.Double, xRow.TotalMolino)
                    db.AddInParameter(xmd, "User", DbType.String, xRow.Usuario)
                    db.ExecuteNonQuery(xmd, Trans)
                Next

                For Each xRow As ETOrden In Molino
                    Dim ymd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Resumen_Molino)
                    db.AddInParameter(ymd, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(ymd, "Anio", DbType.Int32, Producto.Anho)
                    db.AddInParameter(ymd, "Mes", DbType.Int16, Producto.Mes)
                    db.AddInParameter(ymd, "Codigo", DbType.String, xRow.CodProducto)
                    db.AddInParameter(ymd, "CodMolino", DbType.String, xRow.CodMolino)
                    db.AddInParameter(ymd, "Concepto", DbType.String, xRow.Concepto)
                    db.AddInParameter(ymd, "Descripcion", DbType.String, xRow.Descripcion)
                    db.AddInParameter(ymd, "CostoxTON", DbType.Double, xRow.CostoxTON)
                    db.AddInParameter(ymd, "Valor", DbType.Double, xRow.ValorxDecimal)
                    db.AddInParameter(ymd, "CostoxTONAcum", DbType.Double, xRow.CostoxTONAcum)
                    db.AddInParameter(ymd, "ValorAcum", DbType.Double, xRow.TotalMolino)
                    db.AddInParameter(ymd, "User", DbType.String, xRow.Usuario)
                    db.ExecuteNonQuery(ymd, Trans)
                Next
 

                Trans.Commit()
                Conexion.Close()
                lResult = True
                cmd.CommandTimeout = 0
            Catch ex As Exception
                cmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = False
            End Try
        End Using


        Return lResult
    End Function

    Public Function Consultar_Costeo_Produccion_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_Cierre)
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "codcia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Producto", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "fecini", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "fecfin", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "Usuario", DbType.String, Producto.Usuario)
                db.AddInParameter(cmd, "Cierre", DbType.String, Producto.Cierre)
                db.AddInParameter(cmd, "MolinoProy", DbType.String, Producto.CodMolino)
                db.AddInParameter(cmd, "CantProy", DbType.Double, Producto.Cantidad)
                db.AddInParameter(cmd, "Proyeccion", DbType.Boolean, Producto.Proyeccion)

                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using
        cmd.CommandTimeout = 0
        Return lResult
    End Function

    Public Function Consultar_Costeo_Produccion_SinProdMes_Cierre(ByVal Producto As ETOrden) As DataSet
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Costeo_Produccion_SinProd_Cierre)
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try

                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Anio", DbType.Int32, Producto.Anho)
                db.AddInParameter(cmd, "Mes", DbType.Int32, Producto.Mes)
                db.AddInParameter(cmd, "Codigo", DbType.String, Producto.CodProducto)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Producto.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Producto.FechaTerminacion)
                db.AddInParameter(cmd, "User", DbType.String, Producto.Usuario)
                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using
        cmd.CommandTimeout = 0
        Return lResult
    End Function
    Public Function Consultar_Factor_DurezaProducto(ByVal Cia As String, ByVal Ano As Integer, ByVal Mes As Integer, ByVal Producto As String, ByVal Molino As String) As Decimal
 
        Dim lResult As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand("PPA_Factor_Dureza")
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 3000
                db.AddInParameter(cmd, "codcia", DbType.String, Cia)
                db.AddInParameter(cmd, "ayo", DbType.Int32, Ano)
                db.AddInParameter(cmd, "mes", DbType.Int32, Mes)
                db.AddInParameter(cmd, "codProducto", DbType.String, Producto)
                db.AddInParameter(cmd, "Molino", DbType.String, Molino)
                lResult = db.ExecuteDataSet(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
            Catch ex As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(ex.Message, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing
            End Try

        End Using
        cmd.CommandTimeout = 0
        Return lResult.Tables(0).Rows(0).Item(0)


    End Function
#End Region
End Class
