Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Exception

Public Class DAEmpleoLabor
    Inherits ETObjecto

    '   ******  usp_RAL_Listar_EmpleoLabor              *****
    '   Opcion  :   LT1 =>  Listar Empleo Labor
    '   Opcion  :   LT2 =>  Listar Empleo Labor Consulta
    '   Opcion  :   LT3 =>  Listar Empleo Labor Codigo

    '   *****   usp_RAL_Insertar_EmpleoLabor_Activo     *****
    '   Opcion  :   LIS =>  Listar Activo
    '   Opcion  :   LxC =>  Listar Actico x Codigo

    '   *****   usp_RAL_Insertar_EmpleoLabor_Cantera    *****  
    '   Opcion  :   LIS =>  Listar Canteras
    '   Opcion  :   LxC =>  Listar Cantera x Codigo

    '   *****   usp_RAL_ListarCantera   *****
    '   Opcion  :   LMO =>  Listar Canteras
    '   Opcion  :   LNU =>  Listar Canteras General



    '   *****   MANTENIMIENTO   *****

#Region "Agregar Empleo Labor"
    Public Function AgregarEmpleoLabor(ByVal EmpleoLabor As ETEmpleoLabor _
                                        , ByVal Activo As List(Of ETEmpleoLabor) _
                                        , ByVal Linea As List(Of ETEmpleoLabor) _
                                        , ByVal SubLinea As List(Of ETEmpleoLabor) _
                                        , ByVal Cantera As List(Of ETEmpleoLabor) _
                                        , ByVal Opcion As String) As ETResultado

        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.EmpleoLabor)
        Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.EmpleoLabor_Activo)
        Dim cmd01 As DbCommand = db.GetStoredProcCommand(usp_RAL.EmpleoLabor_Activo)
        Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.EmpleoLabor_SoloLinea)
        Dim cmd3 As DbCommand = db.GetStoredProcCommand(usp_RAL.EmpleoLabor_Linea)
        Dim cmd4 As DbCommand = db.GetStoredProcCommand(usp_RAL.EmpleoLabor_Cantera)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, EmpleoLabor.Cod_Cia)
                db.AddInParameter(cmd, "Cod_Area", DbType.String, EmpleoLabor.Cod_Area)
                db.AddInParameter(cmd, "Cod_Empleo", DbType.String, EmpleoLabor.Cod_Empleo)
                db.AddInParameter(cmd, "Descripcion", DbType.String, EmpleoLabor.Descripcion)
                db.AddInParameter(cmd, "User", DbType.String, EmpleoLabor.User)
                db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 3)

                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                If Opcion = "MOD" Then

                    db.AddInParameter(cmd01, "Cod_Cia", DbType.String, EmpleoLabor.Cod_Cia)
                    db.AddInParameter(cmd01, "Cod_Area", DbType.String, EmpleoLabor.Cod_Area)
                    db.AddInParameter(cmd01, "Cod_Empleo", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd01, "Opcion", DbType.String, "UDP")

                    IntRes = db.ExecuteNonQuery(cmd01, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If
                End If

                db.AddInParameter(cmd1, "Cod_Cia", DbType.String, EmpleoLabor.Cod_Cia)
                db.AddInParameter(cmd1, "Cod_Area", DbType.String, EmpleoLabor.Cod_Area)
                db.AddInParameter(cmd1, "Cod_Empleo", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd1, "Cod_Tipo_Activo", DbType.String, EmpleoLabor.Cod_Tipo_Activo)
                db.AddInParameter(cmd1, "Opcion", DbType.String, "ELI")

                IntRes = db.ExecuteNonQuery(cmd1, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                For Each W As ETEmpleoLabor In Activo
                    Dim xmd As DbCommand = db.GetStoredProcCommand(usp_RAL.EmpleoLabor_Activo)
                    db.AddInParameter(xmd, "Cod_Cia", DbType.String, W.Cod_Cia)
                    db.AddInParameter(xmd, "Cod_Area", DbType.String, W.Cod_Area)
                    db.AddInParameter(xmd, "Cod_Empleo", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(xmd, "Cod_Tipo_Activo", DbType.String, W.Cod_Tipo_Activo)
                    db.AddInParameter(xmd, "Cod_Activo", DbType.String, W.Cod_Activo)
                    db.AddInParameter(xmd, "User", DbType.String, W.User)
                    db.AddInParameter(xmd, "Opcion", DbType.String, "AGR")
                    IntRes = db.ExecuteNonQuery(xmd, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                Next


                db.AddInParameter(cmd2, "Cod_Cia", DbType.String, EmpleoLabor.Cod_Cia)
                db.AddInParameter(cmd2, "Cod_Area", DbType.String, EmpleoLabor.Cod_Area)
                db.AddInParameter(cmd2, "Cod_Empleo", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd2, "Opcion", DbType.String, "ELI")

                IntRes = db.ExecuteNonQuery(cmd2, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                For Each W As ETEmpleoLabor In Linea

                    Dim xmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.EmpleoLabor_SoloLinea)

                    db.AddInParameter(xmd1, "Cod_Cia", DbType.String, W.Cod_Cia)
                    db.AddInParameter(xmd1, "Cod_Area", DbType.String, W.Cod_Area)
                    db.AddInParameter(xmd1, "Cod_Empleo", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(xmd1, "Cod_Linea", DbType.String, W.Cod_Linea)
                    db.AddInParameter(xmd1, "User", DbType.String, W.User)
                    db.AddInParameter(xmd1, "Opcion", DbType.String, "AGR")
                    IntRes = db.ExecuteNonQuery(xmd1, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If
                Next


                db.AddInParameter(cmd3, "Cod_Cia", DbType.String, EmpleoLabor.Cod_Cia)
                db.AddInParameter(cmd3, "Cod_Area", DbType.String, EmpleoLabor.Cod_Area)
                db.AddInParameter(cmd3, "Cod_Empleo", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd3, "Cod_Linea", DbType.String, EmpleoLabor.Cod_Linea)
                db.AddInParameter(cmd3, "Opcion", DbType.String, "ELI")

                IntRes = db.ExecuteNonQuery(cmd3, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                For Each W As ETEmpleoLabor In SubLinea

                    Dim xmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.EmpleoLabor_Linea)

                    db.AddInParameter(xmd2, "Cod_Cia", DbType.String, W.Cod_Cia)
                    db.AddInParameter(xmd2, "Cod_Area", DbType.String, W.Cod_Area)
                    db.AddInParameter(xmd2, "Cod_Empleo", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(xmd2, "Cod_Linea", DbType.String, W.Cod_Linea)
                    db.AddInParameter(xmd2, "Cod_SubLinea", DbType.String, W.Cod_SubLinea)
                    db.AddInParameter(xmd2, "User", DbType.String, W.User)
                    db.AddInParameter(xmd2, "Opcion", DbType.String, "AGR")
                    IntRes = db.ExecuteNonQuery(xmd2, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If
                Next


                db.AddInParameter(cmd4, "Cod_Cia", DbType.String, EmpleoLabor.Cod_Cia)
                db.AddInParameter(cmd4, "Cod_Empleo", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd4, "Opcion", DbType.String, "ELI")

                IntRes = db.ExecuteNonQuery(cmd4, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                For Each W As ETEmpleoLabor In Cantera
                    Dim xmd3 As DbCommand = db.GetStoredProcCommand(usp_RAL.EmpleoLabor_Cantera)
                    db.AddInParameter(xmd3, "Cod_Cia", DbType.String, W.Cod_Cia)
                    db.AddInParameter(xmd3, "Cod_Area", DbType.String, W.Cod_Area)
                    db.AddInParameter(xmd3, "Cod_Empleo", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(xmd3, "Cod_Cantera", DbType.String, W.Cod_Cantera)
                    db.AddInParameter(xmd3, "User", DbType.String, W.User)
                    db.AddInParameter(xmd3, "Opcion", DbType.String, "AGR")
                    IntRes = db.ExecuteNonQuery(xmd3, Trans)

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

#Region "Eliminar Emnpleo Labor"
    Public Function EliminarEmpleoLabor(ByVal EmpleoLabor As ETEmpleoLabor) As ETResultado

        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.EmpleoLabor)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, EmpleoLabor.Cod_Cia)
                db.AddInParameter(cmd, "Cod_Empleo", DbType.String, EmpleoLabor.Cod_Empleo)
                db.AddInParameter(cmd, "User", DbType.String, EmpleoLabor.User)
                db.AddInParameter(cmd, "Opcion", DbType.String, "ANU")

                IntRes = db.ExecuteNonQuery(cmd, Trans)

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

    '   *****   TABLAS  *****

#Region "Listar Empleo Labor"
    Public Function ListarEmpleoLabor(ByVal Empleo As ETEmpleoLabor, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Listar_EmpleoLabor)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Empleo.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Area", DbType.String, Empleo.Cod_Area)
            db.AddInParameter(cmd, "Cod_Empleo", DbType.String, Empleo.Cod_Empleo)
            db.AddInParameter(cmd, "Cod_Prov", DbType.String, Empleo.Cod_Prov)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarEmpleoLabor = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Listar Activo x Empleo Labor"
    Public Function ListarActivo(ByVal Empleo As ETEmpleoLabor, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.EmpleoLabor_Activo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Empleo.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Area", DbType.String, Empleo.Cod_Area)
            db.AddInParameter(cmd, "Cod_Empleo", DbType.String, Empleo.Cod_Empleo)
            db.AddInParameter(cmd, "Cod_Activo", DbType.String, Empleo.Cod_Activo)
            db.AddInParameter(cmd, "Linea", DbType.String, Empleo.Cod_Linea)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, Empleo.Cod_Cantera)
            db.AddInParameter(cmd, "FechaInicio", DbType.Date, Empleo.Fecha.ToShortDateString)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Empleo.FechaTermino)
            db.AddInParameter(cmd, "Cod_Prov", DbType.String, Empleo.Cod_Prov)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarActivo = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Listar Cantera x Empleo Labor"
    Public Function ListarCantera(ByVal Empleo As ETEmpleoLabor, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.EmpleoLabor_Cantera)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Empleo.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Area", DbType.String, Empleo.Cod_Area)
            db.AddInParameter(cmd, "Cod_Empleo", DbType.String, Empleo.Cod_Empleo)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, Empleo.Cod_Cantera)
            db.AddInParameter(cmd, "Cod_Prov", DbType.String, Empleo.Cod_Prov)
            db.AddInParameter(cmd, "Fecha", DbType.Date, Empleo.Fecha.ToShortDateString)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Empleo.FechaTermino)
            db.AddInParameter(cmd, "Anio", DbType.Int32, Empleo.Anio)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarCantera = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Cantera"
    Public Function Cantera(ByVal Empleo As ETEmpleoLabor, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarCantera)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Empleo.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Empleo", DbType.String, Empleo.Cod_Empleo)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Cantera = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Contratista Cantera"
    Public Function ContratistaCantera(ByVal Empleo As ETEmpleoLabor, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarContratista_Cantera)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Empleo.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, Empleo.Cod_Cantera)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ContratistaCantera = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

End Class