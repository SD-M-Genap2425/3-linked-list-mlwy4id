
using System.Text;

namespace LinkedList.ManajemenKaryawan
{
    public class Karyawan
    {
        public string NomorKaryawan;
        public string Nama;
        public string Posisi;

        public Karyawan(string nomorKaryawan, string nama, string posisi)
        {
            NomorKaryawan = nomorKaryawan;
            Nama = nama;
            Posisi = posisi;
        }
    }

    public class KaryawanNode
    {
        public Karyawan Karyawan;
        public KaryawanNode Next;
        public KaryawanNode Prev;

        public KaryawanNode(Karyawan _karyawan)
        {
            this.Karyawan = _karyawan;
            Next = null;
            Prev = null;
        }
    }

    public class DaftarKaryawan
    {
        public KaryawanNode Head;
        public KaryawanNode Tail;

        public DaftarKaryawan()
        {
            Head = null;
            Tail = null;
        }

        public void TambahKaryawan(Karyawan karyawan)
        {
            KaryawanNode newKaryawan = new KaryawanNode(karyawan);
            if(Head == null && Tail == null)
            {
                Head = newKaryawan;
                Tail = newKaryawan;
            }
            else
            {
                KaryawanNode ptr = Head;

                if(String.Compare(newKaryawan.Karyawan.NomorKaryawan, Head.Karyawan.NomorKaryawan) < 0)
                {
                    newKaryawan.Next = Head;
                    Head.Prev = newKaryawan;
                    Head = Head.Prev;
                } else if(String.Compare(newKaryawan.Karyawan.NomorKaryawan, Tail.Karyawan.NomorKaryawan) > 0)
                {
                    Tail.Next = newKaryawan;
                    newKaryawan.Prev = Tail;
                    Tail = Tail.Next;
                } else
                {
                    while(ptr != null)
                    {
                        if(String.Compare(ptr.Karyawan.NomorKaryawan, newKaryawan.Karyawan.NomorKaryawan) > 0)
                        {
                            ptr.Prev.Next = newKaryawan;
                            newKaryawan.Prev = ptr.Prev;
                            newKaryawan.Next = ptr;
                            ptr.Prev = newKaryawan;
                            return;
                        }
                        ptr = ptr.Next;
                    }
                }
            }
        }

        public bool HapusKaryawan(string nomorKaryawan)
        {
            if(Head.Karyawan.NomorKaryawan == nomorKaryawan)
            {
                Head = Head.Next;
                if (Head != null) Head.Prev = null;
                else Tail = null;
                    return true;
            }

            if(Tail.Karyawan.NomorKaryawan == nomorKaryawan)
            {
                Tail = Tail.Prev;
                if (Tail != null) Tail.Next = null;
                else Head = null;
                    return true;
            }

            KaryawanNode ptr = Head;

            while(ptr != null)
            {
                if(ptr.Karyawan.NomorKaryawan == nomorKaryawan)
                {
                    ptr.Prev.Next = ptr.Next;
                    ptr.Next.Prev = ptr.Prev;
                    return true;
                }
                ptr = ptr.Next;
            }

            return false;
        }

        public Karyawan[] CariKaryawan(string kataKunci)
        {
            List<Karyawan> searchKaryawan = new List<Karyawan>();
            KaryawanNode ptr = Head;

            while(ptr != null)
            {
                if(ptr.Karyawan.Nama.Contains(kataKunci) || ptr.Karyawan.Posisi.Contains(kataKunci)) 
                {
                    searchKaryawan.Add(ptr.Karyawan);
                }
                ptr = ptr.Next;
            }

            return searchKaryawan.ToArray();
        }

        public string TampilkanDaftar()
        {
            StringBuilder sb = new StringBuilder();
            KaryawanNode ptr = Tail;

            while(ptr != null)
            {
                sb.Append($"{ptr.Karyawan.NomorKaryawan}; {ptr.Karyawan.Nama}; {ptr.Karyawan.Posisi}");
                if (ptr.Prev != null) sb.AppendLine();
                ptr = ptr.Prev;
            }

            return sb.ToString();
        }
    }
}
