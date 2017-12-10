using System.Collections.Generic;
using Upup.Models;

namespace Upup.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Category> CategoryShowInCarousel { get; set; }
        public IEnumerable<Post> UserGuides { get; set; }
    }
}