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
Imports System.Drawing.Printing

Public Class FrmImpEtiquetaQR
#Region "Declarar Variables"


    Dim _objNegocio_ As NGProducto = Nothing
    Dim _objEntidad_ As ETProducto = Nothing
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
    Public filtroDescripcion As String = ""

    Dim path As String
#End Region

    Private Sub FrmImpEtiquetaQR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        path = Application.StartupPath
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        _objEntidad_.CodAlmacen = "28"
        _objEntidad_.csStock = "100"
        Dim dt As New DataTable
        dt = _objNegocio_.ListarProductosImp(_objEntidad_)
        gridproducto.DataSource = dt
    End Sub

    Sub ImprimirEtiquetaQR(ByVal cod_prod As String, ByVal producto As String, ByVal unidad As String, ByVal ubicacion As String, ByVal almacen As String)

        Dim archivo As String
        Dim fs As FileStream

        archivo = "\" & cod_prod & "QR.txt"


        Try
            If Directory.Exists(path) Then

                ':::Si la carpeta existe creamos o sobreescribios el archivo txt
                fs = File.Create(path & archivo)
                fs.Close()
                MsgBox("Archivo creado correctamente", MsgBoxStyle.Information, "Comacsa")
            Else
                ':::Si la carpeta no existe la creamos
                Directory.CreateDirectory(path)

                ':::Una vez creada la carpeta creamos o sobreescribios el archivo txt
                fs = File.Create(path & archivo)
                fs.Close()

            End If


            Dim escribir As New StreamWriter(path & archivo)
            'Dim leer As New StreamReader(path & archivo)

            Try
                ':::Escribimos una linea en nuestro archivo TXT con el formato que este separado por coma (,)
                escribir.WriteLine("CT~~CD,~CC^~CT~")
                escribir.WriteLine("^XA")
                escribir.WriteLine("~TA000")
                escribir.WriteLine("~JSN")
                escribir.WriteLine("^LT0")
                escribir.WriteLine("^MNW")
                escribir.WriteLine("^MTT")
                escribir.WriteLine("^PON")
                escribir.WriteLine("^PMN")
                escribir.WriteLine("^LH0,0")
                escribir.WriteLine("^JMA")
                escribir.WriteLine("^PR6,6")
                escribir.WriteLine("~SD15")
                escribir.WriteLine("^JUS")
                escribir.WriteLine("^LRN")
                escribir.WriteLine("^CI27")
                escribir.WriteLine("^PA0,1,1,0")
                escribir.WriteLine("^XZ")
                escribir.WriteLine("^XA")
                escribir.WriteLine("^MMT")
                escribir.WriteLine("^PW831")
                escribir.WriteLine("^LL406")
                escribir.WriteLine("^LS0")
                escribir.WriteLine("^FPH,8^FT27,67^A0N,39,38^FH\^CI28^FDCodigo:^FS^CI27")
                escribir.WriteLine("^FPH,3^FT292,88^A0N,79,79^FH\^CI28^FD" & cod_prod & "^FS^CI27")
                escribir.WriteLine("^FPH,3^FT27,123^A0N,39,38^FH\^CI28^FDArticulo:^FS^CI27")
                escribir.WriteLine("^FT24,180^A0N,39,23^FH\^CI28^FD" & producto & "^FS^CI27")
                'escribir.WriteLine("^FPH,3^FT22,172^A0N,35,35^FH\^CI28^FD" & producto & "^FS^CI27")
                escribir.WriteLine("^FPH,3^FT24,241^A0N,39,38^FH\^CI28^FDU/M:^FS^CI27")
                escribir.WriteLine("^FPH,3^FT292,245^A0N,37,38^FH\^CI28^FD" & unidad & "^FS^CI27")
                escribir.WriteLine("^FPH,3^FT22,298^A0N,39,38^FH\^CI28^FDUbicacion:^FS^CI27")
                escribir.WriteLine("^FT292,302^A0N,37,38^FH\^CI28^FD" & ubicacion & "^FS^CI27")
                escribir.WriteLine("^FT24,349^A0N,34,33^FH\^CI28^FDAlmacen:^FS^CI27")
                escribir.WriteLine("^FT292,356^A0N,37,38^FH\^CI28^FD" & almacen & "^FS^CI27")
                escribir.WriteLine("^FT591,402^BQN,2,8")
                escribir.WriteLine("^FH\^FDLA," & cod_prod & "\0D\0A^FS")
                escribir.WriteLine("^PQ1,0,1,Y")
                escribir.WriteLine("^XZ")
                escribir.Close()

                Try
                    Dim printername As String

                    Dim oPS As New System.Drawing.Printing.PrinterSettings
                    printername = oPS.PrinterName
                    Dim Proc As New System.Diagnostics.Process

                    Proc.EnableRaisingEvents = True
                    Proc.StartInfo.FileName = path & archivo
                    Proc.StartInfo.Arguments = Chr(34) + printername + Chr(34)
                    Proc.StartInfo.Verb = "Print"
                    Proc.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
                    Proc.StartInfo.CreateNoWindow = True
                    Proc.Start()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


            Catch ex As Exception
                MsgBox("Se presento un problema al escribir en el archivo: " & ex.Message, MsgBoxStyle.Critical, "Comacsa")
            End Try

        Catch ex As Exception
            MsgBox("Se presento un problema al momento de crear el archivo: " & ex.Message, MsgBoxStyle.Critical, "Comacsa")
        End Try

    End Sub


    Private Sub gridproducto_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridproducto.CellChange

    End Sub

    Private Sub rbtProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtProducto.CheckedChanged
        If rbtProducto.Checked = True Then
            rbtListaProducto.Checked = False
            cboProductos.ValueMember = -1

            txtCodProd.Visible = True
            cboProductos.Visible = False
        End If
    End Sub

    Private Sub rbtListaProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtListaProducto.CheckedChanged
        If rbtListaProducto.Checked = True Then
            rbtProducto.Checked = False
            txtCodProd.Text = ""

            cboProductos.Visible = True
            txtCodProd.Visible = False
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim cod_prod As String
        Dim producto As String
        Dim unidad As String
        Dim ubicacion As String
        Dim almacen As String

        For i As Int32 = 0 To gridproducto.Rows.Count - 1
            Dim a As String
            a = i.ToString()
            a = gridproducto.Rows(i).Cells("Accion").Value.ToString()

            If gridproducto.Rows(i).Cells("Accion").Value = 1 Then

                cod_prod = gridproducto.Rows(i).Cells("Cod_prod").Value.ToString
                producto = gridproducto.Rows(i).Cells("Descrip").Value.ToString
                unidad = gridproducto.Rows(i).Cells("Unidad").Value.ToString
                ubicacion = gridproducto.Rows(i).Cells("Ubicacion").Value.ToString
                almacen = gridproducto.Rows(i).Cells("Almacen").Value.ToString
                ImprimirEtiquetaQR(cod_prod, producto, unidad, ubicacion, almacen)

            End If
        Next
        MsgBox("Archivo generado correctamente", MsgBoxStyle.Information, "Comacsa")

    End Sub

    Private Sub chk_ListarSinStock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_ListarSinStock.CheckedChanged

        path = Application.StartupPath
        _objNegocio_ = New NGProducto
        _objEntidad_ = New ETProducto
        _objEntidad_.CodAlmacen = "28"
        If chk_ListarSinStock.Checked = True Then
            _objEntidad_.csStock = "111"
        Else
            _objEntidad_.csStock = "100"
        End If

        Dim dt As New DataTable
        dt = _objNegocio_.ListarProductosImp(_objEntidad_)
        gridproducto.DataSource = dt

    End Sub
End Class
