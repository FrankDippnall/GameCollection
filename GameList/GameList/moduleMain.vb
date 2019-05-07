Imports GameList.Palette

Module moduleMain
    Private FileLocation As String = "GameCollection.mdb"
    Public Function ConnectToDB() As OleDb.OleDbConnection
        'Instantiates an OleDB connection to the InsuranceCompanyDB.mbd file.
        'Returns an open OleDBConnection object for use with SQL statements.
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FileLocation)
        Try
            conn.Open()
        Catch ex As OleDb.OleDbException
            Throw New Exception("Database not found in directory.")
        End Try
        Return conn
    End Function
    Public Function checkDBExists() As Boolean
        'Instantiates an OleDB connection to the InsuranceCompanyDB.mbd file.
        'Returns an open OleDBConnection object for use with SQL statements.
        Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FileLocation)
        Try
            conn.Open()
        Catch ex As OleDb.OleDbException
            Return False
        End Try
        Return True
    End Function
    Public Class Vector2
        Public x, y As Decimal
        Public Sub New(ByVal newx As Decimal, ByVal newy As Decimal)
            x = newx
            y = newy
        End Sub
        Public Function toPoint() As Point
            Return New Point(Math.Floor(x), Math.Floor(y))
        End Function
    End Class
    Public Function Lerp(startVal As Vector2, endVal As Vector2, duration As Decimal) As Vector2
        Return New Vector2(startVal.x + (endVal.x - startVal.x) * duration, startVal.y + (endVal.y - startVal.y) * duration)
    End Function
    Public Function toVector2(ByVal p As Point)
        Return New Vector2(p.X, p.Y)
    End Function
    Public Class Vector3
        Public x, y, z As Decimal
        Public Sub New(ByVal newx As Decimal, ByVal newy As Decimal, ByVal newz As Decimal)
            x = newx
            y = newy
            z = newz
        End Sub
        Public Function toColor() As Color
            Return Color.FromArgb(Math.Floor(x), Math.Floor(y), Math.Floor(z))
        End Function
    End Class
    Public Function Vector3Lerp(startVal As Vector3, endVal As Vector3, duration As Decimal) As Vector3
        Return New Vector3(startVal.x + (endVal.x - startVal.x) * duration, startVal.y + (endVal.y - startVal.y) * duration, startVal.z + (endVal.z - startVal.z) * duration)
    End Function
    Public Function toVector3(ByVal p As Color)
        Return New Vector3(p.R, p.G, p.B)
    End Function
    Public Class GameButton
        Inherits Button
        Private gameID As Integer = 0
        Public Sub setGameID(ByVal newID As Integer)
            gameID = newID
        End Sub
        Public Function getGameID() As Integer
            Return gameID
        End Function
    End Class
    Public Class CheckButton
        Inherits Button
        Private checked As Boolean = False
        Public checkImg As Image = My.Resources.check
        Public Sub initialise(ByRef newparent As Panel)
            Parent = newparent
            FlatStyle = FlatStyle.Flat
            FlatAppearance.BorderColor = Color.White
            FlatAppearance.BorderSize = 2
            FlatAppearance.MouseOverBackColor = Color.FromArgb(74, 74, 74)
            FlatAppearance.MouseDownBackColor = Color.FromArgb(84, 84, 84)
            BackColor = Color.FromArgb(64, 64, 64)
            SetStyle(ControlStyles.Selectable, False)
            Size = New Size(30, 30)
            Location = New Point(newparent.Width - 38, (newparent.Height - Size.Height) / 2)
        End Sub
        Public Sub check()
            checked = True
            BackgroundImage = checkImg
        End Sub
        Public Sub uncheck()
            checked = False
            BackgroundImage = Nothing
        End Sub
        Public Function isChecked() As Boolean
            Return (checked)
        End Function
        Public Sub toggleChecked()
            If checked Then
                uncheck()
            Else
                check()
            End If
        End Sub
    End Class
    Public Class OptionPanel
        Inherits Panel
        Public assignedOption As MacroOption
        Public helpText As String = "<UNDEFINED>"
    End Class
    Public Enum OptionType
        CHECKBOX
        NUMBER
        DROPDOWN
    End Enum
    Public Enum MacroOption
        SHOW_ORDER_NUMS
        FAST_MODE
        DEBUG_MODE
        COLOR_SCHEME
        MENU_COLOR_SCHEME
    End Enum
    Public Class GameInfo
        Private gameID As Integer
        Public gameTitle As String
        Public gameTags As String
        Public gamePlatform As String
        Public userPlayed As Boolean
        Public userRating As Integer
        Public userComment As String
        Public userCommentDate As Date
        Public Sub New(ByVal gameID As Integer, ByVal gameTitle As String, ByVal gameTags As String, ByVal gamePlatform As String, ByVal userPlayed As Boolean, ByVal userRating As Integer, ByVal userComment As String, ByVal usercommentdate As Date)
            Me.gameID = gameID
            Me.gameTitle = gameTitle
            Me.gameTags = gameTags
            Me.gamePlatform = gamePlatform
            Me.userPlayed = userPlayed
            Me.userRating = userRating
            Me.userComment = userComment
            Me.userCommentDate = usercommentdate
        End Sub
        Public Function getGameID() As Integer
            Return gameID
        End Function
    End Class
    Public Sub disableTabStop(ByRef parent As Control)
        For i = 0 To parent.Controls.Count - 1
            disableTabStop(parent.Controls(i))
        Next
        parent.TabStop = False
        'Debug.Print("Disabled TabStop of control '" & parent.Name & "'")
    End Sub
    Public Sub resolveDatabaseName()
        Dim applicationPath As String = Application.StartupPath
        Debug.Print("APPLICATION PATH: " & applicationPath)
    End Sub
    Private Sub mainInitialiseSequence()
        frmSplash.Show()
        frmSplash.lbl_versionNo.Text = "Version " & Application.ProductVersion
        frmSplash.start()
        For currentJob = 1 To 3 'no. things to do.
            'INITIALISATION SEQUENCE
            Threading.Thread.Sleep(500)
            Select Case currentJob
                Case 1 'setting load
                    frmSplash.pass("Loading Settings")
                    For currentSubJob = 1 To 3
                        Select Case currentSubJob
                            Case 1 'render order num check
                                frmSplash.passSub("show order nums")
                            Case 2 'fast mode check
                                frmSplash.passSub("fast mode")
                                frmMain.engageFastMode()
                            Case 3 'debug mode check
                                frmSplash.passSub("debug mode")
                                frmMain.engageDebugMode()
                        End Select
                        Application.DoEvents()
                    Next
                Case 2
                    frmSplash.pass("Setting up Preferences")
                    For currentSubJob = 1 To 3
                        Select Case currentSubJob
                            Case 1 'initialise preferences
                                frmSplash.passSub("initialising")
                                frmPreferences.initialise(True)
                            Case 2
                                frmSplash.passSub("loading palettes")
                                frmMain.setPalettes()
                                frmMain.loadUsedPalettes(True)
                            Case 3
                        End Select
                        Application.DoEvents()
                    Next

                Case 3
                    frmSplash.pass("Accessing Database")
                    For currentSubJob = 1 To 3
                        Select Case currentSubJob
                            Case 1 'check db exists
                                frmSplash.passSub("checking if database exists")
                                If checkDBExists() Then
                                    Exit For
                                End If
                            Case 2
                                frmSplash.passSub("creating database")
                                'create new db
                                CreateDatabase()
                            Case 3
                                'initialise database
                                frmSplash.passSub("initialising database")
                                InitialiseDatabase()
                        End Select
                        Application.DoEvents()
                    Next
                Case Else
                    frmSplash.pass("Finalizing")
            End Select
            Application.DoEvents()
        Next
        frmSplash.pass("Finished!", True)
        Threading.Thread.Sleep(200)

    End Sub
    Sub CreateDatabase()
        On Error GoTo CreateDatabaseError

        Dim cat As New ADOX.Catalog
        cat.Create("Provider='Microsoft.Jet.OLEDB.4.0';Data Source='" & FileLocation & "'")


        'Clean up  
        cat = Nothing
        Exit Sub

CreateDatabaseError:
        cat = Nothing
        Debug.Print("Oops! something went wrong while creating the database.")
    End Sub
    Sub InitialiseDatabase()
        Using conn As OleDb.OleDbConnection = ConnectToDB()
            If conn.ConnectionString.Length > 0 Then
                Dim sqlcmd As New OleDb.OleDbCommand
                sqlcmd.Connection = conn
                sqlcmd.CommandText = "CREATE TABLE Game (gameID AUTOINCREMENT PRIMARY KEY, gameName VARCHAR(255), gameGenres LONGTEXT, gameLink VARCHAR(255), gamePlatformIDs VARCHAR(255), userPlayed BIT, userRating NUMBER, userComment LONGTEXT, userCommentDate DATE)"
                sqlcmd.ExecuteNonQuery()

            Else
                Debug.Print("ERROR - DB NOT FOUND")
            End If

        End Using
    End Sub
    Public Sub Main()
        mainInitialiseSequence()
        frmMain.Run()
        My.Settings.Save()
    End Sub
    Public Class CustomComboBox
        Inherits Control
        Public associatedOption As MacroOption
        Private dropDownPanel As Panel
        Public ComboItems As ComboOption()
        Private currentIndex As Integer = 0
        Private mainControlBounds As Rectangle
        Public currentItem As ComboOption
        Public Sub initialise(ByRef newcontainer As Panel)
            Parent = newcontainer.Parent
            BackColor = Color.FromArgb(64, 64, 64)
            SetStyle(ControlStyles.Selectable, False)
            Size = New Size(150, 30)
            Font = New Font(New FontFamily("Calibri"), 16, FontStyle.Regular)
            ForeColor = Color.White
            Location = New Point(newcontainer.Location.X + newcontainer.Width - (Size.Width + 8), newcontainer.Location.Y + (newcontainer.Height - 30) / 2)
            SetStyle(ControlStyles.UserPaint, True)
            mainControlBounds = Bounds
            instantiateDropDownPanel()
        End Sub
        Public Sub selectItem(ByVal newindex As Integer)
            currentIndex = newindex
            currentItem = ComboItems(newindex)
        End Sub
        Public Function selectedItem() As ComboOption
            Return ComboItems(currentIndex)
        End Function
        Private isDroppedDown As Boolean = False
        Private Sub draw(sender As Object, e As PaintEventArgs) Handles Me.Paint
            Dim borderPen As Pen = New Pen(Color.White, 3)
            Dim borderPen2 As Pen = New Pen(Color.White, 2)
            Dim fillBrush As SolidBrush = New SolidBrush(Color.FromArgb(64, 64, 64))
            Dim emSize As Integer = 16
            Dim textFont As Font = New Font(New FontFamily("Calibri"), emSize, FontStyle.Regular)
            Dim textBrush As Brush = Brushes.White
            Dim prClip As Rectangle = New Rectangle(e.ClipRectangle.Location, New Size(e.ClipRectangle.Size.Width - 1, e.ClipRectangle.Size.Height - 1))
            Dim textLoc As Point = New Point(2, 2)
            Dim arrowLoc As Point = New Point(prClip.Width - 30, 0)
            e.Graphics.FillRectangle(fillBrush, prClip)
            e.Graphics.DrawRectangle(borderPen, prClip)
            e.Graphics.DrawString(ComboItems(currentIndex).displayString, textFont, textBrush, textLoc)
            If isDroppedDown Then
                e.Graphics.DrawImage(My.Resources.cmbDownArrow, arrowLoc)
                e.Graphics.DrawLine(borderPen2, New Point(0, mainControlBounds.Height - 1), New Point(mainControlBounds.Width, mainControlBounds.Height - 1))
            Else
                e.Graphics.DrawImage(My.Resources.cmbLeftArrow, arrowLoc)
            End If

        End Sub
        Private Const itemHeight As Integer = 30
        Private Sub handleClick() Handles Me.Click
            toggleDropDown()
            RaiseEvent radioDropDown(Me, New EventArgs)
            BringToFront()
            Refresh()
        End Sub
        Public Sub resetDropDown()
            If isDroppedDown Then
                toggleDropDown()
            End If
        End Sub
        Private Sub toggleDropDown()
            isDroppedDown = Not isDroppedDown
            If isDroppedDown Then
                Me.Bounds = New Rectangle(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height + itemHeight * ComboItems.Count)
            Else
                Me.Bounds = mainControlBounds
            End If
            Refresh()
        End Sub
        Public realTimeUpdates As Boolean
        Public Sub New(ByVal associatedOption As MacroOption)
            Me.associatedOption = associatedOption
            Select Case associatedOption
                Case MacroOption.COLOR_SCHEME
                    ComboItems = {New ComboOption("Dark", ColorScheme.DARK, 0), New ComboOption("Light", ColorScheme.LIGHT, 1), New ComboOption("Blue", ColorScheme.BLUE, 2)}
                    realTimeUpdates = True
                Case MacroOption.MENU_COLOR_SCHEME
                    ComboItems = {New ComboOption("Green", ColorScheme.GREEN_MENU, 0), New ComboOption("Blue", ColorScheme.BLUE_MENU, 1)}
                Case Else
                    Throw New Exception("Non-dropdown option loaded using dropdown setting.")
            End Select

        End Sub
        Private optionBtns As New List(Of DropDownButton)
        Public Event radioDropDown(sender As Object, e As EventArgs)

        Private Sub instantiateDropDownPanel()
            dropDownPanel = New Panel
            With dropDownPanel
                .Parent = Me
                .Width = Width
                .Height = itemHeight * ComboItems.Length
                .Location = New Point(0, Height)
                '.BackColor = Me.BackColor
                .BackColor = Color.FromArgb(84, 84, 84)
                .BringToFront()
                optionBtns.Clear()
                For index = 0 To ComboItems.Length - 1
                    Dim newOption As DropDownButton = New DropDownButton(index, ComboItems(index).displayString, New Point(0, itemHeight * .Controls.Count), New Size(Width, itemHeight))
                    .Controls.Add(newOption)
                    optionBtns.Add(newOption)
                    AddHandler newOption.Click, AddressOf optionBtnClick
                Next
            End With
        End Sub
        Private Sub optionBtnClick(clickedOp As DropDownButton, e As EventArgs)
            toggleDropDown()
            selectItem(clickedOp.optionIndex)
            Refresh()
        End Sub

    End Class
    Public Class DropDownButton
        Inherits Button
        Public optionIndex As Integer
        Public Sub New(ByVal optionIndex As Integer, ByVal text As String, ByVal location As Point, ByVal size As Size)
            Me.optionIndex = optionIndex
            Me.Location = location
            Me.Text = text
            Me.Size = size
            initialise()
        End Sub
        Private Sub initialise()
            FlatStyle = FlatStyle.Flat
            FlatAppearance.BorderSize = 0
        End Sub
    End Class
    Public Class ComboOption
        Public displayString As String
        Public associatedValue As Object
        Public associatedIndex As Integer
        Public Sub New(ByVal displayString As String, ByVal associatedValue As Object, ByVal associatedIndex As Integer)
            Me.displayString = displayString
            Me.associatedValue = associatedValue
            Me.associatedIndex = associatedIndex
        End Sub
        Public Sub New()
            Me.displayString = ""
            Me.associatedValue = ""
            associatedIndex = -1
        End Sub
        Public Overrides Function ToString() As String
            Return displayString
        End Function
    End Class


End Module
