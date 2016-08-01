Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class ServerForm
    Private Sub ServerForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim ConnectPort As Integer = 12345
        Dim UDPClient As New UdpClient(ConnectPort)

        Try
            Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Any, ConnectPort)

            While (True)
                Dim ReceiveBytes As Byte() = UDPClient.Receive(RemoteIpEndPoint)
                Dim ReceiveString As String = Encoding.UTF8.GetString(ReceiveBytes)
                MsgBox(ReceiveString,, RemoteIpEndPoint.Address.ToString() & ":" & RemoteIpEndPoint.Port)

                Dim SendString As String = Now.ToString
                Dim SendBytes As Byte() = Encoding.UTF8.GetBytes(SendString)
                UDPClient.Send(SendBytes, SendBytes.Length, RemoteIpEndPoint)
            End While

            UDPClient.Close()
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
        End Try
    End Sub
End Class
