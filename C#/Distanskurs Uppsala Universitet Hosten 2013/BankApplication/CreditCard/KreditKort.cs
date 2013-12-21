//CreditCard application
//Andreas Joelsson
//Version 1.0 2013-09-18
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    class KreditKort : IBetalningsmedel
    {
        //Egenskap
        public double Saldo { get; private set; }
        //Metod
        /// <summary>
        /// Implemented from IBetalningsmedel.
        /// </summary>
        /// <param name="belopp">The amount to withdraw from the current saldo.</param>
        public void TaUtPengar(double belopp) 
        {
            this.Saldo -= belopp;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="saldo">The amount to intialize the credit card saldo to.</param>
        public KreditKort(double saldo)
        {
            this.Saldo = saldo;
        }
    }
}
