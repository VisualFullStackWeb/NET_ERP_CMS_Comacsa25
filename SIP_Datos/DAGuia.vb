Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Exception

Public Class DAGuia
    Inherits ETObjecto

#Region "Grabar Movimiento de Almacen"
    Public Function GrabarMovimiento(ByVal Opcion As String, ByVal Mov As String, ByVal Doc As String _
                                            , ByVal Guia As ETGuia, ByVal X As List(Of ETGuia) _
                                            , ByVal P As List(Of ETPedido), ByVal Y As List(Of ETGuia) _
                                            , ByVal Almacen As ETAlmacen) As ETResultado
        Dim Serie As String = ""
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Dim ETResultado As New ETResultado
        Dim Resultado1BE As New ETResultado

        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd5 As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_DetGuia)
        Dim cmd5_1 As DbCommand = db.GetStoredProcCommand(usp_RAL.Transp_Guia_Almacen)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Dim cmd4 As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_CabGuia)
                Dim cmd_4 As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_CabGuia)

                If Opcion = "AGR" Then

                    Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.NumeroMovimiento)
                    Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.NumeroMovimiento)

                    Serie = SerieMovimiento(Guia.Cod_Cia, Guia.Cod_Alm)

                    db.AddInParameter(cmd2, "Cod_Cia", DbType.String, Guia.Cod_Cia)
                    db.AddInParameter(cmd2, "Tipo_Mov", DbType.String, Mov)
                    db.AddInParameter(cmd2, "Tipo_Doc", DbType.String, Doc)
                    db.AddInParameter(cmd2, "Codigo_Almacen", DbType.String, Guia.Cod_Alm)
                    db.AddInParameter(cmd2, "Serie", DbType.String, Serie)
                    db.AddOutParameter(cmd2, "Numero", DbType.Int32, 7)
                    db.AddInParameter(cmd2, "Opcion", DbType.String, "GEN")

                    IntRes = db.ExecuteNonQuery(cmd2, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    ETResultado.Mensaje = NumeroMovimientoAlmacen(Convert.ToString(db.GetParameterValue(cmd2, "Numero")))
                    ETResultado.Mensaje = Serie & ETResultado.Mensaje

                    db.AddInParameter(cmd1, "Cod_Cia", DbType.String, Guia.Cod_Cia)
                    db.AddInParameter(cmd1, "Tipo_Mov", DbType.String, "00")
                    db.AddInParameter(cmd1, "Tipo_Doc", DbType.String, "MOV")
                    db.AddInParameter(cmd1, "Codigo_Almacen", DbType.String, Guia.Cod_Alm)
                    db.AddInParameter(cmd1, "Serie", DbType.String, Serie)
                    db.AddOutParameter(cmd1, "Numero", DbType.Int32, 7)
                    db.AddInParameter(cmd1, "Opcion", DbType.String, "GEN")

                    IntRes = db.ExecuteNonQuery(cmd1, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    Resultado1BE.Mensaje = NumeroMovimientoAlmacen(Convert.ToString(db.GetParameterValue(cmd1, "Numero")))
                    Resultado1BE.Mensaje = Serie & Resultado1BE.Mensaje

                Else

                    ETResultado.Mensaje = Guia.NumDoc
                    Resultado1BE.Mensaje = Guia.NumInterno

                End If

                db.AddInParameter(cmd4, "Cod_Cia", DbType.String, Guia.Cod_Cia)
                db.AddInParameter(cmd4, "Tipo_Mov", DbType.String, Mov)
                db.AddInParameter(cmd4, "Tipo_Doc", DbType.String, Doc)
                db.AddInParameter(cmd4, "NumDoc", DbType.String, ETResultado.Mensaje)
                db.AddInParameter(cmd4, "NumInterno", DbType.String, Resultado1BE.Mensaje)
                db.AddInParameter(cmd4, "Cod_Alm", DbType.String, Guia.Cod_Alm)
                db.AddInParameter(cmd4, "MovStock", DbType.String, Guia.Mov_Stock)
                db.AddInParameter(cmd4, "UserCrea", DbType.String, Guia.User_Crea)
                db.AddInParameter(cmd4, "PtoVta", DbType.String, Guia.PtoVta)
                db.AddInParameter(cmd4, "NroHrs", DbType.Decimal, Guia.NroHrs)
                db.AddInParameter(cmd4, "CapacTransp", DbType.Decimal, Guia.CapacTransp)
                db.AddInParameter(cmd4, "CostoMin", DbType.Decimal, Guia.CostoMin)
                db.AddInParameter(cmd4, "Kilometraje", DbType.Decimal, Guia.Kilometraje)
                db.AddInParameter(cmd4, "Peso_Contenedor", DbType.Decimal, Guia.Peso_Contenedor)
                db.AddInParameter(cmd4, "Peso_Aduanas", DbType.Decimal, Guia.Peso_Aduanas)
                db.AddInParameter(cmd4, "Cod_Labor", DbType.String, Guia.Cod_Labor)
                db.AddInParameter(cmd4, "Cod_Cantera", DbType.String, Guia.Cod_Cantera)
                db.AddInParameter(cmd4, "Cod_Cli", DbType.String, Guia.Cod_Cli)
                db.AddInParameter(cmd4, "Raz_Soc", DbType.String, Guia.RazSoc)
                db.AddInParameter(cmd4, "Cod_Per", DbType.String, Guia.Cod_Per)
                db.AddInParameter(cmd4, "Cod_Area", DbType.String, Guia.Cod_Area)
                db.AddInParameter(cmd4, "Tipo_DocOri", DbType.String, Guia.Tipo_DocOri)
                db.AddInParameter(cmd4, "Doc_Ori", DbType.String, Guia.Doc_Ori)
                db.AddInParameter(cmd4, "Ruc", DbType.String, Guia.Ruc)
                db.AddInParameter(cmd4, "Obs", DbType.String, Guia.Obs)
                db.AddInParameter(cmd4, "tipdocref", DbType.String, Guia.TipDocRef)
                db.AddInParameter(cmd4, "numdocref", DbType.String, Guia.NumDocRef)
                db.AddInParameter(cmd4, "TipoDespacho", DbType.String, Guia.TipoDespacho)
                db.AddInParameter(cmd4, "cod_alm2", DbType.String, Guia.Cod_Alm2)
                db.AddInParameter(cmd4, "dir", DbType.String, Guia.Dir)
                db.AddInParameter(cmd4, "dir2", DbType.String, Guia.Dir2)
                db.AddInParameter(cmd4, "cod_ubi", DbType.String, Guia.Cod_Ubi)
                db.AddInParameter(cmd4, "cod_ubi2", DbType.String, Guia.Cod_Ubi2)
                db.AddInParameter(cmd4, "Status", DbType.String, Guia.Status)
                db.AddInParameter(cmd4, "Motivo", DbType.String, Guia.Motivo)
                db.AddInParameter(cmd4, "Opcion", DbType.String, Opcion)

                IntRes = db.ExecuteNonQuery(cmd4, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                If Doc = "ST" Then
                    Dim cmd11 As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_CabGuia)

                    db.AddInParameter(cmd11, "Cod_Cia", DbType.String, Guia.Cod_Cia)
                    db.AddInParameter(cmd11, "NumDoc", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd11, "Opcion", DbType.String, "STA")

                    IntRes = db.ExecuteNonQuery(cmd11, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If


                    db.AddInParameter(cmd5_1, "Cod_Cia", DbType.String, Almacen.Cod_Cia)
                    db.AddInParameter(cmd5_1, "Tipo_Mov", DbType.String, Mov)
                    db.AddInParameter(cmd5_1, "Tipo_Doc", DbType.String, Doc)
                    db.AddInParameter(cmd5_1, "NumDoc", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd5_1, "cod_transp", DbType.String, Almacen.Cod_Transp)

                    db.AddInParameter(cmd5_1, "razsoc", DbType.String, Almacen.Raz_Soc)
                    db.AddInParameter(cmd5_1, "ruc", DbType.String, Almacen.Ruc)
                    db.AddInParameter(cmd5_1, "placa", DbType.String, Almacen.Placa)
                    db.AddInParameter(cmd5_1, "cod_chofer", DbType.String, Almacen.Cod_Chofer)
                    db.AddInParameter(cmd5_1, "nom_chofer", DbType.String, Almacen.Nom_Chofer)

                    db.AddInParameter(cmd5_1, "marca", DbType.String, Almacen.Marca)
                    db.AddInParameter(cmd5_1, "certinscrip", DbType.String, Almacen.Cert_Inscrip)
                    db.AddInParameter(cmd5_1, "licconducir", DbType.String, Almacen.Lic_Conducir)
                    db.AddInParameter(cmd5_1, "dni_chofer", DbType.String, Almacen.Dni_Chofer)
                    db.AddInParameter(cmd5_1, "dni_destinatario", DbType.String, Almacen.Dni_Destinatario)

                    db.AddInParameter(cmd5_1, "enviado_a", DbType.String, Almacen.Enviado_a)
                    db.AddInParameter(cmd5_1, "status", DbType.String, "")
                    db.AddInParameter(cmd5_1, "user_crea", DbType.String, Almacen.User_Crea)

                    IntRes = db.ExecuteNonQuery(cmd5_1, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                End If






                If Opcion = "MOD" Then
                    db.AddInParameter(cmd5, "Cod_Cia", DbType.String, Guia.Cod_Cia)
                    db.AddInParameter(cmd5, "Tipo_Mov", DbType.String, Mov)
                    db.AddInParameter(cmd5, "Tipo_Doc", DbType.String, Doc)
                    db.AddInParameter(cmd5, "NumDoc", DbType.String, Guia.NumDoc)
                    db.AddInParameter(cmd5, "Opcion", DbType.String, "ELI")

                    IntRes = db.ExecuteNonQuery(cmd5, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    If Mov = "01" And Mov = "41" Then

                        For Each W As ETGuia In X
                            Dim cmd6 As DbCommand = db.GetStoredProcCommand(usp_RAL.UpdateDetalleOC)

                            db.AddInParameter(cmd6, "Cod_Cia", DbType.String, Guia.Cod_Cia)
                            db.AddInParameter(cmd6, "Nro_OC", DbType.String, W.Num_Ord_Exp)
                            db.AddInParameter(cmd6, "Item", DbType.String, W.Item_Fact)
                            db.AddInParameter(cmd6, "Tipo_Producto", DbType.String, W.TipProd)
                            db.AddInParameter(cmd6, "Cod_Producto", DbType.String, W.Cod_Prod)
                            db.AddInParameter(cmd6, "User", DbType.String, Guia.User_Crea)
                            db.AddInParameter(cmd6, "Opcion", DbType.String, "U4")

                            IntRes = db.ExecuteNonQuery(cmd6, Trans)

                            If IntRes = -1 Then
                                Err.Raise(10)
                            End If

                        Next
                    End If

                End If

                If Doc = "SE" Then

                    db.AddInParameter(cmd_4, "Cod_Cia", DbType.String, Guia.Cod_Cia)
                    db.AddInParameter(cmd_4, "Tipo_Mov", DbType.String, "23")
                    db.AddInParameter(cmd_4, "Tipo_Doc", DbType.String, "IE")
                    db.AddInParameter(cmd_4, "NumDoc", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd_4, "NumInterno", DbType.String, Resultado1BE.Mensaje)
                    db.AddInParameter(cmd_4, "Cod_Alm", DbType.String, Guia.Cod_Alm)
                    db.AddInParameter(cmd_4, "MovStock", DbType.String, Guia.Mov_Stock)
                    db.AddInParameter(cmd_4, "UserCrea", DbType.String, Guia.User_Crea)
                    db.AddInParameter(cmd_4, "PtoVta", DbType.String, Guia.PtoVta)
                    db.AddInParameter(cmd_4, "NroHrs", DbType.Decimal, Guia.NroHrs)
                    db.AddInParameter(cmd_4, "CapacTransp", DbType.Decimal, Guia.CapacTransp)
                    db.AddInParameter(cmd_4, "CostoMin", DbType.Decimal, Guia.CostoMin)
                    db.AddInParameter(cmd_4, "Kilometraje", DbType.Decimal, Guia.Kilometraje)
                    db.AddInParameter(cmd_4, "Peso_Contenedor", DbType.Decimal, Guia.Peso_Contenedor)
                    db.AddInParameter(cmd_4, "Peso_Aduanas", DbType.Decimal, Guia.Peso_Aduanas)
                    db.AddInParameter(cmd_4, "Cod_Labor", DbType.String, Guia.Cod_Labor)
                    db.AddInParameter(cmd_4, "Cod_Cantera", DbType.String, Guia.Cod_Cantera)
                    db.AddInParameter(cmd_4, "Cod_Cli", DbType.String, Guia.Cod_Cli)
                    db.AddInParameter(cmd_4, "Raz_Soc", DbType.String, "INGRESO POR CAMBIO DE PROD (REMARCADO)")
                    db.AddInParameter(cmd_4, "Cod_Per", DbType.String, Guia.Cod_Per)
                    db.AddInParameter(cmd_4, "Cod_Area", DbType.String, Guia.Cod_Area)
                    db.AddInParameter(cmd_4, "Tipo_DocOri", DbType.String, Guia.Tipo_DocOri)
                    db.AddInParameter(cmd_4, "Doc_Ori", DbType.String, Guia.Doc_Ori)
                    db.AddInParameter(cmd_4, "Ruc", DbType.String, Guia.Ruc)
                    db.AddInParameter(cmd_4, "Obs", DbType.String, Guia.Obs)
                    db.AddInParameter(cmd_4, "tipdocref", DbType.String, Guia.TipDocRef)
                    db.AddInParameter(cmd_4, "numdocref", DbType.String, Guia.NumDocRef)
                    db.AddInParameter(cmd_4, "TipoDespacho", DbType.String, Guia.TipoDespacho)
                    db.AddInParameter(cmd_4, "cod_alm2", DbType.String, Guia.Cod_Alm2)
                    db.AddInParameter(cmd_4, "dir", DbType.String, Guia.Dir)
                    db.AddInParameter(cmd_4, "dir2", DbType.String, Guia.Dir2)
                    db.AddInParameter(cmd_4, "cod_ubi", DbType.String, Guia.Cod_Ubi)
                    db.AddInParameter(cmd_4, "cod_ubi2", DbType.String, Guia.Cod_Ubi2)
                    db.AddInParameter(cmd_4, "Status", DbType.String, Guia.Status)
                    db.AddInParameter(cmd_4, "Motivo", DbType.String, Guia.Motivo)
                    db.AddInParameter(cmd_4, "Opcion", DbType.String, Opcion)

                    IntRes = db.ExecuteNonQuery(cmd_4, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                End If


                For Each w As ETGuia In X
                    Dim cmd3 As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_DetGuia)
                    Dim cmd7 As DbCommand = db.GetStoredProcCommand(usp_RAL.UpdateDetalleOC)

                    db.AddInParameter(cmd3, "Cod_Cia", DbType.String, Guia.Cod_Cia)
                    db.AddInParameter(cmd3, "Tipo_Mov", DbType.String, Mov)
                    db.AddInParameter(cmd3, "Tipo_Doc", DbType.String, Doc)
                    db.AddInParameter(cmd3, "NumDoc", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd3, "NumInterno", DbType.String, Resultado1BE.Mensaje)
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
                    db.AddInParameter(cmd3, "num_ord_exp", DbType.String, w.Num_Ord_Exp)
                    db.AddInParameter(cmd3, "numinternoexp", DbType.String, w.NumInternoExp)
                    db.AddInParameter(cmd3, "Opcion", DbType.String, "AGR")

                    IntRes = db.ExecuteNonQuery(cmd3, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                    If Mov = "01" Or Mov = "41" Then
                        db.AddInParameter(cmd7, "Cod_Cia", DbType.String, Guia.Cod_Cia)
                        db.AddInParameter(cmd7, "Nro_OC", DbType.String, w.Num_Ord_Exp)
                        db.AddInParameter(cmd7, "Item", DbType.Int16, w.Item_Fact)
                        db.AddInParameter(cmd7, "Tipo_Producto", DbType.String, w.TipProd)
                        db.AddInParameter(cmd7, "Cod_Producto", DbType.String, w.Cod_Prod)
                        db.AddInParameter(cmd7, "Cantidad_Despacho", DbType.Decimal, w.Cant_OC)
                        db.AddInParameter(cmd7, "Cantidad_Anterior", DbType.Decimal, w.Cant_Anterior)
                        db.AddInParameter(cmd7, "User", DbType.String, Guia.User_Crea)
                        db.AddInParameter(cmd7, "Opcion", DbType.String, "U1")

                        IntRes = db.ExecuteNonQuery(cmd7, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If
                    End If

                    If Doc = "ST" And w.IndicadorEnvio = "1" Then
                        Dim cmd13 As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_DetGuia)
                        db.AddInParameter(cmd13, "cant_ing", DbType.String, w.Cant_Ing)
                        db.AddInParameter(cmd13, "NumDoc", DbType.String, ETResultado.Mensaje)
                        db.AddInParameter(cmd13, "num_ord_exp", DbType.String, w.Num_Ord_Exp)
                        db.AddInParameter(cmd13, "cod_prod", DbType.String, w.Cod_Prod)
                        db.AddInParameter(cmd13, "cod_cia", DbType.String, w.Cod_Cia)
                        db.AddInParameter(cmd13, "Opcion", DbType.String, "USC")

                        IntRes = db.ExecuteNonQuery(cmd13, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If
                    End If

                    If Doc = "IT" Then
                        Dim cmd10 As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_DetGuia)

                        db.AddInParameter(cmd10, "cant_ing", DbType.String, w.Cant_Ing)
                        db.AddInParameter(cmd10, "NumDoc", DbType.String, ETResultado.Mensaje)
                        db.AddInParameter(cmd10, "cod_prod", DbType.String, w.Cod_Prod)
                        db.AddInParameter(cmd10, "cod_cia", DbType.String, w.Cod_Cia)
                        db.AddInParameter(cmd10, "Item", DbType.Int16, w.Item)
                        db.AddInParameter(cmd10, "Opcion", DbType.String, "UST")

                        IntRes = db.ExecuteNonQuery(cmd10, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If

                    End If

                    If Doc = "SD" Then
                        Dim cmd11 As DbCommand = db.GetStoredProcCommand(usp_RAL.Update_SalidaDevolucion_OC)
                        db.AddInParameter(cmd11, "cod_cia", DbType.String, w.Cod_Cia)
                        db.AddInParameter(cmd11, "Nro_OC", DbType.String, w.Num_Ord_Exp)
                        db.AddInParameter(cmd11, "NumDoc", DbType.String, ETResultado.Mensaje)
                        db.AddInParameter(cmd11, "Numero_Guia", DbType.String, w.NumInternoExp)
                        db.AddInParameter(cmd11, "Item_OC", DbType.Int16, w.Item_Fact)
                        db.AddInParameter(cmd11, "Cod_Producto", DbType.String, w.Cod_Prod)
                        db.AddInParameter(cmd11, "Cantidad", DbType.Decimal, w.Cant_Ing)
                        db.AddInParameter(cmd11, "Cantidad_Conv", DbType.Decimal, w.Cant_Anterior)
                        db.AddInParameter(cmd11, "UM", DbType.String, w.Unid)
                        db.AddInParameter(cmd11, "User", DbType.String, w.User_Crea)
                        db.AddInParameter(cmd11, "Opcion", DbType.String, "USD")

                        IntRes = db.ExecuteNonQuery(cmd11, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If

                    End If


                Next

                If Doc = "SE" Then
                    For Each W As ETGuia In Y
                        Dim cmd12 As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_DetGuia)

                        db.AddInParameter(cmd12, "Cod_Cia", DbType.String, Guia.Cod_Cia)
                        db.AddInParameter(cmd12, "Tipo_Mov", DbType.String, "23")
                        db.AddInParameter(cmd12, "Tipo_Doc", DbType.String, "IE")
                        db.AddInParameter(cmd12, "NumDoc", DbType.String, ETResultado.Mensaje)
                        db.AddInParameter(cmd12, "NumInterno", DbType.String, Resultado1BE.Mensaje)
                        db.AddInParameter(cmd12, "Cod_cli", DbType.String, W.Cod_Cli)
                        db.AddInParameter(cmd12, "Item", DbType.String, W.Item)
                        db.AddInParameter(cmd12, "cod_prod", DbType.String, W.Cod_Prod)
                        db.AddInParameter(cmd12, "Descrip", DbType.String, W.Descrip)
                        db.AddInParameter(cmd12, "Unid", DbType.String, W.Unid)
                        db.AddInParameter(cmd12, "Factm", DbType.Decimal, W.Factm)
                        db.AddInParameter(cmd12, "cant_ing", DbType.Decimal, W.Cant_Ing)
                        db.AddInParameter(cmd12, "cant_dev", DbType.Decimal, W.Cant_Dev)
                        db.AddInParameter(cmd12, "moneda", DbType.String, W.Moneda)
                        db.AddInParameter(cmd12, "tipo_cambio", DbType.String, W.Tipo_Cambio)
                        db.AddInParameter(cmd12, "precio", DbType.String, W.Precio)
                        db.AddInParameter(cmd12, "dcto", DbType.Decimal, W.Dcto)
                        db.AddInParameter(cmd12, "Total", DbType.Decimal, W.Total)
                        db.AddInParameter(cmd12, "User_Crea", DbType.String, W.User_Crea)
                        db.AddInParameter(cmd12, "item_fact", DbType.String, W.Item_Fact)
                        db.AddInParameter(cmd12, "movi", DbType.String, W.Movi)
                        db.AddInParameter(cmd12, "valorizacion", DbType.Decimal, W.Valorizacion)
                        db.AddInParameter(cmd12, "cod_prodpdc", DbType.String, W.Cod_ProdPdc)
                        db.AddInParameter(cmd12, "nro_blsini", DbType.Decimal, W.Nro_BlsIni)
                        db.AddInParameter(cmd12, "nro_blsfin", DbType.Decimal, W.Nro_BlsFin)
                        db.AddInParameter(cmd12, "hrs_lab", DbType.Decimal, W.Hrs_Lab)
                        db.AddInParameter(cmd12, "tipprod", DbType.String, W.TipProd)
                        db.AddInParameter(cmd12, "codorigen", DbType.String, W.CodOrigen)
                        db.AddInParameter(cmd12, "peso_bls", DbType.Decimal, W.Peso_Bls)
                        db.AddInParameter(cmd12, "cant_oc", DbType.Decimal, W.Cant_OC)
                        db.AddInParameter(cmd12, "cod_equipo", DbType.String, W.Cod_Equipo)
                        db.AddInParameter(cmd12, "facturado", DbType.String, W.Facturado)
                        db.AddInParameter(cmd12, "ctacosto", DbType.String, W.CtaCosto)
                        db.AddInParameter(cmd12, "cant_ped", DbType.Decimal, W.Cant_Ped)
                        db.AddInParameter(cmd12, "largo", DbType.Decimal, W.Largo)
                        db.AddInParameter(cmd12, "ancho", DbType.Decimal, W.Ancho)
                        db.AddInParameter(cmd12, "piezas", DbType.Decimal, W.Piezas)
                        db.AddInParameter(cmd12, "encajado", DbType.Boolean, W.Encajado)
                        db.AddInParameter(cmd12, "lleno", DbType.Boolean, W.Lleno)
                        db.AddInParameter(cmd12, "espesor", DbType.Decimal, W.Espesor)
                        db.AddInParameter(cmd12, "Cod_cantera", DbType.String, W.Cod_Cantera)
                        db.AddInParameter(cmd12, "Cod_Empleo", DbType.String, W.Cod_Empleo)
                        db.AddInParameter(cmd12, "und_oc", DbType.String, W.Und_OC)
                        db.AddInParameter(cmd12, "num_ord_exp", DbType.String, W.Num_Ord_Exp)
                        db.AddInParameter(cmd12, "numinternoexp", DbType.String, W.NumInternoExp)
                        db.AddInParameter(cmd12, "Opcion", DbType.String, "AGR")

                        IntRes = db.ExecuteNonQuery(cmd12, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If
                    Next

                End If


                If Mov = "01" Then
                    For Each Z As ETPedido In P
                        Dim cmd8 As DbCommand = db.GetStoredProcCommand(usp_RAL.UpdatePedidoIngresoOC)
                        Dim cmd9 As DbCommand = db.GetStoredProcCommand(usp_RAL.Cab_IngresoOC)

                        db.AddInParameter(cmd8, "Cod_Cia", DbType.String, Z.Cod_Cia)
                        db.AddInParameter(cmd8, "Item", DbType.Int16, Z.Item)
                        db.AddInParameter(cmd8, "Cod_Producto", DbType.String, Z.Codigo_Producto)
                        db.AddInParameter(cmd8, "Nro_Pedido", DbType.String, Z.Numero_Doc)

                        IntRes = db.ExecuteNonQuery(cmd8, Trans)

                        If IntRes = -1 Then
                            Err.Raise(10)
                        End If


                        db.AddInParameter(cmd9, "Cod_Cia", DbType.String, Z.Cod_Cia)
                        db.AddInParameter(cmd9, "User", DbType.String, Guia.User_Crea)
                        db.AddInParameter(cmd9, "Nro_Pedido", DbType.String, Z.Numero_Doc)

                        IntRes = db.ExecuteNonQuery(cmd9, Trans)

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

#Region "Eliminar Movimiento de Almacen"
    Public Function EliminarMovimiento(ByVal Guia As ETGuia, ByVal X As List(Of ETGuia)) As ETResultado

        Dim ETResultado As New ETResultado

        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd4 As DbCommand = db.GetStoredProcCommand(usp_RAL.UPD_AnularMovimiento)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd4, "Cod_Cia", DbType.String, Guia.Cod_Cia)
                db.AddInParameter(cmd4, "Tipo_Mov", DbType.String, Guia.Tipo_Mov)
                db.AddInParameter(cmd4, "Tipo_Doc", DbType.String, Guia.Tipo_Doc)
                db.AddInParameter(cmd4, "NumDoc", DbType.String, Guia.NumDoc)
                db.AddInParameter(cmd4, "Motivo", DbType.String, Guia.Motivo)
                db.AddInParameter(cmd4, "User", DbType.String, Guia.User_Crea)

                IntRes = db.ExecuteNonQuery(cmd4, Trans)

                If IntRes = -1 Then
                    Err.Raise(10)
                End If


                If Guia.Tipo_Mov = "01" Or Guia.Tipo_Mov = "41" Then
                    For Each W As ETGuia In X
                        Dim cmd6 As DbCommand = db.GetStoredProcCommand(usp_RAL.UpdateDetalleOC)

                        db.AddInParameter(cmd6, "Cod_Cia", DbType.String, Guia.Cod_Cia)
                        db.AddInParameter(cmd6, "Nro_OC", DbType.String, W.Num_Ord_Exp)
                        db.AddInParameter(cmd6, "Item", DbType.String, W.Item)
                        db.AddInParameter(cmd6, "Tipo_Producto", DbType.String, W.TipProd)
                        db.AddInParameter(cmd6, "Cod_Producto", DbType.String, W.Cod_Prod)
                        db.AddInParameter(cmd6, "Cantidad_Despacho", DbType.Decimal, W.Cant_Ped)
                        db.AddInParameter(cmd6, "User", DbType.String, Guia.User_Crea)
                        db.AddInParameter(cmd6, "Opcion", DbType.String, "U3")

                        IntRes = db.ExecuteNonQuery(cmd6, Trans)

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


    '   *****   usp_RAL_Grabar_Cab_Guia                             *****
    '   Opcion  :   VAL     =>      Validar Salida x Orden
    '   Opcion  :   LIS     =>      Numero Interno Salida Orden
    '   Opcion  :   FAC     =>      Consultar Facturacion de la Orden de Compra x Billete


#Region "Listar Guia"
    Public Function Listar_Guia(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Grabar_CabGuia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "Tipo_DocOri", DbType.String, Guia.tipo_docori)
            db.AddInParameter(cmd, "NumDoc", DbType.String, Guia.numdoc)
            db.AddInParameter(cmd, "Doc_Ori", DbType.String, Guia.doc_ori)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Listar_Guia = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****   usp_RAL_IngresoOrdenCompra                          *****

#Region "Listar Movimientos OC"
    Public Function ListarMovimientoOrdenCompra(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.IngresoOrdenCompra)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "NumDoc", DbType.String, Guia.numdoc)
            db.AddInParameter(cmd, "TipoDoc", DbType.String, Guia.tipo_doc)
            db.AddInParameter(cmd, "Ano", DbType.String, Guia.Ano)
            db.AddInParameter(cmd, "Mes", DbType.String, Guia.Mes)
            db.AddInParameter(cmd, "Dia", DbType.String, Guia.Dia)
            db.AddInParameter(cmd, "Usuario", DbType.String, Guia.User_Crea)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Guia.Fecha)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Guia.Fecha2)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarMovimientoOrdenCompra = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   *****   usp_RAL_SalidaTransferencia                         *****

#Region "Listar Movimientos Salida Por Transferencia"

    Public Function ListarMovimientoSalidaTransferencia(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.SalidaTransferencia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.Cod_Cia)
            db.AddInParameter(cmd, "NumDoc", DbType.String, Guia.NumDoc)
            db.AddInParameter(cmd, "TipoDoc", DbType.String, Guia.Tipo_Doc)
            db.AddInParameter(cmd, "Ano", DbType.String, Guia.Ano)
            db.AddInParameter(cmd, "Mes", DbType.String, Guia.Mes)
            db.AddInParameter(cmd, "Dia", DbType.String, Guia.Dia)
            db.AddInParameter(cmd, "Usuario", DbType.String, Guia.User_Crea)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarMovimientoSalidaTransferencia = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region


    '   *****   usp_RAL_SalidaDevolucion                            *****

#Region "Listar Movimientos Salida Por Devolucion"
    Public Function ListarMovimientoSalidaDevolucion(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.SalidaDevolucion)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.Cod_Cia)
            db.AddInParameter(cmd, "NumDoc", DbType.String, Guia.NumDoc)
            db.AddInParameter(cmd, "TipoDoc", DbType.String, Guia.Tipo_Doc)
            db.AddInParameter(cmd, "Ano", DbType.String, Guia.Ano)
            db.AddInParameter(cmd, "Mes", DbType.String, Guia.Mes)
            db.AddInParameter(cmd, "Dia", DbType.String, Guia.Dia)
            db.AddInParameter(cmd, "Usuario", DbType.String, Guia.User_Crea)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarMovimientoSalidaDevolucion = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   ******  usp_RAL_TipoCambio                                  *****

#Region "Listar Tipo Cambio"
    Public Function ListarTipoCambio(ByVal Cia As String, ByVal Tipo As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.TipoCambio)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)
            db.AddInParameter(cmd, "Opcion", DbType.String, Tipo)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarTipoCambio = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   *****   usp_RAL_IngresoAjuste                               *****

#Region "Listar Movimientos Por Ajuste"
    Public Function ListarMovimientoPorAjuste(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.IngresoAjuste)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "NumDoc", DbType.String, Guia.numdoc)
            db.AddInParameter(cmd, "TipoDoc", DbType.String, Guia.tipo_doc)
            db.AddInParameter(cmd, "Ano", DbType.String, Guia.Ano)
            db.AddInParameter(cmd, "Mes", DbType.String, Guia.Mes)
            db.AddInParameter(cmd, "Dia", DbType.String, Guia.Dia)
            db.AddInParameter(cmd, "Usuario", DbType.String, Guia.user_crea)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarMovimientoPorAjuste = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   *****   usp_RAL_IngresoTransferencia                        *****  

#Region "Listar Movimientos Ingreso Transferencia"
    Public Function ListarIngresoTransferencia(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.IngresoTransferencia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "NumDoc", DbType.String, Guia.numdoc)
            db.AddInParameter(cmd, "TipoDoc", DbType.String, Guia.tipo_doc)
            db.AddInParameter(cmd, "Ano", DbType.String, Guia.Ano)
            db.AddInParameter(cmd, "Mes", DbType.String, Guia.Mes)
            db.AddInParameter(cmd, "Dia", DbType.String, Guia.Dia)
            db.AddInParameter(cmd, "Usuario", DbType.String, Guia.user_crea)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarIngresoTransferencia = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   *****   usp_RAL_SalidaRemarcado                             *****   

#Region "Listar Movimientos Salida por Cambio de Producto - Remarcado"
    Public Function ListarSalidaRemarcado(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.SalidaRemarcado)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "NumDoc", DbType.String, Guia.numdoc)
            db.AddInParameter(cmd, "TipoDoc", DbType.String, Guia.tipo_doc)
            db.AddInParameter(cmd, "Ano", DbType.String, Guia.Ano)
            db.AddInParameter(cmd, "Mes", DbType.String, Guia.Mes)
            db.AddInParameter(cmd, "Dia", DbType.String, Guia.Dia)
            db.AddInParameter(cmd, "Usuario", DbType.String, Guia.user_crea)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarSalidaRemarcado = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   *****   usp_RAL_Eliminacion_Total                           *****

#Region "Eliminacion Total de Billetes"
    Public Function EliminacionTotal(ByVal Guia As ETGuia) As ETResultado

        Dim ETResultado As New ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd4 As DbCommand = db.GetStoredProcCommand(usp_RAL.Eliminacion_Total)

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd4, "Cod_Cia", DbType.String, Guia.cod_cia)
                db.AddInParameter(cmd4, "Tipo_Mov", DbType.String, Guia.tipo_mov)
                db.AddInParameter(cmd4, "Tipo_Doc", DbType.String, Guia.tipo_doc)
                db.AddInParameter(cmd4, "Numero_Documento", DbType.String, Guia.numdoc)

                IntRes = db.ExecuteNonQuery(cmd4, Trans)

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


    '   *****   usp_RAL_ConvertirNumeroIngreso                      *****   

#Region "Convertir Cantidad Ingreso Almacen"
    Public Function ConvertirIngresoAlmacen(ByVal Producto As ETProducto, ByVal Cantidad As Decimal) As ETResultado


        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ConvertirNumeroIngreso)

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Producto.cod_cia)
            db.AddInParameter(cmd, "UM_Origen", DbType.String, Producto.unidad)
            db.AddInParameter(cmd, "Codigo", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Cantidad", DbType.Decimal, Cantidad)
            db.AddInParameter(cmd, "UM_Destino", DbType.String, Producto.UnidadDesp)
            db.AddOutParameter(cmd, "Valor", DbType.Double, 16)
            db.ExecuteNonQuery(cmd)

            ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Valor"))

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


    '   *****   usp_RAL_ListarDetalleIngresoOC                      *****   

#Region "Listar Detalle Ingreso Orden Compra"
    Public Function ListarDetalleIngresoOC(ByVal Guia As ETGuia) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DetalleIngresoOC)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "Numero_Guia", DbType.String, Guia.numdoc)
            db.AddInParameter(cmd, "tipo_doc", DbType.String, Guia.Tipo_Doc)
            db.AddInParameter(cmd, "tipo_mov", DbType.String, Guia.tipo_mov)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarDetalleIngresoOC = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region


    '   *****   usp_RAL_ListarDetalleIngresoAjuste                  *****

#Region "Listar Detalle Ingreso Por Ajuste"
    Public Function ListarDetalleIngresoAjuste(ByVal Guia As ETGuia) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DetalleIngresoAjuste)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "NumeroDocumento", DbType.String, Guia.numdoc)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarDetalleIngresoAjuste = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region


    '   *****   usp_RAL_ListarDetalleIngresoRemarcado               *****   

#Region "Listar Detalle Ingreso Por cambio de producto - REMARCADO"
    Public Function ListarDetalleIngresoRemarcado(ByVal Guia As ETGuia) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DetalleIngresoRemarcado)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "NumeroDocumento", DbType.String, Guia.numdoc)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarDetalleIngresoRemarcado = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region


    '   *****   usp_RAL_ListarDetalleIngresoSinOC                   *****   

#Region "Listar Detalle Ingreso Sin Orden Compra"
    Public Function ListarDetalleIngresoSinOC(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DetalleIngresoSinOC)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.Cod_Cia)
            db.AddInParameter(cmd, "Numero_Guia", DbType.String, Guia.NumDoc)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable

            If Ds IsNot Nothing AndAlso Ds.Tables.Count <> 0 Then
                Tabla = Ds.Tables(0).Copy
            End If

            ListarDetalleIngresoSinOC = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region


    '   *****   usp_RAL_ListarDetalleSalidaTransferencia            *****

#Region "Listar Detalle Salida Por Transferencia "
    Public Function ListarDetalleSalidaTransferencia(ByVal Guia As ETGuia) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DetalleSalidaTransferencia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "Numero_Guia", DbType.String, Guia.numdoc)
            db.AddInParameter(cmd, "Cod_Almacen", DbType.String, Guia.cod_alm)
            db.AddInParameter(cmd, "Opcion", DbType.String, "LI1")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable

            If Ds IsNot Nothing AndAlso Ds.Tables.Count <> 0 Then
                Tabla = Ds.Tables(0).Copy
            End If

            ListarDetalleSalidaTransferencia = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region


    '   *****   usp_RAL_ListarSalidaTransferenciaCantera            *****

#Region "Listar Detalle Salida Transferencia para Canteras"
    Public Function ListarSalidaTransferenciaCantera(ByVal Guia As ETGuia) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarSalidaTransferenciaCantera)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "Num_Doc", DbType.String, Guia.numdoc)
            db.AddInParameter(cmd, "Cod_Almacen", DbType.String, Guia.cod_alm)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarSalidaTransferenciaCantera = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try



    End Function

#End Region


    '   *****   usp_RAL_ListarDetalleSalidaRemarcado                *****   

#Region "Listar Detalle Salida Remarcado"
    Public Function ListarDetalleSalidaRemarcado(ByVal Guia As ETGuia) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DetalleSalidaRemarcado)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "NumeroDocumento", DbType.String, Guia.numdoc)
            db.AddInParameter(cmd, "Codigo_Almacen", DbType.String, Guia.cod_alm)
            db.AddInParameter(cmd, "Opcion", DbType.String, "LIS")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarDetalleSalidaRemarcado = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region


    '   *****   usp_alm_consulta_billetes_pendientes_envio_canteras *****   

#Region "Listar Billetes Pendientes de Envio a Canteras"
    Public Function ListarBilletesEnvioCantera(ByVal Guia As ETGuia) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Pendientes_Envio_Cantera)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "codcia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "cantera", DbType.String, Guia.cod_cantera)
            db.AddInParameter(cmd, "Contratista", DbType.String, Guia.cod_cli)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarBilletesEnvioCantera = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region


    '   *****   usp_RAL_ListarDetalleSalidaDevolucion               *****   

#Region "Listar Detalle Salida por Devolucion"
    Public Function ListarDetalleSalidaDevolucion(ByVal Guia As ETGuia) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DetalleSalidaDevolucion)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "Numero_Guia", DbType.String, Guia.numdoc)
            db.AddInParameter(cmd, "tipo_doc", DbType.String, Guia.tipo_doc)
            db.AddInParameter(cmd, "tipo_mov", DbType.String, Guia.tipo_mov)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy


            ListarDetalleSalidaDevolucion = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region


    '   *****   usp_RAL_ListarDatosContratista                      *****
    '   Opcion  :   DC1     =>  Listar Detalle Guia Remision
    '   Opcion  :   DC2     =>  Listar Contratistas

#Region "Listar GR y Contratista"
    Public Function Listar_GR_Contratista(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DatosContratista)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Almacen", DbType.String, Guia.Cod_Alm2)
            db.AddInParameter(cmd, "Cod_Alm_I", DbType.String, Guia.Cod_Alm)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Listar_GR_Contratista = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region


    '   *****   usp_alm_verificar_devolucion                        *****

#Region "Verificar devolucion de la O/C"
    Public Function VerificaDevolucion(ByVal Guia As ETGuia) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Verificar_Devolucion)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "codcia", DbType.String, Guia.cod_cia)
            db.AddInParameter(cmd, "numdoc", DbType.String, Guia.numdoc)
            db.AddInParameter(cmd, "tipdoc", DbType.String, Guia.tipo_doc)
            db.AddInParameter(cmd, "tipmov", DbType.String, Guia.tipo_mov)
            db.AddInParameter(cmd, "nrooc", DbType.String, Guia.NumDoc2)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            VerificaDevolucion = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

#End Region


    '   *****   usp_RAL_OrdenCompraPendientesIngreso                *****
    '   Opcion  :   CAB     =>  Listar Cabecera Orden de Cómpra Pendiente de Ingreso - Productos
    '   Opcion  :   CS2     =>  Listar Cabecera Orden de Cómpra Pendiente de Ingreso - Control de Servicios
    '   Opcion  :   DET     =>  Listar Detalle Orden de Cómpra Pendiente de Ingreso

#Region "Orden de Compra Pendiente de Ingreso - Productos"
    Public Function OCPendienteIngresoProductos(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.OCPendientesIngreso)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cod_cia", DbType.String, Guia.Cod_Cia)
            db.AddInParameter(cmd, "Nro_OC", DbType.String, Guia.Num_Ord_Exp)
            db.AddInParameter(cmd, "Usuario", DbType.String, Guia.User_Crea)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Guia.Fecha)
            db.AddInParameter(cmd, "FechaFin", DbType.DateTime, Guia.Fecha2)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            OCPendienteIngresoProductos = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    '   *****   usp_RAL_OrdenCompraIngresoAlmacen                   *****
    '   Opcion  :   CAB     =>  Listar Cabecera Orden de Compra con Ingreso en Almacén
    '   Opcion  :   DET     =>  Listar Detalle Orden de Cómpra con Ingreso en Almacén


#Region "Orden de Compra con Ingreso en Almacén"
    Public Function OCIngresoAlmacen(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.OCIngresoAlmacen)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cod_cia", DbType.String, Guia.Cod_Cia)
            db.AddInParameter(cmd, "Nro_OC", DbType.String, Guia.Num_Ord_Exp)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, Guia.Fecha)
            db.AddInParameter(cmd, "FechaFin", DbType.DateTime, Guia.Fecha2)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            OCIngresoAlmacen = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region


    Public Function Serie_Movimiento(ByVal Cia As String, ByVal Almacen As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Almacen)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)
            db.AddInParameter(cmd, "Cod_Alm", DbType.String, Almacen)
            db.AddInParameter(cmd, "Opcion", DbType.String, "GEN")

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Serie_Movimiento = Tabla.Rows(0).Item("Serie")

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function
End Class
