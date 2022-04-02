using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    public static class SortedData
    {
        
        public static List<Product> Sotring(ProductContext context, int id)
        {
            List<Product> Sorted = new List<Product>();
            Sorted = context.Products.Where(x => x.ID == id).ToList();
            return Sorted;
        }

    }
}
