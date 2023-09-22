using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Litest
{
    class soalPinalty
    {
        static void main(string[] args)
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

            List<Pembayaran> pembayarans = new List<Pembayaran>()
            {
                new Pembayaran(1,1, new DateTime(2023,1,10), 165000),
                new Pembayaran(2,3, new DateTime(2023,2,20), 130000),
                new Pembayaran(2,5, new DateTime(2023,2,20), 95500),
                new Pembayaran(3,2, new DateTime(2023,3,25), 30000),
                new Pembayaran(4,2, new DateTime(2023,3,30), 50000),
                new Pembayaran(4,4, new DateTime(2023,4,30), 50000),
            };

            DateTime tempo = new DateTime(2023, 4, 29);

            var results = PerhitunganPinalty(invoices, pembayarans, tempo);

            var table = new ConsoleTable("No Tagihan", "No Penalty", "Tagihan Overdue", "Hari Keterlambatan", "Amount Penalty");

            foreach (var result in results)
            {
                table.AddRow(result.invoiceIds, result.noPinalty, result.tagihanOverDue, result.hariKeterlambatan, result.jumlahPinalty);
            }

            Console.WriteLine(table);
        }

        static List<Pinalty> PerhitunganPinalty(List<Invoice> invoices, List<Pembayaran> pembayarans, DateTime tempo)
        {
            var results = new List<Pinalty>();
            foreach (var invoice in invoices)
            {
                var pokokPembayaran = pembayarans.Where(p => p.invoiceId == invoice.id).ToList();

                if (pokokPembayaran.Any())
                {
                    var totalKeterlambatan = 0;
                    var totaPenalty = 0;

                    foreach (var p in pokokPembayaran)
                    {
                        var hariKeterlambatan = (tempo - invoice.tglJatuhTempo).Days;
                        var jumlahPinalty = invoice.jumlah * 2.0 / 1000.0 * hariKeterlambatan;

                        totalKeterlambatan += invoice.jumlah;
                        totaPenalty += Convert.ToInt32(jumlahPinalty);
                    }

                    results.Add(new Pinalty
                    {
                        invoiceIds = invoice.id,
                        noPinalty = pokokPembayaran.Count,
                        tagihanOverDue = totalKeterlambatan,
                        hariKeterlambatan = (tempo - invoice.tglJatuhTempo).Days,
                        jumlahPinalty = totaPenalty,
                    });
                }
            }

            return results;
        }
    }

    class Invoice
    {
        public int id { get; set; }
        public string deskripsi { get; set; }
        public DateTime tglJatuhTempo { get; set; }
        public int jumlah { get; set; }
        public List<Pembayaran> pembayaran { get; set; } = new List<Pembayaran>();


        public Invoice(int Id, string Deskripsi, DateTime TglJatuhTempo, int Jumlah)
        {
            id = Id;
            deskripsi = Deskripsi;
            tglJatuhTempo = TglJatuhTempo;
            jumlah = Jumlah;

        }
    }

    class Pembayaran
    {
        public int id { get; set; }
        public int invoiceId { get; set; }
        public DateTime tglPembayran { get; set; }
        public int jmlPembayaran { get; set; }
        public Pembayaran(int Id, int InvoiceId, DateTime TglPembayaran, int JmlPembayaran)
        {
            id = Id;
            invoiceId = InvoiceId;
            tglPembayran = TglPembayaran;
            jmlPembayaran = JmlPembayaran;
        }
    }
    class Pinalty
    {
        public int id { get; set; }
        public int invoiceIds { get; set; }
        public int noPinalty { get; set; }
        public int tagihanOverDue { get; set; }
        public int hariKeterlambatan { get; set; }
        public int jumlahPinalty { get; set; }
        public Pinalty(int InvoiceIds, int NoPinalty, int TagihanOverDue, int HariKeterlambatan, int JumlahPinalty)
        {
            id = InvoiceIds;
            noPinalty = NoPinalty;
            tagihanOverDue = TagihanOverDue;
            hariKeterlambatan = HariKeterlambatan;
            jumlahPinalty = JumlahPinalty;
        }
    }


}
