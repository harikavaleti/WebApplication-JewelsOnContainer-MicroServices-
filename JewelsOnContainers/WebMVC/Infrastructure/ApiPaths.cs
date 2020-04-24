using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public class ApiPaths
    {
        public static class Catalog
        {
          public static string GetAllCatalogItems(string baseUri, int page, int take, int? brand, int? type)
          {
                var filterQs = string.Empty;

                if(brand.HasValue || type.HasValue)
                {
                    var brandQs = (brand.HasValue) ? brand.Value.ToString() : "-1";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "-1";
                    filterQs = $"/type/{typeQs}/brand/{brandQs}";
                }

             return $"{baseUri}/items{filterQs}?pageIndex={page}&pageSize={take}";
          }

            public static string GetAllCatalogTypes(string baseUri)
            {
                return $"{baseUri}/catalogtypes";
            }

            public static string GetAllCatalogBrands(string baseUri)
            {
                return $"{baseUri}/catalogbrands";
            }
        }
        public static class Basket
        {

        }
    }
}
