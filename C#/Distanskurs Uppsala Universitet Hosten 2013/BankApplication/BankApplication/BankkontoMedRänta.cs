//BankApplication
//Andreas Joelsson
//Version 1.0 2013-09-17
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class BankkontoMedRänta : Bankkonto
    {

        public double Räntesats { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="saldo">The intial amount of money the account should have.</param>
        /// <param name="räntesats">The interest in percentage.</param>
        public BankkontoMedRänta(double saldo, double räntesats)
            : base(saldo)
        {
            Räntesats = räntesats;
        }

        /// <summary>
        /// Method to deposit the interest to the account.
        /// </summary>
        public void SättInRänta() 
        {
            SättInPengar(Saldo * (Räntesats / 100.0));
        }

        /// <summary>
        /// Method that overrides Bankkonto class method and throws exception if the account doesn't have enough money.
        /// </summary>
        /// <see cref="Bankkonto"/>
        /// <param name="belopp">The amount of money to withdraw from the account.</param>
        public override void TaUtPengar(double belopp)
        {
            if (this.Saldo < belopp)
            { 
                throw new ÖvertrasseringsException();
            }
            base.TaUtPengar(belopp);
        }
        
    }
}
