Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Exception


Public Class DAMaestros2
    Inherits ETObjecto


#Region "Listar Documentos Tecnicos"
    Public Function ListarDocumentosTecnicos() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarDocumentosTecnicos1)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Opcion", DbType.String, "LIS")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable

            If Ds IsNot Nothing AndAlso Ds.Tables.Count <> 0 Then
                Tabla = Ds.Tables(0).Copy
            End If

            ListarDocumentosTecnicos = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Listar Area"
    '   *****   usp_RAL_ListarArea  *****  
    '   Opcion  :   LIS     =>  Listar Area Solicitante
    '   Opcion  :   LSI     =>  Listar Sistemas

    Public Function ListarAreaSolicitante(ByVal Opcion As String) As DataTable


        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarArea)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarAreaSolicitante = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    '#Region "Listar Sistemas"
    '    Public Function ListarSistemas() As DataTable
    '        Dim dt As New DataTable
    '        Using cnx As New SqlConnection(ConnectionString.ConnectionString)
    '            Using cmd As New SqlCommand("usp_RAL_ListarArea", cnx)
    '                With cmd
    '                    .Parameters.AddWithValue("@Opcion", "LSI")
    '                    .CommandType = CommandType.StoredProcedure
    '                End With
    '                Try
    '                    cnx.Open()
    '                    Dim da As New SqlDataAdapter(cmd)
    '                    da.Fill(dt)
    '                    cnx.Close()
    '                Catch ex As Exception
    '                    Throw
    '                End Try
    '            End Using
    '        End Using
    '        Return dt
    '    End Function
    '#End Region


#End Region

#Region "Listar EmpleoLabor"
    Public Function ListarEmpleoLabor(ByVal Codigo As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarEmpleoLabor)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cod_maestro2", DbType.String, Codigo)
            db.AddInParameter(cmd, "Opcion", DbType.String, "LIS")

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

#Region "Listar Estado Actual"
    Public Function ListarEstado() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarEstadoActual)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Opcion", DbType.String, "LIS")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarEstado = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Listar Activo"
    Public Function ListarActivo(ByVal Cia As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarActivo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)

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

    Public Function ListarTipoActivo() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConsultarTipoEquipo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarTipoActivo = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region

#Region "Listar Descripcion Activo"

    '   *****   ListarDescripcionActivo     *****
    '   Opcion  :   LNU     =>  Listar Descripcion Activo 
    '   Opcion  :   LMO     =>  Listar Descripcion Activo Modificar

    Public Function ListarDescripcionActivo(ByVal Cia As String, ByVal Activo As String, ByVal Empleo As String, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarDescripcionActivo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)
            db.AddInParameter(cmd, "Cod_Activo", DbType.String, Activo)
            db.AddInParameter(cmd, "Cod_Empleo", DbType.String, Empleo)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarDescripcionActivo = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function


    '#Region "Listar Descripcion Activo"
    '    Public Function ListarDescripcionActivoNuevo(ByVal maestro As Maestros2BE) As DataTable
    '        Dim dt As New DataTable
    '        Using cnx As New SqlConnection(ConnectionString.ConnectionString)
    '            Using cmd As New SqlCommand("usp_RAL_ListarDescripcionActivo", cnx)
    '                With cmd
    '                    .Parameters.AddWithValue("@Cod_Cia", maestro.Cias)
    '                    .Parameters.AddWithValue("@Cod_Activo", maestro.Cod_Maestro2)
    '                    .Parameters.AddWithValue("@Opcion", "LNU")
    '                    .CommandType = CommandType.StoredProcedure
    '                End With
    '                Try
    '                    cnx.Open()
    '                    Dim da As New SqlDataAdapter(cmd)
    '                    da.Fill(dt)
    '                    cnx.Close()
    '                Catch ex As Exception
    '                    Throw
    '                End Try
    '            End Using
    '        End Using
    '        Return dt
    '    End Function
    '#End Region

    '#Region "Listar Descripcion Activo Modificar"
    '    Public Function ListarDescripcionActivo(ByVal maestro As Maestros2BE) As DataTable
    '        Dim dt As New DataTable
    '        Using cnx As New SqlConnection(ConnectionString.ConnectionString)
    '            Using cmd As New SqlCommand("usp_RAL_ListarDescripcionActivo", cnx)
    '                With cmd
    '                    .Parameters.AddWithValue("@Cod_Cia", maestro.Cias)
    '                    .Parameters.AddWithValue("@Cod_Activo", maestro.Cod_Maestro2)
    '                    .Parameters.AddWithValue("@Cod_Empleo", maestro.Empleo)
    '                    .Parameters.AddWithValue("@Opcion", "LMO")
    '                    .CommandType = CommandType.StoredProcedure
    '                End With
    '                Try
    '                    cnx.Open()
    '                    Dim da As New SqlDataAdapter(cmd)
    '                    da.Fill(dt)
    '                    cnx.Close()
    '                Catch ex As Exception
    '                    Throw
    '                End Try
    '            End Using
    '        End Using
    '        Return dt
    '    End Function
    '#End Region
#End Region

#Region "Listar EmpleoLabor"

    '   *****   usp_RAL_Maestros_2  ***** 
    '   Opcion  :   LUD     =>  Listar Unidad de Despacho
    '   Opcion  :   LTP     =>  Listar Tipo de Productos
    '   Opcion  :   LME     =>  Listar Mes
    '   Opcion  :   LLI     =>  Listar Linea de Producto
    '   Opcion  :   LSL     =>  Listar Sub-Linea de Producto
    '   Opcion  :   LCA     =>  Listar Caracteristica del Producto
    '   Opcion  :   LCT     =>  Listar Clasificacion Contable
    '   Opcion  :   LMD     =>  Listar IdUnidad
    '   Opcion  :   LMA     =>  Listar Motivo Anulacion
    '   Opcion  :   LAJ     =>  Listar Motivo Ajuste
    '   Opcion  :   LDR     =>  Listar Documentos de Referencia


    Public Function Listar_Maestros2(ByVal Cia As String, ByVal Linea As String, ByVal SubLinea As String, ByVal UM As String, ByVal Opcion As String, ByVal Cantera As String, ByVal Fecha As Date, ByVal FechaTermino As DateTime) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Maestros_2)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)
            db.AddInParameter(cmd, "Cod_Linea", DbType.String, Linea)
            db.AddInParameter(cmd, "Cod_SubLinea", DbType.String, Linea)
            db.AddInParameter(cmd, "Unidad_Despacho", DbType.String, UM)
            db.AddInParameter(cmd, "Cantera", DbType.String, Cantera)
            db.AddInParameter(cmd, "Fecha", DbType.Date, Fecha.ToShortDateString)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, FechaTermino)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Listar_Maestros2 = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


#Region "Listar Descripcion Plantas Internas Produccion"
    
    Public Function ListarPlantasInternasProduccion() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ReporteCronogramaPdcCriterios)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@pa_planta_geografica", DbType.String, "02")
            'db.AddInParameter(cmd, "Opcion", DbType.String, "LIS")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarPlantasInternasProduccion = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

End Class
