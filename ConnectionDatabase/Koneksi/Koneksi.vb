Imports System.Data.Odbc ' Mengimpor namespace Odbc untuk menggunakan ODBC driver dan komponen terkait

' Kelas Koneksi untuk mengelola koneksi database ODBC
Public Class Koneksi
    Private con As OdbcConnection ' Menyimpan objek koneksi ODBC
    Private da As OdbcDataAdapter ' Menyimpan objek adapter untuk mengambil data dari database
    Private dt As DataTable ' Menyimpan objek DataTable untuk menyimpan hasil query
    Private cmd As OdbcCommand ' Menyimpan objek command untuk mengeksekusi perintah SQL

    ' Constructor yang menerima connectionString untuk menginisialisasi koneksi
    Public Sub New(ByVal connectionString As String)
        con = New OdbcConnection(connectionString) ' Membuat koneksi baru dengan connection string yang diberikan
    End Sub

    ' Metode untuk membuka koneksi jika belum terbuka
    Public Sub OpenConnection()
        If con.State = ConnectionState.Closed Then ' Memeriksa apakah koneksi sedang ditutup
            con.Open() ' Membuka koneksi jika ditutup
        End If
    End Sub

    ' Metode untuk menutup koneksi jika terbuka
    Public Sub CloseConnection()
        If con.State = ConnectionState.Open Then ' Memeriksa apakah koneksi sedang terbuka
            con.Close() ' Menutup koneksi jika terbuka
        End If
    End Sub

    ' Metode untuk mengeksekusi query SELECT dan mengembalikan hasilnya dalam bentuk DataTable
    Public Function ExecuteQuery(ByVal query As String) As DataTable
        da = New OdbcDataAdapter(query, con) ' Menginisialisasi adapter dengan query dan koneksi
        dt = New DataTable() ' Membuat DataTable baru untuk menyimpan hasil query
        da.Fill(dt) ' Mengisi DataTable dengan hasil query
        Return dt ' Mengembalikan DataTable yang berisi hasil query
    End Function

    ' Metode untuk mengeksekusi query INSERT, UPDATE, DELETE tanpa mengembalikan hasil
    Public Sub ExecuteNonQuery(ByVal query As String)
        cmd = New OdbcCommand(query, con) ' Menginisialisasi command dengan query dan koneksi
        cmd.ExecuteNonQuery() ' Menjalankan query tanpa mengembalikan hasil
    End Sub
End Class
