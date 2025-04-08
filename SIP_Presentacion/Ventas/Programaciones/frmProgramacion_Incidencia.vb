Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Public Class frmProgramacion_Incidencia
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
    Dim dtDetalle As New DataTable
    Private Sub frmProgramacion_Incidencia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFecha.Value = Now.Date
    End Sub
    Sub Procesar()
        Try
            Entidad.Contratista = New ETContratista
            Entidad.Contratista.TipoOperacion = Ope
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Entidad.Contratista._codprov = txtcodprov.Text
            Entidad.Contratista.Fecha = dtpFecha.Value
            Dim dtConsulta As New DataTable
            dtConsulta = Negocio.NContratista.Consulta_GuiaProgramacionV2(Entidad.Contratista)
            Call CargarUltraGridxBinding(Me.gridConsulta, Source1, dtConsulta)
            If dtDetalle.Columns.Count > 1 Then
                For i As Int32 = dtDetalle.Rows.Count - 1 To 0 Step -1
                    dtDetalle.Rows.RemoveAt(i)
                Next
                Call CargarUltraGridxBinding(Me.gridDetalle, Source2, dtDetalle)
            End If
            If idprogramacion <> 0 Then
                For i As Int32 = 0 To gridConsulta.Rows.Count - 1
                    If idprogramacion = gridConsulta.Rows(i).Cells("IDPROGRAMACION").Value Then
                        gridConsulta.Rows(i).Selected = True
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Buscar()
        Dim frm As New FrmListaTransportista
        frm.ShowDialog()
        txtcodprov.Text = codMotivodetalle.Trim
        txtproveedor.Text = Motivodetalle.Trim
        Procesar()
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

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Try
            Procesar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnincidencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnincidencia.Click
        Dim cont As Int32 = 0
        For i As Int32 = 0 To gridConsulta.Rows.Count - 1
            If gridConsulta.Rows(i).Cells("INCIDENCIAS").Value = True Then
                cont += 1
            End If
        Next
        If cont = 0 Then
            MsgBox("Debe seleccionar mínimo un registro", MsgBoxStyle.Information, msgComacsa)
            Exit Sub
        End If
        Dim result As DialogResult
        Dim frm As New frmRegistro_Incidencia
        frm.fecha = dtpFecha.Value
        result = frm.ShowDialog()
        If result = Windows.Forms.DialogResult.OK Then
            If MsgBox("¿Seguro desea registrar incidencia?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.No Then
                Return
            End If
            Try
                For i As Int32 = 0 To gridConsulta.Rows.Count - 1
                    If gridConsulta.Rows(i).Cells("INCIDENCIAS").Value = True Then
                        Entidad.Contratista = New ETContratista
                        Entidad.Contratista.TipoOperacion = Ope
                        Negocio.NContratista = New NGContratista
                        Entidad.MyLista = New ETMyLista
                        Entidad.Contratista.Tipo = 1
                        Entidad.Contratista.ID = gridConsulta.Rows(i).Cells("IDPROGRAMACION").Value
                        Entidad.Contratista.idEstado = frm.idestado
                        Entidad.Contratista.Fecha = frm.fechaincidencia
                        Entidad.Contratista.hora = frm.horaincidencia
                        Entidad.Contratista._idconcepto = frm.idconcepto
                        Entidad.Contratista._observacion = frm.observacion
                        Entidad.Contratista.Usuario = User_Sistema
                        Dim dtDatos As New DataTable
                        dtDatos = New DataTable
                        dtDatos = Negocio.NContratista.Registra_Incidencia(Entidad.Contratista)
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            MsgBox("Programación grabada correctamente", MsgBoxStyle.Information, msgComacsa)
            Procesar()
            cargaDetalle(idprogramacion)
        End If
    End Sub
    Dim idprogramacion As Int32
    Private Sub gridConsulta_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridConsulta.DoubleClickRow
        Try
            idprogramacion = gridConsulta.ActiveRow.Cells("IDPROGRAMACION").Value
            cargaDetalle(idprogramacion)
        Catch ex As Exception

        End Try
    End Sub

    Sub cargaDetalle(ByVal idprogramacion As Int32)
        Entidad.Contratista = New ETContratista
        Entidad.Contratista.TipoOperacion = Ope
        Negocio.NContratista = New NGContratista
        Entidad.MyLista = New ETMyLista
        Entidad.Contratista.Usuario = User_Sistema
        Entidad.Contratista.ID = idprogramacion
        Entidad.Contratista.Fecha = dtpFecha.Value
        dtDetalle = Negocio.NContratista.Consulta_Incidencia(Entidad.Contratista)
        Call CargarUltraGridxBinding(Me.gridDetalle, Source2, dtDetalle)
    End Sub
    Private Sub gridDetalle_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridDetalle.ClickCell
        Try
            If gridDetalle.ActiveRow.Cells(gridDetalle.ActiveCell.Column.Index).Column.Key = "ELIMINAR" Then

                If MsgBox("Seguro de eliminar la incidencia?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                    'MsgBox(gridDetalle.ActiveRow.Cells("ID").Value)
                    Entidad.Contratista = New ETContratista
                    Entidad.Contratista.TipoOperacion = Ope
                    Negocio.NContratista = New NGContratista
                    Entidad.MyLista = New ETMyLista
                    Entidad.Contratista.ID = gridDetalle.ActiveRow.Cells("ID").Value
                    Entidad.Contratista.Usuario = User_Sistema
                    Dim dtDatos As New DataTable
                    dtDatos = New DataTable
                    dtDatos = Negocio.NContratista.Elimina_Incidencia(Entidad.Contratista)
                    If dtDatos.Rows(0)(0) = "OK" Then
                        MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
                        Procesar()
                        cargaDetalle(idprogramacion)
                    Else
                        MsgBox(dtDatos.Rows(0)(0), MsgBoxStyle.Exclamation, msgComacsa)
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
   
    Private Sub gridDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridDetalle.InitializeLayout

    End Sub
End Class