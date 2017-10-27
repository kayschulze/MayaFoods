using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MayaFoods.Models
{
    [Table("Products")]

    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Origincountry { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public Product() { }

        public Product(int productid, string name, double cost, string origincountry)
        {
            ProductId = productid;
            Name = name;
            Cost = cost;
            Origincountry = origincountry;
        }

        public override bool Equals(System.Object otherProduct)
        {
            if (!(otherProduct is Product))
            {
                return false;
            }
            else
            {
                Product newProduct = (Product)otherProduct;
                bool idEquality = this.ProductId == newProduct.ProductId;
                bool nameEquality = this.Name == newProduct.Name;
                bool costEquality = this.Cost == newProduct.Cost;
                bool origincountryEquality = this.Origincountry == newProduct.Origincountry;

                return (idEquality && nameEquality && costEquality && origincountryEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.ProductId.GetHashCode();
        }
    }
}
