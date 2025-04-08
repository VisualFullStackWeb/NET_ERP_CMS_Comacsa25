Imports SIP_Entidad
Imports SIP_Negocio

Public Class FrmListarCantera

    '   *****   VARIABLES   *****
    Public CODIGO As String = ""
    Public CANTERA As String = ""
    Public UBIGEO As String = ""
    Public CODIGOUBIGEO As String = ""
    Public FECHA As Date = Now.ToShortDateString
    Public FECHATERMINO As DateTime = Now
    Public PROVEEDOR As String = String.Empty
    Public ANIO As Integer = 0

#Region "Load"
    Private Sub FrmListarCantera_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With Entidad.EmpleoLabor
            .Cod_Cia = Companhia
            .Cod_Empleo = gEmpleo
            .Fecha = FECHA
            .FechaTermino = FECHATERMINO
            .Anio = ANIO
            .Cod_Prov = PROVEEDOR
        End With
        If xFormulario = "HoraMaquina" Or xFormulario = "Lista_Precio" Then
            DgvCantera.DataSource = Negocio.EmpleoLabor.ListarCantera(Entidad.EmpleoLabor, "CEQ")
        ElseIf xFormulario = "HoraDisponibleMaquina" Then
            DgvCantera.DataSource = Negocio.EmpleoLabor.ListarCantera(Entidad.EmpleoLabor, "DHE")
        ElseIf xFormulario = "Depreciacion_Equipo" Then
            DgvCantera.DataSource = Negocio.EmpleoLabor.ListarCantera(Entidad.EmpleoLabor, "EQU")
        ElseIf xFormulario = "Combustible_Explosivo" Or xFormulario = "UbicacionEquipo" _
            Or xFormulario = "Lista_Precio_Flete" Or xFormulario = "Lista_Precio_FletexMineral" _
            Or xFormulario = "Costo_Autorizacion" Or xFormulario = "VigenciaCantera" Then
            DgvCantera.DataSource = Negocio.EmpleoLabor.ListarCantera(Entidad.EmpleoLabor, "EXU")
        ElseIf xFormulario = "Cantera_Contratista" Then
            DgvCantera.DataSource = Negocio.EmpleoLabor.ListarCantera(Entidad.EmpleoLabor, "MCC")
        Else
            DgvCantera.DataSource = Negocio.EmpleoLabor.ListarCantera(Entidad.EmpleoLabor, "EXU")
        End If

    End Sub
#End Region                 'Load

#Region "Evento Controles"

#Region "DgvCantera - DoubleClickRow"
    Private Sub DgvCantera_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvCantera.DoubleClickRow
        CODIGO = e.Row.Cells("Codigo").Value
        CANTERA = e.Row.Cells("Cantera").Value
        UBIGEO = e.Row.Cells("Ubigeo").Value
        CODIGOUBIGEO = e.Row.Cells("CodigoUbigeo").Value
        gEmpleo = ""
        Close()
    End Sub
#End Region

#End Region     'Evento Controles

End Class