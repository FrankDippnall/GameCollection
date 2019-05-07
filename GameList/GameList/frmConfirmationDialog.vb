Public Class frmConfirmationDialog
    Private dragging As Boolean
    Private prevMousePos As Point
    Function runDialog(ByVal dialogTitle As String, ByVal dialogText As String, ByVal dialogEmphasis As String, ByVal dType As DialogType) As DialogResult
        lblDialogTitle.Text = dialogTitle
        lblDialogText.Text = dialogText
        lblDialogEmphasis.Text = dialogEmphasis
        Select Case dType
            Case DialogType.YESNOCANCEL
                'future implementation
            Case DialogType.OKCANCEL
                ' ...
        End Select
        Return ShowDialog()
    End Function
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub startDrag(sender As Object, e As MouseEventArgs) Handles pnlTaskBar.MouseDown, lblDialogTitle.MouseDown
        dragging = True
        prevMousePos = Cursor.Position
    End Sub
    Private Sub endDrag(sender As Object, e As MouseEventArgs) Handles pnlTaskBar.MouseUp, lblDialogTitle.MouseUp
        dragging = False
        prevMousePos = Cursor.Position
    End Sub
    Private Sub Drag(sender As Object, e As MouseEventArgs) Handles pnlTaskBar.MouseMove, lblDialogTitle.MouseMove
        If dragging Then
            Dim currentMousePos As Point = Cursor.Position
            Dim deltaPos As Point = New Point(currentMousePos.X - prevMousePos.X, currentMousePos.Y - prevMousePos.Y)
            prevMousePos = currentMousePos
            Location = New Point(Location.X + deltaPos.X, Location.Y + deltaPos.Y)
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As KeyPressEventArgs) Handles btnCancel.KeyPress, btnNo.KeyPress, btnYes.KeyPress, btnClose.KeyPress
        e.KeyChar = Chr(13)
        e.Handled = True
    End Sub
End Class
Public Enum DialogType
    YESNOCANCEL
    OKCANCEL
End Enum