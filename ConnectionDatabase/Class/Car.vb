' Kelas Car yang mewarisi DatabaseEntity, berfungsi untuk mengelola data mobil dalam database
Public Class Car
    Inherits DatabaseEntity ' Mewarisi DatabaseEntity untuk menggunakan fitur koneksi database

    ' Constructor yang memanggil constructor dari DatabaseEntity
    Public Sub New(ByVal connectionString As String)
        MyBase.New(connectionString) ' Menggunakan constructor dari kelas induk untuk menginisialisasi koneksi
    End Sub

    ' Implementasi metode TampilData untuk menampilkan data mobil dalam DataGridView
    Public Overrides Sub TampilData(ByVal dataGridView As DataGridView)
        dataGridView.Rows.Clear() ' Membersihkan semua baris di DataGridView
        Try
            ' Mengambil data dari tabel cars menggunakan query SELECT
            Dim dt As DataTable = db.ExecuteQuery("SELECT * FROM cars")
            For Each row As DataRow In dt.Rows ' Mengiterasi setiap baris data yang diambil
                ' Menambahkan baris baru ke DataGridView dengan data dari database
                dataGridView.Rows.Add(row("id"), row("merk"), row("type"), row("cc"))
            Next
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL: " & ex.Message) ' Menampilkan pesan jika ada error
        End Try
    End Sub
End Class
