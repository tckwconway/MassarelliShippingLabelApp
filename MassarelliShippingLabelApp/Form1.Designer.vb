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
        Me.tbOrderNo = New System.Windows.Forms.RichTextBox()
        Me.btnRefreshDB = New System.Windows.Forms.Button()
        Me.cbDBList = New System.Windows.Forms.ComboBox()
        Me.btnSaveDefaultDB = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblPricingType = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDivider1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDivider2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblCurrentDB = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDivider3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDefaultDB = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tbAddressForLabel = New System.Windows.Forms.RichTextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbQtyLables = New System.Windows.Forms.TextBox()
        Me.ControlBarTender1 = New MassarelliShippingLabelApp.ControlBarTender()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbOrderNo
        '
        Me.tbOrderNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tbOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbOrderNo.Location = New System.Drawing.Point(12, 12)
        Me.tbOrderNo.Name = "tbOrderNo"
        Me.tbOrderNo.Size = New System.Drawing.Size(408, 44)
        Me.tbOrderNo.TabIndex = 1
        Me.tbOrderNo.Text = ""
        '
        'btnRefreshDB
        '
        Me.btnRefreshDB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefreshDB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefreshDB.Location = New System.Drawing.Point(155, 657)
        Me.btnRefreshDB.Name = "btnRefreshDB"
        Me.btnRefreshDB.Size = New System.Drawing.Size(23, 21)
        Me.btnRefreshDB.TabIndex = 24
        Me.btnRefreshDB.UseVisualStyleBackColor = True
        '
        'cbDBList
        '
        Me.cbDBList.FormattingEnabled = True
        Me.cbDBList.Location = New System.Drawing.Point(71, 657)
        Me.cbDBList.Name = "cbDBList"
        Me.cbDBList.Size = New System.Drawing.Size(79, 21)
        Me.cbDBList.TabIndex = 23
        '
        'btnSaveDefaultDB
        '
        Me.btnSaveDefaultDB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveDefaultDB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveDefaultDB.Location = New System.Drawing.Point(178, 657)
        Me.btnSaveDefaultDB.Name = "btnSaveDefaultDB"
        Me.btnSaveDefaultDB.Size = New System.Drawing.Size(23, 21)
        Me.btnSaveDefaultDB.TabIndex = 25
        Me.btnSaveDefaultDB.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(4, 660)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 13)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "Database"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPricingType, Me.lblDivider1, Me.lblCount, Me.lblDivider2, Me.lblCurrentDB, Me.lblDivider3, Me.lblDefaultDB})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 685)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(559, 22)
        Me.StatusStrip1.TabIndex = 61
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblPricingType
        '
        Me.lblPricingType.Name = "lblPricingType"
        Me.lblPricingType.Size = New System.Drawing.Size(0, 17)
        '
        'lblDivider1
        '
        Me.lblDivider1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lblDivider1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.lblDivider1.Name = "lblDivider1"
        Me.lblDivider1.Size = New System.Drawing.Size(4, 17)
        '
        'lblCount
        '
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 17)
        '
        'lblDivider2
        '
        Me.lblDivider2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lblDivider2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.lblDivider2.Name = "lblDivider2"
        Me.lblDivider2.Size = New System.Drawing.Size(4, 17)
        '
        'lblCurrentDB
        '
        Me.lblCurrentDB.Name = "lblCurrentDB"
        Me.lblCurrentDB.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCurrentDB.Size = New System.Drawing.Size(0, 17)
        Me.lblCurrentDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDivider3
        '
        Me.lblDivider3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lblDivider3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.lblDivider3.Name = "lblDivider3"
        Me.lblDivider3.Size = New System.Drawing.Size(4, 17)
        '
        'lblDefaultDB
        '
        Me.lblDefaultDB.Name = "lblDefaultDB"
        Me.lblDefaultDB.Size = New System.Drawing.Size(0, 17)
        Me.lblDefaultDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbAddressForLabel
        '
        Me.tbAddressForLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAddressForLabel.Location = New System.Drawing.Point(12, 62)
        Me.tbAddressForLabel.Name = "tbAddressForLabel"
        Me.tbAddressForLabel.Size = New System.Drawing.Size(408, 91)
        Me.tbAddressForLabel.TabIndex = 62
        Me.tbAddressForLabel.Text = ""
        '
        'Timer1
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(431, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 24)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Number of "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(451, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 24)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Labels"
        '
        'tbQtyLables
        '
        Me.tbQtyLables.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbQtyLables.Location = New System.Drawing.Point(426, 62)
        Me.tbQtyLables.Multiline = True
        Me.tbQtyLables.Name = "tbQtyLables"
        Me.tbQtyLables.Size = New System.Drawing.Size(119, 91)
        Me.tbQtyLables.TabIndex = 66
        Me.tbQtyLables.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ControlBarTender1
        '
        Me.ControlBarTender1.Location = New System.Drawing.Point(4, 159)
        Me.ControlBarTender1.Name = "ControlBarTender1"
        Me.ControlBarTender1.Size = New System.Drawing.Size(549, 498)
        Me.ControlBarTender1.TabIndex = 63
        '
        'MassarelliShippingLabels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 707)
        Me.Controls.Add(Me.tbQtyLables)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ControlBarTender1)
        Me.Controls.Add(Me.tbAddressForLabel)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnRefreshDB)
        Me.Controls.Add(Me.cbDBList)
        Me.Controls.Add(Me.btnSaveDefaultDB)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.tbOrderNo)
        Me.Name = "MassarelliShippingLabels"
        Me.Text = "Print Shipping Labels"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbOrderNo As System.Windows.Forms.RichTextBox
    Friend WithEvents btnRefreshDB As System.Windows.Forms.Button
    Friend WithEvents cbDBList As System.Windows.Forms.ComboBox
    Friend WithEvents btnSaveDefaultDB As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblPricingType As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDivider1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDivider2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCurrentDB As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDivider3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDefaultDB As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tbAddressForLabel As System.Windows.Forms.RichTextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ControlBarTender1 As MassarelliShippingLabelApp.ControlBarTender
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbQtyLables As System.Windows.Forms.TextBox

End Class
