using System;

namespace CRUDWithWinForms.Views
{
    public interface IMainView
    {
        event EventHandler ShowItemView;
        event EventHandler ShowOwnerView;
        event EventHandler ShowDataView;

    }
}
