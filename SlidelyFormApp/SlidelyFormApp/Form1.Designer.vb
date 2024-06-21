<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnViewSubmissions = New System.Windows.Forms.Button()
        Me.btnCreateSubmissions = New System.Windows.Forms.Button()
        Me.btnSearchByEmail = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnViewSubmissions
        '
        Me.btnViewSubmissions.BackColor = System.Drawing.Color.Yellow
        Me.btnViewSubmissions.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewSubmissions.Location = New System.Drawing.Point(200, 120)
        Me.btnViewSubmissions.Name = "btnViewSubmissions"
        Me.btnViewSubmissions.Size = New System.Drawing.Size(337, 69)
        Me.btnViewSubmissions.TabIndex = 0
        Me.btnViewSubmissions.Text = "&View Submissions" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnViewSubmissions.UseVisualStyleBackColor = False
        '
        'btnCreateSubmissions
        '
        Me.btnCreateSubmissions.BackColor = System.Drawing.Color.LightBlue
        Me.btnCreateSubmissions.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateSubmissions.Location = New System.Drawing.Point(200, 208)
        Me.btnCreateSubmissions.Name = "btnCreateSubmissions"
        Me.btnCreateSubmissions.Size = New System.Drawing.Size(337, 69)
        Me.btnCreateSubmissions.TabIndex = 1
        Me.btnCreateSubmissions.Text = "&Create New Submission"
        Me.btnCreateSubmissions.UseVisualStyleBackColor = False
        '
        'btnSearchByEmail
        '
        Me.btnSearchByEmail.BackColor = System.Drawing.Color.Lavender
        Me.btnSearchByEmail.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchByEmail.Location = New System.Drawing.Point(200, 296)
        Me.btnSearchByEmail.Name = "btnSearchByEmail"
        Me.btnSearchByEmail.Size = New System.Drawing.Size(337, 69)
        Me.btnSearchByEmail.TabIndex = 3
        Me.btnSearchByEmail.Text = "Search By Email"
        Me.btnSearchByEmail.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic", 13.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(273, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 30)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Slidely Form App"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 549)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSearchByEmail)
        Me.Controls.Add(Me.btnCreateSubmissions)
        Me.Controls.Add(Me.btnViewSubmissions)
        Me.Name = "Form1"
        Me.Text = "Ranjeet Singh, Slidely AI Task 2- Slidely Form App"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnViewSubmissions As Button
    Friend WithEvents btnCreateSubmissions As Button
    Friend WithEvents btnSearchByEmail As Button
    Friend WithEvents Label1 As Label
End Class
