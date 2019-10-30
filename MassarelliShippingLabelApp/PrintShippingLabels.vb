Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices.Marshal
Imports System.Runtime.InteropServices
Imports Seagull.BarTender.Print
Imports Seagull.BarTender.Print.Database
Imports Seagull.BarTender.Print.Message
Imports System.IO
Public Class MassarelliShippingLabels
    Private cOptionalCriteria As New OptionalCriteria
    Private bIsLoading As Boolean = True
    Private bSkipProcessing As Boolean = False
    Private bIsLoadOrder As Boolean = True
    Private bEnableSaveDB As Boolean = False
    Private bEnableRefreshDB As Boolean = True
    Private bEnableCtls As Boolean = True
    Private bClearOrderNo = False
    Private bDone As Boolean = False
    Private bLeaveTextBoxOrderNo As Boolean
    Private bIsValidAddress As Boolean
    Private retcall As String ' String for returing the call if error occurs 
    Public engine As Engine = Nothing ' The BarTender Print Engine.
    Public previewPath As String = "" ' The path to the folder where the previews will be exported.
    Public dataPath As String = "" ' The path to the folder where the text file data will be stored
    Private Const appName As String = "Print Preview"
    Public Event PrintEnterPressed() 'Allows user to press Enter Key on Qty Textbox and print the labels

    Private Sub MassarelliShippingLabels_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cOptionalCriteria.DBName = My.Settings.DefaultDB
        MacStartup(cOptionalCriteria.DBName)

        'Load the list of SQL Databases
        Try
            listSQLDatabases()
        Catch ex As Exception
            MsgBox("ListSQLDatabases " & ex.Message)
        End Try

        Try
            engine = New Engine(True)
        Catch exception As PrintEngineException
            ' If the engine is unable to start, a PrintEngineException will be thrown.
            MessageBox.Show(Me, exception.Message, appName)
            'Me.Close() ' Close this app. We cannot run without connection to an engine.
            Return
        End Try

        cbDBList.Text = My.Settings.DefaultDB

        Panel5.Height = 0

        Timer1.Interval = 50
        Timer1.Enabled = True
    End Sub

    Private Sub LoadDB()
        cOptionalCriteria.DBName = My.Settings.DefaultDB
        MacStartup(cOptionalCriteria.DBName)
    End Sub

    Private Sub tbOrderNo_Enter(sender As Object, e As System.EventArgs) Handles tbOrderNo.Enter
        tbOrderNo.BackColor = Color.FromArgb(255, 255, 128)
    End Sub

    Private Sub tbOrderNo_Leave(sender As Object, e As System.EventArgs) Handles tbOrderNo.Leave
        tbOrderNo.BackColor = SystemColors.Window
        bLeaveTextBoxOrderNo = True
    End Sub

    Private Sub tbQtyLables_Enter(sender As System.Object, e As System.EventArgs) Handles tbQtyLables.Enter
        tbQtyLables.BackColor = Color.FromArgb(255, 255, 128)
        tbQtyLablesBack.BackColor = Color.FromArgb(255, 255, 128)
    End Sub

    Private Sub tbQtyLables_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbQtyLables.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") Then
            e.Handled = True
        End If
    End Sub


    Private Sub tbQtyLables_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbQtyLables.KeyUp
        Dim ctr As Integer = 0
        'Dim pt As HiPerfTimer = New HiPerfTimer()
        If Panel5.Height > 0 Then Exit Sub
        ' pt.Start()

        If e.KeyCode = Keys.Enter Then
            tbQtyLables.Text = tbQtyLables.Text.Trim
           
            If tbQtyLables.Text.Length > 3 Then
                'Second Test, just the lenght of text to see if from barcode reader...
                tbQtyLables.Text = ""
                'bSkipProcessing = True
                Exit Sub
            ElseIf tbQtyLables.Text = "" Then
                'Nothing in the textbox, but enter was pressed...
                Exit Sub
            ElseIf tbQtyLables.Text <> "" Then
                'Preview and Print the labels...
                bDone = False
                Do
                    ctr += 1
                    Try
                        Cursor = Cursors.WaitCursor
                        lblLoadingPreview.Visible = True
                        PreviewShippingLabels()
                        Print(ControlBarTender1.format)
                        lblLoadingPreview.Visible = False
                        bDone = True
                    Catch Ex As Exception
                        If ctr = 10000 Then bDone = False : Exit Do
                    End Try
                Loop While Not bDone

            Else
                'just clear Qty textbox and try it again...
                tbQtyLables.Text = ""
                bSkipProcessing = False
                Exit Sub
            End If
        ElseIf IsNumeric(tbQtyLables.Text) Then
            tbQtyLables.Text = tbQtyLables.Text.Trim

            If tbQtyLables.Text.Length > 3 Then
                'Second Test, just the lenght of text to see if from barcode reader...
                tbQtyLables.Text = ""
                'bSkipProcessing = True
                Exit Sub
            ElseIf tbQtyLables.Text = "" Then
                'Nothing in the textbox, but enter was pressed...
                Exit Sub
            ElseIf tbQtyLables.Text <> "" Then
                'Preview and Print the labels...
                bDone = False
                Do
                    ctr += 1
                    Try
                        Cursor = Cursors.WaitCursor
                        lblLoadingPreview.Visible = True
                        ControlBarTender1.DisablePreview()

                        With Timer3
                            .Interval = 100
                            .Enabled = True
                        End With

                        bDone = True
                    Catch Ex As Exception
                        If ctr = 10000 Then bDone = False : Exit Do
                    End Try
                Loop While Not bDone

            Else
                'just clear Qty textbox and try it again...
                tbQtyLables.Text = ""
                bSkipProcessing = False
                Exit Sub
            End If

        ElseIf e.KeyCode = Keys.Escape Then
            'If Escape is presses, clear everything...
            ClearControls()
            tbOrderNo.Focus()
            Exit Sub

        End If

        'pt.Stop()

        With tbQtyLables
            .SuspendLayout()
            .Text = System.Text.RegularExpressions.Regex.Replace(tbQtyLables.Text, "\n", "")
            .SelectionStart = .TextLength
            .ResumeLayout()
        End With

        ControlBarTender1.btnPrint.Enabled = IIf(tbQtyLables.Text.Length = 0, False, True)
    End Sub

    Private Sub EnterPressed() Handles Me.PrintEnterPressed
        Print(ControlBarTender1.format)
    End Sub
    Private Sub tbQtyLables_Leave(sender As System.Object, e As System.EventArgs) Handles tbQtyLables.Leave
        tbQtyLables.BackColor = SystemColors.Window
        tbQtyLablesBack.BackColor = SystemColors.Window
    End Sub

    Protected Overrides Function ProcessTabKey(ByVal forward As Boolean) As Boolean
        MyBase.ProcessTabKey(forward)

        If bLeaveTextBoxOrderNo = True Then
            GetShipLabelAddress()
            bLeaveTextBoxOrderNo = False
        End If
        Return True
    End Function
    Private Sub tbOrderNo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbOrderNo.KeyDown

        If bClearOrderNo = True Then
            tbOrderNo.Text = ""
            bClearOrderNo = False
        End If
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            GetShipLabelAddress()
            ''Pad with zeros to be sure it's a valid order_no
            'Try
            '    With tbOrderNo
            '        If .TextLength <> 8 Then
            '            .Text = ("00" & .Text)
            '            .Text = .Text.Substring(.TextLength - 8)
            '        End If
            '    End With
            'Catch ex As Exception

            'End Try
            ''clear barcode scanner char
            'tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, vbCrLf, "")
            'tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, vbCr, "")
            'tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, vbLf, "")
            'tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, "[^a-zA-Z0-9_ .+]", "")

            'With cOptionalCriteria
            '    .Clear()
            '    ClearAddr()
            '    .mOrderNo = tbOrderNo.Text.Trim
            '    CreateAddressLabel(.mOrderNo)
            '    bClearOrderNo = True
            'End With
        ElseIf e.KeyCode = Keys.Escape Then
            'If Escape is presses, clear everything...
            ClearControls()
            tbOrderNo.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub GetShipLabelAddress()
        'Pad with zeros to be sure it's a valid order_no
        Try
            With tbOrderNo
                If .TextLength <> 8 Then
                    .Text = ("00" & .Text)
                    .Text = .Text.Substring(.TextLength - 8)
                End If
            End With
        Catch ex As Exception

        End Try
        'clear barcode scanner char
        tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, vbCrLf, "")
        tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, vbCr, "")
        tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, vbLf, "")
        tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, "[^a-zA-Z0-9_ .+]", "")

        With cOptionalCriteria
            .Clear()
            ClearAddr()
            .mOrderNo = tbOrderNo.Text.Trim
            CreateAddressLabel(.mOrderNo)
            bClearOrderNo = True
        End With
    End Sub
    Private Sub ClearAddr()

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        tbAddressForLabel.Text = ""
        Panel5.Height = 0
        Panel4.Height = 36
        tbQtyLables.Text = ""
        bIsValidAddress = False

    End Sub


    Private Sub CreateAddressLabel(orderNo As String)
        Dim sSQL As String
        sSQL = "Select IsNull(a.ship_to_name, '') ship_to_name, " & vbCrLf _
             & "IsNull(a.ship_to_addr_1, '') ship_to_addr_1,  " & vbCrLf _
             & "IsNull(a.ship_to_addr_2, '') ship_to_addr_2, " & vbCrLf _
             & "IsNull(a.ship_to_addr_3, '') ship_to_addr_3, " & vbCrLf _
             & "IsNull(a.ship_to_country, '') ship_to_country, " & vbCrLf _
             & "a.ord_no, " & vbCrLf _
             & "Case " & vbCrLf _
             & "When a.shipping_dt = 0 then Convert(varchar, Cast(cast(19000101 as varchar(8)) as datetime), 101) " & vbCrLf _
             & "When a.shipping_dt is null then Convert(varchar, Cast(cast(19000101 as varchar(8)) as datetime), 101) " & vbCrLf _
             & "Else Convert(varchar, Cast(cast(a.shipping_dt as varchar(8)) as datetime), 101) " & vbCrLf _
             & "End as shipping_dt, " & vbCrLf _
             & "Case " & vbCrLf _
             & "When a.shipping_dt = 0 then '' " & vbCrLf _
             & "When a.shipping_dt is null then '' " & vbCrLf _
             & "Else Upper(Substring(Cast(Convert(varchar, Cast(cast(a.shipping_dt as varchar(8)) as datetime), 107) as Varchar(12)),1 , 3)) " & vbCrLf _
             & "End as shipping_MMM " & vbCrLf _
             & "From oeordhdr_sql A" & vbCrLf _
             & "Where a.ord_no = '" & orderNo & "' "

        '& "Convert(varchar, Cast(cast(a.shipping_dt as varchar(8)) as datetime), 101) as shipping_dt, " & vbCrLf _
        '    & "upper((Convert(VARCHAR(3), Cast(cast(a.shipping_dt as varchar(8)) as datetime), 107))) as shipping_MMM " & vbCrLf _

        If cn Is Nothing Then
            LoadDB()
        End If

        Dim dt As DataTable = DAC.ExecuteSQL_DataSet(sSQL, cn, "ADDRESSLABEL")

        'See if we returned any data ...
        If dt.Rows.Count = 0 Then
            MsgBox("Order Number " & cOptionalCriteria.mOrderNo & " was not found.  Order number may be incorrect or the Order may have been processed already.", MsgBoxStyle.OkCancel, "Order Number Not Found")

            Exit Sub
        Else
            bIsValidAddress = True
        End If

        Dim i As Integer = 0
        Dim j As Integer = 0

        With cOptionalCriteria
            For i = 0 To 4
                Dim val As String = dt.Rows(0)(i).ToString.Trim
                If Not val = "" Then
                    If .mShipToName = "" Then .mShipToName = val : Continue For
                    If .mShipToAddr1 = "" Then .mShipToAddr1 = val : Continue For
                    If .mShipToAddr2 = "" Then .mShipToAddr2 = val : Continue For
                    If .mShipToAddr3 = "" Then .mShipToAddr3 = val : Continue For
                    If .mShipToCountry = "" Then .mShipToCountry = val : Continue For

                End If

            Next
            .mOrderNo = dt.Rows(0)("ord_no").ToString
            .mShippingDate = dt.Rows(0)("shipping_dt").ToString
            .mShippingMonth = dt.Rows(0)("shipping_MMM").ToString
        End With

        ParseShipAddressLabel()

    End Sub

    Private Sub ParseShipAddressLabel()

        With cOptionalCriteria
            .mShipAddressForLabel = _
                IIf(.mShipToName = "", "", .mShipToName & vbCrLf) & _
                IIf(.mShipToAddr1 = "", "", .mShipToAddr1 & vbCrLf) & _
                IIf(.mShipToAddr2 = "", "", .mShipToAddr2 & vbCrLf) & _
                IIf(.mShipToAddr3 = "", "", .mShipToAddr3 & vbCrLf) & _
                IIf(.mShipToCountry = "", "", .mShipToCountry)

            tbAddressForLabel.Text = .mShipAddressForLabel

        End With

        tbQtyLables.Focus()
        tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, vbCrLf, "")
        tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, vbCr, "")
        tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, vbLf, "")
        tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, "[^a-zA-Z0-9_ .+]", "")

    End Sub

    Private Sub EnableEditAddressButton()
        If bIsValidAddress Then


        End If

    End Sub
    Private Sub PreviewShippingLabels()
        ' Create a temporary folder to hold the bartender label images.
        Dim RetMethod As String = "PrintLabels"
        Dim palletCount As Integer
        Dim lblCount As Integer
        Dim lblCounter As Integer = 0

        Dim tempPath As String = Path.GetTempPath() ' Something like "C:\Documents and Settings\<username>\Local Settings\Temp""
        Dim newFolder As String

        palletCount = Convert.ToInt32(tbQtyLables.Text.Trim)
        lblCount = palletCount * 2

        Dim arrItems(lblCount - 1, 9) As String
        Do
            newFolder = Path.GetRandomFileName()
            previewPath = tempPath & newFolder ' newFolder is something crazy like "gulvwdmt.3r4"
            tbPreviewPath.Text = previewPath

        Loop While Directory.Exists(previewPath)
        Directory.CreateDirectory(previewPath)

        Do
            newFolder = Path.GetRandomFileName()
            dataPath = tempPath & newFolder
            tbDataPath.Text = dataPath

        Loop While Directory.Exists(dataPath)
        Directory.CreateDirectory(dataPath)
        'Create the temporary Text File for the Label Data Source
        Try
            cOptionalCriteria.mPalletCount = palletCount

            For i As Integer = 0 To lblCount - 1
                lblCounter = lblCounter + Convert.ToInt32(IIf((i Mod 2) = 0, 1, 0))
                cOptionalCriteria.mNofPalletCount = lblCounter
                arrItems(i, 0) = cOptionalCriteria.mShipToName
                arrItems(i, 1) = cOptionalCriteria.mShipToAddr1
                arrItems(i, 2) = cOptionalCriteria.mShipToAddr2
                arrItems(i, 3) = cOptionalCriteria.mShipToAddr3
                arrItems(i, 4) = cOptionalCriteria.mShipToCountry
                arrItems(i, 5) = cOptionalCriteria.mOrderNo
                arrItems(i, 6) = cOptionalCriteria.mShippingDate
                arrItems(i, 7) = cOptionalCriteria.mShippingMonth
                arrItems(i, 8) = cOptionalCriteria.mNofPalletCount
                arrItems(i, 9) = cOptionalCriteria.mPalletCount
            Next

            retcall = "tmpItems = Me.WriteTextFile(arrItems), Array UBound: " & arrItems.Length.ToString
            ExcelDataSet.LabelDataSourcePathFile = ControlBarTender1.WriteTextFile(arrItems, previewPath, dataPath)

            System.Threading.Thread.Sleep(2000)
        Catch ex As Exception
            MsgBox("Method: " & RetMethod & ", Call: " & retcall)
        End Try

        With My.Settings
            .Printer = ControlBarTender1.cboPrinters.Text
            .Save()
        End With

        With ControlBarTender1
            .PreviewLabel(ControlBarTender1.cboPrinters.Text, previewPath, dataPath)
        End With

    End Sub

    Private Sub SetControlState(enableRefresh As Boolean, enableSave As Boolean, enablectls As Boolean)

        btnSaveDefaultDB.Enabled = enableSave
        btnRefreshDB.Enabled = enableRefresh

    End Sub
#Region "   DB Settings   "

    Private Sub LoadDBAndSettings()
        cOptionalCriteria.DBName = My.Settings.DefaultDB
        Try
            MacStartup(My.Settings.DefaultDB)
        Catch ex As Exception
            MsgBox("MacStartup " & ex.Message)
        End Try

        'Load the list of SQL Databases
        Try
            listSQLDatabases()
        Catch ex As Exception
            MsgBox("ListSQLDatabases " & ex.Message)
        End Try

        cbDBList.Text = My.Settings.DefaultDB
        'Status bar labels ...
        lblCurrentDB.Text = cOptionalCriteria.CurrentDB
        lblDefaultDB.Text = cOptionalCriteria.DefaultDB
    End Sub

    Private Sub listSQLDatabases()
        On Error Resume Next

        Dim cmd As New SqlCommand("", cn)
        Dim rdr As SqlDataReader
        cmd.CommandText = "exec sys.sp_databases"

        rdr = cmd.ExecuteReader()
        With cbDBList
            While (rdr.Read())
                If rdr.GetString(0).Substring(0, 4) = "DATA" Then .Items.Add(rdr.GetString(0))

            End While
        End With
        rdr.Dispose()
        cmd.Dispose()

    End Sub

    Private Sub cbDBList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        If bIsLoading Then Exit Sub
        Dim cbo As ComboBox = CType(sender, ComboBox)
        Dim db As String = cbo.SelectedItem.ToString

        bEnableRefreshDB = CBool(IIf(cbo.SelectedItem.ToString = My.Settings.DefaultDB, False, True))
        bEnableSaveDB = CBool(IIf(cbo.SelectedItem.ToString = My.Settings.DefaultDB, False, True))
        bEnableCtls = CBool(IIf(cbo.SelectedItem.ToString = My.Settings.DefaultDB, True, False))

        SetControlState(bEnableRefreshDB, bEnableSaveDB, bEnableCtls)
    End Sub

    Private Sub btnSaveDefaultDB_Click(sender As System.Object, e As System.EventArgs)

        If My.Settings.DefaultDB = cbDBList.SelectedItem.ToString Then
            Exit Sub
        Else

            My.Settings.DefaultDB = cbDBList.SelectedItem.ToString
            My.Settings.Save()

            With cOptionalCriteria
                .DBName = My.Settings.DefaultDB
                MacStartup(.DBName)
                lblCurrentDB.Text = .CurrentDB
                lblDefaultDB.Text = .DefaultDB
            End With

            bEnableRefreshDB = False
            bEnableSaveDB = False
            bEnableCtls = True
            SetControlState(bEnableRefreshDB, bEnableSaveDB, bEnableCtls)

        End If

    End Sub

    Private Sub btnRefreshDB_Click(sender As System.Object, e As System.EventArgs)
        Dim cbo As ComboBox = CType(cbDBList, ComboBox)
        cOptionalCriteria.DBName = cbo.SelectedItem.ToString
        MacStartup(cOptionalCriteria.DBName)
        lblCurrentDB.Text = cOptionalCriteria.CurrentDB

        bEnableRefreshDB = False
        bEnableSaveDB = True
        bEnableCtls = True
        SetControlState(bEnableRefreshDB, bEnableSaveDB, bEnableCtls)
    End Sub

#End Region

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        CType(sender, Timer).Enabled = False
        tbOrderNo.Focus()

        With My.Settings
            If .Printer = "" Or .Label = "" Then
                tbOrderNo.Enabled = False
                MsgBox("Printer and Label must be selected to begin." & vbCrLf & vbCrLf & "Select a Printer and/or Label and they will be automatically saved as the default each time the program is started.", MsgBoxStyle.OkOnly, "Setup Default Printer and Label")
            End If
        End With

    End Sub

    Private Sub ClearControls()
        tbOrderNo.Text = ""
        tbQtyLables.Text = ""
        tbAddressForLabel.Text = ""
        ControlBarTender1.DisablePreview()
        bIsValidAddress = False
    End Sub

    Private Sub tbOrderNo_TextChanged(sender As Object, e As System.EventArgs) Handles tbOrderNo.TextChanged

        With tbOrderNo
            If .Text.Contains(vbLf) Then
                .Text = tbOrderNo.Text.Replace(vbLf, "")
            End If

            If .Text.Length = 0 Then
                ClearAddr()
                ClearControls()
            End If

        End With

    End Sub

    

    Public Sub Print(format As LabelFormatDocument) Handles ControlBarTender1.PrintLabels
        Try
            format.Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnEditAddress_Click_1(sender As System.Object, e As System.EventArgs) Handles btnEditAddress.Click

        
        Panel5.Height = 149
        Panel4.Height = 0
        With cOptionalCriteria
            TextBox1.Text = .mShipToName
            TextBox2.Text = .mShipToAddr1
            TextBox3.Text = .mShipToAddr2
            TextBox4.Text = .mShipToAddr3
            TextBox5.Text = .mShipToCountry
        End With

    End Sub

    Private Sub btnDone_Click(sender As System.Object, e As System.EventArgs) Handles btnDone.Click
        lblLoadingPreview.Visible = True
        'Test to see if the number of Pallet Labels has been entered
        If tbQtyLables.Text.Trim = "" Then
            tbQtyLables.Text = "1"
            'MsgBox("Enter the Number of Pallets, then try again", MsgBoxStyle.OkOnly, "Enter Number of Pallets")
            'Exit Sub
        End If

        Panel5.Height = 0
        Panel4.Height = 36

        With cOptionalCriteria
            .mShipToName = TextBox1.Text
            .mShipToAddr1 = TextBox2.Text
            .mShipToAddr2 = TextBox3.Text
            .mShipToAddr3 = TextBox4.Text
            .mShipToCountry = TextBox5.Text
        End With

       

        ParseShipAddressLabel()
        ControlBarTender1.DisablePreview()
        'If tbOrderNo.Text = "" OrElse tbOrderNo.Text = "00" Then
        '    ControlBarTender1.btnPrint.Enabled = False
        '    Exit Sub
        'End If
        Cursor = Cursors.WaitCursor
        With Timer3
            .Interval = 100
            .Enabled = True
        End With

        bDone = True
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick

        Timer3.Enabled = False
        PreviewShippingLabels()
        lblLoadingPreview.Visible = False
        tbOrderNo.Select()

        Cursor = Cursors.Default
    End Sub

    Private Sub tbQtyLables_TextChanged(sender As System.Object, e As System.EventArgs) Handles tbQtyLables.TextChanged

    End Sub
End Class

Public Class OptionalCriteria
    Public DBName As String
    Public DefaultDB As String
    Public CurrentDB As String
    Public mOrderNo As String
    Public mShipToName As String
    Public mShipToAddr1 As String
    Public mShipToAddr2 As String
    Public mShipToAddr3 As String
    Public mShipToCountry As String
    Public mShipAddressForLabel As String
    Public mShippingDate As String
    Public mShippingMonth As String
    Public mPalletCount As String
    Public mNofPalletCount As String

    Public Sub Clear()
        mOrderNo = ""
        mShipToName = ""
        mShipToAddr1 = ""
        mShipToAddr2 = ""
        mShipToAddr3 = ""
        mShipToCountry = ""
        mShippingDate = ""
        mShippingMonth = ""
        mPalletCount = ""
        mNofPalletCount = ""
    End Sub

End Class