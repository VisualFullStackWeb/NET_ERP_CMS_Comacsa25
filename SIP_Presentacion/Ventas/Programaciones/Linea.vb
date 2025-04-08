Public Class Linea
#Region "Atributos, propiedades o como quieras llamarlos"
    'atributos de la clase
    Private iniX As Integer
    Private iniY As Integer
    Private finX As Integer
    Private finY As Integer

    'lapiz del pincel
    Private myPen As Pen


    'Recordemos que para dibujar cualquier grafico, necesitamos un objeto Graphics, un objeto Pen(pincel), un método de dibujo, y las coordenadas g.DrawLine(myPen,12,26,15,65)


    'propiedad pincel
    'Este es una novedad del .Net Framework
    'tu declaras los atributos, y despues su propiedad
    Public Property Pincel() As Pen
        Get
            Return myPen
        End Get
        Set(ByVal Value As Pen)
            myPen = Value
        End Set
    End Property

    'su prpopiedad color
    Public Property Color() As Color
        Get
            Return myPen.Color
        End Get
        Set(ByVal Value As Color)
            myPen.Color = Value
        End Set
    End Property

    'la propiedad ancho
    Public Property Ancho() As Integer
        Get
            Return myPen.Width
        End Get
        Set(ByVal Value As Integer)
            myPen.Width = Value
        End Set
    End Property

    'propiedades medias locas, recien estoy aprendiedo 
    ' a usar
    Public Property pIniX() As Integer
        Get
            Return iniX
        End Get
        Set(ByVal Value As Integer)
            iniX = Value
        End Set
    End Property

    Public Property pIniY() As Integer
        Get
            Return iniY
        End Get
        Set(ByVal Value As Integer)
            iniY = Value
        End Set
    End Property

    Public Property pFinX() As Integer
        Get
            Return finX
        End Get
        Set(ByVal Value As Integer)
            finX = Value
        End Set
    End Property

    Public Property pFinY() As Integer
        Get
            Return finY
        End Get
        Set(ByVal Value As Integer)
            finY = Value
        End Set
    End Property
#End Region


    'constructor
    Public Sub New(ByVal iX As Integer, ByVal iY As Integer, ByVal fX As Integer, ByVal fY As Integer)
        iniX = iX
        iniY = iY
        finX = fX
        finY = fY

        'estableciendo el lapiz por defecto
        myPen = New Pen(Color.Red, 4)
    End Sub

    'ahora si metodos principales de la clase
    Public Sub Move(ByVal str As String)
        Select Case str
            Case "U"   'mover arriba
                iniY -= 2
                finY -= 2
            Case "D"   'mover abajo
                iniY += 2
                finY += 2
            Case "R"   'mover derecha
                iniX += 2
                finX += 2
            Case "L"   'mover izquierda
                iniX -= 2
                finX -= 2
        End Select
    End Sub
End Class
