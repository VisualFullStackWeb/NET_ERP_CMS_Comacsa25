Imports System.Math
Imports SIP_Entidad
Imports SIP_Datos

Public Class NGReporte
    Private NgO As NGOrden
    Private L As List(Of ETOrden)

    Public Function ReportexCuadroxActivo(ByVal P As ETProducto) As List(Of ETActivo)


Ingreso:

        ReportexCuadroxActivo = New List(Of ETActivo)

        If P.CodProducto = Nothing OrElse P.CodProducto = String.Empty Then
            MsgBox("Ingrese el Producto", MsgBoxStyle.Exclamation, msgComacsa)
            Return Nothing
        End If

        If Not IsNumeric(P.ID) OrElse P.ID = 0 Then
            MsgBox("Ingrese el Enlace del Producto", MsgBoxStyle.Exclamation, msgComacsa)
            Return Nothing
        End If

        If Not IsNumeric(P.Cantidad) OrElse P.Cantidad = 0 Then
            MsgBox("Ingrese la Cantidad a Producir", MsgBoxStyle.Exclamation, msgComacsa)
            Return Nothing
        End If

        If Not IsDate(P.Fecha) Then
            MsgBox("Ingrese la Fecha ha Producir", MsgBoxStyle.Exclamation, msgComacsa)
            Return Nothing
        End If

        If Not IsNumeric(P.Turno) OrElse P.Turno = 0 Then
            MsgBox("Ingrese el Turno", MsgBoxStyle.Exclamation, msgComacsa)
            Return Nothing
        End If


Operacion:

        ReportexCuadroxActivo = Datos.Reporte.ReportexCuadroxActivo(P)

Salida:

        If ReportexCuadroxActivo Is Nothing OrElse ReportexCuadroxActivo.Count = 0 Then

            MsgBox("No posee DistribuciÓn Unidad - Producto", MsgBoxStyle.Exclamation, msgComacsa)
            Return Nothing

        Else

            Return ReportexCuadroxActivo

        End If

    End Function

    Public Function CalculosxCuadroxActivo(ByVal P As ETProducto) As DataTable

Ingreso:

        Dim ListA As List(Of ETActivo)
        Dim dtActivo As New DataTable

        With dtActivo
            .Columns.Add("Action")
            .Columns.Add("CodEnlace")
            .Columns.Add("CodClase")
            .Columns.Add("CodTipo")
            .Columns.Add("Placa")
            .Columns.Add("DesMaquina")
            .Columns.Add("Rendimiento")
            .Columns.Add("Energia")
            .Columns.Add("NroOperarios")
            .Columns.Add("CostoPromxHora")
            .Columns.Add("CostoKwxHora")
            .Columns.Add("MODhhxtn")
            .Columns.Add("MODSolxtn")
            .Columns.Add("EnergiaSolxtn")
            .Columns.Add("MaquinaSolxTon")
            .Columns.Add("CostoTotal")

        End With

Operacion:

        ListA = New List(Of ETActivo)

        ListA = ReportexCuadroxActivo(P)

Salida:
        For Each Y As ETActivo In ListA

            Dim wRow As DataRow = dtActivo.NewRow
            wRow("Action") = False
            wRow("CodEnlace") = Y.ID
            wRow("CodClase") = Y.CodClase
            wRow("CodTipo") = Y.CodTipo
            wRow("Placa") = Y.Placa
            wRow("DesMaquina") = Y.Descripcion
            wRow("Rendimiento") = Y.Rendimiento
            wRow("Energia") = Y.Energia
            wRow("NroOperarios") = Y.NroOperarios
            wRow("CostoPromxHora") = Y.CostoPromxHora
            wRow("CostoKwxHora") = Y.CostoKwxHora
            wRow("MODhhxtn") = Round(Y.NroOperarios / Y.Rendimiento, 4)
            wRow("MODSolxtn") = Round(Y.CostoPromxHora * (Y.NroOperarios / Y.Rendimiento), 4)
            wRow("EnergiaSolxtn") = Round(Y.CostoKwxHora * Y.Energia, 4)
            wRow("MaquinaSolxTon") = Round(Y.CostoPromxHora * (Y.NroOperarios / Y.Rendimiento) + Y.CostoKwxHora * Y.Energia, 4)
            wRow("CostoTotal") = Round(P.Cantidad * (Y.CostoPromxHora * (Y.NroOperarios / Y.Rendimiento) + Y.CostoKwxHora * Y.Energia), 4)
            dtActivo.Rows.Add(wRow)

        Next

        Return dtActivo

    End Function

End Class
