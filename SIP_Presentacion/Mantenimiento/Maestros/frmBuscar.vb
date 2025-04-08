Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports SIP_Entidad
Imports SIP_Negocio

Public Class frmBuscar

#Region "Propiedades"
    Public Property ID() As Long
        Get
            Return _ID
        End Get
        Set(ByVal value As Long)
            _ID = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
    Public Property Flag1() As Long
        Get
            Return _Flag1
        End Get
        Set(ByVal value As Long)
            _Flag1 = value
        End Set
    End Property
    Public Property Flag2() As String
        Get
            Return _Flag2
        End Get
        Set(ByVal value As String)
            _Flag2 = value
        End Set
    End Property
    Public Property Flag3() As String
        Get
            Return _Flag3
        End Get
        Set(ByVal value As String)
            _Flag3 = value
        End Set
    End Property
    Public Property Flag4() As String
        Get
            Return _Flag4
        End Get
        Set(ByVal value As String)
            _Flag4 = value
        End Set
    End Property
    Public Property Flag5() As String
        Get
            Return _Flag5
        End Get
        Set(ByVal value As String)
            _Flag5 = value
        End Set
    End Property
    Public Property Flag6() As String
        Get
            Return _Flag6
        End Get
        Set(ByVal value As String)
            _Flag6 = value
        End Set
    End Property
    Public Property Flag7() As String
        Get
            Return _Flag7
        End Get
        Set(ByVal value As String)
            _Flag7 = value
        End Set
    End Property
    Public Property Flag8() As Date
        Get
            Return _Flag8
        End Get
        Set(ByVal value As Date)
            _Flag8 = value
        End Set
    End Property
    Public Property Flag9() As Date
        Get
            Return _Flag9
        End Get
        Set(ByVal value As Date)
            _Flag9 = value
        End Set
    End Property

    Public Property Flag10() As Integer
        Get
            Return _Flag10
        End Get
        Set(ByVal value As Integer)
            _Flag10 = value
        End Set
    End Property
    Public Property Flag11() As Integer
        Get
            Return _Flag11
        End Get
        Set(ByVal value As Integer)
            _Flag11 = value
        End Set
    End Property
    Public Property Flag12() As Long
        Get
            Return _Flag12
        End Get
        Set(ByVal value As Long)
            _Flag12 = value
        End Set
    End Property
    Public Property Flag13() As Long
        Get
            Return _Flag13
        End Get
        Set(ByVal value As Long)
            _Flag13 = value
        End Set
    End Property
    Public Property Flag14() As String
        Get
            Return _Flag14
        End Get
        Set(ByVal value As String)
            _Flag14 = value
        End Set
    End Property
    Public Property Flag15() As String
        Get
            Return _Flag15
        End Get
        Set(ByVal value As String)
            _Flag15 = value
        End Set
    End Property
    Public Property Flag16() As String
        Get
            Return _Flag16
        End Get
        Set(ByVal value As String)
            _Flag16 = value
        End Set
    End Property
    Public Property Flag17() As String
        Get
            Return _Flag17
        End Get
        Set(ByVal value As String)
            _Flag17 = value
        End Set
    End Property
    Public Property Flag18() As String
        Get
            Return _Flag18
        End Get
        Set(ByVal value As String)
            _Flag18 = value
        End Set
    End Property
    Public Property Flag19() As String
        Get
            Return _Flag19
        End Get
        Set(ByVal value As String)
            _Flag19 = value
        End Set
    End Property

    Public Property TipoReporte() As Short
        Get
            Return _TipoReporte
        End Get
        Set(ByVal value As Short)
            _TipoReporte = value
        End Set
    End Property
    Public Property ID_Input() As Long
        Get
            Return _ID_Input
        End Get
        Set(ByVal value As Long)
            _ID_Input = value
        End Set
    End Property
    Public Property Codigo_Input() As String
        Get
            Return _Codigo_Input
        End Get
        Set(ByVal value As String)
            _Codigo_Input = value
        End Set
    End Property
    Public Property FechaInput() As Date
        Get
            Return _Fecha_Input
        End Get
        Set(ByVal value As Date)
            _Fecha_Input = value
        End Set
    End Property
#End Region
#Region "Declarar Variables"
    Private _ID As Long = 0

    Private _Descripcion As String = String.Empty
    Private _Flag1 As Long = 0
    Private _Flag2 As String = String.Empty
    Private _Flag3 As String = String.Empty
    Private _Flag4 As String = String.Empty
    Private _Flag5 As String = String.Empty
    Private _Flag6 As String = String.Empty
    Private _Flag7 As String = String.Empty
    Private _Flag8 As Date = Date.Today
    Private _Flag9 As Date = Date.Today
    Private _Flag10 As Integer = 0
    Private _Flag11 As Integer = 0
    Private _Flag12 As Long = 0
    Private _Flag13 As Long = 0
    Private _Flag14 As String = String.Empty
    Private _Flag15 As String = String.Empty
    Private _Flag16 As String = String.Empty
    Private _Flag17 As String = String.Empty
    Private _Flag18 As String = String.Empty
    Private _Flag19 As String = String.Empty

    Private _TipoReporte As Short = 0
    Private _ID_Input As Long = 0
    Private _Codigo_Input As String = String.Empty
    Private _Fecha_Input As Date = Date.Today

    Public Enum eState
        frm_Personal = 1
        frm_Equipo = 2
        frm_Requerimiento = 3
        frm_Partida_Mantto_Equipo = 4
        frm_Recurso_Partida = 5
        frm_Cliente = 6
        frm_Equipo_Por_Familia = 7
        frm_Cargo_Empleado = 8
        frm_Orden_Trabajo_BackLog = 9
        frm_Area_Jefatura = 10
        frm_OTs_EnEjecucion = 11
        frm_Area_Empleado = 12
        frm_Catalogo_Activos_Disponible_Enlace = 13
        frm_Catalogo_Activos = 14
        frm_Producto_Terminado = 15
        frm_Producto_Suministros = 16
        frm_Producto_Minerales = 17
        frm_Personal_LineaProduccion = 18
        frm_PersonalTemp = 19
        frm_Personal_Obrero = 20
        frm_Catalogo_molino = 21
    End Enum

    Public Formulario As eState
    Private Ls_Equipo As List(Of ETEquipo) = Nothing
    Private Ls_Personal As List(Of ETPersonal) = Nothing
    Private Ls_Requerimiento As List(Of ETRequerimiento_Mantto) = Nothing
    Private Ls_PartidaMaterial As List(Of ETPartidaMaterial) = Nothing
    Private Ls_PartidaEquipo As List(Of ETPartidaEquipo) = Nothing
    Private Ls_PartidaManoObra As List(Of ETPartidaManoObra) = Nothing
    Private Ls_PartidaServicio As List(Of ETPartidaServicio) = Nothing
    Private Ls_Cliente As List(Of ETCliente) = Nothing
    Private Ls_OrdenTrabajoOrigen As List(Of ETOrdenTrabajo_Mantto) = Nothing
    Private Ls_AreaJefatura As List(Of ETAreaJefatura) = Nothing
    Private Ls_OTsEnEjecucion As List(Of ETOrdenTrabajo_Mantto) = Nothing
    Private Ls_AreEmpleado As List(Of ETAreaEmpleado) = Nothing
    Private Ls_Activo As List(Of ETActivo) = Nothing
    Private Ls_Producto As List(Of ETProducto) = Nothing

#End Region
#Region "Procedimientos Privados"
    Private Sub CargarGrilla()
        Select Case Formulario
            Case eState.frm_Equipo
                Me.Text = ".:::Buscar Equipo:::."
                Call Cargar_Equipo()
            Case eState.frm_Personal
                Me.Text = ".:::Buscar Personal:::."
                Call Cargar_Personal_Activo()

            Case eState.frm_PersonalTemp
                Me.Text = ".:::Buscar Personal:::."
                Call Cargar_Personal_Temp()

            Case eState.frm_Requerimiento
                Me.Text = ".:::Buscar Requerimiento:::."
                Call Cargar_Requerimiento_Activo()
            Case eState.frm_Partida_Mantto_Equipo
                Me.Text = ".:::Buscar Familia Equipo:::."
                Call Cargar_FamiliaEquipo()
            Case eState.frm_Recurso_Partida
                Select Case TipoReporte
                    Case 1
                        Me.Text = ".:::Buscar Material:::."
                    Case 2
                        Me.Text = ".:::Buscar Familia Equipo:::."
                    Case 3
                        Me.Text = ".:::Buscar Cargo:::."
                    Case 4
                        Me.Text = ".:::Buscar Servicio:::."
                End Select

                Call Cargar_Recurso_Partida()
            Case eState.frm_Cliente
                Me.Text = ".:::Buscar Cliente:::."
                Call Cargar_Cliente_Activo()
            Case eState.frm_Equipo_Por_Familia
                Me.Text = ".:::Buscar Equipo:::."
                Call Cargar_Equipo_Por_Familia()
            Case eState.frm_Cargo_Empleado
                Me.Text = ".:::Buscar Personal:::."
                Call Cargar_Cargo_Empleado()
            Case eState.frm_Orden_Trabajo_BackLog
                Me.Text = ".:::Buscar Orden de Trabajo Origen:::."
                Call Cargar_OrdenTrabajo_Origen()
            Case eState.frm_Area_Jefatura
                Me.Text = ".:::Buscar Jefe de Area:::."
                Call Cargar_Area_Jefatura_Activa()
            Case eState.frm_OTs_EnEjecucion
                Me.Text = ".:::Buscar Orden de Trabajo:::."
                Call Cargar_OTs_EnEjecucion()
            Case eState.frm_Area_Empleado
                Me.Text = ".:::Buscar Empleado:::."
                Call Cargar_Area_Empleado()

            Case eState.frm_Catalogo_Activos_Disponible_Enlace
                Me.Text = ".:::Buscar Activo:::."
                Call Cargar_Activos_PendientesEnlaceContabilidad()

            Case eState.frm_Catalogo_Activos
                Me.Text = ".:::Buscar Activo:::."
                Call Cargar_Activos()
            Case eState.frm_Catalogo_molino
                Me.Text = ".:::Buscar Molino:::."
                Call Cargar_Molinos()
            Case eState.frm_Producto_Terminado
                Me.Text = ".:::Buscar Productos Terminados:::."
                Call Cargar_Productos_Terminados()
            Case eState.frm_Producto_Suministros
                Me.Text = ".:::Buscar Productos Suministros:::."
                Call Cargar_Productos_Suministros()
            Case eState.frm_Producto_Minerales
                Me.Text = ".:::Buscar Productos Minerales:::."
                Call Cargar_Productos_Minerales()
            Case eState.frm_Personal_LineaProduccion
                Me.Text = ".:::Buscar Personal:::."
                Call Cargar_Personal_LineProduccion()
            Case eState.frm_Personal_Obrero
                Me.Text = ".:::Buscar Personal:::."
                Call Cargar_Personal_Obrero_Activo()
        End Select
    End Sub
    Private Sub Cargar_Personal_LineProduccion()
        Entidad.Personal = New ETPersonal
        Entidad.Personal.ID = Me.ID
        Entidad.Personal.Fecha = Me.FechaInput
        Entidad.Personal.Tipo = 5
        Negocio.Personal = New NGPersonal
        Entidad.MyLista = New ETMyLista
        Ls_Personal = New List(Of ETPersonal)
        Entidad.MyLista = Negocio.Personal.Consultar_LineaProduccion_Personal(Entidad.Personal)

        If Entidad.MyLista.Validacion Then
            Ls_Personal = Entidad.MyLista.Ls_Personal
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Personal)
    End Sub

    Private Sub Cargar_Productos_Suministros()

        Ls_Producto = New List(Of ETProducto)
        Entidad.Producto = New ETProducto
        Entidad.Producto.Tipo = 7
        Dim dtDatos As New DataTable
        dtDatos = Negocio.Producto.ConsultarProducto(Entidad.Producto)
        'Entidad.MyLista = Negocio.Producto.ConsultarProducto(Entidad.Producto)
        'If Entidad.MyLista.Validacion Then
        '    Ls_Producto = Entidad.MyLista.Ls_Producto
        'End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, dtDatos)
    End Sub

    Private Sub Cargar_Productos_Minerales()

        Ls_Producto = New List(Of ETProducto)
        Entidad.Producto = New ETProducto
        Entidad.Producto.Tipo = 8
        Dim dtDatos As New DataTable
        dtDatos = Negocio.Producto.ConsultarProducto(Entidad.Producto)
        'If Entidad.MyLista.Validacion Then
        '    Ls_Producto = Entidad.MyLista.Ls_Producto
        'End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, dtDatos)
    End Sub

    Private Sub Cargar_Productos_Terminados()

        Ls_Producto = New List(Of ETProducto)
        Entidad.Producto = New ETProducto
        Entidad.Producto.Tipo = 10
        Dim dtDatos As New DataTable
        dtDatos = Negocio.Producto.ConsultarProducto(Entidad.Producto)
        'If Entidad.MyLista.Validacion Then
        '    Ls_Producto = Entidad.MyLista.Ls_Producto
        'End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, dtDatos)
    End Sub

    Private Sub Cargar_Activos()

        Ls_Activo = New List(Of ETActivo)
        Entidad.MyLista = Negocio.Activo.ConsultarActivo9

        If Entidad.MyLista.Validacion Then
            Ls_Activo = Entidad.MyLista.Ls_Activo
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Activo)
    End Sub

    Private Sub Cargar_Molinos()

        Ls_Activo = New List(Of ETActivo)
        Entidad.MyLista = Negocio.Activo.ConsultarActivo10

        If Entidad.MyLista.Validacion Then
            Ls_Activo = Entidad.MyLista.Ls_Activo
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Activo)
    End Sub


    Private Sub Cargar_Activos_PendientesEnlaceContabilidad()

        Entidad.Activo.Activo = Me.ID_Input

        Ls_Activo = New List(Of ETActivo)
        Entidad.MyLista = Negocio.Activo.ConsultarActivo8(Entidad.Activo)

        If Entidad.MyLista.Validacion Then
            Ls_Activo = Entidad.MyLista.Ls_Activo
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Activo)
    End Sub

    Private Sub Cargar_Area_Empleado()

        Entidad.AreaEmpleado.Codigo = Me.Codigo_Input
        Entidad.AreaEmpleado.FechaInicio = Me.FechaInput
        Entidad.AreaEmpleado.Cia = Companhia
        Entidad.AreaEmpleado.Tipo = TipoReporte

        Ls_AreEmpleado = New List(Of ETAreaEmpleado)
        Entidad.MyLista = Negocio.AreaEmpleado.Consultar_Area_Empleado(Entidad.AreaEmpleado)

        If Entidad.MyLista.Validacion Then
            Ls_AreEmpleado = Entidad.MyLista.Ls_AreaEmpleado
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_AreEmpleado)
    End Sub

    Private Sub Cargar_OTs_EnEjecucion()

        Entidad.OrdenTrabajo.FechaInicio = Me.FechaInput
        Entidad.OrdenTrabajo.Area = Me.Codigo_Input
        Entidad.OrdenTrabajo.Tipo = 8

        Ls_OTsEnEjecucion = New List(Of ETOrdenTrabajo_Mantto)
        Entidad.MyLista = Negocio.Orden_Trabajo.Consultar_OTsEnEjecucion(Entidad.OrdenTrabajo)


        If Entidad.MyLista.Validacion Then
            Ls_OTsEnEjecucion = Entidad.MyLista.Ls_Orden_Trabajo_Mantto
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_OTsEnEjecucion)
    End Sub

    Private Sub Cargar_Area_Jefatura_Activa()
        Entidad.AreaJefatura = New ETAreaJefatura
        Entidad.AreaJefatura.FechaInicio = Me.FechaInput
        Entidad.AreaJefatura.Tipo = 5

        Negocio.AreaJefatura = New NGAreaJefatura

        Entidad.MyLista = New ETMyLista
        Ls_AreaJefatura = New List(Of ETAreaJefatura)
        Entidad.MyLista = Negocio.AreaJefatura.Consultar_AreaJefetura_Activa(Entidad.AreaJefatura)


        If Entidad.MyLista.Validacion Then
            Ls_AreaJefatura = Entidad.MyLista.Ls_AreaJefatura
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_AreaJefatura)
    End Sub

    Private Sub Cargar_OrdenTrabajo_Origen()
        Entidad.OrdenTrabajo_Recursos = New ETOrdenTrabajo_Recursos
        Entidad.OrdenTrabajo_Recursos.RecursoID = Me.ID_Input
        Negocio.Orden_Trabajo = New NGOrdenTrabajo_Mantto
        Entidad.MyLista = New ETMyLista
        Ls_OrdenTrabajoOrigen = New List(Of ETOrdenTrabajo_Mantto)
        Entidad.MyLista = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_Origen(Entidad.OrdenTrabajo_Recursos)

        If Entidad.MyLista.Validacion Then
            Ls_OrdenTrabajoOrigen = Entidad.MyLista.Ls_Orden_Trabajo_Mantto
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_OrdenTrabajoOrigen)
    End Sub

    Private Sub Cargar_Cargo_Empleado()
        Entidad.Personal = New ETPersonal
        Entidad.Personal.Cargo = Me.Codigo_Input
        Entidad.Personal.Fecha = Me._Fecha_Input
        Entidad.Personal.Tipo = 4
        Negocio.Personal = New NGPersonal
        Entidad.MyLista = New ETMyLista
        Ls_Personal = New List(Of ETPersonal)
        Entidad.MyLista = Negocio.Personal.ConsultarPersonal4(Entidad.Personal)

        If Entidad.MyLista.Validacion Then
            Ls_Personal = Entidad.MyLista.Ls_Personal
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Personal)
    End Sub

    Private Sub Cargar_Recurso_Partida()
        Select Case TipoReporte
            Case 1
                Call Cargar_Recurso_Material()
            Case 2
                Call Cargar_Recurso_Equipo()
            Case 3
                Call Cargar_Recurso_ManoObra()
            Case 4
                Call Cargar_Recurso_Servicio()
        End Select
    End Sub
    Private Sub Cargar_Recurso_Material()
        Negocio.Partida_Mantto = New NGPartida
        Entidad.MyLista = New ETMyLista
        Ls_PartidaMaterial = New List(Of ETPartidaMaterial)
        Entidad.MyLista = Negocio.Partida_Mantto.Consultar_Lista_Material

        If Entidad.MyLista.Validacion Then
            Ls_PartidaMaterial = Entidad.MyLista.Ls_Partida_Material
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_PartidaMaterial)

    End Sub
    Private Sub Cargar_Recurso_Equipo()
        Negocio.Partida_Mantto = New NGPartida
        Entidad.MyLista = New ETMyLista
        Ls_PartidaEquipo = New List(Of ETPartidaEquipo)
        Entidad.MyLista = Negocio.Partida_Mantto.Consultar_Lista_Equipo

        If Entidad.MyLista.Validacion Then
            Ls_PartidaEquipo = Entidad.MyLista.Ls_Partida_Equipo
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_PartidaEquipo)

    End Sub
    Private Sub Cargar_Recurso_ManoObra()
        Negocio.Partida_Mantto = New NGPartida
        Entidad.MyLista = New ETMyLista
        Ls_PartidaManoObra = New List(Of ETPartidaManoObra)
        Entidad.MyLista = Negocio.Partida_Mantto.Consultar_Lista_ManoObra

        If Entidad.MyLista.Validacion Then
            Ls_PartidaManoObra = Entidad.MyLista.Ls_Partida_ManoObra
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_PartidaManoObra)

    End Sub

    Private Sub Cargar_Recurso_Servicio()
        Negocio.Partida_Mantto = New NGPartida
        Entidad.MyLista = New ETMyLista
        Ls_PartidaServicio = New List(Of ETPartidaServicio)
        Entidad.MyLista = Negocio.Partida_Mantto.Consultar_Lista_Servicio

        If Entidad.MyLista.Validacion Then
            Ls_PartidaServicio = Entidad.MyLista.Ls_Partida_Servicio
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_PartidaServicio)

    End Sub
    Private Sub Cargar_Equipo()

        Negocio.Equipo = New NGEquipo
        Entidad.MyLista = New ETMyLista
        Ls_Equipo = New List(Of ETEquipo)
        Entidad.MyLista = Negocio.Equipo.Consultar_Equipo_Activo()

        If Entidad.MyLista.Validacion Then
            Ls_Equipo = Entidad.MyLista.Ls_Equipo
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Equipo)

    End Sub

    Private Sub Cargar_Equipo_FamiliaEq()

        Negocio.Equipo = New NGEquipo
        Entidad.MyLista = New ETMyLista
        Ls_Equipo = New List(Of ETEquipo)
        Entidad.MyLista = Negocio.Equipo.Consultar_Equipo_Activo()

        If Entidad.MyLista.Validacion Then
            Ls_Equipo = Entidad.MyLista.Ls_Equipo
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Equipo)

    End Sub

    Private Sub Cargar_FamiliaEquipo()

        Negocio.Partida_Mantto = New NGPartida
        Entidad.Partida_Mantto = New ETPartida
        With Entidad.Partida_Mantto
            .Tipo = Me.TipoReporte
            .Partida = Me.ID_Input
        End With
        Dim ds As DataSet
        ds = Negocio.Partida_Mantto.Consultar_Partida_Nodo(Entidad.Partida_Mantto)
        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, ds)

    End Sub
    Private Sub Cargar_Personal_Activo()
        Dim ObjPers As New ETPersonal
        ObjPers.Tipo = 3
        Negocio.Personal = New NGPersonal
        Entidad.MyLista = New ETMyLista
        Ls_Personal = New List(Of ETPersonal)

        Entidad.MyLista = Negocio.Personal.ConsultarPersonal3(ObjPers)

        If Entidad.MyLista.Validacion Then
            Ls_Personal = Entidad.MyLista.Ls_Personal
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Personal)

    End Sub

    Private Sub Cargar_Personal_Obrero_Activo()
        Dim ObjPers As New ETPersonal
        ObjPers.Fecha = FechaInput
        ObjPers.Tipo = 7
        Negocio.Personal = New NGPersonal
        Entidad.MyLista = New ETMyLista
        Ls_Personal = New List(Of ETPersonal)

        Entidad.MyLista = Negocio.Personal.ConsultarPersonal7(ObjPers)

        If Entidad.MyLista.Validacion Then
            Ls_Personal = Entidad.MyLista.Ls_Personal
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Personal)

    End Sub

    Private Sub Cargar_Personal_Temp()
        Dim ObjPers As New ETPersonal
        ObjPers.Tipo = 6
        Negocio.Personal = New NGPersonal
        Entidad.MyLista = New ETMyLista
        Ls_Personal = New List(Of ETPersonal)

        Entidad.MyLista = Negocio.Personal.ConsultarPersonal3(ObjPers)

        If Entidad.MyLista.Validacion Then
            Ls_Personal = Entidad.MyLista.Ls_Personal
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Personal)

    End Sub

    Private Sub Cargar_Requerimiento_Activo()
        Negocio.Requerimiento_Mantto = New NGRequerimiento_Mantto
        Entidad.MyLista = New ETMyLista
        Ls_Requerimiento = New List(Of ETRequerimiento_Mantto)

        Entidad.MyLista = Negocio.Requerimiento_Mantto.ConsultarRequerimiento_Pendientes_Programacion

        If Entidad.MyLista.Validacion Then
            Ls_Requerimiento = Entidad.MyLista.Ls_Requerimiento_Mantto
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Requerimiento)

    End Sub
    Private Sub Cargar_Cliente_Activo()
        Entidad.MyLista = New ETMyLista
        Ls_Cliente = New List(Of ETCliente)
        Negocio.Cliente = New NGCliente
        Entidad.MyLista = Negocio.Cliente.Consultar_Cliente_Activos

        If Entidad.MyLista.Validacion Then
            Ls_Cliente = Entidad.MyLista.Ls_Cliente
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Cliente)

    End Sub

    Private Sub Cargar_Equipo_Por_Familia()

        Entidad.Equipo = New ETEquipo
        Entidad.Equipo.FamiliaEqID = Me.ID_Input
        Entidad.Equipo.Equipo = Val(Me.Codigo_Input)
        Negocio.Equipo = New NGEquipo
        Entidad.MyLista = New ETMyLista
        Ls_Equipo = New List(Of ETEquipo)
        Entidad.MyLista = Negocio.Equipo.Consultar_Equipo_Por_Familia(Entidad.Equipo)

        If Entidad.MyLista.Validacion Then
            Ls_Equipo = Entidad.MyLista.Ls_Equipo
        End If

        Call CargarUltraGridxBinding(Me.Grid1, Me.Source1, Ls_Equipo)

    End Sub
#End Region
#Region "Formularios"
    Private Sub frmBuscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Call CargarGrilla()
    End Sub

#End Region
#Region "Grillas"

    Private Sub Grid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow
        If e Is Nothing Then
            Exit Sub
        End If
        If Grid1.Rows.Count <= 0 Then Return
        If Grid1.ActiveRow Is Nothing Then Return
        If Grid1.ActiveRow.Index < 0 Then Return

        Select Case Formulario
            Case eState.frm_Equipo
                Me.ID = Grid1.ActiveRow.Cells("Equipo").Value
                Me.Descripcion = Grid1.ActiveRow.Cells("Descripcion").Value
                Me.Flag1 = Grid1.ActiveRow.Cells("AtribID").Value
                Me.Flag2 = Grid1.ActiveRow.Cells("Atributo").Value
                Me.Flag3 = Grid1.ActiveRow.Cells("Und").Value
                Me.Flag4 = Grid1.ActiveRow.Cells("TipoDato").Value.ToString
                Me.Flag5 = Grid1.ActiveRow.Cells("longitud").Value.ToString
                Me.Flag6 = Grid1.ActiveRow.Cells("decimales").Value.ToString
                Me.Flag7 = Grid1.ActiveRow.Cells("codigo").Value.ToString
            Case eState.frm_Personal, eState.frm_Personal_LineaProduccion, eState.frm_PersonalTemp, eState.frm_Personal_Obrero
                Me.Descripcion = Grid1.ActiveRow.Cells("DesPersonal").Value
                Me.Flag2 = Grid1.ActiveRow.Cells("CodPersonal").Value
            Case eState.frm_Requerimiento
                Me.Descripcion = Grid1.ActiveRow.Cells("Codigo").Value
                Me.ID = Grid1.ActiveRow.Cells("Requerimiento").Value
            Case eState.frm_Partida_Mantto_Equipo
                Me.Descripcion = Grid1.ActiveRow.Cells("Codigo").Value & "  " & Grid1.ActiveRow.Cells("Descripcion").Value
                Me.ID = Grid1.ActiveRow.Cells("IDCatalogo").Value
            Case eState.frm_Recurso_Partida
                Select Case TipoReporte
                    Case 1
                        Descripcion = Grid1.ActiveRow.Cells("Material").Value
                        Flag2 = Grid1.ActiveRow.Cells("Cod_Mat").Value
                        Flag4 = Grid1.ActiveRow.Cells("Nro_OC").Value.ToString
                    Case 2
                        Descripcion = Grid1.ActiveRow.Cells("Equipo").Value
                        Flag2 = Grid1.ActiveRow.Cells("Cod_Eq").Value
                        ID = Grid1.ActiveRow.Cells("EquipoID").Value
                    Case 3
                        Descripcion = Grid1.ActiveRow.Cells("Cargo").Value
                        Flag2 = Grid1.ActiveRow.Cells("Cod_Cargo").Value
                    Case 4
                        Descripcion = Grid1.ActiveRow.Cells("Servicio").Value
                        Flag2 = Grid1.ActiveRow.Cells("Cod_Ser").Value
                        Flag4 = Grid1.ActiveRow.Cells("Nro_OC").Value.ToString
                End Select
                Flag3 = Grid1.ActiveRow.Cells("Precio").Value.ToString
                Flag5 = Grid1.ActiveRow.Cells("Cod_UniMed").Value.ToString
            Case eState.frm_Cliente
                Me.Descripcion = Grid1.ActiveRow.Cells("Descripcion").Value
                Me.Flag2 = Grid1.ActiveRow.Cells("Codigo").Value
                Me.Flag3 = Grid1.ActiveRow.Cells("RUC").Value

            Case eState.frm_Equipo_Por_Familia
                Me.Descripcion = Grid1.ActiveRow.Cells("Descripcion").Value
                Me.Flag2 = Grid1.ActiveRow.Cells("Codigo").Value
                Me.ID = Grid1.ActiveRow.Cells("Equipo").Value

            Case eState.frm_Cargo_Empleado
                Me.Descripcion = Grid1.ActiveRow.Cells("DesPersonal").Value
                Me.Flag2 = Grid1.ActiveRow.Cells("CodPersonal").Value

            Case eState.frm_Orden_Trabajo_BackLog
                Me.ID = Grid1.ActiveRow.Cells("OrdenTrabajo").Value
                Me.Flag2 = Grid1.ActiveRow.Cells("Codigo").Value

                Me.Flag1 = Grid1.ActiveRow.Cells("EquipoID").Value
                Me.Flag3 = Grid1.ActiveRow.Cells("Equipo").Value
                Me.Flag4 = Grid1.ActiveRow.Cells("EncargadoArea").Value
                Me.Flag5 = Grid1.ActiveRow.Cells("Cod_EncargadoArea").Value
                Me.Flag6 = Grid1.ActiveRow.Cells("Cod_UniMed").Value
                Me.Flag7 = Grid1.ActiveRow.Cells("TipoDato").Value
                Me.Flag10 = Grid1.ActiveRow.Cells("Longitud").Value
                Me.Flag11 = Grid1.ActiveRow.Cells("Decimales").Value
                Me.Flag12 = Grid1.ActiveRow.Cells("AtributoControl").Value
                Me.Flag13 = Grid1.ActiveRow.Cells("Cod_Requerimiento").Value
                Me.Flag14 = Grid1.ActiveRow.Cells("TipoProceso").Value
                Me.Flag15 = Grid1.ActiveRow.Cells("Atributo").Value
                Me.Flag16 = Grid1.ActiveRow.Cells("ValorControl").Value
                Me.Flag17 = Grid1.ActiveRow.Cells("Moneda").Value
                Me.Flag18 = Grid1.ActiveRow.Cells("AreaInterna").Value
                Me.Flag19 = Grid1.ActiveRow.Cells("Cod_AreaInt").Value

                Me.Flag8 = Grid1.ActiveRow.Cells("FechaInicio").Value
                Me.Flag9 = Grid1.ActiveRow.Cells("FechaTerminacion").Value

            Case eState.frm_Area_Jefatura
                Me.Descripcion = Grid1.ActiveRow.Cells("JefeArea").Value
                Me.Flag2 = Grid1.ActiveRow.Cells("Cod_JefeArea").Value
                Me.Flag3 = Grid1.ActiveRow.Cells("Area").Value
                Me.Flag4 = Grid1.ActiveRow.Cells("Cod_Area").Value
                Me.Flag5 = Grid1.ActiveRow.Cells("FechaInicioTxt").Value
                Me.Flag6 = Grid1.ActiveRow.Cells("FechaTerminoTxt").Value

            Case eState.frm_OTs_EnEjecucion
                Me.Descripcion = Grid1.ActiveRow.Cells("Descripcion").Value
                Me.Flag2 = Grid1.ActiveRow.Cells("Cod_Presp").Value
                Me.Flag8 = Grid1.ActiveRow.Cells("FechaInicio").Value
                Me.Flag9 = Grid1.ActiveRow.Cells("FechaTerminacion").Value
                Me.ID = Grid1.ActiveRow.Cells("OrdenTrabajo").Value

            Case eState.frm_Area_Empleado
                Me.Descripcion = Grid1.ActiveRow.Cells("ApePaterno").Value & " " & Grid1.ActiveRow.Cells("ApeMaterno").Value & ", " & Grid1.ActiveRow.Cells("Nombres").Value
                Me.Flag2 = Grid1.ActiveRow.Cells("Cod_Emp").Value
                Me.Flag3 = Grid1.ActiveRow.Cells("FechaInicioTxt").Value
                Me.Flag4 = Grid1.ActiveRow.Cells("FechaTerminoTxt").Value
                Me.ID = Grid1.ActiveRow.Cells("AreaEmpleado").Value
            Case eState.frm_Catalogo_Activos_Disponible_Enlace
                Me.Flag2 = Grid1.ActiveRow.Cells("Codigo").Value

            Case eState.frm_Catalogo_Activos, eState.frm_Catalogo_molino
                Me.Flag2 = Grid1.ActiveRow.Cells("Codigo").Value
                Me.Descripcion = Grid1.ActiveRow.Cells("Descripcion").Value
            Case eState.frm_Producto_Terminado, eState.frm_Producto_Minerales

                Me.Flag2 = Grid1.ActiveRow.Cells("CodProducto").Value
                Me.Descripcion = Grid1.ActiveRow.Cells("Descripcion").Value
            Case eState.frm_Producto_Suministros

                Me.Flag2 = Grid1.ActiveRow.Cells("CodProducto").Value
                Me.Descripcion = Grid1.ActiveRow.Cells("Descripcion").Value
                Me.Flag3 = Grid1.ActiveRow.Cells("Unidad").Value
           
        End Select

        Me.Close()
    End Sub

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            Select Case Formulario
                Case eState.frm_Equipo
                    If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                            OrElse uColumn.Key = "LinNeg" OrElse uColumn.Key = "FamiliaEq") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If

                Case eState.frm_Personal, eState.frm_Personal_LineaProduccion, eState.frm_PersonalTemp, eState.frm_Personal_Obrero
                    uColumn.CellActivation = Activation.NoEdit
                    If uColumn.Key = "CodPersonal" Then
                        uColumn.Header.Caption = "Código"
                        uColumn.MaxWidth = 120
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "DesPersonal" Then
                        uColumn.Header.Caption = "Personal"
                        uColumn.Hidden = Boolean.FalseString
                    Else
                        uColumn.Hidden = Boolean.TrueString
                    End If
                Case eState.frm_Requerimiento
                    uColumn.CellActivation = Activation.NoEdit
                    If uColumn.Key = "Codigo" Then
                        uColumn.Header.Caption = "Requerimiento"
                        uColumn.MaxWidth = 100
                        uColumn.MinWidth = 80
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "Area" Then
                        uColumn.Header.Caption = "Área"
                        uColumn.MaxWidth = 200
                        uColumn.MinWidth = 200
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "Solicitante" Then
                        uColumn.Header.Caption = "Solicitante"
                        uColumn.MaxWidth = 150
                        uColumn.MinWidth = 150
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "Dirigido" Then
                        uColumn.Header.Caption = "Encargado Mantto"
                        uColumn.MaxWidth = 150
                        uColumn.MinWidth = 150
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "Asunto" Then
                        uColumn.Header.Caption = "Asunto"
                        uColumn.MinWidth = 200
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "Fecha" Then
                        uColumn.Header.Caption = "Fecha"
                        uColumn.MaxWidth = 100
                        uColumn.MinWidth = 100
                        uColumn.Hidden = Boolean.FalseString
                    Else
                        uColumn.Hidden = Boolean.TrueString
                    End If

                Case eState.frm_Partida_Mantto_Equipo
                    If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Case eState.frm_Recurso_Partida
                    uColumn.CellActivation = Activation.NoEdit
                    Select Case TipoReporte
                        Case 1
                            If uColumn.Key = "Cod_Mat" Then
                                uColumn.Header.Caption = "Código"
                                uColumn.MaxWidth = 100
                                uColumn.MinWidth = 80
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Material" Then
                                uColumn.Header.Caption = "Material"
                                uColumn.MaxWidth = 200
                                uColumn.MinWidth = 200
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Nro_OC" Then
                                uColumn.Header.Caption = "Nro_OC"
                                uColumn.MaxWidth = 100
                                uColumn.MinWidth = 80
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "UniMed" Then
                                uColumn.Header.Caption = "Und"
                                uColumn.MaxWidth = 100
                                uColumn.MinWidth = 80
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Fecha" Then
                                uColumn.Header.Caption = "Fecha"
                                uColumn.MaxWidth = 80
                                uColumn.MinWidth = 80
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Precio" Then
                                uColumn.Header.Caption = "Precio"
                                uColumn.MinWidth = 80
                                uColumn.CellAppearance.TextHAlign = HAlign.Right
                                uColumn.Hidden = Boolean.FalseString
                            Else
                                uColumn.Hidden = Boolean.TrueString
                            End If
                        Case 2
                            If uColumn.Key = "Cod_Eq" Then
                                uColumn.Header.Caption = "Código"
                                uColumn.MaxWidth = 100
                                uColumn.MinWidth = 80
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Equipo" Then
                                uColumn.Header.Caption = "Equipo"
                                uColumn.MaxWidth = 200
                                uColumn.MinWidth = 200
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "UniMed" Then
                                uColumn.Header.Caption = "Und"
                                uColumn.MaxWidth = 100
                                uColumn.MinWidth = 80
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Fecha" Then
                                uColumn.Header.Caption = "Fecha"
                                uColumn.MaxWidth = 100
                                uColumn.MinWidth = 100
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Precio" Then
                                uColumn.Header.Caption = "Precio"
                                uColumn.MinWidth = 80
                                uColumn.CellAppearance.TextHAlign = HAlign.Right
                                uColumn.Hidden = Boolean.FalseString
                            Else
                                uColumn.Hidden = Boolean.TrueString
                            End If
                        Case 3
                            If uColumn.Key = "Cod_Cargo" Then
                                uColumn.Header.Caption = "Código"
                                uColumn.MaxWidth = 100
                                uColumn.MinWidth = 80
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Cargo" Then
                                uColumn.Header.Caption = "Cargo"
                                uColumn.MaxWidth = 200
                                uColumn.MinWidth = 200
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "UniMed" Then
                                uColumn.Header.Caption = "Und"
                                uColumn.MaxWidth = 100
                                uColumn.MinWidth = 80
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Fecha" Then
                                uColumn.Header.Caption = "Fecha"
                                uColumn.MaxWidth = 100
                                uColumn.MinWidth = 100
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Precio" Then
                                uColumn.Header.Caption = "Precio"
                                uColumn.MinWidth = 80
                                uColumn.CellAppearance.TextHAlign = HAlign.Right
                                uColumn.Hidden = Boolean.FalseString
                            Else
                                uColumn.Hidden = Boolean.TrueString
                            End If
                        Case 4
                            If uColumn.Key = "Cod_Ser" Then
                                uColumn.Header.Caption = "Código"
                                uColumn.MaxWidth = 100
                                uColumn.MinWidth = 80
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Servicio" Then
                                uColumn.Header.Caption = "Servicio"
                                uColumn.MaxWidth = 200
                                uColumn.MinWidth = 200
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Nro_OC" Then
                                uColumn.Header.Caption = "Nro_OC"
                                uColumn.MaxWidth = 100
                                uColumn.MinWidth = 80
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "UniMed" Then
                                uColumn.Header.Caption = "Und"
                                uColumn.MaxWidth = 100
                                uColumn.MinWidth = 80
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Fecha" Then
                                uColumn.Header.Caption = "Fecha"
                                uColumn.MaxWidth = 100
                                uColumn.MinWidth = 100
                                uColumn.Hidden = Boolean.FalseString
                            ElseIf uColumn.Key = "Precio" Then
                                uColumn.Header.Caption = "Precio"
                                uColumn.MinWidth = 80
                                uColumn.CellAppearance.TextHAlign = HAlign.Right
                                uColumn.Hidden = Boolean.FalseString
                            Else
                                uColumn.Hidden = Boolean.TrueString
                            End If
                    End Select
                Case eState.frm_Cliente
                    uColumn.CellActivation = Activation.NoEdit
                    If uColumn.Key = "Codigo" Then
                        uColumn.Header.Caption = "Código"
                        uColumn.MaxWidth = 120
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "Descripcion" Then
                        uColumn.Header.Caption = "Cliente"
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "RUC" Then
                        uColumn.Header.Caption = "RUC"
                        uColumn.MaxWidth = 80
                        uColumn.MinWidth = 80
                        uColumn.Hidden = Boolean.FalseString
                    Else
                        uColumn.Hidden = Boolean.TrueString
                    End If

                Case eState.frm_Equipo_Por_Familia
                    uColumn.CellActivation = Activation.NoEdit
                    If uColumn.Key = "Codigo" Then
                        uColumn.Header.Caption = "Código"
                        uColumn.MaxWidth = 0
                        uColumn.MinWidth = 80
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "Descripcion" Then
                        uColumn.Header.Caption = "Cliente"
                        uColumn.Hidden = Boolean.FalseString
                    Else
                        uColumn.Hidden = Boolean.TrueString
                    End If

                Case eState.frm_Cargo_Empleado
                    uColumn.CellActivation = Activation.NoEdit
                    If uColumn.Key = "DescripArea" Then
                        uColumn.Header.Caption = "Área"
                        uColumn.MinWidth = 150
                        uColumn.MergedCellContentArea = MergedCellContentArea.VirtualRect
                        uColumn.MergedCellStyle = MergedCellStyle.Always
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "CodPersonal" Then
                        uColumn.Header.Caption = "Código"
                        uColumn.MaxWidth = 100
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "DesPersonal" Then
                        uColumn.Header.Caption = "Personal"
                        uColumn.Hidden = Boolean.FalseString
                    Else
                        uColumn.Hidden = Boolean.TrueString
                    End If

                Case eState.frm_Orden_Trabajo_BackLog
                    uColumn.CellActivation = Activation.NoEdit
                    If uColumn.Key = "Codigo" Then
                        uColumn.Header.Caption = "Codigo"
                        uColumn.MaxWidth = 0
                        uColumn.MinWidth = 150
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "Descripcion" Then
                        uColumn.Header.Caption = "Código"
                        uColumn.MinWidth = 200
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "FechaInicio" Then
                        uColumn.MinWidth = 100
                        uColumn.MaxWidth = 100
                        uColumn.Header.Caption = "FechaInicio"
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "FechaTerminacion" Then
                        uColumn.MinWidth = 100
                        uColumn.MaxWidth = 100
                        uColumn.Header.Caption = "FechaTermino"
                        uColumn.Hidden = Boolean.FalseString
                    Else
                        uColumn.Hidden = Boolean.TrueString
                    End If

                Case eState.frm_Area_Jefatura
                    uColumn.CellActivation = Activation.NoEdit
                    If uColumn.Key = "Area" Then
                        uColumn.Header.Caption = "Área"
                        uColumn.MaxWidth = 0
                        uColumn.MinWidth = 200
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "JefeArea" Then
                        uColumn.Header.Caption = "Jefe de Área"
                        uColumn.MinWidth = 200
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "FechaInicioTxt" Then
                        uColumn.MinWidth = 100
                        uColumn.MaxWidth = 100
                        uColumn.Header.Caption = "FechaInicio"
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "FechaTerminoTxt" Then
                        uColumn.MinWidth = 100
                        uColumn.MaxWidth = 100
                        uColumn.Header.Caption = "FechaTermino"
                        uColumn.Hidden = Boolean.FalseString
                    Else
                        uColumn.Hidden = Boolean.TrueString
                    End If

                Case eState.frm_OTs_EnEjecucion
                    uColumn.CellActivation = Activation.NoEdit
                    If uColumn.Key = "Codigo" Then
                        uColumn.Header.Caption = "O/T"
                        uColumn.MaxWidth = 0
                        uColumn.MinWidth = 100
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "Descripcion" Then
                        uColumn.Header.Caption = "Descripción"
                        uColumn.MaxWidth = 0
                        uColumn.MinWidth = 200
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "FechaInicio" Then
                        uColumn.MinWidth = 65
                        uColumn.MaxWidth = 65
                        uColumn.Header.Caption = "F. Inicio"
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "FechaTerminacion" Then
                        uColumn.MinWidth = 65
                        uColumn.MaxWidth = 65
                        uColumn.Hidden = Boolean.FalseString
                        uColumn.Header.Caption = "F. Termino"
                    Else
                        uColumn.Hidden = Boolean.TrueString
                    End If
                Case eState.frm_Area_Empleado
                    uColumn.CellActivation = Activation.NoEdit
                    If uColumn.Key = "Cod_Emp" Then
                        uColumn.Header.Caption = "Código"
                        uColumn.MaxWidth = 100
                        uColumn.MinWidth = 100
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "ApePaterno" Then
                        uColumn.Header.Caption = "Ape. Paterno"
                        uColumn.MaxWidth = 0
                        uColumn.MinWidth = 100
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "ApeMaterno" Then
                        uColumn.Header.Caption = "Ape. Materno"
                        uColumn.MaxWidth = 0
                        uColumn.MinWidth = 100
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "Nombres" Then
                        uColumn.MaxWidth = 0
                        uColumn.MinWidth = 100
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "FechaInicioTxt" Then
                        uColumn.Header.Caption = "F. Inicio"
                        uColumn.MaxWidth = 0
                        uColumn.MinWidth = 65
                        uColumn.MaxWidth = 65
                        uColumn.Hidden = Boolean.FalseString
                    ElseIf uColumn.Key = "FechaTerminoTxt" Then
                        uColumn.Header.Caption = "F. Termino"
                        uColumn.MaxWidth = 0
                        uColumn.MinWidth = 65
                        uColumn.MaxWidth = 65
                        uColumn.Hidden = Boolean.FalseString
                    Else
                        uColumn.Hidden = Boolean.TrueString
                    End If

                Case eState.frm_Catalogo_Activos_Disponible_Enlace, eState.frm_Catalogo_Activos, eState.frm_Catalogo_molino
                    If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                            OrElse uColumn.Key = "CodClase" OrElse uColumn.Key = "CodTipo") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Case eState.frm_Producto_Terminado, eState.frm_Producto_Minerales
                    If Not (uColumn.Key = "CodProducto" OrElse uColumn.Key = "Descripcion") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Case eState.frm_Producto_Suministros
                    If Not (uColumn.Key = "CodProducto" OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "Unidad") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
            End Select
        Next
    End Sub
#End Region

End Class
