Public Class ETPedido

    Private _Codigo_Producto As String
    Private _Descripcion_Producto As String
    Private _Unidad As String
    Private _Cantidad_Solicitada As Decimal
    Private _Cantidad_Autorizada As Decimal
    Private _Cantidad_Atendida As Decimal
    Private _Cantidad_Requerida As Decimal
    Private _Cod_Activo As String
    Private _Ruta_CondTecnicas As String
    Private _Ruta_Imagenes As String
    Private _SalidaOrden As String
    Private _Requerimiento As String
    Private _Aplicacion As String
    Private _Codigo_Aplicacion As String
    Private _Colaborador As String
    Private _UMCompra As String
    Private _Item As Integer
    Private _Cod_Cia As String
    Private _Tipo_Mov As String
    Private _Tipo_Doc As String
    Private _Codigo_Area As String
    Private _Serie As String
    Private _Secuencia As String
    Private _Numero_Doc As String
    Private _Codigo_Almacen As String
    Private _Estado As String
    Private _Importancia As String
    Private _Observaciones As String
    Private _Codigo_Empleo As String
    Private _Codigo_Cantera As String
    Private _Codigo_Proveedor As String
    Private _Razon_Social As String
    Private _Doc_Ori As String
    Private _Tipo_DocOri As String
    Private _Urgente As String
    Private _Fecha As DateTime
    Private _User As String
    Private _User_Recibe As String
    Private _NumeroMovimiento As String
    Private _Sistema As String
    Private _Mes As Integer
    Private _Cod_OrdenTrabajo As String = String.Empty
    Private _OrdenTrabajo As Long = 0
    Private _Fecha1 As Date = Date.Today
    Private _Fecha2 As Date = Date.Today


    Public Property Mes() As Integer
        Get
            Return _Mes
        End Get
        Set(ByVal value As Integer)
            _Mes = value
        End Set
    End Property

    Public Property Sistema() As String
        Get
            Return _Sistema
        End Get
        Set(ByVal value As String)
            _Sistema = value
        End Set
    End Property

    Public Property NumeroMovimiento() As String
        Get
            Return _NumeroMovimiento
        End Get
        Set(ByVal value As String)
            _NumeroMovimiento = value
        End Set
    End Property


    Public Property User_Recibe() As String
        Get
            Return _User_Recibe
        End Get
        Set(ByVal value As String)
            _User_Recibe = value
        End Set
    End Property

    Public Property User() As String
        Get
            Return _User
        End Get
        Set(ByVal value As String)
            _User = value
        End Set
    End Property

    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal value As DateTime)
            _Fecha = value
        End Set
    End Property

    Public Property Codigo_Producto() As String
        Get
            Return _Codigo_Producto
        End Get
        Set(ByVal value As String)
            _Codigo_Producto = value
        End Set
    End Property

    Public Property Descripcion_Producto() As String
        Get
            Return _Descripcion_Producto
        End Get
        Set(ByVal value As String)
            _Descripcion_Producto = value
        End Set
    End Property

    Public Property Unidad() As String
        Get
            Return _Unidad
        End Get
        Set(ByVal value As String)
            _Unidad = value
        End Set
    End Property

    Public Property Cantidad_Solicitada() As Decimal
        Get
            Return _Cantidad_Solicitada
        End Get
        Set(ByVal value As Decimal)
            _Cantidad_Solicitada = value
        End Set
    End Property

    Public Property Cantidad_Autorizada() As Decimal
        Get
            Return _Cantidad_Autorizada
        End Get
        Set(ByVal value As Decimal)
            _Cantidad_Autorizada = value
        End Set
    End Property

    Public Property Cantidad_Atendida() As Decimal
        Get
            Return _Cantidad_Atendida
        End Get
        Set(ByVal value As Decimal)
            _Cantidad_Atendida = value
        End Set
    End Property

    Public Property Cantidad_Requerida() As Decimal
        Get
            Return _Cantidad_Requerida
        End Get
        Set(ByVal value As Decimal)
            _Cantidad_Requerida = value
        End Set
    End Property

    Public Property Cod_Activo() As String
        Get
            Return _Cod_Activo
        End Get
        Set(ByVal value As String)
            _Cod_Activo = value
        End Set
    End Property

    Public Property Ruta_CondTecnicas() As String
        Get
            Return _Ruta_CondTecnicas
        End Get
        Set(ByVal value As String)
            _Ruta_CondTecnicas = value
        End Set
    End Property

    Public Property Ruta_Imagenes() As String
        Get
            Return _Ruta_Imagenes
        End Get
        Set(ByVal value As String)
            _Ruta_Imagenes = value
        End Set
    End Property

    Public Property SalidaOrden() As String
        Get
            Return _SalidaOrden
        End Get
        Set(ByVal value As String)
            _SalidaOrden = value
        End Set
    End Property

    Public Property Requerimiento() As String
        Get
            Return _Requerimiento
        End Get
        Set(ByVal value As String)
            _Requerimiento = value
        End Set
    End Property

    Public Property Aplicacion() As String
        Get
            Return _Aplicacion
        End Get
        Set(ByVal value As String)
            _Aplicacion = value
        End Set
    End Property

    Public Property Codigo_Aplicacion() As String
        Get
            Return _Codigo_Aplicacion
        End Get
        Set(ByVal value As String)
            _Codigo_Aplicacion = value
        End Set
    End Property

    Public Property Colaborador() As String
        Get
            Return _Colaborador
        End Get
        Set(ByVal value As String)
            _Colaborador = value
        End Set
    End Property

    Public Property UMCompra() As String
        Get
            Return _UMCompra
        End Get
        Set(ByVal value As String)
            _UMCompra = value
        End Set
    End Property

    Public Property Item() As Integer
        Get
            Return _Item
        End Get
        Set(ByVal value As Integer)
            _Item = value
        End Set
    End Property


    Public Property Cod_Cia() As String
        Get
            Return _Cod_Cia
        End Get
        Set(ByVal value As String)
            _Cod_Cia = value
        End Set
    End Property

    Public Property Tipo_Mov() As String
        Get
            Return _Tipo_Mov
        End Get
        Set(ByVal value As String)
            _Tipo_Mov = value
        End Set
    End Property

    Public Property Tipo_Doc() As String
        Get
            Return _Tipo_Doc
        End Get
        Set(ByVal value As String)
            _Tipo_Doc = value
        End Set
    End Property

    Public Property Codigo_Area() As String
        Get
            Return _Codigo_Area
        End Get
        Set(ByVal value As String)
            _Codigo_Area = value
        End Set
    End Property

    Public Property Serie() As String
        Get
            Return _Serie
        End Get
        Set(ByVal value As String)
            _Serie = value
        End Set
    End Property

    Public Property Secuencia() As String
        Get
            Return _Secuencia
        End Get
        Set(ByVal value As String)
            _Secuencia = value
        End Set
    End Property

    Public Property Numero_Doc() As String
        Get
            Return _Numero_Doc
        End Get
        Set(ByVal value As String)
            _Numero_Doc = value
        End Set
    End Property

    Public Property Codigo_Almacen() As String
        Get
            Return _Codigo_Almacen
        End Get
        Set(ByVal value As String)
            _Codigo_Almacen = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
        End Set
    End Property

    Public Property Importancia() As String
        Get
            Return _Importancia
        End Get
        Set(ByVal value As String)
            _Importancia = value
        End Set
    End Property

    Public Property Observaciones() As String
        Get
            Return _Observaciones
        End Get
        Set(ByVal value As String)
            _Observaciones = value
        End Set
    End Property

    Public Property Codigo_Empleo() As String
        Get
            Return _Codigo_Empleo
        End Get
        Set(ByVal value As String)
            _Codigo_Empleo = value
        End Set
    End Property

    Public Property Codigo_Cantera() As String
        Get
            Return _Codigo_Cantera
        End Get
        Set(ByVal value As String)
            _Codigo_Cantera = value
        End Set
    End Property

    Public Property Codigo_Proveedor() As String
        Get
            Return _Codigo_Proveedor
        End Get
        Set(ByVal value As String)
            _Codigo_Proveedor = value
        End Set
    End Property

    Public Property Razon_Social() As String
        Get
            Return _Razon_Social
        End Get
        Set(ByVal value As String)
            _Razon_Social = value
        End Set
    End Property

    Public Property Doc_Ori() As String
        Get
            Return _Doc_Ori
        End Get
        Set(ByVal value As String)
            _Doc_Ori = value
        End Set
    End Property

    Public Property Tipo_DocOri() As String
        Get
            Return _Tipo_DocOri
        End Get
        Set(ByVal value As String)
            _Tipo_DocOri = value
        End Set
    End Property

    Public Property Urgente() As String
        Get
            Return _Urgente
        End Get
        Set(ByVal value As String)
            _Urgente = value
        End Set
    End Property
   

    Public Property Cod_OrdenTrabajo() As String
        Get
            Return _Cod_OrdenTrabajo
        End Get
        Set(ByVal value As String)
            _Cod_OrdenTrabajo = value
        End Set
    End Property

    Public Property OrdenTrabajo() As Long
        Get
            Return _OrdenTrabajo
        End Get
        Set(ByVal value As Long)
            _OrdenTrabajo = value
        End Set
    End Property

    Public Property Fecha1() As Date
        Get
            Return _Fecha1
        End Get
        Set(ByVal value As Date)
            _Fecha1 = value
        End Set
    End Property

    Public Property Fecha2() As Date
        Get
            Return _Fecha2
        End Get
        Set(ByVal value As Date)
            _Fecha2 = value
        End Set
    End Property
End Class
