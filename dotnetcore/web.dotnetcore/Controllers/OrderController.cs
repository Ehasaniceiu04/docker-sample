using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web.dotnetcore.Controllers
{
    [Route("api/orders")]
    public class OrderController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return new Order[] {
                new Order{Id=1,ProductName="Polo Shirt", Quantity=2,TotalPrice=4000, CustomerName="Mr Bjorn Ironside", CustomerContactNo="#######2423",CustomerEmail="##@gmail.com"},
                new Order{Id=2,ProductName="Formal Shirt",Quantity=1,TotalPrice=7000,  CustomerName="Mr John Oliver", CustomerContactNo="#######2423",CustomerEmail="##@gmail.com"},
                new Order{Id=3,ProductName="Denim Shirt",Quantity=2,TotalPrice=4000,  CustomerName="Mr Rono", CustomerContactNo="#######2423",CustomerEmail="##@gmail.com"},
                new Order{Id=4,ProductName="Dress Shirt",Quantity=2,TotalPrice=4000,  CustomerName="Mr Taheri", CustomerContactNo="#######2423",CustomerEmail="##@gmail.com"},
                new Order{Id=5,ProductName="Short Sleeve Shirt",Quantity=2,TotalPrice=4000,  CustomerName="Mr Rollo", CustomerContactNo="#######2423",CustomerEmail="##@gmail.com"},
                new Order{Id=6,ProductName="Linen Shirt",Quantity=2,TotalPrice=4000,  CustomerName="Mr Bjorn Ironside", CustomerContactNo="#######2423",CustomerEmail="##@gmail.com"},
                new Order{Id=7,ProductName="Flannel Shirt", Quantity=2,TotalPrice=4000, CustomerName="Mr Rognork Lothbrok", CustomerContactNo="#######2423",CustomerEmail="##@gmail.com"},
                new Order{Id=8,ProductName="T-Shirt",Quantity=2,TotalPrice=4000,  CustomerName="Mrs Lagrta", CustomerContactNo="#######2423",CustomerEmail="##@gmail.com"},
                new Order{Id=9,ProductName="Spaghetti Strap Shirt",Quantity=2,TotalPrice=4000,  CustomerName="Mrs Torvi", CustomerContactNo="#######2423",CustomerEmail="##@gmail.com"},
                new Order{Id=10,ProductName="Tank Shirt",Quantity=2,TotalPrice=4000,  CustomerName="Mrs Aslaug", CustomerContactNo="#######2423",CustomerEmail="##@gmail.com"},
                new Order{Id=11,ProductName="Camisole",Quantity=2,TotalPrice=4000,  CustomerName="Mrs Y", CustomerContactNo="#######2423",CustomerEmail="##@gmail.com"},
                     
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContactNo { get; set; }
        public string CustomerEmail { get; set; }
    }
}
