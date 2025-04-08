Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class frmCConsutarComprobantePagoUnidProd
    Private _Cod_Prov As String = String.Empty
    Private _Proveedor As String = String.Empty
    Private _Codigo As String = String.Empty
    Private _Descripcion As String = String.Empty
    Private _FechaInicio As DateTime = Date.Today
    Private _FechaTermino As DateTime = Date.Today
    Private _Tipo_Doc As String = String.Empty
    Private _Num_Doc As String = String.Empty
    Private _Importe As Double = 0
    Private Contador As Integer = 0
    Private _Ls_Documentos As New List(Of ETPeriodoDetalle)
    Private _Ls_Documentos_Temp As New List(Of ETPeriodoDetalle)
    Private _VisibleCheck As Boolean = Boolean.TrueString


#Region "Propiedades"
    Public Property VisibleCheck() As Boolean
        Get
            Return _VisibleCheck
        End Get
        Set(ByVal value As Boolean)
            _VisibleCheck = value
        End Set
    End Property

    Public Property Ls_Documentos() As List(Of ETPeriodoDetalle)
        Get
            Return _Ls_Documentos
        End Get
        Set(ByVal value As List(Of ETPeriodoDetalle))
            _Ls_Documentos = value
        End Set
    End Property

    Public Property Cod_Prov() As String
        Get
            Return _Cod_Prov
        End Get
        Set(ByVal value As String)
            _Cod_Prov = value
        End Set
    End Property

    Public Property Proveedor() As String
        Get
            Return _Proveedor
        End Get
        Set(ByVal value As String)
            _Proveedor = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property FechaInicio() As DateTime
        Get
            Return _FechaInicio
        End Get
        Set(ByVal value As DateTime)
            _FechaInicio = value
        End Set
    End Property

    Public Property FechaTermino() As DateTime
        Get
            Return _FechaTermino
        End Get
        Set(ByVal value As DateTime)
            _FechaTermino = value
        End Set
    End Property

    Public Property Tipo_Doc() As String
        Get
            Return _Tipo_Doc
        End Get
        Set(ByVal value As String)
            _Tipo_Doc = value
        End Set
    End Property

    Public Property Num_Doc() As String
        Get
            Return _Num_Doc
        End Get
        Set(ByVal value As String)
            _Num_Doc = value
        End Set
    End Property

    Public Property Importe() As Double
        Get
            Return _Importe
        End Get
        Set(ByVal value As Double)
            _Importe = value
        End Set
    End Property
#End Region

    Public Sub CargarDocumentos()
        Entidad.PeriodoDetalle = New ETPeriodoDetalle
        With Entidad.PeriodoDetalle
            .Tipo = IIf(Rbt2.Checked = True, "1", "2")
            .Tipo_Doc = Tipo_Doc
            .Cod_Prov = Cod_Prov
            .FechaInicio = Dtp1.Value 'FechaInicio
            .FechaTermino = Dtp2.Value 'FechaTermino
        End With

        Dim ds As DataSet
        Negocio.PeriodoCosteo = New NGPeriodoCosteo
        ds = Negocio.PeriodoCosteo.ConsultarPeriodoCosteo_ComprobantePago(Entidad.PeriodoDetalle)
        Call CargarUltraGrid(Grid1, ds)

    End Sub

    Public Sub VerDocumentos()
        Call CargarUltraGrid(Grid1, Ls_Documentos)
    End Sub

    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        Call CargarDocumentos()
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        If Grid1.Rows.Count <= 0 Then
            MsgBox("No hay Documentos a Seleccionar", MsgBoxStyle.Critical, msgComacsa)
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

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        Grid1.Update()
        Grid1.UpdateData()
        If Grid1.Rows.Count > 0 Then
            For Each xRow As UltraGridRow In Grid1.Rows
                If xRow.Cells("Action").Value = True Then
                    Entidad.PeriodoDetalle = New ETPeriodoDetalle
                    With Entidad.PeriodoDetalle
                        .Action = True
                        .Tipo = 1
                        .Codigo = Codigo
                        .Cod_Prov = Cod_Prov
                        .Tipo_Doc = xRow.Cells("Tipo_Doc").Value
                        .Tipo_Doc_Name = xRow.Cells("Tipo_Doc_Name").Value
                        .Num_Doc = xRow.Cells("Num_Doc").Value
                        .Fecha_Doc = xRow.Cells("Fecha_Doc").Value
                        .Fecha_Proc = xRow.Cells("Fecha_Proc").Value
                        .Total = xRow.Cells("Total").Value
                        .IGV = xRow.Cells("IGV").Value
                        .Importe = xRow.Cells("Importe").Value
                        .Usuario = User_Sistema
                    End With
                    _Ls_Documentos.Add(Entidad.PeriodoDetalle)
                End If
            Next
        End If

        Me.Close()
    End Sub

    Private Sub Grid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid1.DoubleClick
        If e Is Nothing Then Exit Sub
        If Grid1.Rows.Count <= 0 Then Exit Sub
        If Grid1.ActiveRow Is Nothing Then Exit Sub

        If Lbl2.Visible = False Then
            Num_Doc = Grid1.ActiveRow.Cells("Num_Doc").Value
            Importe = Grid1.ActiveRow.Cells("Importe").Value
            Me.Close()
        End If

    End Sub

    Private Sub Grid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Grid1.InitializeLayout
        If e Is Nothing Then
            Exit Sub
        End If

        If VisibleCheck = False Then
            For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (xCol.Key = "Tipo_Doc_Name" _
                    OrElse xCol.Key = "Num_Doc" OrElse xCol.Key = "Total" _
                    OrElse xCol.Key = "IGV" OrElse xCol.Key = "Importe" _
                    OrElse xCol.Key = "Fecha_Doc" OrElse xCol.Key = "Fecha_Proc") Then
                    xCol.Hidden = True
                Else
                    xCol.Hidden = False
                End If
            Next
        Else
            For Each xCol As UltraGridColumn In e.Layout.Bands(0).Columns
                If Not (xCol.Key = "Action" OrElse xCol.Key = "Tipo_Doc_Name" _
                    OrElse xCol.Key = "Num_Doc" OrElse xCol.Key = "Total" _
                    OrElse xCol.Key = "IGV" OrElse xCol.Key = "Importe" _
                    OrElse xCol.Key = "Fecha_Doc" OrElse xCol.Key = "Fecha_Proc") Then
                    xCol.Hidden = True
                Else
                    xCol.Hidden = False
                End If
            Next

        End If
       

    End Sub

    Private Sub frmCConsutarComprobantePagoUnidProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        Grid1.Update()
        Grid1.UpdateData()
        _Ls_Documentos_Temp = Nothing
        _Ls_Documentos_Temp = New List(Of ETPeriodoDetalle)
        If Grid1.Rows.Count > 0 Then
            For Each xRow As UltraGridRow In Grid1.Rows
                If xRow.Cells("Action").Value = True Then
                    Entidad.PeriodoDetalle = New ETPeriodoDetalle
                    With Entidad.PeriodoDetalle
                        .Action = True
                        .Tipo = 1
                        .Codigo = Codigo
                        .Cod_Prov = Cod_Prov
                        .Tipo_Doc = xRow.Cells("Tipo_Doc").Value
                        .Tipo_Doc_Name = xRow.Cells("Tipo_Doc_Name").Value
                        .Num_Doc = xRow.Cells("Num_Doc").Value
                        .Fecha_Doc = xRow.Cells("Fecha_Doc").Value
                        .Fecha_Proc = xRow.Cells("Fecha_Proc").Value
                        .Total = xRow.Cells("Total").Value
                        .IGV = xRow.Cells("IGV").Value
                        .Importe = xRow.Cells("Importe").Value
                        .Usuario = User_Sistema
                    End With
                    _Ls_Documentos_Temp.Add(Entidad.PeriodoDetalle)
                End If
            Next

            Ls_Documentos = Nothing
            Ls_Documentos = New List(Of ETPeriodoDetalle)
            Ls_Documentos = _Ls_Documentos_Temp
        End If

        Me.Close()
    End Sub
End Class