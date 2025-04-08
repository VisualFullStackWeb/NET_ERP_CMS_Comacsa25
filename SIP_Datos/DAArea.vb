Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports SIP_Entidad

Public Class DAArea
    Public Function Consulta_Area(ByVal EntArea As ETArea) As ETMyLista
        Dim lResul As ETMyLista = Nothing
        If EntArea Is Nothing Then
            Return Nothing
        End If

        Dim Cia As String = String.Empty
        If String.IsNullOrEmpty(EntArea.Cod_Cia) Then
            Cia = Companhia
        Else
            Cia = EntArea.Cod_Cia
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase
        Try

            Using Conexion As DbConnection = db.CreateConnection
                Conexion.Open()
                Dim cmd As DbCommand = db.GetStoredProcCommand(GPA_ERP_COMACSA.Area)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Cia)
                db.AddInParameter(cmd, "Codigo", DbType.String, EntArea.Codigo)
                db.AddInParameter(cmd, "Descripcion", DbType.String, EntArea.Area)
                db.AddInParameter(cmd, "Abrev", DbType.String, EntArea.Abrev)
                db.AddInParameter(cmd, "User", DbType.String, EntArea.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.String, EntArea.Tipo.ToString)
                lResul = New ETMyLista
                Using dr As IDataReader = db.ExecuteReader(cmd)
                    While dr.Read
                        Entidad.Area = New ETArea
                        With Entidad.Area
                            .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                            .Area = dr.GetString(dr.GetOrdinal("Area"))
                            .Abrev = dr.GetString(dr.GetOrdinal("Abrev"))
                            lResul.Ls_Area.Add(Entidad.Area)

                        End With
                    End While
                    If dr IsNot Nothing Then dr.Close()
                    lResul.Validacion = Boolean.TrueString
                End Using
                Conexion.Close()
            End Using
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResul = Nothing
        End Try

        Return lResul
    End Function
End Class
