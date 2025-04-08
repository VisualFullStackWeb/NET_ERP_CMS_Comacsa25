Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmPrecioMineral
#Region "Declarar Variables"
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
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
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
#End Region
    Sub CargarDatos()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable

        dtDatos = objNegocio.ListarPrecioMineral()
        Call CargarUltraGridxBinding(gridminerales, Source1, dtDatos)
    End Sub

    Private Sub frmPrecioMineral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarDatos()
    End Sub

    Private Sub gridminerales_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridminerales.DoubleClickRow
        Try
            txtcodigo.Text = gridminerales.ActiveRow.Cells("COD_PROD").Value
            txtmineral.Text = gridminerales.ActiveRow.Cells("DESCRIP").Value.ToString.Trim
            txtprecio.Value = gridminerales.ActiveRow.Cells("PRECIO").Value
            Me.TabMaestro.Tabs("Registro").Selected = True
            txtprecio.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Sub Grabar()
        Try
            If Me.TabMaestro.Tabs("Lista").Selected = True Then Exit Sub
            If txtprecio.Text.ToString.Trim = "" Then txtprecio.Text = 0
            'If Not Validar() Then Exit Sub
            If txtcodigo.Text.ToString.Trim = "" Then
                MsgBox("Ingrese mineral", MsgBoxStyle.Exclamation, msgComacsa)
                txtmineral.Focus()
                Exit Sub
            End If
            If txtprecio.Text <= 0 Then
                MsgBox("Ingrese precio válido", MsgBoxStyle.Exclamation, msgComacsa)
                txtprecio.Focus()
                Exit Sub
            End If
            If MsgBox("¿Seguro de grabar registro?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._tipo = 1
            objEntidad._usuario = User_Sistema

            objEntidad._codprod = txtcodigo.Text
            objEntidad._precio = txtprecio.Text


            Dim id As Int32
            id = objNegocio.Mant_PrecioMineral(objEntidad)
            If id > 0 Then
                MsgBox("Grabado correctamente", MsgBoxStyle.Information, msgComacsa)
                CargarDatos()
                limpiar()
                Me.TabMaestro.Tabs("Lista").Selected = True
            Else
                MsgBox("Error al grabar", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub limpiar()
        txtcodigo.Clear()
        txtmineral.Clear()
        txtprecio.Clear()
    End Sub

    Private Sub txtprecio_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtprecio.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Private Sub gridminerales_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridminerales.InitializeLayout

    End Sub
End Class