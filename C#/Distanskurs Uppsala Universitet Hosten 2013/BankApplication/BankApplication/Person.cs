//BankApplication
//Andreas Joelsson
//Version 1.0 2013-09-16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Person
    {
        // Publika egenskaper
        public string Efternamn { get; set; }
        public string Förnamn { get; set; }

        // Konstruktor med två parametrar
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="efternamn">Last name of the individual.</param>
        /// <param name="förnamn">First name of the individual.</param>
        public Person(string efternamn, string förnamn) 
        {
            this.Efternamn = efternamn;
            this.Förnamn = förnamn;
        }

        // Returnera namnet på formen ”Efternamn, Förnamn”
        // ToString()-metoden ärvs från Object. Nu överskuggar vi den och kan därmed // själva tillhandahålla en sträng-representation av objektet.
        /// <summary>
        /// Overidden ToString Method.
        /// </summary>
        /// <returns>String in the format "Lastname, Firstname"</returns>
        public override string ToString() 
        {
            return String.Format("{0}, {1}", this.Efternamn, this.Förnamn);
        }
    }
}
