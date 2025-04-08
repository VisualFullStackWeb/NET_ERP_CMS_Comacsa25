Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmProveedores

    '   *****   Variables   *****
    Public Codigo As String = ""
    Public RazonSocial As String = ""
    Public Ruc As String = ""

#Region "Load"

#Region "Load"
    Private Sub FrmProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarProveedores()
    End Sub
#End Region

#End Region                'Load

#Region "Funciones Locales"

#Region "Listar Proveedores"
    Private Sub ListarProveedores()
        With Entidad.Usuario
            .Cod_Cia = Companhia
        End With
        dgvProveedores.DataSource = Negocio.Usuario.ListarProveedoresCia(Entidad.Usuario)
    End Sub
#End Region

#Region "Validar Nombre Corto"
    Private Function ValidarNombreCorto() As Boolean
        If TxtNombreCorto.Text = "" Then
            Return False
        End If

        Dim dtNombreCorto As New DataTable
        With Entidad.Requerimiento
            .Cod_Cia = Companhia
            .Nom_Prov = Trim(TxtNombreCorto.Text & "")
            .Cod_Prov = dgvProveedores.ActiveRow.Cells("Codigo").Value
        End With
        dtNombreCorto = Negocio.Requerimiento.ListarNombreCorto(Entidad.Requerimiento, "LIS")

        If dtNombreCorto.Rows.Count > 0 Then
            MsgBox("El Nombre Corto ya existe.", MsgBoxStyle.Critical, "Comacsa")
            Return False
        End If

        Return True
    End Function
#End Region

#End Region   'Funciones Locales

#Region "Evento Controles"

#Region "dgvProveedores - DoubleClickRow"
    Private Sub dgvProveedores_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvProveedores.DoubleClickRow
        If e Is Nothing Then Return
        If dgvProveedores.ActiveRow Is Nothing Then Return
        If dgvProveedores.Rows.Count > 0 Then
            Codigo = dgvProveedores.ActiveRow.Cells("Codigo").Value
            RazonSocial = dgvProveedores.ActiveRow.Cells("RazonSocial").Value
            Ruc = dgvProveedores.ActiveRow.Cells("Ruc").Value
            Me.Close()
        End If
    End Sub
#End Region

#Region "BtnGuardar - Click"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidarNombreCorto() = False Then Return

        With Entidad.Requerimiento
            .Cod_Cia = Companhia
            .Nom_Prov = Trim(TxtNombreCorto.Text & "")
            .Cod_Prov = dgvProveedores.ActiveRow.Cells("Codigo").Value
            .User_Crea = User_Sistema
        End With
        Negocio.Requerimiento.ListarNombreCorto(Entidad.Requerimiento, "UPD")
        MsgBox("Los datos se guardaron con éxito.", MsgBoxStyle.Information, "Comacsa")
        Call ListarProveedores()

    End Sub
#End Region

#End Region    'Evento Controles

End Class