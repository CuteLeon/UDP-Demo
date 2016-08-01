Imports System.Net.Sockets
Imports System.Text

Public Class ClientForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ConnectPort As Integer = 12345
        Dim RemoteIP As String = "localhost"
        Dim UDPClient As New UdpClient()
        Dim SendString As String = Now.ToString

        Try
            UDPClient.Connect(RemoteIP, ConnectPort)

            Dim SendBytes As Byte() = Encoding.UTF8.GetBytes(SendString)
            UDPClient.Send(SendBytes, SendBytes.Length)

            Dim ReceiveBytes As Byte() = UDPClient.Receive(UDPClient.Client.LocalEndPoint)
            Dim ReceiveString As String = Encoding.UTF8.GetString(ReceiveBytes)
            MsgBox(ReceiveString.ToString(),, "收到消息")
            UDPClient.Close()
        Catch ex As Exception
            Debug.Print(ex.ToString())
        End Try
    End Sub
End Class
