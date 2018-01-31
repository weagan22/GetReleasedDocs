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
        Me.Btn_Go = New System.Windows.Forms.Button()
        Me.SearchValues = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Btn_Go
        '
        Me.Btn_Go.BackColor = System.Drawing.Color.Lime
        Me.Btn_Go.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Go.Location = New System.Drawing.Point(411, 76)
        Me.Btn_Go.Name = "Btn_Go"
        Me.Btn_Go.Size = New System.Drawing.Size(130, 64)
        Me.Btn_Go.TabIndex = 0
        Me.Btn_Go.Text = "GO!"
        Me.Btn_Go.UseVisualStyleBackColor = False
        '
        'SearchValues
        '
        Me.SearchValues.Location = New System.Drawing.Point(12, 36)
        Me.SearchValues.Name = "SearchValues"
        Me.SearchValues.Size = New System.Drawing.Size(529, 20)
        Me.SearchValues.TabIndex = 1
        Me.SearchValues.Text = "Enter values here..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(353, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Enter desired part numbers separated by a comma and then hit go button."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(553, 156)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SearchValues)
        Me.Controls.Add(Me.Btn_Go)
        Me.Name = "Form1"
        Me.Text = "Get Released Docs"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Go As Button
    Friend WithEvents SearchValues As TextBox
    Friend WithEvents Label1 As Label
End Class
