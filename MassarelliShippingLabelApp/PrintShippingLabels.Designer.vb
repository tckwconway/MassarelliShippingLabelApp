<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MassarelliShippingLabels
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MassarelliShippingLabels))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblPricingType = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDivider1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDivider2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblCurrentDB = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDivider3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDefaultDB = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.tbPreviewPath = New System.Windows.Forms.TextBox()
        Me.tbDataPath = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ControlBarTender1 = New MassarelliShippingLabelApp.ControlBarTender()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblLoadingPreview = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnEditAddress = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbQtyLables = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAddressForLabel = New System.Windows.Forms.RichTextBox()
        Me.tbOrderNo = New System.Windows.Forms.RichTextBox()
        Me.tbQtyLablesBack = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnRefreshDB = New System.Windows.Forms.Button()
        Me.cbDBList = New System.Windows.Forms.ComboBox()
        Me.btnSaveDefaultDB = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPricingType, Me.lblDivider1, Me.lblCount, Me.lblDivider2, Me.lblCurrentDB, Me.lblDivider3, Me.lblDefaultDB})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 995)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(832, 22)
        Me.StatusStrip1.TabIndex = 61
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblPricingType
        '
        Me.lblPricingType.Name = "lblPricingType"
        Me.lblPricingType.Size = New System.Drawing.Size(0, 15)
        '
        'lblDivider1
        '
        Me.lblDivider1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lblDivider1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.lblDivider1.Name = "lblDivider1"
        Me.lblDivider1.Size = New System.Drawing.Size(4, 15)
        '
        'lblCount
        '
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 15)
        '
        'lblDivider2
        '
        Me.lblDivider2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lblDivider2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.lblDivider2.Name = "lblDivider2"
        Me.lblDivider2.Size = New System.Drawing.Size(4, 15)
        '
        'lblCurrentDB
        '
        Me.lblCurrentDB.Name = "lblCurrentDB"
        Me.lblCurrentDB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCurrentDB.Size = New System.Drawing.Size(0, 15)
        Me.lblCurrentDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDivider3
        '
        Me.lblDivider3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lblDivider3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.lblDivider3.Name = "lblDivider3"
        Me.lblDivider3.Size = New System.Drawing.Size(4, 15)
        '
        'lblDefaultDB
        '
        Me.lblDefaultDB.Name = "lblDefaultDB"
        Me.lblDefaultDB.Size = New System.Drawing.Size(0, 15)
        Me.lblDefaultDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer1
        '
        '
        'tbPreviewPath
        '
        Me.tbPreviewPath.Location = New System.Drawing.Point(1299, 38)
        Me.tbPreviewPath.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbPreviewPath.Name = "tbPreviewPath"
        Me.tbPreviewPath.Size = New System.Drawing.Size(74, 26)
        Me.tbPreviewPath.TabIndex = 68
        Me.tbPreviewPath.Visible = False
        '
        'tbDataPath
        '
        Me.tbDataPath.Location = New System.Drawing.Point(1299, 78)
        Me.tbDataPath.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbDataPath.Name = "tbDataPath"
        Me.tbDataPath.Size = New System.Drawing.Size(74, 26)
        Me.tbDataPath.TabIndex = 69
        Me.tbDataPath.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1185, 46)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Preview Path"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1185, 89)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 20)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Data Path"
        Me.Label4.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ControlBarTender1)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(831, 983)
        Me.Panel3.TabIndex = 80
        '
        'ControlBarTender1
        '
        Me.ControlBarTender1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ControlBarTender1.Location = New System.Drawing.Point(0, 545)
        Me.ControlBarTender1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ControlBarTender1.Name = "ControlBarTender1"
        Me.ControlBarTender1.Size = New System.Drawing.Size(831, 389)
        Me.ControlBarTender1.TabIndex = 80
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.TextBox5)
        Me.Panel5.Controls.Add(Me.TextBox4)
        Me.Panel5.Controls.Add(Me.TextBox3)
        Me.Panel5.Controls.Add(Me.TextBox2)
        Me.Panel5.Controls.Add(Me.TextBox1)
        Me.Panel5.Controls.Add(Me.btnDone)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 320)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(831, 225)
        Me.Panel5.TabIndex = 90
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox5.Location = New System.Drawing.Point(20, 178)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(610, 35)
        Me.TextBox5.TabIndex = 88
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox4.Location = New System.Drawing.Point(20, 135)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(610, 35)
        Me.TextBox4.TabIndex = 87
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox3.Location = New System.Drawing.Point(20, 92)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(610, 35)
        Me.TextBox3.TabIndex = 86
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox2.Location = New System.Drawing.Point(20, 49)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(610, 35)
        Me.TextBox2.TabIndex = 85
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBox1.Location = New System.Drawing.Point(20, 6)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(610, 35)
        Me.TextBox1.TabIndex = 84
        '
        'btnDone
        '
        Me.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDone.Location = New System.Drawing.Point(640, 5)
        Me.btnDone.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(178, 38)
        Me.btnDone.TabIndex = 0
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblLoadingPreview)
        Me.Panel4.Controls.Add(Me.PictureBox1)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.btnEditAddress)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 265)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(831, 55)
        Me.Panel4.TabIndex = 89
        '
        'lblLoadingPreview
        '
        Me.lblLoadingPreview.AutoSize = True
        Me.lblLoadingPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadingPreview.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblLoadingPreview.Location = New System.Drawing.Point(417, 12)
        Me.lblLoadingPreview.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLoadingPreview.Name = "lblLoadingPreview"
        Me.lblLoadingPreview.Size = New System.Drawing.Size(423, 29)
        Me.lblLoadingPreview.TabIndex = 191
        Me.lblLoadingPreview.Text = "... loading preview ... please wait ..."
        Me.lblLoadingPreview.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MassarelliShippingLabelApp.My.Resources.Resources.Edit01
        Me.PictureBox1.Location = New System.Drawing.Point(20, 17)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 23)
        Me.PictureBox1.TabIndex = 190
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(52, 18)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 20)
        Me.Label5.TabIndex = 189
        Me.Label5.Text = "&Edit:"
        '
        'btnEditAddress
        '
        Me.btnEditAddress.Enabled = False
        Me.btnEditAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditAddress.Location = New System.Drawing.Point(116, 9)
        Me.btnEditAddress.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnEditAddress.Name = "btnEditAddress"
        Me.btnEditAddress.Size = New System.Drawing.Size(178, 38)
        Me.btnEditAddress.TabIndex = 78
        Me.btnEditAddress.Text = "Edit Address"
        Me.btnEditAddress.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tbQtyLables)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.tbAddressForLabel)
        Me.Panel1.Controls.Add(Me.tbOrderNo)
        Me.Panel1.Controls.Add(Me.tbQtyLablesBack)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(831, 265)
        Me.Panel1.TabIndex = 85
        '
        'tbQtyLables
        '
        Me.tbQtyLables.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbQtyLables.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold)
        Me.tbQtyLables.Location = New System.Drawing.Point(669, 117)
        Me.tbQtyLables.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbQtyLables.Multiline = True
        Me.tbQtyLables.Name = "tbQtyLables"
        Me.tbQtyLables.Size = New System.Drawing.Size(122, 123)
        Me.tbQtyLables.TabIndex = 1
        Me.tbQtyLables.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(676, 52)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 33)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Pallets"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(644, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 33)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Number of "
        '
        'tbAddressForLabel
        '
        Me.tbAddressForLabel.BackColor = System.Drawing.SystemColors.Window
        Me.tbAddressForLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddressForLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.tbAddressForLabel.Location = New System.Drawing.Point(20, 94)
        Me.tbAddressForLabel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbAddressForLabel.Name = "tbAddressForLabel"
        Me.tbAddressForLabel.ReadOnly = True
        Me.tbAddressForLabel.Size = New System.Drawing.Size(610, 162)
        Me.tbAddressForLabel.TabIndex = 75
        Me.tbAddressForLabel.Text = ""
        '
        'tbOrderNo
        '
        Me.tbOrderNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tbOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbOrderNo.Location = New System.Drawing.Point(20, 17)
        Me.tbOrderNo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbOrderNo.Name = "tbOrderNo"
        Me.tbOrderNo.Size = New System.Drawing.Size(610, 66)
        Me.tbOrderNo.TabIndex = 0
        Me.tbOrderNo.Text = ""
        '
        'tbQtyLablesBack
        '
        Me.tbQtyLablesBack.BackColor = System.Drawing.SystemColors.Window
        Me.tbQtyLablesBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold)
        Me.tbQtyLablesBack.Location = New System.Drawing.Point(640, 94)
        Me.tbQtyLablesBack.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbQtyLablesBack.Multiline = True
        Me.tbQtyLablesBack.Name = "tbQtyLablesBack"
        Me.tbQtyLablesBack.ReadOnly = True
        Me.tbQtyLablesBack.Size = New System.Drawing.Size(176, 164)
        Me.tbQtyLablesBack.TabIndex = 0
        Me.tbQtyLablesBack.TabStop = False
        Me.tbQtyLablesBack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 934)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(831, 49)
        Me.Panel2.TabIndex = 82
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnRefreshDB)
        Me.Panel7.Controls.Add(Me.cbDBList)
        Me.Panel7.Controls.Add(Me.btnSaveDefaultDB)
        Me.Panel7.Controls.Add(Me.PictureBox2)
        Me.Panel7.Controls.Add(Me.Label7)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(365, 49)
        Me.Panel7.TabIndex = 83
        '
        'btnRefreshDB
        '
        Me.btnRefreshDB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshDB.Image = Global.MassarelliShippingLabelApp.My.Resources.Resources.Refresh_16_16
        Me.btnRefreshDB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefreshDB.Location = New System.Drawing.Point(286, 9)
        Me.btnRefreshDB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnRefreshDB.Name = "btnRefreshDB"
        Me.btnRefreshDB.Size = New System.Drawing.Size(34, 32)
        Me.btnRefreshDB.TabIndex = 190
        Me.btnRefreshDB.UseVisualStyleBackColor = True
        '
        'cbDBList
        '
        Me.cbDBList.FormattingEnabled = True
        Me.cbDBList.Location = New System.Drawing.Point(129, 9)
        Me.cbDBList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cbDBList.Name = "cbDBList"
        Me.cbDBList.Size = New System.Drawing.Size(146, 28)
        Me.cbDBList.TabIndex = 189
        '
        'btnSaveDefaultDB
        '
        Me.btnSaveDefaultDB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveDefaultDB.Image = Global.MassarelliShippingLabelApp.My.Resources.Resources.SaveAsDefault
        Me.btnSaveDefaultDB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveDefaultDB.Location = New System.Drawing.Point(321, 9)
        Me.btnSaveDefaultDB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSaveDefaultDB.Name = "btnSaveDefaultDB"
        Me.btnSaveDefaultDB.Size = New System.Drawing.Size(34, 32)
        Me.btnSaveDefaultDB.TabIndex = 191
        Me.btnSaveDefaultDB.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.MassarelliShippingLabelApp.My.Resources.Resources.DataBase
        Me.PictureBox2.Location = New System.Drawing.Point(20, 12)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 23)
        Me.PictureBox2.TabIndex = 188
        Me.PictureBox2.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(52, 14)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 20)
        Me.Label7.TabIndex = 187
        Me.Label7.Text = "&Data:"
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(365, 0)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(466, 49)
        Me.Panel6.TabIndex = 82
        '
        'Timer3
        '
        '
        'MassarelliShippingLabels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 1017)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbDataPath)
        Me.Controls.Add(Me.tbPreviewPath)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "MassarelliShippingLabels"
        Me.Text = "Print Shipping Labels"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblPricingType As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDivider1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDivider2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCurrentDB As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDivider3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDefaultDB As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents tbPreviewPath As System.Windows.Forms.TextBox
    Friend WithEvents tbDataPath As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ControlBarTender1 As MassarelliShippingLabelApp.ControlBarTender
    Friend WithEvents tbQtyLables As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbAddressForLabel As System.Windows.Forms.RichTextBox
    Friend WithEvents tbOrderNo As System.Windows.Forms.RichTextBox
    Friend WithEvents tbQtyLablesBack As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnEditAddress As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnRefreshDB As System.Windows.Forms.Button
    Friend WithEvents cbDBList As System.Windows.Forms.ComboBox
    Friend WithEvents btnSaveDefaultDB As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents lblLoadingPreview As System.Windows.Forms.Label

End Class
