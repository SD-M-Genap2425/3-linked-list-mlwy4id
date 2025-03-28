

using System.Text;

namespace LinkedList.Inventori
{
    public class Item
    {
        public string Nama;
        public int Kuantitas;

        public Item(string nama, int kuantitas)
        {
            Nama = nama;
            Kuantitas = kuantitas;
        }
    }

    public class ManajemenInventori
    {
        LinkedList<Item> listItem = new LinkedList<Item>();
        
        public void TambahItem(Item item)
        {
            listItem.AddLast(item);
        }

        public bool HapusItem(string nama)
        {
            LinkedListNode<Item> ptr = listItem.First;
            while(ptr != null)
            {
                if(ptr.Value.Nama == nama)
                {
                    listItem.Remove(ptr);
                    return true;
                }
                ptr = ptr.Next;
            }

            return false;
        }

        public string TampilkanInventori()
        {
            StringBuilder sb = new StringBuilder();
            LinkedListNode<Item> ptr = listItem.First; 

            while (ptr != null)
            {
                sb.Append($"{ptr.Value.Nama}; {ptr.Value.Kuantitas}");
                if (ptr.Next != null) sb.AppendLine();
                ptr = ptr.Next;
            }

            return sb.ToString();
        }
    }
}
