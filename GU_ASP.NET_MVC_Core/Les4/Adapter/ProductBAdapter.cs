using Les4.Products;
using System;

namespace Les4.Adapter
{
    public sealed class ProductBAdapter : IData
    {
        private readonly ProductB _order;

        public ProductBAdapter(ProductB order)
        {
            _order = order;
        }

        public string Name { get => _order.Name; }
        public string Description { get => $"{_order.Description}. Power = {_order.Power}"; }
        public decimal Price { get => _order.Price; }
        public void Print()
        {
            Console.WriteLine($"Name {Name}. Description {Description}. Price {Price}");
        }
    }
}
