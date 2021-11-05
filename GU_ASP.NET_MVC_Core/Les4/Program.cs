using Bogus;
using Bogus.DataSets;
using Les4.Adapter;
using Les4.Products;
using Les4.Strategy;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Claims;
using System.Text;
using System.Xml;

namespace Les4
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneratorProduct generator = new GeneratorProduct();

            ISerializer jsonSerializer = new JsonSerializator();
            ISerializer xmlSerializer = new XMLSerializator();

            generator.GetProductA(jsonSerializer, 4);
            generator.GetProductB(jsonSerializer, 3);
            generator.GetProductC(xmlSerializer, 5);

            IDeserializerStrategy strategy = new ProductADeserializatoinStrategy();
            var context =  new DeserializatoinContext(new StreamReader("ProductA.json"));
            context.SetupDeserializatoinStrategy(strategy);
            context.Execute();
            var listProductA = (List<ProductA>)context.Result;
            for (int i = 0; i < listProductA.Count; i++)
            {
                IData data = new ProductAAdapter(listProductA[0]);
                data.Print();
            }

            strategy = new ProductBDeserializatoinStrategy();
            context = new DeserializatoinContext(new StreamReader("ProductB.json"));
            context.SetupDeserializatoinStrategy(strategy);
            context.Execute();
            var listProductB = (List<ProductB>)context.Result;
            for (int i = 0; i < listProductB.Count; i++)
            {
                IData data = new ProductBAdapter(listProductB[0]);
                data.Print();
            }

            strategy = new ProductCDeserializatoinStrategy();
            context = new DeserializatoinContext(new StreamReader("ProductC.xml"));
            context.SetupDeserializatoinStrategy(strategy);
            context.Execute();
            var listProductC = (List<ProductC>)context.Result;
            for (int i = 0; i < listProductC.Count; i++)
            {
                IData data = new ProductCAdapter(listProductC[0]);
                data.Print();
            }
        }
    }
}
