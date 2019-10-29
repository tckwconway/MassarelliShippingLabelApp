<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlBarTender
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlBarTender))
        Me.backgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.imgListUpDown = New System.Windows.Forms.ImageList(Me.components)
        Me.OpenFileDialogBartender = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTipLabelPrinter = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtLabel = New System.Windows.Forms.TextBox()
        Me.btnLoadBartenderLabel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picBartender = New System.Windows.Forms.PictureBox()
        Me.cboPrinters = New System.Windows.Forms.ComboBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.picUpdating = New System.Windows.Forms.PictureBox()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblNumPreviews = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        CType(Me.picBartender, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.picUpdating, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'backgroundWorker
        '
        '
        'imgListUpDown
        '
        Me.imgListUpDown.ImageStream = CType(resources.GetObject("imgListUpDown.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgListUpDown.TransparentColor = System.Drawing.Color.Transparent
        Me.imgListUpDown.Images.SetKeyName(0, "CloseUp_07.ico")
        Me.imgListUpDown.Images.SetKeyName(1, "OpenUp_07.ico")
        Me.imgListUpDown.Images.SetKeyName(2, "Check1616Disabled.ico")
        Me.imgListUpDown.Images.SetKeyName(3, "Check1616.ico")
        Me.imgListUpDown.Images.SetKeyName(4, "BTAdd_02.ico")
        Me.imgListUpDown.Images.SetKeyName(5, "BTRemove_02.ico")
        '
        'OpenFileDialogBartender
        '
        Me.OpenFileDialogBartender.DefaultExt = "btw"
        Me.OpenFileDialogBartender.Filter = "BarTender Label Formats (*.btw)|*.btw"
        Me.OpenFileDialogBartender.Title = "Open BarTender Label Format"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtLabel)
        Me.Panel3.Controls.Add(Me.btnLoadBartenderLabel)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.picBartender)
        Me.Panel3.Controls.Add(Me.cboPrinters)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.btnPrint)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(552, 53)
        Me.Panel3.TabIndex = 1
        '
        'txtLabel
        '
        Me.txtLabel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLabel.Location = New System.Drawing.Point(76, 3)
        Me.txtLabel.Name = "txtLabel"
        Me.txtLabel.ReadOnly = True
        Me.txtLabel.Size = New System.Drawing.Size(323, 20)
        Me.txtLabel.TabIndex = 191
        '
        'btnLoadBartenderLabel
        '
        Me.btnLoadBartenderLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadBartenderLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadBartenderLabel.Image = Global.MassarelliShippingLabelApp.My.Resources.Resources.Elipsis
        Me.btnLoadBartenderLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoadBartenderLabel.Location = New System.Drawing.Point(401, 3)
        Me.btnLoadBartenderLabel.Name = "btnLoadBartenderLabel"
        Me.btnLoadBartenderLabel.Size = New System.Drawing.Size(20, 20)
        Me.btnLoadBartenderLabel.TabIndex = 190
        Me.btnLoadBartenderLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnLoadBartenderLabel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 189
        Me.Label1.Text = "&Label:"
        '
        'picBartender
        '
        Me.picBartender.Image = CType(resources.GetObject("picBartender.Image"), System.Drawing.Image)
        Me.picBartender.Location = New System.Drawing.Point(13, 5)
        Me.picBartender.Name = "picBartender"
        Me.picBartender.Size = New System.Drawing.Size(17, 16)
        Me.picBartender.TabIndex = 188
        Me.picBartender.TabStop = False
        '
        'cboPrinters
        '
        Me.cboPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrinters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPrinters.FormattingEnabled = True
        Me.cboPrinters.Location = New System.Drawing.Point(76, 27)
        Me.cboPrinters.Name = "cboPrinters"
        Me.cboPrinters.Size = New System.Drawing.Size(345, 21)
        Me.cboPrinters.TabIndex = 187
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.MassarelliShippingLabelApp.My.Resources.Resources.Printer1616_PLAIN_2
        Me.PictureBox2.Location = New System.Drawing.Point(13, 30)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 15)
        Me.PictureBox2.TabIndex = 186
        Me.PictureBox2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 185
        Me.Label7.Text = "&Printer:"
        '
        'btnPrint
        '
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(427, 3)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(119, 45)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = " Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.picUpdating)
        Me.Panel4.Controls.Add(Me.picPreview)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 53)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(552, 516)
        Me.Panel4.TabIndex = 2
        '
        'picUpdating
        '
        Me.picUpdating.BackColor = System.Drawing.Color.White
        Me.picUpdating.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picUpdating.Location = New System.Drawing.Point(278, 166)
        Me.picUpdating.Name = "picUpdating"
        Me.picUpdating.Size = New System.Drawing.Size(24, 24)
        Me.picUpdating.TabIndex = 163
        Me.picUpdating.TabStop = False
        Me.picUpdating.Visible = False
        '
        'picPreview
        '
        Me.picPreview.BackColor = System.Drawing.Color.Gray
        Me.picPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picPreview.Location = New System.Drawing.Point(0, 0)
        Me.picPreview.Margin = New System.Windows.Forms.Padding(0)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(552, 516)
        Me.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picPreview.TabIndex = 162
        Me.picPreview.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblNumPreviews)
        Me.Panel2.Controls.Add(Me.btnNext)
        Me.Panel2.Controls.Add(Me.btnLast)
        Me.Panel2.Controls.Add(Me.btnPrev)
        Me.Panel2.Controls.Add(Me.btnFirst)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 538)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(552, 31)
        Me.Panel2.TabIndex = 179
        '
        'lblNumPreviews
        '
        Me.lblNumPreviews.AutoSize = True
        Me.lblNumPreviews.Location = New System.Drawing.Point(223, 9)
        Me.lblNumPreviews.Name = "lblNumPreviews"
        Me.lblNumPreviews.Size = New System.Drawing.Size(62, 13)
        Me.lblNumPreviews.TabIndex = 167
        Me.lblNumPreviews.Text = "Page 0 of 0"
        '
        'btnNext
        '
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Location = New System.Drawing.Point(464, 4)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(37, 23)
        Me.btnNext.TabIndex = 168
        Me.btnNext.Text = ">"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLast.Location = New System.Drawing.Point(507, 4)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(37, 23)
        Me.btnLast.TabIndex = 169
        Me.btnLast.Text = ">>"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrev.Location = New System.Drawing.Point(54, 4)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(37, 23)
        Me.btnPrev.TabIndex = 166
        Me.btnPrev.Text = "<"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFirst.Location = New System.Drawing.Point(11, 4)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(37, 23)
        Me.btnFirst.TabIndex = 165
        Me.btnFirst.Text = "<<"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'ControlBarTender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "ControlBarTender"
        Me.Size = New System.Drawing.Size(552, 569)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.picBartender, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.picUpdating, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents backgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents imgListUpDown As System.Windows.Forms.ImageList
    Private WithEvents OpenFileDialogBartender As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolTipLabelPrinter As System.Windows.Forms.ToolTip
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtLabel As System.Windows.Forms.TextBox
    Friend WithEvents btnLoadBartenderLabel As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picBartender As System.Windows.Forms.PictureBox
    Friend WithEvents cboPrinters As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents picUpdating As System.Windows.Forms.PictureBox
    Private WithEvents picPreview As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents lblNumPreviews As System.Windows.Forms.Label
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnLast As System.Windows.Forms.Button
    Private WithEvents btnPrev As System.Windows.Forms.Button
    Private WithEvents btnFirst As System.Windows.Forms.Button

End Class
