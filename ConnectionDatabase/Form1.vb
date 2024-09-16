' Kelas Form1 untuk mengelola tampilan dan input data mobil dalam form Windows
Public Class Form1
    Private car As Car ' Menyimpan objek Car untuk mengelola data mobil

    ' Event handler saat Form1 di-load
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        car = New Car("dsn=test_koneksi") ' Membuat objek Car baru dengan DSN yang ditentukan
        car.TampilData(DataGridView1) ' Memanggil metode untuk menampilkan data mobil dalam DataGridView
    End Sub

    ' Event handler saat Button1 diklik, untuk memasukkan data baru ke tabel cars
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Memeriksa apakah field input diisi dengan benar
        If TextBox2.Text = "" Or TextBox3.Text = "" Or Not IsNumeric(TextBox4.Text) Then
            MsgBox("Silahkan isi semua field dengan benar") ' Menampilkan pesan jika ada input yang salah
        Else
            Try
                ' Membuat query INSERT untuk menambahkan data baru ke tabel cars
                Dim InputData As String = "INSERT INTO cars (merk, type, cc) VALUES('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
                car.ExecuteNonQuery(InputData) ' Menjalankan query INSERT menggunakan metode ExecuteNonQuery
                MsgBox("Input Data Berhasil") ' Menampilkan pesan sukses
                car.TampilData(DataGridView1) ' Memperbarui tampilan data setelah penambahan
            Catch ex As Exception
                MsgBox("Input Data GAGAL: " & ex.Message) ' Menampilkan pesan jika ada error
            End Try
        End If
    End Sub
End Class
