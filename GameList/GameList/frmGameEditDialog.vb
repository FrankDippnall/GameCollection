Public Class frmGameEditDialog
    Private dragging As Boolean
    Private prevMousePos As Point
    Private numOnly As Boolean
    Private cancel As Boolean
    Function runEditDialog(ByVal dialogTitle As String, ByVal dialogText As String, ByVal eType As EditType, ByVal defaultText As String) As GameEdit
        lblDialogTitle.Text = dialogTitle
        lblDialogText.Text = dialogText
        cancel = False
        txtInput.Text = defaultText
        Select Case eType
            Case EditType.USER_RATING
                numOnly = True
            Case EditType.USER_COMMENT
                numOnly = False
        End Select
        ShowDialog()
        If cancel Then
            Return New GameEdit()
        Else
            Return New GameEdit(eType, finalValidate(eType, txtInput.Text))
        End If

    End Function
    Private Function finalValidate(eType As EditType, ByVal input As String) As String
        Select Case eType
            Case EditType.USER_RATING
                If input = "" Then
                    Return "0"
                ElseIf Integer.Parse(input) > 100 Then
                    Return 100
                End If
                Return input
            Case EditType.USER_COMMENT
                Return input
            Case Else
                Return input
        End Select
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
    Private Sub focusText() Handles MyBase.Shown
        disableTabStop(Me)
        txtInput.TabStop = True
        txtInput.Focus()
    End Sub
    Private Sub inputHandler(sender As Object, e As KeyPressEventArgs) Handles txtInput.KeyPress
        Dim keyCode As Integer = Asc(e.KeyChar)
        If keyCode = 8 Or keyCode = 32 Or keyCode = 13 Then
            Exit Sub
        ElseIf numOnly Then
            If Not (keyCode > 47 And keyCode < 58) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        cancel = True
    End Sub
End Class
Public Class GameEdit
    Public infoType As EditType
    Public newText As String = "<UNDEFINED>"
    Public newInt As Integer = -1
    Public newBool As Boolean
    Public cancelled As Boolean = False
    Public Sub New(iType As EditType, newVal As String)
        infoType = iType
        Select Case infoType
            Case EditType.USER_COMMENT
                newText = newVal
            Case EditType.USER_RATING
                newInt = Integer.Parse(newVal)
        End Select
    End Sub
    Public Sub New(iType As EditType, newVal As Boolean)
        infoType = iType
        newBool = newVal
    End Sub
    Public Sub New()
        cancelled = True
    End Sub
End Class
Public Enum EditType
    USER_RATING
    USER_COMMENT
    USER_PLAYED
    GAME_TAGS
End Enum
