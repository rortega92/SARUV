Imports System.Web.Mvc
Imports System.IO
Imports System.Net
Imports Microsoft.AspNet.Identity.Owin
Imports System.Data.SqlClient
Imports SaruvMaster.SaruvMaster

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
        Public Function Upload(file2 As HttpPostedFileBase, ByVal recursoId As Integer, ByVal tipo As Integer) As ActionResult
            'Dim file1 = Path.GetFullPath(file2.FileName)
            'Dim c = 0
            Try


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

                Dim myFtpWebResponse As System.Net.FtpWebResponse
                Dim uploadurl = "ftp://ftp.adress.com/"
                Dim splitted() As String = Split(file2.FileName, ".")
                Dim fileName = splitted(0) + "_" + DateTime.Now.Ticks.ToString() + "." + splitted(splitted.Length - 1)
                Dim uploadfilename = fileName
                Dim username = "ftpusername"
                Dim password = "ftppassword"


                Dim streamObj As Stream = file2.InputStream
                Dim buffer As Byte() = New Byte(file2.ContentLength - 1) {}
                streamObj.Read(buffer, 0, buffer.Length)
                streamObj.Close()
                streamObj = Nothing
                Dim ftpurl = "ftp://torneo-web.hostei.com/" + fileName
                Dim requestObj = TryCast(FtpWebRequest.Create(ftpurl), FtpWebRequest)


                requestObj.Method = WebRequestMethods.Ftp.UploadFile
                requestObj.Credentials = New NetworkCredential(user, pass)
                myFtpWebResponse = requestObj.GetResponse()
                Console.Write(myFtpWebResponse.StatusCode)
                Dim requestStream As Stream = requestObj.GetRequestStream()
                requestStream.Write(buffer, 0, buffer.Length)
                requestStream.Flush()
                requestStream.Close()


                If myFtpWebResponse.StatusCode.Equals(FtpStatusCode.ClosingData) Then
                    'aqui se muestra toast de correcto'
                    Console.Write("listo")
                End If
                requestObj = Nothing
                insertArchivo(fileName, tipo, recursoId)



            Catch ex As Exception
                'aqui se muestra toast que ocurrio un problema'
                Console.Write(ex.ToString)
            End Try

            Return RedirectToAction("Index", "PersonalUV")
        End Function


        <HttpPost>
        Public Function download(ByVal archivoId As Integer) As ActionResult


            Dim usuario = UserManager.Users.Where(Function(u) u.UserName = User.Identity.Name).First()
            Dim archivo = db.UserFile.Where(Function(m) m.ID = archivoId).First().NombreArchivo

            'Dim file1 = file_textBox.Text
            Dim c = 0

            'Dim splitted() As String = Split(file1, "\")
            ' Dim fileName = splitted(splitted.Length - 1)

            Dim oFTP As FtpWebRequest = CType(FtpWebRequest.Create("ftp://torneo-web.hostei.com/" + archivo), FtpWebRequest)
            oFTP.Credentials = New NetworkCredential("a8250648", "base_datos")
            oFTP.Method = WebRequestMethods.Ftp.DownloadFile
            oFTP.KeepAlive = True
            ' oFTP.EnableSsl = UseSSL
            ' If UseSSL Then ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf ValidateServerCertificate)
            oFTP.UseBinary = True
            Dim response As FtpWebResponse = CType(oFTP.GetResponse, FtpWebResponse)
            Dim responseStream As Stream = response.GetResponseStream
            If (response.StatusCode.Equals(FtpStatusCode.OpeningData)) Then
                Console.Write(response)
            End If

            'Dim fs As New FileStream("C:\Users\Francisco\Documents\" + recurso + ".txt", FileMode.Create)

            'Dim buffer(2047) As Byte
            'Dim read As Integer = 1
            'While read <> 0
            '    read = responseStream.Read(buffer, 0, buffer.Length)
            '    fs.Write(buffer, 0, read)
            'End While
            'responseStream.Close()
            'fs.Flush()
            'fs.Close()
            'responseStream.Close()
            'response.Close()
            'oFTP = Nothing

            Return File(responseStream, System.Net.Mime.MediaTypeNames.Application.Octet, archivo)

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


        Function insertArchivo(ByVal nombre As String, ByVal tipo As Integer, ByVal recursoID As Integer)
            Dim con As New Connection
            Dim cone = New SqlConnection(con.Database.Connection.ConnectionString)
            Dim cmd = New SqlCommand()
            cone.Open()
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.CommandText = "ArchivoUsuario_Insert"
            Dim parm = New SqlParameter()
            parm.ParameterName = "@NombreArchivo"
            parm.Value = nombre
            cmd.Parameters.Add(parm)
            Dim parm1 = New SqlParameter()
            parm1.ParameterName = "@TipoArchivo"
            parm1.Value = tipo
            cmd.Parameters.Add(parm1)
            Dim parm2 = New SqlParameter()
            parm2.ParameterName = "@RecursoID"
            parm2.Value = recursoID
            cmd.Parameters.Add(parm2)
            Dim parm3 = New SqlParameter()
            parm3.ParameterName = "@FechaCreacion"
            parm3.Value = DateTime.Now
            cmd.Parameters.Add(parm3)
            Dim parm4 = New SqlParameter()
            parm4.ParameterName = "@FechaModificacion"
            parm4.Value = DateTime.Now
            cmd.Parameters.Add(parm4)
            cmd.Connection = cone
            Dim res = cmd.ExecuteNonQuery()
            cone.Close()
            Dim row As New Dictionary(Of String, String)
            row.Add("inserted", res.Equals(1))
            Return Json(row, JsonRequestBehavior.AllowGet)
        End Function

        Function getArchivosByRecursoId(ByVal recursoId As Integer) As ActionResult
            Dim archivos = db.UserFile.Where(Function(a) a.RecursoID = recursoId).ToList()
            Dim returnArchivos As New List(Of Dictionary(Of String, String))
            For i As Integer = 0 To archivos.ToArray().Length - 1
                Dim row As New Dictionary(Of String, String)
                row.Add("ID", archivos.ElementAt(i).ID)
                row.Add("NombreArchivo", archivos.ElementAt(i).NombreArchivo)
                row.Add("TipoArchivo", archivos.ElementAt(i).TipoArchivo)
                row.Add("RecursoID", archivos.ElementAt(i).RecursoID)
                returnArchivos.Add(row)
            Next
            Return Json(returnArchivos, JsonRequestBehavior.AllowGet)
        End Function


        Public Function delete(ByVal archivoId As Integer) As ActionResult
            Try
                Dim user = "a8250648"
                Dim pass = "base_datos"
                Dim archivo = db.UserFile.Where(Function(m) m.ID = archivoId).First().NombreArchivo
                Dim ftpRequest As FtpWebRequest = DirectCast(WebRequest.Create("ftp://torneo-web.hostei.com/" + archivo), FtpWebRequest)

                ftpRequest.Credentials = New NetworkCredential(user, pass)


                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile
                Dim responseFileDelete As FtpWebResponse = DirectCast(ftpRequest.GetResponse(), FtpWebResponse)
               
                If (responseFileDelete.StatusCode.Equals(FtpStatusCode.FileActionOK)) Then
                    'toate de todo buen'
                    Console.Write("listo")
                End If
                deleteArchivo(archivoId)

            Catch ex As Exception
                'toast de que ocurrio un error'
            End Try
            Return RedirectToAction("Index", "PersonalUV")
        End Function
        Function deleteArchivo(ByVal archivoId As Integer)
            Dim con As New Connection
            Dim cone = New SqlConnection(con.Database.Connection.ConnectionString)
            Dim cmd = New SqlCommand()
            cone.Open()
            cmd.CommandType = System.Data.CommandType.StoredProcedure
            cmd.CommandText = "ArchivoUsuario_Delete"
            Dim parm = New SqlParameter()
            parm.ParameterName = "@ID"
            parm.Value = archivoId
            cmd.Parameters.Add(parm)
            cmd.Connection = cone
            Dim res = cmd.ExecuteNonQuery()
            cone.Close()
            Dim row As New Dictionary(Of String, String)
            row.Add("deleted", res.Equals(1))
            Return Json(row, JsonRequestBehavior.AllowGet)
        End Function
    End Class

End Namespace