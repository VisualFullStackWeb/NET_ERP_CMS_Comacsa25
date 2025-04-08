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
Imports System.Data

Public Class FrmPlanificacion
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Public ConceptoSeleccionado As String
    Public filtroDescripcion As String = String.Empty
#End Region
    Dim dtTarea As New DataTable
    Dim dtSubTarea As New DataTable
    Dim dtSubTarea_Filtro As New DataTable
    Dim dtPersonal As New DataTable
    Dim dtMaterial As New DataTable
    Dim dtServicio As New DataTable
    Dim dtPlano As New DataTable
    Dim dtPlanoDet As New DataTable
    Dim obj_Proyecto As New NGProyecto
    Dim obj_EProyecto As New ETProyecto
    Dim cierre As Int32 = 0

    Private Sub FrmPlanificacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFecha.Value = Now.Date
        dtfechasubtarea.Value = Now.Date
        If dtTarea.Columns.Count <= 0 Then
            creaColumnaTarea()
        End If
        If dtSubTarea.Columns.Count <= 0 Then
            creaColumnaSubTarea(dtSubTarea)
            creaColumnaSubTarea(dtSubTarea_Filtro)
        End If
        cmbTipo.Value = 0
        cargaData()
        creaColumnaPlano()
        'dtSubTarea_Filtro = dtSubTarea.Clone
    End Sub

    Sub Procesar()
        cargaData()
        Tab1.Tabs("T01").Selected = Boolean.TrueString
        Limpiar()
        LimpiarSubtareaDET()
    End Sub
    Sub cargaData()
        Dim dtPlanificacion As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        Dim dsData As New DataSet
        dsData = obj_Proyecto.Lista_Planificacion(obj_EProyecto)
        dtPlanificacion = dsData.Tables(0)
        gridProyecto.DataSource = dtPlanificacion
    End Sub

    Sub cargaData_ID(ByVal id As Int32)
        dtSubTarea_Filtro.Rows.Clear()
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.idplanificacion = id
        Dim dsData As New DataSet
        dsData = obj_Proyecto.Lista_PlanificacionID(obj_EProyecto)
        dtTarea = dsData.Tables(0)
        dtSubTarea = dsData.Tables(1)
        dtPlano = dsData.Tables(2)
        gridTarea.DataSource = dtTarea
        gridplano.DataSource = dtPlano
    End Sub

    Sub creaColumnaPlano()
        dtPlano.Columns.Add("PLANO")
        dtPlano.Columns.Add("ELIMINAR")
        dtPlano.Columns.Add("ID_PLANIF_PLANO")
        dtPlanoDet.Columns.Add("PLANO")
        dtPlanoDet.Columns.Add("ELIMINAR")
        dtPlanoDet.Columns.Add("ID_PLANIF_SUB_PLANO")
    End Sub

    Sub creaColumnaTarea()
        dtTarea.Columns.Add("ID_TAREA")
        dtTarea.Columns.Add("DESC_TAREA")
        dtTarea.Columns.Add("ELIMINAR")
        dtTarea.Columns.Add("ID_PLANIF_TAREA")
    End Sub

    Sub creaColumnaSubTarea(ByVal dt As DataTable)
        dt.Columns.Add("ID_TAREA")
        dt.Columns.Add("ID_SUBTAREA")
        dt.Columns.Add("SUBTAREA")
        dt.Columns.Add("ELIMINAR")
        dt.Columns.Add("NUMERO")
        dt.Columns.Add("EJECUCION")
        dt.Columns.Add("TIPO")
        dt.Columns.Add("ID_PLANIF_SUBTAREA")
    End Sub

    Sub Buscar()
        If cierre = 1 Then Exit Sub
        If txtproyecto.Focused = True Then
            Dim frm As New FrmListaProyecto
            frm.ShowDialog()
            txtidproyecto.Text = frm.id_proyecto
            txtproyecto.Text = frm.proyecto
            txttaller.Focus()
            Exit Sub
        End If

        If txttaller.Focused = True Then
            Dim frm As New FrmListaTaller
            frm.ShowDialog()
            txtidtaller.Text = frm.id_taller
            txttaller.Text = frm.taller
            txtequipo.Focus()
            Exit Sub
        End If

        If txtequipo.Focused = True Then
            Dim frm As New FrmListaEquipo
            frm.ShowDialog()
            txtidequipo.Text = frm.id_equipo
            txtequipo.Text = frm.equipo
            txttarea.Focus()
            Exit Sub
        End If

        If txttarea.Focused = True Then
            AgregaTarea()
            Exit Sub
        End If
    End Sub

    Sub AgregaTarea()
        Dim frm As New FrmListaTarea
        frm.ShowDialog()
        If frm.id_tarea = 0 Then Exit Sub
        For I As Int32 = 0 To dtTarea.Rows.Count - 1
            If frm.id_tarea = dtTarea.Rows(I)("ID_TAREA") Then
                Exit Sub
            End If
        Next
        Dim dr As DataRow
        dr = dtTarea.NewRow
        dr(0) = frm.id_tarea
        dr(1) = frm.tarea
        dr(2) = "Eliminar"
        dr(3) = 0
        dtTarea.Rows.Add(dr)
        gridTarea.DataSource = dtTarea
    End Sub

    Private Sub txttarea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttarea.KeyPress
        Buscar()
    End Sub

    Private Sub gridTarea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridTarea.Click
        Try
            If gridTarea.ActiveRow.Index < 0 Then Exit Sub
            txtsubtarea.ReadOnly = False
            habilitarcontrol(IIf(cierre = 1, True, False))
            txtsubtarea.Focus()
            ListaSubtareaID(gridTarea.ActiveRow.Cells("ID_TAREA").Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridTarea_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridTarea.ClickCell
        Try
            If gridTarea.ActiveRow.Cells(gridTarea.ActiveCell.Column.Index).Column.Key = "ELIMINAR" Then
                If cierre = 1 Then MsgBox("La planificación se encuentra cerrada", MsgBoxStyle.Information, "Validación") : Exit Sub
                If MsgBox("Seguro de eliminar la tarea?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                    If gridTarea.ActiveRow.Cells("ID_PLANIF_TAREA").Value <> 0 Then
                        Dim dtResultado As New DataTable
                        obj_Proyecto = New NGProyecto
                        obj_EProyecto = New ETProyecto
                        obj_EProyecto.Operacion = 3
                        obj_EProyecto.idplanificacion = txtid.Text
                        obj_EProyecto.idplanificacion_tarea = gridTarea.ActiveRow.Cells("ID_PLANIF_TAREA").Value
                        obj_EProyecto.idtarea = 0
                        obj_EProyecto.desc_tarea = ""
                        obj_EProyecto.Usuario = User_Sistema
                        dtResultado = obj_Proyecto.Mant_Pla_Tarea(obj_EProyecto)
                        cargaData_ID(txtid.Text)
                        gridTarea.Focus()
                        gridTarea.Rows(0).Cells(0).Activate()
                        gridTarea_Click(Nothing, Nothing)
                        Exit Sub
                    End If

                    dtTarea.Rows.RemoveAt(gridTarea.ActiveRow.Index)
                    Exit Sub
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub ListaSubtareaID(ByVal idtarea As Int32)
        Dim rows As DataRow()
        Dim dtNew As DataTable
        dtNew = dtSubTarea_Filtro.Clone()
        rows = dtSubTarea.Select("ID_TAREA=" & idtarea & "")
        dtSubTarea_Filtro.Rows.Clear()
        For Each dr As DataRow In rows
            dtSubTarea_Filtro.ImportRow(dr)
        Next
        gridsubtarea.DataSource = dtSubTarea_Filtro
    End Sub

    Sub AgregaSubTarea(ByVal idtarea As Int32)
        Dim ejecucion As Int32 = 0
        Dim tipo As String = ""
        ejecucion = cmbTipo.Value
        tipo = cmbTipo.Text
        For i As Int32 = 0 To dtSubTarea.Rows.Count - 1
            If txtsubtarea.Text = dtSubTarea.Rows(i)("SUBTAREA") And dtSubTarea.Rows(i)("ID_TAREA") = gridTarea.ActiveRow.Cells("ID_TAREA").Value Then
                MsgBox("No puede ingresar la misma sub-tarea 2 veces", MsgBoxStyle.Exclamation, "Validación")
                Exit Sub
            End If
        Next

        Dim dr As DataRow
        dr = dtSubTarea.NewRow
        dr(0) = idtarea
        dr(1) = 0
        dr(2) = txtsubtarea.Text
        dr(3) = "Eliminar"
        dr(4) = ""
        dr(5) = ejecucion
        dr(6) = tipo
        dr(7) = 0
        dtSubTarea.Rows.Add(dr)
        'dtSubTarea_Filtro = dtSubTarea.Clone
        'gridSubtarea.DataSource = dtSubTarea_Filtro
        'cmbTipo.ReadOnly = True
        txtsubtarea.Clear()
        txtsubtarea.Focus()
        ListaSubtareaID(idtarea)
    End Sub

    Sub Nuevo()
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        txtproyecto.Focus()
        Limpiar()
        LimpiarSubtareaDET()
    End Sub

    Sub Limpiar()
        txtproyecto.Clear()
        txttaller.Clear()
        txttarea.Clear()
        txtequipo.Clear()
        dtTarea.Rows.Clear()
        dtSubTarea.Rows.Clear()
        dtSubTarea_Filtro.Rows.Clear()
        dtPlano.Rows.Clear()
        txtid.Text = 0
        txtidproyecto.Text = 0
        txtidtaller.Text = 0
        txtidequipo.Text = 0
        txtplano.Clear()
        txtplanodet.Clear()
        dtPlanoDet.Rows.Clear()
        dtPersonal.Rows.Clear()
        dtMaterial.Rows.Clear()
        dtServicio.Rows.Clear()
        cmbTipo.ReadOnly = False
        cierre = 0
        habilitarcontrol(IIf(cierre = 1, True, False))
        txttotalsub.Text = "0.00"
        txttotpersona.Text = "0.00"
        txttotmaterial.Text = "0.00"
        txttotservicio.Text = "0.00"
    End Sub

    Sub LimpiarSubtareaDET()
        txtidplanifsub.Text = 0
        txtproyecto_det.Clear()
        txttaller_det.Clear()
        txtequipo_det.Clear()
        txtnota.Clear()
        dtPlanoDet.Rows.Clear()
        dtPersonal.Rows.Clear()
        dtMaterial.Rows.Clear()
        dtServicio.Rows.Clear()
        txtsubtareadet.Clear()
    End Sub

    Private Sub txtsubtarea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtsubtarea.KeyDown
        If e.KeyCode = 13 Then
            If txtsubtarea.Text.ToString.Trim = "" Then
                MsgBox("Ingrese nombre de sub-tarea", MsgBoxStyle.Exclamation, "Validación")
                txtsubtarea.Text = ""
                txtsubtarea.Focus()
                Exit Sub
            End If
            AgregaSubTarea(gridTarea.ActiveRow.Cells("ID_TAREA").Value)
        End If
    End Sub

    Private Sub gridSubtarea_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridsubtarea.ClickCell
        Try
            If gridsubtarea.ActiveRow.Cells(gridsubtarea.ActiveCell.Column.Index).Column.Key = "ELIMINAR" Then
                If cierre = 1 Then MsgBox("La planificación se encuentra cerrada", MsgBoxStyle.Information, "Validación") : Exit Sub
                If MsgBox("Seguro de eliminar la sub-tarea?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                    If gridsubtarea.ActiveRow.Cells("ID_PLANIF_SUBTAREA").Value <> 0 Then
                        'MsgBox(gridsubtarea.ActiveRow.Cells("ID_PLANIF_SUBTAREA").Value)
                        Dim dtResultado As New DataTable
                        obj_Proyecto = New NGProyecto
                        obj_EProyecto = New ETProyecto
                        obj_EProyecto.Operacion = 3
                        obj_EProyecto.idsubtarea = gridsubtarea.ActiveRow.Cells("ID_SUBTAREA").Value
                        obj_EProyecto.idproyecto = txtidproyecto.Text
                        obj_EProyecto.idtaller = txtidtaller.Text
                        obj_EProyecto.idequipo = txtidequipo.Text
                        obj_EProyecto.subtarea = gridsubtarea.ActiveRow.Cells("SUBTAREA").Value
                        obj_EProyecto.ejecucion = gridsubtarea.ActiveRow.Cells("EJECUCION").Value
                        obj_EProyecto.fechaini = dtFecha.Value
                        obj_EProyecto.Usuario = User_Sistema
                        obj_EProyecto.idplanificacion = txtid.Text
                        obj_EProyecto.idtarea = gridsubtarea.ActiveRow.Cells("ID_TAREA").Value
                        dtResultado = obj_Proyecto.Mant_SubTarea(obj_EProyecto)
                    End If

                    For i As Int32 = 0 To dtSubTarea.Rows.Count - 1
                        If dtSubTarea.Rows(i)("ID_TAREA") = gridTarea.ActiveRow.Cells("ID_TAREA").Value And dtSubTarea.Rows(i)("SUBTAREA") = gridsubtarea.ActiveRow.Cells("SUBTAREA").Value Then
                            dtSubTarea.Rows.RemoveAt(i)
                            Exit For
                        End If
                    Next
                    ListaSubtareaID(gridTarea.ActiveRow.Cells("ID_TAREA").Value)
                    Exit Sub
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridSubtarea_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridsubtarea.DoubleClickRow
        Try
            'If User_Sistema = "OROBLES" Then Exit Sub
            Dim numero As String
            numero = gridsubtarea.ActiveRow.Cells("NUMERO").Value
            If numero = "" Then
                MsgBox("Para ingresar detalle de sub-tarea debe tener numeración asignada", MsgBoxStyle.Exclamation, "Sistema")
                Exit Sub
            End If
            Tab1.Tabs("T03").Enabled = True
            Tab1.Tabs("T03").Selected = Boolean.TrueString
            UltraTabControl1.Tabs("T04").Selected = Boolean.TrueString
            DetalleSubatarea()
        Catch ex As Exception

        End Try
    End Sub

    Sub DetalleSubatarea()
        Call CargarUltraCombo(cmbTarea, dtTarea, "ID_PLANIF_TAREA", "DESC_TAREA")
        cmbTarea.Value = gridTarea.ActiveRow.Cells("ID_PLANIF_TAREA").Value
        txtidplanifsub.Text = gridsubtarea.ActiveRow.Cells("ID_PLANIF_SUBTAREA").Value
        Call CargarUltraCombo(cmbsubtarea, dtSubTarea_Filtro, "ID_SUBTAREA", "SUBTAREA")
        cmbsubtarea.Value = gridsubtarea.ActiveRow.Cells("ID_SUBTAREA").Value
        txtsubtareadet.Text = gridsubtarea.ActiveRow.Cells("SUBTAREA").Value
        txtproyecto_det.Text = txtproyecto.Text
        txttaller_det.Text = txttaller.Text
        txtequipo_det.Text = txtequipo.Text
        dtfechasubtarea.Value = Date.Now
        cargaDetalleSubtareaID(txtidplanifsub.Text)
    End Sub

    Sub cargaDetalleSubtareaID(ByVal id As Int32)
        dtPersonal.Rows.Clear()
        dtMaterial.Rows.Clear()
        dtServicio.Rows.Clear()
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.idplanisubtarea = id
        Dim dsData As New DataSet
        dsData = obj_Proyecto.Lista_DetSubtareaID(obj_EProyecto)
        dtPersonal = dsData.Tables(0)
        dtMaterial = dsData.Tables(1)
        dtServicio = dsData.Tables(2)
        dtPlanoDet = dsData.Tables(3)
        Dim dtDatos As New DataTable
        dtDatos = dsData.Tables(4)
        gridpersonal.DataSource = dtPersonal
        gridmaterial.DataSource = dtMaterial
        gridServicio.DataSource = dtServicio
        gridplanodet.DataSource = dtPlanoDet
        dtfechasubtarea.Value = dtDatos(0)("FECHAINI")
        txtnota.Text = dtDatos(0)("NOTA")
        CostoSubtarea()
    End Sub

    Private Sub cmbTarea_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbTarea.InitializeLayout
        With cmbTarea.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("DESC_TAREA").Width = sender.Width '300
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "DESC_TAREA") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub cmbsubtarea_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbsubtarea.InitializeLayout
        With cmbsubtarea.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("SUBTAREA").Width = 300 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "SUBTAREA") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub txtproyecto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtproyecto.KeyPress
        Buscar()
    End Sub

    Private Sub txttaller_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttaller.KeyPress
        Buscar()
    End Sub

    Private Sub txtequipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtequipo.KeyPress
        Buscar()
    End Sub

    Private Sub txtplanodet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtplanodet.KeyDown
        If e.KeyData = 13 Then
            For i As Int32 = 0 To gridplanodet.Rows.Count - 1
                If txtplanodet.Text = gridplanodet.Rows(i).Cells("PLANO").Value Then
                    Exit Sub
                End If
            Next
            txtplanodet.Text = txtplanodet.Text.ToString.Trim
            If validaPlanoDet(txtplanodet.Text) Then
                Dim dr As DataRow
                dr = dtPlanoDet.NewRow
                dr(0) = txtplanodet.Text
                dr(1) = "Eliminar"
                dr(2) = 0
                dtPlanoDet.Rows.Add(dr)
                gridplanodet.DataSource = dtPlanoDet
            Else
                MsgBox("El código de plano ingresado no existe", MsgBoxStyle.Exclamation, "Validación")
            End If
            txtplanodet.Clear()
            txtplanodet.Focus()
        End If
    End Sub

    Function validaPlanoDet(ByVal id_plano As String) As Boolean
        Dim dtPlano As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.idplano = id_plano
        dtPlano = obj_Proyecto.ValidaPlano(obj_EProyecto)
        If dtPlano.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub txtplano_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtplano.KeyDown
        If e.KeyData = 13 Then
            For i As Int32 = 0 To gridplano.Rows.Count - 1
                If txtplano.Text = gridplano.Rows(i).Cells("PLANO").Value Then
                    Exit Sub
                End If
            Next
            txtplano.Text = txtplano.Text.ToString.Trim
            If validaPlanoDet(txtplano.Text) Then
                Dim dr As DataRow
                dr = dtPlano.NewRow
                dr(0) = txtplano.Text
                dr(1) = "Eliminar"
                dr(2) = 0
                dtPlano.Rows.Add(dr)
                gridplano.DataSource = dtPlano
            Else
                MsgBox("El código de plano ingresado no existe", MsgBoxStyle.Exclamation, "Validación")
            End If
            txtplano.Clear()
            txtplano.Focus()
        End If
    End Sub

    Sub eliminar()
        If Tab1.Tabs("T02").Selected = Boolean.TrueString Then
            If txtid.Text = 0 Then MsgBox("Seleccione planificación a eliminar", MsgBoxStyle.Exclamation, "Validación") : Exit Sub
            If MsgBox("Desea eliminar planificación de tarea?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
            Dim dtResultado As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.Operacion = 3
            obj_EProyecto.idplanificacion = txtid.Text
            obj_EProyecto.idproyecto = txtidproyecto.Text
            obj_EProyecto.idtaller = txtidtaller.Text
            obj_EProyecto.idequipo = txtidequipo.Text
            obj_EProyecto.fechaini = dtFecha.Value
            obj_EProyecto.Usuario = User_Sistema
            dtResultado = obj_Proyecto.Mant_Planificacion(obj_EProyecto)
            If dtResultado.Rows.Count > 0 Then
                If dtResultado.Rows(0)(0) = "OK" Then
                    MsgBox("Planificación eliminada correctamente", MsgBoxStyle.Information, "Sistema")
                    Tab1.Tabs("T01").Selected = Boolean.TrueString
                    Limpiar()
                    LimpiarSubtareaDET()
                    Procesar()
                End If
            End If
        End If
    End Sub

    Sub Grabar()
        If cierre = 1 Then MsgBox("La planificación se encuentra cerrada", MsgBoxStyle.Information, "Validación") : Exit Sub
        If Tab1.Tabs("T02").Selected = Boolean.TrueString Then
            If Not validaPlanificacion() Then Exit Sub
            If MsgBox("Desea grabar planificación de tarea?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
            GrabaPlanificacion()
            If txtid.Text = 0 Then Exit Sub
            cargaData()
            cargaData_ID(txtid.Text)
            gridTarea.Focus()
            gridTarea.Rows(0).Cells(0).Activate()
            gridTarea_Click(Nothing, Nothing)
            MsgBox("Planeación grabada correctamente", MsgBoxStyle.Information, "Sistema")
        End If
        If Tab1.Tabs("T03").Selected = Boolean.TrueString Then
            If Not validaDetSubtarea() Then Exit Sub
            If MsgBox("Desea grabar detalle de sub-tarea?", MsgBoxStyle.YesNo, "Sistema") = MsgBoxResult.No Then Exit Sub
            GrabaDetalleSubtarea()
            cargaDetalleSubtareaID(txtidplanifsub.Text)
            MsgBox("Detalle de sub-tarea grabado correctamente", MsgBoxStyle.Information, "Sistema")
            Tab1.Tabs("T03").Enabled = False          
            'Limpiar()
            'LimpiarSubtareaDET()
            'Procesar()
            Tab1.Tabs("T02").Selected = Boolean.TrueString
        End If
    End Sub

    Sub GrabaDetalleSubtarea()
        CostoSubtarea()
        Dim dtResultado As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.Operacion = 1
        obj_EProyecto.idplanisubtarea = txtidplanifsub.Text
        obj_EProyecto.fechaini = dtfechasubtarea.Value
        obj_EProyecto.nota = txtnota.Text
        obj_EProyecto.subtarea = txtsubtareadet.Text
        obj_EProyecto.idplanificacion_tarea = cmbTarea.Value
        obj_EProyecto.Usuario = User_Sistema
        dtResultado = obj_Proyecto.Actu_Subtarea(obj_EProyecto)
        If dtResultado.Rows.Count > 0 Then
            If dtResultado.Rows(0)(0) = "OK" Then
            End If
        End If

        'Registramos planos 
        registroPlanoDet()
        'Registramos personal
        registroPersonal()
        'Registramos material
        registroMaterial()
        'Registramos servicio
        registroServicio()
    End Sub

    Sub registroPlanoDet()
        For i As Int32 = 0 To dtPlanoDet.Rows.Count - 1
            Dim dtResultado As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.Operacion = 1
            obj_EProyecto.idplanisubtarea = txtidplanifsub.Text
            obj_EProyecto.plano = dtPlanoDet.Rows(i)("PLANO")
            obj_EProyecto.idplanificacion_plano = dtPlanoDet.Rows(i)("ID_PLANIF_SUB_PLANO")
            obj_EProyecto.Usuario = User_Sistema
            dtResultado = obj_Proyecto.Mant_PlanoDET(obj_EProyecto)
        Next
    End Sub

    Sub registroServicio()
        For i As Int32 = 0 To dtServicio.Rows.Count - 1
            Dim dtResultado As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.Operacion = 1
            obj_EProyecto.idplanisubtarea = txtidplanifsub.Text
            obj_EProyecto.idsubservicio = dtServicio.Rows(i)("ID")
            obj_EProyecto.placod = dtServicio.Rows(i)("CODIGO")
            obj_EProyecto.Cantidad = dtServicio.Rows(i)("CANTIDAD")
            obj_EProyecto.precio = dtServicio.Rows(i)("PRECIO_SISTEMA")
            obj_EProyecto.precioestimado = dtServicio.Rows(i)("PRECIO_ESTIMADO")
            obj_EProyecto.Total = dtServicio.Rows(i)("TOTAL")
            obj_EProyecto.Usuario = User_Sistema
            dtResultado = obj_Proyecto.Mant_SubServicio(obj_EProyecto)
        Next
    End Sub

    Sub registroMaterial()
        For i As Int32 = 0 To dtMaterial.Rows.Count - 1
            Dim dtResultado As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.Operacion = 1
            obj_EProyecto.idplanisubtarea = txtidplanifsub.Text
            obj_EProyecto.idsubmaterial = dtMaterial.Rows(i)("ID")
            obj_EProyecto.placod = dtMaterial.Rows(i)("CODIGO")
            obj_EProyecto.Cantidad = dtMaterial.Rows(i)("CANTIDAD")
            obj_EProyecto.precio = dtMaterial.Rows(i)("PRECIO_SISTEMA")
            obj_EProyecto.precioestimado = dtMaterial.Rows(i)("PRECIO_ESTIMADO")
            obj_EProyecto.Total = dtMaterial.Rows(i)("TOTAL")
            obj_EProyecto.Usuario = User_Sistema
            dtResultado = obj_Proyecto.Mant_SubMaterial(obj_EProyecto)
        Next
    End Sub

    Sub registroPersonal()
        For i As Int32 = 0 To dtPersonal.Rows.Count - 1
            Dim dtResultado As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.Operacion = 1
            obj_EProyecto.idplanisubtarea = txtidplanifsub.Text
            obj_EProyecto.idsubpersonal = dtPersonal.Rows(i)("ID")
            obj_EProyecto.placod = dtPersonal.Rows(i)("CODIGO")
            obj_EProyecto.horas = dtPersonal.Rows(i)("HORAS")
            obj_EProyecto.precio = dtPersonal.Rows(i)("COSTO")
            obj_EProyecto.Total = dtPersonal.Rows(i)("TOTAL")
            obj_EProyecto.Usuario = User_Sistema
            dtResultado = obj_Proyecto.Mant_SubPersonal(obj_EProyecto)
        Next
    End Sub

    Public Function validaDetSubtarea() As Boolean
        If dtfechasubtarea.Value < dtFecha.Value Then
            MsgBox("La fecha de inicio de la sub-tarea no puede ser menor que la fecha inicio de planificación", MsgBoxStyle.Exclamation, "Validación")
            Return False
        End If
        'If gridplanodet.Rows.Count <= 0 Then MsgBox("Ingrese como mínimo 1 plano", MsgBoxStyle.Exclamation, "Validación") : Return False
        'If dtPersonal.Rows.Count <= 0 Then MsgBox("Ingrese como mínimo 1 personal", MsgBoxStyle.Exclamation, "Validación") : Return False
        'If dtMaterial.Rows.Count <= 0 Then MsgBox("Ingrese como mínimo 1 material", MsgBoxStyle.Exclamation, "Validación") : Return False
        'If dtServicio.Rows.Count <= 0 Then MsgBox("Ingrese como mínimo 1 servicio", MsgBoxStyle.Exclamation, "Validación") : Return False
        Return True
    End Function

    Sub GrabaPlanificacion()
        Dim dtResultado As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.Operacion = 1
        obj_EProyecto.idplanificacion = txtid.Text
        obj_EProyecto.idproyecto = txtidproyecto.Text
        obj_EProyecto.idtaller = txtidtaller.Text
        obj_EProyecto.idequipo = txtidequipo.Text
        obj_EProyecto.fechaini = dtFecha.Value
        obj_EProyecto.Usuario = User_Sistema
        obj_EProyecto.ejecucion = cmbTipo.Value
        dtResultado = obj_Proyecto.Mant_Planificacion(obj_EProyecto)
        If dtResultado.Rows.Count > 0 Then
            If dtResultado.Rows(0)(0) = "OK" Then
                txtid.Text = dtResultado.Rows(0)(1)
            Else
                MsgBox(dtResultado.Rows(0)(0), MsgBoxStyle.Exclamation, "Validación")
                txtid.Text = 0 : Exit Sub
            End If
        End If
        'Registramos planos 
        registroPlano()
        'Registramos la tarea 
        registroTarea()
        'Registramos la subtarea para obtener id y numeracion
        registraSubtarea()
    End Sub

    Sub registroPlano()
        For i As Int32 = 0 To dtPlano.Rows.Count - 1
            Dim dtResultado As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.Operacion = 1
            obj_EProyecto.idplanificacion = txtid.Text
            obj_EProyecto.plano = dtPlano.Rows(i)("PLANO")
            obj_EProyecto.idplanificacion_plano = dtPlano.Rows(i)("ID_PLANIF_PLANO")
            obj_EProyecto.Usuario = User_Sistema
            dtResultado = obj_Proyecto.Mant_Plano(obj_EProyecto)
        Next
    End Sub

    Sub registroTarea()
        For i As Int32 = 0 To dtTarea.Rows.Count - 1
            Dim dtResultado As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.Operacion = 1
            obj_EProyecto.idplanificacion = txtid.Text
            obj_EProyecto.idplanificacion_tarea = dtTarea.Rows(i)("ID_PLANIF_TAREA")
            obj_EProyecto.idtarea = dtTarea.Rows(i)("ID_TAREA")
            obj_EProyecto.desc_tarea = dtTarea.Rows(i)("DESC_TAREA")
            obj_EProyecto.Usuario = User_Sistema
            dtResultado = obj_Proyecto.Mant_Pla_Tarea(obj_EProyecto)
        Next
    End Sub

    Sub registraSubtarea()
        '@FECHA_INI DATETIME,
        For i As Int32 = 0 To dtSubTarea.Rows.Count - 1
            Dim dtResultado As New DataTable
            obj_Proyecto = New NGProyecto
            obj_EProyecto = New ETProyecto
            obj_EProyecto.Operacion = 1
            If dtSubTarea.Rows(i)("ID_PLANIF_SUBTAREA") = 0 Then
                obj_EProyecto.idsubtarea = dtSubTarea.Rows(i)("ID_SUBTAREA")
                obj_EProyecto.idproyecto = txtidproyecto.Text
                obj_EProyecto.idtaller = txtidtaller.Text
                obj_EProyecto.idequipo = txtidequipo.Text
                obj_EProyecto.subtarea = dtSubTarea.Rows(i)("SUBTAREA")
                obj_EProyecto.ejecucion = cmbTipo.Value 'dtSubTarea.Rows(i)("EJECUCION")
                obj_EProyecto.fechaini = Date.Now
                obj_EProyecto.Usuario = User_Sistema
                obj_EProyecto.idplanificacion = txtid.Text
                obj_EProyecto.idtarea = dtSubTarea.Rows(i)("ID_TAREA")
                dtResultado = obj_Proyecto.Mant_SubTarea(obj_EProyecto)
            End If
        Next
    End Sub

    Public Function validaPlanificacion() As Boolean
        If txtidproyecto.Text = 0 Then MsgBox("Seleccione proyecto", MsgBoxStyle.Exclamation, "Validación") : Return False
        If txtidtaller.Text = 0 Then MsgBox("Seleccione taller", MsgBoxStyle.Exclamation, "Validación") : Return False
        If txtidequipo.Text = 0 Then MsgBox("Seleccione equipo", MsgBoxStyle.Exclamation, "Validación") : Return False
        'If gridplano.Rows.Count <= 0 Then MsgBox("Ingrese como mínimo 1 plano", MsgBoxStyle.Exclamation, "Validación") : Return False
        If dtTarea.Rows.Count <= 0 Then MsgBox("Ingrese como mínimo 1 tarea", MsgBoxStyle.Exclamation, "Validación") : Return False
        If dtSubTarea.Rows.Count <= 0 Then MsgBox("Ingrese como mínimo 1 subtarea", MsgBoxStyle.Exclamation, "Validación") : Return False
        Return True
    End Function

    Private Sub rdbPlanificada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPlanificada.CheckedChanged
        txtsubtarea.Focus()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbnoPlanificada.CheckedChanged
        txtsubtarea.Focus()
    End Sub

    Private Sub rdbCorrectiva_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCorrectiva.CheckedChanged
        txtsubtarea.Focus()
    End Sub

    Private Sub gridProyecto_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridProyecto.DoubleClickRow
        Try
            Tab1.Tabs("T02").Selected = Boolean.TrueString
            txtid.Text = gridProyecto.ActiveRow.Cells("ID_PLANIFICACION").Value
            txtidproyecto.Text = gridProyecto.ActiveRow.Cells("ID_PROYECTO").Value
            txtidtaller.Text = gridProyecto.ActiveRow.Cells("ID_TALLER").Value
            txtidequipo.Text = gridProyecto.ActiveRow.Cells("ID_EQUIPO").Value
            txtproyecto.Text = gridProyecto.ActiveRow.Cells("PROYECTO").Value
            txttaller.Text = gridProyecto.ActiveRow.Cells("TALLER").Value
            txtequipo.Text = gridProyecto.ActiveRow.Cells("EQUIPO").Value
            dtFecha.Value = gridProyecto.ActiveRow.Cells("FECHA").Value
            cmbTipo.Value = gridProyecto.ActiveRow.Cells("EJECUCION").Value
            cierre = gridProyecto.ActiveRow.Cells("FLGCIERRE").Value
            cargaData_ID(txtid.Text)
            gridTarea.Focus()
            gridTarea.Rows(0).Cells(0).Activate()
            gridTarea_Click(Nothing, Nothing)
            Tab1.Tabs("T03").Enabled = False
            LimpiarSubtareaDET()
            cmbTipo.ReadOnly = True
            habilitarcontrol(IIf(cierre = 1, True, False))
        Catch ex As Exception

        End Try
    End Sub

    Sub habilitarcontrol(ByVal opc As Boolean)
        txtplano.ReadOnly = opc
        txtplanodet.ReadOnly = opc
        txtsubtarea.ReadOnly = opc
        txtnota.ReadOnly = opc
        dtFecha.ReadOnly = opc
        dtfechasubtarea.ReadOnly = opc
        cmbTipo.ReadOnly = opc
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        AgregaPersonal()
    End Sub

    Sub AgregaPersonal()
        If dtPersonal.Columns.Count <= 0 Then
            dtPersonal.Columns.Add("CODIGO")
            dtPersonal.Columns.Add("TRABAJADOR")
            dtPersonal.Columns.Add("HORAS")
            dtPersonal.Columns.Add("COSTO")
            dtPersonal.Columns.Add("TOTAL")
            dtPersonal.Columns.Add("ID")
        End If
        Dim frm As New FrmListaPersonal
        frm.ShowDialog()
        If frm.placod.ToString = "" Then Exit Sub
        For I As Int32 = 0 To gridpersonal.Rows.Count - 1
            If frm.placod = gridpersonal.Rows(I).Cells("CODIGO").Value.ToString Then
                Exit Sub
            End If
        Next
        Dim dr As DataRow
        dr = dtPersonal.NewRow
        dr(0) = frm.placod
        dr(1) = frm.trabajador
        dr(2) = "0.00"
        dr(3) = frm.soles_hora
        dr(4) = "0.00"
        dr(5) = 0
        dtPersonal.Rows.Add(dr)
        Call CargarUltraGrid(gridpersonal, dtPersonal)
        gridpersonal.Focus()
        gridpersonal.Rows(gridpersonal.Rows.Count - 1).Cells(0).Activate()
        gridpersonal.PerformAction(FirstCellInRow)
        gridpersonal.PerformAction(NextCellByTab)
        gridpersonal.PerformAction(NextCellByTab)
    End Sub

    Sub CostoSubtarea()
        CaluclaTotalPersonal()
        CaluclaTotalMaterial()
        CaluclaTotalServicio()
        Dim total_personal As Double = txttotpersona.Text
        Dim total_material As Double = txttotmaterial.Text
        Dim total_servicio As Double = txttotservicio.Text
        txttotalsub.Text = CDbl(total_personal + total_material + total_servicio).ToString("#0.00")
    End Sub

    Sub CaluclaTotalPersonal()
        Dim horas As Double = 0
        Dim costo As Double = 0
        Dim total As Double = 0
        Dim total_persona As Double = 0
        For i As Int32 = 0 To gridpersonal.Rows.Count - 1
            horas = gridpersonal.Rows(i).Cells("HORAS").Value
            costo = gridpersonal.Rows(i).Cells("COSTO").Value
            total = CDbl(horas * costo)
            total_persona = total_persona + total
            gridpersonal.Rows(i).Cells("TOTAL").Value = total
        Next
        txttotpersona.Text = CDbl(total_persona).ToString("#0.00")
    End Sub

    Sub CaluclaTotalMaterial()
        Dim cantidad As Double = 0
        Dim precio As Double = 0
        Dim precio_estimado As Double = 0
        Dim total As Double = 0
        Dim total_material As Double = 0
        For i As Int32 = 0 To gridmaterial.Rows.Count - 1
            cantidad = gridmaterial.Rows(i).Cells("CANTIDAD").Value
            precio = gridmaterial.Rows(i).Cells("PRECIO_SISTEMA").Value
            precio_estimado = gridmaterial.Rows(i).Cells("PRECIO_ESTIMADO").Value
            total = CDbl(cantidad * IIf(precio <> 0, precio, precio_estimado))
            total_material = total_material + total
            gridmaterial.Rows(i).Cells("TOTAL").Value = total
        Next
        txttotmaterial.Text = CDbl(total_material).ToString("#0.00")
    End Sub

    Sub CaluclaTotalServicio()
        Dim cantidad As Double = 0
        Dim precio As Double = 0
        Dim precio_estimado As Double = 0
        Dim total As Double = 0
        Dim total_servicio As Double = 0
        For i As Int32 = 0 To gridServicio.Rows.Count - 1
            cantidad = gridServicio.Rows(i).Cells("CANTIDAD").Value
            precio = gridServicio.Rows(i).Cells("PRECIO_SISTEMA").Value
            precio_estimado = gridServicio.Rows(i).Cells("PRECIO_ESTIMADO").Value
            total = CDbl(cantidad * IIf(precio <> 0, precio, precio_estimado))
            total_servicio = total_servicio + total
            gridServicio.Rows(i).Cells("TOTAL").Value = total
        Next
        txttotservicio.Text = CDbl(total_servicio).ToString("#0.00")
    End Sub

    Private Sub gridpersonal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridpersonal.KeyDown, gridmaterial.KeyDown, gridServicio.KeyDown
        Try
            If sender Is Nothing OrElse e Is Nothing Then
                Return
            End If
            'If Not (sender Is gridpersonal) Then Return
            With sender
                Select Case e.KeyValue
                    Case 45
                        e.Handled = True
                        Return
                    Case Keys.Up
                        .PerformAction(ExitEditMode)
                        .PerformAction(AboveCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Down
                        .PerformAction(ExitEditMode)
                        .PerformAction(BelowCell)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Right
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Left
                        .PerformAction(ExitEditMode)
                        .PerformAction(PrevCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                    Case Keys.Return
                        .PerformAction(ExitEditMode)
                        .PerformAction(NextCellByTab)
                        e.Handled = Boolean.TrueString
                        .PerformAction(EnterEditMode)
                        'If sender Is gridpersonal Then
                        '    CaluclaTotalPersonal()
                        'End If
                        'If sender Is gridmaterial Then
                        '    CaluclaTotalMaterial()
                        'End If
                        'If sender Is gridServicio Then
                        '    CaluclaTotalServicio()
                        'End If
                        CostoSubtarea()
                End Select

            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If cierre = 1 Then MsgBox("La planificación se encuentra cerrada", MsgBoxStyle.Information, "Validación") : Exit Sub
        AgregaPersonal()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If cierre = 1 Then MsgBox("La planificación se encuentra cerrada", MsgBoxStyle.Information, "Validación") : Exit Sub
        AgregaMaterial()
    End Sub
    Sub AgregaMaterial()
        If dtMaterial.Columns.Count <= 0 Then
            dtMaterial.Columns.Add("CODIGO")
            dtMaterial.Columns.Add("PRODUCTO")
            dtMaterial.Columns.Add("UNIDAD")
            dtMaterial.Columns.Add("CANTIDAD")
            dtMaterial.Columns.Add("PRECIO_SISTEMA")
            dtMaterial.Columns.Add("PRECIO_ESTIMADO")
            dtMaterial.Columns.Add("TOTAL")
            dtMaterial.Columns.Add("ID")
        End If
        Dim frm As New FrmListaMaterial
        frm.ShowDialog()
        If frm.codproducto.ToString = "" Then Exit Sub
        For I As Int32 = 0 To gridmaterial.Rows.Count - 1
            If frm.codproducto = gridmaterial.Rows(I).Cells("CODIGO").Value.ToString Then
                Exit Sub
            End If
        Next
        Dim dtCosto As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.codprod = frm.codproducto
        Dim dsData As New DataSet
        dtCosto = obj_Proyecto.Costo_Material(obj_EProyecto)
        Dim costo As Double = "0.00"
        If dtCosto.Rows.Count > 0 Then
            costo = IIf(dtCosto.Rows(0)(0) <> 0, dtCosto.Rows(0)(0), dtCosto.Rows(0)(1))
        End If
        'If costo = 0 Then
        '    gridmaterial.Rows.Band.Columns("PRECIO_SISTEMA").CellActivation = Activation.ActivateOnly
        '    gridmaterial.Rows.Band.Columns("PRECIO_ESTIMADO").CellActivation = Activation.AllowEdit
        'Else
        '    gridmaterial.Rows.Band.Columns("PRECIO_SISTEMA").CellActivation = Activation.AllowEdit
        '    gridmaterial.Rows.Band.Columns("PRECIO_ESTIMADO").CellActivation = Activation.ActivateOnly
        'End If
        Dim dr As DataRow
        dr = dtMaterial.NewRow
        dr(0) = frm.codproducto
        dr(1) = frm.producto
        dr(2) = frm.unidad
        dr(3) = "0.00"
        dr(4) = costo
        dr(5) = "0.00"
        dr(6) = "0.00"
        dr(7) = 0
        dtMaterial.Rows.Add(dr)
        Call CargarUltraGrid(gridmaterial, dtMaterial)
        gridmaterial.Focus()
        gridmaterial.Rows(gridmaterial.Rows.Count - 1).Cells(0).Activate()
        gridmaterial.PerformAction(FirstCellInRow)
        gridmaterial.PerformAction(NextCellByTab)
        gridmaterial.PerformAction(NextCellByTab)
        gridmaterial.PerformAction(NextCellByTab)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If cierre = 1 Then MsgBox("La planificación se encuentra cerrada", MsgBoxStyle.Information, "Validación") : Exit Sub
        AgregaServicio()
    End Sub
    Sub AgregaServicio()
        If dtServicio.Columns.Count <= 0 Then
            dtServicio.Columns.Add("CODIGO")
            dtServicio.Columns.Add("SERVICIO")
            dtServicio.Columns.Add("CANTIDAD")
            dtServicio.Columns.Add("PRECIO_SISTEMA")
            dtServicio.Columns.Add("PRECIO_ESTIMADO")
            dtServicio.Columns.Add("TOTAL")
            dtServicio.Columns.Add("ID")
        End If
        Dim frm As New FrmListaServicio
        frm.ShowDialog()
        If frm.codigo.ToString = "" Then Exit Sub
        For I As Int32 = 0 To gridServicio.Rows.Count - 1
            If frm.codigo = gridServicio.Rows(I).Cells("CODIGO").Value.ToString Then
                Exit Sub
            End If
        Next
        Dim dtCosto As New DataTable
        obj_Proyecto = New NGProyecto
        obj_EProyecto = New ETProyecto
        obj_EProyecto.codprod = frm.codigo
        Dim dsData As New DataSet
        dtCosto = obj_Proyecto.Costo_Servicio(obj_EProyecto)
        Dim costo As Double = "0.00"
        If dtCosto.Rows.Count > 0 Then
            costo = dtCosto.Rows(0)(0)
        End If

        Dim dr As DataRow
        dr = dtServicio.NewRow
        dr(0) = frm.codigo
        dr(1) = frm.servicio
        dr(2) = "0.00"
        dr(3) = costo
        dr(4) = "0.00"
        dr(5) = "0.00"
        dr(6) = 0
        dtServicio.Rows.Add(dr)
        Call CargarUltraGrid(gridServicio, dtServicio)
        gridServicio.Focus()
        gridServicio.Rows(gridServicio.Rows.Count - 1).Cells(0).Activate()
        gridServicio.PerformAction(FirstCellInRow)
        gridServicio.PerformAction(NextCellByTab)
        gridServicio.PerformAction(NextCellByTab)
        'gridServicio.PerformAction(NextCellByTab)
    End Sub

    Private Sub gridmaterial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gridmaterial.KeyPress, gridServicio.KeyPress
        Try
            If sender Is gridmaterial Or sender Is gridServicio Then
                If sender.ActiveRow.Cells("PRECIO_SISTEMA").Value.ToString = 0 Then
                    sender.Rows.Band.Columns("PRECIO_SISTEMA").CellActivation = Activation.ActivateOnly
                    sender.Rows.Band.Columns("PRECIO_ESTIMADO").CellActivation = Activation.AllowEdit
                Else
                    sender.Rows.Band.Columns("PRECIO_SISTEMA").CellActivation = Activation.AllowEdit
                    sender.Rows.Band.Columns("PRECIO_ESTIMADO").CellActivation = Activation.ActivateOnly
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If cierre = 1 Then MsgBox("La planificación se encuentra cerrada", MsgBoxStyle.Information, "Validación") : Exit Sub
        If MsgBox("Seguro de eliminar personal?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
            If gridpersonal.ActiveRow.Cells("ID").Value <> 0 Then
                Dim dtResultado As New DataTable
                obj_Proyecto = New NGProyecto
                obj_EProyecto = New ETProyecto
                obj_EProyecto.Operacion = 3
                obj_EProyecto.idplanisubtarea = txtidplanifsub.Text
                obj_EProyecto.idsubpersonal = gridpersonal.ActiveRow.Cells("ID").Value
                obj_EProyecto.placod = ""
                obj_EProyecto.horas = 0
                obj_EProyecto.precio = 0
                obj_EProyecto.Total = 0
                obj_EProyecto.Usuario = User_Sistema
                dtResultado = obj_Proyecto.Mant_SubPersonal(obj_EProyecto)
                cargaDetalleSubtareaID(txtidplanifsub.Text)
                Exit Sub
            End If
            dtPersonal.Rows.RemoveAt(gridpersonal.ActiveRow.Index)
            Exit Sub
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If cierre = 1 Then MsgBox("La planificación se encuentra cerrada", MsgBoxStyle.Information, "Validación") : Exit Sub
        If MsgBox("Seguro de eliminar material?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
            If gridmaterial.ActiveRow.Cells("ID").Value <> 0 Then
                Dim dtResultado As New DataTable
                obj_Proyecto = New NGProyecto
                obj_EProyecto = New ETProyecto
                obj_EProyecto.Operacion = 3
                obj_EProyecto.idplanisubtarea = txtidplanifsub.Text
                obj_EProyecto.idsubmaterial = gridmaterial.ActiveRow.Cells("ID").Value
                obj_EProyecto.placod = ""
                obj_EProyecto.Cantidad = 0
                obj_EProyecto.precio = 0
                obj_EProyecto.precioestimado = 0
                obj_EProyecto.Total = 0
                obj_EProyecto.Usuario = User_Sistema
                dtResultado = obj_Proyecto.Mant_SubMaterial(obj_EProyecto)
                cargaDetalleSubtareaID(txtidplanifsub.Text)
            Else
                dtMaterial.Rows.RemoveAt(gridmaterial.ActiveRow.Index)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If cierre = 1 Then MsgBox("La planificación se encuentra cerrada", MsgBoxStyle.Information, "Validación") : Exit Sub
        If MsgBox("Seguro de eliminar servicio?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
            If gridServicio.ActiveRow.Cells("ID").Value <> 0 Then
                Dim dtResultado As New DataTable
                obj_Proyecto = New NGProyecto
                obj_EProyecto = New ETProyecto
                obj_EProyecto.Operacion = 3
                obj_EProyecto.idplanisubtarea = txtidplanifsub.Text
                obj_EProyecto.idsubservicio = gridServicio.ActiveRow.Cells("ID").Value
                obj_EProyecto.placod = ""
                obj_EProyecto.Cantidad = 0
                obj_EProyecto.precio = 0
                obj_EProyecto.precioestimado = 0
                obj_EProyecto.Total = 0
                obj_EProyecto.Usuario = User_Sistema
                dtResultado = obj_Proyecto.Mant_SubServicio(obj_EProyecto)
                cargaDetalleSubtareaID(txtidplanifsub.Text)
            Else
                dtServicio.Rows.RemoveAt(gridServicio.ActiveRow.Index)
                Exit Sub
            End If

        End If
    End Sub
    Private Sub gridplano_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridplano.ClickCell
        Try
            If gridplano.ActiveRow.Cells(gridplano.ActiveCell.Column.Index).Column.Key = "ELIMINAR" Then
                If cierre = 1 Then MsgBox("La planificación se encuentra cerrada", MsgBoxStyle.Information, "Validación") : Exit Sub
                If MsgBox("Seguro de eliminar el plano?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                    If gridplano.ActiveRow.Cells("ID_PLANIF_PLANO").Value <> 0 Then
                        Dim dtResultado As New DataTable
                        obj_Proyecto = New NGProyecto
                        obj_EProyecto = New ETProyecto
                        obj_EProyecto.Operacion = 3
                        obj_EProyecto.idplanificacion = txtid.Text
                        obj_EProyecto.plano = ""
                        obj_EProyecto.idplanificacion_plano = gridplano.ActiveRow.Cells("ID_PLANIF_PLANO").Value
                        obj_EProyecto.Usuario = User_Sistema
                        dtResultado = obj_Proyecto.Mant_Plano(obj_EProyecto)
                        dtPlano.Rows.RemoveAt(gridplano.ActiveRow.Index)
                        Exit Sub
                    Else
                        dtPlano.Rows.RemoveAt(gridplano.ActiveRow.Index)
                        Exit Sub
                    End If
                    'dtPlano.Rows.RemoveAt(gridplano.ActiveRow.Index)
                    'Exit Sub
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridplanodet_ClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridplanodet.ClickCell
        Try
            If gridplanodet.ActiveRow.Cells(gridplanodet.ActiveCell.Column.Index).Column.Key = "ELIMINAR" Then
                If cierre = 1 Then MsgBox("La planificación se encuentra cerrada", MsgBoxStyle.Information, "Validación") : Exit Sub
                If MsgBox("Seguro de eliminar el plano?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                    If gridplanodet.ActiveRow.Cells("ID_PLANIF_SUB_PLANO").Value <> 0 Then
                        Dim dtResultado As New DataTable
                        obj_Proyecto = New NGProyecto
                        obj_EProyecto = New ETProyecto
                        obj_EProyecto.Operacion = 3
                        obj_EProyecto.idplanisubtarea = txtidplanifsub.Text
                        obj_EProyecto.plano = ""
                        obj_EProyecto.idplanificacion_plano = gridplanodet.ActiveRow.Cells("ID_PLANIF_SUB_PLANO").Value
                        obj_EProyecto.Usuario = User_Sistema
                        dtResultado = obj_Proyecto.Mant_PlanoDET(obj_EProyecto)
                        cargaDetalleSubtareaID(txtidplanifsub.Text)
                        Exit Sub
                    Else
                        dtPlanoDet.Rows.RemoveAt(gridplanodet.ActiveRow.Index)
                        Exit Sub
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtfechasubtarea_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtfechasubtarea.ValueChanged
        If dtfechasubtarea.Value < dtFecha.Value Then
            MsgBox("La fecha de inicio de la sub-tarea no puede ser menor que la fecha inicio de proyecto", MsgBoxStyle.Exclamation, "Validación")
            Exit Sub
        End If
    End Sub

    Private Sub cmbTipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.ValueChanged
        Try
            For Each Fila As DataRow In dtSubTarea.Rows
                Fila.SetField("EJECUCION", cmbTipo.Value)
                Fila.SetField("TIPO", cmbTipo.Text)
            Next
            gridTarea_Click(Nothing, Nothing)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridplano_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles gridplano.DoubleClickCell
        Try
            Dim plano As String = ""
            If gridplano.ActiveRow.Cells(gridplano.ActiveCell.Column.Index).Column.Key = "PLANO" Then
                plano = gridplano.ActiveRow.Cells("PLANO").Value
                Dim dtPlano As New DataTable
                obj_Proyecto = New NGProyecto
                obj_EProyecto = New ETProyecto
                obj_EProyecto.idplano = plano
                dtPlano = obj_Proyecto.ValidaPlano(obj_EProyecto)
                If dtPlano.Rows.Count > 0 Then
                    Dim RUTA As String = dtPlano.Rows(0)("PATHAUTOCAD")
                    Process.Start(RUTA)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub gridplanodet_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles gridplanodet.DoubleClickCell
        Try
            Dim plano As String = ""
            If gridplanodet.ActiveRow.Cells(gridplanodet.ActiveCell.Column.Index).Column.Key = "PLANO" Then
                plano = gridplanodet.ActiveRow.Cells("PLANO").Value

                Dim dtPlano As New DataTable
                obj_Proyecto = New NGProyecto
                obj_EProyecto = New ETProyecto
                obj_EProyecto.idplano = plano
                dtPlano = obj_Proyecto.ValidaPlano(obj_EProyecto)
                If dtPlano.Rows.Count > 0 Then
                    Dim RUTA As String = dtPlano.Rows(0)("PATHAUTOCAD")
                    Process.Start(RUTA)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If cierre = 1 Then MsgBox("La planificación se encuentra cerrada", MsgBoxStyle.Information, "Validación") : Exit Sub
        AgregaPersonalExt()
    End Sub
    Sub AgregaPersonalExt()
        If dtPersonal.Columns.Count <= 0 Then
            dtPersonal.Columns.Add("CODIGO")
            dtPersonal.Columns.Add("TRABAJADOR")
            dtPersonal.Columns.Add("HORAS")
            dtPersonal.Columns.Add("COSTO")
            dtPersonal.Columns.Add("TOTAL")
            dtPersonal.Columns.Add("ID")
        End If
        Dim frm As New FrmPersonalExterno
        frm.ShowDialog()
        If frm.placod.ToString = "" Then Exit Sub
        For I As Int32 = 0 To gridpersonal.Rows.Count - 1
            If frm.placod = gridpersonal.Rows(I).Cells("CODIGO").Value.ToString Then
                Exit Sub
            End If
        Next
        Dim dr As DataRow
        dr = dtPersonal.NewRow
        dr(0) = frm.placod
        dr(1) = frm.trabajador
        dr(2) = "0.00"
        dr(3) = "0.00"
        dr(4) = "0.00"
        dr(5) = 0
        dtPersonal.Rows.Add(dr)
        Call CargarUltraGrid(gridpersonal, dtPersonal)
        gridpersonal.Focus()
        gridpersonal.Rows(gridpersonal.Rows.Count - 1).Cells(0).Activate()
        gridpersonal.PerformAction(FirstCellInRow)
        gridpersonal.PerformAction(NextCellByTab)
        gridpersonal.PerformAction(NextCellByTab)
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If cierre = 1 Then MsgBox("La planificación se encuentra cerrada", MsgBoxStyle.Information, "Validación") : Exit Sub
        Dim frm_subtarea As New FrmListaSubtarea
        frm_subtarea.idtarea = gridTarea.ActiveRow.Cells("ID_TAREA").Value
        frm_subtarea.ShowDialog()
        AgregaSubTareaExist(gridTarea.ActiveRow.Cells("ID_TAREA").Value, frm_subtarea.idsubtarea, frm_subtarea.subtarea, frm_subtarea.numero)
    End Sub

    Sub AgregaSubTareaExist(ByVal idtarea As Int32, ByVal idsubtarea As Int32, ByVal subtarea As String, ByVal numero As String)
        If subtarea = "" Or idsubtarea = 0 Then
            'MsgBox("Ingrese nombre de sub-tarea", MsgBoxStyle.Exclamation, "Validación")
            txtsubtarea.Text = ""
            txtsubtarea.Focus()
            Exit Sub
        End If
        Dim ejecucion As Int32 = 0
        Dim tipo As String = ""
        ejecucion = cmbTipo.Value
        tipo = cmbTipo.Text
        For i As Int32 = 0 To dtSubTarea.Rows.Count - 1
            If subtarea = dtSubTarea.Rows(i)("SUBTAREA") And idtarea = gridTarea.ActiveRow.Cells("ID_TAREA").Value Then
                MsgBox("No puede ingresar la misma sub-tarea 2 veces", MsgBoxStyle.Exclamation, "Validación")
                Exit Sub
            End If
        Next

        Dim dr As DataRow
        dr = dtSubTarea.NewRow
        dr(0) = idtarea
        dr(1) = idsubtarea
        dr(2) = subtarea
        dr(3) = "Eliminar"
        dr(4) = numero
        dr(5) = ejecucion
        dr(6) = tipo
        dr(7) = 0
        dtSubTarea.Rows.Add(dr)
        txtsubtarea.Clear()
        txtsubtarea.Focus()
        ListaSubtareaID(idtarea)
    End Sub

    Private Sub gridsubtarea_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridsubtarea.InitializeLayout

    End Sub

    Private Sub gridTarea_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridTarea.InitializeLayout

    End Sub

    Private Sub Tab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles Tab1.SelectedTabChanged

    End Sub

    Private Sub gridProyecto_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridProyecto.InitializeLayout

    End Sub

    Private Sub dtFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFecha.ValueChanged

    End Sub
End Class