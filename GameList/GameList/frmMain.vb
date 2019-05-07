Imports System
Imports System.Net
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.ComponentModel

Public Class frmMain
#Region "Settings"
    Private btnReturnLeftPos As Point = New Point(670, 0)
    Private btnReturnRightPos As Point = New Point(800, 0)
    Private clearSearchDownPos As Point = New Point(335, 0)
    Private clearSearchUpPos As Point = New Point(335, -40)
    Private Const itemHeight As Integer = 34
    Private searchTabUpPos As Point = New Point(0, 410)
    Private searchTabDownPos As Point = New Point(0, 520)
    Private Const searchTabSensitivity As Integer = 100
    Private Const bufferGradient As Double = -272 / 110
    Private Const bufferC As Double = 306 + 272 * 410 / 110 'used for adding additional height to pnlMainContent when necessary to fit scroll bar.
    Private Const scrollGap As Decimal = 34
    Private searchMenuDownPos As Point = New Point(0, 110)
    Private searchMenuUpPos As Point = New Point(0, 0)
    Private Const controlMoveSensitivity As Integer = 100
    Private Const controlFadeSensitivity As Integer = 100
    Private sortFieldPoints() As Point = {New Point(0, 0), New Point(-210, 0), New Point(-420, 0)}
    Private saveChangesRightPos As Point = New Point(815, 413)
    Private revertChangesRightPos As Point = New Point(815, 341)
    Private saveChangesLeftPos As Point = New Point(540, 413)
    Private revertChangesLeftPos As Point = New Point(540, 341)
    Private editRecordUpPos As Point = New Point(540, 414)
    Private editRecordDownPos As Point = New Point(540, 486)
    Private maxTextRatio As Decimal = 0.8
    Private orderNumColor As Color = Color.FromArgb(60, 60, 200)
    Private gameInfoNormalColor As Color = Color.Gray
    Private gameInfoHoverColor As Color = Color.FromArgb(144, 144, 144)
    Private fadeOutMultiplier As Decimal = 2
    Private notifyFlashColor As Color = Color.LightGreen
    Private controlMoveSpeed As Integer
#End Region
#Region "Globals"
    Private dragging As Boolean
    Private prevMousePos As Point
    Private games As New List(Of String)
    Private gameBtns As New List(Of Control)
    Private searching As Boolean = False
    Private scrolling As Boolean = False
    Private adhocSearching As Boolean = False
    Private currentSortFieldNum As Integer = 0
    Private sortFieldLabels() As Label
    Private ascendingOrder As Boolean = True
    Private bufferAmount As Integer = 0
    Dim listBoxPixelsTotal As Integer
    Dim listBoxPixelsShown As Integer
    Private editing As Boolean = False
    Private currentGameID As Integer = -1
    Private inAnimation As Boolean = False
    Private fading As Boolean = False
    Private debugForm As New frmDebug
    Private currentGameInfo As GameInfo
    Private madeChanges As Boolean = False
    Public availablePalettes As New List(Of Palette)
    Public availableMenuPalettes As New List(Of Palette)
    Private currentPalette As Palette
    Private currentMenuPalette As Palette
    Private toClose As Boolean = False
#End Region
    Private Sub btnMinimise_Click(sender As Object, e As EventArgs) Handles btnMinimise.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If editing And madeChanges Then
            Dim result As DialogResult = frmConfirmationDialog.runDialog("Save Changes", "Save your changes to the record ", lblGameInfoTitle.Text, DialogType.YESNOCANCEL)
            Select Case result
                Case DialogResult.Yes
                    saveChanges(currentGameInfo)
                Case DialogResult.No
                Case DialogResult.Cancel
                    Exit Sub
            End Select
        End If
        Close()

    End Sub
    Private Sub startDrag(sender As Object, e As MouseEventArgs) Handles pnlTaskBar.MouseDown, lblViewLabel.MouseDown
        dragging = True
        prevMousePos = Cursor.Position
    End Sub
    Private Sub endDrag(sender As Object, e As MouseEventArgs) Handles pnlTaskBar.MouseUp, lblViewLabel.MouseUp
        dragging = False
        prevMousePos = Cursor.Position
    End Sub
    Private Sub Drag(sender As Object, e As MouseEventArgs) Handles pnlTaskBar.MouseMove, lblViewLabel.MouseMove
        If dragging Then
            Dim currentMousePos As Point = Cursor.Position
            Dim deltaPos As Point = New Point(currentMousePos.X - prevMousePos.X, currentMousePos.Y - prevMousePos.Y)
            prevMousePos = currentMousePos
            Location = New Point(Location.X + deltaPos.X, Location.Y + deltaPos.Y)
        End If
    End Sub
    Public Sub Run()
        Startup()
        Dim timeTaken As Decimal = frmSplash.finish()
        Debug.Print("Loaded in " & timeTaken & "s")
        Show()
        While Not toClose
            Application.DoEvents()
        End While

    End Sub
    Public Sub setPalettes()
        availablePalettes.Clear()
        availablePalettes.Add(New Palette(Palette.ColorScheme.DARK, Color.FromArgb(84, 84, 84), Color.FromArgb(64, 64, 64), Color.FromArgb(54, 54, 54), Color.Black, Color.White))
        availablePalettes.Add(New Palette(Palette.ColorScheme.LIGHT, Color.White, Color.FromArgb(200, 200, 200), Color.FromArgb(150, 150, 150), Color.FromArgb(100, 100, 100), Color.Black, Color.FromArgb(20, 20, 20)))
        availablePalettes.Add(New Palette(Palette.ColorScheme.BLUE, Color.FromArgb(21, 88, 196), Color.FromArgb(230, 230, 255), Color.FromArgb(0, 0, 150), Color.FromArgb(60, 125, 232), Color.Black, Color.FromArgb(0, 0, 80)))
        availableMenuPalettes.Add(New Palette(Palette.ColorScheme.GREEN_MENU, Color.FromArgb(60, 200, 60), Color.FromArgb(7, 158, 30), Color.FromArgb(0, 192, 0)))
        availableMenuPalettes.Add(New Palette(Palette.ColorScheme.BLUE_MENU, Color.FromArgb(7, 50, 158), Color.FromArgb(9, 30, 114), Color.FromArgb(66, 24, 165)))
    End Sub
    Public Sub loadUsedPalettes(ByVal reportProgress As Boolean)
        If reportProgress Then frmSplash.passSub("loading current palette")
        currentPalette = availablePalettes(My.Settings.colorScheme)
        currentMenuPalette = availableMenuPalettes(My.Settings.menuColorScheme)
        If reportProgress Then frmSplash.passSub("setting colors")
        refreshColor()
    End Sub
    Public Sub refreshColor()
        refreshButtonIcons()

        With currentPalette
            pnlMainWrapper.BackColor = .Stroke
            Me.BackColor = .OuterStroke
            pnlTaskBar.BackColor = .Primary
            btnRefresh.BackColor = .Primary
            btnOption.BackColor = .Primary
            btnMinimise.BackColor = .Primary
            btnRefresh.FlatAppearance.MouseOverBackColor = .Hover
            btnRefresh.FlatAppearance.MouseDownBackColor = .Hold
            btnOption.FlatAppearance.MouseOverBackColor = .Hover
            btnOption.FlatAppearance.MouseDownBackColor = .Hold
            btnMinimise.FlatAppearance.MouseOverBackColor = .Hover
            btnMinimise.FlatAppearance.MouseDownBackColor = .Hold
            pnlScroll.BackColor = .AltSecondary
            pnlScrollBar.BackColor = .Primary
            pnlMain.BackColor = .Secondary
            lblViewLabel.ForeColor = .AltText
        End With
        With currentMenuPalette
            pnlSearchTop.BackColor = .Primary
            btnSearchTab.FlatAppearance.MouseOverBackColor = .Hover
            btnSearchTab.FlatAppearance.MouseDownBackColor = .Hold

            btnReturn.FlatAppearance.MouseOverBackColor = .Hover
            btnReturn.FlatAppearance.MouseDownBackColor = .Hold
            btnClearSearch.BackColor = .Secondary
            btnClearSearch.FlatAppearance.MouseOverBackColor = .Hover
            btnClearSearch.FlatAppearance.MouseDownBackColor = .Hold

        End With
        Refresh()
    End Sub
    Private Sub refreshButtonIcons()
        If currentPalette.name = "Light" Then 'use dark icons if Light palette in use
            btnRefresh.BackgroundImage = My.Resources.refreshDark
            btnOption.BackgroundImage = My.Resources.optionDark
            btnMinimise.BackgroundImage = My.Resources.minimiseDark
        Else
            btnRefresh.BackgroundImage = My.Resources.refresh
            btnOption.BackgroundImage = My.Resources.options
            btnMinimise.BackgroundImage = My.Resources.minimise
        End If
    End Sub
    Public Sub engageDebugMode()
        If My.Settings.debugMode Then
            If Not debugForm.Visible Then
                debugForm.Show()
            End If
        Else
            debugForm.Hide()
        End If
    End Sub
    Public Sub engageFastMode()
        If My.Settings.fastMode Then
            controlMoveSpeed = 2
        Else
            controlMoveSpeed = 1
        End If
    End Sub
    Public Sub Startup()
        disableTabStop(Me)
        debugForm.ShowInTaskbar = False
        initialise()
    End Sub
    Public Sub initialise()
        loadUsedPalettes(False)

        loadInfo()

        If currentGameID = -1 Then
            setupControl()
        End If
        sortFieldLabels = {lblSortFieldTitle, lblSortFieldGenre, lblSortFieldUserRating}
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Refresh()
    End Sub
    Private Sub updateFormTitle(ByVal newTitle As String)
        Me.Text = newTitle & " - Game Collection"
        Refresh()
    End Sub
    Private Sub setupControl()
        pnlGameInfo.Parent = pnlMainWrapper
        pnlGameInfo.Location = New Point(0, 41)
        pnlGameInfo.BringToFront()
        pnlGameInfo.Visible = False
        btnSaveChanges.Location = saveChangesRightPos
        btnRevertChanges.Location = revertChangesRightPos
        Text = "All Games"
    End Sub
    Private Sub frmMain_Paint(sender As Object, e As EventArgs) Handles MyBase.Paint
        Dim attemptedTitle As String = Text
        If attemptedTitle.Length > 40 Then
            attemptedTitle = attemptedTitle.Substring(0, 40) & "..."
        End If
        lblViewLabel.Text = attemptedTitle
    End Sub
    Private Sub loadInfo()
        games.Clear()
        Using conn As OleDb.OleDbConnection = ConnectToDB()
            If conn.ConnectionString.Length > 0 Then
                Dim sqlcmd As New OleDb.OleDbCommand
                sqlcmd.Connection = conn
                sqlcmd.CommandText = "SELECT * FROM Game ORDER BY gameName ASC"
                Dim rs As OleDb.OleDbDataReader = sqlcmd.ExecuteReader
                Dim games As Boolean = False
                While rs.Read
                    games = True
                    Dim newString As String = rs("gameName")
                    Dim gameID As Integer = rs("gameID")
                    addGame(newString, False, gameID)
                End While
                If Not games Then
                    lblNoGamesFound.Show()
                    pnlSearchTop.Enabled = False
                Else
                    lblNoGamesFound.Hide()
                    pnlSearchTop.Enabled = True
                End If
            Else
                Debug.Print("ERROR - DB NOT FOUND")
            End If

        End Using
        If currentGameID = -1 Then
            setupSearchTab()
        End If
    End Sub
    Private Sub addGameLabel(ByVal newlabeltext As String)
        Dim newlabel As New Label
        newlabel.Parent = pnlMainContent
        newlabel.Text = newlabeltext
        newlabel.Height = itemHeight
        newlabel.Width = pnlMainContent.Width + 3
        newlabel.Location = New Point(-1, gameBtns.Count * itemHeight - 1)
        newlabel.BackColor = currentPalette.AltSecondary
        newlabel.ForeColor = currentPalette.AltText
        newlabel.Font = New Font("Microsoft Sans Serif", 14.25)
        newlabel.TextAlign = ContentAlignment.MiddleLeft
        gameBtns.Add(newlabel)
    End Sub
    Private Sub addGame(ByVal newgame As String, ByVal drawUserRating As Boolean, ByVal gameID As Integer, Optional orderNum As Integer = -1)
        Dim newbutton As New GameButton
        newbutton.Parent = pnlMainContent
        newbutton.FlatStyle = FlatStyle.Flat
        newbutton.BackColor = currentPalette.Secondary
        newbutton.ForeColor = currentPalette.Text
        newbutton.TextAlign = ContentAlignment.MiddleLeft
        newbutton.Font = New Font("Microsoft Sans Serif", 14.25)
        newbutton.Height = itemHeight
        newbutton.Width = pnlMainContent.Width + 3
        newbutton.FlatAppearance.MouseOverBackColor = currentMenuPalette.Hover
        newbutton.FlatAppearance.MouseDownBackColor = currentMenuPalette.Hold
        newbutton.FlatAppearance.BorderSize = 0
        newbutton.Location = New Point(-1, gameBtns.Count * itemHeight - 1)
        newbutton.Margin = New Padding(0)
        newbutton.setGameID(gameID)
        newbutton.TabStop = False
        AddHandler newbutton.Click, AddressOf selectGame
        If orderNum > 0 Then
            newbutton.Text = "        " & newgame
            Dim newlabel As New Label
            newlabel.Parent = newbutton
            newlabel.Location = New Point(0, 0)
            newlabel.Text = orderNum
            newlabel.Font = newbutton.Font
            newlabel.ForeColor = orderNumColor
        Else
            newbutton.Text = newgame
        End If
        gameBtns.Add(newbutton)
        games.Add(newgame)
        pnlMainContent.Invalidate()
        pnlMainContent.Height = gameBtns.Count * itemHeight
    End Sub
    Private Sub selectGame(clickedButton As GameButton, e As EventArgs)
        currentGameID = clickedButton.getGameID()
        updateFormTitle(clickedButton.Text)
        loadGameInfo(currentGameID)
        madeChanges = False
        pnlGameInfo.Visible = True
        searching = False
        searchTabMove(New Point(0, searchTabDownPos.Y + 40))
        txtSearch.Text = ""
        returnClickHidden()
    End Sub
    Private Sub loadGameInfo(ByVal gameID As Integer)
        Using conn As OleDb.OleDbConnection = ConnectToDB()
            Dim sqlcmd As New OleDb.OleDbCommand
            sqlcmd.Connection = conn
            sqlcmd.CommandText = "SELECT * FROM game WHERE gameID = " & gameID & ";"
            Using rs As OleDb.OleDbDataReader = sqlcmd.ExecuteReader
                If rs.Read Then
                    currentGameInfo = New GameInfo(rs("gameID"), rs("gameName"), rs("gameGenres"), rs("gamePlatformIDs"), rs("userPlayed"), rs("userRating"), rs("userComment"), rs("userCommentDate"))
                    displayCurrentGameInfo()
                    'Debug.Print("Loading gameID " & gameID & ", " & lblGameInfoTitle.Text)
                Else
                    MsgBox("Error - gameID " & gameID & "not found. Check database.")
                    Exit Sub
                End If
            End Using
            'validate title box
            With lblGameInfoTitle

            End With
        End Using
    End Sub
    Private Sub displayCurrentGameInfo()
        updateUserPlayedButton(currentGameInfo.userPlayed)
        lblGameInfoRating.Text = currentGameInfo.userRating
        lblGameInfoTitle.Text = currentGameInfo.gameTitle
        lblGameInfoDesc.Text = currentGameInfo.userComment
    End Sub
    Private Sub updateUserPlayedButton(ByVal userPlayed As Boolean)
        If userPlayed Then
            btnUserPlayed.Text = "PLAYED"
            btnUserPlayed.BackColor = Color.FromArgb(102, 255, 102)
            btnUserPlayed.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 102, 102)
            btnUserPlayed.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 255, 128)
        Else
            btnUserPlayed.Text = "UNPLAYED"
            btnUserPlayed.BackColor = Color.FromArgb(255, 102, 102)
            btnUserPlayed.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 200, 102)
            btnUserPlayed.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 128)
        End If
    End Sub
    Private Sub setupSearchTab()
        updateSearchTab(searchTabDownPos)
    End Sub
    Private Sub searchGameToggle(sender As Object, e As EventArgs) Handles btnSearchTab.Click
        btnSearchTab.Refresh()
        If Not inAnimation Then
            searching = Not searching
            If searching Then
                searchTabMove(searchTabUpPos)
            Else
                searchTabMove(searchTabDownPos)
                pnlSearch.Visible = False
                pnlSearchOption.Location = searchMenuUpPos
                moveControl(btnReturn, btnReturnRightPos, True)
                moveControl(btnClearSearch, clearSearchUpPos)
            End If
        End If
    End Sub
    Private Sub searchTabMove(ByVal endPos As Point, Optional ByVal comboAnim As Boolean = False)
        inAnimation = True
        Dim newloc As Vector2 = toVector2(pnlSearchTop.Location)
        For frame = 0 To searchTabSensitivity
            newloc = Lerp(newloc, toVector2(endPos), (2000 - frame) / 50000)
            updateSearchTab(newloc.toPoint())
            Application.DoEvents() 'magic
            updateScrollBackwards()
            System.Threading.Thread.Sleep(1) 'wait for one ms - used for smooth animation
        Next
        updateSearchTab(endPos)
        If Not comboAnim Then inAnimation = False
    End Sub
    Private Sub updateScrollBackwards()
        pnlScrollBar.Location = New Point(0, (pnlScrollBar.Height - pnlScroll.Height) / (pnlMain.Height - pnlMainContent.Height) * pnlMainContent.Location.Y)
    End Sub
    Private Sub updateSearchTab(ByVal newloc As Point)
        pnlSearchTop.Location = newloc
        pnlSearchBottom.Location = New Point(0, newloc.Y + 40)
        pnlMain.Height = newloc.Y - 2 'outline
        updateScrollBar(newloc.Y - 2)
        updateGameInfoScreen(newloc.Y)
    End Sub
    Private Sub resetViewButton(sender As Object, e As EventArgs)
        btnSearchTab.ForeColor = Color.White
    End Sub
    Private Sub updateScrollBar(ByVal barHeight As Integer)
        pnlScroll.Height = barHeight
        bufferAmount = Math.Ceiling(bufferGradient * pnlMain.Height + bufferC)
        If pnlMain.Height >= pnlMainContent.Height Then
            bufferAmount = 0
        End If
        listBoxPixelsTotal = pnlMainContent.Height + bufferAmount 'pixels total in maincontent
        listBoxPixelsShown = pnlMain.Height 'pixels shown in viewport
        If My.Settings.debugMode Then passDebug()
        pnlScrollBar.Height = listBoxPixelsShown / listBoxPixelsTotal * barHeight
        If pnlScrollBar.Location.Y > pnlScroll.Height - pnlScrollBar.Height Then
            pnlScrollBar.Location = New Point(0, pnlScroll.Height - pnlScrollBar.Height)
        End If
        If pnlScrollBar.Height = pnlScroll.Height Then
            pnlScrollBar.Location = New Point(0, 0)
        End If
        If pnlScrollBar.Location.Y < 0 Then
            pnlScrollBar.Location = New Point(0, 0)
            pnlMainContent.Location = New Point(0, 0)
        End If
    End Sub
    Private Sub passDebug() Handles pnlScrollBar.Paint
        If My.Settings.debugMode Then
            debugForm.updateReadout("pixelsTotal:        " & listBoxPixelsTotal & vbCrLf &
                                   "mainHeight:         " & pnlMain.Height & vbCrLf &
                                   "mainContentHeight:  " & pnlMainContent.Height & vbCrLf &
                                   "bufferAmount:       " & bufferAmount & vbCrLf &
                                   "scrollVisible:      " & Math.Round(pnlScrollBar.Height / pnlScroll.Height * 100, 2) & "%" & vbCrLf &
                                   "actualVisible:      " & Math.Round(pnlMain.Height / pnlMainContent.Height * 100, 2) & "%" & vbCrLf &
                                   "gameCount:          " & games.Count & vbCrLf &
                                   "inferredGameCount:  " & Math.Round(pnlMainContent.Height / itemHeight, 2) & vbCrLf &
                                   "mainContentY:       " & pnlMainContent.Location.Y & vbCrLf &
                                   "scrollBarY:         " & pnlScrollBar.Location.Y & vbCrLf &
                                   "scrollBarHeight:    " & pnlScrollBar.Height & vbCrLf &
                                   "gameInfoX:          " & pnlGameInfo.Location.X & vbCrLf &
                                   "mainContentWidth:   " & pnlMainContent.Width & vbCrLf &
                                   "mainContentX:       " & pnlMainContent.Location.X & vbCrLf &
                                   "mainContentVisible: " & pnlMainContent.Visible & vbCrLf &
                                   "mainX:              " & pnlMain.Location.X)
        End If


    End Sub
    Private Sub scrollStart(sender As Object, e As MouseEventArgs) Handles pnlScrollBar.MouseDown
        scrolling = True
        prevMousePos = Cursor.Position
    End Sub
    Private Sub scrollEnd(sender As Object, e As MouseEventArgs) Handles pnlScrollBar.MouseUp
        scrolling = False
        prevMousePos = Cursor.Position
    End Sub
    Private Sub scrollEnter(sender As Object, e As EventArgs) Handles pnlScrollBar.MouseEnter
        pnlScrollBar.BackColor = currentPalette.Hover
    End Sub
    Private Sub scrollHover(sender As Object, e As EventArgs) Handles pnlScrollBar.MouseLeave
        pnlScrollBar.BackColor = currentPalette.Primary
    End Sub
    Private Sub updateScrollWheel(ByVal delta As Integer)
        If pnlScrollBar.Height = pnlScroll.Height Then
            pnlScrollBar.Location = New Point(0, 0)
        Else
            Dim scrolly As Integer
            Dim deltaPixel As Integer = -delta * scrollGap / 120
            If deltaPixel < 0 Then
                If pnlScrollBar.Location.Y <= 0 Then
                    deltaPixel = 0
                End If
            ElseIf deltaPixel > 0 Then
                If pnlScrollBar.Location.Y >= pnlScroll.Height - pnlScrollBar.Height Then
                    deltaPixel = 0
                End If
            End If
            If pnlScrollBar.Location.Y < 0 Then
                scrolly = 0
            ElseIf scrolly > pnlScroll.Height - pnlScrollBar.Height Then
                scrolly = pnlScroll.Height - pnlScrollBar.Height
            Else
                scrolly = pnlScrollBar.Location.Y + deltaPixel
            End If
            pnlScrollBar.Location = New Point(pnlScrollBar.Location.X, scrolly)
        End If
    End Sub
    Private Sub wheelScroll(sender As Object, e As MouseEventArgs) Handles MyBase.MouseWheel
        If pnlScroll.Height > pnlScrollBar.Height Then
            updateScrollWheel(e.Delta)
            validateScrollBar()
        End If
        If My.Settings.debugMode Then passDebug()
    End Sub
    Private Shadows Sub Scroll(sender As Object, e As MouseEventArgs) Handles pnlScrollBar.MouseMove
        If scrolling And pnlScroll.Height > pnlScrollBar.Height Then
            updateScrollBarScroll()
            updateListScroll()
        End If
        passDebug()
    End Sub
    Private Sub updateScrollBarScroll()
        If pnlScroll.Height > pnlScrollBar.Height Then
            Dim currentMousePos As Point = Cursor.Position
            Dim scrollY As Integer
            Dim deltaPos As Point = New Point(currentMousePos.X - prevMousePos.X, currentMousePos.Y - prevMousePos.Y)
            prevMousePos = currentMousePos
            If deltaPos.Y < 0 Then
                If pnlScrollBar.Location.Y <= 0 Then
                    deltaPos = New Point(0, 0)
                End If
            ElseIf deltaPos.Y > 0 Then
                If pnlScrollBar.Location.Y >= pnlScroll.Height - pnlScrollBar.Height Then
                    deltaPos = New Point(0, 0)
                End If
            End If
            If pnlScrollBar.Location.Y < 0 Then
                scrollY = 0
            ElseIf scrollY > pnlScroll.Height - pnlScrollBar.Height Then
                scrollY = pnlScroll.Height - pnlScrollBar.Height
            Else
                scrollY = pnlScrollBar.Location.Y + deltaPos.Y
            End If
            pnlScrollBar.Location = New Point(pnlScrollBar.Location.X, scrollY)
        Else
            validateScrollBar()
        End If
    End Sub
    Private Sub updateListScroll()
        Dim divisor As Decimal = pnlScrollBar.Height - pnlScroll.Height
        If divisor = 0 Then divisor = 1
        pnlMainContent.Location = New Point(pnlMainContent.Location.X, 1 - (pnlMain.Height - pnlMainContent.Height) / (divisor) * pnlScrollBar.Location.Y)
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        searchOption(MenuOption.Search)
    End Sub
    Private Sub btnClearSearch_Click() Handles btnClearSearch.Click
        txtSearch.Text = ""
        txtSearch.Focus()
    End Sub
    Private Sub searchOption(ByVal menu As MenuOption)
        adhocSearching = False
        Dim showClear As Boolean = False
        Select Case menu
            Case MenuOption.Search
                pnlSearch.Visible = True
                pnlFilter.Visible = False
                pnlSort.Visible = False
                txtSearch.Focus()
                adhocSearching = True
                showClear = True
            Case MenuOption.Filter
                pnlSearch.Visible = False
                pnlFilter.Visible = True
                pnlSort.Visible = False
            Case MenuOption.Sort
                pnlSearch.Visible = False
                pnlFilter.Visible = False
                pnlSort.Visible = True
        End Select
        moveControl(pnlSearchOption, searchMenuDownPos)
        moveControl(btnReturn, btnReturnLeftPos)
        If showClear Then moveControl(btnClearSearch, clearSearchDownPos)
    End Sub
    Private Enum MenuOption
        Search
        Filter
        Sort
    End Enum
    Private Sub searchType(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = Chr(13) Then
            If gameBtns.Count = 1 Then
                selectGame(gameBtns(0), New EventArgs)
            Else
                returnClick()
            End If
            e.Handled = True
        ElseIf e.KeyChar = Chr(8) Or e.KeyChar = Chr(39) Or e.KeyChar = Chr(32) Then
            Exit Sub
        Else
            Dim keyPress As String = e.KeyChar.ToString.ToUpper
            If Asc(keyPress) < 65 Or Asc(keyPress) > 90 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub ignoreArrowKeys(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        e.Handled = True
    End Sub
    Private Sub searchTextChanged() Handles txtSearch.TextChanged
        If txtSearch.TextLength = 0 Then
            lblSearch.Text = "ENTER SEARCH TERM"
            lblSearch.ForeColor = Color.White
        Else
            lblSearch.Text = txtSearch.Text.ToUpper
            lblSearch.ForeColor = Color.Lime
        End If
        lblSearch.Refresh()
        updateInfo()
    End Sub
    Private Sub runQuery(ByVal param() As String) 'searchText, sortField, sortDir, filterField, filter
        Using conn As OleDb.OleDbConnection = ConnectToDB()
            Dim sqlcmd As New OleDb.OleDbCommand
            sqlcmd.Connection = conn
            sqlcmd.CommandText = "SELECT gameID, gameName, " & param(1) & " FROM game WHERE gameName LIKE @gameNameParam ORDER BY " & param(1) & " " & param(2) & ";"
            'Debug.Print("SELECT gameName FROM game WHERE gameName LIKE ""%" & param(0) & "%"" ORDER BY " & param(1) & " " & param(2) & ";")
            sqlcmd.Parameters.AddWithValue("@gameNameParam", "%" & param(0) & "%")
            Dim rs As OleDb.OleDbDataReader = sqlcmd.ExecuteReader
            gameBtns.Clear()
            games.Clear()
            pnlMainContent.Controls.Clear()
            Select Case param(1)
                Case "gameName"
                    While rs.Read
                        Dim newString As String = rs("gameName")
                        Dim gameID As Integer = rs("gameID")
                        addGame(newString, False, gameID)
                    End While
                Case "gameGenres"
                    Dim currentGenre As String = ""
                    While rs.Read
                        Dim nextGenre As String = rs("gameGenres")
                        If currentGenre <> nextGenre Then
                            currentGenre = nextGenre
                            addGameLabel("  " & currentGenre)
                        End If
                        Dim newString As String = rs("gameName")
                        Dim gameID As Integer = rs("gameID")
                        addGame(newString, False, gameID)
                    End While
                Case "userRating"
                    While rs.Read
                        Dim newString As String = rs("gameName")
                        Dim gameID As Integer = rs("gameID")
                        addGame(newString, False, gameID)
                    End While
            End Select
            pnlMainContent.Update()
            updateScrollBar(pnlMain.Height)
            validateScrollBar()
        End Using
    End Sub
    Private Sub updateInfo()
        Dim sortDir As String
        If ascendingOrder Then
            sortDir = "ASC"
        Else
            sortDir = "DESC"
        End If
        Dim sortField As String = "gameName"
        Select Case sortFieldLabels(currentSortFieldNum).Text
            Case "Title"
                sortField = "gameName"
            Case "Genre"
                sortField = "gameGenres"
            Case "User Rating"
                sortField = "userRating"
        End Select
        runQuery({txtSearch.Text, sortField, sortDir})
    End Sub
    Private Sub moveControl(ByRef controlled As Control, ByVal endPos As Point, Optional ByVal updateMain As Boolean = False, Optional ByVal comboAnim As Boolean = False)
        inAnimation = True
        Dim newloc As Vector2 = toVector2(controlled.Location)
        For frame = 0 To controlMoveSensitivity / controlMoveSpeed
            newloc = Lerp(newloc, toVector2(endPos), (2000 - frame) / 50000 * controlMoveSpeed)
            controlled.Location = newloc.toPoint()
            If updateMain Then
                updateMainPanel()
            End If
            If controlled.Location = endPos Then
                Exit For 'optimisation
            End If
            Application.DoEvents() 'magic
            System.Threading.Thread.Sleep(1) 'wait for one ms - used for smooth animation
        Next
        controlled.Location = endPos
        If Not comboAnim Then inAnimation = False
    End Sub
    Private Sub updateMainPanel()
        pnlMainContent.Location = New Point(0, 0)
        pnlMainContent.Width = pnlMain.Width - pnlMainContent.Location.X
        If My.Settings.debugMode Then passDebug()
        pnlMainContent.BringToFront()
    End Sub
    Private Sub returnClick() Handles btnReturn.Click
        moveControl(btnReturn, btnReturnRightPos)
        If btnClearSearch.Location.Y <> clearSearchUpPos.Y Then
            moveControl(btnClearSearch, clearSearchUpPos)
        End If
        moveControl(pnlSearchOption, searchMenuUpPos)
    End Sub
    Private Sub returnClickHidden() Handles btnReturn.Click
        btnReturn.Location = btnReturnRightPos
        btnClearSearch.Location = clearSearchUpPos
        pnlSearchOption.Location = searchMenuUpPos
    End Sub
    Private Sub validateScrollBar()
        If pnlScrollBar.Location.Y + pnlScrollBar.Height > pnlScroll.Height Then
            pnlScrollBar.Location = New Point(0, pnlScroll.Height - pnlScrollBar.Height)
        End If
        If pnlScrollBar.Location.Y < 0 Then
            pnlScrollBar.Location = New Point(0, 0)
        End If
        updateListScroll()
    End Sub
    Private Sub sortFieldRight() Handles btnSortFieldRight.Click
        If currentSortFieldNum < 2 Then
            forceDisableSortFieldButtons()
            currentSortFieldNum += 1
            moveControl(pnlSortLabels, sortFieldPoints(currentSortFieldNum))
            updateInfo()
            enableSortFieldButtons()
        End If
    End Sub
    Private Sub sortFieldLeft() Handles btnSortFieldLeft.Click
        If currentSortFieldNum > 0 Then
            forceDisableSortFieldButtons()
            currentSortFieldNum -= 1
            moveControl(pnlSortLabels, sortFieldPoints(currentSortFieldNum))
            updateInfo()
            enableSortFieldButtons()
        End If
    End Sub
    Private Sub forceDisableSortFieldButtons()
        btnSortFieldLeft.Enabled = False
        btnSortFieldRight.Enabled = False
    End Sub
    Private Sub enableSortFieldButtons()
        If currentSortFieldNum > 0 Then
            btnSortFieldLeft.Enabled = True
            btnSortFieldLeft.BackgroundImage = My.Resources.leftArrow
        Else
            btnSortFieldLeft.BackgroundImage = My.Resources.leftArrowDark
        End If
        If currentSortFieldNum < 2 Then
            btnSortFieldRight.Enabled = True
            btnSortFieldRight.BackgroundImage = My.Resources.rightArrow
        Else
            btnSortFieldRight.BackgroundImage = My.Resources.rightArrowDark
        End If
    End Sub
    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click
        searchOption(MenuOption.Sort)
    End Sub
    Private Sub btnSortDirection_Click(sender As Object, e As EventArgs) Handles btnSortDirection.Click
        ascendingOrder = Not ascendingOrder
        If ascendingOrder Then
            btnSortDirection.Text = "ASCENDING"
        Else
            btnSortDirection.Text = "DESCENDING"
        End If
        updateInfo()
    End Sub
    Private Sub focusSearch(sender As Object, e As EventArgs) Handles lblSearch.Click, pnlSearchBar.Click
        txtSearch.Focus()
    End Sub
    Private Sub updateGameInfoScreen(ByVal screenHeight As Integer)
        pnlGameInfo.Height = screenHeight
    End Sub
    Private Sub backClick(sender As Object, e As EventArgs) Handles btnBack.Click
        If editing And madeChanges Then
            Dim result As DialogResult = frmConfirmationDialog.runDialog("Save Changes", "Save your changes to the record ", lblGameInfoTitle.Text, DialogType.YESNOCANCEL)
            Select Case result
                Case DialogResult.Yes
                    saveChanges(currentGameInfo)
                Case DialogResult.No
                Case DialogResult.Cancel
                    Exit Sub
            End Select
        End If
        currentGameID = -1
        updateFormTitle("All Games")
        editing = False
        pnlMainContent.Visible = True
        pnlGameInfo.Visible = False
        disableEditingHidden()
        searchTabMove(searchTabDownPos)
    End Sub
    Private Sub editRecordClick(sender As Object, e As EventArgs) Handles btnEditRecord.Click
        If Not editing Then
            editing = True
            enableEditing()
        End If
    End Sub
    Private Sub enableEditing()
        btnEditRecord.Enabled = False
        btnUserPlayed.Enabled = True
        moveControl(btnEditRecord, editRecordDownPos)
        moveControl(btnSaveChanges, saveChangesLeftPos)
        moveControl(btnRevertChanges, revertChangesLeftPos)
    End Sub
    Private Sub disableEditingS()
        btnUserPlayed.Enabled = False
        moveControl(btnSaveChanges, saveChangesRightPos)
        moveControl(btnRevertChanges, revertChangesRightPos)
        moveControl(btnEditRecord, editRecordUpPos)
        btnEditRecord.Enabled = True
    End Sub
    Private Sub disableEditingR()
        btnUserPlayed.Enabled = False
        moveControl(btnRevertChanges, revertChangesRightPos)
        moveControl(btnSaveChanges, saveChangesRightPos)
        moveControl(btnEditRecord, editRecordUpPos)
        btnEditRecord.Enabled = True
    End Sub
    Private Sub disableEditingHidden()
        btnUserPlayed.Enabled = False
        btnRevertChanges.Location = revertChangesRightPos
        btnSaveChanges.Location = saveChangesRightPos
        btnEditRecord.Location = editRecordUpPos
        btnEditRecord.Enabled = True
    End Sub
    Private Sub saveChanges(ByRef newGameInfo As GameInfo)
        Using conn As OleDb.OleDbConnection = ConnectToDB()
            Dim sqlcmd As New OleDb.OleDbCommand
            sqlcmd.Connection = conn
            sqlcmd.CommandText = "UPDATE game SET userPlayed = @user_played, userComment = @user_comment, userRating = @user_rating WHERE gameID = " & currentGameID & ";"
            sqlcmd.Parameters.AddWithValue("@user_played", newGameInfo.userPlayed)
            sqlcmd.Parameters.AddWithValue("@user_comment", newGameInfo.userComment)
            sqlcmd.Parameters.AddWithValue("@user_rating", newGameInfo.userRating)
            sqlcmd.ExecuteNonQuery()
        End Using
        madeChanges = False
    End Sub
    Private Sub revertChanges()
        loadGameInfo(currentGameID)
        madeChanges = False
    End Sub
    Private Sub btnSaveChanges_Click(sender As Object, e As EventArgs) Handles btnSaveChanges.Click
        If editing Then
            saveChanges(currentGameInfo)
            editing = False
            disableEditingS()
        End If
    End Sub
    Private Sub btnRevertChanges_Click(sender As Object, e As EventArgs) Handles btnRevertChanges.Click
        If editing Then
            revertChanges()
            editing = False
            disableEditingR()
        End If
    End Sub
    Private Sub btnUserPlayed_Click(sender As Object, e As EventArgs) Handles btnUserPlayed.Click
        If editing Then
            If btnUserPlayed.Text.ToLower = "played" Then
                updateUserPlayedButton(False)
                applyEdit(New GameEdit(EditType.USER_PLAYED, False))
            Else
                updateUserPlayedButton(True)
                applyEdit(New GameEdit(EditType.USER_PLAYED, True))
            End If
            madeChanges = True
        End If
    End Sub
    Private Sub resetAll()
        games.Clear()
        gameBtns.Clear()
        pnlMainContent.Controls.Clear()
        pnlMainContent.Refresh()
        pnlSortLabels.Location = sortFieldPoints(0)
        currentSortFieldNum = 0
    End Sub
    Private Sub btnOption_Click(sender As Object, e As EventArgs) Handles btnOption.Click
        If searching Then
            searchGameToggle(Me, e)
        End If
        frmPreferences.displayPrefs()
        resetAll()
        Debug.Print("after resetAll: " & gameBtns.Count)
        engageDebugMode()

        engageFastMode()
        initialise()

    End Sub
    Private Sub gameRatingMouseEnter() Handles lblGameInfoRating.MouseEnter
        If editing Then
            pnlGameInfoRating.BackColor = gameInfoHoverColor
        End If
    End Sub
    Private Sub gameRatingMouseLeave() Handles lblGameInfoRating.MouseLeave
        If editing Then
            pnlGameInfoRating.BackColor = gameInfoNormalColor
        End If
    End Sub
    Private Sub gameRatingClick() Handles lblGameInfoRating.Click
        If editing Then
            Dim newedit As GameEdit = frmGameEditDialog.runEditDialog("Change Rating", "Input the new value for User Rating", EditType.USER_RATING, currentGameInfo.userRating)
            applyEdit(newedit)
        End If
    End Sub
    Private Sub applyEdit(ByRef newEdit As GameEdit)
        Select Case newEdit.infoType
            Case EditType.USER_RATING
                currentGameInfo.userRating = newEdit.newInt
            Case EditType.USER_COMMENT
                currentGameInfo.userComment = newEdit.newText
            Case EditType.GAME_TAGS
                currentGameInfo.gameTags = newEdit.newText
            Case EditType.USER_PLAYED
                currentGameInfo.userPlayed = newEdit.newBool
                Exit Sub
        End Select
        displayCurrentGameInfo()
        Select Case newEdit.infoType
            Case EditType.USER_RATING
                colorFadeNotify(pnlGameInfoRating)
            Case EditType.USER_COMMENT
                colorFadeNotify(pnlGameInfoDesc)
            Case EditType.GAME_TAGS
                colorFadeNotify(pnlGameTags)
            Case Else

        End Select
    End Sub
    Private Sub colorFade(ByRef controlled As Control, ByVal endCol As Color, Optional ByVal speed As Decimal = 1, Optional ByVal comboFade As Boolean = False)
        fading = True
        Dim newCol As Vector3 = toVector3(controlled.BackColor)
        For frame = 0 To controlFadeSensitivity
            newCol = Vector3Lerp(newCol, toVector3(endCol), (2000 - frame * speed) / 50000)
            controlled.BackColor = newCol.toColor()
            If controlled.BackColor = endCol Then
                Exit For 'optimisation
            End If
            Application.DoEvents() 'magic
            System.Threading.Thread.Sleep(1) 'wait for one ms - used for smooth animation
        Next
        controlled.BackColor = endCol
        If Not comboFade Then fading = False
    End Sub
    Private Sub colorFadeNotify(ByRef controlled As Control)
        If Not fading Then
            Dim returnColor As Color = controlled.BackColor
            colorFade(controlled, notifyFlashColor, 2, True)
            colorFade(controlled, returnColor, 1 / fadeOutMultiplier)
        End If
    End Sub
    Private Overloads Sub Close()
        toClose = True
    End Sub
End Class