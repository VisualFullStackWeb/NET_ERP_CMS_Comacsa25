Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmMAreaEmpleado
#Region "Declarar Variables"
    Private Enum State
        eNew = 1
        eEdit = 2
        eDel = 3
        eSelect = 4
    End Enum
    Private TipoG As State
    Private Ls_AreaEmp As List(Of ETAreaEmpleado) = Nothing
    Private Ls_AreaEmp_Del As List(Of ETAreaEmpleado) = Nothing
    Public Ls_Permisos As New List(Of Integer)

#End Region

#Region "Formulario"
    Private Sub frmMAreaEmpleado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia)
    End Sub
#End Region

#Region "Procedimientos Privados"
    Private Sub Cargar_Grilla()
        Dim Lista As New List(Of ETAreaEmpleado)
        With Entidad.AreaEmpleado
            .Tipo = "4"
            .Cia = Companhia
        End With
        Entidad.MyLista = Negocio.AreaEmpleado.Consultar_Area_Empleado(Entidad.AreaEmpleado)

        If Entidad.MyLista.Validacion = True Then
            Lista = Entidad.MyLista.Ls_AreaEmpleado
        End If
        Call CargarUltraGrid(Grid1, Lista)
    End Sub
    Private Sub CargarEmpleadoEnlazado()
        Dim Lista As New List(Of ETAreaEmpleado)
        With Entidad.AreaEmpleado
            .Tipo = "5"
            .Cia = Cia.Value
            .Codigo = Cbo1.Value
        End With
        Entidad.MyLista = Negocio.AreaEmpleado.Consultar_Area_Empleado(Entidad.AreaEmpleado)

        If Entidad.MyLista.Validacion = True Then
            Lista = Entidad.MyLista.Ls_AreaEmpleado
        End If
        Call CargarUltraGrid(Grid3, Lista)
    End Sub
    Private Sub CargarEmpleadoSinEnlace()
        Dim Lista As New List(Of ETAreaEmpleado)
        With Entidad.AreaEmpleado
            .Tipo = "6"
            .Cia = Cia.Value
        End With
        Entidad.MyLista = Negocio.AreaEmpleado.Consultar_Area_Empleado(Entidad.AreaEmpleado)

        If Entidad.MyLista.Validacion = True Then
            Lista = Entidad.MyLista.Ls_AreaEmpleado
        End If
        Call CargarUltraGrid(Grid2, Lista)
    End Sub

    Private Sub Limpiar()
        Cia.Value = Companhia
        If Cbo1.Rows.Count > 0 Then Cbo1.Value = ""
        Ls_AreaEmp = Nothing
        Ls_AreaEmp = New List(Of ETAreaEmpleado)
        Call CargarUltraGrid(Grid2, Ls_AreaEmp)
        Call CargarUltraGrid(Grid3, Ls_AreaEmp)
    End Sub

    Private Sub HabilitarControles(ByVal b As Boolean)
        Cia.ReadOnly = Not b
        Cbo1.ReadOnly = Not b
        Btn2.Enabled = b
        Btn3.Enabled = b

        'If b = True Then
        'Grid2.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.AllowEdit
        'Grid2.DisplayLayout.Bands(0).Columns("FechaInicio").CellActivation = Activation.AllowEdit
        'Grid2.DisplayLayout.Bands(0).Columns("FechaTermino").CellActivation = Activation.AllowEdit
        'Grid3.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.AllowEdit
        'Else
        'Grid2.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.NoEdit
        'Grid2.DisplayLayout.Bands(0).Columns("FechaInicio").CellActivation = Activation.NoEdit
        'Grid2.DisplayLayout.Bands(0).Columns("FechaTermino").CellActivation = Activation.NoEdit
        'Grid3.DisplayLayout.Bands(0).Columns("Action").CellActivation = Activation.NoEdit
        'End If

    End Sub
#End Region
#Region "Procedimientos Publicos"
    Public Sub Nuevo()
        TipoG = State.eNew
        Call HabilitarControles(Boolean.TrueString)
        Call Limpiar()
        Call Cargar_Area(Cbo1, TipoG, Cia.Value)
    End Sub

#End Region
#Region "Combo"
    Private Sub Cbo1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Cbo1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        With sender.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.TrueString
            For Each uColumn As UltraGridColumn In .Columns
                If sender.Name = "Cbo1" Then
                    If Not (uColumn.Key = "Codigo" OrElse uColumn.Key = "Area") Then
                        uColumn.Hidden = Boolean.TrueString
                    Else
                        uColumn.Hidden = Boolean.FalseString
                    End If
                End If
            Next
        End With

        If sender.Name = "Cbo1" Then
            Cbo1.DisplayLayout.Bands(0).Columns("Codigo").Width = 50
            Cbo1.DisplayLayout.Bands(0).Columns("Area").Width = Cbo1.Width - 50
        End If
    End Sub

    Private Sub Combo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cia.ValueChanged, Cbo1.ValueChanged
        If sender.Name = "Cia" Then
            Call Cargar_Area(Cbo1, TipoG, Cia.Value)
        Else
            Call CargarEmpleadoSinEnlace()
        End If
    End Sub

#End Region
   

#Region "Grilla"
    Private Sub Grilla_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout, Grid2.InitializeLayout, Grid3.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        If sender.name = "Grid1" Then
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                uColumn.CellActivation = Activation.NoEdit
                If Not (uColumn.Key = "Compania" _
                        OrElse uColumn.Key = "Codigo" OrElse uColumn.Key = "Area") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        Else
            For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
                uColumn.CellActivation = Activation.NoEdit
                If Not (uColumn.Key = "Action" OrElse uColumn.Key = "ApePaterno" _
                        OrElse uColumn.Key = "ApeMaterno" OrElse uColumn.Key = "Nombres" _
                        OrElse uColumn.Key = "Cod_Emp" OrElse uColumn.Key = "FechaInicio" _
                        OrElse uColumn.Key = "FechaTermino") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End If

    End Sub

#End Region
   
End Class