Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmCargarUsuario
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ope As Int32 = 0
    Public sistema As String = String.Empty
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
  
    Public filtroDescripcion As String = String.Empty
#End Region
    Public saldo_cero As String = ""
    Public codarea As String = ""
    Private Sub FrmCargarUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        Entidad.Entregas = New ETEntregas
        'Entidad.Entregas.TipoOperacion = Ope
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.Entregas.Sistema = sistema '"22"
        Entidad.Entregas.codArea = codarea '"22"
        If saldo_cero = "" Then
            Entidad.MyLista = Negocio.NEntregas.CargarUsuarios(Entidad.Entregas)
        Else
            Entidad.MyLista = Negocio.NEntregas.CargarUsuariosAprueba(Entidad.Entregas)
        End If

        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridConceptos, Source1, Ls_Entrega)
    End Sub

    Private Sub gridConceptos_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridConceptos.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If sender IsNot gridConceptos Then Return
        If e.Row.IsFilterRow Then Return
        SeleccionarConcepto(e.Row)
    End Sub
    Sub SeleccionarConcepto(ByVal uRow As UltraGridRow)

        If uRow Is Nothing Then
            Return
        End If
        userLogin = uRow.Cells("userLogin").Value
        Me.Close()

    End Sub

    Private Sub gridConceptos_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "userlogin" OrElse uColumn.Key = "encargado") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub gridConceptos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridConceptos.KeyDown
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If e.KeyValue = Keys.Return Then
            If gridConceptos.ActiveRow.Index < 0 Then MsgBox("Seleccione un usuario", MsgBoxStyle.Exclamation, msgComacsa) : Return
            userLogin = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("userLogin").Value
            Me.Close()
        End If
    End Sub

End Class