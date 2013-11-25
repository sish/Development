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
    class BankkontoMedRäntaOchInnehavare : BankkontoMedRänta
    {

        public Person Innehavare { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="saldo">The intial amount of money the account should have.</param>
        /// <param name="räntesats">The interest in percentage.</param>
        /// <param name="innehavare">Instacen of the Person class.</param>
        public BankkontoMedRäntaOchInnehavare(double saldo, double räntesats, Person innehavare) 
            : base(saldo, räntesats)
        {
            this.Innehavare = innehavare;
        }

        /// <summary>
        /// Overloaded tostring medhod to display user.
        /// </summary>
        /// <see cref="Person.cs"/>
        /// <returns>String from the Person class.</returns>
        public override string ToString() 
        {
            return Innehavare.ToString();
        }
    }
}
