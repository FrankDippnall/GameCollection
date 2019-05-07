Public Class frmPreferences
    Private dragging As Boolean
    Private prevMousePos As Point
    Private checkbuttons As New List(Of CheckButton)
    Private dropdowns As New List(Of CustomComboBox)
    Private optionPanels As New List(Of Panel)
    Private optionHeight As Integer = 40
    Private optionSpacingX As Integer = 16
    Private optionSpacingY As Integer = 12
    Private madeChanges As Boolean = False
    Public Sub initialise(ByVal reportProgress As Boolean)
        updateTitle("Preferences")
        optionPanels.Clear()
        generateOptions(reportProgress)
    End Sub
    Private Sub updateTitle(ByVal newtitle)
        Me.Text = newtitle
        lblDialogTitle.Text = newtitle
    End Sub
    Private Sub generateOptions(ByVal reportProgress As Boolean)
        checkbuttons = New List(Of CheckButton)
        If reportProgress Then frmSplash.passSub("checkboxes")
        createOption("Show Order Numbers", "Number the games in search tool.", OptionType.CHECKBOX, MacroOption.SHOW_ORDER_NUMS)
        createOption("Fast Mode", "Speed up menu animation to x2 speed.", OptionType.CHECKBOX, MacroOption.FAST_MODE)
        createOption("Debug Mode", "Display developer debug info.", OptionType.CHECKBOX, MacroOption.DEBUG_MODE)
        If reportProgress Then frmSplash.passSub("primary color scheme")
        createOption("Primary Color Palette", "Color scheme for program window.", OptionType.DROPDOWN, MacroOption.COLOR_SCHEME)
        If reportProgress Then frmSplash.passSub("secondary color scheme")
        createOption("Secondary Color Palette", "Color scheme for search tool window.", OptionType.DROPDOWN, MacroOption.MENU_COLOR_SCHEME)
    End Sub
    Private Sub createOption(ByVal optionName As String, ByVal optionHelpText As String, ByVal oType As OptionType, ByVal assignedOption As MacroOption)
        Dim optionpanel As New OptionPanel
        optionpanel.Parent = pnlMainWrapper
        optionpanel.Location = New Point(optionSpacingX, 40 + optionSpacingY + (optionSpacingY + optionHeight) * optionPanels.Count)
        optionpanel.Size = New Size(Me.Width - 2 * optionSpacingX, optionHeight)
        optionpanel.BackColor = Color.FromArgb(74, 74, 74)
        optionpanel.helpText = optionHelpText
        optionpanel.assignedOption = assignedOption
        optionPanels.Add(optionpanel)
        Dim optionlabel As New Label
        optionlabel.Parent = optionpanel
        optionlabel.Location = New Point(0, 0)
        optionlabel.Font = New Font("Microsoft Sans Serif", 14.25)
        optionlabel.MaximumSize = New Size(optionpanel.Width, optionHeight)
        optionlabel.MinimumSize = optionlabel.MaximumSize
        optionlabel.TextAlign = ContentAlignment.MiddleLeft
        optionlabel.Text = optionName
        optionlabel.ForeColor = Color.White
        optionlabel.Padding = New Padding(10, 0, 0, 0)
        AddHandler optionlabel.MouseEnter, AddressOf displayHelpText
        Select Case oType
            Case OptionType.CHECKBOX
                Dim newcheckBox As New CheckButton
                newcheckBox.initialise(optionpanel)
                AddHandler newcheckBox.Click, AddressOf checkClicked
                checkbuttons.Add(newcheckBox)
                newcheckBox.BringToFront()
            Case OptionType.DROPDOWN
                Dim newComboBox As New CustomComboBox(assignedOption)
                newComboBox.initialise(optionpanel)
                dropdowns.Add(newComboBox)
                newComboBox.BringToFront()
                AddHandler newComboBox.radioDropDown, AddressOf handleRadioDropDown

        End Select
    End Sub
    Private Sub handleRadioDropDown(selectedDropDown As CustomComboBox, e As EventArgs)
        For Each dropdown In dropdowns
            If dropdown.associatedOption <> selectedDropDown.associatedOption Then
                dropdown.resetDropDown()
            End If
        Next
    End Sub
    Private Sub checkClicked(clickedCheck As CheckButton, e As MouseEventArgs)
        madeChanges = True
        clickedCheck.toggleChecked()
        Dim selectedOptionPanel As OptionPanel = clickedCheck.Parent
        updateOptionStatusInfo(getOptionStatus(selectedOptionPanel.assignedOption))
    End Sub
    Private Sub displayHelpText(selectedOption As Label, e As EventArgs)
        Dim selectedOptionPanel As OptionPanel = selectedOption.Parent
        updateOptionStatusInfo(getOptionStatus(selectedOptionPanel.assignedOption))
        lblOptionHelpText.Text = selectedOptionPanel.helpText
    End Sub
    Private Sub updateOptionStatusInfo(ByVal newStatus As String)
        If newStatus = "<ENABLED>" Then
            lblOptionStatusInfo.Text = "ENABLED"
            lblOptionStatusInfo.ForeColor = Color.LightGreen
            lblOptionStatusInfo.Font = New Font(lblOptionStatusInfo.Font, FontStyle.Regular)
        ElseIf newStatus = "<DISABLED>" Then
            lblOptionStatusInfo.Text = "DISABLED"
            lblOptionStatusInfo.ForeColor = Color.LightCoral
            lblOptionStatusInfo.Font = New Font(lblOptionStatusInfo.Font, FontStyle.Regular)
        Else
            lblOptionStatusInfo.Text = newStatus
            lblOptionStatusInfo.ForeColor = Color.White
            lblOptionStatusInfo.Font = New Font(lblOptionStatusInfo.Font, FontStyle.Italic)
        End If
    End Sub
    Private Sub clearHelpText() Handles pnlMainWrapper.MouseEnter
        lblOptionHelpText.Text = ""
        lblOptionStatusInfo.Text = ""
        For Each dropdown In dropdowns
            dropdown.resetDropDown()
        Next
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If madeChanges Then
            Dim dresult As DialogResult = frmConfirmationDialog.runDialog("Confirm Changes", "Confirm your changes to Preferences?", "", DialogType.YESNOCANCEL)
            Select Case dresult
                Case DialogResult.Yes
                    saveCheckInfo()
                Case DialogResult.Cancel
                    Exit Sub
            End Select
        End If
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
    Public Sub displayPrefs()
        madeChanges = False
        loadCheckInfo()
        ShowDialog()
        My.Settings.Save()
    End Sub
    Private Sub loadCheckInfo()
        setCheckBox(0, My.Settings.renderOrderNums)
        setCheckBox(1, My.Settings.fastMode)
        setCheckBox(2, My.Settings.debugMode)
        setDropDown(0, My.Settings.colorScheme)
        setDropDown(1, My.Settings.menuColorScheme)
    End Sub
    Private Sub saveCheckInfo()
        My.Settings.renderOrderNums = checkbuttons(0).isChecked()
        My.Settings.fastMode = checkbuttons(1).isChecked()
        My.Settings.debugMode = checkbuttons(2).isChecked()
        My.Settings.colorScheme = dropdowns(0).currentItem.associatedIndex
        My.Settings.menuColorScheme = dropdowns(1).currentItem.associatedIndex
    End Sub
    Private Sub setCheckBox(ByVal checkBoxIndex As Integer, ByVal newVal As Boolean)
        If checkbuttons(checkBoxIndex).isChecked <> newVal Then
            checkbuttons(checkBoxIndex).toggleChecked()
        End If
    End Sub
    Private Sub setDropDown(ByVal dropdownIndex As Integer, ByVal scheme As Integer)
        dropdowns(dropdownIndex).selectItem(scheme)
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        saveCheckInfo()
    End Sub
    Private Sub OKHelpText() Handles btnOK.MouseEnter
        lblOptionHelpText.Text = "Save changes and exit to menu."
    End Sub
    Private Sub CancelHelpText() Handles btnCancel.MouseEnter
        lblOptionHelpText.Text = "Revert changes and exit to menu."
    End Sub
    Private Function getOptionStatus(ByVal queryoption As MacroOption) As String
        If checkbuttons.Count = 0 Then
            Return "<ERROR>"
        Else
            Select Case queryoption
                Case MacroOption.SHOW_ORDER_NUMS
                    If checkbuttons(0).isChecked Then
                        Return "<ENABLED>"
                    Else
                        Return "<DISABLED>"
                    End If
                Case MacroOption.FAST_MODE
                    If checkbuttons(1).isChecked Then
                        Return "<ENABLED>"
                    Else
                        Return "<DISABLED>"
                    End If
                Case MacroOption.DEBUG_MODE
                    If checkbuttons(2).isChecked Then
                        Return "<ENABLED>"
                    Else
                        Return "<DISABLED>"
                    End If
                Case MacroOption.COLOR_SCHEME
                    Return dropdowns(0).selectedItem.ToString
                Case MacroOption.MENU_COLOR_SCHEME
                    Return dropdowns(1).selectedItem.ToString
            End Select
            Return "NOTHING"
        End If
    End Function


End Class
Public Class Palette
    Public name As String
    Public scheme As ColorScheme
    Public Primary As Color         'BRIGHTEST
    Public Secondary As Color       'SECOND BRIGHT
    Public Tertiary As Color        'THIRD BRIGHT
    Public Hover As Color
    Public Hold As Color
    Public Stroke As Color
    Public OuterStroke As Color
    Public Text As Color
    Public AltText As Color
    Public AltSecondary As Color
    Private isMenu As Boolean
    Public Sub New(ByVal scheme As ColorScheme, ByVal primary As Color, ByVal secondary As Color, ByVal tertiary As Color, ByVal stroke As Color, ByVal text As Color, Optional ByVal outerStroke As Color = Nothing)
        Me.scheme = scheme
        Select Case scheme
            Case ColorScheme.DARK
                Me.name = "Dark"
            Case ColorScheme.LIGHT
                Me.name = "Light"
            Case ColorScheme.BLUE
                Me.name = "Blue"
        End Select
        Me.Primary = primary
        Me.Secondary = secondary
        Me.Tertiary = tertiary
        Me.Stroke = stroke
        Me.Text = text
        If outerStroke <> Nothing Then
            Me.OuterStroke = outerStroke
        Else
            Me.OuterStroke = stroke
        End If
        isMenu = False
        calculateArtificials()
    End Sub
    Public Sub New(ByVal scheme As ColorScheme, ByVal primary As Color, ByVal secondary As Color, ByVal tertiary As Color)
        'menu palette
        Me.scheme = scheme
        Select Case scheme
            Case ColorScheme.GREEN_MENU
                Me.name = "Green Menu"
            Case ColorScheme.BLUE_MENU
                Me.name = "Blue Menu"
            Case ColorScheme.DARK_MENU
                Me.name = "Dark Menu"
        End Select
        Me.Primary = primary
        Me.Secondary = secondary
        Me.Tertiary = tertiary
        isMenu = True
        calculateArtificials()
    End Sub
    Private Sub calculateArtificials()
        If isMenu Then
            'menu artificials
            Hover = darkenColor(Primary, 5)
            Hold = darkenColor(Primary, 50)
        Else
            'normal artificials
            If getBrightness(Primary) > 200 Then
                Hover = darkenColor(Primary, 50)
                Hold = darkenColor(Primary, 100)
                AltText = Text
                AltSecondary = darkenColor(Primary, 100)
            Else
                Hover = darkenColor(Primary, 10)
                Hold = darkenColor(Primary, 30)
                AltSecondary = lightenColor(Primary, 50)
                AltText = Color.White
            End If

        End If
    End Sub
    Private Function getBrightness(ByVal col As Color) As Integer
        Dim r As Integer = col.R
        Dim g As Integer = col.G
        Dim b As Integer = col.B
        Dim total As Integer = r+g+b
        Return Math.Floor(total / 3)
    End Function
    Private Function darkenColor(ByVal oldColor As Color, darkenBy As Integer) As Color
        Dim R, G, B As Integer
        R = oldColor.R - darkenBy
        G = oldColor.G - darkenBy
        B = oldColor.B - darkenBy
        If R < 0 Then R = 0
        If G < 0 Then G = 0
        If B < 0 Then B = 0
        Return Color.FromArgb(R, G, B)
    End Function
    Private Function lightenColor(ByVal oldColor As Color, lightenBy As Integer) As Color
        Dim R, G, B As Integer
        R = oldColor.R + lightenBy
        G = oldColor.G + lightenBy
        B = oldColor.B + lightenBy
        If R > 255 Then R = 0
        If G > 255 Then G = 0
        If B > 255 Then B = 0
        Return Color.FromArgb(R, G, B)
    End Function
    Public Enum ColorScheme
        DARK
        LIGHT
        BLUE
        GREEN_MENU
        BLUE_MENU
        DARK_MENU
    End Enum
End Class
