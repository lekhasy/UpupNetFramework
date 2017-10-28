using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Upup.Areas.Admin.Models
{
    public class DataTableRequest
    {
        public int draw { get; set; }
        public int start { get; set; } //
        public int length { get; set; } //
        public Search search { get; set; } //

        public IEnumerable<Order> order { get; set; }

        public IEnumerable<Column> columns { get; set; }

        public class Search
        {
            public string value { get; set; }
            public bool regex { get; set; }
        }

        public class Column
        {
            public string data { get; set; }
            public string name { get; set; }
            public bool searchable { get; set; }
            public bool orderable { get; set; }

            public Search search { get; set; }
        }

        public class Order
        {
            public int column { get; set; }
            public string dir { get; set; }
        }
    }

    public class DataTableResponse<T>
    {
        public int draw { get; set; }
        public T DT_RowData { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public IEnumerable<T> data { get; set; }
        public string error { get; set; }
    }

    public static class DataTableRequestHandler<T> where T : class
    {
        //public DataTableResponse<T> PerformAsync(DataTableRequest request, DbSet<T> dbSet)
        //{
        //    DataTableResponse<T> dataTableResponse = new DataTableResponse<T>();
        //    dataTableResponse.draw = request.draw;
        //    dataTableResponse.recordsTotal = dbSet.Count();

        //    var filtered = dbSet;

        //    foreach (var col in request.columns)
        //    {
        //        if (col.searchable)
        //        {
        //            filtered = dbSet.
        //        }
        //    }
            
        //}
    }
}