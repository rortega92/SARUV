Imports System.Web.Mvc
Imports System.IO

Namespace Controllers
    Public Class FTPController
        Inherits Controller

        ' GET: FTP
        Function Index() As ActionResult
            Return View()
        End Function


        <HttpPost> _
        Public Function Upload(file As HttpPostedFileBase) As ActionResult

            If file IsNot Nothing AndAlso file.ContentLength > 0 Then
                Dim path = System.IO.Path.GetFullPath(file.FileName)
                Dim myFtpWebRequest As System.Net.FtpWebRequest
                Dim myFtpWebResponse As System.Net.FtpWebResponse
                Dim myStreamWriter As System.IO.StreamWriter
                Dim file1 = Path
                Dim c = 0

                Dim splitted() As String = Split(file1, "\")
                Dim fileName = splitted(splitted.Length - 1)


                myFtpWebRequest = System.Net.WebRequest.Create("ftp://torneo-web.hostei.com/" + fileName)

                myFtpWebRequest.Credentials = New System.Net.NetworkCredential("a8250648", "base_datos")

                myFtpWebRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
                myFtpWebRequest.UseBinary = True

                myStreamWriter = New System.IO.StreamWriter(myFtpWebRequest.GetRequestStream())
                myStreamWriter.Write(New System.IO.StreamReader(file.InputStream, True).ReadToEnd)
                myStreamWriter.Close()

                myFtpWebResponse = myFtpWebRequest.GetResponse()

                JavaScript(myFtpWebResponse.StatusDescription)

                myFtpWebResponse.Close()
            End If

            Return RedirectToAction("#")
        End Function
    End Class
End Namespace