using Bogus;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Les4
{
    class Program
    {
        static void Main(string[] args)
        {

            GeneratorProduct generator = new GeneratorProduct();
            DataParser parser = new DataParser();
            ParseStrategySelector strategySelector = new ParseStrategySelector();

            ISerializer jsonSerializer = new JsonSerializator();
            ISerializer xmlSerializer = new XMLSerializator();

            var ProductsA = generator.GetProductA(jsonSerializer, 4);
            var ProductsB = generator.GetProductB(jsonSerializer, 3);
            var ProductsC = generator.GetProductC(xmlSerializer, 5);

            var parsedData = parser.Parse(chairs, strategySelector.SelectParseStrategy(chairs));
            storage.AddRange(parsedData);
        }
    }
    abstract class ParseStrategy
    {
        public abstract IEnumerable<Data> Parse(string data);
    }

    class JsonParseStrategy : ParseStrategy
    {
        public override IEnumerable<Data> Parse(string data)
        {
            var result = JsonSerializer.Deserialize<IEnumerable<Data>>(data);
            return result;
        }
    }
    class XMLParseStrategy : ParseStrategy
    {
        public override IEnumerable<Data> Parse(string data)
        {
            using var reader = new StringReader(data);
            XmlReader serializer = XmlReader.Create(reader);
            serializer.MoveToContent();
            serializer.ReadStartElement();
            return Array.Empty<Data>();
        }
    }

    class DataParser
{
        public IEnumerable<Data> Parse(string data, ParseStrategy parseStrategy)
        {
            return parseStrategy.Parse(data);
        }
    }
    public record Data
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductA
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
    public class ProductB
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Power { get; set; }
        public decimal Price { get; set; }
    }
    public class ProductC
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public interface ISerializer
    {
        string Serialize<T>(List<T> data);
    }

    public class JsonSerializator : ISerializer
    {
        public string Serialize<T>(List<T> data)
        {
            return JsonSerializer.Serialize(data);
        }
    }

    public class XMLSerializator : ISerializer
    {
        public string Serialize<T>(List<T> data)
        {
            StringBuilder sb = new();
            TextWriter writer = new StringWriter(sb);
            XmlSerializer ser = new(data.GetType());
            ser.Serialize(writer, data);

            return sb.ToString();
        }
    }

    public class GeneratorProduct
    {
        public string GetProductA(ISerializer serializer, int count = 1)
        {
            return serializer.Serialize(FakerProductA.Generate(count));
        }

        public string GetProductB(ISerializer serializer, int count = 1)
        {
            return serializer.Serialize(FakerProductB.Generate(count));
        }

        public string GetProductC(ISerializer serializer, int count = 1)
        {
            return serializer.Serialize(FekerProductC.Generate(count));
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
