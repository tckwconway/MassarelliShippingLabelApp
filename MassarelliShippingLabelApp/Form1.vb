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
    Private bIsLoadOrder As Boolean = True
    Private bEnableSaveDB As Boolean = False
    Private bEnableRefreshDB As Boolean = True
    Private bEnableCtls As Boolean = True
    Private bClearOrderNo = False
    Private retcall As String ' String for returing the call if error occurs 
    Public engine As Engine = Nothing ' The BarTender Print Engine.
    Public previewPath As String = "" ' The path to the folder where the previews will be exported.
    Public dataPath As String = "" ' The path to the folder where the text file data will be stored
    Private Const appName As String = "Print Preview"

    Private Sub MassarelliShippingLabels_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        cOptionalCriteria.DBName = My.Settings.DefaultDB
        MacStartup(cOptionalCriteria.DBName)
        Try
            engine = New Engine(True)
        Catch exception As PrintEngineException
            ' If the engine is unable to start, a PrintEngineException will be thrown.
            MessageBox.Show(Me, exception.Message, appName)
            'Me.Close() ' Close this app. We cannot run without connection to an engine.
            Return
        End Try

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
    End Sub


    Private Sub tbQtyLables_Enter(sender As System.Object, e As System.EventArgs) Handles tbQtyLables.Enter
        tbQtyLables.BackColor = Color.FromArgb(255, 255, 128)
    End Sub

    Private Sub tbQtyLables_Leave(sender As System.Object, e As System.EventArgs) Handles tbQtyLables.Leave
        tbQtyLables.BackColor = SystemColors.Window
    End Sub
    Private Sub tbOrderNo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbOrderNo.KeyDown
        If bClearOrderNo = True Then
            tbOrderNo.Text = ""
            bClearOrderNo = False
        End If
        If e.KeyCode = Keys.Enter Then
            tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, vbCrLf, "")

            With cOptionalCriteria
                .Clear()
                .mOrderNo = tbOrderNo.Text.Trim
                CreateAddressLabel(.mOrderNo)
                bClearOrderNo = True
            End With
        End If
    End Sub

    Private Sub CreateAddressLabel(orderNo As String)
        Dim sSQL As String
        sSQL = "Select IsNull(a.ship_to_name, '') ship_to_name, IsNull(a.ship_to_addr_1, '') ship_to_addr_1,  " _
             & "IsNull(a.ship_to_addr_2, '') ship_to_addr_2, IsNull(a.ship_to_addr_3, '') ship_to_addr_3, IsNull(a.ship_to_country, '') ship_to_country " _
             & "From oebolFil_sql A, OEBOLORD_SQL B " _
             & "Where a.bol_no = b.bol_no " _
             & "and b.ord_no = '" & orderNo & "' "

        If cn Is Nothing Then
            LoadDB()

        End If
        Dim dt As DataTable = DAC.ExecuteSQL_DataSet(sSQL, cn, "ADDRESSLABEL")

        Dim i As Integer = 0
        Dim j As Integer = 0

        For i = 0 To 4
            With cOptionalCriteria
                Dim val As String = dt.Rows(0)(i).ToString.Trim
                If Not val = "" Then
                    If .mShipToName = "" Then .mShipToName = val : Continue For
                    If .mShipToAddr1 = "" Then .mShipToAddr1 = val : Continue For
                    If .mShipToAddr2 = "" Then .mShipToAddr2 = val : Continue For
                    If .mShipToAddr3 = "" Then .mShipToAddr3 = val : Continue For
                    If .mShipToCountry = "" Then .mShipToCountry = val : Continue For
                End If
            End With
        Next
        
        ParseShipAddressLabel()

    End Sub

    Private Sub ParseShipAddressLabel()
        Dim arrItems(0, 4) As String
        Dim RetMethod As String = "PrintLabels"

        With cOptionalCriteria
            .mShipAddressForLabel = _
                IIf(.mShipToName = "", "", .mShipToName & vbCrLf) & _
                IIf(.mShipToAddr1 = "", "", .mShipToAddr1 & vbCrLf) & _
                IIf(.mShipToAddr2 = "", "", .mShipToAddr2 & vbCrLf) & _
                IIf(.mShipToAddr3 = "", "", .mShipToAddr3 & vbCrLf) & _
                IIf(.mShipToCountry = "", "", .mShipToCountry)

            tbAddressForLabel.Text = .mShipAddressForLabel

        End With
        ' Create a temporary folder to hold the bartender label images.
        Dim tempPath As String = Path.GetTempPath() ' Something like "C:\Documents and Settings\<username>\Local Settings\Temp""
        Dim newFolder As String
        Do
            newFolder = Path.GetRandomFileName()
            previewPath = tempPath & newFolder ' newFolder is something crazy like "gulvwdmt.3r4"
        Loop While Directory.Exists(previewPath)
        Directory.CreateDirectory(previewPath)

        Do
            newFolder = Path.GetRandomFileName()
            dataPath = tempPath & newFolder
        Loop While Directory.Exists(dataPath)
        Directory.CreateDirectory(dataPath)
        'Create the temporary Text File for the Label Data Source
        Try
            'arrItems(0, 0) = cOptionalCriteria.mShipAddressForLabel
            arrItems(0, 0) = cOptionalCriteria.mShipToName
            arrItems(0, 1) = cOptionalCriteria.mShipToAddr1 
            arrItems(0, 2) = cOptionalCriteria.mShipToAddr2
            arrItems(0, 3) = cOptionalCriteria.mShipToAddr3
            arrItems(0, 4) = cOptionalCriteria.mShipToCountry

            retcall = "tmpItems = Me.WriteTextFile(arrItems), Array UBound: " & arrItems.Length.ToString
            ExcelDataSet.LabelDataSourcePathFile = ControlBarTender1.WriteTextFile(arrItems, previewPath, dataPath)

        Catch ex As Exception
            MsgBox("Method: " & RetMethod & ", Call: " & retcall)
        End Try

        My.Settings.Printer = ControlBarTender1.cboPrinters.Text
        My.Settings.Save()
        My.Settings.Reload()

        With ControlBarTender1
            .PreviewLabel(ControlBarTender1.cboPrinters.Text, previewPath, dataPath)
        End With

        tbQtyLables.Focus()
        tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, vbCrLf, "")
        tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, vbCr, "")
        tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, vbLf, "")
        tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, "[^a-zA-Z0-9_ .+]", "")
        bIsLoadOrder = False
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
   
    Private Sub cbDBList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbDBList.SelectedIndexChanged
        If bIsLoading Then Exit Sub
        Dim cbo As ComboBox = CType(sender, ComboBox)
        Dim db As String = cbo.SelectedItem.ToString

       
        bEnableRefreshDB = CBool(IIf(cbo.SelectedItem.ToString = My.Settings.DefaultDB, False, True))
        bEnableSaveDB = CBool(IIf(cbo.SelectedItem.ToString = My.Settings.DefaultDB, False, True))
        bEnableCtls = CBool(IIf(cbo.SelectedItem.ToString = My.Settings.DefaultDB, True, False))

        SetControlState(bEnableRefreshDB, bEnableSaveDB, bEnableCtls)
    End Sub

    Private Sub btnSaveDefaultDB_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveDefaultDB.Click

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

    Private Sub btnRefreshDB_Click(sender As System.Object, e As System.EventArgs) Handles btnRefreshDB.Click
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
    End Sub

    Private Sub ClearControls()
        tbOrderNo.Text = ""
        tbQtyLables.Text = ""
        tbAddressForLabel.Text = ""
    End Sub


    Private Sub tbOrderNo_TextChanged(sender As Object, e As System.EventArgs) Handles tbOrderNo.TextChanged
        If bIsLoadOrder = False Then
            tbOrderNo.Text = System.Text.RegularExpressions.Regex.Replace(tbOrderNo.Text, "[^a-zA-Z0-9_ .+]", "")
            bIsLoadOrder = True
        End If
    End Sub

    'Private Sub rtbOrderNo_Enter(sender As Object, e As System.EventArgs)
    '    rtbOrderNo.SelectionAlignment = HorizontalAlignment.Center

    'End Sub

    'Private Sub rtbOrderNo_TextChanged(sender As System.Object, e As System.EventArgs)

    '    With rtbOrderNo

    '        .SelectAll()
    '        .SelectionAlignment = HorizontalAlignment.Center
    '        .Select(0, 0)
    '    End With

    'End Sub
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


    Public Sub Clear()
        mOrderNo = ""
        mShipToName = ""
        mShipToAddr1 = ""
        mShipToAddr2 = ""
        mShipToAddr3 = ""
        mShipToCountry = ""
    End Sub

End Class