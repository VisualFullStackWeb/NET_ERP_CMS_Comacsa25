Imports SIP_Negocio
Imports SIP_Entidad
Imports Infragistics.Win.UltraWinGrid

Public Class FrmCiaEstablecimientos
    Friend Neg_CiaEstablecimiento As New NGCiaEstablecimiento
    Friend lst As New List(Of ETCiaEstablecimiento)
    Public uRow As UltraGridRow
#Region "Propiedades"
    Private _IdCodEstabField As String = String.Empty
    Public Property IdCodEstablecimiento() As String
        Get
            Return _IdCodEstabField
        End Get
        Set(ByVal value As String)
            _IdCodEstabField = value
        End Set
    End Property

    Private _Codigo_UbigeoField As String = String.Empty
    Public Property Codigo_Ubigeo_Establecimiento() As String
        Get
            Return _Codigo_UbigeoField
        End Get
        Set(ByVal value As String)
            _Codigo_UbigeoField = value
        End Set
    End Property

    Private _Nombre_UbigeoField As String = String.Empty
    Public Property Nombre_Ubigeo_Establecimiento() As String
        Get
            Return _Nombre_UbigeoField
        End Get
        Set(ByVal value As String)
            _Nombre_UbigeoField = value
        End Set
    End Property

#End Region


    Private Sub FrmCiaEstablecimientos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        lst = Nothing
    End Sub

    Private Sub FrmCiaEstablecimientos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lst = Neg_CiaEstablecimiento.ListarCiaEstablecimiento()
        udgCiaEstablecimiento.DataSource = lst
    End Sub

    Private Sub udgCiaEstablecimiento_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles udgCiaEstablecimiento.DoubleClickRow
        uRow = sender.ActiveRow
        'udgCiaEstablecimiento.Tag = Trim(uRow.Cells("IdCodEstab").Value) + " - " + Trim(uRow.Cells("denominacion").Value) + " - " + Trim(uRow.Cells("domicilio").Value) + " - " + uRow.Cells("nombre_ubigeo").Value '+ " - (" + uRow.Cells("IdUbigeoSunat").Value + ")"
        udgCiaEstablecimiento.Tag = Trim(uRow.Cells("denominacion").Value) + " - " + Trim(uRow.Cells("domicilio").Value) '+ " - " + uRow.Cells("nombre_ubigeo").Value '+ " - (" + uRow.Cells("IdUbigeoSunat").Value + ")"
        _IdCodEstabField = Trim(uRow.Cells("IdCodEstab").Value)
        _Codigo_UbigeoField = Trim(uRow.Cells("Codigo_Ubigeo").Value)
        _Nombre_UbigeoField = Trim(uRow.Cells("nombre_ubigeo").Value)

        Me.DialogResult = DialogResult.OK
        Close()
    End Sub


    Private Sub udgCiaEstablecimiento_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles udgCiaEstablecimiento.InitializeLayout
        With e.Layout.Bands(0)
            'e.Layout.Bands(0)
            .ColHeaderLines = 3
            'IdCodEstab,denominacion,domicilio,nombre_ubigeo,Codigo_Ubigeo

            .Columns("IdCodEstab").Header.Caption = "Cod. Establecimiento"
            .Columns("IdCodEstab").Width = 60

            .Columns("denominacion").Header.Caption = "Denominación Estab."
            .Columns("denominacion").Width = 100

            .Columns("domicilio").Header.Caption = "Domicilio"
            .Columns("domicilio").Width = 160

            .Columns("nombre_ubigeo").Header.Caption = "Ubigeo"
            .Columns("nombre_ubigeo").Width = 160

            .Columns("Codigo_Ubigeo").Header.Caption = "Cod. Ubigeo Sunat"
            .Columns("Codigo_Ubigeo").Width = 60

        End With
        'e.Layout.Bands(0).Columns("Periodo").Header.Caption = "1." + vbCrLf + "Periodo"
        'e.Layout.Bands(0).Columns("Periodo").Width = 60
    End Sub
End Class