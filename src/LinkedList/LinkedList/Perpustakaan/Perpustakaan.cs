

using System.Text;

namespace LinkedList.Perpustakaan
{
    public class Buku
    {
        public string Judul;
        public string Penulis;
        public int Tahun;

        public Buku(string judul, string penulis, int tahun)
        {
            Judul = judul;
            Penulis = penulis;
            Tahun = tahun;
        }
    }

    public class BukuNode
    {
        public Buku Data;
        public BukuNode Next;

        public BukuNode(Buku _buku)
        {
            Data = _buku;
            Next = null;
        }
    }

    public class KoleksiPerpustakaan
    {
        public BukuNode Head;
        public BukuNode Tail;

        public KoleksiPerpustakaan()
        {
            Head = null;
            Tail = null;
        }

        public void TambahBuku(Buku buku)
        {
            BukuNode newBuku = new BukuNode(buku);
            if(Head == null && Tail == null)
            {
                Head = newBuku;
                Tail = newBuku;
            } else
            {
                Tail.Next = newBuku;
                Tail = Tail.Next;
            }
        }

        public bool HapusBuku(string judul)
        {
            if (Head == null) return false;

            if(Head.Data.Judul == judul)
            {
                Head = Head.Next;
                return true;
            }

            BukuNode ptr = Head;

            while(ptr.Next != null)
            {

                if(ptr.Next.Data.Judul == judul)
                {
                    ptr.Next = ptr.Next.Next;
                    return true;
                }
                ptr = ptr.Next;
            }

            return false;
        }

        public Buku[] CariBuku(string kataKunci)
        {
            List<Buku> searchResult = new List<Buku>();
            BukuNode ptr = Head;

            while(ptr != null)
            {
                if (ptr.Data.Judul.Contains(kataKunci))
                {
                    searchResult.Add(ptr.Data);
                }
                ptr = ptr.Next;
            }

            return searchResult.ToArray();
        }

        public string TampilkanKoleksi()
        {
            StringBuilder sb = new StringBuilder();
            BukuNode ptr = Head;

            while(ptr != null)
            {
                sb.AppendLine($"\"{ptr.Data.Judul}\"; {ptr.Data.Penulis}; {ptr.Data.Tahun}");
                ptr = ptr.Next;
            }

            return sb.ToString();
        }
    }
}
