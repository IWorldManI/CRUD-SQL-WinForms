using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CRUDWithWinForms.Models;
using CRUDWithWinForms.Views;

namespace CRUDWithWinForms.Presenters
{
    public class ItemPresenter
    {
        //Fields
        private IItemView view;
        private IItemRepository repository;
        private BindingSource itemsBindingSource;
        private IEnumerable<ItemModel> _itemtList;

        //Constructor
        public ItemPresenter(IItemView view, IItemRepository repository)
        {
            this.itemsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchItem;
            this.view.AddNewEvent += AddNewItem;
            this.view.EditEvent += LoadSelectedItemToEdit;
            this.view.DeleteEvent += DeleteSelectedItem;
            this.view.SaveEvent += SaveItem;
            this.view.CancelEvent += CancelAction;
            //Set items bindind source
            this.view.SetItemListBindingSource(itemsBindingSource);
            //Load item list view
            LoadAllItemList();
            //Show view
            this.view.Show();
        }

        //Methods
        private void LoadAllItemList()
        {
            _itemtList = repository.GetAll();
            itemsBindingSource.DataSource = _itemtList; //Set data source.
        }
        private void SearchItem(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                _itemtList = repository.GetByValue(this.view.SearchValue);
            else _itemtList = repository.GetAll();
            itemsBindingSource.DataSource = _itemtList;
        }
        private void AddNewItem(object sender, EventArgs e)
        {
            view.IsEdit = false;          
        }
        private void LoadSelectedItemToEdit(object sender, EventArgs e)
        {
            var item = (ItemModel)itemsBindingSource.Current;
            view.ItemId = item.Id.ToString();
            view.ItemName = item.Name;
            view.ItemType = item.Type;
            view.ItemColour = item.Colour;
            view.IsEdit = true;
        }
        private void SaveItem(object sender, EventArgs e)
        {
            var model = new ItemModel();
            model.Id = Convert.ToInt32(view.ItemId);
            model.Name = view.ItemName;
            model.Type = view.ItemType;
            model.Colour = view.ItemColour;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if(view.IsEdit)//Edit model
                {
                    repository.Edit(model);
                    view.Message = "Item edited successfuly: " + model.Type + " " + model.Name;
                }
                else //Add new model
                {
                    repository.Add(model);
                    view.Message = "Item added sucessfully: " + model.Type + " " + model.Name;
                }
                view.IsSuccessful = true;
                LoadAllItemList();
                CleanViewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void CleanViewFields()
        {
            view.ItemId = "0";
            view.ItemName = "";
            view.ItemType = "";
            view.ItemColour = "";            
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanViewFields();
        }
        private void DeleteSelectedItem(object sender, EventArgs e)
        {
            try
            {
                var item = (ItemModel)itemsBindingSource.Current;
                repository.Delete(item.Id);
                view.IsSuccessful = true;
                view.Message = "Item deleted successfully: " + item.Type + " " + item.Name;
                LoadAllItemList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not delete item";
            }
        }

    }
}
