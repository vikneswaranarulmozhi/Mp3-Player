Imports System.IO
Imports System.Data.OleDb
Imports System.Runtime.InteropServices



Public Class Form2
#Region "mp3-declare"
    Public Class Mp3Song
        Private _artist As String
        Private _songName As String
        Private _path As String
        Private _panjang As String
        Public Property Artist() As String
            Get
                Return _artist
            End Get
            Set(ByVal value As String)
                Me._artist = value
            End Set
        End Property
        Public Property SongName() As String
            Get
                Return _songName
            End Get
            Set(ByVal value As String)
                Me._songName = value
            End Set
        End Property
        Public Property FullName() As String
            Get
                Return _path
            End Get
            Set(ByVal value As String)
                Me._path = value
            End Set
        End Property
        Public Property Panjang() As String
            Get
                Return _panjang
            End Get
            Set(ByVal value As String)
                Me._panjang = value
            End Set
        End Property
        Public ReadOnly Property Name()
            Get
                Dim ch() As Char = {Convert.ToChar(&H20), Convert.ToChar(&H0)}
                Me._artist = Me._artist.Trim(ch)
                Me._songName = Me._songName.TrimEnd(ch)
                Return _artist & " >> " & _songName & Panjang
            End Get
        End Property
    End Class
#End Region
#Region "for-database-connect"
    Dim myconnection As New accessdata.koneksidata
    Dim objconnection As OleDbConnection
    Dim mycmd As New OleDbCommand
    Dim objdataadapter As OleDbDataAdapter
    Dim objdatareader As OleDbDataReader
    Dim objdataset As New DataSet
    Dim objdatatable As New DataTable
#End Region


#Region "playlist-in-db"
    'This for our save playlist/audio in database
    Sub simpanini()
        Try
            myconnection.close()
            Dim arrayname() As String = import.FileNames
            For Each nameku As String In arrayname
                Using sql As New OleDb.OleDbCommand("insert into tbplaylist (path) values('" & Replace(nameku, "'", "''") & "')", myconnection.open)
                    If import.FileName = Nothing Then
                    Else
                        For Each track As String In import.FileNames
                            sql.Parameters.Add(New OleDb.OleDbParameter("'" & Replace(nameku, "'", "''") & "'", OleDbType.LongVarChar)).Value = (Replace(track, "'", "''"))
                        Next
                    End If
                    sql.ExecuteNonQuery()
                    myconnection.close()
                End Using
                myconnection.close()
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            myconnection.close()
            Exit Sub
        End Try
        myconnection.close()
    End Sub
    'Add playlist from database into listbox
    Private Sub TambahSoNiDB(ByVal Mp3FilePathsSoNi As String())
        Try
            Me.LISTBOXPLAYLIST.Items.Clear()
            myconnection.close()
            mycmd = myconnection.open.CreateCommand
            mycmd.CommandText = "select * from path where logid like '" & "%" & Form1.TextBox1.Text & "%" & "'"
            objdatareader = mycmd.ExecuteReader
            While objdatareader.Read
                Dim kamuku As String = objdatareader.Item("path").ToString
                If My.Computer.FileSystem.FileExists(kamuku) Then
                    Dim fs As New FileStream(kamuku, FileMode.Open, IO.FileAccess.Read)
                    If fs.Length > 128 Then
                        fs.Position = (fs.Length - 128)
                        Dim TagBytes(2) As Byte
                        fs.Read(TagBytes, 0, 3)
                        Dim tag As String = System.Text.Encoding.Default.GetString(TagBytes)
                        If (tag.ToUpper().Equals("TAG")) Then
                            Dim TitleBytes(30) As Byte
                            fs.Read(TitleBytes, 0, 30)
                            Dim Title As String = System.Text.Encoding.Default.GetString(TitleBytes)
                            Dim ArtistBytes(30) As Byte
                            fs.Read(ArtistBytes, 0, 30)
                            Dim Artist As String = System.Text.Encoding.Default.GetString(ArtistBytes)
                            Dim song As Mp3Song = New Mp3Song
                            Dim media As WMPLib.IWMPMedia = Me.AxWindowsMediaPlayer1.newMedia(kamuku)
                            Dim lenghtsoni As String = media.durationString
                            For m = 1 To (LISTBOXPLAYLIST.Items.Count) + (1)
                                With song
                                    .FullName = kamuku
                                    .Artist = m & ". " & Artist
                                    .SongName = Title
                                    .Panjang = "®" & lenghtsoni
                                End With
                            Next
                            LISTBOXPLAYLIST.DrawMode = DrawMode.OwnerDrawFixed
                            Me.LISTBOXPLAYLIST.Items.Add(song)
                            Me.LISTBOXPLAYLIST.ValueMember = "FullName"
                            Me.LISTBOXPLAYLIST.DisplayMember = "Name"
                        Else
                            Dim f = New IO.FileInfo(kamuku)
                            Dim song As Mp3Song = New Mp3Song
                            Dim media As WMPLib.IWMPMedia = Me.AxWindowsMediaPlayer1.newMedia(kamuku)
                            Dim lenghtsoni As String = media.durationString
                            For m = 1 To (LISTBOXPLAYLIST.Items.Count) + (1)
                                With song
                                    .FullName = kamuku
                                    .Artist = m & ". No Artist"
                                    .SongName = System.IO.Path.GetFileNameWithoutExtension(f.FullName)
                                    .Panjang = "®" & lenghtsoni
                                End With
                            Next
                            LISTBOXPLAYLIST.DrawMode = DrawMode.OwnerDrawFixed
                            Me.LISTBOXPLAYLIST.Items.Add(song)
                            Me.LISTBOXPLAYLIST.ValueMember = "FullName"
                            Me.LISTBOXPLAYLIST.DisplayMember = "Name"
                        End If
                        fs.Close()
                    Else
                        Dim f = New IO.FileInfo(kamuku)
                        Dim song As Mp3Song = New Mp3Song
                        Dim media As WMPLib.IWMPMedia = Me.AxWindowsMediaPlayer1.newMedia(kamuku)
                        Dim lenghtsoni As String = media.durationString
                        For m = 1 To (LISTBOXPLAYLIST.Items.Count) + (1)
                            With song
                                .FullName = kamuku
                                .Artist = m & ". No Artist"
                                .SongName = System.IO.Path.GetFileNameWithoutExtension(f.FullName)
                                .Panjang = "®" & lenghtsoni
                            End With
                        Next
                        LISTBOXPLAYLIST.DrawMode = DrawMode.OwnerDrawFixed
                        Me.LISTBOXPLAYLIST.Items.Add(song)
                        Me.LISTBOXPLAYLIST.ValueMember = "FullName"
                        Me.LISTBOXPLAYLIST.DisplayMember = "Name"
                    End If
                    fs.Close()
                Else
                End If
            End While
            myconnection.close()

        Catch ex As Exception
            myconnection.close()
            Exit Sub
        End Try
        myconnection.close()
    End Sub
    'Count the playlist

#End Region
#Region "general command"
    Sub masukkandanbuka()
        If Me.import.ShowDialog() = Windows.Forms.DialogResult.OK Then
            simpanini()
            tambahdaridb()
        Else
        End If
    End Sub
    Sub tambahdaridb()
        Dim SoniSiteZku As String() = Me.import.FileNames()
        TambahSoNiDB(SoniSiteZku)
        Me.LISTBOXPLAYLIST.ValueMember = "FullName"
        Me.LISTBOXPLAYLIST.DisplayMember = "Name"
    End Sub
#End Region

    Private Sub LISTBOXPLAYLIST_DrawItem(sender As Object, e As DrawItemEventArgs) Handles LISTBOXPLAYLIST.DrawItem
        e.DrawBackground()
        If e.Index > -1 Then
            Using sf As New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Far, .Trimming = StringTrimming.EllipsisCharacter, .FormatFlags = StringFormatFlags.NoWrap}
                Using br As New SolidBrush(Color.Red)
                    With e.Graphics
                        If (CType(Me.LISTBOXPLAYLIST.Items.Item(e.Index), Mp3Song).Name).ToString.Contains(ChrW(174)) Then
                            If CBool(e.State And DrawItemState.Selected) Then
                                Dim Elements() As String = (CType(Me.LISTBOXPLAYLIST.Items.Item(e.Index), Mp3Song).Name).ToString.Split(ChrW(174))
                                .DrawString(Elements(0), e.Font, Brushes.White, New Rectangle(0, e.Bounds.Y, e.Bounds.Width \ 1, e.Bounds.Height), sf)
                                sf.Alignment = StringAlignment.Far
                                .DrawString(Elements(1), e.Font, Brushes.White, New Rectangle(e.Bounds.Width \ 2, e.Bounds.Y, e.Bounds.Width \ 2, e.Bounds.Height), sf)
                            Else
                                Dim Elements() As String = (CType(Me.LISTBOXPLAYLIST.Items.Item(e.Index), Mp3Song).Name).ToString.Split(ChrW(174))
                                .DrawString(Elements(0), e.Font, br, New Rectangle(0, e.Bounds.Y, e.Bounds.Width \ 2, e.Bounds.Height), sf)
                                sf.Alignment = StringAlignment.Far
                                .DrawString(Elements(1), e.Font, br, New Rectangle(e.Bounds.Width \ 2, e.Bounds.Y, e.Bounds.Width \ 2, e.Bounds.Height), sf)
                            End If
                        Else
                        End If
                    End With
                    br.Dispose()
                End Using
            End Using
        End If
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tambahdaridb()


    End Sub

    Private Sub BTPLAY_Click(sender As Object, e As EventArgs) Handles BTPLAY.Click
        Me.Hide()
        Dim Form3 = New Form3()
        Form3.Show()
        'Play the audio
        'AxWindowsMediaPlayer1.URL = CType(Me.LISTBOXPLAYLIST.SelectedItem, Mp3Song).FullName
        '''Start timer for progressbar
        'TFORPB.Start()
        '''Audio Position Index
        'AudioPosition()
    End Sub
    Private Sub BTSTOP_Click(sender As Object, e As EventArgs) Handles BTSTOP.Click
        'Stop or Pause the audio
        AxWindowsMediaPlayer1.Ctlcontrols.pause()
    End Sub
    Private Sub BTRESUME_Click(sender As Object, e As EventArgs) Handles BTRESUME.Click
        'Resume the audio
        If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            AxWindowsMediaPlayer1.Ctlcontrols.pause()
        Else
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        End If
    End Sub
    Private Sub TFORPB_Tick(sender As Object, e As EventArgs) Handles TFORPB.Tick

    End Sub
    Dim AudPos As String
    Sub AudioPosition()
        AudPos = Me.LISTBOXPLAYLIST.SelectedIndex
    End Sub
    Private Sub BTBACK_Click(sender As Object, e As EventArgs)
        'Stop first and then play again
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        If Me.LISTBOXPLAYLIST.SelectedIndex <= 0 Then
            MsgBox("No song above selected !" & vbCrLf & "Please select another song !", MsgBoxStyle.Information, "No song selected !")
        Else
            'Get new index
            If Me.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then Me.LISTBOXPLAYLIST.SelectedIndex = (AudPos) - (1)
            'Play using new index
            AxWindowsMediaPlayer1.URL = CType(Me.LISTBOXPLAYLIST.SelectedItem, Mp3Song).FullName
        End If
        'Get new audio position value
        AudioPosition()
    End Sub


    'Variable for configure command
    Private Const APPCOMMAND_VOLUME_MUTE As Integer = &H80000
    Private Const APPCOMMAND_VOLUME_UP As Integer = &HA0000
    Private Const APPCOMMAND_VOLUME_DOWN As Integer = &H90000
    Private Const WM_APPCOMMAND As Integer = &H319
    <DllImport("user32.dll")> Public Shared Function SendMessageW(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr

    End Function
    Private Sub BTVOLUMEUP_Click(sender As Object, e As EventArgs) Handles BTVOLUMEUP.Click
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_VOLUME_UP))
    End Sub

    Private Sub BTMUTE_Click(sender As Object, e As EventArgs) Handles BTMUTE.Click
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_VOLUME_MUTE))
    End Sub

    Private Sub BTVOLDOWN_Click(sender As Object, e As EventArgs) Handles BTVOLDOWN.Click
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(APPCOMMAND_VOLUME_DOWN))
    End Sub

    Private Sub MyTRVolume_Scroll(sender As Object, e As EventArgs) Handles MyTRVolume.Scroll
        Me.AxWindowsMediaPlayer1.settings.volume = MyTRVolume.Value
    End Sub




    Private Sub TSETPLAY_Tick(sender As Object, e As EventArgs) Handles TSETPLAY.Tick

    End Sub


    Private Sub TFINDSONG_MouseClick(sender As Object, e As MouseEventArgs) Handles TFINDSONG.MouseClick
        Me.TFINDSONG.Text = ""
    End Sub



    Private Sub LISTBOXPLAYLIST_KeyPress(sender As Object, e As KeyPressEventArgs) Handles LISTBOXPLAYLIST.KeyPress
        Try
            If e.KeyChar = Chr(13) Then
                'Play the audio
                AxWindowsMediaPlayer1.URL = CType(Me.LISTBOXPLAYLIST.SelectedItem, Mp3Song).FullName
                'Start timer for progressbar
                TFORPB.Start()
                'Audio Position Index
                AudioPosition()
                If Me.TFINDSONG.Text <> "Search ..." Then
                    TFINDSONG.Text = "Search ..."

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub







    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Form1.Show()

    End Sub







    Private Sub LISTBOXPLAYLIST_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LISTBOXPLAYLIST.SelectedIndexChanged

    End Sub
End Class