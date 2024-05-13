using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using batch3.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace batch3.ViewModels
{
    public class ProductVM
    {
      public Product Product { get; set; }
      [ValidateNever]
      public IEnumerable<SelectListItem> CategoryList { get; set; }

    }
}
