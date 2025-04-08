Public Class ETRequerimiento_Mantto
    Inherits ETObjecto
    Private _Area As String = String.Empty
    Private _Codigo As String = String.Empty
    Private _Solicitante As String = String.Empty
    Private _Dirigido As String = String.Empty
    Private _Asunto As String = String.Empty
    Private _Estado As String = String.Empty
    Private _CodArea As String = String.Empty
    Private _SolicitanteID As String = String.Empty
    Private _DirigidoID As String = String.Empty
    Private _Status As String = String.Empty
    Private _Requerimiento As Long = 0

    Public Property Area() As String
        Get
            Return _Area
        End Get
        Set(ByVal value As String)
            _Area = value
        End Set
    End Property
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property
    Public Property Solicitante() As String
        Get
            Return _Solicitante
        End Get
        Set(ByVal value As String)
            _Solicitante = value
        End Set
    End Property
    Public Property Dirigido() As String
        Get
            Return _Dirigido
        End Get
        Set(ByVal value As String)
            _Dirigido = value
        End Set
    End Property
    Public Property Asunto() As String
        Get
            Return _Asunto
        End Get
        Set(ByVal value As String)
            _Asunto = value
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
    Public Property CodArea() As String
        Get
            Return _CodArea
        End Get
        Set(ByVal value As String)
            _CodArea = value
        End Set
    End Property
    Public Property SolicitanteID() As String
        Get
            Return _SolicitanteID
        End Get
        Set(ByVal value As String)
            _SolicitanteID = value
        End Set
    End Property
    Public Property DirigidoID() As String
        Get
            Return _DirigidoID
        End Get
        Set(ByVal value As String)
            _DirigidoID = value
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
    Public Property Requerimiento() As Long
        Get
            Return _Requerimiento
        End Get
        Set(ByVal value As Long)
            _Requerimiento = value
        End Set
    End Property
End Class
