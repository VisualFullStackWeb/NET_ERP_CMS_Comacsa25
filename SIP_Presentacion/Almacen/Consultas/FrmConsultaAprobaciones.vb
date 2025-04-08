Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Math
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmConsultaAprobaciones
    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Load"
    Private Sub FrmConsultaAprobaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtInicio.Value = Now
        DtFin.Value = Now
        Call ListarCia(Cia1)
        Call ListarOC()
    End Sub
#End Region                '   LOAD

#Region "Funciones Locales"

#Region "Listar Orden de Compra"
    Private Sub ListarOC()
        With Entidad.OrdenCompra
            .Cod_Cia = Companhia
            .Aprobada = "0"
            .Fec_Crea = DtInicio.Value
            .Fec_Entrega = DtFin.Value
        End With
        dgvOC.DataSource = Negocio.OrdenCompraBL.ListarCabOrdenCompra(Entidad.OrdenCompra)
    End Sub
#End Region

#End Region   '   FUNCIONES LOCALES

#Region "Funciones Publicas"

#Region "Buscar"
    Public Sub Buscar()
        Call ListarOC()
    End Sub
#End Region

#Region "Actualizar"
    Public Sub Actualizar()
        Call ListarOC()
    End Sub
#End Region

#End Region  '   FUNCIONES PUBLICAS

#Region "Eventos Controles"

#End Region   '   EVENTOS CONTROLES

End Class