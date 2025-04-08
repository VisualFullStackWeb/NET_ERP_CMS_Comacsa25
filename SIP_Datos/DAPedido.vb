Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Exception

Public Class DAPedido
    Inherits ETObjecto

    '   Mantenimiento

#Region "Grabar Registro de Pedido"
    Public Function GrabarPedido(ByVal Pedido As ETPedido, ByVal B As List(Of ETPedido), ByVal X As List(Of ETLisMaestroDocumentosTecnicos), ByVal Opcion As String) As ETResultado
        Dim ETResultado As New ETResultado
        Dim ETResultado1 As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Cab_Pedido)
        Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.Det_Pedido)
        Dim cmd3 As DbCommand = db.GetStoredProcCommand(usp_RAL.MaestroDocumentos)


        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd, "Tipo_Doc", DbType.String, Pedido.Tipo_Doc)
                db.AddInParameter(cmd, "Numero_Doc", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd, "Codigo_Almacen", DbType.String, Pedido.Codigo_Almacen)
                db.AddInParameter(cmd, "Cod_Area", DbType.String, Pedido.Codigo_Area)
                db.AddInParameter(cmd, "User_Solicita", DbType.String, Pedido.User)
                db.AddInParameter(cmd, "Fecha_Entrega", DbType.DateTime, Pedido.Fecha)
                db.AddInParameter(cmd, "Estado", DbType.String, Pedido.Estado)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, Pedido.Codigo_Cantera)
                db.AddInParameter(cmd, "Cod_Empleo", DbType.String, Pedido.Codigo_Empleo)
                db.AddInParameter(cmd, "Cod_Proveedor", DbType.String, Pedido.Codigo_Proveedor)
                db.AddInParameter(cmd, "Raz_Social", DbType.String, Pedido.Razon_Social)
                db.AddInParameter(cmd, "Urgente", DbType.String, Pedido.Urgente)
                db.AddInParameter(cmd, "OrdenTrabajo", DbType.String, Pedido.OrdenTrabajo)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 7)
                db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

                IntRes = db.ExecuteNonQuery(cmd, Trans)

                If Opcion = "AGR" Then
                    ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))
                Else
                    ETResultado.Mensaje = Pedido.Numero_Doc
                End If

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                db.AddInParameter(cmd1, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd1, "Tipo_Doc", DbType.String, Pedido.Tipo_Doc)
                db.AddInParameter(cmd1, "Num_Doc", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd1, "Opcion", DbType.String, "ELIM")

                IntRes = db.ExecuteNonQuery(cmd1, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                For Each W As ETPedido In B
                    Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.Det_Pedido)
                    Dim ETResultado3 = New ETResultado
                    Dim ETResultado4 = New ETResultado
                    db.AddInParameter(cmd2, "Cod_Cia", DbType.String, W.Cod_Cia)
                    db.AddInParameter(cmd2, "Tipo_Doc", DbType.String, W.Tipo_Doc)
                    db.AddInParameter(cmd2, "Num_Doc", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd2, "Cod_Empleo", DbType.String, W.Codigo_Empleo)
                    db.AddInParameter(cmd2, "Cod_Producto", DbType.String, W.Codigo_Producto)
                    db.AddInParameter(cmd2, "Desc_Producto", DbType.String, W.Descripcion_Producto)
                    db.AddInParameter(cmd2, "Unidad", DbType.String, W.Unidad)
                    db.AddInParameter(cmd2, "Cantidad_Solicitada", DbType.Decimal, W.Cantidad_Solicitada)
                    db.AddInParameter(cmd2, "Cantidad_Autorizada", DbType.Decimal, W.Cantidad_Autorizada)
                    db.AddInParameter(cmd2, "Cod_Activo", DbType.String, W.Cod_Activo)
                    db.AddInParameter(cmd2, "Cod_Cantera", DbType.String, W.Codigo_Cantera)
                    db.AddInParameter(cmd2, "Ruta_CondTecnicas", DbType.String, W.Ruta_CondTecnicas)
                    db.AddInParameter(cmd2, "Ruta_Imagenes", DbType.String, W.Ruta_Imagenes)
                    db.AddInParameter(cmd2, "CodigoAplicacion", DbType.String, W.Codigo_Aplicacion)
                    db.AddInParameter(cmd2, "Aplicacion", DbType.String, W.Aplicacion)
                    db.AddInParameter(cmd2, "Observaciones", DbType.String, W.Observaciones)
                    db.AddInParameter(cmd2, "UMCompra", DbType.String, W.UMCompra)
                    db.AddInParameter(cmd2, "Item", DbType.Int16, W.Item)
                    db.AddInParameter(cmd2, "Opcion", DbType.String, "AGR")

                    IntRes = db.ExecuteNonQuery(cmd2, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If


                Next

                db.AddInParameter(cmd3, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd3, "Nro_Requi", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd3, "Opcion", DbType.String, "DEL")

                IntRes = db.ExecuteNonQuery(cmd3, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                For Each w As ETLisMaestroDocumentosTecnicos In X
                    w.Cod_Cia = Pedido.Cod_Cia
                    w.Nro_Requi = ETResultado.Mensaje
                    w.User_Crea = Pedido.User
                Next


                For Each W As ETLisMaestroDocumentosTecnicos In X
                    Dim cmd4 As DbCommand = db.GetStoredProcCommand(usp_RAL.MaestroDocumentos)
                    db.AddInParameter(cmd4, "Cod_Cia", DbType.String, W.Cod_Cia)
                    db.AddInParameter(cmd4, "Nro_Requi", DbType.String, W.Nro_Requi)
                    db.AddInParameter(cmd4, "Codigo_Producto", DbType.String, W.Codigo_Producto)
                    db.AddInParameter(cmd4, "Producto", DbType.String, W.Producto)
                    db.AddInParameter(cmd4, "Cod_DocTecnico", DbType.String, W.Cod_DocTecnico)
                    db.AddInParameter(cmd4, "User_Crea", DbType.String, W.User_Crea)
                    If W.Estado = "D" Then
                        db.AddInParameter(cmd4, "Opcion", DbType.String, "ELI")
                    Else
                        db.AddInParameter(cmd4, "Opcion", DbType.String, "AGR")
                    End If

                    IntRes = db.ExecuteNonQuery(cmd4, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                Next



                Dim cmd_doc3 As DbCommand = db.GetStoredProcCommand(usp_RAL.Doc_Pedido)
                Dim Tabla As DataTable = Nothing
                Dim Ds As DataSet = Nothing

                db.AddInParameter(cmd_doc3, "Opcion", DbType.Int32, 4)
                db.AddInParameter(cmd_doc3, "numero_pedido", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd_doc3, "usuario", DbType.String, Pedido.User)

                IntRes = db.ExecuteNonQuery(cmd_doc3, Trans)
                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                For Each W As ETPedido In B
                    Dim xword As Integer = 0
                    Dim ximagen As Integer = 0

                    If W.Ruta_CondTecnicas <> "" Then
                        Dim cmd_doc As DbCommand = db.GetStoredProcCommand(usp_RAL.Doc_Pedido)
                        db.AddInParameter(cmd_doc, "Opcion", DbType.Int32, 1)


                        Ds = New DataSet
                        Ds = db.ExecuteDataSet(cmd_doc, Trans)
                        Tabla = New DataTable
                        Tabla = Ds.Tables(0).Copy

                        xword = Tabla.Rows(0).Item("Numero")
                       


                        Dim Ruta_Destino_Word As String = "\\Server03\siscomacsa$\Documentos_Pedidos\doc" & xword & ".doc"

                        'Try
                        ' My.Computer.FileSystem.MoveFile(W.Ruta_CondTecnicas, Ruta_Destino_Word, True)
                        My.Computer.FileSystem.CopyFile(W.Ruta_CondTecnicas, Ruta_Destino_Word, True)
                        'Catch ex As Exception
                        '    Err.Raise(10)
                        'End Try

                    End If

                    If W.Ruta_Imagenes <> "" Then
                        Dim cmd_doc1 As DbCommand = db.GetStoredProcCommand(usp_RAL.Doc_Pedido)
                        db.AddInParameter(cmd_doc1, "Opcion", DbType.Int32, 2)


                        Ds = New DataSet
                        Ds = db.ExecuteDataSet(cmd_doc1, Trans)
                        Tabla = New DataTable
                        Tabla = Ds.Tables(0).Copy

                        ximagen = Tabla.Rows(0).Item("Numero")

                        Dim Ruta_Destino_Imagen As String = "\\Server03\siscomacsa$\Documentos_Pedidos\img" & ximagen & ".jpg"

                   
                        '  My.Computer.FileSystem.MoveFile(W.Ruta_Imagenes, Ruta_Destino_Imagen, True)
                        My.Computer.FileSystem.CopyFile(W.Ruta_Imagenes, Ruta_Destino_Imagen, True)

                    End If

                    If W.Ruta_CondTecnicas <> "" Or W.Ruta_Imagenes <> "" Then
                        Dim cmd_doc2 As DbCommand = db.GetStoredProcCommand(usp_RAL.Doc_Pedido)
                        db.AddInParameter(cmd_doc2, "Opcion", DbType.Int32, 3)
                        db.AddInParameter(cmd_doc2, "NumWord", DbType.Int32, xword)
                        db.AddInParameter(cmd_doc2, "Numimagen", DbType.Int32, ximagen)
                        db.AddInParameter(cmd_doc2, "numero_pedido", DbType.String, ETResultado.Mensaje)
                        db.AddInParameter(cmd_doc2, "cod_producto", DbType.String, W.Codigo_Producto)
                        db.AddInParameter(cmd_doc2, "item", DbType.Int32, W.Item)
                        db.AddInParameter(cmd_doc2, "usuario", DbType.String, Pedido.User)

                        IntRes = db.ExecuteNonQuery(cmd_doc2, Trans)
                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If


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

#Region "Eliminar Registro de Pedido"
    Public Function EliminarPedido(ByVal Pedido As ETPedido) As ETResultado
        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Cab_Pedido)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd, "Tipo_Doc", DbType.String, Pedido.Tipo_Doc)
                db.AddInParameter(cmd, "Numero_Doc", DbType.String, Pedido.Numero_Doc)
                db.AddInParameter(cmd, "User_Anula", DbType.String, Pedido.User)
                db.AddInParameter(cmd, "Opcion", DbType.String, "ANU")
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
#End Region

#Region "Grabar Autorizacion de Pedido"
    Public Function GrabarAutorizacion(ByVal Pedido As ETPedido, ByVal B As List(Of ETPedido)) As ETResultado
        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Cab_Pedido)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd, "Tipo_Doc", DbType.String, Pedido.Tipo_Doc)
                db.AddInParameter(cmd, "Numero_Doc", DbType.String, Pedido.Numero_Doc)
                db.AddInParameter(cmd, "User_Autoriza", DbType.String, Pedido.User)
                db.AddInParameter(cmd, "Fecha_Entrega", DbType.DateTime, Pedido.Fecha)
                db.AddInParameter(cmd, "Urgente", DbType.String, Pedido.Urgente)
                db.AddInParameter(cmd, "Estado", DbType.String, Pedido.Estado)
                db.AddInParameter(cmd, "Opcion", DbType.String, "AUT")

                IntRes = db.ExecuteNonQuery(cmd, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                For Each W As ETPedido In B
                    Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.Det_Pedido)
                    db.AddInParameter(cmd2, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                    db.AddInParameter(cmd2, "Tipo_Doc", DbType.String, Pedido.Tipo_Doc)
                    db.AddInParameter(cmd2, "Num_Doc", DbType.String, Pedido.Numero_Doc)
                    db.AddInParameter(cmd2, "Cod_Producto", DbType.String, W.Codigo_Producto)
                    db.AddInParameter(cmd2, "Cantidad_Autorizada", DbType.Decimal, W.Cantidad_Autorizada)
                    db.AddInParameter(cmd2, "Item", DbType.Int16, W.Item)
                    db.AddInParameter(cmd2, "Opcion", DbType.String, "AUTO")

                    IntRes = db.ExecuteNonQuery(cmd2, Trans)

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

#Region "Grabar Salida Orden"
    Public Function Grabar_SalidaOrden(ByVal Pedido As ETPedido, ByVal Detalle As List(Of ETPedido)) As ETResultado

        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.UpdateEntregar)
        Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.Det_Pedido)



        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd1, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd1, "SalidaOrden", DbType.String, Pedido.SalidaOrden)
                db.AddInParameter(cmd1, "Opcion", DbType.String, "ACLR")

                IntRes = db.ExecuteNonQuery(cmd1, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd, "Num_Doc", DbType.String, Pedido.Numero_Doc)
                db.AddInParameter(cmd, "User", DbType.String, Pedido.User)

                IntRes = db.ExecuteNonQuery(cmd, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                For Each xRow As ETPedido In Detalle
                    Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_DetGuia)
                    db.AddInParameter(cmd2, "Cod_Cia", DbType.String, xRow.Cod_Cia)
                    db.AddInParameter(cmd2, "Tipo_Mov", DbType.String, xRow.Tipo_Mov)
                    db.AddInParameter(cmd2, "Tipo_Doc", DbType.String, xRow.Tipo_Doc)
                    db.AddInParameter(cmd2, "Numdoc", DbType.String, xRow.SalidaOrden)
                    db.AddInParameter(cmd2, "item", DbType.Int16, xRow.Item)
                    db.AddInParameter(cmd2, "cod_prod", DbType.String, xRow.Codigo_Producto)
                    db.AddInParameter(cmd2, "cant_ing", DbType.Double, xRow.Cantidad_Atendida)
                    db.AddInParameter(cmd2, "Obs", DbType.String, xRow.Observaciones)
                    db.AddInParameter(cmd2, "user_crea", DbType.String, xRow.User)
                    db.AddInParameter(cmd2, "Opcion", DbType.String, "OBS")
                    IntRes = db.ExecuteNonQuery(cmd2, Trans)
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

#Region "Cancelar Autorizacion de Pedido"
    Public Function CancelarAutorizacion(ByVal Pedido As ETPedido) As ETResultado
        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Cab_Pedido)
        Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.Det_Pedido)


        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd, "Tipo_Doc", DbType.String, Pedido.Tipo_Doc)
                db.AddInParameter(cmd, "Numero_Doc", DbType.String, Pedido.Numero_Doc)
                db.AddInParameter(cmd, "User_Autoriza", DbType.String, Pedido.User)
                db.AddInParameter(cmd, "Fecha_Entrega", DbType.DateTime, Pedido.Fecha)
                db.AddInParameter(cmd, "Opcion", DbType.String, "MODI")

                IntRes = db.ExecuteNonQuery(cmd, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                db.AddInParameter(cmd2, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd2, "Tipo_Doc", DbType.String, Pedido.Tipo_Doc)
                db.AddInParameter(cmd2, "Num_Doc", DbType.String, Pedido.Numero_Doc)
                db.AddInParameter(cmd2, "Opcion", DbType.String, "AUMO")

                IntRes = db.ExecuteNonQuery(cmd2, Trans)

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

#Region "Actualizar Entrega Pedido "
    Public Function ActualizarEntregaPedido(ByVal Pedido As ETPedido) As ETResultado
        Dim IntRes As Integer = -1
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.UpdateEntregarRequerimiento)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd, "Num_Doc", DbType.String, Pedido.Numero_Doc)
                db.AddInParameter(cmd, "User", DbType.String, Pedido.User)
                db.AddInParameter(cmd, "User_Recibe", DbType.String, Pedido.User_Recibe)

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

#Region "Grabar Distribución de Pedido"
    Public Function GrabarDistribucionPedido(ByVal Pedido As ETPedido, ByVal B As List(Of ETPedido) _
                                            , ByVal Num1 As Integer, ByVal Num2 As Integer _
                                            , ByVal C_Guia As ETGuia, ByVal X As List(Of ETGuia) _
                                            , ByVal Reque As ETRequerimiento, ByVal C As List(Of ETRequerimiento)) As ETResultado
        Dim Serie As String = ""
        Dim Flag As String = ""
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Dim ETResultado As New ETResultado
        Dim Resultado1BE As New ETResultado
        Dim NumeroRequerimiento As String = ""
        Dim NumeroInterno As String
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.AtenderPedido)

        Dim cmd4 As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_CabGuia)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd, "Tipo_Doc", DbType.String, Pedido.Tipo_Doc)
                db.AddInParameter(cmd, "Numero_Doc", DbType.String, Pedido.Numero_Doc)
                db.AddInParameter(cmd, "User_Atiende", DbType.String, Pedido.User)
                db.AddInParameter(cmd, "Estado", DbType.String, Pedido.Estado)
                db.AddInParameter(cmd, "Urgente", DbType.String, Pedido.Urgente)

                db.AddOutParameter(cmd, "NumeroMovimiento", DbType.String, 7)
                db.AddInParameter(cmd, "Opcion", DbType.String, "ATE")
                IntRes = db.ExecuteNonQuery(cmd, Trans)

                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "NumeroMovimiento"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                For Each w As ETPedido In B
                    Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.Det_Pedido)

                    db.AddInParameter(cmd1, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                    db.AddInParameter(cmd1, "Tipo_Doc", DbType.String, Pedido.Tipo_Doc)
                    db.AddInParameter(cmd1, "Num_Doc", DbType.String, Pedido.Numero_Doc)
                    db.AddInParameter(cmd1, "Cod_Producto", DbType.String, w.Codigo_Producto)
                    db.AddInParameter(cmd1, "Desc_Producto", DbType.String, w.Descripcion_Producto)
                    db.AddInParameter(cmd1, "Unidad", DbType.String, w.Unidad)
                    db.AddInParameter(cmd1, "User", DbType.String, Pedido.User)
                    db.AddInParameter(cmd1, "Opcion", DbType.String, "MCPR")
                    db.AddInParameter(cmd1, "Cantidad_Atendida", DbType.Decimal, w.Cantidad_Atendida)
                    db.AddInParameter(cmd1, "Cantidad_Requerida", DbType.Decimal, w.Cantidad_Requerida)
                    db.AddInParameter(cmd1, "Observaciones", DbType.String, w.Observaciones)
                    db.AddInParameter(cmd1, "Estado", DbType.String, w.Estado)
                    db.AddInParameter(cmd1, "Colaborador", DbType.String, w.Colaborador)
                    db.AddInParameter(cmd1, "NumeroMovimiento", DbType.String, Pedido.NumeroMovimiento)
                    db.AddInParameter(cmd1, "Item", DbType.Int16, w.Item)

                    IntRes = db.ExecuteNonQuery(cmd1, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                Next

                If Num1 > 0 Then
                    Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.NumeroMovimiento)
                    Dim cmd_2 As DbCommand = db.GetStoredProcCommand(usp_RAL.NumeroMovimiento)

                    Serie = SerieMovimiento(Pedido.Cod_Cia, Pedido.Codigo_Almacen)

                    db.AddInParameter(cmd2, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                    db.AddInParameter(cmd2, "Tipo_Mov", DbType.String, "18")
                    db.AddInParameter(cmd2, "Tipo_Doc", DbType.String, "SO")
                    db.AddInParameter(cmd2, "Codigo_Almacen", DbType.String, Pedido.Codigo_Almacen)
                    db.AddInParameter(cmd2, "Serie", DbType.String, Serie)
                    db.AddOutParameter(cmd2, "Numero", DbType.Int32, 7)
                    db.AddInParameter(cmd2, "Opcion", DbType.String, "GEN")

                    IntRes = db.ExecuteNonQuery(cmd2, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    ETResultado.Mensaje = NumeroMovimientoAlmacen(Convert.ToString(db.GetParameterValue(cmd2, "Numero")))
                    db.AddInParameter(cmd_2, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                    db.AddInParameter(cmd_2, "Tipo_Mov", DbType.String, "00")
                    db.AddInParameter(cmd_2, "Tipo_Doc", DbType.String, "MOV")
                    db.AddInParameter(cmd_2, "Codigo_Almacen", DbType.String, Pedido.Codigo_Almacen)
                    db.AddOutParameter(cmd_2, "Numero", DbType.Int32, 7)
                    db.AddInParameter(cmd_2, "Serie", DbType.String, Serie)
                    db.AddInParameter(cmd_2, "Opcion", DbType.String, "GEN")

                    IntRes = db.ExecuteNonQuery(cmd_2, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    Resultado1BE.Mensaje = NumeroMovimientoAlmacen(Convert.ToString(db.GetParameterValue(cmd_2, "Numero")))

                    db.AddInParameter(cmd4, "Cod_Cia", DbType.String, C_Guia.Cod_Cia)
                    db.AddInParameter(cmd4, "Tipo_Mov", DbType.String, C_Guia.Tipo_Mov)
                    db.AddInParameter(cmd4, "Tipo_Doc", DbType.String, C_Guia.Tipo_Doc)
                    db.AddInParameter(cmd4, "NumDoc", DbType.String, Serie & ETResultado.Mensaje)
                    db.AddInParameter(cmd4, "NumInterno", DbType.String, Serie & Resultado1BE.Mensaje)
                    db.AddInParameter(cmd4, "Cod_Alm", DbType.String, C_Guia.Cod_Alm)
                    db.AddInParameter(cmd4, "MovStock", DbType.String, C_Guia.Mov_Stock)
                    db.AddInParameter(cmd4, "UserCrea", DbType.String, C_Guia.User_Crea)
                    db.AddInParameter(cmd4, "PtoVta", DbType.String, C_Guia.PtoVta)
                    db.AddInParameter(cmd4, "NroHrs", DbType.Decimal, C_Guia.NroHrs)
                    db.AddInParameter(cmd4, "CapacTransp", DbType.Decimal, C_Guia.CapacTransp)
                    db.AddInParameter(cmd4, "CostoMin", DbType.Decimal, C_Guia.CostoMin)
                    db.AddInParameter(cmd4, "Kilometraje", DbType.Decimal, C_Guia.Kilometraje)
                    db.AddInParameter(cmd4, "Peso_Contenedor", DbType.Decimal, C_Guia.Peso_Contenedor)
                    db.AddInParameter(cmd4, "Peso_Aduanas", DbType.Decimal, C_Guia.Peso_Aduanas)
                    db.AddInParameter(cmd4, "Cod_Labor", DbType.String, C_Guia.Cod_Labor)
                    db.AddInParameter(cmd4, "Cod_Cantera", DbType.String, C_Guia.Cod_Cantera)
                    db.AddInParameter(cmd4, "Cod_Cli", DbType.String, C_Guia.Cod_Cli)
                    db.AddInParameter(cmd4, "Raz_Soc", DbType.String, C_Guia.RazSoc)
                    db.AddInParameter(cmd4, "Cod_Per", DbType.String, C_Guia.Cod_Per)
                    db.AddInParameter(cmd4, "Cod_Area", DbType.String, C_Guia.Cod_Area)
                    db.AddInParameter(cmd4, "Tipo_DocOri", DbType.String, C_Guia.Tipo_DocOri)
                    db.AddInParameter(cmd4, "Doc_Ori", DbType.String, C_Guia.Doc_Ori)
                    db.AddInParameter(cmd4, "Ruc", DbType.String, C_Guia.Ruc)
                    db.AddInParameter(cmd4, "Obs", DbType.String, C_Guia.Obs)
                    db.AddInParameter(cmd4, "tipdocref", DbType.String, C_Guia.TipDocRef)
                    db.AddInParameter(cmd4, "numdocref", DbType.String, C_Guia.NumDocRef)
                    db.AddInParameter(cmd4, "TipoDespacho", DbType.String, C_Guia.TipoDespacho)
                    db.AddInParameter(cmd4, "cod_alm2", DbType.String, C_Guia.Cod_Alm2)
                    db.AddInParameter(cmd4, "dir", DbType.String, C_Guia.Dir)
                    db.AddInParameter(cmd4, "dir2", DbType.String, C_Guia.Dir2)
                    db.AddInParameter(cmd4, "cod_ubi", DbType.String, C_Guia.Cod_Ubi)
                    db.AddInParameter(cmd4, "cod_ubi2", DbType.String, C_Guia.Cod_Ubi2)
                    db.AddInParameter(cmd4, "Status", DbType.String, C_Guia.Status)
                    db.AddInParameter(cmd4, "Motivo", DbType.String, C_Guia.Motivo)
                    db.AddInParameter(cmd4, "Opcion", DbType.String, "AGR")

                    IntRes = db.ExecuteNonQuery(cmd4, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    For Each w As ETGuia In X
                        Dim cmd3 As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_DetGuia)
                        Dim cmd5 As DbCommand = db.GetStoredProcCommand(usp_RAL.Det_Pedido)

                        db.AddInParameter(cmd3, "Cod_Cia", DbType.String, C_Guia.Cod_Cia)
                        db.AddInParameter(cmd3, "Tipo_Mov", DbType.String, C_Guia.Tipo_Mov)
                        db.AddInParameter(cmd3, "Tipo_Doc", DbType.String, C_Guia.Tipo_Doc)
                        db.AddInParameter(cmd3, "NumDoc", DbType.String, Serie & ETResultado.Mensaje)
                        db.AddInParameter(cmd3, "NumInterno", DbType.String, Serie & Resultado1BE.Mensaje)
                        db.AddInParameter(cmd3, "Cod_cli", DbType.String, w.Cod_Cli)
                        db.AddInParameter(cmd3, "Item", DbType.String, w.Item)
                        db.AddInParameter(cmd3, "cod_prod", DbType.String, w.Cod_Prod)
                        db.AddInParameter(cmd3, "Descrip", DbType.String, w.Descrip)
                        db.AddInParameter(cmd3, "Unid", DbType.String, w.Unid)
                        db.AddInParameter(cmd3, "Factm", DbType.Decimal, w.Factm)
                        db.AddInParameter(cmd3, "cant_ing", DbType.Decimal, w.Cant_Ing)
                        db.AddInParameter(cmd3, "cant_dev", DbType.Decimal, w.Cant_Dev)
                        db.AddInParameter(cmd3, "moneda", DbType.String, w.Moneda)
                        db.AddInParameter(cmd3, "tipo_cambio", DbType.String, w.Tipo_Cambio)
                        db.AddInParameter(cmd3, "precio", DbType.String, w.Precio)
                        db.AddInParameter(cmd3, "dcto", DbType.Decimal, w.Dcto)
                        db.AddInParameter(cmd3, "Total", DbType.Decimal, w.Total)
                        db.AddInParameter(cmd3, "User_Crea", DbType.String, w.User_Crea)
                        db.AddInParameter(cmd3, "item_fact", DbType.String, w.Item_Fact)
                        db.AddInParameter(cmd3, "movi", DbType.String, w.Movi)
                        db.AddInParameter(cmd3, "valorizacion", DbType.Decimal, w.Valorizacion)
                        db.AddInParameter(cmd3, "cod_prodpdc", DbType.String, w.Cod_ProdPdc)
                        db.AddInParameter(cmd3, "nro_blsini", DbType.Decimal, w.Nro_BlsIni)
                        db.AddInParameter(cmd3, "nro_blsfin", DbType.Decimal, w.Nro_BlsFin)
                        db.AddInParameter(cmd3, "hrs_lab", DbType.Decimal, w.Hrs_Lab)
                        db.AddInParameter(cmd3, "tipprod", DbType.String, w.TipProd)
                        db.AddInParameter(cmd3, "codorigen", DbType.String, w.CodOrigen)
                        db.AddInParameter(cmd3, "peso_bls", DbType.Decimal, w.Peso_Bls)
                        db.AddInParameter(cmd3, "cant_oc", DbType.Decimal, w.Cant_OC)
                        db.AddInParameter(cmd3, "cod_equipo", DbType.String, w.Cod_Equipo)
                        db.AddInParameter(cmd3, "facturado", DbType.String, w.Facturado)
                        db.AddInParameter(cmd3, "ctacosto", DbType.String, w.CtaCosto)
                        db.AddInParameter(cmd3, "cant_ped", DbType.Decimal, w.Cant_Ped)
                        db.AddInParameter(cmd3, "largo", DbType.Decimal, w.Largo)
                        db.AddInParameter(cmd3, "ancho", DbType.Decimal, w.Ancho)
                        db.AddInParameter(cmd3, "piezas", DbType.Decimal, w.Piezas)
                        db.AddInParameter(cmd3, "encajado", DbType.Boolean, w.Encajado)
                        db.AddInParameter(cmd3, "lleno", DbType.Boolean, w.Lleno)
                        db.AddInParameter(cmd3, "espesor", DbType.Decimal, w.Espesor)
                        db.AddInParameter(cmd3, "Cod_cantera", DbType.String, w.Cod_Cantera)
                        db.AddInParameter(cmd3, "Cod_Empleo", DbType.String, w.Cod_Empleo)
                        db.AddInParameter(cmd3, "und_oc", DbType.String, w.Und_OC)
                        db.AddInParameter(cmd3, "num_ord_exp", DbType.Decimal, w.Num_Ord_Exp)
                        db.AddInParameter(cmd3, "numinternoexp", DbType.String, w.NumInternoExp)
                        db.AddInParameter(cmd3, "Opcion", DbType.String, "AGR")

                        IntRes = db.ExecuteNonQuery(cmd3, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If

                        db.AddInParameter(cmd5, "Cod_Cia", DbType.String, C_Guia.Cod_Cia)
                        db.AddInParameter(cmd5, "Num_Doc", DbType.String, w.NumeroRequisicion)
                        db.AddInParameter(cmd5, "Cod_Producto", DbType.String, w.Cod_Prod)
                        db.AddInParameter(cmd5, "SalidaOrden", DbType.String, Serie & ETResultado.Mensaje)
                        db.AddInParameter(cmd5, "Cantidad_Atendida", DbType.Decimal, w.Cant_Ing)
                        db.AddInParameter(cmd5, "Item", DbType.Int16, w.Item_Pedido)
                        db.AddInParameter(cmd5, "Opcion", DbType.String, "AT1")

                        IntRes = db.ExecuteNonQuery(cmd5, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If

                    Next

                End If

                If Num2 > 0 Then

                    Dim cmd7 As DbCommand = db.GetStoredProcCommand(usp_RAL.NumeracionRequerimiento)
                    Dim cmd8 As DbCommand = db.GetStoredProcCommand(usp_RAL.Numeracion2)
                    Dim cmd9 As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_Requerimiento01)
                    Dim cmd10 As DbCommand = db.GetStoredProcCommand(usp_RAL.RequisicionFirma)

                    Dim Area As String = "16"
                    Flag = FlagRequerimiento(Reque.Cod_Cia, Area)
                    If IsDBNull(Flag) = True Then
                        Err.Raise(10)
                    End If

                    db.AddInParameter(cmd7, "CODCIA", DbType.String, Reque.Cod_Cia)
                    db.AddInParameter(cmd7, "CODAREA", DbType.String, Area)
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

                    NumeroRequerimiento = Tabla.Rows(0).Item("Numero")

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


                    db.AddInParameter(cmd9, "Nro_Requi", DbType.String, NumeroRequerimiento + "-" + Trim(Flag & "") + "-" + Convert.ToString(Year(Now)))
                    db.AddInParameter(cmd9, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                    db.AddInParameter(cmd9, "Lugar_Ent", DbType.String, Reque.Lugar_Ent)
                    db.AddInParameter(cmd9, "Area", DbType.String, Area)
                    db.AddInParameter(cmd9, "Nro_Int", DbType.String, NumeroInterno)
                    db.AddInParameter(cmd9, "User_Crea", DbType.String, Reque.User_Crea)
                    db.AddInParameter(cmd9, "Urgente", DbType.String, Reque.Prioridad)
                    db.AddInParameter(cmd9, "DocOri", DbType.String, "")
                    db.AddInParameter(cmd9, "NumDocOri", DbType.String, "")
                    db.AddInParameter(cmd9, "Opcion", DbType.String, "AGR")

                    IntRes = db.ExecuteNonQuery(cmd9, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    db.AddInParameter(cmd10, "Nro_Requerimiento", DbType.String, NumeroRequerimiento + "-" + Trim(Flag & "") + "-" + Convert.ToString(Year(Now)))
                    db.AddInParameter(cmd10, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                    db.AddInParameter(cmd10, "User", DbType.String, Reque.User_Crea)
                    db.AddInParameter(cmd10, "Opcion", DbType.String, "AGR")

                    IntRes = db.ExecuteNonQuery(cmd10, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If


                    For Each W As ETRequerimiento In C
                        Dim cmd11 As DbCommand = db.GetStoredProcCommand(usp_RAL.Detalle_Requerimiento)
                        Dim cmd12 As DbCommand = db.GetStoredProcCommand(usp_RAL.Anexo_Requerimiento)
                        Dim cmd13 As DbCommand = db.GetStoredProcCommand(usp_RAL.Det_Pedido)
                        Dim cmd17 As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarDocumentosTecnicos)

                        db.AddInParameter(cmd11, "Nro_Requi", DbType.String, NumeroRequerimiento + "-" + Trim(Flag & "") + "-" + Convert.ToString(Year(Now)))
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
                        db.AddInParameter(cmd11, "Opcion", DbType.String, "AGR")

                        IntRes = db.ExecuteNonQuery(cmd11, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If

                        db.AddInParameter(cmd12, "Nro_Req", DbType.String, NumeroRequerimiento + "-" + Trim(Flag & "") + "-" + Convert.ToString(Year(Now)))
                        db.AddInParameter(cmd12, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                        db.AddInParameter(cmd12, "Nro_Pedido", DbType.String, Reque.NumDocOri)
                        db.AddInParameter(cmd12, "Sistema", DbType.String, Reque.Sistema)
                        db.AddInParameter(cmd12, "Codigo_Producto", DbType.Decimal, W.CodigoProducto)
                        db.AddInParameter(cmd12, "Item_Pedido", DbType.Int16, W.Item_Pedido)
                        db.AddInParameter(cmd12, "Item_Requerimiento", DbType.String, W.Item)
                        db.AddInParameter(cmd12, "Cod_Area", DbType.String, Area)
                        db.AddInParameter(cmd12, "User", DbType.String, Reque.User_Crea)
                        db.AddInParameter(cmd12, "Unid_Compra", DbType.String, W.Unidad)
                        db.AddInParameter(cmd12, "Unid_Pedida", DbType.String, W.Unidad_Pedida)
                        db.AddInParameter(cmd12, "Cantidad_Pedida", DbType.String, W.Cantidad)
                        db.AddInParameter(cmd12, "Cantidad_Atendida", DbType.Decimal, W.Cantidad_Pedida)
                        db.AddInParameter(cmd12, "Opcion", DbType.String, "AG")

                        IntRes = db.ExecuteNonQuery(cmd12, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If

                        db.AddInParameter(cmd13, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                        db.AddInParameter(cmd13, "Num_Doc", DbType.String, Reque.NumDocOri)
                        db.AddInParameter(cmd13, "Cod_Producto", DbType.String, W.CodigoProducto)
                        db.AddInParameter(cmd13, "Cantidad_Requerida", DbType.Decimal, W.Cantidad)
                        db.AddInParameter(cmd13, "Item", DbType.Int16, W.Item_Pedido)
                        db.AddInParameter(cmd13, "Observaciones", DbType.String, W.Observacion)
                        db.AddInParameter(cmd13, "Requerimiento", DbType.String, NumeroRequerimiento + "-" + Trim(Flag & "") + "-" + Convert.ToString(Year(Now)))
                        db.AddInParameter(cmd13, "Opcion", DbType.String, "AT2")

                        IntRes = db.ExecuteNonQuery(cmd13, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If


                        db.AddInParameter(cmd17, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                        db.AddInParameter(cmd17, "Num_Requi", DbType.String, Reque.NumDocOri)
                        db.AddInParameter(cmd17, "Cod_Producto", DbType.String, W.CodigoProducto)
                        db.AddInParameter(cmd17, "Opcion", DbType.String, "LD")

                        Ds = New DataSet
                        Ds = db.ExecuteDataSet(cmd17, Trans)
                        Tabla = New DataTable
                        Tabla = Ds.Tables(0).Copy

                        For i As Integer = 0 To Tabla.Rows.Count - 1
                            Dim cmd18 As DbCommand = db.GetStoredProcCommand(usp_RAL.DocumentosTecnicos)


                            db.AddInParameter(cmd18, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                            db.AddInParameter(cmd18, "Num_Requi", DbType.String, Reque.NumDocOri)
                            db.AddInParameter(cmd18, "Cod_Producto", DbType.String, W.CodigoProducto)
                            db.AddInParameter(cmd18, "item", DbType.String, W.Item)
                            db.AddInParameter(cmd18, "cod_doctecnico", DbType.String, Tabla.Rows(i).Item("Documento"))
                            db.AddInParameter(cmd18, "user", DbType.String, Reque.User_Crea)

                            IntRes = db.ExecuteNonQuery(cmd8, Trans)

                            If IntRes = -1 Then
                                Err.Raise(10)
                            End If

                        Next

                    Next

                End If


                If Num2 = 0 Then

                    For Each w As ETPedido In B
                        Dim cmd14 As DbCommand = db.GetStoredProcCommand(usp_RAL.UpdateSoloRequerimiento)

                        db.AddInParameter(cmd14, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                        db.AddInParameter(cmd14, "Num_Doc", DbType.String, Reque.DocOri)
                        db.AddInParameter(cmd14, "Cod_Producto", DbType.String, w.Codigo_Producto)
                        db.AddInParameter(cmd14, "Item", DbType.Int32, w.Item)


                        IntRes = db.ExecuteNonQuery(cmd14, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If

                    Next



                End If


                If Num2 = 1 Then

                    For Each w As ETRequerimiento In C
                        Dim cmd16 As DbCommand = db.GetStoredProcCommand(usp_RAL.UpdateListaRecojo)
                        db.AddInParameter(cmd16, "Cod_Cia", DbType.String, Reque.Cod_Cia)
                        db.AddInParameter(cmd16, "Num_Doc", DbType.String, Reque.NumDocOri)
                        db.AddInParameter(cmd16, "Cod_Prod", DbType.String, w.CodigoProducto)

                        IntRes = db.ExecuteNonQuery(cmd16, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If

                    Next

                End If


                Trans.Commit()
                Conexion.Close()

                ETResultado.Realizo = True


                If Num1 > 0 Then
                    MsgBox("Se generó el Billete " + Serie + NumeroMovimientoAlmacen(ETResultado.Mensaje) + " para la Salida X Orden.", MsgBoxStyle.Information, "Comacsa")
                End If

                If Num2 > 0 Then
                    MsgBox("Se generó el Requerimiento para Logistica " + NumeroRequerimiento + "-" + Trim(Flag & "") + "-" + Convert.ToString(Year(Now)) + " para la compra.", MsgBoxStyle.Information, "Comacsa")

                End If

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

#Region "Grabar Autorizacion de Pedido"
    Public Function GrabarEntrega(ByVal Pedido As ETPedido) As ETResultado
        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Cab_Pedido)
        Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.Det_Pedido)
        Dim cmd3 As DbCommand = db.GetStoredProcCommand(usp_RAL.Cab_Pedido)
        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                


                db.AddInParameter(cmd2, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd2, "Num_Doc", DbType.String, Pedido.Numero_Doc)
                db.AddInParameter(cmd2, "SalidaOrden", DbType.String, Pedido.SalidaOrden)
                db.AddInParameter(cmd2, "User_Recibe", DbType.String, Pedido.User_Recibe)
                db.AddInParameter(cmd2, "User_Entrega", DbType.String, Pedido.User)
                db.AddInParameter(cmd2, "Opcion", DbType.String, "ULTI")



                IntRes = db.ExecuteNonQuery(cmd2, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd, "Tipo_Doc", DbType.String, Pedido.Tipo_Doc)
                db.AddInParameter(cmd, "Numero_Doc", DbType.String, Pedido.Numero_Doc)
                db.AddInParameter(cmd, "Observaciones", DbType.String, Pedido.Observaciones)
                db.AddInParameter(cmd, "Estado", DbType.String, Pedido.Estado)
                db.AddInParameter(cmd, "Opcion", DbType.String, "AEN")


                IntRes = db.ExecuteNonQuery(cmd, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                db.AddInParameter(cmd3, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
                db.AddInParameter(cmd3, "Tipo_Doc", DbType.String, Pedido.Tipo_Doc)
                db.AddInParameter(cmd3, "Numero_Doc", DbType.String, Pedido.Numero_Doc)
                db.AddInParameter(cmd3, "User_Entrega", DbType.String, Pedido.User)
                db.AddInParameter(cmd3, "Opcion", DbType.String, "POT")

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


    '   *****   usp_RAL_DetRequisicionAlmacen   *****
    '   Opcion  :   LEP     =>  Listar Detalle en Proceso
    '   Opcion  :   LENT    =>  Listar Detalle x Entregar
    '   Opcion  :   LP      =>  Listar Detalle Pendientes 
    '   Opcion  :   LA      =>  Listar Detalle Autorizadas
    '   Opcion  :   LLR     =>  Listar Detalle Listo Recojo
    '   Opcion  :   LXAC    =>  Listar Stock Distribuir
    '   Opcion  :   LCON    =>  Listar Consulta
    '   Opcion  :   LSOR    =>  Listar Salida Orden X Requisicion
    '   Opcion  :   DS      =>  Listar Detalle Salida Orden

#Region "Listar Detalle Pedido"
    Public Function ListarDetallePedido(ByVal Detalle As ETPedido, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Det_Pedido)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Detalle.Cod_Cia)
            db.AddInParameter(cmd, "Tipo_Doc", DbType.String, Detalle.Tipo_Doc)
            db.AddInParameter(cmd, "Num_Doc", DbType.String, Detalle.Numero_Doc)
            db.AddInParameter(cmd, "SalidaOrden", DbType.String, Detalle.SalidaOrden)
            db.AddInParameter(cmd, "Estado", DbType.String, Detalle.Estado)
            db.AddInParameter(cmd, "Codigo_Almacen", DbType.String, Detalle.Codigo_Almacen)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarDetallePedido = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   ****   usp_Ral_AplicacionAreaEmpleo ***** 

#Region "Grabar Aplicacion"

    Public Function GrabarAplicacion(ByVal Aplicacion As ETPedido, ByVal Opcion As String) As ETResultado

        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.AplicacionEmpleo)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Aplicacion.Cod_Cia)
                db.AddInParameter(cmd, "Cod_Area", DbType.String, Aplicacion.Codigo_Area)
                db.AddInParameter(cmd, "Cod_Empleo", DbType.String, Aplicacion.Codigo_Empleo)
                db.AddInParameter(cmd, "Cod_Aplicacion", DbType.String, Aplicacion.Codigo_Aplicacion)
                db.AddInParameter(cmd, "Descripcion", DbType.String, Aplicacion.Aplicacion)
                db.AddInParameter(cmd, "User", DbType.String, Aplicacion.User)
                db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)


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

#Region "Listar Aplicacion Area Empleo"
    Public Function ListarAplicacion(ByVal Aplicacion As ETPedido) As DataTable


        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.AplicacionEmpleo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Aplicacion.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Empleo", DbType.String, Aplicacion.Codigo_Empleo)
            db.AddInParameter(cmd, "Cod_Area", DbType.String, Aplicacion.Codigo_Area)
            db.AddInParameter(cmd, "Opcion", DbType.String, "LIS")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarAplicacion = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


    End Function
#End Region


    '   *****   usp_RAL_CabRequisicionPendiente ****
    '   Opcion  :   LX  =>  Listar Requisicion Pendiente

#Region "Listar Pedido Pendiente"
    Public Function Listar_PedidoPendiente(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.PedidoPendiente)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Listar_PedidoPendiente = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****   usp_RAL_CabRequisicionAutorizada    *****
    '   Opcion  :   LA  =>   Listar Requisicion Autorizada      

#Region "Listar Requisicion Autorizada"
    Public Function Listar_PedidoAutorizado(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.PedidoAutorizado)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Sistema", DbType.String, Pedido.Sistema)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Listar_PedidoAutorizado = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function
#End Region

    '   *****   usp_RAL_CabRequisicionAtender    *****
    '   Opcion  :   "LAT"  =>   Listar Requisicion Atender 

#Region "Listar Requisicion Atender"
    Public Function Listar_PedidoAtender(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.PedidoAtender)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Sistema", DbType.String, Pedido.Sistema)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable

            If Ds IsNot Nothing AndAlso Ds.Tables.Count <> 0 Then
                Tabla = Ds.Tables(0).Copy
            End If

            Listar_PedidoAtender = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   *****   usp_RAL_CabRequisicionEntregar    *****
    '   Opcion  :   LE  =>   Listar Requesicion Entregar

#Region "Listar Requesicion Entregar"
    Public Function Listar_PedidoEntregar(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.PedidoEntregar)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Sistema", DbType.String, Pedido.Sistema)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable

            If Ds IsNot Nothing AndAlso Ds.Tables.Count <> 0 Then
                Tabla = Ds.Tables(0).Copy
            End If

            Listar_PedidoEntregar = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****   usp_RAL_CabRequisicionAlmacen    *****
    '   Opcion  :   LE  =>   Listar Requesicion Entregar

#Region "Lista Todos Requisicion"
    Public Function Listar_Pedido(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Cab_Pedido)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Area", DbType.String, Pedido.Codigo_Area)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Listar_Pedido = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   *****   usp_RAL_Grabar_Cab_Guia    *****
    '   Opcion  :   LxO  =>   Listar Documento Origen - Orden de Salida

#Region "Listar Documento Origen - Orden de Salida"
    Public Function Listar_Numero_SO(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_CabGuia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
            db.AddInParameter(cmd, "Tipo_Doc", DbType.String, Pedido.Tipo_Doc)
            db.AddInParameter(cmd, "NumDoc", DbType.String, Pedido.Numero_Doc)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Listar_Numero_SO = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****   usp_RAL_Distribuir_Requerimiento    *****
    '   Opcion  :   LIS  =>   Listar Cabecera Salida Orden

#Region "Listar Cabecera Salida Orden"
    Public Function Listar_SalidaOrden(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DistribuirPedido)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Listar_SalidaOrden = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****   usp_RAL_ListarDocTec    *****
    '   Opcion  :   LIS     =>  Listar Documentos Tecnicos

#Region "Listar Documentos Tecnicos"
    Public Function Listar_DocTec(ByVal Pedido As ETPedido, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarDocumentosTecnicos)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Num_Requi", DbType.String, Pedido.Numero_Doc)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Producto", DbType.String, Pedido.Codigo_Producto)
            db.AddInParameter(cmd, "Nro_Req_Origen", DbType.String, Pedido.Requerimiento)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Listar_DocTec = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function
#End Region

    '   *****   usp_RAL_ListarSalidaRequerimiento   *****

#Region "Listar Salida Orden y Requerimiento Compra"
    Public Function ListarSalidaOrdenRequerimientoCompra(ByVal Pedido As ETPedido) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarDocumentosTecnicos)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Num_Doc", DbType.String, Pedido.Numero_Doc)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarSalidaOrdenRequerimientoCompra = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****  usp_RAL_Consulta_Pedido  *****
    '   Opcion  :   1
    '   Opcion  :   2

    Public Function Consulta_Pedido(ByVal Pedido As ETPedido, ByVal Opcion As Integer) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Consulta_Pedido)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Pedido.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Area", DbType.String, Pedido.Codigo_Area)
            db.AddInParameter(cmd, "Cod_Producto", DbType.String, Pedido.Codigo_Producto)
            db.AddInParameter(cmd, "Mes", DbType.Int32, Pedido.Mes)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable

            If Ds IsNot Nothing AndAlso Ds.Tables.Count <> 0 Then
                Tabla = Ds.Tables(0).Copy
            End If

            Consulta_Pedido = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function


End Class
