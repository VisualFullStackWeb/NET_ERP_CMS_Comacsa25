Imports SIP_Entidad
Imports SIP_Datos

Public Class NGUsuario

    Private List As List(Of ETUsuario)

    Public Function ConsultarPermisos(ByVal U As ETUsuario) As ETObjecto

Ingreso:
        Entidad.Objecto = New ETObjecto
        Datos.Usuario = New DAUsuario


Operacion:

        Entidad.Objecto = Datos.Usuario.ConsultarPermisos(U)

Salida:

        If Entidad.Objecto Is Nothing Then
            Entidad.Objecto = New ETObjecto
        Else
            If Entidad.Objecto.Respuesta <> 0 Then
                Select Case U.Tipo
                    Case 1
                        MsgBox("Usuario y/o Clave Incorrectos", MsgBoxStyle.Exclamation, msgComacsa)
                    Case 2
                        MsgBox("No tiene permisos suficientes para acceder al Modulo", MsgBoxStyle.Exclamation, msgComacsa)
                    Case 3
                        MsgBox("No tiene permisos suficientes para realizar la Acción", MsgBoxStyle.Exclamation, msgComacsa)
                    Case 4
                        MsgBox("No tiene permisos suficientes para generar el Reporte", MsgBoxStyle.Exclamation, msgComacsa)
                End Select
            Else
                If U.Tipo = 1 Then
                    'MsgBox("Bienvenido al ERP Comacsa", MsgBoxStyle.Information, msgComacsa)
                End If
                Entidad.Objecto.Validacion = True
            End If
        End If

        Return Entidad.Objecto

    End Function

    Public Function ConsultarConexion(ByVal U As ETObjecto) As ETObjecto
Ingreso:

        Datos.Usuario = New DAUsuario
        Entidad.Objecto = New ETObjecto
Operacion:
        Entidad.Objecto = Datos.Usuario.ConsultarConexion(U)
Salida:
        If Entidad.Objecto Is Nothing Then
            Entidad.Objecto = New ETObjecto
        Else
            If Entidad.Objecto.Respuesta <> 0 Then
                Select Case U.Tipo
                    Case 1
                        MsgBox("No se puede ubicar el Servidor", MsgBoxStyle.Exclamation, msgComacsa)
                    Case 2
                        MsgBox("No se puede ubicar la Base de Datos", MsgBoxStyle.Exclamation, msgComacsa)
                End Select
            Else
                Entidad.Objecto.Validacion = True
            End If
        End If
        Return Entidad.Objecto
    End Function

    Public Function ConsultarUsuario() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Usuario.ConsultarUsuario()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ConsultarDisponibilidadUsuario(ByVal Usuario As ETUsuario) As ETObjecto
        Return Datos.Usuario.ConsultarDisponibilidadUsuario(Usuario)
    End Function
    Public Function MantenimientoUsuarioArea(ByVal Usuario As ETUsuario) As String
        Try

            Return Datos.Usuario.MantenimientoUsuarioArea(Usuario)

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try
    End Function

    Public Function MantenimientoUsuario(ByVal Usuario As ETUsuario, ByVal Opciones As List(Of ETUsuario)) As ETObjecto
        MantenimientoUsuario = New ETObjecto
        List = New List(Of ETUsuario)

Ingreso:

        Try

            If Not (Usuario.Tipo = 1 OrElse Usuario.Tipo = 2) Then
                Return MantenimientoUsuario
            End If

            If String.IsNullOrEmpty(Usuario.Usuario) Then
                MsgBox("Ingrese el Usuario", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoUsuario
            Else
                Usuario.Usuario = Usuario.Usuario.Trim
            End If

            If Usuario.Tipo = 1 Then
                MantenimientoUsuario = ConsultarDisponibilidadUsuario(Usuario)
                If MantenimientoUsuario Is Nothing OrElse MantenimientoUsuario.Respuesta = 0 Then
                    MsgBox("Error : El Usuario ya Existe", MsgBoxStyle.Exclamation, msgComacsa)
                    Return MantenimientoUsuario
                End If
            End If

            If String.IsNullOrEmpty(Usuario.Contrasenha) Then
                MsgBox("Ingrese la Contraseña", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoUsuario
            Else
                Usuario.Contrasenha = Usuario.Contrasenha.Trim
            End If

            If String.IsNullOrEmpty(Usuario.PlaCod) Then
                MsgBox("Ingrese el Encargado", MsgBoxStyle.Exclamation, msgComacsa)
                Return MantenimientoUsuario
            Else
                Usuario.Encargado = Usuario.Encargado.Trim
            End If

            If String.IsNullOrEmpty(Usuario.Email) Then
                Usuario.Email = String.Empty
            Else
                Usuario.Email = Usuario.Email.Trim()
            End If

            If Usuario.Estado = "E" Then
                Usuario.Estado = "*"
            ElseIf Usuario.Estado = "I" Then
                Usuario.Estado = "I"
            Else
                Usuario.Estado = ""
            End If

            For Each W As ETUsuario In Opciones
                If W.Action Then
                    List.Add(W)
                End If
            Next

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & MsgErrorIngreso, MsgBoxStyle.Critical, msgComacsa)
            Return MantenimientoUsuario

        End Try
Operacion:

        If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
            MantenimientoUsuario.Validacion = False
            Return MantenimientoUsuario
        Else
            MantenimientoUsuario = Datos.Usuario.MantenimientoUsuario(Usuario, List)
        End If

Salida:

        If MantenimientoUsuario Is Nothing OrElse MantenimientoUsuario.Respuesta <> 0 Then
            MantenimientoUsuario = New ETObjecto
            MantenimientoUsuario.Validacion = False
            Return MantenimientoUsuario
        Else
            MsgBox("Se Guardaron los cambios correctamente", MsgBoxStyle.Information, msgComacsa)
            MantenimientoUsuario.Validacion = True
            Return MantenimientoUsuario
        End If
    End Function

    Public Function ConsultarOpcionesUsuario(ByVal U As ETUsuario) As List(Of ETUsuario)
        Return Datos.Usuario.ConsultarOpcionesUsuario(U)
    End Function

    Public Function ConsultarFechaHora(ByVal O As ETObjecto) As ETObjecto
Ingreso:

        Datos.Usuario = New DAUsuario
        Entidad.Objecto = New ETObjecto
Operacion:
        Entidad.Objecto = Datos.Usuario.ConsultarFechaHora(O)
Salida:
        If Entidad.Objecto Is Nothing Then
            Entidad.Objecto = New ETObjecto
        Else
            If Entidad.Objecto.Respuesta <> 0 Then
                MsgBox("No se puede Obtener la Fecha y Hora del Sistema", MsgBoxStyle.Exclamation, msgComacsa)
            Else
                If Not (Year(Now) = Year(Entidad.Objecto.Fecha) AndAlso _
                        Month(Now) = Month(Entidad.Objecto.Fecha) AndAlso _
                        Day(Now) = Day(Entidad.Objecto.Fecha)) Then
                    MsgBox("La Fecha del Servidor no Coincide con la Fecha de la Terminal", MsgBoxStyle.Exclamation, msgComacsa)
                Else
                    Entidad.Objecto.Validacion = True
                End If
            End If
        End If
        Return Entidad.Objecto


    End Function

    Public Function ConsultarAyuda(ByVal Rpt As ETUsuario) As ETUsuario

        Dim lResult As New ETUsuario
        If Rpt Is Nothing Then
            Return lResult
        End If

        If String.IsNullOrEmpty(Rpt.KeyForm) Then
            Return lResult
        End If

        lResult = Datos.Usuario.ConsultarAyuda(Rpt)

        If lResult Is Nothing Then lResult = New ETUsuario

        Return lResult

    End Function


    '====================================================================0

    Public Function Users(ByVal Usuario As ETUsuario) As Boolean
        Return Datos.Usuario.Users(Usuario)
    End Function

    Public Function AgregarUsers(ByVal UsersBE As ETUsuario, ByVal B As List(Of ETUsuario), ByVal C As List(Of ETUsuario)) As ETResultado
        Return Datos.Usuario.AgregarUsers(UsersBE, B, C)
    End Function
    '@ID  @USUARIO   @FECHA    @MOTIVO
    '---------------------------------
    '@01  JSIESQUEN  05012023  Permisos para editar registros en liquidación


    '@01 Add ini
    Public Function PermisoEdicionLiquidacion(ByVal Usuario As ETUsuario) As Boolean
        Return Datos.Usuario.ListarPermisoEditarLiquidaciones(Usuario)
    End Function
    '@01 Add fin

    Public Function UpdateCambioPassword(ByVal Users As ETUsuario) As ETResultado
        Return Datos.Usuario.UpdateCambioPassword(Users)
    End Function

    Public Function ConsultarConexion(ByVal Tipo As Integer) As ETResultado
        Return Datos.Usuario.ConsultarConexion(Tipo)
    End Function

    Public Function ListarMenus(ByVal Reg As ETUsuario) As DataTable
        Return Datos.Usuario.ListarMenus(Reg)
    End Function

    Public Function ListarUsers(ByVal Reg As ETUsuario, ByVal Opcion As String) As DataTable
        Return Datos.Usuario.ListarUsers(Reg, Opcion)
    End Function



    Public Function ObtenerArea_Usuario(ByVal Reg As ETUsuario, ByVal Opcion As String) As String
        Return Datos.Usuario.Obtener_AreaUsuario(Reg, Opcion)
    End Function

    Public Function ObtenerArea_Mantto(ByVal Reg As ETUsuario, ByVal Opcion As String) As String
        Return Datos.Usuario.Obtener_AreaMantto(Reg, Opcion)
    End Function

    Public Function ListarMenuUsers3(ByVal Reg As String) As DataTable
        Return Datos.Usuario.ListarMenuUsers3(Reg)
    End Function

    Public Function ListarTools(ByVal Login As String, ByVal Form As String) As DataTable
        Return Datos.Usuario.ListarTools(Login, Form)
    End Function

    Public Function ListarDescripcionDiseno(ByVal KeyForm As String, ByVal Opcion As String) As DataTable
        Return Datos.Usuario.ListarDescripcionDiseno(KeyForm, Opcion)
    End Function

    Public Function AreaAprobacionRequerimiento(ByVal UsersBE As ETUsuario, ByVal Requerimiento As List(Of ETUsuario), ByVal OrdenCompra As List(Of ETUsuario), ByVal Opcion As String) As ETResultado
        Return Datos.Usuario.AreaAprobacionRequerimiento(UsersBE, Requerimiento, OrdenCompra, Opcion)
    End Function

    Public Function EliminarAreaAprobacionRequerimiento(ByVal UsersBE As ETUsuario) As ETResultado
        Return Datos.Usuario.EliminarAreaAprobacionRequerimiento(UsersBE)
    End Function

    Public Function FirmasDigitales(ByVal Firma As List(Of ETUsuario)) As ETResultado
        Return Datos.Usuario.FirmasDigitales(Firma)
    End Function

    Public Function UsersFirma(ByVal User As ETUsuario, ByVal Opcion As String) As DataTable
        Return Datos.Usuario.UsersFirma(User, Opcion)
    End Function

    Public Function MostrarFirma(ByVal User As ETUsuario) As DataSet
        Return Datos.Usuario.MostrarFirma(User)
    End Function

    Public Function ListarCia(ByVal User As ETUsuario, ByVal Opcion As String) As DataTable
        Return Datos.Usuario.ListarCia(User, Opcion)
    End Function

    Public Function ListarProveedoresCia(ByVal User As ETUsuario) As DataTable
        Return Datos.Usuario.ListarProveedoresCia(User)
    End Function

    Public Function MovimientosAlmacen(ByVal User As ETUsuario, ByVal Opcion As String) As DataTable
        Return Datos.Usuario.MovimientosAlmacen(User, Opcion)
    End Function

    Public Function MovimientosAlmacen_NC() As DataTable
        Return Datos.Usuario.MovimientosAlmacen_NC()
    End Function

    Public Function Area_Usuario(ByVal usuario As String) As DataTable
        Return Datos.Usuario.Area_Usuario(usuario)
    End Function
    Public Function DocIdentidad_Usuario(ByVal usuario As String) As DataTable
        Return Datos.Usuario.DocIdentidad_Usuario(usuario)
    End Function

    Public Function MotivoTraslado_Usuario(ByVal usuario As String) As DataTable
        Return Datos.Usuario.MotivoTrabsladoSunat_Usuario(usuario)
    End Function


    Public Function ListarAlmacen(ByVal usuario As String) As DataTable
        Return Datos.Usuario.ListarAlmacen(usuario)
    End Function
    Public Function ListarAlmacenSolicitante(ByVal usuario As String) As DataTable
        Return Datos.Usuario.ListarAlmacenSolicitante(usuario)
    End Function

    Public Function Carga_Empleo(ByVal cod_maestro2 As String) As DataTable
        Return Datos.Usuario.Carga_Empleo(cod_maestro2)
    End Function

    Public Function ConsultarERP_1(ByVal Rpt As ETUsuario) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Usuario.ConsultarERP_1(Rpt)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function ConsultarERP_2(ByVal Rpt As ETUsuario) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Usuario.ConsultarERP_2(Rpt)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function ConsultarERP_3(ByVal Rpt As ETUsuario) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Usuario.ConsultarERP_3(Rpt)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function GrabarFormulario(ByVal Usuario As ETUsuario) As ETResultado
        Return Datos.Usuario.GrabarFormulario(Usuario)
    End Function

    Public Function ListarFormulario() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        lResult = New ETMyLista
        lResult = Datos.Usuario.ListarFormulario()

        If lResult Is Nothing Then
            lResult = New ETMyLista
        Else
            If Not lResult.Validacion Then
                MsgBox("No se pudieron Cargar los datos Correctamente", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        End If

        Return lResult

    End Function

    Public Function ListarFormulario(ByVal U As ETUsuario, ByVal Opcion As Integer) As DataTable
        Return Datos.Usuario.ListarFormulario(U, Opcion)
    End Function


End Class


