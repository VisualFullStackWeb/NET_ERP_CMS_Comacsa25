Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports System.Text
Imports Infragistics.Win.UltraWinStatusBar
'Imports Infragistics.Win.UltraWinStatusBar.UltraStatusPanel
#Region " ScrollingMarqueeLabelDrawFilter "
'
' Normally an element's appearance can be easily controlled by setting various properties on Appearance 
' objects exposed by Presentation Layer Framework (PLF) based controls.  However, occasionally a requirement 
' comes along that isn't supported by the control. This is where a draw filter is invaluable. 
' 
' All controls that are based on the PLF expose a very flexible, fine-grained drawing extensibility mechanism. 
' To customize the drawing of one or more UIElements of a control you need to implement the 
' IUIElementDrawFilter interface on an object and set the DrawFilter property of the control to that 
' object at runtime.
' 
' This Draw Filter turns an UltraLabel into a scrolling marquee.  It does not modify the Text property of the
' UltraLabel, so you can reliably use the label's Text property when using this filter.  
'
Public Class DrawFilterStatus
    Implements IUIElementDrawFilter

#Region " Data "

    Private UStatus As UltraStatusBar
    Private i16Item As Int16
    Private label As UltraLabel
    Private doScrollLeft As Boolean
    Private txt As StringBuilder
    Private timer As New Timer()
    Private hasScrolled As Boolean = False

    ' Data
#End Region

#Region " IUIElementDrawFilter Members "

#Region " GetPhasesToFilter "
    '
    ' This method is passed a UIElementDrawParams structure and returns a bit-flag enumeration called DrawPhase. 
    ' The passed in structure exposes a property that returns the element to be rendered as well as properties 
    ' and methods to support rendering operations like Graphics, BackBrush, DrawBorders etc. The returned 
    ' DrawPhase bit-flags specify which phase(s) of the drawing operation to filter for this element 
    ' (the DrawElement method below will be called for each bit returned). 
    ' The DrawPhase enumeration allows you to filter the drawing before or after each drawing operation of 
    ' an element (e.g. theme, backcolor, image background, borders, foreground, image and/or child elements). 
    '
    Public Function GetPhasesToFilter(ByRef drawParams As UIElementDrawParams) As Infragistics.Win.DrawPhase Implements IUIElementDrawFilter.GetPhasesToFilter
        ' Indicates that we want this filter's DrawElement method to be invoked prior to when the
        ' foreground (text) of the control is drawn.
        If TypeOf drawParams.Element Is TextUIElementBase Then
            Return DrawPhase.BeforeDrawForeground
        End If
        Return DrawPhase.None
    End Function
    ' GetPhasesToFilter
#End Region

#Region " DrawElement "
    '
    ' This method is passed the same UIElementDrawParams structure as GetPhasesToFilter() and a bit flag indicating 
    ' which single draw phase is being performed. The method returns a boolean. If false is returned then the default 
    ' drawing for that phase will be performed. If true is returned for a 'Before' phase then the default drawing  
    ' for that phase will be skipped. Note: returning true for the BeforeDrawElement phase will cause all the other  
    ' phases to be skipped (even if bits for those phases were returned by the call to GetPhasesToFilter).  
    ' Also, if themes are active, returning true for the BeforeDrawTheme phase will skip all phases up to but not  
    ' including the BeforeDrawChildElements phase. The BeforeDrawFocus phase is only called if the control has focus  
    ' (or the forceDrawAsFocused parameter was set to true on the call to the Draw method) and the element's virtual 
    ' DrawsFocusRect property returns true.
    '
    Public Function DrawElement(ByVal drawPhase As Infragistics.Win.DrawPhase, ByRef drawParams As UIElementDrawParams) As Boolean Implements IUIElementDrawFilter.DrawElement
        ' We only want to draw the text once for each tick of the timer.

        ' The TextHAlign set on the label must be honored, so we setup a StringFormat
        ' to use when drawing the text.
        Dim align As HAlign = drawParams.AppearanceData.TextHAlign
        Dim frmt As New StringFormat()
        If align = HAlign.Left Then
            frmt.Alignment = StringAlignment.Near
        Else
            If align = HAlign.Center Then
                frmt.Alignment = StringAlignment.Center
            Else
                If align = HAlign.Right Then
                    frmt.Alignment = StringAlignment.Far
                End If
            End If
        End If

        ' Draw the text.
        Dim rectF As New RectangleF(drawParams.Element.RectInsideBorders.Left, drawParams.Element.RectInsideBorders.Top, drawParams.Element.RectInsideBorders.Width, drawParams.Element.RectInsideBorders.Height)
        drawParams.Graphics.DrawString(Me.txt.ToString(), drawParams.Font, drawParams.TextBrush, rectF, frmt)

        If Not Me.hasScrolled Then
            ' Rearrange the characters in our private copy of the label's Text so that the next
            ' time we draw the string it will be "scrolled" by one character.
            Me.UpdateText()

            ' Since we only want to scroll the text once per tick of the timer,
            ' set this flag now to prevent this block of code from executing until the next tick.
            Me.hasScrolled = True
        End If

        ' Returning true prevents the text we just drew from being drawn over.
        Return True
    End Function
    ' DrawElement
#End Region

    ' IUIElementDrawFilter Members
#End Region

#Region " Public Interface "

#Region " Constructors "

    Public Sub New(ByVal Status As UltraStatusBar, ByVal Item As Int16)
        Me.UStatus = Status
        Me.i16Item = Item
        AddHandler Me.UStatus.TextChanged, AddressOf Status_TextChanged
        Me.txt = New StringBuilder(Status.Panels(i16Item).Text)
        Me.timer.Interval = 250
        AddHandler Me.timer.Tick, AddressOf timer_Tick
        Me.ScrollLeft = True
    End Sub


    Public Sub New(ByVal label As UltraLabel)
        Me.label = label
        AddHandler Me.label.TextChanged, AddressOf label_TextChanged
        Me.txt = New StringBuilder(label.Text)
        Me.timer.Interval = 250
        AddHandler Me.timer.Tick, AddressOf timer_Tick
        Me.ScrollLeft = True
    End Sub

    Public Sub New(ByVal label As UltraLabel, ByVal scrollLeft As Boolean)
        MyClass.New(label)
        Me.ScrollLeft = scrollLeft
    End Sub

    Public Sub New(ByVal label As UltraLabel, ByVal scrollLeft As Boolean, ByVal pauseTime As Integer)
        MyClass.New(label, scrollLeft)
        timer.Interval = pauseTime
    End Sub

    ' Constructors
#End Region

#Region " PauseTime "
    '
    ' Gets and sets the number of milliseconds that elapse between every time the text scrolls.
    '
    Public Property PauseTime() As Integer
        Get
            Return Me.timer.Interval
        End Get
        Set(ByVal Value As Integer)
            If Value > 0 Then
                Me.timer.Interval = Value
            End If
        End Set
    End Property
    ' PauseTime
#End Region

#Region " StartScrolling "
    '
    ' Causes the text to begin scrolling.
    '
    Public Sub StartScrolling()
        timer.Start()
    End Sub
    ' StartScrolling
#End Region

#Region " StopScrolling "
    '
    ' Causes the text to stop scrolling.
    '
    Public Sub StopScrolling()
        Me.timer.Stop()
    End Sub
    ' StopScrolling
#End Region

#Region " ScrollLeft "
    '
    ' Gets and sets a bool which indicates if the text should scroll to the left or to the right.
    '
    Public Property ScrollLeft() As Boolean
        Get
            Return Me.doScrollLeft
        End Get
        Set(ByVal Value As Boolean)
            Me.doScrollLeft = Value
        End Set
    End Property
    ' ScrollLeft
#End Region

    ' Public Interface
#End Region

#Region " Private Helpers "

#Region " UpdateText "
    ' This method moves the characters of the display text so that it appears that the text is scrolling.
    ' Note, the Text property of the UltraLabel will not be changed by this Draw Filter.  This filter
    ' keeps a local copy of the label's Text and only changes the local copy.
    Private Sub UpdateText()
        If Me.txt.Length = 0 Then
            Return
        End If
        Dim ch As Char
        If Me.ScrollLeft Then
            ch = Me.txt(0)
            Me.txt.Remove(0, 1)
            Me.txt.Append(ch)
        Else
            ch = Me.txt(Me.txt.Length - 1)
            Me.txt.Remove(Me.txt.Length - 1, 1)
            Me.txt.Insert(0, ch)
        End If
    End Sub
    ' UpdateText
#End Region

#Region " timer_Tick "

    Private Sub timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        ' When the timer ticks we want the control to be redrawn.
        ' This will repaint the background but we will intercept the rendering
        ' of the foreground (text) and draw it ourself.
        Me.hasScrolled = False
        'Me.label.Refresh()
        Me.UStatus.Refresh()
    End Sub
    ' timer_Tick
#End Region

#Region " label_TextChanged "
    Private Sub Status_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.txt = New StringBuilder(Me.UStatus.Panels(i16Item).Text)

    End Sub
    Private Sub label_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' If the label's text changes, we need to store a local copy of the new text.
        Me.txt = New StringBuilder(Me.label.Text)

    End Sub
    ' label_TextChanged
#End Region

    ' Private Helpers
#End Region

End Class

' ScrollingMarqueeLabelDrawFilter

#End Region