using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRUDWithWinForms.Models
{
    public class ItemModel
    {
        //Fields
        private int id;
        private string name;
        private string type;
        private string colour;

        //Properties - Validations
        [DisplayName("Item ID")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Item Name")]
        [Required(ErrorMessage ="Item name is requerid")]
        [StringLength(50,MinimumLength =3, ErrorMessage ="Item name must be between 3 and 50 characters")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DisplayName("Item Type")]
        [Required(ErrorMessage = "Item type is requerid")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Item type must be between 3 and 50 characters")]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        [DisplayName("Item Colour")]
        [Required(ErrorMessage = "Item colour is requerid")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Item colour must be between 3 and 50 characters")]
        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }
    }
}
