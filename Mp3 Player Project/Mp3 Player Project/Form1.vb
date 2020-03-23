Imports System.IO
Imports System.Data.OleDb
Imports System.Runtime.InteropServices


Public Class Form1
#Region "for-database-connect"
    Dim myconnection As New accessdata.koneksidata
    Dim objconnection As OleDbConnection
    Dim mycmd As New OleDbCommand
    Dim objdataadapter As OleDbDataAdapter
    Dim objdatareader As OleDbDataReader
    Dim objdataset As New DataSet
    Dim objdatatable As New DataTable
#End Region
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Form5.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim usr As String = TextBox1.Text
        Dim psw As String = TextBox2.Text
        If TextBox1.Text IsNot String.Empty Then
            mycmd = myconnection.open.CreateCommand
            mycmd.CommandText = "SELECT * FROM tblUser where user='" + TextBox1.Text + "' AND pass='" + TextBox2.Text + "'"
            objdatareader = mycmd.ExecuteReader

            If objdatareader.Read Then
                Me.Hide()
                Form4.Show()


            Else

                MessageBox.Show("Username or password is incorrect")
            End If
        Else
            TextBox1.Clear()
            TextBox2.Clear()
            MessageBox.Show("enter the user name")
            Me.Hide()
            Me.Show()
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        End

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        Me.Show()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form5.Show()


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.PasswordChar = "*"
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        Form6.Show()
    End Sub
End Class