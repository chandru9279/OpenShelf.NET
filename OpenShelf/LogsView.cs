using System;
using System.Windows.Forms;

namespace OpenShelf
{
    public partial class LogsView : Form
    {
        public LogsView()
        {
            InitializeComponent();
        }


        private void LogsView_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'logsDataSet.Borrows' table. You can move, or remove it, as needed.
            this.borrowsTableAdapter.Fill(this.logsDataSet.Borrows);

        }

        private void borrowsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.borrowsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.logsDataSet);

        }
    }
}
