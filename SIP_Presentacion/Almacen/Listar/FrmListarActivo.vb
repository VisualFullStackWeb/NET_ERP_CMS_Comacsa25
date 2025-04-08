Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmListarActivo

    '   *****   VARIABLES   *****
    Public CODIGO As String = ""
    Public ACTIVO As String = ""
    Public PROVEEDOR As String = ""
    Public FECHAINICIO As Date = Date.Today
    Public FECHATERMINO As DateTime = Now

#Region "Load"

    Private Sub FrmListarActivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Entidad.EmpleoLabor
            .Cod_Cia = Companhia
            .Cod_Empleo = gEmpleo
            .Cod_Linea = GLinea
            .Cod_Cantera = GCantera
            .Cod_Prov = PROVEEDOR
            .Fecha = FECHAINICIO
            .FechaTermino = FECHATERMINO
        End With

        If xFormulario = "UbicacionEquipo" Then
            DgvActivo.DataSource = Negocio.EmpleoLabor.ListarActivo(Entidad.EmpleoLabor, "MLA")
        ElseIf xFormulario = "Combustible_Explosivo" Or xFormulario = "HoraMaquina" Or xFormulario = "Depreciacion_Equipo" Or xFormulario = "Movimientos" Then
            DgvActivo.DataSource = Negocio.EmpleoLabor.ListarActivo(Entidad.EmpleoLabor, "EQU")
        ElseIf xFormulario = "HoraDisponibleMaquina" Then
            DgvActivo.DataSource = Negocio.EmpleoLabor.ListarActivo(Entidad.EmpleoLabor, "DHE")
        ElseIf xFormulario = "Lista_Precio" Then
            DgvActivo.DataSource = Negocio.EmpleoLabor.ListarActivo(Entidad.EmpleoLabor, "AME")
        Else
            DgvActivo.DataSource = Negocio.EmpleoLabor.ListarActivo(Entidad.EmpleoLabor, "LIS")
        End If
    End Sub

#End Region                '   Load

#Region "Evento Controles"

#Region "DgvActivo - DoubleClickRow"
    Private Sub DgvActivo_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvActivo.DoubleClickRow
        CODIGO = e.Row.Cells("Codigo").Value
        ACTIVO = e.Row.Cells("Modelo").Value
        gEmpleo = ""
        Close()
    End Sub
#End Region

#End Region    '   Evento Controles

End Class