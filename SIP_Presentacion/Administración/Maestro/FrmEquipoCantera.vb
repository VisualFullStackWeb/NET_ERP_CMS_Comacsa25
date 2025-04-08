Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Public Class FrmEquipoCantera
    Dim dtDetalle As DataTable
    Dim flgtrans As Int32
    Dim tipomov As String
    Dim objEntidad As ETContratista
    Dim objNegocio As NGContratista
#Region "Variables"
    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private ListModulos As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Dim Ope = 1
#End Region

    Private Sub FrmEquipoCantera_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        dtDetalle = New DataTable
        If dtDetalle.Columns.Count <= 1 Then
            creaTablaDetalle()
        End If
    End Sub

    Sub creaTablaDetalle()
        dtDetalle.Columns.Add("COD_EQUIPO")
        dtDetalle.Columns.Add("EQUIPO")
        dtDetalle.Columns.Add("CODCANTERA")
        dtDetalle.Columns.Add("CANTERA")
        dtDetalle.Columns.Add("ESTADO")
        dtDetalle.Columns.Add("MODELO")
        dtDetalle.Columns.Add("SERIE")
        dtDetalle.Columns.Add("CONTRATISTA")
        dtDetalle.Columns.Add("RESPONSABLE")
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            If cmbMes.SelectedIndex < 0 Then Exit Sub
            CargarDatos()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarDatos()
        Try
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._ayo = txtAño.Value
            objEntidad._mes = cmbMes.Value
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.ListarEquipoCantera(objEntidad)
            Call CargarUltraGridxBinding(gridDetalle, Source1, dtDatos)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try
    End Sub

    Function ValidarExcel(ByVal RUTA As String) As Boolean
        Cursor = Cursors.WaitCursor
        lblmensaje.Visible = True
        lblmensaje.Text = "Validando datos de libro Excel..."
        lblmensaje.Refresh()
        Dim ObjExcel As Microsoft.Office.Interop.Excel.Application
        Dim ObjW As Microsoft.Office.Interop.Excel.Workbook
        ObjExcel = New Microsoft.Office.Interop.Excel.Application
        ObjW = ObjExcel.Workbooks.Open(RUTA)
        Dim objHojaExcel As Microsoft.Office.Interop.Excel.Worksheet = ObjExcel.Worksheets(1)
        Try
            If objHojaExcel.Range("A1").Value <> "DESCRIPCION" Or objHojaExcel.Range("B1").Value <> "ESTADO" Then
                Return False
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ObjW.Close()
            ObjW = Nothing
            ObjExcel.Quit()
            Runtime.InteropServices.Marshal.ReleaseComObject(ObjExcel)
            ObjExcel = Nothing
        End Try
    End Function

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Try
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._ayo = txtAño.Value
            objEntidad._mes = cmbMes.Value
            Dim dtDatos As New DataTable
            dtDatos = objNegocio.ListarEquipoCantera(objEntidad)
            If dtDatos.Rows.Count > 0 Then
                If MsgBox("Ya existe una carga de datos para el mes seleccionado." & vbLf & "¿Desea continuar la importación de datos?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No Then Exit Sub
            End If

            OpenFileDialog1.Filter = "Libro de Excel|*.xls;*.xlsx"
            OpenFileDialog1.FileName = String.Empty
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub
            Dim cadenaExcel As String = Me.OpenFileDialog1.FileName
            Cursor = Cursors.WaitCursor

            If Not ValidarExcel(cadenaExcel) Then
                MsgBox("El archivo seleccionado es incorrecto", MsgBoxStyle.Exclamation, msgComacsa)
                Cursor = Cursors.Default
                lblmensaje.Visible = False
                lblmensaje.Refresh()
                Exit Sub
            End If
            Dim cs As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                          "Data Source= " & cadenaExcel & _
                          ";Extended Properties=""Excel 8.0;HDR=YES"""
            Dim oConn As New OleDbConnection(cs)

            Try
                oConn.Open()
                CargarDatos(oConn)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Ocurrió un error")
            Finally
                Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
                Cursor = Cursors.Default
                lblmensaje.Visible = False
                lblmensaje.Refresh()
                oConn.Close()
                oConn.Dispose()
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub cargarDatos(ByVal oConn As OleDbConnection)
        Dim Ls_datos = New List(Of ETProveedorFiscalizado)
        Dim DtSet As New System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        MyCommand = New System.Data.OleDb.OleDbDataAdapter _
        ("select * from [EQUIPO$A1:J1000]", oConn)
        MyCommand.TableMappings.Add("Table", "Tabla")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)
        lblmensaje.Text = "Cargando datos de libro Excel..."
        lblmensaje.Refresh()
        Dim cont As Int32 = 1
        Dim dtDatos As New DataTable
        dtDatos = DtSet.Tables(0)
        dtDetalle.Rows.Clear()
        For i As Int32 = 0 To dtDatos.Rows.Count - 1
            Dim dr As DataRow
            dr = dtDetalle.NewRow
            dr(0) = dtDatos.Rows(i)(2)
            dr(1) = dtDatos.Rows(i)(0)
            dr(2) = dtDatos.Rows(i)(3)
            dr(3) = dtDatos.Rows(i)(4)
            dr(4) = dtDatos.Rows(i)(1)
            dr(5) = dtDatos.Rows(i)(5)
            dr(6) = dtDatos.Rows(i)(6)
            dr(7) = dtDatos.Rows(i)(7)
            dr(8) = dtDatos.Rows(i)(8)
            dtDetalle.Rows.Add(dr)
        Next

        Call CargarUltraGridxBinding(gridDetalle, Source1, dtDetalle)
        'Call CargarUltraGrid(gridDetalle, dtDatos)
        MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
    End Sub

    Sub Grabar()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        objEntidad._ayo = txtAño.Value
        objEntidad._mes = cmbMes.Value
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.ListarEquipoCantera(objEntidad)
        If dtDatos.Rows.Count > 0 Then
            If MsgBox("Ya existe una carga de datos para el mes seleccionado." & vbLf & "¿Desea continuar la carga?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No Then Exit Sub
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._ayo = txtAño.Value
            objEntidad._mes = cmbMes.Value
            objEntidad._usuario = User_Sistema
            Dim dtInserta As New DataTable
            dtInserta = objNegocio.EliminaEquipoCantera(objEntidad)
        End If

        For i As Int32 = 0 To gridDetalle.Rows.Count - 1
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._ayo = txtAño.Value
            objEntidad._mes = cmbMes.Value
            objEntidad._codequipo = gridDetalle.Rows(i).Cells("COD_EQUIPO").Value.ToString.Trim
            objEntidad._codcantera = gridDetalle.Rows(i).Cells("CODCANTERA").Value.ToString.Trim
            objEntidad.Estado = gridDetalle.Rows(i).Cells("ESTADO").Value.ToString.Trim
            objEntidad._modelo = gridDetalle.Rows(i).Cells("MODELO").Value.ToString.Trim
            objEntidad._serie = gridDetalle.Rows(i).Cells("SERIE").Value.ToString.Trim
            objEntidad._contratista = gridDetalle.Rows(i).Cells("CONTRATISTA").Value.ToString.Trim
            objEntidad._responsable = gridDetalle.Rows(i).Cells("RESPONSABLE").Value.ToString.Trim
            objEntidad._usuario = User_Sistema
            Dim dtInserta As New DataTable
            dtInserta = objNegocio.InsertaEquipoCantera(objEntidad)
        Next
        MessageBox.Show("Datos importados correctamente.", "Sistema", MessageBoxButtons.OK)
        cmbMes_ValueChanged(Nothing, Nothing)
    End Sub
End Class