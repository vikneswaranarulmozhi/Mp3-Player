Imports System.IO
Imports System.Data.OleDb
Imports System.Runtime.InteropServices


Public Class Form6
#Region "for-database-connect"
    Dim myconnection As New accessdata.koneksidata
    Dim objconnection As OleDbConnection
    Dim mycmd As New OleDbCommand
    Dim objdataadapter As OleDbDataAdapter
    Dim objdatareader As OleDbDataReader
    Dim objdataset As New DataSet
    Dim objdatatable As New DataTable
#End Region
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim usr As String = TextBox1.Text
        Dim crt As Boolean = False
        mycmd = myconnection.open.CreateCommand
        Try
            mycmd.CommandText = "SELECT * FROM tblUser where user='" + TextBox1.Text + "'"
            objdatareader = mycmd.ExecuteReader
            If objdatareader.Read Then
                Me.Hide()
                Form4.Show()
            End If
        Catch ex As Exception

        End Try


    End Sub
End Class