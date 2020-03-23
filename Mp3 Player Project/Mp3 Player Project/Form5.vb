Imports System.IO
Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Public Class Form5
#Region "for-database-connect"
    Dim myconnection As New accessdata.koneksidata
    Dim objconnection As OleDbConnection
    Dim mycmd As New OleDbCommand
    Dim objdataadapter As OleDbDataAdapter
    Dim objdatareader As OleDbDataReader
    Dim objdataset As New DataSet
    Dim objdatatable As New DataTable
#End Region
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If TextBox2.Text = TextBox3.Text Then

            Dim user, pass As String
            user = TextBox1.Text
            pass = TextBox2.Text

            Using sql As New OleDb.OleDbCommand("Insert into tblUser ([user],[pass]) values('" & user & "','" & pass & "')", myconnection.open)
                sql.Parameters.Add(New OleDb.OleDbParameter("'" & user & "'", OleDbType.LongVarChar)).Value = user
                sql.Parameters.Add(New OleDb.OleDbParameter("'" & pass & "'", OleDbType.LongVarChar)).Value = pass
                Try
                    sql.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                myconnection.close()
            End Using
            myconnection.close()
            Me.Hide()
            Dim Form1 = New Form1()
            Form1.Show()
        Else
            TextBox2.Clear()
            TextBox3.Clear()
            MessageBox.Show("Password Does not Match Confirm Password")
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Dim Form1 = New Form1()
        Form1.Show()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.PasswordChar = "*"
        TextBox3.PasswordChar = "*"
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
    End Sub
End Class