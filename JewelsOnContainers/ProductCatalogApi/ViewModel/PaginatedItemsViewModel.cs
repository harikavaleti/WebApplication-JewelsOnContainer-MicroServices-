using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogApi.ViewModel
{
    public class PaginatedItemsViewModel<TEntity>
        where TEntity:class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }

        public IEnumerable<TEntity> Data { get; set; }

    }
}
