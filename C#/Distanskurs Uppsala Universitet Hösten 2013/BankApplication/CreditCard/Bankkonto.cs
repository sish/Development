//BankApplication
//Andreas Joelsson
//Version 1.0 2013-09-XX
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCard;

namespace BankApplication
{
    class Bankkonto : IBetalningsmedel
    {
        // Egenskaper
        public double Saldo { get; private set; }
        // Konstruktor
        /// <summary>
        /// Constructor for the account class.
        /// </summary>
        /// <param name="saldo">The intial amount of money the account should have.</param>
        public Bankkonto(double saldo) 
        {
            this.Saldo = saldo;
        }

        // Metoder
        /// <summary>
        /// Method to deposit money to the account.
        /// </summary>
        /// <param name="belopp">The amount of money to deposit to the account.</param>
        public virtual void SättInPengar(double belopp)
        {
            this.Saldo += belopp;
        }

        /// <summary>
        /// Method to withdraw money from the account.
        /// </summary>
        /// <param name="belopp">The amount of money to withdraw from the account.</param>
        public virtual void TaUtPengar(double belopp)
        {
            this.Saldo -= belopp;
        }

        /// <summary>
        /// Overiddent ToString method to define a specific return string for the use of the Bankkonto class.
        /// </summary>
        /// <returns>string in the format "The account balance is X.XX sek."</returns>
        public override string ToString()
        {
            return String.Format("The account balance is {0:0.00} sek.", this.Saldo);
        }
    }
}
