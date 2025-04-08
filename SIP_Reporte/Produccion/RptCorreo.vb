Imports Microsoft
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Outlook
Imports Microsoft.Office.Interop.Outlook.OlItemType

Public Class RptCorreo

    Private oApp As Outlook.Application = Nothing
    Private oMsg As Outlook._MailItem = Nothing
    Private oAttachs As Attachments = Nothing
    Private oAttach As Attachment = Nothing

    Public Sub CargarCorreo(ByVal ObjCorreo As String(), _
                           ByVal ObjCC As String(), _
                           ByVal StrAsunto As String, _
                           ByVal strAdjunto As String, _
                           ByVal strCuerpo As String)

        oApp = New Outlook.Application

        oMsg = oApp.CreateItem(olMailItem)

        oMsg.Subject = StrAsunto

        oMsg.Body = strCuerpo

        'oMsg.To = ConvertObjtoStr(ObjCorreo)

        'oMsg.CC = ConvertObjtoStr(ObjCC)

        oAttachs = oMsg.Attachments

        oAttach = oAttachs.Add(strAdjunto, , 1, )

        oMsg.Display()

    End Sub

End Class
