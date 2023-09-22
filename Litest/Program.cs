using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;

namespace Litest
{
    class program
    {
        static void Main(string[] args)
        {
            List<Invoice> invoices = new List<Invoice>()
            {
                new Invoice(1, "Tagihan#1", new DateTime(2023, 1, 10),165000),
                new Invoice(2, "Tagihan#2", new DateTime(2023, 2, 15),80000),
                new Invoice(3, "Tagihan#3", new DateTime(2023, 1, 20),130000),
                new Invoice(4, "Tagihan#4", new DateTime(2023, 3, 25),416000),
                new Invoice(5, "Tagihan#5", new DateTime(2023, 2, 10),95500),
                new Invoice(6, "Tagihan#6", new DateTime(2023, 8, 17),523000),
            };

            Console.WriteLine("Input Payment : ");
            int payment = Convert.ToInt32(Console.ReadLine());

            List<Invoice> alokasiInvoice = AlokasiPembayaran(invoices, payment);

            //var table = new ConsoleTable("No", "Tagihan", "Tanggal Jatuh Tempo", "Jumlah Tagihan", "Jumlah Pembayaran", "Sisa Tagihan");
            //table.AddRow("No", "Tagihan", "Tanggal Jatuh Tempo", "Jumlah Tagihan", "Jumlah Pembayaran", "Sisa Tagihan");
            foreach (Invoice invoice in alokasiInvoice)
            {
                int sisaTagihan = invoice.jumlah - invoice.jumlahPembayaran;
                Console.WriteLine($"{invoice.deskripsi}");
                Console.WriteLine($"Due:{invoice.tglJatuhTempo}");
                Console.WriteLine($"Tagihan: {invoice.jumlah}");
                Console.WriteLine($"Pembayaran:{invoice.jumlahPembayaran}");
                Console.WriteLine($"Sisa Pembayaran:{sisaTagihan}");
                Console.WriteLine($"==================================================");
                Console.WriteLine();
            }
            
            Console.ReadLine();
        }
        static List<Invoice> AlokasiPembayaran(List<Invoice> invoices, int payment)
        {
            if (payment < 0)
            {
                Console.WriteLine("Nominal pembayaran tidak boleh kurang dari 0.");
            }

            invoices.Sort((a, b) => a.tglJatuhTempo.CompareTo(b.tglJatuhTempo));

            foreach (Invoice invoice in invoices)
            {
                int sisaTagihan = invoice.jumlah - invoice.jumlahPembayaran;

                invoice.jumlahPembayaran = Math.Min(sisaTagihan, payment);
                payment -= invoice.jumlahPembayaran;

                if (sisaTagihan > payment)
                {
                    Console.WriteLine($"Sisa Pembayaran untuk tagihan #{invoice.id} lebih besar lebih besar dari nominal pembayaran. Sisa pembayaran akan dialokasikan ke tagihan berikutnya.");
                }
            }

            if (payment > 0)
            {
                Console.WriteLine($"Nominal pembayaran lebih besar dari total tagihan yang harus di bayarkan. Sisa Pembayaran akan di kembalikan ke pelanggan");
            }
            return invoices;
        }
    }

    class Invoice
    {
        public int id { get; set; }
        public string deskripsi { get; set; }
        public DateTime tglJatuhTempo { get; set; }
        public int jumlah { get; set; }
        public int jumlahPembayaran { get; set; }

        public Invoice(int Id, string Deskripsi, DateTime TglJatuhTempo, int Jumlah)
        {
            id = Id;
            deskripsi = Deskripsi;
            tglJatuhTempo = TglJatuhTempo;
            jumlah = Jumlah;
            jumlahPembayaran = 0;
        }
    }
}