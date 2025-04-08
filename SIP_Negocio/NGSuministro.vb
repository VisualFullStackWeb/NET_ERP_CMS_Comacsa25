Imports SIP_Entidad
Imports SIP_Datos

Public Class NGSuministro

    Public Function ConsultarSuministro() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Suministro.ConsultarSuministro

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarSuministro2(ByVal Producto As ETProducto) As DataTable

        Return Datos.Suministro.ConsultarSuministro2(Producto)

    End Function


    Public Function ConsultarSuministro3(ByVal Suministro As ETSuministro) As DataTable
        Return Datos.Suministro.ConsultarSuministro3(Suministro)
    End Function
    

    Public Function ConsultarSuministro4() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Suministro.ConsultarSuministro4
        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function ConsultarSuministro5() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Suministro.ConsultarSuministro5

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function MantenimientoEmpaques(ByVal Rpt As ETSuministro, ByVal Ls_Suministro As List(Of ETSuministro)) As ETSuministro

        Dim lResult As ETSuministro = Nothing
        If Rpt Is Nothing OrElse Ls_Suministro Is Nothing Then
            Return lResult
        End If

Ingreso:

        lResult = New ETSuministro

        If String.IsNullOrEmpty(Rpt.CodSuministro) Then
            Rpt.CodSuministro = String.Empty
        Else
            Rpt.CodSuministro = Rpt.CodSuministro.Trim
        End If

        If Rpt.CodSuministro.Length = 0 Then Rpt.Tipo = 1

        If Rpt.CodSuministro.Length = 8 Then Rpt.Tipo = 2

        Select Case Rpt.Status
            Case "K2"
                Rpt.Status = "I"
            Case "K3"
                Rpt.Status = "*"
            Case Else
                Rpt.Status = ""
        End Select

        If String.IsNullOrEmpty(Rpt.Descripcion) Then
            MsgBox("Ingrese el Nombre del Suministro", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        Else
            Rpt.Descripcion = Rpt.Descripcion.Trim
        End If

        If String.IsNullOrEmpty(Rpt.Usuario) Then
            MsgBox("Ingrese el Usuario", MsgBoxStyle.Exclamation, msgComacsa)
            Return lResult
        End If

Operacion:
        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            Return lResult
        Else
            MantenimientoEmpaques = Datos.Suministro.MantenimientoEmpaques(Rpt, Ls_Suministro)
        End If
Salida:
        If lResult Is Nothing Then
            lResult = New ETSuministro
        Else
            MsgBox("Se Guardaron Correctamente los Datos", MsgBoxStyle.Information, msgComacsa)
            lResult.Validacion = Boolean.TrueString
        End If

        Return lResult

    End Function

    Public Function CuadroxOrdenxSuministro(ByVal P As ETProducto) As List(Of ETSuministro)

Ingreso:

        CuadroxOrdenxSuministro = New List(Of ETSuministro)

        If P.CodProducto = Nothing OrElse P.CodProducto = String.Empty Then
            MsgBox("Ingrese el Producto", MsgBoxStyle.Exclamation, msgComacsa)
            Return Nothing
        End If

Operacion:

        CuadroxOrdenxSuministro = Datos.Suministro.CuadroxOrdenxSuministro(P)

Salida:

        If CuadroxOrdenxSuministro Is Nothing OrElse CuadroxOrdenxSuministro.Count = 0 Then
            MsgBox("No posee Empaques Registrados", MsgBoxStyle.Exclamation, msgComacsa)
            Return Nothing
        Else
            Return CuadroxOrdenxSuministro
        End If

    End Function

    Public Function ConsultaConsumoSuministro(ByVal Criterio As ETPedido) As DataSet

        Return Datos.Suministro.ConsultaConsumoSuministro(Criterio)

    End Function



End Class
