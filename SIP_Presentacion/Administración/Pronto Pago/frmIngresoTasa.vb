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
Public Class frmIngresoTasa
#Region "Declarar Variables"
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
    Public filtroDescripcion As String = String.Empty
#End Region
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto

    Private Sub frmIngresoTasa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Procesar()
    End Sub
    Sub Procesar()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarTransportista()
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridMotivos, Source1, Ls_Entrega)
    End Sub
    Sub limpiar()
        txtcodprov.Clear()
        txtproveedor.Clear()
        txttea.Clear()
        txtted.Clear()
    End Sub
    Private Sub gridMotivos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridMotivos.DoubleClickRow
        Try
            Tab1.Tabs("T02").Selected = True
            limpiar()
            txtcodprov.Text = gridMotivos.ActiveRow.Cells("codmotivoDetalle").Value
            txtproveedor.Text = gridMotivos.ActiveRow.Cells("motivoDetalle").Value
            Tasa_Proveedor()
            txttea.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridMotivos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridMotivos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "codmotivoDetalle" OrElse uColumn.Key = "motivoDetalle" OrElse uColumn.Key = "nroruc") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub txttea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttea.KeyDown
        If e.KeyData = Keys.Return Then
            Dim TEA As Double = txttea.Text
            Dim TED As Double = 0
            TED = Math.Pow(1 + (TEA / 100), (1 / 360)) - 1
            TED = TED * 100
            'MsgBox(Math.Round(TED, 3))
            txttea.Text = CDbl(txttea.Text).ToString("##0.000")
            txtted.Text = Math.Round(TED, 3)
            '=(1.15)^(1/360)-1
        End If
    End Sub

    Sub Tasa_Proveedor()
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        _objEntidad.CodTransportista = txtcodprov.Text
        Dim dtDatos As New DataTable
        dtDatos = _objNegocio.Tasa_Proveedor(_objEntidad)
        If dtDatos.Rows.Count > 0 Then
            txttea.Text = dtDatos.Rows(0)("TEA")
            txtted.Text = dtDatos.Rows(0)("TED")
        Else
            txttea.Text = "0.000"
            txtted.Text = "0.000"
        End If
    End Sub

    Sub Grabar()
        Try
            If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub

            Dim dtValidacion As New DataTable
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto

            If MsgBox("¿Seguro desea guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto

            _objEntidad.CodTransportista = txtcodprov.Text
            _objEntidad.tea = txttea.Text
            _objEntidad.ted = txtted.Text
            _objEntidad.Usuario = User_Sistema
            Dim resul As String = ""
            resul = _objNegocio.Ingreso_Tasa(_objEntidad)
            If resul = "OK" Then
                MsgBox("Se guardaron correctamente los datos", MsgBoxStyle.Information, msgComacsa)
                'Procesar()
                limpiar()
                Tab1.Tabs("T01").Selected = True
            Else
                MsgBox("Se produjo un error al grabar", MsgBoxStyle.Information, msgComacsa)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Eliminar()
        Try
            If Tab1.Tabs("T01").Selected = Boolean.TrueString Then Exit Sub
            Dim dtValidacion As New DataTable
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            If MsgBox("¿Seguro desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.CodTransportista = txtcodprov.Text
            _objEntidad.tea = 0
            _objEntidad.ted = 0
            _objEntidad.Usuario = User_Sistema
            Dim resul As String = ""
            resul = _objNegocio.Ingreso_Tasa(_objEntidad)
            If resul = "OK" Then
                MsgBox("Se elimino el registro correctamente", MsgBoxStyle.Information, msgComacsa)
                'Procesar()
                limpiar()
                Tab1.Tabs("T01").Selected = True
            Else
                MsgBox("Se produjo un error al elminar", MsgBoxStyle.Information, msgComacsa)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtcodprov_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodprov.KeyDown
        If e.KeyData = Keys.Return Then
            'Entidad.Contratista = New ETContratista
            'Negocio.NContratista = New NGContratista
            'Entidad.MyLista = New ETMyLista
            'Entidad.Contratista.Usuario = User_Sistema
            'Entidad.Contratista._codprov = txtcodprov.Text
            'Dim dtDatos As New DataTable
            'dtDatos = Negocio.NContratista.Listar_PRO_Prov_Codigo(Entidad.Contratista)
            'If dtDatos.Rows.Count > 0 Then
            '    txtcodprov.Text = dtDatos.Rows(0)("COD_PROV")
            '    txtproveedor.Text = dtDatos.Rows(0)("PROVEEDOR")
            'Else
            '    MsgBox("El código no existe", MsgBoxStyle.Exclamation, msgComacsa)
            '    txtproveedor.Clear()
            'End If
            'Procesar()
        End If
    End Sub

    Private Sub txtcodprov_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodprov.ValueChanged

    End Sub
End Class