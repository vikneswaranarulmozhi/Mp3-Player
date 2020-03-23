Imports System.Data.OleDb
Module sonikoneksi
    Public Function koneksi() As OleDbConnection
        Dim con As OleDbConnection
        con = New OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath.ToString & "\dbplaylist.mdb;")
        Return con
        con = Nothing
    End Function
End Module