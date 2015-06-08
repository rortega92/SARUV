Imports System.Web.Mvc
Imports System.IO
Imports System.Net

Namespace Controllers
    Public Class FTPController
        Inherits Controller

        ' GET: FTP
        Function Index() As ActionResult
            Return View()
        End Function


        <HttpPost>
        Public Function Upload(file2 As HttpPostedFileBase) As ActionResult

            Dim fileName = Path.GetFullPath(file2.FileName)
            Path.GetFullPath(file2.FileName)
            Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://torneo-web.hostei.com/" + fileName), System.Net.FtpWebRequest)
            request.Credentials = New System.Net.NetworkCredential("a8250648", "base_datos")
            request.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            Dim file() As Byte = System.IO.File.ReadAllBytes("C:\Users\Francisco\Documents\ArchivosSARUV\" + file2.FileName)

            Dim strz As System.IO.Stream = request.GetRequestStream()
            strz.Write(file, 0, file.Length)
            strz.Close()
            strz.Dispose()
            Return RedirectToAction("#")
        End Function


        <HttpGet>
        Public Function download() As ActionResult

            Dim db As New Connection
            Dim list = From m In db.RecursoPorUsuario
                       Select m

            list = list.Where()
            Dim items As IEnumerable(Of SelectListItem) = db.RecursoPorUsuario.Select(Function(c) New SelectListItem() With {
    .Value = c..ToString(),
    .Text = c.CategoryName
})
            ViewBag.CategoryID = items
            Return RedirectToAction("#")
        End Function
    End Class
End Namespace