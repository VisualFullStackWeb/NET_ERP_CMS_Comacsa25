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
Public Class frmMant_Conceptos
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

    Private Sub frmMant_Conceptos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Procesar()
    End Sub
    Sub Procesar()
        Try
            Entidad.Contratista = New ETContratista
            Entidad.Contratista.TipoOperacion = Ope
            Negocio.NContratista = New NGContratista
            Entidad.MyLista = New ETMyLista
            Entidad.Contratista.Usuario = User_Sistema
            Dim dtConsulta As New DataTable
            dtConsulta = Negocio.NContratista.llenar_Concepto(Entidad.Contratista)
            Call CargarUltraGridxBinding(Me.gridConsulta, Source1, dtConsulta)
        Catch ex As Exception

        End Try
    End Sub
    Sub nuevo()
        Tab1.Tabs("T02").Selected = True
        limpiar()
        txtconcepto.Focus()
    End Sub
    Sub limpiar()
        txtid.Text = 0
        txtconcepto.Clear()
    End Sub

    Private Sub gridConsulta_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridConsulta.DoubleClickRow
        Try
            Tab1.Tabs("T02").Selected = True
            txtid.Text = gridConsulta.ActiveRow.Cells("IDCONCEPTO").Value
            txtconcepto.Text = gridConsulta.ActiveRow.Cells("CONCEPTO").Value
            txtconcepto.Focus()
        Catch ex As Exception

        End Try
    End Sub
    Sub Grabar()
        Try
            If MsgBox("Seguro de grabar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                Entidad.Contratista = New ETContratista
                Entidad.Contratista.TipoOperacion = 1
                Negocio.NContratista = New NGContratista
                Entidad.MyLista = New ETMyLista
                Entidad.Contratista.ID = txtid.Text
                Entidad.Contratista._descripcion = txtconcepto.Text
                Entidad.Contratista.Usuario = User_Sistema
                Dim dtDatos As New DataTable
                dtDatos = New DataTable
                dtDatos = Negocio.NContratista.Mant_Concepto_Prog(Entidad.Contratista)
                If dtDatos.Rows(0)(0) = "OK" Then
                    MsgBox("Creado correctamente", MsgBoxStyle.Information, msgComacsa)
                    Procesar()
                    Tab1.Tabs("T01").Selected = True
                Else
                    MsgBox("Error", MsgBoxStyle.Exclamation, msgComacsa)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub Eliminar()
        Try
            If MsgBox("Seguro de eliminar registro?", MsgBoxStyle.YesNo, msgComacsa) = MsgBoxResult.Yes Then
                Entidad.Contratista = New ETContratista
                Entidad.Contratista.TipoOperacion = 3
                Negocio.NContratista = New NGContratista
                Entidad.MyLista = New ETMyLista
                Entidad.Contratista.ID = txtid.Text
                Entidad.Contratista._descripcion = txtconcepto.Text
                Entidad.Contratista.Usuario = User_Sistema
                Dim dtDatos As New DataTable
                dtDatos = New DataTable
                dtDatos = Negocio.NContratista.Mant_Concepto_Prog(Entidad.Contratista)
                If dtDatos.Rows(0)(0) = "OK" Then
                    MsgBox("Eliminado correctamente", MsgBoxStyle.Information, msgComacsa)
                    Procesar()
                    Tab1.Tabs("T01").Selected = True
                Else
                    MsgBox("Error", MsgBoxStyle.Exclamation, msgComacsa)
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class