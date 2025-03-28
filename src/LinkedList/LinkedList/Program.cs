using System;
using LinkedList.Perpustakaan;
using LinkedList.ManajemenKaryawan;


namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {
        // Soal Perpustakaan
        Buku buku1 = new Buku("The Hobbit", "J.R.R.Tolkien", 1937);
        Buku buku2 = new Buku("1984", "George Orwell", 1949);
        Buku buku3 = new Buku("The Catcher in the Rye", "J.D.Salinger", 1951);

        KoleksiPerpustakaan koleksiPerpustakaan = new KoleksiPerpustakaan();
        koleksiPerpustakaan.TambahBuku(buku1);
        koleksiPerpustakaan.TambahBuku(buku2);
        koleksiPerpustakaan.TambahBuku(buku3);

        koleksiPerpustakaan.CariBuku("hobbit");
        koleksiPerpustakaan.TampilkanKoleksi();

        koleksiPerpustakaan.HapusBuku("1984");
        koleksiPerpustakaan.TampilkanKoleksi();


        // Soal ManajemenKaryawan
        var daftar = new DaftarKaryawan();
        daftar.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
        daftar.TambahKaryawan(new Karyawan("002", "Jane Doe", "HR"));

        string hasil = daftar.TampilkanDaftar();
        Console.WriteLine(hasil);


        // Soal Inventori

    }
}
