using System;

namespace UAS_3
{
    class Node
    {
        public int noBuku;
        public string Judul, NamaP, TahunTerbit;
        public Node next;
    }

    class list
    {
        Node START;
        public list()
        {
            START = null;
        }
        public void addNode()
        {
            int nomor;
            string jdbuku, nmpe, thntrbt;
            Console.Write("\nMasukkan Nomor Buku: ");
            nomor = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Judul buku: ");
            jdbuku = Console.ReadLine();
            nmpe = Console.ReadLine();
            thntrbt = Console.ReadLine();
            Node nodeBaru = new Node();
            nodeBaru.noBuku = nomor;
            nodeBaru.Judul = jdbuku;

            if (START == null || nomor <= START.noBuku)
            {
                if ((START != null) && (nomor == START.noBuku))
                {
                    Console.WriteLine("\nNomor buku sama tidak diizinkan\n");
                    return;
                }
                nodeBaru.next = START;
                START = nodeBaru;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (nomor >= current.noBuku))
            {
                if (nomor == current.noBuku)
                {
                    Console.WriteLine("\nNomor Buku sama tidak diizinkan\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            nodeBaru.next = current;
            previous.next = nodeBaru;

        }
        public bool delNode(int nomor)
        {
            Node previous, current;
            previous = current = null;
            if (Search(nomor, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        public bool Search(int nomor, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (nomor != current.noBuku))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList Kosong. \n");
            else
            {
                Console.WriteLine("\nData didalam list adalah : \n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.noBuku + " " + currentNode.Judul + "\n");
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        class program
        {
            static void Main(string[] args)
            {
                list obj = new list();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMenu");
                        Console.WriteLine("1. Menambah data kedalam list");
                        Console.WriteLine("2. Menghapus daa dari dalam list");
                        Console.WriteLine("3. Melihat semua data didalam list");
                        Console.WriteLine("4. Mencari sebuah data didalam list");
                        Console.WriteLine("5. Keluar");
                        Console.Write("\nMasukkan pilihan anda (1 - 5): ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.addNode();
                                }
                                break;
                            case '2':
                                {
                                    if (obj.listEmpty())
                                    {
                                        Console.WriteLine("\nList Kosong");
                                        break;
                                    }
                                    Console.Write("\nMasukkan Nomor Buku yang akan dihapus : ");
                                    int nomor = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (obj.delNode(nomor) == false)
                                        Console.WriteLine("\nData tidak ditemukan ");
                                    else
                                        Console.WriteLine("Data dengan nomor Buku " + nomor + "dihapus ");
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
                                        Console.WriteLine("List kosong !");
                                        break;
                                    }
                                    Node previous, current;
                                    previous = current = null;
                                    
                                    Console.Write("\nMasukkan Nomor Buku yang akan dicari: ");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref previous, ref current) == false)
                                        Console.WriteLine("\nData tidak ditemukan,");
                                    else
                                    {
                                        Console.WriteLine("\nData Ditemukan");
                                        Console.WriteLine("\nNomor Buku: " + current.noBuku);
                                        Console.WriteLine("\nNama: " + current.Judul);
                                    }

                                }
                                break;
                            case '5':
                                return;
                            default:
                                {
                                    Console.WriteLine("\npilihan tidak valid ");
                                    break;
                                }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nCheck nomor  yang anda masukkan");
                    }
                }
            }
        }



    }
}
// 2. Untuk Diatas saya menggunakan algoritma Node saya memilih menggunakan Algoritma node karena menurut saya sangat sesuai dengan yang dibutuhkan sepertoi memasukkan data 
//    mencari data dan menghapus dat maka dari itu saya menggunakan algoritma Node
// 3.Algoritma stack menggunakan 3 operation yaitu push dan display
// 4. insert dan yang kedua disebut delete
// 5. a - 5 kedalaman 
//    b inorder, inorder adalah dimana data masuk melalui kiri terlebih dahulu setalh dari kiri maka akan berpindah tempat kembali menjadin kekanan  dan jika sudah selesai antara kanan dan kiri maka
//      maka data tersebut akan dipindahkan keatas atau ketengah.
    


