Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmSuspensionRenta
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)

    Private Enum sTate
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private TipoG As sTate
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_EntregaDetalle As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    'Private ctabeneficiario As String = String.Empty
    'Private bcotra As String = String.Empty
#End Region
    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarSuspension()
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.Gridlineacredito, Source1, Ls_Entrega)
    End Sub

    Private Sub FrmSuspensionRenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarDatos()
    End Sub

    Private Sub Gridlineacredito_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Gridlineacredito.DoubleClickRow
        Try
            Ope = 1
            txtid.Text = Gridlineacredito.ActiveRow.Cells("ID").Value
            txtruc.Text = Gridlineacredito.ActiveRow.Cells("nroruc").Value.ToString.Trim
            txtrazon.Text = Gridlineacredito.ActiveRow.Cells("Razon").Value.ToString.Trim
            dtfecha.Value = Gridlineacredito.ActiveRow.Cells("Fecha").Value.ToString.Trim
            TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
            txtruc.ReadOnly = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Gridlineacredito_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Gridlineacredito.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "nroruc" OrElse uColumn.Key = "Razon" OrElse uColumn.Key = "Fecha") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Public Sub Nuevo()
        Ope = 1
        nroSolicitud = String.Empty
        Call LimpiarDatos()
        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        txtruc.ReadOnly = False
        Me.txtruc.Focus()
    End Sub

    Sub LimpiarDatos()
        txtruc.Clear()
        txtrazon.Clear()
        txtid.Text = 0
    End Sub
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
    Sub Grabar()
        Try
            If TabMaestroEntregas.Tabs("Registro").Selected = Boolean.FalseString Then Exit Sub
            If txtruc.Text.Trim = "" Then
                MsgBox("Ingrese N° de Ruc", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If

            If txtrazon.Text.Trim = "" Then
                MsgBox("Ingrese Razón del proveedor", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._ruc = txtruc.Text
            objEntidad._nombres = txtrazon.Text
            objEntidad._id = txtid.Text
            objEntidad._fecha1 = dtfecha.Value
            objEntidad._tipo = 1
            objEntidad._usuario = User_Sistema

            Dim dtResultado As New DataTable
            dtResultado = objNegocio.MantSuspension(objEntidad)
            If dtResultado.Rows.Count <= 0 Then
                MsgBox("Error al grabar", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If dtResultado.Rows(0)(0) = "OK" Then
                MsgBox("Guardado correctamente", MsgBoxStyle.Information, msgComacsa)
                Actualizar()
            Else
                MsgBox(dtResultado.Rows(0)(0), MsgBoxStyle.Exclamation, msgComacsa)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Eliminar()
        Try
            If txtruc.Text.Trim = "" Then
                MsgBox("Ingrese N° de Ruc", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If

            If txtrazon.Text.Trim = "" Then
                MsgBox("Ingrese Razón del proveedor", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If MsgBox("¿Seguro desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._ruc = txtruc.Text
            objEntidad._nombres = txtrazon.Text
            objEntidad._id = txtid.Text
            objEntidad._tipo = 3
            objEntidad._usuario = User_Sistema
            objEntidad._fecha1 = dtfecha.Value
            Dim dtResultado As New DataTable
            dtResultado = objNegocio.MantSuspension(objEntidad)
            If dtResultado.Rows.Count <= 0 Then
                MsgBox("Error al eliminar", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If dtResultado.Rows(0)(0) = "OK" Then
                MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
                Actualizar()
            Else
                MsgBox(dtResultado.Rows(0)(0), MsgBoxStyle.Exclamation, msgComacsa)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Actualizar()
        CargarDatos()
        LimpiarDatos()
        Me.TabMaestroEntregas.Tabs("Lista").Selected = True
    End Sub
End Class