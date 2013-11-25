using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomCollections;
using CustomDatastructures.Core;

namespace CustomCollectionsTestApp
{
    /// <summary>
    /// Test application for ObservableList.
    /// </summary>
    public partial class TestApp : Form
    {

        ObservableList<int> intList;

        public TestApp()
        {
            InitializeComponent();
        }

        private void TestApp_Load(object sender, EventArgs e)
        {
            intList = new ObservableList<int>();
            intList.BeforeChange += intList_BeforeChange;
            intList.Changed += intList_Changed;
        }

        void intList_Changed(object sender, ListChangedEventArgs<int> e)
        {
            if (Operation.Add == e.Operation)
            {
                lbx_intlist.Items.Add(e.Value);
            }
            else
            {
                lbx_intlist.Items.Remove(e.Value);
            }
        }

        void intList_BeforeChange(object sender, RejectableEventArgs<int> e)
        {
            if (Operation.Add == e.Operation && e.Value > 1000 )
            {
                e.RejectOperation();
                MessageBox.Show("Only values of 1000 and below accepted.");
            }
            else if (Operation.Remove == e.Operation && e.Count <= 2)
            {
                e.RejectOperation();
                MessageBox.Show("Cannot reduce list to less than 2 elements.");
            }
        }

        private void btn_addint_Click(object sender, EventArgs e)
        {
            int value = 0;
            if (true == int.TryParse(tbx_addint.Text, out value))
            {
                if (true == intList.TryAdd(value))
                {
                    tbx_addint.Clear();
                }
            }
        }

        private void btn_intremove_Click(object sender, EventArgs e)
        {
            int value = 0;
            if( true == int.TryParse(lbx_intlist.SelectedItem.ToString(), out value ) )
            {
                if (true != intList.TryRemove(value))
                {
                    MessageBox.Show(string.Format("Unable to remove value {0} from the list.", value));
                }
            }
        }

        private void btn_containsint_Click(object sender, EventArgs e)
        {
            int value = 0;
            string message = "";
            if (true == int.TryParse(tbx_containsint.Text, out value))
            {
                if (true == intList.Contains(value))
                {
                    message += value + " is in the list."; 
                }
                else
                {
                    message += value + " is NOT in the list.";
                }
            }
            else
            {
                message += "Not a valid integer provided to check in list.";
            }
            MessageBox.Show(message);
        }


    }
}
