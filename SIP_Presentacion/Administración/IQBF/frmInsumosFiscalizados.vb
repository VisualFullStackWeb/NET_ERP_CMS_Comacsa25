Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmInsumosFiscalizados

    Public Ls_Permisos As New List(Of Integer)

    Private Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum

    Private TipoG As State

    Dim Ls_ETInsumosFProductos As List(Of ETInsumosFProductos) = Nothing

    Private Sub IniciarControles()
        LimpiarControles()
        TipoG = State.eView
        HabilitarControles(False, State.eNew)
    End Sub

    Private Sub frmInsumosFiscalizados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        IniciarControles()

        Dim oInsFisN As NGInsumosFiscalizados = Nothing

        Try

            oInsFisN = New NGInsumosFiscalizados
            CboPresentacion.DataSource = oInsFisN.Listar_UnidadesDeMedidas(Companhia)
            CboPresentacion.ValueMember = "cod_maestro2"
            CboPresentacion.DisplayMember = "descrip"

            CboUnidadPre.DataSource = oInsFisN.Listar_UnidadesDeMedidas(Companhia)
            CboUnidadPre.ValueMember = "cod_maestro2"
            CboUnidadPre.DisplayMember = "descrip"

            CargarGrilla()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oInsFisN = Nothing
        End Try
    End Sub

    Private Sub HabilitarControles(ByVal Accion As Boolean, ByVal TipoG As State)
        If Accion Then
            If TipoG = State.eNew Then
                UltraGroupBox1.Enabled = Accion
                TxtCod_SUNAT.Enabled = Accion
            ElseIf TipoG = State.eEdit Then
                If Tab1.Tabs("T02").Selected Then
                    UltraGroupBox1.Enabled = Accion
                ElseIf Tab1.Tabs("T03").Selected Then
                    Navigator2.Enabled = Accion
                End If
            End If
        Else
            UltraGroupBox1.Enabled = Accion
            Navigator2.Enabled = Accion
        End If
    End Sub

    Private Sub LimpiarControles()
        LblId_Prod.Text = String.Empty
        TxtCod_SUNAT.Text = String.Empty
        TxtNombreSUNAT.Text = String.Empty
        CboPresentacion.Value = String.Empty
        CboUnidadPre.Value = String.Empty
        TxtCantidadUniPre.Text = String.Empty
        Ls_ETInsumosFProductos = New List(Of ETInsumosFProductos)
        LblCodSUNAT_E.Text = String.Empty
        LblNombreSUNAT_E.Text = String.Empty
        txtpeso.Text = String.Empty
        CargarUltraGrid(Grid2, Ls_ETInsumosFProductos)
    End Sub

    Public Sub Nuevo()
        LimpiarControles()
        HabilitarControles(True, State.eNew)
        Tab1.Tabs("T02").Selected = True
        Navigator2.Enabled = False
        TipoG = State.eNew
    End Sub

    Public Sub Modificar()

        If Tab1.Tabs("T01").Selected Then Exit Sub

        If String.IsNullOrEmpty(LblId_Prod.Text) Then
            MsgBox("No se ha seleccionado registro ha Modificar", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        HabilitarControles(True, State.eEdit)
        TxtCod_SUNAT.Enabled = False
        TipoG = State.eEdit

    End Sub

    Private Function ValidarDatosInsumoFiscalizados() As Boolean

        Dim rpta As Boolean = False
        Dim oInsFisN As NGInsumosFiscalizados = Nothing

        Try
            If TipoG = State.eEdit Then
                If LblId_Prod.Text = String.Empty Then
                    Throw New Exception("No se ha seleccionado Insumo a Modificar")
                End If
            End If


            If TxtCod_SUNAT.Text = String.Empty Then
                TxtCod_SUNAT.Focus()
                Throw New Exception("Ingresar Código de SUNAT")
            End If

            Dim ID_Prod As Integer
            oInsFisN = New NGInsumosFiscalizados
            ID_Prod = oInsFisN.Mostrar_ID_PROD_InsumosFiscalizados_x_Cod_SUNAT(Companhia, TxtCod_SUNAT.Text)
            If ID_Prod > 0 Then
                If TipoG = State.eNew Or (TipoG = State.eEdit And (ID_Prod.ToString.Trim <> LblId_Prod.Text.Trim)) Then
                    TxtCod_SUNAT.Focus()
                    Throw New Exception("El Código de SUNAT ya se encuentra registrado en el Insumo Fiscalizado con ID: " & ID_Prod.ToString)
                End If
            End If

            If TxtNombreSUNAT.Text = String.Empty Then
                TxtNombreSUNAT.Focus()
                Throw New Exception("Ingresar Nombre de producto SUNAT")
            End If
            If CboPresentacion.Value Is Nothing Then
                CboPresentacion.Focus()
                Throw New Exception("Seleccionar Presentación")
            End If
            If CboUnidadPre.Value Is Nothing Then
                CboUnidadPre.Focus()
                Throw New Exception("Seleccionar Unidad de Presentación")
            End If
            If TxtCantidadUniPre.Text = String.Empty Then
                TxtCantidadUniPre.Focus()
                Throw New Exception("Ingresar la Cantidad de Unidad por Presentación")
            End If
            If Not IsNumeric(TxtCantidadUniPre.Text) Then
                TxtCantidadUniPre.Focus()
                Throw New Exception("El valor de La Cantidad de Unidad por Presentación NO es correcto")
            End If

            If txtpeso.Text = String.Empty Then
                txtpeso.Focus()
                Throw New Exception("Ingresar Peso Bruto")
            End If
            If Not IsNumeric(txtpeso.Text) Then
                txtpeso.Focus()
                Throw New Exception("El valor del Peso NO es correcto")
            End If

            rpta = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oInsFisN = Nothing
        End Try
        Return rpta
    End Function

    Private Function ValidarDatosInsumoFProductos() As Boolean
        Dim rpta As Boolean = False
        Try
            If LblId_Prod.Text = String.Empty Then
                Throw New Exception("No se ha seleccionado Insumo a Modificar")
            End If
            If Ls_ETInsumosFProductos.Count <= 0 Then
                Navigator2.Focus()
                Throw New Exception("No se ha ingresado ningún Producto")
            End If
            rpta = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return rpta
    End Function

    Public Sub Grabar()
        If Tab1.Tabs("T02").Selected Then
            GrabarInsumosFiscalizados()
        ElseIf Tab1.Tabs("T03").Selected Then
            If TipoG <> State.eEdit Then Exit Sub
            GrabarInsumosFProductos()
        End If
    End Sub

    Private Sub GrabarInsumosFiscalizados()

        If Not ValidarDatosInsumoFiscalizados() Then Exit Sub

        If MsgBox("¿Esta Seguro de Grabar la información?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub

        Dim oInsFisN As NGInsumosFiscalizados = Nothing
        Dim oInsFisE As ETInsumosFiscalizados = Nothing

        Try
            oInsFisN = New NGInsumosFiscalizados
            oInsFisE = New ETInsumosFiscalizados

            With oInsFisE
                .Cod_Cia = Companhia
                .Cod_Sunat = TxtCod_SUNAT.Text.ToString.Trim
                .Des_Sunat = TxtNombreSUNAT.Text.ToString.Trim
                .Presentacion = CboPresentacion.Value
                .UnidadPre = CboUnidadPre.Value
                .CantidadUniPre = TxtCantidadUniPre.Text
                .PesoBruto = txtpeso.Text
                .Cod_Producto = txtcodproducto.Text.ToString.Trim
            End With

            If TipoG = State.eNew Then
                oInsFisE.User_Crea = User_Sistema
                oInsFisE.Id_Prod = oInsFisN.Insertar_InsumosFiscalizados(oInsFisE)
            ElseIf TipoG = State.eEdit Then
                oInsFisE.User_Modi = User_Sistema
                oInsFisE.Id_Prod = Convert.ToInt32(LblId_Prod.Text.ToString.Trim)
                If oInsFisN.Actualizar_InsumosFiscalizados(oInsFisE) <= 0 Then Throw New Exception("No se pudo actualizar los datos.")
            End If

            HabilitarControles(False, State.eView)
            CargarGrilla()

            MessageBox.Show("Se realizó la Operación Exitosamente.", "Sistema", MessageBoxButtons.OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oInsFisN = Nothing
            oInsFisE = Nothing
        End Try
    End Sub

    Private Sub GrabarInsumosFProductos()

        If Not ValidarDatosInsumoFProductos() Then Exit Sub

        If MsgBox("¿Esta Seguro de Grabar la información?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub

        Dim oInsFProdN As NGInsumosFProductos = Nothing
        Dim oInsFProdE As ETInsumosFProductos = Nothing

        Try

            oInsFProdN = New NGInsumosFProductos
            oInsFProdN.Grabar_ListInsumosFProductos(Ls_ETInsumosFProductos)

            HabilitarControles(False, State.eView)
            CargarGrilla()
            MessageBox.Show("Se realizó la Operación Exitosamente.", "Sistema", MessageBoxButtons.OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oInsFProdN = Nothing
            oInsFProdE = Nothing
        End Try
    End Sub

    Private Sub CargarGrilla()

        Dim oInsFisN As NGInsumosFiscalizados = Nothing
        Dim Dt As DataTable = Nothing
        Try

            oInsFisN = New NGInsumosFiscalizados
            Dt = oInsFisN.Listar_InsumosFiscalizados_x_Cod_Cia(Companhia)

            Call CargarUltraGridxBinding(Grid1, Source1, Dt)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oInsFisN = Nothing
            Dt = Nothing
        End Try
    End Sub

    Private Sub Grid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow

        If e Is Nothing Then Exit Sub

        If Grid1.Rows.Count <= 0 Then Exit Sub

        If Grid1.ActiveRow Is Nothing Then Exit Sub

        If Grid1.ActiveRow.Index < 0 Then Exit Sub

        Dim oInsFisN As NGInsumosFiscalizados = Nothing
        Dim oInsFisE As ETInsumosFiscalizados = Nothing

        Dim oInsFProdN As NGInsumosFProductos = Nothing
        Dim oInsFProdE As ETInsumosFProductos = Nothing
        Dim Dt As DataTable = Nothing
        Try

            oInsFisN = New NGInsumosFiscalizados
            oInsFisE = New ETInsumosFiscalizados

            oInsFisE = oInsFisN.Mostrar_InsumosFiscalizados_x_Id_Prod(Grid1.ActiveRow.Cells("Id_Prod").Value)

            With oInsFisE

                LblId_Prod.Text = .Id_Prod.ToString
                TxtCod_SUNAT.Text = .Cod_Sunat.ToString.Trim
                TxtNombreSUNAT.Text = .Des_Sunat.ToString.Trim
                CboPresentacion.Value = .Presentacion.ToString.Trim
                CboUnidadPre.Value = .UnidadPre.ToString.Trim
                TxtCantidadUniPre.Text = .CantidadUniPre.ToString.Trim
                txtpeso.Text = .PesoBruto.ToString.Trim
                LblCodSUNAT_E.Text = .Cod_Sunat.ToString.Trim
                LblNombreSUNAT_E.Text = .Des_Sunat.ToString.Trim
                txtcodproducto.Text = .Cod_Producto.ToString.Trim

                oInsFProdN = New NGInsumosFProductos
                Dt = oInsFProdN.Listar_InsumosFProductosXId_Prod(.Id_Prod)

                oInsFProdE = New ETInsumosFProductos

                For Each Rw As DataRow In Dt.Rows
                    oInsFProdE = New ETInsumosFProductos
                    oInsFProdE.Id_Prod = .Id_Prod
                    oInsFProdE.Cod_Prod = Rw.Item("Cod_Prod").ToString.Trim
                    oInsFProdE.DescripcionProd = Rw.Item("descrip").ToString.Trim
                    oInsFProdE.User_Crea = User_Sistema
                    oInsFProdE.User_Modi = User_Sistema
                    Ls_ETInsumosFProductos.Add(oInsFProdE)
                Next

                CargarUltraGrid(Grid2, Ls_ETInsumosFProductos)

            End With

            TipoG = State.eView
            HabilitarControles(False, State.eView)
            Tab1.Tabs("T02").Selected = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oInsFisN = Nothing
            oInsFisE = Nothing
            oInsFProdN = Nothing
            Dt = Nothing
        End Try
    End Sub

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        Dim oInsFProdN As NGInsumosFProductos = Nothing
        Dim Dt As DataTable = Nothing
        Dim oInsFProdE As ETInsumosFProductos = Nothing
        Try
            With FrmCProductosFiscalizar
                oInsFProdN = New NGInsumosFProductos
                Dt = New DataTable
                Dt = oInsFProdN.Listar_Productos(Companhia)
                .Id_Prod = Convert.ToInt32(LblId_Prod.Text.Trim)
                CargarUltraGridxBinding(.Grid1, .Source1, Dt)
                If .ShowDialog = Windows.Forms.DialogResult.OK Then

                    For Each uRow As UltraGridRow In .Grid1.Rows.FixedRows
                        oInsFProdE = New ETInsumosFProductos
                        oInsFProdE.Id_Prod = LblId_Prod.Text.Trim
                        oInsFProdE.Cod_Prod = uRow.Cells("Cod_Prod").Value
                        oInsFProdE.DescripcionProd = uRow.Cells("descrip").Value
                        oInsFProdE.User_Crea = User_Sistema
                        oInsFProdE.User_Modi = User_Sistema
                        Ls_ETInsumosFProductos.Add(oInsFProdE)
                    Next

                    CargarUltraGrid(Grid2, Ls_ETInsumosFProductos)

                    .Dispose()
                Else
                    .Dispose()
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oInsFProdN = Nothing
            oInsFProdE = Nothing
            Dt = Nothing
        End Try
    End Sub

    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        If Not VerificarControl(5, Grid2) Then
            MessageBox.Show("No tiene Rumas para Quitar", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If Grid2.ActiveRow Is Nothing Then
            MessageBox.Show("No tiene una Ruma Seleccionada", Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Grid2.ActiveRow.Delete()
    End Sub

    Public Function ValidaExistenciaProductoEnInsumoF(ByVal pId_Prod As Integer, ByVal pCod_Prod As String) As Boolean
        Dim Rpta As Boolean = False
        Dim oInsFProdN As NGInsumosFProductos = Nothing
        Try
            oInsFProdN = New NGInsumosFProductos
            If oInsFProdN.Mostrar_CantidadInsumosFProductosXId_ProdAndCod_Prod(pId_Prod, pCod_Prod) > 0 Then
                Throw New Exception("El producto con Código " & pCod_Prod & " ya se encuentra registrado en el Insumo Fiscalizado")
            End If
            Rpta = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oInsFProdN = Nothing
        End Try
        Return Rpta
    End Function

    Public Sub Eliminar()

        If Tab1.Tabs("T01").Selected Then Exit Sub
        If TipoG <> State.eView Then Exit Sub

        Tab1.Tabs("T02").Selected = True
        Dim oInsFisN As NGInsumosFiscalizados = Nothing

        Try
            oInsFisN = New NGInsumosFiscalizados

            If LblId_Prod.Text = String.Empty Then
                Throw New Exception("No se ha seleccionado Insumo a Modificar")
            End If

            If oInsFisN.Mostrar_Count_InsumosFProductosXId_Prod(Convert.ToInt32(LblId_Prod.Text.Trim)) > 0 Then
                Throw New Exception("El Insumo Fiscalizado tiene Productos enlazados, No se prodrá Eliminarlo.")
            End If

            If MsgBox("¿Esta Seguro de ELIMINAR el Insumo Fiscalizado?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub

            If oInsFisN.Anular_InsumosFiscalizados(Convert.ToInt32(LblId_Prod.Text), User_Sistema) <= 0 Then
                Throw New Exception("No se puedo realizar la operación.")
            End If

            MessageBox.Show("La Operación se realizó Exitosamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)


            IniciarControles()

            CargarGrilla()
            Tab1.Tabs("T01").Selected = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oInsFisN = Nothing
        End Try
    End Sub

    Private Sub Tab1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab1.Click
        If Tab1.ActiveTab.Index.ToString = 0 Then
            IniciarControles()
        End If
    End Sub

#Region "SETEO DE CONTROLES TXT"

    Private Sub TxtCod_SUNAT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCod_SUNAT.KeyPress
        Tabular(e)
        SoloNumeros(sender, e)
    End Sub

    Private Sub TxtNombreSUNAT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombreSUNAT.KeyPress
        Tabular(e)
        SoloLetras(sender, e)
    End Sub

    Private Sub TxtCantidadUniPre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCantidadUniPre.KeyPress
        Tabular(e)
        DecimalPosit(sender, e)
    End Sub

    Public Sub Tabular(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Sub SoloNumeros(ByVal obj As Infragistics.Win.UltraWinEditors.UltraTextEditor, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Key As Integer
        Key = Asc(UCase(e.KeyChar))
        Dim StrCad As String
        StrCad = "0123456789"
        If Key > 26 Then
            If InStr(StrCad, Chr(Key)) = 0 Then
                e.Handled = True
            End If
        End If
    End Sub

    Public Sub DecimalPosit(ByVal obj As Infragistics.Win.UltraWinEditors.UltraTextEditor, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Key As Integer
        Key = Asc(UCase(e.KeyChar))
        Dim StrCad As String
        StrCad = "0123465789."
        If Key > 26 Then
            If InStr(StrCad, Chr(Key)) = 0 Then
                e.Handled = True
            Else
                If Key = 46 Then
                    If InStr(obj.Text, Chr(Key)) = 0 Then
                        obj.MaxLength = obj.TextLength + 3
                    Else
                        e.Handled = True
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub SoloLetras(ByVal obj As Infragistics.Win.UltraWinEditors.UltraTextEditor, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Key As Integer
        Key = Asc(UCase(e.KeyChar))
        Dim StrCad As String
        StrCad = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZÁÉÍÓÚÜ()- "
        If Key > 26 Then
            If InStr(StrCad, Chr(Key)) = 0 Then
                e.Handled = True
            Else
                If obj.TextLength >= obj.MaxLength Then
                    e.Handled = True
                Else
                    If obj.SelectionStart = 0 And Key = 32 Then
                        e.Handled = True
                    ElseIf obj.SelectionStart > 0 And obj.SelectionStart = Len(obj.Text) Then
                        If ((Mid(obj.Text, obj.SelectionStart, 1) = Chr(32)) And Key = 32) Then e.Handled = True
                    ElseIf obj.SelectionStart > 0 And obj.SelectionStart < Len(obj.Text) Then
                        If ((Mid(obj.Text, obj.SelectionStart + 1, 1) = Chr(32)) And Key = 32) Or _
                        ((Mid(obj.Text, obj.SelectionStart, 1) = Chr(32)) And Key = 32) Then e.Handled = True
                    End If
                End If
            End If
            If e.Handled <> True Then
                obj.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        End If
    End Sub
#End Region

    '#Region "Variables Privadas"
    '    Private _Sistema As String = String.Empty
    '    Private _Grupo As String = String.Empty
    '    Private _Modulo As Integer = 0
    '       Public Ls_Permisos As New List(Of Integer)
    '    Private Enum State
    '        eNew = 1
    '        eEdit = 2
    '        eDel = 3
    '        eView = 4
    '    End Enum
    '    Private TipoG As State
    '    Private Ls_Glosa As List(Of ETGlosa) = Nothing
    '#End Region

    '#Region "Formulario"

    '    Private Sub frmMGlosa_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '        If sender Is Nothing OrElse e Is Nothing Then
    '            Return
    '        End If

    '        Administrar_Permisos(MdiParent, Ls_Permisos)

    '    End Sub

    '    Private Sub frmMGlosa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        Call Inicio()
    '    End Sub
    '#End Region
    Private Sub UltraTextEditor1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpeso.KeyPress
        Tabular(e)
        DecimalPosit(sender, e)
    End Sub
End Class