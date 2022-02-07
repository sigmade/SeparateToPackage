using System;
using System.Linq;
using System.Text;

namespace SeparateToPackage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = Data.GetData().ToList();
            var total = data.Count;
            var packageSize = 5;

            do
            {
                var package = data
                    .Skip(data.Count - total)
                    .Take(packageSize);

                var sb = new StringBuilder("");

                foreach (var i in package)
                {
                    sb.Append($"update table set val = {i.Value} where KEY = '{i.Key}' ");
                }

                total -= packageSize;

                //execute query sb.ToString()
                Console.WriteLine(sb.ToString());
                Console.WriteLine(".......................");

            } while (total > 0);

            Console.ReadKey();
        }
    }
}
