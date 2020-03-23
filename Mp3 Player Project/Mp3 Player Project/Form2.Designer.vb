<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.BTVOLDOWN = New System.Windows.Forms.Button()
        Me.BTMUTE = New System.Windows.Forms.Button()
        Me.TFINDSONG = New System.Windows.Forms.TextBox()
        Me.MyTRVolume = New System.Windows.Forms.TrackBar()
        Me.LISTBOXPLAYLIST = New System.Windows.Forms.ListBox()
        Me.BTVOLUMEUP = New System.Windows.Forms.Button()
        Me.BTRESUME = New System.Windows.Forms.Button()
        Me.BTSTOP = New System.Windows.Forms.Button()
        Me.BTPLAY = New System.Windows.Forms.Button()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.TSETPLAY = New System.Windows.Forms.Timer(Me.components)
        Me.TFORPB = New System.Windows.Forms.Timer(Me.components)
        Me.import = New System.Windows.Forms.OpenFileDialog()
        CType(Me.MyTRVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTVOLDOWN
        '
        Me.BTVOLDOWN.Location = New System.Drawing.Point(679, 292)
        Me.BTVOLDOWN.Name = "BTVOLDOWN"
        Me.BTVOLDOWN.Size = New System.Drawing.Size(69, 28)
        Me.BTVOLDOWN.TabIndex = 78
        Me.BTVOLDOWN.Text = "VOL.DOWN"
        Me.BTVOLDOWN.UseVisualStyleBackColor = True
        '
        'BTMUTE
        '
        Me.BTMUTE.Location = New System.Drawing.Point(674, 346)
        Me.BTMUTE.Name = "BTMUTE"
        Me.BTMUTE.Size = New System.Drawing.Size(74, 28)
        Me.BTMUTE.TabIndex = 77
        Me.BTMUTE.Text = "MUTE"
        Me.BTMUTE.UseVisualStyleBackColor = True
        '
        'TFINDSONG
        '
        Me.TFINDSONG.Location = New System.Drawing.Point(154, -24)
        Me.TFINDSONG.Margin = New System.Windows.Forms.Padding(4)
        Me.TFINDSONG.Name = "TFINDSONG"
        Me.TFINDSONG.Size = New System.Drawing.Size(315, 22)
        Me.TFINDSONG.TabIndex = 75
        Me.TFINDSONG.Text = "Search ..."
        '
        'MyTRVolume
        '
        Me.MyTRVolume.BackColor = System.Drawing.SystemColors.Desktop
        Me.MyTRVolume.Location = New System.Drawing.Point(692, 48)
        Me.MyTRVolume.Margin = New System.Windows.Forms.Padding(4)
        Me.MyTRVolume.Maximum = 100
        Me.MyTRVolume.Name = "MyTRVolume"
        Me.MyTRVolume.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.MyTRVolume.Size = New System.Drawing.Size(56, 224)
        Me.MyTRVolume.TabIndex = 74
        Me.MyTRVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'LISTBOXPLAYLIST
        '
        Me.LISTBOXPLAYLIST.FormattingEnabled = True
        Me.LISTBOXPLAYLIST.ItemHeight = 16
        Me.LISTBOXPLAYLIST.Location = New System.Drawing.Point(52, 7)
        Me.LISTBOXPLAYLIST.Margin = New System.Windows.Forms.Padding(4)
        Me.LISTBOXPLAYLIST.Name = "LISTBOXPLAYLIST"
        Me.LISTBOXPLAYLIST.Size = New System.Drawing.Size(569, 308)
        Me.LISTBOXPLAYLIST.TabIndex = 72
        '
        'BTVOLUMEUP
        '
        Me.BTVOLUMEUP.Location = New System.Drawing.Point(675, 15)
        Me.BTVOLUMEUP.Margin = New System.Windows.Forms.Padding(4)
        Me.BTVOLUMEUP.Name = "BTVOLUMEUP"
        Me.BTVOLUMEUP.Size = New System.Drawing.Size(73, 28)
        Me.BTVOLUMEUP.TabIndex = 69
        Me.BTVOLUMEUP.Text = "Vol. Up"
        Me.BTVOLUMEUP.UseVisualStyleBackColor = True
        '
        'BTRESUME
        '
        Me.BTRESUME.Location = New System.Drawing.Point(258, 323)
        Me.BTRESUME.Margin = New System.Windows.Forms.Padding(4)
        Me.BTRESUME.Name = "BTRESUME"
        Me.BTRESUME.Size = New System.Drawing.Size(100, 28)
        Me.BTRESUME.TabIndex = 66
        Me.BTRESUME.Text = "Resume"
        Me.BTRESUME.UseVisualStyleBackColor = True
        '
        'BTSTOP
        '
        Me.BTSTOP.Location = New System.Drawing.Point(411, 323)
        Me.BTSTOP.Margin = New System.Windows.Forms.Padding(4)
        Me.BTSTOP.Name = "BTSTOP"
        Me.BTSTOP.Size = New System.Drawing.Size(100, 28)
        Me.BTSTOP.TabIndex = 65
        Me.BTSTOP.Text = "Stop"
        Me.BTSTOP.UseVisualStyleBackColor = True
        '
        'BTPLAY
        '
        Me.BTPLAY.Location = New System.Drawing.Point(99, 323)
        Me.BTPLAY.Margin = New System.Windows.Forms.Padding(4)
        Me.BTPLAY.Name = "BTPLAY"
        Me.BTPLAY.Size = New System.Drawing.Size(100, 28)
        Me.BTPLAY.TabIndex = 64
        Me.BTPLAY.Text = "Play"
        Me.BTPLAY.UseVisualStyleBackColor = True
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(124, 460)
        Me.AxWindowsMediaPlayer1.Margin = New System.Windows.Forms.Padding(4)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(75, 23)
        Me.AxWindowsMediaPlayer1.TabIndex = 73
        '
        'TSETPLAY
        '
        Me.TSETPLAY.Enabled = True
        '
        'TFORPB
        '
        '
        'import
        '
        Me.import.FileName = "Find Mp3 Player"
        Me.import.Filter = "Audio Files (*.*)|*.mp3"
        Me.import.Multiselect = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.BTVOLDOWN)
        Me.Controls.Add(Me.BTMUTE)
        Me.Controls.Add(Me.TFINDSONG)
        Me.Controls.Add(Me.MyTRVolume)
        Me.Controls.Add(Me.LISTBOXPLAYLIST)
        Me.Controls.Add(Me.BTVOLUMEUP)
        Me.Controls.Add(Me.BTRESUME)
        Me.Controls.Add(Me.BTSTOP)
        Me.Controls.Add(Me.BTPLAY)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.MyTRVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTVOLDOWN As Button
    Friend WithEvents BTMUTE As Button
    Friend WithEvents TFINDSONG As TextBox
    Friend WithEvents MyTRVolume As TrackBar
    Friend WithEvents LISTBOXPLAYLIST As ListBox
    Friend WithEvents BTVOLUMEUP As Button
    Friend WithEvents BTRESUME As Button
    Friend WithEvents BTSTOP As Button
    Friend WithEvents BTPLAY As Button
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents TSETPLAY As Timer
    Friend WithEvents TFORPB As Timer
    Friend WithEvents import As OpenFileDialog
End Class
