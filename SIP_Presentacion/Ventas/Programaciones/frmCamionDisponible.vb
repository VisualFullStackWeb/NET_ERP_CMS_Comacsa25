Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Public Class frmCamionDisponible
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

    Private Sub frmCamionDisponible_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFecha.Value = DateAdd(DateInterval.Day, 1, Now.Date)
    End Sub
    Sub Buscar()
        Dim frm As New FrmListaTransportista
        frm.ShowDialog()
        txtcodprov.Text = codMotivodetalle.Trim
        txtproveedor.Text = Motivodetalle.Trim
        Procesar()
        'txtruc.Text = Ruc.Trim
    End Sub

    Private Sub txtcodprov_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtcodprov.KeyDown
        If e.KeyData = Keys.Return Then
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista._codprov = txtcodprov.Text
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NContratista.Listar_PRO_Prov_Codigo(Entidad.Contratista)
            If dtDatos.Rows.Count > 0 Then
                txtcodprov.Text = dtDatos.Rows(0)("COD_PROV")
                txtproveedor.Text = dtDatos.Rows(0)("PROVEEDOR")
            Else
                MsgBox("El código no existe", MsgBoxStyle.Exclamation, msgComacsa)
                txtproveedor.Clear()
            End If
            Procesar()
        End If
    End Sub
    Sub Procesar()
        CargarDatos()
    End Sub
    Private Sub CargarDatos()
        Try
            Entidad.Contratista = New ETContratista
            Entidad.Contratista.TipoOperacion = Ope
            Entidad.Contratista._tipoanticipo = "I"
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista._codprov = txtcodprov.Text
            Entidad.Contratista.Fecha = dtpFecha.Value
            Dim dtDatos As New DataTable
            dtDatos = Negocio.NContratista.Listar_PRO_Disponibilidad(Entidad.Contratista)
            Call CargarUltraGridxBinding(Me.gridDisponibilidad, Source1, dtDatos)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Procesar()
    End Sub
    Sub Grabar()
        Try
            If Tab1.SelectedTab.Key <> "T01" Then Return
            If MsgBox("¿Seguro desea guardar los cambios?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Return
            End If
            gridDisponibilidad.PerformAction(ExitEditMode)
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            For i As Int32 = 0 To gridDisponibilidad.Rows.Count - 1
                Entidad.Contratista = New ETContratista
                Negocio.NContratista = New NGContratista
                Entidad.MyLista = New ETMyLista
                Entidad.Contratista.Usuario = User_Sistema
                Entidad.Contratista.Tipo = 1
                Entidad.Contratista.ID = gridDisponibilidad.Rows(i).Cells("ID").Value
                Entidad.Contratista._codprov = gridDisponibilidad.Rows(i).Cells("COD_PROV").Value
                Entidad.Contratista._observacion = gridDisponibilidad.Rows(i).Cells("OBSERVACION").Value
                Entidad.Contratista._check = IIf(gridDisponibilidad.Rows(i).Cells("EXISTE").Value = True, 1, 0)
                Entidad.Contratista._check2 = IIf(gridDisponibilidad.Rows(i).Cells("EXISTE2").Value = True, 1, 0)
                Entidad.Contratista._check3 = IIf(gridDisponibilidad.Rows(i).Cells("EXISTE3").Value = True, 1, 0)
                Entidad.Contratista.Fecha = dtpFecha.Value
                Dim dtDatos As New DataTable
                dtDatos = Negocio.NContratista.Listar_PRO_MantDisponibilidad(Entidad.Contratista)
            Next
            Dim Mensaje As String = "Se grabó con éxito el registro"
            MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
            Call Procesar()
            'Call limpiar()

            'If dtDatos.Rows(0)(0) = "OK" Then
            '    Dim Mensaje As String = "Se grabó con éxito el registro"
            '    MsgBox(Mensaje, MsgBoxStyle.Information, msgComacsa)
            '    Call Procesar()
            '    'Call limpiar()
            'Else
            '    Dim Mensaje As String = dtDatos.Rows(0)(0)
            '    MsgBox(Mensaje, MsgBoxStyle.Exclamation, msgComacsa)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        End Try

    End Sub
End Class