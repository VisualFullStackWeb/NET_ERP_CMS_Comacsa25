Imports System
Imports System.IO
Imports Microsoft.Office.Interop.Excel
Namespace Common

    Public Class ImportarExcel
        Public resumenHojas As New Dictionary(Of String, Integer)

        Public Function importarDatosCeldas(ByVal pathFile As String, ByVal nombreColumna As String, ByVal columnaIndex As Integer, ByVal filaInicioNombreColumna As Integer, _
                                                Optional ByVal sumarfilaInicio As Integer = 1) As List(Of Libro)

            Dim valueLista As New List(Of Libro)

            Dim exlApp As Application = New Application()
            Dim libroExcel As Workbook
            'Dim hojaExcel As Worksheet
            Dim miRango As Range

            Try

                libroExcel = exlApp.Workbooks.Open(pathFile)
                Dim listaLibro As New List(Of Libro)

                For Each hoja As Worksheet In libroExcel.Worksheets

                    Dim nombreHoja As String = hoja.Name.ToUpper
                    Dim contadorReg As Integer = 0
                    Dim valorCelda As String = ""
                    Dim fila As Integer = filaInicioNombreColumna 'celda de inicio
                    Dim columna As Integer = columnaIndex 'columna de inicio
                    miRango = hoja.UsedRange

                    If nombreHoja.Contains("HOJA") = True Then
                        Continue For
                    End If

                    'validar el nombre de la columna con la celda
                    Dim datoCelda As String = ""

                    Try
                        datoCelda = CStr((TryCast(miRango.Cells(fila, columna), Range)).Value2)

                        If nombreColumna.Trim.ToUpper = datoCelda.Trim.ToUpper Then
                            fila = fila + sumarfilaInicio
                        Else
                            Continue For
                        End If
                    Catch ex As Exception
                        Continue For
                    End Try

                    'recorrer los datos de la celda del libro
                    Do
                        datoCelda = CStr((TryCast(miRango.Cells(fila, columna), Range)).Value2)

                        If datoCelda IsNot Nothing Then
                            valorCelda = datoCelda

                            Dim libro As New Libro(hoja.Name, valorCelda)
                            valueLista.Add(libro)
                            contadorReg = contadorReg + 1
                        Else
                            valorCelda = ""
                        End If

                        fila = fila + 1
                    Loop While valorCelda.Trim <> ""

                    resumenHojas.Add(nombreHoja, contadorReg)
                Next

                libroExcel.Close(False)
                exlApp.Quit()

            Catch e As Exception
                MessageBox.Show("Error " & e.Message)
            End Try

            Return valueLista

        End Function
        Public Class Libro
            Private _nombreHoja As String = ""
            Private _empleado As String = ""
            Public Sub New(ByVal nombreHoja As String, ByVal empleado As String)

                Me.nombreHoja = nombreHoja
                Me.valorCelda = empleado

            End Sub
            Public Property nombreHoja() As String
                Get
                    Return _nombreHoja
                End Get
                Set(ByVal value As String)
                    _nombreHoja = value
                End Set
            End Property
            Public Property valorCelda() As String
                Get
                    Return _empleado
                End Get
                Set(ByVal value As String)
                    _empleado = value
                End Set
            End Property
        End Class
    End Class
End Namespace