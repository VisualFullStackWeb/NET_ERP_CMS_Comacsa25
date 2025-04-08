Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmConceptos
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
    Sub Nuevo()
        txtid.Text = 0
        limpiar()
        Me.TabMaestro.Tabs("Registro").Selected = True
    End Sub
    Sub limpiar()
        txtid.Text = 0
        txtdescripcion.Clear()
        cmbanticipo.SelectedIndex = -1
        cmbvariacion.SelectedIndex = -1
    End Sub

    Sub Grabar()
        Try
            If Me.TabMaestro.Tabs("Lista").Selected = True Then Exit Sub

            If Not Validar() Then Exit Sub
            If MsgBox("¿Seguro de grabar registro?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._tipo = 1
            objEntidad._usuario = User_Sistema

            objEntidad._idtrabajador = txtid.Text
            objEntidad._descripcion = txtdescripcion.Text
            objEntidad._tipoanticipo = cmbanticipo.Value
            objEntidad._desctipoanticipo = cmbanticipo.Text
            objEntidad._variacion = cmbvariacion.Value
          
            Dim id As Int32
            id = objNegocio.Mant_Conceptos(objEntidad)
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
    Sub Eliminar()
        Try
            If Me.TabMaestro.Tabs("Lista").Selected = True Then Exit Sub
            If txtid.Text.ToString.Trim = "" Then txtid.Text = 0
            If txtid.Text = 0 Then
                MsgBox("Seleccione registro a eliminar", MsgBoxStyle.Exclamation, msgComacsa)
                Exit Sub
            End If
            If Not Validar() Then Exit Sub
            If MsgBox("¿Seguro de eliminar registro?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._tipo = 3
            objEntidad._usuario = User_Sistema

            objEntidad._idtrabajador = txtid.Text
            objEntidad._descripcion = txtdescripcion.Text
            objEntidad._tipoanticipo = cmbanticipo.Value
            objEntidad._desctipoanticipo = cmbanticipo.Text
            objEntidad._variacion = cmbvariacion.Value

            Dim id As Int32
            id = objNegocio.Mant_Conceptos(objEntidad)
            If id > 0 Then
                MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
                CargarDatos()
                limpiar()
                Me.TabMaestro.Tabs("Lista").Selected = True
            Else
                MsgBox("Error al eliminar", MsgBoxStyle.Exclamation, msgComacsa)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub CargarDatos()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        objEntidad._tipo = 1
        objEntidad._tipoanticipo = ""
        dtDatos = objNegocio.Listarconceptos(objEntidad)
        Call CargarUltraGridxBinding(gridconceptos, Source1, dtDatos)
    End Sub
    Function Validar() As Boolean
        If txtdescripcion.Text.Trim = "" Then
            MsgBox("Ingrese descripcion", MsgBoxStyle.Exclamation, msgComacsa)
            txtdescripcion.Focus()
            Return False
        End If
        If cmbanticipo.SelectedIndex < 0 Then
            MsgBox("Ingrese tipo de anticipo", MsgBoxStyle.Exclamation, msgComacsa)
            cmbanticipo.Focus()
            Return False
        End If
        If cmbvariacion.SelectedIndex < 0 Then
            MsgBox("Ingrese tipo de variación", MsgBoxStyle.Exclamation, msgComacsa)
            cmbvariacion.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub frmConceptos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarDatos()
    End Sub

    Private Sub gridcontratista_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridconceptos.DoubleClickRow
        Try
            txtid.Text = gridconceptos.ActiveRow.Cells("ID").Value
            txtdescripcion.Text = gridconceptos.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
            cmbanticipo.Value = gridconceptos.ActiveRow.Cells("TIPO").Value.ToString.Trim
            cmbvariacion.Value = gridconceptos.ActiveRow.Cells("FLAGVARIACION").Value.ToString.Trim
            Me.TabMaestro.Tabs("Registro").Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbanticipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbanticipo.ValueChanged
        Try
            If cmbanticipo.Value = "E" Then
                cmbvariacion.Value = "D"
                cmbvariacion.Enabled = False
            Else
                cmbvariacion.Value = ""
                cmbvariacion.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class