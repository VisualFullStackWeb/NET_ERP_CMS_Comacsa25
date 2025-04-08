Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmConceptoFactura
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

    Private Sub frmConceptoFactura_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarDatos()
    End Sub
    Sub CargarDatos()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.ListarConceptoFact()
        Call CargarUltraGridxBinding(gridminerales, Source1, dtDatos)
    End Sub

    Sub Nuevo()
        Limpiar()
        Me.TabMaestro.Tabs("Registro").Selected = True
    End Sub

    Sub Limpiar()
        txtid.Text = 0
        txtconcepto.Clear()
        txtcuenta.Clear()
        txtdescuenta.Clear()
        txtconcepto.Focus()
    End Sub
    Private Sub gridminerales_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridminerales.DoubleClickRow
        Try
            txtid.Text = gridminerales.ActiveRow.Cells("ID_CONCEPTO").Value
            txtconcepto.Text = gridminerales.ActiveRow.Cells("CONCEPTO").Value.ToString.Trim
            txtcuenta.Text = gridminerales.ActiveRow.Cells("CUENTA").Value.ToString.Trim
            txtdescuenta.Text = gridminerales.ActiveRow.Cells("DESCUENTA").Value.ToString.Trim
            Me.TabMaestro.Tabs("Registro").Selected = True
            txtconcepto.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcuenta.KeyPress
        Dim frm As New FrmCuentaContable
        'frm.filtroDescripcion = TXT
        frm.ShowDialog()
        txtcuenta.Text = codCuenta
        txtdescuenta.Text = Cuenta
    End Sub

    Sub Grabar()
        Try
            If Me.TabMaestro.Tabs("Lista").Selected = True Then Exit Sub
            'If Not Validar() Then Exit Sub
            If txtconcepto.Text.ToString.Trim = "" Then
                MsgBox("Ingrese Concepto", MsgBoxStyle.Exclamation, msgComacsa)
                txtconcepto.Focus()
                Exit Sub
            End If
            If txtcuenta.Text.ToString.Trim = "" Then
                MsgBox("Ingrese Cuenta", MsgBoxStyle.Exclamation, msgComacsa)
                txtconcepto.Focus()
                Exit Sub
            End If
            If MsgBox("¿Seguro de grabar registro?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._tipo = 1
            objEntidad._usuario = User_Sistema

            objEntidad.Operacion = 1
            objEntidad.ID = txtid.Text
            objEntidad._descripcion = txtconcepto.Text
            objEntidad.Cuenta = txtcuenta.Text
            objEntidad.Usuario = User_Sistema


            Dim dtDatos As New DataTable
            dtDatos = objNegocio.Mant_ConceptoFact(objEntidad)
            MsgBox("Grabado correctamente", MsgBoxStyle.Information, msgComacsa)
            CargarDatos()
            Limpiar()
            Me.TabMaestro.Tabs("Lista").Selected = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub Eliminar()
        Try
            If Not Me.TabMaestro.Tabs("Lista").Selected = True Then Exit Sub
            'If Not Validar() Then Exit Sub

            Dim id As Int32 = gridminerales.ActiveRow.Cells("ID_CONCEPTO").Value

            If MsgBox("¿Seguro de eliminar registro?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.No Then Exit Sub
            objNegocio = New NGContratista
            objEntidad = New ETContratista
            objEntidad._tipo = 1
            objEntidad._usuario = User_Sistema

            objEntidad.Operacion = 3
            objEntidad.ID = id
            objEntidad._descripcion = txtconcepto.Text
            objEntidad.Cuenta = txtcuenta.Text
            objEntidad.Usuario = User_Sistema


            Dim dtDatos As New DataTable
            dtDatos = objNegocio.Mant_ConceptoFact(objEntidad)
            MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
            CargarDatos()
            Limpiar()
            Me.TabMaestro.Tabs("Lista").Selected = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class