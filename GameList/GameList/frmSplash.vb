
Public Class frmSplash
    Private Sub handleFormLoad() Handles Me.Load
        lblLoadInfo.Text = ""
        lblSubLoadInfo.Text = ""
        Refresh()
    End Sub
    Public Sub pass(ByVal newLoadInfo As String, Optional complete As Boolean = False)
        If complete Then
            lblLoadInfo.Text = newLoadInfo
        Else
            lblLoadInfo.Text = newLoadInfo & "..."
        End If
        lblSubLoadInfo.Text = ""
        Application.DoEvents()
    End Sub
    Public Sub passSub(ByVal newSubLoadInfo As String)
        lblSubLoadInfo.Text = newSubLoadInfo & "..."
        Application.DoEvents()
    End Sub
    Private startTime As Date
    Public Sub start()
        startTime = Now
        startupTimer.Start()
        pass("Initialising")
        MyBase.Refresh()
        Application.DoEvents()
    End Sub
    Public Function finish() As Decimal
        'returns the time taken
        startupTimer.Stop()
        Dim result As Decimal = Decimal.Parse(timerLabel.Text.Substring(0, timerLabel.Text.Length - 1))
        Me.Close()
        Return result
    End Function
    Private Sub startupTick() Handles startupTimer.Tick
        Dim timeDiff As Decimal = (Now.Ticks - startTime.Ticks) / 100000
        Dim timeDisplay As Decimal = Math.Truncate(timeDiff)
        timerLabel.Text = (timeDisplay / 100) & "s"
    End Sub
End Class

