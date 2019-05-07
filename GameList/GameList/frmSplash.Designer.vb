<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSplash
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lbl_Title = New System.Windows.Forms.Label()
        Me.lbl_versionNo = New System.Windows.Forms.Label()
        Me.lblLoadInfo = New System.Windows.Forms.Label()
        Me.lblSubLoadInfo = New System.Windows.Forms.Label()
        Me.timerLabel = New System.Windows.Forms.Label()
        Me.startupTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lbl_Title
        '
        Me.lbl_Title.AutoSize = True
        Me.lbl_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Title.ForeColor = System.Drawing.Color.Gold
        Me.lbl_Title.Location = New System.Drawing.Point(72, 72)
        Me.lbl_Title.Name = "lbl_Title"
        Me.lbl_Title.Size = New System.Drawing.Size(242, 55)
        Me.lbl_Title.TabIndex = 0
        Me.lbl_Title.Text = "Game List"
        '
        'lbl_versionNo
        '
        Me.lbl_versionNo.AutoSize = True
        Me.lbl_versionNo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lbl_versionNo.Font = New System.Drawing.Font("Franklin Gothic Book", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_versionNo.ForeColor = System.Drawing.Color.DarkRed
        Me.lbl_versionNo.Location = New System.Drawing.Point(400, 0)
        Me.lbl_versionNo.Name = "lbl_versionNo"
        Me.lbl_versionNo.Size = New System.Drawing.Size(0, 21)
        Me.lbl_versionNo.TabIndex = 1
        Me.lbl_versionNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLoadInfo
        '
        Me.lblLoadInfo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblLoadInfo.AutoSize = True
        Me.lblLoadInfo.Font = New System.Drawing.Font("Gill Sans MT", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadInfo.ForeColor = System.Drawing.Color.Black
        Me.lblLoadInfo.Location = New System.Drawing.Point(12, 136)
        Me.lblLoadInfo.Name = "lblLoadInfo"
        Me.lblLoadInfo.Size = New System.Drawing.Size(124, 30)
        Me.lblLoadInfo.TabIndex = 2
        Me.lblLoadInfo.Text = "LOAD INFO"
        Me.lblLoadInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSubLoadInfo
        '
        Me.lblSubLoadInfo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblSubLoadInfo.AutoSize = True
        Me.lblSubLoadInfo.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubLoadInfo.ForeColor = System.Drawing.Color.Black
        Me.lblSubLoadInfo.Location = New System.Drawing.Point(12, 170)
        Me.lblSubLoadInfo.Name = "lblSubLoadInfo"
        Me.lblSubLoadInfo.Size = New System.Drawing.Size(71, 23)
        Me.lblSubLoadInfo.TabIndex = 3
        Me.lblSubLoadInfo.Text = "sub info"
        Me.lblSubLoadInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'timerLabel
        '
        Me.timerLabel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.timerLabel.AutoSize = True
        Me.timerLabel.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timerLabel.ForeColor = System.Drawing.Color.Black
        Me.timerLabel.Location = New System.Drawing.Point(12, 9)
        Me.timerLabel.Name = "timerLabel"
        Me.timerLabel.Size = New System.Drawing.Size(71, 23)
        Me.timerLabel.TabIndex = 4
        Me.timerLabel.Text = "sub info"
        Me.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'startupTimer
        '
        Me.startupTimer.Interval = 1
        '
        'frmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Coral
        Me.ClientSize = New System.Drawing.Size(400, 200)
        Me.Controls.Add(Me.timerLabel)
        Me.Controls.Add(Me.lblSubLoadInfo)
        Me.Controls.Add(Me.lblLoadInfo)
        Me.Controls.Add(Me.lbl_versionNo)
        Me.Controls.Add(Me.lbl_Title)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSplash"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_Title As Label
    Friend WithEvents lbl_versionNo As Label
    Friend WithEvents lblLoadInfo As Label
    Friend WithEvents lblSubLoadInfo As Label
    Friend WithEvents timerLabel As Label
    Friend WithEvents startupTimer As Timer
End Class
