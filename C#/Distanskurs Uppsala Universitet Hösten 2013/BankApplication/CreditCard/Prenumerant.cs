//CreditCard application
//Andreas Joelsson
//Version 1.0 2013-09-18
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication;

namespace CreditCard
{
    class Prenumerant : Person
    {

        public IBetalningsmedel Betalningsmedel { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="efternamn">Last name of the customer.</param>
        /// <param name="förnamn">First name of the customer.</param>
        /// <param name="betalning">What payment method the customer prefers.</param>
        public Prenumerant(string efternamn, string förnamn, IBetalningsmedel betalning)
            : base(efternamn, förnamn) 
        {
            Betalningsmedel = betalning;
        }

        /// <summary>
        /// Overidden tostring method.
        /// </summary>
        /// <returns>Returns a string in the format "LastName, Firstname, X.XX kr"</returns>
        public override string ToString()
        {
            return String.Format("{0}, {1}, {2:0.00} kr", Efternamn, Förnamn, Betalningsmedel.Saldo);
        }

    }
}
