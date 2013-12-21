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
    class Prenumerationsregister
    {
        public List<Prenumerant> Prenumeranter { get; private set; }

        /// <summary>
        /// Method to add a new subscriber to the register.
        /// </summary>
        /// <param name="prenumerant">The prenumerant to add to the register.</param>
        public void LäggTillPrenumerant(Prenumerant prenumerant) 
        {
            Prenumeranter.Add(prenumerant);
        }

        /// <summary>
        /// Method to withdraw money from all customers in the register.
        /// </summary>
        /// <param name="belopp">The amount in sek to withdraw from each customer.</param>
        public void DraÅrsavgiftFrånAllaPrenumeranter(double belopp)
        {
            foreach (Prenumerant prenumerant in Prenumeranter)
            {
                prenumerant.Betalningsmedel.TaUtPengar(belopp);
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Prenumerationsregister()
        {
            Prenumeranter = new List<Prenumerant>();
        }

    }
}
