Imports System.Environment
Imports System.Data.SqlClient


Module MacolaStartup

    Friend cn As SqlConnection
    Public DefaultServer As String = My.Settings.DefaultSERVER
    Public DefaultDB As String = My.Settings.DefaultDB

    Public Sub MacStartup(db)

        Try

            Dim ConnStr As String = "Data Source=" & DefaultServer & ";Initial Catalog=" & db & ";Persist Security Info=True;User ID=sa;Password=STMARTIN"

            cn = New SqlConnection
            cn.ConnectionString = ConnStr
            cn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim st As Integer = cn.State

    End Sub
    'Public Sub MacStartup(db As String)
    '    'db = "DATA"
    '    'Dim ConnStr As String = "Data Source=TIM-OPTIPLEX\SQL2008R2;Initial Catalog=" & db & ";User ID=sa;Password=230South5th"

    '    'Dim ConnStr As String = "Data Source=TCHPSERVER\SQL2008R2;Initial Catalog=" & db & ";User ID=sa;Password=230South5th"
    '    Dim ConnStr As String = "Data Source=MASS_SQL2;Initial Catalog=" & db & ";Persist Security Info=True;User ID=sa;Password=STMARTIN"
    '    cn = New SqlConnection
    '    cn.ConnectionString = ConnStr
    '    cn.Open()

    'End Sub

End Module
