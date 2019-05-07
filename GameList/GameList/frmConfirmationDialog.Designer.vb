<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfirmationDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfirmationDialog))
        Me.pnlTaskBar = New System.Windows.Forms.Panel()
        Me.lblDialogTitle = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.lblDialogText = New System.Windows.Forms.Label()
        Me.lblDialogEmphasis = New System.Windows.Forms.Label()
        Me.pnlMainWrapper = New System.Windows.Forms.Panel()
        Me.pnlTaskBar.SuspendLayout()
        Me.pnlMainWrapper.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTaskBar
        '
        Me.pnlTaskBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlTaskBar.Controls.Add(Me.lblDialogTitle)
        Me.pnlTaskBar.Controls.Add(Me.btnClose)
        Me.pnlTaskBar.Location = New System.Drawing.Point(0, 0)
        Me.pnlTaskBar.Name = "pnlTaskBar"
        Me.pnlTaskBar.Size = New System.Drawing.Size(400, 40)
        Me.pnlTaskBar.TabIndex = 2
        '
        'lblDialogTitle
        '
        Me.lblDialogTitle.AutoSize = True
        Me.lblDialogTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDialogTitle.Font = New System.Drawing.Font("Tw Cen MT", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDialogTitle.ForeColor = System.Drawing.Color.White
        Me.lblDialogTitle.Location = New System.Drawing.Point(4, 3)
        Me.lblDialogTitle.Name = "lblDialogTitle"
        Me.lblDialogTitle.Size = New System.Drawing.Size(71, 34)
        Me.lblDialogTitle.TabIndex = 3
        Me.lblDialogTitle.Text = "TITLE"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.OrangeRed
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(359, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(41, 40)
        Me.btnClose.TabIndex = 1
        Me.btnClose.TabStop = False
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnYes
        '
        Me.btnYes.BackColor = System.Drawing.Color.Silver
        Me.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnYes.FlatAppearance.BorderSize = 0
        Me.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYes.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes.ForeColor = System.Drawing.Color.Black
        Me.btnYes.Location = New System.Drawing.Point(17, 148)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(112, 40)
        Me.btnYes.TabIndex = 15
        Me.btnYes.TabStop = False
        Me.btnYes.Text = "YES"
        Me.btnYes.UseVisualStyleBackColor = False
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
        Me.btnCancel.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(271, 148)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 40)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.TabStop = False
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnNo
        '
        Me.btnNo.BackColor = System.Drawing.Color.Silver
        Me.btnNo.DialogResult = System.Windows.Forms.DialogResult.No
        Me.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnNo.FlatAppearance.BorderSize = 0
        Me.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNo.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNo.ForeColor = System.Drawing.Color.Black
        Me.btnNo.Location = New System.Drawing.Point(144, 148)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(112, 40)
        Me.btnNo.TabIndex = 17
        Me.btnNo.TabStop = False
        Me.btnNo.Text = "NO"
        Me.btnNo.UseVisualStyleBackColor = False
        '
        'lblDialogText
        '
        Me.lblDialogText.AutoSize = True
        Me.lblDialogText.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDialogText.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!)
        Me.lblDialogText.ForeColor = System.Drawing.Color.White
        Me.lblDialogText.Location = New System.Drawing.Point(3, 51)
        Me.lblDialogText.MaximumSize = New System.Drawing.Size(400, 0)
        Me.lblDialogText.Name = "lblDialogText"
        Me.lblDialogText.Size = New System.Drawing.Size(102, 24)
        Me.lblDialogText.TabIndex = 4
        Me.lblDialogText.Text = "CONTENT"
        '
        'lblDialogEmphasis
        '
        Me.lblDialogEmphasis.AutoSize = True
        Me.lblDialogEmphasis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDialogEmphasis.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDialogEmphasis.ForeColor = System.Drawing.Color.LightGreen
        Me.lblDialogEmphasis.Location = New System.Drawing.Point(0, 81)
        Me.lblDialogEmphasis.MaximumSize = New System.Drawing.Size(400, 60)
        Me.lblDialogEmphasis.MinimumSize = New System.Drawing.Size(400, 60)
        Me.lblDialogEmphasis.Name = "lblDialogEmphasis"
        Me.lblDialogEmphasis.Size = New System.Drawing.Size(400, 60)
        Me.lblDialogEmphasis.TabIndex = 18
        Me.lblDialogEmphasis.Text = "CONTENT"
        Me.lblDialogEmphasis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlMainWrapper
        '
        Me.pnlMainWrapper.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.pnlMainWrapper.Controls.Add(Me.lblDialogEmphasis)
        Me.pnlMainWrapper.Controls.Add(Me.pnlTaskBar)
        Me.pnlMainWrapper.Controls.Add(Me.lblDialogText)
        Me.pnlMainWrapper.Controls.Add(Me.btnYes)
        Me.pnlMainWrapper.Controls.Add(Me.btnNo)
        Me.pnlMainWrapper.Controls.Add(Me.btnCancel)
        Me.pnlMainWrapper.Location = New System.Drawing.Point(1, 1)
        Me.pnlMainWrapper.Name = "pnlMainWrapper"
        Me.pnlMainWrapper.Size = New System.Drawing.Size(400, 200)
        Me.pnlMainWrapper.TabIndex = 19
        '
        'frmConfirmationDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(402, 202)
        Me.Controls.Add(Me.pnlMainWrapper)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmConfirmationDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmConfirmationDialog"
        Me.pnlTaskBar.ResumeLayout(False)
        Me.pnlTaskBar.PerformLayout()
        Me.pnlMainWrapper.ResumeLayout(False)
        Me.pnlMainWrapper.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pnlTaskBar As Panel
    Private WithEvents btnClose As Button
    Friend WithEvents btnYes As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnNo As Button
    Friend WithEvents lblDialogTitle As Label
    Friend WithEvents lblDialogText As Label
    Friend WithEvents lblDialogEmphasis As Label
    Friend WithEvents pnlMainWrapper As Panel
End Class
