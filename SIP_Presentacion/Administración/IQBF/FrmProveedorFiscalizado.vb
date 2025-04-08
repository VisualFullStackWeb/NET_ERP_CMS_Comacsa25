Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmProveedorFiscalizado

    Public Ls_Permisos As New List(Of Integer)

    Private Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum

    Private TipoG As State

    Private Sub IniciarControles()
        LimpiarControles()
        TipoG = State.eView
        HabilitarControles(False)
        CargarGrilla()
    End Sub

    Private Sub FrmProveedorFiscalizado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            IniciarControles()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LimpiarControles()
        TxtCodProv.Text = String.Empty
        LblRuc.Text = String.Empty
        LblRazSocNom.Text = String.Empty
        dteFechIniVigencia.Value = DBNull.Value
        dteFechFinVigencia.Value = DBNull.Value
    End Sub

    Private Sub HabilitarControles(ByVal Accion As Boolean)
        UltraGroupBox1.Enabled = Accion
    End Sub

    Public Sub Nuevo()
        LimpiarControles()
        HabilitarControles(True)
        TxtCodProv.Enabled = True
        Tab1.Tabs("T02").Selected = True
        TipoG = State.eNew
    End Sub

    Public Sub Modificar()

        If Tab1.Tabs("T01").Selected Then Exit Sub

        If String.IsNullOrEmpty(TxtCodProv.Text) Then
            MsgBox("No se ha seleccionado registro ha Modificar", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        HabilitarControles(True)
        TxtCodProv.Enabled = False
        TipoG = State.eEdit

    End Sub

    Private Function ValidarDatosProveedorFiscalizado() As Boolean

        Dim rpta As Boolean = False
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing
        Dim Dt As New DataTable
        Try

            If TxtCodProv.Text = String.Empty Then
                If TipoG = State.eNew Then TxtCodProv.Focus()
                Throw New Exception("No se ha seleccionado Proveedor a Modificar")
            End If

            If TipoG = State.eNew Then
                oPrvFisN = New NGProveedorFiscalizado
                oPrvFisE = New ETProveedorFiscalizado
                oPrvFisE = oPrvFisN.Mostrar_ProveedorFiscalizado_X_Cod_Prov(Companhia, TxtCodProv.Text.Trim)
                If Not oPrvFisE.Cod_Prov Is Nothing Then
                    TxtCodProv.Focus()
                    Throw New Exception("El proveedor con código " & TxtCodProv.Text.Trim & " ya se encuentra Registrado")
                End If

            End If

            oPrvFisN = New NGProveedorFiscalizado
            Dt = oPrvFisN.Mostrar_Proveedor_X_Cod_Prov(Companhia, TxtCodProv.Text.Trim)
            If Dt.Rows.Count <= 0 Then
                TxtCodProv.Focus()
                Throw New Exception("No Existe el Proveedor Indicado")
            End If

            If Dt.Rows(0).Item("Status").ToString.Trim = "*" Then
                TxtCodProv.Focus()
                Throw New Exception("El Proveedor Ingresado se Encuentra Anulado")
            End If

            If Not IsDate(dteFechIniVigencia.Value) Then
                dteFechIniVigencia.Focus()
                Throw New Exception("Ingresar Fecha de Inicio de Vigencia")
            End If

            If Not IsDate(dteFechFinVigencia.Value) Then
                dteFechFinVigencia.Focus()
                Throw New Exception("Ingresar Fecha de Fin de Vigencia")
            End If

            If dteFechIniVigencia.Value > dteFechFinVigencia.Value Then
                dteFechIniVigencia.Focus()
                Throw New Exception("La fecha de Inicio de Vigencia No puede ser Mayor a Fecha Fin de Vigencia")
            End If

            rpta = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oPrvFisN = Nothing
            Dt.Dispose()
        End Try
        Return rpta
    End Function

    Public Sub Grabar()
        If Tab1.Tabs("T01").Selected Then Exit Sub
        GrabarProveedorFiscalizado()
    End Sub

    Private Sub GrabarProveedorFiscalizado()

        If Not ValidarDatosProveedorFiscalizado() Then Exit Sub

        If MsgBox("¿Esta Seguro de Grabar la información?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub

        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing

        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            With oPrvFisE
                .Cod_Cia = Companhia
                .Cod_Prov = TxtCodProv.Text.ToString.Trim
                .FechIniVig = dteFechIniVigencia.Value
                .FechFinVig = dteFechFinVigencia.Value
            End With

            If TipoG = State.eNew Then
                oPrvFisE.User_Crea = User_Sistema
                oPrvFisN.Insertar_ProveedorFiscalizado(oPrvFisE)
            ElseIf TipoG = State.eEdit Then
                oPrvFisE.User_Modi = User_Sistema
                If oPrvFisN.Actualizar_ProveedorFiscalizado(oPrvFisE) <= 0 Then Throw New Exception("No se pudo actualizar los datos.")
            End If

            HabilitarControles(False)
            CargarGrilla()

            MessageBox.Show("Se realizó la Operación Exitosamente.", "Sistema", MessageBoxButtons.OK)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oPrvFisN = Nothing
            oPrvFisE = Nothing
        End Try
    End Sub

    Private Sub CargarGrilla()
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim Dt As DataTable = Nothing
        Try
            oPrvFisN = New NGProveedorFiscalizado
            Dt = oPrvFisN.Listar_ProveedorFiscalizado(Companhia)
            Call CargarUltraGridxBinding(Grid1, Source1, Dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oPrvFisN = Nothing
            Dt = Nothing
        End Try
    End Sub

    Private Sub Grid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow

        If e Is Nothing Then Exit Sub

        If Grid1.Rows.Count <= 0 Then Exit Sub

        If Grid1.ActiveRow Is Nothing Then Exit Sub

        If Grid1.ActiveRow.Index < 0 Then Exit Sub

        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing

        Dim oInsFProdN As NGInsumosFProductos = Nothing
        Dim oInsFProdE As ETInsumosFProductos = Nothing
        Dim Dt As DataTable = Nothing
        Try

            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            oPrvFisE = oPrvFisN.Mostrar_ProveedorFiscalizado_X_Cod_Prov(Companhia, Grid1.ActiveRow.Cells("Cod_Prov").Value)

            With oPrvFisE
                TxtCodProv.Text = .Cod_Prov.ToString
                LblRuc.Text = .RUC.ToString
                LblRazSocNom.Text = .RazSoc.ToString
                dteFechIniVigencia.Value = Convert.ToDateTime(.FechIniVig)
                dteFechFinVigencia.Value = Convert.ToDateTime(.FechFinVig)
            End With

            TipoG = State.eView
            HabilitarControles(False)
            Tab1.Tabs("T02").Selected = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oPrvFisN = Nothing
            oPrvFisE = Nothing
            oInsFProdN = Nothing
            Dt = Nothing
        End Try
    End Sub

    Public Sub Eliminar()

        If Tab1.Tabs("T01").Selected Then Exit Sub
        If TipoG <> State.eView Then Exit Sub

        Tab1.Tabs("T02").Selected = True

        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim oPrvFisE As ETProveedorFiscalizado = Nothing

        Try
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado

            If TxtCodProv.Text = String.Empty Then
                Throw New Exception("No se ha seleccionado Proveedor a Modificar")
            End If

            oPrvFisE.Cod_Cia = Companhia
            oPrvFisE.Cod_Prov = TxtCodProv.Text.Trim()
            oPrvFisE.User_Modi = User_Sistema

            If MsgBox("¿Esta Seguro de ELIMINAR el Proveedor Fiscalizado?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub

            If oPrvFisN.Anular_ProveedorFiscalizado(oPrvFisE) <= 0 Then
                Throw New Exception("No se puedo realizar la operación.")
            End If

            MessageBox.Show("La Operación se realizó Exitosamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)

            IniciarControles()

            Tab1.Tabs("T01").Selected = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oPrvFisN = Nothing
        End Try
    End Sub

    Private Sub Tab1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tab1.Click
        If Tab1.ActiveTab.Index.ToString = 0 Then
            IniciarControles()
        End If
    End Sub

    Private Sub TxtCodProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodProv.KeyDown
        If e.KeyCode = Keys.F5 Then
            Me.ListarProveedoresPorFiscalizar()
        End If
    End Sub

    Private Sub TxtCodProv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodProv.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Mostrar_Proveedor_X_Cod_Prov(TxtCodProv.Text.Trim)
        End If
        LetrasNumeros(sender, e)
        If TxtCodProv.Text <> String.Empty Then Tabular(e)
    End Sub

    Private Sub Mostrar_Proveedor_X_Cod_Prov(ByVal pCod_Prov As String)
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim Dt As DataTable = Nothing
        Try
            LblRuc.Text = String.Empty
            LblRazSocNom.Text = String.Empty
            oPrvFisN = New NGProveedorFiscalizado
            Dt = New DataTable
            Dt = oPrvFisN.Mostrar_Proveedor_X_Cod_Prov(Companhia, pCod_Prov)
            If Dt.Rows.Count > 0 Then
                If Dt.Rows(0).Item("Status").ToString.Trim = "*" Then Throw New Exception("El Proveedor Ingresado se encuentra Anulado")
                LblRuc.Text = Dt.Rows(0).Item("RUC").ToString.Trim
                LblRazSocNom.Text = Dt.Rows(0).Item("RazSoc").ToString.Trim
            Else
                ListarProveedoresPorFiscalizar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oPrvFisN = Nothing
            Dt = Nothing
        End Try
    End Sub

    Public Sub ListarProveedoresPorFiscalizar()
        Dim oPrvFisN As NGProveedorFiscalizado = Nothing
        Dim Dt As DataTable = Nothing
        Try
            With FrmCProveedorFiscalizar
                oPrvFisN = New NGProveedorFiscalizado
                Dt = New DataTable
                Dt = oPrvFisN.Listar_Proveedores_Fiscalizar(Companhia)
                CargarUltraGridxBinding(.Grid1, .Source1, Dt)
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    TxtCodProv.Text = .Grid1.ActiveRow.Cells("Cod_Prov").Value
                    LblRuc.Text = .Grid1.ActiveRow.Cells("RUC").Value
                    LblRazSocNom.Text = .Grid1.ActiveRow.Cells("RazSoc").Value
                    .Dispose()
                Else
                    .Dispose()
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oPrvFisN = Nothing
            Dt = Nothing
        End Try
    End Sub

    Public Sub Buscar()
        If TipoG <> State.eNew Then Exit Sub
        ListarProveedoresPorFiscalizar()
    End Sub

    Private Sub FechVigencia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dteFechIniVigencia.KeyPress, dteFechFinVigencia.KeyPress
        Tabular(e)
    End Sub

#Region "SETEO DE CONTROLES TXT"

    Public Sub Tabular(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Sub LetrasNumeros(ByVal obj As Infragistics.Win.UltraWinEditors.UltraTextEditor, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim Key As Integer
        Key = Asc(UCase(e.KeyChar))
        Dim StrCad As String
        StrCad = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789"
        If Key > 26 Then
            If InStr(StrCad, Chr(Key)) = 0 Then
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

    Private Sub dteFechIniVigencia_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dteFechIniVigencia.ValueChanged

    End Sub

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout

    End Sub

    Private Sub TxtCodProv_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodProv.ValueChanged

    End Sub
End Class