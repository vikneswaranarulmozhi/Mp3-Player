
Imports System.IO
Imports System.Data.OleDb
Imports System.Runtime.InteropServices


Public Class Form4
#Region "mp3-declare"
    Public Class Mp3Song
        Private _artist As String
        Private _songName As String
        Private _path As String
        Private _panjang As String
        Private _Genre As String

        Public Property Genre() As String
            Get
                Return _Genre
            End Get
            Set(ByVal value As String)
                Me._Genre = value
            End Set
        End Property
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
                Me._songName = Me._Genre.Trim(ch)
                Return _artist & " >> " & _songName & Panjang & _Genre
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
    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub





    Private Sub LISTFINDSONG_DoubleClick(sender As Object, e As EventArgs) Handles LISTFINDSONG.DoubleClick





        'Start timer for progressbar
        TFORPB.Start()
        'Audio Position Index
        AudioPosition()
    End Sub
    Dim AudPos As String
    Sub AudioPosition()
        AudPos = Me.LISTFINDSONG.SelectedIndex
    End Sub
    Private Sub TFORPB_Tick(sender As Object, e As EventArgs) Handles TFORPB.Tick

    End Sub

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BTSTOP_Click(sender As Object, e As EventArgs)

    End Sub







    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click


        Me.Hide()
        Form2.Show()
    End Sub



    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Hide()
        Dim Form1 = New Form1()
        Form1.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            myconnection.close()
            sonikoneksi.koneksi.Close()
            Dim DA As OleDb.OleDbDataAdapter

            DA = New OleDb.OleDbDataAdapter("select * from playlist ", sonikoneksi.koneksi)
            Dim DT1 As New DataTable
            DT1.Clear()
            DA.Fill(DT1)
            If DT1.Rows.Count = Nothing Then
            Else

                mycmd = myconnection.open.CreateCommand
                mycmd.CommandText = "Select * from playlist"
                objdatareader = mycmd.ExecuteReader
                Dim cnt As Integer = objdatareader.FieldCount
                While objdatareader.Read

                    Dim Art As String
                    Dim Tit As String
                    Dim alm As String
                    Dim gen As String
                    Dim lyc As String


                    Art = (objdatareader.Item("Artist").ToString)
                    lyc = (objdatareader.Item("lyrics").ToString)
                    Tit = (objdatareader.Item("Title").ToString)
                    alm = (objdatareader.Item("Album").ToString)
                    gen = (objdatareader.Item("Genre").ToString)

                    If File.Exists(lyc) Then
                        Try
                            Using tr As TextReader = New StreamReader(lyc)
                                Dim CurrentLine As String
                                Dim foundText As Boolean = False
                                Dim searchString As String = TextBox1.Text

                                'Do


                                CurrentLine = tr.ReadToEnd

                                If CurrentLine IsNot Nothing Then
                                    foundText = CurrentLine.Contains(searchString)

                                End If
                                If foundText = True Then

                                    ComboBox1.Items.Add(objdatareader.Item("Artist").ToString)
                                    ComboBox2.Items.Add(objdatareader.Item("Title").ToString)
                                    ComboBox3.Items.Add(objdatareader.Item("Album").ToString)
                                    ComboBox4.Items.Add(objdatareader.Item("Genre").ToString)
                                End If

                                'While CurrentLine IsNot Nothing And Not foundText

                                'End While
                                'Loop


                            End Using

                        Catch ex As Exception
                            MessageBox.Show("The process failed: {0}", ex.ToString())

                        End Try
                    End If


                End While
            End If

        Catch ex As Exception
            MessageBox.Show("The process failed: {0}", ex.ToString())
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.Text = " "
        ComboBox3.Text = " "
        ComboBox4.Text = " "
        LISTFINDSONG.Items.Clear()
        If ComboBox1.SelectedIndex >= 0 Then
            Dim text As String = ComboBox1.SelectedItem.ToString()

            myconnection.close()
            sonikoneksi.koneksi.Close()
            Dim DA As OleDb.OleDbDataAdapter
            DA = New OleDb.OleDbDataAdapter("select * from playlist where Artist = '" & text & "'", sonikoneksi.koneksi)
            Dim DT1 As New DataTable
            DT1.Clear()
            DA.Fill(DT1)
            If DT1.Rows.Count = Nothing Then
            Else
                Me.LISTFINDSONG.Items.Clear()
                mycmd = myconnection.open.CreateCommand
                mycmd.CommandText = "select * from playlist where Artist = '" & text & "'"
                objdatareader = mycmd.ExecuteReader
                While objdatareader.Read
                    Dim kamuku As String
                    Dim Art As String

                    kamuku = (objdatareader.Item("path").ToString)
                    Art = (objdatareader.Item("Artist").ToString)

                    Dim f = New FileInfo(kamuku)
                    Dim song As Mp3Song = New Mp3Song
                    With song

                        .FullName = kamuku
                        .SongName = System.IO.Path.GetFileNameWithoutExtension(f.FullName)
                        .Artist = Art

                    End With
                    Me.LISTFINDSONG.Items.Add(song)
                    Me.LISTFINDSONG.ValueMember = "FullName"
                    Me.LISTFINDSONG.DisplayMember = "SongName"
                    Me.LISTFINDSONG.ValueMember = "Artist"

                End While
                myconnection.close()
                sonikoneksi.koneksi.Close()
            End If


        End If
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox1.Text = " "
        ComboBox3.Text = " "
        ComboBox4.Text = " "
        LISTFINDSONG.Items.Clear()

        If ComboBox2.SelectedIndex >= 0 Then
            Dim text As String = ComboBox2.SelectedItem.ToString()

            myconnection.close()
            sonikoneksi.koneksi.Close()
            Dim DA As OleDb.OleDbDataAdapter
            DA = New OleDb.OleDbDataAdapter("select * from playlist where Title = '" & text & "'", sonikoneksi.koneksi)
            Dim DT1 As New DataTable
            DT1.Clear()
            DA.Fill(DT1)
            If DT1.Rows.Count = Nothing Then
            Else
                Me.LISTFINDSONG.Items.Clear()
                mycmd = myconnection.open.CreateCommand
                mycmd.CommandText = "select * from playlist where Title = '" & text & "'"
                objdatareader = mycmd.ExecuteReader
                While objdatareader.Read
                    Dim kamuku As String
                    Dim Art As String

                    kamuku = (objdatareader.Item("path").ToString)
                    Art = (objdatareader.Item("Title").ToString)

                    Dim f = New FileInfo(kamuku)
                    Dim song As Mp3Song = New Mp3Song
                    With song

                        .FullName = kamuku
                        .SongName = System.IO.Path.GetFileNameWithoutExtension(f.FullName)
                        .Artist = Art

                    End With
                    Me.LISTFINDSONG.Items.Add(song)
                    Me.LISTFINDSONG.ValueMember = "FullName"
                    Me.LISTFINDSONG.DisplayMember = "SongName"
                    Me.LISTFINDSONG.ValueMember = "Title"

                End While
                myconnection.close()
                sonikoneksi.koneksi.Close()
            End If


        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        ComboBox1.Text = " "
        ComboBox2.Text = " "
        ComboBox4.Text = " "
        LISTFINDSONG.Items.Clear()
        If ComboBox3.SelectedIndex >= 0 Then
            Dim text As String = ComboBox3.SelectedItem.ToString()

            myconnection.close()
            sonikoneksi.koneksi.Close()
            Dim DA As OleDb.OleDbDataAdapter
            DA = New OleDb.OleDbDataAdapter("select * from playlist where Album = '" & text & "'", sonikoneksi.koneksi)
            Dim DT1 As New DataTable
            DT1.Clear()
            DA.Fill(DT1)
            If DT1.Rows.Count = Nothing Then
            Else
                Me.LISTFINDSONG.Items.Clear()
                mycmd = myconnection.open.CreateCommand
                mycmd.CommandText = "select * from playlist where Album = '" & text & "'"
                objdatareader = mycmd.ExecuteReader
                While objdatareader.Read
                    Dim kamuku As String
                    Dim Art As String

                    kamuku = (objdatareader.Item("path").ToString)
                    Art = (objdatareader.Item("Album").ToString)

                    Dim f = New FileInfo(kamuku)
                    Dim song As Mp3Song = New Mp3Song
                    With song

                        .FullName = kamuku
                        .SongName = System.IO.Path.GetFileNameWithoutExtension(f.FullName)
                        .Artist = Art

                    End With
                    Me.LISTFINDSONG.Items.Add(song)
                    Me.LISTFINDSONG.ValueMember = "FullName"
                    Me.LISTFINDSONG.DisplayMember = "SongName"
                    Me.LISTFINDSONG.ValueMember = "Album"

                End While
                myconnection.close()
                sonikoneksi.koneksi.Close()
            End If


        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        ComboBox1.Text = " "
        ComboBox3.Text = " "
        ComboBox2.Text = " "
        LISTFINDSONG.Items.Clear()
        If ComboBox4.SelectedIndex >= 0 Then
            Dim text As String = ComboBox4.SelectedItem.ToString()

            myconnection.close()
            sonikoneksi.koneksi.Close()
            Dim DA As OleDb.OleDbDataAdapter
            DA = New OleDb.OleDbDataAdapter("select * from playlist where Genre = '" & text & "'", sonikoneksi.koneksi)
            Dim DT1 As New DataTable
            DT1.Clear()
            DA.Fill(DT1)
            If DT1.Rows.Count = Nothing Then
            Else
                Me.LISTFINDSONG.Items.Clear()
                mycmd = myconnection.open.CreateCommand
                mycmd.CommandText = "select * from playlist where Genre = '" & text & "'"
                objdatareader = mycmd.ExecuteReader
                While objdatareader.Read
                    Dim kamuku As String
                    Dim Art As String

                    kamuku = (objdatareader.Item("path").ToString)
                    Art = (objdatareader.Item("Genre").ToString)

                    Dim f = New FileInfo(kamuku)
                    Dim song As Mp3Song = New Mp3Song
                    With song

                        .FullName = kamuku
                        .SongName = System.IO.Path.GetFileNameWithoutExtension(f.FullName)
                        .Artist = Art

                    End With
                    Me.LISTFINDSONG.Items.Add(song)
                    Me.LISTFINDSONG.ValueMember = "Genre"
                    Me.LISTFINDSONG.DisplayMember = "SongName"
                    Me.LISTFINDSONG.ValueMember = "Genre"

                End While
                myconnection.close()
                sonikoneksi.koneksi.Close()
            End If


        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Hide()
        Form2.Show()
    End Sub
End Class