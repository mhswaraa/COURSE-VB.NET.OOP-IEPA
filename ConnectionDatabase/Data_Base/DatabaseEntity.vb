' Kelas abstrak untuk entitas database
Public MustInherit Class DatabaseEntity
    Protected db As Koneksi ' Menyimpan objek Koneksi untuk digunakan oleh kelas turunan

    ' Constructor yang menerima connectionString untuk menginisialisasi koneksi
    Public Sub New(ByVal connectionString As String)
        db = New Koneksi(connectionString) ' Membuat objek Koneksi baru dengan connection string yang diberikan
        db.OpenConnection() ' Membuka koneksi saat objek ini dibuat
    End Sub

    ' Metode abstrak yang harus diimplementasikan oleh kelas turunan
    Public MustOverride Sub TampilData(ByVal dataGridView As DataGridView)

    ' Metode untuk mengeksekusi query INSERT, UPDATE, DELETE tanpa mengembalikan hasil
    Public Sub ExecuteNonQuery(ByVal query As String)
        db.ExecuteNonQuery(query) ' Menjalankan query menggunakan objek Koneksi
    End Sub
End Class
