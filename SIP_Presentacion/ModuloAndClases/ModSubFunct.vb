Imports SIP_Negocio
Imports SIP_Entidad
Imports SIP_Reporte
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinTabControl
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinTree
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Infragistics.Win.UltraWinToolbars.UltraToolbar
Imports Infragistics.Win.UltraWinStatusBar
Imports Infragistics.Win.UltraWinExplorerBar
Imports System
Imports System.Configuration
Imports System.Windows
Imports System.Windows.Forms
Imports System.Windows.Forms.ErrorProvider

Module ModSubFunct

    Private ScrollMsg As ScrollingMarqueeLabelDrawFilter = Nothing
    Private RptCrystal As Object = Nothing
    Private Ls_Sistema As List(Of ETUsuario) = Nothing
    Private Ls_Formulario As List(Of ETUsuario) = Nothing
    Private Ls_Grupo As List(Of String) = Nothing
    Private _Grupo As String = String.Empty
    Private ContainerControl As UltraExplorerBarContainerControl = Nothing
    Private TreeNode As UltraTreeNode = Nothing
    Private ObjTreeView As Object = Nothing



#Region "Procedimientos"

    Public Sub UbicarCursor_FiltroCelda(ByVal Grilla As UltraGrid, ByVal Fila As UltraGridRow, ByVal Columna As String)

        Fila.Cells(Columna).Activated = Boolean.TrueString
        Grilla.PerformAction(EnterEditMode)

    End Sub

    'Public Function LetraExcel(ByVal Columna As Integer) As String
    '    Select Case Columna
    '        Case 1
    '            Return "A"
    '        Case 2
    '            Return "B"
    '        Case 3
    '            Return "C"
    '        Case 4
    '            Return "D"
    '        Case 5
    '            Return "E"
    '        Case 6
    '            Return "F"
    '        Case 7
    '            Return "G"
    '        Case 8
    '            Return "H"
    '        Case 9
    '            Return "I"
    '        Case 10
    '            Return "J"
    '        Case 11
    '            Return "K"
    '        Case 12
    '            Return "L"
    '        Case 13
    '            Return "M"
    '        Case 14
    '            Return "N"
    '        Case 15
    '            Return "O"
    '        Case 16
    '            Return "P"
    '        Case 17
    '            Return "Q"
    '        Case 18
    '            Return "R"
    '        Case 19
    '            Return "S"
    '        Case 20
    '            Return "T"
    '        Case 21
    '            Return "U"
    '        Case 22
    '            Return "V"
    '        Case 23
    '            Return "W"
    '        Case 24
    '            Return "X"
    '        Case 25
    '            Return "Y"
    '        Case 26
    '            Return "Z"
    '        Case 27
    '            Return "A"
    '        Case 28
    '            Return "A"
    '        Case 29
    '            Return "A"
    '        Case 30
    '            Return "A"
    '        Case 31
    '            Return "A"
    '        Case 32
    '            Return "A"
    '        Case 33
    '            Return "A"
    '        Case 34
    '            Return "A"
    '        Case 35
    '            Return "A"
    '        Case 36
    '            Return "A"
    '        Case 37
    '            Return "A"
    '        Case 38
    '            Return "A"
    '        Case 39
    '            Return "A"
    '        Case 40
    '            Return "A"
    '        Case 41
    '            Return "A"
    '        Case 42
    '            Return "A"
    '        Case 43
    '            Return "A"
    '        Case 44
    '            Return "A"
    '        Case 45
    '            Return "A"
    '        Case 46
    '            Return "A"
    '        Case 47
    '            Return "A"
    '        Case 48
    '            Return "A"
    '        Case 49
    '            Return "A"
    '        Case 50
    '            Return "A"
    '        Case 51
    '            Return "A"
    '        Case 52
    '            Return "A"
    '        Case 53
    '            Return "A"
    '        Case 54
    '            Return "A"
    '        Case 55
    '            Return "A"
    '        Case 56
    '            Return "A"
    '        Case 57
    '            Return "A"
    '        Case 58
    '            Return "A"
    '        Case 59
    '            Return "A"
    '        Case 60
    '            Return "A"
    '        Case 61
    '            Return "A"
    '        Case 62
    '            Return "A"
    '        Case 63
    '            Return "A"
    '        Case 64
    '            Return "A"
    '        Case 65
    '            Return "A"
    '        Case 66
    '            Return "A"
    '        Case 67
    '            Return "A"
    '        Case 68
    '            Return "A"
    '        Case 69
    '            Return "A"
    '        Case 60
    '            Return "A"
    '        Case 61
    '            Return "A"
    '        Case 62
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"
    '        Case 11
    '            Return "A"
    '        Case 2
    '            Return "A"
    '        Case 3
    '            Return "A"
    '        Case 4
    '            Return "A"
    '        Case 5
    '            Return "A"
    '        Case 6
    '            Return "A"
    '        Case 7
    '            Return "A"
    '        Case 8
    '            Return "A"
    '        Case 9
    '            Return "A"
    '        Case 10
    '            Return "A"

    '    End Select
    'End Function

    Public Sub CargarUltraCombo(ByVal Combo As UltraCombo, ByVal DataSource As Object, _
                                 ByVal ValueMember As String, ByVal DisplayMember As String, _
                                 Optional ByVal Value As String = Nothing)

        If Combo Is Nothing OrElse DataSource Is Nothing OrElse String.IsNullOrEmpty(ValueMember) OrElse String.IsNullOrEmpty(DisplayMember) Then
            Return
        End If

        Combo.DataSource = DataSource
        Combo.ValueMember = ValueMember
        Combo.DisplayMember = DisplayMember

        If Value IsNot Nothing Then
            Combo.Value = Value
        Else
            SeleccionarItem(Combo, ValueMember)
        End If

    End Sub

    Sub SeleccionarItem(ByVal Combo As UltraCombo, ByVal ValueMember As String)

        If Combo Is Nothing OrElse String.IsNullOrEmpty(ValueMember) Then
            Return
        End If

        If Combo.Rows.Count <> 1 Then
            Exit Sub
        End If

        For Each uRow As UltraGridRow In Combo.Rows
            Combo.Value = uRow.Cells(ValueMember).Value
        Next

    End Sub

    Public Sub CargarUltraGrid(ByVal Grilla As UltraGrid, ByVal DataSource As Object, _
                               Optional ByVal DataMember As String = Nothing)

        If Grilla Is Nothing OrElse DataSource Is Nothing Then
            Return
        End If

        Grilla.DataSource = DataSource
        Grilla.DataMember = DataMember

    End Sub

    Public Sub LlenarMeses(ByVal Combo As UltraComboEditor, ByVal Anio As Long, ByVal Mes As Short)
        Dim i As Short = 1
        Combo.Items.Clear()
        If Year(Date.Today) = Anio Then
            For i = 1 To Mes
                Dim Item As New Infragistics.Win.ValueListItem
                Item.DataValue = i
                Item.DisplayText = NameMes(i)
                Combo.Items.Add(Item)
            Next
        ElseIf Year(Date.Today) > Anio Then
            For i = 1 To 12
                Dim Item1 As New Infragistics.Win.ValueListItem
                Item1.DataValue = i
                Item1.DisplayText = NameMes(i)
                Combo.Items.Add(Item1)
            Next
        End If

    End Sub



    Public Sub LlenarAnio(ByVal Combo As UltraComboEditor, ByVal AnioInicio As Long, ByVal AnioFin As Long)
        Dim i As Long = 0
        Combo.Items.Clear()

        For i = AnioInicio To AnioFin
            Dim Item As New Infragistics.Win.ValueListItem
            Item.DataValue = i
            Item.DisplayText = NameMes(i)
            Combo.Items.Add(Item)
        Next

    End Sub

    Public Sub CargarUltraGridxBinding(ByVal Grilla As UltraGrid, _
                                       ByVal Source As BindingSource, _
                                       ByVal DataSource As Object, _
                                       Optional ByVal Columna As String = "")

        If Grilla Is Nothing OrElse Source Is Nothing OrElse DataSource Is Nothing Then
            Return
        End If

        Source.DataSource = DataSource
        Grilla.DataSource = Source

        If String.IsNullOrEmpty(Columna) Then Return

        Call UbicarCursor_FiltroCelda(Grilla, Grilla.Rows.FilterRow, Columna)


    End Sub

    Public Sub CargarUltraDropDown(ByVal DropDown As UltraDropDown, _
                                   ByVal DataSource As Object)

        If DataSource Is Nothing Then
            Return
        End If

        DropDown.DataSource = DataSource

    End Sub

    'Public Sub CargarUltraDropDown(ByVal Grilla As UltraGrid, _
    '                               ByVal DropDown As UltraDropDown, _
    '                               ByVal DataSource As Object, _
    '                               ByVal Column As String, _
    '                               ByVal ValueMember As String, _
    '                               ByVal DisplayMember As String)

    '    If Grilla Is Nothing OrElse DropDown Is Nothing OrElse _
    '       DataSource Is Nothing OrElse String.IsNullOrEmpty(Column) OrElse _
    '       String.IsNullOrEmpty(ValueMember) OrElse String.IsNullOrEmpty(DisplayMember) Then
    '        Return
    '    End If

    '    DropDown.DataSource = DataSource
    '    DropDown.ValueMember = ValueMember
    '    DropDown.DisplayMember = DisplayMember
    '    Grilla.DisplayLayout.Bands(0).Columns(Column).ValueList = DropDown

    'End Sub

    Public Sub Iniciar_Excel(ByVal Archivo As String)
        Try
            Dim excel1 As New Process
            excel1.StartInfo.Arguments = """" + Archivo + """ /e"
            excel1.StartInfo.FileName = Archivo
            excel1.Start()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub CargarUltraStatusBar(ByVal Form As FrmBMain, ByVal Type As uStatus)

        If Form Is Nothing Then
            Return
        End If

        If Type = uStatus.Procesando Then

            Form.Cursor = Cursors.WaitCursor
            Form.stbMain.Panels("KeyEstado").Text = "Procesando ..."

            For i = 0 To 50
                Form.stbMain.Panels("KeyTiempo").ProgressBarInfo.Value = i
                Form.stbMain.Refresh()
            Next

        Else

            For i = 50 To 100
                Form.stbMain.Panels("KeyTiempo").ProgressBarInfo.Value = i
                Form.stbMain.Refresh()
            Next

            Form.stbMain.Panels("KeyEstado").Text = "Finalizado ..."
            Form.Cursor = Cursors.Default

        End If

    End Sub

    Public Sub CargarError(ByVal Ep As ErrorProvider, ByVal Control As Object, Optional ByVal Mensaje As String = Nothing)

        If Ep Is Nothing OrElse Control Is Nothing Then
            Return
        End If

        Ep.SetError(Control, Mensaje)

    End Sub

    Public Sub AdministrarToolBar(ByVal FormParent As FrmBMain, _
                                  Optional ByVal Operaciones As List(Of String) = Nothing, _
                                  Optional ByVal Tipo As Boolean = False)

        If FormParent Is Nothing Then
            Return
        End If

        If Tipo = Boolean.TrueString Then
            For Each uBoton As Object In FormParent.tolMain.Tools
                If Mid(uBoton.Key, 1, 1) = "K" Then
                    uBoton.SharedProps.Enabled = Boolean.FalseString
                End If
            Next
            Return
        End If

        If Operaciones Is Nothing Then
            For Each uBoton As Object In FormParent.tolMain.Tools
                If Mid(uBoton.Key, 1, 1) = "K" Then
                    uBoton.SharedProps.Enabled = Boolean.TrueString
                End If
            Next
        Else
            For Each uBoton As Object In FormParent.tolMain.Tools
                If Mid(uBoton.Key, 1, 1) = "K" Then
                    uBoton.SharedProps.Enabled = Boolean.FalseString
                End If
            Next
            For Each Key As String In Operaciones
                FormParent.tolMain.Tools.Item(Key).SharedProps.Enabled = Boolean.TrueString
            Next
        End If

        FormParent.Refresh()

    End Sub

    Public Sub ScrollLabel(ByVal uLabel As UltraLabel)

        ScrollMsg = New ScrollingMarqueeLabelDrawFilter(uLabel)

        ScrollMsg.ScrollLeft = Boolean.TrueString

        ScrollMsg.PauseTime = 0

        uLabel.DrawFilter = ScrollMsg

        ScrollMsg.StartScrolling()

        uLabel.Text = Mensaje.Scroll

    End Sub

    Public Sub Visor_Consulta_Reporte(ByVal I As Short, ByVal Source As Object, ByVal TipoDoc As ExpArchivo, ByVal Nombre As String, ByVal Carpeta As Short)

        Reporte.Exportar = New RptExportar

        Call Reporte.Exportar.Cargar_Consulta(I, Source, TipoDoc, Nombre, Carpeta)

    End Sub

    Public Sub Visor_Crystal_Reporte(ByVal I As Short, ByVal Source As Object, ByVal TipoDoc As ExpArchivo, ByVal Nombre As String, ByVal Carpeta As Short)

        RptCrystal = New Object
        Reporte.Exportar = New RptExportar
        Reporte.Informe = New RptInforme(Servidor_App, BD_App)

        RptCrystal = Reporte.Informe.Cargar_Proceso_Crystal(I, Source)

        If RptCrystal Is Nothing Then Return

        Call Reporte.Exportar.Cargar_Crystal(RptCrystal, TipoDoc, Nombre, Carpeta)

    End Sub

    Public Sub GuardarConfiguracion(ByVal Valor As String, ByVal Campo As String)

        If String.IsNullOrEmpty(Valor) OrElse String.IsNullOrEmpty(Campo) Then
            Return
        End If

        Try

            Dim MngConfig As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            If MngConfig.AppSettings.Settings(Campo) IsNot Nothing Then
                MngConfig.AppSettings.Settings(Campo).Value = Valor
            Else
                MngConfig.AppSettings.Settings.Add(Campo, Valor)
            End If

            'MngConfig.Save(ConfigurationSaveMode.Full)

        Catch
        End Try

    End Sub


    'Public Function Fc_Obtener_UltimoDiaMes(ByVal _Anho As Integer, ByVal _Mes As Integer) As Date

    '    Dim lResult As Date

    '    If _Mes <> 12 Then

    '        _Mes += 1

    '    End If

    '    Return lResult

    'End Function

    Public Sub UbicarCursorGrilla(ByVal Grid As UltraGrid, ByVal row As UltraGridRow, ByVal Celda As String)
        row.Cells(Celda).Activated = Boolean.TrueString
        Grid.PerformAction(UltraGridAction.EnterEditMode)
    End Sub


    Public Sub ListarAreaUsuario(ByVal Cbo As UltraCombo, ByVal Movimiento As String)
        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario

        With Entidad.Usuario
            .Name_User = User_Sistema
        End With
        Cbo.DataSource = Negocio.Usuario.MovimientosAlmacen(Entidad.Usuario, "ARU")
        Cbo.DisplayMember = "Descripcion"
        Cbo.ValueMember = "Codigo"
    End Sub


    Public Sub ListarMovimientosUsuario(ByVal Cbo As UltraCombo, ByVal Movimiento As String)
        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario

        With Entidad.Usuario
            .Cod_Cia = Companhia
            .Name_User = User_Sistema
        End With
        Cbo.DataSource = Negocio.Usuario.MovimientosAlmacen(Entidad.Usuario, "LMU")
        Cbo.DisplayMember = "Descripcion"
        Cbo.ValueMember = "Codigo"
        Cbo.Value = Movimiento
    End Sub

    Public Sub ListarAlmacenUsuarios(ByVal Cbo As UltraCombo, ByVal Almacen As String)
        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario

        With Entidad.Usuario
            .Cod_Cia = Companhia
            .Name_User = User_Sistema
        End With
        Cbo.DataSource = Negocio.Usuario.MovimientosAlmacen(Entidad.Usuario, "LAU")
        Cbo.DisplayMember = "Descripcion"
        Cbo.ValueMember = "Codigo"
        If Cbo.Rows.Count = 1 Then
            Cbo.Value = Cbo.Rows(0).Cells("Codigo").Value
        Else
            Cbo.Value = Almacen
        End If

    End Sub

    Public Sub ListarAlmacen_General(ByVal cbo As UltraCombo)
        Entidad.Almacen = New ETAlmacen
        Negocio.Almacen = New NGAlmacen

        With Entidad.Almacen
            .Cod_Cia = Companhia
        End With
        cbo.DataSource = Negocio.Almacen.Listar_Almacen(Entidad.Almacen, "LIS")
        cbo.DisplayMember = "descrip"
        cbo.ValueMember = "cod_alm"
        cbo.Value = 28
    End Sub

    Public Sub ListarArea_General(ByVal cbo As UltraCombo)
        Negocio.Maestros2 = New NGMaestros2
        cbo.DataSource = Negocio.Maestros2.ListarAreaSolicitante("LIS")
        cbo.DisplayMember = "descrip"
        cbo.ValueMember = "cod_maestro2"
    End Sub

    Public Sub ListarTipoActivo(ByVal cbo As UltraComboEditor)
        cbo.Items.Clear()
        Negocio.Maestros2 = New NGMaestros2
        cbo.DataSource = Negocio.Maestros2.ListarTipoActivo()
        cbo.DisplayMember = "descrip"
        cbo.ValueMember = "cod_maestro2"
    End Sub

    Public Sub Cargar_CosteoMineral_Conceptos_Variacion(ByVal Grilla As UltraGrid, ByVal Cia As String)
        
        Negocio.Activo = New NGActivo
        Call CargarUltraGrid(Grilla, Negocio.Activo.CosteoMineral_Listar)
    End Sub


    Public Sub ListarCia(ByVal cbo As UltraCombo)
        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario

        With Entidad.Usuario
            .Login = User_Sistema
            .Sistema = Sistema
        End With
        cbo.DataSource = Negocio.Usuario.ListarCia(Entidad.Usuario, "LIS")
        cbo.DisplayMember = "razsoc"
        cbo.ValueMember = "cod_cia"
        cbo.Value = Companhia
    End Sub

    Public Sub Cargar_Area(ByVal Cbo As UltraCombo, ByVal Cia As String, ByVal Tipo As Integer)
        Dim Ls_Area As New List(Of ETArea)

        Dim objArea As New ETArea
        Dim ObjNeg As New NGArea

        objArea.Cod_Cia = Cia
        objArea.Tipo = Tipo

        objArea.Usuario = User_Sistema
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = ObjNeg.Consultar_Area(objArea)
        If Entidad.MyLista.Validacion Then
            Ls_Area = Entidad.MyLista.Ls_Area
        End If

        Call CargarUltraCombo(Cbo, Ls_Area, "Codigo", "Area")
    End Sub

    Public Sub ListarMotivoAnulacion(ByVal cbo As UltraCombo)
        Negocio.Maestros2 = New NGMaestros2
        cbo.DataSource = Negocio.Maestros2.Listar_Maestros2(Companhia, "", "", "", "LMA", "", Now.ToShortDateString, Now)
        cbo.DisplayMember = "Motivo"
        cbo.ValueMember = "Codigo"
    End Sub

    Public Sub ContratistaCantera(ByVal cbo As UltraCombo, ByVal Cantera As String, ByVal Area As String)
        With Entidad.EmpleoLabor
            .Cod_Cia = Companhia
            .Cod_Cantera = Cantera
        End With
        cbo.DataSource = Negocio.EmpleoLabor.ContratistaCantera(Entidad.EmpleoLabor, "LCO")
        cbo.DisplayMember = "Descripcion"
        cbo.ValueMember = "Codigo"

        If Area = "22" Then
            If cbo.Rows.Count = 1 Then
                cbo.Enabled = True
                cbo.Value = 0
            ElseIf cbo.Rows.Count = 0 Then
                cbo.Enabled = False
            ElseIf cbo.Rows.Count > 1 Then
                cbo.Enabled = True
                cbo.Value = 0
            End If
        Else
            cbo.Enabled = False
        End If
    End Sub

#End Region

#Region "Funciones"

    Public Function Fc_Conversion(ByVal O As ETObjecto) As Decimal

        Entidad.Objecto = New ETObjecto
        Negocio.Maestro = New NGMaestro

        Entidad.Objecto = Negocio.Maestro.Converciones(O)

        If Not Entidad.Objecto.Validacion Then

            Fc_Conversion = 0

        Else
            If Entidad.Objecto.Operacion = "*" Then
                Fc_Conversion = O.ValorxDecimal * Entidad.Objecto.Factor
            End If
            If Entidad.Objecto.Operacion = "/" Then
                Fc_Conversion = O.ValorxDecimal / Entidad.Objecto.Factor
            End If
        End If

    End Function

    Public Function AccesoFormulario(ByVal strForm As String) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If String.IsNullOrEmpty(strForm) Then
            Return lResult
        End If

        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario

        Entidad.Usuario.Tipo = Convert.ToInt16(Permisos.Form)
        Entidad.Usuario.Usuario = User_Sistema
        Entidad.Usuario.Formulario = strForm

        Entidad.Objecto = New ETObjecto
        Entidad.Objecto = Negocio.Usuario.ConsultarPermisos(Entidad.Usuario)

        If Entidad.Objecto.Validacion Then lResult = Boolean.TrueString

        Return lResult

    End Function

    Public Function AccesoOperacion(ByVal strForm As String, ByVal strOpe As String) As Boolean

        Dim lResult As Boolean = Boolean.FalseString

        If String.IsNullOrEmpty(strForm) OrElse String.IsNullOrEmpty(strOpe) Then
            Return lResult
        End If

        If strOpe = "K05" OrElse strOpe = "K06" OrElse _
           strOpe = "K09" OrElse strOpe = "K04" Then
            lResult = Boolean.TrueString
            Return lResult
        End If

        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario

        Entidad.Usuario.Tipo = Convert.ToInt16(Permisos.Operacion)
        Entidad.Usuario.Usuario = User_Sistema
        Entidad.Usuario.Formulario = strForm
        Entidad.Usuario.Operacion = strOpe

        Entidad.Objecto = New ETObjecto
        Entidad.Objecto = Negocio.Usuario.ConsultarPermisos(Entidad.Usuario)

        If Entidad.Objecto.Validacion Then lResult = Boolean.TrueString

        Return lResult

    End Function

    Public Function ConvertObjtoStr(ByVal ArrayString As String()) As String
        ConvertObjtoStr = String.Empty
        For Each s As String In ArrayString
            ConvertObjtoStr &= s & ";"
        Next
        Return ConvertObjtoStr
    End Function

    Public Function ExisteFichero(ByVal strRuta As String) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If String.IsNullOrEmpty(strRuta) Then
            Return lResult
        End If

        If IO.File.Exists(strRuta) Then lResult = Boolean.TrueString

        Return lResult

    End Function

    Public Function VerificarControl(ByVal xTipo As Int16, ByRef Control As Object) As Boolean

        VerificarControl = Boolean.FalseString

        Select Case xTipo
            Case 1
                REM ultratexteditor
                If Not (Control.value Is Nothing OrElse Control.value = String.Empty) Then
                    VerificarControl = Boolean.TrueString
                End If
            Case 2
                REM ultradate
                If IsDate(Control.value) Then
                    VerificarControl = Boolean.TrueString
                End If
            Case 3
                REM ultranumeric
                If Not (Not IsNumeric(Control.value) OrElse Control.value = 0) Then
                    VerificarControl = Boolean.TrueString
                End If
            Case 4
                REM ultracombo
                If Control.value IsNot Nothing Then
                    VerificarControl = Boolean.TrueString
                End If
            Case 5
                REM ultraGRID
                If Not (Control.DataSource Is Nothing OrElse Control.Rows.Count = 0) Then
                    VerificarControl = Boolean.TrueString
                End If
        End Select

        Return VerificarControl

    End Function

    Public Function NombrarFormulario(ByVal Key As String) As String

        NombrarFormulario = String.Empty

        Select Case Key
            Case StrucToolTag.MUsuarios
                NombrarFormulario = "Usuarios"
            Case StrucToolTag.MProductoRuma
                NombrarFormulario = "Enlace (Producto-Ruma)"
            Case StrucToolTag.MProductoxUnidad
                NombrarFormulario = "Enlace (Producto-Unidad)"
            Case StrucToolTag.MFormula
                NombrarFormulario = "Formulación"
        End Select

        Return NombrarFormulario

    End Function

    Public Function Codigo_Producto(ByVal Numero As String) As String
        Select Case Len(Numero)
            Case 1
                Codigo_Producto = "5000000" & Numero
            Case 2
                Codigo_Producto = "500000" & Numero
            Case 3
                Codigo_Producto = "50000" & Numero
            Case 4
                Codigo_Producto = "5000" & Numero
            Case 5
                Codigo_Producto = "500" & Numero
            Case 6
                Codigo_Producto = "50" & Numero
            Case 7
                Codigo_Producto = "5" & Numero
            Case Else
                Codigo_Producto = Numero
        End Select
        Return Codigo_Producto
    End Function

    Public Function NumeroMovimientoAlmacen(ByVal Numero As String) As String
        Select Case Len(Numero)
            Case 1
                NumeroMovimientoAlmacen = "000000" & Numero
            Case 2
                NumeroMovimientoAlmacen = "00000" & Numero
            Case 3
                NumeroMovimientoAlmacen = "0000" & Numero
            Case 4
                NumeroMovimientoAlmacen = "000" & Numero
            Case 5
                NumeroMovimientoAlmacen = "00" & Numero
            Case 6
                NumeroMovimientoAlmacen = "0" & Numero
            Case Else
                NumeroMovimientoAlmacen = Numero
        End Select
        Return NumeroMovimientoAlmacen
    End Function

    Public Function NumeroCorrelativoConversion(ByVal Numero As String) As String
        Select Case Len(Numero)
            Case 1
                NumeroCorrelativoConversion = "0000" & Numero
            Case 2
                NumeroCorrelativoConversion = "000" & Numero
            Case 3
                NumeroCorrelativoConversion = "00" & Numero
            Case 4
                NumeroCorrelativoConversion = "0" & Numero
            Case Else
                NumeroCorrelativoConversion = Numero
        End Select
        Return NumeroCorrelativoConversion
    End Function

    Public Function Mes(ByVal Numero As String) As String
        Select Case Len(Numero)
            Case 1
                Mes = "0" & Numero
            Case Else
                Mes = Numero
        End Select
        Return Mes
    End Function

    Public Function NameMes(ByVal Mes As Short) As String
        Dim Nombre As String = String.Empty
        Select Case Mes
            Case 1
                Nombre = "ENERO"
            Case 2
                Nombre = "FEBRERO"
            Case 3
                Nombre = "MARZO"
            Case 4
                Nombre = "ABRIL"
            Case 5
                Nombre = "MAYO"
            Case 6
                Nombre = "JUNIO"
            Case 7
                Nombre = "JULIO"
            Case 8
                Nombre = "AGOSTO"
            Case 9
                Nombre = "SETIEMBRE"
            Case 10
                Nombre = "OCTUBRE"
            Case 11
                Nombre = "NOVIEMBRE"
            Case 12
                Nombre = "DICIEMBRE"
        End Select
        Return Nombre
    End Function

    Public Function TipoCambio() As String

        Dim Cambio As New DataTable
        Cambio = Negocio.Guia.ListarTipoCambio(Companhia, "L1")

        If Cambio.Rows.Count > 0 Then
            TipoCambio = Cambio.Rows(0).Item("Compra")
        Else
            MsgBox("No hay tipo de cambio para el dia " + Now, MsgBoxStyle.Critical, "Comacsa")
            Cambio = Negocio.Guia.ListarTipoCambio(Companhia, "L2")
            TipoCambio = Cambio.Rows(0).Item("Compra")
        End If

    End Function

    Public Function Existe_Producto_Conversion(ByVal Codigo As String, ByVal Origen As String, ByVal Destino As String) As Boolean
        Dim Existencia As New DataTable
        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodProducto = Codigo
            .Unidad = Origen
            .UnidadDesp = Destino
        End With
        Existencia = Negocio.Producto.Existe_Producto_Conversion(Entidad.Producto)

        If Existencia.Rows.Count = 0 Then
            Existe_Producto_Conversion = True
        Else
            Existe_Producto_Conversion = False
        End If

    End Function

    Public Function DescripcionMes(ByVal mes As String) As String
        Select Case mes
            Case "01"
                DescripcionMes = "ENERO"
            Case "02"
                DescripcionMes = "FEBRERO"
            Case "03"
                DescripcionMes = "MARZO"
            Case "04"
                DescripcionMes = "ABRIL"
            Case "05"
                DescripcionMes = "MAYO"
            Case "06"
                DescripcionMes = "JUNIO"
            Case "07"
                DescripcionMes = "JULIO"
            Case "08"
                DescripcionMes = "AGOSTO"
            Case "09"
                DescripcionMes = "SEPTIEMBRE"
            Case "10"
                DescripcionMes = "OCTUBRE"
            Case "11"
                DescripcionMes = "NOVIEMBRE"
            Case Else
                DescripcionMes = "DICIEMBRE"
        End Select
    End Function


    Public Function Saldo_Stock(ByVal Codigo As String, ByVal Almacen As String, ByVal Tipo As String) As Double
        Dim dtStock As New DataTable
        With Entidad.Producto
            .Cod_Cia = Companhia
            .CodProducto = Codigo
            .CodAlmacen = Almacen
            .TipoProducto = Tipo
            .FechaCreacion = Now
        End With
        dtStock = Negocio.Producto.ProductoStockActual(Entidad.Producto)

        If dtStock.Rows.Count > 0 Then
            Saldo_Stock = dtStock.Rows(0).Item("Stock")
        Else
            Saldo_Stock = 0
        End If

    End Function

    Public Function SumaTotalProducto(ByVal grid As UltraGrid, ByVal Codigo As String) As Double
        Dim dtGrid As New DataTable
        Dim xTotal As Double = 0
        dtGrid = grid.DataSource

        For i As Integer = 0 To dtGrid.Rows.Count - 1
            If dtGrid.Rows(i).Item("Codigo") = Codigo Then
                xTotal = xTotal + CDbl(dtGrid.Rows(i).Item("CantidadIngresoAlmacen"))
            End If
        Next
        SumaTotalProducto = xTotal
    End Function

    Public Function FacturacionBillete(ByVal Movimiento As String, ByVal Billete As String) As Boolean
        Dim dtFacturacion As New DataTable
        Dim Facturas As String = ""
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Tipo_Mov = Movimiento
            .NumDoc = Billete
        End With
        dtFacturacion = Negocio.Guia.Listar_Guia(Entidad.Guia, "FAC")

        If dtFacturacion.Rows.Count > 0 Then
            For i As Integer = 0 To dtFacturacion.Rows.Count - 1
                Facturas = Facturas & vbCrLf & dtFacturacion.Rows(i).Item("Codigo") & " - " & dtFacturacion.Rows(i).Item("Billete")
            Next
            MsgBox("Número de documento " & Billete & " ya tiene factura(s) registrada por compras, no se podrá eliminar" & Facturas, MsgBoxStyle.Critical, "Comacsa")
            FacturacionBillete = True
        Else
            FacturacionBillete = False
        End If
    End Function

    Public Function VerificarDevolucion(ByVal Movimiento As String, ByVal Documento As String, ByVal Numero As String, ByVal Oc As String) As Boolean
        Dim dtDevolucion As New DataTable
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Tipo_Mov = Movimiento
            .Tipo_Doc = Documento
            .NumDoc = Numero
            .NumDoc2 = Oc
        End With
        dtDevolucion = Negocio.Guia.VerificaDevolucion(Entidad.Guia)

        If dtDevolucion.Rows.Count > 0 Then
            VerificarDevolucion = True
        Else
            VerificarDevolucion = False
        End If
    End Function

    Public Function PeriodoCerrado(ByVal Almacen As String, ByVal Periodo As String) As Boolean
        Dim dtPeriodo As New DataTable
        With Entidad.Almacen
            .Cod_Cia = Companhia
            .CodAlmacen = Almacen
            .Periodo = Periodo
        End With
        dtPeriodo = Negocio.Almacen.Listar_Almacen(Entidad.Almacen, "CIE")
        If dtPeriodo.Rows.Count > 0 Then
            MsgBox("El Periodo del Almacen ya fue cerrado, No estan permitido los cambios.", MsgBoxStyle.Critical, "Comacsa")
            PeriodoCerrado = True
        Else
            PeriodoCerrado = False
        End If
    End Function

    Public Function Existe_Serie(ByVal Almacen) As Boolean
        Dim dtSerie As New DataTable
        With Entidad.Almacen
            .Cod_Cia = Companhia
            .CodAlmacen = Almacen
        End With
        dtSerie = Negocio.Almacen.Listar_Almacen(Entidad.Almacen, "GEN")

        If dtSerie.Rows.Count > 0 Then
            Existe_Serie = True
        Else
            Existe_Serie = False
        End If
    End Function

    Public Function Existe_Numeracion_Automatico(ByVal Almacen As String, ByVal Movimiento As String) As Boolean
        Dim dtNumeracion As New DataTable
        With Entidad.Almacen
            .Cod_Cia = Companhia
            .CodAlmacen = Almacen
            .Tipo_Mov = Movimiento
        End With
        dtNumeracion = Negocio.Almacen.Listar_Almacen(Entidad.Almacen, "XMO")

        If dtNumeracion.Rows(0).Item("Tipo") = "A" Then
            Existe_Numeracion_Automatico = True
        Else
            Existe_Numeracion_Automatico = False
        End If
    End Function

    Public Function Existe_NumeroMovimiento(ByVal Tipo_Mov As String, ByVal Tipo_Doc As String, ByVal Numero As String) As Boolean
        Dim dtNumero As New DataTable
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Tipo_Mov = Tipo_Mov
            .Tipo_Doc = Tipo_Doc
            .NumDoc = Numero
        End With
        dtNumero = Negocio.OrdenCompraBL.DocumentosReferencia(Entidad.Guia, "VA2")

        If dtNumero.Rows.Count > 0 Then
            MsgBox("El número de documento ya fue ingresado.", MsgBoxStyle.Critical, "Comacsa")
            Existe_NumeroMovimiento = True
        Else
            Existe_NumeroMovimiento = False
        End If

        Return True
    End Function


#End Region

    Public Sub Activar_Sistemas(ByVal TabControl As UltraTabControl)

        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario
        Entidad.MyLista = New ETMyLista
        Ls_Sistema = New List(Of ETUsuario)

        Entidad.Usuario.Tipo = 1
        Entidad.Usuario.Usuario = User_Sistema

        Entidad.MyLista = Negocio.Usuario.ConsultarERP_1(Entidad.Usuario)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Sistema = Entidad.MyLista.Ls_Usuario

        For Each Page As UltraTab In TabControl.Tabs
            For Each Entidad.Usuario In Ls_Sistema
                If Page.Key = Entidad.Usuario.Sistema Then
                    Page.Visible = Boolean.TrueString
                End If
            Next
        Next

    End Sub

    Public Sub Activar_Modulo_Sistema(ByVal TabControl As String, ByVal ExploreBar As Object)

        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario
        Entidad.MyLista = New ETMyLista
        Ls_Formulario = New List(Of ETUsuario)

        Entidad.Usuario.Tipo = 2
        Entidad.Usuario.Sistema = TabControl
        Entidad.Usuario.Usuario = User_Sistema
        Entidad.MyLista = Negocio.Usuario.ConsultarERP_2(Entidad.Usuario)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Formulario = Entidad.MyLista.Ls_Usuario

        Ls_Grupo = New List(Of String)

        For Each Rpt In Ls_Formulario
            _Grupo = String.Empty : _Grupo = Rpt.Grupo
            If Not Ls_Grupo.Exists(AddressOf Existe_Grupo) Then Ls_Grupo.Add(_Grupo)
        Next

        For Each uGpb As UltraExplorerBarGroup In ExploreBar.Groups
            uGpb.Visible = Boolean.FalseString
        Next

        For Each uGpb As UltraExplorerBarGroup In ExploreBar.Groups
            For Each Nombre_Grupo As String In Ls_Grupo
                If String.Compare(uGpb.Key, Nombre_Grupo) = 0 Then
                    uGpb.Visible = Boolean.TrueString
                    ContainerControl = Nothing : TreeNode = Nothing
                    ContainerControl = uGpb.Container
                    ObjTreeView = New Object
                    ObjTreeView = ContainerControl.Controls(0)
                    ObjTreeView.Nodes.Clear()
                    _Grupo = String.Empty : _Grupo = Nombre_Grupo
                    Call TreeNodo(Ls_Formulario.Where(AddressOf Where_Grupo).ToList(), ObjTreeView)
                End If
            Next
        Next

    End Sub

    Function Where_Grupo(ByVal Rpt As ETUsuario) As Boolean

        Dim lResult As Boolean = Boolean.FalseString
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt.Grupo = _Grupo Then lResult = Boolean.TrueString

        Return lResult

    End Function

    Function Existe_Grupo(ByVal Rpt As String) As Boolean

        Dim lResult As Boolean = False
        If Rpt Is Nothing Then
            Return lResult
        End If

        If Rpt = _Grupo Then
            lResult = Boolean.TrueString
        End If

        Return lResult

    End Function

    Sub TreeNodo(ByVal Lista As List(Of ETUsuario), ByVal TreeView As UltraTree)

        Call Ordenar_Item_Nodo(Lista)

        For Each w In Lista
            TreeNode = New UltraTreeNode
            TreeNode.Key = w.ID
            TreeNode.Text = w.Formulario
            If w.Tipo = 0 Then
                TreeNode.LeftImages.Add(1)
            End If
            If w.Tipo = 1 Then
                TreeNode.LeftImages.Add(0)
            End If
            If w.Jerarquia = 0 Then
                TreeView.Nodes.Add(TreeNode)
            Else
                Call RetornarNodo(w, TreeView).Nodes.Add(TreeNode)
            End If
        Next

    End Sub

    Sub Ordenar_Item_Nodo(ByRef Lista As List(Of ETUsuario))

        Dim LsSort = From Tabla In Lista _
                     Order By Tabla.Jerarquia Ascending, _
                              Tabla.Tipo Ascending, _
                              Tabla.Formulario Ascending _
                     Select Tabla

        Lista = New List(Of ETUsuario)

        For Each T In LsSort
            Lista.Add(T)
        Next

        LsSort = Nothing

    End Sub

    Function RetornarNodo(ByVal R As ETUsuario, ByVal TreeView As UltraTree) As UltraTreeNode

        Dim lResult As UltraTreeNode = Nothing
        If R Is Nothing Then
            Return lResult
        End If

        For Each Node_0 As UltraTreeNode In TreeView.Nodes
            For Each Node_1 As UltraTreeNode In Node_0.Nodes
                If String.Compare(R.KeyForm, Node_1.Key) = 0 Then
                    lResult = New UltraTreeNode
                    lResult = Node_1
                    Exit For
                End If
            Next
            If String.Compare(R.KeyForm, Node_0.Key) = 0 Then
                lResult = New UltraTreeNode
                lResult = Node_0
                Exit For
            End If
        Next
        Return lResult

    End Function

    Public Function Habilitar_Permisos(ByVal Key As String) As List(Of Integer)

        Dim lResult As List(Of Integer) = Nothing
        If String.IsNullOrEmpty(Key) Then
            Return lResult
        End If

        Entidad.Usuario = New ETUsuario
        Entidad.MyLista = New ETMyLista
        Negocio.Usuario = New NGUsuario
        lResult = New List(Of Integer)

        Entidad.Usuario.Tipo = 3
        Entidad.Usuario.Usuario = User_Sistema
        Entidad.Usuario.KeyForm = Key

        Entidad.MyLista = Negocio.Usuario.ConsultarERP_3(Entidad.Usuario)

        If Not Entidad.MyLista.Validacion Then GoTo Salir

        For Each Entidad.Usuario In Entidad.MyLista.Ls_Usuario
            lResult.Add(Convert.ToInt32(Entidad.Usuario.KeyOpe))
        Next
Salir:
        Return lResult

    End Function

    Public Sub Administrar_Permisos(ByVal FormParent As FrmBMain, _
                                    Optional ByVal Operaciones As List(Of Integer) = Nothing, _
                                    Optional ByVal Tipo As Boolean = False)

        If FormParent Is Nothing Then
            Return
        End If

        If Tipo = Boolean.TrueString Then
            For Each uBoton As Object In FormParent.tolMain.Tools
                If Mid(uBoton.Key, 1, 1) = "K" Then
                    uBoton.SharedProps.Enabled = Boolean.FalseString
                End If
            Next
            Return
        End If

        If Operaciones Is Nothing Then
            For Each uBoton As Object In FormParent.tolMain.Tools
                'If Mid(uBoton.Key, 1, 1) = "K" Then
                '    uBoton.SharedProps.Enabled = Boolean.TrueString
                'End If
                If IsNumeric(uBoton.Key) Then
                    uBoton.SharedProps.Enabled = Boolean.TrueString
                End If
            Next
        Else
            For Each uBoton As Object In FormParent.tolMain.Tools
                If IsNumeric(uBoton.Key) Then
                    uBoton.SharedProps.Enabled = Boolean.FalseString
                End If
                'If Mid(uBoton.Key, 1, 1) = "K" Then
                '    uBoton.SharedProps.Enabled = Boolean.FalseString
                'End If
            Next
            For Each Key As Integer In Operaciones
                FormParent.tolMain.Tools.Item(CStr(Key)).SharedProps.Enabled = Boolean.TrueString
            Next
        End If

        FormParent.Refresh()

    End Sub

    Public Function txtNumerico(ByVal txtControl As Infragistics.Win.UltraWinEditors.UltraTextEditor, ByVal caracter As Char, ByVal decimales As Boolean) As Boolean
        If (Char.IsNumber(caracter, 0) = True) Or caracter = Convert.ToChar(8) Or caracter = "." Or caracter = "-" Then
            If caracter = "." Or caracter = "-" Then
                If decimales = True Then
                    If txtControl.Text.IndexOf(".") <> -1 Then Return True
                Else : Return True
                End If
            End If
            Return False
        Else
            Return True
        End If
    End Function

    Public Function txtNumericoForm(ByVal txtControl As TextBox, ByVal caracter As Char, ByVal decimales As Boolean) As Boolean
        If (Char.IsNumber(caracter, 0) = True) Or caracter = Convert.ToChar(8) Or caracter = "." Then
            If caracter = "." Then
                If decimales = True Then
                    If txtControl.Text.IndexOf(".") <> -1 Then Return True
                Else : Return True
                End If
            End If
            Return False
        Else
            Return True
        End If
    End Function
End Module
