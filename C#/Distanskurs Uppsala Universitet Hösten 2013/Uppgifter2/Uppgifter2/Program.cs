using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgifter2
{
    class Program
    {
        static void Main(string[] args)
        {

            DiagramPeriod period;

            Console.WriteLine((int)DiagramPeriod.Day);
            Console.WriteLine((int)DiagramPeriod.Week);
            Console.WriteLine((int)DiagramPeriod.Month);
            period = (DiagramPeriod)25;
            int fgsgsgsg = (int)period;
            Console.WriteLine(fgsgsgsg);
            period = DiagramPeriod.Month;
            int antalDagar = (int)period;
            fgsgsgsg = (int)period;
            Console.WriteLine(fgsgsgsg);

            //var mats = new Hund();
            //Pudel bosse = mats;

            //var anneli = new Hund();
            //Pudel pär = (Pudel)anneli;

            /*var anneli2 = new Pudel();
            Hund pär2 = (Pudel)anneli2;

            Pudel tiffany = new Pudel();
            Hund pudel = tiffany;

            var anneli3 = new Pudel();
            Hund pär3 = (Hund)anneli3;

            Hund mats4 = new Pudel();
            Hund bosse4 = mats4;

            var anneli5 = new Pudel();
            Hund pär5 = anneli5 as Hund;

            //Console.WriteLine(bosse.ToString());
            //Console.WriteLine(pär.ToString());
            Console.WriteLine(pär2.ToString());
            Console.WriteLine(pudel.ToString());
            Console.WriteLine(pär3.ToString());
            Console.WriteLine(bosse4.ToString());
            Console.WriteLine(pär5.ToString());*/

            /*var hundLista2 = new List<Hund>() 
            { 
                new Hund(){Namn="Tiffany", Ålder=4},
                new Hund(){Namn="Tessan", Ålder=6},
                new Hund(){Namn="Andreas", Ålder=8},
                new Hund(){Namn="Tom", Ålder=9}
            };


            if (hundLista2.Any(hund => hund.Ålder > 5))
            {
                IEnumerable<Hund> utvaldaHundar =
                    hundLista2.Where(h => h.Namn.StartsWith("T")).Where(hund => hund.Ålder < 7);
                foreach (Hund h in utvaldaHundar) {
                    Console.WriteLine("Hund::: " + h.Namn + Environment.NewLine);
                }
            }

            var hundLista23 = new List<Hund>() 
            { 
                new Hund(){Namn="Tiffany", Ålder=6},
                new Hund(){Namn="Tiffany Jr", Ålder=6},
                new Hund(){Namn="Andreas", Ålder=8},
                new Hund() {Namn="Andreas", Ålder=9},
                new Hund(){Namn="Tom", Ålder=6}
            };

            var ordnadLista = hundLista23.OrderBy(hund => hund.Ålder).ThenBy(hund => hund.Namn);

            foreach (Hund h in ordnadLista) {
                Console.WriteLine(h.Ålder + "::" + h.Namn + Environment.NewLine);
            }

            var kundLista = new List<Kund>() { 
                new Kund(){Namn = "Pelle", KundId = 1}, 
                new Kund(){Namn= "Sven", KundId = 2}, 
                new Kund(){Namn= "Andreas", KundId = 3} 
            };

            var orderLista = new List<Order>() { 
                new Order(){OrderId = 8, KundId = 4}, 
                new Order(){OrderId = 22, KundId = 2},
                new Order(){OrderId = 32, KundId = 3}, 
                new Order(){OrderId = 27, KundId = 1}, 
                new Order(){OrderId = 28, KundId = 2}, 
                new Order(){OrderId = 64, KundId = 1},
                new Order(){OrderId = 81, KundId = 4},
                new Order(){OrderId = 94, KundId = 1},
                new Order(){OrderId = 82, KundId = 7},
                new Order(){OrderId = 31, KundId = 1}
            };

            var query = kundLista.Join(
                orderLista,
                kund => kund.KundId,
                order => order.KundId,
                (x, y) => new { Namn = x.Namn, OrderId = y.OrderId }
                );

            var query2 = query.GroupBy(g => g.Namn).Select(x => x.Count()).Sum();

            Console.WriteLine("Query2: " + query2);

            var hund24 =

             new

             {

                 Namn = "Tiffany",

                 Ålder = 7

             };

            Console.WriteLine("Name: " + hund24.Namn + ", Ålder : " + hund24.Ålder);*/

            Console.WriteLine("********************");

            List<Ägare> ägareLista = new List<Ägare>() {
                new Ägare() { Namn = "Kalle Svensson", ÄgareID = 1 },
                new Ägare() { Namn = "Egil Svensson", ÄgareID = 2 },
                new Ägare() { Namn = "Allan Svensson", ÄgareID = 3 },
                new Ägare() { Namn = "Morten Svensson", ÄgareID = 4 },
                new Ägare() { Namn = "Hane Svensson", ÄgareID = 5 }
            };
            List<Hund> hundLista = new List<Hund>() {
                new Hund(){Namn="Tiffany", Ålder=6, ÄgareID=1},
                new Hund(){Namn="Tiffany Jr", Ålder=6, ÄgareID=2},
                new Hund(){Namn="Andreas", Ålder=8, ÄgareID=1},
                new Hund() {Namn="Andreas", Ålder=9, ÄgareID=3},
                new Hund(){Namn="Tom", Ålder=6, ÄgareID=4}
            };

            var query2 =  from ägare in ägareLista
                          join hund in hundLista on
                          ägare.ÄgareID equals hund.ÄgareID into x
                          select new { a = ägare, b = x};
            foreach (var i in query2)
            {
                Console.WriteLine(i);
                
                foreach (var h in i.b)
                {
                    Console.WriteLine(h);
                }
            }
            /*var query4 = query2.GroupBy(g => g.Namn).Select(x => x.Count()).Sum();
            Console.WriteLine("query4: " + query4);
            var query5 = from q in query2
                         group q by q.Namn into g
                         select g.Sum(x => x.OrderId);
            var query9 = from q in query2
                         group q by q.Namn into g
                         select g.Sum();
            var query8 = (from q in query2
                          group q by q.Namn into g
                          select g.Count()).Sum();
            var query7 = from q in query2
                         group q by q.Namn into g
                         select g.Count().Sum();
            var query6 = from q in query2
                         group q by q.Namn into g
                         select g.Count();*/

            Console.ReadKey();
        }

        

    }
}
