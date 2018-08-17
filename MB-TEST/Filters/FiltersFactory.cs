using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB_TEST
{
    public static class FiltersFactory
    {
        public static List<JsonPlaceHolderResponse> Filter(this List<JsonPlaceHolderResponse> model, Func<JsonPlaceHolderResponse, bool> selector)
        {
            List<JsonPlaceHolderResponse> result = new List<JsonPlaceHolderResponse>();

            if (model != null && model.Count() > 0)
            {
                foreach (var item in model)
                {
                    if (selector(item))
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }
    }

    public class Predicates
    {
        public static bool FilterById(JsonPlaceHolderResponse jsphr)
        {
            return jsphr.Id == 1;
        }
    }
}
