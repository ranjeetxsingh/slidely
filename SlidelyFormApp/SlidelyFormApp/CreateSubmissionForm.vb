Imports System.Net
Imports Newtonsoft.Json
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class CreateSubmissionForm
    Private stopwatch As New Stopwatch()
    Private timer As New Timer()
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        AddHandler timer.Tick, AddressOf UpdateStopwatchTime
        timer.Interval = 1000
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StartStopwatch()
        Me.KeyPreview = True
    End Sub

    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.T Then
            BtnToggleStopwatch_Click(sender, e)
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            SubmitData()
        End If
    End Sub

    Private Sub CreateSubmissionForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        stopwatch.Stop()
        timer.Stop()
    End Sub

    Public Sub StartStopwatch()
        stopwatch.Start()
        timer.Start()
    End Sub

    Private Sub UpdateStopwatchTime(sender As Object, e As EventArgs)
        txtStopwatchTime.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub
    Private Sub BtnToggleStopwatch_Click(sender As Object, e As EventArgs) Handles btnToggleStopwatch.Click
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            timer.Stop()
        Else
            stopwatch.Start()
            timer.Start()
        End If
        txtStopwatchTime.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        SubmitData()
    End Sub
    Private Sub SubmitData()
        Try
            Dim submission As New Submissions With {
                .name = txtName.Text,
                .email = txtEmail.Text,
                .phone = txtPhoneNum.Text,
                .github = txtGithubLink.Text,
                .stopwatch = stopwatch.Elapsed.ToString("hh\:mm\:ss")
            }

            Dim jsonData As String = JsonConvert.SerializeObject(submission)

            Using client As New WebClient()
                client.Headers(HttpRequestHeader.ContentType) = "application/json"
                client.UploadString("http://localhost:3000/submit", jsonData)
            End Using

            MessageBox.Show("Submission successful!")

            stopwatch.Reset()
            txtStopwatchTime.Text = "00:00:00"

            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error submitting form: " & ex.Message)
        End Try
    End Sub

End Class

Public Class Submissions
    Public Property name As String
    Public Property email As String
    Public Property phone As String
    Public Property github As String
    Public Property stopwatch As String
End Class
