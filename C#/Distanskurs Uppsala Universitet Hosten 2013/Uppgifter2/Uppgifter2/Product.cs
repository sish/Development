using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgifter2
{
    //public class Hund
    //{

    //    public string Namn { get; set; }

    //    public Array Ras { get; set; }

    //    public int Ålder { get; set; }

    //    public virtual string Skäll()
    //    {

    //        return "Voff";

    //    }

    //}



    //public class Pudel : Hund
    //{

    //    public string Frisör { get; set; }

    //}

    enum DiagramPeriod { Day = 1, Week = 7, Month = 30 }

    class LambdaExample
    {

        public bool GåTillVeterinären(Hund h)
        {

            //Anropa metoden KontrolleraHund med hunden h och

            //ett lambdauttryck för parametern kontrollMetod

            Func<Hund, bool> arg2 = Hund => false; /*  Vilka lamba-uttryck fungerar att ha på denna rad ? */ ;

            return KontrolleraHund(h, arg2);

        }


        private bool KontrolleraHund(Hund hunden, Func<Hund, bool> kontrollMetod)
        {

            return kontrollMetod(hunden);

        }
    }

    public class Kund
    {
        public string Namn { get; set; }
        public int KundId { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int KundId { get; set; }
    }

    public class Hund
    {
        public string Namn { get; set; }
        public int Ålder { get; set; }
        public int ÄgareID { get; set; }
    }

    public class Ägare
    {
        public string Namn { get; set; }
        public int ÄgareID { get; set; }
    }

}
