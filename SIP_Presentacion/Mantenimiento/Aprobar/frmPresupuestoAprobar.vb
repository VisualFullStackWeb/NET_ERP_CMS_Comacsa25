Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmPresupuestoAprobar
    Public Ls_Permisos As New List(Of Integer)
    Private Contador As Integer = 0

    Public Sub Actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call Inicio()
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Public Sub Grabar()

        If Grid1.Rows.Count <= 0 Then
            MsgBox("No hay Presupuestos Pendientes de Aprobación", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If

        Dim Lista As New List(Of ETPresupuesto)
        Grid1.UpdateData()
        For Each Row As UltraGridRow In Grid1.Rows
            If Row.Cells("Action").Value = True Then
                Entidad.Presupuesto = New ETPresupuesto
                With Entidad.Presupuesto
                    .Presupuesto = Row.Cells("Presupuesto").Value
                    .Status = "A"
                    .Usuario = User_Sistema
                    .Tipo = 9
                End With
                Lista.Add(Entidad.Presupuesto)
            End If
        Next

        If Lista.Count <= 0 Then
            MsgBox("Debe checkear al menos un Presupuesto", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If


        Negocio.Presupuesto = New NGPresupuesto
        If Negocio.Presupuesto.Aprobar_Presupuesto(Lista) > 0 Then
            MsgBox("Se Aprobarón los Presupuestos Satisfactoriamente", MsgBoxStyle.Information, msgComacsa)
            Call Actualizar()
        End If
    End Sub

    Private Sub Inicio()
        Dim Ls_Presupuesto As New List(Of ETPresupuesto)

        Negocio.Presupuesto = New NGPresupuesto

        Entidad.MyLista = New ETMyLista
        Entidad.MyLista = Negocio.Presupuesto.Consultar_Presupuesto_Pendinte_Aprobar
        If Entidad.MyLista.Validacion Then
            Ls_Presupuesto = Entidad.MyLista.Ls_Presupuesto
        End If
        Contador = 0
        Call CargarUltraGrid(Grid1, Ls_Presupuesto)
    End Sub

    Private Sub frmPresupuestoAprobar_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmPresupuestoAprobar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Inicio()
    End Sub
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Return
        End If

        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If uColumn.Key = "Action" Then
                uColumn.CellActivation = Activation.AllowEdit
            Else
                uColumn.CellActivation = Activation.NoEdit
            End If


            If Not (uColumn.Key = "Fecha" OrElse uColumn.Key = "Action" _
                    OrElse uColumn.Key = "Area_Abrev" OrElse uColumn.Key = "Cod_Presup" _
                    OrElse uColumn.Key = "Equipo" OrElse uColumn.Key = "TipoMantto" _
                    OrElse uColumn.Key = "Moneda" OrElse uColumn.Key = "Total" _
                    OrElse uColumn.Key = "FechaInicio" OrElse uColumn.Key = "FechaTerminacion") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No hay Presupuestos Pendientes de Aprobación", MsgBoxStyle.Critical, msgComacsa)
            Exit Sub
        End If
        If Contador Mod 2 = 0 Then
            For Each Row As UltraGridRow In Grid1.Rows
                Row.Cells("Action").Value = True
            Next
        Else
            For Each Row As UltraGridRow In Grid1.Rows
                Row.Cells("Action").Value = False
            Next
        End If
        Grid1.UpdateData()
    End Sub
End Class