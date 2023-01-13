using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_060
{
    class Node
    {
        public int IdBarang;
        public string NamaBarang;
        public string JenisBarang;
        public int HargaBarang;
        public Node next;
    }
    class List
    {
        Node START;

        public List()
        {
            START = null;
        }

        public void addNote()
        {
            int ib;
            string jb;
            Console.WriteLine("\nMasukkan id barang : ");
            ib = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukkan jenis barang : ");
            jb = Console.ReadLine();
            Node newnode = new Node();
            newnode.JenisBarang = jb;

            if (START == null || ib <= START.IdBarang)
            {
                if ((START != null) && (ib == START.IdBarang))
                {
                    Console.WriteLine("\nDuplikat id barang tidak diterima\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (ib >= current.IdBarang))
            {
                if (ib == current.IdBarang)
                {
                    Console.WriteLine("\nDuplikat id barang tidak diterima\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nlist is empt.\n");
            else
            {
                Console.WriteLine("\nThe records in the list are : ");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)

                    Console.Write(currentNode.IdBarang + " " + currentNode.HargaBarang + "\n");

                Console.WriteLine();
            }
        }
        public bool delNode(int ib)
        {
            Node previous, current;
            previous = current = null;
            if (Search(ib, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        public bool Search(int ib, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (ib >= current.IdBarang))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Add a record to the list ");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all the records in the list");
                    Console.WriteLine("4. Search for a record in the list");
                    Console.WriteLine("5. EXIT");
                    Console.Write("\nEnter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList empty");
                                    break;
                                }
                                Console.Write("\nEnter the Id Barang of" +
                                     " the Id Barang whose record is to be delated :");
                                int ib = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(ib) == false)
                                    Console.WriteLine("\n Record not found.");
                                else
                                    Console.WriteLine("Record with Id Barang " + ib + " Deleted");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nEnter Id Barang of the " +
                                    " whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord not found.");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nId Barang: " + current.IdBarang);
                                    Console.WriteLine("\nJenis Barang " + current.JenisBarang);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for the value enterd ");
                }
            }
        }
    }
}

/*  2. linked list
    karena algoritma ini dapat mencari data,mengumpulkan data,
    menampilkan data, bahkan dapat menghapus data yang kita inginkan.

    3. perbedaan utama antara array dan linked list adalah cara data disimpan dan diakses. 
    Array menyimpan data dalam blok memori yang terkait secara bersamaan, sedangkan linked list 
    menyimpan data dalam blok memori yang terpisah dan dihubungkan melalui pointer.
    Array memiliki akses yang lebih cepat ke elemen tertentu, namun memerlukan lebih banyak ruang
    untuk menyimpan pointer pada setiap elemen. Sedangkan linked list memerlukan lebih sedikit ruang, 
    namun memiliki akses yang lebih lambat ke elemen tertentu.

    kapan harus menggunakan tipe data array atau linked list tergantung pada kebutuhan aplikasi.
    Jika aplikasi memerlukan akses yang cepat ke elemen tertentu dan ruang memori tidak terbatas, 
    maka array akan lebih baik digunakan. Namun jika aplikasi memerlukan manipulasi data yang sering seperti
    penambahan atau penghapusan elemen dan ruang memori terbatas, maka linked list akan lebih baik digunakan.
    
    4. algoritma dimana satu data dapat ditambahkan di akhir disebut "enqueue" 
    dan data dihapus dari yang paling terakhir disebut "dequeue"

    5. a. 41,74
          16,53
          46,55
          63,70
          62,64
       b. cara bacanya adalah traversal yaitu kiri root traverse kekanan
          16 25 40 55 30
*/      
