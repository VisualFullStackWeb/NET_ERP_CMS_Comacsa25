Imports System.ComponentModel
Imports System.Net.Mail


Public Class ETReclamo

    Private _dias_muestra As Int32
    Public Property dias_muestra() As Int32
        Get
            Return _dias_muestra
        End Get
        Set(ByVal value As Int32)
            _dias_muestra = value
        End Set
    End Property

    Private _dias_informe As String
    Public Property dias_informe() As String
        Get
            Return _dias_informe
        End Get
        Set(ByVal value As String)
            _dias_informe = value
        End Set
    End Property

    Private _dias_produccion As String
    Public Property dias_produccion() As String
        Get
            Return _dias_produccion
        End Get
        Set(ByVal value As String)
            _dias_produccion = value
        End Set
    End Property

    Private _dias_comercial As String
    Public Property dias_comercial() As String
        Get
            Return _dias_comercial
        End Get
        Set(ByVal value As String)
            _dias_comercial = value
        End Set
    End Property

    Private _CodCia As String
    Public Property CodCia() As String
        Get
            Return _CodCia
        End Get
        Set(ByVal value As String)
            _CodCia = value
        End Set
    End Property

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _Origen As String
    Public Property Origen() As String
        Get
            Return _Origen
        End Get
        Set(ByVal value As String)
            _Origen = value
        End Set
    End Property

    Private _Tipo As String
    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Private _Nro As String
    Public Property Nro() As String
        Get
            Return _Nro
        End Get
        Set(ByVal value As String)
            _Nro = value
        End Set
    End Property

    Private _Fecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal value As DateTime)
            _Fecha = value
        End Set
    End Property

    Private _ClientCodigo As String
    Public Property ClienteCodigo() As String
        Get
            Return _ClientCodigo
        End Get
        Set(ByVal value As String)
            _ClientCodigo = value
        End Set
    End Property

    Private _Cliente As String
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property

    Private _UsuarioRegistra As ETReclamoPersona
    Public Property UsuarioRegistra() As ETReclamoPersona
        Get
            Return _UsuarioRegistra
        End Get
        Set(ByVal value As ETReclamoPersona)
            _UsuarioRegistra = value
        End Set
    End Property

    Private _FechaFin As DateTime
    Public Property FechaFin() As DateTime
        Get
            Return _FechaFin
        End Get
        Set(ByVal value As DateTime)
            _FechaFin = value
        End Set
    End Property

    Private _Estado As String
    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
        End Set
    End Property



    Private _ListaEmailsCliente As BindingList(Of ETReclamoPersona)
    Public Property ListaEmailsCliente() As BindingList(Of ETReclamoPersona)
        Get
            Return _ListaEmailsCliente
        End Get
        Set(ByVal value As BindingList(Of ETReclamoPersona))
            _ListaEmailsCliente = value
        End Set
    End Property

    Private _EjecutivoVentas As ETReclamoPersona
    Public Property EjecutivoVentas() As ETReclamoPersona
        Get
            Return _EjecutivoVentas
        End Get
        Set(ByVal value As ETReclamoPersona)
            _EjecutivoVentas = value
        End Set
    End Property

    Private _JefeResponsable As ETReclamoPersona
    Public Property JefeResponsable() As ETReclamoPersona
        Get
            Return _JefeResponsable
        End Get
        Set(ByVal value As ETReclamoPersona)
            _JefeResponsable = value
        End Set
    End Property

    Private _UsuarioResponsable As ETReclamoPersona
    Public Property UsuarioResponsable() As ETReclamoPersona
        Get
            Return _UsuarioResponsable
        End Get
        Set(ByVal value As ETReclamoPersona)
            _UsuarioResponsable = value
        End Set
    End Property

    Private _ListaMuestras As BindingList(Of ETReclamoMuestra)
    Public Property ListaMuestras() As BindingList(Of ETReclamoMuestra)
        Get
            Return _ListaMuestras
        End Get
        Set(ByVal value As BindingList(Of ETReclamoMuestra))
            _ListaMuestras = value
        End Set
    End Property

    Private _ListaMuestrasLab As BindingList(Of EtReclamoMuestraLab)
    Public Property ListaMuestrasLab() As BindingList(Of EtReclamoMuestraLab)
        Get
            Return _ListaMuestrasLab
        End Get
        Set(ByVal value As BindingList(Of EtReclamoMuestraLab))
            _ListaMuestrasLab = value
        End Set
    End Property

    Private _ListaParticipantes As BindingList(Of ETReclamoPersona)
    Public Property ListaParticipantes() As BindingList(Of ETReclamoPersona)
        Get
            Return _ListaParticipantes
        End Get
        Set(ByVal value As BindingList(Of ETReclamoPersona))
            _ListaParticipantes = value
        End Set
    End Property

    Private _EntregaMuestra As Boolean
    Public Property EntregaMuestra() As Boolean
        Get
            Return _EntregaMuestra
        End Get
        Set(ByVal value As Boolean)
            _EntregaMuestra = value
        End Set
    End Property

    Private _EntregaEvidencia As Boolean
    Public Property EntregaEvidencia() As Boolean
        Get
            Return _EntregaEvidencia
        End Get
        Set(ByVal value As Boolean)
            _EntregaEvidencia = value
        End Set
    End Property

    Private _Organizador As ETReclamoPersona
    Public Property Organizador() As ETReclamoPersona
        Get
            Return _Organizador
        End Get
        Set(ByVal value As ETReclamoPersona)
            _Organizador = value
        End Set
    End Property

    Private _ListaPlanes As BindingList(Of ETReclamoPlanAccion)

    Public Property ListaPlanes() As BindingList(Of ETReclamoPlanAccion)
        Get
            Return _ListaPlanes
        End Get
        Set(ByVal value As BindingList(Of ETReclamoPlanAccion))
            _ListaPlanes = value
        End Set
    End Property

    Private _FormatoComentarios As BindingList(Of ETReclamoPlanAccion)
    Public Property FormatoComentarios() As BindingList(Of ETReclamoPlanAccion)
        Get
            Return _FormatoComentarios
        End Get
        Set(ByVal value As BindingList(Of ETReclamoPlanAccion))
            _FormatoComentarios = value
        End Set
    End Property

    Private _FormatoPlanes As BindingList(Of ETReclamoPlanAccion)
    Public Property FormatoPlanes() As BindingList(Of ETReclamoPlanAccion)
        Get
            Return _FormatoPlanes
        End Get
        Set(ByVal value As BindingList(Of ETReclamoPlanAccion))
            _FormatoPlanes = value
        End Set
    End Property

    ''' <summary>
    ''' Usuario del SIG y copia oculta
    ''' </summary>
    ''' <remarks></remarks>
    Private _UsuariosCopiaOculta As List(Of ETReclamoPersona)
    Public Property UsuariosCopiaOculta() As List(Of ETReclamoPersona)
        Get
            Return _UsuariosCopiaOculta
        End Get
        Set(ByVal value As List(Of ETReclamoPersona))
            _UsuariosCopiaOculta = value
        End Set
    End Property



    Private _Producto As ETReclamoProducto
    Public Property Producto() As ETReclamoProducto
        Get
            Return _Producto
        End Get
        Set(ByVal value As ETReclamoProducto)
            _Producto = value
        End Set
    End Property

    Private _AprobacionProduccion As ETReclamoAprobacion
    Public Property AprobacionProduccion() As ETReclamoAprobacion
        Get
            Return _AprobacionProduccion
        End Get
        Set(ByVal value As ETReclamoAprobacion)
            _AprobacionProduccion = value
        End Set
    End Property

    Private _AprobacionComercial As ETReclamoAprobacion
    Public Property AprobacionComercial() As ETReclamoAprobacion
        Get
            Return _AprobacionComercial
        End Get
        Set(ByVal value As ETReclamoAprobacion)
            _AprobacionComercial = value
        End Set
    End Property

    Private _AprobacionGerencia As ETReclamoAprobacion
    Public Property AprobacionGerencia() As ETReclamoAprobacion
        Get
            Return _AprobacionGerencia
        End Get
        Set(ByVal value As ETReclamoAprobacion)
            _AprobacionGerencia = value
        End Set
    End Property

    Private _AprobacionLaboratorio As ETReclamoAprobacion
    Public Property AprobacionLaboratorio() As ETReclamoAprobacion
        Get
            Return _AprobacionLaboratorio
        End Get
        Set(ByVal value As ETReclamoAprobacion)
            _AprobacionLaboratorio = value
        End Set
    End Property

    'Anulacion
    Private _BitCancelado As Boolean
    Public Property Cancelado() As Boolean
        Get
            Return _BitCancelado
        End Get
        Set(ByVal value As Boolean)
            _BitCancelado = value
        End Set
    End Property

    Private _MotivoCancelacion As String
    Public Property MotivoCancelacion() As String
        Get
            Return _MotivoCancelacion
        End Get
        Set(ByVal value As String)
            _MotivoCancelacion = value
        End Set
    End Property

    Private _Motivo As String
    Public Property Motivo() As String
        Get
            Return _Motivo
        End Get
        Set(ByVal value As String)
            _Motivo = value
        End Set
    End Property

    Private _Observacion As String
    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal value As String)
            _Observacion = value
        End Set
    End Property




    Private _FechaCancelacion As DateTime
    Public Property FechaCancelacion() As DateTime
        Get
            Return _FechaCancelacion
        End Get
        Set(ByVal value As DateTime)
            _FechaCancelacion = value
        End Set
    End Property

    'Analisis
    Private _FechaAnalisis As Nullable(Of DateTime)
    Public Property FechaAnalisis() As Nullable(Of DateTime)
        Get
            Return _FechaAnalisis
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            _FechaAnalisis = value
        End Set
    End Property

    Private _Causas As BindingList(Of ETReclamoCausa)
    Public Property Causas() As BindingList(Of ETReclamoCausa)
        Get
            Return _Causas
        End Get
        Set(ByVal value As BindingList(Of ETReclamoCausa))
            _Causas = value
        End Set
    End Property

    'Reunion
    Private _PersonaAnalisis As ETReclamoPersona
    Public Property PersonaAnalisis() As ETReclamoPersona
        Get
            Return _PersonaAnalisis
        End Get
        Set(ByVal value As ETReclamoPersona)
            _PersonaAnalisis = value
        End Set
    End Property

    Private _LugarReunion As String
    Public Property LugarReunion() As String
        Get
            Return _LugarReunion
        End Get
        Set(ByVal value As String)
            _LugarReunion = value
        End Set
    End Property

    Private _FechaReunion As Nullable(Of DateTime)
    Public Property FechaReunion() As Nullable(Of DateTime)
        Get
            Return _FechaReunion
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            _FechaReunion = value
        End Set
    End Property




    '-----------------------------------------------------------------------------
    ' PRODUCTO OPCION
    '-----------------------------------------------------------------------------
    Private _ProductosOpcion As List(Of ETReclamoProductoOpcion)
    Public Property ProductosOpcion() As List(Of ETReclamoProductoOpcion)
        Get
            Return _ProductosOpcion
        End Get
        Set(ByVal value As List(Of ETReclamoProductoOpcion))
            _ProductosOpcion = value
        End Set
    End Property


    '-----------------------------------------------------------------------------
    ' SERVICIO
    '-----------------------------------------------------------------------------
    Private _Servicios As List(Of ETReclamoServicio)
    Public Property Servicios() As List(Of ETReclamoServicio)
        Get
            Return _Servicios
        End Get
        Set(ByVal value As List(Of ETReclamoServicio))
            _Servicios = value
        End Set
    End Property

    Private _ServicioObservacion As String
    Public Property ServicioObservacion() As String
        Get
            Return _ServicioObservacion
        End Get
        Set(ByVal value As String)
            _ServicioObservacion = value
        End Set
    End Property

    'Evidencias

    Private _RequiereAprobProd As Boolean
    Public Property RequiereAprobProd() As Boolean
        Get
            Return _RequiereAprobProd
        End Get
        Set(ByVal value As Boolean)
            _RequiereAprobProd = value
        End Set
    End Property

    Private _RequiereAprobLab As Boolean
    Public Property RequiereAprobLab() As Boolean
        Get
            Return _RequiereAprobLab
        End Get
        Set(ByVal value As Boolean)
            _RequiereAprobLab = value
        End Set
    End Property

    Private _RequiereAprobCom As Boolean
    Public Property RequiereAprobCom() As Boolean
        Get
            Return _RequiereAprobCom
        End Get
        Set(ByVal value As Boolean)
            _RequiereAprobCom = value
        End Set
    End Property

    Private _RequiereAprobNC As Boolean
    Public Property RequiereAprobNC() As Boolean
        Get
            Return _RequiereAprobNC
        End Get
        Set(ByVal value As Boolean)
            _RequiereAprobNC = value
        End Set
    End Property

    Private _ListaEvidencias As List(Of ETReclamoEvidencia)
    Public Property ListaEvidencias() As List(Of ETReclamoEvidencia)
        Get
            Return _ListaEvidencias
        End Get
        Set(ByVal value As List(Of ETReclamoEvidencia))
            _ListaEvidencias = value
        End Set
    End Property

    'Muestras
    Private _MuestraComentario As String
    Public Property MuestraComentario() As String
        Get
            Return _MuestraComentario
        End Get
        Set(ByVal value As String)
            _MuestraComentario = value
        End Set
    End Property

    Private _MuestraFecha As DateTime
    Public Property MuestraFecha() As DateTime
        Get
            Return _MuestraFecha
        End Get
        Set(ByVal value As DateTime)
            _MuestraFecha = value
        End Set
    End Property

    Private _RutaCorreo As String
    Public Property RutaCorreo() As String
        Get
            Return _RutaCorreo
        End Get
        Set(ByVal value As String)
            _RutaCorreo = value
        End Set
    End Property

    Private _Pareto As String
    Public Property Pareto() As String
        Get
            Return _Pareto
        End Get
        Set(ByVal value As String)
            _Pareto = value
        End Set
    End Property

    Private _Tpreob As String
    Public Property Tpreob() As String
        Get
            Return _Tpreob
        End Get
        Set(ByVal value As String)
            _Tpreob = value
        End Set
    End Property

    Private _RegNotaCredito As Boolean
    Public Property RegNotaCredito() As Boolean
        Get
            Return _RegNotaCredito
        End Get
        Set(ByVal value As Boolean)
            _RegNotaCredito = value
        End Set
    End Property

    Private _NroNCredito As String
    Public Property NroNCredito() As String
        Get
            Return _NroNCredito
        End Get
        Set(ByVal value As String)
            _NroNCredito = value
        End Set
    End Property


    Private _EstadoComentado As String
    Public Property EstadoComentado() As String
        Get
            Return _EstadoComentado
        End Get
        Set(ByVal value As String)
            _EstadoComentado = value
        End Set
    End Property


    Private _ReclamoPermisos As ETReclamoPermisos
    Public Property ReclamoPermisos() As ETReclamoPermisos
        Get
            Return _ReclamoPermisos
        End Get
        Set(ByVal value As ETReclamoPermisos)
            _ReclamoPermisos = value
        End Set
    End Property



    Public Sub New()
        _CodCia = String.Empty
        _id = 0
        _Origen = String.Empty
        _Tipo = String.Empty
        _Nro = String.Empty
        _Fecha = DateTime.Now
        _FechaFin = DateTime.Now
        _ListaEmailsCliente = New BindingList(Of ETReclamoPersona)
        _ClientCodigo = String.Empty
        _Cliente = String.Empty
        _EntregaMuestra = False
        _EntregaEvidencia = False
        _UsuarioRegistra = New ETReclamoPersona()
        _UsuarioResponsable = New ETReclamoPersona()
        _EjecutivoVentas = New ETReclamoPersona()
        _JefeResponsable = New ETReclamoPersona()
        _UsuariosCopiaOculta = New List(Of ETReclamoPersona)
        _Estado = "REGISTRADO"
        _ListaMuestras = New BindingList(Of ETReclamoMuestra)
        _ListaMuestrasLab = New BindingList(Of EtReclamoMuestraLab)
        _ListaParticipantes = New BindingList(Of ETReclamoPersona)
        _Organizador = New ETReclamoPersona()
        _ListaPlanes = New BindingList(Of ETReclamoPlanAccion)

        _Producto = New ETReclamoProducto

        _ProductosOpcion = New List(Of ETReclamoProductoOpcion)

        _Servicios = New List(Of ETReclamoServicio)
        _ServicioObservacion = String.Empty

        _AprobacionComercial = New ETReclamoAprobacion
        _AprobacionProduccion = New ETReclamoAprobacion
        _AprobacionGerencia = New ETReclamoAprobacion
        _AprobacionLaboratorio = New ETReclamoAprobacion

        _BitCancelado = False
        _MotivoCancelacion = String.Empty
        _FechaCancelacion = DateTime.Now

        _FechaAnalisis = Nothing
        _PersonaAnalisis = New ETReclamoPersona
        _Causas = New BindingList(Of ETReclamoCausa)

        _LugarReunion = String.Empty
        _FechaReunion = Nothing
        _ListaEvidencias = New List(Of ETReclamoEvidencia)
        _MuestraComentario = String.Empty
        _MuestraFecha = DateTime.Now

        _RequiereAprobLab = False
        _RequiereAprobProd = False
        _RequiereAprobCom = False

        _RequiereAprobNC = False

        _EstadoComentado = String.Empty

        _FormatoComentarios = New BindingList(Of ETReclamoPlanAccion)
        _FormatoPlanes = New BindingList(Of ETReclamoPlanAccion)

        _ReclamoPermisos = New ETReclamoPermisos()

        _NroNCredito = String.Empty
        _Pareto = String.Empty
        _Tpreob = String.Empty
        _RegNotaCredito = False

    End Sub



    Public ReadOnly Property Registrador() As String
        Get
            Return UsuarioRegistra.Nombre
        End Get
    End Property
    Public ReadOnly Property Responsable() As String
        Get
            Return UsuarioResponsable.Nombre
        End Get
    End Property

End Class



Public Class ETReclamoPersona
    'Implements INotifyPropertyChanged

    'Public Event PropertyChanged As PropertyChangedEventHandler _
    '    Implements INotifyPropertyChanged.PropertyChanged

    'Private Sub NotifyPropertyChanged(ByVal info As String)
    '    RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    'End Sub

    Private _Codigo As String
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            'If Not value = _Codigo Then
            '    Me._Codigo = value
            '    NotifyPropertyChanged("Codigo")
            'End If
            _Codigo = value
        End Set
    End Property

    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            'If Not value = _Nombre Then
            '    Me._Nombre = value
            '    NotifyPropertyChanged("Nombre")
            'End If
            _Nombre = value
        End Set
    End Property

    Private _Correo As String
    Public Property Correo() As String
        Get
            Return _Correo
        End Get
        Set(ByVal value As String)
            'If Not value = _Correo Then
            '    Me._Correo = value
            '    NotifyPropertyChanged("Correo")
            'End If
            _Correo = value
        End Set
    End Property

    Private _Area As String
    Public Property Area() As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            'If Not value = _Area Then
            '    Me._Area = value
            '    NotifyPropertyChanged("Area")
            'End If
            _Area = value
        End Set
    End Property

    Public Sub New()
        _Codigo = String.Empty
        _Nombre = String.Empty
        _Correo = String.Empty
        _Area = String.Empty
    End Sub

    Public Sub New(ByVal pCodigo As String, ByVal pNombre As String)
        _Codigo = pCodigo
        _Nombre = pNombre
        _Area = String.Empty
        _Correo = String.Empty
    End Sub

    Public Function GetEmail() As MailAddress
        Try
            Return New MailAddress(_Correo, _Nombre)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class



Public Class ETReclamoProducto

    Private _Motivo As String
    Public Property Motivo() As String
        Get
            Return _Motivo
        End Get
        Set(ByVal value As String)
            _Motivo = value
        End Set
    End Property

    Private _NroGuia As String
    Public Property NroGuia() As String
        Get
            Return _NroGuia
        End Get
        Set(ByVal value As String)
            _NroGuia = value
        End Set
    End Property

    Private _Observacion As String
    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal value As String)
            _Observacion = value
        End Set
    End Property

    Private _ListaDetalles As BindingList(Of ETReclamoProductoDetalle)
    Public Property ListaDetalles() As BindingList(Of ETReclamoProductoDetalle)
        Get
            Return _ListaDetalles
        End Get
        Set(ByVal value As BindingList(Of ETReclamoProductoDetalle))
            _ListaDetalles = value
        End Set
    End Property

    Public Sub New()
        _Motivo = String.Empty
        _NroGuia = String.Empty
        _Observacion = String.Empty
        _ListaDetalles = New BindingList(Of ETReclamoProductoDetalle)
    End Sub

End Class



Public Class ETReclamoProductoDetalle
    Private _NRO_FACT As String
    Public Property NRO_FACT() As String
        Get
            Return _NRO_FACT
        End Get
        Set(ByVal value As String)
            _NRO_FACT = value
        End Set
    End Property

    Private _NRO_GUIA As String
    Public Property NRO_GUIA() As String
        Get
            Return _NRO_GUIA
        End Get
        Set(ByVal value As String)
            _NRO_GUIA = value
        End Set
    End Property

    Private _FECHA As DateTime
    Public Property FECHA() As DateTime
        Get
            Return _FECHA
        End Get
        Set(ByVal value As DateTime)
            _FECHA = value
        End Set
    End Property

    Private _COD_PRODUCTO As String
    Public Property COD_PRODUCTO() As String
        Get
            Return _COD_PRODUCTO
        End Get
        Set(ByVal value As String)
            _COD_PRODUCTO = value
        End Set
    End Property

    Private _PRODUCTO As String
    Public Property PRODUCTO() As String
        Get
            Return _PRODUCTO
        End Get
        Set(ByVal value As String)
            _PRODUCTO = value
        End Set
    End Property

    Private _LOTE As String
    Public Property LOTE() As String
        Get
            Return _LOTE
        End Get
        Set(ByVal value As String)
            _LOTE = value
        End Set
    End Property

    Private _NRO_BOLSAS As String
    Public Property NRO_BOLSAS() As String
        Get
            Return _NRO_BOLSAS
        End Get
        Set(ByVal value As String)
            _NRO_BOLSAS = value
        End Set
    End Property

    Private _UNIDAD As String
    Public Property UNIDAD() As String
        Get
            Return _UNIDAD
        End Get
        Set(ByVal value As String)
            _UNIDAD = value
        End Set
    End Property

    Private _CANT_INGRESADA As Decimal
    Public Property CANT_INGRESADA() As Decimal
        Get
            Return _CANT_INGRESADA
        End Get
        Set(ByVal value As Decimal)
            _CANT_INGRESADA = value
        End Set
    End Property

    Private _CANT_DESPACHADA As Decimal
    Public Property CANT_DESPACHADA() As Decimal
        Get
            Return _CANT_DESPACHADA
        End Get
        Set(ByVal value As Decimal)
            _CANT_DESPACHADA = value
        End Set
    End Property

    Private _CANT_FACTURADA As Decimal
    Public Property CANT_FACTURADA() As Decimal
        Get
            Return _CANT_FACTURADA
        End Get
        Set(ByVal value As Decimal)
            _CANT_FACTURADA = value
        End Set
    End Property


    Private _NRO_BOLSAS_RECLAMADAS As String
    Public Property NRO_BOLSAS_RECLAMADAS() As String
        Get
            Return _NRO_BOLSAS_RECLAMADAS
        End Get
        Set(ByVal value As String)
            _NRO_BOLSAS_RECLAMADAS = value
        End Set
    End Property

    Public Sub New()
        _NRO_FACT = String.Empty
        _NRO_GUIA = String.Empty
        _FECHA = DateTime.Now.Date
        _COD_PRODUCTO = String.Empty
        _PRODUCTO = String.Empty
        _UNIDAD = String.Empty
        _CANT_DESPACHADA = 0
        _CANT_FACTURADA = 0
        _CANT_INGRESADA = 0
        _LOTE = String.Empty
        _NRO_BOLSAS = String.Empty
        _NRO_BOLSAS_RECLAMADAS = String.Empty
    End Sub
End Class


'--------------------------------------------------------
'  SERVICIO OPCION -  240527
'--------------------------------------------------------
Public Class ETReclamoProductoOpcion

    Private _Codigo As String
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Private _Opcion As String
    Public Property Opcion() As String
        Get
            Return _Opcion
        End Get
        Set(ByVal value As String)
            _Opcion = value
        End Set
    End Property

    Private _Observacion As String
    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal value As String)
            _Observacion = value
        End Set
    End Property

    Public Sub New()
        Codigo = String.Empty
        Opcion = String.Empty
        Observacion = String.Empty
    End Sub
End Class



Public Class ETReclamoServicio

    Private _Codigo As String
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Private _Opcion As String
    Public Property Opcion() As String
        Get
            Return _Opcion
        End Get
        Set(ByVal value As String)
            _Opcion = value
        End Set
    End Property

    Private _Observacion As String
    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal value As String)
            _Observacion = value
        End Set
    End Property

    Public Sub New()
        Codigo = String.Empty
        Opcion = String.Empty
        Observacion = String.Empty
    End Sub
End Class




Public Class ETReclamoAprobacion

    Private _Gerente As ETReclamoPersona
    Public Property Gerente() As ETReclamoPersona
        Get
            Return _Gerente
        End Get
        Set(ByVal value As ETReclamoPersona)
            _Gerente = value
        End Set
    End Property

    Private _Observacion As String
    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal value As String)
            _Observacion = value
        End Set
    End Property

    Private _FechaAprobacion As DateTime
    Public Property FechaAprobacion() As DateTime
        Get
            Return _FechaAprobacion
        End Get
        Set(ByVal value As DateTime)
            _FechaAprobacion = value
        End Set
    End Property

    Private _Aprobado As Boolean
    Public Property Aprobado() As Boolean
        Get
            Return _Aprobado
        End Get
        Set(ByVal value As Boolean)
            _Aprobado = value
        End Set
    End Property

    Private _RegNotaCredito As Boolean
    Public Property RegNotaCredito() As Boolean
        Get
            Return _RegNotaCredito
        End Get
        Set(ByVal value As Boolean)
            _RegNotaCredito = value
        End Set
    End Property


    Private _AccionesPorTomar As String
    Public Property AccionesPorTomar() As String
        Get
            Return _AccionesPorTomar
        End Get
        Set(ByVal value As String)
            _AccionesPorTomar = value
        End Set
    End Property


    Public Sub New()
        _Gerente = New ETReclamoPersona()
        _Observacion = String.Empty
        _FechaAprobacion = Nothing
        _Aprobado = False
        _AccionesPorTomar = String.Empty
    End Sub

End Class




Public Class ETReclamoPlanAccion

    Private _Item As Integer
    Public Property Item() As Integer
        Get
            Return _Item
        End Get
        Set(ByVal value As Integer)
            _Item = value
        End Set
    End Property

    Private _ItemCausa As Integer
    Public Property ItemCausa() As Integer
        Get
            Return _ItemCausa
        End Get
        Set(ByVal value As Integer)
            _ItemCausa = value
        End Set
    End Property

    Private _ETEncargado As ETReclamoPersona
    Public Property ETEncargado() As ETReclamoPersona
        Get
            Return _ETEncargado
        End Get
        Set(ByVal value As ETReclamoPersona)
            _ETEncargado = value
        End Set
    End Property

    Public ReadOnly Property EncargadoCodigo() As String
        Get
            Return _ETEncargado.Codigo
        End Get
    End Property

    Public ReadOnly Property Encargado() As String
        Get
            Return _ETEncargado.Nombre
        End Get
    End Property

    Private _Accion As String
    Public Property AccionPorRealizar() As String
        Get
            Return _Accion
        End Get
        Set(ByVal value As String)
            _Accion = value
        End Set
    End Property

    Private _FechaPropuesta As DateTime
    Public Property FechaPropuesta() As DateTime
        Get
            Return _FechaPropuesta
        End Get
        Set(ByVal value As DateTime)
            _FechaPropuesta = value
        End Set
    End Property

    Private _FechaEjecucion As Nullable(Of DateTime)
    Public Property FechaEjecucion() As Nullable(Of DateTime)
        Get
            Return _FechaEjecucion
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            _FechaEjecucion = value
        End Set
    End Property

    Private _Estado As String
    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
        End Set
    End Property

    Private _Notifica As Boolean
    Public Property Notifica() As Boolean
        Get
            Return _Notifica
        End Get
        Set(ByVal value As Boolean)
            _Notifica = value
        End Set
    End Property

    Public Sub New()
        _Item = 0
        _ItemCausa = 0
        _ETEncargado = New ETReclamoPersona
        _Accion = String.Empty
        _FechaPropuesta = DateTime.Now.Date
        _FechaEjecucion = Nothing
        _Estado = "EN CURSO"
        _Notifica = False
    End Sub
End Class




Public Class EtReclamoMuestraLab
    Inherits ETReclamoMuestra

    Private _APROBADO_POR As String
    Public Property APROBADO_POR() As String
        Get
            Return _APROBADO_POR
        End Get
        Set(ByVal value As String)
            _APROBADO_POR = value
        End Set
    End Property

    Private _ARCHIVO As String
    Public Property ARCHIVO() As String
        Get
            Return _ARCHIVO
        End Get
        Set(ByVal value As String)
            _ARCHIVO = value
        End Set
    End Property

    Private _MUESTRA_CONFORME As Boolean
    Public Property MUESTRA_CONFORME() As Boolean
        Get
            Return _MUESTRA_CONFORME
        End Get
        Set(ByVal value As Boolean)
            _MUESTRA_CONFORME = value
        End Set
    End Property

    Private _FECHA_CONFORME As Boolean
    Public Property FECHA_CONFORME() As Boolean
        Get
            Return _FECHA_CONFORME
        End Get
        Set(ByVal value As Boolean)
            _FECHA_CONFORME = value
        End Set
    End Property

    Public Property CONFORMIDAD() As String
        Get
            If _MUESTRA_CONFORME Then
                Return "SI"
            Else
                Return "NO"
            End If            
        End Get
        Set(ByVal value As String)
            If value = "SI" Then
                _MUESTRA_CONFORME = True
            Else
                _MUESTRA_CONFORME = False
            End If
        End Set
    End Property

    Public Property CONFORMIDAD_FECHA() As String
        Get
            If _FECHA_CONFORME Then
                Return "SI"
            Else
                Return "NO"
            End If
        End Get
        Set(ByVal value As String)
            If value = "SI" Then
                _FECHA_CONFORME = True
            Else
                _FECHA_CONFORME = False
            End If
        End Set
    End Property

    Public Sub New(ByVal item As ETReclamoMuestra)
        ID = item.ID
        COD_PRODUCTO = item.COD_PRODUCTO
        PRODUCTO = item.PRODUCTO
        LOTE = item.LOTE
        NROBOLSA = item.NROBOLSA
        NROBOLSARECLAMADAS = item.NROBOLSARECLAMADAS
        FECHA_INICIO = item.FECHA_INICIO
        FECHA_FIN = item.FECHA_FIN
        OBSERVACION = item.OBSERVACION
        ARCHIVOM = item.ARCHIVOM
        ESTADO = item.ESTADO
        ESTADO_OBS = item.ESTADO_OBS
        _APROBADO_POR = String.Empty        
        _ARCHIVO = String.Empty
        _MUESTRA_CONFORME = False
        _FECHA_CONFORME = False
    End Sub
    Public Sub New()
        MyBase.New()
        APROBADO_POR = ""
        ARCHIVO = ""
        _FECHA_CONFORME = False
        _MUESTRA_CONFORME = False
    End Sub
End Class




Public Class ETReclamoMuestra

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _COD_PRODUCTO As String
    Public Property COD_PRODUCTO() As String
        Get
            Return _COD_PRODUCTO
        End Get
        Set(ByVal value As String)
            _COD_PRODUCTO = value
        End Set
    End Property

    Private _PRODUCTO As String
    Public Property PRODUCTO() As String
        Get
            Return _PRODUCTO
        End Get
        Set(ByVal value As String)
            _PRODUCTO = value
        End Set
    End Property

    Private _LOTE As String
    Public Property LOTE() As String
        Get
            Return _LOTE
        End Get
        Set(ByVal value As String)
            _LOTE = value
        End Set
    End Property

    Private _NROBOLSA As String
    Public Property NROBOLSA() As String
        Get
            Return _NROBOLSA
        End Get
        Set(ByVal value As String)
            _NROBOLSA = value
        End Set
    End Property

    Private _NROBOLSARECLAMADAS As String
    Public Property NROBOLSARECLAMADAS() As String
        Get
            Return _NROBOLSARECLAMADAS
        End Get
        Set(ByVal value As String)
            _NROBOLSARECLAMADAS = value
        End Set
    End Property

    Private _FECHA_INICIO As DateTime
    Public Property FECHA_INICIO() As DateTime
        Get
            Return _FECHA_INICIO
        End Get
        Set(ByVal value As DateTime)
            _FECHA_INICIO = value
        End Set
    End Property

    Private _FECHA_FIN As Nullable(Of DateTime)
    Public Property FECHA_FIN() As Nullable(Of DateTime)
        Get
            Return _FECHA_FIN
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            _FECHA_FIN = value
        End Set
    End Property

    Private _OBSERVACION As String
    Public Property OBSERVACION() As String
        Get
            Return _OBSERVACION
        End Get
        Set(ByVal value As String)
            _OBSERVACION = value
        End Set
    End Property

    Private _ESTADO As String
    Public Property ESTADO() As String
        Get
            Return _ESTADO
        End Get
        Set(ByVal value As String)
            _ESTADO = value
        End Set
    End Property

    Private _ESTADO_OBS As String
    Public Property ESTADO_OBS() As String
        Get
            Return _ESTADO_OBS
        End Get
        Set(ByVal value As String)
            _ESTADO_OBS = value
        End Set
    End Property

    Private _ARCHIVOM As String
    Public Property ARCHIVOM() As String
        Get
            Return _ARCHIVOM
        End Get
        Set(ByVal value As String)
            _ARCHIVOM = value
        End Set
    End Property

    Private _RESPONSABLE As String
    Public Property RESPONSABLE() As String
        Get
            Return _RESPONSABLE
        End Get
        Set(ByVal value As String)
            _RESPONSABLE = value
        End Set
    End Property

    Public Sub New()
        _ID = 0
        _PRODUCTO = ""
        _LOTE = ""
        _NROBOLSA = ""
        _NROBOLSARECLAMADAS = ""
        _FECHA_INICIO = DateTime.Now
        _FECHA_FIN = Nothing
        _OBSERVACION = ""
        _ARCHIVOM = String.Empty
        _RESPONSABLE = String.Empty
        _ESTADO = "EN CURSO"
        _ESTADO_OBS = ""
        _COD_PRODUCTO = String.Empty
    End Sub

End Class




Public Class ETReclamoCausa

    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property

    Private _Item As Integer
    Public Property Item() As Integer
        Get
            Return _Item
        End Get
        Set(ByVal value As Integer)
            _Item = value
        End Set
    End Property

    Private _CausaOrigen As String
    Public Property CausaOrigen() As String
        Get
            Return _CausaOrigen
        End Get
        Set(ByVal value As String)
            _CausaOrigen = value
        End Set
    End Property

    Private _Registrador As ETReclamoPersona
    Public Property Registrador() As ETReclamoPersona
        Get
            Return _Registrador
        End Get
        Set(ByVal value As ETReclamoPersona)
            _Registrador = value
        End Set
    End Property

    Public ReadOnly Property RegistradoPor() As String
        Get
            Return _Registrador.Nombre
        End Get
    End Property

    Private _Detalles As List(Of ETReclamoCausaDetalle)
    Public Property Detalles() As List(Of ETReclamoCausaDetalle)
        Get
            Return _Detalles
        End Get
        Set(ByVal value As List(Of ETReclamoCausaDetalle))
            _Detalles = value
        End Set
    End Property

    Public Sub New()
        _Id = 0
        _Item = 1
        _CausaOrigen = String.Empty
        _Registrador = New ETReclamoPersona
        _Detalles = New List(Of ETReclamoCausaDetalle)
    End Sub

End Class



Public Class ETReclamoCausaDetalle


    Private _IdCausa As Integer
    Public Property IdCausa() As Integer
        Get
            Return _IdCausa
        End Get
        Set(ByVal value As Integer)
            _IdCausa = value
        End Set
    End Property


    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property

    Private _Item As Integer
    Public Property Item() As Integer
        Get
            Return _Item
        End Get
        Set(ByVal value As Integer)
            _Item = value
        End Set
    End Property

    Private _Descripcion As String
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property
    Public Sub New()
        _Id = 0
        _IdCausa = 0
        _Item = 1
        _Descripcion = String.Empty
    End Sub
End Class



Public Class ETReclamoEvidencia

    Private _Fecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal value As DateTime)
            _Fecha = value
        End Set
    End Property

    Private _Comentario As String
    Public Property Comentario() As String
        Get
            Return _Comentario
        End Get
        Set(ByVal value As String)
            _Comentario = value
        End Set
    End Property

    Private _Archivo As String
    Public Property Archivo() As String
        Get
            Return _Archivo
        End Get
        Set(ByVal value As String)
            _Archivo = value
        End Set
    End Property
    Public Sub New()
        _Fecha = DateTime.Now
        _Comentario = String.Empty
        _Archivo = String.Empty
    End Sub


End Class




Public Class ETReclamoPermisos

    Private _Producto As Boolean
    Public Property Producto() As Boolean
        Get
            Return _Producto
        End Get
        Set(ByVal value As Boolean)
            _Producto = value
        End Set
    End Property

    Private _Servicio As Boolean
    Public Property Servicio() As Boolean
        Get
            Return _Servicio
        End Get
        Set(ByVal value As Boolean)
            _Servicio = value
        End Set
    End Property

    Private _Muestra As Boolean
    Public Property Muestra() As Boolean
        Get
            Return _Muestra
        End Get
        Set(ByVal value As Boolean)
            _Muestra = value
        End Set
    End Property

    Private _FechaMuestra As DateTime
    Public Property FechaMuestra() As DateTime
        Get
            Return _FechaMuestra
        End Get
        Set(ByVal value As DateTime)
            _FechaMuestra = value
        End Set
    End Property

    Private _Evidencia As Boolean
    Public Property Evidencia() As Boolean
        Get
            Return _Evidencia
        End Get
        Set(ByVal value As Boolean)
            _Evidencia = value
        End Set
    End Property

    Private _FechaEvidencia As DateTime
    Public Property FechaEvidencia() As DateTime
        Get
            Return _FechaEvidencia
        End Get
        Set(ByVal value As DateTime)
            _FechaEvidencia = value
        End Set
    End Property

    Private _ConformidadLab As Boolean
    Public Property ConformidadLab() As Boolean
        Get
            Return _ConformidadLab
        End Get
        Set(ByVal value As Boolean)
            _ConformidadLab = value
        End Set
    End Property

    Private _InformeLab As Boolean
    Public Property InformeLab() As Boolean
        Get
            Return _InformeLab
        End Get
        Set(ByVal value As Boolean)
            _InformeLab = value
        End Set
    End Property

    Private _AprobProduccion As Boolean
    Public Property AprobProduccion() As Boolean
        Get
            Return _AprobProduccion
        End Get
        Set(ByVal value As Boolean)
            _AprobProduccion = value
        End Set
    End Property

    Private _AprobLaboratorio As Boolean
    Public Property AprobLaboratorio() As Boolean
        Get
            Return _AprobLaboratorio
        End Get
        Set(ByVal value As Boolean)
            _AprobLaboratorio = value
        End Set
    End Property

    Private _AprobacionComercial As Boolean
    Public Property AprobacionComercial() As Boolean
        Get
            Return _AprobacionComercial
        End Get
        Set(ByVal value As Boolean)
            _AprobacionComercial = value
        End Set
    End Property

    Private _Reunion As Boolean
    Public Property Reunion() As Boolean
        Get
            Return _Reunion
        End Get
        Set(ByVal value As Boolean)
            _Reunion = value
        End Set
    End Property

    Private _AnalisisProblema As Boolean
    Public Property AnalisisProblema() As Boolean
        Get
            Return _AnalisisProblema
        End Get
        Set(ByVal value As Boolean)
            _AnalisisProblema = value
        End Set
    End Property

    Private _PlanesAccion As Boolean
    Public Property PlanesAccion() As Boolean
        Get
            Return _PlanesAccion
        End Get
        Set(ByVal value As Boolean)
            _PlanesAccion = value
        End Set
    End Property

    Private _AprobacionGerencial As Boolean
    Public Property AprobacionGerencial() As Boolean
        Get
            Return _AprobacionGerencial
        End Get
        Set(ByVal value As Boolean)
            _AprobacionGerencial = value
        End Set
    End Property

    Private _Seguimiento As Boolean
    Public Property Seguimiento() As Boolean
        Get
            Return _Seguimiento
        End Get
        Set(ByVal value As Boolean)
            _Seguimiento = value
        End Set
    End Property

    Sub New()
        _Producto = False
        _Servicio = False
        _Reunion = False
        _Evidencia = False
        _Muestra = False
        _AnalisisProblema = False
        _PlanesAccion = False
        _AprobLaboratorio = False
        _AprobProduccion = False        
        _AprobacionGerencial = False
        _AprobacionComercial = False
        _Seguimiento = False
    End Sub

End Class




Public Class ETReclamoFormato

    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _comentarios As String
    Public Property comentarios() As String
        Get
            Return _comentarios
        End Get
        Set(ByVal value As String)
            _comentarios = value
        End Set
    End Property

    Private _user As String
    Public Property user() As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property

    Private _fecha As Nullable(Of DateTime)
    Public Property fecha() As Nullable(Of DateTime)
        Get
            Return _fecha
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            _fecha = value
        End Set
    End Property
    Sub New()        
        _id = 0
        _user = ""
        _comentarios = ""
        _fecha = Nothing
        _ListaComentarios = New List(Of ETReclamoFormatoComentarios)
        _ListaPlanes = New List(Of ETReclamoFormatoPlan)
    End Sub


    Private _ListaComentarios As List(Of ETReclamoFormatoComentarios)
    Public Property ListaComentarios() As List(Of ETReclamoFormatoComentarios)
        Get
            Return _ListaComentarios
        End Get
        Set(ByVal value As List(Of ETReclamoFormatoComentarios))
            _ListaComentarios = value
        End Set
    End Property


    Private _ListaPlanes As List(Of ETReclamoFormatoPlan)
    Public Property ListaPlanes() As List(Of ETReclamoFormatoPlan)
        Get
            Return _ListaPlanes
        End Get
        Set(ByVal value As List(Of ETReclamoFormatoPlan))
            _ListaPlanes = value
        End Set
    End Property

End Class


Public Class ETReclamoFormatoComentarios

    Private _iddet As Integer
    Public Property iddet() As Integer
        Get
            Return _iddet
        End Get
        Set(ByVal value As Integer)
            _iddet = value
        End Set
    End Property

    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _user As String
    Public Property user() As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property

    Private _comentarios As String
    Public Property comentarios() As String
        Get
            Return _comentarios
        End Get
        Set(ByVal value As String)
            _comentarios = value
        End Set
    End Property

    Private _estado As String
    Public Property estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property
    Sub New()
        _iddet = 0
        _id = 0
        _user = ""
        _comentarios = ""
        _estado = ""
    End Sub
End Class



Public Class ETReclamoFormatoPlan

    Private _iddet As Integer
    Public Property iddet() As Integer
        Get
            Return _iddet
        End Get
        Set(ByVal value As Integer)
            _iddet = value
        End Set
    End Property

    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _user As String
    Public Property user() As String
        Get
            Return _user
        End Get
        Set(ByVal value As String)
            _user = value
        End Set
    End Property

    Private _acciones As String
    Public Property acciones() As String
        Get
            Return _acciones
        End Get
        Set(ByVal value As String)
            _acciones = value
        End Set
    End Property

    Sub New()
        _iddet = 0
        _id = 0
        _user = ""
        _acciones = ""
    End Sub

End Class