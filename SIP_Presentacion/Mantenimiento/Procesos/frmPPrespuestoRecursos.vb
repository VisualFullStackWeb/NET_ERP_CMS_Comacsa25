Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmPPrespuestoRecursos

#Region "Declarar Variable"
    Private Enum eBuscar
        eMaterial = 1
        eEquipo = 2
        eManoObra = 3
        eServicio = 4
    End Enum
    Private Enum eState
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
        eSave = 5
    End Enum
    Private TipoG_DetMat As eState
    Private TipoG_DetEq As eState
    Private TipoG_DetMO As eState
    Private TipoG_DetSer As eState

    Private _PresupuestoItem As Long = 0
    Private _Ls_Material As List(Of ETPresupuestoMaterial) = Nothing
    Private _Ls_Equipo As List(Of ETPresupuestoEquipo) = Nothing
    Private _Ls_ManoObra As List(Of ETPresupuestoManoObra) = Nothing
    Private _Ls_Servicio As List(Of ETPresupuestoServicio) = Nothing
    Private _Ls_Material_Del As List(Of ETPresupuestoMaterial) = Nothing
    Private _Ls_Equipo_Del As List(Of ETPresupuestoEquipo) = Nothing
    Private _Ls_ManoObra_Del As List(Of ETPresupuestoManoObra) = Nothing
    Private _Ls_Servicio_Del As List(Of ETPresupuestoServicio) = Nothing

    Private _TipoFactor As String = String.Empty
    Private _Factor As Double = 0
    Private _Jornada As Double = 0
    Private _UniMed As String = String.Empty
    Private _TotalPartida As Double = 0

    Private _Det_Mat As String = String.Empty
    Private _Det_Eq As Long = 0
    Private _Det_Eq_New As Long = 0
    Private _Det_MO As String = String.Empty
    Private _Det_Ser As String = String.Empty
    Private _Nro_OC_Mat As String = String.Empty
    Private _Nro_OC_Ser As String = String.Empty
    Private _SoloLectura As Boolean = Boolean.FalseString
#End Region

#Region "Propiedades Publicos"
    Public Property Presupuesto() As Long
        Get
            Return _PresupuestoItem
        End Get
        Set(ByVal value As Long)
            _PresupuestoItem = value
        End Set
    End Property
    Public Property Ls_Material() As List(Of ETPresupuestoMaterial)
        Get
            Return _Ls_Material
        End Get
        Set(ByVal value As List(Of ETPresupuestoMaterial))
            _Ls_Material = value
        End Set
    End Property
    Public Property Ls_Equipo() As List(Of ETPresupuestoEquipo)
        Get
            Return _Ls_Equipo
        End Get
        Set(ByVal value As List(Of ETPresupuestoEquipo))
            _Ls_Equipo = value
        End Set
    End Property
    Public Property Ls_ManoObra() As List(Of ETPresupuestoManoObra)
        Get
            Return _Ls_ManoObra
        End Get
        Set(ByVal value As List(Of ETPresupuestoManoObra))
            _Ls_ManoObra = value
        End Set
    End Property
    Public Property Ls_Servicio() As List(Of ETPresupuestoServicio)
        Get
            Return _Ls_Servicio
        End Get
        Set(ByVal value As List(Of ETPresupuestoServicio))
            _Ls_Servicio = value
        End Set
    End Property
    Public Property Ls_Material_Del() As List(Of ETPresupuestoMaterial)
        Get
            Return _Ls_Material_Del
        End Get
        Set(ByVal value As List(Of ETPresupuestoMaterial))
            _Ls_Material_Del = value
        End Set
    End Property
    Public Property Ls_Equipo_Del() As List(Of ETPresupuestoEquipo)
        Get
            Return _Ls_Equipo_Del
        End Get
        Set(ByVal value As List(Of ETPresupuestoEquipo))
            _Ls_Equipo_Del = value
        End Set
    End Property
    Public Property Ls_ManoObra_Del() As List(Of ETPresupuestoManoObra)
        Get
            Return _Ls_ManoObra_Del
        End Get
        Set(ByVal value As List(Of ETPresupuestoManoObra))
            _Ls_ManoObra_Del = value
        End Set
    End Property
    Public Property Ls_Servicio_Del() As List(Of ETPresupuestoServicio)
        Get
            Return _Ls_Servicio_Del
        End Get
        Set(ByVal value As List(Of ETPresupuestoServicio))
            _Ls_Servicio_Del = value
        End Set
    End Property

    Public Property TipoFactor() As String
        Get
            Return _TipoFactor
        End Get
        Set(ByVal value As String)
            _TipoFactor = value
        End Set
    End Property
    Public Property Factor() As Double
        Get
            Return _Factor
        End Get
        Set(ByVal value As Double)
            _Factor = value
        End Set
    End Property
    Public Property Jornada() As Double
        Get
            Return _Jornada
        End Get
        Set(ByVal value As Double)
            _Jornada = value
        End Set
    End Property
    Public Property UniMed() As String
        Get
            Return _UniMed
        End Get
        Set(ByVal value As String)
            _UniMed = value
        End Set
    End Property
    Public ReadOnly Property Total_Partida() As Double
        Get
            Return _TotalPartida
        End Get
    End Property
    Public Property SoloLectura() As Boolean
        Get
            Return _SoloLectura
        End Get
        Set(ByVal value As Boolean)
            _SoloLectura = value
        End Set
    End Property
#End Region

#Region "Propiedades Privadas"
    Private Property Det_Mat() As String
        Get
            Return _Det_Mat
        End Get
        Set(ByVal value As String)
            _Det_Mat = value
        End Set
    End Property
    Private Property Det_Eq() As Long
        Get
            Return _Det_Eq
        End Get
        Set(ByVal value As Long)
            _Det_Eq = value
        End Set
    End Property
    Private Property Det_Eq_New() As Long
        Get
            Return _Det_Eq_New
        End Get
        Set(ByVal value As Long)
            _Det_Eq_New = value
        End Set
    End Property
    Private Property Det_MO() As String
        Get
            Return _Det_MO
        End Get
        Set(ByVal value As String)
            _Det_MO = value
        End Set
    End Property
    Private Property Det_Ser() As String
        Get
            Return _Det_Ser
        End Get
        Set(ByVal value As String)
            _Det_Ser = value
        End Set
    End Property
    Private Property Nro_OC_Mat() As String
        Get
            Return _Nro_OC_Mat
        End Get
        Set(ByVal value As String)
            _Nro_OC_Mat = value
        End Set
    End Property
    Private Property Nro_OC_Ser() As String
        Get
            Return _Nro_OC_Ser
        End Get
        Set(ByVal value As String)
            _Nro_OC_Ser = value
        End Set
    End Property

#End Region

#Region "Procedimientos Privados"
    Private Sub CargarUnidadMedida()
        Dim Ls_Combo As List(Of ETUnidadMedida)
        Negocio.UnidadMedida = New NGUnidadMedida
        Entidad.MyLista = New ETMyLista

        Ls_Combo = New List(Of ETUnidadMedida)

        Entidad.MyLista = Negocio.UnidadMedida.ConsultarUnidadMedida

        If Entidad.MyLista.Validacion Then
            Ls_Combo = Entidad.MyLista.Ls_UnidadMedida
        End If

        Call CargarUltraCombo(Me.Cbo5, Ls_Combo, "Codigo", "Descripcion", String.Empty)
        Call CargarUltraCombo(Me.Cbo6, Ls_Combo, "Codigo", "Descripcion", String.Empty)
        Call CargarUltraCombo(Me.Cbo7, Ls_Combo, "Codigo", "Descripcion", String.Empty)
        Call CargarUltraCombo(Me.Cbo8, Ls_Combo, "Codigo", "Descripcion", String.Empty)
        Call CargarUltraCombo(Me.Cbo9, Ls_Combo, "Codigo", "Descripcion", String.Empty)

    End Sub
    Private Sub CalcularTotal()
        Dim SubTotal_Mat As Double = 0
        Dim SubTotal_Eq As Double = 0
        Dim SubTotal_MO As Double = 0
        Dim SubTotal_Ser As Double = 0

        If Not (Ls_Material Is Nothing) Then
            For Each Row As ETPresupuestoMaterial In Ls_Material
                SubTotal_Mat = SubTotal_Mat + Row.SubTotal
            Next
        End If
        If Not (Ls_Equipo Is Nothing) Then
            For Each Row As ETPresupuestoEquipo In Ls_Equipo
                SubTotal_Eq = SubTotal_Eq + Row.SubTotal
            Next
        End If
        If Not (Ls_ManoObra Is Nothing) Then
            For Each Row As ETPresupuestoManoObra In Ls_ManoObra
                SubTotal_MO = SubTotal_MO + Row.SubTotal
            Next
        End If
        If Not (Ls_Servicio Is Nothing) Then
            For Each Row As ETPresupuestoServicio In Ls_Servicio
                SubTotal_Ser = SubTotal_Ser + Row.SubTotal
            Next
        End If

        Me.Txt6.Value = SubTotal_Mat
        Me.Txt13.Value = SubTotal_Eq
        Me.Txt20.Value = SubTotal_MO
        Me.Txt26.Value = SubTotal_Ser
        Txt27.Value = SubTotal_Mat + SubTotal_Eq + SubTotal_MO + SubTotal_Ser
    End Sub
    Private Sub Cargar_Presupuesto_Detalle()
        If TipoFactor = "0" Then
            Me.Chk2.Checked = False
        Else
            Me.Chk2.Checked = True
            If TipoFactor = "1" Then
                Me.Rbn1.Checked = True
            Else
                Me.Rbn2.Checked = True
            End If

            TxtF1.Text = Factor
            TxtF2.Text = Jornada
            Cbo5.Value = UniMed
        End If

        _Ls_Material = Nothing
        _Ls_Equipo = Nothing
        _Ls_ManoObra = Nothing
        _Ls_Servicio = Nothing

        _Ls_Material_Del = Nothing
        _Ls_Equipo_Del = Nothing
        _Ls_ManoObra_Del = Nothing
        _Ls_Servicio_Del = Nothing

        Entidad.PresupuestoDet = New ETPresupuestoDetalle
        With Entidad.PresupuestoDet
            .PresupuestoDet = Presupuesto
            .Tipo = 4
        End With

        Negocio.PresupuestoDet = New NGPresupuestoDet
        Entidad.MyLista = New ETMyLista

        _Ls_Material = New List(Of ETPresupuestoMaterial)
        _Ls_Material_Del = New List(Of ETPresupuestoMaterial)

        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Material(Entidad.PresupuestoDet)
        If Entidad.MyLista.Validacion Then
            _Ls_Material = Entidad.MyLista.Ls_Presupuesto_Material
        End If

        _Ls_Equipo = New List(Of ETPresupuestoEquipo)
        _Ls_Equipo_Del = New List(Of ETPresupuestoEquipo)
        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Equipo(Entidad.PresupuestoDet)
        If Entidad.MyLista.Validacion Then
            _Ls_Equipo = Entidad.MyLista.Ls_Presupuesto_Equipo
        End If

        _Ls_ManoObra = New List(Of ETPresupuestoManoObra)
        _Ls_ManoObra_Del = New List(Of ETPresupuestoManoObra)
        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_ManoObra(Entidad.PresupuestoDet)
        If Entidad.MyLista.Validacion Then
            _Ls_ManoObra = Entidad.MyLista.Ls_Presupuesto_ManoObra
        End If

        _Ls_Servicio = New List(Of ETPresupuestoServicio)
        _Ls_Servicio_Del = New List(Of ETPresupuestoServicio)
        Entidad.MyLista = Negocio.PresupuestoDet.Consultar_Presupuesto_Servicio(Entidad.PresupuestoDet)
        If Entidad.MyLista.Validacion Then
            _Ls_Servicio = Entidad.MyLista.Ls_Presupuesto_Servicio
        End If

        Call CargarUltraGrid(Me.Grid1, Ls_Material)
        Call CargarUltraGrid(Me.Grid2, Ls_Equipo)
        Call CargarUltraGrid(Me.Grid3, Ls_ManoObra)
        Call CargarUltraGrid(Me.Grid4, Ls_Servicio)
        Call CalcularTotal()
    End Sub
    Private Sub HabilitarBotonesDet(ByVal Recurso As eBuscar)
        Select Case Recurso
            Case eBuscar.eMaterial
                Det_Mat = String.Empty
                Select Case TipoG_DetMat
                    Case eState.eNew, eState.eEdit
                        Btn3.Enabled = True
                        Btn4.Enabled = True
                        Btn5.Enabled = True
                        Btn6.Enabled = False
                        Btn7.Enabled = False
                        Txt3.ReadOnly = False
                    Case Else
                        Btn3.Enabled = False
                        Btn4.Enabled = True
                        Btn5.Enabled = False
                        Btn6.Enabled = True
                        Btn7.Enabled = True
                        Txt3.ReadOnly = True
                End Select
            Case eBuscar.eEquipo
                Det_Eq = 0
                Select Case TipoG_DetEq
                    Case eState.eNew, eState.eEdit
                        Btn8.Enabled = True
                        Btn9.Enabled = True
                        Btn10.Enabled = True
                        Btn11.Enabled = False
                        Btn12.Enabled = False
                        Txt9.ReadOnly = False
                        Txt11.ReadOnly = False
                    Case Else
                        Btn8.Enabled = False
                        Btn9.Enabled = True
                        Btn10.Enabled = False
                        Btn11.Enabled = True
                        Btn12.Enabled = True
                        Txt9.ReadOnly = True
                        Txt11.ReadOnly = True
                End Select
            Case eBuscar.eManoObra
                Det_MO = String.Empty
                Select Case TipoG_DetMO
                    Case eState.eNew, eState.eEdit
                        Btn13.Enabled = True
                        Btn14.Enabled = True
                        Btn15.Enabled = True
                        Btn16.Enabled = False
                        Btn17.Enabled = False
                        Txt16.ReadOnly = False
                        Txt18.ReadOnly = False
                    Case Else
                        Btn13.Enabled = False
                        Btn14.Enabled = True
                        Btn15.Enabled = False
                        Btn16.Enabled = True
                        Btn17.Enabled = True
                        Txt16.ReadOnly = True
                        Txt18.ReadOnly = True
                End Select
            Case eBuscar.eServicio
                Det_Ser = String.Empty
                Select Case TipoG_DetSer
                    Case eState.eNew, eState.eEdit
                        Btn18.Enabled = True
                        Btn19.Enabled = True
                        Btn20.Enabled = True
                        Btn21.Enabled = False
                        Btn22.Enabled = False
                        Txt23.ReadOnly = False
                    Case Else
                        Btn18.Enabled = False
                        Btn19.Enabled = True
                        Btn20.Enabled = False
                        Btn21.Enabled = True
                        Btn22.Enabled = True
                        Txt23.ReadOnly = True
                End Select
        End Select

    End Sub
    Private Sub LimpiarMateriales()
        Me.Txt1.Clear()
        Me.Txt2.Clear()
        Me.Txt3.Value = 0
        Me.Txt4.Value = 0
        Me.Txt5.Value = 0

        If Cbo6.Rows.Count > 0 Then Cbo6.Value = ""
    End Sub
    Private Sub LimpiarEquipos()
        Me.Txt7.Clear()
        Me.Txt8.Clear()
        Me.Txt9.Value = 0
        Me.Txt10.Value = 0
        Me.Txt11.Value = 0
        Me.Txt12.Value = 0
        If Cbo7.Rows.Count > 0 Then Cbo7.Value = ""
    End Sub
    Private Sub LimpiarManoObra()
        Me.Txt14.Clear()
        Me.Txt15.Clear()
        Me.Txt16.Value = 0
        Me.Txt17.Value = 0
        Me.Txt18.Value = 0
        Me.Txt19.Value = 0
        If Cbo8.Rows.Count > 0 Then Cbo8.Value = ""
    End Sub
    Private Sub LimpiarServicios()
        Me.Txt21.Clear()
        Me.Txt22.Clear()
        Me.Txt23.Value = 0
        Me.Txt24.Value = 0
        Me.Txt25.Value = 0
        If Cbo9.Rows.Count > 0 Then Cbo9.Value = ""
    End Sub
#End Region

#Region "Funciones Privadas"
    Private Function Validar_Material() As Boolean
        Validar_Material = True
        If String.IsNullOrEmpty(Me.Txt1.Text.Trim) Then
            MsgBox("Ingrese el Material", MsgBoxStyle.Critical, Companhia)
            If Btn3.Enabled = True Then Me.Btn3.Focus()
            Validar_Material = False
            Exit Function
        End If

        If String.IsNullOrEmpty(Me.Cbo6.Value) Then
            MsgBox("El Material no tiene Unidad de Medida", MsgBoxStyle.Critical, Companhia)
            Validar_Material = False
            Exit Function
        End If

        If Val(Me.Txt3.Value) = 0 Then
            MsgBox("Ingrese la Cantidad del Material", MsgBoxStyle.Critical, Companhia)
            Validar_Material = False
            Txt3.Focus()
            Exit Function
        End If

        If Val(Me.Txt4.Value) = 0 Then
            MsgBox("El Material no tiene Precio", MsgBoxStyle.Critical, Companhia)
            Validar_Material = False
            Exit Function
        End If
    End Function
    Private Function Validar_Equipo() As Boolean
        Validar_Equipo = True
        If String.IsNullOrEmpty(Me.Txt7.Text.Trim) Then
            MsgBox("Ingrese el Material", MsgBoxStyle.Critical, Companhia)
            If Btn8.Enabled = True Then Me.Btn8.Focus()
            Validar_Equipo = False
            Exit Function
        End If

        If String.IsNullOrEmpty(Me.Cbo7.Value) Then
            MsgBox("El Material no tiene Unidad de Medida", MsgBoxStyle.Critical, Companhia)
            Validar_Equipo = False
            Exit Function
        End If

        If Val(Me.Txt9.Value) = 0 Then
            MsgBox("Ingrese la Cuadrilla de Equipo", MsgBoxStyle.Critical, Companhia)
            Validar_Equipo = False
            Txt9.Focus()
            Exit Function
        End If

        If Val(Me.Txt11.Value) = 0 Then
            MsgBox("El Equipo no tiene Precio", MsgBoxStyle.Critical, Companhia)
            Validar_Equipo = False
            Exit Function
        End If
    End Function
    Private Function Validar_ManoObra() As Boolean
        Validar_ManoObra = True
        If String.IsNullOrEmpty(Me.Txt14.Text.Trim) Then
            MsgBox("Ingrese el Cargo", MsgBoxStyle.Critical, Companhia)
            If Btn13.Enabled = True Then Me.Btn13.Focus()
            Validar_ManoObra = False
            Exit Function
        End If

        If String.IsNullOrEmpty(Me.Cbo8.Value) Then
            MsgBox("El Cargo no tiene Unidad de Medida", MsgBoxStyle.Critical, Companhia)
            Validar_ManoObra = False
            Exit Function
        End If

        If Val(Me.Txt16.Value) = 0 Then
            MsgBox("Ingrese la Cuadrilla de la Mano de Obra", MsgBoxStyle.Critical, Companhia)
            Validar_ManoObra = False
            Txt3.Focus()
            Exit Function
        End If

        If Val(Me.Txt18.Value) = 0 Then
            MsgBox("El Cargo no tiene Precio", MsgBoxStyle.Critical, Companhia)
            Validar_ManoObra = False
            Exit Function
        End If
    End Function
    Private Function Validar_Servicio() As Boolean
        Validar_Servicio = True
        If String.IsNullOrEmpty(Me.Txt21.Text.Trim) Then
            MsgBox("Ingrese el Servicio", MsgBoxStyle.Critical, Companhia)
            If Btn18.Enabled = True Then Me.Btn18.Focus()
            Validar_Servicio = False
            Exit Function
        End If

        If String.IsNullOrEmpty(Me.Cbo9.Value) Then
            MsgBox("El Servicio no tiene Unidad de Medida", MsgBoxStyle.Critical, Companhia)
            Validar_Servicio = False
            Exit Function
        End If
        If Val(Me.Txt23.Value) = 0 Then
            MsgBox("Ingrese la Cantidad del Servicio", MsgBoxStyle.Critical, Companhia)
            Validar_Servicio = False
            Exit Function
        End If

        If Val(Me.Txt24.Value) = 0 Then
            MsgBox("El Servicio no tiene Precio", MsgBoxStyle.Critical, Companhia)
            Validar_Servicio = False
            Exit Function
        End If
    End Function
#End Region

#Region "Formulario"
    Private Sub frmPPrespuestoRecursos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Call CargarUnidadMedida()
        Call Cargar_Presupuesto_Detalle()
        TipoG_DetMat = eState.eView
        TipoG_DetEq = eState.eView
        TipoG_DetMO = eState.eView
        TipoG_DetSer = eState.eView
        Call HabilitarBotonesDet(eBuscar.eMaterial)
        Call HabilitarBotonesDet(eBuscar.eEquipo)
        Call HabilitarBotonesDet(eBuscar.eManoObra)
        Call HabilitarBotonesDet(eBuscar.eServicio)

        Txt6.ReadOnly = True
        Txt13.ReadOnly = True
        Txt20.ReadOnly = True
        Txt26.ReadOnly = True
        Txt27.ReadOnly = True

        If SoloLectura = Boolean.TrueString Then
            Grb4.Enabled = Not SoloLectura
            Btn3.Enabled = Not SoloLectura
            Btn4.Enabled = Not SoloLectura
            Btn5.Enabled = Not SoloLectura
            Btn6.Enabled = Not SoloLectura
            Btn7.Enabled = Not SoloLectura
            Btn8.Enabled = Not SoloLectura
            Btn9.Enabled = Not SoloLectura
            Btn10.Enabled = Not SoloLectura
            Btn11.Enabled = Not SoloLectura
            Btn12.Enabled = Not SoloLectura
            Btn13.Enabled = Not SoloLectura
            Btn14.Enabled = Not SoloLectura
            Btn15.Enabled = Not SoloLectura
            Btn16.Enabled = Not SoloLectura
            Btn17.Enabled = Not SoloLectura
            Btn18.Enabled = Not SoloLectura
            Btn19.Enabled = Not SoloLectura
            Btn20.Enabled = Not SoloLectura
            Btn21.Enabled = Not SoloLectura
            Btn22.Enabled = Not SoloLectura
        End If
    End Sub

#End Region

#Region "Grillas"
    Private Sub Inicializar_Grillas(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout, Grid3.InitializeLayout, Grid4.InitializeLayout
        With e.Layout.Bands(0)
            .ColHeadersVisible = Boolean.TrueString
            For Each uColumn As UltraGridColumn In .Columns
                uColumn.CellActivation = Activation.NoEdit
                Select Case sender.Name
                    Case "Grid1"
                        If Not (uColumn.Key = "Cod_Mat" OrElse uColumn.Key = "Material" _
                        OrElse uColumn.Key = "UniMed" OrElse uColumn.Key = "Cantidad" _
                        OrElse uColumn.Key = "Precio" OrElse uColumn.Key = "SubTotal" _
                        OrElse uColumn.Key = "Nro_OC") Then
                            uColumn.Hidden = Boolean.TrueString
                        Else
                            uColumn.Hidden = Boolean.FalseString
                        End If
                    Case "Grid2"
                        If Not (uColumn.Key = "Cod_Eq" OrElse uColumn.Key = "Equipo" _
                        OrElse uColumn.Key = "UniMed" OrElse uColumn.Key = "Cantidad" _
                        OrElse uColumn.Key = "Precio" OrElse uColumn.Key = "SubTotal") Then
                            uColumn.Hidden = Boolean.TrueString
                        Else
                            uColumn.Hidden = Boolean.FalseString
                        End If
                    Case "Grid3"
                        If Not (uColumn.Key = "Cod_Cargo" OrElse uColumn.Key = "Cargo" _
                        OrElse uColumn.Key = "UniMed" OrElse uColumn.Key = "Cantidad" _
                        OrElse uColumn.Key = "Precio" OrElse uColumn.Key = "SubTotal") Then
                            uColumn.Hidden = Boolean.TrueString
                        Else
                            uColumn.Hidden = Boolean.FalseString
                        End If
                    Case "Grid4"
                        If Not (uColumn.Key = "Cod_Ser" OrElse uColumn.Key = "Servicio" _
                        OrElse uColumn.Key = "UniMed" OrElse uColumn.Key = "Cantidad" _
                        OrElse uColumn.Key = "Precio" OrElse uColumn.Key = "SubTotal" _
                        OrElse uColumn.Key = "Nro_OC") Then
                            uColumn.Hidden = Boolean.TrueString
                        Else
                            uColumn.Hidden = Boolean.FalseString
                        End If
                End Select


            Next
        End With
    End Sub
#End Region
   
#Region "Texto"

    Private Sub Txt3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt3.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Me.Btn5.Enabled = True Then
                Btn5.Focus()
            End If
        End If
        KeyAscii = ValidarDecimal(KeyAscii, Txt3.Value)
        e.KeyChar = Chr(KeyAscii)
    End Sub
    Private Sub Txt3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt3.ValueChanged
        Me.Txt5.Value = Val(Me.Txt3.Value) * Val(Me.Txt4.Value)
    End Sub

    Private Sub Txt4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt4.ValueChanged
        Me.Txt5.Value = Val(Me.Txt3.Value) * Val(Me.Txt4.Value)
    End Sub

    Private Sub Txt9_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt9.ValueChanged
        If Chk2.Checked = False Then
            Me.Txt10.Value = Txt9.Value
        Else
            If Rbn1.Checked = True Then
                Txt10.Value = Val(Txt9.Value) * Val(TxtF2.Value) / Val(TxtF1.Value)
            Else
                Txt10.Value = Val(Txt9.Value) * Val(TxtF2.Value) * Val(TxtF1.Value)
            End If
        End If
    End Sub
    Private Sub Txt10_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt10.ValueChanged
        Me.Txt12.Value = Val(Me.Txt10.Value) * Val(Me.Txt11.Value)
    End Sub
    Private Sub Txt11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt11.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Btn10.Enabled = True Then Btn10.Focus()
        End If
        KeyAscii = ValidarDecimal(KeyAscii, Txt11.Value)
        e.KeyChar = Chr(KeyAscii)
    End Sub
    Private Sub Txt11_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt11.ValueChanged
        Me.Txt12.Value = Val(Me.Txt10.Value) * Val(Me.Txt11.Value)
    End Sub

    Private Sub Txt16_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt16.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Txt18.Focus()
        End If
        KeyAscii = ValidarDecimal(KeyAscii, Txt16.Value)
        e.KeyChar = Chr(KeyAscii)
    End Sub
    Private Sub Txt16_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt16.ValueChanged
        If Chk2.Checked = False Then
            Me.Txt17.Value = Txt16.Value
        Else
            If Rbn1.Checked = True Then
                Txt17.Value = Val(Txt16.Value) * Val(TxtF2.Value) / Val(TxtF1.Value)
            Else
                Txt17.Value = Val(Txt16.Value) * Val(TxtF2.Value) * Val(TxtF1.Value)
            End If
        End If
    End Sub
    Private Sub Txt17_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt17.ValueChanged
        Me.Txt19.Value = Val(Me.Txt17.Value) * Val(Me.Txt18.Value)
    End Sub
    Private Sub Txt18_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt18.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Btn15.Enabled = True Then Btn15.Focus()
        End If
        KeyAscii = ValidarDecimal(KeyAscii, Txt18.Value)
        e.KeyChar = Chr(KeyAscii)
    End Sub
    Private Sub Txt18_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt18.ValueChanged
        Me.Txt19.Value = Val(Me.Txt17.Value) * Val(Me.Txt18.Value)
    End Sub

    Private Sub Txt23_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt23.KeyPress
        Dim KeyAscii As Integer
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If Btn20.Enabled = True Then Btn20.Focus()
        End If
        KeyAscii = ValidarDecimal(KeyAscii, Txt23.Value)
        e.KeyChar = Chr(KeyAscii)
    End Sub
    Private Sub Txt23_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt23.ValueChanged
        Me.Txt25.Value = Val(Me.Txt23.Value) * Val(Me.Txt24.Value)
    End Sub
    Private Sub Txt24_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt24.ValueChanged
        Me.Txt25.Value = Val(Me.Txt23.Value) * Val(Me.Txt24.Value)
    End Sub

#End Region

#Region "Checkear"
    Private Sub Chk2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk2.CheckedChanged
        Me.TxtF1.ReadOnly = Not Chk2.Checked
        Me.TxtF2.ReadOnly = Not Chk2.Checked
        Me.Btn2.Enabled = Chk2.Checked
        Me.Rbn1.Enabled = Chk2.Checked
        Me.Rbn2.Enabled = Chk2.Checked
        Me.TxtF1.Value = 0
        Me.TxtF2.Value = 0
        If Me.Chk2.Checked = True Then
            Me.Rbn1.Checked = True
            Cbo5.Value = "35"
        End If
    End Sub
#End Region

#Region "Botones"
    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        If Chk2.Checked = True Then
            If Val(TxtF1.Text) = 0 Then Return
            If Val(TxtF2.Text) = 0 Then Return
        End If

        If Not (Ls_Equipo Is Nothing) Then
            For Each Row As ETPresupuestoEquipo In _Ls_Equipo
                If Chk2.Checked = False Then
                    Row.Cantidad = Row.Cuadrilla
                Else
                    If Rbn1.Checked = True Then
                        Row.Cantidad = Row.Cuadrilla * Val(TxtF2.Value) / Val(TxtF1.Value)
                    Else
                        Row.Cantidad = Row.Cuadrilla * Val(TxtF2.Value) * Val(TxtF1.Value)
                    End If
                End If
                Row.SubTotal = Row.Cantidad * Row.Precio
            Next

            Call CargarUltraGrid(Grid2, _Ls_Equipo)
        End If

        If Not (Ls_ManoObra Is Nothing) Then
            For Each Row As ETPresupuestoManoObra In _Ls_ManoObra
                If Chk2.Checked = False Then
                    Row.Cantidad = Row.Cuadrilla
                Else
                    If Rbn1.Checked = True Then
                        Row.Cantidad = Row.Cuadrilla * Val(TxtF2.Value) / Val(TxtF1.Value)
                    Else
                        Row.Cantidad = Row.Cuadrilla * Val(TxtF2.Value) * Val(TxtF1.Value)
                    End If
                End If
                Row.SubTotal = Row.Cantidad * Row.Precio
            Next

            Call CargarUltraGrid(Grid3, _Ls_ManoObra)
        End If

        Call CalcularTotal()
    End Sub

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        Dim frm As New frmBuscar
        frm.TipoReporte = 1
        frm.Formulario = frmBuscar.eState.frm_Recurso_Partida
        frm.ShowDialog()
        Txt1.Text = frm.Flag2
        Txt2.Text = frm.Descripcion
        Txt4.Value = frm.Flag3
        Nro_OC_Mat = frm.Flag4
        Cbo6.Value = frm.Flag5
        frm = Nothing
    End Sub
    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        Call LimpiarMateriales()
        TipoG_DetMat = eState.eNew
        Call HabilitarBotonesDet(eBuscar.eMaterial)
    End Sub
    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click
        Dim Repetir As Integer = 0

        If Validar_Material() = False Then
            Exit Sub
        End If

        Entidad.Presupuesto_Material = New ETPresupuestoMaterial
        With Entidad.Presupuesto_Material
            .Cod_Mat = Me.Txt1.Text
            .Material = Me.Txt2.Text
            .Cod_UniMed = Me.Cbo6.Value
            .UniMed = Me.Cbo6.Text
            .Cantidad = Me.Txt3.Value
            .Precio = Me.Txt4.Value
            .SubTotal = Val(Me.Txt3.Value) * Val(Me.Txt4.Value)
            .Nro_OC = Nro_OC_Mat
            .Tipo = TipoG_DetMat
            .Presupuesto = Presupuesto
            .Usuario = User_Sistema
        End With

        If TipoG_DetMat = eState.eNew Then
            For Each Row As ETPresupuestoMaterial In Ls_Material
                If Row.Cod_Mat = Entidad.Presupuesto_Material.Cod_Mat Then
                    MsgBox("Material ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If
            Next

            Ls_Material.Add(Entidad.Presupuesto_Material)
            Call CargarUltraGrid(Grid1, Ls_Material)
        ElseIf TipoG_DetMat = eState.eEdit Then
            If Det_Mat.Trim = Me.Txt1.Text.Trim Then
                Me.Grid1.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo6.Value
                Me.Grid1.ActiveRow.Cells("UniMed").Value = Me.Cbo6.Text
                Me.Grid1.ActiveRow.Cells("Cantidad").Value = Me.Txt3.Value
                Me.Grid1.ActiveRow.Cells("Precio").Value = Me.Txt4.Value
                Me.Grid1.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt3.Value) * Val(Me.Txt4.Value)
                Me.Grid1.ActiveRow.Cells("Nro_OC").Value = Nro_OC_Mat
            Else

                For Each Row As ETPresupuestoMaterial In Ls_Material
                    If Row.Cod_Mat = Entidad.Presupuesto_Material.Cod_Mat Then
                        Repetir = Repetir + 1
                    End If
                Next

                If Repetir > 0 Then
                    MsgBox("Material ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If

                Me.Grid1.ActiveRow.Cells("Cod_Mat").Value = Me.Txt1.Text
                Me.Grid1.ActiveRow.Cells("Material").Value = Me.Txt2.Text
                Me.Grid1.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo6.Value
                Me.Grid1.ActiveRow.Cells("UniMed").Value = Me.Cbo6.Text
                Me.Grid1.ActiveRow.Cells("Cantidad").Value = Me.Txt3.Value
                Me.Grid1.ActiveRow.Cells("Precio").Value = Me.Txt4.Value
                Me.Grid1.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt3.Value) * Val(Me.Txt4.Value)
                Me.Grid1.ActiveRow.Cells("Nro_OC").Value = Nro_OC_Mat
                Me.Grid1.ActiveRow.Cells("Usuario").Value = User_Sistema

                If Grid1.ActiveRow.Cells("Tipo").Value = 2 Then
                    Me.Grid1.ActiveRow.Cells("Material_Ant").Value = Det_Mat
                End If

            End If
        End If

        Call CalcularTotal()
        Call LimpiarMateriales()
        TipoG_DetMat = eState.eView
        Call HabilitarBotonesDet(eBuscar.eMaterial)
    End Sub
    Private Sub Btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn6.Click
        If Me.Grid1.Rows.Count <= 0 Then Return
        If Me.Grid1.ActiveRow Is Nothing Then Return

        TipoG_DetMat = eState.eEdit
        Call HabilitarBotonesDet(eBuscar.eMaterial)

        Txt1.Text = Grid1.ActiveRow.Cells("Cod_Mat").Value
        Txt2.Text = Grid1.ActiveRow.Cells("Material").Value
        Txt3.Value = Grid1.ActiveRow.Cells("Cantidad").Value
        Txt4.Value = Grid1.ActiveRow.Cells("Precio").Value
        Txt5.Value = Grid1.ActiveRow.Cells("SubTotal").Value
        Cbo6.Value = Grid1.ActiveRow.Cells("Cod_UniMed").Value
        Det_Mat = Txt1.Text
        Nro_OC_Mat = Grid1.ActiveRow.Cells("Nro_OC").Value
    End Sub
    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        If Me.Grid1.Rows.Count <= 0 Then Return
        If Me.Grid1.ActiveRow Is Nothing Then Return
        If MsgBox("Esta seguro de quitar el Material: " & Grid1.ActiveRow.Cells("Cod_Mat").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


        If Grid1.ActiveRow.Cells("Tipo").Value <> 2 Then
            Ls_Material.RemoveAt(Grid1.ActiveRow.Index)
            Call CargarUltraGrid(Grid1, Ls_Material)
            Exit Sub
        End If

        Entidad.Presupuesto_Material = New ETPresupuestoMaterial
        With Entidad.Presupuesto_Material
            .Cod_Mat = Grid1.ActiveRow.Cells("Cod_Mat").Value
            .Presupuesto = Grid1.ActiveRow.Cells("Presupuesto").Value
            .Usuario = User_Sistema
            .Tipo = 3
        End With

        _Ls_Material_Del.Add(Entidad.Presupuesto_Material)

        Ls_Material.RemoveAt(Grid1.ActiveRow.Index)
        Call CargarUltraGrid(Grid1, Ls_Material)
        Call CalcularTotal()

    End Sub

    Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn8.Click
        Dim frm As New frmBuscar
        frm.TipoReporte = 2
        frm.Formulario = frmBuscar.eState.frm_Recurso_Partida
        frm.ShowDialog()
        Txt7.Text = frm.Flag2
        Txt8.Text = frm.Descripcion
        Txt11.Value = frm.Flag3
        Det_Eq_New = frm.ID
        Cbo7.Value = frm.Flag5
        frm = Nothing
    End Sub
    Private Sub Btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn9.Click
        Call LimpiarEquipos()
        TipoG_DetEq = eState.eNew
        Call HabilitarBotonesDet(eBuscar.eEquipo)
    End Sub
    Private Sub Btn10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn10.Click
        Dim Repetir As Integer = 0

        If Validar_Equipo() = False Then
            Exit Sub
        End If

        Entidad.Presupuesto_Equipo = New ETPresupuestoEquipo
        With Entidad.Presupuesto_Equipo
            .Cod_Eq = Me.Txt7.Text
            .Equipo = Me.Txt8.Text
            .EquipoID = Me.Det_Eq_New
            .Cod_UniMed = Me.Cbo7.Value
            .UniMed = Me.Cbo7.Text
            .Cuadrilla = Me.Txt9.Value
            .Cantidad = Me.Txt10.Value
            .Precio = Me.Txt11.Value
            .SubTotal = Val(Me.Txt10.Value) * Val(Me.Txt11.Value)
            .Tipo = TipoG_DetEq
            .Presupuesto = Presupuesto
            .Usuario = User_Sistema
        End With

        If TipoG_DetEq = eState.eNew Then
            For Each Row As ETPresupuestoEquipo In Ls_Equipo
                If Row.EquipoID = Entidad.Presupuesto_Equipo.EquipoID Then
                    MsgBox("Equipo ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If
            Next

            Ls_Equipo.Add(Entidad.Presupuesto_Equipo)
            Call CargarUltraGrid(Grid2, Ls_Equipo)
        ElseIf TipoG_DetEq = eState.eEdit Then
            If Det_Eq = Me.Det_Eq_New Then
                Me.Grid2.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo7.Value
                Me.Grid2.ActiveRow.Cells("UniMed").Value = Me.Cbo7.Text
                Me.Grid2.ActiveRow.Cells("Cuadrilla").Value = Me.Txt9.Value
                Me.Grid2.ActiveRow.Cells("Cantidad").Value = Me.Txt10.Value
                Me.Grid2.ActiveRow.Cells("Precio").Value = Me.Txt11.Value
                Me.Grid2.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt10.Value) * Val(Me.Txt11.Value)
            Else

                For Each Row As ETPresupuestoEquipo In Ls_Equipo
                    If Row.EquipoID = Entidad.Presupuesto_Equipo.EquipoID Then
                        Repetir = Repetir + 1
                    End If
                Next

                If Repetir > 0 Then
                    MsgBox("Equipo ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If

                Me.Grid2.ActiveRow.Cells("Cod_Eq").Value = Me.Txt7.Text
                Me.Grid2.ActiveRow.Cells("Equipo").Value = Me.Txt8.Text
                Me.Grid2.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo7.Value
                Me.Grid2.ActiveRow.Cells("UniMed").Value = Me.Cbo7.Text
                Me.Grid2.ActiveRow.Cells("Cuadrilla").Value = Me.Txt9.Text
                Me.Grid2.ActiveRow.Cells("Cantidad").Value = Me.Txt10.Text
                Me.Grid2.ActiveRow.Cells("Precio").Value = Me.Txt11.Text
                Me.Grid2.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt10.Text) * Val(Me.Txt11.Text)
                Me.Grid2.ActiveRow.Cells("EquipoID").Value = Det_Eq_New
                Me.Grid2.ActiveRow.Cells("Usuario").Value = User_Sistema

                If Grid2.ActiveRow.Cells("Tipo").Value = 2 Then
                    Me.Grid2.ActiveRow.Cells("Equipo_Ant").Value = Det_Eq
                End If

            End If
        End If

        Call CalcularTotal()
        Call LimpiarEquipos()
        TipoG_DetEq = eState.eView
        Call HabilitarBotonesDet(eBuscar.eEquipo)
    End Sub
    Private Sub Btn11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn11.Click
        If Me.Grid2.Rows.Count <= 0 Then Return
        If Me.Grid2.ActiveRow Is Nothing Then Return

        TipoG_DetEq = eState.eEdit
        Call HabilitarBotonesDet(eBuscar.eEquipo)

        Txt7.Text = Grid2.ActiveRow.Cells("Cod_Eq").Value
        Txt8.Text = Grid2.ActiveRow.Cells("Equipo").Value
        Txt9.Value = Grid2.ActiveRow.Cells("Cuadrilla").Value
        Txt10.Value = Grid2.ActiveRow.Cells("Cantidad").Value
        Txt11.Value = Grid2.ActiveRow.Cells("Precio").Value
        Txt12.Value = Grid2.ActiveRow.Cells("SubTotal").Value
        Cbo7.Value = Grid2.ActiveRow.Cells("Cod_UniMed").Value
        Det_Eq = Grid2.ActiveRow.Cells("EquipoID").Value
        Det_Eq_New = Grid2.ActiveRow.Cells("EquipoID").Value
    End Sub
    Private Sub Btn12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn12.Click
        If Me.Grid2.Rows.Count <= 0 Then Return
        If Me.Grid2.ActiveRow Is Nothing Then Return
        If MsgBox("Esta seguro de quitar el Equipo: " & Grid2.ActiveRow.Cells("Cod_Eq").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        If Grid2.ActiveRow.Cells("Tipo").Value <> 2 Then
            Ls_Equipo.RemoveAt(Grid2.ActiveRow.Index)
            Call CargarUltraGrid(Grid2, Ls_Equipo)
            Exit Sub
        End If

        Entidad.Presupuesto_Equipo = New ETPresupuestoEquipo
        With Entidad.Presupuesto_Equipo
            .Cod_Eq = Grid2.ActiveRow.Cells("EquipoID").Value
            .Presupuesto = Grid2.ActiveRow.Cells("Presupuesto").Value
            .Usuario = User_Sistema
            .Tipo = 3
        End With

        _Ls_Equipo_Del.Add(Entidad.Presupuesto_Equipo)

        Ls_Equipo.RemoveAt(Grid2.ActiveRow.Index)
        Call CargarUltraGrid(Grid2, Ls_Equipo)
        Call CalcularTotal()
    End Sub

    Private Sub Btn13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn13.Click
        Dim frm As New frmBuscar
        frm.TipoReporte = 3
        frm.Formulario = frmBuscar.eState.frm_Recurso_Partida
        frm.ShowDialog()
        Txt14.Text = frm.Flag2
        Txt15.Text = frm.Descripcion
        Txt18.Value = frm.Flag3
        Cbo8.Value = frm.Flag5
        frm = Nothing
    End Sub
    Private Sub Btn14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn14.Click
        Call LimpiarManoObra()
        TipoG_DetMO = eState.eNew
        Call HabilitarBotonesDet(eBuscar.eManoObra)
    End Sub
    Private Sub Btn15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn15.Click
        Dim Repetir As Integer = 0

        If Validar_ManoObra() = False Then
            Exit Sub
        End If

        Entidad.Presupuesto_ManoObra = New ETPresupuestoManoObra
        With Entidad.Presupuesto_ManoObra
            .Cod_Cargo = Me.Txt14.Text
            .Cargo = Me.Txt15.Text
            .Cod_UniMed = Me.Cbo8.Value
            .UniMed = Me.Cbo8.Text
            .Cuadrilla = Me.Txt16.Value
            .Cantidad = Me.Txt17.Value
            .Precio = Me.Txt18.Value
            .SubTotal = Val(Me.Txt17.Value) * Val(Me.Txt18.Value)
            .Tipo = TipoG_DetMO
            .Presupuesto = Presupuesto
            .Usuario = User_Sistema
        End With

        If TipoG_DetMO = eState.eNew Then
            For Each Row As ETPresupuestoManoObra In Ls_ManoObra
                If Row.Cod_Cargo = Entidad.Presupuesto_ManoObra.Cod_Cargo Then
                    MsgBox("El Cargo ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If
            Next

            Ls_ManoObra.Add(Entidad.Presupuesto_ManoObra)
            Call CargarUltraGrid(Grid3, Ls_ManoObra)
        ElseIf TipoG_DetMO = eState.eEdit Then
            If Det_MO.Trim = Me.Txt14.Text.Trim Then
                Me.Grid3.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo8.Value
                Me.Grid3.ActiveRow.Cells("UniMed").Value = Me.Cbo8.Text
                Me.Grid3.ActiveRow.Cells("Cuadrilla").Value = Me.Txt16.Value
                Me.Grid3.ActiveRow.Cells("Cantidad").Value = Me.Txt17.Value
                Me.Grid3.ActiveRow.Cells("Precio").Value = Me.Txt18.Value
                Me.Grid3.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt17.Value) * Val(Me.Txt18.Value)
            Else

                For Each Row As ETPresupuestoManoObra In Ls_ManoObra
                    If Row.Cod_Cargo = Entidad.Presupuesto_ManoObra.Cod_Cargo Then
                        Repetir = Repetir + 1
                    End If
                Next

                If Repetir > 0 Then
                    MsgBox("El Cargo ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If

                Me.Grid3.ActiveRow.Cells("Cod_Cargo").Value = Me.Txt14.Text
                Me.Grid3.ActiveRow.Cells("Cargo").Value = Me.Txt15.Text
                Me.Grid3.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo8.Value
                Me.Grid3.ActiveRow.Cells("UniMed").Value = Me.Cbo8.Text
                Me.Grid3.ActiveRow.Cells("Cuadrilla").Value = Me.Txt16.Value
                Me.Grid3.ActiveRow.Cells("Cantidad").Value = Me.Txt17.Value
                Me.Grid3.ActiveRow.Cells("Precio").Value = Me.Txt18.Value
                Me.Grid3.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt17.Value) * Val(Me.Txt18.Value)
                Me.Grid3.ActiveRow.Cells("Usuario").Value = User_Sistema

                If Grid3.ActiveRow.Cells("Tipo").Value = 2 Then
                    Me.Grid3.ActiveRow.Cells("Cargo_Ant").Value = Det_MO
                End If

            End If
        End If

        Call CalcularTotal()
        Call LimpiarManoObra()
        TipoG_DetMO = eState.eView
        Call HabilitarBotonesDet(eBuscar.eManoObra)
    End Sub
    Private Sub Btn16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn16.Click
        If Me.Grid3.Rows.Count <= 0 Then Return
        If Me.Grid3.ActiveRow Is Nothing Then Return

        TipoG_DetMO = eState.eEdit
        Call HabilitarBotonesDet(eBuscar.eManoObra)

        Txt14.Text = Grid3.ActiveRow.Cells("Cod_Cargo").Value
        Txt15.Text = Grid3.ActiveRow.Cells("Cargo").Value
        Txt16.Value = Grid3.ActiveRow.Cells("Cuadrilla").Value
        Txt17.Value = Grid3.ActiveRow.Cells("Cantidad").Value
        Txt18.Value = Grid3.ActiveRow.Cells("Precio").Value
        Txt19.Value = Grid3.ActiveRow.Cells("SubTotal").Value
        Cbo8.Value = Grid3.ActiveRow.Cells("Cod_UniMed").Value
        Det_MO = Grid3.ActiveRow.Cells("Cod_Cargo").Value
    End Sub
    Private Sub Btn17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn17.Click
        If Me.Grid3.Rows.Count <= 0 Then Return
        If Me.Grid3.ActiveRow Is Nothing Then Return
        If MsgBox("Esta seguro de quitar el Cargo: " & Grid3.ActiveRow.Cells("Cod_Cargo").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub


        If Grid3.ActiveRow.Cells("Tipo").Value <> 2 Then
            Ls_ManoObra.RemoveAt(Grid3.ActiveRow.Index)
            Call CargarUltraGrid(Grid3, Ls_ManoObra)
            Exit Sub
        End If

        Entidad.Presupuesto_ManoObra = New ETPresupuestoManoObra
        With Entidad.Presupuesto_ManoObra
            .Cod_Cargo = Grid3.ActiveRow.Cells("Cargo").Value
            .Presupuesto = Grid3.ActiveRow.Cells("Presupuesto").Value
            .Usuario = User_Sistema
            .Tipo = 3
        End With

        _Ls_ManoObra_Del.Add(Entidad.Presupuesto_ManoObra)

        Ls_ManoObra.RemoveAt(Grid3.ActiveRow.Index)
        Call CargarUltraGrid(Grid3, Ls_ManoObra)
        Call CalcularTotal()
    End Sub

    Private Sub Btn18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn18.Click
        Dim frm As New frmBuscar
        frm.TipoReporte = 4
        frm.Formulario = frmBuscar.eState.frm_Recurso_Partida
        frm.ShowDialog()
        Txt21.Text = frm.Flag2
        Txt22.Text = frm.Descripcion
        Txt24.Value = frm.Flag3
        Nro_OC_Ser = frm.Flag4
        Cbo9.Value = frm.Flag5
        frm = Nothing
    End Sub
    Private Sub Btn19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn19.Click
        Call LimpiarServicios()
        TipoG_DetSer = eState.eNew
        Call HabilitarBotonesDet(eBuscar.eServicio)
    End Sub
    Private Sub Btn20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn20.Click
        Dim Repetir As Integer = 0

        If Validar_Servicio() = False Then
            Exit Sub
        End If

        Entidad.Presupuesto_Servicio = New ETPresupuestoServicio
        With Entidad.Presupuesto_Servicio
            .Cod_Ser = Me.Txt21.Text
            .Servicio = Me.Txt22.Text
            .Cod_UniMed = Me.Cbo9.Value
            .UniMed = Me.Cbo9.Text
            .Cantidad = Me.Txt23.Value
            .Precio = Me.Txt24.Value
            .SubTotal = Val(Me.Txt23.Value) * Val(Me.Txt24.Value)
            .Nro_OC = Nro_OC_Ser
            .Tipo = TipoG_DetSer
            .Presupuesto = Presupuesto
            .Usuario = User_Sistema
        End With

        If TipoG_DetSer = eState.eNew Then
            For Each Row As ETPresupuestoServicio In Ls_Servicio
                If Row.Cod_Ser = Entidad.Presupuesto_Servicio.Cod_Ser Then
                    MsgBox("Servicio ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If
            Next

            Ls_Servicio.Add(Entidad.Presupuesto_Servicio)
            Call CargarUltraGrid(Grid4, Ls_Servicio)
        ElseIf TipoG_DetSer = eState.eEdit Then
            If Det_Ser.Trim = Me.Txt21.Text.Trim Then
                Me.Grid4.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo9.Value
                Me.Grid4.ActiveRow.Cells("UniMed").Value = Me.Cbo9.Text
                Me.Grid4.ActiveRow.Cells("Cantidad").Value = Me.Txt23.Value
                Me.Grid4.ActiveRow.Cells("Precio").Value = Me.Txt24.Value
                Me.Grid4.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt23.Value) * Val(Me.Txt24.Value)
                Me.Grid4.ActiveRow.Cells("Nro_OC").Value = Nro_OC_Ser
            Else

                For Each Row As ETPresupuestoServicio In Ls_Servicio
                    If Row.Cod_Ser = Entidad.Presupuesto_Servicio.Cod_Ser Then
                        Repetir = Repetir + 1
                    End If
                Next

                If Repetir > 0 Then
                    MsgBox("Servicio ya ingresado en la Lista", MsgBoxStyle.Critical, msgComacsa)
                    Exit Sub
                End If

                Me.Grid4.ActiveRow.Cells("Cod_Ser").Value = Me.Txt21.Text
                Me.Grid4.ActiveRow.Cells("Servicio").Value = Me.Txt22.Text
                Me.Grid4.ActiveRow.Cells("Cod_UniMed").Value = Me.Cbo9.Value
                Me.Grid4.ActiveRow.Cells("UniMed").Value = Me.Cbo9.Text
                Me.Grid4.ActiveRow.Cells("Cantidad").Value = Me.Txt23.Value
                Me.Grid4.ActiveRow.Cells("Precio").Value = Me.Txt24.Value
                Me.Grid4.ActiveRow.Cells("SubTotal").Value = Val(Me.Txt23.Value) * Val(Me.Txt24.Value)
                Me.Grid4.ActiveRow.Cells("Nro_OC").Value = Nro_OC_Ser
                Me.Grid4.ActiveRow.Cells("Usuario").Value = User_Sistema

                If Grid4.ActiveRow.Cells("Tipo").Value = 2 Then
                    Me.Grid4.ActiveRow.Cells("Servicio_Ant").Value = Det_Ser
                End If

            End If
        End If

        Call CalcularTotal()
        Call LimpiarServicios()
        TipoG_DetSer = eState.eView
        Call HabilitarBotonesDet(eBuscar.eServicio)
    End Sub
    Private Sub Btn21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn21.Click
        If Me.Grid4.Rows.Count <= 0 Then Return
        If Me.Grid4.ActiveRow Is Nothing Then Return

        TipoG_DetSer = eState.eEdit
        Call HabilitarBotonesDet(eBuscar.eServicio)

        Txt21.Text = Grid4.ActiveRow.Cells("Cod_Ser").Value
        Txt22.Text = Grid4.ActiveRow.Cells("Servicio").Value
        Txt23.Value = Grid4.ActiveRow.Cells("Cantidad").Value
        Txt24.Value = Grid4.ActiveRow.Cells("Precio").Value
        Txt25.Value = Grid4.ActiveRow.Cells("SubTotal").Value
        Cbo9.Value = Grid4.ActiveRow.Cells("Cod_UniMed").Value
        Det_Ser = Txt1.Text
        Nro_OC_Ser = Grid4.ActiveRow.Cells("Nro_OC").Value
    End Sub
    Private Sub Btn22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn22.Click
        If Me.Grid4.Rows.Count <= 0 Then Return
        If Me.Grid4.ActiveRow Is Nothing Then Return
        If MsgBox("Esta seguro de quitar el Material: " & Grid1.ActiveRow.Cells("Cod_Mat").Value, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        If Grid4.ActiveRow.Cells("Tipo").Value <> 2 Then
            Ls_Servicio.RemoveAt(Grid4.ActiveRow.Index)
            Call CargarUltraGrid(Grid4, Ls_Servicio)
            Exit Sub
        End If

        Entidad.Presupuesto_Servicio = New ETPresupuestoServicio
        With Entidad.Presupuesto_Servicio
            .Cod_Ser = Grid4.ActiveRow.Cells("Cod_Ser").Value
            .Presupuesto = Grid4.ActiveRow.Cells("Presupuesto").Value
            .Usuario = User_Sistema
            .Tipo = 3
        End With

        _Ls_Servicio_Del.Add(Entidad.Presupuesto_Servicio)

        Ls_Servicio.RemoveAt(Grid4.ActiveRow.Index)
        Call CargarUltraGrid(Grid4, Ls_Servicio)
        Call CalcularTotal()

    End Sub

    Private Sub Btn23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn23.Click
        Call CalcularTotal()
        If Chk2.Checked = False Then
            TipoFactor = "0"
        ElseIf Rbn1.Checked = True Then
            TipoFactor = "1"
        Else
            TipoFactor = "2"
        End If
        Factor = Val(TxtF1.Value)
        Jornada = Val(TxtF2.Value)
        UniMed = Cbo5.Value
        Close()
        _TotalPartida = Val(Me.Txt27.Value)

    End Sub
#End Region


End Class