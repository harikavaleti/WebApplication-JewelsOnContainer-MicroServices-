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
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }
            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }
        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }
            public static string GetOrders(string baseUri)
            {
                return baseUri;
            }
            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }
    }
}
