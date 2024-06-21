Imports System.Net
Imports Newtonsoft.Json

Public Class EditSubmissionForm
    Private submission As Submission
    Private currentIndex As Integer

    Public Sub New(submission As Submission, index As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        Me.submission = submission
        Me.currentIndex = index
        LoadSubmission()
    End Sub

    Private Sub LoadSubmission()
        txtName.Text = submission.Name
        txtEmail.Text = submission.Email
        txtPhoneNum.Text = submission.Phone
        txtGithubLink.Text = submission.Github
        txtStopwatch.Text = submission.Stopwatch

        txtName.ReadOnly = False
        txtEmail.ReadOnly = False
        txtPhoneNum.ReadOnly = False
        txtGithubLink.ReadOnly = False
        txtStopwatch.ReadOnly = False
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            ' Update the submission object with the edited values
            submission.Name = txtName.Text
            submission.Email = txtEmail.Text
            submission.Phone = txtPhoneNum.Text
            submission.Github = txtGithubLink.Text
            submission.Stopwatch = txtStopwatch.Text

            ' Create the web client and set the headers
            Dim client As New WebClient()
            client.Headers(HttpRequestHeader.ContentType) = "application/json"

            ' Serialize the submission object to JSON
            Dim requestData As String = JsonConvert.SerializeObject(submission)

            ' Send the updated data to the server
            client.UploadString("http://localhost:3000/edit?index=" & currentIndex, "PUT", requestData)
            MsgBox(requestData)
            ' Show success message
            MsgBox("Updated Successfully!")

            ' Close the form and return OK dialog result
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ' Show error message
            MsgBox("Error updating submission: " & ex.Message)
        End Try
    End Sub

    Private Sub EditSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
