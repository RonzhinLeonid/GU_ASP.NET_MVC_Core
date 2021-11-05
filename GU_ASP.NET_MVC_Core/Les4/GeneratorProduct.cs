using Bogus;
using Les4.Products;

namespace Les4
{
    public class GeneratorProduct
    {
        public void GetProductA(ISerializer serializer, int count = 1)
        {
            serializer.Serialize(FakerProductA.Generate(count));
        }

        public void GetProductB(ISerializer serializer, int count = 1)
        {
            serializer.Serialize(FakerProductB.Generate(count));
        }

        public void GetProductC(ISerializer serializer, int count = 1)
        {
            serializer.Serialize(FekerProductC.Generate(count));
        }

        Faker<ProductA> FakerProductA = new Faker<ProductA>()
            .StrictMode(true)
            .RuleFor(x => x.Id, f => f.Finance.Random.Int(1,100))
            .RuleFor(x => x.Name, f => f.Commerce.Product())
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
            .RuleFor(x => x.Category, f => f.Commerce.ProductAdjective())
            .RuleFor(x => x.Price, f => f.Finance.Random.Decimal(20, 80));

        Faker<ProductB> FakerProductB = new Faker<ProductB>()
            .StrictMode(true)
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Name, f => f.Commerce.Product())
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
            .RuleFor(x => x.Power, f => f.Finance.Random.Int(85, 250))
            .RuleFor(x => x.Price, f => f.Finance.Random.Decimal(20, 80));

        Faker<ProductC> FekerProductC = new Faker<ProductC>()
            .StrictMode(true)
            .RuleFor(x => x.Id, f => f.Finance.Random.Int(1, 100))
            .RuleFor(x => x.Name, f => f.Commerce.Product())
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
            .RuleFor(x => x.Size, f => f.Finance.Random.Int(85, 250))
            .RuleFor(x => x.Color, f => f.Commerce.Color())
            .RuleFor(x => x.Category, f => f.Commerce.ProductAdjective())
            .RuleFor(x => x.Price, f => f.Finance.Random.Decimal(20, 80));
    }



}
