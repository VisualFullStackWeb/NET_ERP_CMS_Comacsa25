Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb

Public Class FrmListaDiferenciaProducto
#Region "Declarar Variables"
    Dim _objNegocio_ As NGProducto
    Dim _objEntidad_ As ETProducto

    Dim dt As New DataTable
    Dim ETMaestros2 = New ETMaestos2

    Dim Accion As String
    Dim Opcion As Int16
    Dim Sec As String

#End Region

#Region "FuncionesBasicas"


    Sub Limpiar()
        'En Blanco Todo

        TxtBusqueda.Text = ""


    End Sub



    Sub cargarDtg()
        'Cargar Grilla


        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto

        _objEntidad_.Accion = Opcion
        If Opcion <> 2 Then
            Try
                _objEntidad_.Tipo = Convert.ToInt16(TxtBusqueda.Text)
            Catch ex As Exception

                MsgBox("Ingrese solo números para esta busqueda", MsgBoxStyle.Information, msgComacsa)
            End Try
        Else
            _objEntidad_.Tipo = 0
        End If
        
        _objEntidad_.CodCaract = TxtBusqueda.Text


        dt = _objNegocio_.DiferenciaInventario(_objEntidad_)

        Call CargarUltraGridxBinding(grdProductos, Source1, dt)

    End Sub

#End Region

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Private Sub FrmActivaEmpleados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Limpiar()
        Opcion = 1
        'cargarDtg()
    End Sub


    Private Sub grdEmpleados_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdProductos.DoubleClickRow

    End Sub

    Private Sub rbtFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtNroInventario.CheckedChanged
        If rbtNroInventario.Checked = True Then
            btnDobleConteo.Checked = False
            rbtFila.Checked = False

            TxtBusqueda.Text = ""

            Opcion = 1
        End If
    End Sub

    Private Sub rbtPlaCod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtFila.CheckedChanged
        If rbtFila.Checked = True Then
            btnDobleConteo.Checked = False
            rbtNroInventario.Checked = False

            TxtBusqueda.Text = ""

            Opcion = 2
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        cargarDtg()
    End Sub

    Private Sub TxtBusqueda_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBusqueda.ValueChanged

    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        If dt.Rows.Count <= 0 Then
            Exit Sub
        End If
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            exLibro = exApp.Workbooks.Add()
            exHoja = exLibro.Worksheets.Add()
            Dim nfila As Integer

            exHoja.Cells.Item(1, 1) = "Nro Inventario"
            exHoja.Cells.Item(1, 2) = "Ubicación"
            exHoja.Cells.Item(1, 3) = "Codigo"
            exHoja.Cells.Item(1, 4) = "Descripción"
            exHoja.Cells.Item(1, 5) = "Stock"
            exHoja.Cells.Item(1, 6) = "Cantidad"
            exHoja.Cells.Item(1, 7) = "Diferencia"
            exHoja.Cells.Item(1, 8) = "Usuario Registro"
            nfila = 2
            With exHoja
                .Activate()
                For i As Int16 = 0 To grdProductos.Rows.Count - 1
                    .Range("A" & nfila + i).Value = dt.Rows(i)("NroInventario")
                    .Range("B" & nfila + i).Value = dt.Rows(i)("ubicacion")
                    .Range("C" & nfila + i).Value = dt.Rows(i)("Cod_Prod")
                    .Range("D" & nfila + i).Value = dt.Rows(i)("Descrip")
                    .Range("E" & nfila + i).Value = dt.Rows(i)("Stock")
                    .Range("F" & nfila + i).Value = dt.Rows(i)("Cantidad")
                    .Range("G" & nfila + i).Value = dt.Rows(i)("Diferencia")
                    .Range("H" & nfila + i).Value = dt.Rows(i)("UsuarioRegistro")
                Next
            End With
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.HorizontalAlignment = 3
            exHoja.Columns.AutoFit()
            exHoja.Columns.HorizontalAlignment = 2
            exApp.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar Excel")
        End Try

    End Sub

    Private Sub btnDobleConteo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDobleConteo.CheckedChanged
        If btnDobleConteo.Checked = True Then
            rbtNroInventario.Checked = False
            rbtFila.Checked = False

            TxtBusqueda.Text = ""

            Opcion = 3
        End If
    End Sub
End Class