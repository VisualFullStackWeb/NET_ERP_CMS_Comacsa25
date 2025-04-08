Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmDatosGuia

    '   *****   VARIABLES   *****
    Public CodigoRazonSocialTransportista = ""
    Public RazonSocialTransportista As String = ""
    Public RucTransportista As String = ""
    Public Marca As String = ""
    Public Placa As String = ""
    Public CertificadoInscripcion As String = ""
    Public Licencia As String = ""
    Public NombreChofer As String = ""
    Dim dt_Transportista As New DataTable

#Region "Funciones Locales"

#Region "ListarContratista"
    Private Sub ListarContratista()
        With Entidad.Guia
            .Cod_Cia = Companhia
        End With
        CboRazonSocial.DataSource = Negocio.Guia.Listar_GR_Contratista(Entidad.Guia, "DC2")
        CboRazonSocial.ValueMember = "Codigo"
        CboRazonSocial.DisplayMember = "RazonSocial"
    End Sub
#End Region

#End Region   '   Funciones Locales

#Region "Load"
    Private Sub FrmDatosGuia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarContratista()
        TxtCodigoCantera.Text = GR_CodigoCantera
        TxtCantera.Text = GR_Cantera
        TxtDireccion.Text = GR_Direccion
        TxtUbicacionGeografica.Text = GR_UbicacionGeografica
        CboRazonSocial.Value = GR_CodigoRazonSocialDestinatario
        TxtRuc.Text = GR_RucDestinatario
        TxtDNI.Text = GR_DniDestinatario
        TxtEnviado.Text = GR_Enviado
        TxtCodigoTransportista.Text = GR_CodigoRazonSocialTransportista
        TxtTransportista.Text = GR_RazonSocialTransportista
        TxtRUCTransportista.Text = GR_RucTransportista
        TxtMarca.Text = GR_Marca
        TxtPlaca.Text = GR_Placa
        TxtCertificado.Text = GR_CertificadoInscripcion
        TxtLincencia.Text = GR_Licencia
        TxtNombreChofer.Text = GR_NombreChofer
    End Sub
#End Region                '   Load

#Region "Evento Controles"

#Region "BtnTransportista_Click"
    Private Sub BtnTransportista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTransportista.Click
        Dim Transportista As New FrmProveedores
        Transportista.ShowDialog()
        TxtCodigoTransportista.Text = Transportista.Codigo
        TxtTransportista.Text = Transportista.RazonSocial
        TxtRuc.Text = Transportista.Ruc

    End Sub
#End Region

#Region "TxtCodigoTransportista - KeyPress"
    Private Sub TxtCodigoTransportista_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoTransportista.KeyPress
        Select Case e.KeyChar
            Case "13"
                With Entidad.Requerimiento
                    .Cod_Prov = TxtCodigoTransportista.Text
                    .Cod_Cia = Companhia
                End With
                dt_Transportista = Negocio.Requerimiento.ListarNombreCorto(Entidad.Requerimiento, "LXP")


                If dt_Transportista.Rows.Count > 0 Then
                    TxtCodigoTransportista = dt_Transportista.Rows(0).Item("Codigo")
                    TxtTransportista.Text = dt_Transportista.Rows(0).Item("RazonSocial")
                    TxtRUCTransportista.Text = dt_Transportista.Rows(0).Item("Ruc")
                Else
                    MsgBox("No hay Transportista con este codigo: " & TxtCodigoTransportista.Text, MsgBoxStyle.Critical, "Comacsa")
                    TxtCodigoTransportista.Clear()
                    TxtTransportista.Clear()
                    TxtRUCTransportista.Clear()

                    Return
                End If

        End Select
    End Sub
#End Region

#Region "TxtCodigoTransportista - ValueChanged"
    Private Sub TxtCodigoTransportista_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodigoTransportista.ValueChanged
        If Len(TxtCodigoTransportista.Text) <> 6 Then
            TxtTransportista.Clear()
            TxtRUCTransportista.Clear()
        End If
    End Sub
#End Region

#Region "btnGuardar - Click"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        CodigoRazonSocialTransportista = Trim(TxtCodigoTransportista.Text & "")
        RazonSocialTransportista = Trim(TxtTransportista.Text & "")
        RucTransportista = Trim(TxtRUCTransportista.Text & "")
        Marca = Trim(TxtMarca.Text & "")
        Placa = Trim(TxtPlaca.Text & "")
        CertificadoInscripcion = Trim(TxtCertificado.Text & "")
        Licencia = Trim(TxtLincencia.Text & "")
        NombreChofer = Trim(TxtNombreChofer.Text & "")
        Me.Close()
    End Sub
#End Region

#Region "btnCerrar - Click"
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
#End Region

#End Region    '   Evento Controles

End Class