Imports System.ComponentModel
Imports Newtonsoft.Json.Linq

Public Class MainForm
    Public ExtensionChild As Extension

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FinalJSON As JObject = New JObject()
        FinalJSON.Add(New JProperty("Revision", TextBox1.Text))
        FinalJSON.Add(New JProperty("Outgoing", GetMessagesJArray(True)))
        FinalJSON.Add(New JProperty("Incoming", GetMessagesJArray(False)))
        Dim SFD As New SaveFileDialog()
        SFD.Filter = "Messages (*.*)|*.*"
        SFD.FileName = "HARBLE_API-" & TextBox1.Text
        If SFD.ShowDialog() = DialogResult.OK Then
            IO.File.WriteAllText(SFD.FileName, FinalJSON.ToString)
            MsgBox("OK :)")
        End If
    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ExtensionChild.Close()
    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Focus()
    End Sub

    Function GetMessagesJArray(ByVal IsOutgoing As Boolean) As JArray
        Dim RequestedMessages As SortedDictionary(Of UShort, Sulakore.Habbo.MessageItem)
        If IsOutgoing = True Then
            RequestedMessages = ExtensionChild.Game.OutMessages
        Else
            RequestedMessages = ExtensionChild.Game.InMessages
        End If
        Dim MessagesJArray As New JArray()
        For Each Message In RequestedMessages
            Dim NewMessage As New JObject()
            If IsOutgoing = True Then
                NewMessage.Add(New JProperty("Name", ExtensionChild.Out.GetName(Message.Value.Hash)))
            Else
                NewMessage.Add(New JProperty("Name", ExtensionChild.In.GetName(Message.Value.Hash)))
            End If
            If String.IsNullOrWhiteSpace(NewMessage("Name").ToString) Then
                Continue For 'Skip empty messages
            End If
            NewMessage.Add(New JProperty("Id", Message.Value.Id))
            NewMessage.Add(New JProperty("Hash", Message.Value.Hash))
            NewMessage.Add(New JProperty("IsOutgoing", Message.Value.IsOutgoing))
            MessagesJArray.Add(NewMessage)
        Next
        Return MessagesJArray
    End Function

End Class