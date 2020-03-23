<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTVOLDOWN = New System.Windows.Forms.Button()
        Me.BTMUTE = New System.Windows.Forms.Button()
        Me.TSETPLAY = New System.Windows.Forms.Timer(Me.components)
        Me.TFORPB = New System.Windows.Forms.Timer(Me.components)
        Me.import = New System.Windows.Forms.OpenFileDialog()
        Me.MyTRVolume = New System.Windows.Forms.TrackBar()
        Me.LBLCOUNT = New System.Windows.Forms.Label()
        Me.LBLFORREPEAT = New System.Windows.Forms.Label()
        Me.BTVOLUMEUP = New System.Windows.Forms.Button()
        Me.BTOPEN = New System.Windows.Forms.Button()
        Me.BTRESUME = New System.Windows.Forms.Button()
        Me.BTSTOP = New System.Windows.Forms.Button()
        Me.BTPLAY = New System.Windows.Forms.Button()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.MyTRVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Location = New System.Drawing.Point(363, 2)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(201, 55)
        Me.Panel5.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 25)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Favorites"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Location = New System.Drawing.Point(205, 2)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(152, 55)
        Me.Panel4.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "PlayList"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(57, 2)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(143, 55)
        Me.Panel3.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Home"
        '
        'BTVOLDOWN
        '
        Me.BTVOLDOWN.Location = New System.Drawing.Point(907, 486)
        Me.BTVOLDOWN.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BTVOLDOWN.Name = "BTVOLDOWN"
        Me.BTVOLDOWN.Size = New System.Drawing.Size(112, 28)
        Me.BTVOLDOWN.TabIndex = 61
        Me.BTVOLDOWN.Text = "Volume Down"
        Me.BTVOLDOWN.UseVisualStyleBackColor = True
        '
        'BTMUTE
        '
        Me.BTMUTE.Location = New System.Drawing.Point(927, 521)
        Me.BTMUTE.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BTMUTE.Name = "BTMUTE"
        Me.BTMUTE.Size = New System.Drawing.Size(75, 28)
        Me.BTMUTE.TabIndex = 60
        Me.BTMUTE.Text = "Mute"
        Me.BTMUTE.UseVisualStyleBackColor = True
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
        'MyTRVolume
        '
        Me.MyTRVolume.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.MyTRVolume.Location = New System.Drawing.Point(942, 241)
        Me.MyTRVolume.Margin = New System.Windows.Forms.Padding(4)
        Me.MyTRVolume.Maximum = 100
        Me.MyTRVolume.Name = "MyTRVolume"
        Me.MyTRVolume.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.MyTRVolume.Size = New System.Drawing.Size(56, 224)
        Me.MyTRVolume.TabIndex = 57
        Me.MyTRVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'LBLCOUNT
        '
        Me.LBLCOUNT.AutoSize = True
        Me.LBLCOUNT.Location = New System.Drawing.Point(-233, 42)
        Me.LBLCOUNT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLCOUNT.Name = "LBLCOUNT"
        Me.LBLCOUNT.Size = New System.Drawing.Size(51, 17)
        Me.LBLCOUNT.TabIndex = 54
        Me.LBLCOUNT.Text = "Label1"
        '
        'LBLFORREPEAT
        '
        Me.LBLFORREPEAT.AutoSize = True
        Me.LBLFORREPEAT.Location = New System.Drawing.Point(-56, 516)
        Me.LBLFORREPEAT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LBLFORREPEAT.Name = "LBLFORREPEAT"
        Me.LBLFORREPEAT.Size = New System.Drawing.Size(18, 17)
        Me.LBLFORREPEAT.TabIndex = 52
        Me.LBLFORREPEAT.Text = "R"
        '
        'BTVOLUMEUP
        '
        Me.BTVOLUMEUP.Location = New System.Drawing.Point(907, 205)
        Me.BTVOLUMEUP.Margin = New System.Windows.Forms.Padding(4)
        Me.BTVOLUMEUP.Name = "BTVOLUMEUP"
        Me.BTVOLUMEUP.Size = New System.Drawing.Size(109, 28)
        Me.BTVOLUMEUP.TabIndex = 49
        Me.BTVOLUMEUP.Text = "Volume Up"
        Me.BTVOLUMEUP.UseVisualStyleBackColor = True
        '
        'BTOPEN
        '
        Me.BTOPEN.Location = New System.Drawing.Point(36, -82)
        Me.BTOPEN.Margin = New System.Windows.Forms.Padding(4)
        Me.BTOPEN.Name = "BTOPEN"
        Me.BTOPEN.Size = New System.Drawing.Size(11, 10)
        Me.BTOPEN.TabIndex = 47
        Me.BTOPEN.Text = "Open"
        Me.BTOPEN.UseVisualStyleBackColor = True
        '
        'BTRESUME
        '
        Me.BTRESUME.Location = New System.Drawing.Point(346, 521)
        Me.BTRESUME.Margin = New System.Windows.Forms.Padding(4)
        Me.BTRESUME.Name = "BTRESUME"
        Me.BTRESUME.Size = New System.Drawing.Size(115, 28)
        Me.BTRESUME.TabIndex = 45
        Me.BTRESUME.Text = "Resume Song"
        Me.BTRESUME.UseVisualStyleBackColor = True
        '
        'BTSTOP
        '
        Me.BTSTOP.Location = New System.Drawing.Point(206, 521)
        Me.BTSTOP.Margin = New System.Windows.Forms.Padding(4)
        Me.BTSTOP.Name = "BTSTOP"
        Me.BTSTOP.Size = New System.Drawing.Size(100, 28)
        Me.BTSTOP.TabIndex = 44
        Me.BTSTOP.Text = "Stop Song"
        Me.BTSTOP.UseVisualStyleBackColor = True
        '
        'BTPLAY
        '
        Me.BTPLAY.Location = New System.Drawing.Point(71, 521)
        Me.BTPLAY.Margin = New System.Windows.Forms.Padding(4)
        Me.BTPLAY.Name = "BTPLAY"
        Me.BTPLAY.Size = New System.Drawing.Size(100, 28)
        Me.BTPLAY.TabIndex = 43
        Me.BTPLAY.Text = "Play Song"
        Me.BTPLAY.UseVisualStyleBackColor = True
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(539, 392)
        Me.AxWindowsMediaPlayer1.Margin = New System.Windows.Forms.Padding(4)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(75, 23)
        Me.AxWindowsMediaPlayer1.TabIndex = 55
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(71, 178)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(249, 206)
        Me.PictureBox1.TabIndex = 62
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(169, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Song"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(169, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 17)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Singer"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(409, 98)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(464, 395)
        Me.RichTextBox1.TabIndex = 65
        Me.RichTextBox1.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(914, 116)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 39)
        Me.Button1.TabIndex = 66
        Me.Button1.Text = "Add My Fav"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1064, 708)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.BTVOLDOWN)
        Me.Controls.Add(Me.BTMUTE)
        Me.Controls.Add(Me.MyTRVolume)
        Me.Controls.Add(Me.LBLCOUNT)
        Me.Controls.Add(Me.LBLFORREPEAT)
        Me.Controls.Add(Me.BTVOLUMEUP)
        Me.Controls.Add(Me.BTOPEN)
        Me.Controls.Add(Me.BTRESUME)
        Me.Controls.Add(Me.BTSTOP)
        Me.Controls.Add(Me.BTPLAY)
        Me.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form3"
        Me.Text = "Favorites "
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.MyTRVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents BTVOLDOWN As Button
    Friend WithEvents BTMUTE As Button
    Friend WithEvents TSETPLAY As Timer
    Friend WithEvents TFORPB As Timer
    Friend WithEvents import As OpenFileDialog
    Friend WithEvents MyTRVolume As TrackBar
    Friend WithEvents LBLCOUNT As Label
    Friend WithEvents LBLFORREPEAT As Label
    Friend WithEvents BTVOLUMEUP As Button
    Friend WithEvents BTOPEN As Button
    Friend WithEvents BTRESUME As Button
    Friend WithEvents BTSTOP As Button
    Friend WithEvents BTPLAY As Button
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Button1 As Button
End Class
