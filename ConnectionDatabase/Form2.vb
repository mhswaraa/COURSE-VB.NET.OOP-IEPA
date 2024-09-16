' Kelas Form2 untuk mengelola tampilan dan input data kendaraan dalam form Windows
Public Class Form2
    Private vehicle As Vehicle ' Menyimpan objek Vehicle untuk mengelola data kendaraan

    ' Event handler saat Form2 di-load
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vehicle = New Vehicle("dsn=test_koneksi") ' Membuat objek Vehicle baru dengan DSN yang ditentukan
        vehicle.TampilData(DataGridView1) ' Memanggil metode untuk menampilkan data kendaraan dalam DataGridView
    End Sub

    ' Event handler saat Button1 diklik, untuk memasukkan data baru ke tabel vehicles
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Memeriksa apakah field input diisi dengan benar
        If TextBox2.Text = "" Or TextBox3.Text = "" Or Not IsNumeric(TextBox4.Text) Then
            MsgBox("Silahkan isi semua field dengan benar") ' Menampilkan pesan jika ada input yang salah
        Else
            Try
                ' Membuat query INSERT untuk menambahkan data baru ke tabel vehicles
                Dim InputData As String = "INSERT INTO vehicles (brand, model, year) VALUES('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
                vehicle.ExecuteNonQuery(InputData) ' Menjalankan query INSERT menggunakan metode ExecuteNonQuery
                MsgBox("Input Data Berhasil") ' Menampilkan pesan sukses
                vehicle.TampilData(DataGridView1) ' Memperbarui tampilan data setelah penambahan
            Catch ex As Exception
                MsgBox("Input Data GAGAL: " & ex.Message) ' Menampilkan pesan jika ada error
            End Try
        End If
    End Sub
End Class
