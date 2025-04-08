Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics.Win.UltraWinGrid.ExcelExport
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop

'stbMain.Panels("KeyUsuario").Text = String.Concat("  Usuario : ", User_Sistema)'

Public Class FrmValidaProduccion
#Region "Declarar Variables"
    Dim Obj_Excel As Object
    Dim Obj_Libro As Object
    Dim Obj_Hoja As Object
    Dim Fila As Integer = 0
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Public ConceptoSeleccionado As String
    Public gettingUser As String
    Public filtroDescripcion As String = String.Empty
#End Region

    Private Sub FrmValidaProduccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtinicio.Value = "01/" + Now.Date.Month.ToString + "/" + Now.Date.Year.ToString
        dtfin.Value = Now.Date
        Procesar()
    End Sub
    Sub Procesar()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad.FechaInicio = dtinicio.Value
        objEntidad.FechaTerminacion = dtfin.Value
        objEntidad.liberado = IIf(chkliberado.Checked = True, 1, 0)
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.ListarValidaProduccion(objEntidad)
        gridproducto.DataSource = dtDatos

        If User_Sistema = "JRUIZ" Then
            gridproducto.DisplayLayout.Bands(0).Columns(12).CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        Else
            gridproducto.DisplayLayout.Bands(0).Columns(12).CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled
        End If


    End Sub
    Sub Grabar()
        gridproducto.PerformAction(ExitEditMode)
        If MsgBox("Desea grabar los datos?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
        lblmensaje.Visible = True
        lblmensaje.Refresh()
        For i As Int32 = 0 To gridproducto.Rows.Count - 1
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._billete = gridproducto.Rows(i).Cells("NUM_DOC").Value
            objEntidad._cod_prod = gridproducto.Rows(i).Cells("COD_PRODPDC").Value

            objEntidad.Comentarios = gridproducto.Rows(i).Cells(12).Value.ToString()


            Dim validacion As Int32 = 0
            If gridproducto.Rows(i).Cells("VALIDACION").Value = True Then
                validacion = 1
            Else
                validacion = 2
            End If

            If validacion = 2 Then
                gridproducto.Rows(i).Cells(12).Value = String.Empty
            Else
                objEntidad.Comentarios = gridproducto.Rows(i).Cells(12).Value.ToString()
            End If

            objEntidad.validacion_ = validacion
            objEntidad.Usuario = User_Sistema
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.MantValidaProduccion(objEntidad)
        Next
        MsgBox("Datos grabados correctamente", MsgBoxStyle.Information, "Sistema")
        Procesar()
        lblmensaje.Visible = False
        lblmensaje.Refresh()
    End Sub

    Sub Excel()


        Dim objNegocio As New NGContratista
        Dim objEntidad As New ETContratista


        objEntidad.FechaInicio = dtinicio.Value
        objEntidad.FechaTerminacion = dtfin.Value
        objEntidad.liberado = IIf(chkliberado.Checked = True, 1, 0)


        Dim dtDatos As New DataTable
        dtDatos = objNegocio.ListarValidaProduccion(objEntidad)


        ExportarDataTableAExcel(dtDatos, objEntidad.FechaInicio, objEntidad.FechaTerminacion)





    End Sub



    ''EXPORTAR EXCEL
    Private Sub ExportarDataTableAExcel(ByVal dt As DataTable, ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime)

        Dim xlApp As Object = CreateObject("Excel.Application")
        Dim xlWorkBook As Object = xlApp.Workbooks.Add
        Dim xlWorkSheet As Object = xlWorkBook.Sheets(1)


        xlWorkSheet.Cells(1, 1) = "REPORTE DE VALIDACION DE PRODUCTOS TERMINADOS"
        xlWorkSheet.Cells(2, 1) = "Fecha de Inicio: " & fechaInicio.ToString("dd/MM/yyyy")
        xlWorkSheet.Cells(3, 1) = "Fecha de Terminación: " & fechaFin.ToString("dd/MM/yyyy")

        xlWorkSheet.Cells(1, 1).Font.Bold = True
        xlWorkSheet.Cells(1, 1).Font.Size = 18

        xlWorkSheet.Cells(2, 1).Font.Bold = True
        xlWorkSheet.Cells(2, 1).Font.Size = 16

        xlWorkSheet.Cells(3, 1).Font.Bold = True
        xlWorkSheet.Cells(3, 1).Font.Size = 16



        Dim i As Integer
        For i = 1 To dt.Columns.Count
            xlWorkSheet.Cells(5, i) = dt.Columns(i - 1).ColumnName
        Next

        With xlWorkSheet.Range("A5:R5")
            .Font.Bold = True
            .Font.Size = 12
            .HorizontalAlignment = -4108 ' xlCente
        End With

        ''With xlWorkSheet.Columns("C")
        ''.WrapText = True
        ''End With

        With xlWorkSheet.Range("A6:B" & (dt.Rows.Count + 5))
            .HorizontalAlignment = -4108 ' xlCenter
            .Font.Name = "Aptos Display"
        End With

        With xlWorkSheet.Range("D6:R" & (dt.Rows.Count + 5))

            .HorizontalAlignment = -4108 ' xlCenter
            .Font.Name = "Aptos Display"

        End With

        Dim j As Integer
        For i = 0 To dt.Rows.Count - 1
            For j = 0 To dt.Columns.Count - 1
                xlWorkSheet.Cells(i + 6, j + 1) = dt.Rows(i)(j).ToString()
            Next
        Next


        For i = 1 To dt.Columns.Count
            xlWorkSheet.Columns(i).AutoFit()

            If xlWorkSheet.Columns(i).ColumnWidth > 30 Then
                xlWorkSheet.Columns(i).ColumnWidth = 30
            End If

        Next

        xlWorkSheet.Columns("C").ColumnWidth = 40

        xlApp.Visible = True




    End Sub



    Private Sub chktodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chktodos.CheckedChanged
        Try
            For i As Int32 = 0 To gridproducto.Rows.Count - 1
                gridproducto.Rows(i).Cells("VALIDACION").Value = IIf(chktodos.Checked = True, 1, 0)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridproducto_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridproducto.InitializeLayout

    End Sub

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged

    End Sub

    Private Sub Source1_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Source1.CurrentChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MOvta.Click
        Dim band = gridproducto.DisplayLayout.Bands(0)


        Dim ocultar As Boolean = Not band.Columns(20).Hidden

        band.Columns(18).Hidden = ocultar
        band.Columns(19).Hidden = ocultar
        band.Columns(20).Hidden = ocultar



        If ocultar Then
            MOvta.Text = "Mostrar/Ocultar Columnas"
        End If
        MOvta.Text = "Mostrar/Ocultar Columnas"




    End Sub
End Class


