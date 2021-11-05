using Les4.Products;
using System;

namespace Les4.Adapter
{
    public sealed class ProductCAdapter : IData
    {
        private readonly ProductC _order;

        public ProductCAdapter(ProductC order)
        {
            _order = order;
        }

        public string Name { get => _order.Name; }
        public string Description { get => $"{_order.Description}. Color {_order.Color}, Size {_order.Size}"; }
        public decimal Price { get => _order.Price; }
        public void Print()
        {
            Console.WriteLine($"Name {Name}. Description {Description}. Price {Price}");
        }
    }
}
