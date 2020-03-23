Imports System.Data.OleDb
Namespace accessdata
    Public Class koneksidata
        Dim conect As New OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath.ToString & "\dbplaylist.mdb;")
        Public Function open() As OleDbConnection
            conect.Open()
            Return conect
        End Function
        Public Function close() As OleDbConnection
            conect.Close()
            Return conect
        End Function
    End Class
End Namespace