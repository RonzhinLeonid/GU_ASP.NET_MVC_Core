using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Bogus.DataSets;

namespace Les7
{
    public class Generator
    {
        Faker _faker;
        List<List<string>> _rowTable;
        public List<List<string>> RowTable { get { return _rowTable; } }
        public Generator(int countEmployee) 
        {
            _faker = new Faker("ru");
            _rowTable = new List<List<string>>();

            for (int i = 0; i < countEmployee; i++)
            {
                var row = new List<string>();
                row.Add(_faker.Name.FullName());
                var count = _faker.Random.Int(1, 10);
                for (int j = 0; j < count; j++)
                {
                    row.Add(GetPrefixNumberExercise() + _faker.Random.Int(100000, 999999) + "|" +
                       _faker.Random.Int(0, 100) + "|" +
                       _faker.Random.Int(1, 672) * 5);

                }
                _rowTable.Add(row);
            }
        }
        string GetPrefixNumberExercise() 
        {
            if (_faker.Random.Int(0, 2) == 0) return "ПЗ.";
            return "ТЗ.";
        }
    }
}
