Imports System.Net
Imports Newtonsoft.Json

Public Class ViewSubmissionForm
    Private currentIndex As Integer = 0
    Private submissions As List(Of Submission) = New List(Of Submission)

    Public Sub New()
        InitializeComponent()
        Me.KeyPreview = True
        LoadSubmissions()
        DisplaySubmission()
    End Sub

    Private Sub LoadSubmissions()
        Try
            Dim client As New WebClient()
            Dim jsonResponse As String = client.DownloadString("http://localhost:3000/read?index=" & currentIndex)
            Dim submission As Submission = JsonConvert.DeserializeObject(Of Submission)(jsonResponse)
            submissions.Add(submission)
        Catch ex As Exception
            MessageBox.Show("Error loading submissions: " & ex.Message)
        End Try
    End Sub

    Private Sub DisplaySubmission()
        If currentIndex >= 0 AndAlso currentIndex < submissions.Count Then
            txtName.Text = submissions(currentIndex).Name
            txtEmail.Text = submissions(currentIndex).Email
            txtPhoneNum.Text = submissions(currentIndex).Phone
            txtGithubLink.Text = submissions(currentIndex).Github
            txtStopwatchTime.Text = submissions(currentIndex).Stopwatch
        Else
            MsgBox("No More Details available")
        End If
    End Sub

    Private Sub BtnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            DisplaySubmission()
        Else
            MsgBox("No More Details Available!")
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            DisplaySubmission()
        Else
            currentIndex += 1
            LoadSubmissions()
            If currentIndex < submissions.Count Then
                DisplaySubmission()
            Else
                currentIndex -= 1
                MessageBox.Show("No More Details available")
            End If
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteSubmission()
    End Sub

    Private Sub DeleteSubmission()
        Try
            Dim client As New WebClient()
            client.Headers(HttpRequestHeader.ContentType) = "application/json"
            client.UploadString("http://localhost:3000/delete?index=" & currentIndex, "DELETE", "")

            submissions.RemoveAt(currentIndex)

            If currentIndex >= submissions.Count Then
                currentIndex = submissions.Count - 1
            End If

            DisplaySubmission()
            MsgBox("Submission deleted successfully!")
        Catch ex As Exception
            MsgBox("Error deleting submission: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If currentIndex >= 0 AndAlso currentIndex < submissions.Count Then
            Dim editForm As New EditSubmissionForm(submissions(currentIndex), currentIndex)
            If editForm.ShowDialog() = DialogResult.OK Then
                LoadUpdatedSubmission(currentIndex)
            End If
        Else
            MsgBox("No submission selected for editing.")
        End If
    End Sub

    Private Sub LoadUpdatedSubmission(index As Integer)
        Try
            Dim client As New WebClient()
            Dim jsonResponse As String = client.DownloadString("http://localhost:3000/read?index=" & index)
            Dim updatedSubmission As Submission = JsonConvert.DeserializeObject(Of Submission)(jsonResponse)
            submissions(index) = updatedSubmission
            DisplaySubmission()
        Catch ex As Exception
            MessageBox.Show("Error reloading submission: " & ex.Message)
        End Try
    End Sub

    Private Sub ViewSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Class Submission
    <JsonProperty("name")>
    Public Property Name As String
    <JsonProperty("email")>
    Public Property Email As String
    <JsonProperty("phone")>
    Public Property Phone As String
    <JsonProperty("github")>
    Public Property Github As String
    <JsonProperty("stopwatch")>
    Public Property Stopwatch As String
End Class
