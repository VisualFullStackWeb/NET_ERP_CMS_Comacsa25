Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmPOrdenTrabajo
#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)
    Private Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eSelect = 4
    End Enum
    Private Enum ValorTipoDato
        vVacio = 0
        vTexto = 1
        vEntero = 2
        vDecimal = 3
        vDate = 4
        vTime = 5
    End Enum

    Private Enum NameFormulario
        eOrdenTrabajo = 76
        eBackLog = 77
    End Enum
    Private Formulario As NameFormulario

    Dim TipoDato As ValorTipoDato
    Private TipoG As State

    Private _OrdenTrabajo As Long = 0
    Private _OrdenTrabajoOrigen As Long = 0
    Private _Longitud As Short = 0
    Private _Decimal As Short = 0
    Private _Presupuesto As Long = 0
    Private _JefeArea As String = String.Empty
    Private _Cliente As String = String.Empty
    Private _Equipo As Long = 0
    Private _AreaInt As String = String.Empty
    Private _Atributo As Long = 0
    Private _Requerimiento As Long = 0
    Private _Programacion As Long = 0
    Private _FechaInicioOT As Date = Date.Today
    Private _FechaTerminoOT As Date = Date.Today
    Private _Status As String = "P"

    Private _FechaInicioJA As String = String.Empty
    Private _FechaTerminoJA As String = String.Empty
    Private _FechaInicioEA As String = String.Empty
    Private _FechaTerminoEA As String = String.Empty

    Private Ls_Material As List(Of ETOrdenTrabajo_Recursos) = Nothing
    Private Ls_Equipo As List(Of ETOrdenTrabajo_Recursos) = Nothing
    Private Ls_ManoObra As List(Of ETOrdenTrabajo_Recursos) = Nothing
    Private Ls_Servicio As List(Of ETOrdenTrabajo_Recursos) = Nothing
    Private Ls_BackLog As List(Of ETOrdenTrabajo_Recursos) = Nothing

#End Region

#Region "Propiedades"
    Public Property OrdenTrabajo() As Long
        Get
            Return _OrdenTrabajo
        End Get
        Set(ByVal value As Long)
            _OrdenTrabajo = value
        End Set
    End Property
    Public Property OrdenTrabajoOrigen() As Long
        Get
            Return _OrdenTrabajoOrigen
        End Get
        Set(ByVal value As Long)
            _OrdenTrabajoOrigen = value
        End Set
    End Property
    Private Property Presupuesto() As Long
        Get
            Return _Presupuesto
        End Get
        Set(ByVal value As Long)
            _Presupuesto = value
        End Set
    End Property
    Private Property EncargadoArea() As String
        Get
            Return _JefeArea
        End Get
        Set(ByVal value As String)
            _JefeArea = value
        End Set
    End Property
    Private Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property
    Private Property Equipo() As Long
        Get
            Return _Equipo
        End Get
        Set(ByVal value As Long)
            _Equipo = value
        End Set
    End Property
    Private Property Longitud() As Short
        Get
            Return _Longitud
        End Get
        Set(ByVal value As Short)
            _Longitud = value
        End Set
    End Property
    Private Property Decimales() As Short
        Get
            Return _Decimal
        End Get
        Set(ByVal value As Short)
            _Decimal = value
        End Set
    End Property
    Private Property AreaInt() As String
        Get
            Return _AreaInt
        End Get
        Set(ByVal value As String)
            _AreaInt = value
        End Set
    End Property
    Private Property Atributo() As Long
        Get
            Return _Atributo
        End Get
        Set(ByVal value As Long)
            _Atributo = value
        End Set
    End Property
    Public Property Requerimiento() As Long
        Get
            Return _Requerimiento
        End Get
        Set(ByVal value As Long)
            _Requerimiento = value
        End Set
    End Property
    Public Property Programacion() As Long
        Get
            Return _Programacion
        End Get
        Set(ByVal value As Long)
            _Programacion = value
        End Set
    End Property
    Public Property FechaInicioOT() As Date
        Get
            Return _FechaInicioOT
        End Get
        Set(ByVal value As Date)
            _FechaInicioOT = value
        End Set
    End Property
    Public Property FechaTerminoOT() As Date
        Get
            Return _FechaTerminoOT
        End Get
        Set(ByVal value As Date)
            _FechaTerminoOT = value
        End Set
    End Property
    Private Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
    Private Property FechaInicioJA() As String
        Get
            Return _FechaInicioJA
        End Get
        Set(ByVal value As String)
            _FechaInicioJA = value
        End Set
    End Property
    Private Property FechaTerminoJA() As String
        Get
            Return _FechaTerminoJA
        End Get
        Set(ByVal value As String)
            _FechaTerminoJA = value
        End Set
    End Property
    Private Property FechaInicioEA() As String
        Get
            Return _FechaInicioEA
        End Get
        Set(ByVal value As String)
            _FechaInicioEA = value
        End Set
    End Property
    Private Property FechaTerminoEA() As String
        Get
            Return _FechaTerminoEA
        End Get
        Set(ByVal value As String)
            _FechaTerminoEA = value
        End Set
    End Property

#End Region

#Region "Formulario"

    Private Sub frmPOrdenTrabajo_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub frmPOrdenTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CargarDatosFormulario()
        Call CargarUnidadMedida()
        Call Inicio()
    End Sub
#End Region

#Region "Procedimientos Privados"

    Private Sub ObtenerJefeArea()

        If Not (TipoG = State.eNew) Then
            Return
        End If

        If String.IsNullOrEmpty(Cbo1.Value) Then
            Return
        End If

        Dim Lista As New List(Of ETAreaJefatura)
        Entidad.AreaJefatura = New ETAreaJefatura
        With Entidad.AreaJefatura
            .Cod_Area = Cbo1.Value
            .FechaInicio = Dtp1.Value
            .Tipo = 5
        End With
        Negocio.AreaJefatura = New NGAreaJefatura
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.AreaJefatura.Consultar_AreaJefetura_Activa(Entidad.AreaJefatura)
        If Entidad.MyLista.Validacion Then
            Lista = Entidad.MyLista.Ls_AreaJefatura
        End If

        Txt20.Clear()
        _JefeArea = String.Empty
        _FechaInicioEA = String.Empty
        _FechaTerminoEA = String.Empty
        If Lista IsNot Nothing Then
            For Each Row As ETAreaJefatura In Lista
                Txt20.Text = Row.Cod_JefeArea & "  " & Row.JefeArea
                _JefeArea = Row.Cod_JefeArea
                _FechaInicioEA = Row.FechaInicioTxt
                _FechaTerminoEA = Row.FechaTerminoTxt
            Next
        End If
    End Sub

    Private Sub InicializarValores()
        _OrdenTrabajo = 0
        _OrdenTrabajoOrigen = 0
        _Longitud = 0
        _Decimal = 0
        _Status = String.Empty
        _Presupuesto = 0
        _JefeArea = String.Empty
        _Cliente = String.Empty
        _Equipo = 0
        _AreaInt = String.Empty
        _Atributo = 0
        _Requerimiento = 0
        _Programacion = 0
        _FechaInicioOT = Date.Today
        _FechaTerminoOT = Date.Today
        _FechaInicioJA = String.Empty
        _FechaTerminoJA = String.Empty
        _FechaInicioEA = String.Empty
        _FechaTerminoEA = String.Empty
    End Sub

    Private Sub CargarUnidadMedida()
        Dim Ls_Combo As List(Of ETUnidadMedida)
        Negocio.UnidadMedida = New NGUnidadMedida
        Entidad.MyLista = New ETMyLista

        Ls_Combo = New List(Of ETUnidadMedida)

        Entidad.MyLista = Negocio.UnidadMedida.ConsultarUnidadMedida

        If Entidad.MyLista.Validacion Then
            Ls_Combo = Entidad.MyLista.Ls_UnidadMedida
        End If

        Call CargarUltraCombo(Me.Cbo3, Ls_Combo, "Codigo", "Descripcion", String.Empty)

    End Sub

    Private Sub Cargar_Area()
        Dim Ls_Area As New List(Of ETArea)

        Dim objArea As New ETArea
        Dim ObjNeg As New NGArea
        If TipoG = State.eNew Then
            objArea.Tipo = TipoG
        Else
            objArea.Tipo = TipoG
        End If

        objArea.Usuario = User_Sistema
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = ObjNeg.Consultar_Area(objArea)
        If Entidad.MyLista.Validacion Then
            Ls_Area = Entidad.MyLista.Ls_Area
        End If

        Call CargarUltraCombo(Me.Cbo1, Ls_Area, "Codigo", "Area")
    End Sub

    Private Sub Cargar_Presupuesto()
        Dim Ls_Presup As New List(Of ETPresupuesto)

        Entidad.Presupuesto = New ETPresupuesto
        With Entidad.Presupuesto
            .Presupuesto = Me.Presupuesto
            .Area = Me.Cbo1.Value
            .Tipo = 6
        End With

        Negocio.Presupuesto = New NGPresupuesto

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.Presupuesto.Consultar_Presupuesto_OT(Entidad.Presupuesto)

        If Entidad.MyLista.Validacion Then
            Ls_Presup = Entidad.MyLista.Ls_Presupuesto
        End If

        Call CargarUltraCombo(Me.Cbo8, Ls_Presup, "Presupuesto", "Cod_Presup")
    End Sub

    Private Sub Cargar_Requerimiento(ByVal Req_ID As Long)
        Dim Ls_Req As New List(Of ETRequerimiento_ManttoDetalle)

        Entidad.Requerimiento_Det_Mantto = New ETRequerimiento_ManttoDetalle
        With Entidad.Requerimiento_Det_Mantto
            .Requerimiento = Req_ID
            .EquipoID = Me.Equipo
            .Tipo = 7
        End With

        Negocio.Requerimiento_Mantto = New NGRequerimiento_Mantto

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.Requerimiento_Mantto.Consultar_Requerimiento_OT(Entidad.Requerimiento_Det_Mantto)

        If Entidad.MyLista.Validacion Then
            Ls_Req = Entidad.MyLista.Ls_Requerimiento_Det_Mantto
        End If
        Call CargarUltraCombo(Me.Cbo6, Ls_Req, "Requerimiento", "Codigo")
    End Sub

    Private Sub CargarDatosFormulario()
        Formulario = Mid(Me.Tag, 2, 2)
        Select Case Formulario
            Case NameFormulario.eOrdenTrabajo
                Me.UltraLabel3.Visible = False
                Me.Txt2.Visible = False
                Me.Btn1.Visible = False
                Me.Label24.Visible = False
                Me.Chk1.Enabled = True
            Case NameFormulario.eBackLog
                Me.UltraLabel18.Visible = False
                Me.Txt15.Visible = False
                Me.Tab1.Tabs("T01").Text = "BACK LOG"
                Me.Tab2.Tabs("T05").Visible = False
                Me.Label24.Visible = True
                Me.Chk1.Checked = True
                Me.Chk1.Enabled = False
        End Select
    End Sub

    Private Sub HabilitarControles(ByVal b As Boolean)
        Cbo1.ReadOnly = Not b
        Txt1.ReadOnly = True
        Cbo8.ReadOnly = Not b
        Txt10.ReadOnly = True

        If Formulario = NameFormulario.eOrdenTrabajo Then
            Chk1.Enabled = b
        Else
            Chk1.Enabled = False
        End If

        Txt3.ReadOnly = True
        Btn1.Enabled = b
        Btn2.Enabled = b
        Txt4.ReadOnly = True
        Txt5.ReadOnly = True
        Txt6.ReadOnly = Not b
        Btn3.Enabled = b
        Cbo2.ReadOnly = Not b
        Txt7.ReadOnly = Not b
        Txt8.ReadOnly = Not b
        Cbo3.ReadOnly = True
        Cbo4.ReadOnly = Not b
        Cbo5.ReadOnly = True
        Txt19.ReadOnly = True
        Txt11.ReadOnly = True
        Txt12.ReadOnly = True
        Txt13.ReadOnly = True
        Txt14.ReadOnly = True
        Txt15.ReadOnly = True
        Txt16.ReadOnly = True
        Cbo6.ReadOnly = Not b
        Txt17.ReadOnly = True
        Txt18.ReadOnly = True
        Dtp1.ReadOnly = Not b
        Dtp2.ReadOnly = Not b

        Rbn1.Enabled = b
        Rbn2.Enabled = b
        Rbn3.Enabled = b
    End Sub
    Private Sub LimpiarDatosPresupuesto()
        Txt10.Value = 0
        EncargadoArea = ""
        Txt20.Clear()
        If Formulario = NameFormulario.eOrdenTrabajo Then
            Chk1.Checked = False
        Else
            Chk1.Checked = True
        End If

        Txt3.Clear()
        Txt4.Clear()
        Cliente = ""
        Txt5.Clear()
        Cbo2.Value = ""
        Label9.Text = "* Valor:"
        TipoDato = ValorTipoDato.vVacio
        Equipo = 0
        Cbo3.Value = ""
        Atributo = 0
        Txt7.Visible = False
        Txt8.Visible = True
        Txt8.Clear()
        Longitud = 0
        Decimales = 0

        Cbo4.Value = ""
        Cbo5.Value = "S/."
        Dtp1.Value = Date.Now
        Dtp2.Value = Date.Now
    End Sub

    Private Sub Limpiar()
        Ep1.Clear()
        If Cbo1.Rows.Count > 0 Then
            Cbo1.Value = ""
        End If
        Txt1.Clear()
        Txt2.Clear()
        Txt20.Clear()
        Label24.Text = ""
        If Cbo8.Rows.Count > 0 Then
            Cbo8.Value = ""
        End If
        Txt10.Value = 0

        If Formulario = NameFormulario.eOrdenTrabajo Then
            Chk1.Checked = False
        Else
            Chk1.Checked = True
        End If

        Txt3.Clear()
        Txt4.Clear()
        Txt5.Clear()
        Txt6.Clear()
        Cbo2.Value = ""
        Label9.Text = "* Valor :"
        Txt8.Clear()
        If Cbo3.Rows.Count > 0 Then
            Cbo3.Value = ""
        End If
        Cbo4.Value = ""
        Cbo5.Value = "S/."
        Txt19.Value = 0
        Txt11.Value = 0
        Txt12.Value = 0
        Txt13.Value = 0
        Txt14.Value = 0
        Txt15.Value = 0
        Txt16.Value = 0
        If Cbo6.Rows.Count > 0 Then
            Cbo6.Value = ""
        End If
        Txt17.Clear()
        Txt18.Clear()
        Rbn1.Checked = True
        Dtp1.Value = Date.Today
        Dtp2.Value = Date.Today

        Call InicializarValores()

        Ls_Material = New List(Of ETOrdenTrabajo_Recursos)
        Ls_Equipo = New List(Of ETOrdenTrabajo_Recursos)
        Ls_ManoObra = New List(Of ETOrdenTrabajo_Recursos)
        Ls_Servicio = New List(Of ETOrdenTrabajo_Recursos)
        Ls_BackLog = New List(Of ETOrdenTrabajo_Recursos)

        Dim Ls_Presup As New List(Of ETPresupuesto)
        Call CargarUltraCombo(Me.Cbo8, Ls_Presup, "Presupuesto", "Cod_Presup")

        Dim Ls_Req As New List(Of ETRequerimiento_ManttoDetalle)
        Call CargarUltraCombo(Me.Cbo6, Ls_Req, "Requerimiento", "Codigo")

        Call CargarUltraGrid(Grid2, Ls_Material)
        Call CargarUltraGrid(Grid3, Ls_Equipo)
        Call CargarUltraGrid(Grid4, Ls_ManoObra)
        Call CargarUltraGrid(Grid5, Ls_Servicio)
        Call CargarUltraGrid(Grid6, Ls_BackLog)


    End Sub

    Private Sub InHabilitarControles_Presupuesto(ByVal b As Boolean)
        If Formulario = NameFormulario.eOrdenTrabajo Then
            Chk1.Enabled = Not b
        Else
            Chk1.Enabled = False

        End If
        Btn2.Enabled = Not b
        Btn3.Enabled = Not b
        Cbo2.ReadOnly = b
        Cbo4.ReadOnly = b
        Cbo5.ReadOnly = True
        Dtp1.ReadOnly = b
        Dtp2.ReadOnly = b
    End Sub

    Private Sub InHabilitarControles_Estado(ByVal Estado As String)
        If Estado <> "P" Then
            Call HabilitarControles(False)
            GroupBox2.Enabled = False
        Else
            GroupBox2.Enabled = True
            Txt6.ReadOnly = False
            Rbn1.Enabled = True
            Rbn2.Enabled = True
            Rbn3.Enabled = False
            Dtp2.ReadOnly = False
        End If
    End Sub

    Private Sub Limpiar_Datos_Equipo()
        Label9.Text = "* Valor:"
        TipoDato = 0
        Txt7.Value = 0
        Txt7.Value = False
        Txt8.Clear()
        Txt8.Visible = True
        Longitud = 0
        Decimales = 0
        Txt8.ReadOnly = True
    End Sub

    Private Sub Inicio()
        Call Limpiar()
        Call InHabilitarControles_Presupuesto(True)
        Call HabilitarControles(False)
        TipoG = State.eSelect
        Call Cargar_Grilla()
        Tab1.Tabs("T01").Selected = True
    End Sub

    Private Sub Cargar_Grilla()
        Dim Ls_OrdenTrabajo As New List(Of ETOrdenTrabajo_Mantto)
        Entidad.MyLista = New ETMyLista
        Negocio.Orden_Trabajo = New NGOrdenTrabajo_Mantto

        If Formulario = NameFormulario.eOrdenTrabajo Then
            Entidad.MyLista = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo
        Else
            Entidad.MyLista = Negocio.Orden_Trabajo.Consultar_BackLog
        End If

        If Entidad.MyLista.Validacion Then
            Ls_OrdenTrabajo = Entidad.MyLista.Ls_Orden_Trabajo_Mantto
        End If

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_OrdenTrabajo)

    End Sub

    Private Sub Cargar_Recursos()

        Ls_Material = New List(Of ETOrdenTrabajo_Recursos)
        Ls_Equipo = New List(Of ETOrdenTrabajo_Recursos)
        Ls_ManoObra = New List(Of ETOrdenTrabajo_Recursos)
        Ls_Servicio = New List(Of ETOrdenTrabajo_Recursos)
        Ls_BackLog = New List(Of ETOrdenTrabajo_Recursos)

        Entidad.OrdenTrabajo_Recursos = New ETOrdenTrabajo_Recursos
        Entidad.OrdenTrabajo_Recursos.OrdenTrabajo = Me.OrdenTrabajo
        Entidad.OrdenTrabajo_Recursos.TipoRecurso = "MAT"
        Negocio.Orden_Trabajo = New NGOrdenTrabajo_Mantto
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_Recursos(Entidad.OrdenTrabajo_Recursos)
        If Entidad.MyLista.Validacion Then
            Ls_Material = Entidad.MyLista.Ls_OrdenTrabajo_Recursos
        End If

        Entidad.OrdenTrabajo_Recursos.TipoRecurso = "EQ"
        Negocio.Orden_Trabajo = New NGOrdenTrabajo_Mantto
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_Recursos(Entidad.OrdenTrabajo_Recursos)
        If Entidad.MyLista.Validacion Then
            Ls_Equipo = Entidad.MyLista.Ls_OrdenTrabajo_Recursos
        End If

        Entidad.OrdenTrabajo_Recursos.TipoRecurso = "MO"
        Negocio.Orden_Trabajo = New NGOrdenTrabajo_Mantto
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_Recursos(Entidad.OrdenTrabajo_Recursos)
        If Entidad.MyLista.Validacion Then
            Ls_ManoObra = Entidad.MyLista.Ls_OrdenTrabajo_Recursos
        End If

        Entidad.OrdenTrabajo_Recursos.TipoRecurso = "SER"
        Negocio.Orden_Trabajo = New NGOrdenTrabajo_Mantto
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_Recursos(Entidad.OrdenTrabajo_Recursos)
        If Entidad.MyLista.Validacion Then
            Ls_Servicio = Entidad.MyLista.Ls_OrdenTrabajo_Recursos
        End If

        Entidad.OrdenTrabajo_Recursos.TipoRecurso = "BL"
        Negocio.Orden_Trabajo = New NGOrdenTrabajo_Mantto
        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_Recursos(Entidad.OrdenTrabajo_Recursos)
        If Entidad.MyLista.Validacion Then
            Ls_BackLog = Entidad.MyLista.Ls_OrdenTrabajo_Recursos
        End If


        Call CargarUltraGrid(Grid2, Ls_Material)
        Call CargarUltraGrid(Grid3, Ls_Equipo)
        Call CargarUltraGrid(Grid4, Ls_ManoObra)
        Call CargarUltraGrid(Grid5, Ls_Servicio)
        Call CargarUltraGrid(Grid6, Ls_BackLog)

    End Sub

    Private Sub Inhabilitar_Controles_OTOrigen(ByVal b As Boolean)
        Txt2.ReadOnly = b
        Txt3.ReadOnly = b
        Txt4.ReadOnly = b
        Txt5.ReadOnly = b
        Cbo2.ReadOnly = b
        Cbo3.ReadOnly = b
        Cbo5.ReadOnly = b
        Btn1.Enabled = Not b
        Btn2.Enabled = Not b
        Btn3.Enabled = Not b


    End Sub
#End Region
#Region "Procedimientos Publicos"
    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Inicio()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Public Sub Nuevo()
        Call Limpiar()
        Call InHabilitarControles_Presupuesto(False)
        Call HabilitarControles(True)
        TipoG = State.eNew
        Status = "P"
        Call Cargar_Area()
        GroupBox2.Enabled = False
        Tab1.Tabs("T02").Selected = True

    End Sub

    Public Sub Grabar()
        Dim lResult As ETOrdenTrabajo_Mantto = Nothing

        If Status <> "P" Then
            Return
        End If
        If ValidarDatos() = False Then
            Exit Sub
        End If

        Entidad.OrdenTrabajo = New ETOrdenTrabajo_Mantto

        Txt7.EndUpdate()
        Txt10.EndUpdate()
        Txt11.EndUpdate()
        Txt12.EndUpdate()
        Txt13.EndUpdate()
        Txt14.EndUpdate()
        Txt15.EndUpdate()
        Txt16.EndUpdate()
        Txt19.EndUpdate()

        With Entidad.OrdenTrabajo
            .OrdenTrabajo = Me.OrdenTrabajo
            .Area = Cbo1.Value
            .Abrev = Cbo1.ActiveRow.Cells("Abrev").Value
            .Codigo = Txt1.Text
            .OrdenTrabajoOrigen = Me.OrdenTrabajoOrigen
            .Presupuesto = Me.Presupuesto
            .CostoPresup = Me.Txt10.Value
            .Cod_EncargadoArea = Me.EncargadoArea
            .TipoCliente = Chk1.Checked
            If Chk1.Checked = False Then
                .Cod_Cli = Cliente
            Else
                .Cod_CliInterno = Cliente
            End If

            .Cod_AreaInt = Me.AreaInt
            .EquipoID = Me.Equipo
            .Descripcion = Txt6.Text
            .TipoProceso = Cbo2.Value
            If TipoDato = ValorTipoDato.vTime OrElse TipoDato = ValorTipoDato.vDate Then
                .ValorControl = Txt7.Value
            Else
                .ValorControl = Txt8.Text
            End If
            .AtributoControl = Me.Atributo
            .Cod_Prioridad = Cbo4.Value
            .Moneda = Cbo5.Value
            .CostoMaterial = Txt11.Value
            .CostoEquipos = Txt12.Value
            .CostoManoObra = Txt13.Value
            .CostoServicios = Txt14.Value
            .CostoBackLog = Txt15.Value
            .CostoTotal = Txt16.Value
            .Cod_Requerimiento = Me.Requerimiento
            .Cod_Programacion = Me.Programacion
            .FechaInicio = Dtp1.Value
            .FechaTerminacion = Dtp2.Value

            If Rbn1.Checked = True Then
                .Status = "P"
            ElseIf Rbn2.Checked = True Then
                .Status = ""
            Else
                .Status = "*"
            End If
            .Usuario = User_Sistema
            .Tipo = TipoG
        End With

        lResult = New ETOrdenTrabajo_Mantto
        Negocio.Orden_Trabajo = New NGOrdenTrabajo_Mantto
        If Rbn2.Checked = True Then
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        End If
        If Rbn2.Checked = True Then
            lResult = Negocio.Orden_Trabajo.Mantenedor_Orden_Trabajo_Mantto(Entidad.OrdenTrabajo)
        End If

        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
        If lResult IsNot Nothing Then
            If lResult.Validacion = True Then
                Call Inicio()
            Else
                Select Case lResult.Tipo
                    Case 1
                        Dtp1.Value = lResult.FechaInicio.ToShortDateString
                    Case 2
                        Dtp2.Value = lResult.FechaTerminacion.ToShortDateString
                    Case 3
                        Dtp1.Value = lResult.FechaInicio.ToShortDateString
                        Dtp2.Value = lResult.FechaTerminacion.ToShortDateString
                End Select
            End If

        End If
    End Sub

    Public Sub Modificar()
        If Grid1.Rows.Count <= 0 Then Return

        If Grid1.ActiveRow Is Nothing Then Return

        TipoG = State.eSelect
        Call Limpiar()
        TipoG = State.eEdit
        Call Cargar_Area()
        TipoG = State.eSelect

        Cbo1.Value = Grid1.ActiveRow.Cells("Area").Value
        Txt1.Text = Grid1.ActiveRow.Cells("Codigo").Value
        Me.OrdenTrabajo = Grid1.ActiveRow.Cells("OrdenTrabajo").Value
        Txt2.Text = Grid1.ActiveRow.Cells("OTOrigen").Value
        Me.OrdenTrabajoOrigen = Grid1.ActiveRow.Cells("OrdenTrabajoOrigen").Value

        Me.Presupuesto = Grid1.ActiveRow.Cells("Presupuesto").Value
        Call Cargar_Presupuesto()

        EncargadoArea = Grid1.ActiveRow.Cells("Cod_EncargadoArea").Value
        Txt20.Text = EncargadoArea & "  " & Grid1.ActiveRow.Cells("EncargadoArea").Value
        Me.Requerimiento = Grid1.ActiveRow.Cells("Cod_Requerimiento").Value

        Chk1.Checked = Grid1.ActiveRow.Cells("TipoCliente").Value
        Txt3.Text = Grid1.ActiveRow.Cells("Cliente").Value
        If Chk1.Checked = True Then
            Txt4.Text = Grid1.ActiveRow.Cells("AreaInterna").Value
            Cliente = Grid1.ActiveRow.Cells("Cod_CliInterno").Value
            AreaInt = Grid1.ActiveRow.Cells("Cod_AreaInt").Value
        Else
            Txt4.Text = Grid1.ActiveRow.Cells("RUC").Value
            Cliente = Grid1.ActiveRow.Cells("Cod_Cli").Value
        End If
        Txt5.Text = Grid1.ActiveRow.Cells("Equipo").Value
        Equipo = Grid1.ActiveRow.Cells("EquipoID").Value
        TipoDato = Val(Grid1.ActiveRow.Cells("TipoDato").Value)
        Atributo = Grid1.ActiveRow.Cells("AtributoControl").Value
        Longitud = Grid1.ActiveRow.Cells("Longitud").Value
        Decimales = Grid1.ActiveRow.Cells("Decimales").Value

        If Atributo > 0 Then
            Cbo3.Value = Grid1.ActiveRow.Cells("Cod_UniMed").Value
            Label9.Text = "* " & Grid1.ActiveRow.Cells("Atributo").Value & ":"
            Select Case TipoDato
                Case ValorTipoDato.vDate
                    Txt7.FormatString = "{LOC}dd/mm/yyyy"
                    Txt8.Visible = False
                    Txt7.Visible = True
                    Txt7.Value = Grid1.ActiveRow.Cells("ValorControl").Value
                Case ValorTipoDato.vTime
                    Txt7.FormatString = "{LOC}hh:mm"
                    Txt8.Visible = False
                    Txt7.Visible = True
                    Txt7.Value = Grid1.ActiveRow.Cells("ValorControl").Value
                Case Else
                    Txt7.Visible = False
                    Txt8.Visible = True
                    Txt8.Text = Grid1.ActiveRow.Cells("ValorControl").Value
            End Select
        End If
        Cbo2.Value = Grid1.ActiveRow.Cells("TipoProceso").Value.ToString.Trim
        Cbo4.Value = Grid1.ActiveRow.Cells("Cod_Prioridad").Value.ToString.Trim
        Cbo5.Value = Grid1.ActiveRow.Cells("Moneda").Value.ToString.Trim
        Call Cargar_Requerimiento(Requerimiento)
        Cbo6.Value = Requerimiento
        Dtp1.Value = Grid1.ActiveRow.Cells("FechaInicio").Value
        Dtp2.Value = Grid1.ActiveRow.Cells("FechaTerminacion").Value

        If Presupuesto > 0 Then
            Call InHabilitarControles_Presupuesto(True)
        End If

        Txt6.Value = Grid1.ActiveRow.Cells("Descripcion").Value
        Txt11.Value = Grid1.ActiveRow.Cells("CostoMaterial").Value
        Txt12.Value = Grid1.ActiveRow.Cells("CostoEquipos").Value
        Txt13.Value = Grid1.ActiveRow.Cells("CostoManoObra").Value
        Txt14.Value = Grid1.ActiveRow.Cells("CostoServicios").Value
        Txt15.Value = Grid1.ActiveRow.Cells("CostoBackLog").Value
        Txt16.Value = Grid1.ActiveRow.Cells("CostoTotal").Value
        Status = Grid1.ActiveRow.Cells("Status").Value
        Select Case Status
            Case "P"
                Rbn1.Checked = True
            Case "*"
                Rbn3.Checked = True
            Case Else
                Rbn2.Checked = True
        End Select
        Call InHabilitarControles_Estado(Status)
        If OrdenTrabajoOrigen > 0 Then
            FechaInicioOT = Grid1.ActiveRow.Cells("FechaInicioOTO").Value
            FechaTerminoOT = Grid1.ActiveRow.Cells("FechaTerminoOTO").Value
            Label24.Text = "Desde: " & FechaInicioOT.ToShortDateString & " Al: " & FechaTerminoOT.ToShortDateString
            Call Inhabilitar_Controles_OTOrigen(True)
        End If
        Call Cargar_Recursos()
        TipoG = State.eEdit
        Tab1.Tabs("T02").Selected = True
    End Sub

    Public Sub Cancelar()
        Call Inicio()
    End Sub

    Public Sub Eliminar()
        Dim mensaje As String = String.Empty
        Dim Status As String = String.Empty
        If Tab1.Tabs("T01").Selected = False Then
            Return
        End If
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No existen Ordenes de Trabajo", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        If Grid1.ActiveRow Is Nothing Then
            Return
        End If

        If Grid1.ActiveRow.Cells("Status").Value = "*" Then
            MsgBox("La O/T ya está anulada", MsgBoxStyle.Critical, msgComacsa)
            Return
        End If
        mensaje = "Esta seguro de Anular la Orden de Trabajo: "
        mensaje = mensaje & Grid1.ActiveRow.Cells("Codigo").Value

        If MsgBox(mensaje, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Return
        End If

        Status = Grid1.ActiveRow.Cells("Status").Value
        If Not (Status = "P") Then
            MsgBox("El Trabajo ya esta Concluido", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        If Val(Grid1.ActiveRow.Cells("CostoTotal").Value) <> 0 Then
            MsgBox("No se puede Anular la O/T porque tiene costos asignados", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        Entidad.OrdenTrabajo = New ETOrdenTrabajo_Mantto
        With Entidad.OrdenTrabajo
            .OrdenTrabajo = Grid1.ActiveRow.Cells("OrdenTrabajo").Value
            .Cod_Requerimiento = Grid1.ActiveRow.Cells("Cod_Requerimiento").Value
            .Cod_Programacion = Grid1.ActiveRow.Cells("Cod_Programacion").Value
            .Presupuesto = Grid1.ActiveRow.Cells("Presupuesto").Value
            .Usuario = User_Sistema
            .Tipo = 3
        End With

        Negocio.Orden_Trabajo.Anular_Orden_Trabajo_Mantto(Entidad.OrdenTrabajo)

        Call Inicio()
    End Sub

    Public Sub Excel()
        If Grid1.Rows.Count <= 0 Then
            Return
        End If
        If Grid1.ActiveRow.Cells Is Nothing Then
            Return
        End If


    End Sub

#End Region


#Region "Funciones Privadas"
    Private Function CargarTipoCambio() As Double
        Dim lResult As Double = 0
        Entidad.Presupuesto = New ETPresupuesto
        With Entidad.Presupuesto
            .Moneda = Cbo5.Value
            .Fecha = Dtp1.Value
            .Tipo = 5
        End With
        Negocio.Presupuesto = New NGPresupuesto
        lResult = Negocio.Presupuesto.Consultar_TipoCambio(Entidad.Presupuesto)
        Return lResult
    End Function

    Private Function ValidarDatos() As Boolean
        Ep1.Clear()
        ValidarDatos = True

        If String.IsNullOrEmpty(Cbo1.Value) Then
            Ep1.SetError(Cbo1, "Seleecione el Área")
            ValidarDatos = False
        End If

        If String.IsNullOrEmpty(Txt20.Text.Trim) Then
            Ep1.SetError(Txt20, "El área no tiene Encargado")
            ValidarDatos = False
        End If

        If Txt2.Visible = True Then
            If String.IsNullOrEmpty(Txt2.Text.Trim) Then
                Ep1.SetError(Txt2, "Seleccione la Orden de Trabajo Origen")
                ValidarDatos = False
            End If

            If OrdenTrabajoOrigen <= 0 Then
                Ep1.SetError(Txt2, "Seleccione la Orden de Trabajo Origen")
                ValidarDatos = False
            End If
        End If

        If String.IsNullOrEmpty(Txt3.Text.Trim) Then
            Ep1.SetError(Txt3, "seleccione al Cliente")
            ValidarDatos = False
        End If

        If String.IsNullOrEmpty(Cliente.Trim) Then
            Ep1.SetError(Txt3, "seleccione al Cliente")
            ValidarDatos = False
        End If

        If String.IsNullOrEmpty(Txt5.Text.Trim) Then
            Ep1.SetError(Txt5, "seleccione al Equipo")
            ValidarDatos = False
        End If

        If Val(Equipo) <= 0 Then
            Ep1.SetError(Txt5, "seleccione al Equipo")
            ValidarDatos = False
        End If

        If String.IsNullOrEmpty(Txt6.Text.Trim) Then
            Ep1.SetError(Txt6, "Ingrese la Descripción de la OT")
            ValidarDatos = False
        End If

        If String.IsNullOrEmpty(Cbo2.Value) Then
            Ep1.SetError(Txt6, "Seleecione el Tipo de Mantenimiento")
            ValidarDatos = False
        End If

        If Atributo > 0 Then
            If TipoDato = ValorTipoDato.vEntero Or TipoDato = ValorTipoDato.vDecimal Then
                If String.IsNullOrEmpty(Txt8.Text.Trim) Then
                    Ep1.SetError(Txt8, "Ingrese el " & Label9.Text)
                    ValidarDatos = False
                ElseIf Val(Txt8.Text) < 0 Then
                    Ep1.SetError(Txt8, "Ingrese un Valor mayor o igual a cero")
                    ValidarDatos = False
                End If

            ElseIf TipoDato = ValorTipoDato.vDate Then
                If Not (IsDate(Txt7.Value)) Then
                    Ep1.SetError(Txt7, "Ingrese la Fecha")
                    ValidarDatos = False
                End If
            ElseIf TipoDato = ValorTipoDato.vTime Then
                If Not (IsDate(Txt7.Value)) Then
                    Ep1.SetError(Txt7, "Ingrese la Hora")
                    ValidarDatos = False
                End If
            End If
        End If

        If String.IsNullOrEmpty(Cbo4.Value) Then
            Ep1.SetError(Cbo4, "Seleccione la Prioridad")
            ValidarDatos = False
        End If

        If String.IsNullOrEmpty(Cbo5.Value) Then
            Ep1.SetError(Cbo5, "Seleecione el Tipo de Mantenimiento")
            ValidarDatos = False
        End If

        If String.IsNullOrEmpty(Cbo6.Value) Then
            Ep1.SetError(Cbo5, "Seleecione el Requerimiento")
            ValidarDatos = False
        End If

        If CDate(Dtp1.Value) > CDate(Dtp2.Value) Then
            Ep1.SetError(Dtp1, "La Fecha de Inicio es mayor a la Fecha de Termino")
            ValidarDatos = False
        End If

        If Chk1.Checked = True Then
            If Not (String.IsNullOrEmpty(FechaInicioJA)) Then
                If String.IsNullOrEmpty(FechaTerminoJA) Then
                    If CDate(FechaInicioJA) > CDate(Dtp2.Value) Then
                        Ep1.SetError(Dtp1, "el Cliente Interno ingreso el " & FechaInicioJA)
                        ValidarDatos = False
                    End If
                Else
                    If CDate(FechaInicioJA) > CDate(Dtp2.Value) Then
                        Ep1.SetError(Dtp1, "el Cliente Interno ingreso el " & FechaInicioJA)
                        ValidarDatos = False
                    ElseIf CDate(FechaTerminoJA) < CDate(Dtp1.Value) Then
                        Ep1.SetError(Dtp1, "el Cliente Interno dejó la Jefatura el " & FechaTerminoJA)
                        ValidarDatos = False
                    End If
                End If
            End If
        End If

        If Txt2.Visible = True Then
            If Not (CDate(Me.FechaInicioOT) <= CDate(Dtp1.Value) And CDate(Dtp2.Value) <= CDate(Me.FechaTerminoOT)) Then
                Ep1.SetError(Dtp1, "El BackLog no esta entre el rango de fecha de la O/T Origen")
                ValidarDatos = False
            End If
        End If
    End Function
#End Region
#Region "Datetime"
    Private Sub Dtp1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp1.ValueChanged
        If TipoG = State.eNew OrElse TipoG = State.eEdit Then
            Txt19.Text = CargarTipoCambio()
            If Val(Txt19.Text) <= 0 Then
                MsgBox("No hay Tipo de Cambio para la Fecha", MsgBoxStyle.Exclamation, msgComacsa)
            End If

            Call ObtenerJefeArea()
        End If
    End Sub
#End Region
#Region "Botones"
    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        Dim frm As New frmBuscar
        frm.Formulario = frmBuscar.eState.frm_Orden_Trabajo_BackLog
        frm.ID_Input = Equipo
        frm.ShowDialog()
        Me.OrdenTrabajoOrigen = frm.ID
        Txt2.Text = frm.Flag2

        FechaInicioOT = frm.Flag8
        FechaTerminoOT = frm.Flag9

        Cliente = frm.Flag5
        Txt3.Text = frm.Flag4
        Txt4.Text = frm.Flag18
        AreaInt = frm.Flag19
        Equipo = frm.Flag1
        Txt5.Text = frm.Flag3
        Cbo2.Value = frm.Flag14.Trim
        Cbo3.Value = frm.Flag6
        TipoDato = Val(frm.Flag7)
        Longitud = frm.Flag10
        Decimales = frm.Flag11
        Atributo = frm.Flag12
        Requerimiento = frm.Flag13
        Call Cargar_Requerimiento(Requerimiento)
        Label9.Text = "* " & frm.Flag15 & ":"

        Select Case TipoDato
            Case ValorTipoDato.vDate
                Txt7.FormatString = "{LOC}dd/mm/yyyy"
                Txt8.Visible = False
                Txt7.Visible = True
                Txt7.Value = frm.Flag16
            Case ValorTipoDato.vTime
                Txt7.FormatString = "{LOC}hh:mm"
                Txt8.Visible = False
                Txt7.Visible = True
                Txt7.Value = frm.Flag16
            Case Else
                Txt7.Visible = False
                Txt8.Visible = True
                Txt8.Text = frm.Flag16
        End Select

        Cbo5.Value = frm.Flag17

        If Me.OrdenTrabajoOrigen > 0 Then
            Label24.Text = "Desde: " & FechaInicioOT.ToShortDateString & " Al: " & FechaTerminoOT.ToShortDateString
            Me.Cbo1.ReadOnly = True
        Else
            Me.Cbo1.ReadOnly = False
        End If
        Call Inhabilitar_Controles_OTOrigen(Cbo1.ReadOnly)
        frm = Nothing
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        Dim frm As New frmBuscar
        If Chk1.Checked = False Then
            frm.Formulario = frmBuscar.eState.frm_Cliente
        Else
            frm.Formulario = frmBuscar.eState.frm_Area_Jefatura
        End If
        frm.ShowDialog()

        Txt3.Text = frm.Flag2 & "  " & frm.Descripcion
        Txt4.Text = frm.Flag3
        Me.AreaInt = frm.Flag4
        Me.FechaInicioJA = frm.Flag5
        Me.FechaTerminoJA = frm.Flag6
        Cliente = frm.Flag2
        frm = Nothing
    End Sub

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        Dim frm As New frmBuscar
        frm.Formulario = frmBuscar.eState.frm_Equipo
        frm.ShowDialog()
        Equipo = frm.ID
        Call Cargar_Requerimiento(0)
        Txt5.Text = frm.Flag7 & "  " & frm.Descripcion
        Cbo3.Value = frm.Flag3
        Atributo = frm.Flag1
        If Atributo > 0 Then
            Label9.Text = "* " & frm.Flag2 & ":"
            TipoDato = Val(frm.Flag4)
            Select Case TipoDato
                Case ValorTipoDato.vDate
                    Txt7.FormatString = "{LOC}dd/mm/yyyy"
                    Txt8.Visible = False
                    Txt7.Visible = True
                Case ValorTipoDato.vTime
                    Txt7.FormatString = "{LOC}hh:mm"
                    Txt8.Visible = False
                    Txt7.Visible = True
                Case Else
                    Txt7.Visible = False
                    Txt8.Visible = True
            End Select
            Longitud = Val(frm.Flag5)
            Decimales = Val(frm.Flag6)
        Else
            Call Limpiar_Datos_Equipo()
        End If

        frm = Nothing
    End Sub


#End Region
#Region "Combo"
    Private Sub Combo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo1.ValueChanged, Cbo5.ValueChanged, Cbo6.ValueChanged, Cbo8.ValueChanged

        If e Is Nothing Then Return

        If sender Is Cbo1 Then
            If Cbo1.Value <> "" Then
                Call Cargar_Presupuesto()
                Call ObtenerJefeArea()
            End If
        End If

        If sender Is Cbo5 Then
            If TipoG = State.eNew OrElse TipoG = State.eEdit Then
                If Cbo5.Value IsNot Nothing Then
                    Txt19.Text = CargarTipoCambio()
                    If Val(Txt19.Text) <= 0 Then
                        MsgBox("No hay Tipo de Cambio para la Fecha", MsgBoxStyle.Exclamation, msgComacsa)
                    End If
                    Cbo6.Focus()
                End If
               
            End If
        End If

        If sender Is Cbo6 Then
            If Cbo6.ActiveRow Is Nothing Then Return

            Txt17.Text = sender.ActiveRow.Cells("CheckList").Value
            Txt18.Text = sender.ActiveRow.Cells("Programacion").Value
            Me.Requerimiento = sender.Value
            Me.Programacion = sender.ActiveRow.Cells("ProgramacionID").Value
        End If

        If sender Is Cbo8 Then
            If Cbo8.Rows.Count <= 0 Then Return
            If sender.ActiveRow Is Nothing Then Return
            If Val(Cbo8.Value) <= 0 Then
                Call InHabilitarControles_Presupuesto(False)
                Call LimpiarDatosPresupuesto()
                Return
            End If


            Call InHabilitarControles_Presupuesto(True)

            Presupuesto = sender.ActiveRow.Cells("Presupuesto").Value
            Txt10.Value = sender.ActiveRow.Cells("Total").Value
            EncargadoArea = sender.ActiveRow.Cells("Cod_EncargadoArea").Value
            Txt20.Text = EncargadoArea & "  " & sender.ActiveRow.Cells("EncargadoArea").Value
            Chk1.Checked = sender.ActiveRow.Cells("TipoCliente").Value
            Txt3.Text = sender.ActiveRow.Cells("Cliente").Value

            If Chk1.Checked = False Then
                Txt4.Text = sender.ActiveRow.Cells("RUC").Value
                Cliente = sender.ActiveRow.Cells("Cod_Cli").Value
            Else
                Txt4.Text = sender.ActiveRow.Cells("AreaInterna").Value
                Cliente = sender.ActiveRow.Cells("Cod_ClienteInt").Value
            End If

            Txt5.Text = sender.ActiveRow.Cells("Equipo").Value
            Cbo2.Value = sender.ActiveRow.Cells("TipoProceso").Value
            Label9.Text = "* " & sender.ActiveRow.Cells("Atributo").Value & ":"
            TipoDato = Val(sender.ActiveRow.Cells("TipoDato").Value)

            Equipo = sender.ActiveRow.Cells("EquipoID").Value
            If TipoG = State.eNew Then
                Call Cargar_Requerimiento(0)
            Else
                Call Cargar_Requerimiento(Requerimiento)
            End If

            Cbo3.Value = sender.ActiveRow.Cells("Cod_UniMed").Value
            Atributo = sender.ActiveRow.Cells("AtributoControl").Value

            Select Case TipoDato
                Case ValorTipoDato.vDate
                    Txt7.FormatString = "{LOC}dd/mm/yyyy"
                    Txt8.Visible = False
                    Txt7.Visible = True
                    Txt7.Value = sender.ActiveRow.Cells("ValorControl").Value

                Case ValorTipoDato.vTime
                    Txt7.FormatString = "{LOC}hh:mm"
                    Txt8.Visible = False
                    Txt7.Visible = True
                    Txt7.Value = sender.ActiveRow.Cells("ValorControl").Value
                Case Else
                    Txt7.Visible = False
                    Txt8.Visible = True
                    Txt8.Text = sender.ActiveRow.Cells("ValorControl").Value
            End Select

            Longitud = sender.ActiveRow.Cells("Longitud").Value
            Decimales = sender.ActiveRow.Cells("Decimales").Value

            Cbo4.Value = sender.ActiveRow.Cells("Cod_Prioridad").Value
            Cbo5.Value = sender.ActiveRow.Cells("Moneda").Value
            Dtp1.Value = sender.ActiveRow.Cells("FechaInicio").Value
            Dtp2.Value = sender.ActiveRow.Cells("FechaTerminacion").Value
            Txt6.Focus()
        End If
    End Sub
    Private Sub Combo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo1.InitializeLayout, Cbo3.InitializeLayout, Cbo6.InitializeLayout, Cbo8.InitializeLayout

        If e Is Nothing Then
            Return
        End If

        If sender Is Cbo1 Then
            With sender.DisplayLayout.Bands(0)
                .ColHeadersVisible = Boolean.TrueString
                For Each uColumn As UltraGridColumn In .Columns
                    If sender.Name = "Cbo1" Then
                        If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Area" _
                            OrElse uColumn.Key = "Abrev") Then
                            uColumn.Hidden = Boolean.TrueString
                        Else
                            uColumn.Hidden = Boolean.FalseString
                        End If
                    End If
                Next
            End With
            Cbo1.DisplayLayout.Bands(0).Columns("Codigo").Width = 50
            Cbo1.DisplayLayout.Bands(0).Columns("Area").Width = 300
            Cbo1.DisplayLayout.Bands(0).Columns("Abrev").Width = 60

        End If

        If sender Is Cbo3 Then
            With sender.DisplayLayout.Bands(0)
                .ColHeadersVisible = Boolean.TrueString
                .Columns("Descripcion").Width = sender.Width - 40
                .Columns("Abrev").Width = 40
                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Descripcion" OrElse uColumn.Key = "Abrev") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next

            End With
        End If

        If sender Is Cbo6 Then
            With sender.DisplayLayout.Bands(0)

                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "CheckList" _
                            OrElse uColumn.Key = "Programacion") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next

            End With
        End If

        If sender Is Cbo8 Then
            With sender.DisplayLayout.Bands(0)

                For Each uColumn As UltraGridColumn In .Columns
                    If Not (uColumn.Key = "Cod_Presup" OrElse uColumn.Key = "Fecha" _
                            OrElse uColumn.Key = "Moneda" OrElse uColumn.Key = "Total") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                Next

            End With
        End If
    End Sub
#End Region

    Private Sub Txt8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt8.KeyPress
        Dim KeyAscii As Integer = 0
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            Cbo4.Focus()
        Else
            'If Cbo2.Value = "1" Then
            Select Case TipoDato
                Case ValorTipoDato.vEntero
                    KeyAscii = ValidarEntero(KeyAscii)
                Case ValorTipoDato.vDecimal
                    KeyAscii = ValidarDecimal(KeyAscii, Txt8.Text)
            End Select
            'End If
        End If
        e.KeyChar = Chr(KeyAscii)
    End Sub

    Private Sub Chk1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk1.CheckedChanged
        Me.Txt3.Clear()
        Me.Txt4.Clear()
        Me.Cliente = String.Empty
        Me.FechaInicioJA = String.Empty
        Me.FechaTerminoJA = String.Empty
        Me.AreaInt = String.Empty
        If Btn2.Enabled = True Then Btn2.Focus()

    End Sub
#Region "Grilla"

    Private Sub Grilla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid2.DoubleClick, Grid3.DoubleClick, Grid4.DoubleClick, Grid5.DoubleClick
        If sender.Rows.Count <= 0 Then
            Return
        End If

        If Not (TipoG = State.eEdit) Then
            Return
        End If

        Dim frm As New frmPOTRecursosDetalle
        frm.OrdenTrabajo = Me.OrdenTrabajo
        If sender Is Grid2 Then
            frm.TipoRecurso = frmPOTRecursosDetalle.Recursos.Material
        ElseIf sender Is Grid3 Then
            frm.TipoRecurso = frmPOTRecursosDetalle.Recursos.Equipo
        ElseIf sender Is Grid4 Then
            frm.TipoRecurso = frmPOTRecursosDetalle.Recursos.ManoObra
        ElseIf sender Is Grid5 Then
            frm.TipoRecurso = frmPOTRecursosDetalle.Recursos.Servicio
        End If
        frm.Status = Status
        frm.ShowDialog()
        frm = Nothing
    End Sub
    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout, Grid3.InitializeLayout, Grid4.InitializeLayout, Grid5.InitializeLayout, Grid6.InitializeLayout

        If sender Is Grid1 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Abrev" OrElse uColumn.Key = "Codigo" _
                   OrElse uColumn.Key = "Cod_Presp" OrElse uColumn.Key = "OTOrigen" _
                   OrElse uColumn.Key = "Cliente" OrElse uColumn.Key = "Equipo" _
                   OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "Moneda" _
                   OrElse uColumn.Key = "CostoPresup" OrElse uColumn.Key = "CostoTotal" _
                   OrElse uColumn.Key = "Estado") Then
                    uColumn.Hidden = True
                Else
                    uColumn.Hidden = False
                End If
            Next

            If Formulario = NameFormulario.eOrdenTrabajo Then
                Me.Grid1.DisplayLayout.Bands(0).Columns("OTOrigen").Hidden = True
            End If

        ElseIf sender Is Grid6 Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                'OrElse uColumn.Key = "UniMed" OrElse uColumn.Key = "Cantidad" _

                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                   OrElse uColumn.Key = "UniMed" OrElse uColumn.Key = "SubTotal") Then
                    uColumn.Hidden = True
                Else
                    uColumn.Hidden = False
                End If
            Next
        Else
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Descripcion" _
                   OrElse uColumn.Key = "UniMed" OrElse uColumn.Key = "Cantidad" _
                   OrElse uColumn.Key = "SubTotal") Then
                    uColumn.Hidden = True
                Else
                    uColumn.Hidden = False
                End If
            Next
        End If

    End Sub

#End Region
   

    Private Sub Dtp1_BeforeDropDown(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dtp1.BeforeDropDown

    End Sub


End Class