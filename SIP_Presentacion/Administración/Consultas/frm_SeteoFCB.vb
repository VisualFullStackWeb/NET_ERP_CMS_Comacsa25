Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.IO
Imports System.Text

Public Class frm_SeteoFCB

    Dim Ent As New ETFCB
    Dim Negocio As New NGFCB
    Public Ls_Permisos As New List(Of Integer)
    Private Ls_Entrega As List(Of ETFCB) = Nothing


    Private Sub Activa_Edicion(ByVal Accion As Integer, ByVal iTab As Integer)

        GrupoGrupos.Enabled = False
        GrupoConceptos.Enabled = False
        GroupProv.Enabled = False
        GroupNat.Enabled = False
        Groupfile.Enabled = False
        GroupBoxDoc.Enabled = False
        GroupSub.Enabled = False

        Tab_Hoja_Costo_Mantenimiento.Visible = True
        Tab_Hoja_Costo_Mantenimiento.Tabs(0).Visible = False
        Tab_Hoja_Costo_Mantenimiento.Tabs(1).Visible = False
        Tab_Hoja_Costo_Mantenimiento.Tabs(2).Visible = False
        Tab_Hoja_Costo_Mantenimiento.Tabs(3).Visible = False
        Tab_Hoja_Costo_Mantenimiento.Tabs(4).Visible = False
        Tab_Hoja_Costo_Mantenimiento.Tabs(5).Visible = False
        Tab_Hoja_Costo_Mantenimiento.Tabs(6).Visible = False
        Tab_Hoja_Costo_Mantenimiento.Tabs(7).Visible = False
        Tab_Hoja_Costo_Mantenimiento.Tabs(8).Visible = False
        Tab_Hoja_Costo_Mantenimiento.Tabs(iTab).Visible = True
        Tab_Hoja_Costo_Mantenimiento.SelectedTab = Tab_Hoja_Costo_Mantenimiento.Tabs(iTab)

        If iTab = 0 Then 'Grupos
            TxtNombregrupo.Text = ""
            LblIdCuadro.Text = ""
            TxtNombregrupo.Focus()
            If Accion = 2 Then
                LblIdCuadro.Text = Trim(GrdGrupos.ActiveRow.Cells("gru_id").Value & "")
                TxtNombregrupo.Text = Trim(GrdGrupos.ActiveRow.Cells("gru_descripcion").Value & "")
                Dim v_ing As Integer
                v_ing = GrdGrupos.ActiveRow.Cells("ingreso").Value

                If v_ing = 1 Then
                    Rbt_ingreso.Checked = True
                Else
                    Rbt_egreso.Checked = True
                End If

            End If
        ElseIf iTab = 1 Then ' Sub Grupos
            txt_subgrupo.Text = ""
            LblIdConcepto.Text = ""
            Me.lbl_idsubgrupo.Text = ""
            Call Combo_Grupos()
            Me.cmb_gruposel.Value = Trim(GrdGrupos.ActiveRow.Cells("gru_id").Value & "")
            Me.cmb_gruposel.Enabled = False
            Me.txt_subgrupo.Focus()
            If Accion = 2 Then
                Me.cmb_gruposel.Enabled = True
                Me.lbl_idsubgrupo.Text = Trim(GridSubGrupo.ActiveRow.Cells("sg_id").Value & "")
                Me.txt_subgrupo.Text = Trim(GridSubGrupo.ActiveRow.Cells("sg_descripcion").Value & "")
                Me.cmb_gruposel.Value = Trim(GridSubGrupo.ActiveRow.Cells("gru_id").Value & "") ''

            End If
        ElseIf iTab = 2 Then ' conceptos
            TxtConcepto.Text = ""
            LblIdConcepto.Text = ""
            Check_dcambio.Checked = False
            Check_dprov.Checked = False
            Call Combo_Grupos()
            Call Combo_SubGrupos()
            Me.cmb_grupo.Value = Trim(GridSubGrupo.ActiveRow.Cells("gru_id").Value & "")
            Me.cmb_grupo.Enabled = False
            Me.cmb_subgr.Value = Trim(GridSubGrupo.ActiveRow.Cells("sg_id").Value & "")
            Me.cmb_subgr.Enabled = False
            TxtConcepto.Focus()

            Dim dt_clases As New DataTable

            dt_clases = Negocio.Validardcambio(1)

            If dt_clases.Rows.Count > 0 Then
                Check_dcambio.Enabled = False
            Else
                Check_dcambio.Enabled = True
            End If
            '
            dt_clases = Nothing
            dt_clases = Negocio.Validardcambio(2)

            If dt_clases.Rows.Count > 0 Then
                Check_dprov.Enabled = False
            Else
                Check_dprov.Enabled = True
            End If
            '

            If Accion = 2 Then
                '  Me.cmb_grupo.Enabled = True
                Dim lvdcambio, lvdprov As Integer
                LblIdConcepto.Text = Trim(GrdConcep.ActiveRow.Cells("con_id").Value & "")
                Me.TxtConcepto.Text = Trim(GrdConcep.ActiveRow.Cells("con_descripcion").Value & "")
                Me.cmb_grupo.Value = Trim(GrdGrupos.ActiveRow.Cells("gru_id").Value & "") ''
                lvdcambio = GrdConcep.ActiveRow.Cells("dcambio").Value
                lvdprov = GrdConcep.ActiveRow.Cells("dprov").Value
                Dim lvpos As Integer
                lvpos = GrdConcep.ActiveRow.Cells("positivo").Value
                If lvpos = 1 Then
                    rad_signo_positivo.Checked = True
                Else
                    rad_signo_negativo.Checked = True
                End If

                If lvdcambio = 1 Then
                    Check_dcambio.Enabled = True
                    Check_dcambio.Checked = True
                Else
                    Check_dcambio.Checked = False
                End If

                If lvdprov = 1 Then
                    Check_dprov.Enabled = True
                    Check_dprov.Checked = True
                Else
                    Check_dprov.Checked = False
                End If

            End If
        ElseIf iTab = 3 Then 'proveedor
            lbl_idgrupo.Text = ""
            lbl_idsubg_prov.Text = ""
            lbl_idconcepto.Text = ""
            UltraTextgrupo.Text = ""
            UltraTextConcepto.Text = ""

            lbl_idgrupo.Text = Me.GrdConcep.ActiveRow.Cells("gru_id").Value
            lbl_idsubg_prov.Text = Me.GrdConcep.ActiveRow.Cells("sg_id").Value
            lbl_idconcepto.Text = Me.GrdConcep.ActiveRow.Cells("con_id").Value

            UltraTextgrupo.Text = Me.GrdGrupos.ActiveRow.Cells("gru_descripcion").Value.ToString
            txtsubgr_prov.Text = Me.GridSubGrupo.ActiveRow.Cells("sg_descripcion").Value.ToString
            UltraTextConcepto.Text = Me.GrdConcep.ActiveRow.Cells("con_descripcion").Value
            Grid1Prov.DataSource = Negocio.ListarProveedores(Integer.Parse(lbl_idgrupo.Text), Integer.Parse(lbl_idconcepto.Text), Companhia, 1)
        ElseIf iTab = 4 Then ' Naturaleza
            lbl_idgruponat.Text = ""
            lbl_idsubg_nat.Text = ""
            lbl_idconcepnat.Text = ""
            txtgruponat.Text = ""
            txtconcepnat.Text = ""

            lbl_idgruponat.Text = Me.GrdConcep.ActiveRow.Cells("gru_id").Value
            lbl_idsubg_nat.Text = Me.GrdConcep.ActiveRow.Cells("sg_id").Value
            lbl_idconcepnat.Text = Me.GrdConcep.ActiveRow.Cells("con_id").Value
            txtgruponat.Text = Me.GrdGrupos.ActiveRow.Cells("gru_descripcion").Value.ToString ''
            txtsubgr_nat.Text = Me.GridSubGrupo.ActiveRow.Cells("sg_descripcion").Value.ToString
            txtconcepnat.Text = Me.GrdConcep.ActiveRow.Cells("con_descripcion").Value
            Cmb_naturaleza.DataSource = Negocio.ListarNaturaleza(Companhia)
            Me.Cmb_naturaleza.ValueMember = "codigo"
            Me.Cmb_naturaleza.DisplayMember = "descripcion"
            'Grid_selnat.DataSource = Negocio.ListarProveedores(Integer.Parse(lbl_idgruponat.Text), Integer.Parse(lbl_idconcepnat.Text), Companhia, 2)
        ElseIf iTab = 5 Then 'File
            lbl_idgrupofile.Text = ""
            lbl_idconcepfile.Text = ""
            txtgrupofile.Text = ""
            txtconcepfile.Text = ""

            lbl_idgrupofile.Text = Me.GrdConcep.ActiveRow.Cells("gru_id").Value
            lbl_idsubg_file.Text = Me.GrdConcep.ActiveRow.Cells("sg_id").Value
            lbl_idconcepfile.Text = Me.GrdConcep.ActiveRow.Cells("con_id").Value
            txtgrupofile.Text = Me.GrdGrupos.ActiveRow.Cells("gru_descripcion").Value.ToString ''
            txtsubgr_file.Text = Me.GridSubGrupo.ActiveRow.Cells("sg_descripcion").Value.ToString
            txtconcepfile.Text = Me.GrdConcep.ActiveRow.Cells("con_descripcion").Value
            Gridselfile.DataSource = Negocio.ListarProveedores(Integer.Parse(lbl_idgrupofile.Text), Integer.Parse(lbl_idconcepfile.Text), Companhia, 3)
            ''
        ElseIf iTab = 6 Then 'Documento
            lbl_idgrupodoc.Text = ""
            lbl_idsubg_doc.Text = ""
            lbl_idconcepdoc.Text = ""
            txtgrupodoc.Text = ""
            txtconceptodoc.Text = ""

            lbl_idgrupodoc.Text = Me.GrdConcep.ActiveRow.Cells("gru_id").Value
            lbl_idsubg_doc.Text = Me.GrdConcep.ActiveRow.Cells("sg_id").Value
            lbl_idconcepdoc.Text = Me.GrdConcep.ActiveRow.Cells("con_id").Value
            txtgrupodoc.Text = Me.GrdGrupos.ActiveRow.Cells("gru_descripcion").Value.ToString ''
            txtsubgr_doc.Text = Me.GridSubGrupo.ActiveRow.Cells("sg_descripcion").Value.ToString
            txtconceptodoc.Text = Me.GrdConcep.ActiveRow.Cells("con_descripcion").Value
            Gridseldoc.DataSource = Negocio.ListarProveedores(Integer.Parse(lbl_idgrupodoc.Text), Integer.Parse(lbl_idconcepdoc.Text), Companhia, 4)

        ElseIf iTab = 7 Then 'Doc Bancario
            lbl_idgrupodbanc.Text = ""
            lbl_idsubgdbanc.Text = ""
            lbl_idconcepdbanc.Text = ""
            txtgrupodbanc.Text = ""
            txtconceptodbanc.Text = ""

            lbl_idgrupodbanc.Text = Me.GrdConcep.ActiveRow.Cells("gru_id").Value
            lbl_idsubgdbanc.Text = Me.GrdConcep.ActiveRow.Cells("sg_id").Value
            lbl_idconcepdbanc.Text = Me.GrdConcep.ActiveRow.Cells("con_id").Value
            txtgrupodbanc.Text = Me.GrdGrupos.ActiveRow.Cells("gru_descripcion").Value.ToString ''
            txtsubgr_dbanc.Text = Me.GridSubGrupo.ActiveRow.Cells("sg_descripcion").Value.ToString
            txtconceptodbanc.Text = Me.GrdConcep.ActiveRow.Cells("con_descripcion").Value
            Cmb_tipo.DataSource = Negocio.ListarTipos()
            Me.Cmb_tipo.ValueMember = "tip_id"
            Me.Cmb_tipo.DisplayMember = "tip_desc"

        ElseIf iTab = 8 Then 'CtaCte
            lbl_idgrupoctacte.Text = ""
            lbl_idsubgctacte.Text = ""
            lbl_idconcepctacte.Text = ""
            txtgrupocta.Text = ""
            txtconcep_cta.Text = ""

            lbl_idgrupoctacte.Text = Me.GrdConcep.ActiveRow.Cells("gru_id").Value
            lbl_idsubgctacte.Text = Me.GrdConcep.ActiveRow.Cells("sg_id").Value
            lbl_idconcepctacte.Text = Me.GrdConcep.ActiveRow.Cells("con_id").Value
            txtgrupocta.Text = Me.GrdGrupos.ActiveRow.Cells("gru_descripcion").Value.ToString ''
            txtsubgr_cta.Text = Me.GridSubGrupo.ActiveRow.Cells("sg_descripcion").Value.ToString
            txtconcep_cta.Text = Me.GrdConcep.ActiveRow.Cells("con_descripcion").Value
            Gridsel_ctacte.DataSource = Negocio.ListarProveedores(Integer.Parse(lbl_idgrupoctacte.Text), Integer.Parse(lbl_idconcepctacte.Text), Companhia, 5)
        End If

        If Accion = 9 Then
            GrupoGrupos.Enabled = True
            GroupSub.Enabled = True
            GrupoConceptos.Enabled = True
            GroupNat.Enabled = True
            Groupfile.Enabled = True
            GroupProv.Enabled = True
            cmb_grupo.Enabled = True
            GroupBoxDoc.Enabled = True
            Checkto_Pro.Checked = False
            Checkto_Na.Checked = False
            Checkto_doc.Checked = False
            Checkto_file.Checked = False

            Tab_Hoja_Costo_Mantenimiento.Visible = False
        End If
    End Sub

    Private Sub btn_newgrupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newgrupo.Click
        Activa_Edicion(1, 0)
    End Sub


    Private Sub btn_cancelar_grupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_grupo.Click
        Activa_Edicion(9, 0)
    End Sub

    Private Sub Combo_Grupos()
        Me.cmb_grupo.DataSource = Negocio.ListarGrupos()
        Me.cmb_grupo.ValueMember = "gru_id"
        Me.cmb_grupo.DisplayMember = "gru_descripcion"

        Me.cmb_gruposel.DataSource = Negocio.ListarGrupos()
        Me.cmb_gruposel.ValueMember = "gru_id"
        Me.cmb_gruposel.DisplayMember = "gru_descripcion"
    End Sub

    Private Sub Combo_SubGrupos()
        Me.cmb_gruposel.DataSource = Negocio.ListarSubGrupos(GrdGrupos.ActiveRow.Cells("gru_id").Value)
        Me.cmb_gruposel.ValueMember = "sg_id"
        Me.cmb_gruposel.DisplayMember = "sg_descripcion"

        cmb_subgr.DataSource = Negocio.ListarSubGrupos(GrdGrupos.ActiveRow.Cells("gru_id").Value)
        cmb_subgr.ValueMember = "sg_id"
        cmb_subgr.DisplayMember = "sg_descripcion"
    End Sub

    Private Sub Cargar_Grupos()
        Me.GrdGrupos.DataSource = Negocio.ListarGrupos()
    End Sub

    Private Sub btn_grabar_grupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar_grupo.Click

        If Trim(Me.TxtNombregrupo.Text & "") = "" Then
            MsgBox("Ingresar el Grupo", MsgBoxStyle.Information, "Comacsa")
            Me.TxtNombregrupo.Focus()
            Exit Sub
        End If

        Dim lAccion As Integer = 1
        If Trim(LblIdCuadro.Text & "") <> "" Then lAccion = 2
        If lAccion <> 2 Then
            Dim Tabla As New DataTable
            Tabla = Negocio.Validar(Trim(Me.TxtNombregrupo.Text & ""), 1)
            If Tabla.Rows.Count > 0 Then
                MsgBox("Registro ya existe", MsgBoxStyle.Information, "Comacsa")
                Me.TxtNombregrupo.Focus()
                Exit Sub
            End If
        End If
        'If MsgBox("¿Esta Seguro de GRABAR?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
        Dim v_ing As Integer
        If Rbt_ingreso.Checked = True Then
            v_ing = 1
        Else
            v_ing = 2
        End If

        With Ent
            .descripcion = Trim(Me.TxtNombregrupo.Text & "")
            .cia = Companhia
            .Usuario = User_Sistema
            .ingreso = v_ing
            If Trim(LblIdCuadro.Text & "") <> "" Then
                .ID = Trim(LblIdCuadro.Text & "")
            End If
        End With
        Negocio.Guardar_Grupo(Ent, lAccion)
        MsgBox("Se guardó correctamente los datos.", MsgBoxStyle.Information, "Comacsa")
        Activa_Edicion(9, 0)
        Call Cargar_Grupos()
        Call Combo_Grupos()
        'End If

    End Sub

    Private Sub Cargar_Conceptos()
        Me.GrdConcep.DataSource = Negocio.ListarConceptosxgrupo(Me.GridSubGrupo.ActiveRow.Cells("gru_id").Value)
    End Sub


    Private Sub Cargar_subgrupos()
        Me.GridSubGrupo.DataSource = Negocio.ListarSubGrupos(Me.GrdGrupos.ActiveRow.Cells("gru_id").Value)
    End Sub

    Private Sub frm_SeteoFCB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Cargar_Grupos()
        'Call Cargar_Conceptos()
        Call Combo_Grupos()
    End Sub

    Private Sub btn_newconcep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newconcep.Click
        Activa_Edicion(1, 2)
    End Sub

    Private Sub btn_cancelar_con_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_con.Click
        Activa_Edicion(9, 0)
    End Sub

    Private Sub btn_grabar_con_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabar_con.Click
        Dim lAccion As Integer = 1
        Dim lpositivo As Integer
        Dim ldifcambio, ldprov As Integer

        If Trim(Me.TxtConcepto.Text & "") = "" Then
            MsgBox("Ingresar el Concepto", MsgBoxStyle.Information, "Comacsa")
            Me.TxtConcepto.Focus()
            Exit Sub
        End If
        If cmb_grupo.Value <= 0 Then
            MsgBox("Seleccione un Grupo", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If

        If rad_signo_positivo.Checked = True Then
            lpositivo = 1
        Else
            lpositivo = 0
        End If

        If Check_dcambio.Checked = True Then
            ldifcambio = 1
        Else
            ldifcambio = 0
        End If

        If Check_dprov.Checked = True Then
            ldprov = 1
        Else
            ldprov = 0
        End If

        If Trim(LblIdConcepto.Text & "") <> "" Then lAccion = 2
        If lAccion <> 2 Then
            Dim Tabla As New DataTable
            Tabla = Negocio.Validar(Trim(Me.TxtConcepto.Text & ""), 2)
            If Tabla.Rows.Count > 0 Then
                MsgBox("Registro ya existe", MsgBoxStyle.Information, "Comacsa")
                Me.TxtConcepto.Focus()
                Exit Sub
            End If
        End If
        'If MsgBox("¿Esta Seguro de GRABAR?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
        With Ent
            .descripcion = Trim(Me.TxtConcepto.Text & "")
            .positivo = lpositivo
            .cia = Companhia
            .Usuario = User_Sistema
            If Trim(LblIdConcepto.Text & "") <> "" Then
                .ID = Trim(LblIdConcepto.Text & "")
            End If
            .grupo = Me.cmb_grupo.Value
            .subgrupo = Me.cmb_subgr.Value
            .dcambio = ldifcambio
            .dprov = ldprov
        End With
        Negocio.Guardar_Concepto(Ent, lAccion)
        MsgBox("Se guardó correctamente los datos.", MsgBoxStyle.Information, "Comacsa")
        Activa_Edicion(9, 0)
        'Call Cargar_Conceptos()
        GrdConcep.DataSource = Negocio.ListarConceptosxgrupo(GridSubGrupo.ActiveRow.Cells("sg_id").Value)
        'Me.GrdConcep.DataSource = Negocio.ListarConceptosxgrupo(Me.cmb_grupos.Value)
        'End If
    End Sub

    'Private Sub cmb_grupos_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.GrdConcep.DataSource = Negocio.ListarConceptosxgrupo(Grd.ActiveRow.Cells("gru_id").Value.ToString)
    'End Sub

    Private Sub btn_eliminar_con_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_con.Click
        Dim lAccion As Integer = 2
        If Trim(LblIdConcepto.Text & "") <> "" Then lAccion = 3
        If MsgBox("¿Esta Seguro de Eliminar ?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
            With Ent
                .ID = Trim(LblIdConcepto.Text & "")
            End With
            Negocio.Guardar_Concepto(Ent, lAccion)
            MsgBox("Se guardó correctamente los datos.", MsgBoxStyle.Information, "Comacsa")
            Activa_Edicion(9, 0)
            Call Cargar_Conceptos()
        End If
    End Sub

    Private Sub GrdGrupos_DoubleClickRow_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GrdGrupos.DoubleClickRow
        If GrdGrupos.ActiveRow.Index >= 0 Then
            Call Activa_Edicion(2, 0)
        End If
    End Sub

    Private Sub GrdConcep_DoubleClickRow_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GrdConcep.DoubleClickRow
        If GrdConcep.ActiveRow.Index >= 0 Then
            Call Activa_Edicion(2, 2)
        End If
    End Sub



    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Activa_Edicion(9, 0)
    End Sub



    Private Sub btn_grabarprov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabarprov.Click
        Ls_Entrega = New List(Of ETFCB)
        For j As Integer = 0 To Grid1Prov.Rows.Count - 1
            If Me.Grid1Prov.Rows(j).Cells("Action").Value = True Then
                Entidad.Etfcb = New ETFCB
                Entidad.Etfcb.grupo = Integer.Parse(lbl_idgrupo.Text)
                Entidad.Etfcb.subgrupo = Integer.Parse(lbl_idsubg_prov.Text)
                Entidad.Etfcb.concepto = Integer.Parse(lbl_idconcepto.Text)
                Entidad.Etfcb.proveedor = Grid1Prov.Rows(j).Cells("cod_prov").Value.ToString.Trim
                Entidad.Etfcb.cia = Companhia
                Entidad.Etfcb.Usuario = User_Sistema
                Ls_Entrega.Add(Entidad.Etfcb)
            End If
        Next
        Ent = Negocio.Guardar_Proveedor_Concepto(Entidad.Etfcb, Ls_Entrega)
        MsgBox("Se guardó correctamente los datos.", MsgBoxStyle.Information, "Comacsa")
        Activa_Edicion(9, 0)
        Call proveedoresxconcepto()
    End Sub

    Private Sub GrdArmaConceptos_ClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs)

        'Dim gru_id, con_id As Integer
        'gru_id = cmb_grupos.Value
        'con_id = GrdConcep.ActiveRow.Cells("con_id").Value()
        'GridProv.DataSource = Negocio.ListarProvConcepto(gru_id, con_id, "01")
    End Sub

    Private Sub proveedoresxconcepto()
        Dim gru_id, sg_id, con_id As Integer
        gru_id = GrdConcep.ActiveRow.Cells("gru_id").Value()
        sg_id = GrdConcep.ActiveRow.Cells("sg_id").Value
        con_id = GrdConcep.ActiveRow.Cells("con_id").Value()
        GridProv.DataSource = Negocio.ListarProvConcepto(gru_id, sg_id, con_id, Companhia)
    End Sub

    Private Sub NaturalezaxConcepto()
        Dim gru_id, sg_id, con_id As Integer
        gru_id = GrdConcep.ActiveRow.Cells("gru_id").Value()
        sg_id = GrdConcep.ActiveRow.Cells("sg_id").Value
        con_id = GrdConcep.ActiveRow.Cells("con_id").Value()
        Grid_nat.DataSource = Negocio.ListarNaturalezaConcepto(gru_id, sg_id, con_id, Companhia)
    End Sub

    Private Sub FilexConcepto()
        Dim gru_id, sg_id, con_id As Integer
        gru_id = GrdConcep.ActiveRow.Cells("gru_id").Value()
        sg_id = GrdConcep.ActiveRow.Cells("sg_id").Value
        con_id = GrdConcep.ActiveRow.Cells("con_id").Value()
        Grdfileconcep.DataSource = Negocio.ListarFileConcepto(gru_id, sg_id, con_id, Companhia)
    End Sub

    Private Sub DocxConcepto()
        Dim gru_id, sg_id, con_id As Integer
        gru_id = GrdConcep.ActiveRow.Cells("gru_id").Value()
        sg_id = GrdConcep.ActiveRow.Cells("sg_id").Value
        con_id = GrdConcep.ActiveRow.Cells("con_id").Value()
        Griddoc.DataSource = Negocio.ListarDocxConcepto(gru_id, sg_id, con_id, Companhia)
    End Sub

    Public Sub movixConcepto()
        Dim gru_id, sg_id, con_id As Integer
        gru_id = GrdConcep.ActiveRow.Cells("gru_id").Value()
        sg_id = GrdConcep.ActiveRow.Cells("sg_id").Value()
        con_id = GrdConcep.ActiveRow.Cells("con_id").Value()
        Grd_dbanc.DataSource = Negocio.ListarMovxconcepto(gru_id, sg_id, con_id, Companhia)
    End Sub

    Public Sub CtactexConcepto()
        Dim gru_id, sg_id, con_id As Integer
        gru_id = GrdConcep.ActiveRow.Cells("gru_id").Value()
        sg_id = GrdConcep.ActiveRow.Cells("sg_id").Value()
        con_id = GrdConcep.ActiveRow.Cells("con_id").Value()
        Grid_ctacte.DataSource = Negocio.ListarCtactexConcepto(gru_id, sg_id, con_id, Companhia)
    End Sub

    Private Sub btn_agregarprov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_agregarprov.Click
        If GrdConcep.Rows.Count < 1 Then Exit Sub
        If GrdConcep.ActiveRow Is Nothing Then Exit Sub
        Call Activa_Edicion(1, 3)
    End Sub

    Private Sub btn_quitarprov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitarprov.Click
        If GridProv.Rows.Count < 1 Then Exit Sub
        If GridProv.ActiveRow Is Nothing Then Exit Sub
        Dim c_id As Integer
        Dim c_prov As String
        c_id = GridProv.ActiveRow.Cells("id").Value
        c_prov = GridProv.ActiveRow.Cells("Cod_Prov").Value.ToString
        If MsgBox("Está Seguro de Eliminar Proveedor " & c_prov & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Negocio.Eliminar_Provconcep(c_id, Companhia, User_Sistema)
                MsgBox("El Proveedor ha sido Eliminado", MsgBoxStyle.Information)
                Call proveedoresxconcepto()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub GridProv_ClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles GridProv.ClickCell
        btn_quitarprov.Enabled = True
    End Sub


    Private Sub Checkto_Pro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkto_Pro.CheckedChanged
        If Grid1Prov.Rows.Count > 0 Then
            If Checkto_Pro.Checked = True Then
                For j As Integer = 0 To Grid1Prov.Rows.Count - 1
                    Grid1Prov.Rows(j).Cells("Action").Value = True
                Next
            Else
                For j As Integer = 0 To Grid1Prov.Rows.Count - 1
                    Grid1Prov.Rows(j).Cells("Action").Value = False
                Next
            End If
        End If
    End Sub

    Private Sub Checkto_Na_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkto_Na.CheckedChanged
        If Grid_selnat.Rows.Count > 0 Then
            If Checkto_Na.Checked = True Then
                For j As Integer = 0 To Grid_selnat.Rows.Count - 1
                    Grid_selnat.Rows(j).Cells("Action").Value = True
                Next
            Else
                For j As Integer = 0 To Grid_selnat.Rows.Count - 1
                    Grid_selnat.Rows(j).Cells("Action").Value = False
                Next
            End If
        End If
    End Sub

    Private Sub btn_cancelar_nat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_nat.Click
        Activa_Edicion(9, 0)
        Cmb_naturaleza.Value = 0
    End Sub

    Private Sub btn_grabarnat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabarnat.Click
        If Cmb_naturaleza.Value <= 0 Then
            MsgBox("Seleccione una Naturaleza", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If

        If Grid_selnat.Rows.Count < 1 Then Exit Sub

        Ls_Entrega = New List(Of ETFCB)
        For j As Integer = 0 To Grid_selnat.Rows.Count - 1
            If Me.Grid_selnat.Rows(j).Cells("Action").Value = True Then
                Entidad.Etfcb = New ETFCB
                Entidad.Etfcb.grupo = Integer.Parse(lbl_idgruponat.Text)
                Entidad.Etfcb.subgrupo = Integer.Parse(lbl_idsubg_nat.Text)
                Entidad.Etfcb.concepto = Integer.Parse(lbl_idconcepnat.Text)
                Entidad.Etfcb.proveedor = Grid_selnat.Rows(j).Cells("codigo").Value.ToString.Trim
                Entidad.Etfcb.cia = Companhia
                Entidad.Etfcb.Usuario = User_Sistema
                Ls_Entrega.Add(Entidad.Etfcb)
            End If
        Next
        Ent = Negocio.Guardar_Naturaleza_Concepto(Entidad.Etfcb, Ls_Entrega)
        MsgBox("Se guardó correctamente los datos.", MsgBoxStyle.Information, "Comacsa")
        Grid_selnat.DataSource = Negocio.ListarCaracteristicaxNaturaleza(Integer.Parse(lbl_idgruponat.Text), Integer.Parse(lbl_idconcepnat.Text), Cmb_naturaleza.Value, Companhia)
        Call NaturalezaxConcepto()
        'Cmb_naturaleza.Value = 0
        Activa_Edicion(9, 0)
    End Sub


    Private Sub btn_newnaturaleza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newnaturaleza.Click
        If GrdConcep.Rows.Count < 1 Then Exit Sub
        If GrdConcep.ActiveRow Is Nothing Then Exit Sub
        Call Activa_Edicion(1, 4)
    End Sub


    Private Sub Grid_nat_ClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles Grid_nat.ClickCell
        btn_quitarnat.Enabled = True
    End Sub

    Private Sub Btn_quitarnaturaleza(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitarnat.Click
        If Grid_nat.Rows.Count < 1 Then Exit Sub
        If Grid_nat.ActiveRow Is Nothing Then Exit Sub
        Dim c_id As Integer
        Dim c_nat As String
        c_id = Grid_nat.ActiveRow.Cells("id").Value
        c_nat = Grid_nat.ActiveRow.Cells("codigo").Value.ToString
        If MsgBox("Está Seguro de Eliminar Naturaleza " & c_nat & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Negocio.Eliminar_Natuconcep(c_id, Companhia, User_Sistema)
                MsgBox("La Naturaleza ha sido Eliminado", MsgBoxStyle.Information)
                Call NaturalezaxConcepto()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub btn_cancelarfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelarfile.Click
        Activa_Edicion(9, 0)
    End Sub

    Private Sub btn_newfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newfile.Click
        If GrdConcep.Rows.Count < 1 Then Exit Sub
        If GrdConcep.ActiveRow Is Nothing Then Exit Sub
        Call Activa_Edicion(1, 5)
    End Sub

    Private Sub btn_grabarfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabarfile.Click
        Ls_Entrega = New List(Of ETFCB)
        For j As Integer = 0 To Gridselfile.Rows.Count - 1
            If Me.Gridselfile.Rows(j).Cells("Action").Value = True Then
                Entidad.Etfcb = New ETFCB
                Entidad.Etfcb.grupo = Integer.Parse(lbl_idgrupofile.Text)
                Entidad.Etfcb.subgrupo = Integer.Parse(lbl_idsubg_file.Text)
                Entidad.Etfcb.concepto = Integer.Parse(lbl_idconcepfile.Text)
                Entidad.Etfcb.proveedor = Gridselfile.Rows(j).Cells("n_file").Value.ToString
                Entidad.Etfcb.cia = Companhia
                Entidad.Etfcb.Usuario = User_Sistema
                Ls_Entrega.Add(Entidad.Etfcb)
            End If
        Next
        Ent = Negocio.Guardar_File_Concepto(Entidad.Etfcb, Ls_Entrega)
        MsgBox("Se guardó correctamente los datos.", MsgBoxStyle.Information, "Comacsa")
        Activa_Edicion(9, 0)
        Call FilexConcepto()
    End Sub
    '
    Private Sub GrdGrupos_ClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles GrdGrupos.ClickCell
        If GrdGrupos.ActiveRow.Index < 0 Then Exit Sub
        Me.btn_subir_grupos.Enabled = True
        Me.btn_bajar_grupos.Enabled = True
        Me.GridSubGrupo.DataSource = Negocio.ListarSubGrupos(GrdGrupos.ActiveRow.Cells("gru_id").Value.ToString)
        GroupSub.Text = GrdGrupos.ActiveRow.Cells("gru_descripcion").Value.ToString
        If Me.GridSubGrupo.Rows.Count < 1 Then
            GrdConcep.DataSource = Nothing
            GrupoConceptos.Text = ""

            btn_newconcep.Enabled = False

            btn_newdbanc.Enabled = False
            btn_newdoc.Enabled = False
            btn_newnaturaleza.Enabled = False
            btn_newfile.Enabled = False
            btn_agregarprov.Enabled = False

            btn_subir_con.Enabled = False
            btn_bajar_con.Enabled = False
            '
            GridProv.DataSource = Nothing
            Grid_nat.DataSource = Nothing
            Grdfileconcep.DataSource = Nothing
            Griddoc.DataSource = Nothing
            Grd_dbanc.DataSource = Nothing
            Grid_ctacte.DataSource = Nothing
        End If
        GrdConcep.DataSource = Nothing
        GrupoConceptos.Text = ""

    End Sub

    Private Sub GrdConcep_ClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles GrdConcep.ClickCell
        If GrdConcep.ActiveRow.Index < 0 Then Exit Sub
        If GrdConcep.Rows.Count < 1 Then Exit Sub
        If GrdConcep.ActiveRow Is Nothing Then Exit Sub

        btn_subir_con.Enabled = True
        btn_bajar_con.Enabled = True
        btn_agregarprov.Enabled = True
        btn_newnaturaleza.Enabled = True
        btn_newfile.Enabled = True
        btn_newdoc.Enabled = True
        btn_newdbanc.Enabled = True
        btn_newctacte.Enabled = True

        Call proveedoresxconcepto()
        Call NaturalezaxConcepto()
        Call FilexConcepto()
        Call DocxConcepto()
        Call movixConcepto()
        Call CtactexConcepto()
    End Sub

    Private Sub Grdfileconcep_ClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles Grdfileconcep.ClickCell
        btn_quitarfile.Enabled = True
    End Sub

    Private Sub btn_quitarfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitarfile.Click

        If Grdfileconcep.Rows.Count < 1 Then Exit Sub
        If Grdfileconcep.ActiveRow Is Nothing Then Exit Sub
        Dim c_id As Integer
        Dim c_nat As String
        c_id = Grdfileconcep.ActiveRow.Cells("id").Value
        c_nat = Grdfileconcep.ActiveRow.Cells("fil_id").Value.ToString
        If MsgBox("Está Seguro de Eliminar N° File " & c_nat & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Negocio.Eliminar_Fileconcep(c_id, Companhia, User_Sistema)
                MsgBox("N° File ha sido Eliminado", MsgBoxStyle.Information)
                Call FilexConcepto()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub Cmb_naturaleza_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_naturaleza.ValueChanged
        Grid_selnat.DataSource = Negocio.ListarCaracteristicaxNaturaleza(Integer.Parse(lbl_idgruponat.Text), Integer.Parse(lbl_idconcepnat.Text), Cmb_naturaleza.Value, Companhia)
    End Sub


    Private Sub btn_newdoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newdoc.Click
        If GrdConcep.Rows.Count < 1 Then Exit Sub
        If GrdConcep.ActiveRow Is Nothing Then Exit Sub
        Activa_Edicion(1, 6)
    End Sub

    Private Sub btn_cancelar_doc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar_doc.Click
        Activa_Edicion(9, 0)
    End Sub

    Private Sub Checkto_file_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkto_file.CheckedChanged
        If Gridselfile.Rows.Count > 0 Then
            If Checkto_file.Checked = True Then
                For j As Integer = 0 To Gridselfile.Rows.Count - 1
                    Gridselfile.Rows(j).Cells("Action").Value = True
                Next
            Else
                For j As Integer = 0 To Gridselfile.Rows.Count - 1
                    Gridselfile.Rows(j).Cells("Action").Value = False
                Next
            End If
        End If
    End Sub

    Private Sub Checkto_doc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkto_doc.CheckedChanged
        If Gridseldoc.Rows.Count > 0 Then
            If Checkto_doc.Checked = True Then
                For j As Integer = 0 To Gridseldoc.Rows.Count - 1
                    Gridseldoc.Rows(j).Cells("Action").Value = True
                Next
            Else
                For j As Integer = 0 To Gridseldoc.Rows.Count - 1
                    Gridseldoc.Rows(j).Cells("Action").Value = False
                Next
            End If
        End If
    End Sub

    Private Sub btn_grabardoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabardoc.Click
        Ls_Entrega = New List(Of ETFCB)
        For j As Integer = 0 To Gridseldoc.Rows.Count - 1
            If Me.Gridseldoc.Rows(j).Cells("Action").Value = True Then
                Entidad.Etfcb = New ETFCB
                Entidad.Etfcb.grupo = Integer.Parse(lbl_idgrupodoc.Text)
                Entidad.Etfcb.subgrupo = Integer.Parse(lbl_idsubg_doc.Text)
                Entidad.Etfcb.concepto = Integer.Parse(lbl_idconcepdoc.Text)
                Entidad.Etfcb.proveedor = Gridseldoc.Rows(j).Cells("cod_maestro2").Value.ToString
                Entidad.Etfcb.cia = Companhia
                Entidad.Etfcb.Usuario = User_Sistema
                Ls_Entrega.Add(Entidad.Etfcb)
            End If
        Next
        Ent = Negocio.Guardar_Doc_Concepto(Entidad.Etfcb, Ls_Entrega)
        MsgBox("Se guardó correctamente los datos.", MsgBoxStyle.Information, "Comacsa")
        Activa_Edicion(9, 0)
        Call DocxConcepto()
    End Sub

    Private Sub btn_quitardoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitardoc.Click
        If Griddoc.Rows.Count < 1 Then Exit Sub
        If Griddoc.ActiveRow Is Nothing Then Exit Sub
        Dim c_id As Integer
        Dim c_nat As String
        c_id = Griddoc.ActiveRow.Cells("id").Value
        c_nat = Griddoc.ActiveRow.Cells("codigo").Value.ToString
        If MsgBox("Está Seguro de Eliminar Tipo Documento " & c_nat & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Negocio.Eliminar_Doc_concep(c_id, Companhia, User_Sistema)
                MsgBox("Tipo Documento ha sido Eliminado", MsgBoxStyle.Information)
                Call DocxConcepto()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub Griddoc_ClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles Griddoc.ClickCell
        btn_quitardoc.Enabled = True
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Activa_Edicion(1, 1)
    End Sub

    Private Sub btn_cancelarsg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelarsg.Click
        Activa_Edicion(9, 0)
    End Sub

    Private Sub GridSubGrupo_ClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles GridSubGrupo.ClickCell
        If GridSubGrupo.ActiveRow.Index < 0 Then Exit Sub
        btn_newconcep.Enabled = True
        btn_subir_sub.Enabled = True
        btn_bajar_sub.Enabled = True
        Me.GrdConcep.DataSource = Negocio.ListarConceptosxgrupo(GridSubGrupo.ActiveRow.Cells("sg_id").Value)
        GrupoConceptos.Text = GridSubGrupo.ActiveRow.Cells("sg_descripcion").Value.ToString
        If Me.GridSubGrupo.Rows.Count < 1 Then

            btn_agregarprov.Enabled = False
            btn_quitarprov.Enabled = False

            btn_newnaturaleza.Enabled = False
            btn_quitarnat.Enabled = False

            btn_newfile.Enabled = False
            btn_quitarfile.Enabled = False

            btn_newdoc.Enabled = False
            btn_quitardoc.Enabled = False

            btn_newdbanc.Enabled = False
            btn_quitardbanc.Enabled = False

            btn_newctacte.Enabled = False
            btn_quitarctacte.Enabled = False
            'btn_newconcep.Enabled = False
        End If
        'If Me.GrdConcep.Rows.Count < 1 Then
       
        '
        GridProv.DataSource = Nothing
        Grid_nat.DataSource = Nothing
        Grdfileconcep.DataSource = Nothing
        Griddoc.DataSource = Nothing
        Grd_dbanc.DataSource = Nothing
        Grid_ctacte.DataSource = Nothing

        btn_agregarprov.Enabled = False
        btn_quitarprov.Enabled = False

        btn_newnaturaleza.Enabled = False
        btn_quitarnat.Enabled = False

        btn_newfile.Enabled = False
        btn_quitarfile.Enabled = False

        btn_newdoc.Enabled = False
        btn_quitardoc.Enabled = False

        btn_newdbanc.Enabled = False
        btn_quitardbanc.Enabled = False
        'End If
    End Sub

    Private Sub btn_grabarsg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabarsg.Click
        Dim lAccion As Integer = 1

        If Trim(Me.txt_subgrupo.Text & "") = "" Then
            MsgBox("Ingresar el Sub Grupo", MsgBoxStyle.Information, "Comacsa")
            Me.txt_subgrupo.Focus()
            Exit Sub
        End If
        If cmb_gruposel.Value <= 0 Then
            MsgBox("Seleccione un Grupo", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If

        If Trim(Me.lbl_idsubgrupo.Text & "") <> "" Then lAccion = 2
        If lAccion <> 2 Then
            Dim Tabla As New DataTable
            Tabla = Negocio.Validar(Trim(Me.txt_subgrupo.Text & ""), 3)
            If Tabla.Rows.Count > 0 Then
                MsgBox("Registro ya existe", MsgBoxStyle.Information, "Comacsa")
                Me.TxtConcepto.Focus()
                Exit Sub
            End If
        End If
        'If MsgBox("¿Esta Seguro de GRABAR?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
        With Ent
            .descripcion = Trim(Me.txt_subgrupo.Text & "")
            .cia = Companhia
            .Usuario = User_Sistema
            If Trim(lbl_idsubgrupo.Text & "") <> "" Then
                .ID = Trim(lbl_idsubgrupo.Text & "")
            End If
            .grupo = Me.cmb_gruposel.Value
        End With
        Negocio.Guardar_Subgrupo(Ent, lAccion) '
        MsgBox("Se guardó correctamente los datos.", MsgBoxStyle.Information, "Comacsa")
        Activa_Edicion(9, 0)
        Call Cargar_subgrupos()
        'End If
    End Sub

    Private Sub GridSubGrupo_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles GridSubGrupo.DoubleClickRow
        If GridSubGrupo.ActiveRow.Index >= 0 Then
            Call Activa_Edicion(2, 1)
        End If
    End Sub
    'Sub baj
    Private Sub mover_fila_arriba(ByVal p_grid As UltraWinGrid.UltraGrid)
        Dim fila As UltraWinGrid.UltraGridRow
        fila = p_grid.ActiveRow
        If fila.Index > 0 Then
            p_grid.Rows.Move(fila, fila.Index - 1)
        End If
    End Sub

    Private Sub mover_fila_abajo(ByVal p_grid As UltraWinGrid.UltraGrid)
        Dim fila As UltraWinGrid.UltraGridRow
        fila = p_grid.ActiveRow
        If fila.Index < p_grid.Rows.Count - 1 Then
            p_grid.Rows.Move(fila, fila.Index + 1)
        End If
    End Sub

    Private Sub grabar_orden_cuadros(ByVal p_grid As UltraWinGrid.UltraGrid, ByVal id As String, ByVal tabla As Integer)
        Dim s_sql As String = ""
        Dim id_cuadro As Integer = 0
        Try
            For i_orden As Integer = 0 To p_grid.Rows.Count - 1
                id_cuadro = p_grid.Rows(i_orden).Cells(id).Value
                Negocio.ordenar(i_orden, id_cuadro, tabla)
            Next
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub btn_subir_grupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_subir_grupos.Click
        If GrdGrupos.Rows.Count < 1 Then Exit Sub
        Call mover_fila_arriba(GrdGrupos)
        Call grabar_orden_cuadros(GrdGrupos, "gru_id", 1)
    End Sub

    Private Sub btn_bajar_grupos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bajar_grupos.Click
        If GrdGrupos.Rows.Count < 1 Then Exit Sub
        Call mover_fila_abajo(GrdGrupos)
        Call grabar_orden_cuadros(GrdGrupos, "gru_id", 1)
    End Sub

    Private Sub btn_subir_sub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_subir_sub.Click
        If GridSubGrupo.Rows.Count < 1 Then Exit Sub
        Call mover_fila_arriba(GridSubGrupo)
        Call grabar_orden_cuadros(GridSubGrupo, "sg_id", 2)
    End Sub

    Private Sub btn_bajar_sub_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bajar_sub.Click
        If GridSubGrupo.Rows.Count < 1 Then Exit Sub
        Call mover_fila_abajo(GridSubGrupo)
        Call grabar_orden_cuadros(GridSubGrupo, "sg_id", 2)
    End Sub

    Private Sub btn_subir_con_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_subir_con.Click
        If GrdConcep.Rows.Count < 1 Then Exit Sub
        Call mover_fila_arriba(GrdConcep)
        Call grabar_orden_cuadros(GrdConcep, "con_id", 3)
    End Sub

    Private Sub btn_bajar_con_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_bajar_con.Click
        If GrdConcep.Rows.Count < 1 Then Exit Sub
        Call mover_fila_abajo(GrdConcep)
        Call grabar_orden_cuadros(GrdConcep, "con_id", 3)
    End Sub

    'Private Sub grabar_orden_cuadros()

    '    Dim s_sql As String = ""
    '    Dim id_cuadro As Integer = 0
    '    Try
    '        For i_orden As Integer = 0 To GrdGrupos.Rows.Count - 1
    '            id_cuadro = GrdGrupos.Rows(i_orden).Cells("gru_id").Value
    '            Negocio.ordenar_grupos(i_orden, id_cuadro)
    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString)
    '    End Try
    'End Sub

    Private Sub btn_eliminar_grupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_grupo.Click
        If MsgBox("¿Esta Seguro de Eliminar?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
            With Ent
                .Usuario = User_Sistema
                'If Trim(lbl_idgrupo.Text & "") <> "" Then
                '    .ID = Trim(lbl_idgrupo.Text & "")
                'End If
                If Trim(LblIdCuadro.Text & "") <> "" Then
                    .ID = Trim(LblIdCuadro.Text & "")
                End If
            End With
            Negocio.Guardar_Grupo(Ent, 3) '
            MsgBox("Se Elimino correctamente !!", MsgBoxStyle.Information, "Comacsa")
            Activa_Edicion(9, 0)
            Call Cargar_Grupos()

        End If
    End Sub

    Private Sub btn_eliminar_subg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar_subg.Click
        If MsgBox("¿Esta Seguro de Eliminar?", MsgBoxStyle.YesNo, "Comacsa") = MsgBoxResult.Yes Then
            With Ent
                .Usuario = User_Sistema
                If Trim(lbl_idsubgrupo.Text & "") <> "" Then
                    .ID = Trim(lbl_idsubgrupo.Text & "")
                End If
            End With
            Negocio.Guardar_Subgrupo(Ent, 3) '
            MsgBox("Se Elimino correctamente !!", MsgBoxStyle.Information, "Comacsa")
            Activa_Edicion(9, 0)
            Call Cargar_subgrupos()
        End If
    End Sub

    Private Sub btn_grabar_tipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Cmb_tipo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_tipo.ValueChanged
        'MessageBox.Show(Cmb_tipo.Value)
        Gridseldbanc.DataSource = Negocio.ListarMovxTipos(Cmb_tipo.Value)
    End Sub

    Private Sub btn_newdbanc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newdbanc.Click
        If GrdConcep.Rows.Count < 1 Then Exit Sub
        If GrdConcep.ActiveRow Is Nothing Then Exit Sub
        Call Activa_Edicion(1, 7)
    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton1.Click
        Activa_Edicion(9, 0)
    End Sub

    Private Sub UltraButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButton2.Click
        If Cmb_tipo.Value <= 0 Then
            MsgBox("Seleccione un Tipo", MsgBoxStyle.Information, "Comacsa")
            Exit Sub
        End If

        If Gridseldbanc.Rows.Count < 1 Then Exit Sub

        Ls_Entrega = New List(Of ETFCB)
        For j As Integer = 0 To Gridseldbanc.Rows.Count - 1
            If Me.Gridseldbanc.Rows(j).Cells("Action").Value = True Then
                Entidad.Etfcb = New ETFCB
                Entidad.Etfcb.grupo = Integer.Parse(lbl_idgrupodbanc.Text)
                Entidad.Etfcb.subgrupo = Integer.Parse(lbl_idsubgdbanc.Text)
                Entidad.Etfcb.concepto = Integer.Parse(lbl_idconcepdbanc.Text)
                Entidad.Etfcb.Tipo = Integer.Parse(Cmb_tipo.Value)
                Entidad.Etfcb.cia = Companhia
                Entidad.Etfcb.Usuario = User_Sistema
                Entidad.Etfcb.ciamaestro = Gridseldbanc.Rows(j).Cells("ciamaestro").Value.ToString
                Entidad.Etfcb.codmaestro = Gridseldbanc.Rows(j).Cells("cod_maestro2").Value.ToString
                Entidad.Etfcb.codmaestro3 = Gridseldbanc.Rows(j).Cells("cod_maestro3").Value.ToString
                Ls_Entrega.Add(Entidad.Etfcb)
            End If
        Next
        Ent = Negocio.Guardar_TipoMov(Entidad.Etfcb, Ls_Entrega)
        MsgBox("Se guardó correctamente los datos.", MsgBoxStyle.Information, "Comacsa")
        Gridseldbanc.DataSource = Negocio.ListarMovxTipos(Cmb_tipo.Value)
        Call movixConcepto()
        Activa_Edicion(9, 0)

    End Sub

    Private Sub Checkto_dbanc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkto_dbanc.CheckedChanged
        If Gridseldbanc.Rows.Count > 0 Then
            If Checkto_dbanc.Checked = True Then
                For j As Integer = 0 To Gridseldbanc.Rows.Count - 1
                    Gridseldbanc.Rows(j).Cells("Action").Value = True
                Next
            Else
                For j As Integer = 0 To Gridseldbanc.Rows.Count - 1
                    Gridseldbanc.Rows(j).Cells("Action").Value = False
                Next
            End If
        End If
    End Sub

    Private Sub Grd_dbanc_ClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles Grd_dbanc.ClickCell
        btn_quitardbanc.Enabled = True
    End Sub

    Private Sub btn_quitardbanc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitardbanc.Click
        If Grd_dbanc.Rows.Count < 1 Then Exit Sub
        If Grd_dbanc.ActiveRow Is Nothing Then Exit Sub
        Dim c_id As Integer
        Dim c_prov As String
        c_id = Grd_dbanc.ActiveRow.Cells("id").Value
        c_prov = Grd_dbanc.ActiveRow.Cells("descrip").Value.ToString
        If MsgBox("Está Seguro de Eliminar Doc Bancario " & c_prov & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Negocio.Eliminar_Tipomovconcep(c_id, Companhia, User_Sistema)
                MsgBox("El Doc se ha sido Eliminado", MsgBoxStyle.Information)
                Call movixConcepto()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
    End Sub



    Private Sub GridProv_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridProv.InitializeLayout
        e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        e.Layout.Bands(0).Columns("id").Hidden = True
        e.Layout.Bands(0).Columns("Cod_Prov").Header.Caption = "CODIGO"
        e.Layout.Bands(0).Columns("RazSoc").Header.Caption = "RAZON SOCIAL/NOMBRE"
        e.Layout.Bands(0).Columns("ruc").Header.Caption = "RUC"
    End Sub

    Private Sub Grd_dbanc_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grd_dbanc.InitializeLayout
        e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        e.Layout.Bands(0).Columns("ciamaestro").Hidden = True
        e.Layout.Bands(0).Columns("cod_maestro2").Hidden = True
        e.Layout.Bands(0).Columns("cod_maestro3").Hidden = True
        e.Layout.Bands(0).Columns("tipo").Hidden = True
        e.Layout.Bands(0).Columns("id").Hidden = True
        e.Layout.Bands(0).Columns("tip_desc").Header.Caption = "TIPO"
        e.Layout.Bands(0).Columns("descrip").Header.Caption = "DESCRIPCION"
    End Sub

    Private Sub Grid_nat_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid_nat.InitializeLayout
        e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        e.Layout.Bands(0).Columns("id").Hidden = True
        e.Layout.Bands(0).Columns("codigo").Header.Caption = "CODIGO"
        e.Layout.Bands(0).Columns("naturaleza").Header.Caption = "NATURALEZA"
        e.Layout.Bands(0).Columns("descripcion").Header.Caption = "CARACTERISTICA"
    End Sub

    Private Sub Griddoc_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Griddoc.InitializeLayout
        e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        e.Layout.Bands(0).Columns("id").Hidden = True
        e.Layout.Bands(0).Columns("codigo").Header.Caption = "CODIGO"
        e.Layout.Bands(0).Columns("descrip").Header.Caption = "DOCUMENTO"
    End Sub

    Private Sub Grdfileconcep_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grdfileconcep.InitializeLayout
        e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        e.Layout.Bands(0).Columns("id").Hidden = True
        e.Layout.Bands(0).Columns("fil_id").Header.Caption = "N° FILE"
    End Sub



    Private Sub GrdConcep_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GrdConcep.InitializeLayout
        e.Layout().Bands(0).Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        e.Layout.Bands(0).Columns("con_id").Hidden = True
        e.Layout.Bands(0).Columns("gru_id").Hidden = True
        e.Layout.Bands(0).Columns("positivo").Hidden = True
        e.Layout.Bands(0).Columns("sg_id").Hidden = True
        e.Layout.Bands(0).Columns("dcambio").Hidden = True
        e.Layout.Bands(0).Columns("dprov").Hidden = True
        e.Layout.Bands(0).Columns("con_descripcion").Header.Caption = "CONCEPTO"

    End Sub

   
    Private Sub Check_dcambio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_dcambio.CheckedChanged
        If Check_dcambio.Checked = True Then
            Check_dprov.Checked = False
        End If
    End Sub


    Private Sub Check_dprov_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_dprov.CheckedChanged
        If Check_dprov.Checked = True Then
            Check_dcambio.Checked = False
        End If

    End Sub

    Private Sub btn_grabarctacte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_grabarctacte.Click
        Ls_Entrega = New List(Of ETFCB)
        For j As Integer = 0 To Gridsel_ctacte.Rows.Count - 1
            If Me.Gridsel_ctacte.Rows(j).Cells("Action").Value = True Then
                Entidad.Etfcb = New ETFCB
                Entidad.Etfcb.grupo = Integer.Parse(lbl_idgrupoctacte.Text)
                Entidad.Etfcb.subgrupo = Integer.Parse(lbl_idsubgctacte.Text)
                Entidad.Etfcb.concepto = Integer.Parse(lbl_idconcepctacte.Text)
                Entidad.Etfcb.proveedor = Gridsel_ctacte.Rows(j).Cells("cgcod").Value.ToString
                Entidad.Etfcb.cia = Companhia
                Entidad.Etfcb.Usuario = User_Sistema
                Ls_Entrega.Add(Entidad.Etfcb)
            End If
        Next
        Ent = Negocio.Guardar_ctacte(Entidad.Etfcb, Ls_Entrega)
        MsgBox("Se guardó correctamente los datos.", MsgBoxStyle.Information, "Comacsa")
        Activa_Edicion(9, 0)
        Call CtactexConcepto()
    End Sub

    Private Sub btn_newctacte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_newctacte.Click
        If GrdConcep.Rows.Count < 1 Then Exit Sub
        If GrdConcep.ActiveRow Is Nothing Then Exit Sub
        Call Activa_Edicion(1, 8)
    End Sub

    Private Sub btn_cancctacte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancctacte.Click
        Activa_Edicion(9, 0)
    End Sub

    Private Sub Grid_ctacte_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid_ctacte.InitializeLayout
        e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        e.Layout.Bands(0).Columns("id").Hidden = True
        e.Layout.Bands(0).Columns("cgcod").Header.Caption = "CUENTA"
        e.Layout.Bands(0).Columns("cgdes").Header.Caption = "DESCRIPCION"
    End Sub

    Private Sub Grid_ctacte_ClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles Grid_ctacte.ClickCell
        btn_quitarctacte.Enabled = True
    End Sub

    Private Sub btn_quitarctacte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_quitarctacte.Click
        If Grid_ctacte.Rows.Count < 1 Then Exit Sub
        If Grid_ctacte.ActiveRow Is Nothing Then Exit Sub
        Dim c_id As Integer
        Dim c_nat As String
        c_id = Grid_ctacte.ActiveRow.Cells("id").Value
        c_nat = Grid_ctacte.ActiveRow.Cells("cgcod").Value.ToString
        If MsgBox("Está Seguro de Eliminar CtaCte " & c_nat & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
                Negocio.Eliminar_Ctactexconcep(c_id, Companhia, User_Sistema)
                MsgBox("La CtaCte ha sido Eliminado", MsgBoxStyle.Information)
                Call CtactexConcepto()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub GrdGrupos_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GrdGrupos.InitializeLayout
        e.Layout().Bands(0).Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    End Sub

    Private Sub GridSubGrupo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GridSubGrupo.InitializeLayout
        e.Layout().Bands(0).Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
    End Sub
End Class
