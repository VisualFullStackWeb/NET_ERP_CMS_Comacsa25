
Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAMaestro

    Public Function Converciones(ByVal O As ETObjecto) As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.Converciones)
        Dim E As ETObjecto = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, O.Tipo)
            db.AddInParameter(cmd, "FactorOriginal", DbType.String, O.FactorOriginal)
            db.AddInParameter(cmd, "FactorDestino", DbType.String, O.FactorDestino)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                dr.Read()

                E = New ETObjecto

                E.Factor = dr.GetDecimal(dr.GetOrdinal("Factor"))
                E.Operacion = dr.GetString(dr.GetOrdinal("Operacion"))

                If Not dr Is Nothing Then
                    dr.Close()
                End If

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return E

    End Function

    Public Function ConsultasMaestros1() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultasMaestros)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, 1)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultasMaestros1 = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function
    Public Function ConsultasMaestros2(ByVal Ent As ETMaestos2) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Maestro_2)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "CiaMaestro", DbType.String, Ent.CiaMaestro)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultasMaestros2 = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function

    Public Function Consultar_Maestros2(ByVal Ent As ETMaestos2) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Maestro_2)
        db.AddInParameter(cmd, "CiaMaestro", DbType.String, Ent.CiaMaestro)

        Try
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.Maestro2 = New ETMaestos2
                    With Entidad.Maestro2
                        Entidad.Maestro2.CiaMaestro = Ent.CiaMaestro
                        Entidad.Maestro2.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        Entidad.Maestro2.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    End With
                    lResult.Ls_Maestro2.Add(Entidad.Maestro2)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using
        Catch Err As Exception
            MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return lResult
    End Function

    Public Function ObtenerDataTrabajador(ByVal Ent As ETMaestos2) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ObtenerDataTrabajador)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        db.AddInParameter(cmd, "cia", DbType.String, Companhia)
        db.AddInParameter(cmd, "codtrabajador", DbType.String, Ent.Codigo)
        Try


            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ObtenerDataTrabajador = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function
    Public Function ConsultarMonedas(ByVal Ent As ETMaestos2) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Monedas)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try


            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarMonedas = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function
    Public Function ConsultarConceptos(ByVal Ent As ETMaestos2) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_ConceptosSolicitudes)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "tipoconcepto", DbType.Int16, 1)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarConceptos = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function
    Public Function ConsultarPermisos(ByVal Ent As ETMaestos2) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ConsultarPermisos)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "usuario", DbType.String, Ent.Usuario)
            db.AddInParameter(cmd, "sistema", DbType.String, "22")
            db.AddInParameter(cmd, "formulario", DbType.String, Ent.Codigo)
            db.AddInParameter(cmd, "frmvb6", DbType.Int16, 0)
            db.AddInParameter(cmd, "frmvbnet", DbType.Int16, 1)
            db.AddInParameter(cmd, "boton", DbType.String, Ent.Descripcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarPermisos = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function
    Public Function ConsultarArea(ByVal Ent As ETMaestos2) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Areas)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try


            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarArea = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function
    Public Function ConsultaRuma(ByVal Ent As ETMaestos2) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarRumasSeteo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "cod_ruma", DbType.String, Ent.Codigo)


            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultaRuma = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function
    Public Function ConsultasTipoPago(ByVal Ent As ETMaestos2) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.RH_OBTENER_TIPO_INGRESO)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Cia", DbType.String, Companhia)


            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultasTipoPago = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function
    Public Function ConsultasMaestros3(ByVal Ent As ETMaestos2) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Maestro_3)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.String, Ent.Codigo)
            db.AddInParameter(cmd, "Cod_usuario", DbType.String, Ent.Usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultasMaestros3 = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function
End Class
