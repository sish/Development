using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomCollections
{
    public class OperationRejectedException : System.InvalidOperationException
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message to set for information to the exception.</param>
        public OperationRejectedException(string message)
            : base(message)
        {
        }

    }
}
