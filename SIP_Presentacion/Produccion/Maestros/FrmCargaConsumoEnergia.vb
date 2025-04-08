Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Public Class FrmCargaConsumoEnergia
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

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Try
            OpenFileDialog1.Filter = "Libro de Excel|*.xls;*.xlsx"
            OpenFileDialog1.FileName = String.Empty
            OpenFileDialog1.ShowDialog()
            If OpenFileDialog1.FileName = "" Then Exit Sub
            Dim cadenaExcel As String = Me.OpenFileDialog1.FileName
            Cursor = Cursors.WaitCursor
            lblmensaje.Visible = True
            lblmensaje.Text = "Validando datos de libro Excel..."
            lblmensaje.Refresh()
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
                cargarDatos(oConn, "PLANTA DE CEMENTO BLANCO")
                cargarDatos(oConn, "PLANTA DE CAL")
                cargarDatos(oConn, "PLANTA DE INFANTAS")
                cargarDatos(oConn, "PLANTA LOS HORNOS")
                Procesar()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Ocurrió un error")
                'MsgBox("Archivo incorrecto a ya se encuentra utilizado", MsgBoxStyle.Critical, "Comacsa")
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

    Sub Procesar()
        Try
            objEntidad = New ETContratista
            objNegocio = New NGContratista

            Dim dtResultado As New DataTable
            Dim mes As Int32 = cmbMes.Value
            Dim ayo As Int32 = txtAño.Value
            objEntidad = New ETContratista
            objNegocio = New NGContratista
            objEntidad._ayo = ayo
            objEntidad._mes = mes
            dtResultado = objNegocio.LISTA_ENERGIA_ELECTRICA(objEntidad)
            Call CargarUltraGrid(gridDetalle, dtResultado)
        Catch ex As Exception

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
        Try
            If Not ObjW.Sheets(1).Name.ToString.ToUpper.Trim = "PLANTA DE CEMENTO BLANCO" Then
                Return False
            End If
            If Not ObjW.Sheets(2).Name.ToString.ToUpper.Trim = "PLANTA DE CAL" Then
                Return False
            End If
            If Not ObjW.Sheets(3).Name.ToString.ToUpper.Trim = "PLANTA DE INFANTAS" Then
                Return False
            End If
            If Not ObjW.Sheets(4).Name.ToString.ToUpper.Trim = "PLANTA LOS HORNOS" Then
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

    Sub cargarDatos(ByVal oConn As OleDbConnection, ByVal hoja As String)

        Dim n_ini As Int32 = 5

        Dim n_col_ini As Int32 = 1
        Dim n_col_fin As Int32 = 5

        Select Case hoja
            Case "PLANTA DE CEMENTO BLANCO"
                n_col_fin = 4
            Case "PLANTA DE CAL"
                n_col_fin = 3
            Case "PLANTA DE INFANTAS"
                n_col_fin = 38
            Case Else
                n_col_fin = 4
        End Select
        Try

            Dim Ls_datos = New List(Of ETProveedorFiscalizado)
            Dim DtSet As New System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyCommand = New System.Data.OleDb.OleDbDataAdapter _
            ("select * from [" & hoja & "$A1:AM37]", oConn)
            MyCommand.TableMappings.Add("Table", "Tabla")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            lblmensaje.Text = "Cargando datos de libro Excel..."
            lblmensaje.Refresh()
            Dim cont As Int32 = 1
            Dim codtipoequipo As String = ""
            Dim tipoequipo As String = ""
            objEntidad = New ETContratista
            objNegocio = New NGContratista

            Dim dtDatos As New DataTable
            dtDatos = DtSet.Tables(0)

            Dim cod_equipo As String = ""
            Dim equipo As String = ""
            Dim valor As Double = 0
            Dim dia As String = ""
            Dim mes As Int32 = cmbMes.Value
            Dim ayo As Int32 = txtAño.Value
            'Dim dia As Int32 = 0
            Dim dtResultado As New DataTable
            For fila As Int32 = n_ini To dtDatos.Rows.Count - 1
                For col As Int32 = n_col_ini To n_col_fin
                    cod_equipo = dtDatos.Rows(2)(col).ToString.Trim
                    equipo = dtDatos.Rows(3)(col).ToString.Trim
                    dia = Convert.ToInt32(dtDatos.Rows(fila)(0).ToString.Trim)
                    If dtDatos.Rows(fila)(col).ToString.Trim = "" Then
                        valor = 0
                    Else
                        valor = dtDatos.Rows(fila)(col)
                    End If
                    dtResultado = New DataTable
                    objEntidad = New ETContratista
                    objNegocio = New NGContratista
                    objEntidad._codequipo = cod_equipo
                    objEntidad._ayo = ayo
                    objEntidad._mes = mes
                    objEntidad._dia = dia
                    objEntidad._toneladas = valor
                    objEntidad._descripcion = hoja
                    objEntidad._usuario = User_Sistema

                    dtResultado = objNegocio.CARGA_ENERGIA_ELECTRICA(objEntidad)
                    dtResultado = objNegocio.CARGA_ENERGIA_ELECTRICA_MENSUAL(objEntidad)
                Next
            Next
            'Call CargarUltraGrid(gridDetalle, dtDetalle)
            MessageBox.Show("Datos importados correctamente " & hoja.ToString.Trim.ToUpper, "Sistema", MessageBoxButtons.OK)
            cmbMes.ReadOnly = True
            txtAño.Enabled = False

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmCargaConsumoEnergia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAño.Value = Year(Now.Date)
        cmbMes.Value = Month(Now.Date)
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            Procesar()
        Catch ex As Exception

        End Try
    End Sub
End Class