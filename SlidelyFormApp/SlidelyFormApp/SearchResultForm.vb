Imports System.Net
Imports Newtonsoft.Json

Public Class SearchResultForm
    Private currentIndex As Integer = 0
    Private submissions As List(Of Submit)

    Public Sub New(email As String)

        ' This call is required by the designer.
        InitializeComponent()
        SearchSubmissions(email)
        DisplaySubmission()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub SearchSubmissions(email As String)
        Try
            Dim client As New WebClient()
            client.Headers(HttpRequestHeader.ContentType) = "application/json"
            Dim requestData As String = JsonConvert.SerializeObject(New With {Key .email = email})
            Dim jsonResponse As String = client.UploadString("http://localhost:3000/read-by-email", "POST", requestData)
            If Not String.IsNullOrEmpty(jsonResponse) Then
                submissions = JsonConvert.DeserializeObject(Of List(Of Submit))(jsonResponse)
            End If

            If submissions Is Nothing OrElse submissions.Count = 0 Then
                MsgBox("No submissions found for the provided email.")
            End If
        Catch ex As Exception
            MsgBox("Error searching submissions: " & ex.Message)
        End Try
    End Sub

    Private Sub DisplaySubmission()
        If submissions IsNot Nothing AndAlso submissions.Count > 0 Then
            If currentIndex >= 0 AndAlso currentIndex < submissions.Count Then
                txtName.Text = submissions(currentIndex).Name
                txtEmail.Text = submissions(currentIndex).Email
                txtPhoneNum.Text = submissions(currentIndex).Phone
                txtGithubLink.Text = submissions(currentIndex).Github
                txtStopwatchTime.Text = submissions(currentIndex).Stopwatch
            Else
                MsgBox("No More Details available")
            End If
        Else
            MsgBox("No data available in the database.")
        End If
    End Sub

    Private Sub ClearFields()
        txtName.Text = String.Empty
        txtEmail.Text = String.Empty
        txtPhoneNum.Text = String.Empty
        txtGithubLink.Text = String.Empty
        txtStopwatchTime.Text = String.Empty
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
            MsgBox("No More Details Available!")
        End If
    End Sub

    Private Sub SearchResultForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Class Submit
    Public Property Name As String
    Public Property Email As String
    Public Property Phone As String
    Public Property Github As String
    Public Property Stopwatch As String
End Class