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

Public Class FrmLecturaDron
#Region "Variables"
    Dim objEntidad As ETContratista
    Dim objNegocio As NGContratista

    Dim opcion As String
#End Region
#Region "Funciones Basicas"
    Sub cargarDtg()
        Dim dtDatos As DataTable

        objNegocio = New NGContratista
        objEntidad = New ETContratista
        opcion = "R"

        objEntidad._tipopago = opcion
        objEntidad.YearStr = txtPeriodo.Value.ToString

        dtDatos = objNegocio.ConsultarLecturaDrone(objEntidad)

        GrdConsumo.DataSource = dtDatos

    End Sub

    Function ValidarExcel(ByVal RUTA As String) As Boolean
        Dim ObjExcel As Microsoft.Office.Interop.Excel.Application
        Dim ObjW As Microsoft.Office.Interop.Excel.Workbook
        ObjExcel = New Microsoft.Office.Interop.Excel.Application
        ObjW = ObjExcel.Workbooks.Open(RUTA)
        Try
            If Not ObjW.Sheets(1).Name = "Ruma" Then
                Return False
            End If
            Return True
        Catch ex As Exception
        Finally
            ObjW.Close()
            ObjW = Nothing
            ObjExcel.Quit()
            Runtime.InteropServices.Marshal.ReleaseComObject(ObjExcel)
            ObjExcel = Nothing
        End Try
    End Function
#End Region

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

    Private Sub FrmLecturaDron_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarDtg()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        cargarDtg()
    End Sub

    Private Sub btnImportarLectura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportarLectura.Click
        If MsgBox("Se remplazará la información actual, ¿Desea continuar?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
        OpenFileDialog1.Filter = "Libro de Excel|*.xls;*.xlsx"
        OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.ShowDialog()
        If Me.OpenFileDialog1.CheckFileExists = False Then
            MsgBox("Archivo no existe", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If

        If Me.OpenFileDialog1.FileName.ToString.Trim = "" Then
            Return
        End If

        Dim cadenaExcel As String = Me.OpenFileDialog1.FileName

        Cursor = Cursors.WaitCursor
        If Not ValidarExcel(cadenaExcel) Then
            MsgBox("El archivo seleccionado es incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
            Return
        End If

        Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                      "Data Source= " & cadenaExcel & _
                      ";Extended Properties=""Excel 8.0;HDR=YES"""
        Dim oConn As New OleDbConnection(cs)
        oConn.Open()

        Dim DtSet As System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        MyCommand = New System.Data.OleDb.OleDbDataAdapter _
        ("select * from [Ruma$]", oConn)
        MyCommand.TableMappings.Add("Table", "TablaRuma")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)
        oConn.Close()
        oConn.Dispose()

        objNegocio = New NGContratista
        objEntidad = New ETContratista

        Dim dtDetalle As DataTable

        objEntidad._tipopago = "D"
        objEntidad.YearStr = txtPeriodo.Value.ToString()
        dtDetalle = objNegocio.ConsultarLecturaDrone(objEntidad)

        For Each dr As DataRow In DtSet.Tables("TablaRuma").Rows

            With objEntidad
                ._tipopago = "C"
                .cadena = dr("Cod Ruma")
                .YearStr = txtPeriodo.Value.ToString()

                If Not (dr.IsNull("Enero")) Then .enero = dr("Enero") Else .enero = 0
                If Not (dr.IsNull("Febrero")) Then .febrero = dr("Febrero") Else .febrero = 0
                If Not (dr.IsNull("Marzo")) Then .marzo = dr("Marzo") Else .marzo = 0
                If Not (dr.IsNull("Abril")) Then .abril = dr("Abril") Else .abril = 0
                If Not (dr.IsNull("Mayo")) Then .mayo = dr("Mayo") Else .mayo = 0
                If Not (dr.IsNull("Junio")) Then .junio = dr("Junio") Else .junio = 0
                If Not (dr.IsNull("Julio")) Then .julio = dr("Julio") Else .julio = 0
                If Not (dr.IsNull("Agosto")) Then .agosto = dr("Agosto") Else .agosto = 0
                If Not (dr.IsNull("Septiembre")) Then .septiembre = dr("Septiembre") Else .septiembre = 0
                If Not (dr.IsNull("Octubre")) Then .octubre = dr("Octubre") Else .octubre = 0
                If Not (dr.IsNull("Noviembre")) Then .noviembre = dr("Noviembre") Else .noviembre = 0
                If Not (dr.IsNull("Diciembre")) Then .diciembre = dr("Diciembre") Else .diciembre = 0

                .Usuario = User_Sistema
                .Fecha = Date.Now
            End With

            dtDetalle = objNegocio.ConsultarLecturaDrone(objEntidad)

        Next
        MsgBox("Información actualizada correctamente", MsgBoxStyle.OkOnly, msgComacsa)
        cargarDtg()

    End Sub
End Class