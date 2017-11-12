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
        public long TotalCount => (SearchProductResult == null ? 0 : SearchProductResult.Count) + (SearchTopicResult == null ? 0 : SearchTopicResult.Count);
    }
}