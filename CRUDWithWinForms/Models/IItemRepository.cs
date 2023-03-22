using System.Collections.Generic;

namespace CRUDWithWinForms.Models
{
   public interface IItemRepository
    {
        void Add(ItemModel itemModel);
        void Edit(ItemModel itemModel);
        void Delete(int id);
        IEnumerable<ItemModel> GetAll();
        IEnumerable<ItemModel> GetByValue(string value); //For search 

    }
}
