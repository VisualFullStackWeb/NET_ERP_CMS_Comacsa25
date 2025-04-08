Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports SIP_Entidad
Imports SIP_Negocio

Public Class frmPOTRecursosDetalle
#Region "Declarar Varibles"
    Public Enum Recursos
        Material = 1
        Equipo = 2
        ManoObra = 3
        Servicio = 4
    End Enum
    Public TipoRecurso As Recursos

    Private _OrdenTrabajo As Long = 0
    Private _Status As String = "P"
    Private Ls_OT_Costo_Detalle As List(Of ETOTRecursoDetalle) = Nothing
#End Region

#Region "Propiedades Publicas"
    Public Property OrdenTrabajo() As Long
        Get
            Return _OrdenTrabajo
        End Get
        Set(ByVal value As Long)
            _OrdenTrabajo = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
#End Region

#Region "Formulario"
    Private Sub frmPOTRecursosDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Texto As String = String.Empty
        Dim Costo As Double = 0

        Select Case TipoRecurso
            Case Recursos.Material
                Texto = "COSTO DE MATERIALES"
            Case Recursos.Equipo
                Texto = "COSTO DE EQUIPOS"
            Case Recursos.ManoObra
                Texto = "COSTO DE MANO DE OBRA"
            Case Else
                Texto = "COSTO DE SERVICIOS"
        End Select

        Me.Text = ".::: " & Texto & " :::."

        Call CargarRecurso()

        For Each Row As ETOTRecursoDetalle In Ls_OT_Costo_Detalle
            Costo = Costo + Row.SubTotal
        Next

        Me.Grb1.Text = Texto & Space(25 - Len(Texto.Trim)) & ": " & Costo.ToString("n4")

    End Sub
#End Region

#Region "Procedimientos Privados"
    Private Sub CargarRecurso()
        Ls_OT_Costo_Detalle = New List(Of ETOTRecursoDetalle)
        Entidad.OrdenTrabajo.OrdenTrabajo = Me.OrdenTrabajo
        Entidad.OrdenTrabajo.Tipo = TipoRecurso
        Entidad.OrdenTrabajo.Status = Status
        Entidad.MyLista = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_Costos_Detalle(Entidad.OrdenTrabajo)
        If Entidad.MyLista.Validacion Then
            Ls_OT_Costo_Detalle = Entidad.MyLista.Ls_OrdenTrabajo_RecursosDetalle
        End If

        Call CargarUltraGrid(Grid1, Ls_OT_Costo_Detalle)
    End Sub
#End Region
   
#Region "Grilla"
    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout

        For Each UColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If UColumn.Key = "Descripcion" Then
                Select Case TipoRecurso
                    Case Recursos.Material
                        UColumn.Header.Caption = "Material"
                    Case Recursos.Equipo
                        UColumn.Header.Caption = "Equipo"
                    Case Recursos.ManoObra
                        UColumn.Header.Caption = "Personal"
                    Case Else
                        UColumn.Header.Caption = "Servicio"
                End Select
            End If
        Next
    End Sub
#End Region
    
End Class