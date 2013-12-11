using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    interface IBetalningsmedel
    {
        /// <summary>
        /// Method to withdraw money from something.
        /// </summary>
        /// <param name="belopp">The amount to withdraw</param>
        void TaUtPengar(double belopp);

        /// <summary>
        /// Property keeping the current amount of money the person has.
        /// </summary>
        double Saldo { get; }
    }
}
