Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports SIP_Entidad
Imports SIP_Negocio
Public Class UsuarioClonar
    Public usuario As String
#Region "Variables"

    Private Val As Boolean = Boolean.FalseString
    Private Tipo As Int16 = 0
    Private Respuesta As Short = 0
    Private Ls_Usuario As List(Of ETUsuario) = Nothing
    Private ListModulos As List(Of ETUsuario) = Nothing
    Private Lis As DataTable = Nothing
    Private MdiOperaciones As List(Of String) = Nothing
    Public Ls_Permisos As New List(Of Integer)


    Private Structure EstadoUsuario
        Event z()
        Const KeyEliminado As String = "E"
        Const KeyInactivo As String = "I"
        Const KeyActivo As String = "A"
        Const Eliminado As String = "ELIMINADO"
        Const Inactivo As String = "INACTIVO"
        Const Activo As String = "ACTIVO"
    End Structure
#End Region

    Private Sub UsuarioClonar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Negocio.Usuario = New NGUsuario
        Entidad.MyLista = New ETMyLista

        Entidad.MyLista = Negocio.Usuario.ConsultarUsuario

        If Not Entidad.MyLista.Validacion Then Return

        Ls_Usuario = New List(Of ETUsuario)
        Ls_Usuario = Entidad.MyLista.Ls_Usuario

        Call CargarUltraGridxBinding(Grid1, Source1, Ls_Usuario)

    End Sub

    Private Sub Grid1_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Grid1.DoubleClickRow
        Try
            usuario = Grid1.ActiveRow.Cells("Usuario").Value
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender Is Grid1 Then

            For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
                If Not (uColumn.Key = "Usuario" Or uColumn.Key = "Encargado") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
            Return
        End If

        'If sender Is Grid2 Then

        '    For Each uColumn As UltraGridColumn In sender.DisplayLayout.Bands(0).Columns
        '        If Not (uColumn.Key = "Formulario" Or uColumn.Key = "Action" Or _
        '                uColumn.Key = "Operacion") Then
        '            uColumn.Hidden = Boolean.TrueString
        '        Else
        '            uColumn.Hidden = Boolean.FalseString
        '        End If
        '    Next
        '    Return

        'End If

    End Sub
End Class