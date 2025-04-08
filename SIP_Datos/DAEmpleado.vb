Imports SIP_Entidad
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data


Public Class DAEmpleado
    Public Function ConsultarPagoTrabajador(ByVal Empleado As ETEmpelado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Empleado.ListarPagoTrabajador)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Opcion", DbType.String, Empleado.Opcion)
            db.AddInParameter(cmd, "Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.String, Empleado.TipoPago)
            db.AddInParameter(cmd, "PlaCod", DbType.String, Empleado.CodPla)
            db.AddInParameter(cmd, "Cod_Maestro3", DbType.String, Empleado.Motivo)
            db.AddInParameter(cmd, "FechaPago", DbType.DateTime, Empleado.Fecha)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarPagoTrabajador = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Prueba(ByVal Empleado As ETEmpelado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Empleado.Prueba)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Try
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Prueba = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function MantPagoTrabajador(ByVal Empleado As ETEmpelado) As Int32
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Empleado.MantPagoTrabajador)
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Accion", DbType.String, Empleado.Accion)
            db.AddInParameter(cmd, "Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "PlaCod", DbType.String, Empleado.CodPla)
            db.AddInParameter(cmd, "Cod_Maestro3", DbType.String, Empleado.Motivo)
            db.AddInParameter(cmd, "Sec", DbType.String, Empleado.Sec)
            db.AddInParameter(cmd, "Tipo", DbType.String, Empleado.TipoPago)
            db.AddInParameter(cmd, "FechaPago", DbType.DateTime, Empleado.Fecha)
            db.AddInParameter(cmd, "Observacion", DbType.String, Empleado.Observaciones)
            db.AddInParameter(cmd, "Fecha_Creacion", DbType.DateTime, DateTime.Now)
            db.AddInParameter(cmd, "Cod_Usuario", DbType.String, Empleado.Usuario)
            db.AddInParameter(cmd, "Pc_Creacion", DbType.String, Empleado.Terminal)
            db.ExecuteDataSet(cmd)

            MantPagoTrabajador = 1

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
End Class
