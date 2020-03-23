Imports System.IO
Imports System.Data.OleDb
Imports System.Runtime.InteropServices

Public Class Form3
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


                        Else
                            Dim f = New IO.FileInfo(kamuku)
                            Dim song As Mp3Song = New Mp3Song
                            Dim media As WMPLib.IWMPMedia = Me.AxWindowsMediaPlayer1.newMedia(kamuku)
                            Dim lenghtsoni As String = media.durationString

                        End If
                        fs.Close()
                    Else
                        Dim f = New IO.FileInfo(kamuku)
                        Dim song As Mp3Song = New Mp3Song
                        Dim media As WMPLib.IWMPMedia = Me.AxWindowsMediaPlayer1.newMedia(kamuku)
                        Dim lenghtsoni As String = media.durationString

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

    End Sub
#End Region


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim it As String = CType(Form4.LISTFINDSONG.SelectedItem, Form4.Mp3Song).SongName
        Dim ar As String = CType(Form4.LISTFINDSONG.SelectedItem, Form4.Mp3Song).Artist
        Label4.Text = it
        Label5.Text = ar
        mycmd = myconnection.open.CreateCommand
        If Form4.ComboBox4.SelectedIndex >= 0 Then

            Dim Gen As String = Form4.ComboBox4.SelectedItem.ToString()
            mycmd.CommandText = "Select * from playlist where Genre='" & Gen & "'"
        End If
        If Form4.ComboBox2.SelectedIndex >= 0 Then
            Dim Tit As String = Form4.ComboBox2.SelectedItem.ToString()
            mycmd.CommandText = "Select * from playlist where Title='" & Tit & "'"
        End If
        If Form4.ComboBox3.SelectedIndex >= 0 Then
            Dim Alb As String = Form4.ComboBox3.SelectedItem.ToString()
            mycmd.CommandText = "Select * from playlist where Album ='" & Alb & "'"
        End If
        If Form4.ComboBox1.SelectedIndex >= 0 Then
            Dim Arti As String = Form4.ComboBox1.SelectedItem.ToString()
            mycmd.CommandText = "Select * from playlist where Artist ='" & Arti & "'"
        End If
        If Form2.LISTBOXPLAYLIST.SelectedIndex >= 0 Then
            Dim Arti As String = Form2.LISTBOXPLAYLIST.SelectedItem.ToString()
            mycmd.CommandText = "Select * from playlist where Artist ='" & Arti & "'"
        End If
        objdatareader = mycmd.ExecuteReader
        Dim cnt As Integer = objdatareader.FieldCount
        While objdatareader.Read

            Dim lyc As String
            Dim pic As String
            lyc = (objdatareader.Item("lyrics").ToString)
            pic = (objdatareader.Item("picture").ToString)
            Dim img As String = pic
            PictureBox1.Image = New Bitmap(img)
            PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
            If File.Exists(lyc) Then
                Try
                    Using tr As TextReader = New StreamReader(lyc)
                        Dim CurrentLine As String
                        CurrentLine = tr.ReadToEnd
                        RichTextBox1.Text = CurrentLine
                    End Using
                Catch ex As Exception
                    MessageBox.Show("The process failed: {0}", ex.ToString())

                End Try
            End If

        End While










        AxWindowsMediaPlayer1.URL = CType(Form4.LISTFINDSONG.SelectedItem, Form4.Mp3Song).FullName
        tambahdaridb()



    End Sub

    Private Sub BTPLAY_Click(sender As Object, e As EventArgs) Handles BTPLAY.Click
        'Play the audio
        AxWindowsMediaPlayer1.URL = CType(Form4.LISTFINDSONG.SelectedItem, Form4.Mp3Song).FullName
        'Start timer for progressbar
        TFORPB.Start()
        'Audio Position Index

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

    Private Sub BTFORWARD_Click(sender As Object, e As EventArgs)
        LBLFORREPEAT.Text = "F"
    End Sub

    Private Sub BTREPEAT_Click(sender As Object, e As EventArgs)
        LBLFORREPEAT.Text = "R"
    End Sub
    Private Sub TSETPLAY_Tick(sender As Object, e As EventArgs) Handles TSETPLAY.Tick

    End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs)
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Form1.Show()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Me.Hide()
        Dim Form4 = New Form4()
        Form4.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Me.Hide()
        Dim Form3 = New Form2()
        Form3.Show()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub LISTBOXPLAYLIST_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub PDURATION_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Me.Hide()
        addfav()
        Form2.Show()

    End Sub
    Sub addfav()
        Try
            myconnection.close()


            Dim arrayname As String = AxWindowsMediaPlayer1.URL
            Dim logid = Form1.TextBox1.Text

            Using sql As New OleDb.OleDbCommand("insert into path ([path],[logid]) values('" & Replace(arrayname, "'", "''") & "','" & Replace(logid, "'", "''") & "')", myconnection.open)
                If import.FileName = Nothing Then
                Else
                    For Each track As String In import.FileNames
                        sql.Parameters.Add(New OleDb.OleDbParameter("'" & Replace(arrayname, "'", "''") & "'", OleDbType.LongVarChar)).Value = (Replace(track, "'", "''"))
                        sql.Parameters.Add(New OleDb.OleDbParameter("'" & Replace(logid, "'", "''") & "'", OleDbType.LongVarChar)).Value = logid
                    Next
                End If
                sql.ExecuteNonQuery()
                myconnection.close()
            End Using
            myconnection.close()

        Catch ex As Exception
            MsgBox(ex.Message)
            myconnection.close()
            Exit Sub
        End Try
        myconnection.close()

    End Sub
End Class
