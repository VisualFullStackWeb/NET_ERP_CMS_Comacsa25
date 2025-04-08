Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmListarEmpleoLabor

    '   *****   VARIABLES   *****
    Public CODIGO As String = ""
    Public EMPLEO As String = ""
    Public EmpleoLabor As New List(Of ETEmpleoLabor)
    Dim Labor As ETEmpleoLabor
    Public EmpleadoTerceros As String = ""

#Region "Load"
    Private Sub FrmListarEmpleoLabor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Entidad.EmpleoLabor = New ETEmpleoLabor
        Negocio.EmpleoLabor = New NGEmpleoLabor

        With Entidad.EmpleoLabor
            .Cod_Cia = Companhia
            .Cod_Area = gArea
        End With
        If EmpleadoTerceros = "" Then
            DgvEmpleoLabor.DataSource = Negocio.EmpleoLabor.ListarEmpleoLabor(Entidad.EmpleoLabor, "LT2")
        Else
            Entidad.EmpleoLabor.Cod_Prov = EmpleadoTerceros
            DgvEmpleoLabor.DataSource = Negocio.EmpleoLabor.ListarEmpleoLabor(Entidad.EmpleoLabor, "LT4")
            UltraLabel4.Text = "LISTA DE PERSONAL"
            Me.Text = "LISTA DE PERSONAL"
        End If

    End Sub
#End Region                'Load

#Region "Eventos Controles"

#Region "Grilla DgvEmpleoLabor DoubleClickRow "
    Private Sub DgvEmpleoLabor_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvEmpleoLabor.DoubleClickRow
        Labor = New ETEmpleoLabor
        With Labor
            .Cod_Empleo = e.Row.Cells("Codigo").Value
            .Descripcion = e.Row.Cells("Empleo").Value
            EmpleoLabor.Add(Labor)
        End With

        CODIGO = e.Row.Cells("Codigo").Value
        EMPLEO = e.Row.Cells("Empleo").Value
        Close()
    End Sub
#End Region

#End Region   'Eventos Controles

    
    Private Sub DgvEmpleoLabor_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DgvEmpleoLabor.InitializeLayout
        If Not (String.IsNullOrEmpty(EmpleadoTerceros.Trim)) Then
            For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
                If xCol.Key = "Empleo" Then
                    xCol.Header.Caption = "Personal"
                End If
            Next
        End If
    End Sub
End Class