Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmPProgramacionMantto
#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)
    Private _Requerimiento As Long = 0
    Private _Programacion As Long = 0
    Private _Req_Anterior As Long = 0
    Private _Equipo_Anterior As Long = 0
    Private Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eView = 4
    End Enum
    Private TipoG As State
#End Region
#Region "Propiedades privadas"
    Private Property Requerimiento() As Long
        Get
            Return _Requerimiento
        End Get
        Set(ByVal value As Long)
            _Requerimiento = value
        End Set
    End Property
    Private Property Programacion() As Long
        Get
            Return _Programacion
        End Get
        Set(ByVal value As Long)
            _Programacion = value
        End Set
    End Property
    Private Property Req_Anterior() As Long
        Get
            Return _Req_Anterior
        End Get
        Set(ByVal value As Long)
            _Req_Anterior = value
        End Set
    End Property
    Private Property Equipo_Anterior() As Long
        Get
            Return _Equipo_Anterior
        End Get
        Set(ByVal value As Long)
            _Equipo_Anterior = value
        End Set
    End Property
#End Region
#Region "Procedimientos Privados"
    Private Sub InicializarVariables()
        _Requerimiento = 0
        _Programacion = 0
        _Req_Anterior = 0
        _Equipo_Anterior = 0
    End Sub
    Private Sub Limpiar()
        Call InicializarVariables()
        Txt1.Clear()
        Txt2.Clear()
        Txt3.Clear()
        Cbo1.Value = ""
        Dtp1.Value = Date.Today
        Dtp2.Value = Date.Today
        Dtp3.Value = Date.Today
        Cbo2.Value = "K1"
    End Sub
    Private Sub HabilitarControles(ByVal b As Boolean)
        Txt1.ReadOnly = Boolean.TrueString
        Txt2.ReadOnly = Boolean.TrueString
        Btn1.Enabled = b
        Cbo1.ReadOnly = Boolean.TrueString
        Dtp1.ReadOnly = Boolean.TrueString
        Dtp2.ReadOnly = Not b
        Dtp3.ReadOnly = Not b
        Txt3.ReadOnly = Not b
        Cbo2.ReadOnly = Boolean.TrueString
    End Sub
    Private Sub CargarRequerimiento_Equipo()
        Dim Ls_Equipo As New List(Of ETRequerimiento_ManttoDetalle)
        Dim objReq As New ETRequerimiento_ManttoDetalle
        Dim objNeg As New NGRequerimiento_Mantto
        objReq.Requerimiento = Me.Requerimiento
        objReq.EquipoID = Me.Equipo_Anterior

        If TipoG = State.eNew Then
            objReq.Tipo = 5
            objReq.Status = ""
        Else
            If Cbo2.Value = "K1" Then
                objReq.Tipo = 6
                objReq.Status = ""
            Else
                objReq.Tipo = 6
                objReq.Status = "P"
            End If
        End If

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = objNeg.Consultar_Equipos_Programar(objReq)
        Ls_Equipo = Entidad.MyLista.Ls_Requerimiento_Det_Mantto
        Call CargarUltraCombo(Cbo1, Ls_Equipo, "EquipoID", "Equipo")
    End Sub
    Private Sub Cargar_Programacion()
        Dim Ls_Programacion As New List(Of ETProgramacionMantto)
        Entidad.MyLista = New ETMyLista
        Negocio.Programacion_Mantto = New NGProgramacionMantto
        Entidad.MyLista = Negocio.Programacion_Mantto.Consultar_Programacion
        If Entidad.MyLista.Validacion Then
            Ls_Programacion = Entidad.MyLista.Ls_Programacion_Mantto
        End If
        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Programacion)
    End Sub
    Private Sub Iniciar()
        TipoG = State.eView
        Me.Tab1.Tabs("T01").Selected = Boolean.TrueString
        Call Cargar_Programacion()
        Call HabilitarControles(False)
        Call Limpiar()
    End Sub
#End Region
#Region "Procedimientos Publicos"
    Public Sub Nuevo()
        TipoG = State.eNew
        Call Limpiar()
        Call HabilitarControles(Boolean.TrueString)
        Tab1.Tabs("T02").Selected = Boolean.TrueString
        Btn1.Focus()
    End Sub
    Public Sub Grabar()
        Dim Resultado As Integer = 0
        If Cbo2.Value <> "K1" Then
            Call Iniciar()
            Return
        End If

        Entidad.Programacion_Mantto = New ETProgramacionMantto
        Entidad.Programacion_Mantto.Tipo = TipoG
        Entidad.Programacion_Mantto.RequerimientoID = Me.Requerimiento
        Entidad.Programacion_Mantto.EquipoID = Me.Cbo1.Value
        Entidad.Programacion_Mantto.Fecha = Me.Dtp1.Value
        Entidad.Programacion_Mantto.FechaInicio = Me.Dtp2.Value
        Entidad.Programacion_Mantto.FechaTerminacion = Me.Dtp3.Value
        Entidad.Programacion_Mantto.Observaciones = Txt3.Text.Trim
        Entidad.Programacion_Mantto.Req_Anterior = Me.Req_Anterior
        Entidad.Programacion_Mantto.Equipo_Anterior = Me.Equipo_Anterior
        Entidad.Programacion_Mantto.Usuario = User_Sistema
        Select Case Cbo2.Value
            Case "K4"
                Entidad.Programacion_Mantto.Status = "*"
            Case "K3"
                Entidad.Programacion_Mantto.Status = "T"
            Case "K2"
                Entidad.Programacion_Mantto.Status = "P"
            Case Else
                Entidad.Programacion_Mantto.Status = ""
        End Select
        Negocio.Programacion_Mantto = New NGProgramacionMantto
        Try
            Resultado = Negocio.Programacion_Mantto.Mantenedor_Programacion(Entidad.Programacion_Mantto)
            If Resultado > 0 Then Call Iniciar()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, msgComacsa)
        End Try
    End Sub
    Public Sub Modificar()
        If Grid1.Rows.Count <= 0 Then Return
        If Grid1.ActiveRow Is Nothing Then Return
        TipoG = State.eEdit
        Call Limpiar()
        Call HabilitarControles(False)
        Me.Txt1.Text = Grid1.ActiveRow.Cells("Codigo").Value
        Me.Txt2.Text = Grid1.ActiveRow.Cells("Cod_Req").Value
        Select Case Grid1.ActiveRow.Cells("Status").Value
            Case "*"
                Cbo2.Value = "K4"
            Case "T"
                Cbo2.Value = "K3"
            Case "P"
                Cbo2.Value = "K2"
            Case Else
                Call HabilitarControles(True)
                Cbo2.Value = "K1"
        End Select
        Me.Requerimiento = Grid1.ActiveRow.Cells("RequerimientoID").Value
        Me.Req_Anterior = Requerimiento
        Me.Equipo_Anterior = Grid1.ActiveRow.Cells("EquipoID").Value
        Call CargarRequerimiento_Equipo()
        Cbo1.Value = Grid1.ActiveRow.Cells("EquipoID").Value
        Dtp1.Value = Grid1.ActiveRow.Cells("Fecha").Value
        Dtp2.Value = Grid1.ActiveRow.Cells("FechaInicio").Value
        Dtp3.Value = Grid1.ActiveRow.Cells("FechaTerminacion").Value
        Txt3.Text = Grid1.ActiveRow.Cells("Observaciones").Value
        Me.Tab1.Tabs("T02").Selected = Boolean.TrueString
        
        Me.Programacion = Grid1.ActiveRow.Cells("Programacion").Value
    End Sub
    Public Sub Eliminar()

        If Grid1.Rows.Count <= 0 Then Exit Sub
        If Grid1.ActiveRow Is Nothing Then Exit Sub
        If Not (Grid1.ActiveRow.Cells("Status").Value.ToString.Trim = "") Then
            MsgBox("Solo puede anular las Programaciones que estan en Estado ACTIVO", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        Me.Requerimiento = Me.Grid1.ActiveRow.Cells("Requerimiento").Value
        Entidad.Programacion_Mantto = New ETProgramacionMantto
        Entidad.Programacion_Mantto.Usuario = User_Sistema
        Entidad.Programacion_Mantto.Status = "*"
        Entidad.Programacion_Mantto.Tipo = 3
        Negocio.Programacion_Mantto = New NGProgramacionMantto

        Try
            Negocio.Programacion_Mantto.Mantenedor_Programacion(Entidad.Programacion_Mantto)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, msgComacsa)
        End Try
        Call Iniciar()
    End Sub

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Iniciar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
#End Region
#Region "Formulario"

    Private Sub frmPProgramacionMantto_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub
    Private Sub frmPProgramacionMantto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Iniciar()
    End Sub
#End Region
#Region "Botones"
    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        Dim frm As New frmBuscar
        frm.Formulario = frmBuscar.eState.frm_Requerimiento
        frm.ShowDialog()
        Txt2.Text = frm.Descripcion
        Me.Requerimiento = frm.ID
        Call CargarRequerimiento_Equipo()
        If Cbo2.Value = "K1" Then
            Me.Cbo1.ReadOnly = Boolean.FalseString
        End If
        frm = Nothing
    End Sub
#End Region
#Region "Combos"
    Private Sub Cbo1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo1.InitializeLayout

        If e Is Nothing Then
            Return
        End If

        With Cbo1.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.TrueString
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Equipo" _
                    OrElse uColumn.Key = "CheckList") Then
                    uColumn.Hidden = Boolean.TrueString

                Else
                    Select Case uColumn.Key
                        Case "Codigo", "CheckList"
                            uColumn.MaxWidth = 80
                            uColumn.MinWidth = 80
                        Case "Equipo"
                            uColumn.MinWidth = Cbo1.Width - 160
                    End Select
                    uColumn.Hidden = Boolean.FalseString
                End If

            Next
        End With
    End Sub
#End Region
#Region "Grillas"
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Fecha" _
                    OrElse uColumn.Key = "Cod_Req" OrElse uColumn.Key = "Cod_Eq" _
                    OrElse uColumn.Key = "Equipo" OrElse uColumn.Key = "FechaInicio" _
                    OrElse uColumn.Key = "FechaTerminacion" OrElse uColumn.Key = "Observaciones" _
                    OrElse uColumn.Key = "Estado") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
#End Region

End Class