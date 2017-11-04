using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.ViewModels
{
    public class SearchModels
    {
        public List<SearchItemModels> SearchProductResult { get; set; }
        public List<SearchItemModels> SearchTopicResult { get; set; }
    }
}