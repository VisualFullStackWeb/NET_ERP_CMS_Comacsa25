Imports System.Windows.Forms
Imports SIP_Negocio



Public Class RptActivoCriterios
#Region "Declaraciones"
    Private _IdPlanta As Int16 = 0
    Private _NomPlanta As String = ""
#End Region
#Region "Propiedades"
    Property IdPlanta()
        Get
            Return _IdPlanta
        End Get
        Set(ByVal value)
            _IdPlanta = value
        End Set
    End Property
    Property NomPlanta()
        Get
            Return _NomPlanta
        End Get
        Set(ByVal value)
            _NomPlanta = value
        End Set
    End Property
#End Region
    

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If CboPantasInternas.SelectedIndex = -1 Then
            MsgBox("Elija planta de producción", vbExclamation, "Verifique")
            Exit Sub
        End If
        _IdPlanta = Me.CboPantasInternas.SelectedValue
        _NomPlanta = Me.CboPantasInternas.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RptActivoCriterios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oDatos As New NGMaestros2

        CboPantasInternas.DataSource = oDatos.ListarPlantasInternasProduccion
        CboPantasInternas.DisplayMember = "descripcion"
        CboPantasInternas.ValueMember = "idPlanta"

    End Sub
End Class
