using CustomDatastructures.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomCollections
{
    public class CustomEventArgs<T> : RejectableEventArgs<T>
    {

        private bool _isOperationRejected;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="operation">Operation enum type.</param>
        /// <param name="value">Generic T value.</param>
        /// <param name="count">int with the count.</param>
        public CustomEventArgs(Operation operation, T value, int count)
            : base(operation, value, count)
        {
            _isOperationRejected = false;
        }

        /// <summary>
        /// Operator showing if an operation has been rejected or not.
        /// </summary>
        public override bool IsOperationRejected
        {
            get { return _isOperationRejected; }
        }

        /// <summary>
        /// Method to reject an operation regardning to what will happen.
        /// </summary>
        public override void RejectOperation()
        {
            _isOperationRejected = true;
        }
    }
}
