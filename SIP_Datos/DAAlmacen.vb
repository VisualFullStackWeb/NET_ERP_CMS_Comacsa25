Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAAlmacen

    Public Function ConsultarAlmacen5() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarAlmacen)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 5)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarAlmacen5 = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function

    Public Function ConsultarAlmacen6() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarAlmacen)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 6)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarAlmacen6 = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function

    Public Function ConsultarAlmacen1() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarAlmacen)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 1)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarAlmacen1 = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function





    '   *****   USP_RAL_ALMACEN
    '   Opcion  :   LIS =>  Listar Almacen
    '   Opcion  :   GEN =>  Listar Serie Almacen
    '   Opcion  :   XMO =>  Listar Tipo Numeracion
    '   Opcion  :   LXU =>  Listar Users Almacen
    '   Opcion  :   MOV =>  Listar Users Movimientos
    '   Opcion  :   ARE =>  ListarUserArea
    '   Opcion  :   CIE =>  ConsultarPeriodoCierre

    '   ******  usp_RAL_Listar_DocumentosIngresoTransferencia   *****
    '   Opcion  :   L1  =>  Listar Documentos Ingreso x Transferencia
    '   Opcion  :   L2  =>  Listar Detalle Ingreso x Transferencia
    '   Opcion  :   L3  =>  Listar Detalle Ingreso x Transferencia Total


#Region "Listar Almacen"
    Public Function Listar_Almacen(ByVal Almacen As ETAlmacen, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Almacen)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Almacen.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Alm", DbType.String, Almacen.CodAlmacen)
            db.AddInParameter(cmd, "Tipo_mov", DbType.String, Almacen.Tipo_Mov)
            db.AddInParameter(cmd, "Login", DbType.String, Almacen.Login)
            db.AddInParameter(cmd, "Periodo", DbType.String, Almacen.Periodo)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Listar_Almacen = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Obtener Direccion Almacen"
    Public Function DireccionAlmacen(ByVal Almacen As ETAlmacen) As ETResultado
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Almacen)

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Almacen.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Alm", DbType.String, Almacen.CodAlmacen)
            db.AddOutParameter(cmd, "Direccion", DbType.String, 150)
            db.AddInParameter(cmd, "Opcion", DbType.String, "DIR")
            db.ExecuteNonQuery(cmd)

            ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Direccion"))

            If ETResultado.Mensaje <> "" Then
                ETResultado.Realizo = True
            Else
                ETResultado.Realizo = False
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
        Return ETResultado

    End Function
#End Region

#Region "Documentos Ingreso x Transferencia"
    Public Function DocumentosIngresoTransferencia(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DocumentosIngresoTransferencia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "Cod_Almacen", DbType.String, Guia.cod_alm)
            db.AddInParameter(cmd, "Numero_Doc", DbType.String, Guia.numdoc)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            DocumentosIngresoTransferencia = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function
#End Region


End Class
