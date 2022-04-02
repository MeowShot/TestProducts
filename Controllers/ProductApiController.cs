using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
  

    public class ProductApiController : ControllerBase
    {
        ProductContext _db;
        public ProductApiController(ProductContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct([FromBody] int Id)
        {
            var Product = await _db.Products.FirstAsync(x=>x.ID==Id);
            return Ok(Product);
        }
        [HttpGet]
        public  IActionResult GetProductOrdered([FromBody] string Name)
        {
          var  Products = _db.Products.Where(x=>x.Name==Name);
            return Ok(Products);
        }
        [HttpGet]
        public IActionResult GetProductOrdered([FromBody] int PriceFrom, int PriceTo)
        {
            var Products =  _db.Products.Where(x => x.Price >= PriceFrom && x.Price <= PriceTo);
            return Ok(Products);
        }

    }
}
