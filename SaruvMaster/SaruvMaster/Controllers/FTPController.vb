Imports System.Web.Mvc
Imports System.IO
Imports System.Net
Imports Microsoft.AspNet.Identity.Owin

Namespace Controllers
    Public Class FTPController
        Inherits Controller
        Dim db As New Connection
        Private _userManager As ApplicationUserManager
        Public Property UserManager() As ApplicationUserManager
            Get
                Return If(_userManager, HttpContext.GetOwinContext().GetUserManager(Of ApplicationUserManager)())
            End Get
            Private Set(value As ApplicationUserManager)
                _userManager = value
            End Set
        End Property

        ' GET: FTP
        Function Index() As ActionResult
            Return View()
        End Function


        <HttpPost>
        Public Function Upload(file2 As HttpPostedFileBase) As ActionResult
            'Dim file1 = Path.GetFullPath(file2.FileName)
            'Dim c = 0

            Dim user = "a8250648"
            Dim pass = "base_datos"
            'Dim splitted() As String = Split(file1, "\")
            'Dim fileName = splitted(splitted.Length - 1)
            'Dim pasdas = file2.FileName
            'Dim request As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create("ftp://torneo-web.hostei.com/" + fileName), System.Net.FtpWebRequest)
            'request.Credentials = New System.Net.NetworkCredential(user, pass)
            'request.Method = System.Net.WebRequestMethods.Ftp.UploadFile
            'Dim ruta = "C:\Users\Francisco\Documents\ArchivosSARUV\" + fileName
            'Dim ftp = "ftp://torneo-web.hostei.com/FRANCISCO"
            'Dim result = FtpDirectoryExists(ftp, user, pass)

            'Dim file() As Byte = System.IO.File.ReadAllBytes("C:\Users\Francisco\Documents\ArchivosSARUV\" + fileName)

            'Dim strz As System.IO.Stream = request.GetRequestStream()
            'strz.Write(file, 0, file.Length)
            'strz.Close()
            'strz.Dispose()
            Dim uploadurl = "ftp://ftp.adress.com/"
            Dim uploadfilename = file2.FileName
            Dim username = "ftpusername"
            Dim password = "ftppassword"
            Dim streamObj As Stream = file2.InputStream
            Dim buffer As Byte() = New Byte(file2.ContentLength - 1) {}
            streamObj.Read(buffer, 0, buffer.Length)
            streamObj.Close()
            streamObj = Nothing
            Dim ftpurl = "ftp://torneo-web.hostei.com/" + file2.FileName
            Dim requestObj = TryCast(FtpWebRequest.Create(ftpurl), FtpWebRequest)
            requestObj.Method = WebRequestMethods.Ftp.UploadFile
            requestObj.Credentials = New NetworkCredential(user, pass)
            Dim requestStream As Stream = requestObj.GetRequestStream()
            requestStream.Write(buffer, 0, buffer.Length)
            requestStream.Flush()
            requestStream.Close()
            requestObj = Nothing

            '=======================================================
            'Service provided by Telerik (www.telerik.com)
            'Conversion powered by NRefactory.
            'Twitter: @telerik
            'Facebook: facebook.com/telerik
            '=======================================================



            Return RedirectToAction("#")
        End Function


        <HttpPost>
        Public Function download(ByVal id As Integer?) As ActionResult
            Dim usuario = UserManager.Users.Where(Function(u) u.UserName = User.Identity.Name).First()
            Dim recurso = db.Recurso.Where(Function(m) m.Id = 1).First().Nombre


            'Dim file1 = file_textBox.Text
            Dim c = 0

            'Dim splitted() As String = Split(file1, "\")
            ' Dim fileName = splitted(splitted.Length - 1)

            Dim oFTP As FtpWebRequest = CType(FtpWebRequest.Create("ftp://torneo-web.hostei.com/" + recurso + ".txt"), FtpWebRequest)
            oFTP.Credentials = New NetworkCredential("a8250648", "base_datos")
            oFTP.Method = WebRequestMethods.Ftp.DownloadFile
            oFTP.KeepAlive = True
            ' oFTP.EnableSsl = UseSSL
            ' If UseSSL Then ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf ValidateServerCertificate)
            oFTP.UseBinary = True
            Dim response As FtpWebResponse = CType(oFTP.GetResponse, FtpWebResponse)
            Dim responseStream As Stream = response.GetResponseStream

            Dim fs As New FileStream("C:\Users\Francisco\Documents\" + recurso + ".txt", FileMode.Create)

            Dim buffer(2047) As Byte
            Dim read As Integer = 1
            While read <> 0
                read = responseStream.Read(buffer, 0, buffer.Length)
                fs.Write(buffer, 0, read)
            End While
            responseStream.Close()
            fs.Flush()
            fs.Close()
            responseStream.Close()
            response.Close()
            oFTP = Nothing
            Return RedirectToAction("#")
        End Function


        Public Function FtpDirectoryExists(directoryPath As String, ftpUser As String, ftpPassword As String) As Boolean
            Dim IsExists As Boolean = True
            Try
                Dim request As FtpWebRequest = DirectCast(WebRequest.Create(directoryPath), FtpWebRequest)
                request.Credentials = New NetworkCredential(ftpUser, ftpPassword)
                request.Method = WebRequestMethods.Ftp.PrintWorkingDirectory

                Dim response As FtpWebResponse = DirectCast(request.GetResponse(), FtpWebResponse)
            Catch ex As WebException
                IsExists = False
            End Try
            Return IsExists
        End Function

        '=======================================================
        'Service provided by Telerik (www.telerik.com)
        'Conversion powered by NRefactory.
        'Twitter: @telerik
        'Facebook: facebook.com/telerik
        '=======================================================

    End Class

End Namespace