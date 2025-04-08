Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmMPrecioCombustible
#Region "Variables"
    Private Tipo As Int16 = 0
    Private Ls_Combustible As List(Of ETCanteraCosteo) = Nothing
    Public Ls_Permisos As New List(Of Integer)
#End Region
    Public Sub Nuevo()
        Tipo = Operacion.Nuevo
        Call Controles(Boolean.FalseString)
        Call Limpiar()
        Tab1.Tabs("T02").Selected = Boolean.TrueString
    End Sub
    Sub Controles(ByVal xBol As Boolean)
        txtid.ReadOnly = Not ((Not xBol) AndAlso (Tipo = Operacion.Nuevo))
        'txtcodmaterial.ReadOnly = xBol
        dtFecha.ReadOnly = xBol
        cboTipo.ReadOnly = xBol
        cmbMes.ReadOnly = xBol
        txtAño.ReadOnly = xBol
    End Sub
    Sub Limpiar()
        txtid.Value = String.Empty
        txtcodmaterial.Value = String.Empty
        txtmaterial.Value = String.Empty
        txtprecio.Value = 0
        cboTipo.Value = ""
        cmbMes.SelectedIndex = -1
        txtAño.Value = Convert.ToInt32(Year(Now.Date))
        txtAño.Focus()
        txtcodcantera.Value = String.Empty
        txtcantera.Value = String.Empty
        'txtAño.Value = Now.Date.Year
        'Call Iniciar_Detalle_Cantera()
    End Sub
    Sub buscar()
        'If String.IsNullOrEmpty(txtcodmaterial.Text) Then
        Dim Combustible As New FrmListarProductos

        If cboTipo.Value = "C" Then
            xFormulario = "Cantera_Combustible"
        Else
            xFormulario = "Cantera_Explosivo"
        End If
        If txtcodmaterial.Focused = True Then
            Combustible.ShowDialog()
            txtcodmaterial.Text = Trim(Combustible.CODIGO & "")
            txtmaterial.Text = Trim(Combustible.DESCRIPCION & "")
            txtunidad.Text = Trim(Combustible.UNIDADMEDIDA & "")
            Combustible = Nothing
            xFormulario = String.Empty
            txtprecio.SelectAll()
        Else
            Dim Cantera As New FrmListarCantera
            Cantera.ShowDialog()
            txtcodcantera.Text = Trim(Cantera.CODIGO & "")
            txtcantera.Text = Trim(Cantera.CANTERA & "")
            Cantera = Nothing
            xFormulario = String.Empty
            'Txt4.SelectAll()
            'Call Tipo_Equipo()
        End If

        Return
        'End If
    End Sub

    Private Sub cboTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.ValueChanged
        Try
            txtcodmaterial.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbMes_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMes.ValueChanged
        Try
            cboTipo.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FrmMPrecioCombustible_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated


        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub FrmMPrecioCombustible_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call ListarCia(Cia)
        CargaDatos()
        Limpiar()
    End Sub

    Sub CargaDatos()

        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.MyLista = New ETMyLista

        With Entidad.CanteraCosteo
            .CodCia = Companhia
        End With

        Entidad.MyLista = Negocio.CanteraCosteo.ListarPrecioCombustibleExplosivo(Entidad.CanteraCosteo)

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Combustible = New List(Of ETCanteraCosteo)
        Ls_Combustible = Entidad.MyLista.Ls_CanteraCosteo

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Combustible)

    End Sub

    Private Sub Grid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow
        Try
            Tab1.Tabs("T02").Selected = Boolean.TrueString
            Dim tipo As String = Grid1.ActiveRow.Cells("NombreTipo").Value
            txtAño.Value = Grid1.ActiveRow.Cells("Ano").Value
            cmbMes.Value = Grid1.ActiveRow.Cells("Mes").Value
            cboTipo.Value = IIf(tipo = "COMBUSTIBLE", "C", "E")
            txtid.Value = Grid1.ActiveRow.Cells("ID").Value
            txtcodmaterial.Value = Grid1.ActiveRow.Cells("CodProd").Value
            txtmaterial.Value = Grid1.ActiveRow.Cells("Descripcion").Value
            txtunidad.Value = Grid1.ActiveRow.Cells("UM").Value
            txtprecio.Value = Grid1.ActiveRow.Cells("Importe").Value
            txtcodcantera.Value = Grid1.ActiveRow.Cells("CodigoCantera").Value
            txtcantera.Value = Grid1.ActiveRow.Cells("Cantera").Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Ano" Or uColumn.Key = "NombreTipo" Or _
                        uColumn.Key = "CodProd" Or uColumn.Key = "Descripcion" Or _
                         uColumn.Key = "Mes" Or uColumn.Key = "Cantera" Or _
                        uColumn.Key = "Importe") Then 'uColumn.Key = "ID" Or
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                    uColumn.CellActivation = Activation.ActivateOnly
                End If
            Next
            Return
        End If

    End Sub

    Public Sub Grabar()

        If Tab1.SelectedTab.Key <> "T02" Then Return
        'If Tipo = Operacion.Retorno Then
        '    MessageBox.Show(Mensaje.Seleccion_2, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return
        'End If
        If Not Verificar_Datos() Then
            Return
        End If

        txtcodmaterial.EndUpdate()
        txtmaterial.EndUpdate()
        txtid.EndUpdate()
        txtunidad.EndUpdate()
        txtprecio.EndUpdate()

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto
        '''''''''''''''''''''''''''''''''''''''''''
        With Entidad.CanteraCosteo
            .Opcion = 1
            .CodProd = txtcodmaterial.Value
            .Descripcion = txtmaterial.Value
            .Importe = txtprecio.Value
            .UM = txtunidad.Value
            .User = User_Sistema
            .Fecha = dtFecha.Value
            .Tipo = cboTipo.Value
            .Mes = cmbMes.Value
            .Ano = txtAño.Value
            .Opcion = 1
            .User = User_Sistema
            .CodigoCantera = txtcodcantera.Text
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoPrecioCombustibleExplosivo(Entidad.CanteraCosteo, 1)

        If Entidad.Resultado.Realizo Then
            Call CargaDatos()
            Call Limpiar()
            Tab1.Tabs("T01").Selected = True
            Tipo = Operacion.Retorno
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Public Sub Eliminar()

        If Tab1.SelectedTab.Key <> "T02" Then Return
        'If Tipo = Operacion.Retorno Then
        '    MessageBox.Show(Mensaje.Seleccion_2, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return
        'End If

        If String.IsNullOrEmpty(txtid.Value) Then
            MsgBox("Debe seleccionar registro a eliminar", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If

        If Not Verificar_Datos() Then
            Return
        End If


        txtcodmaterial.EndUpdate()
        txtmaterial.EndUpdate()
        txtid.EndUpdate()
        txtunidad.EndUpdate()
        txtprecio.EndUpdate()

        Entidad.CanteraCosteo = New ETCanteraCosteo
        Negocio.CanteraCosteo = New NGCanteraCosteo
        Entidad.Objecto = New ETObjecto
        '''''''''''''''''''''''''''''''''''''''''''
        With Entidad.CanteraCosteo
            .Opcion = 1
            .CodProd = txtcodmaterial.Value
            .Descripcion = txtmaterial.Value
            .Importe = txtprecio.Value
            .UM = txtunidad.Value
            .User = User_Sistema
            .Fecha = dtFecha.Value
            .Tipo = cboTipo.Value
            .Mes = cmbMes.Value
            .Ano = txtAño.Value
            .Opcion = 3
            .User = User_Sistema
            .CodigoCantera = txtcodcantera.Text
        End With

        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)

        Entidad.Resultado = Negocio.CanteraCosteo.MantenimientoPrecioCombustibleExplosivo(Entidad.CanteraCosteo, 3)

        If Entidad.Resultado.Realizo Then
            Call CargaDatos()
            Call Limpiar()
            Tab1.Tabs("T01").Selected = True
            Tipo = Operacion.Retorno
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub
    Function Verificar_Datos() As Boolean

        Dim lResult As Boolean = Boolean.TrueString

        If cmbMes.SelectedIndex < 0 Then
            MsgBox("Seleccione Mes", MsgBoxStyle.Information, "Comacsa")
            Return Boolean.FalseString
        End If

        If cboTipo.SelectedIndex < 0 Then
            MsgBox("Ingrese Tipo de Material", MsgBoxStyle.Information, "Comacsa")
            Return Boolean.FalseString
        End If

        If String.IsNullOrEmpty(txtcodmaterial.Value) Then
            MsgBox("Ingrese el producto", MsgBoxStyle.Information, "Comacsa")
            Return Boolean.FalseString
        End If
        If String.IsNullOrEmpty(txtcodcantera.Value) Then
            MsgBox("Ingrese Cantera", MsgBoxStyle.Information, "Comacsa")
            Return Boolean.FalseString
        End If

        If String.IsNullOrEmpty(txtprecio.Value) Then
            MsgBox("Ingrese Precio", MsgBoxStyle.Information, "Comacsa")
            Return Boolean.FalseString
        End If

        If Val(txtprecio.Value) <= 0 Then
            MsgBox("Ingrese un Precio Mayor a Cero", MsgBoxStyle.Information, "Comacsa")
            Return Boolean.FalseString
        End If

        Return lResult

    End Function
End Class