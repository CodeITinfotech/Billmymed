<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GraphSales
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtf = New System.Windows.Forms.DateTimePicker()
        Me.dtt = New System.Windows.Forms.DateTimePicker()
        Me.Btnview = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdline = New System.Windows.Forms.RadioButton()
        Me.reBar = New System.Windows.Forms.RadioButton()
        Me.chkmon = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblminc = New System.Windows.Forms.Label()
        Me.lbllo = New System.Windows.Forms.Label()
        Me.lblhi = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblavg = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblpro = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbltot = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.gr = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblwait = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(232, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "To"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(53, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "From"
        '
        'dtf
        '
        Me.dtf.CustomFormat = "dd/MM/yyyy"
        Me.dtf.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtf.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtf.Location = New System.Drawing.Point(99, 17)
        Me.dtf.Name = "dtf"
        Me.dtf.Size = New System.Drawing.Size(127, 22)
        Me.dtf.TabIndex = 11
        '
        'dtt
        '
        Me.dtt.CustomFormat = "dd/MM/yyyy"
        Me.dtt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtt.Location = New System.Drawing.Point(262, 16)
        Me.dtt.Name = "dtt"
        Me.dtt.Size = New System.Drawing.Size(127, 22)
        Me.dtt.TabIndex = 10
        '
        'Btnview
        '
        Me.Btnview.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btnview.Location = New System.Drawing.Point(399, 15)
        Me.Btnview.Name = "Btnview"
        Me.Btnview.Size = New System.Drawing.Size(75, 25)
        Me.Btnview.TabIndex = 15
        Me.Btnview.Text = "View"
        Me.Btnview.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdline)
        Me.GroupBox2.Controls.Add(Me.reBar)
        Me.GroupBox2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(480, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(131, 39)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        '
        'rdline
        '
        Me.rdline.AutoSize = True
        Me.rdline.Checked = True
        Me.rdline.Location = New System.Drawing.Point(6, 16)
        Me.rdline.Name = "rdline"
        Me.rdline.Size = New System.Drawing.Size(58, 20)
        Me.rdline.TabIndex = 1
        Me.rdline.TabStop = True
        Me.rdline.Text = "Line"
        Me.rdline.UseVisualStyleBackColor = True
        '
        'reBar
        '
        Me.reBar.AutoSize = True
        Me.reBar.Location = New System.Drawing.Point(73, 16)
        Me.reBar.Name = "reBar"
        Me.reBar.Size = New System.Drawing.Size(50, 20)
        Me.reBar.TabIndex = 0
        Me.reBar.Text = "Bar"
        Me.reBar.UseVisualStyleBackColor = True
        '
        'chkmon
        '
        Me.chkmon.AutoSize = True
        Me.chkmon.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkmon.Location = New System.Drawing.Point(627, 24)
        Me.chkmon.Name = "chkmon"
        Me.chkmon.Size = New System.Drawing.Size(83, 20)
        Me.chkmon.TabIndex = 19
        Me.chkmon.Text = "Monthly"
        Me.chkmon.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(374, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 22)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Sales Graph"
        '
        'lblminc
        '
        Me.lblminc.AutoSize = True
        Me.lblminc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblminc.Location = New System.Drawing.Point(3, 10)
        Me.lblminc.Name = "lblminc"
        Me.lblminc.Size = New System.Drawing.Size(48, 16)
        Me.lblminc.TabIndex = 22
        Me.lblminc.Text = "Low :"
        '
        'lbllo
        '
        Me.lbllo.AutoSize = True
        Me.lbllo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllo.Location = New System.Drawing.Point(61, 10)
        Me.lbllo.Name = "lbllo"
        Me.lbllo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbllo.Size = New System.Drawing.Size(40, 16)
        Me.lbllo.TabIndex = 23
        Me.lbllo.Text = "0.00"
        '
        'lblhi
        '
        Me.lblhi.AutoSize = True
        Me.lblhi.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhi.Location = New System.Drawing.Point(61, 26)
        Me.lblhi.Name = "lblhi"
        Me.lblhi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblhi.Size = New System.Drawing.Size(40, 16)
        Me.lblhi.TabIndex = 25
        Me.lblhi.Text = "0.00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "High:"
        '
        'lblavg
        '
        Me.lblavg.AutoSize = True
        Me.lblavg.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblavg.Location = New System.Drawing.Point(247, 10)
        Me.lblavg.Name = "lblavg"
        Me.lblavg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblavg.Size = New System.Drawing.Size(40, 16)
        Me.lblavg.TabIndex = 27
        Me.lblavg.Text = "0.00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(181, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Avg:"
        '
        'lblpro
        '
        Me.lblpro.AutoSize = True
        Me.lblpro.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpro.Location = New System.Drawing.Point(445, 26)
        Me.lblpro.Name = "lblpro"
        Me.lblpro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblpro.Size = New System.Drawing.Size(56, 16)
        Me.lblpro.TabIndex = 29
        Me.lblpro.Text = "Wait.."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(375, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(64, 16)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "Profit:"
        '
        'lbltot
        '
        Me.lbltot.AutoSize = True
        Me.lbltot.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltot.Location = New System.Drawing.Point(247, 26)
        Me.lbltot.Name = "lbltot"
        Me.lbltot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbltot.Size = New System.Drawing.Size(40, 16)
        Me.lbltot.TabIndex = 31
        Me.lbltot.Text = "0.00"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(181, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Total:"
        '
        'bw
        '
        Me.bw.WorkerSupportsCancellation = True
        '
        'gr
        '
        Me.gr.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gr.BackColor = System.Drawing.Color.Wheat
        Me.gr.BorderSkin.BackColor = System.Drawing.Color.Maroon
        ChartArea1.Area3DStyle.Enable3D = True
        ChartArea1.AxisX.Interval = 1.0R
        ChartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea1.Name = "ChartArea1"
        Me.gr.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.gr.Legends.Add(Legend1)
        Me.gr.Location = New System.Drawing.Point(0, 63)
        Me.gr.Name = "gr"
        Series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Series1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Cross
        Series1.BackSecondaryColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Series1.BorderColor = System.Drawing.Color.Red
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series1.Color = System.Drawing.Color.Red
        Series1.CustomProperties = "IsXAxisQuantitative=False"
        Series1.Label = "*"
        Series1.LabelToolTip = "#VAL{D2}"
        Series1.Legend = "Legend1"
        Series1.Name = "Sales"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[String]
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series2.Legend = "Legend1"
        Series2.Name = "Average"
        Me.gr.Series.Add(Series1)
        Me.gr.Series.Add(Series2)
        Me.gr.Size = New System.Drawing.Size(904, 400)
        Me.gr.TabIndex = 32
        Me.gr.Text = "Chart1"
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.lbltot)
        Me.Panel1.Controls.Add(Me.lblminc)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.lbllo)
        Me.Panel1.Controls.Add(Me.lblpro)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblhi)
        Me.Panel1.Controls.Add(Me.lblavg)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(0, 469)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(904, 49)
        Me.Panel1.TabIndex = 33
        '
        'lblwait
        '
        Me.lblwait.AutoSize = True
        Me.lblwait.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblwait.ForeColor = System.Drawing.Color.Blue
        Me.lblwait.Location = New System.Drawing.Point(378, 218)
        Me.lblwait.Name = "lblwait"
        Me.lblwait.Size = New System.Drawing.Size(153, 22)
        Me.lblwait.TabIndex = 34
        Me.lblwait.Text = "Please wait.."
        '
        'GraphSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Wheat
        Me.ClientSize = New System.Drawing.Size(916, 517)
        Me.Controls.Add(Me.lblwait)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gr)
        Me.Controls.Add(Me.chkmon)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Btnview)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtf)
        Me.Controls.Add(Me.dtt)
        Me.Name = "GraphSales"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Graph"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtf As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtt As System.Windows.Forms.DateTimePicker
    Friend WithEvents Btnview As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdline As System.Windows.Forms.RadioButton
    Friend WithEvents reBar As System.Windows.Forms.RadioButton
    Friend WithEvents chkmon As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblminc As System.Windows.Forms.Label
    Friend WithEvents lbllo As System.Windows.Forms.Label
    Friend WithEvents lblhi As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblavg As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblpro As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbltot As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
    Friend WithEvents gr As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblwait As System.Windows.Forms.Label
End Class
