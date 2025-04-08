Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data


Public Class frmCReporteMinasVarios

    Public Ls_Permisos As New List(Of Integer)


    Private Enum rReporte
        rTareoEquipo = 1
        rTareoCombustible = 2
        rDetalleCosteoMineral_Toneladas = 3
        rConsumoCombustible = 4
    End Enum

    Private Enum iTipoCosteo
        TON_INGRESADOS_A_LA_PLANTA = 1
    End Enum

    Private TipoCosteoMineral As iTipoCosteo

    Private TipoReporte As rReporte
    Private Fecha1 As Date
    Private Fecha2 As Date

    Private Sub ChkFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkFecha.CheckedChanged
        Dtp1.ReadOnly = Not ChkFecha.Checked
        Dtp2.ReadOnly = Not ChkFecha.Checked
    End Sub

    Private Sub Rbn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rbn1.CheckedChanged, Rbn2.CheckedChanged, Rbn3.CheckedChanged, Rbn4.CheckedChanged
        If sender Is Rbn1 OrElse sender Is Rbn2 OrElse sender Is Rbn4 Then
            If sender.Checked = True Then
                If sender Is Rbn1 Then
                    TipoReporte = rReporte.rTareoEquipo
                ElseIf sender Is Rbn2 Then
                    TipoReporte = rReporte.rTareoCombustible
                Else
                    TipoReporte = rReporte.rConsumoCombustible
                End If
            End If

            Grb3.Enabled = sender.Checked
            ChkFecha.Checked = sender.Checked
            Cbo1.Enabled = True
            Cbo1.Value = "S/."
            Cbo1.Enabled = sender.Checked
            Grb4.Enabled = False
        End If

        If sender Is Rbn3 Then
            If sender.Checked = True Then
                TipoReporte = rReporte.rDetalleCosteoMineral_Toneladas
                TipoCosteoMineral = iTipoCosteo.TON_INGRESADOS_A_LA_PLANTA
            End If
            Grb3.Enabled = False
            Cbo1.Enabled = False
            Grb4.Enabled = sender.Checked
            Cbo2.Value = Now.Year
            Cbo3.Value = Now.Month
            Cbo4.Value = 1
        End If

    End Sub

    Private Sub Iniciar()
        Rbn1.Checked = True
        Dtp1.Value = Now
        Dtp2.Value = Now
        Call LlenarPeriodo()
    End Sub

    Sub LlenarPeriodo()
        Cbo2.Items.Clear()
        Dim i As Integer = 2010
        For i = 2010 To Year(Date.Now)
            Dim Dato As New Infragistics.Win.ValueListItem
            Dato.DisplayText = CStr(i)
            Dato.DataValue = CStr(i)
            Cbo2.Items.Add(Dato)
        Next
    End Sub

    Private Sub frmCReporteMinasVarios_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmCReporteMinasVarios_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)
    End Sub

    Private Sub frmCReporteMinasVarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Iniciar()
    End Sub

    Public Sub Reporte()
        Fecha1 = Dtp1.Value
        Fecha1 = Fecha1.Date

        Fecha2 = Dtp2.Value
        Fecha2 = Fecha2.Date
        Fecha2 = DateAdd(DateInterval.Day, 1, Fecha2)
        Fecha2 = DateAdd(DateInterval.Second, -1, Fecha2)

        Select Case TipoReporte
            Case rReporte.rTareoEquipo
                Call Reporte01()
            Case rReporte.rTareoCombustible
                Call Reporte02()
            Case rReporte.rDetalleCosteoMineral_Toneladas
                Call Reporte03()
            Case rReporte.rConsumoCombustible
                Call Reporte04()
        End Select
    End Sub

    Private Function CargarReporte01() As DataTable
        Dim lResult As New DataTable
        lResult = Negocio.ReportesBL.Minas_Reporte01(Companhia, Fecha1, Fecha2, Cbo1.Value)
        Return lResult
    End Function

    Private Function CargarReporte02() As DataTable
        Dim lResult As New DataTable
        lResult = Negocio.ReportesBL.Minas_Reporte02(Companhia, Fecha1, Fecha2, Cbo1.Value)
        Return lResult
    End Function

    Private Function CargarReporte03() As DataTable
        Dim lResult As New DataTable
        lResult = Negocio.ReportesBL.Minas_Reporte03(Companhia, Cbo2.Value, Cbo3.Value, Cbo4.Value, TipoCosteoMineral)
        Return lResult
    End Function

    Private Function CargarReporte04() As DataTable
        Dim lResult As New DataTable
        lResult = Negocio.ReportesBL.Minas_Reporte04(Companhia, Fecha1, Fecha2, Cbo1.Value)
        Return lResult
    End Function


    Private Sub Reporte01()
        StrucForm.FxRxReporte = New FrmBReporte

        Dim Ls_Parametro As New List(Of ETParametro)

        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@cod_cia"
            .Valor = Companhia
        End With
        Ls_Parametro.Add(Entidad.Parametro)

        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@FechaInicio"
            .Valor = Fecha1.ToString
        End With
        Ls_Parametro.Add(Entidad.Parametro)

        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@FechaTermino"
            .Valor = Fecha2.ToString
        End With
        Ls_Parametro.Add(Entidad.Parametro)

        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@Moneda"
            .Valor = Cbo1.Value
        End With
        Ls_Parametro.Add(Entidad.Parametro)

        StrucForm.FxRxReporte.NumReporte = VarReporte.DocumentoCrystal
        StrucForm.FxRxReporte.TextReporte = "REPORTE DE TAREO DE EQUIPOS DE MINAS"
        StrucForm.FxRxReporte.DatosReporte = CargarReporte01()
        StrucForm.FxRxReporte.Ls_ParametroCR = Ls_Parametro
        StrucForm.FxRxReporte.NombreReporteCR = RutaReporteERP & "RptERPMinas01.rpt"
        StrucForm.FxRxReporte.MdiParent = MdiParent
        StrucForm.FxRxReporte.Show()
    End Sub

    Private Sub Reporte02()
        StrucForm.FxRxReporte = New FrmBReporte

        Dim Ls_Parametro As New List(Of ETParametro)
        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@cod_cia"
            .Valor = Companhia
        End With
        Ls_Parametro.Add(Entidad.Parametro)

        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@FechaInicio"
            .Valor = Fecha1.ToString
        End With
        Ls_Parametro.Add(Entidad.Parametro)

        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@FechaTermino"
            .Valor = Fecha2.ToString
        End With
        Ls_Parametro.Add(Entidad.Parametro)

        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@Moneda"
            .Valor = Cbo1.Value
        End With
        Ls_Parametro.Add(Entidad.Parametro)

        StrucForm.FxRxReporte.NumReporte = VarReporte.DocumentoCrystal
        StrucForm.FxRxReporte.TextReporte = "REPORTE DE TAREO DE COMBUSTIBLE DE MINAS"
        StrucForm.FxRxReporte.DatosReporte = CargarReporte02()
        StrucForm.FxRxReporte.Ls_ParametroCR = Ls_Parametro
        StrucForm.FxRxReporte.NombreReporteCR = RutaReporteERP & "RptERPMinas02.rpt"
        StrucForm.FxRxReporte.MdiParent = MdiParent
        StrucForm.FxRxReporte.Show()
    End Sub

    Private Sub Reporte03()
        StrucForm.FxRxReporte = New FrmBReporte

        Dim Ls_Parametro As New List(Of ETParametro)
        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@Cod_Cia"
            .Valor = Companhia
        End With
        Ls_Parametro.Add(Entidad.Parametro)

        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@Informacion"
            .Valor = Cbo4.Value
        End With
        Ls_Parametro.Add(Entidad.Parametro)

        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@Ano"
            .Valor = Cbo2.Value
        End With
        Ls_Parametro.Add(Entidad.Parametro)

        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@Mes"
            .Valor = Cbo3.Value
        End With
        Ls_Parametro.Add(Entidad.Parametro)

        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@Opcion"
            .Valor = TipoCosteoMineral
        End With
        Ls_Parametro.Add(Entidad.Parametro)


        StrucForm.FxRxReporte.NumReporte = VarReporte.DocumentoCrystal
        StrucForm.FxRxReporte.TextReporte = "TON INGRESADOS A LA PLANTA POR CANTERA Y  MINERAL"
        StrucForm.FxRxReporte.DatosReporte = CargarReporte03()
        StrucForm.FxRxReporte.Ls_ParametroCR = Ls_Parametro
        StrucForm.FxRxReporte.NombreReporteCR = RutaReporteERP & "RptERPMinas03.rpt"
        StrucForm.FxRxReporte.MdiParent = MdiParent
        StrucForm.FxRxReporte.Show()
    End Sub

    Private Sub Reporte04()
        StrucForm.FxRxReporte = New FrmBReporte
        Dim Ls_Parametro As New List(Of ETParametro)
        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@cod_cia"
            .Valor = Companhia
        End With
        Ls_Parametro.Add(Entidad.Parametro)
        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@FechaInicio"
            .Valor = Fecha1.ToString
        End With
        Ls_Parametro.Add(Entidad.Parametro)
        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@FechaTermino"
            .Valor = Fecha2.ToString
        End With
        Ls_Parametro.Add(Entidad.Parametro)
        Entidad.Parametro = New ETParametro
        With Entidad.Parametro
            .Parametro = "@Moneda"
            .Valor = Cbo1.Value
        End With
        Ls_Parametro.Add(Entidad.Parametro)
        StrucForm.FxRxReporte.NumReporte = VarReporte.DocumentoCrystal
        StrucForm.FxRxReporte.TextReporte = "REPORTE DE CONSUMO DE COMBUSTIBLE DE MINAS"
        StrucForm.FxRxReporte.DatosReporte = CargarReporte04()
        StrucForm.FxRxReporte.Ls_ParametroCR = Ls_Parametro
        StrucForm.FxRxReporte.NombreReporteCR = RutaReporteERP & "RptERPMinas04.rpt"
        StrucForm.FxRxReporte.MdiParent = MdiParent
        StrucForm.FxRxReporte.Show()
    End Sub

    Private Sub Cbo2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo2.ValueChanged
        Call LlenarMeses(Cbo3, Cbo2.Value, Date.Now.Month)
    End Sub
End Class