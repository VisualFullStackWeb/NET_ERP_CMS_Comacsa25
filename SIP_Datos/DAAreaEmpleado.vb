Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Globalization
Imports System.Configuration

Public Class DAAreaEmpleado
    Public Function Mantenedor_AreaEmpleado(ByVal Ls_Emp_Del As List(Of ETAreaEmpleado), ByVal Ls_Emp As List(Of ETAreaEmpleado)) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                For Each Row As ETAreaEmpleado In Ls_Emp_Del
                    Dim cmd As DbCommand = db.GetStoredProcCommand(RPA_RecursosHumanos.Area_Empleado)
                    db.AddInParameter(cmd, "AreaEmpleado", DbType.Int32, Row.AreaEmpleado)
                    db.AddInParameter(cmd, "Cod_Cia", DbType.String, Row.Cia)
                    db.AddInParameter(cmd, "Area", DbType.String, Row.Codigo)
                    db.AddInParameter(cmd, "Empleado", DbType.String, Row.Cod_Emp)
                    db.AddInParameter(cmd, "FechaInicio", DbType.Date, Row.FechaInicio)
                    db.AddInParameter(cmd, "FechaTermino", DbType.Date, Row.FechaTermino)
                    db.AddInParameter(cmd, "Status", DbType.String, Row.Status)
                    db.AddInParameter(cmd, "User", DbType.String, Row.Usuario)
                    db.AddInParameter(cmd, "Tipo", DbType.String, Row.Tipo)
                    db.ExecuteNonQuery(cmd, Trans)
                Next

                For Each Row As ETAreaEmpleado In Ls_Emp
                    Dim xmd As DbCommand = db.GetStoredProcCommand(RPA_RecursosHumanos.Area_Empleado)
                    db.AddInParameter(xmd, "AreaEmpleado", DbType.Int32, Row.AreaEmpleado)
                    db.AddInParameter(xmd, "Cod_Cia", DbType.String, Row.Cia)
                    db.AddInParameter(xmd, "Area", DbType.String, Row.Codigo)
                    db.AddInParameter(xmd, "Empleado", DbType.String, Row.Cod_Emp)
                    db.AddInParameter(xmd, "FechaInicio", DbType.Date, Row.FechaInicio)
                    db.AddInParameter(xmd, "FechaTermino", DbType.Date, Row.FechaTermino)
                    db.AddInParameter(xmd, "Status", DbType.String, Row.Status)
                    db.AddInParameter(xmd, "User", DbType.String, Row.Usuario)
                    db.AddInParameter(xmd, "Tipo", DbType.String, Row.Tipo)
                    db.ExecuteNonQuery(xmd, Trans)
                Next

                Trans.Commit()
                Conexion.Close()
                Return 1
            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return 0
            End Try

        End Using

    End Function

    Public Function Consultar_AreaEmpleado(ByVal Ent_AreEmp As ETAreaEmpleado) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(RPA_RecursosHumanos.Area_Empleado)
        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Ent_AreEmp.Cia)
        db.AddInParameter(cmd, "FechaInicio", DbType.Date, Ent_AreEmp.FechaInicio)
        db.AddInParameter(cmd, "Area", DbType.String, Ent_AreEmp.Codigo)
        db.AddInParameter(cmd, "Tipo", DbType.String, Ent_AreEmp.Tipo)
        Using dr As IDataReader = db.ExecuteReader(cmd)
            lResult = New ETMyLista
            While dr.Read
                Entidad.Area_Empleado = New ETAreaEmpleado
                With Entidad.Area_Empleado
                    Select Case Ent_AreEmp.Tipo
                        Case 4
                            .Cia = dr.GetString(dr.GetOrdinal("Cia"))
                            .Compania = dr.GetString(dr.GetOrdinal("Compania"))
                            .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                            .Area = dr.GetString(dr.GetOrdinal("Area"))
                        Case 5, 6, 7, 8
                            .Cod_Emp = dr.GetString(dr.GetOrdinal("Cod_Emp"))
                            .ApePaterno = dr.GetString(dr.GetOrdinal("ApePaterno"))
                            .ApeMaterno = dr.GetString(dr.GetOrdinal("ApeMaterno"))
                            .Nombres = dr.GetString(dr.GetOrdinal("Nombres"))
                            If Ent_AreEmp.Tipo = 5 Or Ent_AreEmp.Tipo = 7 Then
                                .FechaInicioTxt = dr.GetString(dr.GetOrdinal("FechaInicioTxt"))
                                .FechaTerminoTxt = dr.GetString(dr.GetOrdinal("FechaTerminoTxt"))
                                .AreaEmpleado = dr.GetInt32(dr.GetOrdinal("AreaEmpleado"))
                            End If
                    End Select
                    lResult.Ls_AreaEmpleado.Add(Entidad.Area_Empleado)
                End With
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = True

        End Using
        Return lResult
    End Function
End Class
