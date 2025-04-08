Imports SIP_Entidad
Imports SIP_Negocio


Public Class FrmEnvioCanteras

    '   *****   LISTAS      ******
    Public LstDetEnvio As New List(Of ETLst_EnvioCantera)
    Dim Envio As ETLst_EnvioCantera

#Region "Load"
    Private Sub FrmEnvioCanteras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Entidad.Guia
            .Cod_Cia = Companhia
            .Cod_Cantera = GR_CodigoCantera
            .Cod_Cli = GR_CodigoRazonSocialDestinatario
        End With
        dgvBilletesPendientes.DataSource = Negocio.Guia.ListarBilletesEnvioCantera(Entidad.Guia)
    End Sub
#End Region                '   Load

#Region "Evento Controles"

#Region "btnGuardar - Click"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim xInt As Integer = 0
        For b As Integer = 0 To dgvBilletesPendientes.Rows.Count - 1
            If dgvBilletesPendientes.Rows(b).Cells("Action").Value = 1 Then
                xInt = xInt + 1
            End If
        Next


        If dgvBilletesPendientes.Rows.Count = 0 Or xInt = 0 Then
            MsgBox("Debe hay elementos para guardar.", MsgBoxStyle.Critical, "Comacsa")
            Return

        Else
            Dim EnvioCantera As New DataTable
            For i As Integer = 0 To dgvBilletesPendientes.Rows.Count - 1
                If dgvBilletesPendientes.Rows(i).Cells("Action").Value = 1 Then
                    With Entidad.Guia
                        .Cod_Cia = Companhia
                        .Cod_Alm = gAlmacen
                        .NumDoc = dgvBilletesPendientes.Rows(i).Cells("numdoc").Value
                    End With
                    EnvioCantera = Negocio.Guia.ListarSalidaTransferenciaCantera(Entidad.Guia)

                    For j As Integer = 0 To EnvioCantera.Rows.Count - 1
                        Envio = New ETLst_EnvioCantera
                        With Envio
                            .NroBillete = dgvBilletesPendientes.Rows(i).Cells("numdoc").Value
                            .Codigo = EnvioCantera.Rows(j).Item("Codigo")
                            .Descripcion = EnvioCantera.Rows(j).Item("Descripcion")
                            .UM = EnvioCantera.Rows(j).Item("UM")
                            .Stock = EnvioCantera.Rows(j).Item("Stock")
                            .TipoProducto = EnvioCantera.Rows(j).Item("TipoProducto")
                            .OrdenCompra = EnvioCantera.Rows(j).Item("OrdenCompra")
                            .Cantidad = EnvioCantera.Rows(j).Item("Cantidad")
                        End With
                        LstDetEnvio.Add(Envio)
                    Next
                End If
            Next
            Me.Close()
        End If
    End Sub
#End Region

#Region "btnCerrar - Click"
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
#End Region

#End Region    '   Evento Controles

End Class