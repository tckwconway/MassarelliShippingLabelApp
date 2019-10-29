Imports Seagull.BarTender.Print
Imports Seagull.BarTender.Print.Database
Imports Seagull.BarTender.Print.Message
Imports System
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System.ComponentModel

Imports System.Runtime.InteropServices.Marshal
Imports System.Runtime.InteropServices

Imports System.Data.Common

Public Class ControlBarTender
    Public format As LabelFormatDocument = Nothing ' The format that will be exported.
    Private engine As Engine = Nothing ' The BarTender Print Engine.
    Private previewPath As String '= "" ' The path to the folder where the previews will be exported.
    Private dataPath As String '= "" ' The path to the folder where the text file data will be stored
    Private currentPage As Integer = 1 ' The current page being viewed.
    Private totalPages As Integer ' Number of pages.
    Private messages As Messages
    Private retcall As String ' String for returing the call if error occurs 
    Private Const appName As String = "Print Preview"
    Private Const DatabaseConnectionNameInLabel As String = "LabelData"
    Public Event PrintLabels(lblformat As LabelFormatDocument)


#Region "   BarTender   "

#Region "   Methods   "

    Private Sub OpenBartenderFormat(op As OpenFileDialog)

        ' Close the previous format.
        Try
            If format IsNot Nothing Then
                format.Close(SaveOptions.DoNotSaveChanges)
            End If
        Catch ex As Exception

        End Try

        ' We need to delete the files associated with the last format.
        Try
            Dim files() As String = Directory.GetFiles(previewPath)
            For Each filename As String In files
                File.Delete(filename)
            Next filename

        Catch ex As Exception

        End Try
        
        ' Put the UI back into a non-preview state.
        DisablePreview()
        ' Open the format.
        ExcelDataSet.BTLabelPathFileName = op.FileName
        My.Settings.Label = op.FileName
        My.Settings.Save()
        My.Settings.Reload()

        txtLabel.Text = op.FileName
        If format IsNot Nothing Then
            ' Select the printer in use by the format.
            cboPrinters.SelectedItem = format.PrintSetup.PrinterName
        End If

        Cursor.Current = Cursors.Default

        cboPrinters.Enabled = True

    End Sub

    Private Sub CloseBartenderLabelFormat()
        ' Close the previous format.

        Try
            If format IsNot Nothing Then
                format.Close(SaveOptions.DoNotSaveChanges)
            End If

        Catch ex As Exception

        End Try

        ' We need to delete the files associated with the last format.
        Dim files() As String = Directory.GetFiles(previewPath)
        For Each filename As String In files
            File.Delete(filename)
        Next filename

        ' Put the UI back into a non-preview state.
        DisablePreview()
        picPreview.Visible = True
    End Sub

    Public Sub DisablePreview()
        picPreview.ImageLocation = ""
        'picPreview.Visible = False

        btnPrev.Enabled = False
        btnFirst.Enabled = False
        lblNumPreviews.Visible = False
        btnNext.Enabled = False
        btnLast.Enabled = False
    End Sub

    Public Sub PreviewLabel(prntrName As String, fpreviewPath As String, fdataPath As String)

        cboPrinters.Enabled = False

        engine = MassarelliShippingLabels.engine
        dataPath = fdataPath
        previewPath = fpreviewPath
        ExcelDataSet.PrinterName = prntrName
        'Try
        '    engine = New Engine(True)
        'Catch exception As PrintEngineException
        '    ' If the engine is unable to start, a PrintEngineException will be thrown.
        '    MessageBox.Show(Me, exception.Message, appName)
        '    'Me.Close() ' Close this app. We cannot run without connection to an engine.
        '    Return
        'End Try


        Try
            If format IsNot Nothing Then
                format.Close(SaveOptions.DoNotSaveChanges)
            End If
        Catch ex As Exception
            'If DirectCast(ex, Seagull.BarTender.Print.PrintEngineException).ErrorId = 2 Then
            '    MsgBox("You must load a Bartener Label before labels can be Previewed or Printed.", MsgBoxStyle.OkOnly, "Bartender Label not loaded.")
            '    Exit Sub
            'End If

        End Try


        ' We need to delete the files associated with the last format.
        Dim files() As String = Directory.GetFiles(previewPath)
        For Each filename As String In files
            File.Delete(filename)
        Next filename

        ' Put the UI back into a non-preview state.
        DisablePreview()
        Try
            format = engine.Documents.Open(ExcelDataSet.BTLabelPathFileName)
            CType(format.DatabaseConnections(DatabaseConnectionNameInLabel), TextFile).FileName = ExcelDataSet.LabelDataSourcePathFile
            format.PrintSetup.PrinterName = ExcelDataSet.PrinterName

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        

        ' Set control states to show working. These will be reset when the work completes.
        picUpdating.Visible = True
        'dgvExcelPriceList.Visible = False
        picPreview.Visible = True
        Me.btnPrint.Enabled = True

        ' Have the background worker export the BarTender format.
        'backgroundWorker.RunWorkerAsync(format)
        PreviewAndPrintLabel()
    End Sub

#Region "   Background Worker   "

    Private Sub PreviewAndPrintLabel()
        Dim oldFiles() As String = Directory.GetFiles(previewPath, "*.*")
        For index As Integer = 0 To oldFiles.Length - 1
            File.Delete(oldFiles(index))
        Next index

        Try
            ' Export the format's print previews.
            format.ExportPrintPreviewToFile(previewPath, "PrintPreview%PageNumber%.jpg", ImageType.JPEG, _
                                            Seagull.BarTender.Print.ColorDepth.ColorDepth24bit, _
                                            New Resolution(picPreview.Width, picPreview.Height), _
                                            System.Drawing.Color.White, OverwriteOptions.Overwrite, _
                                            True, True, messages)

            Dim files() As String = Directory.GetFiles(previewPath, "*.*")
            totalPages = files.Length

        Catch ex As Exception

        End Try

        ' Report any messages.
        If messages IsNot Nothing Then
            If messages.Count > 5 Then
                MessageBox.Show(Me, "There are more than 5 messages from the print preview. Only the first 5 will be displayed.", appName)
            End If
            Dim count As Integer = 0
            For Each message As Seagull.BarTender.Print.Message In messages
                MessageBox.Show(Me, message.Text, appName)
                ' if (++count >= 5)
                count += 1
                If count >= 5 Then
                    Exit For
                End If
            Next message
        End If

        picUpdating.Visible = False

        'btnOpen.Enabled = True
        'btnPreview.Enabled = True
        cboPrinters.Enabled = True

        ' Only enable the preview if we actual got some pages.
        If totalPages <> 0 Then
            lblNumPreviews.Visible = True

            currentPage = 1
            ShowPreview()
        End If
    End Sub

    Private Sub backgroundWorker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles backgroundWorker.DoWork
        'Dim format As LabelFormatDocument = CType(e.Argument, LabelFormatDocument)

        ' Delete any existing files.
        Dim oldFiles() As String = Directory.GetFiles(previewPath, "*.*")
        For index As Integer = 0 To oldFiles.Length - 1
            File.Delete(oldFiles(index))
        Next index

        Try
            ' Export the format's print previews.
            format.ExportPrintPreviewToFile(previewPath, "PrintPreview%PageNumber%.jpg", ImageType.JPEG, _
                                            Seagull.BarTender.Print.ColorDepth.ColorDepth24bit, _
                                            New Resolution(picPreview.Width, picPreview.Height), _
                                            System.Drawing.Color.White, OverwriteOptions.Overwrite, _
                                            True, True, messages)

            Dim files() As String = Directory.GetFiles(previewPath, "*.*")
            totalPages = files.Length

        Catch ex As Exception

        End Try

    End Sub

    Private Sub backgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles backgroundWorker.RunWorkerCompleted
        ' Report any messages.
        If messages IsNot Nothing Then
            If messages.Count > 5 Then
                MessageBox.Show(Me, "There are more than 5 messages from the print preview. Only the first 5 will be displayed.", appName)
            End If
            Dim count As Integer = 0
            For Each message As Seagull.BarTender.Print.Message In messages
                MessageBox.Show(Me, message.Text, appName)
                ' if (++count >= 5)
                count += 1
                If count >= 5 Then
                    Exit For
                End If
            Next message
        End If

        picUpdating.Visible = False

        'btnOpen.Enabled = True
        'btnPreview.Enabled = True
        cboPrinters.Enabled = True

        ' Only enable the preview if we actual got some pages.
        If totalPages <> 0 Then
            lblNumPreviews.Visible = True

            currentPage = 1
            ShowPreview()
        End If
    End Sub

#End Region



    Private Function CreateItemLabelsToPrintDataTable() As DataTable
        'Create datatable
        Dim oLabelData As New DataTable("LabelData")

        If ExcelDataSet.ImportType = "SKU" Then
            oLabelData.Columns.Add("Prnt", GetType(Boolean))
            oLabelData.Columns.Add("SKU", GetType(String))
            oLabelData.Columns.Add("Description", GetType(String))
            oLabelData.Columns.Add("Retail", GetType(Decimal))
            oLabelData.Columns.Add("MfgPart", GetType(String))
            oLabelData.Columns.Add("MfgFinish", GetType(String))
            oLabelData.Columns.Add("QtyOrd", GetType(Decimal))
        ElseIf ExcelDataSet.ImportType = "UPC" Then
            oLabelData.Columns.Add("Prnt", GetType(Boolean))
            oLabelData.Columns.Add("SKU", GetType(String))
            oLabelData.Columns.Add("Description", GetType(String))
            oLabelData.Columns.Add("Retail", GetType(Decimal))
            oLabelData.Columns.Add("MfgPart", GetType(String))
            oLabelData.Columns.Add("MfgFinish", GetType(String))
            oLabelData.Columns.Add("QtyOrd", GetType(Decimal))
            oLabelData.Columns.Add("UPC", GetType(String))
        End If

        Return oLabelData

    End Function


    Public Sub PreviewEmptyLabel()

        ' Delete any existing files.
        Dim oldFiles() As String = Directory.GetFiles(previewPath, "*.*")
        For index As Integer = 0 To oldFiles.Length - 1
            File.Delete(oldFiles(index))
        Next index

        ' Export the format's print previews.
        format.ExportPrintPreviewToFile(previewPath, "PrintPreview%PageNumber%.jpg", ImageType.JPEG, Seagull.BarTender.Print.ColorDepth.ColorDepth24bit, New Resolution(picPreview.Width, picPreview.Height), System.Drawing.Color.White, OverwriteOptions.Overwrite, True, True, messages)
        Dim files() As String = Directory.GetFiles(previewPath, "*.*")
        totalPages = files.Length
        ShowPreview()
    End Sub

    ''' <summary>
    ''' Show the preview of the current page.
    ''' </summary>
    Private Sub ShowPreview()
        ' Our current preview number shouldn't be out of range,
        ' but we'll practice good programming by checking it.
        If (currentPage < 1) OrElse (currentPage > totalPages) Then
            currentPage = 1
        End If

        'previewPath = MassarelliShippingLabels.previewPath
        ' Update the page label and the preview Image.
        lblNumPreviews.Text = String.Format("Page {0} of {1}", currentPage, totalPages)
        Dim filename As String = String.Format("{0}\PrintPreview{1}.jpg", previewPath, currentPage)

        picPreview.ImageLocation = filename
        picPreview.Visible = True

        ' Enable or Disable controls as needed.
        If currentPage = 1 Then
            btnPrev.Enabled = False
            btnFirst.Enabled = False
        Else
            btnPrev.Enabled = True
            btnFirst.Enabled = True
        End If

        If currentPage = totalPages Then
            btnNext.Enabled = False
            btnLast.Enabled = False
        Else
            btnNext.Enabled = True
            btnLast.Enabled = True
        End If
        'dgvExcelPriceList.Visible = False
        picPreview.Visible = True
    End Sub

#End Region

#End Region

    Private Sub SetUpControls()
        'List the Local Printers
        Dim printers As New Printers()
        For Each printer As Printer In printers
            cboPrinters.Items.Add(printer.PrinterName)
        Next printer


        cboPrinters.Text = My.Settings.Printer
        ExcelDataSet.PrinterName = My.Settings.Printer

        With My.Settings
            If .Printer = "" Then
                .Printer = ExcelDataSet.PrinterName
            End If
            
        End With
        Try
            If My.Settings.Label > "" Then
                ExcelDataSet.BTLabelPathFileName = My.Settings.Label
                txtLabel.Text = My.Settings.Label
            End If
        Catch ex As Exception
            txtLabel.Text = ""
            ExcelDataSet.BTLabelPathFileName = ""
        End Try

       
    End Sub
    
    Private Sub ControlBarTender_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        SetUpControls()
    End Sub

    Public Function WriteTextFile(ByVal arrItems(,) As String, previewPath As String, dataPath As String) As String
        Dim RetMethod As String = "WriteTextFile"
        Dim RetCall As String = ""
        Dim i As Integer
        Dim tmpFileName As String = "LabelData" & Now.ToString("MMddyyyyhhmmss")

        IsLoading = False

        previewPath = previewPath
        dataPath = dataPath

        tmpFileName = dataPath & "\" & tmpFileName & ".txt"

        'Delete the temporary text file if it exists 
        Try
            Kill(tmpFileName)
        Catch ex As Exception

        End Try
        ExcelDataSet.LabelDataSourcePathFile = tmpFileName  'NOTE: Text file is not written until objWriter.CLOSE
        Using objWriter As New StreamWriter(tmpFileName, True)

            Try
                For i = 0 To arrItems.GetUpperBound(0)
                    'If i = 99 Then
                    '    MsgBox("STOP")
                    'End If
                    If ExcelDataSet.ImportType = "SKU" Then
                        RetCall = "objWriter.WriteLine" & arrItems(i, 0).ToString & "," & arrItems(i, 1).ToString & "," & arrItems(i, 2).ToString & "," & arrItems(i, 3).ToString & "," & arrItems(i, 4).ToString & "," & arrItems(i, 5).ToString
                        objWriter.WriteLine(arrItems(i, 0).ToString & "," & arrItems(i, 1).ToString & "," & arrItems(i, 2).ToString & "," & arrItems(i, 3).ToString & "," & arrItems(i, 4).ToString & "," & arrItems(i, 5).ToString)
                    ElseIf ExcelDataSet.ImportType = "UPC" Then
                        RetCall = "objWriter.WriteLine" & arrItems(i, 0).ToString & "," & arrItems(i, 1).ToString & "," & arrItems(i, 2).ToString & "," & arrItems(i, 3).ToString & "," & arrItems(i, 4).ToString & "," & arrItems(i, 5).ToString & "," & arrItems(i, 6).ToString
                        objWriter.WriteLine(arrItems(i, 0).ToString & "," & arrItems(i, 1).ToString & "," & arrItems(i, 2).ToString & "," & arrItems(i, 3).ToString & "," & arrItems(i, 4).ToString & "," & arrItems(i, 5).ToString & "," & arrItems(i, 6).ToString)
                    Else
                        RetCall = "objWriter.WriteLine" & arrItems(i, 0).ToString & "|" & arrItems(i, 1).ToString & "|" & arrItems(i, 2).ToString & "|" & arrItems(i, 3).ToString & "|" & arrItems(i, 4).ToString & "|" & arrItems(i, 5).ToString & "|" & arrItems(i, 6).ToString & "|" & arrItems(i, 7).ToString & "|" & arrItems(i, 8).ToString & "|" & arrItems(i, 9).ToString
                        objWriter.WriteLine(arrItems(i, 0).ToString & "|" & arrItems(i, 1).ToString & "|" & arrItems(i, 2).ToString & "|" & arrItems(i, 3).ToString & "|" & arrItems(i, 4).ToString & "|" & arrItems(i, 5).ToString & "|" & arrItems(i, 6).ToString & "|" & arrItems(i, 7).ToString & "|" & arrItems(i, 8).ToString & "|" & arrItems(i, 9).ToString)
                        'NOTE: Text file is not written until objWriter.CLOSE
                    End If
                Next
            Catch ex As Exception
                MsgBox("Method: " & RetMethod & ", Call: " & RetCall, MsgBoxStyle.OkOnly, "Error")
                MsgBox(ex.Message)
            End Try

            objWriter.Close()
        End Using
        Return tmpFileName



    End Function

    Private Sub btnNext_Click(sender As System.Object, e As System.EventArgs) Handles btnNext.Click
        currentPage += 1
        ShowPreview()
    End Sub

    Private Sub btnFirst_Click(sender As System.Object, e As System.EventArgs) Handles btnFirst.Click
        currentPage = 1
        ShowPreview()
    End Sub

    Private Sub btnPrev_Click(sender As System.Object, e As System.EventArgs) Handles btnPrev.Click
        currentPage -= 1
        ShowPreview()
    End Sub

    Private Sub btnLast_Click(sender As System.Object, e As System.EventArgs) Handles btnLast.Click
        currentPage = totalPages
        ShowPreview()
    End Sub

    Private Sub btnLoadBartenderLabel_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadBartenderLabel.Click
        Dim op As OpenFileDialog = DirectCast(Me.OpenFileDialogBartender, OpenFileDialog)

        If op.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            OpenBartenderFormat(op)
            op.Dispose()
        End If
        My.Settings.Label = op.FileName
        My.Settings.Save()
        txtLabel.Text = My.Settings.Label
        ExcelDataSet.BTLabelPathFileName = My.Settings.Label

        If My.Settings.Label > "" AndAlso My.Settings.Printer > "" Then
            EnableTextBox(MassarelliShippingLabels.tbOrderNo, True)
        Else
            EnableTextBox(MassarelliShippingLabels.tbOrderNo, True)
        End If

    End Sub


    Private Sub txtLabel_MouseEnter(sender As Object, e As System.EventArgs) Handles txtLabel.MouseEnter
        ToolTipLabelPrinter.SetToolTip(txtLabel, ExcelDataSet.BTLabelPathFileName)
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As System.EventArgs) Handles btnPrint.Click
        RaiseEvent PrintLabels(format)
    End Sub

    'Private Sub cboPrinters_DisplayMemberChanged(sender As Object, e As System.EventArgs) Handles cboPrinters.DisplayMemberChanged

    'End Sub

    Private Sub cboPrinters_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboPrinters.SelectedValueChanged
        My.Settings.Printer = cboPrinters.Text
        My.Settings.Save()
        ExcelDataSet.PrinterName = cboPrinters.Text

        If My.Settings.Label > "" AndAlso My.Settings.Printer > "" Then
            EnableTextBox(MassarelliShippingLabels.tbOrderNo, True)
        Else
            EnableTextBox(MassarelliShippingLabels.tbOrderNo, True)
        End If

    End Sub

    Private Sub EnableTextBox(txt As RichTextBox, enableTxt As Boolean)

        txt.Enabled = enableTxt

    End Sub

    'Private Sub txtLabel_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLabel.TextChanged
    '    My.Settings.Label = cboPrinters.Text
    '    My.Settings.Save()
    '    ExcelDataSet.PrinterName = cboPrinters.Text

    '    If My.Settings.Label > "" AndAlso My.Settings.Printer > "" Then
    '        EnableTextBox(MassarelliShippingLabels.tbOrderNo, True)
    '    Else
    '        EnableTextBox(MassarelliShippingLabels.tbOrderNo, True)
    '    End If
    'End Sub
End Class
