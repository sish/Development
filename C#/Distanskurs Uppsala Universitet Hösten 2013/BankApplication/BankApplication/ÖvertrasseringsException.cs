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
    [Serializable] public class ÖvertrasseringsException : Exception
    {
        /// <summary>
        /// Overidden member Message with a custom Exception message to use.
        /// </summary>
        public override string Message
        {
            get
            {
                return "Kontot får ej övertrasseras";
            }
        }
    }
}
