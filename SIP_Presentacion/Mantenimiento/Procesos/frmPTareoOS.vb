Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports SIP_Entidad
Imports SIP_Negocio

Public Class frmPTareoOS

#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)

    Public Enum NameForm
        frm_TareoOT_Personal = 79
        frm_TareoOT_Equipo = 81
    End Enum

    Public Formulario As NameForm


    Private Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum

    Private TipoG As State
    Private _Recurso As Long = 0
    Private _OrdenTrabajo As Long = 0
    Private _TareoOS As Long = 0
    Private _Fecha1 As Date = Date.Today
    Private _Fecha2 As Date = Date.Today
    Private _Fecha3 As String = String.Empty
    Private _Fecha4 As String = String.Empty

#End Region

#Region "Propiedades Privadas"
    Private Property OrdenTrabajo() As Long
        Get
            Return _OrdenTrabajo
        End Get
        Set(ByVal value As Long)
            _OrdenTrabajo = value
        End Set
    End Property
    Private Property TareoOS() As Long
        Get
            Return _TareoOS
        End Get
        Set(ByVal value As Long)
            _TareoOS = value
        End Set
    End Property
    Private Property Recurso() As Long
        Get
            Return _Recurso
        End Get
        Set(ByVal value As Long)
            _Recurso = value
        End Set
    End Property
    Private Property Fecha1() As Date
        Get
            Return _Fecha1
        End Get
        Set(ByVal value As Date)
            _Fecha1 = value
        End Set
    End Property
    Private Property Fecha2() As Date
        Get
            Return _Fecha2
        End Get
        Set(ByVal value As Date)
            _Fecha2 = value
        End Set
    End Property
    Private Property Fecha3() As String
        Get
            Return _Fecha3
        End Get
        Set(ByVal value As String)
            _Fecha3 = value
        End Set
    End Property
    Private Property Fecha4() As String
        Get
            Return _Fecha4
        End Get
        Set(ByVal value As String)
            _Fecha4 = value
        End Set
    End Property
#End Region

#Region "Procedimientos Privados"
    Private Sub InicializarVariables()
        _OrdenTrabajo = 0
        _Recurso = 0
        _TareoOS = 0
        _Fecha1 = Date.Today
        _Fecha2 = Date.Today
        _Fecha3 = String.Empty
        _Fecha4 = String.Empty
    End Sub

    Private Sub Limpiar()
        Call InicializarVariables()
        Txt1.Clear()
        Txt2.Clear()
        Txt3.Clear()
        Txt4.Clear()
        Txt5.Clear()
        UltraLabel3.Text = ""
        Dtp1.Value = Date.Now
        Dim Ls_Area As New List(Of ETArea)
        Call CargarUltraCombo(Me.Cbo1, Ls_Area, "Codigo", "Area")
        Dim Ls_TareoOS = New List(Of ETTareoOS)
        Call CargarUltraGrid(Grid2, Ls_TareoOS)
    End Sub

    Private Sub Inicio()
        TipoG = State.eView
        Call InicializarVariables()
        Call Limpiar()
        Call Cargar_Grilla(0)
        Call HabilitarControles(False)
        Tab1.Tabs("T01").Selected = True
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

    Private Sub Cargar_Grilla(ByVal OT As Long)
        Dim Ls_TareoOS = New List(Of ETTareoOS)
        With Entidad.TareoOs
            .OrdenTrabajo = OT
            .Tipo = 4
        End With

        If Formulario = NameForm.frm_TareoOT_Personal Then
            Entidad.MyLista = Negocio.TareoOS.Consultar_TareoOSPersonal(Entidad.TareoOs)
        Else
            Entidad.MyLista = Negocio.TareoOS.Consultar_TareoOSEquipo(Entidad.TareoOs)
        End If


        If Entidad.MyLista.Validacion Then
            Ls_TareoOS = Entidad.MyLista.Ls_TareoOS
        End If

        If OT = 0 Then
            Call CargarUltraGridxBinding(Grid1, Source1, Ls_TareoOS)
        Else
            Call CargarUltraGrid(Grid2, Ls_TareoOS)
        End If

    End Sub

    Private Sub HabilitarControles(ByVal xBol As Boolean)
        Txt1.ReadOnly = True
        Txt2.ReadOnly = True
        Txt3.ReadOnly = True
        Txt4.ReadOnly = True
        Txt5.ReadOnly = Not xBol
        Dtp1.ReadOnly = Not xBol
        Btn1.Enabled = xBol
        Btn2.Enabled = xBol

        If TipoG = State.eNew Then
            Cbo1.ReadOnly = Not xBol
        Else
            Cbo1.ReadOnly = True
        End If

    End Sub

#End Region

#Region "Procedimientos Publicos"
    Public Sub Nuevo()
        TipoG = State.eNew
        Call Limpiar()
        Call HabilitarControles(True)
        Call Cargar_Area()
        Tab1.Tabs("T02").Selected = True
    End Sub

    Public Sub Grabar()
        With Entidad.TareoOs
            .OrdenTrabajo = OrdenTrabajo
            .Cod_OT = Cbo1.Value & " - " & Txt2.Text
            .Cod_TareosOS = Txt1.Text
            .Codigo = Txt3.Text
            .Horas = Txt5.Text
            .Fecha = Dtp1.Value
            .FechaInicio = Fecha1
            .FechaTerminacion = Fecha2
            .Fecha1 = Fecha3
            .Fecha2 = Fecha4
            .Tipo = TipoG
            .Usuario = User_Sistema
            .Recurso = Recurso
            .TareoOS = TareoOS
        End With

        If Formulario = NameForm.frm_TareoOT_Personal Then
            If Negocio.TareoOS.Mantenedor_TareoPersonal(Entidad.TareoOs) > 0 Then
                Call Inicio()
            End If
        Else
            If Negocio.TareoOS.Mantenedor_TareoEquipo(Entidad.TareoOs) > 0 Then
                Call Inicio()
            End If
        End If
      

    End Sub

    Public Sub Eliminar()
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No hay Tareo de O/T", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        If Grid1.ActiveRow Is Nothing Then
            MsgBox("Seleccione algún Tareo", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        With Entidad.TareoOs
            .Cod_TareosOS = Grid1.ActiveRow.Cells("Cod_TareosOS").Value
            .TareoOS = Grid1.ActiveRow.Cells("TareoOS").Value
            .Usuario = User_Sistema
            .Tipo = 3
        End With


        If Formulario = NameForm.frm_TareoOT_Personal Then
            If Negocio.TareoOS.Mantenedor_TareoPersonal(Entidad.TareoOs) > 0 Then
                Call Inicio()
            End If
        Else
            If Negocio.TareoOS.Mantenedor_TareoEquipo(Entidad.TareoOs) > 0 Then
                Call Inicio()
            End If
        End If

    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Inicio()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Public Sub Cancelar()
        Call Inicio()
    End Sub

    Public Sub Modificar()
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No hay Tareo de O/T a Modificar", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        If Grid1.ActiveRow Is Nothing Then
            MsgBox("Seleccione algún Tareo", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        TipoG = State.eEdit
        Call Limpiar()
        Call HabilitarControles(True)
        Call Cargar_Area()

        Txt1.Text = Grid1.ActiveRow.Cells("Cod_TareosOS").Value
        Dtp1.Value = Grid1.ActiveRow.Cells("Fecha").Value
        Cbo1.Value = Grid1.ActiveRow.Cells("Area").Value
        Txt2.Text = Grid1.ActiveRow.Cells("Cod_OT").Value
        Txt3.Text = Grid1.ActiveRow.Cells("Codigo").Value
        Txt4.Text = Grid1.ActiveRow.Cells("Descripcion").Value
        Txt5.Text = Grid1.ActiveRow.Cells("Horas").Value
        OrdenTrabajo = Grid1.ActiveRow.Cells("OrdenTrabajo").Value
        TareoOS = Grid1.ActiveRow.Cells("TareoOS").Value
        Recurso = Grid1.ActiveRow.Cells("Recurso").Value
        Call Cargar_Grilla(OrdenTrabajo)
        Tab1.Tabs("T02").Selected = True
    End Sub
#End Region

#Region "Formulario"

    Private Sub frmPTareoOS_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub frmPTareoOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Formulario = Mid(Me.Tag, 2, 2)
        If Formulario = NameForm.frm_TareoOT_Equipo Then
            Tab1.Tabs("T01").Text = "TAREO O/T - EQUIPO"
            UltraLabel5.Text = "* Equipo :"
        Else
            Tab1.Tabs("T01").Text = "TAREO O/T - PERSONAL"
            UltraLabel5.Text = "* Empleado :"
        End If
        Call Inicio()
    End Sub
#End Region

#Region "Combo"
    Private Sub Cbo1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo1.InitializeLayout
        With sender.DisplayLayout.Bands(0)

            For Each uColumn As UltraGridColumn In .Columns
                uColumn.CellActivation = Activation.NoEdit
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Area" _
                    OrElse uColumn.Key = "Abrev") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
        Cbo1.DisplayLayout.Bands(0).Columns("Codigo").Width = 50
        Cbo1.DisplayLayout.Bands(0).Columns("Area").Width = 300
        Cbo1.DisplayLayout.Bands(0).Columns("Abrev").Width = 60
    End Sub
#End Region
   
#Region "Grilla"
    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            uColumn.CellActivation = Activation.NoEdit
            If sender Is Grid1 Then
                If Not (uColumn.Key = "Cod_TareosOS" OrElse uColumn.Key = "Codigo" _
                        OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "Fecha" _
                        OrElse uColumn.Key = "Horas" OrElse uColumn.Key = "Cod_OT") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    If uColumn.Key = "Descripcion" Then
                        If Formulario = NameForm.frm_TareoOT_Equipo Then
                            uColumn.Header.Caption = "Equipo"
                        Else
                            uColumn.Header.Caption = "Personal"
                        End If
                    End If
                    uColumn.Hidden = Boolean.FalseString
                End If
            Else
                If Not (uColumn.Key = "Cod_TareosOS" OrElse uColumn.Key = "Codigo" _
                       OrElse uColumn.Key = "Descripcion" OrElse uColumn.Key = "Fecha" _
                       OrElse uColumn.Key = "Horas") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    If uColumn.Key = "Descripcion" Then
                        If Formulario = NameForm.frm_TareoOT_Equipo Then
                            uColumn.Header.Caption = "Equipo"
                        Else
                            uColumn.Header.Caption = "Personal"
                        End If
                    End If
                    uColumn.Hidden = Boolean.FalseString
                End If
            End If


        Next
    End Sub
#End Region
#Region "Botones"
    Private Sub Boton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click, Btn2.Click
        Dim frmHijo As New frmBuscar
        If sender Is Btn1 Then
            frmHijo.Formulario = frmBuscar.eState.frm_OTs_EnEjecucion
        Else
            If Formulario = NameForm.frm_TareoOT_Personal Then
                frmHijo.Formulario = frmBuscar.eState.frm_Area_Empleado
            Else
                frmHijo.Formulario = frmBuscar.eState.frm_Equipo
            End If
        End If
        frmHijo.FechaInput = Me.Dtp1.Value
        frmHijo.Codigo_Input = Me.Cbo1.Value
        frmHijo.ShowDialog()
        If sender Is Btn1 Then
            Me.Txt2.Text = frmHijo.Flag2
            Fecha1 = frmHijo.Flag8
            Fecha2 = frmHijo.Flag9

            OrdenTrabajo = frmHijo.ID
            If OrdenTrabajo > 0 Then
                UltraLabel3.Text = "Desde: " & Fecha1.ToShortDateString & " Hasta: " & Fecha2.ToShortDateString
            Else
                UltraLabel3.Text = ""
            End If

            Call Cargar_Grilla(OrdenTrabajo)
        Else

            Me.Txt4.Text = frmHijo.Descripcion
            If Formulario = NameForm.frm_TareoOT_Personal Then
                Fecha3 = frmHijo.Flag3
                Fecha4 = frmHijo.Flag4
                Txt3.Text = frmHijo.Flag2
            Else
                Txt3.Text = frmHijo.Flag7
            End If
            Recurso = frmHijo.ID
        End If

        frmHijo = Nothing
    End Sub

#End Region
   

End Class