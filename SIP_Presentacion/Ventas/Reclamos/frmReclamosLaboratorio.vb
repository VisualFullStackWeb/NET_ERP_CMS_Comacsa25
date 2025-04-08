Imports SIP_Entidad
Imports SIP_Negocio

Public Class frmReclamosLaboratorio

    Private Sub frmReclamosLaboratorio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MyBase.Laboratorio = True

        'For Each itemTab As Infragistics.Win.UltraWinTabControl.UltraTab In tabTipoReclamo.Tabs
        '    If itemTab.Key = "TT04" Then
        '        itemTab.Visible = True
        '    Else
        '        itemTab.Visible = False
        '    End If

        '    If itemTab.Key = "TT08" Or itemTab.Key = "TT09" Then
        '        If User_Sistema = "JPMEDINA" Or User_Sistema = "MARROQUI" Or User_Sistema = "VCARLIN" Or User_Sistema = "SA" Then
        '            itemTab.Visible = True
        '        Else
        '            itemTab.Visible = False
        '        End If
        '    End If
        'Next



    End Sub

    'Public Overrides Sub CargarDatos(ByVal pReclamo As SIP_Entidad.ETReclamo)
    '    MyBase.CargarDatos(pReclamo)
    '    MyBase.DesBloquearPaneles(False)

    '    MyBase.grpLaboratorio.Enabled = True
    'End Sub

    Public Overrides Sub BuscarListadoReclamos()

        If dtpBusFechaInicio.Value Is Nothing OrElse dtpBusFechaFin.Value Is Nothing Then
            MsgBox("Fechas Inválidas para la busqueda", MsgBoxStyle.OkOnly, msgComacsa)
            Return
        End If

        Try
            Dim pReclamo As New ETReclamo
            pReclamo.ClienteCodigo = txtBusquedaCliente.Text.Trim()
            pReclamo.FechaFin = dtpBusFechaFin.Value
            pReclamo.Fecha = dtpBusFechaInicio.Value

            'If User_Sistema = "SA" Or User_Sistema = "MARROQUI" Or User_Sistema = "VCARLIN" Then
            '    LISTA_SOURCE = NReclamo.ListarReclamos(pReclamo, "TODOS")
            'Else
            '    LISTA_SOURCE = NReclamo.ListarReclamos(pReclamo, "LABORATORIO")
            'End If
            LISTA_SOURCE = NReclamo.ListarReclamos(pReclamo, "TODOS")

            ugPrincipal.DataSource = LISTA_SOURCE
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, msgComacsa)
        End Try

    End Sub
End Class
