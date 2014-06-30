Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Collections.Specialized


Module Module1

    Private token As String = ""
    Private deviceId As String = ""
    Private title As String = ""
    Private body As String = ""
    Private url As String = ""
    Private name As String = ""
    Private address As String = ""
    Private filePath As String = ""
    Private folderPath As String = ""
    Private mime As String = ""
    Private items As String()

    Sub Main(ByVal args() As String)

        Dim i As Integer = 0

        If IsOdd(args.Length) = False Then
            For i = 0 To args.Length - 1 Step 2

                If args(i).StartsWith("/") Then
                    'Console.WriteLine("Arg: " & args(i) & " is " & args(i + 1))
                    Select Case args(i)
                        Case "/k"
                            token = args(i + 1)
                        Case "/d"
                            deviceId = args(i + 1)
                        Case "/n"
                            If args(i + 1).Split("+").Length = 2 Then
                                title = args(i + 1).Split("+")(0)
                                body = args(i + 1).Split("+")(1)
                                If token.Length > 0 And deviceId.Length > 0 And title.Length > 0 And body.Length > 0 Then
                                    Try
                                        Dim wc As WebClient = New WebClient
                                        Dim authEncoded As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(token & ":"))

                                        wc.Headers(HttpRequestHeader.Authorization) = String.Format("Basic {0}", authEncoded)
                                        wc.Headers(HttpRequestHeader.ContentType) = "application/json"
                                        wc.Headers(HttpRequestHeader.Accept) = "application/json"

                                        Dim strJson = New JObject( _
                                                        New JProperty("type", "note"), _
                                                        New JProperty("device_iden", deviceId), _
                                                        New JProperty("title", title), _
                                                        New JProperty("body", body) _
                                                        )

                                        wc.UploadString("https://api.pushbullet.com/v2/pushes", strJson.ToString)
                                        'Dim wp As WebProxy = New WebProxy("127.0.0.1:8888")
                                        'wc.Proxy = wp
                                        wc.Dispose()
                                    Catch ex As Exception
                                        Console.WriteLine(ex.Message)
                                        Exit Sub
                                    End Try
                                Else
                                    Console.WriteLine("Uncorrect parameter for " & args(i) & " command")
                                End If
                            Else
                                Console.WriteLine("Uncorrect parameter for " & args(i) & " command")
                            End If
                        Case "/l"
                            If args(i + 1).Split("+").Length = 3 Then
                                title = args(i + 1).Split("+")(0)
                                url = args(i + 1).Split("+")(1)
                                body = args(i + 1).Split("+")(2)
                                If token.Length > 0 And deviceId.Length > 0 And title.Length > 0 And body.Length > 0 And url.Length > 0 Then
                                    Try
                                        Dim wc As WebClient = New WebClient
                                        Dim authEncoded As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(token & ":"))

                                        wc.Headers(HttpRequestHeader.Authorization) = String.Format("Basic {0}", authEncoded)
                                        wc.Headers(HttpRequestHeader.ContentType) = "application/json"
                                        wc.Headers(HttpRequestHeader.Accept) = "application/json"

                                        Dim strJson = New JObject( _
                                                        New JProperty("type", "link"), _
                                                        New JProperty("device_iden", deviceId), _
                                                        New JProperty("title", title), _
                                                        New JProperty("url", url), _
                                                        New JProperty("body", body) _
                                                        )

                                        wc.UploadString("https://api.pushbullet.com/v2/pushes", strJson.ToString)
                                        wc.Dispose()
                                    Catch ex As Exception
                                        Console.WriteLine(ex.Message)
                                        Exit Sub
                                    End Try
                                Else
                                    Console.WriteLine("Uncorrect parameter for " & args(i) & " command")
                                End If
                            Else
                                Console.WriteLine("Uncorrect parameter for " & args(i) & " command")
                            End If
                        Case "/a"
                            If args(i + 1).Split("+").Length = 2 Then
                                name = args(i + 1).Split("+")(0)
                                address = args(i + 1).Split("+")(1)
                                If token.Length > 0 And deviceId.Length > 0 And name.Length > 0 And address.Length > 0 Then
                                    Try
                                        Dim wc As WebClient = New WebClient
                                        Dim authEncoded As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(token & ":"))

                                        wc.Headers(HttpRequestHeader.Authorization) = String.Format("Basic {0}", authEncoded)
                                        wc.Headers(HttpRequestHeader.ContentType) = "application/json"
                                        wc.Headers(HttpRequestHeader.Accept) = "application/json"

                                        Dim strJson = New JObject( _
                                                        New JProperty("type", "address"), _
                                                        New JProperty("device_iden", deviceId), _
                                                        New JProperty("name", name), _
                                                        New JProperty("address", address)
                                                        )

                                        wc.UploadString("https://api.pushbullet.com/v2/pushes", strJson.ToString)
                                        wc.Dispose()
                                    Catch ex As Exception
                                        Console.WriteLine(ex.Message)
                                        Exit Sub
                                    End Try
                                Else
                                    Console.WriteLine("Uncorrect parameter for " & args(i) & " command")
                                End If
                            Else
                                Console.WriteLine("Uncorrect parameter for " & args(i) & " command")
                            End If
                        Case "/u"
                            If args(i + 1).Split("+").Length = 2 Then
                                title = args(i + 1).Split("+")(0)
                                items = args(i + 1).Split("+")(1).Split(",")
                                If token.Length > 0 And deviceId.Length > 0 And title.Length > 0 And items.Length > 0 Then
                                    Try
                                        Dim wc As WebClient = New WebClient
                                        Dim authEncoded As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(token & ":"))

                                        wc.Headers(HttpRequestHeader.Authorization) = String.Format("Basic {0}", authEncoded)
                                        wc.Headers(HttpRequestHeader.ContentType) = "application/json"
                                        wc.Headers(HttpRequestHeader.Accept) = "application/json"

                                        Dim param As String() = New String() {"item1", "item2", "item3"}

                                        Dim strJson = New JObject( _
                                                        New JProperty("type", "list"), _
                                                        New JProperty("device_iden", deviceId), _
                                                        New JProperty("title", "titolo"), _
                                                        New JProperty("items", items) _
                                                        )

                                        wc.UploadString("https://api.pushbullet.com/v2/pushes", strJson.ToString)

                                        wc.Dispose()
                                        'Console.WriteLine(strJson.ToString)
                                    Catch ex As Exception
                                        Console.WriteLine(ex.Message)
                                        Exit Sub
                                    End Try
                                Else
                                    Console.WriteLine("Uncorrect parameter for " & args(i) & " command")
                                End If
                            Else
                                Console.WriteLine("Uncorrect parameter for " & args(i) & " command")
                            End If
                        Case "/f"
                            If args(i + 1).Split("+").Length = 3 Then
                                filePath = args(i + 1).Split("+")(0)
                                mime = args(i + 1).Split("+")(1)
                                body = args(i + 1).Split("+")(2)
                                If File.Exists(filePath) = False Then Console.WriteLine("File not found in " & filePath)
                                If body.Length = 0 Then Console.WriteLine("Please add body or empty string "" " & filePath)

                                If token.Length > 0 And deviceId.Length > 0 And File.Exists(filePath) = True And mime.Length > 0 Then
                                    Dim wc As WebClient = New WebClient
                                    Dim authEncoded As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(token & ":"))

                                    wc.Headers(HttpRequestHeader.Authorization) = String.Format("Basic {0}", authEncoded)
                                    wc.Headers(HttpRequestHeader.ContentType) = "application/x-www-form-urlencoded"
                                    wc.Headers(HttpRequestHeader.Accept) = "application/json"

                                    Dim param As String
                                    param = "type=file&"
                                    param &= "device_iden=" & deviceId & "&"
                                    param &= "file_name=" & Path.GetFileName(filePath) & "&"
                                    param &= "file_type=" & mime
                                    Dim retStr As String = ""
                                    Try
                                        retStr = wc.DownloadString("https://api.pushbullet.com/v2/upload-request?" & param)
                                    Catch ex As Exception
                                        Console.WriteLine(ex.Message)
                                        Exit Sub
                                    End Try

                                    Dim json As JObject = JsonConvert.DeserializeObject(retStr)
                                    Dim file_type As String = json("file_type").ToString
                                    Dim file_name As String = json("file_name").ToString
                                    Dim upload_url As String = json("upload_url").ToString
                                    Dim file_url As String = json("file_url").ToString
                                    Dim awsaccesskeyid As String = json("data")("awsaccesskeyid").ToString
                                    Dim acl As String = json("data")("acl").ToString
                                    Dim key As String = json("data")("key").ToString
                                    Dim signature As String = json("data")("signature").ToString
                                    Dim policy As String = json("data")("policy").ToString
                                    Dim contentType As String = json("data")("content-type").ToString

                                    Dim form As NameValueCollection = New NameValueCollection()
                                    form.Add("awsaccesskeyid", awsaccesskeyid)
                                    form.Add("acl", acl)
                                    form.Add("key", key)
                                    form.Add("signature", signature)
                                    form.Add("policy", policy)
                                    form.Add("content-type", contentType)

                                    Dim response As String = HttpUploadFile(upload_url, filePath, "file", mime, form)

                                    If response = "" Then
                                        Try
                                            wc.Headers.Clear()
                                            wc.Headers(HttpRequestHeader.Authorization) = String.Format("Basic {0}", authEncoded)
                                            wc.Headers(HttpRequestHeader.ContentType) = "application/json"
                                            wc.Headers(HttpRequestHeader.Accept) = "application/json"

                                            Dim strJson = New JObject( _
                                                            New JProperty("type", "file"), _
                                                            New JProperty("device_iden", deviceId), _
                                                            New JProperty("file_name", file_name), _
                                                            New JProperty("file_type", file_type), _
                                                            New JProperty("file_url", file_url), _
                                                            New JProperty("body", "" & body) _
                                                            )

                                            wc.UploadString("https://api.pushbullet.com/v2/pushes", strJson.ToString)

                                            wc.Dispose()
                                            Console.WriteLine(strJson.ToString)
                                        Catch ex As Exception
                                            Console.WriteLine(ex.Message)
                                            Exit Sub
                                        End Try
                                    End If
                                Else
                                    Console.WriteLine("Uncorrect parameter for " & args(i) & " command")
                                End If
                            Else
                                Console.WriteLine("Uncorrect parameter for " & args(i) & " command")
                            End If
                        Case "/list"
                            Try
                                Dim wc As WebClient = New WebClient
                                Dim authEncoded As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(token & ":"))

                                wc.Headers(HttpRequestHeader.Authorization) = String.Format("Basic {0}", authEncoded)
                                wc.Headers(HttpRequestHeader.ContentType) = "application/x-www-form-urlencoded"
                                wc.Headers(HttpRequestHeader.Accept) = "application/json"

                                Dim retStr As String = wc.DownloadString("https://api.pushbullet.com/v2/devices")
                                Dim json As JObject = JsonConvert.DeserializeObject(retStr)
                                Dim devices As String = json("devices").ToString
                                Console.WriteLine(devices)
                                wc.Dispose()
                            Catch ex As Exception
                                Console.WriteLine(ex.Message)
                            End Try
                        Case "/ispy"
                            If args(i + 1).Split("+").Length = 2 Then
                                folderPath = args(i + 1).Split("+")(0)
                                body = args(i + 1).Split("+")(1)
                                filePath = getLastFileImage(folderPath)
                                If Directory.Exists(folderPath) = False Then Console.WriteLine("Directory not found in " & folderPath)
                                If File.Exists(filePath) = False Then Console.WriteLine("No files in directory " & folderPath)

                                If token.Length > 0 And deviceId.Length > 0 And Directory.Exists(folderPath) = True _
                                    And body.Length > 0 And File.Exists(filePath) = True Then

                                    Dim wc As WebClient = New WebClient
                                    Dim authEncoded As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(token & ":"))

                                    wc.Headers(HttpRequestHeader.Authorization) = String.Format("Basic {0}", authEncoded)
                                    wc.Headers(HttpRequestHeader.ContentType) = "application/x-www-form-urlencoded"
                                    wc.Headers(HttpRequestHeader.Accept) = "application/json"

                                    Dim param As String
                                    param = "type=file&"
                                    param &= "device_iden=" & deviceId & "&"
                                    param &= "file_name=" & Path.GetFileName(filePath) & "&"
                                    param &= "file_type=image/jpeg"
                                    Dim retStr As String = ""
                                    Try
                                        retStr = wc.DownloadString("https://api.pushbullet.com/v2/upload-request?" & param)
                                    Catch ex As Exception
                                        Console.WriteLine(ex.Message)
                                        Exit Sub
                                    End Try

                                    Dim json As JObject = JsonConvert.DeserializeObject(retStr)
                                    Dim file_type As String = json("file_type").ToString
                                    Dim file_name As String = json("file_name").ToString
                                    Dim upload_url As String = json("upload_url").ToString
                                    Dim file_url As String = json("file_url").ToString
                                    Dim awsaccesskeyid As String = json("data")("awsaccesskeyid").ToString
                                    Dim acl As String = json("data")("acl").ToString
                                    Dim key As String = json("data")("key").ToString
                                    Dim signature As String = json("data")("signature").ToString
                                    Dim policy As String = json("data")("policy").ToString
                                    Dim contentType As String = json("data")("content-type").ToString

                                    Dim form As NameValueCollection = New NameValueCollection()
                                    form.Add("awsaccesskeyid", awsaccesskeyid)
                                    form.Add("acl", acl)
                                    form.Add("key", key)
                                    form.Add("signature", signature)
                                    form.Add("policy", policy)
                                    form.Add("content-type", contentType)

                                    Dim response As String = HttpUploadFile(upload_url, filePath, "file", "image/jpeg", form)

                                    If response = "" Then
                                        Try
                                            wc.Headers.Clear()
                                            wc.Headers(HttpRequestHeader.Authorization) = String.Format("Basic {0}", authEncoded)
                                            wc.Headers(HttpRequestHeader.ContentType) = "application/json"
                                            wc.Headers(HttpRequestHeader.Accept) = "application/json"

                                            Dim strJson = New JObject( _
                                                            New JProperty("file_type", file_type), _
                                                            New JProperty("device_iden", deviceId), _
                                                            New JProperty("file_name", file_name), _
                                                            New JProperty("file_url", file_url), _
                                                            New JProperty("body", "" & body), _
                                                            New JProperty("type", "file") _
                                                            )

                                            wc.UploadString("https://api.pushbullet.com/v2/pushes", strJson.ToString)

                                            wc.Dispose()
                                            Console.WriteLine(strJson.ToString)
                                        Catch ex As Exception
                                            Console.WriteLine(ex.Message)
                                            Exit Sub
                                        End Try
                                    End If
                                Else
                                    Console.WriteLine("Uncorrect parameter for " & args(i) & " command")
                                End If
                            Else
                                Console.WriteLine("Uncorrect parameter for " & args(i) & " command")
                            End If
                        Case Else
                            Console.WriteLine(args(i) & " command not implemented")
                    End Select

                Else
                    Console.WriteLine("Argument must start with / and parameter need to be enclosed in """)
                End If
            Next
        Else
            If args(0) = "/?" Then
                Console.WriteLine(vbCrLf & "SINTAX" & vbCrLf & vbCrLf)
                Console.WriteLine(vbTab & "note")
                Console.WriteLine(vbTab & vbTab & "pushBullet.exe /k [Token] /d [device_id] /n [""title""+""body""]" & vbCrLf)
                Console.WriteLine(vbTab & "link")
                Console.WriteLine(vbTab & vbTab & "pushBullet.exe /k [Token] /d [device_id] /l [""title""+""url""+""body""]" & vbCrLf)
                Console.WriteLine(vbTab & "address")
                Console.WriteLine(vbTab & vbTab & "pushBullet.exe /k [Token] /d [device_id] /a [""name""+""address""]" & vbCrLf)
                Console.WriteLine(vbTab & "list")
                Console.WriteLine(vbTab & vbTab & "pushBullet.exe /k [Token] /d [device_id] /u [""title""+""item1"",""item2"",""item3""....]" & vbCrLf)
                Console.WriteLine(vbTab & "file")
                Console.WriteLine(vbTab & vbTab & "pushBullet.exe /k [Token] /d [device_id] /f [""fileAbsolutePath""+""mime""+""body""]" & vbCrLf)
                Console.WriteLine(vbTab & "ispy")
                Console.WriteLine(vbTab & "This option post to pushbullet the last accessed jpg file in folderSearch")
                Console.WriteLine(vbTab & vbTab & "pushBullet.exe /k [Token] /d [device_id] /ispy [""folderSearch""+""body""]" & vbCrLf)
                Console.WriteLine(vbTab & "list devices")
                Console.WriteLine(vbTab & vbTab & "pushBullet.exe /k [Token] /list all" & vbCrLf & vbCrLf)
                Console.WriteLine("Do not write ""["" ""]"". You can find ""Device_id"" string using command /list all at the property ""iden""" & vbCrLf)
            Else
                Console.WriteLine("Unrecognized parameter")
            End If
        End If

    End Sub

    Private Function getLastFileImage(dir As String) As String
        Dim dirinfo As DirectoryInfo = New DirectoryInfo(dir)
        Dim sourceFiles As New List(Of FileInfo)
        Dim out As String = ""
        Try
            sourceFiles.AddRange(dirinfo.GetFiles("*.jpg", SearchOption.TopDirectoryOnly))
            sourceFiles.Sort(AddressOf SortFiles)
            sourceFiles.Reverse()
            out = sourceFiles(0).FullName
        Catch ex As Exception
            Console.WriteLine("No files in folder " & dir)
        End Try

        Return out

    End Function

    Private Function SortFiles(ByVal x As FileInfo, ByVal y As FileInfo) As Integer
        Return x.LastWriteTime.CompareTo(y.LastWriteTime)
    End Function
    Private Function IsOdd(ByVal number As Integer) As Boolean
        IsOdd = ((number Mod 2) <> 0)
    End Function
    Private Function HttpUploadFile( _
    ByVal uri As String, _
    ByVal filePath As String, _
    ByVal fileParameterName As String, _
    ByVal contentType As String, _
    ByVal otherParameters As Specialized.NameValueCollection) As String

        Dim boundary As String = "-----------------------------" & DateTime.Now.Ticks.ToString("x")
        Dim newLine As String = System.Environment.NewLine
        Dim boundaryBytes As Byte() = Text.Encoding.ASCII.GetBytes(newLine & "--" & boundary & newLine)
        Dim request As Net.HttpWebRequest = Net.WebRequest.Create(uri)

        request.ContentType = "multipart/form-data; boundary=" & boundary
        request.Method = "POST"
        request.KeepAlive = True
        request.Accept = "*/*"
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko"

        'request.Credentials = Net.CredentialCache.DefaultCredentials

        Using requestStream As IO.Stream = request.GetRequestStream()

            Dim formDataTemplate As String = "Content-Disposition: form-data; name=""{0}""{1}{1}{2}"

            For Each key As String In otherParameters.Keys

                requestStream.Write(boundaryBytes, 0, boundaryBytes.Length)
                Dim formItem As String = String.Format(formDataTemplate, key, newLine, otherParameters(key))
                Dim formItemBytes As Byte() = Text.Encoding.UTF8.GetBytes(formItem)
                requestStream.Write(formItemBytes, 0, formItemBytes.Length)

            Next key

            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length)

            Dim headerTemplate As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""{2}Content-Type: {3}{2}{2}"
            Dim header As String = String.Format(headerTemplate, fileParameterName, Path.GetFileName(filePath), newLine, contentType)
            Dim headerBytes As Byte() = Text.Encoding.UTF8.GetBytes(header)
            requestStream.Write(headerBytes, 0, headerBytes.Length)

            Using fileStream As New IO.FileStream(filePath, IO.FileMode.Open, IO.FileAccess.Read)

                Dim buffer(4096) As Byte
                Dim bytesRead As Int32 = fileStream.Read(buffer, 0, buffer.Length)

                Do While (bytesRead > 0)

                    requestStream.Write(buffer, 0, bytesRead)
                    bytesRead = fileStream.Read(buffer, 0, buffer.Length)

                Loop

            End Using

            Dim trailer As Byte() = Text.Encoding.ASCII.GetBytes(newLine & "--" + boundary + "--" & newLine)
            requestStream.Write(trailer, 0, trailer.Length)

        End Using

        Dim response As Net.WebResponse = Nothing
        Dim out As String = ""
        Try

            response = request.GetResponse()

            Using responseStream As IO.Stream = response.GetResponseStream()

                Using responseReader As New IO.StreamReader(responseStream)

                    out = responseReader.ReadToEnd

                End Using

            End Using

        Catch exception As Net.WebException

            response = exception.Response

            If (response IsNot Nothing) Then

                Using reader As New IO.StreamReader(response.GetResponseStream())

                    out = reader.ReadToEnd()

                End Using

                response.Close()

            End If

        Finally

            request = Nothing

        End Try

        Return out
    End Function

End Module
