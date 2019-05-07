<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGameEditDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGameEditDialog))
        Me.pnlTaskBar = New System.Windows.Forms.Panel()
        Me.lblDialogTitle = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblDialogText = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlMainWrapper = New System.Windows.Forms.Panel()
        Me.txtInput = New System.Windows.Forms.TextBox()
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
        Me.lblDialogTitle.Location = New System.Drawing.Point(3, 3)
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
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Silver
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(154, 148)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(112, 40)
        Me.btnOK.TabIndex = 15
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
        Me.btnCancel.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(274, 148)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 40)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'pnlMainWrapper
        '
        Me.pnlMainWrapper.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.pnlMainWrapper.Controls.Add(Me.txtInput)
        Me.pnlMainWrapper.Controls.Add(Me.pnlTaskBar)
        Me.pnlMainWrapper.Controls.Add(Me.lblDialogText)
        Me.pnlMainWrapper.Controls.Add(Me.btnOK)
        Me.pnlMainWrapper.Controls.Add(Me.btnCancel)
        Me.pnlMainWrapper.Location = New System.Drawing.Point(1, 1)
        Me.pnlMainWrapper.Name = "pnlMainWrapper"
        Me.pnlMainWrapper.Size = New System.Drawing.Size(400, 200)
        Me.pnlMainWrapper.TabIndex = 20
        '
        'txtInput
        '
        Me.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInput.Location = New System.Drawing.Point(14, 91)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtInput.Size = New System.Drawing.Size(375, 47)
        Me.txtInput.TabIndex = 16
        Me.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmGameEditDialog
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(402, 202)
        Me.Controls.Add(Me.pnlMainWrapper)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmGameEditDialog"
        Me.Text = "frmGameEditDialog"
        Me.pnlTaskBar.ResumeLayout(False)
        Me.pnlTaskBar.PerformLayout()
        Me.pnlMainWrapper.ResumeLayout(False)
        Me.pnlMainWrapper.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pnlTaskBar As Panel
    Friend WithEvents lblDialogTitle As Label
    Private WithEvents btnClose As Button
    Friend WithEvents lblDialogText As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents pnlMainWrapper As Panel
    Friend WithEvents txtInput As TextBox
End Class
