<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPreferences
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreferences))
        Me.pnlTaskBar = New System.Windows.Forms.Panel()
        Me.lblDialogTitle = New System.Windows.Forms.Label()
        Me.pnlMainWrapper = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlOptionInfo = New System.Windows.Forms.Panel()
        Me.lblOptionStatusInfo = New System.Windows.Forms.Label()
        Me.lblOptionHelpText = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlTaskBar.SuspendLayout()
        Me.pnlMainWrapper.SuspendLayout()
        Me.pnlOptionInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTaskBar
        '
        Me.pnlTaskBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlTaskBar.Controls.Add(Me.lblDialogTitle)
        Me.pnlTaskBar.Controls.Add(Me.btnClose)
        Me.pnlTaskBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlTaskBar.Name = "pnlTaskBar"
        Me.pnlTaskBar.Size = New System.Drawing.Size(550, 40)
        Me.pnlTaskBar.TabIndex = 2
        '
        'lblDialogTitle
        '
        Me.lblDialogTitle.AutoSize = True
        Me.lblDialogTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDialogTitle.Font = New System.Drawing.Font("Tw Cen MT", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDialogTitle.ForeColor = System.Drawing.Color.White
        Me.lblDialogTitle.Location = New System.Drawing.Point(3, 3)
        Me.lblDialogTitle.Name = "lblDialogTitle"
        Me.lblDialogTitle.Size = New System.Drawing.Size(71, 34)
        Me.lblDialogTitle.TabIndex = 3
        Me.lblDialogTitle.Text = "TITLE"
        '
        'pnlMainWrapper
        '
        Me.pnlMainWrapper.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.pnlMainWrapper.Controls.Add(Me.btnOK)
        Me.pnlMainWrapper.Controls.Add(Me.btnCancel)
        Me.pnlMainWrapper.Controls.Add(Me.pnlOptionInfo)
        Me.pnlMainWrapper.Controls.Add(Me.pnlTaskBar)
        Me.pnlMainWrapper.Location = New System.Drawing.Point(1, 1)
        Me.pnlMainWrapper.Name = "pnlMainWrapper"
        Me.pnlMainWrapper.Size = New System.Drawing.Size(550, 560)
        Me.pnlMainWrapper.TabIndex = 3
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Silver
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(232, 518)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(151, 33)
        Me.btnOK.TabIndex = 17
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Silver
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(389, 518)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(151, 33)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'pnlOptionInfo
        '
        Me.pnlOptionInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlOptionInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOptionInfo.Controls.Add(Me.lblOptionStatusInfo)
        Me.pnlOptionInfo.Controls.Add(Me.lblOptionHelpText)
        Me.pnlOptionInfo.Location = New System.Drawing.Point(-1, 470)
        Me.pnlOptionInfo.Name = "pnlOptionInfo"
        Me.pnlOptionInfo.Size = New System.Drawing.Size(552, 40)
        Me.pnlOptionInfo.TabIndex = 4
        '
        'lblOptionStatusInfo
        '
        Me.lblOptionStatusInfo.AutoSize = True
        Me.lblOptionStatusInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblOptionStatusInfo.Font = New System.Drawing.Font("Tw Cen MT", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptionStatusInfo.ForeColor = System.Drawing.Color.White
        Me.lblOptionStatusInfo.Location = New System.Drawing.Point(430, 0)
        Me.lblOptionStatusInfo.MaximumSize = New System.Drawing.Size(120, 40)
        Me.lblOptionStatusInfo.MinimumSize = New System.Drawing.Size(120, 40)
        Me.lblOptionStatusInfo.Name = "lblOptionStatusInfo"
        Me.lblOptionStatusInfo.Size = New System.Drawing.Size(120, 40)
        Me.lblOptionStatusInfo.TabIndex = 5
        Me.lblOptionStatusInfo.Text = "STATUS"
        Me.lblOptionStatusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOptionHelpText
        '
        Me.lblOptionHelpText.AutoSize = True
        Me.lblOptionHelpText.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblOptionHelpText.Font = New System.Drawing.Font("Tw Cen MT", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptionHelpText.ForeColor = System.Drawing.Color.White
        Me.lblOptionHelpText.Location = New System.Drawing.Point(0, 0)
        Me.lblOptionHelpText.MaximumSize = New System.Drawing.Size(430, 40)
        Me.lblOptionHelpText.MinimumSize = New System.Drawing.Size(430, 40)
        Me.lblOptionHelpText.Name = "lblOptionHelpText"
        Me.lblOptionHelpText.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblOptionHelpText.Size = New System.Drawing.Size(430, 40)
        Me.lblOptionHelpText.TabIndex = 4
        Me.lblOptionHelpText.Text = "help text"
        Me.lblOptionHelpText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.OrangeRed
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(509, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(41, 40)
        Me.btnClose.TabIndex = 1
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'frmPreferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(552, 562)
        Me.Controls.Add(Me.pnlMainWrapper)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPreferences"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmConfirmationDialog"
        Me.pnlTaskBar.ResumeLayout(False)
        Me.pnlTaskBar.PerformLayout()
        Me.pnlMainWrapper.ResumeLayout(False)
        Me.pnlOptionInfo.ResumeLayout(False)
        Me.pnlOptionInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pnlTaskBar As Panel
    Private WithEvents btnClose As Button
    Friend WithEvents lblDialogTitle As Label
    Friend WithEvents pnlMainWrapper As Panel
    Private WithEvents pnlOptionInfo As Panel
    Friend WithEvents lblOptionHelpText As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblOptionStatusInfo As Label
End Class
