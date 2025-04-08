Public Class CentroCostoCargaLaboral

    Public Function validarPeriodoCarga(ByVal anio As Short, ByVal mes As Short) As Boolean

        Try
            Dim data As New SIP_Datos.CentroCostoCargaLaboral
            Dim cantidadReg As Integer = 0
            cantidadReg = Data.listarOutput("val", "val_periodo_carga", anio, mes)

            Return cantidadReg > 0

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function listarDataSetCentroCostoCargaLaboral(ByVal anio As Short, ByVal mes As Short) As DataSet

        Dim value As New DataSet

        Try
            Dim listaHojas As New ArrayList
            Dim dt As New DataTable
            dt = listadoCentroCostoCargaLaboral(anio, mes)

            For Each fila As DataRow In dt.Rows

                Dim datoMolino As String = fila("molino").ToString
                If listaHojas.Contains(datoMolino) = False Then
                    listaHojas.Add(datoMolino)
                End If
            Next

            For Each nombreHoja As String In listaHojas
                Dim nuevoDT As New DataTable
                nuevoDT = dt.Clone
                nuevoDT.TableName = nombreHoja
                nuevoDT.Clear()

                For Each fila As DataRow In dt.Select("molino='" + nombreHoja + "'")

                    Dim row As DataRow = nuevoDT.NewRow()
                    row(0) = fila.Item(0)
                    row(1) = fila.Item(1)
                    row(2) = fila.Item(2)
                    row(3) = fila.Item(3)
                    row(4) = fila.Item(4)
                    row(5) = fila.Item(5)
                    row(6) = fila.Item(6)
                    row(7) = fila.Item(7)
                    row(8) = fila.Item(8)

                    nuevoDT.Rows.Add(row)
                Next
                value.Tables.Add(nuevoDT)
            Next

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try

        Return value
    End Function
    Public Function listadoCentroCostoCargaLaboral(ByVal anio As Short, ByVal mes As Short) As DataTable

        Try

            Dim data As New SIP_Datos.CentroCostoCargaLaboral
            Return data.listar("lst", "lst_reporte_centro_costo_carga_laboral", anio, mes)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function agregarCabecera(ByVal entity As SIP_Entidad.Cabecera) As Integer

        Try

            Dim data As New SIP_Datos.CentroCostoCargaLaboral
            Return data.agregarCabecera("ins", "ins_mant", entity)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function agregarDetalle(ByVal entity As SIP_Entidad.Detalle) As Integer

        Try

            Dim data As New SIP_Datos.CentroCostoCargaLaboral
            Return data.agregarDetalle("ins", "ins_mant", entity)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function eliminarPeriodo(ByVal anio As Short, ByVal mes As Short, ByVal loginUsuario As String) As Integer

        Try

            Dim data As New SIP_Datos.CentroCostoCargaLaboral
            Return data.eliminar("del", "del_mant", anio, mes, loginUsuario)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

End Class
