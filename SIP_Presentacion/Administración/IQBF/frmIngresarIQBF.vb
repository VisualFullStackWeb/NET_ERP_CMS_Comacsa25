Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class frmIngresarIQBF
    Public tipo As String
    Public ayo As Int32
    Public mes As Int32
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If tipo = "INGRESO" Then
            GrabaIngreso()
        ElseIf tipo = "EGRESO" Then
            GrabaEgreso()
        ElseIf tipo = "PRODUCCION" Then
            GrabaProduccion()
        ElseIf tipo = "USO" Then
            GrabaUso()
        End If
        Me.Close()
    End Sub

    Sub GrabaIngreso()
        Try
            Dim dtDatos As New DataTable
            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            With oPrvFisE
                .año = Year(dtFecha.Value)
                .mes = Month(dtFecha.Value)
                .Observacion = Txtobservacion.Text
                .Fecha = dtFecha.Value
                .Presentacion = cmbPresentacion.Text
                .tipo_mov = IIf(rdbNacional.Checked = True, "01", "02")
                .TipoDoc = tipo
            End With
            dtDatos = oPrvFisN.IngresaIQBF(oPrvFisE)
        Catch ex As Exception

        End Try
    End Sub


    Sub GrabaEgreso()
        Try
            Dim dtDatos As New DataTable
            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            With oPrvFisE
                .año = Year(dtFecha.Value)
                .mes = Month(dtFecha.Value)
                .Observacion = Txtobservacion.Text
                .Fecha = dtFecha.Value
                .Presentacion = cmbPresentacion.Text
                .tipo_mov = IIf(rdbNacional.Checked = True, "N", "E")
                .TipoDoc = tipo
            End With
            dtDatos = oPrvFisN.IngresaIQBF(oPrvFisE)
        Catch ex As Exception

        End Try
    End Sub

    Sub GrabaProduccion()
        Try
            Dim dtDatos As New DataTable
            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            With oPrvFisE
                .año = Year(dtFecha.Value)
                .mes = Month(dtFecha.Value)
                .Observacion = Txtobservacion.Text
                .Fecha = dtFecha.Value
                .Presentacion = cmbPresentacion.Text
                If rdbEgreso.Checked = True Then
                    .tipo_mov = "E"
                ElseIf rdbRecirculado.Checked = True Then
                    .tipo_mov = "R"
                ElseIf rdbProduccion.Checked = True Then
                    .tipo_mov = "P"
                End If
                '.tipo_mov = IIf(rdbNacional.Checked = True, "N", "E")
                .TipoDoc = tipo
            End With
            dtDatos = oPrvFisN.IngresaIQBF(oPrvFisE)
        Catch ex As Exception

        End Try
    End Sub

    Sub GrabaUso()
        Try
            Dim dtDatos As New DataTable
            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            With oPrvFisE
                .año = Year(dtFecha.Value)
                .mes = Month(dtFecha.Value)
                .Observacion = Txtobservacion.Text
                .Fecha = dtFecha.Value
                .Presentacion = cmbPresentacion.Text
                .tipo_mov = ""
                .TipoDoc = tipo
            End With
            dtDatos = oPrvFisN.IngresaIQBF(oPrvFisE)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmIngresarIQBF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtFecha.Value = "01/" + mes.ToString + "/" + ayo.ToString
        rdbNacional.Checked = True
        rdbNacional.Visible = False : rdbExterior.Visible = False
        If tipo = "INGRESO" Then
            rdbNacional.Visible = True : rdbExterior.Visible = True
        ElseIf tipo = "EGRESO" Then
            rdbNacional.Visible = True : rdbExterior.Visible = True
            Txtobservacion.Text = "ENTREGA DEL PRODUCTO AL CLIENTE EN NUESTRO ESTABLECIMIENTO"
        ElseIf tipo = "PRODUCCION" Then
            rdbEgreso.Visible = True : rdbRecirculado.Visible = True : rdbProduccion.Visible = True
            rdbEgreso.Checked = True
        ElseIf tipo = "USO" Then
            Txtobservacion.Text = "USO EN LABORATORIO PARA ANALISIS"
        End If
        cargaPresentacion()
    End Sub
    Sub cargaPresentacion()
        Try
            Dim dtDatos As New DataTable
            Dim oPrvFisN As NGProveedorFiscalizado = Nothing
            Dim oPrvFisE As ETProveedorFiscalizado = Nothing
            oPrvFisN = New NGProveedorFiscalizado
            oPrvFisE = New ETProveedorFiscalizado
            With oPrvFisE
                .año = Year(dtFecha.Value)
                .TipoDoc = tipo
            End With
            dtDatos = oPrvFisN.PresentacionIQBF(oPrvFisE)
            cmbPresentacion.DataSource = dtDatos
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPresentacion_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbPresentacion.InitializeLayout
        With cmbPresentacion.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("Presentacion").Width = sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "Presentacion") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub rdbRecirculado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbRecirculado.CheckedChanged
        If rdbRecirculado.Checked = True Then
            Txtobservacion.Text = "RECIRCULADO A PRODUCCION POR ROTURA DE ENVASE"
        End If
    End Sub

    Private Sub rdbEgreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbEgreso.CheckedChanged
        If rdbEgreso.Checked = True Then
            Txtobservacion.Text = ""
        End If
    End Sub

    Private Sub rdbProduccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbProduccion.CheckedChanged
        If rdbProduccion.Checked = True Then
            Txtobservacion.Text = ""
        End If
    End Sub
End Class