using Microsoft.AspNetCore.Mvc.Rendering;

namespace BasicSkin.Models
{
    public class CategoryModel
    {
        public IEnumerable<SelectListItem> ListOfCategories { get; set; }
    }
}
