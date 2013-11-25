using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomDatastructures.Core;

namespace CustomCollections
{
    // Make this class generic by adding a type-parameter to the class
    public class ObservableList<T> : IEnumerable<T>, IObservableList<T>
    {
        // Declare an private variabel to work as 
        // the internal data storage for the list
        private List<T> internalList = new List<T>();

        /// <summary>
        /// Method to check if the item T is in the Collection.
        /// </summary>
        /// <param name="item">Generic items.</param>
        /// <returns>bool</returns>
        public bool Contains(T item)
        {
            return internalList.Contains(item);
        }

        /// <summary>
        /// Method to att item T to the Collection.
        /// </summary>
        /// <param name="item">Generic item.</param>
        public void Add(T item)
        {
            CustomEventArgs<T> UpcomingAdd = new CustomEventArgs<T>(Operation.Add, item, internalList.Count);
            DoBeforeChange(UpcomingAdd);
            if (true != UpcomingAdd.IsOperationRejected )
            {
                internalList.Add(item);
                DoWhenChanged(new ListChangedEventArgs<T>(Operation.Add, item, internalList.Count));
            }
            else
            {
                throw new OperationRejectedException("Add was rejected by an observer");
            }
        }

        /// <summary>
        /// Method to try and add an item T to the collection.
        /// </summary>
        /// <param name="item">Generic item.</param>
        /// <returns>bool</returns>
        public bool TryAdd(T item)
        {
            bool retValue = true;
            try
            {
                Add(item);
            }
            catch (Exception)
            {
                retValue = false;
            }
            return retValue;
        }

        /// <summary>
        /// Method to remove an existing item T from the Collection.
        /// </summary>
        /// <param name="item">Generic item.</param>
        public void Remove(T item)
        {
            if (true != Contains(item))
            {
                throw new InvalidOperationException("Item {0} is not present in the ObservableList.");
            }
            else
            {
                CustomEventArgs<T> UpcomingRemove = new CustomEventArgs<T>(Operation.Remove, item, internalList.Count);
                DoBeforeChange(UpcomingRemove);
                if (true != UpcomingRemove.IsOperationRejected)
                {
                    internalList.Remove(item);
                    DoWhenChanged(new ListChangedEventArgs<T>(Operation.Remove, item, internalList.Count));
                }
                else
                {
                    throw new OperationRejectedException("Remove was rejected by an observer");
                }
            }
        }

        /// <summary>
        /// Method to try and remove and item T from the Collection.
        /// </summary>
        /// <param name="item">Generic item.</param>
        /// <returns>bool</returns>
        public bool TryRemove(T item)
        {
            bool retValue = true;
            try
            {
                Remove(item);
            }
            catch (Exception)
            {
                retValue = false;
            }
            return retValue;
        }

        public event EventHandler<ListChangedEventArgs<T>> Changed;
        public event EventHandler<RejectableEventArgs<T>> BeforeChange;

        /// <summary>
        /// Method called to invoke changes on the list.
        /// </summary>
        /// <param name="args">ListChangedEventArgs object with generic type T.</param>
        protected virtual void DoWhenChanged(ListChangedEventArgs<T> args)
        {
            if (null != Changed)
            {
                Changed.Invoke(this, args);
            }
        }

        /// <summary>
        /// Method called to invoke before change on the list.
        /// </summary>
        /// <param name="args">RejectableEventArgsC object with generic type T.</param>
        protected virtual void DoBeforeChange(CustomEventArgs<T> args)
        {
            if (null != BeforeChange)
            {
                BeforeChange.Invoke(this, args);
            }
        }


        // The GetEnumerator methods is required by the IEnumerable and IEnumerable<T>
        // interfaces and you could use the following implementations for these methods.
        // internalList is the internal data storage for the ObservableList,
        // you should replace it with the name of your list instead.

        /// <summary>
        /// Method implemented from the IEnumerable interface.
        /// </summary>
        /// <returns>IEnumerator for the generic type T.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return internalList.GetEnumerator();
        }

        /// <summary>
        /// Method implemented from the IEnumerable interface.
        /// </summary>
        /// <returns>IEnumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)internalList).GetEnumerator();
        }
    }
}
