using System;
using System.Windows.Forms;

namespace CRUDWithWinForms.Views
{
    public interface IItemView
    {
        //Properties - Fields
        string ItemId { get; set; }
        string ItemName { get; set; }
        string ItemType { get; set; }
        string ItemColour { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        //Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        //Methods
        void SetItemListBindingSource(BindingSource itemList);
        void Show();//Optional

    }
}
