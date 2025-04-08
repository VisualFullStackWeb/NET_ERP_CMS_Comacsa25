Imports SIP_Entidad
Imports SIP_Negocio
Public Class frmListarNroGuia
    Private _ID As Integer = 0
    Private _PlaCod As String = String.Empty
    Private DT_Personal As DataSet
    Private _Faltas As New List(Of ETPersonal)
    Private _Formulario As String = String.Empty

    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Public Property PlaCod() As String
        Get
            Return _PlaCod
        End Get
        Set(ByVal value As String)
            _PlaCod = value
        End Set
    End Property
    Public Property Formulario() As String
        Get
            Return _Formulario
        End Get
        Set(ByVal value As String)
            _Formulario = value
        End Set
    End Property
    Public Property Faltas() As List(Of ETPersonal)
        Get
            Return _Faltas
        End Get
        Set(ByVal value As List(Of ETPersonal))
            _Faltas = value
        End Set
    End Property
    Private Sub Iniciar()
        Entidad.CanteraCosteo = New ETCanteraCosteo
        With Entidad.CanteraCosteo
            .CodCia = Companhia
            .ID = ID.ToString
            .CodEmpleado = PlaCod
        End With

        Negocio.CanteraCosteo = New NGCanteraCosteo
        If Formulario = "111" Then
            DT_Personal = Negocio.CanteraCosteo.Consultar_Cantera_Contratista_Personal_Faltas(Entidad.CanteraCosteo)
        ElseIf Formulario = "112" Then
            DT_Personal = Negocio.CanteraCosteo.Consultar_Cantera_Contratista_Personal_Guia(Entidad.CanteraCosteo)
        End If

        Call CargarUltraGrid(Grid1, DT_Personal)
    End Sub

    Private Sub frmListarNroGuia_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim DT As New DataTable
        Dim DS As New DataSet
        Grid1.Update()
        Grid1.UpdateData()
        DS = Grid1.DataSource
        If DS IsNot Nothing Then
            DT = DS.Tables(0)

        End If
       
        If DT IsNot Nothing Then
            If DT.Rows.Count > 0 Then
                For Each xRow As DataRow In DT.Rows
                    If xRow.Item("Action") = True Then
                        Entidad.Personal = New ETPersonal
                        With Entidad.Personal
                            .CodPersonal = PlaCod
                            .Serie_Guia = xRow.Item("Serie")
                            .Nro_Guia = xRow.Item("NroGuia")
                        End With

                        _Faltas.Add(Entidad.Personal)
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub frmListarNroGuia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Iniciar()
        Me.CenterToScreen()
    End Sub
End Class