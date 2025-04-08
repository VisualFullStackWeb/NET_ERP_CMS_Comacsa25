Public Class ETLineaNegocio
    Inherits ETObjecto
    Private _Action As Boolean = Boolean.FalseString
    Private _Cod_Cia As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Porcentaje As Double = 0
    Private _Status As String = String.Empty
    Private _Estado As String = String.Empty
    Private _CodLinNeg As String = String.Empty
    Private _LinNeg As Long = 0
    Private _Orden As Integer = 0
#Region "Mantenimiento"
    ' **************************************************
    ' Sistema       :   Mantenimiento
    ' Creador       :   LFSA
    ' Fecha         :   19/04/2011
    ' Descripción   :   Contiene Entidades las Lineas 
    '                   de Negocio de los Equipos
#End Region

#Region "Produccion"
    ' **************************************************
    ' Sistema       :   Mantenimiento
    ' Creador       :   LFSA
    ' Fecha         :   19/04/2011
    ' Descripción   :   Contiene Entidades las Lineas 
    '                   de Producción
#End Region

#Region "Propiedades"
    Public Property Action() As Boolean
        Get
            Return _Action
        End Get
        Set(ByVal value As Boolean)
            _Action = value
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
    Public Property Codigo() As String
        Get
            Return _CodLinNeg
        End Get
        Set(ByVal value As String)
            _CodLinNeg = value
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
    Public Overloads Property Porcentaje() As Double
        Get
            Return _Porcentaje
        End Get
        Set(ByVal value As Double)
            _Porcentaje = value
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
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Public Property IDCatalogo() As Long
        Get
            Return _LinNeg
        End Get
        Set(ByVal value As Long)
            _LinNeg = value
        End Set
    End Property
    Public Property Orden() As Integer
        Get
            Return _Orden
        End Get
        Set(ByVal value As Integer)
            _Orden = value
        End Set
    End Property
#End Region

End Class
