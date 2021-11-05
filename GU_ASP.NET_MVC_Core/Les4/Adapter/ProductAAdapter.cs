using Les4.Products;
using System;

namespace Les4.Adapter
{
    public sealed class ProductAAdapter : IData
    {
        private readonly ProductA _order;

        public ProductAAdapter(ProductA order)
        {
            _order = order;
        }

        public string Name { get => _order.Name; }
        public string Description { get => _order.Description; }
        public decimal Price { get => _order.Price; }

        public void Print()
        {
            Console.WriteLine($"Name {Name}. Description {Description}. Price {Price}");
        }
    }
}
