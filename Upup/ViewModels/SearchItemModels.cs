using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.ViewModels
{
    public class SearchItemModels
    {
        public string Title { get; set; }
        public string Title_en { get; set; }
        public string Content { get; set; }
        public string Content_en { get; set; }
        public string Image { get; set; }
        public long Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryName_en { get; set; }
        public long CategoryId { get; set; }
    }
}