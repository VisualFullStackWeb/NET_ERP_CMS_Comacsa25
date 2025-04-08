Public Class ETMineral

    Inherits ETObjecto

    Private _CodMineral As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _Origen As String = String.Empty
    Private _Estado As String = String.Empty
    Private _Valor As Byte = Byte.MinValue
    Private _Cantera As String = String.Empty
    Private _DesCantera As String = String.Empty
    Private _Contratista As String = String.Empty
    Private _Cantidad As Decimal = Decimal.Zero

    Public Property CodMineral() As String
        Get
            Return _CodMineral
        End Get
        Set(ByVal value As String)
            _CodMineral = value
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

    Public Property Origen() As String
        Get
            Return _Origen
        End Get
        Set(ByVal value As String)
            _Origen = value
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

    Public Property Valor() As Byte
        Get
            Return _Valor
        End Get
        Set(ByVal value As Byte)
            _Valor = value
        End Set
    End Property

    Public Overloads Property Cantidad() As Decimal
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Decimal)
            _Cantidad = value
        End Set
    End Property

    Public Property Cantera() As String
        Get
            Return _Cantera
        End Get
        Set(ByVal value As String)
            _Cantera = value
        End Set
    End Property

    Public Property DesCantera() As String
        Get
            Return _DesCantera
        End Get
        Set(ByVal value As String)
            _DesCantera = value
        End Set
    End Property

    Public Property Contratista() As String
        Get
            Return _Contratista
        End Get
        Set(ByVal value As String)
            _Contratista = value
        End Set
    End Property

End Class
