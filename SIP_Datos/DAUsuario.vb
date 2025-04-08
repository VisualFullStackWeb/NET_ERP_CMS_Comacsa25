Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Exception
Public Class DAUsuario

    Public Function ConsultarPermisos(ByVal U As ETUsuario) As ETObjecto
        'MsgBox(ConfigurationManager.ConnectionStrings("cn"))
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarPermisos)
        Dim E_Objecto As ETObjecto
        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, U.Tipo)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Sistema", DbType.String, gSistema)
            db.AddInParameter(cmd, "Usuario", DbType.String, U.Usuario)
            db.AddInParameter(cmd, "Contrasenha", DbType.String, U.Contrasenha)
            db.AddInParameter(cmd, "Formulario", DbType.String, U.Formulario)
            db.AddInParameter(cmd, "Operacion", DbType.String, U.Operacion)
            db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
            db.ExecuteNonQuery(cmd)
            E_Objecto = New ETObjecto
            E_Objecto.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
        Return E_Objecto
    End Function

    Public Function ConsultarConexion(ByVal O As ETObjecto) As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarConexion)
        Dim E_Objecto As ETObjecto
        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, O.Tipo)
            db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
            db.AddOutParameter(cmd, "Valor", DbType.String, 16)
            db.ExecuteNonQuery(cmd)
            E_Objecto = New ETObjecto
            E_Objecto.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
            E_Objecto.ValorxTexto = Convert.ToString(db.GetParameterValue(cmd, "Valor"))
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
        Return E_Objecto
    End Function

    Public Function ConsultarFechaHora(ByVal O As ETObjecto) As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarConexion)
        Dim E_Objecto As ETObjecto
        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, O.Tipo)
            db.AddOutParameter(cmd, "Respuesta", DbType.String, 16)
            db.AddOutParameter(cmd, "Fecha", DbType.Date, 6)
            db.ExecuteNonQuery(cmd)
            E_Objecto = New ETObjecto
            E_Objecto.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
            E_Objecto.Fecha = Convert.ToDateTime(db.GetParameterValue(cmd, "Fecha"))
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
        Return E_Objecto

    End Function

    Public Function ConsultarUsuario() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarUsuario)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Sistema", DbType.String, gSistema)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Usuario = New ETUsuario
                    With Entidad.Usuario
                        .Usuario = dr.GetString(dr.GetOrdinal("Usuario"))
                        .Contrasenha = dr.GetString(dr.GetOrdinal("Contrasenha"))
                        .Encargado = dr.GetString(dr.GetOrdinal("Encargado"))
                        .Email = dr.GetString(dr.GetOrdinal("Email"))
                        .Estado = dr.GetString(dr.GetOrdinal("Estado"))
                        .Admin = dr.GetString(dr.GetOrdinal("Admin"))
                        .AprobPedido = dr.GetString(dr.GetOrdinal("Aprueba"))
                        .VerPedidoxArea = dr.GetString(dr.GetOrdinal("Ver"))
                        If IsDBNull(dr.GetString(dr.GetOrdinal("PlaCod"))) Then
                            .PlaCod = ""
                        Else
                            .PlaCod = dr.GetString(dr.GetOrdinal("PlaCod"))
                        End If

                    End With
                    lResult.Ls_Usuario.Add(Entidad.Usuario)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult

    End Function
    Public Function MantenimientoUsuarioArea(ByVal obj As ETUsuario) As String

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoAreaxUsuario)
        Dim lResult As ETMyLista = Nothing
        Dim RPTA As String

        Try
            db.AddInParameter(cmd, "COD_CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "USUARIO", DbType.String, obj.Usuario)
            db.AddInParameter(cmd, "AREA", DbType.String, obj.Area)
            db.AddInParameter(cmd, "LOGIN", DbType.String, obj.Login)
            db.AddInParameter(cmd, "STATUS", DbType.String, obj.ActionArea)

            db.ExecuteNonQuery(cmd)
            RPTA = Convert.ToString(db.GetParameterValue(cmd, "@LOGIN"))
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing

        End Try
        Return RPTA
    End Function
    Public Function ConsultarDisponibilidadUsuario(ByVal Usuario As ETUsuario) As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarDisponibilidadUsuario)
        Dim O As ETObjecto
        Try
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Sistema", DbType.String, gSistema)
            db.AddInParameter(cmd, "Login", DbType.String, Usuario.Login)
            db.AddOutParameter(cmd, "Respuesta", DbType.Int16, Nothing)
            db.ExecuteNonQuery(cmd)
            O = New ETObjecto
            O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
        Return O
    End Function

    Public Function MantenimientoUsuario(ByVal U As ETUsuario, ByVal L As List(Of ETUsuario)) As ETObjecto
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxUsuario)
        Dim smd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantenimientoERP)
        Dim O As New ETObjecto

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "Tipo", DbType.Int16, U.Tipo)
                db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Sistema", DbType.String, gSistema)
                db.AddInParameter(cmd, "Login", DbType.String, U.Login)
                db.AddInParameter(cmd, "Contrasenha", DbType.String, U.Contrasenha)
                db.AddInParameter(cmd, "Estado", DbType.String, U.Estado)
                db.AddInParameter(cmd, "Encargardo", DbType.String, U.Encargado)
                db.AddInParameter(cmd, "Email", DbType.String, U.Email)
                db.AddInParameter(cmd, "Admin", DbType.String, U.Admin)
                db.AddInParameter(cmd, "PlaCod", DbType.String, U.PlaCod)
                db.AddInParameter(cmd, "AprobPedido", DbType.String, U.AprobPedido)
                db.AddInParameter(cmd, "VerPedidoxArea", DbType.String, U.VerPedidoxArea)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

                db.ExecuteNonQuery(cmd, Trans)

                O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                If O.Respuesta <> 0 Then
                    Err.Raise(10)
                End If

                If U.Grupo <> String.Empty Then

                    For Each W As ETUsuario In L

                        Dim xmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantenimientoERP)

                        db.AddInParameter(xmd, "Tipo", DbType.Int16, 1)
                        db.AddInParameter(xmd, "KeyForm", DbType.String, W.KeyForm)
                        db.AddInParameter(xmd, "Login", DbType.String, U.Login)
                        db.AddInParameter(xmd, "Usuario", DbType.String, U.Usuario)

                        IntRes = db.ExecuteNonQuery(xmd, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If

                    Next


                    For Each W As ETUsuario In L

                        Dim xmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantenimientoERP)

                        db.AddInParameter(xmd, "Tipo", DbType.Int16, 2)
                        db.AddInParameter(xmd, "KeyForm", DbType.String, W.KeyForm)
                        db.AddInParameter(xmd, "KeyOpe", DbType.String, W.KeyOpe)
                        db.AddInParameter(xmd, "Login", DbType.String, U.Login)
                        db.AddInParameter(xmd, "Usuario", DbType.String, U.Usuario)
                        db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)

                        db.ExecuteNonQuery(xmd, Trans)

                        O.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                        If O.Respuesta <> 0 Then
                            Err.Raise(10)
                        End If

                    Next

                End If

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return O

    End Function

    Public Function ConsultarOpcionesUsuario(ByVal U As ETUsuario) As List(Of ETUsuario)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.OpcionesERP)

        Dim lst As New List(Of ETUsuario)
        Dim R As ETUsuario = Nothing
        Try

            db.AddInParameter(cmd, "Grupo", DbType.String, U.Grupo)
            db.AddInParameter(cmd, "Sistema", DbType.String, U.Sistema)
            db.AddInParameter(cmd, "Usuario", DbType.String, U.Usuario)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    R = New ETUsuario
                    R.Grupo = dr.GetString(dr.GetOrdinal("Grupo"))
                    R.KeyForm = dr.GetInt32(dr.GetOrdinal("KeyForm"))
                    R.Formulario = dr.GetString(dr.GetOrdinal("Formulario"))
                    R.KeyOpe = dr.GetInt32(dr.GetOrdinal("KeyOpe"))
                    R.Operacion = dr.GetString(dr.GetOrdinal("Operacion"))
                    R.Action = dr.GetBoolean(dr.GetOrdinal("Action"))
                    lst.Add(R)
                End While
                If Not dr Is Nothing Then
                    dr.Close()
                End If
            End Using
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
        Return lst
    End Function

    Public Function ConsultarAyuda(ByVal Rpt As ETUsuario) As ETUsuario

        Dim lResult As ETUsuario = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarPermisos)

        Try
            db.AddInParameter(cmd, "Tipo", DbType.String, 4)
            db.AddInParameter(cmd, "Formulario", DbType.String, Rpt.KeyForm)

            lResult = New ETUsuario

            lResult.ValorxTexto = db.ExecuteScalar(cmd)
            lResult.Validacion = Boolean.TrueString

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = New ETUsuario
        End Try

        Return lResult

    End Function


    '================ ALMACEN =================

    '   *****   USP_RAL_USERS   *****
    '   Opcion = "LSI" :    Listar Usuarios x Sistema
    '   Opcion = "LME" :    Listar Menu x Usuario
    '   Opcion = "DUS" :    Datos Usuario
    '   Opcion = "PLA" :    Planilla Total
    '   Opcion = "PCO" :    Usuario x Codigo
    '   Opcion = "VLO" :    Validar Login
    '   Opcion = "LTO" :    Usuarios Sispedal
    '   Opcion = "COL" :    Listar Colaborador Almacen
    '   Opcion = "VAL" :    Validar User recojo    


#Region "PermisoEditarLiquidaciones"
    '@ID  @USUARIO   @FECHA    @MOTIVO
    '---------------------------------
    '@01  JSIESQUEN  05012023  Permisos para editar registros en liquidación


    '@01 Add ini
    Public Function ListarPermisoEditarLiquidaciones(ByVal Usuario As ETUsuario) As Boolean
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand("usp_Pel_Users")
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            db.AddInParameter(cmd, "usuario", DbType.String, Usuario.Login)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            If Tabla.Rows.Count > 0 Then
                ListarPermisoEditarLiquidaciones = True
            Else
                ListarPermisoEditarLiquidaciones = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
    '@01 Add fin
#End Region
#Region "Validar Users"
    Public Function Users(ByVal User As ETUsuario) As Boolean

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Users)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Login", DbType.String, User.Login)
            db.AddInParameter(cmd, "Password", DbType.String, User.Contrasenha)
            db.AddInParameter(cmd, "Sistema", DbType.String, User.Sistema)
            db.AddInParameter(cmd, "Opcion", DbType.String, "ACC")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            If Tabla.Rows.Count > 0 Then
                Users = True
            Else
                Users = False
            End If
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function
#End Region

#Region "Listar Users"
    Public Function ListarUsers(ByVal User As ETUsuario, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Users)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, User.Cod_Cia)
            db.AddInParameter(cmd, "Login", DbType.String, User.Login)
            db.AddInParameter(cmd, "Sistema", DbType.String, User.Sistema)
            db.AddInParameter(cmd, "Password", DbType.String, User.Contrasenha)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarUsers = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Listar Menus"
    Public Function ListarMenus(ByVal User As ETUsuario) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConsultarOpcionesUsuario)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Sistema", DbType.String, User.Sistema)
            db.AddInParameter(cmd, "Usuario", DbType.String, User.Login)
            db.AddInParameter(cmd, "Grupo", DbType.String, User.Grupo)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarMenus = Tabla


        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Listar Menu X Users"
    Public Function ListarMenuUsers3(ByVal Users As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConsultarMenuUsuario)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing


        Try
            db.AddInParameter(cmd, "@Login", DbType.String, Users)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarMenuUsers3 = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Listar Tools"
    Public Function ListarTools(ByVal Login As String, ByVal Form As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConsultarToolsMenuUsuario)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing


        Try
            db.AddInParameter(cmd, "Login", DbType.String, Login)
            db.AddInParameter(cmd, "Form", DbType.String, Form)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarTools = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Listar Descripcion Diseño"
    Public Function ListarDescripcionDiseno(ByVal KeyForm As String, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DisenoSispedal)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing


        Try
            db.AddInParameter(cmd, "KeyForm", DbType.String, KeyForm)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarDescripcionDiseno = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "ConsultarBD"
    Public Function ConsultarConexion(ByVal Tipo As Integer) As ETResultado
        Dim ETResultado As New ETResultado
        Dim ResultadoBE1 As New ETResultado
        Dim ResultadoBE2 As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConsultarConexion)

        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Tipo)
            db.AddOutParameter(cmd, "Valor", DbType.String, 20)
            db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
            db.AddOutParameter(cmd, "Fecha", DbType.DateTime, 20)
            db.ExecuteNonQuery(cmd)

            ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Valor"))
            ResultadoBE1.Mensaje = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
            ResultadoBE2.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Fecha"))

            If ETResultado.Mensaje <> "" And ResultadoBE1.Mensaje = "0" Then
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

#Region "Obtener el area del Usuario"
    Public Function Obtener_AreaUsuario(ByVal User As ETUsuario, ByVal Opcion As String) As String
        Dim lResult As String = String.Empty
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Users)


        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, User.Cod_Cia)
            db.AddInParameter(cmd, "Login", DbType.String, User.Login)
            db.AddInParameter(cmd, "Sistema", DbType.String, User.Sistema)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            lResult = db.ExecuteScalar(cmd)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)

        End Try
        Return lResult
    End Function

#End Region

#Region "Validar si es area de Mantenimiento"
    Public Function Obtener_AreaMantto(ByVal User As ETUsuario, ByVal Opcion As String) As Boolean
        Dim lResult As Boolean = Boolean.FalseString
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Users)


        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, User.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Area", DbType.String, User.Login)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            lResult = db.ExecuteScalar(cmd)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)

        End Try
        Return lResult
    End Function

#End Region

    '     MANTENIMIENTO   

#Region "Agregar Users x Sistema"
    Public Function AgregarUsers(ByVal UsersBE As ETUsuario, ByVal B As List(Of ETUsuario), ByVal C As List(Of ETUsuario)) As ETResultado
        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Users)
        Dim smd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantenimientoOpciones)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, UsersBE.Cod_Cia)
                db.AddInParameter(cmd, "Login", DbType.String, UsersBE.Login)
                db.AddInParameter(cmd, "Name_User", DbType.String, UsersBE.Name_User)
                db.AddInParameter(cmd, "Password", DbType.String, UsersBE.Contrasenha)
                db.AddInParameter(cmd, "Sistema", DbType.String, UsersBE.Sistema)
                db.AddInParameter(cmd, "Encargado", DbType.String, UsersBE.Encargado)
                db.AddInParameter(cmd, "CodigoEmpleado", DbType.String, UsersBE.PlaCod)
                db.AddInParameter(cmd, "Stock_min", DbType.String, UsersBE.Vi_Stkm)
                db.AddInParameter(cmd, "Status", DbType.String, UsersBE.Status)
                db.AddInParameter(cmd, "Email", DbType.String, UsersBE.Email)
                db.AddInParameter(cmd, "Admin", DbType.String, UsersBE.Admin)
                db.AddInParameter(cmd, "User", DbType.String, UsersBE.User_Crea)
                db.AddInParameter(cmd, "Opcion", DbType.String, "AGR")

                IntRes = db.ExecuteNonQuery(cmd, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                If UsersBE.Grupo <> String.Empty Then

                    db.AddInParameter(smd, "Tipo", DbType.Int16, 1)
                    db.AddInParameter(smd, "Sistema", DbType.String, UsersBE.Sistema)
                    db.AddInParameter(smd, "Grupo", DbType.String, UsersBE.Grupo)
                    db.AddInParameter(smd, "Login", DbType.String, UsersBE.Login)
                    db.AddInParameter(smd, "Usuario", DbType.String, UsersBE.Name_User)
                    db.AddOutParameter(smd, "Respuesta", DbType.Int16, 10)

                    IntRes = db.ExecuteNonQuery(smd, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    For Each W As ETUsuario In B
                        Dim xmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantenimientoOpciones)

                        db.AddInParameter(xmd, "Tipo", DbType.Int16, 2)
                        db.AddInParameter(xmd, "Sistema", DbType.String, UsersBE.Sistema)
                        db.AddInParameter(xmd, "KeyForm", DbType.String, W.Formulario)
                        db.AddInParameter(xmd, "KeyOpe", DbType.String, W.Operacion)
                        db.AddInParameter(xmd, "Login", DbType.String, UsersBE.Login)
                        db.AddInParameter(xmd, "Usuario", DbType.String, UsersBE.Name_User)
                        IntRes = db.ExecuteNonQuery(xmd, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If

                    Next

                    For Each W As ETUsuario In C
                        Dim xmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantenimientoOpciones)

                        db.AddInParameter(xmd, "Tipo", DbType.Int16, 2)
                        db.AddInParameter(xmd, "Sistema", DbType.String, UsersBE.Sistema)
                        db.AddInParameter(xmd, "KeyForm", DbType.String, W.Formulario)
                        db.AddInParameter(xmd, "KeyOpe", DbType.String, W.Operacion)
                        db.AddInParameter(xmd, "Login", DbType.String, UsersBE.Login)
                        db.AddInParameter(xmd, "Usuario", DbType.String, UsersBE.Name_User)
                        IntRes = db.ExecuteNonQuery(xmd, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If
                    Next
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

#Region "Cambio de Password Users"
    Public Function UpdateCambioPassword(ByVal UsersBE As ETUsuario) As ETResultado
        Dim ETResultado As New ETResultado

        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Users)


        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, UsersBE.Cod_Cia)
                db.AddInParameter(cmd, "Login", DbType.String, UsersBE.Login)
                db.AddInParameter(cmd, "Sistema", DbType.String, UsersBE.Sistema)
                db.AddInParameter(cmd, "Password", DbType.String, UsersBE.Contrasenha)
                db.AddInParameter(cmd, "Opcion", DbType.String, "UPD")

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

    '   ===================================================================================================

    '   *****   usp_RAL_UsersAreaAprobacionRequerimiento    *****
    '   Opcion  :   1   =>  Agregar Area Aprobacion Requerimiento
    '   Opcion  :   5   =>  Eliminar Area Aprobacion Requerimiento

    '  MANTENIMIENTO

#Region "Agregar Areas de aprobacion para Requerimiento y/o Orden Compra"

    Public Function AreaAprobacionRequerimiento(ByVal UsersBE As ETUsuario _
                                                , ByVal Requerimiento As List(Of ETUsuario) _
                                                , ByVal OrdenCompra As List(Of ETUsuario) _
                                                , ByVal Opcion As String) As ETResultado
        Dim ETResultado As New ETResultado

        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.UsersAreaAprobacionRequerimiento)
        Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.AgregarMostrarFirmaUsers)
        Dim cmd3 As DbCommand = db.GetStoredProcCommand(usp_RAL.UsersAreaAprobacionOC)



        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                If Opcion = "S" Then
                    db.AddInParameter(cmd2, "codcia", DbType.String, UsersBE.Cod_Cia)
                    db.AddInParameter(cmd2, "login", DbType.String, UsersBE.Login)
                    db.AddInParameter(cmd2, "firma", DbType.Binary, UsersBE.Firma)
                    db.AddInParameter(cmd2, "Sistema", DbType.String, UsersBE.Sistema)
                    db.AddInParameter(cmd2, "Tipo", DbType.String, "1")
                    IntRes = db.ExecuteNonQuery(cmd2, Trans)
                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If
                End If


                db.AddInParameter(cmd3, "CodCia", DbType.String, UsersBE.Cod_Cia)
                db.AddInParameter(cmd3, "Usuario", DbType.String, UsersBE.Name_User)
                db.AddInParameter(cmd3, "Tipo", DbType.String, "5")

                IntRes = db.ExecuteNonQuery(cmd3, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                For Each W In OrdenCompra
                    Dim cmd4 As DbCommand = db.GetStoredProcCommand(usp_RAL.UsersAreaAprobacionOC)
                    db.AddInParameter(cmd4, "CodCia", DbType.String, W.Cod_Cia)
                    db.AddInParameter(cmd4, "Login", DbType.String, W.Login)
                    db.AddInParameter(cmd4, "Area", DbType.String, W.Area)
                    db.AddInParameter(cmd4, "Usuario", DbType.String, W.User_Crea)
                    db.AddInParameter(cmd4, "Tipo", DbType.String, "1")

                    IntRes = db.ExecuteNonQuery(cmd4, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                Next

                db.AddInParameter(cmd, "CodCia", DbType.String, UsersBE.Cod_Cia)
                db.AddInParameter(cmd, "Usuario", DbType.String, UsersBE.Name_User)
                db.AddInParameter(cmd, "Tipo", DbType.String, "5")

                IntRes = db.ExecuteNonQuery(cmd, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                For Each W In Requerimiento
                    Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.UsersAreaAprobacionRequerimiento)
                    db.AddInParameter(cmd1, "CodCia", DbType.String, W.Cod_Cia)
                    db.AddInParameter(cmd1, "Login", DbType.String, W.Name_User)
                    db.AddInParameter(cmd1, "Area", DbType.String, W.Area)
                    db.AddInParameter(cmd1, "Usuario", DbType.String, W.User_Crea)
                    db.AddInParameter(cmd1, "Tipo", DbType.String, "1")

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

#Region "Eliminar Areas de aprobacion para Requerimiento y/o Orden Compra"

    Public Function EliminarAreaAprobacionRequerimiento(ByVal UsersBE As ETUsuario) As ETResultado
        Dim ETResultado As New ETResultado

        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.AgregarMostrarFirmaUsers)
        Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.UsersAreaAprobacionRequerimiento)
        Dim cmd3 As DbCommand = db.GetStoredProcCommand(usp_RAL.UsersAreaAprobacionOC)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd1, "codcia", DbType.String, UsersBE.Cod_Cia)
                db.AddInParameter(cmd1, "login", DbType.String, UsersBE.Name_User)
                db.AddInParameter(cmd1, "Sistema", DbType.String, UsersBE.Sistema)
                db.AddInParameter(cmd1, "Tipo", DbType.String, "9")
                IntRes = db.ExecuteNonQuery(cmd1, Trans)
                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                db.AddInParameter(cmd2, "CodCia", DbType.String, UsersBE.Cod_Cia)
                db.AddInParameter(cmd2, "Usuario", DbType.String, UsersBE.Name_User)
                db.AddInParameter(cmd2, "Tipo", DbType.String, "5")

                IntRes = db.ExecuteNonQuery(cmd2, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                db.AddInParameter(cmd3, "CodCia", DbType.String, UsersBE.Cod_Cia)
                db.AddInParameter(cmd3, "Usuario", DbType.String, UsersBE.Name_User)
                db.AddInParameter(cmd3, "Tipo", DbType.String, "5")

                IntRes = db.ExecuteNonQuery(cmd3, Trans)

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

#Region "Firmas Digitales"

    Public Function FirmasDigitales(ByVal Firma As List(Of ETUsuario)) As ETResultado
        Dim ETResultado As New ETResultado

        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.UsersAreaAprobacionRequerimiento)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                For Each W In Firma
                    db.AddInParameter(cmd, "CodCia", DbType.String, W.Cod_Cia)
                    db.AddInParameter(cmd, "Login", DbType.String, W.Login)
                    db.AddInParameter(cmd, "Area", DbType.String, W.Area)
                    db.AddInParameter(cmd, "Usuario", DbType.String, W.User_Crea)
                    db.AddInParameter(cmd, "Tipo", DbType.String, W.Opcion)
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

    '   ===================================================================================================

    '   *****   usp_RAL_AgregarMostrarFirmaUsers
    '   Opcion  :   4   =>  Listar Areas x Usuario
    '   Opcion  :   5   =>  Listar Users x Firma
    '   Opcion  :   2   =>  Mostrar Imagen
    '   Opcion  :   8   =>  Usuarios de Aprobacion por Areas

#Region "Users Firma"
    Public Function UsersFirma(ByVal User As ETUsuario, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.AgregarMostrarFirmaUsers)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CodCia", DbType.String, User.Cod_Cia)
            db.AddInParameter(cmd, "login", DbType.String, User.Login)
            db.AddInParameter(cmd, "sistema", DbType.String, User.Sistema)
            db.AddInParameter(cmd, "Tipo", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            UsersFirma = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function
#End Region

#Region "Mostrar Firma"
    Public Function MostrarFirma(ByVal User As ETUsuario) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.AgregarMostrarFirmaUsers)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CodCia", DbType.String, User.Cod_Cia)
            db.AddInParameter(cmd, "login", DbType.String, User.Login)
            db.AddInParameter(cmd, "sistema", DbType.String, User.Sistema)
            db.AddInParameter(cmd, "Tipo", DbType.String, "2")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            MostrarFirma = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   ******  usp_RAL_Cia *****
    '       Opcion  LIS =>  Listar Compañia

#Region "Listar CIA"
    Public Function ListarCia(ByVal User As ETUsuario, ByVal Opcion As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Cia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "login", DbType.String, User.Login)
            db.AddInParameter(cmd, "sistema", DbType.String, User.Sistema)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarCia = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function
#End Region



#Region "Listar Proveedores Cia"

    Public Function ListarProveedoresCia(ByVal User As ETUsuario) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ProveedoresCia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CodCia", DbType.String, User.Cod_Cia)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarProveedoresCia = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function
#End Region


    '   *****   usp_RAL_MovimientosAlmacen      *****
    '   Opcion  :   LMU     =>  Listar Tipo de Movimientos por Usuario
    '   Opcion  :   LAU     =>  Listar Almacenes por Usuario
    '   Opcion  :   AUX     =>  Listar Almacenes Destino por Usuario
    '   Opcion  :   LDR     =>  Listar Documentos Referencia

#Region "Movimientos de Almacen"
    Public Function MovimientosAlmacen(ByVal User As ETUsuario, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MovimientosAlmacen)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, User.Cod_Cia)
            db.AddInParameter(cmd, "Usuario", DbType.String, User.Name_User)
            db.AddInParameter(cmd, "Cod_Almacen", DbType.String, User.Cod_Almacen)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            MovimientosAlmacen = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function MovimientosAlmacen_NC() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MovimientosAlmacen_NC)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "Cod_Cia", DbType.String, User.Cod_Cia)
            'db.AddInParameter(cmd, "Usuario", DbType.String, User.Name_User)
            'db.AddInParameter(cmd, "Cod_Almacen", DbType.String, User.Cod_Almacen)
            'db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            MovimientosAlmacen_NC = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Area_Usuario(ByVal usuario As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Area_Usuario)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@codmae", DbType.String, "01044")
            db.AddInParameter(cmd, "@status", DbType.String, "")
            db.AddInParameter(cmd, "@user", DbType.String, usuario)
            'db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Area_Usuario = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function


    Public Function DocIdentidad_Usuario(ByVal usuario As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DocIdentidad_Usuario)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@codmae", DbType.String, "01032")
            db.AddInParameter(cmd, "@status", DbType.String, "")
            'db.AddInParameter(cmd, "@user", DbType.String, usuario)
            'db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            DocIdentidad_Usuario = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function MotivoTrabsladoSunat_Usuario(ByVal usuario As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MotivosTrasladoSunat_Usuario)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@pa_IdCodigoSunat", DbType.String, "*")
            'db.AddInParameter(cmd, "@status", DbType.String, "")
            'db.AddInParameter(cmd, "@user", DbType.String, usuario)
            'db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            MotivoTrabsladoSunat_Usuario = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function


    Public Function ListarAlmacen(ByVal usuario As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarAlmacen)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarAlmacen = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListarAlmacenSolicitante(ByVal usuario As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarAlmacenSolicitante)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarAlmacenSolicitante = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Carga_Empleo(ByVal cod_maestro2 As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Carga_Empleo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@cod_maestro2", DbType.String, cod_maestro2)
            'db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Carga_Empleo = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region

    Public Function ConsultarERP_1(ByVal Rpt As ETUsuario) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaERP)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Rpt.Tipo)
            db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Usuario = New ETUsuario
                    With Entidad.Usuario
                        .Sistema = dr.GetString(dr.GetOrdinal("Sistema"))
                    End With
                    lResult.Ls_Usuario.Add(Entidad.Usuario)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult

    End Function

    Public Function ConsultarERP_2(ByVal Rpt As ETUsuario) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaERP)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Rpt.Tipo)
            db.AddInParameter(cmd, "Sistema", DbType.String, Rpt.Sistema)
            db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Usuario = New ETUsuario
                    With Entidad.Usuario
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .Grupo = dr.GetString(dr.GetOrdinal("Grupo"))
                        .Tipo = dr.GetInt16(dr.GetOrdinal("Tipo"))
                        .Jerarquia = dr.GetInt16(dr.GetOrdinal("Jerarquia"))
                        .KeyForm = dr.GetInt32(dr.GetOrdinal("KeyForm"))
                        .Formulario = dr.GetString(dr.GetOrdinal("Formulario"))
                        '.Sistema = dr.GetString(dr.GetOrdinal("Sistema"))
                    End With
                    lResult.Ls_Usuario.Add(Entidad.Usuario)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult

    End Function

    Public Function ConsultarERP_3(ByVal Rpt As ETUsuario) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaERP)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Rpt.Tipo)
            db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "KeyForm", DbType.Int32, Rpt.KeyForm)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Usuario = New ETUsuario
                    With Entidad.Usuario
                        .KeyOpe = dr.GetInt32(dr.GetOrdinal("KeyOpe"))
                    End With
                    lResult.Ls_Usuario.Add(Entidad.Usuario)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult

    End Function

#Region "Grabar Formulario"
    Public Function GrabarFormulario(ByVal UsersBE As ETUsuario) As ETResultado
        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantenimientoFormularios)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "ID", DbType.Int32, UsersBE.ID)
                db.AddInParameter(cmd, "Sistema", DbType.String, UsersBE.Sistema)
                db.AddInParameter(cmd, "Grupo", DbType.String, UsersBE.Grupo)
                db.AddInParameter(cmd, "Tipo", DbType.String, UsersBE.Tipo)
                db.AddInParameter(cmd, "Jerarquia", DbType.String, UsersBE.Jerarquia)
                db.AddInParameter(cmd, "KeyForm", DbType.String, UsersBE.KeyForm)
                db.AddInParameter(cmd, "Formulario", DbType.String, UsersBE.Formulario)
                db.AddInParameter(cmd, "User", DbType.String, UsersBE.Usuario)
                db.AddInParameter(cmd, "Status", DbType.String, UsersBE.Estado)
                db.AddOutParameter(cmd, "Mensaje", DbType.Int32, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int32, 1)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToInt32(db.GetParameterValue(cmd, "Mensaje"))


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

    Public Function ListarFormulario() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantenimientoFormularios)

        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Opcion", DbType.Int32, 2)
            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Usuario = New ETUsuario
                    With Entidad.Usuario
                        .Formulario = dr.GetString(dr.GetOrdinal("Formulario"))
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .IDSistema = dr.GetString(dr.GetOrdinal("IDSistema"))
                        .Sistema = dr.GetString(dr.GetOrdinal("Sistema"))
                        .IDGrupo = dr.GetString(dr.GetOrdinal("IDGrupo"))
                        .Grupo = dr.GetString(dr.GetOrdinal("Grupo"))
                        .Tipo = dr.GetInt16(dr.GetOrdinal("Tipo"))
                        .Jerarquia = dr.GetInt16(dr.GetOrdinal("Jerarquia"))
                        .KeyForm = dr.GetInt32(dr.GetOrdinal("KeyForm"))
                        .Estado = dr.GetString(dr.GetOrdinal("Estado"))
                    End With
                    lResult.Ls_Usuario.Add(Entidad.Usuario)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult
    End Function


    Public Function ListarFormulario(ByVal U As ETUsuario, ByVal Opcion As Integer) As DataTable
        '   Opcion  :   3   =>  Listar Formulario Padre
        '   Opcion  :   4   =>  Listar Grupos por Sistema


        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantenimientoFormularios)


        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Sistema", DbType.String, U.Sistema)
            db.AddInParameter(cmd, "Grupo", DbType.String, U.Grupo)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarFormulario = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function

End Class
