Imports System.Collections
Imports System.Runtime.InteropServices

Public Class ClsResolucion

    Public i32Horizontal As Int32 = 1024
    Public i32Vertical As Int32 = 768

    Public Sub Main()
        Resolucion.ChangeRes(i32Horizontal, i32Vertical)
        RL()
    End Sub

    Private Shared Sub WL(ByVal text As String, ByVal ParamArray args As Object())
        Console.WriteLine(text, args)
    End Sub

    Private Shared Sub RL()
        Console.ReadLine()
    End Sub

    Private Shared Sub Break()
        System.Diagnostics.Debugger.Break()
    End Sub

    Public Class Resolucion

        'Funciones
        <DllImport("user32.dll")> _
        Public Shared Function EnumDisplaySettings(ByVal deviceName As String, ByVal modeNum As Integer, ByRef devMode As DEVMODE) As Integer
        End Function
        <DllImport("user32.dll")> _
        Public Shared Function ChangeDisplaySettings(ByRef devMode As DEVMODE, ByVal flags As Integer) As Integer
        End Function

        'Constantes
        Public Const ENUM_CURRENT_SETTINGS As Integer = -1
        Public Const CDS_UPDATEREGISTRY As Integer = &H1
        Public Const CDS_TEST As Integer = &H2
        Public Const DISP_CHANGE_SUCCESSFUL As Integer = 0
        Public Const DISP_CHANGE_RESTART As Integer = 1
        Public Const DISP_CHANGE_FAILED As Integer = -1

        'Estructuras
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure DEVMODE
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> _
            Public dmDeviceName As String
            Public dmSpecVersion As Short
            Public dmDriverVersion As Short
            Public dmSize As Short
            Public dmDriverExtra As Short
            Public dmFields As Integer

            Public dmOrientation As Short
            Public dmPaperSize As Short
            Public dmPaperLength As Short
            Public dmPaperWidth As Short

            Public dmScale As Short
            Public dmCopies As Short
            Public dmDefaultSource As Short
            Public dmPrintQuality As Short
            Public dmColor As Short
            Public dmDuplex As Short
            Public dmYResolution As Short
            Public dmTTOption As Short
            Public dmCollate As Short
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)> _
            Public dmFormName As String
            Public dmLogPixels As Short
            Public dmBitsPerPel As Short
            Public dmPelsWidth As Integer
            Public dmPelsHeight As Integer

            Public dmDisplayFlags As Integer
            Public dmDisplayFrequency As Integer

            Public dmICMMethod As Integer
            Public dmICMIntent As Integer
            Public dmMediaType As Integer
            Public dmDitherType As Integer
            Public dmReserved1 As Integer
            Public dmReserved2 As Integer

            Public dmPanningWidth As Integer
            Public dmPanningHeight As Integer
        End Structure

        Public Shared Sub ChangeRes(ByVal HRes As Integer, ByVal VRes As Integer)

            Try
                Dim dm As New DEVMODE()
                dm.dmDeviceName = New [String](New Char(31) {})
                dm.dmFormName = New [String](New Char(31) {})
                dm.dmSize = CShort(Marshal.SizeOf(dm))

                If 0 <> EnumDisplaySettings(Nothing, ENUM_CURRENT_SETTINGS, dm) Then
                    dm.dmPelsWidth = HRes
                    dm.dmPelsHeight = VRes

                    Dim iRet As Integer = ChangeDisplaySettings(dm, CDS_TEST)

                    If iRet = DISP_CHANGE_FAILED Then
                    Else
                        iRet = ChangeDisplaySettings(dm, CDS_UPDATEREGISTRY)

                        Select Case iRet
                            Case DISP_CHANGE_SUCCESSFUL
                                If True Then
                                    Exit Select
                                End If
                            Case DISP_CHANGE_RESTART
                                If True Then
                                    Exit Select
                                End If
                            Case Else
                                If True Then
                                    Exit Select
                                End If
                        End Select
                    End If
                End If
            Catch
            End Try
        End Sub

    End Class

End Class
