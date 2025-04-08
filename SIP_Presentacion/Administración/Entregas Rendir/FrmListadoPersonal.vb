Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmListadoPersonal
    Public cencos As String = ""
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ope As Int32 = 0
    Public sistema As String = String.Empty
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Public filtroDescripcion As String = String.Empty
    'Public Saldo_LC_T1 = 0.0  'Para indicar el saldo de T&E
    'Public Saldo_LC_T2 = 0.0  'Para indicar el saldo P-Card


#End Region

    Private _checkTarjeta As Boolean
    Private _lchk_tarjeta As Integer = 0
    ' Constructor con un parámetro opcional
    Public Sub New(Optional ByVal checkTarjeta As Boolean = False, Optional ByVal lchk_tarjeta As Integer = 0)
        ' Esta llamada es necesaria para el diseñador.
        InitializeComponent()
        ' Asigna el valor del parámetro a la variable interna
        _checkTarjeta = checkTarjeta
        _lchk_tarjeta = lchk_tarjeta
    End Sub

    Private Sub FrmListadoPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        'Entidad.Entregas = New ETEntregas
        'Entidad.Entregas.TipoOperacion = Ope

        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.Entregas.Sistema = sistema '"22"      

        If _checkTarjeta Then
            ' Aplica a Tarjeta de Consumo 
            Entidad.MyLista = Negocio.NEntregas.CargarPersonalTarjetaConsumo(_lchk_tarjeta)
        Else
            Entidad.MyLista = Negocio.NEntregas.CargarPersonal(cencos)
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
        codTrabajador = uRow.Cells("CodTrabajador").Value
        nomTrabajador = uRow.Cells("NomTrabajador").Value
        bcotrabajador = uRow.Cells("bancobeneficiario").Value
        ctatrabajador = uRow.Cells("ctabeneficiario").Value
        If _checkTarjeta Then
            numeroTarjetaConsumo = uRow.Cells("nro_tarjeta").Value
            'tipoTarjetaConsumo = uRow.Cells("tipo_tarjeta").Value
            bancoTarjetaConsumo = uRow.Cells("cod_banco").Value
            If _lchk_tarjeta = 2 Then
                saliniTarjetaConsumo = uRow.Cells("saldo_ini1").Value
                Saldo_LC_T2 = uRow.Cells("saldo_ini1").Value
                Saldo_LC_T1 = uRow.Cells("saldo_ini").Value
            Else
                saliniTarjetaConsumo = uRow.Cells("saldo_ini").Value
                Saldo_LC_T1 = uRow.Cells("saldo_ini").Value
                Saldo_LC_T2 = uRow.Cells("saldo_ini1").Value
            End If
            idTarjetaConsumo = uRow.Cells("idtarjetaconsumo").Value
        End If
        Me.Close()
    End Sub

    Private Sub gridConceptos_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridConceptos.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "CodTrabajador" OrElse uColumn.Key = "NomTrabajador") Then
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
            If gridConceptos.ActiveRow.Index < 0 Then MsgBox("Seleccione un trabajador", MsgBoxStyle.Exclamation, msgComacsa) : Return
            codTrabajador = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("CodTrabajador").Value
            nomTrabajador = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("NomTrabajador").Value
            bcotrabajador = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("bancobeneficiario").Value
            ctatrabajador = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("ctabeneficiario").Value
            If _checkTarjeta Then
                numeroTarjetaConsumo = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("nro_tarjeta").Value
                tipoTarjetaConsumo = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("tipo_tarjeta").Value
                bancoTarjetaConsumo = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("cod_banco").Value
                saliniTarjetaConsumo = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("saldo_ini").Value
                idTarjetaConsumo = gridConceptos.Rows(gridConceptos.ActiveRow.Index).Cells("idtarjetaconsumo").Value
            End If

            Me.Close()
        End If
    End Sub
End Class