using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upup.Models;

namespace Upup.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Category> CategoryShowInCarousel { get; set; }
    }
}