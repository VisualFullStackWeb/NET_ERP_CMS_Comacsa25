Imports SIP_Entidad
Imports SIP_Datos

Public Class NGPersonal

    Public Function ConsultarPersonal1(ByVal Rpt As ETPersonal) As ETMyLista

        Dim lResult As ETMyLista

        lResult = New ETMyLista

        If Rpt IsNot Nothing Then
            lResult = Datos.Personal.ConsultarPersonal1(Rpt)
        End If

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function

    Public Function ConsultarPersonal2(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        lResult = New ETMyLista
        lResult = Datos.Personal.ConsultarPersonal2(Rpt)

        If lResult Is Nothing Then lResult = New ETMyLista

        Return lResult

    End Function


    'SIMAN
    Public Function ConsultarPersonal3(ByVal EntPers As ETPersonal) As ETMyLista

        Dim lResult As ETMyLista

        lResult = New ETMyLista

        lResult = Datos.Personal.ConsultarPersonal4(EntPers)

        If lResult Is Nothing Then lResult = New ETMyLista
        Return lResult

    End Function

    Public Function ConsultarPersonal4(ByVal EntPers As ETPersonal) As ETMyLista

        Dim lResult As ETMyLista

        lResult = New ETMyLista

        lResult = Datos.Personal.ConsultarPersonal5(EntPers)

        If lResult Is Nothing Then lResult = New ETMyLista
        Return lResult

    End Function

    Public Function Consultar_LineaProduccion_Personal(ByVal EntPers As ETPersonal) As ETMyLista

        Dim lResult As ETMyLista

        lResult = New ETMyLista

        lResult = Datos.Personal.ConsultarPersonal_LineaProduccion(EntPers)

        If lResult Is Nothing Then lResult = New ETMyLista
        Return lResult

    End Function

    Public Function ConsultarPersonal7(ByVal EntPers As ETPersonal) As ETMyLista

        Dim lResult As ETMyLista

        lResult = New ETMyLista

        lResult = Datos.Personal.ConsultarPersonal7(EntPers)

        If lResult Is Nothing Then lResult = New ETMyLista
        Return lResult

    End Function
End Class
