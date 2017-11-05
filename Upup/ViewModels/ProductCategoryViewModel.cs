using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upup.Models;

namespace Upup.ViewModels
{
    public class ProductCategoryViewModel : HomeViewModel
    {
        public Category CurrentCategory { get; set; }
    }
}