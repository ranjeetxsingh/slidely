Imports System.Net
Imports System.Windows.Forms

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            btnViewSubmissions.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            btnCreateSubmissions.PerformClick()
        End If
    End Sub

    Private Sub BtnViewSubmissions_Click(sender As Object, e As EventArgs) Handles btnViewSubmissions.Click
        Dim viewForm As New ViewSubmissionForm()
        viewForm.Show()
    End Sub

    Private Sub BtnCreateSubmissions_Click(sender As Object, e As EventArgs) Handles btnCreateSubmissions.Click
        Dim createForm As New CreateSubmissionForm()
        createForm.StartStopwatch()
        createForm.ShowDialog()
    End Sub


    Private Sub BtnSearchByEmail_Click(sender As Object, e As EventArgs) Handles btnSearchByEmail.Click
        Dim email As String = InputBox("Enter Email:", "Search By Email")
        If Not String.IsNullOrEmpty(email) Then
            Dim resultForm As New SearchResultForm(email)
            resultForm.Show()
        End If
    End Sub
End Class
