Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Data.SqlClient

Public Class DAFCB
    Public Function Eliminar_Fileconcep(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_eliminar_concepto_file")
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "@id", DbType.Int32, id)
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@user", DbType.String, User)
                db.ExecuteNonQuery(cmd, Trans)
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

    Public Function Eliminar_Natuconcep(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_eliminar_concep_natu")
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "@id", DbType.Int32, id)
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@user", DbType.String, User)
                db.ExecuteNonQuery(cmd, Trans)
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

    Public Function Eliminar_Provconcep(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_eliminar_concep_prov")
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "@id", DbType.Int32, id)
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@user", DbType.String, User)
                db.ExecuteNonQuery(cmd, Trans)
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

    Public Function Guardar_Grupo(ByVal obj As ETFCB, ByVal Opcion As String) As ETResultado

        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grabar_grupo")
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "@gru_descripcion", DbType.String, obj.descripcion)
                db.AddInParameter(cmd, "@cia", DbType.String, obj.cia)
                db.AddInParameter(cmd, "@user", DbType.String, obj.Usuario)
                db.AddInParameter(cmd, "@opcion", DbType.Int32, Opcion)
                db.AddInParameter(cmd, "@gru_id", DbType.Int32, obj.ID)
                db.AddInParameter(cmd, "@ingreso", DbType.Int32, obj.ingreso)

                db.ExecuteNonQuery(cmd, Trans)
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

    Public Function ListarGrupos() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_listar_grupos")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarGrupos = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function



    Public Function Validardcambio(ByVal tabl As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_validar_dcambio")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@campo", DbType.Int32, tabl)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Validardcambio = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function
    Public Function ListarSubGrupos(ByVal gru_id As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_listar_subgruposxgrupo")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@gru_id", DbType.Int32, gru_id)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarSubGrupos = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ListarTipos() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_listar_tipo")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarTipos = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ListarMovxTipos(ByVal tipid As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_listar_movimientosxtipo")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@tipo", DbType.Int32, tipid)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarMovxTipos = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function


    Public Function ListarMovxconcepto(ByVal gru_id As Integer, ByVal sg_id As Integer, ByVal con_id As Integer, ByVal cia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_tipmovimientosxconcepto")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@gru_id", DbType.Int32, gru_id)
            db.AddInParameter(cmd, "@sg_id", DbType.Int32, sg_id)
            db.AddInParameter(cmd, "@con_id", DbType.Int32, con_id)
            db.AddInParameter(cmd, "@cia", DbType.String, cia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarMovxconcepto = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    'Public Function Guardar_TipoMov(ByVal obj As ETFCB, ByVal Opcion As String) As ETResultado
    '    Dim ETResultado As New ETResultado
    '    Dim db As Database = DatabaseFactory.CreateDatabase()
    '    Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grabar_concepto_tipo")
    '    Using Conexion As DbConnection = db.CreateConnection()
    '        Conexion.Open()
    '        Dim Trans As DbTransaction = Conexion.BeginTransaction()
    '        Try
    '            db.AddInParameter(cmd, "@gru_id", DbType.Int32, obj.grupo)
    '            db.AddInParameter(cmd, "@sg_id", DbType.Int32, obj.subgrupo)
    '            db.AddInParameter(cmd, "@con_id", DbType.Int32, obj.ID)

    '            db.AddInParameter(cmd, "@tipo", DbType.Int32, obj.Tipo)
    '            db.AddInParameter(cmd, "@cia", DbType.String, obj.cia)

    '            db.AddInParameter(cmd, "@user", DbType.String, obj.Usuario)
    '            db.AddInParameter(cmd, "@ciamaestro", DbType.String, obj.ciamaestro)
    '            db.AddInParameter(cmd, "@cod_maestro2", DbType.String, obj.codmaestro)
    '            db.AddInParameter(cmd, "@cod_maestro3", DbType.String, obj.positivo)
    '            db.ExecuteNonQuery(cmd, Trans)
    '            Trans.Commit()
    '            Conexion.Close()
    '            ETResultado.Realizo = True
    '        Catch Err As Exception
    '            Trans.Rollback()
    '            Conexion.Close()
    '            ETResultado.Realizo = False
    '            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
    '            Return Nothing
    '        End Try
    '    End Using
    '    Return ETResultado
    'End Function
    Public Function Guardar_TipoMov(ByVal Rpt As ETFCB, ByVal Ls_Entrega As List(Of ETFCB)) As ETFCB

        Dim lResult As ETFCB = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETFCB
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grabar_concepto_tipo")
                    db.AddInParameter(xmd, "@gru_id", DbType.Int32, Rpt.grupo)
                    db.AddInParameter(xmd, "@sg_id", DbType.Int32, Rpt.subgrupo)
                    db.AddInParameter(xmd, "@con_id", DbType.Int32, Rpt.concepto)
                    db.AddInParameter(xmd, "@tipo", DbType.Int32, Rpt.Tipo)
                    db.AddInParameter(xmd, "@cia", DbType.String, Rpt.cia)
                    db.AddInParameter(xmd, "@user", DbType.String, Rpt.Usuario)
                    db.AddInParameter(xmd, "@ciamaestro", DbType.String, Rpt.ciamaestro)
                    db.AddInParameter(xmd, "@cod_maestro2", DbType.String, Rpt.codmaestro)
                    db.AddInParameter(xmd, "@cod_maestro3", DbType.String, Rpt.codmaestro3)

                    db.ExecuteNonQuery(xmd, Trans)
                Next
                lResult.Validacion = Boolean.TrueString
                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try
        End Using

        Return lResult

    End Function

    Public Function Guardar_Concepto(ByVal obj As ETFCB, ByVal Opcion As String) As ETResultado
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grabar_concepto")
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "@con_descripcion", DbType.String, obj.descripcion)
                db.AddInParameter(cmd, "@cia", DbType.String, obj.cia)
                db.AddInParameter(cmd, "@positivo", DbType.Int32, obj.positivo)
                db.AddInParameter(cmd, "@user", DbType.String, obj.Usuario)
                db.AddInParameter(cmd, "@opcion", DbType.Int32, Opcion)
                db.AddInParameter(cmd, "@con_id", DbType.Int32, obj.ID)
                db.AddInParameter(cmd, "@gru_id", DbType.Int32, obj.grupo)
                db.AddInParameter(cmd, "@sg_id", DbType.Int32, obj.subgrupo)
                db.AddInParameter(cmd, "@dcambio", DbType.Int32, obj.dcambio)
                db.AddInParameter(cmd, "@dprov", DbType.Int32, obj.dprov)
                db.ExecuteNonQuery(cmd, Trans)

                'If obj.dcambio = 1 Then
                '    Dim xmd As DbCommand = db.GetStoredProcCommand("usp_fcb_update_dcambio")
                '    db.AddInParameter(xmd, "@con_id", DbType.Int32, obj.ID)
                '    db.ExecuteNonQuery(xmd, Trans)
                'End If

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

    Public Function ListarConceptos() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_listar_conceptos")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarConceptos = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListarConceptosxgrupo(ByVal gru_id As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_listar_conceptosxgrupo")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@gru_id", DbType.Int32, gru_id)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarConceptosxgrupo = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Validar(ByVal des As String, ByVal tab As Integer) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_validar")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@descripcion", DbType.String, des)
            db.AddInParameter(cmd, "@tabla", DbType.Int32, tab)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Validar = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListarProveedores(ByVal gru_id As Integer, ByVal con_id As Integer, ByVal cia As String, ByVal tabl As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_listar_proveedor")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@gru_id", DbType.Int32, gru_id)
            db.AddInParameter(cmd, "@con_id", DbType.Int32, con_id)
            db.AddInParameter(cmd, "@cia", DbType.String, cia)
            db.AddInParameter(cmd, "@tabla", DbType.Int32, tabl)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarProveedores = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Guardar_Proveedor_Concepto(ByVal Rpt As ETFCB, ByVal Ls_Entrega As List(Of ETFCB)) As ETFCB

        Dim lResult As ETFCB = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETFCB
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grabar_prov_concep")
                    db.AddInParameter(xmd, "@gru_id", DbType.Int32, Row.grupo)
                    db.AddInParameter(xmd, "@sg_id", DbType.Int32, Row.subgrupo)
                    db.AddInParameter(xmd, "@con_id", DbType.Int32, Row.concepto)
                    db.AddInParameter(xmd, "@cod_prov", DbType.String, Row.proveedor)
                    db.AddInParameter(xmd, "@cia", DbType.String, Row.cia)
                    db.AddInParameter(xmd, "@user", DbType.String, Row.Usuario)
                    db.ExecuteNonQuery(xmd, Trans)
                Next
                lResult.Validacion = Boolean.TrueString
                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try
        End Using

        Return lResult

    End Function

    Public Function ListarProvConcepto(ByVal gru_id As Integer, ByVal sg_id As Integer, ByVal con_id As Integer, ByVal cia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_proveedoresxconcepto")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@gru_id", DbType.Int32, gru_id)
            db.AddInParameter(cmd, "@sg_id", DbType.Int32, sg_id)
            db.AddInParameter(cmd, "@con_id", DbType.Int32, con_id)
            db.AddInParameter(cmd, "@cia", DbType.String, cia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarProvConcepto = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ListarNaturalezaConcepto(ByVal gru_id As Integer, ByVal sg_id As Integer, ByVal con_id As Integer, ByVal cia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_naturalezaxconcepto")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@gru_id", DbType.Int32, gru_id)
            db.AddInParameter(cmd, "@sg_id", DbType.Int32, sg_id)
            db.AddInParameter(cmd, "@con_id", DbType.Int32, con_id)
            db.AddInParameter(cmd, "@cia", DbType.String, cia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarNaturalezaConcepto = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ListarFileConcepto(ByVal gru_id As Integer, ByVal sg_id As Integer, ByVal con_id As Integer, ByVal cia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_filexconcepto")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@gru_id", DbType.Int32, gru_id)
            db.AddInParameter(cmd, "@sg_id", DbType.Int32, sg_id)
            db.AddInParameter(cmd, "@con_id", DbType.Int32, con_id)
            db.AddInParameter(cmd, "@cia", DbType.String, cia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarFileConcepto = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Guardar_Naturaleza_Concepto(ByVal Rpt As ETFCB, ByVal Ls_Entrega As List(Of ETFCB)) As ETFCB

        Dim lResult As ETFCB = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETFCB
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grabar_natu_concep")
                    db.AddInParameter(xmd, "@gru_id", DbType.Int32, Row.grupo)
                    db.AddInParameter(xmd, "@sg_id", DbType.Int32, Row.subgrupo)
                    db.AddInParameter(xmd, "@con_id", DbType.Int32, Row.concepto)
                    db.AddInParameter(xmd, "@codigo", DbType.String, Row.proveedor)
                    db.AddInParameter(xmd, "@cia", DbType.String, Row.cia)
                    db.AddInParameter(xmd, "@user", DbType.String, Row.Usuario)
                    db.ExecuteNonQuery(xmd, Trans)
                Next
                lResult.Validacion = Boolean.TrueString
                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try
        End Using

        Return lResult

    End Function

    Public Function Guardar_File_Concepto(ByVal Rpt As ETFCB, ByVal Ls_Entrega As List(Of ETFCB)) As ETFCB

        Dim lResult As ETFCB = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETFCB
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grabar_file_concep")
                    db.AddInParameter(xmd, "@gru_id", DbType.Int32, Row.grupo)
                    db.AddInParameter(xmd, "@sg_id", DbType.Int32, Row.subgrupo)
                    db.AddInParameter(xmd, "@con_id", DbType.Int32, Row.concepto)
                    db.AddInParameter(xmd, "@fil_id", DbType.String, Row.proveedor)
                    db.AddInParameter(xmd, "@cia", DbType.String, Row.cia)
                    db.AddInParameter(xmd, "@user", DbType.String, Row.Usuario)
                    db.ExecuteNonQuery(xmd, Trans)
                Next
                lResult.Validacion = Boolean.TrueString
                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try
        End Using

        Return lResult

    End Function

    Public Function ListarNaturaleza(ByVal cia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_listar_naturaleza")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@cia", DbType.String, cia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarNaturaleza = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ListarCaracteristicaxNaturaleza(ByVal gru_id As Integer, ByVal con_id As Integer, ByVal nat As String, ByVal cia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_caracteriticaxnat")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@gru_id", DbType.Int32, gru_id)
            db.AddInParameter(cmd, "@con_id", DbType.Int32, con_id)
            db.AddInParameter(cmd, "@nat", DbType.String, nat)
            db.AddInParameter(cmd, "@cia", DbType.String, cia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarCaracteristicaxNaturaleza = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ListarDocxConcepto(ByVal gru_id As Integer, ByVal sg_id As Integer, ByVal con_id As Integer, ByVal cia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_documentosxconcepto")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@gru_id", DbType.Int32, gru_id)
            db.AddInParameter(cmd, "@sg_id", DbType.Int32, sg_id)
            db.AddInParameter(cmd, "@con_id", DbType.Int32, con_id)
            db.AddInParameter(cmd, "@cia", DbType.String, cia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarDocxConcepto = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Guardar_Doc_Concepto(ByVal Rpt As ETFCB, ByVal Ls_Entrega As List(Of ETFCB)) As ETFCB

        Dim lResult As ETFCB = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETFCB
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grabar_doc_concep")
                    db.AddInParameter(xmd, "@gru_id", DbType.Int32, Row.grupo)
                    db.AddInParameter(xmd, "@sg_id", DbType.Int32, Row.subgrupo)
                    db.AddInParameter(xmd, "@con_id", DbType.Int32, Row.concepto)
                    db.AddInParameter(xmd, "@codigo", DbType.String, Row.proveedor)
                    db.AddInParameter(xmd, "@cia", DbType.String, Row.cia)
                    db.AddInParameter(xmd, "@user", DbType.String, Row.Usuario)
                    db.ExecuteNonQuery(xmd, Trans)
                Next
                lResult.Validacion = Boolean.TrueString
                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try
        End Using

        Return lResult

    End Function

    Public Function Eliminar_Doc_concep(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_eliminar_doc_concep")
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "@id", DbType.Int32, id)
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@user", DbType.String, User)
                db.ExecuteNonQuery(cmd, Trans)
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
    ''------------------------------------- xD

    Public Function Guardar_Seteo_Grupo(ByVal obj As ETFCB) As ETResultado

        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grabar_seteo_grupo")
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "@gru_id", DbType.String, obj.cia)
                db.AddInParameter(cmd, "@codigo", DbType.String, obj.cia)
                db.AddInParameter(cmd, "@cia", DbType.String, obj.cia)
                db.AddInParameter(cmd, "@usercrea", DbType.Int32, obj.Usuario)
                db.ExecuteNonQuery(cmd, Trans)
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

    Public Function Listar_Grupos_xagregar(ByVal cia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grupos_xagregar")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@cia", DbType.String, cia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Listar_Grupos_xagregar = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Listar_Grupos_seteados(ByVal cia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grupos_seteados")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@cia", DbType.String, cia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Listar_Grupos_seteados = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Eliminar_grupos(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grupos_quitar")
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "@id", DbType.Int32, id)
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@user", DbType.String, User)
                db.ExecuteNonQuery(cmd, Trans)
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


    Public Function Guardar_Seteo_Concepto(ByVal obj As ETFCB) As ETResultado

        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grabar_seteo_concepto")
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "@gru_id", DbType.String, obj.cia)
                db.AddInParameter(cmd, "@con_id", DbType.String, obj.cia)
                db.AddInParameter(cmd, "@tipo", DbType.String, obj.cia)
                db.AddInParameter(cmd, "@cia", DbType.String, obj.cia)
                db.AddInParameter(cmd, "@usercrea", DbType.Int32, obj.Usuario)
                db.ExecuteNonQuery(cmd, Trans)
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

    Public Function Listar_Concepto_xagregar(ByVal cia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_concep_xagregar")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@gru_id", DbType.String, cia)
            db.AddInParameter(cmd, "@tipo", DbType.String, cia)
            db.AddInParameter(cmd, "@cia", DbType.String, cia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Listar_Concepto_xagregar = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Listar_Conceptos_seteados(ByVal cia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_concep_seteados")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@gru_id", DbType.String, cia)
            db.AddInParameter(cmd, "@tipo", DbType.String, cia)
            db.AddInParameter(cmd, "@cia", DbType.String, cia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Listar_Conceptos_seteados = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Eliminar_Conceptos(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_concep_quitar")
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "@id", DbType.Int32, id)
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@user", DbType.String, User)
                db.ExecuteNonQuery(cmd, Trans)
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


    Public Function Guardar_Subgrupo(ByVal obj As ETFCB, ByVal Opcion As String) As ETResultado
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grabar_subgrupo")
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "@con_descripcion", DbType.String, obj.descripcion)
                db.AddInParameter(cmd, "@cia", DbType.String, obj.cia)
                db.AddInParameter(cmd, "@gru_id", DbType.Int32, obj.grupo)
                db.AddInParameter(cmd, "@user", DbType.String, obj.Usuario)
                db.AddInParameter(cmd, "@opcion", DbType.Int32, Opcion)
                db.AddInParameter(cmd, "@sg_id", DbType.Int32, obj.ID)

                db.ExecuteNonQuery(cmd, Trans)
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

    Public Function ordenar(ByVal Orden As Integer, ByVal Id As Integer, ByVal Tabla As Integer) As ETResultado

        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_ordenar_grupos")
                db.AddInParameter(cmd, "@orden", DbType.Int32, Orden)
                db.AddInParameter(cmd, "@id", DbType.Int32, Id)
                db.AddInParameter(cmd, "@tabla", DbType.Int32, Tabla)
                db.ExecuteNonQuery(cmd, Trans)
                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try
        End Using
        Return ETResultado
    End Function


    Public Function Eliminar_Tipomovconcep(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_eliminar_tipmovimiento")
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "@id", DbType.Int32, id)
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@user", DbType.String, User)
                db.ExecuteNonQuery(cmd, Trans)
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
    '*************** Rporte
    Public Function Rpt_listargrupos() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_rptlistargrupos")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            cmd.CommandTimeout = 6000
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Rpt_listargrupos = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function


    Public Function Rpt_listar_gasto_obras_xmes(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_rpt_gasto_obras_xmes")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            cmd.CommandTimeout = 6000
            db.AddInParameter(cmd, "@picia", DbType.String, cia)
            db.AddInParameter(cmd, "@piayo", DbType.Int32, ayo)
            db.AddInParameter(cmd, "@pimes", DbType.Int32, mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Rpt_listar_gasto_obras_xmes = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Rpt_listarconmay(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_rptt") 'usp_fcb_reporte
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            cmd.CommandTimeout = 6000
            db.AddInParameter(cmd, "@picia", DbType.String, cia)
            db.AddInParameter(cmd, "@piayo", DbType.Int32, ayo)
            db.AddInParameter(cmd, "@pimes", DbType.Int32, mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Rpt_listarconmay = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Rpt_listarobras() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("USP_PROYECTS")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            cmd.CommandTimeout = 6000
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Rpt_listarobras = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Rpt_gasto_acumuladoxobras(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_rpt_gasto_obras_xmes_acumulado")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            cmd.CommandTimeout = 6000
            db.AddInParameter(cmd, "@picia", DbType.String, cia)
            db.AddInParameter(cmd, "@piayo", DbType.Int32, ayo)
            db.AddInParameter(cmd, "@pimes", DbType.Int32, mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Rpt_gasto_acumuladoxobras = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function


    Public Function Rpt_listarconmayacumulado(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_reporte_acumuladoxsubgrupo")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            cmd.CommandTimeout = 6000
            db.AddInParameter(cmd, "@picia", DbType.String, cia)
            db.AddInParameter(cmd, "@piayo", DbType.Int32, ayo)
            db.AddInParameter(cmd, "@pimes", DbType.Int32, mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Rpt_listarconmayacumulado = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Rpt_FlujoCaja(ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("USP_FLUJO_CAJA")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            cmd.CommandTimeout = 6000
            db.AddInParameter(cmd, "@AYO", DbType.Int32, ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Rpt_FlujoCaja = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function saldo_ini_mensual(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_saldo_ini_mensual_v2")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            cmd.CommandTimeout = 6000
            db.AddInParameter(cmd, "@picia", DbType.String, cia)
            db.AddInParameter(cmd, "@piayo", DbType.Int32, ayo)
            db.AddInParameter(cmd, "@pimes", DbType.Int32, mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            saldo_ini_mensual = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function


    Public Function Rpt_listarcuentas(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_lista_cuentas")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            cmd.CommandTimeout = 6000
            db.AddInParameter(cmd, "@picia", DbType.String, cia)
            db.AddInParameter(cmd, "@piayo", DbType.Int32, ayo)
            db.AddInParameter(cmd, "@pimes", DbType.Int32, mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Rpt_listarcuentas = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Rpt_listardetalleconmay(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_reporte_detalle")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            cmd.CommandTimeout = 6000
            db.AddInParameter(cmd, "@picia", DbType.String, cia)
            db.AddInParameter(cmd, "@piayo", DbType.Int32, ayo)
            db.AddInParameter(cmd, "@pimes", DbType.Int32, mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Rpt_listardetalleconmay = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function


    Public Function Rpt_listarmontoxconcepto(ByVal cia As String, ByVal ayo As Integer, ByVal mes As Integer) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_reporte_sumaxconcepto")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            cmd.CommandTimeout = 6000
            db.AddInParameter(cmd, "@picia", DbType.String, cia)
            db.AddInParameter(cmd, "@piayo", DbType.Int32, ayo)
            db.AddInParameter(cmd, "@pimes", DbType.Int32, mes)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            Rpt_listarmontoxconcepto = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function
    ''
    Public Function Guardar_ctacte(ByVal Rpt As ETFCB, ByVal Ls_Entrega As List(Of ETFCB)) As ETFCB

        Dim lResult As ETFCB = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETFCB
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand("usp_fcb_grabar_ctacte")
                    db.AddInParameter(xmd, "@gru_id", DbType.Int32, Row.grupo)
                    db.AddInParameter(xmd, "@sg_id", DbType.Int32, Row.subgrupo)
                    db.AddInParameter(xmd, "@con_id", DbType.Int32, Row.concepto)
                    db.AddInParameter(xmd, "@cgcod", DbType.String, Row.proveedor)
                    db.AddInParameter(xmd, "@cia", DbType.String, Row.cia)
                    db.AddInParameter(xmd, "@user", DbType.String, Row.Usuario)
                    db.ExecuteNonQuery(xmd, Trans)
                Next
                lResult.Validacion = Boolean.TrueString
                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try
        End Using

        Return lResult

    End Function

    Public Function ListarCtactexConcepto(ByVal gru_id As Integer, ByVal sg_id As Integer, ByVal con_id As Integer, ByVal cia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_ctactexconcepto")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "@gru_id", DbType.Int32, gru_id)
            db.AddInParameter(cmd, "@sg_id", DbType.Int32, sg_id)
            db.AddInParameter(cmd, "@con_id", DbType.Int32, con_id)
            db.AddInParameter(cmd, "@cia", DbType.String, cia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)
            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy
            ListarCtactexConcepto = Tabla
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function Eliminar_Ctactexconcep(ByVal id As Integer, ByVal Companhia As String, ByVal User As String) As ETResultado
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_fcb_eliminar_ctactexconcepto")
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "@id", DbType.Int32, id)
                db.AddInParameter(cmd, "@cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@user", DbType.String, User)
                db.ExecuteNonQuery(cmd, Trans)
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

End Class

