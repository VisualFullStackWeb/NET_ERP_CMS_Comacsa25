Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmConceptoRH
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
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

    Private Sub FrmConceptoRH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarDatos()
    End Sub
    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Dim dtDatos As New DataTable
        dtDatos = Negocio.NEntregas.ListarConceptoRH()
        Call CargarUltraGridxBinding(Me.gridConcepto, Source1, dtDatos)
    End Sub

    Public Sub Nuevo()
        Ope = 1
        nroSolicitud = String.Empty
        Call LimpiarDatos()
        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        txtconcepto.ReadOnly = False
        Me.txtconcepto.Focus()
    End Sub
    Sub LimpiarDatos()
        txtruc.Clear()
        txtconcepto.Clear()
        txtid.Text = 0
    End Sub

    Private Sub gridConcepto_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridConcepto.DoubleClickRow
        Try
            Ope = 1
            txtid.Text = gridConcepto.ActiveRow.Cells("ID").Value
            txtconcepto.Text = gridConcepto.ActiveRow.Cells("CONCEPTO").Value.ToString.Trim
            TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        Catch ex As Exception

        End Try
    End Sub

    Sub Grabar()
        Try
            If txtconcepto.Text.Trim = "" Then
                MsgBox("Ingrese Concepto del Recibo", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If MsgBox("¿Seguro desea Guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._descripcion = txtconcepto.Text
            objEntidad._id = txtid.Text
            objEntidad._tipo = 1
            objEntidad._usuario = User_Sistema
            '                               
            Dim dtResultado As New DataTable
            dtResultado = objNegocio.MantReciboRH(objEntidad)
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
            If txtid.Text = 0 Then
                MsgBox("Seleccione registro a eliminar", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If

            If txtconcepto.Text.Trim = "" Then
                MsgBox("Ingrese Concepto del Recibo", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If MsgBox("¿Seguro desea eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then Exit Sub
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._descripcion = txtconcepto.Text
            objEntidad._id = txtid.Text
            objEntidad._tipo = 3
            objEntidad._usuario = User_Sistema

            Dim dtResultado As New DataTable
            dtResultado = objNegocio.MantReciboRH(objEntidad)
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