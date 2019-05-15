using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product(int id, string name, decimal price, string grosCategory)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = grosCategory;
        }

        public override string ToString()
        {
            return $"ID : {Id} \t Name : {Name} \t Price : {Price} \t Product Category : {Category}" ;
        }
    }
}
