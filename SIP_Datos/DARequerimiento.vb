Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DARequerimiento

    Public Function MantenimientoRequerimiento(ByVal Rpt As ETRequerimiento, ByVal Ls_Ruma As List(Of ETRuma)) As ETRequerimiento


        Dim lResult As ETRequerimiento = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETRequerimiento

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxRequerimiento)

                db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)
                db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
                db.AddParameter(cmd, "ID", DbType.Int32, 10, _
                                ParameterDirection.InputOutput, True, 0, 0, "", _
                                DataRowVersion.Default, Rpt.ID)
                db.AddParameter(cmd, "NroReq", DbType.String, 10, _
                                ParameterDirection.InputOutput, True, 0, 0, "", _
                                DataRowVersion.Default, Rpt.NroReq)
                db.AddInParameter(cmd, "Fecha", DbType.DateTime, Rpt.FechaLimite)
                db.AddInParameter(cmd, "Prioridad", DbType.String, Rpt.Prioridad)
                db.AddInParameter(cmd, "Observacion", DbType.String, Rpt.Observacion)
                db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                lResult.NroReq = Convert.ToString(db.GetParameterValue(cmd, "NroReq"))
                lResult.ID = Convert.ToInt32(db.GetParameterValue(cmd, "ID"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

                For Each Row In Ls_Ruma

                    Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxRequerimiento)

                    db.AddInParameter(xmd, "Tipo", DbType.Int16, 2)
                    db.AddInParameter(xmd, "Companhia", DbType.String, Companhia)
                    db.AddInParameter(xmd, "ID", DbType.Int32, lResult.ID)
                    db.AddInParameter(xmd, "CodRuma", DbType.String, Row.CodRuma)
                    db.AddInParameter(xmd, "Cantidad", DbType.Decimal, Row.Cantidad)
                    db.AddInParameter(xmd, "Usuario", DbType.String, Rpt.Usuario)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)

                    db.ExecuteNonQuery(xmd, Trans)
                    Rpt.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                    If Rpt.Respuesta <> 0 Then Err.Raise(10)
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

    Public Function ConsultarRequerimiento3(ByVal Rpt As ETRequerimiento) As ETRequerimiento

        Dim lResult As ETRequerimiento = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarRequerimiento)

        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 3)
            db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.ID)

            lResult = New ETRequerimiento

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read()
                    With lResult
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .NroReq = dr.GetString(dr.GetOrdinal("NroReq"))
                        .FechaEmision = dr.GetDateTime(dr.GetOrdinal("FechaCreacion"))
                        .FechaLimite = dr.GetDateTime(dr.GetOrdinal("FechaLimite"))
                        .Observacion = dr.GetString(dr.GetOrdinal("Observacion"))
                        .Prioridad = dr.GetString(dr.GetOrdinal("Prioridad"))
                        .Validacion = Boolean.TrueString
                    End With
                End While
                If dr IsNot Nothing Then dr.Close()
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult

    End Function

    Public Function ConsultarRequerimiento4(ByVal Rpt As ETRequerimiento) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarRequerimiento)

        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 4)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.ID)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read()
                    Entidad.Ruma = New ETRuma
                    With Entidad.Ruma
                        .CodRuma = dr.GetString(dr.GetOrdinal("CodRuma"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                    End With
                    lResult.Ls_Ruma.Add(Entidad.Ruma)
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

    Public Function ConsultarRequerimiento(ByVal Rpt As ETRequerimiento) As ETRequerimiento

        Dim lResult As ETRequerimiento = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarRequerimiento)
        Dim Ds As DataSet = Nothing
        Dim Tabla As DataTable = Nothing

        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Rpt.Tipo)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETRequerimiento
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            If Tabla.Rows.Count > 0 Then
                lResult = New ETRequerimiento
                lResult.Tabla = Tabla.Copy
                lResult.Validacion = Boolean.TrueString
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = New ETRequerimiento

        Finally

            If Tabla IsNot Nothing Then Tabla = Nothing
            If Ds IsNot Nothing Then Ds = Nothing

        End Try

        Return lResult

    End Function

    Public Function EliminarRequerimiento(ByVal Rpt As ETRequerimiento) As ETRequerimiento

        Dim lResult As ETRequerimiento = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxRequerimiento)

                db.AddInParameter(cmd, "Tipo", DbType.Int16, 3)
                db.AddInParameter(cmd, "ID", DbType.String, Rpt.ID)
                db.AddInParameter(cmd, "NroReq", DbType.String, Rpt.NroReq)
                db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

                db.ExecuteNonQuery(cmd, Trans)

                lResult = New ETRequerimiento

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            Finally

                Trans.Commit()
                Conexion.Close()

            End Try

        End Using

        Return lResult

    End Function

    Public Function CRxConsultar_Requerimiento(ByVal Rpt As ETRequerimiento) As ETRequerimiento

        Dim lResult As ETRequerimiento = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.CRxConsultar_Requerimiento)
        Dim Ds As DataSet = Nothing
        Dim Tabla As DataTable = Nothing

        Try
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID", DbType.String, Rpt.ID)

            lResult = New ETRequerimiento
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            If Tabla.Rows.Count > 0 Then
                lResult = New ETRequerimiento
                lResult.Tabla = Tabla.Copy
                lResult.Validacion = Boolean.TrueString
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = New ETRequerimiento

        Finally

            If Tabla IsNot Nothing Then Tabla = Nothing
            If Ds IsNot Nothing Then Ds = Nothing

        End Try

        Return lResult

    End Function

    '=====================================
#Region "Grabar Requerimiento de Compra"
    Public Function GrabarRequerimientoCompra(ByVal Reque As ETRequerimiento, ByVal C As List(Of ETRequerimiento) _
                                                , ByVal Opcion As String, ByVal X As List(Of ETLisMaestroDocumentosTecnicos), _
                                                ByVal R As List(Of ETRequerimiento)) As ETResultado

        Dim Flag As String = ""
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Dim ETResultado As New ETResultado
        Dim NumeroRequerimiento As String = ""
        Dim NumeroInterno As String
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.Detalle_Requerimiento)

        Dim cmd7 As DbCommand = db.GetStoredProcCommand(usp_RAL.NumeracionRequerimiento)
        Dim cmd8 As DbCommand = db.GetStoredProcCommand(usp_RAL.Numeracion2)
        Dim cmd9 As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_Requerimiento01)
        Dim cmd10 As DbCommand = db.GetStoredProcCommand(usp_RAL.RequisicionFirma)


        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                If Opcion = "AGR" Then
                    Flag = FlagRequerimiento(Reque.Cod_Cia, Reque.Area)
                    If IsDBNull(Flag) = True Then
                        Err.Raise(10)
                    End If

                    db.AddInParameter(cmd7, "CODCIA", DbType.String, Reque.Cod_Cia)
                    db.AddInParameter(cmd7, "CODAREA", DbType.String, Reque.Area)
                    db.AddInParameter(cmd7, "USER", DbType.String, Reque.User_Crea)
                    db.AddInParameter(cmd7, "SIGLAS", DbType.String, Flag)
                    db.AddInParameter(cmd7, "AÑO", DbType.String, Year(Now))

                    Ds = New DataSet
                    Ds = db.ExecuteDataSet(cmd7, Trans)
                    Tabla = New DataTable
                    Tabla = Ds.Tables(0).Copy

                    If Tabla.Rows.Count = 0 Then
                        Err.Raise(10)
                    End If

                    ETResultado.Mensaje = Tabla.Rows(0).Item("Numero")

                    db.AddInParameter(cmd8, "cod_cia", DbType.String, Reque.Cod_Cia)
                    db.AddInParameter(cmd8, "documento", DbType.String, "IRE")
                    db.AddInParameter(cmd8, "numero2", DbType.String, "0")

                    Ds = New DataSet
                    Ds = db.ExecuteDataSet(cmd8, Trans)
                    Tabla = New DataTable
                    Tabla = Ds.Tables(0).Copy

                    If Tabla.Rows.Count = 0 Then
                        Err.Raise(10)
                    End If

                    NumeroInterno = Tabla.Rows(0).Item("Numero")


                    ETResultado.Mensaje = ETResultado.Mensaje + "-" + Trim(Flag & "") + "-" + Convert.ToString(Year(Now))
                Else

                    ETResultado.Mensaje = Reque.NroReq
                    NumeroInterno = Reque.Nro_Int
                End If

                db.AddInParameter(cmd9, "Nro_Requi", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd9, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                db.AddInParameter(cmd9, "Lugar_Ent", DbType.String, Reque.Lugar_Ent)
                db.AddInParameter(cmd9, "Area", DbType.String, Reque.Area)
                db.AddInParameter(cmd9, "Nro_Int", DbType.String, NumeroInterno)
                db.AddInParameter(cmd9, "User_Crea", DbType.String, Reque.User_Crea)
                db.AddInParameter(cmd9, "Urgente", DbType.String, Reque.Prioridad)
                db.AddInParameter(cmd9, "DocOri", DbType.String, "")
                db.AddInParameter(cmd9, "NumDocOri", DbType.String, "")
                db.AddInParameter(cmd9, "Opcion", DbType.String, Opcion)

                IntRes = db.ExecuteNonQuery(cmd9, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                db.AddInParameter(cmd10, "Nro_Requerimiento", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd10, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                db.AddInParameter(cmd10, "User", DbType.String, Reque.User_Crea)
                db.AddInParameter(cmd10, "Opcion", DbType.String, "AGR")

                IntRes = db.ExecuteNonQuery(cmd10, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                If Reque.NumDocOri = "0000000" Then
                    Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Detalle_Requerimiento)
                    db.AddInParameter(cmd, "Nro_Requi", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                    db.AddInParameter(cmd, "Opcion", DbType.String, "ELI")

                    IntRes = db.ExecuteNonQuery(cmd, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                End If

                db.AddInParameter(cmd1, "Nro_Requi", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd1, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                db.AddInParameter(cmd1, "Opcion", DbType.String, "EDT")

                IntRes = db.ExecuteNonQuery(cmd1, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                For Each w As ETLisMaestroDocumentosTecnicos In X
                    w.Cod_Cia = Reque.Cod_Cia
                    w.Nro_Requi = ETResultado.Mensaje
                    w.User_Crea = Reque.User_Crea
                Next

                For Each W As ETLisMaestroDocumentosTecnicos In X
                    Dim cmd4 As DbCommand = db.GetStoredProcCommand(usp_RAL.Detalle_Requerimiento)
                    Dim cmd_4 As DbCommand = db.GetStoredProcCommand(usp_RAL.DocumentosTecnicos)

                    If W.Estado = "D" Then
                        db.AddInParameter(cmd4, "Cod_Cia", DbType.String, W.Cod_Cia)
                        db.AddInParameter(cmd4, "Nro_Requi", DbType.String, W.Nro_Requi)
                        db.AddInParameter(cmd4, "Cod_Prod", DbType.String, W.Codigo_Producto)
                        db.AddInParameter(cmd4, "item", DbType.Int16, W.Item)
                        db.AddInParameter(cmd4, "User_Crea", DbType.String, W.User_Crea)
                        db.AddInParameter(cmd4, "Opcion", DbType.String, "DDT")

                        IntRes = db.ExecuteNonQuery(cmd4, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If

                    ElseIf W.Estado = "A" And W.Item <> 0 Then
                        db.AddInParameter(cmd_4, "Cod_Cia", DbType.String, W.Cod_Cia)
                        db.AddInParameter(cmd_4, "Nro_Requi", DbType.String, W.Nro_Requi)
                        db.AddInParameter(cmd_4, "Cod_Prod", DbType.String, W.Codigo_Producto)
                        db.AddInParameter(cmd_4, "item", DbType.Int16, W.Item)
                        db.AddInParameter(cmd_4, "Cod_DocTecnico", DbType.String, W.Cod_DocTecnico)
                        db.AddInParameter(cmd_4, "User", DbType.String, W.User_Crea)

                        IntRes = db.ExecuteNonQuery(cmd_4, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If
                    End If
                Next


                For Each W As ETRequerimiento In C
                    Dim cmd11 As DbCommand = db.GetStoredProcCommand(usp_RAL.Detalle_Requerimiento)
                    Dim cmd04 As DbCommand = db.GetStoredProcCommand(usp_RAL.UPD_DocumentosTecnicos)
                    
                    db.AddInParameter(cmd04, "Nro_Requi", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd04, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                    db.AddInParameter(cmd04, "Cod_Prod", DbType.String, W.CodigoProducto)
                    db.AddInParameter(cmd04, "Item", DbType.Int16, W.Item)

                    IntRes = db.ExecuteNonQuery(cmd04, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    db.AddInParameter(cmd11, "Nro_Requi", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd11, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                    db.AddInParameter(cmd11, "Cod_Prod", DbType.String, W.CodigoProducto)
                    db.AddInParameter(cmd11, "Unidad", DbType.String, W.Unidad)
                    db.AddInParameter(cmd11, "Cantidad", DbType.Decimal, W.Cantidad)
                    db.AddInParameter(cmd11, "Item", DbType.Int16, W.Item)
                    db.AddInParameter(cmd11, "Empleo", DbType.String, W.Empleo)
                    db.AddInParameter(cmd11, "Nro_Int", DbType.String, NumeroInterno)
                    db.AddInParameter(cmd11, "User_Crea", DbType.String, Reque.User_Crea)
                    db.AddInParameter(cmd11, "Memo", DbType.String, W.Memo)
                    db.AddInParameter(cmd11, "Num_Doc", DbType.String, Reque.NumDocOri)
                    db.AddInParameter(cmd11, "Cod_Prov", DbType.String, W.Cod_Prov)
                    db.AddInParameter(cmd11, "RazonSocial", DbType.String, W.Nom_Prov)


                    If Reque.NumDocOri = "0000000" Then
                        db.AddInParameter(cmd11, "Opcion", DbType.String, "AGR")
                    Else
                        db.AddInParameter(cmd11, "Opcion", DbType.String, "XMO")
                    End If

                    IntRes = db.ExecuteNonQuery(cmd11, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    If R IsNot Nothing Then

                        For Each xRow As ETRequerimiento In R
                            Dim cmd12 As DbCommand = db.GetStoredProcCommand(usp_RAL.Almacen_Requerimiento03)
                            db.AddInParameter(cmd12, "Nro_Requi_Union", DbType.String, ETResultado.Mensaje)
                            db.AddInParameter(cmd12, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                            db.AddInParameter(cmd12, "Cod_Prod_Union", DbType.String, W.CodigoProducto)
                            db.AddInParameter(cmd12, "Item_Union", DbType.Int16, W.Item)

                            db.AddInParameter(cmd12, "Nro_Requi_Orig", DbType.String, xRow.NroReq)
                            db.AddInParameter(cmd12, "Cod_Prod_Orig", DbType.String, W.CodigoProducto)
                            db.AddInParameter(cmd12, "Item_Orig", DbType.Int16, xRow.Item)
                            db.AddInParameter(cmd12, "Status", DbType.String, xRow.Status)
                            db.AddInParameter(cmd12, "User", DbType.String, xRow.User_Crea)
                            db.AddInParameter(cmd12, "Tipo", DbType.String, "1")
                            db.ExecuteNonQuery(cmd12, Trans)
                        Next
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

    Public Function GrabarRequerimientoCompraDistribuir(ByVal Producto As List(Of ETListDetalleRequerimiento), _
                                                        ByVal Distribuir As List(Of ETListDetalleRequerimiento)) As ETResultado

        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        
        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                For Each xRow As ETListDetalleRequerimiento In Producto
                    Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.Almacen_Requerimiento04)
                    db.AddInParameter(cmd1, "Nro_Requi_Union", DbType.String, xRow.Nro_Req)
                    db.AddInParameter(cmd1, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd1, "Cod_Prod", DbType.String, xRow.Codigo)
                    db.AddInParameter(cmd1, "Item_Union", DbType.String, xRow.Item)

                    db.AddInParameter(cmd1, "Nro_Requi_Orig", DbType.String, xRow.Nro_Req_Orig)
                    db.AddInParameter(cmd1, "Item_Orig", DbType.String, xRow.Item_Req_Orig)

                    db.AddInParameter(cmd1, "Nro_oc", DbType.String, xRow.Nro_OC)
                    db.AddInParameter(cmd1, "Item_OC", DbType.String, xRow.Item_OC)
                    db.AddInParameter(cmd1, "Cantidad", DbType.Double, xRow.CantidadDist)

                    db.AddInParameter(cmd1, "Status", DbType.String, xRow.Status)
                    db.AddInParameter(cmd1, "User", DbType.String, xRow.Usuario)
                    db.AddInParameter(cmd1, "Tipo", DbType.String, "2")

                    db.ExecuteNonQuery(cmd1, Trans)
                Next


                For Each xRow As ETListDetalleRequerimiento In Distribuir
                    Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.Almacen_Requerimiento04)
                    db.AddInParameter(cmd2, "Nro_Requi_Union", DbType.String, xRow.Nro_Req)
                    db.AddInParameter(cmd2, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd2, "Cod_Prod", DbType.String, xRow.Codigo)
                    db.AddInParameter(cmd2, "Item_Union", DbType.String, xRow.Item)

                    db.AddInParameter(cmd2, "Nro_Requi_Orig", DbType.String, xRow.Nro_Req_Orig)
                    db.AddInParameter(cmd2, "Item_Orig", DbType.String, xRow.Item_Req_Orig)

                    db.AddInParameter(cmd2, "Nro_oc", DbType.String, xRow.Nro_OC)
                    db.AddInParameter(cmd2, "Item_OC", DbType.String, xRow.Item_OC)
                    db.AddInParameter(cmd2, "Cantidad", DbType.Double, xRow.CantidadDist)

                    db.AddInParameter(cmd2, "Status", DbType.String, xRow.Status)
                    db.AddInParameter(cmd2, "User", DbType.String, xRow.Usuario)
                    db.AddInParameter(cmd2, "Tipo", DbType.String, "1")

                    db.ExecuteNonQuery(cmd2, Trans)
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

    Public Function EliminarRequerimientoCompraDistribuir(ByVal Reque As ETRequerimiento) As ETResultado

        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.Almacen_Requerimiento04)
                db.AddInParameter(cmd1, "Nro_Requi_Union", DbType.String, Reque.NroReq)
                db.AddInParameter(cmd1, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                db.AddInParameter(cmd1, "User", DbType.String, Reque.Usuario)
                db.AddInParameter(cmd1, "Tipo", DbType.String, "3")

                db.ExecuteNonQuery(cmd1, Trans)
                
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

#Region "Aprobar - Desaprobar Requerimiento"
    Public Function AprobarRequerimiento(ByVal Requerimiento As List(Of ETRequerimiento)) As ETResultado
        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                For Each w As ETRequerimiento In Requerimiento
                    Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_Requerimiento01)

                    db.AddInParameter(cmd, "Nro_Requi", DbType.String, w.NroReq)
                    db.AddInParameter(cmd, "Cod_Cia", DbType.String, w.Cod_Cia)
                    db.AddInParameter(cmd, "User_Crea", DbType.String, w.User_Crea)
                    db.AddInParameter(cmd, "Aprobada", DbType.String, w.Aprobada)
                    db.AddInParameter(cmd, "Opcion", DbType.String, "APR")
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

#Region "Anular Requerimiento"

    Public Function AnularRequerimientoLogistica(ByVal Logistica As ETRequerimiento) As ETResultado

        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_Requerimiento01)

                db.AddInParameter(cmd, "Nro_Requi", DbType.String, Logistica.NroReq)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Logistica.Cod_Cia)
                db.AddInParameter(cmd, "User_Crea", DbType.String, Logistica.User_Crea)
                db.AddInParameter(cmd, "NumDocOri", DbType.String, Logistica.NumDocOri)
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


    '   *****   usp_RAL_Grabar_Requerimiento01  *****
    '   Opcion  :   LIS     =>  Listar Numero Requerimiento
    '   Opcion  :   VAL     =>  Validar que el Requerimiento NO este Aprobado
    '   Opcion  :   VX      =>  Validar SI el Requerimiento esta Aprobado
    '   Opcion  :   ARE     =>  Validar Desaprobacion de Requerimientos

#Region "Listar Requerimiento Logistica"
    Public Function ListarRequerimientoLogistica(ByVal Reque As ETRequerimiento, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_Requerimiento01)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Reque.Cod_Cia)
            db.AddInParameter(cmd, "DocOri", DbType.String, Reque.DocOri)
            db.AddInParameter(cmd, "Nro_Requi", DbType.String, Reque.NroReq)
            db.AddInParameter(cmd, "NumDocOri", DbType.String, Reque.NumDocOri)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarRequerimientoLogistica = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   *****   usp_RAL_AprobacionRequerimiento *****
    '   Opcion  :   DET     =>  Listar Detalle Requerimiento
    '   Opcion  :   CABO    =>  
    '   Opcion  :   CAB     =>  Listar Cabecera Requerimiento
    '   Opcion  :   DET1    =>  Listar Detalle Requerimiento Aprobacion
    '   Opcion  :   LXD     =>  Listar Requerimientos de Compra


#Region "Listar Requerimiento"
    Public Function ListarRequerimiento(ByVal Reque As ETRequerimiento, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Aprobacion_Requerimiento)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Reque.Cod_Cia)
            db.AddInParameter(cmd, "Usuario", DbType.String, Reque.User_Crea)
            db.AddInParameter(cmd, "Nro_Requi", DbType.String, Reque.NroReq)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Reque.FechaEmision)
            db.AddInParameter(cmd, "FechaFin", DbType.DateTime, Reque.Fec_Aprob)
            db.AddInParameter(cmd, "Aprobada", DbType.String, Reque.Aprobada)
            db.AddInParameter(cmd, "Almacen", DbType.String, Reque.Lugar_Ent)
            db.AddInParameter(cmd, "Nro_Req_Origen", DbType.String, Reque.Nro_Req_Origen)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarRequerimiento = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListarReqCompraConsolidadoDistribuir(ByVal Reque As ETRequerimiento, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Almacen_Requerimiento03)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Reque.Cod_Cia)
            db.AddInParameter(cmd, "Nro_Requi_Union", DbType.String, Reque.NroReq)
            db.AddInParameter(cmd, "Cod_Prod_Union", DbType.String, Reque.CodigoProducto)
            db.AddInParameter(cmd, "Item_Union", DbType.Int16, Reque.Item)
            db.AddInParameter(cmd, "Tipo", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarReqCompraConsolidadoDistribuir = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Validar No Modif. Requerimiento Origen"
    Public Function ValidarRequerimientoOrigen(ByVal Reque As ETRequerimiento) As String

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Aprobacion_Requerimiento)
        Dim LResult As String = String.Empty

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Reque.Cod_Cia)
            db.AddInParameter(cmd, "Nro_Requi", DbType.String, Reque.NroReq)
            db.AddInParameter(cmd, "Opcion", DbType.String, "EXI")

            LResult = db.ExecuteScalar(cmd)
            Return Trim(LResult)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return String.Empty
        End Try

    End Function

#End Region

    '   *****   usp_RAL_EliminarRequerimiento   *****
    '   Opcion  :   UCR     =>  Usuario Creador Requerimiento
    '   Opcion  :   UPV     =>  Usuario Creador Requerimiento  

#Region "Listar Requerimiento"
    Public Function UsuarioRequerimiento(ByVal Reque As ETRequerimiento, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.EliminarRequerimiento)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Reque.Cod_Cia)
            db.AddInParameter(cmd, "Nro_Requi", DbType.String, Reque.NroReq)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            UsuarioRequerimiento = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Listar Promedio Consumo Mensual"
    Public Function ListarPromedioConsumoMensual(ByVal Reque As ETRequerimiento) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Acumulado)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CODCIA", DbType.String, Reque.Cod_Cia)
            db.AddInParameter(cmd, "CODALM", DbType.String, Reque.Lugar_Ent)
            db.AddInParameter(cmd, "TIPPROD", DbType.String, Reque.TipoProducto)
            db.AddInParameter(cmd, "CODPROD", DbType.String, Reque.CodigoProducto)
            db.AddInParameter(cmd, "CODUND", DbType.String, Reque.Unidad)
            db.AddInParameter(cmd, "AÑO", DbType.String, Reque.Ano)
            db.AddInParameter(cmd, "TIPMOV", DbType.String, "18")
            db.AddInParameter(cmd, "TIPDOC", DbType.String, "SO")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarPromedioConsumoMensual = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Consumo del Area en los 2 últimos Años"
    Public Function ConsumoAreaUltimosAños(ByVal Reque As ETRequerimiento) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.AcumuladoFecha)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CODCIA", DbType.String, Reque.Cod_Cia)
            db.AddInParameter(cmd, "CODALM", DbType.String, Reque.Lugar_Ent)
            db.AddInParameter(cmd, "CODAREA", DbType.String, Reque.Area)
            db.AddInParameter(cmd, "TIPPROD", DbType.String, Reque.TipoProducto)
            db.AddInParameter(cmd, "CODPROD", DbType.String, Reque.CodigoProducto)
            db.AddInParameter(cmd, "CODUND", DbType.String, Reque.Unidad)
            db.AddInParameter(cmd, "FECINI", DbType.String, Reque.Inicio)
            db.AddInParameter(cmd, "FECFIN", DbType.String, Reque.Fin)
            db.AddInParameter(cmd, "TIPMOV", DbType.String, "18")
            db.AddInParameter(cmd, "TIPDOC", DbType.String, "SO")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsumoAreaUltimosAños = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Ultimo Proveedor al que se le compro"
    Public Function UltimoProveedorCompra(ByVal Reque As ETRequerimiento) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.UltimaCompra)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CODCIA", DbType.String, Reque.Cod_Cia)
            db.AddInParameter(cmd, "CODALM", DbType.String, Reque.Lugar_Ent)
            db.AddInParameter(cmd, "CODPROD", DbType.String, Reque.CodigoProducto)
            db.AddInParameter(cmd, "TIPMOV", DbType.String, "01")
            db.AddInParameter(cmd, "TIPDOC", DbType.String, "IO")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            UltimoProveedorCompra = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Dias que se demoró en su último pedido"
    Public Function DiasUltimoPedido(ByVal Reque As ETRequerimiento) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DiasDemora)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CODCIA", DbType.String, Reque.Cod_Cia)
            db.AddInParameter(cmd, "CODALM", DbType.String, Reque.Lugar_Ent)
            db.AddInParameter(cmd, "FECHA", DbType.DateTime, Reque.FechaEmision)
            db.AddInParameter(cmd, "TIPPROD", DbType.String, Reque.TipoProducto)
            db.AddInParameter(cmd, "CODPROD", DbType.String, Reque.CodigoProducto)
            db.AddInParameter(cmd, "UNIDAD", DbType.String, Reque.Unidad)
            db.AddInParameter(cmd, "TIPMOV", DbType.String, "01")
            db.AddInParameter(cmd, "TIPDOC", DbType.String, "IO")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            DiasUltimoPedido = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Ultimo despacho que se solicitó en el Area"
    Public Function UltimoDespachoArea(ByVal Reque As ETRequerimiento) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.UltimoDespacho)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CODCIA", DbType.String, Reque.Cod_Cia)
            db.AddInParameter(cmd, "CODALM", DbType.String, Reque.Lugar_Ent)
            db.AddInParameter(cmd, "CODAREA", DbType.String, Reque.Area)
            db.AddInParameter(cmd, "FECHA", DbType.DateTime, Reque.FechaEmision)
            db.AddInParameter(cmd, "TIPPROD", DbType.String, Reque.TipoProducto)
            db.AddInParameter(cmd, "CODPROD", DbType.String, Reque.CodigoProducto)
            db.AddInParameter(cmd, "UNIDAD", DbType.String, Reque.Unidad)
            db.AddInParameter(cmd, "TIPMOV", DbType.String, "01")
            db.AddInParameter(cmd, "TIPDOC", DbType.String, "IO")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            UltimoDespachoArea = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Stock del Mes anterior - Stock Actual"
    Public Function StockMesAnterior(ByVal Reque As ETRequerimiento, ByVal X As String) As ETResultado

        Dim IntRes As Integer = -1
        Dim ETResultado As New ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.SEL_SaldoInicial)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CODCIA", DbType.String, Reque.Cod_Cia)
            db.AddInParameter(cmd, "CODALM", DbType.String, Reque.Lugar_Ent)
            db.AddInParameter(cmd, "año", DbType.String, Reque.Ano)
            db.AddInParameter(cmd, "mes", DbType.String, Reque.Mes)
            db.AddInParameter(cmd, "fechaini", DbType.String, Reque.Inicio)
            db.AddInParameter(cmd, "fechafin", DbType.String, Reque.Fin)
            db.AddInParameter(cmd, "TIPPROD", DbType.String, Reque.TipoProducto)
            db.AddInParameter(cmd, "CODPROD", DbType.String, Reque.CodigoProducto)
            db.AddInParameter(cmd, "tipo", DbType.String, X)
            db.AddOutParameter(cmd, "saldo", DbType.Decimal, 10)

            IntRes = db.ExecuteNonQuery(cmd)

            ETResultado.Mensaje = Convert.ToDecimal(db.GetParameterValue(cmd, "saldo"))


            'If IntRes = -1 Then
            '    Err.Raise(10)
            'End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return ETResultado
    End Function
#End Region

#Region "Consumo del Mes e Ingreso del Mes"
    Public Function Consumo_Ingreso_Mes(ByVal Reque As ETRequerimiento, ByVal Mov As String, ByVal Doc As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.AcumuladoMovimiento)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CODCIA", DbType.String, Reque.Cod_Cia)
            db.AddInParameter(cmd, "CODALM", DbType.String, Reque.Lugar_Ent)
            db.AddInParameter(cmd, "TIPMOV", DbType.String, Mov)
            db.AddInParameter(cmd, "TIPDOC", DbType.String, Doc)
            db.AddInParameter(cmd, "TIPPROD", DbType.String, Reque.TipoProducto)
            db.AddInParameter(cmd, "CODPROD", DbType.String, Reque.CodigoProducto)
            db.AddInParameter(cmd, "CODUND", DbType.String, Reque.Unidad)
            db.AddInParameter(cmd, "Año", DbType.String, Reque.Ano)
            db.AddInParameter(cmd, "Mes", DbType.String, Reque.Mes)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Consumo_Ingreso_Mes = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Ingreso del Mes"
    Public Function IngresoMes(ByVal Reque As ETRequerimiento, ByVal Mov As String, ByVal Doc As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.AcumuladoMovimiento)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CODCIA", DbType.String, Reque.Cod_Cia)
            db.AddInParameter(cmd, "CODALM", DbType.String, Reque.Lugar_Ent)
            db.AddInParameter(cmd, "CODAREA", DbType.String, Reque.Lugar_Ent)
            db.AddInParameter(cmd, "FECHA", DbType.DateTime, Reque.FechaEmision)
            db.AddInParameter(cmd, "TIPMOV", DbType.String, "18")
            db.AddInParameter(cmd, "TIPDOC", DbType.String, "SO")
            db.AddInParameter(cmd, "TIPPROD", DbType.String, Reque.TipoProducto)
            db.AddInParameter(cmd, "CODPROD", DbType.String, Reque.CodigoProducto)
            db.AddInParameter(cmd, "UNIDAD", DbType.String, Reque.Unidad)
            db.AddInParameter(cmd, "Año", DbType.String, Reque.Ano)
            db.AddInParameter(cmd, "Mes", DbType.DateTime, Reque.Mes)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            IngresoMes = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Listar Requerimiento Compra"
    Public Function ListarRequerimientoCompra() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Detalle_Requerimiento)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Opcion", DbType.String, "LXN")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarRequerimientoCompra = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Listar NombreCorto"
    Public Function ListarNombreCorto(ByVal Detalle As ETRequerimiento, ByVal Opcion As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ValidarNombreCorto)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Detalle.Cod_Cia)
            db.AddInParameter(cmd, "NombreCorto", DbType.String, Detalle.Nom_Prov)
            db.AddInParameter(cmd, "Cod_Proveedor", DbType.String, Detalle.Cod_Prov)
            db.AddInParameter(cmd, "User", DbType.String, Detalle.User_Crea)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarNombreCorto = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function
#End Region


End Class
