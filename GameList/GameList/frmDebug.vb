Public Class frmDebug
    Public Sub updateReadout(ByRef info As String)
        lblReadout.Text = info
    End Sub
    Private dragging As Boolean = False
    Private prevMousePos As Point
    Private Sub startDrag(sender As Object, e As MouseEventArgs) Handles Me.MouseDown, lblReadout.MouseDown
        dragging = True
        prevMousePos = Cursor.Position
    End Sub
    Private Sub endDrag(sender As Object, e As MouseEventArgs) Handles Me.MouseUp, lblReadout.MouseUp
        dragging = False
        prevMousePos = Cursor.Position
    End Sub
    Private Sub drag(sender As Object, e As MouseEventArgs) Handles Me.MouseMove, lblReadout.MouseMove
        If dragging Then
            Dim currentMousePos As Point = Cursor.Position
            Dim deltaPos As Point = New Point(currentMousePos.X - prevMousePos.X, currentMousePos.Y - prevMousePos.Y)
            prevMousePos = currentMousePos
            Location = New Point(Location.X + deltaPos.X, Location.Y + deltaPos.Y)
        End If
    End Sub
End Class