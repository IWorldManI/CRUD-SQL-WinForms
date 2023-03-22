using System;
using System.Windows.Forms;

namespace CRUDWithWinForms.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            btnItems.Click += delegate { ShowItemView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowItemView;
        public event EventHandler ShowOwnerView;
        public event EventHandler ShowDataView;
    }
}
