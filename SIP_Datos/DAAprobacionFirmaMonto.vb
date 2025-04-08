Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Exception


Public Class DAAprobacionFirmaMonto
    Inherits ETObjecto

    '   *****   MANTENIMIENTO   *****

#Region "Grabar Rango Aprobacion"
    Public Function GrabarRangoAprobacion(ByVal RangoApropacion As ETAprobacionFirmaMonto _
                                          , ByVal A As List(Of ETAprobacionFirmaMonto) _
                                          , ByVal Opcion As String) As ETResultado
        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RangoAprobacion)
        Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.FirmaMonto)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "Cod_Cia", DbType.String, RangoApropacion.Cod_Cia)
                db.AddInParameter(cmd, "Moneda", DbType.String, RangoApropacion.Moneda)
                db.AddInParameter(cmd, "TotalDesde", DbType.String, RangoApropacion.TotalDesde)
                db.AddInParameter(cmd, "Signo", DbType.Boolean, RangoApropacion.Signo)
                db.AddInParameter(cmd, "TotalHasta", DbType.String, RangoApropacion.TotalHasta)
                db.AddInParameter(cmd, "User", DbType.String, RangoApropacion.User_crea)
                db.AddInParameter(cmd, "CodigoAprobacion", DbType.Int16, RangoApropacion.CodigoAprobacion)
                db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
                db.AddOutParameter(cmd, "Mensaje", DbType.Int16, 10)

                If Opcion = "AGR" Then
                    ETResultado.Mensaje = Convert.ToInt16(db.GetParameterValue(cmd, "Mensaje"))
                Else
                    ETResultado.Mensaje = RangoApropacion.CodigoAprobacion
                End If

                IntRes = db.ExecuteNonQuery(cmd, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                db.AddInParameter(cmd1, "Cod_Cia", DbType.String, RangoApropacion.Cod_Cia)
                db.AddInParameter(cmd1, "CodigoAprobacion", DbType.String, RangoApropacion.CodigoAprobacion)
                db.AddInParameter(cmd1, "Opcion", DbType.String, "ELI")

                IntRes = db.ExecuteNonQuery(cmd1, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                For Each W As ETAprobacionFirmaMonto In A
                    Dim xmd As DbCommand = db.GetStoredProcCommand(usp_RAL.FirmaMonto)

                    db.AddInParameter(xmd, "Cod_Cia", DbType.String, W.Cod_Cia)
                    db.AddInParameter(xmd, "CodigoAprobacion", DbType.String, W.CodigoAprobacion)
                    db.AddInParameter(xmd, "Usuario", DbType.String, W.Usuario)
                    db.AddInParameter(xmd, "Firma", DbType.Boolean, W.Firma)
                    db.AddInParameter(xmd, "User", DbType.String, W.User_crea)
                    db.AddInParameter(xmd, "Opcion", DbType.String, "AGR")

                    IntRes = db.ExecuteNonQuery(xmd, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                Next

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False

                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function
#End Region

#Region "Eliminar Rango Aprobacion"
    Public Function RangoAprobacionEliminar(ByVal RangoApropacion As ETAprobacionFirmaMonto) As ETResultado
        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RangoAprobacion)
        Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.FirmaMonto)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "Cod_Cia", DbType.String, RangoApropacion.Cod_Cia)
                db.AddInParameter(cmd, "CodigoAprobacion", DbType.Int16, RangoApropacion.CodigoAprobacion)
                db.AddInParameter(cmd, "User", DbType.String, RangoApropacion.User_crea)
                db.AddOutParameter(cmd, "Opcion", DbType.String, "ELI")

                IntRes = db.ExecuteNonQuery(cmd, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If



                db.AddInParameter(cmd1, "Cod_Cia", DbType.String, RangoApropacion.Cod_Cia)
                db.AddInParameter(cmd1, "CodigoAprobacion", DbType.String, RangoApropacion.CodigoAprobacion)
                db.AddInParameter(cmd1, "Opcion", DbType.String, "MOD")

                IntRes = db.ExecuteNonQuery(cmd1, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False

                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function
#End Region

#Region "Grabar Aprobacion O/C"
    Public Function GrabarAprobacionOC(ByVal Orden As List(Of ETAprobacionFirmaMonto)) As ETResultado
        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                For Each w As ETAprobacionFirmaMonto In Orden
                    Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.OrdenAprobacionMonto)
                    Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.UpdateDetalleOC)

                    db.AddInParameter(cmd, "Cod_Cia", DbType.String, w.Cod_Cia)
                    db.AddInParameter(cmd, "Nro_OC", DbType.Int16, w.Nro_OC)
                    db.AddInParameter(cmd, "User", DbType.String, w.User_crea)
                    db.AddOutParameter(cmd, "Opcion", DbType.String, "AGR")

                    IntRes = db.ExecuteNonQuery(cmd, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    db.AddInParameter(cmd1, "Cod_Cia", DbType.String, w.Cod_Cia)
                    db.AddInParameter(cmd1, "Nro_OC", DbType.String, w.Nro_OC)
                    db.AddInParameter(cmd1, "User", DbType.String, w.User_crea)
                    db.AddInParameter(cmd1, "Opcion", DbType.String, "MOD")

                    IntRes = db.ExecuteNonQuery(cmd1, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                Next

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False

                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function
#End Region

#Region "Grabar Anular Aprobacion O/C"
    Public Function GrabarAnularAprobacionOC(ByVal Orden As List(Of ETAprobacionFirmaMonto)) As ETResultado
        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                For Each w As ETAprobacionFirmaMonto In Orden
                    Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.OrdenAprobacionMonto)

                    db.AddInParameter(cmd, "Cod_Cia", DbType.String, w.Cod_Cia)
                    db.AddInParameter(cmd, "Nro_OC", DbType.Int16, w.Nro_OC)
                    db.AddInParameter(cmd, "User", DbType.String, w.User_crea)
                    db.AddOutParameter(cmd, "Opcion", DbType.String, "MOD")

                    IntRes = db.ExecuteNonQuery(cmd, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                Next

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False

                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function
#End Region

    '======================================================================

    '   *****   usp_RAL_FirmaMonto  *****
    '   Opcion  :   LxC =>  Listar Firma Monto - Codigo Aprobacion
    '   Opcion  :   LIS =>  Listar Firma Monto 


#Region "Listar Firma Monto"
    Public Function ListarFirmaMonto(ByVal Firma As ETAprobacionFirmaMonto, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.FirmaMonto)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Firma.Cod_Cia)
            db.AddInParameter(cmd, "CodigoAprobacion", DbType.String, Firma.CodigoAprobacion)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarFirmaMonto = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****   usp_RAL_RangoAprobacion
    '   Opcion  :   LIS =>  ListarRangoAprobacion
    '   Opcion  :   L1  =>  T_ListarRangoAprobacion

#Region "Listar Rango Aprobacion"
    Public Function ListarRangoAprobacion(ByVal Aprobacion As ETAprobacionFirmaMonto, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.RangoAprobacion)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Aprobacion.Cod_Cia)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarRangoAprobacion = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


End Class
